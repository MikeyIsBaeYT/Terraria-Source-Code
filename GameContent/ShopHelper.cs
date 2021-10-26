// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ShopHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria.GameContent
{
  public class ShopHelper
  {
    private const float LowestPossiblePriceMultiplier = 0.75f;
    private const float HighestPossiblePriceMultiplier = 1.5f;
    private string _currentHappiness;
    private float _currentPriceAdjustment;
    private NPC _currentNPCBeingTalkedTo;
    private Player _currentPlayerTalking;
    private const float likeValue = 0.95f;
    private const float dislikeValue = 1.05f;
    private const float loveValue = 0.9f;
    private const float hateValue = 1.1f;

    public ShoppingSettings GetShoppingSettings(Player player, NPC npc)
    {
      ShoppingSettings shoppingSettings = new ShoppingSettings()
      {
        PriceAdjustment = 1.0,
        HappinessReport = ""
      };
      this._currentNPCBeingTalkedTo = npc;
      this._currentPlayerTalking = player;
      this.ProcessMood(player, npc);
      shoppingSettings.PriceAdjustment = (double) this._currentPriceAdjustment;
      shoppingSettings.HappinessReport = this._currentHappiness;
      return shoppingSettings;
    }

    private float GetSkeletonMerchantPrices(NPC npc)
    {
      float num = 1f;
      if (Main.moonPhase == 1 || Main.moonPhase == 7)
        num = 1.1f;
      if (Main.moonPhase == 2 || Main.moonPhase == 6)
        num = 1.2f;
      if (Main.moonPhase == 3 || Main.moonPhase == 5)
        num = 1.3f;
      if (Main.moonPhase == 4)
        num = 1.4f;
      if (Main.dayTime)
        num += 0.1f;
      return num;
    }

    private float GetTravelingMerchantPrices(NPC npc) => (float) ((2.0 + (double) (1.5f - Vector2.Distance(npc.Center / 16f, new Vector2((float) Main.spawnTileX, (float) Main.spawnTileY)) / (float) (Main.maxTilesX / 2))) / 3.0);

    private void ProcessMood(Player player, NPC npc)
    {
      this._currentHappiness = "";
      this._currentPriceAdjustment = 1f;
      if (npc.type == 368)
        this._currentPriceAdjustment = 1f;
      else if (npc.type == 453)
      {
        this._currentPriceAdjustment = 1f;
      }
      else
      {
        if (npc.type == 656 || npc.type == 637 || npc.type == 638)
          return;
        if (this.IsNotReallyTownNPC(npc))
        {
          this._currentPriceAdjustment = 1f;
        }
        else
        {
          if (this.RuinMoodIfHomeless(npc))
            this._currentPriceAdjustment = 1000f;
          else if (this.IsFarFromHome(npc))
            this._currentPriceAdjustment = 1000f;
          if (this.IsPlayerInEvilBiomes(player))
            this._currentPriceAdjustment = 1000f;
          int npcsWithinHouse;
          int npcsWithinVillage;
          List<NPC> nearbyResidentNpCs = this.GetNearbyResidentNPCs(npc, out npcsWithinHouse, out npcsWithinVillage);
          if (npcsWithinHouse > 2)
          {
            for (int index = 2; index < npcsWithinHouse + 1; ++index)
              this._currentPriceAdjustment *= 1.04f;
            if (npcsWithinHouse > 4)
              this.AddHappinessReportText("HateCrowded");
            else
              this.AddHappinessReportText("DislikeCrowded");
          }
          if (npcsWithinHouse < 2 && npcsWithinVillage < 4)
          {
            this.AddHappinessReportText("LoveSpace");
            this._currentPriceAdjustment *= 0.9f;
          }
          bool[] flagArray = new bool[663];
          foreach (NPC npc1 in nearbyResidentNpCs)
            flagArray[npc1.type] = true;
          new AllPersonalitiesModifier().ModifyShopPrice(new HelperInfo()
          {
            player = player,
            npc = npc,
            NearbyNPCs = nearbyResidentNpCs,
            PrimaryPlayerBiome = player.GetPrimaryBiome(),
            nearbyNPCsByType = flagArray
          }, this);
          if (this._currentHappiness == "")
            this.AddHappinessReportText("Content");
          this._currentPriceAdjustment = this.LimitAndRoundMultiplier(this._currentPriceAdjustment);
        }
      }
    }

    private float LimitAndRoundMultiplier(float priceAdjustment)
    {
      priceAdjustment = MathHelper.Clamp(priceAdjustment, 0.75f, 1.5f);
      priceAdjustment = (float) Math.Round((double) priceAdjustment * 20.0) / 20f;
      return priceAdjustment;
    }

    private static string BiomeName(int biomeID)
    {
      switch (biomeID)
      {
        case 1:
          return "the Underground";
        case 2:
          return "the Snow";
        case 3:
          return "the Desert";
        case 4:
          return "the Jungle";
        case 5:
          return "the Ocean";
        case 6:
          return "the Hallow";
        case 7:
          return "the Glowing Mushrooms";
        case 8:
          return "the Dungeon";
        case 9:
          return "the Corruption";
        case 10:
          return "the Crimson";
        default:
          return "the Forest";
      }
    }

    private static string BiomeNameKey(int biomeID)
    {
      switch (biomeID)
      {
        case 1:
          return "the Underground";
        case 2:
          return "the Snow";
        case 3:
          return "the Desert";
        case 4:
          return "the Jungle";
        case 5:
          return "the Ocean";
        case 6:
          return "the Hallow";
        case 7:
          return "the Glowing Mushrooms";
        case 8:
          return "the Dungeon";
        case 9:
          return "the Corruption";
        case 10:
          return "the Crimson";
        default:
          return "the Forest";
      }
    }

    private void AddHappinessReportText(string textKeyInCategory, object substitutes = null)
    {
      string str = "TownNPCMood_" + NPCID.Search.GetName(this._currentNPCBeingTalkedTo.netID);
      if (this._currentNPCBeingTalkedTo.type == 633 && this._currentNPCBeingTalkedTo.altTexture == 2)
        str += "Transformed";
      this._currentHappiness = this._currentHappiness + Language.GetTextValueWith(str + "." + textKeyInCategory, substitutes) + " ";
    }

    public void LikeBiome(int biomeID)
    {
      this.AddHappinessReportText(nameof (LikeBiome), (object) new
      {
        BiomeName = ShopHelper.BiomeNameKey(biomeID)
      });
      this._currentPriceAdjustment *= 0.95f;
    }

    public void LoveBiome(int biomeID)
    {
      this.AddHappinessReportText(nameof (LoveBiome), (object) new
      {
        BiomeName = ShopHelper.BiomeNameKey(biomeID)
      });
      this._currentPriceAdjustment *= 0.9f;
    }

    public void DislikeBiome(int biomeID)
    {
      this.AddHappinessReportText(nameof (DislikeBiome), (object) new
      {
        BiomeName = ShopHelper.BiomeNameKey(biomeID)
      });
      this._currentPriceAdjustment *= 1.05f;
    }

    public void HateBiome(int biomeID)
    {
      this.AddHappinessReportText(nameof (HateBiome), (object) new
      {
        BiomeName = ShopHelper.BiomeNameKey(biomeID)
      });
      this._currentPriceAdjustment *= 1.1f;
    }

    public void LikeNPC(int npcType)
    {
      this.AddHappinessReportText(nameof (LikeNPC), (object) new
      {
        NPCName = NPC.GetFullnameByID(npcType)
      });
      this._currentPriceAdjustment *= 0.95f;
    }

    public void LoveNPC(int npcType)
    {
      this.AddHappinessReportText(nameof (LoveNPC), (object) new
      {
        NPCName = NPC.GetFullnameByID(npcType)
      });
      this._currentPriceAdjustment *= 0.9f;
    }

    public void DislikeNPC(int npcType)
    {
      this.AddHappinessReportText(nameof (DislikeNPC), (object) new
      {
        NPCName = NPC.GetFullnameByID(npcType)
      });
      this._currentPriceAdjustment *= 1.05f;
    }

    public void HateNPC(int npcType)
    {
      this.AddHappinessReportText(nameof (HateNPC), (object) new
      {
        NPCName = NPC.GetFullnameByID(npcType)
      });
      this._currentPriceAdjustment *= 1.1f;
    }

    private List<NPC> GetNearbyResidentNPCs(
      NPC npc,
      out int npcsWithinHouse,
      out int npcsWithinVillage)
    {
      List<NPC> npcList = new List<NPC>();
      npcsWithinHouse = 0;
      npcsWithinVillage = 0;
      Vector2 vector2_1 = new Vector2((float) npc.homeTileX, (float) npc.homeTileY);
      if (npc.homeless)
        vector2_1 = new Vector2(npc.Center.X / 16f, npc.Center.Y / 16f);
      for (int index = 0; index < 200; ++index)
      {
        if (index != npc.whoAmI)
        {
          NPC npc1 = Main.npc[index];
          if (npc1.active && npc1.townNPC && !this.IsNotReallyTownNPC(npc1) && !WorldGen.TownManager.CanNPCsLiveWithEachOther_ShopHelper(npc, npc1))
          {
            Vector2 vector2_2 = new Vector2((float) npc1.homeTileX, (float) npc1.homeTileY);
            if (npc1.homeless)
              vector2_2 = npc1.Center / 16f;
            float num = Vector2.Distance(vector2_1, vector2_2);
            if ((double) num < 25.0)
            {
              npcList.Add(npc1);
              ++npcsWithinHouse;
            }
            else if ((double) num < 120.0)
              ++npcsWithinVillage;
          }
        }
      }
      return npcList;
    }

    private bool RuinMoodIfHomeless(NPC npc)
    {
      if (npc.homeless)
        this.AddHappinessReportText("NoHome");
      return npc.homeless;
    }

    private bool IsFarFromHome(NPC npc)
    {
      if ((double) Vector2.Distance(new Vector2((float) npc.homeTileX, (float) npc.homeTileY), new Vector2(npc.Center.X / 16f, npc.Center.Y / 16f)) <= 120.0)
        return false;
      this.AddHappinessReportText("FarFromHome");
      return true;
    }

    private bool IsPlayerInEvilBiomes(Player player)
    {
      if (player.ZoneCorrupt)
      {
        this.AddHappinessReportText("HateBiome", (object) new
        {
          BiomeName = ShopHelper.BiomeNameKey(9)
        });
        return true;
      }
      if (player.ZoneCrimson)
      {
        this.AddHappinessReportText("HateBiome", (object) new
        {
          BiomeName = ShopHelper.BiomeNameKey(10)
        });
        return true;
      }
      if (!player.ZoneDungeon)
        return false;
      this.AddHappinessReportText("HateBiome", (object) new
      {
        BiomeName = ShopHelper.BiomeNameKey(8)
      });
      return true;
    }

    private bool IsNotReallyTownNPC(NPC npc)
    {
      switch (npc.type)
      {
        case 37:
        case 368:
        case 453:
          return true;
        default:
          return false;
      }
    }
  }
}
