// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatCommandProcessor
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Chat.Commands;
using Terraria.Localization;

namespace Terraria.Chat
{
  public class ChatCommandProcessor : IChatProcessor
  {
    private Dictionary<LocalizedText, ChatCommandId> _localizedCommands = new Dictionary<LocalizedText, ChatCommandId>();
    private Dictionary<ChatCommandId, IChatCommand> _commands = new Dictionary<ChatCommandId, IChatCommand>();
    private IChatCommand _defaultCommand;

    public ChatCommandProcessor AddCommand<T>() where T : IChatCommand, new()
    {
      string commandKey = "ChatCommand." + AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>().Name;
      ChatCommandId key1 = ChatCommandId.FromType<T>();
      this._commands[key1] = (IChatCommand) new T();
      if (Language.Exists(commandKey))
      {
        this._localizedCommands.Add(Language.GetText(commandKey), key1);
      }
      else
      {
        commandKey += "_";
        foreach (LocalizedText key2 in Language.FindAll((LanguageSearchFilter) ((key, text) => key.StartsWith(commandKey))))
          this._localizedCommands.Add(key2, key1);
      }
      return this;
    }

    public ChatCommandProcessor AddDefaultCommand<T>() where T : IChatCommand, new()
    {
      this.AddCommand<T>();
      this._defaultCommand = this._commands[ChatCommandId.FromType<T>()];
      return this;
    }

    private static bool HasLocalizedCommand(ChatMessage message, LocalizedText command)
    {
      string lower = message.Text.ToLower();
      string str = command.Value;
      if (!lower.StartsWith(str))
        return false;
      return lower.Length == str.Length || lower[str.Length] == ' ';
    }

    private static string RemoveCommandPrefix(string messageText, LocalizedText command)
    {
      string str = command.Value;
      return !messageText.StartsWith(str) || messageText.Length == str.Length || messageText[str.Length] != ' ' ? "" : messageText.Substring(str.Length + 1);
    }

    public bool ProcessOutgoingMessage(ChatMessage message)
    {
      KeyValuePair<LocalizedText, ChatCommandId> keyValuePair = this._localizedCommands.FirstOrDefault<KeyValuePair<LocalizedText, ChatCommandId>>((Func<KeyValuePair<LocalizedText, ChatCommandId>, bool>) (pair => ChatCommandProcessor.HasLocalizedCommand(message, pair.Key)));
      ChatCommandId commandId = keyValuePair.Value;
      if (keyValuePair.Key == null)
        return false;
      message.SetCommand(commandId);
      message.Text = ChatCommandProcessor.RemoveCommandPrefix(message.Text, keyValuePair.Key);
      return true;
    }

    public bool ProcessReceivedMessage(ChatMessage message, int clientId)
    {
      IChatCommand chatCommand;
      if (this._commands.TryGetValue(message.CommandId, out chatCommand))
      {
        chatCommand.ProcessMessage(message.Text, (byte) clientId);
        return true;
      }
      if (this._defaultCommand == null)
        return false;
      this._defaultCommand.ProcessMessage(message.Text, (byte) clientId);
      return true;
    }
  }
}
