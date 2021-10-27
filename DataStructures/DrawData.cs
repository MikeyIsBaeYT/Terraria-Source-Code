// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.DrawData
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public struct DrawData
  {
    public Texture2D texture;
    public Vector2 position;
    public Rectangle destinationRectangle;
    public Rectangle? sourceRect;
    public Color color;
    public float rotation;
    public Vector2 origin;
    public Vector2 scale;
    public SpriteEffects effect;
    public int shader;
    public bool ignorePlayerRotation;
    public readonly bool useDestinationRectangle;
    public static Rectangle? nullRectangle;

    public DrawData(Texture2D texture, Vector2 position, Color color)
    {
      this.texture = texture;
      this.position = position;
      this.color = color;
      this.destinationRectangle = new Rectangle();
      this.sourceRect = DrawData.nullRectangle;
      this.rotation = 0.0f;
      this.origin = Vector2.Zero;
      this.scale = Vector2.One;
      this.effect = SpriteEffects.None;
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public DrawData(Texture2D texture, Vector2 position, Rectangle? sourceRect, Color color)
    {
      this.texture = texture;
      this.position = position;
      this.color = color;
      this.destinationRectangle = new Rectangle();
      this.sourceRect = sourceRect;
      this.rotation = 0.0f;
      this.origin = Vector2.Zero;
      this.scale = Vector2.One;
      this.effect = SpriteEffects.None;
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public DrawData(
      Texture2D texture,
      Vector2 position,
      Rectangle? sourceRect,
      Color color,
      float rotation,
      Vector2 origin,
      float scale,
      SpriteEffects effect,
      int inactiveLayerDepth)
    {
      this.texture = texture;
      this.position = position;
      this.sourceRect = sourceRect;
      this.color = color;
      this.rotation = rotation;
      this.origin = origin;
      this.scale = new Vector2(scale, scale);
      this.effect = effect;
      this.destinationRectangle = new Rectangle();
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public DrawData(
      Texture2D texture,
      Vector2 position,
      Rectangle? sourceRect,
      Color color,
      float rotation,
      Vector2 origin,
      Vector2 scale,
      SpriteEffects effect,
      int inactiveLayerDepth)
    {
      this.texture = texture;
      this.position = position;
      this.sourceRect = sourceRect;
      this.color = color;
      this.rotation = rotation;
      this.origin = origin;
      this.scale = scale;
      this.effect = effect;
      this.destinationRectangle = new Rectangle();
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public DrawData(Texture2D texture, Rectangle destinationRectangle, Color color)
    {
      this.texture = texture;
      this.destinationRectangle = destinationRectangle;
      this.color = color;
      this.position = Vector2.Zero;
      this.sourceRect = DrawData.nullRectangle;
      this.rotation = 0.0f;
      this.origin = Vector2.Zero;
      this.scale = Vector2.One;
      this.effect = SpriteEffects.None;
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public DrawData(
      Texture2D texture,
      Rectangle destinationRectangle,
      Rectangle? sourceRect,
      Color color)
    {
      this.texture = texture;
      this.destinationRectangle = destinationRectangle;
      this.color = color;
      this.position = Vector2.Zero;
      this.sourceRect = sourceRect;
      this.rotation = 0.0f;
      this.origin = Vector2.Zero;
      this.scale = Vector2.One;
      this.effect = SpriteEffects.None;
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public DrawData(
      Texture2D texture,
      Rectangle destinationRectangle,
      Rectangle? sourceRect,
      Color color,
      float rotation,
      Vector2 origin,
      SpriteEffects effect,
      int inactiveLayerDepth)
    {
      this.texture = texture;
      this.destinationRectangle = destinationRectangle;
      this.sourceRect = sourceRect;
      this.color = color;
      this.rotation = rotation;
      this.origin = origin;
      this.effect = effect;
      this.position = Vector2.Zero;
      this.scale = Vector2.One;
      this.shader = 0;
      this.ignorePlayerRotation = false;
      this.useDestinationRectangle = false;
    }

    public void Draw(SpriteBatch sb)
    {
      if (this.useDestinationRectangle)
        sb.Draw(this.texture, this.destinationRectangle, this.sourceRect, this.color, this.rotation, this.origin, this.effect, 0.0f);
      else
        sb.Draw(this.texture, this.position, this.sourceRect, this.color, this.rotation, this.origin, this.scale, this.effect, 0.0f);
    }
  }
}
