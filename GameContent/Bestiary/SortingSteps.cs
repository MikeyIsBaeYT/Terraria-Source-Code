// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.SortingSteps
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria.GameContent.Bestiary
{
  public static class SortingSteps
  {
    public class ByNetId : IBestiarySortStep, IEntrySortStep<BestiaryEntry>, IComparer<BestiaryEntry>
    {
      public bool HiddenFromSortOptions => true;

      public int Compare(BestiaryEntry x, BestiaryEntry y)
      {
        NPCNetIdBestiaryInfoElement bestiaryInfoElement1 = x.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        NPCNetIdBestiaryInfoElement bestiaryInfoElement2 = y.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        if (bestiaryInfoElement1 == null && bestiaryInfoElement2 != null)
          return 1;
        if (bestiaryInfoElement2 == null && bestiaryInfoElement1 != null)
          return -1;
        return bestiaryInfoElement1 == null || bestiaryInfoElement2 == null ? 0 : bestiaryInfoElement1.NetId.CompareTo(bestiaryInfoElement2.NetId);
      }

      public string GetDisplayNameKey() => "BestiaryInfo.Sort_ID";
    }

    public class ByUnlockState : 
      IBestiarySortStep,
      IEntrySortStep<BestiaryEntry>,
      IComparer<BestiaryEntry>
    {
      public bool HiddenFromSortOptions => true;

      public int Compare(BestiaryEntry x, BestiaryEntry y)
      {
        BestiaryUICollectionInfo uiCollectionInfo1 = x.UIInfoProvider.GetEntryUICollectionInfo();
        BestiaryUICollectionInfo uiCollectionInfo2 = y.UIInfoProvider.GetEntryUICollectionInfo();
        return y.Icon.GetUnlockState(uiCollectionInfo2).CompareTo(x.Icon.GetUnlockState(uiCollectionInfo1));
      }

      public string GetDisplayNameKey() => "BestiaryInfo.Sort_Unlocks";
    }

    public class ByBestiarySortingId : 
      IBestiarySortStep,
      IEntrySortStep<BestiaryEntry>,
      IComparer<BestiaryEntry>
    {
      public bool HiddenFromSortOptions => false;

      public int Compare(BestiaryEntry x, BestiaryEntry y)
      {
        NPCNetIdBestiaryInfoElement bestiaryInfoElement1 = x.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        NPCNetIdBestiaryInfoElement bestiaryInfoElement2 = y.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        if (bestiaryInfoElement1 == null && bestiaryInfoElement2 != null)
          return 1;
        if (bestiaryInfoElement2 == null && bestiaryInfoElement1 != null)
          return -1;
        return bestiaryInfoElement1 == null || bestiaryInfoElement2 == null ? 0 : ContentSamples.NpcBestiarySortingId[bestiaryInfoElement1.NetId].CompareTo(ContentSamples.NpcBestiarySortingId[bestiaryInfoElement2.NetId]);
      }

      public string GetDisplayNameKey() => "BestiaryInfo.Sort_BestiaryID";
    }

    public class ByBestiaryRarity : 
      IBestiarySortStep,
      IEntrySortStep<BestiaryEntry>,
      IComparer<BestiaryEntry>
    {
      public bool HiddenFromSortOptions => false;

      public int Compare(BestiaryEntry x, BestiaryEntry y)
      {
        NPCNetIdBestiaryInfoElement bestiaryInfoElement1 = x.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        NPCNetIdBestiaryInfoElement bestiaryInfoElement2 = y.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        if (bestiaryInfoElement1 == null && bestiaryInfoElement2 != null)
          return 1;
        if (bestiaryInfoElement2 == null && bestiaryInfoElement1 != null)
          return -1;
        if (bestiaryInfoElement1 == null || bestiaryInfoElement2 == null)
          return 0;
        int bestiaryRarityStar = ContentSamples.NpcBestiaryRarityStars[bestiaryInfoElement1.NetId];
        return ContentSamples.NpcBestiaryRarityStars[bestiaryInfoElement2.NetId].CompareTo(bestiaryRarityStar);
      }

      public string GetDisplayNameKey() => "BestiaryInfo.Sort_Rarity";
    }

    public class Alphabetical : 
      IBestiarySortStep,
      IEntrySortStep<BestiaryEntry>,
      IComparer<BestiaryEntry>
    {
      public bool HiddenFromSortOptions => false;

      public int Compare(BestiaryEntry x, BestiaryEntry y)
      {
        NPCNetIdBestiaryInfoElement bestiaryInfoElement1 = x.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        NPCNetIdBestiaryInfoElement bestiaryInfoElement2 = y.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => element is NPCNetIdBestiaryInfoElement)) as NPCNetIdBestiaryInfoElement;
        if (bestiaryInfoElement1 == null && bestiaryInfoElement2 != null)
          return 1;
        if (bestiaryInfoElement2 == null && bestiaryInfoElement1 != null)
          return -1;
        return bestiaryInfoElement1 == null || bestiaryInfoElement2 == null ? 0 : Language.GetTextValue(ContentSamples.NpcsByNetId[bestiaryInfoElement1.NetId].TypeName).CompareTo(Language.GetTextValue(ContentSamples.NpcsByNetId[bestiaryInfoElement2.NetId].TypeName));
      }

      public string GetDisplayNameKey() => "BestiaryInfo.Sort_Alphabetical";
    }

    public abstract class ByStat : 
      IBestiarySortStep,
      IEntrySortStep<BestiaryEntry>,
      IComparer<BestiaryEntry>
    {
      public bool HiddenFromSortOptions => false;

      public int Compare(BestiaryEntry x, BestiaryEntry y)
      {
        NPCStatsReportInfoElement cardX = x.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => this.IsAStatsCardINeed(element, Main.GameMode))) as NPCStatsReportInfoElement;
        NPCStatsReportInfoElement cardY = y.Info.FirstOrDefault<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (element => this.IsAStatsCardINeed(element, Main.GameMode))) as NPCStatsReportInfoElement;
        if (cardX == null && cardY != null)
          return 1;
        if (cardY == null && cardX != null)
          return -1;
        return cardX == null || cardY == null ? 0 : this.Compare(cardX, cardY);
      }

      public abstract int Compare(NPCStatsReportInfoElement cardX, NPCStatsReportInfoElement cardY);

      public abstract string GetDisplayNameKey();

      private bool IsAStatsCardINeed(IBestiaryInfoElement element, int gameMode) => element is NPCStatsReportInfoElement reportInfoElement && reportInfoElement.GameMode == gameMode;
    }

    public class ByAttack : SortingSteps.ByStat
    {
      public override int Compare(NPCStatsReportInfoElement cardX, NPCStatsReportInfoElement cardY) => cardY.Damage.CompareTo(cardX.Damage);

      public override string GetDisplayNameKey() => "BestiaryInfo.Sort_Attack";
    }

    public class ByDefense : SortingSteps.ByStat
    {
      public override int Compare(NPCStatsReportInfoElement cardX, NPCStatsReportInfoElement cardY) => cardY.Defense.CompareTo(cardX.Defense);

      public override string GetDisplayNameKey() => "BestiaryInfo.Sort_Defense";
    }

    public class ByCoins : SortingSteps.ByStat
    {
      public override int Compare(NPCStatsReportInfoElement cardX, NPCStatsReportInfoElement cardY) => cardY.MonetaryValue.CompareTo(cardX.MonetaryValue);

      public override string GetDisplayNameKey() => "BestiaryInfo.Sort_Coins";
    }

    public class ByHP : SortingSteps.ByStat
    {
      public override int Compare(NPCStatsReportInfoElement cardX, NPCStatsReportInfoElement cardY) => cardY.LifeMax.CompareTo(cardX.LifeMax);

      public override string GetDisplayNameKey() => "BestiaryInfo.Sort_HitPoints";
    }
  }
}
