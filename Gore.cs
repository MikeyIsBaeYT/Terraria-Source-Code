// Decompiled with JetBrains decompiler
// Type: Terraria.Gore
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public class Gore
  {
    public static int goreTime = 600;
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float scale;
    public int alpha;
    public int type;
    public float light;
    public bool active;
    public bool sticky = true;
    public int timeLeft = Gore.goreTime;

    public void Update()
    {
      if (Main.netMode == 2 || !this.active)
        return;
      if (this.type == 11 || this.type == 12 || this.type == 13 || this.type == 61 || this.type == 62 || this.type == 63 || this.type == 99)
      {
        this.velocity.Y *= 0.98f;
        this.velocity.X *= 0.98f;
        this.scale -= 0.007f;
        if ((double) this.scale < 0.1)
        {
          this.scale = 0.1f;
          this.alpha = (int) byte.MaxValue;
        }
      }
      else if (this.type == 16 || this.type == 17)
      {
        this.velocity.Y *= 0.98f;
        this.velocity.X *= 0.98f;
        this.scale -= 0.01f;
        if ((double) this.scale < 0.1)
        {
          this.scale = 0.1f;
          this.alpha = (int) byte.MaxValue;
        }
      }
      else
        this.velocity.Y += 0.2f;
      this.rotation += this.velocity.X * 0.1f;
      if (this.sticky)
      {
        int num1 = Main.goreTexture[this.type].Width;
        if (Main.goreTexture[this.type].Height < num1)
          num1 = Main.goreTexture[this.type].Height;
        int num2 = (int) ((double) num1 * 0.899999976158142);
        this.velocity = Collision.TileCollision(this.position, this.velocity, (int) ((double) num2 * (double) this.scale), (int) ((double) num2 * (double) this.scale));
        if ((double) this.velocity.Y == 0.0)
        {
          this.velocity.X *= 0.97f;
          if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
            this.velocity.X = 0.0f;
        }
        if (this.timeLeft > 0)
          --this.timeLeft;
        else
          ++this.alpha;
      }
      else
        this.alpha += 2;
      this.position += this.velocity;
      if (this.alpha >= (int) byte.MaxValue)
        this.active = false;
      if ((double) this.light <= 0.0)
        return;
      float R = this.light * this.scale;
      float G = this.light * this.scale;
      float B = this.light * this.scale;
      if (this.type == 16)
      {
        B *= 0.3f;
        G *= 0.8f;
      }
      else if (this.type == 17)
      {
        G *= 0.6f;
        R *= 0.3f;
      }
      Lighting.addLight((int) (((double) this.position.X + (double) Main.goreTexture[this.type].Width * (double) this.scale / 2.0) / 16.0), (int) (((double) this.position.Y + (double) Main.goreTexture[this.type].Height * (double) this.scale / 2.0) / 16.0), R, G, B);
    }

    public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
    {
      if (Main.rand == null)
        Main.rand = new Random();
      if (Main.netMode == 2)
        return 0;
      int index1 = 200;
      for (int index2 = 0; index2 < 200; ++index2)
      {
        if (!Main.gore[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == 200)
        return index1;
      Main.gore[index1].light = 0.0f;
      Main.gore[index1].position = Position;
      Main.gore[index1].velocity = Velocity;
      Main.gore[index1].velocity.Y -= (float) Main.rand.Next(10, 31) * 0.1f;
      Main.gore[index1].velocity.X += (float) Main.rand.Next(-20, 21) * 0.1f;
      Main.gore[index1].type = Type;
      Main.gore[index1].active = true;
      Main.gore[index1].alpha = 0;
      Main.gore[index1].rotation = 0.0f;
      Main.gore[index1].scale = Scale;
      if (Gore.goreTime == 0 || Type == 11 || Type == 12 || Type == 13 || Type == 16 || Type == 17 || Type == 61 || Type == 62 || Type == 63 || Type == 99)
      {
        Main.gore[index1].sticky = false;
      }
      else
      {
        Main.gore[index1].sticky = true;
        Main.gore[index1].timeLeft = Gore.goreTime;
      }
      if (Type == 16 || Type == 17)
      {
        Main.gore[index1].alpha = 100;
        Main.gore[index1].scale = 0.7f;
        Main.gore[index1].light = 1f;
      }
      return index1;
    }

    public Color GetAlpha(Color newColor)
    {
      float num = (float) ((int) byte.MaxValue - this.alpha) / (float) byte.MaxValue;
      int r;
      int g;
      int b;
      if (this.type == 16 || this.type == 17)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else
      {
        r = (int) ((double) newColor.R * (double) num);
        g = (int) ((double) newColor.G * (double) num);
        b = (int) ((double) newColor.B * (double) num);
      }
      int a = (int) newColor.A - this.alpha;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }
  }
}
