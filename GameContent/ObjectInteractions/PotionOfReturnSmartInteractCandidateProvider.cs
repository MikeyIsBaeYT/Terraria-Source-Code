// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.PotionOfReturnSmartInteractCandidateProvider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.ObjectInteractions
{
  public class PotionOfReturnSmartInteractCandidateProvider : ISmartInteractCandidateProvider
  {
    private PotionOfReturnSmartInteractCandidateProvider.ReusableCandidate _candidate = new PotionOfReturnSmartInteractCandidateProvider.ReusableCandidate();

    public void ClearSelfAndPrepareForCheck() => Main.SmartInteractPotionOfReturn = false;

    public bool ProvideCandidate(
      SmartInteractScanSettings settings,
      out ISmartInteractCandidate candidate)
    {
      candidate = (ISmartInteractCandidate) null;
      Rectangle homeHitbox;
      if (!PotionOfReturnHelper.TryGetGateHitbox(settings.player, out homeHitbox))
        return false;
      this._candidate.Reuse(homeHitbox.ClosestPointInRect(settings.mousevec).Distance(settings.mousevec));
      candidate = (ISmartInteractCandidate) this._candidate;
      return true;
    }

    private class ReusableCandidate : ISmartInteractCandidate
    {
      public float DistanceFromCursor { get; private set; }

      public void WinCandidacy()
      {
        Main.SmartInteractPotionOfReturn = true;
        Main.SmartInteractShowingGenuine = true;
      }

      public void Reuse(float distanceFromCursor) => this.DistanceFromCursor = distanceFromCursor;
    }
  }
}
