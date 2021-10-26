// Decompiled with JetBrains decompiler
// Type: Terraria.TimeLogger
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Terraria
{
  public static class TimeLogger
  {
    private static StreamWriter logWriter;
    private static StringBuilder logBuilder;
    private static int framesToLog;
    private static int currentFrame;
    private static bool startLoggingNextFrame;
    private static bool endLoggingThisFrame;
    private static bool currentlyLogging;
    private static Stopwatch detailedDrawTimer;
    private static double lastDetailedDrawTime;
    private static TimeLogger.TimeLogData[] renderTimes;
    private static TimeLogger.TimeLogData[] drawTimes;
    private static TimeLogger.TimeLogData[] lightingTimes;
    private static TimeLogger.TimeLogData[] detailedDrawTimes;
    private const int maxTimeDelay = 100;

    public static void Initialize()
    {
      TimeLogger.currentFrame = 0;
      TimeLogger.framesToLog = -1;
      TimeLogger.detailedDrawTimer = new Stopwatch();
      TimeLogger.renderTimes = new TimeLogger.TimeLogData[10];
      TimeLogger.drawTimes = new TimeLogger.TimeLogData[10];
      TimeLogger.lightingTimes = new TimeLogger.TimeLogData[5];
      TimeLogger.detailedDrawTimes = new TimeLogger.TimeLogData[40];
      for (int index = 0; index < TimeLogger.renderTimes.Length; ++index)
        TimeLogger.renderTimes[index].logText = string.Format("Render #{0}", (object) index);
      TimeLogger.drawTimes[0].logText = "Drawing Solid Tiles";
      TimeLogger.drawTimes[1].logText = "Drawing Non-Solid Tiles";
      TimeLogger.drawTimes[2].logText = "Drawing Wall Tiles";
      TimeLogger.drawTimes[3].logText = "Drawing Underground Background";
      TimeLogger.drawTimes[4].logText = "Drawing Water Tiles";
      TimeLogger.drawTimes[5].logText = "Drawing Black Tiles";
      TimeLogger.lightingTimes[0].logText = "Lighting Initialization";
      for (int index = 1; index < TimeLogger.lightingTimes.Length; ++index)
        TimeLogger.lightingTimes[index].logText = string.Format("Lighting Pass #{0}", (object) index);
      TimeLogger.detailedDrawTimes[0].logText = "Finding color tiles";
      TimeLogger.detailedDrawTimes[1].logText = "Initial Map Update";
      TimeLogger.detailedDrawTimes[2].logText = "Finding Waterfalls";
      TimeLogger.detailedDrawTimes[3].logText = "Map Section Update";
      TimeLogger.detailedDrawTimes[4].logText = "Map Update";
      TimeLogger.detailedDrawTimes[5].logText = "Section Framing";
      TimeLogger.detailedDrawTimes[6].logText = "Sky Background";
      TimeLogger.detailedDrawTimes[7].logText = "Sun, Moon & Stars";
      TimeLogger.detailedDrawTimes[8].logText = "Surface Background";
      TimeLogger.detailedDrawTimes[9].logText = "Map";
      TimeLogger.detailedDrawTimes[10].logText = "Player Chat";
      TimeLogger.detailedDrawTimes[11].logText = "Water Target";
      TimeLogger.detailedDrawTimes[12].logText = "Background Target";
      TimeLogger.detailedDrawTimes[13].logText = "Black Tile Target";
      TimeLogger.detailedDrawTimes[14].logText = "Wall Target";
      TimeLogger.detailedDrawTimes[15].logText = "Non Solid Tile Target";
      TimeLogger.detailedDrawTimes[16].logText = "Waterfalls";
      TimeLogger.detailedDrawTimes[17].logText = "Solid Tile Target";
      TimeLogger.detailedDrawTimes[18].logText = "NPCs (Behind Tiles)";
      TimeLogger.detailedDrawTimes[19].logText = "NPC";
      TimeLogger.detailedDrawTimes[20].logText = "Projectiles";
      TimeLogger.detailedDrawTimes[21].logText = "Players";
      TimeLogger.detailedDrawTimes[22].logText = "Items";
      TimeLogger.detailedDrawTimes[23].logText = "Rain";
      TimeLogger.detailedDrawTimes[24].logText = "Gore";
      TimeLogger.detailedDrawTimes[25].logText = "Dust";
      TimeLogger.detailedDrawTimes[26].logText = "Water Target";
      TimeLogger.detailedDrawTimes[27].logText = "Interface";
      TimeLogger.detailedDrawTimes[28].logText = "Render Solid Tiles";
      TimeLogger.detailedDrawTimes[29].logText = "Render Non Solid Tiles";
      TimeLogger.detailedDrawTimes[30].logText = "Render Black Tiles";
      TimeLogger.detailedDrawTimes[31].logText = "Render Water/Wires";
      TimeLogger.detailedDrawTimes[32].logText = "Render Walls";
      TimeLogger.detailedDrawTimes[33].logText = "Render Backgrounds";
      TimeLogger.detailedDrawTimes[34].logText = "Drawing Wires";
      TimeLogger.detailedDrawTimes[35].logText = "Render layers up to Players";
      TimeLogger.detailedDrawTimes[36].logText = "Render Items/Rain/Gore/Dust/Water/Map";
      TimeLogger.detailedDrawTimes[37].logText = "Render Interface";
      for (int index = 0; index < TimeLogger.detailedDrawTimes.Length; ++index)
      {
        if (string.IsNullOrEmpty(TimeLogger.detailedDrawTimes[index].logText))
          TimeLogger.detailedDrawTimes[index].logText = string.Format("Unnamed detailed draw #{0}", (object) index);
      }
    }

    public static void Start()
    {
      if (TimeLogger.currentlyLogging)
      {
        TimeLogger.endLoggingThisFrame = true;
        TimeLogger.startLoggingNextFrame = false;
      }
      else
      {
        TimeLogger.startLoggingNextFrame = true;
        TimeLogger.endLoggingThisFrame = false;
        Main.NewText("Detailed logging started", (byte) 250, (byte) 250, (byte) 0);
      }
    }

    public static void NewDrawFrame()
    {
      for (int index = 0; index < TimeLogger.renderTimes.Length; ++index)
        TimeLogger.renderTimes[index].usedLastDraw = false;
      for (int index = 0; index < TimeLogger.drawTimes.Length; ++index)
        TimeLogger.drawTimes[index].usedLastDraw = false;
      for (int index = 0; index < TimeLogger.lightingTimes.Length; ++index)
        TimeLogger.lightingTimes[index].usedLastDraw = false;
      if (TimeLogger.startLoggingNextFrame)
      {
        TimeLogger.startLoggingNextFrame = false;
        DateTime now = DateTime.Now;
        string path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "TerrariaDrawLog.7z";
        try
        {
          TimeLogger.logWriter = new StreamWriter((Stream) new GZipStream((Stream) new FileStream(path, FileMode.Create), CompressionMode.Compress));
          TimeLogger.logBuilder = new StringBuilder(5000);
          TimeLogger.framesToLog = 600;
          TimeLogger.currentFrame = 1;
          TimeLogger.currentlyLogging = true;
        }
        catch
        {
          Main.NewText("Detailed logging could not be started.", (byte) 250, (byte) 250, (byte) 0);
        }
      }
      if (TimeLogger.currentlyLogging)
        TimeLogger.logBuilder.AppendLine(string.Format("Start of Frame #{0}", (object) TimeLogger.currentFrame));
      TimeLogger.detailedDrawTimer.Restart();
      TimeLogger.lastDetailedDrawTime = TimeLogger.detailedDrawTimer.Elapsed.TotalMilliseconds;
    }

    public static void EndDrawFrame()
    {
      if (TimeLogger.currentFrame <= TimeLogger.framesToLog)
      {
        TimeLogger.logBuilder.AppendLine(string.Format("End of Frame #{0}", (object) TimeLogger.currentFrame));
        TimeLogger.logBuilder.AppendLine();
        if (TimeLogger.endLoggingThisFrame)
        {
          TimeLogger.endLoggingThisFrame = false;
          TimeLogger.logBuilder.AppendLine("Logging ended early");
          TimeLogger.currentFrame = TimeLogger.framesToLog;
        }
        if (TimeLogger.logBuilder.Length > 4000)
        {
          TimeLogger.logWriter.Write(TimeLogger.logBuilder.ToString());
          TimeLogger.logBuilder.Clear();
        }
        ++TimeLogger.currentFrame;
        if (TimeLogger.currentFrame > TimeLogger.framesToLog)
        {
          Main.NewText("Detailed logging ended.", (byte) 250, (byte) 250, (byte) 0);
          TimeLogger.logWriter.Write(TimeLogger.logBuilder.ToString());
          TimeLogger.logBuilder.Clear();
          TimeLogger.logBuilder = (StringBuilder) null;
          TimeLogger.logWriter.Flush();
          TimeLogger.logWriter.Close();
          TimeLogger.logWriter = (StreamWriter) null;
          TimeLogger.framesToLog = -1;
          TimeLogger.currentFrame = 0;
          TimeLogger.currentlyLogging = false;
        }
      }
      TimeLogger.detailedDrawTimer.Stop();
    }

    private static void UpdateTime(TimeLogger.TimeLogData[] times, int type, double time)
    {
      bool flag = false;
      if (times[type].resetMaxTime > 0)
        --times[type].resetMaxTime;
      else
        times[type].timeMax = 0.0f;
      times[type].time = (float) time;
      if ((double) times[type].timeMax < time)
      {
        flag = true;
        times[type].timeMax = (float) time;
        times[type].resetMaxTime = 100;
      }
      times[type].usedLastDraw = true;
      if (TimeLogger.currentFrame == 0)
        return;
      TimeLogger.logBuilder.AppendLine(string.Format("    {0} : {1:F4}ms {2}", (object) times[type].logText, (object) time, flag ? (object) " - New Maximum" : (object) string.Empty));
    }

    public static void RenderTime(int renderType, double timeElapsed)
    {
      if (renderType < 0 || renderType >= TimeLogger.renderTimes.Length)
        return;
      TimeLogger.UpdateTime(TimeLogger.renderTimes, renderType, timeElapsed);
    }

    public static float GetRenderTime(int renderType) => TimeLogger.renderTimes[renderType].time;

    public static float GetRenderMax(int renderType) => TimeLogger.renderTimes[renderType].timeMax;

    public static void DrawTime(int drawType, double timeElapsed)
    {
      if (drawType < 0 || drawType >= TimeLogger.drawTimes.Length)
        return;
      TimeLogger.UpdateTime(TimeLogger.drawTimes, drawType, timeElapsed);
    }

    public static float GetDrawTime(int drawType) => TimeLogger.drawTimes[drawType].time;

    public static float GetDrawTotal()
    {
      float num = 0.0f;
      for (int index = 0; index < TimeLogger.drawTimes.Length; ++index)
        num += TimeLogger.drawTimes[index].time;
      return num;
    }

    public static void LightingTime(int lightingType, double timeElapsed)
    {
      if (lightingType < 0 || lightingType >= TimeLogger.lightingTimes.Length)
        return;
      TimeLogger.UpdateTime(TimeLogger.lightingTimes, lightingType, timeElapsed);
    }

    public static float GetLightingTime(int lightingType) => TimeLogger.lightingTimes[lightingType].time;

    public static float GetLightingTotal()
    {
      float num = 0.0f;
      for (int index = 0; index < TimeLogger.lightingTimes.Length; ++index)
        num += TimeLogger.lightingTimes[index].time;
      return num;
    }

    public static void DetailedDrawReset() => TimeLogger.lastDetailedDrawTime = TimeLogger.detailedDrawTimer.Elapsed.TotalMilliseconds;

    public static void DetailedDrawTime(int detailedDrawType)
    {
      if (detailedDrawType < 0 || detailedDrawType >= TimeLogger.detailedDrawTimes.Length)
        return;
      double totalMilliseconds = TimeLogger.detailedDrawTimer.Elapsed.TotalMilliseconds;
      double time = totalMilliseconds - TimeLogger.lastDetailedDrawTime;
      TimeLogger.lastDetailedDrawTime = totalMilliseconds;
      TimeLogger.UpdateTime(TimeLogger.detailedDrawTimes, detailedDrawType, time);
    }

    public static float GetDetailedDrawTime(int detailedDrawType) => TimeLogger.detailedDrawTimes[detailedDrawType].time;

    public static float GetDetailedDrawTotal()
    {
      float num = 0.0f;
      for (int index = 0; index < TimeLogger.detailedDrawTimes.Length; ++index)
      {
        if (TimeLogger.detailedDrawTimes[index].usedLastDraw)
          num += TimeLogger.detailedDrawTimes[index].time;
      }
      return num;
    }

    public static void MenuDrawTime(double timeElapsed)
    {
      if (!TimeLogger.currentlyLogging)
        return;
      TimeLogger.logBuilder.AppendLine(string.Format("Menu Render Time : {0:F4}", (object) timeElapsed));
    }

    public static void SplashDrawTime(double timeElapsed)
    {
      if (!TimeLogger.currentlyLogging)
        return;
      TimeLogger.logBuilder.AppendLine(string.Format("Splash Render Time : {0:F4}", (object) timeElapsed));
    }

    public static void MapDrawTime(double timeElapsed)
    {
      if (!TimeLogger.currentlyLogging)
        return;
      TimeLogger.logBuilder.AppendLine(string.Format("Full Screen Map Render Time : {0:F4}", (object) timeElapsed));
    }

    public static void DrawException(Exception e)
    {
      if (!TimeLogger.currentlyLogging)
        return;
      TimeLogger.logBuilder.AppendLine(e.ToString());
    }

    private struct TimeLogData
    {
      public float time;
      public float timeMax;
      public int resetMaxTime;
      public bool usedLastDraw;
      public string logText;
    }
  }
}
