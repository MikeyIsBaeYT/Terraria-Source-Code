// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UITextBox
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  internal class UITextBox : UITextPanel<string>
  {
    private int _cursor;
    private int _frameCount;
    private int _maxLength = 20;
    public bool ShowInputTicker = true;
    public bool HideSelf;

    public UITextBox(string text, float textScale = 1f, bool large = false)
      : base(text, textScale, large)
    {
    }

    public void Write(string text)
    {
      this.SetText(this.Text.Insert(this._cursor, text));
      this._cursor += text.Length;
    }

    public override void SetText(string text, float textScale, bool large)
    {
      if (text == null)
        text = "";
      if (text.Length > this._maxLength)
        text = text.Substring(0, this._maxLength);
      base.SetText(text, textScale, large);
      this._cursor = Math.Min(this.Text.Length, this._cursor);
    }

    public void SetTextMaxLength(int maxLength) => this._maxLength = maxLength;

    public void Backspace()
    {
      if (this._cursor == 0)
        return;
      this.SetText(this.Text.Substring(0, this.Text.Length - 1));
    }

    public void CursorLeft()
    {
      if (this._cursor == 0)
        return;
      --this._cursor;
    }

    public void CursorRight()
    {
      if (this._cursor >= this.Text.Length)
        return;
      ++this._cursor;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (this.HideSelf)
        return;
      this._cursor = this.Text.Length;
      base.DrawSelf(spriteBatch);
      ++this._frameCount;
      if ((this._frameCount %= 40) > 20 || !this.ShowInputTicker)
        return;
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      Vector2 pos = innerDimensions.Position();
      Vector2 vector2 = new Vector2((this.IsLarge ? FontAssets.DeathText.Value : FontAssets.MouseText.Value).MeasureString(this.Text.Substring(0, this._cursor)).X, this.IsLarge ? 32f : 16f) * this.TextScale;
      if (this.IsLarge)
        pos.Y -= 8f * this.TextScale;
      else
        pos.Y -= 2f * this.TextScale;
      pos.X += (float) (((double) innerDimensions.Width - (double) this.TextSize.X) * (double) this.TextHAlign + (double) vector2.X - (this.IsLarge ? 8.0 : 4.0) * (double) this.TextScale + 6.0);
      if (this.IsLarge)
        Utils.DrawBorderStringBig(spriteBatch, "|", pos, this.TextColor, this.TextScale);
      else
        Utils.DrawBorderString(spriteBatch, "|", pos, this.TextColor, this.TextScale);
    }
  }
}
