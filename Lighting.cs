// Decompiled with JetBrains decompiler
// Type: Terraria.Lighting
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.Graphics;
using Terraria.Graphics.Light;
using Terraria.ID;

namespace Terraria
{
  public class Lighting
  {
    private const float DEFAULT_GLOBAL_BRIGHTNESS = 1.2f;
    private const float BLIND_GLOBAL_BRIGHTNESS = 1f;
    [Obsolete]
    public static int OffScreenTiles = 45;
    private static LightMode _mode = LightMode.Color;
    private static readonly LightingEngine NewEngine = new LightingEngine(Main.ActiveWorld);
    private static readonly LegacyLighting LegacyEngine = new LegacyLighting(Main.Camera, Main.ActiveWorld);
    private static ILightingEngine _activeEngine;

    public static float GlobalBrightness { get; set; }

    public static LightMode Mode
    {
      get => Lighting._mode;
      set
      {
        Lighting._mode = value;
        switch (Lighting._mode)
        {
          case LightMode.White:
            Lighting._activeEngine = (ILightingEngine) Lighting.LegacyEngine;
            Lighting.LegacyEngine.Mode = 1;
            break;
          case LightMode.Retro:
            Lighting._activeEngine = (ILightingEngine) Lighting.LegacyEngine;
            Lighting.LegacyEngine.Mode = 2;
            break;
          case LightMode.Trippy:
            Lighting._activeEngine = (ILightingEngine) Lighting.LegacyEngine;
            Lighting.LegacyEngine.Mode = 3;
            break;
          case LightMode.Color:
            Lighting._activeEngine = (ILightingEngine) Lighting.NewEngine;
            Lighting.LegacyEngine.Mode = 0;
            Lighting.OffScreenTiles = 35;
            break;
        }
        Main.renderCount = 0;
        Main.renderNow = false;
      }
    }

    public static bool NotRetro => Lighting.Mode != LightMode.Retro && Lighting.Mode != LightMode.Trippy;

    public static bool UsingNewLighting => Lighting.Mode == LightMode.Color;

    public static bool UpdateEveryFrame => Main.LightingEveryFrame && !Main.RenderTargetsRequired && !Lighting.NotRetro;

    public static void Initialize()
    {
      Lighting.GlobalBrightness = 1.2f;
      Lighting.NewEngine.Rebuild();
      Lighting.LegacyEngine.Rebuild();
      if (Lighting._activeEngine != null)
        return;
      Lighting.Mode = LightMode.Color;
    }

    public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
    {
      Main.render = true;
      Lighting.UpdateGlobalBrightness();
      Lighting._activeEngine.ProcessArea(new Rectangle(firstX, firstY, lastX - firstX, lastY - firstY));
    }

    private static void UpdateGlobalBrightness()
    {
      Lighting.GlobalBrightness = 1.2f;
      if (!Main.player[Main.myPlayer].blind)
        return;
      Lighting.GlobalBrightness = 1f;
    }

    public static float Brightness(int x, int y)
    {
      Vector3 color = Lighting._activeEngine.GetColor(x, y);
      return (float) ((double) Lighting.GlobalBrightness * ((double) color.X + (double) color.Y + (double) color.Z) / 3.0);
    }

    public static Vector3 GetSubLight(Vector2 position)
    {
      Vector2 vector2_1 = position / 16f - new Vector2(0.5f, 0.5f);
      Vector2 vector2_2 = new Vector2(vector2_1.X % 1f, vector2_1.Y % 1f);
      int x1 = (int) vector2_1.X;
      int y = (int) vector2_1.Y;
      Vector3 color1 = Lighting._activeEngine.GetColor(x1, y);
      Vector3 color2 = Lighting._activeEngine.GetColor(x1 + 1, y);
      Vector3 color3 = Lighting._activeEngine.GetColor(x1, y + 1);
      Vector3 color4 = Lighting._activeEngine.GetColor(x1 + 1, y + 1);
      Vector3 vector3 = color2;
      double x2 = (double) vector2_2.X;
      return Vector3.Lerp(Vector3.Lerp(color1, vector3, (float) x2), Vector3.Lerp(color3, color4, vector2_2.X), vector2_2.Y);
    }

    public static void AddLight(Vector2 position, Vector3 rgb) => Lighting.AddLight((int) ((double) position.X / 16.0), (int) ((double) position.Y / 16.0), rgb.X, rgb.Y, rgb.Z);

    public static void AddLight(Vector2 position, float r, float g, float b) => Lighting.AddLight((int) ((double) position.X / 16.0), (int) ((double) position.Y / 16.0), r, g, b);

    public static void AddLight(int i, int j, int torchID, float lightAmount)
    {
      float R;
      float G;
      float B;
      TorchID.TorchColor(torchID, out R, out G, out B);
      Lighting._activeEngine.AddLight(i, j, new Vector3(R * lightAmount, G * lightAmount, B * lightAmount));
    }

    public static void AddLight(Vector2 position, int torchID)
    {
      float R;
      float G;
      float B;
      TorchID.TorchColor(torchID, out R, out G, out B);
      Lighting.AddLight((int) position.X / 16, (int) position.Y / 16, R, G, B);
    }

    public static void AddLight(int i, int j, float r, float g, float b)
    {
      if (Main.gamePaused || Main.netMode == 2)
        return;
      Lighting._activeEngine.AddLight(i, j, new Vector3(r, g, b));
    }

    public static void NextLightMode()
    {
      ++Lighting.Mode;
      if (!Enum.IsDefined(typeof (LightMode), (object) Lighting.Mode))
        Lighting.Mode = LightMode.White;
      Lighting.Clear();
    }

    public static void Clear() => Lighting._activeEngine.Clear();

    public static Color GetColor(Point tileCoords) => Main.gameMenu ? Color.White : new Color(Lighting._activeEngine.GetColor(tileCoords.X, tileCoords.Y) * Lighting.GlobalBrightness);

    public static Color GetColor(Point tileCoords, Color originalColor) => Main.gameMenu ? originalColor : new Color(Lighting._activeEngine.GetColor(tileCoords.X, tileCoords.Y) * originalColor.ToVector3());

    public static Color GetColor(int x, int y, Color oldColor) => Main.gameMenu ? oldColor : new Color(Lighting._activeEngine.GetColor(x, y) * oldColor.ToVector3());

    public static Color GetColor(int x, int y)
    {
      if (Main.gameMenu)
        return Color.White;
      Color color1 = new Color();
      Vector3 color2 = Lighting._activeEngine.GetColor(x, y);
      float num1 = Lighting.GlobalBrightness * (float) byte.MaxValue;
      int num2 = (int) ((double) color2.X * (double) num1);
      int num3 = (int) ((double) color2.Y * (double) num1);
      int num4 = (int) ((double) color2.Z * (double) num1);
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      if (num4 > (int) byte.MaxValue)
        num4 = (int) byte.MaxValue;
      int num5 = num4 << 16;
      int num6 = num3 << 8;
      color1.PackedValue = (uint) (num2 | num6 | num5 | -16777216);
      return color1;
    }

    public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
    {
      int index = 0;
      for (int x = centerX - 1; x <= centerX + 1; ++x)
      {
        for (int y = centerY - 1; y <= centerY + 1; ++y)
        {
          Vector3 color = Lighting._activeEngine.GetColor(x, y);
          int num1 = (int) ((double) byte.MaxValue * (double) color.X * (double) Lighting.GlobalBrightness);
          int num2 = (int) ((double) byte.MaxValue * (double) color.Y * (double) Lighting.GlobalBrightness);
          int num3 = (int) ((double) byte.MaxValue * (double) color.Z * (double) Lighting.GlobalBrightness);
          if (num1 > (int) byte.MaxValue)
            num1 = (int) byte.MaxValue;
          if (num2 > (int) byte.MaxValue)
            num2 = (int) byte.MaxValue;
          if (num3 > (int) byte.MaxValue)
            num3 = (int) byte.MaxValue;
          int num4 = num3 << 16;
          int num5 = num2 << 8;
          slices[index].PackedValue = (uint) (num1 | num5 | num4 | -16777216);
          index += 3;
        }
        index -= 8;
      }
    }

    public static void GetColor9Slice(int x, int y, ref Vector3[] slices)
    {
      slices[0] = Lighting._activeEngine.GetColor(x - 1, y - 1) * Lighting.GlobalBrightness;
      slices[3] = Lighting._activeEngine.GetColor(x - 1, y) * Lighting.GlobalBrightness;
      slices[6] = Lighting._activeEngine.GetColor(x - 1, y + 1) * Lighting.GlobalBrightness;
      slices[1] = Lighting._activeEngine.GetColor(x, y - 1) * Lighting.GlobalBrightness;
      slices[4] = Lighting._activeEngine.GetColor(x, y) * Lighting.GlobalBrightness;
      slices[7] = Lighting._activeEngine.GetColor(x, y + 1) * Lighting.GlobalBrightness;
      slices[2] = Lighting._activeEngine.GetColor(x + 1, y - 1) * Lighting.GlobalBrightness;
      slices[5] = Lighting._activeEngine.GetColor(x + 1, y) * Lighting.GlobalBrightness;
      slices[8] = Lighting._activeEngine.GetColor(x + 1, y + 1) * Lighting.GlobalBrightness;
    }

    public static void GetCornerColors(
      int centerX,
      int centerY,
      out VertexColors vertices,
      float scale = 1f)
    {
      vertices = new VertexColors();
      int x = centerX;
      int y = centerY;
      Vector3 color1 = Lighting._activeEngine.GetColor(x, y);
      Vector3 color2 = Lighting._activeEngine.GetColor(x, y - 1);
      Vector3 color3 = Lighting._activeEngine.GetColor(x, y + 1);
      Vector3 color4 = Lighting._activeEngine.GetColor(x - 1, y);
      Vector3 color5 = Lighting._activeEngine.GetColor(x + 1, y);
      Vector3 color6 = Lighting._activeEngine.GetColor(x - 1, y - 1);
      Vector3 color7 = Lighting._activeEngine.GetColor(x + 1, y - 1);
      Vector3 color8 = Lighting._activeEngine.GetColor(x - 1, y + 1);
      Vector3 color9 = Lighting._activeEngine.GetColor(x + 1, y + 1);
      float num1 = (float) ((double) Lighting.GlobalBrightness * (double) scale * 63.75);
      int num2 = (int) (((double) color2.X + (double) color6.X + (double) color4.X + (double) color1.X) * (double) num1);
      int num3 = (int) (((double) color2.Y + (double) color6.Y + (double) color4.Y + (double) color1.Y) * (double) num1);
      int num4 = (int) (((double) color2.Z + (double) color6.Z + (double) color4.Z + (double) color1.Z) * (double) num1);
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      if (num4 > (int) byte.MaxValue)
        num4 = (int) byte.MaxValue;
      int num5 = num3 << 8;
      int num6 = num4 << 16;
      vertices.TopLeftColor.PackedValue = (uint) (num2 | num5 | num6 | -16777216);
      int num7 = (int) (((double) color2.X + (double) color7.X + (double) color5.X + (double) color1.X) * (double) num1);
      int num8 = (int) (((double) color2.Y + (double) color7.Y + (double) color5.Y + (double) color1.Y) * (double) num1);
      int num9 = (int) (((double) color2.Z + (double) color7.Z + (double) color5.Z + (double) color1.Z) * (double) num1);
      if (num7 > (int) byte.MaxValue)
        num7 = (int) byte.MaxValue;
      if (num8 > (int) byte.MaxValue)
        num8 = (int) byte.MaxValue;
      if (num9 > (int) byte.MaxValue)
        num9 = (int) byte.MaxValue;
      int num10 = num8 << 8;
      int num11 = num9 << 16;
      vertices.TopRightColor.PackedValue = (uint) (num7 | num10 | num11 | -16777216);
      int num12 = (int) (((double) color3.X + (double) color8.X + (double) color4.X + (double) color1.X) * (double) num1);
      int num13 = (int) (((double) color3.Y + (double) color8.Y + (double) color4.Y + (double) color1.Y) * (double) num1);
      int num14 = (int) (((double) color3.Z + (double) color8.Z + (double) color4.Z + (double) color1.Z) * (double) num1);
      if (num12 > (int) byte.MaxValue)
        num12 = (int) byte.MaxValue;
      if (num13 > (int) byte.MaxValue)
        num13 = (int) byte.MaxValue;
      if (num14 > (int) byte.MaxValue)
        num14 = (int) byte.MaxValue;
      int num15 = num13 << 8;
      int num16 = num14 << 16;
      vertices.BottomLeftColor.PackedValue = (uint) (num12 | num15 | num16 | -16777216);
      int num17 = (int) (((double) color3.X + (double) color9.X + (double) color5.X + (double) color1.X) * (double) num1);
      int num18 = (int) (((double) color3.Y + (double) color9.Y + (double) color5.Y + (double) color1.Y) * (double) num1);
      int num19 = (int) (((double) color3.Z + (double) color9.Z + (double) color5.Z + (double) color1.Z) * (double) num1);
      if (num17 > (int) byte.MaxValue)
        num17 = (int) byte.MaxValue;
      if (num18 > (int) byte.MaxValue)
        num18 = (int) byte.MaxValue;
      if (num19 > (int) byte.MaxValue)
        num19 = (int) byte.MaxValue;
      int num20 = num18 << 8;
      int num21 = num19 << 16;
      vertices.BottomRightColor.PackedValue = (uint) (num17 | num20 | num21 | -16777216);
    }

    public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
    {
      int x = centerX;
      int y = centerY;
      Vector3 color1 = Lighting._activeEngine.GetColor(x, y - 1);
      Vector3 color2 = Lighting._activeEngine.GetColor(x, y + 1);
      Vector3 color3 = Lighting._activeEngine.GetColor(x - 1, y);
      Vector3 color4 = Lighting._activeEngine.GetColor(x + 1, y);
      double num1 = (double) color1.X + (double) color1.Y + (double) color1.Z;
      float num2 = color2.X + color2.Y + color2.Z;
      float num3 = color4.X + color4.Y + color4.Z;
      float num4 = color3.X + color3.Y + color3.Z;
      if (num1 >= (double) num4)
      {
        int num5 = (int) ((double) byte.MaxValue * (double) color3.X * (double) Lighting.GlobalBrightness);
        int num6 = (int) ((double) byte.MaxValue * (double) color3.Y * (double) Lighting.GlobalBrightness);
        int num7 = (int) ((double) byte.MaxValue * (double) color3.Z * (double) Lighting.GlobalBrightness);
        if (num5 > (int) byte.MaxValue)
          num5 = (int) byte.MaxValue;
        if (num6 > (int) byte.MaxValue)
          num6 = (int) byte.MaxValue;
        if (num7 > (int) byte.MaxValue)
          num7 = (int) byte.MaxValue;
        slices[0] = new Color((int) (byte) num5, (int) (byte) num6, (int) (byte) num7, (int) byte.MaxValue);
      }
      else
      {
        int num8 = (int) ((double) byte.MaxValue * (double) color1.X * (double) Lighting.GlobalBrightness);
        int num9 = (int) ((double) byte.MaxValue * (double) color1.Y * (double) Lighting.GlobalBrightness);
        int num10 = (int) ((double) byte.MaxValue * (double) color1.Z * (double) Lighting.GlobalBrightness);
        if (num8 > (int) byte.MaxValue)
          num8 = (int) byte.MaxValue;
        if (num9 > (int) byte.MaxValue)
          num9 = (int) byte.MaxValue;
        if (num10 > (int) byte.MaxValue)
          num10 = (int) byte.MaxValue;
        slices[0] = new Color((int) (byte) num8, (int) (byte) num9, (int) (byte) num10, (int) byte.MaxValue);
      }
      if (num1 >= (double) num3)
      {
        int num11 = (int) ((double) byte.MaxValue * (double) color4.X * (double) Lighting.GlobalBrightness);
        int num12 = (int) ((double) byte.MaxValue * (double) color4.Y * (double) Lighting.GlobalBrightness);
        int num13 = (int) ((double) byte.MaxValue * (double) color4.Z * (double) Lighting.GlobalBrightness);
        if (num11 > (int) byte.MaxValue)
          num11 = (int) byte.MaxValue;
        if (num12 > (int) byte.MaxValue)
          num12 = (int) byte.MaxValue;
        if (num13 > (int) byte.MaxValue)
          num13 = (int) byte.MaxValue;
        slices[1] = new Color((int) (byte) num11, (int) (byte) num12, (int) (byte) num13, (int) byte.MaxValue);
      }
      else
      {
        int num14 = (int) ((double) byte.MaxValue * (double) color1.X * (double) Lighting.GlobalBrightness);
        int num15 = (int) ((double) byte.MaxValue * (double) color1.Y * (double) Lighting.GlobalBrightness);
        int num16 = (int) ((double) byte.MaxValue * (double) color1.Z * (double) Lighting.GlobalBrightness);
        if (num14 > (int) byte.MaxValue)
          num14 = (int) byte.MaxValue;
        if (num15 > (int) byte.MaxValue)
          num15 = (int) byte.MaxValue;
        if (num16 > (int) byte.MaxValue)
          num16 = (int) byte.MaxValue;
        slices[1] = new Color((int) (byte) num14, (int) (byte) num15, (int) (byte) num16, (int) byte.MaxValue);
      }
      if ((double) num2 >= (double) num4)
      {
        int num17 = (int) ((double) byte.MaxValue * (double) color3.X * (double) Lighting.GlobalBrightness);
        int num18 = (int) ((double) byte.MaxValue * (double) color3.Y * (double) Lighting.GlobalBrightness);
        int num19 = (int) ((double) byte.MaxValue * (double) color3.Z * (double) Lighting.GlobalBrightness);
        if (num17 > (int) byte.MaxValue)
          num17 = (int) byte.MaxValue;
        if (num18 > (int) byte.MaxValue)
          num18 = (int) byte.MaxValue;
        if (num19 > (int) byte.MaxValue)
          num19 = (int) byte.MaxValue;
        slices[2] = new Color((int) (byte) num17, (int) (byte) num18, (int) (byte) num19, (int) byte.MaxValue);
      }
      else
      {
        int num20 = (int) ((double) byte.MaxValue * (double) color2.X * (double) Lighting.GlobalBrightness);
        int num21 = (int) ((double) byte.MaxValue * (double) color2.Y * (double) Lighting.GlobalBrightness);
        int num22 = (int) ((double) byte.MaxValue * (double) color2.Z * (double) Lighting.GlobalBrightness);
        if (num20 > (int) byte.MaxValue)
          num20 = (int) byte.MaxValue;
        if (num21 > (int) byte.MaxValue)
          num21 = (int) byte.MaxValue;
        if (num22 > (int) byte.MaxValue)
          num22 = (int) byte.MaxValue;
        slices[2] = new Color((int) (byte) num20, (int) (byte) num21, (int) (byte) num22, (int) byte.MaxValue);
      }
      if ((double) num2 >= (double) num3)
      {
        int num23 = (int) ((double) byte.MaxValue * (double) color4.X * (double) Lighting.GlobalBrightness);
        int num24 = (int) ((double) byte.MaxValue * (double) color4.Y * (double) Lighting.GlobalBrightness);
        int num25 = (int) ((double) byte.MaxValue * (double) color4.Z * (double) Lighting.GlobalBrightness);
        if (num23 > (int) byte.MaxValue)
          num23 = (int) byte.MaxValue;
        if (num24 > (int) byte.MaxValue)
          num24 = (int) byte.MaxValue;
        if (num25 > (int) byte.MaxValue)
          num25 = (int) byte.MaxValue;
        slices[3] = new Color((int) (byte) num23, (int) (byte) num24, (int) (byte) num25, (int) byte.MaxValue);
      }
      else
      {
        int num26 = (int) ((double) byte.MaxValue * (double) color2.X * (double) Lighting.GlobalBrightness);
        int num27 = (int) ((double) byte.MaxValue * (double) color2.Y * (double) Lighting.GlobalBrightness);
        int num28 = (int) ((double) byte.MaxValue * (double) color2.Z * (double) Lighting.GlobalBrightness);
        if (num26 > (int) byte.MaxValue)
          num26 = (int) byte.MaxValue;
        if (num27 > (int) byte.MaxValue)
          num27 = (int) byte.MaxValue;
        if (num28 > (int) byte.MaxValue)
          num28 = (int) byte.MaxValue;
        slices[3] = new Color((int) (byte) num26, (int) (byte) num27, (int) (byte) num28, (int) byte.MaxValue);
      }
    }

    public static void GetColor4Slice(int x, int y, ref Vector3[] slices)
    {
      Vector3 color1 = Lighting._activeEngine.GetColor(x, y - 1);
      Vector3 color2 = Lighting._activeEngine.GetColor(x, y + 1);
      Vector3 color3 = Lighting._activeEngine.GetColor(x - 1, y);
      Vector3 color4 = Lighting._activeEngine.GetColor(x + 1, y);
      double num1 = (double) color1.X + (double) color1.Y + (double) color1.Z;
      float num2 = color2.X + color2.Y + color2.Z;
      float num3 = color4.X + color4.Y + color4.Z;
      float num4 = color3.X + color3.Y + color3.Z;
      slices[0] = num1 < (double) num4 ? color1 * Lighting.GlobalBrightness : color3 * Lighting.GlobalBrightness;
      slices[1] = num1 < (double) num3 ? color1 * Lighting.GlobalBrightness : color4 * Lighting.GlobalBrightness;
      slices[2] = (double) num2 < (double) num4 ? color2 * Lighting.GlobalBrightness : color3 * Lighting.GlobalBrightness;
      if ((double) num2 >= (double) num3)
        slices[3] = color4 * Lighting.GlobalBrightness;
      else
        slices[3] = color2 * Lighting.GlobalBrightness;
    }
  }
}
