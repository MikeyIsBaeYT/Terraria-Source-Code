// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectCoordinatesModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
  public class TileObjectCoordinatesModule
  {
    public int width;
    public int[] heights;
    public int padding;
    public Point16 paddingFix;
    public int styleWidth;
    public int styleHeight;
    public bool calculated;
    public int drawStyleOffset;

    public TileObjectCoordinatesModule(TileObjectCoordinatesModule copyFrom = null, int[] drawHeight = null)
    {
      if (copyFrom == null)
      {
        this.width = 0;
        this.padding = 0;
        this.paddingFix = Point16.Zero;
        this.styleWidth = 0;
        this.drawStyleOffset = 0;
        this.styleHeight = 0;
        this.calculated = false;
        this.heights = drawHeight;
      }
      else
      {
        this.width = copyFrom.width;
        this.padding = copyFrom.padding;
        this.paddingFix = copyFrom.paddingFix;
        this.drawStyleOffset = copyFrom.drawStyleOffset;
        this.styleWidth = copyFrom.styleWidth;
        this.styleHeight = copyFrom.styleHeight;
        this.calculated = copyFrom.calculated;
        if (drawHeight == null)
        {
          if (copyFrom.heights == null)
          {
            this.heights = (int[]) null;
          }
          else
          {
            this.heights = new int[copyFrom.heights.Length];
            Array.Copy((Array) copyFrom.heights, (Array) this.heights, this.heights.Length);
          }
        }
        else
          this.heights = drawHeight;
      }
    }
  }
}
