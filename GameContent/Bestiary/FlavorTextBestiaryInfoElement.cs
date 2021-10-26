// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class FlavorTextBestiaryInfoElement : IBestiaryInfoElement
  {
    private string _key;

    public FlavorTextBestiaryInfoElement(string languageKey) => this._key = languageKey;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info)
    {
      if (info.UnlockState < BestiaryEntryUnlockState.CanShowStats_2)
        return (UIElement) null;
      UIPanel uiPanel = new UIPanel(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Panel", (AssetRequestMode) 1), (Asset<Texture2D>) null, customBarSize: 7);
      uiPanel.Width = new StyleDimension(-11f, 1f);
      uiPanel.Height = new StyleDimension(109f, 0.0f);
      uiPanel.BackgroundColor = new Color(43, 56, 101);
      uiPanel.BorderColor = Color.Transparent;
      uiPanel.Left = new StyleDimension(3f, 0.0f);
      uiPanel.PaddingLeft = 4f;
      uiPanel.PaddingRight = 4f;
      UIText uiText = new UIText(Language.GetText(this._key), 0.8f);
      uiText.HAlign = 0.0f;
      uiText.VAlign = 0.0f;
      uiText.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiText.Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiText.IsWrapped = true;
      UIText text = uiText;
      FlavorTextBestiaryInfoElement.AddDynamicResize((UIElement) uiPanel, text);
      uiPanel.Append((UIElement) text);
      return (UIElement) uiPanel;
    }

    private static void AddDynamicResize(UIElement container, UIText text) => text.OnInternalTextChange += (Action) (() => container.Height = new StyleDimension(text.MinHeight.Pixels, 0.0f));
  }
}
