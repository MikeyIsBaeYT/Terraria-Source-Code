// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiaryEntryGrid
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiaryEntryGrid : UIElement
  {
    private List<BestiaryEntry> _workingSetEntries;
    private UIElement.MouseEvent _clickOnEntryEvent;
    private int _atEntryIndex;
    private int _lastEntry;

    public event Action OnGridContentsChanged;

    public UIBestiaryEntryGrid(
      List<BestiaryEntry> workingSet,
      UIElement.MouseEvent clickOnEntryEvent)
    {
      this.Width = new StyleDimension(0.0f, 1f);
      this.Height = new StyleDimension(0.0f, 1f);
      this._workingSetEntries = workingSet;
      this._clickOnEntryEvent = clickOnEntryEvent;
      this.SetPadding(0.0f);
      this.UpdateEntries();
      this.FillBestiarySpaceWithEntries();
    }

    public void UpdateEntries() => this._lastEntry = this._workingSetEntries.Count;

    public void FillBestiarySpaceWithEntries()
    {
      this.RemoveAllChildren();
      this.UpdateEntries();
      int maxEntriesWidth;
      int maxEntriesHeight;
      int maxEntriesToHave;
      this.GetEntriesToShow(out maxEntriesWidth, out maxEntriesHeight, out maxEntriesToHave);
      this.FixBestiaryRange(0, maxEntriesToHave);
      int atEntryIndex = this._atEntryIndex;
      int num1 = Math.Min(this._lastEntry, atEntryIndex + maxEntriesToHave);
      List<BestiaryEntry> bestiaryEntryList = new List<BestiaryEntry>();
      for (int index = atEntryIndex; index < num1; ++index)
        bestiaryEntryList.Add(this._workingSetEntries[index]);
      int num2 = 0;
      float num3 = 0.5f / (float) maxEntriesWidth;
      float num4 = 0.5f / (float) maxEntriesHeight;
      for (int index1 = 0; index1 < maxEntriesHeight; ++index1)
      {
        for (int index2 = 0; index2 < maxEntriesWidth && num2 < bestiaryEntryList.Count; ++index2)
        {
          UIElement element = (UIElement) new UIBestiaryEntryButton(bestiaryEntryList[num2], false);
          ++num2;
          element.OnClick += this._clickOnEntryEvent;
          element.VAlign = element.HAlign = 0.5f;
          element.Left.Set(0.0f, (float) ((double) index2 / (double) maxEntriesWidth - 0.5) + num3);
          element.Top.Set(0.0f, (float) ((double) index1 / (double) maxEntriesHeight - 0.5) + num4);
          element.SetSnapPoint("Entries", num2, new Vector2?(new Vector2(0.2f, 0.7f)));
          this.Append(element);
        }
      }
    }

    public override void Recalculate()
    {
      base.Recalculate();
      this.FillBestiarySpaceWithEntries();
    }

    public void GetEntriesToShow(
      out int maxEntriesWidth,
      out int maxEntriesHeight,
      out int maxEntriesToHave)
    {
      Rectangle rectangle = this.GetDimensions().ToRectangle();
      maxEntriesWidth = rectangle.Width / 72;
      maxEntriesHeight = rectangle.Height / 72;
      int num = 0;
      maxEntriesToHave = maxEntriesWidth * maxEntriesHeight - num;
    }

    public string GetRangeText()
    {
      int maxEntriesToHave;
      this.GetEntriesToShow(out int _, out int _, out maxEntriesToHave);
      int atEntryIndex = this._atEntryIndex;
      int val2 = Math.Min(this._lastEntry, atEntryIndex + maxEntriesToHave);
      return string.Format("{0}-{1} ({2})", (object) Math.Min(atEntryIndex + 1, val2), (object) val2, (object) this._lastEntry);
    }

    public void MakeButtonGoByOffset(UIElement element, int howManyPages) => element.OnClick += (UIElement.MouseEvent) ((e, v) => this.OffsetLibraryByPages(howManyPages));

    public void OffsetLibraryByPages(int howManyPages)
    {
      int maxEntriesToHave;
      this.GetEntriesToShow(out int _, out int _, out maxEntriesToHave);
      this.OffsetLibrary(howManyPages * maxEntriesToHave);
    }

    public void OffsetLibrary(int offset)
    {
      int maxEntriesToHave;
      this.GetEntriesToShow(out int _, out int _, out maxEntriesToHave);
      this.FixBestiaryRange(offset, maxEntriesToHave);
      this.FillBestiarySpaceWithEntries();
    }

    private void FixBestiaryRange(int offset, int maxEntriesToHave)
    {
      this._atEntryIndex = Utils.Clamp<int>(this._atEntryIndex + offset, 0, Math.Max(0, this._lastEntry - maxEntriesToHave));
      if (this.OnGridContentsChanged == null)
        return;
      this.OnGridContentsChanged();
    }
  }
}
