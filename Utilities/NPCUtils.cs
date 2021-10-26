// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.NPCUtils
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.Utilities
{
  public static class NPCUtils
  {
    public static NPCUtils.TargetSearchResults SearchForTarget(
      Vector2 position,
      NPCUtils.TargetSearchFlag flags = NPCUtils.TargetSearchFlag.All,
      NPCUtils.SearchFilter<Player> playerFilter = null,
      NPCUtils.SearchFilter<NPC> npcFilter = null)
    {
      return NPCUtils.SearchForTarget((NPC) null, position, flags, playerFilter, npcFilter);
    }

    public static NPCUtils.TargetSearchResults SearchForTarget(
      NPC searcher,
      NPCUtils.TargetSearchFlag flags = NPCUtils.TargetSearchFlag.All,
      NPCUtils.SearchFilter<Player> playerFilter = null,
      NPCUtils.SearchFilter<NPC> npcFilter = null)
    {
      return NPCUtils.SearchForTarget(searcher, searcher.Center, flags, playerFilter, npcFilter);
    }

    public static NPCUtils.TargetSearchResults SearchForTarget(
      NPC searcher,
      Vector2 position,
      NPCUtils.TargetSearchFlag flags = NPCUtils.TargetSearchFlag.All,
      NPCUtils.SearchFilter<Player> playerFilter = null,
      NPCUtils.SearchFilter<NPC> npcFilter = null)
    {
      float num1 = float.MaxValue;
      int nearestNPCIndex = -1;
      float adjustedTankDistance = float.MaxValue;
      float nearestTankDistance = float.MaxValue;
      int nearestTankIndex = -1;
      NPCUtils.TargetType tankType = NPCUtils.TargetType.Player;
      if (flags.HasFlag((Enum) NPCUtils.TargetSearchFlag.NPCs))
      {
        for (int index = 0; index < 200; ++index)
        {
          NPC entity = Main.npc[index];
          if (entity.active && entity.whoAmI != searcher.whoAmI && (npcFilter == null || npcFilter(entity)))
          {
            float num2 = Vector2.DistanceSquared(position, entity.Center);
            if ((double) num2 < (double) num1)
            {
              nearestNPCIndex = index;
              num1 = num2;
            }
          }
        }
      }
      if (flags.HasFlag((Enum) NPCUtils.TargetSearchFlag.Players))
      {
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          Player entity = Main.player[index];
          if (entity.active && !entity.dead && !entity.ghost && (playerFilter == null || playerFilter(entity)))
          {
            float num3 = Vector2.Distance(position, entity.Center);
            float num4 = num3 - (float) entity.aggro;
            bool flag = searcher != null && entity.npcTypeNoAggro[searcher.type];
            if (searcher != null & flag && searcher.direction == 0)
              num4 += 1000f;
            if ((double) num4 < (double) adjustedTankDistance)
            {
              nearestTankIndex = index;
              adjustedTankDistance = num4;
              nearestTankDistance = num3;
              tankType = NPCUtils.TargetType.Player;
            }
            if (entity.tankPet >= 0 && !flag)
            {
              Vector2 center = Main.projectile[entity.tankPet].Center;
              float num5 = Vector2.Distance(position, center);
              float num6 = num5 - 200f;
              if ((double) num6 < (double) adjustedTankDistance && (double) num6 < 200.0 && Collision.CanHit(position, 0, 0, center, 0, 0))
              {
                nearestTankIndex = index;
                adjustedTankDistance = num6;
                nearestTankDistance = num5;
                tankType = NPCUtils.TargetType.TankPet;
              }
            }
          }
        }
      }
      return new NPCUtils.TargetSearchResults(searcher, nearestNPCIndex, (float) Math.Sqrt((double) num1), nearestTankIndex, nearestTankDistance, adjustedTankDistance, tankType);
    }

    public static void TargetClosestOldOnesInvasion(
      NPC searcher,
      bool faceTarget = true,
      Vector2? checkPosition = null)
    {
      NPCUtils.TargetSearchResults searchResults = NPCUtils.SearchForTarget(searcher, playerFilter: NPCUtils.SearchFilters.OnlyPlayersInCertainDistance(searcher.Center, 200f), npcFilter: new NPCUtils.SearchFilter<NPC>(NPCUtils.SearchFilters.OnlyCrystal));
      if (!searchResults.FoundTarget)
        return;
      searcher.target = searchResults.NearestTargetIndex;
      searcher.targetRect = searchResults.NearestTargetHitbox;
      if (!(searcher.ShouldFaceTarget(ref searchResults) & faceTarget))
        return;
      searcher.FaceTarget();
    }

    public static void TargetClosestNonBees(NPC searcher, bool faceTarget = true, Vector2? checkPosition = null)
    {
      NPCUtils.TargetSearchResults searchResults = NPCUtils.SearchForTarget(searcher, npcFilter: new NPCUtils.SearchFilter<NPC>(NPCUtils.SearchFilters.NonBeeNPCs));
      if (!searchResults.FoundTarget)
        return;
      searcher.target = searchResults.NearestTargetIndex;
      searcher.targetRect = searchResults.NearestTargetHitbox;
      if (!(searcher.ShouldFaceTarget(ref searchResults) & faceTarget))
        return;
      searcher.FaceTarget();
    }

    public static void TargetClosestCommon(NPC searcher, bool faceTarget = true, Vector2? checkPosition = null) => searcher.TargetClosest(faceTarget);

    public static void TargetClosestBetsy(NPC searcher, bool faceTarget = true, Vector2? checkPosition = null)
    {
      NPCUtils.TargetSearchResults searchResults = NPCUtils.SearchForTarget(searcher, npcFilter: new NPCUtils.SearchFilter<NPC>(NPCUtils.SearchFilters.OnlyCrystal));
      if (!searchResults.FoundTarget)
        return;
      NPCUtils.TargetType targetType = searchResults.NearestTargetType;
      if (searchResults.FoundTank && !searchResults.NearestTankOwner.dead)
        targetType = NPCUtils.TargetType.Player;
      searcher.target = searchResults.NearestTargetIndex;
      searcher.targetRect = searchResults.NearestTargetHitbox;
      if (!(searcher.ShouldFaceTarget(ref searchResults, new NPCUtils.TargetType?(targetType)) & faceTarget))
        return;
      searcher.FaceTarget();
    }

    public delegate bool SearchFilter<T>(T entity) where T : Entity;

    public delegate void NPCTargetingMethod(NPC searcher, bool faceTarget, Vector2? checkPosition);

    public static class SearchFilters
    {
      public static bool OnlyCrystal(NPC npc) => npc.type == 548 && !npc.dontTakeDamageFromHostiles;

      public static NPCUtils.SearchFilter<Player> OnlyPlayersInCertainDistance(
        Vector2 position,
        float maxDistance)
      {
        return (NPCUtils.SearchFilter<Player>) (player => (double) player.Distance(position) <= (double) maxDistance);
      }

      public static bool NonBeeNPCs(NPC npc) => npc.type != 211 && npc.type != 210 && npc.type != 222 && npc.CanBeChasedBy();
    }

    public enum TargetType
    {
      None,
      NPC,
      Player,
      TankPet,
    }

    public struct TargetSearchResults
    {
      private NPCUtils.TargetType _nearestTargetType;
      private int _nearestNPCIndex;
      private float _nearestNPCDistance;
      private int _nearestTankIndex;
      private float _nearestTankDistance;
      private float _adjustedTankDistance;
      private NPCUtils.TargetType _nearestTankType;

      public int NearestTargetIndex
      {
        get
        {
          switch (this._nearestTargetType)
          {
            case NPCUtils.TargetType.NPC:
              return this.NearestNPC.WhoAmIToTargettingIndex;
            case NPCUtils.TargetType.Player:
            case NPCUtils.TargetType.TankPet:
              return this._nearestTankIndex;
            default:
              return -1;
          }
        }
      }

      public Rectangle NearestTargetHitbox
      {
        get
        {
          switch (this._nearestTargetType)
          {
            case NPCUtils.TargetType.NPC:
              return this.NearestNPC.Hitbox;
            case NPCUtils.TargetType.Player:
              return this.NearestTankOwner.Hitbox;
            case NPCUtils.TargetType.TankPet:
              return Main.projectile[this.NearestTankOwner.tankPet].Hitbox;
            default:
              return Rectangle.Empty;
          }
        }
      }

      public NPCUtils.TargetType NearestTargetType => this._nearestTargetType;

      public bool FoundTarget => (uint) this._nearestTargetType > 0U;

      public NPC NearestNPC => this._nearestNPCIndex != -1 ? Main.npc[this._nearestNPCIndex] : (NPC) null;

      public bool FoundNPC => this._nearestNPCIndex != -1;

      public int NearestNPCIndex => this._nearestNPCIndex;

      public float NearestNPCDistance => this._nearestNPCDistance;

      public Player NearestTankOwner => this._nearestTankIndex != -1 ? Main.player[this._nearestTankIndex] : (Player) null;

      public bool FoundTank => this._nearestTankIndex != -1;

      public int NearestTankOwnerIndex => this._nearestTankIndex;

      public float NearestTankDistance => this._nearestTankDistance;

      public float AdjustedTankDistance => this._adjustedTankDistance;

      public NPCUtils.TargetType NearestTankType => this._nearestTankType;

      public TargetSearchResults(
        NPC searcher,
        int nearestNPCIndex,
        float nearestNPCDistance,
        int nearestTankIndex,
        float nearestTankDistance,
        float adjustedTankDistance,
        NPCUtils.TargetType tankType)
      {
        this._nearestNPCIndex = nearestNPCIndex;
        this._nearestNPCDistance = nearestNPCDistance;
        this._nearestTankIndex = nearestTankIndex;
        this._adjustedTankDistance = adjustedTankDistance;
        this._nearestTankDistance = nearestTankDistance;
        this._nearestTankType = tankType;
        if (this._nearestNPCIndex != -1 && this._nearestTankIndex != -1)
        {
          if ((double) this._nearestNPCDistance < (double) this._adjustedTankDistance)
            this._nearestTargetType = NPCUtils.TargetType.NPC;
          else
            this._nearestTargetType = tankType;
        }
        else if (this._nearestNPCIndex != -1)
          this._nearestTargetType = NPCUtils.TargetType.NPC;
        else if (this._nearestTankIndex != -1)
          this._nearestTargetType = tankType;
        else
          this._nearestTargetType = NPCUtils.TargetType.None;
      }
    }

    [Flags]
    public enum TargetSearchFlag
    {
      None = 0,
      NPCs = 1,
      Players = 2,
      All = Players | NPCs, // 0x00000003
    }
  }
}
