// Decompiled with JetBrains decompiler
// Type: Terraria.Cloud
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

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
    public int type;
    public int width;
    public int height;
    private static Random rand = new Random();

    public static void resetClouds()
    {
      if (Main.cloudLimit < 10)
        return;
      Main.numClouds = Cloud.rand.Next(10, Main.cloudLimit);
      Main.windSpeed = 0.0f;
      while ((double) Main.windSpeed == 0.0)
        Main.windSpeed = (float) Cloud.rand.Next(-100, 101) * 0.01f;
      for (int index = 0; index < 100; ++index)
        Main.cloud[index].active = false;
      for (int index = 0; index < Main.numClouds; ++index)
        Cloud.addCloud();
      for (int index = 0; index < Main.numClouds; ++index)
      {
        if ((double) Main.windSpeed < 0.0)
          Main.cloud[index].position.X -= (float) (Main.screenWidth * 2);
        else
          Main.cloud[index].position.X += (float) (Main.screenWidth * 2);
      }
    }

    public static void addCloud()
    {
      int index1 = -1;
      for (int index2 = 0; index2 < 100; ++index2)
      {
        if (!Main.cloud[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 < 0)
        return;
      Main.cloud[index1].rSpeed = 0.0f;
      Main.cloud[index1].sSpeed = 0.0f;
      Main.cloud[index1].type = Cloud.rand.Next(4);
      Main.cloud[index1].scale = (float) Cloud.rand.Next(70, 131) * 0.01f;
      Main.cloud[index1].rotation = (float) Cloud.rand.Next(-10, 11) * 0.01f;
      Main.cloud[index1].width = (int) ((double) Main.cloudTexture[Main.cloud[index1].type].Width * (double) Main.cloud[index1].scale);
      Main.cloud[index1].height = (int) ((double) Main.cloudTexture[Main.cloud[index1].type].Height * (double) Main.cloud[index1].scale);
      float num = Main.windSpeed;
      if (!Main.gameMenu)
        num = Main.windSpeed - Main.player[Main.myPlayer].velocity.X * 0.1f;
      Main.cloud[index1].position.X = (double) num <= 0.0 ? (float) (Main.screenWidth + Main.cloudTexture[Main.cloud[index1].type].Width + Cloud.rand.Next(Main.screenWidth * 2)) : (float) (-Main.cloud[index1].width - Main.cloudTexture[Main.cloud[index1].type].Width - Cloud.rand.Next(Main.screenWidth * 2));
      Main.cloud[index1].position.Y = (float) Cloud.rand.Next((int) ((double) -Main.screenHeight * 0.25), (int) ((double) Main.screenHeight * 0.25));
      Main.cloud[index1].position.Y -= (float) Cloud.rand.Next((int) ((double) Main.screenHeight * 0.150000005960464));
      Main.cloud[index1].position.Y -= (float) Cloud.rand.Next((int) ((double) Main.screenHeight * 0.150000005960464));
      if ((double) Main.cloud[index1].scale > 1.3)
        Main.cloud[index1].scale = 1.3f;
      if ((double) Main.cloud[index1].scale < 0.7)
        Main.cloud[index1].scale = 0.7f;
      Main.cloud[index1].active = true;
      Rectangle rectangle1 = new Rectangle((int) Main.cloud[index1].position.X, (int) Main.cloud[index1].position.Y, Main.cloud[index1].width, Main.cloud[index1].height);
      for (int index3 = 0; index3 < 100; ++index3)
      {
        if (index1 != index3 && Main.cloud[index3].active)
        {
          Rectangle rectangle2 = new Rectangle((int) Main.cloud[index3].position.X, (int) Main.cloud[index3].position.Y, Main.cloud[index3].width, Main.cloud[index3].height);
          if (rectangle1.Intersects(rectangle2))
            Main.cloud[index1].active = false;
        }
      }
    }

    public Color cloudColor(Color bgColor)
    {
      float num1 = (float) (((double) this.scale - 0.400000005960464) * 0.899999976158142);
      float num2 = 1.1f;
      float num3 = (float) ((double) byte.MaxValue - (double) ((int) byte.MaxValue - (int) bgColor.R) * (double) num2);
      float num4 = (float) ((double) byte.MaxValue - (double) ((int) byte.MaxValue - (int) bgColor.G) * (double) num2);
      float num5 = (float) ((double) byte.MaxValue - (double) ((int) byte.MaxValue - (int) bgColor.B) * (double) num2);
      float maxValue = (float) byte.MaxValue;
      float num6 = num3 * num1;
      float num7 = num4 * num1;
      float num8 = num5 * num1;
      float num9 = maxValue * num1;
      if ((double) num6 < 0.0)
        num6 = 0.0f;
      if ((double) num7 < 0.0)
        num7 = 0.0f;
      if ((double) num8 < 0.0)
        num8 = 0.0f;
      if ((double) num9 < 0.0)
        num9 = 0.0f;
      return new Color((int) (byte) num6, (int) (byte) num7, (int) (byte) num8, (int) (byte) num9);
    }

    public object Clone() => this.MemberwiseClone();

    public static void UpdateClouds()
    {
      int num = 0;
      for (int index = 0; index < 100; ++index)
      {
        if (Main.cloud[index].active)
        {
          Main.cloud[index].rotation = 0.0f;
          Main.cloud[index].Update();
          ++num;
        }
      }
      for (int index = 0; index < 100; ++index)
      {
        if (Main.cloud[index].active)
        {
          if (index > 1 && (!Main.cloud[index - 1].active || (double) Main.cloud[index - 1].scale > (double) Main.cloud[index].scale + 0.02))
          {
            Cloud cloud = (Cloud) Main.cloud[index - 1].Clone();
            Main.cloud[index - 1] = (Cloud) Main.cloud[index].Clone();
            Main.cloud[index] = cloud;
          }
          if (index < 99 && (!Main.cloud[index].active || (double) Main.cloud[index + 1].scale < (double) Main.cloud[index].scale - 0.02))
          {
            Cloud cloud = (Cloud) Main.cloud[index + 1].Clone();
            Main.cloud[index + 1] = (Cloud) Main.cloud[index].Clone();
            Main.cloud[index] = cloud;
          }
        }
      }
      if (num >= Main.numClouds)
        return;
      Cloud.addCloud();
    }

    public void Update()
    {
      if (Main.gameMenu)
      {
        this.position.X += (float) ((double) Main.windSpeed * (double) this.scale * 3.0);
      }
      else
      {
        float num1 = Main.player[Main.myPlayer].velocity.X * 0.18f;
        float num2 = (float) (((double) Main.screenPosition.X - (double) Main.screenLastPosition.X) * 0.180000007152557);
        if (Main.player[Main.myPlayer].dead)
          num2 = 0.0f;
        this.position.X += (Main.windSpeed - num2) * this.scale;
      }
      if ((double) Main.windSpeed > 0.0)
      {
        if ((double) this.position.X - (double) Main.cloudTexture[this.type].Width > (double) (Main.screenWidth + 200))
          this.active = false;
      }
      else if ((double) this.position.X + (double) this.width + (double) Main.cloudTexture[this.type].Width < -200.0)
        this.active = false;
      this.rSpeed += (float) Cloud.rand.Next(-10, 11) * 2E-05f;
      if ((double) this.rSpeed > 0.0007)
        this.rSpeed = 0.0007f;
      if ((double) this.rSpeed < -0.0007)
        this.rSpeed = -0.0007f;
      if ((double) this.rotation > 0.05)
        this.rotation = 0.05f;
      if ((double) this.rotation < -0.05)
        this.rotation = -0.05f;
      this.rotation += this.rSpeed;
      this.width = (int) ((double) Main.cloudTexture[this.type].Width * (double) this.scale);
      this.height = (int) ((double) Main.cloudTexture[this.type].Height * (double) this.scale);
    }
  }
}
