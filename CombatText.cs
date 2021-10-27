// Decompiled with JetBrains decompiler
// Type: Terraria.CombatText
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public class CombatText
  {
    public static readonly Color DamagedFriendly = new Color((int) byte.MaxValue, 80, 90, (int) byte.MaxValue);
    public static readonly Color DamagedFriendlyCrit = new Color((int) byte.MaxValue, 100, 30, (int) byte.MaxValue);
    public static readonly Color DamagedHostile = new Color((int) byte.MaxValue, 160, 80, (int) byte.MaxValue);
    public static readonly Color DamagedHostileCrit = new Color((int) byte.MaxValue, 100, 30, (int) byte.MaxValue);
    public static readonly Color OthersDamagedHostile = CombatText.DamagedHostile * 0.4f;
    public static readonly Color OthersDamagedHostileCrit = CombatText.DamagedHostileCrit * 0.4f;
    public static readonly Color HealLife = new Color(100, (int) byte.MaxValue, 100, (int) byte.MaxValue);
    public static readonly Color HealMana = new Color(100, 100, (int) byte.MaxValue, (int) byte.MaxValue);
    public static readonly Color LifeRegen = new Color((int) byte.MaxValue, 60, 70, (int) byte.MaxValue);
    public static readonly Color LifeRegenNegative = new Color((int) byte.MaxValue, 140, 40, (int) byte.MaxValue);
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
    public bool dot;

    public static int NewText(
      Rectangle location,
      Color color,
      int amount,
      bool dramatic = false,
      bool dot = false)
    {
      return CombatText.NewText(location, color, amount.ToString(), dramatic, dot);
    }

    public static int NewText(
      Rectangle location,
      Color color,
      string text,
      bool dramatic = false,
      bool dot = false)
    {
      if (Main.netMode == 2)
        return 100;
      for (int index1 = 0; index1 < 100; ++index1)
      {
        if (!Main.combatText[index1].active)
        {
          int index2 = 0;
          if (dramatic)
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
          if ((double) Main.player[Main.myPlayer].gravDir == -1.0)
          {
            Main.combatText[index1].velocity.Y *= -1f;
            Main.combatText[index1].position.Y = (float) ((double) location.Y + (double) location.Height * 0.75 + (double) vector2.Y * 0.5);
          }
          Main.combatText[index1].lifeTime = 60;
          Main.combatText[index1].crit = dramatic;
          Main.combatText[index1].dot = dot;
          if (dramatic)
          {
            Main.combatText[index1].text = text;
            Main.combatText[index1].lifeTime *= 2;
            Main.combatText[index1].velocity.Y *= 2f;
            Main.combatText[index1].velocity.X = (float) Main.rand.Next(-25, 26) * 0.05f;
            Main.combatText[index1].rotation = (float) (Main.combatText[index1].lifeTime / 2) * (1f / 500f);
            if ((double) Main.combatText[index1].velocity.X < 0.0)
              Main.combatText[index1].rotation *= -1f;
          }
          if (dot)
          {
            Main.combatText[index1].velocity.Y = -4f;
            Main.combatText[index1].lifeTime = 40;
          }
          return index1;
        }
      }
      return 100;
    }

    public static void clearAll()
    {
      for (int index = 0; index < 100; ++index)
        Main.combatText[index].active = false;
    }

    public static float TargetScale => Main.UIScale / (Main.GameViewMatrix.Zoom.X / Main.ForcedMinimumZoom);

    public void Update()
    {
      if (!this.active)
        return;
      float targetScale = CombatText.TargetScale;
      this.alpha += (float) this.alphaDir * 0.05f;
      if ((double) this.alpha <= 0.6)
        this.alphaDir = 1;
      if ((double) this.alpha >= 1.0)
      {
        this.alpha = 1f;
        this.alphaDir = -1;
      }
      if (this.dot)
      {
        this.velocity.Y += 0.15f;
      }
      else
      {
        this.velocity.Y *= 0.92f;
        if (this.crit)
          this.velocity.Y *= 0.92f;
      }
      this.velocity.X *= 0.93f;
      this.position += this.velocity;
      --this.lifeTime;
      if (this.lifeTime <= 0)
      {
        this.scale -= 0.1f * targetScale;
        if ((double) this.scale < 0.1)
          this.active = false;
        this.lifeTime = 0;
        if (!this.crit)
          return;
        this.alphaDir = -1;
        this.scale += 0.07f * targetScale;
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
        if (this.dot)
        {
          this.scale += 0.5f * targetScale;
          if ((double) this.scale <= 0.8 * (double) targetScale)
            return;
          this.scale = 0.8f * targetScale;
        }
        else
        {
          if ((double) this.scale < (double) targetScale)
            this.scale += 0.1f * targetScale;
          if ((double) this.scale <= (double) targetScale)
            return;
          this.scale = targetScale;
        }
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
