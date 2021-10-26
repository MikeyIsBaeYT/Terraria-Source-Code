// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.SpriteViewMatrix
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.Graphics
{
  public class SpriteViewMatrix
  {
    private Vector2 _zoom = Vector2.One;
    private Vector2 _translation = Vector2.Zero;
    private Matrix _zoomMatrix = Matrix.Identity;
    private Matrix _transformationMatrix = Matrix.Identity;
    private Matrix _normalizedTransformationMatrix = Matrix.Identity;
    private SpriteEffects _effects;
    private Matrix _effectMatrix;
    private GraphicsDevice _graphicsDevice;
    private Viewport _viewport;
    private bool _overrideSystemViewport;
    private bool _needsRebuild = true;

    public Vector2 Zoom
    {
      get => this._zoom;
      set
      {
        if (!(this._zoom != value))
          return;
        this._zoom = value;
        this._needsRebuild = true;
      }
    }

    public Vector2 Translation
    {
      get
      {
        if (this.ShouldRebuild())
          this.Rebuild();
        return this._translation;
      }
    }

    public Matrix ZoomMatrix
    {
      get
      {
        if (this.ShouldRebuild())
          this.Rebuild();
        return this._zoomMatrix;
      }
    }

    public Matrix TransformationMatrix
    {
      get
      {
        if (this.ShouldRebuild())
          this.Rebuild();
        return this._transformationMatrix;
      }
    }

    public Matrix NormalizedTransformationmatrix
    {
      get
      {
        if (this.ShouldRebuild())
          this.Rebuild();
        return this._normalizedTransformationMatrix;
      }
    }

    public SpriteEffects Effects
    {
      get => this._effects;
      set
      {
        if (this._effects == value)
          return;
        this._effects = value;
        this._needsRebuild = true;
      }
    }

    public Matrix EffectMatrix
    {
      get
      {
        if (this.ShouldRebuild())
          this.Rebuild();
        return this._effectMatrix;
      }
    }

    public SpriteViewMatrix(GraphicsDevice graphicsDevice) => this._graphicsDevice = graphicsDevice;

    private void Rebuild()
    {
      if (!this._overrideSystemViewport)
        this._viewport = this._graphicsDevice.Viewport;
      Vector2 vector2_1 = new Vector2((float) this._viewport.Width, (float) this._viewport.Height);
      Matrix identity = Matrix.Identity;
      if (this._effects.HasFlag((Enum) SpriteEffects.FlipHorizontally))
        identity *= Matrix.CreateScale(-1f, 1f, 1f) * Matrix.CreateTranslation(vector2_1.X, 0.0f, 0.0f);
      if (this._effects.HasFlag((Enum) SpriteEffects.FlipVertically))
        identity *= Matrix.CreateScale(1f, -1f, 1f) * Matrix.CreateTranslation(0.0f, vector2_1.Y, 0.0f);
      Vector2 vector2_2 = vector2_1 * 0.5f;
      Vector2 vector2_3 = vector2_2 - vector2_2 / this._zoom;
      Matrix orthographicOffCenter = Matrix.CreateOrthographicOffCenter(0.0f, vector2_1.X, vector2_1.Y, 0.0f, 0.0f, 1f);
      this._translation = vector2_3;
      this._zoomMatrix = Matrix.CreateTranslation(-vector2_3.X, -vector2_3.Y, 0.0f) * Matrix.CreateScale(this._zoom.X, this._zoom.Y, 1f);
      this._effectMatrix = identity;
      this._transformationMatrix = identity * this._zoomMatrix;
      this._normalizedTransformationMatrix = Matrix.Invert(identity) * this._zoomMatrix * orthographicOffCenter;
      this._needsRebuild = false;
    }

    public void SetViewportOverride(Viewport viewport)
    {
      this._viewport = viewport;
      this._overrideSystemViewport = true;
    }

    public void ClearViewportOverride() => this._overrideSystemViewport = false;

    private bool ShouldRebuild()
    {
      if (this._needsRebuild)
        return true;
      if (this._overrideSystemViewport)
        return false;
      return this._graphicsDevice.Viewport.Width != this._viewport.Width || this._graphicsDevice.Viewport.Height != this._viewport.Height;
    }
  }
}
