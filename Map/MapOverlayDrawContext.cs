// Decompiled with JetBrains decompiler
// Type: Terraria.Map.MapOverlayDrawContext
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.UI;

namespace Terraria.Map
{
  public struct MapOverlayDrawContext
  {
    private readonly Vector2 _mapPosition;
    private readonly Vector2 _mapOffset;
    private readonly Rectangle? _clippingRect;
    private readonly float _mapScale;
    private readonly float _drawScale;

    public MapOverlayDrawContext(
      Vector2 mapPosition,
      Vector2 mapOffset,
      Rectangle? clippingRect,
      float mapScale,
      float drawScale)
    {
      this._mapPosition = mapPosition;
      this._mapOffset = mapOffset;
      this._clippingRect = clippingRect;
      this._mapScale = mapScale;
      this._drawScale = drawScale;
    }

    public MapOverlayDrawContext.DrawResult Draw(
      Texture2D texture,
      Vector2 position,
      Alignment alignment)
    {
      return this.Draw(texture, position, new SpriteFrame((byte) 1, (byte) 1), alignment);
    }

    public MapOverlayDrawContext.DrawResult Draw(
      Texture2D texture,
      Vector2 position,
      SpriteFrame frame,
      Alignment alignment)
    {
      position = (position - this._mapPosition) * this._mapScale + this._mapOffset;
      if (this._clippingRect.HasValue && !this._clippingRect.Value.Contains(position.ToPoint()))
        return MapOverlayDrawContext.DrawResult.Culled;
      Rectangle sourceRectangle = frame.GetSourceRectangle(texture);
      Vector2 origin = sourceRectangle.Size() * alignment.OffsetMultiplier;
      Main.spriteBatch.Draw(texture, position, new Rectangle?(sourceRectangle), Color.White, 0.0f, origin, this._drawScale, SpriteEffects.None, 0.0f);
      position -= origin * this._drawScale;
      return new MapOverlayDrawContext.DrawResult(new Rectangle((int) position.X, (int) position.Y, (int) ((double) texture.Width * (double) this._drawScale), (int) ((double) texture.Height * (double) this._drawScale)).Contains(Main.MouseScreen.ToPoint()));
    }

    public MapOverlayDrawContext.DrawResult Draw(
      Texture2D texture,
      Vector2 position,
      Color color,
      SpriteFrame frame,
      float scaleIfNotSelected,
      float scaleIfSelected,
      Alignment alignment)
    {
      position = (position - this._mapPosition) * this._mapScale + this._mapOffset;
      if (this._clippingRect.HasValue && !this._clippingRect.Value.Contains(position.ToPoint()))
        return MapOverlayDrawContext.DrawResult.Culled;
      Rectangle sourceRectangle = frame.GetSourceRectangle(texture);
      Vector2 origin = sourceRectangle.Size() * alignment.OffsetMultiplier;
      Vector2 position1 = position;
      float num1 = this._drawScale * scaleIfNotSelected;
      Vector2 vector2 = position - origin * num1;
      int num2 = new Rectangle((int) vector2.X, (int) vector2.Y, (int) ((double) sourceRectangle.Width * (double) num1), (int) ((double) sourceRectangle.Height * (double) num1)).Contains(Main.MouseScreen.ToPoint()) ? 1 : 0;
      float scale = num1;
      if (num2 != 0)
        scale = this._drawScale * scaleIfSelected;
      Main.spriteBatch.Draw(texture, position1, new Rectangle?(sourceRectangle), color, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
      return new MapOverlayDrawContext.DrawResult(num2 != 0);
    }

    public struct DrawResult
    {
      public static readonly MapOverlayDrawContext.DrawResult Culled = new MapOverlayDrawContext.DrawResult(false);
      public readonly bool IsMouseOver;

      public DrawResult(bool isMouseOver) => this.IsMouseOver = isMouseOver;
    }
  }
}
