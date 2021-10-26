// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.WeGameP2PWriter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;
using System;
using System.Collections.Generic;

namespace Terraria.Social.WeGame
{
  public class WeGameP2PWriter
  {
    private const int BUFFER_SIZE = 1024;
    private RailID _local_id;
    private Dictionary<RailID, Queue<WeGameP2PWriter.WriteInformation>> _pendingSendData = new Dictionary<RailID, Queue<WeGameP2PWriter.WriteInformation>>();
    private Dictionary<RailID, Queue<WeGameP2PWriter.WriteInformation>> _pendingSendDataSwap = new Dictionary<RailID, Queue<WeGameP2PWriter.WriteInformation>>();
    private Queue<byte[]> _bufferPool = new Queue<byte[]>();
    private object _lock = new object();

    public void QueueSend(RailID user, byte[] data, int length)
    {
      lock (this._lock)
      {
        Queue<WeGameP2PWriter.WriteInformation> writeInformationQueue;
        if (this._pendingSendData.ContainsKey(user))
          writeInformationQueue = this._pendingSendData[user];
        else
          this._pendingSendData[user] = writeInformationQueue = new Queue<WeGameP2PWriter.WriteInformation>();
        int val1 = length;
        int sourceIndex = 0;
        while (val1 > 0)
        {
          WeGameP2PWriter.WriteInformation writeInformation;
          if (writeInformationQueue.Count == 0 || 1024 - writeInformationQueue.Peek().Size == 0)
          {
            writeInformation = this._bufferPool.Count <= 0 ? new WeGameP2PWriter.WriteInformation() : new WeGameP2PWriter.WriteInformation(this._bufferPool.Dequeue());
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

    public void ClearUser(RailID user)
    {
      lock (this._lock)
      {
        if (this._pendingSendData.ContainsKey(user))
        {
          Queue<WeGameP2PWriter.WriteInformation> writeInformationQueue = this._pendingSendData[user];
          while (writeInformationQueue.Count > 0)
            this._bufferPool.Enqueue(writeInformationQueue.Dequeue().Data);
        }
        if (!this._pendingSendDataSwap.ContainsKey(user))
          return;
        Queue<WeGameP2PWriter.WriteInformation> writeInformationQueue1 = this._pendingSendDataSwap[user];
        while (writeInformationQueue1.Count > 0)
          this._bufferPool.Enqueue(writeInformationQueue1.Dequeue().Data);
      }
    }

    public void SetLocalPeer(RailID rail_id)
    {
      if (RailComparableID.op_Equality((RailComparableID) this._local_id, (RailComparableID) null))
        this._local_id = new RailID();
      ((RailComparableID) this._local_id).id_ = ((RailComparableID) rail_id).id_;
    }

    private RailID GetLocalPeer() => this._local_id;

    private bool IsValid() => RailComparableID.op_Inequality((RailComparableID) this._local_id, (RailComparableID) null) && ((RailComparableID) this._local_id).IsValid();

    public void SendAll()
    {
      if (!this.IsValid())
        return;
      lock (this._lock)
        Utils.Swap<Dictionary<RailID, Queue<WeGameP2PWriter.WriteInformation>>>(ref this._pendingSendData, ref this._pendingSendDataSwap);
      foreach (KeyValuePair<RailID, Queue<WeGameP2PWriter.WriteInformation>> keyValuePair in this._pendingSendDataSwap)
      {
        Queue<WeGameP2PWriter.WriteInformation> writeInformationQueue = keyValuePair.Value;
        while (writeInformationQueue.Count > 0)
        {
          WeGameP2PWriter.WriteInformation writeInformation = writeInformationQueue.Dequeue();
          int num = rail_api.RailFactory().RailNetworkHelper().SendData(this.GetLocalPeer(), keyValuePair.Key, writeInformation.Data, (uint) writeInformation.Size) == 0 ? 1 : 0;
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
