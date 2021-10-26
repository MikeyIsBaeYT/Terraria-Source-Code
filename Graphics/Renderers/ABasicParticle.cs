// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.ABasicParticle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Terraria.Graphics.Renderers
{
  public abstract class ABasicParticle : IPooledParticle, IParticle
  {
    public Vector2 AccelerationPerFrame;
    public Vector2 Velocity;
    public Vector2 LocalPosition;
    protected Asset<Texture2D> _texture;
    protected Rectangle _frame;
    protected Vector2 _origin;
    public float Rotation;
    public float RotationVelocity;
    public float RotationAcceleration;
    public Vector2 Scale;
    public Vector2 ScaleVelocity;
    public Vector2 ScaleAcceleration;

    public bool ShouldBeRemovedFromRenderer { get; protected set; }

    public ABasicParticle()
    {
      this._texture = (Asset<Texture2D>) null;
      this._frame = Rectangle.Empty;
      this._origin = Vector2.Zero;
      this.Velocity = Vector2.Zero;
      this.LocalPosition = Vector2.Zero;
      this.ShouldBeRemovedFromRenderer = false;
    }

    public virtual void SetBasicInfo(
      Asset<Texture2D> textureAsset,
      Rectangle? frame,
      Vector2 initialVelocity,
      Vector2 initialLocalPosition)
    {
      this._texture = textureAsset;
      this._frame = frame.HasValue ? frame.Value : this._texture.Frame();
      this._origin = this._frame.Size() / 2f;
      this.Velocity = initialVelocity;
      this.LocalPosition = initialLocalPosition;
      this.ShouldBeRemovedFromRenderer = false;
    }

    public virtual void Update(ref ParticleRendererSettings settings)
    {
      this.Velocity += this.AccelerationPerFrame;
      this.LocalPosition += this.Velocity;
      this.RotationVelocity += this.RotationAcceleration;
      this.Rotation += this.RotationVelocity;
      this.ScaleVelocity += this.ScaleAcceleration;
      this.Scale += this.ScaleVelocity;
    }

    public abstract void Draw(ref ParticleRendererSettings settings, SpriteBatch spritebatch);

    public bool IsRestingInPool { get; private set; }

    public void RestInPool() => this.IsRestingInPool = true;

    public virtual void FetchFromPool()
    {
      this.IsRestingInPool = false;
      this.ShouldBeRemovedFromRenderer = false;
      this.AccelerationPerFrame = Vector2.Zero;
      this.Velocity = Vector2.Zero;
      this.LocalPosition = Vector2.Zero;
      this._texture = (Asset<Texture2D>) null;
      this._frame = Rectangle.Empty;
      this._origin = Vector2.Zero;
      this.Rotation = 0.0f;
      this.RotationVelocity = 0.0f;
      this.RotationAcceleration = 0.0f;
      this.Scale = Vector2.Zero;
      this.ScaleVelocity = Vector2.Zero;
      this.ScaleAcceleration = Vector2.Zero;
    }
  }
}
