// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIVerticalSlider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIVerticalSlider : UISliderBase
  {
    public float FillPercent;
    public Color FilledColor = Main.OurFavoriteColor;
    public Color EmptyColor = Color.Black;
    private Func<float> _getSliderValue;
    private Action<float> _slideKeyboardAction;
    private Func<float, Color> _blipFunc;
    private Action _slideGamepadAction;
    private bool _isReallyMouseOvered;
    private bool _soundedUsage;
    private bool _alreadyHovered;

    public UIVerticalSlider(
      Func<float> getStatus,
      Action<float> setStatusKeyboard,
      Action setStatusGamepad,
      Color color)
    {
      this._getSliderValue = getStatus != null ? getStatus : (Func<float>) (() => 0.0f);
      this._slideKeyboardAction = setStatusKeyboard != null ? setStatusKeyboard : (Action<float>) (s => { });
      this._slideGamepadAction = setStatusGamepad;
      this._isReallyMouseOvered = false;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      UISliderBase.CurrentAimedSlider = (UIElement) null;
      if (!Main.mouseLeft)
        UISliderBase.CurrentLockedSlider = (UIElement) null;
      this.GetUsageLevel();
      this.FillPercent = this._getSliderValue();
      float sliderValueThatWasSet = this.FillPercent;
      bool flag = false;
      if (this.DrawValueBarDynamicWidth(spriteBatch, out sliderValueThatWasSet))
        flag = true;
      if (UISliderBase.CurrentLockedSlider == this | flag)
      {
        UISliderBase.CurrentAimedSlider = (UIElement) this;
        if (PlayerInput.Triggers.Current.MouseLeft && !PlayerInput.UsingGamepad && UISliderBase.CurrentLockedSlider == this)
        {
          this._slideKeyboardAction(sliderValueThatWasSet);
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

    private bool DrawValueBarDynamicWidth(SpriteBatch spriteBatch, out float sliderValueThatWasSet)
    {
      sliderValueThatWasSet = 0.0f;
      Texture2D texture1 = TextureAssets.ColorBar.Value;
      Rectangle rectangle1 = this.GetDimensions().ToRectangle();
      Rectangle rectangle2 = new Rectangle(5, 4, 4, 4);
      Utils.DrawSplicedPanel(spriteBatch, texture1, rectangle1.X, rectangle1.Y, rectangle1.Width, rectangle1.Height, rectangle2.X, rectangle2.Width, rectangle2.Y, rectangle2.Height, Color.White);
      Rectangle destinationRectangle1 = rectangle1;
      destinationRectangle1.X += rectangle2.Left;
      destinationRectangle1.Width -= rectangle2.Right;
      destinationRectangle1.Y += rectangle2.Top;
      destinationRectangle1.Height -= rectangle2.Bottom;
      Texture2D texture2 = TextureAssets.MagicPixel.Value;
      Rectangle rectangle3 = new Rectangle(0, 0, 1, 1);
      spriteBatch.Draw(texture2, destinationRectangle1, new Rectangle?(rectangle3), this.EmptyColor);
      Rectangle destinationRectangle2 = destinationRectangle1;
      destinationRectangle2.Height = (int) ((double) destinationRectangle2.Height * (double) this.FillPercent);
      destinationRectangle2.Y += destinationRectangle1.Height - destinationRectangle2.Height;
      spriteBatch.Draw(texture2, destinationRectangle2, new Rectangle?(rectangle3), this.FilledColor);
      Rectangle destinationRectangle3 = Utils.CenteredRectangle(new Vector2((float) (destinationRectangle2.Center.X + 1), (float) destinationRectangle2.Top), new Vector2((float) (destinationRectangle2.Width + 16), 4f));
      Rectangle destinationRectangle4 = destinationRectangle3;
      destinationRectangle4.Inflate(2, 2);
      spriteBatch.Draw(texture2, destinationRectangle4, new Rectangle?(rectangle3), Color.Black);
      spriteBatch.Draw(texture2, destinationRectangle3, new Rectangle?(rectangle3), Color.White);
      Rectangle rectangle4 = destinationRectangle1;
      rectangle4.Inflate(4, 0);
      bool flag1 = rectangle4.Contains(Main.MouseScreen.ToPoint());
      this._isReallyMouseOvered = flag1;
      bool flag2 = flag1;
      if (this.IgnoresMouseInteraction)
        flag2 = false;
      int usageLevel = this.GetUsageLevel();
      if (usageLevel == 2)
        flag2 = false;
      if (usageLevel == 1)
        flag2 = true;
      if (flag2 || usageLevel == 1)
      {
        if (!this._alreadyHovered)
          SoundEngine.PlaySound(12);
        this._alreadyHovered = true;
      }
      else
        this._alreadyHovered = false;
      if (!flag2)
        return false;
      sliderValueThatWasSet = Utils.GetLerpValue((float) destinationRectangle1.Bottom, (float) destinationRectangle1.Top, (float) Main.mouseY, true);
      return true;
    }
  }
}
