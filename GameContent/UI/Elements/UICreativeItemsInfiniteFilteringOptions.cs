// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UICreativeItemsInfiniteFilteringOptions
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UICreativeItemsInfiniteFilteringOptions : UIElement
  {
    private EntryFilterer<Item, IItemEntryFilter> _filterer;
    private Dictionary<UIImageFramed, IItemEntryFilter> _filtersByButtons = new Dictionary<UIImageFramed, IItemEntryFilter>();
    private Dictionary<UIImageFramed, UIElement> _iconsByButtons = new Dictionary<UIImageFramed, UIElement>();
    private const int barFramesX = 2;
    private const int barFramesY = 4;

    public event Action OnClickingOption;

    public UICreativeItemsInfiniteFilteringOptions(
      EntryFilterer<Item, IItemEntryFilter> filterer,
      string snapPointsName)
    {
      this._filterer = filterer;
      int num1 = 40;
      int count = this._filterer.AvailableFilters.Count;
      int num2 = num1 * count;
      this.Height = new StyleDimension((float) num1, 0.0f);
      this.Width = new StyleDimension((float) num2, 0.0f);
      this.Top = new StyleDimension(4f, 0.0f);
      this.SetPadding(0.0f);
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Tabs_B", (AssetRequestMode) 1);
      for (int index = 0; index < this._filterer.AvailableFilters.Count; ++index)
      {
        IItemEntryFilter availableFilter = this._filterer.AvailableFilters[index];
        asset.Frame(2, 4).OffsetSize(-2, -2);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(2, 4).OffsetSize(-2, -2));
        uiImageFramed.Left.Set((float) (num1 * index), 0.0f);
        uiImageFramed.OnClick += new UIElement.MouseEvent(this.singleFilterButtonClick);
        uiImageFramed.OnMouseOver += new UIElement.MouseEvent(this.button_OnMouseOver);
        uiImageFramed.SetPadding(0.0f);
        uiImageFramed.SetSnapPoint(snapPointsName, index);
        this.AddOnHover(availableFilter, (UIElement) uiImageFramed, index);
        UIElement image = availableFilter.GetImage();
        image.IgnoresMouseInteraction = true;
        image.Left = new StyleDimension(6f, 0.0f);
        image.HAlign = 0.0f;
        uiImageFramed.Append(image);
        this._filtersByButtons[uiImageFramed] = availableFilter;
        this._iconsByButtons[uiImageFramed] = image;
        this.Append((UIElement) uiImageFramed);
        this.UpdateVisuals(uiImageFramed, index);
      }
    }

    private void button_OnMouseOver(UIMouseEvent evt, UIElement listeningElement) => SoundEngine.PlaySound(12);

    private void singleFilterButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      IItemEntryFilter itemEntryFilter;
      if (!(evt.Target is UIImageFramed target) || !this._filtersByButtons.TryGetValue(target, out itemEntryFilter))
        return;
      int num = this._filterer.AvailableFilters.IndexOf(itemEntryFilter);
      if (num == -1)
        return;
      if (!this._filterer.ActiveFilters.Contains(itemEntryFilter))
        this._filterer.ActiveFilters.Clear();
      this._filterer.ToggleFilter(num);
      this.UpdateVisuals(target, num);
      if (this.OnClickingOption == null)
        return;
      this.OnClickingOption();
    }

    private void UpdateVisuals(UIImageFramed button, int indexOfFilter)
    {
      bool flag = this._filterer.IsFilterActive(indexOfFilter);
      bool isMouseHovering = button.IsMouseHovering;
      int frameX = flag.ToInt();
      int frameY = flag.ToInt() * 2 + isMouseHovering.ToInt();
      button.SetFrame(2, 4, frameX, frameY, -2, -2);
      if (!(this._iconsByButtons[button] is IColorable iconsByButton))
        return;
      Color color = flag ? Color.White : Color.White * 0.5f;
      iconsByButton.Color = color;
    }

    private void AddOnHover(IItemEntryFilter filter, UIElement button, int indexOfFilter)
    {
      button.OnUpdate += (UIElement.ElementEvent) (element => this.ShowButtonName(element, filter, indexOfFilter));
      button.OnUpdate += (UIElement.ElementEvent) (element => this.UpdateVisuals(button as UIImageFramed, indexOfFilter));
    }

    private void ShowButtonName(UIElement element, IItemEntryFilter number, int indexOfFilter)
    {
      if (!element.IsMouseHovering)
        return;
      string textValue = Language.GetTextValue(number.GetDisplayNameKey());
      Main.instance.MouseText(textValue);
    }
  }
}
