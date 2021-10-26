// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.WellFedHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent
{
  public struct WellFedHelper
  {
    private const int MAXIMUM_TIME_LEFT_PER_COUNTER = 72000;
    private int _timeLeftRank1;
    private int _timeLeftRank2;
    private int _timeLeftRank3;

    public int TimeLeft => this._timeLeftRank1 + this._timeLeftRank2 + this._timeLeftRank3;

    public int Rank
    {
      get
      {
        if (this._timeLeftRank3 > 0)
          return 3;
        if (this._timeLeftRank2 > 0)
          return 2;
        return this._timeLeftRank1 > 0 ? 1 : 0;
      }
    }

    public void Eat(int foodRank, int foodBuffTime)
    {
      int timeLeftToAdd = foodBuffTime;
      if (foodRank >= 3)
        this.AddTimeTo(ref this._timeLeftRank3, ref timeLeftToAdd, 72000);
      if (foodRank >= 2)
        this.AddTimeTo(ref this._timeLeftRank2, ref timeLeftToAdd, 72000);
      if (foodRank < 1)
        return;
      this.AddTimeTo(ref this._timeLeftRank1, ref timeLeftToAdd, 72000);
    }

    public void Update() => this.ReduceTimeLeft();

    public void Clear()
    {
      this._timeLeftRank1 = 0;
      this._timeLeftRank2 = 0;
      this._timeLeftRank3 = 0;
    }

    private void AddTimeTo(ref int foodTimeCounter, ref int timeLeftToAdd, int counterMaximumTime)
    {
      if (timeLeftToAdd == 0)
        return;
      int num = timeLeftToAdd;
      if (foodTimeCounter + num > counterMaximumTime)
        num = counterMaximumTime - foodTimeCounter;
      foodTimeCounter += num;
      timeLeftToAdd -= num;
    }

    private void ReduceTimeLeft()
    {
      if (this._timeLeftRank3 > 0)
        --this._timeLeftRank3;
      else if (this._timeLeftRank2 > 0)
      {
        --this._timeLeftRank2;
      }
      else
      {
        if (this._timeLeftRank1 <= 0)
          return;
        --this._timeLeftRank1;
      }
    }
  }
}
