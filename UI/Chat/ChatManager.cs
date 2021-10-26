// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Chat.ChatManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria.Chat;
using Terraria.GameContent.UI.Chat;

namespace Terraria.UI.Chat
{
  public static class ChatManager
  {
    public static readonly ChatCommandProcessor Commands = new ChatCommandProcessor();
    private static ConcurrentDictionary<string, ITagHandler> _handlers = new ConcurrentDictionary<string, ITagHandler>();
    public static readonly Vector2[] ShadowDirections = new Vector2[4]
    {
      -Vector2.UnitX,
      Vector2.UnitX,
      -Vector2.UnitY,
      Vector2.UnitY
    };

    public static Color WaveColor(Color color)
    {
      float num = (float) Main.mouseTextColor / (float) byte.MaxValue;
      color = Color.Lerp(color, Color.Black, 1f - num);
      color.A = Main.mouseTextColor;
      return color;
    }

    public static void ConvertNormalSnippets(TextSnippet[] snippets)
    {
      for (int index = 0; index < snippets.Length; ++index)
      {
        TextSnippet snippet = snippets[index];
        if (snippets[index].GetType() == typeof (TextSnippet))
        {
          PlainTagHandler.PlainSnippet plainSnippet = new PlainTagHandler.PlainSnippet(snippet.Text, snippet.Color, snippet.Scale);
          snippets[index] = (TextSnippet) plainSnippet;
        }
      }
    }

    public static void Register<T>(params string[] names) where T : ITagHandler, new()
    {
      T obj = new T();
      for (int index = 0; index < names.Length; ++index)
        ChatManager._handlers[names[index].ToLower()] = (ITagHandler) obj;
    }

    private static ITagHandler GetHandler(string tagName)
    {
      string lower = tagName.ToLower();
      return ChatManager._handlers.ContainsKey(lower) ? ChatManager._handlers[lower] : (ITagHandler) null;
    }

    public static List<TextSnippet> ParseMessage(string text, Color baseColor)
    {
      text = text.Replace("\r", "");
      MatchCollection matchCollection = ChatManager.Regexes.Format.Matches(text);
      List<TextSnippet> textSnippetList = new List<TextSnippet>();
      int startIndex = 0;
      foreach (Match match in matchCollection)
      {
        if (match.Index > startIndex)
          textSnippetList.Add(new TextSnippet(text.Substring(startIndex, match.Index - startIndex), baseColor));
        startIndex = match.Index + match.Length;
        string tagName = match.Groups["tag"].Value;
        string text1 = match.Groups[nameof (text)].Value;
        string options = match.Groups["options"].Value;
        ITagHandler handler = ChatManager.GetHandler(tagName);
        if (handler != null)
        {
          textSnippetList.Add(handler.Parse(text1, baseColor, options));
          textSnippetList[textSnippetList.Count - 1].TextOriginal = match.ToString();
        }
        else
          textSnippetList.Add(new TextSnippet(text1, baseColor));
      }
      if (text.Length > startIndex)
        textSnippetList.Add(new TextSnippet(text.Substring(startIndex, text.Length - startIndex), baseColor));
      return textSnippetList;
    }

    public static bool AddChatText(DynamicSpriteFont font, string text, Vector2 baseScale)
    {
      int num = Main.screenWidth - 330;
      if ((double) ChatManager.GetStringSize(font, Main.chatText + text, baseScale).X > (double) num)
        return false;
      Main.chatText += text;
      return true;
    }

    public static Vector2 GetStringSize(
      DynamicSpriteFont font,
      string text,
      Vector2 baseScale,
      float maxWidth = -1f)
    {
      TextSnippet[] array = ChatManager.ParseMessage(text, Color.White).ToArray();
      return ChatManager.GetStringSize(font, array, baseScale, maxWidth);
    }

    public static Vector2 GetStringSize(
      DynamicSpriteFont font,
      TextSnippet[] snippets,
      Vector2 baseScale,
      float maxWidth = -1f)
    {
      Vector2 vec = new Vector2((float) Main.mouseX, (float) Main.mouseY);
      Vector2 zero = Vector2.Zero;
      Vector2 minimum = zero;
      Vector2 vector2_1 = minimum;
      float x = font.MeasureString(" ").X;
      float num1 = 0.0f;
      for (int index1 = 0; index1 < snippets.Length; ++index1)
      {
        TextSnippet snippet = snippets[index1];
        snippet.Update();
        float scale = snippet.Scale;
        Vector2 size;
        if (snippet.UniqueDraw(true, out size, (SpriteBatch) null))
        {
          minimum.X += size.X * baseScale.X * scale;
          vector2_1.X = Math.Max(vector2_1.X, minimum.X);
          vector2_1.Y = Math.Max(vector2_1.Y, minimum.Y + size.Y);
        }
        else
        {
          string[] strArray1 = snippet.Text.Split('\n');
          foreach (string str in strArray1)
          {
            char[] chArray = new char[1]{ ' ' };
            string[] strArray2 = str.Split(chArray);
            for (int index2 = 0; index2 < strArray2.Length; ++index2)
            {
              if (index2 != 0)
                minimum.X += x * baseScale.X * scale;
              if ((double) maxWidth > 0.0)
              {
                float num2 = font.MeasureString(strArray2[index2]).X * baseScale.X * scale;
                if ((double) minimum.X - (double) zero.X + (double) num2 > (double) maxWidth)
                {
                  minimum.X = zero.X;
                  minimum.Y += (float) font.LineSpacing * num1 * baseScale.Y;
                  vector2_1.Y = Math.Max(vector2_1.Y, minimum.Y);
                  num1 = 0.0f;
                }
              }
              if ((double) num1 < (double) scale)
                num1 = scale;
              Vector2 vector2_2 = font.MeasureString(strArray2[index2]);
              vec.Between(minimum, minimum + vector2_2);
              minimum.X += vector2_2.X * baseScale.X * scale;
              vector2_1.X = Math.Max(vector2_1.X, minimum.X);
              vector2_1.Y = Math.Max(vector2_1.Y, minimum.Y + vector2_2.Y);
            }
            if (strArray1.Length > 1)
            {
              minimum.X = zero.X;
              minimum.Y += (float) font.LineSpacing * num1 * baseScale.Y;
              vector2_1.Y = Math.Max(vector2_1.Y, minimum.Y);
              num1 = 0.0f;
            }
          }
        }
      }
      return vector2_1;
    }

    public static void DrawColorCodedStringShadow(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      TextSnippet[] snippets,
      Vector2 position,
      Color baseColor,
      float rotation,
      Vector2 origin,
      Vector2 baseScale,
      float maxWidth = -1f,
      float spread = 2f)
    {
      for (int index = 0; index < ChatManager.ShadowDirections.Length; ++index)
        ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position + ChatManager.ShadowDirections[index] * spread, baseColor, rotation, origin, baseScale, out int _, maxWidth, true);
    }

    public static Vector2 DrawColorCodedString(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      TextSnippet[] snippets,
      Vector2 position,
      Color baseColor,
      float rotation,
      Vector2 origin,
      Vector2 baseScale,
      out int hoveredSnippet,
      float maxWidth,
      bool ignoreColors = false)
    {
      int num1 = -1;
      Vector2 vec = new Vector2((float) Main.mouseX, (float) Main.mouseY);
      Vector2 vector2_1 = position;
      Vector2 vector2_2 = vector2_1;
      float x = font.MeasureString(" ").X;
      Color color = baseColor;
      float num2 = 0.0f;
      for (int index1 = 0; index1 < snippets.Length; ++index1)
      {
        TextSnippet snippet = snippets[index1];
        snippet.Update();
        if (!ignoreColors)
          color = snippet.GetVisibleColor();
        float scale = snippet.Scale;
        Vector2 size;
        if (snippet.UniqueDraw(false, out size, spriteBatch, vector2_1, color, scale))
        {
          if (vec.Between(vector2_1, vector2_1 + size))
            num1 = index1;
          vector2_1.X += size.X * baseScale.X * scale;
          vector2_2.X = Math.Max(vector2_2.X, vector2_1.X);
        }
        else
        {
          snippet.Text.Split('\n');
          string[] strArray1 = Regex.Split(snippet.Text, "(\n)");
          bool flag = true;
          for (int index2 = 0; index2 < strArray1.Length; ++index2)
          {
            string input = strArray1[index2];
            Regex.Split(input, "( )");
            string[] strArray2 = input.Split(' ');
            if (input == "\n")
            {
              vector2_1.Y += (float) font.LineSpacing * num2 * baseScale.Y;
              vector2_1.X = position.X;
              vector2_2.Y = Math.Max(vector2_2.Y, vector2_1.Y);
              num2 = 0.0f;
              flag = false;
            }
            else
            {
              for (int index3 = 0; index3 < strArray2.Length; ++index3)
              {
                if (index3 != 0)
                  vector2_1.X += x * baseScale.X * scale;
                if ((double) maxWidth > 0.0)
                {
                  float num3 = font.MeasureString(strArray2[index3]).X * baseScale.X * scale;
                  if ((double) vector2_1.X - (double) position.X + (double) num3 > (double) maxWidth)
                  {
                    vector2_1.X = position.X;
                    vector2_1.Y += (float) font.LineSpacing * num2 * baseScale.Y;
                    vector2_2.Y = Math.Max(vector2_2.Y, vector2_1.Y);
                    num2 = 0.0f;
                  }
                }
                if ((double) num2 < (double) scale)
                  num2 = scale;
                DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, font, strArray2[index3], vector2_1, color, rotation, origin, baseScale * snippet.Scale * scale, SpriteEffects.None, 0.0f);
                Vector2 vector2_3 = font.MeasureString(strArray2[index3]);
                if (vec.Between(vector2_1, vector2_1 + vector2_3))
                  num1 = index1;
                vector2_1.X += vector2_3.X * baseScale.X * scale;
                vector2_2.X = Math.Max(vector2_2.X, vector2_1.X);
              }
              if (strArray1.Length > 1 & flag)
              {
                vector2_1.Y += (float) font.LineSpacing * num2 * baseScale.Y;
                vector2_1.X = position.X;
                vector2_2.Y = Math.Max(vector2_2.Y, vector2_1.Y);
                num2 = 0.0f;
              }
              flag = true;
            }
          }
        }
      }
      hoveredSnippet = num1;
      return vector2_2;
    }

    public static Vector2 DrawColorCodedStringWithShadow(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      TextSnippet[] snippets,
      Vector2 position,
      float rotation,
      Vector2 origin,
      Vector2 baseScale,
      out int hoveredSnippet,
      float maxWidth = -1f,
      float spread = 2f)
    {
      ChatManager.DrawColorCodedStringShadow(spriteBatch, font, snippets, position, Color.Black, rotation, origin, baseScale, maxWidth, spread);
      return ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position, Color.White, rotation, origin, baseScale, out hoveredSnippet, maxWidth);
    }

    public static Vector2 DrawColorCodedStringWithShadow(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      TextSnippet[] snippets,
      Vector2 position,
      float rotation,
      Color color,
      Vector2 origin,
      Vector2 baseScale,
      out int hoveredSnippet,
      float maxWidth = -1f,
      float spread = 2f)
    {
      ChatManager.DrawColorCodedStringShadow(spriteBatch, font, snippets, position, Color.Black, rotation, origin, baseScale, maxWidth, spread);
      return ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position, color, rotation, origin, baseScale, out hoveredSnippet, maxWidth, true);
    }

    public static void DrawColorCodedStringShadow(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      string text,
      Vector2 position,
      Color baseColor,
      float rotation,
      Vector2 origin,
      Vector2 baseScale,
      float maxWidth = -1f,
      float spread = 2f)
    {
      for (int index = 0; index < ChatManager.ShadowDirections.Length; ++index)
        ChatManager.DrawColorCodedString(spriteBatch, font, text, position + ChatManager.ShadowDirections[index] * spread, baseColor, rotation, origin, baseScale, maxWidth, true);
    }

    public static Vector2 DrawColorCodedString(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      string text,
      Vector2 position,
      Color baseColor,
      float rotation,
      Vector2 origin,
      Vector2 baseScale,
      float maxWidth = -1f,
      bool ignoreColors = false)
    {
      Vector2 vector2_1 = position;
      Vector2 vector2_2 = vector2_1;
      string[] strArray1 = text.Split('\n');
      float x = font.MeasureString(" ").X;
      Color color = baseColor;
      float num1 = 1f;
      float num2 = 0.0f;
      foreach (string str1 in strArray1)
      {
        char[] chArray = new char[1]{ ':' };
        foreach (string str2 in str1.Split(chArray))
        {
          if (str2.StartsWith("sss"))
          {
            if (str2.StartsWith("sss1"))
            {
              if (!ignoreColors)
                color = Color.Red;
            }
            else if (str2.StartsWith("sss2"))
            {
              if (!ignoreColors)
                color = Color.Blue;
            }
            else if (str2.StartsWith("sssr") && !ignoreColors)
              color = Color.White;
          }
          else
          {
            string[] strArray2 = str2.Split(' ');
            for (int index = 0; index < strArray2.Length; ++index)
            {
              if (index != 0)
                vector2_1.X += x * baseScale.X * num1;
              if ((double) maxWidth > 0.0)
              {
                float num3 = font.MeasureString(strArray2[index]).X * baseScale.X * num1;
                if ((double) vector2_1.X - (double) position.X + (double) num3 > (double) maxWidth)
                {
                  vector2_1.X = position.X;
                  vector2_1.Y += (float) font.LineSpacing * num2 * baseScale.Y;
                  vector2_2.Y = Math.Max(vector2_2.Y, vector2_1.Y);
                  num2 = 0.0f;
                }
              }
              if ((double) num2 < (double) num1)
                num2 = num1;
              DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, font, strArray2[index], vector2_1, color, rotation, origin, baseScale * num1, SpriteEffects.None, 0.0f);
              vector2_1.X += font.MeasureString(strArray2[index]).X * baseScale.X * num1;
              vector2_2.X = Math.Max(vector2_2.X, vector2_1.X);
            }
          }
        }
        vector2_1.X = position.X;
        vector2_1.Y += (float) font.LineSpacing * num2 * baseScale.Y;
        vector2_2.Y = Math.Max(vector2_2.Y, vector2_1.Y);
        num2 = 0.0f;
      }
      return vector2_2;
    }

    public static Vector2 DrawColorCodedStringWithShadow(
      SpriteBatch spriteBatch,
      DynamicSpriteFont font,
      string text,
      Vector2 position,
      Color baseColor,
      float rotation,
      Vector2 origin,
      Vector2 baseScale,
      float maxWidth = -1f,
      float spread = 2f)
    {
      TextSnippet[] array = ChatManager.ParseMessage(text, baseColor).ToArray();
      ChatManager.ConvertNormalSnippets(array);
      ChatManager.DrawColorCodedStringShadow(spriteBatch, font, array, position, new Color(0, 0, 0, (int) baseColor.A), rotation, origin, baseScale, maxWidth, spread);
      return ChatManager.DrawColorCodedString(spriteBatch, font, array, position, Color.White, rotation, origin, baseScale, out int _, maxWidth);
    }

    public static class Regexes
    {
      public static readonly Regex Format = new Regex("(?<!\\\\)\\[(?<tag>[a-zA-Z]{1,10})(\\/(?<options>[^:]+))?:(?<text>.+?)(?<!\\\\)\\]", RegexOptions.Compiled);
    }
  }
}
