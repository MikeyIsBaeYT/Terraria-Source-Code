// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiaryNPCEntryPortrait
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiaryNPCEntryPortrait : UIElement
  {
    public BestiaryEntry Entry { get; private set; }

    public UIBestiaryNPCEntryPortrait(
      BestiaryEntry entry,
      Asset<Texture2D> portraitBackgroundAsset,
      Color portraitColor,
      List<IBestiaryBackgroundOverlayAndColorProvider> overlays)
    {
      this.Entry = entry;
      this.Height.Set(112f, 0.0f);
      this.Width.Set(193f, 0.0f);
      this.SetPadding(0.0f);
      UIElement element = new UIElement()
      {
        Width = new StyleDimension(-4f, 1f),
        Height = new StyleDimension(-4f, 1f),
        IgnoresMouseInteraction = true,
        OverflowHidden = true,
        HAlign = 0.5f,
        VAlign = 0.5f
      };
      element.SetPadding(0.0f);
      if (portraitBackgroundAsset != null)
      {
        UIElement uiElement = element;
        UIImage uiImage = new UIImage(portraitBackgroundAsset);
        uiImage.HAlign = 0.5f;
        uiImage.VAlign = 0.5f;
        uiImage.ScaleToFit = true;
        uiImage.Width = new StyleDimension(0.0f, 1f);
        uiImage.Height = new StyleDimension(0.0f, 1f);
        uiImage.Color = portraitColor;
        uiElement.Append((UIElement) uiImage);
      }
      for (int index = 0; index < overlays.Count; ++index)
      {
        Asset<Texture2D> backgroundOverlayImage = overlays[index].GetBackgroundOverlayImage();
        Color? backgroundOverlayColor = overlays[index].GetBackgroundOverlayColor();
        UIElement uiElement = element;
        UIImage uiImage = new UIImage(backgroundOverlayImage);
        uiImage.HAlign = 0.5f;
        uiImage.VAlign = 0.5f;
        uiImage.ScaleToFit = true;
        uiImage.Width = new StyleDimension(0.0f, 1f);
        uiImage.Height = new StyleDimension(0.0f, 1f);
        uiImage.Color = backgroundOverlayColor.HasValue ? backgroundOverlayColor.Value : Color.Lerp(Color.White, portraitColor, 0.5f);
        uiElement.Append((UIElement) uiImage);
      }
      UIBestiaryEntryIcon bestiaryEntryIcon = new UIBestiaryEntryIcon(entry, true);
      element.Append((UIElement) bestiaryEntryIcon);
      this.Append(element);
      UIImage uiImage1 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Portrait_Front", (AssetRequestMode) 1));
      uiImage1.VAlign = 0.5f;
      uiImage1.HAlign = 0.5f;
      uiImage1.IgnoresMouseInteraction = true;
      this.Append((UIElement) uiImage1);
    }
  }
}
