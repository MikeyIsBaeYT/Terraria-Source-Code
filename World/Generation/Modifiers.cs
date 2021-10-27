// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.Modifiers
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.World.Generation
{
  public static class Modifiers
  {
    public class ShapeScale : GenAction
    {
      private int _scale;

      public ShapeScale(int scale) => this._scale = scale;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        bool flag = false;
        for (int index1 = 0; index1 < this._scale; ++index1)
        {
          for (int index2 = 0; index2 < this._scale; ++index2)
            flag |= !this.UnitApply(origin, (x - origin.X << 1) + index1 + origin.X, (y - origin.Y << 1) + index2 + origin.Y);
        }
        return !flag;
      }
    }

    public class Expand : GenAction
    {
      private int _xExpansion;
      private int _yExpansion;

      public Expand(int expansion)
      {
        this._xExpansion = expansion;
        this._yExpansion = expansion;
      }

      public Expand(int xExpansion, int yExpansion)
      {
        this._xExpansion = xExpansion;
        this._yExpansion = yExpansion;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        bool flag = false;
        for (int index1 = -this._xExpansion; index1 <= this._xExpansion; ++index1)
        {
          for (int index2 = -this._yExpansion; index2 <= this._yExpansion; ++index2)
            flag |= !this.UnitApply(origin, x + index1, y + index2, args);
        }
        return !flag;
      }
    }

    public class RadialDither : GenAction
    {
      private float _innerRadius;
      private float _outerRadius;

      public RadialDither(float innerRadius, float outerRadius)
      {
        this._innerRadius = innerRadius;
        this._outerRadius = outerRadius;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        Vector2 vector2 = new Vector2((float) origin.X, (float) origin.Y);
        float num = Math.Max(0.0f, Math.Min(1f, (float) (((double) Vector2.Distance(new Vector2((float) x, (float) y), vector2) - (double) this._innerRadius) / ((double) this._outerRadius - (double) this._innerRadius))));
        return GenBase._random.NextDouble() > (double) num ? this.UnitApply(origin, x, y, args) : this.Fail();
      }
    }

    public class Blotches : GenAction
    {
      private int _minX;
      private int _minY;
      private int _maxX;
      private int _maxY;
      private double _chance;

      public Blotches(int scale = 2, double chance = 0.3)
      {
        this._minX = scale;
        this._minY = scale;
        this._maxX = scale;
        this._maxY = scale;
        this._chance = chance;
      }

      public Blotches(int xScale, int yScale, double chance = 0.3)
      {
        this._minX = xScale;
        this._maxX = xScale;
        this._minY = yScale;
        this._maxY = yScale;
        this._chance = chance;
      }

      public Blotches(int leftScale, int upScale, int rightScale, int downScale, double chance = 0.3)
      {
        this._minX = leftScale;
        this._maxX = rightScale;
        this._minY = upScale;
        this._maxY = downScale;
        this._chance = chance;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        GenBase._random.NextDouble();
        if (GenBase._random.NextDouble() >= this._chance)
          return this.UnitApply(origin, x, y, args);
        bool flag = false;
        int num1 = GenBase._random.Next(1 - this._minX, 1);
        int num2 = GenBase._random.Next(0, this._maxX);
        int num3 = GenBase._random.Next(1 - this._minY, 1);
        int num4 = GenBase._random.Next(0, this._maxY);
        for (int index1 = num1; index1 <= num2; ++index1)
        {
          for (int index2 = num3; index2 <= num4; ++index2)
            flag |= !this.UnitApply(origin, x + index1, y + index2, args);
        }
        return !flag;
      }
    }

    public class Conditions : GenAction
    {
      private GenCondition[] _conditions;

      public Conditions(params GenCondition[] conditions) => this._conditions = conditions;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        bool flag = true;
        for (int index = 0; index < this._conditions.Length; ++index)
          flag &= this._conditions[index].IsValid(x, y);
        return flag ? this.UnitApply(origin, x, y, args) : this.Fail();
      }
    }

    public class OnlyWalls : GenAction
    {
      private byte[] _types;

      public OnlyWalls(params byte[] types) => this._types = types;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        for (int index = 0; index < this._types.Length; ++index)
        {
          if ((int) GenBase._tiles[x, y].wall == (int) this._types[index])
            return this.UnitApply(origin, x, y, args);
        }
        return this.Fail();
      }
    }

    public class OnlyTiles : GenAction
    {
      private ushort[] _types;

      public OnlyTiles(params ushort[] types) => this._types = types;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        if (!GenBase._tiles[x, y].active())
          return this.Fail();
        for (int index = 0; index < this._types.Length; ++index)
        {
          if ((int) GenBase._tiles[x, y].type == (int) this._types[index])
            return this.UnitApply(origin, x, y, args);
        }
        return this.Fail();
      }
    }

    public class IsTouching : GenAction
    {
      private static readonly int[] DIRECTIONS = new int[16]
      {
        0,
        -1,
        1,
        0,
        -1,
        0,
        0,
        1,
        -1,
        -1,
        1,
        -1,
        -1,
        1,
        1,
        1
      };
      private bool _useDiagonals;
      private ushort[] _tileIds;

      public IsTouching(bool useDiagonals, params ushort[] tileIds)
      {
        this._useDiagonals = useDiagonals;
        this._tileIds = tileIds;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        int num = this._useDiagonals ? 16 : 8;
        for (int index1 = 0; index1 < num; index1 += 2)
        {
          Tile tile = GenBase._tiles[x + Modifiers.IsTouching.DIRECTIONS[index1], y + Modifiers.IsTouching.DIRECTIONS[index1 + 1]];
          if (tile.active())
          {
            for (int index2 = 0; index2 < this._tileIds.Length; ++index2)
            {
              if ((int) tile.type == (int) this._tileIds[index2])
                return this.UnitApply(origin, x, y, args);
            }
          }
        }
        return this.Fail();
      }
    }

    public class NotTouching : GenAction
    {
      private static readonly int[] DIRECTIONS = new int[16]
      {
        0,
        -1,
        1,
        0,
        -1,
        0,
        0,
        1,
        -1,
        -1,
        1,
        -1,
        -1,
        1,
        1,
        1
      };
      private bool _useDiagonals;
      private ushort[] _tileIds;

      public NotTouching(bool useDiagonals, params ushort[] tileIds)
      {
        this._useDiagonals = useDiagonals;
        this._tileIds = tileIds;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        int num = this._useDiagonals ? 16 : 8;
        for (int index1 = 0; index1 < num; index1 += 2)
        {
          Tile tile = GenBase._tiles[x + Modifiers.NotTouching.DIRECTIONS[index1], y + Modifiers.NotTouching.DIRECTIONS[index1 + 1]];
          if (tile.active())
          {
            for (int index2 = 0; index2 < this._tileIds.Length; ++index2)
            {
              if ((int) tile.type == (int) this._tileIds[index2])
                return this.Fail();
            }
          }
        }
        return this.UnitApply(origin, x, y, args);
      }
    }

    public class IsTouchingAir : GenAction
    {
      private static readonly int[] DIRECTIONS = new int[16]
      {
        0,
        -1,
        1,
        0,
        -1,
        0,
        0,
        1,
        -1,
        -1,
        1,
        -1,
        -1,
        1,
        1,
        1
      };
      private bool _useDiagonals;

      public IsTouchingAir(bool useDiagonals = false) => this._useDiagonals = useDiagonals;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        int num = this._useDiagonals ? 16 : 8;
        for (int index = 0; index < num; index += 2)
        {
          if (!GenBase._tiles[x + Modifiers.IsTouchingAir.DIRECTIONS[index], y + Modifiers.IsTouchingAir.DIRECTIONS[index + 1]].active())
            return this.UnitApply(origin, x, y, args);
        }
        return this.Fail();
      }
    }

    public class SkipTiles : GenAction
    {
      private ushort[] _types;

      public SkipTiles(params ushort[] types) => this._types = types;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        if (!GenBase._tiles[x, y].active())
          return this.UnitApply(origin, x, y, args);
        for (int index = 0; index < this._types.Length; ++index)
        {
          if ((int) GenBase._tiles[x, y].type == (int) this._types[index])
            return this.Fail();
        }
        return this.UnitApply(origin, x, y, args);
      }
    }

    public class HasLiquid : GenAction
    {
      private int _liquidType;
      private int _liquidLevel;

      public HasLiquid(int liquidLevel = -1, int liquidType = -1)
      {
        this._liquidLevel = liquidLevel;
        this._liquidType = liquidType;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        Tile tile = GenBase._tiles[x, y];
        return (this._liquidType == -1 || this._liquidType == (int) tile.liquidType()) && (this._liquidLevel == -1 && tile.liquid != (byte) 0 || this._liquidLevel == (int) tile.liquid) ? this.UnitApply(origin, x, y, args) : this.Fail();
      }
    }

    public class SkipWalls : GenAction
    {
      private byte[] _types;

      public SkipWalls(params byte[] types) => this._types = types;

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        for (int index = 0; index < this._types.Length; ++index)
        {
          if ((int) GenBase._tiles[x, y].wall == (int) this._types[index])
            return this.Fail();
        }
        return this.UnitApply(origin, x, y, args);
      }
    }

    public class IsEmpty : GenAction
    {
      public override bool Apply(Point origin, int x, int y, params object[] args) => !GenBase._tiles[x, y].active() ? this.UnitApply(origin, x, y, args) : this.Fail();
    }

    public class IsSolid : GenAction
    {
      public override bool Apply(Point origin, int x, int y, params object[] args) => GenBase._tiles[x, y].active() && WorldGen.SolidTile(x, y) ? this.UnitApply(origin, x, y, args) : this.Fail();
    }

    public class IsNotSolid : GenAction
    {
      public override bool Apply(Point origin, int x, int y, params object[] args) => !GenBase._tiles[x, y].active() || !WorldGen.SolidTile(x, y) ? this.UnitApply(origin, x, y, args) : this.Fail();
    }

    public class RectangleMask : GenAction
    {
      private int _xMin;
      private int _yMin;
      private int _xMax;
      private int _yMax;

      public RectangleMask(int xMin, int xMax, int yMin, int yMax)
      {
        this._xMin = xMin;
        this._yMin = yMin;
        this._xMax = xMax;
        this._yMax = yMax;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args) => x >= this._xMin + origin.X && x <= this._xMax + origin.X && y >= this._yMin + origin.Y && y <= this._yMax + origin.Y ? this.UnitApply(origin, x, y, args) : this.Fail();
    }

    public class Offset : GenAction
    {
      private int _xOffset;
      private int _yOffset;

      public Offset(int x, int y)
      {
        this._xOffset = x;
        this._yOffset = y;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args) => this.UnitApply(origin, x + this._xOffset, y + this._yOffset, args);
    }

    public class Dither : GenAction
    {
      private double _failureChance;

      public Dither(double failureChance = 0.5) => this._failureChance = failureChance;

      public override bool Apply(Point origin, int x, int y, params object[] args) => GenBase._random.NextDouble() >= this._failureChance ? this.UnitApply(origin, x, y, args) : this.Fail();
    }

    public class Flip : GenAction
    {
      private bool _flipX;
      private bool _flipY;

      public Flip(bool flipX, bool flipY)
      {
        this._flipX = flipX;
        this._flipY = flipY;
      }

      public override bool Apply(Point origin, int x, int y, params object[] args)
      {
        if (this._flipX)
          x = origin.X * 2 - x;
        if (this._flipY)
          y = origin.Y * 2 - y;
        return this.UnitApply(origin, x, y, args);
      }
    }
  }
}
