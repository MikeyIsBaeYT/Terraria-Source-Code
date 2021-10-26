// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIList
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIList : UIElement, IEnumerable<UIElement>, IEnumerable
  {
    protected List<UIElement> _items = new List<UIElement>();
    protected UIScrollbar _scrollbar;
    private UIElement _innerList = (UIElement) new UIList.UIInnerList();
    private float _innerListHeight;
    public float ListPadding = 5f;
    public Action<List<UIElement>> ManualSortMethod;

    public int Count => this._items.Count;

    public UIList()
    {
      this._innerList.OverflowHidden = false;
      this._innerList.Width.Set(0.0f, 1f);
      this._innerList.Height.Set(0.0f, 1f);
      this.OverflowHidden = true;
      this.Append(this._innerList);
    }

    public float GetTotalHeight() => this._innerListHeight;

    public void Goto(UIList.ElementSearchMethod searchMethod)
    {
      for (int index = 0; index < this._items.Count; ++index)
      {
        if (searchMethod(this._items[index]))
        {
          this._scrollbar.ViewPosition = this._items[index].Top.Pixels;
          break;
        }
      }
    }

    public virtual void Add(UIElement item)
    {
      this._items.Add(item);
      this._innerList.Append(item);
      this.UpdateOrder();
      this._innerList.Recalculate();
    }

    public virtual bool Remove(UIElement item)
    {
      this._innerList.RemoveChild(item);
      this.UpdateOrder();
      return this._items.Remove(item);
    }

    public virtual void Clear()
    {
      this._innerList.RemoveAllChildren();
      this._items.Clear();
    }

    public override void Recalculate()
    {
      base.Recalculate();
      this.UpdateScrollbar();
    }

    public override void ScrollWheel(UIScrollWheelEvent evt)
    {
      base.ScrollWheel(evt);
      if (this._scrollbar == null)
        return;
      this._scrollbar.ViewPosition -= (float) evt.ScrollWheelValue;
    }

    public override void RecalculateChildren()
    {
      base.RecalculateChildren();
      float pixels = 0.0f;
      for (int index = 0; index < this._items.Count; ++index)
      {
        float num = this._items.Count == 1 ? 0.0f : this.ListPadding;
        this._items[index].Top.Set(pixels, 0.0f);
        this._items[index].Recalculate();
        CalculatedStyle outerDimensions = this._items[index].GetOuterDimensions();
        pixels += outerDimensions.Height + num;
      }
      this._innerListHeight = pixels;
    }

    private void UpdateScrollbar()
    {
      if (this._scrollbar == null)
        return;
      this._scrollbar.SetView(this.GetInnerDimensions().Height, this._innerListHeight);
    }

    public void SetScrollbar(UIScrollbar scrollbar)
    {
      this._scrollbar = scrollbar;
      this.UpdateScrollbar();
    }

    public void UpdateOrder()
    {
      if (this.ManualSortMethod != null)
        this.ManualSortMethod(this._items);
      else
        this._items.Sort(new Comparison<UIElement>(this.SortMethod));
      this.UpdateScrollbar();
    }

    public int SortMethod(UIElement item1, UIElement item2) => item1.CompareTo((object) item2);

    public override List<SnapPoint> GetSnapPoints()
    {
      List<SnapPoint> snapPointList = new List<SnapPoint>();
      SnapPoint point;
      if (this.GetSnapPoint(out point))
        snapPointList.Add(point);
      foreach (UIElement uiElement in this._items)
        snapPointList.AddRange((IEnumerable<SnapPoint>) uiElement.GetSnapPoints());
      return snapPointList;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (this._scrollbar != null)
        this._innerList.Top.Set(-this._scrollbar.GetValue(), 0.0f);
      this.Recalculate();
    }

    public IEnumerator<UIElement> GetEnumerator() => ((IEnumerable<UIElement>) this._items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) ((IEnumerable<UIElement>) this._items).GetEnumerator();

    public delegate bool ElementSearchMethod(UIElement element);

    private class UIInnerList : UIElement
    {
      public override bool ContainsPoint(Vector2 point) => true;

      protected override void DrawChildren(SpriteBatch spriteBatch)
      {
        Vector2 position1 = this.Parent.GetDimensions().Position();
        Vector2 dimensions1 = new Vector2(this.Parent.GetDimensions().Width, this.Parent.GetDimensions().Height);
        foreach (UIElement element in this.Elements)
        {
          Vector2 position2 = element.GetDimensions().Position();
          Vector2 dimensions2 = new Vector2(element.GetDimensions().Width, element.GetDimensions().Height);
          if (Collision.CheckAABBvAABBCollision(position1, dimensions1, position2, dimensions2))
            element.Draw(spriteBatch);
        }
      }

      public override Rectangle GetViewCullingArea() => this.Parent.GetDimensions().ToRectangle();
    }
  }
}
