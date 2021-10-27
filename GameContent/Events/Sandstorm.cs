// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Events.Sandstorm
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Events
{
  public class Sandstorm
  {
    public static bool Happening;
    public static int TimeLeft;
    public static float Severity;
    public static float IntendedSeverity;
    private static bool _effectsUp;

    public static void WorldClear() => Sandstorm.Happening = false;

    public static void UpdateTime()
    {
      if (Main.netMode != 1)
      {
        if (Sandstorm.Happening)
        {
          if (Sandstorm.TimeLeft > 86400)
            Sandstorm.TimeLeft = 0;
          Sandstorm.TimeLeft -= Main.dayRate;
          if (Sandstorm.TimeLeft <= 0)
            Sandstorm.StopSandstorm();
        }
        else
        {
          int num = (int) ((double) Main.windSpeed * 100.0);
          for (int index = 0; index < Main.dayRate; ++index)
          {
            if (Main.rand.Next(777600) == 0)
              Sandstorm.StartSandstorm();
            else if ((Main.numClouds < 40 || Math.Abs(num) > 50) && Main.rand.Next(518400) == 0)
              Sandstorm.StartSandstorm();
          }
        }
        if (Main.rand.Next(18000) == 0)
          Sandstorm.ChangeSeverityIntentions();
      }
      Sandstorm.UpdateSeverity();
    }

    private static void ChangeSeverityIntentions()
    {
      Sandstorm.IntendedSeverity = !Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
      if (Main.netMode == 1)
        return;
      NetMessage.SendData(7);
    }

    private static void UpdateSeverity()
    {
      int num1 = Math.Sign(Sandstorm.IntendedSeverity - Sandstorm.Severity);
      Sandstorm.Severity = MathHelper.Clamp(Sandstorm.Severity + 3f / 1000f * (float) num1, 0.0f, 1f);
      int num2 = Math.Sign(Sandstorm.IntendedSeverity - Sandstorm.Severity);
      if (num1 == num2)
        return;
      Sandstorm.Severity = Sandstorm.IntendedSeverity;
    }

    private static void StartSandstorm()
    {
      Sandstorm.Happening = true;
      Sandstorm.TimeLeft = (int) (3600.0 * (8.0 + (double) Main.rand.NextFloat() * 16.0));
      Sandstorm.ChangeSeverityIntentions();
    }

    private static void StopSandstorm()
    {
      Sandstorm.Happening = false;
      Sandstorm.TimeLeft = 0;
      Sandstorm.ChangeSeverityIntentions();
    }

    public static void HandleEffectAndSky(bool toState)
    {
      if (toState == Sandstorm._effectsUp)
        return;
      Sandstorm._effectsUp = toState;
      Vector2 center = Main.player[Main.myPlayer].Center;
      if (Sandstorm._effectsUp)
      {
        SkyManager.Instance.Activate(nameof (Sandstorm), center);
        Filters.Scene.Activate(nameof (Sandstorm), center);
        Overlays.Scene.Activate(nameof (Sandstorm), center);
      }
      else
      {
        SkyManager.Instance.Deactivate(nameof (Sandstorm));
        Filters.Scene.Deactivate(nameof (Sandstorm));
        Overlays.Scene.Deactivate(nameof (Sandstorm));
      }
    }

    public static void EmitDust()
    {
      if (Main.gamePaused)
        return;
      int sandTiles = Main.sandTiles;
      Player player = Main.player[Main.myPlayer];
      bool flag = Sandstorm.Happening && player.ZoneSandstorm && (Main.bgStyle == 2 || Main.bgStyle == 5) && Main.bgDelay < 50;
      Sandstorm.HandleEffectAndSky(flag && Main.UseStormEffects);
      if (sandTiles < 100 || (double) player.position.Y > Main.worldSurface * 16.0 || player.ZoneBeach)
        return;
      int maxValue1 = 1;
      if (!flag || Main.rand.Next(maxValue1) != 0)
        return;
      int num1 = Math.Sign(Main.windSpeed);
      float amount = Math.Abs(Main.windSpeed);
      if ((double) amount < 0.00999999977648258)
        return;
      float num2 = (float) num1 * MathHelper.Lerp(0.9f, 1f, amount);
      float num3 = 2000f / (float) sandTiles;
      float num4 = MathHelper.Clamp(3f / num3, 0.77f, 1f);
      int num5 = (int) num3;
      int num6 = (int) (1000.0 * (double) ((float) Main.screenWidth / (float) Main.maxScreenW));
      float num7 = 20f * Sandstorm.Severity;
      float num8 = (float) ((double) num6 * ((double) Main.gfxQuality * 0.5 + 0.5) + (double) num6 * 0.100000001490116) - (float) Dust.SandStormCount;
      if ((double) num8 <= 0.0)
        return;
      float num9 = (float) Main.screenWidth + 1000f;
      float screenHeight = (float) Main.screenHeight;
      Vector2 vector2 = Main.screenPosition + player.velocity;
      WeightedRandom<Color> weightedRandom = new WeightedRandom<Color>();
      weightedRandom.Add(new Color(200, 160, 20, 180), (double) (Main.screenTileCounts[53] + Main.screenTileCounts[396] + Main.screenTileCounts[397]));
      weightedRandom.Add(new Color(103, 98, 122, 180), (double) (Main.screenTileCounts[112] + Main.screenTileCounts[400] + Main.screenTileCounts[398]));
      weightedRandom.Add(new Color(135, 43, 34, 180), (double) (Main.screenTileCounts[234] + Main.screenTileCounts[401] + Main.screenTileCounts[399]));
      weightedRandom.Add(new Color(213, 196, 197, 180), (double) (Main.screenTileCounts[116] + Main.screenTileCounts[403] + Main.screenTileCounts[402]));
      float num10 = MathHelper.Lerp(0.2f, 0.35f, Sandstorm.Severity);
      float num11 = MathHelper.Lerp(0.5f, 0.7f, Sandstorm.Severity);
      int maxValue2 = (int) MathHelper.Lerp(1f, 10f, (float) (((double) num4 - 0.769999980926514) / 0.230000019073486));
      for (int index1 = 0; (double) index1 < (double) num7; ++index1)
      {
        if (Main.rand.Next(num5 / 4) == 0)
        {
          Vector2 Position = new Vector2((float) ((double) Main.rand.NextFloat() * (double) num9 - 500.0), Main.rand.NextFloat() * -50f);
          if (Main.rand.Next(3) == 0 && num1 == 1)
            Position.X = (float) (Main.rand.Next(500) - 500);
          else if (Main.rand.Next(3) == 0 && num1 == -1)
            Position.X = (float) (Main.rand.Next(500) + Main.screenWidth);
          if ((double) Position.X < 0.0 || (double) Position.X > (double) Main.screenWidth)
            Position.Y += (float) ((double) Main.rand.NextFloat() * (double) screenHeight * 0.899999976158142);
          Position += vector2;
          int index2 = (int) Position.X / 16;
          int index3 = (int) Position.Y / 16;
          if (Main.tile[index2, index3] != null && Main.tile[index2, index3].wall == (byte) 0)
          {
            for (int index4 = 0; index4 < 1; ++index4)
            {
              Dust dust = Main.dust[Dust.NewDust(Position, 10, 10, 268)];
              dust.velocity.Y = (float) (2.0 + (double) Main.rand.NextFloat() * 0.200000002980232);
              dust.velocity.Y *= dust.scale;
              dust.velocity.Y *= 0.35f;
              dust.velocity.X = (float) ((double) num2 * 5.0 + (double) Main.rand.NextFloat() * 1.0);
              dust.velocity.X += (float) ((double) num2 * (double) num11 * 20.0);
              dust.fadeIn += num11 * 0.2f;
              dust.velocity *= (float) (1.0 + (double) num10 * 0.5);
              dust.color = (Color) weightedRandom;
              dust.velocity *= 1f + num10;
              dust.velocity *= num4;
              dust.scale = 0.9f;
              --num8;
              if ((double) num8 > 0.0)
              {
                if (Main.rand.Next(maxValue2) != 0)
                {
                  --index4;
                  Position += Utils.RandomVector2(Main.rand, -10f, 10f) + dust.velocity * -1.1f;
                  int x = (int) Position.X / 16;
                  int y = (int) Position.Y / 16;
                  if (WorldGen.InWorld(x, y, 10) && Main.tile[x, y] != null)
                  {
                    int wall = (int) Main.tile[x, y].wall;
                  }
                }
              }
              else
                break;
            }
            if ((double) num8 <= 0.0)
              break;
          }
        }
      }
    }

    public static void DrawGrains(SpriteBatch spriteBatch)
    {
    }
  }
}
