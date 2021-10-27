// Decompiled with JetBrains decompiler
// Type: Terraria.Rain
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
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

    public static void MakeRain()
    {
      if ((double) Main.screenPosition.Y > Main.worldSurface * 16.0 || Main.gameMenu)
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
        Position.X -= (float) ((double) Main.windSpeed * 15.0 * 40.0);
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
        if (Main.gameMenu || !WorldGen.SolidTile(i, j) && Main.tile[i, j].wall <= (byte) 0)
        {
          Vector2 Velocity = new Vector2(Main.windSpeed * 12f, 14f);
          Rain.NewRain(Position, Velocity);
        }
      }
    }

    public void Update()
    {
      this.position += this.velocity;
      if (!Collision.SolidCollision(this.position, 2, 2) && (double) this.position.Y <= (double) Main.screenPosition.Y + (double) Main.screenHeight + 100.0 && !Collision.WetCollision(this.position, 2, 2))
        return;
      this.active = false;
      if ((double) Main.rand.Next(100) >= (double) Main.gfxQuality * 100.0)
        return;
      int Type = 154;
      if (this.type == (byte) 3 || this.type == (byte) 4 || this.type == (byte) 5)
        Type = 218;
      int index = Dust.NewDust(this.position - this.velocity, 2, 2, Type);
      Main.dust[index].position.X -= 2f;
      Main.dust[index].alpha = 38;
      Main.dust[index].velocity *= 0.1f;
      Main.dust[index].velocity += -this.velocity * 0.025f;
      Main.dust[index].scale = 0.75f;
    }

    public static int NewRain(Vector2 Position, Vector2 Velocity)
    {
      int index1 = -1;
      int num1 = (int) ((double) Main.maxRain * (double) Main.cloudAlpha);
      if (num1 > Main.maxRain)
        num1 = Main.maxRain;
      float num2 = (float) Main.maxTilesX / 6400f;
      float num3 = Math.Max(0.0f, Math.Min(1f, (float) (((double) Main.player[Main.myPlayer].position.Y / 16.0 - 85.0 * (double) num2) / (60.0 * (double) num2))));
      float num4 = num3 * num3;
      int num5 = (int) ((double) num1 * (double) num4);
      float num6 = (float) ((1.0 + (double) Main.gfxQuality) / 2.0);
      if ((double) num6 < 0.9)
        num5 = (int) ((double) num5 * (double) num6);
      float num7 = (float) (800 - Main.snowTiles);
      if ((double) num7 < 0.0)
        num7 = 0.0f;
      float num8 = num7 / 800f;
      int num9 = (int) ((double) num5 * (double) num8);
      for (int index2 = 0; index2 < num9; ++index2)
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
      rain.type = (byte) Main.rand.Next(3);
      if (Main.bloodMoon)
        rain.type += (byte) 3;
      return index1;
    }
  }
}
