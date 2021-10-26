// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.MessageDispatcherServer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.Social.WeGame
{
  public class MessageDispatcherServer
  {
    private IPCServer _ipcSever = new IPCServer();

    public event Action OnIPCClientAccess;

    public event Action<IPCMessage> OnMessage;

    public void Init(string serverName)
    {
      this._ipcSever.Init(serverName);
      this._ipcSever.OnDataArrive += new Action<byte[]>(this.OnDataArrive);
      this._ipcSever.OnClientAccess += new Action(this.OnClientAccess);
    }

    public void OnClientAccess()
    {
      if (this.OnIPCClientAccess == null)
        return;
      this.OnIPCClientAccess();
    }

    public void Start() => this._ipcSever.StartListen();

    private void OnDataArrive(byte[] data)
    {
      IPCMessage ipcMessage = new IPCMessage();
      ipcMessage.BuildFrom(data);
      if (this.OnMessage == null)
        return;
      this.OnMessage(ipcMessage);
    }

    public void Tick() => this._ipcSever.Tick();

    public bool SendMessage(IPCMessage msg) => this._ipcSever.Send(msg.GetBytes());
  }
}
