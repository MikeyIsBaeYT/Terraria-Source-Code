// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.DD2Shader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;

namespace Terraria.GameContent.RGB
{
  public class DD2Shader : ChromaShader
  {
    private readonly Vector4 _darkGlowColor;
    private readonly Vector4 _lightGlowColor;

    public DD2Shader(Color darkGlowColor, Color lightGlowColor)
    {
      this._darkGlowColor = darkGlowColor.ToVector4();
      this._lightGlowColor = lightGlowColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector2 vector2_1 = fragment.CanvasCenter;
      if (quality == null)
        vector2_1 = new Vector2(1.7f, 0.5f);
      time *= 0.5f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_1 = new Vector4(0.0f, 0.0f, 0.0f, 1f);
        Vector2 vector2_2 = vector2_1;
        float num1 = (canvasPositionOfIndex - vector2_2).Length();
        float num2 = (float) ((double) num1 * (double) num1 * 0.75);
        float num3 = (float) (((double) num1 - (double) time) % 1.0);
        if ((double) num3 < 0.0)
          ++num3;
        float num4 = (double) num3 <= 0.800000011920929 ? num3 / 0.8f : num3 * (float) (1.0 - ((double) num3 - 1.0 + 0.200000002980232) / 0.200000002980232);
        Vector4 vector4_2 = Vector4.Lerp(this._darkGlowColor, this._lightGlowColor, num4 * num4);
        float amount1 = num4 * (float) ((double) MathHelper.Clamp(1f - num2, 0.0f, 1f) * 0.75 + 0.25);
        vector4_1 = Vector4.Lerp(vector4_1, vector4_2, amount1);
        if ((double) num1 < 0.5)
        {
          float amount2 = 1f - MathHelper.Clamp((float) (((double) num1 - 0.5 + 0.400000005960464) / 0.400000005960464), 0.0f, 1f);
          vector4_1 = Vector4.Lerp(vector4_1, this._lightGlowColor, amount2);
        }
        fragment.SetColor(index, vector4_1);
      }
    }
  }
}
