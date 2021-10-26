// Decompiled with JetBrains decompiler
// Type: Terraria.ClientSock
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Net.Sockets;

namespace Terraria
{
  public class ClientSock
  {
    public TcpClient tcpClient = new TcpClient();
    public NetworkStream networkStream;
    public string statusText;
    public int statusCount;
    public int statusMax;
    public int timeOut;
    public byte[] readBuffer;
    public byte[] writeBuffer;
    public bool active;
    public bool locked;
    public int state;

    public void ClientWriteCallBack(IAsyncResult ar) => --NetMessage.buffer[256].spamCount;

    public void ClientReadCallBack(IAsyncResult ar)
    {
      if (!Netplay.disconnect)
      {
        int streamLength = this.networkStream.EndRead(ar);
        if (streamLength == 0)
        {
          Netplay.disconnect = true;
          Main.statusText = "Lost connection";
        }
        else if (Main.ignoreErrors)
        {
          try
          {
            NetMessage.RecieveBytes(this.readBuffer, streamLength);
          }
          catch
          {
          }
        }
        else
          NetMessage.RecieveBytes(this.readBuffer, streamLength);
      }
      this.locked = false;
    }
  }
}
