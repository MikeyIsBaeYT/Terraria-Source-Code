// Decompiled with JetBrains decompiler
// Type: Terraria.DelegateMethods
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace Terraria
{
  public static class DelegateMethods
  {
    public static Vector3 v3_1 = Vector3.Zero;
    public static Vector2 v2_1 = Vector2.Zero;
    public static float f_1 = 0.0f;
    public static Color c_1 = Color.Transparent;
    public static int i_1;
    public static TileCuttingContext tilecut_0 = TileCuttingContext.Unknown;

    public static Color ColorLerp_BlackToWhite(float percent) => Color.Lerp(Color.Black, Color.White, percent);

    public static Color ColorLerp_HSL_H(float percent) => Main.hslToRgb(percent, 1f, 0.5f);

    public static Color ColorLerp_HSL_S(float percent) => Main.hslToRgb(DelegateMethods.v3_1.X, percent, DelegateMethods.v3_1.Z);

    public static Color ColorLerp_HSL_L(float percent) => Main.hslToRgb(DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, (float) (0.150000005960464 + 0.850000023841858 * (double) percent));

    public static Color ColorLerp_HSL_O(float percent) => Color.Lerp(Color.White, Main.hslToRgb(DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z), percent);

    public static bool SpreadDirt(int x, int y)
    {
      if ((double) Vector2.Distance(DelegateMethods.v2_1, new Vector2((float) x, (float) y)) > (double) DelegateMethods.f_1 || !WorldGen.PlaceTile(x, y, 0))
        return false;
      if (Main.netMode != 0)
        NetMessage.SendData(17, number: 1, number2: ((float) x), number3: ((float) y));
      Vector2 Position = new Vector2((float) (x * 16), (float) (y * 16));
      int Type = 0;
      for (int index = 0; index < 3; ++index)
      {
        Dust dust1 = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 2.2f);
        dust1.noGravity = true;
        dust1.velocity.Y -= 1.2f;
        dust1.velocity *= 4f;
        Dust dust2 = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 1.3f);
        dust2.velocity.Y -= 1.2f;
        dust2.velocity *= 2f;
      }
      int i = x;
      int j1 = y + 1;
      if (Main.tile[i, j1] != null && !TileID.Sets.Platforms[(int) Main.tile[i, j1].type] && (Main.tile[i, j1].topSlope() || Main.tile[i, j1].halfBrick()))
      {
        WorldGen.SlopeTile(i, j1);
        if (Main.netMode != 0)
          NetMessage.SendData(17, number: 14, number2: ((float) i), number3: ((float) j1));
      }
      int j2 = y - 1;
      if (Main.tile[i, j2] != null && !TileID.Sets.Platforms[(int) Main.tile[i, j2].type] && Main.tile[i, j2].bottomSlope())
      {
        WorldGen.SlopeTile(i, j2);
        if (Main.netMode != 0)
          NetMessage.SendData(17, number: 14, number2: ((float) i), number3: ((float) j2));
      }
      return true;
    }

    public static bool SpreadWater(int x, int y)
    {
      if ((double) Vector2.Distance(DelegateMethods.v2_1, new Vector2((float) x, (float) y)) > (double) DelegateMethods.f_1 || !WorldGen.PlaceLiquid(x, y, (byte) 0, byte.MaxValue))
        return false;
      Vector2 Position = new Vector2((float) (x * 16), (float) (y * 16));
      int Type = Dust.dustWater();
      for (int index = 0; index < 3; ++index)
      {
        Dust dust1 = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 2.2f);
        dust1.noGravity = true;
        dust1.velocity.Y -= 1.2f;
        dust1.velocity *= 7f;
        Dust dust2 = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 1.3f);
        dust2.velocity.Y -= 1.2f;
        dust2.velocity *= 4f;
      }
      return true;
    }

    public static bool SpreadHoney(int x, int y)
    {
      if ((double) Vector2.Distance(DelegateMethods.v2_1, new Vector2((float) x, (float) y)) > (double) DelegateMethods.f_1 || !WorldGen.PlaceLiquid(x, y, (byte) 2, byte.MaxValue))
        return false;
      Vector2 Position = new Vector2((float) (x * 16), (float) (y * 16));
      int Type = 152;
      for (int index = 0; index < 3; ++index)
      {
        Dust dust1 = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 2.2f);
        dust1.velocity.Y -= 1.2f;
        dust1.velocity *= 7f;
        Dust dust2 = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 1.3f);
        dust2.velocity.Y -= 1.2f;
        dust2.velocity *= 4f;
      }
      return true;
    }

    public static bool SpreadLava(int x, int y)
    {
      if ((double) Vector2.Distance(DelegateMethods.v2_1, new Vector2((float) x, (float) y)) > (double) DelegateMethods.f_1 || !WorldGen.PlaceLiquid(x, y, (byte) 1, byte.MaxValue))
        return false;
      Vector2 Position = new Vector2((float) (x * 16), (float) (y * 16));
      int Type = 35;
      for (int index = 0; index < 3; ++index)
      {
        Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 1.2f).velocity *= 7f;
        Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 0.8f).velocity *= 4f;
      }
      return true;
    }

    public static bool SpreadDry(int x, int y)
    {
      if ((double) Vector2.Distance(DelegateMethods.v2_1, new Vector2((float) x, (float) y)) > (double) DelegateMethods.f_1 || !WorldGen.EmptyLiquid(x, y))
        return false;
      Vector2 Position = new Vector2((float) (x * 16), (float) (y * 16));
      int Type = 31;
      for (int index = 0; index < 3; ++index)
      {
        Dust dust = Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 1.2f);
        dust.noGravity = true;
        dust.velocity *= 7f;
        Dust.NewDustDirect(Position, 16, 16, Type, Alpha: 100, newColor: Color.Transparent, Scale: 0.8f).velocity *= 4f;
      }
      return true;
    }

    public static bool SpreadTest(int x, int y)
    {
      Tile tile = Main.tile[x, y];
      if (!WorldGen.SolidTile(x, y) && tile.wall == (ushort) 0)
        return true;
      tile.active();
      return false;
    }

    public static bool TestDust(int x, int y)
    {
      if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
        return false;
      int index = Dust.NewDust(new Vector2((float) x, (float) y) * 16f + new Vector2(8f), 0, 0, 6);
      Main.dust[index].noGravity = true;
      Main.dust[index].noLight = true;
      return true;
    }

    public static bool CastLight(int x, int y)
    {
      if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY || Main.tile[x, y] == null)
        return false;
      Lighting.AddLight(x, y, DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z);
      return true;
    }

    public static bool CastLightOpen(int x, int y)
    {
      if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY || Main.tile[x, y] == null)
        return false;
      if (!Main.tile[x, y].active() || Main.tile[x, y].inActive() || Main.tileSolidTop[(int) Main.tile[x, y].type] || !Main.tileSolid[(int) Main.tile[x, y].type])
        Lighting.AddLight(x, y, DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z);
      return true;
    }

    public static bool CastLightOpen_StopForSolids_ScaleWithDistance(int x, int y)
    {
      if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY || Main.tile[x, y] == null || Main.tile[x, y].active() && !Main.tile[x, y].inActive() && !Main.tileSolidTop[(int) Main.tile[x, y].type] && Main.tileSolid[(int) Main.tile[x, y].type])
        return false;
      Vector3 v31 = DelegateMethods.v3_1;
      Vector2 vector2 = new Vector2((float) x, (float) y);
      float num = Vector2.Distance(DelegateMethods.v2_1, vector2);
      Vector3 vector3 = v31 * MathHelper.Lerp(0.65f, 1f, num / DelegateMethods.f_1);
      Lighting.AddLight(x, y, vector3.X, vector3.Y, vector3.Z);
      return true;
    }

    public static bool EmitGolfCartDust_StopForSolids(int x, int y)
    {
      if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY || Main.tile[x, y] == null || Main.tile[x, y].active() && !Main.tile[x, y].inActive() && !Main.tileSolidTop[(int) Main.tile[x, y].type] && Main.tileSolid[(int) Main.tile[x, y].type])
        return false;
      Dust.NewDustPerfect(new Vector2((float) (x * 16 + 8), (float) (y * 16 + 8)), 260, new Vector2?(Vector2.UnitY * -0.2f));
      return true;
    }

    public static bool NotDoorStand(int x, int y)
    {
      if (Main.tile[x, y] == null || !Main.tile[x, y].active() || Main.tile[x, y].type != (ushort) 11)
        return true;
      return Main.tile[x, y].frameX >= (short) 18 && Main.tile[x, y].frameX < (short) 54;
    }

    public static bool CutTiles(int x, int y)
    {
      if (!WorldGen.InWorld(x, y, 1) || Main.tile[x, y] == null)
        return false;
      if (!Main.tileCut[(int) Main.tile[x, y].type] || !WorldGen.CanCutTile(x, y, DelegateMethods.tilecut_0))
        return true;
      WorldGen.KillTile(x, y);
      if (Main.netMode != 0)
        NetMessage.SendData(17, number2: ((float) x), number3: ((float) y));
      return true;
    }

    public static bool SearchAvoidedByNPCs(int x, int y) => WorldGen.InWorld(x, y, 1) && Main.tile[x, y] != null && (!Main.tile[x, y].active() || !TileID.Sets.AvoidedByNPCs[(int) Main.tile[x, y].type]);

    public static void RainbowLaserDraw(
      int stage,
      Vector2 currentPosition,
      float distanceLeft,
      Rectangle lastFrame,
      out float distCovered,
      out Rectangle frame,
      out Vector2 origin,
      out Color color)
    {
      color = DelegateMethods.c_1;
      switch (stage)
      {
        case 0:
          distCovered = 33f;
          frame = new Rectangle(0, 0, 26, 22);
          origin = frame.Size() / 2f;
          break;
        case 1:
          frame = new Rectangle(0, 25, 26, 28);
          distCovered = (float) frame.Height;
          origin = new Vector2((float) (frame.Width / 2), 0.0f);
          break;
        case 2:
          distCovered = 22f;
          frame = new Rectangle(0, 56, 26, 22);
          origin = new Vector2((float) (frame.Width / 2), 1f);
          break;
        default:
          distCovered = 9999f;
          frame = Rectangle.Empty;
          origin = Vector2.Zero;
          color = Color.Transparent;
          break;
      }
    }

    public static void TurretLaserDraw(
      int stage,
      Vector2 currentPosition,
      float distanceLeft,
      Rectangle lastFrame,
      out float distCovered,
      out Rectangle frame,
      out Vector2 origin,
      out Color color)
    {
      color = DelegateMethods.c_1;
      switch (stage)
      {
        case 0:
          distCovered = 32f;
          frame = new Rectangle(0, 0, 22, 20);
          origin = frame.Size() / 2f;
          break;
        case 1:
          ++DelegateMethods.i_1;
          int num = DelegateMethods.i_1 % 5;
          frame = new Rectangle(0, 22 * (num + 1), 22, 20);
          distCovered = (float) (frame.Height - 1);
          origin = new Vector2((float) (frame.Width / 2), 0.0f);
          break;
        case 2:
          frame = new Rectangle(0, 154, 22, 30);
          distCovered = (float) frame.Height;
          origin = new Vector2((float) (frame.Width / 2), 1f);
          break;
        default:
          distCovered = 9999f;
          frame = Rectangle.Empty;
          origin = Vector2.Zero;
          color = Color.Transparent;
          break;
      }
    }

    public static void LightningLaserDraw(
      int stage,
      Vector2 currentPosition,
      float distanceLeft,
      Rectangle lastFrame,
      out float distCovered,
      out Rectangle frame,
      out Vector2 origin,
      out Color color)
    {
      color = DelegateMethods.c_1 * DelegateMethods.f_1;
      switch (stage)
      {
        case 0:
          distCovered = 0.0f;
          frame = new Rectangle(0, 0, 21, 8);
          origin = frame.Size() / 2f;
          break;
        case 1:
          frame = new Rectangle(0, 8, 21, 6);
          distCovered = (float) frame.Height;
          origin = new Vector2((float) (frame.Width / 2), 0.0f);
          break;
        case 2:
          distCovered = 8f;
          frame = new Rectangle(0, 14, 21, 8);
          origin = new Vector2((float) (frame.Width / 2), 2f);
          break;
        default:
          distCovered = 9999f;
          frame = Rectangle.Empty;
          origin = Vector2.Zero;
          color = Color.Transparent;
          break;
      }
    }

    public static int CompareYReverse(Point a, Point b) => b.Y.CompareTo(a.Y);

    public static int CompareDrawSorterByYScale(DrawData a, DrawData b) => a.scale.Y.CompareTo(b.scale.Y);

    public static class Minecart
    {
      public static Vector2 rotationOrigin;
      public static float rotation;

      public static void Sparks(Vector2 dustPosition)
      {
        dustPosition += new Vector2(Main.rand.Next(2) == 0 ? 13f : -13f, 0.0f).RotatedBy((double) DelegateMethods.Minecart.rotation);
        int index = Dust.NewDust(dustPosition, 1, 1, 213, (float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3));
        Main.dust[index].noGravity = true;
        Main.dust[index].fadeIn = (float) ((double) Main.dust[index].scale + 1.0 + 0.00999999977648258 * (double) Main.rand.Next(0, 51));
        Main.dust[index].noGravity = true;
        Main.dust[index].velocity *= (float) Main.rand.Next(15, 51) * 0.01f;
        Main.dust[index].velocity.X *= (float) Main.rand.Next(25, 101) * 0.01f;
        Main.dust[index].velocity.Y -= (float) Main.rand.Next(15, 31) * 0.1f;
        Main.dust[index].position.Y -= 4f;
        if (Main.rand.Next(3) != 0)
          Main.dust[index].noGravity = false;
        else
          Main.dust[index].scale *= 0.6f;
      }

      public static void LandingSound(Vector2 Position, int Width, int Height) => SoundEngine.PlaySound(SoundID.Item53, (int) Position.X + Width / 2, (int) Position.Y + Height / 2);

      public static void BumperSound(Vector2 Position, int Width, int Height) => SoundEngine.PlaySound(SoundID.Item56, (int) Position.X + Width / 2, (int) Position.Y + Height / 2);

      public static void SparksMech(Vector2 dustPosition)
      {
        dustPosition += new Vector2(Main.rand.Next(2) == 0 ? 13f : -13f, 0.0f).RotatedBy((double) DelegateMethods.Minecart.rotation);
        int index = Dust.NewDust(dustPosition, 1, 1, 260, (float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3));
        Main.dust[index].noGravity = true;
        Main.dust[index].fadeIn = (float) ((double) Main.dust[index].scale + 0.5 + 0.00999999977648258 * (double) Main.rand.Next(0, 51));
        Main.dust[index].noGravity = true;
        Main.dust[index].velocity *= (float) Main.rand.Next(15, 51) * 0.01f;
        Main.dust[index].velocity.X *= (float) Main.rand.Next(25, 101) * 0.01f;
        Main.dust[index].velocity.Y -= (float) Main.rand.Next(15, 31) * 0.1f;
        Main.dust[index].position.Y -= 4f;
        if (Main.rand.Next(3) != 0)
          Main.dust[index].noGravity = false;
        else
          Main.dust[index].scale *= 0.6f;
      }

      public static void SparksMeow(Vector2 dustPosition)
      {
        dustPosition += new Vector2(Main.rand.Next(2) == 0 ? 13f : -13f, 0.0f).RotatedBy((double) DelegateMethods.Minecart.rotation);
        int index = Dust.NewDust(dustPosition, 1, 1, 213, (float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3));
        Main.dust[index].shader = GameShaders.Armor.GetShaderFromItemId(2870);
        Main.dust[index].noGravity = true;
        Main.dust[index].fadeIn = (float) ((double) Main.dust[index].scale + 1.0 + 0.00999999977648258 * (double) Main.rand.Next(0, 51));
        Main.dust[index].noGravity = true;
        Main.dust[index].velocity *= (float) Main.rand.Next(15, 51) * 0.01f;
        Main.dust[index].velocity.X *= (float) Main.rand.Next(25, 101) * 0.01f;
        Main.dust[index].velocity.Y -= (float) Main.rand.Next(15, 31) * 0.1f;
        Main.dust[index].position.Y -= 4f;
        if (Main.rand.Next(3) != 0)
          Main.dust[index].noGravity = false;
        else
          Main.dust[index].scale *= 0.6f;
      }
    }
  }
}
