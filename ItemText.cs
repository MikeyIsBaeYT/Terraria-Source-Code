// Decompiled with JetBrains decompiler
// Type: Terraria.ItemText
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public class ItemText
  {
    public Vector2 position;
    public Vector2 velocity;
    public float alpha;
    public int alphaDir = 1;
    public string name;
    public int stack;
    public float scale = 1f;
    public float rotation;
    public Color color;
    public bool active;
    public int lifeTime;
    public static int activeTime = 60;
    public static int numActive;

    public static void NewText(Item newItem, int stack)
    {
      if (!Main.showItemText || newItem.name == null || !newItem.active || Main.netMode == 2)
        return;
      for (int index = 0; index < 20; ++index)
      {
        if (Main.itemText[index].active && Main.itemText[index].name == newItem.name)
        {
          string text1 = newItem.name + " (" + (object) (Main.itemText[index].stack + stack) + ")";
          string text2 = newItem.name;
          if (Main.itemText[index].stack > 1)
            text2 = text2 + " (" + (object) Main.itemText[index].stack + ")";
          Main.fontMouseText.MeasureString(text2);
          Vector2 vector2 = Main.fontMouseText.MeasureString(text1);
          if (Main.itemText[index].lifeTime < 0)
            Main.itemText[index].scale = 1f;
          Main.itemText[index].lifeTime = 60;
          Main.itemText[index].stack += stack;
          Main.itemText[index].scale = 0.0f;
          Main.itemText[index].rotation = 0.0f;
          Main.itemText[index].position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2.X * 0.5);
          Main.itemText[index].position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2.Y * 0.5);
          Main.itemText[index].velocity.Y = -7f;
          return;
        }
      }
      int index1 = -1;
      for (int index2 = 0; index2 < 20; ++index2)
      {
        if (!Main.itemText[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1)
      {
        double num = (double) Main.bottomWorld;
        for (int index3 = 0; index3 < 20; ++index3)
        {
          if (num > (double) Main.itemText[index3].position.Y)
          {
            index1 = index3;
            num = (double) Main.itemText[index3].position.Y;
          }
        }
      }
      if (index1 < 0)
        return;
      string text = newItem.AffixName();
      if (stack > 1)
        text = text + " (" + (object) stack + ")";
      Vector2 vector2_1 = Main.fontMouseText.MeasureString(text);
      Main.itemText[index1].alpha = 1f;
      Main.itemText[index1].alphaDir = -1;
      Main.itemText[index1].active = true;
      Main.itemText[index1].scale = 0.0f;
      Main.itemText[index1].rotation = 0.0f;
      Main.itemText[index1].position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2_1.X * 0.5);
      Main.itemText[index1].position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2_1.Y * 0.5);
      Main.itemText[index1].color = Color.White;
      if (newItem.rare == 1)
        Main.itemText[index1].color = new Color(150, 150, (int) byte.MaxValue);
      else if (newItem.rare == 2)
        Main.itemText[index1].color = new Color(150, (int) byte.MaxValue, 150);
      else if (newItem.rare == 3)
        Main.itemText[index1].color = new Color((int) byte.MaxValue, 200, 150);
      else if (newItem.rare == 4)
        Main.itemText[index1].color = new Color((int) byte.MaxValue, 150, 150);
      else if (newItem.rare == 5)
        Main.itemText[index1].color = new Color((int) byte.MaxValue, 150, (int) byte.MaxValue);
      else if (newItem.rare == -1)
        Main.itemText[index1].color = new Color(130, 130, 130);
      else if (newItem.rare == 6)
        Main.itemText[index1].color = new Color(210, 160, (int) byte.MaxValue);
      Main.itemText[index1].name = newItem.AffixName();
      Main.itemText[index1].stack = stack;
      Main.itemText[index1].velocity.Y = -7f;
      Main.itemText[index1].lifeTime = 60;
    }

    public void Update(int whoAmI)
    {
      if (!this.active)
        return;
      this.alpha += (float) this.alphaDir * 0.01f;
      if ((double) this.alpha <= 0.7)
      {
        this.alpha = 0.7f;
        this.alphaDir = 1;
      }
      if ((double) this.alpha >= 1.0)
      {
        this.alpha = 1f;
        this.alphaDir = -1;
      }
      bool flag = false;
      string text1 = this.name;
      if (this.stack > 1)
        text1 = text1 + " (" + (object) this.stack + ")";
      Vector2 vector2_1 = Main.fontMouseText.MeasureString(text1) * this.scale;
      vector2_1.Y *= 0.8f;
      Rectangle rectangle1 = new Rectangle((int) ((double) this.position.X - (double) vector2_1.X / 2.0), (int) ((double) this.position.Y - (double) vector2_1.Y / 2.0), (int) vector2_1.X, (int) vector2_1.Y);
      for (int index = 0; index < 20; ++index)
      {
        if (Main.itemText[index].active && index != whoAmI)
        {
          string text2 = Main.itemText[index].name;
          if (Main.itemText[index].stack > 1)
            text2 = text2 + " (" + (object) Main.itemText[index].stack + ")";
          Vector2 vector2_2 = Main.fontMouseText.MeasureString(text2);
          vector2_2 *= Main.itemText[index].scale;
          vector2_2.Y *= 0.8f;
          Rectangle rectangle2 = new Rectangle((int) ((double) Main.itemText[index].position.X - (double) vector2_2.X / 2.0), (int) ((double) Main.itemText[index].position.Y - (double) vector2_2.Y / 2.0), (int) vector2_2.X, (int) vector2_2.Y);
          if (rectangle1.Intersects(rectangle2) && ((double) this.position.Y < (double) Main.itemText[index].position.Y || (double) this.position.Y == (double) Main.itemText[index].position.Y && whoAmI < index))
          {
            flag = true;
            int num = ItemText.numActive;
            if (num > 3)
              num = 3;
            Main.itemText[index].lifeTime = ItemText.activeTime + 15 * num;
            this.lifeTime = ItemText.activeTime + 15 * num;
          }
        }
      }
      if (!flag)
      {
        this.velocity.Y *= 0.86f;
        if ((double) this.scale == 1.0)
          this.velocity.Y *= 0.4f;
      }
      else if ((double) this.velocity.Y > -6.0)
        this.velocity.Y -= 0.2f;
      else
        this.velocity.Y *= 0.86f;
      this.velocity.X *= 0.93f;
      this.position += this.velocity;
      --this.lifeTime;
      if (this.lifeTime <= 0)
      {
        this.scale -= 0.03f;
        if ((double) this.scale < 0.1)
          this.active = false;
        this.lifeTime = 0;
      }
      else
      {
        if ((double) this.scale < 1.0)
          this.scale += 0.1f;
        if ((double) this.scale <= 1.0)
          return;
        this.scale = 1f;
      }
    }

    public static void UpdateItemText()
    {
      int num = 0;
      for (int whoAmI = 0; whoAmI < 20; ++whoAmI)
      {
        if (Main.itemText[whoAmI].active)
        {
          ++num;
          Main.itemText[whoAmI].Update(whoAmI);
        }
      }
      ItemText.numActive = num;
    }
  }
}
