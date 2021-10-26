// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIToggleImage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIToggleImage : UIElement
  {
    private Asset<Texture2D> _onTexture;
    private Asset<Texture2D> _offTexture;
    private int _drawWidth;
    private int _drawHeight;
    private Point _onTextureOffset = Point.Zero;
    private Point _offTextureOffset = Point.Zero;
    private bool _isOn;

    public bool IsOn => this._isOn;

    public UIToggleImage(
      Asset<Texture2D> texture,
      int width,
      int height,
      Point onTextureOffset,
      Point offTextureOffset)
    {
      this._onTexture = texture;
      this._offTexture = texture;
      this._offTextureOffset = offTextureOffset;
      this._onTextureOffset = onTextureOffset;
      this._drawWidth = width;
      this._drawHeight = height;
      this.Width.Set((float) width, 0.0f);
      this.Height.Set((float) height, 0.0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      Texture2D texture;
      Point point;
      if (this._isOn)
      {
        texture = this._onTexture.Value;
        point = this._onTextureOffset;
      }
      else
      {
        texture = this._offTexture.Value;
        point = this._offTextureOffset;
      }
      Color color = this.IsMouseHovering ? Color.White : Color.Silver;
      spriteBatch.Draw(texture, new Rectangle((int) dimensions.X, (int) dimensions.Y, this._drawWidth, this._drawHeight), new Rectangle?(new Rectangle(point.X, point.Y, this._drawWidth, this._drawHeight)), color);
    }

    public override void Click(UIMouseEvent evt)
    {
      this.Toggle();
      base.Click(evt);
    }

    public void SetState(bool value) => this._isOn = value;

    public void Toggle() => this._isOn = !this._isOn;
  }
}
