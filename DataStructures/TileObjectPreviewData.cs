// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileObjectPreviewData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.DataStructures
{
  public class TileObjectPreviewData
  {
    private ushort _type;
    private short _style;
    private int _alternate;
    private int _random;
    private bool _active;
    private Point16 _size;
    private Point16 _coordinates;
    private Point16 _objectStart;
    private int[,] _data;
    private Point16 _dataSize;
    private float _percentValid;
    public static TileObjectPreviewData placementCache;
    public static TileObjectPreviewData randomCache;
    public const int None = 0;
    public const int ValidSpot = 1;
    public const int InvalidSpot = 2;

    public void Reset()
    {
      this._active = false;
      this._size = Point16.Zero;
      this._coordinates = Point16.Zero;
      this._objectStart = Point16.Zero;
      this._percentValid = 0.0f;
      this._type = (ushort) 0;
      this._style = (short) 0;
      this._alternate = -1;
      this._random = -1;
      if (this._data == null)
        return;
      Array.Clear((Array) this._data, 0, (int) this._dataSize.X * (int) this._dataSize.Y);
    }

    public void CopyFrom(TileObjectPreviewData copy)
    {
      this._type = copy._type;
      this._style = copy._style;
      this._alternate = copy._alternate;
      this._random = copy._random;
      this._active = copy._active;
      this._size = copy._size;
      this._coordinates = copy._coordinates;
      this._objectStart = copy._objectStart;
      this._percentValid = copy._percentValid;
      if (this._data == null)
      {
        this._data = new int[(int) copy._dataSize.X, (int) copy._dataSize.Y];
        this._dataSize = copy._dataSize;
      }
      else
        Array.Clear((Array) this._data, 0, this._data.Length);
      if ((int) this._dataSize.X < (int) copy._dataSize.X || (int) this._dataSize.Y < (int) copy._dataSize.Y)
      {
        int X = (int) copy._dataSize.X > (int) this._dataSize.X ? (int) copy._dataSize.X : (int) this._dataSize.X;
        int Y = (int) copy._dataSize.Y > (int) this._dataSize.Y ? (int) copy._dataSize.Y : (int) this._dataSize.Y;
        this._data = new int[X, Y];
        this._dataSize = new Point16(X, Y);
      }
      for (int index1 = 0; index1 < (int) copy._dataSize.X; ++index1)
      {
        for (int index2 = 0; index2 < (int) copy._dataSize.Y; ++index2)
          this._data[index1, index2] = copy._data[index1, index2];
      }
    }

    public bool Active
    {
      get => this._active;
      set => this._active = value;
    }

    public ushort Type
    {
      get => this._type;
      set => this._type = value;
    }

    public short Style
    {
      get => this._style;
      set => this._style = value;
    }

    public int Alternate
    {
      get => this._alternate;
      set => this._alternate = value;
    }

    public int Random
    {
      get => this._random;
      set => this._random = value;
    }

    public Point16 Size
    {
      get => this._size;
      set
      {
        if (value.X <= (short) 0 || value.Y <= (short) 0)
          throw new FormatException("PlacementData.Size was set to a negative value.");
        if ((int) value.X > (int) this._dataSize.X || (int) value.Y > (int) this._dataSize.Y)
        {
          int X = (int) value.X > (int) this._dataSize.X ? (int) value.X : (int) this._dataSize.X;
          int Y = (int) value.Y > (int) this._dataSize.Y ? (int) value.Y : (int) this._dataSize.Y;
          int[,] numArray = new int[X, Y];
          if (this._data != null)
          {
            for (int index1 = 0; index1 < (int) this._dataSize.X; ++index1)
            {
              for (int index2 = 0; index2 < (int) this._dataSize.Y; ++index2)
                numArray[index1, index2] = this._data[index1, index2];
            }
          }
          this._data = numArray;
          this._dataSize = new Point16(X, Y);
        }
        this._size = value;
      }
    }

    public Point16 Coordinates
    {
      get => this._coordinates;
      set => this._coordinates = value;
    }

    public Point16 ObjectStart
    {
      get => this._objectStart;
      set => this._objectStart = value;
    }

    public void AllInvalid()
    {
      for (int index1 = 0; index1 < (int) this._size.X; ++index1)
      {
        for (int index2 = 0; index2 < (int) this._size.Y; ++index2)
        {
          if (this._data[index1, index2] != 0)
            this._data[index1, index2] = 2;
        }
      }
    }

    public int this[int x, int y]
    {
      get
      {
        if (x < 0 || y < 0 || x >= (int) this._size.X || y >= (int) this._size.Y)
          throw new IndexOutOfRangeException();
        return this._data[x, y];
      }
      set
      {
        if (x < 0 || y < 0 || x >= (int) this._size.X || y >= (int) this._size.Y)
          throw new IndexOutOfRangeException();
        this._data[x, y] = value;
      }
    }
  }
}
