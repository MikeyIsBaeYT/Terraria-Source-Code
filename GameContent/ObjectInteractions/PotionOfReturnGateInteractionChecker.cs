// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.PotionOfReturnGateInteractionChecker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.ObjectInteractions
{
  public class PotionOfReturnGateInteractionChecker : AHoverInteractionChecker
  {
    internal override bool? AttemptOverridingHoverStatus(Player player, Rectangle rectangle) => Main.SmartInteractPotionOfReturn ? new bool?(true) : new bool?();

    internal override void DoHoverEffect(Player player, Rectangle hitbox)
    {
      player.noThrow = 2;
      player.cursorItemIconEnabled = true;
      player.cursorItemIconID = 4870;
    }

    internal override bool ShouldBlockInteraction(Player player, Rectangle hitbox) => (uint) Player.BlockInteractionWithProjectiles > 0U;

    internal override void PerformInteraction(Player player, Rectangle hitbox) => player.DoPotionOfReturnReturnToOriginalUsePosition();
  }
}
