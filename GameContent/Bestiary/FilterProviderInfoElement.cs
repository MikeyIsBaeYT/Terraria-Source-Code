// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.FilterProviderInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class FilterProviderInfoElement : 
    IFilterInfoProvider,
    IProvideSearchFilterString,
    IBestiaryInfoElement
  {
    private const int framesPerRow = 16;
    private const int framesPerColumn = 5;
    private Point _filterIconFrame;
    private string _key;

    public int DisplayTextPriority { get; set; }

    public FilterProviderInfoElement(string nameLanguageKey, int filterIconFrame)
    {
      this._key = nameLanguageKey;
      this._filterIconFrame.X = filterIconFrame % 16;
      this._filterIconFrame.Y = filterIconFrame / 16;
    }

    public UIElement GetFilterImage()
    {
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow", (AssetRequestMode) 1);
      UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(16, 5, this._filterIconFrame.X, this._filterIconFrame.Y));
      uiImageFramed.HAlign = 0.5f;
      uiImageFramed.VAlign = 0.5f;
      return (UIElement) uiImageFramed;
    }

    public string GetSearchString(ref BestiaryUICollectionInfo info) => info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0 ? (string) null : Language.GetText(this._key).Value;

    public string GetDisplayNameKey() => this._key;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info)
    {
      if (info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0)
        return (UIElement) null;
      UIPanel uiPanel = new UIPanel(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Panel", (AssetRequestMode) 1), (Asset<Texture2D>) null, customBarSize: 7);
      uiPanel.Width = new StyleDimension(-14f, 1f);
      uiPanel.Height = new StyleDimension(34f, 0.0f);
      uiPanel.BackgroundColor = new Color(43, 56, 101);
      uiPanel.BorderColor = Color.Transparent;
      uiPanel.Left = new StyleDimension(5f, 0.0f);
      UIElement button = (UIElement) uiPanel;
      button.SetPadding(0.0f);
      button.PaddingRight = 5f;
      UIElement filterImage = this.GetFilterImage();
      filterImage.HAlign = 0.0f;
      filterImage.Left = new StyleDimension(5f, 0.0f);
      UIText uiText1 = new UIText(Language.GetText(this.GetDisplayNameKey()), 0.8f);
      uiText1.HAlign = 0.0f;
      uiText1.Left = new StyleDimension(38f, 0.0f);
      uiText1.TextOriginX = 0.0f;
      uiText1.VAlign = 0.5f;
      uiText1.DynamicallyScaleDownToWidth = true;
      UIText uiText2 = uiText1;
      if (filterImage != null)
        button.Append(filterImage);
      button.Append((UIElement) uiText2);
      this.AddOnHover(button);
      return button;
    }

    private void AddOnHover(UIElement button) => button.OnUpdate += (UIElement.ElementEvent) (e => this.ShowButtonName(e));

    private void ShowButtonName(UIElement element)
    {
      if (!element.IsMouseHovering)
        return;
      string textValue = Language.GetTextValue(this.GetDisplayNameKey());
      Main.instance.MouseText(textValue);
    }
  }
}
