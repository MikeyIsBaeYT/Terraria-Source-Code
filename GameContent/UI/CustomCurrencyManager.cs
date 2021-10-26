// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.CustomCurrencyManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
  public class CustomCurrencyManager
  {
    private static int _nextCurrencyIndex;
    private static Dictionary<int, CustomCurrencySystem> _currencies = new Dictionary<int, CustomCurrencySystem>();

    public static void Initialize()
    {
      CustomCurrencyManager._nextCurrencyIndex = 0;
      CustomCurrencyID.DefenderMedals = CustomCurrencyManager.RegisterCurrency((CustomCurrencySystem) new CustomCurrencySingleCoin(3817, 999L));
    }

    public static int RegisterCurrency(CustomCurrencySystem collection)
    {
      int nextCurrencyIndex = CustomCurrencyManager._nextCurrencyIndex;
      ++CustomCurrencyManager._nextCurrencyIndex;
      CustomCurrencyManager._currencies[nextCurrencyIndex] = collection;
      return nextCurrencyIndex;
    }

    public static void DrawSavings(
      SpriteBatch sb,
      int currencyIndex,
      float shopx,
      float shopy,
      bool horizontal = false)
    {
      CustomCurrencySystem currency = CustomCurrencyManager._currencies[currencyIndex];
      Player player = Main.player[Main.myPlayer];
      bool overFlowing;
      long num1 = currency.CountCurrency(out overFlowing, player.bank.item);
      long num2 = currency.CountCurrency(out overFlowing, player.bank2.item);
      long num3 = currency.CountCurrency(out overFlowing, player.bank3.item);
      long num4 = currency.CountCurrency(out overFlowing, player.bank4.item);
      long totalCoins = currency.CombineStacks(out overFlowing, num1, num2, num3, num4);
      if (totalCoins <= 0L)
        return;
      Main.instance.LoadItem(4076);
      Main.instance.LoadItem(3813);
      Main.instance.LoadItem(346);
      Main.instance.LoadItem(87);
      if (num4 > 0L)
        sb.Draw(TextureAssets.Item[4076].Value, Utils.CenteredRectangle(new Vector2(shopx + 96f, shopy + 50f), TextureAssets.Item[4076].Value.Size() * 0.65f), new Rectangle?(), Color.White);
      if (num3 > 0L)
        sb.Draw(TextureAssets.Item[3813].Value, Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), TextureAssets.Item[3813].Value.Size() * 0.65f), new Rectangle?(), Color.White);
      if (num2 > 0L)
        sb.Draw(TextureAssets.Item[346].Value, Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), TextureAssets.Item[346].Value.Size() * 0.65f), new Rectangle?(), Color.White);
      if (num1 > 0L)
        sb.Draw(TextureAssets.Item[87].Value, Utils.CenteredRectangle(new Vector2(shopx + 70f, shopy + 60f), TextureAssets.Item[87].Value.Size() * 0.65f), new Rectangle?(), Color.White);
      Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, Lang.inter[66].Value, shopx, shopy + 40f, Color.White * ((float) Main.mouseTextColor / (float) byte.MaxValue), Color.Black, Vector2.Zero);
      currency.DrawSavingsMoney(sb, Lang.inter[66].Value, shopx, shopy, totalCoins, horizontal);
    }

    public static void GetPriceText(
      int currencyIndex,
      string[] lines,
      ref int currentLine,
      int price)
    {
      CustomCurrencyManager._currencies[currencyIndex].GetPriceText(lines, ref currentLine, price);
    }

    public static bool BuyItem(Player player, int price, int currencyIndex)
    {
      CustomCurrencySystem currency = CustomCurrencyManager._currencies[currencyIndex];
      bool overFlowing;
      long num1 = currency.CountCurrency(out overFlowing, player.inventory, 58, 57, 56, 55, 54);
      long num2 = currency.CountCurrency(out overFlowing, player.bank.item);
      long num3 = currency.CountCurrency(out overFlowing, player.bank2.item);
      long num4 = currency.CountCurrency(out overFlowing, player.bank3.item);
      long num5 = currency.CountCurrency(out overFlowing, player.bank4.item);
      if (currency.CombineStacks(out overFlowing, num1, num2, num3, num4, num5) < (long) price)
        return false;
      List<Item[]> objArrayList = new List<Item[]>();
      Dictionary<int, List<int>> slotsToIgnore = new Dictionary<int, List<int>>();
      List<Point> pointList1 = new List<Point>();
      List<Point> slotCoins = new List<Point>();
      List<Point> pointList2 = new List<Point>();
      List<Point> pointList3 = new List<Point>();
      List<Point> pointList4 = new List<Point>();
      List<Point> pointList5 = new List<Point>();
      objArrayList.Add(player.inventory);
      objArrayList.Add(player.bank.item);
      objArrayList.Add(player.bank2.item);
      objArrayList.Add(player.bank3.item);
      objArrayList.Add(player.bank4.item);
      for (int key = 0; key < objArrayList.Count; ++key)
        slotsToIgnore[key] = new List<int>();
      slotsToIgnore[0] = new List<int>()
      {
        58,
        57,
        56,
        55,
        54
      };
      for (int index = 0; index < objArrayList.Count; ++index)
      {
        for (int y = 0; y < objArrayList[index].Length; ++y)
        {
          if (!slotsToIgnore[index].Contains(y) && currency.Accepts(objArrayList[index][y]))
            slotCoins.Add(new Point(index, y));
        }
      }
      CustomCurrencyManager.FindEmptySlots(objArrayList, slotsToIgnore, pointList1, 0);
      CustomCurrencyManager.FindEmptySlots(objArrayList, slotsToIgnore, pointList2, 1);
      CustomCurrencyManager.FindEmptySlots(objArrayList, slotsToIgnore, pointList3, 2);
      CustomCurrencyManager.FindEmptySlots(objArrayList, slotsToIgnore, pointList4, 3);
      CustomCurrencyManager.FindEmptySlots(objArrayList, slotsToIgnore, pointList5, 4);
      return currency.TryPurchasing(price, objArrayList, slotCoins, pointList1, pointList2, pointList3, pointList4, pointList5);
    }

    private static void FindEmptySlots(
      List<Item[]> inventories,
      Dictionary<int, List<int>> slotsToIgnore,
      List<Point> emptySlots,
      int currentInventoryIndex)
    {
      for (int y = inventories[currentInventoryIndex].Length - 1; y >= 0; --y)
      {
        if (!slotsToIgnore[currentInventoryIndex].Contains(y) && (inventories[currentInventoryIndex][y].type == 0 || inventories[currentInventoryIndex][y].stack == 0))
          emptySlots.Add(new Point(currentInventoryIndex, y));
      }
    }

    public static bool IsCustomCurrency(Item item)
    {
      foreach (KeyValuePair<int, CustomCurrencySystem> currency in CustomCurrencyManager._currencies)
      {
        if (currency.Value.Accepts(item))
          return true;
      }
      return false;
    }

    public static void GetPrices(Item item, out int calcForSelling, out int calcForBuying) => CustomCurrencyManager._currencies[item.shopSpecialCurrency].GetItemExpectedPrice(item, out calcForSelling, out calcForBuying);
  }
}
