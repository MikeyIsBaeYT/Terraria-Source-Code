// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.SmartInteractSystem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ObjectInteractions
{
  public class SmartInteractSystem
  {
    private List<ISmartInteractCandidateProvider> _candidateProvidersByOrderOfPriority = new List<ISmartInteractCandidateProvider>();
    private List<ISmartInteractBlockReasonProvider> _blockProviders = new List<ISmartInteractBlockReasonProvider>();
    private List<ISmartInteractCandidate> _candidates = new List<ISmartInteractCandidate>();

    public SmartInteractSystem()
    {
      this._candidateProvidersByOrderOfPriority.Add((ISmartInteractCandidateProvider) new PotionOfReturnSmartInteractCandidateProvider());
      this._candidateProvidersByOrderOfPriority.Add((ISmartInteractCandidateProvider) new ProjectileSmartInteractCandidateProvider());
      this._candidateProvidersByOrderOfPriority.Add((ISmartInteractCandidateProvider) new NPCSmartInteractCandidateProvider());
      this._candidateProvidersByOrderOfPriority.Add((ISmartInteractCandidateProvider) new TileSmartInteractCandidateProvider());
      this._blockProviders.Add((ISmartInteractBlockReasonProvider) new BlockBecauseYouAreOverAnImportantTile());
    }

    public void RunQuery(SmartInteractScanSettings settings)
    {
      this._candidates.Clear();
      foreach (ISmartInteractBlockReasonProvider blockProvider in this._blockProviders)
      {
        if (blockProvider.ShouldBlockSmartInteract(settings))
          return;
      }
      foreach (ISmartInteractCandidateProvider candidateProvider in this._candidateProvidersByOrderOfPriority)
        candidateProvider.ClearSelfAndPrepareForCheck();
      foreach (ISmartInteractCandidateProvider candidateProvider in this._candidateProvidersByOrderOfPriority)
      {
        ISmartInteractCandidate candidate;
        if (candidateProvider.ProvideCandidate(settings, out candidate))
        {
          this._candidates.Add(candidate);
          if ((double) candidate.DistanceFromCursor == 0.0)
            break;
        }
      }
      ISmartInteractCandidate interactCandidate = (ISmartInteractCandidate) null;
      foreach (ISmartInteractCandidate candidate in this._candidates)
      {
        if (interactCandidate == null || (double) interactCandidate.DistanceFromCursor > (double) candidate.DistanceFromCursor)
          interactCandidate = candidate;
      }
      interactCandidate?.WinCandidacy();
    }
  }
}
