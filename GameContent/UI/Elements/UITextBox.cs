// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UITextBox
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
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
      if (text.ToString().Length > this._maxLength)
        text = text.ToString().Substring(0, this._maxLength);
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
      this._cursor = this.Text.Length;
      base.DrawSelf(spriteBatch);
      ++this._frameCount;
      if ((this._frameCount %= 40) > 20)
        return;
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      Vector2 pos = innerDimensions.Position();
      Vector2 vector2 = new Vector2((this.IsLarge ? Main.fontDeathText : Main.fontMouseText).MeasureString(this.Text.Substring(0, this._cursor)).X, this.IsLarge ? 32f : 16f) * this.TextScale;
      if (this.IsLarge)
        pos.Y -= 8f * this.TextScale;
      else
        pos.Y += 2f * this.TextScale;
      pos.X += (float) (((double) innerDimensions.Width - (double) this.TextSize.X) * 0.5 + (double) vector2.X - (this.IsLarge ? 8.0 : 4.0) * (double) this.TextScale + 6.0);
      if (this.IsLarge)
        Utils.DrawBorderStringBig(spriteBatch, "|", pos, this.TextColor, this.TextScale);
      else
        Utils.DrawBorderString(spriteBatch, "|", pos, this.TextColor, this.TextScale);
    }
  }
}
