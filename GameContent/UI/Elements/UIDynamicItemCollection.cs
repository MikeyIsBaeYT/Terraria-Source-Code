// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIDynamicItemCollection
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.Elements
{
  public class UIDynamicItemCollection : UIElement
  {
    private List<int> _itemIdsAvailableToShow = new List<int>();
    private List<int> _itemIdsToLoadTexturesFor = new List<int>();
    private int _itemsPerLine;
    private const int sizePerEntryX = 44;
    private const int sizePerEntryY = 44;
    private List<SnapPoint> _dummySnapPoints = new List<SnapPoint>();

    public UIDynamicItemCollection()
    {
      this.Width = new StyleDimension(0.0f, 1f);
      this.HAlign = 0.5f;
      this.UpdateSize();
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      Main.inventoryScale = 0.8461539f;
      int startX;
      int startY;
      int startItemIndex;
      int endItemIndex;
      this.GetGridParameters(out startX, out startY, out startItemIndex, out endItemIndex);
      int itemsPerLine = this._itemsPerLine;
      for (int index = startItemIndex; index < endItemIndex; ++index)
      {
        int key = this._itemIdsAvailableToShow[index];
        Rectangle itemSlotHitbox = this.GetItemSlotHitbox(startX, startY, startItemIndex, index);
        Item inv = ContentSamples.ItemsByType[key];
        int context = 29;
        if (TextureAssets.Item[key].State == null)
          --itemsPerLine;
        bool flag = false;
        if (this.IsMouseHovering && itemSlotHitbox.Contains(Main.MouseScreen.ToPoint()) && !PlayerInput.IgnoreMouseInterface)
        {
          Main.LocalPlayer.mouseInterface = true;
          ItemSlot.OverrideHover(ref inv, context);
          ItemSlot.LeftClick(ref inv, context);
          ItemSlot.RightClick(ref inv, context);
          ItemSlot.MouseHover(ref inv, context);
          flag = true;
        }
        UILinkPointNavigator.Shortcuts.CREATIVE_ItemSlotShouldHighlightAsSelected = flag;
        ItemSlot.Draw(spriteBatch, ref inv, context, itemSlotHitbox.TopLeft());
        if (itemsPerLine <= 0)
          break;
      }
      while (this._itemIdsToLoadTexturesFor.Count > 0 && itemsPerLine > 0)
      {
        int i = this._itemIdsToLoadTexturesFor[0];
        this._itemIdsToLoadTexturesFor.RemoveAt(0);
        if (TextureAssets.Item[i].State == null)
        {
          Main.instance.LoadItem(i);
          itemsPerLine -= 4;
        }
      }
    }

    private Rectangle GetItemSlotHitbox(
      int startX,
      int startY,
      int startItemIndex,
      int i)
    {
      int num1 = i - startItemIndex;
      int num2 = num1 % this._itemsPerLine;
      int num3 = num1 / this._itemsPerLine;
      return new Rectangle(startX + num2 * 44, startY + num3 * 44, 44, 44);
    }

    private void GetGridParameters(
      out int startX,
      out int startY,
      out int startItemIndex,
      out int endItemIndex)
    {
      Rectangle rectangle = this.GetDimensions().ToRectangle();
      Rectangle viewCullingArea = this.Parent.GetViewCullingArea();
      int x = rectangle.Center.X;
      startX = x - (int) ((double) (44 * this._itemsPerLine) * 0.5);
      startY = rectangle.Top;
      startItemIndex = 0;
      endItemIndex = this._itemIdsAvailableToShow.Count;
      int num1 = (Math.Min(viewCullingArea.Top, rectangle.Top) - viewCullingArea.Top) / 44;
      startY += -num1 * 44;
      startItemIndex += -num1 * this._itemsPerLine;
      int num2 = (int) Math.Ceiling((double) viewCullingArea.Height / 44.0) * this._itemsPerLine;
      if (endItemIndex <= num2 + startItemIndex + this._itemsPerLine)
        return;
      endItemIndex = num2 + startItemIndex + this._itemsPerLine;
    }

    public override void Recalculate()
    {
      base.Recalculate();
      this.UpdateSize();
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (!this.IsMouseHovering)
        return;
      Main.LocalPlayer.mouseInterface = true;
    }

    public void SetContentsToShow(List<int> itemIdsToShow)
    {
      this._itemIdsAvailableToShow.Clear();
      this._itemIdsToLoadTexturesFor.Clear();
      this._itemIdsAvailableToShow.AddRange((IEnumerable<int>) itemIdsToShow);
      this._itemIdsToLoadTexturesFor.AddRange((IEnumerable<int>) itemIdsToShow);
      this.UpdateSize();
    }

    public int GetItemsPerLine() => this._itemsPerLine;

    public override List<SnapPoint> GetSnapPoints()
    {
      List<SnapPoint> snapPointList = new List<SnapPoint>();
      int startX;
      int startY;
      int startItemIndex;
      int endItemIndex;
      this.GetGridParameters(out startX, out startY, out startItemIndex, out endItemIndex);
      int itemsPerLine = this._itemsPerLine;
      Rectangle viewCullingArea = this.Parent.GetViewCullingArea();
      int num1 = endItemIndex - startItemIndex;
      while (this._dummySnapPoints.Count < num1)
        this._dummySnapPoints.Add(new SnapPoint("CreativeInfinitesSlot", 0, Vector2.Zero, Vector2.Zero));
      int num2 = 0;
      Vector2 vector2 = this.GetDimensions().Position();
      for (int i = startItemIndex; i < endItemIndex; ++i)
      {
        Point center = this.GetItemSlotHitbox(startX, startY, startItemIndex, i).Center;
        if (viewCullingArea.Contains(center))
        {
          SnapPoint dummySnapPoint = this._dummySnapPoints[num2];
          dummySnapPoint.ThisIsAHackThatChangesTheSnapPointsInfo(Vector2.Zero, center.ToVector2() - vector2, num2);
          dummySnapPoint.Calculate((UIElement) this);
          ++num2;
          snapPointList.Add(dummySnapPoint);
        }
      }
      foreach (UIElement element in this.Elements)
        snapPointList.AddRange((IEnumerable<SnapPoint>) element.GetSnapPoints());
      return snapPointList;
    }

    public void UpdateSize()
    {
      int num = this.GetDimensions().ToRectangle().Width / 44;
      this._itemsPerLine = num;
      this.MinHeight.Set((float) (44 * (int) Math.Ceiling((double) this._itemIdsAvailableToShow.Count / (double) num)), 0.0f);
    }
  }
}
