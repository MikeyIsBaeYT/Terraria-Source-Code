// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.IPCMessage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Social.WeGame
{
  public class IPCMessage
  {
    private IPCMessageType _cmd;
    private string _jsonData;

    public void Build<T>(IPCMessageType cmd, T t)
    {
      this._jsonData = WeGameHelper.Serialize<T>(t);
      this._cmd = cmd;
    }

    public void BuildFrom(byte[] data)
    {
      byte[] array1 = ((IEnumerable<byte>) data).Take<byte>(4).ToArray<byte>();
      byte[] array2 = ((IEnumerable<byte>) data).Skip<byte>(4).ToArray<byte>();
      this._cmd = (IPCMessageType) BitConverter.ToInt32(array1, 0);
      this._jsonData = Encoding.UTF8.GetString(array2);
    }

    public void Parse<T>(out T value) => WeGameHelper.UnSerialize<T>(this._jsonData, out value);

    public byte[] GetBytes()
    {
      List<byte> byteList = new List<byte>();
      byteList.AddRange((IEnumerable<byte>) BitConverter.GetBytes((int) this._cmd));
      byteList.AddRange((IEnumerable<byte>) Encoding.UTF8.GetBytes(this._jsonData));
      return byteList.ToArray();
    }

    public IPCMessageType GetCmd() => this._cmd;
  }
}
