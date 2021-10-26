// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.NewMultiplayerClosePlayersOverlay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI
{
  public class NewMultiplayerClosePlayersOverlay : IMultiplayerClosePlayersOverlay
  {
    private List<NewMultiplayerClosePlayersOverlay.PlayerOnScreenCache> _playerOnScreenCache = new List<NewMultiplayerClosePlayersOverlay.PlayerOnScreenCache>();
    private List<NewMultiplayerClosePlayersOverlay.PlayerOffScreenCache> _playerOffScreenCache = new List<NewMultiplayerClosePlayersOverlay.PlayerOffScreenCache>();

    public void Draw()
    {
      int namePlateDistance = Main.teamNamePlateDistance;
      if (namePlateDistance <= 0)
        return;
      this._playerOnScreenCache.Clear();
      this._playerOffScreenCache.Clear();
      SpriteBatch spriteBatch = Main.spriteBatch;
      PlayerInput.SetZoom_World();
      int screenWidth = Main.screenWidth;
      int screenHeight = Main.screenHeight;
      Vector2 screenPosition1 = Main.screenPosition;
      PlayerInput.SetZoom_UI();
      int num1 = namePlateDistance * 8;
      Player[] player1 = Main.player;
      int player2 = Main.myPlayer;
      byte mouseTextColor = Main.mouseTextColor;
      Color[] teamColor = Main.teamColor;
      Vector2 screenPosition2 = Main.screenPosition;
      Player localPlayer = player1[player2];
      float num2 = (float) mouseTextColor / (float) byte.MaxValue;
      if (localPlayer.team == 0)
        return;
      DynamicSpriteFont font = FontAssets.MouseText.Value;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (index != player2)
        {
          Player player3 = player1[index];
          if (player3.active && !player3.dead && player3.team == localPlayer.team)
          {
            string name = player3.name;
            Vector2 namePlatePos;
            float namePlateDist;
            Vector2 measurement;
            NewMultiplayerClosePlayersOverlay.GetDistance(screenWidth, screenHeight, screenPosition1, localPlayer, font, player3, name, out namePlatePos, out namePlateDist, out measurement);
            Color color = new Color((int) (byte) ((double) teamColor[player3.team].R * (double) num2), (int) (byte) ((double) teamColor[player3.team].G * (double) num2), (int) (byte) ((double) teamColor[player3.team].B * (double) num2), (int) mouseTextColor);
            if ((double) namePlateDist > 0.0)
            {
              float num3 = player3.Distance(localPlayer.Center);
              if ((double) num3 <= (double) num1)
              {
                float num4 = 20f;
                float num5 = -27f - (float) (((double) measurement.X - 85.0) / 2.0);
                string textValue = Language.GetTextValue("GameUI.PlayerDistance", (object) (int) ((double) num3 / 16.0 * 2.0));
                Vector2 npDistPos = font.MeasureString(textValue);
                npDistPos.X = namePlatePos.X - num5;
                npDistPos.Y = (float) ((double) namePlatePos.Y + (double) measurement.Y / 2.0 - (double) npDistPos.Y / 2.0) - num4;
                this._playerOffScreenCache.Add(new NewMultiplayerClosePlayersOverlay.PlayerOffScreenCache(name, namePlatePos, color, npDistPos, textValue, player3, measurement));
              }
            }
            else
              this._playerOnScreenCache.Add(new NewMultiplayerClosePlayersOverlay.PlayerOnScreenCache(name, namePlatePos, color));
          }
        }
      }
      spriteBatch.End();
      spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, Main.UIScaleMatrix);
      for (int index = 0; index < this._playerOnScreenCache.Count; ++index)
        this._playerOnScreenCache[index].DrawPlayerName_WhenPlayerIsOnScreen(spriteBatch);
      NewMultiplayerClosePlayersOverlay.PlayerOffScreenCache playerOffScreenCache;
      for (int index = 0; index < this._playerOffScreenCache.Count; ++index)
      {
        playerOffScreenCache = this._playerOffScreenCache[index];
        playerOffScreenCache.DrawPlayerName(spriteBatch);
      }
      for (int index = 0; index < this._playerOffScreenCache.Count; ++index)
      {
        playerOffScreenCache = this._playerOffScreenCache[index];
        playerOffScreenCache.DrawPlayerDistance(spriteBatch);
      }
      spriteBatch.End();
      spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, Main.UIScaleMatrix);
      for (int index = 0; index < this._playerOffScreenCache.Count; ++index)
      {
        playerOffScreenCache = this._playerOffScreenCache[index];
        playerOffScreenCache.DrawLifeBar();
      }
      spriteBatch.End();
      spriteBatch.Begin(SpriteSortMode.Immediate, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, Main.UIScaleMatrix);
      for (int index = 0; index < this._playerOffScreenCache.Count; ++index)
      {
        playerOffScreenCache = this._playerOffScreenCache[index];
        playerOffScreenCache.DrawPlayerHead();
      }
    }

    private static void GetDistance(
      int testWidth,
      int testHeight,
      Vector2 testPosition,
      Player localPlayer,
      DynamicSpriteFont font,
      Player player,
      string nameToShow,
      out Vector2 namePlatePos,
      out float namePlateDist,
      out Vector2 measurement)
    {
      float uiScale = Main.UIScale;
      SpriteViewMatrix gameViewMatrix = Main.GameViewMatrix;
      namePlatePos = font.MeasureString(nameToShow);
      float num1 = 0.0f;
      if (player.chatOverhead.timeLeft > 0)
        num1 = -namePlatePos.Y * uiScale;
      else if (player.emoteTime > 0)
        num1 = -namePlatePos.Y * uiScale;
      Vector2 vector2_1 = new Vector2((float) (testWidth / 2) + testPosition.X, (float) (testHeight / 2) + testPosition.Y);
      Vector2 position = player.position;
      Vector2 vector2_2 = position + (position - vector2_1) * (gameViewMatrix.Zoom - Vector2.One);
      namePlateDist = 0.0f;
      float num2 = vector2_2.X + (float) (player.width / 2) - vector2_1.X;
      float num3 = (float) ((double) vector2_2.Y - (double) namePlatePos.Y - 2.0) + num1 - vector2_1.Y;
      float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
      int num5 = testHeight;
      if (testHeight > testWidth)
        num5 = testWidth;
      int num6 = num5 / 2 - 50;
      if (num6 < 100)
        num6 = 100;
      if ((double) num4 < (double) num6)
      {
        namePlatePos.X = (float) ((double) vector2_2.X + (double) (player.width / 2) - (double) namePlatePos.X / 2.0) - testPosition.X;
        namePlatePos.Y = (float) ((double) vector2_2.Y - (double) namePlatePos.Y - 2.0) + num1 - testPosition.Y;
      }
      else
      {
        namePlateDist = num4;
        float num7 = (float) num6 / num4;
        namePlatePos.X = (float) ((double) (testWidth / 2) + (double) num2 * (double) num7 - (double) namePlatePos.X / 2.0);
        namePlatePos.Y = (float) ((double) (testHeight / 2) + (double) num3 * (double) num7 + 40.0 * (double) uiScale);
      }
      measurement = font.MeasureString(nameToShow);
      namePlatePos += measurement / 2f;
      namePlatePos *= 1f / uiScale;
      namePlatePos -= measurement / 2f;
      if ((double) localPlayer.gravDir != -1.0)
        return;
      namePlatePos.Y = (float) testHeight - namePlatePos.Y;
    }

    private struct PlayerOnScreenCache
    {
      private string _name;
      private Vector2 _pos;
      private Color _color;

      public PlayerOnScreenCache(string name, Vector2 pos, Color color)
      {
        this._name = name;
        this._pos = pos;
        this._color = color;
      }

      public void DrawPlayerName_WhenPlayerIsOnScreen(SpriteBatch spriteBatch)
      {
        this._pos = this._pos.Floor();
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this._name, new Vector2(this._pos.X - 2f, this._pos.Y), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this._name, new Vector2(this._pos.X + 2f, this._pos.Y), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this._name, new Vector2(this._pos.X, this._pos.Y - 2f), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this._name, new Vector2(this._pos.X, this._pos.Y + 2f), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this._name, this._pos, this._color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      }
    }

    private struct PlayerOffScreenCache
    {
      private Player player;
      private string nameToShow;
      private Vector2 namePlatePos;
      private Color namePlateColor;
      private Vector2 distanceDrawPosition;
      private string distanceString;
      private Vector2 measurement;

      public PlayerOffScreenCache(
        string name,
        Vector2 pos,
        Color color,
        Vector2 npDistPos,
        string npDist,
        Player thePlayer,
        Vector2 theMeasurement)
      {
        this.nameToShow = name;
        this.namePlatePos = pos.Floor();
        this.namePlateColor = color;
        this.distanceDrawPosition = npDistPos.Floor();
        this.distanceString = npDist;
        this.player = thePlayer;
        this.measurement = theMeasurement;
      }

      public void DrawPlayerName(SpriteBatch spriteBatch) => ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, this.nameToShow, this.namePlatePos + new Vector2(0.0f, -40f), this.namePlateColor, 0.0f, Vector2.Zero, Vector2.One);

      public void DrawPlayerHead()
      {
        float num1 = 20f;
        float num2 = -27f - (float) (((double) this.measurement.X - 85.0) / 2.0);
        Color headBordersColor = Main.GetPlayerHeadBordersColor(this.player);
        Vector2 vec = new Vector2(this.namePlatePos.X, this.namePlatePos.Y - num1);
        vec.X -= 22f + num2;
        vec.Y += 8f;
        Vector2 position = vec.Floor();
        Main.MapPlayerRenderer.DrawPlayerHead(Main.Camera, this.player, position, scale: 0.8f, borderColor: headBordersColor);
      }

      public void DrawLifeBar()
      {
        Vector2 vector2 = Main.screenPosition + this.distanceDrawPosition + new Vector2(26f, 20f);
        if (this.player.statLife == this.player.statLifeMax2)
          return;
        Main.instance.DrawHealthBar(vector2.X, vector2.Y, this.player.statLife, this.player.statLifeMax2, 1f, 1.25f, true);
      }

      public void DrawPlayerDistance(SpriteBatch spriteBatch)
      {
        float num = 0.85f;
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this.distanceString, new Vector2(this.distanceDrawPosition.X - 2f, this.distanceDrawPosition.Y), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this.distanceString, new Vector2(this.distanceDrawPosition.X + 2f, this.distanceDrawPosition.Y), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this.distanceString, new Vector2(this.distanceDrawPosition.X, this.distanceDrawPosition.Y - 2f), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this.distanceString, new Vector2(this.distanceDrawPosition.X, this.distanceDrawPosition.Y + 2f), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, this.distanceString, this.distanceDrawPosition, this.namePlateColor, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      }
    }
  }
}
