// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Liquid.LiquidRenderer
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics;
using Terraria.Utilities;

namespace Terraria.GameContent.Liquid
{
  public class LiquidRenderer
  {
    private const int ANIMATION_FRAME_COUNT = 16;
    private const int CACHE_PADDING = 2;
    private const int CACHE_PADDING_2 = 4;
    private static readonly int[] WATERFALL_LENGTH = new int[3]
    {
      10,
      3,
      2
    };
    private static readonly float[] DEFAULT_OPACITY = new float[3]
    {
      0.6f,
      0.95f,
      0.95f
    };
    private static readonly byte[] WAVE_MASK_STRENGTH = new byte[5]
    {
      (byte) 0,
      (byte) 0,
      (byte) 0,
      byte.MaxValue,
      (byte) 0
    };
    private static readonly byte[] VISCOSITY_MASK = new byte[5]
    {
      (byte) 0,
      (byte) 200,
      (byte) 240,
      (byte) 0,
      (byte) 0
    };
    public const float MIN_LIQUID_SIZE = 0.25f;
    public static LiquidRenderer Instance = new LiquidRenderer();
    private Tile[,] _tiles = Main.tile;
    private Texture2D[] _liquidTextures = new Texture2D[12];
    private LiquidRenderer.LiquidCache[] _cache = new LiquidRenderer.LiquidCache[1];
    private LiquidRenderer.LiquidDrawCache[] _drawCache = new LiquidRenderer.LiquidDrawCache[1];
    private int _animationFrame;
    private Rectangle _drawArea = new Rectangle(0, 0, 1, 1);
    private UnifiedRandom _random = new UnifiedRandom();
    private Color[] _waveMask = new Color[1];
    private float _frameState;

    public event Action<Color[], Rectangle> WaveFilters;

    public LiquidRenderer()
    {
      for (int index = 0; index < this._liquidTextures.Length; ++index)
        this._liquidTextures[index] = TextureManager.Load("Images/Misc/water_" + (object) index);
    }

    private unsafe void InternalPrepareDraw(Rectangle drawArea)
    {
      Rectangle rectangle = new Rectangle(drawArea.X - 2, drawArea.Y - 2, drawArea.Width + 4, drawArea.Height + 4);
      this._drawArea = drawArea;
      if (this._cache.Length < rectangle.Width * rectangle.Height + 1)
        this._cache = new LiquidRenderer.LiquidCache[rectangle.Width * rectangle.Height + 1];
      if (this._drawCache.Length < drawArea.Width * drawArea.Height + 1)
        this._drawCache = new LiquidRenderer.LiquidDrawCache[drawArea.Width * drawArea.Height + 1];
      if (this._waveMask.Length < drawArea.Width * drawArea.Height)
        this._waveMask = new Color[drawArea.Width * drawArea.Height];
      fixed (LiquidRenderer.LiquidCache* liquidCachePtr1 = &this._cache[1])
      {
        int num1 = rectangle.Height * 2 + 2;
        LiquidRenderer.LiquidCache* liquidCachePtr2 = liquidCachePtr1;
        for (int x = rectangle.X; x < rectangle.X + rectangle.Width; ++x)
        {
          for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; ++y)
          {
            Tile tile = this._tiles[x, y] ?? new Tile();
            liquidCachePtr2->LiquidLevel = (float) tile.liquid / (float) byte.MaxValue;
            liquidCachePtr2->IsHalfBrick = tile.halfBrick() && liquidCachePtr2[-1].HasLiquid;
            liquidCachePtr2->IsSolid = WorldGen.SolidOrSlopedTile(tile) && !liquidCachePtr2->IsHalfBrick;
            liquidCachePtr2->HasLiquid = tile.liquid > (byte) 0;
            liquidCachePtr2->VisibleLiquidLevel = 0.0f;
            liquidCachePtr2->HasWall = tile.wall > (byte) 0;
            liquidCachePtr2->Type = tile.liquidType();
            if (liquidCachePtr2->IsHalfBrick && !liquidCachePtr2->HasLiquid)
              liquidCachePtr2->Type = liquidCachePtr2[-1].Type;
            ++liquidCachePtr2;
          }
        }
        LiquidRenderer.LiquidCache* liquidCachePtr3 = liquidCachePtr1 + num1;
        for (int index1 = 2; index1 < rectangle.Width - 2; ++index1)
        {
          for (int index2 = 2; index2 < rectangle.Height - 2; ++index2)
          {
            float val1 = 0.0f;
            float num2;
            if (liquidCachePtr3->IsHalfBrick && liquidCachePtr3[-1].HasLiquid)
              num2 = 1f;
            else if (!liquidCachePtr3->HasLiquid)
            {
              LiquidRenderer.LiquidCache liquidCache1 = liquidCachePtr3[-rectangle.Height];
              LiquidRenderer.LiquidCache liquidCache2 = liquidCachePtr3[rectangle.Height];
              LiquidRenderer.LiquidCache liquidCache3 = liquidCachePtr3[-1];
              LiquidRenderer.LiquidCache liquidCache4 = liquidCachePtr3[1];
              if (liquidCache1.HasLiquid && liquidCache2.HasLiquid && (int) liquidCache1.Type == (int) liquidCache2.Type)
              {
                val1 = liquidCache1.LiquidLevel + liquidCache2.LiquidLevel;
                liquidCachePtr3->Type = liquidCache1.Type;
              }
              if (liquidCache3.HasLiquid && liquidCache4.HasLiquid && (int) liquidCache3.Type == (int) liquidCache4.Type)
              {
                val1 = Math.Max(val1, liquidCache3.LiquidLevel + liquidCache4.LiquidLevel);
                liquidCachePtr3->Type = liquidCache3.Type;
              }
              num2 = val1 * 0.5f;
            }
            else
              num2 = liquidCachePtr3->LiquidLevel;
            liquidCachePtr3->VisibleLiquidLevel = num2;
            liquidCachePtr3->HasVisibleLiquid = (double) num2 != 0.0;
            ++liquidCachePtr3;
          }
          liquidCachePtr3 += 4;
        }
        LiquidRenderer.LiquidCache* liquidCachePtr4 = liquidCachePtr1;
        for (int index3 = 0; index3 < rectangle.Width; ++index3)
        {
          for (int index4 = 0; index4 < rectangle.Height - 10; ++index4)
          {
            if (liquidCachePtr4->HasVisibleLiquid && !liquidCachePtr4->IsSolid)
            {
              liquidCachePtr4->Opacity = 1f;
              liquidCachePtr4->VisibleType = liquidCachePtr4->Type;
              float num3 = 1f / (float) (LiquidRenderer.WATERFALL_LENGTH[(int) liquidCachePtr4->Type] + 1);
              float num4 = 1f;
              for (int index5 = 1; index5 <= LiquidRenderer.WATERFALL_LENGTH[(int) liquidCachePtr4->Type]; ++index5)
              {
                num4 -= num3;
                if (!liquidCachePtr4[index5].IsSolid)
                {
                  liquidCachePtr4[index5].VisibleLiquidLevel = Math.Max(liquidCachePtr4[index5].VisibleLiquidLevel, liquidCachePtr4->VisibleLiquidLevel * num4);
                  liquidCachePtr4[index5].Opacity = num4;
                  liquidCachePtr4[index5].VisibleType = liquidCachePtr4->Type;
                }
                else
                  break;
              }
            }
            if (liquidCachePtr4->IsSolid)
            {
              liquidCachePtr4->VisibleLiquidLevel = 1f;
              liquidCachePtr4->HasVisibleLiquid = false;
            }
            else
              liquidCachePtr4->HasVisibleLiquid = (double) liquidCachePtr4->VisibleLiquidLevel != 0.0;
            ++liquidCachePtr4;
          }
          liquidCachePtr4 += 10;
        }
        LiquidRenderer.LiquidCache* liquidCachePtr5 = liquidCachePtr1 + num1;
        for (int index6 = 2; index6 < rectangle.Width - 2; ++index6)
        {
          for (int index7 = 2; index7 < rectangle.Height - 2; ++index7)
          {
            if (!liquidCachePtr5->HasVisibleLiquid || liquidCachePtr5->IsSolid)
            {
              liquidCachePtr5->HasLeftEdge = false;
              liquidCachePtr5->HasTopEdge = false;
              liquidCachePtr5->HasRightEdge = false;
              liquidCachePtr5->HasBottomEdge = false;
            }
            else
            {
              LiquidRenderer.LiquidCache liquidCache5 = liquidCachePtr5[-1];
              LiquidRenderer.LiquidCache liquidCache6 = liquidCachePtr5[1];
              LiquidRenderer.LiquidCache liquidCache7 = liquidCachePtr5[-rectangle.Height];
              LiquidRenderer.LiquidCache liquidCache8 = liquidCachePtr5[rectangle.Height];
              float num5 = 0.0f;
              float num6 = 1f;
              float num7 = 0.0f;
              float num8 = 1f;
              float visibleLiquidLevel = liquidCachePtr5->VisibleLiquidLevel;
              if (!liquidCache5.HasVisibleLiquid)
                num7 += liquidCache6.VisibleLiquidLevel * (1f - visibleLiquidLevel);
              if (!liquidCache6.HasVisibleLiquid && !liquidCache6.IsSolid && !liquidCache6.IsHalfBrick)
                num8 -= liquidCache5.VisibleLiquidLevel * (1f - visibleLiquidLevel);
              if (!liquidCache7.HasVisibleLiquid && !liquidCache7.IsSolid && !liquidCache7.IsHalfBrick)
                num5 += liquidCache8.VisibleLiquidLevel * (1f - visibleLiquidLevel);
              if (!liquidCache8.HasVisibleLiquid && !liquidCache8.IsSolid && !liquidCache8.IsHalfBrick)
                num6 -= liquidCache7.VisibleLiquidLevel * (1f - visibleLiquidLevel);
              liquidCachePtr5->LeftWall = num5;
              liquidCachePtr5->RightWall = num6;
              liquidCachePtr5->BottomWall = num8;
              liquidCachePtr5->TopWall = num7;
              Point zero = Point.Zero;
              liquidCachePtr5->HasTopEdge = !liquidCache5.HasVisibleLiquid && !liquidCache5.IsSolid || (double) num7 != 0.0;
              liquidCachePtr5->HasBottomEdge = !liquidCache6.HasVisibleLiquid && !liquidCache6.IsSolid || (double) num8 != 1.0;
              liquidCachePtr5->HasLeftEdge = !liquidCache7.HasVisibleLiquid && !liquidCache7.IsSolid || (double) num5 != 0.0;
              liquidCachePtr5->HasRightEdge = !liquidCache8.HasVisibleLiquid && !liquidCache8.IsSolid || (double) num6 != 1.0;
              if (!liquidCachePtr5->HasLeftEdge)
              {
                if (liquidCachePtr5->HasRightEdge)
                  zero.X += 32;
                else
                  zero.X += 16;
              }
              if (liquidCachePtr5->HasLeftEdge && liquidCachePtr5->HasRightEdge)
              {
                zero.X = 16;
                zero.Y += 32;
                if (liquidCachePtr5->HasTopEdge)
                  zero.Y = 16;
              }
              else if (!liquidCachePtr5->HasTopEdge)
              {
                if (!liquidCachePtr5->HasLeftEdge && !liquidCachePtr5->HasRightEdge)
                  zero.Y += 48;
                else
                  zero.Y += 16;
              }
              if (zero.Y == 16 && liquidCachePtr5->HasLeftEdge ^ liquidCachePtr5->HasRightEdge && (index7 + rectangle.Y) % 2 == 0)
                zero.Y += 16;
              liquidCachePtr5->FrameOffset = zero;
            }
            ++liquidCachePtr5;
          }
          liquidCachePtr5 += 4;
        }
        LiquidRenderer.LiquidCache* liquidCachePtr6 = liquidCachePtr1 + num1;
        for (int index8 = 2; index8 < rectangle.Width - 2; ++index8)
        {
          for (int index9 = 2; index9 < rectangle.Height - 2; ++index9)
          {
            if (liquidCachePtr6->HasVisibleLiquid)
            {
              LiquidRenderer.LiquidCache liquidCache9 = liquidCachePtr6[-1];
              LiquidRenderer.LiquidCache liquidCache10 = liquidCachePtr6[1];
              LiquidRenderer.LiquidCache liquidCache11 = liquidCachePtr6[-rectangle.Height];
              LiquidRenderer.LiquidCache liquidCache12 = liquidCachePtr6[rectangle.Height];
              liquidCachePtr6->VisibleLeftWall = liquidCachePtr6->LeftWall;
              liquidCachePtr6->VisibleRightWall = liquidCachePtr6->RightWall;
              liquidCachePtr6->VisibleTopWall = liquidCachePtr6->TopWall;
              liquidCachePtr6->VisibleBottomWall = liquidCachePtr6->BottomWall;
              if (liquidCache9.HasVisibleLiquid && liquidCache10.HasVisibleLiquid)
              {
                if (liquidCachePtr6->HasLeftEdge)
                  liquidCachePtr6->VisibleLeftWall = (float) (((double) liquidCachePtr6->LeftWall * 2.0 + (double) liquidCache9.LeftWall + (double) liquidCache10.LeftWall) * 0.25);
                if (liquidCachePtr6->HasRightEdge)
                  liquidCachePtr6->VisibleRightWall = (float) (((double) liquidCachePtr6->RightWall * 2.0 + (double) liquidCache9.RightWall + (double) liquidCache10.RightWall) * 0.25);
              }
              if (liquidCache11.HasVisibleLiquid && liquidCache12.HasVisibleLiquid)
              {
                if (liquidCachePtr6->HasTopEdge)
                  liquidCachePtr6->VisibleTopWall = (float) (((double) liquidCachePtr6->TopWall * 2.0 + (double) liquidCache11.TopWall + (double) liquidCache12.TopWall) * 0.25);
                if (liquidCachePtr6->HasBottomEdge)
                  liquidCachePtr6->VisibleBottomWall = (float) (((double) liquidCachePtr6->BottomWall * 2.0 + (double) liquidCache11.BottomWall + (double) liquidCache12.BottomWall) * 0.25);
              }
            }
            ++liquidCachePtr6;
          }
          liquidCachePtr6 += 4;
        }
        LiquidRenderer.LiquidCache* liquidCachePtr7 = liquidCachePtr1 + num1;
        for (int index10 = 2; index10 < rectangle.Width - 2; ++index10)
        {
          for (int index11 = 2; index11 < rectangle.Height - 2; ++index11)
          {
            if (liquidCachePtr7->HasLiquid)
            {
              LiquidRenderer.LiquidCache liquidCache13 = liquidCachePtr7[-1];
              LiquidRenderer.LiquidCache liquidCache14 = liquidCachePtr7[1];
              LiquidRenderer.LiquidCache liquidCache15 = liquidCachePtr7[-rectangle.Height];
              LiquidRenderer.LiquidCache liquidCache16 = liquidCachePtr7[rectangle.Height];
              if (liquidCachePtr7->HasTopEdge && !liquidCachePtr7->HasBottomEdge && liquidCachePtr7->HasLeftEdge ^ liquidCachePtr7->HasRightEdge)
              {
                if (liquidCachePtr7->HasRightEdge)
                {
                  liquidCachePtr7->VisibleRightWall = liquidCache14.VisibleRightWall;
                  liquidCachePtr7->VisibleTopWall = liquidCache15.VisibleTopWall;
                }
                else
                {
                  liquidCachePtr7->VisibleLeftWall = liquidCache14.VisibleLeftWall;
                  liquidCachePtr7->VisibleTopWall = liquidCache16.VisibleTopWall;
                }
              }
              else if (liquidCache14.FrameOffset.X == 16 && liquidCache14.FrameOffset.Y == 32)
              {
                if ((double) liquidCachePtr7->VisibleLeftWall > 0.5)
                {
                  liquidCachePtr7->VisibleLeftWall = 0.0f;
                  liquidCachePtr7->FrameOffset = new Point(0, 0);
                }
                else if ((double) liquidCachePtr7->VisibleRightWall < 0.5)
                {
                  liquidCachePtr7->VisibleRightWall = 1f;
                  liquidCachePtr7->FrameOffset = new Point(32, 0);
                }
              }
            }
            ++liquidCachePtr7;
          }
          liquidCachePtr7 += 4;
        }
        LiquidRenderer.LiquidCache* liquidCachePtr8 = liquidCachePtr1 + num1;
        for (int index12 = 2; index12 < rectangle.Width - 2; ++index12)
        {
          for (int index13 = 2; index13 < rectangle.Height - 2; ++index13)
          {
            if (liquidCachePtr8->HasLiquid)
            {
              LiquidRenderer.LiquidCache liquidCache17 = liquidCachePtr8[-1];
              LiquidRenderer.LiquidCache liquidCache18 = liquidCachePtr8[1];
              LiquidRenderer.LiquidCache liquidCache19 = liquidCachePtr8[-rectangle.Height];
              LiquidRenderer.LiquidCache liquidCache20 = liquidCachePtr8[rectangle.Height];
              if (!liquidCachePtr8->HasBottomEdge && !liquidCachePtr8->HasLeftEdge && !liquidCachePtr8->HasTopEdge && !liquidCachePtr8->HasRightEdge)
              {
                if (liquidCache19.HasTopEdge && liquidCache17.HasLeftEdge)
                {
                  liquidCachePtr8->FrameOffset.X = Math.Max(4, (int) (16.0 - (double) liquidCache17.VisibleLeftWall * 16.0)) - 4;
                  liquidCachePtr8->FrameOffset.Y = 48 + Math.Max(4, (int) (16.0 - (double) liquidCache19.VisibleTopWall * 16.0)) - 4;
                  liquidCachePtr8->VisibleLeftWall = 0.0f;
                  liquidCachePtr8->VisibleTopWall = 0.0f;
                  liquidCachePtr8->VisibleRightWall = 1f;
                  liquidCachePtr8->VisibleBottomWall = 1f;
                }
                else if (liquidCache20.HasTopEdge && liquidCache17.HasRightEdge)
                {
                  liquidCachePtr8->FrameOffset.X = 32 - Math.Min(16, (int) ((double) liquidCache17.VisibleRightWall * 16.0) - 4);
                  liquidCachePtr8->FrameOffset.Y = 48 + Math.Max(4, (int) (16.0 - (double) liquidCache20.VisibleTopWall * 16.0)) - 4;
                  liquidCachePtr8->VisibleLeftWall = 0.0f;
                  liquidCachePtr8->VisibleTopWall = 0.0f;
                  liquidCachePtr8->VisibleRightWall = 1f;
                  liquidCachePtr8->VisibleBottomWall = 1f;
                }
              }
            }
            ++liquidCachePtr8;
          }
          liquidCachePtr8 += 4;
        }
        LiquidRenderer.LiquidCache* liquidCachePtr9 = liquidCachePtr1 + num1;
        fixed (LiquidRenderer.LiquidDrawCache* liquidDrawCachePtr1 = &this._drawCache[0])
          fixed (Color* colorPtr1 = &this._waveMask[0])
          {
            LiquidRenderer.LiquidDrawCache* liquidDrawCachePtr2 = liquidDrawCachePtr1;
            Color* colorPtr2 = colorPtr1;
            for (int index14 = 2; index14 < rectangle.Width - 2; ++index14)
            {
              for (int index15 = 2; index15 < rectangle.Height - 2; ++index15)
              {
                if (liquidCachePtr9->HasVisibleLiquid)
                {
                  float num9 = Math.Min(0.75f, liquidCachePtr9->VisibleLeftWall);
                  float num10 = Math.Max(0.25f, liquidCachePtr9->VisibleRightWall);
                  float num11 = Math.Min(0.75f, liquidCachePtr9->VisibleTopWall);
                  float num12 = Math.Max(0.25f, liquidCachePtr9->VisibleBottomWall);
                  if (liquidCachePtr9->IsHalfBrick && (double) num12 > 0.5)
                    num12 = 0.5f;
                  liquidDrawCachePtr2->IsVisible = liquidCachePtr9->HasWall || !liquidCachePtr9->IsHalfBrick || !liquidCachePtr9->HasLiquid;
                  liquidDrawCachePtr2->SourceRectangle = new Rectangle((int) (16.0 - (double) num10 * 16.0) + liquidCachePtr9->FrameOffset.X, (int) (16.0 - (double) num12 * 16.0) + liquidCachePtr9->FrameOffset.Y, (int) Math.Ceiling(((double) num10 - (double) num9) * 16.0), (int) Math.Ceiling(((double) num12 - (double) num11) * 16.0));
                  liquidDrawCachePtr2->IsSurfaceLiquid = liquidCachePtr9->FrameOffset.X == 16 && liquidCachePtr9->FrameOffset.Y == 0 && (double) (index15 + rectangle.Y) > Main.worldSurface - 40.0;
                  liquidDrawCachePtr2->Opacity = liquidCachePtr9->Opacity;
                  liquidDrawCachePtr2->LiquidOffset = new Vector2((float) Math.Floor((double) num9 * 16.0), (float) Math.Floor((double) num11 * 16.0));
                  liquidDrawCachePtr2->Type = liquidCachePtr9->VisibleType;
                  liquidDrawCachePtr2->HasWall = liquidCachePtr9->HasWall;
                  byte num13 = LiquidRenderer.WAVE_MASK_STRENGTH[(int) liquidCachePtr9->VisibleType];
                  byte num14 = (byte) ((uint) num13 >> 1);
                  colorPtr2->R = num14;
                  colorPtr2->G = num14;
                  colorPtr2->B = LiquidRenderer.VISCOSITY_MASK[(int) liquidCachePtr9->VisibleType];
                  colorPtr2->A = num13;
                  LiquidRenderer.LiquidCache* liquidCachePtr10 = liquidCachePtr9 - 1;
                  if (index15 != 2 && !liquidCachePtr10->HasVisibleLiquid && !liquidCachePtr10->IsSolid && !liquidCachePtr10->IsHalfBrick)
                    *(colorPtr2 - 1) = *colorPtr2;
                }
                else
                {
                  liquidDrawCachePtr2->IsVisible = false;
                  int index16 = liquidCachePtr9->IsSolid || liquidCachePtr9->IsHalfBrick ? 3 : 4;
                  byte num15 = LiquidRenderer.WAVE_MASK_STRENGTH[index16];
                  byte num16 = (byte) ((uint) num15 >> 1);
                  colorPtr2->R = num16;
                  colorPtr2->G = num16;
                  colorPtr2->B = LiquidRenderer.VISCOSITY_MASK[index16];
                  colorPtr2->A = num15;
                }
                ++liquidCachePtr9;
                ++liquidDrawCachePtr2;
                ++colorPtr2;
              }
              liquidCachePtr9 += 4;
            }
          }
        LiquidRenderer.LiquidCache* liquidCachePtr11 = liquidCachePtr1;
        for (int x = rectangle.X; x < rectangle.X + rectangle.Width; ++x)
        {
          for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; ++y)
          {
            if (liquidCachePtr11->VisibleType == (byte) 1 && liquidCachePtr11->HasVisibleLiquid && Dust.lavaBubbles < 200)
            {
              if (this._random.Next(700) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (y * 16)), 16, 16, 35, newColor: Color.White);
              if (this._random.Next(350) == 0)
              {
                int index = Dust.NewDust(new Vector2((float) (x * 16), (float) (y * 16)), 16, 8, 35, Alpha: 50, newColor: Color.White, Scale: 1.5f);
                Main.dust[index].velocity *= 0.8f;
                Main.dust[index].velocity.X *= 2f;
                Main.dust[index].velocity.Y -= (float) this._random.Next(1, 7) * 0.1f;
                if (this._random.Next(10) == 0)
                  Main.dust[index].velocity.Y *= (float) this._random.Next(2, 5);
                Main.dust[index].noGravity = true;
              }
            }
            ++liquidCachePtr11;
          }
        }
      }
      if (this.WaveFilters == null)
        return;
      this.WaveFilters(this._waveMask, this.GetCachedDrawArea());
    }

    private unsafe void InternalDraw(
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      int waterStyle,
      float globalAlpha,
      bool isBackgroundDraw)
    {
      Rectangle drawArea = this._drawArea;
      Main.tileBatch.Begin();
      fixed (LiquidRenderer.LiquidDrawCache* liquidDrawCachePtr1 = &this._drawCache[0])
      {
        LiquidRenderer.LiquidDrawCache* liquidDrawCachePtr2 = liquidDrawCachePtr1;
        for (int x = drawArea.X; x < drawArea.X + drawArea.Width; ++x)
        {
          for (int y = drawArea.Y; y < drawArea.Y + drawArea.Height; ++y)
          {
            if (liquidDrawCachePtr2->IsVisible)
            {
              Rectangle sourceRectangle = liquidDrawCachePtr2->SourceRectangle;
              if (liquidDrawCachePtr2->IsSurfaceLiquid)
                sourceRectangle.Y = 1280;
              else
                sourceRectangle.Y += this._animationFrame * 80;
              Vector2 liquidOffset = liquidDrawCachePtr2->LiquidOffset;
              float val2 = liquidDrawCachePtr2->Opacity * (isBackgroundDraw ? 1f : LiquidRenderer.DEFAULT_OPACITY[(int) liquidDrawCachePtr2->Type]);
              int index = (int) liquidDrawCachePtr2->Type;
              switch (index)
              {
                case 0:
                  index = waterStyle;
                  val2 *= isBackgroundDraw ? 1f : globalAlpha;
                  break;
                case 2:
                  index = 11;
                  break;
              }
              float num = Math.Min(1f, val2);
              VertexColors vertices;
              Lighting.GetColor4Slice_New(x, y, out vertices);
              vertices.BottomLeftColor *= num;
              vertices.BottomRightColor *= num;
              vertices.TopLeftColor *= num;
              vertices.TopRightColor *= num;
              Main.tileBatch.Draw(this._liquidTextures[index], new Vector2((float) (x << 4), (float) (y << 4)) + drawOffset + liquidOffset, new Rectangle?(sourceRectangle), vertices, Vector2.Zero, 1f, SpriteEffects.None);
            }
            ++liquidDrawCachePtr2;
          }
        }
      }
      Main.tileBatch.End();
    }

    public bool HasFullWater(int x, int y)
    {
      x -= this._drawArea.X;
      y -= this._drawArea.Y;
      int index = x * this._drawArea.Height + y;
      if (index < 0 || index >= this._drawCache.Length)
        return true;
      return this._drawCache[index].IsVisible && !this._drawCache[index].IsSurfaceLiquid;
    }

    public float GetVisibleLiquid(int x, int y)
    {
      x -= this._drawArea.X;
      y -= this._drawArea.Y;
      if (x < 0 || x >= this._drawArea.Width || y < 0 || y >= this._drawArea.Height)
        return 0.0f;
      int index = (x + 2) * (this._drawArea.Height + 4) + y + 2;
      return !this._cache[index].HasVisibleLiquid ? 0.0f : this._cache[index].VisibleLiquidLevel;
    }

    public void Update(GameTime gameTime)
    {
      if (Main.gamePaused || !Main.hasFocus)
        return;
      float val2 = MathHelper.Clamp(Main.windSpeed * 80f, -20f, 20f);
      this._frameState += ((double) val2 >= 0.0 ? Math.Max(10f, val2) : Math.Min(-10f, val2)) * (float) gameTime.ElapsedGameTime.TotalSeconds;
      if ((double) this._frameState < 0.0)
        this._frameState += 16f;
      this._frameState %= 16f;
      this._animationFrame = (int) this._frameState;
    }

    public void PrepareDraw(Rectangle drawArea) => this.InternalPrepareDraw(drawArea);

    public void SetWaveMaskData(ref Texture2D texture)
    {
      if (texture == null || texture.Width < this._drawArea.Height || texture.Height < this._drawArea.Width)
      {
        Console.WriteLine("WaveMaskData texture recreated. {0}x{1}", (object) this._drawArea.Height, (object) this._drawArea.Width);
        if (texture != null)
        {
          try
          {
            texture.Dispose();
          }
          catch
          {
          }
        }
        texture = new Texture2D(Main.instance.GraphicsDevice, this._drawArea.Height, this._drawArea.Width, false, SurfaceFormat.Color);
      }
      texture.SetData<Color>(0, new Rectangle?(new Rectangle(0, 0, this._drawArea.Height, this._drawArea.Width)), this._waveMask, 0, this._drawArea.Width * this._drawArea.Height);
    }

    public Rectangle GetCachedDrawArea() => this._drawArea;

    public void Draw(
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      int waterStyle,
      float alpha,
      bool isBackgroundDraw)
    {
      this.InternalDraw(spriteBatch, drawOffset, waterStyle, alpha, isBackgroundDraw);
    }

    private struct LiquidCache
    {
      public float LiquidLevel;
      public float VisibleLiquidLevel;
      public float Opacity;
      public bool IsSolid;
      public bool IsHalfBrick;
      public bool HasLiquid;
      public bool HasVisibleLiquid;
      public bool HasWall;
      public Point FrameOffset;
      public bool HasLeftEdge;
      public bool HasRightEdge;
      public bool HasTopEdge;
      public bool HasBottomEdge;
      public float LeftWall;
      public float RightWall;
      public float BottomWall;
      public float TopWall;
      public float VisibleLeftWall;
      public float VisibleRightWall;
      public float VisibleBottomWall;
      public float VisibleTopWall;
      public byte Type;
      public byte VisibleType;
    }

    private struct LiquidDrawCache
    {
      public Rectangle SourceRectangle;
      public Vector2 LiquidOffset;
      public bool IsVisible;
      public float Opacity;
      public byte Type;
      public bool IsSurfaceLiquid;
      public bool HasWall;
    }
  }
}
