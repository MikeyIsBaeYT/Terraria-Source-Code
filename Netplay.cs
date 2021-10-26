// Decompiled with JetBrains decompiler
// Type: Terraria.Netplay
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Terraria
{
  public class Netplay
  {
    public const int bufferSize = 1024;
    public const int maxConnections = 256;
    public static bool stopListen = false;
    public static ServerSock[] serverSock = new ServerSock[256];
    public static ClientSock clientSock = new ClientSock();
    public static TcpListener tcpListener;
    public static IPAddress serverListenIP;
    public static IPAddress serverIP;
    public static int serverPort = 7777;
    public static bool disconnect = false;
    public static string password = "";
    public static string banFile = "banlist.txt";
    public static bool spamCheck = false;
    public static bool anyClients = false;
    public static bool ServerUp = false;

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
            Netplay.serverSock[index1].tileSection[index2, index3] = false;
        }
      }
    }

    public static void AddBan(int plr)
    {
      string str1 = Netplay.serverSock[plr].tcpClient.Client.RemoteEndPoint.ToString();
      string str2 = str1;
      for (int index = 0; index < str1.Length; ++index)
      {
        if (str1.Substring(index, 1) == ":")
          str2 = str1.Substring(0, index);
      }
      using (StreamWriter streamWriter = new StreamWriter(Netplay.banFile, true))
      {
        streamWriter.WriteLine("//" + Main.player[plr].name);
        streamWriter.WriteLine(str2);
      }
    }

    public static bool CheckBan(string ip)
    {
      try
      {
        string str1 = ip;
        for (int index = 0; index < ip.Length; ++index)
        {
          if (ip.Substring(index, 1) == ":")
            str1 = ip.Substring(0, index);
        }
        if (System.IO.File.Exists(Netplay.banFile))
        {
          using (StreamReader streamReader = new StreamReader(Netplay.banFile))
          {
            string str2;
            while ((str2 = streamReader.ReadLine()) != null)
            {
              if (str2 == str1)
                return true;
            }
          }
        }
      }
      catch
      {
      }
      return false;
    }

    public static void newRecent()
    {
      for (int index1 = 0; index1 < Main.maxMP; ++index1)
      {
        if (Main.recentIP[index1] == Netplay.serverIP.ToString() && Main.recentPort[index1] == Netplay.serverPort)
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
      Main.recentIP[0] = Netplay.serverIP.ToString();
      Main.recentPort[0] = Netplay.serverPort;
      Main.recentWorld[0] = Main.worldName;
      Main.SaveRecent();
    }

    public static void ClientLoop(object threadContext)
    {
      Netplay.ResetNetDiag();
      if (Main.rand == null)
        Main.rand = new Random((int) DateTime.Now.Ticks);
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
      Main.player[Main.myPlayer].hostile = false;
      Main.clientPlayer = (Player) Main.player[Main.myPlayer].clientClone();
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (index != Main.myPlayer)
          Main.player[index] = new Player();
      }
      Main.menuMode = 10;
      Main.menuMode = 14;
      if (!Main.autoPass)
        Main.statusText = "Connecting to " + (object) Netplay.serverIP;
      Main.netMode = 1;
      Netplay.disconnect = false;
      Netplay.clientSock = new ClientSock();
      Netplay.clientSock.tcpClient.NoDelay = true;
      Netplay.clientSock.readBuffer = new byte[1024];
      Netplay.clientSock.writeBuffer = new byte[1024];
      bool flag = true;
      while (flag)
      {
        flag = false;
        try
        {
          Netplay.clientSock.tcpClient.Connect(Netplay.serverIP, Netplay.serverPort);
          Netplay.clientSock.networkStream = Netplay.clientSock.tcpClient.GetStream();
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
      NetMessage.buffer[256].Reset();
      int num = -1;
      while (!Netplay.disconnect)
      {
        if (Netplay.clientSock.tcpClient.Connected)
        {
          if (NetMessage.buffer[256].checkBytes)
            NetMessage.CheckBytes();
          Netplay.clientSock.active = true;
          if (Netplay.clientSock.state == 0)
          {
            Main.statusText = "Found server";
            Netplay.clientSock.state = 1;
            NetMessage.SendData(1);
          }
          if (Netplay.clientSock.state == 2 && num != Netplay.clientSock.state)
            Main.statusText = "Sending player data...";
          if (Netplay.clientSock.state == 3 && num != Netplay.clientSock.state)
            Main.statusText = "Requesting world information";
          if (Netplay.clientSock.state == 4)
          {
            WorldGen.worldCleared = false;
            Netplay.clientSock.state = 5;
            WorldGen.clearWorld();
          }
          if (Netplay.clientSock.state == 5 && WorldGen.worldCleared)
          {
            Netplay.clientSock.state = 6;
            Main.player[Main.myPlayer].FindSpawn();
            NetMessage.SendData(8, number: Main.player[Main.myPlayer].SpawnX, number2: ((float) Main.player[Main.myPlayer].SpawnY));
          }
          if (Netplay.clientSock.state == 6 && num != Netplay.clientSock.state)
            Main.statusText = "Requesting tile data";
          if (!Netplay.clientSock.locked && !Netplay.disconnect && Netplay.clientSock.networkStream.DataAvailable)
          {
            Netplay.clientSock.locked = true;
            Netplay.clientSock.networkStream.BeginRead(Netplay.clientSock.readBuffer, 0, Netplay.clientSock.readBuffer.Length, new AsyncCallback(Netplay.clientSock.ClientReadCallBack), (object) Netplay.clientSock.networkStream);
          }
          if (Netplay.clientSock.statusMax > 0 && Netplay.clientSock.statusText != "")
          {
            if (Netplay.clientSock.statusCount >= Netplay.clientSock.statusMax)
            {
              Main.statusText = Netplay.clientSock.statusText + ": Complete!";
              Netplay.clientSock.statusText = "";
              Netplay.clientSock.statusMax = 0;
              Netplay.clientSock.statusCount = 0;
            }
            else
              Main.statusText = Netplay.clientSock.statusText + ": " + (object) (int) ((double) Netplay.clientSock.statusCount / (double) Netplay.clientSock.statusMax * 100.0) + "%";
          }
          Thread.Sleep(1);
        }
        else if (Netplay.clientSock.active)
        {
          Main.statusText = "Lost connection";
          Netplay.disconnect = true;
        }
        num = Netplay.clientSock.state;
      }
      try
      {
        Netplay.clientSock.networkStream.Close();
        Netplay.clientSock.networkStream = Netplay.clientSock.tcpClient.GetStream();
      }
      catch
      {
      }
      if (!Main.gameMenu)
      {
        Main.netMode = 0;
        Player.SavePlayer(Main.player[Main.myPlayer], Main.playerPathName);
        Main.gameMenu = true;
        Main.menuMode = 14;
      }
      NetMessage.buffer[256].Reset();
      if (Main.menuMode == 15 && Main.statusText == "Lost connection")
        Main.menuMode = 14;
      if (Netplay.clientSock.statusText != "" && Netplay.clientSock.statusText != null)
        Main.statusText = "Lost connection";
      Netplay.clientSock.statusCount = 0;
      Netplay.clientSock.statusMax = 0;
      Netplay.clientSock.statusText = "";
      Main.netMode = 0;
    }

    public static void ServerLoop(object threadContext)
    {
      Netplay.ResetNetDiag();
      if (Main.rand == null)
        Main.rand = new Random((int) DateTime.Now.Ticks);
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
      Main.myPlayer = (int) byte.MaxValue;
      Netplay.serverIP = IPAddress.Any;
      Netplay.serverListenIP = Netplay.serverIP;
      Main.menuMode = 14;
      Main.statusText = "Starting server...";
      Main.netMode = 2;
      Netplay.disconnect = false;
      for (int index = 0; index < 256; ++index)
      {
        Netplay.serverSock[index] = new ServerSock();
        Netplay.serverSock[index].Reset();
        Netplay.serverSock[index].whoAmI = index;
        Netplay.serverSock[index].tcpClient = new TcpClient();
        Netplay.serverSock[index].tcpClient.NoDelay = true;
        Netplay.serverSock[index].readBuffer = new byte[1024];
        Netplay.serverSock[index].writeBuffer = new byte[1024];
      }
      Netplay.tcpListener = new TcpListener(Netplay.serverListenIP, Netplay.serverPort);
      try
      {
        Netplay.tcpListener.Start();
      }
      catch (Exception ex)
      {
        Main.menuMode = 15;
        Main.statusText = ex.ToString();
        Netplay.disconnect = true;
      }
      if (!Netplay.disconnect)
      {
        ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ListenForClients), (object) 1);
        Main.statusText = "Server started";
      }
      int num1 = 0;
      while (!Netplay.disconnect)
      {
        if (Netplay.stopListen)
        {
          int num2 = -1;
          for (int index = 0; index < Main.maxNetPlayers; ++index)
          {
            if (!Netplay.serverSock[index].tcpClient.Connected)
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
                Netplay.tcpListener.Start();
                Netplay.stopListen = false;
                ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ListenForClients), (object) 1);
              }
              catch
              {
              }
            }
            else
            {
              Netplay.tcpListener.Start();
              Netplay.stopListen = false;
              ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ListenForClients), (object) 1);
            }
          }
        }
        int num3 = 0;
        for (int i = 0; i < 256; ++i)
        {
          if (NetMessage.buffer[i].checkBytes)
            NetMessage.CheckBytes(i);
          if (Netplay.serverSock[i].kill)
          {
            Netplay.serverSock[i].Reset();
            NetMessage.syncPlayers();
          }
          else if (Netplay.serverSock[i].tcpClient.Connected)
          {
            if (!Netplay.serverSock[i].active)
              Netplay.serverSock[i].state = 0;
            Netplay.serverSock[i].active = true;
            ++num3;
            if (!Netplay.serverSock[i].locked)
            {
              try
              {
                Netplay.serverSock[i].networkStream = Netplay.serverSock[i].tcpClient.GetStream();
                if (Netplay.serverSock[i].networkStream.DataAvailable)
                {
                  Netplay.serverSock[i].locked = true;
                  Netplay.serverSock[i].networkStream.BeginRead(Netplay.serverSock[i].readBuffer, 0, Netplay.serverSock[i].readBuffer.Length, new AsyncCallback(Netplay.serverSock[i].ServerReadCallBack), (object) Netplay.serverSock[i].networkStream);
                }
              }
              catch
              {
                Netplay.serverSock[i].kill = true;
              }
            }
            if (Netplay.serverSock[i].statusMax > 0 && Netplay.serverSock[i].statusText2 != "")
            {
              if (Netplay.serverSock[i].statusCount >= Netplay.serverSock[i].statusMax)
              {
                Netplay.serverSock[i].statusText = "(" + (object) Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint + ") " + Netplay.serverSock[i].name + " " + Netplay.serverSock[i].statusText2 + ": Complete!";
                Netplay.serverSock[i].statusText2 = "";
                Netplay.serverSock[i].statusMax = 0;
                Netplay.serverSock[i].statusCount = 0;
              }
              else
                Netplay.serverSock[i].statusText = "(" + (object) Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint + ") " + Netplay.serverSock[i].name + " " + Netplay.serverSock[i].statusText2 + ": " + (object) (int) ((double) Netplay.serverSock[i].statusCount / (double) Netplay.serverSock[i].statusMax * 100.0) + "%";
            }
            else if (Netplay.serverSock[i].state == 0)
              Netplay.serverSock[i].statusText = "(" + (object) Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint + ") " + Netplay.serverSock[i].name + " is connecting...";
            else if (Netplay.serverSock[i].state == 1)
              Netplay.serverSock[i].statusText = "(" + (object) Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint + ") " + Netplay.serverSock[i].name + " is sending player data...";
            else if (Netplay.serverSock[i].state == 2)
              Netplay.serverSock[i].statusText = "(" + (object) Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint + ") " + Netplay.serverSock[i].name + " requested world information";
            else if (Netplay.serverSock[i].state != 3 && Netplay.serverSock[i].state == 10)
              Netplay.serverSock[i].statusText = "(" + (object) Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint + ") " + Netplay.serverSock[i].name + " is playing";
          }
          else if (Netplay.serverSock[i].active)
          {
            Netplay.serverSock[i].kill = true;
          }
          else
          {
            Netplay.serverSock[i].statusText2 = "";
            if (i < (int) byte.MaxValue)
              Main.player[i].active = false;
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
          Main.statusText = num3 != 0 ? num3.ToString() + " clients connected" : "Waiting for clients...";
        Netplay.anyClients = num3 != 0;
        Netplay.ServerUp = true;
      }
      Netplay.tcpListener.Stop();
      for (int index = 0; index < 256; ++index)
        Netplay.serverSock[index].Reset();
      if (Main.menuMode != 15)
      {
        Main.netMode = 0;
        Main.menuMode = 10;
        WorldGen.saveWorld();
        do
          ;
        while (WorldGen.saveLock);
        Main.menuMode = 0;
      }
      else
        Main.netMode = 0;
      Main.myPlayer = 0;
    }

    public static void ListenForClients(object threadContext)
    {
      while (!Netplay.disconnect && !Netplay.stopListen)
      {
        int index1 = -1;
        for (int index2 = 0; index2 < Main.maxNetPlayers; ++index2)
        {
          if (!Netplay.serverSock[index2].tcpClient.Connected)
          {
            index1 = index2;
            break;
          }
        }
        if (index1 >= 0)
        {
          try
          {
            Netplay.serverSock[index1].tcpClient = Netplay.tcpListener.AcceptTcpClient();
            Netplay.serverSock[index1].tcpClient.NoDelay = true;
            Console.WriteLine(Netplay.serverSock[index1].tcpClient.Client.RemoteEndPoint.ToString() + " is connecting...");
          }
          catch (Exception ex)
          {
            if (!Netplay.disconnect)
            {
              Main.menuMode = 15;
              Main.statusText = ex.ToString();
              Netplay.disconnect = true;
            }
          }
        }
        else
        {
          Netplay.stopListen = true;
          Netplay.tcpListener.Stop();
        }
      }
    }

    public static void StartClient() => ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ClientLoop), (object) 1);

    public static void StartServer() => ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ServerLoop), (object) 1);

    public static bool SetIP(string newIP)
    {
      try
      {
        Netplay.serverIP = IPAddress.Parse(newIP);
      }
      catch
      {
        return false;
      }
      return true;
    }

    public static bool SetIP2(string newIP)
    {
      try
      {
        IPAddress[] addressList = Dns.GetHostEntry(newIP).AddressList;
        for (int index = 0; index < addressList.Length; ++index)
        {
          if (addressList[index].AddressFamily == AddressFamily.InterNetwork)
          {
            Netplay.serverIP = addressList[index];
            return true;
          }
        }
        return false;
      }
      catch
      {
        return false;
      }
    }

    public static void Init()
    {
      for (int index = 0; index < 257; ++index)
      {
        if (index < 256)
        {
          Netplay.serverSock[index] = new ServerSock();
          Netplay.serverSock[index].tcpClient.NoDelay = true;
        }
        NetMessage.buffer[index] = new messageBuffer();
        NetMessage.buffer[index].whoAmI = index;
      }
      Netplay.clientSock.tcpClient.NoDelay = true;
    }

    public static int GetSectionX(int x) => x / 200;

    public static int GetSectionY(int y) => y / 150;
  }
}
