// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.PotionOfReturnHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.ObjectInteractions
{
  public class PotionOfReturnHelper
  {
    public static bool TryGetGateHitbox(Player player, out Rectangle homeHitbox)
    {
      homeHitbox = Rectangle.Empty;
      if (!player.PotionOfReturnHomePosition.HasValue)
        return false;
      Vector2 vector2 = new Vector2(0.0f, (float) (-player.height / 2));
      Vector2 center = player.PotionOfReturnHomePosition.Value + vector2;
      homeHitbox = Utils.CenteredRectangle(center, new Vector2(24f, 40f));
      return true;
    }
  }
}
