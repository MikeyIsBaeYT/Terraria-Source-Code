// Decompiled with JetBrains decompiler
// Type: Terraria.Cloud
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Utilities;

namespace Terraria
{
  public class Cloud
  {
    public Vector2 position;
    public float scale;
    public float rotation;
    public float rSpeed;
    public float sSpeed;
    public bool active;
    public SpriteEffects spriteDir;
    public int type;
    public int width;
    public int height;
    public float Alpha;
    public bool kill;
    private static UnifiedRandom rand = new UnifiedRandom();

    public static void resetClouds()
    {
      if (Main.dedServ)
        return;
      Main.windSpeedCurrent = Main.windSpeedTarget;
      for (int index = 0; index < 200; ++index)
        Main.cloud[index].active = false;
      for (int index = 0; index < Main.numClouds; ++index)
      {
        Cloud.addCloud();
        Main.cloud[index].Alpha = 1f;
      }
      for (int index = 0; index < 200; ++index)
        Main.cloud[index].Alpha = 1f;
    }

    public static void addCloud()
    {
      if (Main.netMode == 2)
        return;
      int index1 = -1;
      for (int index2 = 0; index2 < 200; ++index2)
      {
        if (!Main.cloud[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 < 0)
        return;
      Main.cloud[index1].kill = false;
      Main.cloud[index1].rSpeed = 0.0f;
      Main.cloud[index1].sSpeed = 0.0f;
      Main.cloud[index1].scale = (float) Cloud.rand.Next(70, 131) * 0.01f;
      Main.cloud[index1].rotation = (float) Cloud.rand.Next(-10, 11) * 0.01f;
      Main.cloud[index1].width = (int) ((double) TextureAssets.Cloud[Main.cloud[index1].type].Width() * (double) Main.cloud[index1].scale);
      Main.cloud[index1].height = (int) ((double) TextureAssets.Cloud[Main.cloud[index1].type].Height() * (double) Main.cloud[index1].scale);
      Main.cloud[index1].Alpha = 0.0f;
      Main.cloud[index1].spriteDir = SpriteEffects.None;
      if (Cloud.rand.Next(2) == 0)
        Main.cloud[index1].spriteDir = SpriteEffects.FlipHorizontally;
      float num1 = Main.windSpeedCurrent;
      if (!Main.gameMenu)
        num1 = Main.windSpeedCurrent - Main.player[Main.myPlayer].velocity.X * 0.1f;
      int num2 = 0;
      int num3 = 0;
      if ((double) num1 > 0.0)
        num2 -= 200;
      if ((double) num1 < 0.0)
        num3 += 200;
      int num4 = 300;
      float num5 = (float) WorldGen.genRand.Next(num2 - num4, Main.screenWidth + num3 + num4);
      Main.cloud[index1].Alpha = 0.0f;
      Main.cloud[index1].position.Y = (float) Cloud.rand.Next((int) ((double) -Main.screenHeight * 0.25), (int) ((double) Main.screenHeight * 0.150000005960464));
      if (Main.rand.Next(3) == 0)
        Main.cloud[index1].position.Y -= (float) Cloud.rand.Next((int) ((double) Main.screenHeight * 0.100000001490116));
      Main.cloud[index1].type = Cloud.rand.Next(4);
      if ((double) Main.cloudAlpha > 0.0 && Cloud.rand.Next(4) != 0 || (double) Main.cloudBGActive >= 1.0 && Cloud.rand.Next(2) == 0)
      {
        Main.cloud[index1].type = Cloud.rand.Next(18, 22);
        if ((double) Main.cloud[index1].scale >= 1.15)
          Main.cloud[index1].position.Y -= 150f;
        if ((double) Main.cloud[index1].scale >= 1.0)
          Main.cloud[index1].position.Y -= 150f;
      }
      else if ((double) Main.cloudBGActive <= 0.0 && (double) Main.cloudAlpha == 0.0 && (double) Main.cloud[index1].scale < 1.0 && (double) Main.cloud[index1].position.Y < (double) -Main.screenHeight * 0.150000005960464 && (double) Main.numClouds <= 80.0)
        Main.cloud[index1].type = Cloud.rand.Next(9, 14);
      else if (((double) Main.cloud[index1].scale < 1.15 && (double) Main.cloud[index1].position.Y < (double) -Main.screenHeight * 0.300000011920929 || (double) Main.cloud[index1].scale < 0.85 && (double) Main.cloud[index1].position.Y < (double) Main.screenHeight * 0.150000005960464) && ((double) Main.numClouds > 70.0 || (double) Main.cloudBGActive >= 1.0))
        Main.cloud[index1].type = Cloud.rand.Next(4, 9);
      else if ((double) Main.cloud[index1].position.Y > (double) -Main.screenHeight * 0.150000005960464 && Cloud.rand.Next(2) == 0 && (double) Main.numClouds > 20.0)
        Main.cloud[index1].type = Cloud.rand.Next(14, 18);
      if (Cloud.rand.Next(150) == 0)
        Main.cloud[index1].type = Cloud.RollRareCloud();
      if ((double) Main.cloud[index1].scale > 1.2)
        Main.cloud[index1].position.Y += 100f;
      if ((double) Main.cloud[index1].scale > 1.3)
        Main.cloud[index1].scale = 1.3f;
      if ((double) Main.cloud[index1].scale < 0.7)
        Main.cloud[index1].scale = 0.7f;
      Main.cloud[index1].active = true;
      Main.cloud[index1].position.X = num5;
      if ((double) Main.cloud[index1].position.X > (double) (Main.screenWidth + 400))
        Main.cloud[index1].Alpha = 1f;
      if ((double) Main.cloud[index1].position.X + (double) TextureAssets.Cloud[Main.cloud[index1].type].Width() * (double) Main.cloud[index1].scale < -400.0)
        Main.cloud[index1].Alpha = 1f;
      Rectangle rectangle1 = new Rectangle((int) Main.cloud[index1].position.X, (int) Main.cloud[index1].position.Y, Main.cloud[index1].width, Main.cloud[index1].height);
      for (int index3 = 0; index3 < 200; ++index3)
      {
        if (index1 != index3 && Main.cloud[index3].active)
        {
          Rectangle rectangle2 = new Rectangle((int) Main.cloud[index3].position.X, (int) Main.cloud[index3].position.Y, Main.cloud[index3].width, Main.cloud[index3].height);
          if (rectangle1.Intersects(rectangle2))
            Main.cloud[index1].active = false;
        }
      }
    }

    private static int RollRareCloud()
    {
      int num = -1;
      bool flag = false;
      while (!flag)
      {
        num = Cloud.rand.Next(22, 37);
        switch (num)
        {
          case 25:
          case 26:
            flag = NPC.downedBoss1;
            continue;
          case 28:
            if (Main.rand.Next(10) == 0)
            {
              flag = true;
              continue;
            }
            continue;
          case 30:
          case 35:
            flag = Main.hardMode;
            continue;
          case 31:
            flag = NPC.downedBoss3;
            continue;
          case 36:
            flag = NPC.downedBoss2 && WorldGen.crimson;
            continue;
          default:
            flag = true;
            continue;
        }
      }
      return num;
    }

    public Color cloudColor(Color bgColor)
    {
      float num = this.scale * this.Alpha;
      if ((double) num > 1.0)
        num = 1f;
      return new Color((int) (byte) (float) (int) ((double) bgColor.R * (double) num), (int) (byte) (float) (int) ((double) bgColor.G * (double) num), (int) (byte) (float) (int) ((double) bgColor.B * (double) num), (int) (byte) (float) (int) ((double) bgColor.A * (double) num));
    }

    public object Clone() => this.MemberwiseClone();

    public static void UpdateClouds()
    {
      if (Main.netMode == 2)
        return;
      int maxValue = 0;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.cloud[index].active)
        {
          Main.cloud[index].Update();
          if (!Main.cloud[index].kill)
            ++maxValue;
        }
      }
      for (int index = 0; index < 200; ++index)
      {
        if (Main.cloud[index].active)
        {
          if (index > 1 && (!Main.cloud[index - 1].active || (double) Main.cloud[index - 1].scale > (double) Main.cloud[index].scale + 0.02))
          {
            Cloud cloud = (Cloud) Main.cloud[index - 1].Clone();
            Main.cloud[index - 1] = (Cloud) Main.cloud[index].Clone();
            Main.cloud[index] = cloud;
          }
          if (index < 199 && (!Main.cloud[index].active || (double) Main.cloud[index + 1].scale < (double) Main.cloud[index].scale - 0.02))
          {
            Cloud cloud = (Cloud) Main.cloud[index + 1].Clone();
            Main.cloud[index + 1] = (Cloud) Main.cloud[index].Clone();
            Main.cloud[index] = cloud;
          }
        }
      }
      if (maxValue < Main.numClouds)
      {
        Cloud.addCloud();
      }
      else
      {
        if (maxValue <= Main.numClouds)
          return;
        int index1 = Cloud.rand.Next(maxValue);
        for (int index2 = 0; Main.cloud[index1].kill && index2 < 100; index1 = Cloud.rand.Next(maxValue))
          ++index2;
        Main.cloud[index1].kill = true;
      }
    }

    public void Update()
    {
      if (WorldGen.drunkWorldGenText && Main.gameMenu)
        this.type = 28;
      if ((double) this.scale == 1.0)
        this.scale -= 0.0001f;
      if ((double) this.scale == 1.15)
        this.scale -= 0.0001f;
      float num1;
      if ((double) this.scale < 1.0)
      {
        float num2 = 0.07f;
        float num3 = (float) (((double) (this.scale + 0.15f) + 1.0) / 2.0);
        float num4 = num3 * num3;
        num1 = num2 * num4;
      }
      else if ((double) this.scale <= 1.15)
      {
        float num5 = 0.19f;
        float num6 = this.scale - 0.075f;
        float num7 = num6 * num6;
        num1 = num5 * num7;
      }
      else
      {
        float num8 = 0.23f;
        float num9 = (float) ((double) this.scale - 0.150000005960464 - 0.0750000029802322);
        float num10 = num9 * num9;
        num1 = num8 * num10;
      }
      this.position.X += Main.windSpeedCurrent * 9f * num1 * (float) Main.dayRate;
      this.position.X -= (Main.screenPosition.X - Main.screenLastPosition.X) * num1;
      float num11 = 600f;
      if ((double) Main.bgAlphaFrontLayer[4] == 1.0 && (double) this.position.Y > 200.0)
      {
        this.kill = true;
        this.Alpha -= 0.005f * (float) Main.dayRate;
      }
      if (!this.kill)
      {
        if ((double) this.Alpha < 1.0)
        {
          this.Alpha += 1f / 1000f * (float) Main.dayRate;
          if ((double) this.Alpha > 1.0)
            this.Alpha = 1f;
        }
      }
      else
      {
        this.Alpha -= 1f / 1000f * (float) Main.dayRate;
        if ((double) this.Alpha <= 0.0)
          this.active = false;
      }
      if ((double) this.position.X + (double) TextureAssets.Cloud[this.type].Width() * (double) this.scale < -(double) num11 || (double) this.position.X > (double) Main.screenWidth + (double) num11)
        this.active = false;
      this.rSpeed += (float) Cloud.rand.Next(-10, 11) * 2E-05f;
      if ((double) this.rSpeed > 0.0002)
        this.rSpeed = 0.0002f;
      if ((double) this.rSpeed < -0.0002)
        this.rSpeed = -0.0002f;
      if ((double) this.rotation > 0.02)
        this.rotation = 0.02f;
      if ((double) this.rotation < -0.02)
        this.rotation = -0.02f;
      this.rotation += this.rSpeed;
      this.width = (int) ((double) TextureAssets.Cloud[this.type].Width() * (double) this.scale);
      this.height = (int) ((double) TextureAssets.Cloud[this.type].Height() * (double) this.scale);
      if (this.type < 9 || this.type > 13 || (double) Main.cloudAlpha <= 0.0 && (double) Main.cloudBGActive < 1.0)
        return;
      this.kill = true;
    }
  }
}
