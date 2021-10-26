// Decompiled with JetBrains decompiler
// Type: Terraria.Recipe
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria
{
  public class Recipe
  {
    public static int maxRequirements = 15;
    public static int maxRecipes = 3000;
    public static int numRecipes;
    private static Recipe currentRecipe = new Recipe();
    public Item createItem = new Item();
    public Item[] requiredItem = new Item[Recipe.maxRequirements];
    public int[] requiredTile = new int[Recipe.maxRequirements];
    public int[] acceptedGroups = new int[Recipe.maxRequirements];
    public bool needHoney;
    public bool needWater;
    public bool needLava;
    public bool anyWood;
    public bool anyIronBar;
    public bool anyPressurePlate;
    public bool anySand;
    public bool anyFragment;
    public bool alchemy;
    public bool needSnowBiome;
    public bool needGraveyardBiome;
    private static bool _hasDelayedFindRecipes;

    public void RequireGroup(string name)
    {
      int num;
      if (!RecipeGroup.recipeGroupIDs.TryGetValue(name, out num))
        return;
      for (int index = 0; index < Recipe.maxRequirements; ++index)
      {
        if (this.acceptedGroups[index] == -1)
        {
          this.acceptedGroups[index] = num;
          break;
        }
      }
    }

    public void RequireGroup(int id)
    {
      for (int index = 0; index < Recipe.maxRequirements; ++index)
      {
        if (this.acceptedGroups[index] == -1)
        {
          this.acceptedGroups[index] = id;
          break;
        }
      }
    }

    public bool ProcessGroupsForText(int type, out string theText)
    {
      for (int index = 0; index < Recipe.maxRequirements; ++index)
      {
        int acceptedGroup = this.acceptedGroups[index];
        if (acceptedGroup != -1)
        {
          if (RecipeGroup.recipeGroups[acceptedGroup].ValidItems.Contains(type))
          {
            theText = RecipeGroup.recipeGroups[acceptedGroup].GetText();
            return true;
          }
        }
        else
          break;
      }
      theText = "";
      return false;
    }

    public bool AcceptedByItemGroups(int invType, int reqType)
    {
      for (int index = 0; index < Recipe.maxRequirements; ++index)
      {
        int acceptedGroup = this.acceptedGroups[index];
        if (acceptedGroup != -1)
        {
          if (RecipeGroup.recipeGroups[acceptedGroup].ValidItems.Contains(invType) && RecipeGroup.recipeGroups[acceptedGroup].ValidItems.Contains(reqType))
            return true;
        }
        else
          break;
      }
      return false;
    }

    public Recipe()
    {
      for (int index = 0; index < Recipe.maxRequirements; ++index)
      {
        this.requiredItem[index] = new Item();
        this.requiredTile[index] = -1;
        this.acceptedGroups[index] = -1;
      }
    }

    public void Create()
    {
      for (int index1 = 0; index1 < Recipe.maxRequirements; ++index1)
      {
        Item compareItem = this.requiredItem[index1];
        if (compareItem.type != 0)
        {
          int num1 = compareItem.stack;
          if (this.alchemy && Main.player[Main.myPlayer].alchemyTable)
          {
            if (num1 > 1)
            {
              int num2 = 0;
              for (int index2 = 0; index2 < num1; ++index2)
              {
                if (Main.rand.Next(3) == 0)
                  ++num2;
              }
              num1 -= num2;
            }
            else if (Main.rand.Next(3) == 0)
              num1 = 0;
          }
          if (num1 > 0)
          {
            Item[] inventory = Main.player[Main.myPlayer].inventory;
            for (int index3 = 0; index3 < 58; ++index3)
            {
              Item obj = inventory[index3];
              if (num1 > 0)
              {
                if (obj.IsTheSameAs(compareItem) || this.useWood(obj.type, compareItem.type) || this.useSand(obj.type, compareItem.type) || this.useFragment(obj.type, compareItem.type) || this.useIronBar(obj.type, compareItem.type) || this.usePressurePlate(obj.type, compareItem.type) || this.AcceptedByItemGroups(obj.type, compareItem.type))
                {
                  if (obj.stack > num1)
                  {
                    obj.stack -= num1;
                    num1 = 0;
                  }
                  else
                  {
                    num1 -= obj.stack;
                    inventory[index3] = new Item();
                  }
                }
              }
              else
                break;
            }
            if (Main.player[Main.myPlayer].chest != -1)
            {
              if (Main.player[Main.myPlayer].chest > -1)
                inventory = Main.chest[Main.player[Main.myPlayer].chest].item;
              else if (Main.player[Main.myPlayer].chest == -2)
                inventory = Main.player[Main.myPlayer].bank.item;
              else if (Main.player[Main.myPlayer].chest == -3)
                inventory = Main.player[Main.myPlayer].bank2.item;
              else if (Main.player[Main.myPlayer].chest == -4)
                inventory = Main.player[Main.myPlayer].bank3.item;
              else if (Main.player[Main.myPlayer].chest == -5)
                inventory = Main.player[Main.myPlayer].bank4.item;
              for (int index4 = 0; index4 < 40; ++index4)
              {
                Item obj = inventory[index4];
                if (num1 > 0)
                {
                  if (obj.IsTheSameAs(compareItem) || this.useWood(obj.type, compareItem.type) || this.useSand(obj.type, compareItem.type) || this.useIronBar(obj.type, compareItem.type) || this.usePressurePlate(obj.type, compareItem.type) || this.useFragment(obj.type, compareItem.type) || this.AcceptedByItemGroups(obj.type, compareItem.type))
                  {
                    if (obj.stack > num1)
                    {
                      obj.stack -= num1;
                      if (Main.netMode == 1 && Main.player[Main.myPlayer].chest >= 0)
                        NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index4));
                      num1 = 0;
                    }
                    else
                    {
                      num1 -= obj.stack;
                      inventory[index4] = new Item();
                      if (Main.netMode == 1 && Main.player[Main.myPlayer].chest >= 0)
                        NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index4));
                    }
                  }
                }
                else
                  break;
              }
            }
          }
        }
        else
          break;
      }
      AchievementsHelper.NotifyItemCraft(this);
      AchievementsHelper.NotifyItemPickup(Main.player[Main.myPlayer], this.createItem);
      Recipe.FindRecipes();
    }

    public bool useWood(int invType, int reqType)
    {
      if (!this.anyWood)
        return false;
      switch (reqType)
      {
        case 9:
        case 619:
        case 620:
        case 621:
        case 911:
        case 1729:
        case 2503:
        case 2504:
          switch (invType)
          {
            case 9:
            case 619:
            case 620:
            case 621:
            case 911:
            case 1729:
            case 2503:
            case 2504:
              return true;
            default:
              return false;
          }
        default:
          return false;
      }
    }

    public bool useIronBar(int invType, int reqType) => this.anyIronBar && (reqType == 22 || reqType == 704) && (invType == 22 || invType == 704);

    public bool useSand(int invType, int reqType) => (reqType == 169 || reqType == 408 || reqType == 1246 || reqType == 370 || reqType == 3272 || reqType == 3338 || reqType == 3274 || reqType == 3275) && this.anySand && (invType == 169 || invType == 408 || invType == 1246 || invType == 370 || invType == 3272 || invType == 3338 || invType == 3274 || invType == 3275);

    public bool useFragment(int invType, int reqType) => (reqType == 3458 || reqType == 3456 || reqType == 3457 || reqType == 3459) && this.anyFragment && (invType == 3458 || invType == 3456 || invType == 3457 || invType == 3459);

    public bool usePressurePlate(int invType, int reqType)
    {
      if (!this.anyPressurePlate)
        return false;
      switch (reqType)
      {
        case 529:
        case 541:
        case 542:
        case 543:
        case 852:
        case 853:
        case 1151:
        case 4261:
          switch (invType)
          {
            case 529:
            case 541:
            case 542:
            case 543:
            case 852:
            case 853:
            case 1151:
            case 4261:
              return true;
            default:
              return false;
          }
        default:
          return false;
      }
    }

    public static void GetThroughDelayedFindRecipes()
    {
      if (!Recipe._hasDelayedFindRecipes)
        return;
      Recipe._hasDelayedFindRecipes = false;
      Recipe.FindRecipes();
    }

    public static void FindRecipes(bool canDelayCheck = false)
    {
      if (canDelayCheck)
      {
        Recipe._hasDelayedFindRecipes = true;
      }
      else
      {
        int num1 = Main.availableRecipe[Main.focusRecipe];
        float num2 = Main.availableRecipeY[Main.focusRecipe];
        for (int index = 0; index < Recipe.maxRecipes; ++index)
          Main.availableRecipe[index] = 0;
        Main.numAvailableRecipes = 0;
        if ((Main.guideItem.type <= 0 || Main.guideItem.stack <= 0 ? 0 : (Main.guideItem.Name != "" ? 1 : 0)) != 0)
        {
          for (int index1 = 0; index1 < Recipe.maxRecipes && Main.recipe[index1].createItem.type != 0; ++index1)
          {
            for (int index2 = 0; index2 < Recipe.maxRequirements && Main.recipe[index1].requiredItem[index2].type != 0; ++index2)
            {
              if (Main.guideItem.IsTheSameAs(Main.recipe[index1].requiredItem[index2]) || Main.recipe[index1].useWood(Main.guideItem.type, Main.recipe[index1].requiredItem[index2].type) || Main.recipe[index1].useSand(Main.guideItem.type, Main.recipe[index1].requiredItem[index2].type) || Main.recipe[index1].useIronBar(Main.guideItem.type, Main.recipe[index1].requiredItem[index2].type) || Main.recipe[index1].useFragment(Main.guideItem.type, Main.recipe[index1].requiredItem[index2].type) || Main.recipe[index1].AcceptedByItemGroups(Main.guideItem.type, Main.recipe[index1].requiredItem[index2].type) || Main.recipe[index1].usePressurePlate(Main.guideItem.type, Main.recipe[index1].requiredItem[index2].type))
              {
                Main.availableRecipe[Main.numAvailableRecipes] = index1;
                ++Main.numAvailableRecipes;
                break;
              }
            }
          }
        }
        else
        {
          Dictionary<int, int> dictionary = new Dictionary<int, int>();
          Item[] inventory = Main.player[Main.myPlayer].inventory;
          for (int index = 0; index < 58; ++index)
          {
            Item obj = inventory[index];
            if (obj.stack > 0)
            {
              if (dictionary.ContainsKey(obj.netID))
                dictionary[obj.netID] += obj.stack;
              else
                dictionary[obj.netID] = obj.stack;
            }
          }
          if (Main.player[Main.myPlayer].chest != -1)
          {
            if (Main.player[Main.myPlayer].chest > -1)
              inventory = Main.chest[Main.player[Main.myPlayer].chest].item;
            else if (Main.player[Main.myPlayer].chest == -2)
              inventory = Main.player[Main.myPlayer].bank.item;
            else if (Main.player[Main.myPlayer].chest == -3)
              inventory = Main.player[Main.myPlayer].bank2.item;
            else if (Main.player[Main.myPlayer].chest == -4)
              inventory = Main.player[Main.myPlayer].bank3.item;
            else if (Main.player[Main.myPlayer].chest == -5)
              inventory = Main.player[Main.myPlayer].bank4.item;
            for (int index = 0; index < 40; ++index)
            {
              Item obj = inventory[index];
              if (obj != null && obj.stack > 0)
              {
                if (dictionary.ContainsKey(obj.netID))
                  dictionary[obj.netID] += obj.stack;
                else
                  dictionary[obj.netID] = obj.stack;
              }
            }
          }
          for (int index3 = 0; index3 < Recipe.maxRecipes && Main.recipe[index3].createItem.type != 0; ++index3)
          {
            bool flag1 = true;
            if (flag1)
            {
              for (int index4 = 0; index4 < Recipe.maxRequirements && Main.recipe[index3].requiredTile[index4] != -1; ++index4)
              {
                if (!Main.player[Main.myPlayer].adjTile[Main.recipe[index3].requiredTile[index4]])
                {
                  flag1 = false;
                  break;
                }
              }
            }
            if (flag1)
            {
              for (int index5 = 0; index5 < Recipe.maxRequirements; ++index5)
              {
                Item obj = Main.recipe[index3].requiredItem[index5];
                if (obj.type != 0)
                {
                  int stack = obj.stack;
                  bool flag2 = false;
                  foreach (int key in dictionary.Keys)
                  {
                    if (Main.recipe[index3].useWood(key, obj.type) || Main.recipe[index3].useSand(key, obj.type) || Main.recipe[index3].useIronBar(key, obj.type) || Main.recipe[index3].useFragment(key, obj.type) || Main.recipe[index3].AcceptedByItemGroups(key, obj.type) || Main.recipe[index3].usePressurePlate(key, obj.type))
                    {
                      stack -= dictionary[key];
                      flag2 = true;
                    }
                  }
                  if (!flag2 && dictionary.ContainsKey(obj.netID))
                    stack -= dictionary[obj.netID];
                  if (stack > 0)
                  {
                    flag1 = false;
                    break;
                  }
                }
                else
                  break;
              }
            }
            if (flag1)
            {
              int num3 = !Main.recipe[index3].needWater || Main.player[Main.myPlayer].adjWater ? 1 : (Main.player[Main.myPlayer].adjTile[172] ? 1 : 0);
              bool flag3 = !Main.recipe[index3].needHoney || Main.recipe[index3].needHoney == Main.player[Main.myPlayer].adjHoney;
              bool flag4 = !Main.recipe[index3].needLava || Main.recipe[index3].needLava == Main.player[Main.myPlayer].adjLava;
              bool flag5 = !Main.recipe[index3].needSnowBiome || Main.player[Main.myPlayer].ZoneSnow;
              bool flag6 = !Main.recipe[index3].needGraveyardBiome || Main.player[Main.myPlayer].ZoneGraveyard;
              int num4 = flag3 ? 1 : 0;
              if ((num3 & num4 & (flag4 ? 1 : 0) & (flag5 ? 1 : 0) & (flag6 ? 1 : 0)) == 0)
                flag1 = false;
            }
            if (flag1)
            {
              Main.availableRecipe[Main.numAvailableRecipes] = index3;
              ++Main.numAvailableRecipes;
            }
          }
        }
        for (int index = 0; index < Main.numAvailableRecipes; ++index)
        {
          if (num1 == Main.availableRecipe[index])
          {
            Main.focusRecipe = index;
            break;
          }
        }
        if (Main.focusRecipe >= Main.numAvailableRecipes)
          Main.focusRecipe = Main.numAvailableRecipes - 1;
        if (Main.focusRecipe < 0)
          Main.focusRecipe = 0;
        float num5 = Main.availableRecipeY[Main.focusRecipe] - num2;
        for (int index = 0; index < Recipe.maxRecipes; ++index)
          Main.availableRecipeY[index] -= num5;
      }
    }

    public static void SetupRecipeGroups()
    {
      RecipeGroupID.Birds = RecipeGroup.RegisterGroup("Birds", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.GetNPCNameValue(74)), new int[3]
      {
        2015,
        2016,
        2017
      }));
      RecipeGroupID.Scorpions = RecipeGroup.RegisterGroup("Scorpions", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.GetNPCNameValue(367)), new int[2]
      {
        2157,
        2156
      }));
      RecipeGroupID.Squirrels = RecipeGroup.RegisterGroup("Squirrels", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.GetNPCNameValue(299)), new int[2]
      {
        2018,
        3563
      }));
      RecipeGroupID.Bugs = RecipeGroup.RegisterGroup("Bugs", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.misc[85].Value), new int[3]
      {
        3194,
        3192,
        3193
      }));
      RecipeGroupID.Ducks = RecipeGroup.RegisterGroup("Ducks", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.misc[86].Value), new int[2]
      {
        2123,
        2122
      }));
      RecipeGroupID.Butterflies = RecipeGroup.RegisterGroup("Butterflies", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.misc[87].Value), new int[8]
      {
        1998,
        2001,
        1994,
        1995,
        1996,
        1999,
        1997,
        2000
      }));
      RecipeGroupID.Fireflies = RecipeGroup.RegisterGroup("Fireflies", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.misc[88].Value), new int[2]
      {
        1992,
        2004
      }));
      RecipeGroupID.Snails = RecipeGroup.RegisterGroup("Snails", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.misc[95].Value), new int[2]
      {
        2006,
        2007
      }));
      RecipeGroupID.Dragonflies = RecipeGroup.RegisterGroup("Dragonflies", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.misc[105].Value), new int[6]
      {
        4334,
        4335,
        4336,
        4338,
        4339,
        4337
      }));
      RecipeGroupID.Turtles = RecipeGroup.RegisterGroup("Turtles", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Lang.GetNPCNameValue(616)), new int[2]
      {
        4464,
        4465
      }));
      RecipeGroupID.Fruit = RecipeGroup.RegisterGroup("Fruit", new RecipeGroup((Func<string>) (() => Lang.misc[37].Value + " " + Language.GetTextValue("Misc.Fruit")), new int[17]
      {
        4009,
        4282,
        4283,
        4284,
        4285,
        4286,
        4287,
        4288,
        4289,
        4290,
        4291,
        4292,
        4293,
        4294,
        4295,
        4296,
        4297
      }));
    }

    public static void SetupRecipes()
    {
      // ISSUE: The method is too long to display (57289 instructions)
    }

    private static void UpdateMaterialFieldForAllRecipes()
    {
      for (int index1 = 0; index1 < Recipe.numRecipes; ++index1)
      {
        for (int index2 = 0; Main.recipe[index1].requiredItem[index2].type > 0; ++index2)
          Main.recipe[index1].requiredItem[index2].material = ItemID.Sets.IsAMaterial[Main.recipe[index1].requiredItem[index2].type];
        Main.recipe[index1].createItem.material = ItemID.Sets.IsAMaterial[Main.recipe[index1].createItem.type];
      }
    }

    public static void UpdateWhichItemsAreMaterials()
    {
      for (int Type = 0; Type < 5045; ++Type)
      {
        Item obj = new Item();
        obj.SetDefaults(Type, true);
        obj.checkMat();
        ItemID.Sets.IsAMaterial[Type] = obj.material;
      }
    }

    private static void AddSolarFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4229);
      Recipe.currentRecipe.createItem.stack = 10;
      Recipe.currentRecipe.SetIngridients(3, 10, 3458, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4233);
      Recipe.currentRecipe.createItem.stack = 4;
      Recipe.currentRecipe.SetIngridients(4229, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4145);
      Recipe.currentRecipe.SetIngridients(4229, 14);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4146);
      Recipe.currentRecipe.SetIngridients(4229, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4147);
      Recipe.currentRecipe.SetIngridients(4229, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4148);
      Recipe.currentRecipe.SetIngridients(4229, 16);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4149);
      Recipe.currentRecipe.SetIngridients(4229, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4150);
      Recipe.currentRecipe.SetIngridients(4229, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4151);
      Recipe.currentRecipe.SetIngridients(4229, 4);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4152);
      Recipe.currentRecipe.SetIngridients(4229, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4153);
      Recipe.currentRecipe.SetIngridients(4229, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4154);
      Recipe.currentRecipe.SetIngridients(4229, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4155);
      Recipe.currentRecipe.SetIngridients(4229, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4156);
      Recipe.currentRecipe.SetIngridients(8, 1, 4229, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4157);
      Recipe.currentRecipe.SetIngridients(4229, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4158);
      Recipe.currentRecipe.SetIngridients(4229, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4160);
      Recipe.currentRecipe.SetIngridients(4229, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4161);
      Recipe.currentRecipe.SetIngridients(4229, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4162);
      Recipe.currentRecipe.SetIngridients(4229, 8);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4163);
      Recipe.currentRecipe.SetIngridients(4229, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4165);
      Recipe.currentRecipe.SetIngridients(4229, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
    }

    private static void AddVortexFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4230);
      Recipe.currentRecipe.createItem.stack = 10;
      Recipe.currentRecipe.SetIngridients(3, 10, 3456, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4234);
      Recipe.currentRecipe.createItem.stack = 4;
      Recipe.currentRecipe.SetIngridients(4230, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4166);
      Recipe.currentRecipe.SetIngridients(4230, 14);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4167);
      Recipe.currentRecipe.SetIngridients(4230, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4168);
      Recipe.currentRecipe.SetIngridients(4230, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4169);
      Recipe.currentRecipe.SetIngridients(4230, 16);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4170);
      Recipe.currentRecipe.SetIngridients(4230, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4171);
      Recipe.currentRecipe.SetIngridients(4230, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4172);
      Recipe.currentRecipe.SetIngridients(4230, 4);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4173);
      Recipe.currentRecipe.SetIngridients(4230, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4174);
      Recipe.currentRecipe.SetIngridients(4230, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4175);
      Recipe.currentRecipe.SetIngridients(4230, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4176);
      Recipe.currentRecipe.SetIngridients(4230, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4177);
      Recipe.currentRecipe.SetIngridients(8, 1, 4230, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4178);
      Recipe.currentRecipe.SetIngridients(4230, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4179);
      Recipe.currentRecipe.SetIngridients(4230, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4181);
      Recipe.currentRecipe.SetIngridients(4230, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4182);
      Recipe.currentRecipe.SetIngridients(4230, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4183);
      Recipe.currentRecipe.SetIngridients(4230, 8);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4184);
      Recipe.currentRecipe.SetIngridients(4230, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4186);
      Recipe.currentRecipe.SetIngridients(4230, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
    }

    private static void AddNebulaFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4231);
      Recipe.currentRecipe.createItem.stack = 10;
      Recipe.currentRecipe.SetIngridients(3, 10, 3457, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4235);
      Recipe.currentRecipe.createItem.stack = 4;
      Recipe.currentRecipe.SetIngridients(4231, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4187);
      Recipe.currentRecipe.SetIngridients(4231, 14);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4188);
      Recipe.currentRecipe.SetIngridients(4231, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4189);
      Recipe.currentRecipe.SetIngridients(4231, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4190);
      Recipe.currentRecipe.SetIngridients(4231, 16);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4191);
      Recipe.currentRecipe.SetIngridients(4231, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4192);
      Recipe.currentRecipe.SetIngridients(4231, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4193);
      Recipe.currentRecipe.SetIngridients(4231, 4);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4194);
      Recipe.currentRecipe.SetIngridients(4231, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4195);
      Recipe.currentRecipe.SetIngridients(4231, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4196);
      Recipe.currentRecipe.SetIngridients(4231, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4197);
      Recipe.currentRecipe.SetIngridients(4231, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4198);
      Recipe.currentRecipe.SetIngridients(8, 1, 4231, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4199);
      Recipe.currentRecipe.SetIngridients(4231, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4200);
      Recipe.currentRecipe.SetIngridients(4231, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4202);
      Recipe.currentRecipe.SetIngridients(4231, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4203);
      Recipe.currentRecipe.SetIngridients(4231, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4204);
      Recipe.currentRecipe.SetIngridients(4231, 8);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4205);
      Recipe.currentRecipe.SetIngridients(4231, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4207);
      Recipe.currentRecipe.SetIngridients(4231, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
    }

    private static void AddStardustFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4232);
      Recipe.currentRecipe.createItem.stack = 10;
      Recipe.currentRecipe.SetIngridients(3, 10, 3459, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4236);
      Recipe.currentRecipe.createItem.stack = 4;
      Recipe.currentRecipe.SetIngridients(4232, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4208);
      Recipe.currentRecipe.SetIngridients(4232, 14);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4209);
      Recipe.currentRecipe.SetIngridients(4232, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4210);
      Recipe.currentRecipe.SetIngridients(4232, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4211);
      Recipe.currentRecipe.SetIngridients(4232, 16);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4212);
      Recipe.currentRecipe.SetIngridients(4232, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4213);
      Recipe.currentRecipe.SetIngridients(4232, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4214);
      Recipe.currentRecipe.SetIngridients(4232, 4);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4215);
      Recipe.currentRecipe.SetIngridients(4232, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4216);
      Recipe.currentRecipe.SetIngridients(4232, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4217);
      Recipe.currentRecipe.SetIngridients(4232, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4218);
      Recipe.currentRecipe.SetIngridients(4232, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4219);
      Recipe.currentRecipe.SetIngridients(8, 1, 4232, 3);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4220);
      Recipe.currentRecipe.SetIngridients(4232, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4221);
      Recipe.currentRecipe.SetIngridients(4232, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4223);
      Recipe.currentRecipe.SetIngridients(4232, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4224);
      Recipe.currentRecipe.SetIngridients(4232, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4225);
      Recipe.currentRecipe.SetIngridients(4232, 8);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4226);
      Recipe.currentRecipe.SetIngridients(4232, 10);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4228);
      Recipe.currentRecipe.SetIngridients(4232, 6);
      Recipe.currentRecipe.SetCraftingStation(412);
      Recipe.AddRecipe();
    }

    private static void AddSpiderFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4139);
      Recipe.currentRecipe.createItem.stack = 10;
      Recipe.currentRecipe.SetIngridients(150, 10, 2607, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4140);
      Recipe.currentRecipe.createItem.stack = 4;
      Recipe.currentRecipe.SetIngridients(4139, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3931);
      Recipe.currentRecipe.SetIngridients(4139, 14);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3932);
      Recipe.currentRecipe.SetIngridients(4139, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3933);
      Recipe.currentRecipe.SetIngridients(4139, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3934);
      Recipe.currentRecipe.SetIngridients(4139, 16);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3935);
      Recipe.currentRecipe.SetIngridients(4139, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3936);
      Recipe.currentRecipe.SetIngridients(4139, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3937);
      Recipe.currentRecipe.SetIngridients(4139, 4);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3938);
      Recipe.currentRecipe.SetIngridients(4139, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(16);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3939);
      Recipe.currentRecipe.SetIngridients(4139, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3940);
      Recipe.currentRecipe.SetIngridients(4139, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3941);
      Recipe.currentRecipe.SetIngridients(4139, 6);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3942);
      Recipe.currentRecipe.SetIngridients(8, 1, 4139, 3);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3943);
      Recipe.currentRecipe.SetIngridients(4139, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3944);
      Recipe.currentRecipe.SetIngridients(4139, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3946);
      Recipe.currentRecipe.SetIngridients(4139, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3947);
      Recipe.currentRecipe.SetIngridients(4139, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3948);
      Recipe.currentRecipe.SetIngridients(4139, 8);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3949);
      Recipe.currentRecipe.SetIngridients(4139, 10);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4125);
      Recipe.currentRecipe.SetIngridients(4139, 6);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
    }

    private static void AddLesionFurniture()
    {
      int num = 3955;
      Recipe.currentRecipe.createItem.SetDefaults(3955);
      Recipe.currentRecipe.SetIngridients(61, 2);
      Recipe.currentRecipe.SetCraftingStation(218);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3975);
      Recipe.currentRecipe.SetIngridients(num, 10);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3956);
      Recipe.currentRecipe.createItem.stack = 4;
      Recipe.currentRecipe.SetIngridients(3955, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3967);
      Recipe.currentRecipe.SetIngridients(num, 6);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3963);
      Recipe.currentRecipe.SetIngridients(num, 4);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3965);
      Recipe.currentRecipe.SetIngridients(num, 8, 22, 2);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3974);
      Recipe.currentRecipe.SetIngridients(num, 8);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3972);
      Recipe.currentRecipe.SetIngridients(num, 6, 206, 1);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3970);
      Recipe.currentRecipe.SetIngridients(num, 6, 8, 1);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3962);
      Recipe.currentRecipe.SetIngridients(num, 4, 8, 1);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3969);
      Recipe.currentRecipe.SetIngridients(num, 3, 8, 1);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3961);
      Recipe.currentRecipe.SetIngridients(num, 5, 8, 3);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3959);
      Recipe.currentRecipe.SetIngridients(num, 15, 225, 5);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3968);
      Recipe.currentRecipe.SetIngridients(num, 16);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3960);
      Recipe.currentRecipe.SetIngridients(num, 20, 149, 10);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3966);
      Recipe.currentRecipe.SetIngridients(22, 3, 170, 6, num, 10);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3973);
      Recipe.currentRecipe.SetIngridients(num, 5, 225, 2);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3971);
      Recipe.currentRecipe.SetIngridients(154, 4, num, 15, 149, 1);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3958);
      Recipe.currentRecipe.SetIngridients(num, 14);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(3964);
      Recipe.currentRecipe.SetIngridients(num, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.anyWood = true;
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4126);
      Recipe.currentRecipe.SetIngridients(3955, 6);
      Recipe.currentRecipe.SetCraftingStation(499);
      Recipe.AddRecipe();
    }

    private static void AddSandstoneFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4720);
      Recipe.currentRecipe.createItem.stack = 2;
      Recipe.currentRecipe.SetIngridients(4051, 1);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4298);
      Recipe.currentRecipe.SetIngridients(4051, 14);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4299);
      Recipe.currentRecipe.SetIngridients(4051, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4300);
      Recipe.currentRecipe.SetIngridients(4051, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4301);
      Recipe.currentRecipe.SetIngridients(4051, 16);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4302);
      Recipe.currentRecipe.SetIngridients(4051, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4303);
      Recipe.currentRecipe.SetIngridients(4051, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4304);
      Recipe.currentRecipe.SetIngridients(4051, 4);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4305);
      Recipe.currentRecipe.SetIngridients(4051, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(16);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4267);
      Recipe.currentRecipe.SetIngridients(4051, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4306);
      Recipe.currentRecipe.SetIngridients(4051, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4307);
      Recipe.currentRecipe.SetIngridients(4051, 6);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4308);
      Recipe.currentRecipe.SetIngridients(8, 1, 4051, 3);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4309);
      Recipe.currentRecipe.SetIngridients(4051, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4310);
      Recipe.currentRecipe.SetIngridients(4051, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4312);
      Recipe.currentRecipe.SetIngridients(4051, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4313);
      Recipe.currentRecipe.SetIngridients(4051, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4314);
      Recipe.currentRecipe.SetIngridients(4051, 8);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4315);
      Recipe.currentRecipe.SetIngridients(4051, 10);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4316);
      Recipe.currentRecipe.SetIngridients(4051, 6);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
    }

    private static void AddBambooFurniture()
    {
      Recipe.currentRecipe.createItem.SetDefaults(4566);
      Recipe.currentRecipe.SetIngridients(4564, 14);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4567);
      Recipe.currentRecipe.SetIngridients(4564, 15, 225, 5);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4568);
      Recipe.currentRecipe.SetIngridients(4564, 20, 149, 10);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4569);
      Recipe.currentRecipe.SetIngridients(4564, 16);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4570);
      Recipe.currentRecipe.SetIngridients(4564, 5, 8, 3);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4571);
      Recipe.currentRecipe.SetIngridients(4564, 4, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4572);
      Recipe.currentRecipe.SetIngridients(4564, 4);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4573);
      Recipe.currentRecipe.SetIngridients(4564, 4, 8, 4, 85, 1);
      Recipe.currentRecipe.SetCraftingStation(16);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4574);
      Recipe.currentRecipe.SetIngridients(4564, 8, 22, 2);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4575);
      Recipe.currentRecipe.SetIngridients(4564, 10, 22, 3, 170, 6);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.currentRecipe.anyIronBar = true;
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4576);
      Recipe.currentRecipe.SetIngridients(4564, 6);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4577);
      Recipe.currentRecipe.SetIngridients(8, 1, 4564, 3);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4578);
      Recipe.currentRecipe.SetIngridients(4564, 6, 8, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4579);
      Recipe.currentRecipe.SetIngridients(4564, 15, 154, 4, 149, 1);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4581);
      Recipe.currentRecipe.SetIngridients(4564, 6, 206, 1);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4582);
      Recipe.currentRecipe.SetIngridients(4564, 5, 225, 2);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4583);
      Recipe.currentRecipe.SetIngridients(4564, 8);
      Recipe.currentRecipe.SetCraftingStation(18);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4584);
      Recipe.currentRecipe.SetIngridients(4564, 10);
      Recipe.AddRecipe();
      Recipe.currentRecipe.createItem.SetDefaults(4586);
      Recipe.currentRecipe.SetIngridients(4564, 6);
      Recipe.currentRecipe.SetCraftingStation(106);
      Recipe.AddRecipe();
    }

    private static void CreateReversePlatformRecipes()
    {
      int numRecipes = Recipe.numRecipes;
      for (int index1 = 0; index1 < numRecipes; ++index1)
      {
        if (Main.recipe[index1].createItem.createTile >= 0 && TileID.Sets.Platforms[Main.recipe[index1].createItem.createTile] && Main.recipe[index1].requiredItem[1].type == 0)
        {
          Recipe.currentRecipe.createItem.SetDefaults(Main.recipe[index1].requiredItem[0].type);
          Recipe.currentRecipe.createItem.stack = Main.recipe[index1].requiredItem[0].stack;
          Recipe.currentRecipe.requiredItem[0].SetDefaults(Main.recipe[index1].createItem.type);
          Recipe.currentRecipe.requiredItem[0].stack = Main.recipe[index1].createItem.stack;
          for (int index2 = 0; index2 < Recipe.currentRecipe.requiredTile.Length; ++index2)
            Recipe.currentRecipe.requiredTile[index2] = Main.recipe[index1].requiredTile[index2];
          Recipe.AddRecipe();
          Recipe recipe = Main.recipe[Recipe.numRecipes - 1];
          for (int index3 = Recipe.numRecipes - 2; index3 > index1; --index3)
            Main.recipe[index3 + 1] = Main.recipe[index3];
          Main.recipe[index1 + 1] = recipe;
        }
      }
    }

    private static void CreateReverseWallRecipes()
    {
      int numRecipes = Recipe.numRecipes;
      for (int index1 = 0; index1 < numRecipes; ++index1)
      {
        if (Main.recipe[index1].createItem.createWall > 0 && Main.recipe[index1].requiredItem[1].type == 0 && Main.recipe[index1].requiredItem[0].createWall == -1)
        {
          Recipe.currentRecipe.createItem.SetDefaults(Main.recipe[index1].requiredItem[0].type);
          Recipe.currentRecipe.createItem.stack = Main.recipe[index1].requiredItem[0].stack;
          Recipe.currentRecipe.requiredItem[0].SetDefaults(Main.recipe[index1].createItem.type);
          Recipe.currentRecipe.requiredItem[0].stack = Main.recipe[index1].createItem.stack;
          for (int index2 = 0; index2 < Recipe.currentRecipe.requiredTile.Length; ++index2)
            Recipe.currentRecipe.requiredTile[index2] = Main.recipe[index1].requiredTile[index2];
          Recipe.AddRecipe();
          Recipe recipe = Main.recipe[Recipe.numRecipes - 1];
          for (int index3 = Recipe.numRecipes - 2; index3 > index1; --index3)
            Main.recipe[index3 + 1] = Main.recipe[index3];
          Main.recipe[index1 + 1] = recipe;
        }
      }
    }

    public void SetIngridients(params int[] ingridients)
    {
      if (ingridients.Length == 1)
        ingridients = new int[2]{ ingridients[0], 1 };
      if (ingridients.Length % 2 != 0)
        throw new Exception("Bad ingridients amount");
      for (int index1 = 0; index1 < ingridients.Length; index1 += 2)
      {
        int index2 = index1 / 2;
        this.requiredItem[index2].SetDefaults(ingridients[index1]);
        this.requiredItem[index2].stack = ingridients[index1 + 1];
      }
    }

    public void SetCraftingStation(params int[] tileIDs)
    {
      for (int index = 0; index < tileIDs.Length; ++index)
        this.requiredTile[index] = tileIDs[index];
    }

    private static void AddRecipe()
    {
      if (Recipe.currentRecipe.requiredTile[0] == 13)
        Recipe.currentRecipe.alchemy = true;
      Main.recipe[Recipe.numRecipes] = Recipe.currentRecipe;
      Recipe.currentRecipe = new Recipe();
      ++Recipe.numRecipes;
    }

    public static int GetRequiredTileStyle(int tileID) => tileID == 26 && WorldGen.crimson ? 1 : 0;
  }
}
