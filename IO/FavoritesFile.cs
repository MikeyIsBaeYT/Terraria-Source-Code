// Decompiled with JetBrains decompiler
// Type: Terraria.IO.FavoritesFile
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Terraria.Utilities;

namespace Terraria.IO
{
  public class FavoritesFile
  {
    public readonly string Path;
    public readonly bool IsCloudSave;
    private Dictionary<string, Dictionary<string, bool>> _data = new Dictionary<string, Dictionary<string, bool>>();

    public FavoritesFile(string path, bool isCloud)
    {
      this.Path = path;
      this.IsCloudSave = isCloud;
    }

    public void SaveFavorite(FileData fileData)
    {
      if (!this._data.ContainsKey(fileData.Type))
        this._data.Add(fileData.Type, new Dictionary<string, bool>());
      this._data[fileData.Type][fileData.GetFileName()] = fileData.IsFavorite;
      this.Save();
    }

    public void ClearEntry(FileData fileData)
    {
      if (!this._data.ContainsKey(fileData.Type))
        return;
      this._data[fileData.Type].Remove(fileData.GetFileName());
      this.Save();
    }

    public bool IsFavorite(FileData fileData)
    {
      if (!this._data.ContainsKey(fileData.Type))
        return false;
      string fileName = fileData.GetFileName();
      bool flag;
      return this._data[fileData.Type].TryGetValue(fileName, out flag) && flag;
    }

    public void Save() => FileUtilities.WriteAllBytes(this.Path, Encoding.ASCII.GetBytes(JsonConvert.SerializeObject((object) this._data, (Formatting) 1)), this.IsCloudSave);

    public void Load()
    {
      if (!FileUtilities.Exists(this.Path, this.IsCloudSave))
      {
        this._data.Clear();
      }
      else
      {
        this._data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(Encoding.ASCII.GetString(FileUtilities.ReadAllBytes(this.Path, this.IsCloudSave)));
        if (this._data != null)
          return;
        this._data = new Dictionary<string, Dictionary<string, bool>>();
      }
    }
  }
}
