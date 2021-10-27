// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenAction
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
  public abstract class GenAction : GenBase
  {
    public GenAction NextAction;
    public ShapeData OutputData;
    private bool _returnFalseOnFailure = true;

    public abstract bool Apply(Point origin, int x, int y, params object[] args);

    protected bool UnitApply(Point origin, int x, int y, params object[] args)
    {
      if (this.OutputData != null)
        this.OutputData.Add(x - origin.X, y - origin.Y);
      return this.NextAction == null || this.NextAction.Apply(origin, x, y, args);
    }

    public GenAction IgnoreFailures()
    {
      this._returnFalseOnFailure = false;
      return this;
    }

    protected bool Fail() => !this._returnFalseOnFailure;

    public GenAction Output(ShapeData data)
    {
      this.OutputData = data;
      return this;
    }
  }
}
