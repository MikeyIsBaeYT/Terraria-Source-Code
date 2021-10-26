// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativePowerManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using System.IO;
using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.GameContent.Creative
{
  public class CreativePowerManager
  {
    public static readonly CreativePowerManager Instance = new CreativePowerManager();
    private Dictionary<ushort, ICreativePower> _powersById = new Dictionary<ushort, ICreativePower>();
    private Dictionary<string, ICreativePower> _powersByName = new Dictionary<string, ICreativePower>();
    private ushort _powersCount;
    private static bool _initialized = false;
    private const string _powerPermissionsLineHeader = "journeypermission_";

    private CreativePowerManager()
    {
    }

    public void Register<T>(string nameInServerConfig) where T : ICreativePower, new()
    {
      T obj = new T();
      CreativePowerManager.PowerTypeStorage<T>.Power = obj;
      CreativePowerManager.PowerTypeStorage<T>.Id = this._powersCount;
      CreativePowerManager.PowerTypeStorage<T>.Name = nameInServerConfig;
      obj.DefaultPermissionLevel = PowerPermissionLevel.CanBeChangedByEveryone;
      obj.CurrentPermissionLevel = PowerPermissionLevel.CanBeChangedByEveryone;
      this._powersById[this._powersCount] = (ICreativePower) obj;
      this._powersByName[nameInServerConfig] = (ICreativePower) obj;
      obj.PowerId = this._powersCount;
      obj.ServerConfigName = nameInServerConfig;
      ++this._powersCount;
    }

    public T GetPower<T>() where T : ICreativePower => CreativePowerManager.PowerTypeStorage<T>.Power;

    public ushort GetPowerId<T>() where T : ICreativePower => CreativePowerManager.PowerTypeStorage<T>.Id;

    public bool TryGetPower(ushort id, out ICreativePower power) => this._powersById.TryGetValue(id, out power);

    public static void TryListingPermissionsFrom(string line)
    {
      int length = "journeypermission_".Length;
      if (line.Length < length || !line.ToLower().StartsWith("journeypermission_"))
        return;
      string[] strArray = line.Substring(length).Split('=');
      int result;
      if (strArray.Length != 2 || !int.TryParse(strArray[1].Trim(), out result))
        return;
      PowerPermissionLevel powerPermissionLevel = (PowerPermissionLevel) Utils.Clamp<int>(result, 0, 2);
      string lower = strArray[0].Trim().ToLower();
      CreativePowerManager.Initialize();
      ICreativePower creativePower;
      if (!CreativePowerManager.Instance._powersByName.TryGetValue(lower, out creativePower))
        return;
      creativePower.DefaultPermissionLevel = powerPermissionLevel;
      creativePower.CurrentPermissionLevel = powerPermissionLevel;
    }

    public static void Initialize()
    {
      if (CreativePowerManager._initialized)
        return;
      CreativePowerManager.Instance.Register<CreativePowers.FreezeTime>("time_setfrozen");
      CreativePowerManager.Instance.Register<CreativePowers.StartDayImmediately>("time_setdawn");
      CreativePowerManager.Instance.Register<CreativePowers.StartNoonImmediately>("time_setnoon");
      CreativePowerManager.Instance.Register<CreativePowers.StartNightImmediately>("time_setdusk");
      CreativePowerManager.Instance.Register<CreativePowers.StartMidnightImmediately>("time_setmidnight");
      CreativePowerManager.Instance.Register<CreativePowers.GodmodePower>("godmode");
      CreativePowerManager.Instance.Register<CreativePowers.ModifyWindDirectionAndStrength>("wind_setstrength");
      CreativePowerManager.Instance.Register<CreativePowers.ModifyRainPower>("rain_setstrength");
      CreativePowerManager.Instance.Register<CreativePowers.ModifyTimeRate>("time_setspeed");
      CreativePowerManager.Instance.Register<CreativePowers.FreezeRainPower>("rain_setfrozen");
      CreativePowerManager.Instance.Register<CreativePowers.FreezeWindDirectionAndStrength>("wind_setfrozen");
      CreativePowerManager.Instance.Register<CreativePowers.FarPlacementRangePower>("increaseplacementrange");
      CreativePowerManager.Instance.Register<CreativePowers.DifficultySliderPower>("setdifficulty");
      CreativePowerManager.Instance.Register<CreativePowers.StopBiomeSpreadPower>("biomespread_setfrozen");
      CreativePowerManager.Instance.Register<CreativePowers.SpawnRateSliderPerPlayerPower>("setspawnrate");
      CreativePowerManager._initialized = true;
    }

    public void Reset()
    {
      foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
      {
        keyValuePair.Value.CurrentPermissionLevel = keyValuePair.Value.DefaultPermissionLevel;
        if (keyValuePair.Value is IPersistentPerWorldContent persistentPerWorldContent2)
          persistentPerWorldContent2.Reset();
        if (keyValuePair.Value is IPersistentPerPlayerContent perPlayerContent2)
          perPlayerContent2.Reset();
      }
    }

    public void SaveToWorld(BinaryWriter writer)
    {
      lock (this._powersById)
      {
        foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
        {
          if (keyValuePair.Value is IPersistentPerWorldContent persistentPerWorldContent2)
          {
            writer.Write(true);
            writer.Write(keyValuePair.Key);
            persistentPerWorldContent2.Save(writer);
          }
        }
      }
      writer.Write(false);
    }

    public void LoadFromWorld(BinaryReader reader, int versionGameWasLastSavedOn)
    {
      ICreativePower creativePower;
      while (reader.ReadBoolean() && this._powersById.TryGetValue(reader.ReadUInt16(), out creativePower) && creativePower is IPersistentPerWorldContent persistentPerWorldContent)
        persistentPerWorldContent.Load(reader, versionGameWasLastSavedOn);
    }

    public void ValidateWorld(BinaryReader reader, int versionGameWasLastSavedOn)
    {
      ICreativePower creativePower;
      while (reader.ReadBoolean() && this._powersById.TryGetValue(reader.ReadUInt16(), out creativePower) && creativePower is IPersistentPerWorldContent persistentPerWorldContent)
        persistentPerWorldContent.ValidateWorld(reader, versionGameWasLastSavedOn);
    }

    public void SyncThingsToJoiningPlayer(int playerIndex)
    {
      foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
      {
        NetPacket packet = NetCreativePowerPermissionsModule.SerializeCurrentPowerPermissionLevel(keyValuePair.Key, (int) keyValuePair.Value.CurrentPermissionLevel);
        NetManager.Instance.SendToClient(packet, playerIndex);
      }
      foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
      {
        if (keyValuePair.Value is IOnPlayerJoining onPlayerJoining1)
          onPlayerJoining1.OnPlayerJoining(playerIndex);
      }
    }

    public void SaveToPlayer(Player player, BinaryWriter writer)
    {
      foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
      {
        if (keyValuePair.Value is IPersistentPerPlayerContent perPlayerContent1)
        {
          writer.Write(true);
          writer.Write(keyValuePair.Key);
          perPlayerContent1.Save(player, writer);
        }
      }
      writer.Write(false);
    }

    public void LoadToPlayer(Player player, BinaryReader reader, int versionGameWasLastSavedOn)
    {
      ICreativePower creativePower;
      while (reader.ReadBoolean() && this._powersById.TryGetValue(reader.ReadUInt16(), out creativePower))
      {
        if (creativePower is IPersistentPerPlayerContent perPlayerContent2)
          perPlayerContent2.Load(player, reader, versionGameWasLastSavedOn);
      }
    }

    public void ApplyLoadedDataToPlayer(Player player)
    {
      foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
      {
        if (keyValuePair.Value is IPersistentPerPlayerContent perPlayerContent1)
          perPlayerContent1.ApplyLoadedDataToOutOfPlayerFields(player);
      }
    }

    public void ResetDataForNewPlayer(Player player)
    {
      foreach (KeyValuePair<ushort, ICreativePower> keyValuePair in this._powersById)
      {
        if (keyValuePair.Value is IPersistentPerPlayerContent perPlayerContent1)
        {
          perPlayerContent1.Reset();
          perPlayerContent1.ResetDataForNewPlayer(player);
        }
      }
    }

    private class PowerTypeStorage<T> where T : ICreativePower
    {
      public static ushort Id;
      public static string Name;
      public static T Power;
    }
  }
}
