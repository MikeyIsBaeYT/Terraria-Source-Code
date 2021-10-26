// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.HouseUtils
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public static class HouseUtils
  {
    private static readonly bool[] BlacklistedTiles = TileID.Sets.Factory.CreateBoolSet(true, 225, 41, 43, 44, 226, 203, 112, 25, 151);
    private static readonly bool[] BeelistedTiles = TileID.Sets.Factory.CreateBoolSet(true, 41, 43, 44, 226, 203, 112, 25, 151);

    public static HouseBuilder CreateBuilder(Point origin, StructureMap structures)
    {
      List<Microsoft.Xna.Framework.Rectangle> rooms = HouseUtils.CreateRooms(origin);
      if (rooms.Count == 0 || !HouseUtils.AreRoomLocationsValid((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms))
        return HouseBuilder.Invalid;
      HouseType houseType = HouseUtils.GetHouseType((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
      if (!HouseUtils.AreRoomsValid((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms, structures, houseType))
        return HouseBuilder.Invalid;
      switch (houseType)
      {
        case HouseType.Wood:
          return (HouseBuilder) new WoodHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        case HouseType.Ice:
          return (HouseBuilder) new IceHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        case HouseType.Desert:
          return (HouseBuilder) new DesertHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        case HouseType.Jungle:
          return (HouseBuilder) new JungleHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        case HouseType.Mushroom:
          return (HouseBuilder) new MushroomHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        case HouseType.Granite:
          return (HouseBuilder) new GraniteHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        case HouseType.Marble:
          return (HouseBuilder) new MarbleHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
        default:
          return (HouseBuilder) new WoodHouseBuilder((IEnumerable<Microsoft.Xna.Framework.Rectangle>) rooms);
      }
    }

    private static List<Microsoft.Xna.Framework.Rectangle> CreateRooms(Point origin)
    {
      Point result;
      if (!WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Down(200), (GenCondition) new Conditions.IsSolid()), out result) || result == origin)
        return new List<Microsoft.Xna.Framework.Rectangle>();
      Microsoft.Xna.Framework.Rectangle room1 = HouseUtils.FindRoom(result);
      Microsoft.Xna.Framework.Rectangle room2 = HouseUtils.FindRoom(new Point(room1.Center.X, room1.Y + 1));
      Microsoft.Xna.Framework.Rectangle room3 = HouseUtils.FindRoom(new Point(room1.Center.X, room1.Y + room1.Height + 10));
      room3.Y = room1.Y + room1.Height - 1;
      float roomSolidPrecentage1 = HouseUtils.GetRoomSolidPrecentage(room2);
      float roomSolidPrecentage2 = HouseUtils.GetRoomSolidPrecentage(room3);
      room1.Y += 3;
      room2.Y += 3;
      room3.Y += 3;
      List<Microsoft.Xna.Framework.Rectangle> rectangleList = new List<Microsoft.Xna.Framework.Rectangle>();
      if ((double) WorldGen.genRand.NextFloat() > (double) roomSolidPrecentage1 + 0.200000002980232)
        rectangleList.Add(room2);
      rectangleList.Add(room1);
      if ((double) WorldGen.genRand.NextFloat() > (double) roomSolidPrecentage2 + 0.200000002980232)
        rectangleList.Add(room3);
      return rectangleList;
    }

    private static Microsoft.Xna.Framework.Rectangle FindRoom(Point origin)
    {
      Point result1;
      bool flag1 = WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Left(25), (GenCondition) new Conditions.IsSolid()), out result1);
      Point result2;
      int num1 = WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Right(25), (GenCondition) new Conditions.IsSolid()), out result2) ? 1 : 0;
      if (!flag1)
        result1 = new Point(origin.X - 25, origin.Y);
      if (num1 == 0)
        result2 = new Point(origin.X + 25, origin.Y);
      Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(origin.X, origin.Y, 0, 0);
      if (origin.X - result1.X > result2.X - origin.X)
      {
        rectangle.X = result1.X;
        rectangle.Width = Utils.Clamp<int>(result2.X - result1.X, 15, 30);
      }
      else
      {
        rectangle.Width = Utils.Clamp<int>(result2.X - result1.X, 15, 30);
        rectangle.X = result2.X - rectangle.Width;
      }
      Point result3;
      bool flag2 = WorldUtils.Find(result1, Searches.Chain((GenSearch) new Searches.Up(10), (GenCondition) new Conditions.IsSolid()), out result3);
      Point result4;
      int num2 = WorldUtils.Find(result2, Searches.Chain((GenSearch) new Searches.Up(10), (GenCondition) new Conditions.IsSolid()), out result4) ? 1 : 0;
      if (!flag2)
        result3 = new Point(origin.X, origin.Y - 10);
      if (num2 == 0)
        result4 = new Point(origin.X, origin.Y - 10);
      rectangle.Height = Utils.Clamp<int>(Math.Max(origin.Y - result3.Y, origin.Y - result4.Y), 8, 12);
      rectangle.Y -= rectangle.Height;
      return rectangle;
    }

    private static float GetRoomSolidPrecentage(Microsoft.Xna.Framework.Rectangle room)
    {
      float num = (float) (room.Width * room.Height);
      Ref<int> count = new Ref<int>(0);
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Count(count)));
      return (float) count.Value / num;
    }

    private static int SortBiomeResults(Tuple<HouseType, int> item1, Tuple<HouseType, int> item2) => item2.Item2.CompareTo(item1.Item2);

    private static bool AreRoomLocationsValid(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
    {
      foreach (Microsoft.Xna.Framework.Rectangle room in rooms)
      {
        if (room.Y + room.Height > Main.maxTilesY - 220)
          return false;
      }
      return true;
    }

    private static HouseType GetHouseType(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
    {
      Dictionary<ushort, int> resultsOutput = new Dictionary<ushort, int>();
      foreach (Microsoft.Xna.Framework.Rectangle room in rooms)
        WorldUtils.Gen(new Point(room.X - 10, room.Y - 10), (GenShape) new Shapes.Rectangle(room.Width + 20, room.Height + 20), (GenAction) new Actions.TileScanner(new ushort[12]
        {
          (ushort) 0,
          (ushort) 59,
          (ushort) 147,
          (ushort) 1,
          (ushort) 161,
          (ushort) 53,
          (ushort) 396,
          (ushort) 397,
          (ushort) 368,
          (ushort) 367,
          (ushort) 60,
          (ushort) 70
        }).Output(resultsOutput));
      List<Tuple<HouseType, int>> tupleList = new List<Tuple<HouseType, int>>();
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Wood, resultsOutput[(ushort) 0] + resultsOutput[(ushort) 1]));
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Jungle, resultsOutput[(ushort) 59] + resultsOutput[(ushort) 60] * 10));
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Mushroom, resultsOutput[(ushort) 59] + resultsOutput[(ushort) 70] * 10));
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Ice, resultsOutput[(ushort) 147] + resultsOutput[(ushort) 161]));
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Desert, resultsOutput[(ushort) 397] + resultsOutput[(ushort) 396] + resultsOutput[(ushort) 53]));
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Granite, resultsOutput[(ushort) 368]));
      tupleList.Add(Tuple.Create<HouseType, int>(HouseType.Marble, resultsOutput[(ushort) 367]));
      tupleList.Sort(new Comparison<Tuple<HouseType, int>>(HouseUtils.SortBiomeResults));
      return tupleList[0].Item1;
    }

    private static bool AreRoomsValid(
      IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms,
      StructureMap structures,
      HouseType style)
    {
      foreach (Microsoft.Xna.Framework.Rectangle room in rooms)
      {
        if (style != HouseType.Granite)
        {
          if (WorldUtils.Find(new Point(room.X - 2, room.Y - 2), Searches.Chain(new Searches.Rectangle(room.Width + 4, room.Height + 4).RequireAll(false), (GenCondition) new Conditions.HasLava()), out Point _))
            return false;
        }
        if (WorldGen.notTheBees)
        {
          if (!structures.CanPlace(room, HouseUtils.BeelistedTiles, 5))
            return false;
        }
        else if (!structures.CanPlace(room, HouseUtils.BlacklistedTiles, 5))
          return false;
      }
      return true;
    }
  }
}
