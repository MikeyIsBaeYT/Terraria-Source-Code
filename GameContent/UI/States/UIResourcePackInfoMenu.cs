// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UIResourcePackInfoMenu
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
  public class UIResourcePackInfoMenu : UIState
  {
    private UIResourcePackSelectionMenu _resourceMenu;
    private ResourcePack _pack;
    private UIElement _container;
    private UIList _list;
    private UIScrollbar _scrollbar;
    private bool _isScrollbarAttached;
    private const string _backPointName = "GoBack";
    private UIGamepadHelper _helper;

    public UIResourcePackInfoMenu(UIResourcePackSelectionMenu parent, ResourcePack pack)
    {
      this._resourceMenu = parent;
      this._pack = pack;
      this.BuildPage();
    }

    private void BuildPage()
    {
      this.RemoveAllChildren();
      UIElement element1 = new UIElement();
      element1.Width.Set(0.0f, 0.8f);
      element1.MaxWidth.Set(500f, 0.0f);
      element1.MinWidth.Set(300f, 0.0f);
      element1.Top.Set(230f, 0.0f);
      element1.Height.Set(-element1.Top.Pixels, 1f);
      element1.HAlign = 0.5f;
      this.Append(element1);
      UIPanel uiPanel = new UIPanel();
      uiPanel.Width.Set(0.0f, 1f);
      uiPanel.Height.Set(-110f, 1f);
      uiPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
      element1.Append((UIElement) uiPanel);
      UIElement element2 = new UIElement()
      {
        Width = StyleDimension.Fill,
        Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f)
      };
      uiPanel.Append(element2);
      UIElement element3 = new UIElement()
      {
        Width = new StyleDimension(0.0f, 1f),
        Height = new StyleDimension(52f, 0.0f)
      };
      element3.SetPadding(0.0f);
      element2.Append(element3);
      UIText uiText1 = new UIText(this._pack.Name, 0.7f, true)
      {
        TextColor = Color.Gold
      };
      uiText1.HAlign = 0.5f;
      uiText1.VAlign = 0.0f;
      element3.Append((UIElement) uiText1);
      UIText uiText2 = new UIText(Language.GetTextValue("UI.Author", (object) this._pack.Author), 0.9f);
      uiText2.HAlign = 0.0f;
      uiText2.VAlign = 1f;
      UIText uiText3 = uiText2;
      uiText3.Top.Set(-6f, 0.0f);
      element3.Append((UIElement) uiText3);
      UIText uiText4 = new UIText(Language.GetTextValue("UI.Version", (object) this._pack.Version.GetFormattedVersion()), 0.9f);
      uiText4.HAlign = 1f;
      uiText4.VAlign = 1f;
      uiText4.TextColor = Color.Silver;
      UIText uiText5 = uiText4;
      uiText5.Top.Set(-6f, 0.0f);
      element3.Append((UIElement) uiText5);
      Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Divider", (AssetRequestMode) 1);
      UIImage uiImage1 = new UIImage(asset);
      uiImage1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiImage1.Height = StyleDimension.FromPixels((float) asset.Height());
      uiImage1.ScaleToFit = true;
      UIImage uiImage2 = uiImage1;
      uiImage2.Top.Set(52f, 0.0f);
      uiImage2.SetPadding(6f);
      element2.Append((UIElement) uiImage2);
      UIElement element4 = new UIElement()
      {
        HAlign = 0.5f,
        VAlign = 1f,
        Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f),
        Height = StyleDimension.FromPixelsAndPercent(-74f, 1f)
      };
      element2.Append(element4);
      this._container = element4;
      UIText uiText6 = new UIText(this._pack.Description);
      uiText6.HAlign = 0.5f;
      uiText6.VAlign = 0.0f;
      uiText6.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiText6.Height = StyleDimension.FromPixelsAndPercent(0.0f, 0.0f);
      uiText6.IsWrapped = true;
      uiText6.WrappedTextBottomPadding = 0.0f;
      UIText uiText7 = uiText6;
      UIList uiList1 = new UIList();
      uiList1.HAlign = 0.5f;
      uiList1.VAlign = 0.0f;
      uiList1.Width = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiList1.Height = StyleDimension.FromPixelsAndPercent(0.0f, 1f);
      uiList1.PaddingRight = 20f;
      UIList uiList2 = uiList1;
      uiList2.ListPadding = 5f;
      uiList2.Add((UIElement) uiText7);
      element4.Append((UIElement) uiList2);
      this._list = uiList2;
      UIScrollbar scrollbar = new UIScrollbar();
      scrollbar.SetView(100f, 1000f);
      scrollbar.Height.Set(0.0f, 1f);
      scrollbar.HAlign = 1f;
      this._scrollbar = scrollbar;
      uiList2.SetScrollbar(scrollbar);
      UITextPanel<LocalizedText> uiTextPanel = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
      uiTextPanel.Width.Set(-10f, 0.5f);
      uiTextPanel.Height.Set(50f, 0.0f);
      uiTextPanel.VAlign = 1f;
      uiTextPanel.HAlign = 0.5f;
      uiTextPanel.Top.Set(-45f, 0.0f);
      uiTextPanel.OnMouseOver += new UIElement.MouseEvent(UIResourcePackInfoMenu.FadedMouseOver);
      uiTextPanel.OnMouseOut += new UIElement.MouseEvent(UIResourcePackInfoMenu.FadedMouseOut);
      uiTextPanel.OnClick += new UIElement.MouseEvent(this.GoBackClick);
      uiTextPanel.SetSnapPoint("GoBack", 0);
      element1.Append((UIElement) uiTextPanel);
    }

    public override void Recalculate()
    {
      if (this._scrollbar != null)
      {
        if (this._isScrollbarAttached && !this._scrollbar.CanScroll)
        {
          this._container.RemoveChild((UIElement) this._scrollbar);
          this._isScrollbarAttached = false;
          this._list.Width.Set(0.0f, 1f);
        }
        else if (!this._isScrollbarAttached && this._scrollbar.CanScroll)
        {
          this._container.Append((UIElement) this._scrollbar);
          this._isScrollbarAttached = true;
          this._list.Width.Set(-25f, 1f);
        }
      }
      base.Recalculate();
    }

    private void GoBackClick(UIMouseEvent evt, UIElement listeningElement) => Main.MenuUI.SetState((UIState) this._resourceMenu);

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

    public override void Draw(SpriteBatch spriteBatch)
    {
      base.Draw(spriteBatch);
      this.SetupGamepadPoints(spriteBatch);
    }

    private void SetupGamepadPoints(SpriteBatch spriteBatch)
    {
      UILinkPointNavigator.Shortcuts.BackButtonCommand = 1;
      int idRangeStartInclusive = 3000;
      int idRangeEndExclusive = idRangeStartInclusive;
      List<SnapPoint> snapPoints = this.GetSnapPoints();
      UILinkPoint uiLinkPoint = (UILinkPoint) null;
      for (int index = 0; index < snapPoints.Count; ++index)
      {
        SnapPoint snap = snapPoints[index];
        if (snap.Name == "GoBack")
          uiLinkPoint = this._helper.MakeLinkPointFromSnapPoint(idRangeEndExclusive++, snap);
      }
      if (PlayerInput.UsingGamepadUI)
        this._helper.MoveToVisuallyClosestPoint(idRangeStartInclusive, idRangeEndExclusive);
      if (!Main.CreativeMenu.GamepadMoveToSearchButtonHack)
        return;
      Main.CreativeMenu.GamepadMoveToSearchButtonHack = false;
      if (uiLinkPoint == null)
        return;
      UILinkPointNavigator.ChangePoint(uiLinkPoint.ID);
    }
  }
}
