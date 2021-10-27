// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.OverlaySocialModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Social.Base
{
  public abstract class OverlaySocialModule : ISocialModule
  {
    public abstract void Initialize();

    public abstract void Shutdown();

    public abstract bool IsGamepadTextInputActive();

    public abstract bool ShowGamepadTextInput(
      string description,
      uint maxLength,
      bool multiLine = false,
      string existingText = "",
      bool password = false);

    public abstract string GetGamepadText();
  }
}
