// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.HouseBuilder
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public class HouseBuilder
  {
    private const int VERTICAL_EXIT_WIDTH = 3;
    public static readonly HouseBuilder Invalid = new HouseBuilder();
    public readonly HouseType Type;
    public readonly bool IsValid;
    protected ushort[] SkipTilesDuringWallAging = new ushort[5]
    {
      (ushort) 245,
      (ushort) 246,
      (ushort) 240,
      (ushort) 241,
      (ushort) 242
    };

    public float ChestChance { get; set; }

    public ushort TileType { get; protected set; }

    public ushort WallType { get; protected set; }

    public ushort BeamType { get; protected set; }

    public int PlatformStyle { get; protected set; }

    public int DoorStyle { get; protected set; }

    public int TableStyle { get; protected set; }

    public bool UsesTables2 { get; protected set; }

    public int WorkbenchStyle { get; protected set; }

    public int PianoStyle { get; protected set; }

    public int BookcaseStyle { get; protected set; }

    public int ChairStyle { get; protected set; }

    public int ChestStyle { get; protected set; }

    public ReadOnlyCollection<Microsoft.Xna.Framework.Rectangle> Rooms { get; private set; }

    public Microsoft.Xna.Framework.Rectangle TopRoom => this.Rooms.First<Microsoft.Xna.Framework.Rectangle>();

    public Microsoft.Xna.Framework.Rectangle BottomRoom => this.Rooms.Last<Microsoft.Xna.Framework.Rectangle>();

    private UnifiedRandom _random => WorldGen.genRand;

    private Tile[,] _tiles => Main.tile;

    private HouseBuilder() => this.IsValid = false;

    protected HouseBuilder(HouseType type, IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
    {
      this.Type = type;
      this.IsValid = true;
      List<Microsoft.Xna.Framework.Rectangle> list = rooms.ToList<Microsoft.Xna.Framework.Rectangle>();
      list.Sort((Comparison<Microsoft.Xna.Framework.Rectangle>) ((lhs, rhs) => lhs.Top.CompareTo(rhs.Top)));
      this.Rooms = list.AsReadOnly();
    }

    protected virtual void AgeRoom(Microsoft.Xna.Framework.Rectangle room)
    {
    }

    public void Place(HouseBuilderContext context, StructureMap structures)
    {
      this.PlaceEmptyRooms();
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
        structures.AddProtectedStructure(room, 8);
      this.PlaceStairs();
      this.PlaceDoors();
      this.PlacePlatforms();
      this.PlaceSupportBeams();
      this.FillRooms();
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
        this.AgeRoom(room);
      this.PlaceChests();
      this.PlaceBiomeSpecificTool(context);
    }

    private void PlaceEmptyRooms()
    {
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
      {
        WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Actions.SetTileKeepWall(this.TileType), (GenAction) new Actions.SetFrames(true)));
        WorldUtils.Gen(new Point(room.X + 1, room.Y + 1), (GenShape) new Shapes.Rectangle(room.Width - 2, room.Height - 2), Actions.Chain((GenAction) new Actions.ClearTile(true), (GenAction) new Actions.PlaceWall(this.WallType)));
      }
    }

    private void FillRooms()
    {
      int x1 = 14;
      if (this.UsesTables2)
        x1 = 469;
      Point[] pointArray = new Point[7]
      {
        new Point(x1, this.TableStyle),
        new Point(16, 0),
        new Point(18, this.WorkbenchStyle),
        new Point(86, 0),
        new Point(87, this.PianoStyle),
        new Point(94, 0),
        new Point(101, this.BookcaseStyle)
      };
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
      {
        int num1 = room.Width / 8;
        int num2 = room.Width / (num1 + 1);
        int num3 = this._random.Next(2);
        for (int index1 = 0; index1 < num1; ++index1)
        {
          int i = (index1 + 1) * num2 + room.X;
          switch (index1 + num3 % 2)
          {
            case 0:
              int j1 = room.Y + Math.Min(room.Height / 2, room.Height - 5);
              Vector2 vector2 = this.Type != HouseType.Desert ? WorldGen.randHousePicture() : WorldGen.RandHousePictureDesert();
              int x2 = (int) vector2.X;
              int y = (int) vector2.Y;
              WorldGen.PlaceTile(i, j1, x2, true, style: y);
              break;
            case 1:
              int j2 = room.Y + 1;
              WorldGen.PlaceTile(i, j2, 34, true, style: this._random.Next(6));
              for (int index2 = -1; index2 < 2; ++index2)
              {
                for (int index3 = 0; index3 < 3; ++index3)
                  this._tiles[index2 + i, index3 + j2].frameX += (short) 54;
              }
              break;
          }
        }
        int num4 = room.Width / 8 + 3;
        WorldGen.SetupStatueList();
        for (; num4 > 0; --num4)
        {
          int num5 = this._random.Next(room.Width - 3) + 1 + room.X;
          int num6 = room.Y + room.Height - 2;
          switch (this._random.Next(4))
          {
            case 0:
              WorldGen.PlaceSmallPile(num5, num6, this._random.Next(31, 34), 1);
              break;
            case 1:
              WorldGen.PlaceTile(num5, num6, 186, true, style: this._random.Next(22, 26));
              break;
            case 2:
              int index = this._random.Next(2, WorldGen.statueList.Length);
              WorldGen.PlaceTile(num5, num6, (int) WorldGen.statueList[index].X, true, style: ((int) WorldGen.statueList[index].Y));
              if (WorldGen.StatuesWithTraps.Contains(index))
              {
                WorldGen.PlaceStatueTrap(num5, num6);
                break;
              }
              break;
            case 3:
              Point point = Utils.SelectRandom<Point>(this._random, pointArray);
              WorldGen.PlaceTile(num5, num6, point.X, true, style: point.Y);
              break;
          }
        }
      }
    }

    private void PlaceStairs()
    {
      foreach (Tuple<Point, Point> stairs in this.CreateStairsList())
      {
        Point origin = stairs.Item1;
        Point point = stairs.Item2;
        int num = point.X > origin.X ? 1 : -1;
        ShapeData data = new ShapeData();
        for (int y = 0; y < point.Y - origin.Y; ++y)
          data.Add(num * (y + 1), y);
        WorldUtils.Gen(origin, (GenShape) new ModShapes.All(data), Actions.Chain((GenAction) new Actions.PlaceTile((ushort) 19, this.PlatformStyle), (GenAction) new Actions.SetSlope(num == 1 ? 1 : 2), (GenAction) new Actions.SetFrames(true)));
        WorldUtils.Gen(new Point(origin.X + (num == 1 ? 1 : -4), origin.Y - 1), (GenShape) new Shapes.Rectangle(4, 1), Actions.Chain((GenAction) new Actions.Clear(), (GenAction) new Actions.PlaceWall(this.WallType), (GenAction) new Actions.PlaceTile((ushort) 19, this.PlatformStyle), (GenAction) new Actions.SetFrames(true)));
      }
    }

    private List<Tuple<Point, Point>> CreateStairsList()
    {
      List<Tuple<Point, Point>> tupleList = new List<Tuple<Point, Point>>();
      for (int index = 1; index < this.Rooms.Count; ++index)
      {
        Microsoft.Xna.Framework.Rectangle room1 = this.Rooms[index];
        Microsoft.Xna.Framework.Rectangle room2 = this.Rooms[index - 1];
        if (room2.X - room1.X > room1.X + room1.Width - (room2.X + room2.Width))
          tupleList.Add(new Tuple<Point, Point>(new Point(room1.X + room1.Width - 1, room1.Y + 1), new Point(room1.X + room1.Width - room1.Height + 1, room1.Y + room1.Height - 1)));
        else
          tupleList.Add(new Tuple<Point, Point>(new Point(room1.X, room1.Y + 1), new Point(room1.X + room1.Height - 1, room1.Y + room1.Height - 1)));
      }
      return tupleList;
    }

    private void PlaceDoors()
    {
      foreach (Point door in this.CreateDoorList())
      {
        WorldUtils.Gen(door, (GenShape) new Shapes.Rectangle(1, 3), (GenAction) new Actions.ClearTile(true));
        WorldGen.PlaceTile(door.X, door.Y, 10, true, true, style: this.DoorStyle);
      }
    }

    private List<Point> CreateDoorList()
    {
      List<Point> pointList = new List<Point>();
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
      {
        int exitY;
        if (HouseBuilder.FindSideExit(new Microsoft.Xna.Framework.Rectangle(room.X + room.Width, room.Y + 1, 1, room.Height - 2), false, out exitY))
          pointList.Add(new Point(room.X + room.Width - 1, exitY));
        if (HouseBuilder.FindSideExit(new Microsoft.Xna.Framework.Rectangle(room.X, room.Y + 1, 1, room.Height - 2), true, out exitY))
          pointList.Add(new Point(room.X, exitY));
      }
      return pointList;
    }

    private void PlacePlatforms()
    {
      foreach (Point platforms in this.CreatePlatformsList())
        WorldUtils.Gen(platforms, (GenShape) new Shapes.Rectangle(3, 1), Actions.Chain((GenAction) new Actions.ClearMetadata(), (GenAction) new Actions.PlaceTile((ushort) 19, this.PlatformStyle), (GenAction) new Actions.SetFrames(true)));
    }

    private List<Point> CreatePlatformsList()
    {
      List<Point> pointList = new List<Point>();
      Microsoft.Xna.Framework.Rectangle topRoom = this.TopRoom;
      Microsoft.Xna.Framework.Rectangle bottomRoom = this.BottomRoom;
      int exitX;
      if (HouseBuilder.FindVerticalExit(new Microsoft.Xna.Framework.Rectangle(topRoom.X + 2, topRoom.Y, topRoom.Width - 4, 1), true, out exitX))
        pointList.Add(new Point(exitX, topRoom.Y));
      if (HouseBuilder.FindVerticalExit(new Microsoft.Xna.Framework.Rectangle(bottomRoom.X + 2, bottomRoom.Y + bottomRoom.Height - 1, bottomRoom.Width - 4, 1), false, out exitX))
        pointList.Add(new Point(exitX, bottomRoom.Y + bottomRoom.Height - 1));
      return pointList;
    }

    private void PlaceSupportBeams()
    {
      foreach (Microsoft.Xna.Framework.Rectangle supportBeam in this.CreateSupportBeamList())
      {
        if (supportBeam.Height > 1 && this._tiles[supportBeam.X, supportBeam.Y - 1].type != (ushort) 19)
        {
          WorldUtils.Gen(new Point(supportBeam.X, supportBeam.Y), (GenShape) new Shapes.Rectangle(supportBeam.Width, supportBeam.Height), Actions.Chain((GenAction) new Actions.SetTileKeepWall(this.BeamType), (GenAction) new Actions.SetFrames(true)));
          Tile tile = this._tiles[supportBeam.X, supportBeam.Y + supportBeam.Height];
          tile.slope((byte) 0);
          tile.halfBrick(false);
        }
      }
    }

    private List<Microsoft.Xna.Framework.Rectangle> CreateSupportBeamList()
    {
      List<Microsoft.Xna.Framework.Rectangle> rectangleList = new List<Microsoft.Xna.Framework.Rectangle>();
      int num1 = this.Rooms.Min<Microsoft.Xna.Framework.Rectangle>((Func<Microsoft.Xna.Framework.Rectangle, int>) (room => room.Left));
      int num2 = this.Rooms.Max<Microsoft.Xna.Framework.Rectangle>((Func<Microsoft.Xna.Framework.Rectangle, int>) (room => room.Right)) - 1;
      int num3 = 6;
      while (num3 > 4 && (num2 - num1) % num3 != 0)
        --num3;
      for (int x = num1; x <= num2; x += num3)
      {
        for (int index1 = 0; index1 < this.Rooms.Count; ++index1)
        {
          Microsoft.Xna.Framework.Rectangle room = this.Rooms[index1];
          if (x >= room.X && x < room.X + room.Width)
          {
            int y = room.Y + room.Height;
            int num4 = 50;
            for (int index2 = index1 + 1; index2 < this.Rooms.Count; ++index2)
            {
              if (x >= this.Rooms[index2].X && x < this.Rooms[index2].X + this.Rooms[index2].Width)
                num4 = Math.Min(num4, this.Rooms[index2].Y - y);
            }
            if (num4 > 0)
            {
              Point result;
              bool flag = WorldUtils.Find(new Point(x, y), Searches.Chain((GenSearch) new Searches.Down(num4), (GenCondition) new Conditions.IsSolid()), out result);
              if (num4 < 50)
              {
                flag = true;
                result = new Point(x, y + num4);
              }
              if (flag)
                rectangleList.Add(new Microsoft.Xna.Framework.Rectangle(x, y, 1, result.Y - y));
            }
          }
        }
      }
      return rectangleList;
    }

    private static bool FindVerticalExit(Microsoft.Xna.Framework.Rectangle wall, bool isUp, out int exitX)
    {
      Point result;
      int num = WorldUtils.Find(new Point(wall.X + wall.Width - 3, wall.Y + (isUp ? -5 : 0)), Searches.Chain((GenSearch) new Searches.Left(wall.Width - 3), new Conditions.IsSolid().Not().AreaOr(3, 5)), out result) ? 1 : 0;
      exitX = result.X;
      return num != 0;
    }

    private static bool FindSideExit(Microsoft.Xna.Framework.Rectangle wall, bool isLeft, out int exitY)
    {
      Point result;
      int num = WorldUtils.Find(new Point(wall.X + (isLeft ? -4 : 0), wall.Y + wall.Height - 3), Searches.Chain((GenSearch) new Searches.Up(wall.Height - 3), new Conditions.IsSolid().Not().AreaOr(4, 3)), out result) ? 1 : 0;
      exitY = result.Y;
      return num != 0;
    }

    private void PlaceChests()
    {
      if ((double) this._random.NextFloat() > (double) this.ChestChance)
        return;
      bool flag = false;
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
      {
        int j = room.Height - 1 + room.Y;
        int Style = j > (int) Main.worldSurface ? this.ChestStyle : 0;
        int num = 0;
        while (num < 10 && !(flag = WorldGen.AddBuriedChest(this._random.Next(2, room.Width - 2) + room.X, j, Style: Style)))
          ++num;
        if (!flag)
        {
          int i = room.X + 2;
          while (i <= room.X + room.Width - 2 && !(flag = WorldGen.AddBuriedChest(i, j, Style: Style)))
            ++i;
          if (flag)
            break;
        }
        else
          break;
      }
      if (!flag)
      {
        foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
        {
          int j = room.Y - 1;
          int Style = j > (int) Main.worldSurface ? this.ChestStyle : 0;
          int num = 0;
          while (num < 10 && !(flag = WorldGen.AddBuriedChest(this._random.Next(2, room.Width - 2) + room.X, j, Style: Style)))
            ++num;
          if (!flag)
          {
            int i = room.X + 2;
            while (i <= room.X + room.Width - 2 && !(flag = WorldGen.AddBuriedChest(i, j, Style: Style)))
              ++i;
            if (flag)
              break;
          }
          else
            break;
        }
      }
      if (flag)
        return;
      for (int index = 0; index < 1000; ++index)
      {
        int i = this._random.Next(this.Rooms[0].X - 30, this.Rooms[0].X + 30);
        int num1 = this._random.Next(this.Rooms[0].Y - 30, this.Rooms[0].Y + 30);
        int num2 = num1 > (int) Main.worldSurface ? this.ChestStyle : 0;
        int j = num1;
        int Style = num2;
        if (WorldGen.AddBuriedChest(i, j, Style: Style))
          break;
      }
    }

    private void PlaceBiomeSpecificTool(HouseBuilderContext context)
    {
      if (this.Type == HouseType.Jungle && context.SharpenerCount < this._random.Next(2, 5))
      {
        bool flag = false;
        foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
        {
          int j = room.Height - 2 + room.Y;
          for (int index = 0; index < 10; ++index)
          {
            int i = this._random.Next(2, room.Width - 2) + room.X;
            WorldGen.PlaceTile(i, j, 377, true, true);
            if (flag = this._tiles[i, j].active() && this._tiles[i, j].type == (ushort) 377)
              break;
          }
          if (!flag)
          {
            int i = room.X + 2;
            while (i <= room.X + room.Width - 2 && !(flag = WorldGen.PlaceTile(i, j, 377, true, true)))
              ++i;
            if (flag)
              break;
          }
          else
            break;
        }
        if (flag)
          ++context.SharpenerCount;
      }
      if (this.Type != HouseType.Desert || context.ExtractinatorCount >= this._random.Next(2, 5))
        return;
      bool flag1 = false;
      foreach (Microsoft.Xna.Framework.Rectangle room in this.Rooms)
      {
        int j = room.Height - 2 + room.Y;
        for (int index = 0; index < 10; ++index)
        {
          int i = this._random.Next(2, room.Width - 2) + room.X;
          WorldGen.PlaceTile(i, j, 219, true, true);
          if (flag1 = this._tiles[i, j].active() && this._tiles[i, j].type == (ushort) 219)
            break;
        }
        if (!flag1)
        {
          int i = room.X + 2;
          while (i <= room.X + room.Width - 2 && !(flag1 = WorldGen.PlaceTile(i, j, 219, true, true)))
            ++i;
          if (flag1)
            break;
        }
        else
          break;
      }
      if (!flag1)
        return;
      ++context.ExtractinatorCount;
    }
  }
}
