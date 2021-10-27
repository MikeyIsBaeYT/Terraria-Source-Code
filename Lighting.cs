// Decompiled with JetBrains decompiler
// Type: Terraria.Lighting
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria
{
  public class Lighting
  {
    public static int maxRenderCount = 4;
    public static float brightness = 1f;
    public static float defBrightness = 1f;
    public static int lightMode = 0;
    public static bool RGB = true;
    private static float oldSkyColor = 0.0f;
    private static float skyColor = 0.0f;
    private static int lightCounter = 0;
    public static int offScreenTiles = 45;
    public static int offScreenTiles2 = 35;
    private static int firstTileX;
    private static int lastTileX;
    private static int firstTileY;
    private static int lastTileY;
    public static int LightingThreads = 0;
    private static Lighting.LightingState[][] states;
    private static Lighting.LightingState[][] axisFlipStates;
    private static Lighting.LightingSwipeData swipe;
    private static Lighting.LightingSwipeData[] threadSwipes;
    private static CountdownEvent countdown;
    public static int scrX;
    public static int scrY;
    public static int minX;
    public static int maxX;
    public static int minY;
    public static int maxY;
    private static int maxTempLights = 2000;
    private static Dictionary<Point16, Lighting.ColorTriplet> tempLights;
    private static int firstToLightX;
    private static int firstToLightY;
    private static int lastToLightX;
    private static int lastToLightY;
    private static float negLight = 0.04f;
    private static float negLight2 = 0.16f;
    private static float wetLightR = 0.16f;
    private static float wetLightG = 0.16f;
    private static float wetLightB = 0.16f;
    private static float honeyLightR = 0.16f;
    private static float honeyLightG = 0.16f;
    private static float honeyLightB = 0.16f;
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

    public static bool NotRetro => Lighting.lightMode < 2;

    public static bool UpdateEveryFrame => Main.LightingEveryFrame && !Main.RenderTargetsRequired && !Lighting.NotRetro;

    public static bool LightingDrawToScreen => Main.drawToScreen;

    public static void Initialize(bool resize = false)
    {
      if (!resize)
      {
        Lighting.tempLights = new Dictionary<Point16, Lighting.ColorTriplet>();
        Lighting.swipe = new Lighting.LightingSwipeData();
        Lighting.countdown = new CountdownEvent(0);
        Lighting.threadSwipes = new Lighting.LightingSwipeData[Environment.ProcessorCount];
        for (int index = 0; index < Lighting.threadSwipes.Length; ++index)
          Lighting.threadSwipes[index] = new Lighting.LightingSwipeData();
      }
      int length1 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
      int length2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
      if (Lighting.states != null && Lighting.states.Length >= length1 && Lighting.states[0].Length >= length2)
        return;
      Lighting.states = new Lighting.LightingState[length1][];
      Lighting.axisFlipStates = new Lighting.LightingState[length2][];
      for (int index = 0; index < length2; ++index)
        Lighting.axisFlipStates[index] = new Lighting.LightingState[length1];
      for (int index1 = 0; index1 < length1; ++index1)
      {
        Lighting.LightingState[] lightingStateArray = new Lighting.LightingState[length2];
        for (int index2 = 0; index2 < length2; ++index2)
        {
          Lighting.LightingState lightingState = new Lighting.LightingState();
          lightingStateArray[index2] = lightingState;
          Lighting.axisFlipStates[index2][index1] = lightingState;
        }
        Lighting.states[index1] = lightingStateArray;
      }
    }

    public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
    {
      Main.render = true;
      Lighting.oldSkyColor = Lighting.skyColor;
      float num1 = (float) Main.tileColor.R / (float) byte.MaxValue;
      float num2 = (float) Main.tileColor.G / (float) byte.MaxValue;
      float num3 = (float) Main.tileColor.B / (float) byte.MaxValue;
      Lighting.skyColor = (float) (((double) num1 + (double) num2 + (double) num3) / 3.0);
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
      Lighting.brightness = 1.2f;
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
      ++Lighting.lightCounter;
      ++Main.renderCount;
      int num4 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
      int num5 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
      Vector2 screenLastPosition = Main.screenLastPosition;
      if (Main.renderCount < 3)
        Lighting.doColors();
      if (Main.renderCount == 2)
      {
        Vector2 screenPosition = Main.screenPosition;
        int num6 = (int) Math.Floor((double) Main.screenPosition.X / 16.0) - Lighting.scrX;
        int num7 = (int) Math.Floor((double) Main.screenPosition.Y / 16.0) - Lighting.scrY;
        if (num6 > 16)
          num6 = 0;
        if (num7 > 16)
          num7 = 0;
        int num8 = 0;
        int num9 = num4;
        int num10 = 0;
        int num11 = num5;
        if (num6 < 0)
          num8 -= num6;
        else
          num9 -= num6;
        if (num7 < 0)
          num10 -= num7;
        else
          num11 -= num7;
        if (Lighting.RGB)
        {
          int num12 = num4;
          if (Lighting.states.Length <= num12 + num6)
            num12 = Lighting.states.Length - num6 - 1;
          for (int index1 = num8; index1 < num12; ++index1)
          {
            Lighting.LightingState[] state1 = Lighting.states[index1];
            Lighting.LightingState[] state2 = Lighting.states[index1 + num6];
            int num13 = num11;
            if (state2.Length <= num13 + num6)
              num13 = state2.Length - num7 - 1;
            for (int index2 = num10; index2 < num13; ++index2)
            {
              Lighting.LightingState lightingState1 = state1[index2];
              Lighting.LightingState lightingState2 = state2[index2 + num7];
              lightingState1.r = lightingState2.r2;
              lightingState1.g = lightingState2.g2;
              lightingState1.b = lightingState2.b2;
            }
          }
        }
        else
        {
          int num14 = num9;
          if (Lighting.states.Length <= num14 + num6)
            num14 = Lighting.states.Length - num6 - 1;
          for (int index3 = num8; index3 < num14; ++index3)
          {
            Lighting.LightingState[] state3 = Lighting.states[index3];
            Lighting.LightingState[] state4 = Lighting.states[index3 + num6];
            int num15 = num11;
            if (state4.Length <= num15 + num6)
              num15 = state4.Length - num7 - 1;
            for (int index4 = num10; index4 < num15; ++index4)
            {
              Lighting.LightingState lightingState3 = state3[index4];
              Lighting.LightingState lightingState4 = state4[index4 + num7];
              lightingState3.r = lightingState4.r2;
              lightingState3.g = lightingState4.r2;
              lightingState3.b = lightingState4.r2;
            }
          }
        }
      }
      else if (!Main.renderNow)
      {
        int num16 = (int) Math.Floor((double) Main.screenPosition.X / 16.0) - (int) Math.Floor((double) screenLastPosition.X / 16.0);
        if (num16 > 5 || num16 < -5)
          num16 = 0;
        int num17;
        int num18;
        int num19;
        if (num16 < 0)
        {
          num17 = -1;
          num16 *= -1;
          num18 = num4;
          num19 = num16;
        }
        else
        {
          num17 = 1;
          num18 = 0;
          num19 = num4 - num16;
        }
        int num20 = (int) Math.Floor((double) Main.screenPosition.Y / 16.0) - (int) Math.Floor((double) screenLastPosition.Y / 16.0);
        if (num20 > 5 || num20 < -5)
          num20 = 0;
        int num21;
        int num22;
        int num23;
        if (num20 < 0)
        {
          num21 = -1;
          num20 *= -1;
          num22 = num5;
          num23 = num20;
        }
        else
        {
          num21 = 1;
          num22 = 0;
          num23 = num5 - num20;
        }
        if (num16 != 0 || num20 != 0)
        {
          for (int index5 = num18; index5 != num19; index5 += num17)
          {
            Lighting.LightingState[] state5 = Lighting.states[index5];
            Lighting.LightingState[] state6 = Lighting.states[index5 + num16 * num17];
            for (int index6 = num22; index6 != num23; index6 += num21)
            {
              Lighting.LightingState lightingState5 = state5[index6];
              Lighting.LightingState lightingState6 = state6[index6 + num20 * num21];
              lightingState5.r = lightingState6.r;
              lightingState5.g = lightingState6.g;
              lightingState5.b = lightingState6.b;
            }
          }
        }
        if (Netplay.Connection.StatusMax > 0)
          Main.mapTime = 1;
        if (Main.mapTime == 0 && Main.mapEnabled)
        {
          if (Main.renderCount == 3)
          {
            try
            {
              Main.mapTime = Main.mapTimeMax;
              Main.updateMap = true;
              Main.mapMinX = Utils.Clamp<int>(Lighting.firstToLightX + Lighting.offScreenTiles, 0, Main.maxTilesX - 1);
              Main.mapMaxX = Utils.Clamp<int>(Lighting.lastToLightX - Lighting.offScreenTiles, 0, Main.maxTilesX - 1);
              Main.mapMinY = Utils.Clamp<int>(Lighting.firstToLightY + Lighting.offScreenTiles, 0, Main.maxTilesY - 1);
              Main.mapMaxY = Utils.Clamp<int>(Lighting.lastToLightY - Lighting.offScreenTiles, 0, Main.maxTilesY - 1);
              for (int mapMinX = Main.mapMinX; mapMinX < Main.mapMaxX; ++mapMinX)
              {
                Lighting.LightingState[] state = Lighting.states[mapMinX - Lighting.firstTileX + Lighting.offScreenTiles];
                for (int mapMinY = Main.mapMinY; mapMinY < Main.mapMaxY; ++mapMinY)
                {
                  Lighting.LightingState lightingState = state[mapMinY - Lighting.firstTileY + Lighting.offScreenTiles];
                  Tile tile = Main.tile[mapMinX, mapMinY];
                  float num24 = 0.0f;
                  if ((double) lightingState.r > (double) num24)
                    num24 = lightingState.r;
                  if ((double) lightingState.g > (double) num24)
                    num24 = lightingState.g;
                  if ((double) lightingState.b > (double) num24)
                    num24 = lightingState.b;
                  if (Lighting.lightMode < 2)
                    num24 *= 1.5f;
                  byte light = (byte) Math.Min((float) byte.MaxValue, num24 * (float) byte.MaxValue);
                  if ((double) mapMinY < Main.worldSurface && !tile.active() && tile.wall == (byte) 0 && tile.liquid == (byte) 0)
                    light = (byte) 22;
                  if (light > (byte) 18 || Main.Map[mapMinX, mapMinY].Light > (byte) 0)
                  {
                    if (light < (byte) 22)
                      light = (byte) 22;
                    Main.Map.UpdateLighting(mapMinX, mapMinY, light);
                  }
                }
              }
            }
            catch
            {
            }
          }
        }
        if ((double) Lighting.oldSkyColor != (double) Lighting.skyColor)
        {
          int num25 = Utils.Clamp<int>(Lighting.firstToLightX, 0, Main.maxTilesX - 1);
          int num26 = Utils.Clamp<int>(Lighting.lastToLightX, 0, Main.maxTilesX - 1);
          int num27 = Utils.Clamp<int>(Lighting.firstToLightY, 0, Main.maxTilesY - 1);
          int num28 = Utils.Clamp<int>(Lighting.lastToLightY, 0, (int) Main.worldSurface - 1);
          if ((double) num27 < Main.worldSurface)
          {
            for (int index7 = num25; index7 < num26; ++index7)
            {
              Lighting.LightingState[] state = Lighting.states[index7 - Lighting.firstToLightX];
              for (int index8 = num27; index8 < num28; ++index8)
              {
                Lighting.LightingState lightingState = state[index8 - Lighting.firstToLightY];
                Tile tile = Main.tile[index7, index8];
                if (tile == null)
                {
                  tile = new Tile();
                  Main.tile[index7, index8] = tile;
                }
                if ((!tile.active() || !Main.tileNoSunLight[(int) tile.type]) && (double) lightingState.r < (double) Lighting.skyColor && tile.liquid < (byte) 200 && (Main.wallLight[(int) tile.wall] || tile.wall == (byte) 73))
                {
                  lightingState.r = num1;
                  if ((double) lightingState.g < (double) Lighting.skyColor)
                    lightingState.g = num2;
                  if ((double) lightingState.b < (double) Lighting.skyColor)
                    lightingState.b = num3;
                }
              }
            }
          }
        }
      }
      else
        Lighting.lightCounter = 0;
      if (Main.renderCount <= Lighting.maxRenderCount)
        return;
      Lighting.PreRenderPhase();
    }

    public static void PreRenderPhase()
    {
      float num1 = (float) Main.tileColor.R / (float) byte.MaxValue;
      float num2 = (float) Main.tileColor.G / (float) byte.MaxValue;
      float num3 = (float) Main.tileColor.B / (float) byte.MaxValue;
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num4 = 0;
      int num5 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
      int num6 = 0;
      int num7 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
      Lighting.minX = num5;
      Lighting.maxX = num4;
      Lighting.minY = num7;
      Lighting.maxY = num6;
      Lighting.RGB = Lighting.lightMode == 0 || Lighting.lightMode == 3;
      for (int index1 = num4; index1 < num5; ++index1)
      {
        Lighting.LightingState[] state = Lighting.states[index1];
        for (int index2 = num6; index2 < num7; ++index2)
        {
          Lighting.LightingState lightingState = state[index2];
          lightingState.r2 = 0.0f;
          lightingState.g2 = 0.0f;
          lightingState.b2 = 0.0f;
          lightingState.stopLight = false;
          lightingState.wetLight = false;
          lightingState.honeyLight = false;
        }
      }
      if (Main.wof >= 0)
      {
        if (Main.player[Main.myPlayer].gross)
        {
          try
          {
            int num8 = (int) Main.screenPosition.Y / 16 - 10;
            int num9 = (int) ((double) Main.screenPosition.Y + (double) Main.screenHeight) / 16 + 10;
            int num10 = (int) Main.npc[Main.wof].position.X / 16;
            int num11 = Main.npc[Main.wof].direction <= 0 ? num10 + 2 : num10 - 3;
            int num12 = num11 + 8;
            float num13 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
            float num14 = 0.3f;
            float num15 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
            float num16 = num13 * 0.2f;
            float num17 = num14 * 0.1f;
            float num18 = num15 * 0.3f;
            for (int index3 = num11; index3 <= num12; ++index3)
            {
              Lighting.LightingState[] state = Lighting.states[index3 - num11];
              for (int index4 = num8; index4 <= num9; ++index4)
              {
                Lighting.LightingState lightingState = state[index4 - Lighting.firstToLightY];
                if ((double) lightingState.r2 < (double) num16)
                  lightingState.r2 = num16;
                if ((double) lightingState.g2 < (double) num17)
                  lightingState.g2 = num17;
                if ((double) lightingState.b2 < (double) num18)
                  lightingState.b2 = num18;
              }
            }
          }
          catch
          {
          }
        }
      }
      Main.sandTiles = 0;
      Main.evilTiles = 0;
      Main.bloodTiles = 0;
      Main.shroomTiles = 0;
      Main.snowTiles = 0;
      Main.holyTiles = 0;
      Main.meteorTiles = 0;
      Main.jungleTiles = 0;
      Main.dungeonTiles = 0;
      Main.campfire = false;
      Main.sunflower = false;
      Main.starInBottle = false;
      Main.heartLantern = false;
      Main.campfire = false;
      Main.clock = false;
      Main.musicBox = -1;
      Main.waterCandles = 0;
      for (int index = 0; index < Main.player[Main.myPlayer].NPCBannerBuff.Length; ++index)
        Main.player[Main.myPlayer].NPCBannerBuff[index] = false;
      Main.player[Main.myPlayer].hasBanner = false;
      int[] screenTileCounts = Main.screenTileCounts;
      Array.Clear((Array) screenTileCounts, 0, screenTileCounts.Length);
      int num19 = Utils.Clamp<int>(Lighting.firstToLightX, 5, Main.maxTilesX - 1);
      int num20 = Utils.Clamp<int>(Lighting.lastToLightX, 5, Main.maxTilesX - 1);
      int num21 = Utils.Clamp<int>(Lighting.firstToLightY, 5, Main.maxTilesY - 1);
      int num22 = Utils.Clamp<int>(Lighting.lastToLightY, 5, Main.maxTilesY - 1);
      int num23 = (num20 - num19 - Main.zoneX) / 2;
      int num24 = (num22 - num21 - Main.zoneY) / 2;
      Main.fountainColor = -1;
      Main.monolithType = -1;
      for (int index5 = num19; index5 < num20; ++index5)
      {
        Lighting.LightingState[] state = Lighting.states[index5 - Lighting.firstToLightX];
        for (int index6 = num21; index6 < num22; ++index6)
        {
          Lighting.LightingState lightingState = state[index6 - Lighting.firstToLightY];
          Tile tile = Main.tile[index5, index6];
          if (tile == null)
          {
            tile = new Tile();
            Main.tile[index5, index6] = tile;
          }
          float num25 = 0.0f;
          float num26 = 0.0f;
          float num27 = 0.0f;
          if ((double) index6 < Main.worldSurface)
          {
            if ((!tile.active() || !Main.tileNoSunLight[(int) tile.type] || (tile.slope() != (byte) 0 || tile.halfBrick()) && Main.tile[index5, index6 - 1].liquid == (byte) 0 && Main.tile[index5, index6 + 1].liquid == (byte) 0 && Main.tile[index5 - 1, index6].liquid == (byte) 0 && Main.tile[index5 + 1, index6].liquid == (byte) 0) && (double) lightingState.r2 < (double) Lighting.skyColor && (Main.wallLight[(int) tile.wall] || tile.wall == (byte) 73 || tile.wall == (byte) 227) && tile.liquid < (byte) 200 && (!tile.halfBrick() || Main.tile[index5, index6 - 1].liquid < (byte) 200))
            {
              num25 = num1;
              num26 = num2;
              num27 = num3;
            }
            if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[(int) tile.type]) && tile.wall >= (byte) 88 && tile.wall <= (byte) 93 && tile.liquid < byte.MaxValue)
            {
              num25 = num1;
              num26 = num2;
              num27 = num3;
              switch (tile.wall)
              {
                case 88:
                  num25 *= 0.9f;
                  num26 *= 0.15f;
                  num27 *= 0.9f;
                  break;
                case 89:
                  num25 *= 0.9f;
                  num26 *= 0.9f;
                  num27 *= 0.15f;
                  break;
                case 90:
                  num25 *= 0.15f;
                  num26 *= 0.15f;
                  num27 *= 0.9f;
                  break;
                case 91:
                  num25 *= 0.15f;
                  num26 *= 0.9f;
                  num27 *= 0.15f;
                  break;
                case 92:
                  num25 *= 0.9f;
                  num26 *= 0.15f;
                  num27 *= 0.15f;
                  break;
                case 93:
                  float num28 = 0.2f;
                  float num29 = 0.7f - num28;
                  num25 *= num29 + (float) Main.DiscoR / (float) byte.MaxValue * num28;
                  num26 *= num29 + (float) Main.DiscoG / (float) byte.MaxValue * num28;
                  num27 *= num29 + (float) Main.DiscoB / (float) byte.MaxValue * num28;
                  break;
              }
            }
            if (!Lighting.RGB)
            {
              double num30;
              num27 = (float) (num30 = ((double) num25 + (double) num26 + (double) num27) / 3.0);
              num26 = (float) num30;
              num25 = (float) num30;
            }
            if ((double) lightingState.r2 < (double) num25)
              lightingState.r2 = num25;
            if ((double) lightingState.g2 < (double) num26)
              lightingState.g2 = num26;
            if ((double) lightingState.b2 < (double) num27)
              lightingState.b2 = num27;
          }
          float num31 = (float) (0.550000011920929 + Math.Sin((double) Main.GlobalTime * 2.0) * 0.0799999982118607);
          if (index6 > Main.maxTilesY - 200)
          {
            if ((!tile.active() || !Main.tileNoSunLight[(int) tile.type] || (tile.slope() != (byte) 0 || tile.halfBrick()) && Main.tile[index5, index6 - 1].liquid == (byte) 0 && Main.tile[index5, index6 + 1].liquid == (byte) 0 && Main.tile[index5 - 1, index6].liquid == (byte) 0 && Main.tile[index5 + 1, index6].liquid == (byte) 0) && (double) lightingState.r2 < (double) num31 && (Main.wallLight[(int) tile.wall] || tile.wall == (byte) 73 || tile.wall == (byte) 227) && tile.liquid < (byte) 200 && (!tile.halfBrick() || Main.tile[index5, index6 - 1].liquid < (byte) 200))
            {
              num25 = num31;
              num26 = num31 * 0.6f;
              num27 = num31 * 0.2f;
            }
            if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[(int) tile.type]) && tile.wall >= (byte) 88 && tile.wall <= (byte) 93 && tile.liquid < byte.MaxValue)
            {
              num25 = num31;
              num26 = num31 * 0.6f;
              num27 = num31 * 0.2f;
              switch (tile.wall)
              {
                case 88:
                  num25 *= 0.9f;
                  num26 *= 0.15f;
                  num27 *= 0.9f;
                  break;
                case 89:
                  num25 *= 0.9f;
                  num26 *= 0.9f;
                  num27 *= 0.15f;
                  break;
                case 90:
                  num25 *= 0.15f;
                  num26 *= 0.15f;
                  num27 *= 0.9f;
                  break;
                case 91:
                  num25 *= 0.15f;
                  num26 *= 0.9f;
                  num27 *= 0.15f;
                  break;
                case 92:
                  num25 *= 0.9f;
                  num26 *= 0.15f;
                  num27 *= 0.15f;
                  break;
                case 93:
                  float num32 = 0.2f;
                  float num33 = 0.7f - num32;
                  num25 *= num33 + (float) Main.DiscoR / (float) byte.MaxValue * num32;
                  num26 *= num33 + (float) Main.DiscoG / (float) byte.MaxValue * num32;
                  num27 *= num33 + (float) Main.DiscoB / (float) byte.MaxValue * num32;
                  break;
              }
            }
            if (!Lighting.RGB)
            {
              double num34;
              num27 = (float) (num34 = ((double) num25 + (double) num26 + (double) num27) / 3.0);
              num26 = (float) num34;
              num25 = (float) num34;
            }
            if ((double) lightingState.r2 < (double) num25)
              lightingState.r2 = num25;
            if ((double) lightingState.g2 < (double) num26)
              lightingState.g2 = num26;
            if ((double) lightingState.b2 < (double) num27)
              lightingState.b2 = num27;
          }
          switch (tile.wall)
          {
            case 33:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                num25 = 0.09f;
                num26 = 0.0525f;
                num27 = 0.24f;
                break;
              }
              break;
            case 44:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                num25 = (float) ((double) Main.DiscoR / (double) byte.MaxValue * 0.150000005960464);
                num26 = (float) ((double) Main.DiscoG / (double) byte.MaxValue * 0.150000005960464);
                num27 = (float) ((double) Main.DiscoB / (double) byte.MaxValue * 0.150000005960464);
                break;
              }
              break;
            case 137:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                float num35 = 0.4f + (float) (270 - (int) Main.mouseTextColor) / 1500f + (float) Main.rand.Next(0, 50) * 0.0005f;
                num25 = 1f * num35;
                num26 = 0.5f * num35;
                num27 = 0.1f * num35;
                break;
              }
              break;
            case 153:
              num25 = 0.6f;
              num26 = 0.3f;
              break;
            case 154:
              num25 = 0.6f;
              num27 = 0.6f;
              break;
            case 155:
              num25 = 0.6f;
              num26 = 0.6f;
              num27 = 0.6f;
              break;
            case 156:
              num26 = 0.6f;
              break;
            case 164:
              num25 = 0.6f;
              break;
            case 165:
              num27 = 0.6f;
              break;
            case 166:
              num25 = 0.6f;
              num26 = 0.6f;
              break;
            case 174:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                num25 = 0.2975f;
                break;
              }
              break;
            case 175:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                num25 = 0.075f;
                num26 = 0.15f;
                num27 = 0.4f;
                break;
              }
              break;
            case 176:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                num25 = 0.1f;
                num26 = 0.1f;
                num27 = 0.1f;
                break;
              }
              break;
            case 182:
              if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
              {
                num25 = 0.24f;
                num26 = 0.12f;
                num27 = 0.09f;
                break;
              }
              break;
          }
          if (tile.active())
          {
            if (index5 > num19 + num23 && index5 < num20 - num23 && index6 > num21 + num24 && index6 < num22 - num24)
            {
              ++screenTileCounts[(int) tile.type];
              if (tile.type == (ushort) 215 && tile.frameY < (short) 36)
                Main.campfire = true;
              if (tile.type == (ushort) 405)
                Main.campfire = true;
              if (tile.type == (ushort) 42 && tile.frameY >= (short) 324 && tile.frameY <= (short) 358)
                Main.heartLantern = true;
              if (tile.type == (ushort) 42 && tile.frameY >= (short) 252 && tile.frameY <= (short) 286)
                Main.starInBottle = true;
              if (tile.type == (ushort) 91 && (tile.frameX >= (short) 396 || tile.frameY >= (short) 54))
              {
                int banner = (int) tile.frameX / 18 - 21;
                for (int frameY = (int) tile.frameY; frameY >= 54; frameY -= 54)
                  banner = banner + 90 + 21;
                int index7 = Item.BannerToItem(banner);
                if (ItemID.Sets.BannerStrength[index7].Enabled)
                {
                  Main.player[Main.myPlayer].NPCBannerBuff[banner] = true;
                  Main.player[Main.myPlayer].hasBanner = true;
                }
              }
            }
            switch (tile.type)
            {
              case 139:
                if (tile.frameX >= (short) 36)
                {
                  Main.musicBox = (int) tile.frameY / 36;
                  break;
                }
                break;
              case 207:
                if (tile.frameY >= (short) 72)
                {
                  switch ((int) tile.frameX / 36)
                  {
                    case 0:
                      Main.fountainColor = 0;
                      break;
                    case 1:
                      Main.fountainColor = 6;
                      break;
                    case 2:
                      Main.fountainColor = 3;
                      break;
                    case 3:
                      Main.fountainColor = 5;
                      break;
                    case 4:
                      Main.fountainColor = 2;
                      break;
                    case 5:
                      Main.fountainColor = 10;
                      break;
                    case 6:
                      Main.fountainColor = 4;
                      break;
                    case 7:
                      Main.fountainColor = 9;
                      break;
                    default:
                      Main.fountainColor = -1;
                      break;
                  }
                }
                else
                  break;
                break;
              case 410:
                if (tile.frameY >= (short) 56)
                {
                  Main.monolithType = (int) tile.frameX / 36;
                  break;
                }
                break;
            }
            if (Main.tileBlockLight[(int) tile.type] && (Lighting.lightMode >= 2 || tile.type != (ushort) 131 && !tile.inActive() && tile.slope() == (byte) 0))
              lightingState.stopLight = true;
            if (tile.type == (ushort) 104)
              Main.clock = true;
            if (Main.tileLighted[(int) tile.type])
            {
              switch (tile.type)
              {
                case 4:
                  if (tile.frameX < (short) 66)
                  {
                    switch ((int) tile.frameY / 22)
                    {
                      case 0:
                        num25 = 1f;
                        num26 = 0.95f;
                        num27 = 0.8f;
                        break;
                      case 1:
                        num25 = 0.0f;
                        num26 = 0.1f;
                        num27 = 1.3f;
                        break;
                      case 2:
                        num25 = 1f;
                        num26 = 0.1f;
                        num27 = 0.1f;
                        break;
                      case 3:
                        num25 = 0.0f;
                        num26 = 1f;
                        num27 = 0.1f;
                        break;
                      case 4:
                        num25 = 0.9f;
                        num26 = 0.0f;
                        num27 = 0.9f;
                        break;
                      case 5:
                        num25 = 1.3f;
                        num26 = 1.3f;
                        num27 = 1.3f;
                        break;
                      case 6:
                        num25 = 0.9f;
                        num26 = 0.9f;
                        num27 = 0.0f;
                        break;
                      case 7:
                        num25 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num26 = 0.3f;
                        num27 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 8:
                        num25 = 0.85f;
                        num26 = 1f;
                        num27 = 0.7f;
                        break;
                      case 9:
                        num25 = 0.7f;
                        num26 = 0.85f;
                        num27 = 1f;
                        break;
                      case 10:
                        num25 = 1f;
                        num26 = 0.5f;
                        num27 = 0.0f;
                        break;
                      case 11:
                        num25 = 1.25f;
                        num26 = 1.25f;
                        num27 = 0.8f;
                        break;
                      case 12:
                        num25 = 0.75f;
                        num26 = 1.2825f;
                        num27 = 1.2f;
                        break;
                      case 13:
                        num25 = 0.95f;
                        num26 = 0.65f;
                        num27 = 1.3f;
                        break;
                      case 14:
                        num25 = (float) Main.DiscoR / (float) byte.MaxValue;
                        num26 = (float) Main.DiscoG / (float) byte.MaxValue;
                        num27 = (float) Main.DiscoB / (float) byte.MaxValue;
                        break;
                      case 15:
                        num25 = 1f;
                        num26 = 0.0f;
                        num27 = 1f;
                        break;
                      default:
                        num25 = 1f;
                        num26 = 0.95f;
                        num27 = 0.8f;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case 17:
                case 133:
                case 302:
                  num25 = 0.83f;
                  num26 = 0.6f;
                  num27 = 0.5f;
                  break;
                case 22:
                case 140:
                  num25 = 0.12f;
                  num26 = 0.07f;
                  num27 = 0.32f;
                  break;
                case 26:
                case 31:
                  if (tile.type == (ushort) 31 && tile.frameX >= (short) 36 || tile.type == (ushort) 26 && tile.frameX >= (short) 54)
                  {
                    float num36 = (float) Main.rand.Next(-5, 6) * (1f / 400f);
                    num25 = (float) (0.5 + (double) num36 * 2.0);
                    num26 = 0.2f + num36;
                    num27 = 0.1f;
                    break;
                  }
                  float num37 = (float) Main.rand.Next(-5, 6) * (1f / 400f);
                  num25 = 0.31f + num37;
                  num26 = 0.1f;
                  num27 = (float) (0.439999997615814 + (double) num37 * 2.0);
                  break;
                case 27:
                  if (tile.frameY < (short) 36)
                  {
                    num25 = 0.3f;
                    num26 = 0.27f;
                    break;
                  }
                  break;
                case 33:
                  if (tile.frameX == (short) 0)
                  {
                    switch ((int) tile.frameY / 22)
                    {
                      case 0:
                        num25 = 1f;
                        num26 = 0.95f;
                        num27 = 0.65f;
                        break;
                      case 1:
                        num25 = 0.55f;
                        num26 = 0.85f;
                        num27 = 0.35f;
                        break;
                      case 2:
                        num25 = 0.65f;
                        num26 = 0.95f;
                        num27 = 0.5f;
                        break;
                      case 3:
                        num25 = 0.2f;
                        num26 = 0.75f;
                        num27 = 1f;
                        break;
                      case 14:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.6f;
                        break;
                      case 19:
                        num25 = 0.37f;
                        num26 = 0.8f;
                        num27 = 1f;
                        break;
                      case 20:
                        num25 = 0.0f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 21:
                        num25 = 0.25f;
                        num26 = 0.7f;
                        num27 = 1f;
                        break;
                      case 25:
                        num25 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num26 = 0.3f;
                        num27 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 28:
                        num25 = 0.9f;
                        num26 = 0.75f;
                        num27 = 1f;
                        break;
                      case 30:
                        Vector3 vector3_1 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                        num25 = vector3_1.X;
                        num26 = vector3_1.Y;
                        num27 = vector3_1.Z;
                        break;
                      default:
                        num25 = 1f;
                        num26 = 0.95f;
                        num27 = 0.65f;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case 34:
                  if ((int) tile.frameX % 108 < 54)
                  {
                    switch ((int) tile.frameY / 54 + 37 * ((int) tile.frameX / 108))
                    {
                      case 7:
                        num25 = 0.95f;
                        num26 = 0.95f;
                        num27 = 0.5f;
                        break;
                      case 8:
                        num25 = 0.85f;
                        num26 = 0.6f;
                        num27 = 1f;
                        break;
                      case 9:
                        num25 = 1f;
                        num26 = 0.6f;
                        num27 = 0.6f;
                        break;
                      case 11:
                      case 17:
                        num25 = 0.75f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 15:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.7f;
                        break;
                      case 18:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.6f;
                        break;
                      case 24:
                        num25 = 0.37f;
                        num26 = 0.8f;
                        num27 = 1f;
                        break;
                      case 25:
                        num25 = 0.0f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 26:
                        num25 = 0.25f;
                        num26 = 0.7f;
                        num27 = 1f;
                        break;
                      case 27:
                        num25 = 0.55f;
                        num26 = 0.85f;
                        num27 = 0.35f;
                        break;
                      case 28:
                        num25 = 0.65f;
                        num26 = 0.95f;
                        num27 = 0.5f;
                        break;
                      case 29:
                        num25 = 0.2f;
                        num26 = 0.75f;
                        num27 = 1f;
                        break;
                      case 32:
                        num25 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num26 = 0.3f;
                        num27 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 35:
                        num25 = 0.9f;
                        num26 = 0.75f;
                        num27 = 1f;
                        break;
                      case 37:
                        Vector3 vector3_2 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                        num25 = vector3_2.X;
                        num26 = vector3_2.Y;
                        num27 = vector3_2.Z;
                        break;
                      default:
                        num25 = 1f;
                        num26 = 0.95f;
                        num27 = 0.8f;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case 35:
                  if (tile.frameX < (short) 36)
                  {
                    num25 = 0.75f;
                    num26 = 0.6f;
                    num27 = 0.3f;
                    break;
                  }
                  break;
                case 37:
                  num25 = 0.56f;
                  num26 = 0.43f;
                  num27 = 0.15f;
                  break;
                case 42:
                  if (tile.frameX == (short) 0)
                  {
                    switch ((int) tile.frameY / 36)
                    {
                      case 0:
                        num25 = 0.7f;
                        num26 = 0.65f;
                        num27 = 0.55f;
                        break;
                      case 1:
                        num25 = 0.9f;
                        num26 = 0.75f;
                        num27 = 0.6f;
                        break;
                      case 2:
                        num25 = 0.8f;
                        num26 = 0.6f;
                        num27 = 0.6f;
                        break;
                      case 3:
                        num25 = 0.65f;
                        num26 = 0.5f;
                        num27 = 0.2f;
                        break;
                      case 4:
                        num25 = 0.5f;
                        num26 = 0.7f;
                        num27 = 0.4f;
                        break;
                      case 5:
                        num25 = 0.9f;
                        num26 = 0.4f;
                        num27 = 0.2f;
                        break;
                      case 6:
                        num25 = 0.7f;
                        num26 = 0.75f;
                        num27 = 0.3f;
                        break;
                      case 7:
                        float num38 = Main.demonTorch * 0.2f;
                        num25 = 0.9f - num38;
                        num26 = 0.9f - num38;
                        num27 = 0.7f + num38;
                        break;
                      case 8:
                        num25 = 0.75f;
                        num26 = 0.6f;
                        num27 = 0.3f;
                        break;
                      case 9:
                        float num39 = 1f;
                        float num40 = 0.3f;
                        num27 = 0.5f + Main.demonTorch * 0.2f;
                        num25 = num39 - Main.demonTorch * 0.1f;
                        num26 = num40 - Main.demonTorch * 0.2f;
                        break;
                      case 28:
                        num25 = 0.37f;
                        num26 = 0.8f;
                        num27 = 1f;
                        break;
                      case 29:
                        num25 = 0.0f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 30:
                        num25 = 0.25f;
                        num26 = 0.7f;
                        num27 = 1f;
                        break;
                      case 32:
                        num25 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num26 = 0.3f;
                        num27 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 35:
                        num25 = 0.7f;
                        num26 = 0.6f;
                        num27 = 0.9f;
                        break;
                      case 37:
                        Vector3 vector3_3 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                        num25 = vector3_3.X;
                        num26 = vector3_3.Y;
                        num27 = vector3_3.Z;
                        break;
                      default:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 1f;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case 49:
                  num25 = 0.0f;
                  num26 = 0.35f;
                  num27 = 0.8f;
                  break;
                case 61:
                  if (tile.frameX == (short) 144)
                  {
                    float num41 = (float) (1.0 + (double) (270 - (int) Main.mouseTextColor) / 400.0);
                    float num42 = (float) (0.800000011920929 - (double) (270 - (int) Main.mouseTextColor) / 400.0);
                    num25 = 0.42f * num42;
                    num26 = 0.81f * num41;
                    num27 = 0.52f * num42;
                    break;
                  }
                  break;
                case 70:
                case 71:
                case 72:
                case 190:
                case 348:
                case 349:
                  if (tile.type != (ushort) 349 || tile.frameX >= (short) 36)
                  {
                    float num43 = (float) Main.rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 1000f;
                    num25 = 0.1f;
                    num26 = (float) (0.200000002980232 + (double) num43 / 2.0);
                    num27 = 0.7f + num43;
                    break;
                  }
                  break;
                case 77:
                  num25 = 0.75f;
                  num26 = 0.45f;
                  num27 = 0.25f;
                  break;
                case 83:
                  if (tile.frameX == (short) 18 && !Main.dayTime)
                  {
                    num25 = 0.1f;
                    num26 = 0.4f;
                    num27 = 0.6f;
                  }
                  if (tile.frameX == (short) 90 && !Main.raining && Main.time > 40500.0)
                  {
                    num25 = 0.9f;
                    num26 = 0.72f;
                    num27 = 0.18f;
                    break;
                  }
                  break;
                case 84:
                  switch ((int) tile.frameX / 18)
                  {
                    case 2:
                      float num44 = (float) (270 - (int) Main.mouseTextColor) / 800f;
                      if ((double) num44 > 1.0)
                        num44 = 1f;
                      else if ((double) num44 < 0.0)
                        num44 = 0.0f;
                      num25 = num44 * 0.7f;
                      num26 = num44;
                      num27 = num44 * 0.1f;
                      break;
                    case 5:
                      float num45 = 0.9f;
                      num25 = num45;
                      num26 = num45 * 0.8f;
                      num27 = num45 * 0.2f;
                      break;
                    case 6:
                      float num46 = 0.08f;
                      num26 = num46 * 0.8f;
                      num27 = num46;
                      break;
                  }
                  break;
                case 92:
                  if (tile.frameY <= (short) 18 && tile.frameX == (short) 0)
                  {
                    num25 = 1f;
                    num26 = 1f;
                    num27 = 1f;
                    break;
                  }
                  break;
                case 93:
                  if (tile.frameX == (short) 0)
                  {
                    switch ((int) tile.frameY / 54)
                    {
                      case 1:
                        num25 = 0.95f;
                        num26 = 0.95f;
                        num27 = 0.5f;
                        break;
                      case 2:
                        num25 = 0.85f;
                        num26 = 0.6f;
                        num27 = 1f;
                        break;
                      case 3:
                        num25 = 0.75f;
                        num26 = 1f;
                        num27 = 0.6f;
                        break;
                      case 4:
                      case 5:
                        num25 = 0.75f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 9:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.7f;
                        break;
                      case 13:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.6f;
                        break;
                      case 19:
                        num25 = 0.37f;
                        num26 = 0.8f;
                        num27 = 1f;
                        break;
                      case 20:
                        num25 = 0.0f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 21:
                        num25 = 0.25f;
                        num26 = 0.7f;
                        num27 = 1f;
                        break;
                      case 23:
                        num25 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num26 = 0.3f;
                        num27 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 24:
                        num25 = 0.35f;
                        num26 = 0.5f;
                        num27 = 0.3f;
                        break;
                      case 25:
                        num25 = 0.34f;
                        num26 = 0.4f;
                        num27 = 0.31f;
                        break;
                      case 26:
                        num25 = 0.25f;
                        num26 = 0.32f;
                        num27 = 0.5f;
                        break;
                      case 29:
                        num25 = 0.9f;
                        num26 = 0.75f;
                        num27 = 1f;
                        break;
                      case 31:
                        Vector3 vector3_4 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                        num25 = vector3_4.X;
                        num26 = vector3_4.Y;
                        num27 = vector3_4.Z;
                        break;
                      default:
                        num25 = 1f;
                        num26 = 0.97f;
                        num27 = 0.85f;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case 95:
                  if (tile.frameX < (short) 36)
                  {
                    num25 = 1f;
                    num26 = 0.95f;
                    num27 = 0.8f;
                    break;
                  }
                  break;
                case 96:
                  if (tile.frameX >= (short) 36)
                  {
                    num25 = 0.5f;
                    num26 = 0.35f;
                    num27 = 0.1f;
                    break;
                  }
                  break;
                case 98:
                  if (tile.frameY == (short) 0)
                  {
                    num25 = 1f;
                    num26 = 0.97f;
                    num27 = 0.85f;
                    break;
                  }
                  break;
                case 100:
                case 173:
                  if (tile.frameX < (short) 36)
                  {
                    switch ((int) tile.frameY / 36)
                    {
                      case 1:
                        num25 = 0.95f;
                        num26 = 0.95f;
                        num27 = 0.5f;
                        break;
                      case 3:
                        num25 = 1f;
                        num26 = 0.6f;
                        num27 = 0.6f;
                        break;
                      case 6:
                      case 9:
                        num25 = 0.75f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 11:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.7f;
                        break;
                      case 13:
                        num25 = 1f;
                        num26 = 1f;
                        num27 = 0.6f;
                        break;
                      case 19:
                        num25 = 0.37f;
                        num26 = 0.8f;
                        num27 = 1f;
                        break;
                      case 20:
                        num25 = 0.0f;
                        num26 = 0.9f;
                        num27 = 1f;
                        break;
                      case 21:
                        num25 = 0.25f;
                        num26 = 0.7f;
                        num27 = 1f;
                        break;
                      case 22:
                        num25 = 0.35f;
                        num26 = 0.5f;
                        num27 = 0.3f;
                        break;
                      case 23:
                        num25 = 0.34f;
                        num26 = 0.4f;
                        num27 = 0.31f;
                        break;
                      case 24:
                        num25 = 0.25f;
                        num26 = 0.32f;
                        num27 = 0.5f;
                        break;
                      case 25:
                        num25 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num26 = 0.3f;
                        num27 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 29:
                        num25 = 0.9f;
                        num26 = 0.75f;
                        num27 = 1f;
                        break;
                      case 31:
                        Vector3 vector3_5 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                        num25 = vector3_5.X;
                        num26 = vector3_5.Y;
                        num27 = vector3_5.Z;
                        break;
                      default:
                        num25 = 1f;
                        num26 = 0.95f;
                        num27 = 0.65f;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case 125:
                  float num47 = (float) Main.rand.Next(28, 42) * 0.01f + (float) (270 - (int) Main.mouseTextColor) / 800f;
                  num26 = lightingState.g2 = 0.3f * num47;
                  num27 = lightingState.b2 = 0.6f * num47;
                  break;
                case 126:
                  if (tile.frameX < (short) 36)
                  {
                    num25 = (float) Main.DiscoR / (float) byte.MaxValue;
                    num26 = (float) Main.DiscoG / (float) byte.MaxValue;
                    num27 = (float) Main.DiscoB / (float) byte.MaxValue;
                    break;
                  }
                  break;
                case 129:
                  switch ((int) tile.frameX / 18 % 3)
                  {
                    case 0:
                      num25 = 0.0f;
                      num26 = 0.05f;
                      num27 = 0.25f;
                      break;
                    case 1:
                      num25 = 0.2f;
                      num26 = 0.0f;
                      num27 = 0.15f;
                      break;
                    case 2:
                      num25 = 0.1f;
                      num26 = 0.0f;
                      num27 = 0.2f;
                      break;
                  }
                  break;
                case 149:
                  if (tile.frameX <= (short) 36)
                  {
                    switch ((int) tile.frameX / 18)
                    {
                      case 0:
                        num25 = 0.1f;
                        num26 = 0.2f;
                        num27 = 0.5f;
                        break;
                      case 1:
                        num25 = 0.5f;
                        num26 = 0.1f;
                        num27 = 0.1f;
                        break;
                      case 2:
                        num25 = 0.2f;
                        num26 = 0.5f;
                        num27 = 0.1f;
                        break;
                    }
                    num25 *= (float) Main.rand.Next(970, 1031) * (1f / 1000f);
                    num26 *= (float) Main.rand.Next(970, 1031) * (1f / 1000f);
                    num27 *= (float) Main.rand.Next(970, 1031) * (1f / 1000f);
                    break;
                  }
                  break;
                case 160:
                  num25 = (float) ((double) Main.DiscoR / (double) byte.MaxValue * 0.25);
                  num26 = (float) ((double) Main.DiscoG / (double) byte.MaxValue * 0.25);
                  num27 = (float) ((double) Main.DiscoB / (double) byte.MaxValue * 0.25);
                  break;
                case 171:
                  int index8 = index5;
                  int index9 = index6;
                  if (tile.frameX < (short) 10)
                  {
                    index8 -= (int) tile.frameX;
                    index9 -= (int) tile.frameY;
                  }
                  switch (((int) Main.tile[index8, index9].frameY & 15360) >> 10)
                  {
                    case 1:
                      num25 = 0.1f;
                      num26 = 0.1f;
                      num27 = 0.1f;
                      break;
                    case 2:
                      num25 = 0.2f;
                      break;
                    case 3:
                      num26 = 0.2f;
                      break;
                    case 4:
                      num27 = 0.2f;
                      break;
                    case 5:
                      num25 = 0.125f;
                      num26 = 0.125f;
                      break;
                    case 6:
                      num25 = 0.2f;
                      num26 = 0.1f;
                      break;
                    case 7:
                      num25 = 0.125f;
                      num26 = 0.125f;
                      break;
                    case 8:
                      num25 = 0.08f;
                      num26 = 0.175f;
                      break;
                    case 9:
                      num26 = 0.125f;
                      num27 = 0.125f;
                      break;
                    case 10:
                      num25 = 0.125f;
                      num27 = 0.125f;
                      break;
                    case 11:
                      num25 = 0.1f;
                      num26 = 0.1f;
                      num27 = 0.2f;
                      break;
                    default:
                      double num48;
                      num27 = (float) (num48 = 0.0);
                      num26 = (float) num48;
                      num25 = (float) num48;
                      break;
                  }
                  num25 *= 0.5f;
                  num26 *= 0.5f;
                  num27 *= 0.5f;
                  break;
                case 174:
                  if (tile.frameX == (short) 0)
                  {
                    num25 = 1f;
                    num26 = 0.95f;
                    num27 = 0.65f;
                    break;
                  }
                  break;
                case 184:
                  if (tile.frameX == (short) 110)
                  {
                    num25 = 0.25f;
                    num26 = 0.1f;
                    num27 = 0.0f;
                    break;
                  }
                  break;
                case 204:
                case 347:
                  num25 = 0.35f;
                  break;
                case 209:
                  if (tile.frameX == (short) 234 || tile.frameX == (short) 252)
                  {
                    Vector3 vector3_6 = PortalHelper.GetPortalColor(Main.myPlayer, 0).ToVector3() * 0.65f;
                    num25 = vector3_6.X;
                    num26 = vector3_6.Y;
                    num27 = vector3_6.Z;
                    break;
                  }
                  if (tile.frameX == (short) 306 || tile.frameX == (short) 324)
                  {
                    Vector3 vector3_7 = PortalHelper.GetPortalColor(Main.myPlayer, 1).ToVector3() * 0.65f;
                    num25 = vector3_7.X;
                    num26 = vector3_7.Y;
                    num27 = vector3_7.Z;
                    break;
                  }
                  break;
                case 215:
                  if (tile.frameY < (short) 36)
                  {
                    float num49 = (float) Main.rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 700f;
                    float num50;
                    float num51;
                    float num52;
                    switch ((int) tile.frameX / 54)
                    {
                      case 1:
                        num50 = 0.7f;
                        num51 = 1f;
                        num52 = 0.5f;
                        break;
                      case 2:
                        num50 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num51 = 0.3f;
                        num52 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 3:
                        num50 = 0.45f;
                        num51 = 0.75f;
                        num52 = 1f;
                        break;
                      case 4:
                        num50 = 1.15f;
                        num51 = 1.15f;
                        num52 = 0.5f;
                        break;
                      case 5:
                        num50 = (float) Main.DiscoR / (float) byte.MaxValue;
                        num51 = (float) Main.DiscoG / (float) byte.MaxValue;
                        num52 = (float) Main.DiscoB / (float) byte.MaxValue;
                        break;
                      case 6:
                        num50 = 0.75f;
                        num51 = 1.2825f;
                        num52 = 1.2f;
                        break;
                      case 7:
                        num50 = 0.95f;
                        num51 = 0.65f;
                        num52 = 1.3f;
                        break;
                      default:
                        num50 = 0.9f;
                        num51 = 0.3f;
                        num52 = 0.1f;
                        break;
                    }
                    num25 = num50 + num49;
                    num26 = num51 + num49;
                    num27 = num52 + num49;
                    break;
                  }
                  break;
                case 235:
                  if ((double) lightingState.r2 < 0.6)
                    lightingState.r2 = 0.6f;
                  if ((double) lightingState.g2 < 0.6)
                  {
                    lightingState.g2 = 0.6f;
                    break;
                  }
                  break;
                case 237:
                  num25 = 0.1f;
                  num26 = 0.1f;
                  break;
                case 238:
                  if ((double) lightingState.r2 < 0.5)
                    lightingState.r2 = 0.5f;
                  if ((double) lightingState.b2 < 0.5)
                  {
                    lightingState.b2 = 0.5f;
                    break;
                  }
                  break;
                case 262:
                  num25 = 0.75f;
                  num27 = 0.75f;
                  break;
                case 263:
                  num25 = 0.75f;
                  num26 = 0.75f;
                  break;
                case 264:
                  num27 = 0.75f;
                  break;
                case 265:
                  num26 = 0.75f;
                  break;
                case 266:
                  num25 = 0.75f;
                  break;
                case 267:
                  num25 = 0.75f;
                  num26 = 0.75f;
                  num27 = 0.75f;
                  break;
                case 268:
                  num25 = 0.75f;
                  num26 = 0.375f;
                  break;
                case 270:
                  num25 = 0.73f;
                  num26 = 1f;
                  num27 = 0.41f;
                  break;
                case 271:
                  num25 = 0.45f;
                  num26 = 0.95f;
                  num27 = 1f;
                  break;
                case 286:
                  num25 = 0.1f;
                  num26 = 0.2f;
                  num27 = 0.7f;
                  break;
                case 316:
                case 317:
                case 318:
                  int index10 = (index5 - (int) tile.frameX / 18) / 2 * ((index6 - (int) tile.frameY / 18) / 3) % Main.cageFrames;
                  bool flag1 = Main.jellyfishCageMode[(int) tile.type - 316, index10] == (byte) 2;
                  if (tile.type == (ushort) 316)
                  {
                    if (flag1)
                    {
                      num25 = 0.2f;
                      num26 = 0.3f;
                      num27 = 0.8f;
                    }
                    else
                    {
                      num25 = 0.1f;
                      num26 = 0.2f;
                      num27 = 0.5f;
                    }
                  }
                  if (tile.type == (ushort) 317)
                  {
                    if (flag1)
                    {
                      num25 = 0.2f;
                      num26 = 0.7f;
                      num27 = 0.3f;
                    }
                    else
                    {
                      num25 = 0.05f;
                      num26 = 0.45f;
                      num27 = 0.1f;
                    }
                  }
                  if (tile.type == (ushort) 318)
                  {
                    if (flag1)
                    {
                      num25 = 0.7f;
                      num26 = 0.2f;
                      num27 = 0.5f;
                      break;
                    }
                    num25 = 0.4f;
                    num26 = 0.1f;
                    num27 = 0.25f;
                    break;
                  }
                  break;
                case 327:
                  float num53 = 0.5f + (float) (270 - (int) Main.mouseTextColor) / 1500f + (float) Main.rand.Next(0, 50) * 0.0005f;
                  num25 = 1f * num53;
                  num26 = 0.5f * num53;
                  num27 = 0.1f * num53;
                  break;
                case 336:
                  num25 = 0.85f;
                  num26 = 0.5f;
                  num27 = 0.3f;
                  break;
                case 340:
                  num25 = 0.45f;
                  num26 = 1f;
                  num27 = 0.45f;
                  break;
                case 341:
                  num25 = (float) (0.400000005960464 * (double) Main.demonTorch + 0.600000023841858 * (1.0 - (double) Main.demonTorch));
                  num26 = 0.35f;
                  num27 = (float) (1.0 * (double) Main.demonTorch + 0.600000023841858 * (1.0 - (double) Main.demonTorch));
                  break;
                case 342:
                  num25 = 0.5f;
                  num26 = 0.5f;
                  num27 = 1.1f;
                  break;
                case 343:
                  num25 = 0.85f;
                  num26 = 0.85f;
                  num27 = 0.3f;
                  break;
                case 344:
                  num25 = 0.6f;
                  num26 = 1.026f;
                  num27 = 0.96f;
                  break;
                case 350:
                  double num54 = Main.time * 0.08;
                  double num55;
                  num25 = (float) (num55 = -Math.Cos((int) (num54 / 6.283) % 3 == 1 ? num54 : 0.0) * 0.1 + 0.1);
                  num26 = (float) num55;
                  num27 = (float) num55;
                  break;
                case 370:
                  num25 = 0.32f;
                  num26 = 0.16f;
                  num27 = 0.12f;
                  break;
                case 372:
                  if (tile.frameX == (short) 0)
                  {
                    num25 = 0.9f;
                    num26 = 0.1f;
                    num27 = 0.75f;
                    break;
                  }
                  break;
                case 381:
                  num25 = 0.25f;
                  num26 = 0.1f;
                  num27 = 0.0f;
                  break;
                case 390:
                  num25 = 0.4f;
                  num26 = 0.2f;
                  num27 = 0.1f;
                  break;
                case 391:
                  num25 = 0.3f;
                  num26 = 0.1f;
                  num27 = 0.25f;
                  break;
                case 405:
                  if (tile.frameX < (short) 54)
                  {
                    float num56 = (float) Main.rand.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 700f;
                    float num57;
                    float num58;
                    float num59;
                    switch ((int) tile.frameX / 54)
                    {
                      case 1:
                        num57 = 0.7f;
                        num58 = 1f;
                        num59 = 0.5f;
                        break;
                      case 2:
                        num57 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                        num58 = 0.3f;
                        num59 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                        break;
                      case 3:
                        num57 = 0.45f;
                        num58 = 0.75f;
                        num59 = 1f;
                        break;
                      case 4:
                        num57 = 1.15f;
                        num58 = 1.15f;
                        num59 = 0.5f;
                        break;
                      case 5:
                        num57 = (float) Main.DiscoR / (float) byte.MaxValue;
                        num58 = (float) Main.DiscoG / (float) byte.MaxValue;
                        num59 = (float) Main.DiscoB / (float) byte.MaxValue;
                        break;
                      default:
                        num57 = 0.9f;
                        num58 = 0.3f;
                        num59 = 0.1f;
                        break;
                    }
                    num25 = num57 + num56;
                    num26 = num58 + num56;
                    num27 = num59 + num56;
                    break;
                  }
                  break;
                case 415:
                  num25 = 0.7f;
                  num26 = 0.5f;
                  num27 = 0.1f;
                  break;
                case 416:
                  num25 = 0.0f;
                  num26 = 0.6f;
                  num27 = 0.7f;
                  break;
                case 417:
                  num25 = 0.6f;
                  num26 = 0.2f;
                  num27 = 0.6f;
                  break;
                case 418:
                  num25 = 0.6f;
                  num26 = 0.6f;
                  num27 = 0.9f;
                  break;
                case 429:
                  int num60 = (int) tile.frameX / 18;
                  bool flag2 = num60 % 2 >= 1;
                  bool flag3 = num60 % 4 >= 2;
                  bool flag4 = num60 % 8 >= 4;
                  int num61 = num60 % 16 >= 8 ? 1 : 0;
                  if (flag2)
                    num25 += 0.5f;
                  if (flag3)
                    num26 += 0.5f;
                  if (flag4)
                    num27 += 0.5f;
                  if (num61 != 0)
                  {
                    num25 += 0.2f;
                    num26 += 0.2f;
                    break;
                  }
                  break;
                case 463:
                  num25 = 0.2f;
                  num26 = 0.4f;
                  num27 = 0.8f;
                  break;
              }
            }
          }
          if (Lighting.RGB)
          {
            if ((double) lightingState.r2 < (double) num25)
              lightingState.r2 = num25;
            if ((double) lightingState.g2 < (double) num26)
              lightingState.g2 = num26;
            if ((double) lightingState.b2 < (double) num27)
              lightingState.b2 = num27;
          }
          else
          {
            float num62 = (float) (((double) num25 + (double) num26 + (double) num27) / 3.0);
            if ((double) lightingState.r2 < (double) num62)
              lightingState.r2 = num62;
          }
          if (tile.lava() && tile.liquid > (byte) 0)
          {
            if (Lighting.RGB)
            {
              float num63 = (float) ((double) ((int) tile.liquid / (int) byte.MaxValue) * 0.409999996423721 + 0.140000000596046);
              float num64 = 0.55f + (float) (270 - (int) Main.mouseTextColor) / 900f;
              if ((double) lightingState.r2 < (double) num64)
                lightingState.r2 = num64;
              if ((double) lightingState.g2 < (double) num64)
                lightingState.g2 = num64 * 0.6f;
              if ((double) lightingState.b2 < (double) num64)
                lightingState.b2 = num64 * 0.2f;
            }
            else
            {
              float num65 = (float) ((double) ((int) tile.liquid / (int) byte.MaxValue) * 0.379999995231628 + 0.0799999982118607) + (float) (270 - (int) Main.mouseTextColor) / 2000f;
              if ((double) lightingState.r2 < (double) num65)
                lightingState.r2 = num65;
            }
          }
          else if (tile.liquid > (byte) 128)
          {
            lightingState.wetLight = true;
            if (tile.honey())
              lightingState.honeyLight = true;
          }
          if ((double) lightingState.r2 > 0.0 || Lighting.RGB && ((double) lightingState.g2 > 0.0 || (double) lightingState.b2 > 0.0))
          {
            int num66 = index5 - Lighting.firstToLightX;
            int num67 = index6 - Lighting.firstToLightY;
            if (Lighting.minX > num66)
              Lighting.minX = num66;
            if (Lighting.maxX < num66 + 1)
              Lighting.maxX = num66 + 1;
            if (Lighting.minY > num67)
              Lighting.minY = num67;
            if (Lighting.maxY < num67 + 1)
              Lighting.maxY = num67 + 1;
          }
        }
      }
      foreach (KeyValuePair<Point16, Lighting.ColorTriplet> tempLight in Lighting.tempLights)
      {
        int index11 = (int) tempLight.Key.X - Lighting.firstTileX + Lighting.offScreenTiles;
        int index12 = (int) tempLight.Key.Y - Lighting.firstTileY + Lighting.offScreenTiles;
        if (index11 >= 0 && index11 < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && index12 >= 0 && index12 < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
        {
          Lighting.LightingState lightingState = Lighting.states[index11][index12];
          if ((double) lightingState.r2 < (double) tempLight.Value.r)
            lightingState.r2 = tempLight.Value.r;
          if ((double) lightingState.g2 < (double) tempLight.Value.g)
            lightingState.g2 = tempLight.Value.g;
          if ((double) lightingState.b2 < (double) tempLight.Value.b)
            lightingState.b2 = tempLight.Value.b;
          if (Lighting.minX > index11)
            Lighting.minX = index11;
          if (Lighting.maxX < index11 + 1)
            Lighting.maxX = index11 + 1;
          if (Lighting.minY > index12)
            Lighting.minY = index12;
          if (Lighting.maxY < index12 + 1)
            Lighting.maxY = index12 + 1;
        }
      }
      if (!Main.gamePaused)
        Lighting.tempLights.Clear();
      if (screenTileCounts[27] > 0)
        Main.sunflower = true;
      Main.holyTiles = screenTileCounts[109] + screenTileCounts[110] + screenTileCounts[113] + screenTileCounts[117] + screenTileCounts[116] + screenTileCounts[164] + screenTileCounts[403] + screenTileCounts[402];
      Main.evilTiles = screenTileCounts[23] + screenTileCounts[24] + screenTileCounts[25] + screenTileCounts[32] + screenTileCounts[112] + screenTileCounts[163] + screenTileCounts[400] + screenTileCounts[398] + -5 * screenTileCounts[27];
      Main.bloodTiles = screenTileCounts[199] + screenTileCounts[203] + screenTileCounts[200] + screenTileCounts[401] + screenTileCounts[399] + screenTileCounts[234] + screenTileCounts[352] - 5 * screenTileCounts[27];
      Main.snowTiles = screenTileCounts[147] + screenTileCounts[148] + screenTileCounts[161] + screenTileCounts[162] + screenTileCounts[164] + screenTileCounts[163] + screenTileCounts[200];
      Main.jungleTiles = screenTileCounts[60] + screenTileCounts[61] + screenTileCounts[62] + screenTileCounts[74] + screenTileCounts[226];
      Main.shroomTiles = screenTileCounts[70] + screenTileCounts[71] + screenTileCounts[72];
      Main.meteorTiles = screenTileCounts[37];
      Main.dungeonTiles = screenTileCounts[41] + screenTileCounts[43] + screenTileCounts[44];
      Main.sandTiles = screenTileCounts[53] + screenTileCounts[112] + screenTileCounts[116] + screenTileCounts[234] + screenTileCounts[397] + screenTileCounts[398] + screenTileCounts[402] + screenTileCounts[399] + screenTileCounts[396] + screenTileCounts[400] + screenTileCounts[403] + screenTileCounts[401];
      Main.waterCandles = screenTileCounts[49];
      Main.peaceCandles = screenTileCounts[372];
      Main.partyMonoliths = screenTileCounts[455];
      if (Main.player[Main.myPlayer].accOreFinder)
      {
        Main.player[Main.myPlayer].bestOre = -1;
        for (int index = 0; index < 470; ++index)
        {
          if (screenTileCounts[index] > 0 && Main.tileValue[index] > (short) 0 && (Main.player[Main.myPlayer].bestOre < 0 || (int) Main.tileValue[index] > (int) Main.tileValue[Main.player[Main.myPlayer].bestOre]))
            Main.player[Main.myPlayer].bestOre = index;
        }
      }
      if (Main.holyTiles < 0)
        Main.holyTiles = 0;
      if (Main.evilTiles < 0)
        Main.evilTiles = 0;
      if (Main.bloodTiles < 0)
        Main.bloodTiles = 0;
      int holyTiles = Main.holyTiles;
      Main.holyTiles -= Main.evilTiles;
      Main.holyTiles -= Main.bloodTiles;
      Main.evilTiles -= holyTiles;
      Main.bloodTiles -= holyTiles;
      if (Main.holyTiles < 0)
        Main.holyTiles = 0;
      if (Main.evilTiles < 0)
        Main.evilTiles = 0;
      if (Main.bloodTiles < 0)
        Main.bloodTiles = 0;
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
      Lighting.firstToLightX27 = Lighting.firstTileX - Lighting.offScreenTiles2;
      Lighting.firstToLightY27 = Lighting.firstTileY - Lighting.offScreenTiles2;
      Lighting.lastToLightX27 = Lighting.lastTileX + Lighting.offScreenTiles2;
      Lighting.lastToLightY27 = Lighting.lastTileY + Lighting.offScreenTiles2;
      Lighting.scrX = (int) Math.Floor((double) Main.screenPosition.X / 16.0);
      Lighting.scrY = (int) Math.Floor((double) Main.screenPosition.Y / 16.0);
      Main.renderCount = 0;
      TimeLogger.LightingTime(0, stopwatch.Elapsed.TotalMilliseconds);
      Lighting.doColors();
    }

    public static void doColors()
    {
      if (Lighting.lightMode < 2)
      {
        Lighting.blueWave += (float) Lighting.blueDir * 0.0001f;
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
          Lighting.honeyLightG = 0.7f * Lighting.negLight * Lighting.blueWave;
          Lighting.honeyLightR = 0.75f * Lighting.negLight * Lighting.blueWave;
          Lighting.honeyLightB = 0.6f * Lighting.negLight * Lighting.blueWave;
          switch (Main.waterStyle)
          {
            case 0:
            case 1:
            case 7:
            case 8:
              Lighting.wetLightG = 0.96f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.88f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 1.015f * Lighting.negLight * Lighting.blueWave;
              break;
            case 2:
              Lighting.wetLightG = 0.85f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.94f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
              break;
            case 3:
              Lighting.wetLightG = 0.95f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.84f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 1.015f * Lighting.negLight * Lighting.blueWave;
              break;
            case 4:
              Lighting.wetLightG = 0.86f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.9f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
              break;
            case 5:
              Lighting.wetLightG = 0.99f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.84f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
              break;
            case 6:
              Lighting.wetLightG = 0.98f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.95f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 0.85f * Lighting.negLight * Lighting.blueWave;
              break;
            case 9:
              Lighting.wetLightG = 0.88f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 1f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 0.84f * Lighting.negLight * Lighting.blueWave;
              break;
            case 10:
              Lighting.wetLightG = 1f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightR = 0.83f * Lighting.negLight * Lighting.blueWave;
              Lighting.wetLightB = 1f * Lighting.negLight * Lighting.blueWave;
              break;
            default:
              Lighting.wetLightG = 0.0f;
              Lighting.wetLightR = 0.0f;
              Lighting.wetLightB = 0.0f;
              break;
          }
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
        if (Main.player[Main.myPlayer].blackout)
        {
          Lighting.negLight *= 0.85f;
          Lighting.negLight2 *= 0.85f;
        }
        if (Main.player[Main.myPlayer].headcovered)
        {
          Lighting.negLight *= 0.85f;
          Lighting.negLight2 *= 0.85f;
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
        if (Main.player[Main.myPlayer].blackout)
        {
          Lighting.negLight += 0.09f;
          Lighting.negLight2 += 0.18f;
        }
        if (Main.player[Main.myPlayer].headcovered)
        {
          Lighting.negLight += 0.09f;
          Lighting.negLight2 += 0.18f;
        }
        Lighting.wetLightR = Lighting.negLight * 1.2f;
        Lighting.wetLightG = Lighting.negLight * 1.1f;
      }
      int num1;
      int num2;
      switch (Main.renderCount)
      {
        case 0:
          num1 = 0;
          num2 = 1;
          break;
        case 1:
          num1 = 1;
          num2 = 3;
          break;
        case 2:
          num1 = 3;
          num2 = 4;
          break;
        default:
          num1 = 0;
          num2 = 0;
          break;
      }
      if (Lighting.LightingThreads < 0)
        Lighting.LightingThreads = 0;
      if (Lighting.LightingThreads >= Environment.ProcessorCount)
        Lighting.LightingThreads = Environment.ProcessorCount - 1;
      int lightingThreads = Lighting.LightingThreads;
      if (lightingThreads > 0)
        ++lightingThreads;
      Stopwatch stopwatch = new Stopwatch();
      for (int index1 = num1; index1 < num2; ++index1)
      {
        stopwatch.Restart();
        switch (index1)
        {
          case 0:
            Lighting.swipe.innerLoop1Start = Lighting.minY7 - Lighting.firstToLightY7;
            Lighting.swipe.innerLoop1End = Lighting.lastToLightY27 + Lighting.maxRenderCount - Lighting.firstToLightY7;
            Lighting.swipe.innerLoop2Start = Lighting.maxY7 - Lighting.firstToLightY;
            Lighting.swipe.innerLoop2End = Lighting.firstTileY7 - Lighting.maxRenderCount - Lighting.firstToLightY7;
            Lighting.swipe.outerLoopStart = Lighting.minX7 - Lighting.firstToLightX7;
            Lighting.swipe.outerLoopEnd = Lighting.maxX7 - Lighting.firstToLightX7;
            Lighting.swipe.jaggedArray = Lighting.states;
            break;
          case 1:
            Lighting.swipe.innerLoop1Start = Lighting.minX7 - Lighting.firstToLightX7;
            Lighting.swipe.innerLoop1End = Lighting.lastTileX7 + Lighting.maxRenderCount - Lighting.firstToLightX7;
            Lighting.swipe.innerLoop2Start = Lighting.maxX7 - Lighting.firstToLightX7;
            Lighting.swipe.innerLoop2End = Lighting.firstTileX7 - Lighting.maxRenderCount - Lighting.firstToLightX7;
            Lighting.swipe.outerLoopStart = Lighting.firstToLightY7 - Lighting.firstToLightY7;
            Lighting.swipe.outerLoopEnd = Lighting.lastToLightY7 - Lighting.firstToLightY7;
            Lighting.swipe.jaggedArray = Lighting.axisFlipStates;
            break;
          case 2:
            Lighting.swipe.innerLoop1Start = Lighting.firstToLightY27 - Lighting.firstToLightY7;
            Lighting.swipe.innerLoop1End = Lighting.lastTileY7 + Lighting.maxRenderCount - Lighting.firstToLightY7;
            Lighting.swipe.innerLoop2Start = Lighting.lastToLightY27 - Lighting.firstToLightY;
            Lighting.swipe.innerLoop2End = Lighting.firstTileY7 - Lighting.maxRenderCount - Lighting.firstToLightY7;
            Lighting.swipe.outerLoopStart = Lighting.firstToLightX27 - Lighting.firstToLightX7;
            Lighting.swipe.outerLoopEnd = Lighting.lastToLightX27 - Lighting.firstToLightX7;
            Lighting.swipe.jaggedArray = Lighting.states;
            break;
          case 3:
            Lighting.swipe.innerLoop1Start = Lighting.firstToLightX27 - Lighting.firstToLightX7;
            Lighting.swipe.innerLoop1End = Lighting.lastTileX7 + Lighting.maxRenderCount - Lighting.firstToLightX7;
            Lighting.swipe.innerLoop2Start = Lighting.lastToLightX27 - Lighting.firstToLightX7;
            Lighting.swipe.innerLoop2End = Lighting.firstTileX7 - Lighting.maxRenderCount - Lighting.firstToLightX7;
            Lighting.swipe.outerLoopStart = Lighting.firstToLightY27 - Lighting.firstToLightY7;
            Lighting.swipe.outerLoopEnd = Lighting.lastToLightY27 - Lighting.firstToLightY7;
            Lighting.swipe.jaggedArray = Lighting.axisFlipStates;
            break;
        }
        if (Lighting.swipe.innerLoop1Start > Lighting.swipe.innerLoop1End)
          Lighting.swipe.innerLoop1Start = Lighting.swipe.innerLoop1End;
        if (Lighting.swipe.innerLoop2Start < Lighting.swipe.innerLoop2End)
          Lighting.swipe.innerLoop2Start = Lighting.swipe.innerLoop2End;
        if (Lighting.swipe.outerLoopStart > Lighting.swipe.outerLoopEnd)
          Lighting.swipe.outerLoopStart = Lighting.swipe.outerLoopEnd;
        switch (Lighting.lightMode)
        {
          case 0:
            Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode0_Swipe);
            break;
          case 1:
            Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode1_Swipe);
            break;
          case 2:
            Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode2_Swipe);
            break;
          case 3:
            Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode3_Swipe);
            break;
          default:
            Lighting.swipe.function = (Action<Lighting.LightingSwipeData>) null;
            break;
        }
        if (lightingThreads == 0)
        {
          Lighting.swipe.function(Lighting.swipe);
        }
        else
        {
          int num3 = Lighting.swipe.outerLoopEnd - Lighting.swipe.outerLoopStart;
          int num4 = num3 / lightingThreads;
          int num5 = num3 % lightingThreads;
          int outerLoopStart = Lighting.swipe.outerLoopStart;
          Lighting.countdown.Reset(lightingThreads);
          for (int index2 = 0; index2 < lightingThreads; ++index2)
          {
            Lighting.LightingSwipeData threadSwipe = Lighting.threadSwipes[index2];
            threadSwipe.CopyFrom(Lighting.swipe);
            threadSwipe.outerLoopStart = outerLoopStart;
            outerLoopStart += num4;
            if (num5 > 0)
            {
              ++outerLoopStart;
              --num5;
            }
            threadSwipe.outerLoopEnd = outerLoopStart;
            ThreadPool.QueueUserWorkItem(new WaitCallback(Lighting.callback_LightingSwipe), (object) threadSwipe);
          }
          while (Lighting.countdown.CurrentCount != 0)
            ;
        }
        TimeLogger.LightingTime(index1 + 1, stopwatch.Elapsed.TotalMilliseconds);
      }
    }

    private static void callback_LightingSwipe(object obj)
    {
      Lighting.LightingSwipeData lightingSwipeData = obj as Lighting.LightingSwipeData;
      try
      {
        lightingSwipeData.function(lightingSwipeData);
      }
      catch
      {
      }
      Lighting.countdown.Signal();
    }

    private static void doColors_Mode0_Swipe(Lighting.LightingSwipeData swipeData)
    {
      try
      {
        bool flag1 = true;
        while (true)
        {
          int num1;
          int num2;
          int num3;
          if (flag1)
          {
            num1 = 1;
            num2 = swipeData.innerLoop1Start;
            num3 = swipeData.innerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = swipeData.innerLoop2Start;
            num3 = swipeData.innerLoop2End;
          }
          int outerLoopStart = swipeData.outerLoopStart;
          int outerLoopEnd = swipeData.outerLoopEnd;
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            Lighting.LightingState[] jagged = swipeData.jaggedArray[index1];
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            int num7 = num2;
            int num8 = num3;
            for (int index2 = num7; index2 != num8; index2 += num1)
            {
              Lighting.LightingState lightingState1 = jagged[index2];
              Lighting.LightingState lightingState2 = jagged[index2 + num1];
              bool flag2;
              bool flag3 = flag2 = false;
              if ((double) lightingState1.r2 > (double) num4)
                num4 = lightingState1.r2;
              else if ((double) num4 <= 0.0185)
                flag3 = true;
              else if ((double) lightingState1.r2 < (double) num4)
                lightingState1.r2 = num4;
              if (!flag3 && (double) lightingState2.r2 <= (double) num4)
              {
                if (lightingState1.stopLight)
                  num4 *= Lighting.negLight2;
                else if (lightingState1.wetLight)
                {
                  if (lightingState1.honeyLight)
                    num4 *= (float) ((double) Lighting.honeyLightR * (double) swipeData.rand.Next(98, 100) * 0.00999999977648258);
                  else
                    num4 *= (float) ((double) Lighting.wetLightR * (double) swipeData.rand.Next(98, 100) * 0.00999999977648258);
                }
                else
                  num4 *= Lighting.negLight;
              }
              if ((double) lightingState1.g2 > (double) num5)
                num5 = lightingState1.g2;
              else if ((double) num5 <= 0.0185)
                flag2 = true;
              else
                lightingState1.g2 = num5;
              if (!flag2 && (double) lightingState2.g2 <= (double) num5)
              {
                if (lightingState1.stopLight)
                  num5 *= Lighting.negLight2;
                else if (lightingState1.wetLight)
                {
                  if (lightingState1.honeyLight)
                    num5 *= (float) ((double) Lighting.honeyLightG * (double) swipeData.rand.Next(97, 100) * 0.00999999977648258);
                  else
                    num5 *= (float) ((double) Lighting.wetLightG * (double) swipeData.rand.Next(97, 100) * 0.00999999977648258);
                }
                else
                  num5 *= Lighting.negLight;
              }
              if ((double) lightingState1.b2 > (double) num6)
                num6 = lightingState1.b2;
              else if ((double) num6 > 0.0185)
                lightingState1.b2 = num6;
              else
                continue;
              if ((double) lightingState2.b2 < (double) num6)
              {
                if (lightingState1.stopLight)
                  num6 *= Lighting.negLight2;
                else if (lightingState1.wetLight)
                {
                  if (lightingState1.honeyLight)
                    num6 *= (float) ((double) Lighting.honeyLightB * (double) swipeData.rand.Next(97, 100) * 0.00999999977648258);
                  else
                    num6 *= (float) ((double) Lighting.wetLightB * (double) swipeData.rand.Next(97, 100) * 0.00999999977648258);
                }
                else
                  num6 *= Lighting.negLight;
              }
            }
          }
          if (flag1)
            flag1 = false;
          else
            break;
        }
      }
      catch
      {
      }
    }

    private static void doColors_Mode1_Swipe(Lighting.LightingSwipeData swipeData)
    {
      try
      {
        bool flag = true;
        while (true)
        {
          int num1;
          int num2;
          int num3;
          if (flag)
          {
            num1 = 1;
            num2 = swipeData.innerLoop1Start;
            num3 = swipeData.innerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = swipeData.innerLoop2Start;
            num3 = swipeData.innerLoop2End;
          }
          int outerLoopStart = swipeData.outerLoopStart;
          int outerLoopEnd = swipeData.outerLoopEnd;
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            Lighting.LightingState[] jagged = swipeData.jaggedArray[index1];
            float num4 = 0.0f;
            for (int index2 = num2; index2 != num3; index2 += num1)
            {
              Lighting.LightingState lightingState = jagged[index2];
              if ((double) lightingState.r2 > (double) num4)
                num4 = lightingState.r2;
              else if ((double) num4 > 0.0185)
              {
                if ((double) lightingState.r2 < (double) num4)
                  lightingState.r2 = num4;
              }
              else
                continue;
              if ((double) jagged[index2 + num1].r2 <= (double) num4)
              {
                if (lightingState.stopLight)
                  num4 *= Lighting.negLight2;
                else if (lightingState.wetLight)
                {
                  if (lightingState.honeyLight)
                    num4 *= (float) ((double) Lighting.honeyLightR * (double) swipeData.rand.Next(98, 100) * 0.00999999977648258);
                  else
                    num4 *= (float) ((double) Lighting.wetLightR * (double) swipeData.rand.Next(98, 100) * 0.00999999977648258);
                }
                else
                  num4 *= Lighting.negLight;
              }
            }
          }
          if (flag)
            flag = false;
          else
            break;
        }
      }
      catch
      {
      }
    }

    private static void doColors_Mode2_Swipe(Lighting.LightingSwipeData swipeData)
    {
      try
      {
        bool flag = true;
        while (true)
        {
          int num1;
          int num2;
          int num3;
          if (flag)
          {
            num1 = 1;
            num2 = swipeData.innerLoop1Start;
            num3 = swipeData.innerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = swipeData.innerLoop2Start;
            num3 = swipeData.innerLoop2End;
          }
          int outerLoopStart = swipeData.outerLoopStart;
          int outerLoopEnd = swipeData.outerLoopEnd;
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            Lighting.LightingState[] jagged = swipeData.jaggedArray[index1];
            float num4 = 0.0f;
            for (int index2 = num2; index2 != num3; index2 += num1)
            {
              Lighting.LightingState lightingState = jagged[index2];
              if ((double) lightingState.r2 > (double) num4)
                num4 = lightingState.r2;
              else if ((double) num4 > 0.0)
                lightingState.r2 = num4;
              else
                continue;
              if (lightingState.stopLight)
                num4 -= Lighting.negLight2;
              else if (lightingState.wetLight)
                num4 -= Lighting.wetLightR;
              else
                num4 -= Lighting.negLight;
            }
          }
          if (flag)
            flag = false;
          else
            break;
        }
      }
      catch
      {
      }
    }

    private static void doColors_Mode3_Swipe(Lighting.LightingSwipeData swipeData)
    {
      try
      {
        bool flag1 = true;
        while (true)
        {
          int num1;
          int num2;
          int num3;
          if (flag1)
          {
            num1 = 1;
            num2 = swipeData.innerLoop1Start;
            num3 = swipeData.innerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = swipeData.innerLoop2Start;
            num3 = swipeData.innerLoop2End;
          }
          int outerLoopStart = swipeData.outerLoopStart;
          int outerLoopEnd = swipeData.outerLoopEnd;
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            Lighting.LightingState[] jagged = swipeData.jaggedArray[index1];
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            for (int index2 = num2; index2 != num3; index2 += num1)
            {
              Lighting.LightingState lightingState = jagged[index2];
              bool flag2;
              bool flag3 = flag2 = false;
              if ((double) lightingState.r2 > (double) num4)
                num4 = lightingState.r2;
              else if ((double) num4 <= 0.0)
                flag3 = true;
              else
                lightingState.r2 = num4;
              if (!flag3)
              {
                if (lightingState.stopLight)
                  num4 -= Lighting.negLight2;
                else if (lightingState.wetLight)
                  num4 -= Lighting.wetLightR;
                else
                  num4 -= Lighting.negLight;
              }
              if ((double) lightingState.g2 > (double) num5)
                num5 = lightingState.g2;
              else if ((double) num5 <= 0.0)
                flag2 = true;
              else
                lightingState.g2 = num5;
              if (!flag2)
              {
                if (lightingState.stopLight)
                  num5 -= Lighting.negLight2;
                else if (lightingState.wetLight)
                  num5 -= Lighting.wetLightG;
                else
                  num5 -= Lighting.negLight;
              }
              if ((double) lightingState.b2 > (double) num6)
                num6 = lightingState.b2;
              else if ((double) num6 > 0.0)
                lightingState.b2 = num6;
              else
                continue;
              if (lightingState.stopLight)
                num6 -= Lighting.negLight2;
              else
                num6 -= Lighting.negLight;
            }
          }
          if (flag1)
            flag1 = false;
          else
            break;
        }
      }
      catch
      {
      }
    }

    public static void AddLight(Vector2 position, Vector3 rgb) => Lighting.AddLight((int) ((double) position.X / 16.0), (int) ((double) position.Y / 16.0), rgb.X, rgb.Y, rgb.Z);

    public static void AddLight(Vector2 position, float R, float G, float B) => Lighting.AddLight((int) ((double) position.X / 16.0), (int) ((double) position.Y / 16.0), R, G, B);

    public static void AddLight(int i, int j, float R, float G, float B)
    {
      if (Main.gamePaused || Main.netMode == 2 || i - Lighting.firstTileX + Lighting.offScreenTiles < 0 || i - Lighting.firstTileX + Lighting.offScreenTiles >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || j - Lighting.firstTileY + Lighting.offScreenTiles < 0 || j - Lighting.firstTileY + Lighting.offScreenTiles >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 || Lighting.tempLights.Count == Lighting.maxTempLights)
        return;
      Point16 key = new Point16(i, j);
      Lighting.ColorTriplet colorTriplet;
      if (Lighting.tempLights.TryGetValue(key, out colorTriplet))
      {
        if (Lighting.RGB)
        {
          if ((double) colorTriplet.r < (double) R)
            colorTriplet.r = R;
          if ((double) colorTriplet.g < (double) G)
            colorTriplet.g = G;
          if ((double) colorTriplet.b < (double) B)
            colorTriplet.b = B;
          Lighting.tempLights[key] = colorTriplet;
        }
        else
        {
          float averageColor = (float) (((double) R + (double) G + (double) B) / 3.0);
          if ((double) colorTriplet.r >= (double) averageColor)
            return;
          Lighting.tempLights[key] = new Lighting.ColorTriplet(averageColor);
        }
      }
      else
      {
        colorTriplet = !Lighting.RGB ? new Lighting.ColorTriplet((float) (((double) R + (double) G + (double) B) / 3.0)) : new Lighting.ColorTriplet(R, G, B);
        Lighting.tempLights.Add(key, colorTriplet);
      }
    }

    public static void NextLightMode()
    {
      Lighting.lightCounter += 100;
      ++Lighting.lightMode;
      if (Lighting.lightMode >= 4)
        Lighting.lightMode = 0;
      if (Lighting.lightMode != 2 && Lighting.lightMode != 0)
        return;
      Main.renderCount = 0;
      Main.renderNow = true;
      Lighting.BlackOut();
    }

    public static void BlackOut()
    {
      int num1 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
      int num2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        Lighting.LightingState[] state = Lighting.states[index1];
        for (int index2 = 0; index2 < num2; ++index2)
        {
          Lighting.LightingState lightingState = state[index2];
          lightingState.r = 0.0f;
          lightingState.g = 0.0f;
          lightingState.b = 0.0f;
        }
      }
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
      Lighting.LightingState lightingState = Lighting.states[index1][index2];
      int num1 = (int) ((double) oldColor.R * (double) lightingState.r * (double) Lighting.brightness);
      int num2 = (int) ((double) oldColor.G * (double) lightingState.g * (double) Lighting.brightness);
      int num3 = (int) ((double) oldColor.B * (double) lightingState.b * (double) Lighting.brightness);
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
      if (Main.gameMenu)
        return Color.White;
      if (index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2)
        return Color.Black;
      Lighting.LightingState lightingState = Lighting.states[index1][index2];
      int num1 = (int) ((double) byte.MaxValue * (double) lightingState.r * (double) Lighting.brightness);
      int num2 = (int) ((double) byte.MaxValue * (double) lightingState.g * (double) Lighting.brightness);
      int num3 = (int) ((double) byte.MaxValue * (double) lightingState.b * (double) Lighting.brightness);
      if (num1 > (int) byte.MaxValue)
        num1 = (int) byte.MaxValue;
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      return new Color((int) (byte) num1, (int) (byte) num2, (int) (byte) num3, (int) byte.MaxValue);
    }

    public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
    {
      int num1 = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
      int num2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
      if (num1 <= 0 || num2 <= 0 || num1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
      {
        for (int index = 0; index < 9; ++index)
          slices[index] = Color.Black;
      }
      else
      {
        int index1 = 0;
        for (int index2 = num1 - 1; index2 <= num1 + 1; ++index2)
        {
          Lighting.LightingState[] state = Lighting.states[index2];
          for (int index3 = num2 - 1; index3 <= num2 + 1; ++index3)
          {
            Lighting.LightingState lightingState = state[index3];
            int num3 = (int) ((double) byte.MaxValue * (double) lightingState.r * (double) Lighting.brightness);
            int num4 = (int) ((double) byte.MaxValue * (double) lightingState.g * (double) Lighting.brightness);
            int num5 = (int) ((double) byte.MaxValue * (double) lightingState.b * (double) Lighting.brightness);
            if (num3 > (int) byte.MaxValue)
              num3 = (int) byte.MaxValue;
            if (num4 > (int) byte.MaxValue)
              num4 = (int) byte.MaxValue;
            if (num5 > (int) byte.MaxValue)
              num5 = (int) byte.MaxValue;
            slices[index1] = new Color((int) (byte) num3, (int) (byte) num4, (int) (byte) num5, (int) byte.MaxValue);
            index1 += 3;
          }
          index1 -= 8;
        }
      }
    }

    public static Vector3 GetSubLight(Vector2 position)
    {
      Vector2 vector2_1 = position / 16f - new Vector2(0.5f, 0.5f);
      Vector2 vector2_2 = new Vector2(vector2_1.X % 1f, vector2_1.Y % 1f);
      int index1 = (int) vector2_1.X - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = (int) vector2_1.Y - Lighting.firstTileY + Lighting.offScreenTiles;
      if (index1 <= 0 || index2 <= 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
        return Vector3.One;
      Vector3 vector3_1 = Lighting.states[index1][index2].ToVector3();
      Vector3 vector3_2 = Lighting.states[index1 + 1][index2].ToVector3();
      Vector3 vector3_3 = Lighting.states[index1][index2 + 1].ToVector3();
      Vector3 vector3_4 = Lighting.states[index1 + 1][index2 + 1].ToVector3();
      Vector3 vector3_5 = vector3_2;
      double x = (double) vector2_2.X;
      return Vector3.Lerp(Vector3.Lerp(vector3_1, vector3_5, (float) x), Vector3.Lerp(vector3_3, vector3_4, vector2_2.X), vector2_2.Y);
    }

    public static void GetColor4Slice_New(
      int centerX,
      int centerY,
      out VertexColors vertices,
      float scale = 1f)
    {
      int index1 = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
      if (index1 <= 0 || index2 <= 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
      {
        vertices.BottomLeftColor = Color.Black;
        vertices.BottomRightColor = Color.Black;
        vertices.TopLeftColor = Color.Black;
        vertices.TopRightColor = Color.Black;
      }
      else
      {
        Lighting.LightingState lightingState1 = Lighting.states[index1][index2];
        Lighting.LightingState lightingState2 = Lighting.states[index1][index2 - 1];
        Lighting.LightingState lightingState3 = Lighting.states[index1][index2 + 1];
        Lighting.LightingState lightingState4 = Lighting.states[index1 - 1][index2];
        Lighting.LightingState lightingState5 = Lighting.states[index1 + 1][index2];
        Lighting.LightingState lightingState6 = Lighting.states[index1 - 1][index2 - 1];
        Lighting.LightingState lightingState7 = Lighting.states[index1 + 1][index2 - 1];
        Lighting.LightingState lightingState8 = Lighting.states[index1 - 1][index2 + 1];
        Lighting.LightingState lightingState9 = Lighting.states[index1 + 1][index2 + 1];
        float num1 = (float) ((double) Lighting.brightness * (double) scale * (double) byte.MaxValue * 0.25);
        float num2 = (lightingState2.r + lightingState6.r + lightingState4.r + lightingState1.r) * num1;
        float num3 = (lightingState2.g + lightingState6.g + lightingState4.g + lightingState1.g) * num1;
        float num4 = (lightingState2.b + lightingState6.b + lightingState4.b + lightingState1.b) * num1;
        if ((double) num2 > (double) byte.MaxValue)
          num2 = (float) byte.MaxValue;
        if ((double) num3 > (double) byte.MaxValue)
          num3 = (float) byte.MaxValue;
        if ((double) num4 > (double) byte.MaxValue)
          num4 = (float) byte.MaxValue;
        vertices.TopLeftColor = new Color((int) (byte) num2, (int) (byte) num3, (int) (byte) num4, (int) byte.MaxValue);
        float num5 = (lightingState2.r + lightingState7.r + lightingState5.r + lightingState1.r) * num1;
        float num6 = (lightingState2.g + lightingState7.g + lightingState5.g + lightingState1.g) * num1;
        float num7 = (lightingState2.b + lightingState7.b + lightingState5.b + lightingState1.b) * num1;
        if ((double) num5 > (double) byte.MaxValue)
          num5 = (float) byte.MaxValue;
        if ((double) num6 > (double) byte.MaxValue)
          num6 = (float) byte.MaxValue;
        if ((double) num7 > (double) byte.MaxValue)
          num7 = (float) byte.MaxValue;
        vertices.TopRightColor = new Color((int) (byte) num5, (int) (byte) num6, (int) (byte) num7, (int) byte.MaxValue);
        float num8 = (lightingState3.r + lightingState8.r + lightingState4.r + lightingState1.r) * num1;
        float num9 = (lightingState3.g + lightingState8.g + lightingState4.g + lightingState1.g) * num1;
        float num10 = (lightingState3.b + lightingState8.b + lightingState4.b + lightingState1.b) * num1;
        if ((double) num8 > (double) byte.MaxValue)
          num8 = (float) byte.MaxValue;
        if ((double) num9 > (double) byte.MaxValue)
          num9 = (float) byte.MaxValue;
        if ((double) num10 > (double) byte.MaxValue)
          num10 = (float) byte.MaxValue;
        vertices.BottomLeftColor = new Color((int) (byte) num8, (int) (byte) num9, (int) (byte) num10, (int) byte.MaxValue);
        float num11 = (lightingState3.r + lightingState9.r + lightingState5.r + lightingState1.r) * num1;
        float num12 = (lightingState3.g + lightingState9.g + lightingState5.g + lightingState1.g) * num1;
        float num13 = (lightingState3.b + lightingState9.b + lightingState5.b + lightingState1.b) * num1;
        if ((double) num11 > (double) byte.MaxValue)
          num11 = (float) byte.MaxValue;
        if ((double) num12 > (double) byte.MaxValue)
          num12 = (float) byte.MaxValue;
        if ((double) num13 > (double) byte.MaxValue)
          num13 = (float) byte.MaxValue;
        vertices.BottomRightColor = new Color((int) (byte) num11, (int) (byte) num12, (int) (byte) num13, (int) byte.MaxValue);
      }
    }

    public static void GetColor4Slice_New(
      int centerX,
      int centerY,
      out VertexColors vertices,
      Color centerColor,
      float scale = 1f)
    {
      int index1 = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
      if (index1 <= 0 || index2 <= 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
      {
        vertices.BottomLeftColor = Color.Black;
        vertices.BottomRightColor = Color.Black;
        vertices.TopLeftColor = Color.Black;
        vertices.TopRightColor = Color.Black;
      }
      else
      {
        float num1 = (float) centerColor.R / (float) byte.MaxValue;
        float num2 = (float) centerColor.G / (float) byte.MaxValue;
        float num3 = (float) centerColor.B / (float) byte.MaxValue;
        Lighting.LightingState lightingState1 = Lighting.states[index1][index2 - 1];
        Lighting.LightingState lightingState2 = Lighting.states[index1][index2 + 1];
        Lighting.LightingState lightingState3 = Lighting.states[index1 - 1][index2];
        Lighting.LightingState lightingState4 = Lighting.states[index1 + 1][index2];
        Lighting.LightingState lightingState5 = Lighting.states[index1 - 1][index2 - 1];
        Lighting.LightingState lightingState6 = Lighting.states[index1 + 1][index2 - 1];
        Lighting.LightingState lightingState7 = Lighting.states[index1 - 1][index2 + 1];
        Lighting.LightingState lightingState8 = Lighting.states[index1 + 1][index2 + 1];
        float num4 = (float) ((double) Lighting.brightness * (double) scale * (double) byte.MaxValue * 0.25);
        float num5 = (lightingState1.r + lightingState5.r + lightingState3.r + num1) * num4;
        float num6 = (lightingState1.g + lightingState5.g + lightingState3.g + num2) * num4;
        float num7 = (lightingState1.b + lightingState5.b + lightingState3.b + num3) * num4;
        if ((double) num5 > (double) byte.MaxValue)
          num5 = (float) byte.MaxValue;
        if ((double) num6 > (double) byte.MaxValue)
          num6 = (float) byte.MaxValue;
        if ((double) num7 > (double) byte.MaxValue)
          num7 = (float) byte.MaxValue;
        vertices.TopLeftColor = new Color((int) (byte) num5, (int) (byte) num6, (int) (byte) num7, (int) byte.MaxValue);
        float num8 = (lightingState1.r + lightingState6.r + lightingState4.r + num1) * num4;
        float num9 = (lightingState1.g + lightingState6.g + lightingState4.g + num2) * num4;
        float num10 = (lightingState1.b + lightingState6.b + lightingState4.b + num3) * num4;
        if ((double) num8 > (double) byte.MaxValue)
          num8 = (float) byte.MaxValue;
        if ((double) num9 > (double) byte.MaxValue)
          num9 = (float) byte.MaxValue;
        if ((double) num10 > (double) byte.MaxValue)
          num10 = (float) byte.MaxValue;
        vertices.TopRightColor = new Color((int) (byte) num8, (int) (byte) num9, (int) (byte) num10, (int) byte.MaxValue);
        float num11 = (lightingState2.r + lightingState7.r + lightingState3.r + num1) * num4;
        float num12 = (lightingState2.g + lightingState7.g + lightingState3.g + num2) * num4;
        float num13 = (lightingState2.b + lightingState7.b + lightingState3.b + num3) * num4;
        if ((double) num11 > (double) byte.MaxValue)
          num11 = (float) byte.MaxValue;
        if ((double) num12 > (double) byte.MaxValue)
          num12 = (float) byte.MaxValue;
        if ((double) num13 > (double) byte.MaxValue)
          num13 = (float) byte.MaxValue;
        vertices.BottomLeftColor = new Color((int) (byte) num11, (int) (byte) num12, (int) (byte) num13, (int) byte.MaxValue);
        float num14 = (lightingState2.r + lightingState8.r + lightingState4.r + num1) * num4;
        float num15 = (lightingState2.g + lightingState8.g + lightingState4.g + num2) * num4;
        float num16 = (lightingState2.b + lightingState8.b + lightingState4.b + num3) * num4;
        if ((double) num14 > (double) byte.MaxValue)
          num14 = (float) byte.MaxValue;
        if ((double) num15 > (double) byte.MaxValue)
          num15 = (float) byte.MaxValue;
        if ((double) num16 > (double) byte.MaxValue)
          num16 = (float) byte.MaxValue;
        vertices.BottomRightColor = new Color((int) (byte) num14, (int) (byte) num15, (int) (byte) num16, (int) byte.MaxValue);
      }
    }

    public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
    {
      int index1 = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
      if (index1 <= 0 || index2 <= 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
      {
        for (int index3 = 0; index3 < 4; ++index3)
          slices[index3] = Color.Black;
      }
      else
      {
        Lighting.LightingState lightingState1 = Lighting.states[index1][index2 - 1];
        Lighting.LightingState lightingState2 = Lighting.states[index1][index2 + 1];
        Lighting.LightingState lightingState3 = Lighting.states[index1 - 1][index2];
        Lighting.LightingState lightingState4 = Lighting.states[index1 + 1][index2];
        double num1 = (double) lightingState1.r + (double) lightingState1.g + (double) lightingState1.b;
        float num2 = lightingState2.r + lightingState2.g + lightingState2.b;
        float num3 = lightingState4.r + lightingState4.g + lightingState4.b;
        float num4 = lightingState3.r + lightingState3.g + lightingState3.b;
        if (num1 >= (double) num4)
        {
          int num5 = (int) ((double) byte.MaxValue * (double) lightingState3.r * (double) Lighting.brightness);
          int num6 = (int) ((double) byte.MaxValue * (double) lightingState3.g * (double) Lighting.brightness);
          int num7 = (int) ((double) byte.MaxValue * (double) lightingState3.b * (double) Lighting.brightness);
          if (num5 > (int) byte.MaxValue)
            num5 = (int) byte.MaxValue;
          if (num6 > (int) byte.MaxValue)
            num6 = (int) byte.MaxValue;
          if (num7 > (int) byte.MaxValue)
            num7 = (int) byte.MaxValue;
          slices[0] = new Color((int) (byte) num5, (int) (byte) num6, (int) (byte) num7, (int) byte.MaxValue);
        }
        else
        {
          int num8 = (int) ((double) byte.MaxValue * (double) lightingState1.r * (double) Lighting.brightness);
          int num9 = (int) ((double) byte.MaxValue * (double) lightingState1.g * (double) Lighting.brightness);
          int num10 = (int) ((double) byte.MaxValue * (double) lightingState1.b * (double) Lighting.brightness);
          if (num8 > (int) byte.MaxValue)
            num8 = (int) byte.MaxValue;
          if (num9 > (int) byte.MaxValue)
            num9 = (int) byte.MaxValue;
          if (num10 > (int) byte.MaxValue)
            num10 = (int) byte.MaxValue;
          slices[0] = new Color((int) (byte) num8, (int) (byte) num9, (int) (byte) num10, (int) byte.MaxValue);
        }
        if (num1 >= (double) num3)
        {
          int num11 = (int) ((double) byte.MaxValue * (double) lightingState4.r * (double) Lighting.brightness);
          int num12 = (int) ((double) byte.MaxValue * (double) lightingState4.g * (double) Lighting.brightness);
          int num13 = (int) ((double) byte.MaxValue * (double) lightingState4.b * (double) Lighting.brightness);
          if (num11 > (int) byte.MaxValue)
            num11 = (int) byte.MaxValue;
          if (num12 > (int) byte.MaxValue)
            num12 = (int) byte.MaxValue;
          if (num13 > (int) byte.MaxValue)
            num13 = (int) byte.MaxValue;
          slices[1] = new Color((int) (byte) num11, (int) (byte) num12, (int) (byte) num13, (int) byte.MaxValue);
        }
        else
        {
          int num14 = (int) ((double) byte.MaxValue * (double) lightingState1.r * (double) Lighting.brightness);
          int num15 = (int) ((double) byte.MaxValue * (double) lightingState1.g * (double) Lighting.brightness);
          int num16 = (int) ((double) byte.MaxValue * (double) lightingState1.b * (double) Lighting.brightness);
          if (num14 > (int) byte.MaxValue)
            num14 = (int) byte.MaxValue;
          if (num15 > (int) byte.MaxValue)
            num15 = (int) byte.MaxValue;
          if (num16 > (int) byte.MaxValue)
            num16 = (int) byte.MaxValue;
          slices[1] = new Color((int) (byte) num14, (int) (byte) num15, (int) (byte) num16, (int) byte.MaxValue);
        }
        if ((double) num2 >= (double) num4)
        {
          int num17 = (int) ((double) byte.MaxValue * (double) lightingState3.r * (double) Lighting.brightness);
          int num18 = (int) ((double) byte.MaxValue * (double) lightingState3.g * (double) Lighting.brightness);
          int num19 = (int) ((double) byte.MaxValue * (double) lightingState3.b * (double) Lighting.brightness);
          if (num17 > (int) byte.MaxValue)
            num17 = (int) byte.MaxValue;
          if (num18 > (int) byte.MaxValue)
            num18 = (int) byte.MaxValue;
          if (num19 > (int) byte.MaxValue)
            num19 = (int) byte.MaxValue;
          slices[2] = new Color((int) (byte) num17, (int) (byte) num18, (int) (byte) num19, (int) byte.MaxValue);
        }
        else
        {
          int num20 = (int) ((double) byte.MaxValue * (double) lightingState2.r * (double) Lighting.brightness);
          int num21 = (int) ((double) byte.MaxValue * (double) lightingState2.g * (double) Lighting.brightness);
          int num22 = (int) ((double) byte.MaxValue * (double) lightingState2.b * (double) Lighting.brightness);
          if (num20 > (int) byte.MaxValue)
            num20 = (int) byte.MaxValue;
          if (num21 > (int) byte.MaxValue)
            num21 = (int) byte.MaxValue;
          if (num22 > (int) byte.MaxValue)
            num22 = (int) byte.MaxValue;
          slices[2] = new Color((int) (byte) num20, (int) (byte) num21, (int) (byte) num22, (int) byte.MaxValue);
        }
        if ((double) num2 >= (double) num3)
        {
          int num23 = (int) ((double) byte.MaxValue * (double) lightingState4.r * (double) Lighting.brightness);
          int num24 = (int) ((double) byte.MaxValue * (double) lightingState4.g * (double) Lighting.brightness);
          int num25 = (int) ((double) byte.MaxValue * (double) lightingState4.b * (double) Lighting.brightness);
          if (num23 > (int) byte.MaxValue)
            num23 = (int) byte.MaxValue;
          if (num24 > (int) byte.MaxValue)
            num24 = (int) byte.MaxValue;
          if (num25 > (int) byte.MaxValue)
            num25 = (int) byte.MaxValue;
          slices[3] = new Color((int) (byte) num23, (int) (byte) num24, (int) (byte) num25, (int) byte.MaxValue);
        }
        else
        {
          int num26 = (int) ((double) byte.MaxValue * (double) lightingState2.r * (double) Lighting.brightness);
          int num27 = (int) ((double) byte.MaxValue * (double) lightingState2.g * (double) Lighting.brightness);
          int num28 = (int) ((double) byte.MaxValue * (double) lightingState2.b * (double) Lighting.brightness);
          if (num26 > (int) byte.MaxValue)
            num26 = (int) byte.MaxValue;
          if (num27 > (int) byte.MaxValue)
            num27 = (int) byte.MaxValue;
          if (num28 > (int) byte.MaxValue)
            num28 = (int) byte.MaxValue;
          slices[3] = new Color((int) (byte) num26, (int) (byte) num27, (int) (byte) num28, (int) byte.MaxValue);
        }
      }
    }

    public static Color GetBlackness(int x, int y)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      return index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10 ? Color.Black : new Color(0, 0, 0, (int) (byte) ((double) byte.MaxValue - (double) byte.MaxValue * (double) Lighting.states[index1][index2].r));
    }

    public static float Brightness(int x, int y)
    {
      int index1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int index2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      if (index1 < 0 || index2 < 0 || index1 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || index2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
        return 0.0f;
      Lighting.LightingState lightingState = Lighting.states[index1][index2];
      return (float) ((double) Lighting.brightness * ((double) lightingState.r + (double) lightingState.g + (double) lightingState.b) / 3.0);
    }

    public static float BrightnessAverage(int x, int y, int width, int height)
    {
      int num1 = x - Lighting.firstTileX + Lighting.offScreenTiles;
      int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
      int num3 = num1 + width;
      int num4 = num2 + height;
      if (num1 < 0)
        num1 = 0;
      if (num2 < 0)
        num2 = 0;
      if (num3 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10)
        num3 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
      if (num4 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
        num4 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
      float num5 = 0.0f;
      float num6 = 0.0f;
      for (int index1 = num1; index1 < num3; ++index1)
      {
        for (int index2 = num2; index2 < num4; ++index2)
        {
          ++num5;
          Lighting.LightingState lightingState = Lighting.states[index1][index2];
          num6 += (float) (((double) lightingState.r + (double) lightingState.g + (double) lightingState.b) / 3.0);
        }
      }
      return (double) num5 == 0.0 ? 0.0f : num6 / num5;
    }

    private class LightingSwipeData
    {
      public int outerLoopStart;
      public int outerLoopEnd;
      public int innerLoop1Start;
      public int innerLoop1End;
      public int innerLoop2Start;
      public int innerLoop2End;
      public UnifiedRandom rand;
      public Action<Lighting.LightingSwipeData> function;
      public Lighting.LightingState[][] jaggedArray;

      public LightingSwipeData()
      {
        this.innerLoop1Start = 0;
        this.outerLoopStart = 0;
        this.innerLoop1End = 0;
        this.outerLoopEnd = 0;
        this.innerLoop2Start = 0;
        this.innerLoop2End = 0;
        this.function = (Action<Lighting.LightingSwipeData>) null;
        this.rand = new UnifiedRandom();
      }

      public void CopyFrom(Lighting.LightingSwipeData from)
      {
        this.innerLoop1Start = from.innerLoop1Start;
        this.outerLoopStart = from.outerLoopStart;
        this.innerLoop1End = from.innerLoop1End;
        this.outerLoopEnd = from.outerLoopEnd;
        this.innerLoop2Start = from.innerLoop2Start;
        this.innerLoop2End = from.innerLoop2End;
        this.function = from.function;
        this.jaggedArray = from.jaggedArray;
      }
    }

    private class LightingState
    {
      public float r;
      public float r2;
      public float g;
      public float g2;
      public float b;
      public float b2;
      public bool stopLight;
      public bool wetLight;
      public bool honeyLight;

      public Vector3 ToVector3() => new Vector3(this.r, this.g, this.b);
    }

    private struct ColorTriplet
    {
      public float r;
      public float g;
      public float b;

      public ColorTriplet(float R, float G, float B)
      {
        this.r = R;
        this.g = G;
        this.b = B;
      }

      public ColorTriplet(float averageColor) => this.r = this.g = this.b = averageColor;
    }
  }
}
