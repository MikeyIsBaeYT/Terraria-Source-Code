// Decompiled with JetBrains decompiler
// Type: Terraria.Net.Sockets.TcpSocket
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.Localization;

namespace Terraria.Net.Sockets
{
  public class TcpSocket : ISocket
  {
    private byte[] _packetBuffer = new byte[1024];
    private int _packetBufferLength;
    private List<object> _callbackBuffer = new List<object>();
    private int _messagesInQueue;
    private TcpClient _connection;
    private TcpListener _listener;
    private SocketConnectionAccepted _listenerCallback;
    private RemoteAddress _remoteAddress;
    private bool _isListening;

    public int MessagesInQueue => this._messagesInQueue;

    public TcpSocket()
    {
      this._connection = new TcpClient();
      this._connection.NoDelay = true;
    }

    public TcpSocket(TcpClient tcpClient)
    {
      this._connection = tcpClient;
      this._connection.NoDelay = true;
      IPEndPoint remoteEndPoint = (IPEndPoint) tcpClient.Client.RemoteEndPoint;
      this._remoteAddress = (RemoteAddress) new TcpAddress(remoteEndPoint.Address, remoteEndPoint.Port);
    }

    void ISocket.Close()
    {
      this._remoteAddress = (RemoteAddress) null;
      this._connection.Close();
    }

    bool ISocket.IsConnected() => this._connection != null && this._connection.Client != null && this._connection.Connected;

    void ISocket.Connect(RemoteAddress address)
    {
      TcpAddress tcpAddress = (TcpAddress) address;
      this._connection.Connect(tcpAddress.Address, tcpAddress.Port);
      this._remoteAddress = address;
    }

    private void ReadCallback(IAsyncResult result)
    {
      Tuple<SocketReceiveCallback, object> asyncState = (Tuple<SocketReceiveCallback, object>) result.AsyncState;
      asyncState.Item1(asyncState.Item2, this._connection.GetStream().EndRead(result));
    }

    private void SendCallback(IAsyncResult result)
    {
      Tuple<SocketSendCallback, object> asyncState = (Tuple<SocketSendCallback, object>) result.AsyncState;
      try
      {
        this._connection.GetStream().EndWrite(result);
        asyncState.Item1(asyncState.Item2);
      }
      catch (Exception ex)
      {
        ((ISocket) this).Close();
      }
    }

    void ISocket.SendQueuedPackets()
    {
    }

    void ISocket.AsyncSend(
      byte[] data,
      int offset,
      int size,
      SocketSendCallback callback,
      object state)
    {
      this._connection.GetStream().BeginWrite(data, 0, size, new AsyncCallback(this.SendCallback), (object) new Tuple<SocketSendCallback, object>(callback, state));
    }

    void ISocket.AsyncReceive(
      byte[] data,
      int offset,
      int size,
      SocketReceiveCallback callback,
      object state)
    {
      this._connection.GetStream().BeginRead(data, offset, size, new AsyncCallback(this.ReadCallback), (object) new Tuple<SocketReceiveCallback, object>(callback, state));
    }

    bool ISocket.IsDataAvailable() => this._connection.GetStream().DataAvailable;

    RemoteAddress ISocket.GetRemoteAddress() => this._remoteAddress;

    bool ISocket.StartListening(SocketConnectionAccepted callback)
    {
      IPAddress address = IPAddress.Any;
      string ipString;
      if (Program.LaunchParameters.TryGetValue("-ip", out ipString) && !IPAddress.TryParse(ipString, out address))
        address = IPAddress.Any;
      this._isListening = true;
      this._listenerCallback = callback;
      if (this._listener == null)
        this._listener = new TcpListener(address, Netplay.ListenPort);
      try
      {
        this._listener.Start();
      }
      catch (Exception ex)
      {
        return false;
      }
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.ListenLoop));
      return true;
    }

    void ISocket.StopListening() => this._isListening = false;

    private void ListenLoop(object unused)
    {
      while (this._isListening)
      {
        if (!Netplay.disconnect)
        {
          try
          {
            ISocket client = (ISocket) new TcpSocket(this._listener.AcceptTcpClient());
            Console.WriteLine(Language.GetTextValue("Net.ClientConnecting", (object) client.GetRemoteAddress()));
            this._listenerCallback(client);
          }
          catch (Exception ex)
          {
          }
        }
        else
          break;
      }
      this._listener.Stop();
    }
  }
}
