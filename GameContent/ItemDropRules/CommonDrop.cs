// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.CommonDrop
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class CommonDrop : IItemDropRule
  {
    protected int _itemId;
    protected int _dropsOutOfY;
    protected int _amtDroppedMinimum;
    protected int _amtDroppedMaximum;
    protected int _dropsXoutOfY;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public CommonDrop(
      int itemId,
      int dropsOutOfY,
      int amountDroppedMinimum = 1,
      int amountDroppedMaximum = 1,
      int dropsXOutOfY = 1)
    {
      this._itemId = itemId;
      this._dropsOutOfY = dropsOutOfY;
      this._amtDroppedMinimum = amountDroppedMinimum;
      this._amtDroppedMaximum = amountDroppedMaximum;
      this._dropsXoutOfY = dropsXOutOfY;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public virtual bool CanDrop(DropAttemptInfo info) => true;

    public virtual ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.player.RollLuck(this._dropsOutOfY) < this._dropsXoutOfY)
      {
        CommonCode.DropItemFromNPC(info.npc, this._itemId, info.rng.Next(this._amtDroppedMinimum, this._amtDroppedMaximum + 1));
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

    public virtual void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      float personalDropRate = (float) this._dropsXoutOfY / (float) this._dropsOutOfY;
      float dropRate = personalDropRate * ratesInfo.parentDroprateChance;
      drops.Add(new DropRateInfo(this._itemId, this._amtDroppedMinimum, this._amtDroppedMaximum, dropRate, ratesInfo.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }
  }
}
