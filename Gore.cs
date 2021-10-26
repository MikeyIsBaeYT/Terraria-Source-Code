// Decompiled with JetBrains decompiler
// Type: Terraria.Gore
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria
{
  public class Gore
  {
    public static int goreTime = 600;
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float scale;
    public int alpha;
    public int type;
    public float light;
    public bool active;
    public bool sticky = true;
    public int timeLeft = Gore.goreTime;
    public bool behindTiles;
    public byte frameCounter;
    public SpriteFrame Frame = new SpriteFrame((byte) 1, (byte) 1);

    public float Width => TextureAssets.Gore[this.type].IsLoaded ? this.scale * (float) this.Frame.GetSourceRectangle(TextureAssets.Gore[this.type].Value).Width : 1f;

    public float Height => TextureAssets.Gore[this.type].IsLoaded ? this.scale * (float) this.Frame.GetSourceRectangle(TextureAssets.Gore[this.type].Value).Height : 1f;

    public Rectangle AABBRectangle
    {
      get
      {
        if (!TextureAssets.Gore[this.type].IsLoaded)
          return new Rectangle(0, 0, 1, 1);
        Rectangle sourceRectangle = this.Frame.GetSourceRectangle(TextureAssets.Gore[this.type].Value);
        return new Rectangle((int) this.position.X, (int) this.position.Y, (int) ((double) sourceRectangle.Width * (double) this.scale), (int) ((double) sourceRectangle.Height * (double) this.scale));
      }
    }

    [Obsolete("Please use Frame instead.")]
    public byte frame
    {
      get => this.Frame.CurrentRow;
      set => this.Frame.CurrentRow = value;
    }

    [Obsolete("Please use Frame instead.")]
    public byte numFrames
    {
      get => this.Frame.RowCount;
      set => this.Frame = new SpriteFrame(this.Frame.ColumnCount, value)
      {
        CurrentColumn = this.Frame.CurrentColumn,
        CurrentRow = this.Frame.CurrentRow
      };
    }

    private void UpdateAmbientFloorCloud()
    {
      this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
      if (this.timeLeft <= 0)
      {
        this.active = false;
      }
      else
      {
        bool flag = false;
        Point tileCoordinates = (this.position + new Vector2(15f, 0.0f)).ToTileCoordinates();
        Tile testTile1 = Main.tile[tileCoordinates.X, tileCoordinates.Y];
        Tile testTile2 = Main.tile[tileCoordinates.X, tileCoordinates.Y + 1];
        Tile testTile3 = Main.tile[tileCoordinates.X, tileCoordinates.Y + 2];
        if (testTile1 == null || testTile2 == null || testTile3 == null)
        {
          this.active = false;
        }
        else
        {
          if (WorldGen.SolidTile(testTile1) || !WorldGen.SolidTile(testTile2) && !WorldGen.SolidTile(testTile3))
            flag = true;
          if (this.timeLeft <= 30)
            flag = true;
          this.velocity.X = 0.4f * Main.WindForVisuals;
          if (!flag)
          {
            if (this.alpha > 220)
              --this.alpha;
          }
          else
          {
            ++this.alpha;
            if (this.alpha >= (int) byte.MaxValue)
            {
              this.active = false;
              return;
            }
          }
          this.position += this.velocity;
        }
      }
    }

    private void UpdateAmbientAirborneCloud()
    {
      this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
      if (this.timeLeft <= 0)
      {
        this.active = false;
      }
      else
      {
        bool flag = false;
        Point tileCoordinates = (this.position + new Vector2(15f, 0.0f)).ToTileCoordinates();
        this.rotation = this.velocity.ToRotation();
        Tile testTile = Main.tile[tileCoordinates.X, tileCoordinates.Y];
        if (testTile == null)
        {
          this.active = false;
        }
        else
        {
          if (WorldGen.SolidTile(testTile))
            flag = true;
          if (this.timeLeft <= 60)
            flag = true;
          if (!flag)
          {
            if (this.alpha > 240 && Main.rand.Next(5) == 0)
              --this.alpha;
          }
          else
          {
            if (Main.rand.Next(5) == 0)
              ++this.alpha;
            if (this.alpha >= (int) byte.MaxValue)
            {
              this.active = false;
              return;
            }
          }
          this.position += this.velocity;
        }
      }
    }

    private void UpdateFogMachineCloud()
    {
      this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
      if (this.timeLeft <= 0)
      {
        this.active = false;
      }
      else
      {
        bool flag = false;
        Point tileCoordinates = (this.position + new Vector2(15f, 0.0f)).ToTileCoordinates();
        if (WorldGen.SolidTile(Main.tile[tileCoordinates.X, tileCoordinates.Y]))
          flag = true;
        if (this.timeLeft <= 240)
          flag = true;
        if (!flag)
        {
          if (this.alpha > 225 && Main.rand.Next(2) == 0)
            --this.alpha;
        }
        else
        {
          if (Main.rand.Next(2) == 0)
            ++this.alpha;
          if (this.alpha >= (int) byte.MaxValue)
          {
            this.active = false;
            return;
          }
        }
        this.position += this.velocity;
      }
    }

    private void UpdateLightningBunnySparks()
    {
      if (this.frameCounter == (byte) 0)
      {
        this.frameCounter = (byte) 1;
        this.Frame.CurrentRow = (byte) Main.rand.Next(3);
      }
      this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
      if (this.timeLeft <= 0)
      {
        this.active = false;
      }
      else
      {
        this.alpha = (int) MathHelper.Lerp((float) byte.MaxValue, 0.0f, (float) this.timeLeft / 15f);
        float num = (float) (((double) byte.MaxValue - (double) this.alpha) / (double) byte.MaxValue) * this.scale;
        Lighting.AddLight(this.position + new Vector2(this.Width / 2f, this.Height / 2f), num * 0.4f, num, num);
        this.position += this.velocity;
      }
    }

    private float ChumFloatingChunk_GetWaterLine(int X, int Y)
    {
      float num = this.position.Y + this.Height;
      if (Main.tile[X, Y - 1] == null)
        Main.tile[X, Y - 1] = new Tile();
      if (Main.tile[X, Y] == null)
        Main.tile[X, Y] = new Tile();
      if (Main.tile[X, Y + 1] == null)
        Main.tile[X, Y + 1] = new Tile();
      if (Main.tile[X, Y - 1].liquid > (byte) 0)
        num = (float) (Y * 16) - (float) ((int) Main.tile[X, Y - 1].liquid / 16);
      else if (Main.tile[X, Y].liquid > (byte) 0)
        num = (float) ((Y + 1) * 16) - (float) ((int) Main.tile[X, Y].liquid / 16);
      else if (Main.tile[X, Y + 1].liquid > (byte) 0)
        num = (float) ((Y + 2) * 16) - (float) ((int) Main.tile[X, Y + 1].liquid / 16);
      return num;
    }

    public void Update()
    {
      if (Main.netMode == 2 || !this.active)
        return;
      switch (GoreID.Sets.SpecialAI[this.type])
      {
        case 4:
          this.UpdateAmbientFloorCloud();
          break;
        case 5:
          this.UpdateAmbientAirborneCloud();
          break;
        case 6:
          this.UpdateFogMachineCloud();
          break;
        case 7:
          this.UpdateLightningBunnySparks();
          break;
        default:
          if ((this.type == 1217 || this.type == 1218) && this.frameCounter == (byte) 0)
          {
            this.frameCounter = (byte) 1;
            this.Frame.CurrentRow = (byte) Main.rand.Next(3);
          }
          bool flag1 = this.type >= 1024 && this.type <= 1026;
          if (this.type >= 276 && this.type <= 282)
          {
            this.velocity.X *= 0.98f;
            this.velocity.Y *= 0.98f;
            if ((double) this.velocity.Y < (double) this.scale)
              this.velocity.Y += 0.05f;
            if ((double) this.velocity.Y > 0.1)
            {
              if ((double) this.velocity.X > 0.0)
                this.rotation += 0.01f;
              else
                this.rotation -= 0.01f;
            }
          }
          if (this.type >= 570 && this.type <= 572)
          {
            this.scale -= 1f / 1000f;
            if ((double) this.scale <= 0.01)
            {
              this.scale = 0.01f;
              this.timeLeft = 0;
            }
            this.sticky = false;
            this.rotation = this.velocity.X * 0.1f;
          }
          else if (this.type >= 706 && this.type <= 717 || this.type == 943 || this.type == 1147 || this.type >= 1160 && this.type <= 1162)
          {
            this.alpha = this.type == 943 || this.type >= 1160 && this.type <= 1162 ? 0 : ((double) this.position.Y >= Main.worldSurface * 16.0 + 8.0 ? 100 : 0);
            int num1 = 4;
            ++this.frameCounter;
            if (this.frame <= (byte) 4)
            {
              int x = (int) ((double) this.position.X / 16.0);
              int y = (int) ((double) this.position.Y / 16.0) - 1;
              if (WorldGen.InWorld(x, y) && !Main.tile[x, y].active())
                this.active = false;
              if (this.frame == (byte) 0)
                num1 = 24 + Main.rand.Next(256);
              if (this.frame == (byte) 1)
                num1 = 24 + Main.rand.Next(256);
              if (this.frame == (byte) 2)
                num1 = 24 + Main.rand.Next(256);
              if (this.frame == (byte) 3)
                num1 = 24 + Main.rand.Next(96);
              if (this.frame == (byte) 5)
                num1 = 16 + Main.rand.Next(64);
              if (this.type == 716)
                num1 *= 2;
              if (this.type == 717)
                num1 *= 4;
              if ((this.type == 943 || this.type >= 1160 && this.type <= 1162) && this.frame < (byte) 6)
                num1 = 4;
              if ((int) this.frameCounter >= num1)
              {
                this.frameCounter = (byte) 0;
                ++this.frame;
                if (this.frame == (byte) 5)
                {
                  int index = Gore.NewGore(this.position, this.velocity, this.type);
                  Main.gore[index].frame = (byte) 9;
                  Main.gore[index].velocity *= 0.0f;
                }
              }
            }
            else if (this.frame <= (byte) 6)
            {
              int num2 = 8;
              if (this.type == 716)
                num2 *= 2;
              if (this.type == 717)
                num2 *= 3;
              if ((int) this.frameCounter >= num2)
              {
                this.frameCounter = (byte) 0;
                ++this.frame;
                if (this.frame == (byte) 7)
                  this.active = false;
              }
            }
            else if (this.frame <= (byte) 9)
            {
              int num3 = 6;
              if (this.type == 716)
              {
                num3 = (int) ((double) num3 * 1.5);
                this.velocity.Y += 0.175f;
              }
              else if (this.type == 717)
              {
                num3 *= 2;
                this.velocity.Y += 0.15f;
              }
              else if (this.type == 943)
              {
                num3 = (int) ((double) num3 * 1.5);
                this.velocity.Y += 0.2f;
              }
              else
                this.velocity.Y += 0.2f;
              if ((double) this.velocity.Y < 0.5)
                this.velocity.Y = 0.5f;
              if ((double) this.velocity.Y > 12.0)
                this.velocity.Y = 12f;
              if ((int) this.frameCounter >= num3)
              {
                this.frameCounter = (byte) 0;
                ++this.frame;
              }
              if (this.frame > (byte) 9)
                this.frame = (byte) 7;
            }
            else
            {
              if (this.type == 716)
                num1 *= 2;
              else if (this.type == 717)
                num1 *= 6;
              this.velocity.Y += 0.1f;
              if ((int) this.frameCounter >= num1)
              {
                this.frameCounter = (byte) 0;
                ++this.frame;
              }
              this.velocity *= 0.0f;
              if (this.frame > (byte) 14)
                this.active = false;
            }
          }
          else if (this.type == 11 || this.type == 12 || this.type == 13 || this.type == 61 || this.type == 62 || this.type == 63 || this.type == 99 || this.type == 220 || this.type == 221 || this.type == 222 || this.type >= 375 && this.type <= 377 || this.type >= 435 && this.type <= 437 || this.type >= 861 && this.type <= 862)
          {
            this.velocity.Y *= 0.98f;
            this.velocity.X *= 0.98f;
            this.scale -= 0.007f;
            if ((double) this.scale < 0.1)
            {
              this.scale = 0.1f;
              this.alpha = (int) byte.MaxValue;
            }
          }
          else if (this.type == 16 || this.type == 17)
          {
            this.velocity.Y *= 0.98f;
            this.velocity.X *= 0.98f;
            this.scale -= 0.01f;
            if ((double) this.scale < 0.1)
            {
              this.scale = 0.1f;
              this.alpha = (int) byte.MaxValue;
            }
          }
          else if (this.type == 1201)
          {
            if (this.frameCounter == (byte) 0)
            {
              this.frameCounter = (byte) 1;
              this.Frame.CurrentRow = (byte) Main.rand.Next(4);
            }
            this.scale -= 1f / 500f;
            if ((double) this.scale < 0.1)
            {
              this.scale = 0.1f;
              this.alpha = (int) byte.MaxValue;
            }
            this.rotation += this.velocity.X * 0.1f;
            int index1 = (int) ((double) this.position.X + 6.0) / 16;
            int index2 = (int) ((double) this.position.Y - 6.0) / 16;
            if ((Main.tile[index1, index2] == null ? 0 : (Main.tile[index1, index2].liquid > (byte) 0 ? 1 : 0)) == 0)
            {
              this.velocity.Y += 0.2f;
              if ((double) this.velocity.Y < 0.0)
                this.velocity *= 0.92f;
            }
            else
            {
              this.velocity.Y += 0.005f;
              float num = this.velocity.Length();
              if ((double) num > 1.0)
                this.velocity *= 0.1f;
              else if ((double) num > 0.100000001490116)
                this.velocity *= 0.98f;
            }
          }
          else if (this.type == 1208)
          {
            if (this.frameCounter == (byte) 0)
            {
              this.frameCounter = (byte) 1;
              this.Frame.CurrentRow = (byte) Main.rand.Next(4);
            }
            Vector2 vector2 = this.position + new Vector2(this.Width, this.Height) / 2f;
            int index3 = (int) vector2.X / 16;
            int index4 = (int) vector2.Y / 16;
            bool flag2 = Main.tile[index3, index4] != null && Main.tile[index3, index4].liquid > (byte) 0;
            this.scale -= 0.0005f;
            if ((double) this.scale < 0.1)
            {
              this.scale = 0.1f;
              this.alpha = (int) byte.MaxValue;
            }
            this.rotation += this.velocity.X * 0.1f;
            if (flag2)
            {
              this.velocity.X *= 0.9f;
              int index5 = (int) vector2.X / 16;
              int index6 = (int) ((double) vector2.Y / 16.0);
              double num = (double) this.position.Y / 16.0;
              int index7 = (int) (((double) this.position.Y + (double) this.Height) / 16.0);
              if (Main.tile[index5, index6] == null)
                Main.tile[index5, index6] = new Tile();
              if (Main.tile[index5, index7] == null)
                Main.tile[index5, index7] = new Tile();
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.5f;
              float waterLine = this.ChumFloatingChunk_GetWaterLine((int) ((double) vector2.X / 16.0), (int) ((double) vector2.Y / 16.0));
              if ((double) vector2.Y > (double) waterLine)
              {
                this.velocity.Y -= 0.1f;
                if ((double) this.velocity.Y < -8.0)
                  this.velocity.Y = -8f;
                if ((double) vector2.Y + (double) this.velocity.Y < (double) waterLine)
                  this.velocity.Y = waterLine - vector2.Y;
              }
              else
                this.velocity.Y = waterLine - vector2.Y;
              bool flag3 = !flag2 && (double) this.velocity.Length() < 0.800000011920929;
              int maxValue = flag2 ? 270 : 15;
              if (Main.rand.Next(maxValue) == 0 && !flag3)
              {
                Gore gore = Gore.NewGoreDirect(this.position + Vector2.UnitY * 6f, Vector2.Zero, 1201, this.scale * 0.7f);
                if (flag2)
                  gore.velocity = Vector2.UnitX * Main.rand.NextFloatDirection() * 0.5f + Vector2.UnitY * Main.rand.NextFloat();
                else if ((double) gore.velocity.Y < 0.0)
                  gore.velocity.Y = -gore.velocity.Y;
              }
            }
            else
            {
              if ((double) this.velocity.Y == 0.0)
                this.velocity.X *= 0.95f;
              this.velocity.X *= 0.98f;
              this.velocity.Y += 0.3f;
              if ((double) this.velocity.Y > 15.8999996185303)
                this.velocity.Y = 15.9f;
            }
          }
          else if (this.type == 331)
          {
            this.alpha += 5;
            this.velocity.Y *= 0.95f;
            this.velocity.X *= 0.95f;
            this.rotation = this.velocity.X * 0.1f;
          }
          else if (GoreID.Sets.SpecialAI[this.type] == 3)
          {
            if (++this.frameCounter >= (byte) 8 && (double) this.velocity.Y > 0.200000002980232)
            {
              this.frameCounter = (byte) 0;
              int num = (int) this.Frame.CurrentRow / 4;
              if ((int) ++this.Frame.CurrentRow >= 4 + num * 4)
                this.Frame.CurrentRow = (byte) (num * 4);
            }
          }
          else if (GoreID.Sets.SpecialAI[this.type] != 1 && GoreID.Sets.SpecialAI[this.type] != 2)
          {
            if (this.type >= 907 && this.type <= 909)
            {
              this.rotation = 0.0f;
              this.velocity.X *= 0.98f;
              if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0 / 1000.0)
                this.velocity.Y = (float) ((double) Main.rand.NextFloat() * -3.0 - 0.5);
              if ((double) this.velocity.Y > -1.0)
                this.velocity.Y -= 0.1f;
              if ((double) this.scale < 1.0)
                this.scale += 0.1f;
              if (++this.frameCounter >= (byte) 8)
              {
                this.frameCounter = (byte) 0;
                if (++this.frame >= (byte) 3)
                  this.frame = (byte) 0;
              }
            }
            else if (this.type == 1218)
            {
              if (this.timeLeft > 8)
                this.timeLeft = 8;
              this.velocity.X *= 0.95f;
              if ((double) Math.Abs(this.velocity.X) <= 0.100000001490116)
                this.velocity.X = 0.0f;
              if (this.alpha < 100 && (double) this.velocity.Length() > 0.0 && Main.rand.Next(5) == 0)
              {
                int Type = 246;
                switch (this.Frame.CurrentRow)
                {
                  case 0:
                    Type = 246;
                    break;
                  case 1:
                    Type = 245;
                    break;
                  case 2:
                    Type = 244;
                    break;
                }
                int index = Dust.NewDust(this.position + new Vector2(6f, 4f), 4, 4, Type);
                Main.dust[index].alpha = (int) byte.MaxValue;
                Main.dust[index].scale = 0.8f;
                Main.dust[index].velocity = Vector2.Zero;
              }
              this.velocity.Y += 0.2f;
              this.rotation = 0.0f;
            }
            else if (this.type < 411 || this.type > 430)
            {
              this.velocity.Y += 0.2f;
              this.rotation += this.velocity.X * 0.05f;
            }
            else if (GoreID.Sets.SpecialAI[this.type] != 3)
              this.rotation += this.velocity.X * 0.1f;
          }
          if (this.type >= 580 && this.type <= 582)
          {
            this.rotation = 0.0f;
            this.velocity.X *= 0.95f;
          }
          if (GoreID.Sets.SpecialAI[this.type] == 2)
          {
            if (this.timeLeft < 60)
              this.alpha += Main.rand.Next(1, 7);
            else if (this.alpha > 100)
              this.alpha -= Main.rand.Next(1, 4);
            if (this.alpha < 0)
              this.alpha = 0;
            if (this.alpha > (int) byte.MaxValue)
              this.timeLeft = 0;
            this.velocity.X = (float) (((double) this.velocity.X * 50.0 + (double) Main.WindForVisuals * 2.0 + (double) Main.rand.Next(-10, 11) * 0.100000001490116) / 51.0);
            float num4 = 0.0f;
            if ((double) this.velocity.X < 0.0)
              num4 = this.velocity.X * 0.2f;
            this.velocity.Y = (float) (((double) this.velocity.Y * 50.0 - 0.349999994039536 + (double) num4 + (double) Main.rand.Next(-10, 11) * 0.200000002980232) / 51.0);
            this.rotation = this.velocity.X * 0.6f;
            float num5 = -1f;
            if (TextureAssets.Gore[this.type].IsLoaded)
            {
              Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, (int) ((double) TextureAssets.Gore[this.type].Width() * (double) this.scale), (int) ((double) TextureAssets.Gore[this.type].Height() * (double) this.scale));
              for (int index = 0; index < (int) byte.MaxValue; ++index)
              {
                if (Main.player[index].active && !Main.player[index].dead)
                {
                  Rectangle rectangle2 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
                  if (rectangle1.Intersects(rectangle2))
                  {
                    this.timeLeft = 0;
                    num5 = Main.player[index].velocity.Length();
                    break;
                  }
                }
              }
            }
            if (this.timeLeft > 0)
            {
              if (Main.rand.Next(2) == 0)
                --this.timeLeft;
              if (Main.rand.Next(50) == 0)
                this.timeLeft -= 5;
              if (Main.rand.Next(100) == 0)
                this.timeLeft -= 10;
            }
            else
            {
              this.alpha = (int) byte.MaxValue;
              if (TextureAssets.Gore[this.type].IsLoaded && (double) num5 != -1.0)
              {
                float num6 = (float) ((double) TextureAssets.Gore[this.type].Width() * (double) this.scale * 0.800000011920929);
                float x = this.position.X;
                float y = this.position.Y;
                float num7 = (float) TextureAssets.Gore[this.type].Width() * this.scale;
                float num8 = (float) TextureAssets.Gore[this.type].Height() * this.scale;
                int Type = 31;
                for (int index8 = 0; (double) index8 < (double) num6; ++index8)
                {
                  int index9 = Dust.NewDust(new Vector2(x, y), (int) num7, (int) num8, Type);
                  Main.dust[index9].velocity *= (float) ((1.0 + (double) num5) / 3.0);
                  Main.dust[index9].noGravity = true;
                  Main.dust[index9].alpha = 100;
                  Main.dust[index9].scale = this.scale;
                }
              }
            }
          }
          if (this.type >= 411 && this.type <= 430)
          {
            this.alpha = 50;
            this.velocity.X = (float) (((double) this.velocity.X * 50.0 + (double) Main.WindForVisuals * 2.0 + (double) Main.rand.Next(-10, 11) * 0.100000001490116) / 51.0);
            this.velocity.Y = (float) (((double) this.velocity.Y * 50.0 - 0.25 + (double) Main.rand.Next(-10, 11) * 0.200000002980232) / 51.0);
            this.rotation = this.velocity.X * 0.3f;
            if (TextureAssets.Gore[this.type].IsLoaded)
            {
              Rectangle rectangle3 = new Rectangle((int) this.position.X, (int) this.position.Y, (int) ((double) TextureAssets.Gore[this.type].Width() * (double) this.scale), (int) ((double) TextureAssets.Gore[this.type].Height() * (double) this.scale));
              for (int index = 0; index < (int) byte.MaxValue; ++index)
              {
                if (Main.player[index].active && !Main.player[index].dead)
                {
                  Rectangle rectangle4 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
                  if (rectangle3.Intersects(rectangle4))
                    this.timeLeft = 0;
                }
              }
              if (Collision.SolidCollision(this.position, (int) ((double) TextureAssets.Gore[this.type].Width() * (double) this.scale), (int) ((double) TextureAssets.Gore[this.type].Height() * (double) this.scale)))
                this.timeLeft = 0;
            }
            if (this.timeLeft > 0)
            {
              if (Main.rand.Next(2) == 0)
                --this.timeLeft;
              if (Main.rand.Next(50) == 0)
                this.timeLeft -= 5;
              if (Main.rand.Next(100) == 0)
                this.timeLeft -= 10;
            }
            else
            {
              this.alpha = (int) byte.MaxValue;
              if (TextureAssets.Gore[this.type].IsLoaded)
              {
                float num9 = (float) ((double) TextureAssets.Gore[this.type].Width() * (double) this.scale * 0.800000011920929);
                float x = this.position.X;
                float y = this.position.Y;
                float num10 = (float) TextureAssets.Gore[this.type].Width() * this.scale;
                float num11 = (float) TextureAssets.Gore[this.type].Height() * this.scale;
                int Type = 176;
                if (this.type >= 416 && this.type <= 420)
                  Type = 177;
                if (this.type >= 421 && this.type <= 425)
                  Type = 178;
                if (this.type >= 426 && this.type <= 430)
                  Type = 179;
                for (int index10 = 0; (double) index10 < (double) num9; ++index10)
                {
                  int index11 = Dust.NewDust(new Vector2(x, y), (int) num10, (int) num11, Type);
                  Main.dust[index11].noGravity = true;
                  Main.dust[index11].alpha = 100;
                  Main.dust[index11].scale = this.scale;
                }
              }
            }
          }
          else if (GoreID.Sets.SpecialAI[this.type] != 3 && GoreID.Sets.SpecialAI[this.type] != 1)
          {
            if (this.type >= 706 && this.type <= 717 || this.type == 943 || this.type == 1147 || this.type >= 1160 && this.type <= 1162)
            {
              if (this.type == 716)
              {
                float num12 = 0.6f;
                float num13 = this.frame != (byte) 0 ? (this.frame != (byte) 1 ? (this.frame != (byte) 2 ? (this.frame != (byte) 3 ? (this.frame != (byte) 4 ? (this.frame != (byte) 5 ? (this.frame != (byte) 6 ? (this.frame > (byte) 9 ? (this.frame != (byte) 10 ? (this.frame != (byte) 11 ? (this.frame != (byte) 12 ? (this.frame != (byte) 13 ? (this.frame != (byte) 14 ? 0.0f : num12 * 0.1f) : num12 * 0.2f) : num12 * 0.3f) : num12 * 0.4f) : num12 * 0.5f) : num12 * 0.5f) : num12 * 0.2f) : num12 * 0.4f) : num12 * 0.5f) : num12 * 0.4f) : num12 * 0.3f) : num12 * 0.2f) : num12 * 0.1f;
                Lighting.AddLight(this.position + new Vector2(8f, 8f), 1f * num13, 0.5f * num13, 0.1f * num13);
              }
              Vector2 velocity = this.velocity;
              this.velocity = Collision.TileCollision(this.position, this.velocity, 16, 14);
              if (this.velocity != velocity)
              {
                if (this.frame < (byte) 10)
                {
                  this.frame = (byte) 10;
                  this.frameCounter = (byte) 0;
                  if (this.type != 716 && this.type != 717 && this.type != 943 && (this.type < 1160 || this.type > 1162))
                    SoundEngine.PlaySound(39, (int) this.position.X + 8, (int) this.position.Y + 8, Main.rand.Next(2));
                }
              }
              else if (Collision.WetCollision(this.position + this.velocity, 16, 14))
              {
                if (this.frame < (byte) 10)
                {
                  this.frame = (byte) 10;
                  this.frameCounter = (byte) 0;
                  if (this.type != 716 && this.type != 717 && this.type != 943 && (this.type < 1160 || this.type > 1162))
                    SoundEngine.PlaySound(39, (int) this.position.X + 8, (int) this.position.Y + 8, 2);
                  ((WaterShaderData) Filters.Scene["WaterDistortion"].GetShader()).QueueRipple(this.position + new Vector2(8f, 8f));
                }
                int index12 = (int) ((double) this.position.X + 8.0) / 16;
                int index13 = (int) ((double) this.position.Y + 14.0) / 16;
                if (Main.tile[index12, index13] != null && Main.tile[index12, index13].liquid > (byte) 0)
                {
                  this.velocity *= 0.0f;
                  this.position.Y = (float) (index13 * 16 - (int) Main.tile[index12, index13].liquid / 16);
                }
              }
            }
            else if (this.sticky)
            {
              int num14 = 32;
              if (TextureAssets.Gore[this.type].IsLoaded)
              {
                num14 = TextureAssets.Gore[this.type].Width();
                if (TextureAssets.Gore[this.type].Height() < num14)
                  num14 = TextureAssets.Gore[this.type].Height();
              }
              if (flag1)
                num14 = 4;
              int num15 = (int) ((double) num14 * 0.899999976158142);
              Vector2 velocity = this.velocity;
              this.velocity = Collision.TileCollision(this.position, this.velocity, (int) ((double) num15 * (double) this.scale), (int) ((double) num15 * (double) this.scale));
              if ((double) this.velocity.Y == 0.0)
              {
                if (flag1)
                  this.velocity.X *= 0.94f;
                else
                  this.velocity.X *= 0.97f;
                if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
                  this.velocity.X = 0.0f;
              }
              if (this.timeLeft > 0)
                this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
              else
                this.alpha += GoreID.Sets.DisappearSpeedAlpha[this.type];
            }
            else
              this.alpha += 2 * GoreID.Sets.DisappearSpeedAlpha[this.type];
          }
          if (this.type >= 907 && this.type <= 909)
          {
            int num16 = 32;
            if (TextureAssets.Gore[this.type].IsLoaded)
            {
              num16 = TextureAssets.Gore[this.type].Width();
              if (TextureAssets.Gore[this.type].Height() < num16)
                num16 = TextureAssets.Gore[this.type].Height();
            }
            int num17 = (int) ((double) num16 * 0.899999976158142);
            Vector4 vector4 = Collision.SlopeCollision(this.position, this.velocity, num17, num17, fall: true);
            this.position.X = vector4.X;
            this.position.Y = vector4.Y;
            this.velocity.X = vector4.Z;
            this.velocity.Y = vector4.W;
          }
          if (GoreID.Sets.SpecialAI[this.type] == 1)
            this.Gore_UpdateSail();
          else if (GoreID.Sets.SpecialAI[this.type] == 3)
            this.Gore_UpdateLeaf();
          else
            this.position += this.velocity;
          if (this.alpha >= (int) byte.MaxValue)
            this.active = false;
          if ((double) this.light <= 0.0)
            break;
          float r = this.light * this.scale;
          float g = this.light * this.scale;
          float b = this.light * this.scale;
          if (this.type == 16)
          {
            b *= 0.3f;
            g *= 0.8f;
          }
          else if (this.type == 17)
          {
            g *= 0.6f;
            r *= 0.3f;
          }
          if (TextureAssets.Gore[this.type].IsLoaded)
          {
            Lighting.AddLight((int) (((double) this.position.X + (double) TextureAssets.Gore[this.type].Width() * (double) this.scale / 2.0) / 16.0), (int) (((double) this.position.Y + (double) TextureAssets.Gore[this.type].Height() * (double) this.scale / 2.0) / 16.0), r, g, b);
            break;
          }
          Lighting.AddLight((int) (((double) this.position.X + 32.0 * (double) this.scale / 2.0) / 16.0), (int) (((double) this.position.Y + 32.0 * (double) this.scale / 2.0) / 16.0), r, g, b);
          break;
      }
    }

    private void Gore_UpdateLeaf()
    {
      Vector2 Position = this.position + new Vector2(12f) / 2f - new Vector2(4f) / 2f;
      Position.Y -= 4f;
      Vector2 vector2_1 = this.position - Position;
      if ((double) this.velocity.Y < 0.0)
      {
        Vector2 vector2_2 = new Vector2(this.velocity.X, -0.2f);
        int num1 = (int) (4.0 * 0.899999976158142);
        Point tileCoordinates = (new Vector2((float) num1, (float) num1) / 2f + Position).ToTileCoordinates();
        if (!WorldGen.InWorld(tileCoordinates.X, tileCoordinates.Y))
        {
          this.active = false;
        }
        else
        {
          Tile tile = Main.tile[tileCoordinates.X, tileCoordinates.Y];
          if (tile == null)
          {
            this.active = false;
          }
          else
          {
            int num2 = 6;
            Rectangle rectangle1 = new Rectangle(tileCoordinates.X * 16, tileCoordinates.Y * 16 + (int) tile.liquid / 16, 16, 16 - (int) tile.liquid / 16);
            Rectangle rectangle2 = new Rectangle((int) Position.X, (int) Position.Y + num2, num1, num1);
            bool flag = tile != null && tile.liquid > (byte) 0 && rectangle1.Intersects(rectangle2);
            if (flag)
            {
              if (tile.honey())
                vector2_2.X = 0.0f;
              else if (tile.lava())
              {
                this.active = false;
                for (int index = 0; index < 5; ++index)
                  Dust.NewDust(this.position, num1, num1, 31, SpeedY: -0.2f);
              }
              else
                vector2_2.X = Main.WindForVisuals;
              if ((double) this.position.Y > Main.worldSurface * 16.0)
                vector2_2.X = 0.0f;
            }
            if (!WorldGen.SolidTile(tileCoordinates.X, tileCoordinates.Y + 1) && !flag)
            {
              this.velocity.Y = 0.1f;
              this.timeLeft = 0;
              this.alpha += 20;
            }
            vector2_2 = Collision.TileCollision(Position, vector2_2, num1, num1);
            if (flag)
              this.rotation = vector2_2.ToRotation() + 1.570796f;
            vector2_2.X *= 0.94f;
            if (!flag || (double) vector2_2.X > -0.01 && (double) vector2_2.X < 0.01)
              vector2_2.X = 0.0f;
            if (this.timeLeft > 0)
              this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
            else
              this.alpha += GoreID.Sets.DisappearSpeedAlpha[this.type];
            this.velocity.X = vector2_2.X;
            this.position.X += this.velocity.X;
          }
        }
      }
      else
      {
        this.velocity.Y += (float) Math.PI / 180f;
        Vector2 vector2_3 = new Vector2(Vector2.UnitY.RotatedBy((double) this.velocity.Y).X * 1f, Math.Abs(Vector2.UnitY.RotatedBy((double) this.velocity.Y).Y) * 1f);
        int num3 = 4;
        if ((double) this.position.Y < Main.worldSurface * 16.0)
          vector2_3.X += Main.WindForVisuals * 4f;
        Vector2 vector2_4 = vector2_3;
        vector2_3 = Collision.TileCollision(Position, vector2_3, num3, num3);
        Vector4 vector4 = Collision.SlopeCollision(Position, vector2_3, num3, num3, 1f);
        this.position.X = vector4.X;
        this.position.Y = vector4.Y;
        vector2_3.X = vector4.Z;
        vector2_3.Y = vector4.W;
        this.position += vector2_1;
        if (vector2_3 != vector2_4)
          this.velocity.Y = -1f;
        Point tileCoordinates = (new Vector2(this.Width, this.Height) * 0.5f + this.position).ToTileCoordinates();
        if (!WorldGen.InWorld(tileCoordinates.X, tileCoordinates.Y))
        {
          this.active = false;
        }
        else
        {
          Tile tile = Main.tile[tileCoordinates.X, tileCoordinates.Y];
          if (tile == null)
          {
            this.active = false;
          }
          else
          {
            int num4 = 6;
            Rectangle rectangle3 = new Rectangle(tileCoordinates.X * 16, tileCoordinates.Y * 16 + (int) tile.liquid / 16, 16, 16 - (int) tile.liquid / 16);
            Rectangle rectangle4 = new Rectangle((int) Position.X, (int) Position.Y + num4, num3, num3);
            if (tile != null && tile.liquid > (byte) 0 && rectangle3.Intersects(rectangle4))
              this.velocity.Y = -1f;
            this.position += vector2_3;
            this.rotation = vector2_3.ToRotation() + 1.570796f;
            if (this.timeLeft > 0)
              this.timeLeft -= GoreID.Sets.DisappearSpeed[this.type];
            else
              this.alpha += GoreID.Sets.DisappearSpeedAlpha[this.type];
          }
        }
      }
    }

    private void Gore_UpdateSail()
    {
      if ((double) this.velocity.Y < 0.0)
      {
        Vector2 Velocity = new Vector2(this.velocity.X, 0.6f);
        int num1 = 32;
        if (TextureAssets.Gore[this.type].IsLoaded)
        {
          num1 = TextureAssets.Gore[this.type].Width();
          if (TextureAssets.Gore[this.type].Height() < num1)
            num1 = TextureAssets.Gore[this.type].Height();
        }
        int num2 = (int) ((double) num1 * 0.899999976158142);
        Vector2 vector2 = Collision.TileCollision(this.position, Velocity, (int) ((double) num2 * (double) this.scale), (int) ((double) num2 * (double) this.scale));
        vector2.X *= 0.97f;
        if ((double) vector2.X > -0.01 && (double) vector2.X < 0.01)
          vector2.X = 0.0f;
        if (this.timeLeft > 0)
          --this.timeLeft;
        else
          ++this.alpha;
        this.velocity.X = vector2.X;
      }
      else
      {
        this.velocity.Y += (float) Math.PI / 60f;
        Vector2 Velocity = new Vector2(Vector2.UnitY.RotatedBy((double) this.velocity.Y).X * 2f, Math.Abs(Vector2.UnitY.RotatedBy((double) this.velocity.Y).Y) * 3f) * 2f;
        int num = 32;
        if (TextureAssets.Gore[this.type].IsLoaded)
        {
          num = TextureAssets.Gore[this.type].Width();
          if (TextureAssets.Gore[this.type].Height() < num)
            num = TextureAssets.Gore[this.type].Height();
        }
        Vector2 vector2 = Velocity;
        Vector2 v = Collision.TileCollision(this.position, Velocity, (int) ((double) num * (double) this.scale), (int) ((double) num * (double) this.scale));
        if (v != vector2)
          this.velocity.Y = -1f;
        this.position += v;
        this.rotation = v.ToRotation() + 3.141593f;
        if (this.timeLeft > 0)
          --this.timeLeft;
        else
          ++this.alpha;
      }
    }

    public static Gore NewGorePerfect(
      Vector2 Position,
      Vector2 Velocity,
      int Type,
      float Scale = 1f)
    {
      Gore gore = Gore.NewGoreDirect(Position, Velocity, Type, Scale);
      gore.position = Position;
      gore.velocity = Velocity;
      return gore;
    }

    public static Gore NewGoreDirect(
      Vector2 Position,
      Vector2 Velocity,
      int Type,
      float Scale = 1f)
    {
      return Main.gore[Gore.NewGore(Position, Velocity, Type, Scale)];
    }

    public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
    {
      if (Main.netMode == 2 || Main.gamePaused || WorldGen.gen)
        return 600;
      if (Main.rand == null)
        Main.rand = new UnifiedRandom();
      int index1 = 600;
      for (int index2 = 0; index2 < 600; ++index2)
      {
        if (!Main.gore[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == 600)
        return index1;
      Main.gore[index1].Frame = new SpriteFrame((byte) 1, (byte) 1);
      Main.gore[index1].frameCounter = (byte) 0;
      Main.gore[index1].behindTiles = false;
      Main.gore[index1].light = 0.0f;
      Main.gore[index1].position = Position;
      Main.gore[index1].velocity = Velocity;
      Main.gore[index1].velocity.Y -= (float) Main.rand.Next(10, 31) * 0.1f;
      Main.gore[index1].velocity.X += (float) Main.rand.Next(-20, 21) * 0.1f;
      Main.gore[index1].type = Type;
      Main.gore[index1].active = true;
      Main.gore[index1].alpha = 0;
      Main.gore[index1].rotation = 0.0f;
      Main.gore[index1].scale = Scale;
      if (!ChildSafety.Disabled && ChildSafety.DangerousGore(Type))
      {
        Main.gore[index1].type = Main.rand.Next(11, 14);
        Main.gore[index1].scale = (float) ((double) Main.rand.NextFloat() * 0.5 + 0.5);
        Main.gore[index1].velocity /= 2f;
      }
      if (Gore.goreTime == 0 || Type == 11 || Type == 12 || Type == 13 || Type == 16 || Type == 17 || Type == 61 || Type == 62 || Type == 63 || Type == 99 || Type == 220 || Type == 221 || Type == 222 || Type == 435 || Type == 436 || Type == 437 || Type >= 861 && Type <= 862)
        Main.gore[index1].sticky = false;
      else if (Type >= 375 && Type <= 377)
      {
        Main.gore[index1].sticky = false;
        Main.gore[index1].alpha = 100;
      }
      else
      {
        Main.gore[index1].sticky = true;
        Main.gore[index1].timeLeft = Gore.goreTime;
      }
      if (Type >= 706 && Type <= 717 || Type == 943 || Type == 1147 || Type >= 1160 && Type <= 1162)
      {
        Main.gore[index1].numFrames = (byte) 15;
        Main.gore[index1].behindTiles = true;
        Main.gore[index1].timeLeft = Gore.goreTime * 3;
      }
      if (Type == 16 || Type == 17)
      {
        Main.gore[index1].alpha = 100;
        Main.gore[index1].scale = 0.7f;
        Main.gore[index1].light = 1f;
      }
      if (Type >= 570 && Type <= 572)
        Main.gore[index1].velocity = Velocity;
      if (Type == 1201 || Type == 1208)
        Main.gore[index1].Frame = new SpriteFrame((byte) 1, (byte) 4);
      if (Type == 1217 || Type == 1218)
        Main.gore[index1].Frame = new SpriteFrame((byte) 1, (byte) 3);
      if (Type == 1225)
      {
        Main.gore[index1].Frame = new SpriteFrame((byte) 1, (byte) 3);
        Main.gore[index1].timeLeft = 10 + Main.rand.Next(6);
        Main.gore[index1].sticky = false;
        if (TextureAssets.Gore[Type].IsLoaded)
        {
          Main.gore[index1].position.X = Position.X - (float) (TextureAssets.Gore[Type].Width() / 2) * Scale;
          Main.gore[index1].position.Y = Position.Y - (float) ((double) TextureAssets.Gore[Type].Height() * (double) Scale / 2.0);
        }
      }
      int num1 = GoreID.Sets.SpecialAI[Type];
      if (num1 == 3)
      {
        Main.gore[index1].velocity = new Vector2((float) (((double) Main.rand.NextFloat() - 0.5) * 1.0), Main.rand.NextFloat() * 6.283185f);
        bool flag = Type >= 910 && Type <= 925 || Type >= 1113 && Type <= 1121 || Type >= 1248 && Type <= 1255 || Type >= 1257;
        Main.gore[index1].Frame = new SpriteFrame(flag ? (byte) 32 : (byte) 1, (byte) 8)
        {
          CurrentRow = (byte) Main.rand.Next(8)
        };
        Main.gore[index1].frameCounter = (byte) Main.rand.Next(8);
      }
      if (num1 == 1)
        Main.gore[index1].velocity = new Vector2((float) (((double) Main.rand.NextFloat() - 0.5) * 3.0), Main.rand.NextFloat() * 6.283185f);
      if (Type >= 411 && Type <= 430 && TextureAssets.Gore[Type].IsLoaded)
      {
        Main.gore[index1].position.X = Position.X - (float) (TextureAssets.Gore[Type].Width() / 2) * Scale;
        Main.gore[index1].position.Y = Position.Y - (float) TextureAssets.Gore[Type].Height() * Scale;
        Main.gore[index1].velocity.Y *= (float) Main.rand.Next(90, 150) * 0.01f;
        Main.gore[index1].velocity.X *= (float) Main.rand.Next(40, 90) * 0.01f;
        int num2 = Main.rand.Next(4) * 5;
        Main.gore[index1].type += num2;
        Main.gore[index1].timeLeft = Main.rand.Next(Gore.goreTime / 2, Gore.goreTime * 2);
        Main.gore[index1].sticky = true;
        if (Gore.goreTime == 0)
          Main.gore[index1].timeLeft = Main.rand.Next(150, 600);
      }
      if (Type >= 907 && Type <= 909)
      {
        Main.gore[index1].sticky = true;
        Main.gore[index1].numFrames = (byte) 3;
        Main.gore[index1].frame = (byte) Main.rand.Next(3);
        Main.gore[index1].frameCounter = (byte) Main.rand.Next(5);
        Main.gore[index1].rotation = 0.0f;
      }
      if (num1 == 2)
      {
        Main.gore[index1].sticky = false;
        if (TextureAssets.Gore[Type].IsLoaded)
        {
          Main.gore[index1].alpha = 150;
          Main.gore[index1].velocity = Velocity;
          Main.gore[index1].position.X = Position.X - (float) (TextureAssets.Gore[Type].Width() / 2) * Scale;
          Main.gore[index1].position.Y = Position.Y - (float) ((double) TextureAssets.Gore[Type].Height() * (double) Scale / 2.0);
          Main.gore[index1].timeLeft = Main.rand.Next(Gore.goreTime / 2, Gore.goreTime + 1);
        }
      }
      if (num1 == 4)
      {
        Main.gore[index1].alpha = 254;
        Main.gore[index1].timeLeft = 300;
      }
      if (num1 == 5)
      {
        Main.gore[index1].alpha = 254;
        Main.gore[index1].timeLeft = 240;
      }
      if (num1 == 6)
      {
        Main.gore[index1].alpha = 254;
        Main.gore[index1].timeLeft = 480;
      }
      return index1;
    }

    public Color GetAlpha(Color newColor)
    {
      float num1 = (float) ((int) byte.MaxValue - this.alpha) / (float) byte.MaxValue;
      int r;
      int g;
      int b;
      if (this.type == 16 || this.type == 17)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else
      {
        if (this.type == 716)
          return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 200);
        if (this.type >= 570 && this.type <= 572)
        {
          byte num2 = (byte) ((int) byte.MaxValue - this.alpha);
          return new Color((int) num2, (int) num2, (int) num2, (int) num2 / 2);
        }
        if (this.type == 331)
          return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 50);
        if (this.type == 1225)
          return new Color(num1, num1, num1, num1);
        r = (int) ((double) newColor.R * (double) num1);
        g = (int) ((double) newColor.G * (double) num1);
        b = (int) ((double) newColor.B * (double) num1);
      }
      int a = (int) newColor.A - this.alpha;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return this.type >= 1202 && this.type <= 1204 ? new Color(r, g, b, a < 20 ? a : 20) : new Color(r, g, b, a);
    }
  }
}
