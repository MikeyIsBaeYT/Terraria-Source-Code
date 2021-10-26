// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.SteamP2PWriter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
  public class SteamP2PWriter
  {
    private const int BUFFER_SIZE = 1024;
    private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendData = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();
    private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendDataSwap = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();
    private Queue<byte[]> _bufferPool = new Queue<byte[]>();
    private int _channel;
    private object _lock = new object();

    public SteamP2PWriter(int channel) => this._channel = channel;

    public void QueueSend(CSteamID user, byte[] data, int length)
    {
      lock (this._lock)
      {
        Queue<SteamP2PWriter.WriteInformation> writeInformationQueue;
        if (this._pendingSendData.ContainsKey(user))
          writeInformationQueue = this._pendingSendData[user];
        else
          this._pendingSendData[user] = writeInformationQueue = new Queue<SteamP2PWriter.WriteInformation>();
        int val1 = length;
        int sourceIndex = 0;
        while (val1 > 0)
        {
          SteamP2PWriter.WriteInformation writeInformation;
          if (writeInformationQueue.Count == 0 || 1024 - writeInformationQueue.Peek().Size == 0)
          {
            writeInformation = this._bufferPool.Count <= 0 ? new SteamP2PWriter.WriteInformation() : new SteamP2PWriter.WriteInformation(this._bufferPool.Dequeue());
            writeInformationQueue.Enqueue(writeInformation);
          }
          else
            writeInformation = writeInformationQueue.Peek();
          int length1 = Math.Min(val1, 1024 - writeInformation.Size);
          Array.Copy((Array) data, sourceIndex, (Array) writeInformation.Data, writeInformation.Size, length1);
          writeInformation.Size += length1;
          val1 -= length1;
          sourceIndex += length1;
        }
      }
    }

    public void ClearUser(CSteamID user)
    {
      lock (this._lock)
      {
        if (this._pendingSendData.ContainsKey(user))
        {
          Queue<SteamP2PWriter.WriteInformation> writeInformationQueue = this._pendingSendData[user];
          while (writeInformationQueue.Count > 0)
            this._bufferPool.Enqueue(writeInformationQueue.Dequeue().Data);
        }
        if (!this._pendingSendDataSwap.ContainsKey(user))
          return;
        Queue<SteamP2PWriter.WriteInformation> writeInformationQueue1 = this._pendingSendDataSwap[user];
        while (writeInformationQueue1.Count > 0)
          this._bufferPool.Enqueue(writeInformationQueue1.Dequeue().Data);
      }
    }

    public void SendAll()
    {
      lock (this._lock)
        Utils.Swap<Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>>(ref this._pendingSendData, ref this._pendingSendDataSwap);
      foreach (KeyValuePair<CSteamID, Queue<SteamP2PWriter.WriteInformation>> keyValuePair in this._pendingSendDataSwap)
      {
        Queue<SteamP2PWriter.WriteInformation> writeInformationQueue = keyValuePair.Value;
        while (writeInformationQueue.Count > 0)
        {
          SteamP2PWriter.WriteInformation writeInformation = writeInformationQueue.Dequeue();
          SteamNetworking.SendP2PPacket(keyValuePair.Key, writeInformation.Data, (uint) writeInformation.Size, (EP2PSend) 2, this._channel);
          this._bufferPool.Enqueue(writeInformation.Data);
        }
      }
    }

    public class WriteInformation
    {
      public byte[] Data;
      public int Size;

      public WriteInformation()
      {
        this.Data = new byte[1024];
        this.Size = 0;
      }

      public WriteInformation(byte[] data)
      {
        this.Data = data;
        this.Size = 0;
      }
    }
  }
}
