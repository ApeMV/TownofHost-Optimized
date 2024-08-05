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
    private static byte KeyID = 10;
    private static bool HasKey = false;
    private static bool FOCUSED = false;
    private static bool RED = false;
    private static bool BLUE = false;
    private static bool GREEN = false;
    private static bool PINK = false;
    private static bool CYAN = false;
    private static bool YELLOW = false;
    private static bool PURPLE = false;
    private static bool LIME = false;

    public override void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Keymaster);
        KeyGiveCooldown = FloatOptionItem.Create(Id + 10, GeneralOption.KillCooldown, new(0, 300, 5), 5f, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Keymaster])
            .SetValueFormat(OptionFormat.Seconds);
    }
    public override void Init()
    {
        playerIdList.Clear();
        HasKey = false;
        KeyID = 10;
        FOCUSED = false;
        RED = false;
        BLUE = false;
        GREEN = false;
        PINK = false;
        CYAN = false;
        YELLOW = false;
        PURPLE = false;
        LIME = false;
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
        if (IsKeyedAll(pc))
        {
        HasKey = false;
        }
        else
        {
        HasKey = true;
        pc.Notify(GetString("KeymasterGainedKey"), 5f);
        }
    }
    public override bool ForcedCheckMurderAsKiller(PlayerControl killer, PlayerControl target)
    {
        if (IsKeyed(killer.PlayerId, target.PlayerId))
        {
            return false;
        }
        if (HasKey == true)
        {
        KeyedList[killer.PlayerId].Add(target.PlayerId);
        SendRPC(killer, target);
        NotifyRoles(SpecifySeer: killer);
        killer.Notify(GetString("KeymasterMarkedPlayer"), 5f);

        CheckKeyedAllPlayers();

        killer.ResetKillCooldown();
        killer.SetKillCooldown();
        HasKey = false;
        }
        if (FOCUSED == true)
        {
        var rand = IRandom.Instance;
        KeyID = (byte)rand.Next(1, 8);

            switch (KeyID)
            {
                case 1:
                    killer.Notify(GetString("KeymasterRed"), 15f);
                    RED = true;
                    break;
                case 2:
                    killer.Notify(GetString("KeymasterBlue"), 15f);
                    BLUE = true;
                    break;
                case 3:
                    killer.Notify(GetString("KeymasterGreen"), 15f);
                    GREEN = true;
                    break;
                case 4:
                    killer.Notify(GetString("KeymasterPink"), 15f);
                    PINK = true;
                    break;
                case 5:
                    killer.Notify(GetString("KeymasterCyan"), 15f);
                    CYAN = true;
                    break;
                case 6:
                    killer.Notify(GetString("KeymasterYellow"), 15f);
                    YELLOW = true;
                    break;
                case 7:
                    killer.Notify(GetString("KeymasterPurple"), 15f);
                    PURPLE = true;
                    break;
                case 8:
                    killer.Notify(GetString("KeymasterLime"), 15f);
                    LIME = true;
                    break;
                default:
                    break;
            }
            FOCUSED = false;
            return false;
        }
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
                Keymaster.RpcGuardAndKill(Keymaster);
                Keymaster.ResetKillCooldown();
                FOCUSED = true;
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
