// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.Lobby
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
  public class Lobby
  {
    private HashSet<CSteamID> _usersSeen = new HashSet<CSteamID>();
    private byte[] _messageBuffer = new byte[1024];
    public CSteamID Id = (CSteamID) CSteamID.Nil;
    public CSteamID Owner = (CSteamID) CSteamID.Nil;
    public LobbyState State;
    private CallResult<LobbyEnter_t> _lobbyEnter;
    private CallResult<LobbyEnter_t>.APIDispatchDelegate _lobbyEnterExternalCallback;
    private CallResult<LobbyCreated_t> _lobbyCreated;
    private CallResult<LobbyCreated_t>.APIDispatchDelegate _lobbyCreatedExternalCallback;

    public Lobby()
    {
      // ISSUE: method pointer
      this._lobbyEnter = CallResult<LobbyEnter_t>.Create(new CallResult<LobbyEnter_t>.APIDispatchDelegate((object) this, __methodptr(OnLobbyEntered)));
      // ISSUE: method pointer
      this._lobbyCreated = CallResult<LobbyCreated_t>.Create(new CallResult<LobbyCreated_t>.APIDispatchDelegate((object) this, __methodptr(OnLobbyCreated)));
    }

    public void Create(
      bool inviteOnly,
      CallResult<LobbyCreated_t>.APIDispatchDelegate callResult)
    {
      SteamAPICall_t lobby = SteamMatchmaking.CreateLobby(inviteOnly ? (ELobbyType) 0 : (ELobbyType) 1, 256);
      this._lobbyCreatedExternalCallback = callResult;
      this._lobbyCreated.Set(lobby, (CallResult<LobbyCreated_t>.APIDispatchDelegate) null);
      this.State = LobbyState.Creating;
    }

    public void OpenInviteOverlay()
    {
      if (this.State == LobbyState.Inactive)
        SteamFriends.ActivateGameOverlayInviteDialog(new CSteamID(Main.LobbyId));
      else
        SteamFriends.ActivateGameOverlayInviteDialog(this.Id);
    }

    public void Join(
      CSteamID lobbyId,
      CallResult<LobbyEnter_t>.APIDispatchDelegate callResult)
    {
      if (this.State != LobbyState.Inactive)
        return;
      this.State = LobbyState.Connecting;
      this._lobbyEnterExternalCallback = callResult;
      this._lobbyEnter.Set(SteamMatchmaking.JoinLobby(lobbyId), (CallResult<LobbyEnter_t>.APIDispatchDelegate) null);
    }

    public byte[] GetMessage(int index)
    {
      CSteamID csteamId;
      EChatEntryType echatEntryType;
      int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry(this.Id, index, ref csteamId, this._messageBuffer, this._messageBuffer.Length, ref echatEntryType);
      byte[] numArray = new byte[lobbyChatEntry];
      Array.Copy((Array) this._messageBuffer, (Array) numArray, lobbyChatEntry);
      return numArray;
    }

    public int GetUserCount() => SteamMatchmaking.GetNumLobbyMembers(this.Id);

    public CSteamID GetUserByIndex(int index) => SteamMatchmaking.GetLobbyMemberByIndex(this.Id, index);

    public bool SendMessage(byte[] data) => this.SendMessage(data, data.Length);

    public bool SendMessage(byte[] data, int length) => this.State == LobbyState.Active && SteamMatchmaking.SendLobbyChatMsg(this.Id, data, length);

    public void Set(CSteamID lobbyId)
    {
      this.Id = lobbyId;
      this.State = LobbyState.Active;
      this.Owner = SteamMatchmaking.GetLobbyOwner(lobbyId);
    }

    public void SetPlayedWith(CSteamID userId)
    {
      if (this._usersSeen.Contains(userId))
        return;
      SteamFriends.SetPlayedWith(userId);
      this._usersSeen.Add(userId);
    }

    public void Leave()
    {
      if (this.State == LobbyState.Active)
        SteamMatchmaking.LeaveLobby(this.Id);
      this.State = LobbyState.Inactive;
      this._usersSeen.Clear();
    }

    private void OnLobbyEntered(LobbyEnter_t result, bool failure)
    {
      if (this.State != LobbyState.Connecting)
        return;
      this.State = !failure ? LobbyState.Active : LobbyState.Inactive;
      this.Id = new CSteamID((ulong) result.m_ulSteamIDLobby);
      this.Owner = SteamMatchmaking.GetLobbyOwner(this.Id);
      this._lobbyEnterExternalCallback.Invoke(result, failure);
    }

    private void OnLobbyCreated(LobbyCreated_t result, bool failure)
    {
      if (this.State != LobbyState.Creating)
        return;
      this.State = !failure ? LobbyState.Active : LobbyState.Inactive;
      this.Id = new CSteamID((ulong) result.m_ulSteamIDLobby);
      this.Owner = SteamMatchmaking.GetLobbyOwner(this.Id);
      this._lobbyCreatedExternalCallback.Invoke(result, failure);
    }
  }
}
