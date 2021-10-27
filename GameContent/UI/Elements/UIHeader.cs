// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIHeader
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIHeader : UIElement
  {
    private string _text;

    public string Text
    {
      get => this._text;
      set
      {
        if (!(this._text != value))
          return;
        this._text = value;
        Vector2 vector2 = Main.fontDeathText.MeasureString(this.Text);
        this.Width.Pixels = vector2.X;
        this.Height.Pixels = vector2.Y;
        this.Width.Precent = 0.0f;
        this.Height.Precent = 0.0f;
        this.Recalculate();
      }
    }

    public UIHeader() => this.Text = "";

    public UIHeader(string text) => this.Text = text;

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, Main.fontDeathText, this.Text, new Vector2(dimensions.X, dimensions.Y), Color.White);
    }
  }
}
