// Decompiled with JetBrains decompiler
// Type: Terraria.UI.UIElement
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameContent.UI.Elements;

namespace Terraria.UI
{
  public class UIElement : IComparable
  {
    public string Id = "";
    public UIElement Parent;
    protected List<UIElement> Elements = new List<UIElement>();
    public StyleDimension Top;
    public StyleDimension Left;
    public StyleDimension Width;
    public StyleDimension Height;
    public StyleDimension MaxWidth = StyleDimension.Fill;
    public StyleDimension MaxHeight = StyleDimension.Fill;
    public StyleDimension MinWidth = StyleDimension.Empty;
    public StyleDimension MinHeight = StyleDimension.Empty;
    private bool _isInitialized;
    public bool OverflowHidden;
    public float PaddingTop;
    public float PaddingLeft;
    public float PaddingRight;
    public float PaddingBottom;
    public float MarginTop;
    public float MarginLeft;
    public float MarginRight;
    public float MarginBottom;
    public float HAlign;
    public float VAlign;
    private CalculatedStyle _innerDimensions;
    private CalculatedStyle _dimensions;
    private CalculatedStyle _outerDimensions;
    private static RasterizerState _overflowHiddenRasterizerState;
    protected bool _useImmediateMode;
    private SnapPoint _snapPoint;
    private bool _isMouseHovering;

    public event UIElement.MouseEvent OnMouseDown;

    public event UIElement.MouseEvent OnMouseUp;

    public event UIElement.MouseEvent OnClick;

    public event UIElement.MouseEvent OnMouseOver;

    public event UIElement.MouseEvent OnMouseOut;

    public event UIElement.MouseEvent OnDoubleClick;

    public event UIElement.ScrollWheelEvent OnScrollWheel;

    public bool IsMouseHovering => this._isMouseHovering;

    public UIElement()
    {
      if (UIElement._overflowHiddenRasterizerState != null)
        return;
      UIElement._overflowHiddenRasterizerState = new RasterizerState()
      {
        CullMode = CullMode.None,
        ScissorTestEnable = true
      };
    }

    public void SetSnapPoint(string name, int id, Vector2? anchor = null, Vector2? offset = null)
    {
      if (!anchor.HasValue)
        anchor = new Vector2?(new Vector2(0.5f));
      if (!offset.HasValue)
        offset = new Vector2?(Vector2.Zero);
      this._snapPoint = new SnapPoint(name, id, anchor.Value, offset.Value);
    }

    public bool GetSnapPoint(out SnapPoint point)
    {
      point = this._snapPoint;
      if (this._snapPoint != null)
        this._snapPoint.Calculate(this);
      return this._snapPoint != null;
    }

    protected virtual void DrawSelf(SpriteBatch spriteBatch)
    {
    }

    protected virtual void DrawChildren(SpriteBatch spriteBatch)
    {
      foreach (UIElement element in this.Elements)
        element.Draw(spriteBatch);
    }

    public void Append(UIElement element)
    {
      element.Remove();
      element.Parent = this;
      this.Elements.Add(element);
      element.Recalculate();
    }

    public void Remove()
    {
      if (this.Parent == null)
        return;
      this.Parent.RemoveChild(this);
    }

    public void RemoveChild(UIElement child)
    {
      this.Elements.Remove(child);
      child.Parent = (UIElement) null;
    }

    public void RemoveAllChildren()
    {
      foreach (UIElement element in this.Elements)
        element.Parent = (UIElement) null;
      this.Elements.Clear();
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
      int num1 = this.OverflowHidden ? 1 : 0;
      int num2 = this._useImmediateMode ? 1 : 0;
      RasterizerState rasterizerState = spriteBatch.GraphicsDevice.RasterizerState;
      Rectangle scissorRectangle = spriteBatch.GraphicsDevice.ScissorRectangle;
      SamplerState anisotropicClamp = SamplerState.AnisotropicClamp;
      if (num2 != 0)
      {
        spriteBatch.End();
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState, (Effect) null, Main.UIScaleMatrix);
        this.DrawSelf(spriteBatch);
        spriteBatch.End();
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState, (Effect) null, Main.UIScaleMatrix);
      }
      else
        this.DrawSelf(spriteBatch);
      if (num1 != 0)
      {
        spriteBatch.End();
        Rectangle clippingRectangle = this.GetClippingRectangle(spriteBatch);
        spriteBatch.GraphicsDevice.ScissorRectangle = clippingRectangle;
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState, (Effect) null, Main.UIScaleMatrix);
      }
      this.DrawChildren(spriteBatch);
      if (num1 == 0)
        return;
      spriteBatch.End();
      spriteBatch.GraphicsDevice.ScissorRectangle = scissorRectangle;
      spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, rasterizerState, (Effect) null, Main.UIScaleMatrix);
    }

    public virtual void Update(GameTime gameTime)
    {
      foreach (UIElement element in this.Elements)
        element.Update(gameTime);
    }

    public Rectangle GetClippingRectangle(SpriteBatch spriteBatch)
    {
      Vector2 position1 = new Vector2(this._innerDimensions.X, this._innerDimensions.Y);
      Vector2 position2 = new Vector2(this._innerDimensions.Width, this._innerDimensions.Height) + position1;
      Vector2 vector2_1 = Vector2.Transform(position1, Main.UIScaleMatrix);
      Vector2 vector2_2 = Vector2.Transform(position2, Main.UIScaleMatrix);
      Rectangle rectangle = new Rectangle((int) vector2_1.X, (int) vector2_1.Y, (int) ((double) vector2_2.X - (double) vector2_1.X), (int) ((double) vector2_2.Y - (double) vector2_1.Y));
      int width = spriteBatch.GraphicsDevice.Viewport.Width;
      int height = spriteBatch.GraphicsDevice.Viewport.Height;
      rectangle.X = Utils.Clamp<int>(rectangle.X, 0, width);
      rectangle.Y = Utils.Clamp<int>(rectangle.Y, 0, height);
      rectangle.Width = Utils.Clamp<int>(rectangle.Width, 0, width - rectangle.X);
      rectangle.Height = Utils.Clamp<int>(rectangle.Height, 0, height - rectangle.Y);
      return rectangle;
    }

    public virtual List<SnapPoint> GetSnapPoints()
    {
      List<SnapPoint> snapPointList = new List<SnapPoint>();
      SnapPoint point;
      if (this.GetSnapPoint(out point))
        snapPointList.Add(point);
      foreach (UIElement element in this.Elements)
        snapPointList.AddRange((IEnumerable<SnapPoint>) element.GetSnapPoints());
      return snapPointList;
    }

    public virtual void Recalculate()
    {
      CalculatedStyle calculatedStyle1 = this.Parent == null ? UserInterface.ActiveInstance.GetDimensions() : this.Parent.GetInnerDimensions();
      if (this.Parent != null && this.Parent is UIList)
        calculatedStyle1.Height = float.MaxValue;
      CalculatedStyle calculatedStyle2;
      calculatedStyle2.X = this.Left.GetValue(calculatedStyle1.Width) + calculatedStyle1.X;
      calculatedStyle2.Y = this.Top.GetValue(calculatedStyle1.Height) + calculatedStyle1.Y;
      float min1 = this.MinWidth.GetValue(calculatedStyle1.Width);
      float max1 = this.MaxWidth.GetValue(calculatedStyle1.Width);
      float min2 = this.MinHeight.GetValue(calculatedStyle1.Height);
      float max2 = this.MaxHeight.GetValue(calculatedStyle1.Height);
      calculatedStyle2.Width = MathHelper.Clamp(this.Width.GetValue(calculatedStyle1.Width), min1, max1);
      calculatedStyle2.Height = MathHelper.Clamp(this.Height.GetValue(calculatedStyle1.Height), min2, max2);
      calculatedStyle2.Width += this.MarginLeft + this.MarginRight;
      calculatedStyle2.Height += this.MarginTop + this.MarginBottom;
      calculatedStyle2.X += (float) ((double) calculatedStyle1.Width * (double) this.HAlign - (double) calculatedStyle2.Width * (double) this.HAlign);
      calculatedStyle2.Y += (float) ((double) calculatedStyle1.Height * (double) this.VAlign - (double) calculatedStyle2.Height * (double) this.VAlign);
      this._outerDimensions = calculatedStyle2;
      calculatedStyle2.X += this.MarginLeft;
      calculatedStyle2.Y += this.MarginTop;
      calculatedStyle2.Width -= this.MarginLeft + this.MarginRight;
      calculatedStyle2.Height -= this.MarginTop + this.MarginBottom;
      this._dimensions = calculatedStyle2;
      calculatedStyle2.X += this.PaddingLeft;
      calculatedStyle2.Y += this.PaddingTop;
      calculatedStyle2.Width -= this.PaddingLeft + this.PaddingRight;
      calculatedStyle2.Height -= this.PaddingTop + this.PaddingBottom;
      this._innerDimensions = calculatedStyle2;
      this.RecalculateChildren();
    }

    public UIElement GetElementAt(Vector2 point)
    {
      UIElement uiElement = (UIElement) null;
      foreach (UIElement element in this.Elements)
      {
        if (element.ContainsPoint(point))
        {
          uiElement = element;
          break;
        }
      }
      if (uiElement != null)
        return uiElement.GetElementAt(point);
      return this.ContainsPoint(point) ? this : (UIElement) null;
    }

    public virtual bool ContainsPoint(Vector2 point) => (double) point.X > (double) this._dimensions.X && (double) point.Y > (double) this._dimensions.Y && (double) point.X < (double) this._dimensions.X + (double) this._dimensions.Width && (double) point.Y < (double) this._dimensions.Y + (double) this._dimensions.Height;

    public void SetPadding(float pixels)
    {
      this.PaddingBottom = pixels;
      this.PaddingLeft = pixels;
      this.PaddingRight = pixels;
      this.PaddingTop = pixels;
    }

    public virtual void RecalculateChildren()
    {
      foreach (UIElement element in this.Elements)
        element.Recalculate();
    }

    public CalculatedStyle GetInnerDimensions() => this._innerDimensions;

    public CalculatedStyle GetDimensions() => this._dimensions;

    public CalculatedStyle GetOuterDimensions() => this._outerDimensions;

    public void CopyStyle(UIElement element)
    {
      this.Top = element.Top;
      this.Left = element.Left;
      this.Width = element.Width;
      this.Height = element.Height;
      this.PaddingBottom = element.PaddingBottom;
      this.PaddingLeft = element.PaddingLeft;
      this.PaddingRight = element.PaddingRight;
      this.PaddingTop = element.PaddingTop;
      this.HAlign = element.HAlign;
      this.VAlign = element.VAlign;
      this.MinWidth = element.MinWidth;
      this.MaxWidth = element.MaxWidth;
      this.MinHeight = element.MinHeight;
      this.MaxHeight = element.MaxHeight;
      this.Recalculate();
    }

    public virtual void MouseDown(UIMouseEvent evt)
    {
      if (this.OnMouseDown != null)
        this.OnMouseDown(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.MouseDown(evt);
    }

    public virtual void MouseUp(UIMouseEvent evt)
    {
      if (this.OnMouseUp != null)
        this.OnMouseUp(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.MouseUp(evt);
    }

    public virtual void MouseOver(UIMouseEvent evt)
    {
      this._isMouseHovering = true;
      if (this.OnMouseOver != null)
        this.OnMouseOver(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.MouseOver(evt);
    }

    public virtual void MouseOut(UIMouseEvent evt)
    {
      this._isMouseHovering = false;
      if (this.OnMouseOut != null)
        this.OnMouseOut(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.MouseOut(evt);
    }

    public virtual void Click(UIMouseEvent evt)
    {
      if (this.OnClick != null)
        this.OnClick(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.Click(evt);
    }

    public virtual void DoubleClick(UIMouseEvent evt)
    {
      if (this.OnDoubleClick != null)
        this.OnDoubleClick(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.DoubleClick(evt);
    }

    public virtual void ScrollWheel(UIScrollWheelEvent evt)
    {
      if (this.OnScrollWheel != null)
        this.OnScrollWheel(evt, this);
      if (this.Parent == null)
        return;
      this.Parent.ScrollWheel(evt);
    }

    public void Activate()
    {
      if (!this._isInitialized)
        this.Initialize();
      this.OnActivate();
      foreach (UIElement element in this.Elements)
        element.Activate();
    }

    public virtual void OnActivate()
    {
    }

    public void Deactivate()
    {
      this.OnDeactivate();
      foreach (UIElement element in this.Elements)
        element.Deactivate();
    }

    public virtual void OnDeactivate()
    {
    }

    public void Initialize()
    {
      this.OnInitialize();
      this._isInitialized = true;
    }

    public virtual void OnInitialize()
    {
    }

    public virtual int CompareTo(object obj) => 0;

    public delegate void MouseEvent(UIMouseEvent evt, UIElement listeningElement);

    public delegate void ScrollWheelEvent(UIScrollWheelEvent evt, UIElement listeningElement);
  }
}
