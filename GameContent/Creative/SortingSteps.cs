// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.SortingSteps
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent.Creative
{
  public static class SortingSteps
  {
    public abstract class ACreativeItemSortStep : 
      ICreativeItemSortStep,
      IEntrySortStep<int>,
      IComparer<int>,
      IComparer<Item>
    {
      public abstract string GetDisplayNameKey();

      public int Compare(int x, int y) => this.Compare(ContentSamples.ItemsByType[x], ContentSamples.ItemsByType[y]);

      public abstract int Compare(Item x, Item y);
    }

    public abstract class AStepByFittingFilter : SortingSteps.ACreativeItemSortStep
    {
      public override int Compare(Item x, Item y)
      {
        int num = this.FitsFilter(x).CompareTo(this.FitsFilter(y));
        if (num == 0)
          num = 1;
        return num;
      }

      public abstract bool FitsFilter(Item item);

      public virtual int CompareWhenBothFit(Item x, Item y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }

    public class Blocks : SortingSteps.AStepByFittingFilter
    {
      public override string GetDisplayNameKey() => "CreativePowers.Sort_Blocks";

      public override bool FitsFilter(Item item) => item.createTile >= 0 && !Main.tileFrameImportant[item.createTile];
    }

    public class Walls : SortingSteps.AStepByFittingFilter
    {
      public override string GetDisplayNameKey() => "CreativePowers.Sort_Walls";

      public override bool FitsFilter(Item item) => item.createWall >= 0;
    }

    public class PlacableObjects : SortingSteps.AStepByFittingFilter
    {
      public override string GetDisplayNameKey() => "CreativePowers.Sort_PlacableObjects";

      public override bool FitsFilter(Item item) => item.createTile >= 0 && Main.tileFrameImportant[item.createTile];
    }

    public class ByCreativeSortingId : SortingSteps.ACreativeItemSortStep
    {
      public override string GetDisplayNameKey() => "CreativePowers.Sort_SortingID";

      public override int Compare(Item x, Item y)
      {
        ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup groupAndOrderInGroup1 = ContentSamples.ItemCreativeSortingId[x.type];
        ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup groupAndOrderInGroup2 = ContentSamples.ItemCreativeSortingId[y.type];
        int num = groupAndOrderInGroup1.Group.CompareTo((object) groupAndOrderInGroup2.Group);
        if (num == 0)
          num = groupAndOrderInGroup1.OrderInGroup.CompareTo(groupAndOrderInGroup2.OrderInGroup);
        return num;
      }
    }

    public class Alphabetical : SortingSteps.ACreativeItemSortStep
    {
      public override string GetDisplayNameKey() => "CreativePowers.Sort_Alphabetical";

      public override int Compare(Item x, Item y) => x.Name.CompareTo(y.Name);
    }
  }
}
