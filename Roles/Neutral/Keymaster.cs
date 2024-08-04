using AmongUs.GameOptions;
using Hazel;
using InnerNet;
using System.Text;
using TOHE.Modules;
using TOHE.Roles.Core;
using TOHE.Roles.Neutral;
using UnityEngine;
using static TOHE.Options;
using static TOHE.Translator;
using static TOHE.Utils;

namespace TOHE.Roles.Neutral;

internal class Keymaster : RoleBase
{
    //===========================SETUP================================\\
    private const int Id = 30600;
    private static readonly HashSet<byte> playerIdList = [];
    public static bool HasEnabled = playerIdList.Any();
    
    public override CustomRoles ThisRoleBase => CustomRoles.Impostor;
    public override Custom_RoleType ThisRoleType => Custom_RoleType.NeutralChaos;
    //==================================================================\\

    private static readonly Dictionary<byte, HashSet<byte>> KeyedList = [];
    private static OptionItem KeyGiveCooldown;
    private static byte KeyID = 19;

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Keymaster);
        KeyGiveCooldown = FloatOptionItem.Create(Id + 10, GeneralOption.KillCooldown, new(0, 300, 5), 300f, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Keymaster])
            .SetValueFormat(OptionFormat.Seconds);
    }
    public override void Init()
    {
        playerIdList.Clear();
        KeyID = 19;
        KeyedList.Clear();
    }
    public override void Add(byte playerId)
    {
        playerIdList.Add(playerId);
        KeyedList[playerId] = [];

        if (!Main.ResetCamPlayerList.Contains(playerId))
            Main.ResetCamPlayerList.Add(playerId);
    }
    public override void Remove(byte playerId)
    {
        playerIdList.Remove(playerId);
        KeyedList.Remove(playerId);
    }

    public override void SetKillCooldown(byte id) => Main.AllPlayerKillCooldown[id] = KeyGiveCooldown.GetFloat();
    public override bool CanUseKillButton(PlayerControl pc) => true;
    public override bool CanUseImpostorVentButton(PlayerControl pc) => true;
    private static bool IsKeyed(byte pc, byte target) => KeyedList.TryGetValue(pc, out var Targets) && Targets.Contains(target);

    public static void SendRPC(PlayerControl player, PlayerControl target)
    {
        MessageWriter writer;
        writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncRoleSkill, SendOption.Reliable, -1);
        writer.WriteNetObject(Utils.GetPlayerById(playerIdList.First())); // setKeyedPlayer
        writer.Write(player.PlayerId);
        writer.Write(target.PlayerId);
        AmongUsClient.Instance.FinishRpcImmediately(writer);
    }
    public override void ReceiveRPC(MessageReader reader, PlayerControl NaN)
    {
        byte KeymasterId = reader.ReadByte();
        byte KeyedId = reader.ReadByte();
        KeyedList[KeymasterId].Add(KeyedId);
    }

    public override void OnEnterVent(PlayerControl pc, Vent vent)
    {
        pc.Notify(GetString("KeymasterRed"), 15f);
        var rand = IRandom.Instance;
        KeyID = (byte)rand.Next(1, 18);

        switch (KeyID)
        {
            case 1:
                pc.Notify(GetString("KeymasterRed"), 15f);
                break;
            case 2:
                pc.Notify(GetString("KeymasterBlue"), 15f);
                break;
            case 3:
                pc.Notify(GetString("KeymasterGreen"), 15f);
                break;
            case 4:
                pc.Notify(GetString("KeymasterPink"), 15f);
                break;
            case 5:
                pc.Notify(GetString("KeymasterOrange"), 15f);
                break;
            case 6:
                pc.Notify(GetString("KeymasterYellow"), 15f);
                break;
            case 7:
                pc.Notify(GetString("KeymasterBlack"), 15f);
                break;
            case 8:
                pc.Notify(GetString("KeymasterWhite"), 15f);
                break;
            case 9:
                pc.Notify(GetString("KeymasterPurple"), 15f);
                break;
            case 10:
                pc.Notify(GetString("KeymasterBrown"), 15f);
                break;
            case 11:
                pc.Notify(GetString("KeymasterCyan"), 15f);
                break;
            case 12:
                pc.Notify(GetString("KeymasterLime"), 15f);
                break;
            case 13:
                pc.Notify(GetString("KeymasterMaroon"), 15f);
                break;
            case 14:
                pc.Notify(GetString("KeymasterRose"), 15f);
                break;
            case 15:
                pc.Notify(GetString("KeymasterBanana"), 15f);
                break;
            case 16:
                pc.Notify(GetString("KeymasterGray"), 15f);
                break;
            case 17:
                pc.Notify(GetString("KeymasterTan"), 15f);
                break;
            case 18:
                pc.Notify(GetString("KeymasterCoral"), 15f);
                break;
            default: // just in case
                break;
        }
    }

    public override bool ForcedCheckMurderAsKiller(PlayerControl killer, PlayerControl target)
    {
        if (IsKeyed(killer.PlayerId, target.PlayerId))
        {
            killer.Notify(GetString("TargetAlreadyKeyedShouldNotHappen"));
            return false;
        }
        KeyedList[killer.PlayerId].Add(target.PlayerId);
        SendRPC(killer, target);
        NotifyRoles(SpecifySeer: killer);

        CheckKeyedAllPlayers();

        killer.ResetKillCooldown();
        killer.SetKillCooldown();

        return false;
    }

    private static bool IsKeyedAll(PlayerControl player)
    {
        if (!player.Is(CustomRoles.Keymaster)) return false;

        var (keyed, all) = KeyedPlayerCount(player.PlayerId);
        return keyed >= all;
    }
    private static (int, int) KeyedPlayerCount(byte playerId)
    {
        int all = Main.AllAlivePlayerControls.Count(pc => pc.PlayerId != playerId);
        int keyed = Main.AllAlivePlayerControls.Count(pc => pc.PlayerId != playerId && IsKeyed(playerId, pc.PlayerId));

        return (keyed, all);
    }

    public static void CheckKeyedAllPlayers()
    {
        foreach (var KeyedId in KeyedList.Keys)
        {
            var Keymaster = GetPlayerById(KeyedId);
            if (Keymaster == null) continue;

            if (IsKeyedAll(Keymaster))
            {
                playerIdList.Remove(KeyedId);

                Keymaster.GetRoleClass()?.OnAdd(KeyedId);

                Keymaster.Notify(GetString("KeymasterFOCUS"), time: 2f);
                Keymaster.RpcGuardAndKill(Keymaster);
                Keymaster.ResetKillCooldown();

                NotifyRoles(SpecifySeer: Keymaster);
                Keymaster.MarkDirtySettings();
            }
        }
    }
    public override string GetMark(PlayerControl seer, PlayerControl seen, bool isForMeeting = false)
        => IsKeyed(seer.PlayerId, seen.PlayerId) ? ColorString(GetRoleColor(CustomRoles.Keymaster), "♀") : string.Empty;

    public override string GetProgressText(byte playerId, bool comms)
    {
        var (keyed, all) = KeyedPlayerCount(playerId);
        return ColorString(GetRoleColor(CustomRoles.Keymaster).ShadeColor(0.25f), $"({keyed}/{all})");
    }
}
