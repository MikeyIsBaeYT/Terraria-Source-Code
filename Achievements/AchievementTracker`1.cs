// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.AchievementTracker`1
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Social;

namespace Terraria.Achievements
{
  public abstract class AchievementTracker<T> : IAchievementTracker
  {
    protected T _value;
    protected T _maxValue;
    protected string _name;
    private TrackerType _type;

    public T Value => this._value;

    public T MaxValue => this._maxValue;

    protected AchievementTracker(TrackerType type) => this._type = type;

    void IAchievementTracker.ReportAs(string name) => this._name = name;

    TrackerType IAchievementTracker.GetTrackerType() => this._type;

    void IAchievementTracker.Clear() => this.SetValue(default (T));

    public void SetValue(T newValue, bool reportUpdate = true)
    {
      if (newValue.Equals((object) this._value))
        return;
      this._value = newValue;
      if (!reportUpdate)
        return;
      this.ReportUpdate();
      if (!this._value.Equals((object) this._maxValue))
        return;
      this.OnComplete();
    }

    public abstract void ReportUpdate();

    protected abstract void Load();

    void IAchievementTracker.Load() => this.Load();

    protected void OnComplete()
    {
      if (SocialAPI.Achievements == null)
        return;
      SocialAPI.Achievements.StoreStats();
    }
  }
}
