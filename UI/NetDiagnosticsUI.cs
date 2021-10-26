// Decompiled with JetBrains decompiler
// Type: Terraria.UI.NetDiagnosticsUI
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System.Collections.Generic;
using Terraria.GameContent;

namespace Terraria.UI
{
  public class NetDiagnosticsUI : INetDiagnosticsUI
  {
    private NetDiagnosticsUI.CounterForMessage[] _counterByMessageId = new NetDiagnosticsUI.CounterForMessage[141];
    private Dictionary<int, NetDiagnosticsUI.CounterForMessage> _counterByModuleId = new Dictionary<int, NetDiagnosticsUI.CounterForMessage>();
    private int _highestFoundReadBytes = 1;
    private int _highestFoundReadCount = 1;

    public void Reset()
    {
      for (int index = 0; index < this._counterByMessageId.Length; ++index)
        this._counterByMessageId[index].Reset();
      this._counterByModuleId.Clear();
      this._counterByMessageId[10].exemptFromBadScoreTest = true;
      this._counterByMessageId[82].exemptFromBadScoreTest = true;
    }

    public void CountReadMessage(int messageId, int messageLength) => this._counterByMessageId[messageId].CountReadMessage(messageLength);

    public void CountSentMessage(int messageId, int messageLength) => this._counterByMessageId[messageId].CountSentMessage(messageLength);

    public void CountReadModuleMessage(int moduleMessageId, int messageLength)
    {
      NetDiagnosticsUI.CounterForMessage counterForMessage;
      this._counterByModuleId.TryGetValue(moduleMessageId, out counterForMessage);
      counterForMessage.CountReadMessage(messageLength);
      this._counterByModuleId[moduleMessageId] = counterForMessage;
    }

    public void CountSentModuleMessage(int moduleMessageId, int messageLength)
    {
      NetDiagnosticsUI.CounterForMessage counterForMessage;
      this._counterByModuleId.TryGetValue(moduleMessageId, out counterForMessage);
      counterForMessage.CountSentMessage(messageLength);
      this._counterByModuleId[moduleMessageId] = counterForMessage;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      int num1 = this._counterByMessageId.Length + this._counterByModuleId.Count;
      for (int index = 0; index <= num1 / 51; ++index)
        Utils.DrawInvBG(spriteBatch, 190 + 400 * index, 110, 390, 683, new Color());
      Vector2 position;
      for (int index = 0; index < this._counterByMessageId.Length; ++index)
      {
        int num2 = index / 51;
        int num3 = index - num2 * 51;
        position.X = (float) (200 + num2 * 400);
        position.Y = (float) (120 + num3 * 13);
        this.DrawCounter(spriteBatch, ref this._counterByMessageId[index], index.ToString(), position);
      }
      int num4 = this._counterByMessageId.Length + 1;
      foreach (KeyValuePair<int, NetDiagnosticsUI.CounterForMessage> keyValuePair in this._counterByModuleId)
      {
        int num5 = num4 / 51;
        int num6 = num4 - num5 * 51;
        position.X = (float) (200 + num5 * 400);
        position.Y = (float) (120 + num6 * 13);
        NetDiagnosticsUI.CounterForMessage counter = keyValuePair.Value;
        this.DrawCounter(spriteBatch, ref counter, ".." + keyValuePair.Key.ToString(), position);
        ++num4;
      }
    }

    private void DrawCounter(
      SpriteBatch spriteBatch,
      ref NetDiagnosticsUI.CounterForMessage counter,
      string title,
      Vector2 position)
    {
      if (!counter.exemptFromBadScoreTest)
      {
        if (this._highestFoundReadCount < counter.timesReceived)
          this._highestFoundReadCount = counter.timesReceived;
        if (this._highestFoundReadBytes < counter.bytesReceived)
          this._highestFoundReadBytes = counter.bytesReceived;
      }
      Vector2 pos = position;
      string str = title + ": ";
      Color color = Main.hslToRgb((float) (0.300000011920929 * (1.0 - (double) Utils.Remap((float) counter.bytesReceived, 0.0f, (float) this._highestFoundReadBytes, 0.0f, 1f))), 1f, 0.5f);
      if (counter.exemptFromBadScoreTest)
        color = Color.White;
      string text1 = str;
      this.DrawText(spriteBatch, text1, pos, color);
      pos.X += 30f;
      string text2 = "rx:" + string.Format("{0,0}", (object) counter.timesReceived);
      this.DrawText(spriteBatch, text2, pos, color);
      pos.X += 70f;
      string text3 = string.Format("{0,0}", (object) counter.bytesReceived);
      this.DrawText(spriteBatch, text3, pos, color);
      pos.X += 70f;
      string text4 = str;
      this.DrawText(spriteBatch, text4, pos, color);
      pos.X += 30f;
      string text5 = "tx:" + string.Format("{0,0}", (object) counter.timesSent);
      this.DrawText(spriteBatch, text5, pos, color);
      pos.X += 70f;
      string text6 = string.Format("{0,0}", (object) counter.bytesSent);
      this.DrawText(spriteBatch, text6, pos, color);
    }

    private void DrawText(SpriteBatch spriteBatch, string text, Vector2 pos, Color color) => DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, text, pos, color, 0.0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0.0f);

    private struct CounterForMessage
    {
      public int timesReceived;
      public int timesSent;
      public int bytesReceived;
      public int bytesSent;
      public bool exemptFromBadScoreTest;

      public void Reset()
      {
        this.timesReceived = 0;
        this.timesSent = 0;
        this.bytesReceived = 0;
        this.bytesSent = 0;
      }

      public void CountReadMessage(int messageLength)
      {
        ++this.timesReceived;
        this.bytesReceived += messageLength;
      }

      public void CountSentMessage(int messageLength)
      {
        ++this.timesSent;
        this.bytesSent += messageLength;
      }
    }
  }
}
