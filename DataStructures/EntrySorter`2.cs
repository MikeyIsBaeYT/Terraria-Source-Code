// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.EntrySorter`2
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.DataStructures
{
  public class EntrySorter<TEntryType, TStepType> : IComparer<TEntryType>
    where TEntryType : new()
    where TStepType : IEntrySortStep<TEntryType>
  {
    public List<TStepType> Steps = new List<TStepType>();
    private int _prioritizedStep;

    public void AddSortSteps(List<TStepType> sortSteps) => this.Steps.AddRange((IEnumerable<TStepType>) sortSteps);

    public int Compare(TEntryType x, TEntryType y)
    {
      int num = 0;
      if (this._prioritizedStep != -1)
      {
        num = this.Steps[this._prioritizedStep].Compare(x, y);
        if (num != 0)
          return num;
      }
      for (int index = 0; index < this.Steps.Count; ++index)
      {
        if (index != this._prioritizedStep)
        {
          num = this.Steps[index].Compare(x, y);
          if (num != 0)
            return num;
        }
      }
      return num;
    }

    public void SetPrioritizedStepIndex(int index) => this._prioritizedStep = index;

    public string GetDisplayName() => Language.GetTextValue(this.Steps[this._prioritizedStep].GetDisplayNameKey());
  }
}
