// Decompiled with JetBrains decompiler
// Type: Terraria.Rain
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.Graphics.Effects;

namespace Terraria
{
  public class Rain
  {
    public Vector2 position;
    public Vector2 velocity;
    public float scale;
    public float rotation;
    public int alpha;
    public bool active;
    public byte type;

    public static void ClearRain()
    {
      for (int index = 0; index < Main.maxRain; ++index)
        Main.rain[index].active = false;
    }

    public static void MakeRain()
    {
      if (Main.netMode == 2 || Main.gamePaused || (double) Main.screenPosition.Y > Main.worldSurface * 16.0 || Main.gameMenu)
        return;
      float num1 = (float) Main.screenWidth / 1920f * 25f * (float) (0.25 + 1.0 * (double) Main.cloudAlpha);
      if (Filters.Scene["Sandstorm"].IsActive())
        return;
      for (int index = 0; (double) index < (double) num1; ++index)
      {
        int num2 = 600;
        if ((double) Main.player[Main.myPlayer].velocity.Y < 0.0)
          num2 += (int) ((double) Math.Abs(Main.player[Main.myPlayer].velocity.Y) * 30.0);
        Vector2 Position;
        Position.X = (float) Main.rand.Next((int) Main.screenPosition.X - num2, (int) Main.screenPosition.X + Main.screenWidth + num2);
        Position.Y = Main.screenPosition.Y - (float) Main.rand.Next(20, 100);
        Position.X -= (float) ((double) Main.windSpeedCurrent * 15.0 * 40.0);
        Position.X += Main.player[Main.myPlayer].velocity.X * 40f;
        if ((double) Position.X < 0.0)
          Position.X = 0.0f;
        if ((double) Position.X > (double) ((Main.maxTilesX - 1) * 16))
          Position.X = (float) ((Main.maxTilesX - 1) * 16);
        int i = (int) Position.X / 16;
        int j = (int) Position.Y / 16;
        if (i < 0)
          i = 0;
        if (i > Main.maxTilesX - 1)
          i = Main.maxTilesX - 1;
        if (j < 0)
          j = 0;
        if (j > Main.maxTilesY - 1)
          j = Main.maxTilesY - 1;
        if (Main.gameMenu || !WorldGen.SolidTile(i, j) && Main.tile[i, j].wall <= (ushort) 0)
        {
          Vector2 Velocity = new Vector2(Main.windSpeedCurrent * 18f, 14f);
          Rain.NewRain(Position, Velocity);
        }
      }
    }

    public void Update()
    {
      if (Main.gamePaused)
        return;
      this.position += this.velocity;
      if (Main.gameMenu)
      {
        if ((double) this.position.Y <= (double) Main.screenPosition.Y + (double) Main.screenHeight + 2000.0)
          return;
        this.active = false;
      }
      else
      {
        if (!Collision.SolidCollision(this.position, 2, 2) && (double) this.position.Y <= (double) Main.screenPosition.Y + (double) Main.screenHeight + 100.0 && !Collision.WetCollision(this.position, 2, 2))
          return;
        this.active = false;
        if ((double) Main.rand.Next(100) >= (double) Main.gfxQuality * 100.0)
          return;
        int index = Dust.NewDust(this.position - this.velocity, 2, 2, Dust.dustWater());
        Main.dust[index].position.X -= 2f;
        Main.dust[index].position.Y += 2f;
        Main.dust[index].alpha = 38;
        Main.dust[index].velocity *= 0.1f;
        Main.dust[index].velocity += -this.velocity * 0.025f;
        Main.dust[index].velocity.Y -= 2f;
        Main.dust[index].scale = 0.6f;
        Main.dust[index].noGravity = true;
      }
    }

    private static int NewRain(Vector2 Position, Vector2 Velocity)
    {
      int index1 = -1;
      int num1 = (int) ((double) Main.maxRain * (double) Main.cloudAlpha);
      if (num1 > Main.maxRain)
        num1 = Main.maxRain;
      float num2 = (float) Main.maxTilesX / 6400f;
      double num3 = (double) Math.Max(0.0f, Math.Min(1f, (float) (((double) Main.player[Main.myPlayer].position.Y / 16.0 - 85.0 * (double) num2) / (60.0 * (double) num2))));
      float num4 = (float) ((1.0 + (double) Main.gfxQuality) / 2.0);
      if ((double) num4 < 0.9)
        num1 = (int) ((double) num1 * (double) num4);
      float num5 = (float) (800 - Main.SceneMetrics.SnowTileCount);
      if ((double) num5 < 0.0)
        num5 = 0.0f;
      float num6 = num5 / 800f;
      int num7 = (int) ((double) (int) ((double) num1 * (double) num6) * Math.Pow((double) Main.atmo, 9.0));
      if ((double) Main.atmo < 0.4)
        num7 = 0;
      for (int index2 = 0; index2 < num7; ++index2)
      {
        if (!Main.rain[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
        return Main.maxRain;
      Rain rain = Main.rain[index1];
      rain.active = true;
      rain.position = Position;
      rain.scale = (float) (1.0 + (double) Main.rand.Next(-20, 21) * 0.00999999977648258);
      rain.velocity = Velocity * rain.scale;
      rain.rotation = (float) Math.Atan2((double) rain.velocity.X, -(double) rain.velocity.Y);
      rain.type = (byte) (Main.waterStyle * 3 + Main.rand.Next(3));
      return index1;
    }
  }
}
