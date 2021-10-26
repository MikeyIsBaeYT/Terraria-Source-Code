// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.GoblinArmyShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class GoblinArmyShader : ChromaShader
  {
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;

    public GoblinArmyShader(Color primaryColor, Color secondaryColor)
    {
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
      time *= 0.5f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        canvasPositionOfIndex.Y = 1f;
        float staticNoise = NoiseHelper.GetStaticNoise(canvasPositionOfIndex * 0.3f + new Vector2(12.5f, time * 0.2f));
        float amount = MathHelper.Clamp(Math.Max(0.0f, (float) (1.0 - (double) staticNoise * (double) staticNoise * 4.0 * (double) staticNoise)), 0.0f, 1f);
        Vector4 vector4 = Vector4.Lerp(new Vector4(0.0f, 0.0f, 0.0f, 1f), Vector4.Lerp(Vector4.Lerp(this._primaryColor, this._secondaryColor, amount), Vector4.One, amount * amount), amount);
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
        float staticNoise = NoiseHelper.GetStaticNoise(canvasPositionOfIndex * 0.3f + new Vector2(12.5f, time * 0.2f));
        float amount = MathHelper.Clamp(Math.Max(0.0f, (float) (1.0 - (double) staticNoise * (double) staticNoise * 4.0 * (double) staticNoise * (1.20000004768372 - (double) canvasPositionOfIndex.Y))) * canvasPositionOfIndex.Y * canvasPositionOfIndex.Y, 0.0f, 1f);
        Vector4 vector4 = Vector4.Lerp(new Vector4(0.0f, 0.0f, 0.0f, 1f), Vector4.Lerp(Vector4.Lerp(this._primaryColor, this._secondaryColor, amount), Vector4.One, amount * amount * amount), amount);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
