// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.LegacyChatMonitor
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class LegacyChatMonitor : IChatMonitor
  {
    private int numChatLines;
    private ChatLine[] chatLine;
    private int chatLength;
    private int showCount;
    private int startChatLine;

    public int TextMaxLengthForScreen => Main.screenWidth - 320;

    public void OnResolutionChange()
    {
    }

    public LegacyChatMonitor()
    {
      this.showCount = 10;
      this.numChatLines = 500;
      this.chatLength = 600;
      this.chatLine = new ChatLine[this.numChatLines];
      for (int index = 0; index < this.numChatLines; ++index)
        this.chatLine[index] = new ChatLine();
    }

    public void Clear()
    {
      for (int index = 0; index < this.numChatLines; ++index)
        this.chatLine[index] = new ChatLine();
    }

    public void ResetOffset() => this.startChatLine = 0;

    public void Update()
    {
      for (int index = 0; index < this.numChatLines; ++index)
        this.chatLine[index].UpdateTimeLeft();
    }

    public void Offset(int linesOffset)
    {
      this.showCount = (int) ((double) (Main.screenHeight / 3) / (double) FontAssets.MouseText.Value.MeasureString("1").Y) - 1;
      switch (linesOffset)
      {
        case -1:
          --this.startChatLine;
          if (this.startChatLine >= 0)
            break;
          this.startChatLine = 0;
          break;
        case 1:
          ++this.startChatLine;
          if (this.startChatLine + this.showCount >= this.numChatLines - 1)
            this.startChatLine = this.numChatLines - this.showCount - 1;
          if (!(this.chatLine[this.startChatLine + this.showCount].originalText == ""))
            break;
          --this.startChatLine;
          break;
      }
    }

    public void NewText(string newText, byte R = 255, byte G = 255, byte B = 255) => this.NewTextMultiline(newText, false, new Color((int) R, (int) G, (int) B), -1);

    public void NewTextInternal(string newText, byte R = 255, byte G = 255, byte B = 255, bool force = false)
    {
      int maxTextSize = 80;
      if (!force && newText.Length > maxTextSize)
      {
        string oldText = newText;
        string newText1 = this.TrimIntoMultipleLines(R, G, B, maxTextSize, oldText);
        if (newText1.Length <= 0)
          return;
        this.NewTextInternal(newText1, R, G, B, true);
      }
      else
      {
        for (int index = this.numChatLines - 1; index > 0; --index)
          this.chatLine[index].Copy(this.chatLine[index - 1]);
        this.chatLine[0].color = new Color((int) R, (int) G, (int) B);
        this.chatLine[0].originalText = newText;
        this.chatLine[0].parsedText = ChatManager.ParseMessage(this.chatLine[0].originalText, this.chatLine[0].color).ToArray();
        this.chatLine[0].showTime = this.chatLength;
        SoundEngine.PlaySound(12);
      }
    }

    private string TrimIntoMultipleLines(byte R, byte G, byte B, int maxTextSize, string oldText)
    {
      while (oldText.Length > maxTextSize)
      {
        int num = maxTextSize;
        int startIndex = num;
        while (oldText.Substring(startIndex, 1) != " ")
        {
          --startIndex;
          if (startIndex < 1)
            break;
        }
        if (startIndex == 0)
        {
          while (oldText.Substring(num, 1) != " ")
          {
            ++num;
            if (num >= oldText.Length - 1)
              break;
          }
        }
        else
          num = startIndex;
        if (num >= oldText.Length - 1)
          num = oldText.Length;
        this.NewTextInternal(oldText.Substring(0, num), R, G, B, true);
        oldText = oldText.Substring(num);
        if (oldText.Length > 0)
        {
          while (oldText.Substring(0, 1) == " ")
            oldText = oldText.Substring(1);
        }
      }
      return oldText;
    }

    public void NewTextMultiline(string text, bool force = false, Color c = default (Color), int WidthLimit = -1)
    {
      if (c == new Color())
        c = Color.White;
      List<List<TextSnippet>> textSnippetListList = WidthLimit == -1 ? Utils.WordwrapStringSmart(text, c, FontAssets.MouseText.Value, this.TextMaxLengthForScreen, 10) : Utils.WordwrapStringSmart(text, c, FontAssets.MouseText.Value, WidthLimit, 10);
      for (int index = 0; index < textSnippetListList.Count; ++index)
        this.NewText(textSnippetListList[index]);
    }

    public void NewText(List<TextSnippet> snippets)
    {
      for (int index = this.numChatLines - 1; index > 0; --index)
        this.chatLine[index].Copy(this.chatLine[index - 1]);
      this.chatLine[0].originalText = "this is a hack because draw checks length is higher than 0";
      this.chatLine[0].parsedText = snippets.ToArray();
      this.chatLine[0].showTime = this.chatLength;
      SoundEngine.PlaySound(12);
    }

    public void DrawChat(bool drawingPlayerChat)
    {
      int num1 = this.startChatLine;
      int num2 = this.startChatLine + this.showCount;
      if (num2 >= this.numChatLines)
      {
        num2 = --this.numChatLines;
        num1 = num2 - this.showCount;
      }
      int num3 = 0;
      int index1 = -1;
      int index2 = -1;
      for (int index3 = num1; index3 < num2; ++index3)
      {
        if (drawingPlayerChat || this.chatLine[index3].showTime > 0 && this.chatLine[index3].parsedText.Length != 0)
        {
          int hoveredSnippet = -1;
          ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, this.chatLine[index3].parsedText, new Vector2(88f, (float) (Main.screenHeight - 30 - 28 - num3 * 21)), 0.0f, Vector2.Zero, Vector2.One, out hoveredSnippet);
          if (hoveredSnippet >= 0 && this.chatLine[index3].parsedText[hoveredSnippet].CheckForHover)
          {
            index1 = index3;
            index2 = hoveredSnippet;
          }
        }
        ++num3;
      }
      if (index1 <= -1)
        return;
      this.chatLine[index1].parsedText[index2].OnHover();
      if (!Main.mouseLeft || !Main.mouseLeftRelease)
        return;
      this.chatLine[index1].parsedText[index2].OnClick();
    }
  }
}
