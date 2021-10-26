// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.HallowSurfaceShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class HallowSurfaceShader : ChromaShader
  {
    private readonly Vector4 _skyColor = new Color(150, 220, 220).ToVector4();
    private readonly Vector4 _groundColor = new Vector4(1f, 0.2f, 0.25f, 1f);
    private readonly Vector4 _pinkFlowerColor = new Vector4(1f, 0.2f, 0.25f, 1f);
    private readonly Vector4 _yellowFlowerColor = new Vector4(1f, 1f, 0.0f, 1f);
    private Vector4 _lightColor;

    public virtual void Update(float elapsedTime) => this._lightColor = Main.ColorOfTheSkies.ToVector4() * 0.75f + Vector4.One * 0.25f;

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
        Vector4 vector4 = Vector4.Lerp(this._skyColor, this._groundColor, (float) (Math.Sin((double) time + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
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
      Vector4 vector4_1 = this._skyColor * this._lightColor;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        float amount = Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(gridPositionOfIndex.X, gridPositionOfIndex.Y, time / 20f) * 5.0));
        Vector4 vector4_2 = vector4_1;
        Vector4 vector4_3 = (gridPositionOfIndex.X * 100 + gridPositionOfIndex.Y) % 2 != 0 ? Vector4.Lerp(vector4_2, this._pinkFlowerColor, amount) : Vector4.Lerp(vector4_2, this._yellowFlowerColor, amount);
        if ((double) canvasPositionOfIndex.Y > Math.Sin((double) canvasPositionOfIndex.X) * 0.300000011920929 + 0.699999988079071)
          vector4_3 = this._groundColor;
        fragment.SetColor(index, vector4_3);
      }
    }
  }
}
