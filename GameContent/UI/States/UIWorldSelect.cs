// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UIWorldSelect
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
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
  public class UIWorldSelect : UIState
  {
    private UIList _worldList;
    private UITextPanel<LocalizedText> _backPanel;
    private UITextPanel<LocalizedText> _newPanel;
    private UIPanel _containerPanel;
    private UIScrollbar _scrollbar;
    private bool _isScrollbarAttached;
    private List<Tuple<string, bool>> favoritesCache = new List<Tuple<string, bool>>();
    private bool skipDraw;

    public override void OnInitialize()
    {
      UIElement element = new UIElement();
      element.Width.Set(0.0f, 0.8f);
      element.MaxWidth.Set(650f, 0.0f);
      element.Top.Set(220f, 0.0f);
      element.Height.Set(-220f, 1f);
      element.HAlign = 0.5f;
      UIPanel uiPanel = new UIPanel();
      uiPanel.Width.Set(0.0f, 1f);
      uiPanel.Height.Set(-110f, 1f);
      uiPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
      element.Append((UIElement) uiPanel);
      this._containerPanel = uiPanel;
      this._worldList = new UIList();
      this._worldList.Width.Set(0.0f, 1f);
      this._worldList.Height.Set(0.0f, 1f);
      this._worldList.ListPadding = 5f;
      uiPanel.Append((UIElement) this._worldList);
      this._scrollbar = new UIScrollbar();
      this._scrollbar.SetView(100f, 1000f);
      this._scrollbar.Height.Set(0.0f, 1f);
      this._scrollbar.HAlign = 1f;
      this._worldList.SetScrollbar(this._scrollbar);
      UITextPanel<LocalizedText> uiTextPanel1 = new UITextPanel<LocalizedText>(Language.GetText("UI.SelectWorld"), 0.8f, true);
      uiTextPanel1.HAlign = 0.5f;
      uiTextPanel1.Top.Set(-40f, 0.0f);
      uiTextPanel1.SetPadding(15f);
      uiTextPanel1.BackgroundColor = new Color(73, 94, 171);
      element.Append((UIElement) uiTextPanel1);
      UITextPanel<LocalizedText> uiTextPanel2 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
      uiTextPanel2.Width.Set(-10f, 0.5f);
      uiTextPanel2.Height.Set(50f, 0.0f);
      uiTextPanel2.VAlign = 1f;
      uiTextPanel2.Top.Set(-45f, 0.0f);
      uiTextPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiTextPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiTextPanel2.OnClick += new UIElement.MouseEvent(this.GoBackClick);
      element.Append((UIElement) uiTextPanel2);
      this._backPanel = uiTextPanel2;
      UITextPanel<LocalizedText> uiTextPanel3 = new UITextPanel<LocalizedText>(Language.GetText("UI.New"), 0.7f, true);
      uiTextPanel3.CopyStyle((UIElement) uiTextPanel2);
      uiTextPanel3.HAlign = 1f;
      uiTextPanel3.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiTextPanel3.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiTextPanel3.OnClick += new UIElement.MouseEvent(this.NewWorldClick);
      element.Append((UIElement) uiTextPanel3);
      this._newPanel = uiTextPanel3;
      this.Append(element);
    }

    public override void Recalculate()
    {
      if (this._scrollbar != null)
      {
        if (this._isScrollbarAttached && !this._scrollbar.CanScroll)
        {
          this._containerPanel.RemoveChild((UIElement) this._scrollbar);
          this._isScrollbarAttached = false;
          this._worldList.Width.Set(0.0f, 1f);
        }
        else if (!this._isScrollbarAttached && this._scrollbar.CanScroll)
        {
          this._containerPanel.Append((UIElement) this._scrollbar);
          this._isScrollbarAttached = true;
          this._worldList.Width.Set(-25f, 1f);
        }
      }
      base.Recalculate();
    }

    private void NewWorldClick(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(10);
      Main.newWorldName = Lang.gen[57].Value + " " + (object) (Main.WorldList.Count + 1);
      Main.MenuUI.SetState((UIState) new UIWorldCreation());
      Main.menuMode = 888;
    }

    private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(11);
      Main.menuMode = Main.menuMultiplayer ? 12 : 1;
    }

    private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      SoundEngine.PlaySound(12);
      ((UIPanel) evt.Target).BackgroundColor = new Color(73, 94, 171);
      ((UIPanel) evt.Target).BorderColor = Colors.FancyUIFatButtonMouseOver;
    }

    private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
    {
      ((UIPanel) evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
      ((UIPanel) evt.Target).BorderColor = Color.Black;
    }

    public override void OnActivate()
    {
      Main.LoadWorlds();
      this.UpdateWorldsList();
      if (!PlayerInput.UsingGamepadUI)
        return;
      UILinkPointNavigator.ChangePoint(3000 + (this._worldList.Count == 0 ? 1 : 2));
    }

    private void UpdateWorldsList()
    {
      this._worldList.Clear();
      IOrderedEnumerable<WorldFileData> orderedEnumerable = new List<WorldFileData>((IEnumerable<WorldFileData>) Main.WorldList).OrderByDescending<WorldFileData, bool>(new Func<WorldFileData, bool>(this.CanWorldBePlayed)).ThenByDescending<WorldFileData, bool>((Func<WorldFileData, bool>) (x => x.IsFavorite)).ThenBy<WorldFileData, string>((Func<WorldFileData, string>) (x => x.Name)).ThenBy<WorldFileData, string>((Func<WorldFileData, string>) (x => x.GetFileName()));
      int num = 0;
      foreach (WorldFileData worldFileData in (IEnumerable<WorldFileData>) orderedEnumerable)
        this._worldList.Add((UIElement) new UIWorldListItem(worldFileData, num++, this.CanWorldBePlayed(worldFileData)));
    }

    private bool CanWorldBePlayed(WorldFileData file) => Main.ActivePlayerFileData.Player.difficulty == (byte) 3 == (file.GameMode == 3);

    public override void Draw(SpriteBatch spriteBatch)
    {
      if (this.skipDraw)
      {
        this.skipDraw = false;
      }
      else
      {
        if (this.UpdateFavoritesCache())
        {
          this.skipDraw = true;
          Main.MenuUI.Draw(spriteBatch, new GameTime());
        }
        base.Draw(spriteBatch);
        this.SetupGamepadPoints(spriteBatch);
      }
    }

    private bool UpdateFavoritesCache()
    {
      List<WorldFileData> worldFileDataList = new List<WorldFileData>((IEnumerable<WorldFileData>) Main.WorldList);
      worldFileDataList.Sort((Comparison<WorldFileData>) ((x, y) =>
      {
        if (x.IsFavorite && !y.IsFavorite)
          return -1;
        if (!x.IsFavorite && y.IsFavorite)
          return 1;
        return x.Name.CompareTo(y.Name) != 0 ? x.Name.CompareTo(y.Name) : x.GetFileName().CompareTo(y.GetFileName());
      }));
      bool flag = false;
      if (!flag && worldFileDataList.Count != this.favoritesCache.Count)
        flag = true;
      if (!flag)
      {
        for (int index = 0; index < this.favoritesCache.Count; ++index)
        {
          Tuple<string, bool> tuple = this.favoritesCache[index];
          if (!(worldFileDataList[index].Name == tuple.Item1) || worldFileDataList[index].IsFavorite != tuple.Item2)
          {
            flag = true;
            break;
          }
        }
      }
      if (flag)
      {
        this.favoritesCache.Clear();
        foreach (WorldFileData worldFileData in worldFileDataList)
          this.favoritesCache.Add(Tuple.Create<string, bool>(worldFileData.Name, worldFileData.IsFavorite));
        this.UpdateWorldsList();
      }
      return flag;
    }

    private void SetupGamepadPoints(SpriteBatch spriteBatch)
    {
      UILinkPointNavigator.Shortcuts.BackButtonCommand = 2;
      int num1 = 3000;
      UILinkPointNavigator.SetPosition(num1, this._backPanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
      UILinkPointNavigator.SetPosition(num1 + 1, this._newPanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
      int key1 = num1;
      UILinkPoint point1 = UILinkPointNavigator.Points[key1];
      point1.Unlink();
      point1.Right = key1 + 1;
      int key2 = num1 + 1;
      UILinkPoint point2 = UILinkPointNavigator.Points[key2];
      point2.Unlink();
      point2.Left = key2 - 1;
      float num2 = 1f / Main.UIScale;
      Rectangle clippingRectangle = this._containerPanel.GetClippingRectangle(spriteBatch);
      Vector2 minimum = clippingRectangle.TopLeft() * num2;
      Vector2 maximum = clippingRectangle.BottomRight() * num2;
      List<SnapPoint> snapPoints = this.GetSnapPoints();
      for (int index = 0; index < snapPoints.Count; ++index)
      {
        if (!snapPoints[index].Position.Between(minimum, maximum))
        {
          snapPoints.Remove(snapPoints[index]);
          --index;
        }
      }
      SnapPoint[,] snapPointArray = new SnapPoint[this._worldList.Count, 5];
      foreach (SnapPoint snapPoint in snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Play")))
        snapPointArray[snapPoint.Id, 0] = snapPoint;
      foreach (SnapPoint snapPoint in snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Favorite")))
        snapPointArray[snapPoint.Id, 1] = snapPoint;
      foreach (SnapPoint snapPoint in snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Cloud")))
        snapPointArray[snapPoint.Id, 2] = snapPoint;
      foreach (SnapPoint snapPoint in snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Seed")))
        snapPointArray[snapPoint.Id, 3] = snapPoint;
      foreach (SnapPoint snapPoint in snapPoints.Where<SnapPoint>((Func<SnapPoint, bool>) (a => a.Name == "Delete")))
        snapPointArray[snapPoint.Id, 4] = snapPoint;
      int num3 = num1 + 2;
      int[] numArray = new int[this._worldList.Count];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = -1;
      for (int index1 = 0; index1 < 5; ++index1)
      {
        int key3 = -1;
        for (int index2 = 0; index2 < snapPointArray.GetLength(0); ++index2)
        {
          if (snapPointArray[index2, index1] != null)
          {
            UILinkPoint point3 = UILinkPointNavigator.Points[num3];
            point3.Unlink();
            UILinkPointNavigator.SetPosition(num3, snapPointArray[index2, index1].Position);
            if (key3 != -1)
            {
              point3.Up = key3;
              UILinkPointNavigator.Points[key3].Down = num3;
            }
            if (numArray[index2] != -1)
            {
              point3.Left = numArray[index2];
              UILinkPointNavigator.Points[numArray[index2]].Right = num3;
            }
            point3.Down = num1;
            if (index1 == 0)
              UILinkPointNavigator.Points[num1].Up = UILinkPointNavigator.Points[num1 + 1].Up = num3;
            key3 = num3;
            numArray[index2] = num3;
            UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num3;
            ++num3;
          }
        }
      }
      if (!PlayerInput.UsingGamepadUI || this._worldList.Count != 0 || UILinkPointNavigator.CurrentPoint <= 3001)
        return;
      UILinkPointNavigator.ChangePoint(3001);
    }
  }
}
