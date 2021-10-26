// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.ParticlePool`1
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.Graphics.Renderers
{
  public class ParticlePool<T> where T : IPooledParticle
  {
    private ParticlePool<T>.ParticleInstantiator _instantiator;
    private List<T> _particles;

    public ParticlePool(int initialPoolSize, ParticlePool<T>.ParticleInstantiator instantiator)
    {
      this._particles = new List<T>(initialPoolSize);
      this._instantiator = instantiator;
    }

    public T RequestParticle()
    {
      int count = this._particles.Count;
      for (int index = 0; index < count; ++index)
      {
        T particle = this._particles[index];
        if (particle.IsRestingInPool)
        {
          particle = this._particles[index];
          particle.FetchFromPool();
          return this._particles[index];
        }
      }
      T obj = this._instantiator();
      this._particles.Add(obj);
      obj.FetchFromPool();
      return obj;
    }

    public delegate T ParticleInstantiator() where T : IPooledParticle;
  }
}
