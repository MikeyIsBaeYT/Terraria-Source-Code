// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.ChatInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Chat.Commands;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.Initializers
{
  public static class ChatInitializer
  {
    public static void Load()
    {
      ChatManager.Register<ColorTagHandler>("c", "color");
      ChatManager.Register<ItemTagHandler>("i", "item");
      ChatManager.Register<NameTagHandler>("n", "name");
      ChatManager.Register<AchievementTagHandler>("a", "achievement");
      ChatManager.Register<GlyphTagHandler>("g", "glyph");
      ChatManager.Commands.AddCommand<PartyChatCommand>().AddCommand<RollCommand>().AddCommand<EmoteCommand>().AddCommand<ListPlayersCommand>().AddCommand<RockPaperScissorsCommand>().AddCommand<EmojiCommand>().AddCommand<HelpCommand>().AddDefaultCommand<SayChatCommand>();
      for (int index = 0; index < 145; ++index)
      {
        string name = EmoteID.Search.GetName(index);
        string key = "EmojiCommand." + name;
        ChatManager.Commands.AddAlias(Language.GetText(key), NetworkText.FromFormattable("{0} {1}", (object) Language.GetText("ChatCommand.Emoji_1"), (object) Language.GetText("EmojiName." + name)));
      }
    }
  }
}
