// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.AchievementsSocialModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Steamworks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.Social.Steam
{
  public class AchievementsSocialModule : Terraria.Social.Base.AchievementsSocialModule
  {
    private const string FILE_NAME = "/achievements-steam.dat";
    private Callback<UserStatsReceived_t> _userStatsReceived;
    private bool _areStatsReceived;
    private Dictionary<string, int> _intStatCache = new Dictionary<string, int>();
    private Dictionary<string, float> _floatStatCache = new Dictionary<string, float>();

    public override void Initialize()
    {
      // ISSUE: method pointer
      this._userStatsReceived = Callback<UserStatsReceived_t>.Create(new Callback<UserStatsReceived_t>.DispatchDelegate((object) this, __methodptr(OnUserStatsReceived)));
      SteamUserStats.RequestCurrentStats();
      while (!this._areStatsReceived)
      {
        CoreSocialModule.Pulse();
        Thread.Sleep(10);
      }
    }

    public override void Shutdown() => this.StoreStats();

    public override bool IsAchievementCompleted(string name)
    {
      bool flag;
      return SteamUserStats.GetAchievement(name, ref flag) & flag;
    }

    public override byte[] GetEncryptionKey()
    {
      byte[] numArray = new byte[16];
      byte[] bytes = BitConverter.GetBytes((ulong) SteamUser.GetSteamID().m_SteamID);
      Array.Copy((Array) bytes, (Array) numArray, 8);
      Array.Copy((Array) bytes, 0, (Array) numArray, 8, 8);
      return numArray;
    }

    public override string GetSavePath() => "/achievements-steam.dat";

    private int GetIntStat(string name)
    {
      int num;
      if (this._intStatCache.TryGetValue(name, out num) || !SteamUserStats.GetStat(name, ref num))
        return num;
      this._intStatCache.Add(name, num);
      return num;
    }

    private float GetFloatStat(string name)
    {
      float num;
      if (this._floatStatCache.TryGetValue(name, out num) || !SteamUserStats.GetStat(name, ref num))
        return num;
      this._floatStatCache.Add(name, num);
      return num;
    }

    private bool SetFloatStat(string name, float value)
    {
      this._floatStatCache[name] = value;
      return SteamUserStats.SetStat(name, value);
    }

    public override void UpdateIntStat(string name, int value)
    {
      if (this.GetIntStat(name) >= value)
        return;
      this.SetIntStat(name, value);
    }

    private bool SetIntStat(string name, int value)
    {
      this._intStatCache[name] = value;
      return SteamUserStats.SetStat(name, value);
    }

    public override void UpdateFloatStat(string name, float value)
    {
      if ((double) this.GetFloatStat(name) >= (double) value)
        return;
      this.SetFloatStat(name, value);
    }

    public override void StoreStats() => SteamUserStats.StoreStats();

    public override void CompleteAchievement(string name) => SteamUserStats.SetAchievement(name);

    private void OnUserStatsReceived(UserStatsReceived_t results)
    {
      if (results.m_nGameID != 105600L || !CSteamID.op_Equality((CSteamID) results.m_steamIDUser, SteamUser.GetSteamID()))
        return;
      this._areStatsReceived = true;
    }
  }
}
