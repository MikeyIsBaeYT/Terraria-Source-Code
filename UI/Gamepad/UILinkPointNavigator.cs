// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Gamepad.UILinkPointNavigator
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameInput;

namespace Terraria.UI.Gamepad
{
  public class UILinkPointNavigator
  {
    public static Dictionary<int, UILinkPage> Pages = new Dictionary<int, UILinkPage>();
    public static Dictionary<int, UILinkPoint> Points = new Dictionary<int, UILinkPoint>();
    public static int CurrentPage = 1000;
    public static int OldPage = 1000;
    private static int XCooldown = 0;
    private static int YCooldown = 0;
    private static Vector2 LastInput;
    private static int PageLeftCD = 0;
    private static int PageRightCD = 0;
    public static bool InUse;
    public static int OverridePoint = -1;

    public static int CurrentPoint => UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].CurrentPoint;

    public static bool Available => Main.playerInventory || Main.ingameOptionsWindow || Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1 || Main.mapFullscreen || Main.clothesWindow || Main.MenuUI.IsVisible || Main.InGameUI.IsVisible;

    public static void GoToDefaultPage(int specialFlag = 0)
    {
      if (Main.MenuUI.IsVisible)
        UILinkPointNavigator.CurrentPage = 1004;
      else if (Main.InGameUI.IsVisible || specialFlag == 1)
        UILinkPointNavigator.CurrentPage = 1004;
      else if (Main.gameMenu)
        UILinkPointNavigator.CurrentPage = 1000;
      else if (Main.ingameOptionsWindow)
        UILinkPointNavigator.CurrentPage = 1001;
      else if (Main.hairWindow)
        UILinkPointNavigator.CurrentPage = 12;
      else if (Main.clothesWindow)
        UILinkPointNavigator.CurrentPage = 15;
      else if (Main.npcShop != 0)
        UILinkPointNavigator.CurrentPage = 13;
      else if (Main.InGuideCraftMenu)
        UILinkPointNavigator.CurrentPage = 9;
      else if (Main.InReforgeMenu)
        UILinkPointNavigator.CurrentPage = 5;
      else if (Main.player[Main.myPlayer].chest != -1)
        UILinkPointNavigator.CurrentPage = 4;
      else if (Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1)
        UILinkPointNavigator.CurrentPage = 1003;
      else
        UILinkPointNavigator.CurrentPage = 0;
    }

    public static void Update()
    {
      bool inUse = UILinkPointNavigator.InUse;
      UILinkPointNavigator.InUse = false;
      bool flag1 = true;
      if (flag1)
      {
        switch (PlayerInput.CurrentInputMode)
        {
          case InputMode.Keyboard:
          case InputMode.KeyboardUI:
          case InputMode.Mouse:
            if (!Main.gameMenu)
            {
              flag1 = false;
              break;
            }
            break;
        }
      }
      if (flag1 && PlayerInput.NavigatorRebindingLock > 0)
        flag1 = false;
      if (flag1 && !Main.gameMenu && !PlayerInput.UsingGamepadUI)
        flag1 = false;
      if (flag1 && !Main.gameMenu && PlayerInput.InBuildingMode)
        flag1 = false;
      if (flag1 && !Main.gameMenu && !UILinkPointNavigator.Available)
        flag1 = false;
      bool flag2 = false;
      UILinkPage uiLinkPage;
      if (!UILinkPointNavigator.Pages.TryGetValue(UILinkPointNavigator.CurrentPage, out uiLinkPage))
        flag2 = true;
      else if (!uiLinkPage.IsValid())
        flag2 = true;
      if (flag2)
      {
        UILinkPointNavigator.GoToDefaultPage();
        UILinkPointNavigator.ProcessChanges();
        flag1 = false;
      }
      if (inUse != flag1)
      {
        if (!flag1)
        {
          uiLinkPage.Leave();
          UILinkPointNavigator.GoToDefaultPage();
          UILinkPointNavigator.ProcessChanges();
        }
        else
        {
          UILinkPointNavigator.GoToDefaultPage();
          UILinkPointNavigator.ProcessChanges();
          uiLinkPage.Enter();
        }
        if (flag1)
        {
          Main.player[Main.myPlayer].releaseInventory = false;
          Main.player[Main.myPlayer].releaseUseTile = false;
          PlayerInput.LockTileUseButton = true;
        }
        if (!Main.gameMenu)
        {
          if (flag1)
            PlayerInput.NavigatorCachePosition();
          else
            PlayerInput.NavigatorUnCachePosition();
        }
      }
      if (!flag1)
        return;
      UILinkPointNavigator.InUse = true;
      UILinkPointNavigator.OverridePoint = -1;
      if (UILinkPointNavigator.PageLeftCD > 0)
        --UILinkPointNavigator.PageLeftCD;
      if (UILinkPointNavigator.PageRightCD > 0)
        --UILinkPointNavigator.PageRightCD;
      Vector2 navigatorDirections = PlayerInput.Triggers.Current.GetNavigatorDirections();
      bool flag3 = PlayerInput.Triggers.Current.HotbarMinus && !PlayerInput.Triggers.Current.HotbarPlus;
      int num1 = !PlayerInput.Triggers.Current.HotbarPlus ? 0 : (!PlayerInput.Triggers.Current.HotbarMinus ? 1 : 0);
      if (!flag3)
        UILinkPointNavigator.PageLeftCD = 0;
      if (num1 == 0)
        UILinkPointNavigator.PageRightCD = 0;
      bool flag4 = flag3 && UILinkPointNavigator.PageLeftCD == 0;
      int num2 = num1 == 0 ? 0 : (UILinkPointNavigator.PageRightCD == 0 ? 1 : 0);
      if ((double) UILinkPointNavigator.LastInput.X != (double) navigatorDirections.X)
        UILinkPointNavigator.XCooldown = 0;
      if ((double) UILinkPointNavigator.LastInput.Y != (double) navigatorDirections.Y)
        UILinkPointNavigator.YCooldown = 0;
      if (UILinkPointNavigator.XCooldown > 0)
        --UILinkPointNavigator.XCooldown;
      if (UILinkPointNavigator.YCooldown > 0)
        --UILinkPointNavigator.YCooldown;
      UILinkPointNavigator.LastInput = navigatorDirections;
      if (flag4)
        UILinkPointNavigator.PageLeftCD = 16;
      if (num2 != 0)
        UILinkPointNavigator.PageRightCD = 16;
      UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].Update();
      int num3 = 10;
      if (!Main.gameMenu && Main.playerInventory && !Main.ingameOptionsWindow && !Main.inFancyUI && (UILinkPointNavigator.CurrentPage == 0 || UILinkPointNavigator.CurrentPage == 4 || UILinkPointNavigator.CurrentPage == 2 || UILinkPointNavigator.CurrentPage == 1))
        num3 = PlayerInput.CurrentProfile.InventoryMoveCD;
      if ((double) navigatorDirections.X == -1.0 && UILinkPointNavigator.XCooldown == 0)
      {
        UILinkPointNavigator.XCooldown = num3;
        UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelLeft();
      }
      if ((double) navigatorDirections.X == 1.0 && UILinkPointNavigator.XCooldown == 0)
      {
        UILinkPointNavigator.XCooldown = num3;
        UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelRight();
      }
      if ((double) navigatorDirections.Y == -1.0 && UILinkPointNavigator.YCooldown == 0)
      {
        UILinkPointNavigator.YCooldown = num3;
        UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelUp();
      }
      if ((double) navigatorDirections.Y == 1.0 && UILinkPointNavigator.YCooldown == 0)
      {
        UILinkPointNavigator.YCooldown = num3;
        UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelDown();
      }
      UILinkPointNavigator.XCooldown = UILinkPointNavigator.YCooldown = Math.Max(UILinkPointNavigator.XCooldown, UILinkPointNavigator.YCooldown);
      if (flag4)
        UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].SwapPageLeft();
      if (num2 != 0)
        UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].SwapPageRight();
      if (PlayerInput.Triggers.Current.UsedMovementKey)
      {
        Vector2 position = UILinkPointNavigator.Points[UILinkPointNavigator.CurrentPoint].Position;
        Vector2 vector2_1 = new Vector2((float) PlayerInput.MouseX, (float) PlayerInput.MouseY);
        float num4 = 0.3f;
        if (PlayerInput.InvisibleGamepadInMenus)
          num4 = 1f;
        Vector2 vector2_2 = position;
        double num5 = (double) num4;
        Vector2 vector2_3 = Vector2.Lerp(vector2_1, vector2_2, (float) num5);
        if (Main.gameMenu)
        {
          if ((double) Math.Abs(vector2_3.X - position.X) <= 5.0)
            vector2_3.X = position.X;
          if ((double) Math.Abs(vector2_3.Y - position.Y) <= 5.0)
            vector2_3.Y = position.Y;
        }
        PlayerInput.MouseX = (int) vector2_3.X;
        PlayerInput.MouseY = (int) vector2_3.Y;
      }
      UILinkPointNavigator.ResetFlagsEnd();
    }

    public static void ResetFlagsEnd()
    {
      UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 0;
      UILinkPointNavigator.Shortcuts.BackButtonLock = false;
      UILinkPointNavigator.Shortcuts.BackButtonCommand = 0;
    }

    public static string GetInstructions()
    {
      string str1 = UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].SpecialInteractions();
      string str2 = UILinkPointNavigator.Points[UILinkPointNavigator.CurrentPoint].SpecialInteractions();
      if (!string.IsNullOrEmpty(str2))
      {
        if (string.IsNullOrEmpty(str1))
          return str2;
        str1 = str1 + "   " + str2;
      }
      return str1;
    }

    public static void SetPosition(int ID, Vector2 Position) => UILinkPointNavigator.Points[ID].Position = Position * Main.UIScale;

    public static void RegisterPage(UILinkPage page, int ID, bool automatedDefault = true)
    {
      if (automatedDefault)
        page.DefaultPoint = page.LinkMap.Keys.First<int>();
      page.CurrentPoint = page.DefaultPoint;
      page.ID = ID;
      UILinkPointNavigator.Pages.Add(page.ID, page);
      foreach (KeyValuePair<int, UILinkPoint> link in page.LinkMap)
      {
        link.Value.SetPage(ID);
        UILinkPointNavigator.Points.Add(link.Key, link.Value);
      }
    }

    public static void ChangePage(int PageID)
    {
      if (!UILinkPointNavigator.Pages.ContainsKey(PageID) || !UILinkPointNavigator.Pages[PageID].CanEnter())
        return;
      UILinkPointNavigator.CurrentPage = PageID;
      UILinkPointNavigator.ProcessChanges();
    }

    public static void ChangePoint(int PointID)
    {
      if (!UILinkPointNavigator.Points.ContainsKey(PointID))
        return;
      UILinkPointNavigator.CurrentPage = UILinkPointNavigator.Points[PointID].Page;
      UILinkPointNavigator.OverridePoint = PointID;
      UILinkPointNavigator.ProcessChanges();
    }

    public static void ProcessChanges()
    {
      UILinkPage page = UILinkPointNavigator.Pages[UILinkPointNavigator.OldPage];
      if (UILinkPointNavigator.OldPage != UILinkPointNavigator.CurrentPage)
      {
        page.Leave();
        if (!UILinkPointNavigator.Pages.TryGetValue(UILinkPointNavigator.CurrentPage, out page))
        {
          UILinkPointNavigator.GoToDefaultPage();
          UILinkPointNavigator.ProcessChanges();
          UILinkPointNavigator.OverridePoint = -1;
        }
        page.CurrentPoint = page.DefaultPoint;
        page.Enter();
        page.Update();
        UILinkPointNavigator.OldPage = UILinkPointNavigator.CurrentPage;
      }
      if (UILinkPointNavigator.OverridePoint == -1 || !page.LinkMap.ContainsKey(UILinkPointNavigator.OverridePoint))
        return;
      page.CurrentPoint = UILinkPointNavigator.OverridePoint;
    }

    public static class Shortcuts
    {
      public static int NPCS_IconsPerColumn = 100;
      public static int NPCS_IconsTotal = 0;
      public static int NPCS_LastHovered = -1;
      public static bool NPCS_IconsDisplay = false;
      public static int CRAFT_IconsPerRow = 100;
      public static int CRAFT_IconsPerColumn = 100;
      public static int CRAFT_CurrentIngridientsCount = 0;
      public static int CRAFT_CurrentRecipeBig = 0;
      public static int CRAFT_CurrentRecipeSmall = 0;
      public static bool NPCCHAT_ButtonsLeft = false;
      public static bool NPCCHAT_ButtonsMiddle = false;
      public static bool NPCCHAT_ButtonsRight = false;
      public static int INGAMEOPTIONS_BUTTONS_LEFT = 0;
      public static int INGAMEOPTIONS_BUTTONS_RIGHT = 0;
      public static int OPTIONS_BUTTON_SPECIALFEATURE = 0;
      public static int BackButtonCommand = 0;
      public static bool BackButtonInUse = false;
      public static bool BackButtonLock = false;
      public static int FANCYUI_HIGHEST_INDEX = 1;
      public static int FANCYUI_SPECIAL_INSTRUCTIONS = 0;
      public static int INFOACCCOUNT = 0;
      public static int BUILDERACCCOUNT = 0;
      public static int BUFFS_PER_COLUMN = 0;
      public static int BUFFS_DRAWN = 0;
      public static int INV_MOVE_OPTION_CD = 0;
    }
  }
}
