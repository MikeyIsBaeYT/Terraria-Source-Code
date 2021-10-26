// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.FadingParticle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Renderers
{
  public class FadingParticle : ABasicParticle
  {
    public float FadeInNormalizedTime;
    public float FadeOutNormalizedTime = 1f;
    public Color ColorTint = Color.White;
    private float _timeTolive;
    private float _timeSinceSpawn;

    public override void FetchFromPool()
    {
      base.FetchFromPool();
      this.FadeInNormalizedTime = 0.0f;
      this.FadeOutNormalizedTime = 1f;
      this.ColorTint = Color.White;
      this._timeTolive = 0.0f;
      this._timeSinceSpawn = 0.0f;
    }

    public void SetTypeInfo(float timeToLive) => this._timeTolive = timeToLive;

    public override void Update(ref ParticleRendererSettings settings)
    {
      base.Update(ref settings);
      ++this._timeSinceSpawn;
      if ((double) this._timeSinceSpawn < (double) this._timeTolive)
        return;
      this.ShouldBeRemovedFromRenderer = true;
    }

    public override void Draw(ref ParticleRendererSettings settings, SpriteBatch spritebatch)
    {
      Color color = this.ColorTint * Utils.GetLerpValue(0.0f, this.FadeInNormalizedTime, this._timeSinceSpawn / this._timeTolive, true) * Utils.GetLerpValue(1f, this.FadeOutNormalizedTime, this._timeSinceSpawn / this._timeTolive, true);
      spritebatch.Draw(this._texture.Value, settings.AnchorPosition + this.LocalPosition, new Rectangle?(this._frame), color, this.Rotation, this._origin, this.Scale, SpriteEffects.None, 0.0f);
    }
  }
}
