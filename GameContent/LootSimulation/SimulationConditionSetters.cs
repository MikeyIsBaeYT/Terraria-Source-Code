// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.SimulationConditionSetters
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes;

namespace Terraria.GameContent.LootSimulation
{
  public class SimulationConditionSetters
  {
    public static FastConditionSetter HardMode = new FastConditionSetter((Action<SimulatorInfo>) (info => Main.hardMode = true), (Action<SimulatorInfo>) (info => Main.hardMode = false));
    public static FastConditionSetter ExpertMode = new FastConditionSetter((Action<SimulatorInfo>) (info =>
    {
      Main.GameMode = 1;
      info.runningExpertMode = true;
    }), (Action<SimulatorInfo>) (info =>
    {
      Main.GameMode = 0;
      info.runningExpertMode = false;
    }));
    public static FastConditionSetter Eclipse = new FastConditionSetter((Action<SimulatorInfo>) (info => Main.eclipse = true), (Action<SimulatorInfo>) (info => Main.eclipse = false));
    public static FastConditionSetter BloodMoon = new FastConditionSetter((Action<SimulatorInfo>) (info => Main.bloodMoon = true), (Action<SimulatorInfo>) (info => Main.bloodMoon = false));
    public static FastConditionSetter SlainMechBosses = new FastConditionSetter((Action<SimulatorInfo>) (info =>
    {
      int num;
      NPC.downedMechBossAny = (num = 1) != 0;
      NPC.downedMechBoss3 = num != 0;
      NPC.downedMechBoss2 = num != 0;
      NPC.downedMechBoss1 = num != 0;
    }), (Action<SimulatorInfo>) (info =>
    {
      int num;
      NPC.downedMechBossAny = (num = 0) != 0;
      NPC.downedMechBoss3 = num != 0;
      NPC.downedMechBoss2 = num != 0;
      NPC.downedMechBoss1 = num != 0;
    }));
    public static FastConditionSetter SlainPlantera = new FastConditionSetter((Action<SimulatorInfo>) (info => NPC.downedPlantBoss = true), (Action<SimulatorInfo>) (info => NPC.downedPlantBoss = false));
    public static StackedConditionSetter ExpertAndHardMode = new StackedConditionSetter(new ISimulationConditionSetter[2]
    {
      (ISimulationConditionSetter) SimulationConditionSetters.ExpertMode,
      (ISimulationConditionSetter) SimulationConditionSetters.HardMode
    });
    public static FastConditionSetter WindyWeather = new FastConditionSetter((Action<SimulatorInfo>) (info => Main._shouldUseWindyDayMusic = true), (Action<SimulatorInfo>) (info => Main._shouldUseWindyDayMusic = false));
    public static FastConditionSetter MidDay = new FastConditionSetter((Action<SimulatorInfo>) (info =>
    {
      Main.dayTime = true;
      Main.time = 27000.0;
    }), (Action<SimulatorInfo>) (info => info.ReturnToOriginalDaytime()));
    public static FastConditionSetter MidNight = new FastConditionSetter((Action<SimulatorInfo>) (info =>
    {
      Main.dayTime = false;
      Main.time = 16200.0;
    }), (Action<SimulatorInfo>) (info => info.ReturnToOriginalDaytime()));
    public static FastConditionSetter SlimeRain = new FastConditionSetter((Action<SimulatorInfo>) (info => Main.slimeRain = true), (Action<SimulatorInfo>) (info => Main.slimeRain = false));
    public static StackedConditionSetter WindyExpertHardmodeEndgameEclipseMorning = new StackedConditionSetter(new ISimulationConditionSetter[7]
    {
      (ISimulationConditionSetter) SimulationConditionSetters.WindyWeather,
      (ISimulationConditionSetter) SimulationConditionSetters.ExpertMode,
      (ISimulationConditionSetter) SimulationConditionSetters.HardMode,
      (ISimulationConditionSetter) SimulationConditionSetters.SlainMechBosses,
      (ISimulationConditionSetter) SimulationConditionSetters.SlainPlantera,
      (ISimulationConditionSetter) SimulationConditionSetters.Eclipse,
      (ISimulationConditionSetter) SimulationConditionSetters.MidDay
    });
    public static StackedConditionSetter WindyExpertHardmodeEndgameBloodMoonNight = new StackedConditionSetter(new ISimulationConditionSetter[7]
    {
      (ISimulationConditionSetter) SimulationConditionSetters.WindyWeather,
      (ISimulationConditionSetter) SimulationConditionSetters.ExpertMode,
      (ISimulationConditionSetter) SimulationConditionSetters.HardMode,
      (ISimulationConditionSetter) SimulationConditionSetters.SlainMechBosses,
      (ISimulationConditionSetter) SimulationConditionSetters.SlainPlantera,
      (ISimulationConditionSetter) SimulationConditionSetters.BloodMoon,
      (ISimulationConditionSetter) SimulationConditionSetters.MidNight
    });
    public static SlimeStaffConditionSetter SlimeStaffTest = new SlimeStaffConditionSetter(100);
    public static LuckyCoinConditionSetter LuckyCoinTest = new LuckyCoinConditionSetter(100);
  }
}
