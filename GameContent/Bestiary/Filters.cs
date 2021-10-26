// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.Filters
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public static class Filters
  {
    public class BySearch : 
      IBestiaryEntryFilter,
      IEntryFilter<BestiaryEntry>,
      ISearchFilter<BestiaryEntry>
    {
      private string _search;

      public bool? ForcedDisplay => new bool?(true);

      public bool FitsFilter(BestiaryEntry entry)
      {
        if (this._search == null)
          return true;
        BestiaryUICollectionInfo uiCollectionInfo = entry.UIInfoProvider.GetEntryUICollectionInfo();
        for (int index = 0; index < entry.Info.Count; ++index)
        {
          if (entry.Info[index] is IProvideSearchFilterString searchFilterString1)
          {
            string searchString = searchFilterString1.GetSearchString(ref uiCollectionInfo);
            if (searchString != null && searchString.ToLower().IndexOf(this._search, StringComparison.OrdinalIgnoreCase) != -1)
              return true;
          }
        }
        return false;
      }

      public string GetDisplayNameKey() => "BestiaryInfo.IfSearched";

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

    public class ByUnlockState : IBestiaryEntryFilter, IEntryFilter<BestiaryEntry>
    {
      public bool? ForcedDisplay => new bool?(true);

      public bool FitsFilter(BestiaryEntry entry)
      {
        BestiaryUICollectionInfo uiCollectionInfo = entry.UIInfoProvider.GetEntryUICollectionInfo();
        return entry.Icon.GetUnlockState(uiCollectionInfo);
      }

      public string GetDisplayNameKey() => "BestiaryInfo.IfUnlocked";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(16, 5, 14, 3));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class ByRareCreature : IBestiaryEntryFilter, IEntryFilter<BestiaryEntry>
    {
      public bool? ForcedDisplay => new bool?();

      public bool FitsFilter(BestiaryEntry entry)
      {
        for (int index = 0; index < entry.Info.Count; ++index)
        {
          if (entry.Info[index] is RareSpawnBestiaryInfoElement)
            return true;
        }
        return false;
      }

      public string GetDisplayNameKey() => "BestiaryInfo.IsRare";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Rank_Light", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame());
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class ByBoss : IBestiaryEntryFilter, IEntryFilter<BestiaryEntry>
    {
      public bool? ForcedDisplay => new bool?();

      public bool FitsFilter(BestiaryEntry entry)
      {
        for (int index = 0; index < entry.Info.Count; ++index)
        {
          if (entry.Info[index] is BossBestiaryInfoElement)
            return true;
        }
        return false;
      }

      public string GetDisplayNameKey() => "BestiaryInfo.IsBoss";

      public UIElement GetImage()
      {
        Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow", (AssetRequestMode) 1);
        UIImageFramed uiImageFramed = new UIImageFramed(asset, asset.Frame(16, 5, 15, 3));
        uiImageFramed.HAlign = 0.5f;
        uiImageFramed.VAlign = 0.5f;
        return (UIElement) uiImageFramed;
      }
    }

    public class ByInfoElement : IBestiaryEntryFilter, IEntryFilter<BestiaryEntry>
    {
      private IBestiaryInfoElement _element;

      public bool? ForcedDisplay => new bool?();

      public ByInfoElement(IBestiaryInfoElement element) => this._element = element;

      public bool FitsFilter(BestiaryEntry entry) => entry.Info.Contains(this._element);

      public string GetDisplayNameKey() => !(this._element is IFilterInfoProvider element) ? (string) null : element.GetDisplayNameKey();

      public UIElement GetImage() => !(this._element is IFilterInfoProvider element) ? (UIElement) null : element.GetFilterImage();
    }
  }
}
