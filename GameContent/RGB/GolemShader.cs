// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.GolemShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class GolemShader : ChromaShader
  {
    private readonly Vector4 _glowColor;
    private readonly Vector4 _coreColor;
    private readonly Vector4 _backgroundColor;

    public GolemShader(Color glowColor, Color coreColor, Color backgroundColor)
    {
      this._glowColor = glowColor.ToVector4();
      this._coreColor = coreColor.ToVector4();
      this._backgroundColor = backgroundColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = Vector4.Lerp(this._backgroundColor, this._coreColor, Math.Max(0.0f, (float) Math.Sin((double) time * 0.5)));
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_2 = Vector4.Lerp(vector4_1, this._glowColor, Math.Max(0.0f, (float) Math.Sin((double) canvasPositionOfIndex.X * 2.0 + (double) time + 101.0)));
        fragment.SetColor(index, vector4_2);
      }
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      float num1 = (float) (0.5 + Math.Sin((double) time * 3.0) * 0.100000001490116);
      Vector2 vector2 = new Vector2(1.6f, 0.5f);
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector4 vector4 = this._backgroundColor;
        float num2 = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.Y) * 10.0 + (double) time * 2.0) % 10.0) - Math.Abs(canvasPositionOfIndex.X - vector2.X);
        if ((double) num2 > 0.0)
        {
          float amount = Math.Max(0.0f, 1.2f - num2);
          if ((double) num2 < 0.200000002980232)
            amount = num2 * 5f;
          vector4 = Vector4.Lerp(vector4, this._glowColor, amount);
        }
        float num3 = (canvasPositionOfIndex - vector2).Length();
        if ((double) num3 < (double) num1)
        {
          float amount = 1f - MathHelper.Clamp((float) (((double) num3 - (double) num1 + 0.100000001490116) / 0.100000001490116), 0.0f, 1f);
          vector4 = Vector4.Lerp(vector4, this._coreColor, amount);
        }
        fragment.SetColor(index, vector4);
      }
    }
  }
}
