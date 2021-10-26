// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIPanel
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIPanel : UIElement
  {
    private int _cornerSize = 12;
    private int _barSize = 4;
    private Asset<Texture2D> _borderTexture;
    private Asset<Texture2D> _backgroundTexture;
    public Color BorderColor = Color.Black;
    public Color BackgroundColor = new Color(63, 82, 151) * 0.7f;

    public UIPanel()
    {
      if (this._borderTexture == null)
        this._borderTexture = Main.Assets.Request<Texture2D>("Images/UI/PanelBorder", (AssetRequestMode) 1);
      if (this._backgroundTexture == null)
        this._backgroundTexture = Main.Assets.Request<Texture2D>("Images/UI/PanelBackground", (AssetRequestMode) 1);
      this.SetPadding((float) this._cornerSize);
    }

    public UIPanel(
      Asset<Texture2D> customBackground,
      Asset<Texture2D> customborder,
      int customCornerSize = 12,
      int customBarSize = 4)
    {
      if (this._borderTexture == null)
        this._borderTexture = customborder;
      if (this._backgroundTexture == null)
        this._backgroundTexture = customBackground;
      this._cornerSize = customCornerSize;
      this._barSize = customBarSize;
      this.SetPadding((float) this._cornerSize);
    }

    private void DrawPanel(SpriteBatch spriteBatch, Texture2D texture, Color color)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      Point point1 = new Point((int) dimensions.X, (int) dimensions.Y);
      Point point2 = new Point(point1.X + (int) dimensions.Width - this._cornerSize, point1.Y + (int) dimensions.Height - this._cornerSize);
      int width = point2.X - point1.X - this._cornerSize;
      int height = point2.Y - point1.Y - this._cornerSize;
      spriteBatch.Draw(texture, new Rectangle(point1.X, point1.Y, this._cornerSize, this._cornerSize), new Rectangle?(new Rectangle(0, 0, this._cornerSize, this._cornerSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point2.X, point1.Y, this._cornerSize, this._cornerSize), new Rectangle?(new Rectangle(this._cornerSize + this._barSize, 0, this._cornerSize, this._cornerSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X, point2.Y, this._cornerSize, this._cornerSize), new Rectangle?(new Rectangle(0, this._cornerSize + this._barSize, this._cornerSize, this._cornerSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point2.X, point2.Y, this._cornerSize, this._cornerSize), new Rectangle?(new Rectangle(this._cornerSize + this._barSize, this._cornerSize + this._barSize, this._cornerSize, this._cornerSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X + this._cornerSize, point1.Y, width, this._cornerSize), new Rectangle?(new Rectangle(this._cornerSize, 0, this._barSize, this._cornerSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X + this._cornerSize, point2.Y, width, this._cornerSize), new Rectangle?(new Rectangle(this._cornerSize, this._cornerSize + this._barSize, this._barSize, this._cornerSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X, point1.Y + this._cornerSize, this._cornerSize, height), new Rectangle?(new Rectangle(0, this._cornerSize, this._cornerSize, this._barSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point2.X, point1.Y + this._cornerSize, this._cornerSize, height), new Rectangle?(new Rectangle(this._cornerSize + this._barSize, this._cornerSize, this._cornerSize, this._barSize)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X + this._cornerSize, point1.Y + this._cornerSize, width, height), new Rectangle?(new Rectangle(this._cornerSize, this._cornerSize, this._barSize, this._barSize)), color);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (this._backgroundTexture != null)
        this.DrawPanel(spriteBatch, this._backgroundTexture.Value, this.BackgroundColor);
      if (this._borderTexture == null)
        return;
      this.DrawPanel(spriteBatch, this._borderTexture.Value, this.BorderColor);
    }
  }
}
