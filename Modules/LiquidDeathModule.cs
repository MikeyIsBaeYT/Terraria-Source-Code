// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.LiquidDeathModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Modules
{
  public class LiquidDeathModule
  {
    public bool water;
    public bool lava;

    public LiquidDeathModule(LiquidDeathModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.water = false;
        this.lava = false;
      }
      else
      {
        this.water = copyFrom.water;
        this.lava = copyFrom.lava;
      }
    }
  }
}
