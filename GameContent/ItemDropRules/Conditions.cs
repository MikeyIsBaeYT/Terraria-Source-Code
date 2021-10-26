// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.Conditions
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Localization;

namespace Terraria.GameContent.ItemDropRules
{
  public class Conditions
  {
    private static bool SoulOfWhateverConditionCanDrop(DropAttemptInfo info)
    {
      if (info.npc.boss)
        return false;
      switch (info.npc.type)
      {
        case 1:
        case 13:
        case 14:
        case 15:
        case 121:
        case 535:
          return false;
        default:
          return Main.hardMode && info.npc.lifeMax > 1 && !info.npc.friendly && (double) info.npc.position.Y > Main.rockLayer * 16.0 && (double) info.npc.value >= 1.0;
      }
    }

    public class NeverTrue : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => false;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class IsUsingSpecificAIValues : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      private int _aiSlotToCheck;
      private float _valueToMatch;

      public IsUsingSpecificAIValues(int aislot, float valueToMatch)
      {
        this._aiSlotToCheck = aislot;
        this._valueToMatch = valueToMatch;
      }

      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.ai[this._aiSlotToCheck] == (double) this._valueToMatch;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class FrostMoonDropGatingChance : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info)
      {
        if (!Main.snowMoon)
          return false;
        int waveNumber = NPC.waveNumber;
        if (Main.expertMode)
          waveNumber += 7;
        int range = (int) ((double) (30 - waveNumber) / 2.5);
        if (Main.expertMode)
          range -= 2;
        if (range < 1)
          range = 1;
        return info.player.RollLuck(range) == 0;
      }

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class PumpkinMoonDropGatingChance : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info)
      {
        if (!Main.pumpkinMoon)
          return false;
        int waveNumber = NPC.waveNumber;
        if (Main.expertMode)
          waveNumber += 6;
        int range = (int) ((double) (17 - waveNumber) / 1.25);
        if (Main.expertMode)
          --range;
        if (range < 1)
          range = 1;
        return info.player.RollLuck(range) == 0;
      }

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class FrostMoonDropGateForTrophies : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info)
      {
        if (!Main.snowMoon)
          return false;
        int waveNumber = NPC.waveNumber;
        if (NPC.waveNumber < 15)
          return false;
        int maxValue = 4;
        if (waveNumber == 16)
          maxValue = 4;
        if (waveNumber == 17)
          maxValue = 3;
        if (waveNumber == 18)
          maxValue = 3;
        if (waveNumber == 19)
          maxValue = 2;
        if (waveNumber >= 20)
          maxValue = 2;
        if (Main.expertMode && Main.rand.Next(3) == 0)
          --maxValue;
        return info.rng.Next(maxValue) == 0;
      }

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class IsPumpkinMoon : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.pumpkinMoon;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class FromCertainWaveAndAbove : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      private int _neededWave;

      public FromCertainWaveAndAbove(int neededWave) => this._neededWave = neededWave;

      public bool CanDrop(DropAttemptInfo info) => NPC.waveNumber >= this._neededWave;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class IsBloodMoonAndNotFromStatue : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !Main.dayTime && Main.bloodMoon && !info.npc.SpawnedFromStatue && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class DownedAllMechBosses : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class DownedPlantera : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => NPC.downedPlantBoss;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class FirstTimeKillingPlantera : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !NPC.downedPlantBoss;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class MechanicalBossesDummyCondition : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => true;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class PirateMap : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && (double) info.npc.position.Y / 16.0 < Main.worldSurface + 10.0 && ((double) info.npc.Center.X / 16.0 < 380.0 || (double) info.npc.Center.X / 16.0 > (double) (Main.maxTilesX - 380)) && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.PirateMap");
    }

    public class IsChristmas : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.xMas;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsChristmas");
    }

    public class NotExpert : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !Main.expertMode;

      public bool CanShowItemDropInUI() => !Main.expertMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.NotExpert");
    }

    public class NotMasterMode : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !Main.masterMode;

      public bool CanShowItemDropInUI() => !Main.masterMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.NotMasterMode");
    }

    public class MissingTwin : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info)
      {
        int Type = 125;
        if (info.npc.type == 125)
          Type = 126;
        return !NPC.AnyNPCs(Type);
      }

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class EmpressOfLightIsGenuinelyEnraged : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => info.npc.AI_120_HallowBoss_IsGenuinelyEnraged();

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.EmpressOfLightOnlyTookDamageWhileEnraged");
    }

    public class PlayerNeedsHealing : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => info.player.statLife < info.player.statLifeMax2;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.PlayerNeedsHealing");
    }

    public class LegacyHack_IsBossAndExpert : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => info.npc.boss && Main.expertMode;

      public bool CanShowItemDropInUI() => Main.expertMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.LegacyHack_IsBossAndExpert");
    }

    public class LegacyHack_IsBossAndNotExpert : 
      IItemDropRuleCondition,
      IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => info.npc.boss && !Main.expertMode;

      public bool CanShowItemDropInUI() => !Main.expertMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.LegacyHack_IsBossAndNotExpert");
    }

    public class LegacyHack_IsABoss : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => info.npc.boss;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => (string) null;
    }

    public class IsExpert : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.expertMode;

      public bool CanShowItemDropInUI() => Main.expertMode;

      public string GetConditionDescription() => Main.masterMode ? Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode") : Language.GetTextValue("Bestiary_ItemDropConditions.IsExpert");
    }

    public class IsMasterMode : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.masterMode;

      public bool CanShowItemDropInUI() => Main.masterMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode");
    }

    public class IsCrimson : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => WorldGen.crimson;

      public bool CanShowItemDropInUI() => WorldGen.crimson;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsCrimson");
    }

    public class IsCorruption : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !WorldGen.crimson;

      public bool CanShowItemDropInUI() => !WorldGen.crimson;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsCorruption");
    }

    public class IsCrimsonAndNotExpert : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => WorldGen.crimson && !Main.expertMode;

      public bool CanShowItemDropInUI() => WorldGen.crimson && !Main.expertMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsCrimsonAndNotExpert");
    }

    public class IsCorruptionAndNotExpert : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !WorldGen.crimson && !Main.expertMode;

      public bool CanShowItemDropInUI() => !WorldGen.crimson && !Main.expertMode;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsCorruptionAndNotExpert");
    }

    public class HalloweenWeapons : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info)
      {
        float num1 = 500f * Main.GameModeInfo.EnemyMoneyDropMultiplier;
        float num2 = 40f * Main.GameModeInfo.EnemyDamageMultiplier;
        float num3 = 20f * Main.GameModeInfo.EnemyDefenseMultiplier;
        return Main.halloween && (double) info.npc.value > 0.0 && (double) info.npc.value < (double) num1 && (double) info.npc.damage < (double) num2 && (double) info.npc.defense < (double) num3 && !info.IsInSimulation;
      }

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.HalloweenWeapons");
    }

    public class SoulOfNight : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info)
      {
        if (!Conditions.SoulOfWhateverConditionCanDrop(info))
          return false;
        return info.player.ZoneCorrupt || info.player.ZoneCrimson;
      }

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.SoulOfNight");
    }

    public class SoulOfLight : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Conditions.SoulOfWhateverConditionCanDrop(info) && info.player.ZoneHallow;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.SoulOfLight");
    }

    public class NotFromStatue : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !info.npc.SpawnedFromStatue;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.NotFromStatue");
    }

    public class HalloweenGoodieBagDrop : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.halloween && info.npc.lifeMax > 1 && info.npc.damage > 0 && !info.npc.friendly && info.npc.type != 121 && info.npc.type != 23 && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.HalloweenGoodieBagDrop");
    }

    public class XmasPresentDrop : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.xMas && info.npc.lifeMax > 1 && info.npc.damage > 0 && !info.npc.friendly && info.npc.type != 121 && info.npc.type != 23 && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.XmasPresentDrop");
    }

    public class LivingFlames : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => info.npc.lifeMax > 5 && (double) info.npc.value > 0.0 && !info.npc.friendly && Main.hardMode && (double) info.npc.position.Y / 16.0 > (double) Main.UnderworldLayer && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.LivingFlames");
    }

    public class NamedNPC : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      private string _neededName;

      public NamedNPC(string neededName) => this._neededName = neededName;

      public bool CanDrop(DropAttemptInfo info) => info.npc.GivenOrTypeName == this._neededName;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.NamedNPC");
    }

    public class HallowKeyCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && !info.IsInSimulation && info.player.ZoneHallow;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.HallowKeyCondition");
    }

    public class JungleKeyCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && !info.IsInSimulation && info.player.ZoneJungle;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.JungleKeyCondition");
    }

    public class CorruptKeyCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && !info.IsInSimulation && info.player.ZoneCorrupt;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.CorruptKeyCondition");
    }

    public class CrimsonKeyCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && !info.IsInSimulation && info.player.ZoneCrimson;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.CrimsonKeyCondition");
    }

    public class FrozenKeyCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && !info.IsInSimulation && info.player.ZoneSnow;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.FrozenKeyCondition");
    }

    public class DesertKeyCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => (double) info.npc.value > 0.0 && Main.hardMode && !info.IsInSimulation && info.player.ZoneDesert && !info.player.ZoneBeach;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.DesertKeyCondition");
    }

    public class BeatAnyMechBoss : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => NPC.downedMechBossAny;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.BeatAnyMechBoss");
    }

    public class YoyoCascade : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => !Main.hardMode && info.npc.HasPlayerTarget && info.npc.lifeMax > 5 && !info.npc.friendly && (double) info.npc.position.Y / 16.0 > (double) (Main.maxTilesY - 350) && NPC.downedBoss3 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.YoyoCascade");
    }

    public class YoyosAmarok : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.hardMode && info.npc.HasPlayerTarget && info.player.ZoneSnow && info.npc.lifeMax > 5 && !info.npc.friendly && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.YoyosAmarok");
    }

    public class YoyosYelets : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.hardMode && info.player.ZoneJungle && NPC.downedMechBossAny && info.npc.lifeMax > 5 && info.npc.HasPlayerTarget && !info.npc.friendly && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.YoyosYelets");
    }

    public class YoyosKraken : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.hardMode && info.player.ZoneDungeon && NPC.downedPlantBoss && info.npc.lifeMax > 5 && info.npc.HasPlayerTarget && !info.npc.friendly && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.YoyosKraken");
    }

    public class YoyosHelFire : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.hardMode && !info.player.ZoneDungeon && (double) info.npc.position.Y / 16.0 > (Main.rockLayer + (double) (Main.maxTilesY * 2)) / 3.0 && info.npc.lifeMax > 5 && info.npc.HasPlayerTarget && !info.npc.friendly && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.YoyosHelFire");
    }

    public class KOCannon : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.hardMode && Main.bloodMoon && (double) info.npc.value > 0.0 && !info.IsInSimulation;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.KOCannon");
    }

    public class WindyEnoughForKiteDrops : IItemDropRuleCondition, IProvideItemConditionDescription
    {
      public bool CanDrop(DropAttemptInfo info) => Main.WindyEnoughForKiteDrops;

      public bool CanShowItemDropInUI() => true;

      public string GetConditionDescription() => Language.GetTextValue("Bestiary_ItemDropConditions.IsItAHappyWindyDay");
    }
  }
}
