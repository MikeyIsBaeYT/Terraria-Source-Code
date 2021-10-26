// Decompiled with JetBrains decompiler
// Type: Terraria.ID.ContentSamples
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.Bestiary;
using Terraria.Graphics.Shaders;

namespace Terraria.ID
{
  public static class ContentSamples
  {
    public static Dictionary<int, NPC> NpcsByNetId = new Dictionary<int, NPC>();
    public static Dictionary<int, Projectile> ProjectilesByType = new Dictionary<int, Projectile>();
    public static Dictionary<int, Item> ItemsByType = new Dictionary<int, Item>();
    public static Dictionary<string, int> ItemNetIdsByPersistentIds = new Dictionary<string, int>();
    public static Dictionary<int, string> ItemPersistentIdsByNetIds = new Dictionary<int, string>();
    public static Dictionary<string, int> NpcNetIdsByPersistentIds = new Dictionary<string, int>();
    public static Dictionary<int, string> NpcPersistentIdsByNetIds = new Dictionary<int, string>();
    public static Dictionary<int, int> NpcBestiarySortingId = new Dictionary<int, int>();
    public static Dictionary<int, int> NpcBestiaryRarityStars = new Dictionary<int, int>();
    public static Dictionary<int, string> NpcBestiaryCreditIdsByNpcNetIds = new Dictionary<int, string>();
    public static Dictionary<int, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup> ItemCreativeSortingId = new Dictionary<int, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>();

    public static void Initialize()
    {
      ContentSamples.NpcsByNetId.Clear();
      ContentSamples.NpcNetIdsByPersistentIds.Clear();
      ContentSamples.NpcPersistentIdsByNetIds.Clear();
      ContentSamples.NpcBestiarySortingId.Clear();
      for (int index = -65; index < 663; ++index)
      {
        NPC npc = new NPC();
        npc.SetDefaults(index);
        ContentSamples.NpcsByNetId[index] = npc;
        string name = NPCID.Search.GetName(npc.netID);
        ContentSamples.NpcPersistentIdsByNetIds[index] = name;
        ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[index] = name;
        ContentSamples.NpcNetIdsByPersistentIds[name] = index;
      }
      ContentSamples.ModifyNPCIds();
      ContentSamples.ProjectilesByType.Clear();
      for (int index = 0; index < 950; ++index)
      {
        Projectile projectile = new Projectile();
        projectile.SetDefaults(index);
        ContentSamples.ProjectilesByType[index] = projectile;
      }
      ContentSamples.ItemsByType.Clear();
      for (int index = 0; index < 5045; ++index)
      {
        Item obj = new Item();
        obj.SetDefaults(index);
        ContentSamples.ItemsByType[index] = obj;
        string name = ItemID.Search.GetName(obj.netID);
        ContentSamples.ItemPersistentIdsByNetIds[index] = name;
        ContentSamples.ItemNetIdsByPersistentIds[name] = index;
      }
      foreach (int num in ItemID.Sets.ItemsThatAreProcessedAfterNormalContentSample)
      {
        Item obj = new Item();
        obj.SetDefaults(num);
        ContentSamples.ItemsByType[num] = obj;
        string name = ItemID.Search.GetName(obj.netID);
        ContentSamples.ItemPersistentIdsByNetIds[num] = name;
        ContentSamples.ItemNetIdsByPersistentIds[name] = num;
      }
      ContentSamples.FillNpcRarities();
    }

    public static void FixItemsAfterRecipesAreAdded()
    {
      foreach (KeyValuePair<int, Item> keyValuePair in ContentSamples.ItemsByType)
        keyValuePair.Value.material = ItemID.Sets.IsAMaterial[keyValuePair.Key];
    }

    public static void RebuildBestiarySortingIDsByBestiaryDatabaseContents(BestiaryDatabase database)
    {
      ContentSamples.NpcBestiarySortingId.Clear();
      ContentSamples.CreateBestiarySortingIds(database);
    }

    public static void RebuildItemCreativeSortingIDsAfterRecipesAreSetUp()
    {
      ContentSamples.ItemCreativeSortingId.Clear();
      ContentSamples.CreateCreativeItemSortingIds();
    }

    private static void ModifyNPCIds()
    {
      Dictionary<int, string> creditIdsByNpcNetIds = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds;
      creditIdsByNpcNetIds[-65] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-64] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-63] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-62] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-61] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-60] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-59] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-58] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-57] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-56] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-55] = creditIdsByNpcNetIds[223];
      creditIdsByNpcNetIds[-54] = creditIdsByNpcNetIds[223];
      creditIdsByNpcNetIds[-53] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-52] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-51] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-50] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-49] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-48] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-47] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-46] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[-45] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-44] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-43] = creditIdsByNpcNetIds[2];
      creditIdsByNpcNetIds[-42] = creditIdsByNpcNetIds[2];
      creditIdsByNpcNetIds[-41] = creditIdsByNpcNetIds[2];
      creditIdsByNpcNetIds[-40] = creditIdsByNpcNetIds[2];
      creditIdsByNpcNetIds[-39] = creditIdsByNpcNetIds[2];
      creditIdsByNpcNetIds[-38] = creditIdsByNpcNetIds[2];
      creditIdsByNpcNetIds[-37] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-36] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-35] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-34] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-33] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-32] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-31] = creditIdsByNpcNetIds[186];
      creditIdsByNpcNetIds[-30] = creditIdsByNpcNetIds[186];
      creditIdsByNpcNetIds[-27] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-26] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[-23] = creditIdsByNpcNetIds[173];
      creditIdsByNpcNetIds[-22] = creditIdsByNpcNetIds[173];
      creditIdsByNpcNetIds[-25] = creditIdsByNpcNetIds[183];
      creditIdsByNpcNetIds[-24] = creditIdsByNpcNetIds[183];
      creditIdsByNpcNetIds[-21] = creditIdsByNpcNetIds[176];
      creditIdsByNpcNetIds[-20] = creditIdsByNpcNetIds[176];
      creditIdsByNpcNetIds[-19] = creditIdsByNpcNetIds[176];
      creditIdsByNpcNetIds[-18] = creditIdsByNpcNetIds[176];
      creditIdsByNpcNetIds[-17] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-16] = creditIdsByNpcNetIds[42];
      creditIdsByNpcNetIds[-15] = creditIdsByNpcNetIds[77];
      creditIdsByNpcNetIds[-14] = creditIdsByNpcNetIds[31];
      creditIdsByNpcNetIds[-13] = creditIdsByNpcNetIds[31];
      creditIdsByNpcNetIds[-12] = creditIdsByNpcNetIds[6];
      creditIdsByNpcNetIds[-11] = creditIdsByNpcNetIds[6];
      creditIdsByNpcNetIds[497] = creditIdsByNpcNetIds[496];
      creditIdsByNpcNetIds[495] = creditIdsByNpcNetIds[494];
      short num = 499;
      for (int key = 498; key <= 506; ++key)
        creditIdsByNpcNetIds[key] = creditIdsByNpcNetIds[(int) num];
      creditIdsByNpcNetIds[591] = creditIdsByNpcNetIds[590];
      creditIdsByNpcNetIds[430] = creditIdsByNpcNetIds[3];
      creditIdsByNpcNetIds[436] = creditIdsByNpcNetIds[200];
      creditIdsByNpcNetIds[431] = creditIdsByNpcNetIds[161];
      creditIdsByNpcNetIds[432] = creditIdsByNpcNetIds[186];
      creditIdsByNpcNetIds[433] = creditIdsByNpcNetIds[187];
      creditIdsByNpcNetIds[434] = creditIdsByNpcNetIds[188];
      creditIdsByNpcNetIds[435] = creditIdsByNpcNetIds[189];
      creditIdsByNpcNetIds[164] = creditIdsByNpcNetIds[165];
      creditIdsByNpcNetIds[236] = creditIdsByNpcNetIds[237];
      creditIdsByNpcNetIds[163] = creditIdsByNpcNetIds[238];
      creditIdsByNpcNetIds[239] = creditIdsByNpcNetIds[240];
      creditIdsByNpcNetIds[530] = creditIdsByNpcNetIds[531];
      creditIdsByNpcNetIds[449] = creditIdsByNpcNetIds[21];
      creditIdsByNpcNetIds[450] = creditIdsByNpcNetIds[201];
      creditIdsByNpcNetIds[451] = creditIdsByNpcNetIds[202];
      creditIdsByNpcNetIds[452] = creditIdsByNpcNetIds[203];
      creditIdsByNpcNetIds[595] = creditIdsByNpcNetIds[599];
      creditIdsByNpcNetIds[596] = creditIdsByNpcNetIds[599];
      creditIdsByNpcNetIds[597] = creditIdsByNpcNetIds[599];
      creditIdsByNpcNetIds[598] = creditIdsByNpcNetIds[599];
      creditIdsByNpcNetIds[600] = creditIdsByNpcNetIds[599];
      creditIdsByNpcNetIds[230] = creditIdsByNpcNetIds[55];
      creditIdsByNpcNetIds[593] = creditIdsByNpcNetIds[592];
      creditIdsByNpcNetIds[-2] = creditIdsByNpcNetIds[121];
      creditIdsByNpcNetIds[195] = creditIdsByNpcNetIds[196];
      creditIdsByNpcNetIds[198] = creditIdsByNpcNetIds[199];
      creditIdsByNpcNetIds[158] = creditIdsByNpcNetIds[159];
      creditIdsByNpcNetIds[568] = creditIdsByNpcNetIds[569];
      creditIdsByNpcNetIds[566] = creditIdsByNpcNetIds[567];
      creditIdsByNpcNetIds[576] = creditIdsByNpcNetIds[577];
      creditIdsByNpcNetIds[558] = creditIdsByNpcNetIds[560];
      creditIdsByNpcNetIds[559] = creditIdsByNpcNetIds[560];
      creditIdsByNpcNetIds[552] = creditIdsByNpcNetIds[554];
      creditIdsByNpcNetIds[553] = creditIdsByNpcNetIds[554];
      creditIdsByNpcNetIds[564] = creditIdsByNpcNetIds[565];
      creditIdsByNpcNetIds[570] = creditIdsByNpcNetIds[571];
      creditIdsByNpcNetIds[555] = creditIdsByNpcNetIds[557];
      creditIdsByNpcNetIds[556] = creditIdsByNpcNetIds[557];
      creditIdsByNpcNetIds[574] = creditIdsByNpcNetIds[575];
      creditIdsByNpcNetIds[561] = creditIdsByNpcNetIds[563];
      creditIdsByNpcNetIds[562] = creditIdsByNpcNetIds[563];
      creditIdsByNpcNetIds[572] = creditIdsByNpcNetIds[573];
      creditIdsByNpcNetIds[14] = creditIdsByNpcNetIds[13];
      creditIdsByNpcNetIds[15] = creditIdsByNpcNetIds[13];
    }

    private static void CreateBestiarySortingIds(BestiaryDatabase database)
    {
      List<KeyValuePair<int, NPC>> bestiaryEntriesList = ContentSamples.BestiaryHelper.GetSortedBestiaryEntriesList(database);
      int num = 1;
      foreach (KeyValuePair<int, NPC> keyValuePair in bestiaryEntriesList)
      {
        ContentSamples.NpcBestiarySortingId[keyValuePair.Key] = num;
        ++num;
      }
    }

    private static void FillNpcRarities()
    {
      NPCSpawnParams spawnparams = new NPCSpawnParams()
      {
        gameModeData = Main.RegisterdGameModes[0]
      };
      for (int index = -65; index < 663; ++index)
      {
        NPC npc = new NPC();
        npc.SetDefaults(index, spawnparams);
        ContentSamples.NpcBestiaryRarityStars[index] = ContentSamples.GetNPCBestiaryRarityStarsCount(npc);
      }
      ContentSamples.NpcBestiaryRarityStars[22] = 1;
      ContentSamples.NpcBestiaryRarityStars[17] = 1;
      ContentSamples.NpcBestiaryRarityStars[18] = 1;
      ContentSamples.NpcBestiaryRarityStars[38] = 1;
      ContentSamples.NpcBestiaryRarityStars[369] = 2;
      ContentSamples.NpcBestiaryRarityStars[20] = 3;
      ContentSamples.NpcBestiaryRarityStars[19] = 1;
      ContentSamples.NpcBestiaryRarityStars[227] = 2;
      ContentSamples.NpcBestiaryRarityStars[353] = 2;
      ContentSamples.NpcBestiaryRarityStars[550] = 2;
      ContentSamples.NpcBestiaryRarityStars[588] = 2;
      ContentSamples.NpcBestiaryRarityStars[107] = 3;
      ContentSamples.NpcBestiaryRarityStars[228] = 2;
      ContentSamples.NpcBestiaryRarityStars[124] = 2;
      ContentSamples.NpcBestiaryRarityStars[54] = 2;
      ContentSamples.NpcBestiaryRarityStars[108] = 3;
      ContentSamples.NpcBestiaryRarityStars[178] = 3;
      ContentSamples.NpcBestiaryRarityStars[216] = 3;
      ContentSamples.NpcBestiaryRarityStars[160] = 5;
      ContentSamples.NpcBestiaryRarityStars[441] = 5;
      ContentSamples.NpcBestiaryRarityStars[209] = 3;
      ContentSamples.NpcBestiaryRarityStars[208] = 4;
      ContentSamples.NpcBestiaryRarityStars[142] = 5;
      ContentSamples.NpcBestiaryRarityStars[368] = 3;
      ContentSamples.NpcBestiaryRarityStars[453] = 4;
      ContentSamples.NpcBestiaryRarityStars[37] = 2;
      ContentSamples.NpcBestiaryRarityStars[633] = 5;
      ContentSamples.NpcBestiaryRarityStars[638] = 3;
      ContentSamples.NpcBestiaryRarityStars[637] = 3;
      ContentSamples.NpcBestiaryRarityStars[656] = 3;
      ContentSamples.NpcBestiaryRarityStars[484] = 5;
      ContentSamples.NpcBestiaryRarityStars[614] = 4;
      ContentSamples.NpcBestiaryRarityStars[303] = 4;
      ContentSamples.NpcBestiaryRarityStars[337] = 4;
      ContentSamples.NpcBestiaryRarityStars[360] = 3;
      ContentSamples.NpcBestiaryRarityStars[655] = 2;
      ContentSamples.NpcBestiaryRarityStars[374] = 3;
      ContentSamples.NpcBestiaryRarityStars[661] = 3;
      ContentSamples.NpcBestiaryRarityStars[362] = 2;
      ContentSamples.NpcBestiaryRarityStars[364] = 2;
      ContentSamples.NpcBestiaryRarityStars[616] = 2;
      ContentSamples.NpcBestiaryRarityStars[298] = 2;
      ContentSamples.NpcBestiaryRarityStars[599] = 3;
      ContentSamples.NpcBestiaryRarityStars[355] = 2;
      ContentSamples.NpcBestiaryRarityStars[358] = 3;
      ContentSamples.NpcBestiaryRarityStars[654] = 3;
      ContentSamples.NpcBestiaryRarityStars[653] = 2;
      ContentSamples.NpcBestiaryRarityStars[540] = 2;
      ContentSamples.NpcBestiaryRarityStars[604] = 3;
      ContentSamples.NpcBestiaryRarityStars[611] = 3;
      ContentSamples.NpcBestiaryRarityStars[612] = 2;
      ContentSamples.NpcBestiaryRarityStars[608] = 2;
      ContentSamples.NpcBestiaryRarityStars[607] = 2;
      ContentSamples.NpcBestiaryRarityStars[615] = 3;
      ContentSamples.NpcBestiaryRarityStars[626] = 2;
      ContentSamples.NpcBestiaryRarityStars[485] = 2;
      ContentSamples.NpcBestiaryRarityStars[487] = 3;
      ContentSamples.NpcBestiaryRarityStars[149] = 2;
      ContentSamples.NpcBestiaryRarityStars[366] = 2;
      ContentSamples.NpcBestiaryRarityStars[47] = 3;
      ContentSamples.NpcBestiaryRarityStars[57] = 3;
      ContentSamples.NpcBestiaryRarityStars[168] = 3;
      ContentSamples.NpcBestiaryRarityStars[464] = 3;
      ContentSamples.NpcBestiaryRarityStars[465] = 3;
      ContentSamples.NpcBestiaryRarityStars[470] = 3;
      ContentSamples.NpcBestiaryRarityStars[301] = 2;
      ContentSamples.NpcBestiaryRarityStars[316] = 3;
      ContentSamples.NpcBestiaryRarityStars[546] = 2;
      ContentSamples.NpcBestiaryRarityStars[170] = 3;
      ContentSamples.NpcBestiaryRarityStars[180] = 3;
      ContentSamples.NpcBestiaryRarityStars[171] = 3;
      ContentSamples.NpcBestiaryRarityStars[29] = 2;
      ContentSamples.NpcBestiaryRarityStars[471] = 4;
      ContentSamples.NpcBestiaryRarityStars[66] = 3;
      ContentSamples.NpcBestiaryRarityStars[223] = 2;
      ContentSamples.NpcBestiaryRarityStars[161] = 2;
      ContentSamples.NpcBestiaryRarityStars[491] = 4;
      ContentSamples.NpcBestiaryRarityStars[-9] = 3;
      ContentSamples.NpcBestiaryRarityStars[594] = 2;
      ContentSamples.NpcBestiaryRarityStars[628] = 2;
      ContentSamples.NpcBestiaryRarityStars[225] = 2;
      ContentSamples.NpcBestiaryRarityStars[224] = 2;
      ContentSamples.NpcBestiaryRarityStars[250] = 3;
      ContentSamples.NpcBestiaryRarityStars[16] = 2;
      ContentSamples.NpcBestiaryRarityStars[481] = 2;
      ContentSamples.NpcBestiaryRarityStars[483] = 2;
      ContentSamples.NpcBestiaryRarityStars[184] = 2;
      ContentSamples.NpcBestiaryRarityStars[185] = 3;
      ContentSamples.NpcBestiaryRarityStars[206] = 3;
      ContentSamples.NpcBestiaryRarityStars[541] = 4;
      ContentSamples.NpcBestiaryRarityStars[537] = 2;
      ContentSamples.NpcBestiaryRarityStars[205] = 4;
      ContentSamples.NpcBestiaryRarityStars[499] = 2;
      ContentSamples.NpcBestiaryRarityStars[494] = 2;
      ContentSamples.NpcBestiaryRarityStars[496] = 2;
      ContentSamples.NpcBestiaryRarityStars[302] = 3;
      ContentSamples.NpcBestiaryRarityStars[317] = 3;
      ContentSamples.NpcBestiaryRarityStars[318] = 3;
      ContentSamples.NpcBestiaryRarityStars[319] = 3;
      ContentSamples.NpcBestiaryRarityStars[320] = 3;
      ContentSamples.NpcBestiaryRarityStars[321] = 3;
      ContentSamples.NpcBestiaryRarityStars[331] = 3;
      ContentSamples.NpcBestiaryRarityStars[332] = 3;
      ContentSamples.NpcBestiaryRarityStars[322] = 3;
      ContentSamples.NpcBestiaryRarityStars[323] = 3;
      ContentSamples.NpcBestiaryRarityStars[324] = 3;
      ContentSamples.NpcBestiaryRarityStars[335] = 3;
      ContentSamples.NpcBestiaryRarityStars[336] = 3;
      ContentSamples.NpcBestiaryRarityStars[333] = 3;
      ContentSamples.NpcBestiaryRarityStars[334] = 3;
      ContentSamples.NpcBestiaryRarityStars[4] = 2;
      ContentSamples.NpcBestiaryRarityStars[50] = 2;
      ContentSamples.NpcBestiaryRarityStars[35] = 3;
      ContentSamples.NpcBestiaryRarityStars[13] = 3;
      ContentSamples.NpcBestiaryRarityStars[134] = 4;
      ContentSamples.NpcBestiaryRarityStars[262] = 4;
    }

    private static int GetNPCBestiaryRarityStarsCount(NPC npc)
    {
      float num1 = 1f + (float) npc.rarity;
      if (npc.rarity == 1)
        ++num1;
      else if (npc.rarity == 2)
        num1 += 1.5f;
      else if (npc.rarity == 3)
        num1 += 2f;
      else if (npc.rarity == 4)
        num1 += 2.5f;
      else if (npc.rarity == 5)
        num1 += 3f;
      else if (npc.rarity > 0)
        num1 += 3.5f;
      if (npc.boss)
        num1 += 0.5f;
      int num2 = npc.damage + npc.defense + npc.lifeMax / 4;
      if (num2 > 10000)
        num1 += 3.5f;
      else if (num2 > 5000)
        num1 += 3f;
      else if (num2 > 1000)
        num1 += 2.5f;
      else if (num2 > 500)
        num1 += 2f;
      else if (num2 > 150)
        num1 += 1.5f;
      else if (num2 > 50)
        ++num1;
      if ((double) num1 > 5.0)
        num1 = 5f;
      return (int) num1;
    }

    private static void CreateCreativeItemSortingIds() => ContentSamples.CreativeHelper.SetCreativeMenuOrder();

    public static class CommonlyUsedContentSamples
    {
      public static int TeamDyeShaderIndex = -1;
      public static int ColorOnlyShaderIndex = -1;

      public static void PrepareAfterEverythingElseLoaded()
      {
        ContentSamples.CommonlyUsedContentSamples.TeamDyeShaderIndex = (int) GameShaders.Hair.GetShaderIdFromItemId(1984);
        ContentSamples.CommonlyUsedContentSamples.ColorOnlyShaderIndex = GameShaders.Armor.GetShaderIdFromItemId(3978);
      }
    }

    public static class CreativeHelper
    {
      private static List<int> _manualEventItemsOrder = new List<int>()
      {
        361,
        1315,
        2767,
        602,
        1844,
        1958
      };
      private static List<int> _manualBossSpawnItemsOrder = new List<int>()
      {
        43,
        560,
        70,
        1331,
        1133,
        1307,
        267,
        4988,
        544,
        557,
        556,
        1293,
        2673,
        4961,
        3601
      };
      private static List<int> _manualGolfItemsOrder = new List<int>()
      {
        4095,
        4596,
        4597,
        4595,
        4598,
        4592,
        4593,
        4591,
        4594,
        4092,
        4093,
        4039,
        4094,
        4588,
        4589,
        4587,
        4590,
        3989,
        4242,
        4243,
        4244,
        4245,
        4246,
        4247,
        4248,
        4249,
        4250,
        4251,
        4252,
        4253,
        4254,
        4255,
        4040,
        4086,
        4085,
        4088,
        4084,
        4083,
        4087
      };

      public static ContentSamples.CreativeHelper.ItemGroup GetItemGroup(
        Item item,
        out int orderInGroup)
      {
        orderInGroup = 0;
        int num1 = ContentSamples.CreativeHelper._manualGolfItemsOrder.IndexOf(item.type);
        if (num1 != -1)
        {
          orderInGroup = num1;
          return ContentSamples.CreativeHelper.ItemGroup.Golf;
        }
        int num2 = ItemID.Sets.SortingPriorityWiring[item.type];
        if (num2 != -1)
        {
          orderInGroup = -num2;
          return ContentSamples.CreativeHelper.ItemGroup.Wiring;
        }
        if (item.type == 3620)
          return ContentSamples.CreativeHelper.ItemGroup.Wiring;
        if (item.type == 327 || item.type == 329 || item.type == 1141 || item.type == 1533 || item.type == 1537 || item.type == 1536 || item.type == 1534 || item.type == 1535 || item.type == 3092 || item.type == 3091 || item.type == 4714)
        {
          orderInGroup = -item.rare;
          return ContentSamples.CreativeHelper.ItemGroup.Keys;
        }
        if (item.type == 985 || item.type == 3079 || item.type == 3005 || item.type == 3080)
          return ContentSamples.CreativeHelper.ItemGroup.Rope;
        if (item.type == 781 || item.type == 783 || item.type == 780 || item.type == 782 || item.type == 784)
          return ContentSamples.CreativeHelper.ItemGroup.Solutions;
        if (item.type == 282 || item.type == 3112 || item.type == 4776 || item.type == 3002 || item.type == 286)
        {
          if (item.type == 282)
            orderInGroup = -1;
          return ContentSamples.CreativeHelper.ItemGroup.Glowsticks;
        }
        if (item.type == 166 || item.type == 3115 || item.type == 235 || item.type == 167 || item.type == 3547 || item.type == 2896 || item.type == 3196 || item.type == 4908 || item.type == 4909 || item.type == 4827 || item.type == 4826 || item.type == 4825 || item.type == 4423 || item.type == 4824)
          return ContentSamples.CreativeHelper.ItemGroup.Bombs;
        if (item.createTile == 376)
          return ContentSamples.CreativeHelper.ItemGroup.Crates;
        if (item.type == 1774 || item.type == 1869 || item.type == 4345 || item.type == 3093 || item.type == 4410)
          return ContentSamples.CreativeHelper.ItemGroup.GoodieBags;
        if (item.type >= 3318 && item.type <= 3332 || item.type >= 3860 && item.type <= 3862 || item.type == 4782 || item.type == 4957)
          return ContentSamples.CreativeHelper.ItemGroup.BossBags;
        if (item.type == 1115 || item.type == 1114 || item.type == 1110 || item.type == 1112 || item.type == 1108 || item.type == 1107 || item.type == 1116 || item.type == 1109 || item.type == 1111 || item.type == 1118 || item.type == 1117 || item.type == 1113 || item.type == 1119)
          return ContentSamples.CreativeHelper.ItemGroup.DyeMaterial;
        if (item.type == 3385 || item.type == 3386 || item.type == 3387 || item.type == 3388)
        {
          orderInGroup = -1;
          return ContentSamples.CreativeHelper.ItemGroup.DyeMaterial;
        }
        if (item.dye != (byte) 0)
          return ContentSamples.CreativeHelper.ItemGroup.Dye;
        if (item.hairDye != (short) -1)
          return ContentSamples.CreativeHelper.ItemGroup.HairDye;
        if (item.IsACoin)
        {
          if (item.type == 71)
            orderInGroup = 4;
          else if (item.type == 72)
            orderInGroup = 3;
          else if (item.type == 73)
            orderInGroup = 2;
          else if (item.type == 74)
            orderInGroup = 1;
          return ContentSamples.CreativeHelper.ItemGroup.Coin;
        }
        if (item.createWall > 0)
          return ContentSamples.CreativeHelper.ItemGroup.Walls;
        if (item.createTile == 82)
          return ContentSamples.CreativeHelper.ItemGroup.AlchemySeeds;
        if (item.type == 315 || item.type == 313 || item.type == 316 || item.type == 318 || item.type == 314 || item.type == 2358 || item.type == 317)
          return ContentSamples.CreativeHelper.ItemGroup.AlchemyPlants;
        if (item.createTile == 30 || item.createTile == 321 || item.createTile == 322 || item.createTile == 157 || item.createTile == 158 || item.createTile == 208 || item.createTile == 159 || item.createTile == 253 || item.createTile == 311)
        {
          orderInGroup = item.createTile != 30 ? (item.createTile != 311 ? 50 : 100) : 0;
          return ContentSamples.CreativeHelper.ItemGroup.Wood;
        }
        if (item.createTile >= 0)
        {
          if (item.type == 213)
          {
            orderInGroup = -1;
            return ContentSamples.CreativeHelper.ItemGroup.Pickaxe;
          }
          if (item.tileWand >= 0)
            return ContentSamples.CreativeHelper.ItemGroup.Wands;
          if (item.createTile == 213 || item.createTile == 353 || item.createTile == 365 || item.createTile == 366 || item.createTile == 214)
            return ContentSamples.CreativeHelper.ItemGroup.Rope;
          if (!Main.tileSolid[item.createTile] || Main.tileSolidTop[item.createTile] || item.createTile == 10)
          {
            if (item.createTile == 4)
            {
              orderInGroup = item.placeStyle != 0 ? 10 : 5;
              return ContentSamples.CreativeHelper.ItemGroup.Torches;
            }
            orderInGroup = item.createTile != 178 ? (item.createTile != 239 ? (item.type == 27 || item.type == 4857 || item.type == 4852 || item.type == 4856 || item.type == 4854 || item.type == 4855 || item.type == 4853 || item.type == 4851 ? 8 : (!TileID.Sets.Platforms[item.createTile] ? (item.createTile != 18 ? (item.createTile == 16 || item.createTile == 134 ? (item.placeStyle != 0 ? 40 : 39) : (item.createTile == 133 || item.createTile == 17 ? (item.placeStyle != 0 ? 50 : 49) : (item.createTile != 10 ? (item.createTile != 15 ? (item.createTile != 497 ? (item.createTile != 79 ? (item.createTile != 14 ? (item.createTile != 469 ? (item.createTile != 21 ? (item.createTile != 467 ? (item.createTile != 441 ? (item.createTile != 468 ? item.createTile + 1000 : 130) : 120) : 110) : (item.placeStyle != 0 ? 100 : 99)) : 90) : (item.placeStyle != 0 ? 80 : 79)) : (item.placeStyle != 0 ? 75 : 74)) : 72) : (item.placeStyle != 0 ? 70 : 69)) : (item.placeStyle != 0 ? 60 : 59)))) : (item.placeStyle != 0 ? 30 : 29)) : (item.placeStyle != 0 ? 20 : 19))) : 7) : 5;
            return ContentSamples.CreativeHelper.ItemGroup.PlacableObjects;
          }
          orderInGroup = TileID.Sets.Conversion.Grass[item.createTile] || item.type == 194 ? 5 : 10000;
          if (item.type == 2)
            orderInGroup = 10;
          else if (item.type == 3)
            orderInGroup = 20;
          else if (item.type == 133)
            orderInGroup = 30;
          else if (item.type == 424)
            orderInGroup = 40;
          else if (item.type == 1103)
            orderInGroup = 50;
          else if (item.type == 169)
            orderInGroup = 60;
          else if (item.type == 170)
            orderInGroup = 70;
          else if (item.type == 176)
            orderInGroup = 80;
          else if (item.type == 276)
            orderInGroup = 80;
          return ContentSamples.CreativeHelper.ItemGroup.Blocks;
        }
        if (item.mountType != -1)
          return MountID.Sets.Cart[item.mountType] ? ContentSamples.CreativeHelper.ItemGroup.Minecart : ContentSamples.CreativeHelper.ItemGroup.Mount;
        if (item.bait > 0)
        {
          orderInGroup = -item.bait;
          return ContentSamples.CreativeHelper.ItemGroup.FishingBait;
        }
        if (item.makeNPC > (short) 0)
          return ContentSamples.CreativeHelper.ItemGroup.Critters;
        if (item.fishingPole > 1)
        {
          orderInGroup = -item.fishingPole;
          return ContentSamples.CreativeHelper.ItemGroup.FishingRods;
        }
        if (item.questItem)
          return ContentSamples.CreativeHelper.ItemGroup.FishingQuestFish;
        if (item.type >= 2297 && item.type <= 2321 || item.type == 4402 || item.type == 4401 || item.type == 2290)
        {
          orderInGroup = -item.rare;
          return ContentSamples.CreativeHelper.ItemGroup.FishingQuestFish;
        }
        int num3 = ItemID.Sets.SortingPriorityPainting[item.type];
        if (num3 != -1 || item.paint != (byte) 0)
        {
          orderInGroup = -num3;
          return ContentSamples.CreativeHelper.ItemGroup.Paint;
        }
        int num4 = ContentSamples.CreativeHelper._manualBossSpawnItemsOrder.IndexOf(item.type);
        if (num4 != -1)
        {
          orderInGroup = num4;
          return ContentSamples.CreativeHelper.ItemGroup.BossItem;
        }
        int num5 = ContentSamples.CreativeHelper._manualEventItemsOrder.IndexOf(item.type);
        if (num5 != -1)
        {
          orderInGroup = num5;
          return ContentSamples.CreativeHelper.ItemGroup.EventItem;
        }
        if (item.shoot != 0 && Main.projHook[item.shoot])
          return ContentSamples.CreativeHelper.ItemGroup.Hook;
        if (item.type == 2756 || item.type == 2351 || item.type == 4870 || item.type == 2350 || item.type == 2997 || item.type == 2352 || item.type == 2353)
          return ContentSamples.CreativeHelper.ItemGroup.BuffPotion;
        if (item.buffType != 0)
        {
          if (BuffID.Sets.IsWellFed[item.buffType])
          {
            orderInGroup = -item.buffType * 10000000 - item.buffTime;
            return ContentSamples.CreativeHelper.ItemGroup.Food;
          }
          if (BuffID.Sets.IsAFlaskBuff[item.buffType])
            return ContentSamples.CreativeHelper.ItemGroup.Flask;
          if (Main.vanityPet[item.buffType] || Main.lightPet[item.buffType])
            return ContentSamples.CreativeHelper.ItemGroup.VanityPet;
          if (item.damage == -1)
            return ContentSamples.CreativeHelper.ItemGroup.BuffPotion;
        }
        if (item.headSlot >= 0)
        {
          orderInGroup = -item.defense;
          orderInGroup -= item.rare * 1000;
          if (item.vanity)
            orderInGroup += 100000;
          return ContentSamples.CreativeHelper.ItemGroup.Headgear;
        }
        if (item.bodySlot >= 0)
        {
          orderInGroup = -item.defense;
          orderInGroup -= item.rare * 1000;
          if (item.vanity)
            orderInGroup += 100000;
          return ContentSamples.CreativeHelper.ItemGroup.Torso;
        }
        if (item.legSlot >= 0)
        {
          orderInGroup = -item.defense;
          orderInGroup -= item.rare * 1000;
          if (item.vanity)
            orderInGroup += 100000;
          return ContentSamples.CreativeHelper.ItemGroup.Pants;
        }
        if (item.accessory)
        {
          orderInGroup = item.vanity.ToInt() - item.expert.ToInt();
          if (item.type >= 3293 && item.type <= 3308)
            orderInGroup -= 200000;
          else if (item.type >= 3309 && item.type <= 3314)
            orderInGroup -= 100000;
          orderInGroup -= item.rare * 10000;
          if (item.vanity)
            orderInGroup += 100000;
          return ContentSamples.CreativeHelper.ItemGroup.Accessories;
        }
        if (item.pick > 0)
        {
          orderInGroup = -item.pick;
          return ContentSamples.CreativeHelper.ItemGroup.Pickaxe;
        }
        if (item.axe > 0)
        {
          orderInGroup = -item.axe;
          return ContentSamples.CreativeHelper.ItemGroup.Axe;
        }
        if (item.hammer > 0)
        {
          orderInGroup = -item.hammer;
          return ContentSamples.CreativeHelper.ItemGroup.Hammer;
        }
        if (item.healLife > 0)
        {
          orderInGroup = item.type != 3544 ? (item.type != 499 ? (item.type != 188 ? (item.type != 28 ? -item.healLife + 1000 : 3) : 2) : 1) : 0;
          return ContentSamples.CreativeHelper.ItemGroup.LifePotions;
        }
        if (item.healMana > 0)
        {
          orderInGroup = -item.healMana;
          return ContentSamples.CreativeHelper.ItemGroup.ManaPotions;
        }
        if (item.ammo != AmmoID.None && !item.notAmmo && item.type != 23 && item.type != 75)
        {
          orderInGroup = -item.ammo * 10000;
          orderInGroup += -item.damage;
          return ContentSamples.CreativeHelper.ItemGroup.Ammo;
        }
        if (item.consumable)
        {
          if (item.damage > 0)
          {
            orderInGroup = item.type == 422 || item.type == 423 || item.type == 3477 ? -100000 : -item.damage;
            return ContentSamples.CreativeHelper.ItemGroup.ConsumableThatDamages;
          }
          if (item.type == 4910 || item.type == 4829 || item.type == 4830)
            orderInGroup = 10;
          else if (item.type == 66 || item.type == 2886 || item.type == 67)
            orderInGroup = -10;
          else if (item.type >= 1874 && item.type <= 1905)
            orderInGroup = 5;
          return ContentSamples.CreativeHelper.ItemGroup.ConsumableThatDoesNotDamage;
        }
        if (item.damage > 0)
        {
          orderInGroup = -item.damage;
          if (item.melee)
            return ContentSamples.CreativeHelper.ItemGroup.MeleeWeapon;
          if (item.ranged)
            return ContentSamples.CreativeHelper.ItemGroup.RangedWeapon;
          if (item.magic)
            return ContentSamples.CreativeHelper.ItemGroup.MagicWeapon;
          if (item.summon)
            return ContentSamples.CreativeHelper.ItemGroup.SummonWeapon;
        }
        orderInGroup = -item.rare;
        if (item.useStyle > 0)
          return ContentSamples.CreativeHelper.ItemGroup.RemainingUseItems;
        return item.material ? ContentSamples.CreativeHelper.ItemGroup.Material : ContentSamples.CreativeHelper.ItemGroup.EverythingElse;
      }

      public static void SetCreativeMenuOrder()
      {
        List<Item> source1 = new List<Item>();
        for (int Type = 1; Type < 5045; ++Type)
        {
          Item obj = new Item();
          obj.SetDefaults(Type);
          source1.Add(obj);
        }
        IOrderedEnumerable<IGrouping<ContentSamples.CreativeHelper.ItemGroup, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>> source2 = source1.Select<Item, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>((Func<Item, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>) (x => new ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup(x))).GroupBy<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup, ContentSamples.CreativeHelper.ItemGroup>((Func<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup, ContentSamples.CreativeHelper.ItemGroup>) (x => x.Group)).OrderBy<IGrouping<ContentSamples.CreativeHelper.ItemGroup, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>, int>((Func<IGrouping<ContentSamples.CreativeHelper.ItemGroup, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>, int>) (group => (int) group.Key));
        foreach (IEnumerable<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup> groupAndOrderInGroups in (IEnumerable<IGrouping<ContentSamples.CreativeHelper.ItemGroup, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>>) source2)
        {
          foreach (ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup groupAndOrderInGroup in groupAndOrderInGroups)
            ContentSamples.ItemCreativeSortingId[groupAndOrderInGroup.ItemType] = groupAndOrderInGroup;
        }
        source2.SelectMany<IGrouping<ContentSamples.CreativeHelper.ItemGroup, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>((Func<IGrouping<ContentSamples.CreativeHelper.ItemGroup, ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>, IEnumerable<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>>) (group => (IEnumerable<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>) group.ToList<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>())).ToList<ContentSamples.CreativeHelper.ItemGroupAndOrderInGroup>();
      }

      public static bool ShouldRemoveFromList(Item item) => ItemID.Sets.Deprecated[item.type];

      public enum ItemGroup
      {
        Coin = 10, // 0x0000000A
        Torches = 20, // 0x00000014
        Glowsticks = 25, // 0x00000019
        Wood = 30, // 0x0000001E
        Bombs = 40, // 0x00000028
        LifePotions = 50, // 0x00000032
        ManaPotions = 51, // 0x00000033
        BuffPotion = 52, // 0x00000034
        Flask = 53, // 0x00000035
        Food = 54, // 0x00000036
        Crates = 60, // 0x0000003C
        BossBags = 70, // 0x00000046
        GoodieBags = 80, // 0x00000050
        AlchemyPlants = 83, // 0x00000053
        AlchemySeeds = 84, // 0x00000054
        DyeMaterial = 87, // 0x00000057
        BossItem = 90, // 0x0000005A
        EventItem = 91, // 0x0000005B
        ConsumableThatDoesNotDamage = 94, // 0x0000005E
        Solutions = 95, // 0x0000005F
        Ammo = 96, // 0x00000060
        ConsumableThatDamages = 97, // 0x00000061
        PlacableObjects = 100, // 0x00000064
        Blocks = 120, // 0x00000078
        Wands = 130, // 0x00000082
        Rope = 140, // 0x0000008C
        Walls = 150, // 0x00000096
        Wiring = 200, // 0x000000C8
        Pickaxe = 500, // 0x000001F4
        Axe = 510, // 0x000001FE
        Hammer = 520, // 0x00000208
        MeleeWeapon = 530, // 0x00000212
        RangedWeapon = 540, // 0x0000021C
        MagicWeapon = 550, // 0x00000226
        SummonWeapon = 560, // 0x00000230
        Headgear = 600, // 0x00000258
        Torso = 610, // 0x00000262
        Pants = 620, // 0x0000026C
        Accessories = 630, // 0x00000276
        Hook = 700, // 0x000002BC
        Mount = 710, // 0x000002C6
        Minecart = 720, // 0x000002D0
        VanityPet = 800, // 0x00000320
        LightPet = 810, // 0x0000032A
        Golf = 900, // 0x00000384
        Dye = 910, // 0x0000038E
        HairDye = 920, // 0x00000398
        Paint = 930, // 0x000003A2
        FishingRods = 1000, // 0x000003E8
        FishingQuestFish = 1010, // 0x000003F2
        Fish = 1015, // 0x000003F7
        FishingBait = 1020, // 0x000003FC
        Critters = 1030, // 0x00000406
        Keys = 2000, // 0x000007D0
        RemainingUseItems = 5000, // 0x00001388
        Material = 10000, // 0x00002710
        EverythingElse = 11000, // 0x00002AF8
      }

      public struct ItemGroupAndOrderInGroup
      {
        public int ItemType;
        public ContentSamples.CreativeHelper.ItemGroup Group;
        public int OrderInGroup;

        public ItemGroupAndOrderInGroup(Item item)
        {
          this.ItemType = item.type;
          this.Group = ContentSamples.CreativeHelper.GetItemGroup(item, out this.OrderInGroup);
        }
      }
    }

    public static class BestiaryHelper
    {
      public static List<KeyValuePair<int, NPC>> GetSortedBestiaryEntriesList(
        BestiaryDatabase database)
      {
        List<IBestiaryInfoElement> commonFilters = BestiaryDatabaseNPCsPopulator.CommonTags.GetCommonInfoElementsForFilters();
        List<KeyValuePair<int, NPC>> list = ContentSamples.NpcsByNetId.ToList<KeyValuePair<int, NPC>>().OrderBy<KeyValuePair<int, NPC>, int>((Func<KeyValuePair<int, NPC>, int>) (x => ContentSamples.BestiaryHelper.GetBestiaryTownPriority(x.Value))).ThenBy<KeyValuePair<int, NPC>, bool>((Func<KeyValuePair<int, NPC>, bool>) (x => !x.Value.isLikeATownNPC)).ThenBy<KeyValuePair<int, NPC>, int>((Func<KeyValuePair<int, NPC>, int>) (x => ContentSamples.BestiaryHelper.GetBestiaryNormalGoldCritterPriority(x.Value))).ThenBy<KeyValuePair<int, NPC>, bool>((Func<KeyValuePair<int, NPC>, bool>) (x => !x.Value.CountsAsACritter)).ThenBy<KeyValuePair<int, NPC>, int>((Func<KeyValuePair<int, NPC>, int>) (x => ContentSamples.BestiaryHelper.GetBestiaryBossPriority(x.Value))).ThenBy<KeyValuePair<int, NPC>, bool>((Func<KeyValuePair<int, NPC>, bool>) (x => x.Value.boss || NPCID.Sets.ShouldBeCountedAsBoss[x.Value.type])).ThenBy<KeyValuePair<int, NPC>, int>((Func<KeyValuePair<int, NPC>, int>) (x => ContentSamples.BestiaryHelper.GetLowestBiomeGroupIndex(x.Value, database, commonFilters))).ThenBy<KeyValuePair<int, NPC>, int>((Func<KeyValuePair<int, NPC>, int>) (x => x.Value.aiStyle)).ThenBy<KeyValuePair<int, NPC>, float>((Func<KeyValuePair<int, NPC>, float>) (x => ContentSamples.BestiaryHelper.GetBestiaryPowerLevel(x.Value))).ThenBy<KeyValuePair<int, NPC>, int>((Func<KeyValuePair<int, NPC>, int>) (x => ContentSamples.BestiaryHelper.GetBestiaryStarsPriority(x.Value))).ToList<KeyValuePair<int, NPC>>();
        list.RemoveAll((Predicate<KeyValuePair<int, NPC>>) (x => ContentSamples.BestiaryHelper.ShouldHideBestiaryEntry(x.Value)));
        return list;
      }

      public static int GetLowestBiomeGroupIndex(
        NPC npc,
        BestiaryDatabase database,
        List<IBestiaryInfoElement> commonElements)
      {
        List<IBestiaryInfoElement> info = database.FindEntryByNPCID(npc.netID).Info;
        for (int index = commonElements.Count - 1; index >= 0; --index)
        {
          if (info.IndexOf(commonElements[index]) != -1)
            return index;
        }
        return int.MaxValue;
      }

      public static bool ShouldHideBestiaryEntry(NPC npc)
      {
        NPCID.Sets.NPCBestiaryDrawModifiers bestiaryDrawModifiers;
        return NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(npc.netID, out bestiaryDrawModifiers) && bestiaryDrawModifiers.Hide;
      }

      public static float GetBestiaryPowerLevel(NPC npc) => (float) (npc.damage + npc.defense + npc.lifeMax / 4);

      public static int GetBestiaryTownPriority(NPC npc)
      {
        int num = NPCID.Sets.TownNPCBestiaryPriority.IndexOf(npc.netID);
        if (num == -1)
          num = int.MaxValue;
        return num;
      }

      public static int GetBestiaryNormalGoldCritterPriority(NPC npc)
      {
        int num = NPCID.Sets.NormalGoldCritterBestiaryPriority.IndexOf(npc.netID);
        if (num == -1)
          num = int.MaxValue;
        return num;
      }

      public static int GetBestiaryBossPriority(NPC npc) => NPCID.Sets.BossBestiaryPriority.IndexOf(npc.netID);

      public static int GetBestiaryStarsPriority(NPC npc) => ContentSamples.NpcBestiaryRarityStars[npc.type];
    }
  }
}
