// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.CloudSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;
using System.Collections.Generic;

namespace Terraria.Social.WeGame
{
  public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
  {
    private object ioLock = new object();

    public override void Initialize() => base.Initialize();

    public override void Shutdown()
    {
    }

    public override IEnumerable<string> GetFiles()
    {
      lock (this.ioLock)
      {
        uint fileCount = rail_api.RailFactory().RailStorageHelper().GetFileCount();
        List<string> stringList = new List<string>((int) fileCount);
        ulong num = 0;
        for (uint index = 0; index < fileCount; ++index)
        {
          string str;
          rail_api.RailFactory().RailStorageHelper().GetFileNameAndSize(index, ref str, ref num);
          stringList.Add(str);
        }
        return (IEnumerable<string>) stringList;
      }
    }

    public override bool Write(string path, byte[] data, int length)
    {
      lock (this.ioLock)
      {
        bool flag = true;
        IRailFile irailFile = !rail_api.RailFactory().RailStorageHelper().IsFileExist(path) ? rail_api.RailFactory().RailStorageHelper().CreateFile(path) : rail_api.RailFactory().RailStorageHelper().OpenFile(path);
        if (irailFile != null)
        {
          int num = (int) irailFile.Write(data, (uint) length);
          irailFile.Close();
        }
        else
          flag = false;
        return flag;
      }
    }

    public override int GetFileSize(string path)
    {
      lock (this.ioLock)
      {
        IRailFile irailFile = rail_api.RailFactory().RailStorageHelper().OpenFile(path);
        if (irailFile == null)
          return 0;
        int size = (int) irailFile.GetSize();
        irailFile.Close();
        return size;
      }
    }

    public override void Read(string path, byte[] buffer, int size)
    {
      lock (this.ioLock)
      {
        IRailFile irailFile = rail_api.RailFactory().RailStorageHelper().OpenFile(path);
        if (irailFile == null)
          return;
        int num = (int) irailFile.Read(buffer, (uint) size);
        irailFile.Close();
      }
    }

    public override bool HasFile(string path)
    {
      lock (this.ioLock)
        return rail_api.RailFactory().RailStorageHelper().IsFileExist(path);
    }

    public override bool Delete(string path)
    {
      lock (this.ioLock)
        return rail_api.RailFactory().RailStorageHelper().RemoveFile(path) == 0;
    }
  }
}
