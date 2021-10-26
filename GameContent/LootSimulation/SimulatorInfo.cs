// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.SimulatorInfo
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.LootSimulation
{
  public class SimulatorInfo
  {
    public Player player;
    private double _originalDayTimeCounter;
    private bool _originalDayTimeFlag;
    private Vector2 _originalPlayerPosition;
    public bool runningExpertMode;
    public LootSimulationItemCounter itemCounter;
    public NPC npcVictim;

    public SimulatorInfo()
    {
      this.player = new Player();
      this._originalDayTimeCounter = Main.time;
      this._originalDayTimeFlag = Main.dayTime;
      this._originalPlayerPosition = this.player.position;
      this.runningExpertMode = false;
    }

    public void ReturnToOriginalDaytime()
    {
      Main.dayTime = this._originalDayTimeFlag;
      Main.time = this._originalDayTimeCounter;
    }

    public void AddItem(int itemId, int amount) => this.itemCounter.AddItem(itemId, amount, this.runningExpertMode);

    public void ReturnToOriginalPlayerPosition() => this.player.position = this._originalPlayerPosition;
  }
}
