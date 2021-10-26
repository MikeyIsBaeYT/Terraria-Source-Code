// Decompiled with JetBrains decompiler
// Type: Terraria.NetMessage
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Text;

namespace Terraria
{
  public class NetMessage
  {
    public static messageBuffer[] buffer = new messageBuffer[257];

    public static void SendData(
      int msgType,
      int remoteClient = -1,
      int ignoreClient = -1,
      string text = "",
      int number = 0,
      float number2 = 0.0f,
      float number3 = 0.0f,
      float number4 = 0.0f,
      int number5 = 0)
    {
      int whoAmi = 256;
      if (Main.netMode == 2 && remoteClient >= 0)
        whoAmi = remoteClient;
      lock (NetMessage.buffer[whoAmi])
      {
        int count = 5;
        int dstOffset1 = count;
        int num1;
        switch (msgType)
        {
          case 1:
            byte[] bytes1 = BitConverter.GetBytes(msgType);
            byte[] bytes2 = Encoding.UTF8.GetBytes("Terraria" + (object) Main.curRelease);
            count += bytes2.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes1, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes2, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 5, bytes2.Length);
            break;
          case 2:
            byte[] bytes3 = BitConverter.GetBytes(msgType);
            byte[] bytes4 = Encoding.UTF8.GetBytes(text);
            count += bytes4.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes3, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes4, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 5, bytes4.Length);
            if (Main.dedServ)
            {
              Console.WriteLine(Netplay.serverSock[whoAmi].tcpClient.Client.RemoteEndPoint.ToString() + " was booted: " + text);
              break;
            }
            break;
          case 3:
            byte[] bytes5 = BitConverter.GetBytes(msgType);
            byte[] bytes6 = BitConverter.GetBytes(remoteClient);
            count += bytes6.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes5, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes6, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 5, bytes6.Length);
            break;
          case 4:
            byte[] bytes7 = BitConverter.GetBytes(msgType);
            byte num2 = (byte) number;
            byte hair = (byte) Main.player[(int) num2].hair;
            byte num3 = 0;
            if (Main.player[(int) num2].male)
              num3 = (byte) 1;
            byte[] bytes8 = Encoding.UTF8.GetBytes(text);
            count += 24 + bytes8.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes7, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num2;
            int num4 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[6] = hair;
            int num5 = num4 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[7] = num3;
            int index1 = num5 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index1] = Main.player[(int) num2].hairColor.R;
            int index2 = index1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index2] = Main.player[(int) num2].hairColor.G;
            int index3 = index2 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index3] = Main.player[(int) num2].hairColor.B;
            int index4 = index3 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index4] = Main.player[(int) num2].skinColor.R;
            int index5 = index4 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index5] = Main.player[(int) num2].skinColor.G;
            int index6 = index5 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index6] = Main.player[(int) num2].skinColor.B;
            int index7 = index6 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index7] = Main.player[(int) num2].eyeColor.R;
            int index8 = index7 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index8] = Main.player[(int) num2].eyeColor.G;
            int index9 = index8 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index9] = Main.player[(int) num2].eyeColor.B;
            int index10 = index9 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index10] = Main.player[(int) num2].shirtColor.R;
            int index11 = index10 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index11] = Main.player[(int) num2].shirtColor.G;
            int index12 = index11 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index12] = Main.player[(int) num2].shirtColor.B;
            int index13 = index12 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index13] = Main.player[(int) num2].underShirtColor.R;
            int index14 = index13 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index14] = Main.player[(int) num2].underShirtColor.G;
            int index15 = index14 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index15] = Main.player[(int) num2].underShirtColor.B;
            int index16 = index15 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index16] = Main.player[(int) num2].pantsColor.R;
            int index17 = index16 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index17] = Main.player[(int) num2].pantsColor.G;
            int index18 = index17 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index18] = Main.player[(int) num2].pantsColor.B;
            int index19 = index18 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index19] = Main.player[(int) num2].shoeColor.R;
            int index20 = index19 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index20] = Main.player[(int) num2].shoeColor.G;
            int index21 = index20 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index21] = Main.player[(int) num2].shoeColor.B;
            int index22 = index21 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index22] = Main.player[(int) num2].difficulty;
            int dstOffset2 = index22 + 1;
            Buffer.BlockCopy((Array) bytes8, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset2, bytes8.Length);
            break;
          case 5:
            byte[] bytes9 = BitConverter.GetBytes(msgType);
            byte num6 = (byte) number;
            byte num7 = (byte) number2;
            byte num8;
            byte[] bytes10;
            if ((double) number2 < 49.0)
            {
              if (Main.player[number].inventory[(int) number2].name == "" || Main.player[number].inventory[(int) number2].stack == 0 || Main.player[number].inventory[(int) number2].type == 0)
                Main.player[number].inventory[(int) number2].netID = 0;
              num8 = (byte) Main.player[number].inventory[(int) number2].stack;
              bytes10 = BitConverter.GetBytes((short) Main.player[number].inventory[(int) number2].netID);
              if (Main.player[number].inventory[(int) number2].stack < 0)
                num8 = (byte) 0;
            }
            else
            {
              if (Main.player[number].armor[(int) number2 - 48 - 1].name == "" || Main.player[number].armor[(int) number2 - 48 - 1].stack == 0 || Main.player[number].armor[(int) number2 - 48 - 1].type == 0)
                Main.player[number].armor[(int) number2 - 48 - 1].SetDefaults(0);
              num8 = (byte) Main.player[number].armor[(int) number2 - 48 - 1].stack;
              bytes10 = BitConverter.GetBytes((short) Main.player[number].armor[(int) number2 - 48 - 1].netID);
              if (Main.player[number].armor[(int) number2 - 48 - 1].stack < 0)
                num8 = (byte) 0;
            }
            byte num9 = (byte) number3;
            count += 4 + bytes10.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes9, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num6;
            int num10 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[6] = num7;
            int num11 = num10 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[7] = num8;
            int num12 = num11 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[8] = num9;
            int dstOffset3 = num12 + 1;
            Buffer.BlockCopy((Array) bytes10, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset3, bytes10.Length);
            break;
          case 6:
            byte[] bytes11 = BitConverter.GetBytes(msgType);
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes11, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            break;
          case 7:
            byte[] bytes12 = BitConverter.GetBytes(msgType);
            byte[] bytes13 = BitConverter.GetBytes((int) Main.time);
            byte num13 = 0;
            if (Main.dayTime)
              num13 = (byte) 1;
            byte moonPhase = (byte) Main.moonPhase;
            byte num14 = 0;
            if (Main.bloodMoon)
              num14 = (byte) 1;
            byte[] bytes14 = BitConverter.GetBytes(Main.maxTilesX);
            byte[] bytes15 = BitConverter.GetBytes(Main.maxTilesY);
            byte[] bytes16 = BitConverter.GetBytes(Main.spawnTileX);
            byte[] bytes17 = BitConverter.GetBytes(Main.spawnTileY);
            byte[] bytes18 = BitConverter.GetBytes((int) Main.worldSurface);
            byte[] bytes19 = BitConverter.GetBytes((int) Main.rockLayer);
            byte[] bytes20 = BitConverter.GetBytes(Main.worldID);
            byte[] bytes21 = Encoding.UTF8.GetBytes(Main.worldName);
            byte num15 = 0;
            if (WorldGen.shadowOrbSmashed)
              ++num15;
            if (NPC.downedBoss1)
              num15 += (byte) 2;
            if (NPC.downedBoss2)
              num15 += (byte) 4;
            if (NPC.downedBoss3)
              num15 += (byte) 8;
            if (Main.hardMode)
              num15 += (byte) 16;
            if (NPC.downedClown)
              num15 += (byte) 32;
            count += bytes13.Length + 1 + 1 + 1 + bytes14.Length + bytes15.Length + bytes16.Length + bytes17.Length + bytes18.Length + bytes19.Length + bytes20.Length + 1 + bytes21.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes12, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes13, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 5, bytes13.Length);
            int index23 = dstOffset1 + bytes13.Length;
            NetMessage.buffer[whoAmi].writeBuffer[index23] = num13;
            int index24 = index23 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index24] = moonPhase;
            int index25 = index24 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index25] = num14;
            int dstOffset4 = index25 + 1;
            Buffer.BlockCopy((Array) bytes14, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset4, bytes14.Length);
            int dstOffset5 = dstOffset4 + bytes14.Length;
            Buffer.BlockCopy((Array) bytes15, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset5, bytes15.Length);
            int dstOffset6 = dstOffset5 + bytes15.Length;
            Buffer.BlockCopy((Array) bytes16, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset6, bytes16.Length);
            int dstOffset7 = dstOffset6 + bytes16.Length;
            Buffer.BlockCopy((Array) bytes17, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset7, bytes17.Length);
            int dstOffset8 = dstOffset7 + bytes17.Length;
            Buffer.BlockCopy((Array) bytes18, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset8, bytes18.Length);
            int dstOffset9 = dstOffset8 + bytes18.Length;
            Buffer.BlockCopy((Array) bytes19, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset9, bytes19.Length);
            int dstOffset10 = dstOffset9 + bytes19.Length;
            Buffer.BlockCopy((Array) bytes20, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset10, bytes20.Length);
            int index26 = dstOffset10 + bytes20.Length;
            NetMessage.buffer[whoAmi].writeBuffer[index26] = num15;
            int dstOffset11 = index26 + 1;
            Buffer.BlockCopy((Array) bytes21, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset11, bytes21.Length);
            num1 = dstOffset11 + bytes21.Length;
            break;
          case 8:
            byte[] bytes22 = BitConverter.GetBytes(msgType);
            byte[] bytes23 = BitConverter.GetBytes(number);
            byte[] bytes24 = BitConverter.GetBytes((int) number2);
            count += bytes23.Length + bytes24.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes22, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes23, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, 4);
            int dstOffset12 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes24, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset12, 4);
            break;
          case 9:
            byte[] bytes25 = BitConverter.GetBytes(msgType);
            byte[] bytes26 = BitConverter.GetBytes(number);
            byte[] bytes27 = Encoding.UTF8.GetBytes(text);
            count += bytes26.Length + bytes27.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes25, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes26, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, 4);
            int dstOffset13 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes27, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset13, bytes27.Length);
            break;
          case 10:
            short num16 = (short) number;
            int num17 = (int) number2;
            int index27 = (int) number3;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(msgType), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) BitConverter.GetBytes(num16), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, 2);
            int dstOffset14 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(num17), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset14, 4);
            int dstOffset15 = dstOffset14 + 4;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(index27), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset15, 4);
            int index28 = dstOffset15 + 4;
            short num18;
            for (int index29 = num17; index29 < num17 + (int) num16; index29 = index29 + (int) num18 + 1)
            {
              byte num19 = 0;
              if (Main.tile[index29, index27].active)
                ++num19;
              if (Main.tile[index29, index27].wall > (byte) 0)
                num19 += (byte) 4;
              if (Main.tile[index29, index27].liquid > (byte) 0)
                num19 += (byte) 8;
              if (Main.tile[index29, index27].wire)
                num19 += (byte) 16;
              NetMessage.buffer[whoAmi].writeBuffer[index28] = num19;
              int dstOffset16 = index28 + 1;
              byte[] bytes28 = BitConverter.GetBytes(Main.tile[index29, index27].frameX);
              byte[] bytes29 = BitConverter.GetBytes(Main.tile[index29, index27].frameY);
              byte wall = Main.tile[index29, index27].wall;
              if (Main.tile[index29, index27].active)
              {
                NetMessage.buffer[whoAmi].writeBuffer[dstOffset16] = Main.tile[index29, index27].type;
                ++dstOffset16;
                if (Main.tileFrameImportant[(int) Main.tile[index29, index27].type])
                {
                  Buffer.BlockCopy((Array) bytes28, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset16, 2);
                  int dstOffset17 = dstOffset16 + 2;
                  Buffer.BlockCopy((Array) bytes29, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset17, 2);
                  dstOffset16 = dstOffset17 + 2;
                }
              }
              if (wall > (byte) 0)
              {
                NetMessage.buffer[whoAmi].writeBuffer[dstOffset16] = wall;
                ++dstOffset16;
              }
              if (Main.tile[index29, index27].liquid > (byte) 0)
              {
                NetMessage.buffer[whoAmi].writeBuffer[dstOffset16] = Main.tile[index29, index27].liquid;
                int index30 = dstOffset16 + 1;
                byte num20 = 0;
                if (Main.tile[index29, index27].lava)
                  num20 = (byte) 1;
                NetMessage.buffer[whoAmi].writeBuffer[index30] = num20;
                dstOffset16 = index30 + 1;
              }
              short num21 = 1;
              while (index29 + (int) num21 < num17 + (int) num16 && Main.tile[index29, index27].isTheSameAs(Main.tile[index29 + (int) num21, index27]))
                ++num21;
              num18 = (short) ((int) num21 - 1);
              Buffer.BlockCopy((Array) BitConverter.GetBytes(num18), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset16, 2);
              index28 = dstOffset16 + 2;
            }
            Buffer.BlockCopy((Array) BitConverter.GetBytes(index28 - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            count = index28;
            break;
          case 11:
            byte[] bytes30 = BitConverter.GetBytes(msgType);
            byte[] bytes31 = BitConverter.GetBytes(number);
            byte[] bytes32 = BitConverter.GetBytes((int) number2);
            byte[] bytes33 = BitConverter.GetBytes((int) number3);
            byte[] bytes34 = BitConverter.GetBytes((int) number4);
            count += bytes31.Length + bytes32.Length + bytes33.Length + bytes34.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes30, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes31, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, 4);
            int dstOffset18 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes32, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset18, 4);
            int dstOffset19 = dstOffset18 + 4;
            Buffer.BlockCopy((Array) bytes33, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset19, 4);
            int dstOffset20 = dstOffset19 + 4;
            Buffer.BlockCopy((Array) bytes34, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset20, 4);
            num1 = dstOffset20 + 4;
            break;
          case 12:
            byte[] bytes35 = BitConverter.GetBytes(msgType);
            byte num22 = (byte) number;
            byte[] bytes36 = BitConverter.GetBytes(Main.player[(int) num22].SpawnX);
            byte[] bytes37 = BitConverter.GetBytes(Main.player[(int) num22].SpawnY);
            count += 1 + bytes36.Length + bytes37.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes35, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num22;
            int dstOffset21 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes36, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset21, 4);
            int dstOffset22 = dstOffset21 + 4;
            Buffer.BlockCopy((Array) bytes37, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset22, 4);
            num1 = dstOffset22 + 4;
            break;
          case 13:
            byte[] bytes38 = BitConverter.GetBytes(msgType);
            byte num23 = (byte) number;
            byte num24 = 0;
            if (Main.player[(int) num23].controlUp)
              ++num24;
            if (Main.player[(int) num23].controlDown)
              num24 += (byte) 2;
            if (Main.player[(int) num23].controlLeft)
              num24 += (byte) 4;
            if (Main.player[(int) num23].controlRight)
              num24 += (byte) 8;
            if (Main.player[(int) num23].controlJump)
              num24 += (byte) 16;
            if (Main.player[(int) num23].controlUseItem)
              num24 += (byte) 32;
            if (Main.player[(int) num23].direction == 1)
              num24 += (byte) 64;
            byte selectedItem = (byte) Main.player[(int) num23].selectedItem;
            byte[] bytes39 = BitConverter.GetBytes(Main.player[number].position.X);
            byte[] bytes40 = BitConverter.GetBytes(Main.player[number].position.Y);
            byte[] bytes41 = BitConverter.GetBytes(Main.player[number].velocity.X);
            byte[] bytes42 = BitConverter.GetBytes(Main.player[number].velocity.Y);
            count += 3 + bytes39.Length + bytes40.Length + bytes41.Length + bytes42.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes38, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num23;
            int num25 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[6] = num24;
            int num26 = num25 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[7] = selectedItem;
            int dstOffset23 = num26 + 1;
            Buffer.BlockCopy((Array) bytes39, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset23, 4);
            int dstOffset24 = dstOffset23 + 4;
            Buffer.BlockCopy((Array) bytes40, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset24, 4);
            int dstOffset25 = dstOffset24 + 4;
            Buffer.BlockCopy((Array) bytes41, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset25, 4);
            int dstOffset26 = dstOffset25 + 4;
            Buffer.BlockCopy((Array) bytes42, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset26, 4);
            break;
          case 14:
            byte[] bytes43 = BitConverter.GetBytes(msgType);
            byte num27 = (byte) number;
            byte num28 = (byte) number2;
            count += 2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes43, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num27;
            NetMessage.buffer[whoAmi].writeBuffer[6] = num28;
            break;
          case 15:
            byte[] bytes44 = BitConverter.GetBytes(msgType);
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes44, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            break;
          case 16:
            byte[] bytes45 = BitConverter.GetBytes(msgType);
            byte num29 = (byte) number;
            byte[] bytes46 = BitConverter.GetBytes((short) Main.player[(int) num29].statLife);
            byte[] bytes47 = BitConverter.GetBytes((short) Main.player[(int) num29].statLifeMax);
            count += 1 + bytes46.Length + bytes47.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes45, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num29;
            int dstOffset27 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes46, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset27, 2);
            int dstOffset28 = dstOffset27 + 2;
            Buffer.BlockCopy((Array) bytes47, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset28, 2);
            break;
          case 17:
            byte[] bytes48 = BitConverter.GetBytes(msgType);
            byte num30 = (byte) number;
            byte[] bytes49 = BitConverter.GetBytes((int) number2);
            byte[] bytes50 = BitConverter.GetBytes((int) number3);
            byte num31 = (byte) number4;
            count += 1 + bytes49.Length + bytes50.Length + 1 + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes48, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num30;
            int dstOffset29 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes49, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset29, 4);
            int dstOffset30 = dstOffset29 + 4;
            Buffer.BlockCopy((Array) bytes50, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset30, 4);
            int index31 = dstOffset30 + 4;
            NetMessage.buffer[whoAmi].writeBuffer[index31] = num31;
            int index32 = index31 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index32] = (byte) number5;
            break;
          case 18:
            byte[] bytes51 = BitConverter.GetBytes(msgType);
            BitConverter.GetBytes((int) Main.time);
            byte num32 = 0;
            if (Main.dayTime)
              num32 = (byte) 1;
            byte[] bytes52 = BitConverter.GetBytes((int) Main.time);
            byte[] bytes53 = BitConverter.GetBytes(Main.sunModY);
            byte[] bytes54 = BitConverter.GetBytes(Main.moonModY);
            count += 1 + bytes52.Length + bytes53.Length + bytes54.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes51, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num32;
            int dstOffset31 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes52, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset31, 4);
            int dstOffset32 = dstOffset31 + 4;
            Buffer.BlockCopy((Array) bytes53, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset32, 2);
            int dstOffset33 = dstOffset32 + 2;
            Buffer.BlockCopy((Array) bytes54, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset33, 2);
            num1 = dstOffset33 + 2;
            break;
          case 19:
            byte[] bytes55 = BitConverter.GetBytes(msgType);
            byte num33 = (byte) number;
            byte[] bytes56 = BitConverter.GetBytes((int) number2);
            byte[] bytes57 = BitConverter.GetBytes((int) number3);
            byte num34 = 0;
            if ((double) number4 == 1.0)
              num34 = (byte) 1;
            count += 1 + bytes56.Length + bytes57.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes55, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num33;
            int dstOffset34 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes56, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset34, 4);
            int dstOffset35 = dstOffset34 + 4;
            Buffer.BlockCopy((Array) bytes57, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset35, 4);
            int index33 = dstOffset35 + 4;
            NetMessage.buffer[whoAmi].writeBuffer[index33] = num34;
            break;
          case 20:
            short num35 = (short) number;
            int num36 = (int) number2;
            int num37 = (int) number3;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(msgType), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) BitConverter.GetBytes(num35), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, 2);
            int dstOffset36 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(num36), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset36, 4);
            int dstOffset37 = dstOffset36 + 4;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(num37), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset37, 4);
            int dstOffset38 = dstOffset37 + 4;
            for (int index34 = num36; index34 < num36 + (int) num35; ++index34)
            {
              for (int index35 = num37; index35 < num37 + (int) num35; ++index35)
              {
                byte num38 = 0;
                if (Main.tile[index34, index35].active)
                  ++num38;
                if (Main.tile[index34, index35].wall > (byte) 0)
                  num38 += (byte) 4;
                if (Main.tile[index34, index35].liquid > (byte) 0 && Main.netMode == 2)
                  num38 += (byte) 8;
                if (Main.tile[index34, index35].wire)
                  num38 += (byte) 16;
                NetMessage.buffer[whoAmi].writeBuffer[dstOffset38] = num38;
                ++dstOffset38;
                byte[] bytes58 = BitConverter.GetBytes(Main.tile[index34, index35].frameX);
                byte[] bytes59 = BitConverter.GetBytes(Main.tile[index34, index35].frameY);
                byte wall = Main.tile[index34, index35].wall;
                if (Main.tile[index34, index35].active)
                {
                  NetMessage.buffer[whoAmi].writeBuffer[dstOffset38] = Main.tile[index34, index35].type;
                  ++dstOffset38;
                  if (Main.tileFrameImportant[(int) Main.tile[index34, index35].type])
                  {
                    Buffer.BlockCopy((Array) bytes58, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset38, 2);
                    int dstOffset39 = dstOffset38 + 2;
                    Buffer.BlockCopy((Array) bytes59, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset39, 2);
                    dstOffset38 = dstOffset39 + 2;
                  }
                }
                if (wall > (byte) 0)
                {
                  NetMessage.buffer[whoAmi].writeBuffer[dstOffset38] = wall;
                  ++dstOffset38;
                }
                if (Main.tile[index34, index35].liquid > (byte) 0 && Main.netMode == 2)
                {
                  NetMessage.buffer[whoAmi].writeBuffer[dstOffset38] = Main.tile[index34, index35].liquid;
                  int index36 = dstOffset38 + 1;
                  byte num39 = 0;
                  if (Main.tile[index34, index35].lava)
                    num39 = (byte) 1;
                  NetMessage.buffer[whoAmi].writeBuffer[index36] = num39;
                  dstOffset38 = index36 + 1;
                }
              }
            }
            Buffer.BlockCopy((Array) BitConverter.GetBytes(dstOffset38 - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            count = dstOffset38;
            break;
          case 21:
            byte[] bytes60 = BitConverter.GetBytes(msgType);
            byte[] bytes61 = BitConverter.GetBytes((short) number);
            byte[] bytes62 = BitConverter.GetBytes(Main.item[number].position.X);
            byte[] bytes63 = BitConverter.GetBytes(Main.item[number].position.Y);
            byte[] bytes64 = BitConverter.GetBytes(Main.item[number].velocity.X);
            byte[] bytes65 = BitConverter.GetBytes(Main.item[number].velocity.Y);
            byte stack1 = (byte) Main.item[number].stack;
            byte prefix1 = Main.item[number].prefix;
            short num40 = 0;
            if (Main.item[number].active && Main.item[number].stack > 0)
              num40 = (short) Main.item[number].netID;
            byte[] bytes66 = BitConverter.GetBytes(num40);
            count += bytes61.Length + bytes62.Length + bytes63.Length + bytes64.Length + bytes65.Length + 1 + bytes66.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes60, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes61, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes61.Length);
            int dstOffset40 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) bytes62, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset40, bytes62.Length);
            int dstOffset41 = dstOffset40 + 4;
            Buffer.BlockCopy((Array) bytes63, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset41, bytes63.Length);
            int dstOffset42 = dstOffset41 + 4;
            Buffer.BlockCopy((Array) bytes64, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset42, bytes64.Length);
            int dstOffset43 = dstOffset42 + 4;
            Buffer.BlockCopy((Array) bytes65, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset43, bytes65.Length);
            int index37 = dstOffset43 + 4;
            NetMessage.buffer[whoAmi].writeBuffer[index37] = stack1;
            int index38 = index37 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index38] = prefix1;
            int dstOffset44 = index38 + 1;
            Buffer.BlockCopy((Array) bytes66, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset44, bytes66.Length);
            break;
          case 22:
            byte[] bytes67 = BitConverter.GetBytes(msgType);
            byte[] bytes68 = BitConverter.GetBytes((short) number);
            byte owner = (byte) Main.item[number].owner;
            count += bytes68.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes67, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes68, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes68.Length);
            int index39 = dstOffset1 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index39] = owner;
            break;
          case 23:
            byte[] bytes69 = BitConverter.GetBytes(msgType);
            byte[] bytes70 = BitConverter.GetBytes((short) number);
            byte[] bytes71 = BitConverter.GetBytes(Main.npc[number].position.X);
            byte[] bytes72 = BitConverter.GetBytes(Main.npc[number].position.Y);
            byte[] bytes73 = BitConverter.GetBytes(Main.npc[number].velocity.X);
            byte[] bytes74 = BitConverter.GetBytes(Main.npc[number].velocity.Y);
            byte[] bytes75 = BitConverter.GetBytes((short) Main.npc[number].target);
            byte[] bytes76 = BitConverter.GetBytes(Main.npc[number].life);
            if (!Main.npc[number].active)
              bytes76 = BitConverter.GetBytes(0);
            if (!Main.npc[number].active || Main.npc[number].life <= 0)
              Main.npc[number].netSkip = 0;
            if (Main.npc[number].name == null)
              Main.npc[number].name = "";
            byte[] bytes77 = BitConverter.GetBytes((short) Main.npc[number].netID);
            count += bytes70.Length + bytes71.Length + bytes72.Length + bytes73.Length + bytes74.Length + bytes75.Length + bytes76.Length + NPC.maxAI * 4 + bytes77.Length + 1 + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes69, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes70, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes70.Length);
            int dstOffset45 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) bytes71, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset45, bytes71.Length);
            int dstOffset46 = dstOffset45 + 4;
            Buffer.BlockCopy((Array) bytes72, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset46, bytes72.Length);
            int dstOffset47 = dstOffset46 + 4;
            Buffer.BlockCopy((Array) bytes73, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset47, bytes73.Length);
            int dstOffset48 = dstOffset47 + 4;
            Buffer.BlockCopy((Array) bytes74, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset48, bytes74.Length);
            int dstOffset49 = dstOffset48 + 4;
            Buffer.BlockCopy((Array) bytes75, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset49, bytes75.Length);
            int index40 = dstOffset49 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index40] = (byte) (Main.npc[number].direction + 1);
            int index41 = index40 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index41] = (byte) (Main.npc[number].directionY + 1);
            int dstOffset50 = index41 + 1;
            Buffer.BlockCopy((Array) bytes76, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset50, bytes76.Length);
            int dstOffset51 = dstOffset50 + 4;
            for (int index42 = 0; index42 < NPC.maxAI; ++index42)
            {
              byte[] bytes78 = BitConverter.GetBytes(Main.npc[number].ai[index42]);
              Buffer.BlockCopy((Array) bytes78, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset51, bytes78.Length);
              dstOffset51 += 4;
            }
            Buffer.BlockCopy((Array) bytes77, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset51, bytes77.Length);
            break;
          case 24:
            byte[] bytes79 = BitConverter.GetBytes(msgType);
            byte[] bytes80 = BitConverter.GetBytes((short) number);
            byte num41 = (byte) number2;
            count += bytes80.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes79, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes80, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes80.Length);
            int index43 = dstOffset1 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index43] = num41;
            break;
          case 25:
            byte[] bytes81 = BitConverter.GetBytes(msgType);
            byte num42 = (byte) number;
            byte[] bytes82 = Encoding.UTF8.GetBytes(text);
            byte num43 = (byte) number2;
            byte num44 = (byte) number3;
            byte num45 = (byte) number4;
            count += 1 + bytes82.Length + 3;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes81, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num42;
            int index44 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index44] = num43;
            int index45 = index44 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index45] = num44;
            int index46 = index45 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index46] = num45;
            int dstOffset52 = index46 + 1;
            Buffer.BlockCopy((Array) bytes82, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset52, bytes82.Length);
            break;
          case 26:
            byte[] bytes83 = BitConverter.GetBytes(msgType);
            byte num46 = (byte) number;
            byte num47 = (byte) ((double) number2 + 1.0);
            byte[] bytes84 = BitConverter.GetBytes((short) number3);
            byte[] bytes85 = Encoding.UTF8.GetBytes(text);
            byte num48 = (byte) number4;
            byte num49 = (byte) number5;
            count += 2 + bytes84.Length + 1 + bytes85.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes83, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num46;
            int index47 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index47] = num47;
            int dstOffset53 = index47 + 1;
            Buffer.BlockCopy((Array) bytes84, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset53, bytes84.Length);
            int index48 = dstOffset53 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index48] = num48;
            int index49 = index48 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index49] = num49;
            int dstOffset54 = index49 + 1;
            Buffer.BlockCopy((Array) bytes85, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset54, bytes85.Length);
            break;
          case 27:
            byte[] bytes86 = BitConverter.GetBytes(msgType);
            byte[] bytes87 = BitConverter.GetBytes((short) Main.projectile[number].identity);
            byte[] bytes88 = BitConverter.GetBytes(Main.projectile[number].position.X);
            byte[] bytes89 = BitConverter.GetBytes(Main.projectile[number].position.Y);
            byte[] bytes90 = BitConverter.GetBytes(Main.projectile[number].velocity.X);
            byte[] bytes91 = BitConverter.GetBytes(Main.projectile[number].velocity.Y);
            byte[] bytes92 = BitConverter.GetBytes(Main.projectile[number].knockBack);
            byte[] bytes93 = BitConverter.GetBytes((short) Main.projectile[number].damage);
            Buffer.BlockCopy((Array) bytes86, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes87, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes87.Length);
            int dstOffset55 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) bytes88, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset55, bytes88.Length);
            int dstOffset56 = dstOffset55 + 4;
            Buffer.BlockCopy((Array) bytes89, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset56, bytes89.Length);
            int dstOffset57 = dstOffset56 + 4;
            Buffer.BlockCopy((Array) bytes90, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset57, bytes90.Length);
            int dstOffset58 = dstOffset57 + 4;
            Buffer.BlockCopy((Array) bytes91, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset58, bytes91.Length);
            int dstOffset59 = dstOffset58 + 4;
            Buffer.BlockCopy((Array) bytes92, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset59, bytes92.Length);
            int dstOffset60 = dstOffset59 + 4;
            Buffer.BlockCopy((Array) bytes93, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset60, bytes93.Length);
            int index50 = dstOffset60 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index50] = (byte) Main.projectile[number].owner;
            int index51 = index50 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index51] = (byte) Main.projectile[number].type;
            int dstOffset61 = index51 + 1;
            for (int index52 = 0; index52 < Projectile.maxAI; ++index52)
            {
              byte[] bytes94 = BitConverter.GetBytes(Main.projectile[number].ai[index52]);
              Buffer.BlockCopy((Array) bytes94, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset61, bytes94.Length);
              dstOffset61 += 4;
            }
            count += dstOffset61;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            break;
          case 28:
            byte[] bytes95 = BitConverter.GetBytes(msgType);
            byte[] bytes96 = BitConverter.GetBytes((short) number);
            byte[] bytes97 = BitConverter.GetBytes((short) number2);
            byte[] bytes98 = BitConverter.GetBytes(number3);
            byte num50 = (byte) ((double) number4 + 1.0);
            byte num51 = (byte) number5;
            count += bytes96.Length + bytes97.Length + bytes98.Length + 1 + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes95, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes96, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes96.Length);
            int dstOffset62 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) bytes97, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset62, bytes97.Length);
            int dstOffset63 = dstOffset62 + 2;
            Buffer.BlockCopy((Array) bytes98, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset63, bytes98.Length);
            int index53 = dstOffset63 + 4;
            NetMessage.buffer[whoAmi].writeBuffer[index53] = num50;
            int index54 = index53 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index54] = num51;
            break;
          case 29:
            byte[] bytes99 = BitConverter.GetBytes(msgType);
            byte[] bytes100 = BitConverter.GetBytes((short) number);
            byte num52 = (byte) number2;
            count += bytes100.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes99, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes100, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes100.Length);
            int index55 = dstOffset1 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index55] = num52;
            break;
          case 30:
            byte[] bytes101 = BitConverter.GetBytes(msgType);
            byte num53 = (byte) number;
            byte num54 = 0;
            if (Main.player[(int) num53].hostile)
              num54 = (byte) 1;
            count += 2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes101, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num53;
            int index56 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index56] = num54;
            break;
          case 31:
            byte[] bytes102 = BitConverter.GetBytes(msgType);
            byte[] bytes103 = BitConverter.GetBytes(number);
            byte[] bytes104 = BitConverter.GetBytes((int) number2);
            count += bytes103.Length + bytes104.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes102, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes103, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes103.Length);
            int dstOffset64 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes104, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset64, bytes104.Length);
            break;
          case 32:
            byte[] bytes105 = BitConverter.GetBytes(msgType);
            byte[] bytes106 = BitConverter.GetBytes((short) number);
            byte num55 = (byte) number2;
            byte stack2 = (byte) Main.chest[number].item[(int) number2].stack;
            byte prefix2 = Main.chest[number].item[(int) number2].prefix;
            byte[] numArray = Main.chest[number].item[(int) number2].name != null ? BitConverter.GetBytes((short) Main.chest[number].item[(int) number2].netID) : BitConverter.GetBytes((short) 0);
            count += bytes106.Length + 1 + 1 + 1 + numArray.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes105, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes106, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes106.Length);
            int index57 = dstOffset1 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index57] = num55;
            int index58 = index57 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index58] = stack2;
            int index59 = index58 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index59] = prefix2;
            int dstOffset65 = index59 + 1;
            Buffer.BlockCopy((Array) numArray, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset65, numArray.Length);
            break;
          case 33:
            byte[] bytes107 = BitConverter.GetBytes(msgType);
            byte[] bytes108 = BitConverter.GetBytes((short) number);
            byte[] bytes109;
            byte[] bytes110;
            if (number > -1)
            {
              bytes109 = BitConverter.GetBytes(Main.chest[number].x);
              bytes110 = BitConverter.GetBytes(Main.chest[number].y);
            }
            else
            {
              bytes109 = BitConverter.GetBytes(0);
              bytes110 = BitConverter.GetBytes(0);
            }
            count += bytes108.Length + bytes109.Length + bytes110.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes107, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes108, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes108.Length);
            int dstOffset66 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) bytes109, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset66, bytes109.Length);
            int dstOffset67 = dstOffset66 + 4;
            Buffer.BlockCopy((Array) bytes110, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset67, bytes110.Length);
            break;
          case 34:
            byte[] bytes111 = BitConverter.GetBytes(msgType);
            byte[] bytes112 = BitConverter.GetBytes(number);
            byte[] bytes113 = BitConverter.GetBytes((int) number2);
            count += bytes112.Length + bytes113.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes111, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes112, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes112.Length);
            int dstOffset68 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes113, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset68, bytes113.Length);
            break;
          case 35:
            byte[] bytes114 = BitConverter.GetBytes(msgType);
            byte num56 = (byte) number;
            byte[] bytes115 = BitConverter.GetBytes((short) number2);
            count += 1 + bytes115.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes114, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num56;
            int dstOffset69 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes115, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset69, 2);
            break;
          case 36:
            byte[] bytes116 = BitConverter.GetBytes(msgType);
            byte num57 = (byte) number;
            byte num58 = 0;
            if (Main.player[(int) num57].zoneEvil)
              num58 = (byte) 1;
            byte num59 = 0;
            if (Main.player[(int) num57].zoneMeteor)
              num59 = (byte) 1;
            byte num60 = 0;
            if (Main.player[(int) num57].zoneDungeon)
              num60 = (byte) 1;
            byte num61 = 0;
            if (Main.player[(int) num57].zoneJungle)
              num61 = (byte) 1;
            byte num62 = 0;
            if (Main.player[(int) num57].zoneHoly)
              num62 = (byte) 1;
            count += 6;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes116, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num57;
            int index60 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index60] = num58;
            int index61 = index60 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index61] = num59;
            int index62 = index61 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index62] = num60;
            int index63 = index62 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index63] = num61;
            int index64 = index63 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index64] = num62;
            num1 = index64 + 1;
            break;
          case 37:
            byte[] bytes117 = BitConverter.GetBytes(msgType);
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes117, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            break;
          case 38:
            byte[] bytes118 = BitConverter.GetBytes(msgType);
            byte[] bytes119 = Encoding.UTF8.GetBytes(text);
            count += bytes119.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes118, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes119, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes119.Length);
            break;
          case 39:
            byte[] bytes120 = BitConverter.GetBytes(msgType);
            byte[] bytes121 = BitConverter.GetBytes((short) number);
            count += bytes121.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes120, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes121, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes121.Length);
            break;
          case 40:
            byte[] bytes122 = BitConverter.GetBytes(msgType);
            byte num63 = (byte) number;
            byte[] bytes123 = BitConverter.GetBytes((short) Main.player[(int) num63].talkNPC);
            count += 1 + bytes123.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes122, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num63;
            int dstOffset70 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes123, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset70, bytes123.Length);
            num1 = dstOffset70 + 2;
            break;
          case 41:
            byte[] bytes124 = BitConverter.GetBytes(msgType);
            byte num64 = (byte) number;
            byte[] bytes125 = BitConverter.GetBytes(Main.player[(int) num64].itemRotation);
            byte[] bytes126 = BitConverter.GetBytes((short) Main.player[(int) num64].itemAnimation);
            count += 1 + bytes125.Length + bytes126.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes124, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num64;
            int dstOffset71 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes125, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset71, bytes125.Length);
            int dstOffset72 = dstOffset71 + 4;
            Buffer.BlockCopy((Array) bytes126, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset72, bytes126.Length);
            break;
          case 42:
            byte[] bytes127 = BitConverter.GetBytes(msgType);
            byte num65 = (byte) number;
            byte[] bytes128 = BitConverter.GetBytes((short) Main.player[(int) num65].statMana);
            byte[] bytes129 = BitConverter.GetBytes((short) Main.player[(int) num65].statManaMax);
            count += 1 + bytes128.Length + bytes129.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes127, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num65;
            int dstOffset73 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes128, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset73, 2);
            int dstOffset74 = dstOffset73 + 2;
            Buffer.BlockCopy((Array) bytes129, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset74, 2);
            break;
          case 43:
            byte[] bytes130 = BitConverter.GetBytes(msgType);
            byte num66 = (byte) number;
            byte[] bytes131 = BitConverter.GetBytes((short) number2);
            count += 1 + bytes131.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes130, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num66;
            int dstOffset75 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes131, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset75, 2);
            break;
          case 44:
            byte[] bytes132 = BitConverter.GetBytes(msgType);
            byte num67 = (byte) number;
            byte num68 = (byte) ((double) number2 + 1.0);
            byte[] bytes133 = BitConverter.GetBytes((short) number3);
            byte num69 = (byte) number4;
            byte[] bytes134 = Encoding.UTF8.GetBytes(text);
            count += 2 + bytes133.Length + 1 + bytes134.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes132, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num67;
            int index65 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index65] = num68;
            int dstOffset76 = index65 + 1;
            Buffer.BlockCopy((Array) bytes133, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset76, bytes133.Length);
            int index66 = dstOffset76 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index66] = num69;
            int dstOffset77 = index66 + 1;
            Buffer.BlockCopy((Array) bytes134, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset77, bytes134.Length);
            num1 = dstOffset77 + bytes134.Length;
            break;
          case 45:
            byte[] bytes135 = BitConverter.GetBytes(msgType);
            byte num70 = (byte) number;
            byte team = (byte) Main.player[(int) num70].team;
            count += 2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes135, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[5] = num70;
            int index67 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index67] = team;
            break;
          case 46:
            byte[] bytes136 = BitConverter.GetBytes(msgType);
            byte[] bytes137 = BitConverter.GetBytes(number);
            byte[] bytes138 = BitConverter.GetBytes((int) number2);
            count += bytes137.Length + bytes138.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes136, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes137, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes137.Length);
            int dstOffset78 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes138, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset78, bytes138.Length);
            break;
          case 47:
            byte[] bytes139 = BitConverter.GetBytes(msgType);
            byte[] bytes140 = BitConverter.GetBytes((short) number);
            byte[] bytes141 = BitConverter.GetBytes(Main.sign[number].x);
            byte[] bytes142 = BitConverter.GetBytes(Main.sign[number].y);
            byte[] bytes143 = Encoding.UTF8.GetBytes(Main.sign[number].text);
            count += bytes140.Length + bytes141.Length + bytes142.Length + bytes143.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes139, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes140, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes140.Length);
            int dstOffset79 = dstOffset1 + bytes140.Length;
            Buffer.BlockCopy((Array) bytes141, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset79, bytes141.Length);
            int dstOffset80 = dstOffset79 + bytes141.Length;
            Buffer.BlockCopy((Array) bytes142, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset80, bytes142.Length);
            int dstOffset81 = dstOffset80 + bytes142.Length;
            Buffer.BlockCopy((Array) bytes143, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset81, bytes143.Length);
            num1 = dstOffset81 + bytes143.Length;
            break;
          case 48:
            byte[] bytes144 = BitConverter.GetBytes(msgType);
            byte[] bytes145 = BitConverter.GetBytes(number);
            byte[] bytes146 = BitConverter.GetBytes((int) number2);
            byte liquid = Main.tile[number, (int) number2].liquid;
            byte num71 = 0;
            if (Main.tile[number, (int) number2].lava)
              num71 = (byte) 1;
            count += bytes145.Length + bytes146.Length + 1 + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes144, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes145, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, 4);
            int dstOffset82 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes146, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset82, 4);
            int index68 = dstOffset82 + 4;
            NetMessage.buffer[whoAmi].writeBuffer[index68] = liquid;
            int index69 = index68 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index69] = num71;
            num1 = index69 + 1;
            break;
          case 49:
            byte[] bytes147 = BitConverter.GetBytes(msgType);
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes147, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            break;
          case 50:
            byte[] bytes148 = BitConverter.GetBytes(msgType);
            byte num72 = (byte) number;
            count += 11;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes148, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num72;
            int index70 = dstOffset1 + 1;
            for (int index71 = 0; index71 < 10; ++index71)
            {
              NetMessage.buffer[whoAmi].writeBuffer[index70] = (byte) Main.player[(int) num72].buffType[index71];
              ++index70;
            }
            break;
          case 51:
            byte[] bytes149 = BitConverter.GetBytes(msgType);
            count += 2;
            byte num73 = (byte) number;
            byte num74 = (byte) number2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes149, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num73;
            int index72 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index72] = num74;
            break;
          case 52:
            byte[] bytes150 = BitConverter.GetBytes(msgType);
            byte num75 = (byte) number;
            byte num76 = (byte) number2;
            byte[] bytes151 = BitConverter.GetBytes((int) number3);
            byte[] bytes152 = BitConverter.GetBytes((int) number4);
            count += 2 + bytes151.Length + bytes152.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes150, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num75;
            int index73 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index73] = num76;
            int dstOffset83 = index73 + 1;
            Buffer.BlockCopy((Array) bytes151, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset83, 4);
            int dstOffset84 = dstOffset83 + 4;
            Buffer.BlockCopy((Array) bytes152, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset84, 4);
            num1 = dstOffset84 + 4;
            break;
          case 53:
            byte[] bytes153 = BitConverter.GetBytes(msgType);
            byte[] bytes154 = BitConverter.GetBytes((short) number);
            byte num77 = (byte) number2;
            byte[] bytes155 = BitConverter.GetBytes((short) number3);
            count += bytes154.Length + 1 + bytes155.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes153, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes154, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes154.Length);
            int index74 = dstOffset1 + bytes154.Length;
            NetMessage.buffer[whoAmi].writeBuffer[index74] = num77;
            int dstOffset85 = index74 + 1;
            Buffer.BlockCopy((Array) bytes155, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset85, bytes155.Length);
            num1 = dstOffset85 + bytes155.Length;
            break;
          case 54:
            byte[] bytes156 = BitConverter.GetBytes(msgType);
            byte[] bytes157 = BitConverter.GetBytes((short) number);
            count += bytes157.Length + 15;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes156, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes157, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes157.Length);
            int index75 = dstOffset1 + bytes157.Length;
            for (int index76 = 0; index76 < 5; ++index76)
            {
              NetMessage.buffer[whoAmi].writeBuffer[index75] = (byte) Main.npc[(int) (short) number].buffType[index76];
              int dstOffset86 = index75 + 1;
              byte[] bytes158 = BitConverter.GetBytes(Main.npc[(int) (short) number].buffTime[index76]);
              Buffer.BlockCopy((Array) bytes158, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset86, bytes158.Length);
              index75 = dstOffset86 + bytes158.Length;
            }
            break;
          case 55:
            byte[] bytes159 = BitConverter.GetBytes(msgType);
            byte num78 = (byte) number;
            byte num79 = (byte) number2;
            byte[] bytes160 = BitConverter.GetBytes((short) number3);
            count += 2 + bytes160.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes159, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num78;
            int index77 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index77] = num79;
            int dstOffset87 = index77 + 1;
            Buffer.BlockCopy((Array) bytes160, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset87, bytes160.Length);
            num1 = dstOffset87 + bytes160.Length;
            break;
          case 56:
            byte[] bytes161 = BitConverter.GetBytes(msgType);
            byte[] bytes162 = BitConverter.GetBytes((short) number);
            byte[] bytes163 = Encoding.UTF8.GetBytes(Main.chrName[number]);
            count += bytes162.Length + bytes163.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes161, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes162, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes162.Length);
            int dstOffset88 = dstOffset1 + bytes162.Length;
            Buffer.BlockCopy((Array) bytes163, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset88, bytes163.Length);
            break;
          case 57:
            byte[] bytes164 = BitConverter.GetBytes(msgType);
            count += 2;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes164, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = WorldGen.tGood;
            int index78 = dstOffset1 + 1;
            NetMessage.buffer[whoAmi].writeBuffer[index78] = WorldGen.tEvil;
            break;
          case 58:
            byte[] bytes165 = BitConverter.GetBytes(msgType);
            byte num80 = (byte) number;
            byte[] bytes166 = BitConverter.GetBytes(number2);
            count += 1 + bytes166.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes165, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            NetMessage.buffer[whoAmi].writeBuffer[dstOffset1] = num80;
            int dstOffset89 = dstOffset1 + 1;
            Buffer.BlockCopy((Array) bytes166, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset89, bytes166.Length);
            break;
          case 59:
            byte[] bytes167 = BitConverter.GetBytes(msgType);
            byte[] bytes168 = BitConverter.GetBytes(number);
            byte[] bytes169 = BitConverter.GetBytes((int) number2);
            count += bytes168.Length + bytes169.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes167, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes168, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes168.Length);
            int dstOffset90 = dstOffset1 + 4;
            Buffer.BlockCopy((Array) bytes169, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset90, bytes169.Length);
            break;
          case 60:
            byte[] bytes170 = BitConverter.GetBytes(msgType);
            byte[] bytes171 = BitConverter.GetBytes((short) number);
            byte[] bytes172 = BitConverter.GetBytes((short) number2);
            byte[] bytes173 = BitConverter.GetBytes((short) number3);
            byte num81 = (byte) number4;
            count += bytes171.Length + bytes172.Length + bytes173.Length + 1;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes170, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes171, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes171.Length);
            int dstOffset91 = dstOffset1 + 2;
            Buffer.BlockCopy((Array) bytes172, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset91, bytes172.Length);
            int dstOffset92 = dstOffset91 + 2;
            Buffer.BlockCopy((Array) bytes173, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset92, bytes173.Length);
            int index79 = dstOffset92 + 2;
            NetMessage.buffer[whoAmi].writeBuffer[index79] = num81;
            num1 = index79 + 1;
            break;
          case 61:
            byte[] bytes174 = BitConverter.GetBytes(msgType);
            byte[] bytes175 = BitConverter.GetBytes(number);
            byte[] bytes176 = BitConverter.GetBytes((int) number2);
            count += bytes175.Length + bytes176.Length;
            Buffer.BlockCopy((Array) BitConverter.GetBytes(count - 4), 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 0, 4);
            Buffer.BlockCopy((Array) bytes174, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, 4, 1);
            Buffer.BlockCopy((Array) bytes175, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset1, bytes175.Length);
            int dstOffset93 = dstOffset1 + bytes175.Length;
            Buffer.BlockCopy((Array) bytes176, 0, (Array) NetMessage.buffer[whoAmi].writeBuffer, dstOffset93, bytes176.Length);
            break;
        }
        if (Main.netMode == 1)
        {
          if (Netplay.clientSock.tcpClient.Connected)
          {
            try
            {
              ++NetMessage.buffer[whoAmi].spamCount;
              ++Main.txMsg;
              Main.txData += count;
              ++Main.txMsgType[msgType];
              Main.txDataType[msgType] += count;
              Netplay.clientSock.networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.clientSock.ClientWriteCallBack), (object) Netplay.clientSock.networkStream);
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
              int index80 = number;
              for (int index81 = 0; index81 < 256; ++index81)
              {
                if (index81 != ignoreClient && (NetMessage.buffer[index81].broadcast || Netplay.serverSock[index81].state >= 3 && msgType == 10) && Netplay.serverSock[index81].tcpClient.Connected)
                {
                  bool flag = false;
                  if (Main.player[index80].netSkip > 0)
                  {
                    Rectangle rectangle1 = new Rectangle((int) Main.player[index81].position.X, (int) Main.player[index81].position.Y, Main.player[index81].width, Main.player[index81].height);
                    Rectangle rectangle2 = new Rectangle((int) Main.player[index80].position.X, (int) Main.player[index80].position.Y, Main.player[index80].width, Main.player[index80].height);
                    rectangle2.X -= 2500;
                    rectangle2.Y -= 2500;
                    rectangle2.Width += 5000;
                    rectangle2.Height += 5000;
                    if (rectangle1.Intersects(rectangle2))
                      flag = true;
                  }
                  else
                    flag = true;
                  if (flag)
                  {
                    try
                    {
                      ++NetMessage.buffer[index81].spamCount;
                      ++Main.txMsg;
                      Main.txData += count;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += count;
                      Netplay.serverSock[index81].networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[index81].ServerWriteCallBack), (object) Netplay.serverSock[index81].networkStream);
                    }
                    catch
                    {
                    }
                  }
                }
              }
              ++Main.player[index80].netSkip;
              if (Main.player[index80].netSkip > 2)
              {
                Main.player[index80].netSkip = 0;
                break;
              }
              break;
            case 20:
              for (int index82 = 0; index82 < 256; ++index82)
              {
                if (index82 != ignoreClient && (NetMessage.buffer[index82].broadcast || Netplay.serverSock[index82].state >= 3 && msgType == 10) && Netplay.serverSock[index82].tcpClient.Connected)
                {
                  if (Netplay.serverSock[index82].SectionRange(number, (int) number2, (int) number3))
                  {
                    try
                    {
                      ++NetMessage.buffer[index82].spamCount;
                      ++Main.txMsg;
                      Main.txData += count;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += count;
                      Netplay.serverSock[index82].networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[index82].ServerWriteCallBack), (object) Netplay.serverSock[index82].networkStream);
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            case 27:
              int index83 = number;
              for (int index84 = 0; index84 < 256; ++index84)
              {
                if (index84 != ignoreClient && (NetMessage.buffer[index84].broadcast || Netplay.serverSock[index84].state >= 3 && msgType == 10) && Netplay.serverSock[index84].tcpClient.Connected)
                {
                  bool flag = false;
                  if (Main.projectile[index83].type == 12)
                  {
                    flag = true;
                  }
                  else
                  {
                    Rectangle rectangle3 = new Rectangle((int) Main.player[index84].position.X, (int) Main.player[index84].position.Y, Main.player[index84].width, Main.player[index84].height);
                    Rectangle rectangle4 = new Rectangle((int) Main.projectile[index83].position.X, (int) Main.projectile[index83].position.Y, Main.projectile[index83].width, Main.projectile[index83].height);
                    rectangle4.X -= 5000;
                    rectangle4.Y -= 5000;
                    rectangle4.Width += 10000;
                    rectangle4.Height += 10000;
                    if (rectangle3.Intersects(rectangle4))
                      flag = true;
                  }
                  if (flag)
                  {
                    try
                    {
                      ++NetMessage.buffer[index84].spamCount;
                      ++Main.txMsg;
                      Main.txData += count;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += count;
                      Netplay.serverSock[index84].networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[index84].ServerWriteCallBack), (object) Netplay.serverSock[index84].networkStream);
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            case 28:
              int index85 = number;
              for (int index86 = 0; index86 < 256; ++index86)
              {
                if (index86 != ignoreClient && (NetMessage.buffer[index86].broadcast || Netplay.serverSock[index86].state >= 3 && msgType == 10) && Netplay.serverSock[index86].tcpClient.Connected)
                {
                  bool flag = false;
                  if (Main.npc[index85].life <= 0)
                  {
                    flag = true;
                  }
                  else
                  {
                    Rectangle rectangle5 = new Rectangle((int) Main.player[index86].position.X, (int) Main.player[index86].position.Y, Main.player[index86].width, Main.player[index86].height);
                    Rectangle rectangle6 = new Rectangle((int) Main.npc[index85].position.X, (int) Main.npc[index85].position.Y, Main.npc[index85].width, Main.npc[index85].height);
                    rectangle6.X -= 3000;
                    rectangle6.Y -= 3000;
                    rectangle6.Width += 6000;
                    rectangle6.Height += 6000;
                    if (rectangle5.Intersects(rectangle6))
                      flag = true;
                  }
                  if (flag)
                  {
                    try
                    {
                      ++NetMessage.buffer[index86].spamCount;
                      ++Main.txMsg;
                      Main.txData += count;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += count;
                      Netplay.serverSock[index86].networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[index86].ServerWriteCallBack), (object) Netplay.serverSock[index86].networkStream);
                    }
                    catch
                    {
                    }
                  }
                }
              }
              break;
            default:
              for (int index87 = 0; index87 < 256; ++index87)
              {
                if (index87 != ignoreClient && (NetMessage.buffer[index87].broadcast || Netplay.serverSock[index87].state >= 3 && msgType == 10))
                {
                  if (Netplay.serverSock[index87].tcpClient.Connected)
                  {
                    try
                    {
                      ++NetMessage.buffer[index87].spamCount;
                      ++Main.txMsg;
                      Main.txData += count;
                      ++Main.txMsgType[msgType];
                      Main.txDataType[msgType] += count;
                      Netplay.serverSock[index87].networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[index87].ServerWriteCallBack), (object) Netplay.serverSock[index87].networkStream);
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
        else if (Netplay.serverSock[remoteClient].tcpClient.Connected)
        {
          try
          {
            ++NetMessage.buffer[remoteClient].spamCount;
            ++Main.txMsg;
            Main.txData += count;
            ++Main.txMsgType[msgType];
            Main.txDataType[msgType] += count;
            Netplay.serverSock[remoteClient].networkStream.BeginWrite(NetMessage.buffer[whoAmi].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[remoteClient].ServerWriteCallBack), (object) Netplay.serverSock[remoteClient].networkStream);
          }
          catch
          {
          }
        }
        if (Main.verboseNetplay)
        {
          int num82 = 0;
          while (num82 < count)
            ++num82;
          for (int index88 = 0; index88 < count; ++index88)
          {
            int num83 = (int) NetMessage.buffer[whoAmi].writeBuffer[index88];
          }
        }
        NetMessage.buffer[whoAmi].writeLocked = false;
        if (msgType == 19 && Main.netMode == 1)
        {
          int size = 5;
          NetMessage.SendTileSquare(whoAmi, (int) number2, (int) number3, size);
        }
        if (msgType != 2 || Main.netMode != 2)
          return;
        Netplay.serverSock[whoAmi].kill = true;
      }
    }

    public static void RecieveBytes(byte[] bytes, int streamLength, int i = 256)
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
            Main.statusText = "Bad header lead to a read buffer overflow.";
            Netplay.disconnect = true;
          }
          else
            Netplay.serverSock[i].kill = true;
        }
      }
    }

    public static void CheckBytes(int i = 256)
    {
      lock (NetMessage.buffer[i])
      {
        int num = 0;
        if (NetMessage.buffer[i].totalData < 4)
          return;
        if (NetMessage.buffer[i].messageLength == 0)
          NetMessage.buffer[i].messageLength = BitConverter.ToInt32(NetMessage.buffer[i].readBuffer, 0) + 4;
        for (; NetMessage.buffer[i].totalData >= NetMessage.buffer[i].messageLength + num && NetMessage.buffer[i].messageLength > 0; NetMessage.buffer[i].messageLength = NetMessage.buffer[i].totalData - num < 4 ? 0 : BitConverter.ToInt32(NetMessage.buffer[i].readBuffer, num) + 4)
        {
          if (!Main.ignoreErrors)
          {
            NetMessage.buffer[i].GetData(num + 4, NetMessage.buffer[i].messageLength - 4);
          }
          else
          {
            try
            {
              NetMessage.buffer[i].GetData(num + 4, NetMessage.buffer[i].messageLength - 4);
            }
            catch
            {
            }
          }
          num += NetMessage.buffer[i].messageLength;
        }
        if (num == NetMessage.buffer[i].totalData)
          NetMessage.buffer[i].totalData = 0;
        else if (num > 0)
        {
          Buffer.BlockCopy((Array) NetMessage.buffer[i].readBuffer, num, (Array) NetMessage.buffer[i].readBuffer, 0, NetMessage.buffer[i].totalData - num);
          NetMessage.buffer[i].totalData -= num;
        }
        NetMessage.buffer[i].checkBytes = false;
      }
    }

    public static void BootPlayer(int plr, string msg) => NetMessage.SendData(2, plr, text: msg);

    public static void SendTileSquare(int whoAmi, int tileX, int tileY, int size)
    {
      int num = (size - 1) / 2;
      NetMessage.SendData(20, whoAmi, number: size, number2: ((float) (tileX - num)), number3: ((float) (tileY - num)));
    }

    public static void SendSection(int whoAmi, int sectionX, int sectionY)
    {
      if (Main.netMode != 2)
        return;
      try
      {
        if (sectionX < 0 || sectionY < 0 || sectionX >= Main.maxSectionsX || sectionY >= Main.maxSectionsY)
          return;
        Netplay.serverSock[whoAmi].tileSection[sectionX, sectionY] = true;
        int num1 = sectionX * 200;
        int num2 = sectionY * 150;
        for (int index = num2; index < num2 + 150; ++index)
          NetMessage.SendData(10, whoAmi, number: 200, number2: ((float) num1), number3: ((float) index));
      }
      catch
      {
      }
    }

    public static void greetPlayer(int plr)
    {
      if (Main.motd == "")
        NetMessage.SendData(25, plr, text: (Lang.mp[18] + " " + Main.worldName + "!"), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
      else
        NetMessage.SendData(25, plr, text: Main.motd, number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
      string str = "";
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
          str = !(str == "") ? str + ", " + Main.player[index].name : str + Main.player[index].name;
      }
      NetMessage.SendData(25, plr, text: ("Current players: " + str + "."), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
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
          if ((NetMessage.buffer[remoteClient].broadcast || Netplay.serverSock[remoteClient].state >= 3) && Netplay.serverSock[remoteClient].tcpClient.Connected)
          {
            int index1 = x / 200;
            int index2 = y / 150;
            if (Netplay.serverSock[remoteClient].tileSection[index1, index2])
              NetMessage.SendData(48, remoteClient, number: x, number2: ((float) y));
          }
        }
      }
    }

    public static void syncPlayers()
    {
      bool flag = false;
      for (int index1 = 0; index1 < (int) byte.MaxValue; ++index1)
      {
        int num1 = 0;
        if (Main.player[index1].active)
          num1 = 1;
        if (Netplay.serverSock[index1].state == 10)
        {
          if (Main.autoShutdown && !flag)
          {
            string str1 = Netplay.serverSock[index1].tcpClient.Client.RemoteEndPoint.ToString();
            string str2 = str1;
            for (int index2 = 0; index2 < str1.Length; ++index2)
            {
              if (str1.Substring(index2, 1) == ":")
                str2 = str1.Substring(0, index2);
            }
            if (str2 == "127.0.0.1")
              flag = true;
          }
          NetMessage.SendData(14, ignoreClient: index1, number: index1, number2: ((float) num1));
          NetMessage.SendData(4, ignoreClient: index1, text: Main.player[index1].name, number: index1);
          NetMessage.SendData(13, ignoreClient: index1, number: index1);
          NetMessage.SendData(16, ignoreClient: index1, number: index1);
          NetMessage.SendData(30, ignoreClient: index1, number: index1);
          NetMessage.SendData(45, ignoreClient: index1, number: index1);
          NetMessage.SendData(42, ignoreClient: index1, number: index1);
          NetMessage.SendData(50, ignoreClient: index1, number: index1);
          for (int index3 = 0; index3 < 49; ++index3)
            NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].inventory[index3].name, number: index1, number2: ((float) index3), number3: ((float) Main.player[index1].inventory[index3].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[0].name, number: index1, number2: 49f, number3: ((float) Main.player[index1].armor[0].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[1].name, number: index1, number2: 50f, number3: ((float) Main.player[index1].armor[1].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[2].name, number: index1, number2: 51f, number3: ((float) Main.player[index1].armor[2].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[3].name, number: index1, number2: 52f, number3: ((float) Main.player[index1].armor[3].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[4].name, number: index1, number2: 53f, number3: ((float) Main.player[index1].armor[4].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[5].name, number: index1, number2: 54f, number3: ((float) Main.player[index1].armor[5].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[6].name, number: index1, number2: 55f, number3: ((float) Main.player[index1].armor[6].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[7].name, number: index1, number2: 56f, number3: ((float) Main.player[index1].armor[7].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[8].name, number: index1, number2: 57f, number3: ((float) Main.player[index1].armor[8].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[9].name, number: index1, number2: 58f, number3: ((float) Main.player[index1].armor[9].prefix));
          NetMessage.SendData(5, ignoreClient: index1, text: Main.player[index1].armor[10].name, number: index1, number2: 59f, number3: ((float) Main.player[index1].armor[10].prefix));
          if (!Netplay.serverSock[index1].announced)
          {
            Netplay.serverSock[index1].announced = true;
            NetMessage.SendData(25, ignoreClient: index1, text: (Main.player[index1].name + " " + Lang.mp[19]), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
            if (Main.dedServ)
              Console.WriteLine(Main.player[index1].name + " " + Lang.mp[19]);
          }
        }
        else
        {
          int num2 = 0;
          NetMessage.SendData(14, ignoreClient: index1, number: index1, number2: ((float) num2));
          if (Netplay.serverSock[index1].announced)
          {
            Netplay.serverSock[index1].announced = false;
            NetMessage.SendData(25, ignoreClient: index1, text: (Netplay.serverSock[index1].oldName + " " + Lang.mp[20]), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
            if (Main.dedServ)
              Console.WriteLine(Netplay.serverSock[index1].oldName + " " + Lang.mp[20]);
          }
        }
      }
      for (int number = 0; number < 200; ++number)
      {
        if (Main.npc[number].active && Main.npc[number].townNPC && NPC.TypeToNum(Main.npc[number].type) != -1)
        {
          int num = 0;
          if (Main.npc[number].homeless)
            num = 1;
          NetMessage.SendData(60, number: number, number2: ((float) Main.npc[number].homeTileX), number3: ((float) Main.npc[number].homeTileY), number4: ((float) num));
        }
      }
      if (!Main.autoShutdown || flag)
        return;
      WorldGen.saveWorld();
      Netplay.disconnect = true;
    }
  }
}
