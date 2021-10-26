// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.IChatMonitor
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.UI.Chat
{
  public interface IChatMonitor
  {
    void NewText(string newText, byte R = 255, byte G = 255, byte B = 255);

    void NewTextMultiline(string text, bool force = false, Color c = default (Color), int WidthLimit = -1);

    void DrawChat(bool drawingPlayerChat);

    void Clear();

    void Update();

    void Offset(int linesOffset);

    void ResetOffset();

    void OnResolutionChange();
  }
}
