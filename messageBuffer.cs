// Decompiled with JetBrains decompiler
// Type: Terraria.messageBuffer
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Text;

namespace Terraria
{
  public class messageBuffer
  {
    public const int readBufferMax = 65535;
    public const int writeBufferMax = 65535;
    public bool broadcast;
    public byte[] readBuffer = new byte[(int) ushort.MaxValue];
    public byte[] writeBuffer = new byte[(int) ushort.MaxValue];
    public bool writeLocked;
    public int messageLength;
    public int totalData;
    public int whoAmI;
    public int spamCount;
    public int maxSpam;
    public bool checkBytes;

    public void Reset()
    {
      this.writeBuffer = new byte[(int) ushort.MaxValue];
      this.writeLocked = false;
      this.messageLength = 0;
      this.totalData = 0;
      this.spamCount = 0;
      this.broadcast = false;
      this.checkBytes = false;
    }

    public void GetData(int start, int length)
    {
      if (this.whoAmI < 256)
        Netplay.serverSock[this.whoAmI].timeOut = 0;
      else
        Netplay.clientSock.timeOut = 0;
      int num1 = 0;
      int index1 = start + 1;
      byte num2 = this.readBuffer[start];
      ++Main.rxMsg;
      Main.rxData += length;
      ++Main.rxMsgType[(int) num2];
      Main.rxDataType[(int) num2] += length;
      if (Main.netMode == 1 && Netplay.clientSock.statusMax > 0)
        ++Netplay.clientSock.statusCount;
      if (Main.verboseNetplay)
      {
        int num3 = start;
        while (num3 < start + length)
          ++num3;
        for (int index2 = start; index2 < start + length; ++index2)
        {
          int num4 = (int) this.readBuffer[index2];
        }
      }
      if (Main.netMode == 2 && num2 != (byte) 38 && Netplay.serverSock[this.whoAmI].state == -1)
      {
        NetMessage.SendData(2, this.whoAmI, text: Lang.mp[1]);
      }
      else
      {
        if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state < 10 && num2 > (byte) 12 && num2 != (byte) 16 && num2 != (byte) 42 && num2 != (byte) 50 && num2 != (byte) 38)
          NetMessage.BootPlayer(this.whoAmI, Lang.mp[2]);
        if (num2 == (byte) 1 && Main.netMode == 2)
        {
          if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
          {
            NetMessage.SendData(2, this.whoAmI, text: Lang.mp[3]);
          }
          else
          {
            if (Netplay.serverSock[this.whoAmI].state != 0)
              return;
            if (Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1) == "Terraria" + (object) Main.curRelease)
            {
              if (Netplay.password == null || Netplay.password == "")
              {
                Netplay.serverSock[this.whoAmI].state = 1;
                NetMessage.SendData(3, this.whoAmI);
              }
              else
              {
                Netplay.serverSock[this.whoAmI].state = -1;
                NetMessage.SendData(37, this.whoAmI);
              }
            }
            else
              NetMessage.SendData(2, this.whoAmI, text: Lang.mp[4]);
          }
        }
        else if (num2 == (byte) 2 && Main.netMode == 1)
        {
          Netplay.disconnect = true;
          Main.statusText = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
        }
        else if (num2 == (byte) 3 && Main.netMode == 1)
        {
          if (Netplay.clientSock.state == 1)
            Netplay.clientSock.state = 2;
          int index3 = (int) this.readBuffer[start + 1];
          if (index3 != Main.myPlayer)
          {
            Main.player[index3] = (Player) Main.player[Main.myPlayer].Clone();
            Main.player[Main.myPlayer] = new Player();
            Main.player[index3].whoAmi = index3;
            Main.myPlayer = index3;
          }
          NetMessage.SendData(4, text: Main.player[Main.myPlayer].name, number: Main.myPlayer);
          NetMessage.SendData(16, number: Main.myPlayer);
          NetMessage.SendData(42, number: Main.myPlayer);
          NetMessage.SendData(50, number: Main.myPlayer);
          for (int index4 = 0; index4 < 49; ++index4)
            NetMessage.SendData(5, text: Main.player[Main.myPlayer].inventory[index4].name, number: Main.myPlayer, number2: ((float) index4), number3: ((float) Main.player[Main.myPlayer].inventory[index4].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[0].name, number: Main.myPlayer, number2: 49f, number3: ((float) Main.player[Main.myPlayer].armor[0].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[1].name, number: Main.myPlayer, number2: 50f, number3: ((float) Main.player[Main.myPlayer].armor[1].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[2].name, number: Main.myPlayer, number2: 51f, number3: ((float) Main.player[Main.myPlayer].armor[2].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[3].name, number: Main.myPlayer, number2: 52f, number3: ((float) Main.player[Main.myPlayer].armor[3].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[4].name, number: Main.myPlayer, number2: 53f, number3: ((float) Main.player[Main.myPlayer].armor[4].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[5].name, number: Main.myPlayer, number2: 54f, number3: ((float) Main.player[Main.myPlayer].armor[5].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[6].name, number: Main.myPlayer, number2: 55f, number3: ((float) Main.player[Main.myPlayer].armor[6].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[7].name, number: Main.myPlayer, number2: 56f, number3: ((float) Main.player[Main.myPlayer].armor[7].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[8].name, number: Main.myPlayer, number2: 57f, number3: ((float) Main.player[Main.myPlayer].armor[8].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[9].name, number: Main.myPlayer, number2: 58f, number3: ((float) Main.player[Main.myPlayer].armor[9].prefix));
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[10].name, number: Main.myPlayer, number2: 59f, number3: ((float) Main.player[Main.myPlayer].armor[10].prefix));
          NetMessage.SendData(6);
          if (Netplay.clientSock.state != 2)
            return;
          Netplay.clientSock.state = 3;
        }
        else
        {
          switch (num2)
          {
            case 4:
              bool flag1 = false;
              int whoAmI1 = (int) this.readBuffer[start + 1];
              if (Main.netMode == 2)
                whoAmI1 = this.whoAmI;
              if (whoAmI1 == Main.myPlayer)
                break;
              int num5 = (int) this.readBuffer[start + 2];
              if (num5 >= 36)
                num5 = 0;
              Main.player[whoAmI1].hair = num5;
              Main.player[whoAmI1].whoAmi = whoAmI1;
              int index5 = index1 + 2;
              byte num6 = this.readBuffer[index5];
              int index6 = index5 + 1;
              Main.player[whoAmI1].male = num6 == (byte) 1;
              Main.player[whoAmI1].hairColor.R = this.readBuffer[index6];
              int index7 = index6 + 1;
              Main.player[whoAmI1].hairColor.G = this.readBuffer[index7];
              int index8 = index7 + 1;
              Main.player[whoAmI1].hairColor.B = this.readBuffer[index8];
              int index9 = index8 + 1;
              Main.player[whoAmI1].skinColor.R = this.readBuffer[index9];
              int index10 = index9 + 1;
              Main.player[whoAmI1].skinColor.G = this.readBuffer[index10];
              int index11 = index10 + 1;
              Main.player[whoAmI1].skinColor.B = this.readBuffer[index11];
              int index12 = index11 + 1;
              Main.player[whoAmI1].eyeColor.R = this.readBuffer[index12];
              int index13 = index12 + 1;
              Main.player[whoAmI1].eyeColor.G = this.readBuffer[index13];
              int index14 = index13 + 1;
              Main.player[whoAmI1].eyeColor.B = this.readBuffer[index14];
              int index15 = index14 + 1;
              Main.player[whoAmI1].shirtColor.R = this.readBuffer[index15];
              int index16 = index15 + 1;
              Main.player[whoAmI1].shirtColor.G = this.readBuffer[index16];
              int index17 = index16 + 1;
              Main.player[whoAmI1].shirtColor.B = this.readBuffer[index17];
              int index18 = index17 + 1;
              Main.player[whoAmI1].underShirtColor.R = this.readBuffer[index18];
              int index19 = index18 + 1;
              Main.player[whoAmI1].underShirtColor.G = this.readBuffer[index19];
              int index20 = index19 + 1;
              Main.player[whoAmI1].underShirtColor.B = this.readBuffer[index20];
              int index21 = index20 + 1;
              Main.player[whoAmI1].pantsColor.R = this.readBuffer[index21];
              int index22 = index21 + 1;
              Main.player[whoAmI1].pantsColor.G = this.readBuffer[index22];
              int index23 = index22 + 1;
              Main.player[whoAmI1].pantsColor.B = this.readBuffer[index23];
              int index24 = index23 + 1;
              Main.player[whoAmI1].shoeColor.R = this.readBuffer[index24];
              int index25 = index24 + 1;
              Main.player[whoAmI1].shoeColor.G = this.readBuffer[index25];
              int index26 = index25 + 1;
              Main.player[whoAmI1].shoeColor.B = this.readBuffer[index26];
              int index27 = index26 + 1;
              byte num7 = this.readBuffer[index27];
              Main.player[whoAmI1].difficulty = num7;
              int index28 = index27 + 1;
              string text1 = Encoding.UTF8.GetString(this.readBuffer, index28, length - index28 + start).Trim();
              Main.player[whoAmI1].name = text1.Trim();
              if (Main.netMode != 2)
                break;
              if (Netplay.serverSock[this.whoAmI].state < 10)
              {
                for (int index29 = 0; index29 < (int) byte.MaxValue; ++index29)
                {
                  if (index29 != whoAmI1 && text1 == Main.player[index29].name && Netplay.serverSock[index29].active)
                    flag1 = true;
                }
              }
              if (flag1)
              {
                NetMessage.SendData(2, this.whoAmI, text: (text1 + " " + Lang.mp[5]));
                break;
              }
              if (text1.Length > Player.nameLen)
              {
                NetMessage.SendData(2, this.whoAmI, text: "Name is too long.");
                break;
              }
              if (text1 == "")
              {
                NetMessage.SendData(2, this.whoAmI, text: "Empty name.");
                break;
              }
              Netplay.serverSock[this.whoAmI].oldName = text1;
              Netplay.serverSock[this.whoAmI].name = text1;
              NetMessage.SendData(4, ignoreClient: this.whoAmI, text: text1, number: whoAmI1);
              break;
            case 5:
              int whoAmI2 = (int) this.readBuffer[start + 1];
              if (Main.netMode == 2)
                whoAmI2 = this.whoAmI;
              if (whoAmI2 == Main.myPlayer)
                break;
              lock (Main.player[whoAmI2])
              {
                int index30 = (int) this.readBuffer[start + 2];
                int num8 = (int) this.readBuffer[start + 3];
                byte num9 = this.readBuffer[start + 4];
                int int16 = (int) BitConverter.ToInt16(this.readBuffer, start + 5);
                if (index30 < 49)
                {
                  Main.player[whoAmI2].inventory[index30] = new Item();
                  Main.player[whoAmI2].inventory[index30].netDefaults(int16);
                  Main.player[whoAmI2].inventory[index30].stack = num8;
                  Main.player[whoAmI2].inventory[index30].Prefix((int) num9);
                }
                else
                {
                  Main.player[whoAmI2].armor[index30 - 48 - 1] = new Item();
                  Main.player[whoAmI2].armor[index30 - 48 - 1].netDefaults(int16);
                  Main.player[whoAmI2].armor[index30 - 48 - 1].stack = num8;
                  Main.player[whoAmI2].armor[index30 - 48 - 1].Prefix((int) num9);
                }
                if (Main.netMode != 2 || whoAmI2 != this.whoAmI)
                  break;
                NetMessage.SendData(5, ignoreClient: this.whoAmI, number: whoAmI2, number2: ((float) index30), number3: ((float) num9));
                break;
              }
            case 6:
              if (Main.netMode != 2)
                break;
              if (Netplay.serverSock[this.whoAmI].state == 1)
                Netplay.serverSock[this.whoAmI].state = 2;
              NetMessage.SendData(7, this.whoAmI);
              break;
            case 7:
              if (Main.netMode != 1)
                break;
              Main.time = (double) BitConverter.ToInt32(this.readBuffer, index1);
              int index31 = index1 + 4;
              Main.dayTime = false;
              if (this.readBuffer[index31] == (byte) 1)
                Main.dayTime = true;
              int index32 = index31 + 1;
              Main.moonPhase = (int) this.readBuffer[index32];
              int index33 = index32 + 1;
              int num10 = (int) this.readBuffer[index33];
              int startIndex1 = index33 + 1;
              Main.bloodMoon = num10 == 1;
              Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, startIndex1);
              int startIndex2 = startIndex1 + 4;
              Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, startIndex2);
              int startIndex3 = startIndex2 + 4;
              Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, startIndex3);
              int startIndex4 = startIndex3 + 4;
              Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, startIndex4);
              int startIndex5 = startIndex4 + 4;
              Main.worldSurface = (double) BitConverter.ToInt32(this.readBuffer, startIndex5);
              int startIndex6 = startIndex5 + 4;
              Main.rockLayer = (double) BitConverter.ToInt32(this.readBuffer, startIndex6);
              int startIndex7 = startIndex6 + 4;
              Main.worldID = BitConverter.ToInt32(this.readBuffer, startIndex7);
              int index34 = startIndex7 + 4;
              byte num11 = this.readBuffer[index34];
              if (((int) num11 & 1) == 1)
                WorldGen.shadowOrbSmashed = true;
              if (((int) num11 & 2) == 2)
                NPC.downedBoss1 = true;
              if (((int) num11 & 4) == 4)
                NPC.downedBoss2 = true;
              if (((int) num11 & 8) == 8)
                NPC.downedBoss3 = true;
              if (((int) num11 & 16) == 16)
                Main.hardMode = true;
              if (((int) num11 & 32) == 32)
                NPC.downedClown = true;
              int index35 = index34 + 1;
              Main.worldName = Encoding.UTF8.GetString(this.readBuffer, index35, length - index35 + start);
              if (Netplay.clientSock.state != 3)
                break;
              Netplay.clientSock.state = 4;
              break;
            case 8:
              if (Main.netMode != 2)
                break;
              int int32_1 = BitConverter.ToInt32(this.readBuffer, index1);
              int startIndex8 = index1 + 4;
              int int32_2 = BitConverter.ToInt32(this.readBuffer, startIndex8);
              num1 = startIndex8 + 4;
              bool flag2 = true;
              if (int32_1 == -1 || int32_2 == -1)
                flag2 = false;
              else if (int32_1 < 10 || int32_1 > Main.maxTilesX - 10)
                flag2 = false;
              else if (int32_2 < 10 || int32_2 > Main.maxTilesY - 10)
                flag2 = false;
              int number1 = 1350;
              if (flag2)
                number1 *= 2;
              if (Netplay.serverSock[this.whoAmI].state == 2)
                Netplay.serverSock[this.whoAmI].state = 3;
              NetMessage.SendData(9, this.whoAmI, text: Lang.inter[44], number: number1);
              Netplay.serverSock[this.whoAmI].statusText2 = "is receiving tile data";
              Netplay.serverSock[this.whoAmI].statusMax += number1;
              int sectionX1 = Netplay.GetSectionX(Main.spawnTileX);
              int sectionY1 = Netplay.GetSectionY(Main.spawnTileY);
              for (int sectionX2 = sectionX1 - 2; sectionX2 < sectionX1 + 3; ++sectionX2)
              {
                for (int sectionY2 = sectionY1 - 1; sectionY2 < sectionY1 + 2; ++sectionY2)
                  NetMessage.SendSection(this.whoAmI, sectionX2, sectionY2);
              }
              if (flag2)
              {
                int sectionX3 = Netplay.GetSectionX(int32_1);
                int sectionY3 = Netplay.GetSectionY(int32_2);
                for (int sectionX4 = sectionX3 - 2; sectionX4 < sectionX3 + 3; ++sectionX4)
                {
                  for (int sectionY4 = sectionY3 - 1; sectionY4 < sectionY3 + 2; ++sectionY4)
                    NetMessage.SendSection(this.whoAmI, sectionX4, sectionY4);
                }
                NetMessage.SendData(11, this.whoAmI, number: (sectionX3 - 2), number2: ((float) (sectionY3 - 1)), number3: ((float) (sectionX3 + 2)), number4: ((float) (sectionY3 + 1)));
              }
              NetMessage.SendData(11, this.whoAmI, number: (sectionX1 - 2), number2: ((float) (sectionY1 - 1)), number3: ((float) (sectionX1 + 2)), number4: ((float) (sectionY1 + 1)));
              for (int number2 = 0; number2 < 200; ++number2)
              {
                if (Main.item[number2].active)
                {
                  NetMessage.SendData(21, this.whoAmI, number: number2);
                  NetMessage.SendData(22, this.whoAmI, number: number2);
                }
              }
              for (int number3 = 0; number3 < 200; ++number3)
              {
                if (Main.npc[number3].active)
                  NetMessage.SendData(23, this.whoAmI, number: number3);
              }
              NetMessage.SendData(49, this.whoAmI);
              NetMessage.SendData(57, this.whoAmI);
              NetMessage.SendData(56, this.whoAmI, number: 17);
              NetMessage.SendData(56, this.whoAmI, number: 18);
              NetMessage.SendData(56, this.whoAmI, number: 19);
              NetMessage.SendData(56, this.whoAmI, number: 20);
              NetMessage.SendData(56, this.whoAmI, number: 22);
              NetMessage.SendData(56, this.whoAmI, number: 38);
              NetMessage.SendData(56, this.whoAmI, number: 54);
              NetMessage.SendData(56, this.whoAmI, number: 107);
              NetMessage.SendData(56, this.whoAmI, number: 108);
              NetMessage.SendData(56, this.whoAmI, number: 124);
              break;
            case 9:
              if (Main.netMode != 1)
                break;
              int int32_3 = BitConverter.ToInt32(this.readBuffer, start + 1);
              string str1 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
              Netplay.clientSock.statusMax += int32_3;
              Netplay.clientSock.statusText = str1;
              break;
            default:
              if (num2 == (byte) 10 && Main.netMode == 1)
              {
                short int16_1 = BitConverter.ToInt16(this.readBuffer, start + 1);
                int int32_4 = BitConverter.ToInt32(this.readBuffer, start + 3);
                int int32_5 = BitConverter.ToInt32(this.readBuffer, start + 7);
                int index36 = start + 11;
                int index37;
                for (int index38 = int32_4; index38 < int32_4 + (int) int16_1; index38 = index37 + 1)
                {
                  if (Main.tile[index38, int32_5] == null)
                    Main.tile[index38, int32_5] = new Tile();
                  byte num12 = this.readBuffer[index36];
                  int startIndex9 = index36 + 1;
                  bool active = Main.tile[index38, int32_5].active;
                  Main.tile[index38, int32_5].active = ((int) num12 & 1) == 1;
                  int num13 = (int) num12 & 2;
                  Main.tile[index38, int32_5].wall = ((int) num12 & 4) != 4 ? (byte) 0 : (byte) 1;
                  Main.tile[index38, int32_5].liquid = ((int) num12 & 8) != 8 ? (byte) 0 : (byte) 1;
                  Main.tile[index38, int32_5].wire = ((int) num12 & 16) == 16;
                  if (Main.tile[index38, int32_5].active)
                  {
                    int type = (int) Main.tile[index38, int32_5].type;
                    Main.tile[index38, int32_5].type = this.readBuffer[startIndex9];
                    ++startIndex9;
                    if (Main.tileFrameImportant[(int) Main.tile[index38, int32_5].type])
                    {
                      Main.tile[index38, int32_5].frameX = BitConverter.ToInt16(this.readBuffer, startIndex9);
                      int startIndex10 = startIndex9 + 2;
                      Main.tile[index38, int32_5].frameY = BitConverter.ToInt16(this.readBuffer, startIndex10);
                      startIndex9 = startIndex10 + 2;
                    }
                    else if (!active || (int) Main.tile[index38, int32_5].type != type)
                    {
                      Main.tile[index38, int32_5].frameX = (short) -1;
                      Main.tile[index38, int32_5].frameY = (short) -1;
                    }
                  }
                  if (Main.tile[index38, int32_5].wall > (byte) 0)
                  {
                    Main.tile[index38, int32_5].wall = this.readBuffer[startIndex9];
                    ++startIndex9;
                  }
                  if (Main.tile[index38, int32_5].liquid > (byte) 0)
                  {
                    Main.tile[index38, int32_5].liquid = this.readBuffer[startIndex9];
                    int index39 = startIndex9 + 1;
                    byte num14 = this.readBuffer[index39];
                    startIndex9 = index39 + 1;
                    Main.tile[index38, int32_5].lava = num14 == (byte) 1;
                  }
                  short int16_2 = BitConverter.ToInt16(this.readBuffer, startIndex9);
                  index36 = startIndex9 + 2;
                  index37 = index38;
                  while (int16_2 > (short) 0)
                  {
                    ++index37;
                    --int16_2;
                    if (Main.tile[index37, int32_5] == null)
                      Main.tile[index37, int32_5] = new Tile();
                    Main.tile[index37, int32_5].active = Main.tile[index38, int32_5].active;
                    Main.tile[index37, int32_5].type = Main.tile[index38, int32_5].type;
                    Main.tile[index37, int32_5].wall = Main.tile[index38, int32_5].wall;
                    Main.tile[index37, int32_5].wire = Main.tile[index38, int32_5].wire;
                    if (Main.tileFrameImportant[(int) Main.tile[index37, int32_5].type])
                    {
                      Main.tile[index37, int32_5].frameX = Main.tile[index38, int32_5].frameX;
                      Main.tile[index37, int32_5].frameY = Main.tile[index38, int32_5].frameY;
                    }
                    else
                    {
                      Main.tile[index37, int32_5].frameX = (short) -1;
                      Main.tile[index37, int32_5].frameY = (short) -1;
                    }
                    Main.tile[index37, int32_5].liquid = Main.tile[index38, int32_5].liquid;
                    Main.tile[index37, int32_5].lava = Main.tile[index38, int32_5].lava;
                  }
                }
                if (Main.netMode != 2)
                  break;
                NetMessage.SendData((int) num2, ignoreClient: this.whoAmI, number: ((int) int16_1), number2: ((float) int32_4), number3: ((float) int32_5));
                break;
              }
              switch (num2)
              {
                case 11:
                  if (Main.netMode != 1)
                    return;
                  int int16_3 = (int) BitConverter.ToInt16(this.readBuffer, index1);
                  int startIndex11 = index1 + 4;
                  int int16_4 = (int) BitConverter.ToInt16(this.readBuffer, startIndex11);
                  int startIndex12 = startIndex11 + 4;
                  int int16_5 = (int) BitConverter.ToInt16(this.readBuffer, startIndex12);
                  int startIndex13 = startIndex12 + 4;
                  int int16_6 = (int) BitConverter.ToInt16(this.readBuffer, startIndex13);
                  num1 = startIndex13 + 4;
                  WorldGen.SectionTileFrame(int16_3, int16_4, int16_5, int16_6);
                  return;
                case 12:
                  int whoAmI3 = (int) this.readBuffer[index1];
                  if (Main.netMode == 2)
                    whoAmI3 = this.whoAmI;
                  int startIndex14 = index1 + 1;
                  Main.player[whoAmI3].SpawnX = BitConverter.ToInt32(this.readBuffer, startIndex14);
                  int startIndex15 = startIndex14 + 4;
                  Main.player[whoAmI3].SpawnY = BitConverter.ToInt32(this.readBuffer, startIndex15);
                  num1 = startIndex15 + 4;
                  Main.player[whoAmI3].Spawn();
                  if (Main.netMode != 2 || Netplay.serverSock[this.whoAmI].state < 3)
                    return;
                  if (Netplay.serverSock[this.whoAmI].state == 3)
                  {
                    Netplay.serverSock[this.whoAmI].state = 10;
                    NetMessage.greetPlayer(this.whoAmI);
                    NetMessage.buffer[this.whoAmI].broadcast = true;
                    NetMessage.syncPlayers();
                    NetMessage.SendData(12, ignoreClient: this.whoAmI, number: this.whoAmI);
                    return;
                  }
                  NetMessage.SendData(12, ignoreClient: this.whoAmI, number: this.whoAmI);
                  return;
                case 13:
                  int whoAmI4 = (int) this.readBuffer[index1];
                  if (whoAmI4 == Main.myPlayer)
                    return;
                  if (Main.netMode == 1)
                  {
                    int num15 = Main.player[whoAmI4].active ? 1 : 0;
                  }
                  if (Main.netMode == 2)
                    whoAmI4 = this.whoAmI;
                  int index40 = index1 + 1;
                  int num16 = (int) this.readBuffer[index40];
                  int index41 = index40 + 1;
                  int num17 = (int) this.readBuffer[index41];
                  int startIndex16 = index41 + 1;
                  float single1 = BitConverter.ToSingle(this.readBuffer, startIndex16);
                  int startIndex17 = startIndex16 + 4;
                  float single2 = BitConverter.ToSingle(this.readBuffer, startIndex17);
                  int startIndex18 = startIndex17 + 4;
                  float single3 = BitConverter.ToSingle(this.readBuffer, startIndex18);
                  int startIndex19 = startIndex18 + 4;
                  float single4 = BitConverter.ToSingle(this.readBuffer, startIndex19);
                  num1 = startIndex19 + 4;
                  Main.player[whoAmI4].selectedItem = num17;
                  Main.player[whoAmI4].position.X = single1;
                  Main.player[whoAmI4].position.Y = single2;
                  Main.player[whoAmI4].velocity.X = single3;
                  Main.player[whoAmI4].velocity.Y = single4;
                  Main.player[whoAmI4].oldVelocity = Main.player[whoAmI4].velocity;
                  Main.player[whoAmI4].fallStart = (int) ((double) single2 / 16.0);
                  Main.player[whoAmI4].controlUp = false;
                  Main.player[whoAmI4].controlDown = false;
                  Main.player[whoAmI4].controlLeft = false;
                  Main.player[whoAmI4].controlRight = false;
                  Main.player[whoAmI4].controlJump = false;
                  Main.player[whoAmI4].controlUseItem = false;
                  Main.player[whoAmI4].direction = -1;
                  if ((num16 & 1) == 1)
                    Main.player[whoAmI4].controlUp = true;
                  if ((num16 & 2) == 2)
                    Main.player[whoAmI4].controlDown = true;
                  if ((num16 & 4) == 4)
                    Main.player[whoAmI4].controlLeft = true;
                  if ((num16 & 8) == 8)
                    Main.player[whoAmI4].controlRight = true;
                  if ((num16 & 16) == 16)
                    Main.player[whoAmI4].controlJump = true;
                  if ((num16 & 32) == 32)
                    Main.player[whoAmI4].controlUseItem = true;
                  if ((num16 & 64) == 64)
                    Main.player[whoAmI4].direction = 1;
                  if (Main.netMode != 2 || Netplay.serverSock[this.whoAmI].state != 10)
                    return;
                  NetMessage.SendData(13, ignoreClient: this.whoAmI, number: whoAmI4);
                  return;
                case 14:
                  if (Main.netMode != 1)
                    return;
                  int index42 = (int) this.readBuffer[index1];
                  if (this.readBuffer[index1 + 1] == (byte) 1)
                  {
                    if (!Main.player[index42].active)
                      Main.player[index42] = new Player();
                    Main.player[index42].active = true;
                    return;
                  }
                  Main.player[index42].active = false;
                  return;
                case 15:
                  if (Main.netMode != 2)
                    ;
                  return;
                case 16:
                  int whoAmI5 = (int) this.readBuffer[index1];
                  int startIndex20 = index1 + 1;
                  if (whoAmI5 == Main.myPlayer)
                    return;
                  int int16_7 = (int) BitConverter.ToInt16(this.readBuffer, startIndex20);
                  int int16_8 = (int) BitConverter.ToInt16(this.readBuffer, startIndex20 + 2);
                  if (Main.netMode == 2)
                    whoAmI5 = this.whoAmI;
                  Main.player[whoAmI5].statLife = int16_7;
                  Main.player[whoAmI5].statLifeMax = int16_8;
                  if (Main.player[whoAmI5].statLife <= 0)
                    Main.player[whoAmI5].dead = true;
                  if (Main.netMode != 2)
                    return;
                  NetMessage.SendData(16, ignoreClient: this.whoAmI, number: whoAmI5);
                  return;
                case 17:
                  byte num18 = this.readBuffer[index1];
                  int startIndex21 = index1 + 1;
                  int int32_6 = BitConverter.ToInt32(this.readBuffer, startIndex21);
                  int startIndex22 = startIndex21 + 4;
                  int int32_7 = BitConverter.ToInt32(this.readBuffer, startIndex22);
                  int index43 = startIndex22 + 4;
                  byte num19 = this.readBuffer[index43];
                  int num20 = (int) this.readBuffer[index43 + 1];
                  bool fail = false;
                  if (num19 == (byte) 1)
                    fail = true;
                  if (Main.tile[int32_6, int32_7] == null)
                    Main.tile[int32_6, int32_7] = new Tile();
                  if (Main.netMode == 2)
                  {
                    if (!fail)
                    {
                      switch (num18)
                      {
                        case 0:
                        case 2:
                        case 4:
                          ++Netplay.serverSock[this.whoAmI].spamDelBlock;
                          break;
                        case 1:
                        case 3:
                          ++Netplay.serverSock[this.whoAmI].spamAddBlock;
                          break;
                      }
                    }
                    if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(int32_6), Netplay.GetSectionY(int32_7)])
                      fail = true;
                  }
                  switch (num18)
                  {
                    case 0:
                      WorldGen.KillTile(int32_6, int32_7, fail);
                      break;
                    case 1:
                      WorldGen.PlaceTile(int32_6, int32_7, (int) num19, forced: true, style: num20);
                      break;
                    case 2:
                      WorldGen.KillWall(int32_6, int32_7, fail);
                      break;
                    case 3:
                      WorldGen.PlaceWall(int32_6, int32_7, (int) num19);
                      break;
                    case 4:
                      WorldGen.KillTile(int32_6, int32_7, fail, noItem: true);
                      break;
                    case 5:
                      WorldGen.PlaceWire(int32_6, int32_7);
                      break;
                    case 6:
                      WorldGen.KillWire(int32_6, int32_7);
                      break;
                  }
                  if (Main.netMode != 2)
                    return;
                  NetMessage.SendData(17, ignoreClient: this.whoAmI, number: ((int) num18), number2: ((float) int32_6), number3: ((float) int32_7), number4: ((float) num19), number5: num20);
                  if (num18 != (byte) 1 || num19 != (byte) 53)
                    return;
                  NetMessage.SendTileSquare(-1, int32_6, int32_7, 1);
                  return;
                case 18:
                  if (Main.netMode != 1)
                    return;
                  byte num21 = this.readBuffer[index1];
                  int startIndex23 = index1 + 1;
                  int int32_8 = BitConverter.ToInt32(this.readBuffer, startIndex23);
                  int startIndex24 = startIndex23 + 4;
                  short int16_9 = BitConverter.ToInt16(this.readBuffer, startIndex24);
                  int startIndex25 = startIndex24 + 2;
                  short int16_10 = BitConverter.ToInt16(this.readBuffer, startIndex25);
                  num1 = startIndex25 + 2;
                  Main.dayTime = num21 == (byte) 1;
                  Main.time = (double) int32_8;
                  Main.sunModY = int16_9;
                  Main.moonModY = int16_10;
                  if (Main.netMode != 2)
                    return;
                  NetMessage.SendData(18, ignoreClient: this.whoAmI);
                  return;
                case 19:
                  byte num22 = this.readBuffer[index1];
                  int startIndex26 = index1 + 1;
                  int int32_9 = BitConverter.ToInt32(this.readBuffer, startIndex26);
                  int startIndex27 = startIndex26 + 4;
                  int int32_10 = BitConverter.ToInt32(this.readBuffer, startIndex27);
                  int num23 = (int) this.readBuffer[startIndex27 + 4];
                  int direction = 0;
                  if (num23 == 0)
                    direction = -1;
                  switch (num22)
                  {
                    case 0:
                      WorldGen.OpenDoor(int32_9, int32_10, direction);
                      break;
                    case 1:
                      WorldGen.CloseDoor(int32_9, int32_10, true);
                      break;
                  }
                  if (Main.netMode != 2)
                    return;
                  NetMessage.SendData(19, ignoreClient: this.whoAmI, number: ((int) num22), number2: ((float) int32_9), number3: ((float) int32_10), number4: ((float) num23));
                  return;
                case 20:
                  short int16_11 = BitConverter.ToInt16(this.readBuffer, start + 1);
                  int int32_11 = BitConverter.ToInt32(this.readBuffer, start + 3);
                  int int32_12 = BitConverter.ToInt32(this.readBuffer, start + 7);
                  int startIndex28 = start + 11;
                  if (Main.netMode == 2)
                  {
                    try
                    {
                      if (int16_11 > (short) 10)
                        return;
                      int num24 = int32_11 + (int) int16_11 / 2;
                      int num25 = int32_12;
                      int num26 = (int) ((double) Main.player[this.whoAmI].position.X + (double) (Main.player[this.whoAmI].width / 2)) / 16;
                      int num27 = (int) ((double) Main.player[this.whoAmI].position.Y + (double) (Main.player[this.whoAmI].height / 2)) / 16;
                      if (Math.Abs(num24 - num26) > 20)
                        return;
                      if (Math.Abs(num25 - num27) > 20)
                        return;
                    }
                    catch
                    {
                      return;
                    }
                  }
                  for (int index44 = int32_11; index44 < int32_11 + (int) int16_11; ++index44)
                  {
                    for (int index45 = int32_12; index45 < int32_12 + (int) int16_11; ++index45)
                    {
                      if (Main.tile[index44, index45] == null)
                        Main.tile[index44, index45] = new Tile();
                      byte num28 = this.readBuffer[startIndex28];
                      ++startIndex28;
                      bool active = Main.tile[index44, index45].active;
                      Main.tile[index44, index45].active = ((int) num28 & 1) == 1;
                      Main.tile[index44, index45].wall = ((int) num28 & 4) != 4 ? (byte) 0 : (byte) 1;
                      bool flag3 = false;
                      if (((int) num28 & 8) == 8)
                        flag3 = true;
                      if (Main.netMode != 2)
                        Main.tile[index44, index45].liquid = !flag3 ? (byte) 0 : (byte) 1;
                      Main.tile[index44, index45].wire = ((int) num28 & 16) == 16;
                      if (Main.tile[index44, index45].active)
                      {
                        int type = (int) Main.tile[index44, index45].type;
                        Main.tile[index44, index45].type = this.readBuffer[startIndex28];
                        ++startIndex28;
                        if (Main.tileFrameImportant[(int) Main.tile[index44, index45].type])
                        {
                          Main.tile[index44, index45].frameX = BitConverter.ToInt16(this.readBuffer, startIndex28);
                          int startIndex29 = startIndex28 + 2;
                          Main.tile[index44, index45].frameY = BitConverter.ToInt16(this.readBuffer, startIndex29);
                          startIndex28 = startIndex29 + 2;
                        }
                        else if (!active || (int) Main.tile[index44, index45].type != type)
                        {
                          Main.tile[index44, index45].frameX = (short) -1;
                          Main.tile[index44, index45].frameY = (short) -1;
                        }
                      }
                      if (Main.tile[index44, index45].wall > (byte) 0)
                      {
                        Main.tile[index44, index45].wall = this.readBuffer[startIndex28];
                        ++startIndex28;
                      }
                      if (flag3)
                      {
                        Main.tile[index44, index45].liquid = this.readBuffer[startIndex28];
                        int index46 = startIndex28 + 1;
                        byte num29 = this.readBuffer[index46];
                        startIndex28 = index46 + 1;
                        if (Main.netMode != 2)
                          Main.tile[index44, index45].lava = num29 == (byte) 1;
                      }
                    }
                  }
                  WorldGen.RangeFrame(int32_11, int32_12, int32_11 + (int) int16_11, int32_12 + (int) int16_11);
                  if (Main.netMode != 2)
                    return;
                  NetMessage.SendData((int) num2, ignoreClient: this.whoAmI, number: ((int) int16_11), number2: ((float) int32_11), number3: ((float) int32_12));
                  return;
                case 21:
                  short num30 = BitConverter.ToInt16(this.readBuffer, index1);
                  int startIndex30 = index1 + 2;
                  float single5 = BitConverter.ToSingle(this.readBuffer, startIndex30);
                  int startIndex31 = startIndex30 + 4;
                  float single6 = BitConverter.ToSingle(this.readBuffer, startIndex31);
                  int startIndex32 = startIndex31 + 4;
                  float single7 = BitConverter.ToSingle(this.readBuffer, startIndex32);
                  int startIndex33 = startIndex32 + 4;
                  float single8 = BitConverter.ToSingle(this.readBuffer, startIndex33);
                  int index47 = startIndex33 + 4;
                  byte num31 = this.readBuffer[index47];
                  int index48 = index47 + 1;
                  byte num32 = this.readBuffer[index48];
                  short int16_12 = BitConverter.ToInt16(this.readBuffer, index48 + 1);
                  if (Main.netMode == 1)
                  {
                    if (int16_12 == (short) 0)
                    {
                      Main.item[(int) num30].active = false;
                      return;
                    }
                    Main.item[(int) num30].netDefaults((int) int16_12);
                    Main.item[(int) num30].Prefix((int) num32);
                    Main.item[(int) num30].stack = (int) num31;
                    Main.item[(int) num30].position.X = single5;
                    Main.item[(int) num30].position.Y = single6;
                    Main.item[(int) num30].velocity.X = single7;
                    Main.item[(int) num30].velocity.Y = single8;
                    Main.item[(int) num30].active = true;
                    Main.item[(int) num30].wet = Collision.WetCollision(Main.item[(int) num30].position, Main.item[(int) num30].width, Main.item[(int) num30].height);
                    return;
                  }
                  if (int16_12 == (short) 0)
                  {
                    if (num30 >= (short) 200)
                      return;
                    Main.item[(int) num30].active = false;
                    NetMessage.SendData(21, number: ((int) num30));
                    return;
                  }
                  bool flag4 = false;
                  if (num30 == (short) 200)
                    flag4 = true;
                  if (flag4)
                  {
                    Item obj = new Item();
                    obj.netDefaults((int) int16_12);
                    num30 = (short) Item.NewItem((int) single5, (int) single6, obj.width, obj.height, obj.type, (int) num31, true);
                  }
                  Main.item[(int) num30].netDefaults((int) int16_12);
                  Main.item[(int) num30].Prefix((int) num32);
                  Main.item[(int) num30].stack = (int) num31;
                  Main.item[(int) num30].position.X = single5;
                  Main.item[(int) num30].position.Y = single6;
                  Main.item[(int) num30].velocity.X = single7;
                  Main.item[(int) num30].velocity.Y = single8;
                  Main.item[(int) num30].active = true;
                  Main.item[(int) num30].owner = Main.myPlayer;
                  if (flag4)
                  {
                    NetMessage.SendData(21, number: ((int) num30));
                    Main.item[(int) num30].ownIgnore = this.whoAmI;
                    Main.item[(int) num30].ownTime = 100;
                    Main.item[(int) num30].FindOwner((int) num30);
                    return;
                  }
                  NetMessage.SendData(21, ignoreClient: this.whoAmI, number: ((int) num30));
                  return;
                case 22:
                  short int16_13 = BitConverter.ToInt16(this.readBuffer, index1);
                  byte num33 = this.readBuffer[index1 + 2];
                  if (Main.netMode == 2 && Main.item[(int) int16_13].owner != this.whoAmI)
                    return;
                  Main.item[(int) int16_13].owner = (int) num33;
                  Main.item[(int) int16_13].keepTime = (int) num33 != Main.myPlayer ? 0 : 15;
                  if (Main.netMode != 2)
                    return;
                  Main.item[(int) int16_13].owner = (int) byte.MaxValue;
                  Main.item[(int) int16_13].keepTime = 15;
                  NetMessage.SendData(22, number: ((int) int16_13));
                  return;
                default:
                  if (num2 == (byte) 23 && Main.netMode == 1)
                  {
                    short int16_14 = BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex34 = index1 + 2;
                    float single9 = BitConverter.ToSingle(this.readBuffer, startIndex34);
                    int startIndex35 = startIndex34 + 4;
                    float single10 = BitConverter.ToSingle(this.readBuffer, startIndex35);
                    int startIndex36 = startIndex35 + 4;
                    float single11 = BitConverter.ToSingle(this.readBuffer, startIndex36);
                    int startIndex37 = startIndex36 + 4;
                    float single12 = BitConverter.ToSingle(this.readBuffer, startIndex37);
                    int startIndex38 = startIndex37 + 4;
                    int int16_15 = (int) BitConverter.ToInt16(this.readBuffer, startIndex38);
                    int index49 = startIndex38 + 2;
                    int num34 = (int) this.readBuffer[index49] - 1;
                    int index50 = index49 + 1;
                    int num35 = (int) this.readBuffer[index50] - 1;
                    int startIndex39 = index50 + 1;
                    int int32_13 = BitConverter.ToInt32(this.readBuffer, startIndex39);
                    int startIndex40 = startIndex39 + 4;
                    float[] numArray = new float[NPC.maxAI];
                    for (int index51 = 0; index51 < NPC.maxAI; ++index51)
                    {
                      numArray[index51] = BitConverter.ToSingle(this.readBuffer, startIndex40);
                      startIndex40 += 4;
                    }
                    int int16_16 = (int) BitConverter.ToInt16(this.readBuffer, startIndex40);
                    if (!Main.npc[(int) int16_14].active || Main.npc[(int) int16_14].netID != int16_16)
                    {
                      Main.npc[(int) int16_14].active = true;
                      Main.npc[(int) int16_14].netDefaults(int16_16);
                    }
                    Main.npc[(int) int16_14].position.X = single9;
                    Main.npc[(int) int16_14].position.Y = single10;
                    Main.npc[(int) int16_14].velocity.X = single11;
                    Main.npc[(int) int16_14].velocity.Y = single12;
                    Main.npc[(int) int16_14].target = int16_15;
                    Main.npc[(int) int16_14].direction = num34;
                    Main.npc[(int) int16_14].directionY = num35;
                    Main.npc[(int) int16_14].life = int32_13;
                    if (int32_13 <= 0)
                      Main.npc[(int) int16_14].active = false;
                    for (int index52 = 0; index52 < NPC.maxAI; ++index52)
                      Main.npc[(int) int16_14].ai[index52] = numArray[index52];
                    return;
                  }
                  switch (num2)
                  {
                    case 24:
                      short int16_17 = BitConverter.ToInt16(this.readBuffer, index1);
                      byte whoAmI6 = this.readBuffer[index1 + 2];
                      if (Main.netMode == 2)
                        whoAmI6 = (byte) this.whoAmI;
                      Main.npc[(int) int16_17].StrikeNPC(Main.player[(int) whoAmI6].inventory[Main.player[(int) whoAmI6].selectedItem].damage, Main.player[(int) whoAmI6].inventory[Main.player[(int) whoAmI6].selectedItem].knockBack, Main.player[(int) whoAmI6].direction);
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(24, ignoreClient: this.whoAmI, number: ((int) int16_17), number2: ((float) whoAmI6));
                      NetMessage.SendData(23, number: ((int) int16_17));
                      return;
                    case 25:
                      int whoAmI7 = (int) this.readBuffer[start + 1];
                      if (Main.netMode == 2)
                        whoAmI7 = this.whoAmI;
                      byte R = this.readBuffer[start + 2];
                      byte G = this.readBuffer[start + 3];
                      byte B = this.readBuffer[start + 4];
                      if (Main.netMode == 2)
                      {
                        R = byte.MaxValue;
                        G = byte.MaxValue;
                        B = byte.MaxValue;
                      }
                      string text2 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
                      if (Main.netMode == 1)
                      {
                        string newText = text2;
                        if (whoAmI7 < (int) byte.MaxValue)
                        {
                          newText = "<" + Main.player[whoAmI7].name + "> " + text2;
                          Main.player[whoAmI7].chatText = text2;
                          Main.player[whoAmI7].chatShowTime = Main.chatLength / 2;
                        }
                        Main.NewText(newText, R, G, B);
                        return;
                      }
                      if (Main.netMode != 2)
                        return;
                      string lower = text2.ToLower();
                      if (lower == Lang.mp[6])
                      {
                        string str2 = "";
                        for (int index53 = 0; index53 < (int) byte.MaxValue; ++index53)
                        {
                          if (Main.player[index53].active)
                            str2 = !(str2 == "") ? str2 + ", " + Main.player[index53].name : str2 + Main.player[index53].name;
                        }
                        NetMessage.SendData(25, this.whoAmI, text: (Lang.mp[7] + " " + str2 + "."), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
                        return;
                      }
                      if (lower.Length >= 4 && lower.Substring(0, 4) == "/me ")
                      {
                        NetMessage.SendData(25, text: ("*" + Main.player[this.whoAmI].name + " " + text2.Substring(4)), number: ((int) byte.MaxValue), number2: 200f, number3: 100f);
                        return;
                      }
                      if (lower == Lang.mp[8])
                      {
                        NetMessage.SendData(25, text: ("*" + Main.player[this.whoAmI].name + " " + Lang.mp[9] + " " + (object) Main.rand.Next(1, 101)), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
                        return;
                      }
                      if (lower.Length >= 3 && lower.Substring(0, 3) == "/p ")
                      {
                        if (Main.player[this.whoAmI].team != 0)
                        {
                          for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
                          {
                            if (Main.player[remoteClient].team == Main.player[this.whoAmI].team)
                              NetMessage.SendData(25, remoteClient, text: text2.Substring(3), number: whoAmI7, number2: ((float) Main.teamColor[Main.player[this.whoAmI].team].R), number3: ((float) Main.teamColor[Main.player[this.whoAmI].team].G), number4: ((float) Main.teamColor[Main.player[this.whoAmI].team].B));
                          }
                          return;
                        }
                        NetMessage.SendData(25, this.whoAmI, text: Lang.mp[10], number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
                        return;
                      }
                      if (Main.player[this.whoAmI].difficulty == (byte) 2)
                      {
                        R = Main.hcColor.R;
                        G = Main.hcColor.G;
                        B = Main.hcColor.B;
                      }
                      else if (Main.player[this.whoAmI].difficulty == (byte) 1)
                      {
                        R = Main.mcColor.R;
                        G = Main.mcColor.G;
                        B = Main.mcColor.B;
                      }
                      NetMessage.SendData(25, text: text2, number: whoAmI7, number2: ((float) R), number3: ((float) G), number4: ((float) B));
                      if (!Main.dedServ)
                        return;
                      Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + text2);
                      return;
                    case 26:
                      byte num36 = this.readBuffer[index1];
                      if (Main.netMode == 2 && this.whoAmI != (int) num36 && (!Main.player[(int) num36].hostile || !Main.player[this.whoAmI].hostile))
                        return;
                      int index54 = index1 + 1;
                      int hitDirection1 = (int) this.readBuffer[index54] - 1;
                      int startIndex41 = index54 + 1;
                      short int16_18 = BitConverter.ToInt16(this.readBuffer, startIndex41);
                      int index55 = startIndex41 + 2;
                      byte num37 = this.readBuffer[index55];
                      int index56 = index55 + 1;
                      bool pvp1 = false;
                      byte num38 = this.readBuffer[index56];
                      int index57 = index56 + 1;
                      bool Crit = false;
                      string str3 = Encoding.UTF8.GetString(this.readBuffer, index57, length - index57 + start);
                      if (num37 != (byte) 0)
                        pvp1 = true;
                      if (num38 != (byte) 0)
                        Crit = true;
                      Main.player[(int) num36].Hurt((int) int16_18, hitDirection1, pvp1, true, str3, Crit);
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(26, ignoreClient: this.whoAmI, text: str3, number: ((int) num36), number2: ((float) hitDirection1), number3: ((float) int16_18), number4: ((float) num37));
                      return;
                    case 27:
                      short int16_19 = BitConverter.ToInt16(this.readBuffer, index1);
                      int startIndex42 = index1 + 2;
                      float single13 = BitConverter.ToSingle(this.readBuffer, startIndex42);
                      int startIndex43 = startIndex42 + 4;
                      float single14 = BitConverter.ToSingle(this.readBuffer, startIndex43);
                      int startIndex44 = startIndex43 + 4;
                      float single15 = BitConverter.ToSingle(this.readBuffer, startIndex44);
                      int startIndex45 = startIndex44 + 4;
                      float single16 = BitConverter.ToSingle(this.readBuffer, startIndex45);
                      int startIndex46 = startIndex45 + 4;
                      float single17 = BitConverter.ToSingle(this.readBuffer, startIndex46);
                      int startIndex47 = startIndex46 + 4;
                      short int16_20 = BitConverter.ToInt16(this.readBuffer, startIndex47);
                      int index58 = startIndex47 + 2;
                      byte whoAmI8 = this.readBuffer[index58];
                      int index59 = index58 + 1;
                      byte num39 = this.readBuffer[index59];
                      int startIndex48 = index59 + 1;
                      float[] numArray1 = new float[Projectile.maxAI];
                      if (Main.netMode == 2)
                      {
                        whoAmI8 = (byte) this.whoAmI;
                        if (Main.projHostile[(int) num39])
                          return;
                      }
                      for (int index60 = 0; index60 < Projectile.maxAI; ++index60)
                      {
                        numArray1[index60] = BitConverter.ToSingle(this.readBuffer, startIndex48);
                        startIndex48 += 4;
                      }
                      int number4 = 1000;
                      for (int index61 = 0; index61 < 1000; ++index61)
                      {
                        if (Main.projectile[index61].owner == (int) whoAmI8 && Main.projectile[index61].identity == (int) int16_19 && Main.projectile[index61].active)
                        {
                          number4 = index61;
                          break;
                        }
                      }
                      if (number4 == 1000)
                      {
                        for (int index62 = 0; index62 < 1000; ++index62)
                        {
                          if (!Main.projectile[index62].active)
                          {
                            number4 = index62;
                            break;
                          }
                        }
                      }
                      if (!Main.projectile[number4].active || Main.projectile[number4].type != (int) num39)
                      {
                        Main.projectile[number4].SetDefaults((int) num39);
                        if (Main.netMode == 2)
                          ++Netplay.serverSock[this.whoAmI].spamProjectile;
                      }
                      Main.projectile[number4].identity = (int) int16_19;
                      Main.projectile[number4].position.X = single13;
                      Main.projectile[number4].position.Y = single14;
                      Main.projectile[number4].velocity.X = single15;
                      Main.projectile[number4].velocity.Y = single16;
                      Main.projectile[number4].damage = (int) int16_20;
                      Main.projectile[number4].type = (int) num39;
                      Main.projectile[number4].owner = (int) whoAmI8;
                      Main.projectile[number4].knockBack = single17;
                      for (int index63 = 0; index63 < Projectile.maxAI; ++index63)
                        Main.projectile[number4].ai[index63] = numArray1[index63];
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(27, ignoreClient: this.whoAmI, number: number4);
                      return;
                    case 28:
                      short int16_21 = BitConverter.ToInt16(this.readBuffer, index1);
                      int startIndex49 = index1 + 2;
                      short int16_22 = BitConverter.ToInt16(this.readBuffer, startIndex49);
                      int startIndex50 = startIndex49 + 2;
                      float single18 = BitConverter.ToSingle(this.readBuffer, startIndex50);
                      int index64 = startIndex50 + 4;
                      int hitDirection2 = (int) this.readBuffer[index64] - 1;
                      int number5 = (int) this.readBuffer[index64 + 1];
                      if (int16_22 >= (short) 0)
                      {
                        if (number5 == 1)
                          Main.npc[(int) int16_21].StrikeNPC((int) int16_22, single18, hitDirection2, true);
                        else
                          Main.npc[(int) int16_21].StrikeNPC((int) int16_22, single18, hitDirection2);
                      }
                      else
                      {
                        Main.npc[(int) int16_21].life = 0;
                        Main.npc[(int) int16_21].HitEffect();
                        Main.npc[(int) int16_21].active = false;
                      }
                      if (Main.netMode != 2)
                        return;
                      if (Main.npc[(int) int16_21].life <= 0)
                      {
                        NetMessage.SendData(28, ignoreClient: this.whoAmI, number: ((int) int16_21), number2: ((float) int16_22), number3: single18, number4: ((float) hitDirection2), number5: number5);
                        NetMessage.SendData(23, number: ((int) int16_21));
                        return;
                      }
                      NetMessage.SendData(28, ignoreClient: this.whoAmI, number: ((int) int16_21), number2: ((float) int16_22), number3: single18, number4: ((float) hitDirection2), number5: number5);
                      Main.npc[(int) int16_21].netUpdate = true;
                      return;
                    case 29:
                      short int16_23 = BitConverter.ToInt16(this.readBuffer, index1);
                      byte whoAmI9 = this.readBuffer[index1 + 2];
                      if (Main.netMode == 2)
                        whoAmI9 = (byte) this.whoAmI;
                      for (int index65 = 0; index65 < 1000; ++index65)
                      {
                        if (Main.projectile[index65].owner == (int) whoAmI9 && Main.projectile[index65].identity == (int) int16_23 && Main.projectile[index65].active)
                        {
                          Main.projectile[index65].Kill();
                          break;
                        }
                      }
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(29, ignoreClient: this.whoAmI, number: ((int) int16_23), number2: ((float) whoAmI9));
                      return;
                    case 30:
                      byte whoAmI10 = this.readBuffer[index1];
                      if (Main.netMode == 2)
                        whoAmI10 = (byte) this.whoAmI;
                      byte num40 = this.readBuffer[index1 + 1];
                      Main.player[(int) whoAmI10].hostile = num40 == (byte) 1;
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(30, ignoreClient: this.whoAmI, number: ((int) whoAmI10));
                      string str4 = " " + Lang.mp[11];
                      if (num40 == (byte) 0)
                        str4 = " " + Lang.mp[12];
                      NetMessage.SendData(25, text: (Main.player[(int) whoAmI10].name + str4), number: ((int) byte.MaxValue), number2: ((float) Main.teamColor[Main.player[(int) whoAmI10].team].R), number3: ((float) Main.teamColor[Main.player[(int) whoAmI10].team].G), number4: ((float) Main.teamColor[Main.player[(int) whoAmI10].team].B));
                      return;
                    case 31:
                      if (Main.netMode != 2)
                        return;
                      int int32_14 = BitConverter.ToInt32(this.readBuffer, index1);
                      int startIndex51 = index1 + 4;
                      int int32_15 = BitConverter.ToInt32(this.readBuffer, startIndex51);
                      num1 = startIndex51 + 4;
                      int chest = Chest.FindChest(int32_14, int32_15);
                      if (chest <= -1 || Chest.UsingChest(chest) != -1)
                        return;
                      for (int index66 = 0; index66 < Chest.maxItems; ++index66)
                        NetMessage.SendData(32, this.whoAmI, number: chest, number2: ((float) index66));
                      NetMessage.SendData(33, this.whoAmI, number: chest);
                      Main.player[this.whoAmI].chest = chest;
                      return;
                    case 32:
                      int int16_24 = (int) BitConverter.ToInt16(this.readBuffer, index1);
                      int index67 = index1 + 2;
                      int index68 = (int) this.readBuffer[index67];
                      int index69 = index67 + 1;
                      int num41 = (int) this.readBuffer[index69];
                      int index70 = index69 + 1;
                      int pre = (int) this.readBuffer[index70];
                      int int16_25 = (int) BitConverter.ToInt16(this.readBuffer, index70 + 1);
                      if (Main.chest[int16_24] == null)
                        Main.chest[int16_24] = new Chest();
                      if (Main.chest[int16_24].item[index68] == null)
                        Main.chest[int16_24].item[index68] = new Item();
                      Main.chest[int16_24].item[index68].netDefaults(int16_25);
                      Main.chest[int16_24].item[index68].Prefix(pre);
                      Main.chest[int16_24].item[index68].stack = num41;
                      return;
                    case 33:
                      int int16_26 = (int) BitConverter.ToInt16(this.readBuffer, index1);
                      int startIndex52 = index1 + 2;
                      int int32_16 = BitConverter.ToInt32(this.readBuffer, startIndex52);
                      int int32_17 = BitConverter.ToInt32(this.readBuffer, startIndex52 + 4);
                      if (Main.netMode == 1)
                      {
                        if (Main.player[Main.myPlayer].chest == -1)
                        {
                          Main.playerInventory = true;
                          Main.PlaySound(10);
                        }
                        else if (Main.player[Main.myPlayer].chest != int16_26 && int16_26 != -1)
                        {
                          Main.playerInventory = true;
                          Main.PlaySound(12);
                        }
                        else if (Main.player[Main.myPlayer].chest != -1 && int16_26 == -1)
                          Main.PlaySound(11);
                        Main.player[Main.myPlayer].chest = int16_26;
                        Main.player[Main.myPlayer].chestX = int32_16;
                        Main.player[Main.myPlayer].chestY = int32_17;
                        return;
                      }
                      Main.player[this.whoAmI].chest = int16_26;
                      return;
                    case 34:
                      if (Main.netMode != 2)
                        return;
                      int int32_18 = BitConverter.ToInt32(this.readBuffer, index1);
                      int int32_19 = BitConverter.ToInt32(this.readBuffer, index1 + 4);
                      if (Main.tile[int32_18, int32_19].type != (byte) 21)
                        return;
                      WorldGen.KillTile(int32_18, int32_19);
                      if (Main.tile[int32_18, int32_19].active)
                        return;
                      NetMessage.SendData(17, number2: ((float) int32_18), number3: ((float) int32_19));
                      return;
                    case 35:
                      int whoAmI11 = (int) this.readBuffer[index1];
                      if (Main.netMode == 2)
                        whoAmI11 = this.whoAmI;
                      int startIndex53 = index1 + 1;
                      int int16_27 = (int) BitConverter.ToInt16(this.readBuffer, startIndex53);
                      num1 = startIndex53 + 2;
                      if (whoAmI11 != Main.myPlayer)
                        Main.player[whoAmI11].HealEffect(int16_27);
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(35, ignoreClient: this.whoAmI, number: whoAmI11, number2: ((float) int16_27));
                      return;
                    case 36:
                      int whoAmI12 = (int) this.readBuffer[index1];
                      if (Main.netMode == 2)
                        whoAmI12 = this.whoAmI;
                      int index71 = index1 + 1;
                      int num42 = (int) this.readBuffer[index71];
                      int index72 = index71 + 1;
                      int num43 = (int) this.readBuffer[index72];
                      int index73 = index72 + 1;
                      int num44 = (int) this.readBuffer[index73];
                      int index74 = index73 + 1;
                      int num45 = (int) this.readBuffer[index74];
                      int index75 = index74 + 1;
                      int num46 = (int) this.readBuffer[index75];
                      num1 = index75 + 1;
                      Main.player[whoAmI12].zoneEvil = num42 != 0;
                      Main.player[whoAmI12].zoneMeteor = num43 != 0;
                      Main.player[whoAmI12].zoneDungeon = num44 != 0;
                      Main.player[whoAmI12].zoneJungle = num45 != 0;
                      Main.player[whoAmI12].zoneHoly = num46 != 0;
                      if (Main.netMode != 2)
                        return;
                      NetMessage.SendData(36, ignoreClient: this.whoAmI, number: whoAmI12);
                      return;
                    case 37:
                      if (Main.netMode != 1)
                        return;
                      if (Main.autoPass)
                      {
                        NetMessage.SendData(38, text: Netplay.password);
                        Main.autoPass = false;
                        return;
                      }
                      Netplay.password = "";
                      Main.menuMode = 31;
                      return;
                    case 38:
                      if (Main.netMode != 2)
                        return;
                      if (Encoding.UTF8.GetString(this.readBuffer, index1, length - index1 + start) == Netplay.password)
                      {
                        Netplay.serverSock[this.whoAmI].state = 1;
                        NetMessage.SendData(3, this.whoAmI);
                        return;
                      }
                      NetMessage.SendData(2, this.whoAmI, text: Lang.mp[1]);
                      return;
                    default:
                      if (num2 == (byte) 39 && Main.netMode == 1)
                      {
                        short int16_28 = BitConverter.ToInt16(this.readBuffer, index1);
                        Main.item[(int) int16_28].owner = (int) byte.MaxValue;
                        NetMessage.SendData(22, number: ((int) int16_28));
                        return;
                      }
                      switch (num2)
                      {
                        case 40:
                          byte whoAmI13 = this.readBuffer[index1];
                          if (Main.netMode == 2)
                            whoAmI13 = (byte) this.whoAmI;
                          int startIndex54 = index1 + 1;
                          int int16_29 = (int) BitConverter.ToInt16(this.readBuffer, startIndex54);
                          num1 = startIndex54 + 2;
                          Main.player[(int) whoAmI13].talkNPC = int16_29;
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(40, ignoreClient: this.whoAmI, number: ((int) whoAmI13));
                          return;
                        case 41:
                          byte whoAmI14 = this.readBuffer[index1];
                          if (Main.netMode == 2)
                            whoAmI14 = (byte) this.whoAmI;
                          int startIndex55 = index1 + 1;
                          float single19 = BitConverter.ToSingle(this.readBuffer, startIndex55);
                          int int16_30 = (int) BitConverter.ToInt16(this.readBuffer, startIndex55 + 4);
                          Main.player[(int) whoAmI14].itemRotation = single19;
                          Main.player[(int) whoAmI14].itemAnimation = int16_30;
                          Main.player[(int) whoAmI14].channel = Main.player[(int) whoAmI14].inventory[Main.player[(int) whoAmI14].selectedItem].channel;
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(41, ignoreClient: this.whoAmI, number: ((int) whoAmI14));
                          return;
                        case 42:
                          int whoAmI15 = (int) this.readBuffer[index1];
                          if (Main.netMode == 2)
                            whoAmI15 = this.whoAmI;
                          int startIndex56 = index1 + 1;
                          int int16_31 = (int) BitConverter.ToInt16(this.readBuffer, startIndex56);
                          int int16_32 = (int) BitConverter.ToInt16(this.readBuffer, startIndex56 + 2);
                          if (Main.netMode == 2)
                            whoAmI15 = this.whoAmI;
                          Main.player[whoAmI15].statMana = int16_31;
                          Main.player[whoAmI15].statManaMax = int16_32;
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(42, ignoreClient: this.whoAmI, number: whoAmI15);
                          return;
                        case 43:
                          int whoAmI16 = (int) this.readBuffer[index1];
                          if (Main.netMode == 2)
                            whoAmI16 = this.whoAmI;
                          int startIndex57 = index1 + 1;
                          int int16_33 = (int) BitConverter.ToInt16(this.readBuffer, startIndex57);
                          num1 = startIndex57 + 2;
                          if (whoAmI16 != Main.myPlayer)
                            Main.player[whoAmI16].ManaEffect(int16_33);
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(43, ignoreClient: this.whoAmI, number: whoAmI16, number2: ((float) int16_33));
                          return;
                        case 44:
                          byte whoAmI17 = this.readBuffer[index1];
                          if ((int) whoAmI17 == Main.myPlayer)
                            return;
                          if (Main.netMode == 2)
                            whoAmI17 = (byte) this.whoAmI;
                          int index76 = index1 + 1;
                          int hitDirection3 = (int) this.readBuffer[index76] - 1;
                          int startIndex58 = index76 + 1;
                          short int16_34 = BitConverter.ToInt16(this.readBuffer, startIndex58);
                          int index77 = startIndex58 + 2;
                          byte num47 = this.readBuffer[index77];
                          int index78 = index77 + 1;
                          string str5 = Encoding.UTF8.GetString(this.readBuffer, index78, length - index78 + start);
                          bool pvp2 = false;
                          if (num47 != (byte) 0)
                            pvp2 = true;
                          Main.player[(int) whoAmI17].KillMe((double) int16_34, hitDirection3, pvp2, str5);
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(44, ignoreClient: this.whoAmI, text: str5, number: ((int) whoAmI17), number2: ((float) hitDirection3), number3: ((float) int16_34), number4: ((float) num47));
                          return;
                        case 45:
                          int whoAmI18 = (int) this.readBuffer[index1];
                          if (Main.netMode == 2)
                            whoAmI18 = this.whoAmI;
                          int index79 = index1 + 1;
                          int index80 = (int) this.readBuffer[index79];
                          num1 = index79 + 1;
                          int team = Main.player[whoAmI18].team;
                          Main.player[whoAmI18].team = index80;
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(45, ignoreClient: this.whoAmI, number: whoAmI18);
                          string str6 = "";
                          switch (index80)
                          {
                            case 0:
                              str6 = " " + Lang.mp[13];
                              break;
                            case 1:
                              str6 = " " + Lang.mp[14];
                              break;
                            case 2:
                              str6 = " " + Lang.mp[15];
                              break;
                            case 3:
                              str6 = " " + Lang.mp[16];
                              break;
                            case 4:
                              str6 = " " + Lang.mp[17];
                              break;
                          }
                          for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
                          {
                            if (remoteClient == this.whoAmI || team > 0 && Main.player[remoteClient].team == team || index80 > 0 && Main.player[remoteClient].team == index80)
                              NetMessage.SendData(25, remoteClient, text: (Main.player[whoAmI18].name + str6), number: ((int) byte.MaxValue), number2: ((float) Main.teamColor[index80].R), number3: ((float) Main.teamColor[index80].G), number4: ((float) Main.teamColor[index80].B));
                          }
                          return;
                        case 46:
                          if (Main.netMode != 2)
                            return;
                          int int32_20 = BitConverter.ToInt32(this.readBuffer, index1);
                          int startIndex59 = index1 + 4;
                          int int32_21 = BitConverter.ToInt32(this.readBuffer, startIndex59);
                          num1 = startIndex59 + 4;
                          int number6 = Sign.ReadSign(int32_20, int32_21);
                          if (number6 < 0)
                            return;
                          NetMessage.SendData(47, this.whoAmI, number: number6);
                          return;
                        case 47:
                          int int16_35 = (int) BitConverter.ToInt16(this.readBuffer, index1);
                          int startIndex60 = index1 + 2;
                          int int32_22 = BitConverter.ToInt32(this.readBuffer, startIndex60);
                          int startIndex61 = startIndex60 + 4;
                          int int32_23 = BitConverter.ToInt32(this.readBuffer, startIndex61);
                          int index81 = startIndex61 + 4;
                          string text3 = Encoding.UTF8.GetString(this.readBuffer, index81, length - index81 + start);
                          Main.sign[int16_35] = new Sign();
                          Main.sign[int16_35].x = int32_22;
                          Main.sign[int16_35].y = int32_23;
                          Sign.TextSign(int16_35, text3);
                          if (Main.netMode != 1 || Main.sign[int16_35] == null || int16_35 == Main.player[Main.myPlayer].sign)
                            return;
                          Main.playerInventory = false;
                          Main.player[Main.myPlayer].talkNPC = -1;
                          Main.editSign = false;
                          Main.PlaySound(10);
                          Main.player[Main.myPlayer].sign = int16_35;
                          Main.npcChatText = Main.sign[int16_35].text;
                          return;
                        case 48:
                          int int32_24 = BitConverter.ToInt32(this.readBuffer, index1);
                          int startIndex62 = index1 + 4;
                          int int32_25 = BitConverter.ToInt32(this.readBuffer, startIndex62);
                          int index82 = startIndex62 + 4;
                          byte num48 = this.readBuffer[index82];
                          int index83 = index82 + 1;
                          byte num49 = this.readBuffer[index83];
                          num1 = index83 + 1;
                          if (Main.netMode == 2 && Netplay.spamCheck)
                          {
                            int whoAmI19 = this.whoAmI;
                            int num50 = (int) ((double) Main.player[whoAmI19].position.X + (double) (Main.player[whoAmI19].width / 2));
                            int num51 = (int) ((double) Main.player[whoAmI19].position.Y + (double) (Main.player[whoAmI19].height / 2));
                            int num52 = 10;
                            int num53 = num50 - num52;
                            int num54 = num50 + num52;
                            int num55 = num51 - num52;
                            int num56 = num51 + num52;
                            if (num50 < num53 || num50 > num54 || num51 < num55 || num51 > num56)
                            {
                              NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
                              return;
                            }
                          }
                          if (Main.tile[int32_24, int32_25] == null)
                            Main.tile[int32_24, int32_25] = new Tile();
                          lock (Main.tile[int32_24, int32_25])
                          {
                            Main.tile[int32_24, int32_25].liquid = num48;
                            Main.tile[int32_24, int32_25].lava = num49 == (byte) 1;
                            if (Main.netMode != 2)
                              return;
                            WorldGen.SquareTileFrame(int32_24, int32_25);
                            return;
                          }
                        case 49:
                          if (Netplay.clientSock.state != 6)
                            return;
                          Netplay.clientSock.state = 10;
                          Main.player[Main.myPlayer].Spawn();
                          return;
                        case 50:
                          int whoAmI20 = (int) this.readBuffer[index1];
                          int index84 = index1 + 1;
                          if (Main.netMode == 2)
                            whoAmI20 = this.whoAmI;
                          else if (whoAmI20 == Main.myPlayer)
                            return;
                          for (int index85 = 0; index85 < 10; ++index85)
                          {
                            Main.player[whoAmI20].buffType[index85] = (int) this.readBuffer[index84];
                            Main.player[whoAmI20].buffTime[index85] = Main.player[whoAmI20].buffType[index85] <= 0 ? 0 : 60;
                            ++index84;
                          }
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(50, ignoreClient: this.whoAmI, number: whoAmI20);
                          return;
                        case 51:
                          byte num57 = this.readBuffer[index1];
                          byte num58 = this.readBuffer[index1 + 1];
                          switch (num58)
                          {
                            case 1:
                              NPC.SpawnSkeletron();
                              return;
                            case 2:
                              if (Main.netMode == 2)
                              {
                                if (Main.netMode != 2)
                                  return;
                                NetMessage.SendData(51, ignoreClient: this.whoAmI, number: ((int) num57), number2: ((float) num58));
                                return;
                              }
                              Main.PlaySound(2, (int) Main.player[(int) num57].position.X, (int) Main.player[(int) num57].position.Y);
                              return;
                            default:
                              return;
                          }
                        case 52:
                          byte num59 = this.readBuffer[index1];
                          int index86 = index1 + 1;
                          byte num60 = this.readBuffer[index86];
                          int startIndex63 = index86 + 1;
                          int int32_26 = BitConverter.ToInt32(this.readBuffer, startIndex63);
                          int startIndex64 = startIndex63 + 4;
                          int int32_27 = BitConverter.ToInt32(this.readBuffer, startIndex64);
                          num1 = startIndex64 + 4;
                          if (num60 != (byte) 1)
                            return;
                          Chest.Unlock(int32_26, int32_27);
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(52, ignoreClient: this.whoAmI, number: ((int) num59), number2: ((float) num60), number3: ((float) int32_26), number4: ((float) int32_27));
                          NetMessage.SendTileSquare(-1, int32_26, int32_27, 2);
                          return;
                        case 53:
                          short int16_36 = BitConverter.ToInt16(this.readBuffer, index1);
                          int index87 = index1 + 2;
                          byte num61 = this.readBuffer[index87];
                          int startIndex65 = index87 + 1;
                          short int16_37 = BitConverter.ToInt16(this.readBuffer, startIndex65);
                          num1 = startIndex65 + 2;
                          Main.npc[(int) int16_36].AddBuff((int) num61, (int) int16_37, true);
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(54, number: ((int) int16_36));
                          return;
                        case 54:
                          if (Main.netMode != 1)
                            return;
                          short int16_38 = BitConverter.ToInt16(this.readBuffer, index1);
                          int index88 = index1 + 2;
                          for (int index89 = 0; index89 < 5; ++index89)
                          {
                            Main.npc[(int) int16_38].buffType[index89] = (int) this.readBuffer[index88];
                            int startIndex66 = index88 + 1;
                            Main.npc[(int) int16_38].buffTime[index89] = (int) BitConverter.ToInt16(this.readBuffer, startIndex66);
                            index88 = startIndex66 + 2;
                          }
                          return;
                        case 55:
                          byte num62 = this.readBuffer[index1];
                          int index90 = index1 + 1;
                          byte num63 = this.readBuffer[index90];
                          int startIndex67 = index90 + 1;
                          short int16_39 = BitConverter.ToInt16(this.readBuffer, startIndex67);
                          num1 = startIndex67 + 2;
                          if (Main.netMode == 2 && (int) num62 != this.whoAmI && !Main.pvpBuff[(int) num63])
                            return;
                          if (Main.netMode == 1 && (int) num62 == Main.myPlayer)
                          {
                            Main.player[(int) num62].AddBuff((int) num63, (int) int16_39);
                            return;
                          }
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(55, (int) num62, number: ((int) num62), number2: ((float) num63), number3: ((float) int16_39));
                          return;
                        case 56:
                          if (Main.netMode != 1)
                            return;
                          short int16_40 = BitConverter.ToInt16(this.readBuffer, index1);
                          int index91 = index1 + 2;
                          string str7 = Encoding.UTF8.GetString(this.readBuffer, index91, length - index91 + start);
                          Main.chrName[(int) int16_40] = str7;
                          return;
                        case 57:
                          if (Main.netMode != 1)
                            return;
                          WorldGen.tGood = this.readBuffer[index1];
                          WorldGen.tEvil = this.readBuffer[index1 + 1];
                          return;
                        case 58:
                          byte whoAmI21 = this.readBuffer[index1];
                          if (Main.netMode == 2)
                            whoAmI21 = (byte) this.whoAmI;
                          int startIndex68 = index1 + 1;
                          float single20 = BitConverter.ToSingle(this.readBuffer, startIndex68);
                          num1 = startIndex68 + 4;
                          if (Main.netMode == 2)
                          {
                            NetMessage.SendData(58, ignoreClient: this.whoAmI, number: this.whoAmI, number2: single20);
                            return;
                          }
                          Main.harpNote = single20;
                          int Style = 26;
                          if (Main.player[(int) whoAmI21].inventory[Main.player[(int) whoAmI21].selectedItem].type == 507)
                            Style = 35;
                          Main.PlaySound(2, (int) Main.player[(int) whoAmI21].position.X, (int) Main.player[(int) whoAmI21].position.Y, Style);
                          return;
                        case 59:
                          int int32_28 = BitConverter.ToInt32(this.readBuffer, index1);
                          int startIndex69 = index1 + 4;
                          int int32_29 = BitConverter.ToInt32(this.readBuffer, startIndex69);
                          num1 = startIndex69 + 4;
                          WorldGen.hitSwitch(int32_28, int32_29);
                          if (Main.netMode != 2)
                            return;
                          NetMessage.SendData(59, ignoreClient: this.whoAmI, number: int32_28, number2: ((float) int32_29));
                          return;
                        case 60:
                          short int16_41 = BitConverter.ToInt16(this.readBuffer, index1);
                          int startIndex70 = index1 + 2;
                          short int16_42 = BitConverter.ToInt16(this.readBuffer, startIndex70);
                          int startIndex71 = startIndex70 + 2;
                          short int16_43 = BitConverter.ToInt16(this.readBuffer, startIndex71);
                          int index92 = startIndex71 + 2;
                          byte num64 = this.readBuffer[index92];
                          num1 = index92 + 1;
                          bool flag5 = false;
                          if (num64 == (byte) 1)
                            flag5 = true;
                          if (Main.netMode == 1)
                          {
                            Main.npc[(int) int16_41].homeless = flag5;
                            Main.npc[(int) int16_41].homeTileX = (int) int16_42;
                            Main.npc[(int) int16_41].homeTileY = (int) int16_43;
                            return;
                          }
                          if (num64 == (byte) 0)
                          {
                            WorldGen.kickOut((int) int16_41);
                            return;
                          }
                          WorldGen.moveRoom((int) int16_42, (int) int16_43, (int) int16_41);
                          return;
                        case 61:
                          int int32_30 = BitConverter.ToInt32(this.readBuffer, index1);
                          int startIndex72 = index1 + 4;
                          int int32_31 = BitConverter.ToInt32(this.readBuffer, startIndex72);
                          num1 = startIndex72 + 4;
                          if (Main.netMode != 2)
                            return;
                          if (int32_31 == 4 || int32_31 == 13 || int32_31 == 50 || int32_31 == 125 || int32_31 == 126 || int32_31 == 134 || int32_31 == (int) sbyte.MaxValue || int32_31 == 128)
                          {
                            bool flag6 = true;
                            for (int index93 = 0; index93 < 200; ++index93)
                            {
                              if (Main.npc[index93].active && Main.npc[index93].type == int32_31)
                                flag6 = false;
                            }
                            if (!flag6)
                              return;
                            NPC.SpawnOnPlayer(int32_30, int32_31);
                            return;
                          }
                          if (int32_31 >= 0)
                            return;
                          int type1 = -1;
                          if (int32_31 == -1)
                            type1 = 1;
                          if (int32_31 == -2)
                            type1 = 2;
                          if (type1 <= 0 || Main.invasionType != 0)
                            return;
                          Main.invasionDelay = 0;
                          Main.StartInvasion(type1);
                          return;
                        default:
                          return;
                      }
                  }
              }
          }
        }
      }
    }
  }
}
