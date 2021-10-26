// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.OverlaySocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Social.WeGame
{
  public class OverlaySocialModule : Terraria.Social.Base.OverlaySocialModule
  {
    private bool _gamepadTextInputActive;

    public override void Initialize()
    {
    }

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
      return false;
    }

    public override string GetGamepadText() => "";
  }
}
