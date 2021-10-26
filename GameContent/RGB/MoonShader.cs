// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.MoonShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class MoonShader : ChromaShader
  {
    private readonly Vector4 _moonCoreColor;
    private readonly Vector4 _moonRingColor;
    private readonly Vector4 _skyColor;
    private readonly Vector4 _cloudColor;
    private float _progress;

    public MoonShader(Color skyColor, Color moonRingColor, Color moonCoreColor)
      : this(skyColor, moonRingColor, moonCoreColor, Color.White)
    {
    }

    public MoonShader(Color skyColor, Color moonColor)
      : this(skyColor, moonColor, moonColor)
    {
    }

    public MoonShader(Color skyColor, Color moonRingColor, Color moonCoreColor, Color cloudColor)
    {
      this._skyColor = skyColor.ToVector4();
      this._moonRingColor = moonRingColor.ToVector4();
      this._moonCoreColor = moonCoreColor.ToVector4();
      this._cloudColor = cloudColor.ToVector4();
    }

    public virtual void Update(float elapsedTime)
    {
      if (Main.dayTime)
        this._progress = (float) (Main.time / 54000.0);
      else
        this._progress = (float) (Main.time / 32400.0);
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
        Vector4 vector4 = Vector4.Lerp(this._skyColor, this._cloudColor, (float) Math.Sqrt((double) Math.Max(0.0f, (float) (1.0 - 2.0 * (double) NoiseHelper.GetDynamicNoise(fragment.GetCanvasPositionOfIndex(index) * new Vector2(0.1f, 0.5f) + new Vector2(time * 0.02f, 0.0f), time / 40f)))) * 0.1f);
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
        Vector2 vector2_1 = new Vector2(2f, 0.5f);
        Vector2 vector2_2 = new Vector2(2.5f, 1f);
        float num1 = (float) ((double) this._progress * 3.14159274101257 + 3.14159274101257);
        Vector2 vector2_3 = new Vector2((float) Math.Cos((double) num1), (float) Math.Sin((double) num1)) * vector2_2 + vector2_1;
        for (int index = 0; index < fragment.Count; ++index)
        {
          Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
          float num2 = (float) Math.Sqrt((double) Math.Max(0.0f, (float) (1.0 - 2.0 * (double) NoiseHelper.GetDynamicNoise(canvasPositionOfIndex * new Vector2(0.1f, 0.5f) + new Vector2(time * 0.02f, 0.0f), time / 40f))));
          float num3 = (canvasPositionOfIndex - vector2_3).Length();
          Vector4 vector4 = Vector4.Lerp(this._skyColor, this._cloudColor, num2 * 0.15f);
          if ((double) num3 < 0.800000011920929)
            vector4 = Vector4.Lerp(this._moonRingColor, this._moonCoreColor, Math.Min(0.1f, 0.8f - num3) / 0.1f);
          else if ((double) num3 < 1.0)
            vector4 = Vector4.Lerp(vector4, this._moonRingColor, Math.Min(0.2f, 1f - num3) / 0.2f);
          fragment.SetColor(index, vector4);
        }
      }
    }
  }
}
