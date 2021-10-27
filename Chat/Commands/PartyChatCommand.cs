// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.PartyChatCommand
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Party")]
  public class PartyChatCommand : IChatCommand
  {
    private static readonly Color ERROR_COLOR = new Color((int) byte.MaxValue, 240, 20);

    public void ProcessMessage(string text, byte clientId)
    {
      int team = Main.player[(int) clientId].team;
      Color color = Main.teamColor[team];
      if (team == 0)
      {
        this.SendNoTeamError(clientId);
      }
      else
      {
        if (text == "")
          return;
        for (int playerId = 0; playerId < (int) byte.MaxValue; ++playerId)
        {
          if (Main.player[playerId].team == team)
          {
            NetPacket packet = NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(text), color, clientId);
            NetManager.Instance.SendToClient(packet, playerId);
          }
        }
      }
    }

    private void SendNoTeamError(byte clientId)
    {
      NetPacket packet = NetTextModule.SerializeServerMessage(Lang.mp[10].ToNetworkText(), PartyChatCommand.ERROR_COLOR);
      NetManager.Instance.SendToClient(packet, (int) clientId);
    }
  }
}
