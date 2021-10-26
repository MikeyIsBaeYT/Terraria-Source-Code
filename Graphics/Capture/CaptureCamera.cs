// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Capture.CaptureCamera
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Effects;
using Terraria.Localization;

namespace Terraria.Graphics.Capture
{
  internal class CaptureCamera
  {
    private static bool CameraExists;
    public const int CHUNK_SIZE = 128;
    public const int FRAMEBUFFER_PIXEL_SIZE = 2048;
    public const int INNER_CHUNK_SIZE = 126;
    public const int MAX_IMAGE_SIZE = 4096;
    public const string CAPTURE_DIRECTORY = "Captures";
    private RenderTarget2D _frameBuffer;
    private RenderTarget2D _scaledFrameBuffer;
    private RenderTarget2D _filterFrameBuffer1;
    private RenderTarget2D _filterFrameBuffer2;
    private GraphicsDevice _graphics;
    private readonly object _captureLock = new object();
    private bool _isDisposed;
    private CaptureSettings _activeSettings;
    private Queue<CaptureCamera.CaptureChunk> _renderQueue = new Queue<CaptureCamera.CaptureChunk>();
    private SpriteBatch _spriteBatch;
    private byte[] _scaledFrameData;
    private byte[] _outputData;
    private Size _outputImageSize;
    private SamplerState _downscaleSampleState;
    private float _tilesProcessed;
    private float _totalTiles;

    public bool IsCapturing
    {
      get
      {
        Monitor.Enter(this._captureLock);
        int num = this._activeSettings != null ? 1 : 0;
        Monitor.Exit(this._captureLock);
        return num != 0;
      }
    }

    public CaptureCamera(GraphicsDevice graphics)
    {
      CaptureCamera.CameraExists = true;
      this._graphics = graphics;
      this._spriteBatch = new SpriteBatch(graphics);
      try
      {
        this._frameBuffer = new RenderTarget2D(graphics, 2048, 2048, false, graphics.PresentationParameters.BackBufferFormat, DepthFormat.None);
        this._filterFrameBuffer1 = new RenderTarget2D(graphics, 2048, 2048, false, graphics.PresentationParameters.BackBufferFormat, DepthFormat.None);
        this._filterFrameBuffer2 = new RenderTarget2D(graphics, 2048, 2048, false, graphics.PresentationParameters.BackBufferFormat, DepthFormat.None);
      }
      catch
      {
        Main.CaptureModeDisabled = true;
        return;
      }
      this._downscaleSampleState = SamplerState.AnisotropicClamp;
    }

    ~CaptureCamera() => this.Dispose();

    public void Capture(CaptureSettings settings)
    {
      Main.GlobalTimerPaused = true;
      Monitor.Enter(this._captureLock);
      this._activeSettings = this._activeSettings == null ? settings : throw new InvalidOperationException("Capture called while another capture was already active.");
      Microsoft.Xna.Framework.Rectangle area = settings.Area;
      float num1 = 1f;
      if (settings.UseScaling)
      {
        if (area.Width * 16 > 4096)
          num1 = 4096f / (float) (area.Width * 16);
        if (area.Height * 16 > 4096)
          num1 = Math.Min(num1, 4096f / (float) (area.Height * 16));
        num1 = Math.Min(1f, num1);
        this._outputImageSize = new Size((int) MathHelper.Clamp((float) (int) ((double) num1 * (double) (area.Width * 16)), 1f, 4096f), (int) MathHelper.Clamp((float) (int) ((double) num1 * (double) (area.Height * 16)), 1f, 4096f));
        this._outputData = new byte[4 * this._outputImageSize.Width * this._outputImageSize.Height];
        int num2 = (int) Math.Floor((double) num1 * 2048.0);
        this._scaledFrameData = new byte[4 * num2 * num2];
        this._scaledFrameBuffer = new RenderTarget2D(this._graphics, num2, num2, false, this._graphics.PresentationParameters.BackBufferFormat, DepthFormat.None);
      }
      else
        this._outputData = new byte[16777216];
      this._tilesProcessed = 0.0f;
      this._totalTiles = (float) (area.Width * area.Height);
      for (int x1 = area.X; x1 < area.X + area.Width; x1 += 126)
      {
        for (int y1 = area.Y; y1 < area.Y + area.Height; y1 += 126)
        {
          int width1 = Math.Min(128, area.X + area.Width - x1);
          int height1 = Math.Min(128, area.Y + area.Height - y1);
          int width2 = (int) Math.Floor((double) num1 * (double) (width1 * 16));
          int height2 = (int) Math.Floor((double) num1 * (double) (height1 * 16));
          int x2 = (int) Math.Floor((double) num1 * (double) ((x1 - area.X) * 16));
          int y2 = (int) Math.Floor((double) num1 * (double) ((y1 - area.Y) * 16));
          this._renderQueue.Enqueue(new CaptureCamera.CaptureChunk(new Microsoft.Xna.Framework.Rectangle(x1, y1, width1, height1), new Microsoft.Xna.Framework.Rectangle(x2, y2, width2, height2)));
        }
      }
      Monitor.Exit(this._captureLock);
    }

    public void DrawTick()
    {
      Monitor.Enter(this._captureLock);
      if (this._activeSettings == null)
        return;
      bool notRetro = Lighting.NotRetro;
      if (this._renderQueue.Count > 0)
      {
        CaptureCamera.CaptureChunk captureChunk = this._renderQueue.Dequeue();
        this._graphics.SetRenderTarget((RenderTarget2D) null);
        this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
        TileDrawing tilesRenderer = Main.instance.TilesRenderer;
        Microsoft.Xna.Framework.Rectangle area = captureChunk.Area;
        int left = area.Left;
        area = captureChunk.Area;
        int right = area.Right;
        area = captureChunk.Area;
        int top = area.Top;
        area = captureChunk.Area;
        int bottom = area.Bottom;
        tilesRenderer.PrepareForAreaDrawing(left, right, top, bottom, false);
        Main.instance.TilePaintSystem.PrepareAllRequests();
        this._graphics.SetRenderTarget(this._frameBuffer);
        this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
        if (notRetro)
        {
          Microsoft.Xna.Framework.Color clearColor = this._activeSettings.CaptureBackground ? Microsoft.Xna.Framework.Color.Black : Microsoft.Xna.Framework.Color.Transparent;
          Filters.Scene.BeginCapture(this._filterFrameBuffer1, clearColor);
          Main.instance.DrawCapture(captureChunk.Area, this._activeSettings);
          Filters.Scene.EndCapture(this._frameBuffer, this._filterFrameBuffer1, this._filterFrameBuffer2, clearColor);
        }
        else
          Main.instance.DrawCapture(captureChunk.Area, this._activeSettings);
        if (this._activeSettings.UseScaling)
        {
          this._graphics.SetRenderTarget(this._scaledFrameBuffer);
          this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
          this._spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, this._downscaleSampleState, DepthStencilState.Default, RasterizerState.CullNone);
          this._spriteBatch.Draw((Texture2D) this._frameBuffer, new Microsoft.Xna.Framework.Rectangle(0, 0, this._scaledFrameBuffer.Width, this._scaledFrameBuffer.Height), Microsoft.Xna.Framework.Color.White);
          this._spriteBatch.End();
          this._graphics.SetRenderTarget((RenderTarget2D) null);
          this._scaledFrameBuffer.GetData<byte>(this._scaledFrameData, 0, this._scaledFrameBuffer.Width * this._scaledFrameBuffer.Height * 4);
          this.DrawBytesToBuffer(this._scaledFrameData, this._outputData, this._scaledFrameBuffer.Width, this._outputImageSize.Width, captureChunk.ScaledArea);
        }
        else
        {
          this._graphics.SetRenderTarget((RenderTarget2D) null);
          this.SaveImage((Texture2D) this._frameBuffer, captureChunk.ScaledArea.Width, captureChunk.ScaledArea.Height, ImageFormat.Png, this._activeSettings.OutputName, captureChunk.Area.X.ToString() + "-" + (object) captureChunk.Area.Y + ".png");
        }
        this._tilesProcessed += (float) (captureChunk.Area.Width * captureChunk.Area.Height);
      }
      if (this._renderQueue.Count == 0)
        this.FinishCapture();
      Monitor.Exit(this._captureLock);
    }

    private unsafe void DrawBytesToBuffer(
      byte[] sourceBuffer,
      byte[] destinationBuffer,
      int sourceBufferWidth,
      int destinationBufferWidth,
      Microsoft.Xna.Framework.Rectangle area)
    {
      fixed (byte* numPtr1 = &destinationBuffer[0])
        fixed (byte* numPtr2 = &sourceBuffer[0])
        {
          byte* numPtr3 = numPtr2;
          byte* numPtr4 = numPtr1 + (destinationBufferWidth * area.Y + area.X << 2);
          for (int index1 = 0; index1 < area.Height; ++index1)
          {
            for (int index2 = 0; index2 < area.Width; ++index2)
            {
              numPtr4[2] = *numPtr3;
              numPtr4[1] = numPtr3[1];
              *numPtr4 = numPtr3[2];
              numPtr4[3] = numPtr3[3];
              numPtr3 += 4;
              numPtr4 += 4;
            }
            numPtr3 += sourceBufferWidth - area.Width << 2;
            numPtr4 += destinationBufferWidth - area.Width << 2;
          }
        }
    }

    public float GetProgress() => this._tilesProcessed / this._totalTiles;

    private bool SaveImage(int width, int height, ImageFormat imageFormat, string filename)
    {
      string savePath = Main.SavePath;
      char directorySeparatorChar = Path.DirectorySeparatorChar;
      string str1 = directorySeparatorChar.ToString();
      directorySeparatorChar = Path.DirectorySeparatorChar;
      string str2 = directorySeparatorChar.ToString();
      if (!Utils.TryCreatingDirectory(savePath + str1 + "Captures" + str2))
        return false;
      try
      {
        using (Bitmap bitmap = new Bitmap(width, height))
        {
          System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
          BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
          Marshal.Copy(this._outputData, 0, bitmapdata.Scan0, width * height * 4);
          bitmap.UnlockBits(bitmapdata);
          bitmap.Save(filename, imageFormat);
          bitmap.Dispose();
        }
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        return false;
      }
    }

    private void SaveImage(
      Texture2D texture,
      int width,
      int height,
      ImageFormat imageFormat,
      string foldername,
      string filename)
    {
      string str = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Captures" + Path.DirectorySeparatorChar.ToString() + foldername;
      string filename1 = Path.Combine(str, filename);
      if (!Utils.TryCreatingDirectory(str))
        return;
      using (Bitmap bitmap = new Bitmap(width, height))
      {
        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
        int elementCount = texture.Width * texture.Height * 4;
        texture.GetData<byte>(this._outputData, 0, elementCount);
        int index1 = 0;
        int index2 = 0;
        for (int index3 = 0; index3 < height; ++index3)
        {
          for (int index4 = 0; index4 < width; ++index4)
          {
            byte num = this._outputData[index1 + 2];
            this._outputData[index2 + 2] = this._outputData[index1];
            this._outputData[index2] = num;
            this._outputData[index2 + 1] = this._outputData[index1 + 1];
            this._outputData[index2 + 3] = this._outputData[index1 + 3];
            index1 += 4;
            index2 += 4;
          }
          index1 += texture.Width - width << 2;
        }
        BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
        Marshal.Copy(this._outputData, 0, bitmapdata.Scan0, width * height * 4);
        bitmap.UnlockBits(bitmapdata);
        bitmap.Save(filename1, imageFormat);
      }
    }

    private void FinishCapture()
    {
      if (this._activeSettings.UseScaling)
      {
        int num = 0;
        do
        {
          int width = this._outputImageSize.Width;
          int height = this._outputImageSize.Height;
          ImageFormat png = ImageFormat.Png;
          string[] strArray = new string[6];
          strArray[0] = Main.SavePath;
          char directorySeparatorChar = Path.DirectorySeparatorChar;
          strArray[1] = directorySeparatorChar.ToString();
          strArray[2] = "Captures";
          directorySeparatorChar = Path.DirectorySeparatorChar;
          strArray[3] = directorySeparatorChar.ToString();
          strArray[4] = this._activeSettings.OutputName;
          strArray[5] = ".png";
          string filename = string.Concat(strArray);
          if (!this.SaveImage(width, height, png, filename))
          {
            GC.Collect();
            Thread.Sleep(5);
            ++num;
            Console.WriteLine(Language.GetTextValue("Error.CaptureError"));
          }
          else
            goto label_5;
        }
        while (num <= 5);
        Console.WriteLine(Language.GetTextValue("Error.UnableToCapture"));
      }
label_5:
      this._outputData = (byte[]) null;
      this._scaledFrameData = (byte[]) null;
      Main.GlobalTimerPaused = false;
      CaptureInterface.EndCamera();
      if (this._scaledFrameBuffer != null)
      {
        this._scaledFrameBuffer.Dispose();
        this._scaledFrameBuffer = (RenderTarget2D) null;
      }
      this._activeSettings = (CaptureSettings) null;
    }

    public void Dispose()
    {
      Monitor.Enter(this._captureLock);
      if (this._isDisposed)
        return;
      this._frameBuffer.Dispose();
      this._filterFrameBuffer1.Dispose();
      this._filterFrameBuffer2.Dispose();
      if (this._scaledFrameBuffer != null)
      {
        this._scaledFrameBuffer.Dispose();
        this._scaledFrameBuffer = (RenderTarget2D) null;
      }
      CaptureCamera.CameraExists = false;
      this._isDisposed = true;
      Monitor.Exit(this._captureLock);
    }

    private class CaptureChunk
    {
      public readonly Microsoft.Xna.Framework.Rectangle Area;
      public readonly Microsoft.Xna.Framework.Rectangle ScaledArea;

      public CaptureChunk(Microsoft.Xna.Framework.Rectangle area, Microsoft.Xna.Framework.Rectangle scaledArea)
      {
        this.Area = area;
        this.ScaledArea = scaledArea;
      }
    }
  }
}
