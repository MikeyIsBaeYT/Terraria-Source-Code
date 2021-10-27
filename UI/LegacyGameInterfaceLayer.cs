// Decompiled with JetBrains decompiler
// Type: Terraria.UI.LegacyGameInterfaceLayer
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.UI
{
  public class LegacyGameInterfaceLayer : GameInterfaceLayer
  {
    private GameInterfaceDrawMethod _drawMethod;

    public LegacyGameInterfaceLayer(
      string name,
      GameInterfaceDrawMethod drawMethod,
      InterfaceScaleType scaleType = InterfaceScaleType.Game)
      : base(name, scaleType)
    {
      this._drawMethod = drawMethod;
    }

    protected override bool DrawSelf() => this._drawMethod();
  }
}
