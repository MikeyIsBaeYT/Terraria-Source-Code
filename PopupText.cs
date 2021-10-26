// Decompiled with JetBrains decompiler
// Type: Terraria.PopupText
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.Localization;

namespace Terraria
{
  public class PopupText
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
    public static int sonarText = -1;
    public bool expert;
    public bool master;
    public bool sonar;
    public PopupTextContext context;
    public int npcNetID;

    public bool notActuallyAnItem => (uint) this.npcNetID > 0U;

    public static float TargetScale => Main.UIScale / Main.GameViewMatrix.Zoom.X;

    public static void ClearSonarText()
    {
      if (PopupText.sonarText < 0 || !Main.popupText[PopupText.sonarText].sonar)
        return;
      Main.popupText[PopupText.sonarText].active = false;
      PopupText.sonarText = -1;
    }

    public static int NewText(
      PopupTextContext context,
      int npcNetID,
      Vector2 position,
      bool stay5TimesLonger)
    {
      if (!Main.showItemText || npcNetID == 0 || Main.netMode == 2)
        return -1;
      int nextItemTextSlot = PopupText.FindNextItemTextSlot();
      if (nextItemTextSlot >= 0)
      {
        NPC npc = new NPC();
        npc.SetDefaults(npcNetID);
        string typeName = npc.TypeName;
        Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(typeName);
        PopupText popupText = Main.popupText[nextItemTextSlot];
        Main.popupText[nextItemTextSlot].alpha = 1f;
        popupText.alphaDir = -1;
        popupText.active = true;
        popupText.scale = 0.0f;
        popupText.NoStack = true;
        popupText.rotation = 0.0f;
        popupText.position = position - vector2 / 2f;
        popupText.expert = false;
        popupText.master = false;
        popupText.name = typeName;
        popupText.stack = 1;
        popupText.velocity.Y = -7f;
        popupText.lifeTime = 60;
        popupText.context = context;
        if (stay5TimesLonger)
          popupText.lifeTime *= 5;
        popupText.npcNetID = npcNetID;
        popupText.coinValue = 0;
        popupText.coinText = false;
        popupText.color = Color.White;
        if (context == PopupTextContext.SonarAlert)
          popupText.color = Color.Lerp(Color.White, Color.Crimson, 0.5f);
      }
      return nextItemTextSlot;
    }

    public static int NewText(
      PopupTextContext context,
      Item newItem,
      int stack,
      bool noStack = false,
      bool longText = false)
    {
      if (!Main.showItemText || newItem.Name == null || !newItem.active || Main.netMode == 2)
        return -1;
      bool flag = newItem.type >= 71 && newItem.type <= 74;
      for (int index = 0; index < 20; ++index)
      {
        if (Main.popupText[index].active && !Main.popupText[index].notActuallyAnItem && (Main.popupText[index].name == newItem.AffixName() || flag && Main.popupText[index].coinText) && !Main.popupText[index].NoStack && !noStack)
        {
          string str1 = newItem.Name + " (" + (object) (Main.popupText[index].stack + stack) + ")";
          string str2 = newItem.Name;
          if (Main.popupText[index].stack > 1)
            str2 = str2 + " (" + (object) Main.popupText[index].stack + ")";
          FontAssets.MouseText.Value.MeasureString(str2);
          Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(str1);
          if (Main.popupText[index].lifeTime < 0)
            Main.popupText[index].scale = 1f;
          if (Main.popupText[index].lifeTime < 60)
            Main.popupText[index].lifeTime = 60;
          if (flag && Main.popupText[index].coinText)
          {
            int num = 0;
            if (newItem.type == 71)
              num += stack;
            else if (newItem.type == 72)
              num += 100 * stack;
            else if (newItem.type == 73)
              num += 10000 * stack;
            else if (newItem.type == 74)
              num += 1000000 * stack;
            Main.popupText[index].coinValue += num;
            string name = PopupText.ValueToName(Main.popupText[index].coinValue);
            vector2 = FontAssets.MouseText.Value.MeasureString(name);
            Main.popupText[index].name = name;
            if (Main.popupText[index].coinValue >= 1000000)
            {
              if (Main.popupText[index].lifeTime < 300)
                Main.popupText[index].lifeTime = 300;
              Main.popupText[index].color = new Color(220, 220, 198);
            }
            else if (Main.popupText[index].coinValue >= 10000)
            {
              if (Main.popupText[index].lifeTime < 240)
                Main.popupText[index].lifeTime = 240;
              Main.popupText[index].color = new Color(224, 201, 92);
            }
            else if (Main.popupText[index].coinValue >= 100)
            {
              if (Main.popupText[index].lifeTime < 180)
                Main.popupText[index].lifeTime = 180;
              Main.popupText[index].color = new Color(181, 192, 193);
            }
            else if (Main.popupText[index].coinValue >= 1)
            {
              if (Main.popupText[index].lifeTime < 120)
                Main.popupText[index].lifeTime = 120;
              Main.popupText[index].color = new Color(246, 138, 96);
            }
          }
          Main.popupText[index].stack += stack;
          Main.popupText[index].scale = 0.0f;
          Main.popupText[index].rotation = 0.0f;
          Main.popupText[index].position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2.X * 0.5);
          Main.popupText[index].position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2.Y * 0.5);
          Main.popupText[index].velocity.Y = -7f;
          Main.popupText[index].context = context;
          Main.popupText[index].npcNetID = 0;
          if (Main.popupText[index].coinText)
            Main.popupText[index].stack = 1;
          return index;
        }
      }
      int nextItemTextSlot = PopupText.FindNextItemTextSlot();
      if (nextItemTextSlot >= 0)
      {
        string str = newItem.AffixName();
        if (stack > 1)
          str = str + " (" + (object) stack + ")";
        Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(str);
        Main.popupText[nextItemTextSlot].alpha = 1f;
        Main.popupText[nextItemTextSlot].alphaDir = -1;
        Main.popupText[nextItemTextSlot].active = true;
        Main.popupText[nextItemTextSlot].scale = 0.0f;
        Main.popupText[nextItemTextSlot].NoStack = noStack;
        Main.popupText[nextItemTextSlot].rotation = 0.0f;
        Main.popupText[nextItemTextSlot].position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2.X * 0.5);
        Main.popupText[nextItemTextSlot].position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2.Y * 0.5);
        Main.popupText[nextItemTextSlot].color = Color.White;
        Main.popupText[nextItemTextSlot].master = false;
        if (newItem.rare == 1)
          Main.popupText[nextItemTextSlot].color = new Color(150, 150, (int) byte.MaxValue);
        else if (newItem.rare == 2)
          Main.popupText[nextItemTextSlot].color = new Color(150, (int) byte.MaxValue, 150);
        else if (newItem.rare == 3)
          Main.popupText[nextItemTextSlot].color = new Color((int) byte.MaxValue, 200, 150);
        else if (newItem.rare == 4)
          Main.popupText[nextItemTextSlot].color = new Color((int) byte.MaxValue, 150, 150);
        else if (newItem.rare == 5)
          Main.popupText[nextItemTextSlot].color = new Color((int) byte.MaxValue, 150, (int) byte.MaxValue);
        else if (newItem.rare == -13)
          Main.popupText[nextItemTextSlot].master = true;
        else if (newItem.rare == -11)
          Main.popupText[nextItemTextSlot].color = new Color((int) byte.MaxValue, 175, 0);
        else if (newItem.rare == -1)
          Main.popupText[nextItemTextSlot].color = new Color(130, 130, 130);
        else if (newItem.rare == 6)
          Main.popupText[nextItemTextSlot].color = new Color(210, 160, (int) byte.MaxValue);
        else if (newItem.rare == 7)
          Main.popupText[nextItemTextSlot].color = new Color(150, (int) byte.MaxValue, 10);
        else if (newItem.rare == 8)
          Main.popupText[nextItemTextSlot].color = new Color((int) byte.MaxValue, (int) byte.MaxValue, 10);
        else if (newItem.rare == 9)
          Main.popupText[nextItemTextSlot].color = new Color(5, 200, (int) byte.MaxValue);
        else if (newItem.rare == 10)
          Main.popupText[nextItemTextSlot].color = new Color((int) byte.MaxValue, 40, 100);
        else if (newItem.rare >= 11)
          Main.popupText[nextItemTextSlot].color = new Color(180, 40, (int) byte.MaxValue);
        Main.popupText[nextItemTextSlot].expert = newItem.expert;
        Main.popupText[nextItemTextSlot].name = newItem.AffixName();
        Main.popupText[nextItemTextSlot].stack = stack;
        Main.popupText[nextItemTextSlot].velocity.Y = -7f;
        Main.popupText[nextItemTextSlot].lifeTime = 60;
        Main.popupText[nextItemTextSlot].context = context;
        Main.popupText[nextItemTextSlot].npcNetID = 0;
        if (longText)
          Main.popupText[nextItemTextSlot].lifeTime *= 5;
        Main.popupText[nextItemTextSlot].coinValue = 0;
        Main.popupText[nextItemTextSlot].coinText = newItem.type >= 71 && newItem.type <= 74;
        if (Main.popupText[nextItemTextSlot].coinText)
        {
          if (newItem.type == 71)
            Main.popupText[nextItemTextSlot].coinValue += Main.popupText[nextItemTextSlot].stack;
          else if (newItem.type == 72)
            Main.popupText[nextItemTextSlot].coinValue += 100 * Main.popupText[nextItemTextSlot].stack;
          else if (newItem.type == 73)
            Main.popupText[nextItemTextSlot].coinValue += 10000 * Main.popupText[nextItemTextSlot].stack;
          else if (newItem.type == 74)
            Main.popupText[nextItemTextSlot].coinValue += 1000000 * Main.popupText[nextItemTextSlot].stack;
          Main.popupText[nextItemTextSlot].ValueToName();
          Main.popupText[nextItemTextSlot].stack = 1;
          int index = nextItemTextSlot;
          if (Main.popupText[index].coinValue >= 1000000)
          {
            if (Main.popupText[index].lifeTime < 300)
              Main.popupText[index].lifeTime = 300;
            Main.popupText[index].color = new Color(220, 220, 198);
          }
          else if (Main.popupText[index].coinValue >= 10000)
          {
            if (Main.popupText[index].lifeTime < 240)
              Main.popupText[index].lifeTime = 240;
            Main.popupText[index].color = new Color(224, 201, 92);
          }
          else if (Main.popupText[index].coinValue >= 100)
          {
            if (Main.popupText[index].lifeTime < 180)
              Main.popupText[index].lifeTime = 180;
            Main.popupText[index].color = new Color(181, 192, 193);
          }
          else if (Main.popupText[index].coinValue >= 1)
          {
            if (Main.popupText[index].lifeTime < 120)
              Main.popupText[index].lifeTime = 120;
            Main.popupText[index].color = new Color(246, 138, 96);
          }
        }
      }
      return nextItemTextSlot;
    }

    private static int FindNextItemTextSlot()
    {
      int num1 = -1;
      for (int index = 0; index < 20; ++index)
      {
        if (!Main.popupText[index].active)
        {
          num1 = index;
          break;
        }
      }
      if (num1 == -1)
      {
        double num2 = (double) Main.bottomWorld;
        for (int index = 0; index < 20; ++index)
        {
          if (num2 > (double) Main.popupText[index].position.Y)
          {
            num1 = index;
            num2 = (double) Main.popupText[index].position.Y;
          }
        }
      }
      return num1;
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
      float targetScale = PopupText.TargetScale;
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
      if (this.expert)
        this.color = new Color((int) (byte) Main.DiscoR, (int) (byte) Main.DiscoG, (int) (byte) Main.DiscoB, (int) Main.mouseTextColor);
      else if (this.master)
        this.color = new Color((int) byte.MaxValue, (int) (byte) ((double) Main.masterColor * 200.0), 0, (int) Main.mouseTextColor);
      bool flag = false;
      string str1 = this.name;
      if (this.stack > 1)
        str1 = str1 + " (" + (object) this.stack + ")";
      Vector2 vector2_1 = FontAssets.MouseText.Value.MeasureString(str1) * this.scale;
      vector2_1.Y *= 0.8f;
      Rectangle rectangle1 = new Rectangle((int) ((double) this.position.X - (double) vector2_1.X / 2.0), (int) ((double) this.position.Y - (double) vector2_1.Y / 2.0), (int) vector2_1.X, (int) vector2_1.Y);
      for (int index = 0; index < 20; ++index)
      {
        if (Main.popupText[index].active && index != whoAmI)
        {
          string str2 = Main.popupText[index].name;
          if (Main.popupText[index].stack > 1)
            str2 = str2 + " (" + (object) Main.popupText[index].stack + ")";
          Vector2 vector2_2 = FontAssets.MouseText.Value.MeasureString(str2) * Main.popupText[index].scale;
          vector2_2.Y *= 0.8f;
          Rectangle rectangle2 = new Rectangle((int) ((double) Main.popupText[index].position.X - (double) vector2_2.X / 2.0), (int) ((double) Main.popupText[index].position.Y - (double) vector2_2.Y / 2.0), (int) vector2_2.X, (int) vector2_2.Y);
          if (rectangle1.Intersects(rectangle2) && ((double) this.position.Y < (double) Main.popupText[index].position.Y || (double) this.position.Y == (double) Main.popupText[index].position.Y && whoAmI < index))
          {
            flag = true;
            int num = PopupText.numActive;
            if (num > 3)
              num = 3;
            Main.popupText[index].lifeTime = PopupText.activeTime + 15 * num;
            this.lifeTime = PopupText.activeTime + 15 * num;
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
        {
          this.active = false;
          if (PopupText.sonarText == whoAmI)
            PopupText.sonarText = -1;
        }
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
        if (Main.popupText[whoAmI].active)
        {
          ++num;
          Main.popupText[whoAmI].Update(whoAmI);
        }
      }
      PopupText.numActive = num;
    }
  }
}
