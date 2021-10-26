// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.LavaIndicatorShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class LavaIndicatorShader : ChromaShader
  {
    private readonly Vector4 _backgroundColor;
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;

    public LavaIndicatorShader(Color backgroundColor, Color primaryColor, Color secondaryColor)
    {
      this._backgroundColor = backgroundColor.ToVector4();
      this._primaryColor = primaryColor.ToVector4();
      this._secondaryColor = secondaryColor.ToVector4();
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
        float staticNoise = NoiseHelper.GetStaticNoise(fragment.GetCanvasPositionOfIndex(index) * 0.3f + new Vector2(12.5f, time * 0.2f));
        Vector4 vector4 = Vector4.Lerp(this._primaryColor, this._secondaryColor, MathHelper.Clamp(Math.Max(0.0f, (float) (1.0 - (double) staticNoise * (double) staticNoise * 4.0 * (double) staticNoise)), 0.0f, 1f));
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
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_1 = this._backgroundColor;
        float num1 = 0.4f + NoiseHelper.GetDynamicNoise(canvasPositionOfIndex * 0.2f, time * 0.5f) * 0.4f;
        float num2 = 1.1f - canvasPositionOfIndex.Y;
        if ((double) num2 < (double) num1)
        {
          float staticNoise = NoiseHelper.GetStaticNoise(canvasPositionOfIndex * 0.3f + new Vector2(12.5f, time * 0.2f));
          Vector4 vector4_2 = Vector4.Lerp(this._primaryColor, this._secondaryColor, MathHelper.Clamp(Math.Max(0.0f, (float) (1.0 - (double) staticNoise * (double) staticNoise * 4.0 * (double) staticNoise)), 0.0f, 1f));
          float amount = 1f - MathHelper.Clamp((float) (((double) num2 - (double) num1 + 0.200000002980232) / 0.200000002980232), 0.0f, 1f);
          vector4_1 = Vector4.Lerp(vector4_1, vector4_2, amount);
        }
        fragment.SetColor(index, vector4_1);
      }
    }
  }
}
