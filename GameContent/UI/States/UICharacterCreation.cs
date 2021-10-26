// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UICharacterCreation
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using ReLogic.Content;
using ReLogic.OS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Terraria.Audio;
using Terraria.GameContent.Creative;
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
  public class UICharacterCreation : UIState
  {
    private int[] _validClothStyles = new int[10]
    {
      0,
      2,
      1,
      3,
      8,
      4,
      6,
      5,
      7,
      9
    };
    private readonly Player _player;
    private UIColoredImageButton[] _colorPickers;
    private UICharacterCreation.CategoryId _selectedPicker;
    private Vector3 _currentColorHSL;
    private UIColoredImageButton _clothingStylesCategoryButton;
    private UIColoredImageButton _hairStylesCategoryButton;
    private UIColoredImageButton _charInfoCategoryButton;
    private UIElement _topContainer;
    private UIElement _middleContainer;
    private UIElement _hslContainer;
    private UIElement _hairstylesContainer;
    private UIElement _clothStylesContainer;
    private UIElement _infoContainer;
    private UIText _hslHexText;
    private UIText _difficultyDescriptionText;
    private UIElement _copyHexButton;
    private UIElement _pasteHexButton;
    private UIElement _randomColorButton;
    private UIElement _copyTemplateButton;
    private UIElement _pasteTemplateButton;
    private UIElement _randomizePlayerButton;
    private UIColoredImageButton _genderMale;
    private UIColoredImageButton _genderFemale;
    private UICharacterNameButton _charName;
    private UIText _helpGlyphLeft;
    private UIText _helpGlyphRight;
    private UIGamepadHelper _helper;
    private List<int> _foundPoints = new List<int>();

    public UICharacterCreation(Player player)
    {
      this._player = player;
      this._player.difficulty = (byte) 3;
      this.BuildPage();
    }

    private void BuildPage()
    {
      this.RemoveAllChildren();
      int num = 4;
      UIElement uiElement1 = new UIElement()
      {
        Width = StyleDimension.FromPixels(500f),
        Height = StyleDimension.FromPixels((float) (380 + num)),
        Top = StyleDimension.FromPixels(220f),
        HAlign = 0.5f,
        VAlign = 0.0f
      };
      uiElement1.SetPadding(0.0f);
      this.Append(uiElement1);
      UIPanel uiPanel = new UIPanel();
      uiPanel.Width = StyleDimension.FromPercent(1f);
      uiPanel.Height = StyleDimension.FromPixels(uiElement1.Height.Pixels - 150f - (float) num);
      uiPanel.Top = StyleDimension.FromPixels(50f);
      uiPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
      UIPanel container = uiPanel;
      container.SetPadding(0.0f);
      uiElement1.Append((UIElement) container);
      this.MakeBackAndCreatebuttons(uiElement1);
      this.MakeCharPreview(container);
      UIElement uiElement2 = new UIElement()
      {
        Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        Height = StyleDimension.FromPixelsAndPercent(50f, 0.0f)
      };
      uiElement2.SetPadding(0.0f);
      uiElement2.PaddingTop = 4f;
      uiElement2.PaddingBottom = 0.0f;
      container.Append(uiElement2);
      UIElement uiElement3 = new UIElement()
      {
        Top = StyleDimension.FromPixelsAndPercent(uiElement2.Height.Pixels + 6f, 0.0f),
        Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        Height = StyleDimension.FromPixelsAndPercent(container.Height.Pixels - 70f, 0.0f)
      };
      uiElement3.SetPadding(0.0f);
      uiElement3.PaddingTop = 3f;
      uiElement3.PaddingBottom = 0.0f;
      container.Append(uiElement3);
      this._topContainer = uiElement2;
      this._middleContainer = uiElement3;
      this.MakeInfoMenu(uiElement3);
      this.MakeHSLMenu(uiElement3);
      this.MakeHairsylesMenu(uiElement3);
      this.MakeClothStylesMenu(uiElement3);
      this.MakeCategoriesBar(uiElement2);
      this.Click_CharInfo((UIMouseEvent) null, (UIElement) null);
    }

    private void MakeCharPreview(UIPanel container)
    {
      float num1 = 70f;
      for (float num2 = 0.0f; (double) num2 <= 1.0; ++num2)
      {
        UICharacter uiCharacter1 = new UICharacter(this._player, true, false, 1.5f);
        uiCharacter1.Width = StyleDimension.FromPixels(80f);
        uiCharacter1.Height = StyleDimension.FromPixelsAndPercent(80f, 0.0f);
        uiCharacter1.Top = StyleDimension.FromPixelsAndPercent(-num1, 0.0f);
        uiCharacter1.VAlign = 0.0f;
        uiCharacter1.HAlign = 0.5f;
        UICharacter uiCharacter2 = uiCharacter1;
        container.Append((UIElement) uiCharacter2);
      }
    }

    private void MakeHairsylesMenu(UIElement middleInnerPanel)
    {
      Main.Hairstyles.UpdateUnlocks();
      UIElement element = new UIElement()
      {
        Width = StyleDimension.FromPixelsAndPercent(-10f, 1f),
        Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        HAlign = 0.5f,
        VAlign = 0.5f,
        Top = StyleDimension.FromPixels(6f)
      };
      middleInnerPanel.Append(element);
      element.SetPadding(0.0f);
      UIList uiList1 = new UIList();
      uiList1.Width = StyleDimension.FromPixelsAndPercent(-18f, 1f);
      uiList1.Height = StyleDimension.FromPixelsAndPercent(-6f, 1f);
      UIList uiList2 = uiList1;
      uiList2.SetPadding(4f);
      element.Append((UIElement) uiList2);
      UIScrollbar uiScrollbar = new UIScrollbar();
      uiScrollbar.HAlign = 1f;
      uiScrollbar.Height = StyleDimension.FromPixelsAndPercent(-30f, 1f);
      uiScrollbar.Top = StyleDimension.FromPixels(10f);
      UIScrollbar scrollbar = uiScrollbar;
      scrollbar.SetView(100f, 1000f);
      uiList2.SetScrollbar(scrollbar);
      element.Append((UIElement) scrollbar);
      int count = Main.Hairstyles.AvailableHairstyles.Count;
      UIElement uiElement = new UIElement()
      {
        Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        Height = StyleDimension.FromPixelsAndPercent((float) (48 * (count / 10 + (count % 10 == 0 ? 0 : 1))), 0.0f)
      };
      uiList2.Add(uiElement);
      uiElement.SetPadding(0.0f);
      for (int index = 0; index < count; ++index)
      {
        UIHairStyleButton uiHairStyleButton1 = new UIHairStyleButton(this._player, Main.Hairstyles.AvailableHairstyles[index]);
        uiHairStyleButton1.Left = StyleDimension.FromPixels((float) ((double) (index % 10) * 46.0 + 6.0));
        uiHairStyleButton1.Top = StyleDimension.FromPixels((float) ((double) (index / 10) * 48.0 + 1.0));
        UIHairStyleButton uiHairStyleButton2 = uiHairStyleButton1;
        uiHairStyleButton2.SetSnapPoint("Middle", index);
        uiElement.Append((UIElement) uiHairStyleButton2);
      }
      this._hairstylesContainer = element;
    }

    private void MakeClothStylesMenu(UIElement middleInnerPanel)
    {
      UIElement element1 = new UIElement()
      {
        Width = StyleDimension.FromPixelsAndPercent(-10f, 1f),
        Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        HAlign = 0.5f,
        VAlign = 0.5f
      };
      middleInnerPanel.Append(element1);
      element1.SetPadding(0.0f);
      int num1 = 15;
      for (int id = 0; id < this._validClothStyles.Length; ++id)
      {
        int num2 = 0;
        if (id >= this._validClothStyles.Length / 2)
          num2 = 20;
        UIClothStyleButton clothStyleButton1 = new UIClothStyleButton(this._player, this._validClothStyles[id]);
        clothStyleButton1.Left = StyleDimension.FromPixels((float) ((double) id * 46.0 + (double) num2 + 6.0));
        clothStyleButton1.Top = StyleDimension.FromPixels((float) num1);
        UIClothStyleButton clothStyleButton2 = clothStyleButton1;
        clothStyleButton2.OnMouseDown += new UIElement.MouseEvent(this.Click_CharClothStyle);
        clothStyleButton2.SetSnapPoint("Middle", id);
        element1.Append((UIElement) clothStyleButton2);
      }
      for (int index = 0; index < 2; ++index)
      {
        int num3 = 0;
        if (index >= 1)
          num3 = 20;
        UIHorizontalSeparator horizontalSeparator1 = new UIHorizontalSeparator();
        horizontalSeparator1.Left = StyleDimension.FromPixels((float) ((double) index * 230.0 + (double) num3 + 6.0));
        horizontalSeparator1.Top = StyleDimension.FromPixels((float) (num1 + 86));
        horizontalSeparator1.Width = StyleDimension.FromPixelsAndPercent(230f, 0.0f);
        horizontalSeparator1.Color = Color.Lerp(Color.White, new Color(63, 65, 151, (int) byte.MaxValue), 0.85f) * 0.9f;
        UIHorizontalSeparator horizontalSeparator2 = horizontalSeparator1;
        element1.Append((UIElement) horizontalSeparator2);
        UIColoredImageButton pickerWithoutClick = this.CreatePickerWithoutClick(UICharacterCreation.CategoryId.Clothing, "Images/UI/CharCreation/" + (index == 0 ? "ClothStyleMale" : "ClothStyleFemale"), 0.0f, 0.0f);
        pickerWithoutClick.Top = StyleDimension.FromPixelsAndPercent((float) (num1 + 92), 0.0f);
        pickerWithoutClick.Left = StyleDimension.FromPixels((float) ((double) index * 230.0 + 92.0 + (double) num3 + 6.0));
        pickerWithoutClick.HAlign = 0.0f;
        pickerWithoutClick.VAlign = 0.0f;
        element1.Append((UIElement) pickerWithoutClick);
        if (index == 0)
        {
          pickerWithoutClick.OnMouseDown += new UIElement.MouseEvent(this.Click_CharGenderMale);
          this._genderMale = pickerWithoutClick;
        }
        else
        {
          pickerWithoutClick.OnMouseDown += new UIElement.MouseEvent(this.Click_CharGenderFemale);
          this._genderFemale = pickerWithoutClick;
        }
        pickerWithoutClick.SetSnapPoint("Low", index * 4);
      }
      UIElement element2 = new UIElement()
      {
        Width = StyleDimension.FromPixels(130f),
        Height = StyleDimension.FromPixels(50f),
        HAlign = 0.5f,
        VAlign = 1f
      };
      element1.Append(element2);
      UIColoredImageButton coloredImageButton1 = new UIColoredImageButton(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Copy", (AssetRequestMode) 1), true);
      coloredImageButton1.VAlign = 0.5f;
      coloredImageButton1.HAlign = 0.0f;
      coloredImageButton1.Left = StyleDimension.FromPixelsAndPercent(0.0f, 0.0f);
      UIColoredImageButton coloredImageButton2 = coloredImageButton1;
      coloredImageButton2.OnMouseDown += new UIElement.MouseEvent(this.Click_CopyPlayerTemplate);
      element2.Append((UIElement) coloredImageButton2);
      this._copyTemplateButton = (UIElement) coloredImageButton2;
      UIColoredImageButton coloredImageButton3 = new UIColoredImageButton(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Paste", (AssetRequestMode) 1), true);
      coloredImageButton3.VAlign = 0.5f;
      coloredImageButton3.HAlign = 0.5f;
      UIColoredImageButton coloredImageButton4 = coloredImageButton3;
      coloredImageButton4.OnMouseDown += new UIElement.MouseEvent(this.Click_PastePlayerTemplate);
      element2.Append((UIElement) coloredImageButton4);
      this._pasteTemplateButton = (UIElement) coloredImageButton4;
      UIColoredImageButton coloredImageButton5 = new UIColoredImageButton(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Randomize", (AssetRequestMode) 1), true);
      coloredImageButton5.VAlign = 0.5f;
      coloredImageButton5.HAlign = 1f;
      UIColoredImageButton coloredImageButton6 = coloredImageButton5;
      coloredImageButton6.OnMouseDown += new UIElement.MouseEvent(this.Click_RandomizePlayer);
      element2.Append((UIElement) coloredImageButton6);
      this._randomizePlayerButton = (UIElement) coloredImageButton6;
      coloredImageButton2.SetSnapPoint("Low", 1);
      coloredImageButton4.SetSnapPoint("Low", 2);
      coloredImageButton6.SetSnapPoint("Low", 3);
      this._clothStylesContainer = element1;
    }

    private void MakeCategoriesBar(UIElement categoryContainer)
    {
      float xPositionStart = -240f;
      float xPositionPerId = 48f;
      this._colorPickers = new UIColoredImageButton[10];
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.HairColor, "Images/UI/CharCreation/ColorHair", xPositionStart, xPositionPerId));
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.Eye, "Images/UI/CharCreation/ColorEye", xPositionStart, xPositionPerId));
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.Skin, "Images/UI/CharCreation/ColorSkin", xPositionStart, xPositionPerId));
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.Shirt, "Images/UI/CharCreation/ColorShirt", xPositionStart, xPositionPerId));
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.Undershirt, "Images/UI/CharCreation/ColorUndershirt", xPositionStart, xPositionPerId));
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.Pants, "Images/UI/CharCreation/ColorPants", xPositionStart, xPositionPerId));
      categoryContainer.Append((UIElement) this.CreateColorPicker(UICharacterCreation.CategoryId.Shoes, "Images/UI/CharCreation/ColorShoes", xPositionStart, xPositionPerId));
      this._colorPickers[4].SetMiddleTexture(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/ColorEyeBack", (AssetRequestMode) 1));
      this._clothingStylesCategoryButton = this.CreatePickerWithoutClick(UICharacterCreation.CategoryId.Clothing, "Images/UI/CharCreation/ClothStyleMale", xPositionStart, xPositionPerId);
      this._clothingStylesCategoryButton.OnMouseDown += new UIElement.MouseEvent(this.Click_ClothStyles);
      this._clothingStylesCategoryButton.SetSnapPoint("Top", 1);
      categoryContainer.Append((UIElement) this._clothingStylesCategoryButton);
      this._hairStylesCategoryButton = this.CreatePickerWithoutClick(UICharacterCreation.CategoryId.HairStyle, "Images/UI/CharCreation/HairStyle_Hair", xPositionStart, xPositionPerId);
      this._hairStylesCategoryButton.OnMouseDown += new UIElement.MouseEvent(this.Click_HairStyles);
      this._hairStylesCategoryButton.SetMiddleTexture(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/HairStyle_Arrow", (AssetRequestMode) 1));
      this._hairStylesCategoryButton.SetSnapPoint("Top", 2);
      categoryContainer.Append((UIElement) this._hairStylesCategoryButton);
      this._charInfoCategoryButton = this.CreatePickerWithoutClick(UICharacterCreation.CategoryId.CharInfo, "Images/UI/CharCreation/CharInfo", xPositionStart, xPositionPerId);
      this._charInfoCategoryButton.OnMouseDown += new UIElement.MouseEvent(this.Click_CharInfo);
      this._charInfoCategoryButton.SetSnapPoint("Top", 0);
      categoryContainer.Append((UIElement) this._charInfoCategoryButton);
      this.UpdateColorPickers();
      UIHorizontalSeparator horizontalSeparator1 = new UIHorizontalSeparator();
      horizontalSeparator1.Width = StyleDimension.FromPixelsAndPercent(-20f, 1f);
      horizontalSeparator1.Top = StyleDimension.FromPixels(6f);
      horizontalSeparator1.VAlign = 1f;
      horizontalSeparator1.HAlign = 0.5f;
      horizontalSeparator1.Color = Color.Lerp(Color.White, new Color(63, 65, 151, (int) byte.MaxValue), 0.85f) * 0.9f;
      UIHorizontalSeparator horizontalSeparator2 = horizontalSeparator1;
      categoryContainer.Append((UIElement) horizontalSeparator2);
      int num = 21;
      UIText uiText1 = new UIText(PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "HotbarMinus"));
      uiText1.Left = new StyleDimension((float) -num, 0.0f);
      uiText1.VAlign = 0.5f;
      uiText1.Top = new StyleDimension(-4f, 0.0f);
      UIText uiText2 = uiText1;
      categoryContainer.Append((UIElement) uiText2);
      UIText uiText3 = new UIText(PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "HotbarMinus"));
      uiText3.HAlign = 1f;
      uiText3.Left = new StyleDimension((float) (12 + num), 0.0f);
      uiText3.VAlign = 0.5f;
      uiText3.Top = new StyleDimension(-4f, 0.0f);
      UIText uiText4 = uiText3;
      categoryContainer.Append((UIElement) uiText4);
      this._helpGlyphLeft = uiText2;
      this._helpGlyphRight = uiText4;
      categoryContainer.OnUpdate += new UIElement.ElementEvent(this.UpdateHelpGlyphs);
    }

    private void UpdateHelpGlyphs(UIElement element)
    {
      string text1 = "";
      string text2 = "";
      if (PlayerInput.UsingGamepad)
      {
        text1 = PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "HotbarMinus");
        text2 = PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "HotbarPlus");
      }
      this._helpGlyphLeft.SetText(text1);
      this._helpGlyphRight.SetText(text2);
    }

    private UIColoredImageButton CreateColorPicker(
      UICharacterCreation.CategoryId id,
      string texturePath,
      float xPositionStart,
      float xPositionPerId)
    {
      UIColoredImageButton coloredImageButton = new UIColoredImageButton(Main.Assets.Request<Texture2D>(texturePath, (AssetRequestMode) 1));
      this._colorPickers[(int) id] = coloredImageButton;
      coloredImageButton.VAlign = 0.0f;
      coloredImageButton.HAlign = 0.0f;
      coloredImageButton.Left.Set(xPositionStart + (float) id * xPositionPerId, 0.5f);
      coloredImageButton.OnMouseDown += new UIElement.MouseEvent(this.Click_ColorPicker);
      coloredImageButton.SetSnapPoint("Top", (int) id);
      return coloredImageButton;
    }

    private UIColoredImageButton CreatePickerWithoutClick(
      UICharacterCreation.CategoryId id,
      string texturePath,
      float xPositionStart,
      float xPositionPerId)
    {
      UIColoredImageButton coloredImageButton = new UIColoredImageButton(Main.Assets.Request<Texture2D>(texturePath, (AssetRequestMode) 1));
      coloredImageButton.VAlign = 0.0f;
      coloredImageButton.HAlign = 0.0f;
      coloredImageButton.Left.Set(xPositionStart + (float) id * xPositionPerId, 0.5f);
      return coloredImageButton;
    }

    private void MakeInfoMenu(UIElement parentContainer)
    {
      UIElement element1 = new UIElement()
      {
        Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        HAlign = 0.5f,
        VAlign = 0.0f
      };
      element1.SetPadding(10f);
      element1.PaddingBottom = 0.0f;
      element1.PaddingTop = 0.0f;
      parentContainer.Append(element1);
      UICharacterNameButton characterNameButton = new UICharacterNameButton(Language.GetText("UI.WorldCreationName"), Language.GetText("UI.PlayerEmptyName"));
      characterNameButton.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      characterNameButton.HAlign = 0.5f;
      element1.Append((UIElement) characterNameButton);
      this._charName = characterNameButton;
      characterNameButton.OnMouseDown += new UIElement.MouseEvent(this.Click_Naming);
      characterNameButton.SetSnapPoint("Middle", 0);
      float num1 = 4f;
      float num2 = 0.0f;
      float percent = 0.4f;
      UIElement element2 = new UIElement()
      {
        HAlign = 0.0f,
        VAlign = 1f,
        Width = StyleDimension.FromPixelsAndPercent(-num1, percent),
        Height = StyleDimension.FromPixelsAndPercent(-50f, 1f)
      };
      element2.SetPadding(0.0f);
      element1.Append(element2);
      UISlicedImage uiSlicedImage1 = new UISlicedImage(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelHighlight", (AssetRequestMode) 1));
      uiSlicedImage1.HAlign = 1f;
      uiSlicedImage1.VAlign = 1f;
      uiSlicedImage1.Width = StyleDimension.FromPixelsAndPercent((float) (-(double) num1 * 2.0), 1f - percent);
      uiSlicedImage1.Left = StyleDimension.FromPixels(-num1);
      uiSlicedImage1.Height = StyleDimension.FromPixelsAndPercent(element2.Height.Pixels, element2.Height.Precent);
      UISlicedImage uiSlicedImage2 = uiSlicedImage1;
      uiSlicedImage2.SetSliceDepths(10);
      uiSlicedImage2.Color = Color.LightGray * 0.7f;
      element1.Append((UIElement) uiSlicedImage2);
      float num3 = 4f;
      UIDifficultyButton difficultyButton1 = new UIDifficultyButton(this._player, Lang.menu[26], Lang.menu[31], (byte) 0, Color.Cyan);
      difficultyButton1.HAlign = 0.0f;
      difficultyButton1.VAlign = (float) (1.0 / ((double) num3 - 1.0));
      difficultyButton1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      difficultyButton1.Height = StyleDimension.FromPixelsAndPercent(-num2, 1f / num3);
      UIDifficultyButton difficultyButton2 = difficultyButton1;
      UIDifficultyButton difficultyButton3 = new UIDifficultyButton(this._player, Lang.menu[25], Lang.menu[30], (byte) 1, Main.mcColor);
      difficultyButton3.HAlign = 0.0f;
      difficultyButton3.VAlign = (float) (2.0 / ((double) num3 - 1.0));
      difficultyButton3.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      difficultyButton3.Height = StyleDimension.FromPixelsAndPercent(-num2, 1f / num3);
      UIDifficultyButton difficultyButton4 = difficultyButton3;
      UIDifficultyButton difficultyButton5 = new UIDifficultyButton(this._player, Lang.menu[24], Lang.menu[29], (byte) 2, Main.hcColor);
      difficultyButton5.HAlign = 0.0f;
      difficultyButton5.VAlign = 1f;
      difficultyButton5.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      difficultyButton5.Height = StyleDimension.FromPixelsAndPercent(-num2, 1f / num3);
      UIDifficultyButton difficultyButton6 = difficultyButton5;
      UIDifficultyButton difficultyButton7 = new UIDifficultyButton(this._player, Language.GetText("UI.Creative"), Language.GetText("UI.CreativeDescriptionPlayer"), (byte) 3, Main.creativeModeColor);
      difficultyButton7.HAlign = 0.0f;
      difficultyButton7.VAlign = 0.0f;
      difficultyButton7.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      difficultyButton7.Height = StyleDimension.FromPixelsAndPercent(-num2, 1f / num3);
      UIDifficultyButton difficultyButton8 = difficultyButton7;
      UIText uiText1 = new UIText(Lang.menu[26]);
      uiText1.HAlign = 0.0f;
      uiText1.VAlign = 0.5f;
      uiText1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiText1.Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiText1.Top = StyleDimension.FromPixelsAndPercent(15f, 0.0f);
      uiText1.IsWrapped = true;
      UIText uiText2 = uiText1;
      uiText2.PaddingLeft = 20f;
      uiText2.PaddingRight = 20f;
      uiSlicedImage2.Append((UIElement) uiText2);
      element2.Append((UIElement) difficultyButton2);
      element2.Append((UIElement) difficultyButton4);
      element2.Append((UIElement) difficultyButton6);
      element2.Append((UIElement) difficultyButton8);
      this._infoContainer = element1;
      this._difficultyDescriptionText = uiText2;
      difficultyButton2.OnMouseDown += new UIElement.MouseEvent(this.UpdateDifficultyDescription);
      difficultyButton4.OnMouseDown += new UIElement.MouseEvent(this.UpdateDifficultyDescription);
      difficultyButton6.OnMouseDown += new UIElement.MouseEvent(this.UpdateDifficultyDescription);
      difficultyButton8.OnMouseDown += new UIElement.MouseEvent(this.UpdateDifficultyDescription);
      this.UpdateDifficultyDescription((UIMouseEvent) null, (UIElement) null);
      difficultyButton2.SetSnapPoint("Middle", 1);
      difficultyButton4.SetSnapPoint("Middle", 2);
      difficultyButton6.SetSnapPoint("Middle", 3);
      difficultyButton8.SetSnapPoint("Middle", 4);
    }

    private void UpdateDifficultyDescription(UIMouseEvent evt, UIElement listeningElement)
    {
      LocalizedText text = Lang.menu[31];
      switch (this._player.difficulty)
      {
        case 0:
          text = Lang.menu[31];
          break;
        case 1:
          text = Lang.menu[30];
          break;
        case 2:
          text = Lang.menu[29];
          break;
        case 3:
          text = Language.GetText("UI.CreativeDescriptionPlayer");
          break;
      }
      this._difficultyDescriptionText.SetText(text);
    }

    private void MakeHSLMenu(UIElement parentContainer)
    {
      UIElement element1 = new UIElement()
      {
        Width = StyleDimension.FromPixelsAndPercent(220f, 0.0f),
        Height = StyleDimension.FromPixelsAndPercent(158f, 0.0f),
        HAlign = 0.5f,
        VAlign = 0.0f
      };
      element1.SetPadding(0.0f);
      parentContainer.Append(element1);
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Width = StyleDimension.FromPixelsAndPercent(220f, 0.0f);
      uiPanel1.Height = StyleDimension.FromPixelsAndPercent(104f, 0.0f);
      uiPanel1.HAlign = 0.5f;
      uiPanel1.VAlign = 0.0f;
      uiPanel1.Top = StyleDimension.FromPixelsAndPercent(10f, 0.0f);
      UIElement element2 = (UIElement) uiPanel1;
      element2.SetPadding(0.0f);
      element2.PaddingTop = 3f;
      element1.Append(element2);
      element2.Append((UIElement) this.CreateHSLSlider(UICharacterCreation.HSLSliderId.Hue));
      element2.Append((UIElement) this.CreateHSLSlider(UICharacterCreation.HSLSliderId.Saturation));
      element2.Append((UIElement) this.CreateHSLSlider(UICharacterCreation.HSLSliderId.Luminance));
      UIPanel uiPanel2 = new UIPanel();
      uiPanel2.VAlign = 1f;
      uiPanel2.HAlign = 1f;
      uiPanel2.Width = StyleDimension.FromPixelsAndPercent(100f, 0.0f);
      uiPanel2.Height = StyleDimension.FromPixelsAndPercent(32f, 0.0f);
      UIPanel uiPanel3 = uiPanel2;
      UIText uiText1 = new UIText("FFFFFF");
      uiText1.VAlign = 0.5f;
      uiText1.HAlign = 0.5f;
      UIText uiText2 = uiText1;
      uiPanel3.Append((UIElement) uiText2);
      element1.Append((UIElement) uiPanel3);
      UIColoredImageButton coloredImageButton1 = new UIColoredImageButton(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Copy", (AssetRequestMode) 1), true);
      coloredImageButton1.VAlign = 1f;
      coloredImageButton1.HAlign = 0.0f;
      coloredImageButton1.Left = StyleDimension.FromPixelsAndPercent(0.0f, 0.0f);
      UIColoredImageButton coloredImageButton2 = coloredImageButton1;
      coloredImageButton2.OnMouseDown += new UIElement.MouseEvent(this.Click_CopyHex);
      element1.Append((UIElement) coloredImageButton2);
      this._copyHexButton = (UIElement) coloredImageButton2;
      UIColoredImageButton coloredImageButton3 = new UIColoredImageButton(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Paste", (AssetRequestMode) 1), true);
      coloredImageButton3.VAlign = 1f;
      coloredImageButton3.HAlign = 0.0f;
      coloredImageButton3.Left = StyleDimension.FromPixelsAndPercent(40f, 0.0f);
      UIColoredImageButton coloredImageButton4 = coloredImageButton3;
      coloredImageButton4.OnMouseDown += new UIElement.MouseEvent(this.Click_PasteHex);
      element1.Append((UIElement) coloredImageButton4);
      this._pasteHexButton = (UIElement) coloredImageButton4;
      UIColoredImageButton coloredImageButton5 = new UIColoredImageButton(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/Randomize", (AssetRequestMode) 1), true);
      coloredImageButton5.VAlign = 1f;
      coloredImageButton5.HAlign = 0.0f;
      coloredImageButton5.Left = StyleDimension.FromPixelsAndPercent(80f, 0.0f);
      UIColoredImageButton coloredImageButton6 = coloredImageButton5;
      coloredImageButton6.OnMouseDown += new UIElement.MouseEvent(this.Click_RandomizeSingleColor);
      element1.Append((UIElement) coloredImageButton6);
      this._randomColorButton = (UIElement) coloredImageButton6;
      this._hslContainer = element1;
      this._hslHexText = uiText2;
      coloredImageButton2.SetSnapPoint("Low", 0);
      coloredImageButton4.SetSnapPoint("Low", 1);
      coloredImageButton6.SetSnapPoint("Low", 2);
    }

    private UIColoredSlider CreateHSLSlider(UICharacterCreation.HSLSliderId id)
    {
      UIColoredSlider sliderButtonBase = this.CreateHSLSliderButtonBase(id);
      sliderButtonBase.VAlign = 0.0f;
      sliderButtonBase.HAlign = 0.0f;
      sliderButtonBase.Width = StyleDimension.FromPixelsAndPercent(-10f, 1f);
      sliderButtonBase.Top.Set((float) (30 * (int) id), 0.0f);
      sliderButtonBase.OnMouseDown += new UIElement.MouseEvent(this.Click_ColorPicker);
      sliderButtonBase.SetSnapPoint("Middle", (int) id, offset: new Vector2?(new Vector2(0.0f, 20f)));
      return sliderButtonBase;
    }

    private UIColoredSlider CreateHSLSliderButtonBase(
      UICharacterCreation.HSLSliderId id)
    {
      UIColoredSlider uiColoredSlider;
      switch (id)
      {
        case UICharacterCreation.HSLSliderId.Saturation:
          uiColoredSlider = new UIColoredSlider(LocalizedText.Empty, (Func<float>) (() => this.GetHSLSliderPosition(UICharacterCreation.HSLSliderId.Saturation)), (Action<float>) (x => this.UpdateHSLValue(UICharacterCreation.HSLSliderId.Saturation, x)), new Action(this.UpdateHSL_S), (Func<float, Color>) (x => this.GetHSLSliderColorAt(UICharacterCreation.HSLSliderId.Saturation, x)), Color.Transparent);
          break;
        case UICharacterCreation.HSLSliderId.Luminance:
          uiColoredSlider = new UIColoredSlider(LocalizedText.Empty, (Func<float>) (() => this.GetHSLSliderPosition(UICharacterCreation.HSLSliderId.Luminance)), (Action<float>) (x => this.UpdateHSLValue(UICharacterCreation.HSLSliderId.Luminance, x)), new Action(this.UpdateHSL_L), (Func<float, Color>) (x => this.GetHSLSliderColorAt(UICharacterCreation.HSLSliderId.Luminance, x)), Color.Transparent);
          break;
        default:
          uiColoredSlider = new UIColoredSlider(LocalizedText.Empty, (Func<float>) (() => this.GetHSLSliderPosition(UICharacterCreation.HSLSliderId.Hue)), (Action<float>) (x => this.UpdateHSLValue(UICharacterCreation.HSLSliderId.Hue, x)), new Action(this.UpdateHSL_H), (Func<float, Color>) (x => this.GetHSLSliderColorAt(UICharacterCreation.HSLSliderId.Hue, x)), Color.Transparent);
          break;
      }
      return uiColoredSlider;
    }

    private void UpdateHSL_H() => this.UpdateHSLValue(UICharacterCreation.HSLSliderId.Hue, UILinksInitializer.HandleSliderHorizontalInput(this._currentColorHSL.X, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f));

    private void UpdateHSL_S() => this.UpdateHSLValue(UICharacterCreation.HSLSliderId.Saturation, UILinksInitializer.HandleSliderHorizontalInput(this._currentColorHSL.Y, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f));

    private void UpdateHSL_L() => this.UpdateHSLValue(UICharacterCreation.HSLSliderId.Luminance, UILinksInitializer.HandleSliderHorizontalInput(this._currentColorHSL.Z, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f));

    private float GetHSLSliderPosition(UICharacterCreation.HSLSliderId id)
    {
      switch (id)
      {
        case UICharacterCreation.HSLSliderId.Hue:
          return this._currentColorHSL.X;
        case UICharacterCreation.HSLSliderId.Saturation:
          return this._currentColorHSL.Y;
        case UICharacterCreation.HSLSliderId.Luminance:
          return this._currentColorHSL.Z;
        default:
          return 1f;
      }
    }

    private void UpdateHSLValue(UICharacterCreation.HSLSliderId id, float value)
    {
      switch (id)
      {
        case UICharacterCreation.HSLSliderId.Hue:
          this._currentColorHSL.X = value;
          break;
        case UICharacterCreation.HSLSliderId.Saturation:
          this._currentColorHSL.Y = value;
          break;
        case UICharacterCreation.HSLSliderId.Luminance:
          this._currentColorHSL.Z = value;
          break;
      }
      Color rgb = UICharacterCreation.ScaledHslToRgb(this._currentColorHSL.X, this._currentColorHSL.Y, this._currentColorHSL.Z);
      this.ApplyPendingColor(rgb);
      this._colorPickers[(int) this._selectedPicker]?.SetColor(rgb);
      if (this._selectedPicker == UICharacterCreation.CategoryId.HairColor)
        this._hairStylesCategoryButton.SetColor(rgb);
      this.UpdateHexText(rgb);
    }

    private Color GetHSLSliderColorAt(UICharacterCreation.HSLSliderId id, float pointAt)
    {
      switch (id)
      {
        case UICharacterCreation.HSLSliderId.Hue:
          return UICharacterCreation.ScaledHslToRgb(pointAt, 1f, 0.5f);
        case UICharacterCreation.HSLSliderId.Saturation:
          return UICharacterCreation.ScaledHslToRgb(this._currentColorHSL.X, pointAt, this._currentColorHSL.Z);
        case UICharacterCreation.HSLSliderId.Luminance:
          return UICharacterCreation.ScaledHslToRgb(this._currentColorHSL.X, this._currentColorHSL.Y, pointAt);
        default:
          return Color.White;
      }
    }

    private void ApplyPendingColor(Color pendingColor)
    {
      switch (this._selectedPicker)
      {
        case UICharacterCreation.CategoryId.HairColor:
          this._player.hairColor = pendingColor;
          break;
        case UICharacterCreation.CategoryId.Eye:
          this._player.eyeColor = pendingColor;
          break;
        case UICharacterCreation.CategoryId.Skin:
          this._player.skinColor = pendingColor;
          break;
        case UICharacterCreation.CategoryId.Shirt:
          this._player.shirtColor = pendingColor;
          break;
        case UICharacterCreation.CategoryId.Undershirt:
          this._player.underShirtColor = pendingColor;
          break;
        case UICharacterCreation.CategoryId.Pants:
          this._player.pantsColor = pendingColor;
          break;
        case UICharacterCreation.CategoryId.Shoes:
          this._player.shoeColor = pendingColor;
          break;
      }
    }

    private void UpdateHexText(Color pendingColor) => this._hslHexText.SetText(UICharacterCreation.GetHexText(pendingColor));

    private static string GetHexText(Color pendingColor) => "#" + pendingColor.Hex3().ToUpper();

    private void MakeBackAndCreatebuttons(UIElement outerContainer)
    {
      UITextPanel<LocalizedText> uiTextPanel1 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
      uiTextPanel1.Width = StyleDimension.FromPixelsAndPercent(-10f, 0.5f);
      uiTextPanel1.Height = StyleDimension.FromPixels(50f);
      uiTextPanel1.VAlign = 1f;
      uiTextPanel1.HAlign = 0.0f;
      uiTextPanel1.Top = StyleDimension.FromPixels(-45f);
      UITextPanel<LocalizedText> uiTextPanel2 = uiTextPanel1;
      uiTextPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiTextPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiTextPanel2.OnMouseDown += new UIElement.MouseEvent(this.Click_GoBack);
      uiTextPanel2.SetSnapPoint("Back", 0);
      outerContainer.Append((UIElement) uiTextPanel2);
      UITextPanel<LocalizedText> uiTextPanel3 = new UITextPanel<LocalizedText>(Language.GetText("UI.Create"), 0.7f, true);
      uiTextPanel3.Width = StyleDimension.FromPixelsAndPercent(-10f, 0.5f);
      uiTextPanel3.Height = StyleDimension.FromPixels(50f);
      uiTextPanel3.VAlign = 1f;
      uiTextPanel3.HAlign = 1f;
      uiTextPanel3.Top = StyleDimension.FromPixels(-45f);
      UITextPanel<LocalizedText> uiTextPanel4 = uiTextPanel3;
      uiTextPanel4.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiTextPanel4.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiTextPanel4.OnMouseDown += new UIElement.MouseEvent(this.Click_NamingAndCreating);
      uiTextPanel4.SetSnapPoint("Create", 0);
      outerContainer.Append((UIElement) uiTextPanel4);
    }

    private void Click_GoBack(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(11);
      Main.OpenCharacterSelectUI();
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

    private void Click_ColorPicker(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      for (int index = 0; index < this._colorPickers.Length; ++index)
      {
        if (this._colorPickers[index] == evt.Target)
        {
          this.SelectColorPicker((UICharacterCreation.CategoryId) index);
          break;
        }
      }
    }

    private void Click_ClothStyles(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this.UnselectAllCategories();
      this._selectedPicker = UICharacterCreation.CategoryId.Clothing;
      this._middleContainer.Append(this._clothStylesContainer);
      this._clothingStylesCategoryButton.SetSelected(true);
      this.UpdateSelectedGender();
    }

    private void Click_HairStyles(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this.UnselectAllCategories();
      this._selectedPicker = UICharacterCreation.CategoryId.HairStyle;
      this._middleContainer.Append(this._hairstylesContainer);
      this._hairStylesCategoryButton.SetSelected(true);
    }

    private void Click_CharInfo(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this.UnselectAllCategories();
      this._selectedPicker = UICharacterCreation.CategoryId.CharInfo;
      this._middleContainer.Append(this._infoContainer);
      this._charInfoCategoryButton.SetSelected(true);
    }

    private void Click_CharClothStyle(UIMouseEvent evt, UIElement listeningElement)
    {
      this._clothingStylesCategoryButton.SetImage(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/" + (this._player.Male ? "ClothStyleMale" : "ClothStyleFemale"), (AssetRequestMode) 1));
      this.UpdateSelectedGender();
    }

    private void Click_CharGenderMale(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this._player.Male = true;
      this.Click_CharClothStyle(evt, listeningElement);
      this.UpdateSelectedGender();
    }

    private void Click_CharGenderFemale(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this._player.Male = false;
      this.Click_CharClothStyle(evt, listeningElement);
      this.UpdateSelectedGender();
    }

    private void UpdateSelectedGender()
    {
      this._genderMale.SetSelected(this._player.Male);
      this._genderFemale.SetSelected(!this._player.Male);
    }

    private void Click_CopyHex(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      Platform.Get<IClipboard>().Value = this._hslHexText.Text;
    }

    private void Click_PasteHex(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      Vector3 hsl;
      if (!this.GetHexColor(Platform.Get<IClipboard>().Value, out hsl))
        return;
      this.ApplyPendingColor(UICharacterCreation.ScaledHslToRgb(hsl.X, hsl.Y, hsl.Z));
      this._currentColorHSL = hsl;
      this.UpdateHexText(UICharacterCreation.ScaledHslToRgb(hsl.X, hsl.Y, hsl.Z));
      this.UpdateColorPickers();
    }

    private void Click_CopyPlayerTemplate(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      string text = JsonConvert.SerializeObject((object) new Dictionary<string, object>()
      {
        {
          "version",
          (object) 1
        },
        {
          "hairStyle",
          (object) this._player.hair
        },
        {
          "clothingStyle",
          (object) this._player.skinVariant
        },
        {
          "hairColor",
          (object) UICharacterCreation.GetHexText(this._player.hairColor)
        },
        {
          "eyeColor",
          (object) UICharacterCreation.GetHexText(this._player.eyeColor)
        },
        {
          "skinColor",
          (object) UICharacterCreation.GetHexText(this._player.skinColor)
        },
        {
          "shirtColor",
          (object) UICharacterCreation.GetHexText(this._player.shirtColor)
        },
        {
          "underShirtColor",
          (object) UICharacterCreation.GetHexText(this._player.underShirtColor)
        },
        {
          "pantsColor",
          (object) UICharacterCreation.GetHexText(this._player.pantsColor)
        },
        {
          "shoeColor",
          (object) UICharacterCreation.GetHexText(this._player.shoeColor)
        }
      }, new JsonSerializerSettings()
      {
        TypeNameHandling = (TypeNameHandling) 4,
        MetadataPropertyHandling = (MetadataPropertyHandling) 1,
        Formatting = (Formatting) 1
      });
      PlayerInput.PrettyPrintProfiles(ref text);
      Platform.Get<IClipboard>().Value = text;
    }

    private void Click_PastePlayerTemplate(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      try
      {
        string str1 = Platform.Get<IClipboard>().Value;
        int startIndex = str1.IndexOf("{");
        if (startIndex == -1)
          return;
        string str2 = str1.Substring(startIndex);
        int num1 = str2.LastIndexOf("}");
        if (num1 == -1)
          return;
        Dictionary<string, object> dictionary1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(str2.Substring(0, num1 + 1));
        if (dictionary1 == null)
          return;
        Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
        foreach (KeyValuePair<string, object> keyValuePair in dictionary1)
          dictionary2[keyValuePair.Key.ToLower()] = keyValuePair.Value;
        object obj;
        if (dictionary2.TryGetValue("version", out obj))
        {
          long num2 = (long) obj;
        }
        if (dictionary2.TryGetValue("hairstyle", out obj))
        {
          int num3 = (int) (long) obj;
          if (Main.Hairstyles.AvailableHairstyles.Contains(num3))
            this._player.hair = num3;
        }
        if (dictionary2.TryGetValue("clothingstyle", out obj))
        {
          int num4 = (int) (long) obj;
          if (((IEnumerable<int>) this._validClothStyles).Contains<int>(num4))
            this._player.skinVariant = num4;
        }
        Vector3 hsl;
        if (dictionary2.TryGetValue("haircolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.hairColor = UICharacterCreation.ScaledHslToRgb(hsl);
        if (dictionary2.TryGetValue("eyecolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.eyeColor = UICharacterCreation.ScaledHslToRgb(hsl);
        if (dictionary2.TryGetValue("skincolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.skinColor = UICharacterCreation.ScaledHslToRgb(hsl);
        if (dictionary2.TryGetValue("shirtcolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.shirtColor = UICharacterCreation.ScaledHslToRgb(hsl);
        if (dictionary2.TryGetValue("undershirtcolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.underShirtColor = UICharacterCreation.ScaledHslToRgb(hsl);
        if (dictionary2.TryGetValue("pantscolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.pantsColor = UICharacterCreation.ScaledHslToRgb(hsl);
        if (dictionary2.TryGetValue("shoecolor", out obj) && this.GetHexColor((string) obj, out hsl))
          this._player.shoeColor = UICharacterCreation.ScaledHslToRgb(hsl);
        this.Click_CharClothStyle((UIMouseEvent) null, (UIElement) null);
        this.UpdateColorPickers();
      }
      catch
      {
      }
    }

    private void Click_RandomizePlayer(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      Player player = this._player;
      int index = Main.rand.Next(Main.Hairstyles.AvailableHairstyles.Count);
      player.hair = Main.Hairstyles.AvailableHairstyles[index];
      while ((int) player.eyeColor.R + (int) player.eyeColor.G + (int) player.eyeColor.B > 300)
        player.eyeColor = UICharacterCreation.ScaledHslToRgb(UICharacterCreation.GetRandomColorVector());
      float num = (float) Main.rand.Next(60, 120) * 0.01f;
      if ((double) num > 1.0)
        num = 1f;
      player.skinColor.R = (byte) ((double) Main.rand.Next(240, (int) byte.MaxValue) * (double) num);
      player.skinColor.G = (byte) ((double) Main.rand.Next(110, 140) * (double) num);
      player.skinColor.B = (byte) ((double) Main.rand.Next(75, 110) * (double) num);
      player.hairColor = UICharacterCreation.ScaledHslToRgb(UICharacterCreation.GetRandomColorVector());
      player.shirtColor = UICharacterCreation.ScaledHslToRgb(UICharacterCreation.GetRandomColorVector());
      player.underShirtColor = UICharacterCreation.ScaledHslToRgb(UICharacterCreation.GetRandomColorVector());
      player.pantsColor = UICharacterCreation.ScaledHslToRgb(UICharacterCreation.GetRandomColorVector());
      player.shoeColor = UICharacterCreation.ScaledHslToRgb(UICharacterCreation.GetRandomColorVector());
      player.skinVariant = this._validClothStyles[Main.rand.Next(this._validClothStyles.Length)];
      switch (player.hair + 1)
      {
        case 5:
        case 6:
        case 7:
        case 10:
        case 12:
        case 19:
        case 22:
        case 23:
        case 26:
        case 27:
        case 30:
        case 33:
          player.Male = false;
          break;
        default:
          player.Male = true;
          break;
      }
      this.Click_CharClothStyle((UIMouseEvent) null, (UIElement) null);
      this.UpdateSelectedGender();
      this.UpdateColorPickers();
    }

    private void Click_Naming(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(10);
      this._player.name = "";
      Main.clrInput();
      UIVirtualKeyboard uiVirtualKeyboard = new UIVirtualKeyboard(Lang.menu[45].Value, "", new UIVirtualKeyboard.KeyboardSubmitEvent(this.OnFinishedNaming), new Action(this.OnCancledNaming), allowEmpty: true);
      uiVirtualKeyboard.SetMaxInputLength(20);
      Main.MenuUI.SetState((UIState) uiVirtualKeyboard);
    }

    private void Click_NamingAndCreating(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(10);
      if (string.IsNullOrEmpty(this._player.name))
      {
        this._player.name = "";
        Main.clrInput();
        UIVirtualKeyboard uiVirtualKeyboard = new UIVirtualKeyboard(Lang.menu[45].Value, "", new UIVirtualKeyboard.KeyboardSubmitEvent(this.OnFinishedNamingAndCreating), new Action(this.OnCancledNaming));
        uiVirtualKeyboard.SetMaxInputLength(20);
        Main.MenuUI.SetState((UIState) uiVirtualKeyboard);
      }
      else
        this.FinishCreatingCharacter();
    }

    private void OnFinishedNaming(string name)
    {
      this._player.name = name.Trim();
      Main.MenuUI.SetState((UIState) this);
      this._charName.SetContents(this._player.name);
    }

    private void OnCancledNaming() => Main.MenuUI.SetState((UIState) this);

    private void OnFinishedNamingAndCreating(string name)
    {
      this._player.name = name.Trim();
      Main.MenuUI.SetState((UIState) this);
      this._charName.SetContents(this._player.name);
      this.FinishCreatingCharacter();
    }

    private void FinishCreatingCharacter()
    {
      this.SetupPlayerStatsAndInventoryBasedOnDifficulty();
      PlayerFileData.CreateAndSave(this._player);
      Main.LoadPlayers();
      Main.menuMode = 1;
    }

    private void SetupPlayerStatsAndInventoryBasedOnDifficulty()
    {
      int index1 = 0;
      int num1;
      if (this._player.difficulty == (byte) 3)
      {
        this._player.statLife = this._player.statLifeMax = 100;
        this._player.statMana = this._player.statManaMax = 20;
        this._player.inventory[index1].SetDefaults(6);
        Item[] inventory1 = this._player.inventory;
        int index2 = index1;
        int index3 = index2 + 1;
        inventory1[index2].Prefix(-1);
        this._player.inventory[index3].SetDefaults(1);
        Item[] inventory2 = this._player.inventory;
        int index4 = index3;
        int index5 = index4 + 1;
        inventory2[index4].Prefix(-1);
        this._player.inventory[index5].SetDefaults(10);
        Item[] inventory3 = this._player.inventory;
        int index6 = index5;
        int index7 = index6 + 1;
        inventory3[index6].Prefix(-1);
        this._player.inventory[index7].SetDefaults(7);
        Item[] inventory4 = this._player.inventory;
        int index8 = index7;
        int index9 = index8 + 1;
        inventory4[index8].Prefix(-1);
        this._player.inventory[index9].SetDefaults(4281);
        Item[] inventory5 = this._player.inventory;
        int index10 = index9;
        int index11 = index10 + 1;
        inventory5[index10].Prefix(-1);
        this._player.inventory[index11].SetDefaults(8);
        Item[] inventory6 = this._player.inventory;
        int index12 = index11;
        int index13 = index12 + 1;
        inventory6[index12].stack = 100;
        this._player.inventory[index13].SetDefaults(965);
        Item[] inventory7 = this._player.inventory;
        int index14 = index13;
        int num2 = index14 + 1;
        inventory7[index14].stack = 100;
        Item[] inventory8 = this._player.inventory;
        int index15 = num2;
        num1 = index15 + 1;
        inventory8[index15].SetDefaults(50);
        this._player.armor[3].SetDefaults(4978);
        this._player.armor[3].Prefix(-1);
        this._player.AddBuff(216, 3600);
      }
      else
      {
        this._player.inventory[index1].SetDefaults(3507);
        Item[] inventory9 = this._player.inventory;
        int index16 = index1;
        int index17 = index16 + 1;
        inventory9[index16].Prefix(-1);
        this._player.inventory[index17].SetDefaults(3509);
        Item[] inventory10 = this._player.inventory;
        int index18 = index17;
        int index19 = index18 + 1;
        inventory10[index18].Prefix(-1);
        this._player.inventory[index19].SetDefaults(3506);
        Item[] inventory11 = this._player.inventory;
        int index20 = index19;
        num1 = index20 + 1;
        inventory11[index20].Prefix(-1);
      }
      if (Main.runningCollectorsEdition)
      {
        Item[] inventory = this._player.inventory;
        int index21 = num1;
        int num3 = index21 + 1;
        inventory[index21].SetDefaults(603);
      }
      this._player.savedPerPlayerFieldsThatArentInThePlayerClass = new Player.SavedPlayerDataWithAnnoyingRules();
      CreativePowerManager.Instance.ResetDataForNewPlayer(this._player);
    }

    private bool GetHexColor(string hexString, out Vector3 hsl)
    {
      if (hexString.StartsWith("#"))
        hexString = hexString.Substring(1);
      uint result;
      if (hexString.Length <= 6 && uint.TryParse(hexString, NumberStyles.HexNumber, (IFormatProvider) CultureInfo.CurrentCulture, out result))
      {
        uint num1 = result & (uint) byte.MaxValue;
        uint num2 = result >> 8 & (uint) byte.MaxValue;
        uint num3 = result >> 16 & (uint) byte.MaxValue;
        hsl = UICharacterCreation.RgbToScaledHsl(new Color((int) num3, (int) num2, (int) num1));
        return true;
      }
      hsl = Vector3.Zero;
      return false;
    }

    private void Click_RandomizeSingleColor(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      Vector3 randomColorVector = UICharacterCreation.GetRandomColorVector();
      this.ApplyPendingColor(UICharacterCreation.ScaledHslToRgb(randomColorVector.X, randomColorVector.Y, randomColorVector.Z));
      this._currentColorHSL = randomColorVector;
      this.UpdateHexText(UICharacterCreation.ScaledHslToRgb(randomColorVector.X, randomColorVector.Y, randomColorVector.Z));
      this.UpdateColorPickers();
    }

    private static Vector3 GetRandomColorVector() => new Vector3(Main.rand.NextFloat(), Main.rand.NextFloat(), Main.rand.NextFloat());

    private void UnselectAllCategories()
    {
      foreach (UIColoredImageButton colorPicker in this._colorPickers)
        colorPicker?.SetSelected(false);
      this._clothingStylesCategoryButton.SetSelected(false);
      this._hairStylesCategoryButton.SetSelected(false);
      this._charInfoCategoryButton.SetSelected(false);
      this._hslContainer.Remove();
      this._hairstylesContainer.Remove();
      this._clothStylesContainer.Remove();
      this._infoContainer.Remove();
    }

    private void SelectColorPicker(UICharacterCreation.CategoryId selection)
    {
      this._selectedPicker = selection;
      switch (selection)
      {
        case UICharacterCreation.CategoryId.CharInfo:
          this.Click_CharInfo((UIMouseEvent) null, (UIElement) null);
          break;
        case UICharacterCreation.CategoryId.Clothing:
          this.Click_ClothStyles((UIMouseEvent) null, (UIElement) null);
          break;
        case UICharacterCreation.CategoryId.HairStyle:
          this.Click_HairStyles((UIMouseEvent) null, (UIElement) null);
          break;
        default:
          this.UnselectAllCategories();
          this._middleContainer.Append(this._hslContainer);
          for (int index = 0; index < this._colorPickers.Length; ++index)
          {
            if (this._colorPickers[index] != null)
              this._colorPickers[index].SetSelected((UICharacterCreation.CategoryId) index == selection);
          }
          Vector3 vector3 = Vector3.One;
          switch (this._selectedPicker)
          {
            case UICharacterCreation.CategoryId.HairColor:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.hairColor);
              break;
            case UICharacterCreation.CategoryId.Eye:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.eyeColor);
              break;
            case UICharacterCreation.CategoryId.Skin:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.skinColor);
              break;
            case UICharacterCreation.CategoryId.Shirt:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.shirtColor);
              break;
            case UICharacterCreation.CategoryId.Undershirt:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.underShirtColor);
              break;
            case UICharacterCreation.CategoryId.Pants:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.pantsColor);
              break;
            case UICharacterCreation.CategoryId.Shoes:
              vector3 = UICharacterCreation.RgbToScaledHsl(this._player.shoeColor);
              break;
          }
          this._currentColorHSL = vector3;
          this.UpdateHexText(UICharacterCreation.ScaledHslToRgb(vector3.X, vector3.Y, vector3.Z));
          break;
      }
    }

    private void UpdateColorPickers()
    {
      int selectedPicker = (int) this._selectedPicker;
      this._colorPickers[3].SetColor(this._player.hairColor);
      this._hairStylesCategoryButton.SetColor(this._player.hairColor);
      this._colorPickers[4].SetColor(this._player.eyeColor);
      this._colorPickers[5].SetColor(this._player.skinColor);
      this._colorPickers[6].SetColor(this._player.shirtColor);
      this._colorPickers[7].SetColor(this._player.underShirtColor);
      this._colorPickers[8].SetColor(this._player.pantsColor);
      this._colorPickers[9].SetColor(this._player.shoeColor);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      base.Draw(spriteBatch);
      string text = (string) null;
      if (this._copyHexButton.IsMouseHovering)
        text = Language.GetTextValue("UI.CopyColorToClipboard");
      if (this._pasteHexButton.IsMouseHovering)
        text = Language.GetTextValue("UI.PasteColorFromClipboard");
      if (this._randomColorButton.IsMouseHovering)
        text = Language.GetTextValue("UI.RandomizeColor");
      if (this._copyTemplateButton.IsMouseHovering)
        text = Language.GetTextValue("UI.CopyPlayerToClipboard");
      if (this._pasteTemplateButton.IsMouseHovering)
        text = Language.GetTextValue("UI.PastePlayerFromClipboard");
      if (this._randomizePlayerButton.IsMouseHovering)
        text = Language.GetTextValue("UI.RandomizePlayer");
      if (text != null)
      {
        float x = FontAssets.MouseText.Value.MeasureString(text).X;
        Vector2 vector2 = new Vector2((float) Main.mouseX, (float) Main.mouseY) + new Vector2(16f);
        if ((double) vector2.Y > (double) (Main.screenHeight - 30))
          vector2.Y = (float) (Main.screenHeight - 30);
        if ((double) vector2.X > (double) Main.screenWidth - (double) x)
          vector2.X = (float) (Main.screenWidth - 460);
        Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, text, vector2.X, vector2.Y, new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), Color.Black, Vector2.Zero);
      }
      this.SetupGamepadPoints(spriteBatch);
    }

    private void SetupGamepadPoints(SpriteBatch spriteBatch)
    {
      UILinkPointNavigator.Shortcuts.BackButtonCommand = 1;
      int num1 = 3000;
      int num2 = num1 + 20;
      int num3 = num1;
      List<SnapPoint> snapPoints = this.GetSnapPoints();
      SnapPoint snapPoint1 = snapPoints.First<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Back"));
      SnapPoint snapPoint2 = snapPoints.First<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Create"));
      UILinkPoint point1 = UILinkPointNavigator.Points[num3];
      point1.Unlink();
      UILinkPointNavigator.SetPosition(num3, snapPoint1.Position);
      int num4 = num3 + 1;
      UILinkPoint point2 = UILinkPointNavigator.Points[num4];
      point2.Unlink();
      UILinkPointNavigator.SetPosition(num4, snapPoint2.Position);
      int num5 = num4 + 1;
      point1.Right = point2.ID;
      point2.Left = point1.ID;
      this._foundPoints.Clear();
      this._foundPoints.Add(point1.ID);
      this._foundPoints.Add(point2.ID);
      List<SnapPoint> list1 = snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Top")).ToList<SnapPoint>();
      list1.Sort(new Comparison<SnapPoint>(this.SortPoints));
      for (int index = 0; index < list1.Count; ++index)
      {
        UILinkPoint point3 = UILinkPointNavigator.Points[num5];
        point3.Unlink();
        UILinkPointNavigator.SetPosition(num5, list1[index].Position);
        point3.Left = num5 - 1;
        point3.Right = num5 + 1;
        point3.Down = num2;
        if (index == 0)
          point3.Left = -3;
        if (index == list1.Count - 1)
          point3.Right = -4;
        if (this._selectedPicker == UICharacterCreation.CategoryId.HairStyle || this._selectedPicker == UICharacterCreation.CategoryId.Clothing)
          point3.Down = num2 + index;
        this._foundPoints.Add(num5);
        ++num5;
      }
      List<SnapPoint> list2 = snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Middle")).ToList<SnapPoint>();
      list2.Sort(new Comparison<SnapPoint>(this.SortPoints));
      int ptid1 = num2;
      switch (this._selectedPicker)
      {
        case UICharacterCreation.CategoryId.CharInfo:
          for (int index = 0; index < list2.Count; ++index)
          {
            UILinkPoint andSet = this.GetAndSet(ptid1, list2[index]);
            andSet.Up = andSet.ID - 1;
            andSet.Down = andSet.ID + 1;
            if (index == 0)
              andSet.Up = num1 + 2;
            if (index == list2.Count - 1)
            {
              andSet.Down = point1.ID;
              point1.Up = andSet.ID;
              point2.Up = andSet.ID;
            }
            this._foundPoints.Add(ptid1);
            ++ptid1;
          }
          break;
        case UICharacterCreation.CategoryId.Clothing:
          List<SnapPoint> list3 = snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Low")).ToList<SnapPoint>();
          list3.Sort(new Comparison<SnapPoint>(this.SortPoints));
          int num6 = -2;
          int num7 = -2;
          int ptid2 = num2 + 20;
          for (int index = 0; index < list3.Count; ++index)
          {
            UILinkPoint andSet = this.GetAndSet(ptid2, list3[index]);
            andSet.Up = num2 + index + 2;
            andSet.Down = point1.ID;
            if (index >= 3)
            {
              ++andSet.Up;
              andSet.Down = point2.ID;
            }
            andSet.Left = andSet.ID - 1;
            andSet.Right = andSet.ID + 1;
            if (index == 0)
            {
              num6 = andSet.ID;
              andSet.Left = andSet.ID + 4;
              point1.Up = andSet.ID;
            }
            if (index == list3.Count - 1)
            {
              num7 = andSet.ID;
              andSet.Right = andSet.ID - 4;
              point2.Up = andSet.ID;
            }
            this._foundPoints.Add(ptid2);
            ++ptid2;
          }
          int ptid3 = num2;
          for (int index = 0; index < list2.Count; ++index)
          {
            UILinkPoint andSet = this.GetAndSet(ptid3, list2[index]);
            andSet.Up = num1 + 2 + index;
            andSet.Left = andSet.ID - 1;
            andSet.Right = andSet.ID + 1;
            if (index == 0)
              andSet.Left = andSet.ID + 9;
            if (index == list2.Count - 1)
              andSet.Right = andSet.ID - 9;
            andSet.Down = num6;
            if (index >= 5)
              andSet.Down = num7;
            this._foundPoints.Add(ptid3);
            ++ptid3;
          }
          break;
        case UICharacterCreation.CategoryId.HairStyle:
          if (list2.Count != 0)
          {
            this._helper.CullPointsOutOfElementArea(spriteBatch, list2, this._hairstylesContainer);
            SnapPoint snapPoint3 = list2[list2.Count - 1];
            int num8 = snapPoint3.Id / 10;
            int num9 = snapPoint3.Id % 10;
            int count = Main.Hairstyles.AvailableHairstyles.Count;
            for (int index = 0; index < list2.Count; ++index)
            {
              SnapPoint snap = list2[index];
              UILinkPoint andSet = this.GetAndSet(ptid1, snap);
              andSet.Left = andSet.ID - 1;
              if (snap.Id == 0)
                andSet.Left = -3;
              andSet.Right = andSet.ID + 1;
              if (snap.Id == count - 1)
                andSet.Right = -4;
              andSet.Up = andSet.ID - 10;
              if (index < 10)
                andSet.Up = num1 + 2 + index;
              andSet.Down = andSet.ID + 10;
              if (snap.Id + 10 > snapPoint3.Id)
                andSet.Down = snap.Id % 10 >= 5 ? point2.ID : point1.ID;
              if (index == list2.Count - 1)
              {
                point1.Up = andSet.ID;
                point2.Up = andSet.ID;
              }
              this._foundPoints.Add(ptid1);
              ++ptid1;
            }
            break;
          }
          break;
        default:
          List<SnapPoint> list4 = snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Low")).ToList<SnapPoint>();
          list4.Sort(new Comparison<SnapPoint>(this.SortPoints));
          int ptid4 = num2 + 20;
          for (int index = 0; index < list4.Count; ++index)
          {
            UILinkPoint andSet = this.GetAndSet(ptid4, list4[index]);
            andSet.Up = num2 + 2;
            andSet.Down = point1.ID;
            andSet.Left = andSet.ID - 1;
            andSet.Right = andSet.ID + 1;
            if (index == 0)
            {
              andSet.Left = andSet.ID + 2;
              point1.Up = andSet.ID;
            }
            if (index == list4.Count - 1)
            {
              andSet.Right = andSet.ID - 2;
              point2.Up = andSet.ID;
            }
            this._foundPoints.Add(ptid4);
            ++ptid4;
          }
          int ptid5 = num2;
          for (int index = 0; index < list2.Count; ++index)
          {
            UILinkPoint andSet = this.GetAndSet(ptid5, list2[index]);
            andSet.Up = andSet.ID - 1;
            andSet.Down = andSet.ID + 1;
            if (index == 0)
              andSet.Up = num1 + 2 + 5;
            if (index == list2.Count - 1)
              andSet.Down = num2 + 20 + 2;
            this._foundPoints.Add(ptid5);
            ++ptid5;
          }
          break;
      }
      if (!PlayerInput.UsingGamepadUI || this._foundPoints.Contains(UILinkPointNavigator.CurrentPoint))
        return;
      this.MoveToVisuallyClosestPoint();
    }

    private void MoveToVisuallyClosestPoint()
    {
      Dictionary<int, UILinkPoint> points = UILinkPointNavigator.Points;
      Vector2 mouseScreen = Main.MouseScreen;
      UILinkPoint uiLinkPoint1 = (UILinkPoint) null;
      foreach (int foundPoint in this._foundPoints)
      {
        UILinkPoint uiLinkPoint2;
        if (!points.TryGetValue(foundPoint, out uiLinkPoint2))
          return;
        if (uiLinkPoint1 == null || (double) Vector2.Distance(mouseScreen, uiLinkPoint1.Position) > (double) Vector2.Distance(mouseScreen, uiLinkPoint2.Position))
          uiLinkPoint1 = uiLinkPoint2;
      }
      if (uiLinkPoint1 == null)
        return;
      UILinkPointNavigator.ChangePoint(uiLinkPoint1.ID);
    }

    public void TryMovingCategory(int direction)
    {
      int num = (int) (this._selectedPicker + direction) % 10;
      if (num < 0)
        num += 10;
      this.SelectColorPicker((UICharacterCreation.CategoryId) num);
    }

    private UILinkPoint GetAndSet(int ptid, SnapPoint snap)
    {
      UILinkPoint point = UILinkPointNavigator.Points[ptid];
      point.Unlink();
      UILinkPointNavigator.SetPosition(point.ID, snap.Position);
      return point;
    }

    private bool PointWithName(SnapPoint a, string comp) => a.Name == comp;

    private int SortPoints(SnapPoint a, SnapPoint b) => a.Id.CompareTo(b.Id);

    private static Color ScaledHslToRgb(Vector3 hsl) => UICharacterCreation.ScaledHslToRgb(hsl.X, hsl.Y, hsl.Z);

    private static Color ScaledHslToRgb(float hue, float saturation, float luminosity) => Main.hslToRgb(hue, saturation, (float) ((double) luminosity * 0.850000023841858 + 0.150000005960464));

    private static Vector3 RgbToScaledHsl(Color color)
    {
      Vector3 hsl = Main.rgbToHsl(color);
      hsl.Z = (float) (((double) hsl.Z - 0.150000005960464) / 0.850000023841858);
      return Vector3.Clamp(hsl, Vector3.Zero, Vector3.One);
    }

    private enum CategoryId
    {
      CharInfo,
      Clothing,
      HairStyle,
      HairColor,
      Eye,
      Skin,
      Shirt,
      Undershirt,
      Pants,
      Shoes,
      Count,
    }

    private enum HSLSliderId
    {
      Hue,
      Saturation,
      Luminance,
    }
  }
}
