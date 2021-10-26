// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.AchievementsSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;
using System;
using System.Threading;

namespace Terraria.Social.WeGame
{
  public class AchievementsSocialModule : Terraria.Social.Base.AchievementsSocialModule
  {
    private const string FILE_NAME = "/achievements-wegame.dat";
    private bool _areStatsReceived;
    private bool _areAchievementReceived;
    private RailCallBackHelper _callbackHelper = new RailCallBackHelper();
    private IRailPlayerAchievement _playerAchievement;
    private IRailPlayerStats _playerStats;

    public override void Initialize()
    {
      // ISSUE: method pointer
      this._callbackHelper.RegisterCallback((RAILEventID) 2001, new RailEventCallBackHandler((object) this, __methodptr(RailEventCallBack)));
      // ISSUE: method pointer
      this._callbackHelper.RegisterCallback((RAILEventID) 2101, new RailEventCallBackHandler((object) this, __methodptr(RailEventCallBack)));
      IRailPlayerStats myPlayerStats = this.GetMyPlayerStats();
      IRailPlayerAchievement playerAchievement = this.GetMyPlayerAchievement();
      if (myPlayerStats == null || playerAchievement == null)
        return;
      myPlayerStats.AsyncRequestStats("");
      playerAchievement.AsyncRequestAchievement("");
      while (!this._areStatsReceived && !this._areAchievementReceived)
      {
        CoreSocialModule.RailEventTick();
        Thread.Sleep(10);
      }
    }

    public override void Shutdown() => this.StoreStats();

    private IRailPlayerStats GetMyPlayerStats()
    {
      if (this._playerStats == null)
      {
        IRailStatisticHelper irailStatisticHelper = rail_api.RailFactory().RailStatisticHelper();
        if (irailStatisticHelper != null)
        {
          RailID railId = new RailID();
          ((RailComparableID) railId).id_ = (__Null) 0L;
          this._playerStats = irailStatisticHelper.CreatePlayerStats(railId);
        }
      }
      return this._playerStats;
    }

    private IRailPlayerAchievement GetMyPlayerAchievement()
    {
      if (this._playerAchievement == null)
      {
        IRailAchievementHelper achievementHelper = rail_api.RailFactory().RailAchievementHelper();
        if (achievementHelper != null)
        {
          RailID railId = new RailID();
          ((RailComparableID) railId).id_ = (__Null) 0L;
          this._playerAchievement = achievementHelper.CreatePlayerAchievement(railId);
        }
      }
      return this._playerAchievement;
    }

    public void RailEventCallBack(RAILEventID eventId, EventBase data)
    {
      if (eventId != 2001)
      {
        if (eventId != 2101)
          return;
        this._areAchievementReceived = true;
      }
      else
        this._areStatsReceived = true;
    }

    public override bool IsAchievementCompleted(string name)
    {
      bool flag = false;
      RailResult railResult = (RailResult) 1;
      IRailPlayerAchievement playerAchievement = this.GetMyPlayerAchievement();
      if (playerAchievement != null)
        railResult = playerAchievement.HasAchieved(name, ref flag);
      return flag && railResult == 0;
    }

    public override byte[] GetEncryptionKey()
    {
      RailID railId = rail_api.RailFactory().RailPlayer().GetRailID();
      byte[] numArray = new byte[16];
      byte[] bytes = BitConverter.GetBytes((ulong) ((RailComparableID) railId).id_);
      Array.Copy((Array) bytes, (Array) numArray, 8);
      Array.Copy((Array) bytes, 0, (Array) numArray, 8, 8);
      return numArray;
    }

    public override string GetSavePath() => "/achievements-wegame.dat";

    private int GetIntStat(string name)
    {
      int num = 0;
      this.GetMyPlayerStats()?.GetStatValue(name, ref num);
      return num;
    }

    private float GetFloatStat(string name)
    {
      double num = 0.0;
      this.GetMyPlayerStats()?.GetStatValue(name, ref num);
      return (float) num;
    }

    private bool SetFloatStat(string name, float value)
    {
      IRailPlayerStats myPlayerStats = this.GetMyPlayerStats();
      RailResult railResult = (RailResult) 1;
      if (myPlayerStats != null)
        railResult = myPlayerStats.SetStatValue(name, (double) value);
      return railResult == 0;
    }

    public override void UpdateIntStat(string name, int value)
    {
      IRailPlayerStats myPlayerStats = this.GetMyPlayerStats();
      if (myPlayerStats == null)
        return;
      int num = 0;
      if (myPlayerStats.GetStatValue(name, ref num) != null || num >= value)
        return;
      myPlayerStats.SetStatValue(name, value);
    }

    private bool SetIntStat(string name, int value)
    {
      IRailPlayerStats myPlayerStats = this.GetMyPlayerStats();
      RailResult railResult = (RailResult) 1;
      if (myPlayerStats != null)
        railResult = myPlayerStats.SetStatValue(name, value);
      return railResult == 0;
    }

    public override void UpdateFloatStat(string name, float value)
    {
      IRailPlayerStats myPlayerStats = this.GetMyPlayerStats();
      if (myPlayerStats == null)
        return;
      double num = 0.0;
      if (myPlayerStats.GetStatValue(name, ref num) != null || num >= (double) value)
        return;
      myPlayerStats.SetStatValue(name, (double) value);
    }

    public override void StoreStats()
    {
      this.SaveStats();
      this.SaveAchievement();
    }

    private void SaveStats() => this.GetMyPlayerStats()?.AsyncStoreStats("");

    private void SaveAchievement() => this.GetMyPlayerAchievement()?.AsyncStoreAchievement("");

    public override void CompleteAchievement(string name) => this.GetMyPlayerAchievement()?.MakeAchievement(name);
  }
}
