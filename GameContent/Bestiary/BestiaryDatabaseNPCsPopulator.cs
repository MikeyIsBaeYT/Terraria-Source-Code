// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;

namespace Terraria.GameContent.Bestiary
{
  public class BestiaryDatabaseNPCsPopulator
  {
    private BestiaryDatabase _currentDatabase;

    private BestiaryEntry FindEntryByNPCID(int npcNetId) => this._currentDatabase.FindEntryByNPCID(npcNetId);

    private BestiaryEntry Register(BestiaryEntry entry) => this._currentDatabase.Register(entry);

    private IBestiaryEntryFilter Register(IBestiaryEntryFilter filter) => this._currentDatabase.Register(filter);

    public void Populate(BestiaryDatabase database)
    {
      this._currentDatabase = database;
      this.AddEmptyEntries_CrittersAndEnemies_Automated();
      this.AddTownNPCs_Manual();
      this.AddNPCBiomeRelationships_Automated();
      this.AddNPCBiomeRelationships_Manual();
      this.AddNPCBiomeRelationships_AddDecorations_Automated();
      this.ModifyEntriesThatNeedIt();
      this.RegisterFilters();
      this.RegisterSortSteps();
    }

    private void RegisterTestEntries() => this.Register(BestiaryEntry.Biome("Bestiary_Biomes.Hallow", "Images/UI/Bestiary/Biome_Hallow", new Func<bool>(BestiaryDatabaseNPCsPopulator.Conditions.ReachHardMode)));

    private void RegisterSortSteps()
    {
      foreach (IBestiarySortStep sortStep in new List<IBestiarySortStep>()
      {
        (IBestiarySortStep) new SortingSteps.ByUnlockState(),
        (IBestiarySortStep) new SortingSteps.ByBestiarySortingId(),
        (IBestiarySortStep) new SortingSteps.Alphabetical(),
        (IBestiarySortStep) new SortingSteps.ByNetId(),
        (IBestiarySortStep) new SortingSteps.ByAttack(),
        (IBestiarySortStep) new SortingSteps.ByDefense(),
        (IBestiarySortStep) new SortingSteps.ByCoins(),
        (IBestiarySortStep) new SortingSteps.ByHP(),
        (IBestiarySortStep) new SortingSteps.ByBestiaryRarity()
      })
        this._currentDatabase.Register(sortStep);
    }

    private void RegisterFilters()
    {
      this.Register((IBestiaryEntryFilter) new Filters.ByUnlockState());
      this.Register((IBestiaryEntryFilter) new Filters.ByBoss());
      this.Register((IBestiaryEntryFilter) new Filters.ByRareCreature());
      List<IBestiaryInfoElement> elementsForFilters = BestiaryDatabaseNPCsPopulator.CommonTags.GetCommonInfoElementsForFilters();
      for (int index = 0; index < elementsForFilters.Count; ++index)
        this.Register((IBestiaryEntryFilter) new Filters.ByInfoElement(elementsForFilters[index]));
    }

    private void ModifyEntriesThatNeedIt_NameOverride(int npcID, string newNameKey)
    {
      BestiaryEntry entryByNpcid = this.FindEntryByNPCID(npcID);
      entryByNpcid.Info.RemoveAll((Predicate<IBestiaryInfoElement>) (x => x is NamePlateInfoElement));
      entryByNpcid.Info.Add((IBestiaryInfoElement) new NamePlateInfoElement(newNameKey, npcID));
      entryByNpcid.Icon = (IEntryIcon) new UnlockableNPCEntryIcon(npcID, overrideNameKey: newNameKey);
    }

    private void ModifyEntriesThatNeedIt()
    {
      this.FindEntryByNPCID(258).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom));
      this.FindEntryByNPCID(-1).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(81).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(121).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(7).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(98).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(6).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(94).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption));
      this.FindEntryByNPCID(173).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(181).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(183).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(242).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(241).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(174).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(240).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson));
      this.FindEntryByNPCID(175).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle));
      this.FindEntryByNPCID(153).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle));
      this.FindEntryByNPCID(52).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle));
      this.FindEntryByNPCID(58).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle));
      this.FindEntryByNPCID(102).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns));
      this.FindEntryByNPCID(157).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle));
      this.FindEntryByNPCID(51).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle));
      this.FindEntryByNPCID(169).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow));
      this.FindEntryByNPCID(510).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert));
      this.FindEntryByNPCID(69).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert));
      this.FindEntryByNPCID(580).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert));
      this.FindEntryByNPCID(581).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert));
      this.FindEntryByNPCID(78).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert));
      this.FindEntryByNPCID(79).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptDesert));
      this.FindEntryByNPCID(630).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonDesert));
      this.FindEntryByNPCID(80).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowDesert));
      this.FindEntryByNPCID(533).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundBasedOnWorldEvilProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert, (IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert));
      this.FindEntryByNPCID(528).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert));
      this.FindEntryByNPCID(529).AddTags((IBestiaryInfoElement) new BestiaryPortraitBackgroundBasedOnWorldEvilProviderPreferenceInfoElement((IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert, (IBestiaryBackgroundImagePathAndColorProvider) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert));
      this._currentDatabase.ApplyPass(new BestiaryDatabase.BestiaryEntriesPass(this.TryGivingEntryFlavorTextIfItIsMissing));
      BestiaryEntry entryByNpcid = this.FindEntryByNPCID(398);
      entryByNpcid.Info.Add((IBestiaryInfoElement) new MoonLordPortraitBackgroundProviderBestiaryInfoElement());
      entryByNpcid.Info.RemoveAll((Predicate<IBestiaryInfoElement>) (x => x is NamePlateInfoElement));
      entryByNpcid.Info.Add((IBestiaryInfoElement) new NamePlateInfoElement("Enemies.MoonLord", 398));
      entryByNpcid.Icon = (IEntryIcon) new UnlockableNPCEntryIcon(398, overrideNameKey: "Enemies.MoonLord");
      this.ModifyEntriesThatNeedIt_NameOverride(637, "Friends.TownCat");
      this.ModifyEntriesThatNeedIt_NameOverride(638, "Friends.TownDog");
      this.ModifyEntriesThatNeedIt_NameOverride(656, "Friends.TownBunny");
      for (int index = 494; index <= 506; ++index)
        this.FindEntryByNPCID(index).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new SalamanderShellyDadUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[index]);
      this.FindEntryByNPCID(534).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new HighestOfMultipleUICollectionInfoProvider(new IBestiaryUICollectionInfoProvider[2]
      {
        (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[534], false),
        (IBestiaryUICollectionInfoProvider) new TownNPCUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[441])
      });
      foreach (NPCStatsReportInfoElement reportInfoElement in this.FindEntryByNPCID(13).Info.Select<IBestiaryInfoElement, NPCStatsReportInfoElement>((Func<IBestiaryInfoElement, NPCStatsReportInfoElement>) (x => x as NPCStatsReportInfoElement)).Where<NPCStatsReportInfoElement>((Func<NPCStatsReportInfoElement, bool>) (x => x != null)))
        reportInfoElement.LifeMax *= NPC.GetEaterOfWorldsSegmentsCountByGamemode(reportInfoElement.GameMode);
      foreach (NPCStatsReportInfoElement reportInfoElement in this.FindEntryByNPCID(491).Info.Select<IBestiaryInfoElement, NPCStatsReportInfoElement>((Func<IBestiaryInfoElement, NPCStatsReportInfoElement>) (x => x as NPCStatsReportInfoElement)).Where<NPCStatsReportInfoElement>((Func<NPCStatsReportInfoElement, bool>) (x => x != null)))
      {
        NPC npc = new NPC();
        int num = 4;
        npc.SetDefaults(492);
        reportInfoElement.LifeMax = num * npc.lifeMax;
      }
      this.FindEntryByNPCID(68).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new HighestOfMultipleUICollectionInfoProvider(new IBestiaryUICollectionInfoProvider[3]
      {
        (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[68], true),
        (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[35], true),
        (IBestiaryUICollectionInfoProvider) new TownNPCUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[54])
      });
      this.FindEntryByNPCID(35).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new HighestOfMultipleUICollectionInfoProvider(new IBestiaryUICollectionInfoProvider[2]
      {
        (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[35], true),
        (IBestiaryUICollectionInfoProvider) new TownNPCUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[54])
      });
      this.FindEntryByNPCID(37).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new HighestOfMultipleUICollectionInfoProvider(new IBestiaryUICollectionInfoProvider[3]
      {
        (IBestiaryUICollectionInfoProvider) new TownNPCUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[37]),
        (IBestiaryUICollectionInfoProvider) new TownNPCUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[54]),
        (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[35], true)
      });
      this.FindEntryByNPCID(551).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[551], true);
      this.FindEntryByNPCID(491).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[491], true);
      foreach (KeyValuePair<int, int[]> keyValuePair in new Dictionary<int, int[]>()
      {
        {
          443,
          new int[1]{ 46 }
        },
        {
          442,
          new int[1]{ 74 }
        },
        {
          592,
          new int[1]{ 55 }
        },
        {
          444,
          new int[1]{ 356 }
        },
        {
          601,
          new int[1]{ 599 }
        },
        {
          445,
          new int[1]{ 361 }
        },
        {
          446,
          new int[1]{ 377 }
        },
        {
          605,
          new int[1]{ 604 }
        },
        {
          447,
          new int[1]{ 300 }
        },
        {
          627,
          new int[1]{ 626 }
        },
        {
          613,
          new int[1]{ 612 }
        },
        {
          448,
          new int[1]{ 357 }
        },
        {
          539,
          new int[2]{ 299, 538 }
        }
      })
        this.FindEntryByNPCID(keyValuePair.Key).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new GoldCritterUICollectionInfoProvider(keyValuePair.Value, ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[keyValuePair.Key]);
      foreach (KeyValuePair<int, int> keyValuePair in new Dictionary<int, int>()
      {
        {
          362,
          363
        },
        {
          364,
          365
        },
        {
          602,
          603
        },
        {
          608,
          609
        }
      })
        this.FindEntryByNPCID(keyValuePair.Key).UIInfoProvider = (IBestiaryUICollectionInfoProvider) new HighestOfMultipleUICollectionInfoProvider(new IBestiaryUICollectionInfoProvider[2]
        {
          (IBestiaryUICollectionInfoProvider) new CritterUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[keyValuePair.Key]),
          (IBestiaryUICollectionInfoProvider) new CritterUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[keyValuePair.Value])
        });
      this.FindEntryByNPCID(4).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("eoc"));
      this.FindEntryByNPCID(13).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("eow"));
      this.FindEntryByNPCID(266).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("boc"));
      this.FindEntryByNPCID(113).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("wof"));
      this.FindEntryByNPCID(50).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("slime king"));
      this.FindEntryByNPCID(125).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("the twins"));
      this.FindEntryByNPCID(126).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("the twins"));
      this.FindEntryByNPCID(222).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("qb"));
      this.FindEntryByNPCID(222).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("bee queen"));
      this.FindEntryByNPCID(398).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("moonlord"));
      this.FindEntryByNPCID(398).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("cthulhu"));
      this.FindEntryByNPCID(398).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("ml"));
      this.FindEntryByNPCID(125).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("mech boss"));
      this.FindEntryByNPCID(126).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("mech boss"));
      this.FindEntryByNPCID((int) sbyte.MaxValue).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("mech boss"));
      this.FindEntryByNPCID(134).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("mech boss"));
      this.FindEntryByNPCID(657).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("slime queen"));
      this.FindEntryByNPCID(636).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("eol"));
      this.FindEntryByNPCID(636).AddTags((IBestiaryInfoElement) new SearchAliasInfoElement("fairy"));
    }

    private void TryGivingEntryFlavorTextIfItIsMissing(BestiaryEntry entry)
    {
      if (entry.Info.Any<IBestiaryInfoElement>((Func<IBestiaryInfoElement, bool>) (x => x is FlavorTextBestiaryInfoElement)))
        return;
      SpawnConditionBestiaryInfoElement bestiaryInfoElement1 = (SpawnConditionBestiaryInfoElement) null;
      int? nullable1 = new int?();
      foreach (IBestiaryInfoElement bestiaryInfoElement2 in entry.Info)
      {
        if (bestiaryInfoElement2 is BestiaryPortraitBackgroundProviderPreferenceInfoElement preferenceInfoElement2 && preferenceInfoElement2.GetPreferredProvider() is SpawnConditionBestiaryInfoElement preferredProvider2)
        {
          bestiaryInfoElement1 = preferredProvider2;
          break;
        }
        if (bestiaryInfoElement2 is SpawnConditionBestiaryInfoElement bestiaryInfoElement5)
        {
          int displayTextPriority = bestiaryInfoElement5.DisplayTextPriority;
          if (nullable1.HasValue)
          {
            int num = displayTextPriority;
            int? nullable2 = nullable1;
            int valueOrDefault = nullable2.GetValueOrDefault();
            if (!(num >= valueOrDefault & nullable2.HasValue))
              continue;
          }
          bestiaryInfoElement1 = bestiaryInfoElement5;
          nullable1 = new int?(displayTextPriority);
        }
      }
      if (bestiaryInfoElement1 == null)
        return;
      string displayNameKey = bestiaryInfoElement1.GetDisplayNameKey();
      string languageKey = "Bestiary_BiomeText.biome_" + displayNameKey.Substring(displayNameKey.IndexOf('.') + 1);
      entry.Info.Add((IBestiaryInfoElement) new FlavorTextBestiaryInfoElement(languageKey));
    }

    private void AddTownNPCs_Manual()
    {
      this.Register(BestiaryEntry.TownNPC(22));
      this.Register(BestiaryEntry.TownNPC(17));
      this.Register(BestiaryEntry.TownNPC(18));
      this.Register(BestiaryEntry.TownNPC(19));
      this.Register(BestiaryEntry.TownNPC(20));
      this.Register(BestiaryEntry.TownNPC(37));
      this.Register(BestiaryEntry.TownNPC(54));
      this.Register(BestiaryEntry.TownNPC(38));
      this.Register(BestiaryEntry.TownNPC(107));
      this.Register(BestiaryEntry.TownNPC(108));
      this.Register(BestiaryEntry.TownNPC(124));
      this.Register(BestiaryEntry.TownNPC(142));
      this.Register(BestiaryEntry.TownNPC(160));
      this.Register(BestiaryEntry.TownNPC(178));
      this.Register(BestiaryEntry.TownNPC(207));
      this.Register(BestiaryEntry.TownNPC(208));
      this.Register(BestiaryEntry.TownNPC(209));
      this.Register(BestiaryEntry.TownNPC(227));
      this.Register(BestiaryEntry.TownNPC(228));
      this.Register(BestiaryEntry.TownNPC(229));
      this.Register(BestiaryEntry.TownNPC(353));
      this.Register(BestiaryEntry.TownNPC(369));
      this.Register(BestiaryEntry.TownNPC(441));
      this.Register(BestiaryEntry.TownNPC(550));
      this.Register(BestiaryEntry.TownNPC(588));
      this.Register(BestiaryEntry.TownNPC(368));
      this.Register(BestiaryEntry.TownNPC(453));
      this.Register(BestiaryEntry.TownNPC(633));
      this.Register(BestiaryEntry.TownNPC(638));
      this.Register(BestiaryEntry.TownNPC(637));
      this.Register(BestiaryEntry.TownNPC(656));
    }

    private void AddMultiEntryNPCS_Manual() => this.Register(BestiaryEntry.Enemy(85)).Icon = (IEntryIcon) new UnlockableNPCEntryIcon(85, ai3: 3f);

    private void AddEmptyEntries_CrittersAndEnemies_Automated()
    {
      HashSet<int> exclusions = BestiaryDatabaseNPCsPopulator.GetExclusions();
      foreach (KeyValuePair<int, NPC> keyValuePair in ContentSamples.NpcsByNetId)
      {
        if (!exclusions.Contains(keyValuePair.Key) && !keyValuePair.Value.isLikeATownNPC)
        {
          if (keyValuePair.Value.CountsAsACritter)
            this.Register(BestiaryEntry.Critter(keyValuePair.Key));
          else
            this.Register(BestiaryEntry.Enemy(keyValuePair.Key));
        }
      }
    }

    private static HashSet<int> GetExclusions()
    {
      HashSet<int> intSet = new HashSet<int>();
      List<int> intList = new List<int>();
      foreach (KeyValuePair<int, NPCID.Sets.NPCBestiaryDrawModifiers> keyValuePair in NPCID.Sets.NPCBestiaryDrawOffset)
      {
        if (keyValuePair.Value.Hide)
          intList.Add(keyValuePair.Key);
      }
      foreach (int num in intList)
        intSet.Add(num);
      return intSet;
    }

    private void AddNPCBiomeRelationships_Automated()
    {
      this.FindEntryByNPCID(357).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(448).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(606).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard
      });
      this.FindEntryByNPCID(211).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(377).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(446).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(595).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(596).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(597).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(598).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(599).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(600).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(601).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(612).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(613).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(25).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(30).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(33).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(112).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(300).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(355).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(358).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(447).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(610).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard
      });
      this.FindEntryByNPCID(210).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(261).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(402).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(403).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(485).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(486).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(487).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(359).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(410).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(604).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay
      });
      this.FindEntryByNPCID(605).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay
      });
      this.FindEntryByNPCID(218).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(361).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(404).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(445).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(626).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(627).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(2).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(74).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(190).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(191).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(192).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(193).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(194).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(217).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(297).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(298).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(356).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(360).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(655).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(653).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(654).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(442).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(444).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(582).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(583).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(584).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(585).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(1).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(59).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(138).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow
      });
      this.FindEntryByNPCID(147).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(265).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(367).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(616).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(617).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(23).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor
      });
      this.FindEntryByNPCID(55).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(57).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(58).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(102).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(157).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(219).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(220).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(236).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(302).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween
      });
      this.FindEntryByNPCID(366).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(465).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(537).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(592).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(607).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(10).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(11).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(12).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(34).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(117).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(118).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(119).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(163).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SpiderNest
      });
      this.FindEntryByNPCID(164).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SpiderNest
      });
      this.FindEntryByNPCID(230).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(241).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(406).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(496).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(497).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(519).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(593).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(625).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(49).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(51).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(60).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(93).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(137).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow
      });
      this.FindEntryByNPCID(184).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(204).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(224).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(259).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(299).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(317).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(318).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(378).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(393).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(494).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(495).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(513).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(514).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(515).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(538).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(539).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(580).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(587).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(16).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(71).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(81).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(183).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(67).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(70).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(75).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(239).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(267).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(288).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(394).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(408).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(428).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar
      });
      this.FindEntryByNPCID(43).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(56).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(72).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(141).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(185).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(374).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(375).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(661).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(388).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(602).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(603).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(115).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(232).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(258).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(409).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(462).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(516).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(42).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(46).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(47).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(69).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(231).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(235).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(247).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(248).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(303).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(304).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(337).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(354).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SpiderNest
      });
      this.FindEntryByNPCID(362).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(363).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(364).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(365).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(395).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(443).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(464).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(508).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(532).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(540).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Party,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(578).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(608).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(609).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(611).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(264).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(101).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(121).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(122).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(132).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(148).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(149).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(168).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(234).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(250).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(257).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(421).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.NebulaPillar
      });
      this.FindEntryByNPCID(470).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(472).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(478).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(546).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(581).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(615).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(256).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(133).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(221).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(252).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(329).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(385).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(427).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar
      });
      this.FindEntryByNPCID(490).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(548).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(63).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(64).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(85).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(629).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(103).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(152).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(174).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(195).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(254).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom
      });
      this.FindEntryByNPCID(260).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(382).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(383).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(386).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(389).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(466).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(467).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(489).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(530).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(175).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(176).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(188).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(3).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(7).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(8).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(9).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(95).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(96).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(97).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(98).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(99).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(100).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(120).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow
      });
      this.FindEntryByNPCID(150).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(151).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(153).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(154).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(158).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(161).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(186).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(187).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(189).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(223).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(233).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(251).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(319).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(320).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(321).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(331).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(332).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(338).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(339).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(340).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(341).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(342).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(350).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(381).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(492).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(510).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(511).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(512).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(552).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(553).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(554).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(590).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(82).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(116).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(166).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(199).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(263).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(371).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(461).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(463).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(523).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(52).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(200).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(244).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID((int) byte.MaxValue).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom
      });
      this.FindEntryByNPCID(384).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(387).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(390).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(418).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(420).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.NebulaPillar
      });
      this.FindEntryByNPCID(460).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(468).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(524).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(525).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert
      });
      this.FindEntryByNPCID(526).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert
      });
      this.FindEntryByNPCID(527).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowUndergroundDesert
      });
      this.FindEntryByNPCID(536).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(566).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(567).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(53).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(169).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(301).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard
      });
      this.FindEntryByNPCID(391).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(405).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(423).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.NebulaPillar
      });
      this.FindEntryByNPCID(438).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(498).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(499).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(500).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(501).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(502).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(503).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(504).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(505).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(506).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(534).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(568).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(569).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(21).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(24).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(26).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(27).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(28).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(29).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(31).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(32).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(44).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(73).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(77).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(78).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(79).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptDesert
      });
      this.FindEntryByNPCID(630).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonDesert
      });
      this.FindEntryByNPCID(80).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowDesert
      });
      this.FindEntryByNPCID(104).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(111).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(140).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(159).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(162).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(196).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(198).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(201).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(202).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(203).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(212).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(213).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(242).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(269).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(270).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(272).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(273).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(275).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(276).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(277).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(278).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(279).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(280).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(281).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(282).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(283).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(284).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(285).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(286).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(287).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(294).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(295).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(296).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(310).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(311).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(312).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(313).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(316).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard
      });
      this.FindEntryByNPCID(326).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(415).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(449).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(450).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(451).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(452).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(471).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins
      });
      this.FindEntryByNPCID(482).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Granite
      });
      this.FindEntryByNPCID(572).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(573).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(143).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostLegion
      });
      this.FindEntryByNPCID(144).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostLegion
      });
      this.FindEntryByNPCID(145).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostLegion
      });
      this.FindEntryByNPCID(155).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(271).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(274).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(314).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(352).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(379).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(509).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(555).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(556).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(557).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(61).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(110).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(206).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(214).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(215).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(216).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
      this.FindEntryByNPCID(225).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain
      });
      this.FindEntryByNPCID(291).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(292).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(293).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(347).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(412).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(413).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(414).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(469).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(473).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(474).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(475).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow
      });
      this.FindEntryByNPCID(476).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(483).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Granite
      });
      this.FindEntryByNPCID(586).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(62).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(131).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(165).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SpiderNest
      });
      this.FindEntryByNPCID(167).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(197).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(226).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(237).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(238).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SpiderNest
      });
      this.FindEntryByNPCID(480).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Marble
      });
      this.FindEntryByNPCID(528).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(529).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(289).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(439).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(440).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(533).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(170).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptIce
      });
      this.FindEntryByNPCID(171).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowIce
      });
      this.FindEntryByNPCID(179).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(180).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonIce
      });
      this.FindEntryByNPCID(181).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(205).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(411).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(424).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.NebulaPillar
      });
      this.FindEntryByNPCID(429).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar
      });
      this.FindEntryByNPCID(481).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Marble
      });
      this.FindEntryByNPCID(240).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(290).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(430).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(431).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(432).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(433).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(434).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(435).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(436).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(479).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(518).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(591).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(45).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(130).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(172).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(305).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(306).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(307).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(308).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(309).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(425).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar
      });
      this.FindEntryByNPCID(426).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar
      });
      this.FindEntryByNPCID(570).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(571).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(417).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(419).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(65).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(372).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(373).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(407).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(542).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(543).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(544).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(545).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(619).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(621).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(622).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(623).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(128).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(177).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(561).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(562).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(563).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(594).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay
      });
      this.FindEntryByNPCID(253).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(129).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(6).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(173).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(399).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(416).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(531).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(83).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(84).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow
      });
      this.FindEntryByNPCID(86).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(330).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(620).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(48).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(268).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(328).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(66).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(182).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(13).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(14).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(15).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(39).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(40).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(41).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(315).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(343).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(94).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(392).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(558).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(559).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(560).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(348).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(349).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(156).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(35).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(68).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(134).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(136).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(135).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(454).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(455).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(456).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(457).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(458).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(459).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(113).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(114).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld
      });
      this.FindEntryByNPCID(564).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(565).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(327).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(520).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian
      });
      this.FindEntryByNPCID(574).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(575).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(246).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(50).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(477).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse
      });
      this.FindEntryByNPCID(541).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(109).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(243).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Blizzard
      });
      this.FindEntryByNPCID(618).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon
      });
      this.FindEntryByNPCID(351).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(249).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(222).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(262).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(87).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(88).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(89).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(90).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(91).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID(92).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky
      });
      this.FindEntryByNPCID((int) sbyte.MaxValue).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(346).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(370).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(4).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(551).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(245).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple
      });
      this.FindEntryByNPCID(576).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(577).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(266).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson
      });
      this.FindEntryByNPCID(325).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon
      });
      this.FindEntryByNPCID(344).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(125).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(126).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(549).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy
      });
      this.FindEntryByNPCID(345).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon
      });
      this.FindEntryByNPCID(422).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar
      });
      this.FindEntryByNPCID(493).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      });
      this.FindEntryByNPCID(507).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.NebulaPillar
      });
      this.FindEntryByNPCID(517).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar
      });
      this.FindEntryByNPCID(491).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates
      });
    }

    private void AddNPCBiomeRelationships_Manual()
    {
      this.FindEntryByNPCID(628).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay
      });
      this.FindEntryByNPCID(-4).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(-3).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(-7).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(1).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(-10).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(-8).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(-9).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(-6).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(-5).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(-2).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption
      });
      this.FindEntryByNPCID(-1).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(81).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(121).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(7).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(8).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(9).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(98).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(99).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(100).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(6).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(94).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption
      });
      this.FindEntryByNPCID(173).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(181).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(183).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(242).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(241).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(174).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(240).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson
      });
      this.FindEntryByNPCID(175).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle);
      this.FindEntryByNPCID(175).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(153).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(52).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime);
      this.FindEntryByNPCID(52).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(58).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(102).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(157).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(51).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle
      });
      this.FindEntryByNPCID(161).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime);
      this.FindEntryByNPCID(161).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(155).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime);
      this.FindEntryByNPCID(155).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(169).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow);
      this.FindEntryByNPCID(169).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow
      });
      this.FindEntryByNPCID(510).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(510).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(511).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(511).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(512).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(512).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(69).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(580).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(580).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(581).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(581).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm
      });
      this.FindEntryByNPCID(78).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert
      });
      this.FindEntryByNPCID(79).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert
      });
      this.FindEntryByNPCID(630).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert
      });
      this.FindEntryByNPCID(80).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowUndergroundDesert
      });
      this.FindEntryByNPCID(533).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(533).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert
      });
      this.FindEntryByNPCID(528).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(528).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowUndergroundDesert
      });
      this.FindEntryByNPCID(529).Info.Remove((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert);
      this.FindEntryByNPCID(529).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert
      });
      this.FindEntryByNPCID(624).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(5).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(139).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(484).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime
      });
      this.FindEntryByNPCID(317).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween
      });
      this.FindEntryByNPCID(318).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween
      });
      this.FindEntryByNPCID(320).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween
      });
      this.FindEntryByNPCID(321).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween
      });
      this.FindEntryByNPCID(319).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween
      });
      this.FindEntryByNPCID(324).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(322).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(323).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(302).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(521).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(332).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas
      });
      this.FindEntryByNPCID(331).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas
      });
      this.FindEntryByNPCID(335).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(336).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(333).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(334).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[3]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(535).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime
      });
      this.FindEntryByNPCID(614).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(225).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(224).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(250).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(632).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard
      });
      this.FindEntryByNPCID(631).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(634).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(635).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom
      });
      this.FindEntryByNPCID(636).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(639).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(640).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(641).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(642).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(643).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(644).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(645).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(646).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(647).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(648).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(649).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(650).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(651).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(652).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns
      });
      this.FindEntryByNPCID(657).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(658).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(660).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(659).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(22).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(17).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(588).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(441).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(124).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(209).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow
      });
      this.FindEntryByNPCID(142).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[2]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas
      });
      this.FindEntryByNPCID(207).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(19).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(178).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert
      });
      this.FindEntryByNPCID(20).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(228).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(227).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle
      });
      this.FindEntryByNPCID(369).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(229).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(353).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean
      });
      this.FindEntryByNPCID(38).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(107).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(54).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
      this.FindEntryByNPCID(108).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(18).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(208).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(550).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow
      });
      this.FindEntryByNPCID(633).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(160).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom
      });
      this.FindEntryByNPCID(637).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(638).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(656).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(368).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface
      });
      this.FindEntryByNPCID(37).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon
      });
      this.FindEntryByNPCID(453).Info.AddRange((IEnumerable<IBestiaryInfoElement>) new IBestiaryInfoElement[1]
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground
      });
    }

    private void AddNPCBiomeRelationships_AddDecorations_Automated()
    {
      foreach (KeyValuePair<int, NPC> keyValuePair in ContentSamples.NpcsByNetId)
      {
        BestiaryEntry entryByNpcid = this.FindEntryByNPCID(keyValuePair.Key);
        if (!entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain))
        {
          if (entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse))
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.EclipseSun);
          if (entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime))
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.Moon);
          if (entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime))
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.Sun);
          if (entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon))
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.PumpkinMoon);
          if (entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon))
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.FrostMoon);
          if (entryByNpcid.Info.Contains((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor))
          {
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.Moon);
            entryByNpcid.AddTags((IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.Meteor);
          }
        }
      }
    }

    public static class CommonTags
    {
      public static List<IBestiaryInfoElement> GetCommonInfoElementsForFilters() => new List<IBestiaryInfoElement>()
      {
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Party,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Graveyard,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Granite,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Marble,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SpiderNest,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundJungle,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCorruption,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptIce,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CorruptUndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCrimson,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundCrimson,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonIce,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.CrimsonUndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundHallow,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowIce,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.HallowUndergroundDesert,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Goblins,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.OldOnesArmy,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Martian,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.PumpkinMoon,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostMoon,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.FrostLegion,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.NebulaPillar,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SolarPillar,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar,
        (IBestiaryInfoElement) BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.StardustPillar
      };

      public static class SpawnConditions
      {
        public static class Invasions
        {
          public static SpawnConditionBestiaryInfoElement Goblins = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.Goblins", 49, "Images/MapBG1");
          public static SpawnConditionBestiaryInfoElement Pirates = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.Pirates", 50, "Images/MapBG11");
          public static SpawnConditionBestiaryInfoElement Martian = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.Martian", 53, "Images/MapBG1", new Color?(new Color(35, 40, 40)));
          public static SpawnConditionBestiaryInfoElement OldOnesArmy = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.OldOnesArmy", 55, "Images/MapBG1");
          public static SpawnConditionBestiaryInfoElement PumpkinMoon = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.PumpkinMoon", 51, "Images/MapBG1", new Color?(new Color(35, 40, 40)));
          public static SpawnConditionBestiaryInfoElement FrostMoon = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.FrostMoon", 52, "Images/MapBG12", new Color?(new Color(35, 40, 40)));
          public static SpawnConditionBestiaryInfoElement FrostLegion = new SpawnConditionBestiaryInfoElement("Bestiary_Invasions.FrostLegion", 54, "Images/MapBG12");
        }

        public static class Events
        {
          public static SpawnConditionBestiaryInfoElement SlimeRain;
          public static SpawnConditionBestiaryInfoElement WindyDay;
          public static SpawnConditionBestiaryInfoElement BloodMoon;
          public static SpawnConditionBestiaryInfoElement Halloween;
          public static SpawnConditionBestiaryOverlayInfoElement Rain;
          public static SpawnConditionBestiaryInfoElement Christmas;
          public static SpawnConditionBestiaryInfoElement Eclipse;
          public static SpawnConditionBestiaryInfoElement Party;
          public static SpawnConditionBestiaryOverlayInfoElement Blizzard;
          public static SpawnConditionBestiaryOverlayInfoElement Sandstorm;

          static Events()
          {
            SpawnConditionBestiaryInfoElement bestiaryInfoElement1 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.SlimeRain", 47, "Images/MapBG1");
            bestiaryInfoElement1.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.SlimeRain = bestiaryInfoElement1;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement2 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.WindyDay", 41, "Images/MapBG1");
            bestiaryInfoElement2.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.WindyDay = bestiaryInfoElement2;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement3 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.BloodMoon", 38, "Images/MapBG26", new Color?(new Color(200, 190, 180)));
            bestiaryInfoElement3.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon = bestiaryInfoElement3;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement4 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.Halloween", 45, "Images/MapBG1");
            bestiaryInfoElement4.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Halloween = bestiaryInfoElement4;
            SpawnConditionBestiaryOverlayInfoElement overlayInfoElement1 = new SpawnConditionBestiaryOverlayInfoElement("Bestiary_Events.Rain", 40, "Images/MapBGOverlay2", new Color?(new Color(200, 200, 200)));
            overlayInfoElement1.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain = overlayInfoElement1;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement5 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.Christmas", 46, "Images/MapBG12");
            bestiaryInfoElement5.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Christmas = bestiaryInfoElement5;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement6 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.Eclipse", 39, "Images/MapBG1", new Color?(new Color(60, 30, 0)));
            bestiaryInfoElement6.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Eclipse = bestiaryInfoElement6;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement7 = new SpawnConditionBestiaryInfoElement("Bestiary_Events.Party", 48, "Images/MapBG1");
            bestiaryInfoElement7.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Party = bestiaryInfoElement7;
            SpawnConditionBestiaryOverlayInfoElement overlayInfoElement2 = new SpawnConditionBestiaryOverlayInfoElement("Bestiary_Events.Blizzard", 42, "Images/MapBGOverlay6", new Color?(Color.White));
            overlayInfoElement2.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Blizzard = overlayInfoElement2;
            SpawnConditionBestiaryOverlayInfoElement overlayInfoElement3 = new SpawnConditionBestiaryOverlayInfoElement("Bestiary_Events.Sandstorm", 43, "Images/MapBGOverlay1", new Color?(Color.White));
            overlayInfoElement3.DisplayTextPriority = 1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Sandstorm = overlayInfoElement3;
          }
        }

        public static class Biomes
        {
          public static SpawnConditionBestiaryInfoElement TheCorruption = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.TheCorruption", 7, "Images/MapBG6", new Color?(new Color(200, 200, 200)));
          public static SpawnConditionBestiaryInfoElement TheCrimson = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Crimson", 12, "Images/MapBG7", new Color?(new Color(200, 200, 200)));
          public static SpawnConditionBestiaryInfoElement Surface = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Surface", 0, "Images/MapBG1");
          public static SpawnConditionBestiaryInfoElement Graveyard = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Graveyard", 35, "Images/MapBG27");
          public static SpawnConditionBestiaryInfoElement UndergroundJungle = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundJungle", 23, "Images/MapBG13");
          public static SpawnConditionBestiaryInfoElement TheUnderworld = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.TheUnderworld", 33, "Images/MapBG3");
          public static SpawnConditionBestiaryInfoElement TheDungeon = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.TheDungeon", 32, "Images/MapBG5");
          public static SpawnConditionBestiaryInfoElement Underground = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Underground", 1, "Images/MapBG2");
          public static SpawnConditionBestiaryInfoElement TheHallow = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.TheHallow", 17, "Images/MapBG8");
          public static SpawnConditionBestiaryInfoElement UndergroundMushroom = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundMushroom", 25, "Images/MapBG21");
          public static SpawnConditionBestiaryInfoElement Jungle = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Jungle", 22, "Images/MapBG9");
          public static SpawnConditionBestiaryInfoElement Caverns = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Caverns", 2, "Images/MapBG32");
          public static SpawnConditionBestiaryInfoElement UndergroundSnow = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundSnow", 6, "Images/MapBG4");
          public static SpawnConditionBestiaryInfoElement Ocean = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Ocean", 28, "Images/MapBG11");
          public static SpawnConditionBestiaryInfoElement SurfaceMushroom = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.SurfaceMushroom", 24, "Images/MapBG20");
          public static SpawnConditionBestiaryInfoElement UndergroundDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundDesert", 4, "Images/MapBG15");
          public static SpawnConditionBestiaryInfoElement Snow = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Snow", 5, "Images/MapBG12");
          public static SpawnConditionBestiaryInfoElement Desert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Desert", 3, "Images/MapBG10");
          public static SpawnConditionBestiaryInfoElement Meteor = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Meteor", 44, "Images/MapBG1", new Color?(new Color(35, 40, 40)));
          public static SpawnConditionBestiaryInfoElement Oasis = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Oasis", 27, "Images/MapBG10");
          public static SpawnConditionBestiaryInfoElement SpiderNest = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.SpiderNest", 34, "Images/MapBG19");
          public static SpawnConditionBestiaryInfoElement TheTemple = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.TheTemple", 31, "Images/MapBG14");
          public static SpawnConditionBestiaryInfoElement CorruptUndergroundDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.CorruptUndergroundDesert", 10, "Images/MapBG40");
          public static SpawnConditionBestiaryInfoElement CrimsonUndergroundDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.CrimsonUndergroundDesert", 15, "Images/MapBG41");
          public static SpawnConditionBestiaryInfoElement HallowUndergroundDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.HallowUndergroundDesert", 20, "Images/MapBG42");
          public static SpawnConditionBestiaryInfoElement CorruptDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.CorruptDesert", 9, "Images/MapBG37");
          public static SpawnConditionBestiaryInfoElement CrimsonDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.CrimsonDesert", 14, "Images/MapBG38");
          public static SpawnConditionBestiaryInfoElement HallowDesert = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.HallowDesert", 19, "Images/MapBG39");
          public static SpawnConditionBestiaryInfoElement Granite = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Granite", 30, "Images/MapBG17", new Color?(new Color(100, 100, 100)));
          public static SpawnConditionBestiaryInfoElement UndergroundCorruption = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundCorruption", 8, "Images/MapBG23");
          public static SpawnConditionBestiaryInfoElement UndergroundCrimson = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundCrimson", 13, "Images/MapBG24");
          public static SpawnConditionBestiaryInfoElement UndergroundHallow = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.UndergroundHallow", 18, "Images/MapBG22");
          public static SpawnConditionBestiaryInfoElement Marble = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Marble", 29, "Images/MapBG18");
          public static SpawnConditionBestiaryInfoElement CorruptIce = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.CorruptIce", 11, "Images/MapBG34", new Color?(new Color(200, 200, 200)));
          public static SpawnConditionBestiaryInfoElement HallowIce = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.HallowIce", 21, "Images/MapBG36", new Color?(new Color(200, 200, 200)));
          public static SpawnConditionBestiaryInfoElement CrimsonIce = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.CrimsonIce", 16, "Images/MapBG35", new Color?(new Color(200, 200, 200)));
          public static SpawnConditionBestiaryInfoElement Sky = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.Sky", 26, "Images/MapBG33");
          public static SpawnConditionBestiaryInfoElement NebulaPillar = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.NebulaPillar", 58, "Images/MapBG28");
          public static SpawnConditionBestiaryInfoElement SolarPillar = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.SolarPillar", 56, "Images/MapBG29");
          public static SpawnConditionBestiaryInfoElement VortexPillar = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.VortexPillar", 57, "Images/MapBG30");
          public static SpawnConditionBestiaryInfoElement StardustPillar = new SpawnConditionBestiaryInfoElement("Bestiary_Biomes.StardustPillar", 59, "Images/MapBG31");
        }

        public static class Times
        {
          public static SpawnConditionBestiaryInfoElement DayTime;
          public static SpawnConditionBestiaryInfoElement NightTime;

          static Times()
          {
            SpawnConditionBestiaryInfoElement bestiaryInfoElement1 = new SpawnConditionBestiaryInfoElement("Bestiary_Times.DayTime", 36);
            bestiaryInfoElement1.DisplayTextPriority = -1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime = bestiaryInfoElement1;
            SpawnConditionBestiaryInfoElement bestiaryInfoElement2 = new SpawnConditionBestiaryInfoElement("Bestiary_Times.NightTime", 37, "Images/MapBG1", new Color?(new Color(35, 40, 40)));
            bestiaryInfoElement2.DisplayTextPriority = -1;
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime = bestiaryInfoElement2;
          }
        }

        public static class Visuals
        {
          public static SpawnConditionDecorativeOverlayInfoElement Sun = new SpawnConditionDecorativeOverlayInfoElement("Images/MapBGOverlay3", new Color?(Color.White))
          {
            DisplayPriority = 1f
          };
          public static SpawnConditionDecorativeOverlayInfoElement Moon = new SpawnConditionDecorativeOverlayInfoElement("Images/MapBGOverlay4", new Color?(Color.White))
          {
            DisplayPriority = 1f
          };
          public static SpawnConditionDecorativeOverlayInfoElement EclipseSun = new SpawnConditionDecorativeOverlayInfoElement("Images/MapBGOverlay5", new Color?(Color.White))
          {
            DisplayPriority = 1f
          };
          public static SpawnConditionDecorativeOverlayInfoElement PumpkinMoon = new SpawnConditionDecorativeOverlayInfoElement("Images/MapBGOverlay8", new Color?(Color.White))
          {
            DisplayPriority = 1f
          };
          public static SpawnConditionDecorativeOverlayInfoElement FrostMoon = new SpawnConditionDecorativeOverlayInfoElement("Images/MapBGOverlay9", new Color?(Color.White))
          {
            DisplayPriority = 1f
          };
          public static SpawnConditionDecorativeOverlayInfoElement Meteor = new SpawnConditionDecorativeOverlayInfoElement("Images/MapBGOverlay7", new Color?(Color.White))
          {
            DisplayPriority = 1f
          };
        }
      }
    }

    public static class Conditions
    {
      public static bool ReachHardMode() => Main.hardMode;
    }

    public static class CrownosIconIndexes
    {
      public const int Surface = 0;
      public const int Underground = 1;
      public const int Cave = 2;
      public const int Desert = 3;
      public const int UndergroundDesert = 4;
      public const int Snow = 5;
      public const int UndergroundIce = 6;
      public const int Corruption = 7;
      public const int CorruptionUnderground = 8;
      public const int CorruptionDesert = 9;
      public const int CorruptionUndergroundDesert = 10;
      public const int CorruptionIce = 11;
      public const int Crimson = 12;
      public const int CrimsonUnderground = 13;
      public const int CrimsonDesert = 14;
      public const int CrimsonUndergroundDesert = 15;
      public const int CrimsonIce = 16;
      public const int Hallow = 17;
      public const int HallowUnderground = 18;
      public const int HallowDesert = 19;
      public const int HallowUndergroundDesert = 20;
      public const int HallowIce = 21;
      public const int Jungle = 22;
      public const int UndergroundJungle = 23;
      public const int SurfaceMushroom = 24;
      public const int UndergroundMushroom = 25;
      public const int Sky = 26;
      public const int Oasis = 27;
      public const int Ocean = 28;
      public const int Marble = 29;
      public const int Granite = 30;
      public const int JungleTemple = 31;
      public const int Dungeon = 32;
      public const int Underworld = 33;
      public const int SpiderNest = 34;
      public const int Graveyard = 35;
      public const int Day = 36;
      public const int Night = 37;
      public const int BloodMoon = 38;
      public const int Eclipse = 39;
      public const int Rain = 40;
      public const int WindyDay = 41;
      public const int Blizzard = 42;
      public const int Sandstorm = 43;
      public const int Meteor = 44;
      public const int Halloween = 45;
      public const int Christmas = 46;
      public const int SlimeRain = 47;
      public const int Party = 48;
      public const int GoblinInvasion = 49;
      public const int PirateInvasion = 50;
      public const int PumpkinMoon = 51;
      public const int FrostMoon = 52;
      public const int AlienInvasion = 53;
      public const int FrostLegion = 54;
      public const int OldOnesArmy = 55;
      public const int SolarTower = 56;
      public const int VortexTower = 57;
      public const int NebulaTower = 58;
      public const int StardustTower = 59;
      public const int Hardmode = 60;
      public const int ItemSpawn = 61;
    }
  }
}
