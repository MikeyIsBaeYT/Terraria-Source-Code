// Decompiled with JetBrains decompiler
// Type: Terraria.CombatText
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public class CombatText
  {
    public Vector2 position;
    public Vector2 velocity;
    public float alpha;
    public int alphaDir = 1;
    public string text;
    public float scale = 1f;
    public float rotation;
    public Color color;
    public bool active;
    public int lifeTime;
    public bool crit;

    public static void NewText(Rectangle location, Color color, string text, bool Crit = false)
    {
      if (Main.netMode == 2)
        return;
      for (int index1 = 0; index1 < 100; ++index1)
      {
        if (!Main.combatText[index1].active)
        {
          int index2 = 0;
          if (Crit)
            index2 = 1;
          Vector2 vector2 = Main.fontCombatText[index2].MeasureString(text);
          Main.combatText[index1].alpha = 1f;
          Main.combatText[index1].alphaDir = -1;
          Main.combatText[index1].active = true;
          Main.combatText[index1].scale = 0.0f;
          Main.combatText[index1].rotation = 0.0f;
          Main.combatText[index1].position.X = (float) ((double) location.X + (double) location.Width * 0.5 - (double) vector2.X * 0.5);
          Main.combatText[index1].position.Y = (float) ((double) location.Y + (double) location.Height * 0.25 - (double) vector2.Y * 0.5);
          Main.combatText[index1].position.X += (float) Main.rand.Next(-(int) ((double) location.Width * 0.5), (int) ((double) location.Width * 0.5) + 1);
          Main.combatText[index1].position.Y += (float) Main.rand.Next(-(int) ((double) location.Height * 0.5), (int) ((double) location.Height * 0.5) + 1);
          Main.combatText[index1].color = color;
          Main.combatText[index1].text = text;
          Main.combatText[index1].velocity.Y = -7f;
          Main.combatText[index1].lifeTime = 60;
          Main.combatText[index1].crit = Crit;
          if (!Crit)
            break;
          Main.combatText[index1].text = text;
          Main.combatText[index1].color = new Color((int) byte.MaxValue, 100, 30, (int) byte.MaxValue);
          Main.combatText[index1].lifeTime *= 2;
          Main.combatText[index1].velocity.Y *= 2f;
          Main.combatText[index1].velocity.X = (float) Main.rand.Next(-25, 26) * 0.05f;
          Main.combatText[index1].rotation = (float) (Main.combatText[index1].lifeTime / 2) * (1f / 500f);
          if ((double) Main.combatText[index1].velocity.X >= 0.0)
            break;
          Main.combatText[index1].rotation *= -1f;
          break;
        }
      }
    }

    public void Update()
    {
      if (!this.active)
        return;
      this.alpha += (float) this.alphaDir * 0.05f;
      if ((double) this.alpha <= 0.6)
        this.alphaDir = 1;
      if ((double) this.alpha >= 1.0)
      {
        this.alpha = 1f;
        this.alphaDir = -1;
      }
      this.velocity.Y *= 0.92f;
      if (this.crit)
        this.velocity.Y *= 0.92f;
      this.velocity.X *= 0.93f;
      this.position += this.velocity;
      --this.lifeTime;
      if (this.lifeTime <= 0)
      {
        this.scale -= 0.1f;
        if ((double) this.scale < 0.1)
          this.active = false;
        this.lifeTime = 0;
        if (!this.crit)
          return;
        this.alphaDir = -1;
        this.scale += 0.07f;
      }
      else
      {
        if (this.crit)
        {
          if ((double) this.velocity.X < 0.0)
            this.rotation += 1f / 1000f;
          else
            this.rotation -= 1f / 1000f;
        }
        if ((double) this.scale < 1.0)
          this.scale += 0.1f;
        if ((double) this.scale <= 1.0)
          return;
        this.scale = 1f;
      }
    }

    public static void UpdateCombatText()
    {
      for (int index = 0; index < 100; ++index)
      {
        if (Main.combatText[index].active)
          Main.combatText[index].Update();
      }
    }
  }
}
