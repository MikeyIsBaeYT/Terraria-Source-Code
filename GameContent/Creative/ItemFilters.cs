// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.ItemFilters
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent.Creative
{
  public static class ItemFilters
  {
    private const int framesPerRow = 9;
    private const int framesPerColumn = 1;
    private const int frameSizeOffsetX = -2;
    private const int frameSizeOffsetY = 0;

    public class BySearch : IItemEntryFilter, IEntryFilter<Item>, ISearchFilter<Item>
    {
      private const int _tooltipMaxLines = 30;
      private string[] _toolTipLines = new string[30];
      private bool[] _unusedPrefixLine = new bool[30];
      private bool[] _unusedBadPrefixLines = new bool[30];
      private int _unusedYoyoLogo;
      private int _unusedResearchLine;
      private string _search;

      public bool FitsFilter(Item entry)
      {
        if (this._search == null)
          return true;
        int numLines = 1;
        float knockBack = entry.knockBack;
        Main.MouseText_DrawItemTooltip_GetLinesInfo(entry, ref this._unusedYoyoLogo, ref this._unusedResearchLine, knockBack, ref numLines, this._toolTipLines, this._unusedPrefixLine, this._unusedBadPrefixLines);
        for (int index = 0; index < numLines; ++index)
        {
          if (this._toolTipLines[index].ToLower().IndexOf(this._search, StringComparison.OrdinalIgnoreCase) != -1)
            return true;
        }
        return false;
      }

      public string GetDisplayNameKey() => "CreativePowers.TabSearch";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Rank_Light", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame());
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }

      public void SetSearch(string searchText) => this._search = searchText;
    }

    public class BuildingBlock : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry) => entry.createTile != -1 || entry.createWall != -1 || entry.tileWand != -1;

      public string GetDisplayNameKey() => "CreativePowers.TabBlocks";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9, frameX: 4).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class Weapon : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry) => entry.damage > 0;

      public string GetDisplayNameKey() => "CreativePowers.TabWeapons";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class Armor : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry) => entry.bodySlot != -1 || entry.headSlot != -1 || entry.legSlot != -1;

      public string GetDisplayNameKey() => "CreativePowers.TabArmor";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9, frameX: 2).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class Accessories : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry) => entry.accessory;

      public string GetDisplayNameKey() => "CreativePowers.TabAccessories";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9, frameX: 1).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class Consumables : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry)
      {
        bool flag = entry.createTile != -1 || entry.createWall != -1 || entry.tileWand != -1;
        return entry.consumable && !flag;
      }

      public string GetDisplayNameKey() => "CreativePowers.TabConsumables";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9, frameX: 3).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class GameplayItems : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry) => ItemID.Sets.SortingPriorityBossSpawns[entry.type] != -1;

      public string GetDisplayNameKey() => "CreativePowers.TabMisc";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9, frameX: 5).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class Materials : IItemEntryFilter, IEntryFilter<Item>
    {
      public bool FitsFilter(Item entry) => entry.material;

      public string GetDisplayNameKey() => "CreativePowers.TabMaterials";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Creative/Infinite_Icons", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(9, frameX: 6).OffsetSize(-2, 0));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }
  }
}
