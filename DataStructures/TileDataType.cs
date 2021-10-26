// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileDataType
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.DataStructures
{
  [Flags]
  public enum TileDataType
  {
    Tile = 1,
    TilePaint = 2,
    Wall = 4,
    WallPaint = 8,
    Liquid = 16, // 0x00000010
    Wiring = 32, // 0x00000020
    Actuator = 64, // 0x00000040
    Slope = 128, // 0x00000080
    All = Slope | Actuator | Wiring | Liquid | WallPaint | Wall | TilePaint | Tile, // 0x000000FF
  }
}
