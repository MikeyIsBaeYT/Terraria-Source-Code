// Decompiled with JetBrains decompiler
// Type: Terraria.RemoteClient
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria
{
  public class RemoteClient
  {
    public ISocket Socket;
    public int Id;
    public string Name = "Anonymous";
    public bool IsActive;
    public bool PendingTermination;
    public bool IsAnnouncementCompleted;
    public bool IsReading;
    public int State;
    public int TimeOutTimer;
    public string StatusText = "";
    public string StatusText2;
    public int StatusCount;
    public int StatusMax;
    public bool[,] TileSections = new bool[Main.maxTilesX / 200 + 1, Main.maxTilesY / 150 + 1];
    public byte[] ReadBuffer;
    public float SpamProjectile;
    public float SpamAddBlock;
    public float SpamDeleteBlock;
    public float SpamWater;
    public float SpamProjectileMax = 100f;
    public float SpamAddBlockMax = 100f;
    public float SpamDeleteBlockMax = 500f;
    public float SpamWaterMax = 50f;

    public bool IsConnected() => this.Socket != null && this.Socket.IsConnected();

    public void SpamUpdate()
    {
      if (!Netplay.spamCheck)
      {
        this.SpamProjectile = 0.0f;
        this.SpamDeleteBlock = 0.0f;
        this.SpamAddBlock = 0.0f;
        this.SpamWater = 0.0f;
      }
      else
      {
        if ((double) this.SpamProjectile > (double) this.SpamProjectileMax)
          NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingProjectileSpam"));
        if ((double) this.SpamAddBlock > (double) this.SpamAddBlockMax)
          NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingTileSpam"));
        if ((double) this.SpamDeleteBlock > (double) this.SpamDeleteBlockMax)
          NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingTileRemovalSpam"));
        if ((double) this.SpamWater > (double) this.SpamWaterMax)
          NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingLiquidSpam"));
        this.SpamProjectile -= 0.4f;
        if ((double) this.SpamProjectile < 0.0)
          this.SpamProjectile = 0.0f;
        this.SpamAddBlock -= 0.3f;
        if ((double) this.SpamAddBlock < 0.0)
          this.SpamAddBlock = 0.0f;
        this.SpamDeleteBlock -= 5f;
        if ((double) this.SpamDeleteBlock < 0.0)
          this.SpamDeleteBlock = 0.0f;
        this.SpamWater -= 0.2f;
        if ((double) this.SpamWater >= 0.0)
          return;
        this.SpamWater = 0.0f;
      }
    }

    public void SpamClear()
    {
      this.SpamProjectile = 0.0f;
      this.SpamAddBlock = 0.0f;
      this.SpamDeleteBlock = 0.0f;
      this.SpamWater = 0.0f;
    }

    public static void CheckSection(int playerIndex, Vector2 position, int fluff = 1)
    {
      int index1 = playerIndex;
      int sectionX = Netplay.GetSectionX((int) ((double) position.X / 16.0));
      int sectionY1 = Netplay.GetSectionY((int) ((double) position.Y / 16.0));
      int num = 0;
      for (int index2 = sectionX - fluff; index2 < sectionX + fluff + 1; ++index2)
      {
        for (int index3 = sectionY1 - fluff; index3 < sectionY1 + fluff + 1; ++index3)
        {
          if (index2 >= 0 && index2 < Main.maxSectionsX && index3 >= 0 && index3 < Main.maxSectionsY && !Netplay.Clients[index1].TileSections[index2, index3])
            ++num;
        }
      }
      if (num <= 0)
        return;
      int number = num;
      NetMessage.SendData(9, index1, text: Lang.inter[44].ToNetworkText(), number: number);
      Netplay.Clients[index1].StatusText2 = Language.GetTextValue("Net.IsReceivingTileData");
      Netplay.Clients[index1].StatusMax += number;
      for (int index4 = sectionX - fluff; index4 < sectionX + fluff + 1; ++index4)
      {
        for (int sectionY2 = sectionY1 - fluff; sectionY2 < sectionY1 + fluff + 1; ++sectionY2)
        {
          if (index4 >= 0 && index4 < Main.maxSectionsX && sectionY2 >= 0 && sectionY2 < Main.maxSectionsY && !Netplay.Clients[index1].TileSections[index4, sectionY2])
          {
            NetMessage.SendSection(index1, index4, sectionY2);
            NetMessage.SendData(11, index1, number: index4, number2: ((float) sectionY2), number3: ((float) index4), number4: ((float) sectionY2));
          }
        }
      }
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
        if (this.TileSections[Netplay.GetSectionX(x), Netplay.GetSectionY(y)])
          return true;
      }
      return false;
    }

    public void ResetSections()
    {
      for (int index1 = 0; index1 < Main.maxSectionsX; ++index1)
      {
        for (int index2 = 0; index2 < Main.maxSectionsY; ++index2)
          this.TileSections[index1, index2] = false;
      }
    }

    public void Reset()
    {
      this.ResetSections();
      if (this.Id < (int) byte.MaxValue)
        Main.player[this.Id] = new Player();
      this.TimeOutTimer = 0;
      this.StatusCount = 0;
      this.StatusMax = 0;
      this.StatusText2 = "";
      this.StatusText = "";
      this.State = 0;
      this.IsReading = false;
      this.PendingTermination = false;
      this.SpamClear();
      this.IsActive = false;
      NetMessage.buffer[this.Id].Reset();
      if (this.Socket == null)
        return;
      this.Socket.Close();
    }

    public void ServerWriteCallBack(object state)
    {
      --NetMessage.buffer[this.Id].spamCount;
      if (this.StatusMax <= 0)
        return;
      ++this.StatusCount;
    }

    public void ServerReadCallBack(object state, int length)
    {
      if (!Netplay.disconnect)
      {
        int streamLength = length;
        if (streamLength == 0)
          this.PendingTermination = true;
        else if (Main.ignoreErrors)
        {
          try
          {
            NetMessage.ReceiveBytes(this.ReadBuffer, streamLength, this.Id);
          }
          catch
          {
          }
        }
        else
          NetMessage.ReceiveBytes(this.ReadBuffer, streamLength, this.Id);
      }
      this.IsReading = false;
    }
  }
}
