// Decompiled with JetBrains decompiler
// Type: Terraria.NetMessage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Ionic.Zlib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.IO;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;
using Terraria.Social;

namespace Terraria
{
  public class NetMessage
  {
    public static MessageBuffer[] buffer = new MessageBuffer[257];
    private static PlayerDeathReason _currentPlayerDeathReason;
    private static NetMessage.NetSoundInfo _currentNetSoundInfo;
    private static CoinLossRevengeSystem.RevengeMarker _currentRevengeMarker;

    public static bool TrySendData(
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
      try
      {
        NetMessage.SendData(msgType, remoteClient, ignoreClient, text, number, number2, number3, number4, number5, number6, number7);
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
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
            writer.Write("Terraria" + (object) 230);
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
              bitsByte1[key] = player1.hideVisibleAccessory[key];
            writer.Write((byte) bitsByte1);
            BitsByte bitsByte2 = (BitsByte) (byte) 0;
            for (int key = 0; key < 2; ++key)
              bitsByte2[key] = player1.hideVisibleAccessory[key + 8];
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
            else if (player1.difficulty == (byte) 3)
              bitsByte3[3] = true;
            bitsByte3[2] = player1.extraAccessory;
            writer.Write((byte) bitsByte3);
            BitsByte bitsByte4 = (BitsByte) (byte) 0;
            bitsByte4[0] = player1.UsingBiomeTorches;
            bitsByte4[1] = player1.happyFunTorchTime;
            writer.Write((byte) bitsByte4);
            break;
          case 5:
            writer.Write((byte) number);
            writer.Write((short) number2);
            Player player2 = Main.player[number];
            Item obj1 = (double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length + player2.bank3.item.Length + 1) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length + 1) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length + player2.miscEquips.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length + player2.dye.Length) ? ((double) number2 <= (double) (58 + player2.armor.Length) ? ((double) number2 <= 58.0 ? player2.inventory[(int) number2] : player2.armor[(int) number2 - 58 - 1]) : player2.dye[(int) number2 - 58 - player2.armor.Length - 1]) : player2.miscEquips[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length) - 1]) : player2.miscDyes[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length) - 1]) : player2.bank.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length) - 1]) : player2.bank2.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length) - 1]) : player2.trashItem) : player2.bank3.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length + 1) - 1]) : player2.bank4.item[(int) number2 - 58 - (player2.armor.Length + player2.dye.Length + player2.miscEquips.Length + player2.miscDyes.Length + player2.bank.item.Length + player2.bank2.item.Length + player2.bank3.item.Length + 1) - 1];
            if (obj1.Name == "" || obj1.stack == 0 || obj1.type == 0)
              obj1.SetDefaults(0, true);
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
            BitsByte bitsByte5 = (BitsByte) (byte) 0;
            bitsByte5[0] = Main.dayTime;
            bitsByte5[1] = Main.bloodMoon;
            bitsByte5[2] = Main.eclipse;
            writer.Write((byte) bitsByte5);
            writer.Write((byte) Main.moonPhase);
            writer.Write((short) Main.maxTilesX);
            writer.Write((short) Main.maxTilesY);
            writer.Write((short) Main.spawnTileX);
            writer.Write((short) Main.spawnTileY);
            writer.Write((short) Main.worldSurface);
            writer.Write((short) Main.rockLayer);
            writer.Write(Main.worldID);
            writer.Write(Main.worldName);
            writer.Write((byte) Main.GameMode);
            writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
            writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
            writer.Write((byte) Main.moonType);
            writer.Write((byte) WorldGen.treeBG1);
            writer.Write((byte) WorldGen.treeBG2);
            writer.Write((byte) WorldGen.treeBG3);
            writer.Write((byte) WorldGen.treeBG4);
            writer.Write((byte) WorldGen.corruptBG);
            writer.Write((byte) WorldGen.jungleBG);
            writer.Write((byte) WorldGen.snowBG);
            writer.Write((byte) WorldGen.hallowBG);
            writer.Write((byte) WorldGen.crimsonBG);
            writer.Write((byte) WorldGen.desertBG);
            writer.Write((byte) WorldGen.oceanBG);
            writer.Write((byte) WorldGen.mushroomBG);
            writer.Write((byte) WorldGen.underworldBG);
            writer.Write((byte) Main.iceBackStyle);
            writer.Write((byte) Main.jungleBackStyle);
            writer.Write((byte) Main.hellBackStyle);
            writer.Write(Main.windSpeedTarget);
            writer.Write((byte) Main.numClouds);
            for (int index = 0; index < 3; ++index)
              writer.Write(Main.treeX[index]);
            for (int index = 0; index < 4; ++index)
              writer.Write((byte) Main.treeStyle[index]);
            for (int index = 0; index < 3; ++index)
              writer.Write(Main.caveBackX[index]);
            for (int index = 0; index < 4; ++index)
              writer.Write((byte) Main.caveBackStyle[index]);
            WorldGen.TreeTops.SyncSend(writer);
            if (!Main.raining)
              Main.maxRaining = 0.0f;
            writer.Write(Main.maxRaining);
            BitsByte bitsByte6 = (BitsByte) (byte) 0;
            bitsByte6[0] = WorldGen.shadowOrbSmashed;
            bitsByte6[1] = NPC.downedBoss1;
            bitsByte6[2] = NPC.downedBoss2;
            bitsByte6[3] = NPC.downedBoss3;
            bitsByte6[4] = Main.hardMode;
            bitsByte6[5] = NPC.downedClown;
            bitsByte6[7] = NPC.downedPlantBoss;
            writer.Write((byte) bitsByte6);
            BitsByte bitsByte7 = (BitsByte) (byte) 0;
            bitsByte7[0] = NPC.downedMechBoss1;
            bitsByte7[1] = NPC.downedMechBoss2;
            bitsByte7[2] = NPC.downedMechBoss3;
            bitsByte7[3] = NPC.downedMechBossAny;
            bitsByte7[4] = (double) Main.cloudBGActive >= 1.0;
            bitsByte7[5] = WorldGen.crimson;
            bitsByte7[6] = Main.pumpkinMoon;
            bitsByte7[7] = Main.snowMoon;
            writer.Write((byte) bitsByte7);
            BitsByte bitsByte8 = (BitsByte) (byte) 0;
            bitsByte8[1] = Main.fastForwardTime;
            bitsByte8[2] = Main.slimeRain;
            bitsByte8[3] = NPC.downedSlimeKing;
            bitsByte8[4] = NPC.downedQueenBee;
            bitsByte8[5] = NPC.downedFishron;
            bitsByte8[6] = NPC.downedMartians;
            bitsByte8[7] = NPC.downedAncientCultist;
            writer.Write((byte) bitsByte8);
            BitsByte bitsByte9 = (BitsByte) (byte) 0;
            bitsByte9[0] = NPC.downedMoonlord;
            bitsByte9[1] = NPC.downedHalloweenKing;
            bitsByte9[2] = NPC.downedHalloweenTree;
            bitsByte9[3] = NPC.downedChristmasIceQueen;
            bitsByte9[4] = NPC.downedChristmasSantank;
            bitsByte9[5] = NPC.downedChristmasTree;
            bitsByte9[6] = NPC.downedGolemBoss;
            bitsByte9[7] = BirthdayParty.PartyIsUp;
            writer.Write((byte) bitsByte9);
            BitsByte bitsByte10 = (BitsByte) (byte) 0;
            bitsByte10[0] = NPC.downedPirates;
            bitsByte10[1] = NPC.downedFrost;
            bitsByte10[2] = NPC.downedGoblins;
            bitsByte10[3] = Sandstorm.Happening;
            bitsByte10[4] = DD2Event.Ongoing;
            bitsByte10[5] = DD2Event.DownedInvasionT1;
            bitsByte10[6] = DD2Event.DownedInvasionT2;
            bitsByte10[7] = DD2Event.DownedInvasionT3;
            writer.Write((byte) bitsByte10);
            BitsByte bitsByte11 = (BitsByte) (byte) 0;
            bitsByte11[0] = NPC.combatBookWasUsed;
            bitsByte11[1] = LanternNight.LanternsUp;
            bitsByte11[2] = NPC.downedTowerSolar;
            bitsByte11[3] = NPC.downedTowerVortex;
            bitsByte11[4] = NPC.downedTowerNebula;
            bitsByte11[5] = NPC.downedTowerStardust;
            bitsByte11[6] = Main.forceHalloweenForToday;
            bitsByte11[7] = Main.forceXMasForToday;
            writer.Write((byte) bitsByte11);
            BitsByte bitsByte12 = (BitsByte) (byte) 0;
            bitsByte12[0] = NPC.boughtCat;
            bitsByte12[1] = NPC.boughtDog;
            bitsByte12[2] = NPC.boughtBunny;
            bitsByte12[3] = NPC.freeCake;
            bitsByte12[4] = Main.drunkWorld;
            bitsByte12[5] = NPC.downedEmpressOfLight;
            bitsByte12[6] = NPC.downedQueenSlime;
            bitsByte12[7] = Main.getGoodWorld;
            writer.Write((byte) bitsByte12);
            writer.Write((short) WorldGen.SavedOreTiers.Copper);
            writer.Write((short) WorldGen.SavedOreTiers.Iron);
            writer.Write((short) WorldGen.SavedOreTiers.Silver);
            writer.Write((short) WorldGen.SavedOreTiers.Gold);
            writer.Write((short) WorldGen.SavedOreTiers.Cobalt);
            writer.Write((short) WorldGen.SavedOreTiers.Mythril);
            writer.Write((short) WorldGen.SavedOreTiers.Adamantite);
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
            BitsByte bitsByte13 = (BitsByte) (byte) number2;
            writer.Write((byte) bitsByte13);
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
            Player player3 = Main.player[number];
            writer.Write((byte) number);
            writer.Write((short) player3.SpawnX);
            writer.Write((short) player3.SpawnY);
            writer.Write(player3.respawnTimer);
            writer.Write((byte) number2);
            break;
          case 13:
            Player player4 = Main.player[number];
            writer.Write((byte) number);
            BitsByte bitsByte14 = (BitsByte) (byte) 0;
            bitsByte14[0] = player4.controlUp;
            bitsByte14[1] = player4.controlDown;
            bitsByte14[2] = player4.controlLeft;
            bitsByte14[3] = player4.controlRight;
            bitsByte14[4] = player4.controlJump;
            bitsByte14[5] = player4.controlUseItem;
            bitsByte14[6] = player4.direction == 1;
            writer.Write((byte) bitsByte14);
            BitsByte bitsByte15 = (BitsByte) (byte) 0;
            bitsByte15[0] = player4.pulley;
            bitsByte15[1] = player4.pulley && player4.pulleyDir == (byte) 2;
            bitsByte15[2] = player4.velocity != Vector2.Zero;
            bitsByte15[3] = player4.vortexStealthActive;
            bitsByte15[4] = (double) player4.gravDir == 1.0;
            bitsByte15[5] = player4.shieldRaised;
            bitsByte15[6] = player4.ghost;
            writer.Write((byte) bitsByte15);
            BitsByte bitsByte16 = (BitsByte) (byte) 0;
            bitsByte16[0] = player4.tryKeepingHoveringUp;
            bitsByte16[1] = player4.IsVoidVaultEnabled;
            bitsByte16[2] = player4.sitting.isSitting;
            bitsByte16[3] = player4.downedDD2EventAnyDifficulty;
            bitsByte16[4] = player4.isPettingAnimal;
            bitsByte16[5] = player4.isTheAnimalBeingPetSmall;
            bitsByte16[6] = player4.PotionOfReturnOriginalUsePosition.HasValue;
            bitsByte16[7] = player4.tryKeepingHoveringDown;
            writer.Write((byte) bitsByte16);
            BitsByte bitsByte17 = (BitsByte) (byte) 0;
            bitsByte17[0] = player4.sleeping.isSleeping;
            writer.Write((byte) bitsByte17);
            writer.Write((byte) player4.selectedItem);
            writer.WriteVector2(player4.position);
            if (bitsByte15[2])
              writer.WriteVector2(player4.velocity);
            if (bitsByte16[6])
            {
              writer.WriteVector2(player4.PotionOfReturnOriginalUsePosition.Value);
              writer.WriteVector2(player4.PotionOfReturnHomePosition.Value);
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
                BitsByte bitsByte18 = (BitsByte) (byte) 0;
                BitsByte bitsByte19 = (BitsByte) (byte) 0;
                byte num6 = 0;
                byte num7 = 0;
                Tile tile = Main.tile[index1, index2];
                bitsByte18[0] = tile.active();
                bitsByte18[2] = tile.wall > (ushort) 0;
                bitsByte18[3] = tile.liquid > (byte) 0 && Main.netMode == 2;
                bitsByte18[4] = tile.wire();
                bitsByte18[5] = tile.halfBrick();
                bitsByte18[6] = tile.actuator();
                bitsByte18[7] = tile.inActive();
                bitsByte19[0] = tile.wire2();
                bitsByte19[1] = tile.wire3();
                if (tile.active() && tile.color() > (byte) 0)
                {
                  bitsByte19[2] = true;
                  num6 = tile.color();
                }
                if (tile.wall > (ushort) 0 && tile.wallColor() > (byte) 0)
                {
                  bitsByte19[3] = true;
                  num7 = tile.wallColor();
                }
                bitsByte19 = (BitsByte) (byte) ((uint) (byte) bitsByte19 + (uint) (byte) ((uint) tile.slope() << 4));
                bitsByte19[7] = tile.wire4();
                writer.Write((byte) bitsByte18);
                writer.Write((byte) bitsByte19);
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
                if (tile.wall > (ushort) 0)
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
            writer.Write((byte) Main.item[number].playerIndexTheItemIsReservedFor);
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
            BitsByte bitsByte20 = (BitsByte) (byte) 0;
            bitsByte20[0] = npc1.direction > 0;
            bitsByte20[1] = npc1.directionY > 0;
            bitsByte20[2] = flagArray[0] = (double) npc1.ai[0] != 0.0;
            bitsByte20[3] = flagArray[1] = (double) npc1.ai[1] != 0.0;
            bitsByte20[4] = flagArray[2] = (double) npc1.ai[2] != 0.0;
            bitsByte20[5] = flagArray[3] = (double) npc1.ai[3] != 0.0;
            bitsByte20[6] = npc1.spriteDirection > 0;
            bitsByte20[7] = num9 == npc1.lifeMax;
            writer.Write((byte) bitsByte20);
            BitsByte bitsByte21 = (BitsByte) (byte) 0;
            bitsByte21[0] = npc1.statsAreScaledForThisManyPlayers > 1;
            bitsByte21[1] = npc1.SpawnedFromStatue;
            bitsByte21[2] = (double) npc1.strengthMultiplier != 1.0;
            writer.Write((byte) bitsByte21);
            for (int index = 0; index < NPC.maxAI; ++index)
            {
              if (flagArray[index])
                writer.Write(npc1.ai[index]);
            }
            writer.Write(netId2);
            if (bitsByte21[0])
              writer.Write((byte) npc1.statsAreScaledForThisManyPlayers);
            if (bitsByte21[2])
              writer.Write(npc1.strengthMultiplier);
            if (!bitsByte20[7])
            {
              byte num10 = 1;
              if (npc1.lifeMax > (int) short.MaxValue)
                num10 = (byte) 4;
              else if (npc1.lifeMax > (int) sbyte.MaxValue)
                num10 = (byte) 2;
              writer.Write(num10);
              switch (num10)
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
            if (npc1.type >= 0 && npc1.type < 663 && Main.npcCatchable[npc1.type])
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
            writer.Write((byte) projectile1.owner);
            writer.Write((short) projectile1.type);
            BitsByte bitsByte22 = (BitsByte) (byte) 0;
            for (int key = 0; key < Projectile.maxAI; ++key)
            {
              if ((double) projectile1.ai[key] != 0.0)
                bitsByte22[key] = true;
            }
            if (projectile1.damage != 0)
              bitsByte22[4] = true;
            if ((double) projectile1.knockBack != 0.0)
              bitsByte22[5] = true;
            if (projectile1.type > 0 && projectile1.type < 950 && ProjectileID.Sets.NeedsUUID[projectile1.type])
              bitsByte22[7] = true;
            if (projectile1.originalDamage != 0)
              bitsByte22[6] = true;
            writer.Write((byte) bitsByte22);
            for (int key = 0; key < Projectile.maxAI; ++key)
            {
              if (bitsByte22[key])
                writer.Write(projectile1.ai[key]);
            }
            if (bitsByte22[4])
              writer.Write((short) projectile1.damage);
            if (bitsByte22[5])
              writer.Write(projectile1.knockBack);
            if (bitsByte22[6])
              writer.Write((short) projectile1.originalDamage);
            if (bitsByte22[7])
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
            short num11 = (short) obj3.netID;
            if (obj3.Name == null)
              num11 = (short) 0;
            writer.Write((short) obj3.stack);
            writer.Write(obj3.prefix);
            writer.Write(num11);
            break;
          case 33:
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            string str1 = (string) null;
            if (number > -1)
            {
              num12 = Main.chest[number].x;
              num13 = Main.chest[number].y;
            }
            if ((double) number2 == 1.0)
            {
              string str2 = text.ToString();
              num14 = (int) (byte) str2.Length;
              if (num14 == 0 || num14 > 20)
                num14 = (int) byte.MaxValue;
              else
                str1 = str2;
            }
            writer.Write((short) number);
            writer.Write((short) num12);
            writer.Write((short) num13);
            writer.Write((byte) num14);
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
            writer.Write((byte) number);
            writer.Write((short) number2);
            break;
          case 36:
            Player player5 = Main.player[number];
            writer.Write((byte) number);
            writer.Write((byte) player5.zone1);
            writer.Write((byte) player5.zone2);
            writer.Write((byte) player5.zone3);
            writer.Write((byte) player5.zone4);
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
            writer.Write((byte) number3);
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
              writer.Write((ushort) Main.player[number].buffType[index]);
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
            writer.Write((ushort) number2);
            writer.Write((short) number3);
            break;
          case 54:
            writer.Write((short) number);
            for (int index = 0; index < 5; ++index)
            {
              writer.Write((ushort) Main.npc[number].buffType[index]);
              writer.Write((short) Main.npc[number].buffTime[index]);
            }
            break;
          case 55:
            writer.Write((byte) number);
            writer.Write((ushort) number2);
            writer.Write((int) number3);
            break;
          case 56:
            writer.Write((short) number);
            if (Main.netMode == 2)
            {
              string givenName = Main.npc[number].GivenName;
              writer.Write(givenName);
              writer.Write(Main.npc[number].townNpcVariationIndex);
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
            BitsByte bitsByte23 = (BitsByte) (byte) 0;
            bitsByte23[0] = (number & 1) == 1;
            bitsByte23[1] = (number & 2) == 2;
            bitsByte23[2] = number6 == 1;
            bitsByte23[3] = (uint) number7 > 0U;
            writer.Write((byte) bitsByte23);
            writer.Write((short) number2);
            writer.Write(number3);
            writer.Write(number4);
            writer.Write((byte) number5);
            if (bitsByte23[3])
            {
              writer.Write(number7);
              break;
            }
            break;
          case 66:
            writer.Write((byte) number);
            writer.Write((short) number2);
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
          case 73:
            writer.Write((byte) number);
            break;
          case 74:
            writer.Write((byte) Main.anglerQuest);
            bool flag1 = Main.anglerWhoFinishedToday.Contains(text.ToString());
            writer.Write(flag1);
            break;
          case 76:
            writer.Write((byte) number);
            writer.Write(Main.player[number].anglerQuestsFinished);
            writer.Write(Main.player[number].golferScoreAccumulated);
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
            if (index3 < 0 && index3 >= 289)
              index3 = 1;
            int num15 = NPC.killCount[index3];
            writer.Write((short) index3);
            writer.Write(num15);
            break;
          case 84:
            byte num16 = (byte) number;
            float stealth = Main.player[(int) num16].stealth;
            writer.Write(num16);
            writer.Write(stealth);
            break;
          case 85:
            byte num17 = (byte) number;
            writer.Write(num17);
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
            BitsByte bitsByte24 = (BitsByte) (byte) number2;
            BitsByte bitsByte25 = (BitsByte) (byte) number3;
            writer.Write((short) number);
            writer.Write((byte) bitsByte24);
            Item obj4 = Main.item[number];
            if (bitsByte24[0])
              writer.Write(obj4.color.PackedValue);
            if (bitsByte24[1])
              writer.Write((ushort) obj4.damage);
            if (bitsByte24[2])
              writer.Write(obj4.knockBack);
            if (bitsByte24[3])
              writer.Write((ushort) obj4.useAnimation);
            if (bitsByte24[4])
              writer.Write((ushort) obj4.useTime);
            if (bitsByte24[5])
              writer.Write((short) obj4.shoot);
            if (bitsByte24[6])
              writer.Write(obj4.shootSpeed);
            if (bitsByte24[7])
            {
              writer.Write((byte) bitsByte25);
              if (bitsByte25[0])
                writer.Write((ushort) obj4.width);
              if (bitsByte25[1])
                writer.Write((ushort) obj4.height);
              if (bitsByte25[2])
                writer.Write(obj4.scale);
              if (bitsByte25[3])
                writer.Write((short) obj4.ammo);
              if (bitsByte25[4])
                writer.Write((short) obj4.useAmmo);
              if (bitsByte25[5])
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
            writer.Write((short) number5);
            break;
          case 91:
            writer.Write(number);
            writer.Write((byte) number2);
            if ((double) number2 != (double) byte.MaxValue)
            {
              writer.Write((ushort) number3);
              writer.Write((ushort) number4);
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
            writer.Write((int) number2);
            writer.Write(number3);
            writer.Write(number4);
            break;
          case 95:
            writer.Write((ushort) number);
            writer.Write((byte) number2);
            break;
          case 96:
            writer.Write((byte) number);
            Player player6 = Main.player[number];
            writer.Write((short) number4);
            writer.Write(number2);
            writer.Write(number3);
            writer.WriteVector2(player6.velocity);
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
            writer.Write((ushort) number2);
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
            writer.Write((int) number2);
            writer.Write((int) number3);
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
          case 120:
            writer.Write((byte) number);
            writer.Write((byte) number2);
            break;
          case 121:
            int num18 = (int) number3;
            bool dye1 = (double) number4 == 1.0;
            if (dye1)
              num18 += 8;
            writer.Write((byte) number);
            writer.Write((int) number2);
            writer.Write((byte) num18);
            if (TileEntity.ByID[(int) number2] is TEDisplayDoll teDisplayDoll3)
            {
              teDisplayDoll3.WriteItem((int) number3, writer, dye1);
              break;
            }
            writer.Write(0);
            writer.Write((byte) 0);
            break;
          case 122:
            writer.Write(number);
            writer.Write((byte) number2);
            break;
          case 123:
            writer.Write((short) number);
            writer.Write((short) number2);
            Item obj6 = Main.player[(int) number4].inventory[(int) number3];
            writer.Write((short) obj6.netID);
            writer.Write(obj6.prefix);
            writer.Write((short) number5);
            break;
          case 124:
            int num19 = (int) number3;
            bool dye2 = (double) number4 == 1.0;
            if (dye2)
              num19 += 2;
            writer.Write((byte) number);
            writer.Write((int) number2);
            writer.Write((byte) num19);
            if (TileEntity.ByID[(int) number2] is TEHatRack teHatRack3)
            {
              teHatRack3.WriteItem((int) number3, writer, dye2);
              break;
            }
            writer.Write(0);
            writer.Write((byte) 0);
            break;
          case 125:
            writer.Write((byte) number);
            writer.Write((short) number2);
            writer.Write((short) number3);
            writer.Write((byte) number4);
            break;
          case 126:
            NetMessage._currentRevengeMarker.WriteSelfTo(writer);
            break;
          case (int) sbyte.MaxValue:
            writer.Write(number);
            break;
          case 128:
            writer.Write((byte) number);
            writer.Write((ushort) number5);
            writer.Write((ushort) number6);
            writer.Write((ushort) number2);
            writer.Write((ushort) number3);
            break;
          case 130:
            writer.Write((ushort) number);
            writer.Write((ushort) number2);
            writer.Write((short) number3);
            break;
          case 131:
            writer.Write((ushort) number);
            writer.Write((byte) number2);
            if ((byte) number2 == (byte) 1)
            {
              writer.Write((int) number3);
              writer.Write((short) number4);
              break;
            }
            break;
          case 132:
            NetMessage._currentNetSoundInfo.WriteSelfTo(writer);
            break;
          case 133:
            writer.Write((short) number);
            writer.Write((short) number2);
            Item obj7 = Main.player[(int) number4].inventory[(int) number3];
            writer.Write((short) obj7.netID);
            writer.Write(obj7.prefix);
            writer.Write((short) number5);
            break;
          case 134:
            writer.Write((byte) number);
            Player player7 = Main.player[number];
            writer.Write(player7.ladyBugLuckTimeLeft);
            writer.Write(player7.torchLuck);
            writer.Write(player7.luckPotion);
            writer.Write(player7.HasGardenGnomeNearby);
            break;
          case 135:
            writer.Write((byte) number);
            break;
          case 136:
            for (int index4 = 0; index4 < 2; ++index4)
            {
              for (int index5 = 0; index5 < 3; ++index5)
                writer.Write((ushort) NPC.cavernMonsterType[index4, index5]);
            }
            break;
          case 137:
            writer.Write((short) number);
            writer.Write((ushort) number2);
            break;
          case 139:
            writer.Write((byte) number);
            bool flag3 = (double) number2 == 1.0;
            writer.Write(flag3);
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
              Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
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
              for (int index6 = 0; index6 < 256; ++index6)
              {
                if (index6 != ignoreClient && NetMessage.buffer[index6].broadcast)
                {
                  if (Netplay.Clients[index6].IsConnected())
                  {
                    try
                    {
                      ++NetMessage.buffer[index6].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index6].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index6].ServerWriteCallBack));
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
              for (int index7 = 0; index7 < 256; ++index7)
              {
                if (index7 != ignoreClient && NetMessage.buffer[index7].broadcast && Netplay.Clients[index7].IsConnected())
                {
                  if (Netplay.Clients[index7].SectionRange(number, (int) number2, (int) number3))
                  {
                    try
                    {
                      ++NetMessage.buffer[index7].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index7].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index7].ServerWriteCallBack));
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
              for (int index8 = 0; index8 < 256; ++index8)
              {
                if (index8 != ignoreClient && NetMessage.buffer[index8].broadcast && Netplay.Clients[index8].IsConnected())
                {
                  bool flag4 = false;
                  if (npc3.boss || npc3.netAlways || npc3.townNPC || !npc3.active)
                    flag4 = true;
                  else if (npc3.netSkip <= 0)
                  {
                    Rectangle rect1 = Main.player[index8].getRect();
                    Rectangle rect2 = npc3.getRect();
                    rect2.X -= 2500;
                    rect2.Y -= 2500;
                    rect2.Width += 5000;
                    rect2.Height += 5000;
                    if (rect1.Intersects(rect2))
                      flag4 = true;
                  }
                  else
                    flag4 = true;
                  if (flag4)
                  {
                    try
                    {
                      ++NetMessage.buffer[index8].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index8].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index8].ServerWriteCallBack));
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
              for (int index9 = 0; index9 < 256; ++index9)
              {
                if (index9 != ignoreClient && NetMessage.buffer[index9].broadcast && Netplay.Clients[index9].IsConnected())
                {
                  bool flag5 = false;
                  if (projectile2.type == 12 || Main.projPet[projectile2.type] || projectile2.aiStyle == 11 || projectile2.netImportant)
                  {
                    flag5 = true;
                  }
                  else
                  {
                    Rectangle rect3 = Main.player[index9].getRect();
                    Rectangle rect4 = projectile2.getRect();
                    rect4.X -= 5000;
                    rect4.Y -= 5000;
                    rect4.Width += 10000;
                    rect4.Height += 10000;
                    if (rect3.Intersects(rect4))
                      flag5 = true;
                  }
                  if (flag5)
                  {
                    try
                    {
                      ++NetMessage.buffer[index9].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index9].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index9].ServerWriteCallBack));
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
              for (int index10 = 0; index10 < 256; ++index10)
              {
                if (index10 != ignoreClient && NetMessage.buffer[index10].broadcast && Netplay.Clients[index10].IsConnected())
                {
                  bool flag6 = false;
                  if (npc4.life <= 0)
                  {
                    flag6 = true;
                  }
                  else
                  {
                    Rectangle rect5 = Main.player[index10].getRect();
                    Rectangle rect6 = npc4.getRect();
                    rect6.X -= 3000;
                    rect6.Y -= 3000;
                    rect6.Width += 6000;
                    rect6.Height += 6000;
                    if (rect5.Intersects(rect6))
                      flag6 = true;
                  }
                  if (flag6)
                  {
                    try
                    {
                      ++NetMessage.buffer[index10].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index10].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index10].ServerWriteCallBack));
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
              for (int index11 = 0; index11 < 256; ++index11)
              {
                if (index11 != ignoreClient && NetMessage.buffer[index11].broadcast)
                {
                  if (Netplay.Clients[index11].IsConnected())
                  {
                    try
                    {
                      ++NetMessage.buffer[index11].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index11].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index11].ServerWriteCallBack));
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            default:
              for (int index12 = 0; index12 < 256; ++index12)
              {
                if (index12 != ignoreClient && (NetMessage.buffer[index12].broadcast || Netplay.Clients[index12].State >= 3 && msgType == 10))
                {
                  if (Netplay.Clients[index12].IsConnected())
                  {
                    try
                    {
                      ++NetMessage.buffer[index12].spamCount;
                      Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
                      Netplay.Clients[index12].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[index12].ServerWriteCallBack));
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
            Main.ActiveNetDiagnosticsUI.CountSentMessage(msgType, position2);
            Netplay.Clients[remoteClient].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, position2, new SocketSendCallback(Netplay.Clients[remoteClient].ServerWriteCallBack));
          }
          catch
          {
          }
        }
        if (Main.verboseNetplay)
        {
          int num20 = 0;
          while (num20 < position2)
            ++num20;
          for (int index13 = 0; index13 < position2; ++index13)
          {
            int num21 = (int) NetMessage.buffer[whoAmi].writeBuffer[index13];
          }
        }
        NetMessage.buffer[whoAmi].writeLocked = false;
        if (msgType == 19 && Main.netMode == 1)
          NetMessage.SendTileSquare(whoAmi, (int) number2, (int) number3, 5);
        if (msgType != 2 || Main.netMode != 2)
          return;
        Netplay.Clients[whoAmi].PendingTermination = true;
        Netplay.Clients[whoAmi].PendingTerminationApproved = true;
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
      short[] numArray1 = new short[8000];
      short[] numArray2 = new short[1000];
      short[] numArray3 = new short[1000];
      short num1 = 0;
      short num2 = 0;
      short num3 = 0;
      short num4 = 0;
      int index1 = 0;
      int index2 = 0;
      byte num5 = 0;
      byte[] buffer = new byte[15];
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
              if (tile.type == (ushort) 573 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num12 = (short) Sign.ReadSign(index4, index3);
                if (num12 != (short) -1)
                  numArray2[(int) num2++] = num12;
              }
              if (tile.type == (ushort) 378 && (int) tile.frameX % 36 == 0 && tile.frameY == (short) 0)
              {
                int num13 = TETrainingDummy.Find(index4, index3);
                if (num13 != -1)
                  numArray3[(int) num3++] = (short) num13;
              }
              if (tile.type == (ushort) 395 && (int) tile.frameX % 36 == 0 && tile.frameY == (short) 0)
              {
                int num14 = TEItemFrame.Find(index4, index3);
                if (num14 != -1)
                  numArray3[(int) num3++] = (short) num14;
              }
              if (tile.type == (ushort) 520 && (int) tile.frameX % 18 == 0 && tile.frameY == (short) 0)
              {
                int num15 = TEFoodPlatter.Find(index4, index3);
                if (num15 != -1)
                  numArray3[(int) num3++] = (short) num15;
              }
              if (tile.type == (ushort) 471 && (int) tile.frameX % 54 == 0 && tile.frameY == (short) 0)
              {
                int num16 = TEWeaponsRack.Find(index4, index3);
                if (num16 != -1)
                  numArray3[(int) num3++] = (short) num16;
              }
              if (tile.type == (ushort) 470 && (int) tile.frameX % 36 == 0 && tile.frameY == (short) 0)
              {
                int num17 = TEDisplayDoll.Find(index4, index3);
                if (num17 != -1)
                  numArray3[(int) num3++] = (short) num17;
              }
              if (tile.type == (ushort) 475 && (int) tile.frameX % 54 == 0 && tile.frameY == (short) 0)
              {
                int num18 = TEHatRack.Find(index4, index3);
                if (num18 != -1)
                  numArray3[(int) num3++] = (short) num18;
              }
              if (tile.type == (ushort) 597 && (int) tile.frameX % 54 == 0 && (int) tile.frameY % 72 == 0)
              {
                int num19 = TETeleportationPylon.Find(index4, index3);
                if (num19 != -1)
                  numArray3[(int) num3++] = (short) num19;
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
            if (tile.wall != (ushort) 0)
            {
              num5 |= (byte) 4;
              buffer[index1] = (byte) tile.wall;
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
            int num20 = !tile.halfBrick() ? (tile.slope() == (byte) 0 ? 0 : (int) tile.slope() + 1 << 4) : 16;
            byte num21 = (byte) ((uint) num8 | (uint) (byte) num20);
            if (tile.actuator())
              num7 |= (byte) 2;
            if (tile.inActive())
              num7 |= (byte) 4;
            if (tile.wire4())
              num7 |= (byte) 32;
            if (tile.wall > (ushort) byte.MaxValue)
            {
              buffer[index1] = (byte) ((uint) tile.wall >> 8);
              ++index1;
              num7 |= (byte) 64;
            }
            index2 = 2;
            if (num7 != (byte) 0)
            {
              num21 |= (byte) 1;
              buffer[index2] = num7;
              --index2;
            }
            if (num21 != (byte) 0)
            {
              num5 |= (byte) 1;
              buffer[index2] = num21;
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
              tile.wall = (ushort) reader.ReadByte();
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
              if (((int) num2 & 64) == 64)
              {
                byte num8 = reader.ReadByte();
                tile.wall = (ushort) ((uint) num8 << 8 | (uint) tile.wall);
              }
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
      short num9 = reader.ReadInt16();
      for (int index = 0; index < (int) num9; ++index)
      {
        short num10 = reader.ReadInt16();
        short num11 = reader.ReadInt16();
        short num12 = reader.ReadInt16();
        string str = reader.ReadString();
        if (num10 >= (short) 0 && num10 < (short) 8000)
        {
          if (Main.chest[(int) num10] == null)
            Main.chest[(int) num10] = new Chest();
          Main.chest[(int) num10].name = str;
          Main.chest[(int) num10].x = (int) num11;
          Main.chest[(int) num10].y = (int) num12;
        }
      }
      short num13 = reader.ReadInt16();
      for (int index = 0; index < (int) num13; ++index)
      {
        short num14 = reader.ReadInt16();
        short num15 = reader.ReadInt16();
        short num16 = reader.ReadInt16();
        string str = reader.ReadString();
        if (num14 >= (short) 0 && num14 < (short) 1000)
        {
          if (Main.sign[(int) num14] == null)
            Main.sign[(int) num14] = new Sign();
          Main.sign[(int) num14].text = str;
          Main.sign[(int) num14].x = (int) num15;
          Main.sign[(int) num14].y = (int) num16;
        }
      }
      short num17 = reader.ReadInt16();
      for (int index = 0; index < (int) num17; ++index)
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
            Netplay.Disconnect = true;
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
        catch (Exception ex)
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

    public static void PlayNetSound(
      NetMessage.NetSoundInfo info,
      int remoteClient = -1,
      int ignoreClient = -1)
    {
      NetMessage._currentNetSoundInfo = info;
      NetMessage.SendData(132, remoteClient, ignoreClient);
    }

    public static void SendCoinLossRevengeMarker(
      CoinLossRevengeSystem.RevengeMarker marker,
      int remoteClient = -1,
      int ignoreClient = -1)
    {
      NetMessage._currentRevengeMarker = marker;
      NetMessage.SendData(126, remoteClient, ignoreClient);
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
      WorldGen.RangeFrame(tileX - num, tileY - num, tileX - num + size, tileY - num + size);
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
        ChatHelper.SendChatMessageToClient(NetworkText.FromFormattable("{0} {1}!", (object) Lang.mp[18].ToNetworkText(), (object) Main.worldName), new Color((int) byte.MaxValue, 240, 20), plr);
      else
        ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(Main.motd), new Color((int) byte.MaxValue, 240, 20), plr);
      string str = "";
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
          str = !(str == "") ? str + ", " + Main.player[index].name : str + Main.player[index].name;
      }
      ChatHelper.SendChatMessageToClient(NetworkText.FromKey("Game.JoinGreeting", (object) str), new Color((int) byte.MaxValue, 240, 20), plr);
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
      NPC.RevengeManager.SendAllMarkersToPlayer(plr);
      NetMessage.EnsureLocalPlayerIsPresent();
    }

    private static void SendNPCHousesAndTravelShop(int plr)
    {
      bool flag = false;
      for (int number = 0; number < 200; ++number)
      {
        if (Main.npc[number].active && Main.npc[number].townNPC && NPC.TypeToDefaultHeadIndex(Main.npc[number].type) > 0)
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
      for (int plr = 0; plr < (int) byte.MaxValue; ++plr)
      {
        if (NetMessage.DoesPlayerSlotCountAsAHost(plr))
        {
          flag = true;
          break;
        }
      }
      if (flag)
        return;
      Console.WriteLine(Language.GetTextValue("Net.ServerAutoShutdown"));
      WorldFile.SaveWorld();
      Netplay.Disconnect = true;
    }

    public static bool DoesPlayerSlotCountAsAHost(int plr) => Netplay.Clients[plr].State == 10 && Netplay.Clients[plr].Socket.GetRemoteAddress().IsLocalHost();

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
        if (Main.player[plr].statLife <= 0)
          NetMessage.SendData(135, toWho, fromWho, number: plr);
        NetMessage.SendData(16, toWho, fromWho, number: plr);
        NetMessage.SendData(30, toWho, fromWho, number: plr);
        NetMessage.SendData(45, toWho, fromWho, number: plr);
        NetMessage.SendData(42, toWho, fromWho, number: plr);
        NetMessage.SendData(50, toWho, fromWho, number: plr);
        NetMessage.SendData(80, toWho, fromWho, number: plr, number2: ((float) Main.player[plr].chest));
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
        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(Lang.mp[19].Key, (object) Main.player[plr].name), new Color((int) byte.MaxValue, 240, 20), plr);
        if (!Main.dedServ)
          return;
        Console.WriteLine(Lang.mp[19].Format((object) Main.player[plr].name));
      }
      else
      {
        int num2 = 0;
        NetMessage.SendData(14, ignoreClient: plr, number: plr, number2: ((float) num2));
        if (Netplay.Clients[plr].IsAnnouncementCompleted)
        {
          Netplay.Clients[plr].IsAnnouncementCompleted = false;
          ChatHelper.BroadcastChatMessage(NetworkText.FromKey(Lang.mp[20].Key, (object) Netplay.Clients[plr].Name), new Color((int) byte.MaxValue, 240, 20), plr);
          if (Main.dedServ)
            Console.WriteLine(Lang.mp[20].Format((object) Netplay.Clients[plr].Name));
          Netplay.Clients[plr].Name = "Anonymous";
        }
        Player.Hooks.PlayerDisconnect(plr);
      }
    }

    public struct NetSoundInfo
    {
      public Vector2 position;
      public ushort soundIndex;
      public int style;
      public float volume;
      public float pitchOffset;

      public NetSoundInfo(
        Vector2 position,
        ushort soundIndex,
        int style = -1,
        float volume = -1f,
        float pitchOffset = -1f)
      {
        this.position = position;
        this.soundIndex = soundIndex;
        this.style = style;
        this.volume = volume;
        this.pitchOffset = pitchOffset;
      }

      public void WriteSelfTo(BinaryWriter writer)
      {
        writer.WriteVector2(this.position);
        writer.Write(this.soundIndex);
        BitsByte bitsByte = new BitsByte(this.style != -1, (double) this.volume != -1.0, (double) this.pitchOffset != -1.0);
        writer.Write((byte) bitsByte);
        if (bitsByte[0])
          writer.Write(this.style);
        if (bitsByte[1])
          writer.Write(this.volume);
        if (!bitsByte[2])
          return;
        writer.Write(this.pitchOffset);
      }
    }
  }
}
