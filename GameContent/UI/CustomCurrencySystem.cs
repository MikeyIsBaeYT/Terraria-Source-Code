// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.CustomCurrencySystem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria.GameContent.UI
{
  public class CustomCurrencySystem
  {
    protected Dictionary<int, int> _valuePerUnit = new Dictionary<int, int>();
    private long _currencyCap = 999999999;

    public long CurrencyCap => this._currencyCap;

    public void Include(int coin, int howMuchIsItWorth) => this._valuePerUnit[coin] = howMuchIsItWorth;

    public void SetCurrencyCap(long cap) => this._currencyCap = cap;

    public virtual long CountCurrency(out bool overFlowing, Item[] inv, params int[] ignoreSlots)
    {
      List<int> intList = new List<int>((IEnumerable<int>) ignoreSlots);
      long num1 = 0;
      for (int index = 0; index < inv.Length; ++index)
      {
        if (!intList.Contains(index))
        {
          int num2;
          if (this._valuePerUnit.TryGetValue(inv[index].type, out num2))
            num1 += (long) (num2 * inv[index].stack);
          if (num1 >= this.CurrencyCap)
          {
            overFlowing = true;
            return this.CurrencyCap;
          }
        }
      }
      overFlowing = false;
      return num1;
    }

    public virtual long CombineStacks(out bool overFlowing, params long[] coinCounts)
    {
      long num = 0;
      foreach (long coinCount in coinCounts)
      {
        num += coinCount;
        if (num >= this.CurrencyCap)
        {
          overFlowing = true;
          return this.CurrencyCap;
        }
      }
      overFlowing = false;
      return num;
    }

    public virtual bool TryPurchasing(
      int price,
      List<Item[]> inv,
      List<Point> slotCoins,
      List<Point> slotsEmpty,
      List<Point> slotEmptyBank,
      List<Point> slotEmptyBank2,
      List<Point> slotEmptyBank3,
      List<Point> slotEmptyBank4)
    {
      long num1 = (long) price;
      Dictionary<Point, Item> dictionary = new Dictionary<Point, Item>();
      bool flag = true;
      while (num1 > 0L)
      {
        long num2 = 1000000;
        for (int index = 0; index < 4; ++index)
        {
          if (num1 >= num2)
          {
            foreach (Point slotCoin in slotCoins)
            {
              if (inv[slotCoin.X][slotCoin.Y].type == 74 - index)
              {
                long num3 = num1 / num2;
                dictionary[slotCoin] = inv[slotCoin.X][slotCoin.Y].Clone();
                if (num3 < (long) inv[slotCoin.X][slotCoin.Y].stack)
                {
                  inv[slotCoin.X][slotCoin.Y].stack -= (int) num3;
                }
                else
                {
                  inv[slotCoin.X][slotCoin.Y].SetDefaults();
                  slotsEmpty.Add(slotCoin);
                }
                num1 -= num2 * (long) (dictionary[slotCoin].stack - inv[slotCoin.X][slotCoin.Y].stack);
              }
            }
          }
          num2 /= 100L;
        }
        if (num1 > 0L)
        {
          if (slotsEmpty.Count > 0)
          {
            slotsEmpty.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
            Point point = new Point(-1, -1);
            for (int index1 = 0; index1 < inv.Count; ++index1)
            {
              long num4 = 10000;
              for (int index2 = 0; index2 < 3; ++index2)
              {
                if (num1 >= num4)
                {
                  foreach (Point slotCoin in slotCoins)
                  {
                    if (slotCoin.X == index1 && inv[slotCoin.X][slotCoin.Y].type == 74 - index2 && inv[slotCoin.X][slotCoin.Y].stack >= 1)
                    {
                      List<Point> pointList = slotsEmpty;
                      if (index1 == 1 && slotEmptyBank.Count > 0)
                        pointList = slotEmptyBank;
                      if (index1 == 2 && slotEmptyBank2.Count > 0)
                        pointList = slotEmptyBank2;
                      if (index1 == 3 && slotEmptyBank3.Count > 0)
                        pointList = slotEmptyBank3;
                      if (index1 == 4 && slotEmptyBank4.Count > 0)
                        pointList = slotEmptyBank4;
                      if (--inv[slotCoin.X][slotCoin.Y].stack <= 0)
                      {
                        inv[slotCoin.X][slotCoin.Y].SetDefaults();
                        pointList.Add(slotCoin);
                      }
                      dictionary[pointList[0]] = inv[pointList[0].X][pointList[0].Y].Clone();
                      inv[pointList[0].X][pointList[0].Y].SetDefaults(73 - index2);
                      inv[pointList[0].X][pointList[0].Y].stack = 100;
                      point = pointList[0];
                      pointList.RemoveAt(0);
                      break;
                    }
                  }
                }
                if (point.X == -1 && point.Y == -1)
                  num4 /= 100L;
                else
                  break;
              }
              for (int index3 = 0; index3 < 2; ++index3)
              {
                if (point.X == -1 && point.Y == -1)
                {
                  foreach (Point slotCoin in slotCoins)
                  {
                    if (slotCoin.X == index1 && inv[slotCoin.X][slotCoin.Y].type == 73 + index3 && inv[slotCoin.X][slotCoin.Y].stack >= 1)
                    {
                      List<Point> pointList = slotsEmpty;
                      if (index1 == 1 && slotEmptyBank.Count > 0)
                        pointList = slotEmptyBank;
                      if (index1 == 2 && slotEmptyBank2.Count > 0)
                        pointList = slotEmptyBank2;
                      if (index1 == 3 && slotEmptyBank3.Count > 0)
                        pointList = slotEmptyBank3;
                      if (index1 == 4 && slotEmptyBank4.Count > 0)
                        pointList = slotEmptyBank4;
                      if (--inv[slotCoin.X][slotCoin.Y].stack <= 0)
                      {
                        inv[slotCoin.X][slotCoin.Y].SetDefaults();
                        pointList.Add(slotCoin);
                      }
                      dictionary[pointList[0]] = inv[pointList[0].X][pointList[0].Y].Clone();
                      inv[pointList[0].X][pointList[0].Y].SetDefaults(72 + index3);
                      inv[pointList[0].X][pointList[0].Y].stack = 100;
                      point = pointList[0];
                      pointList.RemoveAt(0);
                      break;
                    }
                  }
                }
              }
              if (point.X != -1 && point.Y != -1)
              {
                slotCoins.Add(point);
                break;
              }
            }
            slotsEmpty.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
            slotEmptyBank.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
            slotEmptyBank2.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
            slotEmptyBank3.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
            slotEmptyBank4.Sort(new Comparison<Point>(DelegateMethods.CompareYReverse));
          }
          else
          {
            foreach (KeyValuePair<Point, Item> keyValuePair in dictionary)
              inv[keyValuePair.Key.X][keyValuePair.Key.Y] = keyValuePair.Value.Clone();
            flag = false;
            break;
          }
        }
      }
      return flag;
    }

    public virtual bool Accepts(Item item) => this._valuePerUnit.ContainsKey(item.type);

    public virtual void DrawSavingsMoney(
      SpriteBatch sb,
      string text,
      float shopx,
      float shopy,
      long totalCoins,
      bool horizontal = false)
    {
    }

    public virtual void GetPriceText(string[] lines, ref int currentLine, int price)
    {
    }

    protected int SortByHighest(Tuple<int, int> valueA, Tuple<int, int> valueB) => valueA.Item2 > valueB.Item2 || valueA.Item2 != valueB.Item2 ? -1 : 0;

    protected List<Tuple<Point, Item>> ItemCacheCreate(List<Item[]> inventories)
    {
      List<Tuple<Point, Item>> tupleList = new List<Tuple<Point, Item>>();
      for (int index = 0; index < inventories.Count; ++index)
      {
        for (int y = 0; y < inventories[index].Length; ++y)
        {
          Item obj = inventories[index][y];
          tupleList.Add(new Tuple<Point, Item>(new Point(index, y), obj.DeepClone()));
        }
      }
      return tupleList;
    }

    protected void ItemCacheRestore(List<Tuple<Point, Item>> cache, List<Item[]> inventories)
    {
      foreach (Tuple<Point, Item> tuple in cache)
        inventories[tuple.Item1.X][tuple.Item1.Y] = tuple.Item2;
    }

    public virtual void GetItemExpectedPrice(
      Item item,
      out int calcForSelling,
      out int calcForBuying)
    {
      int storeValue = item.GetStoreValue();
      calcForSelling = storeValue;
      calcForBuying = storeValue;
    }
  }
}
