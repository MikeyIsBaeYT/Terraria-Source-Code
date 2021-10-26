// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlayerDrawHeadLayers
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.ID;

namespace Terraria.DataStructures
{
  public static class PlayerDrawHeadLayers
  {
    public static void DrawPlayer_0_(ref PlayerDrawHeadSet drawinfo)
    {
    }

    public static void DrawPlayer_00_BackHelmet(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.drawPlayer.head < 0 || drawinfo.drawPlayer.head >= 266)
        return;
      int index = ArmorIDs.Head.Sets.FrontToBackID[drawinfo.drawPlayer.head];
      if (index < 0)
        return;
      Rectangle hairFrame = drawinfo.HairFrame;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, TextureAssets.ArmorHead[index].Value, drawinfo.helmetOffset + new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_01_FaceSkin(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.drawPlayer.head == 38 || drawinfo.drawPlayer.head == 135 || drawinfo.drawPlayer.isHatRackDoll)
        return;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.skinDyePacked, TextureAssets.Players[drawinfo.skinVar, 0].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, TextureAssets.Players[drawinfo.skinVar, 1].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorEyeWhites, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, TextureAssets.Players[drawinfo.skinVar, 2].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorEyes, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      if (!drawinfo.drawPlayer.yoraiz0rDarkness)
        return;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.skinDyePacked, TextureAssets.Extra[67].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_02_DrawArmorWithFullHair(ref PlayerDrawHeadSet drawinfo)
    {
      if (!drawinfo.fullHair)
        return;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, TextureAssets.ArmorHead[drawinfo.drawPlayer.head].Value, drawinfo.helmetOffset + new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.HairFrame), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      if (drawinfo.drawPlayer.invis || drawinfo.hideHair)
        return;
      Rectangle hairFrame = drawinfo.HairFrame;
      hairFrame.Y -= 336;
      if (hairFrame.Y < 0)
        hairFrame.Y = 0;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.hairShaderPacked, TextureAssets.PlayerHair[drawinfo.drawPlayer.hair].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorHair, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_03_HelmetHair(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.hideHair || !drawinfo.hatHair)
        return;
      Rectangle hairFrame = drawinfo.HairFrame;
      hairFrame.Y -= 336;
      if (hairFrame.Y < 0)
        hairFrame.Y = 0;
      if (drawinfo.drawPlayer.invis)
        return;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.hairShaderPacked, TextureAssets.PlayerHairAlt[drawinfo.drawPlayer.hair].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorHair, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_04_RabbitOrder(ref PlayerDrawHeadSet drawinfo)
    {
      int verticalFrames = 27;
      Texture2D texture2D = TextureAssets.ArmorHead[drawinfo.drawPlayer.head].Value;
      Rectangle r = texture2D.Frame(verticalFrames: verticalFrames, frameY: drawinfo.drawPlayer.rabbitOrderFrame.DisplayFrame);
      Vector2 origin = r.Size() / 2f;
      int usedGravDir = 1;
      Vector2 hatDrawPosition = PlayerDrawHeadLayers.DrawPlayer_04_GetHatDrawPosition(ref drawinfo, new Vector2(1f, -26f), usedGravDir);
      int hatStacks = PlayerDrawHeadLayers.DrawPlayer_04_GetHatStacks(ref drawinfo, 4955);
      float num1 = (float) Math.PI / 60f;
      float num2 = (float) ((double) num1 * (double) drawinfo.drawPlayer.position.X % 6.28318548202515);
      for (int index = hatStacks - 1; index >= 0; --index)
      {
        float x = (float) ((double) Vector2.UnitY.RotatedBy((double) num2 + (double) num1 * (double) index).X * ((double) index / 30.0) * 2.0) - (float) (index * 2 * drawinfo.drawPlayer.direction);
        PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, texture2D, hatDrawPosition + new Vector2(x, (float) (index * -14) * drawinfo.scale), new Rectangle?(r), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, origin, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      }
      if (drawinfo.drawPlayer.invis || drawinfo.hideHair)
        return;
      Rectangle hairFrame = drawinfo.HairFrame;
      hairFrame.Y -= 336;
      if (hairFrame.Y < 0)
        hairFrame.Y = 0;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.hairShaderPacked, TextureAssets.PlayerHair[drawinfo.drawPlayer.hair].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorHair, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_04_BadgersHat(ref PlayerDrawHeadSet drawinfo)
    {
      int verticalFrames = 6;
      Texture2D texture2D = TextureAssets.ArmorHead[drawinfo.drawPlayer.head].Value;
      Rectangle r = texture2D.Frame(verticalFrames: verticalFrames, frameY: drawinfo.drawPlayer.rabbitOrderFrame.DisplayFrame);
      Vector2 origin = r.Size() / 2f;
      int usedGravDir = 1;
      Vector2 hatDrawPosition = PlayerDrawHeadLayers.DrawPlayer_04_GetHatDrawPosition(ref drawinfo, new Vector2(0.0f, -9f), usedGravDir);
      int hatStacks = PlayerDrawHeadLayers.DrawPlayer_04_GetHatStacks(ref drawinfo, 5004);
      float num1 = (float) Math.PI / 60f;
      float num2 = (float) ((double) num1 * (double) drawinfo.drawPlayer.position.X % 6.28318548202515);
      int num3 = hatStacks * 4 + 2;
      int num4 = 0;
      bool flag = ((double) Main.GlobalTimeWrappedHourly + 180.0) % 3600.0 < 60.0;
      for (int index = num3 - 1; index >= 0; --index)
      {
        int num5 = 0;
        if (index == num3 - 1)
        {
          r.Y = 0;
          num5 = 2;
        }
        else
          r.Y = index != 0 ? r.Height * (num4++ % 4 + 1) : r.Height * 5;
        if (!(r.Y == r.Height * 3 & flag))
        {
          float x = (float) ((double) Vector2.UnitY.RotatedBy((double) num2 + (double) num1 * (double) index).X * ((double) index / 10.0) * 4.0 - (double) index * 0.100000001490116 * (double) drawinfo.drawPlayer.direction);
          PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, texture2D, hatDrawPosition + new Vector2(x, (float) ((index * -4 + num5) * usedGravDir)) * drawinfo.scale, new Rectangle?(r), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, origin, drawinfo.scale, drawinfo.playerEffect, 0.0f);
        }
      }
    }

    private static Vector2 DrawPlayer_04_GetHatDrawPosition(
      ref PlayerDrawHeadSet drawinfo,
      Vector2 hatOffset,
      int usedGravDir)
    {
      Vector2 vector2 = new Vector2((float) drawinfo.drawPlayer.direction, (float) usedGravDir);
      return drawinfo.Position - Main.screenPosition + new Vector2((float) (-drawinfo.bodyFrameMemory.Width / 2 + drawinfo.drawPlayer.width / 2), (float) (drawinfo.drawPlayer.height - drawinfo.bodyFrameMemory.Height + 4)) + hatOffset * vector2 * drawinfo.scale + (drawinfo.drawPlayer.headPosition + drawinfo.headVect);
    }

    private static int DrawPlayer_04_GetHatStacks(ref PlayerDrawHeadSet drawinfo, int itemId)
    {
      int num = 0;
      int index1 = 0;
      if (drawinfo.drawPlayer.armor[index1] != null && drawinfo.drawPlayer.armor[index1].type == itemId && drawinfo.drawPlayer.armor[index1].stack > 0)
        num += drawinfo.drawPlayer.armor[index1].stack;
      int index2 = 10;
      if (drawinfo.drawPlayer.armor[index2] != null && drawinfo.drawPlayer.armor[index2].type == itemId && drawinfo.drawPlayer.armor[index2].stack > 0)
        num += drawinfo.drawPlayer.armor[index2].stack;
      return num;
    }

    public static void DrawPlayer_04_JungleRose(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.drawPlayer.head == 259)
      {
        PlayerDrawHeadLayers.DrawPlayer_04_RabbitOrder(ref drawinfo);
      }
      else
      {
        if (!drawinfo.helmetIsOverFullHair)
          return;
        if (!drawinfo.drawPlayer.invis && !drawinfo.hideHair)
        {
          Rectangle hairFrame = drawinfo.HairFrame;
          hairFrame.Y -= 336;
          if (hairFrame.Y < 0)
            hairFrame.Y = 0;
          PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.hairShaderPacked, TextureAssets.PlayerHair[drawinfo.drawPlayer.hair].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorHair, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
        }
        if (drawinfo.drawPlayer.head == 0)
          return;
        PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, TextureAssets.ArmorHead[drawinfo.drawPlayer.head].Value, drawinfo.helmetOffset + new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      }
    }

    public static void DrawPlayer_05_TallHats(ref PlayerDrawHeadSet drawinfo)
    {
      if (!drawinfo.helmetIsTall)
        return;
      Rectangle hairFrame = drawinfo.HairFrame;
      if (drawinfo.drawPlayer.head == 158)
        hairFrame.Height -= 2;
      int num = 0;
      if (hairFrame.Y == hairFrame.Height * 6)
        hairFrame.Height -= 2;
      else if (hairFrame.Y == hairFrame.Height * 7)
        num = -2;
      else if (hairFrame.Y == hairFrame.Height * 8)
        num = -2;
      else if (hairFrame.Y == hairFrame.Height * 9)
        num = -2;
      else if (hairFrame.Y == hairFrame.Height * 10)
        num = -2;
      else if (hairFrame.Y == hairFrame.Height * 13)
        hairFrame.Height -= 2;
      else if (hairFrame.Y == hairFrame.Height * 14)
        num = -2;
      else if (hairFrame.Y == hairFrame.Height * 15)
        num = -2;
      else if (hairFrame.Y == hairFrame.Height * 16)
        num = -2;
      hairFrame.Y += num;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, TextureAssets.ArmorHead[drawinfo.drawPlayer.head].Value, drawinfo.helmetOffset + new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0) + (float) num) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_06_NormalHats(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.drawPlayer.head == 265)
      {
        PlayerDrawHeadLayers.DrawPlayer_04_BadgersHat(ref drawinfo);
      }
      else
      {
        if (!drawinfo.helmetIsNormal)
          return;
        Rectangle hairFrame = drawinfo.HairFrame;
        PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cHead, TextureAssets.ArmorHead[drawinfo.drawPlayer.head].Value, drawinfo.helmetOffset + new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      }
    }

    public static void DrawPlayer_07_JustHair(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.helmetIsNormal || drawinfo.helmetIsOverFullHair || drawinfo.helmetIsTall || drawinfo.hideHair)
        return;
      if (drawinfo.drawPlayer.face == (sbyte) 5)
        PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cFace, TextureAssets.AccFace[(int) drawinfo.drawPlayer.face].Value, new Vector2((float) (int) ((double) drawinfo.Position.X - (double) Main.screenPosition.X - (double) (drawinfo.bodyFrameMemory.Width / 2) + (double) (drawinfo.drawPlayer.width / 2)), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      Rectangle hairFrame = drawinfo.HairFrame;
      hairFrame.Y -= 336;
      if (hairFrame.Y < 0)
        hairFrame.Y = 0;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.hairShaderPacked, TextureAssets.PlayerHair[drawinfo.drawPlayer.hair].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(hairFrame), drawinfo.colorHair, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_08_FaceAcc(ref PlayerDrawHeadSet drawinfo)
    {
      if (drawinfo.drawPlayer.face > (sbyte) 0 && drawinfo.drawPlayer.face < (sbyte) 16 && drawinfo.drawPlayer.face != (sbyte) 5)
      {
        if (drawinfo.drawPlayer.face == (sbyte) 7)
        {
          Color color = new Color(200, 200, 200, 150);
          PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cFace, TextureAssets.AccFace[(int) drawinfo.drawPlayer.face].Value, new Vector2((float) (int) ((double) drawinfo.Position.X - (double) Main.screenPosition.X - (double) (drawinfo.bodyFrameMemory.Width / 2) + (double) (drawinfo.drawPlayer.width / 2)), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), new Color(200, 200, 200, 200), drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
        }
        else
          PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cFace, TextureAssets.AccFace[(int) drawinfo.drawPlayer.face].Value, new Vector2((float) (int) ((double) drawinfo.Position.X - (double) Main.screenPosition.X - (double) (drawinfo.bodyFrameMemory.Width / 2) + (double) (drawinfo.drawPlayer.width / 2)), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
      }
      if (!drawinfo.drawUnicornHorn)
        return;
      PlayerDrawHeadLayers.QuickCDD(drawinfo.DrawData, drawinfo.cUnicornHorn, TextureAssets.Extra[143].Value, new Vector2(drawinfo.Position.X - Main.screenPosition.X - (float) (drawinfo.bodyFrameMemory.Width / 2) + (float) (drawinfo.drawPlayer.width / 2), (float) ((double) drawinfo.Position.Y - (double) Main.screenPosition.Y + (double) drawinfo.drawPlayer.height - (double) drawinfo.bodyFrameMemory.Height + 4.0)) + drawinfo.drawPlayer.headPosition + drawinfo.headVect, new Rectangle?(drawinfo.bodyFrameMemory), drawinfo.colorArmorHead, drawinfo.drawPlayer.headRotation, drawinfo.headVect, drawinfo.scale, drawinfo.playerEffect, 0.0f);
    }

    public static void DrawPlayer_RenderAllLayers(ref PlayerDrawHeadSet drawinfo)
    {
      List<DrawData> drawData = drawinfo.DrawData;
      Effect pixelShader = Main.pixelShader;
      Projectile[] projectile = Main.projectile;
      SpriteBatch spriteBatch = Main.spriteBatch;
      for (int index = 0; index < drawData.Count; ++index)
      {
        DrawData cdd = drawData[index];
        if (!cdd.sourceRect.HasValue)
          cdd.sourceRect = new Rectangle?(cdd.texture.Frame());
        PlayerDrawHelper.SetShaderForData(drawinfo.drawPlayer, drawinfo.cHead, ref cdd);
        if (cdd.texture != null)
          cdd.Draw(spriteBatch);
      }
      pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public static void DrawPlayer_DrawSelectionRect(ref PlayerDrawHeadSet drawinfo)
    {
      Vector2 lowest;
      Vector2 highest;
      SpriteRenderTargetHelper.GetDrawBoundary(drawinfo.DrawData, out lowest, out highest);
      Utils.DrawRect(Main.spriteBatch, lowest + Main.screenPosition, highest + Main.screenPosition, Color.White);
    }

    public static void QuickCDD(
      List<DrawData> drawData,
      Texture2D texture,
      Vector2 position,
      Rectangle? sourceRectangle,
      Color color,
      float rotation,
      Vector2 origin,
      float scale,
      SpriteEffects effects,
      float layerDepth)
    {
      drawData.Add(new DrawData(texture, position, sourceRectangle, color, rotation, origin, scale, effects, 0));
    }

    public static void QuickCDD(
      List<DrawData> drawData,
      int shaderTechnique,
      Texture2D texture,
      Vector2 position,
      Rectangle? sourceRectangle,
      Color color,
      float rotation,
      Vector2 origin,
      float scale,
      SpriteEffects effects,
      float layerDepth)
    {
      drawData.Add(new DrawData(texture, position, sourceRectangle, color, rotation, origin, scale, effects, 0)
      {
        shader = shaderTechnique
      });
    }
  }
}
