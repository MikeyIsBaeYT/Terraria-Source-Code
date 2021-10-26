// Decompiled with JetBrains decompiler
// Type: Terraria.IO.WorldFile
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;
using Terraria.Utilities;

namespace Terraria.IO
{
  public class WorldFile
  {
    private static readonly object IOLock = new object();
    private static double _tempTime = Main.time;
    private static bool _tempRaining;
    private static float _tempMaxRain;
    private static int _tempRainTime;
    private static bool _tempDayTime = Main.dayTime;
    private static bool _tempBloodMoon = Main.bloodMoon;
    private static bool _tempEclipse = Main.eclipse;
    private static int _tempMoonPhase = Main.moonPhase;
    private static int _tempCultistDelay = CultistRitual.delay;
    private static int _versionNumber;
    private static bool _isWorldOnCloud;
    private static bool _tempPartyGenuine;
    private static bool _tempPartyManual;
    private static int _tempPartyCooldown;
    private static readonly List<int> TempPartyCelebratingNPCs = new List<int>();
    private static bool _hasCache;
    private static bool? _cachedDayTime;
    private static double? _cachedTime;
    private static int? _cachedMoonPhase;
    private static bool? _cachedBloodMoon;
    private static bool? _cachedEclipse;
    private static int? _cachedCultistDelay;
    private static bool? _cachedPartyGenuine;
    private static bool? _cachedPartyManual;
    private static int? _cachedPartyDaysOnCooldown;
    private static readonly List<int> CachedCelebratingNPCs = new List<int>();
    private static bool? _cachedSandstormHappening;
    private static bool _tempSandstormHappening;
    private static int? _cachedSandstormTimeLeft;
    private static int _tempSandstormTimeLeft;
    private static float? _cachedSandstormSeverity;
    private static float _tempSandstormSeverity;
    private static float? _cachedSandstormIntendedSeverity;
    private static float _tempSandstormIntendedSeverity;
    private static bool _tempLanternNightGenuine;
    private static bool _tempLanternNightManual;
    private static bool _tempLanternNightNextNightIsGenuine;
    private static int _tempLanternNightCooldown;
    private static bool? _cachedLanternNightGenuine;
    private static bool? _cachedLanternNightManual;
    private static bool? _cachedLanternNightNextNightIsGenuine;
    private static int? _cachedLanternNightCooldown;
    public static Exception LastThrownLoadException;

    public static event Action OnWorldLoad;

    public static void CacheSaveTime()
    {
      WorldFile._hasCache = true;
      WorldFile._cachedDayTime = new bool?(Main.dayTime);
      WorldFile._cachedTime = new double?(Main.time);
      WorldFile._cachedMoonPhase = new int?(Main.moonPhase);
      WorldFile._cachedBloodMoon = new bool?(Main.bloodMoon);
      WorldFile._cachedEclipse = new bool?(Main.eclipse);
      WorldFile._cachedCultistDelay = new int?(CultistRitual.delay);
      WorldFile._cachedPartyGenuine = new bool?(BirthdayParty.GenuineParty);
      WorldFile._cachedPartyManual = new bool?(BirthdayParty.ManualParty);
      WorldFile._cachedPartyDaysOnCooldown = new int?(BirthdayParty.PartyDaysOnCooldown);
      WorldFile.CachedCelebratingNPCs.Clear();
      WorldFile.CachedCelebratingNPCs.AddRange((IEnumerable<int>) BirthdayParty.CelebratingNPCs);
      WorldFile._cachedSandstormHappening = new bool?(Sandstorm.Happening);
      WorldFile._cachedSandstormTimeLeft = new int?(Sandstorm.TimeLeft);
      WorldFile._cachedSandstormSeverity = new float?(Sandstorm.Severity);
      WorldFile._cachedSandstormIntendedSeverity = new float?(Sandstorm.IntendedSeverity);
      WorldFile._cachedLanternNightCooldown = new int?(LanternNight.LanternNightsOnCooldown);
      WorldFile._cachedLanternNightGenuine = new bool?(LanternNight.GenuineLanterns);
      WorldFile._cachedLanternNightManual = new bool?(LanternNight.ManualLanterns);
      WorldFile._cachedLanternNightNextNightIsGenuine = new bool?(LanternNight.NextNightIsLanternNight);
    }

    public static void SetOngoingToTemps()
    {
      Main.dayTime = WorldFile._tempDayTime;
      Main.time = WorldFile._tempTime;
      Main.moonPhase = WorldFile._tempMoonPhase;
      Main.bloodMoon = WorldFile._tempBloodMoon;
      Main.eclipse = WorldFile._tempEclipse;
      Main.raining = WorldFile._tempRaining;
      Main.rainTime = WorldFile._tempRainTime;
      Main.maxRaining = WorldFile._tempMaxRain;
      Main.cloudAlpha = WorldFile._tempMaxRain;
      CultistRitual.delay = WorldFile._tempCultistDelay;
      BirthdayParty.ManualParty = WorldFile._tempPartyManual;
      BirthdayParty.GenuineParty = WorldFile._tempPartyGenuine;
      BirthdayParty.PartyDaysOnCooldown = WorldFile._tempPartyCooldown;
      BirthdayParty.CelebratingNPCs.Clear();
      BirthdayParty.CelebratingNPCs.AddRange((IEnumerable<int>) WorldFile.TempPartyCelebratingNPCs);
      Sandstorm.Happening = WorldFile._tempSandstormHappening;
      Sandstorm.TimeLeft = WorldFile._tempSandstormTimeLeft;
      Sandstorm.Severity = WorldFile._tempSandstormSeverity;
      Sandstorm.IntendedSeverity = WorldFile._tempSandstormIntendedSeverity;
      LanternNight.GenuineLanterns = WorldFile._tempLanternNightGenuine;
      LanternNight.LanternNightsOnCooldown = WorldFile._tempLanternNightCooldown;
      LanternNight.ManualLanterns = WorldFile._tempLanternNightManual;
      LanternNight.NextNightIsLanternNight = WorldFile._tempLanternNightNextNightIsGenuine;
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
            if (num1 <= 230)
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
              if (num1 >= 209)
              {
                worldFileData.GameMode = reader.ReadInt32();
                if (num1 >= 222)
                {
                  worldFileData.DrunkWorld = reader.ReadBoolean();
                  if (num1 >= 227)
                    reader.ReadBoolean();
                }
              }
              else if (num1 >= 112)
                worldFileData.GameMode = !reader.ReadBoolean() ? 0 : 1;
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
      int GameMode)
    {
      WorldFileData worldFileData = new WorldFileData(Main.GetWorldPathFromName(name, cloudSave), cloudSave);
      if (Main.autoGenFileLocation != null && Main.autoGenFileLocation != "")
      {
        worldFileData = new WorldFileData(Main.autoGenFileLocation, cloudSave);
        Main.autoGenFileLocation = (string) null;
      }
      worldFileData.Name = name;
      worldFileData.GameMode = GameMode;
      worldFileData.CreationTime = DateTime.Now;
      worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
      worldFileData.SetFavorite(false);
      worldFileData.WorldGeneratorVersion = 987842478081UL;
      worldFileData.UniqueId = Guid.NewGuid();
      if (Main.DefaultSeed == "")
        worldFileData.SetSeedToRandom();
      else
        worldFileData.SetSeed(Main.DefaultSeed);
      return worldFileData;
    }

    public static void ResetTemps()
    {
      WorldFile._tempRaining = false;
      WorldFile._tempMaxRain = 0.0f;
      WorldFile._tempRainTime = 0;
      WorldFile._tempDayTime = true;
      WorldFile._tempBloodMoon = false;
      WorldFile._tempEclipse = false;
      WorldFile._tempMoonPhase = 0;
      Main.anglerWhoFinishedToday.Clear();
      Main.anglerQuestFinished = false;
    }

    private static void ClearTempTiles()
    {
      for (int i = 0; i < Main.maxTilesX; ++i)
      {
        for (int j = 0; j < Main.maxTilesY; ++j)
        {
          if (Main.tile[i, j].type == (ushort) sbyte.MaxValue || Main.tile[i, j].type == (ushort) 504)
            WorldGen.KillTile(i, j);
        }
      }
    }

    public static void LoadWorld(bool loadFromCloud)
    {
      Main.lockMenuBGChange = true;
      WorldFile._isWorldOnCloud = loadFromCloud;
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
              Utils.TryCreatingDirectory(Main.worldPathName.Substring(0, index));
              break;
            }
          }
        }
        WorldGen.clearWorld();
        Main.ActiveWorldFileData = WorldFile.CreateMetadata(Main.worldName == "" ? "World" : Main.worldName, flag, Main.GameMode);
        string seedText = (Main.AutogenSeedName ?? "").Trim();
        if (seedText.Length == 0)
          Main.ActiveWorldFileData.SetSeedToRandom();
        else
          Main.ActiveWorldFileData.SetSeed(seedText);
        WorldGen.GenerateWorld(Main.ActiveWorldFileData.Seed, Main.AutogenProgress);
        WorldFile.SaveWorld();
      }
      using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(Main.worldPathName, flag)))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) memoryStream))
        {
          try
          {
            WorldGen.loadFailed = false;
            WorldGen.loadSuccess = false;
            int num1 = binaryReader.ReadInt32();
            WorldFile._versionNumber = num1;
            if (WorldFile._versionNumber <= 0 || WorldFile._versionNumber > 230)
            {
              WorldGen.loadFailed = true;
              return;
            }
            int num2 = num1 > 87 ? WorldFile.LoadWorld_Version2(binaryReader) : WorldFile.LoadWorld_Version1_Old_BeforeRelease88(binaryReader);
            if (num1 < 141)
              Main.ActiveWorldFileData.CreationTime = loadFromCloud ? DateTime.Now : File.GetCreationTime(Main.worldPathName);
            WorldFile.CheckSavedOreTiers();
            binaryReader.Close();
            memoryStream.Close();
            if (num2 != 0)
              WorldGen.loadFailed = true;
            else
              WorldGen.loadSuccess = true;
            if (WorldGen.loadFailed || !WorldGen.loadSuccess)
              return;
            WorldFile.ConvertOldTileEntities();
            WorldFile.ClearTempTiles();
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
            if (Main.slimeRainTime > 0.0)
              Main.StartSlimeRain(false);
            NPC.SetWorldSpecificMonstersByWorldID();
          }
          catch (Exception ex)
          {
            WorldFile.LastThrownLoadException = ex;
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

    public static void CheckSavedOreTiers()
    {
      if (WorldGen.SavedOreTiers.Copper != -1 && WorldGen.SavedOreTiers.Iron != -1 && WorldGen.SavedOreTiers.Silver != -1 && WorldGen.SavedOreTiers.Gold != -1)
        return;
      int[] numArray = WorldGen.CountTileTypesInWorld(7, 166, 6, 167, 9, 168, 8, 169);
      for (int index = 0; index < numArray.Length; index += 2)
      {
        int num1 = numArray[index];
        int num2 = numArray[index + 1];
        switch (index)
        {
          case 0:
            WorldGen.SavedOreTiers.Copper = num1 <= num2 ? 166 : 7;
            break;
          case 2:
            WorldGen.SavedOreTiers.Iron = num1 <= num2 ? 167 : 6;
            break;
          case 4:
            WorldGen.SavedOreTiers.Silver = num1 <= num2 ? 168 : 9;
            break;
          case 6:
            WorldGen.SavedOreTiers.Gold = num1 <= num2 ? 169 : 8;
            break;
        }
      }
    }

    public static void SaveWorld()
    {
      try
      {
        WorldFile.SaveWorld(WorldFile._isWorldOnCloud);
      }
      catch (Exception ex)
      {
        string worldPath = Main.WorldPath;
        FancyErrorPrinter.ShowFileSavingFailError(ex, worldPath);
        throw;
      }
    }

    public static void SaveWorld(bool useCloudSaving, bool resetTime = false)
    {
      if (useCloudSaving && SocialAPI.Cloud == null)
        return;
      if (Main.worldName == "")
        Main.worldName = "World";
      while (WorldGen.IsGeneratingHardMode)
        Main.statusText = Lang.gen[48].Value;
      if (!Monitor.TryEnter(WorldFile.IOLock))
        return;
      try
      {
        FileUtilities.ProtectedInvoke((Action) (() => WorldFile.InternalSaveWorld(useCloudSaving, resetTime)));
      }
      finally
      {
        Monitor.Exit(WorldFile.IOLock);
      }
    }

    private static void InternalSaveWorld(bool useCloudSaving, bool resetTime)
    {
      Utils.TryCreatingDirectory(Main.WorldPath);
      if (Main.skipMenu)
        return;
      if (WorldFile._hasCache)
        WorldFile.SetTempToCache();
      else
        WorldFile.SetTempToOngoing();
      if (resetTime)
        WorldFile.ResetTempsToDayTime();
      if (Main.worldPathName == null)
        return;
      new Stopwatch().Start();
      byte[] array;
      int length;
      using (MemoryStream memoryStream = new MemoryStream(7000000))
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) memoryStream))
          WorldFile.SaveWorld_Version2(writer);
        array = memoryStream.ToArray();
        length = array.Length;
      }
      byte[] data = (byte[]) null;
      if (FileUtilities.Exists(Main.worldPathName, useCloudSaving))
        data = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
      FileUtilities.Write(Main.worldPathName, array, length, useCloudSaving);
      byte[] buffer = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
      string str = (string) null;
      using (MemoryStream memoryStream = new MemoryStream(buffer, 0, length, false))
      {
        using (BinaryReader fileIO = new BinaryReader((Stream) memoryStream))
        {
          if (!Main.validateSaves || WorldFile.ValidateWorld(fileIO))
          {
            if (data != null)
            {
              str = Main.worldPathName + ".bak";
              Main.statusText = Lang.gen[50].Value;
            }
            WorldFile.DoRollingBackups(str);
          }
          else
            str = Main.worldPathName;
        }
      }
      if (str == null || data == null)
        return;
      FileUtilities.WriteAllBytes(str, data, useCloudSaving);
    }

    private static void DoRollingBackups(string backupWorldWritePath)
    {
      if (Main.WorldRollingBackupsCountToKeep <= 1)
        return;
      int num1 = Main.WorldRollingBackupsCountToKeep;
      if (num1 > 9)
        num1 = 9;
      int num2 = 1;
      for (int index = 1; index < num1; ++index)
      {
        string path = backupWorldWritePath + (object) index;
        if (index == 1)
          path = backupWorldWritePath;
        if (FileUtilities.Exists(path, false))
          num2 = index + 1;
        else
          break;
      }
      for (int index = num2 - 1; index > 0; --index)
      {
        string str = backupWorldWritePath + (object) index;
        if (index == 1)
          str = backupWorldWritePath;
        string destination = backupWorldWritePath + (object) (index + 1);
        if (FileUtilities.Exists(str, false))
          FileUtilities.Move(str, destination, false);
      }
    }

    private static void ResetTempsToDayTime()
    {
      WorldFile._tempDayTime = true;
      WorldFile._tempTime = 13500.0;
      WorldFile._tempMoonPhase = 0;
      WorldFile._tempBloodMoon = false;
      WorldFile._tempEclipse = false;
      WorldFile._tempCultistDelay = 86400;
      WorldFile._tempPartyManual = false;
      WorldFile._tempPartyGenuine = false;
      WorldFile._tempPartyCooldown = 0;
      WorldFile.TempPartyCelebratingNPCs.Clear();
      WorldFile._tempSandstormHappening = false;
      WorldFile._tempSandstormTimeLeft = 0;
      WorldFile._tempSandstormSeverity = 0.0f;
      WorldFile._tempSandstormIntendedSeverity = 0.0f;
      WorldFile._tempLanternNightCooldown = 0;
      WorldFile._tempLanternNightGenuine = false;
      WorldFile._tempLanternNightManual = false;
      WorldFile._tempLanternNightNextNightIsGenuine = false;
    }

    private static void SetTempToOngoing()
    {
      WorldFile._tempDayTime = Main.dayTime;
      WorldFile._tempTime = Main.time;
      WorldFile._tempMoonPhase = Main.moonPhase;
      WorldFile._tempBloodMoon = Main.bloodMoon;
      WorldFile._tempEclipse = Main.eclipse;
      WorldFile._tempCultistDelay = CultistRitual.delay;
      WorldFile._tempPartyManual = BirthdayParty.ManualParty;
      WorldFile._tempPartyGenuine = BirthdayParty.GenuineParty;
      WorldFile._tempPartyCooldown = BirthdayParty.PartyDaysOnCooldown;
      WorldFile.TempPartyCelebratingNPCs.Clear();
      WorldFile.TempPartyCelebratingNPCs.AddRange((IEnumerable<int>) BirthdayParty.CelebratingNPCs);
      WorldFile._tempSandstormHappening = Sandstorm.Happening;
      WorldFile._tempSandstormTimeLeft = Sandstorm.TimeLeft;
      WorldFile._tempSandstormSeverity = Sandstorm.Severity;
      WorldFile._tempSandstormIntendedSeverity = Sandstorm.IntendedSeverity;
      WorldFile._tempRaining = Main.raining;
      WorldFile._tempRainTime = Main.rainTime;
      WorldFile._tempMaxRain = Main.maxRaining;
      WorldFile._tempLanternNightCooldown = LanternNight.LanternNightsOnCooldown;
      WorldFile._tempLanternNightGenuine = LanternNight.GenuineLanterns;
      WorldFile._tempLanternNightManual = LanternNight.ManualLanterns;
      WorldFile._tempLanternNightNextNightIsGenuine = LanternNight.NextNightIsLanternNight;
    }

    private static void SetTempToCache()
    {
      WorldFile._hasCache = false;
      WorldFile._tempDayTime = WorldFile._cachedDayTime.Value;
      WorldFile._tempTime = WorldFile._cachedTime.Value;
      WorldFile._tempMoonPhase = WorldFile._cachedMoonPhase.Value;
      WorldFile._tempBloodMoon = WorldFile._cachedBloodMoon.Value;
      WorldFile._tempEclipse = WorldFile._cachedEclipse.Value;
      WorldFile._tempCultistDelay = WorldFile._cachedCultistDelay.Value;
      WorldFile._tempPartyManual = WorldFile._cachedPartyManual.Value;
      WorldFile._tempPartyGenuine = WorldFile._cachedPartyGenuine.Value;
      WorldFile._tempPartyCooldown = WorldFile._cachedPartyDaysOnCooldown.Value;
      WorldFile.TempPartyCelebratingNPCs.Clear();
      WorldFile.TempPartyCelebratingNPCs.AddRange((IEnumerable<int>) WorldFile.CachedCelebratingNPCs);
      WorldFile._tempSandstormHappening = WorldFile._cachedSandstormHappening.Value;
      WorldFile._tempSandstormTimeLeft = WorldFile._cachedSandstormTimeLeft.Value;
      WorldFile._tempSandstormSeverity = WorldFile._cachedSandstormSeverity.Value;
      WorldFile._tempSandstormIntendedSeverity = WorldFile._cachedSandstormIntendedSeverity.Value;
      WorldFile._tempRaining = Main.raining;
      WorldFile._tempRainTime = Main.rainTime;
      WorldFile._tempMaxRain = Main.maxRaining;
      WorldFile._tempLanternNightCooldown = WorldFile._cachedLanternNightCooldown.Value;
      WorldFile._tempLanternNightGenuine = WorldFile._cachedLanternNightGenuine.Value;
      WorldFile._tempLanternNightManual = WorldFile._cachedLanternNightManual.Value;
      WorldFile._tempLanternNightNextNightIsGenuine = WorldFile._cachedLanternNightNextNightIsGenuine.Value;
    }

    private static void ConvertOldTileEntities()
    {
      List<Point> pointList1 = new List<Point>();
      List<Point> pointList2 = new List<Point>();
      for (int x = 0; x < Main.maxTilesX; ++x)
      {
        for (int y = 0; y < Main.maxTilesY; ++y)
        {
          Tile tile = Main.tile[x, y];
          if ((tile.type == (ushort) 128 || tile.type == (ushort) 269) && tile.frameY == (short) 0 && ((int) tile.frameX % 100 == 0 || (int) tile.frameX % 100 == 36))
            pointList1.Add(new Point(x, y));
          if (tile.type == (ushort) 334 && tile.frameY == (short) 0 && (int) tile.frameX % 54 == 0)
            pointList2.Add(new Point(x, y));
          if (tile.type == (ushort) 49 && (tile.frameX == (short) -1 || tile.frameY == (short) -1))
          {
            tile.frameX = (short) 0;
            tile.frameY = (short) 0;
          }
        }
      }
      foreach (Point point in pointList1)
      {
        if (WorldGen.InWorld(point.X, point.Y, 5))
        {
          int frameX1 = (int) Main.tile[point.X, point.Y].frameX;
          int frameX2 = (int) Main.tile[point.X, point.Y + 1].frameX;
          int frameX3 = (int) Main.tile[point.X, point.Y + 2].frameX;
          for (int index1 = 0; index1 < 2; ++index1)
          {
            for (int index2 = 0; index2 < 3; ++index2)
            {
              Tile tile = Main.tile[point.X + index1, point.Y + index2];
              tile.frameX %= (short) 100;
              if (tile.type == (ushort) 269)
                tile.frameX += (short) 72;
              tile.type = (ushort) 470;
            }
          }
          int key = TEDisplayDoll.Place(point.X, point.Y);
          if (key != -1)
            (TileEntity.ByID[key] as TEDisplayDoll).SetInventoryFromMannequin(frameX1, frameX2, frameX3);
        }
      }
      foreach (Point point in pointList2)
      {
        if (WorldGen.InWorld(point.X, point.Y, 5))
        {
          bool flag1 = Main.tile[point.X, point.Y].frameX >= (short) 54;
          int frameX4 = (int) Main.tile[point.X, point.Y + 1].frameX;
          int frameX5 = (int) Main.tile[point.X + 1, point.Y + 1].frameX;
          bool flag2 = frameX4 >= 5000;
          int netid = frameX4 % 5000 - 100;
          int prefix = frameX5 - (frameX5 >= 25000 ? 25000 : 10000);
          for (int index3 = 0; index3 < 3; ++index3)
          {
            for (int index4 = 0; index4 < 3; ++index4)
            {
              Tile tile = Main.tile[point.X + index3, point.Y + index4];
              tile.type = (ushort) 471;
              tile.frameX = (short) ((flag1 ? 54 : 0) + index3 * 18);
              tile.frameY = (short) (index4 * 18);
            }
          }
          if (TEWeaponsRack.Place(point.X, point.Y) != -1 & flag2)
            TEWeaponsRack.TryPlacing(point.X, point.Y, netid, prefix, 1);
        }
      }
    }

    private static void SaveWorld_Version2(BinaryWriter writer)
    {
      int[] pointers = new int[11]
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
        WorldFile.SaveBestiary(writer),
        WorldFile.SaveCreativePowers(writer)
      };
      WorldFile.SaveFooter(writer);
      WorldFile.SaveHeaderPointers(writer, pointers);
    }

    private static int SaveFileFormatHeader(BinaryWriter writer)
    {
      short num1 = 623;
      short num2 = 11;
      writer.Write(230);
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
      writer.Write(230);
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
      writer.Write(Main.GameMode);
      writer.Write(Main.drunkWorld);
      writer.Write(Main.getGoodWorld);
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
      writer.Write(WorldFile._tempTime);
      writer.Write(WorldFile._tempDayTime);
      writer.Write(WorldFile._tempMoonPhase);
      writer.Write(WorldFile._tempBloodMoon);
      writer.Write(WorldFile._tempEclipse);
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
      writer.Write(WorldFile._tempRaining);
      writer.Write(WorldFile._tempRainTime);
      writer.Write(WorldFile._tempMaxRain);
      writer.Write(WorldGen.SavedOreTiers.Cobalt);
      writer.Write(WorldGen.SavedOreTiers.Mythril);
      writer.Write(WorldGen.SavedOreTiers.Adamantite);
      writer.Write((byte) WorldGen.treeBG1);
      writer.Write((byte) WorldGen.corruptBG);
      writer.Write((byte) WorldGen.jungleBG);
      writer.Write((byte) WorldGen.snowBG);
      writer.Write((byte) WorldGen.hallowBG);
      writer.Write((byte) WorldGen.crimsonBG);
      writer.Write((byte) WorldGen.desertBG);
      writer.Write((byte) WorldGen.oceanBG);
      writer.Write((int) Main.cloudBGActive);
      writer.Write((short) Main.numClouds);
      writer.Write(Main.windSpeedTarget);
      writer.Write(Main.anglerWhoFinishedToday.Count);
      for (int index = 0; index < Main.anglerWhoFinishedToday.Count; ++index)
        writer.Write(Main.anglerWhoFinishedToday[index]);
      writer.Write(NPC.savedAngler);
      writer.Write(Main.anglerQuest);
      writer.Write(NPC.savedStylist);
      writer.Write(NPC.savedTaxCollector);
      writer.Write(NPC.savedGolfer);
      writer.Write(Main.invasionSizeStart);
      writer.Write(WorldFile._tempCultistDelay);
      writer.Write((short) 663);
      for (int index = 0; index < 663; ++index)
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
      writer.Write(WorldFile._tempPartyManual);
      writer.Write(WorldFile._tempPartyGenuine);
      writer.Write(WorldFile._tempPartyCooldown);
      writer.Write(WorldFile.TempPartyCelebratingNPCs.Count);
      for (int index = 0; index < WorldFile.TempPartyCelebratingNPCs.Count; ++index)
        writer.Write(WorldFile.TempPartyCelebratingNPCs[index]);
      writer.Write(WorldFile._tempSandstormHappening);
      writer.Write(WorldFile._tempSandstormTimeLeft);
      writer.Write(WorldFile._tempSandstormSeverity);
      writer.Write(WorldFile._tempSandstormIntendedSeverity);
      writer.Write(NPC.savedBartender);
      DD2Event.Save(writer);
      writer.Write((byte) WorldGen.mushroomBG);
      writer.Write((byte) WorldGen.underworldBG);
      writer.Write((byte) WorldGen.treeBG2);
      writer.Write((byte) WorldGen.treeBG3);
      writer.Write((byte) WorldGen.treeBG4);
      writer.Write(NPC.combatBookWasUsed);
      writer.Write(WorldFile._tempLanternNightCooldown);
      writer.Write(WorldFile._tempLanternNightGenuine);
      writer.Write(WorldFile._tempLanternNightManual);
      writer.Write(WorldFile._tempLanternNightNextNightIsGenuine);
      WorldGen.TreeTops.Save(writer);
      writer.Write(Main.forceHalloweenForToday);
      writer.Write(Main.forceXMasForToday);
      writer.Write(WorldGen.SavedOreTiers.Copper);
      writer.Write(WorldGen.SavedOreTiers.Iron);
      writer.Write(WorldGen.SavedOreTiers.Silver);
      writer.Write(WorldGen.SavedOreTiers.Gold);
      writer.Write(NPC.boughtCat);
      writer.Write(NPC.boughtDog);
      writer.Write(NPC.boughtBunny);
      writer.Write(NPC.downedEmpressOfLight);
      writer.Write(NPC.downedQueenSlime);
      return (int) writer.BaseStream.Position;
    }

    private static int SaveWorldTiles(BinaryWriter writer)
    {
      byte[] buffer = new byte[15];
      for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
      {
        float num1 = (float) index1 / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[49].Value + " " + (object) (int) ((double) num1 * 100.0 + 1.0) + "%";
        int num2;
        for (int index2 = 0; index2 < Main.maxTilesY; index2 = num2 + 1)
        {
          Tile tile = Main.tile[index1, index2];
          int index3 = 3;
          int num3;
          byte num4 = (byte) (num3 = 0);
          byte num5 = (byte) num3;
          byte num6 = (byte) num3;
          bool flag = false;
          if (tile.active())
            flag = true;
          if (flag)
          {
            num6 |= (byte) 2;
            buffer[index3] = (byte) tile.type;
            ++index3;
            if (tile.type > (ushort) byte.MaxValue)
            {
              buffer[index3] = (byte) ((uint) tile.type >> 8);
              ++index3;
              num6 |= (byte) 32;
            }
            if (Main.tileFrameImportant[(int) tile.type])
            {
              buffer[index3] = (byte) ((uint) tile.frameX & (uint) byte.MaxValue);
              int index4 = index3 + 1;
              buffer[index4] = (byte) (((int) tile.frameX & 65280) >> 8);
              int index5 = index4 + 1;
              buffer[index5] = (byte) ((uint) tile.frameY & (uint) byte.MaxValue);
              int index6 = index5 + 1;
              buffer[index6] = (byte) (((int) tile.frameY & 65280) >> 8);
              index3 = index6 + 1;
            }
            if (tile.color() != (byte) 0)
            {
              num4 |= (byte) 8;
              buffer[index3] = tile.color();
              ++index3;
            }
          }
          if (tile.wall != (ushort) 0)
          {
            num6 |= (byte) 4;
            buffer[index3] = (byte) tile.wall;
            ++index3;
            if (tile.wallColor() != (byte) 0)
            {
              num4 |= (byte) 16;
              buffer[index3] = tile.wallColor();
              ++index3;
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
            buffer[index3] = tile.liquid;
            ++index3;
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
          if (tile.wall > (ushort) byte.MaxValue)
          {
            buffer[index3] = (byte) ((uint) tile.wall >> 8);
            ++index3;
            num4 |= (byte) 64;
          }
          int index7 = 2;
          if (num4 != (byte) 0)
          {
            num8 |= (byte) 1;
            buffer[index7] = num4;
            --index7;
          }
          if (num8 != (byte) 0)
          {
            num6 |= (byte) 1;
            buffer[index7] = num8;
            --index7;
          }
          short num9 = 0;
          int index8 = index2 + 1;
          for (int index9 = Main.maxTilesY - index2 - 1; index9 > 0 && tile.isTheSameAs(Main.tile[index1, index8]); ++index8)
          {
            ++num9;
            --index9;
          }
          num2 = index2 + (int) num9;
          if (num9 > (short) 0)
          {
            buffer[index3] = (byte) ((uint) num9 & (uint) byte.MaxValue);
            ++index3;
            if (num9 > (short) byte.MaxValue)
            {
              num6 |= (byte) 128;
              buffer[index3] = (byte) (((int) num9 & 65280) >> 8);
              ++index3;
            }
            else
              num6 |= (byte) 64;
          }
          buffer[index7] = num6;
          writer.Write(buffer, index7, index3 - index7);
        }
      }
      return (int) writer.BaseStream.Position;
    }

    private static int SaveChests(BinaryWriter writer)
    {
      short num = 0;
      for (int index = 0; index < 8000; ++index)
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
      for (int index1 = 0; index1 < 8000; ++index1)
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
          BitsByte bitsByte = (BitsByte) (byte) 0;
          bitsByte[0] = npc.townNPC;
          writer.Write((byte) bitsByte);
          if (bitsByte[0])
            writer.Write(npc.townNpcVariationIndex);
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

    private static int LoadWorld_Version2(BinaryReader reader)
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
      if (WorldFile._versionNumber >= 116)
      {
        if (WorldFile._versionNumber < 122)
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
      if (WorldFile._versionNumber >= 170)
      {
        WorldFile.LoadWeightedPressurePlates(reader);
        if (reader.BaseStream.Position != (long) positions[7])
          return 5;
      }
      if (WorldFile._versionNumber >= 189)
      {
        WorldFile.LoadTownManager(reader);
        if (reader.BaseStream.Position != (long) positions[8])
          return 5;
      }
      if (WorldFile._versionNumber >= 210)
      {
        WorldFile.LoadBestiary(reader, WorldFile._versionNumber);
        if (reader.BaseStream.Position != (long) positions[9])
          return 5;
      }
      else
        WorldFile.LoadBestiaryForVersionsBefore210();
      if (WorldFile._versionNumber >= 220)
      {
        WorldFile.LoadCreativePowers(reader, WorldFile._versionNumber);
        if (reader.BaseStream.Position != (long) positions[10])
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
      if ((WorldFile._versionNumber = reader.ReadInt32()) >= 135)
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
      int versionNumber = WorldFile._versionNumber;
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
      if (versionNumber >= 209)
      {
        Main.GameMode = reader.ReadInt32();
        if (versionNumber >= 222)
          Main.drunkWorld = reader.ReadBoolean();
        if (versionNumber >= 227)
          Main.getGoodWorld = reader.ReadBoolean();
      }
      else
      {
        Main.GameMode = versionNumber < 112 ? 0 : (reader.ReadBoolean() ? 1 : 0);
        if (versionNumber == 208 && reader.ReadBoolean())
          Main.GameMode = 2;
      }
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
      WorldFile._tempTime = reader.ReadDouble();
      WorldFile._tempDayTime = reader.ReadBoolean();
      WorldFile._tempMoonPhase = reader.ReadInt32();
      WorldFile._tempBloodMoon = reader.ReadBoolean();
      WorldFile._tempEclipse = reader.ReadBoolean();
      Main.eclipse = WorldFile._tempEclipse;
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
      WorldFile._tempRaining = reader.ReadBoolean();
      WorldFile._tempRainTime = reader.ReadInt32();
      WorldFile._tempMaxRain = reader.ReadSingle();
      WorldGen.SavedOreTiers.Cobalt = reader.ReadInt32();
      WorldGen.SavedOreTiers.Mythril = reader.ReadInt32();
      WorldGen.SavedOreTiers.Adamantite = reader.ReadInt32();
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
      Main.windSpeedTarget = reader.ReadSingle();
      Main.windSpeedCurrent = Main.windSpeedTarget;
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
      if (versionNumber >= 201)
        NPC.savedGolfer = reader.ReadBoolean();
      if (versionNumber < 107)
      {
        if (Main.invasionType > 0 && Main.invasionSize > 0)
          Main.FakeLoadInvasionStart();
      }
      else
        Main.invasionSizeStart = reader.ReadInt32();
      WorldFile._tempCultistDelay = versionNumber >= 108 ? reader.ReadInt32() : 86400;
      if (versionNumber < 109)
        return;
      int num1 = (int) reader.ReadInt16();
      for (int index = 0; index < num1; ++index)
      {
        if (index < 663)
          NPC.killCount[index] = reader.ReadInt32();
        else
          reader.ReadInt32();
      }
      if (versionNumber < 128)
        return;
      Main.fastForwardTime = reader.ReadBoolean();
      Main.UpdateTimeRate();
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
        WorldFile._tempPartyManual = false;
        WorldFile._tempPartyGenuine = false;
        WorldFile._tempPartyCooldown = 0;
        WorldFile.TempPartyCelebratingNPCs.Clear();
      }
      else
      {
        WorldFile._tempPartyManual = reader.ReadBoolean();
        WorldFile._tempPartyGenuine = reader.ReadBoolean();
        WorldFile._tempPartyCooldown = reader.ReadInt32();
        int num2 = reader.ReadInt32();
        WorldFile.TempPartyCelebratingNPCs.Clear();
        for (int index = 0; index < num2; ++index)
          WorldFile.TempPartyCelebratingNPCs.Add(reader.ReadInt32());
      }
      if (versionNumber < 174)
      {
        WorldFile._tempSandstormHappening = false;
        WorldFile._tempSandstormTimeLeft = 0;
        WorldFile._tempSandstormSeverity = 0.0f;
        WorldFile._tempSandstormIntendedSeverity = 0.0f;
      }
      else
      {
        WorldFile._tempSandstormHappening = reader.ReadBoolean();
        WorldFile._tempSandstormTimeLeft = reader.ReadInt32();
        WorldFile._tempSandstormSeverity = reader.ReadSingle();
        WorldFile._tempSandstormIntendedSeverity = reader.ReadSingle();
      }
      DD2Event.Load(reader, versionNumber);
      if (versionNumber > 194)
        WorldGen.setBG(8, (int) reader.ReadByte());
      else
        WorldGen.setBG(8, 0);
      if (versionNumber >= 215)
        WorldGen.setBG(9, (int) reader.ReadByte());
      else
        WorldGen.setBG(9, 0);
      if (versionNumber > 195)
      {
        WorldGen.setBG(10, (int) reader.ReadByte());
        WorldGen.setBG(11, (int) reader.ReadByte());
        WorldGen.setBG(12, (int) reader.ReadByte());
      }
      else
      {
        WorldGen.setBG(10, WorldGen.treeBG1);
        WorldGen.setBG(11, WorldGen.treeBG1);
        WorldGen.setBG(12, WorldGen.treeBG1);
      }
      if (versionNumber >= 204)
        NPC.combatBookWasUsed = reader.ReadBoolean();
      if (versionNumber < 207)
      {
        WorldFile._tempLanternNightCooldown = 0;
        WorldFile._tempLanternNightGenuine = false;
        WorldFile._tempLanternNightManual = false;
        WorldFile._tempLanternNightNextNightIsGenuine = false;
      }
      else
      {
        WorldFile._tempLanternNightCooldown = reader.ReadInt32();
        WorldFile._tempLanternNightGenuine = reader.ReadBoolean();
        WorldFile._tempLanternNightManual = reader.ReadBoolean();
        WorldFile._tempLanternNightNextNightIsGenuine = reader.ReadBoolean();
      }
      WorldGen.TreeTops.Load(reader, versionNumber);
      if (versionNumber >= 212)
      {
        Main.forceHalloweenForToday = reader.ReadBoolean();
        Main.forceXMasForToday = reader.ReadBoolean();
      }
      else
      {
        Main.forceHalloweenForToday = false;
        Main.forceXMasForToday = false;
      }
      if (versionNumber >= 216)
      {
        WorldGen.SavedOreTiers.Copper = reader.ReadInt32();
        WorldGen.SavedOreTiers.Iron = reader.ReadInt32();
        WorldGen.SavedOreTiers.Silver = reader.ReadInt32();
        WorldGen.SavedOreTiers.Gold = reader.ReadInt32();
      }
      else
      {
        WorldGen.SavedOreTiers.Copper = -1;
        WorldGen.SavedOreTiers.Iron = -1;
        WorldGen.SavedOreTiers.Silver = -1;
        WorldGen.SavedOreTiers.Gold = -1;
      }
      if (versionNumber >= 217)
      {
        NPC.boughtCat = reader.ReadBoolean();
        NPC.boughtDog = reader.ReadBoolean();
        NPC.boughtBunny = reader.ReadBoolean();
      }
      else
      {
        NPC.boughtCat = false;
        NPC.boughtDog = false;
        NPC.boughtBunny = false;
      }
      if (versionNumber >= 223)
      {
        NPC.downedEmpressOfLight = reader.ReadBoolean();
        NPC.downedQueenSlime = reader.ReadBoolean();
      }
      else
      {
        NPC.downedEmpressOfLight = false;
        NPC.downedQueenSlime = false;
      }
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
            from.wall = (ushort) reader.ReadByte();
            if (from.wall >= (ushort) 316)
              from.wall = (ushort) 0;
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
            if (num7 != (byte) 0 && (Main.tileSolid[(int) from.type] || TileID.Sets.NonSolidSaveSlopes[(int) from.type]))
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
            if (((int) num2 & 64) == 64)
            {
              byte num8 = reader.ReadByte();
              from.wall = (ushort) ((uint) num8 << 8 | (uint) from.wall);
              if (from.wall >= (ushort) 316)
                from.wall = (ushort) 0;
            }
          }
          int num9;
          switch ((byte) (((int) num4 & 192) >> 6))
          {
            case 0:
              num9 = 0;
              break;
            case 1:
              num9 = (int) reader.ReadByte();
              break;
            default:
              num9 = (int) reader.ReadInt16();
              break;
          }
          if (index3 != -1)
          {
            if ((double) index2 <= Main.worldSurface)
            {
              if ((double) (index2 + num9) <= Main.worldSurface)
              {
                WorldGen.tileCounts[index3] += (num9 + 1) * 5;
              }
              else
              {
                int num10 = (int) (Main.worldSurface - (double) index2 + 1.0);
                int num11 = num9 + 1 - num10;
                WorldGen.tileCounts[index3] += num10 * 5 + num11;
              }
            }
            else
              WorldGen.tileCounts[index3] += num9 + 1;
          }
          for (; num9 > 0; --num9)
          {
            ++index2;
            Main.tile[index1, index2].CopyFrom(from);
          }
        }
      }
      WorldGen.AddUpAlignmentCounts(true);
      if (WorldFile._versionNumber >= 105)
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
      for (; index1 < 8000; ++index1)
        Main.chest[index1] = (Chest) null;
      if (WorldFile._versionNumber >= 115)
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
        if (WorldFile._versionNumber >= 190)
          npc.SetDefaults(reader.ReadInt32());
        else
          npc.SetDefaults(NPCID.FromLegacyName(reader.ReadString()));
        npc.GivenName = reader.ReadString();
        npc.position.X = reader.ReadSingle();
        npc.position.Y = reader.ReadSingle();
        npc.homeless = reader.ReadBoolean();
        npc.homeTileX = reader.ReadInt32();
        npc.homeTileY = reader.ReadInt32();
        if (WorldFile._versionNumber >= 213 && ((BitsByte) reader.ReadByte())[0])
          npc.townNpcVariationIndex = reader.ReadInt32();
        ++index;
      }
      if (WorldFile._versionNumber < 140)
        return;
      for (bool flag = reader.ReadBoolean(); flag; flag = reader.ReadBoolean())
      {
        NPC npc = Main.npc[index];
        if (WorldFile._versionNumber >= 190)
          npc.SetDefaults(reader.ReadInt32());
        else
          npc.SetDefaults(NPCID.FromLegacyName(reader.ReadString()));
        npc.position = reader.ReadVector2();
        ++index;
      }
    }

    private static void ValidateLoadNPCs(BinaryReader fileIO)
    {
      for (bool flag = fileIO.ReadBoolean(); flag; flag = fileIO.ReadBoolean())
      {
        fileIO.ReadInt32();
        fileIO.ReadString();
        double num1 = (double) fileIO.ReadSingle();
        double num2 = (double) fileIO.ReadSingle();
        fileIO.ReadBoolean();
        fileIO.ReadInt32();
        fileIO.ReadInt32();
        if (((BitsByte) fileIO.ReadByte())[0])
          fileIO.ReadInt32();
      }
      for (bool flag = fileIO.ReadBoolean(); flag; flag = fileIO.ReadBoolean())
      {
        fileIO.ReadInt32();
        double num3 = (double) fileIO.ReadSingle();
        double num4 = (double) fileIO.ReadSingle();
      }
    }

    private static int LoadFooter(BinaryReader reader) => !reader.ReadBoolean() || reader.ReadString() != Main.worldName || reader.ReadInt32() != Main.worldID ? 6 : 0;

    private static bool ValidateWorld(BinaryReader fileIO)
    {
      new Stopwatch().Start();
      try
      {
        Stream baseStream = fileIO.BaseStream;
        int num1 = fileIO.ReadInt32();
        if (num1 == 0 || num1 > 230)
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
            if (((int) num8 & 64) == 64)
            {
              int num17 = (int) fileIO.ReadByte();
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
        int num18 = (int) fileIO.ReadInt16();
        int num19 = (int) fileIO.ReadInt16();
        for (int index4 = 0; index4 < num18; ++index4)
        {
          fileIO.ReadInt32();
          fileIO.ReadInt32();
          fileIO.ReadString();
          for (int index5 = 0; index5 < num19; ++index5)
          {
            if (fileIO.ReadInt16() > (short) 0)
            {
              fileIO.ReadInt32();
              int num20 = (int) fileIO.ReadByte();
            }
          }
        }
        if (baseStream.Position != (long) positions[3])
          return false;
        int num21 = (int) fileIO.ReadInt16();
        for (int index = 0; index < num21; ++index)
        {
          fileIO.ReadString();
          fileIO.ReadInt32();
          fileIO.ReadInt32();
        }
        if (baseStream.Position != (long) positions[4])
          return false;
        WorldFile.ValidateLoadNPCs(fileIO);
        if (baseStream.Position != (long) positions[5])
          return false;
        if (WorldFile._versionNumber >= 116 && WorldFile._versionNumber <= 121)
        {
          int num22 = fileIO.ReadInt32();
          for (int index = 0; index < num22; ++index)
          {
            int num23 = (int) fileIO.ReadInt16();
            int num24 = (int) fileIO.ReadInt16();
          }
          if (baseStream.Position != (long) positions[6])
            return false;
        }
        if (WorldFile._versionNumber >= 122)
        {
          int num25 = fileIO.ReadInt32();
          for (int index = 0; index < num25; ++index)
            TileEntity.Read(fileIO);
        }
        if (WorldFile._versionNumber >= 170)
        {
          int num26 = fileIO.ReadInt32();
          for (int index = 0; index < num26; ++index)
            fileIO.ReadInt64();
        }
        if (WorldFile._versionNumber >= 189)
        {
          int num27 = fileIO.ReadInt32();
          fileIO.ReadBytes(12 * num27);
        }
        if (WorldFile._versionNumber >= 210)
          Main.BestiaryTracker.ValidateWorld(fileIO, WorldFile._versionNumber);
        if (WorldFile._versionNumber >= 220)
          CreativePowerManager.Instance.ValidateWorld(fileIO, WorldFile._versionNumber);
        int num28 = fileIO.ReadBoolean() ? 1 : 0;
        string str2 = fileIO.ReadString();
        int num29 = fileIO.ReadInt32();
        bool flag = false;
        if (num28 != 0 && (str2 == str1 || num29 == num3))
          flag = true;
        return flag;
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

    private static FileMetadata GetFileMetadata(string file, bool cloudSave)
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

    private static void FixDresserChests()
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
      lock (TileEntity.ByID)
      {
        writer.Write(TileEntity.ByID.Count);
        foreach (KeyValuePair<int, TileEntity> keyValuePair in TileEntity.ByID)
          TileEntity.Write(writer, keyValuePair.Value);
      }
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
          point16List.Add(keyValuePair.Value.Position);
        else if (!TileEntity.manager.CheckValidTile((int) keyValuePair.Value.type, (int) keyValuePair.Value.Position.X, (int) keyValuePair.Value.Position.Y))
          point16List.Add(keyValuePair.Value.Position);
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
      lock (PressurePlateHelper.PressurePlatesPressed)
      {
        writer.Write(PressurePlateHelper.PressurePlatesPressed.Count);
        foreach (KeyValuePair<Point, bool[]> keyValuePair in PressurePlateHelper.PressurePlatesPressed)
        {
          writer.Write(keyValuePair.Key.X);
          writer.Write(keyValuePair.Key.Y);
        }
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

    private static int SaveBestiary(BinaryWriter writer)
    {
      Main.BestiaryTracker.Save(writer);
      return (int) writer.BaseStream.Position;
    }

    private static void LoadBestiary(BinaryReader reader, int loadVersionNumber) => Main.BestiaryTracker.Load(reader, loadVersionNumber);

    private static void LoadBestiaryForVersionsBefore210() => Main.BestiaryTracker.FillBasedOnVersionBefore210();

    private static int SaveCreativePowers(BinaryWriter writer)
    {
      CreativePowerManager.Instance.SaveToWorld(writer);
      return (int) writer.BaseStream.Position;
    }

    private static void LoadCreativePowers(BinaryReader reader, int loadVersionNumber) => CreativePowerManager.Instance.LoadFromWorld(reader, loadVersionNumber);

    private static int LoadWorld_Version1_Old_BeforeRelease88(BinaryReader fileIO)
    {
      Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
      int versionNumber = WorldFile._versionNumber;
      if (versionNumber > 230)
        return 1;
      Main.worldName = fileIO.ReadString();
      Main.worldID = fileIO.ReadInt32();
      Main.leftWorld = (float) fileIO.ReadInt32();
      Main.rightWorld = (float) fileIO.ReadInt32();
      Main.topWorld = (float) fileIO.ReadInt32();
      Main.bottomWorld = (float) fileIO.ReadInt32();
      Main.maxTilesY = fileIO.ReadInt32();
      Main.maxTilesX = fileIO.ReadInt32();
      Main.GameMode = versionNumber < 112 ? 0 : (fileIO.ReadBoolean() ? 1 : 0);
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
      WorldFile._tempTime = fileIO.ReadDouble();
      WorldFile._tempDayTime = fileIO.ReadBoolean();
      WorldFile._tempMoonPhase = fileIO.ReadInt32();
      WorldFile._tempBloodMoon = fileIO.ReadBoolean();
      if (versionNumber >= 70)
      {
        WorldFile._tempEclipse = fileIO.ReadBoolean();
        Main.eclipse = WorldFile._tempEclipse;
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
        if (versionNumber >= 201)
          NPC.savedGolfer = fileIO.ReadBoolean();
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
        WorldFile._tempRaining = fileIO.ReadBoolean();
        WorldFile._tempRainTime = fileIO.ReadInt32();
        WorldFile._tempMaxRain = fileIO.ReadSingle();
      }
      if (versionNumber >= 54)
      {
        WorldGen.SavedOreTiers.Cobalt = fileIO.ReadInt32();
        WorldGen.SavedOreTiers.Mythril = fileIO.ReadInt32();
        WorldGen.SavedOreTiers.Adamantite = fileIO.ReadInt32();
      }
      else if (versionNumber >= 23 && WorldGen.altarCount == 0)
      {
        WorldGen.SavedOreTiers.Cobalt = -1;
        WorldGen.SavedOreTiers.Mythril = -1;
        WorldGen.SavedOreTiers.Adamantite = -1;
      }
      else
      {
        WorldGen.SavedOreTiers.Cobalt = 107;
        WorldGen.SavedOreTiers.Mythril = 108;
        WorldGen.SavedOreTiers.Adamantite = 111;
      }
      int style1 = 0;
      int style2 = 0;
      int style3 = 0;
      int style4 = 0;
      int style5 = 0;
      int style6 = 0;
      int style7 = 0;
      int style8 = 0;
      int style9 = 0;
      int style10 = 0;
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
      WorldGen.setBG(8, style9);
      WorldGen.setBG(9, style10);
      WorldGen.setBG(10, style1);
      WorldGen.setBG(11, style1);
      WorldGen.setBG(12, style1);
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
        Main.windSpeedTarget = fileIO.ReadSingle();
        Main.windSpeedCurrent = Main.windSpeedTarget;
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
            if (tile.type == (ushort) sbyte.MaxValue || tile.type == (ushort) 504)
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
              else if (versionNumber < 195 && tile.type == (ushort) 49)
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
            tile.wall = (ushort) fileIO.ReadByte();
            if (tile.wall >= (ushort) 316)
              tile.wall = (ushort) 0;
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
            if (!Main.tileSolid[(int) tile.type] && !TileID.Sets.NonSolidSaveSlopes[(int) tile.type])
              tile.halfBrick(false);
            if (versionNumber >= 49)
            {
              tile.slope(fileIO.ReadByte());
              if (!Main.tileSolid[(int) tile.type] && !TileID.Sets.NonSolidSaveSlopes[(int) tile.type])
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
      int num6 = 1000;
      for (int index5 = 0; index5 < num6; ++index5)
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
              int num7 = versionNumber < 59 ? (int) fileIO.ReadByte() : (int) fileIO.ReadInt16();
              if (num7 > 0)
              {
                if (versionNumber >= 38)
                {
                  Main.chest[index5].item[index6].netDefaults(fileIO.ReadInt32());
                }
                else
                {
                  short num8 = ItemID.FromLegacyName(fileIO.ReadString(), versionNumber);
                  Main.chest[index5].item[index6].SetDefaults((int) num8);
                }
                Main.chest[index5].item[index6].stack = num7;
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
      int num9 = fileIO.ReadBoolean() ? 1 : 0;
      string str1 = fileIO.ReadString();
      int num10 = fileIO.ReadInt32();
      return num9 != 0 && (str1 == Main.worldName || num10 == Main.worldID) ? 0 : 2;
    }
  }
}
