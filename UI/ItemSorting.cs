// Decompiled with JetBrains decompiler
// Type: Terraria.UI.ItemSorting
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;

namespace Terraria.UI
{
  public class ItemSorting
  {
    private static List<ItemSorting.ItemSortingLayer> _layerList = new List<ItemSorting.ItemSortingLayer>();
    private static Dictionary<string, List<int>> _layerWhiteLists = new Dictionary<string, List<int>>();

    public static void SetupWhiteLists()
    {
      ItemSorting._layerWhiteLists.Clear();
      List<ItemSorting.ItemSortingLayer> itemSortingLayerList = new List<ItemSorting.ItemSortingLayer>();
      List<Item> objList = new List<Item>();
      List<int> intList1 = new List<int>();
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsMelee);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsRanged);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsMagic);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsMinions);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsAssorted);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsAmmo);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsPicksaws);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsHamaxes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsPickaxes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsAxes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsHammers);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsTerraforming);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsAmmoLeftovers);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ArmorCombat);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ArmorVanity);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ArmorAccessories);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipGrapple);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipMount);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipCart);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipLightPet);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipVanityPet);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsDyes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsHairDyes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsLife);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsMana);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsElixirs);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsBuffs);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscValuables);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscPainting);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscWiring);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscMaterials);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscRopes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscExtractinator);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastMaterials);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastTilesImportant);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastTilesCommon);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastNotTrash);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastTrash);
      for (int type = -48; type < 5045; ++type)
      {
        Item obj = new Item();
        obj.netDefaults(type);
        objList.Add(obj);
        intList1.Add(type + 48);
      }
      Item[] array = objList.ToArray();
      foreach (ItemSorting.ItemSortingLayer itemSortingLayer in itemSortingLayerList)
      {
        List<int> intList2 = itemSortingLayer.SortingMethod(itemSortingLayer, array, intList1);
        List<int> intList3 = new List<int>();
        for (int index = 0; index < intList2.Count; ++index)
          intList3.Add(array[intList2[index]].netID);
        ItemSorting._layerWhiteLists.Add(itemSortingLayer.Name, intList3);
      }
    }

    private static void SetupSortingPriorities()
    {
      Player player = Main.player[Main.myPlayer];
      ItemSorting._layerList.Clear();
      List<float> floatList = new List<float>()
      {
        player.meleeDamage,
        player.rangedDamage,
        player.magicDamage,
        player.minionDamage
      };
      floatList.Sort((Comparison<float>) ((x, y) => y.CompareTo(x)));
      for (int index = 0; index < 5; ++index)
      {
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsMelee) && (double) player.meleeDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsMelee);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsRanged) && (double) player.rangedDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsRanged);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsMagic) && (double) player.magicDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsMagic);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsMinions) && (double) player.minionDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsMinions);
        }
      }
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsAssorted);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsAmmo);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsPicksaws);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsHamaxes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsPickaxes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsAxes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsHammers);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsTerraforming);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsAmmoLeftovers);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ArmorCombat);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ArmorVanity);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ArmorAccessories);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipGrapple);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipMount);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipCart);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipLightPet);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipVanityPet);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsDyes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsHairDyes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsLife);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsMana);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsElixirs);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsBuffs);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscValuables);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscPainting);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscWiring);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscMaterials);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscRopes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscExtractinator);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastMaterials);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastTilesImportant);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastTilesCommon);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastNotTrash);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastTrash);
    }

    private static void Sort(Item[] inv, params int[] ignoreSlots)
    {
      ItemSorting.SetupSortingPriorities();
      List<int> intList1 = new List<int>();
      for (int index = 0; index < inv.Length; ++index)
      {
        if (!((IEnumerable<int>) ignoreSlots).Contains<int>(index))
        {
          Item obj = inv[index];
          if (obj != null && obj.stack != 0 && obj.type != 0 && !obj.favorited)
            intList1.Add(index);
        }
      }
      for (int index1 = 0; index1 < intList1.Count; ++index1)
      {
        Item obj1 = inv[intList1[index1]];
        if (obj1.stack < obj1.maxStack)
        {
          int num1 = obj1.maxStack - obj1.stack;
          for (int index2 = index1; index2 < intList1.Count; ++index2)
          {
            if (index1 != index2)
            {
              Item obj2 = inv[intList1[index2]];
              if (obj1.type == obj2.type && obj2.stack != obj2.maxStack)
              {
                int num2 = obj2.stack;
                if (num1 < num2)
                  num2 = num1;
                obj1.stack += num2;
                obj2.stack -= num2;
                num1 -= num2;
                if (obj2.stack == 0)
                {
                  inv[intList1[index2]] = new Item();
                  intList1.Remove(intList1[index2]);
                  --index1;
                  int num3 = index2 - 1;
                  break;
                }
                if (num1 == 0)
                  break;
              }
            }
          }
        }
      }
      List<int> intList2 = new List<int>((IEnumerable<int>) intList1);
      for (int index = 0; index < inv.Length; ++index)
      {
        if (!((IEnumerable<int>) ignoreSlots).Contains<int>(index) && !intList2.Contains(index))
        {
          Item obj = inv[index];
          if (obj == null || obj.stack == 0 || obj.type == 0)
            intList2.Add(index);
        }
      }
      intList2.Sort();
      List<int> intList3 = new List<int>();
      List<int> intList4 = new List<int>();
      foreach (ItemSorting.ItemSortingLayer layer in ItemSorting._layerList)
      {
        List<int> intList5 = layer.SortingMethod(layer, inv, intList1);
        if (intList5.Count > 0)
          intList4.Add(intList5.Count);
        intList3.AddRange((IEnumerable<int>) intList5);
      }
      intList3.AddRange((IEnumerable<int>) intList1);
      List<Item> objList = new List<Item>();
      foreach (int index in intList3)
      {
        objList.Add(inv[index]);
        inv[index] = new Item();
      }
      float num = 1f / (float) intList4.Count;
      float hue = num / 2f;
      for (int index3 = 0; index3 < objList.Count; ++index3)
      {
        int index4 = intList2[0];
        ItemSlot.SetGlow(index4, hue, Main.player[Main.myPlayer].chest != -1);
        --intList4[0];
        if (intList4[0] == 0)
        {
          intList4.RemoveAt(0);
          hue += num;
        }
        inv[index4] = objList[index3];
        intList2.Remove(index4);
      }
    }

    public static void SortInventory()
    {
      if (!Main.LocalPlayer.HasItem(905))
        ItemSorting.SortCoins();
      ItemSorting.SortAmmo();
      ItemSorting.Sort(Main.player[Main.myPlayer].inventory, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 50, 51, 52, 53, 54, 55, 56, 57, 58);
    }

    public static void SortChest()
    {
      int chest = Main.player[Main.myPlayer].chest;
      if (chest == -1)
        return;
      Item[] inv = Main.player[Main.myPlayer].bank.item;
      if (chest == -3)
        inv = Main.player[Main.myPlayer].bank2.item;
      if (chest == -4)
        inv = Main.player[Main.myPlayer].bank3.item;
      if (chest == -5)
        inv = Main.player[Main.myPlayer].bank4.item;
      if (chest > -1)
        inv = Main.chest[chest].item;
      Tuple<int, int, int>[] tupleArray1 = new Tuple<int, int, int>[40];
      for (int index = 0; index < 40; ++index)
        tupleArray1[index] = Tuple.Create<int, int, int>(inv[index].netID, inv[index].stack, (int) inv[index].prefix);
      ItemSorting.Sort(inv);
      Tuple<int, int, int>[] tupleArray2 = new Tuple<int, int, int>[40];
      for (int index = 0; index < 40; ++index)
        tupleArray2[index] = Tuple.Create<int, int, int>(inv[index].netID, inv[index].stack, (int) inv[index].prefix);
      if (Main.netMode != 1 || Main.player[Main.myPlayer].chest <= -1)
        return;
      for (int index = 0; index < 40; ++index)
      {
        if (tupleArray2[index] != tupleArray1[index])
          NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index));
      }
    }

    public static void SortAmmo()
    {
      ItemSorting.ClearAmmoSlotSpaces();
      ItemSorting.FillAmmoFromInventory();
    }

    public static void FillAmmoFromInventory()
    {
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      Item[] inventory = Main.player[Main.myPlayer].inventory;
      for (int index = 54; index < 58; ++index)
      {
        ItemSlot.SetGlow(index, 0.31f, false);
        Item obj = inventory[index];
        if (obj.IsAir)
          intList2.Add(index);
        else if (obj.ammo != AmmoID.None)
        {
          if (!intList1.Contains(obj.type))
            intList1.Add(obj.type);
          ItemSorting.RefillItemStack(inventory, inventory[index], 0, 50);
        }
      }
      if (intList2.Count < 1)
        return;
      for (int index1 = 0; index1 < 50; ++index1)
      {
        Item obj = inventory[index1];
        if (obj.stack >= 1 && obj.CanFillEmptyAmmoSlot() && intList1.Contains(obj.type))
        {
          int index2 = intList2[0];
          intList2.Remove(index2);
          Utils.Swap<Item>(ref inventory[index1], ref inventory[index2]);
          ItemSorting.RefillItemStack(inventory, inventory[index2], 0, 50);
          if (intList2.Count == 0)
            break;
        }
      }
      if (intList2.Count < 1)
        return;
      for (int index3 = 0; index3 < 50; ++index3)
      {
        Item obj = inventory[index3];
        if (obj.stack >= 1 && obj.CanFillEmptyAmmoSlot() && obj.FitsAmmoSlot())
        {
          int index4 = intList2[0];
          intList2.Remove(index4);
          Utils.Swap<Item>(ref inventory[index3], ref inventory[index4]);
          ItemSorting.RefillItemStack(inventory, inventory[index4], 0, 50);
          if (intList2.Count == 0)
            break;
        }
      }
    }

    public static void ClearAmmoSlotSpaces()
    {
      Item[] inventory = Main.player[Main.myPlayer].inventory;
      for (int index = 54; index < 58; ++index)
      {
        Item itemToRefill = inventory[index];
        if (!itemToRefill.IsAir && itemToRefill.ammo != AmmoID.None && itemToRefill.stack < itemToRefill.maxStack)
          ItemSorting.RefillItemStack(inventory, itemToRefill, index + 1, 58);
      }
      for (int slot = 54; slot < 58; ++slot)
      {
        if (inventory[slot].type > 0)
          ItemSorting.TrySlidingUp(inventory, slot, 54);
      }
    }

    private static void SortCoins()
    {
      Item[] inventory = Main.LocalPlayer.inventory;
      bool overFlowing;
      long count = Utils.CoinsCount(out overFlowing, inventory, 58);
      if (overFlowing)
        return;
      int[] numArray = Utils.CoinsSplit(count);
      int num1 = 0;
      for (int index = 0; index < 3; ++index)
      {
        int num2 = numArray[index];
        while (num2 > 0)
        {
          num2 -= 99;
          ++num1;
        }
      }
      int num3 = numArray[3];
      while (num3 > 999)
      {
        num3 -= 999;
        ++num1;
      }
      int num4 = 0;
      for (int index = 0; index < 58; ++index)
      {
        if (inventory[index].type >= 71 && inventory[index].type <= 74 && inventory[index].stack > 0)
          ++num4;
      }
      if (num4 < num1)
        return;
      for (int index = 0; index < 58; ++index)
      {
        if (inventory[index].type >= 71 && inventory[index].type <= 74 && inventory[index].stack > 0)
          inventory[index].TurnToAir();
      }
label_23:
      int index1;
      int num5;
      bool flag;
      do
      {
        index1 = -1;
        for (int index2 = 3; index2 >= 0; --index2)
        {
          if (numArray[index2] > 0)
          {
            index1 = index2;
            break;
          }
        }
        if (index1 != -1)
        {
          num5 = numArray[index1];
          if (index1 == 3 && num5 > 999)
            num5 = 999;
          flag = false;
          if (!flag)
          {
            for (int index3 = 50; index3 < 54; ++index3)
            {
              if (inventory[index3].IsAir)
              {
                inventory[index3].SetDefaults(71 + index1);
                inventory[index3].stack = num5;
                numArray[index1] -= num5;
                flag = true;
                break;
              }
            }
          }
        }
        else
          goto label_17;
      }
      while (flag);
      goto label_38;
label_17:
      return;
label_38:
      for (int index4 = 0; index4 < 50; ++index4)
      {
        if (inventory[index4].IsAir)
        {
          inventory[index4].SetDefaults(71 + index1);
          inventory[index4].stack = num5;
          numArray[index1] -= num5;
          break;
        }
      }
      goto label_23;
    }

    private static void RefillItemStack(
      Item[] inv,
      Item itemToRefill,
      int loopStartIndex,
      int loopEndIndex)
    {
      int num1 = itemToRefill.maxStack - itemToRefill.stack;
      if (num1 <= 0)
        return;
      for (int index = loopStartIndex; index < loopEndIndex; ++index)
      {
        Item obj = inv[index];
        if (obj.stack >= 1 && obj.type == itemToRefill.type)
        {
          int num2 = obj.stack;
          if (num2 > num1)
            num2 = num1;
          num1 -= num2;
          itemToRefill.stack += num2;
          obj.stack -= num2;
          if (obj.stack <= 0)
            obj.TurnToAir();
          if (num1 <= 0)
            break;
        }
      }
    }

    private static void TrySlidingUp(Item[] inv, int slot, int minimumIndex)
    {
      for (int index = slot; index > minimumIndex; --index)
      {
        if (inv[index - 1].IsAir)
          Utils.Swap<Item>(ref inv[index], ref inv[index - 1]);
      }
    }

    private class ItemSortingLayer
    {
      public readonly string Name;
      public readonly Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> SortingMethod;

      public ItemSortingLayer(
        string name,
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> method)
      {
        this.Name = name;
        this.SortingMethod = method;
      }

      public void Validate(ref List<int> indexesSortable, Item[] inv)
      {
        List<int> list;
        if (!ItemSorting._layerWhiteLists.TryGetValue(this.Name, out list))
          return;
        indexesSortable = indexesSortable.Where<int>((Func<int, bool>) (i => list.Contains(inv[i].netID))).ToList<int>();
      }

      public override string ToString() => this.Name;
    }

    private class ItemSortingLayers
    {
      public static ItemSorting.ItemSortingLayer WeaponsMelee = new ItemSorting.ItemSortingLayer("Weapons - Melee", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].maxStack == 1 && inv[i].damage > 0 && inv[i].ammo == 0 && inv[i].melee && inv[i].pick < 1 && inv[i].hammer < 1 && inv[i].axe < 1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer WeaponsRanged = new ItemSorting.ItemSortingLayer("Weapons - Ranged", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].maxStack == 1 && inv[i].damage > 0 && inv[i].ammo == 0 && inv[i].ranged)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer WeaponsMagic = new ItemSorting.ItemSortingLayer("Weapons - Magic", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].maxStack == 1 && inv[i].damage > 0 && inv[i].ammo == 0 && inv[i].magic)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer WeaponsMinions = new ItemSorting.ItemSortingLayer("Weapons - Minions", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].maxStack == 1 && inv[i].damage > 0 && inv[i].summon)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer WeaponsAssorted = new ItemSorting.ItemSortingLayer("Weapons - Assorted", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].damage > 0 && inv[i].ammo == 0 && inv[i].pick == 0 && inv[i].axe == 0 && inv[i].hammer == 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer WeaponsAmmo = new ItemSorting.ItemSortingLayer("Weapons - Ammo", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].ammo > 0 && inv[i].damage > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsPicksaws = new ItemSorting.ItemSortingLayer("Tools - Picksaws", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].pick > 0 && inv[i].axe > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) => inv[x].pick.CompareTo(inv[y].pick)));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsHamaxes = new ItemSorting.ItemSortingLayer("Tools - Hamaxes", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].hammer > 0 && inv[i].axe > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) => inv[x].axe.CompareTo(inv[y].axe)));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsPickaxes = new ItemSorting.ItemSortingLayer("Tools - Pickaxes", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].pick > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) => inv[x].pick.CompareTo(inv[y].pick)));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsAxes = new ItemSorting.ItemSortingLayer("Tools - Axes", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].pick > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) => inv[x].axe.CompareTo(inv[y].axe)));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsHammers = new ItemSorting.ItemSortingLayer("Tools - Hammers", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].hammer > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) => inv[x].hammer.CompareTo(inv[y].hammer)));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsTerraforming = new ItemSorting.ItemSortingLayer("Tools - Terraforming", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityTerraforming[inv[i].netID] > -1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityTerraforming[inv[x].netID].CompareTo(ItemID.Sets.SortingPriorityTerraforming[inv[y].netID]);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ToolsAmmoLeftovers = new ItemSorting.ItemSortingLayer("Weapons - Ammo Leftovers", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].ammo > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDamage.CompareTo(inv[x].OriginalDamage);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ArmorCombat = new ItemSorting.ItemSortingLayer("Armor - Combat", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => (inv[i].bodySlot >= 0 || inv[i].headSlot >= 0 || inv[i].legSlot >= 0) && !inv[i].vanity)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDefense.CompareTo(inv[x].OriginalDefense);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ArmorVanity = new ItemSorting.ItemSortingLayer("Armor - Vanity", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => (inv[i].bodySlot >= 0 || inv[i].headSlot >= 0 || inv[i].legSlot >= 0) && inv[i].vanity)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer ArmorAccessories = new ItemSorting.ItemSortingLayer("Armor - Accessories", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].accessory)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[x].vanity.CompareTo(inv[y].vanity);
          if (num == 0)
            num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].OriginalDefense.CompareTo(inv[x].OriginalDefense);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer EquipGrapple = new ItemSorting.ItemSortingLayer("Equip - Grapple", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => Main.projHook[inv[i].shoot])).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer EquipMount = new ItemSorting.ItemSortingLayer("Equip - Mount", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].mountType != -1 && !MountID.Sets.Cart[inv[i].mountType])).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer EquipCart = new ItemSorting.ItemSortingLayer("Equip - Cart", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].mountType != -1 && MountID.Sets.Cart[inv[i].mountType])).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer EquipLightPet = new ItemSorting.ItemSortingLayer("Equip - Light Pet", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].buffType > 0 && Main.lightPet[inv[i].buffType])).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer EquipVanityPet = new ItemSorting.ItemSortingLayer("Equip - Vanity Pet", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].buffType > 0 && Main.vanityPet[inv[i].buffType])).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer PotionsLife = new ItemSorting.ItemSortingLayer("Potions - Life", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].consumable && inv[i].healLife > 0 && inv[i].healMana < 1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].healLife.CompareTo(inv[x].healLife);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer PotionsMana = new ItemSorting.ItemSortingLayer("Potions - Mana", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].consumable && inv[i].healLife < 1 && inv[i].healMana > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].healMana.CompareTo(inv[x].healMana);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer PotionsElixirs = new ItemSorting.ItemSortingLayer("Potions - Elixirs", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].consumable && inv[i].healLife > 0 && inv[i].healMana > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].healLife.CompareTo(inv[x].healLife);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer PotionsBuffs = new ItemSorting.ItemSortingLayer("Potions - Buffs", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].consumable && inv[i].buffType > 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[x].netID.CompareTo(inv[y].netID);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer PotionsDyes = new ItemSorting.ItemSortingLayer("Potions - Dyes", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].dye > (byte) 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].dye.CompareTo(inv[x].dye);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer PotionsHairDyes = new ItemSorting.ItemSortingLayer("Potions - Hair Dyes", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].hairDye >= (short) 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].hairDye.CompareTo(inv[x].hairDye);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer MiscValuables = new ItemSorting.ItemSortingLayer("Misc - Importants", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityBossSpawns[inv[i].netID] > -1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityBossSpawns[inv[x].netID].CompareTo(ItemID.Sets.SortingPriorityBossSpawns[inv[y].netID]);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer MiscWiring = new ItemSorting.ItemSortingLayer("Misc - Wiring", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityWiring[inv[i].netID] > -1 || inv[i].mech)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityWiring[inv[y].netID].CompareTo(ItemID.Sets.SortingPriorityWiring[inv[x].netID]);
          if (num == 0)
            num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].netID.CompareTo(inv[x].netID);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer MiscMaterials = new ItemSorting.ItemSortingLayer("Misc - Materials", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityMaterials[inv[i].netID] > -1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityMaterials[inv[y].netID].CompareTo(ItemID.Sets.SortingPriorityMaterials[inv[x].netID]);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer MiscExtractinator = new ItemSorting.ItemSortingLayer("Misc - Extractinator", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityExtractibles[inv[i].netID] > -1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityExtractibles[inv[y].netID].CompareTo(ItemID.Sets.SortingPriorityExtractibles[inv[x].netID]);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer MiscPainting = new ItemSorting.ItemSortingLayer("Misc - Painting", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityPainting[inv[i].netID] > -1 || inv[i].paint > (byte) 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityPainting[inv[y].netID].CompareTo(ItemID.Sets.SortingPriorityPainting[inv[x].netID]);
          if (num == 0)
            num = inv[x].paint.CompareTo(inv[y].paint);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer MiscRopes = new ItemSorting.ItemSortingLayer("Misc - Ropes", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].netID > 0 && ItemID.Sets.SortingPriorityRopes[inv[i].netID] > -1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = ItemID.Sets.SortingPriorityRopes[inv[y].netID].CompareTo(ItemID.Sets.SortingPriorityRopes[inv[x].netID]);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer LastMaterials = new ItemSorting.ItemSortingLayer("Last - Materials", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].createTile < 0 && inv[i].createWall < 1)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = inv[y].value.CompareTo(inv[x].value);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer LastTilesImportant = new ItemSorting.ItemSortingLayer("Last - Tiles (Frame Important)", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].createTile >= 0 && Main.tileFrameImportant[inv[i].createTile])).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = string.Compare(inv[x].Name, inv[y].Name, StringComparison.OrdinalIgnoreCase);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer LastTilesCommon = new ItemSorting.ItemSortingLayer("Last - Tiles (Common), Walls", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].createWall > 0 || inv[i].createTile >= 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = string.Compare(inv[x].Name, inv[y].Name, StringComparison.OrdinalIgnoreCase);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer LastNotTrash = new ItemSorting.ItemSortingLayer("Last - Not Trash", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> list = itemsToSort.Where<int>((Func<int, bool>) (i => inv[i].OriginalRarity >= 0)).ToList<int>();
        layer.Validate(ref list, inv);
        foreach (int num in list)
          itemsToSort.Remove(num);
        list.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].OriginalRarity.CompareTo(inv[x].OriginalRarity);
          if (num == 0)
            num = string.Compare(inv[x].Name, inv[y].Name, StringComparison.OrdinalIgnoreCase);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return list;
      }));
      public static ItemSorting.ItemSortingLayer LastTrash = new ItemSorting.ItemSortingLayer("Last - Trash", (Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>) ((layer, inv, itemsToSort) =>
      {
        List<int> indexesSortable = new List<int>((IEnumerable<int>) itemsToSort);
        layer.Validate(ref indexesSortable, inv);
        foreach (int num in indexesSortable)
          itemsToSort.Remove(num);
        indexesSortable.Sort((Comparison<int>) ((x, y) =>
        {
          int num = inv[y].value.CompareTo(inv[x].value);
          if (num == 0)
            num = inv[y].stack.CompareTo(inv[x].stack);
          if (num == 0)
            num = x.CompareTo(y);
          return num;
        }));
        return indexesSortable;
      }));
    }
  }
}
