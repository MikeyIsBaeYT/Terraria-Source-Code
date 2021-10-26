// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropBasedOnExpertMode
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class DropBasedOnExpertMode : IItemDropRule, INestedItemDropRule
  {
    private IItemDropRule _ruleForNormalMode;
    private IItemDropRule _ruleForExpertMode;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public DropBasedOnExpertMode(IItemDropRule ruleForNormalMode, IItemDropRule ruleForExpertMode)
    {
      this._ruleForNormalMode = ruleForNormalMode;
      this._ruleForExpertMode = ruleForExpertMode;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public bool CanDrop(DropAttemptInfo info) => info.IsExpertMode ? this._ruleForExpertMode.CanDrop(info) : this._ruleForNormalMode.CanDrop(info);

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info) => new ItemDropAttemptResult()
    {
      State = ItemDropAttemptResultState.DidNotRunCode
    };

    public ItemDropAttemptResult TryDroppingItem(
      DropAttemptInfo info,
      ItemDropRuleResolveAction resolveAction)
    {
      return info.IsExpertMode ? resolveAction(this._ruleForExpertMode, info) : resolveAction(this._ruleForNormalMode, info);
    }

    public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      DropRateInfoChainFeed ratesInfo1 = ratesInfo.With(1f);
      ratesInfo1.AddCondition((IItemDropRuleCondition) new Conditions.IsExpert());
      this._ruleForExpertMode.ReportDroprates(drops, ratesInfo1);
      DropRateInfoChainFeed ratesInfo2 = ratesInfo.With(1f);
      ratesInfo2.AddCondition((IItemDropRuleCondition) new Conditions.NotExpert());
      this._ruleForNormalMode.ReportDroprates(drops, ratesInfo2);
      Chains.ReportDroprates(this.ChainedRules, 1f, drops, ratesInfo);
    }
  }
}
