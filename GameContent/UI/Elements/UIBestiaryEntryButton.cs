// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiaryEntryButton
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
using Terraria.GameContent.Bestiary;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiaryEntryButton : UIElement
  {
    private UIImage _bordersGlow;
    private UIImage _bordersOverlay;
    private UIImage _borders;
    private UIBestiaryEntryIcon _icon;

    public BestiaryEntry Entry { get; private set; }

    public UIBestiaryEntryButton(BestiaryEntry entry, bool isAPrettyPortrait)
    {
      this.Entry = entry;
      this.Height.Set(72f, 0.0f);
      this.Width.Set(72f, 0.0f);
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
      UIImage uiImage1 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Slot_Back", (AssetRequestMode) 1));
      uiImage1.VAlign = 0.5f;
      uiImage1.HAlign = 0.5f;
      element.Append((UIElement) uiImage1);
      if (isAPrettyPortrait)
      {
        Asset<Texture2D> texture = this.TryGettingBackgroundImageProvider(entry);
        if (texture != null)
        {
          UIElement uiElement = element;
          UIImage uiImage2 = new UIImage(texture);
          uiImage2.HAlign = 0.5f;
          uiImage2.VAlign = 0.5f;
          uiElement.Append((UIElement) uiImage2);
        }
      }
      UIBestiaryEntryIcon bestiaryEntryIcon = new UIBestiaryEntryIcon(entry, isAPrettyPortrait);
      element.Append((UIElement) bestiaryEntryIcon);
      this.Append(element);
      this._icon = bestiaryEntryIcon;
      int? nullable = this.TryGettingDisplayIndex(entry);
      if (nullable.HasValue)
      {
        UIText uiText = new UIText(nullable.Value.ToString(), 0.9f);
        uiText.Top = new StyleDimension(10f, 0.0f);
        uiText.Left = new StyleDimension(10f, 0.0f);
        uiText.IgnoresMouseInteraction = true;
        this.Append((UIElement) uiText);
      }
      UIImage uiImage3 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Slot_Selection", (AssetRequestMode) 1));
      uiImage3.VAlign = 0.5f;
      uiImage3.HAlign = 0.5f;
      uiImage3.IgnoresMouseInteraction = true;
      this._bordersGlow = uiImage3;
      UIImage uiImage4 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Slot_Overlay", (AssetRequestMode) 1));
      uiImage4.VAlign = 0.5f;
      uiImage4.HAlign = 0.5f;
      uiImage4.IgnoresMouseInteraction = true;
      uiImage4.Color = Color.White * 0.6f;
      this._bordersOverlay = uiImage4;
      this.Append((UIElement) this._bordersOverlay);
      UIImage uiImage5 = new UIImage(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Slot_Front", (AssetRequestMode) 1));
      uiImage5.VAlign = 0.5f;
      uiImage5.HAlign = 0.5f;
      uiImage5.IgnoresMouseInteraction = true;
      this.Append((UIElement) uiImage5);
      this._borders = uiImage5;
      if (isAPrettyPortrait)
        this.RemoveChild((UIElement) this._bordersOverlay);
      if (isAPrettyPortrait)
        return;
      this.OnMouseOver += new UIElement.MouseEvent(this.MouseOver);
      this.OnMouseOut += new UIElement.MouseEvent(this.MouseOut);
    }

    private Asset<Texture2D> TryGettingBackgroundImageProvider(BestiaryEntry entry)
    {
      IEnumerable<IBestiaryBackgroundImagePathAndColorProvider> source = entry.Info.Where<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (x => x is IBestiaryBackgroundImagePathAndColorProvider)).Select<IBestiaryInfoElement, IBestiaryBackgroundImagePathAndColorProvider>((Func<IBestiaryInfoElement, IBestiaryBackgroundImagePathAndColorProvider>) (x => x as IBestiaryBackgroundImagePathAndColorProvider));
      IEnumerable<IPreferenceProviderElement> preferences = entry.Info.OfType<IPreferenceProviderElement>();
      foreach (IBestiaryBackgroundImagePathAndColorProvider andColorProvider in source.Where<IBestiaryBackgroundImagePathAndColorProvider>((Func<IBestiaryBackgroundImagePathAndColorProvider, bool>) (provider => preferences.Any<IPreferenceProviderElement>((Func<IPreferenceProviderElement, bool>) (preference => preference.Matches(provider))))))
      {
        Asset<Texture2D> backgroundImage = andColorProvider.GetBackgroundImage();
        if (backgroundImage != null)
          return backgroundImage;
      }
      foreach (IBestiaryBackgroundImagePathAndColorProvider andColorProvider in source)
      {
        Asset<Texture2D> backgroundImage = andColorProvider.GetBackgroundImage();
        if (backgroundImage != null)
          return backgroundImage;
      }
      return (Asset<Texture2D>) null;
    }

    private int? TryGettingDisplayIndex(BestiaryEntry entry)
    {
      int? nullable = new int?();
      IBestiaryInfoElement bestiaryInfoElement = entry.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (x => x is IBestiaryEntryDisplayIndex));
      if (bestiaryInfoElement != null)
        nullable = new int?((bestiaryInfoElement as IBestiaryEntryDisplayIndex).BestiaryDisplayIndex);
      return nullable;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (!this.IsMouseHovering)
        return;
      Main.instance.MouseText(this._icon.GetHoverText());
    }

    private void MouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      this.RemoveChild((UIElement) this._borders);
      this.RemoveChild((UIElement) this._bordersGlow);
      this.RemoveChild((UIElement) this._bordersOverlay);
      this.Append((UIElement) this._borders);
      this.Append((UIElement) this._bordersGlow);
      this._icon.ForceHover = true;
    }

    private void MouseOut(UIMouseEvent evt, UIElement listeningElement)
    {
      this.RemoveChild((UIElement) this._borders);
      this.RemoveChild((UIElement) this._bordersGlow);
      this.RemoveChild((UIElement) this._bordersOverlay);
      this.Append((UIElement) this._bordersOverlay);
      this.Append((UIElement) this._borders);
      this._icon.ForceHover = false;
    }
  }
}
