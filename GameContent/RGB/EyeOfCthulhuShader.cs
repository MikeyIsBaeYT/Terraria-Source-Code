// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.EyeOfCthulhuShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class EyeOfCthulhuShader : ChromaShader
  {
    private readonly Vector4 _eyeColor;
    private readonly Vector4 _veinColor;
    private readonly Vector4 _backgroundColor;

    public EyeOfCthulhuShader(Color eyeColor, Color veinColor, Color backgroundColor)
    {
      this._eyeColor = eyeColor.ToVector4();
      this._veinColor = veinColor.ToVector4();
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
        Vector4 vector4 = Vector4.Lerp(this._veinColor, this._eyeColor, (float) (Math.Sin((double) time + (double) canvasPositionOfIndex.X * 4.0) * 0.5 + 0.5));
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
      if (device.Type != null && device.Type != 6)
      {
        this.ProcessLowDetail(device, fragment, quality, time);
      }
      else
      {
        float num1 = (float) ((double) time * 0.200000002980232 % 2.0);
        int num2 = 1;
        if ((double) num1 > 1.0)
        {
          num1 = 2f - num1;
          num2 = -1;
        }
        Vector2 vector2_1 = new Vector2((float) ((double) num1 * 7.0 - 3.5), 0.0f) + fragment.CanvasCenter;
        for (int index = 0; index < fragment.Count; ++index)
        {
          Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
          Vector4 vector4_1 = this._backgroundColor;
          Vector2 vector2_2 = vector2_1;
          Vector2 vector2_3 = canvasPositionOfIndex - vector2_2;
          float num3 = vector2_3.Length();
          if ((double) num3 < 0.5)
          {
            float amount1 = 1f - MathHelper.Clamp((float) (((double) num3 - 0.5 + 0.200000002980232) / 0.200000002980232), 0.0f, 1f);
            float amount2 = MathHelper.Clamp((float) (((double) vector2_3.X + 0.5 - 0.200000002980232) / 0.600000023841858), 0.0f, 1f);
            if (num2 == 1)
              amount2 = 1f - amount2;
            Vector4 vector4_2 = Vector4.Lerp(this._eyeColor, this._veinColor, amount2);
            vector4_1 = Vector4.Lerp(vector4_1, vector4_2, amount1);
          }
          fragment.SetColor(index, vector4_1);
        }
      }
    }
  }
}
