// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Events.DD2Event
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria.Chat;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Events
{
  public class DD2Event
  {
    private static readonly Color INFO_NEW_WAVE_COLOR = new Color(175, 55, (int) byte.MaxValue);
    private static readonly Color INFO_START_INVASION_COLOR = new Color(50, (int) byte.MaxValue, 130);
    private const int INVASION_ID = 3;
    public static bool DownedInvasionT1;
    public static bool DownedInvasionT2;
    public static bool DownedInvasionT3;
    public static bool LostThisRun;
    public static bool WonThisRun;
    public static int LaneSpawnRate = 60;
    private static bool _downedDarkMageT1;
    private static bool _downedOgreT2;
    private static bool _spawnedBetsyT3;
    public static bool Ongoing;
    public static Microsoft.Xna.Framework.Rectangle ArenaHitbox;
    private static int _arenaHitboxingCooldown;
    public static int OngoingDifficulty;
    private static List<Vector2> _deadGoblinSpots = new List<Vector2>();
    private static int _crystalsDropping_lastWave;
    private static int _crystalsDropping_toDrop;
    private static int _crystalsDropping_alreadyDropped;
    private static int _timeLeftUntilSpawningBegins;

    public static bool ReadyToFindBartender => NPC.downedBoss2;

    public static bool DownedInvasionAnyDifficulty => DD2Event.DownedInvasionT1 || DD2Event.DownedInvasionT2 || DD2Event.DownedInvasionT3;

    public static int TimeLeftBetweenWaves
    {
      get => DD2Event._timeLeftUntilSpawningBegins;
      set => DD2Event._timeLeftUntilSpawningBegins = value;
    }

    public static bool EnemySpawningIsOnHold => (uint) DD2Event._timeLeftUntilSpawningBegins > 0U;

    public static bool EnemiesShouldChasePlayers => DD2Event.Ongoing || true;

    public static void Save(BinaryWriter writer)
    {
      writer.Write(DD2Event.DownedInvasionT1);
      writer.Write(DD2Event.DownedInvasionT2);
      writer.Write(DD2Event.DownedInvasionT3);
    }

    public static void Load(BinaryReader reader, int gameVersionNumber)
    {
      if (gameVersionNumber < 178)
      {
        NPC.savedBartender = false;
        DD2Event.ResetProgressEntirely();
      }
      else
      {
        NPC.savedBartender = reader.ReadBoolean();
        DD2Event.DownedInvasionT1 = reader.ReadBoolean();
        DD2Event.DownedInvasionT2 = reader.ReadBoolean();
        DD2Event.DownedInvasionT3 = reader.ReadBoolean();
      }
    }

    public static void ResetProgressEntirely()
    {
      int num;
      DD2Event.DownedInvasionT3 = (num = 0) != 0;
      DD2Event.DownedInvasionT2 = num != 0;
      DD2Event.DownedInvasionT1 = num != 0;
      DD2Event.Ongoing = false;
      DD2Event.ArenaHitbox = new Microsoft.Xna.Framework.Rectangle();
      DD2Event._arenaHitboxingCooldown = 0;
      DD2Event._timeLeftUntilSpawningBegins = 0;
    }

    public static void ReportEventProgress()
    {
      int currentWave;
      int requiredKillCount;
      int currentKillCount;
      DD2Event.GetInvasionStatus(out currentWave, out requiredKillCount, out currentKillCount);
      Main.ReportInvasionProgress(currentKillCount, requiredKillCount, 3, currentWave);
    }

    public static void SyncInvasionProgress(int toWho)
    {
      int currentWave;
      int requiredKillCount;
      int currentKillCount;
      DD2Event.GetInvasionStatus(out currentWave, out requiredKillCount, out currentKillCount);
      NetMessage.SendData(78, toWho, number: currentKillCount, number2: ((float) requiredKillCount), number3: 3f, number4: ((float) currentWave));
    }

    public static void SpawnNPC(ref int newNPC)
    {
    }

    public static void UpdateTime()
    {
      if (!DD2Event.Ongoing && !Main.dedServ)
      {
        Filters.Scene.Deactivate("CrystalDestructionVortex");
        Filters.Scene.Deactivate("CrystalDestructionColor");
        Filters.Scene.Deactivate("CrystalWin");
      }
      else
      {
        if (Main.netMode != 1 && !NPC.AnyNPCs(548))
          DD2Event.StopInvasion();
        if (Main.netMode == 1)
        {
          if (DD2Event._timeLeftUntilSpawningBegins > 0)
            --DD2Event._timeLeftUntilSpawningBegins;
          if (DD2Event._timeLeftUntilSpawningBegins >= 0)
            return;
          DD2Event._timeLeftUntilSpawningBegins = 0;
        }
        else
        {
          if (DD2Event._timeLeftUntilSpawningBegins > 0)
          {
            --DD2Event._timeLeftUntilSpawningBegins;
            if (DD2Event._timeLeftUntilSpawningBegins == 0)
            {
              int currentWave;
              int requiredKillCount;
              int currentKillCount;
              DD2Event.GetInvasionStatus(out currentWave, out requiredKillCount, out currentKillCount);
              WorldGen.BroadcastText(Lang.GetInvasionWaveText(currentWave, DD2Event.GetEnemiesForWave(currentWave)), DD2Event.INFO_NEW_WAVE_COLOR);
              if (currentWave == 7 && DD2Event.OngoingDifficulty == 3)
                DD2Event.SummonBetsy();
              if (Main.netMode != 1)
                Main.ReportInvasionProgress(currentKillCount, requiredKillCount, 3, currentWave);
              if (Main.netMode == 2)
                NetMessage.SendData(78, number: Main.invasionProgress, number2: ((float) Main.invasionProgressMax), number3: 3f, number4: ((float) currentWave));
            }
          }
          if (DD2Event._timeLeftUntilSpawningBegins >= 0)
            return;
          DD2Event._timeLeftUntilSpawningBegins = 0;
        }
      }
    }

    public static void StartInvasion(int difficultyOverride = -1)
    {
      if (Main.netMode == 1)
        return;
      DD2Event._crystalsDropping_toDrop = 0;
      DD2Event._crystalsDropping_alreadyDropped = 0;
      DD2Event._crystalsDropping_lastWave = 0;
      DD2Event._timeLeftUntilSpawningBegins = 0;
      DD2Event.Ongoing = true;
      DD2Event.FindProperDifficulty();
      if (difficultyOverride != -1)
        DD2Event.OngoingDifficulty = difficultyOverride;
      DD2Event._deadGoblinSpots.Clear();
      DD2Event._downedDarkMageT1 = false;
      DD2Event._downedOgreT2 = false;
      DD2Event._spawnedBetsyT3 = false;
      DD2Event.LostThisRun = false;
      DD2Event.WonThisRun = false;
      NPC.waveKills = 0.0f;
      NPC.waveNumber = 1;
      DD2Event.ClearAllTowersInGame();
      WorldGen.BroadcastText(NetworkText.FromKey("DungeonDefenders2.InvasionStart"), DD2Event.INFO_START_INVASION_COLOR);
      NetMessage.SendData(7);
      if (Main.netMode != 1)
        Main.ReportInvasionProgress(0, 1, 3, 1);
      if (Main.netMode == 2)
        NetMessage.SendData(78, number2: 1f, number3: 3f, number4: 1f);
      DD2Event.SetEnemySpawningOnHold(300);
      DD2Event.WipeEntities();
    }

    public static void StopInvasion(bool win = false)
    {
      if (!DD2Event.Ongoing)
        return;
      if (win)
        DD2Event.WinInvasionInternal();
      DD2Event.Ongoing = false;
      DD2Event._deadGoblinSpots.Clear();
      if (Main.netMode == 1)
        return;
      NPC.waveKills = 0.0f;
      NPC.waveNumber = 0;
      DD2Event.WipeEntities();
      NetMessage.SendData(7);
    }

    private static void WinInvasionInternal()
    {
      if (DD2Event.OngoingDifficulty >= 1)
        DD2Event.DownedInvasionT1 = true;
      if (DD2Event.OngoingDifficulty >= 2)
        DD2Event.DownedInvasionT2 = true;
      if (DD2Event.OngoingDifficulty >= 3)
        DD2Event.DownedInvasionT3 = true;
      if (DD2Event.OngoingDifficulty == 1)
        DD2Event.DropMedals(3);
      if (DD2Event.OngoingDifficulty == 2)
        DD2Event.DropMedals(15);
      if (DD2Event.OngoingDifficulty == 3)
        DD2Event.DropMedals(60);
      WorldGen.BroadcastText(NetworkText.FromKey("DungeonDefenders2.InvasionWin"), DD2Event.INFO_START_INVASION_COLOR);
    }

    public static bool ReadyForTier2 => Main.hardMode && NPC.downedMechBossAny;

    public static bool ReadyForTier3 => Main.hardMode && NPC.downedGolemBoss;

    private static void FindProperDifficulty()
    {
      DD2Event.OngoingDifficulty = 1;
      if (DD2Event.ReadyForTier2)
        DD2Event.OngoingDifficulty = 2;
      if (!DD2Event.ReadyForTier3)
        return;
      DD2Event.OngoingDifficulty = 3;
    }

    public static void CheckProgress(int slainMonsterID)
    {
      if (Main.netMode == 1 || !DD2Event.Ongoing || DD2Event.LostThisRun || DD2Event.WonThisRun || DD2Event.EnemySpawningIsOnHold)
        return;
      int currentWave;
      int requiredKillCount;
      int currentKillCount;
      DD2Event.GetInvasionStatus(out currentWave, out requiredKillCount, out currentKillCount);
      float monsterPointsWorth = (float) DD2Event.GetMonsterPointsWorth(slainMonsterID);
      float waveKills = NPC.waveKills;
      NPC.waveKills += monsterPointsWorth;
      currentKillCount += (int) monsterPointsWorth;
      bool flag = false;
      int progressWave = currentWave;
      if ((double) NPC.waveKills >= (double) requiredKillCount && requiredKillCount != 0)
      {
        NPC.waveKills = 0.0f;
        ++NPC.waveNumber;
        flag = true;
        DD2Event.GetInvasionStatus(out currentWave, out requiredKillCount, out currentKillCount, true);
        if (DD2Event.WonThisRun)
        {
          if ((double) currentKillCount == (double) waveKills || (double) monsterPointsWorth == 0.0)
            return;
          if (Main.netMode != 1)
            Main.ReportInvasionProgress(currentKillCount, requiredKillCount, 3, currentWave);
          if (Main.netMode != 2)
            return;
          NetMessage.SendData(78, number: Main.invasionProgress, number2: ((float) Main.invasionProgressMax), number3: 3f, number4: ((float) currentWave));
          return;
        }
        int num = currentWave;
        WorldGen.BroadcastText(NetworkText.FromKey("DungeonDefenders2.WaveComplete"), DD2Event.INFO_NEW_WAVE_COLOR);
        DD2Event.SetEnemySpawningOnHold(1800);
        if (DD2Event.OngoingDifficulty == 1)
        {
          if (num == 5)
            DD2Event.DropMedals(1);
          if (num == 4)
            DD2Event.DropMedals(1);
        }
        if (DD2Event.OngoingDifficulty == 2)
        {
          if (num == 7)
            DD2Event.DropMedals(6);
          if (num == 6)
            DD2Event.DropMedals(3);
          if (num == 5)
            DD2Event.DropMedals(1);
        }
        if (DD2Event.OngoingDifficulty == 3)
        {
          if (num == 7)
            DD2Event.DropMedals(25);
          if (num == 6)
            DD2Event.DropMedals(11);
          if (num == 5)
            DD2Event.DropMedals(3);
          if (num == 4)
            DD2Event.DropMedals(1);
        }
      }
      if ((double) currentKillCount == (double) waveKills)
        return;
      if (flag)
      {
        int num = 1;
        int progressMax = 1;
        if (Main.netMode != 1)
          Main.ReportInvasionProgress(num, progressMax, 3, progressWave);
        if (Main.netMode != 2)
          return;
        NetMessage.SendData(78, number: num, number2: ((float) progressMax), number3: 3f, number4: ((float) progressWave));
      }
      else
      {
        if (Main.netMode != 1)
          Main.ReportInvasionProgress(currentKillCount, requiredKillCount, 3, currentWave);
        if (Main.netMode != 2)
          return;
        NetMessage.SendData(78, number: Main.invasionProgress, number2: ((float) Main.invasionProgressMax), number3: 3f, number4: ((float) currentWave));
      }
    }

    public static void StartVictoryScene()
    {
      DD2Event.WonThisRun = true;
      int firstNpc = NPC.FindFirstNPC(548);
      if (firstNpc == -1)
        return;
      Main.npc[firstNpc].ai[1] = 2f;
      Main.npc[firstNpc].ai[0] = 2f;
      Main.npc[firstNpc].netUpdate = true;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index] != null && Main.npc[index].active && Main.npc[index].type == 549)
        {
          Main.npc[index].ai[0] = 0.0f;
          Main.npc[index].ai[1] = 1f;
          Main.npc[index].netUpdate = true;
        }
      }
    }

    public static void ReportLoss()
    {
      DD2Event.LostThisRun = true;
      DD2Event.SetEnemySpawningOnHold(30);
    }

    private static void GetInvasionStatus(
      out int currentWave,
      out int requiredKillCount,
      out int currentKillCount,
      bool currentlyInCheckProgress = false)
    {
      currentWave = NPC.waveNumber;
      requiredKillCount = 10;
      currentKillCount = (int) NPC.waveKills;
      switch (DD2Event.OngoingDifficulty)
      {
        case 2:
          requiredKillCount = DD2Event.Difficulty_2_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
          break;
        case 3:
          requiredKillCount = DD2Event.Difficulty_3_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
          break;
        default:
          requiredKillCount = DD2Event.Difficulty_1_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
          break;
      }
    }

    private static short[] GetEnemiesForWave(int wave)
    {
      switch (DD2Event.OngoingDifficulty)
      {
        case 2:
          return DD2Event.Difficulty_2_GetEnemiesForWave(wave);
        case 3:
          return DD2Event.Difficulty_3_GetEnemiesForWave(wave);
        default:
          return DD2Event.Difficulty_1_GetEnemiesForWave(wave);
      }
    }

    private static int GetMonsterPointsWorth(int slainMonsterID)
    {
      switch (DD2Event.OngoingDifficulty)
      {
        case 2:
          return DD2Event.Difficulty_2_GetMonsterPointsWorth(slainMonsterID);
        case 3:
          return DD2Event.Difficulty_3_GetMonsterPointsWorth(slainMonsterID);
        default:
          return DD2Event.Difficulty_1_GetMonsterPointsWorth(slainMonsterID);
      }
    }

    public static void SpawnMonsterFromGate(Vector2 gateBottom)
    {
      switch (DD2Event.OngoingDifficulty)
      {
        case 2:
          DD2Event.Difficulty_2_SpawnMonsterFromGate(gateBottom);
          break;
        case 3:
          DD2Event.Difficulty_3_SpawnMonsterFromGate(gateBottom);
          break;
        default:
          DD2Event.Difficulty_1_SpawnMonsterFromGate(gateBottom);
          break;
      }
    }

    public static void SummonCrystal(int x, int y)
    {
      if (Main.netMode == 1)
        NetMessage.SendData(113, number: x, number2: ((float) y));
      else
        DD2Event.SummonCrystalDirect(x, y);
    }

    public static void SummonCrystalDirect(int x, int y)
    {
      if (NPC.AnyNPCs(548))
        return;
      Tile tileSafely = Framing.GetTileSafely(x, y);
      if (!tileSafely.active() || tileSafely.type != (ushort) 466)
        return;
      Point point = new Point(x * 16, y * 16);
      point.X -= (int) tileSafely.frameX / 18 * 16;
      point.Y -= (int) tileSafely.frameY / 18 * 16;
      point.X += 40;
      point.Y += 64;
      DD2Event.StartInvasion();
      NPC.NewNPC(point.X, point.Y, 548);
      DD2Event.DropStarterCrystals();
    }

    public static bool WouldFailSpawningHere(int x, int y)
    {
      Point xLeftEnd;
      Point xRightEnd;
      StrayMethods.CheckArenaScore(new Point(x, y).ToWorldCoordinates(), out xLeftEnd, out xRightEnd);
      int num1 = xRightEnd.X - x;
      int num2 = x - xLeftEnd.X;
      return num1 < 60 || num2 < 60;
    }

    public static void FailureMessage(int client)
    {
      LocalizedText text = Language.GetText("DungeonDefenders2.BartenderWarning");
      Color color = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0);
      if (Main.netMode == 2)
        ChatHelper.SendChatMessageToClient(NetworkText.FromKey(text.Key), color, client);
      else
        Main.NewText(text.Value, color.R, color.G, color.B);
    }

    public static void WipeEntities()
    {
      DD2Event.ClearAllTowersInGame();
      DD2Event.ClearAllDD2HostilesInGame();
      DD2Event.ClearAllDD2EnergyCrystalsInChests();
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(114);
    }

    public static void ClearAllTowersInGame()
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.projectile[index].active && ProjectileID.Sets.IsADD2Turret[Main.projectile[index].type])
          Main.projectile[index].Kill();
      }
    }

    public static void ClearAllDD2HostilesInGame()
    {
      for (int number = 0; number < 200; ++number)
      {
        if (Main.npc[number].active && NPCID.Sets.BelongsToInvasionOldOnesArmy[Main.npc[number].type])
        {
          Main.npc[number].active = false;
          if (Main.netMode == 2)
            NetMessage.SendData(23, number: number);
        }
      }
    }

    public static void ClearAllDD2EnergyCrystalsInGame()
    {
      for (int number = 0; number < 400; ++number)
      {
        Item obj = Main.item[number];
        if (obj.active && obj.type == 3822)
        {
          obj.active = false;
          if (Main.netMode == 2)
            NetMessage.SendData(21, number: number);
        }
      }
    }

    public static void ClearAllDD2EnergyCrystalsInChests()
    {
      if (Main.netMode == 1)
        return;
      List<int> currentlyOpenChests = Chest.GetCurrentlyOpenChests();
      for (int number = 0; number < 8000; ++number)
      {
        Chest chest = Main.chest[number];
        if (chest != null && currentlyOpenChests.Contains(number))
        {
          for (int index = 0; index < 40; ++index)
          {
            if (chest.item[index].type == 3822 && chest.item[index].stack > 0)
            {
              chest.item[index].TurnToAir();
              if (Main.netMode != 0)
                NetMessage.SendData(32, number: number, number2: ((float) index));
            }
          }
        }
      }
    }

    public static void AnnounceGoblinDeath(NPC n) => DD2Event._deadGoblinSpots.Add(n.Bottom);

    public static bool CanRaiseGoblinsHere(Vector2 spot)
    {
      int num = 0;
      foreach (Vector2 deadGoblinSpot in DD2Event._deadGoblinSpots)
      {
        if ((double) Vector2.DistanceSquared(deadGoblinSpot, spot) <= 640000.0)
        {
          ++num;
          if (num >= 3)
            return true;
        }
      }
      return false;
    }

    public static void RaiseGoblins(Vector2 spot)
    {
      List<Vector2> vector2List = new List<Vector2>();
      foreach (Vector2 deadGoblinSpot in DD2Event._deadGoblinSpots)
      {
        if ((double) Vector2.DistanceSquared(deadGoblinSpot, spot) <= 722500.0)
          vector2List.Add(deadGoblinSpot);
      }
      foreach (Vector2 vector2 in vector2List)
        DD2Event._deadGoblinSpots.Remove(vector2);
      int num = 0;
      foreach (Vector2 vec in vector2List)
      {
        Point tileCoordinates = vec.ToTileCoordinates();
        tileCoordinates.X += Main.rand.Next(-15, 16);
        Point result;
        if (WorldUtils.Find(tileCoordinates, Searches.Chain((GenSearch) new Searches.Down(50), (GenCondition) new Conditions.IsSolid()), out result))
        {
          if (DD2Event.OngoingDifficulty == 3)
            NPC.NewNPC(result.X * 16 + 8, result.Y * 16, 567);
          else
            NPC.NewNPC(result.X * 16 + 8, result.Y * 16, 566);
          if (++num >= 8)
            break;
        }
      }
    }

    public static void FindArenaHitbox()
    {
      if (DD2Event._arenaHitboxingCooldown > 0)
      {
        --DD2Event._arenaHitboxingCooldown;
      }
      else
      {
        DD2Event._arenaHitboxingCooldown = 60;
        Vector2 vector2_1 = new Vector2(float.MaxValue, float.MaxValue);
        Vector2 vector2_2 = new Vector2(0.0f, 0.0f);
        for (int index = 0; index < 200; ++index)
        {
          NPC npc = Main.npc[index];
          if (npc.active && (npc.type == 549 || npc.type == 548))
          {
            Vector2 topLeft = npc.TopLeft;
            if ((double) vector2_1.X > (double) topLeft.X)
              vector2_1.X = topLeft.X;
            if ((double) vector2_1.Y > (double) topLeft.Y)
              vector2_1.Y = topLeft.Y;
            Vector2 bottomRight = npc.BottomRight;
            if ((double) vector2_2.X < (double) bottomRight.X)
              vector2_2.X = bottomRight.X;
            if ((double) vector2_2.Y < (double) bottomRight.Y)
              vector2_2.Y = bottomRight.Y;
          }
        }
        Vector2 vector2_3 = new Vector2(16f, 16f) * 50f;
        vector2_1 -= vector2_3;
        vector2_2 += vector2_3;
        Vector2 vector2_4 = vector2_2 - vector2_1;
        DD2Event.ArenaHitbox.X = (int) vector2_1.X;
        DD2Event.ArenaHitbox.Y = (int) vector2_1.Y;
        DD2Event.ArenaHitbox.Width = (int) vector2_4.X;
        DD2Event.ArenaHitbox.Height = (int) vector2_4.Y;
      }
    }

    public static bool ShouldBlockBuilding(Vector2 worldPosition) => DD2Event.ArenaHitbox.Contains(worldPosition.ToPoint());

    public static void DropMedals(int numberOfMedals)
    {
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == 548)
          Main.npc[index].DropItemInstanced(Main.npc[index].position, Main.npc[index].Size, 3817, numberOfMedals, false);
      }
    }

    public static bool ShouldDropCrystals()
    {
      int currentWave;
      int requiredKillCount;
      int currentKillCount;
      DD2Event.GetInvasionStatus(out currentWave, out requiredKillCount, out currentKillCount);
      if (DD2Event._crystalsDropping_lastWave < currentWave)
      {
        ++DD2Event._crystalsDropping_lastWave;
        if (DD2Event._crystalsDropping_alreadyDropped > 0)
          DD2Event._crystalsDropping_alreadyDropped -= DD2Event._crystalsDropping_toDrop;
        switch (DD2Event.OngoingDifficulty)
        {
          case 1:
            switch (currentWave)
            {
              case 1:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 2:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 3:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
              case 4:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
              case 5:
                DD2Event._crystalsDropping_toDrop = 40;
                break;
            }
            break;
          case 2:
            switch (currentWave)
            {
              case 1:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 2:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 3:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 4:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 5:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 6:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
              case 7:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
            }
            break;
          case 3:
            switch (currentWave)
            {
              case 1:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 2:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 3:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 4:
                DD2Event._crystalsDropping_toDrop = 20;
                break;
              case 5:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
              case 6:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
              case 7:
                DD2Event._crystalsDropping_toDrop = 30;
                break;
            }
            break;
        }
      }
      if (Main.netMode != 0 && Main.expertMode)
        DD2Event._crystalsDropping_toDrop = (int) ((double) DD2Event._crystalsDropping_toDrop * (double) NPC.GetBalance());
      float num = (float) currentKillCount / (float) requiredKillCount;
      if ((double) DD2Event._crystalsDropping_alreadyDropped >= (double) DD2Event._crystalsDropping_toDrop * (double) num)
        return false;
      ++DD2Event._crystalsDropping_alreadyDropped;
      return true;
    }

    private static void SummonBetsy()
    {
      if (DD2Event._spawnedBetsyT3 || NPC.AnyNPCs(551))
        return;
      Vector2 Position = new Vector2(1f, 1f);
      int firstNpc = NPC.FindFirstNPC(548);
      if (firstNpc != -1)
        Position = Main.npc[firstNpc].Center;
      NPC.SpawnOnPlayer((int) Player.FindClosest(Position, 1, 1), 551);
      DD2Event._spawnedBetsyT3 = true;
    }

    private static void DropStarterCrystals()
    {
      for (int index1 = 0; index1 < 200; ++index1)
      {
        if (Main.npc[index1].active && Main.npc[index1].type == 548)
        {
          for (int index2 = 0; index2 < 5; ++index2)
            Item.NewItem(Main.npc[index1].position, Main.npc[index1].width, Main.npc[index1].height, 3822, 2);
          break;
        }
      }
    }

    private static void SetEnemySpawningOnHold(int forHowLong)
    {
      DD2Event._timeLeftUntilSpawningBegins = forHowLong;
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(116, number: DD2Event._timeLeftUntilSpawningBegins);
    }

    private static short[] Difficulty_1_GetEnemiesForWave(int wave)
    {
      DD2Event.LaneSpawnRate = 60;
      switch (wave)
      {
        case 1:
          DD2Event.LaneSpawnRate = 90;
          return new short[1]{ (short) 552 };
        case 2:
          return new short[2]{ (short) 552, (short) 555 };
        case 3:
          DD2Event.LaneSpawnRate = 55;
          return new short[3]
          {
            (short) 552,
            (short) 555,
            (short) 561
          };
        case 4:
          DD2Event.LaneSpawnRate = 50;
          return new short[4]
          {
            (short) 552,
            (short) 555,
            (short) 561,
            (short) 558
          };
        case 5:
          DD2Event.LaneSpawnRate = 40;
          return new short[5]
          {
            (short) 552,
            (short) 555,
            (short) 561,
            (short) 558,
            (short) 564
          };
        default:
          return new short[1]{ (short) 552 };
      }
    }

    private static int Difficulty_1_GetRequiredWaveKills(
      ref int waveNumber,
      ref int currentKillCount,
      bool currentlyInCheckProgress)
    {
      switch (waveNumber)
      {
        case -1:
          return 0;
        case 1:
          return 60;
        case 2:
          return 80;
        case 3:
          return 100;
        case 4:
          DD2Event._deadGoblinSpots.Clear();
          return 120;
        case 5:
          if (!DD2Event._downedDarkMageT1 && currentKillCount > 139)
            currentKillCount = 139;
          return 140;
        case 6:
          waveNumber = 5;
          currentKillCount = 1;
          if (currentlyInCheckProgress)
            DD2Event.StartVictoryScene();
          return 1;
        default:
          return 10;
      }
    }

    private static void Difficulty_1_SpawnMonsterFromGate(Vector2 gateBottom)
    {
      int x = (int) gateBottom.X;
      int y = (int) gateBottom.Y;
      int num1 = 50;
      int num2 = 6;
      if (NPC.waveNumber > 4)
        num2 = 12;
      else if (NPC.waveNumber > 3)
        num2 = 8;
      int num3 = 6;
      if (NPC.waveNumber > 4)
        num3 = 8;
      for (int index = 1; index < Main.CurrentFrameFlags.ActivePlayersCount; ++index)
      {
        num1 = (int) ((double) num1 * 1.3);
        num2 = (int) ((double) num2 * 1.3);
        num3 = (int) ((double) num3 * 1.3);
      }
      int number = 200;
      switch (NPC.waveNumber)
      {
        case 1:
          if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num1)
          {
            number = NPC.NewNPC(x, y, 552);
            break;
          }
          break;
        case 2:
          if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num1)
          {
            number = Main.rand.Next(7) != 0 ? NPC.NewNPC(x, y, 552) : NPC.NewNPC(x, y, 555);
            break;
          }
          break;
        case 3:
          if (Main.rand.Next(6) == 0 && NPC.CountNPCS(561) < num2)
          {
            number = NPC.NewNPC(x, y, 561);
            break;
          }
          if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num1)
          {
            number = Main.rand.Next(5) != 0 ? NPC.NewNPC(x, y, 552) : NPC.NewNPC(x, y, 555);
            break;
          }
          break;
        case 4:
          if (Main.rand.Next(12) == 0 && NPC.CountNPCS(558) < num3)
          {
            number = NPC.NewNPC(x, y, 558);
            break;
          }
          if (Main.rand.Next(5) == 0 && NPC.CountNPCS(561) < num2)
          {
            number = NPC.NewNPC(x, y, 561);
            break;
          }
          if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num1)
          {
            number = Main.rand.Next(5) != 0 ? NPC.NewNPC(x, y, 552) : NPC.NewNPC(x, y, 555);
            break;
          }
          break;
        case 5:
          int requiredKillCount;
          int currentKillCount;
          DD2Event.GetInvasionStatus(out int _, out requiredKillCount, out currentKillCount);
          if ((double) currentKillCount > (double) requiredKillCount * 0.5 && !NPC.AnyNPCs(564))
            number = NPC.NewNPC(x, y, 564);
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(558) < num3)
          {
            number = NPC.NewNPC(x, y, 558);
            break;
          }
          if (Main.rand.Next(4) == 0 && NPC.CountNPCS(561) < num2)
          {
            number = NPC.NewNPC(x, y, 561);
            break;
          }
          if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num1)
          {
            number = Main.rand.Next(4) != 0 ? NPC.NewNPC(x, y, 552) : NPC.NewNPC(x, y, 555);
            break;
          }
          break;
        default:
          number = NPC.NewNPC(x, y, 552);
          break;
      }
      if (Main.netMode != 2 || number >= 200)
        return;
      NetMessage.SendData(23, number: number);
    }

    private static int Difficulty_1_GetMonsterPointsWorth(int slainMonsterID)
    {
      if (NPC.waveNumber == 5 && (double) NPC.waveKills >= 139.0)
      {
        if (slainMonsterID != 564 && slainMonsterID != 565)
          return 0;
        DD2Event._downedDarkMageT1 = true;
        return 1;
      }
      if ((uint) (slainMonsterID - 551) > 14U)
      {
        switch (slainMonsterID)
        {
          case 568:
          case 569:
          case 570:
          case 571:
          case 572:
          case 573:
          case 574:
          case 575:
          case 576:
          case 577:
          case 578:
            break;
          default:
            return 0;
        }
      }
      return NPC.waveNumber == 5 && (double) NPC.waveKills == 138.0 || !Main.expertMode ? 1 : 2;
    }

    private static short[] Difficulty_2_GetEnemiesForWave(int wave)
    {
      DD2Event.LaneSpawnRate = 60;
      switch (wave)
      {
        case 1:
          DD2Event.LaneSpawnRate = 90;
          return new short[2]{ (short) 553, (short) 562 };
        case 2:
          DD2Event.LaneSpawnRate = 70;
          return new short[3]
          {
            (short) 553,
            (short) 562,
            (short) 572
          };
        case 3:
          return new short[5]
          {
            (short) 553,
            (short) 556,
            (short) 562,
            (short) 559,
            (short) 572
          };
        case 4:
          DD2Event.LaneSpawnRate = 55;
          return new short[5]
          {
            (short) 553,
            (short) 559,
            (short) 570,
            (short) 572,
            (short) 562
          };
        case 5:
          DD2Event.LaneSpawnRate = 50;
          return new short[6]
          {
            (short) 553,
            (short) 556,
            (short) 559,
            (short) 572,
            (short) 574,
            (short) 570
          };
        case 6:
          DD2Event.LaneSpawnRate = 45;
          return new short[8]
          {
            (short) 553,
            (short) 556,
            (short) 562,
            (short) 559,
            (short) 568,
            (short) 570,
            (short) 572,
            (short) 574
          };
        case 7:
          DD2Event.LaneSpawnRate = 42;
          return new short[8]
          {
            (short) 553,
            (short) 556,
            (short) 572,
            (short) 559,
            (short) 568,
            (short) 574,
            (short) 570,
            (short) 576
          };
        default:
          return new short[1]{ (short) 553 };
      }
    }

    private static int Difficulty_2_GetRequiredWaveKills(
      ref int waveNumber,
      ref int currentKillCount,
      bool currentlyInCheckProgress)
    {
      switch (waveNumber)
      {
        case -1:
          return 0;
        case 1:
          return 60;
        case 2:
          return 80;
        case 3:
          return 100;
        case 4:
          return 120;
        case 5:
          return 140;
        case 6:
          return 180;
        case 7:
          if (!DD2Event._downedOgreT2 && currentKillCount > 219)
            currentKillCount = 219;
          return 220;
        case 8:
          waveNumber = 7;
          currentKillCount = 1;
          if (currentlyInCheckProgress)
            DD2Event.StartVictoryScene();
          return 1;
        default:
          return 10;
      }
    }

    private static int Difficulty_2_GetMonsterPointsWorth(int slainMonsterID)
    {
      if (NPC.waveNumber == 7 && (double) NPC.waveKills >= 219.0)
      {
        if (slainMonsterID != 576 && slainMonsterID != 577)
          return 0;
        DD2Event._downedOgreT2 = true;
        return 1;
      }
      if ((uint) (slainMonsterID - 551) > 14U)
      {
        switch (slainMonsterID)
        {
          case 568:
          case 569:
          case 570:
          case 571:
          case 572:
          case 573:
          case 574:
          case 575:
          case 576:
          case 577:
          case 578:
            break;
          default:
            return 0;
        }
      }
      return NPC.waveNumber == 7 && (double) NPC.waveKills == 218.0 || !Main.expertMode ? 1 : 2;
    }

    private static void Difficulty_2_SpawnMonsterFromGate(Vector2 gateBottom)
    {
      int x = (int) gateBottom.X;
      int y = (int) gateBottom.Y;
      int num1 = 50;
      int num2 = 5;
      if (NPC.waveNumber > 1)
        num2 = 8;
      if (NPC.waveNumber > 3)
        num2 = 10;
      if (NPC.waveNumber > 5)
        num2 = 12;
      int num3 = 5;
      if (NPC.waveNumber > 4)
        num3 = 7;
      int num4 = 2;
      int num5 = 8;
      if (NPC.waveNumber > 3)
        num5 = 12;
      int num6 = 3;
      if (NPC.waveNumber > 5)
        num6 = 5;
      for (int index = 1; index < Main.CurrentFrameFlags.ActivePlayersCount; ++index)
      {
        num1 = (int) ((double) num1 * 1.3);
        num2 = (int) ((double) num2 * 1.3);
        num5 = (int) ((double) num1 * 1.3);
        num6 = (int) ((double) num1 * 1.35);
      }
      int number1 = 200;
      int number2 = 200;
      switch (NPC.waveNumber)
      {
        case 1:
          if (Main.rand.Next(20) == 0 && NPC.CountNPCS(562) < num2)
          {
            number1 = NPC.NewNPC(x, y, 562);
            break;
          }
          if (NPC.CountNPCS(553) < num1)
          {
            number1 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        case 2:
          if (Main.rand.Next(3) == 0 && NPC.CountNPCS(572) < num5)
          {
            number1 = NPC.NewNPC(x, y, 572);
            break;
          }
          if (Main.rand.Next(8) == 0 && NPC.CountNPCS(562) < num2)
          {
            number1 = NPC.NewNPC(x, y, 562);
            break;
          }
          if (NPC.CountNPCS(553) < num1)
          {
            number1 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        case 3:
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(572) < num5)
          {
            number1 = NPC.NewNPC(x, y, 572);
            break;
          }
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(559) < num3)
          {
            number1 = NPC.NewNPC(x, y, 559);
            break;
          }
          if (Main.rand.Next(8) == 0 && NPC.CountNPCS(562) < num2)
          {
            number1 = NPC.NewNPC(x, y, 562);
            break;
          }
          if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num1)
          {
            if (Main.rand.Next(4) == 0)
              number1 = NPC.NewNPC(x, y, 556);
            number2 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        case 4:
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(570) < num6)
          {
            number1 = NPC.NewNPC(x, y, 570);
            break;
          }
          if (Main.rand.Next(12) == 0 && NPC.CountNPCS(559) < num3)
          {
            number1 = NPC.NewNPC(x, y, 559);
            break;
          }
          if (Main.rand.Next(6) == 0 && NPC.CountNPCS(562) < num2)
          {
            number1 = NPC.NewNPC(x, y, 562);
            break;
          }
          if (Main.rand.Next(3) == 0 && NPC.CountNPCS(572) < num5)
          {
            number1 = NPC.NewNPC(x, y, 572);
            break;
          }
          if (NPC.CountNPCS(553) < num1)
          {
            number1 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        case 5:
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
          {
            number1 = NPC.NewNPC(x, y, 570);
            break;
          }
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(559) < num3)
          {
            number1 = NPC.NewNPC(x, y, 559);
            break;
          }
          if (Main.rand.Next(4) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
          {
            number1 = Main.rand.Next(2) != 0 ? NPC.NewNPC(x, y, 574) : NPC.NewNPC(x, y, 572);
            break;
          }
          if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num1)
          {
            if (Main.rand.Next(3) == 0)
              number1 = NPC.NewNPC(x, y, 556);
            number2 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        case 6:
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
          {
            number1 = NPC.NewNPC(x, y, 570);
            break;
          }
          if (Main.rand.Next(17) == 0 && NPC.CountNPCS(568) < num4)
          {
            number1 = NPC.NewNPC(x, y, 568);
            break;
          }
          if (Main.rand.Next(5) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
          {
            number1 = Main.rand.Next(2) == 0 ? NPC.NewNPC(x, y, 574) : NPC.NewNPC(x, y, 572);
            break;
          }
          if (Main.rand.Next(9) == 0 && NPC.CountNPCS(559) < num3)
          {
            number1 = NPC.NewNPC(x, y, 559);
            break;
          }
          if (Main.rand.Next(3) == 0 && NPC.CountNPCS(562) < num2)
          {
            number1 = NPC.NewNPC(x, y, 562);
            break;
          }
          if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num1)
          {
            if (Main.rand.Next(3) != 0)
              number1 = NPC.NewNPC(x, y, 556);
            number2 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        case 7:
          int requiredKillCount;
          int currentKillCount;
          DD2Event.GetInvasionStatus(out int _, out requiredKillCount, out currentKillCount);
          if ((double) currentKillCount > (double) requiredKillCount * 0.100000001490116 && !NPC.AnyNPCs(576))
          {
            number1 = NPC.NewNPC(x, y, 576);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
          {
            number1 = NPC.NewNPC(x, y, 570);
            break;
          }
          if (Main.rand.Next(17) == 0 && NPC.CountNPCS(568) < num4)
          {
            number1 = NPC.NewNPC(x, y, 568);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
          {
            number1 = Main.rand.Next(3) == 0 ? NPC.NewNPC(x, y, 574) : NPC.NewNPC(x, y, 572);
            break;
          }
          if (Main.rand.Next(11) == 0 && NPC.CountNPCS(559) < num3)
          {
            number1 = NPC.NewNPC(x, y, 559);
            break;
          }
          if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num1)
          {
            if (Main.rand.Next(2) == 0)
              number1 = NPC.NewNPC(x, y, 556);
            number2 = NPC.NewNPC(x, y, 553);
            break;
          }
          break;
        default:
          number1 = NPC.NewNPC(x, y, 553);
          break;
      }
      if (Main.netMode == 2 && number1 < 200)
        NetMessage.SendData(23, number: number1);
      if (Main.netMode != 2 || number2 >= 200)
        return;
      NetMessage.SendData(23, number: number2);
    }

    private static short[] Difficulty_3_GetEnemiesForWave(int wave)
    {
      DD2Event.LaneSpawnRate = 60;
      switch (wave)
      {
        case 1:
          DD2Event.LaneSpawnRate = 85;
          return new short[3]
          {
            (short) 554,
            (short) 557,
            (short) 563
          };
        case 2:
          DD2Event.LaneSpawnRate = 75;
          return new short[5]
          {
            (short) 554,
            (short) 557,
            (short) 563,
            (short) 573,
            (short) 578
          };
        case 3:
          DD2Event.LaneSpawnRate = 60;
          return new short[5]
          {
            (short) 554,
            (short) 563,
            (short) 560,
            (short) 573,
            (short) 571
          };
        case 4:
          DD2Event.LaneSpawnRate = 60;
          return new short[7]
          {
            (short) 554,
            (short) 560,
            (short) 571,
            (short) 573,
            (short) 563,
            (short) 575,
            (short) 565
          };
        case 5:
          DD2Event.LaneSpawnRate = 55;
          return new short[7]
          {
            (short) 554,
            (short) 557,
            (short) 573,
            (short) 575,
            (short) 571,
            (short) 569,
            (short) 577
          };
        case 6:
          DD2Event.LaneSpawnRate = 60;
          return new short[8]
          {
            (short) 554,
            (short) 557,
            (short) 563,
            (short) 560,
            (short) 569,
            (short) 571,
            (short) 577,
            (short) 565
          };
        case 7:
          DD2Event.LaneSpawnRate = 90;
          return new short[6]
          {
            (short) 554,
            (short) 557,
            (short) 563,
            (short) 569,
            (short) 571,
            (short) 551
          };
        default:
          return new short[1]{ (short) 554 };
      }
    }

    private static int Difficulty_3_GetRequiredWaveKills(
      ref int waveNumber,
      ref int currentKillCount,
      bool currentlyInCheckProgress)
    {
      switch (waveNumber)
      {
        case -1:
          return 0;
        case 1:
          return 60;
        case 2:
          return 80;
        case 3:
          return 100;
        case 4:
          return 120;
        case 5:
          return 140;
        case 6:
          return 180;
        case 7:
          int firstNpc = NPC.FindFirstNPC(551);
          if (firstNpc == -1)
            return 1;
          currentKillCount = 100 - (int) ((double) Main.npc[firstNpc].life / (double) Main.npc[firstNpc].lifeMax * 100.0);
          return 100;
        case 8:
          waveNumber = 7;
          currentKillCount = 1;
          if (currentlyInCheckProgress)
            DD2Event.StartVictoryScene();
          return 1;
        default:
          return 10;
      }
    }

    private static int Difficulty_3_GetMonsterPointsWorth(int slainMonsterID)
    {
      if (NPC.waveNumber == 7)
        return slainMonsterID == 551 ? 1 : 0;
      if ((uint) (slainMonsterID - 551) > 14U)
      {
        switch (slainMonsterID)
        {
          case 568:
          case 569:
          case 570:
          case 571:
          case 572:
          case 573:
          case 574:
          case 575:
          case 576:
          case 577:
          case 578:
            break;
          default:
            return 0;
        }
      }
      return !Main.expertMode ? 1 : 2;
    }

    private static void Difficulty_3_SpawnMonsterFromGate(Vector2 gateBottom)
    {
      int x = (int) gateBottom.X;
      int y = (int) gateBottom.Y;
      int num1 = 60;
      int num2 = 7;
      if (NPC.waveNumber > 1)
        num2 = 9;
      if (NPC.waveNumber > 3)
        num2 = 12;
      if (NPC.waveNumber > 5)
        num2 = 15;
      int num3 = 7;
      if (NPC.waveNumber > 4)
        num3 = 10;
      int num4 = 2;
      if (NPC.waveNumber > 5)
        num4 = 3;
      int num5 = 12;
      if (NPC.waveNumber > 3)
        num5 = 18;
      int num6 = 4;
      if (NPC.waveNumber > 5)
        num6 = 6;
      int num7 = 4;
      for (int index = 1; index < Main.CurrentFrameFlags.ActivePlayersCount; ++index)
      {
        num1 = (int) ((double) num1 * 1.3);
        num2 = (int) ((double) num2 * 1.3);
        num5 = (int) ((double) num1 * 1.3);
        num6 = (int) ((double) num1 * 1.35);
        num7 = (int) ((double) num7 * 1.3);
      }
      int number1 = 200;
      int number2 = 200;
      switch (NPC.waveNumber)
      {
        case 1:
          if (Main.rand.Next(18) == 0 && NPC.CountNPCS(563) < num2)
          {
            number1 = NPC.NewNPC(x, y, 563);
            break;
          }
          if (NPC.CountNPCS(554) < num1)
          {
            if (Main.rand.Next(7) == 0)
              number1 = NPC.NewNPC(x, y, 557);
            number2 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        case 2:
          if (Main.rand.Next(3) == 0 && NPC.CountNPCS(578) < num7)
          {
            number1 = NPC.NewNPC(x, y, 578);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(563) < num2)
          {
            number1 = NPC.NewNPC(x, y, 563);
            break;
          }
          if (Main.rand.Next(3) == 0 && NPC.CountNPCS(573) < num5)
          {
            number1 = NPC.NewNPC(x, y, 573);
            break;
          }
          if (NPC.CountNPCS(554) < num1)
          {
            if (Main.rand.Next(4) == 0)
              number1 = NPC.NewNPC(x, y, 557);
            number2 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        case 3:
          if (Main.rand.Next(13) == 0 && NPC.CountNPCS(571) < num6)
          {
            number1 = NPC.NewNPC(x, y, 571);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) < num5)
          {
            number1 = NPC.NewNPC(x, y, 573);
            break;
          }
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(560) < num3)
          {
            number1 = NPC.NewNPC(x, y, 560);
            break;
          }
          if (Main.rand.Next(8) == 0 && NPC.CountNPCS(563) < num2)
          {
            number1 = NPC.NewNPC(x, y, 563);
            break;
          }
          if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num1)
          {
            number1 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        case 4:
          if (Main.rand.Next(24) == 0 && !NPC.AnyNPCs(565))
          {
            number1 = NPC.NewNPC(x, y, 565);
            break;
          }
          if (Main.rand.Next(12) == 0 && NPC.CountNPCS(571) < num6)
          {
            number1 = NPC.NewNPC(x, y, 571);
            break;
          }
          if (Main.rand.Next(15) == 0 && NPC.CountNPCS(560) < num3)
          {
            number1 = NPC.NewNPC(x, y, 560);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(563) < num2)
          {
            number1 = NPC.NewNPC(x, y, 563);
            break;
          }
          if (Main.rand.Next(5) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
          {
            number1 = Main.rand.Next(3) == 0 ? NPC.NewNPC(x, y, 575) : NPC.NewNPC(x, y, 573);
            break;
          }
          if (NPC.CountNPCS(554) < num1)
          {
            number1 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        case 5:
          if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(577))
          {
            number1 = NPC.NewNPC(x, y, 577);
            break;
          }
          if (Main.rand.Next(17) == 0 && NPC.CountNPCS(569) < num4)
          {
            number1 = NPC.NewNPC(x, y, 569);
            break;
          }
          if (Main.rand.Next(8) == 0 && NPC.CountNPCS(571) < num6)
          {
            number1 = NPC.NewNPC(x, y, 571);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
          {
            number1 = Main.rand.Next(4) == 0 ? NPC.NewNPC(x, y, 575) : NPC.NewNPC(x, y, 573);
            break;
          }
          if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num1)
          {
            if (Main.rand.Next(3) == 0)
              number1 = NPC.NewNPC(x, y, 557);
            number2 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        case 6:
          if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(577))
          {
            number1 = NPC.NewNPC(x, y, 577);
            break;
          }
          if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(565))
          {
            number1 = NPC.NewNPC(x, y, 565);
            break;
          }
          if (Main.rand.Next(12) == 0 && NPC.CountNPCS(571) < num6)
          {
            number1 = NPC.NewNPC(x, y, 571);
            break;
          }
          if (Main.rand.Next(25) == 0 && NPC.CountNPCS(569) < num4)
          {
            number1 = NPC.NewNPC(x, y, 569);
            break;
          }
          if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
          {
            number1 = Main.rand.Next(3) == 0 ? NPC.NewNPC(x, y, 575) : NPC.NewNPC(x, y, 573);
            break;
          }
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(560) < num3)
          {
            number1 = NPC.NewNPC(x, y, 560);
            break;
          }
          if (Main.rand.Next(5) == 0 && NPC.CountNPCS(563) < num2)
          {
            number1 = NPC.NewNPC(x, y, 563);
            break;
          }
          if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num1)
          {
            if (Main.rand.Next(3) == 0)
              number1 = NPC.NewNPC(x, y, 557);
            number2 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        case 7:
          if (Main.rand.Next(20) == 0 && NPC.CountNPCS(571) < num6)
          {
            number1 = NPC.NewNPC(x, y, 571);
            break;
          }
          if (Main.rand.Next(17) == 0 && NPC.CountNPCS(569) < num4)
          {
            number1 = NPC.NewNPC(x, y, 569);
            break;
          }
          if (Main.rand.Next(10) == 0 && NPC.CountNPCS(563) < num2)
          {
            number1 = NPC.NewNPC(x, y, 563);
            break;
          }
          if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num1)
          {
            if (Main.rand.Next(5) == 0)
              number1 = NPC.NewNPC(x, y, 557);
            number2 = NPC.NewNPC(x, y, 554);
            break;
          }
          break;
        default:
          number1 = NPC.NewNPC(x, y, 554);
          break;
      }
      if (Main.netMode == 2 && number1 < 200)
        NetMessage.SendData(23, number: number1);
      if (Main.netMode != 2 || number2 >= 200)
        return;
      NetMessage.SendData(23, number: number2);
    }
  }
}
