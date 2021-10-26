// Decompiled with JetBrains decompiler
// Type: Terraria.Net.Sockets.ISocket
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Net.Sockets
{
  public interface ISocket
  {
    void Close();

    bool IsConnected();

    void Connect(RemoteAddress address);

    void AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state = null);

    void AsyncReceive(
      byte[] data,
      int offset,
      int size,
      SocketReceiveCallback callback,
      object state = null);

    bool IsDataAvailable();

    void SendQueuedPackets();

    bool StartListening(SocketConnectionAccepted callback);

    void StopListening();

    RemoteAddress GetRemoteAddress();
  }
}
