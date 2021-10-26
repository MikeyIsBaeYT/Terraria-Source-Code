// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.CloudSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
  public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
  {
    private const uint WRITE_CHUNK_SIZE = 1024;
    private object ioLock = new object();
    private byte[] writeBuffer = new byte[1024];

    public override void Initialize() => base.Initialize();

    public override void Shutdown()
    {
    }

    public override IEnumerable<string> GetFiles()
    {
      lock (this.ioLock)
      {
        int fileCount = SteamRemoteStorage.GetFileCount();
        List<string> stringList = new List<string>(fileCount);
        for (int index = 0; index < fileCount; ++index)
        {
          int num;
          stringList.Add(SteamRemoteStorage.GetFileNameAndSize(index, ref num));
        }
        return (IEnumerable<string>) stringList;
      }
    }

    public override bool Write(string path, byte[] data, int length)
    {
      lock (this.ioLock)
      {
        UGCFileWriteStreamHandle_t writeStreamHandleT = SteamRemoteStorage.FileWriteStreamOpen(path);
        for (uint index = 0; (long) index < (long) length; index += 1024U)
        {
          int num = (int) Math.Min(1024L, (long) length - (long) index);
          Array.Copy((Array) data, (long) index, (Array) this.writeBuffer, 0L, (long) num);
          SteamRemoteStorage.FileWriteStreamWriteChunk(writeStreamHandleT, this.writeBuffer, num);
        }
        return SteamRemoteStorage.FileWriteStreamClose(writeStreamHandleT);
      }
    }

    public override int GetFileSize(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.GetFileSize(path);
    }

    public override void Read(string path, byte[] buffer, int size)
    {
      lock (this.ioLock)
        SteamRemoteStorage.FileRead(path, buffer, size);
    }

    public override bool HasFile(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.FileExists(path);
    }

    public override bool Delete(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.FileDelete(path);
    }
  }
}
