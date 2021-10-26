// Decompiled with JetBrains decompiler
// Type: Terraria.Sign
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria
{
  public class Sign
  {
    public const int maxSigns = 1000;
    public int x;
    public int y;
    public string text;

    public object Clone() => this.MemberwiseClone();

    public static void KillSign(int x, int y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.sign[index] != null && Main.sign[index].x == x && Main.sign[index].y == y)
          Main.sign[index] = (Sign) null;
      }
    }

    public static int ReadSign(int i, int j)
    {
      int num1 = (int) Main.tile[i, j].frameX / 18;
      int num2 = (int) Main.tile[i, j].frameY / 18;
      while (num1 > 1)
        num1 -= 2;
      int x = i - num1;
      int y = j - num2;
      if (Main.tile[x, y].type != (byte) 55 && Main.tile[x, y].type != (byte) 85)
      {
        Sign.KillSign(x, y);
        return -1;
      }
      int num3 = -1;
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.sign[index] != null && Main.sign[index].x == x && Main.sign[index].y == y)
        {
          num3 = index;
          break;
        }
      }
      if (num3 < 0)
      {
        for (int index = 0; index < 1000; ++index)
        {
          if (Main.sign[index] == null)
          {
            num3 = index;
            Main.sign[index] = new Sign();
            Main.sign[index].x = x;
            Main.sign[index].y = y;
            Main.sign[index].text = "";
            break;
          }
        }
      }
      return num3;
    }

    public static void TextSign(int i, string text)
    {
      if (Main.tile[Main.sign[i].x, Main.sign[i].y] == null || !Main.tile[Main.sign[i].x, Main.sign[i].y].active || Main.tile[Main.sign[i].x, Main.sign[i].y].type != (byte) 55 && Main.tile[Main.sign[i].x, Main.sign[i].y].type != (byte) 85)
        Main.sign[i] = (Sign) null;
      else
        Main.sign[i].text = text;
    }
  }
}
