// Decompiled with JetBrains decompiler
// Type: Terraria.IO.ResourcePackList
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Terraria.IO
{
  public class ResourcePackList
  {
    private readonly List<ResourcePack> _resourcePacks = new List<ResourcePack>();

    public IEnumerable<ResourcePack> EnabledPacks => (IEnumerable<ResourcePack>) this._resourcePacks.Where<ResourcePack>((Func<ResourcePack, bool>) (pack => pack.IsEnabled)).OrderBy<ResourcePack, int>((Func<ResourcePack, int>) (pack => pack.SortingOrder)).ThenBy<ResourcePack, string>((Func<ResourcePack, string>) (pack => pack.Name)).ThenBy<ResourcePack, ResourcePackVersion>((Func<ResourcePack, ResourcePackVersion>) (pack => pack.Version)).ThenBy<ResourcePack, string>((Func<ResourcePack, string>) (pack => pack.FileName));

    public IEnumerable<ResourcePack> DisabledPacks => (IEnumerable<ResourcePack>) this._resourcePacks.Where<ResourcePack>((Func<ResourcePack, bool>) (pack => !pack.IsEnabled)).OrderBy<ResourcePack, string>((Func<ResourcePack, string>) (pack => pack.Name)).ThenBy<ResourcePack, ResourcePackVersion>((Func<ResourcePack, ResourcePackVersion>) (pack => pack.Version)).ThenBy<ResourcePack, string>((Func<ResourcePack, string>) (pack => pack.FileName));

    public IEnumerable<ResourcePack> AllPacks => (IEnumerable<ResourcePack>) this._resourcePacks.OrderBy<ResourcePack, string>((Func<ResourcePack, string>) (pack => pack.Name)).ThenBy<ResourcePack, ResourcePackVersion>((Func<ResourcePack, ResourcePackVersion>) (pack => pack.Version)).ThenBy<ResourcePack, string>((Func<ResourcePack, string>) (pack => pack.FileName));

    public ResourcePackList()
    {
    }

    public ResourcePackList(IEnumerable<ResourcePack> resourcePacks) => this._resourcePacks.AddRange(resourcePacks);

    public JArray ToJson()
    {
      List<ResourcePackList.ResourcePackEntry> resourcePackEntryList = new List<ResourcePackList.ResourcePackEntry>(this._resourcePacks.Count);
      resourcePackEntryList.AddRange(this._resourcePacks.Select<ResourcePack, ResourcePackList.ResourcePackEntry>((Func<ResourcePack, ResourcePackList.ResourcePackEntry>) (pack => new ResourcePackList.ResourcePackEntry(pack.FileName, pack.IsEnabled, pack.SortingOrder))));
      return JArray.FromObject((object) resourcePackEntryList);
    }

    public static ResourcePackList FromJson(
      JArray serializedState,
      IServiceProvider services,
      string searchPath)
    {
      if (!Directory.Exists(searchPath))
        return new ResourcePackList();
      List<ResourcePack> source = new List<ResourcePack>();
      foreach (ResourcePackList.ResourcePackEntry resourcePackEntry in ResourcePackList.CreatePackEntryListFromJson(serializedState))
      {
        if (resourcePackEntry.FileName != null)
        {
          string path = Path.Combine(searchPath, resourcePackEntry.FileName);
          try
          {
            if (!File.Exists(path))
            {
              if (!Directory.Exists(path))
                continue;
            }
            ResourcePack resourcePack = new ResourcePack(services, path)
            {
              IsEnabled = resourcePackEntry.Enabled,
              SortingOrder = resourcePackEntry.SortingOrder
            };
            source.Add(resourcePack);
          }
          catch (Exception ex)
          {
            Console.WriteLine("Failed to read resource pack {0}: {1}", (object) path, (object) ex);
          }
        }
      }
      foreach (string file in Directory.GetFiles(searchPath, "*.zip"))
      {
        try
        {
          string fileName = Path.GetFileName(file);
          if (source.All<ResourcePack>((Func<ResourcePack, bool>) (pack => pack.FileName != fileName)))
            source.Add(new ResourcePack(services, file));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Failed to read resource pack {0}: {1}", (object) file, (object) ex);
        }
      }
      foreach (string directory in Directory.GetDirectories(searchPath))
      {
        try
        {
          string folderName = Path.GetFileName(directory);
          if (source.All<ResourcePack>((Func<ResourcePack, bool>) (pack => pack.FileName != folderName)))
            source.Add(new ResourcePack(services, directory));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Failed to read resource pack {0}: {1}", (object) directory, (object) ex);
        }
      }
      return new ResourcePackList((IEnumerable<ResourcePack>) source);
    }

    private static IEnumerable<ResourcePackList.ResourcePackEntry> CreatePackEntryListFromJson(
      JArray serializedState)
    {
      try
      {
        if (((JContainer) serializedState).Count != 0)
          return (IEnumerable<ResourcePackList.ResourcePackEntry>) ((JToken) serializedState).ToObject<List<ResourcePackList.ResourcePackEntry>>();
      }
      catch (JsonReaderException ex)
      {
        Console.WriteLine("Failed to parse configuration entry for resource pack list. {0}", (object) ex);
      }
      return (IEnumerable<ResourcePackList.ResourcePackEntry>) new List<ResourcePackList.ResourcePackEntry>();
    }

    private struct ResourcePackEntry
    {
      public string FileName;
      public bool Enabled;
      public int SortingOrder;

      public ResourcePackEntry(string name, bool enabled, int sortingOrder)
      {
        this.FileName = name;
        this.Enabled = enabled;
        this.SortingOrder = sortingOrder;
      }
    }
  }
}
