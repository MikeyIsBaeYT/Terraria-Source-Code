// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.IPCBase
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;

namespace Terraria.Social.WeGame
{
  public abstract class IPCBase
  {
    private List<List<byte>> _producer = new List<List<byte>>();
    private List<List<byte>> _consumer = new List<List<byte>>();
    private List<byte> _totalData = new List<byte>();
    private object _listLock = new object();
    private volatile bool _haveDataToReadFlag;
    protected volatile bool _pipeBrokenFlag;
    protected PipeStream _pipeStream;
    protected CancellationTokenSource _cancelTokenSrc;
    protected Action<byte[]> _onDataArrive;

    public int BufferSize { set; get; }

    public virtual event Action<byte[]> OnDataArrive
    {
      add => this._onDataArrive += value;
      remove => this._onDataArrive -= value;
    }

    public IPCBase() => this.BufferSize = 256;

    protected void AddPackToList(List<byte> pack)
    {
      lock (this._listLock)
      {
        this._producer.Add(pack);
        this._haveDataToReadFlag = true;
      }
    }

    protected List<List<byte>> GetPackList()
    {
      List<List<byte>> byteListList = (List<List<byte>>) null;
      lock (this._listLock)
      {
        List<List<byte>> producer = this._producer;
        this._producer = this._consumer;
        this._consumer = producer;
        this._producer.Clear();
        byteListList = this._consumer;
        this._haveDataToReadFlag = false;
      }
      return byteListList;
    }

    protected bool HaveDataToRead() => this._haveDataToReadFlag;

    public virtual void Reset()
    {
      this._cancelTokenSrc.Cancel();
      this._pipeStream.Dispose();
      this._pipeStream = (PipeStream) null;
    }

    public virtual void ProcessDataArriveEvent()
    {
      if (!this.HaveDataToRead())
        return;
      List<List<byte>> packList = this.GetPackList();
      if (packList == null || this._onDataArrive == null)
        return;
      foreach (List<byte> byteList in packList)
        this._onDataArrive(byteList.ToArray());
    }

    protected virtual bool BeginReadData()
    {
      bool flag = false;
      IPCContent ipcContent = new IPCContent()
      {
        data = new byte[this.BufferSize],
        CancelToken = this._cancelTokenSrc.Token
      };
      WeGameHelper.WriteDebugString(nameof (BeginReadData));
      try
      {
        if (this._pipeStream != null)
        {
          this._pipeStream.BeginRead(ipcContent.data, 0, this.BufferSize, new AsyncCallback(this.ReadCallback), (object) ipcContent);
          flag = true;
        }
      }
      catch (IOException ex)
      {
        this._pipeBrokenFlag = true;
        WeGameHelper.WriteDebugString("BeginReadData Exception, {0}", (object) ex.Message);
      }
      return flag;
    }

    public virtual void ReadCallback(IAsyncResult result)
    {
      WeGameHelper.WriteDebugString("ReadCallback: " + Thread.CurrentThread.ManagedThreadId.ToString());
      IPCContent asyncState = (IPCContent) result.AsyncState;
      try
      {
        int count = this._pipeStream.EndRead(result);
        if (!asyncState.CancelToken.IsCancellationRequested)
        {
          if (count <= 0)
            return;
          this._totalData.AddRange(((IEnumerable<byte>) asyncState.data).Take<byte>(count));
          if (!this._pipeStream.IsMessageComplete)
            return;
          this.AddPackToList(this._totalData);
          this._totalData = new List<byte>();
        }
        else
          WeGameHelper.WriteDebugString("IPCBase.ReadCallback.cancel");
      }
      catch (IOException ex)
      {
        this._pipeBrokenFlag = true;
        WeGameHelper.WriteDebugString("ReadCallback Exception, {0}", (object) ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        this._pipeBrokenFlag = true;
        WeGameHelper.WriteDebugString("ReadCallback Exception, {0}", (object) ex.Message);
      }
    }

    public virtual bool Send(string value) => this.Send(Encoding.UTF8.GetBytes(value));

    public virtual bool Send(byte[] data)
    {
      bool flag = false;
      if (this._pipeStream != null)
      {
        if (this._pipeStream.IsConnected)
        {
          try
          {
            this._pipeStream.BeginWrite(data, 0, data.Length, new AsyncCallback(this.SendCallback), (object) null);
            flag = true;
          }
          catch (IOException ex)
          {
            this._pipeBrokenFlag = true;
            WeGameHelper.WriteDebugString("Send Exception, {0}", (object) ex.Message);
          }
        }
      }
      return flag;
    }

    protected virtual void SendCallback(IAsyncResult result)
    {
      try
      {
        if (this._pipeStream == null)
          return;
        this._pipeStream.EndWrite(result);
      }
      catch (IOException ex)
      {
        this._pipeBrokenFlag = true;
        WeGameHelper.WriteDebugString("SendCallback Exception, {0}", (object) ex.Message);
      }
    }
  }
}
