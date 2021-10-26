// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.PirateInvasionShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class PirateInvasionShader : ChromaShader
  {
    private readonly Vector4 _cannonBallColor;
    private readonly Vector4 _splashColor;
    private readonly Vector4 _waterColor;
    private readonly Vector4 _backgroundColor;

    public PirateInvasionShader(
      Color cannonBallColor,
      Color splashColor,
      Color waterColor,
      Color backgroundColor)
    {
      this._cannonBallColor = cannonBallColor.ToVector4();
      this._splashColor = splashColor.ToVector4();
      this._waterColor = waterColor.ToVector4();
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
        Vector4 vector4 = Vector4.Lerp(this._waterColor, this._cannonBallColor, (float) (Math.Sin((double) time * 0.5 + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
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
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        gridPositionOfIndex.X /= 2;
        double num1 = ((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 40.0 + (double) time * 1.0) % 40.0;
        float amount1 = 0.0f;
        float num2 = (float) (num1 - (double) canvasPositionOfIndex.Y / 1.20000004768372);
        if (num1 > 1.0)
        {
          float num3 = (float) (1.0 - (double) canvasPositionOfIndex.Y / 1.20000004768372);
          amount1 = (float) ((1.0 - (double) Math.Min(1f, num2 - num3)) * (1.0 - (double) Math.Min(1f, num3 / 1f)));
        }
        Vector4 vector4 = this._backgroundColor;
        if ((double) num2 > 0.0)
        {
          float amount2 = Math.Max(0.0f, (float) (1.20000004768372 - (double) num2 * 4.0));
          if ((double) num2 < 0.100000001490116)
            amount2 = num2 / 0.1f;
          vector4 = Vector4.Lerp(Vector4.Lerp(vector4, this._cannonBallColor, amount2), this._splashColor, amount1);
        }
        if ((double) canvasPositionOfIndex.Y > 0.800000011920929)
          vector4 = this._waterColor;
        fragment.SetColor(index, vector4);
      }
    }
  }
}
