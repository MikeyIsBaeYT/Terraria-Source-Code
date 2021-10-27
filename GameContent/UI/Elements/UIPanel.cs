// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIPanel
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIPanel : UIElement
  {
    private static int CORNER_SIZE = 12;
    private static int BAR_SIZE = 4;
    private static Texture2D _borderTexture;
    private static Texture2D _backgroundTexture;
    public Color BorderColor = Color.Black;
    public Color BackgroundColor = new Color(63, 82, 151) * 0.7f;

    public UIPanel()
    {
      if (UIPanel._borderTexture == null)
        UIPanel._borderTexture = TextureManager.Load("Images/UI/PanelBorder");
      if (UIPanel._backgroundTexture == null)
        UIPanel._backgroundTexture = TextureManager.Load("Images/UI/PanelBackground");
      this.SetPadding((float) UIPanel.CORNER_SIZE);
    }

    private void DrawPanel(SpriteBatch spriteBatch, Texture2D texture, Color color)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      Point point1 = new Point((int) dimensions.X, (int) dimensions.Y);
      Point point2 = new Point(point1.X + (int) dimensions.Width - UIPanel.CORNER_SIZE, point1.Y + (int) dimensions.Height - UIPanel.CORNER_SIZE);
      int width = point2.X - point1.X - UIPanel.CORNER_SIZE;
      int height = point2.Y - point1.Y - UIPanel.CORNER_SIZE;
      spriteBatch.Draw(texture, new Rectangle(point1.X, point1.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(0, 0, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point2.X, point1.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, 0, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X, point2.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(0, UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point2.X, point2.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X + UIPanel.CORNER_SIZE, point1.Y, width, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE, 0, UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X + UIPanel.CORNER_SIZE, point2.Y, width, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X, point1.Y + UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, height), new Rectangle?(new Rectangle(0, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, UIPanel.BAR_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point2.X, point1.Y + UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, height), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, UIPanel.BAR_SIZE)), color);
      spriteBatch.Draw(texture, new Rectangle(point1.X + UIPanel.CORNER_SIZE, point1.Y + UIPanel.CORNER_SIZE, width, height), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, UIPanel.BAR_SIZE, UIPanel.BAR_SIZE)), color);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      this.DrawPanel(spriteBatch, UIPanel._backgroundTexture, this.BackgroundColor);
      this.DrawPanel(spriteBatch, UIPanel._borderTexture, this.BorderColor);
    }
  }
}
