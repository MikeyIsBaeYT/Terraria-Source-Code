// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.StackedConditionSetter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes
{
  public class StackedConditionSetter : ISimulationConditionSetter
  {
    private ISimulationConditionSetter[] _setters;

    public StackedConditionSetter(params ISimulationConditionSetter[] setters) => this._setters = setters;

    public void Setup(SimulatorInfo info)
    {
      for (int index = 0; index < this._setters.Length; ++index)
        this._setters[index].Setup(info);
    }

    public void TearDown(SimulatorInfo info)
    {
      for (int index = 0; index < this._setters.Length; ++index)
        this._setters[index].TearDown(info);
    }

    public int GetTimesToRunMultiplier(SimulatorInfo info) => 1;
  }
}
