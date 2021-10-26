// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.CustomCurrencySingleCoin
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI
{
  public class CustomCurrencySingleCoin : CustomCurrencySystem
  {
    public float CurrencyDrawScale = 0.8f;
    public string CurrencyTextKey = "Currency.DefenderMedals";
    public Color CurrencyTextColor = new Color(240, 100, 120);

    public CustomCurrencySingleCoin(int coinItemID, long currencyCap)
    {
      this.Include(coinItemID, 1);
      this.SetCurrencyCap(currencyCap);
    }

    public override bool TryPurchasing(
      int price,
      List<Item[]> inv,
      List<Point> slotCoins,
      List<Point> slotsEmpty,
      List<Point> slotEmptyBank,
      List<Point> slotEmptyBank2,
      List<Point> slotEmptyBank3,
      List<Point> slotEmptyBank4)
    {
      List<Tuple<Point, Item>> cache = this.ItemCacheCreate(inv);
      int num1 = price;
      for (int index = 0; index < slotCoins.Count; ++index)
      {
        Point slotCoin = slotCoins[index];
        int num2 = num1;
        if (inv[slotCoin.X][slotCoin.Y].stack < num2)
          num2 = inv[slotCoin.X][slotCoin.Y].stack;
        num1 -= num2;
        inv[slotCoin.X][slotCoin.Y].stack -= num2;
        if (inv[slotCoin.X][slotCoin.Y].stack == 0)
        {
          switch (slotCoin.X)
          {
            case 0:
              slotsEmpty.Add(slotCoin);
              break;
            case 1:
              slotEmptyBank.Add(slotCoin);
              break;
            case 2:
              slotEmptyBank2.Add(slotCoin);
              break;
            case 3:
              slotEmptyBank3.Add(slotCoin);
              break;
            case 4:
              slotEmptyBank4.Add(slotCoin);
              break;
          }
          slotCoins.Remove(slotCoin);
          --index;
        }
        if (num1 == 0)
          break;
      }
      if (num1 == 0)
        return true;
      this.ItemCacheRestore(cache, inv);
      return false;
    }

    public override void DrawSavingsMoney(
      SpriteBatch sb,
      string text,
      float shopx,
      float shopy,
      long totalCoins,
      bool horizontal = false)
    {
      int i = this._valuePerUnit.Keys.ElementAt<int>(0);
      Main.instance.LoadItem(i);
      Texture2D texture2D = TextureAssets.Item[i].Value;
      if (horizontal)
      {
        Vector2 position = new Vector2((float) ((double) shopx + (double) ChatManager.GetStringSize(FontAssets.MouseText.Value, text, Vector2.One).X + 45.0), shopy + 50f);
        sb.Draw(texture2D, position, new Rectangle?(), Color.White, 0.0f, texture2D.Size() / 2f, this.CurrencyDrawScale, SpriteEffects.None, 0.0f);
        Utils.DrawBorderStringFourWay(sb, FontAssets.ItemStack.Value, totalCoins.ToString(), position.X - 11f, position.Y, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
      }
      else
      {
        int num = totalCoins > 99L ? -6 : 0;
        sb.Draw(texture2D, new Vector2(shopx + 11f, shopy + 75f), new Rectangle?(), Color.White, 0.0f, texture2D.Size() / 2f, this.CurrencyDrawScale, SpriteEffects.None, 0.0f);
        Utils.DrawBorderStringFourWay(sb, FontAssets.ItemStack.Value, totalCoins.ToString(), shopx + (float) num, shopy + 75f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
      }
    }

    public override void GetPriceText(string[] lines, ref int currentLine, int price)
    {
      Color color = this.CurrencyTextColor * ((float) Main.mouseTextColor / (float) byte.MaxValue);
      lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", (object) color.R, (object) color.G, (object) color.B, (object) Lang.tip[50].Value, (object) price, (object) Language.GetTextValue(this.CurrencyTextKey).ToLower());
    }
  }
}
