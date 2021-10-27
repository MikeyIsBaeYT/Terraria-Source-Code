// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.NameTagHandler
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class NameTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(
      string text,
      Color baseColor,
      string options)
    {
      return new TextSnippet("<" + text.Replace("\\[", "[").Replace("\\]", "]") + ">", baseColor);
    }

    public static string GenerateTag(string name) => "[n:" + name.Replace("[", "\\[").Replace("]", "\\]") + "]";
  }
}
