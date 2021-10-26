// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.CavernShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class CavernShader : ChromaShader
  {
    private readonly Vector4 _backColor;
    private readonly Vector4 _frontColor;
    private readonly float _speed;

    public CavernShader(Color backColor, Color frontColor, float speed)
    {
      this._backColor = backColor.ToVector4();
      this._frontColor = frontColor.ToVector4();
      this._speed = speed;
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
        Vector4 vector4 = Vector4.Lerp(this._backColor, this._frontColor, (float) (Math.Sin((double) time * (double) this._speed + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
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
      time *= this._speed * 0.5f;
      float num1 = time % 1f;
      int num2 = (double) time % 2.0 > 1.0 ? 1 : 0;
      Vector4 vector4_1 = num2 != 0 ? this._frontColor : this._backColor;
      Vector4 vector4_2 = num2 != 0 ? this._backColor : this._frontColor;
      float num3 = num1 * 1.2f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        float staticNoise = NoiseHelper.GetStaticNoise(fragment.GetCanvasPositionOfIndex(index) * 0.5f + new Vector2(0.0f, time * 0.5f));
        Vector4 vector4_3 = vector4_1;
        float num4 = staticNoise + num3;
        if ((double) num4 > 0.999000012874603)
        {
          float amount = MathHelper.Clamp((float) (((double) num4 - 0.999000012874603) / 0.200000002980232), 0.0f, 1f);
          vector4_3 = Vector4.Lerp(vector4_3, vector4_2, amount);
        }
        fragment.SetColor(index, vector4_3);
      }
    }
  }
}
