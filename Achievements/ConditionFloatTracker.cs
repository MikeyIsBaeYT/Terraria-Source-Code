// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionFloatTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Social;

namespace Terraria.Achievements
{
  public class ConditionFloatTracker : AchievementTracker<float>
  {
    public ConditionFloatTracker(float maxValue)
      : base(TrackerType.Float)
    {
      this._maxValue = maxValue;
    }

    public ConditionFloatTracker()
      : base(TrackerType.Float)
    {
    }

    public override void ReportUpdate()
    {
      if (SocialAPI.Achievements == null || this._name == null)
        return;
      SocialAPI.Achievements.UpdateFloatStat(this._name, this._value);
    }

    protected override void Load()
    {
    }
  }
}
