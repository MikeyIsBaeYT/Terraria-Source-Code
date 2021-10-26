// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropLocalPerClientAndResetsNPCMoneyTo0
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.ItemDropRules
{
  public class DropLocalPerClientAndResetsNPCMoneyTo0 : CommonDrop
  {
    private IItemDropRuleCondition _condition;

    public DropLocalPerClientAndResetsNPCMoneyTo0(
      int itemId,
      int dropsOutOfY,
      int amountDroppedMinimum,
      int amountDroppedMaximum,
      IItemDropRuleCondition optionalCondition)
      : base(itemId, dropsOutOfY, amountDroppedMinimum, amountDroppedMaximum)
    {
      this._condition = optionalCondition;
    }

    public override bool CanDrop(DropAttemptInfo info) => this._condition == null || this._condition.CanDrop(info);

    public override ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.rng.Next(this._dropsOutOfY) < this._dropsXoutOfY)
      {
        CommonCode.DropItemLocalPerClientAndSetNPCMoneyTo0(info.npc, this._itemId, info.rng.Next(this._amtDroppedMinimum, this._amtDroppedMaximum + 1));
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
  }
}
