// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.OneFromOptionsDropRule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class OneFromOptionsDropRule : IItemDropRule
  {
    private int[] _dropIds;
    private int _outOfY;
    private int _xoutOfY;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public OneFromOptionsDropRule(int outOfY, int xoutOfY, params int[] options)
    {
      this._outOfY = outOfY;
      this._xoutOfY = xoutOfY;
      this._dropIds = options;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public bool CanDrop(DropAttemptInfo info) => true;

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.player.RollLuck(this._outOfY) < this._xoutOfY)
      {
        CommonCode.DropItemFromNPC(info.npc, this._dropIds[info.rng.Next(this._dropIds.Length)], 1);
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
      float personalDropRate = (float) this._xoutOfY / (float) this._outOfY;
      float dropRate = 1f / (float) this._dropIds.Length * (personalDropRate * ratesInfo.parentDroprateChance);
      for (int index = 0; index < this._dropIds.Length; ++index)
        drops.Add(new DropRateInfo(this._dropIds[index], 1, 1, dropRate, ratesInfo.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }
  }
}
