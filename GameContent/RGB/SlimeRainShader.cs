// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.SlimeRainShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class SlimeRainShader : ChromaShader
  {
    private static readonly Vector4[] _colors = new Vector4[3]
    {
      Color.Blue.ToVector4(),
      Color.Green.ToVector4(),
      Color.Purple.ToVector4()
    };

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = new Vector4(0.0f, 0.0f, 0.0f, 0.75f);
      for (int index1 = 0; index1 < fragment.Count; ++index1)
      {
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index1);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index1);
        float num = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 7.0 + (double) time * 0.400000005960464) % 7.0) - canvasPositionOfIndex.Y;
        Vector4 vector4_2 = vector4_1;
        if ((double) num > 0.0)
        {
          float amount = Math.Max(0.0f, 1.2f - num);
          if ((double) num < 0.400000005960464)
            amount = num / 0.4f;
          int index2 = (gridPositionOfIndex.X % SlimeRainShader._colors.Length + SlimeRainShader._colors.Length) % SlimeRainShader._colors.Length;
          vector4_2 = Vector4.Lerp(vector4_2, SlimeRainShader._colors[index2], amount);
        }
        fragment.SetColor(index1, vector4_2);
      }
    }
  }
}
