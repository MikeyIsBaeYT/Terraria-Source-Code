// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.ItemDropWithConditionRule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class ItemDropWithConditionRule : CommonDrop
  {
    private IItemDropRuleCondition _condition;

    public ItemDropWithConditionRule(
      int itemId,
      int dropsOutOfY,
      int amountDroppedMinimum,
      int amountDroppedMaximum,
      IItemDropRuleCondition condition,
      int dropsXOutOfY = 1)
      : base(itemId, dropsOutOfY, amountDroppedMinimum, amountDroppedMaximum, dropsXOutOfY)
    {
      this._condition = condition;
    }

    public override bool CanDrop(DropAttemptInfo info) => this._condition.CanDrop(info);

    public override void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      DropRateInfoChainFeed ratesInfo1 = ratesInfo.With(1f);
      ratesInfo1.AddCondition(this._condition);
      float personalDropRate = (float) this._dropsXoutOfY / (float) this._dropsOutOfY;
      float dropRate = personalDropRate * ratesInfo1.parentDroprateChance;
      drops.Add(new DropRateInfo(this._itemId, this._amtDroppedMinimum, this._amtDroppedMaximum, dropRate, ratesInfo1.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo1);
    }
  }
}
