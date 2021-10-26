// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.LegacyPlayerRenderer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;

namespace Terraria.Graphics.Renderers
{
  public class LegacyPlayerRenderer : IPlayerRenderer
  {
    private readonly List<DrawData> _drawData = new List<DrawData>();
    private readonly List<int> _dust = new List<int>();
    private readonly List<int> _gore = new List<int>();

    public static SamplerState MountedSamplerState => !Main.drawToScreen ? SamplerState.AnisotropicClamp : SamplerState.LinearClamp;

    public void DrawPlayers(Camera camera, IEnumerable<Player> players)
    {
      foreach (Player player in players)
        this.DrawPlayerFull(camera, player);
    }

    public void DrawPlayerHead(
      Camera camera,
      Player drawPlayer,
      Vector2 position,
      float alpha = 1f,
      float scale = 1f,
      Color borderColor = default (Color))
    {
      this._drawData.Clear();
      this._dust.Clear();
      this._gore.Clear();
      PlayerDrawHeadSet drawinfo = new PlayerDrawHeadSet();
      drawinfo.BoringSetup(drawPlayer, this._drawData, this._dust, this._gore, position.X, position.Y, alpha, scale);
      PlayerDrawHeadLayers.DrawPlayer_00_BackHelmet(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_01_FaceSkin(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_02_DrawArmorWithFullHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_03_HelmetHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_04_JungleRose(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_05_TallHats(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_06_NormalHats(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_07_JustHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_08_FaceAcc(ref drawinfo);
      this.CreateOutlines(alpha, scale, borderColor);
      PlayerDrawHeadLayers.DrawPlayer_RenderAllLayers(ref drawinfo);
    }

    private void CreateOutlines(float alpha, float scale, Color borderColor)
    {
      if (!(borderColor != Color.Transparent))
        return;
      List<DrawData> drawDataList1 = new List<DrawData>((IEnumerable<DrawData>) this._drawData);
      List<DrawData> drawDataList2 = new List<DrawData>((IEnumerable<DrawData>) this._drawData);
      float num1 = 2f * scale;
      Color color1 = borderColor * (alpha * alpha);
      Color color2 = Color.Black * (alpha * alpha);
      int colorOnlyShaderIndex = ContentSamples.CommonlyUsedContentSamples.ColorOnlyShaderIndex;
      for (int index = 0; index < drawDataList2.Count; ++index)
      {
        DrawData drawData = drawDataList2[index];
        drawData.shader = colorOnlyShaderIndex;
        drawData.color = color2;
        drawDataList2[index] = drawData;
      }
      int num2 = 2;
      for (int index1 = -num2; index1 <= num2; ++index1)
      {
        for (int index2 = -num2; index2 <= num2; ++index2)
        {
          if (Math.Abs(index1) + Math.Abs(index2) == num2)
          {
            Vector2 vector2 = new Vector2((float) index1 * num1, (float) index2 * num1);
            for (int index3 = 0; index3 < drawDataList2.Count; ++index3)
            {
              DrawData drawData = drawDataList2[index3];
              drawData.position += vector2;
              this._drawData.Add(drawData);
            }
          }
        }
      }
      for (int index = 0; index < drawDataList2.Count; ++index)
      {
        DrawData drawData = drawDataList2[index];
        drawData.shader = colorOnlyShaderIndex;
        drawData.color = color1;
        drawDataList2[index] = drawData;
      }
      Vector2 vector2_1 = Vector2.Zero;
      int num3 = 1;
      for (int index4 = -num3; index4 <= num3; ++index4)
      {
        for (int index5 = -num3; index5 <= num3; ++index5)
        {
          if (Math.Abs(index4) + Math.Abs(index5) == num3)
          {
            vector2_1 = new Vector2((float) index4 * num1, (float) index5 * num1);
            for (int index6 = 0; index6 < drawDataList2.Count; ++index6)
            {
              DrawData drawData = drawDataList2[index6];
              drawData.position += vector2_1;
              this._drawData.Add(drawData);
            }
          }
        }
      }
      this._drawData.AddRange((IEnumerable<DrawData>) drawDataList1);
    }

    public void DrawPlayer(
      Camera camera,
      Player drawPlayer,
      Vector2 position,
      float rotation,
      Vector2 rotationOrigin,
      float shadow = 0.0f,
      float scale = 1f)
    {
      if (drawPlayer.ShouldNotDraw)
        return;
      PlayerDrawSet drawinfo = new PlayerDrawSet();
      this._drawData.Clear();
      this._dust.Clear();
      this._gore.Clear();
      drawinfo.BoringSetup(drawPlayer, this._drawData, this._dust, this._gore, position, shadow, rotation, rotationOrigin);
      PlayerDrawLayers.DrawPlayer_extra_TorsoPlus(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_01_BackHair(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_01_2_JimsCloak(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_01_3_BackHead(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_extra_TorsoMinus(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_02_MountBehindPlayer(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_03_Carpet(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_03_PortableStool(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_extra_TorsoPlus(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_04_ElectrifiedDebuffBack(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_05_ForbiddenSetRing(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_05_2_SafemanSun(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_06_WebbedDebuffBack(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_07_LeinforsHairShampoo(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_extra_TorsoMinus(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_08_Backpacks(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_09_BackAc(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_10_Wings(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_11_Balloons(ref drawinfo);
      if (drawinfo.weaponDrawOrder == WeaponDrawOrder.BehindBackArm)
        PlayerDrawLayers.DrawPlayer_27_HeldItem(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_12_Skin(ref drawinfo);
      if (drawinfo.drawPlayer.wearsRobe && drawinfo.drawPlayer.body != 166)
      {
        PlayerDrawLayers.DrawPlayer_14_Shoes(ref drawinfo);
        PlayerDrawLayers.DrawPlayer_13_Leggings(ref drawinfo);
      }
      else
      {
        PlayerDrawLayers.DrawPlayer_13_Leggings(ref drawinfo);
        PlayerDrawLayers.DrawPlayer_14_Shoes(ref drawinfo);
      }
      PlayerDrawLayers.DrawPlayer_extra_TorsoPlus(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_15_SkinLongCoat(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_16_ArmorLongCoat(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_17_Torso(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_18_OffhandAcc(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_19_WaistAcc(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_20_NeckAcc(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_21_Head(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_22_FaceAcc(ref drawinfo);
      if (drawinfo.drawFrontAccInNeckAccLayer)
      {
        PlayerDrawLayers.DrawPlayer_extra_TorsoMinus(ref drawinfo);
        PlayerDrawLayers.DrawPlayer_32_FrontAcc(ref drawinfo);
        PlayerDrawLayers.DrawPlayer_extra_TorsoPlus(ref drawinfo);
      }
      PlayerDrawLayers.DrawPlayer_23_MountFront(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_24_Pulley(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_25_Shield(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_extra_MountPlus(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_26_SolarShield(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_extra_MountMinus(ref drawinfo);
      if (drawinfo.weaponDrawOrder == WeaponDrawOrder.BehindFrontArm)
        PlayerDrawLayers.DrawPlayer_27_HeldItem(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_28_ArmOverItem(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_29_OnhandAcc(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_30_BladedGlove(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_extra_TorsoMinus(ref drawinfo);
      if (!drawinfo.drawFrontAccInNeckAccLayer)
        PlayerDrawLayers.DrawPlayer_32_FrontAcc(ref drawinfo);
      if (drawinfo.weaponDrawOrder == WeaponDrawOrder.OverFrontArm)
        PlayerDrawLayers.DrawPlayer_27_HeldItem(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_31_ProjectileOverArm(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_33_FrozenOrWebbedDebuff(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_34_ElectrifiedDebuffFront(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_35_IceBarrier(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_36_CTG(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_37_BeetleBuff(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_MakeIntoFirstFractalAfterImage(ref drawinfo);
      PlayerDrawLayers.DrawPlayer_TransformDrawData(ref drawinfo);
      if ((double) scale != 1.0)
        PlayerDrawLayers.DrawPlayer_ScaleDrawData(ref drawinfo, scale);
      PlayerDrawLayers.DrawPlayer_RenderAllLayers(ref drawinfo);
      if (!drawinfo.drawPlayer.mount.Active || drawinfo.drawPlayer.mount.Type != 11)
        return;
      for (int i = 0; i < 1000; ++i)
      {
        if (Main.projectile[i].active && Main.projectile[i].owner == drawinfo.drawPlayer.whoAmI && Main.projectile[i].type == 591)
          Main.instance.DrawProj(i);
      }
    }

    private void DrawPlayerFull(Camera camera, Player drawPlayer)
    {
      SpriteBatch spriteBatch = camera.SpriteBatch;
      SamplerState samplerState = camera.Sampler;
      if (drawPlayer.mount.Active && (double) drawPlayer.fullRotation != 0.0)
        samplerState = LegacyPlayerRenderer.MountedSamplerState;
      spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, samplerState, DepthStencilState.None, camera.Rasterizer, (Effect) null, camera.GameViewMatrix.TransformationMatrix);
      if (Main.gamePaused)
        drawPlayer.PlayerFrame();
      if (drawPlayer.ghost)
      {
        for (int index = 0; index < 3; ++index)
        {
          Vector2 shadowPo = drawPlayer.shadowPos[index];
          Vector2 position = drawPlayer.position - drawPlayer.velocity * (float) (2 + index * 2);
          this.DrawGhost(camera, drawPlayer, position, (float) (0.5 + 0.200000002980232 * (double) index));
        }
        this.DrawGhost(camera, drawPlayer, drawPlayer.position);
      }
      else
      {
        if (drawPlayer.inventory[drawPlayer.selectedItem].flame || drawPlayer.head == 137 || drawPlayer.wings == 22)
        {
          --drawPlayer.itemFlameCount;
          if (drawPlayer.itemFlameCount <= 0)
          {
            drawPlayer.itemFlameCount = 5;
            for (int index = 0; index < 7; ++index)
            {
              drawPlayer.itemFlamePos[index].X = (float) Main.rand.Next(-10, 11) * 0.15f;
              drawPlayer.itemFlamePos[index].Y = (float) Main.rand.Next(-10, 1) * 0.35f;
            }
          }
        }
        if (drawPlayer.armorEffectDrawShadowEOCShield)
        {
          int num = drawPlayer.eocDash / 4;
          if (num > 3)
            num = 3;
          for (int index = 0; index < num; ++index)
            this.DrawPlayer(camera, drawPlayer, drawPlayer.shadowPos[index], drawPlayer.shadowRotation[index], drawPlayer.shadowOrigin[index], (float) (0.5 + 0.200000002980232 * (double) index), 1f);
        }
        Vector2 position1;
        if (drawPlayer.invis)
        {
          drawPlayer.armorEffectDrawOutlines = false;
          drawPlayer.armorEffectDrawShadow = false;
          drawPlayer.armorEffectDrawShadowSubtle = false;
          position1 = drawPlayer.position;
          if (drawPlayer.aggro <= -750)
          {
            this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, 1f, 1f);
          }
          else
          {
            drawPlayer.invis = false;
            this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, 0.0f, 1f);
            drawPlayer.invis = true;
          }
        }
        if (drawPlayer.armorEffectDrawOutlines)
        {
          Vector2 position2 = drawPlayer.position;
          if (!Main.gamePaused)
            drawPlayer.ghostFade += drawPlayer.ghostDir * 0.075f;
          if ((double) drawPlayer.ghostFade < 0.1)
          {
            drawPlayer.ghostDir = 1f;
            drawPlayer.ghostFade = 0.1f;
          }
          else if ((double) drawPlayer.ghostFade > 0.9)
          {
            drawPlayer.ghostDir = -1f;
            drawPlayer.ghostFade = 0.9f;
          }
          float num1 = drawPlayer.ghostFade * 5f;
          for (int index = 0; index < 4; ++index)
          {
            float num2;
            float num3;
            switch (index)
            {
              case 1:
                num2 = -num1;
                num3 = 0.0f;
                break;
              case 2:
                num2 = 0.0f;
                num3 = num1;
                break;
              case 3:
                num2 = 0.0f;
                num3 = -num1;
                break;
              default:
                num2 = num1;
                num3 = 0.0f;
                break;
            }
            position1 = new Vector2(drawPlayer.position.X + num2, drawPlayer.position.Y + drawPlayer.gfxOffY + num3);
            this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, drawPlayer.ghostFade, 1f);
          }
        }
        if (drawPlayer.armorEffectDrawOutlinesForbidden)
        {
          Vector2 position3 = drawPlayer.position;
          if (!Main.gamePaused)
            drawPlayer.ghostFade += drawPlayer.ghostDir * 0.025f;
          if ((double) drawPlayer.ghostFade < 0.1)
          {
            drawPlayer.ghostDir = 1f;
            drawPlayer.ghostFade = 0.1f;
          }
          else if ((double) drawPlayer.ghostFade > 0.9)
          {
            drawPlayer.ghostDir = -1f;
            drawPlayer.ghostFade = 0.9f;
          }
          float num4 = drawPlayer.ghostFade * 5f;
          for (int index = 0; index < 4; ++index)
          {
            float num5;
            float num6;
            switch (index)
            {
              case 1:
                num5 = -num4;
                num6 = 0.0f;
                break;
              case 2:
                num5 = 0.0f;
                num6 = num4;
                break;
              case 3:
                num5 = 0.0f;
                num6 = -num4;
                break;
              default:
                num5 = num4;
                num6 = 0.0f;
                break;
            }
            position1 = new Vector2(drawPlayer.position.X + num5, drawPlayer.position.Y + drawPlayer.gfxOffY + num6);
            this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, drawPlayer.ghostFade, 1f);
          }
        }
        if (drawPlayer.armorEffectDrawShadowBasilisk)
        {
          int num = (int) ((double) drawPlayer.basiliskCharge * 3.0);
          for (int index = 0; index < num; ++index)
            this.DrawPlayer(camera, drawPlayer, drawPlayer.shadowPos[index], drawPlayer.shadowRotation[index], drawPlayer.shadowOrigin[index], (float) (0.5 + 0.200000002980232 * (double) index), 1f);
        }
        else if (drawPlayer.armorEffectDrawShadow)
        {
          for (int index = 0; index < 3; ++index)
            this.DrawPlayer(camera, drawPlayer, drawPlayer.shadowPos[index], drawPlayer.shadowRotation[index], drawPlayer.shadowOrigin[index], (float) (0.5 + 0.200000002980232 * (double) index), 1f);
        }
        if (drawPlayer.armorEffectDrawShadowLokis)
        {
          for (int index = 0; index < 3; ++index)
            this.DrawPlayer(camera, drawPlayer, Vector2.Lerp(drawPlayer.shadowPos[index], drawPlayer.position + new Vector2(0.0f, drawPlayer.gfxOffY), 0.5f), drawPlayer.shadowRotation[index], drawPlayer.shadowOrigin[index], MathHelper.Lerp(1f, (float) (0.5 + 0.200000002980232 * (double) index), 0.5f), 1f);
        }
        if (drawPlayer.armorEffectDrawShadowSubtle)
        {
          for (int index = 0; index < 4; ++index)
          {
            position1.X = drawPlayer.position.X + (float) Main.rand.Next(-20, 21) * 0.1f;
            position1.Y = drawPlayer.position.Y + (float) Main.rand.Next(-20, 21) * 0.1f + drawPlayer.gfxOffY;
            this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, 0.9f, 1f);
          }
        }
        if (drawPlayer.shadowDodge)
        {
          ++drawPlayer.shadowDodgeCount;
          if ((double) drawPlayer.shadowDodgeCount > 30.0)
            drawPlayer.shadowDodgeCount = 30f;
        }
        else
        {
          --drawPlayer.shadowDodgeCount;
          if ((double) drawPlayer.shadowDodgeCount < 0.0)
            drawPlayer.shadowDodgeCount = 0.0f;
        }
        if ((double) drawPlayer.shadowDodgeCount > 0.0)
        {
          Vector2 position4 = drawPlayer.position;
          position1.X = drawPlayer.position.X + drawPlayer.shadowDodgeCount;
          position1.Y = drawPlayer.position.Y + drawPlayer.gfxOffY;
          this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, (float) (0.5 + (double) Main.rand.Next(-10, 11) * 0.00499999988824129), 1f);
          position1.X = drawPlayer.position.X - drawPlayer.shadowDodgeCount;
          this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, (float) (0.5 + (double) Main.rand.Next(-10, 11) * 0.00499999988824129), 1f);
        }
        if (drawPlayer.brainOfConfusionDodgeAnimationCounter > 0)
        {
          Vector2 vector2 = drawPlayer.position + new Vector2(0.0f, drawPlayer.gfxOffY);
          float lerpValue = Utils.GetLerpValue(300f, 270f, (float) drawPlayer.brainOfConfusionDodgeAnimationCounter, false);
          float y = MathHelper.Lerp(2f, 120f, lerpValue);
          if ((double) lerpValue >= 0.0 && (double) lerpValue <= 1.0)
          {
            for (float num = 0.0f; (double) num < 6.28318548202515; num += 1.047198f)
            {
              position1 = vector2 + new Vector2(0.0f, y).RotatedBy(6.28318548202515 * (double) lerpValue * 0.5 + (double) num);
              this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, lerpValue, 1f);
            }
          }
        }
        position1 = drawPlayer.position;
        position1.Y += drawPlayer.gfxOffY;
        if (drawPlayer.stoned)
          this.DrawPlayerStoned(camera, drawPlayer, position1);
        else if (!drawPlayer.invis)
          this.DrawPlayer(camera, drawPlayer, position1, drawPlayer.fullRotation, drawPlayer.fullRotationOrigin, 0.0f, 1f);
      }
      spriteBatch.End();
    }

    private void DrawPlayerStoned(Camera camera, Player drawPlayer, Vector2 position)
    {
      if (drawPlayer.dead)
        return;
      SpriteEffects effects = drawPlayer.direction != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
      camera.SpriteBatch.Draw(TextureAssets.Extra[37].Value, new Vector2((float) (int) ((double) position.X - (double) camera.UnscaledPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) position.Y - (double) camera.UnscaledPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 8.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(), Lighting.GetColor((int) ((double) position.X + (double) drawPlayer.width * 0.5) / 16, (int) ((double) position.Y + (double) drawPlayer.height * 0.5) / 16, Color.White), 0.0f, new Vector2((float) (TextureAssets.Extra[37].Width() / 2), (float) (TextureAssets.Extra[37].Height() / 2)), 1f, effects, 0.0f);
    }

    private void DrawGhost(Camera camera, Player drawPlayer, Vector2 position, float shadow = 0.0f)
    {
      byte mouseTextColor = Main.mouseTextColor;
      SpriteEffects effects = drawPlayer.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
      Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) ((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16, new Color((int) mouseTextColor / 2 + 100, (int) mouseTextColor / 2 + 100, (int) mouseTextColor / 2 + 100, (int) mouseTextColor / 2 + 100)), shadow);
      immuneAlpha.A = (byte) ((double) immuneAlpha.A * (1.0 - (double) Math.Max(0.5f, shadow - 0.5f)));
      Rectangle rectangle = new Rectangle(0, TextureAssets.Ghost.Height() / 4 * drawPlayer.ghostFrame, TextureAssets.Ghost.Width(), TextureAssets.Ghost.Height() / 4);
      Vector2 origin = new Vector2((float) rectangle.Width * 0.5f, (float) rectangle.Height * 0.5f);
      camera.SpriteBatch.Draw(TextureAssets.Ghost.Value, new Vector2((float) (int) ((double) position.X - (double) camera.UnscaledPosition.X + (double) (rectangle.Width / 2)), (float) (int) ((double) position.Y - (double) camera.UnscaledPosition.Y + (double) (rectangle.Height / 2))), new Rectangle?(rectangle), immuneAlpha, 0.0f, origin, 1f, effects, 0.0f);
    }
  }
}
