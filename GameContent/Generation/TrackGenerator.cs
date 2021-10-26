// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.TrackGenerator
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria.ID;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class TrackGenerator
  {
    private static readonly ushort[] InvalidWalls = new ushort[20]
    {
      (ushort) 7,
      (ushort) 94,
      (ushort) 95,
      (ushort) 8,
      (ushort) 98,
      (ushort) 99,
      (ushort) 9,
      (ushort) 96,
      (ushort) 97,
      (ushort) 3,
      (ushort) 83,
      (ushort) 68,
      (ushort) 62,
      (ushort) 78,
      (ushort) 87,
      (ushort) 86,
      (ushort) 42,
      (ushort) 74,
      (ushort) 27,
      (ushort) 149
    };
    private static readonly ushort[] InvalidTiles = new ushort[22]
    {
      (ushort) 383,
      (ushort) 384,
      (ushort) 15,
      (ushort) 304,
      (ushort) 30,
      (ushort) 321,
      (ushort) 245,
      (ushort) 246,
      (ushort) 240,
      (ushort) 241,
      (ushort) 242,
      (ushort) 16,
      (ushort) 34,
      (ushort) 158,
      (ushort) 377,
      (ushort) 94,
      (ushort) 10,
      (ushort) 19,
      (ushort) 86,
      (ushort) 219,
      (ushort) 484,
      (ushort) 190
    };
    private readonly TrackGenerator.TrackHistory[] _history = new TrackGenerator.TrackHistory[4096];
    private readonly TrackGenerator.TrackHistory[] _rewriteHistory = new TrackGenerator.TrackHistory[25];
    private int _xDirection;
    private int _length;
    private int playerHeight = 6;

    public bool Place(Point origin, int minLength, int maxLength)
    {
      if (!TrackGenerator.FindSuitableOrigin(ref origin))
        return false;
      this.CreateTrackStart(origin);
      if (!this.FindPath(minLength, maxLength))
        return false;
      this.PlacePath();
      return true;
    }

    private void PlacePath()
    {
      bool[] flagArray = new bool[this._length];
      for (int index1 = 0; index1 < this._length; ++index1)
      {
        if (WorldGen.genRand.Next(7) == 0)
          this.playerHeight = WorldGen.genRand.Next(5, 9);
        for (int index2 = 0; index2 < this.playerHeight; ++index2)
        {
          if (Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2 - 1].wall == (ushort) 244)
            Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2 - 1].wall = (ushort) 0;
          if (Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2].wall == (ushort) 244)
            Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2].wall = (ushort) 0;
          if (Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2 + 1].wall == (ushort) 244)
            Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2 + 1].wall = (ushort) 0;
          if (Main.tile[(int) this._history[index1].X, (int) this._history[index1].Y - index2].type == (ushort) 135)
            flagArray[index1] = true;
          WorldGen.KillTile((int) this._history[index1].X, (int) this._history[index1].Y - index2, noItem: true);
        }
      }
      for (int index3 = 0; index3 < this._length; ++index3)
      {
        if (WorldGen.genRand.Next(7) == 0)
          this.playerHeight = WorldGen.genRand.Next(5, 9);
        TrackGenerator.TrackHistory trackHistory = this._history[index3];
        Tile.SmoothSlope((int) trackHistory.X, (int) trackHistory.Y + 1);
        Tile.SmoothSlope((int) trackHistory.X, (int) trackHistory.Y - this.playerHeight);
        bool wire = Main.tile[(int) trackHistory.X, (int) trackHistory.Y].wire();
        if (flagArray[index3] && index3 < this._length && index3 > 0 && (int) this._history[index3 - 1].Y == (int) trackHistory.Y && (int) this._history[index3 + 1].Y == (int) trackHistory.Y)
        {
          Main.tile[(int) trackHistory.X, (int) trackHistory.Y].ClearEverything();
          WorldGen.PlaceTile((int) trackHistory.X, (int) trackHistory.Y, 314, forced: true, style: 1);
        }
        else
          Main.tile[(int) trackHistory.X, (int) trackHistory.Y].ResetToType((ushort) 314);
        Main.tile[(int) trackHistory.X, (int) trackHistory.Y].wire(wire);
        if (index3 != 0)
        {
          for (int index4 = 0; index4 < 8; ++index4)
            WorldUtils.TileFrame((int) this._history[index3 - 1].X, (int) this._history[index3 - 1].Y - index4, true);
          if (index3 == this._length - 1)
          {
            for (int index5 = 0; index5 < this.playerHeight; ++index5)
              WorldUtils.TileFrame((int) trackHistory.X, (int) trackHistory.Y - index5, true);
          }
        }
      }
    }

    private void CreateTrackStart(Point origin)
    {
      this._xDirection = origin.X > Main.maxTilesX / 2 ? -1 : 1;
      this._length = 1;
      for (int index = 0; index < this._history.Length; ++index)
        this._history[index] = new TrackGenerator.TrackHistory(origin.X + index * this._xDirection, origin.Y + index, TrackGenerator.TrackSlope.Down);
    }

    private bool FindPath(int minLength, int maxLength)
    {
      int length = this._length;
      while (this._length < this._history.Length - 100)
      {
        this.AppendToHistory(this._history[this._length - 1].Slope == TrackGenerator.TrackSlope.Up ? TrackGenerator.TrackSlope.Straight : TrackGenerator.TrackSlope.Down);
        TrackGenerator.TrackPlacementState avoidTiles = this.TryRewriteHistoryToAvoidTiles();
        if (avoidTiles != TrackGenerator.TrackPlacementState.Invalid)
        {
          length = this._length;
          TrackGenerator.TrackPlacementState trackPlacementState = avoidTiles;
          while (trackPlacementState != TrackGenerator.TrackPlacementState.Available)
          {
            trackPlacementState = this.CreateTunnel();
            if (trackPlacementState != TrackGenerator.TrackPlacementState.Invalid)
              length = this._length;
            else
              break;
          }
          if (this._length >= maxLength)
            break;
        }
        else
          break;
      }
      this._length = Math.Min(maxLength, length);
      if (this._length < minLength)
        return false;
      this.SmoothTrack();
      return this.GetHistorySegmentPlacementState(0, this._length) != TrackGenerator.TrackPlacementState.Invalid;
    }

    private TrackGenerator.TrackPlacementState CreateTunnel()
    {
      TrackGenerator.TrackSlope trackSlope1 = TrackGenerator.TrackSlope.Straight;
      int num = 10;
      TrackGenerator.TrackPlacementState trackPlacementState1 = TrackGenerator.TrackPlacementState.Invalid;
      int x = (int) this._history[this._length - 1].X;
      int y = (int) this._history[this._length - 1].Y;
      for (TrackGenerator.TrackSlope trackSlope2 = TrackGenerator.TrackSlope.Up; trackSlope2 <= TrackGenerator.TrackSlope.Down; ++trackSlope2)
      {
        TrackGenerator.TrackPlacementState trackPlacementState2 = TrackGenerator.TrackPlacementState.Invalid;
        for (int index = 1; index < num; ++index)
        {
          trackPlacementState2 = TrackGenerator.CalculateStateForLocation(x + index * this._xDirection, y + index * (int) trackSlope2);
          switch (trackPlacementState2)
          {
            case TrackGenerator.TrackPlacementState.Obstructed:
              continue;
            case TrackGenerator.TrackPlacementState.Invalid:
              goto label_6;
            default:
              trackSlope1 = trackSlope2;
              num = index;
              trackPlacementState1 = trackPlacementState2;
              goto label_6;
          }
        }
label_6:
        if (trackPlacementState1 != TrackGenerator.TrackPlacementState.Available && trackPlacementState2 == TrackGenerator.TrackPlacementState.Obstructed && (trackPlacementState1 != TrackGenerator.TrackPlacementState.Obstructed || trackSlope1 != TrackGenerator.TrackSlope.Straight))
        {
          trackSlope1 = trackSlope2;
          num = 10;
          trackPlacementState1 = trackPlacementState2;
        }
      }
      if (this._length == 0 || !TrackGenerator.CanSlopesTouch(this._history[this._length - 1].Slope, trackSlope1))
        this.RewriteSlopeDirection(this._length - 1, TrackGenerator.TrackSlope.Straight);
      this._history[this._length - 1].Mode = TrackGenerator.TrackMode.Tunnel;
      for (int index = 1; index < num; ++index)
        this.AppendToHistory(trackSlope1, TrackGenerator.TrackMode.Tunnel);
      return trackPlacementState1;
    }

    private void AppendToHistory(TrackGenerator.TrackSlope slope, TrackGenerator.TrackMode mode = TrackGenerator.TrackMode.Normal)
    {
      this._history[this._length] = new TrackGenerator.TrackHistory((int) this._history[this._length - 1].X + this._xDirection, (int) ((sbyte) this._history[this._length - 1].Y + slope), slope);
      this._history[this._length].Mode = mode;
      ++this._length;
    }

    private TrackGenerator.TrackPlacementState TryRewriteHistoryToAvoidTiles()
    {
      int index1 = this._length - 1;
      int length = Math.Min(this._length, this._rewriteHistory.Length);
      for (int index2 = 0; index2 < length; ++index2)
        this._rewriteHistory[index2] = this._history[index1 - index2];
      for (; index1 >= this._length - length; --index1)
      {
        if (this._history[index1].Slope == TrackGenerator.TrackSlope.Down)
        {
          TrackGenerator.TrackPlacementState segmentPlacementState = this.GetHistorySegmentPlacementState(index1, this._length - index1);
          if (segmentPlacementState == TrackGenerator.TrackPlacementState.Available)
            return segmentPlacementState;
          this.RewriteSlopeDirection(index1, TrackGenerator.TrackSlope.Straight);
        }
      }
      if (this.GetHistorySegmentPlacementState(index1 + 1, this._length - (index1 + 1)) == TrackGenerator.TrackPlacementState.Available)
        return TrackGenerator.TrackPlacementState.Available;
      int index3;
      for (index3 = this._length - 1; index3 >= this._length - length + 1; --index3)
      {
        if (this._history[index3].Slope == TrackGenerator.TrackSlope.Straight)
        {
          TrackGenerator.TrackPlacementState segmentPlacementState = this.GetHistorySegmentPlacementState(this._length - length, length);
          if (segmentPlacementState == TrackGenerator.TrackPlacementState.Available)
            return segmentPlacementState;
          this.RewriteSlopeDirection(index3, TrackGenerator.TrackSlope.Up);
        }
      }
      for (int index4 = 0; index4 < length; ++index4)
        this._history[this._length - 1 - index4] = this._rewriteHistory[index4];
      this.RewriteSlopeDirection(this._length - 1, TrackGenerator.TrackSlope.Straight);
      return this.GetHistorySegmentPlacementState(index3 + 1, this._length - (index3 + 1));
    }

    private void RewriteSlopeDirection(int index, TrackGenerator.TrackSlope slope)
    {
      int num = (int) (slope - this._history[index].Slope);
      this._history[index].Slope = slope;
      for (int index1 = index; index1 < this._length; ++index1)
        this._history[index1].Y += (short) num;
    }

    private TrackGenerator.TrackPlacementState GetHistorySegmentPlacementState(
      int startIndex,
      int length)
    {
      TrackGenerator.TrackPlacementState trackPlacementState = TrackGenerator.TrackPlacementState.Available;
      for (int index = startIndex; index < startIndex + length; ++index)
      {
        TrackGenerator.TrackPlacementState stateForLocation = TrackGenerator.CalculateStateForLocation((int) this._history[index].X, (int) this._history[index].Y);
        switch (stateForLocation)
        {
          case TrackGenerator.TrackPlacementState.Obstructed:
            if (this._history[index].Mode != TrackGenerator.TrackMode.Tunnel)
            {
              trackPlacementState = stateForLocation;
              break;
            }
            break;
          case TrackGenerator.TrackPlacementState.Invalid:
            return stateForLocation;
        }
      }
      return trackPlacementState;
    }

    private void SmoothTrack()
    {
      int val2 = this._length - 1;
      bool flag = false;
      for (int index1 = this._length - 1; index1 >= 0; --index1)
      {
        if (flag)
        {
          val2 = Math.Min(index1 + 15, val2);
          if ((int) this._history[index1].Y >= (int) this._history[val2].Y)
          {
            for (int index2 = index1 + 1; (int) this._history[index2].Y > (int) this._history[index1].Y; ++index2)
            {
              this._history[index2].Y = this._history[index1].Y;
              this._history[index2].Slope = TrackGenerator.TrackSlope.Straight;
            }
            if ((int) this._history[index1].Y == (int) this._history[val2].Y)
              flag = false;
          }
        }
        else if ((int) this._history[index1].Y > (int) this._history[val2].Y)
          flag = true;
        else
          val2 = index1;
      }
    }

    private static bool CanSlopesTouch(
      TrackGenerator.TrackSlope leftSlope,
      TrackGenerator.TrackSlope rightSlope)
    {
      return leftSlope == rightSlope || leftSlope == TrackGenerator.TrackSlope.Straight || rightSlope == TrackGenerator.TrackSlope.Straight;
    }

    private static bool FindSuitableOrigin(ref Point origin)
    {
      TrackGenerator.TrackPlacementState stateForLocation;
      while ((stateForLocation = TrackGenerator.CalculateStateForLocation(origin.X, origin.Y)) != TrackGenerator.TrackPlacementState.Obstructed)
      {
        ++origin.Y;
        if (stateForLocation == TrackGenerator.TrackPlacementState.Invalid)
          return false;
      }
      --origin.Y;
      return TrackGenerator.CalculateStateForLocation(origin.X, origin.Y) == TrackGenerator.TrackPlacementState.Available;
    }

    private static TrackGenerator.TrackPlacementState CalculateStateForLocation(
      int x,
      int y)
    {
      for (int index = 0; index < 6; ++index)
      {
        if (TrackGenerator.IsLocationInvalid(x, y - index))
          return TrackGenerator.TrackPlacementState.Invalid;
      }
      for (int index = 0; index < 6; ++index)
      {
        if (TrackGenerator.IsMinecartTrack(x, y + index))
          return TrackGenerator.TrackPlacementState.Invalid;
      }
      for (int index = 0; index < 6; ++index)
      {
        if (WorldGen.SolidTile(x, y - index))
          return TrackGenerator.TrackPlacementState.Obstructed;
      }
      return WorldGen.IsTileNearby(x, y, 314, 30) ? TrackGenerator.TrackPlacementState.Invalid : TrackGenerator.TrackPlacementState.Available;
    }

    private static bool IsMinecartTrack(int x, int y) => Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 314;

    private static bool IsLocationInvalid(int x, int y)
    {
      if (y > Main.UnderworldLayer || x < 5 || y < (int) Main.worldSurface || x > Main.maxTilesX - 5 || WorldGen.oceanDepths(x, y))
        return true;
      ushort wall = Main.tile[x, y].wall;
      for (int index = 0; index < TrackGenerator.InvalidWalls.Length; ++index)
      {
        if ((int) wall == (int) TrackGenerator.InvalidWalls[index] && (!WorldGen.notTheBees || wall != (ushort) 108))
          return true;
      }
      ushort type = Main.tile[x, y].type;
      for (int index = 0; index < TrackGenerator.InvalidTiles.Length; ++index)
      {
        if ((int) type == (int) TrackGenerator.InvalidTiles[index])
          return true;
      }
      for (int index = -1; index <= 1; ++index)
      {
        if (Main.tile[x + index, y].active() && (Main.tile[x + index, y].type == (ushort) 314 || !TileID.Sets.GeneralPlacementTiles[(int) Main.tile[x + index, y].type]) && (!WorldGen.notTheBees || Main.tile[x + index, y].type != (ushort) 225))
          return true;
      }
      return false;
    }

    [Conditional("DEBUG")]
    private void DrawPause()
    {
    }

    private enum TrackPlacementState
    {
      Available,
      Obstructed,
      Invalid,
    }

    private enum TrackSlope : sbyte
    {
      Up = -1, // 0xFF
      Straight = 0,
      Down = 1,
    }

    private enum TrackMode : byte
    {
      Normal,
      Tunnel,
    }

    [DebuggerDisplay("X = {X}, Y = {Y}, Slope = {Slope}")]
    private struct TrackHistory
    {
      public short X;
      public short Y;
      public TrackGenerator.TrackSlope Slope;
      public TrackGenerator.TrackMode Mode;

      public TrackHistory(int x, int y, TrackGenerator.TrackSlope slope)
      {
        this.X = (short) x;
        this.Y = (short) y;
        this.Slope = slope;
        this.Mode = TrackGenerator.TrackMode.Normal;
      }
    }
  }
}
