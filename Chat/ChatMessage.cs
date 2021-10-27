// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatMessage
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
  public class ChatMessage
  {
    public ChatCommandId CommandId { get; private set; }

    public string Text { get; set; }

    public ChatMessage(string message)
    {
      this.CommandId = ChatCommandId.FromType<SayChatCommand>();
      this.Text = message;
    }

    private ChatMessage(string message, ChatCommandId commandId)
    {
      this.CommandId = commandId;
      this.Text = message;
    }

    public void Serialize(BinaryWriter writer)
    {
      this.CommandId.Serialize(writer);
      writer.Write(this.Text);
    }

    public int GetMaxSerializedSize() => 0 + this.CommandId.GetMaxSerializedSize() + (4 + Encoding.UTF8.GetByteCount(this.Text));

    public static ChatMessage Deserialize(BinaryReader reader)
    {
      ChatCommandId commandId = ChatCommandId.Deserialize(reader);
      return new ChatMessage(reader.ReadString(), commandId);
    }

    public void SetCommand(ChatCommandId commandId) => this.CommandId = commandId;

    public void SetCommand<T>() where T : IChatCommand => this.CommandId = ChatCommandId.FromType<T>();
  }
}
