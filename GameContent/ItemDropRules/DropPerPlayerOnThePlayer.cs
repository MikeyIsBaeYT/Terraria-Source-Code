// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropPerPlayerOnThePlayer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.ItemDropRules
{
  public class DropPerPlayerOnThePlayer : CommonDrop
  {
    private IItemDropRuleCondition _condition;

    public DropPerPlayerOnThePlayer(
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
      CommonCode.DropItemForEachInteractingPlayerOnThePlayer(info.npc, this._itemId, info.rng, this._dropsXoutOfY, this._dropsOutOfY, info.rng.Next(this._amtDroppedMinimum, this._amtDroppedMaximum + 1));
      return new ItemDropAttemptResult()
      {
        State = ItemDropAttemptResultState.Success
      };
    }
  }
}
