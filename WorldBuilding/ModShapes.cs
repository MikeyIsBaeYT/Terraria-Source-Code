// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.ModShapes
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria.WorldBuilding
{
  public static class ModShapes
  {
    public class All : GenModShape
    {
      public All(ShapeData data)
        : base(data)
      {
      }

      public override bool Perform(Point origin, GenAction action)
      {
        foreach (Point16 point16 in this._data.GetData())
        {
          if (!this.UnitApply(action, origin, (int) point16.X + origin.X, (int) point16.Y + origin.Y) && this._quitOnFail)
            return false;
        }
        return true;
      }
    }

    public class OuterOutline : GenModShape
    {
      private static readonly int[] POINT_OFFSETS = new int[16]
      {
        1,
        0,
        -1,
        0,
        0,
        1,
        0,
        -1,
        1,
        1,
        1,
        -1,
        -1,
        1,
        -1,
        -1
      };
      private bool _useDiagonals;
      private bool _useInterior;

      public OuterOutline(ShapeData data, bool useDiagonals = true, bool useInterior = false)
        : base(data)
      {
        this._useDiagonals = useDiagonals;
        this._useInterior = useInterior;
      }

      public override bool Perform(Point origin, GenAction action)
      {
        int num = this._useDiagonals ? 16 : 8;
        foreach (Point16 point16 in this._data.GetData())
        {
          if (this._useInterior && !this.UnitApply(action, origin, (int) point16.X + origin.X, (int) point16.Y + origin.Y) && this._quitOnFail)
            return false;
          for (int index = 0; index < num; index += 2)
          {
            if (!this._data.Contains((int) point16.X + ModShapes.OuterOutline.POINT_OFFSETS[index], (int) point16.Y + ModShapes.OuterOutline.POINT_OFFSETS[index + 1]) && !this.UnitApply(action, origin, origin.X + (int) point16.X + ModShapes.OuterOutline.POINT_OFFSETS[index], origin.Y + (int) point16.Y + ModShapes.OuterOutline.POINT_OFFSETS[index + 1]) && this._quitOnFail)
              return false;
          }
        }
        return true;
      }
    }

    public class InnerOutline : GenModShape
    {
      private static readonly int[] POINT_OFFSETS = new int[16]
      {
        1,
        0,
        -1,
        0,
        0,
        1,
        0,
        -1,
        1,
        1,
        1,
        -1,
        -1,
        1,
        -1,
        -1
      };
      private bool _useDiagonals;

      public InnerOutline(ShapeData data, bool useDiagonals = true)
        : base(data)
      {
        this._useDiagonals = useDiagonals;
      }

      public override bool Perform(Point origin, GenAction action)
      {
        int num = this._useDiagonals ? 16 : 8;
        foreach (Point16 point16 in this._data.GetData())
        {
          bool flag = false;
          for (int index = 0; index < num; index += 2)
          {
            if (!this._data.Contains((int) point16.X + ModShapes.InnerOutline.POINT_OFFSETS[index], (int) point16.Y + ModShapes.InnerOutline.POINT_OFFSETS[index + 1]))
            {
              flag = true;
              break;
            }
          }
          if (flag && !this.UnitApply(action, origin, (int) point16.X + origin.X, (int) point16.Y + origin.Y) && this._quitOnFail)
            return false;
        }
        return true;
      }
    }
  }
}
