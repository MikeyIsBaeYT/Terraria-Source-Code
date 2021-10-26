// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIScrollbar
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIScrollbar : UIElement
  {
    private float _viewPosition;
    private float _viewSize = 1f;
    private float _maxViewSize = 20f;
    private bool _isDragging;
    private bool _isHoveringOverHandle;
    private float _dragYOffset;
    private Asset<Texture2D> _texture;
    private Asset<Texture2D> _innerTexture;

    public float ViewPosition
    {
      get => this._viewPosition;
      set => this._viewPosition = MathHelper.Clamp(value, 0.0f, this._maxViewSize - this._viewSize);
    }

    public bool CanScroll => (double) this._maxViewSize != (double) this._viewSize;

    public UIScrollbar()
    {
      this.Width.Set(20f, 0.0f);
      this.MaxWidth.Set(20f, 0.0f);
      this._texture = Main.Assets.Request<Texture2D>("Images/UI/Scrollbar", (AssetRequestMode) 1);
      this._innerTexture = Main.Assets.Request<Texture2D>("Images/UI/ScrollbarInner", (AssetRequestMode) 1);
      this.PaddingTop = 5f;
      this.PaddingBottom = 5f;
    }

    public void SetView(float viewSize, float maxViewSize)
    {
      viewSize = MathHelper.Clamp(viewSize, 0.0f, maxViewSize);
      this._viewPosition = MathHelper.Clamp(this._viewPosition, 0.0f, maxViewSize - viewSize);
      this._viewSize = viewSize;
      this._maxViewSize = maxViewSize;
    }

    public float GetValue() => this._viewPosition;

    private Rectangle GetHandleRectangle()
    {
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      if ((double) this._maxViewSize == 0.0 && (double) this._viewSize == 0.0)
      {
        this._viewSize = 1f;
        this._maxViewSize = 1f;
      }
      return new Rectangle((int) innerDimensions.X, (int) ((double) innerDimensions.Y + (double) innerDimensions.Height * ((double) this._viewPosition / (double) this._maxViewSize)) - 3, 20, (int) ((double) innerDimensions.Height * ((double) this._viewSize / (double) this._maxViewSize)) + 7);
    }

    private void DrawBar(
      SpriteBatch spriteBatch,
      Texture2D texture,
      Rectangle dimensions,
      Color color)
    {
      spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y - 6, dimensions.Width, 6), new Rectangle?(new Rectangle(0, 0, texture.Width, 6)), color);
      spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y, dimensions.Width, dimensions.Height), new Rectangle?(new Rectangle(0, 6, texture.Width, 4)), color);
      spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y + dimensions.Height, dimensions.Width, 6), new Rectangle?(new Rectangle(0, texture.Height - 6, texture.Width, 6)), color);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      if (this._isDragging)
        this._viewPosition = MathHelper.Clamp((UserInterface.ActiveInstance.MousePosition.Y - innerDimensions.Y - this._dragYOffset) / innerDimensions.Height * this._maxViewSize, 0.0f, this._maxViewSize - this._viewSize);
      Rectangle handleRectangle = this.GetHandleRectangle();
      Vector2 mousePosition = UserInterface.ActiveInstance.MousePosition;
      int num = this._isHoveringOverHandle ? 1 : 0;
      this._isHoveringOverHandle = handleRectangle.Contains(new Point((int) mousePosition.X, (int) mousePosition.Y));
      if (num == 0 && this._isHoveringOverHandle && Main.hasFocus)
        SoundEngine.PlaySound(12);
      this.DrawBar(spriteBatch, this._texture.Value, dimensions.ToRectangle(), Color.White);
      this.DrawBar(spriteBatch, this._innerTexture.Value, handleRectangle, Color.White * (this._isDragging || this._isHoveringOverHandle ? 1f : 0.85f));
    }

    public override void MouseDown(UIMouseEvent evt)
    {
      base.MouseDown(evt);
      if (evt.Target != this)
        return;
      Rectangle handleRectangle = this.GetHandleRectangle();
      if (handleRectangle.Contains(new Point((int) evt.MousePosition.X, (int) evt.MousePosition.Y)))
      {
        this._isDragging = true;
        this._dragYOffset = evt.MousePosition.Y - (float) handleRectangle.Y;
      }
      else
      {
        CalculatedStyle innerDimensions = this.GetInnerDimensions();
        this._viewPosition = MathHelper.Clamp((UserInterface.ActiveInstance.MousePosition.Y - innerDimensions.Y - (float) (handleRectangle.Height >> 1)) / innerDimensions.Height * this._maxViewSize, 0.0f, this._maxViewSize - this._viewSize);
      }
    }

    public override void MouseUp(UIMouseEvent evt)
    {
      base.MouseUp(evt);
      this._isDragging = false;
    }
  }
}
