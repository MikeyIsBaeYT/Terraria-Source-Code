// Decompiled with JetBrains decompiler
// Type: Terraria.ObjectData.TileObjectData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Modules;

namespace Terraria.ObjectData
{
  public class TileObjectData
  {
    private TileObjectData _parent;
    private bool _linkedAlternates;
    private bool _usesCustomCanPlace;
    private TileObjectAlternatesModule _alternates;
    private AnchorDataModule _anchor;
    private AnchorTypesModule _anchorTiles;
    private LiquidDeathModule _liquidDeath;
    private LiquidPlacementModule _liquidPlacement;
    private TilePlacementHooksModule _placementHooks;
    private TileObjectSubTilesModule _subTiles;
    private TileObjectDrawModule _tileObjectDraw;
    private TileObjectStyleModule _tileObjectStyle;
    private TileObjectBaseModule _tileObjectBase;
    private TileObjectCoordinatesModule _tileObjectCoords;
    private bool _hasOwnAlternates;
    private bool _hasOwnAnchor;
    private bool _hasOwnAnchorTiles;
    private bool _hasOwnLiquidDeath;
    private bool _hasOwnLiquidPlacement;
    private bool _hasOwnPlacementHooks;
    private bool _hasOwnSubTiles;
    private bool _hasOwnTileObjectBase;
    private bool _hasOwnTileObjectDraw;
    private bool _hasOwnTileObjectStyle;
    private bool _hasOwnTileObjectCoords;
    private static List<TileObjectData> _data;
    private static TileObjectData _baseObject;
    private static bool readOnlyData;
    private static TileObjectData newTile;
    private static TileObjectData newSubTile;
    private static TileObjectData newAlternate;
    private static TileObjectData StyleSwitch;
    private static TileObjectData StyleTorch;
    private static TileObjectData Style4x2;
    private static TileObjectData Style2x2;
    private static TileObjectData Style1x2;
    private static TileObjectData Style1x1;
    private static TileObjectData StyleAlch;
    private static TileObjectData StyleDye;
    private static TileObjectData Style2x1;
    private static TileObjectData Style6x3;
    private static TileObjectData StyleSmallCage;
    private static TileObjectData StyleOnTable1x1;
    private static TileObjectData Style1x2Top;
    private static TileObjectData Style1xX;
    private static TileObjectData Style2xX;
    private static TileObjectData Style3x2;
    private static TileObjectData Style3x3;
    private static TileObjectData Style3x4;
    private static TileObjectData Style5x4;
    private static TileObjectData Style3x3Wall;

    public TileObjectData(TileObjectData copyFrom = null)
    {
      this._parent = (TileObjectData) null;
      this._linkedAlternates = false;
      if (copyFrom == null)
      {
        this._usesCustomCanPlace = false;
        this._alternates = (TileObjectAlternatesModule) null;
        this._anchor = (AnchorDataModule) null;
        this._anchorTiles = (AnchorTypesModule) null;
        this._tileObjectBase = (TileObjectBaseModule) null;
        this._liquidDeath = (LiquidDeathModule) null;
        this._liquidPlacement = (LiquidPlacementModule) null;
        this._placementHooks = (TilePlacementHooksModule) null;
        this._tileObjectDraw = (TileObjectDrawModule) null;
        this._tileObjectStyle = (TileObjectStyleModule) null;
        this._tileObjectCoords = (TileObjectCoordinatesModule) null;
      }
      else
        this.CopyFrom(copyFrom);
    }

    public void CopyFrom(TileObjectData copy)
    {
      if (copy == null)
        return;
      this._usesCustomCanPlace = copy._usesCustomCanPlace;
      this._alternates = copy._alternates;
      this._anchor = copy._anchor;
      this._anchorTiles = copy._anchorTiles;
      this._tileObjectBase = copy._tileObjectBase;
      this._liquidDeath = copy._liquidDeath;
      this._liquidPlacement = copy._liquidPlacement;
      this._placementHooks = copy._placementHooks;
      this._tileObjectDraw = copy._tileObjectDraw;
      this._tileObjectStyle = copy._tileObjectStyle;
      this._tileObjectCoords = copy._tileObjectCoords;
    }

    public void FullCopyFrom(ushort tileType) => this.FullCopyFrom(TileObjectData.GetTileData((int) tileType, 0));

    public void FullCopyFrom(TileObjectData copy)
    {
      if (copy == null)
        return;
      this._usesCustomCanPlace = copy._usesCustomCanPlace;
      this._alternates = copy._alternates;
      this._anchor = copy._anchor;
      this._anchorTiles = copy._anchorTiles;
      this._tileObjectBase = copy._tileObjectBase;
      this._liquidDeath = copy._liquidDeath;
      this._liquidPlacement = copy._liquidPlacement;
      this._placementHooks = copy._placementHooks;
      this._tileObjectDraw = copy._tileObjectDraw;
      this._tileObjectStyle = copy._tileObjectStyle;
      this._tileObjectCoords = copy._tileObjectCoords;
      this._subTiles = new TileObjectSubTilesModule(copy._subTiles);
      this._hasOwnSubTiles = true;
    }

    private void SetupBaseObject()
    {
      this._alternates = new TileObjectAlternatesModule();
      this._hasOwnAlternates = true;
      this.Alternates = new List<TileObjectData>();
      this._anchor = new AnchorDataModule();
      this._hasOwnAnchor = true;
      this.AnchorTop = new AnchorData();
      this.AnchorBottom = new AnchorData();
      this.AnchorLeft = new AnchorData();
      this.AnchorRight = new AnchorData();
      this.AnchorWall = false;
      this._anchorTiles = new AnchorTypesModule();
      this._hasOwnAnchorTiles = true;
      this.AnchorValidTiles = (int[]) null;
      this.AnchorInvalidTiles = (int[]) null;
      this.AnchorAlternateTiles = (int[]) null;
      this.AnchorValidWalls = (int[]) null;
      this._liquidDeath = new LiquidDeathModule();
      this._hasOwnLiquidDeath = true;
      this.WaterDeath = false;
      this.LavaDeath = false;
      this._liquidPlacement = new LiquidPlacementModule();
      this._hasOwnLiquidPlacement = true;
      this.WaterPlacement = LiquidPlacement.Allowed;
      this.LavaPlacement = LiquidPlacement.NotAllowed;
      this._placementHooks = new TilePlacementHooksModule();
      this._hasOwnPlacementHooks = true;
      this.HookCheckIfCanPlace = new PlacementHook();
      this.HookPostPlaceEveryone = new PlacementHook();
      this.HookPostPlaceMyPlayer = new PlacementHook();
      this.HookPlaceOverride = new PlacementHook();
      this.SubTiles = new List<TileObjectData>(623);
      this._tileObjectBase = new TileObjectBaseModule();
      this._hasOwnTileObjectBase = true;
      this.Width = 1;
      this.Height = 1;
      this.Origin = Point16.Zero;
      this.Direction = TileObjectDirection.None;
      this.RandomStyleRange = 0;
      this.FlattenAnchors = false;
      this._tileObjectCoords = new TileObjectCoordinatesModule();
      this._hasOwnTileObjectCoords = true;
      this.CoordinateHeights = new int[1]{ 16 };
      this.CoordinateWidth = 0;
      this.CoordinatePadding = 0;
      this.CoordinatePaddingFix = Point16.Zero;
      this._tileObjectDraw = new TileObjectDrawModule();
      this._hasOwnTileObjectDraw = true;
      this.DrawYOffset = 0;
      this.DrawFlipHorizontal = false;
      this.DrawFlipVertical = false;
      this.DrawStepDown = 0;
      this._tileObjectStyle = new TileObjectStyleModule();
      this._hasOwnTileObjectStyle = true;
      this.Style = 0;
      this.StyleHorizontal = false;
      this.StyleWrapLimit = 0;
      this.StyleMultiplier = 1;
    }

    private void Calculate()
    {
      if (this._tileObjectCoords.calculated)
        return;
      this._tileObjectCoords.calculated = true;
      this._tileObjectCoords.styleWidth = (this._tileObjectCoords.width + this._tileObjectCoords.padding) * this.Width + (int) this._tileObjectCoords.paddingFix.X;
      int num = 0;
      this._tileObjectCoords.styleHeight = 0;
      for (int index = 0; index < this._tileObjectCoords.heights.Length; ++index)
        num += this._tileObjectCoords.heights[index] + this._tileObjectCoords.padding;
      this._tileObjectCoords.styleHeight = num + (int) this._tileObjectCoords.paddingFix.Y;
      if (!this._hasOwnLiquidDeath)
        return;
      if (this._liquidDeath.lava)
        this.LavaPlacement = LiquidPlacement.NotAllowed;
      if (!this._liquidDeath.water)
        return;
      this.WaterPlacement = LiquidPlacement.NotAllowed;
    }

    private void WriteCheck()
    {
      if (TileObjectData.readOnlyData)
        throw new FieldAccessException("Tile data is locked and only accessible during startup.");
    }

    private void LockWrites() => TileObjectData.readOnlyData = true;

    private bool LinkedAlternates
    {
      get => this._linkedAlternates;
      set
      {
        this.WriteCheck();
        if (value && !this._hasOwnAlternates)
        {
          this._hasOwnAlternates = true;
          this._alternates = new TileObjectAlternatesModule(this._alternates);
        }
        this._linkedAlternates = value;
      }
    }

    public bool UsesCustomCanPlace
    {
      get => this._usesCustomCanPlace;
      set
      {
        this.WriteCheck();
        this._usesCustomCanPlace = value;
      }
    }

    private List<TileObjectData> Alternates
    {
      get => this._alternates == null ? TileObjectData._baseObject.Alternates : this._alternates.data;
      set
      {
        if (!this._hasOwnAlternates)
        {
          this._hasOwnAlternates = true;
          this._alternates = new TileObjectAlternatesModule(this._alternates);
        }
        this._alternates.data = value;
      }
    }

    public AnchorData AnchorTop
    {
      get => this._anchor == null ? TileObjectData._baseObject.AnchorTop : this._anchor.top;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchor)
        {
          if (this._anchor.top == value)
            return;
          this._hasOwnAnchor = true;
          this._anchor = new AnchorDataModule(this._anchor);
        }
        this._anchor.top = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].AnchorTop = value;
      }
    }

    public AnchorData AnchorBottom
    {
      get => this._anchor == null ? TileObjectData._baseObject.AnchorBottom : this._anchor.bottom;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchor)
        {
          if (this._anchor.bottom == value)
            return;
          this._hasOwnAnchor = true;
          this._anchor = new AnchorDataModule(this._anchor);
        }
        this._anchor.bottom = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].AnchorBottom = value;
      }
    }

    public AnchorData AnchorLeft
    {
      get => this._anchor == null ? TileObjectData._baseObject.AnchorLeft : this._anchor.left;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchor)
        {
          if (this._anchor.left == value)
            return;
          this._hasOwnAnchor = true;
          this._anchor = new AnchorDataModule(this._anchor);
        }
        this._anchor.left = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].AnchorLeft = value;
      }
    }

    public AnchorData AnchorRight
    {
      get => this._anchor == null ? TileObjectData._baseObject.AnchorRight : this._anchor.right;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchor)
        {
          if (this._anchor.right == value)
            return;
          this._hasOwnAnchor = true;
          this._anchor = new AnchorDataModule(this._anchor);
        }
        this._anchor.right = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].AnchorRight = value;
      }
    }

    public bool AnchorWall
    {
      get => this._anchor == null ? TileObjectData._baseObject.AnchorWall : this._anchor.wall;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchor)
        {
          if (this._anchor.wall == value)
            return;
          this._hasOwnAnchor = true;
          this._anchor = new AnchorDataModule(this._anchor);
        }
        this._anchor.wall = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].AnchorWall = value;
      }
    }

    public int[] AnchorValidTiles
    {
      get => this._anchorTiles == null ? TileObjectData._baseObject.AnchorValidTiles : this._anchorTiles.tileValid;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchorTiles)
        {
          if (value.deepCompare(this._anchorTiles.tileValid))
            return;
          this._hasOwnAnchorTiles = true;
          this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
        }
        this._anchorTiles.tileValid = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
        {
          int[] numArray = value;
          if (value != null)
            numArray = (int[]) value.Clone();
          this._alternates.data[index].AnchorValidTiles = numArray;
        }
      }
    }

    public int[] AnchorInvalidTiles
    {
      get => this._anchorTiles == null ? TileObjectData._baseObject.AnchorInvalidTiles : this._anchorTiles.tileInvalid;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchorTiles)
        {
          if (value.deepCompare(this._anchorTiles.tileInvalid))
            return;
          this._hasOwnAnchorTiles = true;
          this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
        }
        this._anchorTiles.tileInvalid = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
        {
          int[] numArray = value;
          if (value != null)
            numArray = (int[]) value.Clone();
          this._alternates.data[index].AnchorInvalidTiles = numArray;
        }
      }
    }

    public int[] AnchorAlternateTiles
    {
      get => this._anchorTiles == null ? TileObjectData._baseObject.AnchorAlternateTiles : this._anchorTiles.tileAlternates;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchorTiles)
        {
          if (value.deepCompare(this._anchorTiles.tileInvalid))
            return;
          this._hasOwnAnchorTiles = true;
          this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
        }
        this._anchorTiles.tileAlternates = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
        {
          int[] numArray = value;
          if (value != null)
            numArray = (int[]) value.Clone();
          this._alternates.data[index].AnchorAlternateTiles = numArray;
        }
      }
    }

    public int[] AnchorValidWalls
    {
      get => this._anchorTiles == null ? TileObjectData._baseObject.AnchorValidWalls : this._anchorTiles.wallValid;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnAnchorTiles)
        {
          this._hasOwnAnchorTiles = true;
          this._anchorTiles = new AnchorTypesModule(this._anchorTiles);
        }
        this._anchorTiles.wallValid = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
        {
          int[] numArray = value;
          if (value != null)
            numArray = (int[]) value.Clone();
          this._alternates.data[index].AnchorValidWalls = numArray;
        }
      }
    }

    public bool WaterDeath
    {
      get => this._liquidDeath == null ? TileObjectData._baseObject.WaterDeath : this._liquidDeath.water;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnLiquidDeath)
        {
          if (this._liquidDeath.water == value)
            return;
          this._hasOwnLiquidDeath = true;
          this._liquidDeath = new LiquidDeathModule(this._liquidDeath);
        }
        this._liquidDeath.water = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].WaterDeath = value;
      }
    }

    public bool LavaDeath
    {
      get => this._liquidDeath == null ? TileObjectData._baseObject.LavaDeath : this._liquidDeath.lava;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnLiquidDeath)
        {
          if (this._liquidDeath.lava == value)
            return;
          this._hasOwnLiquidDeath = true;
          this._liquidDeath = new LiquidDeathModule(this._liquidDeath);
        }
        this._liquidDeath.lava = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].LavaDeath = value;
      }
    }

    public LiquidPlacement WaterPlacement
    {
      get => this._liquidPlacement == null ? TileObjectData._baseObject.WaterPlacement : this._liquidPlacement.water;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnLiquidPlacement)
        {
          if (this._liquidPlacement.water == value)
            return;
          this._hasOwnLiquidPlacement = true;
          this._liquidPlacement = new LiquidPlacementModule(this._liquidPlacement);
        }
        this._liquidPlacement.water = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].WaterPlacement = value;
      }
    }

    public LiquidPlacement LavaPlacement
    {
      get => this._liquidPlacement == null ? TileObjectData._baseObject.LavaPlacement : this._liquidPlacement.lava;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnLiquidPlacement)
        {
          if (this._liquidPlacement.lava == value)
            return;
          this._hasOwnLiquidPlacement = true;
          this._liquidPlacement = new LiquidPlacementModule(this._liquidPlacement);
        }
        this._liquidPlacement.lava = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].LavaPlacement = value;
      }
    }

    public PlacementHook HookCheckIfCanPlace
    {
      get => this._placementHooks == null ? TileObjectData._baseObject.HookCheckIfCanPlace : this._placementHooks.check;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnPlacementHooks)
        {
          this._hasOwnPlacementHooks = true;
          this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
        }
        this._placementHooks.check = value;
      }
    }

    public PlacementHook HookPostPlaceEveryone
    {
      get => this._placementHooks == null ? TileObjectData._baseObject.HookPostPlaceEveryone : this._placementHooks.postPlaceEveryone;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnPlacementHooks)
        {
          this._hasOwnPlacementHooks = true;
          this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
        }
        this._placementHooks.postPlaceEveryone = value;
      }
    }

    public PlacementHook HookPostPlaceMyPlayer
    {
      get => this._placementHooks == null ? TileObjectData._baseObject.HookPostPlaceMyPlayer : this._placementHooks.postPlaceMyPlayer;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnPlacementHooks)
        {
          this._hasOwnPlacementHooks = true;
          this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
        }
        this._placementHooks.postPlaceMyPlayer = value;
      }
    }

    public PlacementHook HookPlaceOverride
    {
      get => this._placementHooks == null ? TileObjectData._baseObject.HookPlaceOverride : this._placementHooks.placeOverride;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnPlacementHooks)
        {
          this._hasOwnPlacementHooks = true;
          this._placementHooks = new TilePlacementHooksModule(this._placementHooks);
        }
        this._placementHooks.placeOverride = value;
      }
    }

    private List<TileObjectData> SubTiles
    {
      get => this._subTiles == null ? TileObjectData._baseObject.SubTiles : this._subTiles.data;
      set
      {
        if (!this._hasOwnSubTiles)
        {
          this._hasOwnSubTiles = true;
          this._subTiles = new TileObjectSubTilesModule();
        }
        if (value == null)
          this._subTiles.data = (List<TileObjectData>) null;
        else
          this._subTiles.data = value;
      }
    }

    public int DrawYOffset
    {
      get => this._tileObjectDraw == null ? this.DrawYOffset : this._tileObjectDraw.yOffset;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectDraw)
        {
          if (this._tileObjectDraw.yOffset == value)
            return;
          this._hasOwnTileObjectDraw = true;
          this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
        }
        this._tileObjectDraw.yOffset = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].DrawYOffset = value;
      }
    }

    public int DrawXOffset
    {
      get => this._tileObjectDraw == null ? this.DrawXOffset : this._tileObjectDraw.xOffset;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectDraw)
        {
          if (this._tileObjectDraw.xOffset == value)
            return;
          this._hasOwnTileObjectDraw = true;
          this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
        }
        this._tileObjectDraw.xOffset = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].DrawXOffset = value;
      }
    }

    public bool DrawFlipHorizontal
    {
      get => this._tileObjectDraw == null ? this.DrawFlipHorizontal : this._tileObjectDraw.flipHorizontal;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectDraw)
        {
          if (this._tileObjectDraw.flipHorizontal == value)
            return;
          this._hasOwnTileObjectDraw = true;
          this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
        }
        this._tileObjectDraw.flipHorizontal = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].DrawFlipHorizontal = value;
      }
    }

    public bool DrawFlipVertical
    {
      get => this._tileObjectDraw == null ? this.DrawFlipVertical : this._tileObjectDraw.flipVertical;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectDraw)
        {
          if (this._tileObjectDraw.flipVertical == value)
            return;
          this._hasOwnTileObjectDraw = true;
          this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
        }
        this._tileObjectDraw.flipVertical = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].DrawFlipVertical = value;
      }
    }

    public int DrawStepDown
    {
      get => this._tileObjectDraw == null ? this.DrawStepDown : this._tileObjectDraw.stepDown;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectDraw)
        {
          if (this._tileObjectDraw.stepDown == value)
            return;
          this._hasOwnTileObjectDraw = true;
          this._tileObjectDraw = new TileObjectDrawModule(this._tileObjectDraw);
        }
        this._tileObjectDraw.stepDown = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].DrawStepDown = value;
      }
    }

    public bool StyleHorizontal
    {
      get => this._tileObjectStyle == null ? this.StyleHorizontal : this._tileObjectStyle.horizontal;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          if (this._tileObjectStyle.horizontal == value)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.horizontal = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].StyleHorizontal = value;
      }
    }

    public int Style
    {
      get => this._tileObjectStyle == null ? TileObjectData._baseObject.Style : this._tileObjectStyle.style;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          if (this._tileObjectStyle.style == value)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.style = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].Style = value;
      }
    }

    public int StyleWrapLimit
    {
      get => this._tileObjectStyle == null ? TileObjectData._baseObject.StyleWrapLimit : this._tileObjectStyle.styleWrapLimit;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          if (this._tileObjectStyle.styleWrapLimit == value)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.styleWrapLimit = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].StyleWrapLimit = value;
      }
    }

    public int? StyleWrapLimitVisualOverride
    {
      get => this._tileObjectStyle == null ? TileObjectData._baseObject.StyleWrapLimitVisualOverride : this._tileObjectStyle.styleWrapLimitVisualOverride;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          int? limitVisualOverride = this._tileObjectStyle.styleWrapLimitVisualOverride;
          int? nullable = value;
          if (limitVisualOverride.GetValueOrDefault() == nullable.GetValueOrDefault() & limitVisualOverride.HasValue == nullable.HasValue)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.styleWrapLimitVisualOverride = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].StyleWrapLimitVisualOverride = value;
      }
    }

    public int? styleLineSkipVisualOverride
    {
      get => this._tileObjectStyle == null ? TileObjectData._baseObject.styleLineSkipVisualOverride : this._tileObjectStyle.styleLineSkipVisualoverride;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          int? skipVisualoverride = this._tileObjectStyle.styleLineSkipVisualoverride;
          int? nullable = value;
          if (skipVisualoverride.GetValueOrDefault() == nullable.GetValueOrDefault() & skipVisualoverride.HasValue == nullable.HasValue)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.styleLineSkipVisualoverride = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].styleLineSkipVisualOverride = value;
      }
    }

    public int StyleLineSkip
    {
      get => this._tileObjectStyle == null ? TileObjectData._baseObject.StyleLineSkip : this._tileObjectStyle.styleLineSkip;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          if (this._tileObjectStyle.styleLineSkip == value)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.styleLineSkip = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].StyleLineSkip = value;
      }
    }

    public int StyleMultiplier
    {
      get => this._tileObjectStyle == null ? TileObjectData._baseObject.StyleMultiplier : this._tileObjectStyle.styleMultiplier;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectStyle)
        {
          if (this._tileObjectStyle.styleMultiplier == value)
            return;
          this._hasOwnTileObjectStyle = true;
          this._tileObjectStyle = new TileObjectStyleModule(this._tileObjectStyle);
        }
        this._tileObjectStyle.styleMultiplier = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].StyleMultiplier = value;
      }
    }

    public int Width
    {
      get => this._tileObjectBase == null ? TileObjectData._baseObject.Width : this._tileObjectBase.width;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectBase)
        {
          if (this._tileObjectBase.width == value)
            return;
          this._hasOwnTileObjectBase = true;
          this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
          if (!this._hasOwnTileObjectCoords)
          {
            this._hasOwnTileObjectCoords = true;
            this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords);
            this._tileObjectCoords.calculated = false;
          }
        }
        this._tileObjectBase.width = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].Width = value;
      }
    }

    public int Height
    {
      get => this._tileObjectBase == null ? TileObjectData._baseObject.Height : this._tileObjectBase.height;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectBase)
        {
          if (this._tileObjectBase.height == value)
            return;
          this._hasOwnTileObjectBase = true;
          this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
          if (!this._hasOwnTileObjectCoords)
          {
            this._hasOwnTileObjectCoords = true;
            this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords);
            this._tileObjectCoords.calculated = false;
          }
        }
        this._tileObjectBase.height = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].Height = value;
      }
    }

    public Point16 Origin
    {
      get => this._tileObjectBase == null ? TileObjectData._baseObject.Origin : this._tileObjectBase.origin;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectBase)
        {
          if (this._tileObjectBase.origin == value)
            return;
          this._hasOwnTileObjectBase = true;
          this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
        }
        this._tileObjectBase.origin = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].Origin = value;
      }
    }

    public TileObjectDirection Direction
    {
      get => this._tileObjectBase == null ? TileObjectData._baseObject.Direction : this._tileObjectBase.direction;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectBase)
        {
          if (this._tileObjectBase.direction == value)
            return;
          this._hasOwnTileObjectBase = true;
          this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
        }
        this._tileObjectBase.direction = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].Direction = value;
      }
    }

    public int RandomStyleRange
    {
      get => this._tileObjectBase == null ? TileObjectData._baseObject.RandomStyleRange : this._tileObjectBase.randomRange;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectBase)
        {
          if (this._tileObjectBase.randomRange == value)
            return;
          this._hasOwnTileObjectBase = true;
          this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
        }
        this._tileObjectBase.randomRange = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].RandomStyleRange = value;
      }
    }

    public bool FlattenAnchors
    {
      get => this._tileObjectBase == null ? TileObjectData._baseObject.FlattenAnchors : this._tileObjectBase.flattenAnchors;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectBase)
        {
          if (this._tileObjectBase.flattenAnchors == value)
            return;
          this._hasOwnTileObjectBase = true;
          this._tileObjectBase = new TileObjectBaseModule(this._tileObjectBase);
        }
        this._tileObjectBase.flattenAnchors = value;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].FlattenAnchors = value;
      }
    }

    public int[] CoordinateHeights
    {
      get => this._tileObjectCoords == null ? TileObjectData._baseObject.CoordinateHeights : this._tileObjectCoords.heights;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectCoords)
        {
          if (value.deepCompare(this._tileObjectCoords.heights))
            return;
          this._hasOwnTileObjectCoords = true;
          this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords, value);
        }
        else
          this._tileObjectCoords.heights = value;
        this._tileObjectCoords.calculated = false;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
        {
          int[] numArray = value;
          if (value != null)
            numArray = (int[]) value.Clone();
          this._alternates.data[index].CoordinateHeights = numArray;
        }
      }
    }

    public int CoordinateWidth
    {
      get => this._tileObjectCoords == null ? TileObjectData._baseObject.CoordinateWidth : this._tileObjectCoords.width;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectCoords)
        {
          if (this._tileObjectCoords.width == value)
            return;
          this._hasOwnTileObjectCoords = true;
          this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords);
        }
        this._tileObjectCoords.width = value;
        this._tileObjectCoords.calculated = false;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].CoordinateWidth = value;
      }
    }

    public int CoordinatePadding
    {
      get => this._tileObjectCoords == null ? TileObjectData._baseObject.CoordinatePadding : this._tileObjectCoords.padding;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectCoords)
        {
          if (this._tileObjectCoords.padding == value)
            return;
          this._hasOwnTileObjectCoords = true;
          this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords);
        }
        this._tileObjectCoords.padding = value;
        this._tileObjectCoords.calculated = false;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].CoordinatePadding = value;
      }
    }

    public Point16 CoordinatePaddingFix
    {
      get => this._tileObjectCoords == null ? TileObjectData._baseObject.CoordinatePaddingFix : this._tileObjectCoords.paddingFix;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectCoords)
        {
          if (this._tileObjectCoords.paddingFix == value)
            return;
          this._hasOwnTileObjectCoords = true;
          this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords);
        }
        this._tileObjectCoords.paddingFix = value;
        this._tileObjectCoords.calculated = false;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].CoordinatePaddingFix = value;
      }
    }

    public int CoordinateFullWidth
    {
      get
      {
        if (this._tileObjectCoords == null)
          return TileObjectData._baseObject.CoordinateFullWidth;
        if (!this._tileObjectCoords.calculated)
          this.Calculate();
        return this._tileObjectCoords.styleWidth;
      }
    }

    public int CoordinateFullHeight
    {
      get
      {
        if (this._tileObjectCoords == null)
          return TileObjectData._baseObject.CoordinateFullHeight;
        if (!this._tileObjectCoords.calculated)
          this.Calculate();
        return this._tileObjectCoords.styleHeight;
      }
    }

    public int DrawStyleOffset
    {
      get => this._tileObjectCoords == null ? TileObjectData._baseObject.DrawStyleOffset : this._tileObjectCoords.drawStyleOffset;
      set
      {
        this.WriteCheck();
        if (!this._hasOwnTileObjectCoords)
        {
          if (this._tileObjectCoords.drawStyleOffset == value)
            return;
          this._hasOwnTileObjectCoords = true;
          this._tileObjectCoords = new TileObjectCoordinatesModule(this._tileObjectCoords);
        }
        this._tileObjectCoords.drawStyleOffset = value;
        this._tileObjectCoords.calculated = false;
        if (!this._linkedAlternates)
          return;
        for (int index = 0; index < this._alternates.data.Count; ++index)
          this._alternates.data[index].DrawStyleOffset = value;
      }
    }

    public bool LiquidPlace(Tile checkTile)
    {
      if (checkTile == null)
        return false;
      if (checkTile.liquid > (byte) 0)
      {
        switch (checkTile.liquidType())
        {
          case 0:
          case 2:
            if (this.WaterPlacement == LiquidPlacement.NotAllowed || this.WaterPlacement == LiquidPlacement.OnlyInFullLiquid && checkTile.liquid != byte.MaxValue)
              return false;
            break;
          case 1:
            if (this.LavaPlacement == LiquidPlacement.NotAllowed || this.LavaPlacement == LiquidPlacement.OnlyInFullLiquid && checkTile.liquid != byte.MaxValue)
              return false;
            break;
        }
      }
      else
      {
        switch (checkTile.liquidType())
        {
          case 0:
          case 2:
            if (this.WaterPlacement == LiquidPlacement.OnlyInFullLiquid || this.WaterPlacement == LiquidPlacement.OnlyInLiquid)
              return false;
            break;
          case 1:
            if (this.LavaPlacement == LiquidPlacement.OnlyInFullLiquid || this.LavaPlacement == LiquidPlacement.OnlyInLiquid)
              return false;
            break;
        }
      }
      return true;
    }

    public int AlternatesCount => this.Alternates.Count;

    public bool isValidTileAnchor(int type)
    {
      int[] numArray1;
      int[] numArray2;
      if (this._anchorTiles == null)
      {
        numArray1 = (int[]) null;
        numArray2 = (int[]) null;
      }
      else
      {
        numArray1 = this._anchorTiles.tileValid;
        numArray2 = this._anchorTiles.tileInvalid;
      }
      if (numArray2 != null)
      {
        for (int index = 0; index < numArray2.Length; ++index)
        {
          if (type == numArray2[index])
            return false;
        }
      }
      if (numArray1 == null)
        return true;
      for (int index = 0; index < numArray1.Length; ++index)
      {
        if (type == numArray1[index])
          return true;
      }
      return false;
    }

    public bool isValidWallAnchor(int type)
    {
      int[] numArray = this._anchorTiles != null ? this._anchorTiles.wallValid : (int[]) null;
      if (numArray == null)
        return type != 0;
      for (int index = 0; index < numArray.Length; ++index)
      {
        if (type == numArray[index])
          return true;
      }
      return false;
    }

    public bool isValidAlternateAnchor(int type)
    {
      if (this._anchorTiles == null)
        return false;
      int[] tileAlternates = this._anchorTiles.tileAlternates;
      if (tileAlternates == null)
        return false;
      for (int index = 0; index < tileAlternates.Length; ++index)
      {
        if (type == tileAlternates[index])
          return true;
      }
      return false;
    }

    public int CalculatePlacementStyle(int style, int alternate, int random)
    {
      int num = style * this.StyleMultiplier + this.Style;
      if (random >= 0)
        num += random;
      return num;
    }

    private static void addBaseTile(out TileObjectData baseTile)
    {
      TileObjectData.newTile.Calculate();
      baseTile = TileObjectData.newTile;
      baseTile._parent = TileObjectData._baseObject;
      TileObjectData.newTile = new TileObjectData(TileObjectData._baseObject);
    }

    private static void addTile(int tileType)
    {
      TileObjectData.newTile.Calculate();
      TileObjectData._data[tileType] = TileObjectData.newTile;
      TileObjectData.newTile = new TileObjectData(TileObjectData._baseObject);
    }

    private static void addSubTile(int style)
    {
      TileObjectData.newSubTile.Calculate();
      List<TileObjectData> tileObjectDataList;
      if (!TileObjectData.newTile._hasOwnSubTiles)
      {
        tileObjectDataList = new List<TileObjectData>(style + 1);
        TileObjectData.newTile.SubTiles = tileObjectDataList;
      }
      else
        tileObjectDataList = TileObjectData.newTile.SubTiles;
      if (tileObjectDataList.Count <= style)
      {
        for (int count = tileObjectDataList.Count; count <= style; ++count)
          tileObjectDataList.Add((TileObjectData) null);
      }
      TileObjectData.newSubTile._parent = TileObjectData.newTile;
      tileObjectDataList[style] = TileObjectData.newSubTile;
      TileObjectData.newSubTile = new TileObjectData(TileObjectData._baseObject);
    }

    private static void addAlternate(int baseStyle)
    {
      TileObjectData.newAlternate.Calculate();
      if (!TileObjectData.newTile._hasOwnAlternates)
        TileObjectData.newTile.Alternates = new List<TileObjectData>();
      TileObjectData.newAlternate.Style = baseStyle;
      TileObjectData.newAlternate._parent = TileObjectData.newTile;
      TileObjectData.newTile.Alternates.Add(TileObjectData.newAlternate);
      TileObjectData.newAlternate = new TileObjectData(TileObjectData._baseObject);
    }

    public static void Initialize()
    {
      TileObjectData._baseObject = new TileObjectData();
      TileObjectData._baseObject.SetupBaseObject();
      TileObjectData._data = new List<TileObjectData>(623);
      for (int index = 0; index < 623; ++index)
        TileObjectData._data.Add((TileObjectData) null);
      TileObjectData.newTile = new TileObjectData(TileObjectData._baseObject);
      TileObjectData.newSubTile = new TileObjectData(TileObjectData._baseObject);
      TileObjectData.newAlternate = new TileObjectData(TileObjectData._baseObject);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.StyleMultiplier = 27;
      TileObjectData.newTile.StyleWrapLimit = 27;
      TileObjectData.newTile.UsesCustomCanPlace = false;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(13);
      TileObjectData.addTile(19);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.StyleMultiplier = 27;
      TileObjectData.newTile.StyleWrapLimit = 27;
      TileObjectData.newTile.UsesCustomCanPlace = false;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addTile(427);
      for (int tileType = 435; tileType <= 439; ++tileType)
      {
        TileObjectData.newTile.CoordinateHeights = new int[1]
        {
          16
        };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleMultiplier = 27;
        TileObjectData.newTile.StyleWrapLimit = 27;
        TileObjectData.newTile.UsesCustomCanPlace = false;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.addTile(tileType);
      }
      TileObjectData.newTile.Width = 4;
      TileObjectData.newTile.Height = 8;
      TileObjectData.newTile.Origin = new Point16(1, 7);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.HookPlaceOverride = new PlacementHook(new Func<int, int, int, int, int, int, int>(WorldGen.PlaceXmasTree_Direct), -1, 0, true);
      TileObjectData.newTile.CoordinateHeights = new int[8]
      {
        16,
        16,
        16,
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 0;
      TileObjectData.addTile(171);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.EmptyTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        38
      };
      TileObjectData.newTile.CoordinateWidth = 32;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.DrawYOffset = -20;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.addBaseTile(out TileObjectData.StyleDye);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newSubTile.AnchorValidWalls = new int[1];
      TileObjectData.addSubTile(3);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newSubTile.AnchorValidWalls = new int[1];
      TileObjectData.addSubTile(4);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.OnlyInFullLiquid;
      TileObjectData.addSubTile(5);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newSubTile.AnchorValidTiles = new int[1]
      {
        80
      };
      TileObjectData.newSubTile.AnchorLeft = new AnchorData(AnchorType.EmptyTile, 1, 1);
      TileObjectData.newSubTile.AnchorRight = new AnchorData(AnchorType.EmptyTile, 1, 1);
      TileObjectData.addSubTile(6);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newSubTile.DrawYOffset = -6;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.newSubTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newSubTile.Width, 0);
      TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.EmptyTile, TileObjectData.newSubTile.Width, 0);
      TileObjectData.addSubTile(7);
      TileObjectData.addTile(227);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleDye);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.CoordinateWidth = 20;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.newTile.AnchorTop = AnchorData.Empty;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = false;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(579);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = false;
      TileObjectData.newTile.StyleWrapLimit = 36;
      TileObjectData.newTile.StyleLineSkip = 3;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 1);
      TileObjectData.addAlternate(0);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 2);
      TileObjectData.addAlternate(0);
      TileObjectData.addTile(10);
      TileObjectData.newTile.Width = 2;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 1);
      TileObjectData.addAlternate(0);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 2);
      TileObjectData.addAlternate(0);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 1);
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 2);
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.addAlternate(1);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(19);
      TileObjectData.addTile(11);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 5;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.newTile.CoordinateHeights = new int[5]
      {
        18,
        16,
        16,
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.StyleWrapLimit = 2;
      for (int Y = 1; Y < 5; ++Y)
      {
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, Y);
        TileObjectData.addAlternate(0);
      }
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      for (int Y = 1; Y < 5; ++Y)
      {
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, Y);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(1);
      }
      TileObjectData.addTile(388);
      TileObjectData.newTile.FullCopyFrom((ushort) 388);
      TileObjectData.addTile(389);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.addBaseTile(out TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(13);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.DrawYOffset = -4;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(25);
      TileObjectData.addTile(33);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.DrawYOffset = -4;
      TileObjectData.addTile(49);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TEFoodPlatter.Hook_AfterPlacement), -1, 0, true);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(520);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.DrawYOffset = -4;
      TileObjectData.addTile(372);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.RandomStyleRange = 5;
      TileObjectData.addTile(50);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(494);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(78);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.DrawYOffset = -4;
      TileObjectData.addTile(174);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.addBaseTile(out TileObjectData.Style1xX);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(37);
      TileObjectData.newTile.StyleLineSkip = 2;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.WaterDeath = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(23);
      TileObjectData.addTile(93);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
      TileObjectData.newTile.Height = 6;
      TileObjectData.newTile.Origin = new Point16(0, 5);
      TileObjectData.newTile.CoordinateHeights = new int[6]
      {
        16,
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.addTile(92);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(453);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style1x2Top);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(270);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(271);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(581);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.newTile.StyleWrapLimit = 6;
      TileObjectData.addTile(572);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(32);
      TileObjectData.addTile(42);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.StyleWrapLimit = 111;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(91);
      TileObjectData.newTile.Width = 4;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(1, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(487);
      TileObjectData.newTile.Width = 4;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(1, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addBaseTile(out TileObjectData.Style4x2);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(25);
      TileObjectData.addTile(90);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(8);
      TileObjectData.addTile(79);
      TileObjectData.newTile.Width = 4;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 2, 1);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.addTile(209);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(1, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addBaseTile(out TileObjectData.StyleSmallCage);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(285);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(286);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(582);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(619);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(298);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(299);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(310);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(532);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(533);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(339);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(538);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(555);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(556);
      TileObjectData.newTile.Width = 6;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(3, 2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style6x3);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(275);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(276);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(413);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(414);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(277);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(278);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(279);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(280);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(281);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(296);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(297);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(309);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(550);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(551);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(553);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(554);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(558);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(559);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(599);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(600);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(601);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(602);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(603);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(604);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(605);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(606);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(607);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(608);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(609);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(610);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(611);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(612);
      TileObjectData.newTile.Width = 5;
      TileObjectData.newTile.Height = 4;
      TileObjectData.newTile.Origin = new Point16(2, 3);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[4]
      {
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style5x4);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
      TileObjectData.addTile(464);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
      TileObjectData.addTile(466);
      TileObjectData.newTile.Width = 2;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style2x1);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(29);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(103);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(462);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        18
      };
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(14);
      TileObjectData.addTile(18);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        18
      };
      TileObjectData.addTile(16);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(134);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.AnchorLeft = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Height, 0);
      TileObjectData.newTile.AnchorRight = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Height, 0);
      TileObjectData.addTile(387);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.addAlternate(3);
      TileObjectData.addTile(443);
      TileObjectData.newTile.Width = 2;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addBaseTile(out TileObjectData.Style2xX);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 5;
      TileObjectData.newTile.Origin = new Point16(1, 4);
      TileObjectData.newTile.CoordinateHeights = new int[5]
      {
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addTile(547);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 4;
      TileObjectData.newTile.Origin = new Point16(1, 3);
      TileObjectData.newTile.CoordinateHeights = new int[4]
      {
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(207);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        18
      };
      TileObjectData.addTile(410);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.addTile(480);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.addTile(509);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.addTile(489);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleWrapLimit = 7;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(7);
      TileObjectData.addTile(349);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.addTile(337);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(560);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData();
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(465);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData();
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addTile(531);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.addTile(320);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.addTile(456);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TETrainingDummy.Hook_AfterPlacement), -1, 0, false);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(378);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleWrapLimit = 55;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(165);
      TileObjectData.addTile(105);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Origin = new Point16(0, 2);
      TileObjectData.newTile.RandomStyleRange = 2;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(2);
      TileObjectData.addTile(545);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.Height = 5;
      TileObjectData.newTile.Origin = new Point16(0, 4);
      TileObjectData.newTile.CoordinateHeights = new int[5]
      {
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(17);
      TileObjectData.addTile(104);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Origin = new Point16(0, 2);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addTile(128);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Origin = new Point16(0, 2);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(506);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Origin = new Point16(0, 2);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addTile(269);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.Origin = new Point16(0, 2);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.DrawStyleOffset = 4;
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TEDisplayDoll.Hook_AfterPlacement), -1, 0, false);
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(470);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData();
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(591);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData();
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(592);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.addBaseTile(out TileObjectData.Style3x3);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.Height = 6;
      TileObjectData.newTile.Origin = new Point16(1, 5);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.CoordinateHeights = new int[6]
      {
        16,
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(7);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(8);
      TileObjectData.addTile(548);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.Height = 5;
      TileObjectData.newTile.Origin = new Point16(1, 4);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.CoordinateHeights = new int[5]
      {
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(613);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.Height = 6;
      TileObjectData.newTile.Origin = new Point16(1, 5);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.CoordinateHeights = new int[6]
      {
        16,
        16,
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(614);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.Origin = new Point16(1, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.StyleWrapLimit = 37;
      TileObjectData.newTile.StyleHorizontal = false;
      TileObjectData.newTile.StyleLineSkip = 2;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(32);
      TileObjectData.addTile(34);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.Width = 4;
      TileObjectData.newTile.Origin = new Point16(2, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(454);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(1, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style3x2);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newSubTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(13);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newSubTile.Height = 1;
      TileObjectData.newSubTile.Origin = new Point16(1, 0);
      TileObjectData.newSubTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.addSubTile(25);
      TileObjectData.addTile(14);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.addTile(469);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(37);
      TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(new Func<int, int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(9);
      TileObjectData.addTile(88);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addTile(237);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(244);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.addTile(26);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.addTile(86);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(377);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(37);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(15);
      TileObjectData.addTile(87);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.addTile(486);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(488);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(37);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(10);
      TileObjectData.addTile(89);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(114);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(186);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.StyleWrapLimit = 35;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(187);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.AnchorValidTiles = new int[4]
      {
        53,
        112,
        234,
        116
      };
      TileObjectData.newTile.WaterDeath = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.RandomStyleRange = 4;
      TileObjectData.addTile(552);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.StyleWrapLimit = 14;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.WaterDeath = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(1);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(4);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(9);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(1 + TileObjectData.newTile.StyleWrapLimit);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(4 + TileObjectData.newTile.StyleWrapLimit);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(9 + TileObjectData.newTile.StyleWrapLimit);
      TileObjectData.addTile(215);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(217);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(218);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.addTile(17);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(77);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(133);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
      TileObjectData.addTile(405);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(1, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.addTile(235);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 4;
      TileObjectData.newTile.Origin = new Point16(1, 3);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[4]
      {
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style3x4);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(37);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(4);
      TileObjectData.addTile(101);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(102);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(463);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TEHatRack.Hook_AfterPlacement), -1, 0, false);
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(475);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(new Func<int, int, int, int, int, int, int>(TETeleportationPylon.PlacementPreviewHook_CheckIfCanPlace), 1, 0, true);
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TETeleportationPylon.PlacementPreviewHook_AfterPlacement), -1, 0, false);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(597);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleHorizontal = false;
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(2);
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.styleLineSkipVisualOverride = new int?(0);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(617);
      TileObjectData.newTile.Width = 2;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style2x2);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(new Func<int, int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(21);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(new Func<int, int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(467);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(441);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.AnchorInvalidTiles = new int[3]
      {
        (int) sbyte.MaxValue,
        138,
        484
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(468);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.StyleWrapLimit = 6;
      TileObjectData.newTile.StyleMultiplier = 6;
      TileObjectData.newTile.RandomStyleRange = 6;
      TileObjectData.newTile.AnchorValidTiles = new int[4]
      {
        2,
        477,
        109,
        492
      };
      TileObjectData.addTile(254);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(96);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.StyleWrapLimit = 4;
      TileObjectData.newTile.StyleMultiplier = 1;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.AnchorValidTiles = Utils.GetTrueIndexes(TileID.Sets.Conversion.Sand, TileID.Sets.Conversion.Sandstone, TileID.Sets.Conversion.HardenedSand).ToArray();
      TileObjectData.addTile(485);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.RandomStyleRange = 5;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(457);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(490);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleWrapLimitVisualOverride = new int?(56);
      TileObjectData.newTile.styleLineSkipVisualOverride = new int?(2);
      TileObjectData.addTile(139);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.RandomStyleRange = 9;
      TileObjectData.addTile(35);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(1, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(95);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(1, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(126);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(1, 0);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.addTile(444);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.WaterDeath = true;
      TileObjectData.addTile(98);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(13);
      TileObjectData.addTile(172);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(94);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(411);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(97);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(99);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(25);
      TileObjectData.addTile(100);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(125);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(621);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(622);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(173);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(287);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(319);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(287);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(376);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(138);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addTile(484);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(142);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(143);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(282);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(543);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(598);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(568);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(569);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(570);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(288);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(289);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(290);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(291);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(292);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(293);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(294);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(295);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(316);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(317);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(318);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(360);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(580);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(620);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(565);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(521);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(522);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(523);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(524);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(525);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(526);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(527);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(505);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(358);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(359);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
      TileObjectData.addTile(542);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(361);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(362);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(363);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(364);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(544);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(391);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(392);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(393);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);
      TileObjectData.addTile(394);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(287);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.addTile(335);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(564);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(594);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(354);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(355);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(491);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
      TileObjectData.addTile(356);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
      TileObjectData.newTile.AnchorLeft = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newTile.AnchorRight = new AnchorData(AnchorType.SolidTile, 1, 1);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.addTile(386);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.addAlternate(2);
      TileObjectData.addTile(132);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 0);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(4);
      TileObjectData.addTile(55);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 0);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(4);
      TileObjectData.addTile(573);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 0);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(4);
      TileObjectData.addTile(425);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 0);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(4);
      TileObjectData.addTile(510);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 0);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(4);
      TileObjectData.addTile(511);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(85);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TEItemFrame.Hook_AfterPlacement), -1, 0, true);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 0);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(1, 0);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 0);
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = Point16.Zero;
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
      TileObjectData.addAlternate(4);
      TileObjectData.addTile(395);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style3x3);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.addTile(106);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(212);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(219);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(220);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(228);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(231);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(243);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(247);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(283);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(300);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(301);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(302);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(303);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(304);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(305);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(306);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(307);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(308);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.addTile(406);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.addTile(452);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(412);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(455);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(499);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style1x2);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(16);
      TileObjectData.addTile(15);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleWrapLimit = 2;
      TileObjectData.newTile.StyleMultiplier = 2;
      TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(14);
      TileObjectData.addTile(497);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        20
      };
      TileObjectData.addTile(216);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(390);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.addTile(338);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.StyleWrapLimit = 6;
      TileObjectData.newTile.DrawStyleOffset = 13 * TileObjectData.newTile.StyleWrapLimit;
      TileObjectData.addTile(493);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
      TileObjectData.newTile.RandomStyleRange = 5;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        18,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 26;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.addTile(567);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style1x1);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(420);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        18
      };
      TileObjectData.newTile.CoordinateWidth = 20;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(476);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.AnchorAlternateTiles = new int[2]
      {
        420,
        419
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Origin = new Point16(0, 1);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[1]
      {
        419
      };
      TileObjectData.addTile(419);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TELogicSensor.Hook_AfterPlacement), -1, 0, true);
      TileObjectData.addTile(423);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(424);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(445);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(429);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.EmptyTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        26
      };
      TileObjectData.newTile.CoordinateWidth = 24;
      TileObjectData.newTile.DrawYOffset = -8;
      TileObjectData.newTile.RandomStyleRange = 6;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(81);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        18
      };
      TileObjectData.newTile.CoordinatePadding = 0;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(135);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        18
      };
      TileObjectData.newTile.CoordinatePadding = 0;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(428);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.RandomStyleRange = 2;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(141);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(144);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(210);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.addTile(239);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.RandomStyleRange = 7;
      TileObjectData.addTile(36);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.newTile.RandomStyleRange = 3;
      TileObjectData.newTile.StyleMultiplier = 3;
      TileObjectData.newTile.StyleWrapLimit = 3;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.CoordinateWidth = 20;
      TileObjectData.newTile.DrawYOffset = -2;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(324);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(593);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.FlattenAnchors = true;
      TileObjectData.addBaseTile(out TileObjectData.StyleSwitch);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleSwitch);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[7]
      {
        124,
        561,
        574,
        575,
        576,
        577,
        578
      };
      TileObjectData.newAlternate.DrawXOffset = -2;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleSwitch);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[7]
      {
        124,
        561,
        574,
        575,
        576,
        577,
        578
      };
      TileObjectData.newAlternate.DrawXOffset = 2;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleSwitch);
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.DrawYOffset = 2;
      TileObjectData.addTile(136);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.FlattenAnchors = true;
      TileObjectData.newTile.UsesCustomCanPlace = false;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.DrawStepDown = 2;
      TileObjectData.newTile.CoordinateWidth = 20;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleMultiplier = 6;
      TileObjectData.newTile.StyleWrapLimit = 6;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.WaterDeath = true;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.StyleTorch);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[7]
      {
        124,
        561,
        574,
        575,
        576,
        577,
        578
      };
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[7]
      {
        124,
        561,
        574,
        575,
        576,
        577,
        578
      };
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
      TileObjectData.newAlternate.AnchorWall = true;
      TileObjectData.addAlternate(0);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(8);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(11);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
      TileObjectData.newSubTile.LinkedAlternates = true;
      TileObjectData.newSubTile.WaterDeath = false;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(17);
      TileObjectData.addTile(4);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = new Point16(0, 0);
      TileObjectData.newTile.FlattenAnchors = true;
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.DrawStepDown = 2;
      TileObjectData.newTile.CoordinateWidth = 20;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.WaterDeath = false;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.StyleWrapLimit = 4;
      TileObjectData.newTile.StyleMultiplier = 4;
      TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(new Func<int, int, int, int, int, int, int>(WorldGen.CanPlaceProjectilePressurePad), -1, 0, true);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile | AnchorType.EmptyTile | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.newAlternate.DrawStepDown = 0;
      TileObjectData.newAlternate.DrawYOffset = -4;
      TileObjectData.addAlternate(1);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile | AnchorType.EmptyTile | AnchorType.SolidBottom, TileObjectData.newTile.Height, 0);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[7]
      {
        124,
        561,
        574,
        575,
        576,
        577,
        578
      };
      TileObjectData.newAlternate.DrawXOffset = -2;
      TileObjectData.newAlternate.DrawYOffset = -2;
      TileObjectData.addAlternate(2);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile | AnchorType.EmptyTile | AnchorType.SolidBottom, TileObjectData.newTile.Height, 0);
      TileObjectData.newAlternate.AnchorAlternateTiles = new int[7]
      {
        124,
        561,
        574,
        575,
        576,
        577,
        578
      };
      TileObjectData.newAlternate.DrawXOffset = 2;
      TileObjectData.newAlternate.DrawYOffset = -2;
      TileObjectData.addAlternate(3);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile | AnchorType.EmptyTile | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
      TileObjectData.addTile(442);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 1;
      TileObjectData.newTile.Origin = Point16.Zero;
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[1]
      {
        20
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.DrawYOffset = -1;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.addBaseTile(out TileObjectData.StyleAlch);
      TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newTile.AnchorValidTiles = new int[4]
      {
        2,
        477,
        109,
        492
      };
      TileObjectData.newTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newSubTile.AnchorValidTiles = new int[1]
      {
        60
      };
      TileObjectData.newSubTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.addSubTile(1);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newSubTile.AnchorValidTiles = new int[2]
      {
        0,
        59
      };
      TileObjectData.newSubTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.addSubTile(2);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newSubTile.AnchorValidTiles = new int[4]
      {
        199,
        203,
        25,
        23
      };
      TileObjectData.newSubTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.addSubTile(3);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newSubTile.AnchorValidTiles = new int[2]
      {
        53,
        116
      };
      TileObjectData.newSubTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(4);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newSubTile.AnchorValidTiles = new int[1]
      {
        57
      };
      TileObjectData.newSubTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.newSubTile.LavaPlacement = LiquidPlacement.Allowed;
      TileObjectData.newSubTile.LavaDeath = false;
      TileObjectData.addSubTile(5);
      TileObjectData.newSubTile.CopyFrom(TileObjectData.StyleAlch);
      TileObjectData.newSubTile.AnchorValidTiles = new int[5]
      {
        147,
        161,
        163,
        164,
        200
      };
      TileObjectData.newSubTile.AnchorAlternateTiles = new int[1]
      {
        78
      };
      TileObjectData.newSubTile.WaterPlacement = LiquidPlacement.Allowed;
      TileObjectData.addSubTile(6);
      TileObjectData.addTile(82);
      TileObjectData.newTile.FullCopyFrom((ushort) 82);
      TileObjectData.addTile(83);
      TileObjectData.newTile.FullCopyFrom((ushort) 83);
      TileObjectData.addTile(84);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 1);
      TileObjectData.newTile.AnchorWall = true;
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[3]
      {
        16,
        16,
        16
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.addBaseTile(out TileObjectData.Style3x3Wall);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.StyleWrapLimit = 36;
      TileObjectData.addTile(240);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.StyleWrapLimit = 36;
      TileObjectData.addTile(440);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(334);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int, int>(TEWeaponsRack.Hook_AfterPlacement), -1, 0, true);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
      TileObjectData.addAlternate(1);
      TileObjectData.addTile(471);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.Width = 2;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(245);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.Width = 3;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(1, 0);
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        16
      };
      TileObjectData.addTile(246);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.Width = 4;
      TileObjectData.newTile.Height = 3;
      TileObjectData.newTile.Origin = new Point16(1, 1);
      TileObjectData.newTile.RandomStyleRange = 9;
      TileObjectData.addTile(241);
      TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
      TileObjectData.newTile.Width = 6;
      TileObjectData.newTile.Height = 4;
      TileObjectData.newTile.Origin = new Point16(2, 2);
      TileObjectData.newTile.CoordinateHeights = new int[4]
      {
        16,
        16,
        16,
        16
      };
      TileObjectData.newTile.StyleWrapLimit = 27;
      TileObjectData.addTile(242);
      TileObjectData.newTile.Width = 2;
      TileObjectData.newTile.Height = 4;
      TileObjectData.newTile.Origin = new Point16(0, 3);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[4]
      {
        16,
        16,
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.AnchorValidTiles = new int[5]
      {
        2,
        477,
        109,
        60,
        492
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.RandomStyleRange = 3;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.addTile(27);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.AnchorValidTiles = new int[2]
      {
        2,
        477
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaDeath = true;
      TileObjectData.newTile.RandomStyleRange = 3;
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        147
      };
      TileObjectData.addAlternate(3);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        60
      };
      TileObjectData.addAlternate(6);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        23
      };
      TileObjectData.addAlternate(9);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        199
      };
      TileObjectData.addAlternate(12);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[2]
      {
        109,
        492
      };
      TileObjectData.addAlternate(15);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        53
      };
      TileObjectData.addAlternate(18);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        116
      };
      TileObjectData.addAlternate(21);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        234
      };
      TileObjectData.addAlternate(24);
      TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
      TileObjectData.newAlternate.AnchorValidTiles = new int[1]
      {
        112
      };
      TileObjectData.addAlternate(27);
      TileObjectData.addTile(20);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.AnchorValidTiles = new int[14]
      {
        1,
        25,
        117,
        203,
        539,
        182,
        180,
        179,
        381,
        183,
        181,
        534,
        536,
        539
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.RandomStyleRange = 3;
      TileObjectData.newTile.StyleMultiplier = 3;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(590);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.AnchorValidTiles = new int[7]
      {
        2,
        477,
        492,
        60,
        109,
        199,
        23
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.RandomStyleRange = 3;
      TileObjectData.newTile.StyleMultiplier = 3;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(595);
      TileObjectData.newTile.Width = 1;
      TileObjectData.newTile.Height = 2;
      TileObjectData.newTile.Origin = new Point16(0, 1);
      TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
      TileObjectData.newTile.UsesCustomCanPlace = true;
      TileObjectData.newTile.CoordinateHeights = new int[2]
      {
        16,
        18
      };
      TileObjectData.newTile.CoordinateWidth = 16;
      TileObjectData.newTile.CoordinatePadding = 2;
      TileObjectData.newTile.AnchorValidTiles = new int[7]
      {
        2,
        477,
        492,
        60,
        109,
        199,
        23
      };
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.newTile.DrawFlipHorizontal = true;
      TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
      TileObjectData.newTile.LavaDeath = false;
      TileObjectData.newTile.RandomStyleRange = 3;
      TileObjectData.newTile.StyleMultiplier = 3;
      TileObjectData.newTile.StyleHorizontal = true;
      TileObjectData.addTile(615);
      TileObjectData.readOnlyData = true;
    }

    public static bool CustomPlace(int type, int style)
    {
      if (type < 0 || type >= TileObjectData._data.Count || style < 0)
        return false;
      TileObjectData tileObjectData1 = TileObjectData._data[type];
      if (tileObjectData1 == null)
        return false;
      List<TileObjectData> subTiles = tileObjectData1.SubTiles;
      if (subTiles != null && style < subTiles.Count)
      {
        TileObjectData tileObjectData2 = subTiles[style];
        if (tileObjectData2 != null)
          return tileObjectData2._usesCustomCanPlace;
      }
      return tileObjectData1._usesCustomCanPlace;
    }

    public static bool CheckLiquidPlacement(int type, int style, Tile checkTile)
    {
      TileObjectData tileData = TileObjectData.GetTileData(type, style);
      return tileData != null ? tileData.LiquidPlace(checkTile) : TileObjectData.LiquidPlace(type, checkTile);
    }

    public static bool LiquidPlace(int type, Tile checkTile)
    {
      if (checkTile == null)
        return false;
      if (checkTile.liquid > (byte) 0)
      {
        switch (checkTile.liquidType())
        {
          case 0:
          case 2:
            if (Main.tileWaterDeath[type])
              return false;
            break;
          case 1:
            if (Main.tileLavaDeath[type])
              return false;
            break;
        }
      }
      return true;
    }

    public static bool CheckWaterDeath(int type, int style)
    {
      TileObjectData tileData = TileObjectData.GetTileData(type, style);
      return tileData == null ? Main.tileWaterDeath[type] : tileData.WaterDeath;
    }

    public static bool CheckWaterDeath(Tile checkTile)
    {
      if (!checkTile.active())
        return false;
      TileObjectData tileData = TileObjectData.GetTileData(checkTile);
      return tileData == null ? Main.tileWaterDeath[(int) checkTile.type] : tileData.WaterDeath;
    }

    public static bool CheckLavaDeath(int type, int style)
    {
      TileObjectData tileData = TileObjectData.GetTileData(type, style);
      return tileData == null ? Main.tileLavaDeath[type] : tileData.LavaDeath;
    }

    public static bool CheckLavaDeath(Tile checkTile)
    {
      if (!checkTile.active())
        return false;
      TileObjectData tileData = TileObjectData.GetTileData(checkTile);
      return tileData == null ? Main.tileLavaDeath[(int) checkTile.type] : tileData.LavaDeath;
    }

    public static int PlatformFrameWidth() => TileObjectData._data[19].CoordinateFullWidth;

    public static TileObjectData GetTileData(int type, int style, int alternate = 0)
    {
      if (type < 0 || type >= TileObjectData._data.Count)
        throw new ArgumentOutOfRangeException("Function called with a bad type argument");
      if (style < 0)
        throw new ArgumentOutOfRangeException("Function called with a bad style argument");
      TileObjectData tileObjectData1 = TileObjectData._data[type];
      if (tileObjectData1 == null)
        return (TileObjectData) null;
      List<TileObjectData> subTiles = tileObjectData1.SubTiles;
      if (subTiles != null && style < subTiles.Count)
      {
        TileObjectData tileObjectData2 = subTiles[style];
        if (tileObjectData2 != null)
          tileObjectData1 = tileObjectData2;
      }
      --alternate;
      List<TileObjectData> alternates = tileObjectData1.Alternates;
      if (alternates != null && alternate >= 0 && alternate < alternates.Count)
      {
        TileObjectData tileObjectData3 = alternates[alternate];
        if (tileObjectData3 != null)
          tileObjectData1 = tileObjectData3;
      }
      return tileObjectData1;
    }

    public static TileObjectData GetTileData(Tile getTile)
    {
      if (getTile == null || !getTile.active())
        return (TileObjectData) null;
      int type = (int) getTile.type;
      if (type < 0 || type >= TileObjectData._data.Count)
        throw new ArgumentOutOfRangeException("Function called with a bad tile type");
      TileObjectData tileObjectData = TileObjectData._data[type];
      if (tileObjectData == null)
        return (TileObjectData) null;
      int num1 = (int) getTile.frameX / tileObjectData.CoordinateFullWidth;
      int num2 = (int) getTile.frameY / tileObjectData.CoordinateFullHeight;
      int num3 = tileObjectData.StyleWrapLimit;
      if (num3 == 0)
        num3 = 1;
      int num4 = !tileObjectData.StyleHorizontal ? num1 * num3 + num2 : num2 * num3 + num1;
      int index1 = num4 / tileObjectData.StyleMultiplier;
      int num5 = num4 % tileObjectData.StyleMultiplier;
      if (tileObjectData.SubTiles != null && index1 >= 0 && index1 < tileObjectData.SubTiles.Count)
      {
        TileObjectData subTile = tileObjectData.SubTiles[index1];
        if (subTile != null)
          tileObjectData = subTile;
      }
      if (tileObjectData._alternates != null)
      {
        for (int index2 = 0; index2 < tileObjectData.Alternates.Count; ++index2)
        {
          TileObjectData alternate = tileObjectData.Alternates[index2];
          if (alternate != null && num5 >= alternate.Style && num5 <= alternate.Style + alternate.RandomStyleRange)
            return alternate;
        }
      }
      return tileObjectData;
    }

    public static void SyncObjectPlacement(int tileX, int tileY, int type, int style, int dir)
    {
      NetMessage.SendData(17, number: 1, number2: ((float) tileX), number3: ((float) tileY), number4: ((float) type), number5: style);
      TileObjectData.GetTileData(type, style);
    }

    public static bool CallPostPlacementPlayerHook(
      int tileX,
      int tileY,
      int type,
      int style,
      int dir,
      int alternate,
      TileObject data)
    {
      TileObjectData tileData = TileObjectData.GetTileData(type, style, data.alternate);
      if (tileData == null || tileData._placementHooks == null || tileData._placementHooks.postPlaceMyPlayer.hook == null)
        return false;
      PlacementHook postPlaceMyPlayer = tileData._placementHooks.postPlaceMyPlayer;
      if (postPlaceMyPlayer.processedCoordinates)
      {
        tileX -= (int) tileData.Origin.X;
        tileY -= (int) tileData.Origin.Y;
      }
      return postPlaceMyPlayer.hook(tileX, tileY, type, style, dir, data.alternate) == postPlaceMyPlayer.badReturn;
    }

    public static void OriginToTopLeft(int type, int style, ref Point16 baseCoords)
    {
      TileObjectData tileData = TileObjectData.GetTileData(type, style);
      if (tileData == null)
        return;
      baseCoords = new Point16((int) baseCoords.X - (int) tileData.Origin.X, (int) baseCoords.Y - (int) tileData.Origin.Y);
    }
  }
}
