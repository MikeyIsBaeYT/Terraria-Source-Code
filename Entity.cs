// Decompiled with JetBrains decompiler
// Type: Terraria.Entity
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public abstract class Entity
  {
    public int whoAmI;
    public bool active;
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 oldPosition;
    public Vector2 oldVelocity;
    public int oldDirection;
    public int direction = 1;
    public int width;
    public int height;
    public bool wet;
    public bool honeyWet;
    public byte wetCount;
    public bool lavaWet;

    public float AngleTo(Vector2 Destination) => (float) Math.Atan2((double) Destination.Y - (double) this.Center.Y, (double) Destination.X - (double) this.Center.X);

    public float AngleFrom(Vector2 Source) => (float) Math.Atan2((double) this.Center.Y - (double) Source.Y, (double) this.Center.X - (double) Source.X);

    public float Distance(Vector2 Other) => Vector2.Distance(this.Center, Other);

    public float DistanceSQ(Vector2 Other) => Vector2.DistanceSquared(this.Center, Other);

    public Vector2 DirectionTo(Vector2 Destination) => Vector2.Normalize(Destination - this.Center);

    public Vector2 DirectionFrom(Vector2 Source) => Vector2.Normalize(this.Center - Source);

    public bool WithinRange(Vector2 Target, float MaxRange) => (double) Vector2.DistanceSquared(this.Center, Target) <= (double) MaxRange * (double) MaxRange;

    public Vector2 Center
    {
      get => new Vector2(this.position.X + (float) (this.width / 2), this.position.Y + (float) (this.height / 2));
      set => this.position = new Vector2(value.X - (float) (this.width / 2), value.Y - (float) (this.height / 2));
    }

    public Vector2 Left
    {
      get => new Vector2(this.position.X, this.position.Y + (float) (this.height / 2));
      set => this.position = new Vector2(value.X, value.Y - (float) (this.height / 2));
    }

    public Vector2 Right
    {
      get => new Vector2(this.position.X + (float) this.width, this.position.Y + (float) (this.height / 2));
      set => this.position = new Vector2(value.X - (float) this.width, value.Y - (float) (this.height / 2));
    }

    public Vector2 Top
    {
      get => new Vector2(this.position.X + (float) (this.width / 2), this.position.Y);
      set => this.position = new Vector2(value.X - (float) (this.width / 2), value.Y);
    }

    public Vector2 TopLeft
    {
      get => this.position;
      set => this.position = value;
    }

    public Vector2 TopRight
    {
      get => new Vector2(this.position.X + (float) this.width, this.position.Y);
      set => this.position = new Vector2(value.X - (float) this.width, value.Y);
    }

    public Vector2 Bottom
    {
      get => new Vector2(this.position.X + (float) (this.width / 2), this.position.Y + (float) this.height);
      set => this.position = new Vector2(value.X - (float) (this.width / 2), value.Y - (float) this.height);
    }

    public Vector2 BottomLeft
    {
      get => new Vector2(this.position.X, this.position.Y + (float) this.height);
      set => this.position = new Vector2(value.X, value.Y - (float) this.height);
    }

    public Vector2 BottomRight
    {
      get => new Vector2(this.position.X + (float) this.width, this.position.Y + (float) this.height);
      set => this.position = new Vector2(value.X - (float) this.width, value.Y - (float) this.height);
    }

    public Vector2 Size
    {
      get => new Vector2((float) this.width, (float) this.height);
      set
      {
        this.width = (int) value.X;
        this.height = (int) value.Y;
      }
    }

    public Rectangle Hitbox
    {
      get => new Rectangle((int) this.position.X, (int) this.position.Y, this.width, this.height);
      set
      {
        this.position = new Vector2((float) value.X, (float) value.Y);
        this.width = value.Width;
        this.height = value.Height;
      }
    }
  }
}
