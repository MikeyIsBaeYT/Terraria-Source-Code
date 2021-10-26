// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PlayerEyeHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent
{
  public struct PlayerEyeHelper
  {
    private PlayerEyeHelper.EyeState _state;
    private int _timeInState;
    private const int TimeToActDamaged = 20;

    public int EyeFrameToShow { get; private set; }

    public void Update(Player player)
    {
      this.SetStateByPlayerInfo(player);
      this.UpdateEyeFrameToShow(player);
      ++this._timeInState;
    }

    private void UpdateEyeFrameToShow(Player player)
    {
      PlayerEyeHelper.EyeFrame eyeFrame1 = PlayerEyeHelper.EyeFrame.EyeOpen;
      switch (this._state)
      {
        case PlayerEyeHelper.EyeState.NormalBlinking:
          int num = this._timeInState % 240 - 234;
          eyeFrame1 = num < 4 ? (num < 2 ? (num < 0 ? PlayerEyeHelper.EyeFrame.EyeOpen : PlayerEyeHelper.EyeFrame.EyeHalfClosed) : PlayerEyeHelper.EyeFrame.EyeClosed) : PlayerEyeHelper.EyeFrame.EyeHalfClosed;
          break;
        case PlayerEyeHelper.EyeState.InStorm:
          eyeFrame1 = this._timeInState % 120 - 114 < 0 ? PlayerEyeHelper.EyeFrame.EyeHalfClosed : PlayerEyeHelper.EyeFrame.EyeClosed;
          break;
        case PlayerEyeHelper.EyeState.InBed:
          PlayerEyeHelper.EyeFrame eyeFrame2 = this.DoesPlayerCountAsModeratelyDamaged(player) ? PlayerEyeHelper.EyeFrame.EyeHalfClosed : PlayerEyeHelper.EyeFrame.EyeOpen;
          this._timeInState = player.sleeping.timeSleeping;
          eyeFrame1 = this._timeInState >= 60 ? (this._timeInState >= 120 ? PlayerEyeHelper.EyeFrame.EyeClosed : PlayerEyeHelper.EyeFrame.EyeHalfClosed) : eyeFrame2;
          break;
        case PlayerEyeHelper.EyeState.JustTookDamage:
          eyeFrame1 = PlayerEyeHelper.EyeFrame.EyeClosed;
          break;
        case PlayerEyeHelper.EyeState.IsModeratelyDamaged:
        case PlayerEyeHelper.EyeState.IsTipsy:
        case PlayerEyeHelper.EyeState.IsPoisoned:
          eyeFrame1 = this._timeInState % 120 - 100 < 0 ? PlayerEyeHelper.EyeFrame.EyeHalfClosed : PlayerEyeHelper.EyeFrame.EyeClosed;
          break;
        case PlayerEyeHelper.EyeState.IsBlind:
          eyeFrame1 = PlayerEyeHelper.EyeFrame.EyeClosed;
          break;
      }
      this.EyeFrameToShow = (int) eyeFrame1;
    }

    private void SetStateByPlayerInfo(Player player)
    {
      if (player.blackout || player.blind)
      {
        this.SwitchToState(PlayerEyeHelper.EyeState.IsBlind);
      }
      else
      {
        if (this._state == PlayerEyeHelper.EyeState.JustTookDamage && this._timeInState < 20)
          return;
        if (player.sleeping.isSleeping)
          this.SwitchToState(PlayerEyeHelper.EyeState.InBed, player.itemAnimation > 0);
        else if (this.DoesPlayerCountAsModeratelyDamaged(player))
          this.SwitchToState(PlayerEyeHelper.EyeState.IsModeratelyDamaged);
        else if (player.tipsy)
          this.SwitchToState(PlayerEyeHelper.EyeState.IsTipsy);
        else if (player.poisoned || player.venom)
        {
          this.SwitchToState(PlayerEyeHelper.EyeState.IsPoisoned);
        }
        else
        {
          bool flag = player.ZoneSandstorm || player.ZoneSnow && Main.IsItRaining;
          if (player.behindBackWall)
            flag = false;
          if (flag)
            this.SwitchToState(PlayerEyeHelper.EyeState.InStorm);
          else
            this.SwitchToState(PlayerEyeHelper.EyeState.NormalBlinking);
        }
      }
    }

    private void SwitchToState(
      PlayerEyeHelper.EyeState newState,
      bool resetStateTimerEvenIfAlreadyInState = false)
    {
      if (this._state == newState && !resetStateTimerEvenIfAlreadyInState)
        return;
      this._state = newState;
      this._timeInState = 0;
    }

    private bool DoesPlayerCountAsModeratelyDamaged(Player player) => (double) player.statLife <= (double) player.statLifeMax2 * 0.25;

    public void BlinkBecausePlayerGotHurt() => this.SwitchToState(PlayerEyeHelper.EyeState.JustTookDamage, true);

    private enum EyeFrame
    {
      EyeOpen,
      EyeHalfClosed,
      EyeClosed,
    }

    private enum EyeState
    {
      NormalBlinking,
      InStorm,
      InBed,
      JustTookDamage,
      IsModeratelyDamaged,
      IsBlind,
      IsTipsy,
      IsPoisoned,
    }
  }
}
