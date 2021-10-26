// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.GoldCritterUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.ID;

namespace Terraria.GameContent.Bestiary
{
  public class GoldCritterUICollectionInfoProvider : IBestiaryUICollectionInfoProvider
  {
    private string[] _normalCritterPersistentId;
    private string _goldCritterPersistentId;

    public GoldCritterUICollectionInfoProvider(
      int[] normalCritterPersistentId,
      string goldCritterPersistentId)
    {
      this._normalCritterPersistentId = new string[normalCritterPersistentId.Length];
      for (int index = 0; index < normalCritterPersistentId.Length; ++index)
        this._normalCritterPersistentId[index] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[normalCritterPersistentId[index]];
      this._goldCritterPersistentId = goldCritterPersistentId;
    }

    public BestiaryUICollectionInfo GetEntryUICollectionInfo()
    {
      BestiaryEntryUnlockState unlockStateForCritter1 = this.GetUnlockStateForCritter(this._goldCritterPersistentId);
      BestiaryEntryUnlockState entryUnlockState = BestiaryEntryUnlockState.NotKnownAtAll_0;
      if (unlockStateForCritter1 > entryUnlockState)
        entryUnlockState = unlockStateForCritter1;
      foreach (string persistentId in this._normalCritterPersistentId)
      {
        BestiaryEntryUnlockState unlockStateForCritter2 = this.GetUnlockStateForCritter(persistentId);
        if (unlockStateForCritter2 > entryUnlockState)
          entryUnlockState = unlockStateForCritter2;
      }
      BestiaryUICollectionInfo uiCollectionInfo = new BestiaryUICollectionInfo()
      {
        UnlockState = entryUnlockState
      };
      if (entryUnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0 || this.TryFindingOneGoldCritterThatIsAlreadyUnlocked())
        return uiCollectionInfo;
      return new BestiaryUICollectionInfo()
      {
        UnlockState = BestiaryEntryUnlockState.NotKnownAtAll_0
      };
    }

    private bool TryFindingOneGoldCritterThatIsAlreadyUnlocked()
    {
      for (int index = 0; index < NPCID.Sets.GoldCrittersCollection.Count; ++index)
      {
        int goldCritters = NPCID.Sets.GoldCrittersCollection[index];
        if (this.GetUnlockStateForCritter(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[goldCritters]) > BestiaryEntryUnlockState.NotKnownAtAll_0)
          return true;
      }
      return false;
    }

    private BestiaryEntryUnlockState GetUnlockStateForCritter(
      string persistentId)
    {
      return !Main.BestiaryTracker.Sights.GetWasNearbyBefore(persistentId) ? BestiaryEntryUnlockState.NotKnownAtAll_0 : BestiaryEntryUnlockState.CanShowDropsWithDropRates_4;
    }
  }
}
