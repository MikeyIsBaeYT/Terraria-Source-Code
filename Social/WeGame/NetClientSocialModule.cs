// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.NetClientSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.WeGame
{
  public class NetClientSocialModule : NetSocialModule
  {
    private RailCallBackHelper _callbackHelper = new RailCallBackHelper();
    private bool _hasLocalHost;
    private IPCServer server = new IPCServer();
    private readonly string _serverIDMedataKey = "terraria.serverid";
    private RailID _inviter_id = new RailID();
    private List<PlayerPersonalInfo> _player_info_list;
    private MessageDispatcherServer _msgServer;

    private void OnIPCClientAccess()
    {
      WeGameHelper.WriteDebugString("IPC client access");
      this.SendFriendListToLocalServer();
    }

    private void LazyCreateWeGameMsgServer()
    {
      if (this._msgServer != null)
        return;
      this._msgServer = new MessageDispatcherServer();
      this._msgServer.Init("WeGame.Terraria.Message.Server");
      this._msgServer.OnMessage += new Action<IPCMessage>(this.OnWegameMessage);
      this._msgServer.OnIPCClientAccess += new Action(this.OnIPCClientAccess);
      CoreSocialModule.OnTick += new Action(this._msgServer.Tick);
      this._msgServer.Start();
    }

    private void OnWegameMessage(IPCMessage message)
    {
      if (message.GetCmd() != IPCMessageType.IPCMessageTypeReportServerID)
        return;
      ReportServerID reportServerID;
      message.Parse<ReportServerID>(out reportServerID);
      this.OnReportServerID(reportServerID);
    }

    private void OnReportServerID(ReportServerID reportServerID)
    {
      WeGameHelper.WriteDebugString("OnReportServerID - " + reportServerID._serverID);
      this.AsyncSetMyMetaData(this._serverIDMedataKey, reportServerID._serverID);
      this.AsyncSetInviteCommandLine(reportServerID._serverID);
    }

    public override void Initialize()
    {
      base.Initialize();
      this.RegisterRailEvent();
      this.AsyncGetFriendsInfo();
      this._reader.SetReadEvent(new WeGameP2PReader.OnReadEvent(this.OnPacketRead));
      this._reader.SetLocalPeer(this.GetLocalPeer());
      this._writer.SetLocalPeer(this.GetLocalPeer());
      Main.OnEngineLoad += new Action(this.CheckParameters);
    }

    private void AsyncSetInviteCommandLine(string cmdline) => rail_api.RailFactory().RailFriends().AsyncSetInviteCommandLine(cmdline, "");

    private void AsyncSetMyMetaData(string key, string value)
    {
      List<RailKeyValue> railKeyValueList = new List<RailKeyValue>();
      railKeyValueList.Add(new RailKeyValue()
      {
        key = (__Null) key,
        value = (__Null) value
      });
      rail_api.RailFactory().RailFriends().AsyncSetMyMetadata(railKeyValueList, "");
    }

    private bool TryAuthUserByRecvData(RailID user, byte[] data, int length)
    {
      WeGameHelper.WriteDebugString("TryAuthUserByRecvData user:{0}", (object) (ulong) ((RailComparableID) user).id_);
      if (length < 3)
      {
        WeGameHelper.WriteDebugString("Failed to validate authentication packet: Too short. (Length: " + (object) length + ")");
        return false;
      }
      int num = (int) data[1] << 8 | (int) data[0];
      if (num != length)
      {
        WeGameHelper.WriteDebugString("Failed to validate authentication packet: Packet size mismatch. (" + (object) num + "!=" + (object) length + ")");
        return false;
      }
      if (data[2] == (byte) 93)
        return true;
      WeGameHelper.WriteDebugString("Failed to validate authentication packet: Packet type is not correct. (Type: " + (object) data[2] + ")");
      return false;
    }

    private bool OnPacketRead(byte[] data, int size, RailID user)
    {
      if (!this._connectionStateMap.ContainsKey(user))
        return false;
      NetSocialModule.ConnectionState connectionState = this._connectionStateMap[user];
      if (connectionState != NetSocialModule.ConnectionState.Authenticating)
        return connectionState == NetSocialModule.ConnectionState.Connected;
      if (!this.TryAuthUserByRecvData(user, data, size))
      {
        WeGameHelper.WriteDebugString(" Auth Server Ticket Failed");
        this.Close(user);
      }
      else
      {
        WeGameHelper.WriteDebugString("OnRailAuthSessionTicket Auth Success..");
        this.OnAuthSuccess(user);
      }
      return false;
    }

    private void OnAuthSuccess(RailID remote_peer)
    {
      if (!this._connectionStateMap.ContainsKey(remote_peer))
        return;
      this._connectionStateMap[remote_peer] = NetSocialModule.ConnectionState.Connected;
      this.AsyncSetPlayWith(this._inviter_id);
      this.AsyncSetMyMetaData("status", Language.GetTextValue("Social.StatusInGame"));
      // ISSUE: explicit non-virtual call
      this.AsyncSetMyMetaData(this._serverIDMedataKey, __nonvirtual (((RailComparableID) remote_peer).id_.ToString()));
      Main.clrInput();
      Netplay.ServerPassword = "";
      Main.GetInputText("");
      Main.autoPass = false;
      Main.netMode = 1;
      Netplay.OnConnectedToSocialServer((ISocket) new SocialSocket((RemoteAddress) new WeGameAddress(remote_peer, this.GetFriendNickname(this._inviter_id))));
      // ISSUE: explicit non-virtual call
      WeGameHelper.WriteDebugString("OnConnectToSocialServer server:" + __nonvirtual (((RailComparableID) remote_peer).id_.ToString()));
    }

    private bool GetRailConnectIDFromCmdLine(RailID server_id)
    {
      foreach (string commandLineArg in Environment.GetCommandLineArgs())
      {
        string str = "--rail_connect_cmd=";
        int num = commandLineArg.IndexOf(str);
        if (num != -1)
        {
          ulong result = 0;
          if (ulong.TryParse(commandLineArg.Substring(num + str.Length), out result))
          {
            ((RailComparableID) server_id).id_ = (__Null) (long) result;
            return true;
          }
        }
      }
      return false;
    }

    private void CheckParameters()
    {
      RailID server_id = new RailID();
      if (!this.GetRailConnectIDFromCmdLine(server_id))
        return;
      if (((RailComparableID) server_id).IsValid())
        Main.OpenPlayerSelect((Main.OnPlayerSelected) (playerData =>
        {
          Main.ServerSideCharacter = false;
          playerData.SetAsActive();
          Main.menuMode = 882;
          Main.statusText = Language.GetTextValue("Social.Joining");
          WeGameHelper.WriteDebugString(" CheckParameters， lobby.join");
          this.JoinServer(server_id);
        }));
      else
        WeGameHelper.WriteDebugString("Invalid RailID passed to +connect_lobby");
    }

    public override void LaunchLocalServer(Process process, ServerMode mode)
    {
      if (this._lobby.State != LobbyState.Inactive)
        this._lobby.Leave();
      this.LazyCreateWeGameMsgServer();
      ProcessStartInfo startInfo1 = process.StartInfo;
      startInfo1.Arguments = startInfo1.Arguments + " -wegame -localwegameid " + (object) (ulong) ((RailComparableID) this.GetLocalPeer()).id_;
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
      string str;
      rail_api.RailFactory().RailUtils().GetLaunchAppParameters((EnumRailLaunchAppType) 2, ref str);
      ProcessStartInfo startInfo2 = process.StartInfo;
      startInfo2.Arguments = startInfo2.Arguments + " " + str;
      WeGameHelper.WriteDebugString("LaunchLocalServer,cmd_line:" + process.StartInfo.Arguments);
      this.AsyncSetMyMetaData("status", Language.GetTextValue("Social.StatusInGame"));
      Netplay.OnDisconnect += new Action(this.OnDisconnect);
      process.Start();
    }

    public override void Shutdown()
    {
      this.AsyncSetInviteCommandLine("");
      this.CleanMyMetaData();
      this.UnRegisterRailEvent();
      base.Shutdown();
    }

    public override ulong GetLobbyId() => 0;

    public override bool StartListening(SocketConnectionAccepted callback) => false;

    public override void StopListening()
    {
    }

    public override void Close(RemoteAddress address)
    {
      this.CleanMyMetaData();
      this.Close(this.RemoteAddressToRailId(address));
    }

    public override bool CanInvite() => (this._hasLocalHost || this._lobby.State == LobbyState.Active || Main.LobbyId != 0UL) && (uint) Main.netMode > 0U;

    public override void OpenInviteInterface() => this._lobby.OpenInviteOverlay();

    private void Close(RailID remote_peer)
    {
      if (!this._connectionStateMap.ContainsKey(remote_peer))
        return;
      WeGameHelper.WriteDebugString("CloseRemotePeer, remote:{0}", (object) (ulong) ((RailComparableID) remote_peer).id_);
      rail_api.RailFactory().RailNetworkHelper().CloseSession(this.GetLocalPeer(), remote_peer);
      this._connectionStateMap[remote_peer] = NetSocialModule.ConnectionState.Inactive;
      this._lobby.Leave();
      this._reader.ClearUser(remote_peer);
      this._writer.ClearUser(remote_peer);
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

    private void RegisterRailEvent()
    {
      RAILEventID[] railEventIdArray = new RAILEventID[7]
      {
        (RAILEventID) 16001,
        (RAILEventID) 16002,
        (RAILEventID) 13503,
        (RAILEventID) 13501,
        (RAILEventID) 12003,
        (RAILEventID) 12002,
        (RAILEventID) 12010
      };
      foreach (int num in railEventIdArray)
      {
        // ISSUE: method pointer
        this._callbackHelper.RegisterCallback((RAILEventID) num, new RailEventCallBackHandler((object) this, __methodptr(OnRailEvent)));
      }
    }

    private void UnRegisterRailEvent() => this._callbackHelper.UnregisterAllCallback();

    public void OnRailEvent(RAILEventID id, EventBase data)
    {
      WeGameHelper.WriteDebugString("OnRailEvent,id=" + id.ToString() + " ,result=" + data.result.ToString());
      if (id <= 12010)
      {
        if (id != 12002)
        {
          if (id != 12003)
          {
            if (id != 12010)
              return;
            this.OnFriendlistChange((RailFriendsListChanged) data);
          }
          else
            this.OnGetFriendMetaData((RailFriendsGetMetadataResult) data);
        }
        else
          this.OnRailSetMetaData((RailFriendsSetMetadataResult) data);
      }
      else if (id <= 13503)
      {
        if (id != 13501)
        {
          if (id != 13503)
            return;
          this.OnRailRespondInvation((RailUsersRespondInvitation) data);
        }
        else
          this.OnRailGetUsersInfo((RailUsersInfoData) data);
      }
      else if (id != 16001)
      {
        if (id != 16002)
          return;
        this.OnRailCreateSessionFailed((CreateSessionFailed) data);
      }
      else
        this.OnRailCreateSessionRequest((CreateSessionRequest) data);
    }

    private string DumpMataDataString(List<RailKeyValueResult> list)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RailKeyValueResult railKeyValueResult in list)
        stringBuilder.Append("key: " + (string) railKeyValueResult.key + " value: " + (string) railKeyValueResult.value);
      return stringBuilder.ToString();
    }

    private string GetValueByKey(string key, List<RailKeyValueResult> list)
    {
      string str = (string) null;
      foreach (RailKeyValueResult railKeyValueResult in list)
      {
        if ((string) railKeyValueResult.key == key)
        {
          str = (string) railKeyValueResult.value;
          break;
        }
      }
      return str;
    }

    private bool SendFriendListToLocalServer()
    {
      bool flag = false;
      if (this._hasLocalHost)
      {
        List<RailFriendInfo> list = new List<RailFriendInfo>();
        if (this.GetRailFriendList(list))
        {
          WeGameFriendListInfo t = new WeGameFriendListInfo()
          {
            _friendList = list
          };
          IPCMessage msg = new IPCMessage();
          msg.Build<WeGameFriendListInfo>(IPCMessageType.IPCMessageTypeNotifyFriendList, t);
          flag = this._msgServer.SendMessage(msg);
          WeGameHelper.WriteDebugString("NotifyFriendListToServer: " + flag.ToString());
        }
      }
      return flag;
    }

    private bool GetRailFriendList(List<RailFriendInfo> list)
    {
      bool flag = false;
      IRailFriends irailFriends = rail_api.RailFactory().RailFriends();
      if (irailFriends != null)
        flag = irailFriends.GetFriendsList(list) == 0;
      return flag;
    }

    private void OnGetFriendMetaData(RailFriendsGetMetadataResult data)
    {
      if (((EventBase) data).result != null || ((List<RailKeyValueResult>) data.friend_kvs).Count <= 0)
        return;
      WeGameHelper.WriteDebugString("OnGetFriendMetaData - " + this.DumpMataDataString((List<RailKeyValueResult>) data.friend_kvs));
      string valueByKey = this.GetValueByKey(this._serverIDMedataKey, (List<RailKeyValueResult>) data.friend_kvs);
      if (valueByKey == null)
        return;
      if (valueByKey.Length > 0)
      {
        RailID server_id = new RailID();
        ((RailComparableID) server_id).id_ = (__Null) (long) ulong.Parse(valueByKey);
        if (((RailComparableID) server_id).IsValid())
          this.JoinServer(server_id);
        else
          WeGameHelper.WriteDebugString("JoinServer failed, invalid server id");
      }
      else
        WeGameHelper.WriteDebugString("can not find server id key");
    }

    private void JoinServer(RailID server_id)
    {
      WeGameHelper.WriteDebugString("JoinServer:{0}", (object) (ulong) ((RailComparableID) server_id).id_);
      this._connectionStateMap[server_id] = NetSocialModule.ConnectionState.Authenticating;
      int length = 3;
      byte[] numArray = new byte[length];
      numArray[0] = (byte) (length & (int) byte.MaxValue);
      numArray[1] = (byte) (length >> 8 & (int) byte.MaxValue);
      numArray[2] = (byte) 93;
      rail_api.RailFactory().RailNetworkHelper().SendReliableData(this.GetLocalPeer(), server_id, numArray, (uint) length);
    }

    private string GetFriendNickname(RailID rail_id)
    {
      if (this._player_info_list != null)
      {
        foreach (PlayerPersonalInfo playerInfo in this._player_info_list)
        {
          if (RailComparableID.op_Equality((RailComparableID) playerInfo.rail_id, (RailComparableID) rail_id))
            return (string) playerInfo.rail_name;
        }
      }
      return "";
    }

    private void OnRailGetUsersInfo(RailUsersInfoData data) => this._player_info_list = (List<PlayerPersonalInfo>) data.user_info_list;

    private void OnFriendlistChange(RailFriendsListChanged data)
    {
      if (!this._hasLocalHost)
        return;
      this.SendFriendListToLocalServer();
    }

    private void AsyncGetFriendsInfo()
    {
      IRailFriends irailFriends = rail_api.RailFactory().RailFriends();
      if (irailFriends == null)
        return;
      List<RailFriendInfo> railFriendInfoList = new List<RailFriendInfo>();
      irailFriends.GetFriendsList(railFriendInfoList);
      List<RailID> railIdList = new List<RailID>();
      foreach (RailFriendInfo railFriendInfo in railFriendInfoList)
        railIdList.Add((RailID) railFriendInfo.friend_rail_id);
      irailFriends.AsyncGetPersonalInfo(railIdList, "");
    }

    private void AsyncSetPlayWith(RailID rail_id)
    {
      List<RailUserPlayedWith> railUserPlayedWithList = new List<RailUserPlayedWith>();
      railUserPlayedWithList.Add(new RailUserPlayedWith()
      {
        rail_id = (__Null) rail_id
      });
      rail_api.RailFactory().RailFriends()?.AsyncReportPlayedWithUserList(railUserPlayedWithList, "");
    }

    private void OnRailSetMetaData(RailFriendsSetMetadataResult data) => WeGameHelper.WriteDebugString("OnRailSetMetaData - " + ((EventBase) data).result.ToString());

    private void OnRailRespondInvation(RailUsersRespondInvitation data)
    {
      WeGameHelper.WriteDebugString(" request join game");
      if (this._lobby.State != LobbyState.Inactive)
        this._lobby.Leave();
      this._inviter_id = (RailID) data.inviter_id;
      Main.OpenPlayerSelect((Main.OnPlayerSelected) (playerData =>
      {
        Main.ServerSideCharacter = false;
        playerData.SetAsActive();
        Main.menuMode = 882;
        Main.statusText = Language.GetTextValue("Social.JoiningFriend", (object) this.GetFriendNickname((RailID) data.inviter_id));
        this.AsyncGetServerIDByOwener((RailID) data.inviter_id);
        WeGameHelper.WriteDebugString("inviter_id: " + (object) (ulong) ((RailComparableID) data.inviter_id).id_);
      }));
    }

    private void AsyncGetServerIDByOwener(RailID ownerID) => rail_api.RailFactory().RailFriends()?.AsyncGetFriendMetadata(ownerID, new List<string>()
    {
      this._serverIDMedataKey
    }, "");

    private void OnRailCreateSessionRequest(CreateSessionRequest result)
    {
      WeGameHelper.WriteDebugString(nameof (OnRailCreateSessionRequest));
      if (!this._connectionStateMap.ContainsKey((RailID) result.remote_peer) || this._connectionStateMap[(RailID) result.remote_peer] == NetSocialModule.ConnectionState.Inactive)
        return;
      WeGameHelper.WriteDebugString("AcceptSessionRequest, local{0}, remote:{1}", (object) (ulong) ((RailComparableID) result.local_peer).id_, (object) (ulong) ((RailComparableID) result.remote_peer).id_);
      rail_api.RailFactory().RailNetworkHelper().AcceptSessionRequest((RailID) result.local_peer, (RailID) result.remote_peer);
    }

    private void OnRailCreateSessionFailed(CreateSessionFailed result)
    {
      WeGameHelper.WriteDebugString("OnRailCreateSessionFailed, CloseRemote: local:{0}, remote:{1}", (object) (ulong) ((RailComparableID) result.local_peer).id_, (object) (ulong) ((RailComparableID) result.remote_peer).id_);
      this.Close((RailID) result.remote_peer);
    }

    private void CleanMyMetaData() => rail_api.RailFactory().RailFriends()?.AsyncClearAllMyMetadata("");

    private void OnDisconnect()
    {
      this.CleanMyMetaData();
      this._hasLocalHost = false;
      Netplay.OnDisconnect -= new Action(this.OnDisconnect);
    }
  }
}
