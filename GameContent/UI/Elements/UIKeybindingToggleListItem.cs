// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIKeybindingToggleListItem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
  public class UIKeybindingToggleListItem : UIElement
  {
    private Color _color;
    private Func<string> _TextDisplayFunction;
    private Func<bool> _IsOnFunction;
    private Asset<Texture2D> _toggleTexture;

    public UIKeybindingToggleListItem(Func<string> getText, Func<bool> getStatus, Color color)
    {
      this._color = color;
      this._toggleTexture = Main.Assets.Request<Texture2D>("Images/UI/Settings_Toggle", (AssetRequestMode) 1);
      this._TextDisplayFunction = getText != null ? getText : (Func<string>) (() => "???");
      this._IsOnFunction = getStatus != null ? getStatus : (Func<bool>) (() => false);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      float num1 = 6f;
      base.DrawSelf(spriteBatch);
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2_1 = new Vector2(dimensions.X, dimensions.Y);
      Vector2 baseScale = new Vector2(0.8f);
      Color baseColor = Color.Lerp(false ? Color.Gold : (this.IsMouseHovering ? Color.White : Color.Silver), Color.White, this.IsMouseHovering ? 0.5f : 0.0f);
      Color color = this.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
      Vector2 position = vector2_1;
      Utils.DrawSettingsPanel(spriteBatch, position, num2, color);
      position.X += 8f;
      position.Y += 2f + num1;
      ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, this._TextDisplayFunction(), position, baseColor, 0.0f, Vector2.Zero, baseScale, num2);
      position.X -= 17f;
      Rectangle rectangle = new Rectangle(this._IsOnFunction() ? (this._toggleTexture.Width() - 2) / 2 + 2 : 0, 0, (this._toggleTexture.Width() - 2) / 2, this._toggleTexture.Height());
      Vector2 vector2_2 = new Vector2((float) rectangle.Width, 0.0f);
      position = new Vector2((float) ((double) dimensions.X + (double) dimensions.Width - (double) vector2_2.X - 10.0), dimensions.Y + 2f + num1);
      spriteBatch.Draw(this._toggleTexture.Value, position, new Rectangle?(rectangle), Color.White, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);
    }
  }
}
