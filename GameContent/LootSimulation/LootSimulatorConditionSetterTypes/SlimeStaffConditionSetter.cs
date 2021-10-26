// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.SlimeStaffConditionSetter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes
{
  public class SlimeStaffConditionSetter : ISimulationConditionSetter
  {
    private int _timesToRun;

    public SlimeStaffConditionSetter(int timesToRunMultiplier) => this._timesToRun = timesToRunMultiplier;

    public int GetTimesToRunMultiplier(SimulatorInfo info)
    {
      switch (info.npcVictim.netID)
      {
        case -33:
        case -32:
        case -10:
        case -9:
        case -8:
        case -7:
        case -6:
        case -5:
        case -4:
        case -3:
        case 1:
        case 16:
        case 138:
        case 141:
        case 147:
        case 184:
        case 187:
        case 204:
        case 302:
        case 333:
        case 334:
        case 335:
        case 336:
        case 433:
        case 535:
        case 537:
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
