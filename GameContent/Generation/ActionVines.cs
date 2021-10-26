// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionVines
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class ActionVines : GenAction
  {
    private int _minLength;
    private int _maxLength;
    private int _vineId;

    public ActionVines(int minLength = 6, int maxLength = 10, int vineId = 52)
    {
      this._minLength = minLength;
      this._maxLength = maxLength;
      this._vineId = vineId;
    }

    public override bool Apply(Point origin, int x, int y, params object[] args)
    {
      int num1 = GenBase._random.Next(this._minLength, this._maxLength + 1);
      int num2;
      for (num2 = 0; num2 < num1 && !GenBase._tiles[x, y + num2].active(); ++num2)
      {
        GenBase._tiles[x, y + num2].type = (ushort) this._vineId;
        GenBase._tiles[x, y + num2].active(true);
      }
      return num2 > 0 && this.UnitApply(origin, x, y, args);
    }
  }
}
