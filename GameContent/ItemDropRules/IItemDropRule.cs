// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.IItemDropRule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public interface IItemDropRule
  {
    List<IItemDropRuleChainAttempt> ChainedRules { get; }

    bool CanDrop(DropAttemptInfo info);

    void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo);

    ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info);
  }
}
