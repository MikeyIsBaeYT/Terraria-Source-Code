// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat
{
  public static class ChatHelper
  {
    private static List<Tuple<string, Color>> _cachedMessages = new List<Tuple<string, Color>>();

    public static void DisplayMessageOnClient(NetworkText text, Color color, int playerId) => ChatHelper.DisplayMessage(text, color, byte.MaxValue);

    public static void SendChatMessageToClient(NetworkText text, Color color, int playerId) => ChatHelper.SendChatMessageToClientAs(byte.MaxValue, text, color, playerId);

    public static void SendChatMessageToClientAs(
      byte messageAuthor,
      NetworkText text,
      Color color,
      int playerId)
    {
      if (playerId != Main.myPlayer)
        return;
      ChatHelper.DisplayMessage(text, color, messageAuthor);
    }

    public static void BroadcastChatMessage(NetworkText text, Color color, int excludedPlayer = -1) => ChatHelper.BroadcastChatMessageAs(byte.MaxValue, text, color, excludedPlayer);

    public static void BroadcastChatMessageAs(
      byte messageAuthor,
      NetworkText text,
      Color color,
      int excludedPlayer = -1)
    {
      if (excludedPlayer == Main.myPlayer)
        return;
      ChatHelper.DisplayMessage(text, color, messageAuthor);
    }

    public static bool OnlySendToPlayersWhoAreLoggedIn(int clientIndex) => Netplay.Clients[clientIndex].State == 10;

    public static void SendChatMessageFromClient(ChatMessage message)
    {
      if (message.IsConsumed)
        return;
      NetPacket packet = NetTextModule.SerializeClientMessage(message);
      NetManager.Instance.SendToServer(packet);
    }

    public static void DisplayMessage(NetworkText text, Color color, byte messageAuthor)
    {
      string str = text.ToString();
      if (messageAuthor < byte.MaxValue)
      {
        Main.player[(int) messageAuthor].chatOverhead.NewMessage(str, Main.PlayerOverheadChatMessageDisplayTime);
        Main.player[(int) messageAuthor].chatOverhead.color = color;
        str = NameTagHandler.GenerateTag(Main.player[(int) messageAuthor].name) + " " + str;
      }
      if (ChatHelper.ShouldCacheMessage())
        ChatHelper.CacheMessage(str, color);
      else
        Main.NewTextMultiline(str, c: color);
    }

    private static void CacheMessage(string message, Color color) => ChatHelper._cachedMessages.Add(new Tuple<string, Color>(message, color));

    public static void ShowCachedMessages()
    {
      lock (ChatHelper._cachedMessages)
      {
        foreach (Tuple<string, Color> cachedMessage in ChatHelper._cachedMessages)
          Main.NewTextMultiline(cachedMessage.Item1, c: cachedMessage.Item2);
      }
    }

    public static void ClearDelayedMessagesCache() => ChatHelper._cachedMessages.Clear();

    private static bool ShouldCacheMessage() => Main.netMode == 1 && Main.gameMenu;
  }
}
