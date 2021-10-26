// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropRateInfoChainFeed
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public struct DropRateInfoChainFeed
  {
    public float parentDroprateChance;
    public List<IItemDropRuleCondition> conditions;

    public void AddCondition(IItemDropRuleCondition condition)
    {
      if (this.conditions == null)
        this.conditions = new List<IItemDropRuleCondition>();
      this.conditions.Add(condition);
    }

    public DropRateInfoChainFeed(float droprate)
    {
      this.parentDroprateChance = droprate;
      this.conditions = (List<IItemDropRuleCondition>) null;
    }

    public DropRateInfoChainFeed With(float multiplier)
    {
      DropRateInfoChainFeed rateInfoChainFeed = new DropRateInfoChainFeed(this.parentDroprateChance * multiplier);
      if (this.conditions != null)
        rateInfoChainFeed.conditions = new List<IItemDropRuleCondition>((IEnumerable<IItemDropRuleCondition>) this.conditions);
      return rateInfoChainFeed;
    }
  }
}
