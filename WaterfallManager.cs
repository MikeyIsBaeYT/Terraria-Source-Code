// Decompiled with JetBrains decompiler
// Type: Terraria.WaterfallManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.ID;
using Terraria.IO;

namespace Terraria
{
  public class WaterfallManager
  {
    private const int minWet = 160;
    private const int maxWaterfallCountDefault = 1000;
    private const int maxLength = 100;
    private const int maxTypes = 24;
    public int maxWaterfallCount = 1000;
    private int qualityMax;
    private int currentMax;
    private WaterfallManager.WaterfallData[] waterfalls;
    private Asset<Texture2D>[] waterfallTexture = new Asset<Texture2D>[24];
    private int wFallFrCounter;
    private int regularFrame;
    private int wFallFrCounter2;
    private int slowFrame;
    private int rainFrameCounter;
    private int rainFrameForeground;
    private int rainFrameBackground;
    private int snowFrameCounter;
    private int snowFrameForeground;
    private int findWaterfallCount;
    private int waterfallDist = 100;

    public WaterfallManager()
    {
      this.waterfalls = new WaterfallManager.WaterfallData[1000];
      Main.Configuration.OnLoad += (Action<Preferences>) (preferences =>
      {
        this.maxWaterfallCount = Math.Max(0, preferences.Get<int>("WaterfallDrawLimit", 1000));
        this.waterfalls = new WaterfallManager.WaterfallData[this.maxWaterfallCount];
      });
    }

    public void LoadContent()
    {
      for (int index = 0; index < 24; ++index)
        this.waterfallTexture[index] = Main.Assets.Request<Texture2D>("Images/Waterfall_" + (object) index, (AssetRequestMode) 2);
    }

    public bool CheckForWaterfall(int i, int j)
    {
      for (int index = 0; index < this.currentMax; ++index)
      {
        if (this.waterfalls[index].x == i && this.waterfalls[index].y == j)
          return true;
      }
      return false;
    }

    public void FindWaterfalls(bool forced = false)
    {
      ++this.findWaterfallCount;
      if (this.findWaterfallCount < 30 && !forced)
        return;
      this.findWaterfallCount = 0;
      this.waterfallDist = (int) (75.0 * (double) Main.gfxQuality) + 25;
      this.qualityMax = (int) ((double) this.maxWaterfallCount * (double) Main.gfxQuality);
      this.currentMax = 0;
      int num1 = (int) ((double) Main.screenPosition.X / 16.0 - 1.0);
      int num2 = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth) / 16.0) + 2;
      int num3 = (int) ((double) Main.screenPosition.Y / 16.0 - 1.0);
      int num4 = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight) / 16.0) + 2;
      int num5 = num1 - this.waterfallDist;
      int num6 = num2 + this.waterfallDist;
      int num7 = num3 - this.waterfallDist;
      int num8 = num4 + 20;
      if (num5 < 0)
        num5 = 0;
      if (num6 > Main.maxTilesX)
        num6 = Main.maxTilesX;
      if (num7 < 0)
        num7 = 0;
      if (num8 > Main.maxTilesY)
        num8 = Main.maxTilesY;
      for (int index1 = num5; index1 < num6; ++index1)
      {
        for (int index2 = num7; index2 < num8; ++index2)
        {
          Tile tile = Main.tile[index1, index2];
          if (tile == null)
          {
            tile = new Tile();
            Main.tile[index1, index2] = tile;
          }
          if (tile.active())
          {
            if (tile.halfBrick())
            {
              Tile testTile1 = Main.tile[index1, index2 - 1];
              if (testTile1 == null)
              {
                testTile1 = new Tile();
                Main.tile[index1, index2 - 1] = testTile1;
              }
              if (testTile1.liquid < (byte) 16 || WorldGen.SolidTile(testTile1))
              {
                Tile testTile2 = Main.tile[index1 - 1, index2];
                if (testTile2 == null)
                {
                  testTile2 = new Tile();
                  Main.tile[index1 - 1, index2] = testTile2;
                }
                Tile testTile3 = Main.tile[index1 + 1, index2];
                if (testTile3 == null)
                {
                  testTile3 = new Tile();
                  Main.tile[index1 + 1, index2] = testTile3;
                }
                if ((testTile2.liquid > (byte) 160 || testTile3.liquid > (byte) 160) && (testTile2.liquid == (byte) 0 && !WorldGen.SolidTile(testTile2) && testTile2.slope() == (byte) 0 || testTile3.liquid == (byte) 0 && !WorldGen.SolidTile(testTile3) && testTile3.slope() == (byte) 0) && this.currentMax < this.qualityMax)
                {
                  this.waterfalls[this.currentMax].type = 0;
                  this.waterfalls[this.currentMax].type = testTile1.lava() || testTile3.lava() || testTile2.lava() ? 1 : (testTile1.honey() || testTile3.honey() || testTile2.honey() ? 14 : 0);
                  this.waterfalls[this.currentMax].x = index1;
                  this.waterfalls[this.currentMax].y = index2;
                  ++this.currentMax;
                }
              }
            }
            if (tile.type == (ushort) 196)
            {
              Tile testTile = Main.tile[index1, index2 + 1];
              if (testTile == null)
              {
                testTile = new Tile();
                Main.tile[index1, index2 + 1] = testTile;
              }
              if (!WorldGen.SolidTile(testTile) && testTile.slope() == (byte) 0 && this.currentMax < this.qualityMax)
              {
                this.waterfalls[this.currentMax].type = 11;
                this.waterfalls[this.currentMax].x = index1;
                this.waterfalls[this.currentMax].y = index2 + 1;
                ++this.currentMax;
              }
            }
            if (tile.type == (ushort) 460)
            {
              Tile testTile = Main.tile[index1, index2 + 1];
              if (testTile == null)
              {
                testTile = new Tile();
                Main.tile[index1, index2 + 1] = testTile;
              }
              if (!WorldGen.SolidTile(testTile) && testTile.slope() == (byte) 0 && this.currentMax < this.qualityMax)
              {
                this.waterfalls[this.currentMax].type = 22;
                this.waterfalls[this.currentMax].x = index1;
                this.waterfalls[this.currentMax].y = index2 + 1;
                ++this.currentMax;
              }
            }
          }
        }
      }
    }

    public void UpdateFrame()
    {
      ++this.wFallFrCounter;
      if (this.wFallFrCounter > 2)
      {
        this.wFallFrCounter = 0;
        ++this.regularFrame;
        if (this.regularFrame > 15)
          this.regularFrame = 0;
      }
      ++this.wFallFrCounter2;
      if (this.wFallFrCounter2 > 6)
      {
        this.wFallFrCounter2 = 0;
        ++this.slowFrame;
        if (this.slowFrame > 15)
          this.slowFrame = 0;
      }
      ++this.rainFrameCounter;
      if (this.rainFrameCounter > 0)
      {
        ++this.rainFrameForeground;
        if (this.rainFrameForeground > 7)
          this.rainFrameForeground -= 8;
        if (this.rainFrameCounter > 2)
        {
          this.rainFrameCounter = 0;
          --this.rainFrameBackground;
          if (this.rainFrameBackground < 0)
            this.rainFrameBackground = 7;
        }
      }
      if (++this.snowFrameCounter <= 3)
        return;
      this.snowFrameCounter = 0;
      if (++this.snowFrameForeground <= 7)
        return;
      this.snowFrameForeground = 0;
    }

    private void DrawWaterfall(SpriteBatch spriteBatch, int Style = 0, float Alpha = 1f)
    {
      Main.tileSolid[546] = false;
      float num1 = 0.0f;
      float num2 = 99999f;
      float num3 = 99999f;
      int num4 = -1;
      int num5 = -1;
      float num6 = 0.0f;
      float num7 = 99999f;
      float num8 = 99999f;
      int num9 = -1;
      int num10 = -1;
      for (int index1 = 0; index1 < this.currentMax; ++index1)
      {
        int num11 = 0;
        int index2 = this.waterfalls[index1].type;
        int x1 = this.waterfalls[index1].x;
        int y = this.waterfalls[index1].y;
        int num12 = 0;
        int num13 = 0;
        int num14 = 0;
        int num15 = 0;
        int num16 = 0;
        int index3 = 0;
        int x2;
        switch (index2)
        {
          case 0:
            index2 = Style;
            goto default;
          case 1:
          case 14:
            if (!Main.drewLava && this.waterfalls[index1].stopAtStep != 0)
            {
              x2 = 32 * this.slowFrame;
              break;
            }
            continue;
          case 2:
            if (Main.drewLava)
              continue;
            goto default;
          case 11:
          case 22:
            if (!Main.drewLava)
            {
              int num17 = this.waterfallDist / 4;
              if (index2 == 22)
                num17 = this.waterfallDist / 2;
              if (this.waterfalls[index1].stopAtStep > num17)
                this.waterfalls[index1].stopAtStep = num17;
              if (this.waterfalls[index1].stopAtStep != 0 && (double) (y + num17) >= (double) Main.screenPosition.Y / 16.0 && (double) x1 >= (double) Main.screenPosition.X / 16.0 - 20.0 && (double) x1 <= ((double) Main.screenPosition.X + (double) Main.screenWidth) / 16.0 + 20.0)
              {
                int num18;
                int num19;
                if (x1 % 2 == 0)
                {
                  num18 = this.rainFrameForeground + 3;
                  if (num18 > 7)
                    num18 -= 8;
                  num19 = this.rainFrameBackground + 2;
                  if (num19 > 7)
                    num19 -= 8;
                  if (index2 == 22)
                  {
                    num18 = this.snowFrameForeground + 3;
                    if (num18 > 7)
                      num18 -= 8;
                  }
                }
                else
                {
                  num18 = this.rainFrameForeground;
                  num19 = this.rainFrameBackground;
                  if (index2 == 22)
                    num18 = this.snowFrameForeground;
                }
                Rectangle rectangle1 = new Rectangle(num19 * 18, 0, 16, 16);
                Rectangle rectangle2 = new Rectangle(num18 * 18, 0, 16, 16);
                Vector2 origin = new Vector2(8f, 8f);
                Vector2 position = y % 2 != 0 ? new Vector2((float) (x1 * 16 + 8), (float) (y * 16 + 8)) - Main.screenPosition : new Vector2((float) (x1 * 16 + 9), (float) (y * 16 + 8)) - Main.screenPosition;
                Tile tile = Main.tile[x1, y - 1];
                if (tile.active() && tile.bottomSlope())
                  position.Y -= 16f;
                bool flag = false;
                float rotation = 0.0f;
                for (int index4 = 0; index4 < num17; ++index4)
                {
                  Color color1 = Lighting.GetColor(x1, y);
                  float num20 = 0.6f;
                  float num21 = 0.3f;
                  if (index4 > num17 - 8)
                  {
                    float num22 = (float) (num17 - index4) / 8f;
                    num20 *= num22;
                    num21 *= num22;
                  }
                  Color color2 = color1 * num20;
                  Color color3 = color1 * num21;
                  if (index2 == 22)
                  {
                    spriteBatch.Draw(this.waterfallTexture[22].Value, position, new Rectangle?(rectangle2), color2, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
                  }
                  else
                  {
                    spriteBatch.Draw(this.waterfallTexture[12].Value, position, new Rectangle?(rectangle1), color3, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                    spriteBatch.Draw(this.waterfallTexture[11].Value, position, new Rectangle?(rectangle2), color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                  }
                  if (!flag)
                  {
                    ++y;
                    Tile testTile = Main.tile[x1, y];
                    if (WorldGen.SolidTile(testTile))
                      flag = true;
                    if (testTile.liquid > (byte) 0)
                    {
                      int num23 = (int) (16.0 * ((double) testTile.liquid / (double) byte.MaxValue)) & 254;
                      if (num23 < 15)
                      {
                        rectangle2.Height -= num23;
                        rectangle1.Height -= num23;
                      }
                      else
                        break;
                    }
                    if (y % 2 == 0)
                      ++position.X;
                    else
                      --position.X;
                    position.Y += 16f;
                  }
                  else
                    break;
                }
                this.waterfalls[index1].stopAtStep = 0;
                continue;
              }
              continue;
            }
            continue;
          default:
            x2 = 32 * this.regularFrame;
            break;
        }
        int num24 = 0;
        int num25 = this.waterfallDist;
        Color color4 = Color.White;
        for (int index5 = 0; index5 < num25; ++index5)
        {
          if (num24 < 2)
          {
            switch (index2)
            {
              case 1:
                double num26;
                float r1 = (float) (num26 = (0.550000011920929 + (double) (270 - (int) Main.mouseTextColor) / 900.0) * 0.400000005960464);
                float g1 = (float) (num26 * 0.300000011920929);
                float b1 = (float) (num26 * 0.100000001490116);
                Lighting.AddLight(x1, y, r1, g1, b1);
                break;
              case 2:
                float num27 = (float) Main.DiscoR / (float) byte.MaxValue;
                float num28 = (float) Main.DiscoG / (float) byte.MaxValue;
                float num29 = (float) Main.DiscoB / (float) byte.MaxValue;
                float r2 = num27 * 0.2f;
                float g2 = num28 * 0.2f;
                float b2 = num29 * 0.2f;
                Lighting.AddLight(x1, y, r2, g2, b2);
                break;
              case 15:
                float r3 = 0.0f;
                float g3 = 0.0f;
                float b3 = 0.2f;
                Lighting.AddLight(x1, y, r3, g3, b3);
                break;
              case 16:
                float r4 = 0.0f;
                float g4 = 0.2f;
                float b4 = 0.0f;
                Lighting.AddLight(x1, y, r4, g4, b4);
                break;
              case 17:
                float r5 = 0.0f;
                float g5 = 0.0f;
                float b5 = 0.2f;
                Lighting.AddLight(x1, y, r5, g5, b5);
                break;
              case 18:
                float r6 = 0.0f;
                float g6 = 0.2f;
                float b6 = 0.0f;
                Lighting.AddLight(x1, y, r6, g6, b6);
                break;
              case 19:
                float r7 = 0.2f;
                float g7 = 0.0f;
                float b7 = 0.0f;
                Lighting.AddLight(x1, y, r7, g7, b7);
                break;
              case 20:
                Lighting.AddLight(x1, y, 0.2f, 0.2f, 0.2f);
                break;
              case 21:
                float r8 = 0.2f;
                float g8 = 0.0f;
                float b8 = 0.0f;
                Lighting.AddLight(x1, y, r8, g8, b8);
                break;
            }
            Tile tile = Main.tile[x1, y];
            if (tile == null)
            {
              tile = new Tile();
              Main.tile[x1, y] = tile;
            }
            if (!tile.nactive() || !Main.tileSolid[(int) tile.type] || Main.tileSolidTop[(int) tile.type] || TileID.Sets.Platforms[(int) tile.type] || tile.blockType() != 0)
            {
              Tile testTile1 = Main.tile[x1 - 1, y];
              if (testTile1 == null)
              {
                testTile1 = new Tile();
                Main.tile[x1 - 1, y] = testTile1;
              }
              Tile testTile2 = Main.tile[x1, y + 1];
              if (testTile2 == null)
              {
                testTile2 = new Tile();
                Main.tile[x1, y + 1] = testTile2;
              }
              Tile testTile3 = Main.tile[x1 + 1, y];
              if (testTile3 == null)
              {
                testTile3 = new Tile();
                Main.tile[x1 + 1, y] = testTile3;
              }
              int num30 = (int) tile.liquid / 16;
              int num31 = 0;
              int num32 = num15;
              int num33;
              int num34;
              if (testTile2.topSlope() && !tile.halfBrick() && testTile2.type != (ushort) 19)
              {
                if (testTile2.slope() == (byte) 1)
                {
                  num31 = 1;
                  num33 = 1;
                  num14 = 1;
                  num15 = num14;
                }
                else
                {
                  num31 = -1;
                  num33 = -1;
                  num14 = -1;
                  num15 = num14;
                }
                num34 = 1;
              }
              else if (!WorldGen.SolidTile(testTile2) && !testTile2.bottomSlope() && !tile.halfBrick() || !testTile2.active() && !tile.halfBrick())
              {
                num24 = 0;
                num34 = 1;
                num33 = 0;
              }
              else if ((WorldGen.SolidTile(testTile1) || testTile1.topSlope() || testTile1.liquid > (byte) 0) && !WorldGen.SolidTile(testTile3) && testTile3.liquid == (byte) 0)
              {
                if (num14 == -1)
                  ++num24;
                num33 = 1;
                num34 = 0;
                num14 = 1;
              }
              else if ((WorldGen.SolidTile(testTile3) || testTile3.topSlope() || testTile3.liquid > (byte) 0) && !WorldGen.SolidTile(testTile1) && testTile1.liquid == (byte) 0)
              {
                if (num14 == 1)
                  ++num24;
                num33 = -1;
                num34 = 0;
                num14 = -1;
              }
              else if ((!WorldGen.SolidTile(testTile3) && !tile.topSlope() || testTile3.liquid == (byte) 0) && !WorldGen.SolidTile(testTile1) && !tile.topSlope() && testTile1.liquid == (byte) 0)
              {
                num34 = 0;
                num33 = num14;
              }
              else
              {
                ++num24;
                num34 = 0;
                num33 = 0;
              }
              if (num24 >= 2)
              {
                num14 *= -1;
                num33 *= -1;
              }
              int num35 = -1;
              if (index2 != 1 && index2 != 14)
              {
                if (testTile2.active())
                  num35 = (int) testTile2.type;
                if (tile.active())
                  num35 = (int) tile.type;
              }
              switch (num35)
              {
                case 160:
                  index2 = 2;
                  break;
                case 262:
                case 263:
                case 264:
                case 265:
                case 266:
                case 267:
                case 268:
                  index2 = 15 + num35 - 262;
                  break;
              }
              if (WorldGen.SolidTile(testTile2) && !tile.halfBrick())
                num11 = 8;
              else if (num13 != 0)
                num11 = 0;
              Color color5 = Lighting.GetColor(x1, y);
              Color color6 = color5;
              float num36;
              switch (index2)
              {
                case 1:
                  num36 = 1f;
                  break;
                case 14:
                  num36 = 0.8f;
                  break;
                default:
                  num36 = tile.wall != (ushort) 0 || (double) y >= Main.worldSurface ? 0.6f * Alpha : Alpha;
                  break;
              }
              if (index5 > num25 - 10)
                num36 *= (float) (num25 - index5) / 10f;
              float num37 = (float) color5.R * num36;
              float num38 = (float) color5.G * num36;
              float num39 = (float) color5.B * num36;
              float num40 = (float) color5.A * num36;
              switch (index2)
              {
                case 1:
                  if ((double) num37 < 190.0 * (double) num36)
                    num37 = 190f * num36;
                  if ((double) num38 < 190.0 * (double) num36)
                    num38 = 190f * num36;
                  if ((double) num39 < 190.0 * (double) num36)
                  {
                    num39 = 190f * num36;
                    break;
                  }
                  break;
                case 2:
                  num37 = (float) Main.DiscoR * num36;
                  num38 = (float) Main.DiscoG * num36;
                  num39 = (float) Main.DiscoB * num36;
                  break;
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                  num37 = (float) byte.MaxValue * num36;
                  num38 = (float) byte.MaxValue * num36;
                  num39 = (float) byte.MaxValue * num36;
                  break;
              }
              color5 = new Color((int) num37, (int) num38, (int) num39, (int) num40);
              if (index2 == 1)
              {
                float num41 = Math.Abs((float) (x1 * 16 + 8) - (Main.screenPosition.X + (float) (Main.screenWidth / 2)));
                float num42 = Math.Abs((float) (y * 16 + 8) - (Main.screenPosition.Y + (float) (Main.screenHeight / 2)));
                if ((double) num41 < (double) (Main.screenWidth * 2) && (double) num42 < (double) (Main.screenHeight * 2))
                {
                  float num43 = (float) (1.0 - Math.Sqrt((double) num41 * (double) num41 + (double) num42 * (double) num42) / ((double) Main.screenWidth * 0.75));
                  if ((double) num43 > 0.0)
                    num6 += num43;
                }
                if ((double) num41 < (double) num7)
                {
                  num7 = num41;
                  num9 = x1 * 16 + 8;
                }
                if ((double) num42 < (double) num8)
                {
                  num8 = num41;
                  num10 = y * 16 + 8;
                }
              }
              else if (index2 != 1 && index2 != 14 && index2 != 11 && index2 != 12 && index2 != 22)
              {
                float num44 = Math.Abs((float) (x1 * 16 + 8) - (Main.screenPosition.X + (float) (Main.screenWidth / 2)));
                float num45 = Math.Abs((float) (y * 16 + 8) - (Main.screenPosition.Y + (float) (Main.screenHeight / 2)));
                if ((double) num44 < (double) (Main.screenWidth * 2) && (double) num45 < (double) (Main.screenHeight * 2))
                {
                  float num46 = (float) (1.0 - Math.Sqrt((double) num44 * (double) num44 + (double) num45 * (double) num45) / ((double) Main.screenWidth * 0.75));
                  if ((double) num46 > 0.0)
                    num1 += num46;
                }
                if ((double) num44 < (double) num2)
                {
                  num2 = num44;
                  num4 = x1 * 16 + 8;
                }
                if ((double) num45 < (double) num3)
                {
                  num3 = num44;
                  num5 = y * 16 + 8;
                }
              }
              if (index5 > 50 && (color6.R > (byte) 20 || color6.B > (byte) 20 || color6.G > (byte) 20))
              {
                float num47 = (float) color6.R;
                if ((double) color6.G > (double) num47)
                  num47 = (float) color6.G;
                if ((double) color6.B > (double) num47)
                  num47 = (float) color6.B;
                if ((double) Main.rand.Next(20000) < (double) num47 / 30.0)
                {
                  int index6 = Dust.NewDust(new Vector2((float) (x1 * 16 - num14 * 7), (float) (y * 16 + 6)), 10, 8, 43, Alpha: 254, newColor: Color.White, Scale: 0.5f);
                  Main.dust[index6].velocity *= 0.0f;
                }
              }
              if (num12 == 0 && num31 != 0 && num13 == 1 && num14 != num15)
              {
                num31 = 0;
                num14 = num15;
                color5 = Color.White;
                if (num14 == 1)
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16 + 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color5, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
                else
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16 + 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 8)), color5, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
              }
              if (num16 != 0 && num33 == 0 && num34 == 1)
              {
                if (num14 == 1)
                {
                  if (index3 != index2)
                    spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11 + 8)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 0, 16, 16 - num30 - 8)), color4, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
                  else
                    spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11 + 8)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 0, 16, 16 - num30 - 8)), color5, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11 + 8)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 0, 16, 16 - num30 - 8)), color5, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
              }
              if (num11 == 8 && num13 == 1 && num16 == 0)
              {
                if (num15 == -1)
                {
                  if (index3 != index2)
                    spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 8)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  else
                    spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 8)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
                else if (index3 != index2)
                  spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 8)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                else
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 8)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
              }
              if (num31 != 0 && num12 == 0)
              {
                if (num32 == 1)
                {
                  if (index3 != index2)
                    spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                  else
                    spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else if (index3 != index2)
                  spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                else
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
              if (num34 == 1 && num31 == 0 && num16 == 0)
              {
                if (num14 == -1)
                {
                  if (num13 == 0)
                    spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 0, 16, 16 - num30)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  else if (index3 != index2)
                    spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  else
                    spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
                else if (num13 == 0)
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 0, 16, 16 - num30)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                else if (index3 != index2)
                  spriteBatch.Draw(this.waterfallTexture[index3].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                else
                  spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 - 16), (float) (y * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(x2, 24, 32, 16 - num30)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
              }
              else
              {
                switch (num33)
                {
                  case -1:
                    if (Main.tile[x1, y].liquid <= (byte) 0 || Main.tile[x1, y].halfBrick())
                    {
                      if (num31 == -1)
                      {
                        for (int index7 = 0; index7 < 8; ++index7)
                        {
                          int num48 = index7 * 2;
                          int num49 = index7 * 2;
                          int num50 = 14 - index7 * 2;
                          num11 = 8;
                          if (num12 == 0 && index7 > 5)
                            num50 = 4;
                          spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 + num48), (float) (y * 16 + num11 + num50)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + x2 + num49, 0, 2, 16 - num11)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                        }
                        break;
                      }
                      int height = 16;
                      if (TileID.Sets.BlocksWaterDrawingBehindSelf[(int) Main.tile[x1, y].type])
                        height = 8;
                      else if (TileID.Sets.BlocksWaterDrawingBehindSelf[(int) Main.tile[x1, y + 1].type])
                        height = 8;
                      spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + x2, 0, 16, height)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                      break;
                    }
                    break;
                  case 0:
                    if (num34 == 0)
                    {
                      if (Main.tile[x1, y].liquid <= (byte) 0 || Main.tile[x1, y].halfBrick())
                        spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + x2, 0, 16, 16)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                      index5 = 1000;
                      break;
                    }
                    break;
                  case 1:
                    if (Main.tile[x1, y].liquid <= (byte) 0 || Main.tile[x1, y].halfBrick())
                    {
                      if (num31 == 1)
                      {
                        for (int index8 = 0; index8 < 8; ++index8)
                        {
                          int num51 = index8 * 2;
                          int num52 = 14 - index8 * 2;
                          int num53 = num51;
                          num11 = 8;
                          if (num12 == 0 && index8 < 2)
                            num53 = 4;
                          spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16 + num51), (float) (y * 16 + num11 + num53)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + x2 + num52, 0, 2, 16 - num11)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                        }
                        break;
                      }
                      int height = 16;
                      if (TileID.Sets.BlocksWaterDrawingBehindSelf[(int) Main.tile[x1, y].type])
                        height = 8;
                      else if (TileID.Sets.BlocksWaterDrawingBehindSelf[(int) Main.tile[x1, y + 1].type])
                        height = 8;
                      spriteBatch.Draw(this.waterfallTexture[index2].Value, new Vector2((float) (x1 * 16), (float) (y * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + x2, 0, 16, height)), color5, 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
                      break;
                    }
                    break;
                }
              }
              if (tile.liquid > (byte) 0 && !tile.halfBrick())
                index5 = 1000;
              num13 = num34;
              num15 = num14;
              num12 = num33;
              x1 += num33;
              y += num34;
              num16 = num31;
              color4 = color5;
              if (index3 != index2)
                index3 = index2;
              if (testTile1.active() && (testTile1.type == (ushort) 189 || testTile1.type == (ushort) 196) || testTile3.active() && (testTile3.type == (ushort) 189 || testTile3.type == (ushort) 196) || testTile2.active() && (testTile2.type == (ushort) 189 || testTile2.type == (ushort) 196))
                num25 = (int) ((double) (40 * (Main.maxTilesX / 4200)) * (double) Main.gfxQuality);
            }
            else
              break;
          }
        }
      }
      Main.ambientWaterfallX = (float) num4;
      Main.ambientWaterfallY = (float) num5;
      Main.ambientWaterfallStrength = num1;
      Main.ambientLavafallX = (float) num9;
      Main.ambientLavafallY = (float) num10;
      Main.ambientLavafallStrength = num6;
      Main.tileSolid[546] = true;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < this.currentMax; ++index)
        this.waterfalls[index].stopAtStep = this.waterfallDist;
      Main.drewLava = false;
      if ((double) Main.liquidAlpha[0] > 0.0)
        this.DrawWaterfall(spriteBatch, Alpha: Main.liquidAlpha[0]);
      if ((double) Main.liquidAlpha[2] > 0.0)
        this.DrawWaterfall(spriteBatch, 3, Main.liquidAlpha[2]);
      if ((double) Main.liquidAlpha[3] > 0.0)
        this.DrawWaterfall(spriteBatch, 4, Main.liquidAlpha[3]);
      if ((double) Main.liquidAlpha[4] > 0.0)
        this.DrawWaterfall(spriteBatch, 5, Main.liquidAlpha[4]);
      if ((double) Main.liquidAlpha[5] > 0.0)
        this.DrawWaterfall(spriteBatch, 6, Main.liquidAlpha[5]);
      if ((double) Main.liquidAlpha[6] > 0.0)
        this.DrawWaterfall(spriteBatch, 7, Main.liquidAlpha[6]);
      if ((double) Main.liquidAlpha[7] > 0.0)
        this.DrawWaterfall(spriteBatch, 8, Main.liquidAlpha[7]);
      if ((double) Main.liquidAlpha[8] > 0.0)
        this.DrawWaterfall(spriteBatch, 9, Main.liquidAlpha[8]);
      if ((double) Main.liquidAlpha[9] > 0.0)
        this.DrawWaterfall(spriteBatch, 10, Main.liquidAlpha[9]);
      if ((double) Main.liquidAlpha[10] > 0.0)
        this.DrawWaterfall(spriteBatch, 13, Main.liquidAlpha[10]);
      if ((double) Main.liquidAlpha[12] <= 0.0)
        return;
      this.DrawWaterfall(spriteBatch, 23, Main.liquidAlpha[12]);
    }

    public struct WaterfallData
    {
      public int x;
      public int y;
      public int type;
      public int stopAtStep;
    }
  }
}
