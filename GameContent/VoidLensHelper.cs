// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.VoidLensHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent
{
  public struct VoidLensHelper
  {
    private readonly Vector2 _position;
    private readonly float _opacity;
    private readonly int _frameNumber;

    public VoidLensHelper(Projectile proj)
    {
      this._position = proj.Center;
      this._opacity = proj.Opacity;
      this._frameNumber = proj.frame;
    }

    public VoidLensHelper(Vector2 worldPosition, float opacity)
    {
      worldPosition.Y -= 2f;
      this._position = worldPosition;
      this._opacity = opacity;
      this._frameNumber = (int) (((double) Main.tileFrameCounter[491] + (double) this._position.X + (double) this._position.Y) % 40.0) / 5;
    }

    public void Update()
    {
      Lighting.AddLight(this._position, 0.4f, 0.2f, 0.9f);
      this.SpawnVoidLensDust();
    }

    public void SpawnVoidLensDust()
    {
      if (Main.rand.Next(3) != 0)
        return;
      if (Main.rand.Next(2) == 0)
      {
        Vector2 vector2 = Vector2.UnitY.RotatedByRandom(6.28318548202515) * new Vector2(0.5f, 1f);
        Dust dust = Dust.NewDustDirect(this._position - vector2 * 30f, 0, 0, Utils.SelectRandom<int>(Main.rand, 86, 88));
        dust.noGravity = true;
        dust.noLightEmittence = true;
        dust.position = this._position - vector2.SafeNormalize(Vector2.Zero) * (float) Main.rand.Next(10, 21);
        dust.velocity = vector2.RotatedBy(1.57079637050629) * 2f;
        dust.scale = 0.5f + Main.rand.NextFloat();
        dust.fadeIn = 0.5f;
        dust.customData = (object) this;
        dust.position += dust.velocity * 10f;
        dust.velocity *= -1f;
      }
      else
      {
        Vector2 vector2 = Vector2.UnitY.RotatedByRandom(6.28318548202515) * new Vector2(0.5f, 1f);
        Dust dust = Dust.NewDustDirect(this._position - vector2 * 30f, 0, 0, Utils.SelectRandom<int>(Main.rand, 86, 88));
        dust.noGravity = true;
        dust.noLightEmittence = true;
        dust.position = this._position - vector2.SafeNormalize(Vector2.Zero) * (float) Main.rand.Next(5, 10);
        dust.velocity = vector2.RotatedBy(-1.57079637050629) * 3f;
        dust.scale = 0.5f + Main.rand.NextFloat();
        dust.fadeIn = 0.5f;
        dust.customData = (object) this;
        dust.position += dust.velocity * 10f;
        dust.velocity *= -1f;
      }
    }

    public void DrawToDrawData(List<DrawData> drawDataList, int selectionMode)
    {
      Main.instance.LoadProjectile(734);
      Asset<Texture2D> tex = TextureAssets.Projectile[734];
      Rectangle r = tex.Frame(verticalFrames: 8, frameY: this._frameNumber);
      Color color = Color.Lerp(Lighting.GetColor(this._position.ToTileCoordinates()), Color.White, 0.5f) * this._opacity;
      DrawData drawData1 = new DrawData(tex.Value, this._position - Main.screenPosition, new Rectangle?(r), color, 0.0f, r.Size() / 2f, 1f, SpriteEffects.None, 0);
      drawDataList.Add(drawData1);
      for (float num = 0.0f; (double) num < 1.0; num += 0.34f)
      {
        DrawData drawData2 = drawData1;
        drawData2.color = new Color((int) sbyte.MaxValue, 50, (int) sbyte.MaxValue, 0) * this._opacity;
        drawData2.scale *= 1.1f;
        float x = ((float) ((double) Main.GlobalTimeWrappedHourly / 5.0 * 6.28318548202515)).ToRotationVector2().X;
        drawData2.color *= (float) ((double) x * 0.100000001490116 + 0.300000011920929);
        drawData2.position += ((float) (((double) Main.GlobalTimeWrappedHourly / 5.0 + (double) num) * 6.28318548202515)).ToRotationVector2() * (float) ((double) x * 1.0 + 2.0);
        drawDataList.Add(drawData2);
      }
      if (selectionMode == 0)
        return;
      int averageTileLighting = ((int) color.R + (int) color.G + (int) color.B) / 3;
      if (averageTileLighting <= 10)
        return;
      Color selectionGlowColor = Colors.GetSelectionGlowColor(selectionMode == 2, averageTileLighting);
      drawData1 = new DrawData(TextureAssets.Extra[93].Value, this._position - Main.screenPosition, new Rectangle?(r), selectionGlowColor, 0.0f, r.Size() / 2f, 1f, SpriteEffects.None, 0);
      drawDataList.Add(drawData1);
    }
  }
}
