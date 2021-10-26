// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UIResourcePackSelectionMenu
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Initializers;
using Terraria.IO;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
  public class UIResourcePackSelectionMenu : UIState
  {
    private readonly AssetSourceController _sourceController;
    private UIList _availablePacksList;
    private UIList _enabledPacksList;
    private ResourcePackList _packsList;
    private UIText _titleAvailable;
    private UIText _titleEnabled;
    private const string _snapCategory_ToggleFromOffToOn = "ToggleToOn";
    private const string _snapCategory_ToggleFromOnToOff = "ToggleToOff";
    private const string _snapCategory_InfoWhenOff = "InfoOff";
    private const string _snapCategory_InfoWhenOn = "InfoOn";
    private const string _snapCategory_OffsetOrderUp = "OrderUp";
    private const string _snapCategory_OffsetOrderDown = "OrderDown";
    private const string _snapPointName_goBack = "GoBack";
    private const string _snapPointName_openFolder = "OpenFolder";
    private UIGamepadHelper _helper;

    public UIResourcePackSelectionMenu(
      AssetSourceController sourceController,
      ResourcePackList currentResourcePackList)
    {
      this._sourceController = sourceController;
      this.BuildPage();
      this._packsList = currentResourcePackList;
      this.PopulatePackList();
    }

    private void PopulatePackList()
    {
      this._availablePacksList.Clear();
      this._enabledPacksList.Clear();
      this.CleanUpResourcePackPriority();
      IEnumerable<ResourcePack> enabledPacks = this._packsList.EnabledPacks;
      IEnumerable<ResourcePack> disabledPacks = this._packsList.DisabledPacks;
      int num1 = 0;
      foreach (ResourcePack resourcePack in disabledPacks)
      {
        UIResourcePack uiResourcePack1 = new UIResourcePack(resourcePack, num1);
        uiResourcePack1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
        UIResourcePack uiResourcePack2 = uiResourcePack1;
        UIElement packToggleButton = this.CreatePackToggleButton(resourcePack);
        packToggleButton.OnUpdate += new UIElement.ElementEvent(this.EnablePackUpdate);
        packToggleButton.SetSnapPoint("ToggleToOn", num1);
        uiResourcePack2.ContentPanel.Append(packToggleButton);
        UIElement packInfoButton = this.CreatePackInfoButton(resourcePack);
        packInfoButton.OnUpdate += new UIElement.ElementEvent(this.SeeInfoUpdate);
        packInfoButton.SetSnapPoint("InfoOff", num1);
        uiResourcePack2.ContentPanel.Append(packInfoButton);
        this._availablePacksList.Add((UIElement) uiResourcePack2);
        ++num1;
      }
      int num2 = 0;
      foreach (ResourcePack resourcePack in enabledPacks)
      {
        UIResourcePack uiResourcePack3 = new UIResourcePack(resourcePack, num2);
        uiResourcePack3.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
        UIResourcePack uiResourcePack4 = uiResourcePack3;
        if (resourcePack.IsEnabled)
        {
          UIElement packToggleButton = this.CreatePackToggleButton(resourcePack);
          packToggleButton.Left = new StyleDimension(0.0f, 0.0f);
          packToggleButton.Width = new StyleDimension(0.0f, 0.5f);
          packToggleButton.OnUpdate += new UIElement.ElementEvent(this.DisablePackUpdate);
          packToggleButton.SetSnapPoint("ToggleToOff", num2);
          uiResourcePack4.ContentPanel.Append(packToggleButton);
          UIElement packInfoButton = this.CreatePackInfoButton(resourcePack);
          packInfoButton.OnUpdate += new UIElement.ElementEvent(this.SeeInfoUpdate);
          packInfoButton.Left = new StyleDimension(0.0f, 0.5f);
          packInfoButton.Width = new StyleDimension(0.0f, 0.1666667f);
          packInfoButton.SetSnapPoint("InfoOn", num2);
          uiResourcePack4.ContentPanel.Append(packInfoButton);
          UIElement offsetButton1 = this.CreateOffsetButton(resourcePack, -1);
          offsetButton1.Left = new StyleDimension(0.0f, 0.6666667f);
          offsetButton1.Width = new StyleDimension(0.0f, 0.1666667f);
          offsetButton1.SetSnapPoint("OrderUp", num2);
          uiResourcePack4.ContentPanel.Append(offsetButton1);
          UIElement offsetButton2 = this.CreateOffsetButton(resourcePack, 1);
          offsetButton2.Left = new StyleDimension(0.0f, 0.8333334f);
          offsetButton2.Width = new StyleDimension(0.0f, 0.1666667f);
          offsetButton2.SetSnapPoint("OrderDown", num2);
          uiResourcePack4.ContentPanel.Append(offsetButton2);
        }
        this._enabledPacksList.Add((UIElement) uiResourcePack4);
        ++num2;
      }
      this.UpdateTitles();
    }

    private UIElement CreateOffsetButton(ResourcePack resourcePack, int offset)
    {
      GroupOptionButton<bool> groupOptionButton1 = new GroupOptionButton<bool>(true, (LocalizedText) null, (LocalizedText) null, Color.White, (string) null, 0.8f);
      groupOptionButton1.Left = StyleDimension.FromPercent(0.5f);
      groupOptionButton1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 0.5f);
      groupOptionButton1.Height = StyleDimension.Fill;
      GroupOptionButton<bool> groupOptionButton2 = groupOptionButton1;
      int num = (offset != -1 ? 0 : (resourcePack.SortingOrder == 0 ? 1 : 0)) | (offset != 1 ? 0 : (resourcePack.SortingOrder == this._packsList.EnabledPacks.Count<ResourcePack>() - 1 ? 1 : 0));
      Color lightCyan = Color.LightCyan;
      groupOptionButton2.SetColorsBasedOnSelectionState(lightCyan, lightCyan, 0.7f, 0.7f);
      groupOptionButton2.ShowHighlightWhenSelected = false;
      groupOptionButton2.SetPadding(0.0f);
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/TexturePackButtons", (AssetRequestMode) 1);
      UIImageFramed uiImageFramed1 = new UIImageFramed(asset, asset.Frame(2, 2, offset == 1 ? 1 : 0));
      uiImageFramed1.HAlign = 0.5f;
      uiImageFramed1.VAlign = 0.5f;
      uiImageFramed1.IgnoresMouseInteraction = true;
      UIImageFramed uiImageFramed2 = uiImageFramed1;
      groupOptionButton2.Append((UIElement) uiImageFramed2);
      groupOptionButton2.OnMouseOver += (UIElement.MouseEvent) ((evt, listeningElement) => SoundEngine.PlaySound(12));
      int offsetLocalForLambda = offset;
      if (num != 0)
        groupOptionButton2.OnClick += (UIElement.MouseEvent) ((evt, listeningElement) => SoundEngine.PlaySound(12));
      else
        groupOptionButton2.OnClick += (UIElement.MouseEvent) ((evt, listeningElement) =>
        {
          SoundEngine.PlaySound(12);
          this.OffsetResourcePackPriority(resourcePack, offsetLocalForLambda);
          this.PopulatePackList();
          Main.instance.TilePaintSystem.Reset();
        });
      if (offset == 1)
        groupOptionButton2.OnUpdate += new UIElement.ElementEvent(this.OffsetFrontwardUpdate);
      else
        groupOptionButton2.OnUpdate += new UIElement.ElementEvent(this.OffsetBackwardUpdate);
      return (UIElement) groupOptionButton2;
    }

    private UIElement CreatePackToggleButton(ResourcePack resourcePack)
    {
      Language.GetText(resourcePack.IsEnabled ? "GameUI.Enabled" : "GameUI.Disabled");
      GroupOptionButton<bool> groupOptionButton = new GroupOptionButton<bool>(true, (LocalizedText) null, (LocalizedText) null, Color.White, (string) null, 0.8f);
      groupOptionButton.Left = StyleDimension.FromPercent(0.5f);
      groupOptionButton.Width = StyleDimension.FromPixelsAndPercent(0.0f, 0.5f);
      groupOptionButton.Height = StyleDimension.Fill;
      groupOptionButton.SetColorsBasedOnSelectionState(Color.LightGreen, Color.PaleVioletRed, 0.7f, 0.7f);
      groupOptionButton.SetCurrentOption(resourcePack.IsEnabled);
      groupOptionButton.ShowHighlightWhenSelected = false;
      groupOptionButton.SetPadding(0.0f);
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/TexturePackButtons", (AssetRequestMode) 1);
      UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(2, 2, resourcePack.IsEnabled ? 0 : 1, 1));
      uiImageFramed.HAlign = 0.5f;
      uiImageFramed.VAlign = 0.5f;
      uiImageFramed.IgnoresMouseInteraction = true;
      groupOptionButton.Append((UIElement) uiImageFramed);
      groupOptionButton.OnMouseOver += (UIElement.MouseEvent) ((evt, listeningElement) => SoundEngine.PlaySound(12));
      groupOptionButton.OnClick += (UIElement.MouseEvent) ((evt, listeningElement) =>
      {
        SoundEngine.PlaySound(12);
        resourcePack.IsEnabled = !resourcePack.IsEnabled;
        this.SetResourcePackAsTopPriority(resourcePack);
        this.PopulatePackList();
        Main.instance.TilePaintSystem.Reset();
      });
      return (UIElement) groupOptionButton;
    }

    private void SetResourcePackAsTopPriority(ResourcePack resourcePack)
    {
      if (!resourcePack.IsEnabled)
        return;
      int num = -1;
      foreach (ResourcePack enabledPack in this._packsList.EnabledPacks)
      {
        if (num < enabledPack.SortingOrder && enabledPack != resourcePack)
          num = enabledPack.SortingOrder;
      }
      resourcePack.SortingOrder = num + 1;
    }

    private void OffsetResourcePackPriority(ResourcePack resourcePack, int offset)
    {
      if (!resourcePack.IsEnabled)
        return;
      List<ResourcePack> list = this._packsList.EnabledPacks.ToList<ResourcePack>();
      int index1 = list.IndexOf(resourcePack);
      int index2 = Utils.Clamp<int>(index1 + offset, 0, list.Count - 1);
      if (index2 == index1)
        return;
      int sortingOrder = list[index1].SortingOrder;
      list[index1].SortingOrder = list[index2].SortingOrder;
      list[index2].SortingOrder = sortingOrder;
    }

    private UIElement CreatePackInfoButton(ResourcePack resourcePack)
    {
      UIResourcePackInfoButton<string> resourcePackInfoButton = new UIResourcePackInfoButton<string>("", 0.8f);
      resourcePackInfoButton.Width = StyleDimension.FromPixelsAndPercent(0.0f, 0.5f);
      resourcePackInfoButton.Height = StyleDimension.Fill;
      resourcePackInfoButton.ResourcePack = resourcePack;
      resourcePackInfoButton.SetPadding(0.0f);
      UIImage uiImage = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CharInfo", (AssetRequestMode) 1));
      uiImage.HAlign = 0.5f;
      uiImage.VAlign = 0.5f;
      uiImage.IgnoresMouseInteraction = true;
      resourcePackInfoButton.Append((UIElement) uiImage);
      resourcePackInfoButton.OnMouseOver += (UIElement.MouseEvent) ((evt, listeningElement) => SoundEngine.PlaySound(12));
      resourcePackInfoButton.OnClick += new UIElement.MouseEvent(this.Click_Info);
      return (UIElement) resourcePackInfoButton;
    }

    private void Click_Info(UIMouseEvent evt, UIElement listeningElement)
    {
      if (!(listeningElement is UIResourcePackInfoButton<string> resourcePackInfoButton))
        return;
      SoundEngine.PlaySound(10);
      Main.MenuUI.SetState((UIState) new UIResourcePackInfoMenu(this, resourcePackInfoButton.ResourcePack));
    }

    private void ApplyListChanges() => this._sourceController.UseResourcePacks(new ResourcePackList(this._enabledPacksList.Select<UIElement, ResourcePack>((Func<UIElement, ResourcePack>) (uiPack => ((UIResourcePack) uiPack).ResourcePack))));

    private void CleanUpResourcePackPriority()
    {
      IOrderedEnumerable<ResourcePack> orderedEnumerable = this._packsList.EnabledPacks.OrderBy<ResourcePack, int>((Func<ResourcePack, int>) (pack => pack.SortingOrder));
      int num = 0;
      foreach (ResourcePack resourcePack in (IEnumerable<ResourcePack>) orderedEnumerable)
        resourcePack.SortingOrder = num++;
    }

    private void BuildPage()
    {
      this.RemoveAllChildren();
      UIElement uiElement = new UIElement();
      uiElement.Width.Set(0.0f, 0.8f);
      uiElement.MaxWidth.Set(800f, 0.0f);
      uiElement.MinWidth.Set(600f, 0.0f);
      uiElement.Top.Set(240f, 0.0f);
      uiElement.Height.Set(-240f, 1f);
      uiElement.HAlign = 0.5f;
      this.Append(uiElement);
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Width = StyleDimension.Fill;
      uiPanel1.Height = new StyleDimension(-110f, 1f);
      uiPanel1.BackgroundColor = new Color(33, 43, 79) * 0.8f;
      uiPanel1.PaddingRight = 0.0f;
      uiPanel1.PaddingLeft = 0.0f;
      UIPanel uiPanel2 = uiPanel1;
      uiElement.Append((UIElement) uiPanel2);
      int num1 = 35;
      int num2 = num1;
      int num3 = 30;
      UIElement element1 = new UIElement()
      {
        Width = StyleDimension.Fill,
        Height = StyleDimension.FromPixelsAndPercent((float) -(num3 + 4 + 5), 1f),
        VAlign = 1f
      };
      element1.SetPadding(0.0f);
      uiPanel2.Append(element1);
      UIElement element2 = new UIElement()
      {
        Width = new StyleDimension(-20f, 0.5f),
        Height = new StyleDimension(0.0f, 1f),
        Left = new StyleDimension(10f, 0.0f)
      };
      element2.SetPadding(0.0f);
      element1.Append(element2);
      UIElement element3 = new UIElement()
      {
        Width = new StyleDimension(-20f, 0.5f),
        Height = new StyleDimension(0.0f, 1f),
        Left = new StyleDimension(-10f, 0.0f),
        HAlign = 1f
      };
      element3.SetPadding(0.0f);
      element1.Append(element3);
      UIList uiList1 = new UIList();
      uiList1.Width = new StyleDimension(-25f, 1f);
      uiList1.Height = new StyleDimension(0.0f, 1f);
      uiList1.ListPadding = 5f;
      uiList1.HAlign = 1f;
      UIList uiList2 = uiList1;
      element2.Append((UIElement) uiList2);
      this._availablePacksList = uiList2;
      UIList uiList3 = new UIList();
      uiList3.Width = new StyleDimension(-25f, 1f);
      uiList3.Height = new StyleDimension(0.0f, 1f);
      uiList3.ListPadding = 5f;
      uiList3.HAlign = 0.0f;
      uiList3.Left = new StyleDimension(0.0f, 0.0f);
      UIList uiList4 = uiList3;
      element3.Append((UIElement) uiList4);
      this._enabledPacksList = uiList4;
      UIText uiText1 = new UIText(Language.GetText("UI.AvailableResourcePacksTitle"));
      uiText1.HAlign = 0.0f;
      uiText1.Left = new StyleDimension(25f, 0.0f);
      uiText1.Width = new StyleDimension(-25f, 0.5f);
      uiText1.VAlign = 0.0f;
      uiText1.Top = new StyleDimension(10f, 0.0f);
      UIText uiText2 = uiText1;
      this._titleAvailable = uiText2;
      uiPanel2.Append((UIElement) uiText2);
      UIText uiText3 = new UIText(Language.GetText("UI.EnabledResourcePacksTitle"));
      uiText3.HAlign = 1f;
      uiText3.Left = new StyleDimension(-25f, 0.0f);
      uiText3.Width = new StyleDimension(-25f, 0.5f);
      uiText3.VAlign = 0.0f;
      uiText3.Top = new StyleDimension(10f, 0.0f);
      UIText uiText4 = uiText3;
      this._titleEnabled = uiText4;
      uiPanel2.Append((UIElement) uiText4);
      UITextPanel<LocalizedText> uiTextPanel1 = new UITextPanel<LocalizedText>(Language.GetText("UI.ResourcePacks"), large: true);
      uiTextPanel1.HAlign = 0.5f;
      uiTextPanel1.VAlign = 0.0f;
      uiTextPanel1.Top = new StyleDimension(-44f, 0.0f);
      uiTextPanel1.BackgroundColor = new Color(73, 94, 171);
      UITextPanel<LocalizedText> uiTextPanel2 = uiTextPanel1;
      uiTextPanel2.SetPadding(13f);
      uiElement.Append((UIElement) uiTextPanel2);
      UIScrollbar uiScrollbar1 = new UIScrollbar();
      uiScrollbar1.Height = new StyleDimension(0.0f, 1f);
      uiScrollbar1.HAlign = 0.0f;
      uiScrollbar1.Left = new StyleDimension(0.0f, 0.0f);
      UIScrollbar scrollbar1 = uiScrollbar1;
      element2.Append((UIElement) scrollbar1);
      this._availablePacksList.SetScrollbar(scrollbar1);
      UIVerticalSeparator verticalSeparator1 = new UIVerticalSeparator();
      verticalSeparator1.Height = new StyleDimension(-12f, 1f);
      verticalSeparator1.HAlign = 0.5f;
      verticalSeparator1.VAlign = 1f;
      verticalSeparator1.Color = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
      UIVerticalSeparator verticalSeparator2 = verticalSeparator1;
      uiPanel2.Append((UIElement) verticalSeparator2);
      UIHorizontalSeparator horizontalSeparator1 = new UIHorizontalSeparator();
      horizontalSeparator1.Width = new StyleDimension((float) -num2, 0.5f);
      horizontalSeparator1.VAlign = 0.0f;
      horizontalSeparator1.HAlign = 0.0f;
      horizontalSeparator1.Color = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
      horizontalSeparator1.Top = new StyleDimension((float) num3, 0.0f);
      horizontalSeparator1.Left = new StyleDimension((float) num1, 0.0f);
      UIHorizontalSeparator horizontalSeparator2 = new UIHorizontalSeparator();
      horizontalSeparator2.Width = new StyleDimension((float) -num2, 0.5f);
      horizontalSeparator2.VAlign = 0.0f;
      horizontalSeparator2.HAlign = 1f;
      horizontalSeparator2.Color = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
      horizontalSeparator2.Top = new StyleDimension((float) num3, 0.0f);
      horizontalSeparator2.Left = new StyleDimension((float) -num1, 0.0f);
      UIScrollbar uiScrollbar2 = new UIScrollbar();
      uiScrollbar2.Height = new StyleDimension(0.0f, 1f);
      uiScrollbar2.HAlign = 1f;
      UIScrollbar scrollbar2 = uiScrollbar2;
      element3.Append((UIElement) scrollbar2);
      this._enabledPacksList.SetScrollbar(scrollbar2);
      this.AddBackAndFolderButtons(uiElement);
    }

    private void UpdateTitles()
    {
      this._titleAvailable.SetText(Language.GetText("UI.AvailableResourcePacksTitle").FormatWith((object) new
      {
        Amount = this._availablePacksList.Count
      }));
      this._titleEnabled.SetText(Language.GetText("UI.EnabledResourcePacksTitle").FormatWith((object) new
      {
        Amount = this._enabledPacksList.Count
      }));
    }

    private void AddBackAndFolderButtons(UIElement outerContainer)
    {
      UITextPanel<LocalizedText> uiTextPanel1 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
      uiTextPanel1.Width = new StyleDimension(-8f, 0.5f);
      uiTextPanel1.Height = new StyleDimension(50f, 0.0f);
      uiTextPanel1.VAlign = 1f;
      uiTextPanel1.HAlign = 0.0f;
      uiTextPanel1.Top = new StyleDimension(-45f, 0.0f);
      UITextPanel<LocalizedText> uiTextPanel2 = uiTextPanel1;
      uiTextPanel2.OnMouseOver += new UIElement.MouseEvent(UIResourcePackSelectionMenu.FadedMouseOver);
      uiTextPanel2.OnMouseOut += new UIElement.MouseEvent(UIResourcePackSelectionMenu.FadedMouseOut);
      uiTextPanel2.OnClick += new UIElement.MouseEvent(this.GoBackClick);
      uiTextPanel2.SetSnapPoint("GoBack", 0);
      outerContainer.Append((UIElement) uiTextPanel2);
      UITextPanel<LocalizedText> uiTextPanel3 = new UITextPanel<LocalizedText>(Language.GetText("GameUI.OpenFileFolder"), 0.7f, true);
      uiTextPanel3.Width = new StyleDimension(-8f, 0.5f);
      uiTextPanel3.Height = new StyleDimension(50f, 0.0f);
      uiTextPanel3.VAlign = 1f;
      uiTextPanel3.HAlign = 1f;
      uiTextPanel3.Top = new StyleDimension(-45f, 0.0f);
      UITextPanel<LocalizedText> uiTextPanel4 = uiTextPanel3;
      uiTextPanel4.OnMouseOver += new UIElement.MouseEvent(UIResourcePackSelectionMenu.FadedMouseOver);
      uiTextPanel4.OnMouseOut += new UIElement.MouseEvent(UIResourcePackSelectionMenu.FadedMouseOut);
      uiTextPanel4.OnClick += new UIElement.MouseEvent(this.OpenFoldersClick);
      uiTextPanel4.SetSnapPoint("OpenFolder", 0);
      outerContainer.Append((UIElement) uiTextPanel4);
    }

    private void OpenFoldersClick(UIMouseEvent evt, UIElement listeningElement)
    {
      string resourcePackFolder;
      AssetInitializer.GetResourcePacksFolderPathAndConfirmItExists(out JArray _, out resourcePackFolder);
      SoundEngine.PlaySound(12);
      Utils.OpenFolder(resourcePackFolder);
    }

    private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
    {
      this.ApplyListChanges();
      Main.SaveSettings();
      Main.menuMode = 0;
      IngameFancyUI.Close();
    }

    private static void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      ((UIPanel) evt.Target).BackgroundColor = new Color(73, 94, 171);
      ((UIPanel) evt.Target).BorderColor = Colors.FancyUIFatButtonMouseOver;
    }

    private static void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
    {
      ((UIPanel) evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.8f;
      ((UIPanel) evt.Target).BorderColor = Color.Black;
    }

    private void OffsetBackwardUpdate(UIElement affectedElement) => UIResourcePackSelectionMenu.DisplayMouseTextIfHovered(affectedElement, "UI.OffsetTexturePackPriorityDown");

    private void OffsetFrontwardUpdate(UIElement affectedElement) => UIResourcePackSelectionMenu.DisplayMouseTextIfHovered(affectedElement, "UI.OffsetTexturePackPriorityUp");

    private void EnablePackUpdate(UIElement affectedElement) => UIResourcePackSelectionMenu.DisplayMouseTextIfHovered(affectedElement, "UI.EnableTexturePack");

    private void DisablePackUpdate(UIElement affectedElement) => UIResourcePackSelectionMenu.DisplayMouseTextIfHovered(affectedElement, "UI.DisableTexturePack");

    private void SeeInfoUpdate(UIElement affectedElement) => UIResourcePackSelectionMenu.DisplayMouseTextIfHovered(affectedElement, "UI.SeeTexturePackInfo");

    private static void DisplayMouseTextIfHovered(UIElement affectedElement, string textKey)
    {
      if (!affectedElement.IsMouseHovering)
        return;
      string textValue = Language.GetTextValue(textKey);
      Main.instance.MouseText(textValue);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      base.Draw(spriteBatch);
      this.SetupGamepadPoints(spriteBatch);
    }

    private void SetupGamepadPoints(SpriteBatch spriteBatch)
    {
      UILinkPointNavigator.Shortcuts.BackButtonCommand = 1;
      int idRangeStartInclusive = 3000;
      int currentID = idRangeStartInclusive;
      List<SnapPoint> snapPoints1 = this.GetSnapPoints();
      List<SnapPoint> snapPoints2 = this._availablePacksList.GetSnapPoints();
      this._helper.CullPointsOutOfElementArea(spriteBatch, snapPoints2, (UIElement) this._availablePacksList);
      List<SnapPoint> snapPoints3 = this._enabledPacksList.GetSnapPoints();
      this._helper.CullPointsOutOfElementArea(spriteBatch, snapPoints3, (UIElement) this._enabledPacksList);
      UILinkPoint[] fromCategoryName1 = this._helper.GetVerticalStripFromCategoryName(ref currentID, snapPoints2, "ToggleToOn");
      UILinkPoint[] fromCategoryName2 = this._helper.GetVerticalStripFromCategoryName(ref currentID, snapPoints2, "InfoOff");
      UILinkPoint[] fromCategoryName3 = this._helper.GetVerticalStripFromCategoryName(ref currentID, snapPoints3, "ToggleToOff");
      UILinkPoint[] fromCategoryName4 = this._helper.GetVerticalStripFromCategoryName(ref currentID, snapPoints3, "InfoOn");
      UILinkPoint[] fromCategoryName5 = this._helper.GetVerticalStripFromCategoryName(ref currentID, snapPoints3, "OrderUp");
      UILinkPoint[] fromCategoryName6 = this._helper.GetVerticalStripFromCategoryName(ref currentID, snapPoints3, "OrderDown");
      UILinkPoint uiLinkPoint1 = (UILinkPoint) null;
      UILinkPoint uiLinkPoint2 = (UILinkPoint) null;
      for (int index = 0; index < snapPoints1.Count; ++index)
      {
        SnapPoint snap = snapPoints1[index];
        string name = snap.Name;
        if (!(name == "GoBack"))
        {
          if (name == "OpenFolder")
            uiLinkPoint2 = this._helper.MakeLinkPointFromSnapPoint(currentID++, snap);
        }
        else
          uiLinkPoint1 = this._helper.MakeLinkPointFromSnapPoint(currentID++, snap);
      }
      this._helper.LinkVerticalStrips(fromCategoryName2, fromCategoryName1, 0);
      this._helper.LinkVerticalStrips(fromCategoryName1, fromCategoryName3, 0);
      this._helper.LinkVerticalStrips(fromCategoryName3, fromCategoryName4, 0);
      this._helper.LinkVerticalStrips(fromCategoryName4, fromCategoryName5, 0);
      this._helper.LinkVerticalStrips(fromCategoryName5, fromCategoryName6, 0);
      this._helper.LinkVerticalStripBottomSideToSingle(fromCategoryName1, uiLinkPoint1);
      this._helper.LinkVerticalStripBottomSideToSingle(fromCategoryName2, uiLinkPoint1);
      this._helper.LinkVerticalStripBottomSideToSingle(fromCategoryName5, uiLinkPoint2);
      this._helper.LinkVerticalStripBottomSideToSingle(fromCategoryName6, uiLinkPoint2);
      this._helper.LinkVerticalStripBottomSideToSingle(fromCategoryName3, uiLinkPoint2);
      this._helper.LinkVerticalStripBottomSideToSingle(fromCategoryName4, uiLinkPoint2);
      this._helper.PairLeftRight(uiLinkPoint1, uiLinkPoint2);
      if (PlayerInput.UsingGamepadUI)
        this._helper.MoveToVisuallyClosestPoint(idRangeStartInclusive, currentID);
      if (!Main.CreativeMenu.GamepadMoveToSearchButtonHack)
        return;
      Main.CreativeMenu.GamepadMoveToSearchButtonHack = false;
      if (uiLinkPoint1 == null)
        return;
      UILinkPointNavigator.ChangePoint(uiLinkPoint1.ID);
    }
  }
}
