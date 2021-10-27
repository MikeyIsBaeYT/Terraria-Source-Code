// Decompiled with JetBrains decompiler
// Type: Terraria.Net.NetManager
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria.Net
{
  public class NetManager
  {
    public static readonly NetManager Instance = new NetManager();
    private Dictionary<ushort, NetModule> _modules = new Dictionary<ushort, NetModule>();
    private ushort _moduleCount;

    private NetManager()
    {
    }

    public void Register<T>() where T : NetModule, new()
    {
      T obj = new T();
      NetManager.PacketTypeStorage<T>.Id = this._moduleCount;
      NetManager.PacketTypeStorage<T>.Module = obj;
      this._modules[this._moduleCount] = (NetModule) obj;
      ++this._moduleCount;
    }

    public NetModule GetModule<T>() where T : NetModule => (NetModule) NetManager.PacketTypeStorage<T>.Module;

    public ushort GetId<T>() where T : NetModule => NetManager.PacketTypeStorage<T>.Id;

    public void Read(BinaryReader reader, int userId)
    {
      ushort key = reader.ReadUInt16();
      if (!this._modules.ContainsKey(key))
        return;
      this._modules[key].Deserialize(reader, userId);
    }

    public void Broadcast(NetPacket packet, int ignoreClient = -1)
    {
      for (int index = 0; index < 256; ++index)
      {
        if (index != ignoreClient && Netplay.Clients[index].IsConnected())
          this.SendData(Netplay.Clients[index].Socket, packet);
      }
    }

    public void SendToServer(NetPacket packet) => this.SendData(Netplay.Connection.Socket, packet);

    public void SendToClient(NetPacket packet, int playerId) => this.SendData(Netplay.Clients[playerId].Socket, packet);

    private void SendData(ISocket socket, NetPacket packet)
    {
      if (Main.netMode == 0)
        return;
      packet.ShrinkToFit();
      try
      {
        socket.AsyncSend(packet.Buffer.Data, 0, packet.Length, new SocketSendCallback(NetManager.SendCallback), (object) packet);
      }
      catch
      {
        Console.WriteLine(Language.GetTextValue("Error.ExceptionNormal", (object) Language.GetTextValue("Error.DataSentAfterConnectionLost")));
      }
    }

    public static void SendCallback(object state) => ((NetPacket) state).Recycle();

    private class PacketTypeStorage<T> where T : NetModule
    {
      public static ushort Id;
      public static T Module;
    }
  }
}
