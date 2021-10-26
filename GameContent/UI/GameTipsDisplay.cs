// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.GameTipsDisplay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI
{
  public class GameTipsDisplay
  {
    private LocalizedText[] _tipsDefault;
    private LocalizedText[] _tipsGamepad;
    private LocalizedText[] _tipsKeyboard;
    private readonly List<GameTipsDisplay.GameTip> _currentTips = new List<GameTipsDisplay.GameTip>();
    private LocalizedText _lastTip;

    public GameTipsDisplay()
    {
      this._tipsDefault = Language.FindAll(Lang.CreateDialogFilter("LoadingTips_Default."));
      this._tipsGamepad = Language.FindAll(Lang.CreateDialogFilter("LoadingTips_GamePad."));
      this._tipsKeyboard = Language.FindAll(Lang.CreateDialogFilter("LoadingTips_Keyboard."));
      this._lastTip = (LocalizedText) null;
    }

    public void Update()
    {
      double time = Main.gameTimeCache.TotalGameTime.TotalSeconds;
      this._currentTips.RemoveAll((Predicate<GameTipsDisplay.GameTip>) (x => x.IsExpired(time)));
      bool flag = true;
      foreach (GameTipsDisplay.GameTip currentTip in this._currentTips)
      {
        if (!currentTip.IsExpiring(time))
        {
          flag = false;
          break;
        }
      }
      if (flag)
        this.AddNewTip(time);
      foreach (GameTipsDisplay.GameTip currentTip in this._currentTips)
        currentTip.Update(time);
    }

    public void ClearTips() => this._currentTips.Clear();

    public void Draw()
    {
      SpriteBatch spriteBatch = Main.spriteBatch;
      float screenWidth = (float) Main.screenWidth;
      float y = (float) (Main.screenHeight - 150);
      float num1 = (float) Main.screenWidth * 0.5f;
      foreach (GameTipsDisplay.GameTip currentTip in this._currentTips)
      {
        if ((double) currentTip.ScreenAnchorX >= -0.5 && (double) currentTip.ScreenAnchorX <= 1.5)
        {
          DynamicSpriteFont font = FontAssets.MouseText.Value;
          string text = font.CreateWrappedText(currentTip.Text, num1, Language.ActiveCulture.CultureInfo);
          if (text.Split('\n').Length > 2)
            text = font.CreateWrappedText(currentTip.Text, (float) ((double) num1 * 1.5 - 50.0), Language.ActiveCulture.CultureInfo);
          if (WorldGen.drunkWorldGenText)
          {
            text = string.Concat((object) Main.rand.Next(999999999));
            for (int index = 0; index < 14; ++index)
            {
              if (Main.rand.Next(2) == 0)
                text += (string) (object) Main.rand.Next(999999999);
            }
          }
          if (WorldGen.getGoodWorldGen)
          {
            string str = "";
            for (int startIndex = text.Length - 1; startIndex >= 0; --startIndex)
              str += text.Substring(startIndex, 1);
            text = str;
          }
          Vector2 vector2 = font.MeasureString(text);
          float num2 = 1.1f;
          float num3 = 110f;
          if ((double) vector2.Y > (double) num3)
            num2 = num3 / vector2.Y;
          Vector2 position = new Vector2(screenWidth * currentTip.ScreenAnchorX, y);
          position -= vector2 * num2 * 0.5f;
          ChatManager.DrawColorCodedStringWithShadow(spriteBatch, font, text, position, Color.White, 0.0f, Vector2.Zero, new Vector2(num2, num2));
        }
      }
    }

    private void AddNewTip(double currentTime)
    {
      string textKey = "UI.Back";
      List<LocalizedText> localizedTextList = new List<LocalizedText>();
      localizedTextList.AddRange((IEnumerable<LocalizedText>) this._tipsDefault);
      if (PlayerInput.UsingGamepad)
        localizedTextList.AddRange((IEnumerable<LocalizedText>) this._tipsGamepad);
      else
        localizedTextList.AddRange((IEnumerable<LocalizedText>) this._tipsKeyboard);
      if (this._lastTip != null)
        localizedTextList.Remove(this._lastTip);
      LocalizedText localizedText = localizedTextList.Count != 0 ? localizedTextList[Main.rand.Next(localizedTextList.Count)] : LocalizedText.Empty;
      this._lastTip = localizedText;
      string key = localizedText.Key;
      if (Language.Exists(key))
        textKey = key;
      this._currentTips.Add(new GameTipsDisplay.GameTip(textKey, currentTime));
    }

    private class GameTip
    {
      private const float APPEAR_FROM = 2.5f;
      private const float APPEAR_TO = 0.5f;
      private const float DISAPPEAR_TO = -1.5f;
      private const float APPEAR_TIME = 0.5f;
      private const float DISAPPEAR_TIME = 1f;
      private const float DURATION = 16.5f;
      private LocalizedText _textKey;
      private string _formattedText;
      public float ScreenAnchorX;
      public readonly float Duration;
      public readonly double SpawnTime;

      public string Text => this._textKey == null ? "What?!" : this._formattedText;

      public bool IsExpired(double currentTime) => currentTime >= this.SpawnTime + (double) this.Duration;

      public bool IsExpiring(double currentTime) => currentTime >= this.SpawnTime + (double) this.Duration - 1.0;

      public GameTip(string textKey, double spawnTime)
      {
        this._textKey = Language.GetText(textKey);
        this.SpawnTime = spawnTime;
        this.ScreenAnchorX = 2.5f;
        this.Duration = 16.5f;
        this._formattedText = this._textKey.FormatWith(Lang.CreateDialogSubstitutionObject());
      }

      public void Update(double currentTime)
      {
        double t = currentTime - this.SpawnTime;
        if (t < 0.5)
          this.ScreenAnchorX = MathHelper.SmoothStep(2.5f, 0.5f, (float) Utils.GetLerpValue(0.0, 0.5, t, true));
        else if (t >= (double) this.Duration - 1.0)
          this.ScreenAnchorX = MathHelper.SmoothStep(0.5f, -1.5f, (float) Utils.GetLerpValue((double) this.Duration - 1.0, (double) this.Duration, t, true));
        else
          this.ScreenAnchorX = 0.5f;
      }
    }
  }
}
