// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.WeGameP2PReader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;
using System;
using System.Collections.Generic;

namespace Terraria.Social.WeGame
{
  public class WeGameP2PReader
  {
    public object RailLock = new object();
    private const int BUFFER_SIZE = 4096;
    private Dictionary<RailID, Queue<WeGameP2PReader.ReadResult>> _pendingReadBuffers = new Dictionary<RailID, Queue<WeGameP2PReader.ReadResult>>();
    private Queue<RailID> _deletionQueue = new Queue<RailID>();
    private Queue<byte[]> _bufferPool = new Queue<byte[]>();
    private WeGameP2PReader.OnReadEvent _readEvent;
    private RailID _local_id;

    public void ClearUser(RailID id)
    {
      lock (this._pendingReadBuffers)
        this._deletionQueue.Enqueue(id);
    }

    public bool IsDataAvailable(RailID id)
    {
      lock (this._pendingReadBuffers)
      {
        if (!this._pendingReadBuffers.ContainsKey(id))
          return false;
        Queue<WeGameP2PReader.ReadResult> pendingReadBuffer = this._pendingReadBuffers[id];
        return pendingReadBuffer.Count != 0 && pendingReadBuffer.Peek().Size != 0U;
      }
    }

    public void SetReadEvent(WeGameP2PReader.OnReadEvent method) => this._readEvent = method;

    private bool IsPacketAvailable(out uint size)
    {
      lock (this.RailLock)
      {
        IRailNetwork irailNetwork = rail_api.RailFactory().RailNetworkHelper();
        RailID railId1 = new RailID();
        ((RailComparableID) railId1).id_ = ((RailComparableID) this.GetLocalPeer()).id_;
        RailID railId2 = railId1;
        ref uint local = ref size;
        return irailNetwork.IsDataReady(railId2, ref local);
      }
    }

    private RailID GetLocalPeer() => this._local_id;

    public void SetLocalPeer(RailID rail_id)
    {
      if (RailComparableID.op_Equality((RailComparableID) this._local_id, (RailComparableID) null))
        this._local_id = new RailID();
      ((RailComparableID) this._local_id).id_ = ((RailComparableID) rail_id).id_;
    }

    private bool IsValid() => RailComparableID.op_Inequality((RailComparableID) this._local_id, (RailComparableID) null) && ((RailComparableID) this._local_id).IsValid();

    public void ReadTick()
    {
      if (!this.IsValid())
        return;
      lock (this._pendingReadBuffers)
      {
        while (this._deletionQueue.Count > 0)
          this._pendingReadBuffers.Remove(this._deletionQueue.Dequeue());
        uint size;
        while (this.IsPacketAvailable(out size))
        {
          byte[] data = this._bufferPool.Count != 0 ? this._bufferPool.Dequeue() : new byte[(int) Math.Max(size, 4096U)];
          RailID railId = new RailID();
          bool flag;
          lock (this.RailLock)
            flag = rail_api.RailFactory().RailNetworkHelper().ReadData(this.GetLocalPeer(), railId, data, size) == 0;
          if (flag)
          {
            if (this._readEvent == null || this._readEvent(data, (int) size, railId))
            {
              if (!this._pendingReadBuffers.ContainsKey(railId))
                this._pendingReadBuffers[railId] = new Queue<WeGameP2PReader.ReadResult>();
              this._pendingReadBuffers[railId].Enqueue(new WeGameP2PReader.ReadResult(data, size));
            }
            else
              this._bufferPool.Enqueue(data);
          }
        }
      }
    }

    public int Receive(RailID user, byte[] buffer, int bufferOffset, int bufferSize)
    {
      uint num1 = 0;
      lock (this._pendingReadBuffers)
      {
        if (!this._pendingReadBuffers.ContainsKey(user))
          return 0;
        Queue<WeGameP2PReader.ReadResult> pendingReadBuffer = this._pendingReadBuffers[user];
        while (pendingReadBuffer.Count > 0)
        {
          WeGameP2PReader.ReadResult readResult = pendingReadBuffer.Peek();
          uint num2 = Math.Min((uint) bufferSize - num1, readResult.Size - readResult.Offset);
          if (num2 == 0U)
            return (int) num1;
          Array.Copy((Array) readResult.Data, (long) readResult.Offset, (Array) buffer, (long) bufferOffset + (long) num1, (long) num2);
          if ((int) num2 == (int) readResult.Size - (int) readResult.Offset)
            this._bufferPool.Enqueue(pendingReadBuffer.Dequeue().Data);
          else
            readResult.Offset += num2;
          num1 += num2;
        }
      }
      return (int) num1;
    }

    public class ReadResult
    {
      public byte[] Data;
      public uint Size;
      public uint Offset;

      public ReadResult(byte[] data, uint size)
      {
        this.Data = data;
        this.Size = size;
        this.Offset = 0U;
      }
    }

    public delegate bool OnReadEvent(byte[] data, int size, RailID user);
  }
}
