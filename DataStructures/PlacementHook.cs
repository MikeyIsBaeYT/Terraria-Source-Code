// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlacementHook
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.DataStructures
{
  public struct PlacementHook
  {
    public Func<int, int, int, int, int, int> hook;
    public int badReturn;
    public int badResponse;
    public bool processedCoordinates;
    public static PlacementHook Empty = new PlacementHook((Func<int, int, int, int, int, int>) null, 0, 0, false);
    public const int Response_AllInvalid = 0;

    public PlacementHook(
      Func<int, int, int, int, int, int> hook,
      int badReturn,
      int badResponse,
      bool processedCoordinates)
    {
      this.hook = hook;
      this.badResponse = badResponse;
      this.badReturn = badReturn;
      this.processedCoordinates = processedCoordinates;
    }

    public static bool operator ==(PlacementHook first, PlacementHook second) => first.hook == second.hook && first.badResponse == second.badResponse && first.badReturn == second.badReturn && first.processedCoordinates == second.processedCoordinates;

    public static bool operator !=(PlacementHook first, PlacementHook second) => first.hook != second.hook || first.badResponse != second.badResponse || first.badReturn != second.badReturn || first.processedCoordinates != second.processedCoordinates;

    public override bool Equals(object obj) => obj is PlacementHook placementHook && this == placementHook;

    public override int GetHashCode() => base.GetHashCode();
  }
}
