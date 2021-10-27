// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.DoubleStack`1
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.DataStructures
{
  public class DoubleStack<T1>
  {
    private T1[][] _segmentList;
    private readonly int _segmentSize;
    private int _segmentCount;
    private readonly int _segmentShiftPosition;
    private int _start;
    private int _end;
    private int _size;
    private int _last;

    public DoubleStack(int segmentSize = 1024, int initialSize = 0)
    {
      if (segmentSize < 16)
        segmentSize = 16;
      this._start = segmentSize / 2;
      this._end = this._start;
      this._size = 0;
      this._segmentShiftPosition = segmentSize + this._start;
      initialSize += this._start;
      int length = initialSize / segmentSize + 1;
      this._segmentList = new T1[length][];
      for (int index = 0; index < length; ++index)
        this._segmentList[index] = new T1[segmentSize];
      this._segmentSize = segmentSize;
      this._segmentCount = length;
      this._last = this._segmentSize * this._segmentCount - 1;
    }

    public void PushFront(T1 front)
    {
      if (this._start == 0)
      {
        T1[][] objArray = new T1[this._segmentCount + 1][];
        for (int index = 0; index < this._segmentCount; ++index)
          objArray[index + 1] = this._segmentList[index];
        objArray[0] = new T1[this._segmentSize];
        this._segmentList = objArray;
        ++this._segmentCount;
        this._start += this._segmentSize;
        this._end += this._segmentSize;
        this._last += this._segmentSize;
      }
      --this._start;
      this._segmentList[this._start / this._segmentSize][this._start % this._segmentSize] = front;
      ++this._size;
    }

    public T1 PopFront()
    {
      if (this._size == 0)
        throw new InvalidOperationException("The DoubleStack is empty.");
      T1[] segment1 = this._segmentList[this._start / this._segmentSize];
      int index1 = this._start % this._segmentSize;
      T1 obj = segment1[index1];
      segment1[index1] = default (T1);
      ++this._start;
      --this._size;
      if (this._start >= this._segmentShiftPosition)
      {
        T1[] segment2 = this._segmentList[0];
        for (int index2 = 0; index2 < this._segmentCount - 1; ++index2)
          this._segmentList[index2] = this._segmentList[index2 + 1];
        this._segmentList[this._segmentCount - 1] = segment2;
        this._start -= this._segmentSize;
        this._end -= this._segmentSize;
      }
      if (this._size == 0)
      {
        this._start = this._segmentSize / 2;
        this._end = this._start;
      }
      return obj;
    }

    public T1 PeekFront()
    {
      if (this._size == 0)
        throw new InvalidOperationException("The DoubleStack is empty.");
      return this._segmentList[this._start / this._segmentSize][this._start % this._segmentSize];
    }

    public void PushBack(T1 back)
    {
      if (this._end == this._last)
      {
        T1[][] objArray = new T1[this._segmentCount + 1][];
        for (int index = 0; index < this._segmentCount; ++index)
          objArray[index] = this._segmentList[index];
        objArray[this._segmentCount] = new T1[this._segmentSize];
        ++this._segmentCount;
        this._segmentList = objArray;
        this._last += this._segmentSize;
      }
      this._segmentList[this._end / this._segmentSize][this._end % this._segmentSize] = back;
      ++this._end;
      ++this._size;
    }

    public T1 PopBack()
    {
      if (this._size == 0)
        throw new InvalidOperationException("The DoubleStack is empty.");
      T1[] segment = this._segmentList[this._end / this._segmentSize];
      int index = this._end % this._segmentSize;
      T1 obj = segment[index];
      segment[index] = default (T1);
      --this._end;
      --this._size;
      if (this._size == 0)
      {
        this._start = this._segmentSize / 2;
        this._end = this._start;
      }
      return obj;
    }

    public T1 PeekBack()
    {
      if (this._size == 0)
        throw new InvalidOperationException("The DoubleStack is empty.");
      return this._segmentList[this._end / this._segmentSize][this._end % this._segmentSize];
    }

    public void Clear(bool quickClear = false)
    {
      if (!quickClear)
      {
        for (int index = 0; index < this._segmentCount; ++index)
          Array.Clear((Array) this._segmentList[index], 0, this._segmentSize);
      }
      this._start = this._segmentSize / 2;
      this._end = this._start;
      this._size = 0;
    }

    public int Count => this._size;
  }
}
