// Decompiled with JetBrains decompiler
// Type: Terraria.WorldSections
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace Terraria
{
  public class WorldSections
  {
    private int width;
    private int height;
    private BitsByte[] data;
    private int mapSectionsLeft;
    private int frameSectionsLeft;
    private WorldSections.IterationState prevFrame;
    private WorldSections.IterationState prevMap;

    public WorldSections(int numSectionsX, int numSectionsY)
    {
      this.width = numSectionsX;
      this.height = numSectionsY;
      this.data = new BitsByte[this.width * this.height];
      this.mapSectionsLeft = this.width * this.height;
      this.prevFrame.Reset();
      this.prevMap.Reset();
    }

    public int FrameSectionsLeft => this.frameSectionsLeft;

    public int MapSectionsLeft => this.mapSectionsLeft;

    public bool SectionLoaded(int x, int y) => x >= 0 && x < this.width && y >= 0 && y < this.height && this.data[y * this.width + x][0];

    public void SectionLoaded(int x, int y, bool value)
    {
      if (x < 0 || x >= this.width || y < 0 || y >= this.height)
        return;
      this.data[y * this.width + x][0] = value;
    }

    public bool SectionFramed(int x, int y) => x >= 0 && x < this.width && y >= 0 && y < this.height && this.data[y * this.width + x][1];

    public void SectionFramed(int x, int y, bool value)
    {
      if (x < 0 || x >= this.width || y < 0 || y >= this.height)
        return;
      if (this.data[y * this.width + x][1] != value)
      {
        if (value)
          ++this.frameSectionsLeft;
        else
          --this.frameSectionsLeft;
      }
      this.data[y * this.width + x][1] = value;
    }

    public bool MapSectionDrawn(int x, int y) => x >= 0 && x < this.width && y >= 0 && y < this.height && this.data[y * this.width + x][2];

    public void MapSectionDrawn(int x, int y, bool value)
    {
      if (x < 0 || x >= this.width || y < 0 || y >= this.height)
        return;
      if (this.data[y * this.width + x][1] != value)
      {
        if (value)
          ++this.mapSectionsLeft;
        else
          --this.mapSectionsLeft;
      }
      this.data[y * this.width + x][2] = value;
    }

    public void ClearMapDraw()
    {
      for (int index = 0; index < this.data.Length; ++index)
        this.data[index][2] = false;
      this.prevMap.Reset();
      this.mapSectionsLeft = this.data.Length;
    }

    public void SetSectionLoaded(int x, int y)
    {
      if (x < 0 || x >= this.width || y < 0 || y >= this.height || this.data[y * this.width + x][0])
        return;
      this.data[y * this.width + x][0] = true;
      ++this.frameSectionsLeft;
    }

    public void SetSectionFramed(int x, int y)
    {
      if (x < 0 || x >= this.width || y < 0 || y >= this.height || this.data[y * this.width + x][1])
        return;
      this.data[y * this.width + x][1] = true;
      --this.frameSectionsLeft;
    }

    public void SetAllFramesLoaded()
    {
      for (int index = 0; index < this.data.Length; ++index)
      {
        if (!this.data[index][0])
        {
          this.data[index][0] = true;
          ++this.frameSectionsLeft;
        }
      }
    }

    public bool GetNextMapDraw(Vector2 playerPos, out int x, out int y)
    {
      if (this.mapSectionsLeft <= 0)
      {
        x = -1;
        y = -1;
        return false;
      }
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num1 = 0;
      int num2 = 0;
      Vector2 vector2 = this.prevMap.centerPos;
      playerPos *= 1f / 16f;
      int sectionX = Netplay.GetSectionX((int) playerPos.X);
      int sectionY = Netplay.GetSectionY((int) playerPos.Y);
      int num3 = Netplay.GetSectionX((int) vector2.X);
      int num4 = Netplay.GetSectionY((int) vector2.Y);
      int num5;
      if (num3 != sectionX || num4 != sectionY)
      {
        vector2 = playerPos;
        num3 = sectionX;
        num4 = sectionY;
        num5 = 4;
        x = sectionX;
        y = sectionY;
      }
      else
      {
        num5 = this.prevMap.leg;
        x = this.prevMap.X;
        y = this.prevMap.Y;
        num1 = this.prevMap.xDir;
        num2 = this.prevMap.yDir;
      }
      int num6 = (int) ((double) playerPos.X - ((double) num3 + 0.5) * 200.0);
      int num7 = (int) ((double) playerPos.Y - ((double) num4 + 0.5) * 150.0);
      if (num1 == 0)
      {
        num1 = num6 <= 0 ? 1 : -1;
        num2 = num7 <= 0 ? 1 : -1;
      }
      int num8 = 0;
      bool flag1 = false;
      bool flag2 = false;
      while (true)
      {
        if (num8 == 4)
        {
          if (!flag2)
          {
            flag2 = true;
            x = num3;
            y = num4;
            num6 = (int) ((double) vector2.X - ((double) num3 + 0.5) * 200.0);
            num7 = (int) ((double) vector2.Y - ((double) num4 + 0.5) * 150.0);
            num1 = num6 <= 0 ? 1 : -1;
            num2 = num7 <= 0 ? 1 : -1;
            num5 = 4;
            num8 = 0;
          }
          else
            break;
        }
        if (y >= 0 && y < this.height && x >= 0 && x < this.width)
        {
          flag1 = false;
          if (!this.data[y * this.width + x][2])
            goto label_14;
        }
        int num9 = x - num3;
        int num10 = y - num4;
        if (num9 == 0 || num10 == 0)
        {
          if (num5 == 4)
          {
            if (num9 == 0 && num10 == 0)
            {
              if (Math.Abs(num6) > Math.Abs(num7))
                y -= num2;
              else
                x -= num1;
            }
            else
            {
              if (num9 != 0)
                x += num9 / Math.Abs(num9);
              if (num10 != 0)
                y += num10 / Math.Abs(num10);
            }
            num5 = 0;
            num8 = -2;
            flag1 = true;
          }
          else
          {
            if (num9 == 0)
              num2 = num10 <= 0 ? 1 : -1;
            else
              num1 = num9 <= 0 ? 1 : -1;
            x += num1;
            y += num2;
            ++num5;
          }
          if (flag1)
            ++num8;
          else
            flag1 = true;
        }
        else
        {
          x += num1;
          y += num2;
        }
      }
      throw new Exception("Infinite loop in WorldSections.GetNextMapDraw");
label_14:
      this.data[y * this.width + x][2] = true;
      --this.mapSectionsLeft;
      this.prevMap.centerPos = playerPos;
      this.prevMap.X = x;
      this.prevMap.Y = y;
      this.prevMap.leg = num5;
      this.prevMap.xDir = num1;
      this.prevMap.yDir = num2;
      stopwatch.Stop();
      return true;
    }

    public bool GetNextTileFrame(Vector2 playerPos, out int x, out int y)
    {
      if (this.frameSectionsLeft <= 0)
      {
        x = -1;
        y = -1;
        return false;
      }
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num1 = 0;
      int num2 = 0;
      Vector2 vector2 = this.prevFrame.centerPos;
      playerPos *= 1f / 16f;
      int sectionX = Netplay.GetSectionX((int) playerPos.X);
      int sectionY = Netplay.GetSectionY((int) playerPos.Y);
      int num3 = Netplay.GetSectionX((int) vector2.X);
      int num4 = Netplay.GetSectionY((int) vector2.Y);
      int num5;
      if (num3 != sectionX || num4 != sectionY)
      {
        vector2 = playerPos;
        num3 = sectionX;
        num4 = sectionY;
        num5 = 4;
        x = sectionX;
        y = sectionY;
      }
      else
      {
        num5 = this.prevFrame.leg;
        x = this.prevFrame.X;
        y = this.prevFrame.Y;
        num1 = this.prevFrame.xDir;
        num2 = this.prevFrame.yDir;
      }
      int num6 = (int) ((double) playerPos.X - ((double) num3 + 0.5) * 200.0);
      int num7 = (int) ((double) playerPos.Y - ((double) num4 + 0.5) * 150.0);
      if (num1 == 0)
      {
        num1 = num6 <= 0 ? 1 : -1;
        num2 = num7 <= 0 ? 1 : -1;
      }
      int num8 = 0;
      bool flag1 = false;
      bool flag2 = false;
      while (true)
      {
        if (num8 == 4)
        {
          if (!flag2)
          {
            flag2 = true;
            x = num3;
            y = num4;
            num6 = (int) ((double) vector2.X - ((double) num3 + 0.5) * 200.0);
            num7 = (int) ((double) vector2.Y - ((double) num4 + 0.5) * 150.0);
            num1 = num6 <= 0 ? 1 : -1;
            num2 = num7 <= 0 ? 1 : -1;
            num5 = 4;
            num8 = 0;
          }
          else
            break;
        }
        if (y >= 0 && y < this.height && x >= 0 && x < this.width)
        {
          flag1 = false;
          if (this.data[y * this.width + x][0] && !this.data[y * this.width + x][1])
            goto label_14;
        }
        int num9 = x - num3;
        int num10 = y - num4;
        if (num9 == 0 || num10 == 0)
        {
          if (num5 == 4)
          {
            if (num9 == 0 && num10 == 0)
            {
              if (Math.Abs(num6) > Math.Abs(num7))
                y -= num2;
              else
                x -= num1;
            }
            else
            {
              if (num9 != 0)
                x += num9 / Math.Abs(num9);
              if (num10 != 0)
                y += num10 / Math.Abs(num10);
            }
            num5 = 0;
            num8 = 0;
            flag1 = true;
          }
          else
          {
            if (num9 == 0)
              num2 = num10 <= 0 ? 1 : -1;
            else
              num1 = num9 <= 0 ? 1 : -1;
            x += num1;
            y += num2;
            ++num5;
          }
          if (flag1)
            ++num8;
          else
            flag1 = true;
        }
        else
        {
          x += num1;
          y += num2;
        }
      }
      throw new Exception("Infinite loop in WorldSections.GetNextTileFrame");
label_14:
      this.data[y * this.width + x][1] = true;
      --this.frameSectionsLeft;
      this.prevFrame.centerPos = playerPos;
      this.prevFrame.X = x;
      this.prevFrame.Y = y;
      this.prevFrame.leg = num5;
      this.prevFrame.xDir = num1;
      this.prevFrame.yDir = num2;
      stopwatch.Stop();
      return true;
    }

    private struct IterationState
    {
      public Vector2 centerPos;
      public int X;
      public int Y;
      public int leg;
      public int xDir;
      public int yDir;

      public void Reset()
      {
        this.centerPos = new Vector2(-3200f, -2400f);
        this.X = 0;
        this.Y = 0;
        this.leg = 0;
        this.xDir = 0;
        this.yDir = 0;
      }
    }
  }
}
