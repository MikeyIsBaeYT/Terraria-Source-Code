// Decompiled with JetBrains decompiler
// Type: Terraria.IO.WorldFile
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.IO
{
  public class WorldFile
  {
    private static object padlock = new object();
    public static double tempTime = Main.time;
    public static bool tempRaining = false;
    public static float tempMaxRain = 0.0f;
    public static int tempRainTime = 0;
    public static bool tempDayTime = Main.dayTime;
    public static bool tempBloodMoon = Main.bloodMoon;
    public static bool tempEclipse = Main.eclipse;
    public static int tempMoonPhase = Main.moonPhase;
    public static int tempCultistDelay = CultistRitual.delay;
    public static int versionNumber;
    public static bool IsWorldOnCloud = false;
    public static bool tempPartyGenuine = false;
    public static bool tempPartyManual = false;
    public static int tempPartyCooldown = 0;
    public static List<int> tempPartyCelebratingNPCs = new List<int>();
    private static bool HasCache = false;
    private static bool? CachedDayTime = new bool?();
    private static double? CachedTime = new double?();
    private static int? CachedMoonPhase = new int?();
    private static bool? CachedBloodMoon = new bool?();
    private static bool? CachedEclipse = new bool?();
    private static int? CachedCultistDelay = new int?();
    private static bool? CachedPartyGenuine = new bool?();
    private static bool? CachedPartyManual = new bool?();
    private static int? CachedPartyDaysOnCooldown = new int?();
    private static List<int> CachedCelebratingNPCs = new List<int>();
    private static bool? Cached_Sandstorm_Happening = new bool?();
    private static bool Temp_Sandstorm_Happening = false;
    private static int? Cached_Sandstorm_TimeLeft = new int?();
    private static int Temp_Sandstorm_TimeLeft = 0;
    private static float? Cached_Sandstorm_Severity = new float?();
    private static float Temp_Sandstorm_Severity = 0.0f;
    private static float? Cached_Sandstorm_IntendedSeverity = new float?();
    private static float Temp_Sandstorm_IntendedSeverity = 0.0f;

    public static event Action OnWorldLoad;

    public static void CacheSaveTime()
    {
      WorldFile.HasCache = true;
      WorldFile.CachedDayTime = new bool?(Main.dayTime);
      WorldFile.CachedTime = new double?(Main.time);
      WorldFile.CachedMoonPhase = new int?(Main.moonPhase);
      WorldFile.CachedBloodMoon = new bool?(Main.bloodMoon);
      WorldFile.CachedEclipse = new bool?(Main.eclipse);
      WorldFile.CachedCultistDelay = new int?(CultistRitual.delay);
      WorldFile.CachedPartyGenuine = new bool?(BirthdayParty.GenuineParty);
      WorldFile.CachedPartyManual = new bool?(BirthdayParty.ManualParty);
      WorldFile.CachedPartyDaysOnCooldown = new int?(BirthdayParty.PartyDaysOnCooldown);
      WorldFile.CachedCelebratingNPCs.Clear();
      WorldFile.CachedCelebratingNPCs.AddRange((IEnumerable<int>) BirthdayParty.CelebratingNPCs);
      WorldFile.Cached_Sandstorm_Happening = new bool?(Sandstorm.Happening);
      WorldFile.Cached_Sandstorm_TimeLeft = new int?(Sandstorm.TimeLeft);
      WorldFile.Cached_Sandstorm_Severity = new float?(Sandstorm.Severity);
      WorldFile.Cached_Sandstorm_IntendedSeverity = new float?(Sandstorm.IntendedSeverity);
    }

    private static void ResetTempsToDayTime()
    {
      WorldFile.tempDayTime = true;
      WorldFile.tempTime = 13500.0;
      WorldFile.tempMoonPhase = 0;
      WorldFile.tempBloodMoon = false;
      WorldFile.tempEclipse = false;
      WorldFile.tempCultistDelay = 86400;
      WorldFile.tempPartyManual = false;
      WorldFile.tempPartyGenuine = false;
      WorldFile.tempPartyCooldown = 0;
      WorldFile.tempPartyCelebratingNPCs.Clear();
      WorldFile.Temp_Sandstorm_Happening = false;
      WorldFile.Temp_Sandstorm_TimeLeft = 0;
      WorldFile.Temp_Sandstorm_Severity = 0.0f;
      WorldFile.Temp_Sandstorm_IntendedSeverity = 0.0f;
    }

    private static void SetTempToOngoing()
    {
      WorldFile.tempDayTime = Main.dayTime;
      WorldFile.tempTime = Main.time;
      WorldFile.tempMoonPhase = Main.moonPhase;
      WorldFile.tempBloodMoon = Main.bloodMoon;
      WorldFile.tempEclipse = Main.eclipse;
      WorldFile.tempCultistDelay = CultistRitual.delay;
      WorldFile.tempPartyManual = BirthdayParty.ManualParty;
      WorldFile.tempPartyGenuine = BirthdayParty.GenuineParty;
      WorldFile.tempPartyCooldown = BirthdayParty.PartyDaysOnCooldown;
      WorldFile.tempPartyCelebratingNPCs.Clear();
      WorldFile.tempPartyCelebratingNPCs.AddRange((IEnumerable<int>) BirthdayParty.CelebratingNPCs);
      WorldFile.Temp_Sandstorm_Happening = Sandstorm.Happening;
      WorldFile.Temp_Sandstorm_TimeLeft = Sandstorm.TimeLeft;
      WorldFile.Temp_Sandstorm_Severity = Sandstorm.Severity;
      WorldFile.Temp_Sandstorm_IntendedSeverity = Sandstorm.IntendedSeverity;
    }

    private static void SetTempToCache()
    {
      WorldFile.HasCache = false;
      WorldFile.tempDayTime = WorldFile.CachedDayTime.Value;
      WorldFile.tempTime = WorldFile.CachedTime.Value;
      WorldFile.tempMoonPhase = WorldFile.CachedMoonPhase.Value;
      WorldFile.tempBloodMoon = WorldFile.CachedBloodMoon.Value;
      WorldFile.tempEclipse = WorldFile.CachedEclipse.Value;
      WorldFile.tempCultistDelay = WorldFile.CachedCultistDelay.Value;
      WorldFile.tempPartyManual = WorldFile.CachedPartyManual.Value;
      WorldFile.tempPartyGenuine = WorldFile.CachedPartyGenuine.Value;
      WorldFile.tempPartyCooldown = WorldFile.CachedPartyDaysOnCooldown.Value;
      WorldFile.tempPartyCelebratingNPCs.Clear();
      WorldFile.tempPartyCelebratingNPCs.AddRange((IEnumerable<int>) WorldFile.CachedCelebratingNPCs);
      WorldFile.Temp_Sandstorm_Happening = WorldFile.Cached_Sandstorm_Happening.Value;
      WorldFile.Temp_Sandstorm_TimeLeft = WorldFile.Cached_Sandstorm_TimeLeft.Value;
      WorldFile.Temp_Sandstorm_Severity = WorldFile.Cached_Sandstorm_Severity.Value;
      WorldFile.Temp_Sandstorm_IntendedSeverity = WorldFile.Cached_Sandstorm_IntendedSeverity.Value;
    }

    public static void SetOngoingToTemps()
    {
      Main.dayTime = WorldFile.tempDayTime;
      Main.time = WorldFile.tempTime;
      Main.moonPhase = WorldFile.tempMoonPhase;
      Main.bloodMoon = WorldFile.tempBloodMoon;
      Main.eclipse = WorldFile.tempEclipse;
      Main.raining = WorldFile.tempRaining;
      Main.rainTime = WorldFile.tempRainTime;
      Main.maxRaining = WorldFile.tempMaxRain;
      Main.cloudAlpha = WorldFile.tempMaxRain;
      CultistRitual.delay = WorldFile.tempCultistDelay;
      BirthdayParty.ManualParty = WorldFile.tempPartyManual;
      BirthdayParty.GenuineParty = WorldFile.tempPartyGenuine;
      BirthdayParty.PartyDaysOnCooldown = WorldFile.tempPartyCooldown;
      BirthdayParty.CelebratingNPCs.Clear();
      BirthdayParty.CelebratingNPCs.AddRange((IEnumerable<int>) WorldFile.tempPartyCelebratingNPCs);
      Sandstorm.Happening = WorldFile.Temp_Sandstorm_Happening;
      Sandstorm.TimeLeft = WorldFile.Temp_Sandstorm_TimeLeft;
      Sandstorm.Severity = WorldFile.Temp_Sandstorm_Severity;
      Sandstorm.IntendedSeverity = WorldFile.Temp_Sandstorm_IntendedSeverity;
    }

    public static void loadWorld(bool loadFromCloud)
    {
      WorldFile.IsWorldOnCloud = loadFromCloud;
      Main.checkXMas();
      Main.checkHalloween();
      bool flag = loadFromCloud && SocialAPI.Cloud != null;
      if (!FileUtilities.Exists(Main.worldPathName, flag) && Main.autoGen)
      {
        if (!flag)
        {
          for (int index = Main.worldPathName.Length - 1; index >= 0; --index)
          {
            if (Main.worldPathName.Substring(index, 1) == (Path.DirectorySeparatorChar.ToString() ?? ""))
            {
              Directory.CreateDirectory(Main.worldPathName.Substring(0, index));
              break;
            }
          }
        }
        WorldGen.clearWorld();
        Main.ActiveWorldFileData = WorldFile.CreateMetadata(Main.worldName == "" ? "World" : Main.worldName, flag, Main.expertMode);
        string seedText = (Main.AutogenSeedName ?? "").Trim();
        if (seedText.Length == 0)
          Main.ActiveWorldFileData.SetSeedToRandom();
        else
          Main.ActiveWorldFileData.SetSeed(seedText);
        WorldGen.generateWorld(Main.ActiveWorldFileData.Seed, Main.AutogenProgress);
        WorldFile.saveWorld();
      }
      using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(Main.worldPathName, flag)))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) memoryStream))
        {
          try
          {
            WorldGen.loadFailed = false;
            WorldGen.loadSuccess = false;
            int num1;
            WorldFile.versionNumber = num1 = binaryReader.ReadInt32();
            int num2 = num1 > 87 ? WorldFile.LoadWorld_Version2(binaryReader) : WorldFile.LoadWorld_Version1(binaryReader);
            if (num1 < 141)
              Main.ActiveWorldFileData.CreationTime = loadFromCloud ? DateTime.Now : File.GetCreationTime(Main.worldPathName);
            binaryReader.Close();
            memoryStream.Close();
            if (num2 != 0)
              WorldGen.loadFailed = true;
            else
              WorldGen.loadSuccess = true;
            if (WorldGen.loadFailed || !WorldGen.loadSuccess)
              return;
            WorldGen.gen = true;
            WorldGen.waterLine = Main.maxTilesY;
            Liquid.QuickWater(2);
            WorldGen.WaterCheck();
            int num3 = 0;
            Liquid.quickSettle = true;
            int num4 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
            float num5 = 0.0f;
            while (Liquid.numLiquid > 0 && num3 < 100000)
            {
              ++num3;
              float num6 = (float) (num4 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float) num4;
              if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num4)
                num4 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
              if ((double) num6 > (double) num5)
                num5 = num6;
              else
                num6 = num5;
              Main.statusText = Lang.gen[27].Value + " " + (object) (int) ((double) num6 * 100.0 / 2.0 + 50.0) + "%";
              Liquid.UpdateLiquid();
            }
            Liquid.quickSettle = false;
            Main.weatherCounter = WorldGen.genRand.Next(3600, 18000);
            Cloud.resetClouds();
            WorldGen.WaterCheck();
            WorldGen.gen = false;
            NPC.setFireFlyChance();
            Main.InitLifeBytes();
            if (Main.slimeRainTime > 0.0)
              Main.StartSlimeRain(false);
            NPC.setWorldMonsters();
          }
          catch
          {
            WorldGen.loadFailed = true;
            WorldGen.loadSuccess = false;
            try
            {
              binaryReader.Close();
              memoryStream.Close();
              return;
            }
            catch
            {
              return;
            }
          }
        }
      }
      if (WorldFile.OnWorldLoad == null)
        return;
      WorldFile.OnWorldLoad();
    }

    public static void saveWorld() => WorldFile.saveWorld(WorldFile.IsWorldOnCloud);

    public static void saveWorld(bool useCloudSaving, bool resetTime = false)
    {
      if (useCloudSaving && SocialAPI.Cloud == null)
        return;
      if (Main.worldName == "")
        Main.worldName = "World";
      if (WorldGen.saveLock)
        return;
      WorldGen.saveLock = true;
      while (WorldGen.IsGeneratingHardMode)
        Main.statusText = Lang.gen[48].Value;
      lock (WorldFile.padlock)
      {
        try
        {
          Directory.CreateDirectory(Main.WorldPath);
        }
        catch
        {
        }
        if (Main.skipMenu)
          return;
        if (WorldFile.HasCache)
          WorldFile.SetTempToCache();
        else
          WorldFile.SetTempToOngoing();
        if (resetTime)
          WorldFile.ResetTempsToDayTime();
        if (Main.worldPathName == null)
          return;
        new Stopwatch().Start();
        byte[] data1 = (byte[]) null;
        int num = 0;
        using (MemoryStream memoryStream = new MemoryStream(7000000))
        {
          using (BinaryWriter writer = new BinaryWriter((Stream) memoryStream))
            WorldFile.SaveWorld_Version2(writer);
          data1 = memoryStream.ToArray();
          num = data1.Length;
        }
        if (data1 == null)
          return;
        byte[] data2 = (byte[]) null;
        if (FileUtilities.Exists(Main.worldPathName, useCloudSaving))
          data2 = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
        FileUtilities.Write(Main.worldPathName, data1, num, useCloudSaving);
        byte[] buffer = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
        string path = (string) null;
        using (MemoryStream memoryStream = new MemoryStream(buffer, 0, num, false))
        {
          using (BinaryReader fileIO = new BinaryReader((Stream) memoryStream))
          {
            if (!Main.validateSaves || WorldFile.validateWorld(fileIO))
            {
              if (data2 != null)
              {
                path = Main.worldPathName + ".bak";
                Main.statusText = Lang.gen[50].Value;
              }
            }
            else
              path = Main.worldPathName;
          }
        }
        if (path != null && data2 != null)
          FileUtilities.WriteAllBytes(path, data2, useCloudSaving);
        WorldGen.saveLock = false;
      }
      Main.serverGenLock = false;
    }

    public static int LoadWorld_Version1(BinaryReader fileIO)
    {
      Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
      int versionNumber = WorldFile.versionNumber;
      if (versionNumber > 194)
        return 1;
      Main.worldName = fileIO.ReadString();
      Main.worldID = fileIO.ReadInt32();
      Main.leftWorld = (float) fileIO.ReadInt32();
      Main.rightWorld = (float) fileIO.ReadInt32();
      Main.topWorld = (float) fileIO.ReadInt32();
      Main.bottomWorld = (float) fileIO.ReadInt32();
      Main.maxTilesY = fileIO.ReadInt32();
      Main.maxTilesX = fileIO.ReadInt32();
      Main.expertMode = versionNumber >= 112 && fileIO.ReadBoolean();
      if (versionNumber >= 63)
        Main.moonType = (int) fileIO.ReadByte();
      else
        WorldGen.RandomizeMoonState();
      WorldGen.clearWorld();
      if (versionNumber >= 44)
      {
        Main.treeX[0] = fileIO.ReadInt32();
        Main.treeX[1] = fileIO.ReadInt32();
        Main.treeX[2] = fileIO.ReadInt32();
        Main.treeStyle[0] = fileIO.ReadInt32();
        Main.treeStyle[1] = fileIO.ReadInt32();
        Main.treeStyle[2] = fileIO.ReadInt32();
        Main.treeStyle[3] = fileIO.ReadInt32();
      }
      if (versionNumber >= 60)
      {
        Main.caveBackX[0] = fileIO.ReadInt32();
        Main.caveBackX[1] = fileIO.ReadInt32();
        Main.caveBackX[2] = fileIO.ReadInt32();
        Main.caveBackStyle[0] = fileIO.ReadInt32();
        Main.caveBackStyle[1] = fileIO.ReadInt32();
        Main.caveBackStyle[2] = fileIO.ReadInt32();
        Main.caveBackStyle[3] = fileIO.ReadInt32();
        Main.iceBackStyle = fileIO.ReadInt32();
        if (versionNumber >= 61)
        {
          Main.jungleBackStyle = fileIO.ReadInt32();
          Main.hellBackStyle = fileIO.ReadInt32();
        }
      }
      else
        WorldGen.RandomizeCaveBackgrounds();
      Main.spawnTileX = fileIO.ReadInt32();
      Main.spawnTileY = fileIO.ReadInt32();
      Main.worldSurface = fileIO.ReadDouble();
      Main.rockLayer = fileIO.ReadDouble();
      WorldFile.tempTime = fileIO.ReadDouble();
      WorldFile.tempDayTime = fileIO.ReadBoolean();
      WorldFile.tempMoonPhase = fileIO.ReadInt32();
      WorldFile.tempBloodMoon = fileIO.ReadBoolean();
      if (versionNumber >= 70)
      {
        WorldFile.tempEclipse = fileIO.ReadBoolean();
        Main.eclipse = WorldFile.tempEclipse;
      }
      Main.dungeonX = fileIO.ReadInt32();
      Main.dungeonY = fileIO.ReadInt32();
      WorldGen.crimson = versionNumber >= 56 && fileIO.ReadBoolean();
      NPC.downedBoss1 = fileIO.ReadBoolean();
      NPC.downedBoss2 = fileIO.ReadBoolean();
      NPC.downedBoss3 = fileIO.ReadBoolean();
      if (versionNumber >= 66)
        NPC.downedQueenBee = fileIO.ReadBoolean();
      if (versionNumber >= 44)
      {
        NPC.downedMechBoss1 = fileIO.ReadBoolean();
        NPC.downedMechBoss2 = fileIO.ReadBoolean();
        NPC.downedMechBoss3 = fileIO.ReadBoolean();
        NPC.downedMechBossAny = fileIO.ReadBoolean();
      }
      if (versionNumber >= 64)
      {
        NPC.downedPlantBoss = fileIO.ReadBoolean();
        NPC.downedGolemBoss = fileIO.ReadBoolean();
      }
      if (versionNumber >= 29)
      {
        NPC.savedGoblin = fileIO.ReadBoolean();
        NPC.savedWizard = fileIO.ReadBoolean();
        if (versionNumber >= 34)
        {
          NPC.savedMech = fileIO.ReadBoolean();
          if (versionNumber >= 80)
            NPC.savedStylist = fileIO.ReadBoolean();
        }
        if (versionNumber >= 129)
          NPC.savedTaxCollector = fileIO.ReadBoolean();
        NPC.downedGoblins = fileIO.ReadBoolean();
      }
      if (versionNumber >= 32)
        NPC.downedClown = fileIO.ReadBoolean();
      if (versionNumber >= 37)
        NPC.downedFrost = fileIO.ReadBoolean();
      if (versionNumber >= 56)
        NPC.downedPirates = fileIO.ReadBoolean();
      WorldGen.shadowOrbSmashed = fileIO.ReadBoolean();
      WorldGen.spawnMeteor = fileIO.ReadBoolean();
      WorldGen.shadowOrbCount = (int) fileIO.ReadByte();
      if (versionNumber >= 23)
      {
        WorldGen.altarCount = fileIO.ReadInt32();
        Main.hardMode = fileIO.ReadBoolean();
      }
      Main.invasionDelay = fileIO.ReadInt32();
      Main.invasionSize = fileIO.ReadInt32();
      Main.invasionType = fileIO.ReadInt32();
      Main.invasionX = fileIO.ReadDouble();
      if (versionNumber >= 113)
        Main.sundialCooldown = (int) fileIO.ReadByte();
      if (versionNumber >= 53)
      {
        WorldFile.tempRaining = fileIO.ReadBoolean();
        WorldFile.tempRainTime = fileIO.ReadInt32();
        WorldFile.tempMaxRain = fileIO.ReadSingle();
      }
      if (versionNumber >= 54)
      {
        WorldGen.oreTier1 = fileIO.ReadInt32();
        WorldGen.oreTier2 = fileIO.ReadInt32();
        WorldGen.oreTier3 = fileIO.ReadInt32();
      }
      else if (versionNumber >= 23 && WorldGen.altarCount == 0)
      {
        WorldGen.oreTier1 = -1;
        WorldGen.oreTier2 = -1;
        WorldGen.oreTier3 = -1;
      }
      else
      {
        WorldGen.oreTier1 = 107;
        WorldGen.oreTier2 = 108;
        WorldGen.oreTier3 = 111;
      }
      int style1 = 0;
      int style2 = 0;
      int style3 = 0;
      int style4 = 0;
      int style5 = 0;
      int style6 = 0;
      int style7 = 0;
      int style8 = 0;
      if (versionNumber >= 55)
      {
        style1 = (int) fileIO.ReadByte();
        style2 = (int) fileIO.ReadByte();
        style3 = (int) fileIO.ReadByte();
      }
      if (versionNumber >= 60)
      {
        style4 = (int) fileIO.ReadByte();
        style5 = (int) fileIO.ReadByte();
        style6 = (int) fileIO.ReadByte();
        style7 = (int) fileIO.ReadByte();
        style8 = (int) fileIO.ReadByte();
      }
      WorldGen.setBG(0, style1);
      WorldGen.setBG(1, style2);
      WorldGen.setBG(2, style3);
      WorldGen.setBG(3, style4);
      WorldGen.setBG(4, style5);
      WorldGen.setBG(5, style6);
      WorldGen.setBG(6, style7);
      WorldGen.setBG(7, style8);
      if (versionNumber >= 60)
      {
        Main.cloudBGActive = (float) fileIO.ReadInt32();
        Main.cloudBGAlpha = (double) Main.cloudBGActive < 1.0 ? 0.0f : 1f;
      }
      else
        Main.cloudBGActive = (float) -WorldGen.genRand.Next(8640, 86400);
      if (versionNumber >= 62)
      {
        Main.numClouds = (int) fileIO.ReadInt16();
        Main.windSpeedSet = fileIO.ReadSingle();
        Main.windSpeed = Main.windSpeedSet;
      }
      else
        WorldGen.RandomizeWeather();
      for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
      {
        float num1 = (float) index1 / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[51].Value + " " + (object) (int) ((double) num1 * 100.0 + 1.0) + "%";
        for (int index2 = 0; index2 < Main.maxTilesY; ++index2)
        {
          Tile tile = Main.tile[index1, index2];
          int index3 = -1;
          tile.active(fileIO.ReadBoolean());
          if (tile.active())
          {
            index3 = versionNumber <= 77 ? (int) fileIO.ReadByte() : (int) fileIO.ReadUInt16();
            tile.type = (ushort) index3;
            if (tile.type == (ushort) sbyte.MaxValue)
              tile.active(false);
            if (versionNumber < 72 && (tile.type == (ushort) 35 || tile.type == (ushort) 36 || tile.type == (ushort) 170 || tile.type == (ushort) 171 || tile.type == (ushort) 172))
            {
              tile.frameX = fileIO.ReadInt16();
              tile.frameY = fileIO.ReadInt16();
            }
            else if (Main.tileFrameImportant[index3])
            {
              if (versionNumber < 28 && index3 == 4)
              {
                tile.frameX = (short) 0;
                tile.frameY = (short) 0;
              }
              else if (versionNumber < 40 && tile.type == (ushort) 19)
              {
                tile.frameX = (short) 0;
                tile.frameY = (short) 0;
              }
              else
              {
                tile.frameX = fileIO.ReadInt16();
                tile.frameY = fileIO.ReadInt16();
                if (tile.type == (ushort) 144)
                  tile.frameY = (short) 0;
              }
            }
            else
            {
              tile.frameX = (short) -1;
              tile.frameY = (short) -1;
            }
            if (versionNumber >= 48 && fileIO.ReadBoolean())
              tile.color(fileIO.ReadByte());
          }
          if (versionNumber <= 25)
            fileIO.ReadBoolean();
          if (fileIO.ReadBoolean())
          {
            tile.wall = fileIO.ReadByte();
            if (versionNumber >= 48 && fileIO.ReadBoolean())
              tile.wallColor(fileIO.ReadByte());
          }
          if (fileIO.ReadBoolean())
          {
            tile.liquid = fileIO.ReadByte();
            tile.lava(fileIO.ReadBoolean());
            if (versionNumber >= 51)
              tile.honey(fileIO.ReadBoolean());
          }
          if (versionNumber >= 33)
            tile.wire(fileIO.ReadBoolean());
          if (versionNumber >= 43)
          {
            tile.wire2(fileIO.ReadBoolean());
            tile.wire3(fileIO.ReadBoolean());
          }
          if (versionNumber >= 41)
          {
            tile.halfBrick(fileIO.ReadBoolean());
            if (!Main.tileSolid[(int) tile.type])
              tile.halfBrick(false);
            if (versionNumber >= 49)
            {
              tile.slope(fileIO.ReadByte());
              if (!Main.tileSolid[(int) tile.type])
                tile.slope((byte) 0);
            }
          }
          if (versionNumber >= 42)
          {
            tile.actuator(fileIO.ReadBoolean());
            tile.inActive(fileIO.ReadBoolean());
          }
          int num2 = 0;
          if (versionNumber >= 25)
            num2 = (int) fileIO.ReadInt16();
          if (index3 != -1)
          {
            if ((double) index2 <= Main.worldSurface)
            {
              if ((double) (index2 + num2) <= Main.worldSurface)
              {
                WorldGen.tileCounts[index3] += (num2 + 1) * 5;
              }
              else
              {
                int num3 = (int) (Main.worldSurface - (double) index2 + 1.0);
                int num4 = num2 + 1 - num3;
                WorldGen.tileCounts[index3] += num3 * 5 + num4;
              }
            }
            else
              WorldGen.tileCounts[index3] += num2 + 1;
          }
          if (num2 > 0)
          {
            for (int index4 = index2 + 1; index4 < index2 + num2 + 1; ++index4)
              Main.tile[index1, index4].CopyFrom(Main.tile[index1, index2]);
            index2 += num2;
          }
        }
      }
      WorldGen.AddUpAlignmentCounts(true);
      if (versionNumber < 67)
        WorldGen.FixSunflowers();
      if (versionNumber < 72)
        WorldGen.FixChands();
      int num5 = 40;
      if (versionNumber < 58)
        num5 = 20;
      for (int index5 = 0; index5 < 1000; ++index5)
      {
        if (fileIO.ReadBoolean())
        {
          Main.chest[index5] = new Chest();
          Main.chest[index5].x = fileIO.ReadInt32();
          Main.chest[index5].y = fileIO.ReadInt32();
          if (versionNumber >= 85)
          {
            string str = fileIO.ReadString();
            if (str.Length > 20)
              str = str.Substring(0, 20);
            Main.chest[index5].name = str;
          }
          for (int index6 = 0; index6 < 40; ++index6)
          {
            Main.chest[index5].item[index6] = new Item();
            if (index6 < num5)
            {
              int num6 = versionNumber < 59 ? (int) fileIO.ReadByte() : (int) fileIO.ReadInt16();
              if (num6 > 0)
              {
                if (versionNumber >= 38)
                {
                  Main.chest[index5].item[index6].netDefaults(fileIO.ReadInt32());
                }
                else
                {
                  short num7 = ItemID.FromLegacyName(fileIO.ReadString(), versionNumber);
                  Main.chest[index5].item[index6].SetDefaults((int) num7);
                }
                Main.chest[index5].item[index6].stack = num6;
                if (versionNumber >= 36)
                  Main.chest[index5].item[index6].Prefix((int) fileIO.ReadByte());
              }
            }
          }
        }
      }
      for (int index7 = 0; index7 < 1000; ++index7)
      {
        if (fileIO.ReadBoolean())
        {
          string str = fileIO.ReadString();
          int index8 = fileIO.ReadInt32();
          int index9 = fileIO.ReadInt32();
          if (Main.tile[index8, index9].active() && (Main.tile[index8, index9].type == (ushort) 55 || Main.tile[index8, index9].type == (ushort) 85))
          {
            Main.sign[index7] = new Sign();
            Main.sign[index7].x = index8;
            Main.sign[index7].y = index9;
            Main.sign[index7].text = str;
          }
        }
      }
      bool flag = fileIO.ReadBoolean();
      int index = 0;
      while (flag)
      {
        if (versionNumber >= 190)
          Main.npc[index].SetDefaults(fileIO.ReadInt32());
        else
          Main.npc[index].SetDefaults(NPCID.FromLegacyName(fileIO.ReadString()));
        if (versionNumber >= 83)
          Main.npc[index].GivenName = fileIO.ReadString();
        Main.npc[index].position.X = fileIO.ReadSingle();
        Main.npc[index].position.Y = fileIO.ReadSingle();
        Main.npc[index].homeless = fileIO.ReadBoolean();
        Main.npc[index].homeTileX = fileIO.ReadInt32();
        Main.npc[index].homeTileY = fileIO.ReadInt32();
        flag = fileIO.ReadBoolean();
        ++index;
      }
      if (versionNumber >= 31 && versionNumber <= 83)
      {
        NPC.setNPCName(fileIO.ReadString(), 17, true);
        NPC.setNPCName(fileIO.ReadString(), 18, true);
        NPC.setNPCName(fileIO.ReadString(), 19, true);
        NPC.setNPCName(fileIO.ReadString(), 20, true);
        NPC.setNPCName(fileIO.ReadString(), 22, true);
        NPC.setNPCName(fileIO.ReadString(), 54, true);
        NPC.setNPCName(fileIO.ReadString(), 38, true);
        NPC.setNPCName(fileIO.ReadString(), 107, true);
        NPC.setNPCName(fileIO.ReadString(), 108, true);
        if (versionNumber >= 35)
        {
          NPC.setNPCName(fileIO.ReadString(), 124, true);
          if (versionNumber >= 65)
          {
            NPC.setNPCName(fileIO.ReadString(), 160, true);
            NPC.setNPCName(fileIO.ReadString(), 178, true);
            NPC.setNPCName(fileIO.ReadString(), 207, true);
            NPC.setNPCName(fileIO.ReadString(), 208, true);
            NPC.setNPCName(fileIO.ReadString(), 209, true);
            NPC.setNPCName(fileIO.ReadString(), 227, true);
            NPC.setNPCName(fileIO.ReadString(), 228, true);
            NPC.setNPCName(fileIO.ReadString(), 229, true);
            if (versionNumber >= 79)
              NPC.setNPCName(fileIO.ReadString(), 353, true);
          }
        }
      }
      if (Main.invasionType > 0 && Main.invasionSize > 0)
        Main.FakeLoadInvasionStart();
      if (versionNumber < 7)
        return 0;
      int num8 = fileIO.ReadBoolean() ? 1 : 0;
      string str1 = fileIO.ReadString();
      int num9 = fileIO.ReadInt32();
      return num8 != 0 && (str1 == Main.worldName || num9 == Main.worldID) ? 0 : 2;
    }

    public static void SaveWorld_Version2(BinaryWriter writer)
    {
      int[] pointers = new int[10]
      {
        WorldFile.SaveFileFormatHeader(writer),
        WorldFile.SaveWorldHeader(writer),
        WorldFile.SaveWorldTiles(writer),
        WorldFile.SaveChests(writer),
        WorldFile.SaveSigns(writer),
        WorldFile.SaveNPCs(writer),
        WorldFile.SaveTileEntities(writer),
        WorldFile.SaveWeightedPressurePlates(writer),
        WorldFile.SaveTownManager(writer),
        0
      };
      WorldFile.SaveFooter(writer);
      WorldFile.SaveHeaderPointers(writer, pointers);
    }

    private static int SaveFileFormatHeader(BinaryWriter writer)
    {
      short num1 = 470;
      short num2 = 10;
      writer.Write(194);
      Main.WorldFileMetadata.IncrementAndWrite(writer);
      writer.Write(num2);
      for (int index = 0; index < (int) num2; ++index)
        writer.Write(0);
      writer.Write(num1);
      byte num3 = 0;
      byte num4 = 1;
      for (int index = 0; index < (int) num1; ++index)
      {
        if (Main.tileFrameImportant[index])
          num3 |= num4;
        if (num4 == (byte) 128)
        {
          writer.Write(num3);
          num3 = (byte) 0;
          num4 = (byte) 1;
        }
        else
          num4 <<= 1;
      }
      if (num4 != (byte) 1)
        writer.Write(num3);
      return (int) writer.BaseStream.Position;
    }

    private static int SaveHeaderPointers(BinaryWriter writer, int[] pointers)
    {
      writer.BaseStream.Position = 0L;
      writer.Write(194);
      writer.BaseStream.Position += 20L;
      writer.Write((short) pointers.Length);
      for (int index = 0; index < pointers.Length; ++index)
        writer.Write(pointers[index]);
      return (int) writer.BaseStream.Position;
    }

    private static int SaveWorldHeader(BinaryWriter writer)
    {
      writer.Write(Main.worldName);
      writer.Write(Main.ActiveWorldFileData.SeedText);
      writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
      writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
      writer.Write(Main.worldID);
      writer.Write((int) Main.leftWorld);
      writer.Write((int) Main.rightWorld);
      writer.Write((int) Main.topWorld);
      writer.Write((int) Main.bottomWorld);
      writer.Write(Main.maxTilesY);
      writer.Write(Main.maxTilesX);
      writer.Write(Main.expertMode);
      writer.Write(Main.ActiveWorldFileData.CreationTime.ToBinary());
      writer.Write((byte) Main.moonType);
      writer.Write(Main.treeX[0]);
      writer.Write(Main.treeX[1]);
      writer.Write(Main.treeX[2]);
      writer.Write(Main.treeStyle[0]);
      writer.Write(Main.treeStyle[1]);
      writer.Write(Main.treeStyle[2]);
      writer.Write(Main.treeStyle[3]);
      writer.Write(Main.caveBackX[0]);
      writer.Write(Main.caveBackX[1]);
      writer.Write(Main.caveBackX[2]);
      writer.Write(Main.caveBackStyle[0]);
      writer.Write(Main.caveBackStyle[1]);
      writer.Write(Main.caveBackStyle[2]);
      writer.Write(Main.caveBackStyle[3]);
      writer.Write(Main.iceBackStyle);
      writer.Write(Main.jungleBackStyle);
      writer.Write(Main.hellBackStyle);
      writer.Write(Main.spawnTileX);
      writer.Write(Main.spawnTileY);
      writer.Write(Main.worldSurface);
      writer.Write(Main.rockLayer);
      writer.Write(WorldFile.tempTime);
      writer.Write(WorldFile.tempDayTime);
      writer.Write(WorldFile.tempMoonPhase);
      writer.Write(WorldFile.tempBloodMoon);
      writer.Write(WorldFile.tempEclipse);
      writer.Write(Main.dungeonX);
      writer.Write(Main.dungeonY);
      writer.Write(WorldGen.crimson);
      writer.Write(NPC.downedBoss1);
      writer.Write(NPC.downedBoss2);
      writer.Write(NPC.downedBoss3);
      writer.Write(NPC.downedQueenBee);
      writer.Write(NPC.downedMechBoss1);
      writer.Write(NPC.downedMechBoss2);
      writer.Write(NPC.downedMechBoss3);
      writer.Write(NPC.downedMechBossAny);
      writer.Write(NPC.downedPlantBoss);
      writer.Write(NPC.downedGolemBoss);
      writer.Write(NPC.downedSlimeKing);
      writer.Write(NPC.savedGoblin);
      writer.Write(NPC.savedWizard);
      writer.Write(NPC.savedMech);
      writer.Write(NPC.downedGoblins);
      writer.Write(NPC.downedClown);
      writer.Write(NPC.downedFrost);
      writer.Write(NPC.downedPirates);
      writer.Write(WorldGen.shadowOrbSmashed);
      writer.Write(WorldGen.spawnMeteor);
      writer.Write((byte) WorldGen.shadowOrbCount);
      writer.Write(WorldGen.altarCount);
      writer.Write(Main.hardMode);
      writer.Write(Main.invasionDelay);
      writer.Write(Main.invasionSize);
      writer.Write(Main.invasionType);
      writer.Write(Main.invasionX);
      writer.Write(Main.slimeRainTime);
      writer.Write((byte) Main.sundialCooldown);
      writer.Write(WorldFile.tempRaining);
      writer.Write(WorldFile.tempRainTime);
      writer.Write(WorldFile.tempMaxRain);
      writer.Write(WorldGen.oreTier1);
      writer.Write(WorldGen.oreTier2);
      writer.Write(WorldGen.oreTier3);
      writer.Write((byte) WorldGen.treeBG);
      writer.Write((byte) WorldGen.corruptBG);
      writer.Write((byte) WorldGen.jungleBG);
      writer.Write((byte) WorldGen.snowBG);
      writer.Write((byte) WorldGen.hallowBG);
      writer.Write((byte) WorldGen.crimsonBG);
      writer.Write((byte) WorldGen.desertBG);
      writer.Write((byte) WorldGen.oceanBG);
      writer.Write((int) Main.cloudBGActive);
      writer.Write((short) Main.numClouds);
      writer.Write(Main.windSpeedSet);
      writer.Write(Main.anglerWhoFinishedToday.Count);
      for (int index = 0; index < Main.anglerWhoFinishedToday.Count; ++index)
        writer.Write(Main.anglerWhoFinishedToday[index]);
      writer.Write(NPC.savedAngler);
      writer.Write(Main.anglerQuest);
      writer.Write(NPC.savedStylist);
      writer.Write(NPC.savedTaxCollector);
      writer.Write(Main.invasionSizeStart);
      writer.Write(WorldFile.tempCultistDelay);
      writer.Write((short) 580);
      for (int index = 0; index < 580; ++index)
        writer.Write(NPC.killCount[index]);
      writer.Write(Main.fastForwardTime);
      writer.Write(NPC.downedFishron);
      writer.Write(NPC.downedMartians);
      writer.Write(NPC.downedAncientCultist);
      writer.Write(NPC.downedMoonlord);
      writer.Write(NPC.downedHalloweenKing);
      writer.Write(NPC.downedHalloweenTree);
      writer.Write(NPC.downedChristmasIceQueen);
      writer.Write(NPC.downedChristmasSantank);
      writer.Write(NPC.downedChristmasTree);
      writer.Write(NPC.downedTowerSolar);
      writer.Write(NPC.downedTowerVortex);
      writer.Write(NPC.downedTowerNebula);
      writer.Write(NPC.downedTowerStardust);
      writer.Write(NPC.TowerActiveSolar);
      writer.Write(NPC.TowerActiveVortex);
      writer.Write(NPC.TowerActiveNebula);
      writer.Write(NPC.TowerActiveStardust);
      writer.Write(NPC.LunarApocalypseIsUp);
      writer.Write(WorldFile.tempPartyManual);
      writer.Write(WorldFile.tempPartyGenuine);
      writer.Write(WorldFile.tempPartyCooldown);
      writer.Write(WorldFile.tempPartyCelebratingNPCs.Count);
      for (int index = 0; index < WorldFile.tempPartyCelebratingNPCs.Count; ++index)
        writer.Write(WorldFile.tempPartyCelebratingNPCs[index]);
      writer.Write(WorldFile.Temp_Sandstorm_Happening);
      writer.Write(WorldFile.Temp_Sandstorm_TimeLeft);
      writer.Write(WorldFile.Temp_Sandstorm_Severity);
      writer.Write(WorldFile.Temp_Sandstorm_IntendedSeverity);
      writer.Write(NPC.savedBartender);
      DD2Event.Save(writer);
      return (int) writer.BaseStream.Position;
    }

    private static int SaveWorldTiles(BinaryWriter writer)
    {
      byte[] buffer = new byte[13];
      for (int i = 0; i < Main.maxTilesX; ++i)
      {
        float num1 = (float) i / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[49].Value + " " + (object) (int) ((double) num1 * 100.0 + 1.0) + "%";
        int num2;
        for (int j = 0; j < Main.maxTilesY; j = num2 + 1)
        {
          Tile tile = Main.tile[i, j];
          int index1 = 3;
          int num3;
          byte num4 = (byte) (num3 = 0);
          byte num5 = (byte) num3;
          byte num6 = (byte) num3;
          bool flag = false;
          if (tile.active())
          {
            flag = true;
            if (tile.type == (ushort) sbyte.MaxValue)
            {
              WorldGen.KillTile(i, j);
              if (!tile.active())
              {
                flag = false;
                if (Main.netMode != 0)
                  NetMessage.SendData(17, number2: ((float) i), number3: ((float) j));
              }
            }
          }
          if (flag)
          {
            num6 |= (byte) 2;
            if (tile.type == (ushort) sbyte.MaxValue)
            {
              WorldGen.KillTile(i, j);
              if (!tile.active() && Main.netMode != 0)
                NetMessage.SendData(17, number2: ((float) i), number3: ((float) j));
            }
            buffer[index1] = (byte) tile.type;
            ++index1;
            if (tile.type > (ushort) byte.MaxValue)
            {
              buffer[index1] = (byte) ((uint) tile.type >> 8);
              ++index1;
              num6 |= (byte) 32;
            }
            if (Main.tileFrameImportant[(int) tile.type])
            {
              buffer[index1] = (byte) ((uint) tile.frameX & (uint) byte.MaxValue);
              int index2 = index1 + 1;
              buffer[index2] = (byte) (((int) tile.frameX & 65280) >> 8);
              int index3 = index2 + 1;
              buffer[index3] = (byte) ((uint) tile.frameY & (uint) byte.MaxValue);
              int index4 = index3 + 1;
              buffer[index4] = (byte) (((int) tile.frameY & 65280) >> 8);
              index1 = index4 + 1;
            }
            if (tile.color() != (byte) 0)
            {
              num4 |= (byte) 8;
              buffer[index1] = tile.color();
              ++index1;
            }
          }
          if (tile.wall != (byte) 0)
          {
            num6 |= (byte) 4;
            buffer[index1] = tile.wall;
            ++index1;
            if (tile.wallColor() != (byte) 0)
            {
              num4 |= (byte) 16;
              buffer[index1] = tile.wallColor();
              ++index1;
            }
          }
          if (tile.liquid != (byte) 0)
          {
            if (tile.lava())
              num6 |= (byte) 16;
            else if (tile.honey())
              num6 |= (byte) 24;
            else
              num6 |= (byte) 8;
            buffer[index1] = tile.liquid;
            ++index1;
          }
          if (tile.wire())
            num5 |= (byte) 2;
          if (tile.wire2())
            num5 |= (byte) 4;
          if (tile.wire3())
            num5 |= (byte) 8;
          int num7 = !tile.halfBrick() ? (tile.slope() == (byte) 0 ? 0 : (int) tile.slope() + 1 << 4) : 16;
          byte num8 = (byte) ((uint) num5 | (uint) (byte) num7);
          if (tile.actuator())
            num4 |= (byte) 2;
          if (tile.inActive())
            num4 |= (byte) 4;
          if (tile.wire4())
            num4 |= (byte) 32;
          int index5 = 2;
          if (num4 != (byte) 0)
          {
            num8 |= (byte) 1;
            buffer[index5] = num4;
            --index5;
          }
          if (num8 != (byte) 0)
          {
            num6 |= (byte) 1;
            buffer[index5] = num8;
            --index5;
          }
          short num9 = 0;
          int index6 = j + 1;
          for (int index7 = Main.maxTilesY - j - 1; index7 > 0 && tile.isTheSameAs(Main.tile[i, index6]); ++index6)
          {
            ++num9;
            --index7;
          }
          num2 = j + (int) num9;
          if (num9 > (short) 0)
          {
            buffer[index1] = (byte) ((uint) num9 & (uint) byte.MaxValue);
            ++index1;
            if (num9 > (short) byte.MaxValue)
            {
              num6 |= (byte) 128;
              buffer[index1] = (byte) (((int) num9 & 65280) >> 8);
              ++index1;
            }
            else
              num6 |= (byte) 64;
          }
          buffer[index5] = num6;
          writer.Write(buffer, index5, index1 - index5);
        }
      }
      return (int) writer.BaseStream.Position;
    }

    private static int SaveChests(BinaryWriter writer)
    {
      short num = 0;
      for (int index = 0; index < 1000; ++index)
      {
        Chest chest = Main.chest[index];
        if (chest != null)
        {
          bool flag = false;
          for (int x = chest.x; x <= chest.x + 1; ++x)
          {
            for (int y = chest.y; y <= chest.y + 1; ++y)
            {
              if (x < 0 || y < 0 || x >= Main.maxTilesX || y >= Main.maxTilesY)
              {
                flag = true;
                break;
              }
              Tile tile = Main.tile[x, y];
              if (!tile.active() || !Main.tileContainer[(int) tile.type])
              {
                flag = true;
                break;
              }
            }
          }
          if (flag)
            Main.chest[index] = (Chest) null;
          else
            ++num;
        }
      }
      writer.Write(num);
      writer.Write((short) 40);
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        Chest chest = Main.chest[index1];
        if (chest != null)
        {
          writer.Write(chest.x);
          writer.Write(chest.y);
          writer.Write(chest.name);
          for (int index2 = 0; index2 < 40; ++index2)
          {
            Item obj = chest.item[index2];
            if (obj == null)
            {
              writer.Write((short) 0);
            }
            else
            {
              if (obj.stack > obj.maxStack)
                obj.stack = obj.maxStack;
              if (obj.stack < 0)
                obj.stack = 1;
              writer.Write((short) obj.stack);
              if (obj.stack > 0)
              {
                writer.Write(obj.netID);
                writer.Write(obj.prefix);
              }
            }
          }
        }
      }
      return (int) writer.BaseStream.Position;
    }

    private static int SaveSigns(BinaryWriter writer)
    {
      short num = 0;
      for (int index = 0; index < 1000; ++index)
      {
        Sign sign = Main.sign[index];
        if (sign != null && sign.text != null)
          ++num;
      }
      writer.Write(num);
      for (int index = 0; index < 1000; ++index)
      {
        Sign sign = Main.sign[index];
        if (sign != null && sign.text != null)
        {
          writer.Write(sign.text);
          writer.Write(sign.x);
          writer.Write(sign.y);
        }
      }
      return (int) writer.BaseStream.Position;
    }

    private static int SaveDummies(BinaryWriter writer)
    {
      int num = 0;
      for (int index = 0; index < 1000; ++index)
      {
        if (DeprecatedClassLeftInForLoading.dummies[index] != null)
          ++num;
      }
      writer.Write(num);
      for (int index = 0; index < 1000; ++index)
      {
        DeprecatedClassLeftInForLoading dummy = DeprecatedClassLeftInForLoading.dummies[index];
        if (dummy != null)
        {
          writer.Write(dummy.x);
          writer.Write(dummy.y);
        }
      }
      return (int) writer.BaseStream.Position;
    }

    private static int SaveNPCs(BinaryWriter writer)
    {
      for (int index = 0; index < Main.npc.Length; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && npc.townNPC && npc.type != 368)
        {
          writer.Write(npc.active);
          writer.Write(npc.netID);
          writer.Write(npc.GivenName);
          writer.Write(npc.position.X);
          writer.Write(npc.position.Y);
          writer.Write(npc.homeless);
          writer.Write(npc.homeTileX);
          writer.Write(npc.homeTileY);
        }
      }
      writer.Write(false);
      for (int index = 0; index < Main.npc.Length; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && NPCID.Sets.SavesAndLoads[npc.type])
        {
          writer.Write(npc.active);
          writer.Write(npc.netID);
          writer.WriteVector2(npc.position);
        }
      }
      writer.Write(false);
      return (int) writer.BaseStream.Position;
    }

    private static int SaveFooter(BinaryWriter writer)
    {
      writer.Write(true);
      writer.Write(Main.worldName);
      writer.Write(Main.worldID);
      return (int) writer.BaseStream.Position;
    }

    public static int LoadWorld_Version2(BinaryReader reader)
    {
      reader.BaseStream.Position = 0L;
      bool[] importance;
      int[] positions;
      if (!WorldFile.LoadFileFormatHeader(reader, out importance, out positions) || reader.BaseStream.Position != (long) positions[0])
        return 5;
      WorldFile.LoadHeader(reader);
      if (reader.BaseStream.Position != (long) positions[1])
        return 5;
      WorldFile.LoadWorldTiles(reader, importance);
      if (reader.BaseStream.Position != (long) positions[2])
        return 5;
      WorldFile.LoadChests(reader);
      if (reader.BaseStream.Position != (long) positions[3])
        return 5;
      WorldFile.LoadSigns(reader);
      if (reader.BaseStream.Position != (long) positions[4])
        return 5;
      WorldFile.LoadNPCs(reader);
      if (reader.BaseStream.Position != (long) positions[5])
        return 5;
      if (WorldFile.versionNumber >= 116)
      {
        if (WorldFile.versionNumber < 122)
        {
          WorldFile.LoadDummies(reader);
          if (reader.BaseStream.Position != (long) positions[6])
            return 5;
        }
        else
        {
          WorldFile.LoadTileEntities(reader);
          if (reader.BaseStream.Position != (long) positions[6])
            return 5;
        }
      }
      if (WorldFile.versionNumber >= 170)
      {
        WorldFile.LoadWeightedPressurePlates(reader);
        if (reader.BaseStream.Position != (long) positions[7])
          return 5;
      }
      if (WorldFile.versionNumber >= 189)
      {
        WorldFile.LoadTownManager(reader);
        if (reader.BaseStream.Position != (long) positions[8])
          return 5;
      }
      return WorldFile.LoadFooter(reader);
    }

    private static bool LoadFileFormatHeader(
      BinaryReader reader,
      out bool[] importance,
      out int[] positions)
    {
      importance = (bool[]) null;
      positions = (int[]) null;
      if ((WorldFile.versionNumber = reader.ReadInt32()) >= 135)
      {
        try
        {
          Main.WorldFileMetadata = FileMetadata.Read(reader, FileType.World);
        }
        catch (FileFormatException ex)
        {
          Console.WriteLine(Language.GetTextValue("Error.UnableToLoadWorld"));
          Console.WriteLine((object) ex);
          return false;
        }
      }
      else
        Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
      short num1 = reader.ReadInt16();
      positions = new int[(int) num1];
      for (int index = 0; index < (int) num1; ++index)
        positions[index] = reader.ReadInt32();
      short num2 = reader.ReadInt16();
      importance = new bool[(int) num2];
      byte num3 = 0;
      byte num4 = 128;
      for (int index = 0; index < (int) num2; ++index)
      {
        if (num4 == (byte) 128)
        {
          num3 = reader.ReadByte();
          num4 = (byte) 1;
        }
        else
          num4 <<= 1;
        if (((int) num3 & (int) num4) == (int) num4)
          importance[index] = true;
      }
      return true;
    }

    private static void LoadHeader(BinaryReader reader)
    {
      int versionNumber = WorldFile.versionNumber;
      Main.worldName = reader.ReadString();
      if (versionNumber >= 179)
      {
        string seedText = versionNumber != 179 ? reader.ReadString() : reader.ReadInt32().ToString();
        Main.ActiveWorldFileData.SetSeed(seedText);
        Main.ActiveWorldFileData.WorldGeneratorVersion = reader.ReadUInt64();
      }
      Main.ActiveWorldFileData.UniqueId = versionNumber < 181 ? Guid.NewGuid() : new Guid(reader.ReadBytes(16));
      Main.worldID = reader.ReadInt32();
      Main.leftWorld = (float) reader.ReadInt32();
      Main.rightWorld = (float) reader.ReadInt32();
      Main.topWorld = (float) reader.ReadInt32();
      Main.bottomWorld = (float) reader.ReadInt32();
      Main.maxTilesY = reader.ReadInt32();
      Main.maxTilesX = reader.ReadInt32();
      WorldGen.clearWorld();
      Main.expertMode = versionNumber >= 112 && reader.ReadBoolean();
      if (versionNumber >= 141)
        Main.ActiveWorldFileData.CreationTime = DateTime.FromBinary(reader.ReadInt64());
      Main.moonType = (int) reader.ReadByte();
      Main.treeX[0] = reader.ReadInt32();
      Main.treeX[1] = reader.ReadInt32();
      Main.treeX[2] = reader.ReadInt32();
      Main.treeStyle[0] = reader.ReadInt32();
      Main.treeStyle[1] = reader.ReadInt32();
      Main.treeStyle[2] = reader.ReadInt32();
      Main.treeStyle[3] = reader.ReadInt32();
      Main.caveBackX[0] = reader.ReadInt32();
      Main.caveBackX[1] = reader.ReadInt32();
      Main.caveBackX[2] = reader.ReadInt32();
      Main.caveBackStyle[0] = reader.ReadInt32();
      Main.caveBackStyle[1] = reader.ReadInt32();
      Main.caveBackStyle[2] = reader.ReadInt32();
      Main.caveBackStyle[3] = reader.ReadInt32();
      Main.iceBackStyle = reader.ReadInt32();
      Main.jungleBackStyle = reader.ReadInt32();
      Main.hellBackStyle = reader.ReadInt32();
      Main.spawnTileX = reader.ReadInt32();
      Main.spawnTileY = reader.ReadInt32();
      Main.worldSurface = reader.ReadDouble();
      Main.rockLayer = reader.ReadDouble();
      WorldFile.tempTime = reader.ReadDouble();
      WorldFile.tempDayTime = reader.ReadBoolean();
      WorldFile.tempMoonPhase = reader.ReadInt32();
      WorldFile.tempBloodMoon = reader.ReadBoolean();
      WorldFile.tempEclipse = reader.ReadBoolean();
      Main.eclipse = WorldFile.tempEclipse;
      Main.dungeonX = reader.ReadInt32();
      Main.dungeonY = reader.ReadInt32();
      WorldGen.crimson = reader.ReadBoolean();
      NPC.downedBoss1 = reader.ReadBoolean();
      NPC.downedBoss2 = reader.ReadBoolean();
      NPC.downedBoss3 = reader.ReadBoolean();
      NPC.downedQueenBee = reader.ReadBoolean();
      NPC.downedMechBoss1 = reader.ReadBoolean();
      NPC.downedMechBoss2 = reader.ReadBoolean();
      NPC.downedMechBoss3 = reader.ReadBoolean();
      NPC.downedMechBossAny = reader.ReadBoolean();
      NPC.downedPlantBoss = reader.ReadBoolean();
      NPC.downedGolemBoss = reader.ReadBoolean();
      if (versionNumber >= 118)
        NPC.downedSlimeKing = reader.ReadBoolean();
      NPC.savedGoblin = reader.ReadBoolean();
      NPC.savedWizard = reader.ReadBoolean();
      NPC.savedMech = reader.ReadBoolean();
      NPC.downedGoblins = reader.ReadBoolean();
      NPC.downedClown = reader.ReadBoolean();
      NPC.downedFrost = reader.ReadBoolean();
      NPC.downedPirates = reader.ReadBoolean();
      WorldGen.shadowOrbSmashed = reader.ReadBoolean();
      WorldGen.spawnMeteor = reader.ReadBoolean();
      WorldGen.shadowOrbCount = (int) reader.ReadByte();
      WorldGen.altarCount = reader.ReadInt32();
      Main.hardMode = reader.ReadBoolean();
      Main.invasionDelay = reader.ReadInt32();
      Main.invasionSize = reader.ReadInt32();
      Main.invasionType = reader.ReadInt32();
      Main.invasionX = reader.ReadDouble();
      if (versionNumber >= 118)
        Main.slimeRainTime = reader.ReadDouble();
      if (versionNumber >= 113)
        Main.sundialCooldown = (int) reader.ReadByte();
      WorldFile.tempRaining = reader.ReadBoolean();
      WorldFile.tempRainTime = reader.ReadInt32();
      WorldFile.tempMaxRain = reader.ReadSingle();
      WorldGen.oreTier1 = reader.ReadInt32();
      WorldGen.oreTier2 = reader.ReadInt32();
      WorldGen.oreTier3 = reader.ReadInt32();
      WorldGen.setBG(0, (int) reader.ReadByte());
      WorldGen.setBG(1, (int) reader.ReadByte());
      WorldGen.setBG(2, (int) reader.ReadByte());
      WorldGen.setBG(3, (int) reader.ReadByte());
      WorldGen.setBG(4, (int) reader.ReadByte());
      WorldGen.setBG(5, (int) reader.ReadByte());
      WorldGen.setBG(6, (int) reader.ReadByte());
      WorldGen.setBG(7, (int) reader.ReadByte());
      Main.cloudBGActive = (float) reader.ReadInt32();
      Main.cloudBGAlpha = (double) Main.cloudBGActive < 1.0 ? 0.0f : 1f;
      Main.cloudBGActive = (float) -WorldGen.genRand.Next(8640, 86400);
      Main.numClouds = (int) reader.ReadInt16();
      Main.windSpeedSet = reader.ReadSingle();
      Main.windSpeed = Main.windSpeedSet;
      if (versionNumber < 95)
        return;
      Main.anglerWhoFinishedToday.Clear();
      for (int index = reader.ReadInt32(); index > 0; --index)
        Main.anglerWhoFinishedToday.Add(reader.ReadString());
      if (versionNumber < 99)
        return;
      NPC.savedAngler = reader.ReadBoolean();
      if (versionNumber < 101)
        return;
      Main.anglerQuest = reader.ReadInt32();
      if (versionNumber < 104)
        return;
      NPC.savedStylist = reader.ReadBoolean();
      if (versionNumber >= 129)
        NPC.savedTaxCollector = reader.ReadBoolean();
      if (versionNumber < 107)
      {
        if (Main.invasionType > 0 && Main.invasionSize > 0)
          Main.FakeLoadInvasionStart();
      }
      else
        Main.invasionSizeStart = reader.ReadInt32();
      WorldFile.tempCultistDelay = versionNumber >= 108 ? reader.ReadInt32() : 86400;
      if (versionNumber < 109)
        return;
      int num1 = (int) reader.ReadInt16();
      for (int index = 0; index < num1; ++index)
      {
        if (index < 580)
          NPC.killCount[index] = reader.ReadInt32();
        else
          reader.ReadInt32();
      }
      if (versionNumber < 128)
        return;
      Main.fastForwardTime = reader.ReadBoolean();
      Main.UpdateSundial();
      if (versionNumber < 131)
        return;
      NPC.downedFishron = reader.ReadBoolean();
      NPC.downedMartians = reader.ReadBoolean();
      NPC.downedAncientCultist = reader.ReadBoolean();
      NPC.downedMoonlord = reader.ReadBoolean();
      NPC.downedHalloweenKing = reader.ReadBoolean();
      NPC.downedHalloweenTree = reader.ReadBoolean();
      NPC.downedChristmasIceQueen = reader.ReadBoolean();
      NPC.downedChristmasSantank = reader.ReadBoolean();
      NPC.downedChristmasTree = reader.ReadBoolean();
      if (versionNumber < 140)
        return;
      NPC.downedTowerSolar = reader.ReadBoolean();
      NPC.downedTowerVortex = reader.ReadBoolean();
      NPC.downedTowerNebula = reader.ReadBoolean();
      NPC.downedTowerStardust = reader.ReadBoolean();
      NPC.TowerActiveSolar = reader.ReadBoolean();
      NPC.TowerActiveVortex = reader.ReadBoolean();
      NPC.TowerActiveNebula = reader.ReadBoolean();
      NPC.TowerActiveStardust = reader.ReadBoolean();
      NPC.LunarApocalypseIsUp = reader.ReadBoolean();
      if (NPC.TowerActiveSolar)
        NPC.ShieldStrengthTowerSolar = NPC.ShieldStrengthTowerMax;
      if (NPC.TowerActiveVortex)
        NPC.ShieldStrengthTowerVortex = NPC.ShieldStrengthTowerMax;
      if (NPC.TowerActiveNebula)
        NPC.ShieldStrengthTowerNebula = NPC.ShieldStrengthTowerMax;
      if (NPC.TowerActiveStardust)
        NPC.ShieldStrengthTowerStardust = NPC.ShieldStrengthTowerMax;
      if (versionNumber < 170)
      {
        WorldFile.tempPartyManual = false;
        WorldFile.tempPartyGenuine = false;
        WorldFile.tempPartyCooldown = 0;
        WorldFile.tempPartyCelebratingNPCs.Clear();
      }
      else
      {
        WorldFile.tempPartyManual = reader.ReadBoolean();
        WorldFile.tempPartyGenuine = reader.ReadBoolean();
        WorldFile.tempPartyCooldown = reader.ReadInt32();
        int num2 = reader.ReadInt32();
        WorldFile.tempPartyCelebratingNPCs.Clear();
        for (int index = 0; index < num2; ++index)
          WorldFile.tempPartyCelebratingNPCs.Add(reader.ReadInt32());
      }
      if (versionNumber < 174)
      {
        WorldFile.Temp_Sandstorm_Happening = false;
        WorldFile.Temp_Sandstorm_TimeLeft = 0;
        WorldFile.Temp_Sandstorm_Severity = 0.0f;
        WorldFile.Temp_Sandstorm_IntendedSeverity = 0.0f;
      }
      else
      {
        WorldFile.Temp_Sandstorm_Happening = reader.ReadBoolean();
        WorldFile.Temp_Sandstorm_TimeLeft = reader.ReadInt32();
        WorldFile.Temp_Sandstorm_Severity = reader.ReadSingle();
        WorldFile.Temp_Sandstorm_IntendedSeverity = reader.ReadSingle();
      }
      DD2Event.Load(reader, versionNumber);
    }

    private static void LoadWorldTiles(BinaryReader reader, bool[] importance)
    {
      for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
      {
        float num1 = (float) index1 / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[51].Value + " " + (object) (int) ((double) num1 * 100.0 + 1.0) + "%";
        for (int index2 = 0; index2 < Main.maxTilesY; ++index2)
        {
          int index3 = -1;
          byte num2;
          byte num3 = num2 = (byte) 0;
          Tile from = Main.tile[index1, index2];
          byte num4 = reader.ReadByte();
          if (((int) num4 & 1) == 1)
          {
            num3 = reader.ReadByte();
            if (((int) num3 & 1) == 1)
              num2 = reader.ReadByte();
          }
          if (((int) num4 & 2) == 2)
          {
            from.active(true);
            if (((int) num4 & 32) == 32)
            {
              byte num5 = reader.ReadByte();
              index3 = (int) reader.ReadByte() << 8 | (int) num5;
            }
            else
              index3 = (int) reader.ReadByte();
            from.type = (ushort) index3;
            if (importance[index3])
            {
              from.frameX = reader.ReadInt16();
              from.frameY = reader.ReadInt16();
              if (from.type == (ushort) 144)
                from.frameY = (short) 0;
            }
            else
            {
              from.frameX = (short) -1;
              from.frameY = (short) -1;
            }
            if (((int) num2 & 8) == 8)
              from.color(reader.ReadByte());
          }
          if (((int) num4 & 4) == 4)
          {
            from.wall = reader.ReadByte();
            if (((int) num2 & 16) == 16)
              from.wallColor(reader.ReadByte());
          }
          byte num6 = (byte) (((int) num4 & 24) >> 3);
          if (num6 != (byte) 0)
          {
            from.liquid = reader.ReadByte();
            if (num6 > (byte) 1)
            {
              if (num6 == (byte) 2)
                from.lava(true);
              else
                from.honey(true);
            }
          }
          if (num3 > (byte) 1)
          {
            if (((int) num3 & 2) == 2)
              from.wire(true);
            if (((int) num3 & 4) == 4)
              from.wire2(true);
            if (((int) num3 & 8) == 8)
              from.wire3(true);
            byte num7 = (byte) (((int) num3 & 112) >> 4);
            if (num7 != (byte) 0 && Main.tileSolid[(int) from.type])
            {
              if (num7 == (byte) 1)
                from.halfBrick(true);
              else
                from.slope((byte) ((uint) num7 - 1U));
            }
          }
          if (num2 > (byte) 0)
          {
            if (((int) num2 & 2) == 2)
              from.actuator(true);
            if (((int) num2 & 4) == 4)
              from.inActive(true);
            if (((int) num2 & 32) == 32)
              from.wire4(true);
          }
          int num8;
          switch ((byte) (((int) num4 & 192) >> 6))
          {
            case 0:
              num8 = 0;
              break;
            case 1:
              num8 = (int) reader.ReadByte();
              break;
            default:
              num8 = (int) reader.ReadInt16();
              break;
          }
          if (index3 != -1)
          {
            if ((double) index2 <= Main.worldSurface)
            {
              if ((double) (index2 + num8) <= Main.worldSurface)
              {
                WorldGen.tileCounts[index3] += (num8 + 1) * 5;
              }
              else
              {
                int num9 = (int) (Main.worldSurface - (double) index2 + 1.0);
                int num10 = num8 + 1 - num9;
                WorldGen.tileCounts[index3] += num9 * 5 + num10;
              }
            }
            else
              WorldGen.tileCounts[index3] += num8 + 1;
          }
          for (; num8 > 0; --num8)
          {
            ++index2;
            Main.tile[index1, index2].CopyFrom(from);
          }
        }
      }
      WorldGen.AddUpAlignmentCounts(true);
      if (WorldFile.versionNumber >= 105)
        return;
      WorldGen.FixHearts();
    }

    private static void LoadChests(BinaryReader reader)
    {
      int num1 = (int) reader.ReadInt16();
      int num2 = (int) reader.ReadInt16();
      int num3;
      int num4;
      if (num2 < 40)
      {
        num3 = num2;
        num4 = 0;
      }
      else
      {
        num3 = 40;
        num4 = num2 - 40;
      }
      int index1;
      for (index1 = 0; index1 < num1; ++index1)
      {
        Chest chest = new Chest();
        chest.x = reader.ReadInt32();
        chest.y = reader.ReadInt32();
        chest.name = reader.ReadString();
        for (int index2 = 0; index2 < num3; ++index2)
        {
          short num5 = reader.ReadInt16();
          Item obj = new Item();
          if (num5 > (short) 0)
          {
            obj.netDefaults(reader.ReadInt32());
            obj.stack = (int) num5;
            obj.Prefix((int) reader.ReadByte());
          }
          else if (num5 < (short) 0)
          {
            obj.netDefaults(reader.ReadInt32());
            obj.Prefix((int) reader.ReadByte());
            obj.stack = 1;
          }
          chest.item[index2] = obj;
        }
        for (int index3 = 0; index3 < num4; ++index3)
        {
          if (reader.ReadInt16() > (short) 0)
          {
            reader.ReadInt32();
            int num6 = (int) reader.ReadByte();
          }
        }
        Main.chest[index1] = chest;
      }
      List<Point16> point16List = new List<Point16>();
      for (int index4 = 0; index4 < index1; ++index4)
      {
        if (Main.chest[index4] != null)
        {
          Point16 point16 = new Point16(Main.chest[index4].x, Main.chest[index4].y);
          if (point16List.Contains(point16))
            Main.chest[index4] = (Chest) null;
          else
            point16List.Add(point16);
        }
      }
      for (; index1 < 1000; ++index1)
        Main.chest[index1] = (Chest) null;
      if (WorldFile.versionNumber >= 115)
        return;
      WorldFile.FixDresserChests();
    }

    private static void LoadSigns(BinaryReader reader)
    {
      short num = reader.ReadInt16();
      int index1;
      for (index1 = 0; index1 < (int) num; ++index1)
      {
        string str = reader.ReadString();
        int index2 = reader.ReadInt32();
        int index3 = reader.ReadInt32();
        Tile tile = Main.tile[index2, index3];
        Sign sign;
        if (tile.active() && Main.tileSign[(int) tile.type])
        {
          sign = new Sign();
          sign.text = str;
          sign.x = index2;
          sign.y = index3;
        }
        else
          sign = (Sign) null;
        Main.sign[index1] = sign;
      }
      List<Point16> point16List = new List<Point16>();
      for (int index4 = 0; index4 < 1000; ++index4)
      {
        if (Main.sign[index4] != null)
        {
          Point16 point16 = new Point16(Main.sign[index4].x, Main.sign[index4].y);
          if (point16List.Contains(point16))
            Main.sign[index4] = (Sign) null;
          else
            point16List.Add(point16);
        }
      }
      for (; index1 < 1000; ++index1)
        Main.sign[index1] = (Sign) null;
    }

    private static void LoadDummies(BinaryReader reader)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
        DeprecatedClassLeftInForLoading.dummies[index] = new DeprecatedClassLeftInForLoading((int) reader.ReadInt16(), (int) reader.ReadInt16());
      for (int index = num; index < 1000; ++index)
        DeprecatedClassLeftInForLoading.dummies[index] = (DeprecatedClassLeftInForLoading) null;
    }

    private static void LoadNPCs(BinaryReader reader)
    {
      int index = 0;
      for (bool flag = reader.ReadBoolean(); flag; flag = reader.ReadBoolean())
      {
        NPC npc = Main.npc[index];
        if (WorldFile.versionNumber >= 190)
          npc.SetDefaults(reader.ReadInt32());
        else
          npc.SetDefaults(NPCID.FromLegacyName(reader.ReadString()));
        npc.GivenName = reader.ReadString();
        npc.position.X = reader.ReadSingle();
        npc.position.Y = reader.ReadSingle();
        npc.homeless = reader.ReadBoolean();
        npc.homeTileX = reader.ReadInt32();
        npc.homeTileY = reader.ReadInt32();
        ++index;
      }
      if (WorldFile.versionNumber < 140)
        return;
      for (bool flag = reader.ReadBoolean(); flag; flag = reader.ReadBoolean())
      {
        NPC npc = Main.npc[index];
        if (WorldFile.versionNumber >= 190)
          npc.SetDefaults(reader.ReadInt32());
        else
          npc.SetDefaults(NPCID.FromLegacyName(reader.ReadString()));
        npc.position = reader.ReadVector2();
        ++index;
      }
    }

    private static int LoadFooter(BinaryReader reader) => !reader.ReadBoolean() || reader.ReadString() != Main.worldName || reader.ReadInt32() != Main.worldID ? 6 : 0;

    public static bool validateWorld(BinaryReader fileIO)
    {
      new Stopwatch().Start();
      try
      {
        Stream baseStream = fileIO.BaseStream;
        int num1 = fileIO.ReadInt32();
        if (num1 == 0 || num1 > 194)
          return false;
        baseStream.Position = 0L;
        bool[] importance;
        int[] positions;
        if (!WorldFile.LoadFileFormatHeader(fileIO, out importance, out positions))
          return false;
        string str1 = fileIO.ReadString();
        if (num1 >= 179)
        {
          if (num1 == 179)
            fileIO.ReadInt32();
          else
            fileIO.ReadString();
          long num2 = (long) fileIO.ReadUInt64();
        }
        if (num1 >= 181)
          fileIO.ReadBytes(16);
        int num3 = fileIO.ReadInt32();
        fileIO.ReadInt32();
        fileIO.ReadInt32();
        fileIO.ReadInt32();
        fileIO.ReadInt32();
        int num4 = fileIO.ReadInt32();
        int num5 = fileIO.ReadInt32();
        baseStream.Position = (long) positions[1];
        for (int index1 = 0; index1 < num5; ++index1)
        {
          float num6 = (float) index1 / (float) Main.maxTilesX;
          Main.statusText = Lang.gen[73].Value + " " + (object) (int) ((double) num6 * 100.0 + 1.0) + "%";
          int num7;
          for (int index2 = 0; index2 < num4; index2 = index2 + num7 + 1)
          {
            byte num8 = 0;
            byte num9 = fileIO.ReadByte();
            if (((int) num9 & 1) == 1 && ((int) fileIO.ReadByte() & 1) == 1)
              num8 = fileIO.ReadByte();
            if (((int) num9 & 2) == 2)
            {
              int index3;
              if (((int) num9 & 32) == 32)
              {
                byte num10 = fileIO.ReadByte();
                index3 = (int) fileIO.ReadByte() << 8 | (int) num10;
              }
              else
                index3 = (int) fileIO.ReadByte();
              if (importance[index3])
              {
                int num11 = (int) fileIO.ReadInt16();
                int num12 = (int) fileIO.ReadInt16();
              }
              if (((int) num8 & 8) == 8)
              {
                int num13 = (int) fileIO.ReadByte();
              }
            }
            if (((int) num9 & 4) == 4)
            {
              int num14 = (int) fileIO.ReadByte();
              if (((int) num8 & 16) == 16)
              {
                int num15 = (int) fileIO.ReadByte();
              }
            }
            if (((int) num9 & 24) >> 3 != 0)
            {
              int num16 = (int) fileIO.ReadByte();
            }
            switch ((byte) (((int) num9 & 192) >> 6))
            {
              case 0:
                num7 = 0;
                break;
              case 1:
                num7 = (int) fileIO.ReadByte();
                break;
              default:
                num7 = (int) fileIO.ReadInt16();
                break;
            }
          }
        }
        if (baseStream.Position != (long) positions[2])
          return false;
        int num17 = (int) fileIO.ReadInt16();
        int num18 = (int) fileIO.ReadInt16();
        for (int index4 = 0; index4 < num17; ++index4)
        {
          fileIO.ReadInt32();
          fileIO.ReadInt32();
          fileIO.ReadString();
          for (int index5 = 0; index5 < num18; ++index5)
          {
            if (fileIO.ReadInt16() > (short) 0)
            {
              fileIO.ReadInt32();
              int num19 = (int) fileIO.ReadByte();
            }
          }
        }
        if (baseStream.Position != (long) positions[3])
          return false;
        int num20 = (int) fileIO.ReadInt16();
        for (int index = 0; index < num20; ++index)
        {
          fileIO.ReadString();
          fileIO.ReadInt32();
          fileIO.ReadInt32();
        }
        if (baseStream.Position != (long) positions[4])
          return false;
        for (bool flag = fileIO.ReadBoolean(); flag; flag = fileIO.ReadBoolean())
        {
          fileIO.ReadInt32();
          fileIO.ReadString();
          double num21 = (double) fileIO.ReadSingle();
          double num22 = (double) fileIO.ReadSingle();
          fileIO.ReadBoolean();
          fileIO.ReadInt32();
          fileIO.ReadInt32();
        }
        for (bool flag = fileIO.ReadBoolean(); flag; flag = fileIO.ReadBoolean())
        {
          fileIO.ReadInt32();
          double num23 = (double) fileIO.ReadSingle();
          double num24 = (double) fileIO.ReadSingle();
        }
        if (baseStream.Position != (long) positions[5])
          return false;
        if (WorldFile.versionNumber >= 116 && WorldFile.versionNumber <= 121)
        {
          int num25 = fileIO.ReadInt32();
          for (int index = 0; index < num25; ++index)
          {
            int num26 = (int) fileIO.ReadInt16();
            int num27 = (int) fileIO.ReadInt16();
          }
          if (baseStream.Position != (long) positions[6])
            return false;
        }
        if (WorldFile.versionNumber >= 122)
        {
          int num28 = fileIO.ReadInt32();
          for (int index = 0; index < num28; ++index)
            TileEntity.Read(fileIO);
        }
        if (WorldFile.versionNumber >= 170)
        {
          int num29 = fileIO.ReadInt32();
          for (int index = 0; index < num29; ++index)
            fileIO.ReadInt64();
        }
        if (WorldFile.versionNumber >= 189)
        {
          int num30 = fileIO.ReadInt32();
          fileIO.ReadBytes(12 * num30);
        }
        int num31 = fileIO.ReadBoolean() ? 1 : 0;
        string str2 = fileIO.ReadString();
        int num32 = fileIO.ReadInt32();
        bool flag1 = false;
        if (num31 != 0 && (str2 == str1 || num32 == num3))
          flag1 = true;
        return flag1;
      }
      catch (Exception ex)
      {
        using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
        {
          streamWriter.WriteLine((object) DateTime.Now);
          streamWriter.WriteLine((object) ex);
          streamWriter.WriteLine("");
        }
        return false;
      }
    }

    public static string GetWorldName(string WorldFileName)
    {
      if (WorldFileName == null)
        return string.Empty;
      try
      {
        using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
          {
            int num1 = binaryReader.ReadInt32();
            if (num1 > 0)
            {
              if (num1 <= 194)
              {
                if (num1 <= 87)
                {
                  string str = binaryReader.ReadString();
                  binaryReader.Close();
                  return str;
                }
                if (num1 >= 135)
                  binaryReader.BaseStream.Position += 20L;
                int num2 = (int) binaryReader.ReadInt16();
                fileStream.Position = (long) binaryReader.ReadInt32();
                string str1 = binaryReader.ReadString();
                binaryReader.Close();
                return str1;
              }
            }
          }
        }
      }
      catch
      {
      }
      string[] strArray = WorldFileName.Split(Path.DirectorySeparatorChar);
      string str2 = strArray[strArray.Length - 1];
      return str2.Substring(0, str2.Length - 4);
    }

    public static bool GetWorldDifficulty(string WorldFileName)
    {
      if (WorldFileName == null)
        return false;
      try
      {
        using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
          {
            int num1 = binaryReader.ReadInt32();
            if (num1 >= 135)
              binaryReader.BaseStream.Position += 20L;
            if (num1 >= 112)
            {
              if (num1 <= 194)
              {
                int num2 = (int) binaryReader.ReadInt16();
                fileStream.Position = (long) binaryReader.ReadInt32();
                binaryReader.ReadString();
                binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                return binaryReader.ReadBoolean();
              }
            }
          }
        }
      }
      catch
      {
      }
      return false;
    }

    public static bool IsValidWorld(string file, bool cloudSave) => WorldFile.GetFileMetadata(file, cloudSave) != null;

    public static WorldFileData GetAllMetadata(string file, bool cloudSave)
    {
      if (file == null || cloudSave && SocialAPI.Cloud == null)
        return (WorldFileData) null;
      WorldFileData worldFileData = new WorldFileData(file, cloudSave);
      if (!FileUtilities.Exists(file, cloudSave))
      {
        worldFileData.CreationTime = DateTime.Now;
        worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
        return worldFileData;
      }
      try
      {
        using (Stream input = cloudSave ? (Stream) new MemoryStream(SocialAPI.Cloud.Read(file)) : (Stream) new FileStream(file, FileMode.Open))
        {
          using (BinaryReader reader = new BinaryReader(input))
          {
            int num1 = reader.ReadInt32();
            if (num1 >= 135)
              worldFileData.Metadata = FileMetadata.Read(reader, FileType.World);
            else
              worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
            if (num1 <= 194)
            {
              int num2 = (int) reader.ReadInt16();
              input.Position = (long) reader.ReadInt32();
              worldFileData.Name = reader.ReadString();
              if (num1 >= 179)
              {
                string seedText = num1 != 179 ? reader.ReadString() : reader.ReadInt32().ToString();
                worldFileData.SetSeed(seedText);
                worldFileData.WorldGeneratorVersion = reader.ReadUInt64();
              }
              else
              {
                worldFileData.SetSeedToEmpty();
                worldFileData.WorldGeneratorVersion = 0UL;
              }
              worldFileData.UniqueId = num1 < 181 ? Guid.Empty : new Guid(reader.ReadBytes(16));
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              int y = reader.ReadInt32();
              int x = reader.ReadInt32();
              worldFileData.SetWorldSize(x, y);
              worldFileData.IsExpertMode = num1 >= 112 && reader.ReadBoolean();
              worldFileData.CreationTime = num1 < 141 ? (cloudSave ? DateTime.Now : File.GetCreationTime(file)) : DateTime.FromBinary(reader.ReadInt64());
              int num3 = (int) reader.ReadByte();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadInt32();
              reader.ReadDouble();
              reader.ReadDouble();
              reader.ReadDouble();
              reader.ReadBoolean();
              reader.ReadInt32();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadInt32();
              reader.ReadInt32();
              worldFileData.HasCrimson = reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              int num4 = num1 < 118 ? 0 : (reader.ReadBoolean() ? 1 : 0);
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              reader.ReadBoolean();
              int num5 = (int) reader.ReadByte();
              reader.ReadInt32();
              worldFileData.IsHardMode = reader.ReadBoolean();
              return worldFileData;
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      return (WorldFileData) null;
    }

    public static WorldFileData CreateMetadata(
      string name,
      bool cloudSave,
      bool isExpertMode)
    {
      WorldFileData worldFileData = new WorldFileData(Main.GetWorldPathFromName(name, cloudSave), cloudSave);
      worldFileData.Name = name;
      worldFileData.IsExpertMode = isExpertMode;
      worldFileData.CreationTime = DateTime.Now;
      worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
      worldFileData.SetFavorite(false);
      worldFileData.WorldGeneratorVersion = 833223655425UL;
      worldFileData.UniqueId = Guid.NewGuid();
      if (Main.DefaultSeed == "")
        worldFileData.SetSeedToRandom();
      else
        worldFileData.SetSeed(Main.DefaultSeed);
      return worldFileData;
    }

    public static FileMetadata GetFileMetadata(string file, bool cloudSave)
    {
      if (file == null)
        return (FileMetadata) null;
      try
      {
        byte[] buffer = (byte[]) null;
        int num = !cloudSave ? 0 : (SocialAPI.Cloud != null ? 1 : 0);
        if (num != 0)
        {
          int length = 24;
          buffer = new byte[length];
          SocialAPI.Cloud.Read(file, buffer, length);
        }
        using (Stream input = num != 0 ? (Stream) new MemoryStream(buffer) : (Stream) new FileStream(file, FileMode.Open))
        {
          using (BinaryReader reader = new BinaryReader(input))
            return reader.ReadInt32() >= 135 ? FileMetadata.Read(reader, FileType.World) : FileMetadata.FromCurrentSettings(FileType.World);
        }
      }
      catch
      {
      }
      return (FileMetadata) null;
    }

    public static void ResetTemps()
    {
      WorldFile.tempRaining = false;
      WorldFile.tempMaxRain = 0.0f;
      WorldFile.tempRainTime = 0;
      WorldFile.tempDayTime = true;
      WorldFile.tempBloodMoon = false;
      WorldFile.tempEclipse = false;
      WorldFile.tempMoonPhase = 0;
      Main.anglerWhoFinishedToday.Clear();
      Main.anglerQuestFinished = false;
    }

    public static void FixDresserChests()
    {
      for (int X = 0; X < Main.maxTilesX; ++X)
      {
        for (int Y = 0; Y < Main.maxTilesY; ++Y)
        {
          Tile tile = Main.tile[X, Y];
          if (tile.active() && tile.type == (ushort) 88 && (int) tile.frameX % 54 == 0 && (int) tile.frameY % 36 == 0)
            Chest.CreateChest(X, Y);
        }
      }
    }

    private static int SaveTileEntities(BinaryWriter writer)
    {
      writer.Write(TileEntity.ByID.Count);
      foreach (KeyValuePair<int, TileEntity> keyValuePair in TileEntity.ByID)
        TileEntity.Write(writer, keyValuePair.Value);
      return (int) writer.BaseStream.Position;
    }

    private static void LoadTileEntities(BinaryReader reader)
    {
      TileEntity.ByID.Clear();
      TileEntity.ByPosition.Clear();
      int num1 = reader.ReadInt32();
      int num2 = 0;
      for (int index = 0; index < num1; ++index)
      {
        TileEntity tileEntity1 = TileEntity.Read(reader);
        tileEntity1.ID = num2++;
        TileEntity.ByID[tileEntity1.ID] = tileEntity1;
        TileEntity tileEntity2;
        if (TileEntity.ByPosition.TryGetValue(tileEntity1.Position, out tileEntity2))
          TileEntity.ByID.Remove(tileEntity2.ID);
        TileEntity.ByPosition[tileEntity1.Position] = tileEntity1;
      }
      TileEntity.TileEntitiesNextID = num1;
      List<Point16> point16List = new List<Point16>();
      foreach (KeyValuePair<Point16, TileEntity> keyValuePair in TileEntity.ByPosition)
      {
        if (!WorldGen.InWorld((int) keyValuePair.Value.Position.X, (int) keyValuePair.Value.Position.Y, 1))
        {
          point16List.Add(keyValuePair.Value.Position);
        }
        else
        {
          if (keyValuePair.Value.type == (byte) 0 && !TETrainingDummy.ValidTile((int) keyValuePair.Value.Position.X, (int) keyValuePair.Value.Position.Y))
            point16List.Add(keyValuePair.Value.Position);
          if (keyValuePair.Value.type == (byte) 2 && !TELogicSensor.ValidTile((int) keyValuePair.Value.Position.X, (int) keyValuePair.Value.Position.Y))
            point16List.Add(keyValuePair.Value.Position);
          if (keyValuePair.Value.type == (byte) 1 && !TEItemFrame.ValidTile((int) keyValuePair.Value.Position.X, (int) keyValuePair.Value.Position.Y))
            point16List.Add(keyValuePair.Value.Position);
        }
      }
      try
      {
        foreach (Point16 key in point16List)
        {
          TileEntity tileEntity = TileEntity.ByPosition[key];
          if (TileEntity.ByID.ContainsKey(tileEntity.ID))
            TileEntity.ByID.Remove(tileEntity.ID);
          if (TileEntity.ByPosition.ContainsKey(key))
            TileEntity.ByPosition.Remove(key);
        }
      }
      catch
      {
      }
    }

    private static int SaveWeightedPressurePlates(BinaryWriter writer)
    {
      writer.Write(PressurePlateHelper.PressurePlatesPressed.Count);
      foreach (KeyValuePair<Point, bool[]> keyValuePair in PressurePlateHelper.PressurePlatesPressed)
      {
        writer.Write(keyValuePair.Key.X);
        writer.Write(keyValuePair.Key.Y);
      }
      return (int) writer.BaseStream.Position;
    }

    private static void LoadWeightedPressurePlates(BinaryReader reader)
    {
      PressurePlateHelper.Reset();
      PressurePlateHelper.NeedsFirstUpdate = true;
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
      {
        Point key = new Point(reader.ReadInt32(), reader.ReadInt32());
        PressurePlateHelper.PressurePlatesPressed.Add(key, new bool[(int) byte.MaxValue]);
      }
    }

    private static int SaveTownManager(BinaryWriter writer)
    {
      WorldGen.TownManager.Save(writer);
      return (int) writer.BaseStream.Position;
    }

    private static void LoadTownManager(BinaryReader reader) => WorldGen.TownManager.Load(reader);
  }
}
