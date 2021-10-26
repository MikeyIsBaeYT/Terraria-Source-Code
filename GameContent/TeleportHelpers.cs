// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.TeleportHelpers
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent
{
  public class TeleportHelpers
  {
    public static bool RequestMagicConchTeleportPosition(
      Player player,
      int crawlOffsetX,
      int startX,
      out Point landingPoint)
    {
      landingPoint = new Point();
      Point point = new Point(startX, 50);
      int num1 = 1;
      int num2 = -1;
      int num3 = 1;
      int num4 = 0;
      int num5 = 5000;
      Vector2 vector2 = new Vector2((float) player.width * 0.5f, (float) player.height);
      int num6 = 40;
      bool flag1 = WorldGen.SolidOrSlopedTile(Main.tile[point.X, point.Y]);
      int num7 = 0;
      int num8 = 400;
      while (num4 < num5 && num7 < num8)
      {
        ++num4;
        Tile tile1 = Main.tile[point.X, point.Y];
        Tile tile2 = Main.tile[point.X, point.Y + num3];
        bool flag2 = WorldGen.SolidOrSlopedTile(tile1) || tile1.liquid > (byte) 0;
        bool flag3 = WorldGen.SolidOrSlopedTile(tile2) || tile2.liquid > (byte) 0;
        if (TeleportHelpers.IsInSolidTilesExtended(new Vector2((float) (point.X * 16 + 8), (float) (point.Y * 16 + 15)) - vector2, player.velocity, player.width, player.height, (int) player.gravDir))
        {
          if (flag1)
            point.Y += num1;
          else
            point.Y += num2;
        }
        else if (flag2)
        {
          if (flag1)
            point.Y += num1;
          else
            point.Y += num2;
        }
        else
        {
          flag1 = false;
          if (!TeleportHelpers.IsInSolidTilesExtended(new Vector2((float) (point.X * 16 + 8), (float) (point.Y * 16 + 15 + 16)) - vector2, player.velocity, player.width, player.height, (int) player.gravDir) && !flag3 && (double) point.Y < Main.worldSurface)
            point.Y += num1;
          else if (tile2.liquid > (byte) 0)
          {
            point.X += crawlOffsetX;
            ++num7;
          }
          else if (TeleportHelpers.TileIsDangerous(point.X, point.Y))
          {
            point.X += crawlOffsetX;
            ++num7;
          }
          else if (TeleportHelpers.TileIsDangerous(point.X, point.Y + num3))
          {
            point.X += crawlOffsetX;
            ++num7;
          }
          else if (point.Y < num6)
            point.Y += num1;
          else
            break;
        }
      }
      if (num4 == num5 || num7 >= num8 || !WorldGen.InWorld(point.X, point.Y, 40))
        return false;
      landingPoint = point;
      return true;
    }

    private static bool TileIsDangerous(int x, int y)
    {
      Tile tile = Main.tile[x, y];
      return tile.liquid > (byte) 0 && tile.lava() || tile.wall == (ushort) 87 && (double) y > Main.worldSurface && !NPC.downedPlantBoss || Main.wallDungeon[(int) tile.wall] && (double) y > Main.worldSurface && !NPC.downedBoss3;
    }

    private static bool IsInSolidTilesExtended(
      Vector2 testPosition,
      Vector2 playerVelocity,
      int width,
      int height,
      int gravDir)
    {
      if (Collision.LavaCollision(testPosition, width, height) || (double) Collision.HurtTiles(testPosition, playerVelocity, width, height).Y > 0.0 || Collision.SolidCollision(testPosition, width, height))
        return true;
      Vector2 Velocity1 = Vector2.UnitX * 16f;
      if (Collision.TileCollision(testPosition - Velocity1, Velocity1, width, height, gravDir: gravDir) != Velocity1)
        return true;
      Vector2 Velocity2 = -Vector2.UnitX * 16f;
      if (Collision.TileCollision(testPosition - Velocity2, Velocity2, width, height, gravDir: gravDir) != Velocity2)
        return true;
      Vector2 Velocity3 = Vector2.UnitY * 16f;
      if (Collision.TileCollision(testPosition - Velocity3, Velocity3, width, height, gravDir: gravDir) != Velocity3)
        return true;
      Vector2 Velocity4 = -Vector2.UnitY * 16f;
      return Collision.TileCollision(testPosition - Velocity4, Velocity4, width, height, gravDir: gravDir) != Velocity4;
    }
  }
}
