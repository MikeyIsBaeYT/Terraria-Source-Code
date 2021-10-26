// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallCollision
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria.DataStructures;

namespace Terraria.Physics
{
  public static class BallCollision
  {
    public static BallStepResult Step(
      PhysicsProperties physicsProperties,
      Entity entity,
      ref float entityAngularVelocity,
      IBallContactListener listener)
    {
      Vector2 position = entity.position;
      Vector2 velocity1 = entity.velocity;
      Vector2 size = entity.Size;
      float num1 = entityAngularVelocity;
      float num2 = size.X * 0.5f;
      float num3 = num1 * physicsProperties.Drag;
      Vector2 vector2_1 = velocity1 * physicsProperties.Drag;
      float num4 = vector2_1.Length();
      if ((double) num4 > 1000.0)
      {
        vector2_1 = 1000f * Vector2.Normalize(vector2_1);
        num4 = 1000f;
      }
      int num5 = Math.Max(1, (int) Math.Ceiling((double) num4 / 2.0));
      float timeScale = 1f / (float) num5;
      Vector2 velocity2 = vector2_1 * timeScale;
      float angularVelocity = num3 * timeScale;
      float num6 = physicsProperties.Gravity / (float) (num5 * num5);
      bool flag = false;
      for (int index = 0; index < num5; ++index)
      {
        velocity2.Y += num6;
        BallPassThroughType type;
        Tile tile;
        if (BallCollision.CheckForPassThrough(position + size * 0.5f, out type, out tile))
        {
          if (type == BallPassThroughType.Tile && Main.tileSolid[(int) tile.type] && !Main.tileSolidTop[(int) tile.type])
          {
            velocity2 *= 0.0f;
            angularVelocity *= 0.0f;
            flag = true;
          }
          else
          {
            BallPassThroughEvent passThrough = new BallPassThroughEvent(timeScale, tile, entity, type);
            listener.OnPassThrough(physicsProperties, ref position, ref velocity2, ref angularVelocity, ref passThrough);
          }
        }
        position += velocity2;
        if (!BallCollision.IsBallInWorld(position, size))
          return BallStepResult.OutOfBounds();
        Vector2 collisionPoint;
        if (BallCollision.GetClosestEdgeToCircle(position, size, velocity2, out collisionPoint, out tile))
        {
          Vector2 normal = Vector2.Normalize(position + size * 0.5f - collisionPoint);
          position = collisionPoint + normal * (num2 + 0.0001f) - size * 0.5f;
          BallCollisionEvent collision = new BallCollisionEvent(timeScale, normal, collisionPoint, tile, entity);
          flag = true;
          velocity2 = Vector2.Reflect(velocity2, collision.Normal);
          listener.OnCollision(physicsProperties, ref position, ref velocity2, ref collision);
          angularVelocity = (float) ((double) collision.Normal.X * (double) velocity2.Y - (double) collision.Normal.Y * (double) velocity2.X) / num2;
        }
      }
      Vector2 vector2_2 = velocity2 / timeScale;
      float num7 = angularVelocity / timeScale;
      BallStepResult ballStepResult = BallStepResult.Moving();
      if (flag && (double) vector2_2.X > -0.00999999977648258 && (double) vector2_2.X < 0.00999999977648258 && (double) vector2_2.Y <= 0.0 && (double) vector2_2.Y > -(double) physicsProperties.Gravity)
        ballStepResult = BallStepResult.Resting();
      entity.position = position;
      entity.velocity = vector2_2;
      entityAngularVelocity = num7;
      return ballStepResult;
    }

    private static bool CheckForPassThrough(
      Vector2 center,
      out BallPassThroughType type,
      out Tile contactTile)
    {
      Point tileCoordinates = center.ToTileCoordinates();
      Tile tile = Main.tile[tileCoordinates.X, tileCoordinates.Y];
      contactTile = tile;
      type = BallPassThroughType.None;
      if (tile == null)
        return false;
      if (tile.nactive())
      {
        type = BallPassThroughType.Tile;
        return BallCollision.IsPositionInsideTile(center, tileCoordinates, tile);
      }
      if (tile.liquid <= (byte) 0)
        return false;
      float num = (float) ((double) (tileCoordinates.Y + 1) * 16.0 - (double) tile.liquid / (double) byte.MaxValue * 16.0);
      switch (tile.liquidType())
      {
        case 1:
          type = BallPassThroughType.Lava;
          break;
        case 2:
          type = BallPassThroughType.Honey;
          break;
        default:
          type = BallPassThroughType.Water;
          break;
      }
      return (double) num < (double) center.Y;
    }

    private static bool IsPositionInsideTile(Vector2 position, Point tileCoordinates, Tile tile)
    {
      if (tile.slope() == (byte) 0 && !tile.halfBrick())
        return true;
      Vector2 vector2 = position / 16f - new Vector2((float) tileCoordinates.X, (float) tileCoordinates.Y);
      switch (tile.slope())
      {
        case 0:
          return (double) vector2.Y > 0.5;
        case 1:
          return (double) vector2.Y > (double) vector2.X;
        case 2:
          return (double) vector2.Y > 1.0 - (double) vector2.X;
        case 3:
          return (double) vector2.Y < 1.0 - (double) vector2.X;
        case 4:
          return (double) vector2.Y < (double) vector2.X;
        default:
          return false;
      }
    }

    private static bool IsBallInWorld(Vector2 position, Vector2 size) => (double) position.X > 32.0 && (double) position.Y > 32.0 && (double) position.X + (double) size.X < (double) Main.maxTilesX * 16.0 - 32.0 && (double) position.Y + (double) size.Y < (double) Main.maxTilesY * 16.0 - 32.0;

    private static bool GetClosestEdgeToCircle(
      Vector2 position,
      Vector2 size,
      Vector2 velocity,
      out Vector2 collisionPoint,
      out Tile collisionTile)
    {
      Rectangle tileBounds = BallCollision.GetTileBounds(position, size);
      Vector2 center = position + size * 0.5f;
      BallCollision.TileEdges tileEdges1 = BallCollision.TileEdges.None;
      BallCollision.TileEdges tileEdges2 = (double) velocity.Y >= 0.0 ? tileEdges1 | BallCollision.TileEdges.Top : tileEdges1 | BallCollision.TileEdges.Bottom;
      BallCollision.TileEdges tileEdges3 = (double) velocity.X >= 0.0 ? tileEdges2 | BallCollision.TileEdges.Left : tileEdges2 | BallCollision.TileEdges.Right;
      BallCollision.TileEdges tileEdges4 = (double) velocity.Y <= (double) velocity.X ? tileEdges3 | BallCollision.TileEdges.TopRightSlope : tileEdges3 | BallCollision.TileEdges.BottomLeftSlope;
      BallCollision.TileEdges edgesToTest = (double) velocity.Y <= -(double) velocity.X ? tileEdges4 | BallCollision.TileEdges.TopLeftSlope : tileEdges4 | BallCollision.TileEdges.BottomRightSlope;
      collisionPoint = Vector2.Zero;
      collisionTile = (Tile) null;
      float num1 = float.MaxValue;
      Vector2 closestPointOut = new Vector2();
      float distanceSquaredOut = 0.0f;
      for (int left = tileBounds.Left; left < tileBounds.Right; ++left)
      {
        for (int top = tileBounds.Top; top < tileBounds.Bottom; ++top)
        {
          if (BallCollision.GetCollisionPointForTile(edgesToTest, left, top, center, ref closestPointOut, ref distanceSquaredOut) && (double) distanceSquaredOut < (double) num1 && (double) Vector2.Dot(velocity, center - closestPointOut) <= 0.0)
          {
            num1 = distanceSquaredOut;
            collisionPoint = closestPointOut;
            collisionTile = Main.tile[left, top];
          }
        }
      }
      float num2 = size.X / 2f;
      return (double) num1 < (double) num2 * (double) num2;
    }

    private static bool GetCollisionPointForTile(
      BallCollision.TileEdges edgesToTest,
      int x,
      int y,
      Vector2 center,
      ref Vector2 closestPointOut,
      ref float distanceSquaredOut)
    {
      Tile tile = Main.tile[x, y];
      if (tile == null || !tile.nactive() || !Main.tileSolid[(int) tile.type] && !Main.tileSolidTop[(int) tile.type] || !Main.tileSolid[(int) tile.type] && Main.tileSolidTop[(int) tile.type] && tile.frameY != (short) 0)
        return false;
      if (Main.tileSolidTop[(int) tile.type])
        edgesToTest &= BallCollision.TileEdges.Top | BallCollision.TileEdges.BottomLeftSlope | BallCollision.TileEdges.BottomRightSlope;
      Vector2 tilePosition = new Vector2((float) x * 16f, (float) y * 16f);
      bool flag = false;
      LineSegment edge = new LineSegment();
      if (BallCollision.GetSlopeEdge(ref edgesToTest, tile, tilePosition, ref edge))
      {
        closestPointOut = BallCollision.ClosestPointOnLineSegment(center, edge);
        distanceSquaredOut = Vector2.DistanceSquared(closestPointOut, center);
        flag = true;
      }
      if (BallCollision.GetTopOrBottomEdge(edgesToTest, x, y, tilePosition, ref edge))
      {
        Vector2 vector2 = BallCollision.ClosestPointOnLineSegment(center, edge);
        float num = Vector2.DistanceSquared(vector2, center);
        if (!flag || (double) num < (double) distanceSquaredOut)
        {
          distanceSquaredOut = num;
          closestPointOut = vector2;
        }
        flag = true;
      }
      if (BallCollision.GetLeftOrRightEdge(edgesToTest, x, y, tilePosition, ref edge))
      {
        Vector2 vector2 = BallCollision.ClosestPointOnLineSegment(center, edge);
        float num = Vector2.DistanceSquared(vector2, center);
        if (!flag || (double) num < (double) distanceSquaredOut)
        {
          distanceSquaredOut = num;
          closestPointOut = vector2;
        }
        flag = true;
      }
      return flag;
    }

    private static bool GetSlopeEdge(
      ref BallCollision.TileEdges edgesToTest,
      Tile tile,
      Vector2 tilePosition,
      ref LineSegment edge)
    {
      switch (tile.slope())
      {
        case 0:
          return false;
        case 1:
          edgesToTest &= BallCollision.TileEdges.Bottom | BallCollision.TileEdges.Left | BallCollision.TileEdges.BottomLeftSlope;
          if ((edgesToTest & BallCollision.TileEdges.BottomLeftSlope) == BallCollision.TileEdges.None)
            return false;
          edge.Start = tilePosition;
          edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y + 16f);
          return true;
        case 2:
          edgesToTest &= BallCollision.TileEdges.Bottom | BallCollision.TileEdges.Right | BallCollision.TileEdges.BottomRightSlope;
          if ((edgesToTest & BallCollision.TileEdges.BottomRightSlope) == BallCollision.TileEdges.None)
            return false;
          edge.Start = new Vector2(tilePosition.X, tilePosition.Y + 16f);
          edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y);
          return true;
        case 3:
          edgesToTest &= BallCollision.TileEdges.Top | BallCollision.TileEdges.Left | BallCollision.TileEdges.TopLeftSlope;
          if ((edgesToTest & BallCollision.TileEdges.TopLeftSlope) == BallCollision.TileEdges.None)
            return false;
          edge.Start = new Vector2(tilePosition.X, tilePosition.Y + 16f);
          edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y);
          return true;
        case 4:
          edgesToTest &= BallCollision.TileEdges.Top | BallCollision.TileEdges.Right | BallCollision.TileEdges.TopRightSlope;
          if ((edgesToTest & BallCollision.TileEdges.TopRightSlope) == BallCollision.TileEdges.None)
            return false;
          edge.Start = tilePosition;
          edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y + 16f);
          return true;
        default:
          return false;
      }
    }

    private static bool GetTopOrBottomEdge(
      BallCollision.TileEdges edgesToTest,
      int x,
      int y,
      Vector2 tilePosition,
      ref LineSegment edge)
    {
      if ((edgesToTest & BallCollision.TileEdges.Bottom) != BallCollision.TileEdges.None)
      {
        Tile tile = Main.tile[x, y + 1];
        if ((!BallCollision.IsNeighborSolid(tile) || tile.slope() == (byte) 1 || tile.slope() == (byte) 2 ? 1 : (tile.halfBrick() ? 1 : 0)) == 0)
          return false;
        edge.Start = new Vector2(tilePosition.X, tilePosition.Y + 16f);
        edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y + 16f);
        return true;
      }
      if ((edgesToTest & BallCollision.TileEdges.Top) == BallCollision.TileEdges.None)
        return false;
      Tile tile1 = Main.tile[x, y - 1];
      if ((Main.tile[x, y].halfBrick() || !BallCollision.IsNeighborSolid(tile1) || tile1.slope() == (byte) 3 ? 1 : (tile1.slope() == (byte) 4 ? 1 : 0)) == 0)
        return false;
      if (Main.tile[x, y].halfBrick())
        tilePosition.Y += 8f;
      edge.Start = new Vector2(tilePosition.X, tilePosition.Y);
      edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y);
      return true;
    }

    private static bool GetLeftOrRightEdge(
      BallCollision.TileEdges edgesToTest,
      int x,
      int y,
      Vector2 tilePosition,
      ref LineSegment edge)
    {
      if ((edgesToTest & BallCollision.TileEdges.Left) != BallCollision.TileEdges.None)
      {
        Tile tile1 = Main.tile[x, y];
        Tile tile2 = Main.tile[x - 1, y];
        if ((!BallCollision.IsNeighborSolid(tile2) || tile2.slope() == (byte) 1 || tile2.slope() == (byte) 3 ? 1 : (!tile2.halfBrick() ? 0 : (!tile1.halfBrick() ? 1 : 0))) == 0)
          return false;
        edge.Start = new Vector2(tilePosition.X, tilePosition.Y);
        edge.End = new Vector2(tilePosition.X, tilePosition.Y + 16f);
        if (tile1.halfBrick())
          edge.Start.Y += 8f;
        return true;
      }
      if ((edgesToTest & BallCollision.TileEdges.Right) == BallCollision.TileEdges.None)
        return false;
      Tile tile3 = Main.tile[x, y];
      Tile tile4 = Main.tile[x + 1, y];
      if ((!BallCollision.IsNeighborSolid(tile4) || tile4.slope() == (byte) 2 || tile4.slope() == (byte) 4 ? 1 : (!tile4.halfBrick() ? 0 : (!tile3.halfBrick() ? 1 : 0))) == 0)
        return false;
      edge.Start = new Vector2(tilePosition.X + 16f, tilePosition.Y);
      edge.End = new Vector2(tilePosition.X + 16f, tilePosition.Y + 16f);
      if (tile3.halfBrick())
        edge.Start.Y += 8f;
      return true;
    }

    private static Rectangle GetTileBounds(Vector2 position, Vector2 size)
    {
      int x = (int) Math.Floor((double) position.X / 16.0);
      int y = (int) Math.Floor((double) position.Y / 16.0);
      int num1 = (int) Math.Floor(((double) position.X + (double) size.X) / 16.0);
      int num2 = (int) Math.Floor(((double) position.Y + (double) size.Y) / 16.0);
      return new Rectangle(x, y, num1 - x + 1, num2 - y + 1);
    }

    private static bool IsNeighborSolid(Tile tile) => tile != null && tile.nactive() && Main.tileSolid[(int) tile.type] && !Main.tileSolidTop[(int) tile.type];

    private static Vector2 ClosestPointOnLineSegment(Vector2 point, LineSegment lineSegment)
    {
      Vector2 vector2_1 = point - lineSegment.Start;
      Vector2 vector2_2 = lineSegment.End - lineSegment.Start;
      float num1 = vector2_2.LengthSquared();
      Vector2 vector2_3 = vector2_2;
      float num2 = Vector2.Dot(vector2_1, vector2_3) / num1;
      if ((double) num2 < 0.0)
        return lineSegment.Start;
      return (double) num2 > 1.0 ? lineSegment.End : lineSegment.Start + vector2_2 * num2;
    }

    [Conditional("DEBUG")]
    private static void DrawEdge(LineSegment edge)
    {
    }

    [Flags]
    private enum TileEdges : uint
    {
      None = 0,
      Top = 1,
      Bottom = 2,
      Left = 4,
      Right = 8,
      TopLeftSlope = 16, // 0x00000010
      TopRightSlope = 32, // 0x00000020
      BottomLeftSlope = 64, // 0x00000040
      BottomRightSlope = 128, // 0x00000080
    }
  }
}
