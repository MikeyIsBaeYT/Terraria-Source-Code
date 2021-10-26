// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiaryEntryInfoPage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.Bestiary;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiaryEntryInfoPage : UIPanel
  {
    private UIList _list;
    private UIScrollbar _scrollbar;
    private bool _isScrollbarAttached;

    public UIBestiaryEntryInfoPage()
    {
      this.Width.Set(230f, 0.0f);
      this.Height.Set(0.0f, 1f);
      this.SetPadding(0.0f);
      this.BorderColor = new Color(89, 116, 213, (int) byte.MaxValue);
      this.BackgroundColor = new Color(73, 94, 171);
      UIList uiList1 = new UIList();
      uiList1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiList1.Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      UIList uiList2 = uiList1;
      uiList2.SetPadding(2f);
      uiList2.PaddingBottom = 4f;
      uiList2.PaddingTop = 4f;
      this.Append((UIElement) uiList2);
      this._list = uiList2;
      uiList2.ListPadding = 4f;
      uiList2.ManualSortMethod = new Action<List<UIElement>>(this.ManualIfnoSortingMethod);
      UIScrollbar uiScrollbar = new UIScrollbar();
      uiScrollbar.SetView(100f, 1000f);
      uiScrollbar.Height.Set(-20f, 1f);
      uiScrollbar.HAlign = 1f;
      uiScrollbar.VAlign = 0.5f;
      uiScrollbar.Left.Set(-6f, 0.0f);
      this._scrollbar = uiScrollbar;
      this._list.SetScrollbar(this._scrollbar);
      this.CheckScrollBar();
      this.AppendBorderOverEverything();
    }

    public void UpdateScrollbar(int scrollWheelValue)
    {
      if (this._scrollbar == null)
        return;
      this._scrollbar.ViewPosition -= (float) scrollWheelValue;
    }

    private void AppendBorderOverEverything()
    {
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Width = new StyleDimension(0.0f, 1f);
      uiPanel1.Height = new StyleDimension(0.0f, 1f);
      uiPanel1.IgnoresMouseInteraction = true;
      UIPanel uiPanel2 = uiPanel1;
      uiPanel2.BorderColor = new Color(89, 116, 213, (int) byte.MaxValue);
      uiPanel2.BackgroundColor = Color.Transparent;
      this.Append((UIElement) uiPanel2);
    }

    private void ManualIfnoSortingMethod(List<UIElement> list)
    {
    }

    public override void Recalculate()
    {
      base.Recalculate();
      this.CheckScrollBar();
    }

    private void CheckScrollBar()
    {
      if (this._scrollbar == null)
        return;
      bool canScroll = this._scrollbar.CanScroll;
      bool flag = true;
      if (this._isScrollbarAttached && !flag)
      {
        this.RemoveChild((UIElement) this._scrollbar);
        this._isScrollbarAttached = false;
        this._list.Width.Set(0.0f, 1f);
      }
      else
      {
        if (!(!this._isScrollbarAttached & flag))
          return;
        this.Append((UIElement) this._scrollbar);
        this._isScrollbarAttached = true;
        this._list.Width.Set(-20f, 1f);
      }
    }

    public void FillInfoForEntry(BestiaryEntry entry, ExtraBestiaryInfoPageInformation extraInfo)
    {
      this._list.Clear();
      if (entry == null)
        return;
      this.AddInfoToList(entry, extraInfo);
      this.Recalculate();
    }

    private BestiaryUICollectionInfo GetUICollectionInfo(
      BestiaryEntry entry,
      ExtraBestiaryInfoPageInformation extraInfo)
    {
      IBestiaryUICollectionInfoProvider uiInfoProvider = entry.UIInfoProvider;
      BestiaryUICollectionInfo uiCollectionInfo = uiInfoProvider == null ? new BestiaryUICollectionInfo() : uiInfoProvider.GetEntryUICollectionInfo();
      uiCollectionInfo.OwnerEntry = entry;
      return uiCollectionInfo;
    }

    private void AddInfoToList(BestiaryEntry entry, ExtraBestiaryInfoPageInformation extraInfo)
    {
      BestiaryUICollectionInfo uiCollectionInfo = this.GetUICollectionInfo(entry, extraInfo);
      IOrderedEnumerable<IGrouping<UIBestiaryEntryInfoPage.BestiaryInfoCategory, IBestiaryInfoElement>> orderedEnumerable = new List<IBestiaryInfoElement>((IEnumerable<IBestiaryInfoElement>) entry.Info).GroupBy<IBestiaryInfoElement, UIBestiaryEntryInfoPage.BestiaryInfoCategory>(new Func<IBestiaryInfoElement, UIBestiaryEntryInfoPage.BestiaryInfoCategory>(this.GetBestiaryInfoCategory)).OrderBy<IGrouping<UIBestiaryEntryInfoPage.BestiaryInfoCategory, IBestiaryInfoElement>, UIBestiaryEntryInfoPage.BestiaryInfoCategory>((Func<IGrouping<UIBestiaryEntryInfoPage.BestiaryInfoCategory, IBestiaryInfoElement>, UIBestiaryEntryInfoPage.BestiaryInfoCategory>) (x => x.Key));
      UIElement uiElement1 = (UIElement) null;
      foreach (IGrouping<UIBestiaryEntryInfoPage.BestiaryInfoCategory, IBestiaryInfoElement> source in (IEnumerable<IGrouping<UIBestiaryEntryInfoPage.BestiaryInfoCategory, IBestiaryInfoElement>>) orderedEnumerable)
      {
        if (source.Count<IBestiaryInfoElement>() != 0)
        {
          bool flag = false;
          foreach (IBestiaryInfoElement bestiaryInfoElement in (IEnumerable<IBestiaryInfoElement>) source)
          {
            UIElement uiElement2 = bestiaryInfoElement.ProvideUIElement(uiCollectionInfo);
            if (uiElement2 != null)
            {
              this._list.Add(uiElement2);
              flag = true;
            }
          }
          if (flag)
          {
            UIHorizontalSeparator horizontalSeparator1 = new UIHorizontalSeparator();
            horizontalSeparator1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
            horizontalSeparator1.Color = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
            UIHorizontalSeparator horizontalSeparator2 = horizontalSeparator1;
            this._list.Add((UIElement) horizontalSeparator2);
            uiElement1 = (UIElement) horizontalSeparator2;
          }
        }
      }
      this._list.Remove(uiElement1);
    }

    private UIBestiaryEntryInfoPage.BestiaryInfoCategory GetBestiaryInfoCategory(
      IBestiaryInfoElement element)
    {
      switch (element)
      {
        case NPCPortraitInfoElement _:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.Portrait;
        case FlavorTextBestiaryInfoElement _:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.FlavorText;
        case NamePlateInfoElement _:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.Nameplate;
        case ItemFromCatchingNPCBestiaryInfoElement _:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.ItemsFromCatchingNPC;
        case ItemDropBestiaryInfoElement _:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.ItemsFromDrops;
        case NPCStatsReportInfoElement _:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.Stats;
        default:
          return UIBestiaryEntryInfoPage.BestiaryInfoCategory.Misc;
      }
    }

    private enum BestiaryInfoCategory
    {
      Nameplate,
      Portrait,
      FlavorText,
      Stats,
      ItemsFromCatchingNPC,
      ItemsFromDrops,
      Misc,
    }
  }
}
