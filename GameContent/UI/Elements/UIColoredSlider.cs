// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIColoredSlider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIColoredSlider : UISliderBase
  {
    private Color _color;
    private LocalizedText _textKey;
    private Func<float> _getStatusTextAct;
    private Action<float> _slideKeyboardAction;
    private Func<float, Color> _blipFunc;
    private Action _slideGamepadAction;
    private const bool BOTHER_WITH_TEXT = false;
    private bool _isReallyMouseOvered;
    private bool _alreadyHovered;
    private bool _soundedUsage;

    public UIColoredSlider(
      LocalizedText textKey,
      Func<float> getStatus,
      Action<float> setStatusKeyboard,
      Action setStatusGamepad,
      Func<float, Color> blipColorFunction,
      Color color)
    {
      this._color = color;
      this._textKey = textKey;
      this._getStatusTextAct = getStatus != null ? getStatus : (Func<float>) (() => 0.0f);
      this._slideKeyboardAction = setStatusKeyboard != null ? setStatusKeyboard : (Action<float>) (s => { });
      this._blipFunc = blipColorFunction != null ? blipColorFunction : (Func<float, Color>) (s => Color.Lerp(Color.Black, Color.White, s));
      this._slideGamepadAction = setStatusGamepad;
      this._isReallyMouseOvered = false;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      UISliderBase.CurrentAimedSlider = (UIElement) null;
      if (!Main.mouseLeft)
        UISliderBase.CurrentLockedSlider = (UIElement) null;
      int usageLevel = this.GetUsageLevel();
      float num1 = 8f;
      base.DrawSelf(spriteBatch);
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2_1 = new Vector2(dimensions.X, dimensions.Y);
      bool flag1 = false;
      bool flag2 = this.IsMouseHovering;
      if (usageLevel == 2)
        flag2 = false;
      if (usageLevel == 1)
        flag2 = true;
      Vector2 vector2_2 = new Vector2(0.0f, 2f);
      Vector2 drawPosition = vector2_1 + vector2_2;
      Color.Lerp(flag1 ? Color.Gold : (flag2 ? Color.White : Color.Silver), Color.White, flag2 ? 0.5f : 0.0f);
      Vector2 vector2_3 = new Vector2(0.8f);
      drawPosition.X += 8f;
      drawPosition.Y += num1;
      drawPosition.X -= 17f;
      TextureAssets.ColorBar.Frame();
      drawPosition = new Vector2((float) ((double) dimensions.X + (double) dimensions.Width - 10.0), dimensions.Y + 10f + num1);
      bool wasInBar;
      float num3 = this.DrawValueBar(spriteBatch, drawPosition, 1f, this._getStatusTextAct(), usageLevel, out wasInBar, this._blipFunc);
      if (UISliderBase.CurrentLockedSlider == this | wasInBar)
      {
        UISliderBase.CurrentAimedSlider = (UIElement) this;
        if (PlayerInput.Triggers.Current.MouseLeft && !PlayerInput.UsingGamepad && UISliderBase.CurrentLockedSlider == this)
        {
          this._slideKeyboardAction(num3);
          if (!this._soundedUsage)
            SoundEngine.PlaySound(12);
          this._soundedUsage = true;
        }
        else
          this._soundedUsage = false;
      }
      if (UISliderBase.CurrentAimedSlider != null && UISliderBase.CurrentLockedSlider == null)
        UISliderBase.CurrentLockedSlider = UISliderBase.CurrentAimedSlider;
      if (!this._isReallyMouseOvered)
        return;
      this._slideGamepadAction();
    }

    private float DrawValueBar(
      SpriteBatch sb,
      Vector2 drawPosition,
      float drawScale,
      float sliderPosition,
      int lockMode,
      out bool wasInBar,
      Func<float, Color> blipColorFunc)
    {
      Texture2D texture = TextureAssets.ColorBar.Value;
      Vector2 vector2 = new Vector2((float) texture.Width, (float) texture.Height) * drawScale;
      drawPosition.X -= (float) (int) vector2.X;
      Rectangle destinationRectangle1 = new Rectangle((int) drawPosition.X, (int) drawPosition.Y - (int) vector2.Y / 2, (int) vector2.X, (int) vector2.Y);
      Rectangle destinationRectangle2 = destinationRectangle1;
      sb.Draw(texture, destinationRectangle1, Color.White);
      float num1 = (float) destinationRectangle1.X + 5f * drawScale;
      float y = (float) destinationRectangle1.Y + 4f * drawScale;
      for (float num2 = 0.0f; (double) num2 < 167.0; ++num2)
      {
        float num3 = num2 / 167f;
        Color color = blipColorFunc(num3);
        sb.Draw(TextureAssets.ColorBlip.Value, new Vector2(num1 + num2 * drawScale, y), new Rectangle?(), color, 0.0f, Vector2.Zero, drawScale, SpriteEffects.None, 0.0f);
      }
      destinationRectangle1.X = (int) num1 - 2;
      destinationRectangle1.Y = (int) y;
      destinationRectangle1.Width -= 4;
      destinationRectangle1.Height -= 8;
      bool flag = destinationRectangle1.Contains(new Point(Main.mouseX, Main.mouseY));
      this._isReallyMouseOvered = flag;
      if (this.IgnoresMouseInteraction)
        flag = false;
      if (lockMode == 2)
        flag = false;
      if (flag || lockMode == 1)
      {
        sb.Draw(TextureAssets.ColorHighlight.Value, destinationRectangle2, Main.OurFavoriteColor);
        if (!this._alreadyHovered)
          SoundEngine.PlaySound(12);
        this._alreadyHovered = true;
      }
      else
        this._alreadyHovered = false;
      wasInBar = false;
      if (!this.IgnoresMouseInteraction)
      {
        sb.Draw(TextureAssets.ColorSlider.Value, new Vector2(num1 + 167f * drawScale * sliderPosition, y + 4f * drawScale), new Rectangle?(), Color.White, 0.0f, new Vector2(0.5f * (float) TextureAssets.ColorSlider.Value.Width, 0.5f * (float) TextureAssets.ColorSlider.Value.Height), drawScale, SpriteEffects.None, 0.0f);
        if (Main.mouseX >= destinationRectangle1.X && Main.mouseX <= destinationRectangle1.X + destinationRectangle1.Width)
        {
          wasInBar = flag;
          return (float) (Main.mouseX - destinationRectangle1.X) / (float) destinationRectangle1.Width;
        }
      }
      return destinationRectangle1.X >= Main.mouseX ? 0.0f : 1f;
    }
  }
}
