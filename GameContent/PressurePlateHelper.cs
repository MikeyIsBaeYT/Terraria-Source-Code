// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PressurePlateHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.GameContent
{
  public class PressurePlateHelper
  {
    public static Dictionary<Point, bool[]> PressurePlatesPressed = new Dictionary<Point, bool[]>();
    public static bool NeedsFirstUpdate;
    private static Vector2[] PlayerLastPosition = new Vector2[(int) byte.MaxValue];
    private static Rectangle pressurePlateBounds = new Rectangle(0, 0, 16, 10);

    public static void Update()
    {
      if (!PressurePlateHelper.NeedsFirstUpdate)
        return;
      foreach (Point key in PressurePlateHelper.PressurePlatesPressed.Keys)
        PressurePlateHelper.PokeLocation(key);
      PressurePlateHelper.PressurePlatesPressed.Clear();
      PressurePlateHelper.NeedsFirstUpdate = false;
    }

    public static void Reset()
    {
      PressurePlateHelper.PressurePlatesPressed.Clear();
      for (int index = 0; index < PressurePlateHelper.PlayerLastPosition.Length; ++index)
        PressurePlateHelper.PlayerLastPosition[index] = Vector2.Zero;
    }

    public static void ResetPlayer(int player)
    {
      foreach (Point location in PressurePlateHelper.PressurePlatesPressed.Keys.ToArray<Point>())
        PressurePlateHelper.MoveAwayFrom(location, player);
    }

    public static void UpdatePlayerPosition(Player player)
    {
      Point p = new Point(1, 1);
      Vector2 vector2 = p.ToVector2();
      List<Point> tilesIn1 = Collision.GetTilesIn(PressurePlateHelper.PlayerLastPosition[player.whoAmI] + vector2, PressurePlateHelper.PlayerLastPosition[player.whoAmI] + player.Size - vector2 * 2f);
      List<Point> tilesIn2 = Collision.GetTilesIn(player.TopLeft + vector2, player.BottomRight - vector2 * 2f);
      Rectangle hitbox1 = player.Hitbox;
      Rectangle hitbox2 = player.Hitbox;
      hitbox1.Inflate(-p.X, -p.Y);
      hitbox2.Inflate(-p.X, -p.Y);
      hitbox2.X = (int) PressurePlateHelper.PlayerLastPosition[player.whoAmI].X;
      hitbox2.Y = (int) PressurePlateHelper.PlayerLastPosition[player.whoAmI].Y;
      for (int index = 0; index < tilesIn1.Count; ++index)
      {
        Point location = tilesIn1[index];
        Tile tile = Main.tile[location.X, location.Y];
        if (tile.active() && tile.type == (ushort) 428)
        {
          PressurePlateHelper.pressurePlateBounds.X = location.X * 16;
          PressurePlateHelper.pressurePlateBounds.Y = location.Y * 16 + 16 - PressurePlateHelper.pressurePlateBounds.Height;
          if (!hitbox1.Intersects(PressurePlateHelper.pressurePlateBounds) && !tilesIn2.Contains(location))
            PressurePlateHelper.MoveAwayFrom(location, player.whoAmI);
        }
      }
      for (int index = 0; index < tilesIn2.Count; ++index)
      {
        Point location = tilesIn2[index];
        Tile tile = Main.tile[location.X, location.Y];
        if (tile.active() && tile.type == (ushort) 428)
        {
          PressurePlateHelper.pressurePlateBounds.X = location.X * 16;
          PressurePlateHelper.pressurePlateBounds.Y = location.Y * 16 + 16 - PressurePlateHelper.pressurePlateBounds.Height;
          if (hitbox1.Intersects(PressurePlateHelper.pressurePlateBounds) && (!tilesIn1.Contains(location) || !hitbox2.Intersects(PressurePlateHelper.pressurePlateBounds)))
            PressurePlateHelper.MoveInto(location, player.whoAmI);
        }
      }
      PressurePlateHelper.PlayerLastPosition[player.whoAmI] = player.position;
    }

    public static void DestroyPlate(Point location)
    {
      if (!PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out bool[] _))
        return;
      PressurePlateHelper.PressurePlatesPressed.Remove(location);
      PressurePlateHelper.PokeLocation(location);
    }

    private static void UpdatePlatePosition(Point location, int player, bool onIt)
    {
      if (onIt)
        PressurePlateHelper.MoveInto(location, player);
      else
        PressurePlateHelper.MoveAwayFrom(location, player);
    }

    private static void MoveInto(Point location, int player)
    {
      bool[] flagArray;
      if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out flagArray))
      {
        flagArray[player] = true;
      }
      else
      {
        PressurePlateHelper.PressurePlatesPressed[location] = new bool[(int) byte.MaxValue];
        PressurePlateHelper.PressurePlatesPressed[location][player] = true;
        PressurePlateHelper.PokeLocation(location);
      }
    }

    private static void MoveAwayFrom(Point location, int player)
    {
      bool[] flagArray;
      if (!PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out flagArray))
        return;
      flagArray[player] = false;
      bool flag = false;
      for (int index = 0; index < flagArray.Length; ++index)
      {
        if (flagArray[index])
        {
          flag = true;
          break;
        }
      }
      if (flag)
        return;
      PressurePlateHelper.PressurePlatesPressed.Remove(location);
      PressurePlateHelper.PokeLocation(location);
    }

    private static void PokeLocation(Point location)
    {
      if (Main.netMode == 1)
        return;
      Wiring.blockPlayerTeleportationForOneIteration = true;
      Wiring.HitSwitch(location.X, location.Y);
      NetMessage.SendData(59, number: location.X, number2: ((float) location.Y));
    }
  }
}
