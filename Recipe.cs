// Decompiled with JetBrains decompiler
// Type: Terraria.Recipe
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.GameContent.Achievements;
using Terraria.ID;

namespace Terraria
{
  public class Recipe
  {
    public static int maxRequirements = 15;
    public static int maxRecipes = 2000;
    public static int numRecipes = 0;
    private static Recipe newRecipe = new Recipe();
    public Item createItem = new Item();
    public Item[] requiredItem = new Item[Recipe.maxRequirements];
    public int[] requiredTile = new int[Recipe.maxRequirements];
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
    public List<int> acceptedGroups = new List<int>();

    public void RequireGroup(string name)
    {
      int num;
      if (!RecipeGroup.recipeGroupIDs.TryGetValue(name, out num))
        return;
      this.acceptedGroups.Add(num);
    }

    public bool ProcessGroupsForText(int type, out string theText)
    {
      foreach (int acceptedGroup in this.acceptedGroups)
      {
        if (RecipeGroup.recipeGroups[acceptedGroup].ValidItems.Contains(type))
        {
          theText = RecipeGroup.recipeGroups[acceptedGroup].GetText();
          return true;
        }
      }
      theText = "";
      return false;
    }

    public bool AcceptedByItemGroups(int invType, int reqType)
    {
      foreach (int acceptedGroup in this.acceptedGroups)
      {
        if (RecipeGroup.recipeGroups[acceptedGroup].ValidItems.Contains(invType) && RecipeGroup.recipeGroups[acceptedGroup].ValidItems.Contains(reqType))
          return true;
      }
      return false;
    }

    public Recipe()
    {
      for (int index = 0; index < Recipe.maxRequirements; ++index)
      {
        this.requiredItem[index] = new Item();
        this.requiredTile[index] = -1;
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

    public bool useSand(int invType, int reqType) => (reqType == 169 || reqType == 408 || reqType == 1246 || reqType == 370 || reqType == 3272) && this.anySand && (invType == 169 || invType == 408 || invType == 1246 || invType == 370 || invType == 3272);

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
          switch (invType)
          {
            case 529:
            case 541:
            case 542:
            case 543:
            case 852:
            case 853:
            case 1151:
              return true;
            default:
              return false;
          }
        default:
          return false;
      }
    }

    public static void FindRecipes()
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
          for (int index = 0; index < 40; ++index)
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
            int num3 = !Main.recipe[index3].needWater ? 1 : (Main.player[Main.myPlayer].adjWater ? 1 : (Main.player[Main.myPlayer].adjTile[172] ? 1 : 0));
            bool flag3 = !Main.recipe[index3].needHoney || Main.recipe[index3].needHoney == Main.player[Main.myPlayer].adjHoney;
            bool flag4 = !Main.recipe[index3].needLava || Main.recipe[index3].needLava == Main.player[Main.myPlayer].adjLava;
            bool flag5 = !Main.recipe[index3].needSnowBiome || Main.player[Main.myPlayer].ZoneSnow;
            int num4 = flag3 ? 1 : 0;
            if ((num3 & num4 & (flag4 ? 1 : 0) & (flag5 ? 1 : 0)) == 0)
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
    }

    public static void SetupRecipes()
    {
      // ISSUE: The method is too long to display (51538 instructions)
    }

    private static void PlatformReturn()
    {
      int numRecipes = Recipe.numRecipes;
      for (int index1 = 0; index1 < numRecipes; ++index1)
      {
        if (Main.recipe[index1].createItem.createTile >= 0 && TileID.Sets.Platforms[Main.recipe[index1].createItem.createTile] && Main.recipe[index1].requiredItem[1].type == 0)
        {
          Recipe.newRecipe.createItem.SetDefaults(Main.recipe[index1].requiredItem[0].type);
          Recipe.newRecipe.createItem.stack = Main.recipe[index1].requiredItem[0].stack;
          Recipe.newRecipe.requiredItem[0].SetDefaults(Main.recipe[index1].createItem.type);
          Recipe.newRecipe.requiredItem[0].stack = Main.recipe[index1].createItem.stack;
          for (int index2 = 0; index2 < Recipe.newRecipe.requiredTile.Length; ++index2)
            Recipe.newRecipe.requiredTile[index2] = Main.recipe[index1].requiredTile[index2];
          Recipe.AddRecipe();
          Recipe recipe = Main.recipe[Recipe.numRecipes - 1];
          for (int index3 = Recipe.numRecipes - 2; index3 > index1; --index3)
            Main.recipe[index3 + 1] = Main.recipe[index3];
          Main.recipe[index1 + 1] = recipe;
        }
      }
    }

    private static void WallReturn()
    {
      int numRecipes = Recipe.numRecipes;
      for (int index1 = 0; index1 < numRecipes; ++index1)
      {
        if (Main.recipe[index1].createItem.createWall > 0 && Main.recipe[index1].requiredItem[1].type == 0 && Main.recipe[index1].requiredItem[0].createWall == -1)
        {
          Recipe.newRecipe.createItem.SetDefaults(Main.recipe[index1].requiredItem[0].type);
          Recipe.newRecipe.createItem.stack = Main.recipe[index1].requiredItem[0].stack;
          Recipe.newRecipe.requiredItem[0].SetDefaults(Main.recipe[index1].createItem.type);
          Recipe.newRecipe.requiredItem[0].stack = Main.recipe[index1].createItem.stack;
          for (int index2 = 0; index2 < Recipe.newRecipe.requiredTile.Length; ++index2)
            Recipe.newRecipe.requiredTile[index2] = Main.recipe[index1].requiredTile[index2];
          Recipe.AddRecipe();
          Recipe recipe = Main.recipe[Recipe.numRecipes - 1];
          for (int index3 = Recipe.numRecipes - 2; index3 > index1; --index3)
            Main.recipe[index3 + 1] = Main.recipe[index3];
          Main.recipe[index1 + 1] = recipe;
        }
      }
    }

    private static void AddRecipe()
    {
      if (Recipe.newRecipe.requiredTile[0] == 13)
        Recipe.newRecipe.alchemy = true;
      Main.recipe[Recipe.numRecipes] = Recipe.newRecipe;
      Recipe.newRecipe = new Recipe();
      ++Recipe.numRecipes;
    }
  }
}
