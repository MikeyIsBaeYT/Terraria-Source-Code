// Decompiled with JetBrains decompiler
// Type: Terraria.Net.TcpAddress
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Net;

namespace Terraria.Net
{
  public class TcpAddress : RemoteAddress
  {
    public IPAddress Address;
    public int Port;

    public TcpAddress(IPAddress address, int port)
    {
      this.Type = AddressType.Tcp;
      this.Address = address;
      this.Port = port;
    }

    public override string GetIdentifier() => this.Address.ToString();

    public override bool IsLocalHost() => this.Address.Equals((object) IPAddress.Loopback);

    public override string ToString() => new IPEndPoint(this.Address, this.Port).ToString();

    public override string GetFriendlyName() => this.ToString();
  }
}
