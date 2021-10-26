// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenSearch
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.WorldBuilding
{
  public abstract class GenSearch : GenBase
  {
    public static Point NOT_FOUND = new Point(int.MaxValue, int.MaxValue);
    private bool _requireAll = true;
    private GenCondition[] _conditions;

    public GenSearch Conditions(params GenCondition[] conditions)
    {
      this._conditions = conditions;
      return this;
    }

    public abstract Point Find(Point origin);

    protected bool Check(int x, int y)
    {
      for (int index = 0; index < this._conditions.Length; ++index)
      {
        if (this._requireAll ^ this._conditions[index].IsValid(x, y))
          return !this._requireAll;
      }
      return this._requireAll;
    }

    public GenSearch RequireAll(bool mode)
    {
      this._requireAll = mode;
      return this;
    }
  }
}
