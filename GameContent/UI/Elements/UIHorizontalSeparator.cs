// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIHorizontalSeparator
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIHorizontalSeparator : UIElement
  {
    private Asset<Texture2D> _texture;
    public Color Color;
    public int EdgeWidth;

    public UIHorizontalSeparator(int EdgeWidth = 2, bool highlightSideUp = true)
    {
      this.Color = Color.White;
      this._texture = !highlightSideUp ? Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Separator2", (AssetRequestMode) 1) : Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Separator1", (AssetRequestMode) 1);
      this.Width.Set((float) this._texture.Width(), 0.0f);
      this.Height.Set((float) this._texture.Height(), 0.0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      Utils.DrawPanel(this._texture.Value, this.EdgeWidth, 0, spriteBatch, dimensions.Position(), dimensions.Width, this.Color);
    }

    public override bool ContainsPoint(Vector2 point) => false;
  }
}
