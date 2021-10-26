// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.SurfaceBiomeShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class SurfaceBiomeShader : ChromaShader
  {
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;
    private Vector4 _surfaceColor;
    private float _starVisibility;

    public SurfaceBiomeShader(Color primaryColor, Color secondaryColor)
    {
      this._primaryColor = primaryColor.ToVector4();
      this._secondaryColor = secondaryColor.ToVector4();
    }

    public virtual void Update(float elapsedTime)
    {
      this._surfaceColor = Main.ColorOfTheSkies.ToVector4() * 0.75f + Vector4.One * 0.25f;
      if (Main.dayTime)
      {
        float num = (float) (Main.time / 54000.0);
        if ((double) num < 0.25)
        {
          this._starVisibility = (float) (1.0 - (double) num / 0.25);
        }
        else
        {
          if ((double) num <= 0.75)
            return;
          this._starVisibility = (float) (((double) num - 0.75) / 0.25);
        }
      }
      else
        this._starVisibility = 1f;
    }

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = this._primaryColor * this._surfaceColor;
      Vector4 vector4_2 = this._secondaryColor * this._surfaceColor;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_3 = Vector4.Lerp(vector4_1, vector4_2, (float) (Math.Sin((double) time * 0.5 + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
        fragment.SetColor(index, vector4_3);
      }
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = this._primaryColor * this._surfaceColor;
      Vector4 vector4_2 = this._secondaryColor * this._surfaceColor;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        float amount = (float) (Math.Sin((double) canvasPositionOfIndex.X * 1.5 + (double) canvasPositionOfIndex.Y + (double) time) * 0.5 + 0.5);
        Vector4 vector4_3 = Vector4.Max(Vector4.Lerp(vector4_1, vector4_2, amount), new Vector4(Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(gridPositionOfIndex.X, gridPositionOfIndex.Y, time / 60f) * 20.0)) * (1f - this._surfaceColor.X) * this._starVisibility));
        fragment.SetColor(index, vector4_3);
      }
    }
  }
}
