// Decompiled with JetBrains decompiler
// Type: Terraria.RecipeGroup
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria
{
  public class RecipeGroup
  {
    public Func<string> GetText;
    public List<int> ValidItems;
    public int IconicItemIndex;
    public static Dictionary<int, RecipeGroup> recipeGroups = new Dictionary<int, RecipeGroup>();
    public static Dictionary<string, int> recipeGroupIDs = new Dictionary<string, int>();
    public static int nextRecipeGroupIndex = 0;

    public RecipeGroup(Func<string> getName, params int[] validItems)
    {
      this.GetText = getName;
      this.ValidItems = new List<int>((IEnumerable<int>) validItems);
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
