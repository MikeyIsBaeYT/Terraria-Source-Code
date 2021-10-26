// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.CoreSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.OS;
using Steamworks;
using System;
using System.Threading;
using System.Windows.Forms;
using Terraria.Localization;

namespace Terraria.Social.Steam
{
  public class CoreSocialModule : ISocialModule
  {
    private static CoreSocialModule _instance;
    public const int SteamAppId = 105600;
    private bool IsSteamValid;
    private object _steamTickLock = new object();
    private object _steamCallbackLock = new object();
    private Callback<GameOverlayActivated_t> _onOverlayActivated;

    public static event Action OnTick;

    public void Initialize()
    {
      CoreSocialModule._instance = this;
      if (SteamAPI.RestartAppIfNecessary(new AppId_t(105600U)))
      {
        Environment.Exit(1);
      }
      else
      {
        if (!SteamAPI.Init())
        {
          int num = (int) MessageBox.Show(Language.GetTextValue("Error.LaunchFromSteam"), Language.GetTextValue("Error.Error"));
          Environment.Exit(1);
        }
        this.IsSteamValid = true;
        new Thread(new ParameterizedThreadStart(this.SteamCallbackLoop))
        {
          IsBackground = true
        }.Start();
        new Thread(new ParameterizedThreadStart(this.SteamTickLoop))
        {
          IsBackground = true
        }.Start();
        Main.OnTickForThirdPartySoftwareOnly += new Action(this.PulseSteamTick);
        Main.OnTickForThirdPartySoftwareOnly += new Action(this.PulseSteamCallback);
        if (!Platform.IsOSX)
          return;
        // ISSUE: method pointer
        this._onOverlayActivated = Callback<GameOverlayActivated_t>.Create(new Callback<GameOverlayActivated_t>.DispatchDelegate((object) this, __methodptr(OnOverlayActivated)));
      }
    }

    public void PulseSteamTick()
    {
      if (!Monitor.TryEnter(this._steamTickLock))
        return;
      Monitor.Pulse(this._steamTickLock);
      Monitor.Exit(this._steamTickLock);
    }

    public void PulseSteamCallback()
    {
      if (!Monitor.TryEnter(this._steamCallbackLock))
        return;
      Monitor.Pulse(this._steamCallbackLock);
      Monitor.Exit(this._steamCallbackLock);
    }

    public static void Pulse()
    {
      CoreSocialModule._instance.PulseSteamTick();
      CoreSocialModule._instance.PulseSteamCallback();
    }

    private void SteamTickLoop(object context)
    {
      Monitor.Enter(this._steamTickLock);
      while (this.IsSteamValid)
      {
        if (CoreSocialModule.OnTick != null)
          CoreSocialModule.OnTick();
        Monitor.Wait(this._steamTickLock);
      }
      Monitor.Exit(this._steamTickLock);
    }

    private void SteamCallbackLoop(object context)
    {
      Monitor.Enter(this._steamCallbackLock);
      while (this.IsSteamValid)
      {
        SteamAPI.RunCallbacks();
        Monitor.Wait(this._steamCallbackLock);
      }
      Monitor.Exit(this._steamCallbackLock);
      SteamAPI.Shutdown();
    }

    public void Shutdown() => Application.ApplicationExit += (EventHandler) ((obj, evt) => this.IsSteamValid = false);

    public void OnOverlayActivated(GameOverlayActivated_t result) => Main.instance.IsMouseVisible = result.m_bActive == 1;
  }
}
