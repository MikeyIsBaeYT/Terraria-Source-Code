// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Achievements.ItemCraftCondition
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
  public class ItemCraftCondition : AchievementCondition
  {
    private const string Identifier = "ITEM_PICKUP";
    private static Dictionary<short, List<ItemCraftCondition>> _listeners = new Dictionary<short, List<ItemCraftCondition>>();
    private static bool _isListenerHooked = false;
    private short[] _itemIds;

    private ItemCraftCondition(short itemId)
      : base("ITEM_PICKUP_" + (object) itemId)
    {
      this._itemIds = new short[1]{ itemId };
      ItemCraftCondition.ListenForCraft(this);
    }

    private ItemCraftCondition(short[] itemIds)
      : base("ITEM_PICKUP_" + (object) itemIds[0])
    {
      this._itemIds = itemIds;
      ItemCraftCondition.ListenForCraft(this);
    }

    private static void ListenForCraft(ItemCraftCondition condition)
    {
      if (!ItemCraftCondition._isListenerHooked)
      {
        AchievementsHelper.OnItemCraft += new AchievementsHelper.ItemCraftEvent(ItemCraftCondition.ItemCraftListener);
        ItemCraftCondition._isListenerHooked = true;
      }
      for (int index = 0; index < condition._itemIds.Length; ++index)
      {
        if (!ItemCraftCondition._listeners.ContainsKey(condition._itemIds[index]))
          ItemCraftCondition._listeners[condition._itemIds[index]] = new List<ItemCraftCondition>();
        ItemCraftCondition._listeners[condition._itemIds[index]].Add(condition);
      }
    }

    private static void ItemCraftListener(short itemId, int count)
    {
      if (!ItemCraftCondition._listeners.ContainsKey(itemId))
        return;
      foreach (AchievementCondition achievementCondition in ItemCraftCondition._listeners[itemId])
        achievementCondition.Complete();
    }

    public static AchievementCondition Create(params short[] items) => (AchievementCondition) new ItemCraftCondition(items);

    public static AchievementCondition Create(short item) => (AchievementCondition) new ItemCraftCondition(item);

    public static AchievementCondition[] CreateMany(params short[] items)
    {
      AchievementCondition[] achievementConditionArray = new AchievementCondition[items.Length];
      for (int index = 0; index < items.Length; ++index)
        achievementConditionArray[index] = (AchievementCondition) new ItemCraftCondition(items[index]);
      return achievementConditionArray;
    }
  }
}
