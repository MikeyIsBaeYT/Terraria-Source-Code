// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativePowersHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.Creative
{
  public class CreativePowersHelper
  {
    public const int TextureIconColumns = 21;
    public const int TextureIconRows = 1;
    public static Color CommonSelectedColor = new Color(152, 175, 235);

    private static Asset<Texture2D> GetPowerIconAsset(string path) => Main.Assets.Request<Texture2D>(path, (AssetRequestMode) 1);

    public static UIImageFramed GetIconImage(Point iconLocation)
    {
      Asset<Texture2D> powerIconAsset = CreativePowersHelper.GetPowerIconAsset("Images/UI/Creative/Infinite_Powers");
      UIImageFramed uiImageFramed = new UIImageFramed(powerIconAsset, powerIconAsset.Frame(21, frameX: iconLocation.X, frameY: iconLocation.Y));
      uiImageFramed.MarginLeft = 4f;
      uiImageFramed.MarginTop = 4f;
      uiImageFramed.VAlign = 0.5f;
      uiImageFramed.HAlign = 1f;
      uiImageFramed.IgnoresMouseInteraction = true;
      return uiImageFramed;
    }

    public static GroupOptionButton<bool> CreateToggleButton(
      CreativePowerUIElementRequestInfo info)
    {
      GroupOptionButton<bool> groupOptionButton = new GroupOptionButton<bool>(true, (LocalizedText) null, (LocalizedText) null, Color.White, (string) null, 0.8f);
      groupOptionButton.Width = new StyleDimension((float) info.PreferredButtonWidth, 0.0f);
      groupOptionButton.Height = new StyleDimension((float) info.PreferredButtonHeight, 0.0f);
      groupOptionButton.ShowHighlightWhenSelected = false;
      groupOptionButton.SetCurrentOption(false);
      groupOptionButton.SetColorsBasedOnSelectionState(new Color(152, 175, 235), Colors.InventoryDefaultColor, 1f, 0.7f);
      groupOptionButton.SetColorsBasedOnSelectionState(Main.OurFavoriteColor, Colors.InventoryDefaultColor, 1f, 0.7f);
      return groupOptionButton;
    }

    public static GroupOptionButton<bool> CreateSimpleButton(
      CreativePowerUIElementRequestInfo info)
    {
      GroupOptionButton<bool> groupOptionButton = new GroupOptionButton<bool>(true, (LocalizedText) null, (LocalizedText) null, Color.White, (string) null, 0.8f);
      groupOptionButton.Width = new StyleDimension((float) info.PreferredButtonWidth, 0.0f);
      groupOptionButton.Height = new StyleDimension((float) info.PreferredButtonHeight, 0.0f);
      groupOptionButton.ShowHighlightWhenSelected = false;
      groupOptionButton.SetCurrentOption(false);
      groupOptionButton.SetColorsBasedOnSelectionState(new Color(152, 175, 235), Colors.InventoryDefaultColor, 1f, 0.7f);
      return groupOptionButton;
    }

    public static GroupOptionButton<T> CreateCategoryButton<T>(
      CreativePowerUIElementRequestInfo info,
      T option,
      T currentOption)
      where T : IConvertible, IEquatable<T>
    {
      GroupOptionButton<T> groupOptionButton = new GroupOptionButton<T>(option, (LocalizedText) null, (LocalizedText) null, Color.White, (string) null, 0.8f);
      groupOptionButton.Width = new StyleDimension((float) info.PreferredButtonWidth, 0.0f);
      groupOptionButton.Height = new StyleDimension((float) info.PreferredButtonHeight, 0.0f);
      groupOptionButton.ShowHighlightWhenSelected = false;
      groupOptionButton.SetCurrentOption(currentOption);
      groupOptionButton.SetColorsBasedOnSelectionState(new Color(152, 175, 235), Colors.InventoryDefaultColor, 1f, 0.7f);
      return groupOptionButton;
    }

    public static void AddPermissionTextIfNeeded(ICreativePower power, ref string originalText)
    {
      if (CreativePowersHelper.IsAvailableForPlayer(power, Main.myPlayer))
        return;
      string textValue = Language.GetTextValue("CreativePowers.CantUsePowerBecauseOfNoPermissionFromServer");
      originalText = originalText + "\n" + textValue;
    }

    public static void AddDescriptionIfNeeded(ref string originalText, string descriptionKey)
    {
      if (!CreativePowerSettings.ShouldPowersBeElaborated)
        return;
      string textValue = Language.GetTextValue(descriptionKey);
      originalText = originalText + "\n" + textValue;
    }

    public static void AddUnlockTextIfNeeded(
      ref string originalText,
      bool needed,
      string descriptionKey)
    {
      if (needed)
        return;
      string textValue = Language.GetTextValue(descriptionKey);
      originalText = originalText + "\n" + textValue;
    }

    public static UIVerticalSlider CreateSlider(
      Func<float> GetSliderValueMethod,
      Action<float> SetValueKeyboardMethod,
      Action SetValueGamepadMethod)
    {
      UIVerticalSlider uiVerticalSlider = new UIVerticalSlider(GetSliderValueMethod, SetValueKeyboardMethod, SetValueGamepadMethod, Color.Red);
      uiVerticalSlider.Width = new StyleDimension(12f, 0.0f);
      uiVerticalSlider.Height = new StyleDimension(-10f, 1f);
      uiVerticalSlider.Left = new StyleDimension(6f, 0.0f);
      uiVerticalSlider.HAlign = 0.0f;
      uiVerticalSlider.VAlign = 0.5f;
      uiVerticalSlider.EmptyColor = Color.OrangeRed;
      uiVerticalSlider.FilledColor = Color.CornflowerBlue;
      return uiVerticalSlider;
    }

    public static void UpdateUseMouseInterface(UIElement affectedElement)
    {
      if (!affectedElement.IsMouseHovering)
        return;
      Main.LocalPlayer.mouseInterface = true;
    }

    public static void UpdateUnlockStateByPower(
      ICreativePower power,
      UIElement button,
      Color colorWhenSelected)
    {
      IGroupOptionButton asButton = button as IGroupOptionButton;
      if (asButton == null)
        return;
      button.OnUpdate += (UIElement.ElementEvent) (element => CreativePowersHelper.UpdateUnlockStateByPowerInternal(power, colorWhenSelected, asButton));
    }

    public static bool IsAvailableForPlayer(ICreativePower power, int playerIndex)
    {
      switch (power.CurrentPermissionLevel)
      {
        case PowerPermissionLevel.CanBeChangedByHostAlone:
          return Main.netMode == 0 || Main.countsAsHostForGameplay[playerIndex];
        case PowerPermissionLevel.CanBeChangedByEveryone:
          return true;
        default:
          return false;
      }
    }

    private static void UpdateUnlockStateByPowerInternal(
      ICreativePower power,
      Color colorWhenSelected,
      IGroupOptionButton asButton)
    {
      bool isUnlocked = power.GetIsUnlocked();
      bool flag = !CreativePowersHelper.IsAvailableForPlayer(power, Main.myPlayer);
      asButton.SetBorderColor(flag ? Color.DimGray : Color.White);
      if (flag)
        asButton.SetColorsBasedOnSelectionState(new Color(60, 60, 60), new Color(60, 60, 60), 0.7f, 0.7f);
      else if (isUnlocked)
        asButton.SetColorsBasedOnSelectionState(colorWhenSelected, Colors.InventoryDefaultColor, 1f, 0.7f);
      else
        asButton.SetColorsBasedOnSelectionState(Color.Crimson, Color.Red, 0.7f, 0.7f);
    }

    public class CreativePowerIconLocations
    {
      public static readonly Point Unassigned = new Point(0, 0);
      public static readonly Point Deprecated = new Point(0, 0);
      public static readonly Point ItemDuplication = new Point(0, 0);
      public static readonly Point ItemResearch = new Point(1, 0);
      public static readonly Point TimeCategory = new Point(2, 0);
      public static readonly Point WeatherCategory = new Point(3, 0);
      public static readonly Point EnemyStrengthSlider = new Point(4, 0);
      public static readonly Point GameEvents = new Point(5, 0);
      public static readonly Point Godmode = new Point(6, 0);
      public static readonly Point BlockPlacementRange = new Point(7, 0);
      public static readonly Point StopBiomeSpread = new Point(8, 0);
      public static readonly Point EnemySpawnRate = new Point(9, 0);
      public static readonly Point FreezeTime = new Point(10, 0);
      public static readonly Point TimeDawn = new Point(11, 0);
      public static readonly Point TimeNoon = new Point(12, 0);
      public static readonly Point TimeDusk = new Point(13, 0);
      public static readonly Point TimeMidnight = new Point(14, 0);
      public static readonly Point WindDirection = new Point(15, 0);
      public static readonly Point WindFreeze = new Point(16, 0);
      public static readonly Point RainStrength = new Point(17, 0);
      public static readonly Point RainFreeze = new Point(18, 0);
      public static readonly Point ModifyTime = new Point(19, 0);
      public static readonly Point PersonalCategory = new Point(20, 0);
    }
  }
}
