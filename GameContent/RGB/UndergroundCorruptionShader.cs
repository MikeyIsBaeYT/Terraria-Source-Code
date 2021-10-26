// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.UndergroundCorruptionShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class UndergroundCorruptionShader : ChromaShader
  {
    private readonly Vector4 _corruptionColor = new Vector4(Color.Purple.ToVector3() * 0.2f, 1f);
    private readonly Vector4 _flameColor = Color.Green.ToVector4();
    private readonly Vector4 _flameTipColor = Color.Yellow.ToVector4();

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = Vector4.Lerp(this._flameColor, this._flameTipColor, 0.25f);
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_2 = Vector4.Lerp(this._corruptionColor, vector4_1, (float) (Math.Sin((double) time + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
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
      for (int index = 0; index < fragment.Count; ++index)
      {
        fragment.GetGridPositionOfIndex(index);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        float dynamicNoise = NoiseHelper.GetDynamicNoise(canvasPositionOfIndex * 0.3f + new Vector2(12.5f, time * 0.05f), time * 0.1f);
        float amount = MathHelper.Clamp(Math.Max(0.0f, (float) (1.0 - (double) dynamicNoise * (double) dynamicNoise * 4.0 * (1.20000004768372 - (double) canvasPositionOfIndex.Y))) * canvasPositionOfIndex.Y, 0.0f, 1f);
        Vector4 vector4 = Vector4.Lerp(this._corruptionColor, Vector4.Lerp(this._flameColor, this._flameTipColor, amount), amount);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
