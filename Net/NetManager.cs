// Decompiled with JetBrains decompiler
// Type: Terraria.Net.NetManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using System.IO;
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

    public void Read(BinaryReader reader, int userId, int readLength)
    {
      ushort key = reader.ReadUInt16();
      if (this._modules.ContainsKey(key))
        this._modules[key].Deserialize(reader, userId);
      Main.ActiveNetDiagnosticsUI.CountReadModuleMessage((int) key, readLength);
    }

    public void Broadcast(NetPacket packet, int ignoreClient = -1)
    {
      for (int index = 0; index < 256; ++index)
      {
        if (index != ignoreClient && Netplay.Clients[index].IsConnected())
          this.SendData(Netplay.Clients[index].Socket, packet);
      }
    }

    public void Broadcast(
      NetPacket packet,
      NetManager.BroadcastCondition conditionToBroadcast,
      int ignoreClient = -1)
    {
      for (int clientIndex = 0; clientIndex < 256; ++clientIndex)
      {
        if (clientIndex != ignoreClient && Netplay.Clients[clientIndex].IsConnected() && conditionToBroadcast(clientIndex))
          this.SendData(Netplay.Clients[clientIndex].Socket, packet);
      }
    }

    public void SendToSelf(NetPacket packet)
    {
      packet.Reader.BaseStream.Position = 3L;
      this.Read(packet.Reader, Main.myPlayer, packet.Length);
      NetManager.SendCallback((object) packet);
      Main.ActiveNetDiagnosticsUI.CountSentModuleMessage((int) packet.Id, packet.Length);
    }

    public void BroadcastOrLoopback(NetPacket packet)
    {
      if (Main.netMode == 2)
      {
        this.Broadcast(packet);
      }
      else
      {
        if (Main.netMode != 0)
          return;
        this.SendToSelf(packet);
      }
    }

    public void SendToServerOrLoopback(NetPacket packet)
    {
      if (Main.netMode == 1)
      {
        this.SendToServer(packet);
      }
      else
      {
        if (Main.netMode != 0)
          return;
        this.SendToSelf(packet);
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
      }
      Main.ActiveNetDiagnosticsUI.CountSentModuleMessage((int) packet.Id, packet.Length);
    }

    public static void SendCallback(object state) => ((NetPacket) state).Recycle();

    private class PacketTypeStorage<T> where T : NetModule
    {
      public static ushort Id;
      public static T Module;
    }

    public delegate bool BroadcastCondition(int clientIndex);
  }
}
