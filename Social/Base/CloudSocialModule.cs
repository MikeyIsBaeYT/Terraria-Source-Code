// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.CloudSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.IO;

namespace Terraria.Social.Base
{
  public abstract class CloudSocialModule : ISocialModule
  {
    public bool EnabledByDefault;

    public virtual void Initialize()
    {
      Main.Configuration.OnLoad += (Action<Preferences>) (preferences => this.EnabledByDefault = preferences.Get<bool>("CloudSavingDefault", false));
      Main.Configuration.OnSave += (Action<Preferences>) (preferences => preferences.Put("CloudSavingDefault", (object) this.EnabledByDefault));
    }

    public abstract void Shutdown();

    public abstract IEnumerable<string> GetFiles();

    public abstract bool Write(string path, byte[] data, int length);

    public abstract void Read(string path, byte[] buffer, int length);

    public abstract bool HasFile(string path);

    public abstract int GetFileSize(string path);

    public abstract bool Delete(string path);

    public byte[] Read(string path)
    {
      byte[] buffer = new byte[this.GetFileSize(path)];
      this.Read(path, buffer, buffer.Length);
      return buffer;
    }

    public void Read(string path, byte[] buffer) => this.Read(path, buffer, buffer.Length);

    public bool Write(string path, byte[] data) => this.Write(path, data, data.Length);
  }
}
