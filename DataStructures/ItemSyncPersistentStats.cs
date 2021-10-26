// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.ItemSyncPersistentStats
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public struct ItemSyncPersistentStats
  {
    private Color color;
    private int type;

    public void CopyFrom(Item item)
    {
      this.type = item.type;
      this.color = item.color;
    }

    public void PasteInto(Item item)
    {
      if (this.type != item.type)
        return;
      item.color = this.color;
    }
  }
}
