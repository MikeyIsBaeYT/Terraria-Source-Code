// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiarySortingOptionsGrid
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiarySortingOptionsGrid : UIPanel
  {
    private EntrySorter<BestiaryEntry, IBestiarySortStep> _sorter;
    private List<GroupOptionButton<int>> _buttonsBySorting;
    private int _currentSelected = -1;
    private int _defaultStepIndex;

    public event Action OnClickingOption;

    public UIBestiarySortingOptionsGrid(
      EntrySorter<BestiaryEntry, IBestiarySortStep> sorter)
    {
      this._sorter = sorter;
      this._buttonsBySorting = new List<GroupOptionButton<int>>();
      this.Width = new StyleDimension(0.0f, 1f);
      this.Height = new StyleDimension(0.0f, 1f);
      this.BackgroundColor = new Color(35, 40, 83) * 0.5f;
      this.BorderColor = new Color(35, 40, 83) * 0.5f;
      this.IgnoresMouseInteraction = false;
      this.SetPadding(0.0f);
      this.BuildGrid();
    }

    private void BuildGrid()
    {
      int num1 = 2;
      int num2 = 26 + num1;
      int num3 = 0;
      for (int index = 0; index < this._sorter.Steps.Count; ++index)
      {
        if (!this._sorter.Steps[index].HiddenFromSortOptions)
          ++num3;
      }
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Width = new StyleDimension(126f, 0.0f);
      uiPanel1.Height = new StyleDimension((float) (num3 * num2 + 5 + 3), 0.0f);
      uiPanel1.HAlign = 1f;
      uiPanel1.VAlign = 0.0f;
      uiPanel1.Left = new StyleDimension(-118f, 0.0f);
      uiPanel1.Top = new StyleDimension(0.0f, 0.0f);
      UIPanel uiPanel2 = uiPanel1;
      uiPanel2.BorderColor = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
      uiPanel2.BackgroundColor = new Color(73, 94, 171) * 0.9f;
      uiPanel2.SetPadding(0.0f);
      this.Append((UIElement) uiPanel2);
      int id = 0;
      for (int index = 0; index < this._sorter.Steps.Count; ++index)
      {
        IBestiarySortStep step = this._sorter.Steps[index];
        if (!step.HiddenFromSortOptions)
        {
          GroupOptionButton<int> groupOptionButton1 = new GroupOptionButton<int>(index, Language.GetText(step.GetDisplayNameKey()), (LocalizedText) null, Color.White, (string) null, 0.8f);
          groupOptionButton1.Width = new StyleDimension(114f, 0.0f);
          groupOptionButton1.Height = new StyleDimension((float) (num2 - num1), 0.0f);
          groupOptionButton1.HAlign = 0.5f;
          groupOptionButton1.Top = new StyleDimension((float) (5 + num2 * id), 0.0f);
          GroupOptionButton<int> groupOptionButton2 = groupOptionButton1;
          groupOptionButton2.ShowHighlightWhenSelected = false;
          groupOptionButton2.OnClick += new UIElement.MouseEvent(this.ClickOption);
          groupOptionButton2.SetSnapPoint("SortSteps", id);
          uiPanel2.Append((UIElement) groupOptionButton2);
          this._buttonsBySorting.Add(groupOptionButton2);
          ++id;
        }
      }
      foreach (GroupOptionButton<int> groupOptionButton in this._buttonsBySorting)
        groupOptionButton.SetCurrentOption(-1);
    }

    private void ClickOption(UIMouseEvent evt, UIElement listeningElement)
    {
      int index = ((GroupOptionButton<int>) listeningElement).OptionValue;
      if (index == this._currentSelected)
        index = this._defaultStepIndex;
      foreach (GroupOptionButton<int> groupOptionButton in this._buttonsBySorting)
      {
        bool flag = index == groupOptionButton.OptionValue;
        groupOptionButton.SetCurrentOption(flag ? index : -1);
        if (flag)
          groupOptionButton.SetColor(new Color(152, 175, 235), 1f);
        else
          groupOptionButton.SetColor(Colors.InventoryDefaultColor, 0.7f);
      }
      this._currentSelected = index;
      this._sorter.SetPrioritizedStepIndex(index);
      if (this.OnClickingOption == null)
        return;
      this.OnClickingOption();
    }

    public void GetEntriesToShow(
      out int maxEntriesWidth,
      out int maxEntriesHeight,
      out int maxEntriesToHave)
    {
      maxEntriesWidth = 1;
      maxEntriesHeight = this._buttonsBySorting.Count;
      maxEntriesToHave = this._buttonsBySorting.Count;
    }
  }
}
