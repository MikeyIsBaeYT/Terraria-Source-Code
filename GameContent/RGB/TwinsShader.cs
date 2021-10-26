// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.TwinsShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class TwinsShader : ChromaShader
  {
    private readonly Vector4 _eyeColor;
    private readonly Vector4 _veinColor;
    private readonly Vector4 _laserColor;
    private readonly Vector4 _mouthColor;
    private readonly Vector4 _flameColor;
    private readonly Vector4 _backgroundColor;
    private static readonly Vector4[] _irisColors = new Vector4[2]
    {
      Color.Green.ToVector4(),
      Color.Blue.ToVector4()
    };

    public TwinsShader(
      Color eyeColor,
      Color veinColor,
      Color laserColor,
      Color mouthColor,
      Color flameColor,
      Color backgroundColor)
    {
      this._eyeColor = eyeColor.ToVector4();
      this._veinColor = veinColor.ToVector4();
      this._laserColor = laserColor.ToVector4();
      this._mouthColor = mouthColor.ToVector4();
      this._flameColor = flameColor.ToVector4();
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
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector4 vector4_1 = Vector4.Lerp(this._veinColor, this._eyeColor, (float) (Math.Sin((double) time + (double) canvasPositionOfIndex.X * 4.0) * 0.5 + 0.5));
        float amount = Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(gridPositionOfIndex.X, gridPositionOfIndex.Y, time / 25f) * 5.0));
        Vector4 vector4_2 = Vector4.Lerp(vector4_1, TwinsShader._irisColors[((gridPositionOfIndex.Y * 47 + gridPositionOfIndex.X) % TwinsShader._irisColors.Length + TwinsShader._irisColors.Length) % TwinsShader._irisColors.Length], amount);
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
      if (device.Type != null && device.Type != 6)
      {
        this.ProcessLowDetail(device, fragment, quality, time);
      }
      else
      {
        bool flag = true;
        float num1 = (float) ((double) time * 0.100000001490116 % 2.0);
        if ((double) num1 > 1.0)
        {
          num1 = 2f - num1;
          flag = false;
        }
        Vector2 vector2_1 = new Vector2((float) ((double) num1 * 7.0 - 3.5), 0.0f) + fragment.CanvasCenter;
        for (int index = 0; index < fragment.Count; ++index)
        {
          Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
          Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
          Vector4 vector4_1 = this._backgroundColor;
          Vector2 vector2_2 = canvasPositionOfIndex - vector2_1;
          float num2 = vector2_2.Length();
          if ((double) num2 < 0.5)
          {
            float amount1 = 1f - MathHelper.Clamp((float) (((double) num2 - 0.5 + 0.200000002980232) / 0.200000002980232), 0.0f, 1f);
            float amount2 = MathHelper.Clamp((float) (((double) vector2_2.X + 0.5 - 0.200000002980232) / 0.600000023841858), 0.0f, 1f);
            if (flag)
              amount2 = 1f - amount2;
            Vector4 vector4_2 = Vector4.Lerp(this._eyeColor, this._veinColor, amount2);
            float num3 = (float) Math.Atan2((double) vector2_2.Y, (double) vector2_2.X);
            if (!flag && 3.14159274101257 - (double) Math.Abs(num3) < 0.600000023841858)
              vector4_2 = this._mouthColor;
            vector4_1 = Vector4.Lerp(vector4_1, vector4_2, amount1);
          }
          if (flag && gridPositionOfIndex.Y == 3 && (double) canvasPositionOfIndex.X > (double) vector2_1.X)
          {
            float num4 = (float) (1.0 - (double) Math.Abs((float) ((double) canvasPositionOfIndex.X - (double) vector2_1.X * 2.0 - 0.5)) / 0.5);
            vector4_1 = Vector4.Lerp(vector4_1, this._laserColor, MathHelper.Clamp(num4, 0.0f, 1f));
          }
          else if (!flag)
          {
            Vector2 vector2_3 = canvasPositionOfIndex - (vector2_1 - new Vector2(1.2f, 0.0f));
            vector2_3.Y *= 3.5f;
            float num5 = vector2_3.Length();
            if ((double) num5 < 0.699999988079071)
            {
              float dynamicNoise = NoiseHelper.GetDynamicNoise(canvasPositionOfIndex, time);
              float amount = dynamicNoise * dynamicNoise * dynamicNoise * (1f - MathHelper.Clamp((float) (((double) num5 - 0.699999988079071 + 0.300000011920929) / 0.300000011920929), 0.0f, 1f));
              vector4_1 = Vector4.Lerp(vector4_1, this._flameColor, amount);
            }
          }
          fragment.SetColor(index, vector4_1);
        }
      }
    }
  }
}
