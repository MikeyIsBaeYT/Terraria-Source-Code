// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.SkyShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class SkyShader : ChromaShader
  {
    private readonly Vector4 _baseSkyColor;
    private readonly Vector4 _baseSpaceColor;
    private Vector4 _processedSkyColor;
    private Vector4 _processedCloudColor;
    private float _backgroundTransition;
    private float _starVisibility;

    public SkyShader(Color skyColor, Color spaceColor)
    {
      this._baseSkyColor = skyColor.ToVector4();
      this._baseSpaceColor = spaceColor.ToVector4();
    }

    public virtual void Update(float elapsedTime)
    {
      this._backgroundTransition = MathHelper.Clamp((float) (((double) (Main.player[Main.myPlayer].position.Y / 16f) - Main.worldSurface * 0.25) / (Main.worldSurface * 0.100000001490116)), 0.0f, 1f);
      this._processedSkyColor = this._baseSkyColor * (Main.ColorOfTheSkies.ToVector4() * 0.75f + Vector4.One * 0.25f);
      this._processedCloudColor = Main.ColorOfTheSkies.ToVector4() * 0.75f + Vector4.One * 0.25f;
      if (Main.dayTime)
      {
        float num = (float) (Main.time / 54000.0);
        this._starVisibility = (double) num >= 0.25 ? ((double) num <= 0.75 ? 0.0f : (float) (((double) num - 0.75) / 0.25)) : (float) (1.0 - (double) num / 0.25);
      }
      else
        this._starVisibility = 1f;
      this._starVisibility = Math.Max(1f - this._backgroundTransition, this._starVisibility);
    }

    [RgbProcessor]
    private void ProcessAnyDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector2 vector2 = new Vector2(0.1f, 0.5f);
        Vector4 vector4 = Vector4.Lerp(Vector4.Lerp(this._baseSpaceColor, Vector4.Lerp(this._processedSkyColor, this._processedCloudColor, (float) Math.Sqrt((double) Math.Max(0.0f, (float) (1.0 - 2.0 * (double) NoiseHelper.GetDynamicNoise(canvasPositionOfIndex * vector2 + new Vector2(time * 0.05f, 0.0f), time / 20f))))), this._backgroundTransition), Vector4.One, Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(gridPositionOfIndex.X, gridPositionOfIndex.Y, time / 60f) * 20.0)) * 0.98f * this._starVisibility);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
