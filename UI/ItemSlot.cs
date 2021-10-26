// Decompiled with JetBrains decompiler
// Type: Terraria.UI.ItemSlot
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Chat;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;

namespace Terraria.UI
{
  public class ItemSlot
  {
    public static bool DrawGoldBGForCraftingMaterial = false;
    public static bool ShiftForcedOn;
    private static Item[] singleSlotArray = new Item[1];
    private static bool[] canFavoriteAt = new bool[31];
    private static bool[] canShareAt = new bool[31];
    private static float[] inventoryGlowHue = new float[58];
    private static int[] inventoryGlowTime = new int[58];
    private static float[] inventoryGlowHueChest = new float[58];
    private static int[] inventoryGlowTimeChest = new int[58];
    private static int _customCurrencyForSavings = -1;
    private static int dyeSlotCount;
    private static int accSlotToSwapTo;
    public static float CircularRadialOpacity;
    public static float QuicksRadialOpacity;

    static ItemSlot()
    {
      ItemSlot.canFavoriteAt[0] = true;
      ItemSlot.canFavoriteAt[1] = true;
      ItemSlot.canFavoriteAt[2] = true;
      ItemSlot.canShareAt[15] = true;
      ItemSlot.canShareAt[4] = true;
      ItemSlot.canShareAt[5] = true;
      ItemSlot.canShareAt[6] = true;
      ItemSlot.canShareAt[7] = true;
      ItemSlot.canShareAt[27] = true;
      ItemSlot.canShareAt[26] = true;
      ItemSlot.canShareAt[23] = true;
      ItemSlot.canShareAt[24] = true;
      ItemSlot.canShareAt[25] = true;
      ItemSlot.canShareAt[22] = true;
      ItemSlot.canShareAt[3] = true;
      ItemSlot.canShareAt[8] = true;
      ItemSlot.canShareAt[9] = true;
      ItemSlot.canShareAt[10] = true;
      ItemSlot.canShareAt[11] = true;
      ItemSlot.canShareAt[12] = true;
      ItemSlot.canShareAt[16] = true;
      ItemSlot.canShareAt[20] = true;
      ItemSlot.canShareAt[18] = true;
      ItemSlot.canShareAt[19] = true;
      ItemSlot.canShareAt[17] = true;
      ItemSlot.canShareAt[29] = true;
      ItemSlot.canShareAt[30] = true;
    }

    public static bool ShiftInUse => Main.keyState.PressingShift() || ItemSlot.ShiftForcedOn;

    public static bool ControlInUse => Main.keyState.PressingControl();

    public static bool NotUsingGamepad => !PlayerInput.UsingGamepad;

    public static void SetGlow(int index, float hue, bool chest)
    {
      if (chest)
      {
        if ((double) hue < 0.0)
        {
          ItemSlot.inventoryGlowTimeChest[index] = 0;
          ItemSlot.inventoryGlowHueChest[index] = 0.0f;
        }
        else
        {
          ItemSlot.inventoryGlowTimeChest[index] = 300;
          ItemSlot.inventoryGlowHueChest[index] = hue;
        }
      }
      else
      {
        ItemSlot.inventoryGlowTime[index] = 300;
        ItemSlot.inventoryGlowHue[index] = hue;
      }
    }

    public static void UpdateInterface()
    {
      if (!Main.playerInventory || Main.player[Main.myPlayer].talkNPC == -1)
        ItemSlot._customCurrencyForSavings = -1;
      for (int index = 0; index < ItemSlot.inventoryGlowTime.Length; ++index)
      {
        if (ItemSlot.inventoryGlowTime[index] > 0)
        {
          --ItemSlot.inventoryGlowTime[index];
          if (ItemSlot.inventoryGlowTime[index] == 0)
            ItemSlot.inventoryGlowHue[index] = 0.0f;
        }
      }
      for (int index = 0; index < ItemSlot.inventoryGlowTimeChest.Length; ++index)
      {
        if (ItemSlot.inventoryGlowTimeChest[index] > 0)
        {
          --ItemSlot.inventoryGlowTimeChest[index];
          if (ItemSlot.inventoryGlowTimeChest[index] == 0)
            ItemSlot.inventoryGlowHueChest[index] = 0.0f;
        }
      }
    }

    public static void Handle(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.Handle(ItemSlot.singleSlotArray, context);
      inv = ItemSlot.singleSlotArray[0];
      Recipe.FindRecipes();
    }

    public static void Handle(Item[] inv, int context = 0, int slot = 0)
    {
      ItemSlot.OverrideHover(inv, context, slot);
      ItemSlot.LeftClick(inv, context, slot);
      ItemSlot.RightClick(inv, context, slot);
      if (Main.mouseLeftRelease && Main.mouseLeft)
        Recipe.FindRecipes();
      ItemSlot.MouseHover(inv, context, slot);
    }

    public static void OverrideHover(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.OverrideHover(ItemSlot.singleSlotArray, context);
      inv = ItemSlot.singleSlotArray[0];
    }

    public static bool isEquipLocked(int type) => Main.npcShop > 0 && (type == 854 || type == 3035);

    public static void OverrideHover(Item[] inv, int context = 0, int slot = 0)
    {
      Item obj = inv[slot];
      if (ItemSlot.NotUsingGamepad && ItemSlot.Options.DisableLeftShiftTrashCan)
      {
        if (ItemSlot.ControlInUse)
        {
          if (obj.type > 0 && obj.stack > 0 && !inv[slot].favorited)
          {
            switch (context)
            {
              case 0:
              case 1:
              case 2:
                Main.cursorOverride = Main.npcShop <= 0 || obj.favorited ? 6 : 10;
                break;
              case 3:
              case 4:
              case 7:
                if (Main.player[Main.myPlayer].ItemSpace(obj).CanTakeItemToPersonalInventory)
                {
                  Main.cursorOverride = 6;
                  break;
                }
                break;
            }
          }
        }
        else if (ItemSlot.ShiftInUse)
        {
          bool flag = false;
          if (Main.LocalPlayer.tileEntityAnchor.IsInValidUseTileEntity())
            flag = Main.LocalPlayer.tileEntityAnchor.GetTileEntity().OverrideItemSlotHover(inv, context, slot);
          if (obj.type > 0 && obj.stack > 0 && !inv[slot].favorited && !flag)
          {
            switch (context)
            {
              case 0:
              case 1:
              case 2:
                if (context == 0 && Main.CreativeMenu.IsShowingResearchMenu())
                {
                  Main.cursorOverride = 9;
                  break;
                }
                if (context == 0 && Main.InReforgeMenu)
                {
                  if (obj.maxStack == 1 && obj.Prefix(-3))
                  {
                    Main.cursorOverride = 9;
                    break;
                  }
                  break;
                }
                if (context == 0 && Main.InGuideCraftMenu)
                {
                  if (obj.material)
                  {
                    Main.cursorOverride = 9;
                    break;
                  }
                  break;
                }
                if (Main.player[Main.myPlayer].chest != -1 && ChestUI.TryPlacingInChest(obj, true))
                {
                  Main.cursorOverride = 9;
                  break;
                }
                break;
              case 3:
              case 4:
                if (Main.player[Main.myPlayer].ItemSpace(obj).CanTakeItemToPersonalInventory)
                {
                  Main.cursorOverride = 8;
                  break;
                }
                break;
              case 5:
              case 7:
              case 8:
              case 9:
              case 10:
              case 11:
              case 12:
              case 16:
              case 17:
              case 18:
              case 19:
              case 20:
              case 23:
              case 24:
              case 25:
              case 26:
              case 27:
              case 29:
                if (Main.player[Main.myPlayer].ItemSpace(inv[slot]).CanTakeItemToPersonalInventory)
                {
                  Main.cursorOverride = 7;
                  break;
                }
                break;
            }
          }
        }
      }
      else if (ItemSlot.ShiftInUse)
      {
        bool flag = false;
        if (Main.LocalPlayer.tileEntityAnchor.IsInValidUseTileEntity())
          flag = Main.LocalPlayer.tileEntityAnchor.GetTileEntity().OverrideItemSlotHover(inv, context, slot);
        if (obj.type > 0 && obj.stack > 0 && !inv[slot].favorited && !flag)
        {
          switch (context)
          {
            case 0:
            case 1:
            case 2:
              if (Main.npcShop > 0 && !obj.favorited)
              {
                Main.cursorOverride = 10;
                break;
              }
              if (context == 0 && Main.CreativeMenu.IsShowingResearchMenu())
              {
                Main.cursorOverride = 9;
                break;
              }
              if (context == 0 && Main.InReforgeMenu)
              {
                if (obj.maxStack == 1 && obj.Prefix(-3))
                {
                  Main.cursorOverride = 9;
                  break;
                }
                break;
              }
              if (context == 0 && Main.InGuideCraftMenu)
              {
                if (obj.material)
                {
                  Main.cursorOverride = 9;
                  break;
                }
                break;
              }
              if (Main.player[Main.myPlayer].chest != -1)
              {
                if (ChestUI.TryPlacingInChest(obj, true))
                {
                  Main.cursorOverride = 9;
                  break;
                }
                break;
              }
              Main.cursorOverride = 6;
              break;
            case 3:
            case 4:
              if (Main.player[Main.myPlayer].ItemSpace(obj).CanTakeItemToPersonalInventory)
              {
                Main.cursorOverride = 8;
                break;
              }
              break;
            case 5:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 29:
              if (Main.player[Main.myPlayer].ItemSpace(inv[slot]).CanTakeItemToPersonalInventory)
              {
                Main.cursorOverride = 7;
                break;
              }
              break;
          }
        }
      }
      if (!Main.keyState.IsKeyDown(Main.FavoriteKey) || !ItemSlot.canFavoriteAt[context] && (!Main.drawingPlayerChat || !ItemSlot.canShareAt[context]))
        return;
      if (obj.type > 0 && obj.stack > 0 && Main.drawingPlayerChat)
      {
        Main.cursorOverride = 2;
      }
      else
      {
        if (obj.type <= 0 || obj.stack <= 0)
          return;
        Main.cursorOverride = 3;
      }
    }

    private static bool OverrideLeftClick(Item[] inv, int context = 0, int slot = 0)
    {
      if (context == 10 && ItemSlot.isEquipLocked(inv[slot].type) || Main.LocalPlayer.tileEntityAnchor.IsInValidUseTileEntity() && Main.LocalPlayer.tileEntityAnchor.GetTileEntity().OverrideItemSlotLeftClick(inv, context, slot))
        return true;
      Item I = inv[slot];
      switch (Main.cursorOverride)
      {
        case 2:
          if (ChatManager.AddChatText(FontAssets.MouseText.Value, ItemTagHandler.GenerateTag(I), Vector2.One))
            SoundEngine.PlaySound(12);
          return true;
        case 3:
          if (!ItemSlot.canFavoriteAt[context])
            return false;
          I.favorited = !I.favorited;
          SoundEngine.PlaySound(12);
          return true;
        case 7:
          if (context == 29)
          {
            Item newItem = new Item();
            newItem.SetDefaults(inv[slot].netID);
            newItem.stack = newItem.maxStack;
            Main.player[Main.myPlayer].GetItem(Main.myPlayer, newItem, GetItemSettings.InventoryEntityToPlayerInventorySettings);
            SoundEngine.PlaySound(12);
            return true;
          }
          inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], GetItemSettings.InventoryEntityToPlayerInventorySettings);
          SoundEngine.PlaySound(12);
          return true;
        case 8:
          inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], GetItemSettings.InventoryEntityToPlayerInventorySettings);
          if (Main.player[Main.myPlayer].chest > -1)
            NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) slot));
          return true;
        case 9:
          if (Main.CreativeMenu.IsShowingResearchMenu())
          {
            Main.CreativeMenu.SwapItem(ref inv[slot]);
            SoundEngine.PlaySound(7);
          }
          else if (Main.InReforgeMenu)
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.reforgeItem);
            SoundEngine.PlaySound(7);
          }
          else if (Main.InGuideCraftMenu)
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.guideItem);
            Recipe.FindRecipes();
            SoundEngine.PlaySound(7);
          }
          else
            ChestUI.TryPlacingInChest(inv[slot], false);
          return true;
        default:
          return false;
      }
    }

    public static void LeftClick(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.LeftClick(ItemSlot.singleSlotArray, context);
      inv = ItemSlot.singleSlotArray[0];
    }

    public static void LeftClick(Item[] inv, int context = 0, int slot = 0)
    {
      Player player = Main.player[Main.myPlayer];
      bool flag = Main.mouseLeftRelease && Main.mouseLeft;
      if (flag)
      {
        if (ItemSlot.OverrideLeftClick(inv, context, slot))
          return;
        inv[slot].newAndShiny = false;
        if (ItemSlot.LeftClick_SellOrTrash(inv, context, slot) || player.itemAnimation != 0 || player.itemTime != 0)
          return;
      }
      int num1 = ItemSlot.PickItemMovementAction(inv, context, slot, Main.mouseItem);
      if (num1 != 3 && !flag)
        return;
      switch (num1)
      {
        case 0:
          if (context == 6 && Main.mouseItem.type != 0)
            inv[slot].SetDefaults();
          if (context != 11 || inv[slot].FitsAccessoryVanitySlot)
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
            if (inv[slot].stack > 0)
            {
              switch (context)
              {
                case 0:
                  AchievementsHelper.NotifyItemPickup(player, inv[slot]);
                  break;
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 16:
                case 17:
                case 25:
                case 27:
                  AchievementsHelper.HandleOnEquip(player, inv[slot], context);
                  break;
              }
            }
            if (inv[slot].type == 0 || inv[slot].stack < 1)
              inv[slot] = new Item();
            if (Main.mouseItem.IsTheSameAs(inv[slot]))
            {
              Utils.Swap<bool>(ref inv[slot].favorited, ref Main.mouseItem.favorited);
              if (inv[slot].stack != inv[slot].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
              {
                if (Main.mouseItem.stack + inv[slot].stack <= Main.mouseItem.maxStack)
                {
                  inv[slot].stack += Main.mouseItem.stack;
                  Main.mouseItem.stack = 0;
                }
                else
                {
                  int num2 = Main.mouseItem.maxStack - inv[slot].stack;
                  inv[slot].stack += num2;
                  Main.mouseItem.stack -= num2;
                }
              }
            }
            if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
              Main.mouseItem = new Item();
            if (Main.mouseItem.type > 0 || inv[slot].type > 0)
            {
              Recipe.FindRecipes();
              SoundEngine.PlaySound(7);
            }
            if (context == 3 && Main.netMode == 1)
            {
              NetMessage.SendData(32, number: player.chest, number2: ((float) slot));
              break;
            }
            break;
          }
          break;
        case 1:
          if (Main.mouseItem.stack == 1 && Main.mouseItem.type > 0 && inv[slot].type > 0 && inv[slot].IsNotTheSameAs(Main.mouseItem) && (context != 11 || Main.mouseItem.FitsAccessoryVanitySlot))
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
            SoundEngine.PlaySound(7);
            if (inv[slot].stack > 0)
            {
              if (context <= 12)
              {
                if (context != 0)
                {
                  if ((uint) (context - 8) > 4U)
                    goto label_59;
                }
                else
                {
                  AchievementsHelper.NotifyItemPickup(player, inv[slot]);
                  goto label_59;
                }
              }
              else if ((uint) (context - 16) > 1U && context != 25 && context != 27)
                goto label_59;
              AchievementsHelper.HandleOnEquip(player, inv[slot], context);
            }
          }
          else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
            if (inv[slot].type == 0 || inv[slot].stack < 1)
              inv[slot] = new Item();
            if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
              Main.mouseItem = new Item();
            if (Main.mouseItem.type > 0 || inv[slot].type > 0)
            {
              Recipe.FindRecipes();
              SoundEngine.PlaySound(7);
            }
          }
          else if (Main.mouseItem.type > 0 && inv[slot].type == 0 && (context != 11 || Main.mouseItem.FitsAccessoryVanitySlot))
          {
            if (Main.mouseItem.stack == 1)
            {
              Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
              if (inv[slot].type == 0 || inv[slot].stack < 1)
                inv[slot] = new Item();
              if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                Main.mouseItem = new Item();
              if (Main.mouseItem.type > 0 || inv[slot].type > 0)
              {
                Recipe.FindRecipes();
                SoundEngine.PlaySound(7);
              }
            }
            else
            {
              --Main.mouseItem.stack;
              inv[slot].SetDefaults(Main.mouseItem.type);
              Recipe.FindRecipes();
              SoundEngine.PlaySound(7);
            }
            if (inv[slot].stack > 0)
            {
              if (context <= 12)
              {
                if (context != 0)
                {
                  if ((uint) (context - 8) > 4U)
                    goto label_59;
                }
                else
                {
                  AchievementsHelper.NotifyItemPickup(player, inv[slot]);
                  goto label_59;
                }
              }
              else if ((uint) (context - 16) > 1U && context != 25 && context != 27)
                goto label_59;
              AchievementsHelper.HandleOnEquip(player, inv[slot], context);
            }
          }
label_59:
          if ((context == 23 || context == 24) && Main.netMode == 1)
            NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot));
          if (context == 26 && Main.netMode == 1)
          {
            NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot));
            break;
          }
          break;
        case 2:
          if (Main.mouseItem.stack == 1 && Main.mouseItem.dye > (byte) 0 && inv[slot].type > 0 && inv[slot].type != Main.mouseItem.type)
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
            SoundEngine.PlaySound(7);
            if (inv[slot].stack > 0)
            {
              if (context <= 12)
              {
                if (context != 0)
                {
                  if ((uint) (context - 8) > 4U)
                    goto label_95;
                }
                else
                {
                  AchievementsHelper.NotifyItemPickup(player, inv[slot]);
                  goto label_95;
                }
              }
              else if ((uint) (context - 16) > 1U && context != 25 && context != 27)
                goto label_95;
              AchievementsHelper.HandleOnEquip(player, inv[slot], context);
            }
          }
          else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
          {
            Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
            if (inv[slot].type == 0 || inv[slot].stack < 1)
              inv[slot] = new Item();
            if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
              Main.mouseItem = new Item();
            if (Main.mouseItem.type > 0 || inv[slot].type > 0)
            {
              Recipe.FindRecipes();
              SoundEngine.PlaySound(7);
            }
          }
          else if (Main.mouseItem.dye > (byte) 0 && inv[slot].type == 0)
          {
            if (Main.mouseItem.stack == 1)
            {
              Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
              if (inv[slot].type == 0 || inv[slot].stack < 1)
                inv[slot] = new Item();
              if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                Main.mouseItem = new Item();
              if (Main.mouseItem.type > 0 || inv[slot].type > 0)
              {
                Recipe.FindRecipes();
                SoundEngine.PlaySound(7);
              }
            }
            else
            {
              --Main.mouseItem.stack;
              inv[slot].SetDefaults(Main.mouseItem.type);
              Recipe.FindRecipes();
              SoundEngine.PlaySound(7);
            }
            if (inv[slot].stack > 0)
            {
              if (context <= 12)
              {
                if (context != 0)
                {
                  if ((uint) (context - 8) > 4U)
                    goto label_95;
                }
                else
                {
                  AchievementsHelper.NotifyItemPickup(player, inv[slot]);
                  goto label_95;
                }
              }
              else if ((uint) (context - 16) > 1U && context != 25 && context != 27)
                goto label_95;
              AchievementsHelper.HandleOnEquip(player, inv[slot], context);
            }
          }
label_95:
          if (context == 25 && Main.netMode == 1)
            NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot), number4: 1f);
          if (context == 27 && Main.netMode == 1)
          {
            NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot), number4: 1f);
            break;
          }
          break;
        case 3:
          ItemSlot.HandleShopSlot(inv, slot, false, true);
          break;
        case 4:
          Chest chest = Main.instance.shop[Main.npcShop];
          if (player.SellItem(Main.mouseItem))
          {
            chest.AddItemToShop(Main.mouseItem);
            Main.mouseItem.SetDefaults();
            SoundEngine.PlaySound(18);
          }
          else if (Main.mouseItem.value == 0)
          {
            chest.AddItemToShop(Main.mouseItem);
            Main.mouseItem.SetDefaults();
            SoundEngine.PlaySound(7);
          }
          Recipe.FindRecipes();
          Main.stackSplit = 9999;
          break;
        default:
          if (num1 == 5 && Main.mouseItem.IsAir)
          {
            SoundEngine.PlaySound(7);
            Main.mouseItem.SetDefaults(inv[slot].netID);
            Main.mouseItem.stack = Main.mouseItem.maxStack;
            break;
          }
          break;
      }
      if ((uint) context <= 2U || context == 5)
        return;
      inv[slot].favorited = false;
    }

    private static bool LeftClick_SellOrTrash(Item[] inv, int context, int slot)
    {
      bool flag1 = false;
      bool flag2 = false;
      if (ItemSlot.NotUsingGamepad && ItemSlot.Options.DisableLeftShiftTrashCan)
      {
        switch (context)
        {
          case 0:
          case 1:
          case 2:
          case 3:
          case 4:
          case 7:
            flag1 = true;
            break;
        }
        if (ItemSlot.ControlInUse & flag1)
        {
          ItemSlot.SellOrTrash(inv, context, slot);
          flag2 = true;
        }
      }
      else
      {
        switch (context)
        {
          case 0:
          case 1:
          case 2:
          case 3:
          case 4:
            flag1 = Main.player[Main.myPlayer].chest == -1;
            break;
        }
        if (ItemSlot.ShiftInUse & flag1)
        {
          ItemSlot.SellOrTrash(inv, context, slot);
          flag2 = true;
        }
      }
      return flag2;
    }

    private static void SellOrTrash(Item[] inv, int context, int slot)
    {
      Player player = Main.player[Main.myPlayer];
      if (inv[slot].type <= 0)
        return;
      if (Main.npcShop > 0 && !inv[slot].favorited)
      {
        Chest chest = Main.instance.shop[Main.npcShop];
        if (inv[slot].type >= 71 && inv[slot].type <= 74)
          return;
        if (player.SellItem(inv[slot]))
        {
          chest.AddItemToShop(inv[slot]);
          inv[slot].SetDefaults();
          SoundEngine.PlaySound(18);
          Recipe.FindRecipes();
        }
        else
        {
          if (inv[slot].value != 0)
            return;
          chest.AddItemToShop(inv[slot]);
          inv[slot].SetDefaults();
          SoundEngine.PlaySound(7);
          Recipe.FindRecipes();
        }
      }
      else
      {
        if (inv[slot].favorited)
          return;
        SoundEngine.PlaySound(7);
        player.trashItem = inv[slot].Clone();
        inv[slot].SetDefaults();
        if (context == 3 && Main.netMode == 1)
          NetMessage.SendData(32, number: player.chest, number2: ((float) slot));
        Recipe.FindRecipes();
      }
    }

    private static string GetOverrideInstructions(Item[] inv, int context, int slot)
    {
      Player player = Main.player[Main.myPlayer];
      TileEntity tileEntity = player.tileEntityAnchor.GetTileEntity();
      string instruction;
      if (tileEntity != null && tileEntity.TryGetItemGamepadOverrideInstructions(inv, context, slot, out instruction))
        return instruction;
      if (inv[slot].type > 0 && inv[slot].stack > 0)
      {
        if (!inv[slot].favorited)
        {
          switch (context)
          {
            case 0:
            case 1:
            case 2:
              if (Main.npcShop > 0 && !inv[slot].favorited)
                return Lang.misc[75].Value;
              if (Main.player[Main.myPlayer].chest != -1)
              {
                if (ChestUI.TryPlacingInChest(inv[slot], true))
                  return Lang.misc[76].Value;
                break;
              }
              return Main.InGuideCraftMenu && inv[slot].material ? Lang.misc[76].Value : Lang.misc[74].Value;
            case 3:
            case 4:
              if (Main.player[Main.myPlayer].ItemSpace(inv[slot]).CanTakeItemToPersonalInventory)
                return Lang.misc[76].Value;
              break;
            case 5:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 25:
            case 27:
              if (Main.player[Main.myPlayer].ItemSpace(inv[slot]).CanTakeItemToPersonalInventory)
                return Lang.misc[68].Value;
              break;
          }
        }
        bool flag = false;
        if ((uint) context <= 4U)
          flag = player.chest == -1;
        if (flag)
        {
          if (Main.npcShop > 0 && !inv[slot].favorited)
          {
            Chest chest = Main.instance.shop[Main.npcShop];
            return inv[slot].type >= 71 && inv[slot].type <= 74 ? "" : Lang.misc[75].Value;
          }
          if (!inv[slot].favorited)
            return Lang.misc[74].Value;
        }
      }
      return "";
    }

    public static int PickItemMovementAction(Item[] inv, int context, int slot, Item checkItem)
    {
      Player player = Main.player[Main.myPlayer];
      int num = -1;
      switch (context)
      {
        case 0:
          num = 0;
          break;
        case 1:
          if (checkItem.type == 0 || checkItem.type == 71 || checkItem.type == 72 || checkItem.type == 73 || checkItem.type == 74)
          {
            num = 0;
            break;
          }
          break;
        case 2:
          if (checkItem.FitsAmmoSlot())
          {
            num = 0;
            break;
          }
          break;
        case 3:
          num = 0;
          break;
        case 4:
          Item[] chestinv;
          ChestUI.GetContainerUsageInfo(out bool _, out chestinv);
          if (!ChestUI.IsBlockedFromTransferIntoChest(checkItem, chestinv))
          {
            num = 0;
            break;
          }
          break;
        case 5:
          if (checkItem.Prefix(-3) || checkItem.type == 0)
          {
            num = 0;
            break;
          }
          break;
        case 6:
          num = 0;
          break;
        case 7:
          if (checkItem.material || checkItem.type == 0)
          {
            num = 0;
            break;
          }
          break;
        case 8:
          if (checkItem.type == 0 || checkItem.headSlot > -1 && slot == 0 || checkItem.bodySlot > -1 && slot == 1 || checkItem.legSlot > -1 && slot == 2)
          {
            num = 1;
            break;
          }
          break;
        case 9:
          if (checkItem.type == 0 || checkItem.headSlot > -1 && slot == 10 || checkItem.bodySlot > -1 && slot == 11 || checkItem.legSlot > -1 && slot == 12)
          {
            num = 1;
            break;
          }
          break;
        case 10:
          if (checkItem.type == 0 || checkItem.accessory && !ItemSlot.AccCheck(Main.LocalPlayer.armor, checkItem, slot))
          {
            num = 1;
            break;
          }
          break;
        case 11:
          if (checkItem.type == 0 || checkItem.accessory && !ItemSlot.AccCheck(Main.LocalPlayer.armor, checkItem, slot))
          {
            num = 1;
            break;
          }
          break;
        case 23:
          if (checkItem.type == 0 || checkItem.headSlot > 0 && slot == 0 || checkItem.bodySlot > 0 && slot == 1 || checkItem.legSlot > 0 && slot == 2)
          {
            num = 1;
            break;
          }
          break;
        case 24:
          if (checkItem.type == 0 || checkItem.accessory && !ItemSlot.AccCheck(inv, checkItem, slot))
          {
            num = 1;
            break;
          }
          break;
        case 26:
          if (checkItem.type == 0 || checkItem.headSlot > 0)
          {
            num = 1;
            break;
          }
          break;
        default:
          if (context == 12 || context == 25 || context == 27)
          {
            num = 2;
            break;
          }
          switch (context)
          {
            case 15:
              if (checkItem.type == 0 && inv[slot].type > 0)
              {
                num = 3;
                break;
              }
              if (checkItem.type == inv[slot].type && checkItem.type > 0 && checkItem.stack < checkItem.maxStack && inv[slot].stack > 0)
              {
                num = 3;
                break;
              }
              if (inv[slot].type == 0 && checkItem.type > 0 && (checkItem.type < 71 || checkItem.type > 74))
              {
                num = 4;
                break;
              }
              break;
            case 16:
              if (checkItem.type == 0 || Main.projHook[checkItem.shoot])
              {
                num = 1;
                break;
              }
              break;
            case 17:
              if (checkItem.type == 0 || checkItem.mountType != -1 && !MountID.Sets.Cart[checkItem.mountType])
              {
                num = 1;
                break;
              }
              break;
            case 18:
              if (checkItem.type == 0 || checkItem.mountType != -1 && MountID.Sets.Cart[checkItem.mountType])
              {
                num = 1;
                break;
              }
              break;
            case 19:
              if (checkItem.type == 0 || checkItem.buffType > 0 && Main.vanityPet[checkItem.buffType] && !Main.lightPet[checkItem.buffType])
              {
                num = 1;
                break;
              }
              break;
            case 20:
              if (checkItem.type == 0 || checkItem.buffType > 0 && Main.lightPet[checkItem.buffType])
              {
                num = 1;
                break;
              }
              break;
            default:
              if (context == 29 && checkItem.type == 0 && inv[slot].type > 0)
              {
                num = 5;
                break;
              }
              break;
          }
          break;
      }
      if (context == 30)
        num = 0;
      return num;
    }

    public static void RightClick(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.RightClick(ItemSlot.singleSlotArray, context);
      inv = ItemSlot.singleSlotArray[0];
    }

    public static void RightClick(Item[] inv, int context = 0, int slot = 0)
    {
      Player player = Main.player[Main.myPlayer];
      inv[slot].newAndShiny = false;
      if (player.itemAnimation > 0 || ItemSlot.RightClick_FindSpecialActions(inv, context, slot, player))
        return;
      if ((context == 0 || context == 4 || context == 3) && Main.mouseRight && Main.mouseRightRelease && inv[slot].maxStack == 1)
      {
        ItemSlot.SwapEquip(inv, context, slot);
      }
      else
      {
        if (Main.stackSplit > 1 || !Main.mouseRight)
          return;
        bool flag = true;
        if (context == 0 && inv[slot].maxStack <= 1)
          flag = false;
        if (context == 3 && inv[slot].maxStack <= 1)
          flag = false;
        if (context == 4 && inv[slot].maxStack <= 1)
          flag = false;
        if (!flag || !Main.mouseItem.IsTheSameAs(inv[slot]) && Main.mouseItem.type != 0 || Main.mouseItem.stack >= Main.mouseItem.maxStack && Main.mouseItem.type != 0)
          return;
        ItemSlot.PickupItemIntoMouse(inv, context, slot, player);
        SoundEngine.PlaySound(12);
        ItemSlot.RefreshStackSplitCooldown();
      }
    }

    public static void PickupItemIntoMouse(Item[] inv, int context, int slot, Player player)
    {
      if (Main.mouseItem.type == 0)
      {
        Main.mouseItem = inv[slot].Clone();
        if (context == 29)
          Main.mouseItem.SetDefaults(Main.mouseItem.type);
        Main.mouseItem.stack = 0;
        Main.mouseItem.favorited = inv[slot].favorited && inv[slot].stack == 1;
      }
      ++Main.mouseItem.stack;
      if (context != 29)
        --inv[slot].stack;
      if (inv[slot].stack <= 0)
        inv[slot] = new Item();
      Recipe.FindRecipes();
      if (context == 3 && Main.netMode == 1)
        NetMessage.SendData(32, number: player.chest, number2: ((float) slot));
      if ((context == 23 || context == 24) && Main.netMode == 1)
        NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot));
      if (context == 25 && Main.netMode == 1)
        NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot), number4: 1f);
      if (context == 26 && Main.netMode == 1)
        NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot));
      if (context != 27 || Main.netMode != 1)
        return;
      NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot), number4: 1f);
    }

    public static void RefreshStackSplitCooldown()
    {
      if (Main.stackSplit == 0)
        Main.stackSplit = 30;
      else
        Main.stackSplit = Main.stackDelay;
    }

    private static bool RightClick_FindSpecialActions(
      Item[] inv,
      int context,
      int slot,
      Player player)
    {
      bool flag1 = false;
      switch (context)
      {
        case 0:
          flag1 = true;
          if (Main.mouseRight && (inv[slot].type >= 3318 && inv[slot].type <= 3332 || inv[slot].type == 3860 || inv[slot].type == 3862 || inv[slot].type == 3861 || inv[slot].type == 4782 || inv[slot].type == 4957))
          {
            if (Main.mouseRightRelease)
            {
              player.OpenBossBag(inv[slot].type);
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type > 0 && inv[slot].type < 5045 && ItemID.Sets.IsFishingCrate[inv[slot].type])
          {
            if (Main.mouseRightRelease)
            {
              player.OpenFishingCrate(inv[slot].type);
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 3093)
          {
            if (Main.mouseRightRelease)
            {
              player.OpenHerbBag();
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 4345)
          {
            if (Main.mouseRightRelease)
            {
              player.OpenCanofWorms();
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 4410)
          {
            if (Main.mouseRightRelease)
            {
              player.OpenOyster();
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 1774)
          {
            if (Main.mouseRightRelease)
            {
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              player.OpenGoodieBag();
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 3085)
          {
            if (Main.mouseRightRelease && player.ConsumeItem(327))
            {
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              player.OpenLockBox();
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 4879)
          {
            if (Main.mouseRightRelease && player.HasItem(329))
            {
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              player.OpenShadowLockbox();
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && inv[slot].type == 1869)
          {
            if (Main.mouseRightRelease)
            {
              --inv[slot].stack;
              if (inv[slot].stack == 0)
                inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
              Main.stackSplit = 30;
              Main.mouseRightRelease = false;
              player.openPresent();
              Recipe.FindRecipes();
              break;
            }
            break;
          }
          if (Main.mouseRight && Main.mouseRightRelease && (inv[slot].type == 599 || inv[slot].type == 600 || inv[slot].type == 601))
          {
            SoundEngine.PlaySound(7);
            Main.stackSplit = 30;
            Main.mouseRightRelease = false;
            int num = Main.rand.Next(14);
            if (num == 0 && Main.hardMode)
              inv[slot].SetDefaults(602);
            else if (num <= 7)
            {
              inv[slot].SetDefaults(586);
              inv[slot].stack = Main.rand.Next(20, 50);
            }
            else
            {
              inv[slot].SetDefaults(591);
              inv[slot].stack = Main.rand.Next(20, 50);
            }
            Recipe.FindRecipes();
            break;
          }
          flag1 = false;
          break;
        case 9:
        case 11:
          flag1 = true;
          if (Main.mouseRight && Main.mouseRightRelease)
          {
            if (Main.npcShop > 0)
              return true;
            if (inv[slot].type > 0 && inv[slot].stack > 0 || inv[slot - 10].type > 0 && inv[slot - 10].stack > 0)
            {
              Item obj = inv[slot - 10];
              bool flag2 = context != 11 || obj.FitsAccessoryVanitySlot || obj.IsAir;
              if (flag2 && context == 11 && inv[slot].wingSlot > (sbyte) 0)
              {
                for (int index = 3; index < 10; ++index)
                {
                  if (inv[index].wingSlot > (sbyte) 0 && index != slot - 10)
                    flag2 = false;
                }
              }
              if (flag2)
              {
                Utils.Swap<Item>(ref inv[slot], ref inv[slot - 10]);
                SoundEngine.PlaySound(7);
                Recipe.FindRecipes();
                if (inv[slot].stack > 0)
                {
                  switch (context)
                  {
                    case 0:
                      AchievementsHelper.NotifyItemPickup(player, inv[slot]);
                      break;
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 16:
                    case 17:
                    case 25:
                    case 27:
                      AchievementsHelper.HandleOnEquip(player, inv[slot], context);
                      break;
                  }
                }
                else
                  break;
              }
              else
                break;
            }
            else
              break;
          }
          else
            break;
          break;
        case 12:
        case 25:
        case 27:
          flag1 = true;
          if (Main.mouseRight && Main.mouseRightRelease)
          {
            bool flag3 = false;
            if (!flag3 && (Main.mouseItem.stack < Main.mouseItem.maxStack && Main.mouseItem.type > 0 || Main.mouseItem.IsAir) && inv[slot].type > 0 && (Main.mouseItem.type == inv[slot].type || Main.mouseItem.IsAir))
            {
              flag3 = true;
              if (Main.mouseItem.IsAir)
                Main.mouseItem.SetDefaults(inv[slot].type);
              else
                ++Main.mouseItem.stack;
              inv[slot].SetDefaults();
              SoundEngine.PlaySound(7);
            }
            if (flag3)
            {
              if (context == 25 && Main.netMode == 1)
                NetMessage.SendData(121, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot), number4: 1f);
              if (context == 27 && Main.netMode == 1)
              {
                NetMessage.SendData(124, number: Main.myPlayer, number2: ((float) player.tileEntityAnchor.interactEntityID), number3: ((float) slot), number4: 1f);
                break;
              }
              break;
            }
            break;
          }
          break;
        case 15:
          flag1 = true;
          ItemSlot.HandleShopSlot(inv, slot, true, false);
          break;
      }
      return flag1;
    }

    private static void HandleShopSlot(
      Item[] inv,
      int slot,
      bool rightClickIsValid,
      bool leftClickIsValid)
    {
      if (Main.cursorOverride == 2)
        return;
      Chest chest = Main.instance.shop[Main.npcShop];
      bool flag = Main.mouseRight & rightClickIsValid || Main.mouseLeft & leftClickIsValid;
      if (!(Main.stackSplit <= 1 & flag) || inv[slot].type <= 0 || !Main.mouseItem.IsTheSameAs(inv[slot]) && Main.mouseItem.type != 0)
        return;
      int num = Main.superFastStack + 1;
      Player localPlayer = Main.LocalPlayer;
      for (int index = 0; index < num; ++index)
      {
        if (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0)
        {
          int calcForBuying;
          localPlayer.GetItemExpectedPrice(inv[slot], out int _, out calcForBuying);
          if (localPlayer.BuyItem(calcForBuying, inv[slot].shopSpecialCurrency) && inv[slot].stack > 0)
          {
            if (index == 0)
            {
              if (inv[slot].value > 0)
                SoundEngine.PlaySound(18);
              else
                SoundEngine.PlaySound(7);
            }
            if (Main.mouseItem.type == 0)
            {
              Main.mouseItem.netDefaults(inv[slot].netID);
              if (inv[slot].prefix != (byte) 0)
                Main.mouseItem.Prefix((int) inv[slot].prefix);
              Main.mouseItem.stack = 0;
            }
            if (!inv[slot].buyOnce)
              Main.shopSellbackHelper.Add(inv[slot]);
            ++Main.mouseItem.stack;
            ItemSlot.RefreshStackSplitCooldown();
            if (inv[slot].buyOnce && --inv[slot].stack <= 0)
              inv[slot].SetDefaults();
          }
        }
      }
    }

    public static void Draw(
      SpriteBatch spriteBatch,
      ref Item inv,
      int context,
      Vector2 position,
      Color lightColor = default (Color))
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.Draw(spriteBatch, ItemSlot.singleSlotArray, context, 0, position, lightColor);
      inv = ItemSlot.singleSlotArray[0];
    }

    public static void Draw(
      SpriteBatch spriteBatch,
      Item[] inv,
      int context,
      int slot,
      Vector2 position,
      Color lightColor = default (Color))
    {
      Player player = Main.player[Main.myPlayer];
      Item obj = inv[slot];
      float inventoryScale = Main.inventoryScale;
      Color color1 = Color.White;
      if (lightColor != Color.Transparent)
        color1 = lightColor;
      int ID = -1;
      bool flag1 = false;
      int num1 = 0;
      if (PlayerInput.UsingGamepadUI)
      {
        switch (context)
        {
          case 0:
          case 1:
          case 2:
            ID = slot;
            break;
          case 3:
          case 4:
            ID = 400 + slot;
            break;
          case 5:
            ID = 303;
            break;
          case 6:
            ID = 300;
            break;
          case 7:
            ID = 1500;
            break;
          case 8:
          case 9:
          case 10:
          case 11:
            ID = 100 + slot;
            break;
          case 12:
            if (inv == player.dye)
              ID = 120 + slot;
            if (inv == player.miscDyes)
            {
              ID = 185 + slot;
              break;
            }
            break;
          case 15:
            ID = 2700 + slot;
            break;
          case 16:
            ID = 184;
            break;
          case 17:
            ID = 183;
            break;
          case 18:
            ID = 182;
            break;
          case 19:
            ID = 180;
            break;
          case 20:
            ID = 181;
            break;
          case 22:
            if (UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeBig != -1)
              ID = 700 + UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeBig;
            if (UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeSmall != -1)
            {
              ID = 1500 + UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeSmall + 1;
              break;
            }
            break;
          case 23:
            ID = 5100 + slot;
            break;
          case 24:
            ID = 5100 + slot;
            break;
          case 25:
            ID = 5108 + slot;
            break;
          case 26:
            ID = 5000 + slot;
            break;
          case 27:
            ID = 5002 + slot;
            break;
          case 29:
            ID = 3000 + slot;
            if (UILinkPointNavigator.Shortcuts.CREATIVE_ItemSlotShouldHighlightAsSelected)
            {
              ID = UILinkPointNavigator.CurrentPoint;
              break;
            }
            break;
          case 30:
            ID = 15000 + slot;
            break;
        }
        flag1 = UILinkPointNavigator.CurrentPoint == ID;
        if (context == 0)
        {
          num1 = player.DpadRadial.GetDrawMode(slot);
          if (num1 > 0 && !PlayerInput.CurrentProfile.UsingDpadHotbar())
            num1 = 0;
        }
      }
      Texture2D texture2D1 = TextureAssets.InventoryBack.Value;
      Color color2 = Main.inventoryBack;
      bool flag2 = false;
      if (obj.type > 0 && obj.stack > 0 && obj.favorited && context != 13 && context != 21 && context != 22 && context != 14)
      {
        texture2D1 = TextureAssets.InventoryBack10.Value;
        if (context == 0 && slot < 10 && player.selectedItem == slot)
        {
          color2 = Color.White;
          texture2D1 = TextureAssets.InventoryBack17.Value;
        }
      }
      else if (obj.type > 0 && obj.stack > 0 && ItemSlot.Options.HighlightNewItems && obj.newAndShiny && context != 13 && context != 21 && context != 14 && context != 22)
      {
        texture2D1 = TextureAssets.InventoryBack15.Value;
        float num2 = (float) ((double) ((float) Main.mouseTextColor / (float) byte.MaxValue) * 0.200000002980232 + 0.800000011920929);
        color2 = color2.MultiplyRGBA(new Color(num2, num2, num2));
      }
      else if (PlayerInput.UsingGamepadUI && obj.type > 0 && obj.stack > 0 && num1 != 0 && context != 13 && context != 21 && context != 22)
      {
        texture2D1 = TextureAssets.InventoryBack15.Value;
        float num3 = (float) ((double) ((float) Main.mouseTextColor / (float) byte.MaxValue) * 0.200000002980232 + 0.800000011920929);
        color2 = num1 != 1 ? color2.MultiplyRGBA(new Color(num3 / 2f, num3, num3 / 2f)) : color2.MultiplyRGBA(new Color(num3, num3 / 2f, num3 / 2f));
      }
      else if (context == 0 && slot < 10)
      {
        texture2D1 = TextureAssets.InventoryBack9.Value;
        if (player.selectedItem == slot && !PlayerInput.UsingGamepad)
        {
          texture2D1 = TextureAssets.InventoryBack14.Value;
          color2 = Color.White;
        }
      }
      else if (context == 28)
      {
        texture2D1 = TextureAssets.InventoryBack7.Value;
        color2 = Color.White;
      }
      else if (context == 10 || context == 8 || context == 16 || context == 17 || context == 19 || context == 18 || context == 20)
        texture2D1 = TextureAssets.InventoryBack3.Value;
      else if (context == 11 || context == 9 || context == 24 || context == 23 || context == 26)
        texture2D1 = TextureAssets.InventoryBack8.Value;
      else if (context == 12 || context == 25 || context == 27)
      {
        texture2D1 = TextureAssets.InventoryBack12.Value;
      }
      else
      {
        switch (context)
        {
          case 3:
            texture2D1 = TextureAssets.InventoryBack5.Value;
            break;
          case 4:
            texture2D1 = TextureAssets.InventoryBack2.Value;
            break;
          default:
            if (context == 7 || context == 5)
            {
              texture2D1 = TextureAssets.InventoryBack4.Value;
              break;
            }
            switch (context)
            {
              case 6:
                texture2D1 = TextureAssets.InventoryBack7.Value;
                break;
              case 13:
                byte num4 = 200;
                if (slot == Main.player[Main.myPlayer].selectedItem)
                {
                  texture2D1 = TextureAssets.InventoryBack14.Value;
                  num4 = byte.MaxValue;
                }
                color2 = new Color((int) num4, (int) num4, (int) num4, (int) num4);
                break;
              default:
                if (context == 14 || context == 21)
                {
                  flag2 = true;
                  break;
                }
                switch (context)
                {
                  case 15:
                    texture2D1 = TextureAssets.InventoryBack6.Value;
                    break;
                  case 22:
                    texture2D1 = TextureAssets.InventoryBack4.Value;
                    if (ItemSlot.DrawGoldBGForCraftingMaterial)
                    {
                      ItemSlot.DrawGoldBGForCraftingMaterial = false;
                      texture2D1 = TextureAssets.InventoryBack14.Value;
                      float t = (float) color2.A / (float) byte.MaxValue;
                      color2 = Color.White * ((double) t >= 0.699999988079071 ? 1f : Utils.GetLerpValue(0.0f, 0.7f, t, true));
                      break;
                    }
                    break;
                  case 29:
                    color2 = new Color(53, 69, (int) sbyte.MaxValue, (int) byte.MaxValue);
                    texture2D1 = TextureAssets.InventoryBack18.Value;
                    break;
                  case 30:
                    flag2 = !flag1;
                    break;
                }
                break;
            }
            break;
        }
      }
      if ((context == 0 || context == 2) && ItemSlot.inventoryGlowTime[slot] > 0 && !inv[slot].favorited && !inv[slot].IsAir)
      {
        float num5 = Main.invAlpha / (float) byte.MaxValue;
        Color color3 = new Color(63, 65, 151, (int) byte.MaxValue) * num5;
        Color color4 = Main.hslToRgb(ItemSlot.inventoryGlowHue[slot], 1f, 0.5f) * num5;
        float num6 = (float) ItemSlot.inventoryGlowTime[slot] / 300f;
        float num7 = num6 * num6;
        Color color5 = color4;
        double num8 = (double) num7 / 2.0;
        color2 = Color.Lerp(color3, color5, (float) num8);
        texture2D1 = TextureAssets.InventoryBack13.Value;
      }
      if ((context == 4 || context == 3) && ItemSlot.inventoryGlowTimeChest[slot] > 0 && !inv[slot].favorited && !inv[slot].IsAir)
      {
        float num9 = Main.invAlpha / (float) byte.MaxValue;
        Color color6 = new Color(130, 62, 102, (int) byte.MaxValue) * num9;
        if (context == 3)
          color6 = new Color(104, 52, 52, (int) byte.MaxValue) * num9;
        Color color7 = Main.hslToRgb(ItemSlot.inventoryGlowHueChest[slot], 1f, 0.5f) * num9;
        float num10 = (float) ItemSlot.inventoryGlowTimeChest[slot] / 300f;
        float num11 = num10 * num10;
        color2 = Color.Lerp(color6, color7, num11 / 2f);
        texture2D1 = TextureAssets.InventoryBack13.Value;
      }
      if (flag1)
      {
        texture2D1 = TextureAssets.InventoryBack14.Value;
        color2 = Color.White;
      }
      if (context == 28 && Main.MouseScreen.Between(position, position + texture2D1.Size() * inventoryScale) && !player.mouseInterface)
      {
        texture2D1 = TextureAssets.InventoryBack14.Value;
        color2 = Color.White;
      }
      if (!flag2)
        spriteBatch.Draw(texture2D1, position, new Rectangle?(), color2, 0.0f, new Vector2(), inventoryScale, SpriteEffects.None, 0.0f);
      int num12 = -1;
      switch (context)
      {
        case 8:
        case 23:
          if (slot == 0)
            num12 = 0;
          if (slot == 1)
            num12 = 6;
          if (slot == 2)
          {
            num12 = 12;
            break;
          }
          break;
        case 9:
          if (slot == 10)
            num12 = 3;
          if (slot == 11)
            num12 = 9;
          if (slot == 12)
          {
            num12 = 15;
            break;
          }
          break;
        case 10:
        case 24:
          num12 = 11;
          break;
        case 11:
          num12 = 2;
          break;
        case 12:
        case 25:
        case 27:
          num12 = 1;
          break;
        case 16:
          num12 = 4;
          break;
        case 17:
          num12 = 13;
          break;
        case 18:
          num12 = 7;
          break;
        case 19:
          num12 = 10;
          break;
        case 20:
          num12 = 17;
          break;
        case 26:
          num12 = 0;
          break;
      }
      if ((obj.type <= 0 || obj.stack <= 0) && num12 != -1)
      {
        Texture2D texture2D2 = TextureAssets.Extra[54].Value;
        Rectangle r = texture2D2.Frame(3, 6, num12 % 3, num12 / 3);
        r.Width -= 2;
        r.Height -= 2;
        spriteBatch.Draw(texture2D2, position + texture2D1.Size() / 2f * inventoryScale, new Rectangle?(r), Color.White * 0.35f, 0.0f, r.Size() / 2f, inventoryScale, SpriteEffects.None, 0.0f);
      }
      Vector2 vector2 = texture2D1.Size() * inventoryScale;
      if (obj.type > 0 && obj.stack > 0)
      {
        Main.instance.LoadItem(obj.type);
        Texture2D texture2D3 = TextureAssets.Item[obj.type].Value;
        Rectangle r = Main.itemAnimations[obj.type] == null ? texture2D3.Frame() : Main.itemAnimations[obj.type].GetFrame(texture2D3);
        Color currentColor = color1;
        float scale1 = 1f;
        ItemSlot.GetItemLight(ref currentColor, ref scale1, obj);
        float num13 = 1f;
        if (r.Width > 32 || r.Height > 32)
          num13 = r.Width <= r.Height ? 32f / (float) r.Height : 32f / (float) r.Width;
        float scale2 = num13 * inventoryScale;
        Vector2 position1 = position + vector2 / 2f - r.Size() * scale2 / 2f;
        Vector2 origin = r.Size() * (float) ((double) scale1 / 2.0 - 0.5);
        spriteBatch.Draw(texture2D3, position1, new Rectangle?(r), obj.GetAlpha(currentColor), 0.0f, origin, scale2 * scale1, SpriteEffects.None, 0.0f);
        if (obj.color != Color.Transparent)
          spriteBatch.Draw(texture2D3, position1, new Rectangle?(r), obj.GetColor(color1), 0.0f, origin, scale2 * scale1, SpriteEffects.None, 0.0f);
        if (ItemID.Sets.TrapSigned[obj.type])
          spriteBatch.Draw(TextureAssets.Wire.Value, position + new Vector2(40f, 40f) * inventoryScale, new Rectangle?(new Rectangle(4, 58, 8, 8)), color1, 0.0f, new Vector2(4f), 1f, SpriteEffects.None, 0.0f);
        if (obj.stack > 1)
          ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, obj.stack.ToString(), position + new Vector2(10f, 26f) * inventoryScale, color1, 0.0f, Vector2.Zero, new Vector2(inventoryScale), spread: inventoryScale);
        int num14 = -1;
        if (context == 13)
        {
          if (obj.DD2Summon)
          {
            for (int index = 0; index < 58; ++index)
            {
              if (inv[index].type == 3822)
                num14 += inv[index].stack;
            }
            if (num14 >= 0)
              ++num14;
          }
          if (obj.useAmmo > 0)
          {
            int useAmmo = obj.useAmmo;
            num14 = 0;
            for (int index = 0; index < 58; ++index)
            {
              if (inv[index].ammo == useAmmo)
                num14 += inv[index].stack;
            }
          }
          if (obj.fishingPole > 0)
          {
            num14 = 0;
            for (int index = 0; index < 58; ++index)
            {
              if (inv[index].bait > 0)
                num14 += inv[index].stack;
            }
          }
          if (obj.tileWand > 0)
          {
            int tileWand = obj.tileWand;
            num14 = 0;
            for (int index = 0; index < 58; ++index)
            {
              if (inv[index].type == tileWand)
                num14 += inv[index].stack;
            }
          }
          if (obj.type == 509 || obj.type == 851 || obj.type == 850 || obj.type == 3612 || obj.type == 3625 || obj.type == 3611)
          {
            num14 = 0;
            for (int index = 0; index < 58; ++index)
            {
              if (inv[index].type == 530)
                num14 += inv[index].stack;
            }
          }
        }
        if (num14 != -1)
          ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, num14.ToString(), position + new Vector2(8f, 30f) * inventoryScale, color1, 0.0f, Vector2.Zero, new Vector2(inventoryScale * 0.8f), spread: inventoryScale);
        if (context == 13)
        {
          string text = string.Concat((object) (slot + 1));
          if (text == "10")
            text = "0";
          ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, text, position + new Vector2(8f, 4f) * inventoryScale, color1, 0.0f, Vector2.Zero, new Vector2(inventoryScale), spread: inventoryScale);
        }
        if (context == 13 && obj.potion)
        {
          Vector2 position2 = position + texture2D1.Size() * inventoryScale / 2f - TextureAssets.Cd.Value.Size() * inventoryScale / 2f;
          Color color8 = obj.GetAlpha(color1) * ((float) player.potionDelay / (float) player.potionDelayTime);
          spriteBatch.Draw(TextureAssets.Cd.Value, position2, new Rectangle?(), color8, 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
        }
        if ((context == 10 || context == 18) && obj.expertOnly && !Main.expertMode)
        {
          Vector2 position3 = position + texture2D1.Size() * inventoryScale / 2f - TextureAssets.Cd.Value.Size() * inventoryScale / 2f;
          Color white = Color.White;
          spriteBatch.Draw(TextureAssets.Cd.Value, position3, new Rectangle?(), white, 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
        }
      }
      else if (context == 6)
      {
        Texture2D texture2D4 = TextureAssets.Trash.Value;
        Vector2 position4 = position + texture2D1.Size() * inventoryScale / 2f - texture2D4.Size() * inventoryScale / 2f;
        spriteBatch.Draw(texture2D4, position4, new Rectangle?(), new Color(100, 100, 100, 100), 0.0f, new Vector2(), inventoryScale, SpriteEffects.None, 0.0f);
      }
      if (context == 0 && slot < 10)
      {
        float num15 = inventoryScale;
        string text = string.Concat((object) (slot + 1));
        if (text == "10")
          text = "0";
        Color baseColor = Main.inventoryBack;
        int num16 = 0;
        if (Main.player[Main.myPlayer].selectedItem == slot)
        {
          baseColor = Color.White;
          baseColor.A = (byte) 200;
          num16 -= 2;
          float num17 = num15 * 1.4f;
        }
        ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, text, position + new Vector2(6f, (float) (4 + num16)) * inventoryScale, baseColor, 0.0f, Vector2.Zero, new Vector2(inventoryScale), spread: inventoryScale);
      }
      if (ID == -1)
        return;
      UILinkPointNavigator.SetPosition(ID, position + vector2 * 0.75f);
    }

    public static void MouseHover(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.MouseHover(ItemSlot.singleSlotArray, context);
      inv = ItemSlot.singleSlotArray[0];
    }

    public static void MouseHover(Item[] inv, int context = 0, int slot = 0)
    {
      if (context == 6 && Main.hoverItemName == null)
        Main.hoverItemName = Lang.inter[3].Value;
      if (inv[slot].type > 0 && inv[slot].stack > 0)
      {
        ItemSlot._customCurrencyForSavings = inv[slot].shopSpecialCurrency;
        Main.hoverItemName = inv[slot].Name;
        if (inv[slot].stack > 1)
          Main.hoverItemName = Main.hoverItemName + " (" + (object) inv[slot].stack + ")";
        Main.HoverItem = inv[slot].Clone();
        Main.HoverItem.tooltipContext = context;
        if (context == 8 && slot <= 2)
          Main.HoverItem.wornArmor = true;
        else if (context == 11 || context == 9)
        {
          Main.HoverItem.social = true;
        }
        else
        {
          if (context != 15)
            return;
          Main.HoverItem.buy = true;
        }
      }
      else
      {
        if (context == 10 || context == 11 || context == 24)
          Main.hoverItemName = Lang.inter[9].Value;
        if (context == 11)
          Main.hoverItemName = Lang.inter[11].Value + " " + Main.hoverItemName;
        if (context == 8 || context == 9 || context == 23 || context == 26)
        {
          if (slot == 0 || slot == 10 || context == 26)
            Main.hoverItemName = Lang.inter[12].Value;
          else if (slot == 1 || slot == 11)
            Main.hoverItemName = Lang.inter[13].Value;
          else if (slot == 2 || slot == 12)
            Main.hoverItemName = Lang.inter[14].Value;
          else if (slot >= 10)
            Main.hoverItemName = Lang.inter[11].Value + " " + Main.hoverItemName;
        }
        if (context == 12 || context == 25 || context == 27)
          Main.hoverItemName = Lang.inter[57].Value;
        if (context == 16)
          Main.hoverItemName = Lang.inter[90].Value;
        if (context == 17)
          Main.hoverItemName = Lang.inter[91].Value;
        if (context == 19)
          Main.hoverItemName = Lang.inter[92].Value;
        if (context == 18)
          Main.hoverItemName = Lang.inter[93].Value;
        if (context != 20)
          return;
        Main.hoverItemName = Lang.inter[94].Value;
      }
    }

    public static void SwapEquip(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      ItemSlot.SwapEquip(ItemSlot.singleSlotArray, context, 0);
      inv = ItemSlot.singleSlotArray[0];
    }

    public static void SwapEquip(Item[] inv, int context, int slot)
    {
      Player player = Main.player[Main.myPlayer];
      if (ItemSlot.isEquipLocked(inv[slot].type))
        return;
      if (inv[slot].dye > (byte) 0)
      {
        bool success;
        inv[slot] = ItemSlot.DyeSwap(inv[slot], out success);
        if (success)
        {
          Main.EquipPageSelected = 0;
          AchievementsHelper.HandleOnEquip(player, inv[slot], 12);
        }
      }
      else if (Main.projHook[inv[slot].shoot])
      {
        bool success;
        inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 4, out success);
        if (success)
        {
          Main.EquipPageSelected = 2;
          AchievementsHelper.HandleOnEquip(player, inv[slot], 16);
        }
      }
      else if (inv[slot].mountType != -1 && !MountID.Sets.Cart[inv[slot].mountType])
      {
        bool success;
        inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 3, out success);
        if (success)
        {
          Main.EquipPageSelected = 2;
          AchievementsHelper.HandleOnEquip(player, inv[slot], 17);
        }
      }
      else if (inv[slot].mountType != -1 && MountID.Sets.Cart[inv[slot].mountType])
      {
        bool success;
        inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 2, out success);
        if (success)
          Main.EquipPageSelected = 2;
      }
      else if (inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType])
      {
        bool success;
        inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 1, out success);
        if (success)
          Main.EquipPageSelected = 2;
      }
      else if (inv[slot].buffType > 0 && Main.vanityPet[inv[slot].buffType])
      {
        bool success;
        inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 0, out success);
        if (success)
          Main.EquipPageSelected = 2;
      }
      else
      {
        Item obj = inv[slot];
        bool success;
        inv[slot] = ItemSlot.ArmorSwap(inv[slot], out success);
        if (success)
        {
          Main.EquipPageSelected = 0;
          AchievementsHelper.HandleOnEquip(player, obj, obj.accessory ? 10 : 8);
        }
      }
      Recipe.FindRecipes();
      if (context != 3 || Main.netMode != 1)
        return;
      NetMessage.SendData(32, number: player.chest, number2: ((float) slot));
    }

    public static bool Equippable(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      int num = ItemSlot.Equippable(ItemSlot.singleSlotArray, context, 0) ? 1 : 0;
      inv = ItemSlot.singleSlotArray[0];
      return num != 0;
    }

    public static bool Equippable(Item[] inv, int context, int slot)
    {
      Player player = Main.player[Main.myPlayer];
      return inv[slot].dye > (byte) 0 || Main.projHook[inv[slot].shoot] || inv[slot].mountType != -1 || inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType] || inv[slot].buffType > 0 && Main.vanityPet[inv[slot].buffType] || inv[slot].headSlot >= 0 || inv[slot].bodySlot >= 0 || inv[slot].legSlot >= 0 || inv[slot].accessory;
    }

    private static bool AccCheck(Item[] itemCollection, Item item, int slot)
    {
      if (ItemSlot.isEquipLocked(item.type))
        return true;
      if (slot != -1 && (itemCollection[slot].IsTheSameAs(item) || itemCollection[slot].wingSlot > (sbyte) 0 && item.wingSlot > (sbyte) 0))
        return false;
      for (int index = 0; index < itemCollection.Length; ++index)
      {
        if (slot < 10 && index < 10 && (item.wingSlot > (sbyte) 0 && itemCollection[index].wingSlot > (sbyte) 0 || slot >= 10 && index >= 10 && item.wingSlot > (sbyte) 0 && itemCollection[index].wingSlot > (sbyte) 0) || item.IsTheSameAs(itemCollection[index]))
          return true;
      }
      return false;
    }

    private static Item DyeSwap(Item item, out bool success)
    {
      success = false;
      if (item.dye <= (byte) 0)
        return item;
      Player player = Main.player[Main.myPlayer];
      for (int index = 0; index < 10; ++index)
      {
        if (player.dye[index].type == 0)
        {
          ItemSlot.dyeSlotCount = index;
          break;
        }
      }
      if (ItemSlot.dyeSlotCount >= 10)
        ItemSlot.dyeSlotCount = 0;
      if (ItemSlot.dyeSlotCount < 0)
        ItemSlot.dyeSlotCount = 9;
      Item obj = player.dye[ItemSlot.dyeSlotCount].Clone();
      player.dye[ItemSlot.dyeSlotCount] = item.Clone();
      ++ItemSlot.dyeSlotCount;
      if (ItemSlot.dyeSlotCount >= 10)
        ItemSlot.accSlotToSwapTo = 0;
      SoundEngine.PlaySound(7);
      Recipe.FindRecipes();
      success = true;
      return obj;
    }

    private static Item ArmorSwap(Item item, out bool success)
    {
      success = false;
      if (item.headSlot == -1 && item.bodySlot == -1 && item.legSlot == -1 && !item.accessory)
        return item;
      Player player = Main.player[Main.myPlayer];
      int index1 = !item.vanity || item.accessory ? 0 : 10;
      item.favorited = false;
      Item obj = item;
      if (item.headSlot != -1)
      {
        obj = player.armor[index1].Clone();
        player.armor[index1] = item.Clone();
      }
      else if (item.bodySlot != -1)
      {
        obj = player.armor[index1 + 1].Clone();
        player.armor[index1 + 1] = item.Clone();
      }
      else if (item.legSlot != -1)
      {
        obj = player.armor[index1 + 2].Clone();
        player.armor[index1 + 2] = item.Clone();
      }
      else if (item.accessory)
      {
        int num = 3;
        for (int slot = 3; slot < 10; ++slot)
        {
          if (player.IsAValidEquipmentSlotForIteration(slot))
          {
            num = slot;
            if (player.armor[slot].type == 0)
            {
              ItemSlot.accSlotToSwapTo = slot - 3;
              break;
            }
          }
        }
        for (int index2 = 0; index2 < player.armor.Length; ++index2)
        {
          if (item.IsTheSameAs(player.armor[index2]))
            ItemSlot.accSlotToSwapTo = index2 - 3;
          if (index2 < 10 && item.wingSlot > (sbyte) 0 && player.armor[index2].wingSlot > (sbyte) 0)
            ItemSlot.accSlotToSwapTo = index2 - 3;
        }
        if (ItemSlot.accSlotToSwapTo > num)
          return item;
        if (ItemSlot.accSlotToSwapTo < 0)
          ItemSlot.accSlotToSwapTo = num - 3;
        int index3 = 3 + ItemSlot.accSlotToSwapTo;
        if (ItemSlot.isEquipLocked(player.armor[index3].type))
          return item;
        for (int index4 = 0; index4 < player.armor.Length; ++index4)
        {
          if (item.IsTheSameAs(player.armor[index4]))
            index3 = index4;
        }
        obj = player.armor[index3].Clone();
        player.armor[index3] = item.Clone();
        ItemSlot.accSlotToSwapTo = 0;
      }
      SoundEngine.PlaySound(7);
      Recipe.FindRecipes();
      success = true;
      return obj;
    }

    private static Item EquipSwap(Item item, Item[] inv, int slot, out bool success)
    {
      success = false;
      Player player = Main.player[Main.myPlayer];
      item.favorited = false;
      Item obj = inv[slot].Clone();
      inv[slot] = item.Clone();
      SoundEngine.PlaySound(7);
      Recipe.FindRecipes();
      success = true;
      return obj;
    }

    public static void DrawMoney(
      SpriteBatch sb,
      string text,
      float shopx,
      float shopy,
      int[] coinsArray,
      bool horizontal = false)
    {
      Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, text, shopx, shopy + 40f, Color.White * ((float) Main.mouseTextColor / (float) byte.MaxValue), Color.Black, Vector2.Zero);
      if (horizontal)
      {
        for (int index = 0; index < 4; ++index)
        {
          Main.instance.LoadItem(74 - index);
          if (index == 0)
          {
            int coins = coinsArray[3 - index];
          }
          Vector2 position = new Vector2((float) ((double) shopx + (double) ChatManager.GetStringSize(FontAssets.MouseText.Value, text, Vector2.One).X + (double) (24 * index) + 45.0), shopy + 50f);
          sb.Draw(TextureAssets.Item[74 - index].Value, position, new Rectangle?(), Color.White, 0.0f, TextureAssets.Item[74 - index].Value.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
          Utils.DrawBorderStringFourWay(sb, FontAssets.ItemStack.Value, coinsArray[3 - index].ToString(), position.X - 11f, position.Y, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
        }
      }
      else
      {
        for (int index = 0; index < 4; ++index)
        {
          Main.instance.LoadItem(74 - index);
          int num = index != 0 || coinsArray[3 - index] <= 99 ? 0 : -6;
          sb.Draw(TextureAssets.Item[74 - index].Value, new Vector2(shopx + 11f + (float) (24 * index), shopy + 75f), new Rectangle?(), Color.White, 0.0f, TextureAssets.Item[74 - index].Value.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
          Utils.DrawBorderStringFourWay(sb, FontAssets.ItemStack.Value, coinsArray[3 - index].ToString(), shopx + (float) (24 * index) + (float) num, shopy + 75f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
        }
      }
    }

    public static void DrawSavings(SpriteBatch sb, float shopx, float shopy, bool horizontal = false)
    {
      Player player = Main.player[Main.myPlayer];
      if (ItemSlot._customCurrencyForSavings != -1)
      {
        CustomCurrencyManager.DrawSavings(sb, ItemSlot._customCurrencyForSavings, shopx, shopy, horizontal);
      }
      else
      {
        bool overFlowing;
        long num1 = Utils.CoinsCount(out overFlowing, player.bank.item);
        long num2 = Utils.CoinsCount(out overFlowing, player.bank2.item);
        long num3 = Utils.CoinsCount(out overFlowing, player.bank3.item);
        long num4 = Utils.CoinsCount(out overFlowing, player.bank4.item);
        long count = Utils.CoinsCombineStacks(out overFlowing, num1, num2, num3, num4);
        if (count <= 0L)
          return;
        Main.instance.LoadItem(4076);
        Main.instance.LoadItem(3813);
        Main.instance.LoadItem(346);
        Main.instance.LoadItem(87);
        if (num4 > 0L)
          sb.Draw(TextureAssets.Item[4076].Value, Utils.CenteredRectangle(new Vector2(shopx + 92f, shopy + 45f), TextureAssets.Item[4076].Value.Size() * 0.65f), new Rectangle?(), Color.White);
        if (num3 > 0L)
          sb.Draw(TextureAssets.Item[3813].Value, Utils.CenteredRectangle(new Vector2(shopx + 92f, shopy + 45f), TextureAssets.Item[3813].Value.Size() * 0.65f), new Rectangle?(), Color.White);
        if (num2 > 0L)
          sb.Draw(TextureAssets.Item[346].Value, Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), TextureAssets.Item[346].Value.Size() * 0.65f), new Rectangle?(), Color.White);
        if (num1 > 0L)
          sb.Draw(TextureAssets.Item[87].Value, Utils.CenteredRectangle(new Vector2(shopx + 70f, shopy + 60f), TextureAssets.Item[87].Value.Size() * 0.65f), new Rectangle?(), Color.White);
        ItemSlot.DrawMoney(sb, Lang.inter[66].Value, shopx, shopy, Utils.CoinsSplit(count), horizontal);
      }
    }

    public static void GetItemLight(ref Color currentColor, Item item, bool outInTheWorld = false)
    {
      float scale = 1f;
      ItemSlot.GetItemLight(ref currentColor, ref scale, item, outInTheWorld);
    }

    public static void GetItemLight(ref Color currentColor, int type, bool outInTheWorld = false)
    {
      float scale = 1f;
      ItemSlot.GetItemLight(ref currentColor, ref scale, type, outInTheWorld);
    }

    public static void GetItemLight(
      ref Color currentColor,
      ref float scale,
      Item item,
      bool outInTheWorld = false)
    {
      ItemSlot.GetItemLight(ref currentColor, ref scale, item.type, outInTheWorld);
    }

    public static Color GetItemLight(
      ref Color currentColor,
      ref float scale,
      int type,
      bool outInTheWorld = false)
    {
      if (type < 0 || type > 5045)
        return currentColor;
      if (type == 662 || type == 663)
      {
        currentColor.R = (byte) Main.DiscoR;
        currentColor.G = (byte) Main.DiscoG;
        currentColor.B = (byte) Main.DiscoB;
        currentColor.A = byte.MaxValue;
      }
      else if (ItemID.Sets.ItemIconPulse[type])
      {
        scale = Main.essScale;
        currentColor.R = (byte) ((double) currentColor.R * (double) scale);
        currentColor.G = (byte) ((double) currentColor.G * (double) scale);
        currentColor.B = (byte) ((double) currentColor.B * (double) scale);
        currentColor.A = (byte) ((double) currentColor.A * (double) scale);
      }
      else if (type == 58 || type == 184 || type == 4143)
      {
        scale = (float) ((double) Main.essScale * 0.25 + 0.75);
        currentColor.R = (byte) ((double) currentColor.R * (double) scale);
        currentColor.G = (byte) ((double) currentColor.G * (double) scale);
        currentColor.B = (byte) ((double) currentColor.B * (double) scale);
        currentColor.A = (byte) ((double) currentColor.A * (double) scale);
      }
      return currentColor;
    }

    public static void DrawRadialCircular(SpriteBatch sb, Vector2 position)
    {
      ItemSlot.CircularRadialOpacity = MathHelper.Clamp(ItemSlot.CircularRadialOpacity + (!PlayerInput.UsingGamepad || !PlayerInput.Triggers.Current.RadialHotbar ? -0.15f : 0.25f), 0.0f, 1f);
      if ((double) ItemSlot.CircularRadialOpacity == 0.0)
        return;
      Player player = Main.player[Main.myPlayer];
      Texture2D texture2D1 = TextureAssets.HotbarRadial[2].Value;
      float num1 = ItemSlot.CircularRadialOpacity * 0.9f;
      float num2 = ItemSlot.CircularRadialOpacity * 1f;
      float num3 = (float) Main.mouseTextColor / (float) byte.MaxValue;
      Color color = Color.White * ((float) (1.0 - (1.0 - (double) num3) * (1.0 - (double) num3)) * 0.785f) * num1;
      Texture2D texture2D2 = TextureAssets.HotbarRadial[1].Value;
      float num4 = 6.283185f / (float) player.CircularRadial.RadialCount;
      float num5 = -1.570796f;
      for (int index = 0; index < player.CircularRadial.RadialCount; ++index)
      {
        int binding = player.CircularRadial.Bindings[index];
        Vector2 vector2 = new Vector2(150f, 0.0f).RotatedBy((double) num5 + (double) num4 * (double) index) * num2;
        float num6 = 0.85f;
        if (player.CircularRadial.SelectedBinding == index)
          num6 = 1.7f;
        sb.Draw(texture2D2, position + vector2, new Rectangle?(), color * num6, 0.0f, texture2D2.Size() / 2f, num2 * num6, SpriteEffects.None, 0.0f);
        if (binding != -1)
        {
          double inventoryScale = (double) Main.inventoryScale;
          Main.inventoryScale = num2 * num6;
          ItemSlot.Draw(sb, player.inventory, 14, binding, position + vector2 + new Vector2(-26f * num2 * num6), Color.White);
          Main.inventoryScale = (float) inventoryScale;
        }
      }
    }

    public static void DrawRadialQuicks(SpriteBatch sb, Vector2 position)
    {
      ItemSlot.QuicksRadialOpacity = MathHelper.Clamp(ItemSlot.QuicksRadialOpacity + (!PlayerInput.UsingGamepad || !PlayerInput.Triggers.Current.RadialQuickbar ? -0.15f : 0.25f), 0.0f, 1f);
      if ((double) ItemSlot.QuicksRadialOpacity == 0.0)
        return;
      Player player = Main.player[Main.myPlayer];
      Texture2D texture2D = TextureAssets.HotbarRadial[2].Value;
      Texture2D texture = TextureAssets.QuicksIcon.Value;
      float num1 = ItemSlot.QuicksRadialOpacity * 0.9f;
      float num2 = ItemSlot.QuicksRadialOpacity * 1f;
      float num3 = (float) Main.mouseTextColor / (float) byte.MaxValue;
      Color color = Color.White * ((float) (1.0 - (1.0 - (double) num3) * (1.0 - (double) num3)) * 0.785f) * num1;
      float num4 = 6.283185f / (float) player.QuicksRadial.RadialCount;
      float num5 = -1.570796f;
      Item obj1 = player.QuickHeal_GetItemToUse();
      Item obj2 = player.QuickMana_GetItemToUse();
      Item obj3 = (Item) null;
      Item obj4 = (Item) null;
      if (obj1 == null)
      {
        obj1 = new Item();
        obj1.SetDefaults(28);
      }
      if (obj2 == null)
      {
        obj2 = new Item();
        obj2.SetDefaults(110);
      }
      if (obj3 == null)
      {
        obj3 = new Item();
        obj3.SetDefaults(292);
      }
      if (obj4 == null)
      {
        obj4 = new Item();
        obj4.SetDefaults(2428);
      }
      for (int index = 0; index < player.QuicksRadial.RadialCount; ++index)
      {
        Item inv = obj4;
        if (index == 1)
          inv = obj1;
        if (index == 2)
          inv = obj3;
        if (index == 3)
          inv = obj2;
        int binding = player.QuicksRadial.Bindings[index];
        Vector2 vector2 = new Vector2(120f, 0.0f).RotatedBy((double) num5 + (double) num4 * (double) index) * num2;
        float num6 = 0.85f;
        if (player.QuicksRadial.SelectedBinding == index)
          num6 = 1.7f;
        sb.Draw(texture2D, position + vector2, new Rectangle?(), color * num6, 0.0f, texture2D.Size() / 2f, (float) ((double) num2 * (double) num6 * 1.29999995231628), SpriteEffects.None, 0.0f);
        double inventoryScale = (double) Main.inventoryScale;
        Main.inventoryScale = num2 * num6;
        ItemSlot.Draw(sb, ref inv, 14, position + vector2 + new Vector2(-26f * num2 * num6), Color.White);
        Main.inventoryScale = (float) inventoryScale;
        sb.Draw(texture, position + vector2 + new Vector2(34f, 20f) * 0.85f * num2 * num6, new Rectangle?(), color * num6, 0.0f, texture2D.Size() / 2f, (float) ((double) num2 * (double) num6 * 1.29999995231628), SpriteEffects.None, 0.0f);
      }
    }

    public static void DrawRadialDpad(SpriteBatch sb, Vector2 position)
    {
      if (!PlayerInput.UsingGamepad || !PlayerInput.CurrentProfile.UsingDpadHotbar())
        return;
      Player player = Main.player[Main.myPlayer];
      if (player.chest != -1)
        return;
      Texture2D texture2D = TextureAssets.HotbarRadial[0].Value;
      float num = (float) Main.mouseTextColor / (float) byte.MaxValue;
      Color color = Color.White * ((float) (1.0 - (1.0 - (double) num) * (1.0 - (double) num)) * 0.785f);
      sb.Draw(texture2D, position, new Rectangle?(), color, 0.0f, texture2D.Size() / 2f, Main.inventoryScale, SpriteEffects.None, 0.0f);
      for (int index = 0; index < 4; ++index)
      {
        int binding = player.DpadRadial.Bindings[index];
        if (binding != -1)
          ItemSlot.Draw(sb, player.inventory, 14, binding, position + new Vector2((float) (texture2D.Width / 3), 0.0f).RotatedBy(1.57079637050629 * (double) index - 1.57079637050629) + new Vector2(-26f * Main.inventoryScale), Color.White);
      }
    }

    public static string GetGamepadInstructions(ref Item inv, int context = 0)
    {
      ItemSlot.singleSlotArray[0] = inv;
      string gamepadInstructions = ItemSlot.GetGamepadInstructions(ItemSlot.singleSlotArray, context);
      inv = ItemSlot.singleSlotArray[0];
      return gamepadInstructions;
    }

    public static string GetGamepadInstructions(Item[] inv, int context = 0, int slot = 0)
    {
      Player player = Main.player[Main.myPlayer];
      string s = "";
      if (inv == null || inv[slot] == null || Main.mouseItem == null)
        return s;
      if (context == 0 || context == 1 || context == 2)
      {
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          string str;
          if (Main.mouseItem.type > 0)
          {
            str = s + PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
            if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
              str += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
          }
          else
          {
            if (context == 0 && player.chest == -1)
              player.DpadRadial.ChangeBinding(slot);
            str = s + PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
            if (inv[slot].maxStack > 1)
              str += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
          }
          if (inv[slot].maxStack == 1 && ItemSlot.Equippable(inv, context, slot))
          {
            str += PlayerInput.BuildCommand(Lang.misc[67].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
            if (PlayerInput.Triggers.JustPressed.Grapple)
              ItemSlot.SwapEquip(inv, context, slot);
          }
          s = str + PlayerInput.BuildCommand(Lang.misc[83].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartCursor"]);
          if (PlayerInput.Triggers.JustPressed.SmartCursor)
            inv[slot].favorited = !inv[slot].favorited;
        }
        else if (Main.mouseItem.type > 0)
          s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
      }
      if (context == 3 || context == 4)
      {
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          if (Main.mouseItem.type > 0)
          {
            s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
            if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
              s += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
          }
          else
          {
            s += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
            if (inv[slot].maxStack > 1)
              s += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
          }
          if (inv[slot].maxStack == 1 && ItemSlot.Equippable(inv, context, slot))
          {
            s += PlayerInput.BuildCommand(Lang.misc[67].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
            if (PlayerInput.Triggers.JustPressed.Grapple)
              ItemSlot.SwapEquip(inv, context, slot);
          }
        }
        else if (Main.mouseItem.type > 0)
          s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
      }
      if (context == 15)
      {
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          if (Main.mouseItem.type > 0)
          {
            if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
              s += PlayerInput.BuildCommand(Lang.misc[91].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
          }
          else
            s += PlayerInput.BuildCommand(Lang.misc[90].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"], PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
        }
        else if (Main.mouseItem.type > 0)
          s += PlayerInput.BuildCommand(Lang.misc[92].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
      }
      if (context == 8 || context == 9 || context == 16 || context == 17 || context == 18 || context == 19 || context == 20)
      {
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          if (Main.mouseItem.type > 0)
          {
            if (ItemSlot.Equippable(ref Main.mouseItem, context))
              s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          }
          else if (context != 8 || !ItemSlot.isEquipLocked(inv[slot].type))
            s += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          if (context == 8 && slot >= 3)
          {
            bool flag = player.hideVisibleAccessory[slot];
            s += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
            if (PlayerInput.Triggers.JustPressed.Grapple)
            {
              player.hideVisibleAccessory[slot] = !player.hideVisibleAccessory[slot];
              SoundEngine.PlaySound(12);
              if (Main.netMode == 1)
                NetMessage.SendData(4, number: Main.myPlayer);
            }
          }
          if ((context == 16 || context == 17 || context == 18 || context == 19 || context == 20) && slot < 2)
          {
            bool flag = player.hideMisc[slot];
            s += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
            if (PlayerInput.Triggers.JustPressed.Grapple)
            {
              player.hideMisc[slot] = !player.hideMisc[slot];
              SoundEngine.PlaySound(12);
              if (Main.netMode == 1)
                NetMessage.SendData(4, number: Main.myPlayer);
            }
          }
        }
        else
        {
          if (Main.mouseItem.type > 0 && ItemSlot.Equippable(ref Main.mouseItem, context))
            s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          if (context == 8 && slot >= 3)
          {
            bool flag = player.hideVisibleAccessory[slot];
            s += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
            if (PlayerInput.Triggers.JustPressed.Grapple)
            {
              player.hideVisibleAccessory[slot] = !player.hideVisibleAccessory[slot];
              SoundEngine.PlaySound(12);
              if (Main.netMode == 1)
                NetMessage.SendData(4, number: Main.myPlayer);
            }
          }
          if ((context == 16 || context == 17 || context == 18 || context == 19 || context == 20) && slot < 2)
          {
            bool flag = player.hideMisc[slot];
            s += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
            if (PlayerInput.Triggers.JustPressed.Grapple)
            {
              if (slot == 0)
                player.TogglePet();
              if (slot == 1)
                player.ToggleLight();
              Main.mouseLeftRelease = false;
              SoundEngine.PlaySound(12);
              if (Main.netMode == 1)
                NetMessage.SendData(4, number: Main.myPlayer);
            }
          }
        }
      }
      if (context == 12 || context == 25 || context == 27)
      {
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          if (Main.mouseItem.type > 0)
          {
            if (Main.mouseItem.dye > (byte) 0)
              s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          }
          else
            s += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          if (context == 12 || context == 25 || context == 27)
          {
            int num = -1;
            if (inv == player.dye)
              num = slot;
            if (inv == player.miscDyes)
              num = 10 + slot;
            if (num != -1)
            {
              if (num < 10)
              {
                bool flag = player.hideVisibleAccessory[slot];
                s += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
                if (PlayerInput.Triggers.JustPressed.Grapple)
                {
                  player.hideVisibleAccessory[slot] = !player.hideVisibleAccessory[slot];
                  SoundEngine.PlaySound(12);
                  if (Main.netMode == 1)
                    NetMessage.SendData(4, number: Main.myPlayer);
                }
              }
              else
              {
                bool flag = player.hideMisc[slot];
                s += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
                if (PlayerInput.Triggers.JustPressed.Grapple)
                {
                  player.hideMisc[slot] = !player.hideMisc[slot];
                  SoundEngine.PlaySound(12);
                  if (Main.netMode == 1)
                    NetMessage.SendData(4, number: Main.myPlayer);
                }
              }
            }
          }
        }
        else if (Main.mouseItem.type > 0 && Main.mouseItem.dye > (byte) 0)
          s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
        return s;
      }
      if (context == 6)
      {
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          if (Main.mouseItem.type > 0)
            s += PlayerInput.BuildCommand(Lang.misc[74].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          else
            s += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
        }
        else if (Main.mouseItem.type > 0)
          s += PlayerInput.BuildCommand(Lang.misc[74].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
        return s;
      }
      if (context == 5 || context == 7)
      {
        bool flag = false;
        if (context == 5)
          flag = Main.mouseItem.Prefix(-3) || Main.mouseItem.type == 0;
        if (context == 7)
          flag = Main.mouseItem.material;
        if (inv[slot].type > 0 && inv[slot].stack > 0)
        {
          if (Main.mouseItem.type > 0)
          {
            if (flag)
              s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
          }
          else
            s += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
        }
        else if (Main.mouseItem.type > 0 & flag)
          s += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
        return s;
      }
      string overrideInstructions = ItemSlot.GetOverrideInstructions(inv, context, slot);
      bool flag1 = Main.mouseItem.type > 0 && (context == 0 || context == 1 || context == 2 || context == 6 || context == 15 || context == 7 || context == 4 || context == 3);
      if (context != 8 || !ItemSlot.isEquipLocked(inv[slot].type))
      {
        if (flag1 && string.IsNullOrEmpty(overrideInstructions))
        {
          s += PlayerInput.BuildCommand(Lang.inter[121].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]);
          if (PlayerInput.Triggers.JustPressed.SmartSelect)
            player.DropSelectedItem();
        }
        else if (!string.IsNullOrEmpty(overrideInstructions))
        {
          ItemSlot.ShiftForcedOn = true;
          int cursorOverride = Main.cursorOverride;
          ItemSlot.OverrideHover(inv, context, slot);
          if (-1 != Main.cursorOverride)
          {
            s += PlayerInput.BuildCommand(overrideInstructions, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]);
            if (PlayerInput.Triggers.JustPressed.SmartSelect)
            {
              int num = Main.mouseLeft ? 1 : 0;
              Main.mouseLeft = true;
              ItemSlot.LeftClick(inv, context, slot);
              Main.mouseLeft = num != 0;
            }
          }
          Main.cursorOverride = cursorOverride;
          ItemSlot.ShiftForcedOn = false;
        }
      }
      if (!ItemSlot.TryEnteringFastUseMode(inv, context, slot, player, ref s))
        ItemSlot.TryEnteringBuildingMode(inv, context, slot, player, ref s);
      return s;
    }

    private static bool TryEnteringFastUseMode(
      Item[] inv,
      int context,
      int slot,
      Player player,
      ref string s)
    {
      int num = 0;
      if (Main.mouseItem.CanBeQuickUsed)
        num = 1;
      if (num == 0 && Main.mouseItem.stack <= 0 && context == 0 && inv[slot].CanBeQuickUsed)
        num = 2;
      if (num <= 0)
        return false;
      s += PlayerInput.BuildCommand(Language.GetTextValue("UI.QuickUseItem"), false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]);
      if (PlayerInput.Triggers.JustPressed.QuickMount)
      {
        switch (num)
        {
          case 1:
            PlayerInput.TryEnteringFastUseModeForMouseItem();
            break;
          case 2:
            PlayerInput.TryEnteringFastUseModeForInventorySlot(slot);
            break;
        }
      }
      return true;
    }

    private static bool TryEnteringBuildingMode(
      Item[] inv,
      int context,
      int slot,
      Player player,
      ref string s)
    {
      int num = 0;
      if (ItemSlot.IsABuildingItem(Main.mouseItem))
        num = 1;
      if (num == 0 && Main.mouseItem.stack <= 0 && context == 0 && ItemSlot.IsABuildingItem(inv[slot]))
        num = 2;
      if (num > 0)
      {
        Item mouseItem = Main.mouseItem;
        if (num == 1)
          mouseItem = Main.mouseItem;
        if (num == 2)
          mouseItem = inv[slot];
        if (num != 1 || player.ItemSpace(mouseItem).CanTakeItemToPersonalInventory)
        {
          if (mouseItem.damage > 0 && mouseItem.ammo == 0)
            s += PlayerInput.BuildCommand(Lang.misc[60].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]);
          else if (mouseItem.createTile >= 0 || mouseItem.createWall > 0)
            s += PlayerInput.BuildCommand(Lang.misc[61].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]);
          else
            s += PlayerInput.BuildCommand(Lang.misc[63].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]);
          if (PlayerInput.Triggers.JustPressed.QuickMount)
            PlayerInput.EnterBuildingMode();
          return true;
        }
      }
      return false;
    }

    public static bool IsABuildingItem(Item item) => item.type > 0 && item.stack > 0 && item.useStyle != 0 && item.useTime > 0;

    public static void SelectEquipPage(Item item)
    {
      Main.EquipPage = -1;
      if (item.IsAir)
        return;
      if (Main.projHook[item.shoot])
        Main.EquipPage = 2;
      else if (item.mountType != -1)
        Main.EquipPage = 2;
      else if (item.buffType > 0 && Main.vanityPet[item.buffType])
        Main.EquipPage = 2;
      else if (item.buffType > 0 && Main.lightPet[item.buffType])
        Main.EquipPage = 2;
      else if (item.dye > (byte) 0 && Main.EquipPageSelected == 1)
      {
        Main.EquipPage = 0;
      }
      else
      {
        if (item.legSlot == -1 && item.headSlot == -1 && item.bodySlot == -1 && !item.accessory)
          return;
        Main.EquipPage = 0;
      }
    }

    public class Options
    {
      public static bool DisableLeftShiftTrashCan = true;
      public static bool HighlightNewItems = true;
    }

    public class Context
    {
      public const int InventoryItem = 0;
      public const int InventoryCoin = 1;
      public const int InventoryAmmo = 2;
      public const int ChestItem = 3;
      public const int BankItem = 4;
      public const int PrefixItem = 5;
      public const int TrashItem = 6;
      public const int GuideItem = 7;
      public const int EquipArmor = 8;
      public const int EquipArmorVanity = 9;
      public const int EquipAccessory = 10;
      public const int EquipAccessoryVanity = 11;
      public const int EquipDye = 12;
      public const int HotbarItem = 13;
      public const int ChatItem = 14;
      public const int ShopItem = 15;
      public const int EquipGrapple = 16;
      public const int EquipMount = 17;
      public const int EquipMinecart = 18;
      public const int EquipPet = 19;
      public const int EquipLight = 20;
      public const int MouseItem = 21;
      public const int CraftingMaterial = 22;
      public const int DisplayDollArmor = 23;
      public const int DisplayDollAccessory = 24;
      public const int DisplayDollDye = 25;
      public const int HatRackHat = 26;
      public const int HatRackDye = 27;
      public const int GoldDebug = 28;
      public const int CreativeInfinite = 29;
      public const int CreativeSacrifice = 30;
      public const int Count = 31;
    }
  }
}
