// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.BlockBecauseYouAreOverAnImportantTile
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.ObjectInteractions
{
  public class BlockBecauseYouAreOverAnImportantTile : ISmartInteractBlockReasonProvider
  {
    public bool ShouldBlockSmartInteract(SmartInteractScanSettings settings)
    {
      int tileTargetX = Player.tileTargetX;
      int tileTargetY = Player.tileTargetY;
      if (!WorldGen.InWorld(tileTargetX, tileTargetY, 10))
        return true;
      Tile tile = Main.tile[tileTargetX, tileTargetY];
      if (tile == null)
        return true;
      if (tile.active())
      {
        switch (tile.type)
        {
          case 4:
          case 33:
          case 334:
          case 395:
          case 410:
          case 455:
          case 471:
          case 480:
          case 509:
          case 520:
            return true;
        }
      }
      return false;
    }
  }
}
