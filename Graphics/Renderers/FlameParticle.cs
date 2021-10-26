// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.FlameParticle
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.DataStructures;

namespace Terraria.Graphics.Renderers
{
  public class FlameParticle : ABasicParticle
  {
    public float FadeOutNormalizedTime = 1f;
    private float _timeTolive;
    private float _timeSinceSpawn;
    private int _indexOfPlayerWhoSpawnedThis;
    private int _packedShaderIndex;

    public override void FetchFromPool()
    {
      base.FetchFromPool();
      this.FadeOutNormalizedTime = 1f;
      this._timeTolive = 0.0f;
      this._timeSinceSpawn = 0.0f;
      this._indexOfPlayerWhoSpawnedThis = 0;
      this._packedShaderIndex = 0;
    }

    public override void SetBasicInfo(
      Asset<Texture2D> textureAsset,
      Rectangle? frame,
      Vector2 initialVelocity,
      Vector2 initialLocalPosition)
    {
      base.SetBasicInfo(textureAsset, frame, initialVelocity, initialLocalPosition);
      this._origin = new Vector2((float) (this._frame.Width / 2), (float) (this._frame.Height - 2));
    }

    public void SetTypeInfo(float timeToLive, int indexOfPlayerWhoSpawnedIt, int packedShaderIndex)
    {
      this._timeTolive = timeToLive;
      this._indexOfPlayerWhoSpawnedThis = indexOfPlayerWhoSpawnedIt;
      this._packedShaderIndex = packedShaderIndex;
    }

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
      Color color = new Color(120, 120, 120, 60) * Utils.GetLerpValue(1f, this.FadeOutNormalizedTime, this._timeSinceSpawn / this._timeTolive, true);
      Vector2 vector2_1 = settings.AnchorPosition + this.LocalPosition;
      ulong seed = Main.TileFrameSeed ^ ((ulong) this.LocalPosition.X << 32 | (ulong) (uint) this.LocalPosition.Y);
      Player player = Main.player[this._indexOfPlayerWhoSpawnedThis];
      for (int index = 0; index < 4; ++index)
      {
        Vector2 vector2_2 = new Vector2((float) Utils.RandomInt(ref seed, -2, 3), (float) Utils.RandomInt(ref seed, -2, 3));
        DrawData cdd = new DrawData(this._texture.Value, vector2_1 + vector2_2 * this.Scale, new Rectangle?(this._frame), color, this.Rotation, this._origin, this.Scale, SpriteEffects.None, 0)
        {
          shader = this._packedShaderIndex
        };
        PlayerDrawHelper.SetShaderForData(player, 0, ref cdd);
        cdd.Draw(spritebatch);
      }
      Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }
  }
}
