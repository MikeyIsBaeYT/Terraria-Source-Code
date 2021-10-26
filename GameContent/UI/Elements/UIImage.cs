// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIImage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIImage : UIElement
  {
    private Asset<Texture2D> _texture;
    public float ImageScale = 1f;
    public float Rotation;
    public bool ScaleToFit;
    public Color Color = Color.White;
    public Vector2 NormalizedOrigin = Vector2.Zero;
    public bool RemoveFloatingPointsFromDrawPosition;

    public UIImage(Asset<Texture2D> texture)
    {
      this._texture = texture;
      this.Width.Set((float) this._texture.Width(), 0.0f);
      this.Height.Set((float) this._texture.Height(), 0.0f);
    }

    public void SetImage(Asset<Texture2D> texture)
    {
      this._texture = texture;
      this.Width.Set((float) this._texture.Width(), 0.0f);
      this.Height.Set((float) this._texture.Height(), 0.0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      if (this.ScaleToFit)
      {
        spriteBatch.Draw(this._texture.Value, dimensions.ToRectangle(), this.Color);
      }
      else
      {
        Vector2 vector2_1 = this._texture.Value.Size();
        Vector2 vector2_2 = dimensions.Position() + vector2_1 * (1f - this.ImageScale) / 2f + vector2_1 * this.NormalizedOrigin;
        if (this.RemoveFloatingPointsFromDrawPosition)
          vector2_2 = vector2_2.Floor();
        spriteBatch.Draw(this._texture.Value, vector2_2, new Rectangle?(), this.Color, this.Rotation, vector2_1 * this.NormalizedOrigin, this.ImageScale, SpriteEffects.None, 0.0f);
      }
    }
  }
}
