// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatMessage
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
  public sealed class ChatMessage
  {
    public ChatCommandId CommandId { get; private set; }

    public string Text { get; set; }

    public bool IsConsumed { get; private set; }

    public ChatMessage(string message)
    {
      this.CommandId = ChatCommandId.FromType<SayChatCommand>();
      this.Text = message;
      this.IsConsumed = false;
    }

    private ChatMessage(string message, ChatCommandId commandId)
    {
      this.CommandId = commandId;
      this.Text = message;
    }

    public void Serialize(BinaryWriter writer)
    {
      if (this.IsConsumed)
        throw new InvalidOperationException("Message has already been consumed.");
      this.CommandId.Serialize(writer);
      writer.Write(this.Text);
    }

    public int GetMaxSerializedSize()
    {
      if (this.IsConsumed)
        throw new InvalidOperationException("Message has already been consumed.");
      return 0 + this.CommandId.GetMaxSerializedSize() + (4 + Encoding.UTF8.GetByteCount(this.Text));
    }

    public static ChatMessage Deserialize(BinaryReader reader)
    {
      ChatCommandId commandId = ChatCommandId.Deserialize(reader);
      return new ChatMessage(reader.ReadString(), commandId);
    }

    public void SetCommand(ChatCommandId commandId)
    {
      if (this.IsConsumed)
        throw new InvalidOperationException("Message has already been consumed.");
      this.CommandId = commandId;
    }

    public void SetCommand<T>() where T : IChatCommand
    {
      if (this.IsConsumed)
        throw new InvalidOperationException("Message has already been consumed.");
      this.CommandId = ChatCommandId.FromType<T>();
    }

    public void Consume() => this.IsConsumed = true;
  }
}
