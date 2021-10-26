// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.ColorSlidersSet
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public class ColorSlidersSet
  {
    public float Hue;
    public float Saturation;
    public float Luminance;
    public float Alpha = 1f;

    public void SetHSL(Color color)
    {
      Vector3 hsl = Main.rgbToHsl(color);
      this.Hue = hsl.X;
      this.Saturation = hsl.Y;
      this.Luminance = hsl.Z;
    }

    public void SetHSL(Vector3 vector)
    {
      this.Hue = vector.X;
      this.Saturation = vector.Y;
      this.Luminance = vector.Z;
    }

    public Color GetColor()
    {
      Color rgb = Main.hslToRgb(this.Hue, this.Saturation, this.Luminance);
      rgb.A = (byte) ((double) this.Alpha * (double) byte.MaxValue);
      return rgb;
    }

    public Vector3 GetHSLVector() => new Vector3(this.Hue, this.Saturation, this.Luminance);

    public void ApplyToMainLegacyBars()
    {
      Main.hBar = this.Hue;
      Main.sBar = this.Saturation;
      Main.lBar = this.Luminance;
      Main.aBar = this.Alpha;
    }
  }
}
