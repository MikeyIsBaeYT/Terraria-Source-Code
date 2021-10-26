// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.RichPresenceState
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using Terraria.GameContent.UI.States;

namespace Terraria.Social.Base
{
  public class RichPresenceState : IEquatable<RichPresenceState>
  {
    public RichPresenceState.GameModeState GameMode;

    public bool Equals(RichPresenceState other) => this.GameMode == other.GameMode;

    public static RichPresenceState GetCurrentState()
    {
      RichPresenceState richPresenceState = new RichPresenceState();
      if (Main.gameMenu)
      {
        int num = Main.MenuUI.CurrentState is UICharacterCreation ? 1 : 0;
        bool flag = Main.MenuUI.CurrentState is UIWorldCreation;
        richPresenceState.GameMode = num == 0 ? (!flag ? RichPresenceState.GameModeState.InMainMenu : RichPresenceState.GameModeState.CreatingWorld) : RichPresenceState.GameModeState.CreatingPlayer;
      }
      else
        richPresenceState.GameMode = Main.netMode != 0 ? RichPresenceState.GameModeState.PlayingMulti : RichPresenceState.GameModeState.PlayingSingle;
      return richPresenceState;
    }

    public enum GameModeState
    {
      InMainMenu,
      CreatingPlayer,
      CreatingWorld,
      PlayingSingle,
      PlayingMulti,
    }
  }
}
