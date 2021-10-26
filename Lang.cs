// Decompiled with JetBrains decompiler
// Type: Terraria.Lang
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.UI;

namespace Terraria
{
  public class Lang
  {
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] menu = new LocalizedText[253];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] gen = new LocalizedText[91];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] misc = new LocalizedText[201];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] inter = new LocalizedText[129];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] tip = new LocalizedText[61];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] mp = new LocalizedText[23];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] chestType = new LocalizedText[52];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] dresserType = new LocalizedText[40];
    [Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
    public static LocalizedText[] chestType2 = new LocalizedText[14];
    public static LocalizedText[] prefix = new LocalizedText[85];
    public static LocalizedText[] _mapLegendCache;
    private static LocalizedText[] _itemNameCache = new LocalizedText[5045];
    private static LocalizedText[] _projectileNameCache = new LocalizedText[950];
    private static LocalizedText[] _npcNameCache = new LocalizedText[663];
    private static LocalizedText[] _negativeNpcNameCache = new LocalizedText[65];
    private static LocalizedText[] _buffNameCache = new LocalizedText[323];
    private static LocalizedText[] _buffDescriptionCache = new LocalizedText[323];
    private static ItemTooltip[] _itemTooltipCache = new ItemTooltip[5045];
    private static LocalizedText[] _emojiNameCache = new LocalizedText[145];

    public static string GetMapObjectName(int id) => Lang._mapLegendCache != null ? Lang._mapLegendCache[id].Value : string.Empty;

    public static object CreateDialogSubstitutionObject(NPC npc = null) => (object) new
    {
      Nurse = NPC.GetFirstNPCNameOrNull(18),
      Merchant = NPC.GetFirstNPCNameOrNull(17),
      ArmsDealer = NPC.GetFirstNPCNameOrNull(19),
      Dryad = NPC.GetFirstNPCNameOrNull(20),
      Demolitionist = NPC.GetFirstNPCNameOrNull(38),
      Clothier = NPC.GetFirstNPCNameOrNull(54),
      Guide = NPC.GetFirstNPCNameOrNull(22),
      Wizard = NPC.GetFirstNPCNameOrNull(108),
      GoblinTinkerer = NPC.GetFirstNPCNameOrNull(107),
      Mechanic = NPC.GetFirstNPCNameOrNull(124),
      Truffle = NPC.GetFirstNPCNameOrNull(160),
      Steampunker = NPC.GetFirstNPCNameOrNull(178),
      DyeTrader = NPC.GetFirstNPCNameOrNull(207),
      PartyGirl = NPC.GetFirstNPCNameOrNull(208),
      Cyborg = NPC.GetFirstNPCNameOrNull(209),
      Painter = NPC.GetFirstNPCNameOrNull(227),
      WitchDoctor = NPC.GetFirstNPCNameOrNull(228),
      Pirate = NPC.GetFirstNPCNameOrNull(229),
      Stylist = NPC.GetFirstNPCNameOrNull(353),
      TravelingMerchant = NPC.GetFirstNPCNameOrNull(368),
      Angler = NPC.GetFirstNPCNameOrNull(369),
      Bartender = NPC.GetFirstNPCNameOrNull(550),
      WorldName = Main.worldName,
      Day = Main.dayTime,
      BloodMoon = Main.bloodMoon,
      Eclipse = Main.eclipse,
      MoonLordDefeated = NPC.downedMoonlord,
      HardMode = Main.hardMode,
      Homeless = (npc != null && npc.homeless),
      InventoryKey = Main.cInv,
      PlayerName = Main.player[Main.myPlayer].name,
      GolfGuy = NPC.GetFirstNPCNameOrNull(588),
      TaxCollector = NPC.GetFirstNPCNameOrNull(441),
      Rain = Main.raining,
      Graveyard = Main.LocalPlayer.ZoneGraveyard,
      AnglerCompletedQuestsCount = Main.LocalPlayer.anglerQuestsFinished,
      InputTriggerUI_BuildFromInventory = PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "QuickMount"),
      InputTriggerUI_SellItem = PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "SmartSelect"),
      InputTriggerUI_Trash = PlayerInput.GenerateInputTag_ForCurrentGamemode_WithHacks(false, "SmartSelect"),
      InputTriggerUI_FavoriteItem = PlayerInput.GenerateInputTag_ForCurrentGamemode_WithHacks(false, "SmartCursor"),
      InputTrigger_QuickEquip = PlayerInput.GenerateInputTag_ForCurrentGamemode(false, "Grapple"),
      InputTrigger_LockOn = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "LockOn"),
      InputTrigger_RadialQuickbar = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "HotbarMinus"),
      InputTrigger_RadialHotbar = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "HotbarPlus"),
      InputTrigger_SmartCursor = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "SmartCursor"),
      InputTrigger_UseOrAttack = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "MouseLeft"),
      InputTrigger_InteractWithTile = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "MouseRight"),
      InputTrigger_SmartSelect = PlayerInput.GenerateInputTag_ForCurrentGamemode(true, "SmartSelect")
    };

    [Obsolete("dialog is deprecated. Please use Language.GetText instead.")]
    public static string dialog(int l, bool english = false) => Language.GetTextValueWith("LegacyDialog." + (object) l, Lang.CreateDialogSubstitutionObject());

    public static string GetNPCNameValue(int netID) => Lang.GetNPCName(netID).Value;

    public static LocalizedText GetNPCName(int netID)
    {
      if (netID > 0 && netID < 663)
        return Lang._npcNameCache[netID];
      return netID < 0 && -netID - 1 < Lang._negativeNpcNameCache.Length ? Lang._negativeNpcNameCache[-netID - 1] : LocalizedText.Empty;
    }

    public static ItemTooltip GetTooltip(int itemId) => Lang._itemTooltipCache[itemId];

    public static LocalizedText GetItemName(int id)
    {
      id = (int) ItemID.FromNetId((short) id);
      return id > 0 && id < 5045 && Lang._itemNameCache[id] != null ? Lang._itemNameCache[id] : LocalizedText.Empty;
    }

    public static LocalizedText GetEmojiName(int id) => id >= 0 && id < 145 && Lang._emojiNameCache[id] != null ? Lang._emojiNameCache[id] : LocalizedText.Empty;

    public static string GetItemNameValue(int id) => Lang.GetItemName(id).Value;

    public static string GetBuffName(int id) => Lang._buffNameCache[id].Value;

    public static string GetBuffDescription(int id) => Lang._buffDescriptionCache[id].Value;

    public static string GetDryadWorldStatusDialog()
    {
      int tGood = (int) WorldGen.tGood;
      int tEvil = (int) WorldGen.tEvil;
      int tBlood = (int) WorldGen.tBlood;
      string textValue;
      if (tGood > 0 && tEvil > 0 && tBlood > 0)
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusAll", (object) Main.worldName, (object) tGood, (object) tEvil, (object) tBlood);
      else if (tGood > 0 && tEvil > 0)
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCorrupt", (object) Main.worldName, (object) tGood, (object) tEvil);
      else if (tGood > 0 && tBlood > 0)
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCrimson", (object) Main.worldName, (object) tGood, (object) tBlood);
      else if (tEvil > 0 && tBlood > 0)
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusCorruptCrimson", (object) Main.worldName, (object) tEvil, (object) tBlood);
      else if (tEvil > 0)
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusCorrupt", (object) Main.worldName, (object) tEvil);
      else if (tBlood > 0)
      {
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusCrimson", (object) Main.worldName, (object) tBlood);
      }
      else
      {
        if (tGood <= 0)
          return Language.GetTextValue("DryadSpecialText.WorldStatusPure", (object) Main.worldName);
        textValue = Language.GetTextValue("DryadSpecialText.WorldStatusHallow", (object) Main.worldName, (object) tGood);
      }
      string str = (double) tGood * 1.2 < (double) (tEvil + tBlood) || (double) tGood * 0.8 > (double) (tEvil + tBlood) ? (tGood < tEvil + tBlood ? (tEvil + tBlood <= tGood + 20 ? (tEvil + tBlood <= 5 ? Language.GetTextValue("DryadSpecialText.WorldDescriptionClose") : Language.GetTextValue("DryadSpecialText.WorldDescriptionWork")) : Language.GetTextValue("DryadSpecialText.WorldDescriptionGrim")) : Language.GetTextValue("DryadSpecialText.WorldDescriptionFairyTale")) : Language.GetTextValue("DryadSpecialText.WorldDescriptionBalanced");
      return string.Format("{0} {1}", (object) textValue, (object) str);
    }

    public static string GetRandomGameTitle() => Language.RandomFromCategory("GameTitle").Value;

    public static string DyeTraderQuestChat(bool gotDye = false)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject();
      LocalizedText[] all = Language.FindAll(Lang.CreateDialogFilter(gotDye ? "DyeTraderSpecialText.HasPlant" : "DyeTraderSpecialText.NoPlant", substitutionObject));
      return all[Main.rand.Next(all.Length)].FormatWith(substitutionObject);
    }

    public static string AnglerQuestCountChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      return Language.SelectRandom(Lang.CreateDialogFilter("AnglerQuestChatter.", substitutionObject)).FormatWith(substitutionObject);
    }

    public static string BartenderHelpText(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      Player player = Main.player[Main.myPlayer];
      if (player.bartenderQuestLog == 0)
      {
        ++player.bartenderQuestLog;
        Item newItem = new Item();
        newItem.SetDefaults(3817);
        newItem.stack = 5;
        newItem.position = player.Center;
        Item obj = player.GetItem(player.whoAmI, newItem, GetItemSettings.NPCEntityToPlayerInventorySettings);
        if (obj.stack > 0)
        {
          int number = Item.NewItem((int) player.position.X, (int) player.position.Y, player.width, player.height, obj.type, obj.stack, noGrabDelay: true);
          if (Main.netMode == 1)
            NetMessage.SendData(21, number: number, number2: 1f);
        }
        return Language.GetTextValueWith("BartenderSpecialText.FirstHelp", substitutionObject);
      }
      LocalizedText[] all = Language.FindAll(Lang.CreateDialogFilter("BartenderHelpText.", substitutionObject));
      if (Main.BartenderHelpTextIndex >= all.Length)
        Main.BartenderHelpTextIndex = 0;
      return all[Main.BartenderHelpTextIndex++].FormatWith(substitutionObject);
    }

    public static string BartenderChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      return Main.rand.Next(5) == 0 ? Language.GetTextValueWith(!DD2Event.DownedInvasionT3 ? (!DD2Event.DownedInvasionT2 ? (!DD2Event.DownedInvasionT1 ? "BartenderSpecialText.BeforeDD2Tier1" : "BartenderSpecialText.AfterDD2Tier1") : "BartenderSpecialText.AfterDD2Tier2") : "BartenderSpecialText.AfterDD2Tier3", substitutionObject) : Language.SelectRandom(Lang.CreateDialogFilter("BartenderChatter.", substitutionObject)).FormatWith(substitutionObject);
    }

    public static string GolferChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      return Language.SelectRandom(Lang.CreateDialogFilter("GolferChatter.", substitutionObject)).FormatWith(substitutionObject);
    }

    public static string BestiaryGirlChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      string startsWith = "BestiaryGirlChatter.";
      if (npc.ShouldBestiaryGirlBeLycantrope())
        startsWith = "BestiaryGirlLycantropeChatter.";
      return Language.SelectRandom(Lang.CreateDialogFilter(startsWith, substitutionObject)).FormatWith(substitutionObject);
    }

    public static string CatChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      return Language.SelectRandom(Lang.CreateDialogFilter("CatChatter.", substitutionObject)).FormatWith(substitutionObject);
    }

    public static string DogChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      return Language.SelectRandom(Lang.CreateDialogFilter("DogChatter.", substitutionObject)).FormatWith(substitutionObject);
    }

    public static string BunnyChat(NPC npc)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject(npc);
      return Language.SelectRandom(Lang.CreateDialogFilter("BunnyChatter.", substitutionObject)).FormatWith(substitutionObject);
    }

    public static string GetNPCHouseBannerText(NPC npc, int bannerStyle) => bannerStyle == 1 ? Language.GetTextValue("Game.ReservedForNPC", (object) npc.FullName) : npc.FullName;

    public static LanguageSearchFilter CreateDialogFilter(
      string startsWith,
      object substitutions)
    {
      return (LanguageSearchFilter) ((key, text) => key.StartsWith(startsWith) && text.CanFormatWith(substitutions));
    }

    public static LanguageSearchFilter CreateDialogFilter(string startsWith) => (LanguageSearchFilter) ((key, text) => key.StartsWith(startsWith));

    public static string AnglerQuestChat(bool turnIn = false)
    {
      object substitutionObject = Lang.CreateDialogSubstitutionObject();
      if (turnIn)
        return Language.SelectRandom(Lang.CreateDialogFilter("AnglerQuestText.TurnIn_", substitutionObject)).FormatWith(substitutionObject);
      if (Main.anglerQuestFinished)
        return Language.SelectRandom(Lang.CreateDialogFilter("AnglerQuestText.NoQuest_", substitutionObject)).FormatWith(substitutionObject);
      int anglerQuestItemNetId = Main.anglerQuestItemNetIDs[Main.anglerQuest];
      Main.npcChatCornerItem = anglerQuestItemNetId;
      return Language.GetTextValueWith("AnglerQuestText.Quest_" + ItemID.Search.GetName(anglerQuestItemNetId), substitutionObject);
    }

    public static LocalizedText GetProjectileName(int type) => type >= 0 && type < Lang._projectileNameCache.Length && Lang._projectileNameCache[type] != null ? Lang._projectileNameCache[type] : LocalizedText.Empty;

    private static void FillNameCacheArray<IdClass, IdType>(
      string category,
      LocalizedText[] nameCache,
      bool leaveMissingEntriesBlank = false)
      where IdType : IConvertible
    {
      for (int index = 0; index < nameCache.Length; ++index)
        nameCache[index] = LocalizedText.Empty;
      ((IEnumerable<FieldInfo>) typeof (IdClass).GetFields(BindingFlags.Static | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (f => f.FieldType == typeof (IdType))).ToList<FieldInfo>().ForEach((Action<FieldInfo>) (field =>
      {
        long int64 = Convert.ToInt64((object) (IdType) field.GetValue((object) null));
        if (int64 >= 0L && int64 < (long) nameCache.Length)
        {
          nameCache[(IntPtr) int64] = !leaveMissingEntriesBlank || Language.Exists(category + "." + field.Name) ? Language.GetText(category + "." + field.Name) : LocalizedText.Empty;
        }
        else
        {
          if (!(field.Name == "None"))
            return;
          nameCache[int64] = LocalizedText.Empty;
        }
      }));
    }

    public static void InitializeLegacyLocalization()
    {
      Lang.FillNameCacheArray<PrefixID, int>("Prefix", Lang.prefix);
      for (int index = 0; index < Lang.gen.Length; ++index)
        Lang.gen[index] = Language.GetText("LegacyWorldGen." + (object) index);
      for (int index = 0; index < Lang.menu.Length; ++index)
        Lang.menu[index] = Language.GetText("LegacyMenu." + (object) index);
      for (int index = 0; index < Lang.inter.Length; ++index)
        Lang.inter[index] = Language.GetText("LegacyInterface." + (object) index);
      for (int index = 0; index < Lang.misc.Length; ++index)
        Lang.misc[index] = Language.GetText("LegacyMisc." + (object) index);
      for (int index = 0; index < Lang.mp.Length; ++index)
        Lang.mp[index] = Language.GetText("LegacyMultiplayer." + (object) index);
      for (int index = 0; index < Lang.tip.Length; ++index)
        Lang.tip[index] = Language.GetText("LegacyTooltip." + (object) index);
      for (int index = 0; index < Lang.chestType.Length; ++index)
        Lang.chestType[index] = Language.GetText("LegacyChestType." + (object) index);
      for (int index = 0; index < Lang.chestType2.Length; ++index)
        Lang.chestType2[index] = Language.GetText("LegacyChestType2." + (object) index);
      for (int index = 0; index < Lang.dresserType.Length; ++index)
        Lang.dresserType[index] = Language.GetText("LegacyDresserType." + (object) index);
      Lang.FillNameCacheArray<ItemID, short>("ItemName", Lang._itemNameCache);
      Lang.FillNameCacheArray<ProjectileID, short>("ProjectileName", Lang._projectileNameCache);
      Lang.FillNameCacheArray<NPCID, short>("NPCName", Lang._npcNameCache);
      Lang.FillNameCacheArray<BuffID, int>("BuffName", Lang._buffNameCache);
      Lang.FillNameCacheArray<BuffID, int>("BuffDescription", Lang._buffDescriptionCache);
      Lang.FillNameCacheArray<EmoteID, int>("EmojiName", Lang._emojiNameCache, true);
      for (int id = -65; id < 0; ++id)
        Lang._negativeNpcNameCache[-id - 1] = Lang._npcNameCache[NPCID.FromNetId(id)];
      Lang._negativeNpcNameCache[0] = Language.GetText("NPCName.Slimeling");
      Lang._negativeNpcNameCache[1] = Language.GetText("NPCName.Slimer2");
      Lang._negativeNpcNameCache[2] = Language.GetText("NPCName.GreenSlime");
      Lang._negativeNpcNameCache[3] = Language.GetText("NPCName.Pinky");
      Lang._negativeNpcNameCache[4] = Language.GetText("NPCName.BabySlime");
      Lang._negativeNpcNameCache[5] = Language.GetText("NPCName.BlackSlime");
      Lang._negativeNpcNameCache[6] = Language.GetText("NPCName.PurpleSlime");
      Lang._negativeNpcNameCache[7] = Language.GetText("NPCName.RedSlime");
      Lang._negativeNpcNameCache[8] = Language.GetText("NPCName.YellowSlime");
      Lang._negativeNpcNameCache[9] = Language.GetText("NPCName.JungleSlime");
      Lang._negativeNpcNameCache[53] = Language.GetText("NPCName.SmallRainZombie");
      Lang._negativeNpcNameCache[54] = Language.GetText("NPCName.BigRainZombie");
      ItemTooltip.AddGlobalProcessor((TooltipProcessor) (tooltip =>
      {
        if (tooltip.Contains("<right>"))
        {
          InputMode key = InputMode.XBoxGamepad;
          if (PlayerInput.UsingGamepad)
            key = InputMode.XBoxGamepadUI;
          if (key == InputMode.XBoxGamepadUI)
          {
            string newValue = PlayerInput.BuildCommand("", true, PlayerInput.CurrentProfile.InputModes[key].KeyStatus["MouseRight"]).Replace(": ", "");
            tooltip = tooltip.Replace("<right>", newValue);
          }
          else
            tooltip = tooltip.Replace("<right>", Language.GetTextValue("Controls.RightClick"));
        }
        if (tooltip.Contains("<left>"))
        {
          InputMode key = InputMode.XBoxGamepad;
          if (PlayerInput.UsingGamepad)
            key = InputMode.XBoxGamepadUI;
          if (key == InputMode.XBoxGamepadUI)
          {
            string newValue = PlayerInput.BuildCommand("", true, PlayerInput.CurrentProfile.InputModes[key].KeyStatus["MouseLeft"]).Replace(": ", "");
            tooltip = tooltip.Replace("<left>", newValue);
          }
          else
            tooltip = tooltip.Replace("<left>", Language.GetTextValue("Controls.LeftClick"));
        }
        return tooltip;
      }));
      for (int index = 0; index < Lang._itemTooltipCache.Length; ++index)
        Lang._itemTooltipCache[index] = ItemTooltip.None;
      ((IEnumerable<FieldInfo>) typeof (ItemID).GetFields(BindingFlags.Static | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (f => f.FieldType == typeof (short))).ToList<FieldInfo>().ForEach((Action<FieldInfo>) (field =>
      {
        short num = (short) field.GetValue((object) null);
        if (num <= (short) 0 || (int) num >= Lang._itemTooltipCache.Length)
          return;
        Lang._itemTooltipCache[(int) num] = ItemTooltip.FromLanguageKey("ItemTooltip." + field.Name);
      }));
    }

    public static void BuildMapAtlas()
    {
      Lang._mapLegendCache = new LocalizedText[MapHelper.LookupCount()];
      for (int index = 0; index < Lang._mapLegendCache.Length; ++index)
        Lang._mapLegendCache[index] = LocalizedText.Empty;
      for (int tileType = 0; tileType < TileID.Sets.IsATreeTrunk.Length; ++tileType)
      {
        if (TileID.Sets.IsATreeTrunk[tileType])
          Lang._mapLegendCache[MapHelper.TileToLookup(tileType, 0)] = Language.GetText("MapObject.Tree");
      }
      Lang._mapLegendCache[MapHelper.TileToLookup(4, 0)] = Lang._itemNameCache[8];
      Lang._mapLegendCache[MapHelper.TileToLookup(4, 1)] = Lang._itemNameCache[8];
      Lang._mapLegendCache[MapHelper.TileToLookup(6, 0)] = Language.GetText("MapObject.Iron");
      Lang._mapLegendCache[MapHelper.TileToLookup(7, 0)] = Language.GetText("MapObject.Copper");
      Lang._mapLegendCache[MapHelper.TileToLookup(8, 0)] = Language.GetText("MapObject.Gold");
      Lang._mapLegendCache[MapHelper.TileToLookup(9, 0)] = Language.GetText("MapObject.Silver");
      Lang._mapLegendCache[MapHelper.TileToLookup(10, 0)] = Language.GetText("MapObject.Door");
      Lang._mapLegendCache[MapHelper.TileToLookup(11, 0)] = Language.GetText("MapObject.Door");
      Lang._mapLegendCache[MapHelper.TileToLookup(12, 0)] = Lang._itemNameCache[29];
      Lang._mapLegendCache[MapHelper.TileToLookup(13, 0)] = Lang._itemNameCache[31];
      Lang._mapLegendCache[MapHelper.TileToLookup(14, 0)] = Language.GetText("MapObject.Table");
      Lang._mapLegendCache[MapHelper.TileToLookup(469, 0)] = Language.GetText("MapObject.Table");
      Lang._mapLegendCache[MapHelper.TileToLookup(486, 0)] = Lang._itemNameCache[4063];
      Lang._mapLegendCache[MapHelper.TileToLookup(487, 0)] = Lang._itemNameCache[4064];
      Lang._mapLegendCache[MapHelper.TileToLookup(487, 1)] = Lang._itemNameCache[4065];
      Lang._mapLegendCache[MapHelper.TileToLookup(489, 0)] = Lang._itemNameCache[4074];
      Lang._mapLegendCache[MapHelper.TileToLookup(490, 0)] = Lang._itemNameCache[4075];
      Lang._mapLegendCache[MapHelper.TileToLookup(15, 0)] = Language.GetText("MapObject.Chair");
      Lang._mapLegendCache[MapHelper.TileToLookup(15, 1)] = Language.GetText("MapObject.Toilet");
      Lang._mapLegendCache[MapHelper.TileToLookup(16, 0)] = Language.GetText("MapObject.Anvil");
      Lang._mapLegendCache[MapHelper.TileToLookup(17, 0)] = Lang._itemNameCache[33];
      Lang._mapLegendCache[MapHelper.TileToLookup(18, 0)] = Lang._itemNameCache[36];
      Lang._mapLegendCache[MapHelper.TileToLookup(20, 0)] = Language.GetText("MapObject.Sapling");
      Lang._mapLegendCache[MapHelper.TileToLookup(590, 0)] = Language.GetText("MapObject.Sapling");
      Lang._mapLegendCache[MapHelper.TileToLookup(595, 0)] = Language.GetText("MapObject.Sapling");
      Lang._mapLegendCache[MapHelper.TileToLookup(615, 0)] = Language.GetText("MapObject.Sapling");
      Lang._mapLegendCache[MapHelper.TileToLookup(21, 0)] = Lang._itemNameCache[48];
      Lang._mapLegendCache[MapHelper.TileToLookup(467, 0)] = Lang._itemNameCache[48];
      Lang._mapLegendCache[MapHelper.TileToLookup(22, 0)] = Language.GetText("MapObject.Demonite");
      Lang._mapLegendCache[MapHelper.TileToLookup(26, 0)] = Language.GetText("MapObject.DemonAltar");
      Lang._mapLegendCache[MapHelper.TileToLookup(26, 1)] = Language.GetText("MapObject.CrimsonAltar");
      Lang._mapLegendCache[MapHelper.TileToLookup(27, 0)] = Lang._itemNameCache[63];
      Lang._mapLegendCache[MapHelper.TileToLookup(407, 0)] = Language.GetText("MapObject.Fossil");
      Lang._mapLegendCache[MapHelper.TileToLookup(412, 0)] = Lang._itemNameCache[3549];
      Lang._mapLegendCache[MapHelper.TileToLookup(441, 0)] = Lang._itemNameCache[48];
      Lang._mapLegendCache[MapHelper.TileToLookup(468, 0)] = Lang._itemNameCache[48];
      Lang._mapLegendCache[MapHelper.TileToLookup(404, 0)] = Language.GetText("MapObject.DesertFossil");
      for (int option = 0; option < 9; ++option)
        Lang._mapLegendCache[MapHelper.TileToLookup(28, option)] = Language.GetText("MapObject.Pot");
      Lang._mapLegendCache[MapHelper.TileToLookup(37, 0)] = Lang._itemNameCache[116];
      Lang._mapLegendCache[MapHelper.TileToLookup(29, 0)] = Lang._itemNameCache[87];
      Lang._mapLegendCache[MapHelper.TileToLookup(31, 0)] = Lang._itemNameCache[115];
      Lang._mapLegendCache[MapHelper.TileToLookup(31, 1)] = Lang._itemNameCache[3062];
      Lang._mapLegendCache[MapHelper.TileToLookup(32, 0)] = Language.GetText("MapObject.Thorns");
      Lang._mapLegendCache[MapHelper.TileToLookup(33, 0)] = Lang._itemNameCache[105];
      Lang._mapLegendCache[MapHelper.TileToLookup(34, 0)] = Language.GetText("MapObject.Chandelier");
      Lang._mapLegendCache[MapHelper.TileToLookup(35, 0)] = Lang._itemNameCache[1813];
      Lang._mapLegendCache[MapHelper.TileToLookup(36, 0)] = Lang._itemNameCache[1869];
      Lang._mapLegendCache[MapHelper.TileToLookup(476, 0)] = Lang._itemNameCache[4040];
      Lang._mapLegendCache[MapHelper.TileToLookup(42, 0)] = Language.GetText("MapObject.Lantern");
      Lang._mapLegendCache[MapHelper.TileToLookup(48, 0)] = Lang._itemNameCache[147];
      Lang._mapLegendCache[MapHelper.TileToLookup(49, 0)] = Lang._itemNameCache[148];
      Lang._mapLegendCache[MapHelper.TileToLookup(50, 0)] = Lang._itemNameCache[149];
      Lang._mapLegendCache[MapHelper.TileToLookup(51, 0)] = Language.GetText("MapObject.Web");
      Lang._mapLegendCache[MapHelper.TileToLookup(55, 0)] = Lang._itemNameCache[171];
      Lang._mapLegendCache[MapHelper.TileToLookup(454, 0)] = Lang._itemNameCache[3746];
      Lang._mapLegendCache[MapHelper.TileToLookup(455, 0)] = Lang._itemNameCache[3747];
      Lang._mapLegendCache[MapHelper.TileToLookup(452, 0)] = Lang._itemNameCache[3742];
      Lang._mapLegendCache[MapHelper.TileToLookup(456, 0)] = Lang._itemNameCache[3748];
      Lang._mapLegendCache[MapHelper.TileToLookup(453, 0)] = Lang._itemNameCache[3744];
      Lang._mapLegendCache[MapHelper.TileToLookup(453, 1)] = Lang._itemNameCache[3745];
      Lang._mapLegendCache[MapHelper.TileToLookup(453, 2)] = Lang._itemNameCache[3743];
      Lang._mapLegendCache[MapHelper.TileToLookup(573, 0)] = Lang._itemNameCache[4710];
      Lang._mapLegendCache[MapHelper.TileToLookup(63, 0)] = Lang._itemNameCache[177];
      Lang._mapLegendCache[MapHelper.TileToLookup(64, 0)] = Lang._itemNameCache[178];
      Lang._mapLegendCache[MapHelper.TileToLookup(65, 0)] = Lang._itemNameCache[179];
      Lang._mapLegendCache[MapHelper.TileToLookup(66, 0)] = Lang._itemNameCache[180];
      Lang._mapLegendCache[MapHelper.TileToLookup(67, 0)] = Lang._itemNameCache[181];
      Lang._mapLegendCache[MapHelper.TileToLookup(68, 0)] = Lang._itemNameCache[182];
      Lang._mapLegendCache[MapHelper.TileToLookup(566, 0)] = Lang._itemNameCache[999];
      Lang._mapLegendCache[MapHelper.TileToLookup(69, 0)] = Language.GetText("MapObject.Thorn");
      Lang._mapLegendCache[MapHelper.TileToLookup(72, 0)] = Language.GetText("MapObject.GiantMushroom");
      Lang._mapLegendCache[MapHelper.TileToLookup(77, 0)] = Lang._itemNameCache[221];
      Lang._mapLegendCache[MapHelper.TileToLookup(78, 0)] = Lang._itemNameCache[222];
      Lang._mapLegendCache[MapHelper.TileToLookup(79, 0)] = Lang._itemNameCache[224];
      Lang._mapLegendCache[MapHelper.TileToLookup(80, 0)] = Lang._itemNameCache[276];
      Lang._mapLegendCache[MapHelper.TileToLookup(81, 0)] = Lang._itemNameCache[275];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 0)] = Lang._itemNameCache[313];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 1)] = Lang._itemNameCache[314];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 2)] = Lang._itemNameCache[315];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 3)] = Lang._itemNameCache[316];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 4)] = Lang._itemNameCache[317];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 5)] = Lang._itemNameCache[318];
      Lang._mapLegendCache[MapHelper.TileToLookup(82, 6)] = Lang._itemNameCache[2358];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 0)] = Lang._itemNameCache[313];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 1)] = Lang._itemNameCache[314];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 2)] = Lang._itemNameCache[315];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 3)] = Lang._itemNameCache[316];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 4)] = Lang._itemNameCache[317];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 5)] = Lang._itemNameCache[318];
      Lang._mapLegendCache[MapHelper.TileToLookup(83, 6)] = Lang._itemNameCache[2358];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 0)] = Lang._itemNameCache[313];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 1)] = Lang._itemNameCache[314];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 2)] = Lang._itemNameCache[315];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 3)] = Lang._itemNameCache[316];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 4)] = Lang._itemNameCache[317];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 5)] = Lang._itemNameCache[318];
      Lang._mapLegendCache[MapHelper.TileToLookup(84, 6)] = Lang._itemNameCache[2358];
      Lang._mapLegendCache[MapHelper.TileToLookup(85, 0)] = Lang._itemNameCache[321];
      Lang._mapLegendCache[MapHelper.TileToLookup(86, 0)] = Lang._itemNameCache[332];
      Lang._mapLegendCache[MapHelper.TileToLookup(87, 0)] = Lang._itemNameCache[333];
      Lang._mapLegendCache[MapHelper.TileToLookup(88, 0)] = Lang._itemNameCache[334];
      Lang._mapLegendCache[MapHelper.TileToLookup(89, 0)] = Lang._itemNameCache[335];
      Lang._mapLegendCache[MapHelper.TileToLookup(90, 0)] = Lang._itemNameCache[336];
      Lang._mapLegendCache[MapHelper.TileToLookup(91, 0)] = Language.GetText("MapObject.Banner");
      Lang._mapLegendCache[MapHelper.TileToLookup(92, 0)] = Lang._itemNameCache[341];
      Lang._mapLegendCache[MapHelper.TileToLookup(93, 0)] = Language.GetText("MapObject.FloorLamp");
      Lang._mapLegendCache[MapHelper.TileToLookup(94, 0)] = Lang._itemNameCache[352];
      Lang._mapLegendCache[MapHelper.TileToLookup(95, 0)] = Lang._itemNameCache[344];
      Lang._mapLegendCache[MapHelper.TileToLookup(96, 0)] = Lang._itemNameCache[345];
      Lang._mapLegendCache[MapHelper.TileToLookup(97, 0)] = Lang._itemNameCache[346];
      Lang._mapLegendCache[MapHelper.TileToLookup(98, 0)] = Lang._itemNameCache[347];
      Lang._mapLegendCache[MapHelper.TileToLookup(100, 0)] = Lang._itemNameCache[349];
      Lang._mapLegendCache[MapHelper.TileToLookup(101, 0)] = Lang._itemNameCache[354];
      Lang._mapLegendCache[MapHelper.TileToLookup(102, 0)] = Lang._itemNameCache[355];
      Lang._mapLegendCache[MapHelper.TileToLookup(103, 0)] = Lang._itemNameCache[356];
      Lang._mapLegendCache[MapHelper.TileToLookup(104, 0)] = Lang._itemNameCache[359];
      Lang._mapLegendCache[MapHelper.TileToLookup(105, 0)] = Language.GetText("MapObject.Statue");
      Lang._mapLegendCache[MapHelper.TileToLookup(105, 2)] = Language.GetText("MapObject.Vase");
      Lang._mapLegendCache[MapHelper.TileToLookup(106, 0)] = Lang._itemNameCache[363];
      Lang._mapLegendCache[MapHelper.TileToLookup(107, 0)] = Language.GetText("MapObject.Cobalt");
      Lang._mapLegendCache[MapHelper.TileToLookup(108, 0)] = Language.GetText("MapObject.Mythril");
      Lang._mapLegendCache[MapHelper.TileToLookup(111, 0)] = Language.GetText("MapObject.Adamantite");
      Lang._mapLegendCache[MapHelper.TileToLookup(114, 0)] = Lang._itemNameCache[398];
      Lang._mapLegendCache[MapHelper.TileToLookup(125, 0)] = Lang._itemNameCache[487];
      Lang._mapLegendCache[MapHelper.TileToLookup(128, 0)] = Lang._itemNameCache[498];
      Lang._mapLegendCache[MapHelper.TileToLookup(129, 0)] = Lang._itemNameCache[502];
      Lang._mapLegendCache[MapHelper.TileToLookup(132, 0)] = Lang._itemNameCache[513];
      Lang._mapLegendCache[MapHelper.TileToLookup(411, 0)] = Lang._itemNameCache[3545];
      Lang._mapLegendCache[MapHelper.TileToLookup(133, 0)] = Lang._itemNameCache[524];
      Lang._mapLegendCache[MapHelper.TileToLookup(133, 1)] = Lang._itemNameCache[1221];
      Lang._mapLegendCache[MapHelper.TileToLookup(134, 0)] = Lang._itemNameCache[525];
      Lang._mapLegendCache[MapHelper.TileToLookup(134, 1)] = Lang._itemNameCache[1220];
      Lang._mapLegendCache[MapHelper.TileToLookup(136, 0)] = Lang._itemNameCache[538];
      Lang._mapLegendCache[MapHelper.TileToLookup(137, 0)] = Language.GetText("MapObject.Trap");
      Lang._mapLegendCache[MapHelper.TileToLookup(138, 0)] = Lang._itemNameCache[540];
      Lang._mapLegendCache[MapHelper.TileToLookup(139, 0)] = Lang._itemNameCache[576];
      Lang._mapLegendCache[MapHelper.TileToLookup(142, 0)] = Lang._itemNameCache[581];
      Lang._mapLegendCache[MapHelper.TileToLookup(143, 0)] = Lang._itemNameCache[582];
      Lang._mapLegendCache[MapHelper.TileToLookup(144, 0)] = Language.GetText("MapObject.Timer");
      Lang._mapLegendCache[MapHelper.TileToLookup(149, 0)] = Language.GetText("MapObject.ChristmasLight");
      Lang._mapLegendCache[MapHelper.TileToLookup(166, 0)] = Language.GetText("MapObject.Tin");
      Lang._mapLegendCache[MapHelper.TileToLookup(167, 0)] = Language.GetText("MapObject.Lead");
      Lang._mapLegendCache[MapHelper.TileToLookup(168, 0)] = Language.GetText("MapObject.Tungsten");
      Lang._mapLegendCache[MapHelper.TileToLookup(169, 0)] = Language.GetText("MapObject.Platinum");
      Lang._mapLegendCache[MapHelper.TileToLookup(170, 0)] = Language.GetText("MapObject.PineTree");
      Lang._mapLegendCache[MapHelper.TileToLookup(171, 0)] = Lang._itemNameCache[1873];
      Lang._mapLegendCache[MapHelper.TileToLookup(172, 0)] = Language.GetText("MapObject.Sink");
      Lang._mapLegendCache[MapHelper.TileToLookup(173, 0)] = Lang._itemNameCache[349];
      Lang._mapLegendCache[MapHelper.TileToLookup(174, 0)] = Lang._itemNameCache[713];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 0)] = Lang._itemNameCache[181];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 1)] = Lang._itemNameCache[180];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 2)] = Lang._itemNameCache[177];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 3)] = Lang._itemNameCache[179];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 4)] = Lang._itemNameCache[178];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 5)] = Lang._itemNameCache[182];
      Lang._mapLegendCache[MapHelper.TileToLookup(178, 6)] = Lang._itemNameCache[999];
      Lang._mapLegendCache[MapHelper.TileToLookup(191, 0)] = Language.GetText("MapObject.LivingWood");
      Lang._mapLegendCache[MapHelper.TileToLookup(204, 0)] = Language.GetText("MapObject.Crimtane");
      Lang._mapLegendCache[MapHelper.TileToLookup(207, 0)] = Language.GetText("MapObject.WaterFountain");
      Lang._mapLegendCache[MapHelper.TileToLookup(209, 0)] = Lang._itemNameCache[928];
      Lang._mapLegendCache[MapHelper.TileToLookup(211, 0)] = Language.GetText("MapObject.Chlorophyte");
      Lang._mapLegendCache[MapHelper.TileToLookup(212, 0)] = Language.GetText("MapObject.Turret");
      Lang._mapLegendCache[MapHelper.TileToLookup(213, 0)] = Lang._itemNameCache[965];
      Lang._mapLegendCache[MapHelper.TileToLookup(214, 0)] = Lang._itemNameCache[85];
      Lang._mapLegendCache[MapHelper.TileToLookup(215, 0)] = Lang._itemNameCache[966];
      Lang._mapLegendCache[MapHelper.TileToLookup(216, 0)] = Language.GetText("MapObject.Rocket");
      Lang._mapLegendCache[MapHelper.TileToLookup(217, 0)] = Lang._itemNameCache[995];
      Lang._mapLegendCache[MapHelper.TileToLookup(218, 0)] = Lang._itemNameCache[996];
      Lang._mapLegendCache[MapHelper.TileToLookup(219, 0)] = Language.GetText("MapObject.SiltExtractinator");
      Lang._mapLegendCache[MapHelper.TileToLookup(220, 0)] = Lang._itemNameCache[998];
      Lang._mapLegendCache[MapHelper.TileToLookup(221, 0)] = Language.GetText("MapObject.Palladium");
      Lang._mapLegendCache[MapHelper.TileToLookup(222, 0)] = Language.GetText("MapObject.Orichalcum");
      Lang._mapLegendCache[MapHelper.TileToLookup(223, 0)] = Language.GetText("MapObject.Titanium");
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 0)] = Lang._itemNameCache[1107];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 1)] = Lang._itemNameCache[1108];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 2)] = Lang._itemNameCache[1109];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 3)] = Lang._itemNameCache[1110];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 4)] = Lang._itemNameCache[1111];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 5)] = Lang._itemNameCache[1112];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 6)] = Lang._itemNameCache[1113];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 7)] = Lang._itemNameCache[1114];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 8)] = Lang._itemNameCache[3385];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 9)] = Lang._itemNameCache[3386];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 10)] = Lang._itemNameCache[3387];
      Lang._mapLegendCache[MapHelper.TileToLookup(227, 11)] = Lang._itemNameCache[3388];
      Lang._mapLegendCache[MapHelper.TileToLookup(228, 0)] = Lang._itemNameCache[1120];
      Lang._mapLegendCache[MapHelper.TileToLookup(231, 0)] = Language.GetText("MapObject.Larva");
      Lang._mapLegendCache[MapHelper.TileToLookup(232, 0)] = Lang._itemNameCache[1150];
      Lang._mapLegendCache[MapHelper.TileToLookup(235, 0)] = Lang._itemNameCache[1263];
      Lang._mapLegendCache[MapHelper.TileToLookup(236, 0)] = Lang._itemNameCache[1291];
      Lang._mapLegendCache[MapHelper.TileToLookup(237, 0)] = Lang._itemNameCache[1292];
      Lang._mapLegendCache[MapHelper.TileToLookup(238, 0)] = Language.GetText("MapObject.PlanterasBulb");
      Lang._mapLegendCache[MapHelper.TileToLookup(239, 0)] = Language.GetText("MapObject.MetalBar");
      Lang._mapLegendCache[MapHelper.TileToLookup(240, 0)] = Language.GetText("MapObject.Trophy");
      Lang._mapLegendCache[MapHelper.TileToLookup(240, 1)] = Language.GetText("MapObject.Painting");
      Lang._mapLegendCache[MapHelper.TileToLookup(240, 2)] = Lang._npcNameCache[21];
      Lang._mapLegendCache[MapHelper.TileToLookup(240, 3)] = Language.GetText("MapObject.ItemRack");
      Lang._mapLegendCache[MapHelper.TileToLookup(240, 4)] = Lang._itemNameCache[2442];
      Lang._mapLegendCache[MapHelper.TileToLookup(241, 0)] = Lang._itemNameCache[1417];
      Lang._mapLegendCache[MapHelper.TileToLookup(242, 0)] = Language.GetText("MapObject.Painting");
      Lang._mapLegendCache[MapHelper.TileToLookup(242, 1)] = Language.GetText("MapObject.AnimalSkin");
      Lang._mapLegendCache[MapHelper.TileToLookup(243, 0)] = Lang._itemNameCache[1430];
      Lang._mapLegendCache[MapHelper.TileToLookup(244, 0)] = Lang._itemNameCache[1449];
      Lang._mapLegendCache[MapHelper.TileToLookup(245, 0)] = Language.GetText("MapObject.Picture");
      Lang._mapLegendCache[MapHelper.TileToLookup(246, 0)] = Language.GetText("MapObject.Picture");
      Lang._mapLegendCache[MapHelper.TileToLookup(247, 0)] = Lang._itemNameCache[1551];
      Lang._mapLegendCache[MapHelper.TileToLookup(254, 0)] = Lang._itemNameCache[1725];
      Lang._mapLegendCache[MapHelper.TileToLookup(269, 0)] = Lang._itemNameCache[1989];
      Lang._mapLegendCache[MapHelper.TileToLookup(475, 0)] = Lang._itemNameCache[3977];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 0)] = Lang._itemNameCache[4876];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 1)] = Lang._itemNameCache[4875];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 2)] = Lang._itemNameCache[4916];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 3)] = Lang._itemNameCache[4917];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 4)] = Lang._itemNameCache[4918];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 5)] = Lang._itemNameCache[4919];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 6)] = Lang._itemNameCache[4920];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 7)] = Lang._itemNameCache[4921];
      Lang._mapLegendCache[MapHelper.TileToLookup(597, 8)] = Lang._itemNameCache[4951];
      Lang._mapLegendCache[MapHelper.TileToLookup(617, 0)] = Language.GetText("MapObject.Relic");
      Lang._mapLegendCache[MapHelper.TileToLookup(621, 0)] = Lang._itemNameCache[3750];
      Lang._mapLegendCache[MapHelper.TileToLookup(622, 0)] = Lang._itemNameCache[5008];
      Lang._mapLegendCache[MapHelper.TileToLookup(270, 0)] = Lang._itemNameCache[1993];
      Lang._mapLegendCache[MapHelper.TileToLookup(271, 0)] = Lang._itemNameCache[2005];
      Lang._mapLegendCache[MapHelper.TileToLookup(581, 0)] = Lang._itemNameCache[4848];
      Lang._mapLegendCache[MapHelper.TileToLookup(275, 0)] = Lang._itemNameCache[2162];
      Lang._mapLegendCache[MapHelper.TileToLookup(276, 0)] = Lang._itemNameCache[2163];
      Lang._mapLegendCache[MapHelper.TileToLookup(277, 0)] = Lang._itemNameCache[2164];
      Lang._mapLegendCache[MapHelper.TileToLookup(278, 0)] = Lang._itemNameCache[2165];
      Lang._mapLegendCache[MapHelper.TileToLookup(279, 0)] = Lang._itemNameCache[2166];
      Lang._mapLegendCache[MapHelper.TileToLookup(280, 0)] = Lang._itemNameCache[2167];
      Lang._mapLegendCache[MapHelper.TileToLookup(281, 0)] = Lang._itemNameCache[2168];
      Lang._mapLegendCache[MapHelper.TileToLookup(282, 0)] = Lang._itemNameCache[250];
      Lang._mapLegendCache[MapHelper.TileToLookup(543, 0)] = Lang._itemNameCache[4398];
      Lang._mapLegendCache[MapHelper.TileToLookup(598, 0)] = Lang._itemNameCache[4880];
      Lang._mapLegendCache[MapHelper.TileToLookup(413, 0)] = Language.GetText("MapObject.OrangeSquirrelCage");
      Lang._mapLegendCache[MapHelper.TileToLookup(283, 0)] = Lang._itemNameCache[2172];
      Lang._mapLegendCache[MapHelper.TileToLookup(285, 0)] = Lang._itemNameCache[2174];
      Lang._mapLegendCache[MapHelper.TileToLookup(286, 0)] = Lang._itemNameCache[2175];
      Lang._mapLegendCache[MapHelper.TileToLookup(582, 0)] = Lang._itemNameCache[4850];
      Lang._mapLegendCache[MapHelper.TileToLookup(287, 0)] = Lang._itemNameCache[2177];
      Lang._mapLegendCache[MapHelper.TileToLookup(288, 0)] = Lang._itemNameCache[2178];
      Lang._mapLegendCache[MapHelper.TileToLookup(289, 0)] = Lang._itemNameCache[2179];
      Lang._mapLegendCache[MapHelper.TileToLookup(290, 0)] = Lang._itemNameCache[2180];
      Lang._mapLegendCache[MapHelper.TileToLookup(291, 0)] = Lang._itemNameCache[2181];
      Lang._mapLegendCache[MapHelper.TileToLookup(292, 0)] = Lang._itemNameCache[2182];
      Lang._mapLegendCache[MapHelper.TileToLookup(293, 0)] = Lang._itemNameCache[2183];
      Lang._mapLegendCache[MapHelper.TileToLookup(294, 0)] = Lang._itemNameCache[2184];
      Lang._mapLegendCache[MapHelper.TileToLookup(295, 0)] = Lang._itemNameCache[2185];
      Lang._mapLegendCache[MapHelper.TileToLookup(580, 0)] = Lang._itemNameCache[4846];
      Lang._mapLegendCache[MapHelper.TileToLookup(620, 0)] = Lang._itemNameCache[4964];
      Lang._mapLegendCache[MapHelper.TileToLookup(619, 0)] = Lang._itemNameCache[4963];
      Lang._mapLegendCache[MapHelper.TileToLookup(296, 0)] = Lang._itemNameCache[2186];
      Lang._mapLegendCache[MapHelper.TileToLookup(297, 0)] = Lang._itemNameCache[2187];
      Lang._mapLegendCache[MapHelper.TileToLookup(298, 0)] = Lang._itemNameCache[2190];
      Lang._mapLegendCache[MapHelper.TileToLookup(299, 0)] = Lang._itemNameCache[2191];
      Lang._mapLegendCache[MapHelper.TileToLookup(300, 0)] = Lang._itemNameCache[2192];
      Lang._mapLegendCache[MapHelper.TileToLookup(301, 0)] = Lang._itemNameCache[2193];
      Lang._mapLegendCache[MapHelper.TileToLookup(302, 0)] = Lang._itemNameCache[2194];
      Lang._mapLegendCache[MapHelper.TileToLookup(303, 0)] = Lang._itemNameCache[2195];
      Lang._mapLegendCache[MapHelper.TileToLookup(304, 0)] = Lang._itemNameCache[2196];
      Lang._mapLegendCache[MapHelper.TileToLookup(305, 0)] = Lang._itemNameCache[2197];
      Lang._mapLegendCache[MapHelper.TileToLookup(306, 0)] = Lang._itemNameCache[2198];
      Lang._mapLegendCache[MapHelper.TileToLookup(307, 0)] = Lang._itemNameCache[2203];
      Lang._mapLegendCache[MapHelper.TileToLookup(308, 0)] = Lang._itemNameCache[2204];
      Lang._mapLegendCache[MapHelper.TileToLookup(309, 0)] = Lang._itemNameCache[2206];
      Lang._mapLegendCache[MapHelper.TileToLookup(310, 0)] = Lang._itemNameCache[2207];
      Lang._mapLegendCache[MapHelper.TileToLookup(391, 0)] = Lang._itemNameCache[3254];
      Lang._mapLegendCache[MapHelper.TileToLookup(316, 0)] = Lang._itemNameCache[2439];
      Lang._mapLegendCache[MapHelper.TileToLookup(317, 0)] = Lang._itemNameCache[2440];
      Lang._mapLegendCache[MapHelper.TileToLookup(318, 0)] = Lang._itemNameCache[2441];
      Lang._mapLegendCache[MapHelper.TileToLookup(319, 0)] = Lang._itemNameCache[2490];
      Lang._mapLegendCache[MapHelper.TileToLookup(320, 0)] = Lang._itemNameCache[2496];
      Lang._mapLegendCache[MapHelper.TileToLookup(323, 0)] = Language.GetText("MapObject.PalmTree");
      Lang._mapLegendCache[MapHelper.TileToLookup(314, 0)] = Lang._itemNameCache[2340];
      Lang._mapLegendCache[MapHelper.TileToLookup(353, 0)] = Lang._itemNameCache[2996];
      Lang._mapLegendCache[MapHelper.TileToLookup(354, 0)] = Lang._itemNameCache[2999];
      Lang._mapLegendCache[MapHelper.TileToLookup(355, 0)] = Lang._itemNameCache[3000];
      Lang._mapLegendCache[MapHelper.TileToLookup(356, 0)] = Lang._itemNameCache[3064];
      Lang._mapLegendCache[MapHelper.TileToLookup(358, 0)] = Lang._itemNameCache[3070];
      Lang._mapLegendCache[MapHelper.TileToLookup(359, 0)] = Lang._itemNameCache[3071];
      Lang._mapLegendCache[MapHelper.TileToLookup(360, 0)] = Lang._itemNameCache[3072];
      Lang._mapLegendCache[MapHelper.TileToLookup(361, 0)] = Lang._itemNameCache[3073];
      Lang._mapLegendCache[MapHelper.TileToLookup(362, 0)] = Lang._itemNameCache[3074];
      Lang._mapLegendCache[MapHelper.TileToLookup(363, 0)] = Lang._itemNameCache[3075];
      Lang._mapLegendCache[MapHelper.TileToLookup(364, 0)] = Lang._itemNameCache[3076];
      Lang._mapLegendCache[MapHelper.TileToLookup(414, 0)] = Lang._itemNameCache[3566];
      Lang._mapLegendCache[MapHelper.TileToLookup(521, 0)] = Lang._itemNameCache[4327];
      Lang._mapLegendCache[MapHelper.TileToLookup(522, 0)] = Lang._itemNameCache[4328];
      Lang._mapLegendCache[MapHelper.TileToLookup(523, 0)] = Lang._itemNameCache[4329];
      Lang._mapLegendCache[MapHelper.TileToLookup(524, 0)] = Lang._itemNameCache[4330];
      Lang._mapLegendCache[MapHelper.TileToLookup(525, 0)] = Lang._itemNameCache[4331];
      Lang._mapLegendCache[MapHelper.TileToLookup(526, 0)] = Lang._itemNameCache[4332];
      Lang._mapLegendCache[MapHelper.TileToLookup(527, 0)] = Lang._itemNameCache[4333];
      Lang._mapLegendCache[MapHelper.TileToLookup(542, 0)] = Lang._itemNameCache[4396];
      Lang._mapLegendCache[MapHelper.TileToLookup(365, 0)] = Lang._itemNameCache[3077];
      Lang._mapLegendCache[MapHelper.TileToLookup(366, 0)] = Lang._itemNameCache[3078];
      Lang._mapLegendCache[MapHelper.TileToLookup(373, 0)] = Language.GetText("MapObject.DrippingWater");
      Lang._mapLegendCache[MapHelper.TileToLookup(374, 0)] = Language.GetText("MapObject.DrippingLava");
      Lang._mapLegendCache[MapHelper.TileToLookup(375, 0)] = Language.GetText("MapObject.DrippingHoney");
      Lang._mapLegendCache[MapHelper.TileToLookup(461, 0)] = Language.GetText("MapObject.SandFlow");
      Lang._mapLegendCache[MapHelper.TileToLookup(461, 1)] = Language.GetText("MapObject.SandFlow");
      Lang._mapLegendCache[MapHelper.TileToLookup(461, 2)] = Language.GetText("MapObject.SandFlow");
      Lang._mapLegendCache[MapHelper.TileToLookup(461, 3)] = Language.GetText("MapObject.SandFlow");
      Lang._mapLegendCache[MapHelper.TileToLookup(377, 0)] = Lang._itemNameCache[3198];
      Lang._mapLegendCache[MapHelper.TileToLookup(372, 0)] = Lang._itemNameCache[3117];
      Lang._mapLegendCache[MapHelper.TileToLookup(425, 0)] = Lang._itemNameCache[3617];
      Lang._mapLegendCache[MapHelper.TileToLookup(420, 0)] = Lang._itemNameCache[3603];
      Lang._mapLegendCache[MapHelper.TileToLookup(420, 1)] = Lang._itemNameCache[3604];
      Lang._mapLegendCache[MapHelper.TileToLookup(420, 2)] = Lang._itemNameCache[3605];
      Lang._mapLegendCache[MapHelper.TileToLookup(420, 3)] = Lang._itemNameCache[3606];
      Lang._mapLegendCache[MapHelper.TileToLookup(420, 4)] = Lang._itemNameCache[3607];
      Lang._mapLegendCache[MapHelper.TileToLookup(420, 5)] = Lang._itemNameCache[3608];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 0)] = Lang._itemNameCache[3613];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 1)] = Lang._itemNameCache[3614];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 2)] = Lang._itemNameCache[3615];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 3)] = Lang._itemNameCache[3726];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 4)] = Lang._itemNameCache[3727];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 5)] = Lang._itemNameCache[3728];
      Lang._mapLegendCache[MapHelper.TileToLookup(423, 6)] = Lang._itemNameCache[3729];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 0)] = Lang._itemNameCache[3644];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 1)] = Lang._itemNameCache[3645];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 2)] = Lang._itemNameCache[3646];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 3)] = Lang._itemNameCache[3647];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 4)] = Lang._itemNameCache[3648];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 5)] = Lang._itemNameCache[3649];
      Lang._mapLegendCache[MapHelper.TileToLookup(440, 6)] = Lang._itemNameCache[3650];
      Lang._mapLegendCache[MapHelper.TileToLookup(443, 0)] = Lang._itemNameCache[3722];
      Lang._mapLegendCache[MapHelper.TileToLookup(429, 0)] = Lang._itemNameCache[3629];
      Lang._mapLegendCache[MapHelper.TileToLookup(424, 0)] = Lang._itemNameCache[3616];
      Lang._mapLegendCache[MapHelper.TileToLookup(444, 0)] = Language.GetText("MapObject.BeeHive");
      Lang._mapLegendCache[MapHelper.TileToLookup(466, 0)] = Lang._itemNameCache[3816];
      Lang._mapLegendCache[MapHelper.TileToLookup(463, 0)] = Lang._itemNameCache[3813];
      Lang._mapLegendCache[MapHelper.TileToLookup(491, 0)] = Lang._itemNameCache[4076];
      Lang._mapLegendCache[MapHelper.TileToLookup(494, 0)] = Lang._itemNameCache[4089];
      Lang._mapLegendCache[MapHelper.TileToLookup(499, 0)] = Lang._itemNameCache[4142];
      Lang._mapLegendCache[MapHelper.TileToLookup(488, 0)] = Language.GetText("MapObject.FallenLog");
      Lang._mapLegendCache[MapHelper.TileToLookup(505, 0)] = Lang._itemNameCache[4275];
      Lang._mapLegendCache[MapHelper.TileToLookup(521, 0)] = Lang._itemNameCache[4327];
      Lang._mapLegendCache[MapHelper.TileToLookup(522, 0)] = Lang._itemNameCache[4328];
      Lang._mapLegendCache[MapHelper.TileToLookup(523, 0)] = Lang._itemNameCache[4329];
      Lang._mapLegendCache[MapHelper.TileToLookup(524, 0)] = Lang._itemNameCache[4330];
      Lang._mapLegendCache[MapHelper.TileToLookup(525, 0)] = Lang._itemNameCache[4331];
      Lang._mapLegendCache[MapHelper.TileToLookup(526, 0)] = Lang._itemNameCache[4332];
      Lang._mapLegendCache[MapHelper.TileToLookup(527, 0)] = Lang._itemNameCache[4333];
      Lang._mapLegendCache[MapHelper.TileToLookup(531, 0)] = Language.GetText("MapObject.Statue");
      Lang._mapLegendCache[MapHelper.TileToLookup(349, 0)] = Language.GetText("MapObject.Statue");
      Lang._mapLegendCache[MapHelper.TileToLookup(532, 0)] = Lang._itemNameCache[4364];
      Lang._mapLegendCache[MapHelper.TileToLookup(538, 0)] = Lang._itemNameCache[4380];
      Lang._mapLegendCache[MapHelper.TileToLookup(544, 0)] = Lang._itemNameCache[4399];
      Lang._mapLegendCache[MapHelper.TileToLookup(506, 0)] = Lang._itemNameCache[4276];
      Lang._mapLegendCache[MapHelper.TileToLookup(545, 0)] = Lang._itemNameCache[4420];
      Lang._mapLegendCache[MapHelper.TileToLookup(550, 0)] = Lang._itemNameCache[4461];
      Lang._mapLegendCache[MapHelper.TileToLookup(551, 0)] = Lang._itemNameCache[4462];
      Lang._mapLegendCache[MapHelper.TileToLookup(533, 0)] = Lang._itemNameCache[4376];
      Lang._mapLegendCache[MapHelper.TileToLookup(553, 0)] = Lang._itemNameCache[4473];
      Lang._mapLegendCache[MapHelper.TileToLookup(554, 0)] = Lang._itemNameCache[4474];
      Lang._mapLegendCache[MapHelper.TileToLookup(555, 0)] = Lang._itemNameCache[4475];
      Lang._mapLegendCache[MapHelper.TileToLookup(556, 0)] = Lang._itemNameCache[4476];
      Lang._mapLegendCache[MapHelper.TileToLookup(558, 0)] = Lang._itemNameCache[4481];
      Lang._mapLegendCache[MapHelper.TileToLookup(559, 0)] = Lang._itemNameCache[4483];
      Lang._mapLegendCache[MapHelper.TileToLookup(599, 0)] = Lang._itemNameCache[4882];
      Lang._mapLegendCache[MapHelper.TileToLookup(600, 0)] = Lang._itemNameCache[4883];
      Lang._mapLegendCache[MapHelper.TileToLookup(601, 0)] = Lang._itemNameCache[4884];
      Lang._mapLegendCache[MapHelper.TileToLookup(602, 0)] = Lang._itemNameCache[4885];
      Lang._mapLegendCache[MapHelper.TileToLookup(603, 0)] = Lang._itemNameCache[4886];
      Lang._mapLegendCache[MapHelper.TileToLookup(604, 0)] = Lang._itemNameCache[4887];
      Lang._mapLegendCache[MapHelper.TileToLookup(605, 0)] = Lang._itemNameCache[4888];
      Lang._mapLegendCache[MapHelper.TileToLookup(606, 0)] = Lang._itemNameCache[4889];
      Lang._mapLegendCache[MapHelper.TileToLookup(607, 0)] = Lang._itemNameCache[4890];
      Lang._mapLegendCache[MapHelper.TileToLookup(608, 0)] = Lang._itemNameCache[4891];
      Lang._mapLegendCache[MapHelper.TileToLookup(609, 0)] = Lang._itemNameCache[4892];
      Lang._mapLegendCache[MapHelper.TileToLookup(610, 0)] = Lang._itemNameCache[4893];
      Lang._mapLegendCache[MapHelper.TileToLookup(611, 0)] = Lang._itemNameCache[4894];
      Lang._mapLegendCache[MapHelper.TileToLookup(612, 0)] = Lang._itemNameCache[4895];
      Lang._mapLegendCache[MapHelper.TileToLookup(560, 0)] = Lang._itemNameCache[4599];
      Lang._mapLegendCache[MapHelper.TileToLookup(560, 1)] = Lang._itemNameCache[4600];
      Lang._mapLegendCache[MapHelper.TileToLookup(560, 2)] = Lang._itemNameCache[4601];
      Lang._mapLegendCache[MapHelper.TileToLookup(568, 0)] = Lang._itemNameCache[4655];
      Lang._mapLegendCache[MapHelper.TileToLookup(569, 0)] = Lang._itemNameCache[4656];
      Lang._mapLegendCache[MapHelper.TileToLookup(570, 0)] = Lang._itemNameCache[4657];
      Lang._mapLegendCache[MapHelper.TileToLookup(572, 0)] = Lang._itemNameCache[4695];
      Lang._mapLegendCache[MapHelper.TileToLookup(572, 1)] = Lang._itemNameCache[4696];
      Lang._mapLegendCache[MapHelper.TileToLookup(572, 2)] = Lang._itemNameCache[4697];
      Lang._mapLegendCache[MapHelper.TileToLookup(572, 3)] = Lang._itemNameCache[4698];
      Lang._mapLegendCache[MapHelper.TileToLookup(572, 4)] = Lang._itemNameCache[4699];
      Lang._mapLegendCache[MapHelper.TileToLookup(572, 5)] = Lang._itemNameCache[4700];
      Lang._mapLegendCache[MapHelper.TileToLookup(497, 0)] = Language.GetText("MapObject.Toilet");
    }

    public static NetworkText CreateDeathMessage(
      string deadPlayerName,
      int plr = -1,
      int npc = -1,
      int proj = -1,
      int other = -1,
      int projType = 0,
      int plrItemType = 0)
    {
      NetworkText networkText1 = NetworkText.Empty;
      NetworkText networkText2 = NetworkText.Empty;
      NetworkText networkText3 = NetworkText.Empty;
      NetworkText networkText4 = NetworkText.Empty;
      if (proj >= 0)
        networkText1 = NetworkText.FromKey(Lang.GetProjectileName(projType).Key);
      if (npc >= 0)
        networkText2 = Main.npc[npc].GetGivenOrTypeNetName();
      if (plr >= 0 && plr < (int) byte.MaxValue)
        networkText3 = NetworkText.FromLiteral(Main.player[plr].name);
      if (plrItemType >= 0)
        networkText4 = NetworkText.FromKey(Lang.GetItemName(plrItemType).Key);
      bool flag1 = networkText1 != NetworkText.Empty;
      bool flag2 = plr >= 0 && plr < (int) byte.MaxValue;
      bool flag3 = networkText2 != NetworkText.Empty;
      NetworkText networkText5 = NetworkText.Empty;
      NetworkText empty = NetworkText.Empty;
      NetworkText networkText6 = NetworkText.FromKey(Language.RandomFromCategory("DeathTextGeneric").Key, (object) deadPlayerName, (object) Main.worldName);
      if (flag2)
        networkText5 = NetworkText.FromKey("DeathSource.Player", (object) networkText6, (object) networkText3, flag1 ? (object) networkText1 : (object) networkText4);
      else if (flag3)
        networkText5 = NetworkText.FromKey("DeathSource.NPC", (object) networkText6, (object) networkText2);
      else if (flag1)
      {
        networkText5 = NetworkText.FromKey("DeathSource.Projectile", (object) networkText6, (object) networkText1);
      }
      else
      {
        switch (other)
        {
          case 0:
            networkText5 = NetworkText.FromKey("DeathText.Fell_" + (object) (Main.rand.Next(2) + 1), (object) deadPlayerName);
            break;
          case 1:
            networkText5 = NetworkText.FromKey("DeathText.Drowned_" + (object) (Main.rand.Next(4) + 1), (object) deadPlayerName);
            break;
          case 2:
            networkText5 = NetworkText.FromKey("DeathText.Lava_" + (object) (Main.rand.Next(4) + 1), (object) deadPlayerName);
            break;
          case 3:
            networkText5 = NetworkText.FromKey("DeathText.Default", (object) networkText6);
            break;
          case 4:
            networkText5 = NetworkText.FromKey("DeathText.Slain", (object) deadPlayerName);
            break;
          case 5:
            networkText5 = NetworkText.FromKey("DeathText.Petrified_" + (object) (Main.rand.Next(4) + 1), (object) deadPlayerName);
            break;
          case 6:
            networkText5 = NetworkText.FromKey("DeathText.Stabbed", (object) deadPlayerName);
            break;
          case 7:
            networkText5 = NetworkText.FromKey("DeathText.Suffocated", (object) deadPlayerName);
            break;
          case 8:
            networkText5 = NetworkText.FromKey("DeathText.Burned", (object) deadPlayerName);
            break;
          case 9:
            networkText5 = NetworkText.FromKey("DeathText.Poisoned", (object) deadPlayerName);
            break;
          case 10:
            networkText5 = NetworkText.FromKey("DeathText.Electrocuted", (object) deadPlayerName);
            break;
          case 11:
            networkText5 = NetworkText.FromKey("DeathText.TriedToEscape", (object) deadPlayerName);
            break;
          case 12:
            networkText5 = NetworkText.FromKey("DeathText.WasLicked", (object) deadPlayerName);
            break;
          case 13:
            networkText5 = NetworkText.FromKey("DeathText.Teleport_1", (object) deadPlayerName);
            break;
          case 14:
            networkText5 = NetworkText.FromKey("DeathText.Teleport_2_Male", (object) deadPlayerName);
            break;
          case 15:
            networkText5 = NetworkText.FromKey("DeathText.Teleport_2_Female", (object) deadPlayerName);
            break;
          case 16:
            networkText5 = NetworkText.FromKey("DeathText.Inferno", (object) deadPlayerName);
            break;
          case 254:
            networkText5 = NetworkText.Empty;
            break;
          case (int) byte.MaxValue:
            networkText5 = NetworkText.FromKey("DeathText.Slain", (object) deadPlayerName);
            break;
        }
      }
      return networkText5;
    }

    public static NetworkText GetInvasionWaveText(int wave, params short[] npcIds)
    {
      NetworkText[] networkTextArray = new NetworkText[npcIds.Length + 1];
      for (int index = 0; index < npcIds.Length; ++index)
        networkTextArray[index + 1] = NetworkText.FromKey(Lang.GetNPCName((int) npcIds[index]).Key);
      switch (wave)
      {
        case -1:
          networkTextArray[0] = NetworkText.FromKey("Game.FinalWave");
          break;
        case 1:
          networkTextArray[0] = NetworkText.FromKey("Game.FirstWave");
          break;
        default:
          networkTextArray[0] = NetworkText.FromKey("Game.Wave", (object) wave);
          break;
      }
      return NetworkText.FromKey("Game.InvasionWave_Type" + (object) npcIds.Length, (object[]) networkTextArray);
    }

    public static string LocalizedDuration(
      TimeSpan time,
      bool abbreviated,
      bool showAllAvailableUnits)
    {
      string str1 = "";
      abbreviated |= !GameCulture.FromCultureName(GameCulture.CultureName.English).IsActive;
      if (time.Days > 0)
      {
        int days = time.Days;
        if (!showAllAvailableUnits && time > TimeSpan.FromDays(1.0))
          ++days;
        string str2 = str1 + (object) days + (abbreviated ? (object) (" " + Language.GetTextValue("Misc.ShortDays")) : (days == 1 ? (object) " day" : (object) " days"));
        if (!showAllAvailableUnits)
          return str2;
        str1 = str2 + " ";
      }
      if (time.Hours > 0)
      {
        int hours = time.Hours;
        if (!showAllAvailableUnits && time > TimeSpan.FromHours(1.0))
          ++hours;
        string str3 = str1 + (object) hours + (abbreviated ? (object) (" " + Language.GetTextValue("Misc.ShortHours")) : (hours == 1 ? (object) " hour" : (object) " hours"));
        if (!showAllAvailableUnits)
          return str3;
        str1 = str3 + " ";
      }
      if (time.Minutes > 0)
      {
        int minutes = time.Minutes;
        if (!showAllAvailableUnits && time > TimeSpan.FromMinutes(1.0))
          ++minutes;
        string str4 = str1 + (object) minutes + (abbreviated ? (object) (" " + Language.GetTextValue("Misc.ShortMinutes")) : (minutes == 1 ? (object) " minute" : (object) " minutes"));
        if (!showAllAvailableUnits)
          return str4;
        str1 = str4 + " ";
      }
      return str1 + (object) time.Seconds + (abbreviated ? (object) (" " + Language.GetTextValue("Misc.ShortSeconds")) : (time.Seconds == 1 ? (object) " second" : (object) " seconds"));
    }
  }
}
