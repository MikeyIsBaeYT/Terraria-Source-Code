// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.EntryFilterer`2
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.DataStructures
{
  public class EntryFilterer<T, U>
    where T : new()
    where U : IEntryFilter<T>
  {
    public List<U> AvailableFilters;
    public List<U> ActiveFilters;
    public List<U> AlwaysActiveFilters;
    private ISearchFilter<T> _searchFilter;
    private ISearchFilter<T> _searchFilterFromConstructor;

    public EntryFilterer()
    {
      this.AvailableFilters = new List<U>();
      this.ActiveFilters = new List<U>();
      this.AlwaysActiveFilters = new List<U>();
    }

    public void AddFilters(List<U> filters) => this.AvailableFilters.AddRange((IEnumerable<U>) filters);

    public bool FitsFilter(T entry)
    {
      if (this._searchFilter != null && !this._searchFilter.FitsFilter(entry))
        return false;
      for (int index = 0; index < this.AlwaysActiveFilters.Count; ++index)
      {
        if (!this.AlwaysActiveFilters[index].FitsFilter(entry))
          return false;
      }
      if (this.ActiveFilters.Count == 0)
        return true;
      for (int index = 0; index < this.ActiveFilters.Count; ++index)
      {
        if (this.ActiveFilters[index].FitsFilter(entry))
          return true;
      }
      return false;
    }

    public void ToggleFilter(int filterIndex)
    {
      U availableFilter = this.AvailableFilters[filterIndex];
      if (this.ActiveFilters.Contains(availableFilter))
        this.ActiveFilters.Remove(availableFilter);
      else
        this.ActiveFilters.Add(availableFilter);
    }

    public bool IsFilterActive(int filterIndex) => this.AvailableFilters.IndexInRange<U>(filterIndex) && this.ActiveFilters.Contains(this.AvailableFilters[filterIndex]);

    public void SetSearchFilterObject<Z>(Z searchFilter) where Z : ISearchFilter<T>, U => this._searchFilterFromConstructor = (ISearchFilter<T>) searchFilter;

    public void SetSearchFilter(string searchFilter)
    {
      if (string.IsNullOrWhiteSpace(searchFilter))
      {
        this._searchFilter = (ISearchFilter<T>) null;
      }
      else
      {
        this._searchFilter = this._searchFilterFromConstructor;
        this._searchFilter.SetSearch(searchFilter);
      }
    }

    public string GetDisplayName() => Language.GetTextValueWith("BestiaryInfo.Filters", (object) new
    {
      Count = this.ActiveFilters.Count
    });
  }
}
