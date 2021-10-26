// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Ambience.AmbienceServer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.GameContent.Ambience
{
  public class AmbienceServer
  {
    private const int MINIMUM_SECONDS_BETWEEN_SPAWNS = 10;
    private const int MAXIMUM_SECONDS_BETWEEN_SPAWNS = 120;
    private readonly Dictionary<SkyEntityType, Func<bool>> _spawnConditions = new Dictionary<SkyEntityType, Func<bool>>();
    private readonly Dictionary<SkyEntityType, Func<Player, bool>> _secondarySpawnConditionsPerPlayer = new Dictionary<SkyEntityType, Func<Player, bool>>();
    private int _updatesUntilNextAttempt;
    private List<AmbienceServer.AmbienceSpawnInfo> _forcedSpawns = new List<AmbienceServer.AmbienceSpawnInfo>();

    private static bool IsSunnyDay() => !Main.IsItRaining && Main.dayTime && !Main.eclipse;

    private static bool IsSunset() => Main.dayTime && Main.time > 40500.0;

    private static bool IsCalmNight() => !Main.IsItRaining && !Main.dayTime && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon;

    public AmbienceServer()
    {
      this.ResetSpawnTime();
      this._spawnConditions[SkyEntityType.BirdsV] = new Func<bool>(AmbienceServer.IsSunnyDay);
      this._spawnConditions[SkyEntityType.Wyvern] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() && Main.hardMode);
      this._spawnConditions[SkyEntityType.Airship] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() && Main.IsItAHappyWindyDay);
      this._spawnConditions[SkyEntityType.AirBalloon] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() && !Main.IsItAHappyWindyDay);
      this._spawnConditions[SkyEntityType.Eyeball] = (Func<bool>) (() => !Main.dayTime);
      this._spawnConditions[SkyEntityType.Butterflies] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() && !Main.IsItAHappyWindyDay && !NPC.TooWindyForButterflies && NPC.butterflyChance < 6);
      this._spawnConditions[SkyEntityType.LostKite] = (Func<bool>) (() => Main.dayTime && !Main.eclipse && Main.IsItAHappyWindyDay);
      this._spawnConditions[SkyEntityType.Vulture] = (Func<bool>) (() => AmbienceServer.IsSunnyDay());
      this._spawnConditions[SkyEntityType.Bats] = (Func<bool>) (() => AmbienceServer.IsSunset() && AmbienceServer.IsSunnyDay() || AmbienceServer.IsCalmNight());
      this._spawnConditions[SkyEntityType.PixiePosse] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() || AmbienceServer.IsCalmNight());
      this._spawnConditions[SkyEntityType.Seagulls] = (Func<bool>) (() => AmbienceServer.IsSunnyDay());
      this._spawnConditions[SkyEntityType.SlimeBalloons] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() && Main.IsItAHappyWindyDay);
      this._spawnConditions[SkyEntityType.Gastropods] = (Func<bool>) (() => AmbienceServer.IsCalmNight());
      this._spawnConditions[SkyEntityType.Pegasus] = (Func<bool>) (() => AmbienceServer.IsSunnyDay());
      this._spawnConditions[SkyEntityType.EaterOfSouls] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() || AmbienceServer.IsCalmNight());
      this._spawnConditions[SkyEntityType.Crimera] = (Func<bool>) (() => AmbienceServer.IsSunnyDay() || AmbienceServer.IsCalmNight());
      this._spawnConditions[SkyEntityType.Hellbats] = (Func<bool>) (() => true);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.Vulture] = (Func<Player, bool>) (player => player.ZoneDesert);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.PixiePosse] = (Func<Player, bool>) (player => player.ZoneHallow);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.Seagulls] = (Func<Player, bool>) (player => player.ZoneBeach);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.Gastropods] = (Func<Player, bool>) (player => player.ZoneHallow);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.Pegasus] = (Func<Player, bool>) (player => player.ZoneHallow);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.EaterOfSouls] = (Func<Player, bool>) (player => player.ZoneCorrupt);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.Crimera] = (Func<Player, bool>) (player => player.ZoneCrimson);
      this._secondarySpawnConditionsPerPlayer[SkyEntityType.Bats] = (Func<Player, bool>) (player => player.ZoneJungle);
    }

    private bool IsPlayerAtRightHeightForType(SkyEntityType type, Player plr) => type == SkyEntityType.Hellbats ? AmbienceServer.IsPlayerInAPlaceWhereTheyCanSeeAmbienceHell(plr) : AmbienceServer.IsPlayerInAPlaceWhereTheyCanSeeAmbienceSky(plr);

    public void Update()
    {
      this.SpawnForcedEntities();
      if (this._updatesUntilNextAttempt > 0)
      {
        this._updatesUntilNextAttempt -= Main.dayRate;
      }
      else
      {
        this.ResetSpawnTime();
        IEnumerable<SkyEntityType> source1 = this._spawnConditions.Where<KeyValuePair<SkyEntityType, Func<bool>>>((Func<KeyValuePair<SkyEntityType, Func<bool>>, bool>) (pair => pair.Value())).Select<KeyValuePair<SkyEntityType, Func<bool>>, SkyEntityType>((Func<KeyValuePair<SkyEntityType, Func<bool>>, SkyEntityType>) (pair => pair.Key));
        if (source1.Count<SkyEntityType>((Func<SkyEntityType, bool>) (type => true)) == 0)
          return;
        Player player;
        AmbienceServer.FindPlayerThatCanSeeBackgroundAmbience(out player);
        if (player == null)
          return;
        IEnumerable<SkyEntityType> source2 = source1.Where<SkyEntityType>((Func<SkyEntityType, bool>) (type => this.IsPlayerAtRightHeightForType(type, player) && this._secondarySpawnConditionsPerPlayer.ContainsKey(type) && this._secondarySpawnConditionsPerPlayer[type](player)));
        int maxValue = source2.Count<SkyEntityType>((Func<SkyEntityType, bool>) (type => true));
        if (maxValue == 0 || Main.rand.Next(5) < 3)
        {
          source2 = source1.Where<SkyEntityType>((Func<SkyEntityType, bool>) (type =>
          {
            if (!this.IsPlayerAtRightHeightForType(type, player))
              return false;
            return !this._secondarySpawnConditionsPerPlayer.ContainsKey(type) || this._secondarySpawnConditionsPerPlayer[type](player);
          }));
          maxValue = source2.Count<SkyEntityType>((Func<SkyEntityType, bool>) (type => true));
        }
        if (maxValue == 0)
          return;
        SkyEntityType type1 = source2.ElementAt<SkyEntityType>(Main.rand.Next(maxValue));
        this.SpawnForPlayer(player, type1);
      }
    }

    public void ResetSpawnTime() => this._updatesUntilNextAttempt = Main.rand.Next(600, 7200);

    public void ForceEntitySpawn(AmbienceServer.AmbienceSpawnInfo info) => this._forcedSpawns.Add(info);

    private void SpawnForcedEntities()
    {
      if (this._forcedSpawns.Count == 0)
        return;
      for (int index = this._forcedSpawns.Count - 1; index >= 0; --index)
      {
        AmbienceServer.AmbienceSpawnInfo forcedSpawn = this._forcedSpawns[index];
        Player player;
        if (forcedSpawn.targetPlayer == -1)
          AmbienceServer.FindPlayerThatCanSeeBackgroundAmbience(out player);
        else
          player = Main.player[forcedSpawn.targetPlayer];
        if (player != null && this.IsPlayerAtRightHeightForType(forcedSpawn.skyEntityType, player))
          this.SpawnForPlayer(player, forcedSpawn.skyEntityType);
        this._forcedSpawns.RemoveAt(index);
      }
    }

    private static void FindPlayerThatCanSeeBackgroundAmbience(out Player player)
    {
      player = (Player) null;
      int maxValue = ((IEnumerable<Player>) Main.player).Count<Player>((Func<Player, bool>) (plr => plr.active && AmbienceServer.IsPlayerInAPlaceWhereTheyCanSeeAmbience(plr)));
      if (maxValue == 0)
        return;
      player = ((IEnumerable<Player>) Main.player).Where<Player>((Func<Player, bool>) (plr => plr.active && AmbienceServer.IsPlayerInAPlaceWhereTheyCanSeeAmbience(plr))).ElementAt<Player>(Main.rand.Next(maxValue));
    }

    private static bool IsPlayerInAPlaceWhereTheyCanSeeAmbience(Player plr) => AmbienceServer.IsPlayerInAPlaceWhereTheyCanSeeAmbienceSky(plr) || AmbienceServer.IsPlayerInAPlaceWhereTheyCanSeeAmbienceHell(plr);

    private static bool IsPlayerInAPlaceWhereTheyCanSeeAmbienceSky(Player plr) => (double) plr.position.Y <= Main.worldSurface * 16.0 + 1600.0;

    private static bool IsPlayerInAPlaceWhereTheyCanSeeAmbienceHell(Player plr) => (double) plr.position.Y >= (double) ((Main.UnderworldLayer - 100) * 16);

    private void SpawnForPlayer(Player player, SkyEntityType type) => NetManager.Instance.BroadcastOrLoopback(NetAmbienceModule.SerializeSkyEntitySpawn(player, type));

    public struct AmbienceSpawnInfo
    {
      public SkyEntityType skyEntityType;
      public int targetPlayer;
    }
  }
}
