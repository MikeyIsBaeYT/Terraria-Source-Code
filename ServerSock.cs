// Decompiled with JetBrains decompiler
// Type: Terraria.ServerSock
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Net.Sockets;

namespace Terraria
{
  public class ServerSock
  {
    public Socket clientSocket;
    public NetworkStream networkStream;
    public TcpClient tcpClient = new TcpClient();
    public int whoAmI;
    public string statusText2;
    public int statusCount;
    public int statusMax;
    public bool[,] tileSection = new bool[Main.maxTilesX / 200 + 1, Main.maxTilesY / 150 + 1];
    public string statusText = "";
    public bool active;
    public bool locked;
    public bool kill;
    public int timeOut;
    public bool announced;
    public string name = "Anonymous";
    public string oldName = "";
    public int state;
    public float spamProjectile;
    public float spamAddBlock;
    public float spamDelBlock;
    public float spamWater;
    public float spamProjectileMax = 100f;
    public float spamAddBlockMax = 100f;
    public float spamDelBlockMax = 500f;
    public float spamWaterMax = 50f;
    public byte[] readBuffer;
    public byte[] writeBuffer;

    public void SpamUpdate()
    {
      if (!Netplay.spamCheck)
      {
        this.spamProjectile = 0.0f;
        this.spamDelBlock = 0.0f;
        this.spamAddBlock = 0.0f;
        this.spamWater = 0.0f;
      }
      else
      {
        if ((double) this.spamProjectile > (double) this.spamProjectileMax)
          NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Projectile spam");
        if ((double) this.spamAddBlock > (double) this.spamAddBlockMax)
          NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Add tile spam");
        if ((double) this.spamDelBlock > (double) this.spamDelBlockMax)
          NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Remove tile spam");
        if ((double) this.spamWater > (double) this.spamWaterMax)
          NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
        this.spamProjectile -= 0.4f;
        if ((double) this.spamProjectile < 0.0)
          this.spamProjectile = 0.0f;
        this.spamAddBlock -= 0.3f;
        if ((double) this.spamAddBlock < 0.0)
          this.spamAddBlock = 0.0f;
        this.spamDelBlock -= 5f;
        if ((double) this.spamDelBlock < 0.0)
          this.spamDelBlock = 0.0f;
        this.spamWater -= 0.2f;
        if ((double) this.spamWater >= 0.0)
          return;
        this.spamWater = 0.0f;
      }
    }

    public void SpamClear()
    {
      this.spamProjectile = 0.0f;
      this.spamAddBlock = 0.0f;
      this.spamDelBlock = 0.0f;
      this.spamWater = 0.0f;
    }

    public bool SectionRange(int size, int firstX, int firstY)
    {
      for (int index = 0; index < 4; ++index)
      {
        int x = firstX;
        int y = firstY;
        if (index == 1)
          x += size;
        if (index == 2)
          y += size;
        if (index == 3)
        {
          x += size;
          y += size;
        }
        if (this.tileSection[Netplay.GetSectionX(x), Netplay.GetSectionY(y)])
          return true;
      }
      return false;
    }

    public void Reset()
    {
      for (int index1 = 0; index1 < Main.maxSectionsX; ++index1)
      {
        for (int index2 = 0; index2 < Main.maxSectionsY; ++index2)
          this.tileSection[index1, index2] = false;
      }
      if (this.whoAmI < (int) byte.MaxValue)
        Main.player[this.whoAmI] = new Player();
      this.timeOut = 0;
      this.statusCount = 0;
      this.statusMax = 0;
      this.statusText2 = "";
      this.statusText = "";
      this.name = "Anonymous";
      this.state = 0;
      this.locked = false;
      this.kill = false;
      this.SpamClear();
      this.active = false;
      NetMessage.buffer[this.whoAmI].Reset();
      if (this.networkStream != null)
        this.networkStream.Close();
      if (this.tcpClient == null)
        return;
      this.tcpClient.Close();
    }

    public void ServerWriteCallBack(IAsyncResult ar)
    {
      --NetMessage.buffer[this.whoAmI].spamCount;
      if (this.statusMax <= 0)
        return;
      ++this.statusCount;
    }

    public void ServerReadCallBack(IAsyncResult ar)
    {
      int streamLength = 0;
      if (!Netplay.disconnect)
      {
        try
        {
          streamLength = this.networkStream.EndRead(ar);
        }
        catch
        {
        }
        if (streamLength == 0)
          this.kill = true;
        else if (Main.ignoreErrors)
        {
          try
          {
            NetMessage.RecieveBytes(this.readBuffer, streamLength, this.whoAmI);
          }
          catch
          {
          }
        }
        else
          NetMessage.RecieveBytes(this.readBuffer, streamLength, this.whoAmI);
      }
      this.locked = false;
    }
  }
}
