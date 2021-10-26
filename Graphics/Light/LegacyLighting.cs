// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Light.LegacyLighting
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria.DataStructures;
using Terraria.Utilities;

namespace Terraria.Graphics.Light
{
  public class LegacyLighting : ILightingEngine
  {
    public static int RenderPhases = 4;
    private bool _rgb = true;
    private int _offScreenTiles2 = 35;
    private float _oldSkyColor;
    private float _skyColor;
    private int _requestedRectLeft;
    private int _requestedRectRight;
    private int _requestedRectTop;
    private int _requestedRectBottom;
    private LegacyLighting.LightingState[][] _states;
    private LegacyLighting.LightingState[][] _axisFlipStates;
    private LegacyLighting.LightingSwipeData _swipe;
    private LegacyLighting.LightingSwipeData[] _threadSwipes;
    private int _scrX;
    private int _scrY;
    private int _minX;
    private int _maxX;
    private int _minY;
    private int _maxY;
    private const int MAX_TEMP_LIGHTS = 2000;
    private Dictionary<Point16, LegacyLighting.ColorTriplet> _tempLights;
    private int _expandedRectLeft;
    private int _expandedRectTop;
    private int _expandedRectRight;
    private int _expandedRectBottom;
    private float _negLight = 0.04f;
    private float _negLight2 = 0.16f;
    private float _wetLightR = 0.16f;
    private float _wetLightG = 0.16f;
    private float _wetLightB = 0.16f;
    private float _honeyLightR = 0.16f;
    private float _honeyLightG = 0.16f;
    private float _honeyLightB = 0.16f;
    private float _blueWave = 1f;
    private int _blueDir = 1;
    private LegacyLighting.RectArea _minBoundArea;
    private LegacyLighting.RectArea _requestedArea;
    private LegacyLighting.RectArea _expandedArea;
    private LegacyLighting.RectArea _offScreenTiles2ExpandedArea;
    private TileLightScanner _tileScanner;
    private readonly Camera _camera;
    private World _world;
    private static FastRandom _swipeRandom = FastRandom.CreateWithRandomSeed();
    private LightMap _lightMap = new LightMap();

    public int Mode { get; set; }

    public bool IsColorOrWhiteMode => this.Mode < 2;

    public LegacyLighting(Camera camera, World world)
    {
      this._camera = camera;
      this._world = world;
      this._tileScanner = new TileLightScanner(world);
    }

    public Vector3 GetColor(int x, int y)
    {
      int index1 = x - this._requestedRectLeft + Lighting.OffScreenTiles;
      int index2 = y - this._requestedRectTop + Lighting.OffScreenTiles;
      Vector2 unscaledSize = this._camera.UnscaledSize;
      if (index1 < 0 || index2 < 0 || (double) index1 >= (double) unscaledSize.X / 16.0 + (double) (Lighting.OffScreenTiles * 2) + 10.0 || (double) index2 >= (double) unscaledSize.Y / 16.0 + (double) (Lighting.OffScreenTiles * 2))
        return Vector3.Zero;
      LegacyLighting.LightingState lightingState = this._states[index1][index2];
      return new Vector3(lightingState.R, lightingState.G, lightingState.B);
    }

    public void Rebuild()
    {
      this._tempLights = new Dictionary<Point16, LegacyLighting.ColorTriplet>();
      this._swipe = new LegacyLighting.LightingSwipeData();
      this._threadSwipes = new LegacyLighting.LightingSwipeData[Environment.ProcessorCount];
      for (int index = 0; index < this._threadSwipes.Length; ++index)
        this._threadSwipes[index] = new LegacyLighting.LightingSwipeData();
      int width = (int) this._camera.UnscaledSize.X / 16 + 90 + 10;
      int height = (int) this._camera.UnscaledSize.Y / 16 + 90 + 10;
      this._lightMap.SetSize(width, height);
      if (this._states != null && this._states.Length >= width && this._states[0].Length >= height)
        return;
      this._states = new LegacyLighting.LightingState[width][];
      this._axisFlipStates = new LegacyLighting.LightingState[height][];
      for (int index = 0; index < height; ++index)
        this._axisFlipStates[index] = new LegacyLighting.LightingState[width];
      for (int index1 = 0; index1 < width; ++index1)
      {
        LegacyLighting.LightingState[] lightingStateArray = new LegacyLighting.LightingState[height];
        for (int index2 = 0; index2 < height; ++index2)
        {
          LegacyLighting.LightingState lightingState = new LegacyLighting.LightingState();
          lightingStateArray[index2] = lightingState;
          this._axisFlipStates[index2][index1] = lightingState;
        }
        this._states[index1] = lightingStateArray;
      }
    }

    public void AddLight(int x, int y, Vector3 color)
    {
      float x1 = color.X;
      float y1 = color.Y;
      float z = color.Z;
      if (x - this._requestedRectLeft + Lighting.OffScreenTiles < 0 || (double) (x - this._requestedRectLeft + Lighting.OffScreenTiles) >= (double) this._camera.UnscaledSize.X / 16.0 + (double) (Lighting.OffScreenTiles * 2) + 10.0 || y - this._requestedRectTop + Lighting.OffScreenTiles < 0 || (double) (y - this._requestedRectTop + Lighting.OffScreenTiles) >= (double) this._camera.UnscaledSize.Y / 16.0 + (double) (Lighting.OffScreenTiles * 2) + 10.0 || this._tempLights.Count == 2000)
        return;
      Point16 key = new Point16(x, y);
      LegacyLighting.ColorTriplet colorTriplet;
      if (this._tempLights.TryGetValue(key, out colorTriplet))
      {
        if (this._rgb)
        {
          if ((double) colorTriplet.R < (double) x1)
            colorTriplet.R = x1;
          if ((double) colorTriplet.G < (double) y1)
            colorTriplet.G = y1;
          if ((double) colorTriplet.B < (double) z)
            colorTriplet.B = z;
          this._tempLights[key] = colorTriplet;
        }
        else
        {
          float averageColor = (float) (((double) x1 + (double) y1 + (double) z) / 3.0);
          if ((double) colorTriplet.R >= (double) averageColor)
            return;
          this._tempLights[key] = new LegacyLighting.ColorTriplet(averageColor);
        }
      }
      else
      {
        colorTriplet = !this._rgb ? new LegacyLighting.ColorTriplet((float) (((double) x1 + (double) y1 + (double) z) / 3.0)) : new LegacyLighting.ColorTriplet(x1, y1, z);
        this._tempLights.Add(key, colorTriplet);
      }
    }

    public void ProcessArea(Rectangle area)
    {
      this._oldSkyColor = this._skyColor;
      float tileR = (float) Main.tileColor.R / (float) byte.MaxValue;
      float tileG = (float) Main.tileColor.G / (float) byte.MaxValue;
      float tileB = (float) Main.tileColor.B / (float) byte.MaxValue;
      this._skyColor = (float) (((double) tileR + (double) tileG + (double) tileB) / 3.0);
      if (this.IsColorOrWhiteMode)
      {
        this._offScreenTiles2 = 34;
        Lighting.OffScreenTiles = 40;
      }
      else
      {
        this._offScreenTiles2 = 18;
        Lighting.OffScreenTiles = 23;
      }
      this._requestedRectLeft = area.Left;
      this._requestedRectRight = area.Right;
      this._requestedRectTop = area.Top;
      this._requestedRectBottom = area.Bottom;
      this._expandedRectLeft = this._requestedRectLeft - Lighting.OffScreenTiles;
      this._expandedRectTop = this._requestedRectTop - Lighting.OffScreenTiles;
      this._expandedRectRight = this._requestedRectRight + Lighting.OffScreenTiles;
      this._expandedRectBottom = this._requestedRectBottom + Lighting.OffScreenTiles;
      ++Main.renderCount;
      int maxLightArrayX = (int) this._camera.UnscaledSize.X / 16 + Lighting.OffScreenTiles * 2;
      int maxLightArrayY = (int) this._camera.UnscaledSize.Y / 16 + Lighting.OffScreenTiles * 2;
      if (Main.renderCount < 3)
        this.DoColors();
      if (Main.renderCount == 2)
        this.CopyFullyProcessedDataOver(maxLightArrayX, maxLightArrayY);
      else if (!Main.renderNow)
      {
        this.ShiftUnProcessedDataOver(maxLightArrayX, maxLightArrayY);
        if (Netplay.Connection.StatusMax > 0)
          Main.mapTime = 1;
        if (Main.mapDelay > 0)
          --Main.mapDelay;
        else if (Main.mapTime == 0 && Main.mapEnabled)
        {
          if (Main.renderCount == 3)
          {
            try
            {
              this.TryUpdatingMapWithLight();
            }
            catch
            {
            }
          }
        }
        if ((double) this._oldSkyColor != (double) this._skyColor)
          this.UpdateLightToSkyColor(tileR, tileG, tileB);
      }
      if (Main.renderCount <= LegacyLighting.RenderPhases)
        return;
      this.PreRenderPhase();
    }

    private void TryUpdatingMapWithLight()
    {
      Main.mapTime = Main.mapTimeMax;
      Main.updateMap = true;
      int blackEdgeWidth = Main.Map.BlackEdgeWidth;
      Vector2 unscaledPosition = this._camera.UnscaledPosition;
      float x = this._camera.UnscaledSize.X;
      float y = this._camera.UnscaledSize.Y;
      float num1 = (float) (int) ((double) x / (double) Main.GameViewMatrix.Zoom.X);
      float num2 = (float) (int) ((double) y / (double) Main.GameViewMatrix.Zoom.Y);
      Vector2 translation = Main.GameViewMatrix.Translation;
      Vector2 vector2 = unscaledPosition + translation;
      int num3 = (int) Math.Floor((double) vector2.X / 16.0);
      int num4 = (int) Math.Floor(((double) vector2.X + (double) num1) / 16.0) + 1;
      int num5 = (int) Math.Floor((double) vector2.Y / 16.0);
      int num6 = (int) Math.Floor(((double) vector2.Y + (double) num2) / 16.0) + 1;
      int min1 = Utils.Clamp<int>(num3, Lighting.OffScreenTiles, Main.maxTilesX - Lighting.OffScreenTiles);
      int max1 = Utils.Clamp<int>(num4, Lighting.OffScreenTiles, Main.maxTilesX - Lighting.OffScreenTiles);
      int min2 = Utils.Clamp<int>(num5, Lighting.OffScreenTiles, Main.maxTilesY - Lighting.OffScreenTiles);
      int max2 = Utils.Clamp<int>(num6, Lighting.OffScreenTiles, Main.maxTilesY - Lighting.OffScreenTiles);
      Main.mapMinX = Utils.Clamp<int>(this._requestedRectLeft, blackEdgeWidth, this._world.TileColumns - blackEdgeWidth);
      Main.mapMaxX = Utils.Clamp<int>(this._requestedRectRight, blackEdgeWidth, this._world.TileColumns - blackEdgeWidth);
      Main.mapMinY = Utils.Clamp<int>(this._requestedRectTop, blackEdgeWidth, this._world.TileRows - blackEdgeWidth);
      Main.mapMaxY = Utils.Clamp<int>(this._requestedRectBottom, blackEdgeWidth, this._world.TileRows - blackEdgeWidth);
      Main.mapMinX = Utils.Clamp<int>(Main.mapMinX, min1, max1);
      Main.mapMaxX = Utils.Clamp<int>(Main.mapMaxX, min1, max1);
      Main.mapMinY = Utils.Clamp<int>(Main.mapMinY, min2, max2);
      Main.mapMaxY = Utils.Clamp<int>(Main.mapMaxY, min2, max2);
      int offScreenTiles = Lighting.OffScreenTiles;
      for (int mapMinX = Main.mapMinX; mapMinX < Main.mapMaxX; ++mapMinX)
      {
        LegacyLighting.LightingState[] state = this._states[mapMinX - this._requestedRectLeft + offScreenTiles];
        for (int mapMinY = Main.mapMinY; mapMinY < Main.mapMaxY; ++mapMinY)
        {
          LegacyLighting.LightingState lightingState = state[mapMinY - this._requestedRectTop + offScreenTiles];
          Tile tile = Main.tile[mapMinX, mapMinY];
          float num7 = 0.0f;
          if ((double) lightingState.R > (double) num7)
            num7 = lightingState.R;
          if ((double) lightingState.G > (double) num7)
            num7 = lightingState.G;
          if ((double) lightingState.B > (double) num7)
            num7 = lightingState.B;
          if (this.IsColorOrWhiteMode)
            num7 *= 1.5f;
          byte light = (byte) Math.Min((float) byte.MaxValue, num7 * (float) byte.MaxValue);
          if ((double) mapMinY < Main.worldSurface && !tile.active() && tile.wall == (ushort) 0 && tile.liquid == (byte) 0)
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

    private void UpdateLightToSkyColor(float tileR, float tileG, float tileB)
    {
      int num1 = Utils.Clamp<int>(this._expandedRectLeft, 0, this._world.TileColumns - 1);
      int num2 = Utils.Clamp<int>(this._expandedRectRight, 0, this._world.TileColumns - 1);
      int num3 = Utils.Clamp<int>(this._expandedRectTop, 0, this._world.TileRows - 1);
      int num4 = Utils.Clamp<int>(this._expandedRectBottom, 0, (int) Main.worldSurface - 1);
      if ((double) num3 >= Main.worldSurface)
        return;
      for (int index1 = num1; index1 < num2; ++index1)
      {
        LegacyLighting.LightingState[] state = this._states[index1 - this._expandedRectLeft];
        for (int index2 = num3; index2 < num4; ++index2)
        {
          LegacyLighting.LightingState lightingState = state[index2 - this._expandedRectTop];
          Tile tile = Main.tile[index1, index2];
          if (tile == null)
          {
            tile = new Tile();
            Main.tile[index1, index2] = tile;
          }
          if ((!tile.active() || !Main.tileNoSunLight[(int) tile.type]) && (double) lightingState.R < (double) this._skyColor && tile.liquid < (byte) 200 && (Main.wallLight[(int) tile.wall] || tile.wall == (ushort) 73))
          {
            lightingState.R = tileR;
            if ((double) lightingState.G < (double) this._skyColor)
              lightingState.G = tileG;
            if ((double) lightingState.B < (double) this._skyColor)
              lightingState.B = tileB;
          }
        }
      }
    }

    private void ShiftUnProcessedDataOver(int maxLightArrayX, int maxLightArrayY)
    {
      Vector2 screenLastPosition = Main.screenLastPosition;
      Vector2 unscaledPosition = this._camera.UnscaledPosition;
      int num1 = (int) Math.Floor((double) unscaledPosition.X / 16.0) - (int) Math.Floor((double) screenLastPosition.X / 16.0);
      if (num1 > 5 || num1 < -5)
        num1 = 0;
      int num2;
      int num3;
      int num4;
      if (num1 < 0)
      {
        num2 = -1;
        num1 *= -1;
        num3 = maxLightArrayX;
        num4 = num1;
      }
      else
      {
        num2 = 1;
        num3 = 0;
        num4 = maxLightArrayX - num1;
      }
      int num5 = (int) Math.Floor((double) unscaledPosition.Y / 16.0) - (int) Math.Floor((double) screenLastPosition.Y / 16.0);
      if (num5 > 5 || num5 < -5)
        num5 = 0;
      int num6;
      int num7;
      int num8;
      if (num5 < 0)
      {
        num6 = -1;
        num5 *= -1;
        num7 = maxLightArrayY;
        num8 = num5;
      }
      else
      {
        num6 = 1;
        num7 = 0;
        num8 = maxLightArrayY - num5;
      }
      if (num1 == 0 && num5 == 0)
        return;
      for (int index1 = num3; index1 != num4; index1 += num2)
      {
        LegacyLighting.LightingState[] state1 = this._states[index1];
        LegacyLighting.LightingState[] state2 = this._states[index1 + num1 * num2];
        for (int index2 = num7; index2 != num8; index2 += num6)
        {
          LegacyLighting.LightingState lightingState1 = state1[index2];
          LegacyLighting.LightingState lightingState2 = state2[index2 + num5 * num6];
          lightingState1.R = lightingState2.R;
          lightingState1.G = lightingState2.G;
          lightingState1.B = lightingState2.B;
        }
      }
    }

    private void CopyFullyProcessedDataOver(int maxLightArrayX, int maxLightArrayY)
    {
      Vector2 unscaledPosition = this._camera.UnscaledPosition;
      int num1 = (int) Math.Floor((double) unscaledPosition.X / 16.0) - this._scrX;
      int num2 = (int) Math.Floor((double) unscaledPosition.Y / 16.0) - this._scrY;
      if (num1 > 16)
        num1 = 0;
      if (num2 > 16)
        num2 = 0;
      int num3 = 0;
      int num4 = maxLightArrayX;
      int num5 = 0;
      int num6 = maxLightArrayY;
      if (num1 < 0)
        num3 -= num1;
      else
        num4 -= num1;
      if (num2 < 0)
        num5 -= num2;
      else
        num6 -= num2;
      if (this._rgb)
      {
        int num7 = maxLightArrayX;
        if (this._states.Length <= num7 + num1)
          num7 = this._states.Length - num1 - 1;
        for (int index1 = num3; index1 < num7; ++index1)
        {
          LegacyLighting.LightingState[] state1 = this._states[index1];
          LegacyLighting.LightingState[] state2 = this._states[index1 + num1];
          int num8 = num6;
          if (state2.Length <= num8 + num1)
            num8 = state2.Length - num2 - 1;
          for (int index2 = num5; index2 < num8; ++index2)
          {
            LegacyLighting.LightingState lightingState1 = state1[index2];
            LegacyLighting.LightingState lightingState2 = state2[index2 + num2];
            lightingState1.R = lightingState2.R2;
            lightingState1.G = lightingState2.G2;
            lightingState1.B = lightingState2.B2;
          }
        }
      }
      else
      {
        int num9 = num4;
        if (this._states.Length <= num9 + num1)
          num9 = this._states.Length - num1 - 1;
        for (int index3 = num3; index3 < num9; ++index3)
        {
          LegacyLighting.LightingState[] state3 = this._states[index3];
          LegacyLighting.LightingState[] state4 = this._states[index3 + num1];
          int num10 = num6;
          if (state4.Length <= num10 + num1)
            num10 = state4.Length - num2 - 1;
          for (int index4 = num5; index4 < num10; ++index4)
          {
            LegacyLighting.LightingState lightingState3 = state3[index4];
            LegacyLighting.LightingState lightingState4 = state4[index4 + num2];
            lightingState3.R = lightingState4.R2;
            lightingState3.G = lightingState4.R2;
            lightingState3.B = lightingState4.R2;
          }
        }
      }
    }

    public void Clear()
    {
      int num1 = (int) this._camera.UnscaledSize.X / 16 + Lighting.OffScreenTiles * 2;
      int num2 = (int) this._camera.UnscaledSize.Y / 16 + Lighting.OffScreenTiles * 2;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        if (index1 < this._states.Length)
        {
          LegacyLighting.LightingState[] state = this._states[index1];
          for (int index2 = 0; index2 < num2; ++index2)
          {
            if (index2 < state.Length)
            {
              LegacyLighting.LightingState lightingState = state[index2];
              lightingState.R = 0.0f;
              lightingState.G = 0.0f;
              lightingState.B = 0.0f;
            }
          }
        }
      }
    }

    private void PreRenderPhase()
    {
      double num1 = (double) Main.tileColor.R / (double) byte.MaxValue;
      double num2 = (double) Main.tileColor.G / (double) byte.MaxValue;
      double num3 = (double) Main.tileColor.B / (double) byte.MaxValue;
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num4 = 0;
      int num5 = (int) this._camera.UnscaledSize.X / 16 + Lighting.OffScreenTiles * 2 + 10;
      int num6 = 0;
      int num7 = (int) this._camera.UnscaledSize.Y / 16 + Lighting.OffScreenTiles * 2 + 10;
      this._minX = num5;
      this._maxX = num4;
      this._minY = num7;
      this._maxY = num6;
      this._rgb = this.Mode == 0 || this.Mode == 3;
      for (int index1 = num4; index1 < num5; ++index1)
      {
        LegacyLighting.LightingState[] state = this._states[index1];
        for (int index2 = num6; index2 < num7; ++index2)
        {
          LegacyLighting.LightingState lightingState = state[index2];
          lightingState.R2 = 0.0f;
          lightingState.G2 = 0.0f;
          lightingState.B2 = 0.0f;
          lightingState.StopLight = false;
          lightingState.WetLight = false;
          lightingState.HoneyLight = false;
        }
      }
      if (Main.wofNPCIndex >= 0)
      {
        if (Main.player[Main.myPlayer].gross)
        {
          try
          {
            int num8 = (int) this._camera.UnscaledPosition.Y / 16 - 10;
            int num9 = (int) ((double) this._camera.UnscaledPosition.Y + (double) this._camera.UnscaledSize.Y) / 16 + 10;
            int num10 = (int) Main.npc[Main.wofNPCIndex].position.X / 16;
            int num11 = Main.npc[Main.wofNPCIndex].direction <= 0 ? num10 + 2 : num10 - 3;
            int num12 = num11 + 8;
            float num13 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
            float num14 = 0.3f;
            float num15 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
            float num16 = num13 * 0.2f;
            float num17 = num14 * 0.1f;
            float num18 = num15 * 0.3f;
            for (int index3 = num11; index3 <= num12; ++index3)
            {
              LegacyLighting.LightingState[] state = this._states[index3 - num11];
              for (int index4 = num8; index4 <= num9; ++index4)
              {
                LegacyLighting.LightingState lightingState = state[index4 - this._expandedRectTop];
                if ((double) lightingState.R2 < (double) num16)
                  lightingState.R2 = num16;
                if ((double) lightingState.G2 < (double) num17)
                  lightingState.G2 = num17;
                if ((double) lightingState.B2 < (double) num18)
                  lightingState.B2 = num18;
              }
            }
          }
          catch
          {
          }
        }
      }
      int x = Utils.Clamp<int>(this._expandedRectLeft, 5, this._world.TileColumns - 1);
      int num19 = Utils.Clamp<int>(this._expandedRectRight, 5, this._world.TileColumns - 1);
      int y = Utils.Clamp<int>(this._expandedRectTop, 5, this._world.TileRows - 1);
      int num20 = Utils.Clamp<int>(this._expandedRectBottom, 5, this._world.TileRows - 1);
      Main.SceneMetrics.ScanAndExportToMain(new SceneMetricsScanSettings()
      {
        VisualScanArea = new Rectangle?(new Rectangle(x, y, num19 - x, num20 - y)),
        BiomeScanCenterPositionInWorld = new Vector2?(Main.LocalPlayer.Center),
        ScanOreFinderData = Main.LocalPlayer.accOreFinder
      });
      this._tileScanner.Update();
      this._tileScanner.ExportTo(new Rectangle(x, y, num19 - x, num20 - y), this._lightMap);
      for (int index5 = x; index5 < num19; ++index5)
      {
        LegacyLighting.LightingState[] state = this._states[index5 - this._expandedRectLeft];
        for (int index6 = y; index6 < num20; ++index6)
        {
          LegacyLighting.LightingState lightingState = state[index6 - this._expandedRectTop];
          if (Main.tile[index5, index6] == null)
          {
            Tile tile = new Tile();
            Main.tile[index5, index6] = tile;
          }
          Vector3 color;
          this._lightMap.GetLight(index5 - x, index6 - y, out color);
          if (this._rgb)
          {
            lightingState.R2 = color.X;
            lightingState.G2 = color.Y;
            lightingState.B2 = color.Z;
          }
          else
          {
            float num21 = (float) (((double) color.X + (double) color.Y + (double) color.Z) / 3.0);
            lightingState.R2 = num21;
            lightingState.G2 = num21;
            lightingState.B2 = num21;
          }
          switch (this._lightMap.GetMask(index5 - x, index6 - y))
          {
            case LightMaskMode.Solid:
              lightingState.StopLight = true;
              break;
            case LightMaskMode.Water:
              lightingState.WetLight = true;
              break;
            case LightMaskMode.Honey:
              lightingState.WetLight = true;
              lightingState.HoneyLight = true;
              break;
          }
          if ((double) lightingState.R2 > 0.0 || this._rgb && ((double) lightingState.G2 > 0.0 || (double) lightingState.B2 > 0.0))
          {
            int num22 = index5 - this._expandedRectLeft;
            int num23 = index6 - this._expandedRectTop;
            if (this._minX > num22)
              this._minX = num22;
            if (this._maxX < num22 + 1)
              this._maxX = num22 + 1;
            if (this._minY > num23)
              this._minY = num23;
            if (this._maxY < num23 + 1)
              this._maxY = num23 + 1;
          }
        }
      }
      foreach (KeyValuePair<Point16, LegacyLighting.ColorTriplet> tempLight in this._tempLights)
      {
        int index7 = (int) tempLight.Key.X - this._requestedRectLeft + Lighting.OffScreenTiles;
        int index8 = (int) tempLight.Key.Y - this._requestedRectTop + Lighting.OffScreenTiles;
        if (index7 >= 0 && (double) index7 < (double) this._camera.UnscaledSize.X / 16.0 + (double) (Lighting.OffScreenTiles * 2) + 10.0 && index8 >= 0 && (double) index8 < (double) this._camera.UnscaledSize.Y / 16.0 + (double) (Lighting.OffScreenTiles * 2) + 10.0)
        {
          LegacyLighting.LightingState lightingState = this._states[index7][index8];
          if ((double) lightingState.R2 < (double) tempLight.Value.R)
            lightingState.R2 = tempLight.Value.R;
          if ((double) lightingState.G2 < (double) tempLight.Value.G)
            lightingState.G2 = tempLight.Value.G;
          if ((double) lightingState.B2 < (double) tempLight.Value.B)
            lightingState.B2 = tempLight.Value.B;
          if (this._minX > index7)
            this._minX = index7;
          if (this._maxX < index7 + 1)
            this._maxX = index7 + 1;
          if (this._minY > index8)
            this._minY = index8;
          if (this._maxY < index8 + 1)
            this._maxY = index8 + 1;
        }
      }
      if (!Main.gamePaused)
        this._tempLights.Clear();
      this._minX += this._expandedRectLeft;
      this._maxX += this._expandedRectLeft;
      this._minY += this._expandedRectTop;
      this._maxY += this._expandedRectTop;
      this._minBoundArea.Set(this._minX, this._maxX, this._minY, this._maxY);
      this._requestedArea.Set(this._requestedRectLeft, this._requestedRectRight, this._requestedRectTop, this._requestedRectBottom);
      this._expandedArea.Set(this._expandedRectLeft, this._expandedRectRight, this._expandedRectTop, this._expandedRectBottom);
      this._offScreenTiles2ExpandedArea.Set(this._requestedRectLeft - this._offScreenTiles2, this._requestedRectRight + this._offScreenTiles2, this._requestedRectTop - this._offScreenTiles2, this._requestedRectBottom + this._offScreenTiles2);
      this._scrX = (int) Math.Floor((double) this._camera.UnscaledPosition.X / 16.0);
      this._scrY = (int) Math.Floor((double) this._camera.UnscaledPosition.Y / 16.0);
      Main.renderCount = 0;
      TimeLogger.LightingTime(0, stopwatch.Elapsed.TotalMilliseconds);
      this.DoColors();
    }

    private void DoColors()
    {
      if (this.IsColorOrWhiteMode)
      {
        this._blueWave += (float) this._blueDir * 0.0001f;
        if ((double) this._blueWave > 1.0)
        {
          this._blueWave = 1f;
          this._blueDir = -1;
        }
        else if ((double) this._blueWave < 0.970000028610229)
        {
          this._blueWave = 0.97f;
          this._blueDir = 1;
        }
        if (this._rgb)
        {
          this._negLight = 0.91f;
          this._negLight2 = 0.56f;
          this._honeyLightG = 0.7f * this._negLight * this._blueWave;
          this._honeyLightR = 0.75f * this._negLight * this._blueWave;
          this._honeyLightB = 0.6f * this._negLight * this._blueWave;
          switch (Main.waterStyle)
          {
            case 0:
            case 1:
            case 7:
            case 8:
              this._wetLightG = 0.96f * this._negLight * this._blueWave;
              this._wetLightR = 0.88f * this._negLight * this._blueWave;
              this._wetLightB = 1.015f * this._negLight * this._blueWave;
              break;
            case 2:
              this._wetLightG = 0.85f * this._negLight * this._blueWave;
              this._wetLightR = 0.94f * this._negLight * this._blueWave;
              this._wetLightB = 1.01f * this._negLight * this._blueWave;
              break;
            case 3:
              this._wetLightG = 0.95f * this._negLight * this._blueWave;
              this._wetLightR = 0.84f * this._negLight * this._blueWave;
              this._wetLightB = 1.015f * this._negLight * this._blueWave;
              break;
            case 4:
              this._wetLightG = 0.86f * this._negLight * this._blueWave;
              this._wetLightR = 0.9f * this._negLight * this._blueWave;
              this._wetLightB = 1.01f * this._negLight * this._blueWave;
              break;
            case 5:
              this._wetLightG = 0.99f * this._negLight * this._blueWave;
              this._wetLightR = 0.84f * this._negLight * this._blueWave;
              this._wetLightB = 1.01f * this._negLight * this._blueWave;
              break;
            case 6:
              this._wetLightR = 0.83f * this._negLight * this._blueWave;
              this._wetLightG = 0.93f * this._negLight * this._blueWave;
              this._wetLightB = 0.98f * this._negLight * this._blueWave;
              break;
            case 9:
              this._wetLightG = 0.88f * this._negLight * this._blueWave;
              this._wetLightR = 1f * this._negLight * this._blueWave;
              this._wetLightB = 0.84f * this._negLight * this._blueWave;
              break;
            case 10:
              this._wetLightG = 1f * this._negLight * this._blueWave;
              this._wetLightR = 0.83f * this._negLight * this._blueWave;
              this._wetLightB = 1f * this._negLight * this._blueWave;
              break;
            case 12:
              this._wetLightG = 0.98f * this._negLight * this._blueWave;
              this._wetLightR = 0.95f * this._negLight * this._blueWave;
              this._wetLightB = 0.85f * this._negLight * this._blueWave;
              break;
            default:
              this._wetLightG = 0.0f;
              this._wetLightR = 0.0f;
              this._wetLightB = 0.0f;
              break;
          }
        }
        else
        {
          this._negLight = 0.9f;
          this._negLight2 = 0.54f;
          this._wetLightR = 0.95f * this._negLight * this._blueWave;
        }
        if (Main.player[Main.myPlayer].nightVision)
        {
          this._negLight *= 1.03f;
          this._negLight2 *= 1.03f;
        }
        if (Main.player[Main.myPlayer].blind)
        {
          this._negLight *= 0.95f;
          this._negLight2 *= 0.95f;
        }
        if (Main.player[Main.myPlayer].blackout)
        {
          this._negLight *= 0.85f;
          this._negLight2 *= 0.85f;
        }
        if (Main.player[Main.myPlayer].headcovered)
        {
          this._negLight *= 0.85f;
          this._negLight2 *= 0.85f;
        }
      }
      else
      {
        this._negLight = 0.04f;
        this._negLight2 = 0.16f;
        if (Main.player[Main.myPlayer].nightVision)
        {
          this._negLight -= 0.013f;
          this._negLight2 -= 0.04f;
        }
        if (Main.player[Main.myPlayer].blind)
        {
          this._negLight += 0.03f;
          this._negLight2 += 0.06f;
        }
        if (Main.player[Main.myPlayer].blackout)
        {
          this._negLight += 0.09f;
          this._negLight2 += 0.18f;
        }
        if (Main.player[Main.myPlayer].headcovered)
        {
          this._negLight += 0.09f;
          this._negLight2 += 0.18f;
        }
        this._wetLightR = this._negLight * 1.2f;
        this._wetLightG = this._negLight * 1.1f;
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
      Stopwatch stopwatch = new Stopwatch();
      int left = this._expandedArea.Left;
      int top = this._expandedArea.Top;
      for (int index = num1; index < num2; ++index)
      {
        stopwatch.Restart();
        int num3 = 0;
        int num4 = 0;
        switch (index)
        {
          case 0:
            this._swipe.InnerLoop1Start = this._minBoundArea.Top - top;
            this._swipe.InnerLoop2Start = this._minBoundArea.Bottom - top;
            this._swipe.InnerLoop1End = this._requestedArea.Bottom + LegacyLighting.RenderPhases - top;
            this._swipe.InnerLoop2End = this._requestedArea.Top - LegacyLighting.RenderPhases - top;
            num3 = this._minBoundArea.Left - left;
            num4 = this._minBoundArea.Right - left;
            this._swipe.JaggedArray = this._states;
            break;
          case 1:
            this._swipe.InnerLoop1Start = this._minBoundArea.Left - left;
            this._swipe.InnerLoop2Start = this._minBoundArea.Right - left;
            this._swipe.InnerLoop1End = this._requestedArea.Right + LegacyLighting.RenderPhases - left;
            this._swipe.InnerLoop2End = this._requestedArea.Left - LegacyLighting.RenderPhases - left;
            num3 = this._minBoundArea.Top - top;
            num4 = this._minBoundArea.Bottom - top;
            this._swipe.JaggedArray = this._axisFlipStates;
            break;
          case 2:
            this._swipe.InnerLoop1Start = this._offScreenTiles2ExpandedArea.Top - top;
            this._swipe.InnerLoop2Start = this._offScreenTiles2ExpandedArea.Bottom - top;
            this._swipe.InnerLoop1End = this._requestedArea.Bottom + LegacyLighting.RenderPhases - top;
            this._swipe.InnerLoop2End = this._requestedArea.Top - LegacyLighting.RenderPhases - top;
            num3 = this._offScreenTiles2ExpandedArea.Left - left;
            num4 = this._offScreenTiles2ExpandedArea.Right - left;
            this._swipe.JaggedArray = this._states;
            break;
          case 3:
            this._swipe.InnerLoop1Start = this._offScreenTiles2ExpandedArea.Left - left;
            this._swipe.InnerLoop2Start = this._offScreenTiles2ExpandedArea.Right - left;
            this._swipe.InnerLoop1End = this._requestedArea.Right + LegacyLighting.RenderPhases - left;
            this._swipe.InnerLoop2End = this._requestedArea.Left - LegacyLighting.RenderPhases - left;
            num3 = this._offScreenTiles2ExpandedArea.Top - top;
            num4 = this._offScreenTiles2ExpandedArea.Bottom - top;
            this._swipe.JaggedArray = this._axisFlipStates;
            break;
        }
        if (this._swipe.InnerLoop1Start > this._swipe.InnerLoop1End)
          this._swipe.InnerLoop1Start = this._swipe.InnerLoop1End;
        if (this._swipe.InnerLoop2Start < this._swipe.InnerLoop2End)
          this._swipe.InnerLoop2Start = this._swipe.InnerLoop2End;
        if (num3 > num4)
          num3 = num4;
        ParallelForAction parallelForAction;
        switch (this.Mode)
        {
          case 0:
            // ISSUE: method pointer
            parallelForAction = new ParallelForAction((object) this, __methodptr(doColors_Mode0_Swipe));
            break;
          case 1:
            // ISSUE: method pointer
            parallelForAction = new ParallelForAction((object) this, __methodptr(doColors_Mode1_Swipe));
            break;
          case 2:
            // ISSUE: method pointer
            parallelForAction = new ParallelForAction((object) this, __methodptr(doColors_Mode2_Swipe));
            break;
          case 3:
            // ISSUE: method pointer
            parallelForAction = new ParallelForAction((object) this, __methodptr(doColors_Mode3_Swipe));
            break;
          default:
            // ISSUE: method pointer
            parallelForAction = new ParallelForAction((object) this, __methodptr(doColors_Mode0_Swipe));
            break;
        }
        FastParallel.For(num3, num4, parallelForAction, (object) this._swipe);
        LegacyLighting._swipeRandom.NextSeed();
        TimeLogger.LightingTime(index + 1, stopwatch.Elapsed.TotalMilliseconds);
      }
    }

    private void doColors_Mode0_Swipe(int outerLoopStart, int outerLoopEnd, object context)
    {
      LegacyLighting.LightingSwipeData lightingSwipeData = context as LegacyLighting.LightingSwipeData;
      FastRandom fastRandom = new FastRandom();
      try
      {
        bool flag1 = true;
        while (true)
        {
          int num1;
          int val2_1;
          int val2_2;
          if (flag1)
          {
            num1 = 1;
            val2_1 = lightingSwipeData.InnerLoop1Start;
            val2_2 = lightingSwipeData.InnerLoop1End;
          }
          else
          {
            num1 = -1;
            val2_1 = lightingSwipeData.InnerLoop2Start;
            val2_2 = lightingSwipeData.InnerLoop2End;
          }
          int num2 = outerLoopStart;
          int num3 = outerLoopEnd;
          for (int index1 = num2; index1 < num3; ++index1)
          {
            LegacyLighting.LightingState[] jagged = lightingSwipeData.JaggedArray[index1];
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            int num7 = Math.Min(jagged.Length - 1, Math.Max(0, val2_1));
            int num8 = Math.Min(jagged.Length - 1, Math.Max(0, val2_2));
            for (int index2 = num7; index2 != num8; index2 += num1)
            {
              LegacyLighting.LightingState lightingState1 = jagged[index2];
              LegacyLighting.LightingState lightingState2 = jagged[index2 + num1];
              bool flag2;
              bool flag3 = flag2 = false;
              if ((double) lightingState1.R2 > (double) num4)
                num4 = lightingState1.R2;
              else if ((double) num4 <= 0.0185)
                flag3 = true;
              else if ((double) lightingState1.R2 < (double) num4)
                lightingState1.R2 = num4;
              if (lightingState1.WetLight)
                fastRandom = LegacyLighting._swipeRandom.WithModifier((ulong) (index1 * 1000 + index2));
              if (!flag3 && (double) lightingState2.R2 <= (double) num4)
              {
                if (lightingState1.StopLight)
                  num4 *= this._negLight2;
                else if (lightingState1.WetLight)
                {
                  if (lightingState1.HoneyLight)
                    num4 *= (float) ((double) this._honeyLightR * (double) fastRandom.Next(98, 100) * 0.00999999977648258);
                  else
                    num4 *= (float) ((double) this._wetLightR * (double) fastRandom.Next(98, 100) * 0.00999999977648258);
                }
                else
                  num4 *= this._negLight;
              }
              if ((double) lightingState1.G2 > (double) num5)
                num5 = lightingState1.G2;
              else if ((double) num5 <= 0.0185)
                flag2 = true;
              else
                lightingState1.G2 = num5;
              if (!flag2 && (double) lightingState2.G2 <= (double) num5)
              {
                if (lightingState1.StopLight)
                  num5 *= this._negLight2;
                else if (lightingState1.WetLight)
                {
                  if (lightingState1.HoneyLight)
                    num5 *= (float) ((double) this._honeyLightG * (double) fastRandom.Next(97, 100) * 0.00999999977648258);
                  else
                    num5 *= (float) ((double) this._wetLightG * (double) fastRandom.Next(97, 100) * 0.00999999977648258);
                }
                else
                  num5 *= this._negLight;
              }
              if ((double) lightingState1.B2 > (double) num6)
                num6 = lightingState1.B2;
              else if ((double) num6 > 0.0185)
                lightingState1.B2 = num6;
              else
                continue;
              if ((double) lightingState2.B2 < (double) num6)
              {
                if (lightingState1.StopLight)
                  num6 *= this._negLight2;
                else if (lightingState1.WetLight)
                {
                  if (lightingState1.HoneyLight)
                    num6 *= (float) ((double) this._honeyLightB * (double) fastRandom.Next(97, 100) * 0.00999999977648258);
                  else
                    num6 *= (float) ((double) this._wetLightB * (double) fastRandom.Next(97, 100) * 0.00999999977648258);
                }
                else
                  num6 *= this._negLight;
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

    private void doColors_Mode1_Swipe(int outerLoopStart, int outerLoopEnd, object context)
    {
      LegacyLighting.LightingSwipeData lightingSwipeData = context as LegacyLighting.LightingSwipeData;
      FastRandom fastRandom1 = new FastRandom();
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
            num2 = lightingSwipeData.InnerLoop1Start;
            num3 = lightingSwipeData.InnerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = lightingSwipeData.InnerLoop2Start;
            num3 = lightingSwipeData.InnerLoop2End;
          }
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            LegacyLighting.LightingState[] jagged = lightingSwipeData.JaggedArray[index1];
            float num4 = 0.0f;
            for (int index2 = num2; index2 != num3; index2 += num1)
            {
              LegacyLighting.LightingState lightingState = jagged[index2];
              if ((double) lightingState.R2 > (double) num4)
                num4 = lightingState.R2;
              else if ((double) num4 > 0.0185)
              {
                if ((double) lightingState.R2 < (double) num4)
                  lightingState.R2 = num4;
              }
              else
                continue;
              if ((double) jagged[index2 + num1].R2 <= (double) num4)
              {
                if (lightingState.StopLight)
                  num4 *= this._negLight2;
                else if (lightingState.WetLight)
                {
                  FastRandom fastRandom2 = LegacyLighting._swipeRandom.WithModifier((ulong) (index1 * 1000 + index2));
                  if (lightingState.HoneyLight)
                    num4 *= (float) ((double) this._honeyLightR * (double) fastRandom2.Next(98, 100) * 0.00999999977648258);
                  else
                    num4 *= (float) ((double) this._wetLightR * (double) fastRandom2.Next(98, 100) * 0.00999999977648258);
                }
                else
                  num4 *= this._negLight;
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

    private void doColors_Mode2_Swipe(int outerLoopStart, int outerLoopEnd, object context)
    {
      LegacyLighting.LightingSwipeData lightingSwipeData = context as LegacyLighting.LightingSwipeData;
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
            num2 = lightingSwipeData.InnerLoop1Start;
            num3 = lightingSwipeData.InnerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = lightingSwipeData.InnerLoop2Start;
            num3 = lightingSwipeData.InnerLoop2End;
          }
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            LegacyLighting.LightingState[] jagged = lightingSwipeData.JaggedArray[index1];
            float num4 = 0.0f;
            for (int index2 = num2; index2 != num3; index2 += num1)
            {
              LegacyLighting.LightingState lightingState = jagged[index2];
              if ((double) lightingState.R2 > (double) num4)
                num4 = lightingState.R2;
              else if ((double) num4 > 0.0)
                lightingState.R2 = num4;
              else
                continue;
              if (lightingState.StopLight)
                num4 -= this._negLight2;
              else if (lightingState.WetLight)
                num4 -= this._wetLightR;
              else
                num4 -= this._negLight;
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

    private void doColors_Mode3_Swipe(int outerLoopStart, int outerLoopEnd, object context)
    {
      LegacyLighting.LightingSwipeData lightingSwipeData = context as LegacyLighting.LightingSwipeData;
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
            num2 = lightingSwipeData.InnerLoop1Start;
            num3 = lightingSwipeData.InnerLoop1End;
          }
          else
          {
            num1 = -1;
            num2 = lightingSwipeData.InnerLoop2Start;
            num3 = lightingSwipeData.InnerLoop2End;
          }
          for (int index1 = outerLoopStart; index1 < outerLoopEnd; ++index1)
          {
            LegacyLighting.LightingState[] jagged = lightingSwipeData.JaggedArray[index1];
            float num4 = 0.0f;
            float num5 = 0.0f;
            float num6 = 0.0f;
            for (int index2 = num2; index2 != num3; index2 += num1)
            {
              LegacyLighting.LightingState lightingState = jagged[index2];
              bool flag2;
              bool flag3 = flag2 = false;
              if ((double) lightingState.R2 > (double) num4)
                num4 = lightingState.R2;
              else if ((double) num4 <= 0.0)
                flag3 = true;
              else
                lightingState.R2 = num4;
              if (!flag3)
              {
                if (lightingState.StopLight)
                  num4 -= this._negLight2;
                else if (lightingState.WetLight)
                  num4 -= this._wetLightR;
                else
                  num4 -= this._negLight;
              }
              if ((double) lightingState.G2 > (double) num5)
                num5 = lightingState.G2;
              else if ((double) num5 <= 0.0)
                flag2 = true;
              else
                lightingState.G2 = num5;
              if (!flag2)
              {
                if (lightingState.StopLight)
                  num5 -= this._negLight2;
                else if (lightingState.WetLight)
                  num5 -= this._wetLightG;
                else
                  num5 -= this._negLight;
              }
              if ((double) lightingState.B2 > (double) num6)
                num6 = lightingState.B2;
              else if ((double) num6 > 0.0)
                lightingState.B2 = num6;
              else
                continue;
              if (lightingState.StopLight)
                num6 -= this._negLight2;
              else
                num6 -= this._negLight;
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

    public struct RectArea
    {
      public int Left;
      public int Right;
      public int Top;
      public int Bottom;

      public void Set(int left, int right, int top, int bottom)
      {
        this.Left = left;
        this.Right = right;
        this.Top = top;
        this.Bottom = bottom;
      }
    }

    private class LightingSwipeData
    {
      public int InnerLoop1Start;
      public int InnerLoop1End;
      public int InnerLoop2Start;
      public int InnerLoop2End;
      public LegacyLighting.LightingState[][] JaggedArray;

      public LightingSwipeData()
      {
        this.InnerLoop1Start = 0;
        this.InnerLoop1End = 0;
        this.InnerLoop2Start = 0;
        this.InnerLoop2End = 0;
      }

      public void CopyFrom(LegacyLighting.LightingSwipeData from)
      {
        this.InnerLoop1Start = from.InnerLoop1Start;
        this.InnerLoop1End = from.InnerLoop1End;
        this.InnerLoop2Start = from.InnerLoop2Start;
        this.InnerLoop2End = from.InnerLoop2End;
        this.JaggedArray = from.JaggedArray;
      }
    }

    private class LightingState
    {
      public float R;
      public float R2;
      public float G;
      public float G2;
      public float B;
      public float B2;
      public bool StopLight;
      public bool WetLight;
      public bool HoneyLight;

      public Vector3 ToVector3() => new Vector3(this.R, this.G, this.B);
    }

    private struct ColorTriplet
    {
      public float R;
      public float G;
      public float B;

      public ColorTriplet(float R, float G, float B)
      {
        this.R = R;
        this.G = G;
        this.B = B;
      }

      public ColorTriplet(float averageColor) => this.R = this.G = this.B = averageColor;
    }
  }
}
