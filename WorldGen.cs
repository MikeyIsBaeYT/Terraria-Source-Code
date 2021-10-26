// Decompiled with JetBrains decompiler
// Type: Terraria.WorldGen
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Terraria
{
  internal class WorldGen
  {
    public static int c = 0;
    public static int m = 0;
    public static int a = 0;
    public static int co = 0;
    public static int ir = 0;
    public static int si = 0;
    public static int go = 0;
    public static int maxMech = 1000;
    public static int[] mechX = new int[WorldGen.maxMech];
    public static int[] mechY = new int[WorldGen.maxMech];
    public static int numMechs = 0;
    public static int[] mechTime = new int[WorldGen.maxMech];
    public static int maxWire = 1000;
    public static int[] wireX = new int[WorldGen.maxWire];
    public static int[] wireY = new int[WorldGen.maxWire];
    public static int numWire = 0;
    public static int[] noWireX = new int[WorldGen.maxWire];
    public static int[] noWireY = new int[WorldGen.maxWire];
    public static int numNoWire = 0;
    public static int maxPump = 20;
    public static int[] inPumpX = new int[WorldGen.maxPump];
    public static int[] inPumpY = new int[WorldGen.maxPump];
    public static int numInPump = 0;
    public static int[] outPumpX = new int[WorldGen.maxPump];
    public static int[] outPumpY = new int[WorldGen.maxPump];
    public static int numOutPump = 0;
    public static int totalEvil = 0;
    public static int totalGood = 0;
    public static int totalSolid = 0;
    public static int totalEvil2 = 0;
    public static int totalGood2 = 0;
    public static int totalSolid2 = 0;
    public static byte tEvil = 0;
    public static byte tGood = 0;
    public static int totalX = 0;
    public static int totalD = 0;
    public static bool hardLock = false;
    private static object padlock = new object();
    public static int lavaLine;
    public static int waterLine;
    public static bool noTileActions = false;
    public static bool spawnEye = false;
    public static bool gen = false;
    public static bool shadowOrbSmashed = false;
    public static int shadowOrbCount = 0;
    public static int altarCount = 0;
    public static bool spawnMeteor = false;
    public static bool loadFailed = false;
    public static bool loadSuccess = false;
    public static bool worldCleared = false;
    public static bool worldBackup = false;
    public static bool loadBackup = false;
    private static int lastMaxTilesX = 0;
    private static int lastMaxTilesY = 0;
    public static bool saveLock = false;
    private static bool mergeUp = false;
    private static bool mergeDown = false;
    private static bool mergeLeft = false;
    private static bool mergeRight = false;
    private static int tempMoonPhase = Main.moonPhase;
    private static bool tempDayTime = Main.dayTime;
    private static bool tempBloodMoon = Main.bloodMoon;
    private static double tempTime = Main.time;
    private static bool stopDrops = false;
    private static bool mudWall = false;
    private static int grassSpread = 0;
    public static bool noLiquidCheck = false;
    [ThreadStatic]
    public static Random genRand = new Random();
    public static string statusText = "";
    public static bool destroyObject = false;
    public static int spawnDelay = 0;
    public static int spawnNPC = 0;
    public static int maxRoomTiles = 1900;
    public static int numRoomTiles;
    public static int[] roomX = new int[WorldGen.maxRoomTiles];
    public static int[] roomY = new int[WorldGen.maxRoomTiles];
    public static int roomX1;
    public static int roomX2;
    public static int roomY1;
    public static int roomY2;
    public static bool canSpawn;
    public static bool[] houseTile = new bool[150];
    public static int bestX = 0;
    public static int bestY = 0;
    public static int hiScore = 0;
    public static int dungeonX;
    public static int dungeonY;
    public static Vector2 lastDungeonHall = new Vector2();
    public static int maxDRooms = 100;
    public static int numDRooms = 0;
    public static int[] dRoomX = new int[WorldGen.maxDRooms];
    public static int[] dRoomY = new int[WorldGen.maxDRooms];
    public static int[] dRoomSize = new int[WorldGen.maxDRooms];
    private static bool[] dRoomTreasure = new bool[WorldGen.maxDRooms];
    private static int[] dRoomL = new int[WorldGen.maxDRooms];
    private static int[] dRoomR = new int[WorldGen.maxDRooms];
    private static int[] dRoomT = new int[WorldGen.maxDRooms];
    private static int[] dRoomB = new int[WorldGen.maxDRooms];
    private static int numDDoors;
    private static int[] DDoorX = new int[300];
    private static int[] DDoorY = new int[300];
    private static int[] DDoorPos = new int[300];
    private static int numDPlats;
    private static int[] DPlatX = new int[300];
    private static int[] DPlatY = new int[300];
    private static int[] JChestX = new int[100];
    private static int[] JChestY = new int[100];
    private static int numJChests = 0;
    public static int dEnteranceX = 0;
    public static bool dSurface = false;
    private static double dxStrength1;
    private static double dyStrength1;
    private static double dxStrength2;
    private static double dyStrength2;
    private static int dMinX;
    private static int dMaxX;
    private static int dMinY;
    private static int dMaxY;
    private static int numIslandHouses = 0;
    private static int houseCount = 0;
    private static int[] fihX = new int[300];
    private static int[] fihY = new int[300];
    private static int numMCaves = 0;
    private static int[] mCaveX = new int[300];
    private static int[] mCaveY = new int[300];
    private static int JungleX = 0;
    private static int hellChest = 0;
    private static bool roomTorch;
    private static bool roomDoor;
    private static bool roomChair;
    private static bool roomTable;
    private static bool roomOccupied;
    private static bool roomEvil;

    public static bool MoveNPC(int x, int y, int n)
    {
      if (!WorldGen.StartRoomCheck(x, y))
      {
        Main.NewText(Lang.inter[40], G: (byte) 240, B: (byte) 20);
        return false;
      }
      if (!WorldGen.RoomNeeds(WorldGen.spawnNPC))
      {
        if (Lang.lang <= 1)
        {
          int index1 = 0;
          string[] strArray = new string[4];
          if (!WorldGen.roomTorch)
          {
            strArray[index1] = "a light source";
            ++index1;
          }
          if (!WorldGen.roomDoor)
          {
            strArray[index1] = "a door";
            ++index1;
          }
          if (!WorldGen.roomTable)
          {
            strArray[index1] = "a table";
            ++index1;
          }
          if (!WorldGen.roomChair)
          {
            strArray[index1] = "a chair";
            ++index1;
          }
          string str = "";
          for (int index2 = 0; index2 < index1; ++index2)
          {
            if (index1 == 2 && index2 == 1)
              str += " and ";
            else if (index2 > 0 && index2 != index1 - 1)
              str += ", and ";
            else if (index2 > 0)
              str += ", ";
            str += strArray[index2];
          }
          Main.NewText("This housing is missing " + str + ".", G: (byte) 240, B: (byte) 20);
        }
        else
          Main.NewText(Lang.inter[39], G: (byte) 240, B: (byte) 20);
        return false;
      }
      WorldGen.ScoreRoom();
      if (WorldGen.hiScore > 0)
        return true;
      if (WorldGen.roomOccupied)
        Main.NewText(Lang.inter[41], G: (byte) 240, B: (byte) 20);
      else if (WorldGen.roomEvil)
        Main.NewText(Lang.inter[42], G: (byte) 240, B: (byte) 20);
      else
        Main.NewText(Lang.inter[39], G: (byte) 240, B: (byte) 20);
      return false;
    }

    public static void moveRoom(int x, int y, int n)
    {
      if (Main.netMode == 1)
      {
        NetMessage.SendData(60, number: n, number2: ((float) x), number3: ((float) y), number4: 1f);
      }
      else
      {
        WorldGen.spawnNPC = Main.npc[n].type;
        Main.npc[n].homeless = true;
        WorldGen.SpawnNPC(x, y);
      }
    }

    public static void kickOut(int n)
    {
      if (Main.netMode == 1)
        NetMessage.SendData(60, number: n);
      else
        Main.npc[n].homeless = true;
    }

    public static void SpawnNPC(int x, int y)
    {
      if (Main.wallHouse[(int) Main.tile[x, y].wall])
        WorldGen.canSpawn = true;
      if (!WorldGen.canSpawn || !WorldGen.StartRoomCheck(x, y) || !WorldGen.RoomNeeds(WorldGen.spawnNPC))
        return;
      WorldGen.ScoreRoom();
      if (WorldGen.hiScore <= 0)
        return;
      int index1 = -1;
      for (int index2 = 0; index2 < 200; ++index2)
      {
        if (Main.npc[index2].active && Main.npc[index2].homeless && Main.npc[index2].type == WorldGen.spawnNPC)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
      {
        int index3 = WorldGen.bestX;
        int index4 = WorldGen.bestY;
        bool flag = false;
        if (!flag)
        {
          flag = true;
          Rectangle rectangle = new Rectangle(index3 * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, index4 * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
          for (int index5 = 0; index5 < (int) byte.MaxValue; ++index5)
          {
            if (Main.player[index5].active && new Rectangle((int) Main.player[index5].position.X, (int) Main.player[index5].position.Y, Main.player[index5].width, Main.player[index5].height).Intersects(rectangle))
            {
              flag = false;
              break;
            }
          }
        }
        if (!flag && (double) index4 <= Main.worldSurface)
        {
          for (int index6 = 1; index6 < 500; ++index6)
          {
            for (int index7 = 0; index7 < 2; ++index7)
            {
              index3 = index7 != 0 ? WorldGen.bestX - index6 : WorldGen.bestX + index6;
              if (index3 > 10 && index3 < Main.maxTilesX - 10)
              {
                int num1 = WorldGen.bestY - index6;
                double num2 = (double) (WorldGen.bestY + index6);
                if (num1 < 10)
                  num1 = 10;
                if (num2 > Main.worldSurface)
                  num2 = Main.worldSurface;
                for (int index8 = num1; (double) index8 < num2; ++index8)
                {
                  index4 = index8;
                  if (Main.tile[index3, index4].active && Main.tileSolid[(int) Main.tile[index3, index4].type])
                  {
                    if (!Collision.SolidTiles(index3 - 1, index3 + 1, index4 - 3, index4 - 1))
                    {
                      flag = true;
                      Rectangle rectangle = new Rectangle(index3 * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, index4 * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                      for (int index9 = 0; index9 < (int) byte.MaxValue; ++index9)
                      {
                        if (Main.player[index9].active && new Rectangle((int) Main.player[index9].position.X, (int) Main.player[index9].position.Y, Main.player[index9].width, Main.player[index9].height).Intersects(rectangle))
                        {
                          flag = false;
                          break;
                        }
                      }
                      break;
                    }
                    break;
                  }
                }
              }
              if (flag)
                break;
            }
            if (flag)
              break;
          }
        }
        int index10 = NPC.NewNPC(index3 * 16, index4 * 16, WorldGen.spawnNPC, 1);
        Main.npc[index10].homeTileX = WorldGen.bestX;
        Main.npc[index10].homeTileY = WorldGen.bestY;
        if (index3 < WorldGen.bestX)
          Main.npc[index10].direction = 1;
        else if (index3 > WorldGen.bestX)
          Main.npc[index10].direction = -1;
        Main.npc[index10].netUpdate = true;
        string str = Main.npc[index10].name;
        if (Main.chrName[Main.npc[index10].type] != "")
          str = Lang.lang > 1 ? Main.chrName[Main.npc[index10].type] : Main.chrName[Main.npc[index10].type] + " " + Lang.the + Main.npc[index10].name;
        switch (Main.netMode)
        {
          case 0:
            Main.NewText(str + " " + Lang.misc[18], (byte) 50, (byte) 125);
            break;
          case 2:
            NetMessage.SendData(25, text: (str + " " + Lang.misc[18]), number: ((int) byte.MaxValue), number2: 50f, number3: 125f, number4: ((float) byte.MaxValue));
            break;
        }
      }
      else
      {
        WorldGen.spawnNPC = 0;
        Main.npc[index1].homeTileX = WorldGen.bestX;
        Main.npc[index1].homeTileY = WorldGen.bestY;
        Main.npc[index1].homeless = false;
      }
      WorldGen.spawnNPC = 0;
    }

    public static bool RoomNeeds(int npcType)
    {
      WorldGen.roomChair = false;
      WorldGen.roomDoor = false;
      WorldGen.roomTable = false;
      WorldGen.roomTorch = false;
      if (WorldGen.houseTile[15] || WorldGen.houseTile[79] || WorldGen.houseTile[89] || WorldGen.houseTile[102])
        WorldGen.roomChair = true;
      if (WorldGen.houseTile[14] || WorldGen.houseTile[18] || WorldGen.houseTile[87] || WorldGen.houseTile[88] || WorldGen.houseTile[90] || WorldGen.houseTile[101])
        WorldGen.roomTable = true;
      if (WorldGen.houseTile[4] || WorldGen.houseTile[33] || WorldGen.houseTile[34] || WorldGen.houseTile[35] || WorldGen.houseTile[36] || WorldGen.houseTile[42] || WorldGen.houseTile[49] || WorldGen.houseTile[93] || WorldGen.houseTile[95] || WorldGen.houseTile[98] || WorldGen.houseTile[100] || WorldGen.houseTile[149])
        WorldGen.roomTorch = true;
      if (WorldGen.houseTile[10] || WorldGen.houseTile[11] || WorldGen.houseTile[19])
        WorldGen.roomDoor = true;
      WorldGen.canSpawn = WorldGen.roomChair && WorldGen.roomTable && WorldGen.roomDoor && WorldGen.roomTorch;
      return WorldGen.canSpawn;
    }

    public static void QuickFindHome(int npc)
    {
      if (Main.npc[npc].homeTileX <= 10 || Main.npc[npc].homeTileY <= 10 || Main.npc[npc].homeTileX >= Main.maxTilesX - 10 || Main.npc[npc].homeTileY >= Main.maxTilesY)
        return;
      WorldGen.canSpawn = false;
      WorldGen.StartRoomCheck(Main.npc[npc].homeTileX, Main.npc[npc].homeTileY - 1);
      if (!WorldGen.canSpawn)
      {
        for (int x = Main.npc[npc].homeTileX - 1; x < Main.npc[npc].homeTileX + 2; ++x)
        {
          int y = Main.npc[npc].homeTileY - 1;
          while (y < Main.npc[npc].homeTileY + 2 && !WorldGen.StartRoomCheck(x, y))
            ++y;
        }
      }
      if (!WorldGen.canSpawn)
      {
        int num = 10;
        for (int x = Main.npc[npc].homeTileX - num; x <= Main.npc[npc].homeTileX + num; x += 2)
        {
          int y = Main.npc[npc].homeTileY - num;
          while (y <= Main.npc[npc].homeTileY + num && !WorldGen.StartRoomCheck(x, y))
            y += 2;
        }
      }
      if (WorldGen.canSpawn)
      {
        WorldGen.RoomNeeds(Main.npc[npc].type);
        if (WorldGen.canSpawn)
          WorldGen.ScoreRoom(npc);
        if (WorldGen.canSpawn && WorldGen.hiScore > 0)
        {
          Main.npc[npc].homeTileX = WorldGen.bestX;
          Main.npc[npc].homeTileY = WorldGen.bestY;
          Main.npc[npc].homeless = false;
          WorldGen.canSpawn = false;
        }
        else
          Main.npc[npc].homeless = true;
      }
      else
        Main.npc[npc].homeless = true;
    }

    public static void ScoreRoom(int ignoreNPC = -1)
    {
      WorldGen.roomOccupied = false;
      WorldGen.roomEvil = false;
      for (int index1 = 0; index1 < 200; ++index1)
      {
        if (Main.npc[index1].active && Main.npc[index1].townNPC && ignoreNPC != index1 && !Main.npc[index1].homeless)
        {
          for (int index2 = 0; index2 < WorldGen.numRoomTiles; ++index2)
          {
            if (Main.npc[index1].homeTileX == WorldGen.roomX[index2] && Main.npc[index1].homeTileY == WorldGen.roomY[index2])
            {
              bool flag = false;
              for (int index3 = 0; index3 < WorldGen.numRoomTiles; ++index3)
              {
                if (Main.npc[index1].homeTileX == WorldGen.roomX[index3] && Main.npc[index1].homeTileY - 1 == WorldGen.roomY[index3])
                {
                  flag = true;
                  break;
                }
              }
              if (flag)
              {
                WorldGen.roomOccupied = true;
                WorldGen.hiScore = -1;
                return;
              }
            }
          }
        }
      }
      WorldGen.hiScore = 0;
      int num1 = 0;
      int num2 = WorldGen.roomX1 - Main.zoneX / 2 / 16 - 1 - Lighting.offScreenTiles;
      int num3 = WorldGen.roomX2 + Main.zoneX / 2 / 16 + 1 + Lighting.offScreenTiles;
      int num4 = WorldGen.roomY1 - Main.zoneY / 2 / 16 - 1 - Lighting.offScreenTiles;
      int num5 = WorldGen.roomY2 + Main.zoneY / 2 / 16 + 1 + Lighting.offScreenTiles;
      if (num2 < 0)
        num2 = 0;
      if (num3 >= Main.maxTilesX)
        num3 = Main.maxTilesX - 1;
      if (num4 < 0)
        num4 = 0;
      if (num5 > Main.maxTilesX)
        num5 = Main.maxTilesX;
      for (int index4 = num2 + 1; index4 < num3; ++index4)
      {
        for (int index5 = num4 + 2; index5 < num5 + 2; ++index5)
        {
          if (Main.tile[index4, index5].active)
          {
            if (Main.tile[index4, index5].type == (byte) 23 || Main.tile[index4, index5].type == (byte) 24 || Main.tile[index4, index5].type == (byte) 25 || Main.tile[index4, index5].type == (byte) 32 || Main.tile[index4, index5].type == (byte) 112)
              ++num1;
            else if (Main.tile[index4, index5].type == (byte) 27)
              num1 -= 5;
            else if (Main.tile[index4, index5].type == (byte) 109 || Main.tile[index4, index5].type == (byte) 110 || Main.tile[index4, index5].type == (byte) 113 || Main.tile[index4, index5].type == (byte) 116)
              --num1;
          }
        }
      }
      if (num1 < 50)
        num1 = 0;
      int num6 = -num1;
      if (num6 <= -250)
      {
        WorldGen.hiScore = num6;
        WorldGen.roomEvil = true;
      }
      else
      {
        int roomX1 = WorldGen.roomX1;
        int roomX2 = WorldGen.roomX2;
        int roomY1 = WorldGen.roomY1;
        int roomY2 = WorldGen.roomY2;
        for (int index6 = roomX1 + 1; index6 < roomX2; ++index6)
        {
          for (int index7 = roomY1 + 2; index7 < roomY2 + 2; ++index7)
          {
            if (Main.tile[index6, index7].active)
            {
              int num7 = num6;
              if (Main.tileSolid[(int) Main.tile[index6, index7].type] && !Main.tileSolidTop[(int) Main.tile[index6, index7].type] && !Collision.SolidTiles(index6 - 1, index6 + 1, index7 - 3, index7 - 1) && Main.tile[index6 - 1, index7].active && Main.tileSolid[(int) Main.tile[index6 - 1, index7].type] && Main.tile[index6 + 1, index7].active && Main.tileSolid[(int) Main.tile[index6 + 1, index7].type])
              {
                for (int index8 = index6 - 2; index8 < index6 + 3; ++index8)
                {
                  for (int index9 = index7 - 4; index9 < index7; ++index9)
                  {
                    if (Main.tile[index8, index9].active)
                    {
                      if (index8 == index6)
                        num7 -= 15;
                      else if (Main.tile[index8, index9].type == (byte) 10 || Main.tile[index8, index9].type == (byte) 11)
                        num7 -= 20;
                      else if (Main.tileSolid[(int) Main.tile[index8, index9].type])
                        num7 -= 5;
                      else
                        num7 += 5;
                    }
                  }
                }
                if (num7 > WorldGen.hiScore)
                {
                  bool flag = false;
                  for (int index10 = 0; index10 < WorldGen.numRoomTiles; ++index10)
                  {
                    if (WorldGen.roomX[index10] == index6 && WorldGen.roomY[index10] == index7)
                    {
                      flag = true;
                      break;
                    }
                  }
                  if (flag)
                  {
                    WorldGen.hiScore = num7;
                    WorldGen.bestX = index6;
                    WorldGen.bestY = index7;
                  }
                }
              }
            }
          }
        }
      }
    }

    public static bool StartRoomCheck(int x, int y)
    {
      WorldGen.roomX1 = x;
      WorldGen.roomX2 = x;
      WorldGen.roomY1 = y;
      WorldGen.roomY2 = y;
      WorldGen.numRoomTiles = 0;
      for (int index = 0; index < 150; ++index)
        WorldGen.houseTile[index] = false;
      WorldGen.canSpawn = true;
      if (Main.tile[x, y].active && Main.tileSolid[(int) Main.tile[x, y].type])
        WorldGen.canSpawn = false;
      WorldGen.CheckRoom(x, y);
      if (WorldGen.numRoomTiles < 60)
        WorldGen.canSpawn = false;
      return WorldGen.canSpawn;
    }

    public static void CheckRoom(int x, int y)
    {
      if (!WorldGen.canSpawn)
        return;
      if (x < 10 || y < 10 || x >= Main.maxTilesX - 10 || y >= WorldGen.lastMaxTilesY - 10)
      {
        WorldGen.canSpawn = false;
      }
      else
      {
        for (int index = 0; index < WorldGen.numRoomTiles; ++index)
        {
          if (WorldGen.roomX[index] == x && WorldGen.roomY[index] == y)
            return;
        }
        WorldGen.roomX[WorldGen.numRoomTiles] = x;
        WorldGen.roomY[WorldGen.numRoomTiles] = y;
        ++WorldGen.numRoomTiles;
        if (WorldGen.numRoomTiles >= WorldGen.maxRoomTiles)
        {
          WorldGen.canSpawn = false;
        }
        else
        {
          if (Main.tile[x, y].active)
          {
            WorldGen.houseTile[(int) Main.tile[x, y].type] = true;
            if (Main.tileSolid[(int) Main.tile[x, y].type] || Main.tile[x, y].type == (byte) 11)
              return;
          }
          if (x < WorldGen.roomX1)
            WorldGen.roomX1 = x;
          if (x > WorldGen.roomX2)
            WorldGen.roomX2 = x;
          if (y < WorldGen.roomY1)
            WorldGen.roomY1 = y;
          if (y > WorldGen.roomY2)
            WorldGen.roomY2 = y;
          bool flag1 = false;
          bool flag2 = false;
          for (int index = -2; index < 3; ++index)
          {
            if (Main.wallHouse[(int) Main.tile[x + index, y].wall])
              flag1 = true;
            if (Main.tile[x + index, y].active && (Main.tileSolid[(int) Main.tile[x + index, y].type] || Main.tile[x + index, y].type == (byte) 11))
              flag1 = true;
            if (Main.wallHouse[(int) Main.tile[x, y + index].wall])
              flag2 = true;
            if (Main.tile[x, y + index].active && (Main.tileSolid[(int) Main.tile[x, y + index].type] || Main.tile[x, y + index].type == (byte) 11))
              flag2 = true;
          }
          if (!flag1 || !flag2)
          {
            WorldGen.canSpawn = false;
          }
          else
          {
            for (int x1 = x - 1; x1 < x + 2; ++x1)
            {
              for (int y1 = y - 1; y1 < y + 2; ++y1)
              {
                if ((x1 != x || y1 != y) && WorldGen.canSpawn)
                  WorldGen.CheckRoom(x1, y1);
              }
            }
          }
        }
      }
    }

    public static void dropMeteor()
    {
      bool flag = true;
      int num1 = 0;
      if (Main.netMode == 1)
        return;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
        {
          flag = false;
          break;
        }
      }
      int num2 = 0;
      int num3 = (int) (400.0 * (double) (Main.maxTilesX / 4200));
      for (int index1 = 5; index1 < Main.maxTilesX - 5; ++index1)
      {
        for (int index2 = 5; (double) index2 < Main.worldSurface; ++index2)
        {
          if (Main.tile[index1, index2].active && Main.tile[index1, index2].type == (byte) 37)
          {
            ++num2;
            if (num2 > num3)
              return;
          }
        }
      }
      while (!flag)
      {
        float num4 = (float) Main.maxTilesX * 0.08f;
        int i = Main.rand.Next(50, Main.maxTilesX - 50);
        while ((double) i > (double) Main.spawnTileX - (double) num4 && (double) i < (double) Main.spawnTileX + (double) num4)
          i = Main.rand.Next(50, Main.maxTilesX - 50);
        for (int j = Main.rand.Next(100); j < Main.maxTilesY; ++j)
        {
          if (Main.tile[i, j].active && Main.tileSolid[(int) Main.tile[i, j].type])
          {
            flag = WorldGen.meteor(i, j);
            break;
          }
        }
        ++num1;
        if (num1 >= 100)
          break;
      }
    }

    public static bool meteor(int i, int j)
    {
      if (i < 50 || i > Main.maxTilesX - 50 || j < 50 || j > Main.maxTilesY - 50)
        return false;
      int num1 = 25;
      Rectangle rectangle1 = new Rectangle((i - num1) * 16, (j - num1) * 16, num1 * 2 * 16, num1 * 2 * 16);
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
        {
          Rectangle rectangle2 = new Rectangle((int) ((double) Main.player[index].position.X + (double) (Main.player[index].width / 2) - (double) (NPC.sWidth / 2) - (double) NPC.safeRangeX), (int) ((double) Main.player[index].position.Y + (double) (Main.player[index].height / 2) - (double) (NPC.sHeight / 2) - (double) NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
          if (rectangle1.Intersects(rectangle2))
            return false;
        }
      }
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active)
        {
          Rectangle rectangle3 = new Rectangle((int) Main.npc[index].position.X, (int) Main.npc[index].position.Y, Main.npc[index].width, Main.npc[index].height);
          if (rectangle1.Intersects(rectangle3))
            return false;
        }
      }
      for (int index1 = i - num1; index1 < i + num1; ++index1)
      {
        for (int index2 = j - num1; index2 < j + num1; ++index2)
        {
          if (Main.tile[index1, index2].active && Main.tile[index1, index2].type == (byte) 21)
            return false;
        }
      }
      WorldGen.stopDrops = true;
      int num2 = 15;
      for (int index3 = i - num2; index3 < i + num2; ++index3)
      {
        for (int index4 = j - num2; index4 < j + num2; ++index4)
        {
          if (index4 > j + Main.rand.Next(-2, 3) - 5 && (double) (Math.Abs(i - index3) + Math.Abs(j - index4)) < (double) num2 * 1.5 + (double) Main.rand.Next(-5, 5))
          {
            if (!Main.tileSolid[(int) Main.tile[index3, index4].type])
              Main.tile[index3, index4].active = false;
            Main.tile[index3, index4].type = (byte) 37;
          }
        }
      }
      int num3 = 10;
      for (int index5 = i - num3; index5 < i + num3; ++index5)
      {
        for (int index6 = j - num3; index6 < j + num3; ++index6)
        {
          if (index6 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - index5) + Math.Abs(j - index6) < num3 + Main.rand.Next(-3, 4))
            Main.tile[index5, index6].active = false;
        }
      }
      int num4 = 16;
      for (int i1 = i - num4; i1 < i + num4; ++i1)
      {
        for (int j1 = j - num4; j1 < j + num4; ++j1)
        {
          if (Main.tile[i1, j1].type == (byte) 5 || Main.tile[i1, j1].type == (byte) 32)
            WorldGen.KillTile(i1, j1);
          WorldGen.SquareTileFrame(i1, j1);
          WorldGen.SquareWallFrame(i1, j1);
        }
      }
      int num5 = 23;
      for (int i2 = i - num5; i2 < i + num5; ++i2)
      {
        for (int j2 = j - num5; j2 < j + num5; ++j2)
        {
          if (Main.tile[i2, j2].active && Main.rand.Next(10) == 0 && (double) (Math.Abs(i - i2) + Math.Abs(j - j2)) < (double) num5 * 1.3)
          {
            if (Main.tile[i2, j2].type == (byte) 5 || Main.tile[i2, j2].type == (byte) 32)
              WorldGen.KillTile(i2, j2);
            Main.tile[i2, j2].type = (byte) 37;
            WorldGen.SquareTileFrame(i2, j2);
          }
        }
      }
      WorldGen.stopDrops = false;
      if (Main.netMode == 0)
        Main.NewText(Lang.gen[59], (byte) 50, B: (byte) 130);
      else if (Main.netMode == 2)
        NetMessage.SendData(25, text: Lang.gen[59], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
      if (Main.netMode != 1)
        NetMessage.SendTileSquare(-1, i, j, 30);
      return true;
    }

    public static void setWorldSize()
    {
      Main.bottomWorld = (float) (Main.maxTilesY * 16);
      Main.rightWorld = (float) (Main.maxTilesX * 16);
      Main.maxSectionsX = Main.maxTilesX / 200;
      Main.maxSectionsY = Main.maxTilesY / 150;
    }

    public static void worldGenCallBack(object threadContext)
    {
      Main.PlaySound(10);
      WorldGen.clearWorld();
      WorldGen.generateWorld();
      WorldGen.saveWorld(true);
      Main.LoadWorlds();
      if (Main.menuMode == 10)
        Main.menuMode = 6;
      Main.PlaySound(10);
    }

    public static void CreateNewWorld() => ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.worldGenCallBack), (object) 1);

    public static void SaveAndQuitCallBack(object threadContext)
    {
      Main.menuMode = 10;
      Main.gameMenu = true;
      Player.SavePlayer(Main.player[Main.myPlayer], Main.playerPathName);
      if (Main.netMode == 0)
      {
        WorldGen.saveWorld();
        Main.PlaySound(10);
      }
      else
      {
        Netplay.disconnect = true;
        Main.netMode = 0;
      }
      Main.menuMode = 0;
    }

    public static void SaveAndQuit()
    {
      Main.PlaySound(11);
      ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.SaveAndQuitCallBack), (object) 1);
    }

    public static void playWorldCallBack(object threadContext)
    {
      if (Main.rand == null)
        Main.rand = new Random((int) DateTime.Now.Ticks);
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (index != Main.myPlayer)
          Main.player[index].active = false;
      }
      WorldGen.loadWorld();
      if (WorldGen.loadFailed || !WorldGen.loadSuccess)
      {
        WorldGen.loadWorld();
        if (WorldGen.loadFailed || !WorldGen.loadSuccess)
        {
          WorldGen.worldBackup = File.Exists(Main.worldPathName + ".bak");
          if (!Main.dedServ)
          {
            if (WorldGen.worldBackup)
            {
              Main.menuMode = 200;
              return;
            }
            Main.menuMode = 201;
            return;
          }
          if (WorldGen.worldBackup)
          {
            File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
            File.Delete(Main.worldPathName + ".bak");
            WorldGen.loadWorld();
            if (WorldGen.loadFailed || !WorldGen.loadSuccess)
            {
              WorldGen.loadWorld();
              if (WorldGen.loadFailed || !WorldGen.loadSuccess)
              {
                Console.WriteLine("Load failed!");
                return;
              }
            }
          }
          else
          {
            Console.WriteLine("Load failed!  No backup found.");
            return;
          }
        }
      }
      WorldGen.EveryTileFrame();
      if (Main.gameMenu)
        Main.gameMenu = false;
      Main.player[Main.myPlayer].Spawn();
      Main.player[Main.myPlayer].UpdatePlayer(Main.myPlayer);
      Main.dayTime = WorldGen.tempDayTime;
      Main.time = WorldGen.tempTime;
      Main.moonPhase = WorldGen.tempMoonPhase;
      Main.bloodMoon = WorldGen.tempBloodMoon;
      Main.PlaySound(11);
      Main.resetClouds = true;
    }

    public static void playWorld() => ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.playWorldCallBack), (object) 1);

    public static void saveAndPlayCallBack(object threadContext) => WorldGen.saveWorld();

    public static void saveAndPlay() => ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.saveAndPlayCallBack), (object) 1);

    public static void saveToonWhilePlayingCallBack(object threadContext) => Player.SavePlayer(Main.player[Main.myPlayer], Main.playerPathName);

    public static void saveToonWhilePlaying() => ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.saveToonWhilePlayingCallBack), (object) 1);

    public static void serverLoadWorldCallBack(object threadContext)
    {
      WorldGen.loadWorld();
      if (WorldGen.loadFailed || !WorldGen.loadSuccess)
      {
        WorldGen.loadWorld();
        if (WorldGen.loadFailed || !WorldGen.loadSuccess)
        {
          WorldGen.worldBackup = File.Exists(Main.worldPathName + ".bak");
          if (!Main.dedServ)
          {
            if (WorldGen.worldBackup)
            {
              Main.menuMode = 200;
              return;
            }
            Main.menuMode = 201;
            return;
          }
          if (WorldGen.worldBackup)
          {
            File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
            File.Delete(Main.worldPathName + ".bak");
            WorldGen.loadWorld();
            if (WorldGen.loadFailed || !WorldGen.loadSuccess)
            {
              WorldGen.loadWorld();
              if (WorldGen.loadFailed || !WorldGen.loadSuccess)
              {
                Console.WriteLine("Load failed!");
                return;
              }
            }
          }
          else
          {
            Console.WriteLine("Load failed!  No backup found.");
            return;
          }
        }
      }
      Main.PlaySound(10);
      Netplay.StartServer();
      Main.dayTime = WorldGen.tempDayTime;
      Main.time = WorldGen.tempTime;
      Main.moonPhase = WorldGen.tempMoonPhase;
      Main.bloodMoon = WorldGen.tempBloodMoon;
    }

    public static void serverLoadWorld() => ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.serverLoadWorldCallBack), (object) 1);

    public static void clearWorld()
    {
      WorldGen.totalSolid2 = 0;
      WorldGen.totalGood2 = 0;
      WorldGen.totalEvil2 = 0;
      WorldGen.totalSolid = 0;
      WorldGen.totalGood = 0;
      WorldGen.totalEvil = 0;
      WorldGen.totalX = 0;
      WorldGen.totalD = 0;
      WorldGen.tEvil = (byte) 0;
      WorldGen.tGood = (byte) 0;
      NPC.clrNames();
      Main.trashItem = new Item();
      WorldGen.spawnEye = false;
      WorldGen.spawnNPC = 0;
      WorldGen.shadowOrbCount = 0;
      WorldGen.altarCount = 0;
      Main.hardMode = false;
      Main.helpText = 0;
      Main.dungeonX = 0;
      Main.dungeonY = 0;
      NPC.downedBoss1 = false;
      NPC.downedBoss2 = false;
      NPC.downedBoss3 = false;
      NPC.savedGoblin = false;
      NPC.savedWizard = false;
      NPC.savedMech = false;
      NPC.downedGoblins = false;
      NPC.downedClown = false;
      NPC.downedFrost = false;
      WorldGen.shadowOrbSmashed = false;
      WorldGen.spawnMeteor = false;
      WorldGen.stopDrops = false;
      Main.invasionDelay = 0;
      Main.invasionType = 0;
      Main.invasionSize = 0;
      Main.invasionWarn = 0;
      Main.invasionX = 0.0;
      WorldGen.noLiquidCheck = false;
      Liquid.numLiquid = 0;
      LiquidBuffer.numLiquidBuffer = 0;
      if (Main.netMode == 1 || WorldGen.lastMaxTilesX > Main.maxTilesX || WorldGen.lastMaxTilesY > Main.maxTilesY)
      {
        for (int index1 = 0; index1 < WorldGen.lastMaxTilesX; ++index1)
        {
          float num = (float) index1 / (float) WorldGen.lastMaxTilesX;
          Main.statusText = Lang.gen[46] + " " + (object) (int) ((double) num * 100.0 + 1.0) + "%";
          for (int index2 = 0; index2 < WorldGen.lastMaxTilesY; ++index2)
            Main.tile[index1, index2] = (Tile) null;
        }
      }
      WorldGen.lastMaxTilesX = Main.maxTilesX;
      WorldGen.lastMaxTilesY = Main.maxTilesY;
      if (Main.netMode != 1)
      {
        for (int index3 = 0; index3 < Main.maxTilesX; ++index3)
        {
          float num = (float) index3 / (float) Main.maxTilesX;
          Main.statusText = Lang.gen[47] + " " + (object) (int) ((double) num * 100.0 + 1.0) + "%";
          for (int index4 = 0; index4 < Main.maxTilesY; ++index4)
            Main.tile[index3, index4] = new Tile();
        }
      }
      for (int index = 0; index < 2000; ++index)
        Main.dust[index] = new Dust();
      for (int index = 0; index < 200; ++index)
        Main.gore[index] = new Gore();
      for (int index = 0; index < 200; ++index)
        Main.item[index] = new Item();
      for (int index = 0; index < 200; ++index)
        Main.npc[index] = new NPC();
      for (int index = 0; index < 1000; ++index)
        Main.projectile[index] = new Projectile();
      for (int index = 0; index < 1000; ++index)
        Main.chest[index] = (Chest) null;
      for (int index = 0; index < 1000; ++index)
        Main.sign[index] = (Sign) null;
      for (int index = 0; index < Liquid.resLiquid; ++index)
        Main.liquid[index] = new Liquid();
      for (int index = 0; index < 10000; ++index)
        Main.liquidBuffer[index] = new LiquidBuffer();
      WorldGen.setWorldSize();
      WorldGen.worldCleared = true;
    }

    public static void saveWorld(bool resetTime = false)
    {
      if (Main.worldName == "")
        Main.worldName = "World";
      if (WorldGen.saveLock)
        return;
      WorldGen.saveLock = true;
      while (WorldGen.hardLock)
        Main.statusText = Lang.gen[48];
      lock (WorldGen.padlock)
      {
        try
        {
          Directory.CreateDirectory(Main.WorldPath);
        }
        catch
        {
        }
        if (Main.skipMenu)
          return;
        bool flag = Main.dayTime;
        WorldGen.tempTime = Main.time;
        WorldGen.tempMoonPhase = Main.moonPhase;
        WorldGen.tempBloodMoon = Main.bloodMoon;
        if (resetTime)
        {
          flag = true;
          WorldGen.tempTime = 13500.0;
          WorldGen.tempMoonPhase = 0;
          WorldGen.tempBloodMoon = false;
        }
        if (Main.worldPathName == null)
          return;
        new Stopwatch().Start();
        string str = Main.worldPathName + ".sav";
        using (FileStream fileStream = new FileStream(str, FileMode.Create))
        {
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
          {
            binaryWriter.Write(Main.curRelease);
            binaryWriter.Write(Main.worldName);
            binaryWriter.Write(Main.worldID);
            binaryWriter.Write((int) Main.leftWorld);
            binaryWriter.Write((int) Main.rightWorld);
            binaryWriter.Write((int) Main.topWorld);
            binaryWriter.Write((int) Main.bottomWorld);
            binaryWriter.Write(Main.maxTilesY);
            binaryWriter.Write(Main.maxTilesX);
            binaryWriter.Write(Main.spawnTileX);
            binaryWriter.Write(Main.spawnTileY);
            binaryWriter.Write(Main.worldSurface);
            binaryWriter.Write(Main.rockLayer);
            binaryWriter.Write(WorldGen.tempTime);
            binaryWriter.Write(flag);
            binaryWriter.Write(WorldGen.tempMoonPhase);
            binaryWriter.Write(WorldGen.tempBloodMoon);
            binaryWriter.Write(Main.dungeonX);
            binaryWriter.Write(Main.dungeonY);
            binaryWriter.Write(NPC.downedBoss1);
            binaryWriter.Write(NPC.downedBoss2);
            binaryWriter.Write(NPC.downedBoss3);
            binaryWriter.Write(NPC.savedGoblin);
            binaryWriter.Write(NPC.savedWizard);
            binaryWriter.Write(NPC.savedMech);
            binaryWriter.Write(NPC.downedGoblins);
            binaryWriter.Write(NPC.downedClown);
            binaryWriter.Write(NPC.downedFrost);
            binaryWriter.Write(WorldGen.shadowOrbSmashed);
            binaryWriter.Write(WorldGen.spawnMeteor);
            binaryWriter.Write((byte) WorldGen.shadowOrbCount);
            binaryWriter.Write(WorldGen.altarCount);
            binaryWriter.Write(Main.hardMode);
            binaryWriter.Write(Main.invasionDelay);
            binaryWriter.Write(Main.invasionSize);
            binaryWriter.Write(Main.invasionType);
            binaryWriter.Write(Main.invasionX);
            for (int i = 0; i < Main.maxTilesX; ++i)
            {
              float num1 = (float) i / (float) Main.maxTilesX;
              Main.statusText = Lang.gen[49] + " " + (object) (int) ((double) num1 * 100.0 + 1.0) + "%";
              int num2;
              for (int j = 0; j < Main.maxTilesY; j = j + num2 + 1)
              {
                if (Main.tile[i, j].type == (byte) 127 && Main.tile[i, j].active)
                {
                  WorldGen.KillTile(i, j);
                  WorldGen.KillTile(i, j);
                  if (!Main.tile[i, j].active && Main.netMode != 0)
                    NetMessage.SendData(17, number2: ((float) i), number3: ((float) j));
                }
                Tile tile = (Tile) Main.tile[i, j].Clone();
                binaryWriter.Write(tile.active);
                if (tile.active)
                {
                  binaryWriter.Write(tile.type);
                  if (Main.tileFrameImportant[(int) tile.type])
                  {
                    binaryWriter.Write(tile.frameX);
                    binaryWriter.Write(tile.frameY);
                  }
                }
                if (Main.tile[i, j].wall > (byte) 0)
                {
                  binaryWriter.Write(true);
                  binaryWriter.Write(tile.wall);
                }
                else
                  binaryWriter.Write(false);
                if (tile.liquid > (byte) 0)
                {
                  binaryWriter.Write(true);
                  binaryWriter.Write(tile.liquid);
                  binaryWriter.Write(tile.lava);
                }
                else
                  binaryWriter.Write(false);
                binaryWriter.Write(tile.wire);
                int num3 = 1;
                while (j + num3 < Main.maxTilesY && tile.isTheSameAs(Main.tile[i, j + num3]))
                  ++num3;
                num2 = num3 - 1;
                binaryWriter.Write((short) num2);
              }
            }
            for (int index1 = 0; index1 < 1000; ++index1)
            {
              if (Main.chest[index1] == null)
              {
                binaryWriter.Write(false);
              }
              else
              {
                Chest chest = (Chest) Main.chest[index1].Clone();
                binaryWriter.Write(true);
                binaryWriter.Write(chest.x);
                binaryWriter.Write(chest.y);
                for (int index2 = 0; index2 < Chest.maxItems; ++index2)
                {
                  if (chest.item[index2].type == 0)
                    chest.item[index2].stack = 0;
                  binaryWriter.Write((byte) chest.item[index2].stack);
                  if (chest.item[index2].stack > 0)
                  {
                    binaryWriter.Write(chest.item[index2].netID);
                    binaryWriter.Write(chest.item[index2].prefix);
                  }
                }
              }
            }
            for (int index = 0; index < 1000; ++index)
            {
              if (Main.sign[index] == null || Main.sign[index].text == null)
              {
                binaryWriter.Write(false);
              }
              else
              {
                Sign sign = (Sign) Main.sign[index].Clone();
                binaryWriter.Write(true);
                binaryWriter.Write(sign.text);
                binaryWriter.Write(sign.x);
                binaryWriter.Write(sign.y);
              }
            }
            for (int index = 0; index < 200; ++index)
            {
              NPC npc = (NPC) Main.npc[index].Clone();
              if (npc.active && npc.townNPC)
              {
                binaryWriter.Write(true);
                binaryWriter.Write(npc.name);
                binaryWriter.Write(npc.position.X);
                binaryWriter.Write(npc.position.Y);
                binaryWriter.Write(npc.homeless);
                binaryWriter.Write(npc.homeTileX);
                binaryWriter.Write(npc.homeTileY);
              }
            }
            binaryWriter.Write(false);
            binaryWriter.Write(Main.chrName[17]);
            binaryWriter.Write(Main.chrName[18]);
            binaryWriter.Write(Main.chrName[19]);
            binaryWriter.Write(Main.chrName[20]);
            binaryWriter.Write(Main.chrName[22]);
            binaryWriter.Write(Main.chrName[54]);
            binaryWriter.Write(Main.chrName[38]);
            binaryWriter.Write(Main.chrName[107]);
            binaryWriter.Write(Main.chrName[108]);
            binaryWriter.Write(Main.chrName[124]);
            binaryWriter.Write(true);
            binaryWriter.Write(Main.worldName);
            binaryWriter.Write(Main.worldID);
            binaryWriter.Close();
            fileStream.Close();
            if (File.Exists(Main.worldPathName))
            {
              Main.statusText = Lang.gen[50];
              string destFileName = Main.worldPathName + ".bak";
              File.Copy(Main.worldPathName, destFileName, true);
            }
            File.Copy(str, Main.worldPathName, true);
            File.Delete(str);
          }
        }
        WorldGen.saveLock = false;
      }
    }

    public static void loadWorld()
    {
      Main.checkXMas();
      if (!File.Exists(Main.worldPathName) && Main.autoGen)
      {
        for (int index = Main.worldPathName.Length - 1; index >= 0; --index)
        {
          if (Main.worldPathName.Substring(index, 1) == string.Concat((object) Path.DirectorySeparatorChar))
          {
            Directory.CreateDirectory(Main.worldPathName.Substring(0, index));
            break;
          }
        }
        WorldGen.clearWorld();
        WorldGen.generateWorld();
        WorldGen.saveWorld();
      }
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
      using (FileStream fileStream = new FileStream(Main.worldPathName, FileMode.Open))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
        {
          try
          {
            WorldGen.loadFailed = false;
            WorldGen.loadSuccess = false;
            int release = binaryReader.ReadInt32();
            if (release > Main.curRelease)
            {
              WorldGen.loadFailed = true;
              WorldGen.loadSuccess = false;
              try
              {
                binaryReader.Close();
                fileStream.Close();
              }
              catch
              {
              }
            }
            else
            {
              Main.worldName = binaryReader.ReadString();
              Main.worldID = binaryReader.ReadInt32();
              Main.leftWorld = (float) binaryReader.ReadInt32();
              Main.rightWorld = (float) binaryReader.ReadInt32();
              Main.topWorld = (float) binaryReader.ReadInt32();
              Main.bottomWorld = (float) binaryReader.ReadInt32();
              Main.maxTilesY = binaryReader.ReadInt32();
              Main.maxTilesX = binaryReader.ReadInt32();
              WorldGen.clearWorld();
              Main.spawnTileX = binaryReader.ReadInt32();
              Main.spawnTileY = binaryReader.ReadInt32();
              Main.worldSurface = binaryReader.ReadDouble();
              Main.rockLayer = binaryReader.ReadDouble();
              WorldGen.tempTime = binaryReader.ReadDouble();
              WorldGen.tempDayTime = binaryReader.ReadBoolean();
              WorldGen.tempMoonPhase = binaryReader.ReadInt32();
              WorldGen.tempBloodMoon = binaryReader.ReadBoolean();
              Main.dungeonX = binaryReader.ReadInt32();
              Main.dungeonY = binaryReader.ReadInt32();
              NPC.downedBoss1 = binaryReader.ReadBoolean();
              NPC.downedBoss2 = binaryReader.ReadBoolean();
              NPC.downedBoss3 = binaryReader.ReadBoolean();
              if (release >= 29)
              {
                NPC.savedGoblin = binaryReader.ReadBoolean();
                NPC.savedWizard = binaryReader.ReadBoolean();
                if (release >= 34)
                  NPC.savedMech = binaryReader.ReadBoolean();
                NPC.downedGoblins = binaryReader.ReadBoolean();
              }
              if (release >= 32)
                NPC.downedClown = binaryReader.ReadBoolean();
              if (release >= 37)
                NPC.downedFrost = binaryReader.ReadBoolean();
              WorldGen.shadowOrbSmashed = binaryReader.ReadBoolean();
              WorldGen.spawnMeteor = binaryReader.ReadBoolean();
              WorldGen.shadowOrbCount = (int) binaryReader.ReadByte();
              if (release >= 23)
              {
                WorldGen.altarCount = binaryReader.ReadInt32();
                Main.hardMode = binaryReader.ReadBoolean();
              }
              Main.invasionDelay = binaryReader.ReadInt32();
              Main.invasionSize = binaryReader.ReadInt32();
              Main.invasionType = binaryReader.ReadInt32();
              Main.invasionX = binaryReader.ReadDouble();
              for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
              {
                float num1 = (float) index1 / (float) Main.maxTilesX;
                Main.statusText = Lang.gen[51] + " " + (object) (int) ((double) num1 * 100.0 + 1.0) + "%";
                for (int index2 = 0; index2 < Main.maxTilesY; ++index2)
                {
                  Main.tile[index1, index2].active = binaryReader.ReadBoolean();
                  if (Main.tile[index1, index2].active)
                  {
                    Main.tile[index1, index2].type = binaryReader.ReadByte();
                    if (Main.tile[index1, index2].type == (byte) 127)
                      Main.tile[index1, index2].active = false;
                    if (Main.tileFrameImportant[(int) Main.tile[index1, index2].type])
                    {
                      if (release < 28 && Main.tile[index1, index2].type == (byte) 4)
                      {
                        Main.tile[index1, index2].frameX = (short) 0;
                        Main.tile[index1, index2].frameY = (short) 0;
                      }
                      else
                      {
                        Main.tile[index1, index2].frameX = binaryReader.ReadInt16();
                        Main.tile[index1, index2].frameY = binaryReader.ReadInt16();
                        if (Main.tile[index1, index2].type == (byte) 144)
                          Main.tile[index1, index2].frameY = (short) 0;
                      }
                    }
                    else
                    {
                      Main.tile[index1, index2].frameX = (short) -1;
                      Main.tile[index1, index2].frameY = (short) -1;
                    }
                  }
                  if (release <= 25)
                    binaryReader.ReadBoolean();
                  if (binaryReader.ReadBoolean())
                    Main.tile[index1, index2].wall = binaryReader.ReadByte();
                  if (binaryReader.ReadBoolean())
                  {
                    Main.tile[index1, index2].liquid = binaryReader.ReadByte();
                    Main.tile[index1, index2].lava = binaryReader.ReadBoolean();
                  }
                  if (release >= 33)
                    Main.tile[index1, index2].wire = binaryReader.ReadBoolean();
                  if (release >= 25)
                  {
                    int num2 = (int) binaryReader.ReadInt16();
                    if (num2 > 0)
                    {
                      for (int index3 = index2 + 1; index3 < index2 + num2 + 1; ++index3)
                      {
                        Main.tile[index1, index3].active = Main.tile[index1, index2].active;
                        Main.tile[index1, index3].type = Main.tile[index1, index2].type;
                        Main.tile[index1, index3].wall = Main.tile[index1, index2].wall;
                        Main.tile[index1, index3].frameX = Main.tile[index1, index2].frameX;
                        Main.tile[index1, index3].frameY = Main.tile[index1, index2].frameY;
                        Main.tile[index1, index3].liquid = Main.tile[index1, index2].liquid;
                        Main.tile[index1, index3].lava = Main.tile[index1, index2].lava;
                        Main.tile[index1, index3].wire = Main.tile[index1, index2].wire;
                      }
                      index2 += num2;
                    }
                  }
                }
              }
              for (int index4 = 0; index4 < 1000; ++index4)
              {
                if (binaryReader.ReadBoolean())
                {
                  Main.chest[index4] = new Chest();
                  Main.chest[index4].x = binaryReader.ReadInt32();
                  Main.chest[index4].y = binaryReader.ReadInt32();
                  for (int index5 = 0; index5 < Chest.maxItems; ++index5)
                  {
                    Main.chest[index4].item[index5] = new Item();
                    byte num = binaryReader.ReadByte();
                    if (num > (byte) 0)
                    {
                      if (release >= 38)
                      {
                        Main.chest[index4].item[index5].netDefaults(binaryReader.ReadInt32());
                      }
                      else
                      {
                        string ItemName = Item.VersionName(binaryReader.ReadString(), release);
                        Main.chest[index4].item[index5].SetDefaults(ItemName);
                      }
                      Main.chest[index4].item[index5].stack = (int) num;
                      if (release >= 36)
                        Main.chest[index4].item[index5].Prefix((int) binaryReader.ReadByte());
                    }
                  }
                }
              }
              for (int index6 = 0; index6 < 1000; ++index6)
              {
                if (binaryReader.ReadBoolean())
                {
                  string str = binaryReader.ReadString();
                  int index7 = binaryReader.ReadInt32();
                  int index8 = binaryReader.ReadInt32();
                  if (Main.tile[index7, index8].active && (Main.tile[index7, index8].type == (byte) 55 || Main.tile[index7, index8].type == (byte) 85))
                  {
                    Main.sign[index6] = new Sign();
                    Main.sign[index6].x = index7;
                    Main.sign[index6].y = index8;
                    Main.sign[index6].text = str;
                  }
                }
              }
              bool flag1 = binaryReader.ReadBoolean();
              int index = 0;
              while (flag1)
              {
                Main.npc[index].SetDefaults(binaryReader.ReadString());
                Main.npc[index].position.X = binaryReader.ReadSingle();
                Main.npc[index].position.Y = binaryReader.ReadSingle();
                Main.npc[index].homeless = binaryReader.ReadBoolean();
                Main.npc[index].homeTileX = binaryReader.ReadInt32();
                Main.npc[index].homeTileY = binaryReader.ReadInt32();
                flag1 = binaryReader.ReadBoolean();
                ++index;
              }
              if (release >= 31)
              {
                Main.chrName[17] = binaryReader.ReadString();
                Main.chrName[18] = binaryReader.ReadString();
                Main.chrName[19] = binaryReader.ReadString();
                Main.chrName[20] = binaryReader.ReadString();
                Main.chrName[22] = binaryReader.ReadString();
                Main.chrName[54] = binaryReader.ReadString();
                Main.chrName[38] = binaryReader.ReadString();
                Main.chrName[107] = binaryReader.ReadString();
                Main.chrName[108] = binaryReader.ReadString();
                if (release >= 35)
                  Main.chrName[124] = binaryReader.ReadString();
              }
              if (release >= 7)
              {
                bool flag2 = binaryReader.ReadBoolean();
                string str = binaryReader.ReadString();
                int num = binaryReader.ReadInt32();
                if (flag2 && str == Main.worldName && num == Main.worldID)
                {
                  WorldGen.loadSuccess = true;
                }
                else
                {
                  WorldGen.loadSuccess = false;
                  WorldGen.loadFailed = true;
                  binaryReader.Close();
                  fileStream.Close();
                  return;
                }
              }
              else
                WorldGen.loadSuccess = true;
              binaryReader.Close();
              fileStream.Close();
              if (WorldGen.loadFailed || !WorldGen.loadSuccess)
                return;
              WorldGen.gen = true;
              for (int X = 0; X < Main.maxTilesX; ++X)
              {
                float num = (float) X / (float) Main.maxTilesX;
                Main.statusText = Lang.gen[52] + " " + (object) (int) ((double) num * 100.0 + 1.0) + "%";
                WorldGen.CountTiles(X);
              }
              WorldGen.waterLine = Main.maxTilesY;
              NPC.setNames();
              Liquid.QuickWater(2);
              WorldGen.WaterCheck();
              int num3 = 0;
              Liquid.quickSettle = true;
              int num4 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
              float num5 = 0.0f;
              while (Liquid.numLiquid > 0 && num3 < 100000)
              {
                ++num3;
                float num6 = (float) (num4 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float) num4;
                if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num4)
                  num4 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
                if ((double) num6 > (double) num5)
                  num5 = num6;
                else
                  num6 = num5;
                Main.statusText = Lang.gen[27] + " " + (object) (int) ((double) num6 * 100.0 / 2.0 + 50.0) + "%";
                Liquid.UpdateLiquid();
              }
              Liquid.quickSettle = false;
              WorldGen.WaterCheck();
              WorldGen.gen = false;
            }
          }
          catch
          {
            WorldGen.loadFailed = true;
            WorldGen.loadSuccess = false;
            try
            {
              binaryReader.Close();
              fileStream.Close();
            }
            catch
            {
            }
          }
        }
      }
    }

    private static void resetGen()
    {
      WorldGen.mudWall = false;
      WorldGen.hellChest = 0;
      WorldGen.JungleX = 0;
      WorldGen.numMCaves = 0;
      WorldGen.numIslandHouses = 0;
      WorldGen.houseCount = 0;
      WorldGen.dEnteranceX = 0;
      WorldGen.numDRooms = 0;
      WorldGen.numDDoors = 0;
      WorldGen.numDPlats = 0;
      WorldGen.numJChests = 0;
    }

    public static bool placeTrap(int x2, int y2, int type = -1)
    {
      int i1 = x2;
      int j1 = y2;
      while (!WorldGen.SolidTile(i1, j1))
      {
        ++j1;
        if (j1 >= Main.maxTilesY - 300)
          return false;
      }
      int j2 = j1 - 1;
      if (Main.tile[i1, j2].liquid > (byte) 0 && Main.tile[i1, j2].lava)
        return false;
      if (type == -1 && Main.rand.Next(20) == 0)
        type = 2;
      else if (type == -1)
        type = Main.rand.Next(2);
      if (Main.tile[i1, j2].active || Main.tile[i1 - 1, j2].active || Main.tile[i1 + 1, j2].active || Main.tile[i1, j2 - 1].active || Main.tile[i1 - 1, j2 - 1].active || Main.tile[i1 + 1, j2 - 1].active || Main.tile[i1, j2 - 2].active || Main.tile[i1 - 1, j2 - 2].active || Main.tile[i1 + 1, j2 - 2].active || Main.tile[i1, j2 + 1].type == (byte) 48)
        return false;
      switch (type)
      {
        case 0:
          int i2 = i1;
          int j3 = j2 - WorldGen.genRand.Next(3);
          while (!WorldGen.SolidTile(i2, j3))
            --i2;
          int i3 = i2;
          int i4 = i1;
          while (!WorldGen.SolidTile(i4, j3))
            ++i4;
          int i5 = i4;
          int num1 = i1 - i3;
          int num2 = i5 - i1;
          bool flag1 = false;
          bool flag2 = false;
          if (num1 > 5 && num1 < 50)
            flag1 = true;
          if (num2 > 5 && num2 < 50)
            flag2 = true;
          if (flag1 && !WorldGen.SolidTile(i3, j3 + 1))
            flag1 = false;
          if (flag2 && !WorldGen.SolidTile(i5, j3 + 1))
            flag2 = false;
          if (flag1 && (Main.tile[i3, j3].type == (byte) 10 || Main.tile[i3, j3].type == (byte) 48 || Main.tile[i3, j3 + 1].type == (byte) 10 || Main.tile[i3, j3 + 1].type == (byte) 48))
            flag1 = false;
          if (flag2 && (Main.tile[i5, j3].type == (byte) 10 || Main.tile[i5, j3].type == (byte) 48 || Main.tile[i5, j3 + 1].type == (byte) 10 || Main.tile[i5, j3 + 1].type == (byte) 48))
            flag2 = false;
          int style;
          int i6;
          if (flag1 && flag2)
          {
            style = 1;
            i6 = i3;
            if (WorldGen.genRand.Next(2) == 0)
            {
              i6 = i5;
              style = -1;
            }
          }
          else if (flag2)
          {
            i6 = i5;
            style = -1;
          }
          else
          {
            if (!flag1)
              return false;
            i6 = i3;
            style = 1;
          }
          if (Main.tile[i1, j2].wall > (byte) 0)
            WorldGen.PlaceTile(i1, j2, 135, true, true, style: 2);
          else
            WorldGen.PlaceTile(i1, j2, 135, true, true, style: WorldGen.genRand.Next(2, 4));
          WorldGen.KillTile(i6, j3);
          WorldGen.PlaceTile(i6, j3, 137, true, true, style: style);
          int index1 = i1;
          int index2 = j2;
          while (index1 != i6 || index2 != j3)
          {
            Main.tile[index1, index2].wire = true;
            if (index1 > i6)
              --index1;
            if (index1 < i6)
              ++index1;
            Main.tile[index1, index2].wire = true;
            if (index2 > j3)
              --index2;
            if (index2 < j3)
              ++index2;
            Main.tile[index1, index2].wire = true;
          }
          return true;
        case 1:
          int num3 = i1;
          int num4 = j2 - 8;
          int i7 = num3 + WorldGen.genRand.Next(-1, 2);
          bool flag3 = true;
          while (flag3)
          {
            bool flag4 = true;
            int num5 = 0;
            for (int i8 = i7 - 2; i8 <= i7 + 3; ++i8)
            {
              for (int j4 = num4; j4 <= num4 + 3; ++j4)
              {
                if (!WorldGen.SolidTile(i8, j4))
                  flag4 = false;
                if (Main.tile[i8, j4].active && (Main.tile[i8, j4].type == (byte) 0 || Main.tile[i8, j4].type == (byte) 1 || Main.tile[i8, j4].type == (byte) 59))
                  ++num5;
              }
            }
            --num4;
            if ((double) num4 < Main.worldSurface)
              return false;
            if (flag4 && num5 > 2)
              flag3 = false;
          }
          if (j2 - num4 <= 5 || j2 - num4 >= 40)
            return false;
          for (int i9 = i7; i9 <= i7 + 1; ++i9)
          {
            for (int j5 = num4; j5 <= j2; ++j5)
            {
              if (WorldGen.SolidTile(i9, j5))
                WorldGen.KillTile(i9, j5);
            }
          }
          for (int i10 = i7 - 2; i10 <= i7 + 3; ++i10)
          {
            for (int j6 = num4 - 2; j6 <= num4 + 3; ++j6)
            {
              if (WorldGen.SolidTile(i10, j6))
                Main.tile[i10, j6].type = (byte) 1;
            }
          }
          WorldGen.PlaceTile(i1, j2, 135, true, true, style: WorldGen.genRand.Next(2, 4));
          WorldGen.PlaceTile(i7, num4 + 2, 130, true);
          WorldGen.PlaceTile(i7 + 1, num4 + 2, 130, true);
          WorldGen.PlaceTile(i7 + 1, num4 + 1, 138, true);
          int index3 = num4 + 2;
          Main.tile[i7, index3].wire = true;
          Main.tile[i7 + 1, index3].wire = true;
          int j7 = index3 + 1;
          WorldGen.PlaceTile(i7, j7, 130, true);
          WorldGen.PlaceTile(i7 + 1, j7, 130, true);
          Main.tile[i7, j7].wire = true;
          Main.tile[i7 + 1, j7].wire = true;
          WorldGen.PlaceTile(i7, j7 + 1, 130, true);
          WorldGen.PlaceTile(i7 + 1, j7 + 1, 130, true);
          Main.tile[i7, j7 + 1].wire = true;
          Main.tile[i7 + 1, j7 + 1].wire = true;
          int index4 = i1;
          int index5 = j2;
          while (index4 != i7 || index5 != j7)
          {
            Main.tile[index4, index5].wire = true;
            if (index4 > i7)
              --index4;
            if (index4 < i7)
              ++index4;
            Main.tile[index4, index5].wire = true;
            if (index5 > j7)
              --index5;
            if (index5 < j7)
              ++index5;
            Main.tile[index4, index5].wire = true;
          }
          return true;
        case 2:
          int num6 = Main.rand.Next(4, 7);
          int i11 = i1 + Main.rand.Next(-1, 2);
          int j8 = j2;
          for (int index6 = 0; index6 < num6; ++index6)
          {
            ++j8;
            if (!WorldGen.SolidTile(i11, j8))
              return false;
          }
          for (int i12 = i11 - 2; i12 <= i11 + 2; ++i12)
          {
            for (int j9 = j8 - 2; j9 <= j8 + 2; ++j9)
            {
              if (!WorldGen.SolidTile(i12, j9))
                return false;
            }
          }
          WorldGen.KillTile(i11, j8);
          Main.tile[i11, j8].active = true;
          Main.tile[i11, j8].type = (byte) 141;
          Main.tile[i11, j8].frameX = (short) 0;
          Main.tile[i11, j8].frameY = (short) (18 * Main.rand.Next(2));
          WorldGen.PlaceTile(i1, j2, 135, true, true, style: WorldGen.genRand.Next(2, 4));
          int index7 = i1;
          int index8 = j2;
          while (index7 != i11 || index8 != j8)
          {
            Main.tile[index7, index8].wire = true;
            if (index7 > i11)
              --index7;
            if (index7 < i11)
              ++index7;
            Main.tile[index7, index8].wire = true;
            if (index8 > j8)
              --index8;
            if (index8 < j8)
              ++index8;
            Main.tile[index7, index8].wire = true;
          }
          break;
      }
      return false;
    }

    public static void generateWorld(int seed = -1)
    {
      Main.checkXMas();
      NPC.clrNames();
      NPC.setNames();
      WorldGen.gen = true;
      WorldGen.resetGen();
      WorldGen.genRand = seed <= 0 ? new Random((int) DateTime.Now.Ticks) : new Random(seed);
      Main.worldID = WorldGen.genRand.Next(int.MaxValue);
      int num1 = 0;
      int num2 = 0;
      double num3 = (double) Main.maxTilesY * 0.3 * ((double) WorldGen.genRand.Next(90, 110) * 0.005);
      double num4 = (num3 + (double) Main.maxTilesY * 0.2) * ((double) WorldGen.genRand.Next(90, 110) * 0.01);
      double num5 = num3;
      double num6 = num3;
      double num7 = num4;
      double num8 = num4;
      int num9 = WorldGen.genRand.Next(2) != 0 ? 1 : -1;
      for (int index1 = 0; index1 < Main.maxTilesX; ++index1)
      {
        float num10 = (float) index1 / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[0] + " " + (object) (int) ((double) num10 * 100.0 + 1.0) + "%";
        if (num3 < num5)
          num5 = num3;
        if (num3 > num6)
          num6 = num3;
        if (num4 < num7)
          num7 = num4;
        if (num4 > num8)
          num8 = num4;
        if (num2 <= 0)
        {
          num1 = WorldGen.genRand.Next(0, 5);
          num2 = WorldGen.genRand.Next(5, 40);
          if (num1 == 0)
            num2 *= (int) ((double) WorldGen.genRand.Next(5, 30) * 0.2);
        }
        --num2;
        if (num1 == 0)
        {
          while (WorldGen.genRand.Next(0, 7) == 0)
            num3 += (double) WorldGen.genRand.Next(-1, 2);
        }
        else if (num1 == 1)
        {
          while (WorldGen.genRand.Next(0, 4) == 0)
            --num3;
          while (WorldGen.genRand.Next(0, 10) == 0)
            ++num3;
        }
        else if (num1 == 2)
        {
          while (WorldGen.genRand.Next(0, 4) == 0)
            ++num3;
          while (WorldGen.genRand.Next(0, 10) == 0)
            --num3;
        }
        else if (num1 == 3)
        {
          while (WorldGen.genRand.Next(0, 2) == 0)
            --num3;
          while (WorldGen.genRand.Next(0, 6) == 0)
            ++num3;
        }
        else if (num1 == 4)
        {
          while (WorldGen.genRand.Next(0, 2) == 0)
            ++num3;
          while (WorldGen.genRand.Next(0, 5) == 0)
            --num3;
        }
        if (num3 < (double) Main.maxTilesY * 0.17)
        {
          num3 = (double) Main.maxTilesY * 0.17;
          num2 = 0;
        }
        else if (num3 > (double) Main.maxTilesY * 0.3)
        {
          num3 = (double) Main.maxTilesY * 0.3;
          num2 = 0;
        }
        if ((index1 < 275 || index1 > Main.maxTilesX - 275) && num3 > (double) Main.maxTilesY * 0.25)
        {
          num3 = (double) Main.maxTilesY * 0.25;
          num2 = 1;
        }
        while (WorldGen.genRand.Next(0, 3) == 0)
          num4 += (double) WorldGen.genRand.Next(-2, 3);
        if (num4 < num3 + (double) Main.maxTilesY * 0.05)
          ++num4;
        if (num4 > num3 + (double) Main.maxTilesY * 0.35)
          --num4;
        for (int index2 = 0; (double) index2 < num3; ++index2)
        {
          Main.tile[index1, index2].active = false;
          Main.tile[index1, index2].frameX = (short) -1;
          Main.tile[index1, index2].frameY = (short) -1;
        }
        for (int index3 = (int) num3; index3 < Main.maxTilesY; ++index3)
        {
          if ((double) index3 < num4)
          {
            Main.tile[index1, index3].active = true;
            Main.tile[index1, index3].type = (byte) 0;
            Main.tile[index1, index3].frameX = (short) -1;
            Main.tile[index1, index3].frameY = (short) -1;
          }
          else
          {
            Main.tile[index1, index3].active = true;
            Main.tile[index1, index3].type = (byte) 1;
            Main.tile[index1, index3].frameX = (short) -1;
            Main.tile[index1, index3].frameY = (short) -1;
          }
        }
      }
      Main.worldSurface = num6 + 25.0;
      Main.rockLayer = num8;
      double num11 = (double) ((int) ((Main.rockLayer - Main.worldSurface) / 6.0) * 6);
      Main.rockLayer = Main.worldSurface + num11;
      WorldGen.waterLine = (int) (Main.rockLayer + (double) Main.maxTilesY) / 2;
      WorldGen.waterLine += WorldGen.genRand.Next(-100, 20);
      WorldGen.lavaLine = WorldGen.waterLine + WorldGen.genRand.Next(50, 80);
      int num12 = 0;
      for (int index4 = 0; index4 < (int) ((double) Main.maxTilesX * 0.0015); ++index4)
      {
        int[] numArray1 = new int[10];
        int[] numArray2 = new int[10];
        int index5 = WorldGen.genRand.Next(450, Main.maxTilesX - 450);
        int index6 = 0;
        for (int index7 = 0; index7 < 10; ++index7)
        {
          while (!Main.tile[index5, index6].active)
            ++index6;
          numArray1[index7] = index5;
          numArray2[index7] = index6 - WorldGen.genRand.Next(11, 16);
          index5 += WorldGen.genRand.Next(5, 11);
        }
        for (int index8 = 0; index8 < 10; ++index8)
        {
          WorldGen.TileRunner(numArray1[index8], numArray2[index8], (double) WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(6, 9), 0, true, -2f, -0.3f);
          WorldGen.TileRunner(numArray1[index8], numArray2[index8], (double) WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(6, 9), 0, true, 2f, -0.3f);
        }
      }
      Main.statusText = Lang.gen[1];
      int num13 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.0008), (int) ((double) Main.maxTilesX * (1.0 / 400.0))) + 2;
      for (int index9 = 0; index9 < num13; ++index9)
      {
        int num14 = WorldGen.genRand.Next(Main.maxTilesX);
        while ((double) num14 > (double) Main.maxTilesX * 0.400000005960464 && (double) num14 < (double) Main.maxTilesX * 0.600000023841858)
          num14 = WorldGen.genRand.Next(Main.maxTilesX);
        int num15 = WorldGen.genRand.Next(35, 90);
        if (index9 == 1)
        {
          float num16 = (float) (Main.maxTilesX / 4200);
          num15 += (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num16);
        }
        if (WorldGen.genRand.Next(3) == 0)
          num15 *= 2;
        if (index9 == 1)
          num15 *= 2;
        int num17 = num14 - num15;
        int num18 = WorldGen.genRand.Next(35, 90);
        if (WorldGen.genRand.Next(3) == 0)
          num18 *= 2;
        if (index9 == 1)
          num18 *= 2;
        int num19 = num14 + num18;
        if (num17 < 0)
          num17 = 0;
        if (num19 > Main.maxTilesX)
          num19 = Main.maxTilesX;
        switch (index9)
        {
          case 0:
            num17 = 0;
            num19 = WorldGen.genRand.Next(260, 300);
            if (num9 == 1)
            {
              num19 += 40;
              break;
            }
            break;
          case 2:
            num17 = Main.maxTilesX - WorldGen.genRand.Next(260, 300);
            num19 = Main.maxTilesX;
            if (num9 == -1)
            {
              num17 -= 40;
              break;
            }
            break;
        }
        int num20 = WorldGen.genRand.Next(50, 100);
        for (int index10 = num17; index10 < num19; ++index10)
        {
          if (WorldGen.genRand.Next(2) == 0)
          {
            num20 += WorldGen.genRand.Next(-1, 2);
            if (num20 < 50)
              num20 = 50;
            if (num20 > 100)
              num20 = 100;
          }
          for (int index11 = 0; (double) index11 < Main.worldSurface; ++index11)
          {
            if (Main.tile[index10, index11].active)
            {
              int num21 = num20;
              if (index10 - num17 < num21)
                num21 = index10 - num17;
              if (num19 - index10 < num21)
                num21 = num19 - index10;
              int num22 = num21 + WorldGen.genRand.Next(5);
              for (int index12 = index11; index12 < index11 + num22; ++index12)
              {
                if (index10 > num17 + WorldGen.genRand.Next(5) && index10 < num19 - WorldGen.genRand.Next(5))
                  Main.tile[index10, index12].type = (byte) 53;
              }
              break;
            }
          }
        }
      }
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 8E-06); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) Main.worldSurface, (int) Main.rockLayer), (double) WorldGen.genRand.Next(15, 70), WorldGen.genRand.Next(20, 130), 53);
      WorldGen.numMCaves = 0;
      Main.statusText = Lang.gen[2];
      for (int index13 = 0; index13 < (int) ((double) Main.maxTilesX * 0.0008); ++index13)
      {
        int num23 = 0;
        bool flag1 = false;
        bool flag2 = false;
        int i = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.25), (int) ((double) Main.maxTilesX * 0.75));
        while (!flag2)
        {
          flag2 = true;
          while (i > Main.maxTilesX / 2 - 100 && i < Main.maxTilesX / 2 + 100)
            i = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.25), (int) ((double) Main.maxTilesX * 0.75));
          for (int index14 = 0; index14 < WorldGen.numMCaves; ++index14)
          {
            if (i > WorldGen.mCaveX[index14] - 50 && i < WorldGen.mCaveX[index14] + 50)
            {
              ++num23;
              flag2 = false;
              break;
            }
          }
          if (num23 >= 200)
          {
            flag1 = true;
            break;
          }
        }
        if (!flag1)
        {
          for (int j = 0; (double) j < Main.worldSurface; ++j)
          {
            if (Main.tile[i, j].active)
            {
              WorldGen.Mountinater(i, j);
              WorldGen.mCaveX[WorldGen.numMCaves] = i;
              WorldGen.mCaveY[WorldGen.numMCaves] = j;
              ++WorldGen.numMCaves;
              break;
            }
          }
        }
      }
      bool flag3 = false;
      if (Main.xMas)
        flag3 = true;
      else if (WorldGen.genRand.Next(3) == 0)
        flag3 = true;
      if (flag3)
      {
        Main.statusText = Lang.gen[56];
        int num24 = WorldGen.genRand.Next(Main.maxTilesX);
        while ((double) num24 < (double) Main.maxTilesX * 0.349999994039536 || (double) num24 > (double) Main.maxTilesX * 0.649999976158142)
          num24 = WorldGen.genRand.Next(Main.maxTilesX);
        int num25 = WorldGen.genRand.Next(35, 90);
        float num26 = (float) (Main.maxTilesX / 4200);
        int num27 = num25 + (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num26) + (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num26);
        int num28 = num24 - num27;
        int num29 = WorldGen.genRand.Next(35, 90) + (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num26) + (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num26);
        int num30 = num24 + num29;
        if (num28 < 0)
          num28 = 0;
        if (num30 > Main.maxTilesX)
          num30 = Main.maxTilesX;
        int num31 = WorldGen.genRand.Next(50, 100);
        for (int index15 = num28; index15 < num30; ++index15)
        {
          if (WorldGen.genRand.Next(2) == 0)
          {
            num31 += WorldGen.genRand.Next(-1, 2);
            if (num31 < 50)
              num31 = 50;
            if (num31 > 100)
              num31 = 100;
          }
          for (int index16 = 0; (double) index16 < Main.worldSurface; ++index16)
          {
            if (Main.tile[index15, index16].active)
            {
              int num32 = num31;
              if (index15 - num28 < num32)
                num32 = index15 - num28;
              if (num30 - index15 < num32)
                num32 = num30 - index15;
              int num33 = num32 + WorldGen.genRand.Next(5);
              for (int index17 = index16; index17 < index16 + num33; ++index17)
              {
                if (index15 > num28 + WorldGen.genRand.Next(5) && index15 < num30 - WorldGen.genRand.Next(5))
                  Main.tile[index15, index17].type = (byte) 147;
              }
              break;
            }
          }
        }
      }
      for (int index18 = 1; index18 < Main.maxTilesX - 1; ++index18)
      {
        float num34 = (float) index18 / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[3] + " " + (object) (int) ((double) num34 * 100.0 + 1.0) + "%";
        bool flag4 = false;
        num12 += WorldGen.genRand.Next(-1, 2);
        if (num12 < 0)
          num12 = 0;
        if (num12 > 10)
          num12 = 10;
        for (int index19 = 0; (double) index19 < Main.worldSurface + 10.0 && (double) index19 <= Main.worldSurface + (double) num12; ++index19)
        {
          if (flag4)
            Main.tile[index18, index19].wall = (byte) 2;
          if (Main.tile[index18, index19].active && Main.tile[index18 - 1, index19].active && Main.tile[index18 + 1, index19].active && Main.tile[index18, index19 + 1].active && Main.tile[index18 - 1, index19 + 1].active && Main.tile[index18 + 1, index19 + 1].active)
            flag4 = true;
        }
      }
      Main.statusText = Lang.gen[4];
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0002); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int) num5 + 1), (double) WorldGen.genRand.Next(4, 15), WorldGen.genRand.Next(5, 40), 1);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0002); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6 + 1), (double) WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(5, 30), 1);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0045); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8 + 1), (double) WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(2, 23), 1);
      Main.statusText = Lang.gen[5];
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.005); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 40), 0);
      Main.statusText = Lang.gen[6];
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 2E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int) num5), (double) WorldGen.genRand.Next(4, 14), WorldGen.genRand.Next(10, 50), 40);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 5E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6 + 1), (double) WorldGen.genRand.Next(8, 14), WorldGen.genRand.Next(15, 45), 40);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 2E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8 + 1), (double) WorldGen.genRand.Next(8, 15), WorldGen.genRand.Next(5, 50), 40);
      for (int index20 = 5; index20 < Main.maxTilesX - 5; ++index20)
      {
        for (int index21 = 1; (double) index21 < Main.worldSurface - 1.0; ++index21)
        {
          if (Main.tile[index20, index21].active)
          {
            for (int index22 = index21; index22 < index21 + 5; ++index22)
            {
              if (Main.tile[index20, index22].type == (byte) 40)
                Main.tile[index20, index22].type = (byte) 0;
            }
            break;
          }
        }
      }
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0015); ++index)
      {
        float num35 = (float) index / ((float) (Main.maxTilesX * Main.maxTilesY) * 0.0015f);
        Main.statusText = Lang.gen[7] + " " + (object) (int) ((double) num35 * 100.0 + 1.0) + "%";
        int type = -1;
        if (WorldGen.genRand.Next(5) == 0)
          type = -2;
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, Main.maxTilesY), (double) WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 20), type);
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, Main.maxTilesY), (double) WorldGen.genRand.Next(8, 15), WorldGen.genRand.Next(7, 30), type);
      }
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 3E-05); ++index)
      {
        float num36 = (float) index / ((float) (Main.maxTilesX * Main.maxTilesY) * 3E-05f);
        Main.statusText = Lang.gen[8] + " " + (object) (int) ((double) num36 * 100.0 + 1.0) + "%";
        if (num8 <= (double) Main.maxTilesY)
        {
          int type = -1;
          if (WorldGen.genRand.Next(6) == 0)
            type = -2;
          WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num8 + 1), (double) WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(30, 200), type);
        }
      }
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.00013); ++index)
      {
        float num37 = (float) index / ((float) (Main.maxTilesX * Main.maxTilesY) * 0.00013f);
        Main.statusText = Lang.gen[9] + " " + (object) (int) ((double) num37 * 100.0 + 1.0) + "%";
        if (num8 <= (double) Main.maxTilesY)
        {
          int type = -1;
          if (WorldGen.genRand.Next(10) == 0)
            type = -2;
          WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num8, Main.maxTilesY), (double) WorldGen.genRand.Next(6, 20), WorldGen.genRand.Next(50, 300), type);
        }
      }
      Main.statusText = Lang.gen[10];
      for (int index = 0; index < (int) ((double) Main.maxTilesX * (1.0 / 400.0)); ++index)
      {
        int i = WorldGen.genRand.Next(0, Main.maxTilesX);
        for (int j = 0; (double) j < num6; ++j)
        {
          if (Main.tile[i, j].active)
          {
            WorldGen.TileRunner(i, j, (double) WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(5, 50), -1, speedX: ((float) WorldGen.genRand.Next(-10, 11) * 0.1f), speedY: 1f);
            break;
          }
        }
      }
      for (int index = 0; index < (int) ((double) Main.maxTilesX * 0.0007); ++index)
      {
        int i = WorldGen.genRand.Next(0, Main.maxTilesX);
        for (int j = 0; (double) j < num6; ++j)
        {
          if (Main.tile[i, j].active)
          {
            WorldGen.TileRunner(i, j, (double) WorldGen.genRand.Next(10, 15), WorldGen.genRand.Next(50, 130), -1, speedX: ((float) WorldGen.genRand.Next(-10, 11) * 0.1f), speedY: 2f);
            break;
          }
        }
      }
      for (int index = 0; index < (int) ((double) Main.maxTilesX * 0.0003); ++index)
      {
        int i = WorldGen.genRand.Next(0, Main.maxTilesX);
        for (int j = 0; (double) j < num6; ++j)
        {
          if (Main.tile[i, j].active)
          {
            WorldGen.TileRunner(i, j, (double) WorldGen.genRand.Next(12, 25), WorldGen.genRand.Next(150, 500), -1, speedX: ((float) WorldGen.genRand.Next(-10, 11) * 0.1f), speedY: 4f);
            WorldGen.TileRunner(i, j, (double) WorldGen.genRand.Next(8, 17), WorldGen.genRand.Next(60, 200), -1, speedX: ((float) WorldGen.genRand.Next(-10, 11) * 0.1f), speedY: 2f);
            WorldGen.TileRunner(i, j, (double) WorldGen.genRand.Next(5, 13), WorldGen.genRand.Next(40, 170), -1, speedX: ((float) WorldGen.genRand.Next(-10, 11) * 0.1f), speedY: 2f);
            break;
          }
        }
      }
      for (int index = 0; index < (int) ((double) Main.maxTilesX * 0.0004); ++index)
      {
        int i = WorldGen.genRand.Next(0, Main.maxTilesX);
        for (int j = 0; (double) j < num6; ++j)
        {
          if (Main.tile[i, j].active)
          {
            WorldGen.TileRunner(i, j, (double) WorldGen.genRand.Next(7, 12), WorldGen.genRand.Next(150, 250), -1, speedY: 1f, noYChange: true);
            break;
          }
        }
      }
      float num38 = (float) (Main.maxTilesX / 4200);
      for (int index = 0; (double) index < 5.0 * (double) num38; ++index)
      {
        try
        {
          WorldGen.Caverer(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int) Main.rockLayer, Main.maxTilesY - 400));
        }
        catch
        {
        }
      }
      for (int index23 = 0; index23 < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.002); ++index23)
      {
        int index24 = WorldGen.genRand.Next(1, Main.maxTilesX - 1);
        int index25 = WorldGen.genRand.Next((int) num5, (int) num6);
        if (index25 >= Main.maxTilesY)
          index25 = Main.maxTilesY - 2;
        if (Main.tile[index24 - 1, index25].active && Main.tile[index24 - 1, index25].type == (byte) 0 && Main.tile[index24 + 1, index25].active && Main.tile[index24 + 1, index25].type == (byte) 0 && Main.tile[index24, index25 - 1].active && Main.tile[index24, index25 - 1].type == (byte) 0 && Main.tile[index24, index25 + 1].active && Main.tile[index24, index25 + 1].type == (byte) 0)
        {
          Main.tile[index24, index25].active = true;
          Main.tile[index24, index25].type = (byte) 2;
        }
        int index26 = WorldGen.genRand.Next(1, Main.maxTilesX - 1);
        int index27 = WorldGen.genRand.Next(0, (int) num5);
        if (index27 >= Main.maxTilesY)
          index27 = Main.maxTilesY - 2;
        if (Main.tile[index26 - 1, index27].active && Main.tile[index26 - 1, index27].type == (byte) 0 && Main.tile[index26 + 1, index27].active && Main.tile[index26 + 1, index27].type == (byte) 0 && Main.tile[index26, index27 - 1].active && Main.tile[index26, index27 - 1].type == (byte) 0 && Main.tile[index26, index27 + 1].active && Main.tile[index26, index27 + 1].type == (byte) 0)
        {
          Main.tile[index26, index27].active = true;
          Main.tile[index26, index27].type = (byte) 2;
        }
      }
      Main.statusText = Lang.gen[11] + " 0%";
      float num39 = (float) (Main.maxTilesX / 4200) * 1.5f;
      int num40 = 0;
      float num41 = (float) WorldGen.genRand.Next(15, 30) * 0.01f;
      int num42;
      if (num9 == -1)
      {
        float num43 = 1f - num41;
        num42 = (int) ((double) Main.maxTilesX * (double) num43);
      }
      else
        num42 = (int) ((double) Main.maxTilesX * (double) num41);
      int num44 = (int) ((double) Main.maxTilesY + Main.rockLayer) / 2;
      int i1 = num42 + WorldGen.genRand.Next((int) (-100.0 * (double) num39), (int) (101.0 * (double) num39));
      int j1 = num44 + WorldGen.genRand.Next((int) (-100.0 * (double) num39), (int) (101.0 * (double) num39));
      int num45 = i1;
      int num46 = j1;
      WorldGen.TileRunner(i1, j1, (double) WorldGen.genRand.Next((int) (250.0 * (double) num39), (int) (500.0 * (double) num39)), WorldGen.genRand.Next(50, 150), 59, speedX: ((float) (num9 * 3)));
      for (int index = 0; (double) index < 6.0 * (double) num39; ++index)
        WorldGen.TileRunner(i1 + WorldGen.genRand.Next(-(int) (125.0 * (double) num39), (int) (125.0 * (double) num39)), j1 + WorldGen.genRand.Next(-(int) (125.0 * (double) num39), (int) (125.0 * (double) num39)), (double) WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(63, 65));
      WorldGen.mudWall = true;
      Main.statusText = Lang.gen[11] + " 15%";
      int i2 = i1 + WorldGen.genRand.Next((int) (-250.0 * (double) num39), (int) (251.0 * (double) num39));
      int j2 = j1 + WorldGen.genRand.Next((int) (-150.0 * (double) num39), (int) (151.0 * (double) num39));
      int num47 = i2;
      int num48 = j2;
      int num49 = i2;
      int num50 = j2;
      WorldGen.TileRunner(i2, j2, (double) WorldGen.genRand.Next((int) (250.0 * (double) num39), (int) (500.0 * (double) num39)), WorldGen.genRand.Next(50, 150), 59);
      WorldGen.mudWall = false;
      for (int index = 0; (double) index < 6.0 * (double) num39; ++index)
        WorldGen.TileRunner(i2 + WorldGen.genRand.Next(-(int) (125.0 * (double) num39), (int) (125.0 * (double) num39)), j2 + WorldGen.genRand.Next(-(int) (125.0 * (double) num39), (int) (125.0 * (double) num39)), (double) WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(65, 67));
      WorldGen.mudWall = true;
      Main.statusText = Lang.gen[11] + " 30%";
      int i3 = i2 + WorldGen.genRand.Next((int) (-400.0 * (double) num39), (int) (401.0 * (double) num39));
      int j3 = j2 + WorldGen.genRand.Next((int) (-150.0 * (double) num39), (int) (151.0 * (double) num39));
      int num51 = i3;
      int num52 = j3;
      WorldGen.TileRunner(i3, j3, (double) WorldGen.genRand.Next((int) (250.0 * (double) num39), (int) (500.0 * (double) num39)), WorldGen.genRand.Next(50, 150), 59, speedX: ((float) (num9 * -3)));
      WorldGen.mudWall = false;
      for (int index = 0; (double) index < 6.0 * (double) num39; ++index)
        WorldGen.TileRunner(i3 + WorldGen.genRand.Next(-(int) (125.0 * (double) num39), (int) (125.0 * (double) num39)), j3 + WorldGen.genRand.Next(-(int) (125.0 * (double) num39), (int) (125.0 * (double) num39)), (double) WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(67, 69));
      WorldGen.mudWall = true;
      Main.statusText = Lang.gen[11] + " 45%";
      int i4 = (num45 + num47 + num51) / 3;
      int j4 = (num46 + num48 + num52) / 3;
      WorldGen.TileRunner(i4, j4, (double) WorldGen.genRand.Next((int) (400.0 * (double) num39), (int) (600.0 * (double) num39)), 10000, 59, speedY: -20f, noYChange: true);
      WorldGen.JungleRunner(i4, j4);
      Main.statusText = Lang.gen[11] + " 60%";
      WorldGen.mudWall = false;
      for (int index = 0; index < Main.maxTilesX / 10; ++index)
      {
        int i5 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
        int j5;
        for (j5 = WorldGen.genRand.Next((int) Main.rockLayer, Main.maxTilesY - 200); Main.tile[i5, j5].wall != (byte) 15; j5 = WorldGen.genRand.Next((int) Main.rockLayer, Main.maxTilesY - 200))
          i5 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
        WorldGen.MudWallRunner(i5, j5);
      }
      int i6 = num49;
      int j6 = num50;
      for (int index = 0; (double) index <= 20.0 * (double) num39; ++index)
      {
        Main.statusText = Lang.gen[11] + " " + (object) (int) (60.0 + (double) index / (double) num39) + "%";
        i6 += WorldGen.genRand.Next((int) (-5.0 * (double) num39), (int) (6.0 * (double) num39));
        j6 += WorldGen.genRand.Next((int) (-5.0 * (double) num39), (int) (6.0 * (double) num39));
        WorldGen.TileRunner(i6, j6, (double) WorldGen.genRand.Next(40, 100), WorldGen.genRand.Next(300, 500), 59);
      }
      for (int index28 = 0; (double) index28 <= 10.0 * (double) num39; ++index28)
      {
        Main.statusText = Lang.gen[11] + " " + (object) (int) (80.0 + (double) index28 / (double) num39 * 2.0) + "%";
        int i7 = num49 + WorldGen.genRand.Next((int) (-600.0 * (double) num39), (int) (600.0 * (double) num39));
        int j7;
        for (j7 = num50 + WorldGen.genRand.Next((int) (-200.0 * (double) num39), (int) (200.0 * (double) num39)); i7 < 1 || i7 >= Main.maxTilesX - 1 || j7 < 1 || j7 >= Main.maxTilesY - 1 || Main.tile[i7, j7].type != (byte) 59; j7 = num50 + WorldGen.genRand.Next((int) (-200.0 * (double) num39), (int) (200.0 * (double) num39)))
          i7 = num49 + WorldGen.genRand.Next((int) (-600.0 * (double) num39), (int) (600.0 * (double) num39));
        for (int index29 = 0; (double) index29 < 8.0 * (double) num39; ++index29)
        {
          i7 += WorldGen.genRand.Next(-30, 31);
          j7 += WorldGen.genRand.Next(-30, 31);
          int type = -1;
          if (WorldGen.genRand.Next(7) == 0)
            type = -2;
          WorldGen.TileRunner(i7, j7, (double) WorldGen.genRand.Next(10, 20), WorldGen.genRand.Next(30, 70), type);
        }
      }
      for (int index = 0; (double) index <= 300.0 * (double) num39; ++index)
      {
        int i8 = num49 + WorldGen.genRand.Next((int) (-600.0 * (double) num39), (int) (600.0 * (double) num39));
        int j8;
        for (j8 = num50 + WorldGen.genRand.Next((int) (-200.0 * (double) num39), (int) (200.0 * (double) num39)); i8 < 1 || i8 >= Main.maxTilesX - 1 || j8 < 1 || j8 >= Main.maxTilesY - 1 || Main.tile[i8, j8].type != (byte) 59; j8 = num50 + WorldGen.genRand.Next((int) (-200.0 * (double) num39), (int) (200.0 * (double) num39)))
          i8 = num49 + WorldGen.genRand.Next((int) (-600.0 * (double) num39), (int) (600.0 * (double) num39));
        WorldGen.TileRunner(i8, j8, (double) WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(5, 30), 1);
        if (WorldGen.genRand.Next(4) == 0)
        {
          int type = WorldGen.genRand.Next(63, 69);
          WorldGen.TileRunner(i8 + WorldGen.genRand.Next(-1, 2), j8 + WorldGen.genRand.Next(-1, 2), (double) WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(4, 8), type);
        }
      }
      num40 = num49;
      float num53 = (float) WorldGen.genRand.Next(6, 10) * (float) (Main.maxTilesX / 4200);
      for (int index30 = 0; (double) index30 < (double) num53; ++index30)
      {
        bool flag5 = true;
        while (flag5)
        {
          int index31 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
          int index32 = WorldGen.genRand.Next((int) (Main.worldSurface + Main.rockLayer) / 2, Main.maxTilesY - 300);
          if (Main.tile[index31, index32].type == (byte) 59)
          {
            flag5 = false;
            int num54 = WorldGen.genRand.Next(2, 4);
            int num55 = WorldGen.genRand.Next(2, 4);
            for (int index33 = index31 - num54 - 1; index33 <= index31 + num54 + 1; ++index33)
            {
              for (int index34 = index32 - num55 - 1; index34 <= index32 + num55 + 1; ++index34)
              {
                Main.tile[index33, index34].active = true;
                Main.tile[index33, index34].type = (byte) 45;
                Main.tile[index33, index34].liquid = (byte) 0;
                Main.tile[index33, index34].lava = false;
              }
            }
            for (int index35 = index31 - num54; index35 <= index31 + num54; ++index35)
            {
              for (int index36 = index32 - num55; index36 <= index32 + num55; ++index36)
                Main.tile[index35, index36].active = false;
            }
            bool flag6 = false;
            int num56 = 0;
            while (!flag6 && num56 < 100)
            {
              ++num56;
              int i9 = WorldGen.genRand.Next(index31 - num54, index31 + num54 + 1);
              int j9 = WorldGen.genRand.Next(index32 - num55, index32 + num55 - 2);
              WorldGen.PlaceTile(i9, j9, 4, true);
              if (Main.tile[i9, j9].type == (byte) 4)
                flag6 = true;
            }
            for (int index37 = index31 - num54 - 1; index37 <= index31 + num54 + 1; ++index37)
            {
              for (int index38 = index32 + num55 - 2; index38 <= index32 + num55; ++index38)
                Main.tile[index37, index38].active = false;
            }
            for (int index39 = index31 - num54 - 1; index39 <= index31 + num54 + 1; ++index39)
            {
              for (int index40 = index32 + num55 - 2; index40 <= index32 + num55 - 1; ++index40)
                Main.tile[index39, index40].active = false;
            }
            for (int index41 = index31 - num54 - 1; index41 <= index31 + num54 + 1; ++index41)
            {
              int num57 = 4;
              for (int index42 = index32 + num55 + 2; !Main.tile[index41, index42].active && index42 < Main.maxTilesY && num57 > 0; --num57)
              {
                Main.tile[index41, index42].active = true;
                Main.tile[index41, index42].type = (byte) 59;
                ++index42;
              }
            }
            int num58 = num54 - WorldGen.genRand.Next(1, 3);
            int index43 = index32 - num55 - 2;
            while (num58 > -1)
            {
              for (int index44 = index31 - num58 - 1; index44 <= index31 + num58 + 1; ++index44)
              {
                Main.tile[index44, index43].active = true;
                Main.tile[index44, index43].type = (byte) 45;
              }
              num58 -= WorldGen.genRand.Next(1, 3);
              --index43;
            }
            WorldGen.JChestX[WorldGen.numJChests] = index31;
            WorldGen.JChestY[WorldGen.numJChests] = index32;
            ++WorldGen.numJChests;
          }
        }
      }
      for (int i10 = 0; i10 < Main.maxTilesX; ++i10)
      {
        for (int j10 = 0; j10 < Main.maxTilesY; ++j10)
        {
          if (Main.tile[i10, j10].active)
          {
            try
            {
              WorldGen.grassSpread = 0;
              WorldGen.SpreadGrass(i10, j10, 59, 60);
            }
            catch
            {
              WorldGen.grassSpread = 0;
              WorldGen.SpreadGrass(i10, j10, 59, 60, false);
            }
          }
        }
      }
      WorldGen.numIslandHouses = 0;
      WorldGen.houseCount = 0;
      Main.statusText = Lang.gen[12];
      for (int index45 = 0; index45 < (int) ((double) Main.maxTilesX * 0.0008); ++index45)
      {
        int num59 = 0;
        bool flag7 = false;
        int index46 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.1), (int) ((double) Main.maxTilesX * 0.9));
        bool flag8 = false;
        while (!flag8)
        {
          flag8 = true;
          while (index46 > Main.maxTilesX / 2 - 80 && index46 < Main.maxTilesX / 2 + 80)
            index46 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.1), (int) ((double) Main.maxTilesX * 0.9));
          for (int index47 = 0; index47 < WorldGen.numIslandHouses; ++index47)
          {
            if (index46 > WorldGen.fihX[index47] - 80 && index46 < WorldGen.fihX[index47] + 80)
            {
              ++num59;
              flag8 = false;
              break;
            }
          }
          if (num59 >= 200)
          {
            flag7 = true;
            break;
          }
        }
        if (!flag7)
        {
          for (int index48 = 200; (double) index48 < Main.worldSurface; ++index48)
          {
            if (Main.tile[index46, index48].active)
            {
              int i11 = index46;
              int j11 = WorldGen.genRand.Next(90, index48 - 100);
              while ((double) j11 > num5 - 50.0)
                --j11;
              WorldGen.FloatingIsland(i11, j11);
              WorldGen.fihX[WorldGen.numIslandHouses] = i11;
              WorldGen.fihY[WorldGen.numIslandHouses] = j11;
              ++WorldGen.numIslandHouses;
              break;
            }
          }
        }
      }
      Main.statusText = Lang.gen[13];
      for (int index = 0; index < Main.maxTilesX / 500; ++index)
        WorldGen.ShroomPatch(WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.3), (int) ((double) Main.maxTilesX * 0.7)), WorldGen.genRand.Next((int) Main.rockLayer, Main.maxTilesY - 350));
      for (int i12 = 0; i12 < Main.maxTilesX; ++i12)
      {
        for (int worldSurface = (int) Main.worldSurface; worldSurface < Main.maxTilesY; ++worldSurface)
        {
          if (Main.tile[i12, worldSurface].active)
          {
            WorldGen.grassSpread = 0;
            WorldGen.SpreadGrass(i12, worldSurface, 59, 70, false);
          }
        }
      }
      Main.statusText = Lang.gen[14];
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.001); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 40), 59);
      Main.statusText = Lang.gen[15];
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0001); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num8, Main.maxTilesY), (double) WorldGen.genRand.Next(5, 12), WorldGen.genRand.Next(15, 50), 123);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0005); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num8, Main.maxTilesY), (double) WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 5), 123);
      Main.statusText = Lang.gen[16];
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 6E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6), (double) WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), 7);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 8E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8), (double) WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), 7);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0002); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 7);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 3E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6), (double) WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), 6);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 8E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8), (double) WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), 6);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0002); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 6);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 2.6E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8), (double) WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), 9);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.00015); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 9);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.00017); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int) num5), (double) WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 9);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.00012); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), 8);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.00012); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int) num5 - 20), (double) WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), 8);
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 2E-05); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int) num7, Main.maxTilesY), (double) WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), 22);
      Main.statusText = Lang.gen[17];
      for (int index49 = 0; index49 < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0006); ++index49)
      {
        int index50 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
        int index51 = WorldGen.genRand.Next((int) num5, Main.maxTilesY - 20);
        if (index49 < WorldGen.numMCaves)
        {
          index50 = WorldGen.mCaveX[index49];
          index51 = WorldGen.mCaveY[index49];
        }
        if (!Main.tile[index50, index51].active && ((double) index51 > Main.worldSurface || Main.tile[index50, index51].wall > (byte) 0))
        {
          while (!Main.tile[index50, index51].active && index51 > (int) num5)
            --index51;
          int j12 = index51 + 1;
          int num60 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num60 = -1;
          while (!Main.tile[index50, j12].active && index50 > 10 && index50 < Main.maxTilesX - 10)
            index50 += num60;
          int i13 = index50 - num60;
          if ((double) j12 > Main.worldSurface || Main.tile[i13, j12].wall > (byte) 0)
            WorldGen.TileRunner(i13, j12, (double) WorldGen.genRand.Next(4, 11), WorldGen.genRand.Next(2, 4), 51, true, (float) num60, -1f, overRide: false);
        }
      }
      Main.statusText = Lang.gen[18] + " 0%";
      int num61 = Main.maxTilesY - WorldGen.genRand.Next(150, 190);
      for (int index52 = 0; index52 < Main.maxTilesX; ++index52)
      {
        num61 += WorldGen.genRand.Next(-3, 4);
        if (num61 < Main.maxTilesY - 190)
          num61 = Main.maxTilesY - 190;
        if (num61 > Main.maxTilesY - 160)
          num61 = Main.maxTilesY - 160;
        for (int index53 = num61 - 20 - WorldGen.genRand.Next(3); index53 < Main.maxTilesY; ++index53)
        {
          if (index53 >= num61)
          {
            Main.tile[index52, index53].active = false;
            Main.tile[index52, index53].lava = false;
            Main.tile[index52, index53].liquid = (byte) 0;
          }
          else
            Main.tile[index52, index53].type = (byte) 57;
        }
      }
      int num62 = Main.maxTilesY - WorldGen.genRand.Next(40, 70);
      for (int index54 = 10; index54 < Main.maxTilesX - 10; ++index54)
      {
        num62 += WorldGen.genRand.Next(-10, 11);
        if (num62 > Main.maxTilesY - 60)
          num62 = Main.maxTilesY - 60;
        if (num62 < Main.maxTilesY - 100)
          num62 = Main.maxTilesY - 120;
        for (int index55 = num62; index55 < Main.maxTilesY - 10; ++index55)
        {
          if (!Main.tile[index54, index55].active)
          {
            Main.tile[index54, index55].lava = true;
            Main.tile[index54, index55].liquid = byte.MaxValue;
          }
        }
      }
      for (int index56 = 0; index56 < Main.maxTilesX; ++index56)
      {
        if (WorldGen.genRand.Next(50) == 0)
        {
          int index57 = Main.maxTilesY - 65;
          while (!Main.tile[index56, index57].active && index57 > Main.maxTilesY - 135)
            --index57;
          WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), index57 + WorldGen.genRand.Next(20, 50), (double) WorldGen.genRand.Next(15, 20), 1000, 57, true, speedY: ((float) WorldGen.genRand.Next(1, 3)), noYChange: true);
        }
      }
      Liquid.QuickWater(-2);
      for (int i14 = 0; i14 < Main.maxTilesX; ++i14)
      {
        float num63 = (float) i14 / (float) (Main.maxTilesX - 1);
        Main.statusText = Lang.gen[18] + " " + (object) (int) ((double) num63 * 100.0 / 2.0 + 50.0) + "%";
        if (WorldGen.genRand.Next(13) == 0)
        {
          int index = Main.maxTilesY - 65;
          while ((Main.tile[i14, index].liquid > (byte) 0 || Main.tile[i14, index].active) && index > Main.maxTilesY - 140)
            --index;
          WorldGen.TileRunner(i14, index - WorldGen.genRand.Next(2, 5), (double) WorldGen.genRand.Next(5, 30), 1000, 57, true, speedY: ((float) WorldGen.genRand.Next(1, 3)), noYChange: true);
          float num64 = (float) WorldGen.genRand.Next(1, 3);
          if (WorldGen.genRand.Next(3) == 0)
            num64 *= 0.5f;
          if (WorldGen.genRand.Next(2) == 0)
            WorldGen.TileRunner(i14, index - WorldGen.genRand.Next(2, 5), (double) (int) ((double) WorldGen.genRand.Next(5, 15) * (double) num64), (int) ((double) WorldGen.genRand.Next(10, 15) * (double) num64), 57, true, 1f, 0.3f);
          if (WorldGen.genRand.Next(2) == 0)
          {
            float num65 = (float) WorldGen.genRand.Next(1, 3);
            WorldGen.TileRunner(i14, index - WorldGen.genRand.Next(2, 5), (double) (int) ((double) WorldGen.genRand.Next(5, 15) * (double) num65), (int) ((double) WorldGen.genRand.Next(10, 15) * (double) num65), 57, true, -1f, 0.3f);
          }
          WorldGen.TileRunner(i14 + WorldGen.genRand.Next(-10, 10), index + WorldGen.genRand.Next(-10, 10), (double) WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(5, 10), -2, speedX: ((float) WorldGen.genRand.Next(-1, 3)), speedY: ((float) WorldGen.genRand.Next(-1, 3)));
          if (WorldGen.genRand.Next(3) == 0)
            WorldGen.TileRunner(i14 + WorldGen.genRand.Next(-10, 10), index + WorldGen.genRand.Next(-10, 10), (double) WorldGen.genRand.Next(10, 30), WorldGen.genRand.Next(10, 20), -2, speedX: ((float) WorldGen.genRand.Next(-1, 3)), speedY: ((float) WorldGen.genRand.Next(-1, 3)));
          if (WorldGen.genRand.Next(5) == 0)
            WorldGen.TileRunner(i14 + WorldGen.genRand.Next(-15, 15), index + WorldGen.genRand.Next(-15, 10), (double) WorldGen.genRand.Next(15, 30), WorldGen.genRand.Next(5, 20), -2, speedX: ((float) WorldGen.genRand.Next(-1, 3)), speedY: ((float) WorldGen.genRand.Next(-1, 3)));
        }
      }
      for (int index = 0; index < Main.maxTilesX; ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(20, Main.maxTilesX - 20), WorldGen.genRand.Next(Main.maxTilesY - 180, Main.maxTilesY - 10), (double) WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(2, 7), -2);
      for (int index = 0; index < Main.maxTilesX; ++index)
      {
        if (!Main.tile[index, Main.maxTilesY - 145].active)
        {
          Main.tile[index, Main.maxTilesY - 145].liquid = byte.MaxValue;
          Main.tile[index, Main.maxTilesY - 145].lava = true;
        }
        if (!Main.tile[index, Main.maxTilesY - 144].active)
        {
          Main.tile[index, Main.maxTilesY - 144].liquid = byte.MaxValue;
          Main.tile[index, Main.maxTilesY - 144].lava = true;
        }
      }
      for (int index = 0; index < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0008); ++index)
        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), (double) WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(3, 7), 58);
      WorldGen.AddHellHouses();
      int num66 = WorldGen.genRand.Next(2, (int) ((double) Main.maxTilesX * 0.005));
      for (int index = 0; index < num66; ++index)
      {
        float num67 = (float) index / (float) num66;
        Main.statusText = Lang.gen[19] + " " + (object) (int) ((double) num67 * 100.0) + "%";
        int i15 = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
        while (i15 > Main.maxTilesX / 2 - 50 && i15 < Main.maxTilesX / 2 + 50)
          i15 = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
        int j13 = (int) num5 - 20;
        while (!Main.tile[i15, j13].active)
          ++j13;
        WorldGen.Lakinater(i15, j13);
      }
      int x1;
      int num68;
      if (num9 == -1)
      {
        x1 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.05), (int) ((double) Main.maxTilesX * 0.2));
        num68 = -1;
      }
      else
      {
        x1 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.8), (int) ((double) Main.maxTilesX * 0.95));
        num68 = 1;
      }
      int y1 = (int) ((Main.rockLayer + (double) Main.maxTilesY) / 2.0) + WorldGen.genRand.Next(-200, 200);
      WorldGen.MakeDungeon(x1, y1);
      for (int index58 = 0; (double) index58 < (double) Main.maxTilesX * 0.00045; ++index58)
      {
        float num69 = (float) index58 / ((float) Main.maxTilesX * 0.00045f);
        Main.statusText = Lang.gen[20] + " " + (object) (int) ((double) num69 * 100.0) + "%";
        bool flag9 = false;
        int num70 = 0;
        int num71 = 0;
        int num72 = 0;
        while (!flag9)
        {
          int num73 = 0;
          flag9 = true;
          int num74 = Main.maxTilesX / 2;
          int num75 = 200;
          num70 = WorldGen.genRand.Next(320, Main.maxTilesX - 320);
          num71 = num70 - WorldGen.genRand.Next(200) - 100;
          num72 = num70 + WorldGen.genRand.Next(200) + 100;
          if (num71 < 285)
            num71 = 285;
          if (num72 > Main.maxTilesX - 285)
            num72 = Main.maxTilesX - 285;
          if (num70 > num74 - num75 && num70 < num74 + num75)
            flag9 = false;
          if (num71 > num74 - num75 && num71 < num74 + num75)
            flag9 = false;
          if (num72 > num74 - num75 && num72 < num74 + num75)
            flag9 = false;
          for (int index59 = num71; index59 < num72; ++index59)
          {
            for (int index60 = 0; index60 < (int) Main.worldSurface; index60 += 5)
            {
              if (Main.tile[index59, index60].active && Main.tileDungeon[(int) Main.tile[index59, index60].type])
              {
                flag9 = false;
                break;
              }
              if (!flag9)
                break;
            }
          }
          if (num73 < 200 && WorldGen.JungleX > num71 && WorldGen.JungleX < num72)
          {
            int num76 = num73 + 1;
            flag9 = false;
          }
        }
        int num77 = 0;
        for (int i16 = num71; i16 < num72; ++i16)
        {
          if (num77 > 0)
            --num77;
          if (i16 == num70 || num77 == 0)
          {
            for (int j14 = (int) num5; (double) j14 < Main.worldSurface - 1.0; ++j14)
            {
              if (Main.tile[i16, j14].active || Main.tile[i16, j14].wall > (byte) 0)
              {
                if (i16 == num70)
                {
                  num77 = 20;
                  WorldGen.ChasmRunner(i16, j14, WorldGen.genRand.Next(150) + 150, true);
                  break;
                }
                if (WorldGen.genRand.Next(35) == 0 && num77 == 0)
                {
                  num77 = 30;
                  bool makeOrb = true;
                  WorldGen.ChasmRunner(i16, j14, WorldGen.genRand.Next(50) + 50, makeOrb);
                  break;
                }
                break;
              }
            }
          }
          for (int index61 = (int) num5; (double) index61 < Main.worldSurface - 1.0; ++index61)
          {
            if (Main.tile[i16, index61].active)
            {
              int num78 = index61 + WorldGen.genRand.Next(10, 14);
              for (int index62 = index61; index62 < num78; ++index62)
              {
                if ((Main.tile[i16, index62].type == (byte) 59 || Main.tile[i16, index62].type == (byte) 60) && i16 >= num71 + WorldGen.genRand.Next(5) && i16 < num72 - WorldGen.genRand.Next(5))
                  Main.tile[i16, index62].type = (byte) 0;
              }
              break;
            }
          }
        }
        double num79 = Main.worldSurface + 40.0;
        for (int index63 = num71; index63 < num72; ++index63)
        {
          num79 += (double) WorldGen.genRand.Next(-2, 3);
          if (num79 < Main.worldSurface + 30.0)
            num79 = Main.worldSurface + 30.0;
          if (num79 > Main.worldSurface + 50.0)
            num79 = Main.worldSurface + 50.0;
          int i17 = index63;
          bool flag10 = false;
          for (int j15 = (int) num5; (double) j15 < num79; ++j15)
          {
            if (Main.tile[i17, j15].active)
            {
              if (Main.tile[i17, j15].type == (byte) 53 && i17 >= num71 + WorldGen.genRand.Next(5) && i17 <= num72 - WorldGen.genRand.Next(5))
                Main.tile[i17, j15].type = (byte) 0;
              if (Main.tile[i17, j15].type == (byte) 0 && (double) j15 < Main.worldSurface - 1.0 && !flag10)
              {
                WorldGen.grassSpread = 0;
                WorldGen.SpreadGrass(i17, j15, grass: 23);
              }
              flag10 = true;
              if (Main.tile[i17, j15].type == (byte) 1 && i17 >= num71 + WorldGen.genRand.Next(5) && i17 <= num72 - WorldGen.genRand.Next(5))
                Main.tile[i17, j15].type = (byte) 25;
              if (Main.tile[i17, j15].type == (byte) 2)
                Main.tile[i17, j15].type = (byte) 23;
            }
          }
        }
        for (int index64 = num71; index64 < num72; ++index64)
        {
          for (int index65 = 0; index65 < Main.maxTilesY - 50; ++index65)
          {
            if (Main.tile[index64, index65].active && Main.tile[index64, index65].type == (byte) 31)
            {
              int num80 = index64 - 13;
              int num81 = index64 + 13;
              int num82 = index65 - 13;
              int num83 = index65 + 13;
              for (int index66 = num80; index66 < num81; ++index66)
              {
                if (index66 > 10 && index66 < Main.maxTilesX - 10)
                {
                  for (int index67 = num82; index67 < num83; ++index67)
                  {
                    if (Math.Abs(index66 - index64) + Math.Abs(index67 - index65) < 9 + WorldGen.genRand.Next(11) && WorldGen.genRand.Next(3) != 0 && Main.tile[index66, index67].type != (byte) 31)
                    {
                      Main.tile[index66, index67].active = true;
                      Main.tile[index66, index67].type = (byte) 25;
                      if (Math.Abs(index66 - index64) <= 1 && Math.Abs(index67 - index65) <= 1)
                        Main.tile[index66, index67].active = false;
                    }
                    if (Main.tile[index66, index67].type != (byte) 31 && Math.Abs(index66 - index64) <= 2 + WorldGen.genRand.Next(3) && Math.Abs(index67 - index65) <= 2 + WorldGen.genRand.Next(3))
                      Main.tile[index66, index67].active = false;
                  }
                }
              }
            }
          }
        }
      }
      Main.statusText = Lang.gen[21];
      for (int index = 0; index < WorldGen.numMCaves; ++index)
      {
        int i18 = WorldGen.mCaveX[index];
        int j16 = WorldGen.mCaveY[index];
        WorldGen.CaveOpenater(i18, j16);
        WorldGen.Cavinator(i18, j16, WorldGen.genRand.Next(40, 50));
      }
      int index68 = 0;
      int index69 = 0;
      int index70 = 20;
      int index71 = Main.maxTilesX - 20;
      Main.statusText = Lang.gen[22];
      for (int index72 = 0; index72 < 2; ++index72)
      {
        if (index72 == 0)
        {
          int num84 = 0;
          int num85 = WorldGen.genRand.Next(125, 200) + 50;
          if (num68 == 1)
            num85 = 275;
          int num86 = 0;
          float num87 = 1f;
          int index73 = 0;
          while (!Main.tile[num85 - 1, index73].active)
            ++index73;
          index68 = index73;
          int num88 = index73 + WorldGen.genRand.Next(1, 5);
          for (int index74 = num85 - 1; index74 >= num84; --index74)
          {
            ++num86;
            if (num86 < 3)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.2f;
            else if (num86 < 6)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.15f;
            else if (num86 < 9)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
            else if (num86 < 15)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.07f;
            else if (num86 < 50)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
            else if (num86 < 75)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.04f;
            else if (num86 < 100)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.03f;
            else if (num86 < 125)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.02f;
            else if (num86 < 150)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
            else if (num86 < 175)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.005f;
            else if (num86 < 200)
              num87 += (float) WorldGen.genRand.Next(10, 20) * (1f / 1000f);
            else if (num86 < 230)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
            else if (num86 < 235)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
            else if (num86 < 240)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
            else if (num86 < 245)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
            else if (num86 < (int) byte.MaxValue)
              num87 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
            if (num86 == 235)
              index71 = index74;
            if (num86 == 235)
              index70 = index74;
            int num89 = WorldGen.genRand.Next(15, 20);
            for (int index75 = 0; (double) index75 < (double) num88 + (double) num87 + (double) num89; ++index75)
            {
              if ((double) index75 < (double) num88 + (double) num87 * 0.75 - 3.0)
              {
                Main.tile[index74, index75].active = false;
                if (index75 > num88)
                  Main.tile[index74, index75].liquid = byte.MaxValue;
                else if (index75 == num88)
                  Main.tile[index74, index75].liquid = (byte) 127;
              }
              else if (index75 > num88)
              {
                Main.tile[index74, index75].type = (byte) 53;
                Main.tile[index74, index75].active = true;
              }
              Main.tile[index74, index75].wall = (byte) 0;
            }
          }
        }
        else
        {
          int index76 = Main.maxTilesX - WorldGen.genRand.Next(125, 200) - 50;
          int maxTilesX = Main.maxTilesX;
          if (num68 == -1)
            index76 = Main.maxTilesX - 275;
          float num90 = 1f;
          int num91 = 0;
          int index77 = 0;
          while (!Main.tile[index76, index77].active)
            ++index77;
          index69 = index77;
          int num92 = index77 + WorldGen.genRand.Next(1, 5);
          for (int index78 = index76; index78 < maxTilesX; ++index78)
          {
            ++num91;
            if (num91 < 3)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.2f;
            else if (num91 < 6)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.15f;
            else if (num91 < 9)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
            else if (num91 < 15)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.07f;
            else if (num91 < 50)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
            else if (num91 < 75)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.04f;
            else if (num91 < 100)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.03f;
            else if (num91 < 125)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.02f;
            else if (num91 < 150)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
            else if (num91 < 175)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.005f;
            else if (num91 < 200)
              num90 += (float) WorldGen.genRand.Next(10, 20) * (1f / 1000f);
            else if (num91 < 230)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
            else if (num91 < 235)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
            else if (num91 < 240)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
            else if (num91 < 245)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
            else if (num91 < (int) byte.MaxValue)
              num90 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
            if (num91 == 235)
              index71 = index78;
            int num93 = WorldGen.genRand.Next(15, 20);
            for (int index79 = 0; (double) index79 < (double) num92 + (double) num90 + (double) num93; ++index79)
            {
              if ((double) index79 < (double) num92 + (double) num90 * 0.75 - 3.0 && (double) index79 < Main.worldSurface - 2.0)
              {
                Main.tile[index78, index79].active = false;
                if (index79 > num92)
                  Main.tile[index78, index79].liquid = byte.MaxValue;
                else if (index79 == num92)
                  Main.tile[index78, index79].liquid = (byte) 127;
              }
              else if (index79 > num92)
              {
                Main.tile[index78, index79].type = (byte) 53;
                Main.tile[index78, index79].active = true;
              }
              Main.tile[index78, index79].wall = (byte) 0;
            }
          }
        }
      }
      while (!Main.tile[index70, index68].active)
        ++index68;
      int num94 = index68 + 1;
      while (!Main.tile[index71, index69].active)
        ++index69;
      int num95 = index69 + 1;
      Main.statusText = Lang.gen[23];
      for (int type = 63; type <= 68; ++type)
      {
        float num96 = 0.0f;
        switch (type)
        {
          case 63:
            num96 = (float) Main.maxTilesX * 0.3f;
            break;
          case 64:
            num96 = (float) Main.maxTilesX * 0.1f;
            break;
          case 65:
            num96 = (float) Main.maxTilesX * 0.25f;
            break;
          case 66:
            num96 = (float) Main.maxTilesX * 0.45f;
            break;
          case 67:
            num96 = (float) Main.maxTilesX * 0.5f;
            break;
          case 68:
            num96 = (float) Main.maxTilesX * 0.05f;
            break;
        }
        float num97 = num96 * 0.2f;
        for (int index80 = 0; (double) index80 < (double) num97; ++index80)
        {
          int i19 = WorldGen.genRand.Next(0, Main.maxTilesX);
          int j17;
          for (j17 = WorldGen.genRand.Next((int) Main.worldSurface, Main.maxTilesY); Main.tile[i19, j17].type != (byte) 1; j17 = WorldGen.genRand.Next((int) Main.worldSurface, Main.maxTilesY))
            i19 = WorldGen.genRand.Next(0, Main.maxTilesX);
          WorldGen.TileRunner(i19, j17, (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type);
        }
      }
      for (int index81 = 0; index81 < 2; ++index81)
      {
        int num98 = 1;
        int num99 = 5;
        int num100 = Main.maxTilesX - 5;
        if (index81 == 1)
        {
          num98 = -1;
          num99 = Main.maxTilesX - 5;
          num100 = 5;
        }
        for (int index82 = num99; index82 != num100; index82 += num98)
        {
          for (int index83 = 10; index83 < Main.maxTilesY - 10; ++index83)
          {
            if (Main.tile[index82, index83].active && Main.tile[index82, index83].type == (byte) 53 && Main.tile[index82, index83 + 1].active && Main.tile[index82, index83 + 1].type == (byte) 53)
            {
              int index84 = index82 + num98;
              int index85 = index83 + 1;
              if (!Main.tile[index84, index83].active && !Main.tile[index84, index83 + 1].active)
              {
                while (!Main.tile[index84, index85].active)
                  ++index85;
                int index86 = index85 - 1;
                Main.tile[index82, index83].active = false;
                Main.tile[index84, index86].active = true;
                Main.tile[index84, index86].type = (byte) 53;
              }
            }
          }
        }
      }
      for (int index87 = 0; index87 < Main.maxTilesX; ++index87)
      {
        float num101 = (float) index87 / (float) (Main.maxTilesX - 1);
        Main.statusText = Lang.gen[24] + " " + (object) (int) ((double) num101 * 100.0) + "%";
        for (int index88 = Main.maxTilesY - 5; index88 > 0; --index88)
        {
          if (Main.tile[index87, index88].active)
          {
            if (Main.tile[index87, index88].type == (byte) 53)
            {
              for (int index89 = index88; !Main.tile[index87, index89 + 1].active && index89 < Main.maxTilesY - 5; ++index89)
              {
                Main.tile[index87, index89 + 1].active = true;
                Main.tile[index87, index89 + 1].type = (byte) 53;
              }
            }
            else if (Main.tile[index87, index88].type == (byte) 123)
            {
              for (int index90 = index88; !Main.tile[index87, index90 + 1].active && index90 < Main.maxTilesY - 5; ++index90)
              {
                Main.tile[index87, index90 + 1].active = true;
                Main.tile[index87, index90 + 1].type = (byte) 123;
                Main.tile[index87, index90].active = false;
              }
            }
          }
        }
      }
      for (int index91 = 3; index91 < Main.maxTilesX - 3; ++index91)
      {
        float num102 = (float) index91 / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[25] + " " + (object) (int) ((double) num102 * 100.0 + 1.0) + "%";
        bool flag11 = true;
        for (int index92 = 0; (double) index92 < Main.worldSurface; ++index92)
        {
          if (flag11)
          {
            if (Main.tile[index91, index92].wall == (byte) 2)
              Main.tile[index91, index92].wall = (byte) 0;
            if (Main.tile[index91, index92].type != (byte) 53)
            {
              if (Main.tile[index91 - 1, index92].wall == (byte) 2)
                Main.tile[index91 - 1, index92].wall = (byte) 0;
              if (Main.tile[index91 - 2, index92].wall == (byte) 2 && WorldGen.genRand.Next(2) == 0)
                Main.tile[index91 - 2, index92].wall = (byte) 0;
              if (Main.tile[index91 - 3, index92].wall == (byte) 2 && WorldGen.genRand.Next(2) == 0)
                Main.tile[index91 - 3, index92].wall = (byte) 0;
              if (Main.tile[index91 + 1, index92].wall == (byte) 2)
                Main.tile[index91 + 1, index92].wall = (byte) 0;
              if (Main.tile[index91 + 2, index92].wall == (byte) 2 && WorldGen.genRand.Next(2) == 0)
                Main.tile[index91 + 2, index92].wall = (byte) 0;
              if (Main.tile[index91 + 3, index92].wall == (byte) 2 && WorldGen.genRand.Next(2) == 0)
                Main.tile[index91 + 3, index92].wall = (byte) 0;
              if (Main.tile[index91, index92].active)
                flag11 = false;
            }
          }
          else if (Main.tile[index91, index92].wall == (byte) 0 && Main.tile[index91, index92 + 1].wall == (byte) 0 && Main.tile[index91, index92 + 2].wall == (byte) 0 && Main.tile[index91, index92 + 3].wall == (byte) 0 && Main.tile[index91, index92 + 4].wall == (byte) 0 && Main.tile[index91 - 1, index92].wall == (byte) 0 && Main.tile[index91 + 1, index92].wall == (byte) 0 && Main.tile[index91 - 2, index92].wall == (byte) 0 && Main.tile[index91 + 2, index92].wall == (byte) 0 && !Main.tile[index91, index92].active && !Main.tile[index91, index92 + 1].active && !Main.tile[index91, index92 + 2].active && !Main.tile[index91, index92 + 3].active)
            flag11 = true;
        }
      }
      for (int index93 = 0; index93 < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 2E-05); ++index93)
      {
        float num103 = (float) index93 / ((float) (Main.maxTilesX * Main.maxTilesY) * 2E-05f);
        Main.statusText = Lang.gen[26] + " " + (object) (int) ((double) num103 * 100.0 + 1.0) + "%";
        bool flag12 = false;
        int num104 = 0;
        while (!flag12)
        {
          int x2 = WorldGen.genRand.Next(1, Main.maxTilesX);
          int y2 = (int) (num6 + 20.0);
          WorldGen.Place3x2(x2, y2, 26);
          if (Main.tile[x2, y2].type == (byte) 26)
          {
            flag12 = true;
          }
          else
          {
            ++num104;
            if (num104 >= 10000)
              flag12 = true;
          }
        }
      }
      for (int index94 = 0; index94 < Main.maxTilesX; ++index94)
      {
        int index95 = index94;
        for (int index96 = (int) num5; (double) index96 < Main.worldSurface - 1.0; ++index96)
        {
          if (Main.tile[index95, index96].active)
          {
            if (Main.tile[index95, index96].type == (byte) 60)
            {
              Main.tile[index95, index96 - 1].liquid = byte.MaxValue;
              Main.tile[index95, index96 - 2].liquid = byte.MaxValue;
              break;
            }
            break;
          }
        }
      }
      for (int index97 = 400; index97 < Main.maxTilesX - 400; ++index97)
      {
        int index98 = index97;
        for (int index99 = (int) num5; (double) index99 < Main.worldSurface - 1.0; ++index99)
        {
          if (Main.tile[index98, index99].active)
          {
            if (Main.tile[index98, index99].type == (byte) 53)
            {
              int index100 = index99;
              while ((double) index100 > num5)
              {
                --index100;
                Main.tile[index98, index100].liquid = (byte) 0;
              }
              break;
            }
            break;
          }
        }
      }
      Liquid.QuickWater(3);
      WorldGen.WaterCheck();
      int num105 = 0;
      Liquid.quickSettle = true;
      while (num105 < 10)
      {
        int num106 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
        ++num105;
        float num107 = 0.0f;
        while (Liquid.numLiquid > 0)
        {
          float num108 = (float) (num106 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float) num106;
          if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num106)
            num106 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
          if ((double) num108 > (double) num107)
            num107 = num108;
          else
            num108 = num107;
          if (num105 == 1)
            Main.statusText = Lang.gen[27] + " " + (object) (int) ((double) num108 * 100.0 / 3.0 + 33.0) + "%";
          int num109 = 10;
          if (num105 > num109)
            ;
          Liquid.UpdateLiquid();
        }
        WorldGen.WaterCheck();
        Main.statusText = Lang.gen[27] + " " + (object) (int) ((double) num105 * 10.0 / 3.0 + 66.0) + "%";
      }
      Liquid.quickSettle = false;
      float num110 = (float) (Main.maxTilesX / 4200);
      for (int index101 = 0; index101 < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 2E-05); ++index101)
      {
        float num111 = (float) index101 / ((float) (Main.maxTilesX * Main.maxTilesY) * 2E-05f);
        Main.statusText = Lang.gen[28] + " " + (object) (int) ((double) num111 * 100.0 + 1.0) + "%";
        bool flag13 = false;
        int num112 = 0;
        while (!flag13)
        {
          if (WorldGen.AddLifeCrystal(WorldGen.genRand.Next(1, Main.maxTilesX), WorldGen.genRand.Next((int) (num6 + 20.0), Main.maxTilesY)))
          {
            flag13 = true;
          }
          else
          {
            ++num112;
            if (num112 >= 10000)
              flag13 = true;
          }
        }
      }
      int style = 0;
      for (int index102 = 0; (double) index102 < 82.0 * (double) num110; ++index102)
      {
        if (style > 41)
          style = 0;
        float num113 = (float) index102 / (200f * num110);
        Main.statusText = Lang.gen[29] + " " + (object) (int) ((double) num113 * 100.0 + 1.0) + "%";
        bool flag14 = false;
        int num114 = 0;
        while (!flag14)
        {
          int i20 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
          int index103 = WorldGen.genRand.Next((int) (num6 + 20.0), Main.maxTilesY - 300);
          while (!Main.tile[i20, index103].active)
            ++index103;
          int j18 = index103 - 1;
          WorldGen.PlaceTile(i20, j18, 105, true, true, style: style);
          if (Main.tile[i20, j18].active && Main.tile[i20, j18].type == (byte) 105)
          {
            flag14 = true;
            ++style;
          }
          else
          {
            ++num114;
            if (num114 >= 10000)
              flag14 = true;
          }
        }
      }
      for (int index104 = 0; index104 < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 1.6E-05); ++index104)
      {
        float num115 = (float) index104 / ((float) (Main.maxTilesX * Main.maxTilesY) * 1.6E-05f);
        Main.statusText = Lang.gen[30] + " " + (object) (int) ((double) num115 * 100.0 + 1.0) + "%";
        bool flag15 = false;
        int num116 = 0;
        while (!flag15)
        {
          int i21 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
          int j19 = WorldGen.genRand.Next((int) (num6 + 20.0), Main.maxTilesY - 230);
          if ((double) index104 <= 3.0 * (double) num110)
            j19 = WorldGen.genRand.Next(Main.maxTilesY - 200, Main.maxTilesY - 50);
          while (Main.tile[i21, j19].wall == (byte) 7 || Main.tile[i21, j19].wall == (byte) 8 || Main.tile[i21, j19].wall == (byte) 9)
          {
            i21 = WorldGen.genRand.Next(1, Main.maxTilesX);
            j19 = WorldGen.genRand.Next((int) (num6 + 20.0), Main.maxTilesY - 230);
            if (index104 <= 3)
              j19 = WorldGen.genRand.Next(Main.maxTilesY - 200, Main.maxTilesY - 50);
          }
          if (WorldGen.AddBuriedChest(i21, j19))
          {
            flag15 = true;
            if (WorldGen.genRand.Next(2) == 0)
            {
              int j20 = j19;
              while (Main.tile[i21, j20].type != (byte) 21 && j20 < Main.maxTilesY - 300)
                ++j20;
              if (j19 < Main.maxTilesY - 300)
                WorldGen.MineHouse(i21, j20);
            }
          }
          else
          {
            ++num116;
            if (num116 >= 5000)
              flag15 = true;
          }
        }
      }
      for (int index105 = 0; index105 < (int) ((double) Main.maxTilesX * 0.005); ++index105)
      {
        float num117 = (float) index105 / ((float) Main.maxTilesX * 0.005f);
        Main.statusText = Lang.gen[31] + " " + (object) (int) ((double) num117 * 100.0 + 1.0) + "%";
        bool flag16 = false;
        int num118 = 0;
        while (!flag16)
        {
          int i22 = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
          int j21 = WorldGen.genRand.Next((int) num5, (int) Main.worldSurface);
          bool flag17 = false;
          if (Main.tile[i22, j21].wall == (byte) 2 && !Main.tile[i22, j21].active)
            flag17 = true;
          if (flag17 && WorldGen.AddBuriedChest(i22, j21, notNearOtherChests: true))
          {
            flag16 = true;
          }
          else
          {
            ++num118;
            if (num118 >= 2000)
              flag16 = true;
          }
        }
      }
      int num119 = 0;
      for (int index106 = 0; index106 < WorldGen.numJChests; ++index106)
      {
        float num120 = (float) (index106 / WorldGen.numJChests);
        Main.statusText = Lang.gen[32] + " " + (object) (int) ((double) num120 * 100.0 + 1.0) + "%";
        ++num119;
        int contain = 211;
        switch (num119)
        {
          case 1:
            contain = 211;
            break;
          case 2:
            contain = 212;
            break;
          case 3:
            contain = 213;
            break;
        }
        if (num119 > 3)
          num119 = 0;
        if (!WorldGen.AddBuriedChest(WorldGen.JChestX[index106] + WorldGen.genRand.Next(2), WorldGen.JChestY[index106], contain))
        {
          for (int i23 = WorldGen.JChestX[index106]; i23 <= WorldGen.JChestX[index106] + 1; ++i23)
          {
            for (int j22 = WorldGen.JChestY[index106]; j22 <= WorldGen.JChestY[index106] + 1; ++j22)
              WorldGen.KillTile(i23, j22);
          }
          WorldGen.AddBuriedChest(WorldGen.JChestX[index106], WorldGen.JChestY[index106], contain);
        }
      }
      int num121 = 0;
      for (int index107 = 0; (double) index107 < 9.0 * (double) num110; ++index107)
      {
        float num122 = (float) index107 / (9f * num110);
        Main.statusText = Lang.gen[33] + " " + (object) (int) ((double) num122 * 100.0 + 1.0) + "%";
        ++num121;
        int contain;
        switch (num121)
        {
          case 1:
            contain = 186;
            break;
          case 2:
            contain = 277;
            break;
          default:
            contain = 187;
            num121 = 0;
            break;
        }
        int i24;
        int j23;
        for (bool flag18 = false; !flag18; flag18 = WorldGen.AddBuriedChest(i24, j23, contain))
        {
          i24 = WorldGen.genRand.Next(1, Main.maxTilesX);
          for (j23 = WorldGen.genRand.Next(1, Main.maxTilesY - 200); Main.tile[i24, j23].liquid < (byte) 200 || Main.tile[i24, j23].lava; j23 = WorldGen.genRand.Next(1, Main.maxTilesY - 200))
            i24 = WorldGen.genRand.Next(1, Main.maxTilesX);
        }
      }
      for (int index108 = 0; index108 < WorldGen.numIslandHouses; ++index108)
        WorldGen.IslandHouse(WorldGen.fihX[index108], WorldGen.fihY[index108]);
      for (int index109 = 0; index109 < (int) ((double) Main.maxTilesX * 0.05); ++index109)
      {
        float num123 = (float) index109 / ((float) Main.maxTilesX * 0.05f);
        Main.statusText = Lang.gen[34] + " " + (object) (int) ((double) num123 * 100.0 + 1.0) + "%";
        for (int index110 = 0; index110 < 1000; ++index110)
        {
          int x2 = Main.rand.Next(200, Main.maxTilesX - 200);
          int y2 = Main.rand.Next((int) Main.worldSurface, Main.maxTilesY - 300);
          if (Main.tile[x2, y2].wall == (byte) 0 && WorldGen.placeTrap(x2, y2))
            break;
        }
      }
      for (int index111 = 0; index111 < (int) ((double) (Main.maxTilesX * Main.maxTilesY) * 0.0008); ++index111)
      {
        float num124 = (float) index111 / ((float) (Main.maxTilesX * Main.maxTilesY) * 0.0008f);
        Main.statusText = Lang.gen[35] + " " + (object) (int) ((double) num124 * 100.0 + 1.0) + "%";
        bool flag19 = false;
        int num125 = 0;
        while (!flag19)
        {
          int num126 = WorldGen.genRand.Next((int) num6, Main.maxTilesY - 10);
          if ((double) num124 > 0.93)
            num126 = Main.maxTilesY - 150;
          else if ((double) num124 > 0.75)
            num126 = (int) num5;
          int x3 = WorldGen.genRand.Next(1, Main.maxTilesX);
          bool flag20 = false;
          for (int y3 = num126; y3 < Main.maxTilesY; ++y3)
          {
            if (!flag20)
            {
              if (Main.tile[x3, y3].active && Main.tileSolid[(int) Main.tile[x3, y3].type] && !Main.tile[x3, y3 - 1].lava)
                flag20 = true;
            }
            else
            {
              if (WorldGen.PlacePot(x3, y3))
              {
                flag19 = true;
                break;
              }
              ++num125;
              if (num125 >= 10000)
              {
                flag19 = true;
                break;
              }
            }
          }
        }
      }
      for (int index112 = 0; index112 < Main.maxTilesX / 200; ++index112)
      {
        float num127 = (float) (index112 / (Main.maxTilesX / 200));
        Main.statusText = Lang.gen[36] + " " + (object) (int) ((double) num127 * 100.0 + 1.0) + "%";
        bool flag21 = false;
        int num128 = 0;
        while (!flag21)
        {
          int i25 = WorldGen.genRand.Next(1, Main.maxTilesX);
          int index113 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 5);
          try
          {
            if (Main.tile[i25, index113].wall != (byte) 13)
            {
              if (Main.tile[i25, index113].wall != (byte) 14)
                continue;
            }
            while (!Main.tile[i25, index113].active)
              ++index113;
            int j24 = index113 - 1;
            WorldGen.PlaceTile(i25, j24, 77);
            if (Main.tile[i25, j24].type == (byte) 77)
            {
              flag21 = true;
            }
            else
            {
              ++num128;
              if (num128 >= 10000)
                flag21 = true;
            }
          }
          catch
          {
          }
        }
      }
      Main.statusText = Lang.gen[37];
      for (int index114 = 0; index114 < Main.maxTilesX; ++index114)
      {
        int i26 = index114;
        bool flag22 = true;
        for (int j25 = 0; (double) j25 < Main.worldSurface - 1.0; ++j25)
        {
          if (Main.tile[i26, j25].active)
          {
            if (flag22)
            {
              if (Main.tile[i26, j25].type == (byte) 0)
              {
                try
                {
                  WorldGen.grassSpread = 0;
                  WorldGen.SpreadGrass(i26, j25);
                }
                catch
                {
                  WorldGen.grassSpread = 0;
                  WorldGen.SpreadGrass(i26, j25, repeat: false);
                }
              }
            }
            if ((double) j25 <= num6)
              flag22 = false;
            else
              break;
          }
          else if (Main.tile[i26, j25].wall == (byte) 0)
            flag22 = true;
        }
      }
      Main.statusText = Lang.gen[38];
      for (int i27 = 5; i27 < Main.maxTilesX - 5; ++i27)
      {
        if (WorldGen.genRand.Next(8) == 0)
        {
          for (int j26 = 0; (double) j26 < Main.worldSurface - 1.0; ++j26)
          {
            if (Main.tile[i27, j26].active && Main.tile[i27, j26].type == (byte) 53 && !Main.tile[i27, j26 - 1].active && Main.tile[i27, j26 - 1].wall == (byte) 0)
            {
              if (i27 < 250 || i27 > Main.maxTilesX - 250)
              {
                if (Main.tile[i27, j26 - 2].liquid == byte.MaxValue && Main.tile[i27, j26 - 3].liquid == byte.MaxValue && Main.tile[i27, j26 - 4].liquid == byte.MaxValue)
                  WorldGen.PlaceTile(i27, j26 - 1, 81, true);
              }
              else if (i27 > 400 && i27 < Main.maxTilesX - 400)
                WorldGen.PlantCactus(i27, j26);
            }
          }
        }
      }
      int num129 = 5;
      bool flag23 = true;
      while (flag23)
      {
        int index115 = Main.maxTilesX / 2 + WorldGen.genRand.Next(-num129, num129 + 1);
        for (int index116 = 0; index116 < Main.maxTilesY; ++index116)
        {
          if (Main.tile[index115, index116].active)
          {
            Main.spawnTileX = index115;
            Main.spawnTileY = index116;
            break;
          }
        }
        flag23 = false;
        ++num129;
        if ((double) Main.spawnTileY > Main.worldSurface)
          flag23 = true;
        if (Main.tile[Main.spawnTileX, Main.spawnTileY - 1].liquid > (byte) 0)
          flag23 = true;
      }
      int num130 = 10;
      while ((double) Main.spawnTileY > Main.worldSurface)
      {
        int index117 = WorldGen.genRand.Next(Main.maxTilesX / 2 - num130, Main.maxTilesX / 2 + num130);
        for (int index118 = 0; index118 < Main.maxTilesY; ++index118)
        {
          if (Main.tile[index117, index118].active)
          {
            Main.spawnTileX = index117;
            Main.spawnTileY = index118;
            break;
          }
        }
        ++num130;
      }
      int index119 = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, 22);
      Main.npc[index119].homeTileX = Main.spawnTileX;
      Main.npc[index119].homeTileY = Main.spawnTileY;
      Main.npc[index119].direction = 1;
      Main.npc[index119].homeless = true;
      Main.statusText = Lang.gen[39];
      for (int index120 = 0; (double) index120 < (double) Main.maxTilesX * 0.002; ++index120)
      {
        int num131 = Main.maxTilesX / 2;
        int num132 = WorldGen.genRand.Next(Main.maxTilesX);
        int num133 = num132 - WorldGen.genRand.Next(10) - 7;
        int num134 = num132 + WorldGen.genRand.Next(10) + 7;
        if (num133 < 0)
          num133 = 0;
        if (num134 > Main.maxTilesX - 1)
          num134 = Main.maxTilesX - 1;
        for (int i28 = num133; i28 < num134; ++i28)
        {
          for (int index121 = 1; (double) index121 < Main.worldSurface - 1.0; ++index121)
          {
            if (Main.tile[i28, index121].type == (byte) 2 && Main.tile[i28, index121].active && !Main.tile[i28, index121 - 1].active)
              WorldGen.PlaceTile(i28, index121 - 1, 27, true);
            if (Main.tile[i28, index121].active)
              break;
          }
        }
      }
      Main.statusText = Lang.gen[40];
      for (int index122 = 0; (double) index122 < (double) Main.maxTilesX * 0.003; ++index122)
      {
        int num135 = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
        int num136 = WorldGen.genRand.Next(25, 50);
        for (int i29 = num135 - num136; i29 < num135 + num136; ++i29)
        {
          for (int y4 = 20; (double) y4 < Main.worldSurface; ++y4)
            WorldGen.GrowEpicTree(i29, y4);
        }
      }
      WorldGen.AddTrees();
      Main.statusText = Lang.gen[41];
      for (int index123 = 0; (double) index123 < (double) Main.maxTilesX * 1.7; ++index123)
        WorldGen.PlantAlch();
      Main.statusText = Lang.gen[42];
      WorldGen.AddPlants();
      for (int i30 = 0; i30 < Main.maxTilesX; ++i30)
      {
        for (int y5 = 0; y5 < Main.maxTilesY; ++y5)
        {
          if (Main.tile[i30, y5].active)
          {
            if (y5 >= (int) Main.worldSurface && Main.tile[i30, y5].type == (byte) 70 && !Main.tile[i30, y5 - 1].active)
            {
              WorldGen.GrowShroom(i30, y5);
              if (!Main.tile[i30, y5 - 1].active)
                WorldGen.PlaceTile(i30, y5 - 1, 71, true);
            }
            if (Main.tile[i30, y5].type == (byte) 60 && !Main.tile[i30, y5 - 1].active)
              WorldGen.PlaceTile(i30, y5 - 1, 61, true);
          }
        }
      }
      Main.statusText = Lang.gen[43];
      for (int index124 = 0; index124 < Main.maxTilesX; ++index124)
      {
        int num137 = 0;
        for (int index125 = 0; (double) index125 < Main.worldSurface; ++index125)
        {
          if (num137 > 0 && !Main.tile[index124, index125].active)
          {
            Main.tile[index124, index125].active = true;
            Main.tile[index124, index125].type = (byte) 52;
            --num137;
          }
          else
            num137 = 0;
          if (Main.tile[index124, index125].active && Main.tile[index124, index125].type == (byte) 2 && WorldGen.genRand.Next(5) < 3)
            num137 = WorldGen.genRand.Next(1, 10);
        }
        int num138 = 0;
        for (int index126 = 0; index126 < Main.maxTilesY; ++index126)
        {
          if (num138 > 0 && !Main.tile[index124, index126].active)
          {
            Main.tile[index124, index126].active = true;
            Main.tile[index124, index126].type = (byte) 62;
            --num138;
          }
          else
            num138 = 0;
          if (Main.tile[index124, index126].active && Main.tile[index124, index126].type == (byte) 60 && WorldGen.genRand.Next(5) < 3)
            num138 = WorldGen.genRand.Next(1, 10);
        }
      }
      Main.statusText = Lang.gen[44];
      for (int index127 = 0; (double) index127 < (double) Main.maxTilesX * 0.005; ++index127)
      {
        int index128 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
        int num139 = WorldGen.genRand.Next(5, 15);
        int num140 = WorldGen.genRand.Next(15, 30);
        for (int index129 = 1; (double) index129 < Main.worldSurface - 1.0; ++index129)
        {
          if (Main.tile[index128, index129].active)
          {
            for (int index130 = index128 - num139; index130 < index128 + num139; ++index130)
            {
              for (int index131 = index129 - num140; index131 < index129 + num140; ++index131)
              {
                if (Main.tile[index130, index131].type == (byte) 3 || Main.tile[index130, index131].type == (byte) 24)
                  Main.tile[index130, index131].frameX = (short) (WorldGen.genRand.Next(6, 8) * 18);
              }
            }
            break;
          }
        }
      }
      Main.statusText = Lang.gen[45];
      for (int index132 = 0; (double) index132 < (double) Main.maxTilesX * 0.002; ++index132)
      {
        int index133 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
        int num141 = WorldGen.genRand.Next(4, 10);
        int num142 = WorldGen.genRand.Next(15, 30);
        for (int index134 = 1; (double) index134 < Main.worldSurface - 1.0; ++index134)
        {
          if (Main.tile[index133, index134].active)
          {
            for (int index135 = index133 - num141; index135 < index133 + num141; ++index135)
            {
              for (int index136 = index134 - num142; index136 < index134 + num142; ++index136)
              {
                if (Main.tile[index135, index136].type == (byte) 3 || Main.tile[index135, index136].type == (byte) 24)
                  Main.tile[index135, index136].frameX = (short) 144;
              }
            }
            break;
          }
        }
      }
      WorldGen.gen = false;
    }

    public static bool GrowEpicTree(int i, int y)
    {
      int index1 = y;
      while (Main.tile[i, index1].type == (byte) 20)
        ++index1;
      if (Main.tile[i, index1].active && Main.tile[i, index1].type == (byte) 2 && Main.tile[i, index1 - 1].wall == (byte) 0 && Main.tile[i, index1 - 1].liquid == (byte) 0 && (Main.tile[i - 1, index1].active && (Main.tile[i - 1, index1].type == (byte) 2 || Main.tile[i - 1, index1].type == (byte) 23 || Main.tile[i - 1, index1].type == (byte) 60 || Main.tile[i - 1, index1].type == (byte) 109) || Main.tile[i + 1, index1].active && (Main.tile[i + 1, index1].type == (byte) 2 || Main.tile[i + 1, index1].type == (byte) 23 || Main.tile[i + 1, index1].type == (byte) 60 || Main.tile[i + 1, index1].type == (byte) 109)))
      {
        int num1 = 1;
        if (WorldGen.EmptyTileCheck(i - num1, i + num1, index1 - 55, index1 - 1, 20))
        {
          bool flag1 = false;
          bool flag2 = false;
          int num2 = WorldGen.genRand.Next(20, 30);
          for (int index2 = index1 - num2; index2 < index1; ++index2)
          {
            Main.tile[i, index2].frameNumber = (byte) WorldGen.genRand.Next(3);
            Main.tile[i, index2].active = true;
            Main.tile[i, index2].type = (byte) 5;
            int num3 = WorldGen.genRand.Next(3);
            int num4 = WorldGen.genRand.Next(10);
            if (index2 == index1 - 1 || index2 == index1 - num2)
              num4 = 0;
            while ((num4 == 5 || num4 == 7) && flag1 || (num4 == 6 || num4 == 7) && flag2)
              num4 = WorldGen.genRand.Next(10);
            flag1 = false;
            flag2 = false;
            if (num4 == 5 || num4 == 7)
              flag1 = true;
            if (num4 == 6 || num4 == 7)
              flag2 = true;
            switch (num4)
            {
              case 1:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 0;
                  Main.tile[i, index2].frameY = (short) 66;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 0;
                  Main.tile[i, index2].frameY = (short) 88;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 0;
                  Main.tile[i, index2].frameY = (short) 110;
                  break;
                }
                break;
              case 2:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 22;
                  Main.tile[i, index2].frameY = (short) 0;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 22;
                  Main.tile[i, index2].frameY = (short) 22;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 22;
                  Main.tile[i, index2].frameY = (short) 44;
                  break;
                }
                break;
              case 3:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 44;
                  Main.tile[i, index2].frameY = (short) 66;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 44;
                  Main.tile[i, index2].frameY = (short) 88;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 44;
                  Main.tile[i, index2].frameY = (short) 110;
                  break;
                }
                break;
              case 4:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 22;
                  Main.tile[i, index2].frameY = (short) 66;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 22;
                  Main.tile[i, index2].frameY = (short) 88;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 22;
                  Main.tile[i, index2].frameY = (short) 110;
                  break;
                }
                break;
              case 5:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 88;
                  Main.tile[i, index2].frameY = (short) 0;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 88;
                  Main.tile[i, index2].frameY = (short) 22;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 88;
                  Main.tile[i, index2].frameY = (short) 44;
                  break;
                }
                break;
              case 6:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 66;
                  Main.tile[i, index2].frameY = (short) 66;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 66;
                  Main.tile[i, index2].frameY = (short) 88;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 66;
                  Main.tile[i, index2].frameY = (short) 110;
                  break;
                }
                break;
              case 7:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 110;
                  Main.tile[i, index2].frameY = (short) 66;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 110;
                  Main.tile[i, index2].frameY = (short) 88;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 110;
                  Main.tile[i, index2].frameY = (short) 110;
                  break;
                }
                break;
              default:
                if (num3 == 0)
                {
                  Main.tile[i, index2].frameX = (short) 0;
                  Main.tile[i, index2].frameY = (short) 0;
                }
                if (num3 == 1)
                {
                  Main.tile[i, index2].frameX = (short) 0;
                  Main.tile[i, index2].frameY = (short) 22;
                }
                if (num3 == 2)
                {
                  Main.tile[i, index2].frameX = (short) 0;
                  Main.tile[i, index2].frameY = (short) 44;
                  break;
                }
                break;
            }
            if (num4 == 5 || num4 == 7)
            {
              Main.tile[i - 1, index2].active = true;
              Main.tile[i - 1, index2].type = (byte) 5;
              int num5 = WorldGen.genRand.Next(3);
              if (WorldGen.genRand.Next(3) < 2)
              {
                if (num5 == 0)
                {
                  Main.tile[i - 1, index2].frameX = (short) 44;
                  Main.tile[i - 1, index2].frameY = (short) 198;
                }
                if (num5 == 1)
                {
                  Main.tile[i - 1, index2].frameX = (short) 44;
                  Main.tile[i - 1, index2].frameY = (short) 220;
                }
                if (num5 == 2)
                {
                  Main.tile[i - 1, index2].frameX = (short) 44;
                  Main.tile[i - 1, index2].frameY = (short) 242;
                }
              }
              else
              {
                if (num5 == 0)
                {
                  Main.tile[i - 1, index2].frameX = (short) 66;
                  Main.tile[i - 1, index2].frameY = (short) 0;
                }
                if (num5 == 1)
                {
                  Main.tile[i - 1, index2].frameX = (short) 66;
                  Main.tile[i - 1, index2].frameY = (short) 22;
                }
                if (num5 == 2)
                {
                  Main.tile[i - 1, index2].frameX = (short) 66;
                  Main.tile[i - 1, index2].frameY = (short) 44;
                }
              }
            }
            if (num4 == 6 || num4 == 7)
            {
              Main.tile[i + 1, index2].active = true;
              Main.tile[i + 1, index2].type = (byte) 5;
              int num6 = WorldGen.genRand.Next(3);
              if (WorldGen.genRand.Next(3) < 2)
              {
                if (num6 == 0)
                {
                  Main.tile[i + 1, index2].frameX = (short) 66;
                  Main.tile[i + 1, index2].frameY = (short) 198;
                }
                if (num6 == 1)
                {
                  Main.tile[i + 1, index2].frameX = (short) 66;
                  Main.tile[i + 1, index2].frameY = (short) 220;
                }
                if (num6 == 2)
                {
                  Main.tile[i + 1, index2].frameX = (short) 66;
                  Main.tile[i + 1, index2].frameY = (short) 242;
                }
              }
              else
              {
                if (num6 == 0)
                {
                  Main.tile[i + 1, index2].frameX = (short) 88;
                  Main.tile[i + 1, index2].frameY = (short) 66;
                }
                if (num6 == 1)
                {
                  Main.tile[i + 1, index2].frameX = (short) 88;
                  Main.tile[i + 1, index2].frameY = (short) 88;
                }
                if (num6 == 2)
                {
                  Main.tile[i + 1, index2].frameX = (short) 88;
                  Main.tile[i + 1, index2].frameY = (short) 110;
                }
              }
            }
          }
          int num7 = WorldGen.genRand.Next(3);
          bool flag3 = false;
          bool flag4 = false;
          if (Main.tile[i - 1, index1].active && (Main.tile[i - 1, index1].type == (byte) 2 || Main.tile[i - 1, index1].type == (byte) 23 || Main.tile[i - 1, index1].type == (byte) 60 || Main.tile[i - 1, index1].type == (byte) 109))
            flag3 = true;
          if (Main.tile[i + 1, index1].active && (Main.tile[i + 1, index1].type == (byte) 2 || Main.tile[i + 1, index1].type == (byte) 23 || Main.tile[i + 1, index1].type == (byte) 60 || Main.tile[i + 1, index1].type == (byte) 109))
            flag4 = true;
          if (!flag3)
          {
            if (num7 == 0)
              num7 = 2;
            if (num7 == 1)
              num7 = 3;
          }
          if (!flag4)
          {
            if (num7 == 0)
              num7 = 1;
            if (num7 == 2)
              num7 = 3;
          }
          if (flag3 && !flag4)
            num7 = 1;
          if (flag4 && !flag3)
            num7 = 2;
          if (num7 == 0 || num7 == 1)
          {
            Main.tile[i + 1, index1 - 1].active = true;
            Main.tile[i + 1, index1 - 1].type = (byte) 5;
            int num8 = WorldGen.genRand.Next(3);
            if (num8 == 0)
            {
              Main.tile[i + 1, index1 - 1].frameX = (short) 22;
              Main.tile[i + 1, index1 - 1].frameY = (short) 132;
            }
            if (num8 == 1)
            {
              Main.tile[i + 1, index1 - 1].frameX = (short) 22;
              Main.tile[i + 1, index1 - 1].frameY = (short) 154;
            }
            if (num8 == 2)
            {
              Main.tile[i + 1, index1 - 1].frameX = (short) 22;
              Main.tile[i + 1, index1 - 1].frameY = (short) 176;
            }
          }
          if (num7 == 0 || num7 == 2)
          {
            Main.tile[i - 1, index1 - 1].active = true;
            Main.tile[i - 1, index1 - 1].type = (byte) 5;
            int num9 = WorldGen.genRand.Next(3);
            if (num9 == 0)
            {
              Main.tile[i - 1, index1 - 1].frameX = (short) 44;
              Main.tile[i - 1, index1 - 1].frameY = (short) 132;
            }
            if (num9 == 1)
            {
              Main.tile[i - 1, index1 - 1].frameX = (short) 44;
              Main.tile[i - 1, index1 - 1].frameY = (short) 154;
            }
            if (num9 == 2)
            {
              Main.tile[i - 1, index1 - 1].frameX = (short) 44;
              Main.tile[i - 1, index1 - 1].frameY = (short) 176;
            }
          }
          int num10 = WorldGen.genRand.Next(3);
          switch (num7)
          {
            case 0:
              if (num10 == 0)
              {
                Main.tile[i, index1 - 1].frameX = (short) 88;
                Main.tile[i, index1 - 1].frameY = (short) 132;
              }
              if (num10 == 1)
              {
                Main.tile[i, index1 - 1].frameX = (short) 88;
                Main.tile[i, index1 - 1].frameY = (short) 154;
              }
              if (num10 == 2)
              {
                Main.tile[i, index1 - 1].frameX = (short) 88;
                Main.tile[i, index1 - 1].frameY = (short) 176;
                break;
              }
              break;
            case 1:
              if (num10 == 0)
              {
                Main.tile[i, index1 - 1].frameX = (short) 0;
                Main.tile[i, index1 - 1].frameY = (short) 132;
              }
              if (num10 == 1)
              {
                Main.tile[i, index1 - 1].frameX = (short) 0;
                Main.tile[i, index1 - 1].frameY = (short) 154;
              }
              if (num10 == 2)
              {
                Main.tile[i, index1 - 1].frameX = (short) 0;
                Main.tile[i, index1 - 1].frameY = (short) 176;
                break;
              }
              break;
            case 2:
              if (num10 == 0)
              {
                Main.tile[i, index1 - 1].frameX = (short) 66;
                Main.tile[i, index1 - 1].frameY = (short) 132;
              }
              if (num10 == 1)
              {
                Main.tile[i, index1 - 1].frameX = (short) 66;
                Main.tile[i, index1 - 1].frameY = (short) 154;
              }
              if (num10 == 2)
              {
                Main.tile[i, index1 - 1].frameX = (short) 66;
                Main.tile[i, index1 - 1].frameY = (short) 176;
                break;
              }
              break;
          }
          if (WorldGen.genRand.Next(3) < 2)
          {
            int num11 = WorldGen.genRand.Next(3);
            if (num11 == 0)
            {
              Main.tile[i, index1 - num2].frameX = (short) 22;
              Main.tile[i, index1 - num2].frameY = (short) 198;
            }
            if (num11 == 1)
            {
              Main.tile[i, index1 - num2].frameX = (short) 22;
              Main.tile[i, index1 - num2].frameY = (short) 220;
            }
            if (num11 == 2)
            {
              Main.tile[i, index1 - num2].frameX = (short) 22;
              Main.tile[i, index1 - num2].frameY = (short) 242;
            }
          }
          else
          {
            int num12 = WorldGen.genRand.Next(3);
            if (num12 == 0)
            {
              Main.tile[i, index1 - num2].frameX = (short) 0;
              Main.tile[i, index1 - num2].frameY = (short) 198;
            }
            if (num12 == 1)
            {
              Main.tile[i, index1 - num2].frameX = (short) 0;
              Main.tile[i, index1 - num2].frameY = (short) 220;
            }
            if (num12 == 2)
            {
              Main.tile[i, index1 - num2].frameX = (short) 0;
              Main.tile[i, index1 - num2].frameY = (short) 242;
            }
          }
          WorldGen.RangeFrame(i - 2, index1 - num2 - 1, i + 2, index1 + 1);
          if (Main.netMode == 2)
            NetMessage.SendTileSquare(-1, i, (int) ((double) index1 - (double) num2 * 0.5), num2 + 1);
          return true;
        }
      }
      return false;
    }

    public static void GrowTree(int i, int y)
    {
      int index1 = y;
      while (Main.tile[i, index1].type == (byte) 20)
        ++index1;
      if ((Main.tile[i - 1, index1 - 1].liquid != (byte) 0 || Main.tile[i - 1, index1 - 1].liquid != (byte) 0 || Main.tile[i + 1, index1 - 1].liquid != (byte) 0) && Main.tile[i, index1].type != (byte) 60 || !Main.tile[i, index1].active || Main.tile[i, index1].type != (byte) 2 && Main.tile[i, index1].type != (byte) 23 && Main.tile[i, index1].type != (byte) 60 && Main.tile[i, index1].type != (byte) 109 && Main.tile[i, index1].type != (byte) 147 || Main.tile[i, index1 - 1].wall != (byte) 0 || (!Main.tile[i - 1, index1].active || Main.tile[i - 1, index1].type != (byte) 2 && Main.tile[i - 1, index1].type != (byte) 23 && Main.tile[i - 1, index1].type != (byte) 60 && Main.tile[i - 1, index1].type != (byte) 109 && Main.tile[i - 1, index1].type != (byte) 147) && (!Main.tile[i + 1, index1].active || Main.tile[i + 1, index1].type != (byte) 2 && Main.tile[i + 1, index1].type != (byte) 23 && Main.tile[i + 1, index1].type != (byte) 60 && Main.tile[i + 1, index1].type != (byte) 109 && Main.tile[i + 1, index1].type != (byte) 147))
        return;
      int num1 = 1;
      int num2 = 16;
      if (Main.tile[i, index1].type == (byte) 60)
        num2 += 5;
      if (!WorldGen.EmptyTileCheck(i - num1, i + num1, index1 - num2, index1 - 1, 20))
        return;
      bool flag1 = false;
      bool flag2 = false;
      int num3 = WorldGen.genRand.Next(5, num2 + 1);
      for (int index2 = index1 - num3; index2 < index1; ++index2)
      {
        Main.tile[i, index2].frameNumber = (byte) WorldGen.genRand.Next(3);
        Main.tile[i, index2].active = true;
        Main.tile[i, index2].type = (byte) 5;
        int num4 = WorldGen.genRand.Next(3);
        int num5 = WorldGen.genRand.Next(10);
        if (index2 == index1 - 1 || index2 == index1 - num3)
          num5 = 0;
        while ((num5 == 5 || num5 == 7) && flag1 || (num5 == 6 || num5 == 7) && flag2)
          num5 = WorldGen.genRand.Next(10);
        flag1 = false;
        flag2 = false;
        if (num5 == 5 || num5 == 7)
          flag1 = true;
        if (num5 == 6 || num5 == 7)
          flag2 = true;
        switch (num5)
        {
          case 1:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 0;
              Main.tile[i, index2].frameY = (short) 66;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 0;
              Main.tile[i, index2].frameY = (short) 88;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 0;
              Main.tile[i, index2].frameY = (short) 110;
              break;
            }
            break;
          case 2:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 22;
              Main.tile[i, index2].frameY = (short) 0;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 22;
              Main.tile[i, index2].frameY = (short) 22;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 22;
              Main.tile[i, index2].frameY = (short) 44;
              break;
            }
            break;
          case 3:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 44;
              Main.tile[i, index2].frameY = (short) 66;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 44;
              Main.tile[i, index2].frameY = (short) 88;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 44;
              Main.tile[i, index2].frameY = (short) 110;
              break;
            }
            break;
          case 4:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 22;
              Main.tile[i, index2].frameY = (short) 66;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 22;
              Main.tile[i, index2].frameY = (short) 88;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 22;
              Main.tile[i, index2].frameY = (short) 110;
              break;
            }
            break;
          case 5:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 88;
              Main.tile[i, index2].frameY = (short) 0;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 88;
              Main.tile[i, index2].frameY = (short) 22;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 88;
              Main.tile[i, index2].frameY = (short) 44;
              break;
            }
            break;
          case 6:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 66;
              Main.tile[i, index2].frameY = (short) 66;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 66;
              Main.tile[i, index2].frameY = (short) 88;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 66;
              Main.tile[i, index2].frameY = (short) 110;
              break;
            }
            break;
          case 7:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 110;
              Main.tile[i, index2].frameY = (short) 66;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 110;
              Main.tile[i, index2].frameY = (short) 88;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 110;
              Main.tile[i, index2].frameY = (short) 110;
              break;
            }
            break;
          default:
            if (num4 == 0)
            {
              Main.tile[i, index2].frameX = (short) 0;
              Main.tile[i, index2].frameY = (short) 0;
            }
            if (num4 == 1)
            {
              Main.tile[i, index2].frameX = (short) 0;
              Main.tile[i, index2].frameY = (short) 22;
            }
            if (num4 == 2)
            {
              Main.tile[i, index2].frameX = (short) 0;
              Main.tile[i, index2].frameY = (short) 44;
              break;
            }
            break;
        }
        if (num5 == 5 || num5 == 7)
        {
          Main.tile[i - 1, index2].active = true;
          Main.tile[i - 1, index2].type = (byte) 5;
          int num6 = WorldGen.genRand.Next(3);
          if (WorldGen.genRand.Next(3) < 2)
          {
            if (num6 == 0)
            {
              Main.tile[i - 1, index2].frameX = (short) 44;
              Main.tile[i - 1, index2].frameY = (short) 198;
            }
            if (num6 == 1)
            {
              Main.tile[i - 1, index2].frameX = (short) 44;
              Main.tile[i - 1, index2].frameY = (short) 220;
            }
            if (num6 == 2)
            {
              Main.tile[i - 1, index2].frameX = (short) 44;
              Main.tile[i - 1, index2].frameY = (short) 242;
            }
          }
          else
          {
            if (num6 == 0)
            {
              Main.tile[i - 1, index2].frameX = (short) 66;
              Main.tile[i - 1, index2].frameY = (short) 0;
            }
            if (num6 == 1)
            {
              Main.tile[i - 1, index2].frameX = (short) 66;
              Main.tile[i - 1, index2].frameY = (short) 22;
            }
            if (num6 == 2)
            {
              Main.tile[i - 1, index2].frameX = (short) 66;
              Main.tile[i - 1, index2].frameY = (short) 44;
            }
          }
        }
        if (num5 == 6 || num5 == 7)
        {
          Main.tile[i + 1, index2].active = true;
          Main.tile[i + 1, index2].type = (byte) 5;
          int num7 = WorldGen.genRand.Next(3);
          if (WorldGen.genRand.Next(3) < 2)
          {
            if (num7 == 0)
            {
              Main.tile[i + 1, index2].frameX = (short) 66;
              Main.tile[i + 1, index2].frameY = (short) 198;
            }
            if (num7 == 1)
            {
              Main.tile[i + 1, index2].frameX = (short) 66;
              Main.tile[i + 1, index2].frameY = (short) 220;
            }
            if (num7 == 2)
            {
              Main.tile[i + 1, index2].frameX = (short) 66;
              Main.tile[i + 1, index2].frameY = (short) 242;
            }
          }
          else
          {
            if (num7 == 0)
            {
              Main.tile[i + 1, index2].frameX = (short) 88;
              Main.tile[i + 1, index2].frameY = (short) 66;
            }
            if (num7 == 1)
            {
              Main.tile[i + 1, index2].frameX = (short) 88;
              Main.tile[i + 1, index2].frameY = (short) 88;
            }
            if (num7 == 2)
            {
              Main.tile[i + 1, index2].frameX = (short) 88;
              Main.tile[i + 1, index2].frameY = (short) 110;
            }
          }
        }
      }
      int num8 = WorldGen.genRand.Next(3);
      bool flag3 = false;
      bool flag4 = false;
      if (Main.tile[i - 1, index1].active && (Main.tile[i - 1, index1].type == (byte) 2 || Main.tile[i - 1, index1].type == (byte) 23 || Main.tile[i - 1, index1].type == (byte) 60 || Main.tile[i - 1, index1].type == (byte) 109 || Main.tile[i - 1, index1].type == (byte) 147))
        flag3 = true;
      if (Main.tile[i + 1, index1].active && (Main.tile[i + 1, index1].type == (byte) 2 || Main.tile[i + 1, index1].type == (byte) 23 || Main.tile[i + 1, index1].type == (byte) 60 || Main.tile[i + 1, index1].type == (byte) 109 || Main.tile[i + 1, index1].type == (byte) 147))
        flag4 = true;
      if (!flag3)
      {
        if (num8 == 0)
          num8 = 2;
        if (num8 == 1)
          num8 = 3;
      }
      if (!flag4)
      {
        if (num8 == 0)
          num8 = 1;
        if (num8 == 2)
          num8 = 3;
      }
      if (flag3 && !flag4)
        num8 = 1;
      if (flag4 && !flag3)
        num8 = 2;
      if (num8 == 0 || num8 == 1)
      {
        Main.tile[i + 1, index1 - 1].active = true;
        Main.tile[i + 1, index1 - 1].type = (byte) 5;
        int num9 = WorldGen.genRand.Next(3);
        if (num9 == 0)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 132;
        }
        if (num9 == 1)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 154;
        }
        if (num9 == 2)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 176;
        }
      }
      if (num8 == 0 || num8 == 2)
      {
        Main.tile[i - 1, index1 - 1].active = true;
        Main.tile[i - 1, index1 - 1].type = (byte) 5;
        int num10 = WorldGen.genRand.Next(3);
        if (num10 == 0)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 132;
        }
        if (num10 == 1)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 154;
        }
        if (num10 == 2)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 176;
        }
      }
      int num11 = WorldGen.genRand.Next(3);
      switch (num8)
      {
        case 0:
          if (num11 == 0)
          {
            Main.tile[i, index1 - 1].frameX = (short) 88;
            Main.tile[i, index1 - 1].frameY = (short) 132;
          }
          if (num11 == 1)
          {
            Main.tile[i, index1 - 1].frameX = (short) 88;
            Main.tile[i, index1 - 1].frameY = (short) 154;
          }
          if (num11 == 2)
          {
            Main.tile[i, index1 - 1].frameX = (short) 88;
            Main.tile[i, index1 - 1].frameY = (short) 176;
            break;
          }
          break;
        case 1:
          if (num11 == 0)
          {
            Main.tile[i, index1 - 1].frameX = (short) 0;
            Main.tile[i, index1 - 1].frameY = (short) 132;
          }
          if (num11 == 1)
          {
            Main.tile[i, index1 - 1].frameX = (short) 0;
            Main.tile[i, index1 - 1].frameY = (short) 154;
          }
          if (num11 == 2)
          {
            Main.tile[i, index1 - 1].frameX = (short) 0;
            Main.tile[i, index1 - 1].frameY = (short) 176;
            break;
          }
          break;
        case 2:
          if (num11 == 0)
          {
            Main.tile[i, index1 - 1].frameX = (short) 66;
            Main.tile[i, index1 - 1].frameY = (short) 132;
          }
          if (num11 == 1)
          {
            Main.tile[i, index1 - 1].frameX = (short) 66;
            Main.tile[i, index1 - 1].frameY = (short) 154;
          }
          if (num11 == 2)
          {
            Main.tile[i, index1 - 1].frameX = (short) 66;
            Main.tile[i, index1 - 1].frameY = (short) 176;
            break;
          }
          break;
      }
      if (WorldGen.genRand.Next(4) < 3)
      {
        int num12 = WorldGen.genRand.Next(3);
        if (num12 == 0)
        {
          Main.tile[i, index1 - num3].frameX = (short) 22;
          Main.tile[i, index1 - num3].frameY = (short) 198;
        }
        if (num12 == 1)
        {
          Main.tile[i, index1 - num3].frameX = (short) 22;
          Main.tile[i, index1 - num3].frameY = (short) 220;
        }
        if (num12 == 2)
        {
          Main.tile[i, index1 - num3].frameX = (short) 22;
          Main.tile[i, index1 - num3].frameY = (short) 242;
        }
      }
      else
      {
        int num13 = WorldGen.genRand.Next(3);
        if (num13 == 0)
        {
          Main.tile[i, index1 - num3].frameX = (short) 0;
          Main.tile[i, index1 - num3].frameY = (short) 198;
        }
        if (num13 == 1)
        {
          Main.tile[i, index1 - num3].frameX = (short) 0;
          Main.tile[i, index1 - num3].frameY = (short) 220;
        }
        if (num13 == 2)
        {
          Main.tile[i, index1 - num3].frameX = (short) 0;
          Main.tile[i, index1 - num3].frameY = (short) 242;
        }
      }
      WorldGen.RangeFrame(i - 2, index1 - num3 - 1, i + 2, index1 + 1);
      if (Main.netMode != 2)
        return;
      NetMessage.SendTileSquare(-1, i, (int) ((double) index1 - (double) num3 * 0.5), num3 + 1);
    }

    public static void GrowShroom(int i, int y)
    {
      int index1 = y;
      if (Main.tile[i - 1, index1 - 1].lava || Main.tile[i - 1, index1 - 1].lava || Main.tile[i + 1, index1 - 1].lava || !Main.tile[i, index1].active || Main.tile[i, index1].type != (byte) 70 || Main.tile[i, index1 - 1].wall != (byte) 0 || !Main.tile[i - 1, index1].active || Main.tile[i - 1, index1].type != (byte) 70 || !Main.tile[i + 1, index1].active || Main.tile[i + 1, index1].type != (byte) 70 || !WorldGen.EmptyTileCheck(i - 2, i + 2, index1 - 13, index1 - 1, 71))
        return;
      int num1 = WorldGen.genRand.Next(4, 11);
      for (int index2 = index1 - num1; index2 < index1; ++index2)
      {
        Main.tile[i, index2].frameNumber = (byte) WorldGen.genRand.Next(3);
        Main.tile[i, index2].active = true;
        Main.tile[i, index2].type = (byte) 72;
        int num2 = WorldGen.genRand.Next(3);
        if (num2 == 0)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) 0;
        }
        if (num2 == 1)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) 18;
        }
        if (num2 == 2)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) 36;
        }
      }
      int num3 = WorldGen.genRand.Next(3);
      if (num3 == 0)
      {
        Main.tile[i, index1 - num1].frameX = (short) 36;
        Main.tile[i, index1 - num1].frameY = (short) 0;
      }
      if (num3 == 1)
      {
        Main.tile[i, index1 - num1].frameX = (short) 36;
        Main.tile[i, index1 - num1].frameY = (short) 18;
      }
      if (num3 == 2)
      {
        Main.tile[i, index1 - num1].frameX = (short) 36;
        Main.tile[i, index1 - num1].frameY = (short) 36;
      }
      WorldGen.RangeFrame(i - 2, index1 - num1 - 1, i + 2, index1 + 1);
      if (Main.netMode != 2)
        return;
      NetMessage.SendTileSquare(-1, i, (int) ((double) index1 - (double) num1 * 0.5), num1 + 1);
    }

    public static void AddTrees()
    {
      for (int i = 1; i < Main.maxTilesX - 1; ++i)
      {
        for (int y = 20; (double) y < Main.worldSurface; ++y)
          WorldGen.GrowTree(i, y);
        if (WorldGen.genRand.Next(3) == 0)
          ++i;
        if (WorldGen.genRand.Next(4) == 0)
          ++i;
      }
    }

    public static bool EmptyTileCheck(
      int startX,
      int endX,
      int startY,
      int endY,
      int ignoreStyle = -1)
    {
      if (startX < 0 || endX >= Main.maxTilesX || startY < 0 || endY >= Main.maxTilesY)
        return false;
      for (int index1 = startX; index1 < endX + 1; ++index1)
      {
        for (int index2 = startY; index2 < endY + 1; ++index2)
        {
          if (Main.tile[index1, index2].active && (ignoreStyle == -1 || ignoreStyle == 11 && Main.tile[index1, index2].type != (byte) 11 || ignoreStyle == 20 && Main.tile[index1, index2].type != (byte) 20 && Main.tile[index1, index2].type != (byte) 3 && Main.tile[index1, index2].type != (byte) 24 && Main.tile[index1, index2].type != (byte) 61 && Main.tile[index1, index2].type != (byte) 32 && Main.tile[index1, index2].type != (byte) 69 && Main.tile[index1, index2].type != (byte) 73 && Main.tile[index1, index2].type != (byte) 74 && Main.tile[index1, index2].type != (byte) 110 && Main.tile[index1, index2].type != (byte) 113 || ignoreStyle == 71 && Main.tile[index1, index2].type != (byte) 71))
            return false;
        }
      }
      return true;
    }

    public static void smCallBack(object threadContext)
    {
      if (Main.hardMode)
        return;
      WorldGen.hardLock = true;
      Main.hardMode = true;
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
      float num1 = (float) WorldGen.genRand.Next(300, 400) * (1f / 1000f);
      int i1 = (int) ((double) Main.maxTilesX * (double) num1);
      int i2 = (int) ((double) Main.maxTilesX * (1.0 - (double) num1));
      int num2 = 1;
      if (WorldGen.genRand.Next(2) == 0)
      {
        i2 = (int) ((double) Main.maxTilesX * (double) num1);
        i1 = (int) ((double) Main.maxTilesX * (1.0 - (double) num1));
        num2 = -1;
      }
      WorldGen.GERunner(i1, 0, (float) (3 * num2), 5f);
      WorldGen.GERunner(i2, 0, (float) (3 * -num2), 5f, false);
      if (Main.netMode == 0)
        Main.NewText(Lang.misc[15], (byte) 50, B: (byte) 130);
      else if (Main.netMode == 2)
        NetMessage.SendData(25, text: Lang.misc[15], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
      if (Main.netMode == 2)
        Netplay.ResetSections();
      WorldGen.hardLock = false;
    }

    public static void StartHardmode()
    {
      if (Main.netMode == 1)
        return;
      ThreadPool.QueueUserWorkItem(new WaitCallback(WorldGen.smCallBack), (object) 1);
    }

    public static bool PlaceDoor(int i, int j, int type)
    {
      try
      {
        if (!Main.tile[i, j - 2].active || !Main.tileSolid[(int) Main.tile[i, j - 2].type] || !Main.tile[i, j + 2].active || !Main.tileSolid[(int) Main.tile[i, j + 2].type])
          return false;
        Main.tile[i, j - 1].active = true;
        Main.tile[i, j - 1].type = (byte) 10;
        Main.tile[i, j - 1].frameY = (short) 0;
        Main.tile[i, j - 1].frameX = (short) (WorldGen.genRand.Next(3) * 18);
        Main.tile[i, j].active = true;
        Main.tile[i, j].type = (byte) 10;
        Main.tile[i, j].frameY = (short) 18;
        Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(3) * 18);
        Main.tile[i, j + 1].active = true;
        Main.tile[i, j + 1].type = (byte) 10;
        Main.tile[i, j + 1].frameY = (short) 36;
        Main.tile[i, j + 1].frameX = (short) (WorldGen.genRand.Next(3) * 18);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static bool CloseDoor(int i, int j, bool forced = false)
    {
      int num1 = 0;
      int i1 = i;
      int num2 = j;
      if (Main.tile[i, j] == null)
        Main.tile[i, j] = new Tile();
      int frameX = (int) Main.tile[i, j].frameX;
      int frameY = (int) Main.tile[i, j].frameY;
      switch (frameX)
      {
        case 0:
          i1 = i;
          num1 = 1;
          break;
        case 18:
          i1 = i - 1;
          num1 = 1;
          break;
        case 36:
          i1 = i + 1;
          num1 = -1;
          break;
        case 54:
          i1 = i;
          num1 = -1;
          break;
      }
      switch (frameY)
      {
        case 0:
          num2 = j;
          break;
        case 18:
          num2 = j - 1;
          break;
        case 36:
          num2 = j - 2;
          break;
      }
      int num3 = i1;
      if (num1 == -1)
        num3 = i1 - 1;
      if (!forced)
      {
        for (int j1 = num2; j1 < num2 + 3; ++j1)
        {
          if (!Collision.EmptyTile(i1, j1, true))
            return false;
        }
      }
      for (int index1 = num3; index1 < num3 + 2; ++index1)
      {
        for (int index2 = num2; index2 < num2 + 3; ++index2)
        {
          if (index1 == i1)
          {
            if (Main.tile[index1, index2] == null)
              Main.tile[index1, index2] = new Tile();
            Main.tile[index1, index2].type = (byte) 10;
            Main.tile[index1, index2].frameX = (short) (WorldGen.genRand.Next(3) * 18);
          }
          else
          {
            if (Main.tile[index1, index2] == null)
              Main.tile[index1, index2] = new Tile();
            Main.tile[index1, index2].active = false;
          }
        }
      }
      if (Main.netMode != 1)
      {
        int num4 = i1;
        for (int index = num2; index <= num2 + 2; ++index)
        {
          if (WorldGen.numNoWire < WorldGen.maxWire - 1)
          {
            WorldGen.noWireX[WorldGen.numNoWire] = num4;
            WorldGen.noWireY[WorldGen.numNoWire] = index;
            ++WorldGen.numNoWire;
          }
        }
      }
      for (int i2 = i1 - 1; i2 <= i1 + 1; ++i2)
      {
        for (int j2 = num2 - 1; j2 <= num2 + 2; ++j2)
          WorldGen.TileFrame(i2, j2);
      }
      Main.PlaySound(9, i * 16, j * 16);
      return true;
    }

    public static bool AddLifeCrystal(int i, int j)
    {
      for (int index = j; index < Main.maxTilesY; ++index)
      {
        if (Main.tile[i, index].active && Main.tileSolid[(int) Main.tile[i, index].type])
        {
          int endX = i;
          int endY = index - 1;
          if (Main.tile[endX, endY - 1].lava || Main.tile[endX - 1, endY - 1].lava || !WorldGen.EmptyTileCheck(endX - 1, endX, endY - 1, endY))
            return false;
          Main.tile[endX - 1, endY - 1].active = true;
          Main.tile[endX - 1, endY - 1].type = (byte) 12;
          Main.tile[endX - 1, endY - 1].frameX = (short) 0;
          Main.tile[endX - 1, endY - 1].frameY = (short) 0;
          Main.tile[endX, endY - 1].active = true;
          Main.tile[endX, endY - 1].type = (byte) 12;
          Main.tile[endX, endY - 1].frameX = (short) 18;
          Main.tile[endX, endY - 1].frameY = (short) 0;
          Main.tile[endX - 1, endY].active = true;
          Main.tile[endX - 1, endY].type = (byte) 12;
          Main.tile[endX - 1, endY].frameX = (short) 0;
          Main.tile[endX - 1, endY].frameY = (short) 18;
          Main.tile[endX, endY].active = true;
          Main.tile[endX, endY].type = (byte) 12;
          Main.tile[endX, endY].frameX = (short) 18;
          Main.tile[endX, endY].frameY = (short) 18;
          return true;
        }
      }
      return false;
    }

    public static void AddShadowOrb(int x, int y)
    {
      if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesY - 10)
        return;
      for (int index1 = x - 1; index1 < x + 1; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2].active && Main.tile[index1, index2].type == (byte) 31)
            return;
        }
      }
      Main.tile[x - 1, y - 1].active = true;
      Main.tile[x - 1, y - 1].type = (byte) 31;
      Main.tile[x - 1, y - 1].frameX = (short) 0;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].active = true;
      Main.tile[x, y - 1].type = (byte) 31;
      Main.tile[x, y - 1].frameX = (short) 18;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y].active = true;
      Main.tile[x - 1, y].type = (byte) 31;
      Main.tile[x - 1, y].frameX = (short) 0;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x, y].active = true;
      Main.tile[x, y].type = (byte) 31;
      Main.tile[x, y].frameX = (short) 18;
      Main.tile[x, y].frameY = (short) 18;
    }

    public static void AddHellHouses()
    {
      int num1 = (int) ((double) Main.maxTilesX * 0.25);
      for (int i = num1; i < Main.maxTilesX - num1; ++i)
      {
        int j = Main.maxTilesY - 40;
        while (Main.tile[i, j].active || Main.tile[i, j].liquid > (byte) 0)
          --j;
        if (Main.tile[i, j + 1].active)
        {
          byte type = (byte) WorldGen.genRand.Next(75, 77);
          byte wall = 13;
          if (WorldGen.genRand.Next(5) > 0)
            type = (byte) 75;
          if (type == (byte) 75)
            wall = (byte) 14;
          WorldGen.HellHouse(i, j, type, wall);
          i += WorldGen.genRand.Next(15, 80);
        }
      }
      float num2 = (float) (Main.maxTilesX / 4200);
      for (int index1 = 0; (double) index1 < 200.0 * (double) num2; ++index1)
      {
        int num3 = 0;
        bool flag1 = false;
        while (!flag1)
        {
          ++num3;
          int index2 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.2), (int) ((double) Main.maxTilesX * 0.8));
          int j = WorldGen.genRand.Next(Main.maxTilesY - 300, Main.maxTilesY - 20);
          if (Main.tile[index2, j].active && (Main.tile[index2, j].type == (byte) 75 || Main.tile[index2, j].type == (byte) 76))
          {
            int num4 = 0;
            if (Main.tile[index2 - 1, j].wall > (byte) 0)
              num4 = -1;
            else if (Main.tile[index2 + 1, j].wall > (byte) 0)
              num4 = 1;
            if (!Main.tile[index2 + num4, j].active && !Main.tile[index2 + num4, j + 1].active)
            {
              bool flag2 = false;
              for (int index3 = index2 - 8; index3 < index2 + 8; ++index3)
              {
                for (int index4 = j - 8; index4 < j + 8; ++index4)
                {
                  if (Main.tile[index3, index4].active && Main.tile[index3, index4].type == (byte) 4)
                  {
                    flag2 = true;
                    break;
                  }
                }
              }
              if (!flag2)
              {
                WorldGen.PlaceTile(index2 + num4, j, 4, true, true, style: 7);
                flag1 = true;
              }
            }
          }
          if (num3 > 1000)
            flag1 = true;
        }
      }
    }

    public static void HellHouse(int i, int j, byte type = 76, byte wall = 13)
    {
      int width = WorldGen.genRand.Next(8, 20);
      int num1 = WorldGen.genRand.Next(1, 3);
      int num2 = WorldGen.genRand.Next(4, 13);
      int i1 = i;
      int j1 = j;
      for (int index = 0; index < num1; ++index)
      {
        int height = WorldGen.genRand.Next(5, 9);
        WorldGen.HellRoom(i1, j1, width, height, type, wall);
        j1 -= height;
      }
      int j2 = j;
      for (int index = 0; index < num2; ++index)
      {
        int height = WorldGen.genRand.Next(5, 9);
        j2 += height;
        WorldGen.HellRoom(i1, j2, width, height, type, wall);
      }
      for (int index1 = i - width / 2; index1 <= i + width / 2; ++index1)
      {
        int index2 = j;
        while (index2 < Main.maxTilesY && (Main.tile[index1, index2].active && (Main.tile[index1, index2].type == (byte) 76 || Main.tile[index1, index2].type == (byte) 75) || Main.tile[i, index2].wall == (byte) 13 || Main.tile[i, index2].wall == (byte) 14))
          ++index2;
        int num3 = 6 + WorldGen.genRand.Next(3);
        while (index2 < Main.maxTilesY && !Main.tile[index1, index2].active)
        {
          --num3;
          Main.tile[index1, index2].active = true;
          Main.tile[index1, index2].type = (byte) 57;
          ++index2;
          if (num3 <= 0)
            break;
        }
      }
      int index3 = j;
      while (index3 < Main.maxTilesY && (Main.tile[i, index3].active && (Main.tile[i, index3].type == (byte) 76 || Main.tile[i, index3].type == (byte) 75) || Main.tile[i, index3].wall == (byte) 13 || Main.tile[i, index3].wall == (byte) 14))
        ++index3;
      int index4 = index3 - 1;
      int maxValue = index4;
      while (Main.tile[i, index4].active && (Main.tile[i, index4].type == (byte) 76 || Main.tile[i, index4].type == (byte) 75) || Main.tile[i, index4].wall == (byte) 13 || Main.tile[i, index4].wall == (byte) 14)
      {
        --index4;
        if (Main.tile[i, index4].active && (Main.tile[i, index4].type == (byte) 76 || Main.tile[i, index4].type == (byte) 75))
        {
          int num4 = WorldGen.genRand.Next(i - width / 2 + 1, i + width / 2 - 1);
          int num5 = WorldGen.genRand.Next(i - width / 2 + 1, i + width / 2 - 1);
          if (num4 > num5)
          {
            int num6 = num4;
            num4 = num5;
            num5 = num6;
          }
          if (num4 == num5)
          {
            if (num4 < i)
              ++num5;
            else
              --num4;
          }
          for (int index5 = num4; index5 <= num5; ++index5)
          {
            if (Main.tile[index5, index4 - 1].wall == (byte) 13)
              Main.tile[index5, index4].wall = (byte) 13;
            if (Main.tile[index5, index4 - 1].wall == (byte) 14)
              Main.tile[index5, index4].wall = (byte) 14;
            Main.tile[index5, index4].type = (byte) 19;
            Main.tile[index5, index4].active = true;
          }
          --index4;
        }
      }
      int minValue = index4;
      float num7 = (float) ((maxValue - minValue) * width) * 0.02f;
      for (int index6 = 0; (double) index6 < (double) num7; ++index6)
      {
        int num8 = WorldGen.genRand.Next(i - width / 2, i + width / 2 + 1);
        int num9 = WorldGen.genRand.Next(minValue, maxValue);
        int num10 = WorldGen.genRand.Next(3, 8);
        for (int index7 = num8 - num10; index7 <= num8 + num10; ++index7)
        {
          for (int index8 = num9 - num10; index8 <= num9 + num10; ++index8)
          {
            float num11 = (float) Math.Abs(index7 - num8);
            float num12 = (float) Math.Abs(index8 - num9);
            if (Math.Sqrt((double) num11 * (double) num11 + (double) num12 * (double) num12) < (double) num10 * 0.4)
            {
              try
              {
                if (Main.tile[index7, index8].type == (byte) 76 || Main.tile[index7, index8].type == (byte) 19)
                  Main.tile[index7, index8].active = false;
                Main.tile[index7, index8].wall = (byte) 0;
              }
              catch
              {
              }
            }
          }
        }
      }
    }

    public static void HellRoom(int i, int j, int width, int height, byte type = 76, byte wall = 13)
    {
      if (j > Main.maxTilesY - 40)
        return;
      for (int index1 = i - width / 2; index1 <= i + width / 2; ++index1)
      {
        for (int index2 = j - height; index2 <= j; ++index2)
        {
          try
          {
            Main.tile[index1, index2].active = true;
            Main.tile[index1, index2].type = type;
            Main.tile[index1, index2].liquid = (byte) 0;
            Main.tile[index1, index2].lava = false;
          }
          catch
          {
          }
        }
      }
      for (int index3 = i - width / 2 + 1; index3 <= i + width / 2 - 1; ++index3)
      {
        for (int index4 = j - height + 1; index4 <= j - 1; ++index4)
        {
          try
          {
            Main.tile[index3, index4].active = false;
            Main.tile[index3, index4].wall = wall;
            Main.tile[index3, index4].liquid = (byte) 0;
            Main.tile[index3, index4].lava = false;
          }
          catch
          {
          }
        }
      }
    }

    public static void MakeDungeon(int x, int y, int tileType = 41, int wallType = 7)
    {
      int num1 = WorldGen.genRand.Next(3);
      int num2 = WorldGen.genRand.Next(3);
      switch (num1)
      {
        case 1:
          tileType = 43;
          break;
        case 2:
          tileType = 44;
          break;
      }
      switch (num2)
      {
        case 1:
          wallType = 8;
          break;
        case 2:
          wallType = 9;
          break;
      }
      WorldGen.numDDoors = 0;
      WorldGen.numDPlats = 0;
      WorldGen.numDRooms = 0;
      WorldGen.dungeonX = x;
      WorldGen.dungeonY = y;
      WorldGen.dMinX = x;
      WorldGen.dMaxX = x;
      WorldGen.dMinY = y;
      WorldGen.dMaxY = y;
      WorldGen.dxStrength1 = (double) WorldGen.genRand.Next(25, 30);
      WorldGen.dyStrength1 = (double) WorldGen.genRand.Next(20, 25);
      WorldGen.dxStrength2 = (double) WorldGen.genRand.Next(35, 50);
      WorldGen.dyStrength2 = (double) WorldGen.genRand.Next(10, 15);
      float num3 = (float) (Main.maxTilesX / 60);
      float num4 = num3 + (float) WorldGen.genRand.Next(0, (int) ((double) num3 / 3.0));
      float num5 = num4;
      int num6 = 5;
      WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      while ((double) num4 > 0.0)
      {
        if (WorldGen.dungeonX < WorldGen.dMinX)
          WorldGen.dMinX = WorldGen.dungeonX;
        if (WorldGen.dungeonX > WorldGen.dMaxX)
          WorldGen.dMaxX = WorldGen.dungeonX;
        if (WorldGen.dungeonY > WorldGen.dMaxY)
          WorldGen.dMaxY = WorldGen.dungeonY;
        --num4;
        Main.statusText = Lang.gen[58] + " " + (object) (int) (((double) num5 - (double) num4) / (double) num5 * 60.0) + "%";
        if (num6 > 0)
          --num6;
        if (num6 == 0 & WorldGen.genRand.Next(3) == 0)
        {
          num6 = 5;
          if (WorldGen.genRand.Next(2) == 0)
          {
            int dungeonX = WorldGen.dungeonX;
            int dungeonY = WorldGen.dungeonY;
            WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            if (WorldGen.genRand.Next(2) == 0)
              WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            WorldGen.dungeonX = dungeonX;
            WorldGen.dungeonY = dungeonY;
          }
          else
            WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
        }
        else
          WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      }
      WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      int num7 = WorldGen.dRoomX[0];
      int num8 = WorldGen.dRoomY[0];
      for (int index = 0; index < WorldGen.numDRooms; ++index)
      {
        if (WorldGen.dRoomY[index] < num8)
        {
          num7 = WorldGen.dRoomX[index];
          num8 = WorldGen.dRoomY[index];
        }
      }
      WorldGen.dungeonX = num7;
      WorldGen.dungeonY = num8;
      WorldGen.dEnteranceX = num7;
      WorldGen.dSurface = false;
      int num9 = 5;
      while (!WorldGen.dSurface)
      {
        if (num9 > 0)
          --num9;
        if (num9 == 0 & WorldGen.genRand.Next(5) == 0 && (double) WorldGen.dungeonY > Main.worldSurface + 50.0)
        {
          num9 = 10;
          int dungeonX = WorldGen.dungeonX;
          int dungeonY = WorldGen.dungeonY;
          WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, true);
          WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
          WorldGen.dungeonX = dungeonX;
          WorldGen.dungeonY = dungeonY;
        }
        WorldGen.DungeonStairs(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      }
      WorldGen.DungeonEnt(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      Main.statusText = Lang.gen[58] + " 65%";
      for (int index1 = 0; index1 < WorldGen.numDRooms; ++index1)
      {
        for (int index2 = WorldGen.dRoomL[index1]; index2 <= WorldGen.dRoomR[index1]; ++index2)
        {
          if (!Main.tile[index2, WorldGen.dRoomT[index1] - 1].active)
          {
            WorldGen.DPlatX[WorldGen.numDPlats] = index2;
            WorldGen.DPlatY[WorldGen.numDPlats] = WorldGen.dRoomT[index1] - 1;
            ++WorldGen.numDPlats;
            break;
          }
        }
        for (int index3 = WorldGen.dRoomL[index1]; index3 <= WorldGen.dRoomR[index1]; ++index3)
        {
          if (!Main.tile[index3, WorldGen.dRoomB[index1] + 1].active)
          {
            WorldGen.DPlatX[WorldGen.numDPlats] = index3;
            WorldGen.DPlatY[WorldGen.numDPlats] = WorldGen.dRoomB[index1] + 1;
            ++WorldGen.numDPlats;
            break;
          }
        }
        for (int index4 = WorldGen.dRoomT[index1]; index4 <= WorldGen.dRoomB[index1]; ++index4)
        {
          if (!Main.tile[WorldGen.dRoomL[index1] - 1, index4].active)
          {
            WorldGen.DDoorX[WorldGen.numDDoors] = WorldGen.dRoomL[index1] - 1;
            WorldGen.DDoorY[WorldGen.numDDoors] = index4;
            WorldGen.DDoorPos[WorldGen.numDDoors] = -1;
            ++WorldGen.numDDoors;
            break;
          }
        }
        for (int index5 = WorldGen.dRoomT[index1]; index5 <= WorldGen.dRoomB[index1]; ++index5)
        {
          if (!Main.tile[WorldGen.dRoomR[index1] + 1, index5].active)
          {
            WorldGen.DDoorX[WorldGen.numDDoors] = WorldGen.dRoomR[index1] + 1;
            WorldGen.DDoorY[WorldGen.numDDoors] = index5;
            WorldGen.DDoorPos[WorldGen.numDDoors] = 1;
            ++WorldGen.numDDoors;
            break;
          }
        }
      }
      Main.statusText = Lang.gen[58] + " 70%";
      int num10 = 0;
      int num11 = 1000;
      int num12 = 0;
      while (num12 < Main.maxTilesX / 100)
      {
        ++num10;
        int index6 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index7 = WorldGen.genRand.Next((int) Main.worldSurface + 25, WorldGen.dMaxY);
        int num13 = index6;
        if ((int) Main.tile[index6, index7].wall == wallType && !Main.tile[index6, index7].active)
        {
          int num14 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num14 = -1;
          while (!Main.tile[index6, index7].active)
            index7 += num14;
          if (Main.tile[index6 - 1, index7].active && Main.tile[index6 + 1, index7].active && !Main.tile[index6 - 1, index7 - num14].active && !Main.tile[index6 + 1, index7 - num14].active)
          {
            ++num12;
            for (int index8 = WorldGen.genRand.Next(5, 13); Main.tile[index6 - 1, index7].active && Main.tile[index6, index7 + num14].active && Main.tile[index6, index7].active && !Main.tile[index6, index7 - num14].active && index8 > 0; --index8)
            {
              Main.tile[index6, index7].type = (byte) 48;
              if (!Main.tile[index6 - 1, index7 - num14].active && !Main.tile[index6 + 1, index7 - num14].active)
              {
                Main.tile[index6, index7 - num14].type = (byte) 48;
                Main.tile[index6, index7 - num14].active = true;
              }
              --index6;
            }
            int num15 = WorldGen.genRand.Next(5, 13);
            for (int index9 = num13 + 1; Main.tile[index9 + 1, index7].active && Main.tile[index9, index7 + num14].active && Main.tile[index9, index7].active && !Main.tile[index9, index7 - num14].active && num15 > 0; --num15)
            {
              Main.tile[index9, index7].type = (byte) 48;
              if (!Main.tile[index9 - 1, index7 - num14].active && !Main.tile[index9 + 1, index7 - num14].active)
              {
                Main.tile[index9, index7 - num14].type = (byte) 48;
                Main.tile[index9, index7 - num14].active = true;
              }
              ++index9;
            }
          }
        }
        if (num10 > num11)
        {
          num10 = 0;
          ++num12;
        }
      }
      int num16 = 0;
      int num17 = 1000;
      int num18 = 0;
      Main.statusText = Lang.gen[58] + " 75%";
      while (num18 < Main.maxTilesX / 100)
      {
        ++num16;
        int index10 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index11 = WorldGen.genRand.Next((int) Main.worldSurface + 25, WorldGen.dMaxY);
        int num19 = index11;
        if ((int) Main.tile[index10, index11].wall == wallType && !Main.tile[index10, index11].active)
        {
          int num20 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num20 = -1;
          while (index10 > 5 && index10 < Main.maxTilesX - 5 && !Main.tile[index10, index11].active)
            index10 += num20;
          if (Main.tile[index10, index11 - 1].active && Main.tile[index10, index11 + 1].active && !Main.tile[index10 - num20, index11 - 1].active && !Main.tile[index10 - num20, index11 + 1].active)
          {
            ++num18;
            for (int index12 = WorldGen.genRand.Next(5, 13); Main.tile[index10, index11 - 1].active && Main.tile[index10 + num20, index11].active && Main.tile[index10, index11].active && !Main.tile[index10 - num20, index11].active && index12 > 0; --index12)
            {
              Main.tile[index10, index11].type = (byte) 48;
              if (!Main.tile[index10 - num20, index11 - 1].active && !Main.tile[index10 - num20, index11 + 1].active)
              {
                Main.tile[index10 - num20, index11].type = (byte) 48;
                Main.tile[index10 - num20, index11].active = true;
              }
              --index11;
            }
            int num21 = WorldGen.genRand.Next(5, 13);
            for (int index13 = num19 + 1; Main.tile[index10, index13 + 1].active && Main.tile[index10 + num20, index13].active && Main.tile[index10, index13].active && !Main.tile[index10 - num20, index13].active && num21 > 0; --num21)
            {
              Main.tile[index10, index13].type = (byte) 48;
              if (!Main.tile[index10 - num20, index13 - 1].active && !Main.tile[index10 - num20, index13 + 1].active)
              {
                Main.tile[index10 - num20, index13].type = (byte) 48;
                Main.tile[index10 - num20, index13].active = true;
              }
              ++index13;
            }
          }
        }
        if (num16 > num17)
        {
          num16 = 0;
          ++num18;
        }
      }
      Main.statusText = Lang.gen[58] + " 80%";
      for (int index14 = 0; index14 < WorldGen.numDDoors; ++index14)
      {
        int num22 = WorldGen.DDoorX[index14] - 10;
        int num23 = WorldGen.DDoorX[index14] + 10;
        int num24 = 100;
        int num25 = 0;
        for (int index15 = num22; index15 < num23; ++index15)
        {
          bool flag1 = true;
          int index16 = WorldGen.DDoorY[index14];
          while (!Main.tile[index15, index16].active)
            --index16;
          if (!Main.tileDungeon[(int) Main.tile[index15, index16].type])
            flag1 = false;
          int num26 = index16;
          int index17 = WorldGen.DDoorY[index14];
          while (!Main.tile[index15, index17].active)
            ++index17;
          if (!Main.tileDungeon[(int) Main.tile[index15, index17].type])
            flag1 = false;
          int num27 = index17;
          if (num27 - num26 >= 3)
          {
            int num28 = index15 - 20;
            int num29 = index15 + 20;
            int num30 = num27 - 10;
            int num31 = num27 + 10;
            for (int index18 = num28; index18 < num29; ++index18)
            {
              for (int index19 = num30; index19 < num31; ++index19)
              {
                if (Main.tile[index18, index19].active && Main.tile[index18, index19].type == (byte) 10)
                {
                  flag1 = false;
                  break;
                }
              }
            }
            if (flag1)
            {
              for (int index20 = num27 - 3; index20 < num27; ++index20)
              {
                for (int index21 = index15 - 3; index21 <= index15 + 3; ++index21)
                {
                  if (Main.tile[index21, index20].active)
                  {
                    flag1 = false;
                    break;
                  }
                }
              }
            }
            if (flag1 && num27 - num26 < 20)
            {
              bool flag2 = false;
              if (WorldGen.DDoorPos[index14] == 0 && num27 - num26 < num24)
                flag2 = true;
              if (WorldGen.DDoorPos[index14] == -1 && index15 > num25)
                flag2 = true;
              if (WorldGen.DDoorPos[index14] == 1 && (index15 < num25 || num25 == 0))
                flag2 = true;
              if (flag2)
              {
                num25 = index15;
                num24 = num27 - num26;
              }
            }
          }
        }
        if (num24 < 20)
        {
          int i = num25;
          int index22 = WorldGen.DDoorY[index14];
          int index23 = index22;
          for (; !Main.tile[i, index22].active; ++index22)
            Main.tile[i, index22].active = false;
          while (!Main.tile[i, index23].active)
            --index23;
          int j = index22 - 1;
          int num32 = index23 + 1;
          for (int index24 = num32; index24 < j - 2; ++index24)
          {
            Main.tile[i, index24].active = true;
            Main.tile[i, index24].type = (byte) tileType;
          }
          WorldGen.PlaceTile(i, j, 10, true);
          int index25 = i - 1;
          int index26 = j - 3;
          while (!Main.tile[index25, index26].active)
            --index26;
          if (j - index26 < j - num32 + 5 && Main.tileDungeon[(int) Main.tile[index25, index26].type])
          {
            for (int index27 = j - 4 - WorldGen.genRand.Next(3); index27 > index26; --index27)
            {
              Main.tile[index25, index27].active = true;
              Main.tile[index25, index27].type = (byte) tileType;
            }
          }
          int index28 = index25 + 2;
          int index29 = j - 3;
          while (!Main.tile[index28, index29].active)
            --index29;
          if (j - index29 < j - num32 + 5 && Main.tileDungeon[(int) Main.tile[index28, index29].type])
          {
            for (int index30 = j - 4 - WorldGen.genRand.Next(3); index30 > index29; --index30)
            {
              Main.tile[index28, index30].active = true;
              Main.tile[index28, index30].type = (byte) tileType;
            }
          }
          int index31 = j + 1;
          int num33 = index28 - 1;
          Main.tile[num33 - 1, index31].active = true;
          Main.tile[num33 - 1, index31].type = (byte) tileType;
          Main.tile[num33 + 1, index31].active = true;
          Main.tile[num33 + 1, index31].type = (byte) tileType;
        }
      }
      Main.statusText = Lang.gen[58] + " 85%";
      for (int index32 = 0; index32 < WorldGen.numDPlats; ++index32)
      {
        int index33 = WorldGen.DPlatX[index32];
        int num34 = WorldGen.DPlatY[index32];
        int num35 = Main.maxTilesX;
        int num36 = 10;
        for (int index34 = num34 - 5; index34 <= num34 + 5; ++index34)
        {
          int index35 = index33;
          int index36 = index33;
          bool flag3 = false;
          if (Main.tile[index35, index34].active)
          {
            flag3 = true;
          }
          else
          {
            while (!Main.tile[index35, index34].active)
            {
              --index35;
              if (!Main.tileDungeon[(int) Main.tile[index35, index34].type])
                flag3 = true;
            }
            while (!Main.tile[index36, index34].active)
            {
              ++index36;
              if (!Main.tileDungeon[(int) Main.tile[index36, index34].type])
                flag3 = true;
            }
          }
          if (!flag3 && index36 - index35 <= num36)
          {
            bool flag4 = true;
            int num37 = index33 - num36 / 2 - 2;
            int num38 = index33 + num36 / 2 + 2;
            int num39 = index34 - 5;
            int num40 = index34 + 5;
            for (int index37 = num37; index37 <= num38; ++index37)
            {
              for (int index38 = num39; index38 <= num40; ++index38)
              {
                if (Main.tile[index37, index38].active && Main.tile[index37, index38].type == (byte) 19)
                {
                  flag4 = false;
                  break;
                }
              }
            }
            for (int index39 = index34 + 3; index39 >= index34 - 5; --index39)
            {
              if (Main.tile[index33, index39].active)
              {
                flag4 = false;
                break;
              }
            }
            if (flag4)
            {
              num35 = index34;
              break;
            }
          }
        }
        if (num35 > num34 - 10 && num35 < num34 + 10)
        {
          int index40 = index33;
          int index41 = num35;
          int index42 = index33 + 1;
          for (; !Main.tile[index40, index41].active; --index40)
          {
            Main.tile[index40, index41].active = true;
            Main.tile[index40, index41].type = (byte) 19;
          }
          for (; !Main.tile[index42, index41].active; ++index42)
          {
            Main.tile[index42, index41].active = true;
            Main.tile[index42, index41].type = (byte) 19;
          }
        }
      }
      Main.statusText = Lang.gen[58] + " 90%";
      int num41 = 0;
      int num42 = 1000;
      int num43 = 0;
      while (num43 < Main.maxTilesX / 20)
      {
        ++num41;
        int index43 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index44 = WorldGen.genRand.Next(WorldGen.dMinY, WorldGen.dMaxY);
        bool flag5 = true;
        if ((int) Main.tile[index43, index44].wall == wallType && !Main.tile[index43, index44].active)
        {
          int num44 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num44 = -1;
          while (flag5 && !Main.tile[index43, index44].active)
          {
            index43 -= num44;
            if (index43 < 5 || index43 > Main.maxTilesX - 5)
              flag5 = false;
            else if (Main.tile[index43, index44].active && !Main.tileDungeon[(int) Main.tile[index43, index44].type])
              flag5 = false;
          }
          if (flag5 && Main.tile[index43, index44].active && Main.tileDungeon[(int) Main.tile[index43, index44].type] && Main.tile[index43, index44 - 1].active && Main.tileDungeon[(int) Main.tile[index43, index44 - 1].type] && Main.tile[index43, index44 + 1].active && Main.tileDungeon[(int) Main.tile[index43, index44 + 1].type])
          {
            int i1 = index43 + num44;
            for (int index45 = i1 - 3; index45 <= i1 + 3; ++index45)
            {
              for (int index46 = index44 - 3; index46 <= index44 + 3; ++index46)
              {
                if (Main.tile[index45, index46].active && Main.tile[index45, index46].type == (byte) 19)
                {
                  flag5 = false;
                  break;
                }
              }
            }
            if (flag5 && !Main.tile[i1, index44 - 1].active & !Main.tile[i1, index44 - 2].active & !Main.tile[i1, index44 - 3].active)
            {
              int index47 = i1;
              int num45 = i1;
              while (index47 > WorldGen.dMinX && index47 < WorldGen.dMaxX && !Main.tile[index47, index44].active && !Main.tile[index47, index44 - 1].active && !Main.tile[index47, index44 + 1].active)
                index47 += num44;
              int num46 = Math.Abs(i1 - index47);
              bool flag6 = false;
              if (WorldGen.genRand.Next(2) == 0)
                flag6 = true;
              if (num46 > 5)
              {
                for (int index48 = WorldGen.genRand.Next(1, 4); index48 > 0; --index48)
                {
                  Main.tile[i1, index44].active = true;
                  Main.tile[i1, index44].type = (byte) 19;
                  if (flag6)
                  {
                    WorldGen.PlaceTile(i1, index44 - 1, 50, true);
                    if (WorldGen.genRand.Next(50) == 0 && Main.tile[i1, index44 - 1].type == (byte) 50)
                      Main.tile[i1, index44 - 1].frameX = (short) 90;
                  }
                  i1 += num44;
                }
                num41 = 0;
                ++num43;
                if (!flag6 && WorldGen.genRand.Next(2) == 0)
                {
                  int i2 = num45;
                  int j = index44 - 1;
                  int type = 0;
                  if (WorldGen.genRand.Next(4) == 0)
                    type = 1;
                  switch (type)
                  {
                    case 0:
                      type = 13;
                      break;
                    case 1:
                      type = 49;
                      break;
                  }
                  WorldGen.PlaceTile(i2, j, type, true);
                  if (Main.tile[i2, j].type == (byte) 13)
                    Main.tile[i2, j].frameX = WorldGen.genRand.Next(2) != 0 ? (short) 36 : (short) 18;
                }
              }
            }
          }
        }
        if (num41 > num42)
        {
          num41 = 0;
          ++num43;
        }
      }
      Main.statusText = Lang.gen[58] + " 95%";
      int num47 = 0;
      for (int index = 0; index < WorldGen.numDRooms; ++index)
      {
        int num48 = 0;
        while (num48 < 1000)
        {
          int num49 = (int) ((double) WorldGen.dRoomSize[index] * 0.4);
          int i = WorldGen.dRoomX[index] + WorldGen.genRand.Next(-num49, num49 + 1);
          int j = WorldGen.dRoomY[index] + WorldGen.genRand.Next(-num49, num49 + 1);
          ++num47;
          int Style = 2;
          int contain;
          switch (num47)
          {
            case 1:
              contain = 329;
              break;
            case 2:
              contain = 155;
              break;
            case 3:
              contain = 156;
              break;
            case 4:
              contain = 157;
              break;
            case 5:
              contain = 163;
              break;
            case 6:
              contain = 113;
              break;
            case 7:
              contain = 327;
              Style = 0;
              break;
            default:
              contain = 164;
              num47 = 0;
              break;
          }
          if ((double) j < Main.worldSurface + 50.0)
          {
            contain = 327;
            Style = 0;
          }
          if (contain == 0 && WorldGen.genRand.Next(2) == 0)
          {
            num48 = 1000;
          }
          else
          {
            if (WorldGen.AddBuriedChest(i, j, contain, Style: Style))
              num48 += 1000;
            ++num48;
          }
        }
      }
      WorldGen.dMinX -= 25;
      WorldGen.dMaxX += 25;
      WorldGen.dMinY -= 25;
      WorldGen.dMaxY += 25;
      if (WorldGen.dMinX < 0)
        WorldGen.dMinX = 0;
      if (WorldGen.dMaxX > Main.maxTilesX)
        WorldGen.dMaxX = Main.maxTilesX;
      if (WorldGen.dMinY < 0)
        WorldGen.dMinY = 0;
      if (WorldGen.dMaxY > Main.maxTilesY)
        WorldGen.dMaxY = Main.maxTilesY;
      int num50 = 0;
      int num51 = 1000;
      int num52 = 0;
      while (num52 < Main.maxTilesX / 150)
      {
        ++num50;
        int x1 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index49 = WorldGen.genRand.Next(WorldGen.dMinY, WorldGen.dMaxY);
        if ((int) Main.tile[x1, index49].wall == wallType)
        {
          for (int y1 = index49; y1 > WorldGen.dMinY; --y1)
          {
            if (Main.tile[x1, y1 - 1].active && (int) Main.tile[x1, y1 - 1].type == tileType)
            {
              bool flag = false;
              for (int index50 = x1 - 15; index50 < x1 + 15; ++index50)
              {
                for (int index51 = y1 - 15; index51 < y1 + 15; ++index51)
                {
                  if (index50 > 0 && index50 < Main.maxTilesX && index51 > 0 && index51 < Main.maxTilesY && Main.tile[index50, index51].type == (byte) 42)
                  {
                    flag = true;
                    break;
                  }
                }
              }
              if (Main.tile[x1 - 1, y1].active || Main.tile[x1 + 1, y1].active || Main.tile[x1 - 1, y1 + 1].active || Main.tile[x1 + 1, y1 + 1].active || Main.tile[x1, y1 + 2].active)
                flag = true;
              if (!flag)
              {
                WorldGen.Place1x2Top(x1, y1, 42);
                if (Main.tile[x1, y1].type == (byte) 42)
                {
                  num50 = 0;
                  ++num52;
                  for (int index52 = 0; index52 < 1000; ++index52)
                  {
                    int i = x1 + WorldGen.genRand.Next(-12, 13);
                    int j = y1 + WorldGen.genRand.Next(3, 21);
                    if (!Main.tile[i, j].active && !Main.tile[i, j + 1].active && Main.tile[i - 1, j].type != (byte) 48 && Main.tile[i + 1, j].type != (byte) 48 && Collision.CanHit(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, new Vector2((float) (x1 * 16), (float) (y1 * 16 + 1)), 16, 16))
                    {
                      WorldGen.PlaceTile(i, j, 136, true);
                      if (Main.tile[i, j].active)
                      {
                        while (i != x1 || j != y1)
                        {
                          Main.tile[i, j].wire = true;
                          if (i > x1)
                            --i;
                          if (i < x1)
                            ++i;
                          Main.tile[i, j].wire = true;
                          if (j > y1)
                            --j;
                          if (j < y1)
                            ++j;
                          Main.tile[i, j].wire = true;
                        }
                        if (Main.rand.Next(3) > 0)
                        {
                          Main.tile[x1, y1].frameX = (short) 18;
                          Main.tile[x1, y1 + 1].frameX = (short) 18;
                          break;
                        }
                        break;
                      }
                    }
                  }
                  break;
                }
                break;
              }
              break;
            }
          }
        }
        if (num50 > num51)
        {
          ++num52;
          num50 = 0;
        }
      }
      int num53 = 0;
      int num54 = 1000;
      int num55 = 0;
      while (num55 < Main.maxTilesX / 500)
      {
        ++num53;
        int x2 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int y2 = WorldGen.genRand.Next(WorldGen.dMinY, WorldGen.dMaxY);
        if ((int) Main.tile[x2, y2].wall == wallType && WorldGen.placeTrap(x2, y2, 0))
          num53 = num54;
        if (num53 > num54)
        {
          ++num55;
          num53 = 0;
        }
      }
    }

    public static void DungeonStairs(int i, int j, int tileType, int wallType)
    {
      Vector2 vector2_1 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(5, 9);
      Vector2 vector2_2;
      vector2_2.X = (float) i;
      vector2_2.Y = (float) j;
      int num2 = WorldGen.genRand.Next(10, 30);
      int num3 = i <= WorldGen.dEnteranceX ? 1 : -1;
      if (i > Main.maxTilesX - 400)
        num3 = -1;
      else if (i < 400)
        num3 = 1;
      vector2_1.Y = -1f;
      vector2_1.X = (float) num3;
      if (WorldGen.genRand.Next(3) == 0)
        vector2_1.X *= 0.5f;
      else if (WorldGen.genRand.Next(3) == 0)
        vector2_1.Y *= 2f;
      while (num2 > 0)
      {
        --num2;
        int num4 = (int) ((double) vector2_2.X - num1 - 4.0 - (double) WorldGen.genRand.Next(6));
        int num5 = (int) ((double) vector2_2.X + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        int num6 = (int) ((double) vector2_2.Y - num1 - 4.0);
        int num7 = (int) ((double) vector2_2.Y + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        if (num4 < 0)
          num4 = 0;
        if (num5 > Main.maxTilesX)
          num5 = Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > Main.maxTilesY)
          num7 = Main.maxTilesY;
        int num8 = 1;
        if ((double) vector2_2.X > (double) (Main.maxTilesX / 2))
          num8 = -1;
        int i1 = (int) ((double) vector2_2.X + WorldGen.dxStrength1 * 0.600000023841858 * (double) num8 + WorldGen.dxStrength2 * (double) num8);
        int num9 = (int) (WorldGen.dyStrength2 * 0.5);
        if ((double) vector2_2.Y < Main.worldSurface - 5.0 && Main.tile[i1, (int) ((double) vector2_2.Y - num1 - 6.0 + (double) num9)].wall == (byte) 0 && Main.tile[i1, (int) ((double) vector2_2.Y - num1 - 7.0 + (double) num9)].wall == (byte) 0 && Main.tile[i1, (int) ((double) vector2_2.Y - num1 - 8.0 + (double) num9)].wall == (byte) 0)
        {
          WorldGen.dSurface = true;
          WorldGen.TileRunner(i1, (int) ((double) vector2_2.Y - num1 - 6.0 + (double) num9), (double) WorldGen.genRand.Next(25, 35), WorldGen.genRand.Next(10, 20), -1, speedY: -1f);
        }
        for (int index1 = num4; index1 < num5; ++index1)
        {
          for (int index2 = num6; index2 < num7; ++index2)
          {
            Main.tile[index1, index2].liquid = (byte) 0;
            if ((int) Main.tile[index1, index2].wall != wallType)
            {
              Main.tile[index1, index2].wall = (byte) 0;
              Main.tile[index1, index2].active = true;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
        for (int i2 = num4 + 1; i2 < num5 - 1; ++i2)
        {
          for (int j1 = num6 + 1; j1 < num7 - 1; ++j1)
            WorldGen.PlaceWall(i2, j1, wallType, true);
        }
        int num10 = 0;
        if (WorldGen.genRand.Next((int) num1) == 0)
          num10 = WorldGen.genRand.Next(1, 3);
        int num11 = (int) ((double) vector2_2.X - num1 * 0.5 - (double) num10);
        int num12 = (int) ((double) vector2_2.X + num1 * 0.5 + (double) num10);
        int num13 = (int) ((double) vector2_2.Y - num1 * 0.5 - (double) num10);
        int num14 = (int) ((double) vector2_2.Y + num1 * 0.5 + (double) num10);
        if (num11 < 0)
          num11 = 0;
        if (num12 > Main.maxTilesX)
          num12 = Main.maxTilesX;
        if (num13 < 0)
          num13 = 0;
        if (num14 > Main.maxTilesY)
          num14 = Main.maxTilesY;
        for (int i3 = num11; i3 < num12; ++i3)
        {
          for (int j2 = num13; j2 < num14; ++j2)
          {
            Main.tile[i3, j2].active = false;
            WorldGen.PlaceWall(i3, j2, wallType, true);
          }
        }
        if (WorldGen.dSurface)
          num2 = 0;
        vector2_2 += vector2_1;
      }
      WorldGen.dungeonX = (int) vector2_2.X;
      WorldGen.dungeonY = (int) vector2_2.Y;
    }

    public static void DungeonHalls(int i, int j, int tileType, int wallType, bool forceX = false)
    {
      Vector2 vector2_1 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(4, 6);
      Vector2 vector2_2 = new Vector2();
      Vector2 vector2_3 = new Vector2();
      Vector2 vector2_4;
      vector2_4.X = (float) i;
      vector2_4.Y = (float) j;
      int num2 = WorldGen.genRand.Next(35, 80);
      if (forceX)
      {
        num2 += 20;
        WorldGen.lastDungeonHall = new Vector2();
      }
      else if (WorldGen.genRand.Next(5) == 0)
      {
        num1 *= 2.0;
        num2 /= 2;
      }
      bool flag1 = false;
      while (!flag1)
      {
        int num3 = WorldGen.genRand.Next(2) != 0 ? 1 : -1;
        bool flag2 = false;
        if (WorldGen.genRand.Next(2) == 0)
          flag2 = true;
        if (forceX)
          flag2 = true;
        if (flag2)
        {
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num3;
          vector2_3.Y = 0.0f;
          vector2_3.X = (float) -num3;
          vector2_1.Y = 0.0f;
          vector2_1.X = (float) num3;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_1.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else
        {
          ++num1;
          vector2_1.Y = (float) num3;
          vector2_1.X = 0.0f;
          vector2_2.X = 0.0f;
          vector2_2.Y = (float) num3;
          vector2_3.X = 0.0f;
          vector2_3.Y = (float) -num3;
          if (WorldGen.genRand.Next(2) == 0)
            vector2_1.X = WorldGen.genRand.Next(2) != 0 ? -0.3f : 0.3f;
          else
            num2 /= 2;
        }
        if (WorldGen.lastDungeonHall != vector2_3)
          flag1 = true;
      }
      if (!forceX)
      {
        if ((double) vector2_4.X > (double) (WorldGen.lastMaxTilesX - 200))
        {
          int num4 = -1;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num4;
          vector2_1.Y = 0.0f;
          vector2_1.X = (float) num4;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_1.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else if ((double) vector2_4.X < 200.0)
        {
          int num5 = 1;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num5;
          vector2_1.Y = 0.0f;
          vector2_1.X = (float) num5;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_1.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else if ((double) vector2_4.Y > (double) (WorldGen.lastMaxTilesY - 300))
        {
          int num6 = -1;
          ++num1;
          vector2_1.Y = (float) num6;
          vector2_1.X = 0.0f;
          vector2_2.X = 0.0f;
          vector2_2.Y = (float) num6;
          if (WorldGen.genRand.Next(2) == 0)
            vector2_1.X = WorldGen.genRand.Next(2) != 0 ? -0.3f : 0.3f;
        }
        else if ((double) vector2_4.Y < Main.rockLayer)
        {
          int num7 = 1;
          ++num1;
          vector2_1.Y = (float) num7;
          vector2_1.X = 0.0f;
          vector2_2.X = 0.0f;
          vector2_2.Y = (float) num7;
          if (WorldGen.genRand.Next(2) == 0)
            vector2_1.X = WorldGen.genRand.Next(2) != 0 ? -0.3f : 0.3f;
        }
        else if ((double) vector2_4.X < (double) (Main.maxTilesX / 2) && (double) vector2_4.X > (double) Main.maxTilesX * 0.25)
        {
          int num8 = -1;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num8;
          vector2_1.Y = 0.0f;
          vector2_1.X = (float) num8;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_1.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else if ((double) vector2_4.X > (double) (Main.maxTilesX / 2) && (double) vector2_4.X < (double) Main.maxTilesX * 0.75)
        {
          int num9 = 1;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num9;
          vector2_1.Y = 0.0f;
          vector2_1.X = (float) num9;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_1.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
      }
      if ((double) vector2_2.Y == 0.0)
      {
        WorldGen.DDoorX[WorldGen.numDDoors] = (int) vector2_4.X;
        WorldGen.DDoorY[WorldGen.numDDoors] = (int) vector2_4.Y;
        WorldGen.DDoorPos[WorldGen.numDDoors] = 0;
        ++WorldGen.numDDoors;
      }
      else
      {
        WorldGen.DPlatX[WorldGen.numDPlats] = (int) vector2_4.X;
        WorldGen.DPlatY[WorldGen.numDPlats] = (int) vector2_4.Y;
        ++WorldGen.numDPlats;
      }
      WorldGen.lastDungeonHall = vector2_2;
      while (num2 > 0)
      {
        if ((double) vector2_2.X > 0.0 && (double) vector2_4.X > (double) (Main.maxTilesX - 100))
          num2 = 0;
        else if ((double) vector2_2.X < 0.0 && (double) vector2_4.X < 100.0)
          num2 = 0;
        else if ((double) vector2_2.Y > 0.0 && (double) vector2_4.Y > (double) (Main.maxTilesY - 100))
          num2 = 0;
        else if ((double) vector2_2.Y < 0.0 && (double) vector2_4.Y < Main.rockLayer + 50.0)
          num2 = 0;
        --num2;
        int num10 = (int) ((double) vector2_4.X - num1 - 4.0 - (double) WorldGen.genRand.Next(6));
        int num11 = (int) ((double) vector2_4.X + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        int num12 = (int) ((double) vector2_4.Y - num1 - 4.0 - (double) WorldGen.genRand.Next(6));
        int num13 = (int) ((double) vector2_4.Y + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        if (num10 < 0)
          num10 = 0;
        if (num11 > Main.maxTilesX)
          num11 = Main.maxTilesX;
        if (num12 < 0)
          num12 = 0;
        if (num13 > Main.maxTilesY)
          num13 = Main.maxTilesY;
        for (int index1 = num10; index1 < num11; ++index1)
        {
          for (int index2 = num12; index2 < num13; ++index2)
          {
            Main.tile[index1, index2].liquid = (byte) 0;
            if (Main.tile[index1, index2].wall == (byte) 0)
            {
              Main.tile[index1, index2].active = true;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
        for (int i1 = num10 + 1; i1 < num11 - 1; ++i1)
        {
          for (int j1 = num12 + 1; j1 < num13 - 1; ++j1)
            WorldGen.PlaceWall(i1, j1, wallType, true);
        }
        int num14 = 0;
        if ((double) vector2_1.Y == 0.0 && WorldGen.genRand.Next((int) num1 + 1) == 0)
          num14 = WorldGen.genRand.Next(1, 3);
        else if ((double) vector2_1.X == 0.0 && WorldGen.genRand.Next((int) num1 - 1) == 0)
          num14 = WorldGen.genRand.Next(1, 3);
        else if (WorldGen.genRand.Next((int) num1 * 3) == 0)
          num14 = WorldGen.genRand.Next(1, 3);
        int num15 = (int) ((double) vector2_4.X - num1 * 0.5 - (double) num14);
        int num16 = (int) ((double) vector2_4.X + num1 * 0.5 + (double) num14);
        int num17 = (int) ((double) vector2_4.Y - num1 * 0.5 - (double) num14);
        int num18 = (int) ((double) vector2_4.Y + num1 * 0.5 + (double) num14);
        if (num15 < 0)
          num15 = 0;
        if (num16 > Main.maxTilesX)
          num16 = Main.maxTilesX;
        if (num17 < 0)
          num17 = 0;
        if (num18 > Main.maxTilesY)
          num18 = Main.maxTilesY;
        for (int index3 = num15; index3 < num16; ++index3)
        {
          for (int index4 = num17; index4 < num18; ++index4)
          {
            Main.tile[index3, index4].active = false;
            Main.tile[index3, index4].wall = (byte) wallType;
          }
        }
        vector2_4 += vector2_1;
      }
      WorldGen.dungeonX = (int) vector2_4.X;
      WorldGen.dungeonY = (int) vector2_4.Y;
      if ((double) vector2_2.Y == 0.0)
      {
        WorldGen.DDoorX[WorldGen.numDDoors] = (int) vector2_4.X;
        WorldGen.DDoorY[WorldGen.numDDoors] = (int) vector2_4.Y;
        WorldGen.DDoorPos[WorldGen.numDDoors] = 0;
        ++WorldGen.numDDoors;
      }
      else
      {
        WorldGen.DPlatX[WorldGen.numDPlats] = (int) vector2_4.X;
        WorldGen.DPlatY[WorldGen.numDPlats] = (int) vector2_4.Y;
        ++WorldGen.numDPlats;
      }
    }

    public static void DungeonRoom(int i, int j, int tileType, int wallType)
    {
      double num1 = (double) WorldGen.genRand.Next(15, 30);
      Vector2 vector2_1;
      vector2_1.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_1.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      Vector2 vector2_2;
      vector2_2.X = (float) i;
      vector2_2.Y = (float) j - (float) num1 / 2f;
      int num2 = WorldGen.genRand.Next(10, 20);
      double num3 = (double) vector2_2.X;
      double num4 = (double) vector2_2.X;
      double num5 = (double) vector2_2.Y;
      double num6 = (double) vector2_2.Y;
      while (num2 > 0)
      {
        --num2;
        int num7 = (int) ((double) vector2_2.X - num1 * 0.800000011920929 - 5.0);
        int num8 = (int) ((double) vector2_2.X + num1 * 0.800000011920929 + 5.0);
        int num9 = (int) ((double) vector2_2.Y - num1 * 0.800000011920929 - 5.0);
        int num10 = (int) ((double) vector2_2.Y + num1 * 0.800000011920929 + 5.0);
        if (num7 < 0)
          num7 = 0;
        if (num8 > Main.maxTilesX)
          num8 = Main.maxTilesX;
        if (num9 < 0)
          num9 = 0;
        if (num10 > Main.maxTilesY)
          num10 = Main.maxTilesY;
        for (int index1 = num7; index1 < num8; ++index1)
        {
          for (int index2 = num9; index2 < num10; ++index2)
          {
            Main.tile[index1, index2].liquid = (byte) 0;
            if (Main.tile[index1, index2].wall == (byte) 0)
            {
              Main.tile[index1, index2].active = true;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
        for (int i1 = num7 + 1; i1 < num8 - 1; ++i1)
        {
          for (int j1 = num9 + 1; j1 < num10 - 1; ++j1)
            WorldGen.PlaceWall(i1, j1, wallType, true);
        }
        int num11 = (int) ((double) vector2_2.X - num1 * 0.5);
        int num12 = (int) ((double) vector2_2.X + num1 * 0.5);
        int num13 = (int) ((double) vector2_2.Y - num1 * 0.5);
        int num14 = (int) ((double) vector2_2.Y + num1 * 0.5);
        if (num11 < 0)
          num11 = 0;
        if (num12 > Main.maxTilesX)
          num12 = Main.maxTilesX;
        if (num13 < 0)
          num13 = 0;
        if (num14 > Main.maxTilesY)
          num14 = Main.maxTilesY;
        if ((double) num11 < num3)
          num3 = (double) num11;
        if ((double) num12 > num4)
          num4 = (double) num12;
        if ((double) num13 < num5)
          num5 = (double) num13;
        if ((double) num14 > num6)
          num6 = (double) num14;
        for (int index3 = num11; index3 < num12; ++index3)
        {
          for (int index4 = num13; index4 < num14; ++index4)
          {
            Main.tile[index3, index4].active = false;
            Main.tile[index3, index4].wall = (byte) wallType;
          }
        }
        vector2_2 += vector2_1;
        vector2_1.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_1.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_1.X > 1.0)
          vector2_1.X = 1f;
        if ((double) vector2_1.X < -1.0)
          vector2_1.X = -1f;
        if ((double) vector2_1.Y > 1.0)
          vector2_1.Y = 1f;
        if ((double) vector2_1.Y < -1.0)
          vector2_1.Y = -1f;
      }
      WorldGen.dRoomX[WorldGen.numDRooms] = (int) vector2_2.X;
      WorldGen.dRoomY[WorldGen.numDRooms] = (int) vector2_2.Y;
      WorldGen.dRoomSize[WorldGen.numDRooms] = (int) num1;
      WorldGen.dRoomL[WorldGen.numDRooms] = (int) num3;
      WorldGen.dRoomR[WorldGen.numDRooms] = (int) num4;
      WorldGen.dRoomT[WorldGen.numDRooms] = (int) num5;
      WorldGen.dRoomB[WorldGen.numDRooms] = (int) num6;
      WorldGen.dRoomTreasure[WorldGen.numDRooms] = false;
      ++WorldGen.numDRooms;
    }

    public static void DungeonEnt(int i, int j, int tileType, int wallType)
    {
      int num1 = 60;
      for (int index1 = i - num1; index1 < i + num1; ++index1)
      {
        for (int index2 = j - num1; index2 < j + num1; ++index2)
        {
          Main.tile[index1, index2].liquid = (byte) 0;
          Main.tile[index1, index2].lava = false;
        }
      }
      double dxStrength1 = WorldGen.dxStrength1;
      double dyStrength1 = WorldGen.dyStrength1;
      Vector2 vector2;
      vector2.X = (float) i;
      vector2.Y = (float) j - (float) dyStrength1 / 2f;
      WorldGen.dMinY = (int) vector2.Y;
      int num2 = 1;
      if (i > Main.maxTilesX / 2)
        num2 = -1;
      int num3 = (int) ((double) vector2.X - dxStrength1 * 0.600000023841858 - (double) WorldGen.genRand.Next(2, 5));
      int num4 = (int) ((double) vector2.X + dxStrength1 * 0.600000023841858 + (double) WorldGen.genRand.Next(2, 5));
      int num5 = (int) ((double) vector2.Y - dyStrength1 * 0.600000023841858 - (double) WorldGen.genRand.Next(2, 5));
      int num6 = (int) ((double) vector2.Y + dyStrength1 * 0.600000023841858 + (double) WorldGen.genRand.Next(8, 16));
      if (num3 < 0)
        num3 = 0;
      if (num4 > Main.maxTilesX)
        num4 = Main.maxTilesX;
      if (num5 < 0)
        num5 = 0;
      if (num6 > Main.maxTilesY)
        num6 = Main.maxTilesY;
      for (int i1 = num3; i1 < num4; ++i1)
      {
        for (int j1 = num5; j1 < num6; ++j1)
        {
          Main.tile[i1, j1].liquid = (byte) 0;
          if ((int) Main.tile[i1, j1].wall != wallType)
          {
            Main.tile[i1, j1].wall = (byte) 0;
            if (i1 > num3 + 1 && i1 < num4 - 2 && j1 > num5 + 1 && j1 < num6 - 2)
              WorldGen.PlaceWall(i1, j1, wallType, true);
            Main.tile[i1, j1].active = true;
            Main.tile[i1, j1].type = (byte) tileType;
          }
        }
      }
      int num7 = num3;
      int num8 = num3 + 5 + WorldGen.genRand.Next(4);
      int num9 = num5 - 3 - WorldGen.genRand.Next(3);
      int num10 = num5;
      for (int index3 = num7; index3 < num8; ++index3)
      {
        for (int index4 = num9; index4 < num10; ++index4)
        {
          if ((int) Main.tile[index3, index4].wall != wallType)
          {
            Main.tile[index3, index4].active = true;
            Main.tile[index3, index4].type = (byte) tileType;
          }
        }
      }
      int num11 = num4 - 5 - WorldGen.genRand.Next(4);
      int num12 = num4;
      int num13 = num5 - 3 - WorldGen.genRand.Next(3);
      int num14 = num5;
      for (int index5 = num11; index5 < num12; ++index5)
      {
        for (int index6 = num13; index6 < num14; ++index6)
        {
          if ((int) Main.tile[index5, index6].wall != wallType)
          {
            Main.tile[index5, index6].active = true;
            Main.tile[index5, index6].type = (byte) tileType;
          }
        }
      }
      int num15 = 1 + WorldGen.genRand.Next(2);
      int num16 = 2 + WorldGen.genRand.Next(4);
      int num17 = 0;
      for (int index7 = num3; index7 < num4; ++index7)
      {
        for (int index8 = num5 - num15; index8 < num5; ++index8)
        {
          if ((int) Main.tile[index7, index8].wall != wallType)
          {
            Main.tile[index7, index8].active = true;
            Main.tile[index7, index8].type = (byte) tileType;
          }
        }
        ++num17;
        if (num17 >= num16)
        {
          index7 += num16;
          num17 = 0;
        }
      }
      for (int i2 = num3; i2 < num4; ++i2)
      {
        for (int j2 = num6; j2 < num6 + 100; ++j2)
          WorldGen.PlaceWall(i2, j2, 2, true);
      }
      int num18 = (int) ((double) vector2.X - dxStrength1 * 0.600000023841858);
      int num19 = (int) ((double) vector2.X + dxStrength1 * 0.600000023841858);
      int num20 = (int) ((double) vector2.Y - dyStrength1 * 0.600000023841858);
      int num21 = (int) ((double) vector2.Y + dyStrength1 * 0.600000023841858);
      if (num18 < 0)
        num18 = 0;
      if (num19 > Main.maxTilesX)
        num19 = Main.maxTilesX;
      if (num20 < 0)
        num20 = 0;
      if (num21 > Main.maxTilesY)
        num21 = Main.maxTilesY;
      for (int i3 = num18; i3 < num19; ++i3)
      {
        for (int j3 = num20; j3 < num21; ++j3)
          WorldGen.PlaceWall(i3, j3, wallType, true);
      }
      int num22 = (int) ((double) vector2.X - dxStrength1 * 0.6 - 1.0);
      int num23 = (int) ((double) vector2.X + dxStrength1 * 0.6 + 1.0);
      int num24 = (int) ((double) vector2.Y - dyStrength1 * 0.6 - 1.0);
      int num25 = (int) ((double) vector2.Y + dyStrength1 * 0.6 + 1.0);
      if (num22 < 0)
        num22 = 0;
      if (num23 > Main.maxTilesX)
        num23 = Main.maxTilesX;
      if (num24 < 0)
        num24 = 0;
      if (num25 > Main.maxTilesY)
        num25 = Main.maxTilesY;
      for (int index9 = num22; index9 < num23; ++index9)
      {
        for (int index10 = num24; index10 < num25; ++index10)
          Main.tile[index9, index10].wall = (byte) wallType;
      }
      int num26 = (int) ((double) vector2.X - dxStrength1 * 0.5);
      int num27 = (int) ((double) vector2.X + dxStrength1 * 0.5);
      int num28 = (int) ((double) vector2.Y - dyStrength1 * 0.5);
      int num29 = (int) ((double) vector2.Y + dyStrength1 * 0.5);
      if (num26 < 0)
        num26 = 0;
      if (num27 > Main.maxTilesX)
        num27 = Main.maxTilesX;
      if (num28 < 0)
        num28 = 0;
      if (num29 > Main.maxTilesY)
        num29 = Main.maxTilesY;
      for (int index11 = num26; index11 < num27; ++index11)
      {
        for (int index12 = num28; index12 < num29; ++index12)
        {
          Main.tile[index11, index12].active = false;
          Main.tile[index11, index12].wall = (byte) wallType;
        }
      }
      WorldGen.DPlatX[WorldGen.numDPlats] = (int) vector2.X;
      WorldGen.DPlatY[WorldGen.numDPlats] = num29;
      ++WorldGen.numDPlats;
      vector2.X += (float) (dxStrength1 * 0.600000023841858) * (float) num2;
      vector2.Y += (float) dyStrength1 * 0.5f;
      double dxStrength2 = WorldGen.dxStrength2;
      double dyStrength2 = WorldGen.dyStrength2;
      vector2.X += (float) (dxStrength2 * 0.550000011920929) * (float) num2;
      vector2.Y -= (float) dyStrength2 * 0.5f;
      int num30 = (int) ((double) vector2.X - dxStrength2 * 0.600000023841858 - (double) WorldGen.genRand.Next(1, 3));
      int num31 = (int) ((double) vector2.X + dxStrength2 * 0.600000023841858 + (double) WorldGen.genRand.Next(1, 3));
      int num32 = (int) ((double) vector2.Y - dyStrength2 * 0.600000023841858 - (double) WorldGen.genRand.Next(1, 3));
      int num33 = (int) ((double) vector2.Y + dyStrength2 * 0.600000023841858 + (double) WorldGen.genRand.Next(6, 16));
      if (num30 < 0)
        num30 = 0;
      if (num31 > Main.maxTilesX)
        num31 = Main.maxTilesX;
      if (num32 < 0)
        num32 = 0;
      if (num33 > Main.maxTilesY)
        num33 = Main.maxTilesY;
      for (int index13 = num30; index13 < num31; ++index13)
      {
        for (int index14 = num32; index14 < num33; ++index14)
        {
          if ((int) Main.tile[index13, index14].wall != wallType)
          {
            bool flag = true;
            if (num2 < 0)
            {
              if ((double) index13 < (double) vector2.X - dxStrength2 * 0.5)
                flag = false;
            }
            else if ((double) index13 > (double) vector2.X + dxStrength2 * 0.5 - 1.0)
              flag = false;
            if (flag)
            {
              Main.tile[index13, index14].wall = (byte) 0;
              Main.tile[index13, index14].active = true;
              Main.tile[index13, index14].type = (byte) tileType;
            }
          }
        }
      }
      for (int i4 = num30; i4 < num31; ++i4)
      {
        for (int j4 = num33; j4 < num33 + 100; ++j4)
          WorldGen.PlaceWall(i4, j4, 2, true);
      }
      int num34 = (int) ((double) vector2.X - dxStrength2 * 0.5);
      int num35 = (int) ((double) vector2.X + dxStrength2 * 0.5);
      int num36 = num34;
      if (num2 < 0)
        ++num36;
      int num37 = num36 + 5 + WorldGen.genRand.Next(4);
      int num38 = num32 - 3 - WorldGen.genRand.Next(3);
      int num39 = num32;
      for (int index15 = num36; index15 < num37; ++index15)
      {
        for (int index16 = num38; index16 < num39; ++index16)
        {
          if ((int) Main.tile[index15, index16].wall != wallType)
          {
            Main.tile[index15, index16].active = true;
            Main.tile[index15, index16].type = (byte) tileType;
          }
        }
      }
      int num40 = num35 - 5 - WorldGen.genRand.Next(4);
      int num41 = num35;
      int num42 = num32 - 3 - WorldGen.genRand.Next(3);
      int num43 = num32;
      for (int index17 = num40; index17 < num41; ++index17)
      {
        for (int index18 = num42; index18 < num43; ++index18)
        {
          if ((int) Main.tile[index17, index18].wall != wallType)
          {
            Main.tile[index17, index18].active = true;
            Main.tile[index17, index18].type = (byte) tileType;
          }
        }
      }
      int num44 = 1 + WorldGen.genRand.Next(2);
      int num45 = 2 + WorldGen.genRand.Next(4);
      int num46 = 0;
      if (num2 < 0)
        ++num35;
      for (int index19 = num34 + 1; index19 < num35 - 1; ++index19)
      {
        for (int index20 = num32 - num44; index20 < num32; ++index20)
        {
          if ((int) Main.tile[index19, index20].wall != wallType)
          {
            Main.tile[index19, index20].active = true;
            Main.tile[index19, index20].type = (byte) tileType;
          }
        }
        ++num46;
        if (num46 >= num45)
        {
          index19 += num45;
          num46 = 0;
        }
      }
      int num47 = (int) ((double) vector2.X - dxStrength2 * 0.6);
      int num48 = (int) ((double) vector2.X + dxStrength2 * 0.6);
      int num49 = (int) ((double) vector2.Y - dyStrength2 * 0.6);
      int num50 = (int) ((double) vector2.Y + dyStrength2 * 0.6);
      if (num47 < 0)
        num47 = 0;
      if (num48 > Main.maxTilesX)
        num48 = Main.maxTilesX;
      if (num49 < 0)
        num49 = 0;
      if (num50 > Main.maxTilesY)
        num50 = Main.maxTilesY;
      for (int index21 = num47; index21 < num48; ++index21)
      {
        for (int index22 = num49; index22 < num50; ++index22)
          Main.tile[index21, index22].wall = (byte) 0;
      }
      int num51 = (int) ((double) vector2.X - dxStrength2 * 0.5);
      int num52 = (int) ((double) vector2.X + dxStrength2 * 0.5);
      int num53 = (int) ((double) vector2.Y - dyStrength2 * 0.5);
      int index23 = (int) ((double) vector2.Y + dyStrength2 * 0.5);
      if (num51 < 0)
        num51 = 0;
      if (num52 > Main.maxTilesX)
        num52 = Main.maxTilesX;
      if (num53 < 0)
        num53 = 0;
      if (index23 > Main.maxTilesY)
        index23 = Main.maxTilesY;
      for (int index24 = num51; index24 < num52; ++index24)
      {
        for (int index25 = num53; index25 < index23; ++index25)
        {
          Main.tile[index24, index25].active = false;
          Main.tile[index24, index25].wall = (byte) 0;
        }
      }
      for (int index26 = num51; index26 < num52; ++index26)
      {
        if (!Main.tile[index26, index23].active)
        {
          Main.tile[index26, index23].active = true;
          Main.tile[index26, index23].type = (byte) 19;
        }
      }
      Main.dungeonX = (int) vector2.X;
      Main.dungeonY = index23;
      int index27 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37);
      Main.npc[index27].homeless = false;
      Main.npc[index27].homeTileX = Main.dungeonX;
      Main.npc[index27].homeTileY = Main.dungeonY;
      if (num2 == 1)
      {
        int num54 = 0;
        for (int index28 = num52; index28 < num52 + 25; ++index28)
        {
          ++num54;
          for (int index29 = index23 + num54; index29 < index23 + 25; ++index29)
          {
            Main.tile[index28, index29].active = true;
            Main.tile[index28, index29].type = (byte) tileType;
          }
        }
      }
      else
      {
        int num55 = 0;
        for (int index30 = num51; index30 > num51 - 25; --index30)
        {
          ++num55;
          for (int index31 = index23 + num55; index31 < index23 + 25; ++index31)
          {
            Main.tile[index30, index31].active = true;
            Main.tile[index30, index31].type = (byte) tileType;
          }
        }
      }
      int num56 = 1 + WorldGen.genRand.Next(2);
      int num57 = 2 + WorldGen.genRand.Next(4);
      int num58 = 0;
      int num59 = (int) ((double) vector2.X - dxStrength2 * 0.5);
      int num60 = (int) ((double) vector2.X + dxStrength2 * 0.5);
      int num61 = num59 + 2;
      int num62 = num60 - 2;
      for (int i5 = num61; i5 < num62; ++i5)
      {
        for (int j5 = num53; j5 < index23; ++j5)
          WorldGen.PlaceWall(i5, j5, wallType, true);
        ++num58;
        if (num58 >= num57)
        {
          i5 += num57 * 2;
          num58 = 0;
        }
      }
      vector2.X -= (float) (dxStrength2 * 0.600000023841858) * (float) num2;
      vector2.Y += (float) dyStrength2 * 0.5f;
      double num63 = 15.0;
      double num64 = 3.0;
      vector2.Y -= (float) num64 * 0.5f;
      int num65 = (int) ((double) vector2.X - num63 * 0.5);
      int num66 = (int) ((double) vector2.X + num63 * 0.5);
      int num67 = (int) ((double) vector2.Y - num64 * 0.5);
      int num68 = (int) ((double) vector2.Y + num64 * 0.5);
      if (num65 < 0)
        num65 = 0;
      if (num66 > Main.maxTilesX)
        num66 = Main.maxTilesX;
      if (num67 < 0)
        num67 = 0;
      if (num68 > Main.maxTilesY)
        num68 = Main.maxTilesY;
      for (int index32 = num65; index32 < num66; ++index32)
      {
        for (int index33 = num67; index33 < num68; ++index33)
          Main.tile[index32, index33].active = false;
      }
      if (num2 < 0)
        --vector2.X;
      WorldGen.PlaceTile((int) vector2.X, (int) vector2.Y + 1, 10);
    }

    public static bool AddBuriedChest(
      int i,
      int j,
      int contain = 0,
      bool notNearOtherChests = false,
      int Style = -1)
    {
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
      for (int index1 = j; index1 < Main.maxTilesY; ++index1)
      {
        if (Main.tile[i, index1].active && Main.tileSolid[(int) Main.tile[i, index1].type])
        {
          bool flag = false;
          int num1 = i;
          int num2 = index1;
          int style = 0;
          if ((double) num2 >= Main.worldSurface + 25.0 || contain > 0)
            style = 1;
          if (Style >= 0)
            style = Style;
          if (num2 > Main.maxTilesY - 205 && contain == 0)
          {
            switch (WorldGen.hellChest)
            {
              case 0:
                contain = 274;
                style = 4;
                flag = true;
                break;
              case 1:
                contain = 220;
                style = 4;
                flag = true;
                break;
              case 2:
                contain = 112;
                style = 4;
                flag = true;
                break;
              case 3:
                contain = 218;
                style = 4;
                flag = true;
                WorldGen.hellChest = 0;
                break;
            }
          }
          int index2 = WorldGen.PlaceChest(num1 - 1, num2 - 1, notNearOtherChests: notNearOtherChests, style: style);
          if (index2 < 0)
            return false;
          if (flag)
            ++WorldGen.hellChest;
          int index3 = 0;
          while (index3 == 0)
          {
            if ((double) num2 < Main.worldSurface + 25.0)
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                int num3 = WorldGen.genRand.Next(6);
                if (num3 == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(280);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 1)
                {
                  Main.chest[index2].item[index3].SetDefaults(281);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 2)
                {
                  Main.chest[index2].item[index3].SetDefaults(284);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 3)
                {
                  Main.chest[index2].item[index3].SetDefaults(282);
                  Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(50, 75);
                }
                if (num3 == 4)
                {
                  Main.chest[index2].item[index3].SetDefaults(279);
                  Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(25, 50);
                }
                if (num3 == 5)
                {
                  Main.chest[index2].item[index3].SetDefaults(285);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                ++index3;
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(168);
                Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(3, 6);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num4 = WorldGen.genRand.Next(2);
                int num5 = WorldGen.genRand.Next(8) + 3;
                if (num4 == 0)
                  Main.chest[index2].item[index3].SetDefaults(20);
                if (num4 == 1)
                  Main.chest[index2].item[index3].SetDefaults(22);
                Main.chest[index2].item[index3].stack = num5;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num6 = WorldGen.genRand.Next(2);
                int num7 = WorldGen.genRand.Next(26) + 25;
                if (num6 == 0)
                  Main.chest[index2].item[index3].SetDefaults(40);
                if (num6 == 1)
                  Main.chest[index2].item[index3].SetDefaults(42);
                Main.chest[index2].item[index3].stack = num7;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num8 = WorldGen.genRand.Next(1);
                int num9 = WorldGen.genRand.Next(3) + 3;
                if (num8 == 0)
                  Main.chest[index2].item[index3].SetDefaults(28);
                Main.chest[index2].item[index3].stack = num9;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num10 = WorldGen.genRand.Next(4);
                int num11 = WorldGen.genRand.Next(1, 3);
                if (num10 == 0)
                  Main.chest[index2].item[index3].SetDefaults(292);
                if (num10 == 1)
                  Main.chest[index2].item[index3].SetDefaults(298);
                if (num10 == 2)
                  Main.chest[index2].item[index3].SetDefaults(299);
                if (num10 == 3)
                  Main.chest[index2].item[index3].SetDefaults(290);
                Main.chest[index2].item[index3].stack = num11;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num12 = WorldGen.genRand.Next(2);
                int num13 = WorldGen.genRand.Next(11) + 10;
                if (num12 == 0)
                  Main.chest[index2].item[index3].SetDefaults(8);
                if (num12 == 1)
                  Main.chest[index2].item[index3].SetDefaults(31);
                Main.chest[index2].item[index3].stack = num13;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(72);
                Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(10, 30);
                ++index3;
              }
            }
            else if ((double) num2 < Main.rockLayer)
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                int num14 = WorldGen.genRand.Next(7);
                if (num14 == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(49);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num14 == 1)
                {
                  Main.chest[index2].item[index3].SetDefaults(50);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num14 == 2)
                  Main.chest[index2].item[index3].SetDefaults(52);
                if (num14 == 3)
                {
                  Main.chest[index2].item[index3].SetDefaults(53);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num14 == 4)
                {
                  Main.chest[index2].item[index3].SetDefaults(54);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num14 == 5)
                {
                  Main.chest[index2].item[index3].SetDefaults(55);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num14 == 6)
                {
                  Main.chest[index2].item[index3].SetDefaults(51);
                  Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(26) + 25;
                }
                ++index3;
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(166);
                Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(10, 20);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num15 = WorldGen.genRand.Next(2);
                int num16 = WorldGen.genRand.Next(10) + 5;
                if (num15 == 0)
                  Main.chest[index2].item[index3].SetDefaults(22);
                if (num15 == 1)
                  Main.chest[index2].item[index3].SetDefaults(21);
                Main.chest[index2].item[index3].stack = num16;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num17 = WorldGen.genRand.Next(2);
                int num18 = WorldGen.genRand.Next(25) + 25;
                if (num17 == 0)
                  Main.chest[index2].item[index3].SetDefaults(40);
                if (num17 == 1)
                  Main.chest[index2].item[index3].SetDefaults(42);
                Main.chest[index2].item[index3].stack = num18;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num19 = WorldGen.genRand.Next(1);
                int num20 = WorldGen.genRand.Next(3) + 3;
                if (num19 == 0)
                  Main.chest[index2].item[index3].SetDefaults(28);
                Main.chest[index2].item[index3].stack = num20;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num21 = WorldGen.genRand.Next(7);
                int num22 = WorldGen.genRand.Next(1, 3);
                if (num21 == 0)
                  Main.chest[index2].item[index3].SetDefaults(289);
                if (num21 == 1)
                  Main.chest[index2].item[index3].SetDefaults(298);
                if (num21 == 2)
                  Main.chest[index2].item[index3].SetDefaults(299);
                if (num21 == 3)
                  Main.chest[index2].item[index3].SetDefaults(290);
                if (num21 == 4)
                  Main.chest[index2].item[index3].SetDefaults(303);
                if (num21 == 5)
                  Main.chest[index2].item[index3].SetDefaults(291);
                if (num21 == 6)
                  Main.chest[index2].item[index3].SetDefaults(304);
                Main.chest[index2].item[index3].stack = num22;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num23 = WorldGen.genRand.Next(11) + 10;
                Main.chest[index2].item[index3].SetDefaults(8);
                Main.chest[index2].item[index3].stack = num23;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(72);
                Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(50, 90);
                ++index3;
              }
            }
            else if (num2 < Main.maxTilesY - 250)
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                int num24 = WorldGen.genRand.Next(7);
                if (num24 == 2 && WorldGen.genRand.Next(2) == 0)
                  num24 = WorldGen.genRand.Next(7);
                if (num24 == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(49);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num24 == 1)
                {
                  Main.chest[index2].item[index3].SetDefaults(50);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num24 == 2)
                {
                  Main.chest[index2].item[index3].SetDefaults(52);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num24 == 3)
                {
                  Main.chest[index2].item[index3].SetDefaults(53);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num24 == 4)
                {
                  Main.chest[index2].item[index3].SetDefaults(54);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num24 == 5)
                {
                  Main.chest[index2].item[index3].SetDefaults(55);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num24 == 6)
                {
                  Main.chest[index2].item[index3].SetDefaults(51);
                  Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(26) + 25;
                }
                ++index3;
              }
              if (WorldGen.genRand.Next(5) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(43);
                ++index3;
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(167);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num25 = WorldGen.genRand.Next(2);
                int num26 = WorldGen.genRand.Next(8) + 3;
                if (num25 == 0)
                  Main.chest[index2].item[index3].SetDefaults(19);
                if (num25 == 1)
                  Main.chest[index2].item[index3].SetDefaults(21);
                Main.chest[index2].item[index3].stack = num26;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num27 = WorldGen.genRand.Next(2);
                int num28 = WorldGen.genRand.Next(26) + 25;
                if (num27 == 0)
                  Main.chest[index2].item[index3].SetDefaults(41);
                if (num27 == 1)
                  Main.chest[index2].item[index3].SetDefaults(279);
                Main.chest[index2].item[index3].stack = num28;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num29 = WorldGen.genRand.Next(1);
                int num30 = WorldGen.genRand.Next(3) + 3;
                if (num29 == 0)
                  Main.chest[index2].item[index3].SetDefaults(188);
                Main.chest[index2].item[index3].stack = num30;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num31 = WorldGen.genRand.Next(6);
                int num32 = WorldGen.genRand.Next(1, 3);
                if (num31 == 0)
                  Main.chest[index2].item[index3].SetDefaults(296);
                if (num31 == 1)
                  Main.chest[index2].item[index3].SetDefaults(295);
                if (num31 == 2)
                  Main.chest[index2].item[index3].SetDefaults(299);
                if (num31 == 3)
                  Main.chest[index2].item[index3].SetDefaults(302);
                if (num31 == 4)
                  Main.chest[index2].item[index3].SetDefaults(303);
                if (num31 == 5)
                  Main.chest[index2].item[index3].SetDefaults(305);
                Main.chest[index2].item[index3].stack = num32;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 1)
              {
                int num33 = WorldGen.genRand.Next(4);
                int num34 = WorldGen.genRand.Next(1, 3);
                if (num33 == 0)
                  Main.chest[index2].item[index3].SetDefaults(301);
                if (num33 == 1)
                  Main.chest[index2].item[index3].SetDefaults(302);
                if (num33 == 2)
                  Main.chest[index2].item[index3].SetDefaults(297);
                if (num33 == 3)
                  Main.chest[index2].item[index3].SetDefaults(304);
                Main.chest[index2].item[index3].stack = num34;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num35 = WorldGen.genRand.Next(2);
                int num36 = WorldGen.genRand.Next(15) + 15;
                if (num35 == 0)
                  Main.chest[index2].item[index3].SetDefaults(8);
                if (num35 == 1)
                  Main.chest[index2].item[index3].SetDefaults(282);
                Main.chest[index2].item[index3].stack = num36;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(73);
                Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(1, 3);
                ++index3;
              }
            }
            else
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                int num37 = WorldGen.genRand.Next(4);
                if (num37 == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(49);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num37 == 1)
                {
                  Main.chest[index2].item[index3].SetDefaults(50);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num37 == 2)
                {
                  Main.chest[index2].item[index3].SetDefaults(53);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num37 == 3)
                {
                  Main.chest[index2].item[index3].SetDefaults(54);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                ++index3;
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(167);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num38 = WorldGen.genRand.Next(2);
                int num39 = WorldGen.genRand.Next(15) + 15;
                if (num38 == 0)
                  Main.chest[index2].item[index3].SetDefaults(117);
                if (num38 == 1)
                  Main.chest[index2].item[index3].SetDefaults(19);
                Main.chest[index2].item[index3].stack = num39;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num40 = WorldGen.genRand.Next(2);
                int num41 = WorldGen.genRand.Next(25) + 50;
                if (num40 == 0)
                  Main.chest[index2].item[index3].SetDefaults(265);
                if (num40 == 1)
                  Main.chest[index2].item[index3].SetDefaults(278);
                Main.chest[index2].item[index3].stack = num41;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num42 = WorldGen.genRand.Next(2);
                int num43 = WorldGen.genRand.Next(15) + 15;
                if (num42 == 0)
                  Main.chest[index2].item[index3].SetDefaults(226);
                if (num42 == 1)
                  Main.chest[index2].item[index3].SetDefaults(227);
                Main.chest[index2].item[index3].stack = num43;
                ++index3;
              }
              if (WorldGen.genRand.Next(4) > 0)
              {
                int num44 = WorldGen.genRand.Next(7);
                int num45 = WorldGen.genRand.Next(1, 3);
                if (num44 == 0)
                  Main.chest[index2].item[index3].SetDefaults(296);
                if (num44 == 1)
                  Main.chest[index2].item[index3].SetDefaults(295);
                if (num44 == 2)
                  Main.chest[index2].item[index3].SetDefaults(293);
                if (num44 == 3)
                  Main.chest[index2].item[index3].SetDefaults(288);
                if (num44 == 4)
                  Main.chest[index2].item[index3].SetDefaults(294);
                if (num44 == 5)
                  Main.chest[index2].item[index3].SetDefaults(297);
                if (num44 == 6)
                  Main.chest[index2].item[index3].SetDefaults(304);
                Main.chest[index2].item[index3].stack = num45;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num46 = WorldGen.genRand.Next(5);
                int num47 = WorldGen.genRand.Next(1, 3);
                if (num46 == 0)
                  Main.chest[index2].item[index3].SetDefaults(305);
                if (num46 == 1)
                  Main.chest[index2].item[index3].SetDefaults(301);
                if (num46 == 2)
                  Main.chest[index2].item[index3].SetDefaults(302);
                if (num46 == 3)
                  Main.chest[index2].item[index3].SetDefaults(288);
                if (num46 == 4)
                  Main.chest[index2].item[index3].SetDefaults(300);
                Main.chest[index2].item[index3].stack = num47;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num48 = WorldGen.genRand.Next(2);
                int num49 = WorldGen.genRand.Next(15) + 15;
                if (num48 == 0)
                  Main.chest[index2].item[index3].SetDefaults(8);
                if (num48 == 1)
                  Main.chest[index2].item[index3].SetDefaults(282);
                Main.chest[index2].item[index3].stack = num49;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(73);
                Main.chest[index2].item[index3].stack = WorldGen.genRand.Next(2, 5);
                ++index3;
              }
            }
          }
          return true;
        }
      }
      return false;
    }

    public static bool OpenDoor(int i, int j, int direction)
    {
      if (Main.tile[i, j - 1] == null)
        Main.tile[i, j - 1] = new Tile();
      if (Main.tile[i, j - 2] == null)
        Main.tile[i, j - 2] = new Tile();
      if (Main.tile[i, j + 1] == null)
        Main.tile[i, j + 1] = new Tile();
      if (Main.tile[i, j] == null)
        Main.tile[i, j] = new Tile();
      int index1 = Main.tile[i, j - 1].frameY != (short) 0 || (int) Main.tile[i, j - 1].type != (int) Main.tile[i, j].type ? (Main.tile[i, j - 2].frameY != (short) 0 || (int) Main.tile[i, j - 2].type != (int) Main.tile[i, j].type ? (Main.tile[i, j + 1].frameY != (short) 0 || (int) Main.tile[i, j + 1].type != (int) Main.tile[i, j].type ? j : j + 1) : j - 2) : j - 1;
      short num = 0;
      int index2;
      int i1;
      if (direction == -1)
      {
        index2 = i - 1;
        num = (short) 36;
        i1 = i - 1;
      }
      else
      {
        index2 = i;
        i1 = i + 1;
      }
      bool flag = true;
      for (int j1 = index1; j1 < index1 + 3; ++j1)
      {
        if (Main.tile[i1, j1] == null)
          Main.tile[i1, j1] = new Tile();
        if (Main.tile[i1, j1].active)
        {
          if (Main.tileCut[(int) Main.tile[i1, j1].type] || Main.tile[i1, j1].type == (byte) 3 || Main.tile[i1, j1].type == (byte) 24 || Main.tile[i1, j1].type == (byte) 52 || Main.tile[i1, j1].type == (byte) 61 || Main.tile[i1, j1].type == (byte) 62 || Main.tile[i1, j1].type == (byte) 69 || Main.tile[i1, j1].type == (byte) 71 || Main.tile[i1, j1].type == (byte) 73 || Main.tile[i1, j1].type == (byte) 74 || Main.tile[i1, j1].type == (byte) 110 || Main.tile[i1, j1].type == (byte) 113 || Main.tile[i1, j1].type == (byte) 115)
          {
            WorldGen.KillTile(i1, j1);
          }
          else
          {
            flag = false;
            break;
          }
        }
      }
      if (flag)
      {
        if (Main.netMode != 1)
        {
          for (int index3 = index2; index3 <= index2 + 1; ++index3)
          {
            for (int index4 = index1; index4 <= index1 + 2; ++index4)
            {
              if (WorldGen.numNoWire < WorldGen.maxWire - 1)
              {
                WorldGen.noWireX[WorldGen.numNoWire] = index3;
                WorldGen.noWireY[WorldGen.numNoWire] = index4;
                ++WorldGen.numNoWire;
              }
            }
          }
        }
        Main.PlaySound(8, i * 16, j * 16);
        Main.tile[index2, index1].active = true;
        Main.tile[index2, index1].type = (byte) 11;
        Main.tile[index2, index1].frameY = (short) 0;
        Main.tile[index2, index1].frameX = num;
        if (Main.tile[index2 + 1, index1] == null)
          Main.tile[index2 + 1, index1] = new Tile();
        Main.tile[index2 + 1, index1].active = true;
        Main.tile[index2 + 1, index1].type = (byte) 11;
        Main.tile[index2 + 1, index1].frameY = (short) 0;
        Main.tile[index2 + 1, index1].frameX = (short) ((int) num + 18);
        if (Main.tile[index2, index1 + 1] == null)
          Main.tile[index2, index1 + 1] = new Tile();
        Main.tile[index2, index1 + 1].active = true;
        Main.tile[index2, index1 + 1].type = (byte) 11;
        Main.tile[index2, index1 + 1].frameY = (short) 18;
        Main.tile[index2, index1 + 1].frameX = num;
        if (Main.tile[index2 + 1, index1 + 1] == null)
          Main.tile[index2 + 1, index1 + 1] = new Tile();
        Main.tile[index2 + 1, index1 + 1].active = true;
        Main.tile[index2 + 1, index1 + 1].type = (byte) 11;
        Main.tile[index2 + 1, index1 + 1].frameY = (short) 18;
        Main.tile[index2 + 1, index1 + 1].frameX = (short) ((int) num + 18);
        if (Main.tile[index2, index1 + 2] == null)
          Main.tile[index2, index1 + 2] = new Tile();
        Main.tile[index2, index1 + 2].active = true;
        Main.tile[index2, index1 + 2].type = (byte) 11;
        Main.tile[index2, index1 + 2].frameY = (short) 36;
        Main.tile[index2, index1 + 2].frameX = num;
        if (Main.tile[index2 + 1, index1 + 2] == null)
          Main.tile[index2 + 1, index1 + 2] = new Tile();
        Main.tile[index2 + 1, index1 + 2].active = true;
        Main.tile[index2 + 1, index1 + 2].type = (byte) 11;
        Main.tile[index2 + 1, index1 + 2].frameY = (short) 36;
        Main.tile[index2 + 1, index1 + 2].frameX = (short) ((int) num + 18);
        for (int i2 = index2 - 1; i2 <= index2 + 2; ++i2)
        {
          for (int j2 = index1 - 1; j2 <= index1 + 2; ++j2)
            WorldGen.TileFrame(i2, j2);
        }
      }
      return flag;
    }

    public static void Check1xX(int x, int j, byte type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = j - (int) Main.tile[x, j].frameY / 18;
      int frameX = (int) Main.tile[x, j].frameX;
      int num2 = 3;
      if (type == (byte) 92)
        num2 = 6;
      bool flag = false;
      for (int index = 0; index < num2; ++index)
      {
        if (Main.tile[x, num1 + index] == null)
          Main.tile[x, num1 + index] = new Tile();
        if (!Main.tile[x, num1 + index].active)
          flag = true;
        else if ((int) Main.tile[x, num1 + index].type != (int) type)
          flag = true;
        else if ((int) Main.tile[x, num1 + index].frameY != index * 18)
          flag = true;
        else if ((int) Main.tile[x, num1 + index].frameX != frameX)
          flag = true;
      }
      if (Main.tile[x, num1 + num2] == null)
        Main.tile[x, num1 + num2] = new Tile();
      if (!Main.tile[x, num1 + num2].active)
        flag = true;
      if (!Main.tileSolid[(int) Main.tile[x, num1 + num2].type])
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int index = 0; index < num2; ++index)
      {
        if ((int) Main.tile[x, num1 + index].type == (int) type)
          WorldGen.KillTile(x, num1 + index);
      }
      if (type == (byte) 92)
        Item.NewItem(x * 16, j * 16, 32, 32, 341);
      if (type == (byte) 93)
        Item.NewItem(x * 16, j * 16, 32, 32, 342);
      WorldGen.destroyObject = false;
    }

    public static void Check2xX(int i, int j, byte type)
    {
      if (WorldGen.destroyObject)
        return;
      int i1 = i;
      int frameX1 = (int) Main.tile[i, j].frameX;
      while (frameX1 >= 36)
        frameX1 -= 36;
      if (frameX1 == 18)
        --i1;
      if (Main.tile[i1, j] == null)
        Main.tile[i1, j] = new Tile();
      int index1 = j - (int) Main.tile[i1, j].frameY / 18;
      if (Main.tile[i1, index1] == null)
        Main.tile[i1, index1] = new Tile();
      int frameX2 = (int) Main.tile[i1, j].frameX;
      int num1 = 3;
      if (type == (byte) 104)
        num1 = 5;
      bool flag = false;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        if (Main.tile[i1, index1 + index2] == null)
          Main.tile[i1, index1 + index2] = new Tile();
        if (!Main.tile[i1, index1 + index2].active)
          flag = true;
        else if ((int) Main.tile[i1, index1 + index2].type != (int) type)
          flag = true;
        else if ((int) Main.tile[i1, index1 + index2].frameY != index2 * 18)
          flag = true;
        else if ((int) Main.tile[i1, index1 + index2].frameX != frameX2)
          flag = true;
        if (Main.tile[i1 + 1, index1 + index2] == null)
          Main.tile[i1 + 1, index1 + index2] = new Tile();
        if (!Main.tile[i1 + 1, index1 + index2].active)
          flag = true;
        else if ((int) Main.tile[i1 + 1, index1 + index2].type != (int) type)
          flag = true;
        else if ((int) Main.tile[i1 + 1, index1 + index2].frameY != index2 * 18)
          flag = true;
        else if ((int) Main.tile[i1 + 1, index1 + index2].frameX != frameX2 + 18)
          flag = true;
      }
      if (Main.tile[i1, index1 + num1] == null)
        Main.tile[i1, index1 + num1] = new Tile();
      if (!Main.tile[i1, index1 + num1].active)
        flag = true;
      if (!Main.tileSolid[(int) Main.tile[i1, index1 + num1].type])
        flag = true;
      if (Main.tile[i1 + 1, index1 + num1] == null)
        Main.tile[i1 + 1, index1 + num1] = new Tile();
      if (!Main.tile[i1 + 1, index1 + num1].active)
        flag = true;
      if (!Main.tileSolid[(int) Main.tile[i1 + 1, index1 + num1].type])
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int index3 = 0; index3 < num1; ++index3)
      {
        if ((int) Main.tile[i1, index1 + index3].type == (int) type)
          WorldGen.KillTile(i1, index1 + index3);
        if ((int) Main.tile[i1 + 1, index1 + index3].type == (int) type)
          WorldGen.KillTile(i1 + 1, index1 + index3);
      }
      if (type == (byte) 104)
        Item.NewItem(i1 * 16, j * 16, 32, 32, 359);
      if (type == (byte) 105)
      {
        int num2 = frameX2 / 36;
        int Type;
        switch (num2)
        {
          case 0:
            Type = 360;
            break;
          case 1:
            Type = 52;
            break;
          default:
            Type = 438 + num2 - 2;
            break;
        }
        Item.NewItem(i1 * 16, j * 16, 32, 32, Type);
      }
      WorldGen.destroyObject = false;
    }

    public static void Place1xX(int x, int y, int type, int style = 0)
    {
      int num1 = style * 18;
      int num2 = 3;
      if (type == 92)
        num2 = 6;
      bool flag = true;
      for (int index = y - num2 + 1; index < y + 1; ++index)
      {
        if (Main.tile[x, index] == null)
          Main.tile[x, index] = new Tile();
        if (Main.tile[x, index].active)
          flag = false;
        if (type == 93 && Main.tile[x, index].liquid > (byte) 0)
          flag = false;
      }
      if (!flag || !Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type])
        return;
      for (int index = 0; index < num2; ++index)
      {
        Main.tile[x, y - num2 + 1 + index].active = true;
        Main.tile[x, y - num2 + 1 + index].frameY = (short) (index * 18);
        Main.tile[x, y - num2 + 1 + index].frameX = (short) num1;
        Main.tile[x, y - num2 + 1 + index].type = (byte) type;
      }
    }

    public static void Place2xX(int x, int y, int type, int style = 0)
    {
      int num1 = style * 36;
      int num2 = 3;
      if (type == 104)
        num2 = 5;
      bool flag = true;
      for (int index = y - num2 + 1; index < y + 1; ++index)
      {
        if (Main.tile[x, index] == null)
          Main.tile[x, index] = new Tile();
        if (Main.tile[x, index].active)
          flag = false;
        if (Main.tile[x + 1, index] == null)
          Main.tile[x + 1, index] = new Tile();
        if (Main.tile[x + 1, index].active)
          flag = false;
      }
      if (!flag || !Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || !Main.tile[x + 1, y + 1].active || !Main.tileSolid[(int) Main.tile[x + 1, y + 1].type])
        return;
      for (int index = 0; index < num2; ++index)
      {
        Main.tile[x, y - num2 + 1 + index].active = true;
        Main.tile[x, y - num2 + 1 + index].frameY = (short) (index * 18);
        Main.tile[x, y - num2 + 1 + index].frameX = (short) num1;
        Main.tile[x, y - num2 + 1 + index].type = (byte) type;
        Main.tile[x + 1, y - num2 + 1 + index].active = true;
        Main.tile[x + 1, y - num2 + 1 + index].frameY = (short) (index * 18);
        Main.tile[x + 1, y - num2 + 1 + index].frameX = (short) (num1 + 18);
        Main.tile[x + 1, y - num2 + 1 + index].type = (byte) type;
      }
    }

    public static void Check1x2(int x, int j, byte type)
    {
      if (WorldGen.destroyObject)
        return;
      int j1 = j;
      bool flag = true;
      if (Main.tile[x, j1] == null)
        Main.tile[x, j1] = new Tile();
      if (Main.tile[x, j1 + 1] == null)
        Main.tile[x, j1 + 1] = new Tile();
      int frameY = (int) Main.tile[x, j1].frameY;
      int num = 0;
      while (frameY >= 40)
      {
        frameY -= 40;
        ++num;
      }
      if (frameY == 18)
        --j1;
      if (Main.tile[x, j1] == null)
        Main.tile[x, j1] = new Tile();
      if ((int) Main.tile[x, j1].frameY == 40 * num && (int) Main.tile[x, j1 + 1].frameY == 40 * num + 18 && (int) Main.tile[x, j1].type == (int) type && (int) Main.tile[x, j1 + 1].type == (int) type)
        flag = false;
      if (Main.tile[x, j1 + 2] == null)
        Main.tile[x, j1 + 2] = new Tile();
      if (!Main.tile[x, j1 + 2].active || !Main.tileSolid[(int) Main.tile[x, j1 + 2].type])
        flag = true;
      if (Main.tile[x, j1 + 2].type != (byte) 2 && Main.tile[x, j1 + 2].type != (byte) 109 && Main.tile[x, j1 + 2].type != (byte) 147 && Main.tile[x, j1].type == (byte) 20)
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[x, j1].type == (int) type)
        WorldGen.KillTile(x, j1);
      if ((int) Main.tile[x, j1 + 1].type == (int) type)
        WorldGen.KillTile(x, j1 + 1);
      switch (type)
      {
        case 15:
          if (num == 1)
          {
            Item.NewItem(x * 16, j1 * 16, 32, 32, 358);
            break;
          }
          Item.NewItem(x * 16, j1 * 16, 32, 32, 34);
          break;
        case 134:
          Item.NewItem(x * 16, j1 * 16, 32, 32, 525);
          break;
      }
      WorldGen.destroyObject = false;
    }

    public static void CheckOnTable1x1(int x, int y, int type)
    {
      if (Main.tile[x, y + 1] == null || Main.tile[x, y + 1].active && Main.tileTable[(int) Main.tile[x, y + 1].type])
        return;
      if (type == 78)
      {
        if (Main.tile[x, y + 1].active && Main.tileSolid[(int) Main.tile[x, y + 1].type])
          return;
        WorldGen.KillTile(x, y);
      }
      else
        WorldGen.KillTile(x, y);
    }

    public static void CheckSign(int x, int y, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = x - 2;
      int num2 = x + 3;
      int num3 = y - 2;
      int num4 = y + 3;
      if (num1 < 0 || num2 > Main.maxTilesX || num3 < 0 || num4 > Main.maxTilesY)
        return;
      bool flag = false;
      for (int index1 = num1; index1 < num2; ++index1)
      {
        for (int index2 = num3; index2 < num4; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
        }
      }
      int num5 = (int) Main.tile[x, y].frameX / 18;
      int num6 = (int) Main.tile[x, y].frameY / 18;
      while (num5 > 1)
        num5 -= 2;
      int x1 = x - num5;
      int y1 = y - num6;
      int num7 = (int) Main.tile[x1, y1].frameX / 18 / 2;
      int num8 = x1;
      int num9 = x1 + 2;
      int num10 = y1;
      int num11 = y1 + 2;
      int num12 = 0;
      for (int index3 = num8; index3 < num9; ++index3)
      {
        int num13 = 0;
        for (int index4 = num10; index4 < num11; ++index4)
        {
          if (!Main.tile[index3, index4].active || (int) Main.tile[index3, index4].type != type)
          {
            flag = true;
            break;
          }
          if ((int) Main.tile[index3, index4].frameX / 18 != num12 + num7 * 2 || (int) Main.tile[index3, index4].frameY / 18 != num13)
          {
            flag = true;
            break;
          }
          ++num13;
        }
        ++num12;
      }
      if (!flag)
      {
        if (type == 85)
        {
          if (Main.tile[x1, y1 + 2].active && Main.tileSolid[(int) Main.tile[x1, y1 + 2].type] && Main.tile[x1 + 1, y1 + 2].active && Main.tileSolid[(int) Main.tile[x1 + 1, y1 + 2].type])
            num7 = 0;
          else
            flag = true;
        }
        else if (Main.tile[x1, y1 + 2].active && Main.tileSolid[(int) Main.tile[x1, y1 + 2].type] && Main.tile[x1 + 1, y1 + 2].active && Main.tileSolid[(int) Main.tile[x1 + 1, y1 + 2].type])
          num7 = 0;
        else if (Main.tile[x1, y1 - 1].active && Main.tileSolid[(int) Main.tile[x1, y1 - 1].type] && !Main.tileSolidTop[(int) Main.tile[x1, y1 - 1].type] && Main.tile[x1 + 1, y1 - 1].active && Main.tileSolid[(int) Main.tile[x1 + 1, y1 - 1].type] && !Main.tileSolidTop[(int) Main.tile[x1 + 1, y1 - 1].type])
          num7 = 1;
        else if (Main.tile[x1 - 1, y1].active && Main.tileSolid[(int) Main.tile[x1 - 1, y1].type] && !Main.tileSolidTop[(int) Main.tile[x1 - 1, y1].type] && Main.tile[x1 - 1, y1 + 1].active && Main.tileSolid[(int) Main.tile[x1 - 1, y1 + 1].type] && !Main.tileSolidTop[(int) Main.tile[x1 - 1, y1 + 1].type])
          num7 = 2;
        else if (Main.tile[x1 + 2, y1].active && Main.tileSolid[(int) Main.tile[x1 + 2, y1].type] && !Main.tileSolidTop[(int) Main.tile[x1 + 2, y1].type] && Main.tile[x1 + 2, y1 + 1].active && Main.tileSolid[(int) Main.tile[x1 + 2, y1 + 1].type] && !Main.tileSolidTop[(int) Main.tile[x1 + 2, y1 + 1].type])
          num7 = 3;
        else
          flag = true;
      }
      if (flag)
      {
        WorldGen.destroyObject = true;
        for (int i = num8; i < num9; ++i)
        {
          for (int j = num10; j < num11; ++j)
          {
            if ((int) Main.tile[i, j].type == type)
              WorldGen.KillTile(i, j);
          }
        }
        Sign.KillSign(x1, y1);
        if (type == 85)
          Item.NewItem(x * 16, y * 16, 32, 32, 321);
        else
          Item.NewItem(x * 16, y * 16, 32, 32, 171);
        WorldGen.destroyObject = false;
      }
      else
      {
        int num14 = 36 * num7;
        for (int index5 = 0; index5 < 2; ++index5)
        {
          for (int index6 = 0; index6 < 2; ++index6)
          {
            Main.tile[x1 + index5, y1 + index6].active = true;
            Main.tile[x1 + index5, y1 + index6].type = (byte) type;
            Main.tile[x1 + index5, y1 + index6].frameX = (short) (num14 + 18 * index5);
            Main.tile[x1 + index5, y1 + index6].frameY = (short) (18 * index6);
          }
        }
      }
    }

    public static bool PlaceSign(int x, int y, int type)
    {
      int num1 = x - 2;
      int num2 = x + 3;
      int num3 = y - 2;
      int num4 = y + 3;
      if (num1 < 0 || num2 > Main.maxTilesX || num3 < 0 || num4 > Main.maxTilesY)
        return false;
      for (int index1 = num1; index1 < num2; ++index1)
      {
        for (int index2 = num3; index2 < num4; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
        }
      }
      int index3 = x;
      int index4 = y;
      int num5 = 0;
      switch (type)
      {
        case 55:
          if (Main.tile[x, y + 1].active && Main.tileSolid[(int) Main.tile[x, y + 1].type] && Main.tile[x + 1, y + 1].active && Main.tileSolid[(int) Main.tile[x + 1, y + 1].type])
          {
            --index4;
            num5 = 0;
            break;
          }
          if (Main.tile[x, y - 1].active && Main.tileSolid[(int) Main.tile[x, y - 1].type] && !Main.tileSolidTop[(int) Main.tile[x, y - 1].type] && Main.tile[x + 1, y - 1].active && Main.tileSolid[(int) Main.tile[x + 1, y - 1].type] && !Main.tileSolidTop[(int) Main.tile[x + 1, y - 1].type])
          {
            num5 = 1;
            break;
          }
          if (Main.tile[x - 1, y].active && Main.tileSolid[(int) Main.tile[x - 1, y].type] && !Main.tileSolidTop[(int) Main.tile[x - 1, y].type] && !Main.tileNoAttach[(int) Main.tile[x - 1, y].type] && Main.tile[x - 1, y + 1].active && Main.tileSolid[(int) Main.tile[x - 1, y + 1].type] && !Main.tileSolidTop[(int) Main.tile[x - 1, y + 1].type] && !Main.tileNoAttach[(int) Main.tile[x - 1, y + 1].type])
          {
            num5 = 2;
            break;
          }
          if (!Main.tile[x + 1, y].active || !Main.tileSolid[(int) Main.tile[x + 1, y].type] || Main.tileSolidTop[(int) Main.tile[x + 1, y].type] || Main.tileNoAttach[(int) Main.tile[x + 1, y].type] || !Main.tile[x + 1, y + 1].active || !Main.tileSolid[(int) Main.tile[x + 1, y + 1].type] || Main.tileSolidTop[(int) Main.tile[x + 1, y + 1].type] || Main.tileNoAttach[(int) Main.tile[x + 1, y + 1].type])
            return false;
          --index3;
          num5 = 3;
          break;
        case 85:
          if (!Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || !Main.tile[x + 1, y + 1].active || !Main.tileSolid[(int) Main.tile[x + 1, y + 1].type])
            return false;
          --index4;
          num5 = 0;
          break;
      }
      if (Main.tile[index3, index4].active || Main.tile[index3 + 1, index4].active || Main.tile[index3, index4 + 1].active || Main.tile[index3 + 1, index4 + 1].active)
        return false;
      int num6 = 36 * num5;
      for (int index5 = 0; index5 < 2; ++index5)
      {
        for (int index6 = 0; index6 < 2; ++index6)
        {
          Main.tile[index3 + index5, index4 + index6].active = true;
          Main.tile[index3 + index5, index4 + index6].type = (byte) type;
          Main.tile[index3 + index5, index4 + index6].frameX = (short) (num6 + 18 * index5);
          Main.tile[index3 + index5, index4 + index6].frameY = (short) (18 * index6);
        }
      }
      return true;
    }

    public static void Place1x1(int x, int y, int type, int style = 0)
    {
      if (Main.tile[x, y] == null)
        Main.tile[x, y] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (!WorldGen.SolidTile(x, y + 1) || Main.tile[x, y].active)
        return;
      Main.tile[x, y].active = true;
      Main.tile[x, y].type = (byte) type;
      if (type == 144)
      {
        Main.tile[x, y].frameX = (short) (style * 18);
        Main.tile[x, y].frameY = (short) 0;
      }
      else
        Main.tile[x, y].frameY = (short) (style * 18);
    }

    public static void Check1x1(int x, int y, int type)
    {
      if (Main.tile[x, y + 1] == null || Main.tile[x, y + 1].active && Main.tileSolid[(int) Main.tile[x, y + 1].type])
        return;
      WorldGen.KillTile(x, y);
    }

    public static void PlaceOnTable1x1(int x, int y, int type, int style = 0)
    {
      bool flag = false;
      if (Main.tile[x, y] == null)
        Main.tile[x, y] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (!Main.tile[x, y].active && Main.tile[x, y + 1].active && Main.tileTable[(int) Main.tile[x, y + 1].type])
        flag = true;
      if (type == 78 && !Main.tile[x, y].active && Main.tile[x, y + 1].active && Main.tileSolid[(int) Main.tile[x, y + 1].type])
        flag = true;
      if (!flag)
        return;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameX = (short) (style * 18);
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].type = (byte) type;
      if (type != 50)
        return;
      Main.tile[x, y].frameX = (short) (18 * WorldGen.genRand.Next(5));
    }

    public static bool PlaceAlch(int x, int y, int style)
    {
      if (Main.tile[x, y] == null)
        Main.tile[x, y] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (!Main.tile[x, y].active && Main.tile[x, y + 1].active)
      {
        bool flag = false;
        switch (style)
        {
          case 0:
            if (Main.tile[x, y + 1].type != (byte) 2 && Main.tile[x, y + 1].type != (byte) 78 && Main.tile[x, y + 1].type != (byte) 109)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0)
            {
              flag = true;
              break;
            }
            break;
          case 1:
            if (Main.tile[x, y + 1].type != (byte) 60 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0)
            {
              flag = true;
              break;
            }
            break;
          case 2:
            if (Main.tile[x, y + 1].type != (byte) 0 && Main.tile[x, y + 1].type != (byte) 59 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0)
            {
              flag = true;
              break;
            }
            break;
          case 3:
            if (Main.tile[x, y + 1].type != (byte) 23 && Main.tile[x, y + 1].type != (byte) 25 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0)
            {
              flag = true;
              break;
            }
            break;
          case 4:
            if (Main.tile[x, y + 1].type != (byte) 53 && Main.tile[x, y + 1].type != (byte) 78 && Main.tile[x, y + 1].type != (byte) 116)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && Main.tile[x, y].lava)
            {
              flag = true;
              break;
            }
            break;
          case 5:
            if (Main.tile[x, y + 1].type != (byte) 57 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && !Main.tile[x, y].lava)
            {
              flag = true;
              break;
            }
            break;
        }
        if (!flag)
        {
          Main.tile[x, y].active = true;
          Main.tile[x, y].type = (byte) 82;
          Main.tile[x, y].frameX = (short) (18 * style);
          Main.tile[x, y].frameY = (short) 0;
          return true;
        }
      }
      return false;
    }

    public static void GrowAlch(int x, int y)
    {
      if (!Main.tile[x, y].active)
        return;
      if (Main.tile[x, y].type == (byte) 82 && WorldGen.genRand.Next(50) == 0)
      {
        Main.tile[x, y].type = (byte) 83;
        if (Main.netMode == 2)
          NetMessage.SendTileSquare(-1, x, y, 1);
        WorldGen.SquareTileFrame(x, y);
      }
      else
      {
        if (Main.tile[x, y].frameX != (short) 36)
          return;
        Main.tile[x, y].type = Main.tile[x, y].type != (byte) 83 ? (byte) 83 : (byte) 84;
        if (Main.netMode != 2)
          return;
        NetMessage.SendTileSquare(-1, x, y, 1);
      }
    }

    public static void PlantAlch()
    {
      int index1 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
      int index2 = WorldGen.genRand.Next(40) != 0 ? (WorldGen.genRand.Next(10) != 0 ? WorldGen.genRand.Next((int) Main.worldSurface, Main.maxTilesY - 20) : WorldGen.genRand.Next(0, Main.maxTilesY - 20)) : WorldGen.genRand.Next((int) (Main.rockLayer + (double) Main.maxTilesY) / 2, Main.maxTilesY - 20);
      while (index2 < Main.maxTilesY - 20 && !Main.tile[index1, index2].active)
        ++index2;
      if (!Main.tile[index1, index2].active || Main.tile[index1, index2 - 1].active || Main.tile[index1, index2 - 1].liquid != (byte) 0)
        return;
      if (Main.tile[index1, index2].type == (byte) 2 || Main.tile[index1, index2].type == (byte) 109)
        WorldGen.PlaceAlch(index1, index2 - 1, 0);
      if (Main.tile[index1, index2].type == (byte) 60)
        WorldGen.PlaceAlch(index1, index2 - 1, 1);
      if (Main.tile[index1, index2].type == (byte) 0 || Main.tile[index1, index2].type == (byte) 59)
        WorldGen.PlaceAlch(index1, index2 - 1, 2);
      if (Main.tile[index1, index2].type == (byte) 23 || Main.tile[index1, index2].type == (byte) 25)
        WorldGen.PlaceAlch(index1, index2 - 1, 3);
      if (Main.tile[index1, index2].type == (byte) 53 || Main.tile[index1, index2].type == (byte) 116)
        WorldGen.PlaceAlch(index1, index2 - 1, 4);
      if (Main.tile[index1, index2].type == (byte) 57)
        WorldGen.PlaceAlch(index1, index2 - 1, 5);
      if (!Main.tile[index1, index2 - 1].active || Main.netMode != 2)
        return;
      NetMessage.SendTileSquare(-1, index1, index2 - 1, 1);
    }

    public static void CheckAlch(int x, int y)
    {
      if (Main.tile[x, y] == null)
        Main.tile[x, y] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      bool flag = false;
      if (!Main.tile[x, y + 1].active)
        flag = true;
      int num = (int) Main.tile[x, y].frameX / 18;
      Main.tile[x, y].frameY = (short) 0;
      if (!flag)
      {
        switch (num)
        {
          case 0:
            if (Main.tile[x, y + 1].type != (byte) 109 && Main.tile[x, y + 1].type != (byte) 2 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && Main.tile[x, y].lava)
            {
              flag = true;
              break;
            }
            break;
          case 1:
            if (Main.tile[x, y + 1].type != (byte) 60 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && Main.tile[x, y].lava)
            {
              flag = true;
              break;
            }
            break;
          case 2:
            if (Main.tile[x, y + 1].type != (byte) 0 && Main.tile[x, y + 1].type != (byte) 59 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && Main.tile[x, y].lava)
            {
              flag = true;
              break;
            }
            break;
          case 3:
            if (Main.tile[x, y + 1].type != (byte) 23 && Main.tile[x, y + 1].type != (byte) 25 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && Main.tile[x, y].lava)
            {
              flag = true;
              break;
            }
            break;
          case 4:
            if (Main.tile[x, y + 1].type != (byte) 53 && Main.tile[x, y + 1].type != (byte) 78 && Main.tile[x, y + 1].type != (byte) 116)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && Main.tile[x, y].lava)
              flag = true;
            if (Main.tile[x, y].type != (byte) 82 && !Main.tile[x, y].lava && Main.netMode != 1)
            {
              if (Main.tile[x, y].liquid > (byte) 16)
              {
                if (Main.tile[x, y].type == (byte) 83)
                {
                  Main.tile[x, y].type = (byte) 84;
                  if (Main.netMode == 2)
                  {
                    NetMessage.SendTileSquare(-1, x, y, 1);
                    break;
                  }
                  break;
                }
                break;
              }
              if (Main.tile[x, y].type == (byte) 84)
              {
                Main.tile[x, y].type = (byte) 83;
                if (Main.netMode == 2)
                {
                  NetMessage.SendTileSquare(-1, x, y, 1);
                  break;
                }
                break;
              }
              break;
            }
            break;
          case 5:
            if (Main.tile[x, y + 1].type != (byte) 57 && Main.tile[x, y + 1].type != (byte) 78)
              flag = true;
            if (Main.tile[x, y].liquid > (byte) 0 && !Main.tile[x, y].lava)
              flag = true;
            if (Main.tile[x, y].type != (byte) 82 && Main.tile[x, y].lava && Main.tile[x, y].type != (byte) 82 && Main.tile[x, y].lava && Main.netMode != 1)
            {
              if (Main.tile[x, y].liquid > (byte) 16)
              {
                if (Main.tile[x, y].type == (byte) 83)
                {
                  Main.tile[x, y].type = (byte) 84;
                  if (Main.netMode == 2)
                  {
                    NetMessage.SendTileSquare(-1, x, y, 1);
                    break;
                  }
                  break;
                }
                break;
              }
              if (Main.tile[x, y].type == (byte) 84)
              {
                Main.tile[x, y].type = (byte) 83;
                if (Main.netMode == 2)
                {
                  NetMessage.SendTileSquare(-1, x, y, 1);
                  break;
                }
                break;
              }
              break;
            }
            break;
        }
      }
      if (!flag)
        return;
      WorldGen.KillTile(x, y);
    }

    public static void CheckBanner(int x, int j, byte type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = j - (int) Main.tile[x, j].frameY / 18;
      int frameX = (int) Main.tile[x, j].frameX;
      bool flag = false;
      for (int index = 0; index < 3; ++index)
      {
        if (Main.tile[x, num1 + index] == null)
          Main.tile[x, num1 + index] = new Tile();
        if (!Main.tile[x, num1 + index].active)
          flag = true;
        else if ((int) Main.tile[x, num1 + index].type != (int) type)
          flag = true;
        else if ((int) Main.tile[x, num1 + index].frameY != index * 18)
          flag = true;
        else if ((int) Main.tile[x, num1 + index].frameX != frameX)
          flag = true;
      }
      if (Main.tile[x, num1 - 1] == null)
        Main.tile[x, num1 - 1] = new Tile();
      if (!Main.tile[x, num1 - 1].active)
        flag = true;
      if (!Main.tileSolid[(int) Main.tile[x, num1 - 1].type])
        flag = true;
      if (Main.tileSolidTop[(int) Main.tile[x, num1 - 1].type])
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int index = 0; index < 3; ++index)
      {
        if ((int) Main.tile[x, num1 + index].type == (int) type)
          WorldGen.KillTile(x, num1 + index);
      }
      if (type == (byte) 91)
      {
        int num2 = frameX / 18;
        Item.NewItem(x * 16, (num1 + 1) * 16, 32, 32, 337 + num2);
      }
      WorldGen.destroyObject = false;
    }

    public static void PlaceBanner(int x, int y, int type, int style = 0)
    {
      int num = style * 18;
      if (Main.tile[x, y - 1] == null)
        Main.tile[x, y - 1] = new Tile();
      if (Main.tile[x, y] == null)
        Main.tile[x, y] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (Main.tile[x, y + 2] == null)
        Main.tile[x, y + 2] = new Tile();
      if (!Main.tile[x, y - 1].active || !Main.tileSolid[(int) Main.tile[x, y - 1].type] || Main.tileSolidTop[(int) Main.tile[x, y - 1].type] || Main.tile[x, y].active || Main.tile[x, y + 1].active || Main.tile[x, y + 2].active)
        return;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].frameX = (short) num;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x, y + 1].active = true;
      Main.tile[x, y + 1].frameY = (short) 18;
      Main.tile[x, y + 1].frameX = (short) num;
      Main.tile[x, y + 1].type = (byte) type;
      Main.tile[x, y + 2].active = true;
      Main.tile[x, y + 2].frameY = (short) 36;
      Main.tile[x, y + 2].frameX = (short) num;
      Main.tile[x, y + 2].type = (byte) type;
    }

    public static void PlaceMan(int i, int j, int dir)
    {
      for (int index1 = i; index1 <= i + 1; ++index1)
      {
        for (int index2 = j - 2; index2 <= j; ++index2)
        {
          if (Main.tile[index1, index2].active)
            return;
        }
      }
      if (!WorldGen.SolidTile(i, j + 1) || !WorldGen.SolidTile(i + 1, j + 1))
        return;
      byte num = 0;
      if (dir == 1)
        num = (byte) 36;
      Main.tile[i, j - 2].active = true;
      Main.tile[i, j - 2].frameY = (short) 0;
      Main.tile[i, j - 2].frameX = (short) num;
      Main.tile[i, j - 2].type = (byte) 128;
      Main.tile[i, j - 1].active = true;
      Main.tile[i, j - 1].frameY = (short) 18;
      Main.tile[i, j - 1].frameX = (short) num;
      Main.tile[i, j - 1].type = (byte) 128;
      Main.tile[i, j].active = true;
      Main.tile[i, j].frameY = (short) 36;
      Main.tile[i, j].frameX = (short) num;
      Main.tile[i, j].type = (byte) 128;
      Main.tile[i + 1, j - 2].active = true;
      Main.tile[i + 1, j - 2].frameY = (short) 0;
      Main.tile[i + 1, j - 2].frameX = (short) (byte) (18U + (uint) num);
      Main.tile[i + 1, j - 2].type = (byte) 128;
      Main.tile[i + 1, j - 1].active = true;
      Main.tile[i + 1, j - 1].frameY = (short) 18;
      Main.tile[i + 1, j - 1].frameX = (short) (byte) (18U + (uint) num);
      Main.tile[i + 1, j - 1].type = (byte) 128;
      Main.tile[i + 1, j].active = true;
      Main.tile[i + 1, j].frameY = (short) 36;
      Main.tile[i + 1, j].frameX = (short) (byte) (18U + (uint) num);
      Main.tile[i + 1, j].type = (byte) 128;
    }

    public static void CheckMan(int i, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = i;
      int num2 = j - (int) Main.tile[i, j].frameY / 18;
      int frameX1 = (int) Main.tile[i, j].frameX;
      while (frameX1 >= 100)
        frameX1 -= 100;
      while (frameX1 >= 36)
        frameX1 -= 36;
      int i1 = num1 - frameX1 / 18;
      bool flag = false;
      for (int index1 = 0; index1 <= 1; ++index1)
      {
        for (int index2 = 0; index2 <= 2; ++index2)
        {
          int index3 = i1 + index1;
          int index4 = num2 + index2;
          int frameX2 = (int) Main.tile[index3, index4].frameX;
          while (frameX2 >= 100)
            frameX2 -= 100;
          if (frameX2 >= 36)
            frameX2 -= 36;
          if (!Main.tile[index3, index4].active || Main.tile[index3, index4].type != (byte) 128 || (int) Main.tile[index3, index4].frameY != index2 * 18 || frameX2 != index1 * 18)
            flag = true;
        }
      }
      if (!WorldGen.SolidTile(i1, num2 + 3) || !WorldGen.SolidTile(i1 + 1, num2 + 3))
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      Item.NewItem(i * 16, j * 16, 32, 32, 498);
      for (int index5 = 0; index5 <= 1; ++index5)
      {
        for (int index6 = 0; index6 <= 2; ++index6)
        {
          int i2 = i1 + index5;
          int j1 = num2 + index6;
          if (Main.tile[i2, j1].active && Main.tile[i2, j1].type == (byte) 128)
            WorldGen.KillTile(i2, j1);
        }
      }
      WorldGen.destroyObject = false;
    }

    public static void Place1x2(int x, int y, int type, int style)
    {
      short num1 = 0;
      if (type == 20)
        num1 = (short) (WorldGen.genRand.Next(3) * 18);
      if (Main.tile[x, y - 1] == null)
        Main.tile[x, y - 1] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (!Main.tile[x, y + 1].active || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || Main.tile[x, y - 1].active)
        return;
      short num2 = (short) (style * 40);
      Main.tile[x, y - 1].active = true;
      Main.tile[x, y - 1].frameY = num2;
      Main.tile[x, y - 1].frameX = num1;
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameY = (short) ((int) num2 + 18);
      Main.tile[x, y].frameX = num1;
      Main.tile[x, y].type = (byte) type;
    }

    public static void Place1x2Top(int x, int y, int type)
    {
      short num = 0;
      if (Main.tile[x, y - 1] == null)
        Main.tile[x, y - 1] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (!Main.tile[x, y - 1].active || !Main.tileSolid[(int) Main.tile[x, y - 1].type] || Main.tileSolidTop[(int) Main.tile[x, y - 1].type] || Main.tile[x, y + 1].active)
        return;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].frameX = num;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x, y + 1].active = true;
      Main.tile[x, y + 1].frameY = (short) 18;
      Main.tile[x, y + 1].frameX = num;
      Main.tile[x, y + 1].type = (byte) type;
    }

    public static void Check1x2Top(int x, int j, byte type)
    {
      if (WorldGen.destroyObject)
        return;
      int j1 = j;
      bool flag = true;
      if (Main.tile[x, j1] == null)
        Main.tile[x, j1] = new Tile();
      if (Main.tile[x, j1 + 1] == null)
        Main.tile[x, j1 + 1] = new Tile();
      if (Main.tile[x, j1].frameY == (short) 18)
        --j1;
      if (Main.tile[x, j1] == null)
        Main.tile[x, j1] = new Tile();
      if (Main.tile[x, j1].frameY == (short) 0 && Main.tile[x, j1 + 1].frameY == (short) 18 && (int) Main.tile[x, j1].type == (int) type && (int) Main.tile[x, j1 + 1].type == (int) type)
        flag = false;
      if (Main.tile[x, j1 - 1] == null)
        Main.tile[x, j1 - 1] = new Tile();
      if (!Main.tile[x, j1 - 1].active || !Main.tileSolid[(int) Main.tile[x, j1 - 1].type] || Main.tileSolidTop[(int) Main.tile[x, j1 - 1].type])
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[x, j1].type == (int) type)
        WorldGen.KillTile(x, j1);
      if ((int) Main.tile[x, j1 + 1].type == (int) type)
        WorldGen.KillTile(x, j1 + 1);
      if (type == (byte) 42)
        Item.NewItem(x * 16, j1 * 16, 32, 32, 136);
      WorldGen.destroyObject = false;
    }

    public static void Check2x1(int i, int y, byte type)
    {
      if (WorldGen.destroyObject)
        return;
      int i1 = i;
      bool flag = true;
      if (Main.tile[i1, y] == null)
        Main.tile[i1, y] = new Tile();
      if (Main.tile[i1 + 1, y] == null)
        Main.tile[i1 + 1, y] = new Tile();
      if (Main.tile[i1, y + 1] == null)
        Main.tile[i1, y + 1] = new Tile();
      if (Main.tile[i1 + 1, y + 1] == null)
        Main.tile[i1 + 1, y + 1] = new Tile();
      if (Main.tile[i1, y].frameX == (short) 18)
        --i1;
      if (Main.tile[i1, y].frameX == (short) 0 && Main.tile[i1 + 1, y].frameX == (short) 18 && (int) Main.tile[i1, y].type == (int) type && (int) Main.tile[i1 + 1, y].type == (int) type)
        flag = false;
      if (type == (byte) 29 || type == (byte) 103)
      {
        if (!Main.tile[i1, y + 1].active || !Main.tileTable[(int) Main.tile[i1, y + 1].type])
          flag = true;
        if (!Main.tile[i1 + 1, y + 1].active || !Main.tileTable[(int) Main.tile[i1 + 1, y + 1].type])
          flag = true;
      }
      else
      {
        if (!Main.tile[i1, y + 1].active || !Main.tileSolid[(int) Main.tile[i1, y + 1].type])
          flag = true;
        if (!Main.tile[i1 + 1, y + 1].active || !Main.tileSolid[(int) Main.tile[i1 + 1, y + 1].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[i1, y].type == (int) type)
        WorldGen.KillTile(i1, y);
      if ((int) Main.tile[i1 + 1, y].type == (int) type)
        WorldGen.KillTile(i1 + 1, y);
      if (type == (byte) 16)
        Item.NewItem(i1 * 16, y * 16, 32, 32, 35);
      if (type == (byte) 18)
        Item.NewItem(i1 * 16, y * 16, 32, 32, 36);
      if (type == (byte) 29)
      {
        Item.NewItem(i1 * 16, y * 16, 32, 32, 87);
        Main.PlaySound(13, i * 16, y * 16);
      }
      if (type == (byte) 103)
      {
        Item.NewItem(i1 * 16, y * 16, 32, 32, 356);
        Main.PlaySound(13, i * 16, y * 16);
      }
      if (type == (byte) 134)
        Item.NewItem(i1 * 16, y * 16, 32, 32, 525);
      WorldGen.destroyObject = false;
      WorldGen.SquareTileFrame(i1, y);
      WorldGen.SquareTileFrame(i1 + 1, y);
    }

    public static void Place2x1(int x, int y, int type)
    {
      if (Main.tile[x, y] == null)
        Main.tile[x, y] = new Tile();
      if (Main.tile[x + 1, y] == null)
        Main.tile[x + 1, y] = new Tile();
      if (Main.tile[x, y + 1] == null)
        Main.tile[x, y + 1] = new Tile();
      if (Main.tile[x + 1, y + 1] == null)
        Main.tile[x + 1, y + 1] = new Tile();
      bool flag = false;
      if (type != 29 && type != 103 && Main.tile[x, y + 1].active && Main.tile[x + 1, y + 1].active && Main.tileSolid[(int) Main.tile[x, y + 1].type] && Main.tileSolid[(int) Main.tile[x + 1, y + 1].type] && !Main.tile[x, y].active && !Main.tile[x + 1, y].active)
        flag = true;
      else if ((type == 29 || type == 103) && Main.tile[x, y + 1].active && Main.tile[x + 1, y + 1].active && Main.tileTable[(int) Main.tile[x, y + 1].type] && Main.tileTable[(int) Main.tile[x + 1, y + 1].type] && !Main.tile[x, y].active && !Main.tile[x + 1, y].active)
        flag = true;
      if (!flag)
        return;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].frameX = (short) 0;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x + 1, y].active = true;
      Main.tile[x + 1, y].frameY = (short) 0;
      Main.tile[x + 1, y].frameX = (short) 18;
      Main.tile[x + 1, y].type = (byte) type;
    }

    public static void Check4x2(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = i;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18 * -1;
      if ((type == 79 || type == 90) && Main.tile[i, j].frameX >= (short) 72)
        num3 += 4;
      int num4 = num2 + (int) Main.tile[i, j].frameY / 18 * -1;
      for (int index1 = num3; index1 < num3 + 4; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 2; ++index2)
        {
          int num5 = (index1 - num3) * 18;
          if ((type == 79 || type == 90) && Main.tile[i, j].frameX >= (short) 72)
            num5 = (index1 - num3 + 4) * 18;
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || (int) Main.tile[index1, index2].frameX != num5 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18)
            flag = true;
        }
        if (Main.tile[index1, num4 + 2] == null)
          Main.tile[index1, num4 + 2] = new Tile();
        if (!Main.tile[index1, num4 + 2].active || !Main.tileSolid[(int) Main.tile[index1, num4 + 2].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i1 = num3; i1 < num3 + 4; ++i1)
      {
        for (int j1 = num4; j1 < num4 + 3; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      if (type == 79)
        Item.NewItem(i * 16, j * 16, 32, 32, 224);
      if (type == 90)
        Item.NewItem(i * 16, j * 16, 32, 32, 336);
      WorldGen.destroyObject = false;
      for (int i2 = num3 - 1; i2 < num3 + 4; ++i2)
      {
        for (int j2 = num4 - 1; j2 < num4 + 4; ++j2)
          WorldGen.TileFrame(i2, j2);
      }
    }

    public static void Check2x2(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = 0;
      int num2 = (int) Main.tile[i, j].frameX / 18 * -1;
      int num3 = (int) Main.tile[i, j].frameY / 18 * -1;
      if (num2 < -1)
      {
        num2 += 2;
        num1 = 36;
      }
      int i1 = num2 + i;
      int num4 = num3 + j;
      for (int index1 = i1; index1 < i1 + 2; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 2; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || (int) Main.tile[index1, index2].frameX != (index1 - i1) * 18 + num1 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18)
            flag = true;
        }
        switch (type)
        {
          case 95:
          case 126:
            if (Main.tile[index1, num4 - 1] == null)
              Main.tile[index1, num4 - 1] = new Tile();
            if (!Main.tile[index1, num4 - 1].active || !Main.tileSolid[(int) Main.tile[index1, num4 - 1].type] || Main.tileSolidTop[(int) Main.tile[index1, num4 - 1].type])
            {
              flag = true;
              continue;
            }
            continue;
          case 138:
            continue;
          default:
            if (Main.tile[index1, num4 + 2] == null)
              Main.tile[index1, num4 + 2] = new Tile();
            if (!Main.tile[index1, num4 + 2].active || !Main.tileSolid[(int) Main.tile[index1, num4 + 2].type] && !Main.tileTable[(int) Main.tile[index1, num4 + 2].type])
            {
              flag = true;
              continue;
            }
            continue;
        }
      }
      if (type == 138 && !WorldGen.SolidTile(i1, num4 + 2) && !WorldGen.SolidTile(i1 + 1, num4 + 2))
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i2 = i1; i2 < i1 + 2; ++i2)
      {
        for (int j1 = num4; j1 < num4 + 2; ++j1)
        {
          if ((int) Main.tile[i2, j1].type == type && Main.tile[i2, j1].active)
            WorldGen.KillTile(i2, j1);
        }
      }
      if (type == 85)
        Item.NewItem(i * 16, j * 16, 32, 32, 321);
      if (type == 94)
        Item.NewItem(i * 16, j * 16, 32, 32, 352);
      if (type == 95)
        Item.NewItem(i * 16, j * 16, 32, 32, 344);
      if (type == 96)
        Item.NewItem(i * 16, j * 16, 32, 32, 345);
      if (type == 97)
        Item.NewItem(i * 16, j * 16, 32, 32, 346);
      if (type == 98)
        Item.NewItem(i * 16, j * 16, 32, 32, 347);
      if (type == 99)
        Item.NewItem(i * 16, j * 16, 32, 32, 348);
      if (type == 100)
        Item.NewItem(i * 16, j * 16, 32, 32, 349);
      if (type == 125)
        Item.NewItem(i * 16, j * 16, 32, 32, 487);
      if (type == 126)
        Item.NewItem(i * 16, j * 16, 32, 32, 488);
      if (type == 132)
        Item.NewItem(i * 16, j * 16, 32, 32, 513);
      if (type == 142)
        Item.NewItem(i * 16, j * 16, 32, 32, 581);
      if (type == 143)
        Item.NewItem(i * 16, j * 16, 32, 32, 582);
      if (type == 138 && !WorldGen.gen && Main.netMode != 1)
        Projectile.NewProjectile((float) (i1 * 16) + 15.5f, (float) (num4 * 16 + 16), 0.0f, 0.0f, 99, 70, 10f, Main.myPlayer);
      WorldGen.destroyObject = false;
      for (int i3 = i1 - 1; i3 < i1 + 3; ++i3)
      {
        for (int j2 = num4 - 1; j2 < num4 + 3; ++j2)
          WorldGen.TileFrame(i3, j2);
      }
    }

    public static void OreRunner(int i, int j, double strength, int steps, int type)
    {
      double num1 = strength;
      float num2 = (float) steps;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        if ((double) vector2_1.Y < 0.0 && (double) num2 > 0.0 && type == 59)
          num2 = 0.0f;
        num1 = strength * ((double) num2 / (double) steps);
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX)
          num4 = Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          for (int index2 = num5; index2 < num6; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < strength * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[index1, index2].active && (Main.tile[index1, index2].type == (byte) 0 || Main.tile[index1, index2].type == (byte) 1 || Main.tile[index1, index2].type == (byte) 23 || Main.tile[index1, index2].type == (byte) 25 || Main.tile[index1, index2].type == (byte) 40 || Main.tile[index1, index2].type == (byte) 53 || Main.tile[index1, index2].type == (byte) 57 || Main.tile[index1, index2].type == (byte) 59 || Main.tile[index1, index2].type == (byte) 60 || Main.tile[index1, index2].type == (byte) 70 || Main.tile[index1, index2].type == (byte) 109 || Main.tile[index1, index2].type == (byte) 112 || Main.tile[index1, index2].type == (byte) 116 || Main.tile[index1, index2].type == (byte) 117))
            {
              Main.tile[index1, index2].type = (byte) type;
              WorldGen.SquareTileFrame(index1, index2);
              if (Main.netMode == 2)
                NetMessage.SendTileSquare(-1, index1, index2, 1);
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
      }
    }

    public static void SmashAltar(int i, int j)
    {
      if (Main.netMode == 1 || !Main.hardMode || WorldGen.noTileActions || WorldGen.gen)
        return;
      int num1 = WorldGen.altarCount % 3;
      int num2 = WorldGen.altarCount / 3 + 1;
      float num3 = (float) (Main.maxTilesX / 4200);
      int num4 = 1 - num1;
      float num5 = (num3 * 310f - (float) (85 * num1)) * 0.85f / (float) num2;
      int type;
      switch (num1)
      {
        case 0:
          switch (Main.netMode)
          {
            case 0:
              Main.NewText(Lang.misc[12], (byte) 50, B: (byte) 130);
              break;
            case 2:
              NetMessage.SendData(25, text: Lang.misc[12], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
              break;
          }
          type = 107;
          num5 *= 1.05f;
          break;
        case 1:
          switch (Main.netMode)
          {
            case 0:
              Main.NewText(Lang.misc[13], (byte) 50, B: (byte) 130);
              break;
            case 2:
              NetMessage.SendData(25, text: Lang.misc[13], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
              break;
          }
          type = 108;
          break;
        default:
          switch (Main.netMode)
          {
            case 0:
              Main.NewText(Lang.misc[14], (byte) 50, B: (byte) 130);
              break;
            case 2:
              NetMessage.SendData(25, text: Lang.misc[14], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
              break;
          }
          type = 111;
          break;
      }
      for (int index = 0; (double) index < (double) num5; ++index)
      {
        int i1 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
        double num6 = Main.worldSurface;
        if (type == 108)
          num6 = Main.rockLayer;
        if (type == 111)
          num6 = (Main.rockLayer + Main.rockLayer + (double) Main.maxTilesY) / 3.0;
        int j1 = WorldGen.genRand.Next((int) num6, Main.maxTilesY - 150);
        WorldGen.OreRunner(i1, j1, (double) WorldGen.genRand.Next(5, 9 + num4), WorldGen.genRand.Next(5, 9 + num4), type);
      }
      int num7 = WorldGen.genRand.Next(3);
      while (num7 != 2)
      {
        int tileX = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
        int tileY = WorldGen.genRand.Next((int) Main.rockLayer + 50, Main.maxTilesY - 300);
        if (Main.tile[tileX, tileY].active && Main.tile[tileX, tileY].type == (byte) 1)
        {
          Main.tile[tileX, tileY].type = num7 != 0 ? (byte) 117 : (byte) 25;
          if (Main.netMode == 2)
          {
            NetMessage.SendTileSquare(-1, tileX, tileY, 1);
            break;
          }
          break;
        }
      }
      if (Main.netMode != 1)
      {
        int num8 = Main.rand.Next(2) + 1;
        for (int index = 0; index < num8; ++index)
          NPC.SpawnOnPlayer((int) Player.FindClosest(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16), 82);
      }
      ++WorldGen.altarCount;
    }

    public static void Check3x2(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = i;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18 * -1;
      int num4 = num2 + (int) Main.tile[i, j].frameY / 18 * -1;
      for (int index1 = num3; index1 < num3 + 3; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 2; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || (int) Main.tile[index1, index2].frameX != (index1 - num3) * 18 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18)
            flag = true;
        }
        if (Main.tile[index1, num4 + 2] == null)
          Main.tile[index1, num4 + 2] = new Tile();
        if (!Main.tile[index1, num4 + 2].active || !Main.tileSolid[(int) Main.tile[index1, num4 + 2].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i1 = num3; i1 < num3 + 3; ++i1)
      {
        for (int j1 = num4; j1 < num4 + 3; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      switch (type)
      {
        case 14:
          Item.NewItem(i * 16, j * 16, 32, 32, 32);
          break;
        case 17:
          Item.NewItem(i * 16, j * 16, 32, 32, 33);
          break;
        case 26:
          if (!WorldGen.noTileActions)
          {
            WorldGen.SmashAltar(i, j);
            break;
          }
          break;
        case 77:
          Item.NewItem(i * 16, j * 16, 32, 32, 221);
          break;
        case 86:
          Item.NewItem(i * 16, j * 16, 32, 32, 332);
          break;
        case 87:
          Item.NewItem(i * 16, j * 16, 32, 32, 333);
          break;
        case 88:
          Item.NewItem(i * 16, j * 16, 32, 32, 334);
          break;
        case 89:
          Item.NewItem(i * 16, j * 16, 32, 32, 335);
          break;
        case 114:
          Item.NewItem(i * 16, j * 16, 32, 32, 398);
          break;
        case 133:
          Item.NewItem(i * 16, j * 16, 32, 32, 524);
          break;
      }
      WorldGen.destroyObject = false;
      for (int i2 = num3 - 1; i2 < num3 + 4; ++i2)
      {
        for (int j2 = num4 - 1; j2 < num4 + 4; ++j2)
          WorldGen.TileFrame(i2, j2);
      }
    }

    public static void Check3x4(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = i;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18 * -1;
      int num4 = num2 + (int) Main.tile[i, j].frameY / 18 * -1;
      for (int index1 = num3; index1 < num3 + 3; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 4; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || (int) Main.tile[index1, index2].frameX != (index1 - num3) * 18 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18)
            flag = true;
        }
        if (Main.tile[index1, num4 + 4] == null)
          Main.tile[index1, num4 + 4] = new Tile();
        if (!Main.tile[index1, num4 + 4].active || !Main.tileSolid[(int) Main.tile[index1, num4 + 4].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i1 = num3; i1 < num3 + 3; ++i1)
      {
        for (int j1 = num4; j1 < num4 + 4; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      switch (type)
      {
        case 101:
          Item.NewItem(i * 16, j * 16, 32, 32, 354);
          break;
        case 102:
          Item.NewItem(i * 16, j * 16, 32, 32, 355);
          break;
      }
      WorldGen.destroyObject = false;
      for (int i2 = num3 - 1; i2 < num3 + 4; ++i2)
      {
        for (int j2 = num4 - 1; j2 < num4 + 4; ++j2)
          WorldGen.TileFrame(i2, j2);
      }
    }

    public static void Place4x2(int x, int y, int type, int direction = -1)
    {
      if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
        return;
      bool flag = true;
      for (int index1 = x - 1; index1 < x + 3; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active)
            flag = false;
        }
        if (Main.tile[index1, y + 1] == null)
          Main.tile[index1, y + 1] = new Tile();
        if (!Main.tile[index1, y + 1].active || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          flag = false;
      }
      short num = 0;
      if (direction == 1)
        num = (short) 72;
      if (!flag)
        return;
      Main.tile[x - 1, y - 1].active = true;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y - 1].frameX = num;
      Main.tile[x - 1, y - 1].type = (byte) type;
      Main.tile[x, y - 1].active = true;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].frameX = (short) (18 + (int) num);
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x + 1, y - 1].active = true;
      Main.tile[x + 1, y - 1].frameY = (short) 0;
      Main.tile[x + 1, y - 1].frameX = (short) (36 + (int) num);
      Main.tile[x + 1, y - 1].type = (byte) type;
      Main.tile[x + 2, y - 1].active = true;
      Main.tile[x + 2, y - 1].frameY = (short) 0;
      Main.tile[x + 2, y - 1].frameX = (short) (54 + (int) num);
      Main.tile[x + 2, y - 1].type = (byte) type;
      Main.tile[x - 1, y].active = true;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x - 1, y].frameX = num;
      Main.tile[x - 1, y].type = (byte) type;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameY = (short) 18;
      Main.tile[x, y].frameX = (short) (18 + (int) num);
      Main.tile[x, y].type = (byte) type;
      Main.tile[x + 1, y].active = true;
      Main.tile[x + 1, y].frameY = (short) 18;
      Main.tile[x + 1, y].frameX = (short) (36 + (int) num);
      Main.tile[x + 1, y].type = (byte) type;
      Main.tile[x + 2, y].active = true;
      Main.tile[x + 2, y].frameY = (short) 18;
      Main.tile[x + 2, y].frameX = (short) (54 + (int) num);
      Main.tile[x + 2, y].type = (byte) type;
    }

    public static void SwitchMB(int i, int j)
    {
      int num1 = (int) Main.tile[i, j].frameY / 18;
      while (num1 >= 2)
        num1 -= 2;
      int num2 = (int) Main.tile[i, j].frameX / 18;
      if (num2 >= 2)
        num2 -= 2;
      int tileX = i - num2;
      int tileY = j - num1;
      for (int index1 = tileX; index1 < tileX + 2; ++index1)
      {
        for (int index2 = tileY; index2 < tileY + 2; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active && Main.tile[index1, index2].type == (byte) 139)
          {
            if (Main.tile[index1, index2].frameX < (short) 36)
              Main.tile[index1, index2].frameX += (short) 36;
            else
              Main.tile[index1, index2].frameX -= (short) 36;
            WorldGen.noWireX[WorldGen.numNoWire] = index1;
            WorldGen.noWireY[WorldGen.numNoWire] = index2;
            ++WorldGen.numNoWire;
          }
        }
      }
      NetMessage.SendTileSquare(-1, tileX, tileY, 3);
    }

    public static void CheckMB(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = 0;
      int num2;
      for (num2 = (int) Main.tile[i, j].frameY / 18; num2 >= 2; num2 -= 2)
        ++num1;
      int num3 = (int) Main.tile[i, j].frameX / 18;
      int num4 = 0;
      if (num3 >= 2)
      {
        num3 -= 2;
        ++num4;
      }
      int num5 = i - num3;
      int num6 = j - num2;
      for (int index1 = num5; index1 < num5 + 2; ++index1)
      {
        for (int index2 = num6; index2 < num6 + 2; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || (int) Main.tile[index1, index2].frameX != (index1 - num5) * 18 + num4 * 36 || (int) Main.tile[index1, index2].frameY != (index2 - num6) * 18 + num1 * 36)
            flag = true;
        }
        if (!Main.tileSolid[(int) Main.tile[index1, num6 + 2].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i1 = num5; i1 < num5 + 2; ++i1)
      {
        for (int j1 = num6; j1 < num6 + 3; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      Item.NewItem(i * 16, j * 16, 32, 32, 562 + num1);
      for (int i2 = num5 - 1; i2 < num5 + 3; ++i2)
      {
        for (int j2 = num6 - 1; j2 < num6 + 3; ++j2)
          WorldGen.TileFrame(i2, j2);
      }
      WorldGen.destroyObject = false;
    }

    public static void PlaceMB(int X, int y, int type, int style)
    {
      int index1 = X + 1;
      if (index1 < 5 || index1 > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
        return;
      bool flag = true;
      for (int index2 = index1 - 1; index2 < index1 + 1; ++index2)
      {
        for (int index3 = y - 1; index3 < y + 1; ++index3)
        {
          if (Main.tile[index2, index3] == null)
            Main.tile[index2, index3] = new Tile();
          if (Main.tile[index2, index3].active)
            flag = false;
        }
        if (Main.tile[index2, y + 1] == null)
          Main.tile[index2, y + 1] = new Tile();
        if (!Main.tile[index2, y + 1].active || !Main.tileSolid[(int) Main.tile[index2, y + 1].type] && !Main.tileTable[(int) Main.tile[index2, y + 1].type])
          flag = false;
      }
      if (!flag)
        return;
      Main.tile[index1 - 1, y - 1].active = true;
      Main.tile[index1 - 1, y - 1].frameY = (short) (style * 36);
      Main.tile[index1 - 1, y - 1].frameX = (short) 0;
      Main.tile[index1 - 1, y - 1].type = (byte) type;
      Main.tile[index1, y - 1].active = true;
      Main.tile[index1, y - 1].frameY = (short) (style * 36);
      Main.tile[index1, y - 1].frameX = (short) 18;
      Main.tile[index1, y - 1].type = (byte) type;
      Main.tile[index1 - 1, y].active = true;
      Main.tile[index1 - 1, y].frameY = (short) (style * 36 + 18);
      Main.tile[index1 - 1, y].frameX = (short) 0;
      Main.tile[index1 - 1, y].type = (byte) type;
      Main.tile[index1, y].active = true;
      Main.tile[index1, y].frameY = (short) (style * 36 + 18);
      Main.tile[index1, y].frameX = (short) 18;
      Main.tile[index1, y].type = (byte) type;
    }

    public static void Place2x2(int x, int superY, int type)
    {
      int index1 = superY;
      if (type == 95 || type == 126)
        ++index1;
      if (x < 5 || x > Main.maxTilesX - 5 || index1 < 5 || index1 > Main.maxTilesY - 5)
        return;
      bool flag = true;
      for (int index2 = x - 1; index2 < x + 1; ++index2)
      {
        for (int index3 = index1 - 1; index3 < index1 + 1; ++index3)
        {
          if (Main.tile[index2, index3] == null)
            Main.tile[index2, index3] = new Tile();
          if (Main.tile[index2, index3].active)
            flag = false;
          if (type == 98 && Main.tile[index2, index3].liquid > (byte) 0)
            flag = false;
        }
        if (type == 95 || type == 126)
        {
          if (Main.tile[index2, index1 - 2] == null)
            Main.tile[index2, index1 - 2] = new Tile();
          if (!Main.tile[index2, index1 - 2].active || !Main.tileSolid[(int) Main.tile[index2, index1 - 2].type] || Main.tileSolidTop[(int) Main.tile[index2, index1 - 2].type])
            flag = false;
        }
        else
        {
          if (Main.tile[index2, index1 + 1] == null)
            Main.tile[index2, index1 + 1] = new Tile();
          if (!Main.tile[index2, index1 + 1].active || !Main.tileSolid[(int) Main.tile[index2, index1 + 1].type] && !Main.tileTable[(int) Main.tile[index2, index1 + 1].type])
            flag = false;
        }
      }
      if (!flag)
        return;
      Main.tile[x - 1, index1 - 1].active = true;
      Main.tile[x - 1, index1 - 1].frameY = (short) 0;
      Main.tile[x - 1, index1 - 1].frameX = (short) 0;
      Main.tile[x - 1, index1 - 1].type = (byte) type;
      Main.tile[x, index1 - 1].active = true;
      Main.tile[x, index1 - 1].frameY = (short) 0;
      Main.tile[x, index1 - 1].frameX = (short) 18;
      Main.tile[x, index1 - 1].type = (byte) type;
      Main.tile[x - 1, index1].active = true;
      Main.tile[x - 1, index1].frameY = (short) 18;
      Main.tile[x - 1, index1].frameX = (short) 0;
      Main.tile[x - 1, index1].type = (byte) type;
      Main.tile[x, index1].active = true;
      Main.tile[x, index1].frameY = (short) 18;
      Main.tile[x, index1].frameX = (short) 18;
      Main.tile[x, index1].type = (byte) type;
    }

    public static void Place3x4(int x, int y, int type)
    {
      if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
        return;
      bool flag = true;
      for (int index1 = x - 1; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 3; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active)
            flag = false;
        }
        if (Main.tile[index1, y + 1] == null)
          Main.tile[index1, y + 1] = new Tile();
        if (!Main.tile[index1, y + 1].active || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          flag = false;
      }
      if (!flag)
        return;
      for (int index = -3; index <= 0; ++index)
      {
        short num = (short) ((3 + index) * 18);
        Main.tile[x - 1, y + index].active = true;
        Main.tile[x - 1, y + index].frameY = num;
        Main.tile[x - 1, y + index].frameX = (short) 0;
        Main.tile[x - 1, y + index].type = (byte) type;
        Main.tile[x, y + index].active = true;
        Main.tile[x, y + index].frameY = num;
        Main.tile[x, y + index].frameX = (short) 18;
        Main.tile[x, y + index].type = (byte) type;
        Main.tile[x + 1, y + index].active = true;
        Main.tile[x + 1, y + index].frameY = num;
        Main.tile[x + 1, y + index].frameX = (short) 36;
        Main.tile[x + 1, y + index].type = (byte) type;
      }
    }

    public static void Place3x2(int x, int y, int type)
    {
      if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
        return;
      bool flag = true;
      for (int index1 = x - 1; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active)
            flag = false;
        }
        if (Main.tile[index1, y + 1] == null)
          Main.tile[index1, y + 1] = new Tile();
        if (!Main.tile[index1, y + 1].active || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          flag = false;
      }
      if (!flag)
        return;
      Main.tile[x - 1, y - 1].active = true;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y - 1].frameX = (short) 0;
      Main.tile[x - 1, y - 1].type = (byte) type;
      Main.tile[x, y - 1].active = true;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].frameX = (short) 18;
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x + 1, y - 1].active = true;
      Main.tile[x + 1, y - 1].frameY = (short) 0;
      Main.tile[x + 1, y - 1].frameX = (short) 36;
      Main.tile[x + 1, y - 1].type = (byte) type;
      Main.tile[x - 1, y].active = true;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x - 1, y].frameX = (short) 0;
      Main.tile[x - 1, y].type = (byte) type;
      Main.tile[x, y].active = true;
      Main.tile[x, y].frameY = (short) 18;
      Main.tile[x, y].frameX = (short) 18;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x + 1, y].active = true;
      Main.tile[x + 1, y].frameY = (short) 18;
      Main.tile[x + 1, y].frameX = (short) 36;
      Main.tile[x + 1, y].type = (byte) type;
    }

    public static void Check3x3(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = j;
      int num2 = (int) Main.tile[i, j].frameX / 18;
      int num3 = i - num2;
      if (num2 >= 3)
        num2 -= 3;
      int num4 = i - num2;
      int num5 = num1 + (int) Main.tile[i, j].frameY / 18 * -1;
      for (int index1 = num4; index1 < num4 + 3; ++index1)
      {
        for (int index2 = num5; index2 < num5 + 3; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || (int) Main.tile[index1, index2].frameX != (index1 - num3) * 18 || (int) Main.tile[index1, index2].frameY != (index2 - num5) * 18)
            flag = true;
        }
      }
      if (type == 106)
      {
        for (int index = num4; index < num4 + 3; ++index)
        {
          if (Main.tile[index, num5 + 3] == null)
            Main.tile[index, num5 + 3] = new Tile();
          if (!Main.tile[index, num5 + 3].active || !Main.tileSolid[(int) Main.tile[index, num5 + 3].type])
          {
            flag = true;
            break;
          }
        }
      }
      else
      {
        if (Main.tile[num4 + 1, num5 - 1] == null)
          Main.tile[num4 + 1, num5 - 1] = new Tile();
        if (!Main.tile[num4 + 1, num5 - 1].active || !Main.tileSolid[(int) Main.tile[num4 + 1, num5 - 1].type] || Main.tileSolidTop[(int) Main.tile[num4 + 1, num5 - 1].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i1 = num4; i1 < num4 + 3; ++i1)
      {
        for (int j1 = num5; j1 < num5 + 3; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      switch (type)
      {
        case 34:
          Item.NewItem(i * 16, j * 16, 32, 32, 106);
          break;
        case 35:
          Item.NewItem(i * 16, j * 16, 32, 32, 107);
          break;
        case 36:
          Item.NewItem(i * 16, j * 16, 32, 32, 108);
          break;
        case 106:
          Item.NewItem(i * 16, j * 16, 32, 32, 363);
          break;
      }
      WorldGen.destroyObject = false;
      for (int i2 = num4 - 1; i2 < num4 + 4; ++i2)
      {
        for (int j2 = num5 - 1; j2 < num5 + 4; ++j2)
          WorldGen.TileFrame(i2, j2);
      }
    }

    public static void Place3x3(int x, int y, int type)
    {
      bool flag = true;
      int num = 0;
      if (type == 106)
      {
        num = -2;
        for (int index1 = x - 1; index1 < x + 2; ++index1)
        {
          for (int index2 = y - 2; index2 < y + 1; ++index2)
          {
            if (Main.tile[index1, index2] == null)
              Main.tile[index1, index2] = new Tile();
            if (Main.tile[index1, index2].active)
              flag = false;
          }
        }
        for (int index = x - 1; index < x + 2; ++index)
        {
          if (Main.tile[index, y + 1] == null)
            Main.tile[index, y + 1] = new Tile();
          if (!Main.tile[index, y + 1].active || !Main.tileSolid[(int) Main.tile[index, y + 1].type])
          {
            flag = false;
            break;
          }
        }
      }
      else
      {
        for (int index3 = x - 1; index3 < x + 2; ++index3)
        {
          for (int index4 = y; index4 < y + 3; ++index4)
          {
            if (Main.tile[index3, index4] == null)
              Main.tile[index3, index4] = new Tile();
            if (Main.tile[index3, index4].active)
              flag = false;
          }
        }
        if (Main.tile[x, y - 1] == null)
          Main.tile[x, y - 1] = new Tile();
        if (!Main.tile[x, y - 1].active || !Main.tileSolid[(int) Main.tile[x, y - 1].type] || Main.tileSolidTop[(int) Main.tile[x, y - 1].type])
          flag = false;
      }
      if (!flag)
        return;
      Main.tile[x - 1, y + num].active = true;
      Main.tile[x - 1, y + num].frameY = (short) 0;
      Main.tile[x - 1, y + num].frameX = (short) 0;
      Main.tile[x - 1, y + num].type = (byte) type;
      Main.tile[x, y + num].active = true;
      Main.tile[x, y + num].frameY = (short) 0;
      Main.tile[x, y + num].frameX = (short) 18;
      Main.tile[x, y + num].type = (byte) type;
      Main.tile[x + 1, y + num].active = true;
      Main.tile[x + 1, y + num].frameY = (short) 0;
      Main.tile[x + 1, y + num].frameX = (short) 36;
      Main.tile[x + 1, y + num].type = (byte) type;
      Main.tile[x - 1, y + 1 + num].active = true;
      Main.tile[x - 1, y + 1 + num].frameY = (short) 18;
      Main.tile[x - 1, y + 1 + num].frameX = (short) 0;
      Main.tile[x - 1, y + 1 + num].type = (byte) type;
      Main.tile[x, y + 1 + num].active = true;
      Main.tile[x, y + 1 + num].frameY = (short) 18;
      Main.tile[x, y + 1 + num].frameX = (short) 18;
      Main.tile[x, y + 1 + num].type = (byte) type;
      Main.tile[x + 1, y + 1 + num].active = true;
      Main.tile[x + 1, y + 1 + num].frameY = (short) 18;
      Main.tile[x + 1, y + 1 + num].frameX = (short) 36;
      Main.tile[x + 1, y + 1 + num].type = (byte) type;
      Main.tile[x - 1, y + 2 + num].active = true;
      Main.tile[x - 1, y + 2 + num].frameY = (short) 36;
      Main.tile[x - 1, y + 2 + num].frameX = (short) 0;
      Main.tile[x - 1, y + 2 + num].type = (byte) type;
      Main.tile[x, y + 2 + num].active = true;
      Main.tile[x, y + 2 + num].frameY = (short) 36;
      Main.tile[x, y + 2 + num].frameX = (short) 18;
      Main.tile[x, y + 2 + num].type = (byte) type;
      Main.tile[x + 1, y + 2 + num].active = true;
      Main.tile[x + 1, y + 2 + num].frameY = (short) 36;
      Main.tile[x + 1, y + 2 + num].frameX = (short) 36;
      Main.tile[x + 1, y + 2 + num].type = (byte) type;
    }

    public static void PlaceSunflower(int x, int y, int type = 27)
    {
      if ((double) y > Main.worldSurface - 1.0)
        return;
      bool flag = true;
      for (int index1 = x; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 3; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active || Main.tile[index1, index2].wall > (byte) 0)
            flag = false;
        }
        if (Main.tile[index1, y + 1] == null)
          Main.tile[index1, y + 1] = new Tile();
        if (!Main.tile[index1, y + 1].active || Main.tile[index1, y + 1].type != (byte) 2 && Main.tile[index1, y + 1].type != (byte) 109)
          flag = false;
      }
      if (!flag)
        return;
      for (int index3 = 0; index3 < 2; ++index3)
      {
        for (int index4 = -3; index4 < 1; ++index4)
        {
          int num1 = index3 * 18 + WorldGen.genRand.Next(3) * 36;
          int num2 = (index4 + 3) * 18;
          Main.tile[x + index3, y + index4].active = true;
          Main.tile[x + index3, y + index4].frameX = (short) num1;
          Main.tile[x + index3, y + index4].frameY = (short) num2;
          Main.tile[x + index3, y + index4].type = (byte) type;
        }
      }
    }

    public static void CheckSunflower(int i, int j, int type = 27)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = 0;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18;
      int num4 = num2 + (int) Main.tile[i, j].frameY / 18 * -1;
      while (num3 > 1)
        num3 -= 2;
      int num5 = num3 * -1 + i;
      for (int index1 = num5; index1 < num5 + 2; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 4; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          int num6 = (int) Main.tile[index1, index2].frameX / 18;
          while (num6 > 1)
            num6 -= 2;
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || num6 != index1 - num5 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18)
            flag = true;
        }
        if (Main.tile[index1, num4 + 4] == null)
          Main.tile[index1, num4 + 4] = new Tile();
        if (!Main.tile[index1, num4 + 4].active || Main.tile[index1, num4 + 4].type != (byte) 2 && Main.tile[index1, num4 + 4].type != (byte) 109)
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int i1 = num5; i1 < num5 + 2; ++i1)
      {
        for (int j1 = num4; j1 < num4 + 4; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      Item.NewItem(i * 16, j * 16, 32, 32, 63);
      WorldGen.destroyObject = false;
    }

    public static bool PlacePot(int x, int y, int type = 28)
    {
      bool flag = true;
      for (int index1 = x; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active)
            flag = false;
        }
        if (Main.tile[index1, y + 1] == null)
          Main.tile[index1, y + 1] = new Tile();
        if (!Main.tile[index1, y + 1].active || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          flag = false;
      }
      if (!flag)
        return false;
      for (int index3 = 0; index3 < 2; ++index3)
      {
        for (int index4 = -1; index4 < 1; ++index4)
        {
          int num1 = index3 * 18 + WorldGen.genRand.Next(3) * 36;
          int num2 = (index4 + 1) * 18;
          Main.tile[x + index3, y + index4].active = true;
          Main.tile[x + index3, y + index4].frameX = (short) num1;
          Main.tile[x + index3, y + index4].frameY = (short) num2;
          Main.tile[x + index3, y + index4].type = (byte) type;
        }
      }
      return true;
    }

    public static bool CheckCactus(int i, int j)
    {
      int index1 = j;
      int index2 = i;
      while (Main.tile[index2, index1].active && Main.tile[index2, index1].type == (byte) 80)
      {
        ++index1;
        if (!Main.tile[index2, index1].active || Main.tile[index2, index1].type != (byte) 80)
        {
          if (Main.tile[index2 - 1, index1].active && Main.tile[index2 - 1, index1].type == (byte) 80 && Main.tile[index2 - 1, index1 - 1].active && Main.tile[index2 - 1, index1 - 1].type == (byte) 80 && index2 >= i)
            --index2;
          if (Main.tile[index2 + 1, index1].active && Main.tile[index2 + 1, index1].type == (byte) 80 && Main.tile[index2 + 1, index1 - 1].active && Main.tile[index2 + 1, index1 - 1].type == (byte) 80 && index2 <= i)
            ++index2;
        }
      }
      if (!Main.tile[index2, index1].active || Main.tile[index2, index1].type != (byte) 53 && Main.tile[index2, index1].type != (byte) 112 && Main.tile[index2, index1].type != (byte) 116)
      {
        WorldGen.KillTile(i, j);
        return true;
      }
      if (i != index2)
      {
        if ((!Main.tile[i, j + 1].active || Main.tile[i, j + 1].type != (byte) 80) && (!Main.tile[i - 1, j].active || Main.tile[i - 1, j].type != (byte) 80) && (!Main.tile[i + 1, j].active || Main.tile[i + 1, j].type != (byte) 80))
        {
          WorldGen.KillTile(i, j);
          return true;
        }
      }
      else if (i == index2 && (!Main.tile[i, j + 1].active || Main.tile[i, j + 1].type != (byte) 80 && Main.tile[i, j + 1].type != (byte) 53 && Main.tile[i, j + 1].type != (byte) 112 && Main.tile[i, j + 1].type != (byte) 116))
      {
        WorldGen.KillTile(i, j);
        return true;
      }
      return false;
    }

    public static void PlantCactus(int i, int j)
    {
      WorldGen.GrowCactus(i, j);
      for (int index = 0; index < 150; ++index)
        WorldGen.GrowCactus(WorldGen.genRand.Next(i - 1, i + 2), WorldGen.genRand.Next(j - 10, j + 2));
    }

    public static void CheckOrb(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int i1 = Main.tile[i, j].frameX != (short) 0 ? i - 1 : i;
      int j1 = Main.tile[i, j].frameY != (short) 0 ? j - 1 : j;
      if (Main.tile[i1, j1] == null || Main.tile[i1 + 1, j1] == null || Main.tile[i1, j1 + 1] == null || Main.tile[i1 + 1, j1 + 1] == null || Main.tile[i1, j1].active && (int) Main.tile[i1, j1].type == type && Main.tile[i1 + 1, j1].active && (int) Main.tile[i1 + 1, j1].type == type && Main.tile[i1, j1 + 1].active && (int) Main.tile[i1, j1 + 1].type == type && Main.tile[i1 + 1, j1 + 1].active && (int) Main.tile[i1 + 1, j1 + 1].type == type)
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[i1, j1].type == type)
        WorldGen.KillTile(i1, j1);
      if ((int) Main.tile[i1 + 1, j1].type == type)
        WorldGen.KillTile(i1 + 1, j1);
      if ((int) Main.tile[i1, j1 + 1].type == type)
        WorldGen.KillTile(i1, j1 + 1);
      if ((int) Main.tile[i1 + 1, j1 + 1].type == type)
        WorldGen.KillTile(i1 + 1, j1 + 1);
      if (Main.netMode != 1 && !WorldGen.noTileActions)
      {
        switch (type)
        {
          case 12:
            Item.NewItem(i1 * 16, j1 * 16, 32, 32, 29);
            break;
          case 31:
            if (WorldGen.genRand.Next(2) == 0)
              WorldGen.spawnMeteor = true;
            int num1 = Main.rand.Next(5);
            if (!WorldGen.shadowOrbSmashed)
              num1 = 0;
            switch (num1)
            {
              case 0:
                Item.NewItem(i1 * 16, j1 * 16, 32, 32, 96, pfix: -1);
                int Stack = WorldGen.genRand.Next(25, 51);
                Item.NewItem(i1 * 16, j1 * 16, 32, 32, 97, Stack);
                break;
              case 1:
                Item.NewItem(i1 * 16, j1 * 16, 32, 32, 64, pfix: -1);
                break;
              case 2:
                Item.NewItem(i1 * 16, j1 * 16, 32, 32, 162, pfix: -1);
                break;
              case 3:
                Item.NewItem(i1 * 16, j1 * 16, 32, 32, 115, pfix: -1);
                break;
              case 4:
                Item.NewItem(i1 * 16, j1 * 16, 32, 32, 111, pfix: -1);
                break;
            }
            WorldGen.shadowOrbSmashed = true;
            ++WorldGen.shadowOrbCount;
            if (WorldGen.shadowOrbCount >= 3)
            {
              WorldGen.shadowOrbCount = 0;
              float num2 = (float) (i1 * 16);
              float num3 = (float) (j1 * 16);
              float num4 = -1f;
              int plr = 0;
              for (int index = 0; index < (int) byte.MaxValue; ++index)
              {
                float num5 = Math.Abs(Main.player[index].position.X - num2) + Math.Abs(Main.player[index].position.Y - num3);
                if ((double) num5 < (double) num4 || (double) num4 == -1.0)
                {
                  plr = index;
                  num4 = num5;
                }
              }
              NPC.SpawnOnPlayer(plr, 13);
              break;
            }
            string str = Lang.misc[10];
            if (WorldGen.shadowOrbCount == 2)
              str = Lang.misc[11];
            switch (Main.netMode)
            {
              case 0:
                Main.NewText(str, (byte) 50, B: (byte) 130);
                break;
              case 2:
                NetMessage.SendData(25, text: str, number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
                break;
            }
            break;
        }
      }
      Main.PlaySound(13, i * 16, j * 16);
      WorldGen.destroyObject = false;
    }

    public static void CheckTree(int i, int j)
    {
      int index1 = -1;
      int index2 = -1;
      int index3 = -1;
      int index4 = -1;
      int index5 = -1;
      int index6 = -1;
      int index7 = -1;
      int index8 = -1;
      int type = (int) Main.tile[i, j].type;
      int frameX = (int) Main.tile[i, j].frameX;
      int frameY = (int) Main.tile[i, j].frameY;
      if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
        index4 = (int) Main.tile[i - 1, j].type;
      if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
        index5 = (int) Main.tile[i + 1, j].type;
      if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
        index2 = (int) Main.tile[i, j - 1].type;
      if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
        index7 = (int) Main.tile[i, j + 1].type;
      if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].active)
        index1 = (int) Main.tile[i - 1, j - 1].type;
      if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].active)
        index3 = (int) Main.tile[i + 1, j - 1].type;
      if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].active)
        index6 = (int) Main.tile[i - 1, j + 1].type;
      if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].active)
        index8 = (int) Main.tile[i + 1, j + 1].type;
      if (index4 >= 0 && Main.tileStone[index4])
        index4 = 1;
      if (index5 >= 0 && Main.tileStone[index5])
        index5 = 1;
      if (index2 >= 0 && Main.tileStone[index2])
        index2 = 1;
      if (index7 >= 0 && Main.tileStone[index7])
        index7 = 1;
      if (index1 >= 0 && Main.tileStone[index1])
        ;
      if (index3 >= 0 && Main.tileStone[index3])
        ;
      if (index6 >= 0 && Main.tileStone[index6])
        ;
      if (index8 >= 0 && Main.tileStone[index8])
        ;
      if (index7 == 23)
        index7 = 2;
      if (index7 == 60)
        index7 = 2;
      if (index7 == 109)
        index7 = 2;
      if (index7 == 147)
        index7 = 2;
      if (Main.tile[i, j].frameX >= (short) 22 && Main.tile[i, j].frameX <= (short) 44 && Main.tile[i, j].frameY >= (short) 132 && Main.tile[i, j].frameY <= (short) 176)
      {
        if (index7 != 2)
          WorldGen.KillTile(i, j);
        else if ((Main.tile[i, j].frameX != (short) 22 || index4 != type) && (Main.tile[i, j].frameX != (short) 44 || index5 != type))
          WorldGen.KillTile(i, j);
      }
      else if (Main.tile[i, j].frameX == (short) 88 && Main.tile[i, j].frameY >= (short) 0 && Main.tile[i, j].frameY <= (short) 44 || Main.tile[i, j].frameX == (short) 66 && Main.tile[i, j].frameY >= (short) 66 && Main.tile[i, j].frameY <= (short) 130 || Main.tile[i, j].frameX == (short) 110 && Main.tile[i, j].frameY >= (short) 66 && Main.tile[i, j].frameY <= (short) 110 || Main.tile[i, j].frameX == (short) 132 && Main.tile[i, j].frameY >= (short) 0 && Main.tile[i, j].frameY <= (short) 176)
      {
        if (index4 == type && index5 == type)
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 110;
            Main.tile[i, j].frameY = (short) 66;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 110;
            Main.tile[i, j].frameY = (short) 88;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 110;
            Main.tile[i, j].frameY = (short) 110;
          }
        }
        else if (index4 == type)
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) 0;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) 22;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) 44;
          }
        }
        else if (index5 == type)
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) 66;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) 88;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) 110;
          }
        }
        else
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 0;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 22;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 44;
          }
        }
      }
      if (Main.tile[i, j].frameY >= (short) 132 && Main.tile[i, j].frameY <= (short) 176 && (Main.tile[i, j].frameX == (short) 0 || Main.tile[i, j].frameX == (short) 66 || Main.tile[i, j].frameX == (short) 88))
      {
        if (index7 != 2)
          WorldGen.KillTile(i, j);
        if (index4 != type && index5 != type)
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 0;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 22;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 44;
          }
        }
        else if (index4 != type)
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 132;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 154;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) 176;
          }
        }
        else if (index5 != type)
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) 132;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) 154;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) 176;
          }
        }
        else
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) 132;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) 154;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) 176;
          }
        }
      }
      if (Main.tile[i, j].frameX == (short) 66 && (Main.tile[i, j].frameY == (short) 0 || Main.tile[i, j].frameY == (short) 22 || Main.tile[i, j].frameY == (short) 44) || Main.tile[i, j].frameX == (short) 44 && (Main.tile[i, j].frameY == (short) 198 || Main.tile[i, j].frameY == (short) 220 || Main.tile[i, j].frameY == (short) 242))
      {
        if (index5 != type)
          WorldGen.KillTile(i, j);
      }
      else if (Main.tile[i, j].frameX == (short) 88 && (Main.tile[i, j].frameY == (short) 66 || Main.tile[i, j].frameY == (short) 88 || Main.tile[i, j].frameY == (short) 110) || Main.tile[i, j].frameX == (short) 66 && (Main.tile[i, j].frameY == (short) 198 || Main.tile[i, j].frameY == (short) 220 || Main.tile[i, j].frameY == (short) 242))
      {
        if (index4 != type)
          WorldGen.KillTile(i, j);
      }
      else if (index7 == -1 || index7 == 23)
        WorldGen.KillTile(i, j);
      else if (index2 != type && Main.tile[i, j].frameY < (short) 198 && (Main.tile[i, j].frameX != (short) 22 && Main.tile[i, j].frameX != (short) 44 || Main.tile[i, j].frameY < (short) 132))
      {
        if (index4 == type || index5 == type)
        {
          if (index7 == type)
          {
            if (index4 == type && index5 == type)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 132;
              }
              if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 154;
              }
              if (Main.tile[i, j].frameNumber == (byte) 2)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 176;
              }
            }
            else if (index4 == type)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 0;
              }
              if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 22;
              }
              if (Main.tile[i, j].frameNumber == (byte) 2)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 44;
              }
            }
            else if (index5 == type)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 66;
              }
              if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 88;
              }
              if (Main.tile[i, j].frameNumber == (byte) 2)
              {
                Main.tile[i, j].frameX = (short) 132;
                Main.tile[i, j].frameY = (short) 110;
              }
            }
          }
          else if (index4 == type && index5 == type)
          {
            if (Main.tile[i, j].frameNumber == (byte) 0)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 132;
            }
            if (Main.tile[i, j].frameNumber == (byte) 1)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 154;
            }
            if (Main.tile[i, j].frameNumber == (byte) 2)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 176;
            }
          }
          else if (index4 == type)
          {
            if (Main.tile[i, j].frameNumber == (byte) 0)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 0;
            }
            if (Main.tile[i, j].frameNumber == (byte) 1)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 22;
            }
            if (Main.tile[i, j].frameNumber == (byte) 2)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 44;
            }
          }
          else if (index5 == type)
          {
            if (Main.tile[i, j].frameNumber == (byte) 0)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 66;
            }
            if (Main.tile[i, j].frameNumber == (byte) 1)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 88;
            }
            if (Main.tile[i, j].frameNumber == (byte) 2)
            {
              Main.tile[i, j].frameX = (short) 154;
              Main.tile[i, j].frameY = (short) 110;
            }
          }
        }
        else
        {
          if (Main.tile[i, j].frameNumber == (byte) 0)
          {
            Main.tile[i, j].frameX = (short) 110;
            Main.tile[i, j].frameY = (short) 0;
          }
          if (Main.tile[i, j].frameNumber == (byte) 1)
          {
            Main.tile[i, j].frameX = (short) 110;
            Main.tile[i, j].frameY = (short) 22;
          }
          if (Main.tile[i, j].frameNumber == (byte) 2)
          {
            Main.tile[i, j].frameX = (short) 110;
            Main.tile[i, j].frameY = (short) 44;
          }
        }
      }
      if ((int) Main.tile[i, j].frameX == frameX || (int) Main.tile[i, j].frameY == frameY || frameX < 0 || frameY < 0)
        return;
      WorldGen.TileFrame(i - 1, j);
      WorldGen.TileFrame(i + 1, j);
      WorldGen.TileFrame(i, j - 1);
      WorldGen.TileFrame(i, j + 1);
    }

    public static void CactusFrame(int i, int j)
    {
      try
      {
        int index1 = j;
        int index2 = i;
        if (WorldGen.CheckCactus(i, j))
          return;
        while (Main.tile[index2, index1].active && Main.tile[index2, index1].type == (byte) 80)
        {
          ++index1;
          if (!Main.tile[index2, index1].active || Main.tile[index2, index1].type != (byte) 80)
          {
            if (Main.tile[index2 - 1, index1].active && Main.tile[index2 - 1, index1].type == (byte) 80 && Main.tile[index2 - 1, index1 - 1].active && Main.tile[index2 - 1, index1 - 1].type == (byte) 80 && index2 >= i)
              --index2;
            if (Main.tile[index2 + 1, index1].active && Main.tile[index2 + 1, index1].type == (byte) 80 && Main.tile[index2 + 1, index1 - 1].active && Main.tile[index2 + 1, index1 - 1].type == (byte) 80 && index2 <= i)
              ++index2;
          }
        }
        int num1 = index1 - 1;
        int num2 = i - index2;
        num1 = j;
        int type = (int) Main.tile[i - 2, j].type;
        int num3 = (int) Main.tile[i - 1, j].type;
        int num4 = (int) Main.tile[i + 1, j].type;
        int num5 = (int) Main.tile[i, j - 1].type;
        int index3 = (int) Main.tile[i, j + 1].type;
        int num6 = (int) Main.tile[i - 1, j + 1].type;
        int num7 = (int) Main.tile[i + 1, j + 1].type;
        if (!Main.tile[i - 1, j].active)
          num3 = -1;
        if (!Main.tile[i + 1, j].active)
          num4 = -1;
        if (!Main.tile[i, j - 1].active)
          num5 = -1;
        if (!Main.tile[i, j + 1].active)
          index3 = -1;
        if (!Main.tile[i - 1, j + 1].active)
          num6 = -1;
        if (!Main.tile[i + 1, j + 1].active)
          num7 = -1;
        short num8 = Main.tile[i, j].frameX;
        short num9 = Main.tile[i, j].frameY;
        switch (num2)
        {
          case -1:
            if (num4 == 80)
            {
              if (num5 != 80 && index3 != 80)
              {
                num8 = (short) 108;
                num9 = (short) 36;
                break;
              }
              if (index3 != 80)
              {
                num8 = (short) 54;
                num9 = (short) 36;
                break;
              }
              if (num5 != 80)
              {
                num8 = (short) 54;
                num9 = (short) 0;
                break;
              }
              num8 = (short) 54;
              num9 = (short) 18;
              break;
            }
            if (num5 != 80)
            {
              num8 = (short) 54;
              num9 = (short) 0;
              break;
            }
            num8 = (short) 54;
            num9 = (short) 18;
            break;
          case 0:
            if (num5 != 80)
            {
              if (num3 == 80 && num4 == 80 && num6 != 80 && num7 != 80 && type != 80)
              {
                num8 = (short) 90;
                num9 = (short) 0;
                break;
              }
              if (num3 == 80 && num6 != 80 && type != 80)
              {
                num8 = (short) 72;
                num9 = (short) 0;
                break;
              }
              if (num4 == 80 && num7 != 80)
              {
                num8 = (short) 18;
                num9 = (short) 0;
                break;
              }
              num8 = (short) 0;
              num9 = (short) 0;
              break;
            }
            if (num3 == 80 && num4 == 80 && num6 != 80 && num7 != 80 && type != 80)
            {
              num8 = (short) 90;
              num9 = (short) 36;
              break;
            }
            if (num3 == 80 && num6 != 80 && type != 80)
            {
              num8 = (short) 72;
              num9 = (short) 36;
              break;
            }
            if (num4 == 80 && num7 != 80)
            {
              num8 = (short) 18;
              num9 = (short) 36;
              break;
            }
            if (index3 >= 0 && Main.tileSolid[index3])
            {
              num8 = (short) 0;
              num9 = (short) 36;
              break;
            }
            num8 = (short) 0;
            num9 = (short) 18;
            break;
          case 1:
            if (num3 == 80)
            {
              if (num5 != 80 && index3 != 80)
              {
                num8 = (short) 108;
                num9 = (short) 16;
                break;
              }
              if (index3 != 80)
              {
                num8 = (short) 36;
                num9 = (short) 36;
                break;
              }
              if (num5 != 80)
              {
                num8 = (short) 36;
                num9 = (short) 0;
                break;
              }
              num8 = (short) 36;
              num9 = (short) 18;
              break;
            }
            if (num5 != 80)
            {
              num8 = (short) 36;
              num9 = (short) 0;
              break;
            }
            num8 = (short) 36;
            num9 = (short) 18;
            break;
        }
        if ((int) num8 == (int) Main.tile[i, j].frameX && (int) num9 == (int) Main.tile[i, j].frameY)
          return;
        Main.tile[i, j].frameX = num8;
        Main.tile[i, j].frameY = num9;
        WorldGen.SquareTileFrame(i, j);
      }
      catch
      {
        Main.tile[i, j].frameX = (short) 0;
        Main.tile[i, j].frameY = (short) 0;
      }
    }

    public static void GrowCactus(int i, int j)
    {
      int index1 = j;
      int i1 = i;
      if (!Main.tile[i, j].active || Main.tile[i, j - 1].liquid > (byte) 0 || Main.tile[i, j].type != (byte) 53 && Main.tile[i, j].type != (byte) 80 && Main.tile[i, j].type != (byte) 112 && Main.tile[i, j].type != (byte) 116)
        return;
      if (Main.tile[i, j].type == (byte) 53 || Main.tile[i, j].type == (byte) 112 || Main.tile[i, j].type == (byte) 116)
      {
        if (Main.tile[i, j - 1].active || Main.tile[i - 1, j - 1].active || Main.tile[i + 1, j - 1].active)
          return;
        int num1 = 0;
        int num2 = 0;
        for (int index2 = i - 6; index2 <= i + 6; ++index2)
        {
          for (int index3 = j - 3; index3 <= j + 1; ++index3)
          {
            try
            {
              if (Main.tile[index2, index3].active)
              {
                if (Main.tile[index2, index3].type == (byte) 80)
                {
                  ++num1;
                  if (num1 >= 4)
                    return;
                }
                if (Main.tile[index2, index3].type != (byte) 53 && Main.tile[index2, index3].type != (byte) 112)
                {
                  if (Main.tile[index2, index3].type != (byte) 116)
                    continue;
                }
                ++num2;
              }
            }
            catch
            {
            }
          }
        }
        if (num2 <= 10)
          return;
        Main.tile[i, j - 1].active = true;
        Main.tile[i, j - 1].type = (byte) 80;
        if (Main.netMode == 2)
          NetMessage.SendTileSquare(-1, i, j - 1, 1);
        WorldGen.SquareTileFrame(i1, index1 - 1);
      }
      else
      {
        if (Main.tile[i, j].type != (byte) 80)
          return;
        while (Main.tile[i1, index1].active && Main.tile[i1, index1].type == (byte) 80)
        {
          ++index1;
          if (!Main.tile[i1, index1].active || Main.tile[i1, index1].type != (byte) 80)
          {
            if (Main.tile[i1 - 1, index1].active && Main.tile[i1 - 1, index1].type == (byte) 80 && Main.tile[i1 - 1, index1 - 1].active && Main.tile[i1 - 1, index1 - 1].type == (byte) 80 && i1 >= i)
              --i1;
            if (Main.tile[i1 + 1, index1].active && Main.tile[i1 + 1, index1].type == (byte) 80 && Main.tile[i1 + 1, index1 - 1].active && Main.tile[i1 + 1, index1 - 1].type == (byte) 80 && i1 <= i)
              ++i1;
          }
        }
        int num3 = index1 - 1 - j;
        int num4 = i - i1;
        int num5 = i - num4;
        int num6 = j;
        int num7 = 11 - num3;
        int num8 = 0;
        for (int index4 = num5 - 2; index4 <= num5 + 2; ++index4)
        {
          for (int index5 = num6 - num7; index5 <= num6 + num3; ++index5)
          {
            if (Main.tile[index4, index5].active && Main.tile[index4, index5].type == (byte) 80)
              ++num8;
          }
        }
        if (num8 >= WorldGen.genRand.Next(11, 13))
          return;
        int index6 = i;
        int index7 = j;
        if (num4 == 0)
        {
          if (num3 == 0)
          {
            if (Main.tile[index6, index7 - 1].active)
              return;
            Main.tile[index6, index7 - 1].active = true;
            Main.tile[index6, index7 - 1].type = (byte) 80;
            WorldGen.SquareTileFrame(index6, index7 - 1);
            if (Main.netMode != 2)
              return;
            NetMessage.SendTileSquare(-1, index6, index7 - 1, 1);
          }
          else
          {
            bool flag1 = false;
            bool flag2 = false;
            if (Main.tile[index6, index7 - 1].active && Main.tile[index6, index7 - 1].type == (byte) 80)
            {
              if (!Main.tile[index6 - 1, index7].active && !Main.tile[index6 - 2, index7 + 1].active && !Main.tile[index6 - 1, index7 - 1].active && !Main.tile[index6 - 1, index7 + 1].active && !Main.tile[index6 - 2, index7].active)
                flag1 = true;
              if (!Main.tile[index6 + 1, index7].active && !Main.tile[index6 + 2, index7 + 1].active && !Main.tile[index6 + 1, index7 - 1].active && !Main.tile[index6 + 1, index7 + 1].active && !Main.tile[index6 + 2, index7].active)
                flag2 = true;
            }
            int num9 = WorldGen.genRand.Next(3);
            if (num9 == 0 && flag1)
            {
              Main.tile[index6 - 1, index7].active = true;
              Main.tile[index6 - 1, index7].type = (byte) 80;
              WorldGen.SquareTileFrame(index6 - 1, index7);
              if (Main.netMode != 2)
                return;
              NetMessage.SendTileSquare(-1, index6 - 1, index7, 1);
            }
            else if (num9 == 1 && flag2)
            {
              Main.tile[index6 + 1, index7].active = true;
              Main.tile[index6 + 1, index7].type = (byte) 80;
              WorldGen.SquareTileFrame(index6 + 1, index7);
              if (Main.netMode != 2)
                return;
              NetMessage.SendTileSquare(-1, index6 + 1, index7, 1);
            }
            else
            {
              if (num3 >= WorldGen.genRand.Next(2, 8))
                return;
              if (Main.tile[index6 - 1, index7 - 1].active)
              {
                int type = (int) Main.tile[index6 - 1, index7 - 1].type;
              }
              if (Main.tile[index6 + 1, index7 - 1].active && Main.tile[index6 + 1, index7 - 1].type == (byte) 80 || Main.tile[index6, index7 - 1].active)
                return;
              Main.tile[index6, index7 - 1].active = true;
              Main.tile[index6, index7 - 1].type = (byte) 80;
              WorldGen.SquareTileFrame(index6, index7 - 1);
              if (Main.netMode != 2)
                return;
              NetMessage.SendTileSquare(-1, index6, index7 - 1, 1);
            }
          }
        }
        else
        {
          if (Main.tile[index6, index7 - 1].active || Main.tile[index6, index7 - 2].active || Main.tile[index6 + num4, index7 - 1].active || !Main.tile[index6 - num4, index7 - 1].active || Main.tile[index6 - num4, index7 - 1].type != (byte) 80)
            return;
          Main.tile[index6, index7 - 1].active = true;
          Main.tile[index6, index7 - 1].type = (byte) 80;
          WorldGen.SquareTileFrame(index6, index7 - 1);
          if (Main.netMode != 2)
            return;
          NetMessage.SendTileSquare(-1, index6, index7 - 1, 1);
        }
      }
    }

    public static void CheckPot(int i, int j, int type = 28)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = 0;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18;
      int index1 = num2 + (int) Main.tile[i, j].frameY / 18 * -1;
      while (num3 > 1)
        num3 -= 2;
      int index2 = num3 * -1 + i;
      for (int index3 = index2; index3 < index2 + 2; ++index3)
      {
        for (int index4 = index1; index4 < index1 + 2; ++index4)
        {
          if (Main.tile[index3, index4] == null)
            Main.tile[index3, index4] = new Tile();
          int num4 = (int) Main.tile[index3, index4].frameX / 18;
          while (num4 > 1)
            num4 -= 2;
          if (!Main.tile[index3, index4].active || (int) Main.tile[index3, index4].type != type || num4 != index3 - index2 || (int) Main.tile[index3, index4].frameY != (index4 - index1) * 18)
            flag = true;
        }
        if (Main.tile[index3, index1 + 2] == null)
          Main.tile[index3, index1 + 2] = new Tile();
        if (!Main.tile[index3, index1 + 2].active || !Main.tileSolid[(int) Main.tile[index3, index1 + 2].type])
          flag = true;
      }
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      Main.PlaySound(13, i * 16, j * 16);
      for (int i1 = index2; i1 < index2 + 2; ++i1)
      {
        for (int j1 = index1; j1 < index1 + 2; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && Main.tile[i1, j1].active)
            WorldGen.KillTile(i1, j1);
        }
      }
      Gore.NewGore(new Vector2((float) (i * 16), (float) (j * 16)), new Vector2(), 51);
      Gore.NewGore(new Vector2((float) (i * 16), (float) (j * 16)), new Vector2(), 52);
      Gore.NewGore(new Vector2((float) (i * 16), (float) (j * 16)), new Vector2(), 53);
      if (WorldGen.genRand.Next(40) == 0 && (Main.tile[index2, index1].wall == (byte) 7 || Main.tile[index2, index1].wall == (byte) 8 || Main.tile[index2, index1].wall == (byte) 9))
        Item.NewItem(i * 16, j * 16, 16, 16, 327);
      else if (WorldGen.genRand.Next(45) == 0)
      {
        if ((double) j < Main.worldSurface)
        {
          int num5 = WorldGen.genRand.Next(4);
          if (num5 == 0)
            Item.NewItem(i * 16, j * 16, 16, 16, 292);
          if (num5 == 1)
            Item.NewItem(i * 16, j * 16, 16, 16, 298);
          if (num5 == 2)
            Item.NewItem(i * 16, j * 16, 16, 16, 299);
          if (num5 == 3)
            Item.NewItem(i * 16, j * 16, 16, 16, 290);
        }
        else if ((double) j < Main.rockLayer)
        {
          int num6 = WorldGen.genRand.Next(7);
          if (num6 == 0)
            Item.NewItem(i * 16, j * 16, 16, 16, 289);
          if (num6 == 1)
            Item.NewItem(i * 16, j * 16, 16, 16, 298);
          if (num6 == 2)
            Item.NewItem(i * 16, j * 16, 16, 16, 299);
          if (num6 == 3)
            Item.NewItem(i * 16, j * 16, 16, 16, 290);
          if (num6 == 4)
            Item.NewItem(i * 16, j * 16, 16, 16, 303);
          if (num6 == 5)
            Item.NewItem(i * 16, j * 16, 16, 16, 291);
          if (num6 == 6)
            Item.NewItem(i * 16, j * 16, 16, 16, 304);
        }
        else if (j < Main.maxTilesY - 200)
        {
          int num7 = WorldGen.genRand.Next(10);
          if (num7 == 0)
            Item.NewItem(i * 16, j * 16, 16, 16, 296);
          if (num7 == 1)
            Item.NewItem(i * 16, j * 16, 16, 16, 295);
          if (num7 == 2)
            Item.NewItem(i * 16, j * 16, 16, 16, 299);
          if (num7 == 3)
            Item.NewItem(i * 16, j * 16, 16, 16, 302);
          if (num7 == 4)
            Item.NewItem(i * 16, j * 16, 16, 16, 303);
          if (num7 == 5)
            Item.NewItem(i * 16, j * 16, 16, 16, 305);
          if (num7 == 6)
            Item.NewItem(i * 16, j * 16, 16, 16, 301);
          if (num7 == 7)
            Item.NewItem(i * 16, j * 16, 16, 16, 302);
          if (num7 == 8)
            Item.NewItem(i * 16, j * 16, 16, 16, 297);
          if (num7 == 9)
            Item.NewItem(i * 16, j * 16, 16, 16, 304);
        }
        else
        {
          int num8 = WorldGen.genRand.Next(12);
          if (num8 == 0)
            Item.NewItem(i * 16, j * 16, 16, 16, 296);
          if (num8 == 1)
            Item.NewItem(i * 16, j * 16, 16, 16, 295);
          if (num8 == 2)
            Item.NewItem(i * 16, j * 16, 16, 16, 293);
          if (num8 == 3)
            Item.NewItem(i * 16, j * 16, 16, 16, 288);
          if (num8 == 4)
            Item.NewItem(i * 16, j * 16, 16, 16, 294);
          if (num8 == 5)
            Item.NewItem(i * 16, j * 16, 16, 16, 297);
          if (num8 == 6)
            Item.NewItem(i * 16, j * 16, 16, 16, 304);
          if (num8 == 7)
            Item.NewItem(i * 16, j * 16, 16, 16, 305);
          if (num8 == 8)
            Item.NewItem(i * 16, j * 16, 16, 16, 301);
          if (num8 == 9)
            Item.NewItem(i * 16, j * 16, 16, 16, 302);
          if (num8 == 10)
            Item.NewItem(i * 16, j * 16, 16, 16, 288);
          if (num8 == 11)
            Item.NewItem(i * 16, j * 16, 16, 16, 300);
        }
      }
      else
      {
        int num9 = Main.rand.Next(8);
        if (num9 == 0 && Main.player[(int) Player.FindClosest(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16)].statLife < Main.player[(int) Player.FindClosest(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16)].statLifeMax)
          Item.NewItem(i * 16, j * 16, 16, 16, 58);
        else if (num9 == 1 && Main.player[(int) Player.FindClosest(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16)].statMana < Main.player[(int) Player.FindClosest(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16)].statManaMax)
        {
          Item.NewItem(i * 16, j * 16, 16, 16, 184);
        }
        else
        {
          switch (num9)
          {
            case 2:
              int Stack1 = Main.rand.Next(1, 6);
              if (Main.tile[i, j].liquid > (byte) 0)
              {
                Item.NewItem(i * 16, j * 16, 16, 16, 282, Stack1);
                break;
              }
              Item.NewItem(i * 16, j * 16, 16, 16, 8, Stack1);
              break;
            case 3:
              int Stack2 = Main.rand.Next(8) + 3;
              int Type1 = 40;
              if ((double) j < Main.rockLayer && WorldGen.genRand.Next(2) == 0)
                Type1 = !Main.hardMode ? 42 : 168;
              if (j > Main.maxTilesY - 200)
                Type1 = 265;
              else if (Main.hardMode)
                Type1 = Main.rand.Next(2) != 0 ? 47 : 278;
              Item.NewItem(i * 16, j * 16, 16, 16, Type1, Stack2);
              break;
            case 4:
              int Type2 = 28;
              if (j > Main.maxTilesY - 200 || Main.hardMode)
                Type2 = 188;
              Item.NewItem(i * 16, j * 16, 16, 16, Type2);
              break;
            default:
              if (num9 == 5 && (double) j > Main.rockLayer)
              {
                int Stack3 = Main.rand.Next(4) + 1;
                Item.NewItem(i * 16, j * 16, 16, 16, 166, Stack3);
                break;
              }
              float num10 = (float) (200 + WorldGen.genRand.Next(-100, 101));
              if ((double) j < Main.worldSurface)
                num10 *= 0.5f;
              else if ((double) j < Main.rockLayer)
                num10 *= 0.75f;
              else if (j > Main.maxTilesY - 250)
                num10 *= 1.25f;
              float num11 = num10 * (float) (1.0 + (double) Main.rand.Next(-20, 21) * 0.00999999977648258);
              if (Main.rand.Next(5) == 0)
                num11 *= (float) (1.0 + (double) Main.rand.Next(5, 11) * 0.00999999977648258);
              if (Main.rand.Next(10) == 0)
                num11 *= (float) (1.0 + (double) Main.rand.Next(10, 21) * 0.00999999977648258);
              if (Main.rand.Next(15) == 0)
                num11 *= (float) (1.0 + (double) Main.rand.Next(20, 41) * 0.00999999977648258);
              if (Main.rand.Next(20) == 0)
                num11 *= (float) (1.0 + (double) Main.rand.Next(40, 81) * 0.00999999977648258);
              if (Main.rand.Next(25) == 0)
                num11 *= (float) (1.0 + (double) Main.rand.Next(50, 101) * 0.00999999977648258);
              while ((int) num11 > 0)
              {
                if ((double) num11 > 1000000.0)
                {
                  int Stack4 = (int) ((double) num11 / 1000000.0);
                  if (Stack4 > 50 && Main.rand.Next(2) == 0)
                    Stack4 /= Main.rand.Next(3) + 1;
                  if (Main.rand.Next(2) == 0)
                    Stack4 /= Main.rand.Next(3) + 1;
                  num11 -= (float) (1000000 * Stack4);
                  Item.NewItem(i * 16, j * 16, 16, 16, 74, Stack4);
                }
                else if ((double) num11 > 10000.0)
                {
                  int Stack5 = (int) ((double) num11 / 10000.0);
                  if (Stack5 > 50 && Main.rand.Next(2) == 0)
                    Stack5 /= Main.rand.Next(3) + 1;
                  if (Main.rand.Next(2) == 0)
                    Stack5 /= Main.rand.Next(3) + 1;
                  num11 -= (float) (10000 * Stack5);
                  Item.NewItem(i * 16, j * 16, 16, 16, 73, Stack5);
                }
                else if ((double) num11 > 100.0)
                {
                  int Stack6 = (int) ((double) num11 / 100.0);
                  if (Stack6 > 50 && Main.rand.Next(2) == 0)
                    Stack6 /= Main.rand.Next(3) + 1;
                  if (Main.rand.Next(2) == 0)
                    Stack6 /= Main.rand.Next(3) + 1;
                  num11 -= (float) (100 * Stack6);
                  Item.NewItem(i * 16, j * 16, 16, 16, 72, Stack6);
                }
                else
                {
                  int Stack7 = (int) num11;
                  if (Stack7 > 50 && Main.rand.Next(2) == 0)
                    Stack7 /= Main.rand.Next(3) + 1;
                  if (Main.rand.Next(2) == 0)
                    Stack7 /= Main.rand.Next(4) + 1;
                  if (Stack7 < 1)
                    Stack7 = 1;
                  num11 -= (float) Stack7;
                  Item.NewItem(i * 16, j * 16, 16, 16, 71, Stack7);
                }
              }
              break;
          }
        }
      }
      WorldGen.destroyObject = false;
    }

    public static int PlaceChest(int x, int y, int type = 21, bool notNearOtherChests = false, int style = 0)
    {
      bool flag = true;
      int num = -1;
      for (int index1 = x; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          if (Main.tile[index1, index2].active)
            flag = false;
          if (Main.tile[index1, index2].lava)
            flag = false;
        }
        if (Main.tile[index1, y + 1] == null)
          Main.tile[index1, y + 1] = new Tile();
        if (!Main.tile[index1, y + 1].active || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          flag = false;
      }
      if (flag && notNearOtherChests)
      {
        for (int index3 = x - 25; index3 < x + 25; ++index3)
        {
          for (int index4 = y - 8; index4 < y + 8; ++index4)
          {
            try
            {
              if (Main.tile[index3, index4].active)
              {
                if (Main.tile[index3, index4].type == (byte) 21)
                {
                  flag = false;
                  return -1;
                }
              }
            }
            catch
            {
            }
          }
        }
      }
      if (flag)
      {
        num = Chest.CreateChest(x, y - 1);
        if (num == -1)
          flag = false;
      }
      if (flag)
      {
        Main.tile[x, y - 1].active = true;
        Main.tile[x, y - 1].frameY = (short) 0;
        Main.tile[x, y - 1].frameX = (short) (36 * style);
        Main.tile[x, y - 1].type = (byte) type;
        Main.tile[x + 1, y - 1].active = true;
        Main.tile[x + 1, y - 1].frameY = (short) 0;
        Main.tile[x + 1, y - 1].frameX = (short) (18 + 36 * style);
        Main.tile[x + 1, y - 1].type = (byte) type;
        Main.tile[x, y].active = true;
        Main.tile[x, y].frameY = (short) 18;
        Main.tile[x, y].frameX = (short) (36 * style);
        Main.tile[x, y].type = (byte) type;
        Main.tile[x + 1, y].active = true;
        Main.tile[x + 1, y].frameY = (short) 18;
        Main.tile[x + 1, y].frameX = (short) (18 + 36 * style);
        Main.tile[x + 1, y].type = (byte) type;
      }
      return num;
    }

    public static void CheckChest(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      bool flag = false;
      int num1 = 0;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18;
      int num4 = num2 + (int) Main.tile[i, j].frameY / 18 * -1;
      while (num3 > 1)
        num3 -= 2;
      int num5 = num3 * -1 + i;
      for (int index1 = num5; index1 < num5 + 2; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 2; ++index2)
        {
          if (Main.tile[index1, index2] == null)
            Main.tile[index1, index2] = new Tile();
          int num6 = (int) Main.tile[index1, index2].frameX / 18;
          while (num6 > 1)
            num6 -= 2;
          if (!Main.tile[index1, index2].active || (int) Main.tile[index1, index2].type != type || num6 != index1 - num5 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18)
            flag = true;
        }
        if (Main.tile[index1, num4 + 2] == null)
          Main.tile[index1, num4 + 2] = new Tile();
        if (!Main.tile[index1, num4 + 2].active || !Main.tileSolid[(int) Main.tile[index1, num4 + 2].type])
          flag = true;
      }
      if (!flag)
        return;
      int Type = 48;
      if (Main.tile[i, j].frameX >= (short) 216)
        Type = 348;
      else if (Main.tile[i, j].frameX >= (short) 180)
        Type = 343;
      else if (Main.tile[i, j].frameX >= (short) 108)
        Type = 328;
      else if (Main.tile[i, j].frameX >= (short) 36)
        Type = 306;
      WorldGen.destroyObject = true;
      for (int index3 = num5; index3 < num5 + 2; ++index3)
      {
        for (int index4 = num4; index4 < num4 + 3; ++index4)
        {
          if ((int) Main.tile[index3, index4].type == type && Main.tile[index3, index4].active)
          {
            Chest.DestroyChest(index3, index4);
            WorldGen.KillTile(index3, index4);
          }
        }
      }
      Item.NewItem(i * 16, j * 16, 32, 32, Type);
      WorldGen.destroyObject = false;
    }

    public static bool PlaceWire(int i, int j)
    {
      if (Main.tile[i, j].wire)
        return false;
      Main.PlaySound(0, i * 16, j * 16);
      Main.tile[i, j].wire = true;
      return true;
    }

    public static bool KillWire(int i, int j)
    {
      if (!Main.tile[i, j].wire)
        return false;
      Main.PlaySound(0, i * 16, j * 16);
      Main.tile[i, j].wire = false;
      if (Main.netMode != 1)
        Item.NewItem(i * 16, j * 16, 16, 16, 530);
      for (int index = 0; index < 5; ++index)
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 50);
      return true;
    }

    public static bool PlaceTile(
      int i,
      int j,
      int type,
      bool mute = false,
      bool forced = false,
      int plr = -1,
      int style = 0)
    {
      if (type >= 150)
        return false;
      bool flag = false;
      if (i >= 0 && j >= 0 && i < Main.maxTilesX && j < Main.maxTilesY)
      {
        if (Main.tile[i, j] == null)
          Main.tile[i, j] = new Tile();
        if (forced || Collision.EmptyTile(i, j) || !Main.tileSolid[type] || type == 23 && Main.tile[i, j].type == (byte) 0 && Main.tile[i, j].active || type == 2 && Main.tile[i, j].type == (byte) 0 && Main.tile[i, j].active || type == 109 && Main.tile[i, j].type == (byte) 0 && Main.tile[i, j].active || type == 60 && Main.tile[i, j].type == (byte) 59 && Main.tile[i, j].active || type == 70 && Main.tile[i, j].type == (byte) 59 && Main.tile[i, j].active)
        {
          if (type == 23 && (Main.tile[i, j].type != (byte) 0 || !Main.tile[i, j].active) || type == 2 && (Main.tile[i, j].type != (byte) 0 || !Main.tile[i, j].active) || type == 109 && (Main.tile[i, j].type != (byte) 0 || !Main.tile[i, j].active) || type == 60 && (Main.tile[i, j].type != (byte) 59 || !Main.tile[i, j].active))
            return false;
          if (type == 81)
          {
            if (Main.tile[i - 1, j] == null)
              Main.tile[i - 1, j] = new Tile();
            if (Main.tile[i + 1, j] == null)
              Main.tile[i + 1, j] = new Tile();
            if (Main.tile[i, j - 1] == null)
              Main.tile[i, j - 1] = new Tile();
            if (Main.tile[i, j + 1] == null)
              Main.tile[i, j + 1] = new Tile();
            if (Main.tile[i - 1, j].active || Main.tile[i + 1, j].active || Main.tile[i, j - 1].active || !Main.tile[i, j + 1].active || !Main.tileSolid[(int) Main.tile[i, j + 1].type])
              return false;
          }
          if (Main.tile[i, j].liquid > (byte) 0)
          {
            if (type == 4)
            {
              if (style != 8)
                return false;
            }
            else if (type == 3 || type == 4 || type == 20 || type == 24 || type == 27 || type == 32 || type == 51 || type == 69 || type == 72)
              return false;
          }
          Main.tile[i, j].frameY = (short) 0;
          Main.tile[i, j].frameX = (short) 0;
          if (type == 3 || type == 24 || type == 110)
          {
            if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1].active && (Main.tile[i, j + 1].type == (byte) 2 && type == 3 || Main.tile[i, j + 1].type == (byte) 23 && type == 24 || Main.tile[i, j + 1].type == (byte) 78 && type == 3 || Main.tile[i, j + 1].type == (byte) 109 && type == 110))
            {
              if (type == 24 && WorldGen.genRand.Next(13) == 0)
              {
                Main.tile[i, j].active = true;
                Main.tile[i, j].type = (byte) 32;
                WorldGen.SquareTileFrame(i, j);
              }
              else if (Main.tile[i, j + 1].type == (byte) 78)
              {
                Main.tile[i, j].active = true;
                Main.tile[i, j].type = (byte) type;
                Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(2) * 18 + 108);
              }
              else if (Main.tile[i, j].wall == (byte) 0 && Main.tile[i, j + 1].wall == (byte) 0)
              {
                if (WorldGen.genRand.Next(50) == 0 || type == 24 && WorldGen.genRand.Next(40) == 0)
                {
                  Main.tile[i, j].active = true;
                  Main.tile[i, j].type = (byte) type;
                  Main.tile[i, j].frameX = (short) 144;
                }
                else if (WorldGen.genRand.Next(35) == 0)
                {
                  Main.tile[i, j].active = true;
                  Main.tile[i, j].type = (byte) type;
                  Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(2) * 18 + 108);
                }
                else
                {
                  Main.tile[i, j].active = true;
                  Main.tile[i, j].type = (byte) type;
                  Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(6) * 18);
                }
              }
            }
          }
          else
          {
            switch (type)
            {
              case 61:
                if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1].active && Main.tile[i, j + 1].type == (byte) 60)
                {
                  if (WorldGen.genRand.Next(16) == 0 && (double) j > Main.worldSurface)
                  {
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) 69;
                    WorldGen.SquareTileFrame(i, j);
                    break;
                  }
                  if (WorldGen.genRand.Next(60) == 0 && (double) j > Main.rockLayer)
                  {
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) type;
                    Main.tile[i, j].frameX = (short) 144;
                    break;
                  }
                  if (WorldGen.genRand.Next(1000) == 0 && (double) j > Main.rockLayer)
                  {
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) type;
                    Main.tile[i, j].frameX = (short) 162;
                    break;
                  }
                  if (WorldGen.genRand.Next(15) == 0)
                  {
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) type;
                    Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(2) * 18 + 108);
                    break;
                  }
                  Main.tile[i, j].active = true;
                  Main.tile[i, j].type = (byte) type;
                  Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(6) * 18);
                  break;
                }
                break;
              case 71:
                if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1].active && Main.tile[i, j + 1].type == (byte) 70)
                {
                  Main.tile[i, j].active = true;
                  Main.tile[i, j].type = (byte) type;
                  Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(5) * 18);
                  break;
                }
                break;
              case 129:
                if (WorldGen.SolidTile(i - 1, j) || WorldGen.SolidTile(i + 1, j) || WorldGen.SolidTile(i, j - 1) || WorldGen.SolidTile(i, j + 1))
                {
                  Main.tile[i, j].active = true;
                  Main.tile[i, j].type = (byte) type;
                  Main.tile[i, j].frameX = (short) (WorldGen.genRand.Next(8) * 18);
                  WorldGen.SquareTileFrame(i, j);
                  break;
                }
                break;
              default:
                if (type == 132 || type == 138 || type == 142 || type == 143)
                {
                  WorldGen.Place2x2(i, j, type);
                  break;
                }
                switch (type)
                {
                  case 4:
                    if (Main.tile[i - 1, j] == null)
                      Main.tile[i - 1, j] = new Tile();
                    if (Main.tile[i + 1, j] == null)
                      Main.tile[i + 1, j] = new Tile();
                    if (Main.tile[i, j + 1] == null)
                      Main.tile[i, j + 1] = new Tile();
                    if (Main.tile[i - 1, j].active && (Main.tileSolid[(int) Main.tile[i - 1, j].type] || Main.tile[i - 1, j].type == (byte) 124 || Main.tile[i - 1, j].type == (byte) 5 && Main.tile[i - 1, j - 1].type == (byte) 5 && Main.tile[i - 1, j + 1].type == (byte) 5) || Main.tile[i + 1, j].active && (Main.tileSolid[(int) Main.tile[i + 1, j].type] || Main.tile[i + 1, j].type == (byte) 124 || Main.tile[i + 1, j].type == (byte) 5 && Main.tile[i + 1, j - 1].type == (byte) 5 && Main.tile[i + 1, j + 1].type == (byte) 5) || Main.tile[i, j + 1].active && Main.tileSolid[(int) Main.tile[i, j + 1].type])
                    {
                      Main.tile[i, j].active = true;
                      Main.tile[i, j].type = (byte) type;
                      Main.tile[i, j].frameY = (short) (22 * style);
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    break;
                  case 10:
                    if (Main.tile[i, j - 1] == null)
                      Main.tile[i, j - 1] = new Tile();
                    if (Main.tile[i, j - 2] == null)
                      Main.tile[i, j - 2] = new Tile();
                    if (Main.tile[i, j - 3] == null)
                      Main.tile[i, j - 3] = new Tile();
                    if (Main.tile[i, j + 1] == null)
                      Main.tile[i, j + 1] = new Tile();
                    if (Main.tile[i, j + 2] == null)
                      Main.tile[i, j + 2] = new Tile();
                    if (Main.tile[i, j + 3] == null)
                      Main.tile[i, j + 3] = new Tile();
                    if (!Main.tile[i, j - 1].active && !Main.tile[i, j - 2].active && Main.tile[i, j - 3].active && Main.tileSolid[(int) Main.tile[i, j - 3].type])
                    {
                      WorldGen.PlaceDoor(i, j - 1, type);
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    if (Main.tile[i, j + 1].active || Main.tile[i, j + 2].active || !Main.tile[i, j + 3].active || !Main.tileSolid[(int) Main.tile[i, j + 3].type])
                      return false;
                    WorldGen.PlaceDoor(i, j + 1, type);
                    WorldGen.SquareTileFrame(i, j);
                    break;
                  case 128:
                    WorldGen.PlaceMan(i, j, style);
                    WorldGen.SquareTileFrame(i, j);
                    break;
                  case 136:
                    if (Main.tile[i - 1, j] == null)
                      Main.tile[i - 1, j] = new Tile();
                    if (Main.tile[i + 1, j] == null)
                      Main.tile[i + 1, j] = new Tile();
                    if (Main.tile[i, j + 1] == null)
                      Main.tile[i, j + 1] = new Tile();
                    if (Main.tile[i - 1, j].active && (Main.tileSolid[(int) Main.tile[i - 1, j].type] || Main.tile[i - 1, j].type == (byte) 124 || Main.tile[i - 1, j].type == (byte) 5 && Main.tile[i - 1, j - 1].type == (byte) 5 && Main.tile[i - 1, j + 1].type == (byte) 5) || Main.tile[i + 1, j].active && (Main.tileSolid[(int) Main.tile[i + 1, j].type] || Main.tile[i + 1, j].type == (byte) 124 || Main.tile[i + 1, j].type == (byte) 5 && Main.tile[i + 1, j - 1].type == (byte) 5 && Main.tile[i + 1, j + 1].type == (byte) 5) || Main.tile[i, j + 1].active && Main.tileSolid[(int) Main.tile[i, j + 1].type])
                    {
                      Main.tile[i, j].active = true;
                      Main.tile[i, j].type = (byte) type;
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    break;
                  case 137:
                    Main.tile[i, j].active = true;
                    Main.tile[i, j].type = (byte) type;
                    if (style == 1)
                    {
                      Main.tile[i, j].frameX = (short) 18;
                      break;
                    }
                    break;
                  case 139:
                    WorldGen.PlaceMB(i, j, type, style);
                    WorldGen.SquareTileFrame(i, j);
                    break;
                  case 149:
                    if (WorldGen.SolidTile(i - 1, j) || WorldGen.SolidTile(i + 1, j) || WorldGen.SolidTile(i, j - 1) || WorldGen.SolidTile(i, j + 1))
                    {
                      Main.tile[i, j].frameX = (short) (18 * style);
                      Main.tile[i, j].active = true;
                      Main.tile[i, j].type = (byte) type;
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    break;
                  default:
                    if (type == 34 || type == 35 || type == 36 || type == 106)
                    {
                      WorldGen.Place3x3(i, j, type);
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    if (type == 13 || type == 33 || type == 49 || type == 50 || type == 78)
                    {
                      WorldGen.PlaceOnTable1x1(i, j, type, style);
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    if (type == 14 || type == 26 || type == 86 || type == 87 || type == 88 || type == 89 || type == 114)
                    {
                      WorldGen.Place3x2(i, j, type);
                      WorldGen.SquareTileFrame(i, j);
                      break;
                    }
                    switch (type)
                    {
                      case 15:
                        if (Main.tile[i, j - 1] == null)
                          Main.tile[i, j - 1] = new Tile();
                        if (Main.tile[i, j] == null)
                          Main.tile[i, j] = new Tile();
                        WorldGen.Place1x2(i, j, type, style);
                        WorldGen.SquareTileFrame(i, j);
                        break;
                      case 20:
                        if (Main.tile[i, j + 1] == null)
                          Main.tile[i, j + 1] = new Tile();
                        if (Main.tile[i, j + 1].active && (Main.tile[i, j + 1].type == (byte) 2 || Main.tile[i, j + 1].type == (byte) 109 || Main.tile[i, j + 1].type == (byte) 147))
                        {
                          WorldGen.Place1x2(i, j, type, style);
                          WorldGen.SquareTileFrame(i, j);
                          break;
                        }
                        break;
                      default:
                        if (type == 16 || type == 18 || type == 29 || type == 103 || type == 134)
                        {
                          WorldGen.Place2x1(i, j, type);
                          WorldGen.SquareTileFrame(i, j);
                          break;
                        }
                        if (type == 92 || type == 93)
                        {
                          WorldGen.Place1xX(i, j, type);
                          WorldGen.SquareTileFrame(i, j);
                          break;
                        }
                        if (type == 104 || type == 105)
                        {
                          WorldGen.Place2xX(i, j, type, style);
                          WorldGen.SquareTileFrame(i, j);
                          break;
                        }
                        if (type == 17 || type == 77 || type == 133)
                        {
                          WorldGen.Place3x2(i, j, type);
                          WorldGen.SquareTileFrame(i, j);
                          break;
                        }
                        switch (type)
                        {
                          case 21:
                            WorldGen.PlaceChest(i, j, type, style: style);
                            WorldGen.SquareTileFrame(i, j);
                            break;
                          case 91:
                            WorldGen.PlaceBanner(i, j, type, style);
                            WorldGen.SquareTileFrame(i, j);
                            break;
                          default:
                            if (type == 135 || type == 141 || type == 144)
                            {
                              WorldGen.Place1x1(i, j, type, style);
                              WorldGen.SquareTileFrame(i, j);
                              break;
                            }
                            if (type == 101 || type == 102)
                            {
                              WorldGen.Place3x4(i, j, type);
                              WorldGen.SquareTileFrame(i, j);
                              break;
                            }
                            switch (type)
                            {
                              case 27:
                                WorldGen.PlaceSunflower(i, j);
                                WorldGen.SquareTileFrame(i, j);
                                break;
                              case 28:
                                WorldGen.PlacePot(i, j);
                                WorldGen.SquareTileFrame(i, j);
                                break;
                              case 42:
                                WorldGen.Place1x2Top(i, j, type);
                                WorldGen.SquareTileFrame(i, j);
                                break;
                              default:
                                if (type == 55 || type == 85)
                                {
                                  WorldGen.PlaceSign(i, j, type);
                                  break;
                                }
                                if (Main.tileAlch[type])
                                {
                                  WorldGen.PlaceAlch(i, j, style);
                                  break;
                                }
                                switch (type)
                                {
                                  case 79:
                                  case 90:
                                    int direction = 1;
                                    if (plr > -1)
                                      direction = Main.player[plr].direction;
                                    WorldGen.Place4x2(i, j, type, direction);
                                    break;
                                  case 81:
                                    Main.tile[i, j].frameX = (short) (26 * WorldGen.genRand.Next(6));
                                    Main.tile[i, j].active = true;
                                    Main.tile[i, j].type = (byte) type;
                                    break;
                                  case 94:
                                  case 95:
                                  case 96:
                                  case 97:
                                  case 98:
                                  case 99:
                                  case 100:
                                  case 125:
                                  case 126:
                                    WorldGen.Place2x2(i, j, type);
                                    break;
                                  default:
                                    Main.tile[i, j].active = true;
                                    Main.tile[i, j].type = (byte) type;
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                        break;
                    }
                    break;
                }
                break;
            }
          }
          if (Main.tile[i, j].active && !mute)
          {
            WorldGen.SquareTileFrame(i, j);
            flag = true;
            if (type == (int) sbyte.MaxValue)
              Main.PlaySound(2, i * 16, j * 16, 30);
            else
              Main.PlaySound(0, i * 16, j * 16);
            if (type == 22 || type == 140)
            {
              for (int index = 0; index < 3; ++index)
                Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, 14);
            }
          }
        }
      }
      return flag;
    }

    public static void UpdateMech()
    {
      for (int index1 = WorldGen.numMechs - 1; index1 >= 0; --index1)
      {
        --WorldGen.mechTime[index1];
        if (Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].active && Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].type == (byte) 144)
        {
          if (Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].frameY == (short) 0)
          {
            WorldGen.mechTime[index1] = 0;
          }
          else
          {
            int num = (int) Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].frameX / 18;
            switch (num)
            {
              case 0:
                num = 60;
                break;
              case 1:
                num = 180;
                break;
              case 2:
                num = 300;
                break;
            }
            if (Math.IEEERemainder((double) WorldGen.mechTime[index1], (double) num) == 0.0)
            {
              WorldGen.mechTime[index1] = 18000;
              WorldGen.TripWire(WorldGen.mechX[index1], WorldGen.mechY[index1]);
            }
          }
        }
        if (WorldGen.mechTime[index1] <= 0)
        {
          if (Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].active && Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].type == (byte) 144)
          {
            Main.tile[WorldGen.mechX[index1], WorldGen.mechY[index1]].frameY = (short) 0;
            NetMessage.SendTileSquare(-1, WorldGen.mechX[index1], WorldGen.mechY[index1], 1);
          }
          for (int index2 = index1; index2 < WorldGen.numMechs; ++index2)
          {
            WorldGen.mechX[index2] = WorldGen.mechX[index2 + 1];
            WorldGen.mechY[index2] = WorldGen.mechY[index2 + 1];
            WorldGen.mechTime[index2] = WorldGen.mechTime[index2 + 1];
          }
          --WorldGen.numMechs;
        }
      }
    }

    public static bool checkMech(int i, int j, int time)
    {
      for (int index = 0; index < WorldGen.numMechs; ++index)
      {
        if (WorldGen.mechX[index] == i && WorldGen.mechY[index] == j)
          return false;
      }
      if (WorldGen.numMechs >= WorldGen.maxMech - 1)
        return false;
      WorldGen.mechX[WorldGen.numMechs] = i;
      WorldGen.mechY[WorldGen.numMechs] = j;
      WorldGen.mechTime[WorldGen.numMechs] = time;
      ++WorldGen.numMechs;
      return true;
    }

    public static void hitSwitch(int i, int j)
    {
      if (Main.tile[i, j] == null)
        return;
      if (Main.tile[i, j].type == (byte) 135)
      {
        Main.PlaySound(28, i * 16, j * 16, 0);
        WorldGen.TripWire(i, j);
      }
      else if (Main.tile[i, j].type == (byte) 136)
      {
        Main.tile[i, j].frameY = Main.tile[i, j].frameY != (short) 0 ? (short) 0 : (short) 18;
        Main.PlaySound(28, i * 16, j * 16, 0);
        WorldGen.TripWire(i, j);
      }
      else if (Main.tile[i, j].type == (byte) 144)
      {
        if (Main.tile[i, j].frameY == (short) 0)
        {
          Main.tile[i, j].frameY = (short) 18;
          if (Main.netMode != 1)
            WorldGen.checkMech(i, j, 18000);
        }
        else
          Main.tile[i, j].frameY = (short) 0;
        Main.PlaySound(28, i * 16, j * 16, 0);
      }
      else
      {
        if (Main.tile[i, j].type != (byte) 132)
          return;
        short num1 = 36;
        int num2 = (int) Main.tile[i, j].frameX / 18 * -1;
        int num3 = (int) Main.tile[i, j].frameY / 18 * -1;
        if (num2 < -1)
        {
          num2 += 2;
          num1 = (short) -36;
        }
        int i1 = num2 + i;
        int j1 = num3 + j;
        for (int index1 = i1; index1 < i1 + 2; ++index1)
        {
          for (int index2 = j1; index2 < j1 + 2; ++index2)
          {
            if (Main.tile[index1, index2].type == (byte) 132)
              Main.tile[index1, index2].frameX += num1;
          }
        }
        WorldGen.TileFrame(i1, j1);
        Main.PlaySound(28, i * 16, j * 16, 0);
        for (int i2 = i1; i2 < i1 + 2; ++i2)
        {
          for (int j2 = j1; j2 < j1 + 2; ++j2)
          {
            if (Main.tile[i2, j2].type == (byte) 132 && Main.tile[i2, j2].active && Main.tile[i2, j2].wire)
            {
              WorldGen.TripWire(i2, j2);
              return;
            }
          }
        }
      }
    }

    public static void TripWire(int i, int j)
    {
      if (Main.netMode == 1)
        return;
      WorldGen.numWire = 0;
      WorldGen.numNoWire = 0;
      WorldGen.numInPump = 0;
      WorldGen.numOutPump = 0;
      WorldGen.noWire(i, j);
      WorldGen.hitWire(i, j);
      if (WorldGen.numInPump <= 0 || WorldGen.numOutPump <= 0)
        return;
      WorldGen.xferWater();
    }

    public static void xferWater()
    {
      for (int index1 = 0; index1 < WorldGen.numInPump; ++index1)
      {
        int i1 = WorldGen.inPumpX[index1];
        int j1 = WorldGen.inPumpY[index1];
        int liquid1 = (int) Main.tile[i1, j1].liquid;
        if (liquid1 > 0)
        {
          bool lava = Main.tile[i1, j1].lava;
          for (int index2 = 0; index2 < WorldGen.numOutPump; ++index2)
          {
            int i2 = WorldGen.outPumpX[index2];
            int j2 = WorldGen.outPumpY[index2];
            int liquid2 = (int) Main.tile[i2, j2].liquid;
            if (liquid2 < (int) byte.MaxValue)
            {
              bool flag = Main.tile[i2, j2].lava;
              if (liquid2 == 0)
                flag = lava;
              if (lava == flag)
              {
                int num = liquid1;
                if (num + liquid2 > (int) byte.MaxValue)
                  num = (int) byte.MaxValue - liquid2;
                Main.tile[i2, j2].liquid += (byte) num;
                Main.tile[i1, j1].liquid -= (byte) num;
                liquid1 = (int) Main.tile[i1, j1].liquid;
                Main.tile[i2, j2].lava = lava;
                WorldGen.SquareTileFrame(i2, j2);
                if (Main.tile[i1, j1].liquid == (byte) 0)
                {
                  Main.tile[i1, j1].lava = false;
                  WorldGen.SquareTileFrame(i1, j1);
                  break;
                }
              }
            }
          }
          WorldGen.SquareTileFrame(i1, j1);
        }
      }
    }

    public static void noWire(int i, int j)
    {
      if (WorldGen.numNoWire >= WorldGen.maxWire - 1)
        return;
      WorldGen.noWireX[WorldGen.numNoWire] = i;
      WorldGen.noWireY[WorldGen.numNoWire] = j;
      ++WorldGen.numNoWire;
    }

    public static void hitWire(int i, int j)
    {
      if (WorldGen.numWire >= WorldGen.maxWire - 1 || !Main.tile[i, j].wire)
        return;
      for (int index = 0; index < WorldGen.numWire; ++index)
      {
        if (WorldGen.wireX[index] == i && WorldGen.wireY[index] == j)
          return;
      }
      WorldGen.wireX[WorldGen.numWire] = i;
      WorldGen.wireY[WorldGen.numWire] = j;
      ++WorldGen.numWire;
      int type = (int) Main.tile[i, j].type;
      bool flag = true;
      for (int index = 0; index < WorldGen.numNoWire; ++index)
      {
        if (WorldGen.noWireX[index] == i && WorldGen.noWireY[index] == j)
          flag = false;
      }
      if (flag && Main.tile[i, j].active)
      {
        switch (type)
        {
          case 4:
            if (Main.tile[i, j].frameX < (short) 66)
              Main.tile[i, j].frameX += (short) 66;
            else
              Main.tile[i, j].frameX -= (short) 66;
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          case 10:
            int direction = 1;
            if (Main.rand.Next(2) == 0)
              direction = -1;
            if (!WorldGen.OpenDoor(i, j, direction))
            {
              if (WorldGen.OpenDoor(i, j, -direction))
              {
                NetMessage.SendData(19, number2: ((float) i), number3: ((float) j), number4: ((float) -direction));
                break;
              }
              break;
            }
            NetMessage.SendData(19, number2: ((float) i), number3: ((float) j), number4: ((float) direction));
            break;
          case 11:
            if (WorldGen.CloseDoor(i, j, true))
            {
              NetMessage.SendData(19, number: 1, number2: ((float) i), number3: ((float) j));
              break;
            }
            break;
          case 33:
            short num1 = 18;
            if (Main.tile[i, j].frameX > (short) 0)
              num1 = (short) -18;
            Main.tile[i, j].frameX += num1;
            NetMessage.SendTileSquare(-1, i, j, 3);
            break;
          case 34:
          case 35:
          case 36:
            int index1 = j - (int) Main.tile[i, j].frameY / 18;
            int num2 = (int) Main.tile[i, j].frameX / 18;
            if (num2 > 2)
              num2 -= 3;
            int index2 = i - num2;
            short num3 = 54;
            if (Main.tile[index2, index1].frameX > (short) 0)
              num3 = (short) -54;
            for (int i1 = index2; i1 < index2 + 3; ++i1)
            {
              for (int j1 = index1; j1 < index1 + 3; ++j1)
              {
                Main.tile[i1, j1].frameX += num3;
                WorldGen.noWire(i1, j1);
              }
            }
            NetMessage.SendTileSquare(-1, index2 + 1, index1 + 1, 3);
            break;
          case 42:
            int j2 = j - (int) Main.tile[i, j].frameY / 18;
            short num4 = 18;
            if (Main.tile[i, j].frameX > (short) 0)
              num4 = (short) -18;
            Main.tile[i, j2].frameX += num4;
            Main.tile[i, j2 + 1].frameX += num4;
            WorldGen.noWire(i, j2);
            WorldGen.noWire(i, j2 + 1);
            NetMessage.SendTileSquare(-1, i, j, 2);
            break;
          case 92:
            int j3 = j - (int) Main.tile[i, j].frameY / 18;
            short num5 = 18;
            if (Main.tile[i, j].frameX > (short) 0)
              num5 = (short) -18;
            Main.tile[i, j3].frameX += num5;
            Main.tile[i, j3 + 1].frameX += num5;
            Main.tile[i, j3 + 2].frameX += num5;
            Main.tile[i, j3 + 3].frameX += num5;
            Main.tile[i, j3 + 4].frameX += num5;
            Main.tile[i, j3 + 5].frameX += num5;
            WorldGen.noWire(i, j3);
            WorldGen.noWire(i, j3 + 1);
            WorldGen.noWire(i, j3 + 2);
            WorldGen.noWire(i, j3 + 3);
            WorldGen.noWire(i, j3 + 4);
            WorldGen.noWire(i, j3 + 5);
            NetMessage.SendTileSquare(-1, i, j3 + 3, 7);
            break;
          case 93:
            int j4 = j - (int) Main.tile[i, j].frameY / 18;
            short num6 = 18;
            if (Main.tile[i, j].frameX > (short) 0)
              num6 = (short) -18;
            Main.tile[i, j4].frameX += num6;
            Main.tile[i, j4 + 1].frameX += num6;
            Main.tile[i, j4 + 2].frameX += num6;
            WorldGen.noWire(i, j4);
            WorldGen.noWire(i, j4 + 1);
            WorldGen.noWire(i, j4 + 2);
            NetMessage.SendTileSquare(-1, i, j4 + 1, 3);
            break;
          case 95:
          case 100:
          case 126:
            int index3 = j - (int) Main.tile[i, j].frameY / 18;
            int num7 = (int) Main.tile[i, j].frameX / 18;
            if (num7 > 1)
              num7 -= 2;
            int index4 = i - num7;
            short num8 = 36;
            if (Main.tile[index4, index3].frameX > (short) 0)
              num8 = (short) -36;
            Main.tile[index4, index3].frameX += num8;
            Main.tile[index4, index3 + 1].frameX += num8;
            Main.tile[index4 + 1, index3].frameX += num8;
            Main.tile[index4 + 1, index3 + 1].frameX += num8;
            WorldGen.noWire(index4, index3);
            WorldGen.noWire(index4, index3 + 1);
            WorldGen.noWire(index4 + 1, index3);
            WorldGen.noWire(index4 + 1, index3 + 1);
            NetMessage.SendTileSquare(-1, index4, index3, 3);
            break;
          case 105:
            int j5 = j - (int) Main.tile[i, j].frameY / 18;
            int num9 = (int) Main.tile[i, j].frameX / 18;
            int num10 = 0;
            while (num9 >= 2)
            {
              num9 -= 2;
              ++num10;
            }
            int i2 = i - num9;
            WorldGen.noWire(i2, j5);
            WorldGen.noWire(i2, j5 + 1);
            WorldGen.noWire(i2, j5 + 2);
            WorldGen.noWire(i2 + 1, j5);
            WorldGen.noWire(i2 + 1, j5 + 1);
            WorldGen.noWire(i2 + 1, j5 + 2);
            int X = i2 * 16 + 16;
            int Y = (j5 + 3) * 16;
            int index5 = -1;
            switch (num10)
            {
              case 2:
                if (WorldGen.checkMech(i, j, 600) && Item.MechSpawn((float) X, (float) Y, 184))
                {
                  Item.NewItem(X, Y - 16, 0, 0, 184);
                  break;
                }
                break;
              case 4:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 1))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 1);
                  break;
                }
                break;
              case 7:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 49))
                {
                  index5 = NPC.NewNPC(X - 4, Y - 6, 49);
                  break;
                }
                break;
              case 8:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 55))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 55);
                  break;
                }
                break;
              case 9:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 46))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 46);
                  break;
                }
                break;
              case 10:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 21))
                {
                  index5 = NPC.NewNPC(X, Y, 21);
                  break;
                }
                break;
              case 17:
                if (WorldGen.checkMech(i, j, 600) && Item.MechSpawn((float) X, (float) Y, 166))
                {
                  Item.NewItem(X, Y - 20, 0, 0, 166);
                  break;
                }
                break;
              case 18:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 67))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 67);
                  break;
                }
                break;
              case 23:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 63))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 63);
                  break;
                }
                break;
              case 27:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 85))
                {
                  index5 = NPC.NewNPC(X - 9, Y, 85);
                  break;
                }
                break;
              case 28:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 74))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 74);
                  break;
                }
                break;
              case 37:
                if (WorldGen.checkMech(i, j, 600) && Item.MechSpawn((float) X, (float) Y, 58))
                {
                  Item.NewItem(X, Y - 16, 0, 0, 58);
                  break;
                }
                break;
              case 40:
                if (WorldGen.checkMech(i, j, 300))
                {
                  int[] numArray = new int[10];
                  int maxValue = 0;
                  for (int index6 = 0; index6 < 200; ++index6)
                  {
                    if (Main.npc[index6].active && (Main.npc[index6].type == 17 || Main.npc[index6].type == 19 || Main.npc[index6].type == 22 || Main.npc[index6].type == 38 || Main.npc[index6].type == 54 || Main.npc[index6].type == 107 || Main.npc[index6].type == 108))
                    {
                      numArray[maxValue] = index6;
                      ++maxValue;
                      if (maxValue >= 9)
                        break;
                    }
                  }
                  if (maxValue > 0)
                  {
                    int number = numArray[Main.rand.Next(maxValue)];
                    Main.npc[number].position.X = (float) (X - Main.npc[number].width / 2);
                    Main.npc[number].position.Y = (float) (Y - Main.npc[number].height - 1);
                    NetMessage.SendData(23, number: number);
                    break;
                  }
                  break;
                }
                break;
              case 41:
                if (WorldGen.checkMech(i, j, 300))
                {
                  int[] numArray = new int[10];
                  int maxValue = 0;
                  for (int index7 = 0; index7 < 200; ++index7)
                  {
                    if (Main.npc[index7].active && (Main.npc[index7].type == 18 || Main.npc[index7].type == 20 || Main.npc[index7].type == 124))
                    {
                      numArray[maxValue] = index7;
                      ++maxValue;
                      if (maxValue >= 9)
                        break;
                    }
                  }
                  if (maxValue > 0)
                  {
                    int number = numArray[Main.rand.Next(maxValue)];
                    Main.npc[number].position.X = (float) (X - Main.npc[number].width / 2);
                    Main.npc[number].position.Y = (float) (Y - Main.npc[number].height - 1);
                    NetMessage.SendData(23, number: number);
                    break;
                  }
                  break;
                }
                break;
              case 42:
                if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn((float) X, (float) Y, 58))
                {
                  index5 = NPC.NewNPC(X, Y - 12, 58);
                  break;
                }
                break;
            }
            if (index5 >= 0)
            {
              Main.npc[index5].value = 0.0f;
              Main.npc[index5].npcSlots = 0.0f;
              break;
            }
            break;
          case 130:
            Main.tile[i, j].type = (byte) 131;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          case 131:
            Main.tile[i, j].type = (byte) 130;
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          case 137:
            if (WorldGen.checkMech(i, j, 180))
            {
              int num11 = -1;
              if (Main.tile[i, j].frameX != (short) 0)
                num11 = 1;
              float SpeedX = (float) (12 * num11);
              int Damage = 20;
              int Type = 98;
              Vector2 vector2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 7));
              vector2.X += (float) (10 * num11);
              vector2.Y += 2f;
              Projectile.NewProjectile((float) (int) vector2.X, (float) (int) vector2.Y, SpeedX, 0.0f, Type, Damage, 2f, Main.myPlayer);
              break;
            }
            break;
          case 139:
            WorldGen.SwitchMB(i, j);
            break;
          case 141:
            WorldGen.KillTile(i, j, noItem: true);
            NetMessage.SendTileSquare(-1, i, j, 1);
            Projectile.NewProjectile((float) (i * 16 + 8), (float) (j * 16 + 8), 0.0f, 0.0f, 108, 250, 10f, Main.myPlayer);
            break;
          case 142:
          case 143:
            int j6 = j - (int) Main.tile[i, j].frameY / 18;
            int num12 = (int) Main.tile[i, j].frameX / 18;
            if (num12 > 1)
              num12 -= 2;
            int i3 = i - num12;
            WorldGen.noWire(i3, j6);
            WorldGen.noWire(i3, j6 + 1);
            WorldGen.noWire(i3 + 1, j6);
            WorldGen.noWire(i3 + 1, j6 + 1);
            if (type == 142)
            {
              for (int index8 = 0; index8 < 4 && WorldGen.numInPump < WorldGen.maxPump - 1; ++index8)
              {
                int num13;
                int num14;
                switch (index8)
                {
                  case 0:
                    num13 = i3;
                    num14 = j6 + 1;
                    break;
                  case 1:
                    num13 = i3 + 1;
                    num14 = j6 + 1;
                    break;
                  case 2:
                    num13 = i3;
                    num14 = j6;
                    break;
                  default:
                    num13 = i3 + 1;
                    num14 = j6;
                    break;
                }
                WorldGen.inPumpX[WorldGen.numInPump] = num13;
                WorldGen.inPumpY[WorldGen.numInPump] = num14;
                ++WorldGen.numInPump;
              }
              break;
            }
            for (int index9 = 0; index9 < 4 && WorldGen.numOutPump < WorldGen.maxPump - 1; ++index9)
            {
              int num15;
              int num16;
              switch (index9)
              {
                case 0:
                  num15 = i3;
                  num16 = j6 + 1;
                  break;
                case 1:
                  num15 = i3 + 1;
                  num16 = j6 + 1;
                  break;
                case 2:
                  num15 = i3;
                  num16 = j6;
                  break;
                default:
                  num15 = i3 + 1;
                  num16 = j6;
                  break;
              }
              WorldGen.outPumpX[WorldGen.numOutPump] = num15;
              WorldGen.outPumpY[WorldGen.numOutPump] = num16;
              ++WorldGen.numOutPump;
            }
            break;
          case 144:
            WorldGen.hitSwitch(i, j);
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
          case 149:
            if (Main.tile[i, j].frameX < (short) 54)
              Main.tile[i, j].frameX += (short) 54;
            else
              Main.tile[i, j].frameX -= (short) 54;
            NetMessage.SendTileSquare(-1, i, j, 1);
            break;
        }
      }
      WorldGen.hitWire(i - 1, j);
      WorldGen.hitWire(i + 1, j);
      WorldGen.hitWire(i, j - 1);
      WorldGen.hitWire(i, j + 1);
    }

    public static void KillWall(int i, int j, bool fail = false)
    {
      if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY)
        return;
      if (Main.tile[i, j] == null)
        Main.tile[i, j] = new Tile();
      if (Main.tile[i, j].wall <= (byte) 0)
        return;
      if (Main.tile[i, j].wall == (byte) 21)
        Main.PlaySound(13, i * 16, j * 16);
      else
        Main.PlaySound(0, i * 16, j * 16);
      int num = 10;
      if (fail)
        num = 3;
      for (int index = 0; index < num; ++index)
      {
        int Type = 0;
        if (Main.tile[i, j].wall == (byte) 1 || Main.tile[i, j].wall == (byte) 5 || Main.tile[i, j].wall == (byte) 6 || Main.tile[i, j].wall == (byte) 7 || Main.tile[i, j].wall == (byte) 8 || Main.tile[i, j].wall == (byte) 9)
          Type = 1;
        if (Main.tile[i, j].wall == (byte) 3)
          Type = WorldGen.genRand.Next(2) != 0 ? 1 : 14;
        if (Main.tile[i, j].wall == (byte) 4)
          Type = 7;
        if (Main.tile[i, j].wall == (byte) 12)
          Type = 9;
        if (Main.tile[i, j].wall == (byte) 10)
          Type = 10;
        if (Main.tile[i, j].wall == (byte) 11)
          Type = 11;
        if (Main.tile[i, j].wall == (byte) 21)
          Type = 13;
        if (Main.tile[i, j].wall == (byte) 22 || Main.tile[i, j].wall == (byte) 28)
          Type = 51;
        if (Main.tile[i, j].wall == (byte) 23)
          Type = 38;
        if (Main.tile[i, j].wall == (byte) 24)
          Type = 36;
        if (Main.tile[i, j].wall == (byte) 25)
          Type = 48;
        if (Main.tile[i, j].wall == (byte) 26 || Main.tile[i, j].wall == (byte) 30)
          Type = 49;
        if (Main.tile[i, j].wall == (byte) 29)
          Type = 50;
        if (Main.tile[i, j].wall == (byte) 31)
          Type = 51;
        if (Main.tile[i, j].wall == (byte) 27)
          Type = WorldGen.genRand.Next(2) != 0 ? 1 : 7;
        Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, Type);
      }
      if (fail)
      {
        WorldGen.SquareWallFrame(i, j);
      }
      else
      {
        int Type = 0;
        if (Main.tile[i, j].wall == (byte) 1)
          Type = 26;
        if (Main.tile[i, j].wall == (byte) 4)
          Type = 93;
        if (Main.tile[i, j].wall == (byte) 5)
          Type = 130;
        if (Main.tile[i, j].wall == (byte) 6)
          Type = 132;
        if (Main.tile[i, j].wall == (byte) 7)
          Type = 135;
        if (Main.tile[i, j].wall == (byte) 8)
          Type = 138;
        if (Main.tile[i, j].wall == (byte) 9)
          Type = 140;
        if (Main.tile[i, j].wall == (byte) 10)
          Type = 142;
        if (Main.tile[i, j].wall == (byte) 11)
          Type = 144;
        if (Main.tile[i, j].wall == (byte) 12)
          Type = 146;
        if (Main.tile[i, j].wall == (byte) 14)
          Type = 330;
        if (Main.tile[i, j].wall == (byte) 16)
          Type = 30;
        if (Main.tile[i, j].wall == (byte) 17)
          Type = 135;
        if (Main.tile[i, j].wall == (byte) 18)
          Type = 138;
        if (Main.tile[i, j].wall == (byte) 19)
          Type = 140;
        if (Main.tile[i, j].wall == (byte) 20)
          Type = 330;
        if (Main.tile[i, j].wall == (byte) 21)
          Type = 392;
        if (Main.tile[i, j].wall == (byte) 22)
          Type = 417;
        if (Main.tile[i, j].wall == (byte) 23)
          Type = 418;
        if (Main.tile[i, j].wall == (byte) 24)
          Type = 419;
        if (Main.tile[i, j].wall == (byte) 25)
          Type = 420;
        if (Main.tile[i, j].wall == (byte) 26)
          Type = 421;
        if (Main.tile[i, j].wall == (byte) 29)
          Type = 587;
        if (Main.tile[i, j].wall == (byte) 30)
          Type = 592;
        if (Main.tile[i, j].wall == (byte) 31)
          Type = 595;
        if (Main.tile[i, j].wall == (byte) 27)
          Type = 479;
        if (Type > 0)
          Item.NewItem(i * 16, j * 16, 16, 16, Type);
        Main.tile[i, j].wall = (byte) 0;
        WorldGen.SquareWallFrame(i, j);
      }
    }

    public static void KillTile(int i, int j, bool fail = false, bool effectOnly = false, bool noItem = false)
    {
      if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY)
        return;
      if (Main.tile[i, j] == null)
        Main.tile[i, j] = new Tile();
      if (!Main.tile[i, j].active)
        return;
      if (j >= 1 && Main.tile[i, j - 1] == null)
        Main.tile[i, j - 1] = new Tile();
      if (j >= 1 && Main.tile[i, j - 1].active && (Main.tile[i, j - 1].type == (byte) 5 && Main.tile[i, j].type != (byte) 5 || Main.tile[i, j - 1].type == (byte) 21 && Main.tile[i, j].type != (byte) 21 || Main.tile[i, j - 1].type == (byte) 26 && Main.tile[i, j].type != (byte) 26 || Main.tile[i, j - 1].type == (byte) 72 && Main.tile[i, j].type != (byte) 72 || Main.tile[i, j - 1].type == (byte) 12 && Main.tile[i, j].type != (byte) 12) && (Main.tile[i, j - 1].type != (byte) 5 || (Main.tile[i, j - 1].frameX != (short) 66 || Main.tile[i, j - 1].frameY < (short) 0 || Main.tile[i, j - 1].frameY > (short) 44) && (Main.tile[i, j - 1].frameX != (short) 88 || Main.tile[i, j - 1].frameY < (short) 66 || Main.tile[i, j - 1].frameY > (short) 110) && Main.tile[i, j - 1].frameY < (short) 198))
        return;
      if (!effectOnly && !WorldGen.stopDrops)
      {
        if (Main.tile[i, j].type == (byte) 127)
          Main.PlaySound(2, i * 16, j * 16, 27);
        else if (Main.tile[i, j].type == (byte) 3 || Main.tile[i, j].type == (byte) 110)
        {
          Main.PlaySound(6, i * 16, j * 16);
          if (Main.tile[i, j].frameX == (short) 144)
            Item.NewItem(i * 16, j * 16, 16, 16, 5);
        }
        else if (Main.tile[i, j].type == (byte) 24)
        {
          Main.PlaySound(6, i * 16, j * 16);
          if (Main.tile[i, j].frameX == (short) 144)
            Item.NewItem(i * 16, j * 16, 16, 16, 60);
        }
        else if (Main.tileAlch[(int) Main.tile[i, j].type] || Main.tile[i, j].type == (byte) 32 || Main.tile[i, j].type == (byte) 51 || Main.tile[i, j].type == (byte) 52 || Main.tile[i, j].type == (byte) 61 || Main.tile[i, j].type == (byte) 62 || Main.tile[i, j].type == (byte) 69 || Main.tile[i, j].type == (byte) 71 || Main.tile[i, j].type == (byte) 73 || Main.tile[i, j].type == (byte) 74 || Main.tile[i, j].type == (byte) 113 || Main.tile[i, j].type == (byte) 115)
          Main.PlaySound(6, i * 16, j * 16);
        else if (Main.tile[i, j].type == (byte) 1 || Main.tile[i, j].type == (byte) 6 || Main.tile[i, j].type == (byte) 7 || Main.tile[i, j].type == (byte) 8 || Main.tile[i, j].type == (byte) 9 || Main.tile[i, j].type == (byte) 22 || Main.tile[i, j].type == (byte) 140 || Main.tile[i, j].type == (byte) 25 || Main.tile[i, j].type == (byte) 37 || Main.tile[i, j].type == (byte) 38 || Main.tile[i, j].type == (byte) 39 || Main.tile[i, j].type == (byte) 41 || Main.tile[i, j].type == (byte) 43 || Main.tile[i, j].type == (byte) 44 || Main.tile[i, j].type == (byte) 45 || Main.tile[i, j].type == (byte) 46 || Main.tile[i, j].type == (byte) 47 || Main.tile[i, j].type == (byte) 48 || Main.tile[i, j].type == (byte) 56 || Main.tile[i, j].type == (byte) 58 || Main.tile[i, j].type == (byte) 63 || Main.tile[i, j].type == (byte) 64 || Main.tile[i, j].type == (byte) 65 || Main.tile[i, j].type == (byte) 66 || Main.tile[i, j].type == (byte) 67 || Main.tile[i, j].type == (byte) 68 || Main.tile[i, j].type == (byte) 75 || Main.tile[i, j].type == (byte) 76 || Main.tile[i, j].type == (byte) 107 || Main.tile[i, j].type == (byte) 108 || Main.tile[i, j].type == (byte) 111 || Main.tile[i, j].type == (byte) 117 || Main.tile[i, j].type == (byte) 118 || Main.tile[i, j].type == (byte) 119 || Main.tile[i, j].type == (byte) 120 || Main.tile[i, j].type == (byte) 121 || Main.tile[i, j].type == (byte) 122)
          Main.PlaySound(21, i * 16, j * 16);
        else if (Main.tile[i, j].type != (byte) 138)
          Main.PlaySound(0, i * 16, j * 16);
        if (Main.tile[i, j].type == (byte) 129 && !fail)
          Main.PlaySound(2, i * 16, j * 16, 27);
      }
      int num1 = 10;
      if (Main.tile[i, j].type == (byte) 128)
      {
        int index1 = i;
        int frameX1 = (int) Main.tile[i, j].frameX;
        int frameX2 = (int) Main.tile[i, j].frameX;
        while (frameX2 >= 100)
          frameX2 -= 100;
        while (frameX2 >= 36)
          frameX2 -= 36;
        if (frameX2 == 18)
        {
          frameX1 = (int) Main.tile[i - 1, j].frameX;
          --index1;
        }
        if (frameX1 >= 100)
        {
          int index2 = 0;
          while (frameX1 >= 100)
          {
            frameX1 -= 100;
            ++index2;
          }
          int num2 = (int) Main.tile[index1, j].frameY / 18;
          if (num2 == 0)
            Item.NewItem(i * 16, j * 16, 16, 16, Item.headType[index2]);
          if (num2 == 1)
            Item.NewItem(i * 16, j * 16, 16, 16, Item.bodyType[index2]);
          if (num2 == 2)
            Item.NewItem(i * 16, j * 16, 16, 16, Item.legType[index2]);
          int frameX3 = (int) Main.tile[index1, j].frameX;
          while (frameX3 >= 100)
            frameX3 -= 100;
          Main.tile[index1, j].frameX = (short) frameX3;
        }
      }
      if (fail)
        num1 = 3;
      if (Main.tile[i, j].type == (byte) 138)
        num1 = 0;
      for (int index = 0; index < num1; ++index)
      {
        int Type = 0;
        if (Main.tile[i, j].type == (byte) 0)
          Type = 0;
        if (Main.tile[i, j].type == (byte) 1 || Main.tile[i, j].type == (byte) 16 || Main.tile[i, j].type == (byte) 17 || Main.tile[i, j].type == (byte) 38 || Main.tile[i, j].type == (byte) 39 || Main.tile[i, j].type == (byte) 41 || Main.tile[i, j].type == (byte) 43 || Main.tile[i, j].type == (byte) 44 || Main.tile[i, j].type == (byte) 48 || Main.tileStone[(int) Main.tile[i, j].type] || Main.tile[i, j].type == (byte) 85 || Main.tile[i, j].type == (byte) 90 || Main.tile[i, j].type == (byte) 92 || Main.tile[i, j].type == (byte) 96 || Main.tile[i, j].type == (byte) 97 || Main.tile[i, j].type == (byte) 99 || Main.tile[i, j].type == (byte) 105 || Main.tile[i, j].type == (byte) 117 || Main.tile[i, j].type == (byte) 130 || Main.tile[i, j].type == (byte) 131 || Main.tile[i, j].type == (byte) 132 || Main.tile[i, j].type == (byte) 135 || Main.tile[i, j].type == (byte) 135 || Main.tile[i, j].type == (byte) 137 || Main.tile[i, j].type == (byte) 142 || Main.tile[i, j].type == (byte) 143 || Main.tile[i, j].type == (byte) 144)
          Type = 1;
        if (Main.tile[i, j].type == (byte) 33 || Main.tile[i, j].type == (byte) 95 || Main.tile[i, j].type == (byte) 98 || Main.tile[i, j].type == (byte) 100)
          Type = 6;
        if (Main.tile[i, j].type == (byte) 5 || Main.tile[i, j].type == (byte) 10 || Main.tile[i, j].type == (byte) 11 || Main.tile[i, j].type == (byte) 14 || Main.tile[i, j].type == (byte) 15 || Main.tile[i, j].type == (byte) 19 || Main.tile[i, j].type == (byte) 30 || Main.tile[i, j].type == (byte) 86 || Main.tile[i, j].type == (byte) 87 || Main.tile[i, j].type == (byte) 88 || Main.tile[i, j].type == (byte) 89 || Main.tile[i, j].type == (byte) 93 || Main.tile[i, j].type == (byte) 94 || Main.tile[i, j].type == (byte) 104 || Main.tile[i, j].type == (byte) 106 || Main.tile[i, j].type == (byte) 114 || Main.tile[i, j].type == (byte) 124 || Main.tile[i, j].type == (byte) 128 || Main.tile[i, j].type == (byte) 139)
          Type = 7;
        if (Main.tile[i, j].type == (byte) 21)
          Type = Main.tile[i, j].frameX < (short) 108 ? (Main.tile[i, j].frameX < (short) 36 ? 7 : 10) : 37;
        if (Main.tile[i, j].type == (byte) 2)
          Type = WorldGen.genRand.Next(2) != 0 ? 2 : 0;
        if (Main.tile[i, j].type == (byte) 127)
          Type = 67;
        if (Main.tile[i, j].type == (byte) 91)
          Type = -1;
        if (Main.tile[i, j].type == (byte) 6 || Main.tile[i, j].type == (byte) 26)
          Type = 8;
        if (Main.tile[i, j].type == (byte) 7 || Main.tile[i, j].type == (byte) 34 || Main.tile[i, j].type == (byte) 47)
          Type = 9;
        if (Main.tile[i, j].type == (byte) 8 || Main.tile[i, j].type == (byte) 36 || Main.tile[i, j].type == (byte) 45 || Main.tile[i, j].type == (byte) 102)
          Type = 10;
        if (Main.tile[i, j].type == (byte) 9 || Main.tile[i, j].type == (byte) 35 || Main.tile[i, j].type == (byte) 42 || Main.tile[i, j].type == (byte) 46 || Main.tile[i, j].type == (byte) 126 || Main.tile[i, j].type == (byte) 136)
          Type = 11;
        if (Main.tile[i, j].type == (byte) 12)
          Type = 12;
        if (Main.tile[i, j].type == (byte) 3 || Main.tile[i, j].type == (byte) 73)
          Type = 3;
        if (Main.tile[i, j].type == (byte) 13 || Main.tile[i, j].type == (byte) 54)
          Type = 13;
        if (Main.tile[i, j].type == (byte) 22 || Main.tile[i, j].type == (byte) 140)
          Type = 14;
        if (Main.tile[i, j].type == (byte) 28 || Main.tile[i, j].type == (byte) 78)
          Type = 22;
        if (Main.tile[i, j].type == (byte) 29)
          Type = 23;
        if (Main.tile[i, j].type == (byte) 40 || Main.tile[i, j].type == (byte) 103)
          Type = 28;
        if (Main.tile[i, j].type == (byte) 49)
          Type = 29;
        if (Main.tile[i, j].type == (byte) 50)
          Type = 22;
        if (Main.tile[i, j].type == (byte) 51)
          Type = 30;
        if (Main.tile[i, j].type == (byte) 52)
          Type = 3;
        if (Main.tile[i, j].type == (byte) 53 || Main.tile[i, j].type == (byte) 81)
          Type = 32;
        if (Main.tile[i, j].type == (byte) 56 || Main.tile[i, j].type == (byte) 75)
          Type = 37;
        if (Main.tile[i, j].type == (byte) 57 || Main.tile[i, j].type == (byte) 119 || Main.tile[i, j].type == (byte) 141)
          Type = 36;
        if (Main.tile[i, j].type == (byte) 59 || Main.tile[i, j].type == (byte) 120)
          Type = 38;
        if (Main.tile[i, j].type == (byte) 61 || Main.tile[i, j].type == (byte) 62 || Main.tile[i, j].type == (byte) 74 || Main.tile[i, j].type == (byte) 80)
          Type = 40;
        if (Main.tile[i, j].type == (byte) 69)
          Type = 7;
        if (Main.tile[i, j].type == (byte) 71 || Main.tile[i, j].type == (byte) 72)
          Type = 26;
        if (Main.tile[i, j].type == (byte) 70)
          Type = 17;
        if (Main.tile[i, j].type == (byte) 112)
          Type = 14;
        if (Main.tile[i, j].type == (byte) 123)
          Type = 53;
        if (Main.tile[i, j].type == (byte) 116 || Main.tile[i, j].type == (byte) 118 || Main.tile[i, j].type == (byte) 147 || Main.tile[i, j].type == (byte) 148)
          Type = 51;
        if (Main.tile[i, j].type == (byte) 109)
          Type = WorldGen.genRand.Next(2) != 0 ? 47 : 0;
        if (Main.tile[i, j].type == (byte) 110 || Main.tile[i, j].type == (byte) 113 || Main.tile[i, j].type == (byte) 115)
          Type = 47;
        if (Main.tile[i, j].type == (byte) 107 || Main.tile[i, j].type == (byte) 121)
          Type = 48;
        if (Main.tile[i, j].type == (byte) 108 || Main.tile[i, j].type == (byte) 122 || Main.tile[i, j].type == (byte) 134 || Main.tile[i, j].type == (byte) 146)
          Type = 49;
        if (Main.tile[i, j].type == (byte) 111 || Main.tile[i, j].type == (byte) 133 || Main.tile[i, j].type == (byte) 145)
          Type = 50;
        if (Main.tile[i, j].type == (byte) 149)
          Type = 49;
        if (Main.tileAlch[(int) Main.tile[i, j].type])
        {
          int num3 = (int) Main.tile[i, j].frameX / 18;
          if (num3 == 0)
            Type = 3;
          if (num3 == 1)
            Type = 3;
          if (num3 == 2)
            Type = 7;
          if (num3 == 3)
            Type = 17;
          if (num3 == 4)
            Type = 3;
          if (num3 == 5)
            Type = 6;
        }
        if (Main.tile[i, j].type == (byte) 61)
          Type = WorldGen.genRand.Next(2) != 0 ? 39 : 38;
        if (Main.tile[i, j].type == (byte) 58 || Main.tile[i, j].type == (byte) 76 || Main.tile[i, j].type == (byte) 77)
          Type = WorldGen.genRand.Next(2) != 0 ? 25 : 6;
        if (Main.tile[i, j].type == (byte) 37)
          Type = WorldGen.genRand.Next(2) != 0 ? 23 : 6;
        if (Main.tile[i, j].type == (byte) 32)
          Type = WorldGen.genRand.Next(2) != 0 ? 24 : 14;
        if (Main.tile[i, j].type == (byte) 23 || Main.tile[i, j].type == (byte) 24)
          Type = WorldGen.genRand.Next(2) != 0 ? 17 : 14;
        if (Main.tile[i, j].type == (byte) 25 || Main.tile[i, j].type == (byte) 31)
          Type = WorldGen.genRand.Next(2) != 0 ? 1 : 14;
        if (Main.tile[i, j].type == (byte) 20)
          Type = WorldGen.genRand.Next(2) != 0 ? 2 : 7;
        if (Main.tile[i, j].type == (byte) 27)
          Type = WorldGen.genRand.Next(2) != 0 ? 19 : 3;
        if (Main.tile[i, j].type == (byte) 129)
          Type = Main.tile[i, j].frameX == (short) 0 || Main.tile[i, j].frameX == (short) 54 || Main.tile[i, j].frameX == (short) 108 ? 68 : (Main.tile[i, j].frameX == (short) 18 || Main.tile[i, j].frameX == (short) 72 || Main.tile[i, j].frameX == (short) 126 ? 69 : 70);
        if (Main.tile[i, j].type == (byte) 4)
        {
          int num4 = (int) Main.tile[i, j].frameY / 22;
          switch (num4)
          {
            case 0:
              Type = 6;
              break;
            case 8:
              Type = 75;
              break;
            default:
              Type = 58 + num4;
              break;
          }
        }
        if ((Main.tile[i, j].type == (byte) 34 || Main.tile[i, j].type == (byte) 35 || Main.tile[i, j].type == (byte) 36 || Main.tile[i, j].type == (byte) 42) && Main.rand.Next(2) == 0)
          Type = 6;
        if (Type >= 0)
          Dust.NewDust(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16, Type);
      }
      if (effectOnly)
        return;
      if (fail)
      {
        if (Main.tile[i, j].type == (byte) 2 || Main.tile[i, j].type == (byte) 23 || Main.tile[i, j].type == (byte) 109)
          Main.tile[i, j].type = (byte) 0;
        if (Main.tile[i, j].type == (byte) 60 || Main.tile[i, j].type == (byte) 70)
          Main.tile[i, j].type = (byte) 59;
        WorldGen.SquareTileFrame(i, j);
      }
      else
      {
        if (Main.tile[i, j].type == (byte) 21 && Main.netMode != 1)
        {
          int num5 = (int) Main.tile[i, j].frameX / 18;
          int Y = j - (int) Main.tile[i, j].frameY / 18;
          while (num5 > 1)
            num5 -= 2;
          if (!Chest.DestroyChest(i - num5, Y))
            return;
        }
        if (!noItem && !WorldGen.stopDrops && Main.netMode != 1)
        {
          int Type = 0;
          if (Main.tile[i, j].type == (byte) 0 || Main.tile[i, j].type == (byte) 2 || Main.tile[i, j].type == (byte) 109)
            Type = 2;
          else if (Main.tile[i, j].type == (byte) 1)
            Type = 3;
          else if (Main.tile[i, j].type == (byte) 3 || Main.tile[i, j].type == (byte) 73)
          {
            if (Main.rand.Next(2) == 0 && Main.player[(int) Player.FindClosest(new Vector2((float) (i * 16), (float) (j * 16)), 16, 16)].HasItem(281))
              Type = 283;
          }
          else if (Main.tile[i, j].type == (byte) 4)
          {
            int num6 = (int) Main.tile[i, j].frameY / 22;
            switch (num6)
            {
              case 0:
                Type = 8;
                break;
              case 8:
                Type = 523;
                break;
              default:
                Type = 426 + num6;
                break;
            }
          }
          else if (Main.tile[i, j].type == (byte) 5)
          {
            if (Main.tile[i, j].frameX >= (short) 22 && Main.tile[i, j].frameY >= (short) 198)
            {
              if (Main.netMode != 1)
              {
                if (WorldGen.genRand.Next(2) == 0)
                {
                  int index = j;
                  while (Main.tile[i, index] != null && (!Main.tile[i, index].active || !Main.tileSolid[(int) Main.tile[i, index].type] || Main.tileSolidTop[(int) Main.tile[i, index].type]))
                    ++index;
                  if (Main.tile[i, index] != null)
                    Type = Main.tile[i, index].type == (byte) 2 || Main.tile[i, index].type == (byte) 109 ? 27 : 9;
                }
                else
                  Type = 9;
              }
            }
            else
              Type = 9;
          }
          else if (Main.tile[i, j].type == (byte) 6)
            Type = 11;
          else if (Main.tile[i, j].type == (byte) 7)
            Type = 12;
          else if (Main.tile[i, j].type == (byte) 8)
            Type = 13;
          else if (Main.tile[i, j].type == (byte) 9)
            Type = 14;
          else if (Main.tile[i, j].type == (byte) 123)
            Type = 424;
          else if (Main.tile[i, j].type == (byte) 124)
            Type = 480;
          else if (Main.tile[i, j].type == (byte) 149)
          {
            if (Main.tile[i, j].frameX == (short) 0 || Main.tile[i, j].frameX == (short) 54)
              Type = 596;
            else if (Main.tile[i, j].frameX == (short) 18 || Main.tile[i, j].frameX == (short) 72)
              Type = 597;
            else if (Main.tile[i, j].frameX == (short) 36 || Main.tile[i, j].frameX == (short) 90)
              Type = 598;
          }
          else if (Main.tile[i, j].type == (byte) 13)
          {
            Main.PlaySound(13, i * 16, j * 16);
            Type = Main.tile[i, j].frameX != (short) 18 ? (Main.tile[i, j].frameX != (short) 36 ? (Main.tile[i, j].frameX != (short) 54 ? (Main.tile[i, j].frameX != (short) 72 ? 31 : 351) : 350) : 110) : 28;
          }
          else if (Main.tile[i, j].type == (byte) 19)
            Type = 94;
          else if (Main.tile[i, j].type == (byte) 22)
            Type = 56;
          else if (Main.tile[i, j].type == (byte) 140)
            Type = 577;
          else if (Main.tile[i, j].type == (byte) 23)
            Type = 2;
          else if (Main.tile[i, j].type == (byte) 25)
            Type = 61;
          else if (Main.tile[i, j].type == (byte) 30)
            Type = 9;
          else if (Main.tile[i, j].type == (byte) 33)
            Type = 105;
          else if (Main.tile[i, j].type == (byte) 37)
            Type = 116;
          else if (Main.tile[i, j].type == (byte) 38)
            Type = 129;
          else if (Main.tile[i, j].type == (byte) 39)
            Type = 131;
          else if (Main.tile[i, j].type == (byte) 40)
            Type = 133;
          else if (Main.tile[i, j].type == (byte) 41)
            Type = 134;
          else if (Main.tile[i, j].type == (byte) 43)
            Type = 137;
          else if (Main.tile[i, j].type == (byte) 44)
            Type = 139;
          else if (Main.tile[i, j].type == (byte) 45)
            Type = 141;
          else if (Main.tile[i, j].type == (byte) 46)
            Type = 143;
          else if (Main.tile[i, j].type == (byte) 47)
            Type = 145;
          else if (Main.tile[i, j].type == (byte) 48)
            Type = 147;
          else if (Main.tile[i, j].type == (byte) 49)
            Type = 148;
          else if (Main.tile[i, j].type == (byte) 51)
            Type = 150;
          else if (Main.tile[i, j].type == (byte) 53)
            Type = 169;
          else if (Main.tile[i, j].type == (byte) 54)
          {
            Type = 170;
            Main.PlaySound(13, i * 16, j * 16);
          }
          else if (Main.tile[i, j].type == (byte) 56)
            Type = 173;
          else if (Main.tile[i, j].type == (byte) 57)
            Type = 172;
          else if (Main.tile[i, j].type == (byte) 58)
            Type = 174;
          else if (Main.tile[i, j].type == (byte) 60)
            Type = 176;
          else if (Main.tile[i, j].type == (byte) 70)
            Type = 176;
          else if (Main.tile[i, j].type == (byte) 75)
            Type = 192;
          else if (Main.tile[i, j].type == (byte) 76)
            Type = 214;
          else if (Main.tile[i, j].type == (byte) 78)
            Type = 222;
          else if (Main.tile[i, j].type == (byte) 81)
            Type = 275;
          else if (Main.tile[i, j].type == (byte) 80)
            Type = 276;
          else if (Main.tile[i, j].type == (byte) 107)
            Type = 364;
          else if (Main.tile[i, j].type == (byte) 108)
            Type = 365;
          else if (Main.tile[i, j].type == (byte) 111)
            Type = 366;
          else if (Main.tile[i, j].type == (byte) 112)
            Type = 370;
          else if (Main.tile[i, j].type == (byte) 116)
            Type = 408;
          else if (Main.tile[i, j].type == (byte) 117)
            Type = 409;
          else if (Main.tile[i, j].type == (byte) 129)
            Type = 502;
          else if (Main.tile[i, j].type == (byte) 118)
            Type = 412;
          else if (Main.tile[i, j].type == (byte) 119)
            Type = 413;
          else if (Main.tile[i, j].type == (byte) 120)
            Type = 414;
          else if (Main.tile[i, j].type == (byte) 121)
            Type = 415;
          else if (Main.tile[i, j].type == (byte) 122)
            Type = 416;
          else if (Main.tile[i, j].type == (byte) 136)
            Type = 538;
          else if (Main.tile[i, j].type == (byte) 137)
            Type = 539;
          else if (Main.tile[i, j].type == (byte) 141)
            Type = 580;
          else if (Main.tile[i, j].type == (byte) 145)
            Type = 586;
          else if (Main.tile[i, j].type == (byte) 146)
            Type = 591;
          else if (Main.tile[i, j].type == (byte) 147)
            Type = 593;
          else if (Main.tile[i, j].type == (byte) 148)
            Type = 594;
          else if (Main.tile[i, j].type == (byte) 135)
          {
            if (Main.tile[i, j].frameY == (short) 0)
              Type = 529;
            if (Main.tile[i, j].frameY == (short) 18)
              Type = 541;
            if (Main.tile[i, j].frameY == (short) 36)
              Type = 542;
            if (Main.tile[i, j].frameY == (short) 54)
              Type = 543;
          }
          else if (Main.tile[i, j].type == (byte) 144)
          {
            if (Main.tile[i, j].frameX == (short) 0)
              Type = 583;
            if (Main.tile[i, j].frameX == (short) 18)
              Type = 584;
            if (Main.tile[i, j].frameX == (short) 36)
              Type = 585;
          }
          else if (Main.tile[i, j].type == (byte) 130)
            Type = 511;
          else if (Main.tile[i, j].type == (byte) 131)
            Type = 512;
          else if (Main.tile[i, j].type == (byte) 61 || Main.tile[i, j].type == (byte) 74)
          {
            if (Main.tile[i, j].frameX == (short) 144)
              Item.NewItem(i * 16, j * 16, 16, 16, 331, WorldGen.genRand.Next(2, 4));
            else if (Main.tile[i, j].frameX == (short) 162)
              Type = 223;
            else if (Main.tile[i, j].frameX >= (short) 108 && Main.tile[i, j].frameX <= (short) 126 && WorldGen.genRand.Next(100) == 0)
              Type = 208;
            else if (WorldGen.genRand.Next(100) == 0)
              Type = 195;
          }
          else if (Main.tile[i, j].type == (byte) 59 || Main.tile[i, j].type == (byte) 60)
            Type = 176;
          else if (Main.tile[i, j].type == (byte) 71 || Main.tile[i, j].type == (byte) 72)
          {
            if (WorldGen.genRand.Next(50) == 0)
              Type = 194;
            else if (WorldGen.genRand.Next(2) == 0)
              Type = 183;
          }
          else if (Main.tile[i, j].type >= (byte) 63 && Main.tile[i, j].type <= (byte) 68)
            Type = (int) Main.tile[i, j].type - 63 + 177;
          else if (Main.tile[i, j].type == (byte) 50)
            Type = Main.tile[i, j].frameX != (short) 90 ? 149 : 165;
          else if (Main.tileAlch[(int) Main.tile[i, j].type] && Main.tile[i, j].type > (byte) 82)
          {
            int num7 = (int) Main.tile[i, j].frameX / 18;
            bool flag = false;
            if (Main.tile[i, j].type == (byte) 84)
              flag = true;
            if (num7 == 0 && Main.dayTime)
              flag = true;
            if (num7 == 1 && !Main.dayTime)
              flag = true;
            if (num7 == 3 && Main.bloodMoon)
              flag = true;
            Type = 313 + num7;
            if (flag)
              Item.NewItem(i * 16, j * 16, 16, 16, 307 + num7, WorldGen.genRand.Next(1, 4));
          }
          if (Type > 0)
            Item.NewItem(i * 16, j * 16, 16, 16, Type, pfix: -1);
        }
        Main.tile[i, j].active = false;
        Main.tile[i, j].frameX = (short) -1;
        Main.tile[i, j].frameY = (short) -1;
        Main.tile[i, j].frameNumber = (byte) 0;
        if (Main.tile[i, j].type == (byte) 58 && j > Main.maxTilesY - 200)
        {
          Main.tile[i, j].lava = true;
          Main.tile[i, j].liquid = (byte) 128;
        }
        Main.tile[i, j].type = (byte) 0;
        WorldGen.SquareTileFrame(i, j);
      }
    }

    public static bool PlayerLOS(int x, int y)
    {
      Rectangle rectangle1 = new Rectangle(x * 16, y * 16, 16, 16);
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
        {
          Rectangle rectangle2 = new Rectangle((int) ((double) Main.player[index].position.X + (double) Main.player[index].width * 0.5 - (double) NPC.sWidth * 0.6), (int) ((double) Main.player[index].position.Y + (double) Main.player[index].height * 0.5 - (double) NPC.sHeight * 0.6), (int) ((double) NPC.sWidth * 1.2), (int) ((double) NPC.sHeight * 1.2));
          if (rectangle1.Intersects(rectangle2))
            return true;
        }
      }
      return false;
    }

    public static void hardUpdateWorld(int i, int j)
    {
      if (!Main.hardMode)
        return;
      int type = (int) Main.tile[i, j].type;
      if (type == 117 && (double) j > Main.rockLayer && Main.rand.Next(110) == 0)
      {
        int num1 = WorldGen.genRand.Next(4);
        int num2 = 0;
        int num3 = 0;
        switch (num1)
        {
          case 0:
            num2 = -1;
            break;
          case 1:
            num2 = 1;
            break;
          default:
            num3 = num1 != 0 ? 1 : -1;
            break;
        }
        if (!Main.tile[i + num2, j + num3].active)
        {
          int num4 = 0;
          int num5 = 6;
          for (int index1 = i - num5; index1 <= i + num5; ++index1)
          {
            for (int index2 = j - num5; index2 <= j + num5; ++index2)
            {
              if (Main.tile[index1, index2].active && Main.tile[index1, index2].type == (byte) 129)
                ++num4;
            }
          }
          if (num4 < 2)
          {
            WorldGen.PlaceTile(i + num2, j + num3, 129, true);
            NetMessage.SendTileSquare(-1, i + num2, j + num3, 1);
          }
        }
      }
      if (type == 23 || type == 25 || type == 32 || type == 112)
      {
        bool flag = true;
        while (flag)
        {
          flag = false;
          int index3 = i + WorldGen.genRand.Next(-3, 4);
          int index4 = j + WorldGen.genRand.Next(-3, 4);
          if (Main.tile[index3, index4].type == (byte) 2)
          {
            if (WorldGen.genRand.Next(2) == 0)
              flag = true;
            Main.tile[index3, index4].type = (byte) 23;
            WorldGen.SquareTileFrame(index3, index4);
            NetMessage.SendTileSquare(-1, index3, index4, 1);
          }
          else if (Main.tile[index3, index4].type == (byte) 1)
          {
            if (WorldGen.genRand.Next(2) == 0)
              flag = true;
            Main.tile[index3, index4].type = (byte) 25;
            WorldGen.SquareTileFrame(index3, index4);
            NetMessage.SendTileSquare(-1, index3, index4, 1);
          }
          else if (Main.tile[index3, index4].type == (byte) 53)
          {
            if (WorldGen.genRand.Next(2) == 0)
              flag = true;
            Main.tile[index3, index4].type = (byte) 112;
            WorldGen.SquareTileFrame(index3, index4);
            NetMessage.SendTileSquare(-1, index3, index4, 1);
          }
          else if (Main.tile[index3, index4].type == (byte) 59)
          {
            if (WorldGen.genRand.Next(2) == 0)
              flag = true;
            Main.tile[index3, index4].type = (byte) 0;
            WorldGen.SquareTileFrame(index3, index4);
            NetMessage.SendTileSquare(-1, index3, index4, 1);
          }
          else if (Main.tile[index3, index4].type == (byte) 60)
          {
            if (WorldGen.genRand.Next(2) == 0)
              flag = true;
            Main.tile[index3, index4].type = (byte) 23;
            WorldGen.SquareTileFrame(index3, index4);
            NetMessage.SendTileSquare(-1, index3, index4, 1);
          }
          else if (Main.tile[index3, index4].type == (byte) 69)
          {
            if (WorldGen.genRand.Next(2) == 0)
              flag = true;
            Main.tile[index3, index4].type = (byte) 32;
            WorldGen.SquareTileFrame(index3, index4);
            NetMessage.SendTileSquare(-1, index3, index4, 1);
          }
        }
      }
      if (type != 109 && type != 110 && type != 113 && type != 115 && type != 116 && type != 117 && type != 118)
        return;
      bool flag1 = true;
      while (flag1)
      {
        flag1 = false;
        int index5 = i + WorldGen.genRand.Next(-3, 4);
        int index6 = j + WorldGen.genRand.Next(-3, 4);
        if (Main.tile[index5, index6].type == (byte) 2)
        {
          if (WorldGen.genRand.Next(2) == 0)
            flag1 = true;
          Main.tile[index5, index6].type = (byte) 109;
          WorldGen.SquareTileFrame(index5, index6);
          NetMessage.SendTileSquare(-1, index5, index6, 1);
        }
        else if (Main.tile[index5, index6].type == (byte) 1)
        {
          if (WorldGen.genRand.Next(2) == 0)
            flag1 = true;
          Main.tile[index5, index6].type = (byte) 117;
          WorldGen.SquareTileFrame(index5, index6);
          NetMessage.SendTileSquare(-1, index5, index6, 1);
        }
        else if (Main.tile[index5, index6].type == (byte) 53)
        {
          if (WorldGen.genRand.Next(2) == 0)
            flag1 = true;
          Main.tile[index5, index6].type = (byte) 116;
          WorldGen.SquareTileFrame(index5, index6);
          NetMessage.SendTileSquare(-1, index5, index6, 1);
        }
      }
    }

    public static bool SolidTile(int i, int j)
    {
      try
      {
        if (Main.tile[i, j] == null)
          return true;
        if (Main.tile[i, j].active)
        {
          if (Main.tileSolid[(int) Main.tile[i, j].type])
          {
            if (!Main.tileSolidTop[(int) Main.tile[i, j].type])
              return true;
          }
        }
      }
      catch
      {
      }
      return false;
    }

    public static void MineHouse(int i, int j)
    {
      if (i < 50 || i > Main.maxTilesX - 50 || j < 50 || j > Main.maxTilesY - 50)
        return;
      int num1 = WorldGen.genRand.Next(6, 12);
      int num2 = WorldGen.genRand.Next(3, 6);
      int num3 = WorldGen.genRand.Next(15, 30);
      int num4 = WorldGen.genRand.Next(15, 30);
      if (WorldGen.SolidTile(i, j) || Main.tile[i, j].wall > (byte) 0)
        return;
      int num5 = j - num1;
      int num6 = j + num2;
      for (int index1 = 0; index1 < 2; ++index1)
      {
        bool flag1 = true;
        int i1 = i;
        int j1 = j;
        int num7 = -1;
        int num8 = num3;
        if (index1 == 1)
        {
          num7 = 1;
          num8 = num4;
          ++i1;
        }
        while (flag1)
        {
          if (j1 - num1 < num5)
            num5 = j1 - num1;
          if (j1 + num2 > num6)
            num6 = j1 + num2;
          for (int index2 = 0; index2 < 2; ++index2)
          {
            int j2 = j1;
            bool flag2 = true;
            int num9 = num1;
            int num10 = -1;
            if (index2 == 1)
            {
              ++j2;
              num9 = num2;
              num10 = 1;
            }
            while (flag2)
            {
              if (i1 != i && Main.tile[i1 - num7, j2].wall != (byte) 27 && (WorldGen.SolidTile(i1 - num7, j2) || !Main.tile[i1 - num7, j2].active))
              {
                Main.tile[i1 - num7, j2].active = true;
                Main.tile[i1 - num7, j2].type = (byte) 30;
              }
              if (WorldGen.SolidTile(i1 - 1, j2))
                Main.tile[i1 - 1, j2].type = (byte) 30;
              if (WorldGen.SolidTile(i1 + 1, j2))
                Main.tile[i1 + 1, j2].type = (byte) 30;
              if (WorldGen.SolidTile(i1, j2))
              {
                int num11 = 0;
                if (WorldGen.SolidTile(i1 - 1, j2))
                  ++num11;
                if (WorldGen.SolidTile(i1 + 1, j2))
                  ++num11;
                if (WorldGen.SolidTile(i1, j2 - 1))
                  ++num11;
                if (WorldGen.SolidTile(i1, j2 + 1))
                  ++num11;
                if (num11 < 2)
                {
                  Main.tile[i1, j2].active = false;
                }
                else
                {
                  flag2 = false;
                  Main.tile[i1, j2].type = (byte) 30;
                }
              }
              else
              {
                Main.tile[i1, j2].wall = (byte) 27;
                Main.tile[i1, j2].liquid = (byte) 0;
                Main.tile[i1, j2].lava = false;
              }
              j2 += num10;
              --num9;
              if (num9 <= 0)
              {
                if (!Main.tile[i1, j2].active)
                {
                  Main.tile[i1, j2].active = true;
                  Main.tile[i1, j2].type = (byte) 30;
                }
                flag2 = false;
              }
            }
          }
          --num8;
          i1 += num7;
          if (WorldGen.SolidTile(i1, j1))
          {
            int num12 = 0;
            int num13 = 0;
            int j3 = j1;
            bool flag3 = true;
            while (flag3)
            {
              --j3;
              ++num12;
              if (WorldGen.SolidTile(i1 - num7, j3))
              {
                num12 = 999;
                flag3 = false;
              }
              else if (!WorldGen.SolidTile(i1, j3))
                flag3 = false;
            }
            int j4 = j1;
            bool flag4 = true;
            while (flag4)
            {
              ++j4;
              ++num13;
              if (WorldGen.SolidTile(i1 - num7, j4))
              {
                num13 = 999;
                flag4 = false;
              }
              else if (!WorldGen.SolidTile(i1, j4))
                flag4 = false;
            }
            if (num13 <= num12)
            {
              if (num13 > num2)
                num8 = 0;
              else
                j1 += num13 + 1;
            }
            else if (num12 > num1)
              num8 = 0;
            else
              j1 -= num12 + 1;
          }
          if (num8 <= 0)
            flag1 = false;
        }
      }
      int num14 = i - num3 - 1;
      int num15 = i + num4 + 2;
      int num16 = num5 - 1;
      int num17 = num6 + 2;
      for (int i2 = num14; i2 < num15; ++i2)
      {
        for (int j5 = num16; j5 < num17; ++j5)
        {
          if (Main.tile[i2, j5].wall == (byte) 27 && !Main.tile[i2, j5].active)
          {
            if (Main.tile[i2 - 1, j5].wall != (byte) 27 && i2 < i && !WorldGen.SolidTile(i2 - 1, j5))
            {
              WorldGen.PlaceTile(i2, j5, 30, true);
              Main.tile[i2, j5].wall = (byte) 0;
            }
            if (Main.tile[i2 + 1, j5].wall != (byte) 27 && i2 > i && !WorldGen.SolidTile(i2 + 1, j5))
            {
              WorldGen.PlaceTile(i2, j5, 30, true);
              Main.tile[i2, j5].wall = (byte) 0;
            }
            for (int i3 = i2 - 1; i3 <= i2 + 1; ++i3)
            {
              for (int j6 = j5 - 1; j6 <= j5 + 1; ++j6)
              {
                if (WorldGen.SolidTile(i3, j6))
                  Main.tile[i3, j6].type = (byte) 30;
              }
            }
          }
          if (Main.tile[i2, j5].type == (byte) 30 && Main.tile[i2 - 1, j5].wall == (byte) 27 && Main.tile[i2 + 1, j5].wall == (byte) 27 && (Main.tile[i2, j5 - 1].wall == (byte) 27 || Main.tile[i2, j5 - 1].active) && (Main.tile[i2, j5 + 1].wall == (byte) 27 || Main.tile[i2, j5 + 1].active))
          {
            Main.tile[i2, j5].active = false;
            Main.tile[i2, j5].wall = (byte) 27;
          }
        }
      }
      for (int index3 = num14; index3 < num15; ++index3)
      {
        for (int index4 = num16; index4 < num17; ++index4)
        {
          if (Main.tile[index3, index4].type == (byte) 30)
          {
            if (Main.tile[index3 - 1, index4].wall == (byte) 27 && Main.tile[index3 + 1, index4].wall == (byte) 27 && !Main.tile[index3 - 1, index4].active && !Main.tile[index3 + 1, index4].active)
            {
              Main.tile[index3, index4].active = false;
              Main.tile[index3, index4].wall = (byte) 27;
            }
            if (Main.tile[index3, index4 - 1].type != (byte) 21 && Main.tile[index3 - 1, index4].wall == (byte) 27 && Main.tile[index3 + 1, index4].type == (byte) 30 && Main.tile[index3 + 2, index4].wall == (byte) 27 && !Main.tile[index3 - 1, index4].active && !Main.tile[index3 + 2, index4].active)
            {
              Main.tile[index3, index4].active = false;
              Main.tile[index3, index4].wall = (byte) 27;
              Main.tile[index3 + 1, index4].active = false;
              Main.tile[index3 + 1, index4].wall = (byte) 27;
            }
            if (Main.tile[index3, index4 - 1].wall == (byte) 27 && Main.tile[index3, index4 + 1].wall == (byte) 27 && !Main.tile[index3, index4 - 1].active && !Main.tile[index3, index4 + 1].active)
            {
              Main.tile[index3, index4].active = false;
              Main.tile[index3, index4].wall = (byte) 27;
            }
          }
        }
      }
      for (int i4 = num14; i4 < num15; ++i4)
      {
        for (int j7 = num17; j7 > num16; --j7)
        {
          bool flag5 = false;
          if (Main.tile[i4, j7].active && Main.tile[i4, j7].type == (byte) 30)
          {
            int num18 = -1;
            for (int index5 = 0; index5 < 2; ++index5)
            {
              if (!WorldGen.SolidTile(i4 + num18, j7) && Main.tile[i4 + num18, j7].wall == (byte) 0)
              {
                int num19 = 0;
                int j8 = j7;
                int num20 = j7;
                while (Main.tile[i4, j8].active && Main.tile[i4, j8].type == (byte) 30 && !WorldGen.SolidTile(i4 + num18, j8) && Main.tile[i4 + num18, j8].wall == (byte) 0)
                {
                  --j8;
                  ++num19;
                }
                int num21 = j8 + 1 + 1;
                if (num19 > 4)
                {
                  if (WorldGen.genRand.Next(2) == 0)
                  {
                    int j9 = num20 - 1;
                    bool flag6 = true;
                    for (int index6 = i4 - 2; index6 <= i4 + 2; ++index6)
                    {
                      for (int index7 = j9 - 2; index7 <= j9; ++index7)
                      {
                        if (index6 != i4 && Main.tile[index6, index7].active)
                          flag6 = false;
                      }
                    }
                    if (flag6)
                    {
                      Main.tile[i4, j9].active = false;
                      Main.tile[i4, j9 - 1].active = false;
                      Main.tile[i4, j9 - 2].active = false;
                      WorldGen.PlaceTile(i4, j9, 10, true);
                      flag5 = true;
                    }
                  }
                  if (!flag5)
                  {
                    for (int index8 = num21; index8 < num20; ++index8)
                      Main.tile[i4, index8].type = (byte) 124;
                  }
                }
              }
              num18 = 1;
            }
          }
          if (flag5)
            break;
        }
      }
      for (int i5 = num14; i5 < num15; i5 = i5 + WorldGen.genRand.Next(3) + 1)
      {
        bool flag = true;
        for (int j10 = num16; j10 < num17; ++j10)
        {
          for (int i6 = i5 - 2; i6 <= i5 + 2; ++i6)
          {
            if (Main.tile[i6, j10].active && (!WorldGen.SolidTile(i6, j10) || Main.tile[i6, j10].type == (byte) 10))
              flag = false;
          }
        }
        if (flag)
        {
          for (int j11 = num16; j11 < num17; ++j11)
          {
            if (Main.tile[i5, j11].wall == (byte) 27 && !Main.tile[i5, j11].active)
              WorldGen.PlaceTile(i5, j11, 124, true);
          }
        }
      }
      for (int index9 = 0; index9 < 4; ++index9)
      {
        int i7 = WorldGen.genRand.Next(num14 + 2, num15 - 1);
        int index10;
        for (index10 = WorldGen.genRand.Next(num16 + 2, num17 - 1); Main.tile[i7, index10].wall != (byte) 27; index10 = WorldGen.genRand.Next(num16 + 2, num17 - 1))
          i7 = WorldGen.genRand.Next(num14 + 2, num15 - 1);
        while (Main.tile[i7, index10].active)
          --index10;
        while (!Main.tile[i7, index10].active)
          ++index10;
        int j12 = index10 - 1;
        if (Main.tile[i7, j12].wall == (byte) 27)
        {
          if (WorldGen.genRand.Next(3) == 0)
          {
            int type = WorldGen.genRand.Next(9);
            if (type == 0)
              type = 14;
            if (type == 1)
              type = 16;
            if (type == 2)
              type = 18;
            if (type == 3)
              type = 86;
            if (type == 4)
              type = 87;
            if (type == 5)
              type = 94;
            if (type == 6)
              type = 101;
            if (type == 7)
              type = 104;
            if (type == 8)
              type = 106;
            WorldGen.PlaceTile(i7, j12, type, true);
          }
          else
          {
            int style = WorldGen.genRand.Next(2, 43);
            WorldGen.PlaceTile(i7, j12, 105, true, true, style: style);
          }
        }
      }
    }

    public static void CountTiles(int X)
    {
      if (X == 0)
      {
        WorldGen.totalEvil = WorldGen.totalEvil2;
        WorldGen.totalSolid = WorldGen.totalSolid2;
        WorldGen.totalGood = WorldGen.totalGood2;
        float num1 = (float) Math.Round((double) ((float) WorldGen.totalGood / (float) WorldGen.totalSolid) * 100.0);
        float num2 = (float) Math.Round((double) ((float) WorldGen.totalEvil / (float) WorldGen.totalSolid) * 100.0);
        WorldGen.tGood = (byte) num1;
        WorldGen.tEvil = (byte) num2;
        if (Main.netMode == 2)
          NetMessage.SendData(57);
        WorldGen.totalEvil2 = 0;
        WorldGen.totalSolid2 = 0;
        WorldGen.totalGood2 = 0;
      }
      for (int j = 0; j < Main.maxTilesY; ++j)
      {
        int num = 1;
        if ((double) j <= Main.worldSurface)
          num *= 5;
        if (WorldGen.SolidTile(X, j))
        {
          if (Main.tile[X, j].type == (byte) 109 || Main.tile[X, j].type == (byte) 116 || Main.tile[X, j].type == (byte) 117)
            WorldGen.totalGood2 += num;
          else if (Main.tile[X, j].type == (byte) 23 || Main.tile[X, j].type == (byte) 25 || Main.tile[X, j].type == (byte) 112)
            WorldGen.totalEvil2 += num;
          WorldGen.totalSolid2 += num;
        }
      }
    }

    public static void UpdateWorld()
    {
      WorldGen.UpdateMech();
      ++WorldGen.totalD;
      if (WorldGen.totalD >= 10)
      {
        WorldGen.totalD = 0;
        WorldGen.CountTiles(WorldGen.totalX);
        ++WorldGen.totalX;
        if (WorldGen.totalX >= Main.maxTilesX)
          WorldGen.totalX = 0;
      }
      ++Liquid.skipCount;
      if (Liquid.skipCount > 1)
      {
        Liquid.UpdateLiquid();
        Liquid.skipCount = 0;
      }
      float num1 = 3E-05f * (float) Main.worldRate;
      float num2 = 1.5E-05f * (float) Main.worldRate;
      bool flag1 = false;
      ++WorldGen.spawnDelay;
      if (Main.invasionType > 0)
        WorldGen.spawnDelay = 0;
      if (WorldGen.spawnDelay >= 20)
      {
        flag1 = true;
        WorldGen.spawnDelay = 0;
        if (WorldGen.spawnNPC != 37)
        {
          for (int index = 0; index < 200; ++index)
          {
            if (Main.npc[index].active && Main.npc[index].homeless && Main.npc[index].townNPC)
            {
              WorldGen.spawnNPC = Main.npc[index].type;
              break;
            }
          }
        }
      }
      for (int index1 = 0; (double) index1 < (double) (Main.maxTilesX * Main.maxTilesY) * (double) num1; ++index1)
      {
        int index2 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
        int index3 = WorldGen.genRand.Next(10, (int) Main.worldSurface - 1);
        int num3 = index2 - 1;
        int num4 = index2 + 2;
        int index4 = index3 - 1;
        int num5 = index3 + 2;
        if (num3 < 10)
          num3 = 10;
        if (num4 > Main.maxTilesX - 10)
          num4 = Main.maxTilesX - 10;
        if (index4 < 10)
          index4 = 10;
        if (num5 > Main.maxTilesY - 10)
          num5 = Main.maxTilesY - 10;
        if (Main.tile[index2, index3] != null)
        {
          if (Main.tileAlch[(int) Main.tile[index2, index3].type])
            WorldGen.GrowAlch(index2, index3);
          if (Main.tile[index2, index3].liquid > (byte) 32)
          {
            if (Main.tile[index2, index3].active && (Main.tile[index2, index3].type == (byte) 3 || Main.tile[index2, index3].type == (byte) 20 || Main.tile[index2, index3].type == (byte) 24 || Main.tile[index2, index3].type == (byte) 27 || Main.tile[index2, index3].type == (byte) 73))
            {
              WorldGen.KillTile(index2, index3);
              if (Main.netMode == 2)
                NetMessage.SendData(17, number2: ((float) index2), number3: ((float) index3));
            }
          }
          else if (Main.tile[index2, index3].active)
          {
            WorldGen.hardUpdateWorld(index2, index3);
            if (Main.tile[index2, index3].type == (byte) 80)
            {
              if (WorldGen.genRand.Next(15) == 0)
                WorldGen.GrowCactus(index2, index3);
            }
            else if (Main.tile[index2, index3].type == (byte) 53)
            {
              if (!Main.tile[index2, index4].active)
              {
                if (index2 < 250 || index2 > Main.maxTilesX - 250)
                {
                  if (WorldGen.genRand.Next(500) == 0 && Main.tile[index2, index4].liquid == byte.MaxValue && Main.tile[index2, index4 - 1].liquid == byte.MaxValue && Main.tile[index2, index4 - 2].liquid == byte.MaxValue && Main.tile[index2, index4 - 3].liquid == byte.MaxValue && Main.tile[index2, index4 - 4].liquid == byte.MaxValue)
                  {
                    WorldGen.PlaceTile(index2, index4, 81, true);
                    if (Main.netMode == 2 && Main.tile[index2, index4].active)
                      NetMessage.SendTileSquare(-1, index2, index4, 1);
                  }
                }
                else if (index2 > 400 && index2 < Main.maxTilesX - 400 && WorldGen.genRand.Next(300) == 0)
                  WorldGen.GrowCactus(index2, index3);
              }
            }
            else if (Main.tile[index2, index3].type == (byte) 116 || Main.tile[index2, index3].type == (byte) 112)
            {
              if (!Main.tile[index2, index4].active && index2 > 400 && index2 < Main.maxTilesX - 400 && WorldGen.genRand.Next(300) == 0)
                WorldGen.GrowCactus(index2, index3);
            }
            else if (Main.tile[index2, index3].type == (byte) 78)
            {
              if (!Main.tile[index2, index4].active)
              {
                WorldGen.PlaceTile(index2, index4, 3, true);
                if (Main.netMode == 2 && Main.tile[index2, index4].active)
                  NetMessage.SendTileSquare(-1, index2, index4, 1);
              }
            }
            else if (Main.tile[index2, index3].type == (byte) 2 || Main.tile[index2, index3].type == (byte) 23 || Main.tile[index2, index3].type == (byte) 32 || Main.tile[index2, index3].type == (byte) 109)
            {
              int grass = (int) Main.tile[index2, index3].type;
              if (!Main.tile[index2, index4].active && WorldGen.genRand.Next(12) == 0 && grass == 2)
              {
                WorldGen.PlaceTile(index2, index4, 3, true);
                if (Main.netMode == 2 && Main.tile[index2, index4].active)
                  NetMessage.SendTileSquare(-1, index2, index4, 1);
              }
              if (!Main.tile[index2, index4].active && WorldGen.genRand.Next(10) == 0 && grass == 23)
              {
                WorldGen.PlaceTile(index2, index4, 24, true);
                if (Main.netMode == 2 && Main.tile[index2, index4].active)
                  NetMessage.SendTileSquare(-1, index2, index4, 1);
              }
              if (!Main.tile[index2, index4].active && WorldGen.genRand.Next(10) == 0 && grass == 109)
              {
                WorldGen.PlaceTile(index2, index4, 110, true);
                if (Main.netMode == 2 && Main.tile[index2, index4].active)
                  NetMessage.SendTileSquare(-1, index2, index4, 1);
              }
              bool flag2 = false;
              for (int i = num3; i < num4; ++i)
              {
                for (int j = index4; j < num5; ++j)
                {
                  if ((index2 != i || index3 != j) && Main.tile[i, j].active)
                  {
                    if (grass == 32)
                      grass = 23;
                    if (Main.tile[i, j].type == (byte) 0 || grass == 23 && Main.tile[i, j].type == (byte) 2 || grass == 23 && Main.tile[i, j].type == (byte) 109)
                    {
                      WorldGen.SpreadGrass(i, j, grass: grass, repeat: false);
                      if (grass == 23)
                        WorldGen.SpreadGrass(i, j, 2, grass, false);
                      if (grass == 23)
                        WorldGen.SpreadGrass(i, j, 109, grass, false);
                      if ((int) Main.tile[i, j].type == grass)
                      {
                        WorldGen.SquareTileFrame(i, j);
                        flag2 = true;
                      }
                    }
                    if (Main.tile[i, j].type == (byte) 0 || grass == 109 && Main.tile[i, j].type == (byte) 2 || grass == 109 && Main.tile[i, j].type == (byte) 23)
                    {
                      WorldGen.SpreadGrass(i, j, grass: grass, repeat: false);
                      if (grass == 109)
                        WorldGen.SpreadGrass(i, j, 2, grass, false);
                      if (grass == 109)
                        WorldGen.SpreadGrass(i, j, 23, grass, false);
                      if ((int) Main.tile[i, j].type == grass)
                      {
                        WorldGen.SquareTileFrame(i, j);
                        flag2 = true;
                      }
                    }
                  }
                }
              }
              if (Main.netMode == 2 && flag2)
                NetMessage.SendTileSquare(-1, index2, index3, 3);
            }
            else if (Main.tile[index2, index3].type == (byte) 20 && WorldGen.genRand.Next(20) == 0 && !WorldGen.PlayerLOS(index2, index3))
              WorldGen.GrowTree(index2, index3);
            if (Main.tile[index2, index3].type == (byte) 3 && WorldGen.genRand.Next(20) == 0 && Main.tile[index2, index3].frameX < (short) 144)
            {
              Main.tile[index2, index3].type = (byte) 73;
              if (Main.netMode == 2)
                NetMessage.SendTileSquare(-1, index2, index3, 3);
            }
            if (Main.tile[index2, index3].type == (byte) 110 && WorldGen.genRand.Next(20) == 0 && Main.tile[index2, index3].frameX < (short) 144)
            {
              Main.tile[index2, index3].type = (byte) 113;
              if (Main.netMode == 2)
                NetMessage.SendTileSquare(-1, index2, index3, 3);
            }
            if (Main.tile[index2, index3].type == (byte) 32 && WorldGen.genRand.Next(3) == 0)
            {
              int index5 = index2;
              int index6 = index3;
              int num6 = 0;
              if (Main.tile[index5 + 1, index6].active && Main.tile[index5 + 1, index6].type == (byte) 32)
                ++num6;
              if (Main.tile[index5 - 1, index6].active && Main.tile[index5 - 1, index6].type == (byte) 32)
                ++num6;
              if (Main.tile[index5, index6 + 1].active && Main.tile[index5, index6 + 1].type == (byte) 32)
                ++num6;
              if (Main.tile[index5, index6 - 1].active && Main.tile[index5, index6 - 1].type == (byte) 32)
                ++num6;
              if (num6 < 3 || Main.tile[index2, index3].type == (byte) 23)
              {
                switch (WorldGen.genRand.Next(4))
                {
                  case 0:
                    --index6;
                    break;
                  case 1:
                    ++index6;
                    break;
                  case 2:
                    --index5;
                    break;
                  case 3:
                    ++index5;
                    break;
                }
                if (!Main.tile[index5, index6].active)
                {
                  int num7 = 0;
                  if (Main.tile[index5 + 1, index6].active && Main.tile[index5 + 1, index6].type == (byte) 32)
                    ++num7;
                  if (Main.tile[index5 - 1, index6].active && Main.tile[index5 - 1, index6].type == (byte) 32)
                    ++num7;
                  if (Main.tile[index5, index6 + 1].active && Main.tile[index5, index6 + 1].type == (byte) 32)
                    ++num7;
                  if (Main.tile[index5, index6 - 1].active && Main.tile[index5, index6 - 1].type == (byte) 32)
                    ++num7;
                  if (num7 < 2)
                  {
                    int num8 = 7;
                    int num9 = index5 - num8;
                    int num10 = index5 + num8;
                    int num11 = index6 - num8;
                    int num12 = index6 + num8;
                    bool flag3 = false;
                    for (int index7 = num9; index7 < num10; ++index7)
                    {
                      for (int index8 = num11; index8 < num12; ++index8)
                      {
                        if (Math.Abs(index7 - index5) * 2 + Math.Abs(index8 - index6) < 9 && Main.tile[index7, index8].active && Main.tile[index7, index8].type == (byte) 23 && Main.tile[index7, index8 - 1].active && Main.tile[index7, index8 - 1].type == (byte) 32 && Main.tile[index7, index8 - 1].liquid == (byte) 0)
                        {
                          flag3 = true;
                          break;
                        }
                      }
                    }
                    if (flag3)
                    {
                      Main.tile[index5, index6].type = (byte) 32;
                      Main.tile[index5, index6].active = true;
                      WorldGen.SquareTileFrame(index5, index6);
                      if (Main.netMode == 2)
                        NetMessage.SendTileSquare(-1, index5, index6, 3);
                    }
                  }
                }
              }
            }
          }
          else if (flag1 && WorldGen.spawnNPC > 0)
            WorldGen.SpawnNPC(index2, index3);
          if (Main.tile[index2, index3].active)
          {
            if ((Main.tile[index2, index3].type == (byte) 2 || Main.tile[index2, index3].type == (byte) 52) && WorldGen.genRand.Next(40) == 0 && !Main.tile[index2, index3 + 1].active && !Main.tile[index2, index3 + 1].lava)
            {
              bool flag4 = false;
              for (int index9 = index3; index9 > index3 - 10; --index9)
              {
                if (Main.tile[index2, index9].active && Main.tile[index2, index9].type == (byte) 2)
                {
                  flag4 = true;
                  break;
                }
              }
              if (flag4)
              {
                int index10 = index2;
                int index11 = index3 + 1;
                Main.tile[index10, index11].type = (byte) 52;
                Main.tile[index10, index11].active = true;
                WorldGen.SquareTileFrame(index10, index11);
                if (Main.netMode == 2)
                  NetMessage.SendTileSquare(-1, index10, index11, 3);
              }
            }
            if (Main.tile[index2, index3].type == (byte) 60)
            {
              int type = (int) Main.tile[index2, index3].type;
              if (!Main.tile[index2, index4].active && WorldGen.genRand.Next(7) == 0)
              {
                WorldGen.PlaceTile(index2, index4, 61, true);
                if (Main.netMode == 2 && Main.tile[index2, index4].active)
                  NetMessage.SendTileSquare(-1, index2, index4, 1);
              }
              else if (WorldGen.genRand.Next(500) == 0 && (!Main.tile[index2, index4].active || Main.tile[index2, index4].type == (byte) 61 || Main.tile[index2, index4].type == (byte) 74 || Main.tile[index2, index4].type == (byte) 69) && !WorldGen.PlayerLOS(index2, index3))
                WorldGen.GrowTree(index2, index3);
              bool flag5 = false;
              for (int i = num3; i < num4; ++i)
              {
                for (int j = index4; j < num5; ++j)
                {
                  if ((index2 != i || index3 != j) && Main.tile[i, j].active && Main.tile[i, j].type == (byte) 59)
                  {
                    WorldGen.SpreadGrass(i, j, 59, type, false);
                    if ((int) Main.tile[i, j].type == type)
                    {
                      WorldGen.SquareTileFrame(i, j);
                      flag5 = true;
                    }
                  }
                }
              }
              if (Main.netMode == 2 && flag5)
                NetMessage.SendTileSquare(-1, index2, index3, 3);
            }
            if (Main.tile[index2, index3].type == (byte) 61 && WorldGen.genRand.Next(3) == 0 && Main.tile[index2, index3].frameX < (short) 144)
            {
              Main.tile[index2, index3].type = (byte) 74;
              if (Main.netMode == 2)
                NetMessage.SendTileSquare(-1, index2, index3, 3);
            }
            if ((Main.tile[index2, index3].type == (byte) 60 || Main.tile[index2, index3].type == (byte) 62) && WorldGen.genRand.Next(15) == 0 && !Main.tile[index2, index3 + 1].active && !Main.tile[index2, index3 + 1].lava)
            {
              bool flag6 = false;
              for (int index12 = index3; index12 > index3 - 10; --index12)
              {
                if (Main.tile[index2, index12].active && Main.tile[index2, index12].type == (byte) 60)
                {
                  flag6 = true;
                  break;
                }
              }
              if (flag6)
              {
                int index13 = index2;
                int index14 = index3 + 1;
                Main.tile[index13, index14].type = (byte) 62;
                Main.tile[index13, index14].active = true;
                WorldGen.SquareTileFrame(index13, index14);
                if (Main.netMode == 2)
                  NetMessage.SendTileSquare(-1, index13, index14, 3);
              }
            }
            if ((Main.tile[index2, index3].type == (byte) 109 || Main.tile[index2, index3].type == (byte) 115) && WorldGen.genRand.Next(15) == 0 && !Main.tile[index2, index3 + 1].active && !Main.tile[index2, index3 + 1].lava)
            {
              bool flag7 = false;
              for (int index15 = index3; index15 > index3 - 10; --index15)
              {
                if (Main.tile[index2, index15].active && Main.tile[index2, index15].type == (byte) 109)
                {
                  flag7 = true;
                  break;
                }
              }
              if (flag7)
              {
                int index16 = index2;
                int index17 = index3 + 1;
                Main.tile[index16, index17].type = (byte) 115;
                Main.tile[index16, index17].active = true;
                WorldGen.SquareTileFrame(index16, index17);
                if (Main.netMode == 2)
                  NetMessage.SendTileSquare(-1, index16, index17, 3);
              }
            }
          }
        }
      }
      for (int index18 = 0; (double) index18 < (double) (Main.maxTilesX * Main.maxTilesY) * (double) num2; ++index18)
      {
        int index19 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
        int index20 = WorldGen.genRand.Next((int) Main.worldSurface - 1, Main.maxTilesY - 20);
        int num13 = index19 - 1;
        int num14 = index19 + 2;
        int index21 = index20 - 1;
        int num15 = index20 + 2;
        if (num13 < 10)
          num13 = 10;
        if (num14 > Main.maxTilesX - 10)
          num14 = Main.maxTilesX - 10;
        if (index21 < 10)
          index21 = 10;
        if (num15 > Main.maxTilesY - 10)
          num15 = Main.maxTilesY - 10;
        if (Main.tile[index19, index20] != null)
        {
          if (Main.tileAlch[(int) Main.tile[index19, index20].type])
            WorldGen.GrowAlch(index19, index20);
          if (Main.tile[index19, index20].liquid <= (byte) 32)
          {
            if (Main.tile[index19, index20].active)
            {
              WorldGen.hardUpdateWorld(index19, index20);
              if (Main.tile[index19, index20].type == (byte) 23 && !Main.tile[index19, index21].active && WorldGen.genRand.Next(1) == 0)
              {
                WorldGen.PlaceTile(index19, index21, 24, true);
                if (Main.netMode == 2 && Main.tile[index19, index21].active)
                  NetMessage.SendTileSquare(-1, index19, index21, 1);
              }
              if (Main.tile[index19, index20].type == (byte) 32 && WorldGen.genRand.Next(3) == 0)
              {
                int index22 = index19;
                int index23 = index20;
                int num16 = 0;
                if (Main.tile[index22 + 1, index23].active && Main.tile[index22 + 1, index23].type == (byte) 32)
                  ++num16;
                if (Main.tile[index22 - 1, index23].active && Main.tile[index22 - 1, index23].type == (byte) 32)
                  ++num16;
                if (Main.tile[index22, index23 + 1].active && Main.tile[index22, index23 + 1].type == (byte) 32)
                  ++num16;
                if (Main.tile[index22, index23 - 1].active && Main.tile[index22, index23 - 1].type == (byte) 32)
                  ++num16;
                if (num16 < 3 || Main.tile[index19, index20].type == (byte) 23)
                {
                  switch (WorldGen.genRand.Next(4))
                  {
                    case 0:
                      --index23;
                      break;
                    case 1:
                      ++index23;
                      break;
                    case 2:
                      --index22;
                      break;
                    case 3:
                      ++index22;
                      break;
                  }
                  if (!Main.tile[index22, index23].active)
                  {
                    int num17 = 0;
                    if (Main.tile[index22 + 1, index23].active && Main.tile[index22 + 1, index23].type == (byte) 32)
                      ++num17;
                    if (Main.tile[index22 - 1, index23].active && Main.tile[index22 - 1, index23].type == (byte) 32)
                      ++num17;
                    if (Main.tile[index22, index23 + 1].active && Main.tile[index22, index23 + 1].type == (byte) 32)
                      ++num17;
                    if (Main.tile[index22, index23 - 1].active && Main.tile[index22, index23 - 1].type == (byte) 32)
                      ++num17;
                    if (num17 < 2)
                    {
                      int num18 = 7;
                      int num19 = index22 - num18;
                      int num20 = index22 + num18;
                      int num21 = index23 - num18;
                      int num22 = index23 + num18;
                      bool flag8 = false;
                      for (int index24 = num19; index24 < num20; ++index24)
                      {
                        for (int index25 = num21; index25 < num22; ++index25)
                        {
                          if (Math.Abs(index24 - index22) * 2 + Math.Abs(index25 - index23) < 9 && Main.tile[index24, index25].active && Main.tile[index24, index25].type == (byte) 23 && Main.tile[index24, index25 - 1].active && Main.tile[index24, index25 - 1].type == (byte) 32 && Main.tile[index24, index25 - 1].liquid == (byte) 0)
                          {
                            flag8 = true;
                            break;
                          }
                        }
                      }
                      if (flag8)
                      {
                        Main.tile[index22, index23].type = (byte) 32;
                        Main.tile[index22, index23].active = true;
                        WorldGen.SquareTileFrame(index22, index23);
                        if (Main.netMode == 2)
                          NetMessage.SendTileSquare(-1, index22, index23, 3);
                      }
                    }
                  }
                }
              }
              if (Main.tile[index19, index20].type == (byte) 60)
              {
                int type = (int) Main.tile[index19, index20].type;
                if (!Main.tile[index19, index21].active && WorldGen.genRand.Next(10) == 0)
                {
                  WorldGen.PlaceTile(index19, index21, 61, true);
                  if (Main.netMode == 2 && Main.tile[index19, index21].active)
                    NetMessage.SendTileSquare(-1, index19, index21, 1);
                }
                bool flag9 = false;
                for (int i = num13; i < num14; ++i)
                {
                  for (int j = index21; j < num15; ++j)
                  {
                    if ((index19 != i || index20 != j) && Main.tile[i, j].active && Main.tile[i, j].type == (byte) 59)
                    {
                      WorldGen.SpreadGrass(i, j, 59, type, false);
                      if ((int) Main.tile[i, j].type == type)
                      {
                        WorldGen.SquareTileFrame(i, j);
                        flag9 = true;
                      }
                    }
                  }
                }
                if (Main.netMode == 2 && flag9)
                  NetMessage.SendTileSquare(-1, index19, index20, 3);
              }
              if (Main.tile[index19, index20].type == (byte) 61 && WorldGen.genRand.Next(3) == 0 && Main.tile[index19, index20].frameX < (short) 144)
              {
                Main.tile[index19, index20].type = (byte) 74;
                if (Main.netMode == 2)
                  NetMessage.SendTileSquare(-1, index19, index20, 3);
              }
              if ((Main.tile[index19, index20].type == (byte) 60 || Main.tile[index19, index20].type == (byte) 62) && WorldGen.genRand.Next(5) == 0 && !Main.tile[index19, index20 + 1].active && !Main.tile[index19, index20 + 1].lava)
              {
                bool flag10 = false;
                for (int index26 = index20; index26 > index20 - 10; --index26)
                {
                  if (Main.tile[index19, index26].active && Main.tile[index19, index26].type == (byte) 60)
                  {
                    flag10 = true;
                    break;
                  }
                }
                if (flag10)
                {
                  int index27 = index19;
                  int index28 = index20 + 1;
                  Main.tile[index27, index28].type = (byte) 62;
                  Main.tile[index27, index28].active = true;
                  WorldGen.SquareTileFrame(index27, index28);
                  if (Main.netMode == 2)
                    NetMessage.SendTileSquare(-1, index27, index28, 3);
                }
              }
              if (Main.tile[index19, index20].type == (byte) 69 && WorldGen.genRand.Next(3) == 0)
              {
                int index29 = index19;
                int index30 = index20;
                int num23 = 0;
                if (Main.tile[index29 + 1, index30].active && Main.tile[index29 + 1, index30].type == (byte) 69)
                  ++num23;
                if (Main.tile[index29 - 1, index30].active && Main.tile[index29 - 1, index30].type == (byte) 69)
                  ++num23;
                if (Main.tile[index29, index30 + 1].active && Main.tile[index29, index30 + 1].type == (byte) 69)
                  ++num23;
                if (Main.tile[index29, index30 - 1].active && Main.tile[index29, index30 - 1].type == (byte) 69)
                  ++num23;
                if (num23 < 3 || Main.tile[index19, index20].type == (byte) 60)
                {
                  switch (WorldGen.genRand.Next(4))
                  {
                    case 0:
                      --index30;
                      break;
                    case 1:
                      ++index30;
                      break;
                    case 2:
                      --index29;
                      break;
                    case 3:
                      ++index29;
                      break;
                  }
                  if (!Main.tile[index29, index30].active)
                  {
                    int num24 = 0;
                    if (Main.tile[index29 + 1, index30].active && Main.tile[index29 + 1, index30].type == (byte) 69)
                      ++num24;
                    if (Main.tile[index29 - 1, index30].active && Main.tile[index29 - 1, index30].type == (byte) 69)
                      ++num24;
                    if (Main.tile[index29, index30 + 1].active && Main.tile[index29, index30 + 1].type == (byte) 69)
                      ++num24;
                    if (Main.tile[index29, index30 - 1].active && Main.tile[index29, index30 - 1].type == (byte) 69)
                      ++num24;
                    if (num24 < 2)
                    {
                      int num25 = 7;
                      int num26 = index29 - num25;
                      int num27 = index29 + num25;
                      int num28 = index30 - num25;
                      int num29 = index30 + num25;
                      bool flag11 = false;
                      for (int index31 = num26; index31 < num27; ++index31)
                      {
                        for (int index32 = num28; index32 < num29; ++index32)
                        {
                          if (Math.Abs(index31 - index29) * 2 + Math.Abs(index32 - index30) < 9 && Main.tile[index31, index32].active && Main.tile[index31, index32].type == (byte) 60 && Main.tile[index31, index32 - 1].active && Main.tile[index31, index32 - 1].type == (byte) 69 && Main.tile[index31, index32 - 1].liquid == (byte) 0)
                          {
                            flag11 = true;
                            break;
                          }
                        }
                      }
                      if (flag11)
                      {
                        Main.tile[index29, index30].type = (byte) 69;
                        Main.tile[index29, index30].active = true;
                        WorldGen.SquareTileFrame(index29, index30);
                        if (Main.netMode == 2)
                          NetMessage.SendTileSquare(-1, index29, index30, 3);
                      }
                    }
                  }
                }
              }
              if (Main.tile[index19, index20].type == (byte) 70)
              {
                int type = (int) Main.tile[index19, index20].type;
                if (!Main.tile[index19, index21].active && WorldGen.genRand.Next(10) == 0)
                {
                  WorldGen.PlaceTile(index19, index21, 71, true);
                  if (Main.netMode == 2 && Main.tile[index19, index21].active)
                    NetMessage.SendTileSquare(-1, index19, index21, 1);
                }
                if (WorldGen.genRand.Next(200) == 0 && !WorldGen.PlayerLOS(index19, index20))
                  WorldGen.GrowShroom(index19, index20);
                bool flag12 = false;
                for (int i = num13; i < num14; ++i)
                {
                  for (int j = index21; j < num15; ++j)
                  {
                    if ((index19 != i || index20 != j) && Main.tile[i, j].active && Main.tile[i, j].type == (byte) 59)
                    {
                      WorldGen.SpreadGrass(i, j, 59, type, false);
                      if ((int) Main.tile[i, j].type == type)
                      {
                        WorldGen.SquareTileFrame(i, j);
                        flag12 = true;
                      }
                    }
                  }
                }
                if (Main.netMode == 2 && flag12)
                  NetMessage.SendTileSquare(-1, index19, index20, 3);
              }
            }
            else if (flag1 && WorldGen.spawnNPC > 0)
              WorldGen.SpawnNPC(index19, index20);
          }
        }
      }
      if (Main.rand.Next(100) == 0)
        WorldGen.PlantAlch();
      if (Main.dayTime)
        return;
      float num30 = (float) (Main.maxTilesX / 4200);
      if ((double) Main.rand.Next(8000) >= 10.0 * (double) num30)
        return;
      int num31 = 12;
      Vector2 vector2 = new Vector2((float) ((Main.rand.Next(Main.maxTilesX - 50) + 100) * 16), (float) (Main.rand.Next((int) ((double) Main.maxTilesY * 0.05)) * 16));
      float num32 = (float) Main.rand.Next(-100, 101);
      float num33 = (float) (Main.rand.Next(200) + 100);
      float num34 = (float) Math.Sqrt((double) num32 * (double) num32 + (double) num33 * (double) num33);
      float num35 = (float) num31 / num34;
      float SpeedX = num32 * num35;
      float SpeedY = num33 * num35;
      Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 12, 1000, 10f, Main.myPlayer);
    }

    public static void PlaceWall(int i, int j, int type, bool mute = false)
    {
      if (i <= 1 || j <= 1 || i >= Main.maxTilesX - 2 || j >= Main.maxTilesY - 2)
        return;
      if (Main.tile[i, j] == null)
        Main.tile[i, j] = new Tile();
      if (Main.tile[i, j].wall != (byte) 0)
        return;
      Main.tile[i, j].wall = (byte) type;
      WorldGen.SquareWallFrame(i, j);
      if (mute)
        return;
      Main.PlaySound(0, i * 16, j * 16);
    }

    public static void AddPlants()
    {
      for (int i = 0; i < Main.maxTilesX; ++i)
      {
        for (int index = 1; index < Main.maxTilesY; ++index)
        {
          if (Main.tile[i, index].type == (byte) 2 && Main.tile[i, index].active)
          {
            if (!Main.tile[i, index - 1].active)
              WorldGen.PlaceTile(i, index - 1, 3, true);
          }
          else if (Main.tile[i, index].type == (byte) 23 && Main.tile[i, index].active && !Main.tile[i, index - 1].active)
            WorldGen.PlaceTile(i, index - 1, 24, true);
        }
      }
    }

    public static void SpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true)
    {
      try
      {
        if ((int) Main.tile[i, j].type != dirt || !Main.tile[i, j].active || (double) j < Main.worldSurface && grass == 70 || (double) j >= Main.worldSurface && dirt == 0)
          return;
        int num1 = i - 1;
        int num2 = i + 2;
        int num3 = j - 1;
        int num4 = j + 2;
        if (num1 < 0)
          num1 = 0;
        if (num2 > Main.maxTilesX)
          num2 = Main.maxTilesX;
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesY)
          num4 = Main.maxTilesY;
        bool flag = true;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          for (int index2 = num3; index2 < num4; ++index2)
          {
            if (!Main.tile[index1, index2].active || !Main.tileSolid[(int) Main.tile[index1, index2].type])
              flag = false;
            if (Main.tile[index1, index2].lava && Main.tile[index1, index2].liquid > (byte) 0)
            {
              flag = true;
              break;
            }
          }
        }
        if (flag || grass == 23 && Main.tile[i, j - 1].type == (byte) 27)
          return;
        Main.tile[i, j].type = (byte) grass;
        for (int i1 = num1; i1 < num2; ++i1)
        {
          for (int j1 = num3; j1 < num4; ++j1)
          {
            if (Main.tile[i1, j1].active)
            {
              if ((int) Main.tile[i1, j1].type == dirt)
              {
                try
                {
                  if (repeat)
                  {
                    if (WorldGen.grassSpread < 1000)
                    {
                      ++WorldGen.grassSpread;
                      WorldGen.SpreadGrass(i1, j1, dirt, grass);
                      --WorldGen.grassSpread;
                    }
                  }
                }
                catch
                {
                }
              }
            }
          }
        }
      }
      catch
      {
      }
    }

    public static void ChasmRunnerSideways(int i, int j, int direction, int steps)
    {
      float num1 = (float) steps;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(10, 21) * 0.1f * (float) direction;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 10) * 0.01f;
      double num2 = (double) (WorldGen.genRand.Next(5) + 7);
      while (num2 > 0.0)
      {
        if ((double) num1 > 0.0)
        {
          num2 = num2 + (double) WorldGen.genRand.Next(3) - (double) WorldGen.genRand.Next(3);
          if (num2 < 7.0)
            num2 = 7.0;
          if (num2 > 20.0)
            num2 = 20.0;
          if ((double) num1 == 1.0 && num2 < 10.0)
            num2 = 10.0;
        }
        else
          num2 -= (double) WorldGen.genRand.Next(4);
        if ((double) vector2_1.Y > Main.rockLayer && (double) num1 > 0.0)
          num1 = 0.0f;
        --num1;
        int num3 = (int) ((double) vector2_1.X - num2 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num2 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num2 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num2 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX - 1)
          num4 = Main.maxTilesX - 1;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          for (int index2 = num5; index2 < num6; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < num2 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[index1, index2].type != (byte) 31 && Main.tile[index1, index2].type != (byte) 22)
              Main.tile[index1, index2].active = false;
          }
        }
        vector2_1 += vector2_2;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 10) * 0.1f;
        if ((double) vector2_1.Y < (double) (j - 20))
          vector2_2.Y += (float) WorldGen.genRand.Next(20) * 0.01f;
        if ((double) vector2_1.Y > (double) (j + 20))
          vector2_2.Y -= (float) WorldGen.genRand.Next(20) * 0.01f;
        if ((double) vector2_2.Y < -0.5)
          vector2_2.Y = -0.5f;
        if ((double) vector2_2.Y > 0.5)
          vector2_2.Y = 0.5f;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.01f;
        switch (direction)
        {
          case -1:
            if ((double) vector2_2.X > -0.5)
              vector2_2.X = -0.5f;
            if ((double) vector2_2.X < -2.0)
            {
              vector2_2.X = -2f;
              break;
            }
            break;
          case 1:
            if ((double) vector2_2.X < 0.5)
              vector2_2.X = 0.5f;
            if ((double) vector2_2.X > 2.0)
            {
              vector2_2.X = 2f;
              break;
            }
            break;
        }
        int num7 = (int) ((double) vector2_1.X - num2 * 1.1);
        int num8 = (int) ((double) vector2_1.X + num2 * 1.1);
        int num9 = (int) ((double) vector2_1.Y - num2 * 1.1);
        int num10 = (int) ((double) vector2_1.Y + num2 * 1.1);
        if (num7 < 1)
          num7 = 1;
        if (num8 > Main.maxTilesX - 1)
          num8 = Main.maxTilesX - 1;
        if (num9 < 0)
          num9 = 0;
        if (num10 > Main.maxTilesY)
          num10 = Main.maxTilesY;
        for (int index3 = num7; index3 < num8; ++index3)
        {
          for (int index4 = num9; index4 < num10; ++index4)
          {
            if ((double) Math.Abs((float) index3 - vector2_1.X) + (double) Math.Abs((float) index4 - vector2_1.Y) < num2 * 1.1 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[index3, index4].wall != (byte) 3)
            {
              if (Main.tile[index3, index4].type != (byte) 25 && index4 > j + WorldGen.genRand.Next(3, 20))
                Main.tile[index3, index4].active = true;
              Main.tile[index3, index4].active = true;
              if (Main.tile[index3, index4].type != (byte) 31 && Main.tile[index3, index4].type != (byte) 22)
                Main.tile[index3, index4].type = (byte) 25;
              if (Main.tile[index3, index4].wall == (byte) 2)
                Main.tile[index3, index4].wall = (byte) 0;
            }
          }
        }
        for (int i1 = num7; i1 < num8; ++i1)
        {
          for (int j1 = num9; j1 < num10; ++j1)
          {
            if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j1 - vector2_1.Y) < num2 * 1.1 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[i1, j1].wall != (byte) 3)
            {
              if (Main.tile[i1, j1].type != (byte) 31 && Main.tile[i1, j1].type != (byte) 22)
                Main.tile[i1, j1].type = (byte) 25;
              Main.tile[i1, j1].active = true;
              WorldGen.PlaceWall(i1, j1, 3, true);
            }
          }
        }
      }
      if (WorldGen.genRand.Next(3) != 0)
        return;
      int x = (int) vector2_1.X;
      int y = (int) vector2_1.Y;
      while (!Main.tile[x, y].active)
        ++y;
      WorldGen.TileRunner(x, y, (double) WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), 22);
    }

    public static void ChasmRunner(int i, int j, int steps, bool makeOrb = false)
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      if (!makeOrb)
        flag2 = true;
      float num1 = (float) steps;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) ((double) WorldGen.genRand.Next(11) * 0.200000002980232 + 0.5);
      int num2 = 5;
      double num3 = (double) (WorldGen.genRand.Next(5) + 7);
      while (num3 > 0.0)
      {
        if ((double) num1 > 0.0)
        {
          num3 = num3 + (double) WorldGen.genRand.Next(3) - (double) WorldGen.genRand.Next(3);
          if (num3 < 7.0)
            num3 = 7.0;
          if (num3 > 20.0)
            num3 = 20.0;
          if ((double) num1 == 1.0 && num3 < 10.0)
            num3 = 10.0;
        }
        else if ((double) vector2_1.Y > Main.worldSurface + 45.0)
          num3 -= (double) WorldGen.genRand.Next(4);
        if ((double) vector2_1.Y > Main.rockLayer && (double) num1 > 0.0)
          num1 = 0.0f;
        --num1;
        if (!flag1 && (double) vector2_1.Y > Main.worldSurface + 20.0)
        {
          flag1 = true;
          WorldGen.ChasmRunnerSideways((int) vector2_1.X, (int) vector2_1.Y, -1, WorldGen.genRand.Next(20, 40));
          WorldGen.ChasmRunnerSideways((int) vector2_1.X, (int) vector2_1.Y, 1, WorldGen.genRand.Next(20, 40));
        }
        if ((double) num1 > (double) num2)
        {
          int num4 = (int) ((double) vector2_1.X - num3 * 0.5);
          int num5 = (int) ((double) vector2_1.X + num3 * 0.5);
          int num6 = (int) ((double) vector2_1.Y - num3 * 0.5);
          int num7 = (int) ((double) vector2_1.Y + num3 * 0.5);
          if (num4 < 0)
            num4 = 0;
          if (num5 > Main.maxTilesX - 1)
            num5 = Main.maxTilesX - 1;
          if (num6 < 0)
            num6 = 0;
          if (num7 > Main.maxTilesY)
            num7 = Main.maxTilesY;
          for (int index1 = num4; index1 < num5; ++index1)
          {
            for (int index2 = num6; index2 < num7; ++index2)
            {
              if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < num3 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[index1, index2].type != (byte) 31 && Main.tile[index1, index2].type != (byte) 22)
                Main.tile[index1, index2].active = false;
            }
          }
        }
        if ((double) num1 <= 2.0 && (double) vector2_1.Y < Main.worldSurface + 45.0)
          num1 = 2f;
        if ((double) num1 <= 0.0)
        {
          if (!flag2)
          {
            flag2 = true;
            WorldGen.AddShadowOrb((int) vector2_1.X, (int) vector2_1.Y);
          }
          else if (!flag3)
          {
            flag3 = false;
            bool flag4 = false;
            int num8 = 0;
            while (!flag4)
            {
              int x = WorldGen.genRand.Next((int) vector2_1.X - 25, (int) vector2_1.X + 25);
              int y = WorldGen.genRand.Next((int) vector2_1.Y - 50, (int) vector2_1.Y);
              if (x < 5)
                x = 5;
              if (x > Main.maxTilesX - 5)
                x = Main.maxTilesX - 5;
              if (y < 5)
                y = 5;
              if (y > Main.maxTilesY - 5)
                y = Main.maxTilesY - 5;
              if ((double) y > Main.worldSurface)
              {
                WorldGen.Place3x2(x, y, 26);
                if (Main.tile[x, y].type == (byte) 26)
                {
                  flag4 = true;
                }
                else
                {
                  ++num8;
                  if (num8 >= 10000)
                    flag4 = true;
                }
              }
              else
                flag4 = true;
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.01f;
        if ((double) vector2_2.X > 0.3)
          vector2_2.X = 0.3f;
        if ((double) vector2_2.X < -0.3)
          vector2_2.X = -0.3f;
        int num9 = (int) ((double) vector2_1.X - num3 * 1.1);
        int num10 = (int) ((double) vector2_1.X + num3 * 1.1);
        int num11 = (int) ((double) vector2_1.Y - num3 * 1.1);
        int num12 = (int) ((double) vector2_1.Y + num3 * 1.1);
        if (num9 < 1)
          num9 = 1;
        if (num10 > Main.maxTilesX - 1)
          num10 = Main.maxTilesX - 1;
        if (num11 < 0)
          num11 = 0;
        if (num12 > Main.maxTilesY)
          num12 = Main.maxTilesY;
        for (int index3 = num9; index3 < num10; ++index3)
        {
          for (int index4 = num11; index4 < num12; ++index4)
          {
            if ((double) Math.Abs((float) index3 - vector2_1.X) + (double) Math.Abs((float) index4 - vector2_1.Y) < num3 * 1.1 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
            {
              if (Main.tile[index3, index4].type != (byte) 25 && index4 > j + WorldGen.genRand.Next(3, 20))
                Main.tile[index3, index4].active = true;
              if (steps <= num2)
                Main.tile[index3, index4].active = true;
              if (Main.tile[index3, index4].type != (byte) 31)
                Main.tile[index3, index4].type = (byte) 25;
              if (Main.tile[index3, index4].wall == (byte) 2)
                Main.tile[index3, index4].wall = (byte) 0;
            }
          }
        }
        for (int i1 = num9; i1 < num10; ++i1)
        {
          for (int j1 = num11; j1 < num12; ++j1)
          {
            if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j1 - vector2_1.Y) < num3 * 1.1 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
            {
              if (Main.tile[i1, j1].type != (byte) 31)
                Main.tile[i1, j1].type = (byte) 25;
              if (steps <= num2)
                Main.tile[i1, j1].active = true;
              if (j1 > j + WorldGen.genRand.Next(3, 20))
                WorldGen.PlaceWall(i1, j1, 3, true);
            }
          }
        }
      }
    }

    public static void JungleRunner(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(5, 11);
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(10, 20) * 0.1f;
      int num2 = 0;
      bool flag = true;
      while (flag)
      {
        if ((double) vector2_1.Y < Main.worldSurface)
        {
          int x = (int) vector2_1.X;
          int y = (int) vector2_1.Y;
          if (Main.tile[x, y].wall == (byte) 0 && !Main.tile[x, y].active && Main.tile[x, y - 3].wall == (byte) 0 && !Main.tile[x, y - 3].active && Main.tile[x, y - 1].wall == (byte) 0 && !Main.tile[x, y - 1].active && Main.tile[x, y - 4].wall == (byte) 0 && !Main.tile[x, y - 4].active && Main.tile[x, y - 2].wall == (byte) 0 && !Main.tile[x, y - 2].active && Main.tile[x, y - 5].wall == (byte) 0 && !Main.tile[x, y - 5].active)
            flag = false;
        }
        WorldGen.JungleX = (int) vector2_1.X;
        num1 += (double) WorldGen.genRand.Next(-20, 21) * 0.100000001490116;
        if (num1 < 5.0)
          num1 = 5.0;
        if (num1 > 10.0)
          num1 = 10.0;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX)
          num4 = Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        for (int i1 = num3; i1 < num4; ++i1)
        {
          for (int j1 = num5; j1 < num6; ++j1)
          {
            if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j1 - vector2_1.Y) < num1 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
              WorldGen.KillTile(i1, j1);
          }
        }
        ++num2;
        if (num2 > 10 && WorldGen.genRand.Next(50) < num2)
        {
          num2 = 0;
          int num7 = -2;
          if (WorldGen.genRand.Next(2) == 0)
            num7 = 2;
          WorldGen.TileRunner((int) vector2_1.X, (int) vector2_1.Y, (double) WorldGen.genRand.Next(3, 20), WorldGen.genRand.Next(10, 100), -1, speedX: ((float) num7));
        }
        vector2_1 += vector2_2;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.01f;
        if ((double) vector2_2.Y > 0.0)
          vector2_2.Y = 0.0f;
        if ((double) vector2_2.Y < -2.0)
          vector2_2.Y = -2f;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
        if ((double) vector2_1.X < (double) (i - 200))
          vector2_2.X += (float) WorldGen.genRand.Next(5, 21) * 0.1f;
        if ((double) vector2_1.X > (double) (i + 200))
          vector2_2.X -= (float) WorldGen.genRand.Next(5, 21) * 0.1f;
        if ((double) vector2_2.X > 1.5)
          vector2_2.X = 1.5f;
        if ((double) vector2_2.X < -1.5)
          vector2_2.X = -1.5f;
      }
    }

    public static void GERunner(int i, int j, float speedX = 0.0f, float speedY = 0.0f, bool good = true)
    {
      int num1 = (int) ((double) WorldGen.genRand.Next(200, 250) * (double) (Main.maxTilesX / 4200));
      double num2 = (double) num1;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      if ((double) speedX != 0.0 || (double) speedY != 0.0)
      {
        vector2_2.X = speedX;
        vector2_2.Y = speedY;
      }
      bool flag = true;
      while (flag)
      {
        int num3 = (int) ((double) vector2_1.X - num2 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num2 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num2 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num2 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX)
          num4 = Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        for (int i1 = num3; i1 < num4; ++i1)
        {
          for (int j1 = num5; j1 < num6; ++j1)
          {
            if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j1 - vector2_1.Y) < (double) num1 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
            {
              if (good)
              {
                if (Main.tile[i1, j1].wall == (byte) 3)
                  Main.tile[i1, j1].wall = (byte) 28;
                if (Main.tile[i1, j1].type == (byte) 2)
                {
                  Main.tile[i1, j1].type = (byte) 109;
                  WorldGen.SquareTileFrame(i1, j1);
                }
                else if (Main.tile[i1, j1].type == (byte) 1)
                {
                  Main.tile[i1, j1].type = (byte) 117;
                  WorldGen.SquareTileFrame(i1, j1);
                }
                else if (Main.tile[i1, j1].type == (byte) 53 || Main.tile[i1, j1].type == (byte) 123)
                {
                  Main.tile[i1, j1].type = (byte) 116;
                  WorldGen.SquareTileFrame(i1, j1);
                }
                else if (Main.tile[i1, j1].type == (byte) 23)
                {
                  Main.tile[i1, j1].type = (byte) 109;
                  WorldGen.SquareTileFrame(i1, j1);
                }
                else if (Main.tile[i1, j1].type == (byte) 25)
                {
                  Main.tile[i1, j1].type = (byte) 117;
                  WorldGen.SquareTileFrame(i1, j1);
                }
                else if (Main.tile[i1, j1].type == (byte) 112)
                {
                  Main.tile[i1, j1].type = (byte) 116;
                  WorldGen.SquareTileFrame(i1, j1);
                }
              }
              else if (Main.tile[i1, j1].type == (byte) 2)
              {
                Main.tile[i1, j1].type = (byte) 23;
                WorldGen.SquareTileFrame(i1, j1);
              }
              else if (Main.tile[i1, j1].type == (byte) 1)
              {
                Main.tile[i1, j1].type = (byte) 25;
                WorldGen.SquareTileFrame(i1, j1);
              }
              else if (Main.tile[i1, j1].type == (byte) 53 || Main.tile[i1, j1].type == (byte) 123)
              {
                Main.tile[i1, j1].type = (byte) 112;
                WorldGen.SquareTileFrame(i1, j1);
              }
              else if (Main.tile[i1, j1].type == (byte) 109)
              {
                Main.tile[i1, j1].type = (byte) 23;
                WorldGen.SquareTileFrame(i1, j1);
              }
              else if (Main.tile[i1, j1].type == (byte) 117)
              {
                Main.tile[i1, j1].type = (byte) 25;
                WorldGen.SquareTileFrame(i1, j1);
              }
              else if (Main.tile[i1, j1].type == (byte) 116)
              {
                Main.tile[i1, j1].type = (byte) 112;
                WorldGen.SquareTileFrame(i1, j1);
              }
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > (double) speedX + 1.0)
          vector2_2.X = speedX + 1f;
        if ((double) vector2_2.X < (double) speedX - 1.0)
          vector2_2.X = speedX - 1f;
        if ((double) vector2_1.X < (double) -num1 || (double) vector2_1.Y < (double) -num1 || (double) vector2_1.X > (double) (Main.maxTilesX + num1) || (double) vector2_1.Y > (double) (Main.maxTilesX + num1))
          flag = false;
      }
    }

    public static void TileRunner(
      int i,
      int j,
      double strength,
      int steps,
      int type,
      bool addTile = false,
      float speedX = 0.0f,
      float speedY = 0.0f,
      bool noYChange = false,
      bool overRide = true)
    {
      double num1 = strength;
      float num2 = (float) steps;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      if ((double) speedX != 0.0 || (double) speedY != 0.0)
      {
        vector2_2.X = speedX;
        vector2_2.Y = speedY;
      }
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        if ((double) vector2_1.Y < 0.0 && (double) num2 > 0.0 && type == 59)
          num2 = 0.0f;
        num1 = strength * ((double) num2 / (double) steps);
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX)
          num4 = Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        for (int i1 = num3; i1 < num4; ++i1)
        {
          for (int j1 = num5; j1 < num6; ++j1)
          {
            if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j1 - vector2_1.Y) < strength * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
            {
              if (WorldGen.mudWall && (double) j1 > Main.worldSurface && j1 < Main.maxTilesY - 210 - WorldGen.genRand.Next(3))
                WorldGen.PlaceWall(i1, j1, 15, true);
              if (type < 0)
              {
                if (type == -2 && Main.tile[i1, j1].active && (j1 < WorldGen.waterLine || j1 > WorldGen.lavaLine))
                {
                  Main.tile[i1, j1].liquid = byte.MaxValue;
                  if (j1 > WorldGen.lavaLine)
                    Main.tile[i1, j1].lava = true;
                }
                Main.tile[i1, j1].active = false;
              }
              else
              {
                if ((overRide || !Main.tile[i1, j1].active) && (type != 40 || Main.tile[i1, j1].type != (byte) 53) && (!Main.tileStone[type] || Main.tile[i1, j1].type == (byte) 1) && Main.tile[i1, j1].type != (byte) 45 && Main.tile[i1, j1].type != (byte) 147 && (Main.tile[i1, j1].type != (byte) 1 || type != 59 || (double) j1 >= Main.worldSurface + (double) WorldGen.genRand.Next(-50, 50)))
                {
                  if (Main.tile[i1, j1].type != (byte) 53 || (double) j1 >= Main.worldSurface)
                    Main.tile[i1, j1].type = (byte) type;
                  else if (type == 59)
                    Main.tile[i1, j1].type = (byte) type;
                }
                if (addTile)
                {
                  Main.tile[i1, j1].active = true;
                  Main.tile[i1, j1].liquid = (byte) 0;
                  Main.tile[i1, j1].lava = false;
                }
                if (noYChange && (double) j1 < Main.worldSurface && type != 59)
                  Main.tile[i1, j1].wall = (byte) 2;
                if (type == 59 && j1 > WorldGen.waterLine && Main.tile[i1, j1].liquid > (byte) 0)
                {
                  Main.tile[i1, j1].lava = false;
                  Main.tile[i1, j1].liquid = (byte) 0;
                }
              }
            }
          }
        }
        vector2_1 += vector2_2;
        if (num1 > 50.0)
        {
          vector2_1 += vector2_2;
          --num2;
          vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
          vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
          if (num1 > 100.0)
          {
            vector2_1 += vector2_2;
            --num2;
            vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
            vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
            if (num1 > 150.0)
            {
              vector2_1 += vector2_2;
              --num2;
              vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
              vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
              if (num1 > 200.0)
              {
                vector2_1 += vector2_2;
                --num2;
                vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (num1 > 250.0)
                {
                  vector2_1 += vector2_2;
                  --num2;
                  vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                  vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                  if (num1 > 300.0)
                  {
                    vector2_1 += vector2_2;
                    --num2;
                    vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                    vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (num1 > 400.0)
                    {
                      vector2_1 += vector2_2;
                      --num2;
                      vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                      vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                      if (num1 > 500.0)
                      {
                        vector2_1 += vector2_2;
                        --num2;
                        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num1 > 600.0)
                        {
                          vector2_1 += vector2_2;
                          --num2;
                          vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                          vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                          if (num1 > 700.0)
                          {
                            vector2_1 += vector2_2;
                            --num2;
                            vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                            vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num1 > 800.0)
                            {
                              vector2_1 += vector2_2;
                              --num2;
                              vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                              vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                              if (num1 > 900.0)
                              {
                                vector2_1 += vector2_2;
                                --num2;
                                vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                                vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
        if (!noYChange)
        {
          vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
          if ((double) vector2_2.Y > 1.0)
            vector2_2.Y = 1f;
          if ((double) vector2_2.Y < -1.0)
            vector2_2.Y = -1f;
        }
        else if (type != 59 && num1 < 3.0)
        {
          if ((double) vector2_2.Y > 1.0)
            vector2_2.Y = 1f;
          if ((double) vector2_2.Y < -1.0)
            vector2_2.Y = -1f;
        }
        if (type == 59 && !noYChange)
        {
          if ((double) vector2_2.Y > 0.5)
            vector2_2.Y = 0.5f;
          if ((double) vector2_2.Y < -0.5)
            vector2_2.Y = -0.5f;
          if ((double) vector2_1.Y < Main.rockLayer + 100.0)
            vector2_2.Y = 1f;
          if ((double) vector2_1.Y > (double) (Main.maxTilesY - 300))
            vector2_2.Y = -1f;
        }
      }
    }

    public static void MudWallRunner(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(5, 15);
      float num2 = (float) WorldGen.genRand.Next(5, 20);
      float num3 = num2;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      while (num1 > 0.0 && (double) num3 > 0.0)
      {
        double num4 = num1 * ((double) num3 / (double) num2);
        --num3;
        int num5 = (int) ((double) vector2_1.X - num4 * 0.5);
        int num6 = (int) ((double) vector2_1.X + num4 * 0.5);
        int num7 = (int) ((double) vector2_1.Y - num4 * 0.5);
        int num8 = (int) ((double) vector2_1.Y + num4 * 0.5);
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesX)
          num6 = Main.maxTilesX;
        if (num7 < 0)
          num7 = 0;
        if (num8 > Main.maxTilesY)
          num8 = Main.maxTilesY;
        for (int index1 = num5; index1 < num6; ++index1)
        {
          for (int index2 = num7; index2 < num8; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < num1 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
              Main.tile[index1, index2].wall = (byte) 0;
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.Y > 1.0)
          vector2_2.Y = 1f;
        if ((double) vector2_2.Y < -1.0)
          vector2_2.Y = -1f;
      }
    }

    public static void FloatingIsland(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(80, 120);
      float num2 = (float) WorldGen.genRand.Next(20, 25);
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-20, 21) * 0.2f;
      while ((double) vector2_2.X > -2.0 && (double) vector2_2.X < 2.0)
        vector2_2.X = (float) WorldGen.genRand.Next(-20, 21) * 0.2f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.02f;
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        num1 -= (double) WorldGen.genRand.Next(4);
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX)
          num4 = Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        double num7 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        float num8 = vector2_1.Y + 1f;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          if (WorldGen.genRand.Next(2) == 0)
            num8 += (float) WorldGen.genRand.Next(-1, 2);
          if ((double) num8 < (double) vector2_1.Y)
            num8 = vector2_1.Y;
          if ((double) num8 > (double) vector2_1.Y + 2.0)
            num8 = vector2_1.Y + 2f;
          for (int index2 = num5; index2 < num6; ++index2)
          {
            if ((double) index2 > (double) num8)
            {
              float num9 = Math.Abs((float) index1 - vector2_1.X);
              float num10 = Math.Abs((float) index2 - vector2_1.Y) * 2f;
              if (Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10) < num7 * 0.4)
              {
                Main.tile[index1, index2].active = true;
                if (Main.tile[index1, index2].type == (byte) 59)
                  Main.tile[index1, index2].type = (byte) 0;
              }
            }
          }
        }
        WorldGen.TileRunner(WorldGen.genRand.Next(num3 + 10, num4 - 10), (int) ((double) vector2_1.Y + num7 * 0.1 + 5.0), (double) WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(10, 15), 0, true, speedY: 2f, noYChange: true);
        int num11 = (int) ((double) vector2_1.X - num1 * 0.4);
        int num12 = (int) ((double) vector2_1.X + num1 * 0.4);
        int num13 = (int) ((double) vector2_1.Y - num1 * 0.4);
        int num14 = (int) ((double) vector2_1.Y + num1 * 0.4);
        if (num11 < 0)
          num11 = 0;
        if (num12 > Main.maxTilesX)
          num12 = Main.maxTilesX;
        if (num13 < 0)
          num13 = 0;
        if (num14 > Main.maxTilesY)
          num14 = Main.maxTilesY;
        double num15 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        for (int index3 = num11; index3 < num12; ++index3)
        {
          for (int index4 = num13; index4 < num14; ++index4)
          {
            if ((double) index4 > (double) vector2_1.Y + 2.0)
            {
              float num16 = Math.Abs((float) index3 - vector2_1.X);
              float num17 = Math.Abs((float) index4 - vector2_1.Y) * 2f;
              if (Math.Sqrt((double) num16 * (double) num16 + (double) num17 * (double) num17) < num15 * 0.4)
                Main.tile[index3, index4].wall = (byte) 2;
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
        if ((double) vector2_2.Y > 0.2)
          vector2_2.Y = -0.2f;
        if ((double) vector2_2.Y < -0.2)
          vector2_2.Y = -0.2f;
      }
    }

    public static void Caverer(int X, int Y)
    {
      switch (WorldGen.genRand.Next(2))
      {
        case 0:
          int num1 = WorldGen.genRand.Next(7, 9);
          float xDir1 = (float) WorldGen.genRand.Next(100) * 0.01f;
          float yDir1 = 1f - xDir1;
          if (WorldGen.genRand.Next(2) == 0)
            xDir1 = -xDir1;
          if (WorldGen.genRand.Next(2) == 0)
            yDir1 = -yDir1;
          Vector2 vector2_1 = new Vector2((float) X, (float) Y);
          for (int index = 0; index < num1; ++index)
          {
            vector2_1 = WorldGen.digTunnel(vector2_1.X, vector2_1.Y, xDir1, yDir1, WorldGen.genRand.Next(6, 20), WorldGen.genRand.Next(4, 9));
            xDir1 += (float) WorldGen.genRand.Next(-20, 21) * 0.1f;
            yDir1 += (float) WorldGen.genRand.Next(-20, 21) * 0.1f;
            if ((double) xDir1 < -1.5)
              xDir1 = -1.5f;
            if ((double) xDir1 > 1.5)
              xDir1 = 1.5f;
            if ((double) yDir1 < -1.5)
              yDir1 = -1.5f;
            if ((double) yDir1 > 1.5)
              yDir1 = 1.5f;
            float xDir2 = (float) WorldGen.genRand.Next(100) * 0.01f;
            float yDir2 = 1f - xDir2;
            if (WorldGen.genRand.Next(2) == 0)
              xDir2 = -xDir2;
            if (WorldGen.genRand.Next(2) == 0)
              yDir2 = -yDir2;
            Vector2 vector2_2 = WorldGen.digTunnel(vector2_1.X, vector2_1.Y, xDir2, yDir2, WorldGen.genRand.Next(30, 50), WorldGen.genRand.Next(3, 6));
            WorldGen.TileRunner((int) vector2_2.X, (int) vector2_2.Y, (double) WorldGen.genRand.Next(10, 20), WorldGen.genRand.Next(5, 10), -1);
          }
          break;
        case 1:
          int num2 = WorldGen.genRand.Next(15, 30);
          float xDir3 = (float) WorldGen.genRand.Next(100) * 0.01f;
          float yDir3 = 1f - xDir3;
          if (WorldGen.genRand.Next(2) == 0)
            xDir3 = -xDir3;
          if (WorldGen.genRand.Next(2) == 0)
            yDir3 = -yDir3;
          Vector2 vector2_3 = new Vector2((float) X, (float) Y);
          for (int index = 0; index < num2; ++index)
          {
            vector2_3 = WorldGen.digTunnel(vector2_3.X, vector2_3.Y, xDir3, yDir3, WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(2, 6), true);
            xDir3 += (float) WorldGen.genRand.Next(-20, 21) * 0.1f;
            yDir3 += (float) WorldGen.genRand.Next(-20, 21) * 0.1f;
            if ((double) xDir3 < -1.5)
              xDir3 = -1.5f;
            if ((double) xDir3 > 1.5)
              xDir3 = 1.5f;
            if ((double) yDir3 < -1.5)
              yDir3 = -1.5f;
            if ((double) yDir3 > 1.5)
              yDir3 = 1.5f;
          }
          break;
      }
    }

    public static Vector2 digTunnel(
      float X,
      float Y,
      float xDir,
      float yDir,
      int Steps,
      int Size,
      bool Wet = false)
    {
      float x = X;
      float y = Y;
      try
      {
        float num1 = 0.0f;
        float num2 = 0.0f;
        int num3 = Steps;
        float num4 = (float) Size;
        for (int index1 = 0; index1 < num3; ++index1)
        {
          for (int index2 = (int) ((double) x - (double) num4); (double) index2 <= (double) x + (double) num4; ++index2)
          {
            for (int index3 = (int) ((double) y - (double) num4); (double) index3 <= (double) y + (double) num4; ++index3)
            {
              if ((double) Math.Abs((float) index2 - x) + (double) Math.Abs((float) index3 - y) < (double) num4 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.005))
              {
                Main.tile[index2, index3].active = false;
                if (Wet)
                  Main.tile[index2, index3].liquid = byte.MaxValue;
              }
            }
          }
          num4 += (float) WorldGen.genRand.Next(-50, 51) * 0.03f;
          if ((double) num4 < (double) Size * 0.6)
            num4 = (float) Size * 0.6f;
          if ((double) num4 > (double) (Size * 2))
            num4 = (float) Size * 2f;
          num1 += (float) WorldGen.genRand.Next(-20, 21) * 0.01f;
          num2 += (float) WorldGen.genRand.Next(-20, 21) * 0.01f;
          if ((double) num1 < -1.0)
            num1 = -1f;
          if ((double) num1 > 1.0)
            num1 = 1f;
          if ((double) num2 < -1.0)
            num2 = -1f;
          if ((double) num2 > 1.0)
            num2 = 1f;
          x += (float) (((double) xDir + (double) num1) * 0.600000023841858);
          y += (float) (((double) yDir + (double) num2) * 0.600000023841858);
        }
      }
      catch
      {
      }
      return new Vector2(x, y);
    }

    public static void IslandHouse(int i, int j)
    {
      byte num1 = (byte) WorldGen.genRand.Next(45, 48);
      byte num2 = (byte) WorldGen.genRand.Next(10, 13);
      Vector2 vector2 = new Vector2((float) i, (float) j);
      int num3 = 1;
      if (WorldGen.genRand.Next(2) == 0)
        num3 = -1;
      int num4 = WorldGen.genRand.Next(7, 12);
      int num5 = WorldGen.genRand.Next(5, 7);
      vector2.X = (float) (i + (num4 + 2) * num3);
      for (int index = j - 15; index < j + 30; ++index)
      {
        if (Main.tile[(int) vector2.X, index].active)
        {
          vector2.Y = (float) (index - 1);
          break;
        }
      }
      vector2.X = (float) i;
      int num6 = (int) ((double) vector2.X - (double) num4 - 2.0);
      int num7 = (int) ((double) vector2.X + (double) num4 + 2.0);
      int num8 = (int) ((double) vector2.Y - (double) num5 - 2.0);
      int num9 = (int) ((double) vector2.Y + 2.0 + (double) WorldGen.genRand.Next(3, 5));
      if (num6 < 0)
        num6 = 0;
      if (num7 > Main.maxTilesX)
        num7 = Main.maxTilesX;
      if (num8 < 0)
        num8 = 0;
      if (num9 > Main.maxTilesY)
        num9 = Main.maxTilesY;
      for (int index1 = num6; index1 <= num7; ++index1)
      {
        for (int index2 = num8; index2 < num9; ++index2)
        {
          Main.tile[index1, index2].active = true;
          Main.tile[index1, index2].type = num1;
          Main.tile[index1, index2].wall = (byte) 0;
        }
      }
      int num10 = (int) ((double) vector2.X - (double) num4);
      int num11 = (int) ((double) vector2.X + (double) num4);
      int num12 = (int) ((double) vector2.Y - (double) num5);
      int num13 = (int) ((double) vector2.Y + 1.0);
      if (num10 < 0)
        num10 = 0;
      if (num11 > Main.maxTilesX)
        num11 = Main.maxTilesX;
      if (num12 < 0)
        num12 = 0;
      if (num13 > Main.maxTilesY)
        num13 = Main.maxTilesY;
      for (int index3 = num10; index3 <= num11; ++index3)
      {
        for (int index4 = num12; index4 < num13; ++index4)
        {
          if (Main.tile[index3, index4].wall == (byte) 0)
          {
            Main.tile[index3, index4].active = false;
            Main.tile[index3, index4].wall = num2;
          }
        }
      }
      int i1 = i + (num4 + 1) * num3;
      int y = (int) vector2.Y;
      for (int index = i1 - 2; index <= i1 + 2; ++index)
      {
        Main.tile[index, y].active = false;
        Main.tile[index, y - 1].active = false;
        Main.tile[index, y - 2].active = false;
      }
      WorldGen.PlaceTile(i1, y, 10, true);
      int contain = 0;
      int num14 = WorldGen.houseCount;
      if (num14 > 2)
        num14 = WorldGen.genRand.Next(3);
      switch (num14)
      {
        case 0:
          contain = 159;
          break;
        case 1:
          contain = 65;
          break;
        case 2:
          contain = 158;
          break;
      }
      WorldGen.AddBuriedChest(i, y - 3, contain, Style: 2);
      ++WorldGen.houseCount;
    }

    public static void Mountinater(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(80, 120);
      float num2 = (float) WorldGen.genRand.Next(40, 55);
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j + num2 / 2f;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.1f;
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        num1 -= (double) WorldGen.genRand.Next(4);
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > Main.maxTilesX)
          num4 = Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesY)
          num6 = Main.maxTilesY;
        double num7 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          for (int index2 = num5; index2 < num6; ++index2)
          {
            float num8 = Math.Abs((float) index1 - vector2_1.X);
            float num9 = Math.Abs((float) index2 - vector2_1.Y);
            if (Math.Sqrt((double) num8 * (double) num8 + (double) num9 * (double) num9) < num7 * 0.4 && !Main.tile[index1, index2].active)
            {
              Main.tile[index1, index2].active = true;
              Main.tile[index1, index2].type = (byte) 0;
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 0.5)
          vector2_2.X = 0.5f;
        if ((double) vector2_2.X < -0.5)
          vector2_2.X = -0.5f;
        if ((double) vector2_2.Y > -0.5)
          vector2_2.Y = -0.5f;
        if ((double) vector2_2.Y < -1.5)
          vector2_2.Y = -1.5f;
      }
    }

    public static void Lakinater(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(25, 50);
      double num2 = num1;
      float num3 = (float) WorldGen.genRand.Next(30, 80);
      if (WorldGen.genRand.Next(5) == 0)
      {
        num1 *= 1.5;
        num2 *= 1.5;
        num3 *= 1.2f;
      }
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j - num3 * 0.3f;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.1f;
      while (num1 > 0.0 && (double) num3 > 0.0)
      {
        if ((double) vector2_1.Y + num2 * 0.5 > Main.worldSurface)
          num3 = 0.0f;
        num1 -= (double) WorldGen.genRand.Next(3);
        --num3;
        int num4 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > Main.maxTilesX)
          num5 = Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > Main.maxTilesY)
          num7 = Main.maxTilesY;
        num2 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          for (int index2 = num6; index2 < num7; ++index2)
          {
            float num8 = Math.Abs((float) index1 - vector2_1.X);
            float num9 = Math.Abs((float) index2 - vector2_1.Y);
            if (Math.Sqrt((double) num8 * (double) num8 + (double) num9 * (double) num9) < num2 * 0.4)
            {
              if (Main.tile[index1, index2].active)
                Main.tile[index1, index2].liquid = byte.MaxValue;
              Main.tile[index1, index2].active = false;
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 0.5)
          vector2_2.X = 0.5f;
        if ((double) vector2_2.X < -0.5)
          vector2_2.X = -0.5f;
        if ((double) vector2_2.Y > 1.5)
          vector2_2.Y = 1.5f;
        if ((double) vector2_2.Y < 0.5)
          vector2_2.Y = 0.5f;
      }
    }

    public static void ShroomPatch(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(40, 70);
      double num2 = num1;
      float num3 = (float) WorldGen.genRand.Next(20, 30);
      if (WorldGen.genRand.Next(5) == 0)
      {
        num1 *= 1.5;
        double num4 = num2 * 1.5;
        num3 *= 1.2f;
      }
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j - num3 * 0.3f;
      Vector2 vector2_2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.1f;
      while (num1 > 0.0 && (double) num3 > 0.0)
      {
        num1 -= (double) WorldGen.genRand.Next(3);
        --num3;
        int num5 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num8 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num5 < 0)
          num5 = 0;
        if (num6 > Main.maxTilesX)
          num6 = Main.maxTilesX;
        if (num7 < 0)
          num7 = 0;
        if (num8 > Main.maxTilesY)
          num8 = Main.maxTilesY;
        double num9 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        for (int index1 = num5; index1 < num6; ++index1)
        {
          for (int index2 = num7; index2 < num8; ++index2)
          {
            float num10 = Math.Abs((float) index1 - vector2_1.X);
            float num11 = Math.Abs((float) (((double) index2 - (double) vector2_1.Y) * 2.29999995231628));
            if (Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11) < num9 * 0.4)
            {
              if ((double) index2 < (double) vector2_1.Y + num9 * 0.02)
              {
                if (Main.tile[index1, index2].type != (byte) 59)
                  Main.tile[index1, index2].active = false;
              }
              else
                Main.tile[index1, index2].type = (byte) 59;
              Main.tile[index1, index2].liquid = (byte) 0;
              Main.tile[index1, index2].lava = false;
            }
          }
        }
        vector2_1 += vector2_2;
        vector2_1.X += vector2_2.X;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y -= (float) WorldGen.genRand.Next(11) * 0.05f;
        if ((double) vector2_2.X > -0.5 && (double) vector2_2.X < 0.5)
          vector2_2.X = (double) vector2_2.X >= 0.0 ? 0.5f : -0.5f;
        if ((double) vector2_2.X > 2.0)
          vector2_2.X = 1f;
        if ((double) vector2_2.X < -2.0)
          vector2_2.X = -1f;
        if ((double) vector2_2.Y > 1.0)
          vector2_2.Y = 1f;
        if ((double) vector2_2.Y < -1.0)
          vector2_2.Y = -1f;
        for (int index = 0; index < 2; ++index)
        {
          int i1 = (int) vector2_1.X + WorldGen.genRand.Next(-20, 20);
          int j1;
          for (j1 = (int) vector2_1.Y + WorldGen.genRand.Next(0, 20); !Main.tile[i1, j1].active && Main.tile[i1, j1].type != (byte) 59; j1 = (int) vector2_1.Y + WorldGen.genRand.Next(0, 20))
            i1 = (int) vector2_1.X + WorldGen.genRand.Next(-20, 20);
          int num12 = WorldGen.genRand.Next(7, 10);
          int steps = WorldGen.genRand.Next(7, 10);
          WorldGen.TileRunner(i1, j1, (double) num12, steps, 59, speedY: 2f, noYChange: true);
          if (WorldGen.genRand.Next(3) == 0)
            WorldGen.TileRunner(i1, j1, (double) (num12 - 3), steps - 3, -1, speedY: 2f, noYChange: true);
        }
      }
    }

    public static void Cavinator(int i, int j, int steps)
    {
      double num1 = (double) WorldGen.genRand.Next(7, 15);
      int num2 = 1;
      if (WorldGen.genRand.Next(2) == 0)
        num2 = -1;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      int num3 = WorldGen.genRand.Next(20, 40);
      Vector2 vector2_2;
      vector2_2.Y = (float) WorldGen.genRand.Next(10, 20) * 0.01f;
      vector2_2.X = (float) num2;
      while (num3 > 0)
      {
        --num3;
        int num4 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > Main.maxTilesX)
          num5 = Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > Main.maxTilesY)
          num7 = Main.maxTilesY;
        double num8 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          for (int index2 = num6; index2 < num7; ++index2)
          {
            float num9 = Math.Abs((float) index1 - vector2_1.X);
            float num10 = Math.Abs((float) index2 - vector2_1.Y);
            if (Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10) < num8 * 0.4)
              Main.tile[index1, index2].active = false;
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > (double) num2 + 0.5)
          vector2_2.X = (float) num2 + 0.5f;
        if ((double) vector2_2.X < (double) num2 - 0.5)
          vector2_2.X = (float) num2 - 0.5f;
        if ((double) vector2_2.Y > 2.0)
          vector2_2.Y = 2f;
        if ((double) vector2_2.Y < 0.0)
          vector2_2.Y = 0.0f;
      }
      if (steps <= 0 || (double) (int) vector2_1.Y >= Main.rockLayer + 50.0)
        return;
      WorldGen.Cavinator((int) vector2_1.X, (int) vector2_1.Y, steps - 1);
    }

    public static void CaveOpenater(int i, int j)
    {
      double num1 = (double) WorldGen.genRand.Next(7, 12);
      int num2 = 1;
      if (WorldGen.genRand.Next(2) == 0)
        num2 = -1;
      Vector2 vector2_1;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      int num3 = 100;
      Vector2 vector2_2;
      vector2_2.Y = 0.0f;
      vector2_2.X = (float) num2;
      while (num3 > 0)
      {
        if (Main.tile[(int) vector2_1.X, (int) vector2_1.Y].wall == (byte) 0)
          num3 = 0;
        --num3;
        int num4 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > Main.maxTilesX)
          num5 = Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > Main.maxTilesY)
          num7 = Main.maxTilesY;
        double num8 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          for (int index2 = num6; index2 < num7; ++index2)
          {
            float num9 = Math.Abs((float) index1 - vector2_1.X);
            float num10 = Math.Abs((float) index2 - vector2_1.Y);
            if (Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10) < num8 * 0.4)
              Main.tile[index1, index2].active = false;
          }
        }
        vector2_1 += vector2_2;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > (double) num2 + 0.5)
          vector2_2.X = (float) num2 + 0.5f;
        if ((double) vector2_2.X < (double) num2 - 0.5)
          vector2_2.X = (float) num2 - 0.5f;
        if ((double) vector2_2.Y > 0.0)
          vector2_2.Y = 0.0f;
        if ((double) vector2_2.Y < -0.5)
          vector2_2.Y = -0.5f;
      }
    }

    public static void SquareTileFrame(int i, int j, bool resetFrame = true)
    {
      WorldGen.TileFrame(i - 1, j - 1);
      WorldGen.TileFrame(i - 1, j);
      WorldGen.TileFrame(i - 1, j + 1);
      WorldGen.TileFrame(i, j - 1);
      WorldGen.TileFrame(i, j, resetFrame);
      WorldGen.TileFrame(i, j + 1);
      WorldGen.TileFrame(i + 1, j - 1);
      WorldGen.TileFrame(i + 1, j);
      WorldGen.TileFrame(i + 1, j + 1);
    }

    public static void SquareWallFrame(int i, int j, bool resetFrame = true)
    {
      WorldGen.WallFrame(i - 1, j - 1);
      WorldGen.WallFrame(i - 1, j);
      WorldGen.WallFrame(i - 1, j + 1);
      WorldGen.WallFrame(i, j - 1);
      WorldGen.WallFrame(i, j, resetFrame);
      WorldGen.WallFrame(i, j + 1);
      WorldGen.WallFrame(i + 1, j - 1);
      WorldGen.WallFrame(i + 1, j);
      WorldGen.WallFrame(i + 1, j + 1);
    }

    public static void SectionTileFrame(int startX, int startY, int endX, int endY)
    {
      int num1 = startX * 200;
      int num2 = (endX + 1) * 200;
      int num3 = startY * 150;
      int num4 = (endY + 1) * 150;
      if (num1 < 1)
        num1 = 1;
      if (num3 < 1)
        num3 = 1;
      if (num1 > Main.maxTilesX - 2)
        num1 = Main.maxTilesX - 2;
      if (num3 > Main.maxTilesY - 2)
        num3 = Main.maxTilesY - 2;
      for (int i = num1 - 1; i < num2 + 1; ++i)
      {
        for (int j = num3 - 1; j < num4 + 1; ++j)
        {
          if (Main.tile[i, j] == null)
            Main.tile[i, j] = new Tile();
          WorldGen.TileFrame(i, j, true, true);
          WorldGen.WallFrame(i, j, true);
        }
      }
    }

    public static void RangeFrame(int startX, int startY, int endX, int endY)
    {
      int num1 = startX;
      int num2 = endX + 1;
      int num3 = startY;
      int num4 = endY + 1;
      for (int i = num1 - 1; i < num2 + 1; ++i)
      {
        for (int j = num3 - 1; j < num4 + 1; ++j)
        {
          WorldGen.TileFrame(i, j);
          WorldGen.WallFrame(i, j);
        }
      }
    }

    public static void WaterCheck()
    {
      Liquid.numLiquid = 0;
      LiquidBuffer.numLiquidBuffer = 0;
      for (int index1 = 1; index1 < Main.maxTilesX - 1; ++index1)
      {
        for (int index2 = Main.maxTilesY - 2; index2 > 0; --index2)
        {
          Main.tile[index1, index2].checkingLiquid = false;
          if (Main.tile[index1, index2].liquid > (byte) 0 && Main.tile[index1, index2].active && Main.tileSolid[(int) Main.tile[index1, index2].type] && !Main.tileSolidTop[(int) Main.tile[index1, index2].type])
            Main.tile[index1, index2].liquid = (byte) 0;
          else if (Main.tile[index1, index2].liquid > (byte) 0)
          {
            if (Main.tile[index1, index2].active)
            {
              if (Main.tileWaterDeath[(int) Main.tile[index1, index2].type] && (Main.tile[index1, index2].type != (byte) 4 || Main.tile[index1, index2].frameY != (short) 176))
                WorldGen.KillTile(index1, index2);
              if (Main.tile[index1, index2].lava && Main.tileLavaDeath[(int) Main.tile[index1, index2].type])
                WorldGen.KillTile(index1, index2);
            }
            if ((!Main.tile[index1, index2 + 1].active || !Main.tileSolid[(int) Main.tile[index1, index2 + 1].type] || Main.tileSolidTop[(int) Main.tile[index1, index2 + 1].type]) && Main.tile[index1, index2 + 1].liquid < byte.MaxValue)
            {
              if (Main.tile[index1, index2 + 1].liquid > (byte) 250)
                Main.tile[index1, index2 + 1].liquid = byte.MaxValue;
              else
                Liquid.AddWater(index1, index2);
            }
            if ((!Main.tile[index1 - 1, index2].active || !Main.tileSolid[(int) Main.tile[index1 - 1, index2].type] || Main.tileSolidTop[(int) Main.tile[index1 - 1, index2].type]) && (int) Main.tile[index1 - 1, index2].liquid != (int) Main.tile[index1, index2].liquid)
              Liquid.AddWater(index1, index2);
            else if ((!Main.tile[index1 + 1, index2].active || !Main.tileSolid[(int) Main.tile[index1 + 1, index2].type] || Main.tileSolidTop[(int) Main.tile[index1 + 1, index2].type]) && (int) Main.tile[index1 + 1, index2].liquid != (int) Main.tile[index1, index2].liquid)
              Liquid.AddWater(index1, index2);
            if (Main.tile[index1, index2].lava)
            {
              if (Main.tile[index1 - 1, index2].liquid > (byte) 0 && !Main.tile[index1 - 1, index2].lava)
                Liquid.AddWater(index1, index2);
              else if (Main.tile[index1 + 1, index2].liquid > (byte) 0 && !Main.tile[index1 + 1, index2].lava)
                Liquid.AddWater(index1, index2);
              else if (Main.tile[index1, index2 - 1].liquid > (byte) 0 && !Main.tile[index1, index2 - 1].lava)
                Liquid.AddWater(index1, index2);
              else if (Main.tile[index1, index2 + 1].liquid > (byte) 0 && !Main.tile[index1, index2 + 1].lava)
                Liquid.AddWater(index1, index2);
            }
          }
        }
      }
    }

    public static void EveryTileFrame()
    {
      WorldGen.noLiquidCheck = true;
      WorldGen.noTileActions = true;
      for (int i = 0; i < Main.maxTilesX; ++i)
      {
        float num = (float) i / (float) Main.maxTilesX;
        Main.statusText = Lang.gen[55] + " " + (object) (int) ((double) num * 100.0 + 1.0) + "%";
        for (int j = 0; j < Main.maxTilesY; ++j)
        {
          if (Main.tile[i, j].active)
            WorldGen.TileFrame(i, j, true);
          if (Main.tile[i, j].wall > (byte) 0)
            WorldGen.WallFrame(i, j, true);
        }
      }
      WorldGen.noLiquidCheck = false;
      WorldGen.noTileActions = false;
    }

    public static void PlantCheck(int i, int j)
    {
      int num1 = -1;
      int num2 = (int) Main.tile[i, j].type;
      int num3 = i - 1;
      int num4 = i + 1;
      int maxTilesX = Main.maxTilesX;
      int num5 = j - 1;
      if (j + 1 >= Main.maxTilesY)
        num1 = num2;
      if (i - 1 >= 0 && Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
      {
        int type1 = (int) Main.tile[i - 1, j].type;
      }
      if (i + 1 < Main.maxTilesX && Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
      {
        int type2 = (int) Main.tile[i + 1, j].type;
      }
      if (j - 1 >= 0 && Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
      {
        int type3 = (int) Main.tile[i, j - 1].type;
      }
      if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
        num1 = (int) Main.tile[i, j + 1].type;
      if (i - 1 >= 0 && j - 1 >= 0 && Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].active)
      {
        int type4 = (int) Main.tile[i - 1, j - 1].type;
      }
      if (i + 1 < Main.maxTilesX && j - 1 >= 0 && Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].active)
      {
        int type5 = (int) Main.tile[i + 1, j - 1].type;
      }
      if (i - 1 >= 0 && j + 1 < Main.maxTilesY && Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].active)
      {
        int type6 = (int) Main.tile[i - 1, j + 1].type;
      }
      if (i + 1 < Main.maxTilesX && j + 1 < Main.maxTilesY && Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].active)
      {
        int type7 = (int) Main.tile[i + 1, j + 1].type;
      }
      if ((num2 != 3 || num1 == 2 || num1 == 78) && (num2 != 24 || num1 == 23) && (num2 != 61 || num1 == 60) && (num2 != 71 || num1 == 70) && (num2 != 73 || num1 == 2 || num1 == 78) && (num2 != 74 || num1 == 60) && (num2 != 110 || num1 == 109) && (num2 != 113 || num1 == 109))
        return;
      switch (num1)
      {
        case 2:
          num2 = num2 != 113 ? 3 : 73;
          break;
        case 23:
          num2 = 24;
          if (Main.tile[i, j].frameX >= (short) 162)
          {
            Main.tile[i, j].frameX = (short) 126;
            break;
          }
          break;
        case 109:
          num2 = num2 != 73 ? 110 : 113;
          break;
      }
      if (num2 != (int) Main.tile[i, j].type)
        Main.tile[i, j].type = (byte) num2;
      else
        WorldGen.KillTile(i, j);
    }

    public static void WallFrame(int i, int j, bool resetFrame = false)
    {
      if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY || Main.tile[i, j] == null || Main.tile[i, j].wall <= (byte) 0)
        return;
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      int num4 = -1;
      int num5 = -1;
      int num6 = -1;
      int num7 = -1;
      int num8 = -1;
      int wall = (int) Main.tile[i, j].wall;
      if (wall == 0)
        return;
      int wallFrameX = (int) Main.tile[i, j].wallFrameX;
      int wallFrameY = (int) Main.tile[i, j].wallFrameY;
      Rectangle rectangle;
      rectangle.X = -1;
      rectangle.Y = -1;
      if (i - 1 < 0)
      {
        num1 = wall;
        num4 = wall;
        num6 = wall;
      }
      if (i + 1 >= Main.maxTilesX)
      {
        num3 = wall;
        num5 = wall;
        num8 = wall;
      }
      if (j - 1 < 0)
      {
        num1 = wall;
        num2 = wall;
        num3 = wall;
      }
      if (j + 1 >= Main.maxTilesY)
      {
        num6 = wall;
        num7 = wall;
        num8 = wall;
      }
      if (i - 1 >= 0 && Main.tile[i - 1, j] != null)
        num4 = (int) Main.tile[i - 1, j].wall;
      if (i + 1 < Main.maxTilesX && Main.tile[i + 1, j] != null)
        num5 = (int) Main.tile[i + 1, j].wall;
      if (j - 1 >= 0 && Main.tile[i, j - 1] != null)
        num2 = (int) Main.tile[i, j - 1].wall;
      if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1] != null)
        num7 = (int) Main.tile[i, j + 1].wall;
      if (i - 1 >= 0 && j - 1 >= 0 && Main.tile[i - 1, j - 1] != null)
        num1 = (int) Main.tile[i - 1, j - 1].wall;
      if (i + 1 < Main.maxTilesX && j - 1 >= 0 && Main.tile[i + 1, j - 1] != null)
        num3 = (int) Main.tile[i + 1, j - 1].wall;
      if (i - 1 >= 0 && j + 1 < Main.maxTilesY && Main.tile[i - 1, j + 1] != null)
        num6 = (int) Main.tile[i - 1, j + 1].wall;
      if (i + 1 < Main.maxTilesX && j + 1 < Main.maxTilesY && Main.tile[i + 1, j + 1] != null)
        num8 = (int) Main.tile[i + 1, j + 1].wall;
      if (wall == 2)
      {
        if (j == (int) Main.worldSurface)
        {
          num7 = wall;
          num6 = wall;
          num8 = wall;
        }
        else if (j >= (int) Main.worldSurface)
        {
          num7 = wall;
          num6 = wall;
          num8 = wall;
          num2 = wall;
          num1 = wall;
          num3 = wall;
          num4 = wall;
          num5 = wall;
        }
      }
      if (num7 > 0)
        num7 = wall;
      if (num6 > 0)
        num6 = wall;
      if (num8 > 0)
        num8 = wall;
      if (num2 > 0)
        num2 = wall;
      if (num1 > 0)
        num1 = wall;
      if (num3 > 0)
        num3 = wall;
      if (num4 > 0)
        num4 = wall;
      if (num5 > 0)
        num5 = wall;
      int num9;
      if (resetFrame)
      {
        num9 = WorldGen.genRand.Next(0, 3);
        Main.tile[i, j].wallFrameNumber = (byte) num9;
      }
      else
        num9 = (int) Main.tile[i, j].wallFrameNumber;
      if (rectangle.X < 0 || rectangle.Y < 0)
      {
        if (num2 == wall && num7 == wall && num4 == wall & num5 == wall)
        {
          if (num1 != wall && num3 != wall)
          {
            if (num9 == 0)
            {
              rectangle.X = 108;
              rectangle.Y = 18;
            }
            if (num9 == 1)
            {
              rectangle.X = 126;
              rectangle.Y = 18;
            }
            if (num9 == 2)
            {
              rectangle.X = 144;
              rectangle.Y = 18;
            }
          }
          else if (num6 != wall && num8 != wall)
          {
            if (num9 == 0)
            {
              rectangle.X = 108;
              rectangle.Y = 36;
            }
            if (num9 == 1)
            {
              rectangle.X = 126;
              rectangle.Y = 36;
            }
            if (num9 == 2)
            {
              rectangle.X = 144;
              rectangle.Y = 36;
            }
          }
          else if (num1 != wall && num6 != wall)
          {
            if (num9 == 0)
            {
              rectangle.X = 180;
              rectangle.Y = 0;
            }
            if (num9 == 1)
            {
              rectangle.X = 180;
              rectangle.Y = 18;
            }
            if (num9 == 2)
            {
              rectangle.X = 180;
              rectangle.Y = 36;
            }
          }
          else if (num3 != wall && num8 != wall)
          {
            if (num9 == 0)
            {
              rectangle.X = 198;
              rectangle.Y = 0;
            }
            if (num9 == 1)
            {
              rectangle.X = 198;
              rectangle.Y = 18;
            }
            if (num9 == 2)
            {
              rectangle.X = 198;
              rectangle.Y = 36;
            }
          }
          else
          {
            if (num9 == 0)
            {
              rectangle.X = 18;
              rectangle.Y = 18;
            }
            if (num9 == 1)
            {
              rectangle.X = 36;
              rectangle.Y = 18;
            }
            if (num9 == 2)
            {
              rectangle.X = 54;
              rectangle.Y = 18;
            }
          }
        }
        else if (num2 != wall && num7 == wall && num4 == wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 18;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 36;
            rectangle.Y = 0;
          }
          if (num9 == 2)
          {
            rectangle.X = 54;
            rectangle.Y = 0;
          }
        }
        else if (num2 == wall && num7 != wall && num4 == wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 18;
            rectangle.Y = 36;
          }
          if (num9 == 1)
          {
            rectangle.X = 36;
            rectangle.Y = 36;
          }
          if (num9 == 2)
          {
            rectangle.X = 54;
            rectangle.Y = 36;
          }
        }
        else if (num2 == wall && num7 == wall && num4 != wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 0;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 0;
            rectangle.Y = 18;
          }
          if (num9 == 2)
          {
            rectangle.X = 0;
            rectangle.Y = 36;
          }
        }
        else if (num2 == wall && num7 == wall && num4 == wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 72;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 72;
            rectangle.Y = 18;
          }
          if (num9 == 2)
          {
            rectangle.X = 72;
            rectangle.Y = 36;
          }
        }
        else if (num2 != wall && num7 == wall && num4 != wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 0;
            rectangle.Y = 54;
          }
          if (num9 == 1)
          {
            rectangle.X = 36;
            rectangle.Y = 54;
          }
          if (num9 == 2)
          {
            rectangle.X = 72;
            rectangle.Y = 54;
          }
        }
        else if (num2 != wall && num7 == wall && num4 == wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 18;
            rectangle.Y = 54;
          }
          if (num9 == 1)
          {
            rectangle.X = 54;
            rectangle.Y = 54;
          }
          if (num9 == 2)
          {
            rectangle.X = 90;
            rectangle.Y = 54;
          }
        }
        else if (num2 == wall && num7 != wall && num4 != wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 0;
            rectangle.Y = 72;
          }
          if (num9 == 1)
          {
            rectangle.X = 36;
            rectangle.Y = 72;
          }
          if (num9 == 2)
          {
            rectangle.X = 72;
            rectangle.Y = 72;
          }
        }
        else if (num2 == wall && num7 != wall && num4 == wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 18;
            rectangle.Y = 72;
          }
          if (num9 == 1)
          {
            rectangle.X = 54;
            rectangle.Y = 72;
          }
          if (num9 == 2)
          {
            rectangle.X = 90;
            rectangle.Y = 72;
          }
        }
        else if (num2 == wall && num7 == wall && num4 != wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 90;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 90;
            rectangle.Y = 18;
          }
          if (num9 == 2)
          {
            rectangle.X = 90;
            rectangle.Y = 36;
          }
        }
        else if (num2 != wall && num7 != wall && num4 == wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 108;
            rectangle.Y = 72;
          }
          if (num9 == 1)
          {
            rectangle.X = 126;
            rectangle.Y = 72;
          }
          if (num9 == 2)
          {
            rectangle.X = 144;
            rectangle.Y = 72;
          }
        }
        else if (num2 != wall && num7 == wall && num4 != wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 108;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 126;
            rectangle.Y = 0;
          }
          if (num9 == 2)
          {
            rectangle.X = 144;
            rectangle.Y = 0;
          }
        }
        else if (num2 == wall && num7 != wall && num4 != wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 108;
            rectangle.Y = 54;
          }
          if (num9 == 1)
          {
            rectangle.X = 126;
            rectangle.Y = 54;
          }
          if (num9 == 2)
          {
            rectangle.X = 144;
            rectangle.Y = 54;
          }
        }
        else if (num2 != wall && num7 != wall && num4 != wall & num5 == wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 162;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 162;
            rectangle.Y = 18;
          }
          if (num9 == 2)
          {
            rectangle.X = 162;
            rectangle.Y = 36;
          }
        }
        else if (num2 != wall && num7 != wall && num4 == wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 216;
            rectangle.Y = 0;
          }
          if (num9 == 1)
          {
            rectangle.X = 216;
            rectangle.Y = 18;
          }
          if (num9 == 2)
          {
            rectangle.X = 216;
            rectangle.Y = 36;
          }
        }
        else if (num2 != wall && num7 != wall && num4 != wall & num5 != wall)
        {
          if (num9 == 0)
          {
            rectangle.X = 162;
            rectangle.Y = 54;
          }
          if (num9 == 1)
          {
            rectangle.X = 180;
            rectangle.Y = 54;
          }
          if (num9 == 2)
          {
            rectangle.X = 198;
            rectangle.Y = 54;
          }
        }
      }
      if (rectangle.X <= -1 || rectangle.Y <= -1)
      {
        if (num9 <= 0)
        {
          rectangle.X = 18;
          rectangle.Y = 18;
        }
        if (num9 == 1)
        {
          rectangle.X = 36;
          rectangle.Y = 18;
        }
        if (num9 >= 2)
        {
          rectangle.X = 54;
          rectangle.Y = 18;
        }
      }
      Main.tile[i, j].wallFrameX = (byte) rectangle.X;
      Main.tile[i, j].wallFrameY = (byte) rectangle.Y;
    }

    public static void TileFrame(int i, int j, bool resetFrame = false, bool noBreak = false)
    {
      try
      {
        if (i <= 5 || j <= 5 || i >= Main.maxTilesX - 5 || j >= Main.maxTilesY - 5 || Main.tile[i, j] == null)
          return;
        if (Main.tile[i, j].liquid > (byte) 0 && Main.netMode != 1 && !WorldGen.noLiquidCheck)
          Liquid.AddWater(i, j);
        if (!Main.tile[i, j].active || noBreak && Main.tileFrameImportant[(int) Main.tile[i, j].type] && Main.tile[i, j].type != (byte) 4)
          return;
        int type1 = (int) Main.tile[i, j].type;
        if (Main.tileStone[type1])
          type1 = 1;
        int frameX1 = (int) Main.tile[i, j].frameX;
        int frameY1 = (int) Main.tile[i, j].frameY;
        Rectangle rectangle = new Rectangle(-1, -1, 0, 0);
        if (Main.tileFrameImportant[(int) Main.tile[i, j].type])
        {
          switch (type1)
          {
            case 4:
              short num1 = 0;
              if (Main.tile[i, j].frameX >= (short) 66)
                num1 = (short) 66;
              int index1 = -1;
              int index2 = -1;
              int index3 = -1;
              int num2 = -1;
              int num3 = -1;
              int num4 = -1;
              int num5 = -1;
              if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
              {
                int type2 = (int) Main.tile[i, j - 1].type;
              }
              if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
                index1 = (int) Main.tile[i, j + 1].type;
              if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
                index2 = (int) Main.tile[i - 1, j].type;
              if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
                index3 = (int) Main.tile[i + 1, j].type;
              if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].active)
                num2 = (int) Main.tile[i - 1, j + 1].type;
              if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].active)
                num3 = (int) Main.tile[i + 1, j + 1].type;
              if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].active)
                num4 = (int) Main.tile[i - 1, j - 1].type;
              if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].active)
                num5 = (int) Main.tile[i + 1, j - 1].type;
              if (index1 >= 0 && Main.tileSolid[index1] && !Main.tileNoAttach[index1])
              {
                Main.tile[i, j].frameX = num1;
                break;
              }
              if (index2 >= 0 && Main.tileSolid[index2] && !Main.tileNoAttach[index2] || index2 == 124 || index2 == 5 && num4 == 5 && num2 == 5)
              {
                Main.tile[i, j].frameX = (short) (22 + (int) num1);
                break;
              }
              if (index3 >= 0 && Main.tileSolid[index3] && !Main.tileNoAttach[index3] || index3 == 124 || index3 == 5 && num5 == 5 && num3 == 5)
              {
                Main.tile[i, j].frameX = (short) (44 + (int) num1);
                break;
              }
              WorldGen.KillTile(i, j);
              break;
            case 136:
              int index4 = -1;
              int index5 = -1;
              int index6 = -1;
              if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
              {
                int type3 = (int) Main.tile[i, j - 1].type;
              }
              if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
                index4 = (int) Main.tile[i, j + 1].type;
              if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
                index5 = (int) Main.tile[i - 1, j].type;
              if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
                index6 = (int) Main.tile[i + 1, j].type;
              if (index4 >= 0 && Main.tileSolid[index4] && !Main.tileNoAttach[index4])
              {
                Main.tile[i, j].frameX = (short) 0;
                break;
              }
              if (index5 >= 0 && Main.tileSolid[index5] && !Main.tileNoAttach[index5] || index5 == 124 || index5 == 5)
              {
                Main.tile[i, j].frameX = (short) 18;
                break;
              }
              if (index6 >= 0 && Main.tileSolid[index6] && !Main.tileNoAttach[index6] || index6 == 124 || index6 == 5)
              {
                Main.tile[i, j].frameX = (short) 36;
                break;
              }
              WorldGen.KillTile(i, j);
              break;
            default:
              if (type1 == 129 || type1 == 149)
              {
                int index7 = -1;
                int index8 = -1;
                int index9 = -1;
                int index10 = -1;
                if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
                  index8 = (int) Main.tile[i, j - 1].type;
                if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
                  index7 = (int) Main.tile[i, j + 1].type;
                if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
                  index9 = (int) Main.tile[i - 1, j].type;
                if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
                  index10 = (int) Main.tile[i + 1, j].type;
                if (index7 >= 0 && Main.tileSolid[index7] && !Main.tileSolidTop[index7])
                {
                  Main.tile[i, j].frameY = (short) 0;
                  break;
                }
                if (index9 >= 0 && Main.tileSolid[index9] && !Main.tileSolidTop[index9])
                {
                  Main.tile[i, j].frameY = (short) 54;
                  break;
                }
                if (index10 >= 0 && Main.tileSolid[index10] && !Main.tileSolidTop[index10])
                {
                  Main.tile[i, j].frameY = (short) 36;
                  break;
                }
                if (index8 >= 0 && Main.tileSolid[index8] && !Main.tileSolidTop[index8])
                {
                  Main.tile[i, j].frameY = (short) 18;
                  break;
                }
                WorldGen.KillTile(i, j);
                break;
              }
              if (type1 == 3 || type1 == 24 || type1 == 61 || type1 == 71 || type1 == 73 || type1 == 74 || type1 == 110 || type1 == 113)
              {
                WorldGen.PlantCheck(i, j);
                break;
              }
              if (type1 == 12 || type1 == 31)
              {
                WorldGen.CheckOrb(i, j, type1);
                break;
              }
              switch (type1)
              {
                case 10:
                  if (WorldGen.destroyObject)
                    return;
                  int frameY2 = (int) Main.tile[i, j].frameY;
                  int j1 = j;
                  bool flag1 = false;
                  if (frameY2 == 0)
                    j1 = j;
                  if (frameY2 == 18)
                    j1 = j - 1;
                  if (frameY2 == 36)
                    j1 = j - 2;
                  if (Main.tile[i, j1 - 1] == null)
                    Main.tile[i, j1 - 1] = new Tile();
                  if (Main.tile[i, j1 + 3] == null)
                    Main.tile[i, j1 + 3] = new Tile();
                  if (Main.tile[i, j1 + 2] == null)
                    Main.tile[i, j1 + 2] = new Tile();
                  if (Main.tile[i, j1 + 1] == null)
                    Main.tile[i, j1 + 1] = new Tile();
                  if (Main.tile[i, j1] == null)
                    Main.tile[i, j1] = new Tile();
                  if (!Main.tile[i, j1 - 1].active || !Main.tileSolid[(int) Main.tile[i, j1 - 1].type])
                    flag1 = true;
                  if (!Main.tile[i, j1 + 3].active || !Main.tileSolid[(int) Main.tile[i, j1 + 3].type])
                    flag1 = true;
                  if (!Main.tile[i, j1].active || (int) Main.tile[i, j1].type != type1)
                    flag1 = true;
                  if (!Main.tile[i, j1 + 1].active || (int) Main.tile[i, j1 + 1].type != type1)
                    flag1 = true;
                  if (!Main.tile[i, j1 + 2].active || (int) Main.tile[i, j1 + 2].type != type1)
                    flag1 = true;
                  if (flag1)
                  {
                    WorldGen.destroyObject = true;
                    WorldGen.KillTile(i, j1);
                    WorldGen.KillTile(i, j1 + 1);
                    WorldGen.KillTile(i, j1 + 2);
                    Item.NewItem(i * 16, j * 16, 16, 16, 25);
                  }
                  WorldGen.destroyObject = false;
                  return;
                case 11:
                  if (WorldGen.destroyObject)
                    return;
                  int num6 = 0;
                  int index11 = i;
                  int num7 = j;
                  int frameX2 = (int) Main.tile[i, j].frameX;
                  int frameY3 = (int) Main.tile[i, j].frameY;
                  bool flag2 = false;
                  switch (frameX2)
                  {
                    case 0:
                      index11 = i;
                      num6 = 1;
                      break;
                    case 18:
                      index11 = i - 1;
                      num6 = 1;
                      break;
                    case 36:
                      index11 = i + 1;
                      num6 = -1;
                      break;
                    case 54:
                      index11 = i;
                      num6 = -1;
                      break;
                  }
                  switch (frameY3)
                  {
                    case 0:
                      num7 = j;
                      break;
                    case 18:
                      num7 = j - 1;
                      break;
                    case 36:
                      num7 = j - 2;
                      break;
                  }
                  if (Main.tile[index11, num7 + 3] == null)
                    Main.tile[index11, num7 + 3] = new Tile();
                  if (Main.tile[index11, num7 - 1] == null)
                    Main.tile[index11, num7 - 1] = new Tile();
                  if (!Main.tile[index11, num7 - 1].active || !Main.tileSolid[(int) Main.tile[index11, num7 - 1].type] || !Main.tile[index11, num7 + 3].active || !Main.tileSolid[(int) Main.tile[index11, num7 + 3].type])
                  {
                    flag2 = true;
                    WorldGen.destroyObject = true;
                    Item.NewItem(i * 16, j * 16, 16, 16, 25);
                  }
                  int num8 = index11;
                  if (num6 == -1)
                    num8 = index11 - 1;
                  for (int i1 = num8; i1 < num8 + 2; ++i1)
                  {
                    for (int j2 = num7; j2 < num7 + 3; ++j2)
                    {
                      if (!flag2 && (Main.tile[i1, j2].type != (byte) 11 || !Main.tile[i1, j2].active))
                      {
                        WorldGen.destroyObject = true;
                        Item.NewItem(i * 16, j * 16, 16, 16, 25);
                        flag2 = true;
                        i1 = num8;
                        j2 = num7;
                      }
                      if (flag2)
                        WorldGen.KillTile(i1, j2);
                    }
                  }
                  WorldGen.destroyObject = false;
                  return;
                default:
                  if (type1 == 34 || type1 == 35 || type1 == 36 || type1 == 106)
                  {
                    WorldGen.Check3x3(i, j, (int) (byte) type1);
                    return;
                  }
                  if (type1 == 15 || type1 == 20)
                  {
                    WorldGen.Check1x2(i, j, (byte) type1);
                    return;
                  }
                  if (type1 == 14 || type1 == 17 || type1 == 26 || type1 == 77 || type1 == 86 || type1 == 87 || type1 == 88 || type1 == 89 || type1 == 114 || type1 == 133)
                  {
                    WorldGen.Check3x2(i, j, (int) (byte) type1);
                    return;
                  }
                  if (type1 == 135 || type1 == 144 || type1 == 141)
                  {
                    WorldGen.Check1x1(i, j, type1);
                    return;
                  }
                  if (type1 == 16 || type1 == 18 || type1 == 29 || type1 == 103 || type1 == 134)
                  {
                    WorldGen.Check2x1(i, j, (byte) type1);
                    return;
                  }
                  if (type1 == 13 || type1 == 33 || type1 == 50 || type1 == 78)
                  {
                    WorldGen.CheckOnTable1x1(i, j, (int) (byte) type1);
                    return;
                  }
                  switch (type1)
                  {
                    case 21:
                      WorldGen.CheckChest(i, j, (int) (byte) type1);
                      return;
                    case 27:
                      WorldGen.CheckSunflower(i, j);
                      return;
                    case 28:
                      WorldGen.CheckPot(i, j);
                      return;
                    case 128:
                      WorldGen.CheckMan(i, j);
                      return;
                    default:
                      if (type1 == 132 || type1 == 138 || type1 == 142 || type1 == 143)
                      {
                        WorldGen.Check2x2(i, j, type1);
                        return;
                      }
                      if (type1 == 91)
                      {
                        WorldGen.CheckBanner(i, j, (byte) type1);
                        return;
                      }
                      if (type1 == 139)
                      {
                        WorldGen.CheckMB(i, j, (int) (byte) type1);
                        return;
                      }
                      if (type1 == 92 || type1 == 93)
                      {
                        WorldGen.Check1xX(i, j, (byte) type1);
                        return;
                      }
                      if (type1 == 104 || type1 == 105)
                      {
                        WorldGen.Check2xX(i, j, (byte) type1);
                        return;
                      }
                      if (type1 == 101 || type1 == 102)
                      {
                        WorldGen.Check3x4(i, j, (int) (byte) type1);
                        return;
                      }
                      if (type1 == 42)
                      {
                        WorldGen.Check1x2Top(i, j, (byte) type1);
                        return;
                      }
                      if (type1 == 55 || type1 == 85)
                      {
                        WorldGen.CheckSign(i, j, type1);
                        return;
                      }
                      if (type1 == 79 || type1 == 90)
                      {
                        WorldGen.Check4x2(i, j, type1);
                        return;
                      }
                      if (type1 == 85 || type1 == 94 || type1 == 95 || type1 == 96 || type1 == 97 || type1 == 98 || type1 == 99 || type1 == 100 || type1 == 125 || type1 == 126)
                      {
                        WorldGen.Check2x2(i, j, type1);
                        return;
                      }
                      if (type1 == 81)
                      {
                        int index12 = -1;
                        int num9 = -1;
                        int num10 = -1;
                        int num11 = -1;
                        if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
                          num9 = (int) Main.tile[i, j - 1].type;
                        if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
                          index12 = (int) Main.tile[i, j + 1].type;
                        if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
                          num10 = (int) Main.tile[i - 1, j].type;
                        if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
                          num11 = (int) Main.tile[i + 1, j].type;
                        if (num10 != -1 || num9 != -1 || num11 != -1)
                        {
                          WorldGen.KillTile(i, j);
                          return;
                        }
                        if (index12 >= 0 && Main.tileSolid[index12])
                          return;
                        WorldGen.KillTile(i, j);
                        return;
                      }
                      if (Main.tileAlch[type1])
                      {
                        WorldGen.CheckAlch(i, j);
                        return;
                      }
                      switch (type1)
                      {
                        case 5:
                          WorldGen.CheckTree(i, j);
                          return;
                        case 72:
                          int num12 = -1;
                          int num13 = -1;
                          if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
                            num13 = (int) Main.tile[i, j - 1].type;
                          if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
                            num12 = (int) Main.tile[i, j + 1].type;
                          if (num12 != type1 && num12 != 70)
                          {
                            WorldGen.KillTile(i, j);
                            return;
                          }
                          if (num13 == type1 || Main.tile[i, j].frameX != (short) 0)
                            return;
                          Main.tile[i, j].frameNumber = (byte) WorldGen.genRand.Next(3);
                          if (Main.tile[i, j].frameNumber == (byte) 0)
                          {
                            Main.tile[i, j].frameX = (short) 18;
                            Main.tile[i, j].frameY = (short) 0;
                          }
                          if (Main.tile[i, j].frameNumber == (byte) 1)
                          {
                            Main.tile[i, j].frameX = (short) 18;
                            Main.tile[i, j].frameY = (short) 18;
                          }
                          if (Main.tile[i, j].frameNumber != (byte) 2)
                            return;
                          Main.tile[i, j].frameX = (short) 18;
                          Main.tile[i, j].frameY = (short) 36;
                          return;
                        default:
                          return;
                      }
                  }
              }
          }
        }
        else
        {
          int index13 = -1;
          int index14 = -1;
          int index15 = -1;
          int index16 = -1;
          int index17 = -1;
          int index18 = -1;
          int index19 = -1;
          int index20 = -1;
          if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].active)
            index16 = !Main.tileStone[(int) Main.tile[i - 1, j].type] ? (int) Main.tile[i - 1, j].type : 1;
          if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].active)
            index17 = !Main.tileStone[(int) Main.tile[i + 1, j].type] ? (int) Main.tile[i + 1, j].type : 1;
          if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active)
            index14 = !Main.tileStone[(int) Main.tile[i, j - 1].type] ? (int) Main.tile[i, j - 1].type : 1;
          if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].active)
            index19 = !Main.tileStone[(int) Main.tile[i, j + 1].type] ? (int) Main.tile[i, j + 1].type : 1;
          if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].active)
            index13 = !Main.tileStone[(int) Main.tile[i - 1, j - 1].type] ? (int) Main.tile[i - 1, j - 1].type : 1;
          if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].active)
            index15 = !Main.tileStone[(int) Main.tile[i + 1, j - 1].type] ? (int) Main.tile[i + 1, j - 1].type : 1;
          if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].active)
            index18 = !Main.tileStone[(int) Main.tile[i - 1, j + 1].type] ? (int) Main.tile[i - 1, j + 1].type : 1;
          if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].active)
            index20 = !Main.tileStone[(int) Main.tile[i + 1, j + 1].type] ? (int) Main.tile[i + 1, j + 1].type : 1;
          if (!Main.tileSolid[type1])
          {
            if (type1 == 49)
            {
              WorldGen.CheckOnTable1x1(i, j, (int) (byte) type1);
              return;
            }
            if (type1 == 80)
            {
              WorldGen.CactusFrame(i, j);
              return;
            }
          }
          else if (type1 == 19)
          {
            if (index17 >= 0 && !Main.tileSolid[index17])
              index17 = -1;
            if (index16 >= 0 && !Main.tileSolid[index16])
              index16 = -1;
            if (index16 == type1 && index17 == type1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 0;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 0;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 0;
                rectangle.Y = 36;
              }
            }
            else if (index16 == type1 && index17 == -1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 18;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 18;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 18;
                rectangle.Y = 36;
              }
            }
            else if (index16 == -1 && index17 == type1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 36;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 36;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 36;
                rectangle.Y = 36;
              }
            }
            else if (index16 != type1 && index17 == type1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 54;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 54;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 54;
                rectangle.Y = 36;
              }
            }
            else if (index16 == type1 && index17 != type1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 72;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 72;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 72;
                rectangle.Y = 36;
              }
            }
            else if (index16 != type1 && index16 != -1 && index17 == -1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 108;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 108;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 108;
                rectangle.Y = 36;
              }
            }
            else if (index16 == -1 && index17 != type1 && index17 != -1)
            {
              if (Main.tile[i, j].frameNumber == (byte) 0)
              {
                rectangle.X = 126;
                rectangle.Y = 0;
              }
              else if (Main.tile[i, j].frameNumber == (byte) 1)
              {
                rectangle.X = 126;
                rectangle.Y = 18;
              }
              else
              {
                rectangle.X = 126;
                rectangle.Y = 36;
              }
            }
            else if (Main.tile[i, j].frameNumber == (byte) 0)
            {
              rectangle.X = 90;
              rectangle.Y = 0;
            }
            else if (Main.tile[i, j].frameNumber == (byte) 1)
            {
              rectangle.X = 90;
              rectangle.Y = 18;
            }
            else
            {
              rectangle.X = 90;
              rectangle.Y = 36;
            }
          }
          WorldGen.mergeUp = false;
          WorldGen.mergeDown = false;
          WorldGen.mergeLeft = false;
          WorldGen.mergeRight = false;
          int num14;
          if (resetFrame)
          {
            num14 = WorldGen.genRand.Next(0, 3);
            Main.tile[i, j].frameNumber = (byte) num14;
          }
          else
            num14 = (int) Main.tile[i, j].frameNumber;
          if (type1 == 0)
          {
            if (index14 >= 0 && Main.tileMergeDirt[index14])
            {
              WorldGen.TileFrame(i, j - 1);
              if (WorldGen.mergeDown)
                index14 = type1;
            }
            if (index19 >= 0 && Main.tileMergeDirt[index19])
            {
              WorldGen.TileFrame(i, j + 1);
              if (WorldGen.mergeUp)
                index19 = type1;
            }
            if (index16 >= 0 && Main.tileMergeDirt[index16])
            {
              WorldGen.TileFrame(i - 1, j);
              if (WorldGen.mergeRight)
                index16 = type1;
            }
            if (index17 >= 0 && Main.tileMergeDirt[index17])
            {
              WorldGen.TileFrame(i + 1, j);
              if (WorldGen.mergeLeft)
                index17 = type1;
            }
            if (index14 == 2 || index14 == 23 || index14 == 109)
              index14 = type1;
            if (index19 == 2 || index19 == 23 || index19 == 109)
              index19 = type1;
            if (index16 == 2 || index16 == 23 || index16 == 109)
              index16 = type1;
            if (index17 == 2 || index17 == 23 || index17 == 109)
              index17 = type1;
            if (index13 >= 0 && Main.tileMergeDirt[index13])
              index13 = type1;
            else if (index13 == 2 || index13 == 23 || index13 == 109)
              index13 = type1;
            if (index15 >= 0 && Main.tileMergeDirt[index15])
              index15 = type1;
            else if (index15 == 2 || index15 == 23 || index15 == 109)
              index15 = type1;
            if (index18 >= 0 && Main.tileMergeDirt[index18])
              index18 = type1;
            else if (index18 == 2 || index18 == 23 || index15 == 109)
              index18 = type1;
            if (index20 >= 0 && Main.tileMergeDirt[index20])
              index20 = type1;
            else if (index20 == 2 || index20 == 23 || index20 == 109)
              index20 = type1;
            if ((double) j < Main.rockLayer)
            {
              if (index14 == 59)
                index14 = -2;
              if (index19 == 59)
                index19 = -2;
              if (index16 == 59)
                index16 = -2;
              if (index17 == 59)
                index17 = -2;
              if (index13 == 59)
                index13 = -2;
              if (index15 == 59)
                index15 = -2;
              if (index18 == 59)
                index18 = -2;
              if (index20 == 59)
                index20 = -2;
            }
          }
          else if (Main.tileMergeDirt[type1])
          {
            if (index14 == 0)
              index14 = -2;
            if (index19 == 0)
              index19 = -2;
            if (index16 == 0)
              index16 = -2;
            if (index17 == 0)
              index17 = -2;
            if (index13 == 0)
              index13 = -2;
            if (index15 == 0)
              index15 = -2;
            if (index18 == 0)
              index18 = -2;
            if (index20 == 0)
              index20 = -2;
            if (type1 == 1)
            {
              if ((double) j > Main.rockLayer)
              {
                if (index14 == 59)
                {
                  WorldGen.TileFrame(i, j - 1);
                  if (WorldGen.mergeDown)
                    index14 = type1;
                }
                if (index19 == 59)
                {
                  WorldGen.TileFrame(i, j + 1);
                  if (WorldGen.mergeUp)
                    index19 = type1;
                }
                if (index16 == 59)
                {
                  WorldGen.TileFrame(i - 1, j);
                  if (WorldGen.mergeRight)
                    index16 = type1;
                }
                if (index17 == 59)
                {
                  WorldGen.TileFrame(i + 1, j);
                  if (WorldGen.mergeLeft)
                    index17 = type1;
                }
                if (index13 == 59)
                  index13 = type1;
                if (index15 == 59)
                  index15 = type1;
                if (index18 == 59)
                  index18 = type1;
                if (index20 == 59)
                  index20 = type1;
              }
              if (index14 == 57)
              {
                WorldGen.TileFrame(i, j - 1);
                if (WorldGen.mergeDown)
                  index14 = type1;
              }
              if (index19 == 57)
              {
                WorldGen.TileFrame(i, j + 1);
                if (WorldGen.mergeUp)
                  index19 = type1;
              }
              if (index16 == 57)
              {
                WorldGen.TileFrame(i - 1, j);
                if (WorldGen.mergeRight)
                  index16 = type1;
              }
              if (index17 == 57)
              {
                WorldGen.TileFrame(i + 1, j);
                if (WorldGen.mergeLeft)
                  index17 = type1;
              }
              if (index13 == 57)
                index13 = type1;
              if (index15 == 57)
                index15 = type1;
              if (index18 == 57)
                index18 = type1;
              if (index20 == 57)
                index20 = type1;
            }
          }
          else
          {
            switch (type1)
            {
              case 32:
                if (index19 == 23)
                {
                  index19 = type1;
                  break;
                }
                break;
              case 51:
                if (index14 > -1 && !Main.tileNoAttach[index14])
                  index14 = type1;
                if (index19 > -1 && !Main.tileNoAttach[index19])
                  index19 = type1;
                if (index16 > -1 && !Main.tileNoAttach[index16])
                  index16 = type1;
                if (index17 > -1 && !Main.tileNoAttach[index17])
                  index17 = type1;
                if (index13 > -1 && !Main.tileNoAttach[index13])
                  index13 = type1;
                if (index15 > -1 && !Main.tileNoAttach[index15])
                  index15 = type1;
                if (index18 > -1 && !Main.tileNoAttach[index18])
                  index18 = type1;
                if (index20 > -1 && !Main.tileNoAttach[index20])
                {
                  index20 = type1;
                  break;
                }
                break;
              case 57:
                if (index14 == 1)
                  index14 = -2;
                if (index19 == 1)
                  index19 = -2;
                if (index16 == 1)
                  index16 = -2;
                if (index17 == 1)
                  index17 = -2;
                if (index13 == 1)
                  index13 = -2;
                if (index15 == 1)
                  index15 = -2;
                if (index18 == 1)
                  index18 = -2;
                if (index20 == 1)
                  index20 = -2;
                if (index14 == 58 || index14 == 76 || index14 == 75)
                {
                  WorldGen.TileFrame(i, j - 1);
                  if (WorldGen.mergeDown)
                    index14 = type1;
                }
                if (index19 == 58 || index19 == 76 || index19 == 75)
                {
                  WorldGen.TileFrame(i, j + 1);
                  if (WorldGen.mergeUp)
                    index19 = type1;
                }
                if (index16 == 58 || index16 == 76 || index16 == 75)
                {
                  WorldGen.TileFrame(i - 1, j);
                  if (WorldGen.mergeRight)
                    index16 = type1;
                }
                if (index17 == 58 || index17 == 76 || index17 == 75)
                {
                  WorldGen.TileFrame(i + 1, j);
                  if (WorldGen.mergeLeft)
                    index17 = type1;
                }
                if (index13 == 58 || index13 == 76 || index13 == 75)
                  index13 = type1;
                if (index15 == 58 || index15 == 76 || index15 == 75)
                  index15 = type1;
                if (index18 == 58 || index18 == 76 || index18 == 75)
                  index18 = type1;
                if (index20 == 58 || index20 == 76 || index20 == 75)
                {
                  index20 = type1;
                  break;
                }
                break;
              case 58:
              case 75:
              case 76:
                if (index14 == 57)
                  index14 = -2;
                if (index19 == 57)
                  index19 = -2;
                if (index16 == 57)
                  index16 = -2;
                if (index17 == 57)
                  index17 = -2;
                if (index13 == 57)
                  index13 = -2;
                if (index15 == 57)
                  index15 = -2;
                if (index18 == 57)
                  index18 = -2;
                if (index20 == 57)
                {
                  index20 = -2;
                  break;
                }
                break;
              case 59:
                if ((double) j > Main.rockLayer)
                {
                  if (index14 == 1)
                    index14 = -2;
                  if (index19 == 1)
                    index19 = -2;
                  if (index16 == 1)
                    index16 = -2;
                  if (index17 == 1)
                    index17 = -2;
                  if (index13 == 1)
                    index13 = -2;
                  if (index15 == 1)
                    index15 = -2;
                  if (index18 == 1)
                    index18 = -2;
                  if (index20 == 1)
                    index20 = -2;
                }
                if (index14 == 60)
                  index14 = type1;
                if (index19 == 60)
                  index19 = type1;
                if (index16 == 60)
                  index16 = type1;
                if (index17 == 60)
                  index17 = type1;
                if (index13 == 60)
                  index13 = type1;
                if (index15 == 60)
                  index15 = type1;
                if (index18 == 60)
                  index18 = type1;
                if (index20 == 60)
                  index20 = type1;
                if (index14 == 70)
                  index14 = type1;
                if (index19 == 70)
                  index19 = type1;
                if (index16 == 70)
                  index16 = type1;
                if (index17 == 70)
                  index17 = type1;
                if (index13 == 70)
                  index13 = type1;
                if (index15 == 70)
                  index15 = type1;
                if (index18 == 70)
                  index18 = type1;
                if (index20 == 70)
                  index20 = type1;
                if ((double) j < Main.rockLayer)
                {
                  if (index14 == 0)
                  {
                    WorldGen.TileFrame(i, j - 1);
                    if (WorldGen.mergeDown)
                      index14 = type1;
                  }
                  if (index19 == 0)
                  {
                    WorldGen.TileFrame(i, j + 1);
                    if (WorldGen.mergeUp)
                      index19 = type1;
                  }
                  if (index16 == 0)
                  {
                    WorldGen.TileFrame(i - 1, j);
                    if (WorldGen.mergeRight)
                      index16 = type1;
                  }
                  if (index17 == 0)
                  {
                    WorldGen.TileFrame(i + 1, j);
                    if (WorldGen.mergeLeft)
                      index17 = type1;
                  }
                  if (index13 == 0)
                    index13 = type1;
                  if (index15 == 0)
                    index15 = type1;
                  if (index18 == 0)
                    index18 = type1;
                  if (index20 == 0)
                  {
                    index20 = type1;
                    break;
                  }
                  break;
                }
                break;
              case 69:
                if (index19 == 60)
                {
                  index19 = type1;
                  break;
                }
                break;
            }
          }
          bool flag3 = false;
          if (type1 == 2 || type1 == 23 || type1 == 60 || type1 == 70 || type1 == 109)
          {
            flag3 = true;
            if (index14 > -1 && !Main.tileSolid[index14] && index14 != type1)
              index14 = -1;
            if (index19 > -1 && !Main.tileSolid[index19] && index19 != type1)
              index19 = -1;
            if (index16 > -1 && !Main.tileSolid[index16] && index16 != type1)
              index16 = -1;
            if (index17 > -1 && !Main.tileSolid[index17] && index17 != type1)
              index17 = -1;
            if (index13 > -1 && !Main.tileSolid[index13] && index13 != type1)
              index13 = -1;
            if (index15 > -1 && !Main.tileSolid[index15] && index15 != type1)
              index15 = -1;
            if (index18 > -1 && !Main.tileSolid[index18] && index18 != type1)
              index18 = -1;
            if (index20 > -1 && !Main.tileSolid[index20] && index20 != type1)
              index20 = -1;
            int num15 = 0;
            switch (type1)
            {
              case 2:
                if (index14 == 23)
                  index14 = num15;
                if (index19 == 23)
                  index19 = num15;
                if (index16 == 23)
                  index16 = num15;
                if (index17 == 23)
                  index17 = num15;
                if (index13 == 23)
                  index13 = num15;
                if (index15 == 23)
                  index15 = num15;
                if (index18 == 23)
                  index18 = num15;
                if (index20 == 23)
                {
                  index20 = num15;
                  break;
                }
                break;
              case 23:
                if (index14 == 2)
                  index14 = num15;
                if (index19 == 2)
                  index19 = num15;
                if (index16 == 2)
                  index16 = num15;
                if (index17 == 2)
                  index17 = num15;
                if (index13 == 2)
                  index13 = num15;
                if (index15 == 2)
                  index15 = num15;
                if (index18 == 2)
                  index18 = num15;
                if (index20 == 2)
                {
                  index20 = num15;
                  break;
                }
                break;
              case 60:
              case 70:
                num15 = 59;
                break;
            }
            if (index14 != type1 && index14 != num15 && (index19 == type1 || index19 == num15))
            {
              if (index16 == num15 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 198;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 198;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 198;
                    break;
                }
              }
              else if (index16 == type1 && index17 == num15)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 198;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 198;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 198;
                    break;
                }
              }
            }
            else if (index19 != type1 && index19 != num15 && (index14 == type1 || index14 == num15))
            {
              if (index16 == num15 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 216;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 216;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 216;
                    break;
                }
              }
              else if (index16 == type1 && index17 == num15)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 216;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 216;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 216;
                    break;
                }
              }
            }
            else if (index16 != type1 && index16 != num15 && (index17 == type1 || index17 == num15))
            {
              if (index14 == num15 && index19 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 72;
                    rectangle.Y = 144;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 162;
                    break;
                  default:
                    rectangle.X = 72;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index19 == type1 && index17 == index14)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 72;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 108;
                    break;
                  default:
                    rectangle.X = 72;
                    rectangle.Y = 126;
                    break;
                }
              }
            }
            else if (index17 != type1 && index17 != num15 && (index16 == type1 || index16 == num15))
            {
              if (index14 == num15 && index19 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 90;
                    rectangle.Y = 144;
                    break;
                  case 1:
                    rectangle.X = 90;
                    rectangle.Y = 162;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index19 == type1 && index17 == index14)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 90;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 90;
                    rectangle.Y = 108;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 126;
                    break;
                }
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 == type1 && index17 == type1)
            {
              if (index13 != type1 && index15 != type1 && index18 != type1 && index20 != type1)
              {
                if (index20 == num15)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 108;
                      rectangle.Y = 324;
                      break;
                    case 1:
                      rectangle.X = 126;
                      rectangle.Y = 324;
                      break;
                    default:
                      rectangle.X = 144;
                      rectangle.Y = 324;
                      break;
                  }
                }
                else if (index15 == num15)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 108;
                      rectangle.Y = 342;
                      break;
                    case 1:
                      rectangle.X = 126;
                      rectangle.Y = 342;
                      break;
                    default:
                      rectangle.X = 144;
                      rectangle.Y = 342;
                      break;
                  }
                }
                else if (index18 == num15)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 108;
                      rectangle.Y = 360;
                      break;
                    case 1:
                      rectangle.X = 126;
                      rectangle.Y = 360;
                      break;
                    default:
                      rectangle.X = 144;
                      rectangle.Y = 360;
                      break;
                  }
                }
                else if (index13 == num15)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 108;
                      rectangle.Y = 378;
                      break;
                    case 1:
                      rectangle.X = 126;
                      rectangle.Y = 378;
                      break;
                    default:
                      rectangle.X = 144;
                      rectangle.Y = 378;
                      break;
                  }
                }
                else
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 144;
                      rectangle.Y = 234;
                      break;
                    case 1:
                      rectangle.X = 198;
                      rectangle.Y = 234;
                      break;
                    default:
                      rectangle.X = 252;
                      rectangle.Y = 234;
                      break;
                  }
                }
              }
              else if (index13 != type1 && index20 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 306;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 306;
                    break;
                  default:
                    rectangle.X = 72;
                    rectangle.Y = 306;
                    break;
                }
              }
              else if (index15 != type1 && index18 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 90;
                    rectangle.Y = 306;
                    break;
                  case 1:
                    rectangle.X = 108;
                    rectangle.Y = 306;
                    break;
                  default:
                    rectangle.X = 126;
                    rectangle.Y = 306;
                    break;
                }
              }
              else if (index13 != type1 && index15 == type1 && index18 == type1 && index20 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index13 == type1 && index15 != type1 && index18 == type1 && index20 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index13 == type1 && index15 == type1 && index18 != type1 && index20 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 162;
                    break;
                }
              }
              else if (index13 == type1 && index15 == type1 && index18 == type1 && index20 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 162;
                    break;
                }
              }
            }
            else if (index14 == type1 && index19 == num15 && index16 == type1 && index17 == type1 && index13 == -1 && index15 == -1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 108;
                  rectangle.Y = 18;
                  break;
                case 1:
                  rectangle.X = 126;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 144;
                  rectangle.Y = 18;
                  break;
              }
            }
            else if (index14 == num15 && index19 == type1 && index16 == type1 && index17 == type1 && index18 == -1 && index20 == -1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 108;
                  rectangle.Y = 36;
                  break;
                case 1:
                  rectangle.X = 126;
                  rectangle.Y = 36;
                  break;
                default:
                  rectangle.X = 144;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 == num15 && index17 == type1 && index15 == -1 && index20 == -1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 198;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 198;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 198;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 == type1 && index17 == num15 && index13 == -1 && index18 == -1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 180;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 180;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 180;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 == type1 && index19 == num15 && index16 == type1 && index17 == type1)
            {
              if (index15 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index13 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 180;
                    break;
                }
              }
            }
            else if (index14 == num15 && index19 == type1 && index16 == type1 && index17 == type1)
            {
              if (index20 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 162;
                    break;
                }
              }
              else if (index18 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 162;
                    break;
                }
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 == type1 && index17 == num15)
            {
              if (index13 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 162;
                    break;
                }
              }
              else if (index18 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 180;
                    break;
                }
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 == num15 && index17 == type1)
            {
              if (index15 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 162;
                    break;
                }
              }
              else if (index20 != -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 180;
                    break;
                }
              }
            }
            else if (index14 == num15 && index19 == type1 && index16 == type1 && index17 == type1 || index14 == type1 && index19 == num15 && index16 == type1 && index17 == type1 || index14 == type1 && index19 == type1 && index16 == num15 && index17 == type1 || index14 == type1 && index19 == type1 && index16 == type1 && index17 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 18;
                  break;
                case 1:
                  rectangle.X = 36;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 54;
                  rectangle.Y = 18;
                  break;
              }
            }
            if ((index14 == type1 || index14 == num15) && (index19 == type1 || index19 == num15) && (index16 == type1 || index16 == num15) && (index17 == type1 || index17 == num15))
            {
              if (index13 != type1 && index13 != num15 && (index15 == type1 || index15 == num15) && (index18 == type1 || index18 == num15) && (index20 == type1 || index20 == num15))
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index15 != type1 && index15 != num15 && (index13 == type1 || index13 == num15) && (index18 == type1 || index18 == num15) && (index20 == type1 || index20 == num15))
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 180;
                    break;
                }
              }
              else if (index18 != type1 && index18 != num15 && (index13 == type1 || index13 == num15) && (index15 == type1 || index15 == num15) && (index20 == type1 || index20 == num15))
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 162;
                    break;
                }
              }
              else if (index20 != type1 && index20 != num15 && (index13 == type1 || index13 == num15) && (index18 == type1 || index18 == num15) && (index15 == type1 || index15 == num15))
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 162;
                    break;
                }
              }
            }
            if (index14 != num15 && index14 != type1 && index19 == type1 && index16 != num15 && index16 != type1 && index17 == type1 && index20 != num15 && index20 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 90;
                  rectangle.Y = 270;
                  break;
                case 1:
                  rectangle.X = 108;
                  rectangle.Y = 270;
                  break;
                default:
                  rectangle.X = 126;
                  rectangle.Y = 270;
                  break;
              }
            }
            else if (index14 != num15 && index14 != type1 && index19 == type1 && index16 == type1 && index17 != num15 && index17 != type1 && index18 != num15 && index18 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 144;
                  rectangle.Y = 270;
                  break;
                case 1:
                  rectangle.X = 162;
                  rectangle.Y = 270;
                  break;
                default:
                  rectangle.X = 180;
                  rectangle.Y = 270;
                  break;
              }
            }
            else if (index19 != num15 && index19 != type1 && index14 == type1 && index16 != num15 && index16 != type1 && index17 == type1 && index15 != num15 && index15 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 90;
                  rectangle.Y = 288;
                  break;
                case 1:
                  rectangle.X = 108;
                  rectangle.Y = 288;
                  break;
                default:
                  rectangle.X = 126;
                  rectangle.Y = 288;
                  break;
              }
            }
            else if (index19 != num15 && index19 != type1 && index14 == type1 && index16 == type1 && index17 != num15 && index17 != type1 && index13 != num15 && index13 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 144;
                  rectangle.Y = 288;
                  break;
                case 1:
                  rectangle.X = 162;
                  rectangle.Y = 288;
                  break;
                default:
                  rectangle.X = 180;
                  rectangle.Y = 288;
                  break;
              }
            }
            else if (index14 != type1 && index14 != num15 && index19 == type1 && index16 == type1 && index17 == type1 && index18 != type1 && index18 != num15 && index20 != type1 && index20 != num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 144;
                  rectangle.Y = 216;
                  break;
                case 1:
                  rectangle.X = 198;
                  rectangle.Y = 216;
                  break;
                default:
                  rectangle.X = 252;
                  rectangle.Y = 216;
                  break;
              }
            }
            else if (index19 != type1 && index19 != num15 && index14 == type1 && index16 == type1 && index17 == type1 && index13 != type1 && index13 != num15 && index15 != type1 && index15 != num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 144;
                  rectangle.Y = 252;
                  break;
                case 1:
                  rectangle.X = 198;
                  rectangle.Y = 252;
                  break;
                default:
                  rectangle.X = 252;
                  rectangle.Y = 252;
                  break;
              }
            }
            else if (index16 != type1 && index16 != num15 && index19 == type1 && index14 == type1 && index17 == type1 && index15 != type1 && index15 != num15 && index20 != type1 && index20 != num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 126;
                  rectangle.Y = 234;
                  break;
                case 1:
                  rectangle.X = 180;
                  rectangle.Y = 234;
                  break;
                default:
                  rectangle.X = 234;
                  rectangle.Y = 234;
                  break;
              }
            }
            else if (index17 != type1 && index17 != num15 && index19 == type1 && index14 == type1 && index16 == type1 && index13 != type1 && index13 != num15 && index18 != type1 && index18 != num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 162;
                  rectangle.Y = 234;
                  break;
                case 1:
                  rectangle.X = 216;
                  rectangle.Y = 234;
                  break;
                default:
                  rectangle.X = 270;
                  rectangle.Y = 234;
                  break;
              }
            }
            else if (index14 != num15 && index14 != type1 && (index19 == num15 || index19 == type1) && index16 == num15 && index17 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 36;
                  rectangle.Y = 270;
                  break;
                case 1:
                  rectangle.X = 54;
                  rectangle.Y = 270;
                  break;
                default:
                  rectangle.X = 72;
                  rectangle.Y = 270;
                  break;
              }
            }
            else if (index19 != num15 && index19 != type1 && (index14 == num15 || index14 == type1) && index16 == num15 && index17 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 36;
                  rectangle.Y = 288;
                  break;
                case 1:
                  rectangle.X = 54;
                  rectangle.Y = 288;
                  break;
                default:
                  rectangle.X = 72;
                  rectangle.Y = 288;
                  break;
              }
            }
            else if (index16 != num15 && index16 != type1 && (index17 == num15 || index17 == type1) && index14 == num15 && index19 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 0;
                  rectangle.Y = 270;
                  break;
                case 1:
                  rectangle.X = 0;
                  rectangle.Y = 288;
                  break;
                default:
                  rectangle.X = 0;
                  rectangle.Y = 306;
                  break;
              }
            }
            else if (index17 != num15 && index17 != type1 && (index16 == num15 || index16 == type1) && index14 == num15 && index19 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 270;
                  break;
                case 1:
                  rectangle.X = 18;
                  rectangle.Y = 288;
                  break;
                default:
                  rectangle.X = 18;
                  rectangle.Y = 306;
                  break;
              }
            }
            else if (index14 == type1 && index19 == num15 && index16 == num15 && index17 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 198;
                  rectangle.Y = 288;
                  break;
                case 1:
                  rectangle.X = 216;
                  rectangle.Y = 288;
                  break;
                default:
                  rectangle.X = 234;
                  rectangle.Y = 288;
                  break;
              }
            }
            else if (index14 == num15 && index19 == type1 && index16 == num15 && index17 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 198;
                  rectangle.Y = 270;
                  break;
                case 1:
                  rectangle.X = 216;
                  rectangle.Y = 270;
                  break;
                default:
                  rectangle.X = 234;
                  rectangle.Y = 270;
                  break;
              }
            }
            else if (index14 == num15 && index19 == num15 && index16 == type1 && index17 == num15)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 198;
                  rectangle.Y = 306;
                  break;
                case 1:
                  rectangle.X = 216;
                  rectangle.Y = 306;
                  break;
                default:
                  rectangle.X = 234;
                  rectangle.Y = 306;
                  break;
              }
            }
            else if (index14 == num15 && index19 == num15 && index16 == num15 && index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 144;
                  rectangle.Y = 306;
                  break;
                case 1:
                  rectangle.X = 162;
                  rectangle.Y = 306;
                  break;
                default:
                  rectangle.X = 180;
                  rectangle.Y = 306;
                  break;
              }
            }
            if (index14 != type1 && index14 != num15 && index19 == type1 && index16 == type1 && index17 == type1)
            {
              if ((index18 == num15 || index18 == type1) && index20 != num15 && index20 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 324;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 324;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 324;
                    break;
                }
              }
              else if ((index20 == num15 || index20 == type1) && index18 != num15 && index18 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 324;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 324;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 324;
                    break;
                }
              }
            }
            else if (index19 != type1 && index19 != num15 && index14 == type1 && index16 == type1 && index17 == type1)
            {
              if ((index13 == num15 || index13 == type1) && index15 != num15 && index15 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 342;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 342;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 342;
                    break;
                }
              }
              else if ((index15 == num15 || index15 == type1) && index13 != num15 && index13 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 342;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 342;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 342;
                    break;
                }
              }
            }
            else if (index16 != type1 && index16 != num15 && index14 == type1 && index19 == type1 && index17 == type1)
            {
              if ((index15 == num15 || index15 == type1) && index20 != num15 && index20 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 360;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 360;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 360;
                    break;
                }
              }
              else if ((index20 == num15 || index20 == type1) && index15 != num15 && index15 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 360;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 360;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 360;
                    break;
                }
              }
            }
            else if (index17 != type1 && index17 != num15 && index14 == type1 && index19 == type1 && index16 == type1)
            {
              if ((index13 == num15 || index13 == type1) && index18 != num15 && index18 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 378;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 378;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 378;
                    break;
                }
              }
              else if ((index18 == num15 || index18 == type1) && index13 != num15 && index13 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 378;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 378;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 378;
                    break;
                }
              }
            }
            if ((index14 == type1 || index14 == num15) && (index19 == type1 || index19 == num15) && (index16 == type1 || index16 == num15) && (index17 == type1 || index17 == num15) && index13 != -1 && index15 != -1 && index18 != -1 && index20 != -1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 18;
                  break;
                case 1:
                  rectangle.X = 36;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 54;
                  rectangle.Y = 18;
                  break;
              }
            }
            if (index14 == num15)
              index14 = -2;
            if (index19 == num15)
              index19 = -2;
            if (index16 == num15)
              index16 = -2;
            if (index17 == num15)
              index17 = -2;
            if (index13 == num15)
              index13 = -2;
            if (index15 == num15)
              index15 = -2;
            if (index18 == num15)
              index18 = -2;
            if (index20 == num15)
              index20 = -2;
          }
          if (rectangle.X == -1 && rectangle.Y == -1 && (Main.tileMergeDirt[type1] || type1 == 0 || type1 == 2 || type1 == 57 || type1 == 58 || type1 == 59 || type1 == 60 || type1 == 70 || type1 == 109 || type1 == 76 || type1 == 75))
          {
            if (!flag3)
            {
              flag3 = true;
              if (index14 > -1 && !Main.tileSolid[index14] && index14 != type1)
                index14 = -1;
              if (index19 > -1 && !Main.tileSolid[index19] && index19 != type1)
                index19 = -1;
              if (index16 > -1 && !Main.tileSolid[index16] && index16 != type1)
                index16 = -1;
              if (index17 > -1 && !Main.tileSolid[index17] && index17 != type1)
                index17 = -1;
              if (index13 > -1 && !Main.tileSolid[index13] && index13 != type1)
                index13 = -1;
              if (index15 > -1 && !Main.tileSolid[index15] && index15 != type1)
                index15 = -1;
              if (index18 > -1 && !Main.tileSolid[index18] && index18 != type1)
                index18 = -1;
              if (index20 > -1 && !Main.tileSolid[index20] && index20 != type1)
                index20 = -1;
            }
            if (index14 >= 0 && index14 != type1)
              index14 = -1;
            if (index19 >= 0 && index19 != type1)
              index19 = -1;
            if (index16 >= 0 && index16 != type1)
              index16 = -1;
            if (index17 >= 0 && index17 != type1)
              index17 = -1;
            if (index14 != -1 && index19 != -1 && index16 != -1 && index17 != -1)
            {
              if (index14 == -2 && index19 == type1 && index16 == type1 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 144;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 162;
                    rectangle.Y = 108;
                    break;
                  default:
                    rectangle.X = 180;
                    rectangle.Y = 108;
                    break;
                }
                WorldGen.mergeUp = true;
              }
              else if (index14 == type1 && index19 == -2 && index16 == type1 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 144;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 162;
                    rectangle.Y = 90;
                    break;
                  default:
                    rectangle.X = 180;
                    rectangle.Y = 90;
                    break;
                }
                WorldGen.mergeDown = true;
              }
              else if (index14 == type1 && index19 == type1 && index16 == -2 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 162;
                    rectangle.Y = 126;
                    break;
                  case 1:
                    rectangle.X = 162;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 162;
                    rectangle.Y = 162;
                    break;
                }
                WorldGen.mergeLeft = true;
              }
              else if (index14 == type1 && index19 == type1 && index16 == type1 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 144;
                    rectangle.Y = 126;
                    break;
                  case 1:
                    rectangle.X = 144;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 144;
                    rectangle.Y = 162;
                    break;
                }
                WorldGen.mergeRight = true;
              }
              else if (index14 == -2 && index19 == type1 && index16 == -2 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 162;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeLeft = true;
              }
              else if (index14 == -2 && index19 == type1 && index16 == type1 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 126;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 162;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == type1 && index19 == -2 && index16 == -2 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 36;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 180;
                    break;
                }
                WorldGen.mergeDown = true;
                WorldGen.mergeLeft = true;
              }
              else if (index14 == type1 && index19 == -2 && index16 == type1 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 108;
                    break;
                  case 1:
                    rectangle.X = 54;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 180;
                    break;
                }
                WorldGen.mergeDown = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == type1 && index19 == type1 && index16 == -2 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 180;
                    rectangle.Y = 126;
                    break;
                  case 1:
                    rectangle.X = 180;
                    rectangle.Y = 144;
                    break;
                  default:
                    rectangle.X = 180;
                    rectangle.Y = 162;
                    break;
                }
                WorldGen.mergeLeft = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == -2 && index19 == -2 && index16 == type1 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 144;
                    rectangle.Y = 180;
                    break;
                  case 1:
                    rectangle.X = 162;
                    rectangle.Y = 180;
                    break;
                  default:
                    rectangle.X = 180;
                    rectangle.Y = 180;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeDown = true;
              }
              else if (index14 == -2 && index19 == type1 && index16 == -2 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 198;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 198;
                    rectangle.Y = 108;
                    break;
                  default:
                    rectangle.X = 198;
                    rectangle.Y = 126;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeLeft = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == type1 && index19 == -2 && index16 == -2 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 198;
                    rectangle.Y = 144;
                    break;
                  case 1:
                    rectangle.X = 198;
                    rectangle.Y = 162;
                    break;
                  default:
                    rectangle.X = 198;
                    rectangle.Y = 180;
                    break;
                }
                WorldGen.mergeDown = true;
                WorldGen.mergeLeft = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == -2 && index19 == -2 && index16 == type1 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 216;
                    rectangle.Y = 144;
                    break;
                  case 1:
                    rectangle.X = 216;
                    rectangle.Y = 162;
                    break;
                  default:
                    rectangle.X = 216;
                    rectangle.Y = 180;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeDown = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == -2 && index19 == -2 && index16 == -2 && index17 == type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 216;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 216;
                    rectangle.Y = 108;
                    break;
                  default:
                    rectangle.X = 216;
                    rectangle.Y = 126;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeDown = true;
                WorldGen.mergeLeft = true;
              }
              else if (index14 == -2 && index19 == -2 && index16 == -2 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 108;
                    rectangle.Y = 198;
                    break;
                  case 1:
                    rectangle.X = 126;
                    rectangle.Y = 198;
                    break;
                  default:
                    rectangle.X = 144;
                    rectangle.Y = 198;
                    break;
                }
                WorldGen.mergeUp = true;
                WorldGen.mergeDown = true;
                WorldGen.mergeLeft = true;
                WorldGen.mergeRight = true;
              }
              else if (index14 == type1 && index19 == type1 && index16 == type1 && index17 == type1)
              {
                if (index13 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 18;
                      rectangle.Y = 108;
                      break;
                    case 1:
                      rectangle.X = 18;
                      rectangle.Y = 144;
                      break;
                    default:
                      rectangle.X = 18;
                      rectangle.Y = 180;
                      break;
                  }
                }
                if (index15 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 0;
                      rectangle.Y = 108;
                      break;
                    case 1:
                      rectangle.X = 0;
                      rectangle.Y = 144;
                      break;
                    default:
                      rectangle.X = 0;
                      rectangle.Y = 180;
                      break;
                  }
                }
                if (index18 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 18;
                      rectangle.Y = 90;
                      break;
                    case 1:
                      rectangle.X = 18;
                      rectangle.Y = 126;
                      break;
                    default:
                      rectangle.X = 18;
                      rectangle.Y = 162;
                      break;
                  }
                }
                if (index20 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 0;
                      rectangle.Y = 90;
                      break;
                    case 1:
                      rectangle.X = 0;
                      rectangle.Y = 126;
                      break;
                    default:
                      rectangle.X = 0;
                      rectangle.Y = 162;
                      break;
                  }
                }
              }
            }
            else
            {
              if (type1 != 2 && type1 != 23 && type1 != 60 && type1 != 70 && type1 != 109)
              {
                if (index14 == -1 && index19 == -2 && index16 == type1 && index17 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 234;
                      rectangle.Y = 0;
                      break;
                    case 1:
                      rectangle.X = 252;
                      rectangle.Y = 0;
                      break;
                    default:
                      rectangle.X = 270;
                      rectangle.Y = 0;
                      break;
                  }
                  WorldGen.mergeDown = true;
                }
                else if (index14 == -2 && index19 == -1 && index16 == type1 && index17 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 234;
                      rectangle.Y = 18;
                      break;
                    case 1:
                      rectangle.X = 252;
                      rectangle.Y = 18;
                      break;
                    default:
                      rectangle.X = 270;
                      rectangle.Y = 18;
                      break;
                  }
                  WorldGen.mergeUp = true;
                }
                else if (index14 == type1 && index19 == type1 && index16 == -1 && index17 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 234;
                      rectangle.Y = 36;
                      break;
                    case 1:
                      rectangle.X = 252;
                      rectangle.Y = 36;
                      break;
                    default:
                      rectangle.X = 270;
                      rectangle.Y = 36;
                      break;
                  }
                  WorldGen.mergeRight = true;
                }
                else if (index14 == type1 && index19 == type1 && index16 == -2 && index17 == -1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 234;
                      rectangle.Y = 54;
                      break;
                    case 1:
                      rectangle.X = 252;
                      rectangle.Y = 54;
                      break;
                    default:
                      rectangle.X = 270;
                      rectangle.Y = 54;
                      break;
                  }
                  WorldGen.mergeLeft = true;
                }
              }
              if (index14 != -1 && index19 != -1 && index16 == -1 && index17 == type1)
              {
                if (index14 == -2 && index19 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 72;
                      rectangle.Y = 144;
                      break;
                    case 1:
                      rectangle.X = 72;
                      rectangle.Y = 162;
                      break;
                    default:
                      rectangle.X = 72;
                      rectangle.Y = 180;
                      break;
                  }
                  WorldGen.mergeUp = true;
                }
                else if (index19 == -2 && index14 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 72;
                      rectangle.Y = 90;
                      break;
                    case 1:
                      rectangle.X = 72;
                      rectangle.Y = 108;
                      break;
                    default:
                      rectangle.X = 72;
                      rectangle.Y = 126;
                      break;
                  }
                  WorldGen.mergeDown = true;
                }
              }
              else if (index14 != -1 && index19 != -1 && index16 == type1 && index17 == -1)
              {
                if (index14 == -2 && index19 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 90;
                      rectangle.Y = 144;
                      break;
                    case 1:
                      rectangle.X = 90;
                      rectangle.Y = 162;
                      break;
                    default:
                      rectangle.X = 90;
                      rectangle.Y = 180;
                      break;
                  }
                  WorldGen.mergeUp = true;
                }
                else if (index19 == -2 && index14 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 90;
                      rectangle.Y = 90;
                      break;
                    case 1:
                      rectangle.X = 90;
                      rectangle.Y = 108;
                      break;
                    default:
                      rectangle.X = 90;
                      rectangle.Y = 126;
                      break;
                  }
                  WorldGen.mergeDown = true;
                }
              }
              else if (index14 == -1 && index19 == type1 && index16 != -1 && index17 != -1)
              {
                if (index16 == -2 && index17 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 0;
                      rectangle.Y = 198;
                      break;
                    case 1:
                      rectangle.X = 18;
                      rectangle.Y = 198;
                      break;
                    default:
                      rectangle.X = 36;
                      rectangle.Y = 198;
                      break;
                  }
                  WorldGen.mergeLeft = true;
                }
                else if (index17 == -2 && index16 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 54;
                      rectangle.Y = 198;
                      break;
                    case 1:
                      rectangle.X = 72;
                      rectangle.Y = 198;
                      break;
                    default:
                      rectangle.X = 90;
                      rectangle.Y = 198;
                      break;
                  }
                  WorldGen.mergeRight = true;
                }
              }
              else if (index14 == type1 && index19 == -1 && index16 != -1 && index17 != -1)
              {
                if (index16 == -2 && index17 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 0;
                      rectangle.Y = 216;
                      break;
                    case 1:
                      rectangle.X = 18;
                      rectangle.Y = 216;
                      break;
                    default:
                      rectangle.X = 36;
                      rectangle.Y = 216;
                      break;
                  }
                  WorldGen.mergeLeft = true;
                }
                else if (index17 == -2 && index16 == type1)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 54;
                      rectangle.Y = 216;
                      break;
                    case 1:
                      rectangle.X = 72;
                      rectangle.Y = 216;
                      break;
                    default:
                      rectangle.X = 90;
                      rectangle.Y = 216;
                      break;
                  }
                  WorldGen.mergeRight = true;
                }
              }
              else if (index14 != -1 && index19 != -1 && index16 == -1 && index17 == -1)
              {
                if (index14 == -2 && index19 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 108;
                      rectangle.Y = 216;
                      break;
                    case 1:
                      rectangle.X = 108;
                      rectangle.Y = 234;
                      break;
                    default:
                      rectangle.X = 108;
                      rectangle.Y = 252;
                      break;
                  }
                  WorldGen.mergeUp = true;
                  WorldGen.mergeDown = true;
                }
                else if (index14 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 126;
                      rectangle.Y = 144;
                      break;
                    case 1:
                      rectangle.X = 126;
                      rectangle.Y = 162;
                      break;
                    default:
                      rectangle.X = 126;
                      rectangle.Y = 180;
                      break;
                  }
                  WorldGen.mergeUp = true;
                }
                else if (index19 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 126;
                      rectangle.Y = 90;
                      break;
                    case 1:
                      rectangle.X = 126;
                      rectangle.Y = 108;
                      break;
                    default:
                      rectangle.X = 126;
                      rectangle.Y = 126;
                      break;
                  }
                  WorldGen.mergeDown = true;
                }
              }
              else if (index14 == -1 && index19 == -1 && index16 != -1 && index17 != -1)
              {
                if (index16 == -2 && index17 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 162;
                      rectangle.Y = 198;
                      break;
                    case 1:
                      rectangle.X = 180;
                      rectangle.Y = 198;
                      break;
                    default:
                      rectangle.X = 198;
                      rectangle.Y = 198;
                      break;
                  }
                  WorldGen.mergeLeft = true;
                  WorldGen.mergeRight = true;
                }
                else if (index16 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 0;
                      rectangle.Y = 252;
                      break;
                    case 1:
                      rectangle.X = 18;
                      rectangle.Y = 252;
                      break;
                    default:
                      rectangle.X = 36;
                      rectangle.Y = 252;
                      break;
                  }
                  WorldGen.mergeLeft = true;
                }
                else if (index17 == -2)
                {
                  switch (num14)
                  {
                    case 0:
                      rectangle.X = 54;
                      rectangle.Y = 252;
                      break;
                    case 1:
                      rectangle.X = 72;
                      rectangle.Y = 252;
                      break;
                    default:
                      rectangle.X = 90;
                      rectangle.Y = 252;
                      break;
                  }
                  WorldGen.mergeRight = true;
                }
              }
              else if (index14 == -2 && index19 == -1 && index16 == -1 && index17 == -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 108;
                    rectangle.Y = 144;
                    break;
                  case 1:
                    rectangle.X = 108;
                    rectangle.Y = 162;
                    break;
                  default:
                    rectangle.X = 108;
                    rectangle.Y = 180;
                    break;
                }
                WorldGen.mergeUp = true;
              }
              else if (index14 == -1 && index19 == -2 && index16 == -1 && index17 == -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 108;
                    rectangle.Y = 90;
                    break;
                  case 1:
                    rectangle.X = 108;
                    rectangle.Y = 108;
                    break;
                  default:
                    rectangle.X = 108;
                    rectangle.Y = 126;
                    break;
                }
                WorldGen.mergeDown = true;
              }
              else if (index14 == -1 && index19 == -1 && index16 == -2 && index17 == -1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 0;
                    rectangle.Y = 234;
                    break;
                  case 1:
                    rectangle.X = 18;
                    rectangle.Y = 234;
                    break;
                  default:
                    rectangle.X = 36;
                    rectangle.Y = 234;
                    break;
                }
                WorldGen.mergeLeft = true;
              }
              else if (index14 == -1 && index19 == -1 && index16 == -1 && index17 == -2)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 54;
                    rectangle.Y = 234;
                    break;
                  case 1:
                    rectangle.X = 72;
                    rectangle.Y = 234;
                    break;
                  default:
                    rectangle.X = 90;
                    rectangle.Y = 234;
                    break;
                }
                WorldGen.mergeRight = true;
              }
            }
          }
          if (rectangle.X < 0 || rectangle.Y < 0)
          {
            if (!flag3)
            {
              if (index14 > -1 && !Main.tileSolid[index14] && index14 != type1)
                index14 = -1;
              if (index19 > -1 && !Main.tileSolid[index19] && index19 != type1)
                index19 = -1;
              if (index16 > -1 && !Main.tileSolid[index16] && index16 != type1)
                index16 = -1;
              if (index17 > -1 && !Main.tileSolid[index17] && index17 != type1)
                index17 = -1;
              if (index13 > -1 && !Main.tileSolid[index13] && index13 != type1)
                index13 = -1;
              if (index15 > -1 && !Main.tileSolid[index15] && index15 != type1)
                index15 = -1;
              if (index18 > -1 && !Main.tileSolid[index18] && index18 != type1)
                index18 = -1;
              if (index20 > -1 && !Main.tileSolid[index20] && index20 != type1)
                index20 = -1;
            }
            if (type1 == 2 || type1 == 23 || type1 == 60 || type1 == 70 || type1 == 109)
            {
              if (index14 == -2)
                index14 = type1;
              if (index19 == -2)
                index19 = type1;
              if (index16 == -2)
                index16 = type1;
              if (index17 == -2)
                index17 = type1;
              if (index13 == -2)
                index13 = type1;
              if (index15 == -2)
                index15 = type1;
              if (index18 == -2)
                index18 = type1;
              if (index20 == -2)
                index20 = type1;
            }
            if (index14 == type1 && index19 == type1 && index16 == type1 & index17 == type1)
            {
              if (index13 != type1 && index15 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 108;
                    rectangle.Y = 18;
                    break;
                  case 1:
                    rectangle.X = 126;
                    rectangle.Y = 18;
                    break;
                  default:
                    rectangle.X = 144;
                    rectangle.Y = 18;
                    break;
                }
              }
              else if (index18 != type1 && index20 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 108;
                    rectangle.Y = 36;
                    break;
                  case 1:
                    rectangle.X = 126;
                    rectangle.Y = 36;
                    break;
                  default:
                    rectangle.X = 144;
                    rectangle.Y = 36;
                    break;
                }
              }
              else if (index13 != type1 && index18 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 180;
                    rectangle.Y = 0;
                    break;
                  case 1:
                    rectangle.X = 180;
                    rectangle.Y = 18;
                    break;
                  default:
                    rectangle.X = 180;
                    rectangle.Y = 36;
                    break;
                }
              }
              else if (index15 != type1 && index20 != type1)
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 198;
                    rectangle.Y = 0;
                    break;
                  case 1:
                    rectangle.X = 198;
                    rectangle.Y = 18;
                    break;
                  default:
                    rectangle.X = 198;
                    rectangle.Y = 36;
                    break;
                }
              }
              else
              {
                switch (num14)
                {
                  case 0:
                    rectangle.X = 18;
                    rectangle.Y = 18;
                    break;
                  case 1:
                    rectangle.X = 36;
                    rectangle.Y = 18;
                    break;
                  default:
                    rectangle.X = 54;
                    rectangle.Y = 18;
                    break;
                }
              }
            }
            else if (index14 != type1 && index19 == type1 && index16 == type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 36;
                  rectangle.Y = 0;
                  break;
                default:
                  rectangle.X = 54;
                  rectangle.Y = 0;
                  break;
              }
            }
            else if (index14 == type1 && index19 != type1 && index16 == type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 36;
                  break;
                case 1:
                  rectangle.X = 36;
                  rectangle.Y = 36;
                  break;
                default:
                  rectangle.X = 54;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 != type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 0;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 0;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 0;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 == type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 72;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 72;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 72;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 != type1 && index19 == type1 && index16 != type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 0;
                  rectangle.Y = 54;
                  break;
                case 1:
                  rectangle.X = 36;
                  rectangle.Y = 54;
                  break;
                default:
                  rectangle.X = 72;
                  rectangle.Y = 54;
                  break;
              }
            }
            else if (index14 != type1 && index19 == type1 && index16 == type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 54;
                  break;
                case 1:
                  rectangle.X = 54;
                  rectangle.Y = 54;
                  break;
                default:
                  rectangle.X = 90;
                  rectangle.Y = 54;
                  break;
              }
            }
            else if (index14 == type1 && index19 != type1 && index16 != type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 0;
                  rectangle.Y = 72;
                  break;
                case 1:
                  rectangle.X = 36;
                  rectangle.Y = 72;
                  break;
                default:
                  rectangle.X = 72;
                  rectangle.Y = 72;
                  break;
              }
            }
            else if (index14 == type1 && index19 != type1 && index16 == type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 18;
                  rectangle.Y = 72;
                  break;
                case 1:
                  rectangle.X = 54;
                  rectangle.Y = 72;
                  break;
                default:
                  rectangle.X = 90;
                  rectangle.Y = 72;
                  break;
              }
            }
            else if (index14 == type1 && index19 == type1 && index16 != type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 90;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 90;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 90;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 != type1 && index19 != type1 && index16 == type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 108;
                  rectangle.Y = 72;
                  break;
                case 1:
                  rectangle.X = 126;
                  rectangle.Y = 72;
                  break;
                default:
                  rectangle.X = 144;
                  rectangle.Y = 72;
                  break;
              }
            }
            else if (index14 != type1 && index19 == type1 && index16 != type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 108;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 126;
                  rectangle.Y = 0;
                  break;
                default:
                  rectangle.X = 144;
                  rectangle.Y = 0;
                  break;
              }
            }
            else if (index14 == type1 && index19 != type1 && index16 != type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 108;
                  rectangle.Y = 54;
                  break;
                case 1:
                  rectangle.X = 126;
                  rectangle.Y = 54;
                  break;
                default:
                  rectangle.X = 144;
                  rectangle.Y = 54;
                  break;
              }
            }
            else if (index14 != type1 && index19 != type1 && index16 != type1 & index17 == type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 162;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 162;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 162;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 != type1 && index19 != type1 && index16 == type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 216;
                  rectangle.Y = 0;
                  break;
                case 1:
                  rectangle.X = 216;
                  rectangle.Y = 18;
                  break;
                default:
                  rectangle.X = 216;
                  rectangle.Y = 36;
                  break;
              }
            }
            else if (index14 != type1 && index19 != type1 && index16 != type1 & index17 != type1)
            {
              switch (num14)
              {
                case 0:
                  rectangle.X = 162;
                  rectangle.Y = 54;
                  break;
                case 1:
                  rectangle.X = 180;
                  rectangle.Y = 54;
                  break;
                default:
                  rectangle.X = 198;
                  rectangle.Y = 54;
                  break;
              }
            }
          }
          if (rectangle.X <= -1 || rectangle.Y <= -1)
          {
            if (num14 <= 0)
            {
              rectangle.X = 18;
              rectangle.Y = 18;
            }
            else if (num14 == 1)
            {
              rectangle.X = 36;
              rectangle.Y = 18;
            }
            if (num14 >= 2)
            {
              rectangle.X = 54;
              rectangle.Y = 18;
            }
          }
          Main.tile[i, j].frameX = (short) rectangle.X;
          Main.tile[i, j].frameY = (short) rectangle.Y;
          if (type1 == 52 || type1 == 62 || type1 == 115)
          {
            int num16 = Main.tile[i, j - 1] == null ? type1 : (Main.tile[i, j - 1].active ? (int) Main.tile[i, j - 1].type : -1);
            if (type1 == 52 && (num16 == 109 || num16 == 115))
            {
              Main.tile[i, j].type = (byte) 115;
              WorldGen.SquareTileFrame(i, j);
              return;
            }
            if (type1 == 115 && (num16 == 2 || num16 == 52))
            {
              Main.tile[i, j].type = (byte) 52;
              WorldGen.SquareTileFrame(i, j);
              return;
            }
            if (num16 != type1)
            {
              bool flag4 = false;
              if (num16 == -1)
                flag4 = true;
              if (type1 == 52 && num16 != 2)
                flag4 = true;
              if (type1 == 62 && num16 != 60)
                flag4 = true;
              if (type1 == 115 && num16 != 109)
                flag4 = true;
              if (flag4)
                WorldGen.KillTile(i, j);
            }
          }
          if (!WorldGen.noTileActions && (type1 == 53 || type1 == 112 || type1 == 116 || type1 == 123))
          {
            switch (Main.netMode)
            {
              case 0:
                if (Main.tile[i, j + 1] != null && !Main.tile[i, j + 1].active)
                {
                  bool flag5 = true;
                  if (Main.tile[i, j - 1].active && Main.tile[i, j - 1].type == (byte) 21)
                    flag5 = false;
                  if (flag5)
                  {
                    int Type = 31;
                    if (type1 == 59)
                      Type = 39;
                    if (type1 == 57)
                      Type = 40;
                    if (type1 == 112)
                      Type = 56;
                    if (type1 == 116)
                      Type = 67;
                    if (type1 == 123)
                      Type = 71;
                    Main.tile[i, j].active = false;
                    int index21 = Projectile.NewProjectile((float) (i * 16 + 8), (float) (j * 16 + 8), 0.0f, 0.41f, Type, 10, 0.0f, Main.myPlayer);
                    Main.projectile[index21].ai[0] = 1f;
                    WorldGen.SquareTileFrame(i, j);
                    break;
                  }
                  break;
                }
                break;
              case 2:
                if (Main.tile[i, j + 1] != null && !Main.tile[i, j + 1].active)
                {
                  bool flag6 = true;
                  if (Main.tile[i, j - 1].active && Main.tile[i, j - 1].type == (byte) 21)
                    flag6 = false;
                  if (flag6)
                  {
                    int Type = 31;
                    if (type1 == 59)
                      Type = 39;
                    if (type1 == 57)
                      Type = 40;
                    if (type1 == 112)
                      Type = 56;
                    if (type1 == 116)
                      Type = 67;
                    if (type1 == 123)
                      Type = 71;
                    Main.tile[i, j].active = false;
                    int index22 = Projectile.NewProjectile((float) (i * 16 + 8), (float) (j * 16 + 8), 0.0f, 2.5f, Type, 10, 0.0f, Main.myPlayer);
                    Main.projectile[index22].velocity.Y = 0.5f;
                    Main.projectile[index22].position.Y += 2f;
                    Main.projectile[index22].netUpdate = true;
                    NetMessage.SendTileSquare(-1, i, j, 1);
                    WorldGen.SquareTileFrame(i, j);
                    break;
                  }
                  break;
                }
                break;
            }
          }
          if (rectangle.X == frameX1 || rectangle.Y == frameY1 || frameX1 < 0 || frameY1 < 0)
            return;
          bool mergeUp = WorldGen.mergeUp;
          bool mergeDown = WorldGen.mergeDown;
          bool mergeLeft = WorldGen.mergeLeft;
          bool mergeRight = WorldGen.mergeRight;
          WorldGen.TileFrame(i - 1, j);
          WorldGen.TileFrame(i + 1, j);
          WorldGen.TileFrame(i, j - 1);
          WorldGen.TileFrame(i, j + 1);
          WorldGen.mergeUp = mergeUp;
          WorldGen.mergeDown = mergeDown;
          WorldGen.mergeLeft = mergeLeft;
          WorldGen.mergeRight = mergeRight;
        }
      }
      catch
      {
      }
    }
  }
}
