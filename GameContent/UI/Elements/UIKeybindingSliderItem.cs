// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIKeybindingSliderItem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
  public class UIKeybindingSliderItem : UIElement
  {
    private Color _color;
    private Func<string> _TextDisplayFunction;
    private Func<float> _GetStatusFunction;
    private Action<float> _SlideKeyboardAction;
    private Action _SlideGamepadAction;
    private int _sliderIDInPage;
    private Asset<Texture2D> _toggleTexture;

    public UIKeybindingSliderItem(
      Func<string> getText,
      Func<float> getStatus,
      Action<float> setStatusKeyboard,
      Action setStatusGamepad,
      int sliderIDInPage,
      Color color)
    {
      this._color = color;
      this._toggleTexture = Main.Assets.Request<Texture2D>("Images/UI/Settings_Toggle", (AssetRequestMode) 1);
      this._TextDisplayFunction = getText != null ? getText : (Func<string>) (() => "???");
      this._GetStatusFunction = getStatus != null ? getStatus : (Func<float>) (() => 0.0f);
      this._SlideKeyboardAction = setStatusKeyboard != null ? setStatusKeyboard : (Action<float>) (s => { });
      this._SlideGamepadAction = setStatusGamepad != null ? setStatusGamepad : (Action) (() => { });
      this._sliderIDInPage = sliderIDInPage;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      float num1 = 6f;
      base.DrawSelf(spriteBatch);
      int lockState = 0;
      IngameOptions.rightHover = -1;
      if (!Main.mouseLeft)
        IngameOptions.rightLock = -1;
      if (IngameOptions.rightLock == this._sliderIDInPage)
        lockState = 1;
      else if (IngameOptions.rightLock != -1)
        lockState = 2;
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2 = new Vector2(dimensions.X, dimensions.Y);
      bool flag = this.IsMouseHovering;
      if (lockState == 1)
        flag = true;
      if (lockState == 2)
        flag = false;
      Vector2 baseScale = new Vector2(0.8f);
      Color baseColor = Color.Lerp(false ? Color.Gold : (flag ? Color.White : Color.Silver), Color.White, flag ? 0.5f : 0.0f);
      Color color = flag ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
      Vector2 position = vector2;
      Utils.DrawSettingsPanel(spriteBatch, position, num2, color);
      position.X += 8f;
      position.Y += 2f + num1;
      ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, this._TextDisplayFunction(), position, baseColor, 0.0f, Vector2.Zero, baseScale, num2);
      position.X -= 17f;
      TextureAssets.ColorBar.Frame();
      position = new Vector2((float) ((double) dimensions.X + (double) dimensions.Width - 10.0), dimensions.Y + 10f + num1);
      IngameOptions.valuePosition = position;
      float num3 = IngameOptions.DrawValueBar(spriteBatch, 1f, this._GetStatusFunction(), lockState);
      if (IngameOptions.inBar || IngameOptions.rightLock == this._sliderIDInPage)
      {
        IngameOptions.rightHover = this._sliderIDInPage;
        if (PlayerInput.Triggers.Current.MouseLeft && PlayerInput.CurrentProfile.AllowEditting && !PlayerInput.UsingGamepad && IngameOptions.rightLock == this._sliderIDInPage)
          this._SlideKeyboardAction(num3);
      }
      if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
        IngameOptions.rightLock = IngameOptions.rightHover;
      if (!this.IsMouseHovering || !PlayerInput.CurrentProfile.AllowEditting)
        return;
      this._SlideGamepadAction();
    }
  }
}
