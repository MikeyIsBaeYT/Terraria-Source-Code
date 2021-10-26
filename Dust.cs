// Decompiled with JetBrains decompiler
// Type: Terraria.Dust
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public class Dust
  {
    public Vector2 position;
    public Vector2 velocity;
    public static int lavaBubbles;
    public float fadeIn;
    public bool noGravity;
    public float scale;
    public float rotation;
    public bool noLight;
    public bool active;
    public int type;
    public Color color;
    public int alpha;
    public Rectangle frame;

    public static int NewDust(
      Vector2 Position,
      int Width,
      int Height,
      int Type,
      float SpeedX = 0.0f,
      float SpeedY = 0.0f,
      int Alpha = 0,
      Color newColor = default (Color),
      float Scale = 1f)
    {
      if (Main.gameMenu)
        return 0;
      if (Main.rand == null)
        Main.rand = new Random((int) DateTime.Now.Ticks);
      if (Main.gamePaused || WorldGen.gen || Main.netMode == 2)
        return 0;
      if (!new Rectangle((int) ((double) Main.player[Main.myPlayer].position.X - (double) (Main.screenWidth / 2) - 100.0), (int) ((double) Main.player[Main.myPlayer].position.Y - (double) (Main.screenHeight / 2) - 100.0), Main.screenWidth + 200, Main.screenHeight + 200).Intersects(new Rectangle((int) Position.X, (int) Position.Y, 10, 10)))
        return 2000;
      int num1 = 2000;
      for (int index = 0; index < 2000; ++index)
      {
        if (!Main.dust[index].active)
        {
          int num2 = Width;
          int num3 = Height;
          if (num2 < 5)
            num2 = 5;
          if (num3 < 5)
            num3 = 5;
          num1 = index;
          Main.dust[index].fadeIn = 0.0f;
          Main.dust[index].active = true;
          Main.dust[index].type = Type;
          Main.dust[index].noGravity = false;
          Main.dust[index].color = newColor;
          Main.dust[index].alpha = Alpha;
          Main.dust[index].position.X = (float) ((double) Position.X + (double) Main.rand.Next(num2 - 4) + 4.0);
          Main.dust[index].position.Y = (float) ((double) Position.Y + (double) Main.rand.Next(num3 - 4) + 4.0);
          Main.dust[index].velocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + SpeedX;
          Main.dust[index].velocity.Y = (float) Main.rand.Next(-20, 21) * 0.1f + SpeedY;
          Main.dust[index].frame.X = 10 * Type;
          Main.dust[index].frame.Y = 10 * Main.rand.Next(3);
          Main.dust[index].frame.Width = 8;
          Main.dust[index].frame.Height = 8;
          Main.dust[index].rotation = 0.0f;
          Main.dust[index].scale = (float) (1.0 + (double) Main.rand.Next(-20, 21) * 0.00999999977648258);
          Main.dust[index].scale *= Scale;
          Main.dust[index].noLight = false;
          if (Main.dust[index].type == 6 || Main.dust[index].type == 75 || Main.dust[index].type == 29 || Main.dust[index].type >= 59 && Main.dust[index].type <= 65)
          {
            Main.dust[index].velocity.Y = (float) Main.rand.Next(-10, 6) * 0.1f;
            Main.dust[index].velocity.X *= 0.3f;
            Main.dust[index].scale *= 0.7f;
          }
          if (Main.dust[index].type == 33 || Main.dust[index].type == 52)
          {
            Main.dust[index].alpha = 170;
            Main.dust[index].velocity *= 0.5f;
            ++Main.dust[index].velocity.Y;
          }
          if (Main.dust[index].type == 41)
            Main.dust[index].velocity *= 0.0f;
          if (Main.dust[index].type == 34 || Main.dust[index].type == 35)
          {
            Main.dust[index].velocity *= 0.1f;
            Main.dust[index].velocity.Y = -0.5f;
            if (Main.dust[index].type == 34 && !Collision.WetCollision(new Vector2(Main.dust[index].position.X, Main.dust[index].position.Y - 8f), 4, 4))
            {
              Main.dust[index].active = false;
              break;
            }
            break;
          }
          break;
        }
      }
      return num1;
    }

    public static void UpdateDust()
    {
      Dust.lavaBubbles = 0;
      Main.snowDust = 0;
      for (int index = 0; index < 2000; ++index)
      {
        if (index < Main.numDust)
        {
          if (Main.dust[index].active)
          {
            if (Main.dust[index].type == 35)
              ++Dust.lavaBubbles;
            Main.dust[index].position += Main.dust[index].velocity;
            if (Main.dust[index].type == 6 || Main.dust[index].type == 75 || Main.dust[index].type == 29 || Main.dust[index].type >= 59 && Main.dust[index].type <= 65)
            {
              if (!Main.dust[index].noGravity)
                Main.dust[index].velocity.Y += 0.05f;
              if (!Main.dust[index].noLight)
              {
                float num1 = Main.dust[index].scale * 1.4f;
                if (Main.dust[index].type == 29)
                {
                  if ((double) num1 > 1.0)
                    num1 = 1f;
                  Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num1 * 0.1f, num1 * 0.4f, num1);
                }
                if (Main.dust[index].type == 75)
                {
                  if ((double) num1 > 1.0)
                    num1 = 1f;
                  Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num1 * 0.7f, num1, num1 * 0.2f);
                }
                else if (Main.dust[index].type >= 59 && Main.dust[index].type <= 65)
                {
                  if ((double) num1 > 0.800000011920929)
                    num1 = 0.8f;
                  int num2 = Main.dust[index].type - 58;
                  float num3 = 1f;
                  float num4 = 1f;
                  float num5 = 1f;
                  switch (num2)
                  {
                    case 1:
                      num3 = 0.0f;
                      num4 = 0.1f;
                      num5 = 1.3f;
                      break;
                    case 2:
                      num3 = 1f;
                      num4 = 0.1f;
                      num5 = 0.1f;
                      break;
                    case 3:
                      num3 = 0.0f;
                      num4 = 1f;
                      num5 = 0.1f;
                      break;
                    case 4:
                      num3 = 0.9f;
                      num4 = 0.0f;
                      num5 = 0.9f;
                      break;
                    case 5:
                      num3 = 1.3f;
                      num4 = 1.3f;
                      num5 = 1.3f;
                      break;
                    case 6:
                      num3 = 0.9f;
                      num4 = 0.9f;
                      num5 = 0.0f;
                      break;
                    case 7:
                      num3 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                      num4 = 0.3f;
                      num5 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                      break;
                  }
                  Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num1 * num3, num1 * num4, num1 * num5);
                }
                else
                {
                  if ((double) num1 > 0.600000023841858)
                    num1 = 0.6f;
                  Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num1, num1 * 0.65f, num1 * 0.4f);
                }
              }
            }
            else if (Main.dust[index].type == 14 || Main.dust[index].type == 16 || Main.dust[index].type == 31 || Main.dust[index].type == 46)
            {
              Main.dust[index].velocity.Y *= 0.98f;
              Main.dust[index].velocity.X *= 0.98f;
              if (Main.dust[index].type == 31 && Main.dust[index].noGravity)
              {
                Main.dust[index].velocity *= 1.02f;
                Main.dust[index].scale += 0.02f;
                Main.dust[index].alpha += 4;
                if (Main.dust[index].alpha > (int) byte.MaxValue)
                {
                  Main.dust[index].scale = 0.0001f;
                  Main.dust[index].alpha = (int) byte.MaxValue;
                }
              }
            }
            else if (Main.dust[index].type == 32)
            {
              Main.dust[index].scale -= 0.01f;
              Main.dust[index].velocity.X *= 0.96f;
              Main.dust[index].velocity.Y += 0.1f;
            }
            else if (Main.dust[index].type == 43)
            {
              Main.dust[index].rotation += 0.1f * Main.dust[index].scale;
              Color color = Lighting.GetColor((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0));
              float num6 = (float) color.R / 270f;
              float num7 = (float) color.G / 270f;
              float num8 = (float) color.B / 270f;
              float R = num6 * (Main.dust[index].scale * 1.07f);
              float G = num7 * (Main.dust[index].scale * 1.07f);
              float B = num8 * (Main.dust[index].scale * 1.07f);
              if (Main.dust[index].alpha < (int) byte.MaxValue)
              {
                Main.dust[index].scale += 0.09f;
                if ((double) Main.dust[index].scale >= 1.0)
                {
                  Main.dust[index].scale = 1f;
                  Main.dust[index].alpha = (int) byte.MaxValue;
                }
              }
              else
              {
                if ((double) Main.dust[index].scale < 0.8)
                  Main.dust[index].scale -= 0.01f;
                if ((double) Main.dust[index].scale < 0.5)
                  Main.dust[index].scale -= 0.01f;
              }
              if ((double) R < 0.05 && (double) G < 0.05 && (double) B < 0.05)
                Main.dust[index].active = false;
              else
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), R, G, B);
            }
            else if (Main.dust[index].type == 15 || Main.dust[index].type == 57 || Main.dust[index].type == 58)
            {
              Main.dust[index].velocity.Y *= 0.98f;
              Main.dust[index].velocity.X *= 0.98f;
              float num = Main.dust[index].scale;
              if (Main.dust[index].type != 15)
                num = Main.dust[index].scale * 0.8f;
              if (Main.dust[index].noLight)
                Main.dust[index].velocity *= 0.95f;
              if ((double) num > 1.0)
                num = 1f;
              if (Main.dust[index].type == 15)
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num * 0.45f, num * 0.55f, num);
              else if (Main.dust[index].type == 57)
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num * 0.95f, num * 0.95f, num * 0.45f);
              else if (Main.dust[index].type == 58)
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num, num * 0.55f, num * 0.75f);
            }
            else if (Main.dust[index].type == 66)
            {
              if ((double) Main.dust[index].velocity.X < 0.0)
                --Main.dust[index].rotation;
              else
                ++Main.dust[index].rotation;
              Main.dust[index].velocity.Y *= 0.98f;
              Main.dust[index].velocity.X *= 0.98f;
              Main.dust[index].scale += 0.02f;
              float num = Main.dust[index].scale;
              if (Main.dust[index].type != 15)
                num = Main.dust[index].scale * 0.8f;
              if ((double) num > 1.0)
                num = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num * ((float) Main.dust[index].color.R / (float) byte.MaxValue), num * ((float) Main.dust[index].color.G / (float) byte.MaxValue), num * ((float) Main.dust[index].color.B / (float) byte.MaxValue));
            }
            else if (Main.dust[index].type == 20 || Main.dust[index].type == 21)
            {
              Main.dust[index].scale += 0.005f;
              Main.dust[index].velocity.Y *= 0.94f;
              Main.dust[index].velocity.X *= 0.94f;
              float B1 = Main.dust[index].scale * 0.8f;
              if ((double) B1 > 1.0)
                B1 = 1f;
              if (Main.dust[index].type == 21)
              {
                float B2 = Main.dust[index].scale * 0.4f;
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B2 * 0.8f, B2 * 0.3f, B2);
              }
              else
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B1 * 0.3f, B1 * 0.6f, B1);
            }
            else if (Main.dust[index].type == 27 || Main.dust[index].type == 45)
            {
              Main.dust[index].velocity *= 0.94f;
              Main.dust[index].scale += 1f / 500f;
              float B = Main.dust[index].scale;
              if (Main.dust[index].noLight)
              {
                B *= 0.1f;
                Main.dust[index].scale -= 0.06f;
                if ((double) Main.dust[index].scale < 1.0)
                  Main.dust[index].scale -= 0.06f;
                if (Main.player[Main.myPlayer].wet)
                  Main.dust[index].position += Main.player[Main.myPlayer].velocity * 0.5f;
                else
                  Main.dust[index].position += Main.player[Main.myPlayer].velocity;
              }
              if ((double) B > 1.0)
                B = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B * 0.6f, B * 0.2f, B);
            }
            else if (Main.dust[index].type == 55 || Main.dust[index].type == 56 || Main.dust[index].type == 73 || Main.dust[index].type == 74)
            {
              Main.dust[index].velocity *= 0.98f;
              float num = Main.dust[index].scale * 0.8f;
              if (Main.dust[index].type == 55)
              {
                if ((double) num > 1.0)
                  num = 1f;
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num, num, num * 0.6f);
              }
              else if (Main.dust[index].type == 73)
              {
                if ((double) num > 1.0)
                  num = 1f;
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num, num * 0.35f, num * 0.5f);
              }
              else if (Main.dust[index].type == 74)
              {
                if ((double) num > 1.0)
                  num = 1f;
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num * 0.35f, num, num * 0.5f);
              }
              else
              {
                float B = Main.dust[index].scale * 1.2f;
                if ((double) B > 1.0)
                  B = 1f;
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B * 0.35f, B * 0.5f, B);
              }
            }
            else if (Main.dust[index].type == 71 || Main.dust[index].type == 72)
            {
              Main.dust[index].velocity *= 0.98f;
              float num = Main.dust[index].scale;
              if ((double) num > 1.0)
                num = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), num * 0.2f, 0.0f, num * 0.1f);
            }
            else if (Main.dust[index].type == 76)
            {
              ++Main.snowDust;
              Main.dust[index].scale += 0.009f;
              Main.dust[index].position += Main.player[Main.myPlayer].velocity * 0.2f;
            }
            else if (!Main.dust[index].noGravity && Main.dust[index].type != 41 && Main.dust[index].type != 44)
              Main.dust[index].velocity.Y += 0.1f;
            if (Main.dust[index].type == 5 && Main.dust[index].noGravity)
              Main.dust[index].scale -= 0.04f;
            if (Main.dust[index].type == 33 || Main.dust[index].type == 52)
            {
              if ((double) Main.dust[index].velocity.X == 0.0)
              {
                if (Collision.SolidCollision(Main.dust[index].position, 2, 2))
                  Main.dust[index].scale = 0.0f;
                Main.dust[index].rotation += 0.5f;
                Main.dust[index].scale -= 0.01f;
              }
              if (Collision.WetCollision(new Vector2(Main.dust[index].position.X, Main.dust[index].position.Y), 4, 4))
              {
                Main.dust[index].alpha += 20;
                Main.dust[index].scale -= 0.1f;
              }
              Main.dust[index].alpha += 2;
              Main.dust[index].scale -= 0.005f;
              if (Main.dust[index].alpha > (int) byte.MaxValue)
                Main.dust[index].scale = 0.0f;
              Main.dust[index].velocity.X *= 0.93f;
              if ((double) Main.dust[index].velocity.Y > 4.0)
                Main.dust[index].velocity.Y = 4f;
              if (Main.dust[index].noGravity)
              {
                if ((double) Main.dust[index].velocity.X < 0.0)
                  Main.dust[index].rotation -= 0.2f;
                else
                  Main.dust[index].rotation += 0.2f;
                Main.dust[index].scale += 0.03f;
                Main.dust[index].velocity.X *= 1.05f;
                Main.dust[index].velocity.Y += 0.15f;
              }
            }
            if (Main.dust[index].type == 35 && Main.dust[index].noGravity)
            {
              Main.dust[index].scale += 0.03f;
              if ((double) Main.dust[index].scale < 1.0)
                Main.dust[index].velocity.Y += 0.075f;
              Main.dust[index].velocity.X *= 1.08f;
              if ((double) Main.dust[index].velocity.X > 0.0)
                Main.dust[index].rotation += 0.01f;
              else
                Main.dust[index].rotation -= 0.01f;
              float R = Main.dust[index].scale * 0.6f;
              if ((double) R > 1.0)
                R = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0 + 1.0), R, R * 0.3f, R * 0.1f);
            }
            else if (Main.dust[index].type == 67)
            {
              float B = Main.dust[index].scale;
              if ((double) B > 1.0)
                B = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), 0.0f, B * 0.8f, B);
            }
            else if (Main.dust[index].type == 34 || Main.dust[index].type == 35)
            {
              if (!Collision.WetCollision(new Vector2(Main.dust[index].position.X, Main.dust[index].position.Y - 8f), 4, 4))
              {
                Main.dust[index].scale = 0.0f;
              }
              else
              {
                Main.dust[index].alpha += Main.rand.Next(2);
                if (Main.dust[index].alpha > (int) byte.MaxValue)
                  Main.dust[index].scale = 0.0f;
                Main.dust[index].velocity.Y = -0.5f;
                if (Main.dust[index].type == 34)
                {
                  Main.dust[index].scale += 0.005f;
                }
                else
                {
                  ++Main.dust[index].alpha;
                  Main.dust[index].scale -= 0.01f;
                  Main.dust[index].velocity.Y = -0.2f;
                }
                Main.dust[index].velocity.X += (float) Main.rand.Next(-10, 10) * (1f / 500f);
                if ((double) Main.dust[index].velocity.X < -0.25)
                  Main.dust[index].velocity.X = -0.25f;
                if ((double) Main.dust[index].velocity.X > 0.25)
                  Main.dust[index].velocity.X = 0.25f;
              }
              if (Main.dust[index].type == 35)
              {
                float R = (float) ((double) Main.dust[index].scale * 0.300000011920929 + 0.400000005960464);
                if ((double) R > 1.0)
                  R = 1f;
                Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), R, R * 0.5f, R * 0.3f);
              }
            }
            if (Main.dust[index].type == 68)
            {
              float B = Main.dust[index].scale * 0.3f;
              if ((double) B > 1.0)
                B = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B * 0.1f, B * 0.2f, B);
            }
            if (Main.dust[index].type == 70)
            {
              float B = Main.dust[index].scale * 0.3f;
              if ((double) B > 1.0)
                B = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B * 0.5f, 0.0f, B);
            }
            if (Main.dust[index].type == 41)
            {
              Main.dust[index].velocity.X += (float) Main.rand.Next(-10, 11) * 0.01f;
              Main.dust[index].velocity.Y += (float) Main.rand.Next(-10, 11) * 0.01f;
              if ((double) Main.dust[index].velocity.X > 0.75)
                Main.dust[index].velocity.X = 0.75f;
              if ((double) Main.dust[index].velocity.X < -0.75)
                Main.dust[index].velocity.X = -0.75f;
              if ((double) Main.dust[index].velocity.Y > 0.75)
                Main.dust[index].velocity.Y = 0.75f;
              if ((double) Main.dust[index].velocity.Y < -0.75)
                Main.dust[index].velocity.Y = -0.75f;
              Main.dust[index].scale += 0.007f;
              float B = Main.dust[index].scale * 0.7f;
              if ((double) B > 1.0)
                B = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), B * 0.4f, B * 0.9f, B);
            }
            else if (Main.dust[index].type == 44)
            {
              Main.dust[index].velocity.X += (float) Main.rand.Next(-10, 11) * (3f / 1000f);
              Main.dust[index].velocity.Y += (float) Main.rand.Next(-10, 11) * (3f / 1000f);
              if ((double) Main.dust[index].velocity.X > 0.35)
                Main.dust[index].velocity.X = 0.35f;
              if ((double) Main.dust[index].velocity.X < -0.35)
                Main.dust[index].velocity.X = -0.35f;
              if ((double) Main.dust[index].velocity.Y > 0.35)
                Main.dust[index].velocity.Y = 0.35f;
              if ((double) Main.dust[index].velocity.Y < -0.35)
                Main.dust[index].velocity.Y = -0.35f;
              Main.dust[index].scale += 0.0085f;
              float G = Main.dust[index].scale * 0.7f;
              if ((double) G > 1.0)
                G = 1f;
              Lighting.addLight((int) ((double) Main.dust[index].position.X / 16.0), (int) ((double) Main.dust[index].position.Y / 16.0), G * 0.7f, G, G * 0.8f);
            }
            else
              Main.dust[index].velocity.X *= 0.99f;
            if (Main.dust[index].type != 79)
              Main.dust[index].rotation += Main.dust[index].velocity.X * 0.5f;
            if ((double) Main.dust[index].fadeIn > 0.0)
            {
              if (Main.dust[index].type == 46)
                Main.dust[index].scale += 0.1f;
              else
                Main.dust[index].scale += 0.03f;
              if ((double) Main.dust[index].scale > (double) Main.dust[index].fadeIn)
                Main.dust[index].fadeIn = 0.0f;
            }
            else
              Main.dust[index].scale -= 0.01f;
            if (Main.dust[index].noGravity)
            {
              Main.dust[index].velocity *= 0.92f;
              if ((double) Main.dust[index].fadeIn == 0.0)
                Main.dust[index].scale -= 0.04f;
            }
            if ((double) Main.dust[index].position.Y > (double) Main.screenPosition.Y + (double) Main.screenHeight)
              Main.dust[index].active = false;
            if ((double) Main.dust[index].scale < 0.1)
              Main.dust[index].active = false;
          }
        }
        else
          Main.dust[index].active = false;
      }
    }

    public Color GetAlpha(Color newColor)
    {
      float num = (float) ((int) byte.MaxValue - this.alpha) / (float) byte.MaxValue;
      if (this.type == 6 || this.type == 75 || this.type == 20 || this.type == 21)
        return new Color((int) newColor.R, (int) newColor.G, (int) newColor.B, 25);
      if ((this.type == 68 || this.type == 70) && this.noGravity)
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
      if (this.type == 15 || this.type == 20 || this.type == 21 || this.type == 29 || this.type == 35 || this.type == 41 || this.type == 44 || this.type == 27 || this.type == 45 || this.type == 55 || this.type == 56 || this.type == 57 || this.type == 58 || this.type == 73 || this.type == 74)
        num = (float) (((double) num + 3.0) / 4.0);
      else if (this.type == 43)
      {
        num = (float) (((double) num + 9.0) / 10.0);
      }
      else
      {
        if (this.type == 66)
          return new Color((int) newColor.R, (int) newColor.G, (int) newColor.B, 0);
        if (this.type == 71)
          return new Color(200, 200, 200, 0);
        if (this.type == 72)
          return new Color(200, 200, 200, 200);
      }
      int r = (int) ((double) newColor.R * (double) num);
      int g = (int) ((double) newColor.G * (double) num);
      int b = (int) ((double) newColor.B * (double) num);
      int a = (int) newColor.A - this.alpha;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public Color GetColor(Color newColor)
    {
      int r = (int) this.color.R - ((int) byte.MaxValue - (int) newColor.R);
      int g = (int) this.color.G - ((int) byte.MaxValue - (int) newColor.G);
      int b = (int) this.color.B - ((int) byte.MaxValue - (int) newColor.B);
      int a = (int) this.color.A - ((int) byte.MaxValue - (int) newColor.A);
      if (r < 0)
        r = 0;
      if (r > (int) byte.MaxValue)
        r = (int) byte.MaxValue;
      if (g < 0)
        g = 0;
      if (g > (int) byte.MaxValue)
        g = (int) byte.MaxValue;
      if (b < 0)
        b = 0;
      if (b > (int) byte.MaxValue)
        b = (int) byte.MaxValue;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }
  }
}
