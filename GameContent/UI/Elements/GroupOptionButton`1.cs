// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.GroupOptionButton`1
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class GroupOptionButton<T> : UIElement, IGroupOptionButton where T : IConvertible
  {
    private T _currentOption;
    private readonly Asset<Texture2D> _BasePanelTexture;
    private readonly Asset<Texture2D> _selectedBorderTexture;
    private readonly Asset<Texture2D> _hoveredBorderTexture;
    private readonly Asset<Texture2D> _iconTexture;
    private readonly T _myOption;
    private Color _color;
    private Color _borderColor;
    public float FadeFromBlack = 1f;
    private float _whiteLerp = 0.7f;
    private float _opacity = 0.7f;
    private bool _hovered;
    private bool _soundedHover;
    public bool ShowHighlightWhenSelected = true;
    private bool _UseOverrideColors;
    private Color _overrideUnpickedColor = Color.White;
    private Color _overridePickedColor = Color.White;
    private float _overrideOpacityPicked;
    private float _overrideOpacityUnpicked;
    public readonly LocalizedText Description;
    private UIText _title;

    public T OptionValue => this._myOption;

    public bool IsSelected => this._currentOption.Equals((object) this._myOption);

    public GroupOptionButton(
      T option,
      LocalizedText title,
      LocalizedText description,
      Color textColor,
      string iconTexturePath,
      float textSize = 1f,
      float titleAlignmentX = 0.5f,
      float titleWidthReduction = 10f)
    {
      this._borderColor = Color.White;
      this._currentOption = option;
      this._myOption = option;
      this.Description = description;
      this.Width = StyleDimension.FromPixels(44f);
      this.Height = StyleDimension.FromPixels(34f);
      this._BasePanelTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/PanelGrayscale", (AssetRequestMode) 1);
      this._selectedBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelHighlight", (AssetRequestMode) 1);
      this._hoveredBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelBorder", (AssetRequestMode) 1);
      if (iconTexturePath != null)
        this._iconTexture = Main.Assets.Request<Texture2D>(iconTexturePath, (AssetRequestMode) 1);
      this._color = Colors.InventoryDefaultColor;
      if (title == null)
        return;
      UIText uiText1 = new UIText(title, textSize);
      uiText1.HAlign = titleAlignmentX;
      uiText1.VAlign = 0.5f;
      uiText1.Width = StyleDimension.FromPixelsAndPercent(-titleWidthReduction, 1f);
      uiText1.Top = StyleDimension.FromPixels(0.0f);
      UIText uiText2 = uiText1;
      uiText2.TextColor = textColor;
      this.Append((UIElement) uiText2);
      this._title = uiText2;
    }

    public void SetText(LocalizedText text, float textSize, Color color)
    {
      if (this._title != null)
        this._title.Remove();
      UIText uiText1 = new UIText(text, textSize);
      uiText1.HAlign = 0.5f;
      uiText1.VAlign = 0.5f;
      uiText1.Width = StyleDimension.FromPixelsAndPercent(-10f, 1f);
      uiText1.Top = StyleDimension.FromPixels(0.0f);
      UIText uiText2 = uiText1;
      uiText2.TextColor = color;
      this.Append((UIElement) uiText2);
      this._title = uiText2;
    }

    public void SetCurrentOption(T option) => this._currentOption = option;

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (this._hovered)
      {
        if (!this._soundedHover)
          SoundEngine.PlaySound(12);
        this._soundedHover = true;
      }
      else
        this._soundedHover = false;
      CalculatedStyle dimensions = this.GetDimensions();
      Color color1 = this._color;
      float num = this._opacity;
      bool isSelected = this.IsSelected;
      if (this._UseOverrideColors)
      {
        color1 = isSelected ? this._overridePickedColor : this._overrideUnpickedColor;
        num = isSelected ? this._overrideOpacityPicked : this._overrideOpacityUnpicked;
      }
      Utils.DrawSplicedPanel(spriteBatch, this._BasePanelTexture.Value, (int) dimensions.X, (int) dimensions.Y, (int) dimensions.Width, (int) dimensions.Height, 10, 10, 10, 10, Color.Lerp(Color.Black, color1, this.FadeFromBlack) * num);
      if (isSelected && this.ShowHighlightWhenSelected)
        Utils.DrawSplicedPanel(spriteBatch, this._selectedBorderTexture.Value, (int) dimensions.X + 7, (int) dimensions.Y + 7, (int) dimensions.Width - 14, (int) dimensions.Height - 14, 10, 10, 10, 10, Color.Lerp(color1, Color.White, this._whiteLerp) * num);
      if (this._hovered)
        Utils.DrawSplicedPanel(spriteBatch, this._hoveredBorderTexture.Value, (int) dimensions.X, (int) dimensions.Y, (int) dimensions.Width, (int) dimensions.Height, 10, 10, 10, 10, this._borderColor);
      if (this._iconTexture == null)
        return;
      Color color2 = Color.White;
      if (!this._hovered && !isSelected)
        color2 = Color.Lerp(color1, Color.White, this._whiteLerp) * num;
      spriteBatch.Draw(this._iconTexture.Value, new Vector2(dimensions.X + 1f, dimensions.Y + 1f), color2);
    }

    public override void MouseDown(UIMouseEvent evt)
    {
      SoundEngine.PlaySound(12);
      base.MouseDown(evt);
    }

    public override void MouseOver(UIMouseEvent evt)
    {
      base.MouseOver(evt);
      this._hovered = true;
    }

    public override void MouseOut(UIMouseEvent evt)
    {
      base.MouseOut(evt);
      this._hovered = false;
    }

    public void SetColor(Color color, float opacity)
    {
      this._color = color;
      this._opacity = opacity;
    }

    public void SetColorsBasedOnSelectionState(
      Color pickedColor,
      Color unpickedColor,
      float opacityPicked,
      float opacityNotPicked)
    {
      this._UseOverrideColors = true;
      this._overridePickedColor = pickedColor;
      this._overrideUnpickedColor = unpickedColor;
      this._overrideOpacityPicked = opacityPicked;
      this._overrideOpacityUnpicked = opacityNotPicked;
    }

    public void SetBorderColor(Color color) => this._borderColor = color;
  }
}
