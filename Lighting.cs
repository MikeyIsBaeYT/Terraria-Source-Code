// Decompiled with JetBrains decompiler
// Type: Terraria.Lighting
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace Terraria
{
  public class Lighting
  {
    public static int maxRenderCount = 4;
    public static int dirX;
    public static int dirY;
    public static float brightness = 1f;
    public static float defBrightness = 1f;
    public static int lightMode = 0;
    public static bool RGB = true;
    public static float oldSkyColor = 0.0f;
    public static float skyColor = 0.0f;
    private static float lightColor = 0.0f;
    private static float lightColorG = 0.0f;
    private static float lightColorB = 0.0f;
    public static int lightCounter = 0;
    public static int offScreenTiles = 45;
    public static int offScreenTiles2 = 35;
    private static int firstTileX;
    private static int lastTileX;
    private static int firstTileY;
    private static int lastTileY;
    public static float[,] color = new float[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static float[,] colorG = new float[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static float[,] colorB = new float[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static float[,] color2 = new float[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static float[,] colorG2 = new float[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static float[,] colorB2 = new float[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static bool[,] stopLight = new bool[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static bool[,] wetLight = new bool[Main.screenWidth + Lighting.offScreenTiles * 2 + 10, Main.screenHeight + Lighting.offScreenTiles * 2 + 10];
    public static int scrX;
    public static int scrY;
    public static int minX;
    public static int maxX;
    public static int minY;
    public static int maxY;
    private static int maxTempLights = 2000;
    private static int[] tempLightX = new int[Lighting.maxTempLights];
    private static int[] tempLightY = new int[Lighting.maxTempLights];
    private static float[] tempLight = new float[Lighting.maxTempLights];
    private static float[] tempLightG = new float[Lighting.maxTempLights];
    private static float[] tempLightB = new float[Lighting.maxTempLights];
    public static int tempLightCount;
    private static int firstToLightX;
    private static int firstToLightY;
    private static int lastToLightX;
    private static int lastToLightY;
    public static bool resize = false;
    private static float negLight = 0.04f;
    private static float negLight2 = 0.16f;
    private static float wetLightR = 0.16f;
    private static float wetLightG = 0.16f;
    private static float blueWave = 1f;
    private static int blueDir = 1;
    private static int minX7;
    private static int maxX7;
    private static int minY7;
    private static int maxY7;
    private static int firstTileX7;
    private static int lastTileX7;
    private static int lastTileY7;
    private static int firstTileY7;
    private static int firstToLightX7;
    private static int lastToLightX7;
    private static int firstToLightY7;
    private static int lastToLightY7;
    private static int firstToLightX27;
    private static int lastToLightX27;
    private static int firstToLightY27;
    private static int lastToLightY27;

    public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
    {
      Main.render = true;
      Lighting.oldSkyColor = Lighting.skyColor;
      Lighting.skyColor = (float) (((int) Main.tileColor.R + (int) Main.tileColor.G + (int) Main.tileColor.B) / 3) / (float) byte.MaxValue;
      if (Lighting.lightMode < 2)
      {
        Lighting.brightness = 1.2f;
        Lighting.offScreenTiles2 = 34;
        Lighting.offScreenTiles = 40;
      }
      else
      {
        Lighting.brightness = 1f;
        Lighting.offScreenTiles2 = 18;
        Lighting.offScreenTiles = 23;
      }
      if (Main.player[Main.myPlayer].blind)
        Lighting.brightness = 1f;
      Lighting.defBrightness = Lighting.brightness;
      Lighting.firstTileX = firstX;
      Lighting.lastTileX = lastX;
      Lighting.firstTileY = firstY;
      Lighting.lastTileY = lastY;
      Lighting.firstToLightX = Lighting.firstTileX - Lighting.offScreenTiles;
      Lighting.firstToLightY = Lighting.firstTileY - Lighting.offScreenTiles;
      Lighting.lastToLightX = Lighting.lastTileX + Lighting.offScreenTiles;
      Lighting.lastToLightY = Lighting.lastTileY + Lighting.offScreenTiles;
      if (Lighting.firstToLightX < 0)
        Lighting.firstToLightX = 0;
      if (Lighting.lastToLightX >= Main.maxTilesX)
        Lighting.lastToLightX = Main.maxTilesX - 1;
      if (Lighting.firstToLightY < 0)
        Lighting.firstToLightY = 0;
      if (Lighting.lastToLightY >= Main.maxTilesY)
        Lighting.lastToLightY = Main.maxTilesY - 1;
      int num1 = Lighting.firstTileX - Lighting.offScreenTiles2;
      int num2 = Lighting.firstTileY - Lighting.offScreenTiles2;
      int num3 = Lighting.lastTileX + Lighting.offScreenTiles2;
      int num4 = Lighting.lastTileY + Lighting.offScreenTiles2;
      if (num1 < 0)
        num1 = 0;
      if (num3 >= Main.maxTilesX)
        num3 = Main.maxTilesX - 1;
      if (num2 < 0)
        num2 = 0;
      if (num4 >= Main.maxTilesY)
        num4 = Main.maxTilesY - 1;
      ++Lighting.lightCounter;
      ++Main.renderCount;
      int num5 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
      int num6 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
      Vector2 vector2 = Main.screenLastPosition;
      Lighting.doColors();
      if (Main.renderCount == 2)
      {
        vector2 = Main.screenPosition;
        int num7 = (int) ((double) Main.screenPosition.X / 16.0) - Lighting.scrX;
        int num8 = (int) ((double) Main.screenPosition.Y / 16.0) - Lighting.scrY;
        if (num7 > 4)
          num7 = 0;
        if (num8 > 4)
          num8 = 0;
        if (Lighting.RGB)
        {
          for (int index1 = 0; index1 < num5; ++index1)
          {
            if (index1 + num7 >= 0)
            {
              for (int index2 = 0; index2 < num6; ++index2)
              {
                if (index2 + num8 >= 0)
                {
                  Lighting.color[index1, index2] = Lighting.color2[index1 + num7, index2 + num8];
                  Lighting.colorG[index1, index2] = Lighting.colorG2[index1 + num7, index2 + num8];
                  Lighting.colorB[index1, index2] = Lighting.colorB2[index1 + num7, index2 + num8];
                }
              }
            }
          }
        }
        else
        {
          for (int index3 = 0; index3 < num5; ++index3)
          {
            if (index3 + num7 >= 0)
            {
              for (int index4 = 0; index4 < num6; ++index4)
              {
                if (index4 + num8 >= 0)
                {
                  Lighting.color[index3, index4] = Lighting.color2[index3 + num7, index4 + num8];
                  Lighting.colorG[index3, index4] = Lighting.color2[index3 + num7, index4 + num8];
                  Lighting.colorB[index3, index4] = Lighting.color2[index3 + num7, index4 + num8];
                }
              }
            }
          }
        }
      }
      if (Main.renderCount != 2 && !Lighting.resize && !Main.renderNow)
      {
        if ((double) Math.Abs((float) ((double) Main.screenPosition.X / 16.0 - (double) vector2.X / 16.0)) < 5.0)
        {
          while ((int) ((double) Main.screenPosition.X / 16.0) < (int) ((double) vector2.X / 16.0))
          {
            vector2.X -= 16f;
            for (int index5 = num5 - 1; index5 > 1; --index5)
            {
              for (int index6 = 0; index6 < num6; ++index6)
              {
                Lighting.color[index5, index6] = Lighting.color[index5 - 1, index6];
                Lighting.colorG[index5, index6] = Lighting.colorG[index5 - 1, index6];
                Lighting.colorB[index5, index6] = Lighting.colorB[index5 - 1, index6];
              }
            }
          }
          while ((int) ((double) Main.screenPosition.X / 16.0) > (int) ((double) vector2.X / 16.0))
          {
            vector2.X += 16f;
            for (int index7 = 0; index7 < num5 - 1; ++index7)
            {
              for (int index8 = 0; index8 < num6; ++index8)
              {
                Lighting.color[index7, index8] = Lighting.color[index7 + 1, index8];
                Lighting.colorG[index7, index8] = Lighting.colorG[index7 + 1, index8];
                Lighting.colorB[index7, index8] = Lighting.colorB[index7 + 1, index8];
              }
            }
          }
        }
        if ((double) Math.Abs((float) ((double) Main.screenPosition.Y / 16.0 - (double) vector2.Y / 16.0)) < 5.0)
        {
          while ((int) ((double) Main.screenPosition.Y / 16.0) < (int) ((double) vector2.Y / 16.0))
          {
            vector2.Y -= 16f;
            for (int index9 = num6 - 1; index9 > 1; --index9)
            {
              for (int index10 = 0; index10 < num5; ++index10)
              {
                Lighting.color[index10, index9] = Lighting.color[index10, index9 - 1];
                Lighting.colorG[index10, index9] = Lighting.colorG[index10, index9 - 1];
                Lighting.colorB[index10, index9] = Lighting.colorB[index10, index9 - 1];
              }
            }
          }
          while ((int) ((double) Main.screenPosition.Y / 16.0) > (int) ((double) vector2.Y / 16.0))
          {
            vector2.Y += 16f;
            for (int index11 = 0; index11 < num6 - 1; ++index11)
            {
              for (int index12 = 0; index12 < num5 - 1; ++index12)
              {
                Lighting.color[index12, index11] = Lighting.color[index12, index11 + 1];
                Lighting.colorG[index12, index11] = Lighting.colorG[index12, index11 + 1];
                Lighting.colorB[index12, index11] = Lighting.colorB[index12, index11 + 1];
              }
            }
          }
        }
        if ((double) Lighting.oldSkyColor != (double) Lighting.skyColor)
        {
          for (int firstToLightX = Lighting.firstToLightX; firstToLightX < Lighting.lastToLightX; ++firstToLightX)
          {
            for (int firstToLightY = Lighting.firstToLightY; firstToLightY < Lighting.lastToLightY; ++firstToLightY)
            {
              if (Main.tile[firstToLightX, firstToLightY] == null)
                Main.tile[firstToLightX, firstToLightY] = new Tile();
              if ((!Main.tile[firstToLightX, firstToLightY].active || !Main.tileNoSunLight[(int) Main.tile[firstToLightX, firstToLightY].type]) && (double) Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] < (double) Lighting.skyColor && (Main.tile[firstToLightX, firstToLightY].wall == (byte) 0 || Main.tile[firstToLightX, firstToLightY].wall == (byte) 21) && (double) firstToLightY < Main.worldSurface && Main.tile[firstToLightX, firstToLightY].liquid < (byte) 200)
              {
                if ((double) Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] < (double) Lighting.skyColor)
                  Lighting.color[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] = (float) Main.tileColor.R / (float) byte.MaxValue;
                if ((double) Lighting.colorG[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] < (double) Lighting.skyColor)
                  Lighting.colorG[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] = (float) Main.tileColor.G / (float) byte.MaxValue;
                if ((double) Lighting.colorB[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] < (double) Lighting.skyColor)
                  Lighting.colorB[firstToLightX - Lighting.firstToLightX, firstToLightY - Lighting.firstToLightY] = (float) Main.tileColor.B / (float) byte.MaxValue;
              }
            }
          }
        }
      }
      else
        Lighting.lightCounter = 0;
      if (Main.renderCount <= Lighting.maxRenderCount)
        return;
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
      Lighting.resize = false;
      Main.drawScene = true;
      Lighting.ResetRange();
      Lighting.RGB = Lighting.lightMode == 0 || Lighting.lightMode == 3;
      int num9 = 0;
      int num10 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
      int num11 = 0;
      int num12 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
      for (int index13 = num9; index13 < num10; ++index13)
      {
        for (int index14 = num11; index14 < num12; ++index14)
        {
          Lighting.color2[index13, index14] = 0.0f;
          Lighting.colorG2[index13, index14] = 0.0f;
          Lighting.colorB2[index13, index14] = 0.0f;
          Lighting.stopLight[index13, index14] = false;
          Lighting.wetLight[index13, index14] = false;
        }
      }
      for (int index15 = 0; index15 < Lighting.tempLightCount; ++index15)
      {
        if (Lighting.tempLightX[index15] - Lighting.firstTileX + Lighting.offScreenTiles >= 0 && Lighting.tempLightX[index15] - Lighting.firstTileX + Lighting.offScreenTiles < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && Lighting.tempLightY[index15] - Lighting.firstTileY + Lighting.offScreenTiles >= 0 && Lighting.tempLightY[index15] - Lighting.firstTileY + Lighting.offScreenTiles < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
        {
          int index16 = Lighting.tempLightX[index15] - Lighting.firstTileX + Lighting.offScreenTiles;
          int index17 = Lighting.tempLightY[index15] - Lighting.firstTileY + Lighting.offScreenTiles;
          if ((double) Lighting.color2[index16, index17] < (double) Lighting.tempLight[index15])
            Lighting.color2[index16, index17] = Lighting.tempLight[index15];
          if ((double) Lighting.colorG2[index16, index17] < (double) Lighting.tempLightG[index15])
            Lighting.colorG2[index16, index17] = Lighting.tempLightG[index15];
          if ((double) Lighting.colorB2[index16, index17] < (double) Lighting.tempLightB[index15])
            Lighting.colorB2[index16, index17] = Lighting.tempLightB[index15];
        }
      }
      if (Main.wof >= 0)
      {
        if (Main.player[Main.myPlayer].gross)
        {
          try
          {
            int num13 = (int) Main.screenPosition.Y / 16 - 10;
            int num14 = (int) ((double) Main.screenPosition.Y + (double) Main.screenHeight) / 16 + 10;
            int num15 = (int) Main.npc[Main.wof].position.X / 16;
            int num16 = Main.npc[Main.wof].direction <= 0 ? num15 + 2 : num15 - 3;
            int num17 = num16 + 8;
            float num18 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
            float num19 = 0.3f;
            float num20 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
            float num21 = num18 * 0.2f;
            float num22 = num19 * 0.1f;
            float num23 = num20 * 0.3f;
            for (int index18 = num16; index18 <= num17; ++index18)
            {
              for (int index19 = num13; index19 <= num14; ++index19)
              {
                if ((double) Lighting.color2[index18 - Lighting.firstToLightX, index19 - Lighting.firstToLightY] < (double) num21)
                  Lighting.color2[index18 - Lighting.firstToLightX, index19 - Lighting.firstToLightY] = num21;
                if ((double) Lighting.colorG2[index18 - Lighting.firstToLightX, index19 - Lighting.firstToLightY] < (double) num22)
                  Lighting.colorG2[index18 - Lighting.firstToLightX, index19 - Lighting.firstToLightY] = num22;
                if ((double) Lighting.colorB2[index18 - Lighting.firstToLightX, index19 - Lighting.firstToLightY] < (double) num23)
                  Lighting.colorB2[index18 - Lighting.firstToLightX, index19 - Lighting.firstToLightY] = num23;
              }
            }
          }
          catch
          {
          }
        }
      }
      if (!Main.renderNow)
      {
        Main.oldTempLightCount = Lighting.tempLightCount;
        Lighting.tempLightCount = 0;
      }
      if (Main.gamePaused)
        Lighting.tempLightCount = Main.oldTempLightCount;
      Main.sandTiles = 0;
      Main.evilTiles = 0;
      Main.snowTiles = 0;
      Main.holyTiles = 0;
      Main.meteorTiles = 0;
      Main.jungleTiles = 0;
      Main.dungeonTiles = 0;
      Main.musicBox = -1;
      int firstToLightX1 = Lighting.firstToLightX;
      int lastToLightX = Lighting.lastToLightX;
      int firstToLightY1 = Lighting.firstToLightY;
      int lastToLightY = Lighting.lastToLightY;
      for (int index20 = firstToLightX1; index20 < lastToLightX; ++index20)
      {
        for (int index21 = firstToLightY1; index21 < lastToLightY; ++index21)
        {
          if (Main.tile[index20, index21] == null)
            Main.tile[index20, index21] = new Tile();
          if ((!Main.tile[index20, index21].active || !Main.tileNoSunLight[(int) Main.tile[index20, index21].type]) && (double) Lighting.color2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] < (double) Lighting.skyColor && (Main.tile[index20, index21].wall == (byte) 0 || Main.tile[index20, index21].wall == (byte) 21) && (double) index21 < Main.worldSurface && Main.tile[index20, index21].liquid < (byte) 200)
          {
            if ((double) Lighting.color2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] < (double) Lighting.skyColor)
              Lighting.color2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] = (float) Main.tileColor.R / (float) byte.MaxValue;
            if ((double) Lighting.colorG2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] < (double) Lighting.skyColor)
              Lighting.colorG2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] = (float) Main.tileColor.G / (float) byte.MaxValue;
            if ((double) Lighting.colorB2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] < (double) Lighting.skyColor)
              Lighting.colorB2[index20 - Lighting.firstToLightX, index21 - Lighting.firstToLightY] = (float) Main.tileColor.B / (float) byte.MaxValue;
          }
        }
      }
      for (int index22 = firstToLightX1; index22 < lastToLightX; ++index22)
      {
        for (int index23 = firstToLightY1; index23 < lastToLightY; ++index23)
        {
          int index24 = index22 - Lighting.firstToLightX;
          int index25 = index23 - Lighting.firstToLightY;
          if (Main.tile[index22, index23] == null)
            Main.tile[index22, index23] = new Tile();
          int zoneX = Main.zoneX;
          int zoneY = Main.zoneY;
          int num24 = (lastToLightX - firstToLightX1 - zoneX) / 2;
          int num25 = (lastToLightY - firstToLightY1 - zoneY) / 2;
          if (Main.tile[index22, index23].active)
          {
            if (index22 > firstToLightX1 + num24 && index22 < lastToLightX - num24 && index23 > firstToLightY1 + num25 && index23 < lastToLightY - num25)
            {
              switch (Main.tile[index22, index23].type)
              {
                case 23:
                case 24:
                case 25:
                case 32:
                  ++Main.evilTiles;
                  break;
                case 27:
                  Main.evilTiles -= 5;
                  break;
                case 37:
                  ++Main.meteorTiles;
                  break;
                case 41:
                case 43:
                case 44:
                  ++Main.dungeonTiles;
                  break;
                case 53:
                  ++Main.sandTiles;
                  break;
                case 60:
                case 61:
                case 62:
                case 84:
                  ++Main.jungleTiles;
                  break;
                case 109:
                case 110:
                case 113:
                case 117:
                  ++Main.holyTiles;
                  break;
                case 112:
                  ++Main.sandTiles;
                  ++Main.evilTiles;
                  break;
                case 116:
                  ++Main.sandTiles;
                  ++Main.holyTiles;
                  break;
                case 139:
                  if (Main.tile[index22, index23].frameX >= (short) 36)
                  {
                    int num26 = 0;
                    for (int index26 = (int) Main.tile[index22, index23].frameY / 18; index26 >= 2; index26 -= 2)
                      ++num26;
                    Main.musicBox = num26;
                    break;
                  }
                  break;
                case 147:
                case 148:
                  ++Main.snowTiles;
                  break;
              }
            }
            if (Main.tileBlockLight[(int) Main.tile[index22, index23].type] && Main.tile[index22, index23].type != (byte) 131)
              Lighting.stopLight[index24, index25] = true;
            if (Main.tileLighted[(int) Main.tile[index22, index23].type])
            {
              if (Lighting.RGB)
              {
                switch (Main.tile[index22, index23].type)
                {
                  case 4:
                    float num27 = 1f;
                    float num28 = 0.95f;
                    float num29 = 0.8f;
                    if (Main.tile[index22, index23].frameX < (short) 66)
                    {
                      switch ((int) Main.tile[index22, index23].frameY / 22)
                      {
                        case 1:
                          num27 = 0.0f;
                          num28 = 0.1f;
                          num29 = 1.3f;
                          break;
                        case 2:
                          num27 = 1f;
                          num28 = 0.1f;
                          num29 = 0.1f;
                          break;
                        case 3:
                          num27 = 0.0f;
                          num28 = 1f;
                          num29 = 0.1f;
                          break;
                        case 4:
                          num27 = 0.9f;
                          num28 = 0.0f;
                          num29 = 0.9f;
                          break;
                        case 5:
                          num27 = 1.3f;
                          num28 = 1.3f;
                          num29 = 1.3f;
                          break;
                        case 6:
                          num27 = 0.9f;
                          num28 = 0.9f;
                          num29 = 0.0f;
                          break;
                        case 7:
                          num27 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                          num28 = 0.3f;
                          num29 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                          break;
                        case 8:
                          num29 = 0.7f;
                          num27 = 0.85f;
                          num28 = 1f;
                          break;
                      }
                      if ((double) Lighting.color2[index24, index25] < (double) num27)
                        Lighting.color2[index24, index25] = num27;
                      if ((double) Lighting.colorG2[index24, index25] < (double) num28)
                        Lighting.colorG2[index24, index25] = num28;
                      if ((double) Lighting.colorB2[index24, index25] < (double) num29)
                      {
                        Lighting.colorB2[index24, index25] = num29;
                        break;
                      }
                      break;
                    }
                    break;
                  case 17:
                  case 133:
                    if ((double) Lighting.color2[index24, index25] < 0.829999983310699)
                      Lighting.color2[index24, index25] = 0.83f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.600000023841858)
                      Lighting.colorG2[index24, index25] = 0.6f;
                    if ((double) Lighting.colorB2[index24, index25] < 0.5)
                    {
                      Lighting.colorB2[index24, index25] = 0.5f;
                      break;
                    }
                    break;
                  case 22:
                  case 140:
                    if ((double) Lighting.color2[index24, index25] < 0.12)
                      Lighting.color2[index24, index25] = 0.12f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.07)
                      Lighting.colorG2[index24, index25] = 0.07f;
                    if ((double) Lighting.colorB2[index24, index25] < 0.32)
                    {
                      Lighting.colorB2[index24, index25] = 0.32f;
                      break;
                    }
                    break;
                  case 26:
                  case 31:
                    float num30 = (float) Main.rand.Next(-5, 6) * (1f / 400f);
                    if ((double) Lighting.color2[index24, index25] < 0.310000002384186 + (double) num30)
                      Lighting.color2[index24, index25] = 0.31f + num30;
                    if ((double) Lighting.colorG2[index24, index25] < 0.100000001490116 + (double) num30)
                      Lighting.colorG2[index24, index25] = 0.1f;
                    if ((double) Lighting.colorB2[index24, index25] < 0.439999997615814 + (double) num30 * 2.0)
                    {
                      Lighting.colorB2[index24, index25] = (float) (0.439999997615814 + (double) num30 * 2.0);
                      break;
                    }
                    break;
                  case 33:
                    if (Main.tile[index22, index23].frameX == (short) 0)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.95)
                        Lighting.colorG2[index24, index25] = 0.95f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.65)
                      {
                        Lighting.colorB2[index24, index25] = 0.65f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 34:
                  case 35:
                    if (Main.tile[index22, index23].frameX < (short) 54)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.95)
                        Lighting.colorG2[index24, index25] = 0.95f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.8)
                      {
                        Lighting.colorB2[index24, index25] = 0.8f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 36:
                    if (Main.tile[index22, index23].frameX < (short) 54)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.95)
                        Lighting.colorG2[index24, index25] = 0.95f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.65)
                      {
                        Lighting.colorB2[index24, index25] = 0.65f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 37:
                    if ((double) Lighting.color2[index24, index25] < 0.56)
                      Lighting.color2[index24, index25] = 0.56f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.43)
                      Lighting.colorG2[index24, index25] = 0.43f;
                    if ((double) Lighting.colorB2[index24, index25] < 0.15)
                    {
                      Lighting.colorB2[index24, index25] = 0.15f;
                      break;
                    }
                    break;
                  case 42:
                    if (Main.tile[index22, index23].frameX == (short) 0)
                    {
                      if ((double) Lighting.color2[index24, index25] < 0.649999976158142)
                        Lighting.color2[index24, index25] = 0.65f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.800000011920929)
                        Lighting.colorG2[index24, index25] = 0.8f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.540000021457672)
                      {
                        Lighting.colorB2[index24, index25] = 0.54f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 49:
                    if ((double) Lighting.color2[index24, index25] < 0.300000011920929)
                      Lighting.color2[index24, index25] = 0.3f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.300000011920929)
                      Lighting.colorG2[index24, index25] = 0.3f;
                    if ((double) Lighting.colorB2[index24, index25] < 0.75)
                    {
                      Lighting.colorB2[index24, index25] = 0.75f;
                      break;
                    }
                    break;
                  case 61:
                    if (Main.tile[index22, index23].frameX == (short) 144)
                    {
                      if ((double) Lighting.color2[index24, index25] < 0.419999986886978)
                        Lighting.color2[index24, index25] = 0.42f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.810000002384186)
                        Lighting.colorG2[index24, index25] = 0.81f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.519999980926514)
                      {
                        Lighting.colorB2[index24, index25] = 0.52f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 70:
                  case 71:
                  case 72:
                    float num31 = (float) Main.rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 500f;
                    if ((double) Lighting.color2[index24, index25] < 0.100000001490116 + (double) num31)
                      Lighting.color2[index24, index25] = 0.1f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.300000011920929 + (double) num31 / 2.0)
                      Lighting.colorG2[index24, index25] = (float) (0.300000011920929 + (double) num31 / 2.0);
                    if ((double) Lighting.colorB2[index24, index25] < 0.600000023841858 + (double) num31)
                    {
                      Lighting.colorB2[index24, index25] = 0.6f + num31;
                      break;
                    }
                    break;
                  case 77:
                    if ((double) Lighting.color2[index24, index25] < 0.75)
                      Lighting.color2[index24, index25] = 0.75f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.449999988079071)
                      Lighting.colorG2[index24, index25] = 0.45f;
                    if ((double) Lighting.colorB2[index24, index25] < 0.25)
                    {
                      Lighting.colorB2[index24, index25] = 0.25f;
                      break;
                    }
                    break;
                  case 83:
                    if (Main.tile[index22, index23].frameX == (short) 18 && !Main.dayTime)
                    {
                      if ((double) Lighting.color2[index24, index25] < 0.1)
                        Lighting.color2[index24, index25] = 0.1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.4)
                        Lighting.colorG2[index24, index25] = 0.4f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.6)
                      {
                        Lighting.colorB2[index24, index25] = 0.6f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 84:
                    switch ((int) Main.tile[index22, index23].frameX / 18)
                    {
                      case 2:
                        float num32 = (float) (270 - (int) Main.mouseTextColor) / 800f;
                        if ((double) num32 > 1.0)
                          num32 = 1f;
                        if ((double) num32 < 0.0)
                          num32 = 0.0f;
                        float num33 = num32;
                        if ((double) Lighting.color2[index24, index25] < (double) num33 * 0.699999988079071)
                          Lighting.color2[index24, index25] = num33 * 0.7f;
                        if ((double) Lighting.colorG2[index24, index25] < (double) num33)
                          Lighting.colorG2[index24, index25] = num33;
                        if ((double) Lighting.colorB2[index24, index25] < (double) num33 * 0.100000001490116)
                        {
                          Lighting.colorB2[index24, index25] = num33 * 0.1f;
                          break;
                        }
                        break;
                      case 5:
                        float num34 = 0.9f;
                        if ((double) Lighting.color2[index24, index25] < (double) num34)
                          Lighting.color2[index24, index25] = num34;
                        if ((double) Lighting.colorG2[index24, index25] < (double) num34 * 0.800000011920929)
                          Lighting.colorG2[index24, index25] = num34 * 0.8f;
                        if ((double) Lighting.colorB2[index24, index25] < (double) num34 * 0.200000002980232)
                        {
                          Lighting.colorB2[index24, index25] = num34 * 0.2f;
                          break;
                        }
                        break;
                    }
                    break;
                  case 92:
                    if (Main.tile[index22, index23].frameY <= (short) 18 && Main.tile[index22, index23].frameX == (short) 0)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 1.0)
                        Lighting.colorG2[index24, index25] = 1f;
                      if ((double) Lighting.colorB2[index24, index25] < 1.0)
                      {
                        Lighting.colorB2[index24, index25] = 1f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 93:
                    if (Main.tile[index22, index23].frameY == (short) 0 && Main.tile[index22, index23].frameX == (short) 0)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.97)
                        Lighting.colorG2[index24, index25] = 0.97f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.85)
                      {
                        Lighting.colorB2[index24, index25] = 0.85f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 95:
                    if (Main.tile[index22, index23].frameX < (short) 36)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.95)
                        Lighting.colorG2[index24, index25] = 0.95f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.8)
                      {
                        Lighting.colorB2[index24, index25] = 0.8f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 98:
                    if (Main.tile[index22, index23].frameY == (short) 0)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.97)
                        Lighting.colorG2[index24, index25] = 0.97f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.85)
                      {
                        Lighting.colorB2[index24, index25] = 0.85f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 100:
                    if (Main.tile[index22, index23].frameX < (short) 36)
                    {
                      if ((double) Lighting.color2[index24, index25] < 1.0)
                        Lighting.color2[index24, index25] = 1f;
                      if ((double) Lighting.colorG2[index24, index25] < 0.95)
                        Lighting.colorG2[index24, index25] = 0.95f;
                      if ((double) Lighting.colorB2[index24, index25] < 0.65)
                      {
                        Lighting.colorB2[index24, index25] = 0.65f;
                        break;
                      }
                      break;
                    }
                    break;
                  case 125:
                    float num35 = (float) Main.rand.Next(28, 42) * 0.01f + (float) (270 - (int) Main.mouseTextColor) / 800f;
                    if ((double) Lighting.colorG2[index24, index25] < 0.1 * (double) num35)
                      Lighting.colorG2[index24, index25] = 0.3f * num35;
                    if ((double) Lighting.colorB2[index24, index25] < 0.3 * (double) num35)
                    {
                      Lighting.colorB2[index24, index25] = 0.6f * num35;
                      break;
                    }
                    break;
                  case 126:
                    if (Main.tile[index22, index23].frameX < (short) 36)
                    {
                      if ((double) Lighting.color2[index24, index25] < (double) Main.DiscoR / (double) byte.MaxValue)
                        Lighting.color2[index24, index25] = (float) Main.DiscoR / (float) byte.MaxValue;
                      if ((double) Lighting.colorG2[index24, index25] < (double) Main.DiscoG / (double) byte.MaxValue)
                        Lighting.colorG2[index24, index25] = (float) Main.DiscoG / (float) byte.MaxValue;
                      if ((double) Lighting.colorB2[index24, index25] < (double) Main.DiscoB / (double) byte.MaxValue)
                      {
                        Lighting.colorB2[index24, index25] = (float) Main.DiscoB / (float) byte.MaxValue;
                        break;
                      }
                      break;
                    }
                    break;
                  case 129:
                    float num36;
                    float num37;
                    float num38;
                    if (Main.tile[index22, index23].frameX == (short) 0 || Main.tile[index22, index23].frameX == (short) 54 || Main.tile[index22, index23].frameX == (short) 108)
                    {
                      num36 = 0.05f;
                      num37 = 0.25f;
                      num38 = 0.0f;
                    }
                    else if (Main.tile[index22, index23].frameX == (short) 18 || Main.tile[index22, index23].frameX == (short) 72 || Main.tile[index22, index23].frameX == (short) 126)
                    {
                      num38 = 0.2f;
                      num37 = 0.15f;
                      num36 = 0.0f;
                    }
                    else
                    {
                      num37 = 0.2f;
                      num38 = 0.1f;
                      num36 = 0.0f;
                    }
                    if ((double) Lighting.color2[index24, index25] < (double) num38)
                      Lighting.color2[index24, index25] = (float) ((double) num38 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                    if ((double) Lighting.colorG2[index24, index25] < (double) num36)
                      Lighting.colorG2[index24, index25] = (float) ((double) num36 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                    if ((double) Lighting.colorB2[index24, index25] < (double) num37)
                    {
                      Lighting.colorB2[index24, index25] = (float) ((double) num37 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                      break;
                    }
                    break;
                  case 149:
                    float num39;
                    float num40;
                    float num41;
                    if (Main.tile[index22, index23].frameX == (short) 0)
                    {
                      num39 = 0.2f;
                      num40 = 0.5f;
                      num41 = 0.1f;
                    }
                    else if (Main.tile[index22, index23].frameX == (short) 18)
                    {
                      num41 = 0.5f;
                      num40 = 0.1f;
                      num39 = 0.1f;
                    }
                    else
                    {
                      num40 = 0.1f;
                      num41 = 0.2f;
                      num39 = 0.5f;
                    }
                    if (Main.tile[index22, index23].frameX <= (short) 36)
                    {
                      if ((double) Lighting.color2[index24, index25] < (double) num41)
                        Lighting.color2[index24, index25] = (float) ((double) num41 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                      if ((double) Lighting.colorG2[index24, index25] < (double) num39)
                        Lighting.colorG2[index24, index25] = (float) ((double) num39 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                      if ((double) Lighting.colorB2[index24, index25] < (double) num40)
                      {
                        Lighting.colorB2[index24, index25] = (float) ((double) num40 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                        break;
                      }
                      break;
                    }
                    break;
                }
              }
              else
              {
                switch (Main.tile[index22, index23].type)
                {
                  case 4:
                    if (Main.tile[index22, index23].frameX < (short) 66)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 17:
                  case 133:
                    if ((double) Lighting.color2[index24, index25] < 0.75)
                    {
                      Lighting.color2[index24, index25] = 0.75f;
                      break;
                    }
                    break;
                  case 22:
                    if ((double) Lighting.color2[index24, index25] < 0.200000002980232)
                    {
                      Lighting.color2[index24, index25] = 0.2f;
                      break;
                    }
                    break;
                  case 26:
                  case 31:
                    float num42 = (float) Main.rand.Next(-5, 6) * 0.01f;
                    if ((double) Lighting.color2[index24, index25] < 0.400000005960464 + (double) num42)
                    {
                      Lighting.color2[index24, index25] = 0.4f + num42;
                      break;
                    }
                    break;
                  case 33:
                    if (Main.tile[index22, index23].frameX == (short) 0)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 34:
                  case 35:
                  case 36:
                    if (Main.tile[index22, index23].frameX < (short) 54)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 37:
                    if ((double) Lighting.color2[index24, index25] < 0.5)
                    {
                      Lighting.color2[index24, index25] = 0.5f;
                      break;
                    }
                    break;
                  case 42:
                    if (Main.tile[index22, index23].frameX == (short) 0)
                    {
                      Lighting.color2[index24, index25] = 0.75f;
                      break;
                    }
                    break;
                  case 49:
                    if ((double) Lighting.color2[index24, index25] < 0.100000001490116)
                    {
                      Lighting.color2[index24, index25] = 0.7f;
                      break;
                    }
                    break;
                  case 61:
                    if (Main.tile[index22, index23].frameX == (short) 144 && (double) Lighting.color2[index24, index25] < 0.75)
                    {
                      Lighting.color2[index24, index25] = 0.75f;
                      break;
                    }
                    break;
                  case 70:
                  case 71:
                  case 72:
                    float num43 = (float) Main.rand.Next(38, 43) * 0.01f;
                    if ((double) Lighting.color2[index24, index25] < (double) num43)
                    {
                      Lighting.color2[index24, index25] = num43;
                      break;
                    }
                    break;
                  case 77:
                    if ((double) Lighting.color2[index24, index25] < 0.600000023841858)
                    {
                      Lighting.color2[index24, index25] = 0.6f;
                      break;
                    }
                    break;
                  case 84:
                    int num44 = (int) Main.tile[index22, index23].frameX / 18;
                    float num45 = 0.0f;
                    switch (num44)
                    {
                      case 2:
                        float num46 = (float) (270 - (int) Main.mouseTextColor) / 500f;
                        if ((double) num46 > 1.0)
                          num46 = 1f;
                        if ((double) num46 < 0.0)
                          num46 = 0.0f;
                        num45 = num46;
                        break;
                      case 5:
                        num45 = 0.7f;
                        break;
                    }
                    if ((double) Lighting.color2[index24, index25] < (double) num45)
                    {
                      Lighting.color2[index24, index25] = num45;
                      break;
                    }
                    break;
                  case 92:
                    if (Main.tile[index22, index23].frameY <= (short) 18 && Main.tile[index22, index23].frameX == (short) 0)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 93:
                    if (Main.tile[index22, index23].frameY == (short) 0 && Main.tile[index22, index23].frameX == (short) 0)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 95:
                    if (Main.tile[index22, index23].frameX < (short) 36 && (double) Lighting.color2[index24, index25] < 0.850000023841858)
                    {
                      Lighting.color2[index24, index25] = 0.9f;
                      break;
                    }
                    break;
                  case 98:
                    if (Main.tile[index22, index23].frameY == (short) 0)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 100:
                    if (Main.tile[index22, index23].frameX < (short) 36)
                    {
                      Lighting.color2[index24, index25] = 1f;
                      break;
                    }
                    break;
                  case 125:
                    float num47 = (float) Main.rand.Next(28, 42) * 0.007f + (float) (270 - (int) Main.mouseTextColor) / 900f;
                    if ((double) Lighting.color2[index24, index25] < 0.5 * (double) num47)
                    {
                      Lighting.color2[index24, index25] = 0.3f * num47;
                      break;
                    }
                    break;
                  case 126:
                    if (Main.tile[index22, index23].frameX < (short) 36 && (double) Lighting.color2[index24, index25] < 0.300000011920929)
                    {
                      Lighting.color2[index24, index25] = 0.3f;
                      break;
                    }
                    break;
                  case 129:
                    float num48 = 0.08f;
                    if ((double) Lighting.color2[index24, index25] < (double) num48)
                    {
                      Lighting.color2[index24, index25] = (float) ((double) num48 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                      break;
                    }
                    break;
                  case 149:
                    if (Main.tile[index22, index23].frameX <= (short) 36)
                    {
                      float num49 = 0.4f;
                      if ((double) Lighting.color2[index24, index25] < (double) num49)
                      {
                        Lighting.color2[index24, index25] = (float) ((double) num49 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                        break;
                      }
                      break;
                    }
                    break;
                }
              }
            }
          }
          if (Main.tile[index22, index23].lava && Main.tile[index22, index23].liquid > (byte) 0)
          {
            if (Lighting.RGB)
            {
              float num50 = (float) ((double) ((int) Main.tile[index22, index23].liquid / (int) byte.MaxValue) * 0.409999996423721 + 0.140000000596046);
              float num51 = 0.55f + (float) (270 - (int) Main.mouseTextColor) / 900f;
              if ((double) Lighting.color2[index24, index25] < (double) num51)
                Lighting.color2[index24, index25] = num51;
              if ((double) Lighting.colorG2[index24, index25] < (double) num51)
                Lighting.colorG2[index24, index25] = num51 * 0.6f;
              if ((double) Lighting.colorB2[index24, index25] < (double) num51)
                Lighting.colorB2[index24, index25] = num51 * 0.2f;
            }
            else
            {
              float num52 = (float) ((double) ((int) Main.tile[index22, index23].liquid / (int) byte.MaxValue) * 0.379999995231628 + 0.0799999982118607) + (float) (270 - (int) Main.mouseTextColor) / 2000f;
              if ((double) Lighting.color2[index24, index25] < (double) num52)
                Lighting.color2[index24, index25] = num52;
            }
          }
          else if (Main.tile[index22, index23].liquid > (byte) 128)
            Lighting.wetLight[index24, index25] = true;
          if (Lighting.RGB)
          {
            if ((double) Lighting.color2[index24, index25] > 0.0 || (double) Lighting.colorG2[index24, index25] > 0.0 || (double) Lighting.colorB2[index24, index25] > 0.0)
            {
              if (Lighting.minX > index24)
                Lighting.minX = index24;
              if (Lighting.maxX < index24 + 1)
                Lighting.maxX = index24 + 1;
              if (Lighting.minY > index25)
                Lighting.minY = index25;
              if (Lighting.maxY < index25 + 1)
                Lighting.maxY = index25 + 1;
            }
          }
          else if ((double) Lighting.color2[index24, index25] > 0.0)
          {
            if (Lighting.minX > index24)
              Lighting.minX = index24;
            if (Lighting.maxX < index24 + 1)
              Lighting.maxX = index24 + 1;
            if (Lighting.minY > index25)
              Lighting.minY = index25;
            if (Lighting.maxY < index25 + 1)
              Lighting.maxY = index25 + 1;
          }
        }
      }
      if (Main.holyTiles < 0)
        Main.holyTiles = 0;
      if (Main.evilTiles < 0)
        Main.evilTiles = 0;
      int holyTiles = Main.holyTiles;
      Main.holyTiles -= Main.evilTiles;
      Main.evilTiles -= holyTiles;
      if (Main.holyTiles < 0)
        Main.holyTiles = 0;
      if (Main.evilTiles < 0)
        Main.evilTiles = 0;
      Lighting.minX += Lighting.firstToLightX;
      Lighting.maxX += Lighting.firstToLightX;
      Lighting.minY += Lighting.firstToLightY;
      Lighting.maxY += Lighting.firstToLightY;
      Lighting.minX7 = Lighting.minX;
      Lighting.maxX7 = Lighting.maxX;
      Lighting.minY7 = Lighting.minY;
      Lighting.maxY7 = Lighting.maxY;
      Lighting.firstTileX7 = Lighting.firstTileX;
      Lighting.lastTileX7 = Lighting.lastTileX;
      Lighting.lastTileY7 = Lighting.lastTileY;
      Lighting.firstTileY7 = Lighting.firstTileY;
      Lighting.firstToLightX7 = Lighting.firstToLightX;
      Lighting.lastToLightX7 = Lighting.lastToLightX;
      Lighting.firstToLightY7 = Lighting.firstToLightY;
      Lighting.lastToLightY7 = Lighting.lastToLightY;
      Lighting.firstToLightX27 = num1;
      Lighting.lastToLightX27 = num3;
      Lighting.firstToLightY27 = num2;
      Lighting.lastToLightY27 = num4;
      Lighting.scrX = (int) Main.screenPosition.X / 16;
      Lighting.scrY = (int) Main.screenPosition.Y / 16;
      Main.renderCount = 0;
      Main.lightTimer[0] = (float) stopwatch.ElapsedMilliseconds;
      Lighting.doColors();
    }

    public static void doColors()
    {
      Stopwatch stopwatch = new Stopwatch();
      if (Lighting.lightMode < 2)
      {
        Lighting.blueWave += (float) Lighting.blueDir * 0.0005f;
        if ((double) Lighting.blueWave > 1.0)
        {
          Lighting.blueWave = 1f;
          Lighting.blueDir = -1;
        }
        else if ((double) Lighting.blueWave < 0.970000028610229)
        {
          Lighting.blueWave = 0.97f;
          Lighting.blueDir = 1;
        }
        if (Lighting.RGB)
        {
          Lighting.negLight = 0.91f;
          Lighting.negLight2 = 0.56f;
          Lighting.wetLightG = 0.97f * Lighting.negLight * Lighting.blueWave;
          Lighting.wetLightR = 0.88f * Lighting.negLight * Lighting.blueWave;
        }
        else
        {
          Lighting.negLight = 0.9f;
          Lighting.negLight2 = 0.54f;
          Lighting.wetLightR = 0.95f * Lighting.negLight * Lighting.blueWave;
        }
        if (Main.player[Main.myPlayer].nightVision)
        {
          Lighting.negLight *= 1.03f;
          Lighting.negLight2 *= 1.03f;
        }
        if (Main.player[Main.myPlayer].blind)
        {
          Lighting.negLight *= 0.95f;
          Lighting.negLight2 *= 0.95f;
        }
        if (Lighting.RGB)
        {
          if (Main.renderCount == 0)
          {
            stopwatch.Restart();
            for (int minX7 = Lighting.minX7; minX7 < Lighting.maxX7; ++minX7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int minY7 = Lighting.minY7; minY7 < Lighting.lastToLightY27 + Lighting.maxRenderCount; ++minY7)
              {
                Lighting.LightColor(minX7, minY7);
                Lighting.LightColorG(minX7, minY7);
                Lighting.LightColorB(minX7, minY7);
              }
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int maxY7 = Lighting.maxY7; maxY7 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --maxY7)
              {
                Lighting.LightColor(minX7, maxY7);
                Lighting.LightColorG(minX7, maxY7);
                Lighting.LightColorB(minX7, maxY7);
              }
            }
            Main.lightTimer[1] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightY7 = Lighting.firstToLightY7; firstToLightY7 < Lighting.lastToLightY7; ++firstToLightY7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 1;
              Lighting.dirY = 0;
              for (int minX7 = Lighting.minX7; minX7 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++minX7)
              {
                Lighting.LightColor(minX7, firstToLightY7);
                Lighting.LightColorG(minX7, firstToLightY7);
                Lighting.LightColorB(minX7, firstToLightY7);
              }
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = -1;
              Lighting.dirY = 0;
              for (int maxX7 = Lighting.maxX7; maxX7 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --maxX7)
              {
                Lighting.LightColor(maxX7, firstToLightY7);
                Lighting.LightColorG(maxX7, firstToLightY7);
                Lighting.LightColorB(maxX7, firstToLightY7);
              }
            }
            Main.lightTimer[2] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastToLightX27; ++firstToLightX27)
            {
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastTileY7 + Lighting.maxRenderCount; ++firstToLightY27)
              {
                Lighting.LightColor(firstToLightX27, firstToLightY27);
                Lighting.LightColorG(firstToLightX27, firstToLightY27);
                Lighting.LightColorB(firstToLightX27, firstToLightY27);
              }
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int lastToLightY27 = Lighting.lastToLightY27; lastToLightY27 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --lastToLightY27)
              {
                Lighting.LightColor(firstToLightX27, lastToLightY27);
                Lighting.LightColorG(firstToLightX27, lastToLightY27);
                Lighting.LightColorB(firstToLightX27, lastToLightY27);
              }
            }
            Main.lightTimer[3] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount != 2)
            return;
          stopwatch.Restart();
          for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastToLightY27; ++firstToLightY27)
          {
            Lighting.lightColor = 0.0f;
            Lighting.lightColorG = 0.0f;
            Lighting.lightColorB = 0.0f;
            Lighting.dirX = 1;
            Lighting.dirY = 0;
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++firstToLightX27)
            {
              Lighting.LightColor(firstToLightX27, firstToLightY27);
              Lighting.LightColorG(firstToLightX27, firstToLightY27);
              Lighting.LightColorB(firstToLightX27, firstToLightY27);
            }
            Lighting.lightColor = 0.0f;
            Lighting.lightColorG = 0.0f;
            Lighting.lightColorB = 0.0f;
            Lighting.dirX = -1;
            Lighting.dirY = 0;
            for (int lastToLightX27 = Lighting.lastToLightX27; lastToLightX27 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --lastToLightX27)
            {
              Lighting.LightColor(lastToLightX27, firstToLightY27);
              Lighting.LightColorG(lastToLightX27, firstToLightY27);
              Lighting.LightColorB(lastToLightX27, firstToLightY27);
            }
          }
          Main.lightTimer[4] = (float) stopwatch.ElapsedMilliseconds;
        }
        else
        {
          if (Main.renderCount == 0)
          {
            stopwatch.Restart();
            for (int minX7 = Lighting.minX7; minX7 < Lighting.maxX7; ++minX7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int minY7 = Lighting.minY7; minY7 < Lighting.lastToLightY27 + Lighting.maxRenderCount; ++minY7)
                Lighting.LightColor(minX7, minY7);
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int maxY7 = Lighting.maxY7; maxY7 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --maxY7)
                Lighting.LightColor(minX7, maxY7);
            }
            Main.lightTimer[1] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightY7 = Lighting.firstToLightY7; firstToLightY7 < Lighting.lastToLightY7; ++firstToLightY7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 1;
              Lighting.dirY = 0;
              for (int minX7 = Lighting.minX7; minX7 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++minX7)
                Lighting.LightColor(minX7, firstToLightY7);
              Lighting.lightColor = 0.0f;
              Lighting.dirX = -1;
              Lighting.dirY = 0;
              for (int maxX7 = Lighting.maxX7; maxX7 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --maxX7)
                Lighting.LightColor(maxX7, firstToLightY7);
            }
            Main.lightTimer[2] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastToLightX27; ++firstToLightX27)
            {
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastTileY7 + Lighting.maxRenderCount; ++firstToLightY27)
                Lighting.LightColor(firstToLightX27, firstToLightY27);
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int lastToLightY27 = Lighting.lastToLightY27; lastToLightY27 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --lastToLightY27)
                Lighting.LightColor(firstToLightX27, lastToLightY27);
            }
            Main.lightTimer[3] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount != 2)
            return;
          stopwatch.Restart();
          for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastToLightY27; ++firstToLightY27)
          {
            Lighting.lightColor = 0.0f;
            Lighting.dirX = 1;
            Lighting.dirY = 0;
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++firstToLightX27)
              Lighting.LightColor(firstToLightX27, firstToLightY27);
            Lighting.lightColor = 0.0f;
            Lighting.dirX = -1;
            Lighting.dirY = 0;
            for (int lastToLightX27 = Lighting.lastToLightX27; lastToLightX27 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --lastToLightX27)
              Lighting.LightColor(lastToLightX27, firstToLightY27);
          }
          Main.lightTimer[4] = (float) stopwatch.ElapsedMilliseconds;
        }
      }
      else
      {
        Lighting.negLight = 0.04f;
        Lighting.negLight2 = 0.16f;
        if (Main.player[Main.myPlayer].nightVision)
        {
          Lighting.negLight -= 0.013f;
          Lighting.negLight2 -= 0.04f;
        }
        if (Main.player[Main.myPlayer].blind)
        {
          Lighting.negLight += 0.03f;
          Lighting.negLight2 += 0.06f;
        }
        Lighting.wetLightR = Lighting.negLight * 1.2f;
        Lighting.wetLightG = Lighting.negLight * 1.1f;
        if (Lighting.RGB)
        {
          if (Main.renderCount == 0)
          {
            stopwatch.Restart();
            for (int minX7 = Lighting.minX7; minX7 < Lighting.maxX7; ++minX7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int minY7 = Lighting.minY7; minY7 < Lighting.lastToLightY27 + Lighting.maxRenderCount; ++minY7)
              {
                Lighting.LightColor2(minX7, minY7);
                Lighting.LightColorG2(minX7, minY7);
                Lighting.LightColorB2(minX7, minY7);
              }
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int maxY7 = Lighting.maxY7; maxY7 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --maxY7)
              {
                Lighting.LightColor2(minX7, maxY7);
                Lighting.LightColorG2(minX7, maxY7);
                Lighting.LightColorB2(minX7, maxY7);
              }
            }
            Main.lightTimer[1] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightY7 = Lighting.firstToLightY7; firstToLightY7 < Lighting.lastToLightY7; ++firstToLightY7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 1;
              Lighting.dirY = 0;
              for (int minX7 = Lighting.minX7; minX7 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++minX7)
              {
                Lighting.LightColor2(minX7, firstToLightY7);
                Lighting.LightColorG2(minX7, firstToLightY7);
                Lighting.LightColorB2(minX7, firstToLightY7);
              }
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = -1;
              Lighting.dirY = 0;
              for (int maxX7 = Lighting.maxX7; maxX7 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --maxX7)
              {
                Lighting.LightColor2(maxX7, firstToLightY7);
                Lighting.LightColorG2(maxX7, firstToLightY7);
                Lighting.LightColorB2(maxX7, firstToLightY7);
              }
            }
            Main.lightTimer[2] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastToLightX27; ++firstToLightX27)
            {
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastTileY7 + Lighting.maxRenderCount; ++firstToLightY27)
              {
                Lighting.LightColor2(firstToLightX27, firstToLightY27);
                Lighting.LightColorG2(firstToLightX27, firstToLightY27);
                Lighting.LightColorB2(firstToLightX27, firstToLightY27);
              }
              Lighting.lightColor = 0.0f;
              Lighting.lightColorG = 0.0f;
              Lighting.lightColorB = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int lastToLightY27 = Lighting.lastToLightY27; lastToLightY27 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --lastToLightY27)
              {
                Lighting.LightColor2(firstToLightX27, lastToLightY27);
                Lighting.LightColorG2(firstToLightX27, lastToLightY27);
                Lighting.LightColorB2(firstToLightX27, lastToLightY27);
              }
            }
            Main.lightTimer[3] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount != 2)
            return;
          stopwatch.Restart();
          for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastToLightY27; ++firstToLightY27)
          {
            Lighting.lightColor = 0.0f;
            Lighting.lightColorG = 0.0f;
            Lighting.lightColorB = 0.0f;
            Lighting.dirX = 1;
            Lighting.dirY = 0;
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++firstToLightX27)
            {
              Lighting.LightColor2(firstToLightX27, firstToLightY27);
              Lighting.LightColorG2(firstToLightX27, firstToLightY27);
              Lighting.LightColorB2(firstToLightX27, firstToLightY27);
            }
            Lighting.lightColor = 0.0f;
            Lighting.lightColorG = 0.0f;
            Lighting.lightColorB = 0.0f;
            Lighting.dirX = -1;
            Lighting.dirY = 0;
            for (int lastToLightX27 = Lighting.lastToLightX27; lastToLightX27 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --lastToLightX27)
            {
              Lighting.LightColor2(lastToLightX27, firstToLightY27);
              Lighting.LightColorG2(lastToLightX27, firstToLightY27);
              Lighting.LightColorB2(lastToLightX27, firstToLightY27);
            }
          }
          Main.lightTimer[4] = (float) stopwatch.ElapsedMilliseconds;
        }
        else
        {
          if (Main.renderCount == 0)
          {
            stopwatch.Restart();
            for (int minX7 = Lighting.minX7; minX7 < Lighting.maxX7; ++minX7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int minY7 = Lighting.minY7; minY7 < Lighting.lastToLightY27 + Lighting.maxRenderCount; ++minY7)
                Lighting.LightColor2(minX7, minY7);
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int maxY7 = Lighting.maxY7; maxY7 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --maxY7)
                Lighting.LightColor2(minX7, maxY7);
            }
            Main.lightTimer[1] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightY7 = Lighting.firstToLightY7; firstToLightY7 < Lighting.lastToLightY7; ++firstToLightY7)
            {
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 1;
              Lighting.dirY = 0;
              for (int minX7 = Lighting.minX7; minX7 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++minX7)
                Lighting.LightColor2(minX7, firstToLightY7);
              Lighting.lightColor = 0.0f;
              Lighting.dirX = -1;
              Lighting.dirY = 0;
              for (int maxX7 = Lighting.maxX7; maxX7 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --maxX7)
                Lighting.LightColor2(maxX7, firstToLightY7);
            }
            Main.lightTimer[2] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount == 1)
          {
            stopwatch.Restart();
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastToLightX27; ++firstToLightX27)
            {
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = 1;
              for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastTileY7 + Lighting.maxRenderCount; ++firstToLightY27)
                Lighting.LightColor2(firstToLightX27, firstToLightY27);
              Lighting.lightColor = 0.0f;
              Lighting.dirX = 0;
              Lighting.dirY = -1;
              for (int lastToLightY27 = Lighting.lastToLightY27; lastToLightY27 >= Lighting.firstTileY7 - Lighting.maxRenderCount; --lastToLightY27)
                Lighting.LightColor2(firstToLightX27, lastToLightY27);
            }
            Main.lightTimer[3] = (float) stopwatch.ElapsedMilliseconds;
          }
          if (Main.renderCount != 2)
            return;
          stopwatch.Restart();
          for (int firstToLightY27 = Lighting.firstToLightY27; firstToLightY27 < Lighting.lastToLightY27; ++firstToLightY27)
          {
            Lighting.lightColor = 0.0f;
            Lighting.dirX = 1;
            Lighting.dirY = 0;
            for (int firstToLightX27 = Lighting.firstToLightX27; firstToLightX27 < Lighting.lastTileX7 + Lighting.maxRenderCount; ++firstToLightX27)
              Lighting.LightColor2(firstToLightX27, firstToLightY27);
            Lighting.lightColor = 0.0f;
            Lighting.dirX = -1;
            Lighting.dirY = 0;
            for (int lastToLightX27 = Lighting.lastToLightX27; lastToLightX27 >= Lighting.firstTileX7 - Lighting.maxRenderCount; --lastToLightX27)
              Lighting.LightColor2(lastToLightX27, firstToLightY27);
          }
          Main.lightTimer[4] = (float) stopwatch.ElapsedMilliseconds;
        }
      }
    }

    public static void addLight(int i, int j, float Lightness)
    {
      if (Main.netMode == 2 || i - Lighting.firstTileX + Lighting.offScreenTiles < 0 || i - Lighting.firstTileX + Lighting.offScreenTiles >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || j - Lighting.firstTileY + Lighting.offScreenTiles < 0 || j - Lighting.firstTileY + Lighting.offScreenTiles >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 || Lighting.tempLightCount == Lighting.maxTempLights)
        return;
      if (!Lighting.RGB)
      {
        for (int index = 0; index < Lighting.tempLightCount; ++index)
        {
          if (Lighting.tempLightX[index] == i && Lighting.tempLightY[index] == j && (double) Lightness <= (double) Lighting.tempLight[index])
            return;
        }
        Lighting.tempLightX[Lighting.tempLightCount] = i;
        Lighting.tempLightY[Lighting.tempLightCount] = j;
        Lighting.tempLight[Lighting.tempLightCount] = Lightness;
        Lighting.tempLightG[Lighting.tempLightCount] = Lightness;
        Lighting.tempLightB[Lighting.tempLightCount] = Lightness;
        ++Lighting.tempLightCount;
      }
      else
      {
        Lighting.tempLight[Lighting.tempLightCount] = Lightness;
        Lighting.tempLightG[Lighting.tempLightCount] = Lightness;
        Lighting.tempLightB[Lighting.tempLightCount] = Lightness;
        Lighting.tempLightX[Lighting.tempLightCount] = i;
        Lighting.tempLightY[Lighting.tempLightCount] = j;
        ++Lighting.tempLightCount;
      }
    }

    public static void addLight(int i, int j, float R, float G, float B)
    {
      if (Main.netMode == 2)
        return;
      if (!Lighting.RGB)
        Lighting.addLight(i, j, (float) (((double) R + (double) G + (double) B) / 3.0));
      if (i - Lighting.firstTileX + Lighting.offScreenTiles < 0 || i - Lighting.firstTileX + Lighting.offScreenTiles >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || j - Lighting.firstTileY + Lighting.offScreenTiles < 0 || j - Lighting.firstTileY + Lighting.offScreenTiles >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 || Lighting.tempLightCount == Lighting.maxTempLights)
        return;
      for (int index = 0; index < Lighting.tempLightCount; ++index)
      {
        if (Lighting.tempLightX[index] == i && Lighting.tempLightY[index] == j)
        {
          if ((double) Lighting.tempLight[index] < (double) R)
            Lighting.tempLight[index] = R;
          if ((double) Lighting.tempLightG[index] < (double) G)
            Lighting.tempLightG[index] = G;
          if ((double) Lighting.tempLightB[index] >= (double) B)
            return;
          Lighting.tempLightB[index] = B;
          return;
        }
      }
      Lighting.tempLight[Lighting.tempLightCount] = R;
      Lighting.tempLightG[Lighting.tempLightCount] = G;
      Lighting.tempLightB[Lighting.tempLightCount] = B;
      Lighting.tempLightX[Lighting.tempLightCount] = i;
      Lighting.tempLightY[Lighting.tempLightCount] = j;
      ++Lighting.tempLightCount;
    }

    private static void ResetRange()
    {
      Lighting.minX = Main.screenWidth + Lighting.offScreenTiles * 2 + 10;
      Lighting.maxX = 0;
      Lighting.minY = Main.screenHeight + Lighting.offScreenTiles * 2 + 10;
      Lighting.maxY = 0;
    }

    private static void LightColor(int i, int j)
    {
      int index1 = i - Lighting.firstToLightX7;
      int index2 = j - Lighting.firstToLightY7;
      if ((double) Lighting.color2[index1, index2] > (double) Lighting.lightColor)
      {
        Lighting.lightColor = Lighting.color2[index1, index2];
      }
      else
      {
        if ((double) Lighting.lightColor <= 0.0185)
          return;
        if ((double) Lighting.color2[index1, index2] < (double) Lighting.lightColor)
          Lighting.color2[index1, index2] = Lighting.lightColor;
      }
      if ((double) Lighting.color2[index1 + Lighting.dirX, index2 + Lighting.dirY] > (double) Lighting.lightColor)
        return;
      if (Lighting.stopLight[index1, index2])
        Lighting.lightColor *= Lighting.negLight2;
      else if (Lighting.wetLight[index1, index2])
        Lighting.lightColor *= (float) ((double) Lighting.wetLightR * (double) Main.rand.Next(98, 100) * 0.00999999977648258);
      else
        Lighting.lightColor *= Lighting.negLight;
    }

    private static void LightColorG(int i, int j)
    {
      int index1 = i - Lighting.firstToLightX7;
      int index2 = j - Lighting.firstToLightY7;
      if ((double) Lighting.colorG2[index1, index2] > (double) Lighting.lightColorG)
      {
        Lighting.lightColorG = Lighting.colorG2[index1, index2];
      }
      else
      {
        if ((double) Lighting.lightColorG <= 0.0185)
          return;
        Lighting.colorG2[index1, index2] = Lighting.lightColorG;
      }
      if ((double) Lighting.colorG2[index1 + Lighting.dirX, index2 + Lighting.dirY] > (double) Lighting.lightColorG)
        return;
      if (Lighting.stopLight[index1, index2])
        Lighting.lightColorG *= Lighting.negLight2;
      else if (Lighting.wetLight[index1, index2])
        Lighting.lightColorG *= (float) ((double) Lighting.wetLightG * (double) Main.rand.Next(97, 100) * 0.00999999977648258);
      else
        Lighting.lightColorG *= Lighting.negLight;
    }

    private static void LightColorB(int i, int j)
    {
      int index1 = i - Lighting.firstToLightX7;
      int index2 = j - Lighting.firstToLightY7;
      if ((double) Lighting.colorB2[index1, index2] > (double) Lighting.lightColorB)
      {
        Lighting.lightColorB = Lighting.colorB2[index1, index2];
      }
      else
      {
        if ((double) Lighting.lightColorB <= 0.0185)
          return;
        Lighting.colorB2[index1, index2] = Lighting.lightColorB;
      }
      if ((double) Lighting.colorB2[index1 + Lighting.dirX, index2 + Lighting.dirY] >= (double) Lighting.lightColorB)
        return;
      if (Lighting.stopLight[index1, index2])
        Lighting.lightColorB *= Lighting.negLight2;
      else
        Lighting.lightColorB *= Lighting.negLight;
    }

    private static void LightColor2(int i, int j)
    {
      int index1 = i - Lighting.firstToLightX7;
      int index2 = j - Lighting.firstToLightY7;
      try
      {
        if ((double) Lighting.color2[index1, index2] > (double) Lighting.lightColor)
        {
          Lighting.lightColor = Lighting.color2[index1, index2];
        }
        else
        {
          if ((double) Lighting.lightColor <= 0.0)
            return;
          Lighting.color2[index1, index2] = Lighting.lightColor;
        }
        if (Main.tile[i, j].active && Main.tileBlockLight[(int) Main.tile[i, j].type])
          Lighting.lightColor -= Lighting.negLight2;
        else if (Lighting.wetLight[index1, index2])
          Lighting.lightColor -= Lighting.wetLightR;
        else
          Lighting.lightColor -= Lighting.negLight;
      }
      catch
      {
      }
    }

    private static void LightColorG2(int i, int j)
    {
      int index1 = i - Lighting.firstToLightX7;
      int index2 = j - Lighting.firstToLightY7;
      try
      {
        if ((double) Lighting.colorG2[index1, index2] > (double) Lighting.lightColorG)
        {
          Lighting.lightColorG = Lighting.colorG2[index1, index2];
        }
        else
        {
          if ((double) Lighting.lightColorG <= 0.0)
            return;
          Lighting.colorG2[index1, index2] = Lighting.lightColorG;
        }
        if (Main.tile[i, j].active && Main.tileBlockLight[(int) Main.tile[i, j].type])
          Lighting.lightColorG -= Lighting.negLight2;
        else if (Lighting.wetLight[index1, index2])
          Lighting.lightColorG -= Lighting.wetLightG;
        else
          Lighting.lightColorG -= Lighting.negLight;
      }
      catch
      {
      }
    }

    private static void LightColorB2(int i, int j)
    {
      int index1 = i - Lighting.firstToLightX7;
      int index2 = j - Lighting.firstToLightY7;
      try
      {
        if ((double) Lighting.colorB2[index1, index2] > (double) Lighting.lightColorB)
        {
          Lighting.lightColorB = Lighting.colorB2[index1, index2];
        }
        else
        {
          if ((double) Lighting.lightColorB <= 0.0)
            return;
          Lighting.colorB2[index1, index2] = Lighting.lightColorB;
        }
        if (Main.tile[i, j].active && Main.tileBlockLight[(int) Main.tile[i, j].type])
          Lighting.lightColorB -= Lighting.negLight2;
        else
          Lighting.lightColorB -= Lighting.negLight;
      }
      catch
      {
      }
    }

    public static int LightingX(int lightX)
    {
      if (lightX < 0)
        return 0;
      return lightX >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 ? Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 : lightX;
    }

    public static int LightingY(int lightY)
    {
      if (lightY < 0)
        return 0;
      return lightY >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 ? Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 - 1 : lightY;
    }

    public static Color GetColor(int x, int y, Color oldColor)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      if (Main.gameMenu)
        return oldColor;
      if (index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
        return Color.Black;
      Color white = Color.White;
      int num1 = (int) ((double) oldColor.R * (double) Lighting.color[index1, index2] * (double) Lighting.brightness);
      int num2 = (int) ((double) oldColor.G * (double) Lighting.colorG[index1, index2] * (double) Lighting.brightness);
      int num3 = (int) ((double) oldColor.B * (double) Lighting.colorB[index1, index2] * (double) Lighting.brightness);
      if (num1 > (int) byte.MaxValue)
        num1 = (int) byte.MaxValue;
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      white.R = (byte) num1;
      white.G = (byte) num2;
      white.B = (byte) num3;
      return white;
    }

    public static Color GetColor(int x, int y)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      if (index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2)
        return Color.Black;
      int num1 = (int) ((double) byte.MaxValue * (double) Lighting.color[index1, index2] * (double) Lighting.brightness);
      int num2 = (int) ((double) byte.MaxValue * (double) Lighting.colorG[index1, index2] * (double) Lighting.brightness);
      int num3 = (int) ((double) byte.MaxValue * (double) Lighting.colorB[index1, index2] * (double) Lighting.brightness);
      if (num1 > (int) byte.MaxValue)
        num1 = (int) byte.MaxValue;
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      return new Color((int) (byte) num1, (int) (byte) num2, (int) (byte) num3, (int) byte.MaxValue);
    }

    public static Color GetBlackness(int x, int y)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      return index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 ? Color.Black : new Color(0, 0, 0, (int) (byte) ((double) byte.MaxValue - (double) byte.MaxValue * (double) Lighting.color[index1, index2]));
    }

    public static float Brightness(int x, int y)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      return index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 ? 0.0f : (float) (((double) Lighting.color[index1, index2] + (double) Lighting.colorG[index1, index2] + (double) Lighting.colorB[index1, index2]) / 3.0);
    }

    public static bool Brighter(int x, int y, int x2, int y2)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      int index3 = x2 - Lighting.firstTileX + Lighting.offScreenTiles;
      int index4 = y2 - Lighting.firstTileY + Lighting.offScreenTiles;
      try
      {
        return (double) Lighting.color[index1, index2] + (double) Lighting.colorG[index1, index2] + (double) Lighting.colorB[index1, index2] >= (double) Lighting.color[index3, index4] + (double) Lighting.colorG[index3, index4] + (double) Lighting.colorB[index3, index4];
      }
      catch
      {
        return false;
      }
    }
  }
}
