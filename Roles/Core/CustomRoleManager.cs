﻿using TOHE.Roles.Impostor;

namespace TOHE.Roles.Core;

public static class CustomRoleManager
{
    public static RoleBase GetRoleClass(this CustomRoles role) => role switch
    {
        // ==== Vanilla ====
        CustomRoles.Crewmate => new VanillaRole(),
        CustomRoles.Impostor => new VanillaRole(),

        // ==== Impostors ====
        CustomRoles.Shapeshifter => new VanillaRole(),
        CustomRoles.ImpostorTOHE => new VanillaRole(),
        CustomRoles.ShapeshifterTOHE => new VanillaRole(),
        CustomRoles.Arrogance => new Arrogance(),
        CustomRoles.Anonymous => new Anonymous(),
        CustomRoles.AntiAdminer => new AntiAdminer(),
        //CustomRoles.Bard => new Bard(),
        //CustomRoles.Berserker  => new Berserker(),
        //CustomRoles.Blackmailer => new Blackmailer(),
        //CustomRoles.Bomber => new Bomber(),
        //CustomRoles.BountyHunter => new BountyHunter(),
        //CustomRoles.OverKiller => new OverKiller(),
        //CustomRoles.Camouflager => new Camouflager(),
        //CustomRoles.Capitalism => new Capitalism(),
        //CustomRoles.Cantankerous => new Cantankerous(),
        //CustomRoles.Chronomancer => new Chronomancer(),
        //CustomRoles.EvilDiviner => new EvilDiviner(),
        //CustomRoles.Consort => new Consort(),
        //CustomRoles.Councillor => new Councillor(),
        //CustomRoles.Crewpostor => new Crewpostor(),
        //CustomRoles.CursedWolf => new CursedWolf(),
        //CustomRoles.Deathpact => new Deathpact(),
        //CustomRoles.Devourer => new Devourer(),
        //CustomRoles.Disperser => new Disperser(),
        //CustomRoles.Duellist => new Duellist(),
        //CustomRoles.Dazzler => new Dazzler(),
        //CustomRoles.Escapee => new Escapee(),
        //CustomRoles.Eraser => new Eraser(),
        //CustomRoles.EvilGuesser => new EvilGuesser(),
        //CustomRoles.EvilTracker => new EvilTracker(),
        //CustomRoles.FireWorks => new FireWorks(),
        //CustomRoles.Gambler => new Gambler(),
        //CustomRoles.Gangster => new Gangster(),
        //CustomRoles.Godfather => new Godfather(),
        //CustomRoles.Greedier => new Greedier(),
        //CustomRoles.Hangman => new Hangman(),
        //CustomRoles.Hitman => new Hitman(),
        //CustomRoles.Inhibitor => new Inhibitor(),
        //CustomRoles.Kamikaze => new Kamikaze(),
        //CustomRoles.Kidnapper => new Kidnapper(),
        //CustomRoles.Minimalism => new Minimalism(),
        //CustomRoles.BallLightning => new BallLightning(),
        //CustomRoles.Librarian => new Librarian(),
        //CustomRoles.Lurker => new Lurker(),
        //CustomRoles.Mafioso => new Mafioso(),
        //CustomRoles.Mastermind => new Mastermind(),
        //CustomRoles.Mafia => new Mafia(),
        //CustomRoles.SerialKiller => new SerialKiller(),
        //CustomRoles.Miner => new Miner(),
        //CustomRoles.Morphling => new Morphling(),
        //CustomRoles.Assassin => new Assassin(),
        //CustomRoles.Nuker => new Nuker(),
        //CustomRoles.Nullifier => new Nullifier(),
        //CustomRoles.Parasite => new Parasite(),
        //CustomRoles.Penguin => new Penguin(),
        //CustomRoles.Puppeteer => new Puppeteer(),
        //CustomRoles.QuickShooter => new QuickShooter(),
        //CustomRoles.Refugee => new Refugee(),
        //CustomRoles.RiftMaker => new RiftMaker(),
        //CustomRoles.Saboteur => new Saboteur(),
        //CustomRoles.Sapper => new Sapper(),
        //CustomRoles.Scavenger => new Scavenger(),
        //CustomRoles.Sniper => new Sniper(),
        //CustomRoles.ImperiusCurse => new ImperiusCurse(),
        //CustomRoles.Swapster => new Swapster(),
        //CustomRoles.Swiftclaw => new Swiftclaw(),
        //CustomRoles.Swooper => new Swooper(),
        //CustomRoles.Stealth => new Stealth(),
        //CustomRoles.TimeThief => new TimeThief(),
        //CustomRoles.BoobyTrap => new BoobyTrap(),
        //CustomRoles.Trickster => new Trickster(),
        //CustomRoles.Twister => new Twister(),
        //CustomRoles.Underdog => new Underdog(),
        //CustomRoles.Undertaker => new Undertaker(),
        //CustomRoles.Vampire => new Vampire(),
        //CustomRoles.Vindicator => new Vindicator(),
        //CustomRoles.Visionary => new Visionary(),
        //CustomRoles.Warlock => new Warlock(),
        //CustomRoles.Wildling => new Wildling(),
        //CustomRoles.Witch => new Witch(),
        //CustomRoles.YinYanger => new YinYanger(),
        //CustomRoles.Zombie => new Zombie(),

        // ==== Crewmates ====
        //CustomRoles.Engineer => new Engineer(),
        //CustomRoles.GuardianAngel => new GuardianAngel(),
        //CustomRoles.Scientist => new Scientist(),
        //CustomRoles.CrewmateTOHE => new CrewmateTOHE(),
        //CustomRoles.EngineerTOHE => new EngineerTOHE(),
        //CustomRoles.GuardianAngelTOHE => new GuardianAngelTOHE(),
        //CustomRoles.ScientistTOHE => new ScientistTOHE(),
        //CustomRoles.Addict => new Addict(),
        //CustomRoles.Aid => new Aid(),
        //CustomRoles.Alchemist => new Alchemist(),
        //CustomRoles.Altruist => new Altruist(),
        //CustomRoles.Analyzer => new Analyzer(),
        //CustomRoles.Autocrat => new Autocrat(),
        //CustomRoles.Beacon => new Beacon(),
        //CustomRoles.Benefactor => new Benefactor(),
        //CustomRoles.Bodyguard => new Bodyguard(),
        //CustomRoles.CameraMan => new CameraMan(),
        //CustomRoles.CyberStar => new CyberStar(),
        //CustomRoles.Chameleon => new Chameleon(),
        //CustomRoles.Cleaner => new Cleaner(),
        //CustomRoles.Cleanser => new Cleanser(),
        //CustomRoles.CopyCat => new CopyCat(),
        //CustomRoles.Bloodhound => new Bloodhound(),
        //CustomRoles.Crusader => new Crusader(),
        //CustomRoles.Demolitionist => new Demolitionist(),
        //CustomRoles.Deputy => new Deputy(),
        //CustomRoles.Detective => new Detective(),
        //CustomRoles.Detour => new Detour(),
        //CustomRoles.Dictator => new Dictator(),
        //CustomRoles.Doctor => new Doctor(),
        //CustomRoles.DonutDelivery => new DonutDelivery(),
        //CustomRoles.Doormaster => new Doormaster(),
        //CustomRoles.DovesOfNeace => new DovesOfNeace(),
        //CustomRoles.Drainer => new Drainer(),
        //CustomRoles.Druid => new Druid(),
        //CustomRoles.Electric => new Electric(),
        //CustomRoles.Enigma => new Enigma(),
        //CustomRoles.Escort => new Escort(),
        //CustomRoles.Express => new Express(),
        //CustomRoles.Farseer => new Farseer(),
        //CustomRoles.Divinator => new Divinator(),
        //CustomRoles.Gaulois => new Gaulois(),
        //CustomRoles.Glitch => new Glitch(),
        //CustomRoles.Grenadier => new Grenadier(),
        //CustomRoles.GuessManager => new GuessManager(),
        //CustomRoles.Guardian => new Guardian(),
        //CustomRoles.Ignitor => new Ignitor(),
        //CustomRoles.Insight => new Insight(),
        //CustomRoles.ParityCop => new ParityCop(),
        //CustomRoles.Jailor => new Jailor(),
        //CustomRoles.Judge => new Judge(),
        //CustomRoles.Needy => new Needy(),
        //CustomRoles.Lighter => new Lighter(),
        //CustomRoles.Lookout => new Lookout(),
        //CustomRoles.Luckey => new Luckey(),
        //CustomRoles.Marshall => new Marshall(),
        //CustomRoles.Mayor => new Mayor(),
        //CustomRoles.SabotageMaster => new SabotageMaster(),
        //CustomRoles.Medic => new Medic(),
        //CustomRoles.Mediumshiper => new Mediumshiper(),
        //CustomRoles.Merchant => new Merchant(),
        //CustomRoles.Monitor => new Monitor(),
        //CustomRoles.Mole => new Mole(),
        //CustomRoles.Monarch => new Monarch(),
        //CustomRoles.Mortician => new Mortician(),
        //CustomRoles.NiceEraser => new NiceEraser(),
        //CustomRoles.NiceGuesser => new NiceGuesser(),
        //CustomRoles.NiceHacker => new NiceHacker(),
        //CustomRoles.NiceSwapper => new NiceSwapper(),
        //CustomRoles.Nightmare => new Nightmare(),
        //CustomRoles.Observer => new Observer(),
        //CustomRoles.Oracle => new Oracle(),
        //CustomRoles.Paranoia => new Paranoia(),
        //CustomRoles.Philantropist => new Philantropist(),
        //CustomRoles.Psychic => new Psychic(),
        //CustomRoles.Rabbit => new Rabbit(),
        //CustomRoles.Randomizer => new Randomizer(),
        //CustomRoles.Ricochet => new Ricochet(),
        //CustomRoles.Sentinel => new Sentinel(),
        //CustomRoles.SecurityGuard => new SecurityGuard(),
        //CustomRoles.Sheriff => new Sheriff(),
        //CustomRoles.Shiftguard => new Shiftguard(),
        //CustomRoles.Snitch => new Snitch(),
        //CustomRoles.Spiritualist => new Spiritualist(),
        //CustomRoles.Speedrunner => new Speedrunner(),
        //CustomRoles.SpeedBooster => new SpeedBooster(),
        //CustomRoles.Spy => new Spy(),
        //CustomRoles.SuperStar => new SuperStar(),
        //CustomRoles.TaskManager => new TaskManager(),
        //CustomRoles.Tether => new Tether(),
        //CustomRoles.TimeManager => new TimeManager(),
        //CustomRoles.TimeMaster => new TimeMaster(),
        //CustomRoles.Tornado => new Tornado(),
        //CustomRoles.Tracker => new Tracker(),
        //CustomRoles.Transmitter => new Transmitter(),
        //CustomRoles.Transporter => new Transporter(),
        //CustomRoles.Tracefinder => new Tracefinder(),
        //CustomRoles.Tunneler => new Tunneler(),
        //CustomRoles.Ventguard => new Ventguard(),
        //CustomRoles.Veteran => new Veteran(),
        //CustomRoles.SwordsMan => new SwordsMan(),
        //CustomRoles.Witness => new Witness(),
        //CustomRoles.Agitater => new Agitater(),

        // ==== Neutrals ====
        //CustomRoles.Amnesiac => new Amnesiac(),
        //CustomRoles.Arsonist => new Arsonist(),
        //CustomRoles.Bandit => new Bandit(),
        //CustomRoles.BloodKnight => new BloodKnight(),
        //CustomRoles.Bubble => new Bubble(),
        //CustomRoles.Collector => new Collector(),
        //CustomRoles.Convener => new Convener(),
        //CustomRoles.Deathknight => new Deathknight(),
        //CustomRoles.Gamer => new Gamer(),
        //CustomRoles.Doppelganger => new Doppelganger(),
        //CustomRoles.Doomsayer => new Doomsayer(),
        //CustomRoles.Eclipse => new Eclipse(),
        //CustomRoles.Enderman => new Enderman(),
        //CustomRoles.Executioner => new Executioner(),
        //CustomRoles.Totocalcio => new Totocalcio(),
        //CustomRoles.God => new God(),
        //CustomRoles.FFF => new FFF(),
        //CustomRoles.HeadHunter => new HeadHunter(),
        //CustomRoles.HexMaster => new HexMaster(),
        //CustomRoles.Hookshot => new Hookshot(),
        //CustomRoles.Imitator => new Imitator(),
        //CustomRoles.Innocent => new Innocent(),
        //CustomRoles.Jackal => new Jackal(),
        //CustomRoles.Jester => new Jester(),
        //CustomRoles.Jinx => new Jinx(),
        //CustomRoles.Juggernaut => new Juggernaut(),
        //CustomRoles.Konan => new Konan(),
        //CustomRoles.Lawyer => new Lawyer(),
        //CustomRoles.Magician => new Magician(),
        //CustomRoles.Mario => new Mario(),
        //CustomRoles.Mathematician => new Mathematician(),
        //CustomRoles.Maverick => new Maverick(),
        //CustomRoles.Medusa => new Medusa(),
        //CustomRoles.Mycologist => new Mycologist(),
        //CustomRoles.Necromancer => new Necromancer(),
        //CustomRoles.Opportunist => new Opportunist(),
        //CustomRoles.Pelican => new Pelican(),
        //CustomRoles.Perceiver => new Perceiver(),
        //CustomRoles.Pestilence => new Pestilence(),
        //CustomRoles.Phantom => new Phantom(),
        //CustomRoles.Pickpocket => new Pickpocket(),
        //CustomRoles.PlagueBearer => new PlagueBearer(),
        //CustomRoles.PlagueDoctor => new PlagueDoctor(),
        //CustomRoles.Poisoner => new Poisoner(),
        //CustomRoles.Postman => new Postman(),
        //CustomRoles.Provocateur => new Provocateur(),
        //CustomRoles.Pursuer => new Pursuer(),
        //CustomRoles.Pyromaniac => new Pyromaniac(),
        //CustomRoles.Reckless => new Reckless(),
        //CustomRoles.Revolutionist => new Revolutionist(),
        //CustomRoles.Ritualist => new Ritualist(),
        //CustomRoles.Romantic => new Romantic(),
        //CustomRoles.RuthlessRomantic => new RuthlessRomantic(),
        //CustomRoles.NSerialKiller => new NSerialKiller(),
        //CustomRoles.Sidekick => new Sidekick(),
        //CustomRoles.SoulHunter => new SoulHunter(),
        //CustomRoles.Spiritcaller => new Spiritcaller(),
        //CustomRoles.Sprayer => new Sprayer(),
        //CustomRoles.DarkHide => new DarkHide(),
        //CustomRoles.Succubus => new Succubus(),
        //CustomRoles.Sunnyboy => new Sunnyboy(),
        //CustomRoles.Terrorist => new Terrorist(),
        //CustomRoles.Traitor => new Traitor(),
        //CustomRoles.Vengeance => new Vengeance(),
        //CustomRoles.VengefulRomantic => new VengefulRomantic(),
        //CustomRoles.Virus => new Virus(),
        //CustomRoles.Vulture => new Vulture(),
        //CustomRoles.Wraith => new Wraith(),
        //CustomRoles.Werewolf => new Werewolf(),
        //CustomRoles.WeaponMaster => new WeaponMaster(),
        //CustomRoles.Workaholic => new Workaholic(),
        //CustomRoles.KB_Normal => new KB_Normal(),
        //CustomRoles.Killer => new Killer(),
        //CustomRoles.Tasker => new Tasker(),
        //CustomRoles.Potato => new Potato(),
        //CustomRoles.GM => new GM(),
        //CustomRoles.Convict => new Convict(),
        _ => new VanillaRole(),
    };
}
