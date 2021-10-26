// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallStepResult
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.Physics
{
  public struct BallStepResult
  {
    public readonly BallState State;

    private BallStepResult(BallState state) => this.State = state;

    public static BallStepResult OutOfBounds() => new BallStepResult(BallState.OutOfBounds);

    public static BallStepResult Moving() => new BallStepResult(BallState.Moving);

    public static BallStepResult Resting() => new BallStepResult(BallState.Resting);
  }
}
