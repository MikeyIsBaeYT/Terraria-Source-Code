// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIText
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIText : UIElement
  {
    private object _text = (object) "";
    private float _textScale = 1f;
    private Vector2 _textSize = Vector2.Zero;
    private bool _isLarge;
    private Color _color = Color.White;
    private bool _isWrapped;
    public bool DynamicallyScaleDownToWidth;
    private string _visibleText;
    private string _lastTextReference;

    public string Text => this._text.ToString();

    public float TextOriginX { get; set; }

    public float WrappedTextBottomPadding { get; set; }

    public bool IsWrapped
    {
      get => this._isWrapped;
      set
      {
        this._isWrapped = value;
        this.InternalSetText(this._text, this._textScale, this._isLarge);
      }
    }

    public event Action OnInternalTextChange;

    public Color TextColor
    {
      get => this._color;
      set => this._color = value;
    }

    public UIText(string text, float textScale = 1f, bool large = false)
    {
      this.TextOriginX = 0.5f;
      this.IsWrapped = false;
      this.WrappedTextBottomPadding = 20f;
      this.InternalSetText((object) text, textScale, large);
    }

    public UIText(LocalizedText text, float textScale = 1f, bool large = false)
    {
      this.TextOriginX = 0.5f;
      this.IsWrapped = false;
      this.WrappedTextBottomPadding = 20f;
      this.InternalSetText((object) text, textScale, large);
    }

    public override void Recalculate()
    {
      this.InternalSetText(this._text, this._textScale, this._isLarge);
      base.Recalculate();
    }

    public void SetText(string text) => this.InternalSetText((object) text, this._textScale, this._isLarge);

    public void SetText(LocalizedText text) => this.InternalSetText((object) text, this._textScale, this._isLarge);

    public void SetText(string text, float textScale, bool large) => this.InternalSetText((object) text, textScale, large);

    public void SetText(LocalizedText text, float textScale, bool large) => this.InternalSetText((object) text, textScale, large);

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      base.DrawSelf(spriteBatch);
      this.VerifyTextState();
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      Vector2 pos = innerDimensions.Position();
      if (this._isLarge)
        pos.Y -= 10f * this._textScale;
      else
        pos.Y -= 2f * this._textScale;
      pos.X += (innerDimensions.Width - this._textSize.X) * this.TextOriginX;
      float textScale = this._textScale;
      if (this.DynamicallyScaleDownToWidth && (double) this._textSize.X > (double) innerDimensions.Width)
        textScale *= innerDimensions.Width / this._textSize.X;
      if (this._isLarge)
        Utils.DrawBorderStringBig(spriteBatch, this._visibleText, pos, this._color, textScale);
      else
        Utils.DrawBorderString(spriteBatch, this._visibleText, pos, this._color, textScale);
    }

    private void VerifyTextState()
    {
      if ((object) this._lastTextReference == (object) this.Text)
        return;
      this.InternalSetText(this._text, this._textScale, this._isLarge);
    }

    private void InternalSetText(object text, float textScale, bool large)
    {
      DynamicSpriteFont dynamicSpriteFont = large ? FontAssets.DeathText.Value : FontAssets.MouseText.Value;
      this._text = text;
      this._isLarge = large;
      this._textScale = textScale;
      this._lastTextReference = this._text.ToString();
      this._visibleText = !this.IsWrapped ? this._lastTextReference : dynamicSpriteFont.CreateWrappedText(this._lastTextReference, this.GetInnerDimensions().Width / this._textScale);
      Vector2 vector2_1 = dynamicSpriteFont.MeasureString(this._visibleText);
      Vector2 vector2_2 = !this.IsWrapped ? new Vector2(vector2_1.X, large ? 32f : 16f) * textScale : new Vector2(vector2_1.X, vector2_1.Y + this.WrappedTextBottomPadding) * textScale;
      this._textSize = vector2_2;
      this.MinWidth.Set(vector2_2.X + this.PaddingLeft + this.PaddingRight, 0.0f);
      this.MinHeight.Set(vector2_2.Y + this.PaddingTop + this.PaddingBottom, 0.0f);
      if (this.OnInternalTextChange == null)
        return;
      this.OnInternalTextChange();
    }
  }
}
