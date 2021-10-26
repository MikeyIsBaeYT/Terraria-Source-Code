// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallCollisionEvent
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.Physics
{
  public struct BallCollisionEvent
  {
    public readonly Vector2 Normal;
    public readonly Vector2 ImpactPoint;
    public readonly Tile Tile;
    public readonly Entity Entity;
    public readonly float TimeScale;

    public BallCollisionEvent(
      float timeScale,
      Vector2 normal,
      Vector2 impactPoint,
      Tile tile,
      Entity entity)
    {
      this.Normal = normal;
      this.ImpactPoint = impactPoint;
      this.Tile = tile;
      this.Entity = entity;
      this.TimeScale = timeScale;
    }
  }
}
