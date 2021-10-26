// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UICreativeInfiniteItemsDisplay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.UI.States;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UICreativeInfiniteItemsDisplay : UIElement
  {
    private List<int> _itemIdsAvailableTotal;
    private List<int> _itemIdsAvailableToShow;
    private CreativeUnlocksTracker _lastTrackerCheckedForEdits;
    private int _lastCheckedVersionForEdits = -1;
    private UISearchBar _searchBar;
    private UIPanel _searchBoxPanel;
    private UIState _parentUIState;
    private string _searchString;
    private UIDynamicItemCollection _itemGrid;
    private EntryFilterer<Item, IItemEntryFilter> _filterer;
    private EntrySorter<int, ICreativeItemSortStep> _sorter;
    private UIElement _containerInfinites;
    private UIElement _containerSacrifice;
    private bool _showSacrificesInsteadOfInfinites;
    public const string SnapPointName_SacrificeSlot = "CreativeSacrificeSlot";
    public const string SnapPointName_SacrificeConfirmButton = "CreativeSacrificeConfirm";
    public const string SnapPointName_InfinitesFilter = "CreativeInfinitesFilter";
    public const string SnapPointName_InfinitesSearch = "CreativeInfinitesSearch";
    public const string SnapPointName_InfinitesItemSlot = "CreativeInfinitesSlot";
    private List<UIImage> _sacrificeCogsSmall = new List<UIImage>();
    private List<UIImage> _sacrificeCogsMedium = new List<UIImage>();
    private List<UIImage> _sacrificeCogsBig = new List<UIImage>();
    private UIImageFramed _sacrificePistons;
    private UIParticleLayer _pistonParticleSystem;
    private Asset<Texture2D> _pistonParticleAsset;
    private int _sacrificeAnimationTimeLeft;
    private bool _researchComplete;
    private bool _hovered;
    private int _lastItemIdSacrificed;
    private int _lastItemAmountWeHad;
    private int _lastItemAmountWeNeededTotal;

    public UICreativeInfiniteItemsDisplay(UIState uiStateThatHoldsThis)
    {
      this._parentUIState = uiStateThatHoldsThis;
      this._itemIdsAvailableTotal = new List<int>();
      this._itemIdsAvailableToShow = new List<int>();
      this._filterer = new EntryFilterer<Item, IItemEntryFilter>();
      this._filterer.AddFilters(new List<IItemEntryFilter>()
      {
        (IItemEntryFilter) new ItemFilters.Weapon(),
        (IItemEntryFilter) new ItemFilters.Armor(),
        (IItemEntryFilter) new ItemFilters.BuildingBlock(),
        (IItemEntryFilter) new ItemFilters.GameplayItems(),
        (IItemEntryFilter) new ItemFilters.Accessories(),
        (IItemEntryFilter) new ItemFilters.Consumables(),
        (IItemEntryFilter) new ItemFilters.Materials()
      });
      this._filterer.SetSearchFilterObject<ItemFilters.BySearch>(new ItemFilters.BySearch());
      this._sorter = new EntrySorter<int, ICreativeItemSortStep>();
      this._sorter.AddSortSteps(new List<ICreativeItemSortStep>()
      {
        (ICreativeItemSortStep) new SortingSteps.ByCreativeSortingId(),
        (ICreativeItemSortStep) new SortingSteps.Alphabetical()
      });
      this._itemIdsAvailableTotal.AddRange((IEnumerable<int>) CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId.Keys.ToList<int>());
      this.BuildPage();
    }

    private void BuildPage()
    {
      this._lastCheckedVersionForEdits = -1;
      this.RemoveAllChildren();
      this.SetPadding(0.0f);
      UIElement totalContainer1 = new UIElement()
      {
        Width = StyleDimension.Fill,
        Height = StyleDimension.Fill
      };
      totalContainer1.SetPadding(0.0f);
      this._containerInfinites = totalContainer1;
      UIElement totalContainer2 = new UIElement()
      {
        Width = StyleDimension.Fill,
        Height = StyleDimension.Fill
      };
      totalContainer2.SetPadding(0.0f);
      this._containerSacrifice = totalContainer2;
      this.BuildInfinitesMenuContents(totalContainer1);
      this.BuildSacrificeMenuContents(totalContainer2);
      this.UpdateContents();
      this.OnUpdate += new UIElement.ElementEvent(this.UICreativeInfiniteItemsDisplay_OnUpdate);
    }

    private void Hover_OnUpdate(UIElement affectedElement)
    {
      if (!this._hovered)
        return;
      Main.LocalPlayer.mouseInterface = true;
    }

    private void Hover_OnMouseOut(UIMouseEvent evt, UIElement listeningElement) => this._hovered = false;

    private void Hover_OnMouseOver(UIMouseEvent evt, UIElement listeningElement) => this._hovered = true;

    private static UIPanel CreateBasicPanel()
    {
      UIPanel uiPanel = new UIPanel();
      UICreativeInfiniteItemsDisplay.SetBasicSizesForCreativeSacrificeOrInfinitesPanel((UIElement) uiPanel);
      uiPanel.BackgroundColor *= 0.8f;
      uiPanel.BorderColor *= 0.8f;
      return uiPanel;
    }

    private static void SetBasicSizesForCreativeSacrificeOrInfinitesPanel(UIElement element)
    {
      element.Width = new StyleDimension(0.0f, 1f);
      element.Height = new StyleDimension(-38f, 1f);
      element.Top = new StyleDimension(38f, 0.0f);
    }

    private void BuildInfinitesMenuContents(UIElement totalContainer)
    {
      UIPanel basicPanel = UICreativeInfiniteItemsDisplay.CreateBasicPanel();
      totalContainer.Append((UIElement) basicPanel);
      basicPanel.OnUpdate += new UIElement.ElementEvent(this.Hover_OnUpdate);
      basicPanel.OnMouseOver += new UIElement.MouseEvent(this.Hover_OnMouseOver);
      basicPanel.OnMouseOut += new UIElement.MouseEvent(this.Hover_OnMouseOut);
      UIDynamicItemCollection dynamicItemCollection = new UIDynamicItemCollection();
      this._itemGrid = dynamicItemCollection;
      UIElement uiElement = new UIElement()
      {
        Height = new StyleDimension(24f, 0.0f),
        Width = new StyleDimension(0.0f, 1f)
      };
      uiElement.SetPadding(0.0f);
      basicPanel.Append(uiElement);
      this.AddSearchBar(uiElement);
      this._searchBar.SetContents((string) null, true);
      UIList uiList1 = new UIList();
      uiList1.Width = new StyleDimension(-25f, 1f);
      uiList1.Height = new StyleDimension(-28f, 1f);
      uiList1.VAlign = 1f;
      uiList1.HAlign = 0.0f;
      UIList uiList2 = uiList1;
      basicPanel.Append((UIElement) uiList2);
      float num = 4f;
      UIScrollbar uiScrollbar = new UIScrollbar();
      uiScrollbar.Height = new StyleDimension((float) (-28.0 - (double) num * 2.0), 1f);
      uiScrollbar.Top = new StyleDimension(-num, 0.0f);
      uiScrollbar.VAlign = 1f;
      uiScrollbar.HAlign = 1f;
      UIScrollbar scrollbar = uiScrollbar;
      basicPanel.Append((UIElement) scrollbar);
      uiList2.SetScrollbar(scrollbar);
      uiList2.Add((UIElement) dynamicItemCollection);
      UICreativeItemsInfiniteFilteringOptions filteringOptions = new UICreativeItemsInfiniteFilteringOptions(this._filterer, "CreativeInfinitesFilter");
      filteringOptions.OnClickingOption += new Action(this.filtersHelper_OnClickingOption);
      filteringOptions.Left = new StyleDimension(20f, 0.0f);
      totalContainer.Append((UIElement) filteringOptions);
      filteringOptions.OnUpdate += new UIElement.ElementEvent(this.Hover_OnUpdate);
      filteringOptions.OnMouseOver += new UIElement.MouseEvent(this.Hover_OnMouseOver);
      filteringOptions.OnMouseOut += new UIElement.MouseEvent(this.Hover_OnMouseOut);
    }

    private void BuildSacrificeMenuContents(UIElement totalContainer)
    {
      UIPanel basicPanel = UICreativeInfiniteItemsDisplay.CreateBasicPanel();
      basicPanel.VAlign = 0.5f;
      basicPanel.Height = new StyleDimension(170f, 0.0f);
      basicPanel.Width = new StyleDimension(170f, 0.0f);
      basicPanel.Top = new StyleDimension();
      totalContainer.Append((UIElement) basicPanel);
      basicPanel.OnUpdate += new UIElement.ElementEvent(this.Hover_OnUpdate);
      basicPanel.OnMouseOver += new UIElement.MouseEvent(this.Hover_OnMouseOver);
      basicPanel.OnMouseOut += new UIElement.MouseEvent(this.Hover_OnMouseOut);
      this.AddCogsForSacrificeMenu((UIElement) basicPanel);
      this._pistonParticleAsset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Research_Spark", (AssetRequestMode) 1);
      float pixels = 0.0f;
      UIImage uiImage1 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Creative/Research_Slots", (AssetRequestMode) 1));
      uiImage1.HAlign = 0.5f;
      uiImage1.VAlign = 0.5f;
      uiImage1.Top = new StyleDimension(-20f, 0.0f);
      uiImage1.Left = new StyleDimension(pixels, 0.0f);
      UIImage uiImage2 = uiImage1;
      basicPanel.Append((UIElement) uiImage2);
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Research_FramedPistons", (AssetRequestMode) 1);
      UIImageFramed uiImageFramed1 = new UIImageFramed(asset, asset.Frame(verticalFrames: 9));
      uiImageFramed1.HAlign = 0.5f;
      uiImageFramed1.VAlign = 0.5f;
      uiImageFramed1.Top = new StyleDimension(-20f, 0.0f);
      uiImageFramed1.Left = new StyleDimension(pixels, 0.0f);
      uiImageFramed1.IgnoresMouseInteraction = true;
      UIImageFramed uiImageFramed2 = uiImageFramed1;
      basicPanel.Append((UIElement) uiImageFramed2);
      this._sacrificePistons = uiImageFramed2;
      UIParticleLayer uiParticleLayer = new UIParticleLayer();
      uiParticleLayer.Width = new StyleDimension(0.0f, 1f);
      uiParticleLayer.Height = new StyleDimension(0.0f, 1f);
      uiParticleLayer.AnchorPositionOffsetByPercents = Vector2.One / 2f;
      uiParticleLayer.AnchorPositionOffsetByPixels = Vector2.Zero;
      this._pistonParticleSystem = uiParticleLayer;
      uiImageFramed2.Append((UIElement) this._pistonParticleSystem);
      UIElement element = Main.CreativeMenu.ProvideItemSlotElement(0);
      element.HAlign = 0.5f;
      element.VAlign = 0.5f;
      element.Top = new StyleDimension(-15f, 0.0f);
      element.Left = new StyleDimension(pixels, 0.0f);
      element.SetSnapPoint("CreativeSacrificeSlot", 0);
      uiImage2.Append(element);
      UIText uiText1 = new UIText("(0/50)", 0.8f);
      uiText1.Top = new StyleDimension(10f, 0.0f);
      uiText1.Left = new StyleDimension(pixels, 0.0f);
      uiText1.HAlign = 0.5f;
      uiText1.VAlign = 0.5f;
      uiText1.IgnoresMouseInteraction = true;
      UIText uiText2 = uiText1;
      uiText2.OnUpdate += new UIElement.ElementEvent(this.descriptionText_OnUpdate);
      basicPanel.Append((UIElement) uiText2);
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Top = new StyleDimension(0.0f, 0.0f);
      uiPanel1.Left = new StyleDimension(pixels, 0.0f);
      uiPanel1.HAlign = 0.5f;
      uiPanel1.VAlign = 1f;
      uiPanel1.Width = new StyleDimension(124f, 0.0f);
      uiPanel1.Height = new StyleDimension(30f, 0.0f);
      UIPanel uiPanel2 = uiPanel1;
      UIText uiText3 = new UIText(Language.GetText("CreativePowers.ConfirmInfiniteItemSacrifice"), 0.8f);
      uiText3.IgnoresMouseInteraction = true;
      uiText3.HAlign = 0.5f;
      uiText3.VAlign = 0.5f;
      UIText uiText4 = uiText3;
      uiPanel2.Append((UIElement) uiText4);
      uiPanel2.SetSnapPoint("CreativeSacrificeConfirm", 0);
      uiPanel2.OnClick += new UIElement.MouseEvent(this.sacrificeButton_OnClick);
      uiPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiPanel2.OnUpdate += new UIElement.ElementEvent(this.research_OnUpdate);
      basicPanel.Append((UIElement) uiPanel2);
      basicPanel.OnUpdate += new UIElement.ElementEvent(this.sacrificeWindow_OnUpdate);
    }

    private void research_OnUpdate(UIElement affectedElement)
    {
      if (!affectedElement.IsMouseHovering)
        return;
      Main.instance.MouseText(Language.GetTextValue("CreativePowers.ResearchButtonTooltip"));
    }

    private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      ((UIPanel) evt.Target).BackgroundColor = new Color(73, 94, 171);
      ((UIPanel) evt.Target).BorderColor = Colors.FancyUIFatButtonMouseOver;
    }

    private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
    {
      ((UIPanel) evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.8f;
      ((UIPanel) evt.Target).BorderColor = Color.Black;
    }

    private void AddCogsForSacrificeMenu(UIElement sacrificesContainer)
    {
      UIElement uiElement = new UIElement();
      uiElement.IgnoresMouseInteraction = true;
      UICreativeInfiniteItemsDisplay.SetBasicSizesForCreativeSacrificeOrInfinitesPanel(uiElement);
      uiElement.VAlign = 0.5f;
      uiElement.Height = new StyleDimension(170f, 0.0f);
      uiElement.Width = new StyleDimension(280f, 0.0f);
      uiElement.Top = new StyleDimension();
      uiElement.SetPadding(0.0f);
      sacrificesContainer.Append(uiElement);
      Vector2 vector2 = new Vector2(-10f, -10f);
      this.AddSymetricalCogsPair(uiElement, new Vector2(22f, 1f) + vector2, "Images/UI/Creative/Research_GearC", this._sacrificeCogsSmall);
      this.AddSymetricalCogsPair(uiElement, new Vector2(1f, 28f) + vector2, "Images/UI/Creative/Research_GearB", this._sacrificeCogsMedium);
      this.AddSymetricalCogsPair(uiElement, new Vector2(5f, 5f) + vector2, "Images/UI/Creative/Research_GearA", this._sacrificeCogsBig);
    }

    private void sacrificeWindow_OnUpdate(UIElement affectedElement)
    {
      float num1 = 0.05f;
      float animationProgress = this.GetSacrificeAnimationProgress();
      double lerpValue = (double) Utils.GetLerpValue(1f, 0.7f, animationProgress, true);
      float num2 = 1f + (float) (lerpValue * lerpValue) * 2f;
      float num3 = num1 * num2;
      float num4 = 1.142857f;
      float num5 = 1f;
      UICreativeInfiniteItemsDisplay.OffsetRotationsForCogs((float) (2.0 * (double) num3), this._sacrificeCogsSmall);
      UICreativeInfiniteItemsDisplay.OffsetRotationsForCogs(num4 * num3, this._sacrificeCogsMedium);
      UICreativeInfiniteItemsDisplay.OffsetRotationsForCogs(-num5 * num3, this._sacrificeCogsBig);
      int frameY = 0;
      if (this._sacrificeAnimationTimeLeft != 0)
      {
        float num6 = 0.1f;
        float num7 = 0.06666667f;
        frameY = (double) animationProgress < 1.0 - (double) num6 ? ((double) animationProgress < 1.0 - (double) num6 * 2.0 ? ((double) animationProgress < 1.0 - (double) num6 * 3.0 ? ((double) animationProgress < (double) num7 * 4.0 ? ((double) animationProgress < (double) num7 * 3.0 ? ((double) animationProgress < (double) num7 * 2.0 ? ((double) animationProgress < (double) num7 ? 1 : 2) : 3) : 4) : 5) : 6) : 7) : 8;
        if (this._sacrificeAnimationTimeLeft == 56)
        {
          SoundEngine.PlaySound(63);
          Vector2 vector2 = new Vector2(0.0f, 0.1635f);
          for (int index = 0; index < 15; ++index)
          {
            Vector2 initialVelocity = Main.rand.NextVector2Circular(4f, 3f);
            if ((double) initialVelocity.Y > 0.0)
              initialVelocity.Y = -initialVelocity.Y;
            initialVelocity.Y -= 2f;
            this._pistonParticleSystem.AddParticle((IParticle) new CreativeSacrificeParticle(this._pistonParticleAsset, new Rectangle?(), initialVelocity, Vector2.Zero)
            {
              AccelerationPerFrame = vector2,
              ScaleOffsetPerFrame = -0.01666667f
            });
          }
        }
        if (this._sacrificeAnimationTimeLeft == 40 && this._researchComplete)
        {
          this._researchComplete = false;
          SoundEngine.PlaySound(64);
        }
      }
      this._sacrificePistons.SetFrame(1, 9, 0, frameY, 0, 0);
    }

    private static void OffsetRotationsForCogs(float rotationOffset, List<UIImage> cogsList)
    {
      cogsList[0].Rotation += rotationOffset;
      cogsList[1].Rotation -= rotationOffset;
    }

    private void AddSymetricalCogsPair(
      UIElement sacrificesContainer,
      Vector2 cogOFfsetsInPixels,
      string assetPath,
      List<UIImage> imagesList)
    {
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>(assetPath, (AssetRequestMode) 1);
      cogOFfsetsInPixels += -asset.Size() / 2f;
      UIImage uiImage1 = new UIImage(asset);
      uiImage1.NormalizedOrigin = Vector2.One / 2f;
      uiImage1.Left = new StyleDimension(cogOFfsetsInPixels.X, 0.0f);
      uiImage1.Top = new StyleDimension(cogOFfsetsInPixels.Y, 0.0f);
      UIImage uiImage2 = uiImage1;
      imagesList.Add(uiImage2);
      sacrificesContainer.Append((UIElement) uiImage2);
      UIImage uiImage3 = new UIImage(asset);
      uiImage3.NormalizedOrigin = Vector2.One / 2f;
      uiImage3.HAlign = 1f;
      uiImage3.Left = new StyleDimension(-cogOFfsetsInPixels.X, 0.0f);
      uiImage3.Top = new StyleDimension(cogOFfsetsInPixels.Y, 0.0f);
      UIImage uiImage4 = uiImage3;
      imagesList.Add(uiImage4);
      sacrificesContainer.Append((UIElement) uiImage4);
    }

    private void descriptionText_OnUpdate(UIElement affectedElement)
    {
      UIText uiText = affectedElement as UIText;
      int itemIdChecked;
      int amountWeHave;
      int amountNeededTotal;
      bool sacrificeNumbers = Main.CreativeMenu.GetSacrificeNumbers(out itemIdChecked, out amountWeHave, out amountNeededTotal);
      Main.CreativeMenu.ShouldDrawSacrificeArea();
      if (!Main.mouseItem.IsAir)
        this.ForgetItemSacrifice();
      if (itemIdChecked == 0)
      {
        if (this._lastItemIdSacrificed != 0 && this._lastItemAmountWeNeededTotal != this._lastItemAmountWeHad)
          uiText.SetText(string.Format("({0}/{1})", (object) this._lastItemAmountWeHad, (object) this._lastItemAmountWeNeededTotal));
        else
          uiText.SetText("???");
      }
      else
      {
        this.ForgetItemSacrifice();
        if (!sacrificeNumbers)
          uiText.SetText("X");
        else
          uiText.SetText(string.Format("({0}/{1})", (object) amountWeHave, (object) amountNeededTotal));
      }
    }

    private void sacrificeButton_OnClick(UIMouseEvent evt, UIElement listeningElement)
    {
      int itemIdChecked;
      int amountWeHave;
      int amountNeededTotal;
      Main.CreativeMenu.GetSacrificeNumbers(out itemIdChecked, out amountWeHave, out amountNeededTotal);
      int amountWeSacrificed;
      switch (Main.CreativeMenu.SacrificeItem(out amountWeSacrificed))
      {
        case CreativeUI.ItemSacrificeResult.SacrificedButNotDone:
          this._researchComplete = false;
          this.BeginSacrificeAnimation();
          this.RememberItemSacrifice(itemIdChecked, amountWeHave + amountWeSacrificed, amountNeededTotal);
          break;
        case CreativeUI.ItemSacrificeResult.SacrificedAndDone:
          this._researchComplete = true;
          this.BeginSacrificeAnimation();
          this.RememberItemSacrifice(itemIdChecked, amountWeHave + amountWeSacrificed, amountNeededTotal);
          break;
      }
    }

    private void RememberItemSacrifice(int itemId, int amountWeHave, int amountWeNeedTotal)
    {
      this._lastItemIdSacrificed = itemId;
      this._lastItemAmountWeHad = amountWeHave;
      this._lastItemAmountWeNeededTotal = amountWeNeedTotal;
    }

    private void ForgetItemSacrifice()
    {
      this._lastItemIdSacrificed = 0;
      this._lastItemAmountWeHad = 0;
      this._lastItemAmountWeNeededTotal = 0;
    }

    private void BeginSacrificeAnimation() => this._sacrificeAnimationTimeLeft = 60;

    private void UpdateSacrificeAnimation()
    {
      if (this._sacrificeAnimationTimeLeft <= 0)
        return;
      --this._sacrificeAnimationTimeLeft;
    }

    private float GetSacrificeAnimationProgress() => Utils.GetLerpValue(60f, 0.0f, (float) this._sacrificeAnimationTimeLeft, true);

    public void SetPageTypeToShow(
      UICreativeInfiniteItemsDisplay.InfiniteItemsDisplayPage page)
    {
      this._showSacrificesInsteadOfInfinites = page == UICreativeInfiniteItemsDisplay.InfiniteItemsDisplayPage.InfiniteItemsResearch;
    }

    private void UICreativeInfiniteItemsDisplay_OnUpdate(UIElement affectedElement)
    {
      this.RemoveAllChildren();
      CreativeUnlocksTracker playerCreativeTracker = Main.LocalPlayerCreativeTracker;
      if (this._lastTrackerCheckedForEdits != playerCreativeTracker)
      {
        this._lastTrackerCheckedForEdits = playerCreativeTracker;
        this._lastCheckedVersionForEdits = -1;
      }
      int lastEditId = playerCreativeTracker.ItemSacrifices.LastEditId;
      if (this._lastCheckedVersionForEdits != lastEditId)
      {
        this._lastCheckedVersionForEdits = lastEditId;
        this.UpdateContents();
      }
      if (this._showSacrificesInsteadOfInfinites)
        this.Append(this._containerSacrifice);
      else
        this.Append(this._containerInfinites);
      this.UpdateSacrificeAnimation();
    }

    private void filtersHelper_OnClickingOption() => this.UpdateContents();

    private void UpdateContents()
    {
      this._itemIdsAvailableTotal.Clear();
      CreativeItemSacrificesCatalog.Instance.FillListOfItemsThatCanBeObtainedInfinitely(this._itemIdsAvailableTotal);
      this._itemIdsAvailableToShow.Clear();
      this._itemIdsAvailableToShow.AddRange(this._itemIdsAvailableTotal.Where<int>((Func<int, bool>) (x => this._filterer.FitsFilter(ContentSamples.ItemsByType[x]))));
      this._itemIdsAvailableToShow.Sort((IComparer<int>) this._sorter);
      this._itemGrid.SetContentsToShow(this._itemIdsAvailableToShow);
    }

    private void AddSearchBar(UIElement searchArea)
    {
      UIImageButton uiImageButton1 = new UIImageButton(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Button_Search", (AssetRequestMode) 1));
      uiImageButton1.VAlign = 0.5f;
      uiImageButton1.HAlign = 0.0f;
      UIImageButton uiImageButton2 = uiImageButton1;
      uiImageButton2.OnClick += new UIElement.MouseEvent(this.Click_SearchArea);
      uiImageButton2.SetHoverImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Button_Search_Border", (AssetRequestMode) 1));
      uiImageButton2.SetVisibility(1f, 1f);
      uiImageButton2.SetSnapPoint("CreativeInfinitesSearch", 0);
      searchArea.Append((UIElement) uiImageButton2);
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Width = new StyleDimension((float) (-(double) uiImageButton2.Width.Pixels - 3.0), 1f);
      uiPanel1.Height = new StyleDimension(0.0f, 1f);
      uiPanel1.VAlign = 0.5f;
      uiPanel1.HAlign = 1f;
      UIPanel uiPanel2 = uiPanel1;
      this._searchBoxPanel = uiPanel2;
      uiPanel2.BackgroundColor = new Color(35, 40, 83);
      uiPanel2.BorderColor = new Color(35, 40, 83);
      uiPanel2.SetPadding(0.0f);
      searchArea.Append((UIElement) uiPanel2);
      UISearchBar uiSearchBar1 = new UISearchBar(Language.GetText("UI.PlayerNameSlot"), 0.8f);
      uiSearchBar1.Width = new StyleDimension(0.0f, 1f);
      uiSearchBar1.Height = new StyleDimension(0.0f, 1f);
      uiSearchBar1.HAlign = 0.0f;
      uiSearchBar1.VAlign = 0.5f;
      uiSearchBar1.Left = new StyleDimension(0.0f, 0.0f);
      uiSearchBar1.IgnoresMouseInteraction = true;
      UISearchBar uiSearchBar2 = uiSearchBar1;
      this._searchBar = uiSearchBar2;
      uiPanel2.OnClick += new UIElement.MouseEvent(this.Click_SearchArea);
      uiSearchBar2.OnContentsChanged += new Action<string>(this.OnSearchContentsChanged);
      uiPanel2.Append((UIElement) uiSearchBar2);
      uiSearchBar2.OnStartTakingInput += new Action(this.OnStartTakingInput);
      uiSearchBar2.OnEndTakingInput += new Action(this.OnEndTakingInput);
      uiSearchBar2.OnNeedingVirtualKeyboard += new Action(this.OpenVirtualKeyboardWhenNeeded);
      uiSearchBar2.OnCancledTakingInput += new Action(this.OnCancledInput);
    }

    private void OnCancledInput() => Main.LocalPlayer.ToggleInv();

    private void Click_SearchArea(UIMouseEvent evt, UIElement listeningElement) => this._searchBar.ToggleTakingText();

    private void OnSearchContentsChanged(string contents)
    {
      this._searchString = contents;
      this._filterer.SetSearchFilter(contents);
      this.UpdateContents();
    }

    private void OnStartTakingInput() => this._searchBoxPanel.BorderColor = Main.OurFavoriteColor;

    private void OnEndTakingInput() => this._searchBoxPanel.BorderColor = new Color(35, 40, 83);

    private void OpenVirtualKeyboardWhenNeeded()
    {
      int length = 40;
      UIVirtualKeyboard uiVirtualKeyboard = new UIVirtualKeyboard(Language.GetText("UI.PlayerNameSlot").Value, this._searchString, new UIVirtualKeyboard.KeyboardSubmitEvent(this.OnFinishedSettingName), new Action(this.GoBackHere), 3, true);
      uiVirtualKeyboard.SetMaxInputLength(length);
      IngameFancyUI.OpenUIState((UIState) uiVirtualKeyboard);
    }

    private static UserInterface GetCurrentInterface()
    {
      UserInterface activeInstance = UserInterface.ActiveInstance;
      return !Main.gameMenu ? Main.InGameUI : Main.MenuUI;
    }

    private void OnFinishedSettingName(string name)
    {
      this._searchBar.SetContents(name.Trim());
      this.GoBackHere();
    }

    private void GoBackHere()
    {
      IngameFancyUI.Close();
      this._searchBar.ToggleTakingText();
      Main.CreativeMenu.GamepadMoveToSearchButtonHack = true;
    }

    public int GetItemsPerLine() => this._itemGrid.GetItemsPerLine();

    public enum InfiniteItemsDisplayPage
    {
      InfiniteItemsPickup,
      InfiniteItemsResearch,
    }
  }
}
