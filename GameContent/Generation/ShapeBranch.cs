// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ShapeBranch
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class ShapeBranch : GenShape
  {
    private Point _offset;
    private List<Point> _endPoints;

    public ShapeBranch() => this._offset = new Point(10, -5);

    public ShapeBranch(Point offset) => this._offset = offset;

    public ShapeBranch(double angle, double distance) => this._offset = new Point((int) (Math.Cos(angle) * distance), (int) (Math.Sin(angle) * distance));

    private bool PerformSegment(Point origin, GenAction action, Point start, Point end, int size)
    {
      size = Math.Max(1, size);
      for (int index1 = -(size >> 1); index1 < size - (size >> 1); ++index1)
      {
        for (int index2 = -(size >> 1); index2 < size - (size >> 1); ++index2)
        {
          if (!Utils.PlotLine(new Point(start.X + index1, start.Y + index2), end, (Utils.TileActionAttempt) ((tileX, tileY) => this.UnitApply(action, origin, tileX, tileY) || !this._quitOnFail), false))
            return false;
        }
      }
      return true;
    }

    public override bool Perform(Point origin, GenAction action)
    {
      float num1 = new Vector2((float) this._offset.X, (float) this._offset.Y).Length();
      int size = (int) ((double) num1 / 6.0);
      if (this._endPoints != null)
        this._endPoints.Add(new Point(origin.X + this._offset.X, origin.Y + this._offset.Y));
      if (!this.PerformSegment(origin, action, origin, new Point(origin.X + this._offset.X, origin.Y + this._offset.Y), size))
        return false;
      int num2 = (int) ((double) num1 / 8.0);
      for (int index = 0; index < num2; ++index)
      {
        float num3 = (float) (((double) index + 1.0) / ((double) num2 + 1.0));
        Point point1 = new Point((int) ((double) num3 * (double) this._offset.X), (int) ((double) num3 * (double) this._offset.Y));
        Vector2 spinningpoint = new Vector2((float) (this._offset.X - point1.X), (float) (this._offset.Y - point1.Y));
        spinningpoint = spinningpoint.RotatedBy((GenBase._random.NextDouble() * 0.5 + 1.0) * (GenBase._random.Next(2) == 0 ? -1.0 : 1.0)) * 0.75f;
        Point point2 = new Point((int) spinningpoint.X + point1.X, (int) spinningpoint.Y + point1.Y);
        if (this._endPoints != null)
          this._endPoints.Add(new Point(point2.X + origin.X, point2.Y + origin.Y));
        if (!this.PerformSegment(origin, action, new Point(point1.X + origin.X, point1.Y + origin.Y), new Point(point2.X + origin.X, point2.Y + origin.Y), size - 1))
          return false;
      }
      return true;
    }

    public ShapeBranch OutputEndpoints(List<Point> endpoints)
    {
      this._endPoints = endpoints;
      return this;
    }
  }
}
