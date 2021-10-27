// Decompiled with JetBrains decompiler
// Type: Terraria.NetMessage
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Ionic.Zlib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.IO;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;

namespace Terraria
{
  public class NetMessage
  {
    public static MessageBuffer[] buffer = new MessageBuffer[257];
    private static PlayerDeathReason _currentPlayerDeathReason;

    public static void SendChatMessageToClient(NetworkText text, Color color, int playerId)
    {
      NetPacket packet = NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
      NetManager.Instance.SendToClient(packet, playerId);
    }

    public static void BroadcastChatMessage(NetworkText text, Color color, int excludedPlayer = -1)
    {
      NetPacket packet = NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
      NetManager.Instance.Broadcast(packet, excludedPlayer);
    }

    public static void SendChatMessageFromClient(ChatMessage text)
    {
      NetPacket packet = NetTextModule.SerializeClientMessage(text);
      NetManager.Instance.SendToServer(packet);
    }

    public static void SendData(
      int msgType,
      int remoteClient = -1,
      int ignoreClient = -1,
      NetworkText text = null,
      int number = 0,
      float number2 = 0.0f,
      float number3 = 0.0f,
      float number4 = 0.0f,
      int number5 = 0,
      int number6 = 0,
      int number7 = 0)
    {
      if (Main.netMode == 0)
        return;
      int whoAmi = 256;
      if (text == null)
        text = NetworkText.Empty;
      if (Main.netMode == 2 && remoteClient >= 0)
        whoAmi = remoteClient;
      lock (NetMessage.buffer[whoAmi])
      {
        BinaryWriter writer = NetMessage.buffer[whoAmi].writer;
        if (writer == null)
        {
          NetMessage.buffer[whoAmi].ResetWriter();
          writer = NetMessage.buffer[whoAmi].writer;
        }
        writer.BaseStream.Position = 0L;
        long position1 = writer.BaseStream.Position;
        writer.BaseStream.Position += 2L;
        writer.Write((byte) msgType);
        switch (msgType)
        {
          case 1:
            writer.Write("Terraria" + (object) 194);
            break;
          case 2:
            text.Serialize(writer);
            if (Main.dedServ)
            {
              Console.WriteLine(Language.GetTextValue("CLI.ClientWasBooted", (object) Netplay.Clients[whoAmi].Socket.GetRemoteAddress().ToString(), (object) text));
              break;
            }
            break;
          case 3:
            writer.Write((byte) remoteClient);
            break;
          case 4:
            Player player1 = Main.player[number];
            writer.Write((byte) number);
            writer.Write((byte) player1.skinVariant);
            writer.Write((byte) player1.hair);
            writer.Write(player1.name);
            writer.Write(player1.hairDye);
            BitsByte bitsByte1 = (BitsByte) (byte) 0;
            for (int key = 0; key < 8; ++key)
              bitsByte1[key] = player1.hideVisual[key];
            writer.Write((byte) bitsByte1);
            BitsByte bitsByte2 = (BitsByte) (byte) 0;
            for (int key = 0; key < 2; ++key)
              bitsByte2[key] = player1.hideVisual[key + 8];
            writer.Write((byte) bitsByte2);
            writer.Write((byte) player1.hideMisc);
            writer.WriteRGB(player1.hairColor);
            writer.WriteRGB(player1.skinColor);
            writer.WriteRGB(player1.eyeColor);
            writer.WriteRGB(player1.shirtColor);
            writer.WriteRGB(player1.underShirtColor);
            writer.WriteRGB(player1.pantsColor);
            writer.WriteRGB(player1.shoeColor);
            BitsByte bitsByte3 = (BitsByte) (byte) 0;
            if (player1.difficulty == (byte) 1)
              bitsByte3[0] = true;
            else if (player1.difficulty == (byte) 2)
              bitsByte3[1] = true;
            bitsByte3[2] = player1.extraAccessory;
            writer.Write((byte) bitsByte3);
            break;
          case 5:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            Player player2 = Main.player[number];
            Item obj1 = (double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length + 1) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length) ? ((double) number2 <= 58.0 ? player2.inventory[(int) number2] : player2.armor[(int) number2 - 58 - 1]) : player2.dye[(int) number2 - 58 - player2.armor.Length - 1]) : player2.miscEquips[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length) - 1]) : player2.miscDyes[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length) - 1]) : player2.bank.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length) - 1]) : player2.bank2.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length) - 1]) : player2.trashItem) : player2.bank3.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length + 1) - 1];
            if (obj1.Name == "" || obj1.stack == 0 || obj1.type == 0)
              obj1.SetDefaults();
            int num1 = obj1.stack;
            int netId1 = obj1.netID;
            if (num1 < 0)
              num1 = 0;
            writer.Write((short) num1);
            writer.Write((byte) number3);
            writer.Write((short) netId1);
            break;
          case 7:
            writer.Write((int) Main.time);
            BitsByte bitsByte4 = (BitsByte) (byte) 0;
            bitsByte4[0] = Main.dayTime;
            bitsByte4[1] = Main.bloodMoon;
            bitsByte4[2] = Main.eclipse;
            writer.Write((byte) bitsByte4);
            writer.Write((byte) Main.moonPhase);
            writer.Write((short) Main.maxTilesX);
            writer.Write((short) Main.maxTilesY);
            writer.Write((short) Main.spawnTileX);
            writer.Write((short) Main.spawnTileY);
            writer.Write((short) Main.worldSurface);
            writer.Write((short) Main.rockLayer);
            writer.Write(Main.worldID);
            writer.Write(Main.worldName);
            writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
            writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
            writer.Write((byte) Main.moonType);
            writer.Write((byte) WorldGen.treeBG);
            writer.Write((byte) WorldGen.corruptBG);
            writer.Write((byte) WorldGen.jungleBG);
            writer.Write((byte) WorldGen.snowBG);
            writer.Write((byte) WorldGen.hallowBG);
            writer.Write((byte) WorldGen.crimsonBG);
            writer.Write((byte) WorldGen.desertBG);
            writer.Write((byte) WorldGen.oceanBG);
            writer.Write((byte) Main.iceBackStyle);
            writer.Write((byte) Main.jungleBackStyle);
            writer.Write((byte) Main.hellBackStyle);
            writer.Write(Main.windSpeedSet);
            writer.Write((byte) Main.numClouds);
            for (int index = 0; index < 3; ++index)
              writer.Write(Main.treeX[index]);
            for (int index = 0; index < 4; ++index)
              writer.Write((byte) Main.treeStyle[index]);
            for (int index = 0; index < 3; ++index)
              writer.Write(Main.caveBackX[index]);
            for (int index = 0; index < 4; ++index)
              writer.Write((byte) Main.caveBackStyle[index]);
            if (!Main.raining)
              Main.maxRaining = 0.0f;
            writer.Write(Main.maxRaining);
            BitsByte bitsByte5 = (BitsByte) (byte) 0;
            bitsByte5[0] = WorldGen.shadowOrbSmashed;
            bitsByte5[1] = NPC.downedBoss1;
            bitsByte5[2] = NPC.downedBoss2;
            bitsByte5[3] = NPC.downedBoss3;
            bitsByte5[4] = Main.hardMode;
            bitsByte5[5] = NPC.downedClown;
            bitsByte5[7] = NPC.downedPlantBoss;
            writer.Write((byte) bitsByte5);
            BitsByte bitsByte6 = (BitsByte) (byte) 0;
            bitsByte6[0] = NPC.downedMechBoss1;
            bitsByte6[1] = NPC.downedMechBoss2;
            bitsByte6[2] = NPC.downedMechBoss3;
            bitsByte6[3] = NPC.downedMechBossAny;
            bitsByte6[4] = (double) Main.cloudBGActive >= 1.0;
            bitsByte6[5] = WorldGen.crimson;
            bitsByte6[6] = Main.pumpkinMoon;
            bitsByte6[7] = Main.snowMoon;
            writer.Write((byte) bitsByte6);
            BitsByte bitsByte7 = (BitsByte) (byte) 0;
            bitsByte7[0] = Main.expertMode;
            bitsByte7[1] = Main.fastForwardTime;
            bitsByte7[2] = Main.slimeRain;
            bitsByte7[3] = NPC.downedSlimeKing;
            bitsByte7[4] = NPC.downedQueenBee;
            bitsByte7[5] = NPC.downedFishron;
            bitsByte7[6] = NPC.downedMartians;
            bitsByte7[7] = NPC.downedAncientCultist;
            writer.Write((byte) bitsByte7);
            BitsByte bitsByte8 = (BitsByte) (byte) 0;
            bitsByte8[0] = NPC.downedMoonlord;
            bitsByte8[1] = NPC.downedHalloweenKing;
            bitsByte8[2] = NPC.downedHalloweenTree;
            bitsByte8[3] = NPC.downedChristmasIceQueen;
            bitsByte8[4] = NPC.downedChristmasSantank;
            bitsByte8[5] = NPC.downedChristmasTree;
            bitsByte8[6] = NPC.downedGolemBoss;
            bitsByte8[7] = BirthdayParty.PartyIsUp;
            writer.Write((byte) bitsByte8);
            BitsByte bitsByte9 = (BitsByte) (byte) 0;
            bitsByte9[0] = NPC.downedPirates;
            bitsByte9[1] = NPC.downedFrost;
            bitsByte9[2] = NPC.downedGoblins;
            bitsByte9[3] = Sandstorm.Happening;
            bitsByte9[4] = DD2Event.Ongoing;
            bitsByte9[5] = DD2Event.DownedInvasionT1;
            bitsByte9[6] = DD2Event.DownedInvasionT2;
            bitsByte9[7] = DD2Event.DownedInvasionT3;
            writer.Write((byte) bitsByte9);
            writer.Write((sbyte) Main.invasionType);
            if (SocialAPI.Network != null)
              writer.Write(SocialAPI.Network.GetLobbyId());
            else
              writer.Write(0UL);
            writer.Write(Sandstorm.IntendedSeverity);
            break;
          case 8:
            writer.Write(number);
            writer.Write((int) number2);
            break;
          case 9:
            writer.Write(number);
            text.Serialize(writer);
            break;
          case 10:
            int num2 = NetMessage.CompressTileBlock(number, (int) number2, (short) number3, (short) number4, NetMessage.buffer[whoAmi].writeBuffer, (int) writer.BaseStream.Position);
            writer.BaseStream.Position += (long) num2;
            break;
          case 11:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            break;
          case 12:
            writer.Write((byte) number);
            writer.Write((short) Main.player[number].SpawnX);
            writer.Write((short) Main.player[number].SpawnY);
            break;
          case 13:
            Player player3 = Main.player[number];
            writer.Write((byte) number);
            BitsByte bitsByte10 = (BitsByte) (byte) 0;
            bitsByte10[0] = player3.controlUp;
            bitsByte10[1] = player3.controlDown;
            bitsByte10[2] = player3.controlLeft;
            bitsByte10[3] = player3.controlRight;
            bitsByte10[4] = player3.controlJump;
            bitsByte10[5] = player3.controlUseItem;
            bitsByte10[6] = player3.direction == 1;
            writer.Write((byte) bitsByte10);
            BitsByte bitsByte11 = (BitsByte) (byte) 0;
            bitsByte11[0] = player3.pulley;
            bitsByte11[1] = player3.pulley && player3.pulleyDir == (byte) 2;
            bitsByte11[2] = player3.velocity != Vector2.Zero;
            bitsByte11[3] = player3.vortexStealthActive;
            bitsByte11[4] = (double) player3.gravDir == 1.0;
            bitsByte11[5] = player3.shieldRaised;
            writer.Write((byte) bitsByte11);
            writer.Write((byte) player3.selectedItem);
            writer.WriteVector2(player3.position);
            if (bitsByte11[2])
            {
              writer.WriteVector2(player3.velocity);
              break;
            }
            break;
          case 14:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            break;
          case 16:
            writer.Write((byte) number);
            writer.Write((short) Main.player[number].statLife);
            writer.Write((short) Main.player[number].statLifeMax);
            break;
          case 17:
            writer.Write((byte) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            writer.Write((byte) number5);
            break;
          case 18:
            writer.Write(Main.dayTime ? (byte) 1 : (byte) 0);
            writer.Write((int) Main.time);
            writer.Write(Main.sunModY);
            writer.Write(Main.moonModY);
            break;
          case 19:
            writer.Write((byte) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((double) number4 == 1.0 ? (byte) 1 : (byte) 0);
            break;
          case 20:
            int num3 = number;
            int num4 = (int) number2;
            int num5 = (int) number3;
            if (num3 < 0)
              num3 = 0;
            if (num4 < num3)
              num4 = num3;
            if (num4 >= Main.maxTilesX + num3)
              num4 = Main.maxTilesX - num3 - 1;
            if (num5 < num3)
              num5 = num3;
            if (num5 >= Main.maxTilesY + num3)
              num5 = Main.maxTilesY - num3 - 1;
            if (number5 == 0)
            {
              writer.Write((ushort) (num3 & (int) short.MaxValue));
            }
            else
            {
              writer.Write((ushort) (num3 & (int) short.MaxValue | 32768));
              writer.Write((byte) number5);
            }
            writer.Write((short) num4);
            writer.Write((short) num5);
            for (int index1 = num4; index1 < num4 + num3; ++index1)
            {
              for (int index2 = num5; index2 < num5 + num3; ++index2)
              {
                BitsByte bitsByte12 = (BitsByte) (byte) 0;
                BitsByte bitsByte13 = (BitsByte) (byte) 0;
                byte num6 = 0;
                byte num7 = 0;
                Tile tile = Main.tile[index1, index2];
                bitsByte12[0] = tile.active();
                bitsByte12[2] = tile.wall > (byte) 0;
                bitsByte12[3] = tile.liquid > (byte) 0 && Main.netMode == 2;
                bitsByte12[4] = tile.wire();
                bitsByte12[5] = tile.halfBrick();
                bitsByte12[6] = tile.actuator();
                bitsByte12[7] = tile.inActive();
                bitsByte13[0] = tile.wire2();
                bitsByte13[1] = tile.wire3();
                if (tile.active() && tile.color() > (byte) 0)
                {
                  bitsByte13[2] = true;
                  num6 = tile.color();
                }
                if (tile.wall > (byte) 0 && tile.wallColor() > (byte) 0)
                {
                  bitsByte13[3] = true;
                  num7 = tile.wallColor();
                }
                bitsByte13 = (BitsByte) (byte) ((uint) (byte) bitsByte13 + (uint) (byte) ((uint) tile.slope() << 4));
                bitsByte13[7] = tile.wire4();
                writer.Write((byte) bitsByte12);
                writer.Write((byte) bitsByte13);
                if (num6 > (byte) 0)
                  writer.Write(num6);
                if (num7 > (byte) 0)
                  writer.Write(num7);
                if (tile.active())
                {
                  writer.Write(tile.type);
                  if (Main.tileFrameImportant[(int) tile.type])
                  {
                    writer.Write(tile.frameX);
                    writer.Write(tile.frameY);
                  }
                }
                if (tile.wall > (byte) 0)
                  writer.Write(tile.wall);
                if (tile.liquid > (byte) 0 && Main.netMode == 2)
                {
                  writer.Write(tile.liquid);
                  writer.Write(tile.liquidType());
                }
              }
            }
            break;
          case 21:
          case 90:
            Item obj2 = Main.item[number];
            writer.Write((short) number);
            writer.WriteVector2(obj2.position);
            writer.WriteVector2(obj2.velocity);
            writer.Write((short) obj2.stack);
            writer.Write(obj2.prefix);
            writer.Write((byte) number2);
            short num8 = 0;
            if (obj2.active && obj2.stack > 0)
              num8 = (short) obj2.netID;
            writer.Write(num8);
            break;
          case 22:
            writer.Write((short) number);
            writer.Write((byte) Main.item[number].owner);
            break;
          case 23:
            NPC npc1 = Main.npc[number];
            writer.Write((short) number);
            writer.WriteVector2(npc1.position);
            writer.WriteVector2(npc1.velocity);
            writer.Write((ushort) npc1.target);
            int num9 = npc1.life;
            if (!npc1.active)
              num9 = 0;
            if (!npc1.active || npc1.life <= 0)
              npc1.netSkip = 0;
            short netId2 = (short) npc1.netID;
            bool[] flagArray = new bool[4];
            BitsByte bitsByte14 = (BitsByte) (byte) 0;
            bitsByte14[0] = npc1.direction > 0;
            bitsByte14[1] = npc1.directionY > 0;
            bitsByte14[2] = flagArray[0] = (double) npc1.ai[0] != 0.0;
            bitsByte14[3] = flagArray[1] = (double) npc1.ai[1] != 0.0;
            bitsByte14[4] = flagArray[2] = (double) npc1.ai[2] != 0.0;
            bitsByte14[5] = flagArray[3] = (double) npc1.ai[3] != 0.0;
            bitsByte14[6] = npc1.spriteDirection > 0;
            bitsByte14[7] = num9 == npc1.lifeMax;
            writer.Write((byte) bitsByte14);
            for (int index = 0; index < NPC.maxAI; ++index)
            {
              if (flagArray[index])
                writer.Write(npc1.ai[index]);
            }
            writer.Write(netId2);
            if (!bitsByte14[7])
            {
              byte npcLifeByte = Main.npcLifeBytes[npc1.netID];
              writer.Write(npcLifeByte);
              switch (npcLifeByte)
              {
                case 2:
                  writer.Write((short) num9);
                  break;
                case 4:
                  writer.Write(num9);
                  break;
                default:
                  writer.Write((sbyte) num9);
                  break;
              }
            }
            if (npc1.type >= 0 && npc1.type < 580 && Main.npcCatchable[npc1.type])
            {
              writer.Write((byte) npc1.releaseOwner);
              break;
            }
            break;
          case 24:
            writer.Write((short) number);
            writer.Write((byte) number2);
            break;
          case 27:
            Projectile projectile1 = Main.projectile[number];
            writer.Write((short) projectile1.identity);
            writer.WriteVector2(projectile1.position);
            writer.WriteVector2(projectile1.velocity);
            writer.Write(projectile1.knockBack);
            writer.Write((short) projectile1.damage);
            writer.Write((byte) projectile1.owner);
            writer.Write((short) projectile1.type);
            BitsByte bitsByte15 = (BitsByte) (byte) 0;
            for (int key = 0; key < Projectile.maxAI; ++key)
            {
              if ((double) projectile1.ai[key] != 0.0)
                bitsByte15[key] = true;
            }
            if (projectile1.type > 0 && projectile1.type < 714 && ProjectileID.Sets.NeedsUUID[projectile1.type])
              bitsByte15[Projectile.maxAI] = true;
            writer.Write((byte) bitsByte15);
            for (int key = 0; key < Projectile.maxAI; ++key)
            {
              if (bitsByte15[key])
                writer.Write(projectile1.ai[key]);
            }
            if (bitsByte15[Projectile.maxAI])
            {
              writer.Write((short) projectile1.projUUID);
              break;
            }
            break;
          case 28:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write(number3);
            writer.Write((byte) ((double) number4 + 1.0));
            writer.Write((byte) number5);
            break;
          case 29:
            writer.Write((short) number);
            writer.Write((byte) number2);
            break;
          case 30:
            writer.Write((byte) number);
            writer.Write(Main.player[number].hostile);
            break;
          case 31:
            writer.Write((short) number);
            writer.Write((short) number2);
            break;
          case 32:
            Item obj3 = Main.chest[number].item[(int) (byte) number2];
            writer.Write((short) number);
            writer.Write((byte) number2);
            short num10 = (short) obj3.netID;
            if (obj3.Name == null)
              num10 = (short) 0;
            writer.Write((short) obj3.stack);
            writer.Write(obj3.prefix);
            writer.Write(num10);
            break;
          case 33:
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            string str1 = (string) null;
            if (number > -1)
            {
              num11 = Main.chest[number].x;
              num12 = Main.chest[number].y;
            }
            if ((double) number2 == 1.0)
            {
              string str2 = text.ToString();
              num13 = (int) (byte) str2.Length;
              if (num13 == 0 || num13 > 20)
                num13 = (int) byte.MaxValue;
              else
                str1 = str2;
            }
            writer.Write((short) number);
            writer.Write((short) num11);
            writer.Write((short) num12);
            writer.Write((byte) num13);
            if (str1 != null)
            {
              writer.Write(str1);
              break;
            }
            break;
          case 34:
            writer.Write((byte) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            if (Main.netMode == 2)
            {
              Netplay.GetSectionX((int) number2);
              Netplay.GetSectionY((int) number3);
              writer.Write((short) number5);
              break;
            }
            writer.Write((short) 0);
            break;
          case 35:
          case 66:
            writer.Write((byte) number);
            writer.Write((short) number2);
            break;
          case 36:
            Player player4 = Main.player[number];
            writer.Write((byte) number);
            writer.Write((byte) player4.zone1);
            writer.Write((byte) player4.zone2);
            writer.Write((byte) player4.zone3);
            writer.Write((byte) player4.zone4);
            break;
          case 38:
            writer.Write(Netplay.ServerPassword);
            break;
          case 39:
            writer.Write((short) number);
            break;
          case 40:
            writer.Write((byte) number);
            writer.Write((short) Main.player[number].talkNPC);
            break;
          case 41:
            writer.Write((byte) number);
            writer.Write(Main.player[number].itemRotation);
            writer.Write((short) Main.player[number].itemAnimation);
            break;
          case 42:
            writer.Write((byte) number);
            writer.Write((short) Main.player[number].statMana);
            writer.Write((short) Main.player[number].statManaMax);
            break;
          case 43:
            writer.Write((byte) number);
            writer.Write((short) number2);
            break;
          case 45:
            writer.Write((byte) number);
            writer.Write((byte) Main.player[number].team);
            break;
          case 46:
            writer.Write((short) number);
            writer.Write((short) number2);
            break;
          case 47:
            writer.Write((short) number);
            writer.Write((short) Main.sign[number].x);
            writer.Write((short) Main.sign[number].y);
            writer.Write(Main.sign[number].text);
            writer.Write((byte) number2);
            break;
          case 48:
            Tile tile1 = Main.tile[number, (int) number2];
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write(tile1.liquid);
            writer.Write(tile1.liquidType());
            break;
          case 50:
            writer.Write((byte) number);
            for (int index = 0; index < 22; ++index)
              writer.Write((byte) Main.player[number].buffType[index]);
            break;
          case 51:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            break;
          case 52:
            writer.Write((byte) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            break;
          case 53:
            writer.Write((short) number);
            writer.Write((byte) number2);
            writer.Write((short) number3);
            break;
          case 54:
            writer.Write((short) number);
            for (int index = 0; index < 5; ++index)
            {
              writer.Write((byte) Main.npc[number].buffType[index]);
              writer.Write((short) Main.npc[number].buffTime[index]);
            }
            break;
          case 55:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            writer.Write((int) number3);
            break;
          case 56:
            writer.Write((short) number);
            if (Main.netMode == 2)
            {
              string givenName = Main.npc[number].GivenName;
              writer.Write(givenName);
              break;
            }
            break;
          case 57:
            writer.Write(WorldGen.tGood);
            writer.Write(WorldGen.tEvil);
            writer.Write(WorldGen.tBlood);
            break;
          case 58:
            writer.Write((byte) number);
            writer.Write(number2);
            break;
          case 59:
            writer.Write((short) number);
            writer.Write((short) number2);
            break;
          case 60:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((byte) number4);
            break;
          case 61:
            writer.Write((short) number);
            writer.Write((short) number2);
            break;
          case 62:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            break;
          case 63:
          case 64:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((byte) number3);
            break;
          case 65:
            BitsByte bitsByte16 = (BitsByte) (byte) 0;
            bitsByte16[0] = (number & 1) == 1;
            bitsByte16[1] = (number & 2) == 2;
            bitsByte16[2] = (number5 & 1) == 1;
            bitsByte16[3] = (number5 & 2) == 2;
            writer.Write((byte) bitsByte16);
            writer.Write((short) number2);
            writer.Write(number3);
            writer.Write(number4);
            break;
          case 68:
            writer.Write(Main.clientUUID);
            break;
          case 69:
            Netplay.GetSectionX((int) number2);
            Netplay.GetSectionY((int) number3);
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write(Main.chest[(int) (short) number].name);
            break;
          case 70:
            writer.Write((short) number);
            writer.Write((byte) number2);
            break;
          case 71:
            writer.Write(number);
            writer.Write((int) number2);
            writer.Write((short) number3);
            writer.Write((byte) number4);
            break;
          case 72:
            for (int index = 0; index < 40; ++index)
              writer.Write((short) Main.travelShop[index]);
            break;
          case 74:
            writer.Write((byte) Main.anglerQuest);
            bool flag1 = Main.anglerWhoFinishedToday.Contains(text.ToString());
            writer.Write(flag1);
            break;
          case 76:
            writer.Write((byte) number);
            writer.Write(Main.player[number].anglerQuestsFinished);
            break;
          case 77:
            if (Main.netMode != 2)
              return;
            writer.Write((short) number);
            writer.Write((ushort) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            break;
          case 78:
            writer.Write(number);
            writer.Write((int) number2);
            writer.Write((sbyte) number3);
            writer.Write((sbyte) number4);
            break;
          case 79:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            writer.Write((byte) number5);
            writer.Write((sbyte) number6);
            writer.Write(number7 == 1);
            break;
          case 80:
            writer.Write((byte) number);
            writer.Write((short) number2);
            break;
          case 81:
            writer.Write(number2);
            writer.Write(number3);
            writer.WriteRGB(new Color()
            {
              PackedValue = (uint) number
            });
            writer.Write((int) number4);
            break;
          case 83:
            int index3 = number;
            if (index3 < 0 && index3 >= 267)
              index3 = 1;
            int num14 = NPC.killCount[index3];
            writer.Write((short) index3);
            writer.Write(num14);
            break;
          case 84:
            byte num15 = (byte) number;
            float stealth = Main.player[(int) num15].stealth;
            writer.Write(num15);
            writer.Write(stealth);
            break;
          case 85:
            byte num16 = (byte) number;
            writer.Write(num16);
            break;
          case 86:
            writer.Write(number);
            bool flag2 = TileEntity.ByID.ContainsKey(number);
            writer.Write(flag2);
            if (flag2)
            {
              TileEntity.Write(writer, TileEntity.ByID[number], true);
              break;
            }
            break;
          case 87:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((byte) number3);
            break;
          case 88:
            BitsByte bitsByte17 = (BitsByte) (byte) number2;
            BitsByte bitsByte18 = (BitsByte) (byte) number3;
            writer.Write((short) number);
            writer.Write((byte) bitsByte17);
            Item obj4 = Main.item[number];
            if (bitsByte17[0])
              writer.Write(obj4.color.PackedValue);
            if (bitsByte17[1])
              writer.Write((ushort) obj4.damage);
            if (bitsByte17[2])
              writer.Write(obj4.knockBack);
            if (bitsByte17[3])
              writer.Write((ushort) obj4.useAnimation);
            if (bitsByte17[4])
              writer.Write((ushort) obj4.useTime);
            if (bitsByte17[5])
              writer.Write((short) obj4.shoot);
            if (bitsByte17[6])
              writer.Write(obj4.shootSpeed);
            if (bitsByte17[7])
            {
              writer.Write((byte) bitsByte18);
              if (bitsByte18[0])
                writer.Write((ushort) obj4.width);
              if (bitsByte18[1])
                writer.Write((ushort) obj4.height);
              if (bitsByte18[2])
                writer.Write(obj4.scale);
              if (bitsByte18[3])
                writer.Write((short) obj4.ammo);
              if (bitsByte18[4])
                writer.Write((short) obj4.useAmmo);
              if (bitsByte18[5])
              {
                writer.Write(obj4.notAmmo);
                break;
              }
              break;
            }
            break;
          case 89:
            writer.Write((short) number);
            writer.Write((short) number2);
            Item obj5 = Main.player[(int) number4].inventory[(int) number3];
            writer.Write((short) obj5.netID);
            writer.Write(obj5.prefix);
            writer.Write((short) obj5.stack);
            break;
          case 91:
            writer.Write(number);
            writer.Write((byte) number2);
            if ((double) number2 != (double) byte.MaxValue)
            {
              writer.Write((ushort) number3);
              writer.Write((byte) number4);
              writer.Write((byte) number5);
              if (number5 < 0)
              {
                writer.Write((short) number6);
                break;
              }
              break;
            }
            break;
          case 92:
            writer.Write((short) number);
            writer.Write(number2);
            writer.Write(number3);
            writer.Write(number4);
            break;
          case 95:
            writer.Write((ushort) number);
            break;
          case 96:
            writer.Write((byte) number);
            Player player5 = Main.player[number];
            writer.Write((short) number4);
            writer.Write(number2);
            writer.Write(number3);
            writer.WriteVector2(player5.velocity);
            break;
          case 97:
            writer.Write((short) number);
            break;
          case 98:
            writer.Write((short) number);
            break;
          case 99:
            writer.Write((byte) number);
            writer.WriteVector2(Main.player[number].MinionRestTargetPoint);
            break;
          case 100:
            writer.Write((ushort) number);
            NPC npc2 = Main.npc[number];
            writer.Write((short) number4);
            writer.Write(number2);
            writer.Write(number3);
            writer.WriteVector2(npc2.velocity);
            break;
          case 101:
            writer.Write((ushort) NPC.ShieldStrengthTowerSolar);
            writer.Write((ushort) NPC.ShieldStrengthTowerVortex);
            writer.Write((ushort) NPC.ShieldStrengthTowerNebula);
            writer.Write((ushort) NPC.ShieldStrengthTowerStardust);
            break;
          case 102:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            writer.Write(number3);
            writer.Write(number4);
            break;
          case 103:
            writer.Write(NPC.MoonLordCountdown);
            break;
          case 104:
            writer.Write((byte) number);
            writer.Write((short) number2);
            writer.Write((short) number3 < (short) 0 ? 0.0f : number3);
            writer.Write((byte) number4);
            writer.Write(number5);
            writer.Write((byte) number6);
            break;
          case 105:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((double) number3 == 1.0);
            break;
          case 106:
            HalfVector2 halfVector2 = new HalfVector2((float) number, number2);
            writer.Write(halfVector2.PackedValue);
            break;
          case 107:
            writer.Write((byte) number2);
            writer.Write((byte) number3);
            writer.Write((byte) number4);
            text.Serialize(writer);
            writer.Write((short) number5);
            break;
          case 108:
            writer.Write((short) number);
            writer.Write(number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            writer.Write((short) number5);
            writer.Write((short) number6);
            writer.Write((byte) number7);
            break;
          case 109:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((short) number4);
            writer.Write((byte) number5);
            break;
          case 110:
            writer.Write((short) number);
            writer.Write((short) number2);
            writer.Write((byte) number3);
            break;
          case 112:
            writer.Write((byte) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((byte) number4);
            writer.Write((short) number5);
            break;
          case 113:
            writer.Write((short) number);
            writer.Write((short) number2);
            break;
          case 115:
            writer.Write((byte) number);
            writer.Write((short) Main.player[number].MinionAttackTargetNPC);
            break;
          case 116:
            writer.Write(number);
            break;
          case 117:
            writer.Write((byte) number);
            NetMessage._currentPlayerDeathReason.WriteSelfTo(writer);
            writer.Write((short) number2);
            writer.Write((byte) ((double) number3 + 1.0));
            writer.Write((byte) number4);
            writer.Write((sbyte) number5);
            break;
          case 118:
            writer.Write((byte) number);
            NetMessage._currentPlayerDeathReason.WriteSelfTo(writer);
            writer.Write((short) number2);
            writer.Write((byte) ((double) number3 + 1.0));
            writer.Write((byte) number4);
            break;
          case 119:
            writer.Write(number2);
            writer.Write(number3);
            writer.WriteRGB(new Color()
            {
              PackedValue = (uint) number
            });
            text.Serialize(writer);
            break;
        }
        int position2 = (int) writer.BaseStream.Position;
        writer.BaseStream.Position = position1;
        writer.Write((short) position2);
        writer.BaseStream.Position = (long) position2;
        if (Main.netMode == 1)
        {
          if (Netplay.Connection.Socket.IsConnected())
          {
            try
            {
              ++NetMessage.buffer[whoAmi].spamCount;
              ++Main.txMsg;
              Main.txData += position2;
              ++Main.txMsgType[msgType];
              Main.txDataType[msgType] += position2;
              Netplay.Connection.Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Connection.ClientWriteCallBack));
            }
            catch
            {
            }
          }
        }
        else if (remoteClient == -1)
        {
          switch (msgType)
          {
            case 13:
              for (int index4 = 0; index4 < 256; ++index4)
              {
                if (index4 != ignoreClient && NetMessage.buffer[index4].broadcast)
                {
                  if (Netplay.Clients[index4].IsConnected())
                  {
                    try
                    {
                      ++NetMessage.buffer[index4].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index4].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index4].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              ++Main.player[number].netSkip;
              if (Main.player[number].netSkip > 2)
              {
                Main.player[number].netSkip = 0;
                break;
              }
              break;
            case 20:
              for (int index5 = 0; index5 < 256; ++index5)
              {
                if (index5 != ignoreClient && NetMessage.buffer[index5].broadcast && Netplay.Clients[index5].IsConnected())
                {
                  if (Netplay.Clients[index5].SectionRange(number, (int) number2, (int) number3))
                  {
                    try
                    {
                      ++NetMessage.buffer[index5].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index5].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index5].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            case 23:
              NPC npc3 = Main.npc[number];
              for (int index6 = 0; index6 < 256; ++index6)
              {
                if (index6 != ignoreClient && NetMessage.buffer[index6].broadcast && Netplay.Clients[index6].IsConnected())
                {
                  bool flag3 = false;
                  if (npc3.boss || npc3.netAlways || npc3.townNPC || !npc3.active)
                    flag3 = true;
                  else if (npc3.netSkip <= 0)
                  {
                    Rectangle rect1 = Main.player[index6].getRect();
                    Rectangle rect2 = npc3.getRect();
                    rect2.X -= 2500;
                    rect2.Y -= 2500;
                    rect2.Width += 5000;
                    rect2.Height += 5000;
                    if (rect1.Intersects(rect2))
                      flag3 = true;
                  }
                  else
                    flag3 = true;
                  if (flag3)
                  {
                    try
                    {
                      ++NetMessage.buffer[index6].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index6].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index6].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              ++npc3.netSkip;
              if (npc3.netSkip > 4)
              {
                npc3.netSkip = 0;
                break;
              }
              break;
            case 27:
              Projectile projectile2 = Main.projectile[number];
              for (int index7 = 0; index7 < 256; ++index7)
              {
                if (index7 != ignoreClient && NetMessage.buffer[index7].broadcast && Netplay.Clients[index7].IsConnected())
                {
                  bool flag4 = false;
                  if (projectile2.type == 12 || Main.projPet[projectile2.type] || projectile2.aiStyle == 11 || projectile2.netImportant)
                  {
                    flag4 = true;
                  }
                  else
                  {
                    Rectangle rect3 = Main.player[index7].getRect();
                    Rectangle rect4 = projectile2.getRect();
                    rect4.X -= 5000;
                    rect4.Y -= 5000;
                    rect4.Width += 10000;
                    rect4.Height += 10000;
                    if (rect3.Intersects(rect4))
                      flag4 = true;
                  }
                  if (flag4)
                  {
                    try
                    {
                      ++NetMessage.buffer[index7].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index7].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index7].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            case 28:
              NPC npc4 = Main.npc[number];
              for (int index8 = 0; index8 < 256; ++index8)
              {
                if (index8 != ignoreClient && NetMessage.buffer[index8].broadcast && Netplay.Clients[index8].IsConnected())
                {
                  bool flag5 = false;
                  if (npc4.life <= 0)
                  {
                    flag5 = true;
                  }
                  else
                  {
                    Rectangle rect5 = Main.player[index8].getRect();
                    Rectangle rect6 = npc4.getRect();
                    rect6.X -= 3000;
                    rect6.Y -= 3000;
                    rect6.Width += 6000;
                    rect6.Height += 6000;
                    if (rect5.Intersects(rect6))
                      flag5 = true;
                  }
                  if (flag5)
                  {
                    try
                    {
                      ++NetMessage.buffer[index8].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index8].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index8].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            case 34:
            case 69:
              for (int index9 = 0; index9 < 256; ++index9)
              {
                if (index9 != ignoreClient && NetMessage.buffer[index9].broadcast)
                {
                  if (Netplay.Clients[index9].IsConnected())
                  {
                    try
                    {
                      ++NetMessage.buffer[index9].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index9].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index9].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            default:
              for (int index10 = 0; index10 < 256; ++index10)
              {
                if (index10 != ignoreClient && (NetMessage.buffer[index10].broadcast || Netplay.Clients[index10].State >= 3 && msgType == 10))
                {
                  if (Netplay.Clients[index10].IsConnected())
                  {
                    try
                    {
                      ++NetMessage.buffer[index10].spamCount;
                      ++Main.txMsg;
                      Main.txData += position2;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += position2;
                      Netplay.Clients[index10].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index10].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
          }
        }
        else if (Netplay.Clients[remoteClient].IsConnected())
        {
          try
          {
            ++NetMessage.buffer[remoteClient].spamCount;
            ++Main.txMsg;
            Main.txData += position2;
            ++Main.txMsgType[msgType];
            Main.txDataType[msgType] += position2;
            Netplay.Clients[remoteClient].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[remoteClient].ServerWriteCallBack));
          }
          catch
          {
          }
        }
        if (Main.verboseNetplay)
        {
          int num17 = 0;
          while (num17 < position2)
            ++num17;
          for (int index11 = 0; index11 < position2; ++index11)
          {
            int num18 = (int) NetMessage.buffer[whoAmi].writeBuffer[index11];
          }
        }
        NetMessage.buffer[whoAmi].writeLocked = false;
        if (msgType == 19 && Main.netMode == 1)
          NetMessage.SendTileSquare(whoAmi, (int) number2, (int) number3, 5);
        if (msgType != 2 || Main.netMode != 2)
          return;
        Netplay.Clients[whoAmi].PendingTermination = true;
      }
    }

    public static int CompressTileBlock(
      int xStart,
      int yStart,
      short width,
      short height,
      byte[] buffer,
      int bufferStart)
    {
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) memoryStream1))
        {
          writer.Write(xStart);
          writer.Write(yStart);
          writer.Write(width);
          writer.Write(height);
          NetMessage.CompressTileBlock_Inner(writer, xStart, yStart, (int) width, (int) height);
          int length = buffer.Length;
          if ((long) bufferStart + memoryStream1.Length > (long) length)
            return (int) ((long) (length - bufferStart) + memoryStream1.Length);
          memoryStream1.Position = 0L;
          MemoryStream memoryStream2 = new MemoryStream();
          using (DeflateStream deflateStream = new DeflateStream((Stream) memoryStream2, (CompressionMode) 0, true))
          {
            memoryStream1.CopyTo((Stream) deflateStream);
            ((Stream) deflateStream).Flush();
            ((Stream) deflateStream).Close();
            ((Stream) deflateStream).Dispose();
          }
          if (memoryStream1.Length <= memoryStream2.Length)
          {
            memoryStream1.Position = 0L;
            buffer[bufferStart] = (byte) 0;
            ++bufferStart;
            memoryStream1.Read(buffer, bufferStart, (int) memoryStream1.Length);
            return (int) memoryStream1.Length + 1;
          }
          memoryStream2.Position = 0L;
          buffer[bufferStart] = (byte) 1;
          ++bufferStart;
          memoryStream2.Read(buffer, bufferStart, (int) memoryStream2.Length);
          return (int) memoryStream2.Length + 1;
        }
      }
    }

    public static void CompressTileBlock_Inner(
      BinaryWriter writer,
      int xStart,
      int yStart,
      int width,
      int height)
    {
      short[] numArray1 = new short[1000];
      short[] numArray2 = new short[1000];
      short[] numArray3 = new short[1000];
      short num1 = 0;
      short num2 = 0;
      short num3 = 0;
      short num4 = 0;
      int index1 = 0;
      int index2 = 0;
      byte num5 = 0;
      byte[] buffer = new byte[13];
      Tile compTile = (Tile) null;
      for (int index3 = yStart; index3 < yStart + height; ++index3)
      {
        for (int index4 = xStart; index4 < xStart + width; ++index4)
        {
          Tile tile = Main.tile[index4, index3];
          if (tile.isTheSameAs(compTile))
          {
            ++num4;
          }
          else
          {
            if (compTile != null)
            {
              if (num4 > (short) 0)
              {
                buffer[index1] = (byte) ((uint) num4 & (uint) byte.MaxValue);
                ++index1;
                if (num4 > (short) byte.MaxValue)
                {
                  num5 |= (byte) 128;
                  buffer[index1] = (byte) (((int) num4 & 65280) >> 8);
                  ++index1;
                }
                else
                  num5 |= (byte) 64;
              }
              buffer[index2] = num5;
              writer.Write(buffer, index2, index1 - index2);
              num4 = (short) 0;
            }
            index1 = 3;
            int num6;
            byte num7 = (byte) (num6 = 0);
            byte num8 = (byte) num6;
            num5 = (byte) num6;
            if (tile.active())
            {
              num5 |= (byte) 2;
              buffer[index1] = (byte) tile.type;
              ++index1;
              if (tile.type > (ushort) byte.MaxValue)
              {
                buffer[index1] = (byte) ((uint) tile.type >> 8);
                ++index1;
                num5 |= (byte) 32;
              }
              if (TileID.Sets.BasicChest[(int) tile.type] && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short chest = (short) Chest.FindChest(index4, index3);
                if (chest != (short) -1)
                {
                  numArray1[(int) num1] = chest;
                  ++num1;
                }
              }
              if (tile.type == (ushort) 88 && (int) tile.frameX % 54 == 0 && (int) tile.frameY % 36 == 0)
              {
                short chest = (short) Chest.FindChest(index4, index3);
                if (chest != (short) -1)
                {
                  numArray1[(int) num1] = chest;
                  ++num1;
                }
              }
              if (tile.type == (ushort) 85 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num9 = (short) Sign.ReadSign(index4, index3);
                if (num9 != (short) -1)
                  numArray2[(int) num2++] = num9;
              }
              if (tile.type == (ushort) 55 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num10 = (short) Sign.ReadSign(index4, index3);
                if (num10 != (short) -1)
                  numArray2[(int) num2++] = num10;
              }
              if (tile.type == (ushort) 425 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num11 = (short) Sign.ReadSign(index4, index3);
                if (num11 != (short) -1)
                  numArray2[(int) num2++] = num11;
              }
              if (tile.type == (ushort) 378 && (int) tile.frameX % 36 == 0 && tile.frameY == (short) 0)
              {
                int num12 = TETrainingDummy.Find(index4, index3);
                if (num12 != -1)
                  numArray3[(int) num3++] = (short) num12;
              }
              if (tile.type == (ushort) 395 && (int) tile.frameX % 36 == 0 && tile.frameY == (short) 0)
              {
                int num13 = TEItemFrame.Find(index4, index3);
                if (num13 != -1)
                  numArray3[(int) num3++] = (short) num13;
              }
              if (Main.tileFrameImportant[(int) tile.type])
              {
                buffer[index1] = (byte) ((uint) tile.frameX & (uint) byte.MaxValue);
                int index5 = index1 + 1;
                buffer[index5] = (byte) (((int) tile.frameX & 65280) >> 8);
                int index6 = index5 + 1;
                buffer[index6] = (byte) ((uint) tile.frameY & (uint) byte.MaxValue);
                int index7 = index6 + 1;
                buffer[index7] = (byte) (((int) tile.frameY & 65280) >> 8);
                index1 = index7 + 1;
              }
              if (tile.color() != (byte) 0)
              {
                num7 |= (byte) 8;
                buffer[index1] = tile.color();
                ++index1;
              }
            }
            if (tile.wall != (byte) 0)
            {
              num5 |= (byte) 4;
              buffer[index1] = tile.wall;
              ++index1;
              if (tile.wallColor() != (byte) 0)
              {
                num7 |= (byte) 16;
                buffer[index1] = tile.wallColor();
                ++index1;
              }
            }
            if (tile.liquid != (byte) 0)
            {
              if (tile.lava())
                num5 |= (byte) 16;
              else if (tile.honey())
                num5 |= (byte) 24;
              else
                num5 |= (byte) 8;
              buffer[index1] = tile.liquid;
              ++index1;
            }
            if (tile.wire())
              num8 |= (byte) 2;
            if (tile.wire2())
              num8 |= (byte) 4;
            if (tile.wire3())
              num8 |= (byte) 8;
            int num14 = !tile.halfBrick() ? (tile.slope() == (byte) 0 ? 0 : (int) tile.slope() + 1 << 4) : 16;
            byte num15 = (byte) ((uint) num8 | (uint) (byte) num14);
            if (tile.actuator())
              num7 |= (byte) 2;
            if (tile.inActive())
              num7 |= (byte) 4;
            if (tile.wire4())
              num7 |= (byte) 32;
            index2 = 2;
            if (num7 != (byte) 0)
            {
              num15 |= (byte) 1;
              buffer[index2] = num7;
              --index2;
            }
            if (num15 != (byte) 0)
            {
              num5 |= (byte) 1;
              buffer[index2] = num15;
              --index2;
            }
            compTile = tile;
          }
        }
      }
      if (num4 > (short) 0)
      {
        buffer[index1] = (byte) ((uint) num4 & (uint) byte.MaxValue);
        ++index1;
        if (num4 > (short) byte.MaxValue)
        {
          num5 |= (byte) 128;
          buffer[index1] = (byte) (((int) num4 & 65280) >> 8);
          ++index1;
        }
        else
          num5 |= (byte) 64;
      }
      buffer[index2] = num5;
      writer.Write(buffer, index2, index1 - index2);
      writer.Write(num1);
      for (int index8 = 0; index8 < (int) num1; ++index8)
      {
        Chest chest = Main.chest[(int) numArray1[index8]];
        writer.Write(numArray1[index8]);
        writer.Write((short) chest.x);
        writer.Write((short) chest.y);
        writer.Write(chest.name);
      }
      writer.Write(num2);
      for (int index9 = 0; index9 < (int) num2; ++index9)
      {
        Sign sign = Main.sign[(int) numArray2[index9]];
        writer.Write(numArray2[index9]);
        writer.Write((short) sign.x);
        writer.Write((short) sign.y);
        writer.Write(sign.text);
      }
      writer.Write(num3);
      for (int index10 = 0; index10 < (int) num3; ++index10)
        TileEntity.Write(writer, TileEntity.ByID[(int) numArray3[index10]]);
    }

    public static void DecompressTileBlock(byte[] buffer, int bufferStart, int bufferLength)
    {
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        memoryStream1.Write(buffer, bufferStart, bufferLength);
        memoryStream1.Position = 0L;
        MemoryStream memoryStream2;
        if ((uint) memoryStream1.ReadByte() > 0U)
        {
          MemoryStream memoryStream3 = new MemoryStream();
          using (DeflateStream deflateStream = new DeflateStream((Stream) memoryStream1, (CompressionMode) 1, true))
          {
            ((Stream) deflateStream).CopyTo((Stream) memoryStream3);
            ((Stream) deflateStream).Close();
          }
          memoryStream2 = memoryStream3;
          memoryStream2.Position = 0L;
        }
        else
        {
          memoryStream2 = memoryStream1;
          memoryStream2.Position = 1L;
        }
        using (BinaryReader reader = new BinaryReader((Stream) memoryStream2))
        {
          int xStart = reader.ReadInt32();
          int yStart = reader.ReadInt32();
          short num1 = reader.ReadInt16();
          short num2 = reader.ReadInt16();
          NetMessage.DecompressTileBlock_Inner(reader, xStart, yStart, (int) num1, (int) num2);
        }
      }
    }

    public static void DecompressTileBlock_Inner(
      BinaryReader reader,
      int xStart,
      int yStart,
      int width,
      int height)
    {
      Tile tile = (Tile) null;
      int num1 = 0;
      for (int index1 = yStart; index1 < yStart + height; ++index1)
      {
        for (int index2 = xStart; index2 < xStart + width; ++index2)
        {
          if (num1 != 0)
          {
            --num1;
            if (Main.tile[index2, index1] == null)
              Main.tile[index2, index1] = new Tile(tile);
            else
              Main.tile[index2, index1].CopyFrom(tile);
          }
          else
          {
            byte num2;
            byte num3 = num2 = (byte) 0;
            tile = Main.tile[index2, index1];
            if (tile == null)
            {
              tile = new Tile();
              Main.tile[index2, index1] = tile;
            }
            else
              tile.ClearEverything();
            byte num4 = reader.ReadByte();
            if (((int) num4 & 1) == 1)
            {
              num3 = reader.ReadByte();
              if (((int) num3 & 1) == 1)
                num2 = reader.ReadByte();
            }
            bool flag = tile.active();
            if (((int) num4 & 2) == 2)
            {
              tile.active(true);
              ushort type = tile.type;
              int index3;
              if (((int) num4 & 32) == 32)
              {
                byte num5 = reader.ReadByte();
                index3 = (int) reader.ReadByte() << 8 | (int) num5;
              }
              else
                index3 = (int) reader.ReadByte();
              tile.type = (ushort) index3;
              if (Main.tileFrameImportant[index3])
              {
                tile.frameX = reader.ReadInt16();
                tile.frameY = reader.ReadInt16();
              }
              else if (!flag || (int) tile.type != (int) type)
              {
                tile.frameX = (short) -1;
                tile.frameY = (short) -1;
              }
              if (((int) num2 & 8) == 8)
                tile.color(reader.ReadByte());
            }
            if (((int) num4 & 4) == 4)
            {
              tile.wall = reader.ReadByte();
              if (((int) num2 & 16) == 16)
                tile.wallColor(reader.ReadByte());
            }
            byte num6 = (byte) (((int) num4 & 24) >> 3);
            if (num6 != (byte) 0)
            {
              tile.liquid = reader.ReadByte();
              if (num6 > (byte) 1)
              {
                if (num6 == (byte) 2)
                  tile.lava(true);
                else
                  tile.honey(true);
              }
            }
            if (num3 > (byte) 1)
            {
              if (((int) num3 & 2) == 2)
                tile.wire(true);
              if (((int) num3 & 4) == 4)
                tile.wire2(true);
              if (((int) num3 & 8) == 8)
                tile.wire3(true);
              byte num7 = (byte) (((int) num3 & 112) >> 4);
              if (num7 != (byte) 0 && Main.tileSolid[(int) tile.type])
              {
                if (num7 == (byte) 1)
                  tile.halfBrick(true);
                else
                  tile.slope((byte) ((uint) num7 - 1U));
              }
            }
            if (num2 > (byte) 0)
            {
              if (((int) num2 & 2) == 2)
                tile.actuator(true);
              if (((int) num2 & 4) == 4)
                tile.inActive(true);
              if (((int) num2 & 32) == 32)
                tile.wire4(true);
            }
            switch ((byte) (((int) num4 & 192) >> 6))
            {
              case 0:
                num1 = 0;
                continue;
              case 1:
                num1 = (int) reader.ReadByte();
                continue;
              default:
                num1 = (int) reader.ReadInt16();
                continue;
            }
          }
        }
      }
      short num8 = reader.ReadInt16();
      for (int index = 0; index < (int) num8; ++index)
      {
        short num9 = reader.ReadInt16();
        short num10 = reader.ReadInt16();
        short num11 = reader.ReadInt16();
        string str = reader.ReadString();
        if (num9 >= (short) 0 && num9 < (short) 1000)
        {
          if (Main.chest[(int) num9] == null)
            Main.chest[(int) num9] = new Chest();
          Main.chest[(int) num9].name = str;
          Main.chest[(int) num9].x = (int) num10;
          Main.chest[(int) num9].y = (int) num11;
        }
      }
      short num12 = reader.ReadInt16();
      for (int index = 0; index < (int) num12; ++index)
      {
        short num13 = reader.ReadInt16();
        short num14 = reader.ReadInt16();
        short num15 = reader.ReadInt16();
        string str = reader.ReadString();
        if (num13 >= (short) 0 && num13 < (short) 1000)
        {
          if (Main.sign[(int) num13] == null)
            Main.sign[(int) num13] = new Sign();
          Main.sign[(int) num13].text = str;
          Main.sign[(int) num13].x = (int) num14;
          Main.sign[(int) num13].y = (int) num15;
        }
      }
      short num16 = reader.ReadInt16();
      for (int index = 0; index < (int) num16; ++index)
      {
        TileEntity tileEntity = TileEntity.Read(reader);
        TileEntity.ByID[tileEntity.ID] = tileEntity;
        TileEntity.ByPosition[tileEntity.Position] = tileEntity;
      }
    }

    public static void ReceiveBytes(byte[] bytes, int streamLength, int i = 256)
    {
      lock (NetMessage.buffer[i])
      {
        try
        {
          Buffer.BlockCopy((Array) bytes, 0, (Array) NetMessage.buffer[i].readBuffer, NetMessage.buffer[i].totalData, streamLength);
          NetMessage.buffer[i].totalData += streamLength;
          NetMessage.buffer[i].checkBytes = true;
        }
        catch
        {
          if (Main.netMode == 1)
          {
            Main.menuMode = 15;
            Main.statusText = Language.GetTextValue("Error.BadHeaderBufferOverflow");
            Netplay.disconnect = true;
          }
          else
            Netplay.Clients[i].PendingTermination = true;
        }
      }
    }

    public static void CheckBytes(int bufferIndex = 256)
    {
      lock (NetMessage.buffer[bufferIndex])
      {
        int startIndex = 0;
        int num = NetMessage.buffer[bufferIndex].totalData;
        try
        {
          while (num >= 2)
          {
            int uint16 = (int) BitConverter.ToUInt16(NetMessage.buffer[bufferIndex].readBuffer, startIndex);
            if (num >= uint16)
            {
              long position = NetMessage.buffer[bufferIndex].reader.BaseStream.Position;
              NetMessage.buffer[bufferIndex].GetData(startIndex + 2, uint16 - 2, out int _);
              NetMessage.buffer[bufferIndex].reader.BaseStream.Position = position + (long) uint16;
              num -= uint16;
              startIndex += uint16;
            }
            else
              break;
          }
        }
        catch
        {
          num = 0;
          startIndex = 0;
        }
        if (num != NetMessage.buffer[bufferIndex].totalData)
        {
          for (int index = 0; index < num; ++index)
            NetMessage.buffer[bufferIndex].readBuffer[index] = NetMessage.buffer[bufferIndex].readBuffer[index + startIndex];
          NetMessage.buffer[bufferIndex].totalData = num;
        }
        NetMessage.buffer[bufferIndex].checkBytes = false;
      }
    }

    public static void BootPlayer(int plr, NetworkText msg) => NetMessage.SendData(2, plr, text: msg);

    public static void SendObjectPlacment(
      int whoAmi,
      int x,
      int y,
      int type,
      int style,
      int alternative,
      int random,
      int direction)
    {
      int remoteClient;
      int ignoreClient;
      if (Main.netMode == 2)
      {
        remoteClient = -1;
        ignoreClient = whoAmi;
      }
      else
      {
        remoteClient = whoAmi;
        ignoreClient = -1;
      }
      NetMessage.SendData(79, remoteClient, ignoreClient, number: x, number2: ((float) y), number3: ((float) type), number4: ((float) style), number5: alternative, number6: random, number7: direction);
    }

    public static void SendTemporaryAnimation(
      int whoAmi,
      int animationType,
      int tileType,
      int xCoord,
      int yCoord)
    {
      NetMessage.SendData(77, whoAmi, number: animationType, number2: ((float) tileType), number3: ((float) xCoord), number4: ((float) yCoord));
    }

    public static void SendPlayerHurt(
      int playerTargetIndex,
      PlayerDeathReason reason,
      int damage,
      int direction,
      bool critical,
      bool pvp,
      int hitContext,
      int remoteClient = -1,
      int ignoreClient = -1)
    {
      NetMessage._currentPlayerDeathReason = reason;
      BitsByte bitsByte = (BitsByte) (byte) 0;
      bitsByte[0] = critical;
      bitsByte[1] = pvp;
      NetMessage.SendData(117, remoteClient, ignoreClient, number: playerTargetIndex, number2: ((float) damage), number3: ((float) direction), number4: ((float) (byte) bitsByte), number5: hitContext);
    }

    public static void SendPlayerDeath(
      int playerTargetIndex,
      PlayerDeathReason reason,
      int damage,
      int direction,
      bool pvp,
      int remoteClient = -1,
      int ignoreClient = -1)
    {
      NetMessage._currentPlayerDeathReason = reason;
      BitsByte bitsByte = (BitsByte) (byte) 0;
      bitsByte[0] = pvp;
      NetMessage.SendData(118, remoteClient, ignoreClient, number: playerTargetIndex, number2: ((float) damage), number3: ((float) direction), number4: ((float) (byte) bitsByte));
    }

    public static void SendTileRange(
      int whoAmi,
      int tileX,
      int tileY,
      int xSize,
      int ySize,
      TileChangeType changeType = TileChangeType.None)
    {
      int number = xSize >= ySize ? xSize : ySize;
      NetMessage.SendData(20, whoAmi, number: number, number2: ((float) tileX), number3: ((float) tileY), number5: ((int) changeType));
    }

    public static void SendTileSquare(
      int whoAmi,
      int tileX,
      int tileY,
      int size,
      TileChangeType changeType = TileChangeType.None)
    {
      int num = (size - 1) / 2;
      NetMessage.SendData(20, whoAmi, number: size, number2: ((float) (tileX - num)), number3: ((float) (tileY - num)), number5: ((int) changeType));
    }

    public static void SendTravelShop(int remoteClient)
    {
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(72, remoteClient);
    }

    public static void SendAnglerQuest(int remoteClient)
    {
      if (Main.netMode != 2)
        return;
      if (remoteClient == -1)
      {
        for (int remoteClient1 = 0; remoteClient1 < (int) byte.MaxValue; ++remoteClient1)
        {
          if (Netplay.Clients[remoteClient1].State == 10)
            NetMessage.SendData(74, remoteClient1, text: NetworkText.FromLiteral(Main.player[remoteClient1].name), number: Main.anglerQuest);
        }
      }
      else
      {
        if (Netplay.Clients[remoteClient].State != 10)
          return;
        NetMessage.SendData(74, remoteClient, text: NetworkText.FromLiteral(Main.player[remoteClient].name), number: Main.anglerQuest);
      }
    }

    public static void SendSection(int whoAmi, int sectionX, int sectionY, bool skipSent = false)
    {
      if (Main.netMode != 2)
        return;
      try
      {
        if (sectionX < 0 || sectionY < 0 || sectionX >= Main.maxSectionsX || sectionY >= Main.maxSectionsY || skipSent && Netplay.Clients[whoAmi].TileSections[sectionX, sectionY])
          return;
        Netplay.Clients[whoAmi].TileSections[sectionX, sectionY] = true;
        int number1 = sectionX * 200;
        int num1 = sectionY * 150;
        int num2 = 150;
        for (int index = num1; index < num1 + 150; index += num2)
          NetMessage.SendData(10, whoAmi, number: number1, number2: ((float) index), number3: 200f, number4: ((float) num2));
        for (int number2 = 0; number2 < 200; ++number2)
        {
          if (Main.npc[number2].active && Main.npc[number2].townNPC)
          {
            int sectionX1 = Netplay.GetSectionX((int) ((double) Main.npc[number2].position.X / 16.0));
            int sectionY1 = Netplay.GetSectionY((int) ((double) Main.npc[number2].position.Y / 16.0));
            int num3 = sectionX;
            if (sectionX1 == num3 && sectionY1 == sectionY)
              NetMessage.SendData(23, whoAmi, number: number2);
          }
        }
      }
      catch
      {
      }
    }

    public static void greetPlayer(int plr)
    {
      if (Main.motd == "")
        NetMessage.SendChatMessageToClient(NetworkText.FromFormattable("{0} {1}!", (object) Lang.mp[18].ToNetworkText(), (object) Main.worldName), new Color((int) byte.MaxValue, 240, 20), plr);
      else
        NetMessage.SendChatMessageToClient(NetworkText.FromLiteral(Main.motd), new Color((int) byte.MaxValue, 240, 20), plr);
      string str = "";
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
          str = !(str == "") ? str + ", " + Main.player[index].name : str + Main.player[index].name;
      }
      NetMessage.SendChatMessageToClient(NetworkText.FromKey("Game.JoinGreeting", (object) str), new Color((int) byte.MaxValue, 240, 20), plr);
    }

    public static void sendWater(int x, int y)
    {
      if (Main.netMode == 1)
      {
        NetMessage.SendData(48, number: x, number2: ((float) y));
      }
      else
      {
        for (int remoteClient = 0; remoteClient < 256; ++remoteClient)
        {
          if ((NetMessage.buffer[remoteClient].broadcast || Netplay.Clients[remoteClient].State >= 3) && Netplay.Clients[remoteClient].IsConnected())
          {
            int index1 = x / 200;
            int index2 = y / 150;
            if (Netplay.Clients[remoteClient].TileSections[index1, index2])
              NetMessage.SendData(48, remoteClient, number: x, number2: ((float) y));
          }
        }
      }
    }

    public static void SyncDisconnectedPlayer(int plr)
    {
      NetMessage.SyncOnePlayer(plr, -1, plr);
      NetMessage.EnsureLocalPlayerIsPresent();
    }

    public static void SyncConnectedPlayer(int plr)
    {
      NetMessage.SyncOnePlayer(plr, -1, plr);
      for (int plr1 = 0; plr1 < (int) byte.MaxValue; ++plr1)
      {
        if (plr != plr1 && Main.player[plr1].active)
          NetMessage.SyncOnePlayer(plr1, plr, -1);
      }
      NetMessage.SendNPCHousesAndTravelShop(plr);
      NetMessage.SendAnglerQuest(plr);
      NetMessage.EnsureLocalPlayerIsPresent();
    }

    private static void SendNPCHousesAndTravelShop(int plr)
    {
      bool flag = false;
      for (int number = 0; number < 200; ++number)
      {
        if (Main.npc[number].active && Main.npc[number].townNPC && NPC.TypeToHeadIndex(Main.npc[number].type) != -1)
        {
          if (!flag && Main.npc[number].type == 368)
            flag = true;
          byte householdStatus = WorldGen.TownManager.GetHouseholdStatus(Main.npc[number]);
          NetMessage.SendData(60, plr, number: number, number2: ((float) Main.npc[number].homeTileX), number3: ((float) Main.npc[number].homeTileY), number4: ((float) householdStatus));
        }
      }
      if (!flag)
        return;
      NetMessage.SendTravelShop(plr);
    }

    private static void EnsureLocalPlayerIsPresent()
    {
      if (!Main.autoShutdown)
        return;
      bool flag = false;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Netplay.Clients[index].State == 10 && Netplay.Clients[index].Socket.GetRemoteAddress().IsLocalHost())
        {
          flag = true;
          break;
        }
      }
      if (flag)
        return;
      Console.WriteLine(Language.GetTextValue("Net.ServerAutoShutdown"));
      WorldFile.saveWorld();
      Netplay.disconnect = true;
    }

    private static void SyncOnePlayer(int plr, int toWho, int fromWho)
    {
      int num1 = 0;
      if (Main.player[plr].active)
        num1 = 1;
      if (Netplay.Clients[plr].State == 10)
      {
        NetMessage.SendData(14, toWho, fromWho, number: plr, number2: ((float) num1));
        NetMessage.SendData(4, toWho, fromWho, number: plr);
        NetMessage.SendData(13, toWho, fromWho, number: plr);
        NetMessage.SendData(16, toWho, fromWho, number: plr);
        NetMessage.SendData(30, toWho, fromWho, number: plr);
        NetMessage.SendData(45, toWho, fromWho, number: plr);
        NetMessage.SendData(42, toWho, fromWho, number: plr);
        NetMessage.SendData(50, toWho, fromWho, number: plr);
        for (int index = 0; index < 59; ++index)
          NetMessage.SendData(5, toWho, fromWho, number: plr, number2: ((float) index), number3: ((float) Main.player[plr].inventory[index].prefix));
        for (int index = 0; index < Main.player[plr].armor.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, number: plr, number2: ((float) (59 + index)), number3: ((float) Main.player[plr].armor[index].prefix));
        for (int index = 0; index < Main.player[plr].dye.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, number: plr, number2: ((float) (58 + Main.player[plr].armor.Length + 1 + index)), number3: ((float) Main.player[plr].dye[index].prefix));
        for (int index = 0; index < Main.player[plr].miscEquips.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, number: plr, number2: ((float) (58 + Main.player[plr].armor.Length + Main.player[plr].dye.Length + 1 + index)), number3: ((float) Main.player[plr].miscEquips[index].prefix));
        for (int index = 0; index < Main.player[plr].miscDyes.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, number: plr, number2: ((float) (58 + Main.player[plr].armor.Length + Main.player[plr].dye.Length + Main.player[plr].miscEquips.Length + 1 + index)), number3: ((float) Main.player[plr].miscDyes[index].prefix));
        if (Netplay.Clients[plr].IsAnnouncementCompleted)
          return;
        Netplay.Clients[plr].IsAnnouncementCompleted = true;
        NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.mp[19].Key, (object) Main.player[plr].name), new Color((int) byte.MaxValue, 240, 20), plr);
        if (!Main.dedServ)
          return;
        Console.WriteLine(Lang.mp[19].Format((object) Main.player[plr].name));
      }
      else
      {
        int num2 = 0;
        NetMessage.SendData(14, ignoreClient: plr, number: plr, number2: ((float) num2));
        if (!Netplay.Clients[plr].IsAnnouncementCompleted)
          return;
        Netplay.Clients[plr].IsAnnouncementCompleted = false;
        NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.mp[20].Key, (object) Netplay.Clients[plr].Name), new Color((int) byte.MaxValue, 240, 20), plr);
        if (Main.dedServ)
          Console.WriteLine(Lang.mp[20].Format((object) Netplay.Clients[plr].Name));
        Netplay.Clients[plr].Name = "Anonymous";
      }
    }
  }
}
