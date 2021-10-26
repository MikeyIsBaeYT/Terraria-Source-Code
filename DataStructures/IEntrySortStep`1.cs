// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.IEntrySortStep`1
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.DataStructures
{
  public interface IEntrySortStep<T> : IComparer<T>
  {
    string GetDisplayNameKey();
  }
}
