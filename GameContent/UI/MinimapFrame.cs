// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.MinimapFrame
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Diagnostics;
using Terraria.Audio;
using Terraria.GameInput;

namespace Terraria.GameContent.UI
{
  public class MinimapFrame
  {
    private const float DEFAULT_ZOOM = 1.05f;
    private const float ZOOM_OUT_MULTIPLIER = 0.975f;
    private const float ZOOM_IN_MULTIPLIER = 1.025f;
    private readonly Asset<Texture2D> _frameTexture;
    private readonly Vector2 _frameOffset;
    private MinimapFrame.Button _resetButton;
    private MinimapFrame.Button _zoomInButton;
    private MinimapFrame.Button _zoomOutButton;

    public Vector2 MinimapPosition { get; set; }

    private Vector2 FramePosition
    {
      get => this.MinimapPosition + this._frameOffset;
      set => this.MinimapPosition = value - this._frameOffset;
    }

    public MinimapFrame(Asset<Texture2D> frameTexture, Vector2 frameOffset)
    {
      this._frameTexture = frameTexture;
      this._frameOffset = frameOffset;
    }

    public void SetResetButton(Asset<Texture2D> hoverTexture, Vector2 position) => this._resetButton = new MinimapFrame.Button(hoverTexture, position, (Action) (() => this.ResetZoom()));

    private void ResetZoom() => Main.mapMinimapScale = 1.05f;

    public void SetZoomInButton(Asset<Texture2D> hoverTexture, Vector2 position) => this._zoomInButton = new MinimapFrame.Button(hoverTexture, position, (Action) (() => this.ZoomInButton()));

    private void ZoomInButton() => Main.mapMinimapScale *= 1.025f;

    public void SetZoomOutButton(Asset<Texture2D> hoverTexture, Vector2 position) => this._zoomOutButton = new MinimapFrame.Button(hoverTexture, position, (Action) (() => this.ZoomOutButton()));

    private void ZoomOutButton() => Main.mapMinimapScale *= 0.975f;

    public void Update()
    {
      MinimapFrame.Button buttonUnderMouse = this.GetButtonUnderMouse();
      this._zoomInButton.IsHighlighted = buttonUnderMouse == this._zoomInButton;
      this._zoomOutButton.IsHighlighted = buttonUnderMouse == this._zoomOutButton;
      this._resetButton.IsHighlighted = buttonUnderMouse == this._resetButton;
      if (buttonUnderMouse == null || Main.LocalPlayer.lastMouseInterface)
        return;
      buttonUnderMouse.IsHighlighted = true;
      if (PlayerInput.IgnoreMouseInterface)
        return;
      Main.LocalPlayer.mouseInterface = true;
      if (!Main.mouseLeft)
        return;
      buttonUnderMouse.Click();
      if (!Main.mouseLeftRelease)
        return;
      SoundEngine.PlaySound(12);
    }

    public void DrawBackground(SpriteBatch spriteBatch) => spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle((int) this.MinimapPosition.X - 6, (int) this.MinimapPosition.Y - 6, 244, 244), Color.Black * Main.mapMinimapAlpha);

    public void DrawForeground(SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(this._frameTexture.Value, this.FramePosition, Color.White);
      this._zoomInButton.Draw(spriteBatch, this.FramePosition);
      this._zoomOutButton.Draw(spriteBatch, this.FramePosition);
      this._resetButton.Draw(spriteBatch, this.FramePosition);
    }

    private MinimapFrame.Button GetButtonUnderMouse()
    {
      Vector2 testPoint = new Vector2((float) Main.mouseX, (float) Main.mouseY);
      if (this._zoomInButton.IsTouchingPoint(testPoint, this.FramePosition))
        return this._zoomInButton;
      if (this._zoomOutButton.IsTouchingPoint(testPoint, this.FramePosition))
        return this._zoomOutButton;
      return this._resetButton.IsTouchingPoint(testPoint, this.FramePosition) ? this._resetButton : (MinimapFrame.Button) null;
    }

    [Conditional("DEBUG")]
    private void ValidateState()
    {
    }

    private class Button
    {
      public bool IsHighlighted;
      private readonly Vector2 _position;
      private readonly Asset<Texture2D> _hoverTexture;
      private readonly Action _onMouseDown;

      private Vector2 Size => new Vector2((float) this._hoverTexture.Width(), (float) this._hoverTexture.Height());

      public Button(Asset<Texture2D> hoverTexture, Vector2 position, Action mouseDownCallback)
      {
        this._position = position;
        this._hoverTexture = hoverTexture;
        this._onMouseDown = mouseDownCallback;
      }

      public void Click() => this._onMouseDown();

      public void Draw(SpriteBatch spriteBatch, Vector2 parentPosition)
      {
        if (!this.IsHighlighted)
          return;
        spriteBatch.Draw(this._hoverTexture.Value, this._position + parentPosition, Color.White);
      }

      public bool IsTouchingPoint(Vector2 testPoint, Vector2 parentPosition)
      {
        Vector2 vector2_1 = this._position + parentPosition + this.Size * 0.5f;
        Vector2 vector2_2 = Vector2.Max(this.Size, new Vector2(22f, 22f)) * 0.5f;
        Vector2 vector2_3 = testPoint - vector2_1;
        return (double) Math.Abs(vector2_3.X) < (double) vector2_2.X && (double) Math.Abs(vector2_3.Y) < (double) vector2_2.Y;
      }
    }
  }
}
