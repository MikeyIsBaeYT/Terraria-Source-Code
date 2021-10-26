// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Capture.CaptureInterface
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.UI.Chat;

namespace Terraria.Graphics.Capture
{
  public class CaptureInterface
  {
    private static Dictionary<int, CaptureInterface.CaptureInterfaceMode> Modes = CaptureInterface.FillModes();
    public bool Active;
    public static bool JustActivated;
    private const Keys KeyToggleActive = Keys.F1;
    private bool KeyToggleActiveHeld;
    public int SelectedMode;
    public int HoveredMode;
    public static bool EdgeAPinned;
    public static bool EdgeBPinned;
    public static Point EdgeA;
    public static Point EdgeB;
    public static bool CameraLock;
    private static float CameraFrame;
    private static float CameraWaiting;
    private const float CameraMaxFrame = 5f;
    private const float CameraMaxWait = 60f;
    private static CaptureSettings CameraSettings;

    private static Dictionary<int, CaptureInterface.CaptureInterfaceMode> FillModes() => new Dictionary<int, CaptureInterface.CaptureInterfaceMode>()
    {
      {
        0,
        (CaptureInterface.CaptureInterfaceMode) new CaptureInterface.ModeEdgeSelection()
      },
      {
        1,
        (CaptureInterface.CaptureInterfaceMode) new CaptureInterface.ModeDragBounds()
      },
      {
        2,
        (CaptureInterface.CaptureInterfaceMode) new CaptureInterface.ModeChangeSettings()
      }
    };

    public static Rectangle GetArea()
    {
      int x = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
      int num1 = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
      int num2 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
      int num3 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
      int y = num1;
      int width = num2 + 1;
      int height = num3 + 1;
      return new Rectangle(x, y, width, height);
    }

    public void Update()
    {
      PlayerInput.SetZoom_UI();
      this.UpdateCamera();
      if (CaptureInterface.CameraLock)
        return;
      bool flag = Main.keyState.IsKeyDown(Keys.F1);
      if (flag && !this.KeyToggleActiveHeld && (Main.mouseItem.type == 0 || this.Active) && !Main.CaptureModeDisabled && !Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
        this.ToggleCamera(!this.Active);
      this.KeyToggleActiveHeld = flag;
      if (!this.Active)
        return;
      Main.blockMouse = true;
      if (CaptureInterface.JustActivated && Main.mouseLeftRelease && !Main.mouseLeft)
        CaptureInterface.JustActivated = false;
      if (this.UpdateButtons(new Vector2((float) Main.mouseX, (float) Main.mouseY)) && Main.mouseLeft)
        return;
      foreach (KeyValuePair<int, CaptureInterface.CaptureInterfaceMode> mode in CaptureInterface.Modes)
      {
        mode.Value.Selected = mode.Key == this.SelectedMode;
        mode.Value.Update();
      }
      PlayerInput.SetZoom_Unscaled();
    }

    public void Draw(SpriteBatch sb)
    {
      if (!this.Active)
        return;
      sb.End();
      sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.UIScaleMatrix);
      PlayerInput.SetZoom_UI();
      foreach (CaptureInterface.CaptureInterfaceMode captureInterfaceMode in CaptureInterface.Modes.Values)
        captureInterfaceMode.Draw(sb);
      sb.End();
      sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.UIScaleMatrix);
      PlayerInput.SetZoom_UI();
      Main.mouseText = false;
      Main.instance.GUIBarsDraw();
      this.DrawButtons(sb);
      Main.instance.DrawMouseOver();
      Utils.DrawBorderStringBig(sb, Lang.inter[81].Value, new Vector2((float) Main.screenWidth * 0.5f, 100f), Color.White, anchorx: 0.5f, anchory: 0.5f);
      Utils.DrawCursorSingle(sb, Main.cursorColor, scale: Main.cursorScale);
      this.DrawCameraLock(sb);
      sb.End();
      sb.Begin();
    }

    public void ToggleCamera(bool On = true)
    {
      if (CaptureInterface.CameraLock)
        return;
      bool active = this.Active;
      this.Active = CaptureInterface.Modes.ContainsKey(this.SelectedMode) & On;
      if (active != this.Active)
        SoundEngine.PlaySound(On ? 10 : 11);
      foreach (KeyValuePair<int, CaptureInterface.CaptureInterfaceMode> mode in CaptureInterface.Modes)
        mode.Value.ToggleActive(this.Active && mode.Key == this.SelectedMode);
      if (!On || active)
        return;
      CaptureInterface.JustActivated = true;
    }

    private bool UpdateButtons(Vector2 mouse)
    {
      this.HoveredMode = -1;
      bool flag1 = !Main.graphics.IsFullScreen;
      int num1 = 9;
      for (int index = 0; index < num1; ++index)
      {
        if (new Rectangle(24 + 46 * index, 24, 42, 42).Contains(mouse.ToPoint()))
        {
          this.HoveredMode = index;
          bool flag2 = Main.mouseLeft && Main.mouseLeftRelease;
          int num2 = 0;
          int num3 = index;
          int num4 = num2;
          int num5 = num4 + 1;
          if (num3 == num4 && flag2)
            CaptureInterface.QuickScreenshot();
          int num6 = index;
          int num7 = num5;
          int num8 = num7 + 1;
          if (num6 == num7 && flag2 && CaptureInterface.EdgeAPinned && CaptureInterface.EdgeBPinned)
            CaptureInterface.StartCamera(new CaptureSettings()
            {
              Area = CaptureInterface.GetArea(),
              Biome = CaptureBiome.GetCaptureBiome(CaptureInterface.Settings.BiomeChoiceIndex),
              CaptureBackground = !CaptureInterface.Settings.TransparentBackground,
              CaptureEntities = CaptureInterface.Settings.IncludeEntities,
              UseScaling = CaptureInterface.Settings.PackImage,
              CaptureMech = WiresUI.Settings.DrawWires
            });
          int num9 = index;
          int num10 = num8;
          int num11 = num10 + 1;
          if (num9 == num10 && flag2 && this.SelectedMode != 0)
          {
            SoundEngine.PlaySound(12);
            this.SelectedMode = 0;
            this.ToggleCamera();
          }
          int num12 = index;
          int num13 = num11;
          int num14 = num13 + 1;
          if (num12 == num13 && flag2 && this.SelectedMode != 1)
          {
            SoundEngine.PlaySound(12);
            this.SelectedMode = 1;
            this.ToggleCamera();
          }
          int num15 = index;
          int num16 = num14;
          int num17 = num16 + 1;
          if (num15 == num16 && flag2)
          {
            SoundEngine.PlaySound(12);
            CaptureInterface.ResetFocus();
          }
          int num18 = index;
          int num19 = num17;
          int num20 = num19 + 1;
          if (num18 == num19 && flag2 && Main.mapEnabled)
          {
            SoundEngine.PlaySound(12);
            Main.mapFullscreen = !Main.mapFullscreen;
          }
          int num21 = index;
          int num22 = num20;
          int num23 = num22 + 1;
          if (num21 == num22 && flag2 && this.SelectedMode != 2)
          {
            SoundEngine.PlaySound(12);
            this.SelectedMode = 2;
            this.ToggleCamera();
          }
          int num24 = index;
          int num25 = num23;
          int num26 = num25 + 1;
          if (num24 == num25 && flag2 & flag1)
          {
            SoundEngine.PlaySound(12);
            Utils.OpenFolder(Path.Combine(Main.SavePath, "Captures"));
          }
          int num27 = index;
          int num28 = num26;
          int num29 = num28 + 1;
          if (num27 == num28 && flag2)
          {
            this.ToggleCamera(false);
            Main.blockMouse = true;
            Main.mouseLeftRelease = false;
          }
          return true;
        }
      }
      return false;
    }

    public static void QuickScreenshot()
    {
      Point tileCoordinates1 = Main.ViewPosition.ToTileCoordinates();
      Point tileCoordinates2 = (Main.ViewPosition + Main.ViewSize).ToTileCoordinates();
      CaptureInterface.StartCamera(new CaptureSettings()
      {
        Area = new Rectangle(tileCoordinates1.X, tileCoordinates1.Y, tileCoordinates2.X - tileCoordinates1.X + 1, tileCoordinates2.Y - tileCoordinates1.Y + 1),
        Biome = CaptureBiome.GetCaptureBiome(CaptureInterface.Settings.BiomeChoiceIndex),
        CaptureBackground = !CaptureInterface.Settings.TransparentBackground,
        CaptureEntities = CaptureInterface.Settings.IncludeEntities,
        UseScaling = CaptureInterface.Settings.PackImage,
        CaptureMech = WiresUI.Settings.DrawWires
      });
    }

    private void DrawButtons(SpriteBatch sb)
    {
      Vector2 vector2 = new Vector2((float) Main.mouseX, (float) Main.mouseY);
      int num = 9;
      for (int index = 0; index < num; ++index)
      {
        Texture2D texture2D = TextureAssets.InventoryBack.Value;
        float scale = 0.8f;
        Vector2 position = new Vector2((float) (24 + 46 * index), 24f);
        Color color = Main.inventoryBack * 0.8f;
        if (this.SelectedMode == 0 && index == 2)
          texture2D = TextureAssets.InventoryBack14.Value;
        else if (this.SelectedMode == 1 && index == 3)
          texture2D = TextureAssets.InventoryBack14.Value;
        else if (this.SelectedMode == 2 && index == 6)
          texture2D = TextureAssets.InventoryBack14.Value;
        else if (index >= 2 && index <= 3)
          texture2D = TextureAssets.InventoryBack2.Value;
        sb.Draw(texture2D, position, new Rectangle?(), color, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
        switch (index)
        {
          case 0:
            texture2D = TextureAssets.Camera[7].Value;
            break;
          case 1:
            texture2D = TextureAssets.Camera[0].Value;
            break;
          case 2:
          case 3:
          case 4:
            texture2D = TextureAssets.Camera[index].Value;
            break;
          case 5:
            texture2D = Main.mapFullscreen ? TextureAssets.MapIcon[0].Value : TextureAssets.MapIcon[4].Value;
            break;
          case 6:
            texture2D = TextureAssets.Camera[1].Value;
            break;
          case 7:
            texture2D = TextureAssets.Camera[6].Value;
            break;
          case 8:
            texture2D = TextureAssets.Camera[5].Value;
            break;
        }
        sb.Draw(texture2D, position + new Vector2(26f) * scale, new Rectangle?(), Color.White, 0.0f, texture2D.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
        bool flag = false;
        if (index != 1)
        {
          if (index != 5)
          {
            if (index == 7 && Main.graphics.IsFullScreen)
              flag = true;
          }
          else if (!Main.mapEnabled)
            flag = true;
        }
        else if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
          flag = true;
        if (flag)
          sb.Draw(TextureAssets.Cd.Value, position + new Vector2(26f) * scale, new Rectangle?(), Color.White * 0.65f, 0.0f, TextureAssets.Cd.Value.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
      }
      string cursorText = "";
      switch (this.HoveredMode)
      {
        case -1:
          switch (this.HoveredMode)
          {
            case 1:
              if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
              {
                cursorText = cursorText + "\n" + Lang.inter[112].Value;
                break;
              }
              break;
            case 5:
              if (!Main.mapEnabled)
              {
                cursorText = cursorText + "\n" + Lang.inter[114].Value;
                break;
              }
              break;
            case 7:
              if (Main.graphics.IsFullScreen)
              {
                cursorText = cursorText + "\n" + Lang.inter[113].Value;
                break;
              }
              break;
          }
          if (!(cursorText != ""))
            break;
          Main.instance.MouseText(cursorText);
          break;
        case 0:
          cursorText = Lang.inter[111].Value;
          goto case -1;
        case 1:
          cursorText = Lang.inter[67].Value;
          goto case -1;
        case 2:
          cursorText = Lang.inter[69].Value;
          goto case -1;
        case 3:
          cursorText = Lang.inter[70].Value;
          goto case -1;
        case 4:
          cursorText = Lang.inter[78].Value;
          goto case -1;
        case 5:
          cursorText = Main.mapFullscreen ? Lang.inter[109].Value : Lang.inter[108].Value;
          goto case -1;
        case 6:
          cursorText = Lang.inter[68].Value;
          goto case -1;
        case 7:
          cursorText = Lang.inter[110].Value;
          goto case -1;
        case 8:
          cursorText = Lang.inter[71].Value;
          goto case -1;
        default:
          cursorText = "???";
          goto case -1;
      }
    }

    private static bool GetMapCoords(int PinX, int PinY, int Goal, out Point result)
    {
      if (!Main.mapFullscreen)
      {
        result = new Point(-1, -1);
        return false;
      }
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 2f;
      int num4 = Main.maxTilesX / Main.textureMaxWidth;
      int num5 = Main.maxTilesY / Main.textureMaxHeight;
      float num6 = 10f;
      float num7 = 10f;
      float num8 = (float) (Main.maxTilesX - 10);
      float num9 = (float) (Main.maxTilesY - 10);
      num1 = 200f;
      num2 = 300f;
      num3 = Main.mapFullscreenScale;
      float num10 = (float) ((double) Main.screenWidth / (double) Main.maxTilesX * 0.800000011920929);
      if ((double) Main.mapFullscreenScale < (double) num10)
        Main.mapFullscreenScale = num10;
      if ((double) Main.mapFullscreenScale > 16.0)
        Main.mapFullscreenScale = 16f;
      float mapFullscreenScale = Main.mapFullscreenScale;
      if ((double) Main.mapFullscreenPos.X < (double) num6)
        Main.mapFullscreenPos.X = num6;
      if ((double) Main.mapFullscreenPos.X > (double) num8)
        Main.mapFullscreenPos.X = num8;
      if ((double) Main.mapFullscreenPos.Y < (double) num7)
        Main.mapFullscreenPos.Y = num7;
      if ((double) Main.mapFullscreenPos.Y > (double) num9)
        Main.mapFullscreenPos.Y = num9;
      double x1 = (double) Main.mapFullscreenPos.X;
      float y1 = Main.mapFullscreenPos.Y;
      double num11 = (double) mapFullscreenScale;
      double num12 = x1 * num11;
      float num13 = y1 * mapFullscreenScale;
      float num14 = (float) -num12 + (float) (Main.screenWidth / 2);
      float num15 = -num13 + (float) (Main.screenHeight / 2);
      float x2 = num14 + num6 * mapFullscreenScale;
      float y2 = num15 + num7 * mapFullscreenScale;
      float num16 = (float) (Main.maxTilesX / 840) * Main.mapFullscreenScale;
      float num17 = x2;
      float num18 = y2;
      float num19 = (float) TextureAssets.Map.Width();
      float num20 = (float) TextureAssets.Map.Height();
      float num21;
      float num22;
      float num23;
      float num24;
      switch (Main.maxTilesX)
      {
        case 4200:
          float num25 = num16 * 0.998f;
          num21 = num17 - 37.3f * num25;
          num22 = num18 - 1.7f * num25;
          num23 = (num19 - 16f) * num25;
          num24 = (num20 - 8.31f) * num25;
          break;
        case 6300:
          float num26 = num16 * 1.09f;
          num21 = num17 - 39.8f * num26;
          num22 = y2 - 4.08f * num26;
          num23 = (num19 - 26.69f) * num26;
          float num27 = (num20 - 6.92f) * num26;
          if ((double) num26 < 1.2)
          {
            num24 = num27 + 2f;
            break;
          }
          break;
        case 6400:
          float num28 = num16 * 1.09f;
          num21 = num17 - 38.8f * num28;
          num22 = y2 - 3.85f * num28;
          num23 = (num19 - 13.6f) * num28;
          float num29 = (num20 - 6.92f) * num28;
          if ((double) num28 < 1.2)
          {
            num24 = num29 + 2f;
            break;
          }
          break;
        case 8400:
          float num30 = num16 * 0.999f;
          num21 = num17 - 40.6f * num30;
          num22 = y2 - 5f * num30;
          num23 = (num19 - 8.045f) * num30;
          float num31 = (num20 + 0.12f) * num30;
          if ((double) num30 < 1.2)
          {
            num24 = num31 + 1f;
            break;
          }
          break;
      }
      switch (Goal)
      {
        case 0:
          int x3 = (int) ((-(double) x2 + (double) PinX) / (double) mapFullscreenScale + (double) num6);
          int y3 = (int) ((-(double) y2 + (double) PinY) / (double) mapFullscreenScale + (double) num7);
          bool flag = false;
          if ((double) x3 < (double) num6)
            flag = true;
          if ((double) x3 >= (double) num8)
            flag = true;
          if ((double) y3 < (double) num7)
            flag = true;
          if ((double) y3 >= (double) num9)
            flag = true;
          if (!flag)
          {
            result = new Point(x3, y3);
            return true;
          }
          result = new Point(-1, -1);
          return false;
        case 1:
          Vector2 vector2_1 = new Vector2(x2, y2);
          Vector2 vector2_2 = new Vector2((float) PinX, (float) PinY) * mapFullscreenScale - new Vector2(10f * mapFullscreenScale);
          result = (vector2_1 + vector2_2).ToPoint();
          return true;
        default:
          result = new Point(-1, -1);
          return false;
      }
    }

    private static void ConstraintPoints()
    {
      int offScreenTiles = Lighting.OffScreenTiles;
      if (CaptureInterface.EdgeAPinned)
        CaptureInterface.PointWorldClamp(ref CaptureInterface.EdgeA, offScreenTiles);
      if (!CaptureInterface.EdgeBPinned)
        return;
      CaptureInterface.PointWorldClamp(ref CaptureInterface.EdgeB, offScreenTiles);
    }

    private static void PointWorldClamp(ref Point point, int fluff)
    {
      if (point.X < fluff)
        point.X = fluff;
      if (point.X > Main.maxTilesX - 1 - fluff)
        point.X = Main.maxTilesX - 1 - fluff;
      if (point.Y < fluff)
        point.Y = fluff;
      if (point.Y <= Main.maxTilesY - 1 - fluff)
        return;
      point.Y = Main.maxTilesY - 1 - fluff;
    }

    public bool UsingMap() => CaptureInterface.CameraLock || CaptureInterface.Modes[this.SelectedMode].UsingMap();

    public static void ResetFocus()
    {
      CaptureInterface.EdgeAPinned = false;
      CaptureInterface.EdgeBPinned = false;
      CaptureInterface.EdgeA = new Point(-1, -1);
      CaptureInterface.EdgeB = new Point(-1, -1);
    }

    public void Scrolling()
    {
      int num = PlayerInput.ScrollWheelDelta / 120 % 30;
      if (num < 0)
        num += 30;
      int selectedMode = this.SelectedMode;
      this.SelectedMode -= num;
      while (this.SelectedMode < 0)
        this.SelectedMode += 2;
      while (this.SelectedMode > 2)
        this.SelectedMode -= 2;
      if (this.SelectedMode == selectedMode)
        return;
      SoundEngine.PlaySound(12);
    }

    private void UpdateCamera()
    {
      if (CaptureInterface.CameraLock && (double) CaptureInterface.CameraFrame == 4.0)
        CaptureManager.Instance.Capture(CaptureInterface.CameraSettings);
      CaptureInterface.CameraFrame += (float) CaptureInterface.CameraLock.ToDirectionInt();
      if ((double) CaptureInterface.CameraFrame < 0.0)
        CaptureInterface.CameraFrame = 0.0f;
      if ((double) CaptureInterface.CameraFrame > 5.0)
        CaptureInterface.CameraFrame = 5f;
      if ((double) CaptureInterface.CameraFrame == 5.0)
        ++CaptureInterface.CameraWaiting;
      if ((double) CaptureInterface.CameraWaiting <= 60.0)
        return;
      CaptureInterface.CameraWaiting = 60f;
    }

    private void DrawCameraLock(SpriteBatch sb)
    {
      if ((double) CaptureInterface.CameraFrame == 0.0)
        return;
      sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Black * (CaptureInterface.CameraFrame / 5f));
      if ((double) CaptureInterface.CameraFrame != 5.0)
        return;
      float num1 = (float) ((double) CaptureInterface.CameraWaiting - 60.0 + 5.0);
      if ((double) num1 <= 0.0)
        return;
      float num2 = num1 / 5f;
      float num3 = CaptureManager.Instance.GetProgress() * 100f;
      if ((double) num3 > 100.0)
        num3 = 100f;
      string text1 = num3.ToString("##") + " ";
      string text2 = "/ 100%";
      Vector2 vector2_1 = FontAssets.DeathText.Value.MeasureString(text1);
      Vector2 vector2_2 = FontAssets.DeathText.Value.MeasureString(text2);
      Vector2 vector2_3 = new Vector2(-vector2_1.X, (float) (-(double) vector2_1.Y / 2.0));
      Vector2 vector2_4 = new Vector2(0.0f, (float) (-(double) vector2_2.Y / 2.0));
      ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.DeathText.Value, text1, new Vector2((float) Main.screenWidth, (float) Main.screenHeight) / 2f + vector2_3, Color.White * num2, 0.0f, Vector2.Zero, Vector2.One);
      ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.DeathText.Value, text2, new Vector2((float) Main.screenWidth, (float) Main.screenHeight) / 2f + vector2_4, Color.White * num2, 0.0f, Vector2.Zero, Vector2.One);
    }

    public static void StartCamera(CaptureSettings settings)
    {
      SoundEngine.PlaySound(40);
      CaptureInterface.CameraSettings = settings;
      CaptureInterface.CameraLock = true;
      CaptureInterface.CameraWaiting = 0.0f;
    }

    public static void EndCamera() => CaptureInterface.CameraLock = false;

    public static class Settings
    {
      public static bool PackImage = true;
      public static bool IncludeEntities = true;
      public static bool TransparentBackground;
      public static int BiomeChoiceIndex = -1;
      public static int ScreenAnchor = 0;
      public static Color MarkedAreaColor = new Color(0.8f, 0.8f, 0.8f, 0.0f) * 0.3f;
    }

    private abstract class CaptureInterfaceMode
    {
      public bool Selected;

      public abstract void Update();

      public abstract void Draw(SpriteBatch sb);

      public abstract void ToggleActive(bool tickedOn);

      public abstract bool UsingMap();
    }

    private class ModeEdgeSelection : CaptureInterface.CaptureInterfaceMode
    {
      public override void Update()
      {
        if (!this.Selected)
          return;
        PlayerInput.SetZoom_Context();
        this.EdgePlacement(new Vector2((float) Main.mouseX, (float) Main.mouseY));
      }

      public override void Draw(SpriteBatch sb)
      {
        if (!this.Selected)
          return;
        sb.End();
        sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.CurrentWantedZoomMatrix);
        PlayerInput.SetZoom_Context();
        this.DrawMarkedArea(sb);
        this.DrawCursors(sb);
        sb.End();
        sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.UIScaleMatrix);
        PlayerInput.SetZoom_UI();
      }

      public override void ToggleActive(bool tickedOn)
      {
      }

      public override bool UsingMap() => true;

      private void EdgePlacement(Vector2 mouse)
      {
        if (CaptureInterface.JustActivated)
          return;
        if (!Main.mapFullscreen)
        {
          if (Main.mouseLeft)
          {
            CaptureInterface.EdgeAPinned = true;
            CaptureInterface.EdgeA = Main.MouseWorld.ToTileCoordinates();
          }
          if (Main.mouseRight)
          {
            CaptureInterface.EdgeBPinned = true;
            CaptureInterface.EdgeB = Main.MouseWorld.ToTileCoordinates();
          }
        }
        else
        {
          Point result;
          if (CaptureInterface.GetMapCoords((int) mouse.X, (int) mouse.Y, 0, out result))
          {
            if (Main.mouseLeft)
            {
              CaptureInterface.EdgeAPinned = true;
              CaptureInterface.EdgeA = result;
            }
            if (Main.mouseRight)
            {
              CaptureInterface.EdgeBPinned = true;
              CaptureInterface.EdgeB = result;
            }
          }
        }
        CaptureInterface.ConstraintPoints();
      }

      private void DrawMarkedArea(SpriteBatch sb)
      {
        if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
          return;
        int PinX = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
        int PinY = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
        int num1 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
        int num2 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
        if (!Main.mapFullscreen)
        {
          Rectangle rectangle1 = Main.ReverseGravitySupport(new Rectangle(PinX * 16, PinY * 16, (num1 + 1) * 16, (num2 + 1) * 16));
          Rectangle rectangle2 = Main.ReverseGravitySupport(new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth + 1, Main.screenHeight + 1));
          Rectangle result;
          Rectangle.Intersect(ref rectangle2, ref rectangle1, out result);
          if (result.Width == 0 || result.Height == 0)
            return;
          result.Offset(-rectangle2.X, -rectangle2.Y);
          sb.Draw(TextureAssets.MagicPixel.Value, result, CaptureInterface.Settings.MarkedAreaColor);
          for (int index = 0; index < 2; ++index)
          {
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(result.X, result.Y + (index == 1 ? result.Height : -2), result.Width, 2), Color.White);
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(result.X + (index == 1 ? result.Width : -2), result.Y, 2, result.Height), Color.White);
          }
        }
        else
        {
          Point result1;
          CaptureInterface.GetMapCoords(PinX, PinY, 1, out result1);
          Point result2;
          CaptureInterface.GetMapCoords(PinX + num1 + 1, PinY + num2 + 1, 1, out result2);
          Rectangle rectangle3 = new Rectangle(result1.X, result1.Y, result2.X - result1.X, result2.Y - result1.Y);
          Rectangle rectangle4 = new Rectangle(0, 0, Main.screenWidth + 1, Main.screenHeight + 1);
          Rectangle result3;
          Rectangle.Intersect(ref rectangle4, ref rectangle3, out result3);
          if (result3.Width == 0 || result3.Height == 0)
            return;
          result3.Offset(-rectangle4.X, -rectangle4.Y);
          sb.Draw(TextureAssets.MagicPixel.Value, result3, CaptureInterface.Settings.MarkedAreaColor);
          for (int index = 0; index < 2; ++index)
          {
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(result3.X, result3.Y + (index == 1 ? result3.Height : -2), result3.Width, 2), Color.White);
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(result3.X + (index == 1 ? result3.Width : -2), result3.Y, 2, result3.Height), Color.White);
          }
        }
      }

      private void DrawCursors(SpriteBatch sb)
      {
        float num1 = 1f / Main.cursorScale;
        float num2 = 0.8f / num1;
        Vector2 min = Main.screenPosition + new Vector2(30f);
        Vector2 max = min + new Vector2((float) Main.screenWidth, (float) Main.screenHeight) - new Vector2(60f);
        if (Main.mapFullscreen)
        {
          min -= Main.screenPosition;
          max -= Main.screenPosition;
        }
        Vector3 hsl = Main.rgbToHsl(Main.cursorColor);
        Main.hslToRgb((float) (((double) hsl.X + 0.330000013113022) % 1.0), hsl.Y, hsl.Z);
        Main.hslToRgb((float) (((double) hsl.X - 0.330000013113022) % 1.0), hsl.Y, hsl.Z);
        Color white;
        Color color = white = Color.White;
        bool flag = (double) Main.player[Main.myPlayer].gravDir == -1.0;
        if (!CaptureInterface.EdgeAPinned)
        {
          Utils.DrawCursorSingle(sb, color, 3.926991f, Main.cursorScale * num1 * num2, new Vector2((float) ((double) Main.mouseX - 5.0 + 12.0), (float) ((double) Main.mouseY + 2.5 + 12.0)), 4);
        }
        else
        {
          int specialMode = 0;
          float num3 = 0.0f;
          Vector2 vector2_1 = Vector2.Zero;
          if (!Main.mapFullscreen)
          {
            Vector2 vector2_2 = CaptureInterface.EdgeA.ToVector2() * 16f;
            float num4;
            Vector2 vector2_3;
            if (!CaptureInterface.EdgeBPinned)
            {
              specialMode = 1;
              Vector2 vector2_4 = vector2_2 + Vector2.One * 8f;
              vector2_1 = vector2_4;
              num4 = (-vector2_4 + Main.ReverseGravitySupport(new Vector2((float) Main.mouseX, (float) Main.mouseY)) + Main.screenPosition).ToRotation();
              if (flag)
                num4 = -num4;
              vector2_3 = Vector2.Clamp(vector2_4, min, max);
              if (vector2_3 != vector2_4)
                num4 = (vector2_4 - vector2_3).ToRotation();
            }
            else
            {
              Vector2 vector2_5 = new Vector2((float) ((CaptureInterface.EdgeA.X > CaptureInterface.EdgeB.X).ToInt() * 16), (float) ((CaptureInterface.EdgeA.Y > CaptureInterface.EdgeB.Y).ToInt() * 16));
              Vector2 vector2_6 = vector2_2 + vector2_5;
              vector2_3 = Vector2.Clamp(vector2_6, min, max);
              num4 = (CaptureInterface.EdgeB.ToVector2() * 16f + new Vector2(16f) - vector2_5 - vector2_3).ToRotation();
              if (vector2_3 != vector2_6)
              {
                num4 = (vector2_6 - vector2_3).ToRotation();
                specialMode = 1;
              }
              if (flag)
                num4 *= -1f;
            }
            Utils.DrawCursorSingle(sb, color, num4 - 1.570796f, Main.cursorScale * num1, Main.ReverseGravitySupport(vector2_3 - Main.screenPosition), 4, specialMode);
          }
          else
          {
            Point result1 = CaptureInterface.EdgeA;
            if (CaptureInterface.EdgeBPinned)
            {
              int num5 = (CaptureInterface.EdgeA.X > CaptureInterface.EdgeB.X).ToInt();
              int num6 = (CaptureInterface.EdgeA.Y > CaptureInterface.EdgeB.Y).ToInt();
              result1.X += num5;
              result1.Y += num6;
              CaptureInterface.GetMapCoords(result1.X, result1.Y, 1, out result1);
              Point result2 = CaptureInterface.EdgeB;
              result2.X += 1 - num5;
              result2.Y += 1 - num6;
              CaptureInterface.GetMapCoords(result2.X, result2.Y, 1, out result2);
              Vector2 vector2_7 = Vector2.Clamp(result1.ToVector2(), min, max);
              num3 = (result2.ToVector2() - vector2_7).ToRotation();
            }
            else
              CaptureInterface.GetMapCoords(result1.X, result1.Y, 1, out result1);
            Utils.DrawCursorSingle(sb, color, num3 - 1.570796f, Main.cursorScale * num1, result1.ToVector2(), 4);
          }
        }
        if (!CaptureInterface.EdgeBPinned)
        {
          Utils.DrawCursorSingle(sb, white, 0.7853981f, Main.cursorScale * num1 * num2, new Vector2((float) ((double) Main.mouseX + 2.5 + 12.0), (float) ((double) Main.mouseY - 5.0 + 12.0)), 5);
        }
        else
        {
          int specialMode = 0;
          float num7 = 0.0f;
          Vector2 vector2_8 = Vector2.Zero;
          if (!Main.mapFullscreen)
          {
            Vector2 vector2_9 = CaptureInterface.EdgeB.ToVector2() * 16f;
            float num8;
            Vector2 vector2_10;
            if (!CaptureInterface.EdgeAPinned)
            {
              specialMode = 1;
              Vector2 vector2_11 = vector2_9 + Vector2.One * 8f;
              vector2_8 = vector2_11;
              num8 = (-vector2_11 + Main.ReverseGravitySupport(new Vector2((float) Main.mouseX, (float) Main.mouseY)) + Main.screenPosition).ToRotation();
              if (flag)
                num8 = -num8;
              vector2_10 = Vector2.Clamp(vector2_11, min, max);
              if (vector2_10 != vector2_11)
                num8 = (vector2_11 - vector2_10).ToRotation();
            }
            else
            {
              Vector2 vector2_12 = new Vector2((float) ((CaptureInterface.EdgeB.X >= CaptureInterface.EdgeA.X).ToInt() * 16), (float) ((CaptureInterface.EdgeB.Y >= CaptureInterface.EdgeA.Y).ToInt() * 16));
              Vector2 vector2_13 = vector2_9 + vector2_12;
              vector2_10 = Vector2.Clamp(vector2_13, min, max);
              num8 = (CaptureInterface.EdgeA.ToVector2() * 16f + new Vector2(16f) - vector2_12 - vector2_10).ToRotation();
              if (vector2_10 != vector2_13)
              {
                num8 = (vector2_13 - vector2_10).ToRotation();
                specialMode = 1;
              }
              if (flag)
                num8 *= -1f;
            }
            Utils.DrawCursorSingle(sb, white, num8 - 1.570796f, Main.cursorScale * num1, Main.ReverseGravitySupport(vector2_10 - Main.screenPosition), 5, specialMode);
          }
          else
          {
            Point result3 = CaptureInterface.EdgeB;
            if (CaptureInterface.EdgeAPinned)
            {
              int num9 = (CaptureInterface.EdgeB.X >= CaptureInterface.EdgeA.X).ToInt();
              int num10 = (CaptureInterface.EdgeB.Y >= CaptureInterface.EdgeA.Y).ToInt();
              result3.X += num9;
              result3.Y += num10;
              CaptureInterface.GetMapCoords(result3.X, result3.Y, 1, out result3);
              Point result4 = CaptureInterface.EdgeA;
              result4.X += 1 - num9;
              result4.Y += 1 - num10;
              CaptureInterface.GetMapCoords(result4.X, result4.Y, 1, out result4);
              Vector2 vector2_14 = Vector2.Clamp(result3.ToVector2(), min, max);
              num7 = (result4.ToVector2() - vector2_14).ToRotation();
            }
            else
              CaptureInterface.GetMapCoords(result3.X, result3.Y, 1, out result3);
            Utils.DrawCursorSingle(sb, white, num7 - 1.570796f, Main.cursorScale * num1, result3.ToVector2(), 5);
          }
        }
      }
    }

    private class ModeDragBounds : CaptureInterface.CaptureInterfaceMode
    {
      public int currentAim = -1;
      private bool dragging;
      private int caughtEdge = -1;
      private bool inMap;

      public override void Update()
      {
        if (!this.Selected || CaptureInterface.JustActivated)
          return;
        PlayerInput.SetZoom_Context();
        this.DragBounds(new Vector2((float) Main.mouseX, (float) Main.mouseY));
      }

      public override void Draw(SpriteBatch sb)
      {
        if (!this.Selected)
          return;
        sb.End();
        sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.CurrentWantedZoomMatrix);
        PlayerInput.SetZoom_Context();
        this.DrawMarkedArea(sb);
        sb.End();
        sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.UIScaleMatrix);
        PlayerInput.SetZoom_UI();
      }

      public override void ToggleActive(bool tickedOn)
      {
        if (tickedOn)
          return;
        this.currentAim = -1;
      }

      public override bool UsingMap() => this.caughtEdge != -1;

      private void DragBounds(Vector2 mouse)
      {
        if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
        {
          bool flag1 = false;
          if (Main.mouseLeft)
            flag1 = true;
          if (flag1)
          {
            bool flag2 = true;
            Point result;
            if (!Main.mapFullscreen)
              result = (Main.screenPosition + mouse).ToTileCoordinates();
            else
              flag2 = CaptureInterface.GetMapCoords((int) mouse.X, (int) mouse.Y, 0, out result);
            if (flag2)
            {
              if (!CaptureInterface.EdgeAPinned)
              {
                CaptureInterface.EdgeAPinned = true;
                CaptureInterface.EdgeA = result;
              }
              if (!CaptureInterface.EdgeBPinned)
              {
                CaptureInterface.EdgeBPinned = true;
                CaptureInterface.EdgeB = result;
              }
            }
            this.currentAim = 3;
            this.caughtEdge = 1;
          }
        }
        int PinX = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
        int PinY = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
        int num1 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
        int num2 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
        bool flag = (double) Main.player[Main.myPlayer].gravDir == -1.0;
        int num3 = 1 - flag.ToInt();
        int num4 = flag.ToInt();
        Rectangle rectangle1;
        Rectangle rectangle2;
        if (!Main.mapFullscreen)
        {
          rectangle1 = Main.ReverseGravitySupport(new Rectangle(PinX * 16, PinY * 16, (num1 + 1) * 16, (num2 + 1) * 16));
          rectangle2 = Main.ReverseGravitySupport(new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth + 1, Main.screenHeight + 1));
          Rectangle result;
          Rectangle.Intersect(ref rectangle2, ref rectangle1, out result);
          if (result.Width == 0 || result.Height == 0)
            return;
          result.Offset(-rectangle2.X, -rectangle2.Y);
        }
        else
        {
          Point result1;
          CaptureInterface.GetMapCoords(PinX, PinY, 1, out result1);
          Point result2;
          CaptureInterface.GetMapCoords(PinX + num1 + 1, PinY + num2 + 1, 1, out result2);
          rectangle1 = new Rectangle(result1.X, result1.Y, result2.X - result1.X, result2.Y - result1.Y);
          rectangle2 = new Rectangle(0, 0, Main.screenWidth + 1, Main.screenHeight + 1);
          Rectangle result3;
          Rectangle.Intersect(ref rectangle2, ref rectangle1, out result3);
          if (result3.Width == 0 || result3.Height == 0)
            return;
          result3.Offset(-rectangle2.X, -rectangle2.Y);
        }
        this.dragging = false;
        if (!Main.mouseLeft)
          this.currentAim = -1;
        if (this.currentAim != -1)
        {
          this.dragging = true;
          Point point1 = new Point();
          Point point2;
          if (!Main.mapFullscreen)
          {
            point2 = Main.MouseWorld.ToTileCoordinates();
          }
          else
          {
            Point result;
            if (!CaptureInterface.GetMapCoords((int) mouse.X, (int) mouse.Y, 0, out result))
              return;
            point2 = result;
          }
          switch (this.currentAim)
          {
            case 0:
            case 1:
              if (this.caughtEdge == 0)
                CaptureInterface.EdgeA.Y = point2.Y;
              if (this.caughtEdge == 1)
              {
                CaptureInterface.EdgeB.Y = point2.Y;
                break;
              }
              break;
            case 2:
            case 3:
              if (this.caughtEdge == 0)
                CaptureInterface.EdgeA.X = point2.X;
              if (this.caughtEdge == 1)
              {
                CaptureInterface.EdgeB.X = point2.X;
                break;
              }
              break;
          }
        }
        else
        {
          this.caughtEdge = -1;
          Rectangle drawbox = rectangle1;
          drawbox.Offset(-rectangle2.X, -rectangle2.Y);
          this.inMap = drawbox.Contains(mouse.ToPoint());
          for (int boundIndex = 0; boundIndex < 4; ++boundIndex)
          {
            Rectangle bound = this.GetBound(drawbox, boundIndex);
            bound.Inflate(8, 8);
            if (bound.Contains(mouse.ToPoint()))
            {
              this.currentAim = boundIndex;
              switch (boundIndex)
              {
                case 0:
                  this.caughtEdge = CaptureInterface.EdgeA.Y >= CaptureInterface.EdgeB.Y ? num3 : num4;
                  goto label_46;
                case 1:
                  this.caughtEdge = CaptureInterface.EdgeA.Y < CaptureInterface.EdgeB.Y ? num3 : num4;
                  goto label_46;
                case 2:
                  this.caughtEdge = CaptureInterface.EdgeA.X >= CaptureInterface.EdgeB.X ? 1 : 0;
                  goto label_46;
                case 3:
                  this.caughtEdge = CaptureInterface.EdgeA.X < CaptureInterface.EdgeB.X ? 1 : 0;
                  goto label_46;
                default:
                  goto label_46;
              }
            }
          }
        }
label_46:
        CaptureInterface.ConstraintPoints();
      }

      private Rectangle GetBound(Rectangle drawbox, int boundIndex)
      {
        switch (boundIndex)
        {
          case 0:
            return new Rectangle(drawbox.X, drawbox.Y - 2, drawbox.Width, 2);
          case 1:
            return new Rectangle(drawbox.X, drawbox.Y + drawbox.Height, drawbox.Width, 2);
          case 2:
            return new Rectangle(drawbox.X - 2, drawbox.Y, 2, drawbox.Height);
          case 3:
            return new Rectangle(drawbox.X + drawbox.Width, drawbox.Y, 2, drawbox.Height);
          default:
            return Rectangle.Empty;
        }
      }

      public void DrawMarkedArea(SpriteBatch sb)
      {
        if (!CaptureInterface.EdgeAPinned || !CaptureInterface.EdgeBPinned)
          return;
        int PinX = Math.Min(CaptureInterface.EdgeA.X, CaptureInterface.EdgeB.X);
        int PinY = Math.Min(CaptureInterface.EdgeA.Y, CaptureInterface.EdgeB.Y);
        int num1 = Math.Abs(CaptureInterface.EdgeA.X - CaptureInterface.EdgeB.X);
        int num2 = Math.Abs(CaptureInterface.EdgeA.Y - CaptureInterface.EdgeB.Y);
        Rectangle result1;
        if (!Main.mapFullscreen)
        {
          Rectangle rectangle1 = Main.ReverseGravitySupport(new Rectangle(PinX * 16, PinY * 16, (num1 + 1) * 16, (num2 + 1) * 16));
          Rectangle rectangle2 = Main.ReverseGravitySupport(new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth + 1, Main.screenHeight + 1));
          Rectangle.Intersect(ref rectangle2, ref rectangle1, out result1);
          if (result1.Width == 0 || result1.Height == 0)
            return;
          result1.Offset(-rectangle2.X, -rectangle2.Y);
        }
        else
        {
          Point result2;
          CaptureInterface.GetMapCoords(PinX, PinY, 1, out result2);
          Point result3;
          CaptureInterface.GetMapCoords(PinX + num1 + 1, PinY + num2 + 1, 1, out result3);
          Rectangle rectangle3 = new Rectangle(result2.X, result2.Y, result3.X - result2.X, result3.Y - result2.Y);
          Rectangle rectangle4 = new Rectangle(0, 0, Main.screenWidth + 1, Main.screenHeight + 1);
          Rectangle.Intersect(ref rectangle4, ref rectangle3, out result1);
          if (result1.Width == 0 || result1.Height == 0)
            return;
          result1.Offset(-rectangle4.X, -rectangle4.Y);
        }
        sb.Draw(TextureAssets.MagicPixel.Value, result1, CaptureInterface.Settings.MarkedAreaColor);
        Rectangle r = Rectangle.Empty;
        for (int index = 0; index < 2; ++index)
        {
          if (this.currentAim != index)
            this.DrawBound(sb, new Rectangle(result1.X, result1.Y + (index == 1 ? result1.Height : -2), result1.Width, 2), 0);
          else
            r = new Rectangle(result1.X, result1.Y + (index == 1 ? result1.Height : -2), result1.Width, 2);
          if (this.currentAim != index + 2)
            this.DrawBound(sb, new Rectangle(result1.X + (index == 1 ? result1.Width : -2), result1.Y, 2, result1.Height), 0);
          else
            r = new Rectangle(result1.X + (index == 1 ? result1.Width : -2), result1.Y, 2, result1.Height);
        }
        if (!(r != Rectangle.Empty))
          return;
        this.DrawBound(sb, r, 1 + this.dragging.ToInt());
      }

      private void DrawBound(SpriteBatch sb, Rectangle r, int mode)
      {
        switch (mode)
        {
          case 0:
            sb.Draw(TextureAssets.MagicPixel.Value, r, Color.Silver);
            break;
          case 1:
            Rectangle destinationRectangle1 = new Rectangle(r.X - 2, r.Y, r.Width + 4, r.Height);
            sb.Draw(TextureAssets.MagicPixel.Value, destinationRectangle1, Color.White);
            destinationRectangle1 = new Rectangle(r.X, r.Y - 2, r.Width, r.Height + 4);
            sb.Draw(TextureAssets.MagicPixel.Value, destinationRectangle1, Color.White);
            sb.Draw(TextureAssets.MagicPixel.Value, r, Color.White);
            break;
          case 2:
            Rectangle destinationRectangle2 = new Rectangle(r.X - 2, r.Y, r.Width + 4, r.Height);
            sb.Draw(TextureAssets.MagicPixel.Value, destinationRectangle2, Color.Gold);
            destinationRectangle2 = new Rectangle(r.X, r.Y - 2, r.Width, r.Height + 4);
            sb.Draw(TextureAssets.MagicPixel.Value, destinationRectangle2, Color.Gold);
            sb.Draw(TextureAssets.MagicPixel.Value, r, Color.Gold);
            break;
        }
      }
    }

    private class ModeChangeSettings : CaptureInterface.CaptureInterfaceMode
    {
      private const int ButtonsCount = 7;
      private int hoveredButton = -1;
      private bool inUI;

      private Rectangle GetRect()
      {
        Rectangle rectangle = new Rectangle(0, 0, 224, 170);
        if (CaptureInterface.Settings.ScreenAnchor == 0)
        {
          rectangle.X = 227 - rectangle.Width / 2;
          rectangle.Y = 80;
        }
        return rectangle;
      }

      private void ButtonDraw(int button, ref string key, ref string value)
      {
        switch (button)
        {
          case 0:
            key = Lang.inter[74].Value;
            value = Lang.inter[73 - CaptureInterface.Settings.PackImage.ToInt()].Value;
            break;
          case 1:
            key = Lang.inter[75].Value;
            value = Lang.inter[73 - CaptureInterface.Settings.IncludeEntities.ToInt()].Value;
            break;
          case 2:
            key = Lang.inter[76].Value;
            value = Lang.inter[73 - (!CaptureInterface.Settings.TransparentBackground).ToInt()].Value;
            break;
          case 6:
            key = "      " + Lang.menu[86].Value;
            value = "";
            break;
        }
      }

      private void PressButton(int button)
      {
        bool flag = false;
        switch (button)
        {
          case 0:
            CaptureInterface.Settings.PackImage = !CaptureInterface.Settings.PackImage;
            flag = true;
            break;
          case 1:
            CaptureInterface.Settings.IncludeEntities = !CaptureInterface.Settings.IncludeEntities;
            flag = true;
            break;
          case 2:
            CaptureInterface.Settings.TransparentBackground = !CaptureInterface.Settings.TransparentBackground;
            flag = true;
            break;
          case 6:
            CaptureInterface.Settings.PackImage = true;
            CaptureInterface.Settings.IncludeEntities = true;
            CaptureInterface.Settings.TransparentBackground = false;
            CaptureInterface.Settings.BiomeChoiceIndex = -1;
            flag = true;
            break;
        }
        if (!flag)
          return;
        SoundEngine.PlaySound(12);
      }

      private void DrawWaterChoices(SpriteBatch spritebatch, Point start, Point mouse)
      {
        Rectangle r = new Rectangle(0, 0, 20, 20);
        for (int index1 = 0; index1 < 2; ++index1)
        {
          for (int index2 = 0; index2 < 7; ++index2)
          {
            if (index1 != 1 || index2 != 6)
            {
              int num1 = index2 + index1 * 7;
              r.X = start.X + 24 * index2 + 12 * index1;
              r.Y = start.Y + 24 * index1;
              int num2 = num1;
              int num3 = 0;
              if (r.Contains(mouse))
              {
                if (Main.mouseLeft && Main.mouseLeftRelease)
                {
                  SoundEngine.PlaySound(12);
                  CaptureInterface.Settings.BiomeChoiceIndex = num2;
                }
                ++num3;
              }
              if (CaptureInterface.Settings.BiomeChoiceIndex == num2)
                num3 += 2;
              Texture2D texture = TextureAssets.Extra[130].Value;
              int x = num1 * 18;
              Color white = Color.White;
              float num4 = 1f;
              if (num3 < 2)
                num4 *= 0.5f;
              if (num3 % 2 == 1)
                spritebatch.Draw(TextureAssets.MagicPixel.Value, r.TopLeft(), new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Gold, 0.0f, Vector2.Zero, new Vector2(20f), SpriteEffects.None, 0.0f);
              else
                spritebatch.Draw(TextureAssets.MagicPixel.Value, r.TopLeft(), new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.White * num4, 0.0f, Vector2.Zero, new Vector2(20f), SpriteEffects.None, 0.0f);
              spritebatch.Draw(texture, r.TopLeft() + new Vector2(2f), new Rectangle?(new Rectangle(x, 0, 16, 16)), Color.White * num4);
            }
          }
        }
      }

      private int UnnecessaryBiomeSelectionTypeConversion(int index)
      {
        switch (index)
        {
          case 0:
            return -1;
          case 1:
            return 0;
          case 2:
            return 2;
          case 3:
          case 4:
          case 5:
          case 6:
          case 7:
          case 8:
            return index;
          case 9:
            return 10;
          case 10:
            return 12;
          case 11:
            return 13;
          case 12:
            return 14;
          default:
            return 0;
        }
      }

      public override void Update()
      {
        if (!this.Selected || CaptureInterface.JustActivated)
          return;
        PlayerInput.SetZoom_UI();
        Point point = new Point(Main.mouseX, Main.mouseY);
        this.hoveredButton = -1;
        Rectangle rect = this.GetRect();
        this.inUI = rect.Contains(point);
        rect.Inflate(-20, -20);
        rect.Height = 16;
        int y = rect.Y;
        for (int index = 0; index < 7; ++index)
        {
          rect.Y = y + index * 20;
          if (rect.Contains(point))
          {
            this.hoveredButton = index;
            break;
          }
        }
        if (!Main.mouseLeft || !Main.mouseLeftRelease || this.hoveredButton == -1)
          return;
        this.PressButton(this.hoveredButton);
      }

      public override void Draw(SpriteBatch sb)
      {
        if (!this.Selected)
          return;
        sb.End();
        sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.CurrentWantedZoomMatrix);
        PlayerInput.SetZoom_Context();
        ((CaptureInterface.ModeDragBounds) CaptureInterface.Modes[1]).currentAim = -1;
        ((CaptureInterface.ModeDragBounds) CaptureInterface.Modes[1]).DrawMarkedArea(sb);
        sb.End();
        sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect) null, Main.UIScaleMatrix);
        PlayerInput.SetZoom_UI();
        Rectangle rect = this.GetRect();
        Utils.DrawInvBG(sb, rect, new Color(63, 65, 151, (int) byte.MaxValue) * 0.485f);
        for (int button = 0; button < 7; ++button)
        {
          string key = "";
          string text = "";
          this.ButtonDraw(button, ref key, ref text);
          Color baseColor = Color.White;
          if (button == this.hoveredButton)
            baseColor = Color.Gold;
          ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.ItemStack.Value, key, rect.TopLeft() + new Vector2(20f, (float) (20 + 20 * button)), baseColor, 0.0f, Vector2.Zero, Vector2.One);
          ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.ItemStack.Value, text, rect.TopRight() + new Vector2(-20f, (float) (20 + 20 * button)), baseColor, 0.0f, FontAssets.ItemStack.Value.MeasureString(text) * Vector2.UnitX, Vector2.One);
        }
        this.DrawWaterChoices(sb, (rect.TopLeft() + new Vector2((float) (rect.Width / 2 - 84), 90f)).ToPoint(), Main.MouseScreen.ToPoint());
      }

      public override void ToggleActive(bool tickedOn)
      {
        if (!tickedOn)
          return;
        this.hoveredButton = -1;
      }

      public override bool UsingMap() => this.inUI;
    }
  }
}
