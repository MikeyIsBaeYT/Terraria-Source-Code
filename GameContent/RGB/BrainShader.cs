// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.BrainShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class BrainShader : ChromaShader
  {
    private readonly Vector4 _brainColor;
    private readonly Vector4 _veinColor;

    public BrainShader(Color brainColor, Color veinColor)
    {
      this._brainColor = brainColor.ToVector4();
      this._veinColor = veinColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4 = Vector4.Lerp(this._brainColor, this._veinColor, Math.Max(0.0f, (float) Math.Sin((double) time * 3.0)));
      for (int index = 0; index < fragment.Count; ++index)
        fragment.SetColor(index, vector4);
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector2 vector2 = new Vector2(1.6f, 0.5f);
      Vector4 vector4_1 = Vector4.Lerp(this._brainColor, this._veinColor, (float) ((double) Math.Max(0.0f, (float) Math.Sin((double) time * 3.0)) * 0.5 + 0.5));
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 brainColor = this._brainColor;
        float amount = Math.Max(0.0f, (float) (1.0 - 5.0 * (Math.Sin((double) NoiseHelper.GetDynamicNoise(canvasPositionOfIndex * 0.15f + new Vector2(time * (1f / 500f)), time * 0.03f) * 10.0) * 0.5 + 0.5)));
        Vector4 vector4_2 = Vector4.Lerp(brainColor, vector4_1, amount);
        fragment.SetColor(index, vector4_2);
      }
    }
  }
}
