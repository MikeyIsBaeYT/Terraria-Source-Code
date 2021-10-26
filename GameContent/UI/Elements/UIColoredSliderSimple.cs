// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIColoredSliderSimple
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIColoredSliderSimple : UIElement
  {
    public float FillPercent;
    public Color FilledColor = Main.OurFavoriteColor;
    public Color EmptyColor = Color.Black;

    protected override void DrawSelf(SpriteBatch spriteBatch) => this.DrawValueBarDynamicWidth(spriteBatch);

    private void DrawValueBarDynamicWidth(SpriteBatch sb)
    {
      Texture2D texture1 = TextureAssets.ColorBar.Value;
      Rectangle rectangle1 = this.GetDimensions().ToRectangle();
      Rectangle rectangle2 = new Rectangle(5, 4, 4, 4);
      Utils.DrawSplicedPanel(sb, texture1, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, rectangle2.X, rectangle2.Width, rectangle2.Y, rectangle2.Height, Color.White);
      Rectangle destinationRectangle1 = rectangle1;
      destinationRectangle1.X += rectangle2.Left;
      destinationRectangle1.Width -= rectangle2.Right;
      destinationRectangle1.Y += rectangle2.Top;
      destinationRectangle1.Height -= rectangle2.Bottom;
      Texture2D texture2 = TextureAssets.MagicPixel.Value;
      Rectangle rectangle3 = new Rectangle(0, 0, 1, 1);
      sb.Draw(texture2, destinationRectangle1, new Rectangle?(rectangle3), this.EmptyColor);
      Rectangle destinationRectangle2 = destinationRectangle1;
      destinationRectangle2.Width = (int) ((double) destinationRectangle2.Width * (double) this.FillPercent);
      sb.Draw(texture2, destinationRectangle2, new Rectangle?(rectangle3), this.FilledColor);
    }
  }
}
