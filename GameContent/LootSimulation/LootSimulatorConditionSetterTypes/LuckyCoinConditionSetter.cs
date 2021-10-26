// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.LuckyCoinConditionSetter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes
{
  public class LuckyCoinConditionSetter : ISimulationConditionSetter
  {
    private int _timesToRun;

    public LuckyCoinConditionSetter(int timesToRunMultiplier) => this._timesToRun = timesToRunMultiplier;

    public int GetTimesToRunMultiplier(SimulatorInfo info)
    {
      switch (info.npcVictim.netID)
      {
        case 216:
        case 491:
          return this._timesToRun;
        default:
          return 0;
      }
    }

    public void Setup(SimulatorInfo info)
    {
    }

    public void TearDown(SimulatorInfo info)
    {
    }
  }
}
