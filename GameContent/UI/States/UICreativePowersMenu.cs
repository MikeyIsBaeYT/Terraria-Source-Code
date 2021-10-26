// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UICreativePowersMenu
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Creative;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
  public class UICreativePowersMenu : UIState
  {
    private bool _hovered;
    private PowerStripUIElement _mainPowerStrip;
    private PowerStripUIElement _timePowersStrip;
    private PowerStripUIElement _weatherPowersStrip;
    private PowerStripUIElement _personalPowersStrip;
    private UICreativeInfiniteItemsDisplay _infiniteItemsWindow;
    private UIElement _container;
    private UICreativePowersMenu.MenuTree<UICreativePowersMenu.OpenMainSubCategory> _mainCategory = new UICreativePowersMenu.MenuTree<UICreativePowersMenu.OpenMainSubCategory>(UICreativePowersMenu.OpenMainSubCategory.None);
    private UICreativePowersMenu.MenuTree<UICreativePowersMenu.WeatherSubcategory> _weatherCategory = new UICreativePowersMenu.MenuTree<UICreativePowersMenu.WeatherSubcategory>(UICreativePowersMenu.WeatherSubcategory.None);
    private UICreativePowersMenu.MenuTree<UICreativePowersMenu.TimeSubcategory> _timeCategory = new UICreativePowersMenu.MenuTree<UICreativePowersMenu.TimeSubcategory>(UICreativePowersMenu.TimeSubcategory.None);
    private UICreativePowersMenu.MenuTree<UICreativePowersMenu.PersonalSubcategory> _personalCategory = new UICreativePowersMenu.MenuTree<UICreativePowersMenu.PersonalSubcategory>(UICreativePowersMenu.PersonalSubcategory.None);
    private const int INITIAL_LEFT_PIXELS = 20;
    private const int LEFT_PIXELS_PER_STRIP_DEPTH = 60;
    private const string STRIP_MAIN = "strip 0";
    private const string STRIP_DEPTH_1 = "strip 1";
    private const string STRIP_DEPTH_2 = "strip 2";
    private UIGamepadHelper _helper;

    public bool IsShowingResearchMenu => this._mainCategory.CurrentOption == 2;

    public override void OnActivate() => this.InitializePage();

    private void InitializePage()
    {
      int num1 = 270;
      int num2 = 20;
      this._container = new UIElement()
      {
        HAlign = 0.0f,
        VAlign = 0.0f,
        Width = new StyleDimension(0.0f, 1f),
        Height = new StyleDimension((float) (-num1 - num2), 1f),
        Top = new StyleDimension((float) num1, 0.0f)
      };
      this.Append(this._container);
      PowerStripUIElement powerStripUiElement1 = new PowerStripUIElement("strip 0", this.CreateMainPowerStrip());
      powerStripUiElement1.HAlign = 0.0f;
      powerStripUiElement1.VAlign = 0.5f;
      powerStripUiElement1.Left = new StyleDimension(20f, 0.0f);
      PowerStripUIElement powerStripUiElement2 = powerStripUiElement1;
      powerStripUiElement2.OnMouseOver += new UIElement.MouseEvent(this.strip_OnMouseOver);
      powerStripUiElement2.OnMouseOut += new UIElement.MouseEvent(this.strip_OnMouseOut);
      this._mainPowerStrip = powerStripUiElement2;
      PowerStripUIElement powerStripUiElement3 = new PowerStripUIElement("strip 1", this.CreateTimePowerStrip());
      powerStripUiElement3.HAlign = 0.0f;
      powerStripUiElement3.VAlign = 0.5f;
      powerStripUiElement3.Left = new StyleDimension(80f, 0.0f);
      PowerStripUIElement powerStripUiElement4 = powerStripUiElement3;
      powerStripUiElement4.OnMouseOver += new UIElement.MouseEvent(this.strip_OnMouseOver);
      powerStripUiElement4.OnMouseOut += new UIElement.MouseEvent(this.strip_OnMouseOut);
      this._timePowersStrip = powerStripUiElement4;
      PowerStripUIElement powerStripUiElement5 = new PowerStripUIElement("strip 1", this.CreateWeatherPowerStrip());
      powerStripUiElement5.HAlign = 0.0f;
      powerStripUiElement5.VAlign = 0.5f;
      powerStripUiElement5.Left = new StyleDimension(80f, 0.0f);
      PowerStripUIElement powerStripUiElement6 = powerStripUiElement5;
      powerStripUiElement6.OnMouseOver += new UIElement.MouseEvent(this.strip_OnMouseOver);
      powerStripUiElement6.OnMouseOut += new UIElement.MouseEvent(this.strip_OnMouseOut);
      this._weatherPowersStrip = powerStripUiElement6;
      PowerStripUIElement powerStripUiElement7 = new PowerStripUIElement("strip 1", this.CreatePersonalPowerStrip());
      powerStripUiElement7.HAlign = 0.0f;
      powerStripUiElement7.VAlign = 0.5f;
      powerStripUiElement7.Left = new StyleDimension(80f, 0.0f);
      PowerStripUIElement powerStripUiElement8 = powerStripUiElement7;
      powerStripUiElement8.OnMouseOver += new UIElement.MouseEvent(this.strip_OnMouseOver);
      powerStripUiElement8.OnMouseOut += new UIElement.MouseEvent(this.strip_OnMouseOut);
      this._personalPowersStrip = powerStripUiElement8;
      UICreativeInfiniteItemsDisplay infiniteItemsDisplay = new UICreativeInfiniteItemsDisplay((UIState) this);
      infiniteItemsDisplay.HAlign = 0.0f;
      infiniteItemsDisplay.VAlign = 0.5f;
      infiniteItemsDisplay.Left = new StyleDimension(80f, 0.0f);
      infiniteItemsDisplay.Width = new StyleDimension(480f, 0.0f);
      infiniteItemsDisplay.Height = new StyleDimension(-88f, 1f);
      this._infiniteItemsWindow = infiniteItemsDisplay;
      this.RefreshElementsOrder();
      this.OnUpdate += new UIElement.ElementEvent(this.UICreativePowersMenu_OnUpdate);
    }

    private List<UIElement> CreateMainPowerStrip()
    {
      UICreativePowersMenu.MenuTree<UICreativePowersMenu.OpenMainSubCategory> mainCategory = this._mainCategory;
      mainCategory.Buttons.Clear();
      List<UIElement> elements = new List<UIElement>();
      CreativePowerUIElementRequestInfo request = new CreativePowerUIElementRequestInfo()
      {
        PreferredButtonWidth = 40,
        PreferredButtonHeight = 40
      };
      GroupOptionButton<int> categoryButton1 = CreativePowersHelper.CreateCategoryButton<int>(request, 1, 0);
      categoryButton1.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.ItemDuplication));
      categoryButton1.OnClick += new UIElement.MouseEvent(this.MainCategoryButtonClick);
      categoryButton1.OnUpdate += new UIElement.ElementEvent(this.itemsWindowButton_OnUpdate);
      mainCategory.Buttons.Add(1, categoryButton1);
      elements.Add((UIElement) categoryButton1);
      GroupOptionButton<int> categoryButton2 = CreativePowersHelper.CreateCategoryButton<int>(request, 2, 0);
      categoryButton2.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.ItemResearch));
      categoryButton2.OnClick += new UIElement.MouseEvent(this.MainCategoryButtonClick);
      categoryButton2.OnUpdate += new UIElement.ElementEvent(this.researchWindowButton_OnUpdate);
      mainCategory.Buttons.Add(2, categoryButton2);
      elements.Add((UIElement) categoryButton2);
      GroupOptionButton<int> categoryButton3 = CreativePowersHelper.CreateCategoryButton<int>(request, 3, 0);
      categoryButton3.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.TimeCategory));
      categoryButton3.OnClick += new UIElement.MouseEvent(this.MainCategoryButtonClick);
      categoryButton3.OnUpdate += new UIElement.ElementEvent(this.timeCategoryButton_OnUpdate);
      mainCategory.Buttons.Add(3, categoryButton3);
      elements.Add((UIElement) categoryButton3);
      GroupOptionButton<int> categoryButton4 = CreativePowersHelper.CreateCategoryButton<int>(request, 4, 0);
      categoryButton4.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.WeatherCategory));
      categoryButton4.OnClick += new UIElement.MouseEvent(this.MainCategoryButtonClick);
      categoryButton4.OnUpdate += new UIElement.ElementEvent(this.weatherCategoryButton_OnUpdate);
      mainCategory.Buttons.Add(4, categoryButton4);
      elements.Add((UIElement) categoryButton4);
      GroupOptionButton<int> categoryButton5 = CreativePowersHelper.CreateCategoryButton<int>(request, 6, 0);
      categoryButton5.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.PersonalCategory));
      categoryButton5.OnClick += new UIElement.MouseEvent(this.MainCategoryButtonClick);
      categoryButton5.OnUpdate += new UIElement.ElementEvent(this.personalCategoryButton_OnUpdate);
      mainCategory.Buttons.Add(6, categoryButton5);
      elements.Add((UIElement) categoryButton5);
      CreativePowerManager.Instance.GetPower<CreativePowers.StopBiomeSpreadPower>().ProvidePowerButtons(request, elements);
      GroupOptionButton<int> subcategoryButton = this.CreateSubcategoryButton<CreativePowers.DifficultySliderPower>(ref request, 1, "strip 1", 5, 0, mainCategory.Buttons, mainCategory.Sliders);
      subcategoryButton.OnClick += new UIElement.MouseEvent(this.MainCategoryButtonClick);
      elements.Add((UIElement) subcategoryButton);
      return elements;
    }

    private static void CategoryButton_OnUpdate_DisplayTooltips(
      UIElement affectedElement,
      string categoryNameKey)
    {
      GroupOptionButton<int> groupOptionButton = affectedElement as GroupOptionButton<int>;
      if (!affectedElement.IsMouseHovering)
        return;
      string textValue = Language.GetTextValue(groupOptionButton.IsSelected ? categoryNameKey + "Opened" : categoryNameKey + "Closed");
      CreativePowersHelper.AddDescriptionIfNeeded(ref textValue, categoryNameKey);
      Main.instance.MouseTextNoOverride(textValue);
    }

    private void itemsWindowButton_OnUpdate(UIElement affectedElement) => UICreativePowersMenu.CategoryButton_OnUpdate_DisplayTooltips(affectedElement, "CreativePowers.InfiniteItemsCategory");

    private void researchWindowButton_OnUpdate(UIElement affectedElement) => UICreativePowersMenu.CategoryButton_OnUpdate_DisplayTooltips(affectedElement, "CreativePowers.ResearchItemsCategory");

    private void timeCategoryButton_OnUpdate(UIElement affectedElement) => UICreativePowersMenu.CategoryButton_OnUpdate_DisplayTooltips(affectedElement, "CreativePowers.TimeCategory");

    private void weatherCategoryButton_OnUpdate(UIElement affectedElement) => UICreativePowersMenu.CategoryButton_OnUpdate_DisplayTooltips(affectedElement, "CreativePowers.WeatherCategory");

    private void personalCategoryButton_OnUpdate(UIElement affectedElement) => UICreativePowersMenu.CategoryButton_OnUpdate_DisplayTooltips(affectedElement, "CreativePowers.PersonalCategory");

    private void UICreativePowersMenu_OnUpdate(UIElement affectedElement)
    {
      if (!this._hovered)
        return;
      Main.LocalPlayer.mouseInterface = true;
    }

    private void strip_OnMouseOut(UIMouseEvent evt, UIElement listeningElement) => this._hovered = false;

    private void strip_OnMouseOver(UIMouseEvent evt, UIElement listeningElement) => this._hovered = true;

    private void MainCategoryButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      this.ToggleMainCategory((listeningElement as GroupOptionButton<int>).OptionValue);
      this.RefreshElementsOrder();
    }

    private void ToggleMainCategory(int option) => this.ToggleCategory<UICreativePowersMenu.OpenMainSubCategory>(this._mainCategory, option, UICreativePowersMenu.OpenMainSubCategory.None);

    private void ToggleWeatherCategory(int option) => this.ToggleCategory<UICreativePowersMenu.WeatherSubcategory>(this._weatherCategory, option, UICreativePowersMenu.WeatherSubcategory.None);

    private void ToggleTimeCategory(int option) => this.ToggleCategory<UICreativePowersMenu.TimeSubcategory>(this._timeCategory, option, UICreativePowersMenu.TimeSubcategory.None);

    private void TogglePersonalCategory(int option) => this.ToggleCategory<UICreativePowersMenu.PersonalSubcategory>(this._personalCategory, option, UICreativePowersMenu.PersonalSubcategory.None);

    private void ToggleCategory<TEnum>(
      UICreativePowersMenu.MenuTree<TEnum> tree,
      int option,
      TEnum defaultOption)
      where TEnum : struct, IConvertible
    {
      if (tree.CurrentOption == option)
        option = defaultOption.ToInt32((IFormatProvider) null);
      tree.CurrentOption = option;
      foreach (GroupOptionButton<int> groupOptionButton in tree.Buttons.Values)
        groupOptionButton.SetCurrentOption(option);
    }

    private List<UIElement> CreateTimePowerStrip()
    {
      UICreativePowersMenu.MenuTree<UICreativePowersMenu.TimeSubcategory> timeCategory = this._timeCategory;
      List<UIElement> elements = new List<UIElement>();
      CreativePowerUIElementRequestInfo request = new CreativePowerUIElementRequestInfo()
      {
        PreferredButtonWidth = 40,
        PreferredButtonHeight = 40
      };
      CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().ProvidePowerButtons(request, elements);
      CreativePowerManager.Instance.GetPower<CreativePowers.StartDayImmediately>().ProvidePowerButtons(request, elements);
      CreativePowerManager.Instance.GetPower<CreativePowers.StartNoonImmediately>().ProvidePowerButtons(request, elements);
      CreativePowerManager.Instance.GetPower<CreativePowers.StartNightImmediately>().ProvidePowerButtons(request, elements);
      CreativePowerManager.Instance.GetPower<CreativePowers.StartMidnightImmediately>().ProvidePowerButtons(request, elements);
      GroupOptionButton<int> subcategoryButton = this.CreateSubcategoryButton<CreativePowers.ModifyTimeRate>(ref request, 2, "strip 2", 1, 0, timeCategory.Buttons, timeCategory.Sliders);
      subcategoryButton.OnClick += new UIElement.MouseEvent(this.TimeCategoryButtonClick);
      elements.Add((UIElement) subcategoryButton);
      return elements;
    }

    private List<UIElement> CreatePersonalPowerStrip()
    {
      UICreativePowersMenu.MenuTree<UICreativePowersMenu.PersonalSubcategory> personalCategory = this._personalCategory;
      List<UIElement> elements = new List<UIElement>();
      CreativePowerUIElementRequestInfo request = new CreativePowerUIElementRequestInfo()
      {
        PreferredButtonWidth = 40,
        PreferredButtonHeight = 40
      };
      CreativePowerManager.Instance.GetPower<CreativePowers.GodmodePower>().ProvidePowerButtons(request, elements);
      CreativePowerManager.Instance.GetPower<CreativePowers.FarPlacementRangePower>().ProvidePowerButtons(request, elements);
      GroupOptionButton<int> subcategoryButton = this.CreateSubcategoryButton<CreativePowers.SpawnRateSliderPerPlayerPower>(ref request, 2, "strip 2", 1, 0, personalCategory.Buttons, personalCategory.Sliders);
      subcategoryButton.OnClick += new UIElement.MouseEvent(this.PersonalCategoryButtonClick);
      elements.Add((UIElement) subcategoryButton);
      return elements;
    }

    private List<UIElement> CreateWeatherPowerStrip()
    {
      UICreativePowersMenu.MenuTree<UICreativePowersMenu.WeatherSubcategory> weatherCategory = this._weatherCategory;
      List<UIElement> elements = new List<UIElement>();
      CreativePowerUIElementRequestInfo request = new CreativePowerUIElementRequestInfo()
      {
        PreferredButtonWidth = 40,
        PreferredButtonHeight = 40
      };
      GroupOptionButton<int> subcategoryButton1 = this.CreateSubcategoryButton<CreativePowers.ModifyWindDirectionAndStrength>(ref request, 2, "strip 2", 1, 0, weatherCategory.Buttons, weatherCategory.Sliders);
      subcategoryButton1.OnClick += new UIElement.MouseEvent(this.WeatherCategoryButtonClick);
      elements.Add((UIElement) subcategoryButton1);
      CreativePowerManager.Instance.GetPower<CreativePowers.FreezeWindDirectionAndStrength>().ProvidePowerButtons(request, elements);
      GroupOptionButton<int> subcategoryButton2 = this.CreateSubcategoryButton<CreativePowers.ModifyRainPower>(ref request, 2, "strip 2", 2, 0, weatherCategory.Buttons, weatherCategory.Sliders);
      subcategoryButton2.OnClick += new UIElement.MouseEvent(this.WeatherCategoryButtonClick);
      elements.Add((UIElement) subcategoryButton2);
      CreativePowerManager.Instance.GetPower<CreativePowers.FreezeRainPower>().ProvidePowerButtons(request, elements);
      return elements;
    }

    private GroupOptionButton<int> CreateSubcategoryButton<T>(
      ref CreativePowerUIElementRequestInfo request,
      int subcategoryDepth,
      string subcategoryName,
      int subcategoryIndex,
      int currentSelectedInSubcategory,
      Dictionary<int, GroupOptionButton<int>> subcategoryButtons,
      Dictionary<int, UIElement> slidersSet)
      where T : ICreativePower, IProvideSliderElement, IPowerSubcategoryElement
    {
      T power = CreativePowerManager.Instance.GetPower<T>();
      UIElement uiElement = power.ProvideSlider();
      uiElement.Left = new StyleDimension((float) (20 + subcategoryDepth * 60), 0.0f);
      slidersSet[subcategoryIndex] = uiElement;
      uiElement.SetSnapPoint(subcategoryName, 0, new Vector2?(new Vector2(0.0f, 0.5f)), new Vector2?(new Vector2(28f, 0.0f)));
      GroupOptionButton<int> optionButton = power.GetOptionButton(request, subcategoryIndex, currentSelectedInSubcategory);
      subcategoryButtons[subcategoryIndex] = optionButton;
      CreativePowersHelper.UpdateUnlockStateByPower((ICreativePower) power, (UIElement) optionButton, CreativePowersHelper.CommonSelectedColor);
      return optionButton;
    }

    private void WeatherCategoryButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      GroupOptionButton<int> groupOptionButton = listeningElement as GroupOptionButton<int>;
      switch (groupOptionButton.OptionValue)
      {
        case 1:
          if (!CreativePowerManager.Instance.GetPower<CreativePowers.ModifyWindDirectionAndStrength>().GetIsUnlocked())
            return;
          break;
        case 2:
          if (!CreativePowerManager.Instance.GetPower<CreativePowers.ModifyRainPower>().GetIsUnlocked())
            return;
          break;
      }
      this.ToggleWeatherCategory(groupOptionButton.OptionValue);
      this.RefreshElementsOrder();
    }

    private void TimeCategoryButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      GroupOptionButton<int> groupOptionButton = listeningElement as GroupOptionButton<int>;
      if (groupOptionButton.OptionValue == 1 && !CreativePowerManager.Instance.GetPower<CreativePowers.ModifyTimeRate>().GetIsUnlocked())
        return;
      this.ToggleTimeCategory(groupOptionButton.OptionValue);
      this.RefreshElementsOrder();
    }

    private void PersonalCategoryButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      GroupOptionButton<int> groupOptionButton = listeningElement as GroupOptionButton<int>;
      if (groupOptionButton.OptionValue == 1 && !CreativePowerManager.Instance.GetPower<CreativePowers.SpawnRateSliderPerPlayerPower>().GetIsUnlocked())
        return;
      this.TogglePersonalCategory(groupOptionButton.OptionValue);
      this.RefreshElementsOrder();
    }

    private void RefreshElementsOrder()
    {
      this._container.RemoveAllChildren();
      this._container.Append((UIElement) this._mainPowerStrip);
      UIElement element = (UIElement) null;
      UICreativePowersMenu.MenuTree<UICreativePowersMenu.OpenMainSubCategory> mainCategory = this._mainCategory;
      if (mainCategory.Sliders.TryGetValue(mainCategory.CurrentOption, out element))
        this._container.Append(element);
      if (mainCategory.CurrentOption == 1)
      {
        this._infiniteItemsWindow.SetPageTypeToShow(UICreativeInfiniteItemsDisplay.InfiniteItemsDisplayPage.InfiniteItemsPickup);
        this._container.Append((UIElement) this._infiniteItemsWindow);
      }
      if (mainCategory.CurrentOption == 2)
      {
        this._infiniteItemsWindow.SetPageTypeToShow(UICreativeInfiniteItemsDisplay.InfiniteItemsDisplayPage.InfiniteItemsResearch);
        this._container.Append((UIElement) this._infiniteItemsWindow);
      }
      if (mainCategory.CurrentOption == 3)
      {
        this._container.Append((UIElement) this._timePowersStrip);
        UICreativePowersMenu.MenuTree<UICreativePowersMenu.TimeSubcategory> timeCategory = this._timeCategory;
        if (timeCategory.Sliders.TryGetValue(timeCategory.CurrentOption, out element))
          this._container.Append(element);
      }
      if (mainCategory.CurrentOption == 4)
      {
        this._container.Append((UIElement) this._weatherPowersStrip);
        UICreativePowersMenu.MenuTree<UICreativePowersMenu.WeatherSubcategory> weatherCategory = this._weatherCategory;
        if (weatherCategory.Sliders.TryGetValue(weatherCategory.CurrentOption, out element))
          this._container.Append(element);
      }
      if (mainCategory.CurrentOption != 6)
        return;
      this._container.Append((UIElement) this._personalPowersStrip);
      UICreativePowersMenu.MenuTree<UICreativePowersMenu.PersonalSubcategory> personalCategory = this._personalCategory;
      if (!personalCategory.Sliders.TryGetValue(personalCategory.CurrentOption, out element))
        return;
      this._container.Append(element);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      base.Draw(spriteBatch);
      this.SetupGamepadPoints(spriteBatch);
    }

    private void SetupGamepadPoints(SpriteBatch spriteBatch)
    {
      int currentID = 10000;
      List<SnapPoint> snapPoints = this.GetSnapPoints();
      List<SnapPoint> pointsByCategoryName1 = this._helper.GetOrderedPointsByCategoryName(snapPoints, "strip 0");
      List<SnapPoint> pointsByCategoryName2 = this._helper.GetOrderedPointsByCategoryName(snapPoints, "strip 1");
      List<SnapPoint> pointsByCategoryName3 = this._helper.GetOrderedPointsByCategoryName(snapPoints, "strip 2");
      UILinkPoint[] uiLinkPointArray1 = (UILinkPoint[]) null;
      UILinkPoint[] uiLinkPointArray2 = (UILinkPoint[]) null;
      UILinkPoint[] stripOnRight = (UILinkPoint[]) null;
      if (pointsByCategoryName1.Count > 0)
        uiLinkPointArray1 = this._helper.CreateUILinkStripVertical(ref currentID, pointsByCategoryName1);
      if (pointsByCategoryName2.Count > 0)
        uiLinkPointArray2 = this._helper.CreateUILinkStripVertical(ref currentID, pointsByCategoryName2);
      if (pointsByCategoryName3.Count > 0)
        stripOnRight = this._helper.CreateUILinkStripVertical(ref currentID, pointsByCategoryName3);
      if (uiLinkPointArray1 != null && uiLinkPointArray2 != null)
        this._helper.LinkVerticalStrips(uiLinkPointArray1, uiLinkPointArray2, (uiLinkPointArray1.Length - uiLinkPointArray2.Length) / 2);
      if (uiLinkPointArray2 != null && stripOnRight != null)
        this._helper.LinkVerticalStrips(uiLinkPointArray2, stripOnRight, (uiLinkPointArray1.Length - uiLinkPointArray2.Length) / 2);
      UILinkPoint downSide = (UILinkPoint) null;
      UILinkPoint uiLinkPoint = (UILinkPoint) null;
      for (int index = 0; index < snapPoints.Count; ++index)
      {
        SnapPoint snap = snapPoints[index];
        string name = snap.Name;
        if (!(name == "CreativeSacrificeConfirm"))
        {
          if (name == "CreativeInfinitesSearch")
          {
            uiLinkPoint = this._helper.MakeLinkPointFromSnapPoint(currentID++, snap);
            Main.CreativeMenu.GamepadPointIdForInfiniteItemSearchHack = uiLinkPoint.ID;
          }
        }
        else
          downSide = this._helper.MakeLinkPointFromSnapPoint(currentID++, snap);
      }
      UILinkPoint point = UILinkPointNavigator.Points[15000];
      List<SnapPoint> pointsByCategoryName4 = this._helper.GetOrderedPointsByCategoryName(snapPoints, "CreativeInfinitesFilter");
      if (pointsByCategoryName4.Count > 0)
      {
        UILinkPoint[] linkStripHorizontal = this._helper.CreateUILinkStripHorizontal(ref currentID, pointsByCategoryName4);
        if (uiLinkPoint != null)
        {
          uiLinkPoint.Up = linkStripHorizontal[0].ID;
          for (int index = 0; index < linkStripHorizontal.Length; ++index)
            linkStripHorizontal[index].Down = uiLinkPoint.ID;
        }
      }
      List<SnapPoint> pointsByCategoryName5 = this._helper.GetOrderedPointsByCategoryName(snapPoints, "CreativeInfinitesSlot");
      UILinkPoint[,] uiLinkPointArray3 = (UILinkPoint[,]) null;
      if (pointsByCategoryName5.Count > 0)
      {
        uiLinkPointArray3 = this._helper.CreateUILinkPointGrid(ref currentID, pointsByCategoryName5, this._infiniteItemsWindow.GetItemsPerLine(), uiLinkPoint, uiLinkPointArray1[0]);
        this._helper.LinkVerticalStripRightSideToSingle(uiLinkPointArray1, uiLinkPointArray3[0, 0]);
      }
      else if (uiLinkPoint != null)
        this._helper.LinkVerticalStripRightSideToSingle(uiLinkPointArray1, uiLinkPoint);
      if (uiLinkPoint != null && uiLinkPointArray3 != null)
        this._helper.PairUpDown(uiLinkPoint, uiLinkPointArray3[0, 0]);
      if (point != null && this.IsShowingResearchMenu)
        this._helper.LinkVerticalStripRightSideToSingle(uiLinkPointArray1, point);
      if (downSide != null)
      {
        this._helper.PairUpDown(point, downSide);
        downSide.Left = uiLinkPointArray1[0].ID;
      }
      if (!Main.CreativeMenu.GamepadMoveToSearchButtonHack)
        return;
      Main.CreativeMenu.GamepadMoveToSearchButtonHack = false;
      if (uiLinkPoint == null)
        return;
      UILinkPointNavigator.ChangePoint(uiLinkPoint.ID);
    }

    private class MenuTree<TEnum> where TEnum : struct, IConvertible
    {
      public int CurrentOption;
      public Dictionary<int, GroupOptionButton<int>> Buttons = new Dictionary<int, GroupOptionButton<int>>();
      public Dictionary<int, UIElement> Sliders = new Dictionary<int, UIElement>();

      public MenuTree(TEnum defaultValue) => this.CurrentOption = defaultValue.ToInt32((IFormatProvider) null);
    }

    private enum OpenMainSubCategory
    {
      None,
      InfiniteItems,
      ResearchWindow,
      Time,
      Weather,
      EnemyStrengthSlider,
      PersonalPowers,
    }

    private enum WeatherSubcategory
    {
      None,
      WindSlider,
      RainSlider,
    }

    private enum TimeSubcategory
    {
      None,
      TimeRate,
    }

    private enum PersonalSubcategory
    {
      None,
      EnemySpawnRateSlider,
    }
  }
}
