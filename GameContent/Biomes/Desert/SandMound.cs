// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.Desert.SandMound
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.GameContent.Biomes.Desert
{
  public static class SandMound
  {
    public static void Place(DesertDescription description)
    {
      Rectangle desert1 = description.Desert;
      desert1.Height = Math.Min(description.Desert.Height, description.Hive.Height / 2);
      Rectangle desert2 = description.Desert;
      desert2.Y = desert1.Bottom;
      desert2.Height = Math.Max(0, description.Desert.Bottom - desert1.Bottom);
      SurfaceMap surface = description.Surface;
      int num1 = 0;
      int num2 = 0;
      for (int index1 = -5; index1 < desert1.Width + 5; ++index1)
      {
        float num3 = MathHelper.Clamp((float) ((double) Math.Abs((float) (index1 + 5) / (float) (desert1.Width + 10)) * 2.0 - 1.0), -1f, 1f);
        if (index1 % 3 == 0)
          num1 = Utils.Clamp<int>(num1 + WorldGen.genRand.Next(-1, 2), -10, 10);
        num2 = Utils.Clamp<int>(num2 + WorldGen.genRand.Next(-1, 2), -10, 10);
        float num4 = (float) Math.Sqrt(1.0 - (double) num3 * (double) num3 * (double) num3 * (double) num3);
        int num5 = desert1.Bottom - (int) ((double) num4 * (double) desert1.Height) + num1;
        if ((double) Math.Abs(num3) < 1.0)
        {
          float num6 = Utils.UnclampedSmoothStep(0.5f, 0.8f, Math.Abs(num3));
          float num7 = num6 * num6 * num6;
          int num8 = Math.Min(10 + (int) ((double) desert1.Top - (double) num7 * 20.0) + num2, num5);
          for (int index2 = (int) surface[index1 + desert1.X] - 1; index2 < num8; ++index2)
          {
            int index3 = index1 + desert1.X;
            int index4 = index2;
            Main.tile[index3, index4].active(false);
            Main.tile[index3, index4].wall = (ushort) 0;
          }
        }
        SandMound.PlaceSandColumn(index1 + desert1.X, num5, desert2.Bottom - num5);
      }
    }

    private static void PlaceSandColumn(int startX, int startY, int height)
    {
      for (int index = startY + height - 1; index >= startY; --index)
      {
        int i = startX;
        int j = index;
        Tile tile1 = Main.tile[i, j];
        tile1.liquid = (byte) 0;
        Tile tile2 = Main.tile[i, j + 1];
        Tile tile3 = Main.tile[i, j + 2];
        tile1.type = (ushort) 53;
        tile1.slope((byte) 0);
        tile1.halfBrick(false);
        tile1.active(true);
        if (index < startY)
          tile1.active(false);
        WorldGen.SquareWallFrame(i, j);
      }
    }
  }
}
