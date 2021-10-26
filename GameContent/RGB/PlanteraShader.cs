// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.PlanteraShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class PlanteraShader : ChromaShader
  {
    private readonly Vector4 _bulbColor;
    private readonly Vector4 _vineColor;
    private readonly Vector4 _backgroundColor;

    public PlanteraShader(Color bulbColor, Color vineColor, Color backgroundColor)
    {
      this._bulbColor = bulbColor.ToVector4();
      this._vineColor = vineColor.ToVector4();
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
        Vector4 vector4 = Vector4.Lerp(this._bulbColor, this._vineColor, (float) (Math.Sin((double) time * 2.0 + (double) canvasPositionOfIndex.X * 10.0) * 0.5 + 0.5));
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
        canvasPositionOfIndex.X -= 1.8f;
        if ((double) canvasPositionOfIndex.X < 0.0)
        {
          canvasPositionOfIndex.X *= -1f;
          gridPositionOfIndex.Y += 101;
        }
        float num1 = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.Y) * 5.0 + (double) time * 0.400000005960464) % 5.0);
        float num2 = 1f;
        if ((double) num1 > 1.0)
        {
          num2 = 1f - MathHelper.Clamp((float) (((double) num1 - 0.400000005960464 - 1.0) / 0.400000005960464), 0.0f, 1f);
          num1 = 1f;
        }
        float num3 = num1 - canvasPositionOfIndex.X / 5f;
        Vector4 vector4 = this._backgroundColor;
        if ((double) num3 > 0.0)
        {
          float num4 = 1f;
          if ((double) num3 < 0.200000002980232)
            num4 = num3 / 0.2f;
          vector4 = (gridPositionOfIndex.X + 7 * gridPositionOfIndex.Y) % 5 != 0 ? Vector4.Lerp(this._backgroundColor, this._vineColor, num4 * num2) : Vector4.Lerp(this._backgroundColor, this._bulbColor, num4 * num2);
        }
        fragment.SetColor(index, vector4);
      }
    }
  }
}
