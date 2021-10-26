// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Chat.TextSnippet
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;

namespace Terraria.UI.Chat
{
  public class TextSnippet
  {
    public string Text;
    public string TextOriginal;
    public Color Color = Color.White;
    public float Scale = 1f;
    public bool CheckForHover;
    public bool DeleteWhole;

    public TextSnippet(string text = "")
    {
      this.Text = text;
      this.TextOriginal = text;
    }

    public TextSnippet(string text, Color color, float scale = 1f)
    {
      this.Text = text;
      this.TextOriginal = text;
      this.Color = color;
      this.Scale = scale;
    }

    public virtual void Update()
    {
    }

    public virtual void OnHover()
    {
    }

    public virtual void OnClick()
    {
    }

    public virtual Color GetVisibleColor() => ChatManager.WaveColor(this.Color);

    public virtual bool UniqueDraw(
      bool justCheckingString,
      out Vector2 size,
      SpriteBatch spriteBatch,
      Vector2 position = default (Vector2),
      Color color = default (Color),
      float scale = 1f)
    {
      size = Vector2.Zero;
      return false;
    }

    public virtual TextSnippet CopyMorph(string newText)
    {
      TextSnippet textSnippet = (TextSnippet) this.MemberwiseClone();
      textSnippet.Text = newText;
      return textSnippet;
    }

    public virtual float GetStringLength(DynamicSpriteFont font) => font.MeasureString(this.Text).X * this.Scale;

    public override string ToString() => "Text: " + this.Text + " | OriginalText: " + this.TextOriginal;
  }
}
