// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Light.LightMap
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Threading;
using Terraria.Utilities;

namespace Terraria.Graphics.Light
{
  public class LightMap
  {
    private Vector3[] _colors;
    private LightMaskMode[] _mask;
    private FastRandom _random = FastRandom.CreateWithRandomSeed();
    private const int DEFAULT_WIDTH = 203;
    private const int DEFAULT_HEIGHT = 203;

    public int NonVisiblePadding { get; set; }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public float LightDecayThroughAir { get; set; }

    public float LightDecayThroughSolid { get; set; }

    public Vector3 LightDecayThroughWater { get; set; }

    public Vector3 LightDecayThroughHoney { get; set; }

    public Vector3 this[int x, int y]
    {
      get => this._colors[this.IndexOf(x, y)];
      set => this._colors[this.IndexOf(x, y)] = value;
    }

    public LightMap()
    {
      this.LightDecayThroughAir = 0.91f;
      this.LightDecayThroughSolid = 0.56f;
      this.LightDecayThroughWater = new Vector3(0.88f, 0.96f, 1.015f) * 0.91f;
      this.LightDecayThroughHoney = new Vector3(0.75f, 0.7f, 0.6f) * 0.91f;
      this.Width = 203;
      this.Height = 203;
      this._colors = new Vector3[41209];
      this._mask = new LightMaskMode[41209];
    }

    public void GetLight(int x, int y, out Vector3 color) => color = this._colors[this.IndexOf(x, y)];

    public LightMaskMode GetMask(int x, int y) => this._mask[this.IndexOf(x, y)];

    public void Clear()
    {
      for (int index = 0; index < this._colors.Length; ++index)
      {
        this._colors[index].X = 0.0f;
        this._colors[index].Y = 0.0f;
        this._colors[index].Z = 0.0f;
        this._mask[index] = LightMaskMode.None;
      }
    }

    public void SetMaskAt(int x, int y, LightMaskMode mode) => this._mask[this.IndexOf(x, y)] = mode;

    public void Blur()
    {
      this.BlurPass();
      this.BlurPass();
      this._random.NextSeed();
    }

    private void BlurPass()
    {
      // ISSUE: method pointer
      FastParallel.For(0, this.Width, new ParallelForAction((object) this, __methodptr(\u003CBlurPass\u003Eb__42_0)), (object) null);
      // ISSUE: method pointer
      FastParallel.For(0, this.Height, new ParallelForAction((object) this, __methodptr(\u003CBlurPass\u003Eb__42_1)), (object) null);
    }

    private void BlurLine(int startIndex, int endIndex, int stride)
    {
      Vector3 zero = Vector3.Zero;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      for (int index = startIndex; index != endIndex + stride; index += stride)
      {
        if ((double) zero.X < (double) this._colors[index].X)
        {
          zero.X = this._colors[index].X;
          flag1 = false;
        }
        else if (!flag1)
        {
          if ((double) zero.X < 0.0185000002384186)
            flag1 = true;
          else
            this._colors[index].X = zero.X;
        }
        if ((double) zero.Y < (double) this._colors[index].Y)
        {
          zero.Y = this._colors[index].Y;
          flag2 = false;
        }
        else if (!flag2)
        {
          if ((double) zero.Y < 0.0185000002384186)
            flag2 = true;
          else
            this._colors[index].Y = zero.Y;
        }
        if ((double) zero.Z < (double) this._colors[index].Z)
        {
          zero.Z = this._colors[index].Z;
          flag3 = false;
        }
        else if (!flag3)
        {
          if ((double) zero.Z < 0.0185000002384186)
            flag3 = true;
          else
            this._colors[index].Z = zero.Z;
        }
        if (!(flag1 & flag3 & flag2))
        {
          switch (this._mask[index])
          {
            case LightMaskMode.None:
              if (!flag1)
                zero.X *= this.LightDecayThroughAir;
              if (!flag2)
                zero.Y *= this.LightDecayThroughAir;
              if (!flag3)
              {
                zero.Z *= this.LightDecayThroughAir;
                continue;
              }
              continue;
            case LightMaskMode.Solid:
              if (!flag1)
                zero.X *= this.LightDecayThroughSolid;
              if (!flag2)
                zero.Y *= this.LightDecayThroughSolid;
              if (!flag3)
              {
                zero.Z *= this.LightDecayThroughSolid;
                continue;
              }
              continue;
            case LightMaskMode.Water:
              float num = (float) this._random.WithModifier((ulong) index).Next(98, 100) / 100f;
              if (!flag1)
                zero.X *= this.LightDecayThroughWater.X * num;
              if (!flag2)
                zero.Y *= this.LightDecayThroughWater.Y * num;
              if (!flag3)
              {
                zero.Z *= this.LightDecayThroughWater.Z * num;
                continue;
              }
              continue;
            case LightMaskMode.Honey:
              if (!flag1)
                zero.X *= this.LightDecayThroughHoney.X;
              if (!flag2)
                zero.Y *= this.LightDecayThroughHoney.Y;
              if (!flag3)
              {
                zero.Z *= this.LightDecayThroughHoney.Z;
                continue;
              }
              continue;
            default:
              continue;
          }
        }
      }
    }

    private int IndexOf(int x, int y) => x * this.Height + y;

    public void SetSize(int width, int height)
    {
      if (width * height > this._colors.Length)
      {
        this._colors = new Vector3[width * height];
        this._mask = new LightMaskMode[width * height];
      }
      this.Width = width;
      this.Height = height;
    }
  }
}
