// Decompiled with JetBrains decompiler
// Type: Terraria.IngameOptions
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria
{
  public static class IngameOptions
  {
    public const int width = 670;
    public const int height = 480;
    public static float[] leftScale = new float[9]
    {
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f
    };
    public static float[] rightScale = new float[15]
    {
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.7f
    };
    public static bool[] skipRightSlot = new bool[20];
    public static int leftHover = -1;
    public static int rightHover = -1;
    public static int oldLeftHover = -1;
    public static int oldRightHover = -1;
    public static int rightLock = -1;
    public static bool inBar = false;
    public static bool notBar = false;
    public static bool noSound = false;
    private static Rectangle _GUIHover = new Rectangle();
    public static int category = 0;
    public static Vector2 valuePosition = Vector2.Zero;
    private static string _mouseOverText;

    public static void Open()
    {
      Main.playerInventory = false;
      Main.editChest = false;
      Main.npcChatText = "";
      Main.PlaySound(10);
      Main.ingameOptionsWindow = true;
      IngameOptions.category = 0;
      for (int index = 0; index < IngameOptions.leftScale.Length; ++index)
        IngameOptions.leftScale[index] = 0.0f;
      for (int index = 0; index < IngameOptions.rightScale.Length; ++index)
        IngameOptions.rightScale[index] = 0.0f;
      IngameOptions.leftHover = -1;
      IngameOptions.rightHover = -1;
      IngameOptions.oldLeftHover = -1;
      IngameOptions.oldRightHover = -1;
      IngameOptions.rightLock = -1;
      IngameOptions.inBar = false;
      IngameOptions.notBar = false;
      IngameOptions.noSound = false;
    }

    public static void Close()
    {
      if (Main.setKey != -1)
        return;
      Main.ingameOptionsWindow = false;
      Main.PlaySound(11);
      Recipe.FindRecipes();
      Main.playerInventory = true;
      Main.SaveSettings();
    }

    public static void Draw(Main mainInstance, SpriteBatch sb)
    {
      if (Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
      {
        Main.setKey = -1;
        IngameOptions.Close();
        Main.playerInventory = false;
      }
      else
      {
        for (int index = 0; index < IngameOptions.skipRightSlot.Length; ++index)
          IngameOptions.skipRightSlot[index] = false;
        bool flag1 = GameCulture.Russian.IsActive || GameCulture.Portuguese.IsActive || GameCulture.Polish.IsActive || GameCulture.French.IsActive;
        bool isActive1 = GameCulture.Polish.IsActive;
        bool isActive2 = GameCulture.German.IsActive;
        bool flag2 = GameCulture.Italian.IsActive || GameCulture.Spanish.IsActive;
        bool flag3 = false;
        int num1 = 70;
        float scale = 0.75f;
        float num2 = 60f;
        float num3 = 300f;
        if (flag1)
          flag3 = true;
        if (isActive1)
          num3 = 200f;
        Vector2 vector2_1 = new Vector2((float) Main.mouseX, (float) Main.mouseY);
        bool flag4 = Main.mouseLeft && Main.mouseLeftRelease;
        Vector2 vector2_2 = new Vector2((float) Main.screenWidth, (float) Main.screenHeight);
        Vector2 vector2_3 = new Vector2(670f, 480f);
        Vector2 vector2_4 = vector2_2 / 2f - vector2_3 / 2f;
        int num4 = 20;
        IngameOptions._GUIHover = new Rectangle((int) ((double) vector2_4.X - (double) num4), (int) ((double) vector2_4.Y - (double) num4), (int) ((double) vector2_3.X + (double) (num4 * 2)), (int) ((double) vector2_3.Y + (double) (num4 * 2)));
        Utils.DrawInvBG(sb, vector2_4.X - (float) num4, vector2_4.Y - (float) num4, vector2_3.X + (float) (num4 * 2), vector2_3.Y + (float) (num4 * 2), new Color(33, 15, 91, (int) byte.MaxValue) * 0.685f);
        if (new Rectangle((int) vector2_4.X - num4, (int) vector2_4.Y - num4, (int) vector2_3.X + num4 * 2, (int) vector2_3.Y + num4 * 2).Contains(new Point(Main.mouseX, Main.mouseY)))
          Main.player[Main.myPlayer].mouseInterface = true;
        Utils.DrawBorderString(sb, Language.GetTextValue("GameUI.SettingsMenu"), vector2_4 + vector2_3 * new Vector2(0.5f, 0.0f), Color.White, anchorx: 0.5f);
        if (flag1)
        {
          Utils.DrawInvBG(sb, vector2_4.X + (float) (num4 / 2), vector2_4.Y + (float) (num4 * 5 / 2), vector2_3.X / 3f - (float) num4, vector2_3.Y - (float) (num4 * 3));
          Utils.DrawInvBG(sb, vector2_4.X + vector2_3.X / 3f + (float) num4, vector2_4.Y + (float) (num4 * 5 / 2), (float) ((double) vector2_3.X * 2.0 / 3.0) - (float) (num4 * 3 / 2), vector2_3.Y - (float) (num4 * 3));
        }
        else
        {
          Utils.DrawInvBG(sb, vector2_4.X + (float) (num4 / 2), vector2_4.Y + (float) (num4 * 5 / 2), vector2_3.X / 2f - (float) num4, vector2_3.Y - (float) (num4 * 3));
          Utils.DrawInvBG(sb, vector2_4.X + vector2_3.X / 2f + (float) num4, vector2_4.Y + (float) (num4 * 5 / 2), vector2_3.X / 2f - (float) (num4 * 3 / 2), vector2_3.Y - (float) (num4 * 3));
        }
        float num5 = 0.7f;
        float num6 = 0.8f;
        float num7 = 0.01f;
        if (flag1)
        {
          num5 = 0.4f;
          num6 = 0.44f;
        }
        if (isActive2)
        {
          num5 = 0.55f;
          num6 = 0.6f;
        }
        if (IngameOptions.oldLeftHover != IngameOptions.leftHover && IngameOptions.leftHover != -1)
          Main.PlaySound(12);
        if (IngameOptions.oldRightHover != IngameOptions.rightHover && IngameOptions.rightHover != -1)
          Main.PlaySound(12);
        if (flag4 && IngameOptions.rightHover != -1 && !IngameOptions.noSound)
          Main.PlaySound(12);
        IngameOptions.oldLeftHover = IngameOptions.leftHover;
        IngameOptions.oldRightHover = IngameOptions.rightHover;
        IngameOptions.noSound = false;
        bool flag5 = SocialAPI.Network != null && SocialAPI.Network.CanInvite();
        int num8 = 5 + (flag5 ? 1 : 0) + 2;
        Vector2 anchor1 = new Vector2(vector2_4.X + vector2_3.X / 4f, vector2_4.Y + (float) (num4 * 5 / 2));
        Vector2 offset1 = new Vector2(0.0f, vector2_3.Y - (float) (num4 * 5)) / (float) (num8 + 1);
        if (flag1)
          anchor1.X -= 55f;
        UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_LEFT = num8 + 1;
        for (int index = 0; index <= num8; ++index)
        {
          if (IngameOptions.leftHover == index || index == IngameOptions.category)
            IngameOptions.leftScale[index] += num7;
          else
            IngameOptions.leftScale[index] -= num7;
          if ((double) IngameOptions.leftScale[index] < (double) num5)
            IngameOptions.leftScale[index] = num5;
          if ((double) IngameOptions.leftScale[index] > (double) num6)
            IngameOptions.leftScale[index] = num6;
        }
        IngameOptions.leftHover = -1;
        int category1 = IngameOptions.category;
        int i1 = 0;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[114].Value, i1, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i1;
          if (flag4)
          {
            IngameOptions.category = 0;
            Main.PlaySound(10);
          }
        }
        int i2 = i1 + 1;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[210].Value, i2, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i2;
          if (flag4)
          {
            IngameOptions.category = 1;
            Main.PlaySound(10);
          }
        }
        int i3 = i2 + 1;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[63].Value, i3, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i3;
          if (flag4)
          {
            IngameOptions.category = 2;
            Main.PlaySound(10);
          }
        }
        int i4 = i3 + 1;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[218].Value, i4, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i4;
          if (flag4)
          {
            IngameOptions.category = 3;
            Main.PlaySound(10);
          }
        }
        int i5 = i4 + 1;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[66].Value, i5, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i5;
          if (flag4)
          {
            IngameOptions.Close();
            IngameFancyUI.OpenKeybinds();
          }
        }
        int i6 = i5 + 1;
        if (flag5 && IngameOptions.DrawLeftSide(sb, Lang.menu[147].Value, i6, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i6;
          if (flag4)
          {
            IngameOptions.Close();
            SocialAPI.Network.OpenInviteInterface();
          }
        }
        if (flag5)
          ++i6;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[131].Value, i6, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i6;
          if (flag4)
          {
            IngameOptions.Close();
            IngameFancyUI.OpenAchievements();
          }
        }
        int i7 = i6 + 1;
        if (IngameOptions.DrawLeftSide(sb, Lang.menu[118].Value, i7, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i7;
          if (flag4)
            IngameOptions.Close();
        }
        int i8 = i7 + 1;
        if (IngameOptions.DrawLeftSide(sb, Lang.inter[35].Value, i8, anchor1, offset1, IngameOptions.leftScale))
        {
          IngameOptions.leftHover = i8;
          if (flag4)
          {
            IngameOptions.Close();
            Main.menuMode = 10;
            WorldGen.SaveAndQuit();
          }
        }
        int num9 = i8 + 1;
        int category2 = IngameOptions.category;
        if (category1 != category2)
        {
          for (int index = 0; index < IngameOptions.rightScale.Length; ++index)
            IngameOptions.rightScale[index] = 0.0f;
        }
        int num10 = 0;
        switch (IngameOptions.category)
        {
          case 0:
            num10 = 15;
            num5 = 1f;
            num6 = 1.001f;
            num7 = 1f / 1000f;
            break;
          case 1:
            num10 = 6;
            num5 = 1f;
            num6 = 1.001f;
            num7 = 1f / 1000f;
            break;
          case 2:
            num10 = 12;
            num5 = 1f;
            num6 = 1.001f;
            num7 = 1f / 1000f;
            break;
          case 3:
            num10 = 15;
            num5 = 1f;
            num6 = 1.001f;
            num7 = 1f / 1000f;
            break;
        }
        if (flag1)
        {
          num5 -= 0.1f;
          num6 -= 0.1f;
        }
        if (isActive2 && IngameOptions.category == 3)
        {
          num5 -= 0.15f;
          num6 -= 0.15f;
        }
        if (flag2 && (IngameOptions.category == 0 || IngameOptions.category == 3))
        {
          num5 -= 0.2f;
          num6 -= 0.2f;
        }
        UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num10;
        Vector2 anchor2 = new Vector2(vector2_4.X + (float) ((double) vector2_3.X * 3.0 / 4.0), vector2_4.Y + (float) (num4 * 5 / 2));
        if (flag1)
          anchor2.X = vector2_4.X + (float) ((double) vector2_3.X * 2.0 / 3.0);
        Vector2 offset2 = new Vector2(0.0f, vector2_3.Y - (float) (num4 * 3)) / (float) (num10 + 1);
        if (IngameOptions.category == 2)
          offset2.Y -= 2f;
        for (int index = 0; index < 15; ++index)
        {
          if (IngameOptions.rightLock == index || IngameOptions.rightHover == index && IngameOptions.rightLock == -1)
            IngameOptions.rightScale[index] += num7;
          else
            IngameOptions.rightScale[index] -= num7;
          if ((double) IngameOptions.rightScale[index] < (double) num5)
            IngameOptions.rightScale[index] = num5;
          if ((double) IngameOptions.rightScale[index] > (double) num6)
            IngameOptions.rightScale[index] = num6;
        }
        IngameOptions.inBar = false;
        IngameOptions.rightHover = -1;
        if (!Main.mouseLeft)
          IngameOptions.rightLock = -1;
        if (IngameOptions.rightLock == -1)
          IngameOptions.notBar = false;
        if (IngameOptions.category == 0)
        {
          int i9 = 0;
          IngameOptions.DrawRightSide(sb, Lang.menu[65].Value, i9, anchor2, offset2, IngameOptions.rightScale[i9], 1f);
          IngameOptions.skipRightSlot[i9] = true;
          int i10 = i9 + 1;
          anchor2.X -= (float) num1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[99].Value + " " + (object) Math.Round((double) Main.musicVolume * 100.0) + "%", i10, anchor2, offset2, IngameOptions.rightScale[i10], (float) (((double) IngameOptions.rightScale[i10] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.noSound = true;
            IngameOptions.rightHover = i10;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          float num11 = IngameOptions.DrawValueBar(sb, scale, Main.musicVolume);
          if ((IngameOptions.inBar || IngameOptions.rightLock == i10) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i10;
            if (Main.mouseLeft && IngameOptions.rightLock == i10)
              Main.musicVolume = num11;
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i10;
          }
          if (IngameOptions.rightHover == i10)
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 2;
          int i11 = i10 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[98].Value + " " + (object) Math.Round((double) Main.soundVolume * 100.0) + "%", i11, anchor2, offset2, IngameOptions.rightScale[i11], (float) (((double) IngameOptions.rightScale[i11] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i11;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          float num12 = IngameOptions.DrawValueBar(sb, scale, Main.soundVolume);
          if ((IngameOptions.inBar || IngameOptions.rightLock == i11) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i11;
            if (Main.mouseLeft && IngameOptions.rightLock == i11)
            {
              Main.soundVolume = num12;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i11;
          }
          if (IngameOptions.rightHover == i11)
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 3;
          int i12 = i11 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[119].Value + " " + (object) Math.Round((double) Main.ambientVolume * 100.0) + "%", i12, anchor2, offset2, IngameOptions.rightScale[i12], (float) (((double) IngameOptions.rightScale[i12] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i12;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          float num13 = IngameOptions.DrawValueBar(sb, scale, Main.ambientVolume);
          if ((IngameOptions.inBar || IngameOptions.rightLock == i12) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i12;
            if (Main.mouseLeft && IngameOptions.rightLock == i12)
            {
              Main.ambientVolume = num13;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i12;
          }
          if (IngameOptions.rightHover == i12)
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 4;
          int i13 = i12 + 1;
          anchor2.X += (float) num1;
          IngameOptions.DrawRightSide(sb, "", i13, anchor2, offset2, IngameOptions.rightScale[i13], 1f);
          IngameOptions.skipRightSlot[i13] = true;
          int i14 = i13 + 1;
          IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.ZoomCategory"), i14, anchor2, offset2, IngameOptions.rightScale[i14], 1f);
          IngameOptions.skipRightSlot[i14] = true;
          int i15 = i14 + 1;
          anchor2.X -= (float) num1;
          string txt1 = Language.GetTextValue("GameUI.GameZoom", (object) Math.Round((double) Main.GameZoomTarget * 100.0), (object) Math.Round((double) Main.GameViewMatrix.Zoom.X * 100.0));
          if (flag3)
            txt1 = Main.fontItemStack.CreateWrappedText(txt1, num3, Language.ActiveCulture.CultureInfo);
          if (IngameOptions.DrawRightSide(sb, txt1, i15, anchor2, offset2, IngameOptions.rightScale[i15] * 0.85f, (float) (((double) IngameOptions.rightScale[i15] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i15;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          float num14 = IngameOptions.DrawValueBar(sb, scale, Main.GameZoomTarget - 1f);
          if ((IngameOptions.inBar || IngameOptions.rightLock == i15) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i15;
            if (Main.mouseLeft && IngameOptions.rightLock == i15)
              Main.GameZoomTarget = num14 + 1f;
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i15;
          }
          if (IngameOptions.rightHover == i15)
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 10;
          int i16 = i15 + 1;
          bool flag6 = false;
          if ((double) Main.temporaryGUIScaleSlider == -1.0)
            Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
          string txt2 = Language.GetTextValue("GameUI.UIScale", (object) Math.Round((double) Main.temporaryGUIScaleSlider * 100.0), (object) Math.Round((double) Main.UIScale * 100.0));
          if (flag3)
            txt2 = Main.fontItemStack.CreateWrappedText(txt2, num3, Language.ActiveCulture.CultureInfo);
          if (IngameOptions.DrawRightSide(sb, txt2, i16, anchor2, offset2, IngameOptions.rightScale[i16] * 0.75f, (float) (((double) IngameOptions.rightScale[i16] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i16;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          float num15 = IngameOptions.DrawValueBar(sb, scale, Main.temporaryGUIScaleSlider - 1f);
          if ((IngameOptions.inBar || IngameOptions.rightLock == i16) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i16;
            if (Main.mouseLeft && IngameOptions.rightLock == i16)
            {
              Main.temporaryGUIScaleSlider = num15 + 1f;
              Main.temporaryGUIScaleSliderUpdate = true;
              flag6 = true;
            }
          }
          if (!flag6 && Main.temporaryGUIScaleSliderUpdate && (double) Main.temporaryGUIScaleSlider != -1.0)
          {
            Main.UIScale = Main.temporaryGUIScaleSlider;
            Main.temporaryGUIScaleSliderUpdate = false;
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i16;
          }
          if (IngameOptions.rightHover == i16)
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 11;
          int i17 = i16 + 1;
          anchor2.X += (float) num1;
          IngameOptions.DrawRightSide(sb, "", i17, anchor2, offset2, IngameOptions.rightScale[i17], 1f);
          IngameOptions.skipRightSlot[i17] = true;
          int i18 = i17 + 1;
          IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.Gameplay"), i18, anchor2, offset2, IngameOptions.rightScale[i18], 1f);
          IngameOptions.skipRightSlot[i18] = true;
          int i19 = i18 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.autoSave ? Lang.menu[67].Value : Lang.menu[68].Value, i19, anchor2, offset2, IngameOptions.rightScale[i19], (float) (((double) IngameOptions.rightScale[i19] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i19;
            if (flag4)
              Main.autoSave = !Main.autoSave;
          }
          int i20 = i19 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.autoPause ? Lang.menu[69].Value : Lang.menu[70].Value, i20, anchor2, offset2, IngameOptions.rightScale[i20], (float) (((double) IngameOptions.rightScale[i20] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i20;
            if (flag4)
              Main.autoPause = !Main.autoPause;
          }
          int i21 = i20 + 1;
          if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartWallReplacement ? Lang.menu[226].Value : Lang.menu[225].Value, i21, anchor2, offset2, IngameOptions.rightScale[i21], (float) (((double) IngameOptions.rightScale[i21] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i21;
            if (flag4)
              Player.SmartCursorSettings.SmartWallReplacement = !Player.SmartCursorSettings.SmartWallReplacement;
          }
          int i22 = i21 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.ReversedUpDownArmorSetBonuses ? Lang.menu[220].Value : Lang.menu[221].Value, i22, anchor2, offset2, IngameOptions.rightScale[i22], (float) (((double) IngameOptions.rightScale[i22] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i22;
            if (flag4)
              Main.ReversedUpDownArmorSetBonuses = !Main.ReversedUpDownArmorSetBonuses;
          }
          int i23 = i22 + 1;
          IngameOptions.DrawRightSide(sb, "", i23, anchor2, offset2, IngameOptions.rightScale[i23], 1f);
          IngameOptions.skipRightSlot[i23] = true;
          int num16 = i23 + 1;
        }
        if (IngameOptions.category == 1)
        {
          int i24 = 0;
          if (IngameOptions.DrawRightSide(sb, Main.showItemText ? Lang.menu[71].Value : Lang.menu[72].Value, i24, anchor2, offset2, IngameOptions.rightScale[i24], (float) (((double) IngameOptions.rightScale[i24] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i24;
            if (flag4)
              Main.showItemText = !Main.showItemText;
          }
          int i25 = i24 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[123].Value + " " + (object) Lang.menu[124 + Main.invasionProgressMode], i25, anchor2, offset2, IngameOptions.rightScale[i25], (float) (((double) IngameOptions.rightScale[i25] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i25;
            if (flag4)
            {
              ++Main.invasionProgressMode;
              if (Main.invasionProgressMode >= 3)
                Main.invasionProgressMode = 0;
            }
          }
          int i26 = i25 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.placementPreview ? Lang.menu[128].Value : Lang.menu[129].Value, i26, anchor2, offset2, IngameOptions.rightScale[i26], (float) (((double) IngameOptions.rightScale[i26] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i26;
            if (flag4)
              Main.placementPreview = !Main.placementPreview;
          }
          int i27 = i26 + 1;
          if (IngameOptions.DrawRightSide(sb, ItemSlot.Options.HighlightNewItems ? Lang.inter[117].Value : Lang.inter[116].Value, i27, anchor2, offset2, IngameOptions.rightScale[i27], (float) (((double) IngameOptions.rightScale[i27] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i27;
            if (flag4)
              ItemSlot.Options.HighlightNewItems = !ItemSlot.Options.HighlightNewItems;
          }
          int i28 = i27 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.MouseShowBuildingGrid ? Lang.menu[229].Value : Lang.menu[230].Value, i28, anchor2, offset2, IngameOptions.rightScale[i28], (float) (((double) IngameOptions.rightScale[i28] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i28;
            if (flag4)
              Main.MouseShowBuildingGrid = !Main.MouseShowBuildingGrid;
          }
          int i29 = i28 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.GamepadDisableInstructionsDisplay ? Lang.menu[241].Value : Lang.menu[242].Value, i29, anchor2, offset2, IngameOptions.rightScale[i29], (float) (((double) IngameOptions.rightScale[i29] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i29;
            if (flag4)
              Main.GamepadDisableInstructionsDisplay = !Main.GamepadDisableInstructionsDisplay;
          }
          int num17 = i29 + 1;
        }
        if (IngameOptions.category == 2)
        {
          int i30 = 0;
          if (IngameOptions.DrawRightSide(sb, Main.graphics.IsFullScreen ? Lang.menu[49].Value : Lang.menu[50].Value, i30, anchor2, offset2, IngameOptions.rightScale[i30], (float) (((double) IngameOptions.rightScale[i30] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i30;
            if (flag4)
              Main.ToggleFullScreen();
          }
          int i31 = i30 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[51].Value + ": " + (object) Main.PendingResolutionWidth + "x" + (object) Main.PendingResolutionHeight, i31, anchor2, offset2, IngameOptions.rightScale[i31], (float) (((double) IngameOptions.rightScale[i31] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i31;
            if (flag4)
            {
              int num18 = 0;
              for (int index = 0; index < Main.numDisplayModes; ++index)
              {
                if (Main.displayWidth[index] == Main.PendingResolutionWidth && Main.displayHeight[index] == Main.PendingResolutionHeight)
                {
                  num18 = index;
                  break;
                }
              }
              int index1 = num18 + 1;
              if (index1 >= Main.numDisplayModes)
                index1 = 0;
              Main.PendingResolutionWidth = Main.displayWidth[index1];
              Main.PendingResolutionHeight = Main.displayHeight[index1];
            }
          }
          int i32 = i31 + 1;
          anchor2.X -= (float) num1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[52].Value + ": " + (object) Main.bgScroll + "%", i32, anchor2, offset2, IngameOptions.rightScale[i32], (float) (((double) IngameOptions.rightScale[i32] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.noSound = true;
            IngameOptions.rightHover = i32;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          float num19 = IngameOptions.DrawValueBar(sb, scale, (float) Main.bgScroll / 100f);
          if ((IngameOptions.inBar || IngameOptions.rightLock == i32) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i32;
            if (Main.mouseLeft && IngameOptions.rightLock == i32)
            {
              Main.bgScroll = (int) ((double) num19 * 100.0);
              Main.caveParallax = (float) (1.0 - (double) Main.bgScroll / 500.0);
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i32;
          }
          if (IngameOptions.rightHover == i32)
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 1;
          int i33 = i32 + 1;
          anchor2.X += (float) num1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[247 + Main.FrameSkipMode].Value, i33, anchor2, offset2, IngameOptions.rightScale[i33], (float) (((double) IngameOptions.rightScale[i33] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i33;
            if (flag4)
            {
              ++Main.FrameSkipMode;
              if (Main.FrameSkipMode < 0 || Main.FrameSkipMode > 2)
                Main.FrameSkipMode = 0;
            }
          }
          int i34 = i33 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[55 + Lighting.lightMode].Value, i34, anchor2, offset2, IngameOptions.rightScale[i34], (float) (((double) IngameOptions.rightScale[i34] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i34;
            if (flag4)
              Lighting.NextLightMode();
          }
          int i35 = i34 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[116].Value + " " + (Lighting.LightingThreads > 0 ? string.Concat((object) (Lighting.LightingThreads + 1)) : Lang.menu[117].Value), i35, anchor2, offset2, IngameOptions.rightScale[i35], (float) (((double) IngameOptions.rightScale[i35] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i35;
            if (flag4)
            {
              ++Lighting.LightingThreads;
              if (Lighting.LightingThreads > Environment.ProcessorCount - 1)
                Lighting.LightingThreads = 0;
            }
          }
          int i36 = i35 + 1;
          if (IngameOptions.DrawRightSide(sb, Lang.menu[59 + Main.qaStyle].Value, i36, anchor2, offset2, IngameOptions.rightScale[i36], (float) (((double) IngameOptions.rightScale[i36] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i36;
            if (flag4)
            {
              ++Main.qaStyle;
              if (Main.qaStyle > 3)
                Main.qaStyle = 0;
            }
          }
          int i37 = i36 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.BackgroundEnabled ? Lang.menu[100].Value : Lang.menu[101].Value, i37, anchor2, offset2, IngameOptions.rightScale[i37], (float) (((double) IngameOptions.rightScale[i37] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i37;
            if (flag4)
              Main.BackgroundEnabled = !Main.BackgroundEnabled;
          }
          int i38 = i37 + 1;
          if (IngameOptions.DrawRightSide(sb, ChildSafety.Disabled ? Lang.menu[132].Value : Lang.menu[133].Value, i38, anchor2, offset2, IngameOptions.rightScale[i38], (float) (((double) IngameOptions.rightScale[i38] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i38;
            if (flag4)
              ChildSafety.Disabled = !ChildSafety.Disabled;
          }
          int i39 = i38 + 1;
          if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.HeatDistortion", Main.UseHeatDistortion ? (object) Language.GetTextValue("GameUI.Enabled") : (object) Language.GetTextValue("GameUI.Disabled")), i39, anchor2, offset2, IngameOptions.rightScale[i39], (float) (((double) IngameOptions.rightScale[i39] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i39;
            if (flag4)
              Main.UseHeatDistortion = !Main.UseHeatDistortion;
          }
          int i40 = i39 + 1;
          if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.StormEffects", Main.UseStormEffects ? (object) Language.GetTextValue("GameUI.Enabled") : (object) Language.GetTextValue("GameUI.Disabled")), i40, anchor2, offset2, IngameOptions.rightScale[i40], (float) (((double) IngameOptions.rightScale[i40] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i40;
            if (flag4)
              Main.UseStormEffects = !Main.UseStormEffects;
          }
          int i41 = i40 + 1;
          string textValue;
          switch (Main.WaveQuality)
          {
            case 1:
              textValue = Language.GetTextValue("GameUI.QualityLow");
              break;
            case 2:
              textValue = Language.GetTextValue("GameUI.QualityMedium");
              break;
            case 3:
              textValue = Language.GetTextValue("GameUI.QualityHigh");
              break;
            default:
              textValue = Language.GetTextValue("GameUI.QualityOff");
              break;
          }
          if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.WaveQuality", (object) textValue), i41, anchor2, offset2, IngameOptions.rightScale[i41], (float) (((double) IngameOptions.rightScale[i41] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i41;
            if (flag4)
              Main.WaveQuality = (Main.WaveQuality + 1) % 4;
          }
          int num20 = i41 + 1;
        }
        if (IngameOptions.category == 3)
        {
          int i42 = 0;
          float num21 = (float) num1;
          if (flag1)
            num2 = 126f;
          Vector3 hslVector = Main.mouseColorSlider.GetHSLVector();
          Main.mouseColorSlider.ApplyToMainLegacyBars();
          IngameOptions.DrawRightSide(sb, Lang.menu[64].Value, i42, anchor2, offset2, IngameOptions.rightScale[i42], 1f);
          IngameOptions.skipRightSlot[i42] = true;
          int i43 = i42 + 1;
          anchor2.X -= num21;
          if (IngameOptions.DrawRightSide(sb, "", i43, anchor2, offset2, IngameOptions.rightScale[i43], (float) (((double) IngameOptions.rightScale[i43] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i43;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          float num22 = IngameOptions.DrawValueBar(sb, scale, hslVector.X, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_H));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i43) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i43;
            if (Main.mouseLeft && IngameOptions.rightLock == i43)
            {
              hslVector.X = num22;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i43;
          }
          if (IngameOptions.rightHover == i43)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
            Main.menuMode = 25;
          }
          int i44 = i43 + 1;
          if (IngameOptions.DrawRightSide(sb, "", i44, anchor2, offset2, IngameOptions.rightScale[i44], (float) (((double) IngameOptions.rightScale[i44] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i44;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          float num23 = IngameOptions.DrawValueBar(sb, scale, hslVector.Y, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_S));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i44) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i44;
            if (Main.mouseLeft && IngameOptions.rightLock == i44)
            {
              hslVector.Y = num23;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i44;
          }
          if (IngameOptions.rightHover == i44)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
            Main.menuMode = 25;
          }
          int i45 = i44 + 1;
          if (IngameOptions.DrawRightSide(sb, "", i45, anchor2, offset2, IngameOptions.rightScale[i45], (float) (((double) IngameOptions.rightScale[i45] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i45;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          DelegateMethods.v3_1.Z = Utils.InverseLerp(0.15f, 1f, DelegateMethods.v3_1.Z, true);
          float num24 = IngameOptions.DrawValueBar(sb, scale, DelegateMethods.v3_1.Z, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_L));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i45) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i45;
            if (Main.mouseLeft && IngameOptions.rightLock == i45)
            {
              hslVector.Z = (float) ((double) num24 * 0.850000023841858 + 0.150000005960464);
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i45;
          }
          if (IngameOptions.rightHover == i45)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
            Main.menuMode = 25;
          }
          int i46 = i45 + 1;
          if ((double) hslVector.Z < 0.150000005960464)
            hslVector.Z = 0.15f;
          Main.mouseColorSlider.SetHSL(hslVector);
          Main.mouseColor = Main.mouseColorSlider.GetColor();
          anchor2.X += num21;
          IngameOptions.DrawRightSide(sb, "", i46, anchor2, offset2, IngameOptions.rightScale[i46], 1f);
          IngameOptions.skipRightSlot[i46] = true;
          int i47 = i46 + 1;
          hslVector = Main.mouseBorderColorSlider.GetHSLVector();
          if (PlayerInput.UsingGamepad && IngameOptions.rightHover == -1)
            Main.mouseBorderColorSlider.ApplyToMainLegacyBars();
          IngameOptions.DrawRightSide(sb, Lang.menu[217].Value, i47, anchor2, offset2, IngameOptions.rightScale[i47], 1f);
          IngameOptions.skipRightSlot[i47] = true;
          int i48 = i47 + 1;
          anchor2.X -= num21;
          if (IngameOptions.DrawRightSide(sb, "", i48, anchor2, offset2, IngameOptions.rightScale[i48], (float) (((double) IngameOptions.rightScale[i48] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i48;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          float num25 = IngameOptions.DrawValueBar(sb, scale, hslVector.X, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_H));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i48) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i48;
            if (Main.mouseLeft && IngameOptions.rightLock == i48)
            {
              hslVector.X = num25;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i48;
          }
          if (IngameOptions.rightHover == i48)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
            Main.menuMode = 252;
          }
          int i49 = i48 + 1;
          if (IngameOptions.DrawRightSide(sb, "", i49, anchor2, offset2, IngameOptions.rightScale[i49], (float) (((double) IngameOptions.rightScale[i49] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i49;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          float num26 = IngameOptions.DrawValueBar(sb, scale, hslVector.Y, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_S));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i49) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i49;
            if (Main.mouseLeft && IngameOptions.rightLock == i49)
            {
              hslVector.Y = num26;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i49;
          }
          if (IngameOptions.rightHover == i49)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
            Main.menuMode = 252;
          }
          int i50 = i49 + 1;
          if (IngameOptions.DrawRightSide(sb, "", i50, anchor2, offset2, IngameOptions.rightScale[i50], (float) (((double) IngameOptions.rightScale[i50] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i50;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          float num27 = IngameOptions.DrawValueBar(sb, scale, hslVector.Z, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_L));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i50) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i50;
            if (Main.mouseLeft && IngameOptions.rightLock == i50)
            {
              hslVector.Z = num27;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i50;
          }
          if (IngameOptions.rightHover == i50)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
            Main.menuMode = 252;
          }
          int i51 = i50 + 1;
          if (IngameOptions.DrawRightSide(sb, "", i51, anchor2, offset2, IngameOptions.rightScale[i51], (float) (((double) IngameOptions.rightScale[i51] - (double) num5) / ((double) num6 - (double) num5))))
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i51;
          }
          IngameOptions.valuePosition.X = (float) ((double) vector2_4.X + (double) vector2_3.X - (double) (num4 / 2) - 20.0);
          IngameOptions.valuePosition.Y -= 3f;
          IngameOptions.valuePosition.X -= num2;
          DelegateMethods.v3_1 = hslVector;
          float perc = Main.mouseBorderColorSlider.Alpha;
          float num28 = IngameOptions.DrawValueBar(sb, scale, perc, colorMethod: new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_O));
          if ((IngameOptions.inBar || IngameOptions.rightLock == i51) && !IngameOptions.notBar)
          {
            IngameOptions.rightHover = i51;
            if (Main.mouseLeft && IngameOptions.rightLock == i51)
            {
              perc = num28;
              IngameOptions.noSound = true;
            }
          }
          if ((double) Main.mouseX > (double) vector2_4.X + (double) vector2_3.X * 2.0 / 3.0 + (double) num4 && (double) Main.mouseX < (double) IngameOptions.valuePosition.X + 3.75 && (double) Main.mouseY > (double) IngameOptions.valuePosition.Y - 10.0 && (double) Main.mouseY <= (double) IngameOptions.valuePosition.Y + 10.0)
          {
            if (IngameOptions.rightLock == -1)
              IngameOptions.notBar = true;
            IngameOptions.rightHover = i51;
          }
          if (IngameOptions.rightHover == i51)
          {
            UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 8;
            Main.menuMode = 252;
          }
          int i52 = i51 + 1;
          Main.mouseBorderColorSlider.SetHSL(hslVector);
          Main.mouseBorderColorSlider.Alpha = perc;
          Main.MouseBorderColor = Main.mouseBorderColorSlider.GetColor();
          anchor2.X += num21;
          IngameOptions.DrawRightSide(sb, "", i52, anchor2, offset2, IngameOptions.rightScale[i52], 1f);
          IngameOptions.skipRightSlot[i52] = true;
          int i53 = i52 + 1;
          string txt = "";
          switch (LockOnHelper.UseMode)
          {
            case LockOnHelper.LockOnMode.FocusTarget:
              txt = Lang.menu[232].Value;
              break;
            case LockOnHelper.LockOnMode.TargetClosest:
              txt = Lang.menu[233].Value;
              break;
            case LockOnHelper.LockOnMode.ThreeDS:
              txt = Lang.menu[234].Value;
              break;
          }
          if (IngameOptions.DrawRightSide(sb, txt, i53, anchor2, offset2, IngameOptions.rightScale[i53] * 0.9f, (float) (((double) IngameOptions.rightScale[i53] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i53;
            if (flag4)
              LockOnHelper.CycleUseModes();
          }
          int i54 = i53 + 1;
          if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartBlocksEnabled ? Lang.menu[215].Value : Lang.menu[216].Value, i54, anchor2, offset2, IngameOptions.rightScale[i54] * 0.9f, (float) (((double) IngameOptions.rightScale[i54] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i54;
            if (flag4)
              Player.SmartCursorSettings.SmartBlocksEnabled = !Player.SmartCursorSettings.SmartBlocksEnabled;
          }
          int i55 = i54 + 1;
          if (IngameOptions.DrawRightSide(sb, Main.cSmartCursorToggle ? Lang.menu[121].Value : Lang.menu[122].Value, i55, anchor2, offset2, IngameOptions.rightScale[i55], (float) (((double) IngameOptions.rightScale[i55] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i55;
            if (flag4)
              Main.cSmartCursorToggle = !Main.cSmartCursorToggle;
          }
          int i56 = i55 + 1;
          if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartAxeAfterPickaxe ? Lang.menu[214].Value : Lang.menu[213].Value, i56, anchor2, offset2, IngameOptions.rightScale[i56] * 0.9f, (float) (((double) IngameOptions.rightScale[i56] - (double) num5) / ((double) num6 - (double) num5))))
          {
            IngameOptions.rightHover = i56;
            if (flag4)
              Player.SmartCursorSettings.SmartAxeAfterPickaxe = !Player.SmartCursorSettings.SmartAxeAfterPickaxe;
          }
          int num29 = i56 + 1;
        }
        if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
          IngameOptions.rightLock = IngameOptions.rightHover;
        for (int index = 0; index < num8 + 1; ++index)
          UILinkPointNavigator.SetPosition(2900 + index, anchor1 + offset1 * (float) (index + 1));
        int num30 = 0;
        Vector2 zero = Vector2.Zero;
        if (flag1)
          zero.X = -40f;
        for (int index = 0; index < num10; ++index)
        {
          if (!IngameOptions.skipRightSlot[index])
          {
            UILinkPointNavigator.SetPosition(2930 + num30, anchor2 + zero + offset2 * (float) (index + 1));
            ++num30;
          }
        }
        UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num30;
        Main.DrawGamepadInstructions();
        Main.mouseText = false;
        Main.instance.GUIBarsDraw();
        Main.instance.DrawMouseOver();
        Main.DrawCursor(Main.DrawThickCursor());
      }
    }

    public static void MouseOver()
    {
      if (!Main.ingameOptionsWindow)
        return;
      if (IngameOptions._GUIHover.Contains(Main.MouseScreen.ToPoint()))
        Main.mouseText = true;
      if (IngameOptions._mouseOverText != null)
        Main.instance.MouseText(IngameOptions._mouseOverText);
      IngameOptions._mouseOverText = (string) null;
    }

    public static bool DrawLeftSide(
      SpriteBatch sb,
      string txt,
      int i,
      Vector2 anchor,
      Vector2 offset,
      float[] scales,
      float minscale = 0.7f,
      float maxscale = 0.8f,
      float scalespeed = 0.01f)
    {
      int num = i == IngameOptions.category ? 1 : 0;
      Color color = Color.Lerp(Color.Gray, Color.White, (float) (((double) scales[i] - (double) minscale) / ((double) maxscale - (double) minscale)));
      if (num != 0)
        color = Color.Gold;
      Vector2 vector2 = Utils.DrawBorderStringBig(sb, txt, anchor + offset * (float) (1 + i), color, scales[i], 0.5f, 0.5f);
      return new Rectangle((int) anchor.X - (int) vector2.X / 2, (int) anchor.Y + (int) ((double) offset.Y * (double) (1 + i)) - (int) vector2.Y / 2, (int) vector2.X, (int) vector2.Y).Contains(new Point(Main.mouseX, Main.mouseY));
    }

    public static bool DrawRightSide(
      SpriteBatch sb,
      string txt,
      int i,
      Vector2 anchor,
      Vector2 offset,
      float scale,
      float colorScale,
      Color over = default (Color))
    {
      Color color = Color.Lerp(Color.Gray, Color.White, colorScale);
      if (over != new Color())
        color = over;
      Vector2 vector2 = Utils.DrawBorderString(sb, txt, anchor + offset * (float) (1 + i), color, scale, 0.5f, 0.5f);
      IngameOptions.valuePosition = anchor + offset * (float) (1 + i) + vector2 * new Vector2(0.5f, 0.0f);
      return new Rectangle((int) anchor.X - (int) vector2.X / 2, (int) anchor.Y + (int) ((double) offset.Y * (double) (1 + i)) - (int) vector2.Y / 2, (int) vector2.X, (int) vector2.Y).Contains(new Point(Main.mouseX, Main.mouseY));
    }

    public static bool DrawValue(SpriteBatch sb, string txt, int i, float scale, Color over = default (Color))
    {
      Color color = Color.Gray;
      Vector2 vector2 = Main.fontMouseText.MeasureString(txt) * scale;
      int num = new Rectangle((int) IngameOptions.valuePosition.X, (int) IngameOptions.valuePosition.Y - (int) vector2.Y / 2, (int) vector2.X, (int) vector2.Y).Contains(new Point(Main.mouseX, Main.mouseY)) ? 1 : 0;
      if (num != 0)
        color = Color.White;
      if (over != new Color())
        color = over;
      Utils.DrawBorderString(sb, txt, IngameOptions.valuePosition, color, scale, anchory: 0.5f);
      IngameOptions.valuePosition.X += vector2.X;
      return num != 0;
    }

    public static float DrawValueBar(
      SpriteBatch sb,
      float scale,
      float perc,
      int lockState = 0,
      Utils.ColorLerpMethod colorMethod = null)
    {
      if (colorMethod == null)
        colorMethod = new Utils.ColorLerpMethod(Utils.ColorLerp_BlackToWhite);
      Texture2D colorBarTexture = Main.colorBarTexture;
      Vector2 vector2 = new Vector2((float) colorBarTexture.Width, (float) colorBarTexture.Height) * scale;
      IngameOptions.valuePosition.X -= (float) (int) vector2.X;
      Rectangle destinationRectangle1 = new Rectangle((int) IngameOptions.valuePosition.X, (int) IngameOptions.valuePosition.Y - (int) vector2.Y / 2, (int) vector2.X, (int) vector2.Y);
      Rectangle destinationRectangle2 = destinationRectangle1;
      sb.Draw(colorBarTexture, destinationRectangle1, Color.White);
      int num1 = 167;
      float num2 = (float) destinationRectangle1.X + 5f * scale;
      float y = (float) destinationRectangle1.Y + 4f * scale;
      for (float num3 = 0.0f; (double) num3 < (double) num1; ++num3)
      {
        float percent = num3 / (float) num1;
        sb.Draw(Main.colorBlipTexture, new Vector2(num2 + num3 * scale, y), new Rectangle?(), colorMethod(percent), 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
      }
      destinationRectangle1.X = (int) num2;
      destinationRectangle1.Y = (int) y;
      bool flag = destinationRectangle1.Contains(new Point(Main.mouseX, Main.mouseY));
      if (lockState == 2)
        flag = false;
      if (flag || lockState == 1)
        sb.Draw(Main.colorHighlightTexture, destinationRectangle2, Main.OurFavoriteColor);
      sb.Draw(Main.colorSliderTexture, new Vector2(num2 + 167f * scale * perc, y + 4f * scale), new Rectangle?(), Color.White, 0.0f, new Vector2(0.5f * (float) Main.colorSliderTexture.Width, 0.5f * (float) Main.colorSliderTexture.Height), scale, SpriteEffects.None, 0.0f);
      if (Main.mouseX >= destinationRectangle1.X && Main.mouseX <= destinationRectangle1.X + destinationRectangle1.Width)
      {
        IngameOptions.inBar = flag;
        return (float) (Main.mouseX - destinationRectangle1.X) / (float) destinationRectangle1.Width;
      }
      IngameOptions.inBar = false;
      return destinationRectangle1.X >= Main.mouseX ? 0.0f : 1f;
    }
  }
}
