// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.RemadeChatMonitor
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class RemadeChatMonitor : IChatMonitor
  {
    private const int MaxMessages = 500;
    private int _showCount;
    private int _startChatLine;
    private List<ChatMessageContainer> _messages;
    private bool _recalculateOnNextUpdate;

    public RemadeChatMonitor()
    {
      this._showCount = 10;
      this._startChatLine = 0;
      this._messages = new List<ChatMessageContainer>();
    }

    public void NewText(string newText, byte R = 255, byte G = 255, byte B = 255) => this.AddNewMessage(newText, new Color((int) R, (int) G, (int) B));

    public void NewTextMultiline(string text, bool force = false, Color c = default (Color), int WidthLimit = -1) => this.AddNewMessage(text, c, WidthLimit);

    public void AddNewMessage(string text, Color color, int widthLimitInPixels = -1)
    {
      ChatMessageContainer messageContainer = new ChatMessageContainer();
      messageContainer.SetContents(text, color, widthLimitInPixels);
      this._messages.Insert(0, messageContainer);
      while (this._messages.Count > 500)
        this._messages.RemoveAt(this._messages.Count - 1);
    }

    public void DrawChat(bool drawingPlayerChat)
    {
      int startChatLine = this._startChatLine;
      int index = 0;
      int snippetIndex1 = 0;
      while (startChatLine > 0 && index < this._messages.Count)
      {
        int num = Math.Min(startChatLine, this._messages[index].LineCount);
        startChatLine -= num;
        snippetIndex1 += num;
        if (snippetIndex1 == this._messages[index].LineCount)
        {
          snippetIndex1 = 0;
          ++index;
        }
      }
      int num1 = 0;
      int? nullable1 = new int?();
      int snippetIndex2 = -1;
      int? nullable2 = new int?();
      int hoveredSnippet = -1;
      while (num1 < this._showCount && index < this._messages.Count)
      {
        ChatMessageContainer message = this._messages[index];
        if (message.Prepared && drawingPlayerChat | message.CanBeShownWhenChatIsClosed)
        {
          TextSnippet[] withInversedIndex = message.GetSnippetWithInversedIndex(snippetIndex1);
          ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, withInversedIndex, new Vector2(88f, (float) (Main.screenHeight - 30 - 28 - num1 * 21)), 0.0f, Vector2.Zero, Vector2.One, out hoveredSnippet);
          if (hoveredSnippet >= 0)
          {
            nullable2 = new int?(hoveredSnippet);
            nullable1 = new int?(index);
            snippetIndex2 = snippetIndex1;
          }
          ++num1;
          ++snippetIndex1;
          if (snippetIndex1 >= message.LineCount)
          {
            snippetIndex1 = 0;
            ++index;
          }
        }
        else
          break;
      }
      if (!nullable1.HasValue || !nullable2.HasValue)
        return;
      TextSnippet[] withInversedIndex1 = this._messages[nullable1.Value].GetSnippetWithInversedIndex(snippetIndex2);
      withInversedIndex1[nullable2.Value].OnHover();
      if (!Main.mouseLeft || !Main.mouseLeftRelease)
        return;
      withInversedIndex1[nullable2.Value].OnClick();
    }

    public void Clear() => this._messages.Clear();

    public void Update()
    {
      if (this._recalculateOnNextUpdate)
      {
        this._recalculateOnNextUpdate = false;
        for (int index = 0; index < this._messages.Count; ++index)
          this._messages[index].MarkToNeedRefresh();
      }
      for (int index = 0; index < this._messages.Count; ++index)
        this._messages[index].Update();
    }

    public void Offset(int linesOffset)
    {
      this._startChatLine += linesOffset;
      this.ClampMessageIndex();
    }

    private void ClampMessageIndex()
    {
      int num1 = 0;
      int index = 0;
      int num2 = 0;
      int num3 = this._startChatLine + this._showCount;
      while (num1 < num3 && index < this._messages.Count)
      {
        int num4 = Math.Min(num3 - num1, this._messages[index].LineCount);
        num1 += num4;
        if (num1 < num3)
        {
          ++index;
          num2 = 0;
        }
        else
          num2 = num4;
      }
      int showCount = this._showCount;
      while (showCount > 0 && num1 > 0)
      {
        --num2;
        --showCount;
        --num1;
        if (num2 < 0)
        {
          --index;
          if (index != -1)
            num2 = this._messages[index].LineCount - 1;
          else
            break;
        }
      }
      this._startChatLine = num1;
    }

    public void ResetOffset() => this._startChatLine = 0;

    public void OnResolutionChange() => this._recalculateOnNextUpdate = true;
  }
}
