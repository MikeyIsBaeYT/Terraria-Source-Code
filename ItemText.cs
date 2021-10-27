// Decompiled with JetBrains decompiler
// Type: Terraria.ItemText
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Localization;

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
    public bool NoStack;
    public bool coinText;
    public int coinValue;
    public bool expert;

    public static float TargetScale => Main.UIScale / Main.GameViewMatrix.Zoom.X;

    public static void NewText(Item newItem, int stack, bool noStack = false, bool longText = false)
    {
      bool flag = newItem.type >= 71 && newItem.type <= 74;
      if (!Main.showItemText || newItem.Name == null || !newItem.active || Main.netMode == 2)
        return;
      for (int index = 0; index < 20; ++index)
      {
        if (Main.itemText[index].active && (Main.itemText[index].name == newItem.AffixName() || flag && Main.itemText[index].coinText) && !Main.itemText[index].NoStack && !noStack)
        {
          string str1 = newItem.Name + " (" + (object) (Main.itemText[index].stack + stack) + ")";
          string str2 = newItem.Name;
          if (Main.itemText[index].stack > 1)
            str2 = str2 + " (" + (object) Main.itemText[index].stack + ")";
          Main.fontMouseText.MeasureString(str2);
          Vector2 vector2 = Main.fontMouseText.MeasureString(str1);
          if (Main.itemText[index].lifeTime < 0)
            Main.itemText[index].scale = 1f;
          if (Main.itemText[index].lifeTime < 60)
            Main.itemText[index].lifeTime = 60;
          if (flag && Main.itemText[index].coinText)
          {
            int num = 0;
            if (newItem.type == 71)
              num += newItem.stack;
            else if (newItem.type == 72)
              num += 100 * newItem.stack;
            else if (newItem.type == 73)
              num += 10000 * newItem.stack;
            else if (newItem.type == 74)
              num += 1000000 * newItem.stack;
            Main.itemText[index].coinValue += num;
            string name = ItemText.ValueToName(Main.itemText[index].coinValue);
            vector2 = Main.fontMouseText.MeasureString(name);
            Main.itemText[index].name = name;
            if (Main.itemText[index].coinValue >= 1000000)
            {
              if (Main.itemText[index].lifeTime < 300)
                Main.itemText[index].lifeTime = 300;
              Main.itemText[index].color = new Color(220, 220, 198);
            }
            else if (Main.itemText[index].coinValue >= 10000)
            {
              if (Main.itemText[index].lifeTime < 240)
                Main.itemText[index].lifeTime = 240;
              Main.itemText[index].color = new Color(224, 201, 92);
            }
            else if (Main.itemText[index].coinValue >= 100)
            {
              if (Main.itemText[index].lifeTime < 180)
                Main.itemText[index].lifeTime = 180;
              Main.itemText[index].color = new Color(181, 192, 193);
            }
            else if (Main.itemText[index].coinValue >= 1)
            {
              if (Main.itemText[index].lifeTime < 120)
                Main.itemText[index].lifeTime = 120;
              Main.itemText[index].color = new Color(246, 138, 96);
            }
          }
          Main.itemText[index].stack += stack;
          Main.itemText[index].scale = 0.0f;
          Main.itemText[index].rotation = 0.0f;
          Main.itemText[index].position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2.X * 0.5);
          Main.itemText[index].position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2.Y * 0.5);
          Main.itemText[index].velocity.Y = -7f;
          if (!Main.itemText[index].coinText)
            return;
          Main.itemText[index].stack = 1;
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
      string str = newItem.AffixName();
      if (stack > 1)
        str = str + " (" + (object) stack + ")";
      Vector2 vector2_1 = Main.fontMouseText.MeasureString(str);
      Main.itemText[index1].alpha = 1f;
      Main.itemText[index1].alphaDir = -1;
      Main.itemText[index1].active = true;
      Main.itemText[index1].scale = 0.0f;
      Main.itemText[index1].NoStack = noStack;
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
      else if (newItem.rare == -11)
        Main.itemText[index1].color = new Color((int) byte.MaxValue, 175, 0);
      else if (newItem.rare == -1)
        Main.itemText[index1].color = new Color(130, 130, 130);
      else if (newItem.rare == 6)
        Main.itemText[index1].color = new Color(210, 160, (int) byte.MaxValue);
      else if (newItem.rare == 7)
        Main.itemText[index1].color = new Color(150, (int) byte.MaxValue, 10);
      else if (newItem.rare == 8)
        Main.itemText[index1].color = new Color((int) byte.MaxValue, (int) byte.MaxValue, 10);
      else if (newItem.rare == 9)
        Main.itemText[index1].color = new Color(5, 200, (int) byte.MaxValue);
      else if (newItem.rare == 10)
        Main.itemText[index1].color = new Color((int) byte.MaxValue, 40, 100);
      else if (newItem.rare >= 11)
        Main.itemText[index1].color = new Color(180, 40, (int) byte.MaxValue);
      Main.itemText[index1].expert = newItem.expert;
      Main.itemText[index1].name = newItem.AffixName();
      Main.itemText[index1].stack = stack;
      Main.itemText[index1].velocity.Y = -7f;
      Main.itemText[index1].lifeTime = 60;
      if (longText)
        Main.itemText[index1].lifeTime *= 5;
      Main.itemText[index1].coinValue = 0;
      Main.itemText[index1].coinText = newItem.type >= 71 && newItem.type <= 74;
      if (!Main.itemText[index1].coinText)
        return;
      if (newItem.type == 71)
        Main.itemText[index1].coinValue += Main.itemText[index1].stack;
      else if (newItem.type == 72)
        Main.itemText[index1].coinValue += 100 * Main.itemText[index1].stack;
      else if (newItem.type == 73)
        Main.itemText[index1].coinValue += 10000 * Main.itemText[index1].stack;
      else if (newItem.type == 74)
        Main.itemText[index1].coinValue += 1000000 * Main.itemText[index1].stack;
      Main.itemText[index1].ValueToName();
      Main.itemText[index1].stack = 1;
      int index4 = index1;
      if (Main.itemText[index4].coinValue >= 1000000)
      {
        if (Main.itemText[index4].lifeTime < 300)
          Main.itemText[index4].lifeTime = 300;
        Main.itemText[index4].color = new Color(220, 220, 198);
      }
      else if (Main.itemText[index4].coinValue >= 10000)
      {
        if (Main.itemText[index4].lifeTime < 240)
          Main.itemText[index4].lifeTime = 240;
        Main.itemText[index4].color = new Color(224, 201, 92);
      }
      else if (Main.itemText[index4].coinValue >= 100)
      {
        if (Main.itemText[index4].lifeTime < 180)
          Main.itemText[index4].lifeTime = 180;
        Main.itemText[index4].color = new Color(181, 192, 193);
      }
      else
      {
        if (Main.itemText[index4].coinValue < 1)
          return;
        if (Main.itemText[index4].lifeTime < 120)
          Main.itemText[index4].lifeTime = 120;
        Main.itemText[index4].color = new Color(246, 138, 96);
      }
    }

    private static string ValueToName(int coinValue)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = coinValue;
      while (num5 > 0)
      {
        if (num5 >= 1000000)
        {
          num5 -= 1000000;
          ++num1;
        }
        else if (num5 >= 10000)
        {
          num5 -= 10000;
          ++num2;
        }
        else if (num5 >= 100)
        {
          num5 -= 100;
          ++num3;
        }
        else if (num5 >= 1)
        {
          --num5;
          ++num4;
        }
      }
      string str = "";
      if (num1 > 0)
        str = str + (object) num1 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Platinum"));
      if (num2 > 0)
        str = str + (object) num2 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Gold"));
      if (num3 > 0)
        str = str + (object) num3 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Silver"));
      if (num4 > 0)
        str = str + (object) num4 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Copper"));
      if (str.Length > 1)
        str = str.Substring(0, str.Length - 1);
      return str;
    }

    private void ValueToName()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int coinValue = this.coinValue;
      while (coinValue > 0)
      {
        if (coinValue >= 1000000)
        {
          coinValue -= 1000000;
          ++num1;
        }
        else if (coinValue >= 10000)
        {
          coinValue -= 10000;
          ++num2;
        }
        else if (coinValue >= 100)
        {
          coinValue -= 100;
          ++num3;
        }
        else if (coinValue >= 1)
        {
          --coinValue;
          ++num4;
        }
      }
      this.name = "";
      if (num1 > 0)
        this.name = this.name + (object) num1 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Platinum"));
      if (num2 > 0)
        this.name = this.name + (object) num2 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Gold"));
      if (num3 > 0)
        this.name = this.name + (object) num3 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Silver"));
      if (num4 > 0)
        this.name = this.name + (object) num4 + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Copper"));
      if (this.name.Length <= 1)
        return;
      this.name = this.name.Substring(0, this.name.Length - 1);
    }

    public void Update(int whoAmI)
    {
      if (!this.active)
        return;
      float targetScale = ItemText.TargetScale;
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
      if (this.expert && this.expert)
        this.color = new Color((int) (byte) Main.DiscoR, (int) (byte) Main.DiscoG, (int) (byte) Main.DiscoB, (int) Main.mouseTextColor);
      bool flag = false;
      string str1 = this.name;
      if (this.stack > 1)
        str1 = str1 + " (" + (object) this.stack + ")";
      Vector2 vector2_1 = Main.fontMouseText.MeasureString(str1) * this.scale;
      vector2_1.Y *= 0.8f;
      Rectangle rectangle1 = new Rectangle((int) ((double) this.position.X - (double) vector2_1.X / 2.0), (int) ((double) this.position.Y - (double) vector2_1.Y / 2.0), (int) vector2_1.X, (int) vector2_1.Y);
      for (int index = 0; index < 20; ++index)
      {
        if (Main.itemText[index].active && index != whoAmI)
        {
          string str2 = Main.itemText[index].name;
          if (Main.itemText[index].stack > 1)
            str2 = str2 + " (" + (object) Main.itemText[index].stack + ")";
          Vector2 vector2_2 = Main.fontMouseText.MeasureString(str2) * Main.itemText[index].scale;
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
        if ((double) this.scale == (double) targetScale)
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
        this.scale -= 0.03f * targetScale;
        if ((double) this.scale < 0.1 * (double) targetScale)
          this.active = false;
        this.lifeTime = 0;
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
