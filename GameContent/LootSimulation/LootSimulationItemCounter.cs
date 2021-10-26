// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulationItemCounter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;

namespace Terraria.GameContent.LootSimulation
{
  public class LootSimulationItemCounter
  {
    private long[] _itemCountsObtained = new long[5045];
    private long[] _itemCountsObtainedExpert = new long[5045];
    private long _totalTimesAttempted;
    private long _totalTimesAttemptedExpert;

    public void AddItem(int itemId, int amount, bool expert)
    {
      if (expert)
        this._itemCountsObtainedExpert[itemId] += (long) amount;
      else
        this._itemCountsObtained[itemId] += (long) amount;
    }

    public void Exclude(params int[] itemIds)
    {
      foreach (int itemId in itemIds)
      {
        this._itemCountsObtained[itemId] = 0L;
        this._itemCountsObtainedExpert[itemId] = 0L;
      }
    }

    public void IncreaseTimesAttempted(int amount, bool expert)
    {
      if (expert)
        this._totalTimesAttemptedExpert += (long) amount;
      else
        this._totalTimesAttempted += (long) amount;
    }

    public string PrintCollectedItems(bool expert)
    {
      long[] collectionToUse = this._itemCountsObtained;
      long totalDropsAttempted = this._totalTimesAttempted;
      if (expert)
      {
        collectionToUse = this._itemCountsObtainedExpert;
        this._totalTimesAttempted = this._totalTimesAttemptedExpert;
      }
      return string.Join(",\n", ((IEnumerable<long>) collectionToUse).Select((count, itemId) => new
      {
        itemId = itemId,
        count = count
      }).Where(entry => entry.count > 0L).Select(entry => entry.itemId).Select<int, string>((Func<int, string>) (itemId => string.Format("new ItemDropInfo(ItemID.{0}, {1}, {2})", (object) ItemID.Search.GetName(itemId), (object) collectionToUse[itemId], (object) totalDropsAttempted))));
    }
  }
}
