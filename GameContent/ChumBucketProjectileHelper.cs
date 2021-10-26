// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ChumBucketProjectileHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.GameContent
{
  public class ChumBucketProjectileHelper
  {
    private Dictionary<Point, int> _chumCountsPendingForThisFrame = new Dictionary<Point, int>();
    private Dictionary<Point, int> _chumCountsFromLastFrame = new Dictionary<Point, int>();

    public void OnPreUpdateAllProjectiles()
    {
      Utils.Swap<Dictionary<Point, int>>(ref this._chumCountsPendingForThisFrame, ref this._chumCountsFromLastFrame);
      this._chumCountsPendingForThisFrame.Clear();
    }

    public void AddChumLocation(Vector2 spot)
    {
      Point tileCoordinates = spot.ToTileCoordinates();
      int num1 = 0;
      this._chumCountsPendingForThisFrame.TryGetValue(tileCoordinates, out num1);
      int num2 = num1 + 1;
      this._chumCountsPendingForThisFrame[tileCoordinates] = num2;
    }

    public int GetChumsInLocation(Point tileCoords)
    {
      int num = 0;
      this._chumCountsFromLastFrame.TryGetValue(tileCoords, out num);
      return num;
    }
  }
}
