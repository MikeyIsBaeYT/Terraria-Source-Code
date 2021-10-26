// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.FrostLegionShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;

namespace Terraria.GameContent.RGB
{
  public class FrostLegionShader : ChromaShader
  {
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;

    public FrostLegionShader(Color primaryColor, Color secondaryColor)
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
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        float staticNoise = NoiseHelper.GetStaticNoise(fragment.GetGridPositionOfIndex(index).X / 2);
        float num = (float) (((double) canvasPositionOfIndex.Y + (double) canvasPositionOfIndex.X / 2.0 - (double) staticNoise + (double) time) % 2.0);
        if ((double) num < 0.0)
          num += 2f;
        if ((double) num < 0.200000002980232)
          num = (float) (1.0 - (double) num / 0.200000002980232);
        Vector4 vector4 = Vector4.Lerp(this._primaryColor, this._secondaryColor, num / 2f);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
