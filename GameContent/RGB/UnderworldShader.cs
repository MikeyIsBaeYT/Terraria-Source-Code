// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.UnderworldShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class UnderworldShader : ChromaShader
  {
    private readonly Vector4 _backColor;
    private readonly Vector4 _frontColor;
    private readonly float _speed;

    public UnderworldShader(Color backColor, Color frontColor, float speed)
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
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector4 vector4 = Vector4.Lerp(this._backColor, this._frontColor, NoiseHelper.GetDynamicNoise(fragment.GetCanvasPositionOfIndex(index) * 0.5f, (float) ((double) time * (double) this._speed / 3.0)));
        fragment.SetColor(index, vector4);
      }
    }
  }
}
