// Decompiled with JetBrains decompiler
// Type: Terraria.Testing.PacketHistory
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Terraria.Testing
{
  public class PacketHistory
  {
    private byte[] _buffer;
    private PacketHistory.PacketView[] _packets;
    private int _bufferPosition;
    private int _historyPosition;

    public PacketHistory(int historySize = 100, int bufferSize = 65535)
    {
    }

    [Conditional("DEBUG")]
    public void Record(byte[] buffer, int offset, int length)
    {
      length = Math.Max(0, length);
      PacketHistory.PacketView packetView = this.AppendPacket(length);
      Buffer.BlockCopy((Array) buffer, offset, (Array) this._buffer, packetView.Offset, length);
    }

    private PacketHistory.PacketView AppendPacket(int size)
    {
      int offset = this._bufferPosition;
      if (offset + size > this._buffer.Length)
        offset = 0;
      PacketHistory.PacketView packetView = new PacketHistory.PacketView(offset, size, DateTime.Now);
      this._packets[this._historyPosition] = packetView;
      this._historyPosition = (this._historyPosition + 1) % this._packets.Length;
      this._bufferPosition = offset + size;
      return packetView;
    }

    [Conditional("DEBUG")]
    public void Dump(string reason)
    {
      byte[] numArray = new byte[this._buffer.Length];
      Buffer.BlockCopy((Array) this._buffer, this._bufferPosition, (Array) numArray, 0, this._buffer.Length - this._bufferPosition);
      Buffer.BlockCopy((Array) this._buffer, 0, (Array) numArray, this._buffer.Length - this._bufferPosition, this._bufferPosition);
      StringBuilder stringBuilder = new StringBuilder();
      int num = 1;
      for (int index1 = 0; index1 < this._packets.Length; ++index1)
      {
        PacketHistory.PacketView packet = this._packets[(index1 + this._historyPosition) % this._packets.Length];
        if (packet.Offset != 0 || packet.Length != 0)
        {
          stringBuilder.Append(string.Format("Packet {0} [Assumed MessageID: {4}, Size: {2}, Buffer Position: {1}, Timestamp: {3:G}]\r\n", (object) num++, (object) packet.Offset, (object) packet.Length, (object) packet.Time, (object) this._buffer[packet.Offset]));
          for (int index2 = 0; index2 < packet.Length; ++index2)
          {
            stringBuilder.Append(this._buffer[packet.Offset + index2].ToString("X2") + " ");
            if (index2 % 16 == 15 && index2 != this._packets.Length - 1)
              stringBuilder.Append("\r\n");
          }
          stringBuilder.Append("\r\n\r\n");
        }
      }
      stringBuilder.Append(reason);
      Directory.CreateDirectory(Path.Combine(Main.SavePath, "NetDump"));
      File.WriteAllText(Path.Combine(Main.SavePath, "NetDump", this.CreateDumpFileName()), stringBuilder.ToString());
    }

    private string CreateDumpFileName()
    {
      DateTime localTime = DateTime.Now.ToLocalTime();
      return string.Format("Net_{0}_{1}_{2}_{3}.txt", (object) "Terraria", (object) Main.versionNumber, (object) localTime.ToString("MM-dd-yy_HH-mm-ss-ffff", (IFormatProvider) CultureInfo.InvariantCulture), (object) Thread.CurrentThread.ManagedThreadId);
    }

    [Conditional("DEBUG")]
    private void InitializeBuffer(int historySize, int bufferSize)
    {
      this._packets = new PacketHistory.PacketView[historySize];
      this._buffer = new byte[bufferSize];
    }

    private struct PacketView
    {
      public static readonly PacketHistory.PacketView Empty = new PacketHistory.PacketView(0, 0, DateTime.Now);
      public readonly int Offset;
      public readonly int Length;
      public readonly DateTime Time;

      public PacketView(int offset, int length, DateTime time)
      {
        this.Offset = offset;
        this.Length = length;
        this.Time = time;
      }
    }
  }
}
