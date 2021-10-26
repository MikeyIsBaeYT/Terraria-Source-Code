// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.ItemDropResolver
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class ItemDropResolver
  {
    private ItemDropDatabase _database;

    public ItemDropResolver(ItemDropDatabase database) => this._database = database;

    public void TryDropping(DropAttemptInfo info)
    {
      List<IItemDropRule> rulesForNpcid = this._database.GetRulesForNPCID(info.npc.netID);
      for (int index = 0; index < rulesForNpcid.Count; ++index)
        this.ResolveRule(rulesForNpcid[index], info);
    }

    private ItemDropAttemptResult ResolveRule(
      IItemDropRule rule,
      DropAttemptInfo info)
    {
      if (!rule.CanDrop(info))
      {
        ItemDropAttemptResult parentResult = new ItemDropAttemptResult()
        {
          State = ItemDropAttemptResultState.DoesntFillConditions
        };
        this.ResolveRuleChains(rule, info, parentResult);
        return parentResult;
      }
      ItemDropAttemptResult parentResult1 = !(rule is INestedItemDropRule nestedItemDropRule) ? rule.TryDroppingItem(info) : nestedItemDropRule.TryDroppingItem(info, new ItemDropRuleResolveAction(this.ResolveRule));
      this.ResolveRuleChains(rule, info, parentResult1);
      return parentResult1;
    }

    private void ResolveRuleChains(
      IItemDropRule rule,
      DropAttemptInfo info,
      ItemDropAttemptResult parentResult)
    {
      this.ResolveRuleChains(ref info, ref parentResult, rule.ChainedRules);
    }

    private void ResolveRuleChains(
      ref DropAttemptInfo info,
      ref ItemDropAttemptResult parentResult,
      List<IItemDropRuleChainAttempt> ruleChains)
    {
      if (ruleChains == null)
        return;
      for (int index = 0; index < ruleChains.Count; ++index)
      {
        IItemDropRuleChainAttempt ruleChain = ruleChains[index];
        if (ruleChain.CanChainIntoRule(parentResult))
          this.ResolveRule(ruleChain.RuleToChain, info);
      }
    }
  }
}
