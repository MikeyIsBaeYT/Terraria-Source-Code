// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.GemCaveShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class GemCaveShader : ChromaShader
  {
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;
    private static readonly Vector4[] _gemColors = new Vector4[7]
    {
      Color.White.ToVector4(),
      Color.Yellow.ToVector4(),
      Color.Orange.ToVector4(),
      Color.Red.ToVector4(),
      Color.Green.ToVector4(),
      Color.Blue.ToVector4(),
      Color.Purple.ToVector4()
    };

    public GemCaveShader(Color primaryColor, Color secondaryColor)
    {
      this._primaryColor = primaryColor.ToVector4();
      this._secondaryColor = secondaryColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      time *= 0.25f;
      float num1 = time % 1f;
      int num2 = (double) time % 2.0 > 1.0 ? 1 : 0;
      Vector4 vector4_1 = num2 != 0 ? this._secondaryColor : this._primaryColor;
      Vector4 vector4_2 = num2 != 0 ? this._primaryColor : this._secondaryColor;
      float num3 = num1 * 1.2f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        float staticNoise = NoiseHelper.GetStaticNoise(canvasPositionOfIndex * 0.5f + new Vector2(0.0f, time * 0.5f));
        Vector4 vector4_3 = vector4_1;
        float num4 = staticNoise + num3;
        if ((double) num4 > 0.999000012874603)
        {
          float amount = MathHelper.Clamp((float) (((double) num4 - 0.999000012874603) / 0.200000002980232), 0.0f, 1f);
          vector4_3 = Vector4.Lerp(vector4_3, vector4_2, amount);
        }
        float amount1 = Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(gridPositionOfIndex.X, gridPositionOfIndex.Y, time / 100f) * 20.0));
        Vector4 vector4_4 = Vector4.Lerp(vector4_3, GemCaveShader._gemColors[((gridPositionOfIndex.Y * 47 + gridPositionOfIndex.X) % GemCaveShader._gemColors.Length + GemCaveShader._gemColors.Length) % GemCaveShader._gemColors.Length], amount1);
        fragment.SetColor(index, vector4_4);
        fragment.SetColor(index, vector4_4);
      }
    }
  }
}
