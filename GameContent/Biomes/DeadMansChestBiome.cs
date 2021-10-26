// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.DeadMansChestBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class DeadMansChestBiome : MicroBiome
  {
    private List<DeadMansChestBiome.DartTrapPlacementAttempt> _dartTrapPlacementSpots = new List<DeadMansChestBiome.DartTrapPlacementAttempt>();
    private List<DeadMansChestBiome.WirePlacementAttempt> _wirePlacementSpots = new List<DeadMansChestBiome.WirePlacementAttempt>();
    private List<DeadMansChestBiome.BoulderPlacementAttempt> _boulderPlacementSpots = new List<DeadMansChestBiome.BoulderPlacementAttempt>();
    private List<DeadMansChestBiome.ExplosivePlacementAttempt> _explosivePlacementAttempt = new List<DeadMansChestBiome.ExplosivePlacementAttempt>();
    [JsonProperty("NumberOfDartTraps")]
    private IntRange _numberOfDartTraps = new IntRange(3, 6);
    [JsonProperty("NumberOfBoulderTraps")]
    private IntRange _numberOfBoulderTraps = new IntRange(2, 4);
    [JsonProperty("NumberOfStepsBetweenBoulderTraps")]
    private IntRange _numberOfStepsBetweenBoulderTraps = new IntRange(2, 4);

    public override bool Place(Point origin, StructureMap structures)
    {
      if (!DeadMansChestBiome.IsAGoodSpot(origin))
        return false;
      this.ClearCaches();
      Point position = new Point(origin.X, origin.Y + 1);
      this.FindBoulderTrapSpots(position);
      this.FindDartTrapSpots(position);
      this.FindExplosiveTrapSpots(position);
      if (!this.AreThereEnoughTraps())
        return false;
      this.TurnGoldChestIntoDeadMansChest(origin);
      foreach (DeadMansChestBiome.DartTrapPlacementAttempt trapPlacementSpot in this._dartTrapPlacementSpots)
        this.ActuallyPlaceDartTrap(trapPlacementSpot.position, trapPlacementSpot.directionX, trapPlacementSpot.x, trapPlacementSpot.y, trapPlacementSpot.xPush, trapPlacementSpot.t);
      foreach (DeadMansChestBiome.WirePlacementAttempt wirePlacementSpot in this._wirePlacementSpots)
        this.PlaceWireLine(wirePlacementSpot.position, wirePlacementSpot.dirX, wirePlacementSpot.dirY, wirePlacementSpot.steps);
      foreach (DeadMansChestBiome.BoulderPlacementAttempt boulderPlacementSpot in this._boulderPlacementSpots)
        this.ActuallyPlaceBoulderTrap(boulderPlacementSpot.position, boulderPlacementSpot.yPush, boulderPlacementSpot.requiredHeight, boulderPlacementSpot.bestType);
      foreach (DeadMansChestBiome.ExplosivePlacementAttempt placementAttempt in this._explosivePlacementAttempt)
        this.ActuallyPlaceExplosive(placementAttempt.position);
      this.PlaceWiresForExplosives(origin);
      return true;
    }

    private void PlaceWiresForExplosives(Point origin)
    {
      if (this._explosivePlacementAttempt.Count <= 0)
        return;
      this.PlaceWireLine(origin, 0, 1, this._explosivePlacementAttempt[0].position.Y - origin.Y);
      int x1 = this._explosivePlacementAttempt[0].position.X;
      int num = this._explosivePlacementAttempt[0].position.X;
      int y = this._explosivePlacementAttempt[0].position.Y;
      for (int index = 1; index < this._explosivePlacementAttempt.Count; ++index)
      {
        int x2 = this._explosivePlacementAttempt[index].position.X;
        if (x1 > x2)
          x1 = x2;
        if (num < x2)
          num = x2;
      }
      this.PlaceWireLine(new Point(x1, y), 1, 0, num - x1);
    }

    private bool AreThereEnoughTraps() => (this._boulderPlacementSpots.Count >= 1 || this._explosivePlacementAttempt.Count >= 1) && this._dartTrapPlacementSpots.Count >= 1;

    private void ClearCaches()
    {
      this._dartTrapPlacementSpots.Clear();
      this._wirePlacementSpots.Clear();
      this._boulderPlacementSpots.Clear();
      this._explosivePlacementAttempt.Clear();
    }

    private void FindBoulderTrapSpots(Point position)
    {
      int x1 = position.X;
      int num1 = GenBase._random.Next(this._numberOfBoulderTraps);
      int num2 = GenBase._random.Next(this._numberOfStepsBetweenBoulderTraps);
      int x2 = x1 - num1 / 2 * num2;
      int y = position.Y - 6;
      for (int index = 0; index <= num1; ++index)
      {
        this.FindBoulderTrapSpot(new Point(x2, y));
        x2 += num2;
      }
      if (this._boulderPlacementSpots.Count <= 0)
        return;
      int x3 = this._boulderPlacementSpots[0].position.X;
      int num3 = this._boulderPlacementSpots[0].position.X;
      for (int index = 1; index < this._boulderPlacementSpots.Count; ++index)
      {
        int x4 = this._boulderPlacementSpots[index].position.X;
        if (x3 > x4)
          x3 = x4;
        if (num3 < x4)
          num3 = x4;
      }
      if (x3 > position.X)
        x3 = position.X;
      if (num3 < position.X)
        num3 = position.X;
      this._wirePlacementSpots.Add(new DeadMansChestBiome.WirePlacementAttempt(new Point(x3, y - 1), 1, 0, num3 - x3));
      this._wirePlacementSpots.Add(new DeadMansChestBiome.WirePlacementAttempt(position, 0, -1, 7));
    }

    private void FindBoulderTrapSpot(Point position)
    {
      int x = position.X;
      int y = position.Y;
      for (int yPush = 0; yPush < 50; ++yPush)
      {
        if (Main.tile[x, y - yPush].active())
        {
          this.PlaceBoulderTrapSpot(new Point(x, y - yPush), yPush);
          break;
        }
      }
    }

    private void PlaceBoulderTrapSpot(Point position, int yPush)
    {
      int[] numArray = new int[623];
      for (int x = position.X; x < position.X + 2; ++x)
      {
        for (int index = position.Y - 4; index <= position.Y; ++index)
        {
          Tile tile = Main.tile[x, index];
          if (tile.active() && !Main.tileFrameImportant[(int) tile.type] && Main.tileSolid[(int) tile.type])
            ++numArray[(int) tile.type];
          if (tile.active() && !TileID.Sets.CanBeClearedDuringGeneration[(int) tile.type])
            return;
        }
      }
      for (int index1 = position.X - 1; index1 < position.X + 2 + 1; ++index1)
      {
        for (int index2 = position.Y - 4 - 1; index2 <= position.Y - 4 + 2; ++index2)
        {
          if (!Main.tile[index1, index2].active())
            return;
        }
      }
      int bestType = -1;
      for (int index = 0; index < numArray.Length; ++index)
      {
        if (bestType == -1 || numArray[bestType] < numArray[index])
          bestType = index;
      }
      this._boulderPlacementSpots.Add(new DeadMansChestBiome.BoulderPlacementAttempt(position, yPush - 1, 4, bestType));
    }

    private void FindDartTrapSpots(Point position)
    {
      int num1 = GenBase._random.Next(this._numberOfDartTraps);
      int directionX = GenBase._random.Next(2) == 0 ? -1 : 1;
      int steps = -1;
      for (int index = 0; index < num1; ++index)
      {
        int num2 = this.FindDartTrapSpotSingle(position, directionX) ? 1 : 0;
        directionX *= -1;
        --position.Y;
        if (num2 != 0)
          steps = index;
      }
      this._wirePlacementSpots.Add(new DeadMansChestBiome.WirePlacementAttempt(new Point(position.X, position.Y + num1), 0, -1, steps));
    }

    private bool FindDartTrapSpotSingle(Point position, int directionX)
    {
      int x = position.X;
      int y = position.Y;
      for (int xPush = 0; xPush < 20; ++xPush)
      {
        Tile t = Main.tile[x + xPush * directionX, y];
        if (t.type != (ushort) 467 && t.active() && Main.tileSolid[(int) t.type])
        {
          if (xPush < 5 || t.actuator() || Main.tileFrameImportant[(int) t.type] || !TileID.Sets.CanBeClearedDuringGeneration[(int) t.type])
            return false;
          this._dartTrapPlacementSpots.Add(new DeadMansChestBiome.DartTrapPlacementAttempt(position, directionX, x, y, xPush, t));
          return true;
        }
      }
      return false;
    }

    private void FindExplosiveTrapSpots(Point position)
    {
      int x1 = position.X;
      int y = position.Y + 3;
      List<int> intList = new List<int>();
      if (this.IsGoodSpotsForExplosive(x1, y))
        intList.Add(x1);
      int x2 = x1 + 1;
      if (this.IsGoodSpotsForExplosive(x2, y))
        intList.Add(x2);
      int x3 = -1;
      if (intList.Count > 0)
        x3 = intList[GenBase._random.Next(intList.Count)];
      intList.Clear();
      int num1 = x2 + GenBase._random.Next(2, 6);
      int num2 = 4;
      for (int x4 = num1; x4 < num1 + num2; ++x4)
      {
        if (this.IsGoodSpotsForExplosive(x4, y))
          intList.Add(x4);
      }
      int x5 = -1;
      if (intList.Count > 0)
        x5 = intList[GenBase._random.Next(intList.Count)];
      int num3 = position.X - num2 - GenBase._random.Next(2, 6);
      for (int x6 = num3; x6 < num3 + num2; ++x6)
      {
        if (this.IsGoodSpotsForExplosive(x6, y))
          intList.Add(x6);
      }
      int x7 = -1;
      if (intList.Count > 0)
        x7 = intList[GenBase._random.Next(intList.Count)];
      if (x7 != -1)
        this._explosivePlacementAttempt.Add(new DeadMansChestBiome.ExplosivePlacementAttempt(new Point(x7, y)));
      if (x3 != -1)
        this._explosivePlacementAttempt.Add(new DeadMansChestBiome.ExplosivePlacementAttempt(new Point(x3, y)));
      if (x5 == -1)
        return;
      this._explosivePlacementAttempt.Add(new DeadMansChestBiome.ExplosivePlacementAttempt(new Point(x5, y)));
    }

    private bool IsGoodSpotsForExplosive(int x, int y)
    {
      Tile tile = Main.tile[x, y];
      return tile.active() && Main.tileSolid[(int) tile.type] && !Main.tileFrameImportant[(int) tile.type] && !Main.tileSolidTop[(int) tile.type];
    }

    public List<int> GetPossibleChestsToTrapify(StructureMap structures)
    {
      List<int> intList = new List<int>();
      bool[] validTiles = new bool[TileID.Sets.GeneralPlacementTiles.Length];
      for (int index = 0; index < validTiles.Length; ++index)
        validTiles[index] = TileID.Sets.GeneralPlacementTiles[index];
      validTiles[21] = true;
      validTiles[467] = true;
      for (int index = 0; index < 8000; ++index)
      {
        Chest chest = Main.chest[index];
        if (chest != null)
        {
          Point position1 = new Point(chest.x, chest.y);
          if (DeadMansChestBiome.IsAGoodSpot(position1))
          {
            this.ClearCaches();
            Point position2 = new Point(position1.X, position1.Y + 1);
            this.FindBoulderTrapSpots(position2);
            this.FindDartTrapSpots(position2);
            if (this.AreThereEnoughTraps() && (structures == null || structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(position1.X, position1.Y, 1, 1), validTiles, 10)))
              intList.Add(index);
          }
        }
      }
      return intList;
    }

    private static bool IsAGoodSpot(Point position)
    {
      if (!WorldGen.InWorld(position.X, position.Y, 50) || WorldGen.oceanDepths(position.X, position.Y))
        return false;
      Tile tile1 = Main.tile[position.X, position.Y];
      if (tile1.type != (ushort) 21 || (int) tile1.frameX / 36 != 1)
        return false;
      Tile tile2 = Main.tile[position.X, position.Y + 2];
      return TileID.Sets.CanBeClearedDuringGeneration[(int) tile2.type] && WorldGen.countWires(position.X, position.Y, 20) <= 0 && WorldGen.countTiles(position.X, position.Y, lavaOk: true) >= 40;
    }

    private void TurnGoldChestIntoDeadMansChest(Point position)
    {
      for (int index1 = 0; index1 < 2; ++index1)
      {
        for (int index2 = 0; index2 < 2; ++index2)
        {
          int index3 = position.X + index1;
          int index4 = position.Y + index2;
          Tile tile = Main.tile[index3, index4];
          tile.type = (ushort) 467;
          tile.frameX = (short) (144 + index1 * 18);
          tile.frameY = (short) (index2 * 18);
        }
      }
      if (GenBase._random.Next(3) != 0)
        return;
      int chest = Chest.FindChest(position.X, position.Y);
      if (chest <= -1)
        return;
      Item[] objArray = Main.chest[chest].item;
      for (int index = objArray.Length - 2; index > 0; --index)
      {
        Item obj = objArray[index];
        if (obj.stack != 0)
          objArray[index + 1] = obj.DeepClone();
      }
      objArray[1] = new Item();
      objArray[1].SetDefaults(5007);
      Main.chest[chest].item = objArray;
    }

    private void ActuallyPlaceDartTrap(
      Point position,
      int directionX,
      int x,
      int y,
      int xPush,
      Tile t)
    {
      t.type = (ushort) 137;
      t.frameY = (short) 0;
      t.frameX = directionX != -1 ? (short) 0 : (short) 18;
      t.slope((byte) 0);
      t.halfBrick(false);
      WorldGen.TileFrame(x, y, true);
      this.PlaceWireLine(position, directionX, 0, xPush);
    }

    private void PlaceWireLine(Point start, int offsetX, int offsetY, int steps)
    {
      for (int index = 0; index <= steps; ++index)
        Main.tile[start.X + offsetX * index, start.Y + offsetY * index].wire(true);
    }

    private void ActuallyPlaceBoulderTrap(
      Point position,
      int yPush,
      int requiredHeight,
      int bestType)
    {
      for (int x = position.X; x < position.X + 2; ++x)
      {
        for (int j = position.Y - requiredHeight; j <= position.Y + 2; ++j)
        {
          Tile tile = Main.tile[x, j];
          if (j < position.Y - requiredHeight + 2)
            tile.ClearTile();
          else if (j <= position.Y)
          {
            if (!tile.active())
            {
              tile.active(true);
              tile.type = (ushort) bestType;
            }
            tile.slope((byte) 0);
            tile.halfBrick(false);
            tile.actuator(true);
            tile.wire(true);
            WorldGen.TileFrame(x, j, true);
          }
          else
            tile.ClearTile();
        }
      }
      int i = position.X + 1;
      int j1 = position.Y - requiredHeight + 1;
      int num1 = 3;
      int num2 = i - num1;
      int num3 = j1 - num1;
      int num4 = i + num1 - 1;
      int num5 = j1 + num1 - 1;
      for (int index1 = num2; index1 <= num4; ++index1)
      {
        for (int index2 = num3; index2 <= num5; ++index2)
        {
          if (Main.tile[index1, index2].type != (ushort) 138)
            Main.tile[index1, index2].type = (ushort) 1;
        }
      }
      WorldGen.PlaceTile(i, j1, 138);
      this.PlaceWireLine(position, 0, 1, yPush);
    }

    private void ActuallyPlaceExplosive(Point position)
    {
      Tile tile = Main.tile[position.X, position.Y];
      tile.type = (ushort) 141;
      int num1;
      short num2 = (short) (num1 = 0);
      tile.frameY = (short) num1;
      tile.frameX = num2;
      tile.slope((byte) 0);
      tile.halfBrick(false);
      WorldGen.TileFrame(position.X, position.Y, true);
    }

    private class DartTrapPlacementAttempt
    {
      public int directionX;
      public int xPush;
      public int x;
      public int y;
      public Point position;
      public Tile t;

      public DartTrapPlacementAttempt(
        Point position,
        int directionX,
        int x,
        int y,
        int xPush,
        Tile t)
      {
        this.position = position;
        this.directionX = directionX;
        this.x = x;
        this.y = y;
        this.xPush = xPush;
        this.t = t;
      }
    }

    private class BoulderPlacementAttempt
    {
      public Point position;
      public int yPush;
      public int requiredHeight;
      public int bestType;

      public BoulderPlacementAttempt(Point position, int yPush, int requiredHeight, int bestType)
      {
        this.position = position;
        this.yPush = yPush;
        this.requiredHeight = requiredHeight;
        this.bestType = bestType;
      }
    }

    private class WirePlacementAttempt
    {
      public Point position;
      public int dirX;
      public int dirY;
      public int steps;

      public WirePlacementAttempt(Point position, int dirX, int dirY, int steps)
      {
        this.position = position;
        this.dirX = dirX;
        this.dirY = dirY;
        this.steps = steps;
      }
    }

    private class ExplosivePlacementAttempt
    {
      public Point position;

      public ExplosivePlacementAttempt(Point position) => this.position = position;
    }
  }
}
