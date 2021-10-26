// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.MartianMadnessShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class MartianMadnessShader : ChromaShader
  {
    private readonly Vector4 _metalColor;
    private readonly Vector4 _glassColor;
    private readonly Vector4 _beamColor;
    private readonly Vector4 _backgroundColor;

    public MartianMadnessShader(
      Color metalColor,
      Color glassColor,
      Color beamColor,
      Color backgroundColor)
    {
      this._metalColor = metalColor.ToVector4();
      this._glassColor = glassColor.ToVector4();
      this._beamColor = beamColor.ToVector4();
      this._backgroundColor = backgroundColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        float amount = (float) (Math.Sin((double) time * 2.0 + (double) canvasPositionOfIndex.X * 5.0) * 0.5 + 0.5);
        int num = (gridPositionOfIndex.X + gridPositionOfIndex.Y) % 2;
        if (num < 0)
          num += 2;
        Vector4 vector4 = num == 1 ? Vector4.Lerp(this._glassColor, this._beamColor, amount) : this._metalColor;
        fragment.SetColor(index, vector4);
      }
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      if (device.Type != null && device.Type != 6)
      {
        this.ProcessLowDetail(device, fragment, quality, time);
      }
      else
      {
        float num1 = (float) ((double) time * 0.5 % 6.28318548202515);
        if ((double) num1 > 3.14159274101257)
          num1 = 6.283185f - num1;
        Vector2 vector2_1 = new Vector2((float) (1.70000004768372 + Math.Cos((double) num1) * 2.0), (float) (Math.Sin((double) num1) * 1.10000002384186 - 0.5));
        for (int index = 0; index < fragment.Count; ++index)
        {
          Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
          Vector4 vector4 = this._backgroundColor;
          float num2 = Math.Abs(vector2_1.X - canvasPositionOfIndex.X);
          if ((double) canvasPositionOfIndex.Y > (double) vector2_1.Y && (double) num2 < 0.200000002980232)
          {
            float num3 = 1f - MathHelper.Clamp((float) (((double) num2 - 0.200000002980232 + 0.200000002980232) / 0.200000002980232), 0.0f, 1f);
            float num4 = Math.Max(0.0f, (float) (1.0 - (double) Math.Abs((float) (((double) num1 - 1.57079637050629) / 1.57079637050629)) * 3.0));
            vector4 = Vector4.Lerp(vector4, this._beamColor, num3 * num4);
          }
          Vector2 vector2_2 = vector2_1 - canvasPositionOfIndex;
          vector2_2.X /= 1f;
          vector2_2.Y /= 0.2f;
          float num5 = vector2_2.Length();
          if ((double) num5 < 1.0)
          {
            float amount = 1f - MathHelper.Clamp((float) (((double) num5 - 1.0 + 0.200000002980232) / 0.200000002980232), 0.0f, 1f);
            vector4 = Vector4.Lerp(vector4, this._metalColor, amount);
          }
          Vector2 vector2_3 = vector2_1 - canvasPositionOfIndex + new Vector2(0.0f, -0.1f);
          vector2_3.X /= 0.3f;
          vector2_3.Y /= 0.3f;
          if ((double) vector2_3.Y < 0.0)
            vector2_3.Y *= 2f;
          float num6 = vector2_3.Length();
          if ((double) num6 < 1.0)
          {
            float amount = 1f - MathHelper.Clamp((float) (((double) num6 - 1.0 + 0.200000002980232) / 0.200000002980232), 0.0f, 1f);
            vector4 = Vector4.Lerp(vector4, this._glassColor, amount);
          }
          fragment.SetColor(index, vector4);
        }
      }
    }
  }
}
