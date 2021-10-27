// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PortalHelper
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.GameContent
{
  public class PortalHelper
  {
    public const int PORTALS_PER_PERSON = 2;
    private static int[,] FoundPortals = new int[256, 2];
    private static int[] PortalCooldownForPlayers = new int[256];
    private static int[] PortalCooldownForNPCs = new int[200];
    private static readonly Vector2[] EDGES = new Vector2[4]
    {
      new Vector2(0.0f, 1f),
      new Vector2(0.0f, -1f),
      new Vector2(1f, 0.0f),
      new Vector2(-1f, 0.0f)
    };
    private static readonly Vector2[] SLOPE_EDGES = new Vector2[4]
    {
      new Vector2(1f, -1f),
      new Vector2(-1f, -1f),
      new Vector2(1f, 1f),
      new Vector2(-1f, 1f)
    };
    private static readonly Point[] SLOPE_OFFSETS = new Point[4]
    {
      new Point(1, -1),
      new Point(-1, -1),
      new Point(1, 1),
      new Point(-1, 1)
    };

    static PortalHelper()
    {
      for (int index = 0; index < PortalHelper.SLOPE_EDGES.Length; ++index)
        PortalHelper.SLOPE_EDGES[index].Normalize();
      for (int index = 0; index < PortalHelper.FoundPortals.GetLength(0); ++index)
      {
        PortalHelper.FoundPortals[index, 0] = -1;
        PortalHelper.FoundPortals[index, 1] = -1;
      }
    }

    public static void UpdatePortalPoints()
    {
      for (int index = 0; index < PortalHelper.FoundPortals.GetLength(0); ++index)
      {
        PortalHelper.FoundPortals[index, 0] = -1;
        PortalHelper.FoundPortals[index, 1] = -1;
      }
      for (int index = 0; index < PortalHelper.PortalCooldownForPlayers.Length; ++index)
      {
        if (PortalHelper.PortalCooldownForPlayers[index] > 0)
          --PortalHelper.PortalCooldownForPlayers[index];
      }
      for (int index = 0; index < PortalHelper.PortalCooldownForNPCs.Length; ++index)
      {
        if (PortalHelper.PortalCooldownForNPCs[index] > 0)
          --PortalHelper.PortalCooldownForNPCs[index];
      }
      for (int index = 0; index < 1000; ++index)
      {
        Projectile projectile = Main.projectile[index];
        if (projectile.active && projectile.type == 602 && (double) projectile.ai[1] >= 0.0 && (double) projectile.ai[1] <= 1.0 && projectile.owner >= 0 && projectile.owner <= (int) byte.MaxValue)
          PortalHelper.FoundPortals[projectile.owner, (int) projectile.ai[1]] = index;
      }
    }

    public static void TryGoingThroughPortals(Entity ent)
    {
      float collisionPoint = 0.0f;
      Vector2 velocity = ent.velocity;
      int width = ent.width;
      int height = ent.height;
      int gravDir = 1;
      if (ent is Player)
        gravDir = (int) ((Player) ent).gravDir;
      for (int index1 = 0; index1 < PortalHelper.FoundPortals.GetLength(0); ++index1)
      {
        if (PortalHelper.FoundPortals[index1, 0] != -1 && PortalHelper.FoundPortals[index1, 1] != -1 && (!(ent is Player) || index1 < PortalHelper.PortalCooldownForPlayers.Length && PortalHelper.PortalCooldownForPlayers[index1] <= 0) && (!(ent is NPC) || index1 < PortalHelper.PortalCooldownForNPCs.Length && PortalHelper.PortalCooldownForNPCs[index1] <= 0))
        {
          for (int index2 = 0; index2 < 2; ++index2)
          {
            Projectile projectile1 = Main.projectile[PortalHelper.FoundPortals[index1, index2]];
            Vector2 start;
            Vector2 end;
            PortalHelper.GetPortalEdges(projectile1.Center, projectile1.ai[0], out start, out end);
            if (Collision.CheckAABBvLineCollision(ent.position + ent.velocity, ent.Size, start, end, 2f, ref collisionPoint))
            {
              Projectile projectile2 = Main.projectile[PortalHelper.FoundPortals[index1, 1 - index2]];
              float num1 = ent.Hitbox.Distance(projectile1.Center);
              int bonusX;
              int bonusY;
              Vector2 newPos = PortalHelper.GetPortalOutingPoint(ent.Size, projectile2.Center, projectile2.ai[0], out bonusX, out bonusY) + Vector2.Normalize(new Vector2((float) bonusX, (float) bonusY)) * num1;
              Vector2 Velocity1 = Vector2.UnitX * 16f;
              if (!(Collision.TileCollision(newPos - Velocity1, Velocity1, width, height, true, true, gravDir) != Velocity1))
              {
                Vector2 Velocity2 = -Vector2.UnitX * 16f;
                if (!(Collision.TileCollision(newPos - Velocity2, Velocity2, width, height, true, true, gravDir) != Velocity2))
                {
                  Vector2 Velocity3 = Vector2.UnitY * 16f;
                  if (!(Collision.TileCollision(newPos - Velocity3, Velocity3, width, height, true, true, gravDir) != Velocity3))
                  {
                    Vector2 Velocity4 = -Vector2.UnitY * 16f;
                    if (!(Collision.TileCollision(newPos - Velocity4, Velocity4, width, height, true, true, gravDir) != Velocity4))
                    {
                      float num2 = 0.1f;
                      if (bonusY == -gravDir)
                        num2 = 0.1f;
                      if (ent.velocity == Vector2.Zero)
                        ent.velocity = (projectile1.ai[0] - 1.570796f).ToRotationVector2() * num2;
                      if ((double) ent.velocity.Length() < (double) num2)
                      {
                        ent.velocity.Normalize();
                        ent.velocity *= num2;
                      }
                      Vector2 vec = Vector2.Normalize(new Vector2((float) bonusX, (float) bonusY));
                      if (vec.HasNaNs() || vec == Vector2.Zero)
                        vec = Vector2.UnitX * (float) ent.direction;
                      ent.velocity = vec * ent.velocity.Length();
                      if (bonusY == -gravDir && Math.Sign(ent.velocity.Y) != -gravDir || (double) Math.Abs(ent.velocity.Y) < 0.100000001490116)
                        ent.velocity.Y = (float) -gravDir * 0.1f;
                      int extraInfo = (int) ((double) (projectile2.owner * 2) + (double) projectile2.ai[1]);
                      int num3 = extraInfo + (extraInfo % 2 == 0 ? 1 : -1);
                      switch (ent)
                      {
                        case Player _:
                          Player player = (Player) ent;
                          player.lastPortalColorIndex = num3;
                          player.Teleport(newPos, 4, extraInfo);
                          if (Main.netMode == 1)
                          {
                            NetMessage.SendData(96, number: player.whoAmI, number2: newPos.X, number3: newPos.Y, number4: ((float) extraInfo));
                            NetMessage.SendData(13, number: player.whoAmI);
                          }
                          PortalHelper.PortalCooldownForPlayers[index1] = 10;
                          return;
                        case NPC _:
                          NPC npc = (NPC) ent;
                          npc.lastPortalColorIndex = num3;
                          npc.Teleport(newPos, 4, extraInfo);
                          if (Main.netMode == 1)
                          {
                            NetMessage.SendData(100, number: npc.whoAmI, number2: newPos.X, number3: newPos.Y, number4: ((float) extraInfo));
                            NetMessage.SendData(23, number: npc.whoAmI);
                          }
                          PortalHelper.PortalCooldownForPlayers[index1] = 10;
                          return;
                        default:
                          return;
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }

    public static int TryPlacingPortal(
      Projectile theBolt,
      Vector2 velocity,
      Vector2 theCrashVelocity)
    {
      Vector2 vector2_1 = velocity / velocity.Length();
      Point tileCoordinates = PortalHelper.FindCollision(theBolt.position, theBolt.position + velocity + vector2_1 * 32f).ToTileCoordinates();
      Tile tile = Main.tile[tileCoordinates.X, tileCoordinates.Y];
      Vector2 vector2_2 = new Vector2((float) (tileCoordinates.X * 16 + 8), (float) (tileCoordinates.Y * 16 + 8));
      if (!WorldGen.SolidOrSlopedTile(tile))
        return -1;
      int num = (int) tile.slope();
      bool flag = tile.halfBrick();
      for (int index = 0; index < (flag ? 2 : PortalHelper.EDGES.Length); ++index)
      {
        Point bestPosition;
        if ((double) Vector2.Dot(PortalHelper.EDGES[index], vector2_1) > 0.0 && PortalHelper.FindValidLine(tileCoordinates, (int) PortalHelper.EDGES[index].Y, (int) -(double) PortalHelper.EDGES[index].X, out bestPosition))
          return PortalHelper.AddPortal(new Vector2((float) (bestPosition.X * 16 + 8), (float) (bestPosition.Y * 16 + 8)) - PortalHelper.EDGES[index] * (flag ? 0.0f : 8f), (float) Math.Atan2((double) PortalHelper.EDGES[index].Y, (double) PortalHelper.EDGES[index].X) + 1.570796f, (int) theBolt.ai[0], theBolt.direction);
      }
      if (num != 0)
      {
        Vector2 vector2_3 = PortalHelper.SLOPE_EDGES[num - 1];
        Point bestPosition;
        if ((double) Vector2.Dot(vector2_3, -vector2_1) > 0.0 && PortalHelper.FindValidLine(tileCoordinates, -PortalHelper.SLOPE_OFFSETS[num - 1].Y, PortalHelper.SLOPE_OFFSETS[num - 1].X, out bestPosition))
          return PortalHelper.AddPortal(new Vector2((float) (bestPosition.X * 16 + 8), (float) (bestPosition.Y * 16 + 8)), (float) Math.Atan2((double) vector2_3.Y, (double) vector2_3.X) - 1.570796f, (int) theBolt.ai[0], theBolt.direction);
      }
      return -1;
    }

    private static bool FindValidLine(
      Point position,
      int xOffset,
      int yOffset,
      out Point bestPosition)
    {
      bestPosition = position;
      if (PortalHelper.IsValidLine(position, xOffset, yOffset))
        return true;
      Point position1 = new Point(position.X - xOffset, position.Y - yOffset);
      if (PortalHelper.IsValidLine(position1, xOffset, yOffset))
      {
        bestPosition = position1;
        return true;
      }
      Point position2 = new Point(position.X + xOffset, position.Y + yOffset);
      if (!PortalHelper.IsValidLine(position2, xOffset, yOffset))
        return false;
      bestPosition = position2;
      return true;
    }

    private static bool IsValidLine(Point position, int xOffset, int yOffset)
    {
      Tile tile1 = Main.tile[position.X, position.Y];
      Tile tile2 = Main.tile[position.X - xOffset, position.Y - yOffset];
      Tile tile3 = Main.tile[position.X + xOffset, position.Y + yOffset];
      return !PortalHelper.BlockPortals(Main.tile[position.X + yOffset, position.Y - xOffset]) && !PortalHelper.BlockPortals(Main.tile[position.X + yOffset - xOffset, position.Y - xOffset - yOffset]) && !PortalHelper.BlockPortals(Main.tile[position.X + yOffset + xOffset, position.Y - xOffset + yOffset]) && WorldGen.SolidOrSlopedTile(tile1) && WorldGen.SolidOrSlopedTile(tile2) && WorldGen.SolidOrSlopedTile(tile3) && tile2.HasSameSlope(tile1) && tile3.HasSameSlope(tile1);
    }

    private static bool BlockPortals(Tile t) => t.active() && !Main.tileCut[(int) t.type] && !TileID.Sets.BreakableWhenPlacing[(int) t.type] && Main.tileSolid[(int) t.type];

    private static Vector2 FindCollision(Vector2 startPosition, Vector2 stopPosition)
    {
      int lastX = 0;
      int lastY = 0;
      Utils.PlotLine(startPosition.ToTileCoordinates(), stopPosition.ToTileCoordinates(), (Utils.PerLinePoint) ((x, y) =>
      {
        lastX = x;
        lastY = y;
        return !WorldGen.SolidOrSlopedTile(x, y);
      }), false);
      return new Vector2((float) lastX * 16f, (float) lastY * 16f);
    }

    private static int AddPortal(Vector2 position, float angle, int form, int direction)
    {
      if (!PortalHelper.SupportedTilesAreFine(position, angle))
        return -1;
      PortalHelper.RemoveMyOldPortal(form);
      PortalHelper.RemoveIntersectingPortals(position, angle);
      int index = Projectile.NewProjectile(position.X, position.Y, 0.0f, 0.0f, 602, 0, 0.0f, Main.myPlayer, angle, (float) form);
      Main.projectile[index].direction = direction;
      Main.projectile[index].netUpdate = true;
      return index;
    }

    private static void RemoveMyOldPortal(int form)
    {
      for (int index = 0; index < 1000; ++index)
      {
        Projectile projectile = Main.projectile[index];
        if (projectile.active && projectile.type == 602 && projectile.owner == Main.myPlayer && (double) projectile.ai[1] == (double) form)
        {
          projectile.Kill();
          break;
        }
      }
    }

    private static void RemoveIntersectingPortals(Vector2 position, float angle)
    {
      Vector2 start1;
      Vector2 end1;
      PortalHelper.GetPortalEdges(position, angle, out start1, out end1);
      for (int number = 0; number < 1000; ++number)
      {
        Projectile projectile = Main.projectile[number];
        if (projectile.active && projectile.type == 602)
        {
          Vector2 start2;
          Vector2 end2;
          PortalHelper.GetPortalEdges(projectile.Center, projectile.ai[0], out start2, out end2);
          if (Collision.CheckLinevLine(start1, end1, start2, end2).Length != 0)
          {
            if (projectile.owner != Main.myPlayer && Main.netMode != 2)
              NetMessage.SendData(95, number: number);
            projectile.Kill();
            if (Main.netMode == 2)
              NetMessage.SendData(29, number: projectile.whoAmI, number2: ((float) projectile.owner));
          }
        }
      }
    }

    public static Color GetPortalColor(int colorIndex) => PortalHelper.GetPortalColor(colorIndex / 2, colorIndex % 2);

    public static Color GetPortalColor(int player, int portal)
    {
      Color white = Color.White;
      Color color;
      if (Main.netMode == 0)
      {
        color = portal != 0 ? Main.hslToRgb(0.52f, 1f, 0.6f) : Main.hslToRgb(0.12f, 1f, 0.5f);
      }
      else
      {
        float num = 0.08f;
        color = Main.hslToRgb((float) ((0.5 + (double) player * ((double) num * 2.0) + (double) portal * (double) num) % 1.0), 1f, 0.5f);
      }
      color.A = (byte) 66;
      return color;
    }

    private static void GetPortalEdges(
      Vector2 position,
      float angle,
      out Vector2 start,
      out Vector2 end)
    {
      Vector2 rotationVector2 = angle.ToRotationVector2();
      start = position + rotationVector2 * -22f;
      end = position + rotationVector2 * 22f;
    }

    private static Vector2 GetPortalOutingPoint(
      Vector2 objectSize,
      Vector2 portalPosition,
      float portalAngle,
      out int bonusX,
      out int bonusY)
    {
      int num = (int) Math.Round((double) MathHelper.WrapAngle(portalAngle) / 0.785398185253143);
      switch (num)
      {
        case -3:
        case 3:
          bonusX = num == -3 ? 1 : -1;
          bonusY = -1;
          return portalPosition + new Vector2(num == -3 ? 0.0f : -objectSize.X, -objectSize.Y);
        case -2:
        case 2:
          bonusX = num == 2 ? -1 : 1;
          bonusY = 0;
          return portalPosition + new Vector2(num == 2 ? -objectSize.X : 0.0f, (float) (-(double) objectSize.Y / 2.0));
        case -1:
        case 1:
          bonusX = num == -1 ? 1 : -1;
          bonusY = 1;
          return portalPosition + new Vector2(num == -1 ? 0.0f : -objectSize.X, 0.0f);
        case 0:
        case 4:
          bonusX = 0;
          bonusY = num == 0 ? 1 : -1;
          return portalPosition + new Vector2((float) (-(double) objectSize.X / 2.0), num == 0 ? 0.0f : -objectSize.Y);
        default:
          Main.NewText("Broken portal! (over4s = " + (object) num + ")");
          bonusX = 0;
          bonusY = 0;
          return portalPosition;
      }
    }

    public static void SyncPortalsOnPlayerJoin(
      int plr,
      int fluff,
      List<Point> dontInclude,
      out List<Point> portals,
      out List<Point> portalCenters)
    {
      portals = new List<Point>();
      portalCenters = new List<Point>();
      for (int index = 0; index < 1000; ++index)
      {
        Projectile projectile = Main.projectile[index];
        if (projectile.active && (projectile.type == 602 || projectile.type == 601))
        {
          Vector2 center = projectile.Center;
          int sectionX = Netplay.GetSectionX((int) ((double) center.X / 16.0));
          int sectionY = Netplay.GetSectionY((int) ((double) center.Y / 16.0));
          for (int x = sectionX - fluff; x < sectionX + fluff + 1; ++x)
          {
            for (int y = sectionY - fluff; y < sectionY + fluff + 1; ++y)
            {
              if (x >= 0 && x < Main.maxSectionsX && y >= 0 && y < Main.maxSectionsY && !Netplay.Clients[plr].TileSections[x, y] && !dontInclude.Contains(new Point(x, y)))
              {
                portals.Add(new Point(x, y));
                if (!portalCenters.Contains(new Point(sectionX, sectionY)))
                  portalCenters.Add(new Point(sectionX, sectionY));
              }
            }
          }
        }
      }
    }

    public static void SyncPortalSections(Vector2 portalPosition, int fluff)
    {
      for (int playerIndex = 0; playerIndex < (int) byte.MaxValue; ++playerIndex)
      {
        if (Main.player[playerIndex].active)
          RemoteClient.CheckSection(playerIndex, portalPosition, fluff);
      }
    }

    public static bool SupportedTilesAreFine(Vector2 portalCenter, float portalAngle)
    {
      Point tileCoordinates = portalCenter.ToTileCoordinates();
      int num1 = (int) Math.Round((double) MathHelper.WrapAngle(portalAngle) / 0.785398185253143);
      int num2;
      int num3;
      switch (num1)
      {
        case -3:
        case 3:
          num2 = num1 == -3 ? 1 : -1;
          num3 = -1;
          break;
        case -2:
        case 2:
          num2 = num1 == 2 ? -1 : 1;
          num3 = 0;
          break;
        case -1:
        case 1:
          num2 = num1 == -1 ? 1 : -1;
          num3 = 1;
          break;
        case 0:
        case 4:
          num2 = 0;
          num3 = num1 == 0 ? 1 : -1;
          break;
        default:
          Main.NewText("Broken portal! (over4s = " + (object) num1 + " , " + (object) portalAngle + ")");
          return false;
      }
      if (num2 != 0 && num3 != 0)
      {
        int num4 = 3;
        if (num2 == -1 && num3 == 1)
          num4 = 5;
        if (num2 == 1 && num3 == -1)
          num4 = 2;
        if (num2 == 1 && num3 == 1)
          num4 = 4;
        int slope = num4 - 1;
        return PortalHelper.SupportedSlope(tileCoordinates.X, tileCoordinates.Y, slope) && PortalHelper.SupportedSlope(tileCoordinates.X + num2, tileCoordinates.Y - num3, slope) && PortalHelper.SupportedSlope(tileCoordinates.X - num2, tileCoordinates.Y + num3, slope);
      }
      switch (num2)
      {
        case 0:
          switch (num3)
          {
            case 0:
              return true;
            case 1:
              --tileCoordinates.Y;
              break;
          }
          if (PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y) && PortalHelper.SupportedNormal(tileCoordinates.X + 1, tileCoordinates.Y) && PortalHelper.SupportedNormal(tileCoordinates.X - 1, tileCoordinates.Y))
            return true;
          return PortalHelper.SupportedHalfbrick(tileCoordinates.X, tileCoordinates.Y) && PortalHelper.SupportedHalfbrick(tileCoordinates.X + 1, tileCoordinates.Y) && PortalHelper.SupportedHalfbrick(tileCoordinates.X - 1, tileCoordinates.Y);
        case 1:
          --tileCoordinates.X;
          break;
      }
      return PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y) && PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y - 1) && PortalHelper.SupportedNormal(tileCoordinates.X, tileCoordinates.Y + 1);
    }

    private static bool SupportedSlope(int x, int y, int slope)
    {
      Tile tile = Main.tile[x, y];
      return tile != null && tile.nactive() && !Main.tileCut[(int) tile.type] && !TileID.Sets.BreakableWhenPlacing[(int) tile.type] && Main.tileSolid[(int) tile.type] && (int) tile.slope() == slope;
    }

    private static bool SupportedHalfbrick(int x, int y)
    {
      Tile tile = Main.tile[x, y];
      return tile != null && tile.nactive() && !Main.tileCut[(int) tile.type] && !TileID.Sets.BreakableWhenPlacing[(int) tile.type] && Main.tileSolid[(int) tile.type] && tile.halfBrick();
    }

    private static bool SupportedNormal(int x, int y)
    {
      Tile tile = Main.tile[x, y];
      return tile != null && tile.nactive() && !Main.tileCut[(int) tile.type] && !TileID.Sets.BreakableWhenPlacing[(int) tile.type] && Main.tileSolid[(int) tile.type] && !TileID.Sets.NotReallySolid[(int) tile.type] && !tile.halfBrick() && tile.slope() == (byte) 0;
    }
  }
}
