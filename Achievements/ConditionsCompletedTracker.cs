// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionsCompletedTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria.Achievements
{
  public class ConditionsCompletedTracker : ConditionIntTracker
  {
    private List<AchievementCondition> _conditions = new List<AchievementCondition>();

    public void AddCondition(AchievementCondition condition)
    {
      ++this._maxValue;
      condition.OnComplete += new AchievementCondition.AchievementUpdate(this.OnConditionCompleted);
      this._conditions.Add(condition);
    }

    private void OnConditionCompleted(AchievementCondition condition) => this.SetValue(Math.Min(this._value + 1, this._maxValue));

    protected override void Load()
    {
      for (int index = 0; index < this._conditions.Count; ++index)
      {
        if (this._conditions[index].IsCompleted)
          ++this._value;
      }
    }
  }
}
