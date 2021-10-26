// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.LegacyMultiplayerClosePlayersOverlay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.Graphics.Renderers;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI
{
  public class LegacyMultiplayerClosePlayersOverlay : IMultiplayerClosePlayersOverlay
  {
    public void Draw()
    {
      int namePlateDistance = Main.teamNamePlateDistance;
      if (namePlateDistance <= 0)
        return;
      SpriteBatch spriteBatch = Main.spriteBatch;
      spriteBatch.End();
      spriteBatch.Begin(SpriteSortMode.Immediate, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, Main.UIScaleMatrix);
      PlayerInput.SetZoom_World();
      int screenWidth = Main.screenWidth;
      int screenHeight = Main.screenHeight;
      Vector2 screenPosition1 = Main.screenPosition;
      PlayerInput.SetZoom_UI();
      float uiScale = Main.UIScale;
      int num1 = namePlateDistance * 8;
      Player[] player1 = Main.player;
      int player2 = Main.myPlayer;
      SpriteViewMatrix gameViewMatrix = Main.GameViewMatrix;
      byte mouseTextColor = Main.mouseTextColor;
      Color[] teamColor = Main.teamColor;
      Camera camera = Main.Camera;
      IPlayerRenderer playerRenderer = Main.PlayerRenderer;
      Vector2 screenPosition2 = Main.screenPosition;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (player1[index].active && player2 != index && !player1[index].dead && player1[player2].team > 0 && player1[player2].team == player1[index].team)
        {
          string name = player1[index].name;
          Vector2 namePlatePos = FontAssets.MouseText.Value.MeasureString(name);
          float num2 = 0.0f;
          if (player1[index].chatOverhead.timeLeft > 0)
            num2 = -namePlatePos.Y * uiScale;
          else if (player1[index].emoteTime > 0)
            num2 = -namePlatePos.Y * uiScale;
          Vector2 vector2_1 = new Vector2((float) (screenWidth / 2) + screenPosition1.X, (float) (screenHeight / 2) + screenPosition1.Y);
          Vector2 position1 = player1[index].position;
          Vector2 vector2_2 = position1 + (position1 - vector2_1) * (gameViewMatrix.Zoom - Vector2.One);
          float num3 = 0.0f;
          float num4 = (float) mouseTextColor / (float) byte.MaxValue;
          Color namePlateColor = new Color((int) (byte) ((double) teamColor[player1[index].team].R * (double) num4), (int) (byte) ((double) teamColor[player1[index].team].G * (double) num4), (int) (byte) ((double) teamColor[player1[index].team].B * (double) num4), (int) mouseTextColor);
          float num5 = vector2_2.X + (float) (player1[index].width / 2) - vector2_1.X;
          float num6 = (float) ((double) vector2_2.Y - (double) namePlatePos.Y - 2.0) + num2 - vector2_1.Y;
          float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
          int num8 = screenHeight;
          if (screenHeight > screenWidth)
            num8 = screenWidth;
          int num9 = num8 / 2 - 50;
          if (num9 < 100)
            num9 = 100;
          if ((double) num7 < (double) num9)
          {
            namePlatePos.X = (float) ((double) vector2_2.X + (double) (player1[index].width / 2) - (double) namePlatePos.X / 2.0) - screenPosition1.X;
            namePlatePos.Y = (float) ((double) vector2_2.Y - (double) namePlatePos.Y - 2.0) + num2 - screenPosition1.Y;
          }
          else
          {
            num3 = num7;
            float num10 = (float) num9 / num7;
            namePlatePos.X = (float) ((double) (screenWidth / 2) + (double) num5 * (double) num10 - (double) namePlatePos.X / 2.0);
            namePlatePos.Y = (float) ((double) (screenHeight / 2) + (double) num6 * (double) num10 + 40.0 * (double) uiScale);
          }
          Vector2 vector2_3 = FontAssets.MouseText.Value.MeasureString(name);
          namePlatePos += vector2_3 / 2f;
          namePlatePos *= 1f / uiScale;
          namePlatePos -= vector2_3 / 2f;
          if ((double) player1[player2].gravDir == -1.0)
            namePlatePos.Y = (float) screenHeight - namePlatePos.Y;
          if ((double) num3 > 0.0)
          {
            float num11 = 20f;
            float num12 = -27f - (float) (((double) vector2_3.X - 85.0) / 2.0);
            float num13 = player1[index].Center.X - player1[player2].Center.X;
            float num14 = player1[index].Center.Y - player1[player2].Center.Y;
            float num15 = (float) Math.Sqrt((double) num13 * (double) num13 + (double) num14 * (double) num14);
            if ((double) num15 <= (double) num1)
            {
              string textValue = Language.GetTextValue("GameUI.PlayerDistance", (object) (int) ((double) num15 / 16.0 * 2.0));
              Vector2 npDistPos = FontAssets.MouseText.Value.MeasureString(textValue);
              npDistPos.X = namePlatePos.X - num12;
              npDistPos.Y = (float) ((double) namePlatePos.Y + (double) vector2_3.Y / 2.0 - (double) npDistPos.Y / 2.0) - num11;
              LegacyMultiplayerClosePlayersOverlay.DrawPlayerName2(spriteBatch, ref namePlateColor, textValue, ref npDistPos);
              Color headBordersColor = Main.GetPlayerHeadBordersColor(player1[index]);
              Vector2 position2 = new Vector2(namePlatePos.X, namePlatePos.Y - num11);
              position2.X -= 22f + num12;
              position2.Y += 8f;
              playerRenderer.DrawPlayerHead(camera, player1[index], position2, scale: 0.8f, borderColor: headBordersColor);
              Vector2 vector2_4 = npDistPos + screenPosition2 + new Vector2(26f, 20f);
              if (player1[index].statLife != player1[index].statLifeMax2)
                Main.instance.DrawHealthBar(vector2_4.X, vector2_4.Y, player1[index].statLife, player1[index].statLifeMax2, 1f, 1.25f, true);
              ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, name, namePlatePos + new Vector2(0.0f, -40f), namePlateColor, 0.0f, Vector2.Zero, Vector2.One);
            }
          }
          else
            LegacyMultiplayerClosePlayersOverlay.DrawPlayerName(spriteBatch, name, ref namePlatePos, ref namePlateColor);
        }
      }
    }

    private static void DrawPlayerName2(
      SpriteBatch spriteBatch,
      ref Color namePlateColor,
      string npDist,
      ref Vector2 npDistPos)
    {
      float num = 0.85f;
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, npDist, new Vector2(npDistPos.X - 2f, npDistPos.Y), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, npDist, new Vector2(npDistPos.X + 2f, npDistPos.Y), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, npDist, new Vector2(npDistPos.X, npDistPos.Y - 2f), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, npDist, new Vector2(npDistPos.X, npDistPos.Y + 2f), Color.Black, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, npDist, npDistPos, namePlateColor, 0.0f, new Vector2(), num, SpriteEffects.None, 0.0f);
    }

    private static void DrawPlayerName(
      SpriteBatch spriteBatch,
      string namePlate,
      ref Vector2 namePlatePos,
      ref Color namePlateColor)
    {
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, namePlate, new Vector2(namePlatePos.X - 2f, namePlatePos.Y), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, namePlate, new Vector2(namePlatePos.X + 2f, namePlatePos.Y), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, namePlate, new Vector2(namePlatePos.X, namePlatePos.Y - 2f), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, namePlate, new Vector2(namePlatePos.X, namePlatePos.Y + 2f), Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, namePlate, namePlatePos, namePlateColor, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
    }
  }
}
