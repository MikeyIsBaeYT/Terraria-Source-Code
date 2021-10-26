// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.Lobby
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;
using System;

namespace Terraria.Social.WeGame
{
  public class Lobby
  {
    private RailCallBackHelper _callbackHelper = new RailCallBackHelper();
    public LobbyState State;
    private bool _gameServerInitSuccess;
    private IRailGameServer _gameServer;
    public Action<RailID> _lobbyCreatedExternalCallback;
    private RailID _server_id;

    private IRailGameServer RailServerHelper
    {
      get => this._gameServerInitSuccess ? this._gameServer : (IRailGameServer) null;
      set => this._gameServer = value;
    }

    private IRailGameServerHelper GetRailServerHelper() => rail_api.RailFactory().RailGameServerHelper();

    private void RegisterGameServerEvent()
    {
      if (this._callbackHelper == null)
        return;
      // ISSUE: method pointer
      this._callbackHelper.RegisterCallback((RAILEventID) 3002, new RailEventCallBackHandler((object) this, __methodptr(OnRailEvent)));
    }

    public void OnRailEvent(RAILEventID id, EventBase data)
    {
      WeGameHelper.WriteDebugString("OnRailEvent,id=" + id.ToString() + " ,result=" + data.result.ToString());
      if (id != 3002)
        return;
      this.OnGameServerCreated((CreateGameServerResult) data);
    }

    private void OnGameServerCreated(CreateGameServerResult result)
    {
      if (((EventBase) result).result != null)
        return;
      this._gameServerInitSuccess = true;
      this._lobbyCreatedExternalCallback((RailID) result.game_server_id);
      this._server_id = (RailID) result.game_server_id;
    }

    public void Create(bool inviteOnly)
    {
      if (this.State == LobbyState.Inactive)
        this.RegisterGameServerEvent();
      this.RailServerHelper = rail_api.RailFactory().RailGameServerHelper().AsyncCreateGameServer(new CreateGameServerOptions()
      {
        has_password = (__Null) 0,
        enable_team_voice = (__Null) 0
      }, "terraria", "terraria");
      this.State = LobbyState.Creating;
    }

    public void OpenInviteOverlay()
    {
      WeGameHelper.WriteDebugString("OpenInviteOverlay by wegame");
      rail_api.RailFactory().RailFloatingWindow().AsyncShowRailFloatingWindow((EnumRailWindowType) 10, "");
    }

    public void Join(RailID local_peer, RailID remote_peer)
    {
      if (this.State != LobbyState.Inactive)
        WeGameHelper.WriteDebugString("Lobby connection attempted while already in a lobby. This should never happen?");
      else
        this.State = LobbyState.Connecting;
    }

    public byte[] GetMessage(int index) => (byte[]) null;

    public int GetUserCount() => 0;

    public RailID GetUserByIndex(int index) => (RailID) null;

    public bool SendMessage(byte[] data) => this.SendMessage(data, data.Length);

    public bool SendMessage(byte[] data, int length) => false;

    public void Set(RailID lobbyId)
    {
    }

    public void SetPlayedWith(RailID userId)
    {
    }

    public void Leave() => this.State = LobbyState.Inactive;

    public IRailGameServer GetServer() => this.RailServerHelper;
  }
}
