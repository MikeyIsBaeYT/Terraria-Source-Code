// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionIntTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Social;

namespace Terraria.Achievements
{
  public class ConditionIntTracker : AchievementTracker<int>
  {
    public ConditionIntTracker()
      : base(TrackerType.Int)
    {
    }

    public ConditionIntTracker(int maxValue)
      : base(TrackerType.Int)
    {
      this._maxValue = maxValue;
    }

    public override void ReportUpdate()
    {
      if (SocialAPI.Achievements == null || this._name == null)
        return;
      SocialAPI.Achievements.UpdateIntStat(this._name, this._value);
    }

    protected override void Load()
    {
    }
  }
}
