// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.OverlaySocialModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Steamworks;

namespace Terraria.Social.Steam
{
  public class OverlaySocialModule : Terraria.Social.Base.OverlaySocialModule
  {
    private Callback<GamepadTextInputDismissed_t> _gamepadTextInputDismissed;
    private bool _gamepadTextInputActive;

    public override void Initialize() => this._gamepadTextInputDismissed = Callback<GamepadTextInputDismissed_t>.Create(new Callback<GamepadTextInputDismissed_t>.DispatchDelegate((object) this, __methodptr(OnGamepadTextInputDismissed)));

    public override void Shutdown()
    {
    }

    public override bool IsGamepadTextInputActive() => this._gamepadTextInputActive;

    public override bool ShowGamepadTextInput(
      string description,
      uint maxLength,
      bool multiLine = false,
      string existingText = "",
      bool password = false)
    {
      if (this._gamepadTextInputActive)
        return false;
      int num = SteamUtils.ShowGamepadTextInput(password ? (EGamepadTextInputMode) 1 : (EGamepadTextInputMode) 0, multiLine ? (EGamepadTextInputLineMode) 1 : (EGamepadTextInputLineMode) 0, description, maxLength, existingText) ? 1 : 0;
      if (num == 0)
        return num != 0;
      this._gamepadTextInputActive = true;
      return num != 0;
    }

    public override string GetGamepadText()
    {
      uint gamepadTextLength = SteamUtils.GetEnteredGamepadTextLength();
      string str;
      SteamUtils.GetEnteredGamepadTextInput(ref str, gamepadTextLength);
      return str;
    }

    private void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t result) => this._gamepadTextInputActive = false;
  }
}
