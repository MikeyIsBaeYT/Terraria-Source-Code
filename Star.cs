// Decompiled with JetBrains decompiler
// Type: Terraria.Star
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.Utilities;

namespace Terraria
{
  public class Star
  {
    public Vector2 position;
    public float scale;
    public float rotation;
    public int type;
    public float twinkle;
    public float twinkleSpeed;
    public float rotationSpeed;
    public bool falling;
    public bool hidden;
    public Vector2 fallSpeed;
    public int fallTime;
    public static bool dayCheck = false;
    public static float starfallBoost = 1f;
    public static int starFallCount = 0;
    public float fadeIn;

    public static void NightSetup()
    {
      Star.starfallBoost = 1f;
      if (Main.rand.Next(10) == 0)
        Star.starfallBoost = (float) Main.rand.Next(300, 501) * 0.01f;
      else if (Main.rand.Next(3) == 0)
        Star.starfallBoost = (float) Main.rand.Next(100, 151) * 0.01f;
      Star.starFallCount = 0;
    }

    public static void StarFall(float positionX)
    {
      ++Star.starFallCount;
      int index1 = -1;
      float num1 = -1f;
      float num2 = (float) ((double) positionX / (double) Main.rightWorld * 1920.0);
      for (int index2 = 0; index2 < Main.numStars; ++index2)
      {
        if (!Main.star[index2].hidden && !Main.star[index2].falling)
        {
          float num3 = Math.Abs(Main.star[index2].position.X - num2);
          if ((double) num1 == -1.0 || (double) num3 < (double) num1)
          {
            index1 = index2;
            num1 = num3;
          }
        }
      }
      if (index1 < 0)
        return;
      Main.star[index1].Fall();
    }

    public static void SpawnStars(int s = -1)
    {
      FastRandom withRandomSeed = FastRandom.CreateWithRandomSeed();
      int num1 = withRandomSeed.Next(200, 400);
      int num2 = 0;
      int num3 = num1;
      if (s >= 0)
      {
        num2 = s;
        num3 = s + 1;
      }
      for (int index1 = num2; index1 < num3; ++index1)
      {
        Main.star[index1] = new Star();
        if (s >= 0)
        {
          Main.star[index1].fadeIn = 1f;
          int num4 = 10;
          int num5 = -2000;
          for (int index2 = 0; index2 < num4; ++index2)
          {
            float num6 = (float) withRandomSeed.Next(1921);
            int num7 = 2000;
            for (int index3 = 0; index3 < Main.numStars; ++index3)
            {
              if (index3 != s && !Main.star[index3].hidden && !Main.star[index3].falling)
              {
                int num8 = (int) Math.Abs(num6 - Main.star[index3].position.X);
                if (num8 < num7)
                  num7 = num8;
              }
            }
            if (s == 0 || num7 > num5)
            {
              num5 = num7;
              Main.star[index1].position.X = num6;
            }
          }
        }
        else
          Main.star[index1].position.X = (float) withRandomSeed.Next(1921);
        Main.star[index1].position.Y = (float) withRandomSeed.Next(1201);
        Main.star[index1].rotation = (float) withRandomSeed.Next(628) * 0.01f;
        Main.star[index1].scale = (float) withRandomSeed.Next(70, 130) * (3f / 500f);
        Main.star[index1].type = withRandomSeed.Next(0, 4);
        Main.star[index1].twinkle = (float) withRandomSeed.Next(60, 101) * 0.01f;
        Main.star[index1].twinkleSpeed = (float) withRandomSeed.Next(30, 110) * 0.0001f;
        if (withRandomSeed.Next(2) == 0)
          Main.star[index1].twinkleSpeed *= -1f;
        Main.star[index1].rotationSpeed = (float) withRandomSeed.Next(5, 50) * 0.0001f;
        if (withRandomSeed.Next(2) == 0)
          Main.star[index1].rotationSpeed *= -1f;
        if (withRandomSeed.Next(40) == 0)
        {
          Main.star[index1].scale *= 2f;
          Main.star[index1].twinkleSpeed /= 2f;
          Main.star[index1].rotationSpeed /= 2f;
        }
      }
      if (s != -1)
        return;
      Main.numStars = num1;
    }

    public void Fall()
    {
      this.fallTime = 0;
      this.falling = true;
      this.fallSpeed.Y = (float) Main.rand.Next(700, 1001) * 0.01f;
      this.fallSpeed.X = (float) Main.rand.Next(-400, 401) * 0.01f;
    }

    public void Update()
    {
      if (this.falling && !this.hidden)
      {
        this.fallTime += Main.dayRate;
        this.position += this.fallSpeed * (float) (Main.dayRate + 99) / 100f;
        if ((double) this.position.Y > 1500.0)
          this.hidden = true;
        this.twinkle += this.twinkleSpeed * 3f;
        if ((double) this.twinkle > 1.0)
        {
          this.twinkle = 1f;
          this.twinkleSpeed *= -1f;
        }
        else if ((double) this.twinkle < 0.6)
        {
          this.twinkle = 0.6f;
          this.twinkleSpeed *= -1f;
        }
        this.rotation += 0.5f;
        if ((double) this.rotation > 6.28)
          this.rotation -= 6.28f;
        if ((double) this.rotation >= 0.0)
          return;
        this.rotation += 6.28f;
      }
      else
      {
        if ((double) this.fadeIn > 0.0)
        {
          this.fadeIn -= 6.172839E-05f * (float) Main.dayRate;
          if ((double) this.fadeIn < 0.0)
            this.fadeIn = 0.0f;
        }
        this.twinkle += this.twinkleSpeed;
        if ((double) this.twinkle > 1.0)
        {
          this.twinkle = 1f;
          this.twinkleSpeed *= -1f;
        }
        else if ((double) this.twinkle < 0.6)
        {
          this.twinkle = 0.6f;
          this.twinkleSpeed *= -1f;
        }
        this.rotation += this.rotationSpeed;
        if ((double) this.rotation > 6.28)
          this.rotation -= 6.28f;
        if ((double) this.rotation >= 0.0)
          return;
        this.rotation += 6.28f;
      }
    }

    public static void UpdateStars()
    {
      if (!Main.dayTime)
        Star.dayCheck = false;
      else if (!Star.dayCheck && Main.time >= 27000.0)
      {
        for (int s = 0; s < Main.numStars; ++s)
        {
          if (Main.star[s].hidden)
            Star.SpawnStars(s);
        }
      }
      for (int index = 0; index < Main.numStars; ++index)
        Main.star[index].Update();
    }
  }
}
