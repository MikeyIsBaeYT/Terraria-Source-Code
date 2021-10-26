// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.PrettySparkleParticle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Terraria.Graphics.Renderers
{
  public class PrettySparkleParticle : ABasicParticle
  {
    public Color ColorTint;
    public float Opacity;
    private float _timeSinceSpawn;

    public override void FetchFromPool()
    {
      base.FetchFromPool();
      this.ColorTint = Color.Transparent;
      this._timeSinceSpawn = 0.0f;
      this.Opacity = 0.0f;
    }

    public override void Update(ref ParticleRendererSettings settings)
    {
      base.Update(ref settings);
      ++this._timeSinceSpawn;
      this.Opacity = Utils.GetLerpValue(0.0f, 0.05f, this._timeSinceSpawn / 60f, true) * Utils.GetLerpValue(1f, 0.9f, this._timeSinceSpawn / 60f, true);
      if ((double) this._timeSinceSpawn < 60.0)
        return;
      this.ShouldBeRemovedFromRenderer = true;
    }

    public override void Draw(ref ParticleRendererSettings settings, SpriteBatch spritebatch)
    {
      Color color1 = Color.White * this.Opacity * 0.9f;
      color1.A /= (byte) 2;
      Texture2D texture2D = TextureAssets.Extra[98].Value;
      Color color2 = this.ColorTint * this.Opacity * 0.5f;
      color2.A = (byte) 0;
      Vector2 origin = texture2D.Size() / 2f;
      Color color3 = color1 * 0.5f;
      float num = Utils.GetLerpValue(0.0f, 20f, this._timeSinceSpawn, true) * Utils.GetLerpValue(45f, 30f, this._timeSinceSpawn, true);
      Vector2 scale1 = new Vector2(0.3f, 2f) * num * this.Scale;
      Vector2 scale2 = new Vector2(0.3f, 1f) * num * this.Scale;
      Color color4 = color2 * num;
      Color color5 = color3 * num;
      Vector2 position = settings.AnchorPosition + this.LocalPosition;
      SpriteEffects effects = SpriteEffects.None;
      spritebatch.Draw(texture2D, position, new Rectangle?(), color4, 1.570796f + this.Rotation, origin, scale1, effects, 0.0f);
      spritebatch.Draw(texture2D, position, new Rectangle?(), color4, 0.0f + this.Rotation, origin, scale2, effects, 0.0f);
      spritebatch.Draw(texture2D, position, new Rectangle?(), color5, 1.570796f + this.Rotation, origin, scale1 * 0.6f, effects, 0.0f);
      spritebatch.Draw(texture2D, position, new Rectangle?(), color5, 0.0f + this.Rotation, origin, scale2 * 0.6f, effects, 0.0f);
    }
  }
}
