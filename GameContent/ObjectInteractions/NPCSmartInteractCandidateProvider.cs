// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.NPCSmartInteractCandidateProvider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.ObjectInteractions
{
  public class NPCSmartInteractCandidateProvider : ISmartInteractCandidateProvider
  {
    private NPCSmartInteractCandidateProvider.ReusableCandidate _candidate = new NPCSmartInteractCandidateProvider.ReusableCandidate();

    public void ClearSelfAndPrepareForCheck() => Main.SmartInteractNPC = -1;

    public bool ProvideCandidate(
      SmartInteractScanSettings settings,
      out ISmartInteractCandidate candidate)
    {
      candidate = (ISmartInteractCandidate) null;
      if (!settings.FullInteraction)
        return false;
      Rectangle rectangle = Utils.CenteredRectangle(settings.player.Center, new Vector2((float) Player.tileRangeX, (float) Player.tileRangeY) * 16f * 2f);
      Vector2 mousevec = settings.mousevec;
      mousevec.ToPoint();
      bool flag = false;
      int npcIndex = -1;
      float npcDistanceFromCursor = -1f;
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && npc.townNPC && npc.Hitbox.Intersects(rectangle) && !flag)
        {
          float num = npc.Hitbox.Distance(mousevec);
          if ((npcIndex == -1 ? 1 : ((double) Main.npc[npcIndex].Hitbox.Distance(mousevec) > (double) num ? 1 : 0)) != 0)
          {
            npcIndex = index;
            npcDistanceFromCursor = num;
          }
          if ((double) num == 0.0)
          {
            flag = true;
            npcIndex = index;
            npcDistanceFromCursor = num;
            break;
          }
        }
      }
      if (settings.DemandOnlyZeroDistanceTargets && !flag || npcIndex == -1)
        return false;
      this._candidate.Reuse(npcIndex, npcDistanceFromCursor);
      candidate = (ISmartInteractCandidate) this._candidate;
      return true;
    }

    private class ReusableCandidate : ISmartInteractCandidate
    {
      private int _npcIndexToTarget;

      public float DistanceFromCursor { get; private set; }

      public void WinCandidacy()
      {
        Main.SmartInteractNPC = this._npcIndexToTarget;
        Main.SmartInteractShowingGenuine = true;
      }

      public void Reuse(int npcIndex, float npcDistanceFromCursor)
      {
        this._npcIndexToTarget = npcIndex;
        this.DistanceFromCursor = npcDistanceFromCursor;
      }
    }
  }
}
