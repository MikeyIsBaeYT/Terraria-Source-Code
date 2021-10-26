// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.ShapeData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;

namespace Terraria.WorldBuilding
{
  public class ShapeData
  {
    private HashSet<Point16> _points;

    public int Count => this._points.Count;

    public ShapeData() => this._points = new HashSet<Point16>();

    public ShapeData(ShapeData original) => this._points = new HashSet<Point16>((IEnumerable<Point16>) original._points);

    public void Add(int x, int y) => this._points.Add(new Point16(x, y));

    public void Remove(int x, int y) => this._points.Remove(new Point16(x, y));

    public HashSet<Point16> GetData() => this._points;

    public void Clear() => this._points.Clear();

    public bool Contains(int x, int y) => this._points.Contains(new Point16(x, y));

    public void Add(ShapeData shapeData, Point localOrigin, Point remoteOrigin)
    {
      foreach (Point16 point16 in shapeData.GetData())
        this.Add(remoteOrigin.X - localOrigin.X + (int) point16.X, remoteOrigin.Y - localOrigin.Y + (int) point16.Y);
    }

    public void Subtract(ShapeData shapeData, Point localOrigin, Point remoteOrigin)
    {
      foreach (Point16 point16 in shapeData.GetData())
        this.Remove(remoteOrigin.X - localOrigin.X + (int) point16.X, remoteOrigin.Y - localOrigin.Y + (int) point16.Y);
    }

    public static Microsoft.Xna.Framework.Rectangle GetBounds(
      Point origin,
      params ShapeData[] shapes)
    {
      int val1_1 = (int) shapes[0]._points.First<Point16>().X;
      int val1_2 = val1_1;
      int val1_3 = (int) shapes[0]._points.First<Point16>().Y;
      int val1_4 = val1_3;
      for (int index = 0; index < shapes.Length; ++index)
      {
        foreach (Point16 point in shapes[index]._points)
        {
          val1_1 = Math.Max(val1_1, (int) point.X);
          val1_2 = Math.Min(val1_2, (int) point.X);
          val1_3 = Math.Max(val1_3, (int) point.Y);
          val1_4 = Math.Min(val1_4, (int) point.Y);
        }
      }
      return new Microsoft.Xna.Framework.Rectangle(val1_2 + origin.X, val1_4 + origin.Y, val1_1 - val1_2, val1_3 - val1_4);
    }
  }
}
