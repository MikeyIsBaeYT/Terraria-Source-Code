// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropOneByOne
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class DropOneByOne : IItemDropRule
  {
    private int _itemId;
    private DropOneByOne.Parameters _parameters;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public DropOneByOne(int itemId, DropOneByOne.Parameters parameters)
    {
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
      this._parameters = parameters;
      this._itemId = itemId;
    }

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.player.RollLuck(this._parameters.DropsXOutOfYTimes_TheY) < this._parameters.DropsXOutOfYTimes_TheX)
      {
        int num1 = info.rng.Next(this._parameters.MinimumItemDropsCount, this._parameters.MaximumItemDropsCount + 1);
        int activePlayersCount = Main.CurrentFrameFlags.ActivePlayersCount;
        int minValue = this._parameters.MinimumStackPerChunkBase + activePlayersCount * this._parameters.BonusMinDropsPerChunkPerPlayer;
        int num2 = this._parameters.MaximumStackPerChunkBase + activePlayersCount * this._parameters.BonusMaxDropsPerChunkPerPlayer;
        for (int index = 0; index < num1; ++index)
          CommonCode.DropItemFromNPC(info.npc, this._itemId, info.rng.Next(minValue, num2 + 1), true);
        return new ItemDropAttemptResult()
        {
          State = ItemDropAttemptResultState.Success
        };
      }
      return new ItemDropAttemptResult()
      {
        State = ItemDropAttemptResultState.FailedRandomRoll
      };
    }

    public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      float personalDropRate = this._parameters.GetPersonalDropRate();
      float dropRate = personalDropRate * ratesInfo.parentDroprateChance;
      drops.Add(new DropRateInfo(this._itemId, this._parameters.MinimumItemDropsCount * (this._parameters.MinimumStackPerChunkBase + this._parameters.BonusMinDropsPerChunkPerPlayer), this._parameters.MaximumItemDropsCount * (this._parameters.MaximumStackPerChunkBase + this._parameters.BonusMaxDropsPerChunkPerPlayer), dropRate, ratesInfo.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }

    public bool CanDrop(DropAttemptInfo info) => true;

    public struct Parameters
    {
      public int DropsXOutOfYTimes_TheX;
      public int DropsXOutOfYTimes_TheY;
      public int MinimumItemDropsCount;
      public int MaximumItemDropsCount;
      public int MinimumStackPerChunkBase;
      public int MaximumStackPerChunkBase;
      public int BonusMinDropsPerChunkPerPlayer;
      public int BonusMaxDropsPerChunkPerPlayer;

      public float GetPersonalDropRate() => (float) this.DropsXOutOfYTimes_TheX / (float) this.DropsXOutOfYTimes_TheY;
    }
  }
}
