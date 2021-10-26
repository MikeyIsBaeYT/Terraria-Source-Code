// Decompiled with JetBrains decompiler
// Type: Terraria.RemoteClient
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
    public bool PendingTerminationApproved;
    public bool IsAnnouncementCompleted;
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
    private volatile bool _isReading;
    private static List<Point> _pendingSectionFraming = new List<Point>();

    public bool IsConnected() => this.Socket != null && this.Socket.IsConnected();

    public void SpamUpdate()
    {
      if (!Netplay.SpamCheck)
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
      int sectionY = Netplay.GetSectionY((int) ((double) position.Y / 16.0));
      int num = 0;
      for (int index2 = sectionX - fluff; index2 < sectionX + fluff + 1; ++index2)
      {
        for (int index3 = sectionY - fluff; index3 < sectionY + fluff + 1; ++index3)
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
      RemoteClient._pendingSectionFraming.Clear();
      for (int index4 = sectionX - fluff; index4 < sectionX + fluff + 1; ++index4)
      {
        for (int index5 = sectionY - fluff; index5 < sectionY + fluff + 1; ++index5)
        {
          if (index4 >= 0 && index4 < Main.maxSectionsX && index5 >= 0 && index5 < Main.maxSectionsY && !Netplay.Clients[index1].TileSections[index4, index5])
          {
            NetMessage.SendSection(index1, index4, index5);
            RemoteClient._pendingSectionFraming.Add(new Point(index4, index5));
          }
        }
      }
      foreach (Point point in RemoteClient._pendingSectionFraming)
        NetMessage.SendData(11, index1, number: point.X, number2: ((float) point.Y), number3: ((float) point.X), number4: ((float) point.Y));
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
      this._isReading = false;
      this.PendingTermination = false;
      this.PendingTerminationApproved = false;
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

    public void Update()
    {
      if (!this.IsActive)
      {
        this.State = 0;
        this.IsActive = true;
      }
      this.TryRead();
      this.UpdateStatusText();
    }

    private void TryRead()
    {
      if (this._isReading)
        return;
      try
      {
        if (!this.Socket.IsDataAvailable())
          return;
        this._isReading = true;
        this.Socket.AsyncReceive(this.ReadBuffer, 0, this.ReadBuffer.Length, new SocketReceiveCallback(this.ServerReadCallBack));
      }
      catch
      {
        this.PendingTermination = true;
      }
    }

    private void ServerReadCallBack(object state, int length)
    {
      if (!Netplay.Disconnect)
      {
        int streamLength = length;
        if (streamLength == 0)
        {
          this.PendingTermination = true;
        }
        else
        {
          try
          {
            NetMessage.ReceiveBytes(this.ReadBuffer, streamLength, this.Id);
          }
          catch
          {
            if (!Main.ignoreErrors)
              throw;
          }
        }
      }
      this._isReading = false;
    }

    private void UpdateStatusText()
    {
      if (this.StatusMax > 0 && this.StatusText2 != "")
      {
        if (this.StatusCount >= this.StatusMax)
        {
          this.StatusText = Language.GetTextValue("Net.ClientStatusComplete", (object) this.Socket.GetRemoteAddress(), (object) this.Name, (object) this.StatusText2);
          this.StatusText2 = "";
          this.StatusMax = 0;
          this.StatusCount = 0;
        }
        else
          this.StatusText = "(" + (object) this.Socket.GetRemoteAddress() + ") " + this.Name + " " + this.StatusText2 + ": " + (object) (int) ((double) this.StatusCount / (double) this.StatusMax * 100.0) + "%";
      }
      else if (this.State == 0)
        this.StatusText = Language.GetTextValue("Net.ClientConnecting", (object) string.Format("({0}) {1}", (object) this.Socket.GetRemoteAddress(), (object) this.Name));
      else if (this.State == 1)
        this.StatusText = Language.GetTextValue("Net.ClientSendingData", (object) this.Socket.GetRemoteAddress(), (object) this.Name);
      else if (this.State == 2)
      {
        this.StatusText = Language.GetTextValue("Net.ClientRequestedWorldInfo", (object) this.Socket.GetRemoteAddress(), (object) this.Name);
      }
      else
      {
        if (this.State == 3)
          return;
        if (this.State != 10)
          return;
        try
        {
          this.StatusText = Language.GetTextValue("Net.ClientPlaying", (object) this.Socket.GetRemoteAddress(), (object) this.Name);
        }
        catch (Exception ex)
        {
          this.PendingTermination = true;
        }
      }
    }
  }
}
