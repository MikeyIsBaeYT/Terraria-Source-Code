// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Achievements.CustomFloatCondition
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
  public class CustomFloatCondition : AchievementCondition
  {
    [JsonProperty("Value")]
    private float _value;
    private float _maxValue;

    public float Value
    {
      get => this._value;
      set
      {
        float newValue = Utils.Clamp<float>(value, 0.0f, this._maxValue);
        if (this._tracker != null)
          ((AchievementTracker<float>) this._tracker).SetValue(newValue);
        this._value = newValue;
        if ((double) this._value != (double) this._maxValue)
          return;
        this.Complete();
      }
    }

    private CustomFloatCondition(string name, float maxValue)
      : base(name)
    {
      this._maxValue = maxValue;
      this._value = 0.0f;
    }

    public override void Clear()
    {
      this._value = 0.0f;
      base.Clear();
    }

    public override void Load(JObject state)
    {
      base.Load(state);
      this._value = JToken.op_Explicit(state["Value"]);
      if (this._tracker == null)
        return;
      ((AchievementTracker<float>) this._tracker).SetValue(this._value, false);
    }

    protected override IAchievementTracker CreateAchievementTracker() => (IAchievementTracker) new ConditionFloatTracker(this._maxValue);

    public static AchievementCondition Create(string name, float maxValue) => (AchievementCondition) new CustomFloatCondition(name, maxValue);
  }
}
