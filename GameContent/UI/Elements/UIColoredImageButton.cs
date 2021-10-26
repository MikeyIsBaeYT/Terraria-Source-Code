// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIColoredImageButton
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIColoredImageButton : UIElement
  {
    private Asset<Texture2D> _backPanelTexture;
    private Asset<Texture2D> _texture;
    private Asset<Texture2D> _middleTexture;
    private Asset<Texture2D> _backPanelHighlightTexture;
    private Asset<Texture2D> _backPanelBorderTexture;
    private Color _color;
    private float _visibilityActive = 1f;
    private float _visibilityInactive = 0.4f;
    private bool _selected;
    private bool _hovered;

    public UIColoredImageButton(Asset<Texture2D> texture, bool isSmall = false)
    {
      this._color = Color.White;
      this._texture = texture;
      this._backPanelTexture = !isSmall ? Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanel", (AssetRequestMode) 1) : Main.Assets.Request<Texture2D>("Images/UI/CharCreation/SmallPanel", (AssetRequestMode) 1);
      this.Width.Set((float) this._backPanelTexture.Width(), 0.0f);
      this.Height.Set((float) this._backPanelTexture.Height(), 0.0f);
      this._backPanelHighlightTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelHighlight", (AssetRequestMode) 1);
      if (isSmall)
        this._backPanelBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/SmallPanelBorder", (AssetRequestMode) 1);
      else
        this._backPanelBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelBorder", (AssetRequestMode) 1);
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
      Vector2 position = dimensions.Position() + new Vector2(dimensions.Width, dimensions.Height) / 2f;
      spriteBatch.Draw(this._backPanelTexture.Value, position, new Rectangle?(), Color.White * (this.IsMouseHovering ? this._visibilityActive : this._visibilityInactive), 0.0f, this._backPanelTexture.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
      Color white = Color.White;
      if (this._hovered)
        spriteBatch.Draw(this._backPanelBorderTexture.Value, position, new Rectangle?(), Color.White, 0.0f, this._backPanelBorderTexture.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
      if (this._selected)
        spriteBatch.Draw(this._backPanelHighlightTexture.Value, position, new Rectangle?(), Color.White, 0.0f, this._backPanelHighlightTexture.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
      if (this._middleTexture != null)
        spriteBatch.Draw(this._middleTexture.Value, position, new Rectangle?(), Color.White, 0.0f, this._middleTexture.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
      spriteBatch.Draw(this._texture.Value, position, new Rectangle?(), this._color, 0.0f, this._texture.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
    }

    public override void MouseOver(UIMouseEvent evt)
    {
      base.MouseOver(evt);
      SoundEngine.PlaySound(12);
      this._hovered = true;
    }

    public void SetVisibility(float whenActive, float whenInactive)
    {
      this._visibilityActive = MathHelper.Clamp(whenActive, 0.0f, 1f);
      this._visibilityInactive = MathHelper.Clamp(whenInactive, 0.0f, 1f);
    }

    public void SetColor(Color color) => this._color = color;

    public void SetMiddleTexture(Asset<Texture2D> texAsset) => this._middleTexture = texAsset;

    public void SetSelected(bool selected) => this._selected = selected;

    public override void MouseOut(UIMouseEvent evt)
    {
      base.MouseOut(evt);
      this._hovered = false;
    }
  }
}
