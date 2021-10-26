// Decompiled with JetBrains decompiler
// Type: Terraria.Netplay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.Audio;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Map;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
  public class Netplay
  {
    public const int MaxConnections = 256;
    public const int NetBufferSize = 1024;
    public static string BanFilePath = "banlist.txt";
    public static string ServerPassword = "";
    public static RemoteClient[] Clients = new RemoteClient[256];
    public static RemoteServer Connection = new RemoteServer();
    public static IPAddress ServerIP;
    public static string ServerIPText = "";
    public static ISocket TcpListener;
    public static int ListenPort = 7777;
    public static bool IsListening = true;
    public static bool UseUPNP = true;
    public static bool Disconnect;
    public static bool SpamCheck = false;
    public static bool HasClients;
    private static Thread _serverThread;
    public static MessageBuffer fullBuffer = new MessageBuffer();
    private static int _currentRequestId;
    private static UdpClient BroadcastClient = (UdpClient) null;
    private static Thread broadcastThread = (Thread) null;

    public static event Action OnDisconnect;

    private static void UpdateServer()
    {
      for (int bufferIndex = 0; bufferIndex < 256; ++bufferIndex)
      {
        if (NetMessage.buffer[bufferIndex].checkBytes)
          NetMessage.CheckBytes(bufferIndex);
      }
    }

    private static string GetLocalIPAddress()
    {
      string str = "";
      foreach (IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
      {
        if (address.AddressFamily == AddressFamily.InterNetwork)
        {
          str = address.ToString();
          break;
        }
      }
      return str;
    }

    private static void ResetNetDiag() => Main.ActiveNetDiagnosticsUI.Reset();

    public static void ResetSections()
    {
      for (int index1 = 0; index1 < 256; ++index1)
      {
        for (int index2 = 0; index2 < Main.maxSectionsX; ++index2)
        {
          for (int index3 = 0; index3 < Main.maxSectionsY; ++index3)
            Netplay.Clients[index1].TileSections[index2, index3] = false;
        }
      }
    }

    public static void AddBan(int plr)
    {
      RemoteAddress remoteAddress = Netplay.Clients[plr].Socket.GetRemoteAddress();
      using (StreamWriter streamWriter = new StreamWriter(Netplay.BanFilePath, true))
      {
        streamWriter.WriteLine("//" + Main.player[plr].name);
        streamWriter.WriteLine(remoteAddress.GetIdentifier());
      }
    }

    public static bool IsBanned(RemoteAddress address)
    {
      try
      {
        string identifier = address.GetIdentifier();
        if (System.IO.File.Exists(Netplay.BanFilePath))
        {
          using (StreamReader streamReader = new StreamReader(Netplay.BanFilePath))
          {
            string str;
            while ((str = streamReader.ReadLine()) != null)
            {
              if (str == identifier)
                return true;
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      return false;
    }

    private static void OpenPort(int port)
    {
    }

    private static void ClosePort(int port)
    {
    }

    private static void ServerFullWriteCallBack(object state)
    {
    }

    private static void OnConnectionAccepted(ISocket client)
    {
      int nextOpenClientSlot = Netplay.FindNextOpenClientSlot();
      if (nextOpenClientSlot != -1)
      {
        Netplay.Clients[nextOpenClientSlot].Reset();
        Netplay.Clients[nextOpenClientSlot].Socket = client;
      }
      else
      {
        lock (Netplay.fullBuffer)
          Netplay.KickClient(client, NetworkText.FromKey("CLI.ServerIsFull"));
      }
      if (Netplay.FindNextOpenClientSlot() != -1)
        return;
      Netplay.StopListening();
      Netplay.IsListening = false;
    }

    private static void KickClient(ISocket client, NetworkText kickMessage)
    {
      BinaryWriter writer = Netplay.fullBuffer.writer;
      if (writer == null)
      {
        Netplay.fullBuffer.ResetWriter();
        writer = Netplay.fullBuffer.writer;
      }
      writer.BaseStream.Position = 0L;
      long position1 = writer.BaseStream.Position;
      writer.BaseStream.Position += 2L;
      writer.Write((byte) 2);
      kickMessage.Serialize(writer);
      if (Main.dedServ)
        Console.WriteLine(Language.GetTextValue("CLI.ClientWasBooted", (object) client.GetRemoteAddress().ToString(), (object) kickMessage));
      int position2 = (int) writer.BaseStream.Position;
      writer.BaseStream.Position = position1;
      writer.Write((short) position2);
      writer.BaseStream.Position = (long) position2;
      client.AsyncSend(Netplay.fullBuffer.writeBuffer, 0, position2, new SocketSendCallback(Netplay.ServerFullWriteCallBack), (object) client);
    }

    public static void OnConnectedToSocialServer(ISocket client) => Netplay.StartSocialClient(client);

    private static bool StartListening()
    {
      if (SocialAPI.Network != null)
        SocialAPI.Network.StartListening(new SocketConnectionAccepted(Netplay.OnConnectionAccepted));
      return Netplay.TcpListener.StartListening(new SocketConnectionAccepted(Netplay.OnConnectionAccepted));
    }

    private static void StopListening()
    {
      if (SocialAPI.Network != null)
        SocialAPI.Network.StopListening();
      Netplay.TcpListener.StopListening();
    }

    public static void StartServer()
    {
      Netplay.InitializeServer();
      Netplay._serverThread = new Thread(new ThreadStart(Netplay.ServerLoop))
      {
        IsBackground = true,
        Name = "Server Loop Thread"
      };
      Netplay._serverThread.Start();
    }

    private static void InitializeServer()
    {
      Netplay.ResetNetDiag();
      if (Main.rand == null)
        Main.rand = new UnifiedRandom((int) DateTime.Now.Ticks);
      Main.myPlayer = (int) byte.MaxValue;
      Netplay.ServerIP = IPAddress.Any;
      Main.menuMode = 14;
      Main.statusText = Lang.menu[8].Value;
      Main.netMode = 2;
      Netplay.Disconnect = false;
      for (int index = 0; index < 256; ++index)
      {
        Netplay.Clients[index] = new RemoteClient();
        Netplay.Clients[index].Reset();
        Netplay.Clients[index].Id = index;
        Netplay.Clients[index].ReadBuffer = new byte[1024];
      }
      Netplay.TcpListener = (ISocket) new TcpSocket();
      if (!Netplay.Disconnect)
      {
        if (!Netplay.StartListening())
        {
          Main.menuMode = 15;
          Main.statusText = Language.GetTextValue("Error.TriedToRunServerTwice");
          Netplay.Disconnect = true;
        }
        Main.statusText = Language.GetTextValue("CLI.ServerStarted");
      }
      if (!Netplay.UseUPNP)
        return;
      try
      {
        Netplay.OpenPort(Netplay.ListenPort);
      }
      catch (Exception ex)
      {
      }
    }

    private static void CleanupServer()
    {
      Netplay.StopListening();
      try
      {
        Netplay.ClosePort(Netplay.ListenPort);
      }
      catch
      {
      }
      for (int index = 0; index < 256; ++index)
        Netplay.Clients[index].Reset();
      if (Main.menuMode != 15)
      {
        Main.netMode = 0;
        Main.menuMode = 10;
        WorldFile.SaveWorld();
        Main.menuMode = 0;
      }
      else
        Main.netMode = 0;
      Main.myPlayer = 0;
    }

    private static void ServerLoop()
    {
      int num = 0;
      Netplay.StartBroadCasting();
      while (!Netplay.Disconnect)
      {
        Netplay.StartListeningIfNeeded();
        Netplay.UpdateConnectedClients();
        num = (num + 1) % 10;
        Thread.Sleep(num == 0 ? 1 : 0);
      }
      Netplay.StopBroadCasting();
      Netplay.CleanupServer();
    }

    private static void UpdateConnectedClients()
    {
      int num1 = 0;
      for (int index = 0; index < 256; ++index)
      {
        if (Netplay.Clients[index].PendingTermination)
        {
          if (Netplay.Clients[index].PendingTerminationApproved)
          {
            Netplay.Clients[index].Reset();
            NetMessage.SyncDisconnectedPlayer(index);
          }
        }
        else if (Netplay.Clients[index].IsConnected())
        {
          Netplay.Clients[index].Update();
          ++num1;
        }
        else if (Netplay.Clients[index].IsActive)
        {
          Netplay.Clients[index].PendingTermination = true;
          Netplay.Clients[index].PendingTerminationApproved = true;
        }
        else
        {
          Netplay.Clients[index].StatusText2 = "";
          if (index < (int) byte.MaxValue)
          {
            int num2 = Main.player[index].active ? 1 : 0;
            Main.player[index].active = false;
            if (num2 != 0)
              Player.Hooks.PlayerDisconnect(index);
          }
        }
      }
      Netplay.HasClients = (uint) num1 > 0U;
    }

    private static void StartListeningIfNeeded()
    {
      if (Netplay.IsListening)
        return;
      if (!((IEnumerable<RemoteClient>) Netplay.Clients).Any<RemoteClient>((Func<RemoteClient, bool>) (client => !client.IsConnected())))
        return;
      try
      {
        Netplay.StartListening();
        Netplay.IsListening = true;
      }
      catch
      {
        if (Main.ignoreErrors)
          return;
        throw;
      }
    }

    private static void UpdateClient()
    {
      if (Main.netMode != 1 || !Netplay.Connection.Socket.IsConnected() || !NetMessage.buffer[256].checkBytes)
        return;
      NetMessage.CheckBytes();
    }

    public static void AddCurrentServerToRecentList()
    {
      if (Netplay.Connection.Socket.GetRemoteAddress().Type != AddressType.Tcp)
        return;
      for (int index1 = 0; index1 < Main.maxMP; ++index1)
      {
        if (Main.recentIP[index1].ToLower() == Netplay.ServerIPText.ToLower() && Main.recentPort[index1] == Netplay.ListenPort)
        {
          for (int index2 = index1; index2 < Main.maxMP - 1; ++index2)
          {
            Main.recentIP[index2] = Main.recentIP[index2 + 1];
            Main.recentPort[index2] = Main.recentPort[index2 + 1];
            Main.recentWorld[index2] = Main.recentWorld[index2 + 1];
          }
        }
      }
      for (int index = Main.maxMP - 1; index > 0; --index)
      {
        Main.recentIP[index] = Main.recentIP[index - 1];
        Main.recentPort[index] = Main.recentPort[index - 1];
        Main.recentWorld[index] = Main.recentWorld[index - 1];
      }
      Main.recentIP[0] = Netplay.ServerIPText;
      Main.recentPort[0] = Netplay.ListenPort;
      Main.recentWorld[0] = Main.worldName;
      Main.SaveRecent();
    }

    public static void SocialClientLoop(object threadContext)
    {
      ISocket socket = (ISocket) threadContext;
      Netplay.ClientLoopSetup(socket.GetRemoteAddress());
      Netplay.Connection.Socket = socket;
      Netplay.InnerClientLoop();
    }

    public static void TcpClientLoop()
    {
      Netplay.ClientLoopSetup((RemoteAddress) new TcpAddress(Netplay.ServerIP, Netplay.ListenPort));
      Main.menuMode = 14;
      bool flag = true;
      while (flag)
      {
        flag = false;
        try
        {
          Netplay.Connection.Socket.Connect((RemoteAddress) new TcpAddress(Netplay.ServerIP, Netplay.ListenPort));
          flag = false;
        }
        catch
        {
          if (!Netplay.Disconnect)
          {
            if (Main.gameMenu)
              flag = true;
          }
        }
      }
      Netplay.InnerClientLoop();
    }

    private static void ClientLoopSetup(RemoteAddress address)
    {
      Netplay.ResetNetDiag();
      Main.ServerSideCharacter = false;
      if (Main.rand == null)
        Main.rand = new UnifiedRandom((int) DateTime.Now.Ticks);
      Main.player[Main.myPlayer].hostile = false;
      Main.clientPlayer = (Player) Main.player[Main.myPlayer].clientClone();
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (index != Main.myPlayer)
          Main.player[index] = new Player();
      }
      Main.netMode = 1;
      Main.menuMode = 14;
      if (!Main.autoPass)
        Main.statusText = Language.GetTextValue("Net.ConnectingTo", (object) address.GetFriendlyName());
      Netplay.Disconnect = false;
      Netplay.Connection = new RemoteServer();
      Netplay.Connection.ReadBuffer = new byte[1024];
    }

    private static void InnerClientLoop()
    {
      try
      {
        NetMessage.buffer[256].Reset();
        int num1 = -1;
        while (!Netplay.Disconnect)
        {
          if (Netplay.Connection.Socket.IsConnected())
          {
            Netplay.Connection.IsActive = true;
            if (Netplay.Connection.State == 0)
            {
              Main.statusText = Language.GetTextValue("Net.FoundServer");
              Netplay.Connection.State = 1;
              NetMessage.SendData(1);
            }
            if (Netplay.Connection.State == 2 && num1 != Netplay.Connection.State)
              Main.statusText = Language.GetTextValue("Net.SendingPlayerData");
            if (Netplay.Connection.State == 3 && num1 != Netplay.Connection.State)
              Main.statusText = Language.GetTextValue("Net.RequestingWorldInformation");
            if (Netplay.Connection.State == 4)
            {
              WorldGen.worldCleared = false;
              Netplay.Connection.State = 5;
              Main.cloudBGAlpha = (double) Main.cloudBGActive < 1.0 ? 0.0f : 1f;
              Main.windSpeedCurrent = Main.windSpeedTarget;
              Cloud.resetClouds();
              Main.cloudAlpha = Main.maxRaining;
              WorldGen.clearWorld();
              if (Main.mapEnabled)
                Main.Map.Load();
            }
            if (Netplay.Connection.State == 5 && Main.loadMapLock)
            {
              float num2 = (float) Main.loadMapLastX / (float) Main.maxTilesX;
              Main.statusText = Lang.gen[68].Value + " " + (object) (int) ((double) num2 * 100.0 + 1.0) + "%";
            }
            else if (Netplay.Connection.State == 5 && WorldGen.worldCleared)
            {
              Netplay.Connection.State = 6;
              Main.player[Main.myPlayer].FindSpawn();
              NetMessage.SendData(8, number: Main.player[Main.myPlayer].SpawnX, number2: ((float) Main.player[Main.myPlayer].SpawnY));
            }
            if (Netplay.Connection.State == 6 && num1 != Netplay.Connection.State)
              Main.statusText = Language.GetTextValue("Net.RequestingTileData");
            if (!Netplay.Connection.IsReading && !Netplay.Disconnect && Netplay.Connection.Socket.IsDataAvailable())
            {
              Netplay.Connection.IsReading = true;
              Netplay.Connection.Socket.AsyncReceive(Netplay.Connection.ReadBuffer, 0, Netplay.Connection.ReadBuffer.Length, new SocketReceiveCallback(Netplay.Connection.ClientReadCallBack));
            }
            if (Netplay.Connection.StatusMax > 0 && Netplay.Connection.StatusText != "")
            {
              if (Netplay.Connection.StatusCount >= Netplay.Connection.StatusMax)
              {
                Main.statusText = Language.GetTextValue("Net.StatusComplete", (object) Netplay.Connection.StatusText);
                Netplay.Connection.StatusText = "";
                Netplay.Connection.StatusMax = 0;
                Netplay.Connection.StatusCount = 0;
              }
              else
                Main.statusText = Netplay.Connection.StatusText + ": " + (object) (int) ((double) Netplay.Connection.StatusCount / (double) Netplay.Connection.StatusMax * 100.0) + "%";
            }
            Thread.Sleep(1);
          }
          else if (Netplay.Connection.IsActive)
          {
            Main.statusText = Language.GetTextValue("Net.LostConnection");
            Netplay.Disconnect = true;
          }
          num1 = Netplay.Connection.State;
        }
        try
        {
          Netplay.Connection.Socket.Close();
        }
        catch
        {
        }
        if (!Main.gameMenu)
        {
          Main.gameMenu = true;
          Main.SwitchNetMode(0);
          MapHelper.noStatusText = true;
          Player.SavePlayer(Main.ActivePlayerFileData);
          Player.ClearPlayerTempInfo();
          Main.ActivePlayerFileData.StopPlayTimer();
          SoundEngine.StopTrackedSounds();
          MapHelper.noStatusText = false;
          Main.menuMode = 14;
        }
        NetMessage.buffer[256].Reset();
        if (Main.menuMode == 15 && Main.statusText == Language.GetTextValue("Net.LostConnection"))
          Main.menuMode = 14;
        if (Netplay.Connection.StatusText != "" && Netplay.Connection.StatusText != null)
          Main.statusText = Language.GetTextValue("Net.LostConnection");
        Netplay.Connection.StatusCount = 0;
        Netplay.Connection.StatusMax = 0;
        Netplay.Connection.StatusText = "";
        Main.SwitchNetMode(0);
      }
      catch (Exception ex)
      {
        try
        {
          using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
          {
            streamWriter.WriteLine((object) DateTime.Now);
            streamWriter.WriteLine((object) ex);
            streamWriter.WriteLine("");
          }
        }
        catch
        {
        }
        Netplay.Disconnect = true;
      }
      if (Netplay.OnDisconnect == null)
        return;
      Netplay.OnDisconnect();
    }

    private static int FindNextOpenClientSlot()
    {
      for (int index = 0; index < Main.maxNetPlayers; ++index)
      {
        if (!Netplay.Clients[index].IsConnected())
          return index;
      }
      return -1;
    }

    public static void StartSocialClient(ISocket socket) => new Thread(new ParameterizedThreadStart(Netplay.SocialClientLoop))
    {
      Name = "Social Client Thread",
      IsBackground = true
    }.Start((object) socket);

    public static void StartTcpClient() => new Thread(new ThreadStart(Netplay.TcpClientLoop))
    {
      Name = "TCP Client Thread",
      IsBackground = true
    }.Start();

    public static bool SetRemoteIP(string remoteAddress) => Netplay.SetRemoteIPOld(remoteAddress);

    public static bool SetRemoteIPOld(string remoteAddress)
    {
      try
      {
        IPAddress address;
        if (IPAddress.TryParse(remoteAddress, out address))
        {
          Netplay.ServerIP = address;
          Netplay.ServerIPText = address.ToString();
          return true;
        }
        IPAddress[] addressList = Dns.GetHostEntry(remoteAddress).AddressList;
        for (int index = 0; index < addressList.Length; ++index)
        {
          if (addressList[index].AddressFamily == AddressFamily.InterNetwork)
          {
            Netplay.ServerIP = addressList[index];
            Netplay.ServerIPText = remoteAddress;
            return true;
          }
        }
      }
      catch (Exception ex)
      {
      }
      return false;
    }

    public static void SetRemoteIPAsync(string remoteAddress, Action successCallBack)
    {
      try
      {
        IPAddress address;
        if (IPAddress.TryParse(remoteAddress, out address))
        {
          Netplay.ServerIP = address;
          Netplay.ServerIPText = address.ToString();
          successCallBack();
        }
        else
        {
          Netplay.InvalidateAllOngoingIPSetAttempts();
          Dns.BeginGetHostAddresses(remoteAddress, new AsyncCallback(Netplay.SetRemoteIPAsyncCallback), (object) new Netplay.SetRemoteIPRequestInfo()
          {
            RequestId = Netplay._currentRequestId,
            SuccessCallback = successCallBack,
            RemoteAddress = remoteAddress
          });
        }
      }
      catch (Exception ex)
      {
      }
    }

    public static void InvalidateAllOngoingIPSetAttempts() => ++Netplay._currentRequestId;

    private static void SetRemoteIPAsyncCallback(IAsyncResult ar)
    {
      Netplay.SetRemoteIPRequestInfo asyncState = (Netplay.SetRemoteIPRequestInfo) ar.AsyncState;
      if (asyncState.RequestId != Netplay._currentRequestId)
        return;
      try
      {
        bool flag = false;
        IPAddress[] hostAddresses = Dns.EndGetHostAddresses(ar);
        for (int index = 0; index < hostAddresses.Length; ++index)
        {
          if (hostAddresses[index].AddressFamily == AddressFamily.InterNetwork)
          {
            Netplay.ServerIP = hostAddresses[index];
            Netplay.ServerIPText = asyncState.RemoteAddress;
            flag = true;
            break;
          }
        }
        if (!flag)
          return;
        asyncState.SuccessCallback();
      }
      catch (Exception ex)
      {
      }
    }

    public static void Initialize()
    {
      NetMessage.buffer[256] = new MessageBuffer();
      NetMessage.buffer[256].whoAmI = 256;
    }

    public static void Update() => Netplay.UpdateClient();

    public static int GetSectionX(int x) => x / 200;

    public static int GetSectionY(int y) => y / 150;

    private static void BroadcastThread()
    {
      Netplay.BroadcastClient = new UdpClient();
      IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
      Netplay.BroadcastClient.EnableBroadcast = true;
      DateTime dateTime = new DateTime(0L);
      byte[] array;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream))
        {
          int num = 1010;
          binaryWriter.Write(num);
          binaryWriter.Write(Netplay.ListenPort);
          binaryWriter.Write(Main.worldName);
          binaryWriter.Write(Dns.GetHostName());
          binaryWriter.Write((ushort) Main.maxTilesX);
          binaryWriter.Write(Main.ActiveWorldFileData.HasCrimson);
          binaryWriter.Write(Main.ActiveWorldFileData.GameMode);
          binaryWriter.Write((byte) Main.maxNetPlayers);
          binaryWriter.Write((byte) 0);
          binaryWriter.Flush();
          array = memoryStream.ToArray();
        }
      }
      while (true)
      {
        int num = 0;
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active)
            ++num;
        }
        if (num > 0)
        {
          array[array.Length - 1] = (byte) num;
          try
          {
            Netplay.BroadcastClient.Send(array, array.Length, new IPEndPoint(IPAddress.Broadcast, 8888));
          }
          catch
          {
          }
        }
        Thread.Sleep(1000);
      }
    }

    public static void StartBroadCasting()
    {
      if (Netplay.broadcastThread != null)
        Netplay.StopBroadCasting();
      Netplay.broadcastThread = new Thread(new ThreadStart(Netplay.BroadcastThread));
      Netplay.broadcastThread.Start();
    }

    public static void StopBroadCasting()
    {
      if (Netplay.broadcastThread != null)
      {
        Netplay.broadcastThread.Abort();
        Netplay.broadcastThread = (Thread) null;
      }
      if (Netplay.BroadcastClient == null)
        return;
      Netplay.BroadcastClient.Close();
      Netplay.BroadcastClient = (UdpClient) null;
    }

    private class SetRemoteIPRequestInfo
    {
      public int RequestId;
      public Action SuccessCallback;
      public string RemoteAddress;
    }
  }
}
