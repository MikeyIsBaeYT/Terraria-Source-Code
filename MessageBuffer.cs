// Decompiled with JetBrains decompiler
// Type: Terraria.MessageBuffer
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI;

namespace Terraria
{
  public class MessageBuffer
  {
    public const int readBufferMax = 131070;
    public const int writeBufferMax = 131070;
    public bool broadcast;
    public byte[] readBuffer = new byte[131070];
    public byte[] writeBuffer = new byte[131070];
    public bool writeLocked;
    public int messageLength;
    public int totalData;
    public int whoAmI;
    public int spamCount;
    public int maxSpam;
    public bool checkBytes;
    public MemoryStream readerStream;
    public MemoryStream writerStream;
    public BinaryReader reader;
    public BinaryWriter writer;

    public static event TileChangeReceivedEvent OnTileChangeReceived;

    public void Reset()
    {
      Array.Clear((Array) this.readBuffer, 0, this.readBuffer.Length);
      Array.Clear((Array) this.writeBuffer, 0, this.writeBuffer.Length);
      this.writeLocked = false;
      this.messageLength = 0;
      this.totalData = 0;
      this.spamCount = 0;
      this.broadcast = false;
      this.checkBytes = false;
      this.ResetReader();
      this.ResetWriter();
    }

    public void ResetReader()
    {
      if (this.readerStream != null)
        this.readerStream.Close();
      this.readerStream = new MemoryStream(this.readBuffer);
      this.reader = new BinaryReader((Stream) this.readerStream);
    }

    public void ResetWriter()
    {
      if (this.writerStream != null)
        this.writerStream.Close();
      this.writerStream = new MemoryStream(this.writeBuffer);
      this.writer = new BinaryWriter((Stream) this.writerStream);
    }

    public void GetData(int start, int length, out int messageType)
    {
      if (this.whoAmI < 256)
        Netplay.Clients[this.whoAmI].TimeOutTimer = 0;
      else
        Netplay.Connection.TimeOutTimer = 0;
      int bufferStart = start + 1;
      byte num1 = this.readBuffer[start];
      messageType = (int) num1;
      if (num1 >= (byte) 120)
        return;
      ++Main.rxMsg;
      Main.rxData += length;
      ++Main.rxMsgType[(int) num1];
      Main.rxDataType[(int) num1] += length;
      if (Main.netMode == 1 && Netplay.Connection.StatusMax > 0)
        ++Netplay.Connection.StatusCount;
      if (Main.verboseNetplay)
      {
        int num2 = start;
        while (num2 < start + length)
          ++num2;
        for (int index = start; index < start + length; ++index)
        {
          int num3 = (int) this.readBuffer[index];
        }
      }
      if (Main.netMode == 2 && num1 != (byte) 38 && Netplay.Clients[this.whoAmI].State == -1)
      {
        NetMessage.SendData(2, this.whoAmI, text: Lang.mp[1].ToNetworkText());
      }
      else
      {
        if (Main.netMode == 2 && Netplay.Clients[this.whoAmI].State < 10 && num1 > (byte) 12 && num1 != (byte) 93 && num1 != (byte) 16 && num1 != (byte) 42 && num1 != (byte) 50 && num1 != (byte) 38 && num1 != (byte) 68)
          NetMessage.BootPlayer(this.whoAmI, Lang.mp[2].ToNetworkText());
        if (this.reader == null)
          this.ResetReader();
        this.reader.BaseStream.Position = (long) bufferStart;
        switch (num1)
        {
          case 1:
            if (Main.netMode != 2)
              break;
            if (Main.dedServ && Netplay.IsBanned(Netplay.Clients[this.whoAmI].Socket.GetRemoteAddress()))
            {
              NetMessage.SendData(2, this.whoAmI, text: Lang.mp[3].ToNetworkText());
              break;
            }
            if (Netplay.Clients[this.whoAmI].State != 0)
              break;
            if (this.reader.ReadString() == "Terraria" + (object) 194)
            {
              if (string.IsNullOrEmpty(Netplay.ServerPassword))
              {
                Netplay.Clients[this.whoAmI].State = 1;
                NetMessage.SendData(3, this.whoAmI);
                break;
              }
              Netplay.Clients[this.whoAmI].State = -1;
              NetMessage.SendData(37, this.whoAmI);
              break;
            }
            NetMessage.SendData(2, this.whoAmI, text: Lang.mp[4].ToNetworkText());
            break;
          case 2:
            if (Main.netMode != 1)
              break;
            Netplay.disconnect = true;
            Main.statusText = NetworkText.Deserialize(this.reader).ToString();
            break;
          case 3:
            if (Main.netMode != 1)
              break;
            if (Netplay.Connection.State == 1)
              Netplay.Connection.State = 2;
            int number1 = (int) this.reader.ReadByte();
            if (number1 != Main.myPlayer)
            {
              Main.player[number1] = Main.ActivePlayerFileData.Player;
              Main.player[Main.myPlayer] = new Player();
            }
            Main.player[number1].whoAmI = number1;
            Main.myPlayer = number1;
            Player player1 = Main.player[number1];
            NetMessage.SendData(4, number: number1);
            NetMessage.SendData(68, number: number1);
            NetMessage.SendData(16, number: number1);
            NetMessage.SendData(42, number: number1);
            NetMessage.SendData(50, number: number1);
            for (int index = 0; index < 59; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) index), number3: ((float) player1.inventory[index].prefix));
            for (int index = 0; index < player1.armor.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (59 + index)), number3: ((float) player1.armor[index].prefix));
            for (int index = 0; index < player1.dye.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + 1 + index)), number3: ((float) player1.dye[index].prefix));
            for (int index = 0; index < player1.miscEquips.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + player1.dye.Length + 1 + index)), number3: ((float) player1.miscEquips[index].prefix));
            for (int index = 0; index < player1.miscDyes.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + player1.dye.Length + player1.miscEquips.Length + 1 + index)), number3: ((float) player1.miscDyes[index].prefix));
            for (int index = 0; index < player1.bank.item.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + player1.dye.Length + player1.miscEquips.Length + player1.miscDyes.Length + 1 + index)), number3: ((float) player1.bank.item[index].prefix));
            for (int index = 0; index < player1.bank2.item.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + player1.dye.Length + player1.miscEquips.Length + player1.miscDyes.Length + player1.bank.item.Length + 1 + index)), number3: ((float) player1.bank2.item[index].prefix));
            NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + player1.dye.Length + player1.miscEquips.Length + player1.miscDyes.Length + player1.bank.item.Length + player1.bank2.item.Length + 1)), number3: ((float) player1.trashItem.prefix));
            for (int index = 0; index < player1.bank3.item.Length; ++index)
              NetMessage.SendData(5, number: number1, number2: ((float) (58 + player1.armor.Length + player1.dye.Length + player1.miscEquips.Length + player1.miscDyes.Length + player1.bank.item.Length + player1.bank2.item.Length + 2 + index)), number3: ((float) player1.bank3.item[index].prefix));
            NetMessage.SendData(6);
            if (Netplay.Connection.State != 2)
              break;
            Netplay.Connection.State = 3;
            break;
          case 4:
            int number2 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number2 = this.whoAmI;
            if (number2 == Main.myPlayer && !Main.ServerSideCharacter)
              break;
            Player player2 = Main.player[number2];
            player2.whoAmI = number2;
            player2.skinVariant = (int) this.reader.ReadByte();
            player2.skinVariant = (int) MathHelper.Clamp((float) player2.skinVariant, 0.0f, 9f);
            player2.hair = (int) this.reader.ReadByte();
            if (player2.hair >= 134)
              player2.hair = 0;
            player2.name = this.reader.ReadString().Trim().Trim();
            player2.hairDye = this.reader.ReadByte();
            BitsByte bitsByte1 = (BitsByte) this.reader.ReadByte();
            for (int key = 0; key < 8; ++key)
              player2.hideVisual[key] = bitsByte1[key];
            bitsByte1 = (BitsByte) this.reader.ReadByte();
            for (int key = 0; key < 2; ++key)
              player2.hideVisual[key + 8] = bitsByte1[key];
            player2.hideMisc = (BitsByte) this.reader.ReadByte();
            player2.hairColor = this.reader.ReadRGB();
            player2.skinColor = this.reader.ReadRGB();
            player2.eyeColor = this.reader.ReadRGB();
            player2.shirtColor = this.reader.ReadRGB();
            player2.underShirtColor = this.reader.ReadRGB();
            player2.pantsColor = this.reader.ReadRGB();
            player2.shoeColor = this.reader.ReadRGB();
            BitsByte bitsByte2 = (BitsByte) this.reader.ReadByte();
            player2.difficulty = (byte) 0;
            if (bitsByte2[0])
              ++player2.difficulty;
            if (bitsByte2[1])
              player2.difficulty += (byte) 2;
            if (player2.difficulty > (byte) 2)
              player2.difficulty = (byte) 2;
            player2.extraAccessory = bitsByte2[2];
            if (Main.netMode != 2)
              break;
            bool flag1 = false;
            if (Netplay.Clients[this.whoAmI].State < 10)
            {
              for (int index = 0; index < (int) byte.MaxValue; ++index)
              {
                if (index != number2 && player2.name == Main.player[index].name && Netplay.Clients[index].IsActive)
                  flag1 = true;
              }
            }
            if (flag1)
            {
              NetMessage.SendData(2, this.whoAmI, text: NetworkText.FromFormattable("{0} {1}", (object) player2.name, (object) Lang.mp[5].ToNetworkText()));
              break;
            }
            if (player2.name.Length > Player.nameLen)
            {
              NetMessage.SendData(2, this.whoAmI, text: NetworkText.FromKey("Net.NameTooLong"));
              break;
            }
            if (player2.name == "")
            {
              NetMessage.SendData(2, this.whoAmI, text: NetworkText.FromKey("Net.EmptyName"));
              break;
            }
            Netplay.Clients[this.whoAmI].Name = player2.name;
            Netplay.Clients[this.whoAmI].Name = player2.name;
            NetMessage.SendData(4, ignoreClient: this.whoAmI, number: number2);
            break;
          case 5:
            int number3 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number3 = this.whoAmI;
            if (number3 == Main.myPlayer && !Main.ServerSideCharacter && !Main.player[number3].IsStackingItems())
              break;
            Player player3 = Main.player[number3];
            lock (player3)
            {
              int index1 = (int) this.reader.ReadByte();
              int num4 = (int) this.reader.ReadInt16();
              int pre = (int) this.reader.ReadByte();
              int type1 = (int) this.reader.ReadInt16();
              Item[] objArray = (Item[]) null;
              int index2 = 0;
              bool flag2 = false;
              if (index1 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length + player3.bank2.item.Length + 1)
              {
                index2 = index1 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length + player3.bank2.item.Length + 1) - 1;
                objArray = player3.bank3.item;
              }
              else if (index1 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length + player3.bank2.item.Length)
                flag2 = true;
              else if (index1 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length)
              {
                index2 = index1 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length) - 1;
                objArray = player3.bank2.item;
              }
              else if (index1 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length)
              {
                index2 = index1 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length) - 1;
                objArray = player3.bank.item;
              }
              else if (index1 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length)
              {
                index2 = index1 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length) - 1;
                objArray = player3.miscDyes;
              }
              else if (index1 > 58 + player3.armor.Length + player3.dye.Length)
              {
                index2 = index1 - 58 - (player3.armor.Length + player3.dye.Length) - 1;
                objArray = player3.miscEquips;
              }
              else if (index1 > 58 + player3.armor.Length)
              {
                index2 = index1 - 58 - player3.armor.Length - 1;
                objArray = player3.dye;
              }
              else if (index1 > 58)
              {
                index2 = index1 - 58 - 1;
                objArray = player3.armor;
              }
              else
              {
                index2 = index1;
                objArray = player3.inventory;
              }
              if (flag2)
              {
                player3.trashItem = new Item();
                player3.trashItem.netDefaults(type1);
                player3.trashItem.stack = num4;
                player3.trashItem.Prefix(pre);
              }
              else if (index1 <= 58)
              {
                int type2 = objArray[index2].type;
                int stack = objArray[index2].stack;
                objArray[index2] = new Item();
                objArray[index2].netDefaults(type1);
                objArray[index2].stack = num4;
                objArray[index2].Prefix(pre);
                if (number3 == Main.myPlayer && index2 == 58)
                  Main.mouseItem = objArray[index2].Clone();
                if (number3 == Main.myPlayer && Main.netMode == 1)
                {
                  Main.player[number3].inventoryChestStack[index1] = false;
                  if (objArray[index2].stack != stack || objArray[index2].type != type2)
                  {
                    Recipe.FindRecipes();
                    Main.PlaySound(7);
                  }
                }
              }
              else
              {
                objArray[index2] = new Item();
                objArray[index2].netDefaults(type1);
                objArray[index2].stack = num4;
                objArray[index2].Prefix(pre);
              }
              if (Main.netMode != 2 || number3 != this.whoAmI || index1 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length)
                break;
              NetMessage.SendData(5, ignoreClient: this.whoAmI, number: number3, number2: ((float) index1), number3: ((float) pre));
              break;
            }
          case 6:
            if (Main.netMode != 2)
              break;
            if (Netplay.Clients[this.whoAmI].State == 1)
              Netplay.Clients[this.whoAmI].State = 2;
            NetMessage.SendData(7, this.whoAmI);
            Main.SyncAnInvasion(this.whoAmI);
            break;
          case 7:
            if (Main.netMode != 1)
              break;
            Main.time = (double) this.reader.ReadInt32();
            BitsByte bitsByte3 = (BitsByte) this.reader.ReadByte();
            Main.dayTime = bitsByte3[0];
            Main.bloodMoon = bitsByte3[1];
            Main.eclipse = bitsByte3[2];
            Main.moonPhase = (int) this.reader.ReadByte();
            Main.maxTilesX = (int) this.reader.ReadInt16();
            Main.maxTilesY = (int) this.reader.ReadInt16();
            Main.spawnTileX = (int) this.reader.ReadInt16();
            Main.spawnTileY = (int) this.reader.ReadInt16();
            Main.worldSurface = (double) this.reader.ReadInt16();
            Main.rockLayer = (double) this.reader.ReadInt16();
            Main.worldID = this.reader.ReadInt32();
            Main.worldName = this.reader.ReadString();
            Main.ActiveWorldFileData.UniqueId = new Guid(this.reader.ReadBytes(16));
            Main.ActiveWorldFileData.WorldGeneratorVersion = this.reader.ReadUInt64();
            Main.moonType = (int) this.reader.ReadByte();
            WorldGen.setBG(0, (int) this.reader.ReadByte());
            WorldGen.setBG(1, (int) this.reader.ReadByte());
            WorldGen.setBG(2, (int) this.reader.ReadByte());
            WorldGen.setBG(3, (int) this.reader.ReadByte());
            WorldGen.setBG(4, (int) this.reader.ReadByte());
            WorldGen.setBG(5, (int) this.reader.ReadByte());
            WorldGen.setBG(6, (int) this.reader.ReadByte());
            WorldGen.setBG(7, (int) this.reader.ReadByte());
            Main.iceBackStyle = (int) this.reader.ReadByte();
            Main.jungleBackStyle = (int) this.reader.ReadByte();
            Main.hellBackStyle = (int) this.reader.ReadByte();
            Main.windSpeedSet = this.reader.ReadSingle();
            Main.numClouds = (int) this.reader.ReadByte();
            for (int index = 0; index < 3; ++index)
              Main.treeX[index] = this.reader.ReadInt32();
            for (int index = 0; index < 4; ++index)
              Main.treeStyle[index] = (int) this.reader.ReadByte();
            for (int index = 0; index < 3; ++index)
              Main.caveBackX[index] = this.reader.ReadInt32();
            for (int index = 0; index < 4; ++index)
              Main.caveBackStyle[index] = (int) this.reader.ReadByte();
            Main.maxRaining = this.reader.ReadSingle();
            Main.raining = (double) Main.maxRaining > 0.0;
            BitsByte bitsByte4 = (BitsByte) this.reader.ReadByte();
            WorldGen.shadowOrbSmashed = bitsByte4[0];
            NPC.downedBoss1 = bitsByte4[1];
            NPC.downedBoss2 = bitsByte4[2];
            NPC.downedBoss3 = bitsByte4[3];
            Main.hardMode = bitsByte4[4];
            NPC.downedClown = bitsByte4[5];
            Main.ServerSideCharacter = bitsByte4[6];
            NPC.downedPlantBoss = bitsByte4[7];
            BitsByte bitsByte5 = (BitsByte) this.reader.ReadByte();
            NPC.downedMechBoss1 = bitsByte5[0];
            NPC.downedMechBoss2 = bitsByte5[1];
            NPC.downedMechBoss3 = bitsByte5[2];
            NPC.downedMechBossAny = bitsByte5[3];
            Main.cloudBGActive = bitsByte5[4] ? 1f : 0.0f;
            WorldGen.crimson = bitsByte5[5];
            Main.pumpkinMoon = bitsByte5[6];
            Main.snowMoon = bitsByte5[7];
            BitsByte bitsByte6 = (BitsByte) this.reader.ReadByte();
            Main.expertMode = bitsByte6[0];
            Main.fastForwardTime = bitsByte6[1];
            Main.UpdateSundial();
            int num5 = bitsByte6[2] ? 1 : 0;
            NPC.downedSlimeKing = bitsByte6[3];
            NPC.downedQueenBee = bitsByte6[4];
            NPC.downedFishron = bitsByte6[5];
            NPC.downedMartians = bitsByte6[6];
            NPC.downedAncientCultist = bitsByte6[7];
            BitsByte bitsByte7 = (BitsByte) this.reader.ReadByte();
            NPC.downedMoonlord = bitsByte7[0];
            NPC.downedHalloweenKing = bitsByte7[1];
            NPC.downedHalloweenTree = bitsByte7[2];
            NPC.downedChristmasIceQueen = bitsByte7[3];
            NPC.downedChristmasSantank = bitsByte7[4];
            NPC.downedChristmasTree = bitsByte7[5];
            NPC.downedGolemBoss = bitsByte7[6];
            BirthdayParty.ManualParty = bitsByte7[7];
            BitsByte bitsByte8 = (BitsByte) this.reader.ReadByte();
            NPC.downedPirates = bitsByte8[0];
            NPC.downedFrost = bitsByte8[1];
            NPC.downedGoblins = bitsByte8[2];
            Sandstorm.Happening = bitsByte8[3];
            DD2Event.Ongoing = bitsByte8[4];
            DD2Event.DownedInvasionT1 = bitsByte8[5];
            DD2Event.DownedInvasionT2 = bitsByte8[6];
            DD2Event.DownedInvasionT3 = bitsByte8[7];
            if (num5 != 0)
              Main.StartSlimeRain();
            else
              Main.StopSlimeRain();
            Main.invasionType = (int) this.reader.ReadSByte();
            Main.LobbyId = this.reader.ReadUInt64();
            Sandstorm.IntendedSeverity = this.reader.ReadSingle();
            if (Netplay.Connection.State != 3)
              break;
            Netplay.Connection.State = 4;
            break;
          case 8:
            if (Main.netMode != 2)
              break;
            int num6 = this.reader.ReadInt32();
            int y1 = this.reader.ReadInt32();
            bool flag3 = true;
            if (num6 == -1 || y1 == -1)
              flag3 = false;
            else if (num6 < 10 || num6 > Main.maxTilesX - 10)
              flag3 = false;
            else if (y1 < 10 || y1 > Main.maxTilesY - 10)
              flag3 = false;
            int number4 = Netplay.GetSectionX(Main.spawnTileX) - 2;
            int num7 = Netplay.GetSectionY(Main.spawnTileY) - 1;
            int num8 = number4 + 5;
            int num9 = num7 + 3;
            if (number4 < 0)
              number4 = 0;
            if (num8 >= Main.maxSectionsX)
              num8 = Main.maxSectionsX - 1;
            if (num7 < 0)
              num7 = 0;
            if (num9 >= Main.maxSectionsY)
              num9 = Main.maxSectionsY - 1;
            int num10 = (num8 - number4) * (num9 - num7);
            List<Point> dontInclude = new List<Point>();
            for (int x = number4; x < num8; ++x)
            {
              for (int y2 = num7; y2 < num9; ++y2)
                dontInclude.Add(new Point(x, y2));
            }
            int num11 = -1;
            int num12 = -1;
            if (flag3)
            {
              num6 = Netplay.GetSectionX(num6) - 2;
              y1 = Netplay.GetSectionY(y1) - 1;
              num11 = num6 + 5;
              num12 = y1 + 3;
              if (num6 < 0)
                num6 = 0;
              if (num11 >= Main.maxSectionsX)
                num11 = Main.maxSectionsX - 1;
              if (y1 < 0)
                y1 = 0;
              if (num12 >= Main.maxSectionsY)
                num12 = Main.maxSectionsY - 1;
              for (int x = num6; x < num11; ++x)
              {
                for (int y3 = y1; y3 < num12; ++y3)
                {
                  if (x < number4 || x >= num8 || y3 < num7 || y3 >= num9)
                  {
                    dontInclude.Add(new Point(x, y3));
                    ++num10;
                  }
                }
              }
            }
            int num13 = 1;
            List<Point> portals;
            List<Point> portalCenters;
            PortalHelper.SyncPortalsOnPlayerJoin(this.whoAmI, 1, dontInclude, out portals, out portalCenters);
            int number5 = num10 + portals.Count;
            if (Netplay.Clients[this.whoAmI].State == 2)
              Netplay.Clients[this.whoAmI].State = 3;
            NetMessage.SendData(9, this.whoAmI, text: Lang.inter[44].ToNetworkText(), number: number5);
            Netplay.Clients[this.whoAmI].StatusText2 = Language.GetTextValue("Net.IsReceivingTileData");
            Netplay.Clients[this.whoAmI].StatusMax += number5;
            for (int sectionX = number4; sectionX < num8; ++sectionX)
            {
              for (int sectionY = num7; sectionY < num9; ++sectionY)
                NetMessage.SendSection(this.whoAmI, sectionX, sectionY);
            }
            NetMessage.SendData(11, this.whoAmI, number: number4, number2: ((float) num7), number3: ((float) (num8 - 1)), number4: ((float) (num9 - 1)));
            if (flag3)
            {
              for (int sectionX = num6; sectionX < num11; ++sectionX)
              {
                for (int sectionY = y1; sectionY < num12; ++sectionY)
                  NetMessage.SendSection(this.whoAmI, sectionX, sectionY, true);
              }
              NetMessage.SendData(11, this.whoAmI, number: num6, number2: ((float) y1), number3: ((float) (num11 - 1)), number4: ((float) (num12 - 1)));
            }
            for (int index = 0; index < portals.Count; ++index)
              NetMessage.SendSection(this.whoAmI, portals[index].X, portals[index].Y, true);
            for (int index = 0; index < portalCenters.Count; ++index)
              NetMessage.SendData(11, this.whoAmI, number: (portalCenters[index].X - num13), number2: ((float) (portalCenters[index].Y - num13)), number3: ((float) (portalCenters[index].X + num13 + 1)), number4: ((float) (portalCenters[index].Y + num13 + 1)));
            for (int number6 = 0; number6 < 400; ++number6)
            {
              if (Main.item[number6].active)
              {
                NetMessage.SendData(21, this.whoAmI, number: number6);
                NetMessage.SendData(22, this.whoAmI, number: number6);
              }
            }
            for (int number7 = 0; number7 < 200; ++number7)
            {
              if (Main.npc[number7].active)
                NetMessage.SendData(23, this.whoAmI, number: number7);
            }
            for (int number8 = 0; number8 < 1000; ++number8)
            {
              if (Main.projectile[number8].active && (Main.projPet[Main.projectile[number8].type] || Main.projectile[number8].netImportant))
                NetMessage.SendData(27, this.whoAmI, number: number8);
            }
            for (int number9 = 0; number9 < 267; ++number9)
              NetMessage.SendData(83, this.whoAmI, number: number9);
            NetMessage.SendData(49, this.whoAmI);
            NetMessage.SendData(57, this.whoAmI);
            NetMessage.SendData(7, this.whoAmI);
            NetMessage.SendData(103, number: NPC.MoonLordCountdown);
            NetMessage.SendData(101, this.whoAmI);
            break;
          case 9:
            if (Main.netMode != 1)
              break;
            Netplay.Connection.StatusMax += this.reader.ReadInt32();
            Netplay.Connection.StatusText = NetworkText.Deserialize(this.reader).ToString();
            break;
          case 10:
            if (Main.netMode != 1)
              break;
            NetMessage.DecompressTileBlock(this.readBuffer, bufferStart, length);
            break;
          case 11:
            if (Main.netMode != 1)
              break;
            WorldGen.SectionTileFrame((int) this.reader.ReadInt16(), (int) this.reader.ReadInt16(), (int) this.reader.ReadInt16(), (int) this.reader.ReadInt16());
            break;
          case 12:
            int index3 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              index3 = this.whoAmI;
            Player player4 = Main.player[index3];
            player4.SpawnX = (int) this.reader.ReadInt16();
            player4.SpawnY = (int) this.reader.ReadInt16();
            player4.Spawn();
            if (index3 == Main.myPlayer && Main.netMode != 2)
            {
              Main.ActivePlayerFileData.StartPlayTimer();
              Player.Hooks.EnterWorld(Main.myPlayer);
            }
            if (Main.netMode != 2 || Netplay.Clients[this.whoAmI].State < 3)
              break;
            if (Netplay.Clients[this.whoAmI].State == 3)
            {
              Netplay.Clients[this.whoAmI].State = 10;
              NetMessage.greetPlayer(this.whoAmI);
              NetMessage.buffer[this.whoAmI].broadcast = true;
              NetMessage.SyncConnectedPlayer(this.whoAmI);
              NetMessage.SendData(12, ignoreClient: this.whoAmI, number: this.whoAmI);
              NetMessage.SendData(74, this.whoAmI, text: NetworkText.FromLiteral(Main.player[this.whoAmI].name), number: Main.anglerQuest);
              break;
            }
            NetMessage.SendData(12, ignoreClient: this.whoAmI, number: this.whoAmI);
            break;
          case 13:
            int number10 = (int) this.reader.ReadByte();
            if (number10 == Main.myPlayer && !Main.ServerSideCharacter)
              break;
            if (Main.netMode == 2)
              number10 = this.whoAmI;
            Player player5 = Main.player[number10];
            BitsByte bitsByte9 = (BitsByte) this.reader.ReadByte();
            player5.controlUp = bitsByte9[0];
            player5.controlDown = bitsByte9[1];
            player5.controlLeft = bitsByte9[2];
            player5.controlRight = bitsByte9[3];
            player5.controlJump = bitsByte9[4];
            player5.controlUseItem = bitsByte9[5];
            player5.direction = bitsByte9[6] ? 1 : -1;
            BitsByte bitsByte10 = (BitsByte) this.reader.ReadByte();
            if (bitsByte10[0])
            {
              player5.pulley = true;
              player5.pulleyDir = bitsByte10[1] ? (byte) 2 : (byte) 1;
            }
            else
              player5.pulley = false;
            player5.selectedItem = (int) this.reader.ReadByte();
            player5.position = this.reader.ReadVector2();
            if (bitsByte10[2])
              player5.velocity = this.reader.ReadVector2();
            else
              player5.velocity = Vector2.Zero;
            player5.vortexStealthActive = bitsByte10[3];
            player5.gravDir = bitsByte10[4] ? 1f : -1f;
            if (Main.netMode != 2 || Netplay.Clients[this.whoAmI].State != 10)
              break;
            NetMessage.SendData(13, ignoreClient: this.whoAmI, number: number10);
            break;
          case 14:
            int playerIndex = (int) this.reader.ReadByte();
            int num14 = (int) this.reader.ReadByte();
            if (Main.netMode != 1)
              break;
            int num15 = Main.player[playerIndex].active ? 1 : 0;
            if (num14 == 1)
            {
              if (!Main.player[playerIndex].active)
                Main.player[playerIndex] = new Player();
              Main.player[playerIndex].active = true;
            }
            else
              Main.player[playerIndex].active = false;
            int num16 = Main.player[playerIndex].active ? 1 : 0;
            if (num15 == num16)
              break;
            if (Main.player[playerIndex].active)
            {
              Player.Hooks.PlayerConnect(playerIndex);
              break;
            }
            Player.Hooks.PlayerDisconnect(playerIndex);
            break;
          case 16:
            int number11 = (int) this.reader.ReadByte();
            if (number11 == Main.myPlayer && !Main.ServerSideCharacter)
              break;
            if (Main.netMode == 2)
              number11 = this.whoAmI;
            Player player6 = Main.player[number11];
            player6.statLife = (int) this.reader.ReadInt16();
            player6.statLifeMax = (int) this.reader.ReadInt16();
            if (player6.statLifeMax < 100)
              player6.statLifeMax = 100;
            player6.dead = player6.statLife <= 0;
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(16, ignoreClient: this.whoAmI, number: number11);
            break;
          case 17:
            byte num17 = this.reader.ReadByte();
            int index4 = (int) this.reader.ReadInt16();
            int index5 = (int) this.reader.ReadInt16();
            short num18 = this.reader.ReadInt16();
            int num19 = (int) this.reader.ReadByte();
            bool fail = num18 == (short) 1;
            if (!WorldGen.InWorld(index4, index5, 3))
              break;
            if (Main.tile[index4, index5] == null)
              Main.tile[index4, index5] = new Tile();
            if (Main.netMode == 2)
            {
              if (!fail)
              {
                if (num17 == (byte) 0 || num17 == (byte) 2 || num17 == (byte) 4)
                  ++Netplay.Clients[this.whoAmI].SpamDeleteBlock;
                if (num17 == (byte) 1 || num17 == (byte) 3)
                  ++Netplay.Clients[this.whoAmI].SpamAddBlock;
              }
              if (!Netplay.Clients[this.whoAmI].TileSections[Netplay.GetSectionX(index4), Netplay.GetSectionY(index5)])
                fail = true;
            }
            if (num17 == (byte) 0)
              WorldGen.KillTile(index4, index5, fail);
            if (num17 == (byte) 1)
              WorldGen.PlaceTile(index4, index5, (int) num18, forced: true, style: num19);
            if (num17 == (byte) 2)
              WorldGen.KillWall(index4, index5, fail);
            if (num17 == (byte) 3)
              WorldGen.PlaceWall(index4, index5, (int) num18);
            if (num17 == (byte) 4)
              WorldGen.KillTile(index4, index5, fail, noItem: true);
            if (num17 == (byte) 5)
              WorldGen.PlaceWire(index4, index5);
            if (num17 == (byte) 6)
              WorldGen.KillWire(index4, index5);
            if (num17 == (byte) 7)
              WorldGen.PoundTile(index4, index5);
            if (num17 == (byte) 8)
              WorldGen.PlaceActuator(index4, index5);
            if (num17 == (byte) 9)
              WorldGen.KillActuator(index4, index5);
            if (num17 == (byte) 10)
              WorldGen.PlaceWire2(index4, index5);
            if (num17 == (byte) 11)
              WorldGen.KillWire2(index4, index5);
            if (num17 == (byte) 12)
              WorldGen.PlaceWire3(index4, index5);
            if (num17 == (byte) 13)
              WorldGen.KillWire3(index4, index5);
            if (num17 == (byte) 14)
              WorldGen.SlopeTile(index4, index5, (int) num18);
            if (num17 == (byte) 15)
              Minecart.FrameTrack(index4, index5, true);
            if (num17 == (byte) 16)
              WorldGen.PlaceWire4(index4, index5);
            if (num17 == (byte) 17)
              WorldGen.KillWire4(index4, index5);
            if (num17 == (byte) 18)
            {
              Wiring.SetCurrentUser(this.whoAmI);
              Wiring.PokeLogicGate(index4, index5);
              Wiring.SetCurrentUser();
              break;
            }
            if (num17 == (byte) 19)
            {
              Wiring.SetCurrentUser(this.whoAmI);
              Wiring.Actuate(index4, index5);
              Wiring.SetCurrentUser();
              break;
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(17, ignoreClient: this.whoAmI, number: ((int) num17), number2: ((float) index4), number3: ((float) index5), number4: ((float) num18), number5: num19);
            if (num17 != (byte) 1 || num18 != (short) 53)
              break;
            NetMessage.SendTileSquare(-1, index4, index5, 1);
            break;
          case 18:
            if (Main.netMode != 1)
              break;
            Main.dayTime = this.reader.ReadByte() == (byte) 1;
            Main.time = (double) this.reader.ReadInt32();
            Main.sunModY = this.reader.ReadInt16();
            Main.moonModY = this.reader.ReadInt16();
            break;
          case 19:
            byte num20 = this.reader.ReadByte();
            int num21 = (int) this.reader.ReadInt16();
            int num22 = (int) this.reader.ReadInt16();
            if (!WorldGen.InWorld(num21, num22, 3))
              break;
            int direction1 = this.reader.ReadByte() == (byte) 0 ? -1 : 1;
            switch (num20)
            {
              case 0:
                WorldGen.OpenDoor(num21, num22, direction1);
                break;
              case 1:
                WorldGen.CloseDoor(num21, num22, true);
                break;
              case 2:
                WorldGen.ShiftTrapdoor(num21, num22, direction1 == 1, 1);
                break;
              case 3:
                WorldGen.ShiftTrapdoor(num21, num22, direction1 == 1, 0);
                break;
              case 4:
                WorldGen.ShiftTallGate(num21, num22, false);
                break;
              case 5:
                WorldGen.ShiftTallGate(num21, num22, true);
                break;
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(19, ignoreClient: this.whoAmI, number: ((int) num20), number2: ((float) num21), number3: ((float) num22), number4: (direction1 == 1 ? 1f : 0.0f));
            break;
          case 20:
            int num23 = (int) this.reader.ReadUInt16();
            short num24 = (short) (num23 & (int) short.MaxValue);
            int num25 = (uint) (num23 & 32768) > 0U ? 1 : 0;
            byte num26 = 0;
            if (num25 != 0)
              num26 = this.reader.ReadByte();
            int num27 = (int) this.reader.ReadInt16();
            int num28 = (int) this.reader.ReadInt16();
            if (!WorldGen.InWorld(num27, num28, 3))
              break;
            TileChangeType type3 = TileChangeType.None;
            if (Enum.IsDefined(typeof (TileChangeType), (object) num26))
              type3 = (TileChangeType) num26;
            if (MessageBuffer.OnTileChangeReceived != null)
              MessageBuffer.OnTileChangeReceived(num27, num28, (int) num24, type3);
            BitsByte bitsByte11 = (BitsByte) (byte) 0;
            BitsByte bitsByte12 = (BitsByte) (byte) 0;
            for (int index6 = num27; index6 < num27 + (int) num24; ++index6)
            {
              for (int index7 = num28; index7 < num28 + (int) num24; ++index7)
              {
                if (Main.tile[index6, index7] == null)
                  Main.tile[index6, index7] = new Tile();
                Tile tile = Main.tile[index6, index7];
                bool flag4 = tile.active();
                BitsByte bitsByte13 = (BitsByte) this.reader.ReadByte();
                BitsByte bitsByte14 = (BitsByte) this.reader.ReadByte();
                tile.active(bitsByte13[0]);
                tile.wall = bitsByte13[2] ? (byte) 1 : (byte) 0;
                bool flag5 = bitsByte13[3];
                if (Main.netMode != 2)
                  tile.liquid = flag5 ? (byte) 1 : (byte) 0;
                tile.wire(bitsByte13[4]);
                tile.halfBrick(bitsByte13[5]);
                tile.actuator(bitsByte13[6]);
                tile.inActive(bitsByte13[7]);
                tile.wire2(bitsByte14[0]);
                tile.wire3(bitsByte14[1]);
                if (bitsByte14[2])
                  tile.color(this.reader.ReadByte());
                if (bitsByte14[3])
                  tile.wallColor(this.reader.ReadByte());
                if (tile.active())
                {
                  int type4 = (int) tile.type;
                  tile.type = this.reader.ReadUInt16();
                  if (Main.tileFrameImportant[(int) tile.type])
                  {
                    tile.frameX = this.reader.ReadInt16();
                    tile.frameY = this.reader.ReadInt16();
                  }
                  else if (!flag4 || (int) tile.type != type4)
                  {
                    tile.frameX = (short) -1;
                    tile.frameY = (short) -1;
                  }
                  byte slope = 0;
                  if (bitsByte14[4])
                    ++slope;
                  if (bitsByte14[5])
                    slope += (byte) 2;
                  if (bitsByte14[6])
                    slope += (byte) 4;
                  tile.slope(slope);
                }
                tile.wire4(bitsByte14[7]);
                if (tile.wall > (byte) 0)
                  tile.wall = this.reader.ReadByte();
                if (flag5)
                {
                  tile.liquid = this.reader.ReadByte();
                  tile.liquidType((int) this.reader.ReadByte());
                }
              }
            }
            WorldGen.RangeFrame(num27, num28, num27 + (int) num24, num28 + (int) num24);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData((int) num1, ignoreClient: this.whoAmI, number: ((int) num24), number2: ((float) num27), number3: ((float) num28));
            break;
          case 21:
          case 90:
            int index8 = (int) this.reader.ReadInt16();
            Vector2 vector2_1 = this.reader.ReadVector2();
            Vector2 vector2_2 = this.reader.ReadVector2();
            int Stack = (int) this.reader.ReadInt16();
            int pre1 = (int) this.reader.ReadByte();
            int num29 = (int) this.reader.ReadByte();
            int type5 = (int) this.reader.ReadInt16();
            if (Main.netMode == 1)
            {
              if (type5 == 0)
              {
                Main.item[index8].active = false;
                break;
              }
              int index9 = index8;
              Item obj = Main.item[index9];
              bool flag6 = (obj.newAndShiny || obj.netID != type5) && ItemSlot.Options.HighlightNewItems && (type5 < 0 || type5 >= 3930 || !ItemID.Sets.NeverShiny[type5]);
              obj.netDefaults(type5);
              obj.newAndShiny = flag6;
              obj.Prefix(pre1);
              obj.stack = Stack;
              obj.position = vector2_1;
              obj.velocity = vector2_2;
              obj.active = true;
              if (num1 == (byte) 90)
              {
                obj.instanced = true;
                obj.owner = Main.myPlayer;
                obj.keepTime = 600;
              }
              obj.wet = Collision.WetCollision(obj.position, obj.width, obj.height);
              break;
            }
            if (Main.itemLockoutTime[index8] > 0)
              break;
            if (type5 == 0)
            {
              if (index8 >= 400)
                break;
              Main.item[index8].active = false;
              NetMessage.SendData(21, number: index8);
              break;
            }
            bool flag7 = false;
            if (index8 == 400)
              flag7 = true;
            if (flag7)
            {
              Item obj = new Item();
              obj.netDefaults(type5);
              index8 = Item.NewItem((int) vector2_1.X, (int) vector2_1.Y, obj.width, obj.height, obj.type, Stack, true);
            }
            Item obj1 = Main.item[index8];
            obj1.netDefaults(type5);
            obj1.Prefix(pre1);
            obj1.stack = Stack;
            obj1.position = vector2_1;
            obj1.velocity = vector2_2;
            obj1.active = true;
            obj1.owner = Main.myPlayer;
            if (flag7)
            {
              NetMessage.SendData(21, number: index8);
              if (num29 == 0)
              {
                Main.item[index8].ownIgnore = this.whoAmI;
                Main.item[index8].ownTime = 100;
              }
              Main.item[index8].FindOwner(index8);
              break;
            }
            NetMessage.SendData(21, ignoreClient: this.whoAmI, number: index8);
            break;
          case 22:
            int number12 = (int) this.reader.ReadInt16();
            int num30 = (int) this.reader.ReadByte();
            if (Main.netMode == 2 && Main.item[number12].owner != this.whoAmI)
              break;
            Main.item[number12].owner = num30;
            Main.item[number12].keepTime = num30 != Main.myPlayer ? 0 : 15;
            if (Main.netMode != 2)
              break;
            Main.item[number12].owner = (int) byte.MaxValue;
            Main.item[number12].keepTime = 15;
            NetMessage.SendData(22, number: number12);
            break;
          case 23:
            if (Main.netMode != 1)
              break;
            int index10 = (int) this.reader.ReadInt16();
            Vector2 vector2_3 = this.reader.ReadVector2();
            Vector2 vector2_4 = this.reader.ReadVector2();
            int num31 = (int) this.reader.ReadUInt16();
            if (num31 == (int) ushort.MaxValue)
              num31 = 0;
            BitsByte bitsByte15 = (BitsByte) this.reader.ReadByte();
            float[] numArray1 = new float[NPC.maxAI];
            for (int index11 = 0; index11 < NPC.maxAI; ++index11)
              numArray1[index11] = !bitsByte15[index11 + 2] ? 0.0f : this.reader.ReadSingle();
            int Type1 = (int) this.reader.ReadInt16();
            int num32 = 0;
            if (!bitsByte15[7])
            {
              switch (this.reader.ReadByte())
              {
                case 2:
                  num32 = (int) this.reader.ReadInt16();
                  break;
                case 4:
                  num32 = this.reader.ReadInt32();
                  break;
                default:
                  num32 = (int) this.reader.ReadSByte();
                  break;
              }
            }
            int oldType = -1;
            NPC npc1 = Main.npc[index10];
            if (!npc1.active || npc1.netID != Type1)
            {
              if (npc1.active)
                oldType = npc1.type;
              npc1.active = true;
              npc1.SetDefaults(Type1);
            }
            if ((double) Vector2.DistanceSquared(npc1.position, vector2_3) < 6400.0)
              npc1.visualOffset = npc1.position - vector2_3;
            npc1.position = vector2_3;
            npc1.velocity = vector2_4;
            npc1.target = num31;
            npc1.direction = bitsByte15[0] ? 1 : -1;
            npc1.directionY = bitsByte15[1] ? 1 : -1;
            npc1.spriteDirection = bitsByte15[6] ? 1 : -1;
            if (bitsByte15[7])
              num32 = npc1.life = npc1.lifeMax;
            else
              npc1.life = num32;
            if (num32 <= 0)
              npc1.active = false;
            for (int index12 = 0; index12 < NPC.maxAI; ++index12)
              npc1.ai[index12] = numArray1[index12];
            if (oldType > -1 && oldType != npc1.type)
              npc1.TransformVisuals(oldType, npc1.type);
            if (Type1 == 262)
              NPC.plantBoss = index10;
            if (Type1 == 245)
              NPC.golemBoss = index10;
            if (npc1.type < 0 || npc1.type >= 580 || !Main.npcCatchable[npc1.type])
              break;
            npc1.releaseOwner = (short) this.reader.ReadByte();
            break;
          case 24:
            int number13 = (int) this.reader.ReadInt16();
            int index13 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              index13 = this.whoAmI;
            Player player7 = Main.player[index13];
            Main.npc[number13].StrikeNPC(player7.inventory[player7.selectedItem].damage, player7.inventory[player7.selectedItem].knockBack, player7.direction);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(24, ignoreClient: this.whoAmI, number: number13, number2: ((float) index13));
            NetMessage.SendData(23, number: number13);
            break;
          case 27:
            int num33 = (int) this.reader.ReadInt16();
            Vector2 vector2_5 = this.reader.ReadVector2();
            Vector2 vector2_6 = this.reader.ReadVector2();
            float num34 = this.reader.ReadSingle();
            int num35 = (int) this.reader.ReadInt16();
            int index14 = (int) this.reader.ReadByte();
            int Type2 = (int) this.reader.ReadInt16();
            BitsByte bitsByte16 = (BitsByte) this.reader.ReadByte();
            float[] numArray2 = new float[Projectile.maxAI];
            for (int key = 0; key < Projectile.maxAI; ++key)
              numArray2[key] = !bitsByte16[key] ? 0.0f : this.reader.ReadSingle();
            int index15 = bitsByte16[Projectile.maxAI] ? (int) this.reader.ReadInt16() : -1;
            if (index15 >= 1000)
              index15 = -1;
            if (Main.netMode == 2)
            {
              index14 = this.whoAmI;
              if (Main.projHostile[Type2])
                break;
            }
            int number14 = 1000;
            for (int index16 = 0; index16 < 1000; ++index16)
            {
              if (Main.projectile[index16].owner == index14 && Main.projectile[index16].identity == num33 && Main.projectile[index16].active)
              {
                number14 = index16;
                break;
              }
            }
            if (number14 == 1000)
            {
              for (int index17 = 0; index17 < 1000; ++index17)
              {
                if (!Main.projectile[index17].active)
                {
                  number14 = index17;
                  break;
                }
              }
            }
            Projectile projectile1 = Main.projectile[number14];
            if (!projectile1.active || projectile1.type != Type2)
            {
              projectile1.SetDefaults(Type2);
              if (Main.netMode == 2)
                ++Netplay.Clients[this.whoAmI].SpamProjectile;
            }
            projectile1.identity = num33;
            projectile1.position = vector2_5;
            projectile1.velocity = vector2_6;
            projectile1.type = Type2;
            projectile1.damage = num35;
            projectile1.knockBack = num34;
            projectile1.owner = index14;
            for (int index18 = 0; index18 < Projectile.maxAI; ++index18)
              projectile1.ai[index18] = numArray2[index18];
            if (index15 >= 0)
            {
              projectile1.projUUID = index15;
              Main.projectileIdentity[index14, index15] = number14;
            }
            projectile1.ProjectileFixDesperation();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(27, ignoreClient: this.whoAmI, number: number14);
            break;
          case 28:
            int number15 = (int) this.reader.ReadInt16();
            int Damage1 = (int) this.reader.ReadInt16();
            float num36 = this.reader.ReadSingle();
            int hitDirection = (int) this.reader.ReadByte() - 1;
            byte num37 = this.reader.ReadByte();
            if (Main.netMode == 2)
            {
              if (Damage1 < 0)
                Damage1 = 0;
              Main.npc[number15].PlayerInteraction(this.whoAmI);
            }
            if (Damage1 >= 0)
            {
              Main.npc[number15].StrikeNPC(Damage1, num36, hitDirection, num37 == (byte) 1, fromNet: true);
            }
            else
            {
              Main.npc[number15].life = 0;
              Main.npc[number15].HitEffect();
              Main.npc[number15].active = false;
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(28, ignoreClient: this.whoAmI, number: number15, number2: ((float) Damage1), number3: num36, number4: ((float) hitDirection), number5: ((int) num37));
            if (Main.npc[number15].life <= 0)
              NetMessage.SendData(23, number: number15);
            else
              Main.npc[number15].netUpdate = true;
            if (Main.npc[number15].realLife < 0)
              break;
            if (Main.npc[Main.npc[number15].realLife].life <= 0)
            {
              NetMessage.SendData(23, number: Main.npc[number15].realLife);
              break;
            }
            Main.npc[Main.npc[number15].realLife].netUpdate = true;
            break;
          case 29:
            int number16 = (int) this.reader.ReadInt16();
            int num38 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              num38 = this.whoAmI;
            for (int index19 = 0; index19 < 1000; ++index19)
            {
              if (Main.projectile[index19].owner == num38 && Main.projectile[index19].identity == number16 && Main.projectile[index19].active)
              {
                Main.projectile[index19].Kill();
                break;
              }
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(29, ignoreClient: this.whoAmI, number: number16, number2: ((float) num38));
            break;
          case 30:
            int number17 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number17 = this.whoAmI;
            bool flag8 = this.reader.ReadBoolean();
            Main.player[number17].hostile = flag8;
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(30, ignoreClient: this.whoAmI, number: number17);
            LocalizedText localizedText1 = flag8 ? Lang.mp[11] : Lang.mp[12];
            Color color1 = Main.teamColor[Main.player[number17].team];
            NetMessage.BroadcastChatMessage(NetworkText.FromKey(localizedText1.Key, (object) Main.player[number17].name), color1);
            break;
          case 31:
            if (Main.netMode != 2)
              break;
            int chest1 = Chest.FindChest((int) this.reader.ReadInt16(), (int) this.reader.ReadInt16());
            if (chest1 <= -1 || Chest.UsingChest(chest1) != -1)
              break;
            for (int index20 = 0; index20 < 40; ++index20)
              NetMessage.SendData(32, this.whoAmI, number: chest1, number2: ((float) index20));
            NetMessage.SendData(33, this.whoAmI, number: chest1);
            Main.player[this.whoAmI].chest = chest1;
            if (Main.myPlayer == this.whoAmI)
              Main.recBigList = false;
            NetMessage.SendData(80, ignoreClient: this.whoAmI, number: this.whoAmI, number2: ((float) chest1));
            break;
          case 32:
            int index21 = (int) this.reader.ReadInt16();
            int index22 = (int) this.reader.ReadByte();
            int num39 = (int) this.reader.ReadInt16();
            int pre2 = (int) this.reader.ReadByte();
            int type6 = (int) this.reader.ReadInt16();
            if (Main.chest[index21] == null)
              Main.chest[index21] = new Chest();
            if (Main.chest[index21].item[index22] == null)
              Main.chest[index21].item[index22] = new Item();
            Main.chest[index21].item[index22].netDefaults(type6);
            Main.chest[index21].item[index22].Prefix(pre2);
            Main.chest[index21].item[index22].stack = num39;
            Recipe.FindRecipes();
            break;
          case 33:
            int num40 = (int) this.reader.ReadInt16();
            int index23 = (int) this.reader.ReadInt16();
            int index24 = (int) this.reader.ReadInt16();
            int num41 = (int) this.reader.ReadByte();
            string str1 = string.Empty;
            if (num41 != 0)
            {
              if (num41 <= 20)
                str1 = this.reader.ReadString();
              else if (num41 != (int) byte.MaxValue)
                num41 = 0;
            }
            if (Main.netMode == 1)
            {
              Player player8 = Main.player[Main.myPlayer];
              if (player8.chest == -1)
              {
                Main.playerInventory = true;
                Main.PlaySound(10);
              }
              else if (player8.chest != num40 && num40 != -1)
              {
                Main.playerInventory = true;
                Main.PlaySound(12);
                Main.recBigList = false;
              }
              else if (player8.chest != -1 && num40 == -1)
              {
                Main.PlaySound(11);
                Main.recBigList = false;
              }
              player8.chest = num40;
              player8.chestX = index23;
              player8.chestY = index24;
              Recipe.FindRecipes();
              if (Main.tile[index23, index24].frameX < (short) 36 || Main.tile[index23, index24].frameX >= (short) 72)
                break;
              AchievementsHelper.HandleSpecialEvent(Main.player[Main.myPlayer], 16);
              break;
            }
            if (num41 != 0)
            {
              int chest2 = Main.player[this.whoAmI].chest;
              Chest chest3 = Main.chest[chest2];
              chest3.name = str1;
              NetMessage.SendData(69, ignoreClient: this.whoAmI, number: chest2, number2: ((float) chest3.x), number3: ((float) chest3.y));
            }
            Main.player[this.whoAmI].chest = num40;
            Recipe.FindRecipes();
            NetMessage.SendData(80, ignoreClient: this.whoAmI, number: this.whoAmI, number2: ((float) num40));
            break;
          case 34:
            byte num42 = this.reader.ReadByte();
            int index25 = (int) this.reader.ReadInt16();
            int index26 = (int) this.reader.ReadInt16();
            int style1 = (int) this.reader.ReadInt16();
            int id = (int) this.reader.ReadInt16();
            if (Main.netMode == 2)
              id = 0;
            if (Main.netMode == 2)
            {
              if (num42 == (byte) 0)
              {
                int number5_1 = WorldGen.PlaceChest(index25, index26, style: style1);
                if (number5_1 == -1)
                {
                  NetMessage.SendData(34, this.whoAmI, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number4: ((float) style1), number5: number5_1);
                  Item.NewItem(index25 * 16, index26 * 16, 32, 32, Chest.chestItemSpawn[style1], noBroadcast: true);
                  break;
                }
                NetMessage.SendData(34, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number4: ((float) style1), number5: number5_1);
                break;
              }
              if (num42 == (byte) 1 && Main.tile[index25, index26].type == (ushort) 21)
              {
                Tile tile = Main.tile[index25, index26];
                if ((int) tile.frameX % 36 != 0)
                  --index25;
                if ((int) tile.frameY % 36 != 0)
                  --index26;
                int chest4 = Chest.FindChest(index25, index26);
                WorldGen.KillTile(index25, index26);
                if (tile.active())
                  break;
                NetMessage.SendData(34, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number5: chest4);
                break;
              }
              if (num42 == (byte) 2)
              {
                int number5_2 = WorldGen.PlaceChest(index25, index26, (ushort) 88, style: style1);
                if (number5_2 == -1)
                {
                  NetMessage.SendData(34, this.whoAmI, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number4: ((float) style1), number5: number5_2);
                  Item.NewItem(index25 * 16, index26 * 16, 32, 32, Chest.dresserItemSpawn[style1], noBroadcast: true);
                  break;
                }
                NetMessage.SendData(34, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number4: ((float) style1), number5: number5_2);
                break;
              }
              if (num42 == (byte) 3 && Main.tile[index25, index26].type == (ushort) 88)
              {
                Tile tile = Main.tile[index25, index26];
                int num43 = index25 - (int) tile.frameX % 54 / 18;
                if ((int) tile.frameY % 36 != 0)
                  --index26;
                int chest5 = Chest.FindChest(num43, index26);
                WorldGen.KillTile(num43, index26);
                if (tile.active())
                  break;
                NetMessage.SendData(34, number: ((int) num42), number2: ((float) num43), number3: ((float) index26), number5: chest5);
                break;
              }
              if (num42 == (byte) 4)
              {
                int number5_3 = WorldGen.PlaceChest(index25, index26, (ushort) 467, style: style1);
                if (number5_3 == -1)
                {
                  NetMessage.SendData(34, this.whoAmI, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number4: ((float) style1), number5: number5_3);
                  Item.NewItem(index25 * 16, index26 * 16, 32, 32, Chest.chestItemSpawn2[style1], noBroadcast: true);
                  break;
                }
                NetMessage.SendData(34, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number4: ((float) style1), number5: number5_3);
                break;
              }
              if (num42 != (byte) 5 || Main.tile[index25, index26].type != (ushort) 467)
                break;
              Tile tile1 = Main.tile[index25, index26];
              if ((int) tile1.frameX % 36 != 0)
                --index25;
              if ((int) tile1.frameY % 36 != 0)
                --index26;
              int chest6 = Chest.FindChest(index25, index26);
              WorldGen.KillTile(index25, index26);
              if (tile1.active())
                break;
              NetMessage.SendData(34, number: ((int) num42), number2: ((float) index25), number3: ((float) index26), number5: chest6);
              break;
            }
            switch (num42)
            {
              case 0:
                if (id == -1)
                {
                  WorldGen.KillTile(index25, index26);
                  return;
                }
                WorldGen.PlaceChestDirect(index25, index26, (ushort) 21, style1, id);
                return;
              case 2:
                if (id == -1)
                {
                  WorldGen.KillTile(index25, index26);
                  return;
                }
                WorldGen.PlaceDresserDirect(index25, index26, (ushort) 88, style1, id);
                return;
              case 4:
                if (id == -1)
                {
                  WorldGen.KillTile(index25, index26);
                  return;
                }
                WorldGen.PlaceChestDirect(index25, index26, (ushort) 467, style1, id);
                return;
              default:
                Chest.DestroyChestDirect(index25, index26, id);
                WorldGen.KillTile(index25, index26);
                return;
            }
          case 35:
            int number18 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number18 = this.whoAmI;
            int healAmount1 = (int) this.reader.ReadInt16();
            if (number18 != Main.myPlayer || Main.ServerSideCharacter)
              Main.player[number18].HealEffect(healAmount1);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(35, ignoreClient: this.whoAmI, number: number18, number2: ((float) healAmount1));
            break;
          case 36:
            int number19 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number19 = this.whoAmI;
            Player player9 = Main.player[number19];
            player9.zone1 = (BitsByte) this.reader.ReadByte();
            player9.zone2 = (BitsByte) this.reader.ReadByte();
            player9.zone3 = (BitsByte) this.reader.ReadByte();
            player9.zone4 = (BitsByte) this.reader.ReadByte();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(36, ignoreClient: this.whoAmI, number: number19);
            break;
          case 37:
            if (Main.netMode != 1)
              break;
            if (Main.autoPass)
            {
              NetMessage.SendData(38);
              Main.autoPass = false;
              break;
            }
            Netplay.ServerPassword = "";
            Main.menuMode = 31;
            break;
          case 38:
            if (Main.netMode != 2)
              break;
            if (this.reader.ReadString() == Netplay.ServerPassword)
            {
              Netplay.Clients[this.whoAmI].State = 1;
              NetMessage.SendData(3, this.whoAmI);
              break;
            }
            NetMessage.SendData(2, this.whoAmI, text: Lang.mp[1].ToNetworkText());
            break;
          case 39:
            if (Main.netMode != 1)
              break;
            int number20 = (int) this.reader.ReadInt16();
            Main.item[number20].owner = (int) byte.MaxValue;
            NetMessage.SendData(22, number: number20);
            break;
          case 40:
            int number21 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number21 = this.whoAmI;
            int num44 = (int) this.reader.ReadInt16();
            Main.player[number21].talkNPC = num44;
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(40, ignoreClient: this.whoAmI, number: number21);
            break;
          case 41:
            int number22 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number22 = this.whoAmI;
            Player player10 = Main.player[number22];
            float num45 = this.reader.ReadSingle();
            int num46 = (int) this.reader.ReadInt16();
            player10.itemRotation = num45;
            player10.itemAnimation = num46;
            player10.channel = player10.inventory[player10.selectedItem].channel;
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(41, ignoreClient: this.whoAmI, number: number22);
            break;
          case 42:
            int index27 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              index27 = this.whoAmI;
            else if (Main.myPlayer == index27 && !Main.ServerSideCharacter)
              break;
            int num47 = (int) this.reader.ReadInt16();
            int num48 = (int) this.reader.ReadInt16();
            Main.player[index27].statMana = num47;
            Main.player[index27].statManaMax = num48;
            break;
          case 43:
            int number23 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number23 = this.whoAmI;
            int manaAmount = (int) this.reader.ReadInt16();
            if (number23 != Main.myPlayer)
              Main.player[number23].ManaEffect(manaAmount);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(43, ignoreClient: this.whoAmI, number: number23, number2: ((float) manaAmount));
            break;
          case 45:
            int number24 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number24 = this.whoAmI;
            int index28 = (int) this.reader.ReadByte();
            Player player11 = Main.player[number24];
            int team = player11.team;
            player11.team = index28;
            Color color2 = Main.teamColor[index28];
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(45, ignoreClient: this.whoAmI, number: number24);
            LocalizedText localizedText2 = Lang.mp[13 + index28];
            if (index28 == 5)
              localizedText2 = Lang.mp[22];
            for (int playerId = 0; playerId < (int) byte.MaxValue; ++playerId)
            {
              if (playerId == this.whoAmI || team > 0 && Main.player[playerId].team == team || index28 > 0 && Main.player[playerId].team == index28)
                NetMessage.SendChatMessageToClient(NetworkText.FromKey(localizedText2.Key, (object) player11.name), color2, playerId);
            }
            break;
          case 46:
            if (Main.netMode != 2)
              break;
            int number25 = Sign.ReadSign((int) this.reader.ReadInt16(), (int) this.reader.ReadInt16());
            if (number25 < 0)
              break;
            NetMessage.SendData(47, this.whoAmI, number: number25, number2: ((float) this.whoAmI));
            break;
          case 47:
            int index29 = (int) this.reader.ReadInt16();
            int num49 = (int) this.reader.ReadInt16();
            int num50 = (int) this.reader.ReadInt16();
            string text1 = this.reader.ReadString();
            string str2 = (string) null;
            if (Main.sign[index29] != null)
              str2 = Main.sign[index29].text;
            Main.sign[index29] = new Sign();
            Main.sign[index29].x = num49;
            Main.sign[index29].y = num50;
            Sign.TextSign(index29, text1);
            int num51 = (int) this.reader.ReadByte();
            if (Main.netMode == 2 && str2 != text1)
            {
              num51 = this.whoAmI;
              NetMessage.SendData(47, ignoreClient: this.whoAmI, number: index29, number2: ((float) num51));
            }
            if (Main.netMode != 1 || num51 != Main.myPlayer || Main.sign[index29] == null)
              break;
            Main.playerInventory = false;
            Main.player[Main.myPlayer].talkNPC = -1;
            Main.npcChatCornerItem = 0;
            Main.editSign = false;
            Main.PlaySound(10);
            Main.player[Main.myPlayer].sign = index29;
            Main.npcChatText = Main.sign[index29].text;
            break;
          case 48:
            int i1 = (int) this.reader.ReadInt16();
            int j1 = (int) this.reader.ReadInt16();
            byte num52 = this.reader.ReadByte();
            byte num53 = this.reader.ReadByte();
            if (Main.netMode == 2 && Netplay.spamCheck)
            {
              int whoAmI = this.whoAmI;
              int num54 = (int) ((double) Main.player[whoAmI].position.X + (double) (Main.player[whoAmI].width / 2));
              int num55 = (int) ((double) Main.player[whoAmI].position.Y + (double) (Main.player[whoAmI].height / 2));
              int num56 = 10;
              int num57 = num54 - num56;
              int num58 = num54 + num56;
              int num59 = num55 - num56;
              int num60 = num55 + num56;
              if (i1 < num57 || i1 > num58 || j1 < num59 || j1 > num60)
              {
                NetMessage.BootPlayer(this.whoAmI, NetworkText.FromKey("Net.CheatingLiquidSpam"));
                break;
              }
            }
            if (Main.tile[i1, j1] == null)
              Main.tile[i1, j1] = new Tile();
            lock (Main.tile[i1, j1])
            {
              Main.tile[i1, j1].liquid = num52;
              Main.tile[i1, j1].liquidType((int) num53);
              if (Main.netMode != 2)
                break;
              WorldGen.SquareTileFrame(i1, j1);
              break;
            }
          case 49:
            if (Netplay.Connection.State != 6)
              break;
            Netplay.Connection.State = 10;
            Main.ActivePlayerFileData.StartPlayTimer();
            Player.Hooks.EnterWorld(Main.myPlayer);
            Main.player[Main.myPlayer].Spawn();
            break;
          case 50:
            int number26 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number26 = this.whoAmI;
            else if (number26 == Main.myPlayer && !Main.ServerSideCharacter)
              break;
            Player player12 = Main.player[number26];
            for (int index30 = 0; index30 < 22; ++index30)
            {
              player12.buffType[index30] = (int) this.reader.ReadByte();
              player12.buffTime[index30] = player12.buffType[index30] <= 0 ? 0 : 60;
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(50, ignoreClient: this.whoAmI, number: number26);
            break;
          case 51:
            byte num61 = this.reader.ReadByte();
            byte num62 = this.reader.ReadByte();
            switch (num62)
            {
              case 1:
                NPC.SpawnSkeletron();
                return;
              case 2:
                if (Main.netMode == 2)
                {
                  NetMessage.SendData(51, ignoreClient: this.whoAmI, number: ((int) num61), number2: ((float) num62));
                  return;
                }
                Main.PlaySound(SoundID.Item1, (int) Main.player[(int) num61].position.X, (int) Main.player[(int) num61].position.Y);
                return;
              case 3:
                if (Main.netMode != 2)
                  return;
                Main.Sundialing();
                return;
              case 4:
                Main.npc[(int) num61].BigMimicSpawnSmoke();
                return;
              default:
                return;
            }
          case 52:
            int num63 = (int) this.reader.ReadByte();
            int num64 = (int) this.reader.ReadInt16();
            int num65 = (int) this.reader.ReadInt16();
            if (num63 == 1)
            {
              Chest.Unlock(num64, num65);
              if (Main.netMode == 2)
              {
                NetMessage.SendData(52, ignoreClient: this.whoAmI, number2: ((float) num63), number3: ((float) num64), number4: ((float) num65));
                NetMessage.SendTileSquare(-1, num64, num65, 2);
              }
            }
            if (num63 != 2)
              break;
            WorldGen.UnlockDoor(num64, num65);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(52, ignoreClient: this.whoAmI, number2: ((float) num63), number3: ((float) num64), number4: ((float) num65));
            NetMessage.SendTileSquare(-1, num64, num65, 2);
            break;
          case 53:
            int number27 = (int) this.reader.ReadInt16();
            int type7 = (int) this.reader.ReadByte();
            int time1 = (int) this.reader.ReadInt16();
            Main.npc[number27].AddBuff(type7, time1, true);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(54, number: number27);
            break;
          case 54:
            if (Main.netMode != 1)
              break;
            int index31 = (int) this.reader.ReadInt16();
            NPC npc2 = Main.npc[index31];
            for (int index32 = 0; index32 < 5; ++index32)
            {
              npc2.buffType[index32] = (int) this.reader.ReadByte();
              npc2.buffTime[index32] = (int) this.reader.ReadInt16();
            }
            break;
          case 55:
            int index33 = (int) this.reader.ReadByte();
            int type8 = (int) this.reader.ReadByte();
            int time1_1 = this.reader.ReadInt32();
            if (Main.netMode == 2 && index33 != this.whoAmI && !Main.pvpBuff[type8])
              break;
            if (Main.netMode == 1 && index33 == Main.myPlayer)
            {
              Main.player[index33].AddBuff(type8, time1_1);
              break;
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(55, index33, number: index33, number2: ((float) type8), number3: ((float) time1_1));
            break;
          case 56:
            int number28 = (int) this.reader.ReadInt16();
            if (number28 < 0 || number28 >= 200)
              break;
            if (Main.netMode == 1)
            {
              string str3 = this.reader.ReadString();
              Main.npc[number28].GivenName = str3;
              break;
            }
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(56, this.whoAmI, number: number28);
            break;
          case 57:
            if (Main.netMode != 1)
              break;
            WorldGen.tGood = this.reader.ReadByte();
            WorldGen.tEvil = this.reader.ReadByte();
            WorldGen.tBlood = this.reader.ReadByte();
            break;
          case 58:
            int index34 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              index34 = this.whoAmI;
            float number2_1 = this.reader.ReadSingle();
            if (Main.netMode == 2)
            {
              NetMessage.SendData(58, ignoreClient: this.whoAmI, number: this.whoAmI, number2: number2_1);
              break;
            }
            Player player13 = Main.player[index34];
            Main.harpNote = number2_1;
            LegacySoundStyle type9 = SoundID.Item26;
            if (player13.inventory[player13.selectedItem].type == 507)
              type9 = SoundID.Item35;
            Main.PlaySound(type9, player13.position);
            break;
          case 59:
            int num66 = (int) this.reader.ReadInt16();
            int j2 = (int) this.reader.ReadInt16();
            Wiring.SetCurrentUser(this.whoAmI);
            Wiring.HitSwitch(num66, j2);
            Wiring.SetCurrentUser();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(59, ignoreClient: this.whoAmI, number: num66, number2: ((float) j2));
            break;
          case 60:
            int n = (int) this.reader.ReadInt16();
            int x1 = (int) this.reader.ReadInt16();
            int y4 = (int) this.reader.ReadInt16();
            byte num67 = this.reader.ReadByte();
            if (n >= 200)
            {
              NetMessage.BootPlayer(this.whoAmI, NetworkText.FromKey("Net.CheatingInvalid"));
              break;
            }
            if (Main.netMode == 1)
            {
              Main.npc[n].homeless = num67 == (byte) 1;
              Main.npc[n].homeTileX = x1;
              Main.npc[n].homeTileY = y4;
              if (num67 == (byte) 1)
              {
                WorldGen.TownManager.KickOut(Main.npc[n].type);
                break;
              }
              if (num67 != (byte) 2)
                break;
              WorldGen.TownManager.SetRoom(Main.npc[n].type, x1, y4);
              break;
            }
            if (num67 == (byte) 1)
            {
              WorldGen.kickOut(n);
              break;
            }
            WorldGen.moveRoom(x1, y4, n);
            break;
          case 61:
            int plr = (int) this.reader.ReadInt16();
            int Type3 = (int) this.reader.ReadInt16();
            if (Main.netMode != 2)
              break;
            if (Type3 >= 0 && Type3 < 580 && NPCID.Sets.MPAllowedEnemies[Type3])
            {
              if (NPC.AnyNPCs(Type3))
                break;
              NPC.SpawnOnPlayer(plr, Type3);
              break;
            }
            switch (Type3)
            {
              case -8:
                if (!NPC.downedGolemBoss || !Main.hardMode || NPC.AnyDanger() || NPC.AnyoneNearCultists())
                  return;
                WorldGen.StartImpendingDoom();
                NetMessage.SendData(7);
                return;
              case -7:
                Main.invasionDelay = 0;
                Main.StartInvasion(4);
                NetMessage.SendData(7);
                NetMessage.SendData(78, number2: 1f, number3: ((float) (Main.invasionType + 3)));
                return;
              case -6:
                if (!Main.dayTime || Main.eclipse)
                  return;
                NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[20].Key), new Color(50, (int) byte.MaxValue, 130));
                Main.eclipse = true;
                NetMessage.SendData(7);
                return;
              case -5:
                if (Main.dayTime || DD2Event.Ongoing)
                  return;
                NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[34].Key), new Color(50, (int) byte.MaxValue, 130));
                Main.startSnowMoon();
                NetMessage.SendData(7);
                NetMessage.SendData(78, number2: 1f, number3: 1f, number4: 1f);
                return;
              case -4:
                if (Main.dayTime || DD2Event.Ongoing)
                  return;
                NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[31].Key), new Color(50, (int) byte.MaxValue, 130));
                Main.startPumpkinMoon();
                NetMessage.SendData(7);
                NetMessage.SendData(78, number2: 1f, number3: 2f, number4: 1f);
                return;
              default:
                if (Type3 >= 0)
                  return;
                int type10 = 1;
                if (Type3 > -5)
                  type10 = -Type3;
                if (type10 > 0 && Main.invasionType == 0)
                {
                  Main.invasionDelay = 0;
                  Main.StartInvasion(type10);
                }
                NetMessage.SendData(78, number2: 1f, number3: ((float) (Main.invasionType + 3)));
                return;
            }
          case 62:
            int number29 = (int) this.reader.ReadByte();
            int num68 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number29 = this.whoAmI;
            if (num68 == 1)
              Main.player[number29].NinjaDodge();
            if (num68 == 2)
              Main.player[number29].ShadowDodge();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(62, ignoreClient: this.whoAmI, number: number29, number2: ((float) num68));
            break;
          case 63:
            int num69 = (int) this.reader.ReadInt16();
            int y5 = (int) this.reader.ReadInt16();
            byte color3 = this.reader.ReadByte();
            WorldGen.paintTile(num69, y5, color3);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(63, ignoreClient: this.whoAmI, number: num69, number2: ((float) y5), number3: ((float) color3));
            break;
          case 64:
            int num70 = (int) this.reader.ReadInt16();
            int y6 = (int) this.reader.ReadInt16();
            byte color4 = this.reader.ReadByte();
            WorldGen.paintWall(num70, y6, color4);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(64, ignoreClient: this.whoAmI, number: num70, number2: ((float) y6), number3: ((float) color4));
            break;
          case 65:
            BitsByte bitsByte17 = (BitsByte) this.reader.ReadByte();
            int index35 = (int) this.reader.ReadInt16();
            if (Main.netMode == 2)
              index35 = this.whoAmI;
            Vector2 vector2_7 = this.reader.ReadVector2();
            int num71 = 0;
            int num72 = 0;
            if (bitsByte17[0])
              ++num71;
            if (bitsByte17[1])
              num71 += 2;
            if (bitsByte17[2])
              ++num72;
            if (bitsByte17[3])
              num72 += 2;
            switch (num71)
            {
              case 0:
                Main.player[index35].Teleport(vector2_7, num72);
                break;
              case 1:
                Main.npc[index35].Teleport(vector2_7, num72);
                break;
              case 2:
                Main.player[index35].Teleport(vector2_7, num72);
                if (Main.netMode == 2)
                {
                  RemoteClient.CheckSection(this.whoAmI, vector2_7);
                  NetMessage.SendData(65, number2: ((float) index35), number3: vector2_7.X, number4: vector2_7.Y, number5: num72);
                  int index36 = -1;
                  float num73 = 9999f;
                  for (int index37 = 0; index37 < (int) byte.MaxValue; ++index37)
                  {
                    if (Main.player[index37].active && index37 != this.whoAmI)
                    {
                      Vector2 vector2_8 = Main.player[index37].position - Main.player[this.whoAmI].position;
                      if ((double) vector2_8.Length() < (double) num73)
                      {
                        num73 = vector2_8.Length();
                        index36 = index37;
                      }
                    }
                  }
                  if (index36 >= 0)
                  {
                    NetMessage.BroadcastChatMessage(NetworkText.FromKey("Game.HasTeleportedTo", (object) Main.player[this.whoAmI].name, (object) Main.player[index36].name), new Color(250, 250, 0));
                    break;
                  }
                  break;
                }
                break;
            }
            if (Main.netMode != 2 || num71 != 0)
              break;
            NetMessage.SendData(65, ignoreClient: this.whoAmI, number2: ((float) index35), number3: vector2_7.X, number4: vector2_7.Y, number5: num72);
            break;
          case 66:
            int number30 = (int) this.reader.ReadByte();
            int healAmount2 = (int) this.reader.ReadInt16();
            if (healAmount2 <= 0)
              break;
            Player player14 = Main.player[number30];
            player14.statLife += healAmount2;
            if (player14.statLife > player14.statLifeMax2)
              player14.statLife = player14.statLifeMax2;
            player14.HealEffect(healAmount2, false);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(66, ignoreClient: this.whoAmI, number: number30, number2: ((float) healAmount2));
            break;
          case 68:
            this.reader.ReadString();
            break;
          case 69:
            int number31 = (int) this.reader.ReadInt16();
            int X = (int) this.reader.ReadInt16();
            int Y = (int) this.reader.ReadInt16();
            if (Main.netMode == 1)
            {
              if (number31 < 0 || number31 >= 1000)
                break;
              Chest chest7 = Main.chest[number31];
              if (chest7 == null)
              {
                chest7 = new Chest();
                chest7.x = X;
                chest7.y = Y;
                Main.chest[number31] = chest7;
              }
              else if (chest7.x != X || chest7.y != Y)
                break;
              chest7.name = this.reader.ReadString();
              break;
            }
            if (number31 < -1 || number31 >= 1000)
              break;
            if (number31 == -1)
            {
              number31 = Chest.FindChest(X, Y);
              if (number31 == -1)
                break;
            }
            Chest chest8 = Main.chest[number31];
            if (chest8.x != X || chest8.y != Y)
              break;
            NetMessage.SendData(69, this.whoAmI, number: number31, number2: ((float) X), number3: ((float) Y));
            break;
          case 70:
            if (Main.netMode != 2)
              break;
            int i2 = (int) this.reader.ReadInt16();
            int who = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              who = this.whoAmI;
            if (i2 >= 200 || i2 < 0)
              break;
            NPC.CatchNPC(i2, who);
            break;
          case 71:
            if (Main.netMode != 2)
              break;
            int x2 = this.reader.ReadInt32();
            int num74 = this.reader.ReadInt32();
            int num75 = (int) this.reader.ReadInt16();
            byte num76 = this.reader.ReadByte();
            int y7 = num74;
            int Type4 = num75;
            int Style = (int) num76;
            int whoAmI1 = this.whoAmI;
            NPC.ReleaseNPC(x2, y7, Type4, Style, whoAmI1);
            break;
          case 72:
            if (Main.netMode != 1)
              break;
            for (int index38 = 0; index38 < 40; ++index38)
              Main.travelShop[index38] = (int) this.reader.ReadInt16();
            break;
          case 73:
            Main.player[this.whoAmI].TeleportationPotion();
            break;
          case 74:
            if (Main.netMode != 1)
              break;
            Main.anglerQuest = (int) this.reader.ReadByte();
            Main.anglerQuestFinished = this.reader.ReadBoolean();
            break;
          case 75:
            if (Main.netMode != 2)
              break;
            string name = Main.player[this.whoAmI].name;
            if (Main.anglerWhoFinishedToday.Contains(name))
              break;
            Main.anglerWhoFinishedToday.Add(name);
            break;
          case 76:
            int number32 = (int) this.reader.ReadByte();
            if (number32 == Main.myPlayer && !Main.ServerSideCharacter)
              break;
            if (Main.netMode == 2)
              number32 = this.whoAmI;
            Main.player[number32].anglerQuestsFinished = this.reader.ReadInt32();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(76, ignoreClient: this.whoAmI, number: number32);
            break;
          case 77:
            int type11 = (int) this.reader.ReadInt16();
            ushort num77 = this.reader.ReadUInt16();
            short num78 = this.reader.ReadInt16();
            short num79 = this.reader.ReadInt16();
            int num80 = (int) num77;
            int x3 = (int) num78;
            int y8 = (int) num79;
            Animation.NewTemporaryAnimation(type11, (ushort) num80, x3, y8);
            break;
          case 78:
            if (Main.netMode != 1)
              break;
            Main.ReportInvasionProgress(this.reader.ReadInt32(), this.reader.ReadInt32(), (int) this.reader.ReadSByte(), (int) this.reader.ReadSByte());
            break;
          case 79:
            int x4 = (int) this.reader.ReadInt16();
            int y9 = (int) this.reader.ReadInt16();
            short num81 = this.reader.ReadInt16();
            int style2 = (int) this.reader.ReadInt16();
            int num82 = (int) this.reader.ReadByte();
            int random = (int) this.reader.ReadSByte();
            int direction2 = !this.reader.ReadBoolean() ? -1 : 1;
            if (Main.netMode == 2)
            {
              ++Netplay.Clients[this.whoAmI].SpamAddBlock;
              if (!WorldGen.InWorld(x4, y9, 10) || !Netplay.Clients[this.whoAmI].TileSections[Netplay.GetSectionX(x4), Netplay.GetSectionY(y9)])
                break;
            }
            WorldGen.PlaceObject(x4, y9, (int) num81, style: style2, alternate: num82, random: random, direction: direction2);
            if (Main.netMode != 2)
              break;
            NetMessage.SendObjectPlacment(this.whoAmI, x4, y9, (int) num81, style2, num82, random, direction2);
            break;
          case 80:
            if (Main.netMode != 1)
              break;
            int index39 = (int) this.reader.ReadByte();
            int num83 = (int) this.reader.ReadInt16();
            if (num83 < -3 || num83 >= 1000)
              break;
            Main.player[index39].chest = num83;
            Recipe.FindRecipes();
            break;
          case 81:
            if (Main.netMode != 1)
              break;
            int x5 = (int) this.reader.ReadSingle();
            int num84 = (int) this.reader.ReadSingle();
            Color color5 = this.reader.ReadRGB();
            int amount = this.reader.ReadInt32();
            int y10 = num84;
            CombatText.NewText(new Rectangle(x5, y10, 0, 0), color5, amount);
            break;
          case 82:
            NetManager.Instance.Read(this.reader, this.whoAmI);
            break;
          case 83:
            if (Main.netMode != 1)
              break;
            int index40 = (int) this.reader.ReadInt16();
            int num85 = this.reader.ReadInt32();
            if (index40 < 0 || index40 >= 267)
              break;
            NPC.killCount[index40] = num85;
            break;
          case 84:
            int number33 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number33 = this.whoAmI;
            float num86 = this.reader.ReadSingle();
            Main.player[number33].stealth = num86;
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(84, ignoreClient: this.whoAmI, number: number33);
            break;
          case 85:
            int whoAmI2 = this.whoAmI;
            byte num87 = this.reader.ReadByte();
            if (Main.netMode != 2 || whoAmI2 >= (int) byte.MaxValue || num87 >= (byte) 58)
              break;
            Chest.ServerPlaceItem(this.whoAmI, (int) num87);
            break;
          case 86:
            if (Main.netMode != 1)
              break;
            int key1 = this.reader.ReadInt32();
            if (!this.reader.ReadBoolean())
            {
              TileEntity tileEntity;
              if (!TileEntity.ByID.TryGetValue(key1, out tileEntity))
                break;
              switch (tileEntity)
              {
                case TETrainingDummy _:
                case TEItemFrame _:
                case TELogicSensor _:
                  TileEntity.ByID.Remove(key1);
                  TileEntity.ByPosition.Remove(tileEntity.Position);
                  return;
                default:
                  return;
              }
            }
            else
            {
              TileEntity tileEntity = TileEntity.Read(this.reader, true);
              tileEntity.ID = key1;
              TileEntity.ByID[tileEntity.ID] = tileEntity;
              TileEntity.ByPosition[tileEntity.Position] = tileEntity;
              break;
            }
          case 87:
            if (Main.netMode != 2)
              break;
            int num88 = (int) this.reader.ReadInt16();
            int num89 = (int) this.reader.ReadInt16();
            int type12 = (int) this.reader.ReadByte();
            if (!WorldGen.InWorld(num88, num89) || TileEntity.ByPosition.ContainsKey(new Point16(num88, num89)))
              break;
            TileEntity.PlaceEntityNet(num88, num89, type12);
            break;
          case 88:
            if (Main.netMode != 1)
              break;
            int index41 = (int) this.reader.ReadInt16();
            if (index41 < 0 || index41 > 400)
              break;
            Item obj2 = Main.item[index41];
            BitsByte bitsByte18 = (BitsByte) this.reader.ReadByte();
            if (bitsByte18[0])
              obj2.color.PackedValue = this.reader.ReadUInt32();
            if (bitsByte18[1])
              obj2.damage = (int) this.reader.ReadUInt16();
            if (bitsByte18[2])
              obj2.knockBack = this.reader.ReadSingle();
            if (bitsByte18[3])
              obj2.useAnimation = (int) this.reader.ReadUInt16();
            if (bitsByte18[4])
              obj2.useTime = (int) this.reader.ReadUInt16();
            if (bitsByte18[5])
              obj2.shoot = (int) this.reader.ReadInt16();
            if (bitsByte18[6])
              obj2.shootSpeed = this.reader.ReadSingle();
            if (!bitsByte18[7])
              break;
            bitsByte18 = (BitsByte) this.reader.ReadByte();
            if (bitsByte18[0])
              obj2.width = (int) this.reader.ReadInt16();
            if (bitsByte18[1])
              obj2.height = (int) this.reader.ReadInt16();
            if (bitsByte18[2])
              obj2.scale = this.reader.ReadSingle();
            if (bitsByte18[3])
              obj2.ammo = (int) this.reader.ReadInt16();
            if (bitsByte18[4])
              obj2.useAmmo = (int) this.reader.ReadInt16();
            if (!bitsByte18[5])
              break;
            obj2.notAmmo = this.reader.ReadBoolean();
            break;
          case 89:
            if (Main.netMode != 2)
              break;
            int x6 = (int) this.reader.ReadInt16();
            int num90 = (int) this.reader.ReadInt16();
            int num91 = (int) this.reader.ReadInt16();
            int num92 = (int) this.reader.ReadByte();
            int num93 = (int) this.reader.ReadInt16();
            int y11 = num90;
            int netid = num91;
            int prefix = num92;
            int stack1 = num93;
            TEItemFrame.TryPlacing(x6, y11, netid, prefix, stack1);
            break;
          case 91:
            if (Main.netMode != 1)
              break;
            int key2 = this.reader.ReadInt32();
            int type13 = (int) this.reader.ReadByte();
            if (type13 == (int) byte.MaxValue)
            {
              if (!EmoteBubble.byID.ContainsKey(key2))
                break;
              EmoteBubble.byID.Remove(key2);
              break;
            }
            int meta = (int) this.reader.ReadUInt16();
            int time2 = (int) this.reader.ReadByte();
            int emotion = (int) this.reader.ReadByte();
            int num94 = 0;
            if (emotion < 0)
              num94 = (int) this.reader.ReadInt16();
            WorldUIAnchor bubbleAnchor = EmoteBubble.DeserializeNetAnchor(type13, meta);
            lock (EmoteBubble.byID)
            {
              if (!EmoteBubble.byID.ContainsKey(key2))
              {
                EmoteBubble.byID[key2] = new EmoteBubble(emotion, bubbleAnchor, time2);
              }
              else
              {
                EmoteBubble.byID[key2].lifeTime = time2;
                EmoteBubble.byID[key2].lifeTimeStart = time2;
                EmoteBubble.byID[key2].emote = emotion;
                EmoteBubble.byID[key2].anchor = bubbleAnchor;
              }
              EmoteBubble.byID[key2].ID = key2;
              EmoteBubble.byID[key2].metadata = num94;
              break;
            }
          case 92:
            int number34 = (int) this.reader.ReadInt16();
            float num95 = this.reader.ReadSingle();
            float num96 = this.reader.ReadSingle();
            float num97 = this.reader.ReadSingle();
            if (number34 < 0 || number34 > 200)
              break;
            if (Main.netMode == 1)
            {
              Main.npc[number34].moneyPing(new Vector2(num96, num97));
              Main.npc[number34].extraValue = num95;
              break;
            }
            Main.npc[number34].extraValue += num95;
            NetMessage.SendData(92, number: number34, number2: Main.npc[number34].extraValue, number3: num96, number4: num97);
            break;
          case 95:
            ushort num98 = this.reader.ReadUInt16();
            if (Main.netMode != 2 || num98 < (ushort) 0 || num98 >= (ushort) 1000)
              break;
            Projectile projectile2 = Main.projectile[(int) num98];
            if (projectile2.type != 602)
              break;
            projectile2.Kill();
            NetMessage.SendData(29, number: projectile2.whoAmI, number2: ((float) projectile2.owner));
            break;
          case 96:
            int index42 = (int) this.reader.ReadByte();
            Player player15 = Main.player[index42];
            int extraInfo1 = (int) this.reader.ReadInt16();
            Vector2 newPos1 = this.reader.ReadVector2();
            Vector2 vector2_9 = this.reader.ReadVector2();
            player15.lastPortalColorIndex = extraInfo1 + (extraInfo1 % 2 == 0 ? 1 : -1);
            player15.Teleport(newPos1, 4, extraInfo1);
            player15.velocity = vector2_9;
            break;
          case 97:
            if (Main.netMode != 1)
              break;
            AchievementsHelper.NotifyNPCKilledDirect(Main.player[Main.myPlayer], (int) this.reader.ReadInt16());
            break;
          case 98:
            if (Main.netMode != 1)
              break;
            AchievementsHelper.NotifyProgressionEvent((int) this.reader.ReadInt16());
            break;
          case 99:
            int number35 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number35 = this.whoAmI;
            Main.player[number35].MinionRestTargetPoint = this.reader.ReadVector2();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(99, ignoreClient: this.whoAmI, number: number35);
            break;
          case 100:
            int index43 = (int) this.reader.ReadUInt16();
            NPC npc3 = Main.npc[index43];
            int extraInfo2 = (int) this.reader.ReadInt16();
            Vector2 newPos2 = this.reader.ReadVector2();
            Vector2 vector2_10 = this.reader.ReadVector2();
            npc3.lastPortalColorIndex = extraInfo2 + (extraInfo2 % 2 == 0 ? 1 : -1);
            npc3.Teleport(newPos2, 4, extraInfo2);
            npc3.velocity = vector2_10;
            break;
          case 101:
            if (Main.netMode == 2)
              break;
            NPC.ShieldStrengthTowerSolar = (int) this.reader.ReadUInt16();
            NPC.ShieldStrengthTowerVortex = (int) this.reader.ReadUInt16();
            NPC.ShieldStrengthTowerNebula = (int) this.reader.ReadUInt16();
            NPC.ShieldStrengthTowerStardust = (int) this.reader.ReadUInt16();
            if (NPC.ShieldStrengthTowerSolar < 0)
              NPC.ShieldStrengthTowerSolar = 0;
            if (NPC.ShieldStrengthTowerVortex < 0)
              NPC.ShieldStrengthTowerVortex = 0;
            if (NPC.ShieldStrengthTowerNebula < 0)
              NPC.ShieldStrengthTowerNebula = 0;
            if (NPC.ShieldStrengthTowerStardust < 0)
              NPC.ShieldStrengthTowerStardust = 0;
            if (NPC.ShieldStrengthTowerSolar > NPC.LunarShieldPowerExpert)
              NPC.ShieldStrengthTowerSolar = NPC.LunarShieldPowerExpert;
            if (NPC.ShieldStrengthTowerVortex > NPC.LunarShieldPowerExpert)
              NPC.ShieldStrengthTowerVortex = NPC.LunarShieldPowerExpert;
            if (NPC.ShieldStrengthTowerNebula > NPC.LunarShieldPowerExpert)
              NPC.ShieldStrengthTowerNebula = NPC.LunarShieldPowerExpert;
            if (NPC.ShieldStrengthTowerStardust <= NPC.LunarShieldPowerExpert)
              break;
            NPC.ShieldStrengthTowerStardust = NPC.LunarShieldPowerExpert;
            break;
          case 102:
            int index44 = (int) this.reader.ReadByte();
            byte num99 = this.reader.ReadByte();
            Vector2 Other = this.reader.ReadVector2();
            if (Main.netMode == 2)
            {
              NetMessage.SendData(102, number: this.whoAmI, number2: ((float) num99), number3: Other.X, number4: Other.Y);
              break;
            }
            Player player16 = Main.player[index44];
            for (int index45 = 0; index45 < (int) byte.MaxValue; ++index45)
            {
              Player player17 = Main.player[index45];
              if (player17.active && !player17.dead && (player16.team == 0 || player16.team == player17.team) && (double) player17.Distance(Other) < 700.0)
              {
                Vector2 vector2_11 = player16.Center - player17.Center;
                Vector2 vec = Vector2.Normalize(vector2_11);
                if (!vec.HasNaNs())
                {
                  int num100 = 90;
                  float num101 = 0.0f;
                  float num102 = 0.2094395f;
                  Vector2 spinningpoint = new Vector2(0.0f, -8f);
                  Vector2 vector2_12 = new Vector2(-3f);
                  float num103 = 0.0f;
                  float num104 = 0.005f;
                  switch (num99)
                  {
                    case 173:
                      num100 = 90;
                      break;
                    case 176:
                      num100 = 88;
                      break;
                    case 179:
                      num100 = 86;
                      break;
                  }
                  for (int index46 = 0; (double) index46 < (double) vector2_11.Length() / 6.0; ++index46)
                  {
                    Vector2 Position = player17.Center + 6f * (float) index46 * vec + spinningpoint.RotatedBy((double) num101) + vector2_12;
                    num101 += num102;
                    int Type5 = num100;
                    Color newColor = new Color();
                    int index47 = Dust.NewDust(Position, 6, 6, Type5, Alpha: 100, newColor: newColor, Scale: 1.5f);
                    Main.dust[index47].noGravity = true;
                    Main.dust[index47].velocity = Vector2.Zero;
                    Main.dust[index47].fadeIn = (num103 += num104);
                    Main.dust[index47].velocity += vec * 1.5f;
                  }
                }
                player17.NebulaLevelup((int) num99);
              }
            }
            break;
          case 103:
            if (Main.netMode != 1)
              break;
            NPC.MoonLordCountdown = this.reader.ReadInt32();
            break;
          case 104:
            if (Main.netMode != 1 || Main.npcShop <= 0)
              break;
            Item[] objArray1 = Main.instance.shop[Main.npcShop].item;
            int index48 = (int) this.reader.ReadByte();
            int type14 = (int) this.reader.ReadInt16();
            int num105 = (int) this.reader.ReadInt16();
            int pre3 = (int) this.reader.ReadByte();
            int num106 = this.reader.ReadInt32();
            BitsByte bitsByte19 = (BitsByte) this.reader.ReadByte();
            if (index48 >= objArray1.Length)
              break;
            objArray1[index48] = new Item();
            objArray1[index48].netDefaults(type14);
            objArray1[index48].stack = num105;
            objArray1[index48].Prefix(pre3);
            objArray1[index48].value = num106;
            objArray1[index48].buyOnce = bitsByte19[0];
            break;
          case 105:
            if (Main.netMode == 1)
              break;
            int i3 = (int) this.reader.ReadInt16();
            int num107 = (int) this.reader.ReadInt16();
            bool flag9 = this.reader.ReadBoolean();
            int j3 = num107;
            int num108 = flag9 ? 1 : 0;
            WorldGen.ToggleGemLock(i3, j3, num108 != 0);
            break;
          case 106:
            if (Main.netMode != 1)
              break;
            Utils.PoofOfSmoke(new HalfVector2()
            {
              PackedValue = this.reader.ReadUInt32()
            }.ToVector2());
            break;
          case 107:
            if (Main.netMode != 1)
              break;
            Color color6 = this.reader.ReadRGB();
            string text2 = NetworkText.Deserialize(this.reader).ToString();
            int num109 = (int) this.reader.ReadInt16();
            Color c = color6;
            int WidthLimit = num109;
            Main.NewTextMultiline(text2, c: c, WidthLimit: WidthLimit);
            break;
          case 108:
            if (Main.netMode != 1)
              break;
            int Damage2 = (int) this.reader.ReadInt16();
            float KnockBack = this.reader.ReadSingle();
            int x7 = (int) this.reader.ReadInt16();
            int y12 = (int) this.reader.ReadInt16();
            int angle = (int) this.reader.ReadInt16();
            int ammo = (int) this.reader.ReadInt16();
            int owner = (int) this.reader.ReadByte();
            if (owner != Main.myPlayer)
              break;
            WorldGen.ShootFromCannon(x7, y12, angle, ammo, Damage2, KnockBack, owner);
            break;
          case 109:
            if (Main.netMode != 2)
              break;
            int x8 = (int) this.reader.ReadInt16();
            int num110 = (int) this.reader.ReadInt16();
            int x9 = (int) this.reader.ReadInt16();
            int y13 = (int) this.reader.ReadInt16();
            int num111 = (int) this.reader.ReadByte();
            int whoAmI3 = this.whoAmI;
            WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
            WiresUI.Settings.ToolMode = (WiresUI.Settings.MultiToolMode) num111;
            int y14 = num110;
            Wiring.MassWireOperation(new Point(x8, y14), new Point(x9, y13), Main.player[whoAmI3]);
            WiresUI.Settings.ToolMode = toolMode;
            break;
          case 110:
            if (Main.netMode != 1)
              break;
            int type15 = (int) this.reader.ReadInt16();
            int num112 = (int) this.reader.ReadInt16();
            int index49 = (int) this.reader.ReadByte();
            if (index49 != Main.myPlayer)
              break;
            Player player18 = Main.player[index49];
            for (int index50 = 0; index50 < num112; ++index50)
              player18.ConsumeItem(type15);
            player18.wireOperationsCooldown = 0;
            break;
          case 111:
            if (Main.netMode != 2)
              break;
            BirthdayParty.ToggleManualParty();
            break;
          case 112:
            int number36 = (int) this.reader.ReadByte();
            int x10 = (int) this.reader.ReadInt16();
            int y15 = (int) this.reader.ReadInt16();
            int height = (int) this.reader.ReadByte();
            int num113 = (int) this.reader.ReadInt16();
            if (number36 != 1)
              break;
            if (Main.netMode == 1)
              WorldGen.TreeGrowFX(x10, y15, height, num113);
            if (Main.netMode != 2)
              break;
            NetMessage.SendData((int) num1, number: number36, number2: ((float) x10), number3: ((float) y15), number4: ((float) height), number5: num113);
            break;
          case 113:
            int x11 = (int) this.reader.ReadInt16();
            int y16 = (int) this.reader.ReadInt16();
            if (Main.netMode != 2 || Main.snowMoon || Main.pumpkinMoon)
              break;
            if (DD2Event.WouldFailSpawningHere(x11, y16))
              DD2Event.FailureMessage(this.whoAmI);
            DD2Event.SummonCrystal(x11, y16);
            break;
          case 114:
            if (Main.netMode != 1)
              break;
            DD2Event.WipeEntities();
            break;
          case 115:
            int number37 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              number37 = this.whoAmI;
            Main.player[number37].MinionAttackTargetNPC = (int) this.reader.ReadInt16();
            if (Main.netMode != 2)
              break;
            NetMessage.SendData(115, ignoreClient: this.whoAmI, number: number37);
            break;
          case 116:
            if (Main.netMode != 1)
              break;
            DD2Event.TimeLeftBetweenWaves = this.reader.ReadInt32();
            break;
          case 117:
            int playerTargetIndex1 = (int) this.reader.ReadByte();
            if (Main.netMode == 2 && this.whoAmI != playerTargetIndex1 && (!Main.player[playerTargetIndex1].hostile || !Main.player[this.whoAmI].hostile))
              break;
            PlayerDeathReason playerDeathReason1 = PlayerDeathReason.FromReader(this.reader);
            int num114 = (int) this.reader.ReadInt16();
            int num115 = (int) this.reader.ReadByte() - 1;
            BitsByte bitsByte20 = (BitsByte) this.reader.ReadByte();
            bool flag10 = bitsByte20[0];
            bool pvp1 = bitsByte20[1];
            int num116 = (int) this.reader.ReadSByte();
            Main.player[playerTargetIndex1].Hurt(playerDeathReason1, num114, num115, pvp1, true, flag10, num116);
            if (Main.netMode != 2)
              break;
            NetMessage.SendPlayerHurt(playerTargetIndex1, playerDeathReason1, num114, num115, flag10, pvp1, num116, ignoreClient: this.whoAmI);
            break;
          case 118:
            int playerTargetIndex2 = (int) this.reader.ReadByte();
            if (Main.netMode == 2)
              playerTargetIndex2 = this.whoAmI;
            PlayerDeathReason playerDeathReason2 = PlayerDeathReason.FromReader(this.reader);
            int damage = (int) this.reader.ReadInt16();
            int num117 = (int) this.reader.ReadByte() - 1;
            bool pvp2 = ((BitsByte) this.reader.ReadByte())[0];
            Main.player[playerTargetIndex2].KillMe(playerDeathReason2, (double) damage, num117, pvp2);
            if (Main.netMode != 2)
              break;
            NetMessage.SendPlayerDeath(playerTargetIndex2, playerDeathReason2, damage, num117, pvp2, ignoreClient: this.whoAmI);
            break;
          case 119:
            if (Main.netMode != 1)
              break;
            int x12 = (int) this.reader.ReadSingle();
            int num118 = (int) this.reader.ReadSingle();
            Color color7 = this.reader.ReadRGB();
            NetworkText networkText = NetworkText.Deserialize(this.reader);
            int y17 = num118;
            CombatText.NewText(new Rectangle(x12, y17, 0, 0), color7, networkText.ToString());
            break;
        }
      }
    }
  }
}
