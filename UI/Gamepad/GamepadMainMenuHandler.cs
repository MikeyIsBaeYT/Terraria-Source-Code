// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Gamepad.GamepadMainMenuHandler
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameInput;

namespace Terraria.UI.Gamepad
{
  public class GamepadMainMenuHandler
  {
    public static int LastMainMenu = -1;
    public static List<Vector2> MenuItemPositions = new List<Vector2>(20);
    public static int LastDrew = -1;
    public static bool CanRun = false;

    public static void Update()
    {
      if (!GamepadMainMenuHandler.CanRun)
      {
        UILinkPage page = UILinkPointNavigator.Pages[1000];
        page.CurrentPoint = page.DefaultPoint;
        Vector2 vector2 = new Vector2((float) Math.Cos((double) Main.GlobalTimeWrappedHourly * 6.28318548202515), (float) Math.Sin((double) Main.GlobalTimeWrappedHourly * 6.28318548202515 * 2.0)) * new Vector2(30f, 15f) + Vector2.UnitY * 20f;
        UILinkPointNavigator.SetPosition(2000, new Vector2((float) Main.screenWidth, (float) Main.screenHeight) / 2f + vector2);
      }
      else
      {
        if (!Main.gameMenu || Main.MenuUI.IsVisible || GamepadMainMenuHandler.LastDrew != Main.menuMode)
          return;
        int lastMainMenu = GamepadMainMenuHandler.LastMainMenu;
        GamepadMainMenuHandler.LastMainMenu = Main.menuMode;
        switch (Main.menuMode)
        {
          case 17:
          case 18:
          case 19:
          case 21:
          case 22:
          case 23:
          case 24:
          case 26:
            if (GamepadMainMenuHandler.MenuItemPositions.Count >= 4)
            {
              Vector2 menuItemPosition = GamepadMainMenuHandler.MenuItemPositions[3];
              GamepadMainMenuHandler.MenuItemPositions.RemoveAt(3);
              if (Main.menuMode == 17)
              {
                GamepadMainMenuHandler.MenuItemPositions.Insert(0, menuItemPosition);
                break;
              }
              break;
            }
            break;
          case 28:
            if (GamepadMainMenuHandler.MenuItemPositions.Count >= 3)
            {
              GamepadMainMenuHandler.MenuItemPositions.RemoveAt(1);
              break;
            }
            break;
        }
        UILinkPage page = UILinkPointNavigator.Pages[1000];
        if (lastMainMenu != Main.menuMode)
          page.CurrentPoint = page.DefaultPoint;
        for (int index = 0; index < GamepadMainMenuHandler.MenuItemPositions.Count; ++index)
        {
          Vector2 vector2 = GamepadMainMenuHandler.MenuItemPositions[index] * Main.UIScale;
          if (index == 0 && lastMainMenu != GamepadMainMenuHandler.LastMainMenu && PlayerInput.UsingGamepad && Main.InvisibleCursorForGamepad)
          {
            Main.mouseX = PlayerInput.MouseX = (int) vector2.X;
            Main.mouseY = PlayerInput.MouseY = (int) vector2.Y;
            Main.menuFocus = -1;
          }
          UILinkPoint link = page.LinkMap[2000 + index];
          link.Position = vector2;
          link.Up = index != 0 ? 2000 + index - 1 : -1;
          link.Left = -3;
          link.Right = -4;
          link.Down = index != GamepadMainMenuHandler.MenuItemPositions.Count - 1 ? 2000 + index + 1 : -2;
        }
        GamepadMainMenuHandler.MenuItemPositions.Clear();
      }
    }
  }
}
