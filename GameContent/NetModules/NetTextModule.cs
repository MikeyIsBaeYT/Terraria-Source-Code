// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetTextModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.IO;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI.Chat;

namespace Terraria.GameContent.NetModules
{
  public class NetTextModule : NetModule
  {
    public static NetPacket SerializeClientMessage(ChatMessage message)
    {
      NetPacket packet = NetModule.CreatePacket<NetTextModule>(message.GetMaxSerializedSize());
      message.Serialize(packet.Writer);
      return packet;
    }

    public static NetPacket SerializeServerMessage(NetworkText text, Color color) => NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);

    public static NetPacket SerializeServerMessage(
      NetworkText text,
      Color color,
      byte authorId)
    {
      NetPacket packet = NetModule.CreatePacket<NetTextModule>(1 + text.GetMaxSerializedSize() + 3);
      packet.Writer.Write(authorId);
      text.Serialize(packet.Writer);
      packet.Writer.WriteRGB(color);
      return packet;
    }

    private bool DeserializeAsClient(BinaryReader reader, int senderPlayerId)
    {
      byte messageAuthor = reader.ReadByte();
      ChatHelper.DisplayMessage(NetworkText.Deserialize(reader), reader.ReadRGB(), messageAuthor);
      return true;
    }

    private bool DeserializeAsServer(BinaryReader reader, int senderPlayerId)
    {
      ChatMessage message = ChatMessage.Deserialize(reader);
      ChatManager.Commands.ProcessIncomingMessage(message, senderPlayerId);
      return true;
    }

    public override bool Deserialize(BinaryReader reader, int senderPlayerId) => this.DeserializeAsClient(reader, senderPlayerId);
  }
}
