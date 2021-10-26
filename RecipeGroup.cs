// Decompiled with JetBrains decompiler
// Type: Terraria.RecipeGroup
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria
{
  public class RecipeGroup
  {
    public Func<string> GetText;
    public HashSet<int> ValidItems;
    public int IconicItemId;
    public static Dictionary<int, RecipeGroup> recipeGroups = new Dictionary<int, RecipeGroup>();
    public static Dictionary<string, int> recipeGroupIDs = new Dictionary<string, int>();
    public static int nextRecipeGroupIndex;

    public RecipeGroup(Func<string> getName, params int[] validItems)
    {
      this.GetText = getName;
      this.ValidItems = new HashSet<int>((IEnumerable<int>) validItems);
      this.IconicItemId = validItems[0];
    }

    public static int RegisterGroup(string name, RecipeGroup rec)
    {
      int key = RecipeGroup.nextRecipeGroupIndex++;
      RecipeGroup.recipeGroups.Add(key, rec);
      RecipeGroup.recipeGroupIDs.Add(name, key);
      return key;
    }
  }
}
