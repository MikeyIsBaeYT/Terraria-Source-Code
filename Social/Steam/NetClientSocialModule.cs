// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.NetClientSocialModule
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Steamworks;
using System;
using System.Diagnostics;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.Steam
{
  public class NetClientSocialModule : NetSocialModule
  {
    private Callback<GameLobbyJoinRequested_t> _gameLobbyJoinRequested;
    private Callback<P2PSessionRequest_t> _p2pSessionRequest;
    private Callback<P2PSessionConnectFail_t> _p2pSessionConnectfail;
    private HAuthTicket _authTicket = (HAuthTicket) HAuthTicket.Invalid;
    private byte[] _authData = new byte[1021];
    private uint _authDataLength;
    private bool _hasLocalHost;

    public NetClientSocialModule()
      : base(2, 1)
    {
    }

    public override void Initialize()
    {
      base.Initialize();
      // ISSUE: method pointer
      this._gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(new Callback<GameLobbyJoinRequested_t>.DispatchDelegate((object) this, __methodptr(OnLobbyJoinRequest)));
      // ISSUE: method pointer
      this._p2pSessionRequest = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate((object) this, __methodptr(OnP2PSessionRequest)));
      // ISSUE: method pointer
      this._p2pSessionConnectfail = Callback<P2PSessionConnectFail_t>.Create(new Callback<P2PSessionConnectFail_t>.DispatchDelegate((object) this, __methodptr(OnSessionConnectFail)));
      Main.OnEngineLoad += new Action(this.CheckParameters);
    }

    private void CheckParameters()
    {
      ulong result;
      if (!Program.LaunchParameters.ContainsKey("+connect_lobby") || !ulong.TryParse(Program.LaunchParameters["+connect_lobby"], out result))
        return;
      CSteamID lobbySteamId = new CSteamID(result);
      if (!((CSteamID) ref lobbySteamId).IsValid())
        return;
      Main.OpenPlayerSelect((Main.OnPlayerSelected) (playerData =>
      {
        Main.ServerSideCharacter = false;
        playerData.SetAsActive();
        Main.menuMode = 882;
        Main.statusText = Language.GetTextValue("Social.Joining");
        // ISSUE: method pointer
        this._lobby.Join(lobbySteamId, new CallResult<LobbyEnter_t>.APIDispatchDelegate((object) this, __methodptr(OnLobbyEntered)));
      }));
    }

    public override void LaunchLocalServer(Process process, ServerMode mode)
    {
      if (this._lobby.State != LobbyState.Inactive)
        this._lobby.Leave();
      ProcessStartInfo startInfo = process.StartInfo;
      startInfo.Arguments = startInfo.Arguments + " -steam -localsteamid " + (object) (ulong) SteamUser.GetSteamID().m_SteamID;
      if (mode.HasFlag((Enum) ServerMode.Lobby))
      {
        this._hasLocalHost = true;
        if (mode.HasFlag((Enum) ServerMode.FriendsCanJoin))
          process.StartInfo.Arguments += " -lobby friends";
        else
          process.StartInfo.Arguments += " -lobby private";
        if (mode.HasFlag((Enum) ServerMode.FriendsOfFriends))
          process.StartInfo.Arguments += " -friendsoffriends";
      }
      SteamFriends.SetRichPresence("status", Language.GetTextValue("Social.StatusInGame"));
      Netplay.OnDisconnect += new Action(this.OnDisconnect);
      process.Start();
    }

    public override ulong GetLobbyId() => 0;

    public override bool StartListening(SocketConnectionAccepted callback) => false;

    public override void StopListening()
    {
    }

    public override void Close(RemoteAddress address)
    {
      SteamFriends.ClearRichPresence();
      this.Close(this.RemoteAddressToSteamId(address));
    }

    public override bool CanInvite() => (this._hasLocalHost || this._lobby.State == LobbyState.Active || Main.LobbyId != 0UL) && (uint) Main.netMode > 0U;

    public override void OpenInviteInterface() => this._lobby.OpenInviteOverlay();

    private void Close(CSteamID user)
    {
      if (!this._connectionStateMap.ContainsKey(user))
        return;
      SteamNetworking.CloseP2PSessionWithUser(user);
      this.ClearAuthTicket();
      this._connectionStateMap[user] = NetSocialModule.ConnectionState.Inactive;
      this._lobby.Leave();
      this._reader.ClearUser(user);
      this._writer.ClearUser(user);
    }

    public override void Connect(RemoteAddress address)
    {
    }

    public override void CancelJoin()
    {
      if (this._lobby.State == LobbyState.Inactive)
        return;
      this._lobby.Leave();
    }

    private void OnLobbyJoinRequest(GameLobbyJoinRequested_t result)
    {
      if (this._lobby.State != LobbyState.Inactive)
        this._lobby.Leave();
      string friendName = SteamFriends.GetFriendPersonaName((CSteamID) result.m_steamIDFriend);
      Main.OpenPlayerSelect((Main.OnPlayerSelected) (playerData =>
      {
        Main.ServerSideCharacter = false;
        playerData.SetAsActive();
        Main.menuMode = 882;
        Main.statusText = Language.GetTextValue("Social.JoiningFriend", (object) friendName);
        // ISSUE: method pointer
        this._lobby.Join((CSteamID) result.m_steamIDLobby, new CallResult<LobbyEnter_t>.APIDispatchDelegate((object) this, __methodptr(OnLobbyEntered)));
      }));
    }

    private void OnLobbyEntered(LobbyEnter_t result, bool failure)
    {
      SteamNetworking.AllowP2PPacketRelay(true);
      this.SendAuthTicket(this._lobby.Owner);
      int num = 0;
      P2PSessionState_t p2PsessionStateT;
      while (SteamNetworking.GetP2PSessionState(this._lobby.Owner, ref p2PsessionStateT) && p2PsessionStateT.m_bConnectionActive != 1)
      {
        switch ((byte) p2PsessionStateT.m_eP2PSessionError)
        {
          case 1:
            this.ClearAuthTicket();
            return;
          case 2:
            this.ClearAuthTicket();
            return;
          case 3:
            this.ClearAuthTicket();
            return;
          case 4:
            if (++num > 5)
            {
              this.ClearAuthTicket();
              return;
            }
            SteamNetworking.CloseP2PSessionWithUser(this._lobby.Owner);
            this.SendAuthTicket(this._lobby.Owner);
            continue;
          case 5:
            this.ClearAuthTicket();
            return;
          default:
            continue;
        }
      }
      this._connectionStateMap[this._lobby.Owner] = NetSocialModule.ConnectionState.Connected;
      SteamFriends.SetPlayedWith(this._lobby.Owner);
      SteamFriends.SetRichPresence("status", Language.GetTextValue("Social.StatusInGame"));
      Main.clrInput();
      Netplay.ServerPassword = "";
      Main.GetInputText("");
      Main.autoPass = false;
      Main.netMode = 1;
      Netplay.OnConnectedToSocialServer((ISocket) new SocialSocket((RemoteAddress) new SteamAddress(this._lobby.Owner)));
    }

    private void SendAuthTicket(CSteamID address)
    {
      if (HAuthTicket.op_Equality(this._authTicket, (HAuthTicket) HAuthTicket.Invalid))
        this._authTicket = SteamUser.GetAuthSessionTicket(this._authData, this._authData.Length, ref this._authDataLength);
      int length = (int) this._authDataLength + 3;
      byte[] numArray = new byte[length];
      numArray[0] = (byte) (length & (int) byte.MaxValue);
      numArray[1] = (byte) (length >> 8 & (int) byte.MaxValue);
      numArray[2] = (byte) 93;
      for (int index = 0; (long) index < (long) this._authDataLength; ++index)
        numArray[index + 3] = this._authData[index];
      SteamNetworking.SendP2PPacket(address, numArray, (uint) length, (EP2PSend) 2, 1);
    }

    private void ClearAuthTicket()
    {
      if (HAuthTicket.op_Inequality(this._authTicket, (HAuthTicket) HAuthTicket.Invalid))
        SteamUser.CancelAuthTicket(this._authTicket);
      this._authTicket = (HAuthTicket) HAuthTicket.Invalid;
      for (int index = 0; index < this._authData.Length; ++index)
        this._authData[index] = (byte) 0;
      this._authDataLength = 0U;
    }

    private void OnDisconnect()
    {
      SteamFriends.ClearRichPresence();
      this._hasLocalHost = false;
      Netplay.OnDisconnect -= new Action(this.OnDisconnect);
    }

    private void OnSessionConnectFail(P2PSessionConnectFail_t result) => this.Close((CSteamID) result.m_steamIDRemote);

    private void OnP2PSessionRequest(P2PSessionRequest_t result)
    {
      CSteamID steamIdRemote = (CSteamID) result.m_steamIDRemote;
      if (!this._connectionStateMap.ContainsKey(steamIdRemote) || this._connectionStateMap[steamIdRemote] == NetSocialModule.ConnectionState.Inactive)
        return;
      SteamNetworking.AcceptP2PSessionWithUser(steamIdRemote);
    }
  }
}
