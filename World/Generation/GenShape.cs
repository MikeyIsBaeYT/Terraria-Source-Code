// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenShape
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
  public abstract class GenShape : GenBase
  {
    private ShapeData _outputData;
    protected bool _quitOnFail;

    public abstract bool Perform(Point origin, GenAction action);

    protected bool UnitApply(GenAction action, Point origin, int x, int y, params object[] args)
    {
      if (this._outputData != null)
        this._outputData.Add(x - origin.X, y - origin.Y);
      return action.Apply(origin, x, y, args);
    }

    public GenShape Output(ShapeData outputData)
    {
      this._outputData = outputData;
      return this;
    }

    public GenShape QuitOnFail(bool value = true)
    {
      this._quitOnFail = value;
      return this;
    }
  }
}
