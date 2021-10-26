// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatCommandId
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.Utilities;
using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
  public struct ChatCommandId
  {
    private readonly string _name;

    private ChatCommandId(string name) => this._name = name;

    public static ChatCommandId FromType<T>() where T : IChatCommand
    {
      ChatCommandAttribute cacheableAttribute = AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>();
      return cacheableAttribute != null ? new ChatCommandId(cacheableAttribute.Name) : new ChatCommandId((string) null);
    }

    public void Serialize(BinaryWriter writer) => writer.Write(this._name ?? "");

    public static ChatCommandId Deserialize(BinaryReader reader) => new ChatCommandId(reader.ReadString());

    public int GetMaxSerializedSize() => 4 + Encoding.UTF8.GetByteCount(this._name ?? "");
  }
}
