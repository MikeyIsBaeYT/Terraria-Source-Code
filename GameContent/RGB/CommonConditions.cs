// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.CommonConditions
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public static class CommonConditions
  {
    public static readonly ChromaCondition InMenu = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.gameMenu && !Main.drunkWorld));
    public static readonly ChromaCondition DrunkMenu = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.gameMenu && Main.drunkWorld));

    public abstract class ConditionBase : ChromaCondition
    {
      protected Player CurrentPlayer => Main.player[Main.myPlayer];
    }

    private class SimpleCondition : CommonConditions.ConditionBase
    {
      private Func<Player, bool> _condition;

      public SimpleCondition(Func<Player, bool> condition) => this._condition = condition;

      public virtual bool IsActive() => this._condition(this.CurrentPlayer);
    }

    public static class SurfaceBiome
    {
      public static readonly ChromaCondition Ocean = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneBeach && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Desert = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneDesert && !player.ZoneBeach && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Jungle = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneJungle && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Snow = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneSnow && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Mushroom = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneGlowshroom && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Corruption = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneCorrupt && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Hallow = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneHallow && player.ZoneOverworldHeight));
      public static readonly ChromaCondition Crimson = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneCrimson && player.ZoneOverworldHeight));
    }

    public static class MiscBiome
    {
      public static readonly ChromaCondition Meteorite = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneMeteor));
    }

    public static class UndergroundBiome
    {
      public static readonly ChromaCondition Hive = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneHive));
      public static readonly ChromaCondition Jungle = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneJungle && !player.ZoneOverworldHeight));
      public static readonly ChromaCondition Mushroom = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneGlowshroom && !player.ZoneOverworldHeight));
      public static readonly ChromaCondition Ice = (ChromaCondition) new CommonConditions.SimpleCondition(new Func<Player, bool>(CommonConditions.UndergroundBiome.InIce));
      public static readonly ChromaCondition HallowIce = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.UndergroundBiome.InIce(player) && player.ZoneHallow));
      public static readonly ChromaCondition CrimsonIce = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.UndergroundBiome.InIce(player) && player.ZoneCrimson));
      public static readonly ChromaCondition CorruptIce = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.UndergroundBiome.InIce(player) && player.ZoneCorrupt));
      public static readonly ChromaCondition Hallow = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneHallow && !player.ZoneOverworldHeight));
      public static readonly ChromaCondition Crimson = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneCrimson && !player.ZoneOverworldHeight));
      public static readonly ChromaCondition Corrupt = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneCorrupt && !player.ZoneOverworldHeight));
      public static readonly ChromaCondition Desert = (ChromaCondition) new CommonConditions.SimpleCondition(new Func<Player, bool>(CommonConditions.UndergroundBiome.InDesert));
      public static readonly ChromaCondition HallowDesert = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.UndergroundBiome.InDesert(player) && player.ZoneHallow));
      public static readonly ChromaCondition CrimsonDesert = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.UndergroundBiome.InDesert(player) && player.ZoneCrimson));
      public static readonly ChromaCondition CorruptDesert = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.UndergroundBiome.InDesert(player) && player.ZoneCorrupt));
      public static readonly ChromaCondition Temple = (ChromaCondition) new CommonConditions.SimpleCondition(new Func<Player, bool>(CommonConditions.UndergroundBiome.InTemple));
      public static readonly ChromaCondition Dungeon = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneDungeon));
      public static readonly ChromaCondition Marble = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneMarble));
      public static readonly ChromaCondition Granite = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneGranite));
      public static readonly ChromaCondition GemCave = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneGemCave));

      private static bool InTemple(Player player)
      {
        int x = (int) ((double) player.position.X + (double) (player.width / 2)) / 16;
        int y = (int) ((double) player.position.Y + (double) (player.height / 2)) / 16;
        return WorldGen.InWorld(x, y) && Main.tile[x, y] != null && Main.tile[x, y].wall == (ushort) 87;
      }

      private static bool InIce(Player player) => player.ZoneSnow && !player.ZoneOverworldHeight;

      private static bool InDesert(Player player) => player.ZoneDesert && !player.ZoneOverworldHeight;
    }

    public static class Boss
    {
      public static int HighestTierBossOrEvent;
      public static readonly ChromaCondition EaterOfWorlds = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 13));
      public static readonly ChromaCondition Destroyer = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 134));
      public static readonly ChromaCondition KingSlime = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 50));
      public static readonly ChromaCondition QueenSlime = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 657));
      public static readonly ChromaCondition BrainOfCthulhu = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 266));
      public static readonly ChromaCondition DukeFishron = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 370));
      public static readonly ChromaCondition QueenBee = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 222));
      public static readonly ChromaCondition Plantera = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 262));
      public static readonly ChromaCondition Empress = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 636));
      public static readonly ChromaCondition EyeOfCthulhu = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 4));
      public static readonly ChromaCondition TheTwins = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 126));
      public static readonly ChromaCondition MoonLord = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 398));
      public static readonly ChromaCondition WallOfFlesh = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 113));
      public static readonly ChromaCondition Golem = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 245));
      public static readonly ChromaCondition Cultist = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 439));
      public static readonly ChromaCondition Skeletron = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == 35));
      public static readonly ChromaCondition SkeletronPrime = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == (int) sbyte.MaxValue));
    }

    public static class Weather
    {
      public static readonly ChromaCondition Rain = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneRain && !player.ZoneSnow && !player.ZoneSandstorm));
      public static readonly ChromaCondition Sandstorm = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneSandstorm));
      public static readonly ChromaCondition Blizzard = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneSnow && player.ZoneRain));
      public static readonly ChromaCondition SlimeRain = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.slimeRain && player.ZoneOverworldHeight));
    }

    public static class Depth
    {
      public static readonly ChromaCondition Sky = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => (double) player.position.Y / 16.0 < Main.worldSurface * 0.449999988079071));
      public static readonly ChromaCondition Surface = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneOverworldHeight && (double) player.position.Y / 16.0 >= Main.worldSurface * 0.449999988079071 && !CommonConditions.Depth.IsPlayerInFrontOfDirtWall(player)));
      public static readonly ChromaCondition Vines = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneOverworldHeight && (double) player.position.Y / 16.0 >= Main.worldSurface * 0.449999988079071 && CommonConditions.Depth.IsPlayerInFrontOfDirtWall(player)));
      public static readonly ChromaCondition Underground = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneDirtLayerHeight));
      public static readonly ChromaCondition Caverns = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneRockLayerHeight && player.position.ToTileCoordinates().Y <= Main.maxTilesY - 400));
      public static readonly ChromaCondition Magma = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneRockLayerHeight && player.position.ToTileCoordinates().Y > Main.maxTilesY - 400));
      public static readonly ChromaCondition Underworld = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneUnderworldHeight));

      private static bool IsPlayerInFrontOfDirtWall(Player player)
      {
        Point tileCoordinates = player.Center.ToTileCoordinates();
        if (!WorldGen.InWorld(tileCoordinates.X, tileCoordinates.Y) || Main.tile[tileCoordinates.X, tileCoordinates.Y] == null)
          return false;
        switch (Main.tile[tileCoordinates.X, tileCoordinates.Y].wall)
        {
          case 2:
          case 16:
          case 54:
          case 55:
          case 56:
          case 57:
          case 58:
          case 59:
          case 61:
          case 170:
          case 171:
          case 185:
          case 196:
          case 197:
          case 198:
          case 199:
          case 212:
          case 213:
          case 214:
          case 215:
            return true;
          default:
            return false;
        }
      }
    }

    public static class Events
    {
      public static readonly ChromaCondition BloodMoon = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.bloodMoon && !Main.snowMoon && !Main.pumpkinMoon));
      public static readonly ChromaCondition FrostMoon = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.snowMoon));
      public static readonly ChromaCondition PumpkinMoon = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.pumpkinMoon));
      public static readonly ChromaCondition SolarEclipse = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.eclipse));
      public static readonly ChromaCondition SolarPillar = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneTowerSolar));
      public static readonly ChromaCondition NebulaPillar = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneTowerNebula));
      public static readonly ChromaCondition VortexPillar = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneTowerVortex));
      public static readonly ChromaCondition StardustPillar = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.ZoneTowerStardust));
      public static readonly ChromaCondition PirateInvasion = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == -3));
      public static readonly ChromaCondition DD2Event = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == -6));
      public static readonly ChromaCondition FrostLegion = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == -2));
      public static readonly ChromaCondition MartianMadness = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == -4));
      public static readonly ChromaCondition GoblinArmy = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => CommonConditions.Boss.HighestTierBossOrEvent == -1));
    }

    public static class Alert
    {
      public static readonly ChromaCondition MoonlordComing = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => NPC.MoonLordCountdown > 0));
      public static readonly ChromaCondition Drowning = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.breath != player.breathMax));
      public static readonly ChromaCondition Keybinds = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.InGameUI.CurrentState == Main.ManageControlsMenu || Main.MenuUI.CurrentState == Main.ManageControlsMenu));
      public static readonly ChromaCondition LavaIndicator = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.lavaWet));
    }

    public static class CriticalAlert
    {
      public static readonly ChromaCondition LowLife = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => Main.ChromaPainter.PotionAlert));
      public static readonly ChromaCondition Death = (ChromaCondition) new CommonConditions.SimpleCondition((Func<Player, bool>) (player => player.dead));
    }
  }
}
