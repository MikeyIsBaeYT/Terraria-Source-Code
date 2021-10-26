// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.ParticleRenderer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Terraria.Graphics.Renderers
{
  public class ParticleRenderer
  {
    public ParticleRendererSettings Settings;
    public List<IParticle> Particles = new List<IParticle>();

    public ParticleRenderer() => this.Settings = new ParticleRendererSettings();

    public void Add(IParticle particle) => this.Particles.Add(particle);

    public void Update()
    {
      for (int index = 0; index < this.Particles.Count; ++index)
      {
        if (this.Particles[index].ShouldBeRemovedFromRenderer)
        {
          if (this.Particles[index] is IPooledParticle particle3)
            particle3.RestInPool();
          this.Particles.RemoveAt(index);
          --index;
        }
        else
          this.Particles[index].Update(ref this.Settings);
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < this.Particles.Count; ++index)
      {
        if (!this.Particles[index].ShouldBeRemovedFromRenderer)
          this.Particles[index].Draw(ref this.Settings, spriteBatch);
      }
    }
  }
}
