// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectDrawModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Modules
{
  public class TileObjectDrawModule
  {
    public int xOffset;
    public int yOffset;
    public bool flipHorizontal;
    public bool flipVertical;
    public int stepDown;

    public TileObjectDrawModule(TileObjectDrawModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.xOffset = 0;
        this.yOffset = 0;
        this.flipHorizontal = false;
        this.flipVertical = false;
        this.stepDown = 0;
      }
      else
      {
        this.xOffset = copyFrom.xOffset;
        this.yOffset = copyFrom.yOffset;
        this.flipHorizontal = copyFrom.flipHorizontal;
        this.flipVertical = copyFrom.flipVertical;
        this.stepDown = copyFrom.stepDown;
      }
    }
  }
}
