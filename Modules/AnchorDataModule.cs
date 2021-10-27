// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.AnchorDataModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.DataStructures;

namespace Terraria.Modules
{
  public class AnchorDataModule
  {
    public AnchorData top;
    public AnchorData bottom;
    public AnchorData left;
    public AnchorData right;
    public bool wall;

    public AnchorDataModule(AnchorDataModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.top = new AnchorData();
        this.bottom = new AnchorData();
        this.left = new AnchorData();
        this.right = new AnchorData();
        this.wall = false;
      }
      else
      {
        this.top = copyFrom.top;
        this.bottom = copyFrom.bottom;
        this.left = copyFrom.left;
        this.right = copyFrom.right;
        this.wall = copyFrom.wall;
      }
    }
  }
}
