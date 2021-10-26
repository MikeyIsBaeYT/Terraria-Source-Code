// Decompiled with JetBrains decompiler
// Type: Terraria.UI.LegacyGameInterfaceLayer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
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
