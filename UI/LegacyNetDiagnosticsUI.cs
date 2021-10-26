// Decompiled with JetBrains decompiler
// Type: Terraria.UI.LegacyNetDiagnosticsUI
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameContent;

namespace Terraria.UI
{
  public class LegacyNetDiagnosticsUI : INetDiagnosticsUI
  {
    public static bool netDiag;
    public static int txData = 0;
    public static int rxData = 0;
    public static int txMsg = 0;
    public static int rxMsg = 0;
    private const int maxMsg = 141;
    public static int[] rxMsgType = new int[141];
    public static int[] rxDataType = new int[141];
    public static int[] txMsgType = new int[141];
    public static int[] txDataType = new int[141];

    public void Reset()
    {
      LegacyNetDiagnosticsUI.rxMsg = 0;
      LegacyNetDiagnosticsUI.rxData = 0;
      LegacyNetDiagnosticsUI.txMsg = 0;
      LegacyNetDiagnosticsUI.txData = 0;
      for (int index = 0; index < 141; ++index)
      {
        LegacyNetDiagnosticsUI.rxMsgType[index] = 0;
        LegacyNetDiagnosticsUI.rxDataType[index] = 0;
        LegacyNetDiagnosticsUI.txMsgType[index] = 0;
        LegacyNetDiagnosticsUI.txDataType[index] = 0;
      }
    }

    public void CountReadMessage(int messageId, int messageLength)
    {
      ++LegacyNetDiagnosticsUI.rxMsg;
      LegacyNetDiagnosticsUI.rxData += messageLength;
      ++LegacyNetDiagnosticsUI.rxMsgType[messageId];
      LegacyNetDiagnosticsUI.rxDataType[messageId] += messageLength;
    }

    public void CountSentMessage(int messageId, int messageLength)
    {
      ++LegacyNetDiagnosticsUI.txMsg;
      LegacyNetDiagnosticsUI.txData += messageLength;
      ++LegacyNetDiagnosticsUI.txMsgType[messageId];
      LegacyNetDiagnosticsUI.txDataType[messageId] += messageLength;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      LegacyNetDiagnosticsUI.DrawTitles(spriteBatch);
      LegacyNetDiagnosticsUI.DrawMesageLines(spriteBatch);
    }

    private static void DrawMesageLines(SpriteBatch spriteBatch)
    {
      for (int msgId = 0; msgId < 141; ++msgId)
      {
        int num1 = 200;
        int num2 = 120;
        int num3 = msgId / 50;
        int x = num1 + num3 * 400;
        int y = num2 + (msgId - num3 * 50) * 13;
        LegacyNetDiagnosticsUI.PrintNetDiagnosticsLineForMessage(spriteBatch, msgId, x, y);
      }
    }

    private static void DrawTitles(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < 4; ++index)
      {
        string str = "";
        int num1 = 20;
        int num2 = 220;
        if (index == 0)
        {
          str = "RX Msgs: " + string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.rxMsg);
          num2 += index * 20;
        }
        else if (index == 1)
        {
          str = "RX Bytes: " + string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.rxData);
          num2 += index * 20;
        }
        else if (index == 2)
        {
          str = "TX Msgs: " + string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.txMsg);
          num2 += index * 20;
        }
        else if (index == 3)
        {
          str = "TX Bytes: " + string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.txData);
          num2 += index * 20;
        }
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str, new Vector2((float) num1, (float) num2), Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      }
    }

    private static void PrintNetDiagnosticsLineForMessage(
      SpriteBatch spriteBatch,
      int msgId,
      int x,
      int y)
    {
      float num = 0.7f;
      string str1 = msgId.ToString() + ": ";
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str1, new Vector2((float) x, (float) y), Color.White, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      x += 30;
      string str2 = "rx:" + string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.rxMsgType[msgId]);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str2, new Vector2((float) x, (float) y), Color.White, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      x += 70;
      string str3 = string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.rxDataType[msgId]);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str3, new Vector2((float) x, (float) y), Color.White, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      x += 70;
      string str4 = msgId.ToString() + ": ";
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str4, new Vector2((float) x, (float) y), Color.White, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      x += 30;
      string str5 = "tx:" + string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.txMsgType[msgId]);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str5, new Vector2((float) x, (float) y), Color.White, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      x += 70;
      string str6 = string.Format("{0:0,0}", (object) LegacyNetDiagnosticsUI.txDataType[msgId]);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str6, new Vector2((float) x, (float) y), Color.White, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
    }

    public void CountReadModuleMessage(int moduleMessageId, int messageLength)
    {
    }

    public void CountSentModuleMessage(int moduleMessageId, int messageLength)
    {
    }
  }
}
