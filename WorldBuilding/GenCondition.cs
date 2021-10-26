// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenCondition
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.WorldBuilding
{
  public abstract class GenCondition : GenBase
  {
    private bool InvertResults;
    private int _width;
    private int _height;
    private GenCondition.AreaType _areaType = GenCondition.AreaType.None;

    public bool IsValid(int x, int y)
    {
      switch (this._areaType)
      {
        case GenCondition.AreaType.And:
          for (int x1 = x; x1 < x + this._width; ++x1)
          {
            for (int y1 = y; y1 < y + this._height; ++y1)
            {
              if (!this.CheckValidity(x1, y1))
                return this.InvertResults;
            }
          }
          return !this.InvertResults;
        case GenCondition.AreaType.Or:
          for (int x2 = x; x2 < x + this._width; ++x2)
          {
            for (int y2 = y; y2 < y + this._height; ++y2)
            {
              if (this.CheckValidity(x2, y2))
                return !this.InvertResults;
            }
          }
          return this.InvertResults;
        case GenCondition.AreaType.None:
          return this.CheckValidity(x, y) ^ this.InvertResults;
        default:
          return true;
      }
    }

    public GenCondition Not()
    {
      this.InvertResults = !this.InvertResults;
      return this;
    }

    public GenCondition AreaOr(int width, int height)
    {
      this._areaType = GenCondition.AreaType.Or;
      this._width = width;
      this._height = height;
      return this;
    }

    public GenCondition AreaAnd(int width, int height)
    {
      this._areaType = GenCondition.AreaType.And;
      this._width = width;
      this._height = height;
      return this;
    }

    protected abstract bool CheckValidity(int x, int y);

    private enum AreaType
    {
      And,
      Or,
      None,
    }
  }
}
