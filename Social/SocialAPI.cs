// Decompiled with JetBrains decompiler
// Type: Terraria.Social.SocialAPI
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.Social.Base;
using Terraria.Social.WeGame;

namespace Terraria.Social
{
  public static class SocialAPI
  {
    private static SocialMode _mode;
    public static Terraria.Social.Base.FriendsSocialModule Friends;
    public static Terraria.Social.Base.AchievementsSocialModule Achievements;
    public static Terraria.Social.Base.CloudSocialModule Cloud;
    public static Terraria.Social.Base.NetSocialModule Network;
    public static Terraria.Social.Base.OverlaySocialModule Overlay;
    public static ServerJoinRequestsManager JoinRequests;
    private static List<ISocialModule> _modules;

    public static SocialMode Mode => SocialAPI._mode;

    public static void Initialize(SocialMode? mode = null)
    {
      if (!mode.HasValue)
      {
        mode = new SocialMode?(SocialMode.None);
        mode = new SocialMode?(SocialMode.Steam);
      }
      SocialAPI._mode = mode.Value;
      SocialAPI._modules = new List<ISocialModule>();
      SocialAPI.JoinRequests = new ServerJoinRequestsManager();
      Main.OnTickForInternalCodeOnly += new Action(SocialAPI.JoinRequests.Update);
      switch (SocialAPI.Mode)
      {
        case SocialMode.Steam:
          SocialAPI.LoadSteam();
          break;
        case SocialMode.WeGame:
          SocialAPI.LoadWeGame();
          break;
      }
      foreach (ISocialModule module in SocialAPI._modules)
        module.Initialize();
    }

    public static void Shutdown()
    {
      SocialAPI._modules.Reverse();
      foreach (ISocialModule module in SocialAPI._modules)
        module.Shutdown();
    }

    private static T LoadModule<T>() where T : ISocialModule, new()
    {
      T obj = new T();
      SocialAPI._modules.Add((ISocialModule) obj);
      return obj;
    }

    private static T LoadModule<T>(T module) where T : ISocialModule
    {
      SocialAPI._modules.Add((ISocialModule) module);
      return module;
    }

    private static void LoadDiscord()
    {
    }

    private static void LoadSteam()
    {
      SocialAPI.LoadModule<Terraria.Social.Steam.CoreSocialModule>();
      SocialAPI.Friends = (Terraria.Social.Base.FriendsSocialModule) SocialAPI.LoadModule<Terraria.Social.Steam.FriendsSocialModule>();
      SocialAPI.Achievements = (Terraria.Social.Base.AchievementsSocialModule) SocialAPI.LoadModule<Terraria.Social.Steam.AchievementsSocialModule>();
      SocialAPI.Cloud = (Terraria.Social.Base.CloudSocialModule) SocialAPI.LoadModule<Terraria.Social.Steam.CloudSocialModule>();
      SocialAPI.Overlay = (Terraria.Social.Base.OverlaySocialModule) SocialAPI.LoadModule<Terraria.Social.Steam.OverlaySocialModule>();
      SocialAPI.Network = (Terraria.Social.Base.NetSocialModule) SocialAPI.LoadModule<Terraria.Social.Steam.NetClientSocialModule>();
      WeGameHelper.WriteDebugString("LoadSteam modules");
    }

    private static void LoadWeGame()
    {
      SocialAPI.LoadModule<Terraria.Social.WeGame.CoreSocialModule>();
      SocialAPI.Cloud = (Terraria.Social.Base.CloudSocialModule) SocialAPI.LoadModule<Terraria.Social.WeGame.CloudSocialModule>();
      SocialAPI.Friends = (Terraria.Social.Base.FriendsSocialModule) SocialAPI.LoadModule<Terraria.Social.WeGame.FriendsSocialModule>();
      SocialAPI.Overlay = (Terraria.Social.Base.OverlaySocialModule) SocialAPI.LoadModule<Terraria.Social.WeGame.OverlaySocialModule>();
      SocialAPI.Network = (Terraria.Social.Base.NetSocialModule) SocialAPI.LoadModule<Terraria.Social.WeGame.NetClientSocialModule>();
      WeGameHelper.WriteDebugString("LoadWeGame modules");
    }
  }
}
