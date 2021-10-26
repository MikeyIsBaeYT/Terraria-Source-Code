// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiaryInfoItemLine
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiaryInfoItemLine : UIPanel, IManuallyOrderedUIElement
  {
    private Item _infoDisplayItem;
    private bool _hideMouseOver;

    public int OrderInUIList { get; set; }

    public UIBestiaryInfoItemLine(
      DropRateInfo info,
      BestiaryUICollectionInfo uiinfo,
      float textScale = 1f)
    {
      this._infoDisplayItem = new Item();
      this._infoDisplayItem.SetDefaults(info.itemId);
      this.SetBestiaryNotesOnItemCache(info);
      this.SetPadding(0.0f);
      this.PaddingLeft = 10f;
      this.PaddingRight = 10f;
      this.Width.Set(-14f, 1f);
      this.Height.Set(32f, 0.0f);
      this.Left.Set(5f, 0.0f);
      this.OnMouseOver += new UIElement.MouseEvent(this.MouseOver);
      this.OnMouseOut += new UIElement.MouseEvent(this.MouseOut);
      this.BorderColor = new Color(89, 116, 213, (int) byte.MaxValue);
      string stackRange;
      string droprate;
      this.GetDropInfo(info, uiinfo, out stackRange, out droprate);
      if (uiinfo.UnlockState < BestiaryEntryUnlockState.CanShowDropsWithoutDropRates_3)
      {
        this._hideMouseOver = true;
        Asset<Texture2D> texture = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Locked", (AssetRequestMode) 1);
        UIElement element = new UIElement()
        {
          Height = new StyleDimension(0.0f, 1f),
          Width = new StyleDimension(0.0f, 1f),
          HAlign = 0.5f,
          VAlign = 0.5f
        };
        element.SetPadding(0.0f);
        UIImage uiImage1 = new UIImage(texture);
        uiImage1.ImageScale = 0.55f;
        uiImage1.HAlign = 0.5f;
        uiImage1.VAlign = 0.5f;
        UIImage uiImage2 = uiImage1;
        element.Append((UIElement) uiImage2);
        this.Append(element);
      }
      else
      {
        UIItemIcon uiItemIcon = new UIItemIcon(this._infoDisplayItem, uiinfo.UnlockState < BestiaryEntryUnlockState.CanShowDropsWithoutDropRates_3);
        uiItemIcon.IgnoresMouseInteraction = true;
        uiItemIcon.HAlign = 0.0f;
        uiItemIcon.Left = new StyleDimension(4f, 0.0f);
        this.Append((UIElement) uiItemIcon);
        if (!string.IsNullOrEmpty(stackRange))
          droprate = stackRange + " " + droprate;
        UITextPanel<string> uiTextPanel = new UITextPanel<string>(droprate, textScale);
        uiTextPanel.IgnoresMouseInteraction = true;
        uiTextPanel.DrawPanel = false;
        uiTextPanel.HAlign = 1f;
        uiTextPanel.Top = new StyleDimension(-4f, 0.0f);
        this.Append((UIElement) uiTextPanel);
      }
    }

    protected void GetDropInfo(
      DropRateInfo dropRateInfo,
      BestiaryUICollectionInfo uiinfo,
      out string stackRange,
      out string droprate)
    {
      stackRange = dropRateInfo.stackMin == dropRateInfo.stackMax ? (dropRateInfo.stackMin != 1 ? " (" + (object) dropRateInfo.stackMin + ")" : "") : string.Format(" ({0}-{1})", (object) dropRateInfo.stackMin, (object) dropRateInfo.stackMax);
      string originalFormat = "P";
      if ((double) dropRateInfo.dropRate < 0.001)
        originalFormat = "P4";
      droprate = (double) dropRateInfo.dropRate == 1.0 ? "100%" : Utils.PrettifyPercentDisplay(dropRateInfo.dropRate, originalFormat);
      if (uiinfo.UnlockState == BestiaryEntryUnlockState.CanShowDropsWithDropRates_4)
        return;
      droprate = "???";
      stackRange = "";
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      base.DrawSelf(spriteBatch);
      if (!this.IsMouseHovering || this._hideMouseOver)
        return;
      this.DrawMouseOver();
    }

    private void DrawMouseOver()
    {
      Main.HoverItem = this._infoDisplayItem;
      Main.instance.MouseText("");
      Main.mouseText = true;
    }

    public override int CompareTo(object obj) => obj is IManuallyOrderedUIElement orderedUiElement ? this.OrderInUIList.CompareTo(orderedUiElement.OrderInUIList) : base.CompareTo(obj);

    private void SetBestiaryNotesOnItemCache(DropRateInfo info)
    {
      List<string> stringList = new List<string>();
      if (info.conditions == null)
        return;
      foreach (IProvideItemConditionDescription condition in info.conditions)
      {
        if (condition != null)
        {
          string conditionDescription = condition.GetConditionDescription();
          if (!string.IsNullOrWhiteSpace(conditionDescription))
            stringList.Add(conditionDescription);
        }
      }
      this._infoDisplayItem.BestiaryNotes = string.Join("\n", (IEnumerable<string>) stringList);
    }

    private void MouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this.BorderColor = Colors.FancyUIFatButtonMouseOver;
    }

    private void MouseOut(UIMouseEvent evt, UIElement listeningElement) => this.BorderColor = new Color(89, 116, 213, (int) byte.MaxValue);
  }
}
