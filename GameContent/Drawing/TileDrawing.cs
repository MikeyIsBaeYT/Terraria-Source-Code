// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.TileDrawing
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.UI;
using Terraria.Utilities;

namespace Terraria.GameContent.Drawing
{
  public class TileDrawing
  {
    private const int MAX_SPECIALS = 9000;
    private const int MAX_SPECIALS_LEGACY = 1000;
    private const float FORCE_FOR_MIN_WIND = 0.08f;
    private const float FORCE_FOR_MAX_WIND = 1.2f;
    private int _leafFrequency = 100000;
    private int[] _specialsCount = new int[12];
    private Point[][] _specialPositions = new Point[12][];
    private Dictionary<Point, int> _displayDollTileEntityPositions = new Dictionary<Point, int>();
    private Dictionary<Point, int> _hatRackTileEntityPositions = new Dictionary<Point, int>();
    private Dictionary<Point, int> _trainingDummyTileEntityPositions = new Dictionary<Point, int>();
    private Dictionary<Point, int> _itemFrameTileEntityPositions = new Dictionary<Point, int>();
    private Dictionary<Point, int> _foodPlatterTileEntityPositions = new Dictionary<Point, int>();
    private Dictionary<Point, int> _weaponRackTileEntityPositions = new Dictionary<Point, int>();
    private Dictionary<Point, int> _chestPositions = new Dictionary<Point, int>();
    private int _specialTilesCount;
    private int[] _specialTileX = new int[1000];
    private int[] _specialTileY = new int[1000];
    private UnifiedRandom _rand;
    private double _treeWindCounter;
    private double _grassWindCounter;
    private double _sunflowerWindCounter;
    private double _vineWindCounter;
    private WindGrid _windGrid = new WindGrid();
    private bool _shouldShowInvisibleBlocks;
    private List<Point> _vineRootsPositions = new List<Point>();
    private List<Point> _reverseVineRootsPositions = new List<Point>();
    private TilePaintSystemV2 _paintSystem;
    private Color _martianGlow = new Color(0, 0, 0, 0);
    private Color _meteorGlow = new Color(100, 100, 100, 0);
    private Color _lavaMossGlow = new Color(150, 100, 50, 0);
    private Color _kryptonMossGlow = new Color(0, 200, 0, 0);
    private Color _xenonMossGlow = new Color(0, 180, 250, 0);
    private Color _argonMossGlow = new Color(225, 0, 125, 0);
    private bool _isActiveAndNotPaused;
    private Player _localPlayer = new Player();
    private Color _highQualityLightingRequirement;
    private Color _mediumQualityLightingRequirement;
    private static readonly Vector2 _zero;
    private ThreadLocal<TileDrawInfo> _currentTileDrawInfo = new ThreadLocal<TileDrawInfo>((Func<TileDrawInfo>) (() => new TileDrawInfo()));
    private TileDrawInfo _currentTileDrawInfoNonThreaded = new TileDrawInfo();
    private Vector3[] _glowPaintColorSlices = new Vector3[9]
    {
      Vector3.One,
      Vector3.One,
      Vector3.One,
      Vector3.One,
      Vector3.One,
      Vector3.One,
      Vector3.One,
      Vector3.One,
      Vector3.One
    };
    private List<DrawData> _voidLensData = new List<DrawData>();

    private void AddSpecialPoint(int x, int y, TileDrawing.TileCounterType type) => this._specialPositions[(int) type][this._specialsCount[(int) type]++] = new Point(x, y);

    private bool[] _tileSolid => Main.tileSolid;

    private bool[] _tileSolidTop => Main.tileSolidTop;

    private Dust[] _dust => Main.dust;

    private Gore[] _gore => Main.gore;

    public TileDrawing(TilePaintSystemV2 paintSystem)
    {
      this._paintSystem = paintSystem;
      this._rand = new UnifiedRandom();
      for (int index = 0; index < this._specialPositions.Length; ++index)
        this._specialPositions[index] = new Point[9000];
    }

    public void PreparePaintForTilesOnScreen()
    {
      if (Main.GameUpdateCount % 6U > 0U)
        return;
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 vector2 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2 = Vector2.Zero;
      int firstTileX;
      int lastTileX;
      int firstTileY;
      int lastTileY;
      this.GetScreenDrawArea(unscaledPosition, vector2 + (Main.Camera.UnscaledPosition - Main.Camera.ScaledPosition), out firstTileX, out lastTileX, out firstTileY, out lastTileY);
      this.PrepareForAreaDrawing(firstTileX, lastTileX, firstTileY, lastTileY, true);
    }

    public void PrepareForAreaDrawing(
      int firstTileX,
      int lastTileX,
      int firstTileY,
      int lastTileY,
      bool prepareLazily)
    {
      TilePaintSystemV2.TileVariationkey lookupKey1 = new TilePaintSystemV2.TileVariationkey();
      TilePaintSystemV2.WallVariationKey lookupKey2 = new TilePaintSystemV2.WallVariationKey();
      for (int index1 = firstTileY; index1 < lastTileY + 4; ++index1)
      {
        for (int index2 = firstTileX - 2; index2 < lastTileX + 2; ++index2)
        {
          Tile tile = Main.tile[index2, index1];
          if (tile != null)
          {
            if (tile.active())
            {
              Main.instance.LoadTiles((int) tile.type);
              lookupKey1.TileType = (int) tile.type;
              lookupKey1.PaintColor = (int) tile.color();
              int num = 0;
              switch (tile.type)
              {
                case 5:
                  num = TileDrawing.GetTreeBiome(index2, index1, (int) tile.frameX, (int) tile.frameY);
                  break;
                case 323:
                  num = this.GetPalmTreeBiome(index2, index1);
                  break;
              }
              lookupKey1.TileStyle = num;
              if (lookupKey1.PaintColor != 0)
                this._paintSystem.RequestTile(ref lookupKey1);
            }
            if (tile.wall != (ushort) 0)
            {
              Main.instance.LoadWall((int) tile.wall);
              lookupKey2.WallType = (int) tile.wall;
              lookupKey2.PaintColor = (int) tile.wallColor();
              if (lookupKey2.PaintColor != 0)
                this._paintSystem.RequestWall(ref lookupKey2);
            }
            if (!prepareLazily)
              this.MakeExtraPreparations(tile, index2, index1);
          }
        }
      }
    }

    private void MakeExtraPreparations(Tile tile, int x, int y)
    {
      switch (tile.type)
      {
        case 5:
          int treeFrame1 = 0;
          int floorY1 = 0;
          int topTextureFrameWidth1 = 0;
          int topTextureFrameHeight1 = 0;
          int treeStyle1 = 0;
          int xoffset1 = (tile.frameX == (short) 44).ToInt() - (tile.frameX == (short) 66).ToInt();
          if (!WorldGen.GetCommonTreeFoliageData(x, y, xoffset1, ref treeFrame1, ref treeStyle1, out floorY1, out topTextureFrameWidth1, out topTextureFrameHeight1))
            break;
          TilePaintSystemV2.TreeFoliageVariantKey lookupKey1 = new TilePaintSystemV2.TreeFoliageVariantKey()
          {
            TextureIndex = treeStyle1,
            PaintColor = (int) tile.color()
          };
          this._paintSystem.RequestTreeTop(ref lookupKey1);
          this._paintSystem.RequestTreeBranch(ref lookupKey1);
          break;
        case 323:
          int num = 15;
          if (x >= WorldGen.beachDistance && x <= Main.maxTilesX - WorldGen.beachDistance)
            num = 21;
          TilePaintSystemV2.TreeFoliageVariantKey lookupKey2 = new TilePaintSystemV2.TreeFoliageVariantKey()
          {
            TextureIndex = num,
            PaintColor = (int) tile.color()
          };
          this._paintSystem.RequestTreeTop(ref lookupKey2);
          this._paintSystem.RequestTreeBranch(ref lookupKey2);
          break;
        case 583:
        case 584:
        case 585:
        case 586:
        case 587:
        case 588:
        case 589:
          int treeFrame2 = 0;
          int floorY2 = 0;
          int topTextureFrameWidth2 = 0;
          int topTextureFrameHeight2 = 0;
          int treeStyle2 = 0;
          int xoffset2 = (tile.frameX == (short) 44).ToInt() - (tile.frameX == (short) 66).ToInt();
          if (!WorldGen.GetGemTreeFoliageData(x, y, xoffset2, ref treeFrame2, ref treeStyle2, out floorY2, out topTextureFrameWidth2, out topTextureFrameHeight2))
            break;
          TilePaintSystemV2.TreeFoliageVariantKey lookupKey3 = new TilePaintSystemV2.TreeFoliageVariantKey()
          {
            TextureIndex = treeStyle2,
            PaintColor = (int) tile.color()
          };
          this._paintSystem.RequestTreeTop(ref lookupKey3);
          this._paintSystem.RequestTreeBranch(ref lookupKey3);
          break;
        case 596:
        case 616:
          int treeFrame3 = 0;
          int floorY3 = 0;
          int topTextureFrameWidth3 = 0;
          int topTextureFrameHeight3 = 0;
          int treeStyle3 = 0;
          int xoffset3 = (tile.frameX == (short) 44).ToInt() - (tile.frameX == (short) 66).ToInt();
          if (!WorldGen.GetVanityTreeFoliageData(x, y, xoffset3, ref treeFrame3, ref treeStyle3, out floorY3, out topTextureFrameWidth3, out topTextureFrameHeight3))
            break;
          TilePaintSystemV2.TreeFoliageVariantKey lookupKey4 = new TilePaintSystemV2.TreeFoliageVariantKey()
          {
            TextureIndex = treeStyle3,
            PaintColor = (int) tile.color()
          };
          this._paintSystem.RequestTreeTop(ref lookupKey4);
          this._paintSystem.RequestTreeBranch(ref lookupKey4);
          break;
      }
    }

    public void Update()
    {
      double lerpValue = (double) Utils.GetLerpValue(0.08f, 1.2f, Math.Abs(Main.WindForVisuals), true);
      this._treeWindCounter += 1.0 / 240.0 + 1.0 / 240.0 * lerpValue * 2.0;
      this._grassWindCounter += 1.0 / 180.0 + 1.0 / 180.0 * lerpValue * 4.0;
      this._sunflowerWindCounter += 1.0 / 420.0 + 1.0 / 420.0 * lerpValue * 5.0;
      this._vineWindCounter += 1.0 / 120.0 + 1.0 / 120.0 * lerpValue * 0.400000005960464;
      this.UpdateLeafFrequency();
      this.EnsureWindGridSize();
      this._windGrid.Update();
      this._shouldShowInvisibleBlocks = Main.LocalPlayer.CanSeeInvisibleBlocks;
    }

    public void PreDrawTiles(bool solidLayer, bool forRenderTargets, bool intoRenderTargets)
    {
      bool flag = intoRenderTargets || Lighting.UpdateEveryFrame;
      if (!(!solidLayer & flag))
        return;
      this._specialsCount[5] = 0;
      this._specialsCount[4] = 0;
      this._specialsCount[8] = 0;
      this._specialsCount[6] = 0;
      this._specialsCount[3] = 0;
      this._specialsCount[0] = 0;
      this._specialsCount[9] = 0;
      this._specialsCount[10] = 0;
      this._specialsCount[11] = 0;
    }

    public void PostDrawTiles(bool solidLayer, bool forRenderTargets, bool intoRenderTargets)
    {
      if (!solidLayer && !intoRenderTargets)
      {
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, (Effect) null, Main.Transform);
        this.DrawMultiTileVines();
        this.DrawMultiTileGrass();
        this.DrawVoidLenses();
        this.DrawTeleportationPylons();
        this.DrawMasterTrophies();
        this.DrawGrass();
        this.DrawTrees();
        this.DrawVines();
        this.DrawReverseVines();
        Main.spriteBatch.End();
      }
      if (!solidLayer || intoRenderTargets)
        return;
      this.DrawEntities_HatRacks();
      this.DrawEntities_DisplayDolls();
    }

    public void Draw(
      bool solidLayer,
      bool forRenderTargets,
      bool intoRenderTargets,
      int waterStyleOverride = -1)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      this._isActiveAndNotPaused = !Main.gamePaused && Main.instance.IsActive;
      this._localPlayer = Main.LocalPlayer;
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 vector2 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2 = Vector2.Zero;
      if (!solidLayer)
        Main.critterCage = false;
      this.EnsureWindGridSize();
      this.ClearLegacyCachedDraws();
      bool flag = intoRenderTargets || Main.LightingEveryFrame;
      if (flag)
        this.ClearCachedTileDraws(solidLayer);
      float num1 = (float) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 30.0 * (double) Main.gfxQuality);
      this._highQualityLightingRequirement.R = (byte) num1;
      this._highQualityLightingRequirement.G = (byte) ((double) num1 * 1.1);
      this._highQualityLightingRequirement.B = (byte) ((double) num1 * 1.2);
      float num2 = (float) (50.0 * (1.0 - (double) Main.gfxQuality) + 2.0 * (double) Main.gfxQuality);
      this._mediumQualityLightingRequirement.R = (byte) num2;
      this._mediumQualityLightingRequirement.G = (byte) ((double) num2 * 1.1);
      this._mediumQualityLightingRequirement.B = (byte) ((double) num2 * 1.2);
      int firstTileX;
      int lastTileX;
      int firstTileY;
      int lastTileY;
      this.GetScreenDrawArea(unscaledPosition, vector2 + (Main.Camera.UnscaledPosition - Main.Camera.ScaledPosition), out firstTileX, out lastTileX, out firstTileY, out lastTileY);
      byte num3 = (byte) (100.0 + 150.0 * (double) Main.martianLight);
      this._martianGlow = new Color((int) num3, (int) num3, (int) num3, 0);
      TileDrawInfo drawData = this._currentTileDrawInfo.Value;
      for (int index1 = firstTileY; index1 < lastTileY + 4; ++index1)
      {
        for (int index2 = firstTileX - 2; index2 < lastTileX + 2; ++index2)
        {
          Tile tileCache = Main.tile[index2, index1];
          if (tileCache == null)
          {
            Tile tile = new Tile();
            Main.tile[index2, index1] = tile;
            Main.mapTime += 60;
          }
          else if (tileCache.active() && this.IsTileDrawLayerSolid(tileCache.type) == solidLayer)
          {
            ushort type = tileCache.type;
            short frameX = tileCache.frameX;
            short frameY = tileCache.frameY;
            if (!TextureAssets.Tile[(int) type].IsLoaded)
              Main.instance.LoadTiles((int) type);
            switch (type)
            {
              case 27:
                if ((((int) frameX % 36 != 0 ? 0 : (frameY == (short) 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 34:
                if ((((int) frameX % 54 != 0 ? 0 : ((int) frameY % 54 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileVine);
                  continue;
                }
                continue;
              case 42:
              case 270:
              case 271:
              case 572:
              case 581:
                if ((((int) frameX % 18 != 0 ? 0 : ((int) frameY % 36 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileVine);
                  continue;
                }
                continue;
              case 52:
              case 62:
              case 115:
              case 205:
              case 382:
              case 528:
                if (flag)
                {
                  this.CrawlToTopOfVineAndAddSpecialPoint(index1, index2);
                  continue;
                }
                continue;
              case 91:
                if ((((int) frameX % 18 != 0 ? 0 : ((int) frameY % 54 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileVine);
                  continue;
                }
                continue;
              case 95:
              case 126:
              case 444:
                if ((((int) frameX % 36 != 0 ? 0 : ((int) frameY % 36 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileVine);
                  continue;
                }
                continue;
              case 233:
                if (((frameY != (short) 0 ? 0 : ((int) frameX % 54 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                if (((frameY != (short) 34 ? 0 : ((int) frameX % 36 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 236:
              case 238:
                if ((((int) frameX % 36 != 0 ? 0 : (frameY == (short) 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 373:
              case 374:
              case 375:
              case 461:
                this.EmitLiquidDrops(index1, index2, tileCache, type);
                continue;
              case 454:
                if ((((int) frameX % 72 != 0 ? 0 : ((int) frameY % 54 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileVine);
                  continue;
                }
                continue;
              case 465:
              case 591:
              case 592:
                if ((((int) frameX % 36 != 0 ? 0 : ((int) frameY % 54 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileVine);
                  continue;
                }
                continue;
              case 485:
              case 489:
              case 490:
                if (((frameY != (short) 0 ? 0 : ((int) frameX % 36 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 491:
                if (flag && frameX == (short) 18 && frameY == (short) 18)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.VoidLens);
                  break;
                }
                break;
              case 493:
                if (((frameY != (short) 0 ? 0 : ((int) frameX % 18 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 519:
                if ((int) frameX / 18 <= 4 & flag)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 521:
              case 522:
              case 523:
              case 524:
              case 525:
              case 526:
              case 527:
                if (((frameY != (short) 0 ? 0 : ((int) frameX % 36 == 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                  continue;
                }
                continue;
              case 530:
                if (frameX < (short) 270)
                {
                  if ((((int) frameX % 54 != 0 ? 0 : (frameY == (short) 0 ? 1 : 0)) & (flag ? 1 : 0)) != 0)
                  {
                    this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MultiTileGrass);
                    continue;
                  }
                  continue;
                }
                break;
              case 541:
                if (this._shouldShowInvisibleBlocks)
                  break;
                continue;
              case 549:
                if (flag)
                {
                  this.CrawlToBottomOfReverseVineAndAddSpecialPoint(index1, index2);
                  continue;
                }
                continue;
              case 597:
                if (flag && (int) frameX % 54 == 0 && frameY == (short) 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.TeleportationPylon);
                  break;
                }
                break;
              case 617:
                if (flag && (int) frameX % 54 == 0 && (int) frameY % 72 == 0)
                {
                  this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.MasterTrophy);
                  break;
                }
                break;
              default:
                if (this.ShouldSwayInWind(index2, index1, tileCache))
                {
                  if (flag)
                  {
                    this.AddSpecialPoint(index2, index1, TileDrawing.TileCounterType.WindyGrass);
                    continue;
                  }
                  continue;
                }
                break;
            }
            this.DrawSingleTile(drawData, solidLayer, waterStyleOverride, unscaledPosition, vector2, index2, index1);
          }
        }
      }
      if (solidLayer)
      {
        Main.instance.DrawTileCracks(1, Main.player[Main.myPlayer].hitReplace);
        Main.instance.DrawTileCracks(1, Main.player[Main.myPlayer].hitTile);
      }
      this.DrawSpecialTilesLegacy(unscaledPosition, vector2);
      if (TileObject.objectPreview.Active && this._localPlayer.cursorItemIconEnabled && Main.placementPreview && !CaptureManager.Instance.Active)
      {
        Main.instance.LoadTiles((int) TileObject.objectPreview.Type);
        TileObject.DrawPreview(Main.spriteBatch, TileObject.objectPreview, unscaledPosition - vector2);
      }
      if (solidLayer)
        TimeLogger.DrawTime(0, stopwatch.Elapsed.TotalMilliseconds);
      else
        TimeLogger.DrawTime(1, stopwatch.Elapsed.TotalMilliseconds);
    }

    private void CrawlToTopOfVineAndAddSpecialPoint(int j, int i)
    {
      int y = j;
      for (int j1 = j - 1; j1 > 0; --j1)
      {
        Tile tile = Main.tile[i, j1];
        if (WorldGen.SolidTile(i, j1) || !tile.active())
        {
          y = j1 + 1;
          break;
        }
      }
      Point point = new Point(i, y);
      if (this._vineRootsPositions.Contains(point))
        return;
      this._vineRootsPositions.Add(point);
      this.AddSpecialPoint(i, y, TileDrawing.TileCounterType.Vine);
    }

    private void CrawlToBottomOfReverseVineAndAddSpecialPoint(int j, int i)
    {
      int y = j;
      for (int j1 = j; j1 < Main.maxTilesY; ++j1)
      {
        Tile tile = Main.tile[i, j1];
        if (WorldGen.SolidTile(i, j1) || !tile.active())
        {
          y = j1 - 1;
          break;
        }
      }
      Point point = new Point(i, y);
      if (this._reverseVineRootsPositions.Contains(point))
        return;
      this._reverseVineRootsPositions.Add(point);
      this.AddSpecialPoint(i, y, TileDrawing.TileCounterType.ReverseVine);
    }

    private void DrawSingleTile(
      TileDrawInfo drawData,
      bool solidLayer,
      int waterStyleOverride,
      Vector2 screenPosition,
      Vector2 screenOffset,
      int tileX,
      int tileY)
    {
      drawData.tileCache = Main.tile[tileX, tileY];
      drawData.typeCache = drawData.tileCache.type;
      drawData.tileFrameX = drawData.tileCache.frameX;
      drawData.tileFrameY = drawData.tileCache.frameY;
      drawData.tileLight = Lighting.GetColor(tileX, tileY);
      if (drawData.tileCache.liquid > (byte) 0 && drawData.tileCache.type == (ushort) 518)
        return;
      this.GetTileDrawData(tileX, tileY, drawData.tileCache, drawData.typeCache, ref drawData.tileFrameX, ref drawData.tileFrameY, out drawData.tileWidth, out drawData.tileHeight, out drawData.tileTop, out drawData.halfBrickHeight, out drawData.addFrX, out drawData.addFrY, out drawData.tileSpriteEffect, out drawData.glowTexture, out drawData.glowSourceRect, out drawData.glowColor);
      drawData.drawTexture = this.GetTileDrawTexture(drawData.tileCache, tileX, tileY);
      Texture2D highlightTexture = (Texture2D) null;
      Rectangle rectangle1 = Rectangle.Empty;
      Color transparent = Color.Transparent;
      if (TileID.Sets.HasOutlines[(int) drawData.typeCache])
        this.GetTileOutlineInfo(tileX, tileY, drawData.typeCache, ref drawData.tileLight, ref highlightTexture, ref transparent);
      if (this._localPlayer.dangerSense && TileDrawing.IsTileDangerous(this._localPlayer, drawData.tileCache, drawData.typeCache))
      {
        if (drawData.tileLight.R < byte.MaxValue)
          drawData.tileLight.R = byte.MaxValue;
        if (drawData.tileLight.G < (byte) 50)
          drawData.tileLight.G = (byte) 50;
        if (drawData.tileLight.B < (byte) 50)
          drawData.tileLight.B = (byte) 50;
        if (this._isActiveAndNotPaused && this._rand.Next(30) == 0)
        {
          int index = Dust.NewDust(new Vector2((float) (tileX * 16), (float) (tileY * 16)), 16, 16, 60, Alpha: 100, Scale: 0.3f);
          this._dust[index].fadeIn = 1f;
          this._dust[index].velocity *= 0.1f;
          this._dust[index].noLight = true;
          this._dust[index].noGravity = true;
        }
      }
      if (this._localPlayer.findTreasure && Main.IsTileSpelunkable(drawData.typeCache, drawData.tileFrameX, drawData.tileFrameY))
      {
        if (drawData.tileLight.R < (byte) 200)
          drawData.tileLight.R = (byte) 200;
        if (drawData.tileLight.G < (byte) 170)
          drawData.tileLight.G = (byte) 170;
        if (this._isActiveAndNotPaused && this._rand.Next(60) == 0)
        {
          int index = Dust.NewDust(new Vector2((float) (tileX * 16), (float) (tileY * 16)), 16, 16, 204, Alpha: 150, Scale: 0.3f);
          this._dust[index].fadeIn = 1f;
          this._dust[index].velocity *= 0.1f;
          this._dust[index].noLight = true;
        }
      }
      if (this._isActiveAndNotPaused)
      {
        if (!Lighting.UpdateEveryFrame || new FastRandom(Main.TileFrameSeed).WithModifier(tileX, tileY).Next(4) == 0)
          this.DrawTiles_EmitParticles(tileY, tileX, drawData.tileCache, drawData.typeCache, drawData.tileFrameX, drawData.tileFrameY, drawData.tileLight);
        drawData.tileLight = this.DrawTiles_GetLightOverride(tileY, tileX, drawData.tileCache, drawData.typeCache, drawData.tileFrameX, drawData.tileFrameY, drawData.tileLight);
      }
      this.CacheSpecialDraws(tileX, tileY, drawData);
      if (drawData.typeCache == (ushort) 72 && drawData.tileFrameX >= (short) 36)
      {
        int num = 0;
        if (drawData.tileFrameY == (short) 18)
          num = 1;
        else if (drawData.tileFrameY == (short) 36)
          num = 2;
        Main.spriteBatch.Draw(TextureAssets.ShroomCap.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X - 22), (float) (tileY * 16 - (int) screenPosition.Y - 26)) + screenOffset, new Rectangle?(new Rectangle(num * 62, 0, 60, 42)), Lighting.GetColor(tileX, tileY), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      }
      Rectangle normalTileRect = new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight - drawData.halfBrickHeight);
      Vector2 vector2 = new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop + drawData.halfBrickHeight)) + screenOffset;
      if (drawData.tileLight.R < (byte) 1 && drawData.tileLight.G < (byte) 1 && drawData.tileLight.B < (byte) 1)
        return;
      this.DrawTile_LiquidBehindTile(solidLayer, waterStyleOverride, screenPosition, screenOffset, tileX, tileY, drawData);
      drawData.colorTint = Color.White;
      drawData.finalColor = TileDrawing.GetFinalLight(drawData.tileCache, drawData.typeCache, drawData.tileLight, drawData.colorTint);
      switch (drawData.typeCache)
      {
        case 51:
          drawData.finalColor = drawData.tileLight * 0.5f;
          break;
        case 80:
          bool evil;
          bool good;
          bool crimson;
          this.GetCactusType(tileX, tileY, (int) drawData.tileFrameX, (int) drawData.tileFrameY, out evil, out good, out crimson);
          if (evil)
            normalTileRect.Y += 54;
          if (good)
            normalTileRect.Y += 108;
          if (crimson)
          {
            normalTileRect.Y += 162;
            break;
          }
          break;
        case 83:
          drawData.drawTexture = this.GetTileDrawTexture(drawData.tileCache, tileX, tileY);
          break;
        case 129:
          drawData.finalColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 100);
          int num1 = 2;
          if (drawData.tileFrameX >= (short) 324)
            drawData.finalColor = Color.Transparent;
          if (drawData.tileFrameY < (short) 36)
          {
            vector2.Y += (float) (num1 * (drawData.tileFrameY == (short) 0).ToDirectionInt());
            break;
          }
          vector2.X += (float) (num1 * (drawData.tileFrameY == (short) 36).ToDirectionInt());
          break;
        case 136:
          switch ((int) drawData.tileFrameX / 18)
          {
            case 1:
              vector2.X += -2f;
              break;
            case 2:
              vector2.X += 2f;
              break;
          }
          break;
        case 160:
          Color oldColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, (int) byte.MaxValue);
          if (drawData.tileCache.inActive())
            oldColor = drawData.tileCache.actColor(oldColor);
          drawData.finalColor = oldColor;
          break;
        case 272:
          int num2 = (Main.tileFrame[(int) drawData.typeCache] + tileX % 2 + tileY % 2 + tileX % 3 + tileY % 3) % 2 * 90;
          drawData.addFrY += num2;
          normalTileRect.Y += num2;
          break;
        case 323:
          if (drawData.tileCache.frameX <= (short) 132 && drawData.tileCache.frameX >= (short) 88)
            return;
          vector2.X += (float) drawData.tileCache.frameY;
          break;
        case 442:
          if ((int) drawData.tileFrameX / 22 == 3)
          {
            vector2.X += 2f;
            break;
          }
          break;
      }
      if (drawData.typeCache == (ushort) 314)
        this.DrawTile_MinecartTrack(screenPosition, screenOffset, tileX, tileY, drawData);
      else if (drawData.typeCache == (ushort) 171)
        this.DrawXmasTree(screenPosition, screenOffset, tileX, tileY, drawData);
      else
        this.DrawBasicTile(screenPosition, screenOffset, tileX, tileY, drawData, normalTileRect, vector2);
      if (Main.tileGlowMask[(int) drawData.tileCache.type] != (short) -1)
      {
        short num3 = Main.tileGlowMask[(int) drawData.tileCache.type];
        if (TextureAssets.GlowMask.IndexInRange<Asset<Texture2D>>((int) num3))
          drawData.drawTexture = TextureAssets.GlowMask[(int) num3].Value;
        double num4 = Main.timeForVisualEffects * 0.08;
        Color color = Color.White;
        bool flag = false;
        switch (drawData.tileCache.type)
        {
          case 129:
            if (drawData.tileFrameX < (short) 324)
            {
              flag = true;
              break;
            }
            drawData.drawTexture = this.GetTileDrawTexture(drawData.tileCache, tileX, tileY);
            Color rgb = Main.hslToRgb((float) (0.699999988079071 + Math.Sin(6.28318548202515 * (double) Main.GlobalTimeWrappedHourly * 0.159999996423721 + (double) tileX * 0.300000011920929 + (double) tileY * 0.699999988079071) * 0.159999996423721), 1f, 0.5f);
            rgb.A /= (byte) 2;
            color = rgb * 0.3f;
            int num5 = 72;
            for (float f = 0.0f; (double) f < 6.28318548202515; f += 1.570796f)
              Main.spriteBatch.Draw(drawData.drawTexture, vector2 + f.ToRotationVector2() * 2f, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY + num5, drawData.tileWidth, drawData.tileHeight)), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 100);
            break;
          case 209:
            color = PortalHelper.GetPortalColor(Main.myPlayer, drawData.tileCache.frameX >= (short) 288 ? 1 : 0);
            break;
          case 350:
            color = new Color(new Vector4((float) (-Math.Cos((int) (num4 / 6.283) % 3 == 1 ? num4 : 0.0) * 0.2 + 0.2)));
            break;
          case 370:
          case 390:
            color = this._meteorGlow;
            break;
          case 381:
          case 517:
            color = this._lavaMossGlow;
            break;
          case 391:
            color = new Color(250, 250, 250, 200);
            break;
          case 429:
          case 445:
            drawData.drawTexture = this.GetTileDrawTexture(drawData.tileCache, tileX, tileY);
            drawData.addFrY = 18;
            break;
          case 534:
          case 535:
            color = this._kryptonMossGlow;
            break;
          case 536:
          case 537:
            color = this._xenonMossGlow;
            break;
          case 539:
          case 540:
            color = this._argonMossGlow;
            break;
        }
        if (!flag)
        {
          if (drawData.tileCache.slope() == (byte) 0 && !drawData.tileCache.halfBrick())
            Main.spriteBatch.Draw(drawData.drawTexture, vector2, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          else if (drawData.tileCache.halfBrick())
          {
            Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + 10)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY + 10, drawData.tileWidth, 6)), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          }
          else
          {
            byte num6 = drawData.tileCache.slope();
            for (int index = 0; index < 8; ++index)
            {
              int width = index << 1;
              Rectangle rectangle2 = new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY + index * 2, width, 2);
              int num7 = 0;
              switch (num6)
              {
                case 2:
                  rectangle2.X = 16 - width;
                  num7 = 16 - width;
                  break;
                case 3:
                  rectangle2.Width = 16 - width;
                  break;
                case 4:
                  rectangle2.Width = 14 - width;
                  rectangle2.X = width + 2;
                  num7 = width + 2;
                  break;
              }
              Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + (float) num7, (float) (tileY * 16 - (int) screenPosition.Y + index * 2)) + screenOffset, new Rectangle?(rectangle2), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
      }
      if (drawData.glowTexture != null)
      {
        Vector2 position = new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset;
        if (TileID.Sets.Platforms[(int) drawData.typeCache])
          position = vector2;
        Main.spriteBatch.Draw(drawData.glowTexture, position, new Rectangle?(drawData.glowSourceRect), drawData.glowColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      }
      if (highlightTexture == null)
        return;
      rectangle1 = new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight);
      int num8 = 0;
      int num9 = 0;
      Main.spriteBatch.Draw(highlightTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + (float) num8, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop + num9)) + screenOffset, new Rectangle?(rectangle1), transparent, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
    }

    private Texture2D GetTileDrawTexture(Tile tile, int tileX, int tileY)
    {
      Texture2D texture2D = TextureAssets.Tile[(int) tile.type].Value;
      int tileStyle = 0;
      int num = (int) tile.type;
      switch (tile.type)
      {
        case 5:
          tileStyle = TileDrawing.GetTreeBiome(tileX, tileY, (int) tile.frameX, (int) tile.frameY);
          break;
        case 83:
          if (this.IsAlchemyPlantHarvestable((int) tile.frameX / 18))
            num = 84;
          Main.instance.LoadTiles(num);
          break;
        case 323:
          tileStyle = this.GetPalmTreeBiome(tileX, tileY);
          break;
      }
      Texture2D requestIfNotReady = this._paintSystem.TryGetTileAndRequestIfNotReady(num, tileStyle, (int) tile.color());
      if (requestIfNotReady != null)
        texture2D = requestIfNotReady;
      return texture2D;
    }

    private Texture2D GetTileDrawTexture(
      Tile tile,
      int tileX,
      int tileY,
      int paintOverride)
    {
      Texture2D texture2D = TextureAssets.Tile[(int) tile.type].Value;
      int tileStyle = 0;
      int num = (int) tile.type;
      switch (tile.type)
      {
        case 5:
          tileStyle = TileDrawing.GetTreeBiome(tileX, tileY, (int) tile.frameX, (int) tile.frameY);
          break;
        case 83:
          if (this.IsAlchemyPlantHarvestable((int) tile.frameX / 18))
            num = 84;
          Main.instance.LoadTiles(num);
          break;
        case 323:
          tileStyle = this.GetPalmTreeBiome(tileX, tileY);
          break;
      }
      Texture2D requestIfNotReady = this._paintSystem.TryGetTileAndRequestIfNotReady(num, tileStyle, paintOverride);
      if (requestIfNotReady != null)
        texture2D = requestIfNotReady;
      return texture2D;
    }

    private void DrawBasicTile(
      Vector2 screenPosition,
      Vector2 screenOffset,
      int tileX,
      int tileY,
      TileDrawInfo drawData,
      Rectangle normalTileRect,
      Vector2 normalTilePosition)
    {
      if (drawData.tileCache.slope() > (byte) 0)
      {
        if (TileID.Sets.Platforms[(int) drawData.tileCache.type])
        {
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(normalTileRect), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          if (drawData.tileCache.slope() == (byte) 1 && Main.tile[tileX + 1, tileY + 1].active() && Main.tileSolid[(int) Main.tile[tileX + 1, tileY + 1].type] && Main.tile[tileX + 1, tileY + 1].slope() != (byte) 2 && !Main.tile[tileX + 1, tileY + 1].halfBrick() && (!Main.tile[tileX, tileY + 1].active() || Main.tile[tileX, tileY + 1].blockType() != 0 && Main.tile[tileX, tileY + 1].blockType() != 5 || !TileID.Sets.BlocksStairs[(int) Main.tile[tileX, tileY + 1].type] && !TileID.Sets.BlocksStairsAbove[(int) Main.tile[tileX, tileY + 1].type]))
          {
            Rectangle rectangle = new Rectangle(198, (int) drawData.tileFrameY, 16, 16);
            if (TileID.Sets.Platforms[(int) Main.tile[tileX + 1, tileY + 1].type] && Main.tile[tileX + 1, tileY + 1].slope() == (byte) 0)
              rectangle.X = 324;
            Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, 16f), new Rectangle?(rectangle), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          }
          else
          {
            if (drawData.tileCache.slope() != (byte) 2 || !Main.tile[tileX - 1, tileY + 1].active() || !Main.tileSolid[(int) Main.tile[tileX - 1, tileY + 1].type] || Main.tile[tileX - 1, tileY + 1].slope() == (byte) 1 || Main.tile[tileX - 1, tileY + 1].halfBrick() || Main.tile[tileX, tileY + 1].active() && (Main.tile[tileX, tileY + 1].blockType() == 0 || Main.tile[tileX, tileY + 1].blockType() == 4) && (TileID.Sets.BlocksStairs[(int) Main.tile[tileX, tileY + 1].type] || TileID.Sets.BlocksStairsAbove[(int) Main.tile[tileX, tileY + 1].type]))
              return;
            Rectangle rectangle = new Rectangle(162, (int) drawData.tileFrameY, 16, 16);
            if (TileID.Sets.Platforms[(int) Main.tile[tileX - 1, tileY + 1].type] && Main.tile[tileX - 1, tileY + 1].slope() == (byte) 0)
              rectangle.X = 306;
            Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, 16f), new Rectangle?(rectangle), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          }
        }
        else if (TileID.Sets.HasSlopeFrames[(int) drawData.tileCache.type])
        {
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, 16, 16)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
        }
        else
        {
          int num1 = (int) drawData.tileCache.slope();
          int width = 2;
          for (int index = 0; index < 8; ++index)
          {
            int num2 = index * -2;
            int height = 16 - index * 2;
            int num3 = 16 - height;
            int num4;
            switch (num1)
            {
              case 1:
                num2 = 0;
                num4 = index * 2;
                height = 14 - index * 2;
                num3 = 0;
                break;
              case 2:
                num2 = 0;
                num4 = 16 - index * 2 - 2;
                height = 14 - index * 2;
                num3 = 0;
                break;
              case 3:
                num4 = index * 2;
                break;
              default:
                num4 = 16 - index * 2 - 2;
                break;
            }
            Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2((float) num4, (float) (index * width + num2)), new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX + num4, (int) drawData.tileFrameY + drawData.addFrY + num3, width, height)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          }
          int num5 = num1 > 2 ? 0 : 14;
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, (float) num5), new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY + num5, 16, 2)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
        }
      }
      else if (!TileID.Sets.Platforms[(int) drawData.typeCache] && !TileID.Sets.IgnoresNearbyHalfbricksWhenDrawn[(int) drawData.typeCache] && this._tileSolid[(int) drawData.typeCache] && !TileID.Sets.NotReallySolid[(int) drawData.typeCache] && !drawData.tileCache.halfBrick() && (Main.tile[tileX - 1, tileY].halfBrick() || Main.tile[tileX + 1, tileY].halfBrick()))
      {
        if (Main.tile[tileX - 1, tileY].halfBrick() && Main.tile[tileX + 1, tileY].halfBrick())
        {
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, 8f), new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, drawData.addFrY + (int) drawData.tileFrameY + 8, drawData.tileWidth, 8)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          Rectangle rectangle = new Rectangle(126 + drawData.addFrX, drawData.addFrY, 16, 8);
          if (Main.tile[tileX, tileY - 1].active() && !Main.tile[tileX, tileY - 1].bottomSlope() && (int) Main.tile[tileX, tileY - 1].type == (int) drawData.typeCache)
            rectangle = new Rectangle(90 + drawData.addFrX, drawData.addFrY, 16, 8);
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(rectangle), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
        }
        else if (Main.tile[tileX - 1, tileY].halfBrick())
        {
          int width = 4;
          if (TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[(int) drawData.typeCache])
            width = 2;
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, 8f), new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, drawData.addFrY + (int) drawData.tileFrameY + 8, drawData.tileWidth, 8)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2((float) width, 0.0f), new Rectangle?(new Rectangle((int) drawData.tileFrameX + width + drawData.addFrX, drawData.addFrY + (int) drawData.tileFrameY, drawData.tileWidth - width, drawData.tileHeight)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(new Rectangle(144 + drawData.addFrX, drawData.addFrY, width, 8)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          if (width != 2)
            return;
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(new Rectangle(148 + drawData.addFrX, drawData.addFrY, 2, 2)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
        }
        else
        {
          if (!Main.tile[tileX + 1, tileY].halfBrick())
            return;
          int width = 4;
          if (TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[(int) drawData.typeCache])
            width = 2;
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, 8f), new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, drawData.addFrY + (int) drawData.tileFrameY + 8, drawData.tileWidth, 8)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, drawData.addFrY + (int) drawData.tileFrameY, drawData.tileWidth - width, drawData.tileHeight)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2((float) (16 - width), 0.0f), new Rectangle?(new Rectangle(144 + (16 - width), 0, width, 8)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          if (width != 2)
            return;
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(14f, 0.0f), new Rectangle?(new Rectangle(156, 0, 2, 2)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
        }
      }
      else if (Lighting.NotRetro && this._tileSolid[(int) drawData.typeCache] && !drawData.tileCache.halfBrick() && !drawData.tileCache.inActive() && drawData.typeCache != (ushort) 137 && drawData.typeCache != (ushort) 235 && drawData.typeCache != (ushort) 388 && drawData.typeCache != (ushort) 476 && drawData.typeCache != (ushort) 160 && drawData.typeCache != (ushort) 138)
      {
        this.DrawSingleTile_SlicedBlock(normalTilePosition, tileX, tileY, drawData);
      }
      else
      {
        if (drawData.halfBrickHeight == 8 && (!Main.tile[tileX, tileY + 1].active() || !this._tileSolid[(int) Main.tile[tileX, tileY + 1].type] || Main.tile[tileX, tileY + 1].halfBrick()))
        {
          if (TileID.Sets.Platforms[(int) drawData.typeCache])
          {
            Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(normalTileRect), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          }
          else
          {
            Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(normalTileRect.Modified(0, 0, 0, -4)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
            Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition + new Vector2(0.0f, 4f), new Rectangle?(new Rectangle(144 + drawData.addFrX, 66 + drawData.addFrY, drawData.tileWidth, 4)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          }
        }
        else
          Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(normalTileRect), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
        this.DrawSingleTile_Flames(screenPosition, screenOffset, tileX, tileY, drawData);
      }
    }

    private int GetPalmTreeBiome(int tileX, int tileY)
    {
      int x = tileX;
      int y = tileY;
      while (Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 323)
        ++y;
      return this.GetPalmTreeVariant(x, y);
    }

    private static int GetTreeBiome(int tileX, int tileY, int tileFrameX, int tileFrameY)
    {
      int x = tileX;
      int y = tileY;
      int type = (int) Main.tile[x, y].type;
      if (tileFrameX == 66 && tileFrameY <= 45)
        ++x;
      if (tileFrameX == 88 && tileFrameY >= 66 && tileFrameY <= 110)
        --x;
      if (tileFrameY >= 198)
      {
        switch (tileFrameX)
        {
          case 44:
            ++x;
            break;
          case 66:
            --x;
            break;
        }
      }
      else if (tileFrameY >= 132)
      {
        switch (tileFrameX)
        {
          case 22:
            --x;
            break;
          case 44:
            ++x;
            break;
        }
      }
      while (Main.tile[x, y].active() && (int) Main.tile[x, y].type == type)
        ++y;
      return TileDrawing.GetTreeVariant(x, y);
    }

    public static int GetTreeVariant(int x, int y)
    {
      if (Main.tile[x, y] == null || !Main.tile[x, y].active())
        return -1;
      switch (Main.tile[x, y].type)
      {
        case 23:
          return 0;
        case 60:
          return (double) y <= Main.worldSurface ? 1 : 5;
        case 70:
          return 6;
        case 109:
        case 492:
          return 2;
        case 147:
          return 3;
        case 199:
          return 4;
        default:
          return -1;
      }
    }

    private TileDrawing.TileFlameData GetTileFlameData(
      int tileX,
      int tileY,
      int type,
      int tileFrameY)
    {
      switch (type)
      {
        case 270:
          return new TileDrawing.TileFlameData()
          {
            flameTexture = TextureAssets.FireflyJar.Value,
            flameColor = new Color(200, 200, 200, 0),
            flameCount = 1
          };
        case 271:
          return new TileDrawing.TileFlameData()
          {
            flameTexture = TextureAssets.LightningbugJar.Value,
            flameColor = new Color(200, 200, 200, 0),
            flameCount = 1
          };
        case 581:
          return new TileDrawing.TileFlameData()
          {
            flameTexture = TextureAssets.GlowMask[291].Value,
            flameColor = new Color(200, 100, 100, 0),
            flameCount = 1
          };
        default:
          if (!Main.tileFlame[type])
            return new TileDrawing.TileFlameData();
          ulong num = Main.TileFrameSeed ^ ((ulong) tileX << 32 | (ulong) (uint) tileY);
          int index = 0;
          switch (type)
          {
            case 4:
              index = 0;
              break;
            case 33:
            case 174:
              index = 1;
              break;
            case 34:
              index = 3;
              break;
            case 35:
              index = 7;
              break;
            case 42:
              index = 13;
              break;
            case 49:
              index = 5;
              break;
            case 93:
              index = 4;
              break;
            case 98:
              index = 6;
              break;
            case 100:
            case 173:
              index = 2;
              break;
            case 372:
              index = 16;
              break;
          }
          TileDrawing.TileFlameData tileFlameData = new TileDrawing.TileFlameData()
          {
            flameTexture = TextureAssets.Flames[index].Value,
            flameSeed = num
          };
          switch (index)
          {
            case 1:
              switch ((int) Main.tile[tileX, tileY].frameY / 22)
              {
                case 5:
                case 6:
                case 7:
                case 10:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.075f;
                  tileFlameData.flameRangeMultY = 0.075f;
                  break;
                case 8:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.3f;
                  tileFlameData.flameRangeMultY = 0.3f;
                  break;
                case 12:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 14:
                  tileFlameData.flameCount = 8;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.1f;
                  break;
                case 16:
                  tileFlameData.flameCount = 4;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 27:
                case 28:
                  tileFlameData.flameCount = 1;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.0f;
                  tileFlameData.flameRangeMultY = 0.0f;
                  break;
                default:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
              }
              break;
            case 2:
              switch ((int) Main.tile[tileX, tileY].frameY / 36)
              {
                case 3:
                  tileFlameData.flameCount = 3;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.05f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 6:
                  tileFlameData.flameCount = 5;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 9:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.3f;
                  tileFlameData.flameRangeMultY = 0.3f;
                  break;
                case 11:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 13:
                  tileFlameData.flameCount = 8;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.1f;
                  break;
                case 28:
                case 29:
                  tileFlameData.flameCount = 1;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.0f;
                  tileFlameData.flameRangeMultY = 0.0f;
                  break;
                default:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
              }
              break;
            case 3:
              switch ((int) Main.tile[tileX, tileY].frameY / 54)
              {
                case 8:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.075f;
                  tileFlameData.flameRangeMultY = 0.075f;
                  break;
                case 9:
                  tileFlameData.flameCount = 3;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.05f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 11:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.3f;
                  tileFlameData.flameRangeMultY = 0.3f;
                  break;
                case 15:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 17:
                case 20:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.075f;
                  tileFlameData.flameRangeMultY = 0.075f;
                  break;
                case 18:
                  tileFlameData.flameCount = 8;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.1f;
                  break;
                case 34:
                case 35:
                  tileFlameData.flameCount = 1;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.0f;
                  tileFlameData.flameRangeMultY = 0.0f;
                  break;
                default:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
              }
              break;
            case 4:
              switch ((int) Main.tile[tileX, tileY].frameY / 54)
              {
                case 1:
                  tileFlameData.flameCount = 3;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 2:
                case 4:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.075f;
                  tileFlameData.flameRangeMultY = 0.075f;
                  break;
                case 3:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -20;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.2f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
                case 5:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.3f;
                  tileFlameData.flameRangeMultY = 0.3f;
                  break;
                case 9:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.15f;
                  break;
                case 12:
                  tileFlameData.flameCount = 1;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.01f;
                  tileFlameData.flameRangeMultY = 0.01f;
                  break;
                case 13:
                  tileFlameData.flameCount = 8;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.1f;
                  tileFlameData.flameRangeMultY = 0.1f;
                  break;
                case 28:
                case 29:
                  tileFlameData.flameCount = 1;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.0f;
                  tileFlameData.flameRangeMultY = 0.0f;
                  break;
                default:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
              }
              break;
            case 7:
              tileFlameData.flameCount = 4;
              tileFlameData.flameColor = new Color(50, 50, 50, 0);
              tileFlameData.flameRangeXMin = -10;
              tileFlameData.flameRangeXMax = 11;
              tileFlameData.flameRangeYMin = -10;
              tileFlameData.flameRangeYMax = 10;
              tileFlameData.flameRangeMultX = 0.0f;
              tileFlameData.flameRangeMultY = 0.0f;
              break;
            case 13:
              switch (tileFrameY / 36)
              {
                case 1:
                case 3:
                case 6:
                case 8:
                case 19:
                case 27:
                case 29:
                case 30:
                case 31:
                case 32:
                case 36:
                case 39:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
                case 2:
                case 16:
                case 25:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.1f;
                  break;
                case 11:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(50, 50, 50, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 11;
                  tileFlameData.flameRangeMultX = 0.075f;
                  tileFlameData.flameRangeMultY = 0.075f;
                  break;
                case 34:
                case 35:
                  tileFlameData.flameCount = 1;
                  tileFlameData.flameColor = new Color(75, 75, 75, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.0f;
                  tileFlameData.flameRangeMultY = 0.0f;
                  break;
                case 44:
                  tileFlameData.flameCount = 7;
                  tileFlameData.flameColor = new Color(100, 100, 100, 0);
                  tileFlameData.flameRangeXMin = -10;
                  tileFlameData.flameRangeXMax = 11;
                  tileFlameData.flameRangeYMin = -10;
                  tileFlameData.flameRangeYMax = 1;
                  tileFlameData.flameRangeMultX = 0.15f;
                  tileFlameData.flameRangeMultY = 0.35f;
                  break;
                default:
                  tileFlameData.flameCount = 0;
                  break;
              }
              break;
            default:
              tileFlameData.flameCount = 7;
              tileFlameData.flameColor = new Color(100, 100, 100, 0);
              if (tileFrameY / 22 == 14)
                tileFlameData.flameColor = new Color((float) Main.DiscoR / (float) byte.MaxValue, (float) Main.DiscoG / (float) byte.MaxValue, (float) Main.DiscoB / (float) byte.MaxValue, 0.0f);
              tileFlameData.flameRangeXMin = -10;
              tileFlameData.flameRangeXMax = 11;
              tileFlameData.flameRangeYMin = -10;
              tileFlameData.flameRangeYMax = 1;
              tileFlameData.flameRangeMultX = 0.15f;
              tileFlameData.flameRangeMultY = 0.35f;
              break;
          }
          return tileFlameData;
      }
    }

    private void DrawSingleTile_Flames(
      Vector2 screenPosition,
      Vector2 screenOffset,
      int tileX,
      int tileY,
      TileDrawInfo drawData)
    {
      if (drawData.typeCache == (ushort) 548 && (int) drawData.tileFrameX / 54 > 6)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[297].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), Color.White, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 613)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[298].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), Color.White, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 614)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[299].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), Color.White, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 593)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[295].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), Color.White, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 594)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[296].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), Color.White, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 215 && drawData.tileFrameY < (short) 36)
      {
        int index = 15;
        Color color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
        if ((int) drawData.tileFrameX / 54 == 5)
          color = new Color((float) Main.DiscoR / (float) byte.MaxValue, (float) Main.DiscoG / (float) byte.MaxValue, (float) Main.DiscoB / (float) byte.MaxValue, 0.0f);
        Main.spriteBatch.Draw(TextureAssets.Flames[index].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), color, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      }
      if (drawData.typeCache == (ushort) 85)
      {
        float graveyardVisualIntensity = Main.GraveyardVisualIntensity;
        if ((double) graveyardVisualIntensity > 0.0)
        {
          ulong num1 = Main.TileFrameSeed ^ ((ulong) tileX << 32 | (ulong) (uint) tileY);
          TileDrawing.TileFlameData tileFlameData = this.GetTileFlameData(tileX, tileY, (int) drawData.typeCache, (int) drawData.tileFrameY);
          if (num1 == 0UL)
            num1 = tileFlameData.flameSeed;
          tileFlameData.flameSeed = num1;
          Vector2 position = new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset;
          Rectangle rectangle = new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight);
          for (int index = 0; index < tileFlameData.flameCount; ++index)
          {
            Color color = tileFlameData.flameColor * graveyardVisualIntensity;
            float x = (float) Utils.RandomInt(ref tileFlameData.flameSeed, tileFlameData.flameRangeXMin, tileFlameData.flameRangeXMax) * tileFlameData.flameRangeMultX;
            float y = (float) Utils.RandomInt(ref tileFlameData.flameSeed, tileFlameData.flameRangeYMin, tileFlameData.flameRangeYMax) * tileFlameData.flameRangeMultY;
            for (float num2 = 0.0f; (double) num2 < 1.0; num2 += 0.25f)
              Main.spriteBatch.Draw(tileFlameData.flameTexture, position + new Vector2(x, y) + Vector2.UnitX.RotatedBy((double) num2 * 6.28318548202515) * 2f, new Rectangle?(rectangle), color, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
            Main.spriteBatch.Draw(tileFlameData.flameTexture, position, new Rectangle?(rectangle), Color.White * graveyardVisualIntensity, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
          }
        }
      }
      if (drawData.typeCache == (ushort) 286)
        Main.spriteBatch.Draw(TextureAssets.GlowSnail.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 100, (int) byte.MaxValue, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 582)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[293].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 391)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[131].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), new Color(250, 250, 250, 200), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 619)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[300].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 100, (int) byte.MaxValue, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 270)
        Main.spriteBatch.Draw(TextureAssets.FireflyJar.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 271)
        Main.spriteBatch.Draw(TextureAssets.LightningbugJar.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 581)
        Main.spriteBatch.Draw(TextureAssets.GlowMask[291].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 316 || drawData.typeCache == (ushort) 317 || drawData.typeCache == (ushort) 318)
      {
        int index = (tileX - (int) drawData.tileFrameX / 18) / 2 * ((tileY - (int) drawData.tileFrameY / 18) / 3) % Main.cageFrames;
        Main.spriteBatch.Draw(TextureAssets.JellyfishBowl[(int) drawData.typeCache - 316].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + Main.jellyfishCageFrame[(int) drawData.typeCache - 316, index] * 36, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      }
      if (drawData.typeCache == (ushort) 149 && drawData.tileFrameX < (short) 54)
        Main.spriteBatch.Draw(TextureAssets.XmasLight.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache == (ushort) 300 || drawData.typeCache == (ushort) 302 || drawData.typeCache == (ushort) 303 || drawData.typeCache == (ushort) 306)
      {
        int index = 9;
        if (drawData.typeCache == (ushort) 302)
          index = 10;
        if (drawData.typeCache == (ushort) 303)
          index = 11;
        if (drawData.typeCache == (ushort) 306)
          index = 12;
        Main.spriteBatch.Draw(TextureAssets.Flames[index].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      }
      else if (Main.tileFlame[(int) drawData.typeCache])
      {
        ulong seed = Main.TileFrameSeed ^ ((ulong) tileX << 32 | (ulong) (uint) tileY);
        int typeCache = (int) drawData.typeCache;
        int index1 = 0;
        switch (typeCache)
        {
          case 4:
            index1 = 0;
            break;
          case 33:
          case 174:
            index1 = 1;
            break;
          case 34:
            index1 = 3;
            break;
          case 35:
            index1 = 7;
            break;
          case 42:
            index1 = 13;
            break;
          case 49:
            index1 = 5;
            break;
          case 93:
            index1 = 4;
            break;
          case 98:
            index1 = 6;
            break;
          case 100:
          case 173:
            index1 = 2;
            break;
          case 372:
            index1 = 16;
            break;
        }
        switch (index1)
        {
          case 1:
            switch ((int) Main.tile[tileX, tileY].frameY / 22)
            {
              case 5:
              case 6:
              case 7:
              case 10:
                for (int index2 = 0; index2 < 7; ++index2)
                {
                  float num3 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  float num4 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num3, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num4) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 8:
                for (int index3 = 0; index3 < 7; ++index3)
                {
                  float num5 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  float num6 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num5, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num6) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 12:
                for (int index4 = 0; index4 < 7; ++index4)
                {
                  float num7 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num8 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num7, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num8) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 14:
                for (int index5 = 0; index5 < 8; ++index5)
                {
                  float num9 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num10 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num9, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num10) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 16:
                for (int index6 = 0; index6 < 4; ++index6)
                {
                  float num11 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num12 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num11, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num12) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 27:
              case 28:
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                break;
              default:
                for (int index7 = 0; index7 < 7; ++index7)
                {
                  float num13 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num14 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.35f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num13, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num14) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
            }
            break;
          case 2:
            switch ((int) Main.tile[tileX, tileY].frameY / 36)
            {
              case 3:
                for (int index8 = 0; index8 < 3; ++index8)
                {
                  float num15 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.05f;
                  float num16 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num15, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num16) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 6:
                for (int index9 = 0; index9 < 5; ++index9)
                {
                  float num17 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num18 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num17, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num18) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 9:
                for (int index10 = 0; index10 < 7; ++index10)
                {
                  float num19 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  float num20 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num19, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num20) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 11:
                for (int index11 = 0; index11 < 7; ++index11)
                {
                  float num21 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num22 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num21, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num22) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 13:
                for (int index12 = 0; index12 < 8; ++index12)
                {
                  float num23 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num24 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num23, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num24) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 28:
              case 29:
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                break;
              default:
                for (int index13 = 0; index13 < 7; ++index13)
                {
                  float num25 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num26 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.35f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num25, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num26) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
            }
            break;
          case 3:
            switch ((int) Main.tile[tileX, tileY].frameY / 54)
            {
              case 8:
                for (int index14 = 0; index14 < 7; ++index14)
                {
                  float num27 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  float num28 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num27, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num28) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 9:
                for (int index15 = 0; index15 < 3; ++index15)
                {
                  float num29 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.05f;
                  float num30 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num29, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num30) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 11:
                for (int index16 = 0; index16 < 7; ++index16)
                {
                  float num31 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  float num32 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num31, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num32) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 15:
                for (int index17 = 0; index17 < 7; ++index17)
                {
                  float num33 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num34 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num33, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num34) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 17:
              case 20:
                for (int index18 = 0; index18 < 7; ++index18)
                {
                  float num35 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  float num36 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num35, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num36) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 18:
                for (int index19 = 0; index19 < 8; ++index19)
                {
                  float num37 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num38 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num37, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num38) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 34:
              case 35:
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                break;
              default:
                for (int index20 = 0; index20 < 7; ++index20)
                {
                  float num39 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num40 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.35f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num39, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num40) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
            }
            break;
          case 4:
            switch ((int) Main.tile[tileX, tileY].frameY / 54)
            {
              case 1:
                for (int index21 = 0; index21 < 3; ++index21)
                {
                  float num41 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num42 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num41, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num42) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 2:
              case 4:
                for (int index22 = 0; index22 < 7; ++index22)
                {
                  float num43 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  float num44 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.075f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num43, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num44) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 3:
                for (int index23 = 0; index23 < 7; ++index23)
                {
                  float num45 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.2f;
                  float num46 = (float) Utils.RandomInt(ref seed, -20, 1) * 0.35f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num45, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num46) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 5:
                for (int index24 = 0; index24 < 7; ++index24)
                {
                  float num47 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  float num48 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.3f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num47, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num48) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 9:
                for (int index25 = 0; index25 < 7; ++index25)
                {
                  float num49 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num50 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.15f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num49, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num50) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 12:
                float num51 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.01f;
                float num52 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.01f;
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num51, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num52) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(Utils.RandomInt(ref seed, 90, 111), Utils.RandomInt(ref seed, 90, 111), Utils.RandomInt(ref seed, 90, 111), 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                break;
              case 13:
                for (int index26 = 0; index26 < 8; ++index26)
                {
                  float num53 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  float num54 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.1f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num53, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num54) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
              case 28:
              case 29:
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                break;
              default:
                for (int index27 = 0; index27 < 7; ++index27)
                {
                  float num55 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                  float num56 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.35f;
                  Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num55, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num56) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
                }
                break;
            }
            break;
          case 7:
            for (int index28 = 0; index28 < 4; ++index28)
            {
              float num57 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
              float num58 = (float) Utils.RandomInt(ref seed, -10, 10) * 0.15f;
              float num59 = 0.0f;
              float num60 = 0.0f;
              Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num59, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num60) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
            }
            break;
          case 13:
            int num61 = (int) drawData.tileFrameY / 36;
            if (num61 == 1 || num61 == 3 || num61 == 6 || num61 == 8 || num61 == 19 || num61 == 27 || num61 == 29 || num61 == 30 || num61 == 31 || num61 == 32 || num61 == 36 || num61 == 39)
            {
              for (int index29 = 0; index29 < 7; ++index29)
              {
                float num62 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                float num63 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.35f;
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num62, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num63) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(100, 100, 100, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
              }
              break;
            }
            if (num61 == 25 || num61 == 16 || num61 == 2)
            {
              for (int index30 = 0; index30 < 7; ++index30)
              {
                float num64 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                float num65 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.1f;
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num64, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num65) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(50, 50, 50, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
              }
              break;
            }
            if (num61 == 29)
            {
              for (int index31 = 0; index31 < 7; ++index31)
              {
                float num66 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                float num67 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.15f;
                Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num66, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num67) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(25, 25, 25, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
              }
              break;
            }
            if (num61 == 34 || num61 == 35)
            {
              Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(75, 75, 75, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
              break;
            }
            break;
          default:
            for (int index32 = 0; index32 < 7; ++index32)
            {
              Color color = new Color(100, 100, 100, 0);
              if ((int) drawData.tileFrameY / 22 == 14)
                color = new Color((float) Main.DiscoR / (float) byte.MaxValue, (float) Main.DiscoG / (float) byte.MaxValue, (float) Main.DiscoB / (float) byte.MaxValue, 0.0f);
              float num68 = (float) Utils.RandomInt(ref seed, -10, 11) * 0.15f;
              float num69 = (float) Utils.RandomInt(ref seed, -10, 1) * 0.35f;
              Main.spriteBatch.Draw(TextureAssets.Flames[index1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0) + num68, (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop) + num69) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), color, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
            }
            break;
        }
      }
      if (drawData.typeCache == (ushort) 144)
        Main.spriteBatch.Draw(TextureAssets.Timer.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color(200, 200, 200, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
      if (drawData.typeCache != (ushort) 237)
        return;
      Main.spriteBatch.Draw(TextureAssets.SunAltar.Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle((int) drawData.tileFrameX, (int) drawData.tileFrameY, drawData.tileWidth, drawData.tileHeight)), new Color((int) Main.mouseTextColor / 2, (int) Main.mouseTextColor / 2, (int) Main.mouseTextColor / 2, 0), 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
    }

    private int GetPalmTreeVariant(int x, int y)
    {
      int num = -1;
      if (Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 53)
        num = 0;
      if (Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 234)
        num = 1;
      if (Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 116)
        num = 2;
      if (Main.tile[x, y].active() && Main.tile[x, y].type == (ushort) 112)
        num = 3;
      if (WorldGen.IsPalmOasisTree(x))
        num += 4;
      return num;
    }

    private void DrawSingleTile_SlicedBlock(
      Vector2 normalTilePosition,
      int tileX,
      int tileY,
      TileDrawInfo drawData)
    {
      Color color = new Color();
      Vector2 origin = new Vector2();
      if ((int) drawData.tileLight.R > (int) this._highQualityLightingRequirement.R || (int) drawData.tileLight.G > (int) this._highQualityLightingRequirement.G || (int) drawData.tileLight.B > (int) this._highQualityLightingRequirement.B)
      {
        Vector3[] slices = drawData.colorSlices;
        Lighting.GetColor9Slice(tileX, tileY, ref slices);
        Vector3 vector3_1 = drawData.tileLight.ToVector3();
        Vector3 vector3_2 = drawData.colorTint.ToVector3();
        if (drawData.tileCache.color() == (byte) 31)
          slices = this._glowPaintColorSlices;
        for (int index = 0; index < 9; ++index)
        {
          Rectangle rectangle;
          rectangle.X = 0;
          rectangle.Y = 0;
          rectangle.Width = 4;
          rectangle.Height = 4;
          switch (index)
          {
            case 1:
              rectangle.Width = 8;
              rectangle.X = 4;
              break;
            case 2:
              rectangle.X = 12;
              break;
            case 3:
              rectangle.Height = 8;
              rectangle.Y = 4;
              break;
            case 4:
              rectangle.Width = 8;
              rectangle.Height = 8;
              rectangle.X = 4;
              rectangle.Y = 4;
              break;
            case 5:
              rectangle.X = 12;
              rectangle.Y = 4;
              rectangle.Height = 8;
              break;
            case 6:
              rectangle.Y = 12;
              break;
            case 7:
              rectangle.Width = 8;
              rectangle.Height = 4;
              rectangle.X = 4;
              rectangle.Y = 12;
              break;
            case 8:
              rectangle.X = 12;
              rectangle.Y = 12;
              break;
          }
          Vector3 tileLight;
          tileLight.X = (float) (((double) slices[index].X + (double) vector3_1.X) * 0.5);
          tileLight.Y = (float) (((double) slices[index].Y + (double) vector3_1.Y) * 0.5);
          tileLight.Z = (float) (((double) slices[index].Z + (double) vector3_1.Z) * 0.5);
          TileDrawing.GetFinalLight(drawData.tileCache, drawData.typeCache, ref tileLight, ref vector3_2);
          Vector2 position;
          position.X = normalTilePosition.X + (float) rectangle.X;
          position.Y = normalTilePosition.Y + (float) rectangle.Y;
          rectangle.X += (int) drawData.tileFrameX + drawData.addFrX;
          rectangle.Y += (int) drawData.tileFrameY + drawData.addFrY;
          int num1 = (int) ((double) tileLight.X * (double) byte.MaxValue);
          int num2 = (int) ((double) tileLight.Y * (double) byte.MaxValue);
          int num3 = (int) ((double) tileLight.Z * (double) byte.MaxValue);
          if (num1 > (int) byte.MaxValue)
            num1 = (int) byte.MaxValue;
          if (num2 > (int) byte.MaxValue)
            num2 = (int) byte.MaxValue;
          if (num3 > (int) byte.MaxValue)
            num3 = (int) byte.MaxValue;
          int num4 = num3 << 16;
          int num5 = num2 << 8;
          color.PackedValue = (uint) (num1 | num5 | num4 | -16777216);
          Main.spriteBatch.Draw(drawData.drawTexture, position, new Rectangle?(rectangle), color, 0.0f, origin, 1f, drawData.tileSpriteEffect, 0.0f);
        }
      }
      else if ((int) drawData.tileLight.R > (int) this._mediumQualityLightingRequirement.R || (int) drawData.tileLight.G > (int) this._mediumQualityLightingRequirement.G || (int) drawData.tileLight.B > (int) this._mediumQualityLightingRequirement.B)
      {
        Vector3[] colorSlices = drawData.colorSlices;
        Lighting.GetColor4Slice(tileX, tileY, ref colorSlices);
        Vector3 vector3_3 = drawData.tileLight.ToVector3();
        Vector3 vector3_4 = drawData.colorTint.ToVector3();
        Rectangle rectangle;
        rectangle.Width = 8;
        rectangle.Height = 8;
        for (int index = 0; index < 4; ++index)
        {
          rectangle.X = 0;
          rectangle.Y = 0;
          switch (index)
          {
            case 1:
              rectangle.X = 8;
              break;
            case 2:
              rectangle.Y = 8;
              break;
            case 3:
              rectangle.X = 8;
              rectangle.Y = 8;
              break;
          }
          Vector3 tileLight;
          tileLight.X = (float) (((double) colorSlices[index].X + (double) vector3_3.X) * 0.5);
          tileLight.Y = (float) (((double) colorSlices[index].Y + (double) vector3_3.Y) * 0.5);
          tileLight.Z = (float) (((double) colorSlices[index].Z + (double) vector3_3.Z) * 0.5);
          TileDrawing.GetFinalLight(drawData.tileCache, drawData.typeCache, ref tileLight, ref vector3_4);
          Vector2 position;
          position.X = normalTilePosition.X + (float) rectangle.X;
          position.Y = normalTilePosition.Y + (float) rectangle.Y;
          rectangle.X += (int) drawData.tileFrameX + drawData.addFrX;
          rectangle.Y += (int) drawData.tileFrameY + drawData.addFrY;
          int num6 = (int) ((double) tileLight.X * (double) byte.MaxValue);
          int num7 = (int) ((double) tileLight.Y * (double) byte.MaxValue);
          int num8 = (int) ((double) tileLight.Z * (double) byte.MaxValue);
          if (num6 > (int) byte.MaxValue)
            num6 = (int) byte.MaxValue;
          if (num7 > (int) byte.MaxValue)
            num7 = (int) byte.MaxValue;
          if (num8 > (int) byte.MaxValue)
            num8 = (int) byte.MaxValue;
          int num9 = num8 << 16;
          int num10 = num7 << 8;
          color.PackedValue = (uint) (num6 | num10 | num9 | -16777216);
          Main.spriteBatch.Draw(drawData.drawTexture, position, new Rectangle?(rectangle), color, 0.0f, origin, 1f, drawData.tileSpriteEffect, 0.0f);
        }
      }
      else
        Main.spriteBatch.Draw(drawData.drawTexture, normalTilePosition, new Rectangle?(new Rectangle((int) drawData.tileFrameX + drawData.addFrX, (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight)), drawData.finalColor, 0.0f, TileDrawing._zero, 1f, drawData.tileSpriteEffect, 0.0f);
    }

    private void GetCactusType(
      int tileX,
      int tileY,
      int frameX,
      int frameY,
      out bool evil,
      out bool good,
      out bool crimson)
    {
      evil = false;
      good = false;
      crimson = false;
      int index1 = tileX;
      if (frameX == 36)
        --index1;
      if (frameX == 54)
        ++index1;
      if (frameX == 108)
      {
        if (frameY == 18)
          --index1;
        else
          ++index1;
      }
      int index2 = tileY;
      bool flag = false;
      if (Main.tile[index1, index2].type == (ushort) 80 && Main.tile[index1, index2].active())
        flag = true;
      while (!Main.tile[index1, index2].active() || !this._tileSolid[(int) Main.tile[index1, index2].type] || !flag)
      {
        if (Main.tile[index1, index2].type == (ushort) 80 && Main.tile[index1, index2].active())
          flag = true;
        ++index2;
        if (index2 > tileY + 20)
          break;
      }
      if (Main.tile[index1, index2].type == (ushort) 112)
        evil = true;
      if (Main.tile[index1, index2].type == (ushort) 116)
        good = true;
      if (Main.tile[index1, index2].type != (ushort) 234)
        return;
      crimson = true;
    }

    private void DrawXmasTree(
      Vector2 screenPosition,
      Vector2 screenOffset,
      int tileX,
      int tileY,
      TileDrawInfo drawData)
    {
      if (tileY - (int) drawData.tileFrameY > 0 && drawData.tileFrameY == (short) 7 && Main.tile[tileX, tileY - (int) drawData.tileFrameY] != null)
      {
        drawData.tileTop -= 16 * (int) drawData.tileFrameY;
        drawData.tileFrameX = Main.tile[tileX, tileY - (int) drawData.tileFrameY].frameX;
        drawData.tileFrameY = Main.tile[tileX, tileY - (int) drawData.tileFrameY].frameY;
      }
      if (drawData.tileFrameX < (short) 10)
        return;
      int num1 = 0;
      if (((int) drawData.tileFrameY & 1) == 1)
        ++num1;
      if (((int) drawData.tileFrameY & 2) == 2)
        num1 += 2;
      if (((int) drawData.tileFrameY & 4) == 4)
        num1 += 4;
      int num2 = 0;
      if (((int) drawData.tileFrameY & 8) == 8)
        ++num2;
      if (((int) drawData.tileFrameY & 16) == 16)
        num2 += 2;
      if (((int) drawData.tileFrameY & 32) == 32)
        num2 += 4;
      int num3 = 0;
      if (((int) drawData.tileFrameY & 64) == 64)
        ++num3;
      if (((int) drawData.tileFrameY & 128) == 128)
        num3 += 2;
      if (((int) drawData.tileFrameY & 256) == 256)
        num3 += 4;
      if (((int) drawData.tileFrameY & 512) == 512)
        num3 += 8;
      int num4 = 0;
      if (((int) drawData.tileFrameY & 1024) == 1024)
        ++num4;
      if (((int) drawData.tileFrameY & 2048) == 2048)
        num4 += 2;
      if (((int) drawData.tileFrameY & 4096) == 4096)
        num4 += 4;
      if (((int) drawData.tileFrameY & 8192) == 8192)
        num4 += 8;
      Color color1 = Lighting.GetColor(tileX + 1, tileY - 3);
      Main.spriteBatch.Draw(TextureAssets.XmasTree[0].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle(0, 0, 64, 128)), color1, 0.0f, TileDrawing._zero, 1f, SpriteEffects.None, 0.0f);
      if (num1 > 0)
      {
        int num5 = num1 - 1;
        Color color2 = color1;
        if (num5 != 3)
          color2 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        Main.spriteBatch.Draw(TextureAssets.XmasTree[3].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle(66 * num5, 0, 64, 128)), color2, 0.0f, TileDrawing._zero, 1f, SpriteEffects.None, 0.0f);
      }
      if (num2 > 0)
      {
        int num6 = num2 - 1;
        Main.spriteBatch.Draw(TextureAssets.XmasTree[1].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle(66 * num6, 0, 64, 128)), color1, 0.0f, TileDrawing._zero, 1f, SpriteEffects.None, 0.0f);
      }
      if (num3 > 0)
      {
        int num7 = num3 - 1;
        Main.spriteBatch.Draw(TextureAssets.XmasTree[2].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle(66 * num7, 0, 64, 128)), color1, 0.0f, TileDrawing._zero, 1f, SpriteEffects.None, 0.0f);
      }
      if (num4 <= 0)
        return;
      int num8 = num4 - 1;
      Main.spriteBatch.Draw(TextureAssets.XmasTree[4].Value, new Vector2((float) (tileX * 16 - (int) screenPosition.X) - (float) (((double) drawData.tileWidth - 16.0) / 2.0), (float) (tileY * 16 - (int) screenPosition.Y + drawData.tileTop)) + screenOffset, new Rectangle?(new Rectangle(66 * num8, 130 * Main.tileFrame[171], 64, 128)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), 0.0f, TileDrawing._zero, 1f, SpriteEffects.None, 0.0f);
    }

    private void DrawTile_MinecartTrack(
      Vector2 screenPosition,
      Vector2 screenOffset,
      int tileX,
      int tileY,
      TileDrawInfo drawData)
    {
      drawData.tileLight = TileDrawing.GetFinalLight(drawData.tileCache, drawData.typeCache, drawData.tileLight, drawData.colorTint);
      int frontColor;
      int backColor;
      Minecart.TrackColors(tileX, tileY, drawData.tileCache, out frontColor, out backColor);
      drawData.drawTexture = this.GetTileDrawTexture(drawData.tileCache, tileX, tileY, frontColor);
      Texture2D tileDrawTexture = this.GetTileDrawTexture(drawData.tileCache, tileX, tileY, backColor);
      int num = (int) drawData.tileCache.frameNumber();
      if (drawData.tileFrameY != (short) -1)
        Main.spriteBatch.Draw(tileDrawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) (tileY * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect((int) drawData.tileFrameY, Main.tileFrame[314])), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) (tileY * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect((int) drawData.tileFrameX, Main.tileFrame[314])), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      if (Minecart.DrawLeftDecoration((int) drawData.tileFrameY))
        Main.spriteBatch.Draw(tileDrawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) ((tileY + 1) * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect(36)), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      if (Minecart.DrawLeftDecoration((int) drawData.tileFrameX))
        Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) ((tileY + 1) * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect(36)), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      if (Minecart.DrawRightDecoration((int) drawData.tileFrameY))
        Main.spriteBatch.Draw(tileDrawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) ((tileY + 1) * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect(37, Main.tileFrame[314])), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      if (Minecart.DrawRightDecoration((int) drawData.tileFrameX))
        Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) ((tileY + 1) * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect(37)), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      if (Minecart.DrawBumper((int) drawData.tileFrameX))
      {
        Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) ((tileY - 1) * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect(39)), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      }
      else
      {
        if (!Minecart.DrawBouncyBumper((int) drawData.tileFrameX))
          return;
        Main.spriteBatch.Draw(drawData.drawTexture, new Vector2((float) (tileX * 16 - (int) screenPosition.X), (float) ((tileY - 1) * 16 - (int) screenPosition.Y)) + screenOffset, new Rectangle?(Minecart.GetSourceRect(38)), drawData.tileLight, 0.0f, new Vector2(), 1f, drawData.tileSpriteEffect, 0.0f);
      }
    }

    private void DrawTile_LiquidBehindTile(
      bool solidLayer,
      int waterStyleOverride,
      Vector2 screenPosition,
      Vector2 screenOffset,
      int tileX,
      int tileY,
      TileDrawInfo drawData)
    {
      Tile tile1 = Main.tile[tileX + 1, tileY];
      Tile tile2 = Main.tile[tileX - 1, tileY];
      Tile tile3 = Main.tile[tileX, tileY - 1];
      Tile tile4 = Main.tile[tileX, tileY + 1];
      if (tile1 == null)
      {
        tile1 = new Tile();
        Main.tile[tileX + 1, tileY] = tile1;
      }
      if (tile2 == null)
      {
        tile2 = new Tile();
        Main.tile[tileX - 1, tileY] = tile2;
      }
      if (tile3 == null)
      {
        tile3 = new Tile();
        Main.tile[tileX, tileY - 1] = tile3;
      }
      if (tile4 == null)
      {
        tile4 = new Tile();
        Main.tile[tileX, tileY + 1] = tile4;
      }
      if (!solidLayer || drawData.tileCache.inActive() || this._tileSolidTop[(int) drawData.typeCache] || drawData.tileCache.halfBrick() && (tile2.liquid > (byte) 160 || tile1.liquid > (byte) 160) && Main.instance.waterfallManager.CheckForWaterfall(tileX, tileY) || TileID.Sets.BlocksWaterDrawingBehindSelf[(int) drawData.tileCache.type] && drawData.tileCache.slope() == (byte) 0)
        return;
      int num1 = 0;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      int liquidType = 0;
      bool flag6 = false;
      int num2 = (int) drawData.tileCache.slope();
      int num3 = drawData.tileCache.blockType();
      if (drawData.tileCache.type == (ushort) 546 && drawData.tileCache.liquid > (byte) 0)
      {
        flag5 = true;
        flag4 = true;
        flag1 = true;
        flag2 = true;
        switch (drawData.tileCache.liquidType())
        {
          case 0:
            flag6 = true;
            break;
          case 1:
            liquidType = 1;
            break;
          case 2:
            liquidType = 11;
            break;
        }
        num1 = (int) drawData.tileCache.liquid;
      }
      else
      {
        if (drawData.tileCache.liquid > (byte) 0)
        {
          switch (num3)
          {
            case 0:
              goto label_25;
            case 1:
              if (drawData.tileCache.liquid <= (byte) 160)
                goto label_25;
              else
                break;
          }
          flag5 = true;
          switch (drawData.tileCache.liquidType())
          {
            case 0:
              flag6 = true;
              break;
            case 1:
              liquidType = 1;
              break;
            case 2:
              liquidType = 11;
              break;
          }
          if ((int) drawData.tileCache.liquid > num1)
            num1 = (int) drawData.tileCache.liquid;
        }
label_25:
        if (tile2.liquid > (byte) 0 && num2 != 1 && num2 != 3)
        {
          flag1 = true;
          switch (tile2.liquidType())
          {
            case 0:
              flag6 = true;
              break;
            case 1:
              liquidType = 1;
              break;
            case 2:
              liquidType = 11;
              break;
          }
          if ((int) tile2.liquid > num1)
            num1 = (int) tile2.liquid;
        }
        if (tile1.liquid > (byte) 0 && num2 != 2 && num2 != 4)
        {
          flag2 = true;
          switch (tile1.liquidType())
          {
            case 0:
              flag6 = true;
              break;
            case 1:
              liquidType = 1;
              break;
            case 2:
              liquidType = 11;
              break;
          }
          if ((int) tile1.liquid > num1)
            num1 = (int) tile1.liquid;
        }
        if (tile3.liquid > (byte) 0 && num2 != 3 && num2 != 4)
        {
          flag3 = true;
          switch (tile3.liquidType())
          {
            case 0:
              flag6 = true;
              break;
            case 1:
              liquidType = 1;
              break;
            case 2:
              liquidType = 11;
              break;
          }
        }
        if (tile4.liquid > (byte) 0 && num2 != 1 && num2 != 2)
        {
          if (tile4.liquid > (byte) 240)
            flag4 = true;
          switch (tile4.liquidType())
          {
            case 0:
              flag6 = true;
              break;
            case 1:
              liquidType = 1;
              break;
            case 2:
              liquidType = 11;
              break;
          }
        }
      }
      if (!flag3 && !flag4 && !flag1 && !flag2 && !flag5)
        return;
      if (waterStyleOverride != -1)
        Main.waterStyle = waterStyleOverride;
      if (liquidType == 0)
        liquidType = Main.waterStyle;
      Color color = Lighting.GetColor(tileX, tileY);
      Vector2 vector2 = new Vector2((float) (tileX * 16), (float) (tileY * 16));
      Rectangle liquidSize = new Rectangle(0, 4, 16, 16);
      if (flag4 && flag1 | flag2)
      {
        flag1 = true;
        flag2 = true;
      }
      if ((!flag3 || !(flag1 | flag2)) && !(flag4 & flag3))
      {
        if (flag3)
        {
          liquidSize = new Rectangle(0, 4, 16, 4);
          if (drawData.tileCache.halfBrick() || drawData.tileCache.slope() != (byte) 0)
            liquidSize = new Rectangle(0, 4, 16, 12);
        }
        else if (flag4 && !flag1 && !flag2)
        {
          vector2 = new Vector2((float) (tileX * 16), (float) (tileY * 16 + 12));
          liquidSize = new Rectangle(0, 4, 16, 4);
        }
        else
        {
          float num4 = (float) (256 - num1) / 32f;
          int y = 4;
          if (tile3.liquid == (byte) 0 && (num3 != 0 || !WorldGen.SolidTile(tileX, tileY - 1)))
            y = 0;
          if (drawData.tileCache.slope() != (byte) 0)
          {
            vector2 = new Vector2((float) (tileX * 16), (float) (tileY * 16 + (int) num4 * 2));
            liquidSize = new Rectangle(0, (int) num4 * 2, 16, 16 - (int) num4 * 2);
          }
          else if (flag1 & flag2 || drawData.tileCache.halfBrick())
          {
            vector2 = new Vector2((float) (tileX * 16), (float) (tileY * 16 + (int) num4 * 2));
            liquidSize = new Rectangle(0, y, 16, 16 - (int) num4 * 2);
          }
          else if (flag1)
          {
            vector2 = new Vector2((float) (tileX * 16), (float) (tileY * 16 + (int) num4 * 2));
            liquidSize = new Rectangle(0, y, 4, 16 - (int) num4 * 2);
          }
          else
          {
            vector2 = new Vector2((float) (tileX * 16 + 12), (float) (tileY * 16 + (int) num4 * 2));
            liquidSize = new Rectangle(0, y, 4, 16 - (int) num4 * 2);
          }
        }
      }
      float num5 = 0.5f;
      switch (liquidType)
      {
        case 1:
          num5 = 1f;
          break;
        case 11:
          num5 = Math.Max(num5 * 1.7f, 1f);
          break;
      }
      if ((double) tileY <= Main.worldSurface || (double) num5 > 1.0)
      {
        num5 = 1f;
        if (drawData.tileCache.wall == (ushort) 21)
          num5 = 0.9f;
        else if (drawData.tileCache.wall > (ushort) 0)
          num5 = 0.6f;
      }
      if (drawData.tileCache.halfBrick() && tile3.liquid > (byte) 0 && drawData.tileCache.wall > (ushort) 0)
        num5 = 0.0f;
      if (drawData.tileCache.bottomSlope() && (tile2.liquid == (byte) 0 && !WorldGen.SolidTile(tileX - 1, tileY) || tile1.liquid == (byte) 0 && !WorldGen.SolidTile(tileX + 1, tileY)))
        num5 = 0.0f;
      Color aColor = color * num5;
      bool flag7 = false;
      if (flag6)
      {
        for (int index = 0; index < 13; ++index)
        {
          if (Main.IsLiquidStyleWater(index) && (double) Main.liquidAlpha[index] > 0.0 && index != liquidType)
          {
            this.DrawPartialLiquid(drawData.tileCache, vector2 - screenPosition + screenOffset, liquidSize, index, aColor);
            flag7 = true;
            break;
          }
        }
      }
      this.DrawPartialLiquid(drawData.tileCache, vector2 - screenPosition + screenOffset, liquidSize, liquidType, aColor * (flag7 ? Main.liquidAlpha[liquidType] : 1f));
    }

    private void CacheSpecialDraws(int tileX, int tileY, TileDrawInfo drawData)
    {
      if (TileID.Sets.BasicChest[(int) drawData.typeCache])
      {
        Point key = new Point(tileX, tileY);
        if ((int) drawData.tileFrameX % 36 != 0)
          --key.X;
        if ((int) drawData.tileFrameY % 36 != 0)
          --key.Y;
        if (!this._chestPositions.ContainsKey(key))
          this._chestPositions[key] = Chest.FindChest(key.X, key.Y);
        int num1 = (int) drawData.tileFrameX / 18;
        int num2 = (int) drawData.tileFrameY / 18;
        int num3 = (int) drawData.tileFrameX / 36;
        int num4 = num1 * 18;
        drawData.addFrX = num4 - (int) drawData.tileFrameX;
        int num5 = num2 * 18;
        if (this._chestPositions[key] != -1)
        {
          int frame = Main.chest[this._chestPositions[key]].frame;
          if (frame == 1)
            num5 += 38;
          if (frame == 2)
            num5 += 76;
        }
        drawData.addFrY = num5 - (int) drawData.tileFrameY;
        if (num2 != 0)
          drawData.tileHeight = 18;
        if (drawData.typeCache == (ushort) 21 && (num3 == 48 || num3 == 49))
          drawData.glowSourceRect = new Rectangle(16 * (num1 % 2), (int) drawData.tileFrameY + drawData.addFrY, drawData.tileWidth, drawData.tileHeight);
      }
      if (drawData.typeCache == (ushort) 378)
      {
        Point key = new Point(tileX, tileY);
        if ((int) drawData.tileFrameX % 36 != 0)
          --key.X;
        if ((int) drawData.tileFrameY % 54 != 0)
          key.Y -= (int) drawData.tileFrameY / 18;
        if (!this._trainingDummyTileEntityPositions.ContainsKey(key))
          this._trainingDummyTileEntityPositions[key] = TETrainingDummy.Find(key.X, key.Y);
        if (this._trainingDummyTileEntityPositions[key] != -1)
        {
          int npc = ((TETrainingDummy) TileEntity.ByID[this._trainingDummyTileEntityPositions[key]]).npc;
          if (npc != -1)
          {
            int num = Main.npc[npc].frame.Y / 55 * 54 + (int) drawData.tileFrameY;
            drawData.addFrY = num - (int) drawData.tileFrameY;
          }
        }
      }
      if (drawData.typeCache == (ushort) 395)
      {
        Point point = new Point(tileX, tileY);
        if ((int) drawData.tileFrameX % 36 != 0)
          --point.X;
        if ((int) drawData.tileFrameY % 36 != 0)
          --point.Y;
        if (!this._itemFrameTileEntityPositions.ContainsKey(point))
        {
          this._itemFrameTileEntityPositions[point] = TEItemFrame.Find(point.X, point.Y);
          if (this._itemFrameTileEntityPositions[point] != -1)
            this.AddSpecialLegacyPoint(point);
        }
      }
      if (drawData.typeCache == (ushort) 520)
      {
        Point point = new Point(tileX, tileY);
        if (!this._foodPlatterTileEntityPositions.ContainsKey(point))
        {
          this._foodPlatterTileEntityPositions[point] = TEFoodPlatter.Find(point.X, point.Y);
          if (this._foodPlatterTileEntityPositions[point] != -1)
            this.AddSpecialLegacyPoint(point);
        }
      }
      if (drawData.typeCache == (ushort) 471)
      {
        Point point = new Point(tileX, tileY);
        point.X -= (int) drawData.tileFrameX % 54 / 18;
        point.Y -= (int) drawData.tileFrameY % 54 / 18;
        if (!this._weaponRackTileEntityPositions.ContainsKey(point))
        {
          this._weaponRackTileEntityPositions[point] = TEWeaponsRack.Find(point.X, point.Y);
          if (this._weaponRackTileEntityPositions[point] != -1)
            this.AddSpecialLegacyPoint(point);
        }
      }
      if (drawData.typeCache == (ushort) 470)
      {
        Point point = new Point(tileX, tileY);
        point.X -= (int) drawData.tileFrameX % 36 / 18;
        point.Y -= (int) drawData.tileFrameY % 54 / 18;
        if (!this._displayDollTileEntityPositions.ContainsKey(point))
        {
          this._displayDollTileEntityPositions[point] = TEDisplayDoll.Find(point.X, point.Y);
          if (this._displayDollTileEntityPositions[point] != -1)
            this.AddSpecialLegacyPoint(point);
        }
      }
      if (drawData.typeCache == (ushort) 475)
      {
        Point point = new Point(tileX, tileY);
        point.X -= (int) drawData.tileFrameX % 54 / 18;
        point.Y -= (int) drawData.tileFrameY % 72 / 18;
        if (!this._hatRackTileEntityPositions.ContainsKey(point))
        {
          this._hatRackTileEntityPositions[point] = TEHatRack.Find(point.X, point.Y);
          if (this._hatRackTileEntityPositions[point] != -1)
            this.AddSpecialLegacyPoint(point);
        }
      }
      if (drawData.typeCache == (ushort) 323 && drawData.tileFrameX <= (short) 132 && drawData.tileFrameX >= (short) 88)
        this.AddSpecialPoint(tileX, tileY, TileDrawing.TileCounterType.Tree);
      if (drawData.typeCache == (ushort) 412 && drawData.tileFrameX == (short) 0 && drawData.tileFrameY == (short) 0)
        this.AddSpecialLegacyPoint(tileX, tileY);
      if (drawData.typeCache == (ushort) 620 && drawData.tileFrameX == (short) 0 && drawData.tileFrameY == (short) 0)
        this.AddSpecialLegacyPoint(tileX, tileY);
      if (drawData.typeCache == (ushort) 237 && drawData.tileFrameX == (short) 18 && drawData.tileFrameY == (short) 0)
        this.AddSpecialLegacyPoint(tileX, tileY);
      switch (drawData.typeCache)
      {
        case 5:
        case 583:
        case 584:
        case 585:
        case 586:
        case 587:
        case 588:
        case 589:
        case 596:
        case 616:
          if (drawData.tileFrameY < (short) 198 || drawData.tileFrameX < (short) 22)
            break;
          this.AddSpecialPoint(tileX, tileY, TileDrawing.TileCounterType.Tree);
          break;
      }
    }

    private static Color GetFinalLight(
      Tile tileCache,
      ushort typeCache,
      Color tileLight,
      Color tint)
    {
      int num1 = (int) ((double) ((int) tileLight.R * (int) tint.R) / (double) byte.MaxValue);
      int num2 = (int) ((double) ((int) tileLight.G * (int) tint.G) / (double) byte.MaxValue);
      int num3 = (int) ((double) ((int) tileLight.B * (int) tint.B) / (double) byte.MaxValue);
      if (num1 > (int) byte.MaxValue)
        num1 = (int) byte.MaxValue;
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      int num4 = num3 << 16;
      int num5 = num2 << 8;
      tileLight.PackedValue = (uint) (num1 | num5 | num4 | -16777216);
      if (tileCache.color() == (byte) 31)
        tileLight = Color.White;
      if (tileCache.inActive())
        tileLight = tileCache.actColor(tileLight);
      else if (TileDrawing.ShouldTileShine(typeCache, tileCache.frameX))
        tileLight = Main.shine(tileLight, (int) typeCache);
      return tileLight;
    }

    private static void GetFinalLight(
      Tile tileCache,
      ushort typeCache,
      ref Vector3 tileLight,
      ref Vector3 tint)
    {
      tileLight *= tint;
      if (tileCache.inActive())
      {
        tileCache.actColor(ref tileLight);
      }
      else
      {
        if (!TileDrawing.ShouldTileShine(typeCache, tileCache.frameX))
          return;
        Main.shine(ref tileLight, (int) typeCache);
      }
    }

    private static bool ShouldTileShine(ushort type, short frameX)
    {
      if (!Main.tileShine2[(int) type])
        return false;
      switch (type)
      {
        case 21:
        case 441:
          return frameX >= (short) 36 && frameX < (short) 178;
        case 467:
        case 468:
          return frameX >= (short) 144 && frameX < (short) 178;
        default:
          return true;
      }
    }

    private static bool IsTileDangerous(Player localPlayer, Tile tileCache, ushort typeCache)
    {
      bool flag = typeCache == (ushort) 135 || typeCache == (ushort) 137 || typeCache == (ushort) 138 || typeCache == (ushort) 484 || typeCache == (ushort) 141 || typeCache == (ushort) 210 || typeCache == (ushort) 442 || typeCache == (ushort) 443 || typeCache == (ushort) 444 || typeCache == (ushort) 411 || typeCache == (ushort) 485 || typeCache == (ushort) 85;
      if (tileCache.slope() == (byte) 0 && !tileCache.inActive())
      {
        flag = flag || typeCache == (ushort) 32 || typeCache == (ushort) 69 || typeCache == (ushort) 48 || typeCache == (ushort) 232 || typeCache == (ushort) 352 || typeCache == (ushort) 483 || typeCache == (ushort) 482 || typeCache == (ushort) 481 || typeCache == (ushort) 51 || typeCache == (ushort) 229;
        if (!localPlayer.fireWalk)
          flag = flag || typeCache == (ushort) 37 || typeCache == (ushort) 58 || typeCache == (ushort) 76;
        if (!localPlayer.iceSkate)
          flag = flag || typeCache == (ushort) 162;
      }
      return flag;
    }

    private bool IsTileDrawLayerSolid(ushort typeCache) => TileID.Sets.DrawTileInSolidLayer[(int) typeCache].HasValue ? TileID.Sets.DrawTileInSolidLayer[(int) typeCache].Value : this._tileSolid[(int) typeCache];

    private void GetTileOutlineInfo(
      int x,
      int y,
      ushort typeCache,
      ref Color tileLight,
      ref Texture2D highlightTexture,
      ref Color highlightColor)
    {
      bool actuallySelected;
      if (!Main.InSmartCursorHighlightArea(x, y, out actuallySelected))
        return;
      int averageTileLighting = ((int) tileLight.R + (int) tileLight.G + (int) tileLight.B) / 3;
      if (averageTileLighting <= 10)
        return;
      highlightTexture = TextureAssets.HighlightMask[(int) typeCache].Value;
      highlightColor = Colors.GetSelectionGlowColor(actuallySelected, averageTileLighting);
    }

    private void DrawPartialLiquid(
      Tile tileCache,
      Vector2 position,
      Rectangle liquidSize,
      int liquidType,
      Color aColor)
    {
      int num = (int) tileCache.slope();
      if (!TileID.Sets.BlocksWaterDrawingBehindSelf[(int) tileCache.type] || num == 0)
      {
        Main.spriteBatch.Draw(TextureAssets.Liquid[liquidType].Value, position, new Rectangle?(liquidSize), aColor, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      }
      else
      {
        liquidSize.X += 18 * (num - 1);
        if (tileCache.slope() == (byte) 1)
          Main.spriteBatch.Draw(TextureAssets.LiquidSlope[liquidType].Value, position, new Rectangle?(liquidSize), aColor, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        else if (tileCache.slope() == (byte) 2)
          Main.spriteBatch.Draw(TextureAssets.LiquidSlope[liquidType].Value, position, new Rectangle?(liquidSize), aColor, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        else if (tileCache.slope() == (byte) 3)
        {
          Main.spriteBatch.Draw(TextureAssets.LiquidSlope[liquidType].Value, position, new Rectangle?(liquidSize), aColor, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
        else
        {
          if (tileCache.slope() != (byte) 4)
            return;
          Main.spriteBatch.Draw(TextureAssets.LiquidSlope[liquidType].Value, position, new Rectangle?(liquidSize), aColor, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
      }
    }

    private bool InAPlaceWithWind(int x, int y, int width, int height) => WorldGen.InAPlaceWithWind(x, y, width, height);

    private void GetTileDrawData(
      int x,
      int y,
      Tile tileCache,
      ushort typeCache,
      ref short tileFrameX,
      ref short tileFrameY,
      out int tileWidth,
      out int tileHeight,
      out int tileTop,
      out int halfBrickHeight,
      out int addFrX,
      out int addFrY,
      out SpriteEffects tileSpriteEffect,
      out Texture2D glowTexture,
      out Rectangle glowSourceRect,
      out Color glowColor)
    {
      tileTop = 0;
      tileWidth = 16;
      tileHeight = 16;
      halfBrickHeight = 0;
      addFrY = Main.tileFrame[(int) typeCache] * 38;
      addFrX = 0;
      tileSpriteEffect = SpriteEffects.None;
      glowTexture = (Texture2D) null;
      glowSourceRect = Rectangle.Empty;
      glowColor = Color.Transparent;
      switch (typeCache)
      {
        case 3:
        case 24:
        case 61:
        case 71:
        case 110:
        case 201:
          tileHeight = 20;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 4:
          tileWidth = 20;
          tileHeight = 20;
          if (WorldGen.SolidTile(x, y - 1))
          {
            tileTop = 4;
            break;
          }
          break;
        case 5:
          tileWidth = 20;
          tileHeight = 20;
          int treeBiome = TileDrawing.GetTreeBiome(x, y, (int) tileFrameX, (int) tileFrameY);
          tileFrameX += (short) (176 * (treeBiome + 1));
          break;
        case 12:
        case 31:
        case 96:
          addFrY = Main.tileFrame[(int) typeCache] * 36;
          break;
        case 14:
        case 21:
        case 411:
        case 467:
        case 469:
          if (tileFrameY == (short) 18)
          {
            tileHeight = 18;
            break;
          }
          break;
        case 15:
        case 497:
          if ((int) tileFrameY % 40 == 18)
          {
            tileHeight = 18;
            break;
          }
          break;
        case 16:
        case 17:
        case 18:
        case 26:
        case 32:
        case 69:
        case 72:
        case 77:
        case 79:
        case 124:
        case 137:
        case 138:
        case 352:
        case 462:
        case 487:
        case 488:
        case 574:
        case 575:
        case 576:
        case 577:
        case 578:
          tileHeight = 18;
          break;
        case 20:
        case 590:
        case 595:
          tileHeight = 18;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 27:
          if ((int) tileFrameY % 74 == 54)
          {
            tileHeight = 18;
            break;
          }
          break;
        case 28:
        case 105:
        case 470:
        case 475:
        case 506:
        case 547:
        case 548:
        case 552:
        case 560:
        case 597:
        case 613:
        case 621:
        case 622:
          tileTop = 2;
          break;
        case 33:
        case 49:
        case 174:
        case 372:
          tileHeight = 20;
          tileTop = -4;
          break;
        case 52:
        case 62:
        case 115:
        case 205:
        case 382:
        case 528:
          tileTop = -2;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 73:
        case 74:
        case 113:
          tileTop = -12;
          tileHeight = 32;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 78:
        case 85:
        case 100:
        case 133:
        case 134:
        case 173:
        case 210:
        case 233:
        case 254:
        case 283:
        case 378:
        case 457:
        case 466:
        case 520:
          tileTop = 2;
          break;
        case 80:
        case 142:
        case 143:
          tileTop = 2;
          break;
        case 81:
          tileTop -= 8;
          tileHeight = 26;
          tileWidth = 24;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 82:
        case 83:
        case 84:
          tileHeight = 20;
          tileTop = -2;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 89:
          tileTop = 2;
          break;
        case 102:
          tileTop = 2;
          break;
        case 106:
          addFrY = Main.tileFrame[(int) typeCache] * 54;
          break;
        case 129:
          addFrY = 0;
          if (tileFrameX >= (short) 324)
          {
            int num1 = ((int) tileFrameX - 324) / 18;
            int num2 = (num1 + Main.tileFrame[(int) typeCache]) % 6 - num1;
            addFrX = num2 * 18;
            break;
          }
          break;
        case 132:
        case 135:
          tileTop = 2;
          tileHeight = 18;
          break;
        case 136:
          if (tileFrameX == (short) 0)
          {
            tileTop = 2;
            break;
          }
          break;
        case 139:
          tileTop = 2;
          int num3 = (int) tileFrameY / 2016;
          addFrY -= 2016 * num3;
          addFrX += 72 * num3;
          break;
        case 172:
        case 376:
          if ((int) tileFrameY % 38 == 18)
          {
            tileHeight = 18;
            break;
          }
          break;
        case 178:
          if (tileFrameY <= (short) 36)
          {
            tileTop = 2;
            break;
          }
          break;
        case 184:
          tileWidth = 20;
          if (tileFrameY <= (short) 36)
          {
            tileTop = 2;
            break;
          }
          if (tileFrameY <= (short) 108)
          {
            tileTop = -2;
            break;
          }
          break;
        case 185:
        case 186:
        case 187:
          tileTop = 2;
          switch (typeCache)
          {
            case 185:
              Main.tileShine2[185] = tileFrameY == (short) 18 && tileFrameX >= (short) 576 && tileFrameX <= (short) 882;
              if (tileFrameY == (short) 18)
              {
                int num4 = (int) tileFrameX / 1908;
                addFrX -= 1908 * num4;
                addFrY += 18 * num4;
                break;
              }
              break;
            case 186:
              Main.tileShine2[186] = tileFrameX >= (short) 864 && tileFrameX <= (short) 1170;
              break;
            case 187:
              int num5 = (int) tileFrameX / 1890;
              addFrX -= 1890 * num5;
              addFrY += 36 * num5;
              break;
          }
          break;
        case 207:
          tileTop = 2;
          if (tileFrameY >= (short) 72)
          {
            addFrY = Main.tileFrame[(int) typeCache];
            int num6 = x;
            if ((int) tileFrameX % 36 != 0)
              --num6;
            addFrY += num6 % 6;
            if (addFrY >= 6)
              addFrY -= 6;
            addFrY *= 72;
            break;
          }
          addFrY = 0;
          break;
        case 215:
          addFrY = tileFrameY >= (short) 36 ? 252 : Main.tileFrame[(int) typeCache] * 36;
          tileTop = 2;
          break;
        case 217:
        case 218:
        case 564:
          addFrY = Main.tileFrame[(int) typeCache] * 36;
          tileTop = 2;
          break;
        case 219:
        case 220:
          addFrY = Main.tileFrame[(int) typeCache] * 54;
          tileTop = 2;
          break;
        case 227:
          tileWidth = 32;
          tileHeight = 38;
          if (tileFrameX == (short) 238)
            tileTop -= 6;
          else
            tileTop -= 20;
          if (tileFrameX == (short) 204)
          {
            bool evil;
            bool good;
            bool crimson;
            this.GetCactusType(x, y, (int) tileFrameX, (int) tileFrameY, out evil, out good, out crimson);
            if (good)
              tileFrameX += (short) 238;
            if (evil)
              tileFrameX += (short) 204;
            if (crimson)
              tileFrameX += (short) 272;
          }
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 228:
        case 231:
        case 243:
        case 247:
          tileTop = 2;
          addFrY = Main.tileFrame[(int) typeCache] * 54;
          break;
        case 235:
          addFrY = Main.tileFrame[(int) typeCache] * 18;
          break;
        case 238:
          tileTop = 2;
          addFrY = Main.tileFrame[(int) typeCache] * 36;
          break;
        case 244:
          tileTop = 2;
          addFrY = tileFrameX >= (short) 54 ? 0 : Main.tileFrame[(int) typeCache] * 36;
          break;
        case 270:
        case 271:
        case 581:
          int num7 = Main.tileFrame[(int) typeCache] + x % 6;
          if (x % 2 == 0)
            num7 += 3;
          if (x % 3 == 0)
            num7 += 3;
          if (x % 4 == 0)
            num7 += 3;
          while (num7 > 5)
            num7 -= 6;
          addFrX = num7 * 18;
          addFrY = 0;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 272:
          addFrY = 0;
          break;
        case 275:
        case 276:
        case 277:
        case 278:
        case 279:
        case 280:
        case 281:
        case 296:
        case 297:
        case 309:
        case 358:
        case 359:
        case 413:
        case 414:
        case 542:
        case 550:
        case 551:
        case 553:
        case 554:
        case 558:
        case 559:
        case 599:
        case 600:
        case 601:
        case 602:
        case 603:
        case 604:
        case 605:
        case 606:
        case 607:
        case 608:
        case 609:
        case 610:
        case 611:
        case 612:
          tileTop = 2;
          Main.critterCage = true;
          int bigAnimalCageFrame = this.GetBigAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          switch (typeCache)
          {
            case 275:
            case 359:
            case 599:
            case 600:
            case 601:
            case 602:
            case 603:
            case 604:
            case 605:
              addFrY = Main.bunnyCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 276:
            case 413:
            case 414:
            case 606:
            case 607:
            case 608:
            case 609:
            case 610:
            case 611:
            case 612:
              addFrY = Main.squirrelCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 277:
              addFrY = Main.mallardCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 278:
              addFrY = Main.duckCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 279:
            case 358:
              addFrY = Main.birdCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 280:
              addFrY = Main.blueBirdCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 281:
              addFrY = Main.redBirdCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 296:
            case 297:
              addFrY = Main.scorpionCageFrame[0, bigAnimalCageFrame] * 54;
              break;
            case 309:
              addFrY = Main.penguinCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 542:
              addFrY = Main.owlCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 550:
            case 551:
              addFrY = Main.turtleCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 553:
              addFrY = Main.grebeCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 554:
              addFrY = Main.seagullCageFrame[bigAnimalCageFrame] * 54;
              break;
            case 558:
            case 559:
              addFrY = Main.seahorseCageFrame[bigAnimalCageFrame] * 54;
              break;
          }
          break;
        case 282:
        case 505:
        case 543:
          tileTop = 2;
          Main.critterCage = true;
          int waterAnimalCageFrame1 = this.GetWaterAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          addFrY = Main.fishBowlFrame[waterAnimalCageFrame1] * 36;
          break;
        case 285:
        case 286:
        case 298:
        case 299:
        case 310:
        case 339:
        case 361:
        case 362:
        case 363:
        case 364:
        case 391:
        case 392:
        case 393:
        case 394:
        case 532:
        case 533:
        case 538:
        case 544:
        case 555:
        case 556:
        case 582:
        case 619:
          tileTop = 2;
          Main.critterCage = true;
          int smallAnimalCageFrame1 = this.GetSmallAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          switch (typeCache)
          {
            case 285:
              addFrY = Main.snailCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 286:
            case 582:
              addFrY = Main.snail2CageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 298:
            case 361:
              addFrY = Main.frogCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 299:
            case 363:
              addFrY = Main.mouseCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 310:
            case 364:
            case 391:
            case 619:
              addFrY = Main.wormCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 339:
            case 362:
              addFrY = Main.grasshopperCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 392:
            case 393:
            case 394:
              addFrY = Main.slugCageFrame[(int) typeCache - 392, smallAnimalCageFrame1] * 36;
              break;
            case 532:
              addFrY = Main.maggotCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 533:
              addFrY = Main.ratCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 538:
            case 544:
              addFrY = Main.ladybugCageFrame[smallAnimalCageFrame1] * 36;
              break;
            case 555:
            case 556:
              addFrY = Main.waterStriderCageFrame[smallAnimalCageFrame1] * 36;
              break;
          }
          break;
        case 288:
        case 289:
        case 290:
        case 291:
        case 292:
        case 293:
        case 294:
        case 295:
        case 360:
        case 580:
        case 620:
          tileTop = 2;
          Main.critterCage = true;
          int waterAnimalCageFrame2 = this.GetWaterAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          int index1 = (int) typeCache - 288;
          if (typeCache == (ushort) 360 || typeCache == (ushort) 580 || typeCache == (ushort) 620)
            index1 = 8;
          addFrY = Main.butterflyCageFrame[index1, waterAnimalCageFrame2] * 36;
          break;
        case 300:
        case 301:
        case 302:
        case 303:
        case 304:
        case 305:
        case 306:
        case 307:
        case 308:
        case 354:
        case 355:
        case 499:
          addFrY = Main.tileFrame[(int) typeCache] * 54;
          tileTop = 2;
          break;
        case 316:
        case 317:
        case 318:
          tileTop = 2;
          Main.critterCage = true;
          int smallAnimalCageFrame2 = this.GetSmallAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          int index2 = (int) typeCache - 316;
          addFrY = Main.jellyfishCageFrame[index2, smallAnimalCageFrame2] * 36;
          break;
        case 323:
          tileWidth = 20;
          tileHeight = 20;
          int palmTreeBiome = this.GetPalmTreeBiome(x, y);
          tileFrameY = (short) (22 * palmTreeBiome);
          break;
        case 324:
          tileWidth = 20;
          tileHeight = 20;
          tileTop = -2;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 326:
        case 327:
        case 328:
        case 329:
        case 345:
        case 351:
        case 421:
        case 422:
        case 458:
        case 459:
          addFrY = Main.tileFrame[(int) typeCache] * 90;
          break;
        case 330:
        case 331:
        case 332:
        case 333:
          tileTop += 2;
          break;
        case 336:
        case 340:
        case 341:
        case 342:
        case 343:
        case 344:
          addFrY = Main.tileFrame[(int) typeCache] * 90;
          tileTop = 2;
          break;
        case 349:
          tileTop = 2;
          int num8 = (int) tileFrameX % 36;
          int num9 = (int) tileFrameY % 54;
          int frameData1;
          if (Animation.GetTemporaryFrame(x - num8 / 18, y - num9 / 18, out frameData1))
          {
            tileFrameX = (short) (36 * frameData1 + num8);
            break;
          }
          break;
        case 377:
          addFrY = Main.tileFrame[(int) typeCache] * 38;
          tileTop = 2;
          break;
        case 379:
          addFrY = Main.tileFrame[(int) typeCache] * 90;
          break;
        case 388:
        case 389:
          TileObjectData.GetTileData((int) typeCache, (int) tileFrameX / 18);
          int num10 = 94;
          tileTop = -2;
          if ((int) tileFrameY == num10 - 20 || (int) tileFrameY == num10 * 2 - 20 || tileFrameY == (short) 0 || (int) tileFrameY == num10)
            tileHeight = 18;
          if (tileFrameY != (short) 0 && (int) tileFrameY != num10)
          {
            tileTop = 0;
            break;
          }
          break;
        case 390:
          addFrY = Main.tileFrame[(int) typeCache] * 36;
          break;
        case 405:
          tileHeight = 16;
          if (tileFrameY > (short) 0)
            tileHeight = 18;
          int num11 = Main.tileFrame[(int) typeCache];
          if (tileFrameX >= (short) 54)
            num11 = 0;
          addFrY = num11 * 38;
          break;
        case 406:
          tileHeight = 16;
          if ((int) tileFrameY % 54 >= 36)
            tileHeight = 18;
          int num12 = Main.tileFrame[(int) typeCache];
          if (tileFrameY >= (short) 108)
            num12 = 6 - (int) tileFrameY / 54;
          else if (tileFrameY >= (short) 54)
            num12 = Main.tileFrame[(int) typeCache] - 1;
          addFrY = num12 * 56;
          addFrY += (int) tileFrameY / 54 * 2;
          break;
        case 410:
          if (tileFrameY == (short) 36)
            tileHeight = 18;
          if (tileFrameY >= (short) 56)
          {
            addFrY = Main.tileFrame[(int) typeCache];
            addFrY *= 56;
            break;
          }
          addFrY = 0;
          break;
        case 412:
          addFrY = 0;
          tileTop = 2;
          break;
        case 426:
        case 430:
        case 431:
        case 432:
        case 433:
        case 434:
          addFrY = 90;
          break;
        case 428:
          tileTop += 4;
          if (PressurePlateHelper.PressurePlatesPressed.ContainsKey(new Point(x, y)))
          {
            addFrX += 18;
            break;
          }
          break;
        case 441:
        case 468:
          if (tileFrameY == (short) 18)
            tileHeight = 18;
          int num13 = (int) tileFrameX % 36;
          int num14 = (int) tileFrameY % 38;
          int frameData2;
          if (Animation.GetTemporaryFrame(x - num13 / 18, y - num14 / 18, out frameData2))
          {
            tileFrameY = (short) (38 * frameData2 + num14);
            break;
          }
          break;
        case 442:
          tileWidth = 20;
          tileHeight = 20;
          switch ((int) tileFrameX / 22)
          {
            case 1:
              tileTop = -4;
              break;
            case 2:
              tileTop = -2;
              tileWidth = 24;
              break;
            case 3:
              tileTop = -2;
              break;
          }
          break;
        case 452:
          int num15 = Main.tileFrame[(int) typeCache];
          if (tileFrameX >= (short) 54)
            num15 = 0;
          addFrY = num15 * 54;
          break;
        case 453:
          int num16 = (Main.tileFrameCounter[(int) typeCache] / 20 + (y - (int) tileFrameY / 18 + x)) % 3;
          addFrY = num16 * 54;
          break;
        case 454:
          addFrY = Main.tileFrame[(int) typeCache] * 54;
          break;
        case 455:
          addFrY = 0;
          tileTop = 2;
          int num17 = 1 + Main.tileFrame[(int) typeCache];
          if (!BirthdayParty.PartyIsUp)
            num17 = 0;
          addFrY = num17 * 54;
          break;
        case 456:
          int num18 = (Main.tileFrameCounter[(int) typeCache] / 20 + (y - (int) tileFrameY / 18 + (x - (int) tileFrameX / 18))) % 4;
          addFrY = num18 * 54;
          break;
        case 463:
        case 464:
          addFrY = Main.tileFrame[(int) typeCache] * 72;
          tileTop = 2;
          break;
        case 476:
          tileWidth = 20;
          tileHeight = 18;
          break;
        case 480:
        case 509:
          if (tileFrameY >= (short) 54)
          {
            addFrY = Main.tileFrame[(int) typeCache];
            addFrY *= 54;
            break;
          }
          addFrY = 0;
          break;
        case 485:
          tileTop = 2;
          int num19 = (Main.tileFrameCounter[(int) typeCache] / 5 + (y - (int) tileFrameY / 18 + (x - (int) tileFrameX / 18))) % 4;
          addFrY = num19 * 36;
          break;
        case 489:
          tileTop = 2;
          int y1 = y - (int) tileFrameY / 18;
          int x1 = x - (int) tileFrameX / 18;
          if (this.InAPlaceWithWind(x1, y1, 2, 3))
          {
            int num20 = (Main.tileFrameCounter[(int) typeCache] / 5 + (y1 + x1)) % 16;
            addFrY = num20 * 54;
            break;
          }
          break;
        case 490:
          tileTop = 2;
          int y2 = y - (int) tileFrameY / 18;
          int num21 = this.InAPlaceWithWind(x - (int) tileFrameX / 18, y2, 2, 2) ? 1 : 0;
          int num22 = num21 != 0 ? Main.tileFrame[(int) typeCache] : 0;
          int num23 = 0;
          if (num21 != 0)
          {
            if ((double) Math.Abs(Main.WindForVisuals) > 0.5)
            {
              switch (Main.weatherVaneBobframe)
              {
                case 0:
                  num23 = 0;
                  break;
                case 1:
                  num23 = 1;
                  break;
                case 2:
                  num23 = 2;
                  break;
                case 3:
                  num23 = 1;
                  break;
                case 4:
                  num23 = 0;
                  break;
                case 5:
                  num23 = -1;
                  break;
                case 6:
                  num23 = -2;
                  break;
                case 7:
                  num23 = -1;
                  break;
              }
            }
            else
            {
              switch (Main.weatherVaneBobframe)
              {
                case 0:
                  num23 = 0;
                  break;
                case 1:
                  num23 = 1;
                  break;
                case 2:
                  num23 = 0;
                  break;
                case 3:
                  num23 = -1;
                  break;
                case 4:
                  num23 = 0;
                  break;
                case 5:
                  num23 = 1;
                  break;
                case 6:
                  num23 = 0;
                  break;
                case 7:
                  num23 = -1;
                  break;
              }
            }
          }
          int num24 = num22 + num23;
          if (num24 < 0)
            num24 += 12;
          int num25 = num24 % 12;
          addFrY = num25 * 36;
          break;
        case 491:
          tileTop = 2;
          addFrX = 54;
          break;
        case 493:
          if (tileFrameY == (short) 0)
          {
            int num26 = Main.tileFrameCounter[(int) typeCache];
            float num27 = Math.Abs(Main.WindForVisuals);
            int y3 = y - (int) tileFrameY / 18;
            int x2 = x - (int) tileFrameX / 18;
            if (!this.InAPlaceWithWind(x2, y3, 1, 1))
              num27 = 0.0f;
            if ((double) num27 >= 0.100000001490116)
            {
              if ((double) num27 < 0.5)
              {
                int num28 = (num26 / 20 + (y3 + x2)) % 6;
                int num29 = (double) Main.WindForVisuals >= 0.0 ? num28 + 1 : 6 - num28;
                addFrY = num29 * 36;
              }
              else
              {
                int num30 = (num26 / 10 + (y3 + x2)) % 6;
                int num31 = (double) Main.WindForVisuals >= 0.0 ? num30 + 7 : 12 - num30;
                addFrY = num31 * 36;
              }
            }
          }
          tileTop = 2;
          break;
        case 494:
          tileTop = 2;
          break;
        case 507:
        case 508:
          int num32 = 20;
          int num33 = (Main.tileFrameCounter[(int) typeCache] + x * 11 + y * 27) % (num32 * 8);
          addFrY = 90 * (num33 / num32);
          break;
        case 518:
          int num34 = (int) tileCache.liquid / 16 - 3;
          if (WorldGen.SolidTile(x, y - 1) && num34 > 8)
            num34 = 8;
          if (tileCache.liquid == (byte) 0)
          {
            Tile tileSafely = Framing.GetTileSafely(x, y + 1);
            if (tileSafely.nactive())
            {
              switch (tileSafely.blockType())
              {
                case 1:
                  num34 = Math.Max(8, (int) tileSafely.liquid / 16) - 16;
                  break;
                case 2:
                case 3:
                  num34 -= 4;
                  break;
              }
            }
          }
          tileTop -= num34;
          break;
        case 519:
          tileTop = 2;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 521:
        case 522:
        case 523:
        case 524:
        case 525:
        case 526:
        case 527:
          tileTop = 2;
          Main.critterCage = true;
          int waterAnimalCageFrame3 = this.GetWaterAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          int index3 = (int) typeCache - 521;
          addFrY = Main.dragonflyJarFrame[index3, waterAnimalCageFrame3] * 36;
          break;
        case 529:
          int num35 = y + 1;
          int num36 = x;
          int corruptCount1;
          int crimsonCount1;
          int hallowedCount1;
          WorldGen.GetBiomeInfluence(num36, num36, num35, num35, out corruptCount1, out crimsonCount1, out hallowedCount1);
          int num37 = corruptCount1;
          if (num37 < crimsonCount1)
            num37 = crimsonCount1;
          if (num37 < hallowedCount1)
            num37 = hallowedCount1;
          int num38 = corruptCount1 != 0 || crimsonCount1 != 0 || hallowedCount1 != 0 ? (hallowedCount1 != num37 ? (crimsonCount1 != num37 ? 4 : 3) : 2) : (x < WorldGen.beachDistance || x > Main.maxTilesX - WorldGen.beachDistance ? 1 : 0);
          addFrY += 34 * num38 - (int) tileFrameY;
          tileHeight = 32;
          tileTop = -14;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 530:
          int num39 = y - (int) tileFrameY % 36 / 18 + 2;
          int startX = x - (int) tileFrameX % 54 / 18;
          int corruptCount2;
          int crimsonCount2;
          int hallowedCount2;
          WorldGen.GetBiomeInfluence(startX, startX + 3, num39, num39, out corruptCount2, out crimsonCount2, out hallowedCount2);
          int num40 = corruptCount2;
          if (num40 < crimsonCount2)
            num40 = crimsonCount2;
          if (num40 < hallowedCount2)
            num40 = hallowedCount2;
          int num41 = corruptCount2 != 0 || crimsonCount2 != 0 || hallowedCount2 != 0 ? (hallowedCount2 != num40 ? (crimsonCount2 != num40 ? 3 : 2) : 1) : 0;
          addFrY += 36 * num41;
          tileTop = 2;
          break;
        case 541:
          addFrY = this._shouldShowInvisibleBlocks ? 0 : 90;
          break;
        case 561:
          tileTop -= 2;
          tileHeight = 20;
          addFrY = (int) tileFrameY / 18 * 4;
          break;
        case 565:
          tileTop = 2;
          addFrY = tileFrameX >= (short) 36 ? 0 : Main.tileFrame[(int) typeCache] * 36;
          break;
        case 567:
          tileWidth = 26;
          tileHeight = 18;
          tileTop = 2;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 568:
        case 569:
        case 570:
          tileTop = 2;
          Main.critterCage = true;
          int waterAnimalCageFrame4 = this.GetWaterAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          addFrY = Main.fairyJarFrame[waterAnimalCageFrame4] * 36;
          break;
        case 571:
          if (x % 2 == 0)
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
          tileTop = 2;
          break;
        case 572:
          int num42 = Main.tileFrame[(int) typeCache] + x % 6;
          while (num42 > 3)
            num42 -= 3;
          addFrX = num42 * 18;
          addFrY = 0;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 579:
          tileWidth = 20;
          tileHeight = 20;
          tileTop -= 2;
          bool flag = (double) (x * 16 + 8) > (double) Main.LocalPlayer.Center.X;
          addFrY = tileFrameX <= (short) 0 ? (!flag ? 22 : 0) : (!flag ? 0 : 22);
          break;
        case 583:
        case 584:
        case 585:
        case 586:
        case 587:
        case 588:
        case 589:
        case 596:
        case 616:
          tileWidth = 20;
          tileHeight = 20;
          break;
        case 592:
          addFrY = Main.tileFrame[(int) typeCache] * 54;
          break;
        case 593:
          if (tileFrameX >= (short) 18)
            addFrX = -18;
          tileTop = 2;
          int frameData3;
          addFrY = !Animation.GetTemporaryFrame(x, y, out frameData3) ? (tileFrameX >= (short) 18 ? 0 : Main.tileFrame[(int) typeCache] * 18) : (int) (short) (18 * frameData3);
          break;
        case 594:
          if (tileFrameX >= (short) 36)
            addFrX = -36;
          tileTop = 2;
          int num43 = (int) tileFrameX % 36;
          int num44 = (int) tileFrameY % 36;
          int frameData4;
          addFrY = !Animation.GetTemporaryFrame(x - num43 / 18, y - num44 / 18, out frameData4) ? (tileFrameX >= (short) 36 ? 0 : Main.tileFrame[(int) typeCache] * 36) : (int) (short) (36 * frameData4);
          break;
        case 598:
          tileTop = 2;
          Main.critterCage = true;
          int waterAnimalCageFrame5 = this.GetWaterAnimalCageFrame(x, y, (int) tileFrameX, (int) tileFrameY);
          addFrY = Main.lavaFishBowlFrame[waterAnimalCageFrame5] * 36;
          break;
        case 614:
          addFrX = Main.tileFrame[(int) typeCache] * 54;
          addFrY = 0;
          tileTop = 2;
          break;
        case 615:
          tileHeight = 18;
          if (x % 2 == 0)
          {
            tileSpriteEffect = SpriteEffects.FlipHorizontally;
            break;
          }
          break;
        case 617:
          tileTop = 2;
          tileFrameY %= (short) 144;
          tileFrameX %= (short) 54;
          break;
      }
      if (tileCache.halfBrick())
        halfBrickHeight = 8;
      switch (typeCache)
      {
        case 10:
          if ((int) tileFrameY / 54 != 32)
            break;
          glowTexture = TextureAssets.GlowMask[57].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 54, tileWidth, tileHeight);
          glowColor = this._martianGlow;
          break;
        case 11:
          int num45 = (int) tileFrameY / 54;
          if (num45 == 32)
          {
            glowTexture = TextureAssets.GlowMask[58].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 54, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num45 != 33)
            break;
          glowTexture = TextureAssets.GlowMask[119].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 54, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 14:
          int num46 = (int) tileFrameX / 54;
          if (num46 == 31)
          {
            glowTexture = TextureAssets.GlowMask[67].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num46 != 32)
            break;
          glowTexture = TextureAssets.GlowMask[124].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 15:
          int num47 = (int) tileFrameY / 40;
          if (num47 == 32)
          {
            glowTexture = TextureAssets.GlowMask[54].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 40, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num47 != 33)
            break;
          glowTexture = TextureAssets.GlowMask[116].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 40, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 18:
          int num48 = (int) tileFrameX / 36;
          if (num48 == 27)
          {
            glowTexture = TextureAssets.GlowMask[69].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num48 != 28)
            break;
          glowTexture = TextureAssets.GlowMask[125].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 19:
          int num49 = (int) tileFrameY / 18;
          if (num49 == 26)
          {
            glowTexture = TextureAssets.GlowMask[65].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 18, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num49 != 27)
            break;
          glowTexture = TextureAssets.GlowMask[112].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 18, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 21:
        case 467:
          int num50 = (int) tileFrameX / 36;
          if (num50 == 48)
          {
            glowTexture = TextureAssets.GlowMask[56].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num50 != 49)
            break;
          glowTexture = TextureAssets.GlowMask[117].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 33:
          if ((int) tileFrameX / 18 != 0 || (int) tileFrameY / 22 != 26)
            break;
          glowTexture = TextureAssets.GlowMask[61].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 22, tileWidth, tileHeight);
          glowColor = this._martianGlow;
          break;
        case 34:
          if ((int) tileFrameX / 54 != 0 || (int) tileFrameY / 54 != 33)
            break;
          glowTexture = TextureAssets.GlowMask[55].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 54, tileWidth, tileHeight);
          glowColor = this._martianGlow;
          break;
        case 42:
          if ((int) tileFrameY / 36 != 33)
            break;
          glowTexture = TextureAssets.GlowMask[63].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 36, tileWidth, tileHeight);
          glowColor = this._martianGlow;
          break;
        case 79:
          int num51 = (int) tileFrameY / 36;
          if (num51 == 27)
          {
            glowTexture = TextureAssets.GlowMask[53].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 36, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num51 != 28)
            break;
          glowTexture = TextureAssets.GlowMask[114].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 36, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 87:
          int num52 = (int) tileFrameX / 54;
          int num53 = (int) tileFrameX / 1998;
          addFrX -= 1998 * num53;
          addFrY += 36 * num53;
          if (num52 == 26)
          {
            glowTexture = TextureAssets.GlowMask[64].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num52 != 27)
            break;
          glowTexture = TextureAssets.GlowMask[121].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 88:
          int num54 = (int) tileFrameX / 54;
          int num55 = (int) tileFrameX / 1998;
          addFrX -= 1998 * num55;
          addFrY += 36 * num55;
          if (num54 == 24)
          {
            glowTexture = TextureAssets.GlowMask[59].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num54 != 25)
            break;
          glowTexture = TextureAssets.GlowMask[120].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 89:
          int num56 = (int) tileFrameX / 54;
          int num57 = (int) tileFrameX / 1998;
          addFrX -= 1998 * num57;
          addFrY += 36 * num57;
          if (num56 == 29)
          {
            glowTexture = TextureAssets.GlowMask[66].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num56 != 30)
            break;
          glowTexture = TextureAssets.GlowMask[123].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 90:
          int num58 = (int) tileFrameY / 36;
          if (num58 == 27)
          {
            glowTexture = TextureAssets.GlowMask[52].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 36, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num58 != 28)
            break;
          glowTexture = TextureAssets.GlowMask[113].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 36, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 93:
          int num59 = (int) tileFrameY / 54;
          int num60 = (int) tileFrameY / 1998;
          addFrY -= 1998 * num60;
          addFrX += 36 * num60;
          tileTop += 2;
          if (num59 != 27)
            break;
          glowTexture = TextureAssets.GlowMask[62].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 54, tileWidth, tileHeight);
          glowColor = this._martianGlow;
          break;
        case 100:
          if ((int) tileFrameX / 36 != 0 || (int) tileFrameY / 36 != 27)
            break;
          glowTexture = TextureAssets.GlowMask[68].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 36, tileWidth, tileHeight);
          glowColor = this._martianGlow;
          break;
        case 101:
          int num61 = (int) tileFrameX / 54;
          int num62 = (int) tileFrameX / 1998;
          addFrX -= 1998 * num62;
          addFrY += 72 * num62;
          if (num61 == 28)
          {
            glowTexture = TextureAssets.GlowMask[60].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num61 != 29)
            break;
          glowTexture = TextureAssets.GlowMask[115].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 54, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 104:
          int num63 = (int) tileFrameX / 36;
          tileTop = 2;
          if (num63 == 24)
          {
            glowTexture = TextureAssets.GlowMask[51].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num63 != 25)
            break;
          glowTexture = TextureAssets.GlowMask[118].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 172:
          int num64 = (int) tileFrameY / 38;
          if (num64 == 28)
          {
            glowTexture = TextureAssets.GlowMask[88].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 38, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num64 != 29)
            break;
          glowTexture = TextureAssets.GlowMask[122].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY % 38, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 184:
          if (tileCache.frameX == (short) 110)
          {
            glowTexture = TextureAssets.GlowMask[(int) sbyte.MaxValue].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._lavaMossGlow;
          }
          if (tileCache.frameX == (short) 132)
          {
            glowTexture = TextureAssets.GlowMask[(int) sbyte.MaxValue].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._kryptonMossGlow;
          }
          if (tileCache.frameX == (short) 154)
          {
            glowTexture = TextureAssets.GlowMask[(int) sbyte.MaxValue].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._xenonMossGlow;
          }
          if (tileCache.frameX != (short) 176)
            break;
          glowTexture = TextureAssets.GlowMask[(int) sbyte.MaxValue].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._argonMossGlow;
          break;
        case 441:
        case 468:
          int num65 = (int) tileFrameX / 36;
          if (num65 == 48)
          {
            glowTexture = TextureAssets.GlowMask[56].Value;
            glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
            glowColor = this._martianGlow;
          }
          if (num65 != 49)
            break;
          glowTexture = TextureAssets.GlowMask[117].Value;
          glowSourceRect = new Rectangle((int) tileFrameX % 36, (int) tileFrameY, tileWidth, tileHeight);
          glowColor = this._meteorGlow;
          break;
        case 463:
          glowTexture = TextureAssets.GlowMask[243].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY + addFrY, tileWidth, tileHeight);
          glowColor = new Color((int) sbyte.MaxValue, (int) sbyte.MaxValue, (int) sbyte.MaxValue, 0);
          break;
        case 564:
          if (tileCache.frameX < (short) 36)
          {
            glowTexture = TextureAssets.GlowMask[267].Value;
            glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY + addFrY, tileWidth, tileHeight);
            glowColor = new Color(200, 200, 200, 0) * ((float) Main.mouseTextColor / (float) byte.MaxValue);
          }
          addFrY = 0;
          break;
        case 568:
          glowTexture = TextureAssets.GlowMask[268].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY + addFrY, tileWidth, tileHeight);
          glowColor = Color.White;
          break;
        case 569:
          glowTexture = TextureAssets.GlowMask[269].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY + addFrY, tileWidth, tileHeight);
          glowColor = Color.White;
          break;
        case 570:
          glowTexture = TextureAssets.GlowMask[270].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY + addFrY, tileWidth, tileHeight);
          glowColor = Color.White;
          break;
        case 580:
          glowTexture = TextureAssets.GlowMask[289].Value;
          glowSourceRect = new Rectangle((int) tileFrameX, (int) tileFrameY + addFrY, tileWidth, tileHeight);
          glowColor = new Color(225, 110, 110, 0);
          break;
      }
    }

    private bool IsWindBlocked(int x, int y)
    {
      Tile tile = Main.tile[x, y];
      return tile == null || tile.wall > (ushort) 0 && !WallID.Sets.AllowsWind[(int) tile.wall] || (double) y > Main.worldSurface;
    }

    private int GetWaterAnimalCageFrame(int x, int y, int tileFrameX, int tileFrameY) => (x - tileFrameX / 18) / 2 * ((y - tileFrameY / 18) / 3) % Main.cageFrames;

    private int GetSmallAnimalCageFrame(int x, int y, int tileFrameX, int tileFrameY) => (x - tileFrameX / 18) / 3 * ((y - tileFrameY / 18) / 3) % Main.cageFrames;

    private int GetBigAnimalCageFrame(int x, int y, int tileFrameX, int tileFrameY) => (x - tileFrameX / 18) / 6 * ((y - tileFrameY / 18) / 4) % Main.cageFrames;

    private void GetScreenDrawArea(
      Vector2 screenPosition,
      Vector2 offSet,
      out int firstTileX,
      out int lastTileX,
      out int firstTileY,
      out int lastTileY)
    {
      firstTileX = (int) (((double) screenPosition.X - (double) offSet.X) / 16.0 - 1.0);
      lastTileX = (int) (((double) screenPosition.X + (double) Main.screenWidth + (double) offSet.X) / 16.0) + 2;
      firstTileY = (int) (((double) screenPosition.Y - (double) offSet.Y) / 16.0 - 1.0);
      lastTileY = (int) (((double) screenPosition.Y + (double) Main.screenHeight + (double) offSet.Y) / 16.0) + 5;
      if (firstTileX < 4)
        firstTileX = 4;
      if (lastTileX > Main.maxTilesX - 4)
        lastTileX = Main.maxTilesX - 4;
      if (firstTileY < 4)
        firstTileY = 4;
      if (lastTileY > Main.maxTilesY - 4)
        lastTileY = Main.maxTilesY - 4;
      if (Main.sectionManager.FrameSectionsLeft <= 0)
        return;
      TimeLogger.DetailedDrawReset();
      WorldGen.SectionTileFrameWithCheck(firstTileX, firstTileY, lastTileX, lastTileY);
      TimeLogger.DetailedDrawTime(5);
    }

    public void ClearCachedTileDraws(bool solidLayer)
    {
      if (!solidLayer)
        return;
      this._displayDollTileEntityPositions.Clear();
      this._hatRackTileEntityPositions.Clear();
      this._vineRootsPositions.Clear();
      this._reverseVineRootsPositions.Clear();
    }

    private void AddSpecialLegacyPoint(Point p) => this.AddSpecialLegacyPoint(p.X, p.Y);

    private void AddSpecialLegacyPoint(int x, int y)
    {
      this._specialTileX[this._specialTilesCount] = x;
      this._specialTileY[this._specialTilesCount] = y;
      ++this._specialTilesCount;
    }

    private void ClearLegacyCachedDraws()
    {
      this._chestPositions.Clear();
      this._trainingDummyTileEntityPositions.Clear();
      this._foodPlatterTileEntityPositions.Clear();
      this._itemFrameTileEntityPositions.Clear();
      this._weaponRackTileEntityPositions.Clear();
      this._specialTilesCount = 0;
    }

    private Color DrawTiles_GetLightOverride(
      int j,
      int i,
      Tile tileCache,
      ushort typeCache,
      short tileFrameX,
      short tileFrameY,
      Color tileLight)
    {
      if (tileCache.color() == (byte) 31)
        return Color.White;
      switch (typeCache)
      {
        case 61:
          if (tileFrameX == (short) 144)
          {
            tileLight.A = tileLight.R = tileLight.G = tileLight.B = (byte) (245.0 - (double) Main.mouseTextColor * 1.5);
            break;
          }
          break;
        case 83:
          int style = (int) tileFrameX / 18;
          if (this.IsAlchemyPlantHarvestable(style))
          {
            if (style == 5)
            {
              tileLight.A = (byte) ((uint) Main.mouseTextColor / 2U);
              tileLight.G = Main.mouseTextColor;
              tileLight.B = Main.mouseTextColor;
            }
            if (style == 6)
            {
              byte num1 = (byte) (((int) Main.mouseTextColor + (int) tileLight.G * 2) / 3);
              byte num2 = (byte) (((int) Main.mouseTextColor + (int) tileLight.B * 2) / 3);
              if ((int) num1 > (int) tileLight.G)
                tileLight.G = num1;
              if ((int) num2 > (int) tileLight.B)
              {
                tileLight.B = num2;
                break;
              }
              break;
            }
            break;
          }
          break;
        case 541:
          return Color.White;
      }
      return tileLight;
    }

    private void DrawTiles_EmitParticles(
      int j,
      int i,
      Tile tileCache,
      ushort typeCache,
      short tileFrameX,
      short tileFrameY,
      Color tileLight)
    {
      switch (typeCache)
      {
        case 238:
          if (this._rand.Next(10) == 0)
          {
            int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 168);
            this._dust[index].noGravity = true;
            this._dust[index].alpha = 200;
            break;
          }
          break;
        case 463:
          if (tileFrameY == (short) 54 && tileFrameX == (short) 0)
          {
            for (int index = 0; index < 4; ++index)
            {
              if (this._rand.Next(2) != 0)
              {
                Dust dust = Dust.NewDustDirect(new Vector2((float) (i * 16 + 4), (float) (j * 16)), 36, 8, 16);
                dust.noGravity = true;
                dust.alpha = 140;
                dust.fadeIn = 1.2f;
                dust.velocity = Vector2.Zero;
              }
            }
          }
          if (tileFrameY == (short) 18 && (tileFrameX == (short) 0 || tileFrameX == (short) 36))
          {
            for (int index = 0; index < 1; ++index)
            {
              if (this._rand.Next(13) == 0)
              {
                Dust dust = Dust.NewDustDirect(new Vector2((float) (i * 16), (float) (j * 16)), 8, 8, 274);
                dust.position = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 8));
                dust.position.X += tileFrameX == (short) 36 ? 4f : -4f;
                dust.noGravity = true;
                dust.alpha = 128;
                dust.fadeIn = 1.2f;
                dust.noLight = true;
                dust.velocity = new Vector2(0.0f, this._rand.NextFloatDirection() * 1.2f);
              }
            }
            break;
          }
          break;
        default:
          if (typeCache == (ushort) 497 && (int) tileCache.frameY / 40 == 31 && (int) tileCache.frameY % 40 == 0)
          {
            for (int index = 0; index < 1; ++index)
            {
              if (this._rand.Next(10) == 0)
              {
                Dust dust = Dust.NewDustDirect(new Vector2((float) (i * 16), (float) (j * 16 + 8)), 16, 12, 43);
                dust.noGravity = true;
                dust.alpha = 254;
                dust.color = Color.White;
                dust.scale = 0.7f;
                dust.velocity = Vector2.Zero;
                dust.noLight = true;
              }
            }
            break;
          }
          break;
      }
      if (typeCache == (ushort) 139 && tileCache.frameX == (short) 36 && (int) tileCache.frameY % 36 == 0 && (int) Main.timeForVisualEffects % 7 == 0 && this._rand.Next(3) == 0)
      {
        int Type = this._rand.Next(570, 573);
        Vector2 Position = new Vector2((float) (i * 16 + 8), (float) (j * 16 - 8));
        Vector2 Velocity = new Vector2(Main.WindForVisuals * 2f, -0.5f);
        Velocity.X *= (float) (1.0 + (double) this._rand.Next(-50, 51) * 0.00999999977648258);
        Velocity.Y *= (float) (1.0 + (double) this._rand.Next(-50, 51) * 0.00999999977648258);
        if (Type == 572)
          Position.X -= 8f;
        if (Type == 571)
          Position.X -= 4f;
        Gore.NewGore(Position, Velocity, Type, 0.8f);
      }
      if (typeCache == (ushort) 244 && tileFrameX == (short) 18 && tileFrameY == (short) 18 && this._rand.Next(2) == 0)
      {
        if (this._rand.Next(500) == 0)
          Gore.NewGore(new Vector2((float) (i * 16 + 8), (float) (j * 16 + 8)), new Vector2(), 415, (float) this._rand.Next(51, 101) * 0.01f);
        else if (this._rand.Next(250) == 0)
          Gore.NewGore(new Vector2((float) (i * 16 + 8), (float) (j * 16 + 8)), new Vector2(), 414, (float) this._rand.Next(51, 101) * 0.01f);
        else if (this._rand.Next(80) == 0)
          Gore.NewGore(new Vector2((float) (i * 16 + 8), (float) (j * 16 + 8)), new Vector2(), 413, (float) this._rand.Next(51, 101) * 0.01f);
        else if (this._rand.Next(10) == 0)
          Gore.NewGore(new Vector2((float) (i * 16 + 8), (float) (j * 16 + 8)), new Vector2(), 412, (float) this._rand.Next(51, 101) * 0.01f);
        else if (this._rand.Next(3) == 0)
          Gore.NewGore(new Vector2((float) (i * 16 + 8), (float) (j * 16 + 8)), new Vector2(), 411, (float) this._rand.Next(51, 101) * 0.01f);
      }
      if (typeCache == (ushort) 565 && tileFrameX == (short) 0 && tileFrameY == (short) 18 && this._rand.Next(3) == 0 && (Main.drawToScreen && this._rand.Next(4) == 0 || !Main.drawToScreen))
      {
        Vector2 worldCoordinates = new Point(i, j).ToWorldCoordinates();
        int Type = 1202;
        float Scale = (float) (8.0 + (double) Main.rand.NextFloat() * 1.60000002384186);
        Vector2 vector2 = new Vector2(0.0f, -18f);
        Gore.NewGorePerfect(worldCoordinates + vector2, (Main.rand.NextVector2Circular(0.7f, 0.25f) * 0.4f + Main.rand.NextVector2CircularEdge(1f, 0.4f) * 0.1f) * 4f, Type, Scale);
      }
      if (typeCache == (ushort) 165 && tileFrameX >= (short) 162 && tileFrameX <= (short) 214 && tileFrameY == (short) 72 && this._rand.Next(60) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16 + 2), (float) (j * 16 + 6)), 8, 4, 153);
        this._dust[index].scale -= (float) this._rand.Next(3) * 0.1f;
        this._dust[index].velocity.Y = 0.0f;
        this._dust[index].velocity.X *= 0.05f;
        this._dust[index].alpha = 100;
      }
      if (typeCache == (ushort) 42 && tileFrameX == (short) 0)
      {
        int num1 = (int) tileFrameY / 36;
        int num2 = (int) tileFrameY / 18 % 2;
        if (num1 == 7 && num2 == 1)
        {
          if (this._rand.Next(50) == 0)
            this._dust[Dust.NewDust(new Vector2((float) (i * 16 + 4), (float) (j * 16 + 4)), 8, 8, 58, Alpha: 150)].velocity *= 0.5f;
          if (this._rand.Next(100) == 0)
          {
            int index = Gore.NewGore(new Vector2((float) (i * 16 - 2), (float) (j * 16 - 4)), new Vector2(), this._rand.Next(16, 18));
            this._gore[index].scale *= 0.7f;
            this._gore[index].velocity *= 0.25f;
          }
        }
        else if (num1 == 29 && num2 == 1 && this._rand.Next(40) == 0)
        {
          int index = Dust.NewDust(new Vector2((float) (i * 16 + 4), (float) (j * 16)), 8, 8, 59, Alpha: 100);
          if (this._rand.Next(3) != 0)
            this._dust[index].noGravity = true;
          this._dust[index].velocity *= 0.3f;
          this._dust[index].velocity.Y -= 1.5f;
        }
      }
      if (typeCache == (ushort) 215 && tileFrameY < (short) 36 && this._rand.Next(3) == 0 && (Main.drawToScreen && this._rand.Next(4) == 0 || !Main.drawToScreen) && tileFrameY == (short) 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16 + 2), (float) (j * 16 - 4)), 4, 8, 31, Alpha: 100);
        if (tileFrameX == (short) 0)
          this._dust[index].position.X += (float) this._rand.Next(8);
        if (tileFrameX == (short) 36)
          this._dust[index].position.X -= (float) this._rand.Next(8);
        this._dust[index].alpha += this._rand.Next(100);
        this._dust[index].velocity *= 0.2f;
        this._dust[index].velocity.Y -= (float) (0.5 + (double) this._rand.Next(10) * 0.100000001490116);
        this._dust[index].fadeIn = (float) (0.5 + (double) this._rand.Next(10) * 0.100000001490116);
      }
      if (typeCache == (ushort) 592 && tileFrameY == (short) 18 && this._rand.Next(3) == 0 && (Main.drawToScreen && this._rand.Next(6) == 0 || !Main.drawToScreen))
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16 + 2), (float) (j * 16 + 4)), 4, 8, 31, Alpha: 100);
        if (tileFrameX == (short) 0)
          this._dust[index].position.X += (float) this._rand.Next(8);
        if (tileFrameX == (short) 36)
          this._dust[index].position.X -= (float) this._rand.Next(8);
        this._dust[index].alpha += this._rand.Next(100);
        this._dust[index].velocity *= 0.2f;
        this._dust[index].velocity.Y -= (float) (0.5 + (double) this._rand.Next(10) * 0.100000001490116);
        this._dust[index].fadeIn = (float) (0.5 + (double) this._rand.Next(10) * 0.100000001490116);
      }
      if (typeCache == (ushort) 4 && this._rand.Next(40) == 0 && tileFrameX < (short) 66)
      {
        int num = (int) tileFrameY / 22;
        int Type;
        switch (num)
        {
          case 0:
            Type = 6;
            break;
          case 8:
            Type = 75;
            break;
          case 9:
            Type = 135;
            break;
          case 10:
            Type = 158;
            break;
          case 11:
            Type = 169;
            break;
          case 12:
            Type = 156;
            break;
          case 13:
            Type = 234;
            break;
          case 14:
            Type = 66;
            break;
          case 15:
            Type = 242;
            break;
          case 16:
            Type = 293;
            break;
          case 17:
            Type = 294;
            break;
          default:
            Type = 58 + num;
            break;
        }
        int index;
        switch (tileFrameX)
        {
          case 22:
            index = Dust.NewDust(new Vector2((float) (i * 16 + 6), (float) (j * 16)), 4, 4, Type, Alpha: 100);
            break;
          case 44:
            index = Dust.NewDust(new Vector2((float) (i * 16 + 2), (float) (j * 16)), 4, 4, Type, Alpha: 100);
            break;
          default:
            index = Dust.NewDust(new Vector2((float) (i * 16 + 4), (float) (j * 16)), 4, 4, Type, Alpha: 100);
            break;
        }
        if (this._rand.Next(3) != 0)
          this._dust[index].noGravity = true;
        this._dust[index].velocity *= 0.3f;
        this._dust[index].velocity.Y -= 1.5f;
        if (Type == 66)
        {
          this._dust[index].color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
          this._dust[index].noGravity = true;
        }
      }
      if (typeCache == (ushort) 93 && this._rand.Next(40) == 0 && tileFrameX == (short) 0)
      {
        int num = (int) tileFrameY / 54;
        if ((int) tileFrameY / 18 % 3 == 0)
        {
          int Type;
          switch (num)
          {
            case 0:
            case 6:
            case 7:
            case 8:
            case 10:
            case 14:
            case 15:
            case 16:
              Type = 6;
              break;
            case 20:
              Type = 59;
              break;
            default:
              Type = -1;
              break;
          }
          if (Type != -1)
          {
            int index = Dust.NewDust(new Vector2((float) (i * 16 + 4), (float) (j * 16 + 2)), 4, 4, Type, Alpha: 100);
            if (this._rand.Next(3) != 0)
              this._dust[index].noGravity = true;
            this._dust[index].velocity *= 0.3f;
            this._dust[index].velocity.Y -= 1.5f;
          }
        }
      }
      if (typeCache == (ushort) 100 && this._rand.Next(40) == 0 && tileFrameX < (short) 36)
      {
        int num = (int) tileFrameY / 36;
        if ((int) tileFrameY / 18 % 2 == 0)
        {
          int Type;
          switch (num)
          {
            case 0:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
            case 14:
            case 15:
            case 16:
              Type = 6;
              break;
            case 20:
              Type = 59;
              break;
            default:
              Type = -1;
              break;
          }
          if (Type != -1)
          {
            int index = Dust.NewDust(tileFrameX != (short) 0 ? (this._rand.Next(3) != 0 ? new Vector2((float) (i * 16), (float) (j * 16 + 2)) : new Vector2((float) (i * 16 + 6), (float) (j * 16 + 2))) : (this._rand.Next(3) != 0 ? new Vector2((float) (i * 16 + 14), (float) (j * 16 + 2)) : new Vector2((float) (i * 16 + 4), (float) (j * 16 + 2))), 4, 4, Type, Alpha: 100);
            if (this._rand.Next(3) != 0)
              this._dust[index].noGravity = true;
            this._dust[index].velocity *= 0.3f;
            this._dust[index].velocity.Y -= 1.5f;
          }
        }
      }
      if (typeCache == (ushort) 98 && this._rand.Next(40) == 0 && tileFrameY == (short) 0 && tileFrameX == (short) 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16 + 12), (float) (j * 16 + 2)), 4, 4, 6, Alpha: 100);
        if (this._rand.Next(3) != 0)
          this._dust[index].noGravity = true;
        this._dust[index].velocity *= 0.3f;
        this._dust[index].velocity.Y -= 1.5f;
      }
      if (typeCache == (ushort) 49 && tileFrameX == (short) 0 && this._rand.Next(2) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16 + 4), (float) (j * 16 - 4)), 4, 4, 172, Alpha: 100);
        if (this._rand.Next(3) == 0)
        {
          this._dust[index].scale = 0.5f;
        }
        else
        {
          this._dust[index].scale = 0.9f;
          this._dust[index].noGravity = true;
        }
        this._dust[index].velocity *= 0.3f;
        this._dust[index].velocity.Y -= 1.5f;
      }
      if (typeCache == (ushort) 372 && tileFrameX == (short) 0 && this._rand.Next(2) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16 + 4), (float) (j * 16 - 4)), 4, 4, 242, Alpha: 100);
        if (this._rand.Next(3) == 0)
        {
          this._dust[index].scale = 0.5f;
        }
        else
        {
          this._dust[index].scale = 0.9f;
          this._dust[index].noGravity = true;
        }
        this._dust[index].velocity *= 0.3f;
        this._dust[index].velocity.Y -= 1.5f;
      }
      if (typeCache == (ushort) 34 && this._rand.Next(40) == 0 && tileFrameX < (short) 54)
      {
        int num3 = (int) tileFrameY / 54;
        int num4 = (int) tileFrameX / 18 % 3;
        if ((int) tileFrameY / 18 % 3 == 1 && num4 != 1)
        {
          int Type;
          switch (num3)
          {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 12:
            case 13:
            case 16:
            case 19:
            case 21:
              Type = 6;
              break;
            case 25:
              Type = 59;
              break;
            default:
              Type = -1;
              break;
          }
          if (Type != -1)
          {
            int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16 + 2)), 14, 6, Type, Alpha: 100);
            if (this._rand.Next(3) != 0)
              this._dust[index].noGravity = true;
            this._dust[index].velocity *= 0.3f;
            this._dust[index].velocity.Y -= 1.5f;
          }
        }
      }
      int maxValue = this._leafFrequency / 4;
      if (typeCache == (ushort) 192 && this._rand.Next(maxValue) == 0)
        this.EmitLivingTreeLeaf(i, j, 910);
      if (typeCache == (ushort) 384 && this._rand.Next(maxValue) == 0)
        this.EmitLivingTreeLeaf(i, j, 914);
      if (typeCache == (ushort) 83)
      {
        int style = (int) tileFrameX / 18;
        if (this.IsAlchemyPlantHarvestable(style))
          this.EmitAlchemyHerbParticles(j, i, style);
      }
      if (typeCache == (ushort) 22 && this._rand.Next(400) == 0)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14);
      else if ((typeCache == (ushort) 23 || typeCache == (ushort) 24 || typeCache == (ushort) 32) && this._rand.Next(500) == 0)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14);
      else if (typeCache == (ushort) 25 && this._rand.Next(700) == 0)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14);
      else if (typeCache == (ushort) 112 && this._rand.Next(700) == 0)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14);
      else if (typeCache == (ushort) 31 && this._rand.Next(20) == 0)
      {
        if (tileFrameX >= (short) 36)
        {
          int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 5, Alpha: 100);
          this._dust[index].velocity.Y = 0.0f;
          this._dust[index].velocity.X *= 0.3f;
        }
        else
          Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14, Alpha: 100);
      }
      else if (typeCache == (ushort) 26 && this._rand.Next(20) == 0)
      {
        if (tileFrameX >= (short) 54)
        {
          int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 5, Alpha: 100);
          this._dust[index].scale = 1.5f;
          this._dust[index].noGravity = true;
          this._dust[index].velocity *= 0.75f;
        }
        else
          Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14, Alpha: 100);
      }
      else if ((typeCache == (ushort) 71 || typeCache == (ushort) 72) && this._rand.Next(500) == 0)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 41, Alpha: 250, Scale: 0.8f);
      else if ((typeCache == (ushort) 17 || typeCache == (ushort) 77 || typeCache == (ushort) 133) && this._rand.Next(40) == 0)
      {
        if (!(tileFrameX == (short) 18 & tileFrameY == (short) 18))
          return;
        int index = Dust.NewDust(new Vector2((float) (i * 16 - 4), (float) (j * 16 - 6)), 8, 6, 6, Alpha: 100);
        if (this._rand.Next(3) == 0)
          return;
        this._dust[index].noGravity = true;
      }
      else if (typeCache == (ushort) 405 && this._rand.Next(20) == 0)
      {
        if (!(tileFrameX == (short) 18 & tileFrameY == (short) 18))
          return;
        int index = Dust.NewDust(new Vector2((float) (i * 16 - 4), (float) (j * 16 - 6)), 24, 10, 6, Alpha: 100);
        if (this._rand.Next(5) == 0)
          return;
        this._dust[index].noGravity = true;
      }
      else if (typeCache == (ushort) 452 && tileFrameY == (short) 0 && tileFrameX == (short) 0 && this._rand.Next(3) == 0)
      {
        Vector2 Position = new Vector2((float) (i * 16 + 16), (float) (j * 16 + 8));
        Vector2 Velocity = new Vector2(0.0f, 0.0f);
        if ((double) Main.WindForVisuals < 0.0)
          Velocity.X = -Main.WindForVisuals;
        int Type = 907 + Main.tileFrame[(int) typeCache] / 5;
        if (this._rand.Next(2) != 0)
          return;
        Gore.NewGore(Position, Velocity, Type, (float) ((double) this._rand.NextFloat() * 0.400000005960464 + 0.400000005960464));
      }
      else if (typeCache == (ushort) 406 && tileFrameY == (short) 54 && tileFrameX == (short) 0 && this._rand.Next(3) == 0)
      {
        Vector2 Position = new Vector2((float) (i * 16 + 16), (float) (j * 16 + 8));
        Vector2 Velocity = new Vector2(0.0f, 0.0f);
        if ((double) Main.WindForVisuals < 0.0)
          Velocity.X = -Main.WindForVisuals;
        int Type = this._rand.Next(825, 828);
        if (this._rand.Next(4) == 0)
          Gore.NewGore(Position, Velocity, Type, (float) ((double) this._rand.NextFloat() * 0.200000002980232 + 0.200000002980232));
        else if (this._rand.Next(2) == 0)
          Gore.NewGore(Position, Velocity, Type, (float) ((double) this._rand.NextFloat() * 0.300000011920929 + 0.300000011920929));
        else
          Gore.NewGore(Position, Velocity, Type, (float) ((double) this._rand.NextFloat() * 0.400000005960464 + 0.400000005960464));
      }
      else if (typeCache == (ushort) 37 && this._rand.Next(250) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 6, Scale: ((float) this._rand.Next(3)));
        if ((double) this._dust[index].scale <= 1.0)
          return;
        this._dust[index].noGravity = true;
      }
      else if ((typeCache == (ushort) 58 || typeCache == (ushort) 76) && this._rand.Next(250) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 6, Scale: ((float) this._rand.Next(3)));
        if ((double) this._dust[index].scale > 1.0)
          this._dust[index].noGravity = true;
        this._dust[index].noLight = true;
      }
      else if (typeCache == (ushort) 61)
      {
        if (tileFrameX != (short) 144 || this._rand.Next(60) != 0)
          return;
        this._dust[Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 44, Alpha: 250, Scale: 0.4f)].fadeIn = 0.7f;
      }
      else
      {
        if (Main.tileShine[(int) typeCache] <= 0 || tileLight.R <= (byte) 20 && tileLight.B <= (byte) 20 && tileLight.G <= (byte) 20)
          return;
        int num5 = (int) tileLight.R;
        if ((int) tileLight.G > num5)
          num5 = (int) tileLight.G;
        if ((int) tileLight.B > num5)
          num5 = (int) tileLight.B;
        int num6 = num5 / 30;
        if (this._rand.Next(Main.tileShine[(int) typeCache]) >= num6 || (typeCache == (ushort) 21 || typeCache == (ushort) 441) && (tileFrameX < (short) 36 || tileFrameX >= (short) 180) && (tileFrameX < (short) 396 || tileFrameX > (short) 409) || (typeCache == (ushort) 467 || typeCache == (ushort) 468) && (tileFrameX < (short) 144 || tileFrameX >= (short) 180))
          return;
        Color newColor = Color.White;
        if (typeCache == (ushort) 178)
        {
          switch ((int) tileFrameX / 18)
          {
            case 0:
              newColor = new Color((int) byte.MaxValue, 0, (int) byte.MaxValue, (int) byte.MaxValue);
              break;
            case 1:
              newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
              break;
            case 2:
              newColor = new Color(0, 0, (int) byte.MaxValue, (int) byte.MaxValue);
              break;
            case 3:
              newColor = new Color(0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
              break;
            case 4:
              newColor = new Color((int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
              break;
            case 5:
              newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              break;
            case 6:
              newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
              break;
          }
          this._dust[Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 43, Alpha: 254, newColor: newColor, Scale: 0.5f)].velocity *= 0.0f;
        }
        else
        {
          if (typeCache == (ushort) 63)
            newColor = new Color(0, 0, (int) byte.MaxValue, (int) byte.MaxValue);
          if (typeCache == (ushort) 64)
            newColor = new Color((int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
          if (typeCache == (ushort) 65)
            newColor = new Color(0, (int) byte.MaxValue, 0, (int) byte.MaxValue);
          if (typeCache == (ushort) 66)
            newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue);
          if (typeCache == (ushort) 67)
            newColor = new Color((int) byte.MaxValue, 0, (int) byte.MaxValue, (int) byte.MaxValue);
          if (typeCache == (ushort) 68)
            newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          if (typeCache == (ushort) 12)
            newColor = new Color((int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
          if (typeCache == (ushort) 204)
            newColor = new Color((int) byte.MaxValue, 0, 0, (int) byte.MaxValue);
          if (typeCache == (ushort) 211)
            newColor = new Color(50, (int) byte.MaxValue, 100, (int) byte.MaxValue);
          this._dust[Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 43, Alpha: 254, newColor: newColor, Scale: 0.5f)].velocity *= 0.0f;
        }
      }
    }

    private void EmitLivingTreeLeaf(int i, int j, int leafGoreType)
    {
      this.EmitLivingTreeLeaf_Below(i, j, leafGoreType);
      if (this._rand.Next(2) != 0)
        return;
      this.EmitLivingTreeLeaf_Sideways(i, j, leafGoreType);
    }

    private void EmitLivingTreeLeaf_Below(int x, int y, int leafGoreType)
    {
      Tile testTile = Main.tile[x, y + 1];
      if (WorldGen.SolidTile(testTile) || testTile.liquid > (byte) 0)
        return;
      float windForVisuals = Main.WindForVisuals;
      if ((double) windForVisuals < -0.200000002980232 && (WorldGen.SolidTile(Main.tile[x - 1, y + 1]) || WorldGen.SolidTile(Main.tile[x - 2, y + 1])) || (double) windForVisuals > 0.200000002980232 && (WorldGen.SolidTile(Main.tile[x + 1, y + 1]) || WorldGen.SolidTile(Main.tile[x + 2, y + 1])))
        return;
      Gore.NewGorePerfect(new Vector2((float) (x * 16), (float) (y * 16 + 16)), Vector2.Zero, leafGoreType).Frame.CurrentColumn = Main.tile[x, y].color();
    }

    private void EmitLivingTreeLeaf_Sideways(int x, int y, int leafGoreType)
    {
      int num1 = 0;
      if ((double) Main.WindForVisuals > 0.200000002980232)
        num1 = 1;
      else if ((double) Main.WindForVisuals < -0.200000002980232)
        num1 = -1;
      Tile testTile = Main.tile[x + num1, y];
      if (WorldGen.SolidTile(testTile) || testTile.liquid > (byte) 0)
        return;
      int num2 = 0;
      if (num1 == -1)
        num2 = -10;
      Gore.NewGorePerfect(new Vector2((float) (x * 16 + 8 + 4 * num1 + num2), (float) (y * 16 + 8)), Vector2.Zero, leafGoreType).Frame.CurrentColumn = Main.tile[x, y].color();
    }

    private void EmitLiquidDrops(int j, int i, Tile tileCache, ushort typeCache)
    {
      int num1 = 60;
      switch (typeCache)
      {
        case 374:
          num1 = 120;
          break;
        case 375:
          num1 = 180;
          break;
        case 461:
          num1 = 180;
          break;
      }
      if (this._rand.Next(num1 * 2) != 0 || tileCache.liquid != (byte) 0)
        return;
      Rectangle rectangle1 = new Rectangle(i * 16, j * 16, 16, 16);
      rectangle1.X -= 34;
      rectangle1.Width += 68;
      rectangle1.Y -= 100;
      rectangle1.Height = 400;
      bool flag = true;
      for (int index = 0; index < 600; ++index)
      {
        if (this._gore[index].active && (this._gore[index].type >= 706 && this._gore[index].type <= 717 || this._gore[index].type == 943 || this._gore[index].type == 1147 || this._gore[index].type >= 1160 && this._gore[index].type <= 1162))
        {
          Rectangle rectangle2 = new Rectangle((int) this._gore[index].position.X, (int) this._gore[index].position.Y, 16, 16);
          if (rectangle1.Intersects(rectangle2))
            flag = false;
        }
      }
      if (!flag)
        return;
      Vector2 Position = new Vector2((float) (i * 16), (float) (j * 16));
      int num2 = 706;
      if (Main.waterStyle == 12)
        num2 = 1147;
      else if (Main.waterStyle > 1)
        num2 = 706 + Main.waterStyle - 1;
      if (typeCache == (ushort) 374)
        num2 = 716;
      if (typeCache == (ushort) 375)
        num2 = 717;
      if (typeCache == (ushort) 461)
      {
        num2 = 943;
        if (Main.player[Main.myPlayer].ZoneCorrupt)
          num2 = 1160;
        if (Main.player[Main.myPlayer].ZoneCrimson)
          num2 = 1161;
        if (Main.player[Main.myPlayer].ZoneHallow)
          num2 = 1162;
      }
      Vector2 Velocity = new Vector2();
      int Type = num2;
      this._gore[Gore.NewGore(Position, Velocity, Type)].velocity *= 0.0f;
    }

    private float GetWindCycle(int x, int y, double windCounter)
    {
      if (!Main.SettingsEnabled_TilesSwayInWind)
        return 0.0f;
      float num1 = (float) ((double) x * 0.5 + (double) (y / 100) * 0.5);
      float num2 = (float) Math.Cos(windCounter * 6.28318548202515 + (double) num1) * 0.5f;
      return (double) y < Main.worldSurface ? (num2 + Main.WindForVisuals) * Utils.GetLerpValue(0.08f, 0.18f, Math.Abs(Main.WindForVisuals), true) : 0.0f;
    }

    private bool ShouldSwayInWind(int x, int y, Tile tileCache) => Main.SettingsEnabled_TilesSwayInWind && TileID.Sets.SwaysInWindBasic[(int) tileCache.type] && (tileCache.type != (ushort) 227 || tileCache.frameX != (short) 204 && tileCache.frameX != (short) 238 && tileCache.frameX != (short) 408 && tileCache.frameX != (short) 442 && tileCache.frameX != (short) 476);

    private void UpdateLeafFrequency()
    {
      float num = Math.Abs(Main.WindForVisuals);
      this._leafFrequency = (double) num > 0.100000001490116 ? ((double) num > 0.200000002980232 ? ((double) num > 0.300000011920929 ? ((double) num > 0.400000005960464 ? ((double) num > 0.5 ? ((double) num > 0.600000023841858 ? ((double) num > 0.699999988079071 ? ((double) num > 0.800000011920929 ? ((double) num > 0.899999976158142 ? ((double) num > 1.0 ? ((double) num > 1.10000002384186 ? 10 : 20) : 30) : 40) : 50) : 75) : 130) : 200) : 300) : 450) : 1000) : 2000;
      this._leafFrequency *= 7;
    }

    private void EnsureWindGridSize()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 offSet = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        offSet = Vector2.Zero;
      int firstTileX;
      int lastTileX;
      int firstTileY;
      int lastTileY;
      this.GetScreenDrawArea(unscaledPosition, offSet, out firstTileX, out lastTileX, out firstTileY, out lastTileY);
      this._windGrid.SetSize(lastTileX - firstTileX, lastTileY - firstTileY);
    }

    private void EmitTreeLeaves(int tilePosX, int tilePosY, int grassPosX, int grassPosY)
    {
      if (!this._isActiveAndNotPaused)
        return;
      int treeHeight = grassPosY - tilePosY;
      Tile topTile = Main.tile[tilePosX, tilePosY];
      if (topTile.liquid > (byte) 0)
        return;
      int passStyle;
      WorldGen.GetTreeLeaf(tilePosX, topTile, Main.tile[grassPosX, grassPosY], ref treeHeight, out int _, out passStyle);
      if (passStyle == -1 || passStyle == 912 || passStyle == 913)
        return;
      bool flag1 = passStyle >= 917 && passStyle <= 925 || passStyle >= 1113 && passStyle <= 1121;
      int maxValue = this._leafFrequency;
      bool flag2 = (uint) (tilePosX - grassPosX) > 0U;
      if (flag1)
        maxValue /= 2;
      if ((double) tilePosY > Main.worldSurface)
        maxValue = 10000;
      if (flag2)
        maxValue *= 3;
      if (this._rand.Next(maxValue) != 0)
        return;
      int num1 = 2;
      Vector2 vector2 = new Vector2((float) (tilePosX * 16 + 8), (float) (tilePosY * 16 + 8));
      if (flag2)
      {
        int num2 = tilePosX - grassPosX;
        vector2.X += (float) (num2 * 12);
        int num3 = 0;
        if (topTile.frameY == (short) 220)
          num3 = 1;
        else if (topTile.frameY == (short) 242)
          num3 = 2;
        if (topTile.frameX == (short) 66)
        {
          switch (num3)
          {
            case 0:
              vector2 += new Vector2(0.0f, -6f);
              break;
            case 1:
              vector2 += new Vector2(0.0f, -6f);
              break;
            case 2:
              vector2 += new Vector2(0.0f, 8f);
              break;
          }
        }
        else
        {
          switch (num3)
          {
            case 0:
              vector2 += new Vector2(0.0f, 4f);
              break;
            case 1:
              vector2 += new Vector2(2f, -6f);
              break;
            case 2:
              vector2 += new Vector2(6f, -6f);
              break;
          }
        }
      }
      else
      {
        vector2 += new Vector2(-16f, -16f);
        if (flag1)
          vector2.Y -= (float) (Main.rand.Next(0, 28) * 4);
      }
      if (WorldGen.SolidTile(vector2.ToTileCoordinates()))
        return;
      Gore.NewGoreDirect(vector2, Utils.RandomVector2(Main.rand, (float) -num1, (float) num1), passStyle, (float) (0.699999988079071 + (double) Main.rand.NextFloat() * 0.600000023841858)).Frame.CurrentColumn = Main.tile[tilePosX, tilePosY].color();
    }

    private void DrawSpecialTilesLegacy(Vector2 screenPosition, Vector2 offSet)
    {
      for (int index1 = 0; index1 < this._specialTilesCount; ++index1)
      {
        int index2 = this._specialTileX[index1];
        int index3 = this._specialTileY[index1];
        Tile tile = Main.tile[index2, index3];
        ushort type1 = tile.type;
        short frameX1 = tile.frameX;
        short frameY1 = tile.frameY;
        if (type1 == (ushort) 237)
          Main.spriteBatch.Draw(TextureAssets.SunOrb.Value, new Vector2((float) (index2 * 16 - (int) screenPosition.X) + 8f, (float) (index3 * 16 - (int) screenPosition.Y - 36)) + offSet, new Rectangle?(new Rectangle(0, 0, TextureAssets.SunOrb.Width(), TextureAssets.SunOrb.Height())), new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, 0), Main.sunCircle, new Vector2((float) (TextureAssets.SunOrb.Width() / 2), (float) (TextureAssets.SunOrb.Height() / 2)), 1f, SpriteEffects.None, 0.0f);
        if (type1 == (ushort) 334 && frameX1 >= (short) 5000)
        {
          int num1 = (int) frameY1 / 18;
          int num2 = (int) frameX1;
          int num3 = 0;
          int type2 = num2 % 5000 - 100;
          for (; num2 >= 5000; num2 -= 5000)
            ++num3;
          int frameX2 = (int) Main.tile[index2 + 1, index3].frameX;
          int pre = frameX2 < 25000 ? frameX2 - 10000 : frameX2 - 25000;
          Item obj = new Item();
          obj.netDefaults(type2);
          obj.Prefix(pre);
          Main.instance.LoadItem(obj.type);
          Texture2D texture2D = TextureAssets.Item[obj.type].Value;
          Rectangle rectangle = Main.itemAnimations[obj.type] == null ? texture2D.Frame() : Main.itemAnimations[obj.type].GetFrame(texture2D);
          int width = rectangle.Width;
          int height = rectangle.Height;
          float num4 = 1f;
          if (width > 40 || height > 40)
            num4 = width <= height ? 40f / (float) height : 40f / (float) width;
          float scale = num4 * obj.scale;
          SpriteEffects effects = SpriteEffects.None;
          if (num3 >= 3)
            effects = SpriteEffects.FlipHorizontally;
          Color color = Lighting.GetColor(index2, index3);
          Main.spriteBatch.Draw(texture2D, new Vector2((float) (index2 * 16 - (int) screenPosition.X + 24), (float) (index3 * 16 - (int) screenPosition.Y + 8)) + offSet, new Rectangle?(rectangle), Lighting.GetColor(index2, index3), 0.0f, new Vector2((float) (width / 2), (float) (height / 2)), scale, effects, 0.0f);
          if (obj.color != new Color())
            Main.spriteBatch.Draw(texture2D, new Vector2((float) (index2 * 16 - (int) screenPosition.X + 24), (float) (index3 * 16 - (int) screenPosition.Y + 8)) + offSet, new Rectangle?(rectangle), obj.GetColor(color), 0.0f, new Vector2((float) (width / 2), (float) (height / 2)), scale, effects, 0.0f);
        }
        if (type1 == (ushort) 395)
        {
          Item theItem = ((TEItemFrame) TileEntity.ByPosition[new Point16(index2, index3)]).item;
          Vector2 screenPositionForItemCenter = new Vector2((float) (index2 * 16 - (int) screenPosition.X + 16), (float) (index3 * 16 - (int) screenPosition.Y + 16)) + offSet;
          Color color = Lighting.GetColor(index2, index3);
          Main.DrawItemIcon(Main.spriteBatch, theItem, screenPositionForItemCenter, color, 20f);
        }
        if (type1 == (ushort) 520)
        {
          Item obj = ((TEFoodPlatter) TileEntity.ByPosition[new Point16(index2, index3)]).item;
          if (!obj.IsAir)
          {
            Main.instance.LoadItem(obj.type);
            Texture2D texture2D = TextureAssets.Item[obj.type].Value;
            Rectangle rectangle = !ItemID.Sets.IsFood[obj.type] ? texture2D.Frame() : texture2D.Frame(verticalFrames: 3, frameY: 2);
            int width = rectangle.Width;
            int height = rectangle.Height;
            float num = 1f;
            SpriteEffects effects = tile.frameX == (short) 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Color color = Lighting.GetColor(index2, index3);
            Color currentColor = color;
            float scale1 = 1f;
            ItemSlot.GetItemLight(ref currentColor, ref scale1, obj);
            float scale2 = num * scale1;
            Vector2 position = new Vector2((float) (index2 * 16 - (int) screenPosition.X + 8), (float) (index3 * 16 - (int) screenPosition.Y + 16)) + offSet;
            position.Y += 2f;
            Vector2 origin = new Vector2((float) (width / 2), (float) height);
            Main.spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle), currentColor, 0.0f, origin, scale2, effects, 0.0f);
            if (obj.color != new Color())
              Main.spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle), obj.GetColor(color), 0.0f, origin, scale2, effects, 0.0f);
          }
        }
        if (type1 == (ushort) 471)
        {
          Item obj = (TileEntity.ByPosition[new Point16(index2, index3)] as TEWeaponsRack).item;
          Main.instance.LoadItem(obj.type);
          Texture2D texture2D = TextureAssets.Item[obj.type].Value;
          Rectangle rectangle = Main.itemAnimations[obj.type] == null ? texture2D.Frame() : Main.itemAnimations[obj.type].GetFrame(texture2D);
          int width = rectangle.Width;
          int height = rectangle.Height;
          float num5 = 1f;
          float num6 = 40f;
          if ((double) width > (double) num6 || (double) height > (double) num6)
            num5 = width <= height ? num6 / (float) height : num6 / (float) width;
          float num7 = num5 * obj.scale;
          SpriteEffects effects = SpriteEffects.FlipHorizontally;
          if (tile.frameX < (short) 54)
            effects = SpriteEffects.None;
          Color color = Lighting.GetColor(index2, index3);
          Color currentColor = color;
          float scale3 = 1f;
          ItemSlot.GetItemLight(ref currentColor, ref scale3, obj);
          float scale4 = num7 * scale3;
          Main.spriteBatch.Draw(texture2D, new Vector2((float) (index2 * 16 - (int) screenPosition.X + 24), (float) (index3 * 16 - (int) screenPosition.Y + 24)) + offSet, new Rectangle?(rectangle), currentColor, 0.0f, new Vector2((float) (width / 2), (float) (height / 2)), scale4, effects, 0.0f);
          if (obj.color != new Color())
            Main.spriteBatch.Draw(texture2D, new Vector2((float) (index2 * 16 - (int) screenPosition.X + 24), (float) (index3 * 16 - (int) screenPosition.Y + 24)) + offSet, new Rectangle?(rectangle), obj.GetColor(color), 0.0f, new Vector2((float) (width / 2), (float) (height / 2)), scale4, effects, 0.0f);
        }
        if (type1 == (ushort) 412)
        {
          Texture2D texture2D = TextureAssets.GlowMask[202].Value;
          int frameY2 = Main.tileFrame[(int) type1] / 60;
          int frameY3 = (frameY2 + 1) % 4;
          float num = (float) (Main.tileFrame[(int) type1] % 60) / 60f;
          Color color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          Main.spriteBatch.Draw(texture2D, new Vector2((float) (index2 * 16 - (int) screenPosition.X), (float) (index3 * 16 - (int) screenPosition.Y + 10)) + offSet, new Rectangle?(texture2D.Frame(verticalFrames: 4, frameY: frameY2)), color * (1f - num), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          Main.spriteBatch.Draw(texture2D, new Vector2((float) (index2 * 16 - (int) screenPosition.X), (float) (index3 * 16 - (int) screenPosition.Y + 10)) + offSet, new Rectangle?(texture2D.Frame(verticalFrames: 4, frameY: frameY3)), color * num, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
        if (type1 == (ushort) 620)
        {
          Texture2D texture = TextureAssets.Extra[202].Value;
          double num8 = (double) (Main.tileFrame[(int) type1] % 60) / 60.0;
          int num9 = 2;
          Main.critterCage = true;
          int waterAnimalCageFrame = this.GetWaterAnimalCageFrame(index2, index3, (int) frameX1, (int) frameY1);
          int index4 = 8;
          int num10 = Main.butterflyCageFrame[index4, waterAnimalCageFrame];
          int num11 = 6;
          float num12 = 1f;
          Rectangle rectangle = new Rectangle(0, 34 * num10, 32, 32);
          Vector2 position1 = new Vector2((float) (index2 * 16 - (int) screenPosition.X), (float) (index3 * 16 - (int) screenPosition.Y + num9)) + offSet;
          Main.spriteBatch.Draw(texture, position1, new Rectangle?(rectangle), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          for (int index5 = 0; index5 < num11; ++index5)
          {
            Color color = new Color((int) sbyte.MaxValue, (int) sbyte.MaxValue, (int) sbyte.MaxValue, 0).MultiplyRGBA(Main.hslToRgb((float) (((double) Main.GlobalTimeWrappedHourly + (double) index5 / (double) num11) % 1.0), 1f, 0.5f)) * (float) (1.0 - (double) num12 * 0.5);
            color.A = (byte) 0;
            int num13 = 2;
            Vector2 position2 = position1 + ((float) ((double) index5 / (double) num11 * 6.28318548202515)).ToRotationVector2() * (float) ((double) num13 * (double) num12 + 2.0);
            Main.spriteBatch.Draw(texture, position2, new Rectangle?(rectangle), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          }
          Main.spriteBatch.Draw(texture, position1, new Rectangle?(rectangle), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0) * 0.1f, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
      }
    }

    private void DrawEntities_DisplayDolls()
    {
      Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, (Effect) null, Main.Transform);
      foreach (KeyValuePair<Point, int> tileEntityPosition in this._displayDollTileEntityPositions)
      {
        TileEntity tileEntity;
        if (tileEntityPosition.Value != -1 && TileEntity.ByPosition.TryGetValue(new Point16(tileEntityPosition.Key.X, tileEntityPosition.Key.Y), out tileEntity))
          (tileEntity as TEDisplayDoll).Draw(tileEntityPosition.Key.X, tileEntityPosition.Key.Y);
      }
      Main.spriteBatch.End();
    }

    private void DrawEntities_HatRacks()
    {
      Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, (Effect) null, Main.Transform);
      foreach (KeyValuePair<Point, int> tileEntityPosition in this._hatRackTileEntityPositions)
      {
        TileEntity tileEntity;
        if (tileEntityPosition.Value != -1 && TileEntity.ByPosition.TryGetValue(new Point16(tileEntityPosition.Key.X, tileEntityPosition.Key.Y), out tileEntity))
          (tileEntity as TEHatRack).Draw(tileEntityPosition.Key.X, tileEntityPosition.Key.Y);
      }
      Main.spriteBatch.End();
    }

    private void DrawTrees()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 zero = Vector2.Zero;
      int index1 = 0;
      int num1 = this._specialsCount[index1];
      float num2 = 0.08f;
      float num3 = 0.06f;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        Point point = this._specialPositions[index1][index2];
        int x = point.X;
        int y1 = point.Y;
        Tile t = Main.tile[x, y1];
        if (t != null && t.active())
        {
          ushort type = t.type;
          short frameX = t.frameX;
          short frameY1 = t.frameY;
          bool flag1 = t.wall > (ushort) 0;
          WorldGen.GetTreeFoliageDataMethod foliageDataMethod = (WorldGen.GetTreeFoliageDataMethod) null;
          try
          {
            bool flag2 = false;
            switch (type)
            {
              case 5:
                flag2 = true;
                foliageDataMethod = new WorldGen.GetTreeFoliageDataMethod(WorldGen.GetCommonTreeFoliageData);
                break;
              case 583:
              case 584:
              case 585:
              case 586:
              case 587:
              case 588:
              case 589:
                flag2 = true;
                foliageDataMethod = new WorldGen.GetTreeFoliageDataMethod(WorldGen.GetGemTreeFoliageData);
                break;
              case 596:
              case 616:
                flag2 = true;
                foliageDataMethod = new WorldGen.GetTreeFoliageDataMethod(WorldGen.GetVanityTreeFoliageData);
                break;
            }
            if (flag2 && frameY1 >= (short) 198 && frameX >= (short) 22)
            {
              int treeFrame = WorldGen.GetTreeFrame(t);
              switch (frameX)
              {
                case 22:
                  int treeStyle1 = 0;
                  int topTextureFrameWidth1 = 80;
                  int topTextureFrameHeight1 = 80;
                  int xoffset1 = 0;
                  int grassPosX = x + xoffset1;
                  int floorY1 = y1;
                  if (foliageDataMethod(x, y1, xoffset1, ref treeFrame, ref treeStyle1, out floorY1, out topTextureFrameWidth1, out topTextureFrameHeight1))
                  {
                    this.EmitTreeLeaves(x, y1, grassPosX, floorY1);
                    if (treeStyle1 == 14)
                    {
                      float num4 = (float) this._rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 1000f;
                      Lighting.AddLight(x, y1, 0.1f, (float) (0.200000002980232 + (double) num4 / 2.0), 0.7f + num4);
                    }
                    byte tileColor = t.color();
                    Texture2D treeTopTexture = this.GetTreeTopTexture(treeStyle1, 0, tileColor);
                    Vector2 vector2;
                    Vector2 position = vector2 = new Vector2((float) (x * 16 - (int) unscaledPosition.X + 8), (float) (y1 * 16 - (int) unscaledPosition.Y + 16)) + zero;
                    float num5 = 0.0f;
                    if (!flag1)
                      num5 = this.GetWindCycle(x, y1, this._treeWindCounter);
                    position.X += num5 * 2f;
                    position.Y += Math.Abs(num5) * 2f;
                    Color color = Lighting.GetColor(x, y1);
                    if (t.color() == (byte) 31)
                      color = Color.White;
                    Main.spriteBatch.Draw(treeTopTexture, position, new Rectangle?(new Rectangle(treeFrame * (topTextureFrameWidth1 + 2), 0, topTextureFrameWidth1, topTextureFrameHeight1)), color, num5 * num2, new Vector2((float) (topTextureFrameWidth1 / 2), (float) topTextureFrameHeight1), 1f, SpriteEffects.None, 0.0f);
                    break;
                  }
                  continue;
                case 44:
                  int treeStyle2 = 0;
                  int num6 = x;
                  int floorY2 = y1;
                  int xoffset2 = 1;
                  int topTextureFrameWidth2;
                  int topTextureFrameHeight2;
                  if (foliageDataMethod(x, y1, xoffset2, ref treeFrame, ref treeStyle2, out floorY2, out topTextureFrameWidth2, out topTextureFrameHeight2))
                  {
                    this.EmitTreeLeaves(x, y1, num6 + xoffset2, floorY2);
                    if (treeStyle2 == 14)
                    {
                      float num7 = (float) this._rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 1000f;
                      Lighting.AddLight(x, y1, 0.1f, (float) (0.200000002980232 + (double) num7 / 2.0), 0.7f + num7);
                    }
                    byte tileColor = t.color();
                    Texture2D treeBranchTexture = this.GetTreeBranchTexture(treeStyle2, 0, tileColor);
                    Vector2 position = new Vector2((float) (x * 16), (float) (y1 * 16)) - unscaledPosition.Floor() + zero + new Vector2(16f, 12f);
                    float num8 = 0.0f;
                    if (!flag1)
                      num8 = this.GetWindCycle(x, y1, this._treeWindCounter);
                    if ((double) num8 > 0.0)
                      position.X += num8;
                    position.X += Math.Abs(num8) * 2f;
                    Color color = Lighting.GetColor(x, y1);
                    if (t.color() == (byte) 31)
                      color = Color.White;
                    Main.spriteBatch.Draw(treeBranchTexture, position, new Rectangle?(new Rectangle(0, treeFrame * 42, 40, 40)), color, num8 * num3, new Vector2(40f, 24f), 1f, SpriteEffects.None, 0.0f);
                    break;
                  }
                  continue;
                case 66:
                  int treeStyle3 = 0;
                  int num9 = x;
                  int floorY3 = y1;
                  int xoffset3 = -1;
                  int topTextureFrameWidth3;
                  int topTextureFrameHeight3;
                  if (foliageDataMethod(x, y1, xoffset3, ref treeFrame, ref treeStyle3, out floorY3, out topTextureFrameWidth3, out topTextureFrameHeight3))
                  {
                    this.EmitTreeLeaves(x, y1, num9 + xoffset3, floorY3);
                    if (treeStyle3 == 14)
                    {
                      float num10 = (float) this._rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 1000f;
                      Lighting.AddLight(x, y1, 0.1f, (float) (0.200000002980232 + (double) num10 / 2.0), 0.7f + num10);
                    }
                    byte tileColor = t.color();
                    Texture2D treeBranchTexture = this.GetTreeBranchTexture(treeStyle3, 0, tileColor);
                    Vector2 position = new Vector2((float) (x * 16), (float) (y1 * 16)) - unscaledPosition.Floor() + zero + new Vector2(0.0f, 18f);
                    float num11 = 0.0f;
                    if (!flag1)
                      num11 = this.GetWindCycle(x, y1, this._treeWindCounter);
                    if ((double) num11 < 0.0)
                      position.X += num11;
                    position.X -= Math.Abs(num11) * 2f;
                    Color color = Lighting.GetColor(x, y1);
                    if (t.color() == (byte) 31)
                      color = Color.White;
                    Main.spriteBatch.Draw(treeBranchTexture, position, new Rectangle?(new Rectangle(42, treeFrame * 42, 40, 40)), color, num11 * num3, new Vector2(0.0f, 30f), 1f, SpriteEffects.None, 0.0f);
                    break;
                  }
                  continue;
              }
            }
            if (type == (ushort) 323)
            {
              if (frameX >= (short) 88)
              {
                if (frameX <= (short) 132)
                {
                  int num12 = 0;
                  if (frameX == (short) 110)
                    num12 = 1;
                  else if (frameX == (short) 132)
                    num12 = 2;
                  int treeTextureIndex = 15;
                  int width = 80;
                  int height = 80;
                  int num13 = 32;
                  int num14 = 0;
                  int palmTreeBiome = this.GetPalmTreeBiome(x, y1);
                  int y2 = palmTreeBiome * 82;
                  if (palmTreeBiome >= 4 && palmTreeBiome <= 7)
                  {
                    treeTextureIndex = 21;
                    width = 114;
                    height = 98;
                    y2 = (palmTreeBiome - 4) * 98;
                    num13 = 48;
                    num14 = 2;
                  }
                  int frameY2 = (int) Main.tile[x, y1].frameY;
                  byte tileColor = t.color();
                  Texture2D treeTopTexture = this.GetTreeTopTexture(treeTextureIndex, palmTreeBiome, tileColor);
                  Vector2 position = new Vector2((float) (x * 16 - (int) unscaledPosition.X - num13 + frameY2 + width / 2), (float) (y1 * 16 - (int) unscaledPosition.Y + 16 + num14)) + zero;
                  float num15 = 0.0f;
                  if (!flag1)
                    num15 = this.GetWindCycle(x, y1, this._treeWindCounter);
                  position.X += num15 * 2f;
                  position.Y += Math.Abs(num15) * 2f;
                  Color color = Lighting.GetColor(x, y1);
                  if (t.color() == (byte) 31)
                    color = Color.White;
                  Main.spriteBatch.Draw(treeTopTexture, position, new Rectangle?(new Rectangle(num12 * (width + 2), y2, width, height)), color, num15 * num2, new Vector2((float) (width / 2), (float) height), 1f, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
          catch
          {
          }
        }
      }
    }

    private Texture2D GetTreeTopTexture(
      int treeTextureIndex,
      int treeTextureStyle,
      byte tileColor)
    {
      return this._paintSystem.TryGetTreeTopAndRequestIfNotReady(treeTextureIndex, treeTextureStyle, (int) tileColor) ?? TextureAssets.TreeTop[treeTextureIndex].Value;
    }

    private Texture2D GetTreeBranchTexture(
      int treeTextureIndex,
      int treeTextureStyle,
      byte tileColor)
    {
      return this._paintSystem.TryGetTreeBranchAndRequestIfNotReady(treeTextureIndex, treeTextureStyle, (int) tileColor) ?? TextureAssets.TreeBranch[treeTextureIndex].Value;
    }

    private void DrawGrass()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 zero = Vector2.Zero;
      int index1 = 3;
      int num1 = this._specialsCount[index1];
      for (int index2 = 0; index2 < num1; ++index2)
      {
        Point point = this._specialPositions[index1][index2];
        int x = point.X;
        int y = point.Y;
        Tile tile = Main.tile[x, y];
        if (tile != null && tile.active())
        {
          ushort type = tile.type;
          short frameX = tile.frameX;
          short frameY = tile.frameY;
          int tileWidth;
          int tileHeight;
          int tileTop;
          int halfBrickHeight;
          int addFrX;
          int addFrY;
          SpriteEffects tileSpriteEffect;
          this.GetTileDrawData(x, y, tile, type, ref frameX, ref frameY, out tileWidth, out tileHeight, out tileTop, out halfBrickHeight, out addFrX, out addFrY, out tileSpriteEffect, out Texture2D _, out Rectangle _, out Color _);
          bool canDoDust = this._rand.Next(4) == 0;
          Color tileLight = Lighting.GetColor(x, y);
          this.DrawAnimatedTile_AdjustForVisionChangers(x, y, tile, type, frameX, frameY, ref tileLight, canDoDust);
          tileLight = this.DrawTiles_GetLightOverride(y, x, tile, type, frameX, frameY, tileLight);
          if (this._isActiveAndNotPaused & canDoDust)
            this.DrawTiles_EmitParticles(y, x, tile, type, frameX, frameY, tileLight);
          if (type == (ushort) 83 && this.IsAlchemyPlantHarvestable((int) frameX / 18))
          {
            ushort num2 = 84;
            Main.instance.LoadTiles((int) num2);
          }
          if (tile.type == (ushort) 227 && frameX == (short) 202)
          {
            bool evil;
            bool good;
            bool crimson;
            this.GetCactusType(x, y, (int) frameX, (int) frameY, out evil, out good, out crimson);
            if (good)
              frameX += (short) 170;
            if (evil)
              frameX += (short) 204;
            if (crimson)
              frameX += (short) 238;
          }
          Vector2 position = new Vector2((float) (x * 16 - (int) unscaledPosition.X + 8), (float) (y * 16 - (int) unscaledPosition.Y + 16)) + zero;
          double grassWindCounter = this._grassWindCounter;
          float num3 = this.GetWindCycle(x, y, this._grassWindCounter);
          if (!WallID.Sets.AllowsWind[(int) tile.wall])
            num3 = 0.0f;
          if (!this.InAPlaceWithWind(x, y, 1, 1))
            num3 = 0.0f;
          float num4 = num3 + this.GetWindGridPush(x, y, 20, 0.35f);
          position.X += num4 * 1f;
          position.Y += Math.Abs(num4) * 1f;
          Texture2D tileDrawTexture = this.GetTileDrawTexture(tile, x, y);
          if (tileDrawTexture != null)
            Main.spriteBatch.Draw(tileDrawTexture, position, new Rectangle?(new Rectangle((int) frameX + addFrX, (int) frameY + addFrY, tileWidth, tileHeight - halfBrickHeight)), tileLight, num4 * 0.1f, new Vector2((float) (tileWidth / 2), (float) (16 - halfBrickHeight - tileTop)), 1f, tileSpriteEffect, 0.0f);
        }
      }
    }

    private void DrawAnimatedTile_AdjustForVisionChangers(
      int i,
      int j,
      Tile tileCache,
      ushort typeCache,
      short tileFrameX,
      short tileFrameY,
      ref Color tileLight,
      bool canDoDust)
    {
      if (this._localPlayer.dangerSense && TileDrawing.IsTileDangerous(this._localPlayer, tileCache, typeCache))
      {
        if (tileLight.R < byte.MaxValue)
          tileLight.R = byte.MaxValue;
        if (tileLight.G < (byte) 50)
          tileLight.G = (byte) 50;
        if (tileLight.B < (byte) 50)
          tileLight.B = (byte) 50;
        if (this._isActiveAndNotPaused & canDoDust && this._rand.Next(30) == 0)
        {
          int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 60, Alpha: 100, Scale: 0.3f);
          this._dust[index].fadeIn = 1f;
          this._dust[index].velocity *= 0.1f;
          this._dust[index].noLight = true;
          this._dust[index].noGravity = true;
        }
      }
      if (!this._localPlayer.findTreasure || !Main.IsTileSpelunkable(typeCache, tileFrameX, tileFrameY))
        return;
      if (tileLight.R < (byte) 200)
        tileLight.R = (byte) 200;
      if (tileLight.G < (byte) 170)
        tileLight.G = (byte) 170;
      if (!this._isActiveAndNotPaused || !(this._rand.Next(60) == 0 & canDoDust))
        return;
      int index1 = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 204, Alpha: 150, Scale: 0.3f);
      this._dust[index1].fadeIn = 1f;
      this._dust[index1].velocity *= 0.1f;
      this._dust[index1].noLight = true;
    }

    private float GetWindGridPush(
      int i,
      int j,
      int pushAnimationTimeTotal,
      float pushForcePerFrame)
    {
      int windTimeLeft;
      int direction;
      this._windGrid.GetWindTime(i, j, pushAnimationTimeTotal, out windTimeLeft, out direction);
      return windTimeLeft >= pushAnimationTimeTotal / 2 ? (float) (pushAnimationTimeTotal - windTimeLeft) * pushForcePerFrame * (float) direction : (float) windTimeLeft * pushForcePerFrame * (float) direction;
    }

    private float GetWindGridPushComplex(
      int i,
      int j,
      int pushAnimationTimeTotal,
      float totalPushForce,
      int loops,
      bool flipDirectionPerLoop)
    {
      int windTimeLeft;
      int direction;
      this._windGrid.GetWindTime(i, j, pushAnimationTimeTotal, out windTimeLeft, out direction);
      double num1 = (double) windTimeLeft / (double) pushAnimationTimeTotal;
      int num2 = (int) (num1 * (double) loops);
      float num3 = (float) (num1 * (double) loops % 1.0);
      double num4 = 1.0 / (double) loops;
      if (flipDirectionPerLoop && num2 % 2 == 1)
        direction *= -1;
      return num1 * (double) loops % 1.0 > 0.5 ? (1f - num3) * totalPushForce * (float) direction * (float) (loops - num2) : num3 * totalPushForce * (float) direction * (float) (loops - num2);
    }

    private void DrawMasterTrophies()
    {
      int index1 = 11;
      int num1 = this._specialsCount[index1];
      for (int index2 = 0; index2 < num1; ++index2)
      {
        Point p = this._specialPositions[index1][index2];
        Tile tile = Main.tile[p.X, p.Y];
        if (tile != null && tile.active())
        {
          Texture2D texture2D = TextureAssets.Extra[198].Value;
          int frameY = (int) tile.frameX / 54;
          int num2 = (uint) tile.frameY / 72U > 0U ? 1 : 0;
          int horizontalFrames = 1;
          int verticalFrames = 27;
          Rectangle r = texture2D.Frame(horizontalFrames, verticalFrames, frameY: frameY);
          Vector2 origin = r.Size() / 2f;
          Vector2 worldCoordinates = p.ToWorldCoordinates(24f, 64f);
          float num3 = (float) Math.Sin((double) Main.GlobalTimeWrappedHourly * 6.28318548202515 / 5.0);
          Vector2 vector2_1 = new Vector2(0.0f, -40f);
          Vector2 vector2_2 = worldCoordinates + vector2_1 + new Vector2(0.0f, num3 * 4f);
          Color color1 = Lighting.GetColor(p.X, p.Y);
          SpriteEffects effects = num2 != 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
          Main.spriteBatch.Draw(texture2D, vector2_2 - Main.screenPosition, new Rectangle?(r), color1, 0.0f, origin, 1f, effects, 0.0f);
          float num4 = (float) (Math.Sin((double) Main.GlobalTimeWrappedHourly * 6.28318548202515 / 2.0) * 0.300000011920929 + 0.699999988079071);
          Color color2 = color1;
          color2.A = (byte) 0;
          Color color3 = color2 * 0.1f * num4;
          for (float num5 = 0.0f; (double) num5 < 1.0; num5 += 0.1666667f)
            Main.spriteBatch.Draw(texture2D, vector2_2 - Main.screenPosition + (6.283185f * num5).ToRotationVector2() * (float) (6.0 + (double) num3 * 2.0), new Rectangle?(r), color3, 0.0f, origin, 1f, effects, 0.0f);
        }
      }
    }

    private void DrawTeleportationPylons()
    {
      int index1 = 10;
      int num1 = this._specialsCount[index1];
      for (int index2 = 0; index2 < num1; ++index2)
      {
        Point p = this._specialPositions[index1][index2];
        Tile tile = Main.tile[p.X, p.Y];
        if (tile != null && tile.active())
        {
          Texture2D texture2D = TextureAssets.Extra[181].Value;
          int tileStyle = (int) tile.frameX / 54;
          int num2 = 3;
          int horizontalFrames = num2 + 9;
          int verticalFrames = 8;
          int frameY = (Main.tileFrameCounter[597] + p.X + p.Y) % 64 / 8;
          Rectangle r = texture2D.Frame(horizontalFrames, verticalFrames, num2 + tileStyle, frameY);
          Rectangle rectangle = texture2D.Frame(horizontalFrames, verticalFrames, 2, frameY);
          texture2D.Frame(horizontalFrames, verticalFrames, frameY: frameY);
          Vector2 origin = r.Size() / 2f;
          Vector2 worldCoordinates = p.ToWorldCoordinates(24f, 64f);
          float num3 = (float) Math.Sin((double) Main.GlobalTimeWrappedHourly * 6.28318548202515 / 5.0);
          Vector2 vector2 = new Vector2(0.0f, -40f);
          Vector2 center = worldCoordinates + vector2 + new Vector2(0.0f, num3 * 4f);
          if (this._isActiveAndNotPaused & this._rand.Next(4) == 0 && this._rand.Next(10) == 0)
          {
            Rectangle dustBox = Utils.CenteredRectangle(center, r.Size());
            TeleportPylonsSystem.SpawnInWorldDust(tileStyle, dustBox);
          }
          Color color1 = Color.Lerp(Lighting.GetColor(p.X, p.Y), Color.White, 0.8f);
          Main.spriteBatch.Draw(texture2D, center - Main.screenPosition, new Rectangle?(r), color1 * 0.7f, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
          Color color2 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0) * 0.1f * (float) (Math.Sin((double) Main.GlobalTimeWrappedHourly * 6.28318548202515 / 1.0) * 0.200000002980232 + 0.800000011920929);
          for (float num4 = 0.0f; (double) num4 < 1.0; num4 += 0.1666667f)
            Main.spriteBatch.Draw(texture2D, center - Main.screenPosition + (6.283185f * num4).ToRotationVector2() * (float) (6.0 + (double) num3 * 2.0), new Rectangle?(r), color2, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
          int num5 = 0;
          bool actuallySelected;
          if (Main.InSmartCursorHighlightArea(p.X, p.Y, out actuallySelected))
          {
            num5 = 1;
            if (actuallySelected)
              num5 = 2;
          }
          if (num5 != 0)
          {
            int averageTileLighting = ((int) color1.R + (int) color1.G + (int) color1.B) / 3;
            if (averageTileLighting > 10)
            {
              Color selectionGlowColor = Colors.GetSelectionGlowColor(num5 == 2, averageTileLighting);
              Main.spriteBatch.Draw(texture2D, center - Main.screenPosition, new Rectangle?(rectangle), selectionGlowColor, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
      }
    }

    private void DrawVoidLenses()
    {
      int index1 = 8;
      int num = this._specialsCount[index1];
      this._voidLensData.Clear();
      for (int index2 = 0; index2 < num; ++index2)
      {
        Point p = this._specialPositions[index1][index2];
        VoidLensHelper voidLensHelper = new VoidLensHelper(p.ToWorldCoordinates(), 1f);
        if (!Main.gamePaused)
          voidLensHelper.Update();
        int selectionMode = 0;
        bool actuallySelected;
        if (Main.InSmartCursorHighlightArea(p.X, p.Y, out actuallySelected))
        {
          selectionMode = 1;
          if (actuallySelected)
            selectionMode = 2;
        }
        voidLensHelper.DrawToDrawData(this._voidLensData, selectionMode);
      }
      foreach (DrawData drawData in this._voidLensData)
        drawData.Draw(Main.spriteBatch);
    }

    private void DrawMultiTileGrass()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 zero = Vector2.Zero;
      int index1 = 4;
      int num = this._specialsCount[index1];
      for (int index2 = 0; index2 < num; ++index2)
      {
        Point point = this._specialPositions[index1][index2];
        int x = point.X;
        int y = point.Y;
        int sizeX = 1;
        int sizeY = 1;
        Tile tile = Main.tile[x, y];
        if (tile != null && tile.active())
        {
          switch (Main.tile[x, y].type)
          {
            case 27:
              sizeX = 2;
              sizeY = 5;
              break;
            case 233:
              sizeX = Main.tile[x, y].frameY != (short) 0 ? 2 : 3;
              sizeY = 2;
              break;
            case 236:
            case 238:
              sizeX = sizeY = 2;
              break;
            case 485:
            case 490:
            case 521:
            case 522:
            case 523:
            case 524:
            case 525:
            case 526:
            case 527:
              sizeX = 2;
              sizeY = 2;
              break;
            case 489:
              sizeX = 2;
              sizeY = 3;
              break;
            case 493:
              sizeX = 1;
              sizeY = 2;
              break;
            case 519:
              sizeX = 1;
              sizeY = this.ClimbCatTail(x, y);
              y -= sizeY - 1;
              break;
            case 530:
              sizeX = 3;
              sizeY = 2;
              break;
          }
          this.DrawMultiTileGrassInWind(unscaledPosition, zero, x, y, sizeX, sizeY);
        }
      }
    }

    private int ClimbCatTail(int originx, int originy)
    {
      int num = 0;
      int index = originy;
      while (index > 10)
      {
        Tile tile = Main.tile[originx, index];
        if (tile.active() && tile.type == (ushort) 519)
        {
          if (tile.frameX >= (short) 180)
          {
            ++num;
            break;
          }
          --index;
          ++num;
        }
        else
          break;
      }
      return num;
    }

    private void DrawMultiTileVines()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 zero = Vector2.Zero;
      int index1 = 5;
      int num = this._specialsCount[index1];
      for (int index2 = 0; index2 < num; ++index2)
      {
        Point point = this._specialPositions[index1][index2];
        int x = point.X;
        int y = point.Y;
        int sizeX = 1;
        int sizeY = 1;
        Tile tile = Main.tile[x, y];
        if (tile != null && tile.active())
        {
          switch (Main.tile[x, y].type)
          {
            case 34:
              sizeX = 3;
              sizeY = 3;
              break;
            case 42:
            case 270:
            case 271:
            case 572:
            case 581:
              sizeX = 1;
              sizeY = 2;
              break;
            case 91:
              sizeX = 1;
              sizeY = 3;
              break;
            case 95:
            case 126:
            case 444:
              sizeX = 2;
              sizeY = 2;
              break;
            case 454:
              sizeX = 4;
              sizeY = 3;
              break;
            case 465:
            case 591:
            case 592:
              sizeX = 2;
              sizeY = 3;
              break;
          }
          this.DrawMultiTileVinesInWind(unscaledPosition, zero, x, y, sizeX, sizeY);
        }
      }
    }

    private void DrawVines()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 zero = Vector2.Zero;
      int index1 = 6;
      int num = this._specialsCount[index1];
      for (int index2 = 0; index2 < num; ++index2)
      {
        Point point = this._specialPositions[index1][index2];
        int x = point.X;
        int y = point.Y;
        this.DrawVineStrip(unscaledPosition, zero, x, y);
      }
    }

    private void DrawReverseVines()
    {
      Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
      Vector2 zero = Vector2.Zero;
      int index1 = 9;
      int num = this._specialsCount[index1];
      for (int index2 = 0; index2 < num; ++index2)
      {
        Point point = this._specialPositions[index1][index2];
        int x = point.X;
        int y = point.Y;
        this.DrawRisingVineStrip(unscaledPosition, zero, x, y);
      }
    }

    private void DrawMultiTileGrassInWind(
      Vector2 screenPosition,
      Vector2 offSet,
      int topLeftX,
      int topLeftY,
      int sizeX,
      int sizeY)
    {
      float windCycle = this.GetWindCycle(topLeftX, topLeftY, this._sunflowerWindCounter);
      Vector2 vector2_1 = new Vector2((float) (sizeX * 16) * 0.5f, (float) (sizeY * 16));
      Vector2 vector2_2 = new Vector2((float) (topLeftX * 16 - (int) screenPosition.X) + (float) ((double) sizeX * 16.0 * 0.5), (float) (topLeftY * 16 - (int) screenPosition.Y + 16 * sizeY)) + offSet;
      float num1 = 0.07f;
      int type1 = (int) Main.tile[topLeftX, topLeftY].type;
      Texture2D texture = (Texture2D) null;
      Color color1 = Color.Transparent;
      bool flag = this.InAPlaceWithWind(topLeftX, topLeftY, sizeX, sizeY);
      switch (type1)
      {
        case 27:
          texture = TextureAssets.Flames[14].Value;
          color1 = Color.White;
          break;
        case 519:
          flag = this.InAPlaceWithWind(topLeftX, topLeftY, sizeX, 1);
          break;
        case 521:
        case 522:
        case 523:
        case 524:
        case 525:
        case 526:
        case 527:
          num1 = 0.0f;
          flag = false;
          break;
        default:
          num1 = 0.15f;
          break;
      }
      for (int index1 = topLeftX; index1 < topLeftX + sizeX; ++index1)
      {
        for (int index2 = topLeftY; index2 < topLeftY + sizeY; ++index2)
        {
          Tile tile = Main.tile[index1, index2];
          ushort type2 = tile.type;
          if ((int) type2 == type1)
          {
            double num2 = (double) Math.Abs((float) (((double) (index1 - topLeftX) + 0.5) / (double) sizeX - 0.5));
            short frameX = tile.frameX;
            short frameY = tile.frameY;
            float num3 = (float) (1.0 - (double) (index2 - topLeftY + 1) / (double) sizeY);
            if ((double) num3 == 0.0)
              num3 = 0.1f;
            if (!flag)
              num3 = 0.0f;
            int tileWidth;
            int tileHeight;
            int tileTop;
            int halfBrickHeight;
            int addFrX;
            int addFrY;
            SpriteEffects tileSpriteEffect;
            this.GetTileDrawData(index1, index2, tile, type2, ref frameX, ref frameY, out tileWidth, out tileHeight, out tileTop, out halfBrickHeight, out addFrX, out addFrY, out tileSpriteEffect, out Texture2D _, out Rectangle _, out Color _);
            bool canDoDust = this._rand.Next(4) == 0;
            Color color2 = Lighting.GetColor(index1, index2);
            this.DrawAnimatedTile_AdjustForVisionChangers(index1, index2, tile, type2, frameX, frameY, ref color2, canDoDust);
            Color lightOverride = this.DrawTiles_GetLightOverride(index2, index1, tile, type2, frameX, frameY, color2);
            if (this._isActiveAndNotPaused & canDoDust)
              this.DrawTiles_EmitParticles(index2, index1, tile, type2, frameX, frameY, lightOverride);
            Vector2 vector2_3 = new Vector2((float) (index1 * 16 - (int) screenPosition.X), (float) (index2 * 16 - (int) screenPosition.Y + tileTop)) + offSet;
            if (tile.type == (ushort) 493 && tile.frameY == (short) 0)
            {
              if ((double) Main.WindForVisuals >= 0.0)
                tileSpriteEffect ^= SpriteEffects.FlipHorizontally;
              if (!tileSpriteEffect.HasFlag((Enum) SpriteEffects.FlipHorizontally))
                vector2_3.X -= 6f;
              else
                vector2_3.X += 6f;
            }
            Vector2 vector2_4 = new Vector2(windCycle * 1f, Math.Abs(windCycle) * 2f * num3);
            Vector2 origin = vector2_2 - vector2_3;
            Texture2D tileDrawTexture = this.GetTileDrawTexture(tile, index1, index2);
            if (tileDrawTexture != null)
            {
              Main.spriteBatch.Draw(tileDrawTexture, vector2_2 + new Vector2(0.0f, vector2_4.Y), new Rectangle?(new Rectangle((int) frameX + addFrX, (int) frameY + addFrY, tileWidth, tileHeight - halfBrickHeight)), lightOverride, windCycle * num1 * num3, origin, 1f, tileSpriteEffect, 0.0f);
              if (texture != null)
                Main.spriteBatch.Draw(texture, vector2_2 + new Vector2(0.0f, vector2_4.Y), new Rectangle?(new Rectangle((int) frameX + addFrX, (int) frameY + addFrY, tileWidth, tileHeight - halfBrickHeight)), color1, windCycle * num1 * num3, origin, 1f, tileSpriteEffect, 0.0f);
            }
          }
        }
      }
    }

    private void DrawVineStrip(Vector2 screenPosition, Vector2 offSet, int x, int startY)
    {
      int num1 = 0;
      int num2 = 0;
      Vector2 vector2 = new Vector2((float) (x * 16 + 8), (float) (startY * 16 - 2));
      float num3 = MathHelper.Lerp(0.2f, 1f, Math.Abs(Main.WindForVisuals) / 1.2f);
      float num4 = -0.08f * num3;
      float windCycle = this.GetWindCycle(x, startY, this._vineWindCounter);
      float num5 = 0.0f;
      float num6 = 0.0f;
      for (int index = startY; index < Main.maxTilesY - 10; ++index)
      {
        Tile tile = Main.tile[x, index];
        if (tile != null)
        {
          ushort type = tile.type;
          if (!tile.active() || !TileID.Sets.VineThreads[(int) type])
            break;
          ++num1;
          if (num2 >= 5)
            num4 += 0.0075f * num3;
          if (num2 >= 2)
            num4 += 1f / 400f;
          if (WallID.Sets.AllowsWind[(int) tile.wall] && (double) index < Main.worldSurface)
            ++num2;
          float windGridPush = this.GetWindGridPush(x, index, 20, 0.01f);
          if ((double) windGridPush == 0.0 && (double) num6 != 0.0)
            num5 *= -0.78f;
          else
            num5 -= windGridPush;
          num6 = windGridPush;
          short frameX = tile.frameX;
          short frameY = tile.frameY;
          Color color = Lighting.GetColor(x, index);
          int tileWidth;
          int tileHeight;
          int tileTop;
          int halfBrickHeight;
          int addFrX;
          int addFrY;
          SpriteEffects tileSpriteEffect;
          this.GetTileDrawData(x, index, tile, type, ref frameX, ref frameY, out tileWidth, out tileHeight, out tileTop, out halfBrickHeight, out addFrX, out addFrY, out tileSpriteEffect, out Texture2D _, out Rectangle _, out Color _);
          Vector2 position = new Vector2((float) -(int) screenPosition.X, (float) -(int) screenPosition.Y) + offSet + vector2;
          if (tile.color() == (byte) 31)
            color = Color.White;
          float rotation = (float) num2 * num4 * windCycle + num5;
          Texture2D tileDrawTexture = this.GetTileDrawTexture(tile, x, index);
          if (tileDrawTexture == null)
            break;
          Main.spriteBatch.Draw(tileDrawTexture, position, new Rectangle?(new Rectangle((int) frameX + addFrX, (int) frameY + addFrY, tileWidth, tileHeight - halfBrickHeight)), color, rotation, new Vector2((float) (tileWidth / 2), (float) (halfBrickHeight - tileTop)), 1f, tileSpriteEffect, 0.0f);
          vector2 += (rotation + 1.570796f).ToRotationVector2() * 16f;
        }
      }
    }

    private void DrawRisingVineStrip(Vector2 screenPosition, Vector2 offSet, int x, int startY)
    {
      int num1 = 0;
      int num2 = 0;
      Vector2 vector2 = new Vector2((float) (x * 16 + 8), (float) (startY * 16 + 16 + 2));
      float num3 = MathHelper.Lerp(0.2f, 1f, Math.Abs(Main.WindForVisuals) / 1.2f);
      float num4 = -0.08f * num3;
      float windCycle = this.GetWindCycle(x, startY, this._vineWindCounter);
      float num5 = 0.0f;
      float num6 = 0.0f;
      for (int index = startY; index > 10; --index)
      {
        Tile tile = Main.tile[x, index];
        if (tile != null)
        {
          ushort type = tile.type;
          if (!tile.active() || !TileID.Sets.ReverseVineThreads[(int) type])
            break;
          ++num1;
          if (num2 >= 5)
            num4 += 0.0075f * num3;
          if (num2 >= 2)
            num4 += 1f / 400f;
          if (WallID.Sets.AllowsWind[(int) tile.wall] && (double) index < Main.worldSurface)
            ++num2;
          float windGridPush = this.GetWindGridPush(x, index, 40, -0.004f);
          if ((double) windGridPush == 0.0 && (double) num6 != 0.0)
            num5 *= -0.78f;
          else
            num5 -= windGridPush;
          num6 = windGridPush;
          short frameX = tile.frameX;
          short frameY = tile.frameY;
          Color color = Lighting.GetColor(x, index);
          int tileWidth;
          int tileHeight;
          int tileTop;
          int halfBrickHeight;
          int addFrX;
          int addFrY;
          SpriteEffects tileSpriteEffect;
          this.GetTileDrawData(x, index, tile, type, ref frameX, ref frameY, out tileWidth, out tileHeight, out tileTop, out halfBrickHeight, out addFrX, out addFrY, out tileSpriteEffect, out Texture2D _, out Rectangle _, out Color _);
          Vector2 position = new Vector2((float) -(int) screenPosition.X, (float) -(int) screenPosition.Y) + offSet + vector2;
          float rotation = (float) num2 * -num4 * windCycle + num5;
          Texture2D tileDrawTexture = this.GetTileDrawTexture(tile, x, index);
          if (tileDrawTexture == null)
            break;
          Main.spriteBatch.Draw(tileDrawTexture, position, new Rectangle?(new Rectangle((int) frameX + addFrX, (int) frameY + addFrY, tileWidth, tileHeight - halfBrickHeight)), color, rotation, new Vector2((float) (tileWidth / 2), (float) (halfBrickHeight - tileTop + tileHeight)), 1f, tileSpriteEffect, 0.0f);
          vector2 += (rotation - 1.570796f).ToRotationVector2() * 16f;
        }
      }
    }

    private float GetAverageWindGridPush(
      int topLeftX,
      int topLeftY,
      int sizeX,
      int sizeY,
      int totalPushTime,
      float pushForcePerFrame)
    {
      float num1 = 0.0f;
      int num2 = 0;
      for (int index1 = 0; index1 < sizeX; ++index1)
      {
        for (int index2 = 0; index2 < sizeY; ++index2)
        {
          float windGridPush = this.GetWindGridPush(topLeftX + index1, topLeftY + index2, totalPushTime, pushForcePerFrame);
          if ((double) windGridPush != 0.0)
          {
            num1 += windGridPush;
            ++num2;
          }
        }
      }
      return num2 == 0 ? 0.0f : num1 / (float) num2;
    }

    private float GetHighestWindGridPushComplex(
      int topLeftX,
      int topLeftY,
      int sizeX,
      int sizeY,
      int totalPushTime,
      float pushForcePerFrame,
      int loops,
      bool swapLoopDir)
    {
      float num1 = 0.0f;
      int num2 = int.MaxValue;
      for (int index1 = 0; index1 < 1; ++index1)
      {
        for (int index2 = 0; index2 < sizeY; ++index2)
        {
          int windTimeLeft;
          this._windGrid.GetWindTime(topLeftX + index1 + sizeX / 2, topLeftY + index2, totalPushTime, out windTimeLeft, out int _);
          float windGridPushComplex = this.GetWindGridPushComplex(topLeftX + index1, topLeftY + index2, totalPushTime, pushForcePerFrame, loops, swapLoopDir);
          if (windTimeLeft < num2 && windTimeLeft != 0)
          {
            num1 = windGridPushComplex;
            num2 = windTimeLeft;
          }
        }
      }
      return num1;
    }

    private void DrawMultiTileVinesInWind(
      Vector2 screenPosition,
      Vector2 offSet,
      int topLeftX,
      int topLeftY,
      int sizeX,
      int sizeY)
    {
      float windCycle = this.GetWindCycle(topLeftX, topLeftY, this._sunflowerWindCounter);
      float num1 = windCycle;
      int totalPushTime = 60;
      float pushForcePerFrame = 1.26f;
      float windGridPushComplex = this.GetHighestWindGridPushComplex(topLeftX, topLeftY, sizeX, sizeY, totalPushTime, pushForcePerFrame, 3, true);
      float num2 = windCycle + windGridPushComplex;
      Vector2 vector2_1 = new Vector2((float) (sizeX * 16) * 0.5f, 0.0f);
      Vector2 vector2_2 = new Vector2((float) (topLeftX * 16 - (int) screenPosition.X) + (float) ((double) sizeX * 16.0 * 0.5), (float) (topLeftY * 16 - (int) screenPosition.Y)) + offSet;
      Tile tile1 = Main.tile[topLeftX, topLeftY];
      int type1 = (int) tile1.type;
      Vector2 vector2_3 = new Vector2(0.0f, -2f);
      Vector2 vector2_4 = vector2_2 + vector2_3;
      Texture2D texture = (Texture2D) null;
      Color color = Color.Transparent;
      float? nullable = new float?();
      float num3 = 1f;
      float num4 = -4f;
      bool flag = false;
      float num5 = 0.15f;
      switch (type1)
      {
        case 34:
        case 126:
          nullable = new float?(1f);
          num4 = 0.0f;
          switch ((int) tile1.frameY / 54 + (int) tile1.frameX / 108 * 37)
          {
            case 9:
              nullable = new float?();
              num4 = -1f;
              flag = true;
              num5 *= 0.3f;
              break;
            case 11:
              num5 *= 0.5f;
              break;
            case 12:
              nullable = new float?();
              num4 = -1f;
              break;
            case 18:
              nullable = new float?();
              num4 = -1f;
              break;
            case 21:
              nullable = new float?();
              num4 = -1f;
              break;
            case 23:
              nullable = new float?(0.0f);
              break;
            case 25:
              nullable = new float?();
              num4 = -1f;
              flag = true;
              break;
            case 32:
              num5 *= 0.5f;
              break;
            case 33:
              num5 *= 0.5f;
              break;
            case 35:
              nullable = new float?(0.0f);
              break;
            case 36:
              nullable = new float?();
              num4 = -1f;
              flag = true;
              break;
            case 37:
              nullable = new float?();
              num4 = -1f;
              flag = true;
              num5 *= 0.5f;
              break;
            case 39:
              nullable = new float?();
              num4 = -1f;
              flag = true;
              break;
            case 40:
            case 41:
            case 42:
            case 43:
              nullable = new float?();
              num4 = -2f;
              flag = true;
              num5 *= 0.5f;
              break;
            case 44:
              nullable = new float?();
              num4 = -3f;
              break;
          }
          break;
        case 42:
          nullable = new float?(1f);
          num4 = 0.0f;
          switch ((int) tile1.frameY / 36)
          {
            case 0:
              nullable = new float?();
              num4 = -1f;
              break;
            case 9:
              nullable = new float?(0.0f);
              break;
            case 12:
              nullable = new float?();
              num4 = -1f;
              break;
            case 14:
              nullable = new float?();
              num4 = -1f;
              break;
            case 28:
              nullable = new float?();
              num4 = -1f;
              break;
            case 30:
              nullable = new float?(0.0f);
              break;
            case 32:
              nullable = new float?(0.0f);
              break;
            case 33:
              nullable = new float?(0.0f);
              break;
            case 34:
              nullable = new float?();
              num4 = -1f;
              break;
            case 35:
              nullable = new float?(0.0f);
              break;
            case 38:
              nullable = new float?();
              num4 = -1f;
              break;
            case 39:
              nullable = new float?();
              num4 = -1f;
              flag = true;
              break;
            case 40:
            case 41:
            case 42:
            case 43:
              nullable = new float?(0.0f);
              nullable = new float?();
              num4 = -1f;
              flag = true;
              break;
          }
          break;
        case 95:
        case 270:
        case 271:
        case 444:
        case 454:
        case 572:
        case 581:
          nullable = new float?(1f);
          num4 = 0.0f;
          break;
        case 591:
          num3 = 0.5f;
          num4 = -2f;
          break;
        case 592:
          num3 = 0.5f;
          num4 = -2f;
          texture = TextureAssets.GlowMask[294].Value;
          color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
          break;
      }
      if (flag)
        vector2_4 += new Vector2(0.0f, 16f);
      float num6 = num5 * -1f;
      if (!this.InAPlaceWithWind(topLeftX, topLeftY, sizeX, sizeY))
        num2 -= num1;
      ulong num7 = 0;
      for (int index1 = topLeftX; index1 < topLeftX + sizeX; ++index1)
      {
        for (int index2 = topLeftY; index2 < topLeftY + sizeY; ++index2)
        {
          Tile tile2 = Main.tile[index1, index2];
          ushort type2 = tile2.type;
          if ((int) type2 == type1)
          {
            double num8 = (double) Math.Abs((float) (((double) (index1 - topLeftX) + 0.5) / (double) sizeX - 0.5));
            short frameX = tile2.frameX;
            short frameY = tile2.frameY;
            float num9 = (float) (index2 - topLeftY + 1) / (float) sizeY;
            if ((double) num9 == 0.0)
              num9 = 0.1f;
            if (nullable.HasValue)
              num9 = nullable.Value;
            if (flag && index2 == topLeftY)
              num9 = 0.0f;
            int tileWidth;
            int tileHeight;
            int tileTop;
            int halfBrickHeight;
            int addFrX;
            int addFrY;
            SpriteEffects tileSpriteEffect;
            this.GetTileDrawData(index1, index2, tile2, type2, ref frameX, ref frameY, out tileWidth, out tileHeight, out tileTop, out halfBrickHeight, out addFrX, out addFrY, out tileSpriteEffect, out Texture2D _, out Rectangle _, out Color _);
            bool canDoDust = this._rand.Next(4) == 0;
            Color tileLight = Lighting.GetColor(index1, index2);
            this.DrawAnimatedTile_AdjustForVisionChangers(index1, index2, tile2, type2, frameX, frameY, ref tileLight, canDoDust);
            tileLight = this.DrawTiles_GetLightOverride(index2, index1, tile2, type2, frameX, frameY, tileLight);
            if (this._isActiveAndNotPaused & canDoDust)
              this.DrawTiles_EmitParticles(index2, index1, tile2, type2, frameX, frameY, tileLight);
            Vector2 vector2_5 = new Vector2((float) (index1 * 16 - (int) screenPosition.X), (float) (index2 * 16 - (int) screenPosition.Y + tileTop)) + offSet + vector2_3;
            Vector2 vector2_6 = new Vector2(num2 * num3, Math.Abs(num2) * num4 * num9);
            Vector2 origin = vector2_4 - vector2_5;
            Texture2D tileDrawTexture = this.GetTileDrawTexture(tile2, index1, index2);
            if (tileDrawTexture != null)
            {
              Vector2 position = vector2_4 + new Vector2(0.0f, vector2_6.Y);
              Rectangle rectangle = new Rectangle((int) frameX + addFrX, (int) frameY + addFrY, tileWidth, tileHeight - halfBrickHeight);
              float rotation = num2 * num6 * num9;
              Main.spriteBatch.Draw(tileDrawTexture, position, new Rectangle?(rectangle), tileLight, rotation, origin, 1f, tileSpriteEffect, 0.0f);
              if (texture != null)
                Main.spriteBatch.Draw(texture, position, new Rectangle?(rectangle), color, rotation, origin, 1f, tileSpriteEffect, 0.0f);
              TileDrawing.TileFlameData tileFlameData = this.GetTileFlameData(index1, index2, (int) type2, (int) frameY);
              if (num7 == 0UL)
                num7 = tileFlameData.flameSeed;
              tileFlameData.flameSeed = num7;
              for (int index3 = 0; index3 < tileFlameData.flameCount; ++index3)
              {
                float x = (float) Utils.RandomInt(ref tileFlameData.flameSeed, tileFlameData.flameRangeXMin, tileFlameData.flameRangeXMax) * tileFlameData.flameRangeMultX;
                float y = (float) Utils.RandomInt(ref tileFlameData.flameSeed, tileFlameData.flameRangeYMin, tileFlameData.flameRangeYMax) * tileFlameData.flameRangeMultY;
                Main.spriteBatch.Draw(tileFlameData.flameTexture, position + new Vector2(x, y), new Rectangle?(rectangle), tileFlameData.flameColor, rotation, origin, 1f, tileSpriteEffect, 0.0f);
              }
            }
          }
        }
      }
    }

    private void EmitAlchemyHerbParticles(int j, int i, int style)
    {
      if (style == 0 && this._rand.Next(100) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16 - 4)), 16, 16, 19, Alpha: 160, Scale: 0.1f);
        this._dust[index].velocity.X /= 2f;
        this._dust[index].velocity.Y /= 2f;
        this._dust[index].noGravity = true;
        this._dust[index].fadeIn = 1f;
      }
      if (style == 1 && this._rand.Next(100) == 0)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 41, Alpha: 250, Scale: 0.8f);
      if (style == 3)
      {
        if (this._rand.Next(200) == 0)
          this._dust[Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14, Alpha: 100, Scale: 0.2f)].fadeIn = 1.2f;
        if (this._rand.Next(75) == 0)
        {
          int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 27, Alpha: 100);
          this._dust[index].velocity.X /= 2f;
          this._dust[index].velocity.Y /= 2f;
        }
      }
      if (style == 4 && this._rand.Next(150) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 8, 16);
        this._dust[index].velocity.X /= 3f;
        this._dust[index].velocity.Y /= 3f;
        this._dust[index].velocity.Y -= 0.7f;
        this._dust[index].alpha = 50;
        this._dust[index].scale *= 0.1f;
        this._dust[index].fadeIn = 0.9f;
        this._dust[index].noGravity = true;
      }
      if (style == 5 && this._rand.Next(40) == 0)
      {
        int index = Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16 - 6)), 16, 16, 6, Scale: 1.5f);
        this._dust[index].velocity.Y -= 2f;
        this._dust[index].noGravity = true;
      }
      if (style != 6 || this._rand.Next(30) != 0)
        return;
      Color newColor = new Color(50, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this._dust[Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 43, Alpha: 254, newColor: newColor, Scale: 0.5f)].velocity *= 0.0f;
    }

    private bool IsAlchemyPlantHarvestable(int style) => style == 0 && Main.dayTime || style == 1 && !Main.dayTime || style == 3 && !Main.dayTime && (Main.bloodMoon || Main.moonPhase == 0) || style == 4 && (Main.raining || (double) Main.cloudAlpha > 0.0) || style == 5 && !Main.raining && Main.time > 40500.0;

    private enum TileCounterType
    {
      Tree,
      DisplayDoll,
      HatRack,
      WindyGrass,
      MultiTileGrass,
      MultiTileVine,
      Vine,
      BiomeGrass,
      VoidLens,
      ReverseVine,
      TeleportationPylon,
      MasterTrophy,
      Count,
    }

    private struct TileFlameData
    {
      public Texture2D flameTexture;
      public ulong flameSeed;
      public int flameCount;
      public Color flameColor;
      public int flameRangeXMin;
      public int flameRangeXMax;
      public int flameRangeYMin;
      public int flameRangeYMax;
      public float flameRangeMultX;
      public float flameRangeMultY;
    }
  }
}
