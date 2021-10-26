// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.Point16
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public struct Point16
  {
    public readonly short X;
    public readonly short Y;
    public static Point16 Zero = new Point16(0, 0);
    public static Point16 NegativeOne = new Point16(-1, -1);

    public Point16(Point point)
    {
      this.X = (short) point.X;
      this.Y = (short) point.Y;
    }

    public Point16(int X, int Y)
    {
      this.X = (short) X;
      this.Y = (short) Y;
    }

    public Point16(short X, short Y)
    {
      this.X = X;
      this.Y = Y;
    }

    public static Point16 Max(int firstX, int firstY, int secondX, int secondY) => new Point16(firstX > secondX ? firstX : secondX, firstY > secondY ? firstY : secondY);

    public Point16 Max(int compareX, int compareY) => new Point16((int) this.X > compareX ? (int) this.X : compareX, (int) this.Y > compareY ? (int) this.Y : compareY);

    public Point16 Max(Point16 compareTo) => new Point16((int) this.X > (int) compareTo.X ? this.X : compareTo.X, (int) this.Y > (int) compareTo.Y ? this.Y : compareTo.Y);

    public static bool operator ==(Point16 first, Point16 second) => (int) first.X == (int) second.X && (int) first.Y == (int) second.Y;

    public static bool operator !=(Point16 first, Point16 second) => (int) first.X != (int) second.X || (int) first.Y != (int) second.Y;

    public override bool Equals(object obj)
    {
      Point16 point16 = (Point16) obj;
      return (int) this.X == (int) point16.X && (int) this.Y == (int) point16.Y;
    }

    public override int GetHashCode() => (int) this.X << 16 | (int) (ushort) this.Y;

    public override string ToString() => string.Format("{{{0}, {1}}}", (object) this.X, (object) this.Y);
  }
}
