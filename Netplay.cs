// Decompiled with JetBrains decompiler
// Type: Terraria.Netplay
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.IO;
using Terraria.Localization;
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
    public static bool IsServerRunning = false;
    public static bool IsListening = true;
    public static bool UseUPNP = true;
    public static bool disconnect = false;
    public static bool spamCheck = false;
    public static bool anyClients = false;
    private static Thread ServerThread;
    public static string portForwardIP;
    public static int portForwardPort;
    public static bool portForwardOpen;

    public static event Action OnDisconnect;

    private static void OpenPort()
    {
      Netplay.portForwardIP = Netplay.GetLocalIPAddress();
      Netplay.portForwardPort = Netplay.ListenPort;
    }

    public static void closePort()
    {
    }

    public static string GetLocalIPAddress()
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

    public static void ResetNetDiag()
    {
      Main.rxMsg = 0;
      Main.rxData = 0;
      Main.txMsg = 0;
      Main.txData = 0;
      for (int index = 0; index < Main.maxMsg; ++index)
      {
        Main.rxMsgType[index] = 0;
        Main.rxDataType[index] = 0;
        Main.txMsgType[index] = 0;
        Main.txDataType[index] = 0;
      }
    }

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

    public static void newRecent()
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

    public static void TcpClientLoop(object threadContext)
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
          if (!Netplay.disconnect)
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
      Netplay.disconnect = false;
      Netplay.Connection = new RemoteServer();
      Netplay.Connection.ReadBuffer = new byte[1024];
    }

    private static void InnerClientLoop()
    {
      try
      {
        NetMessage.buffer[256].Reset();
        int num1 = -1;
        while (!Netplay.disconnect)
        {
          if (Netplay.Connection.Socket.IsConnected())
          {
            if (NetMessage.buffer[256].checkBytes)
              NetMessage.CheckBytes();
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
              Main.windSpeed = Main.windSpeedSet;
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
            if (!Netplay.Connection.IsReading && !Netplay.disconnect && Netplay.Connection.Socket.IsDataAvailable())
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
            Netplay.disconnect = true;
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
          Main.SwitchNetMode(0);
          Player.SavePlayer(Main.ActivePlayerFileData);
          Main.ActivePlayerFileData.StopPlayTimer();
          Main.gameMenu = true;
          Main.StopTrackedSounds();
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
        Netplay.disconnect = true;
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

    private static void OnConnectionAccepted(ISocket client)
    {
      int nextOpenClientSlot = Netplay.FindNextOpenClientSlot();
      if (nextOpenClientSlot != -1)
      {
        Netplay.Clients[nextOpenClientSlot].Reset();
        Netplay.Clients[nextOpenClientSlot].Socket = client;
        Console.WriteLine(Language.GetTextValue("Net.ClientConnecting", (object) client.GetRemoteAddress()));
      }
      if (Netplay.FindNextOpenClientSlot() != -1)
        return;
      Netplay.StopListening();
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

    public static void ServerLoop(object threadContext)
    {
      Netplay.ResetNetDiag();
      if (Main.rand == null)
        Main.rand = new UnifiedRandom((int) DateTime.Now.Ticks);
      Main.myPlayer = (int) byte.MaxValue;
      Netplay.ServerIP = IPAddress.Any;
      Main.menuMode = 14;
      Main.statusText = Lang.menu[8].Value;
      Main.netMode = 2;
      Netplay.disconnect = false;
      for (int index = 0; index < 256; ++index)
      {
        Netplay.Clients[index] = new RemoteClient();
        Netplay.Clients[index].Reset();
        Netplay.Clients[index].Id = index;
        Netplay.Clients[index].ReadBuffer = new byte[1024];
      }
      Netplay.TcpListener = (ISocket) new TcpSocket();
      if (!Netplay.disconnect)
      {
        if (!Netplay.StartListening())
        {
          Main.menuMode = 15;
          Main.statusText = Language.GetTextValue("Error.TriedToRunServerTwice");
          Netplay.disconnect = true;
        }
        Main.statusText = Language.GetTextValue("CLI.ServerStarted");
      }
      if (Netplay.UseUPNP)
      {
        try
        {
          Netplay.OpenPort();
        }
        catch
        {
        }
      }
      int num1 = 0;
      while (!Netplay.disconnect)
      {
        if (!Netplay.IsListening)
        {
          int num2 = -1;
          for (int index = 0; index < Main.maxNetPlayers; ++index)
          {
            if (!Netplay.Clients[index].IsConnected())
            {
              num2 = index;
              break;
            }
          }
          if (num2 >= 0)
          {
            if (Main.ignoreErrors)
            {
              try
              {
                Netplay.StartListening();
                Netplay.IsListening = true;
              }
              catch
              {
              }
            }
            else
            {
              Netplay.StartListening();
              Netplay.IsListening = true;
            }
          }
        }
        int num3 = 0;
        for (int index = 0; index < 256; ++index)
        {
          if (NetMessage.buffer[index].checkBytes)
            NetMessage.CheckBytes(index);
          if (Netplay.Clients[index].PendingTermination)
          {
            Netplay.Clients[index].Reset();
            NetMessage.SyncDisconnectedPlayer(index);
          }
          else if (Netplay.Clients[index].IsConnected())
          {
            if (!Netplay.Clients[index].IsActive)
              Netplay.Clients[index].State = 0;
            Netplay.Clients[index].IsActive = true;
            ++num3;
            if (!Netplay.Clients[index].IsReading)
            {
              try
              {
                if (Netplay.Clients[index].Socket.IsDataAvailable())
                {
                  Netplay.Clients[index].IsReading = true;
                  Netplay.Clients[index].Socket.AsyncReceive(Netplay.Clients[index].ReadBuffer, 0, Netplay.Clients[index].ReadBuffer.Length, new SocketReceiveCallback(Netplay.Clients[index].ServerReadCallBack));
                }
              }
              catch
              {
                Netplay.Clients[index].PendingTermination = true;
              }
            }
            if (Netplay.Clients[index].StatusMax > 0 && Netplay.Clients[index].StatusText2 != "")
            {
              if (Netplay.Clients[index].StatusCount >= Netplay.Clients[index].StatusMax)
              {
                Netplay.Clients[index].StatusText = Language.GetTextValue("Net.ClientStatusComplete", (object) Netplay.Clients[index].Socket.GetRemoteAddress(), (object) Netplay.Clients[index].Name, (object) Netplay.Clients[index].StatusText2);
                Netplay.Clients[index].StatusText2 = "";
                Netplay.Clients[index].StatusMax = 0;
                Netplay.Clients[index].StatusCount = 0;
              }
              else
                Netplay.Clients[index].StatusText = "(" + (object) Netplay.Clients[index].Socket.GetRemoteAddress() + ") " + Netplay.Clients[index].Name + " " + Netplay.Clients[index].StatusText2 + ": " + (object) (int) ((double) Netplay.Clients[index].StatusCount / (double) Netplay.Clients[index].StatusMax * 100.0) + "%";
            }
            else if (Netplay.Clients[index].State == 0)
              Netplay.Clients[index].StatusText = Language.GetTextValue("Net.ClientConnecting", (object) string.Format("({0}) {1}", (object) Netplay.Clients[index].Socket.GetRemoteAddress(), (object) Netplay.Clients[index].Name));
            else if (Netplay.Clients[index].State == 1)
              Netplay.Clients[index].StatusText = Language.GetTextValue("Net.ClientSendingData", (object) Netplay.Clients[index].Socket.GetRemoteAddress(), (object) Netplay.Clients[index].Name);
            else if (Netplay.Clients[index].State == 2)
              Netplay.Clients[index].StatusText = Language.GetTextValue("Net.ClientRequestedWorldInfo", (object) Netplay.Clients[index].Socket.GetRemoteAddress(), (object) Netplay.Clients[index].Name);
            else if (Netplay.Clients[index].State != 3)
            {
              if (Netplay.Clients[index].State == 10)
              {
                try
                {
                  Netplay.Clients[index].StatusText = Language.GetTextValue("Net.ClientPlaying", (object) Netplay.Clients[index].Socket.GetRemoteAddress(), (object) Netplay.Clients[index].Name);
                }
                catch (Exception ex)
                {
                  Netplay.Clients[index].PendingTermination = true;
                }
              }
            }
          }
          else if (Netplay.Clients[index].IsActive)
          {
            Netplay.Clients[index].PendingTermination = true;
          }
          else
          {
            Netplay.Clients[index].StatusText2 = "";
            if (index < (int) byte.MaxValue)
            {
              int num4 = Main.player[index].active ? 1 : 0;
              Main.player[index].active = false;
              if (num4 != 0)
                Player.Hooks.PlayerDisconnect(index);
            }
          }
        }
        ++num1;
        if (num1 > 10)
        {
          Thread.Sleep(1);
          num1 = 0;
        }
        else
          Thread.Sleep(0);
        if (!WorldGen.saveLock && !Main.dedServ)
          Main.statusText = num3 != 0 ? Language.GetTextValue("Net.ClientsConnected", (object) num3) : Language.GetTextValue("Net.WaitingForClients");
        Netplay.anyClients = num3 != 0;
        Netplay.IsServerRunning = true;
      }
      Netplay.StopListening();
      try
      {
        Netplay.closePort();
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
        WorldFile.saveWorld();
        do
          ;
        while (WorldGen.saveLock);
        Main.menuMode = 0;
      }
      else
        Main.netMode = 0;
      Main.myPlayer = 0;
    }

    public static void StartSocialClient(ISocket socket) => ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.SocialClientLoop), (object) socket);

    public static void StartTcpClient() => ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.TcpClientLoop), (object) 1);

    public static void StartServer()
    {
      Netplay.ServerThread = new Thread(new ParameterizedThreadStart(Netplay.ServerLoop));
      Netplay.ServerThread.Start();
    }

    public static bool SetRemoteIP(string remoteAddress)
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

    public static void Initialize()
    {
      NetMessage.buffer[256] = new MessageBuffer();
      NetMessage.buffer[256].whoAmI = 256;
    }

    public static int GetSectionX(int x) => x / 200;

    public static int GetSectionY(int y) => y / 150;
  }
}
