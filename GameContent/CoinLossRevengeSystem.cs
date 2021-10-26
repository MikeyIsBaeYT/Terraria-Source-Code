// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.CoinLossRevengeSystem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent
{
  public class CoinLossRevengeSystem
  {
    public static bool DisplayCaching = false;
    public static int MinimumCoinsForCaching = Item.buyPrice(silver: 10);
    private const int PLAYER_BOX_WIDTH_INNER = 1968;
    private const int PLAYER_BOX_HEIGHT_INNER = 1200;
    private const int PLAYER_BOX_WIDTH_OUTER = 2608;
    private const int PLAYER_BOX_HEIGHT_OUTER = 1840;
    private static readonly Vector2 _playerBoxSizeInner = new Vector2(1968f, 1200f);
    private static readonly Vector2 _playerBoxSizeOuter = new Vector2(2608f, 1840f);
    private List<CoinLossRevengeSystem.RevengeMarker> _markers;
    private readonly object _markersLock = new object();
    private int _gameTime;

    public void AddMarkerFromReader(BinaryReader reader)
    {
      int num1 = reader.ReadInt32();
      Vector2 coords = reader.ReadVector2();
      int num2 = reader.ReadInt32();
      float num3 = reader.ReadSingle();
      int num4 = reader.ReadInt32();
      int num5 = reader.ReadInt32();
      int num6 = reader.ReadInt32();
      float num7 = reader.ReadSingle();
      bool flag = reader.ReadBoolean();
      int npcNetId = num2;
      double num8 = (double) num3;
      int npcType = num4;
      int npcAiStyle = num5;
      int coinValue = num6;
      double num9 = (double) num7;
      int num10 = flag ? 1 : 0;
      int gameTime = this._gameTime;
      int uniqueID = num1;
      this.AddMarker(new CoinLossRevengeSystem.RevengeMarker(coords, npcNetId, (float) num8, npcType, npcAiStyle, coinValue, (float) num9, num10 != 0, gameTime, uniqueID));
    }

    private void AddMarker(CoinLossRevengeSystem.RevengeMarker marker)
    {
      lock (this._markersLock)
        this._markers.Add(marker);
    }

    public void DestroyMarker(int markerUniqueID)
    {
      lock (this._markersLock)
        this._markers.RemoveAll((Predicate<CoinLossRevengeSystem.RevengeMarker>) (x => x.UniqueID == markerUniqueID));
    }

    public CoinLossRevengeSystem() => this._markers = new List<CoinLossRevengeSystem.RevengeMarker>();

    public void CacheEnemy(NPC npc)
    {
      if (npc.boss || npc.realLife != -1 || npc.rarity > 0 || npc.extraValue < CoinLossRevengeSystem.MinimumCoinsForCaching || (double) npc.position.X < (double) Main.leftWorld + 640.0 + 16.0 || (double) npc.position.X + (double) npc.width > (double) Main.rightWorld - 640.0 - 32.0 || (double) npc.position.Y < (double) Main.topWorld + 640.0 + 16.0 || (double) npc.position.Y > (double) Main.bottomWorld - 640.0 - 32.0 - (double) npc.height)
        return;
      int num1 = npc.netID;
      int num2;
      if (NPCID.Sets.RespawnEnemyID.TryGetValue(num1, out num2))
        num1 = num2;
      if (num1 == 0)
        return;
      CoinLossRevengeSystem.RevengeMarker marker = new CoinLossRevengeSystem.RevengeMarker(npc.Center, num1, npc.GetLifePercent(), npc.type, npc.aiStyle, npc.extraValue, npc.value, npc.SpawnedFromStatue, this._gameTime);
      this.AddMarker(marker);
      if (Main.netMode == 2)
        NetMessage.SendCoinLossRevengeMarker(marker);
      if (!CoinLossRevengeSystem.DisplayCaching)
        return;
      Main.NewText("Cached " + npc.GivenOrTypeName);
    }

    public void Reset()
    {
      lock (this._markersLock)
        this._markers.Clear();
      this._gameTime = 0;
    }

    public void Update()
    {
      ++this._gameTime;
      if (Main.netMode != 1 || this._gameTime % 60 != 0)
        return;
      this.RemoveExpiredOrInvalidMarkers();
    }

    public void CheckRespawns()
    {
      lock (this._markersLock)
      {
        if (this._markers.Count == 0)
          return;
      }
      List<Tuple<int, Rectangle, Rectangle>> tupleList = new List<Tuple<int, Rectangle, Rectangle>>();
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        Player player = Main.player[index];
        if (player.active && !player.dead)
          tupleList.Add(Tuple.Create<int, Rectangle, Rectangle>(index, Utils.CenteredRectangle(player.Center, CoinLossRevengeSystem._playerBoxSizeInner), Utils.CenteredRectangle(player.Center, CoinLossRevengeSystem._playerBoxSizeOuter)));
      }
      if (tupleList.Count == 0)
        return;
      this.RemoveExpiredOrInvalidMarkers();
      lock (this._markersLock)
      {
        List<CoinLossRevengeSystem.RevengeMarker> revengeMarkerList = new List<CoinLossRevengeSystem.RevengeMarker>();
        for (int index = 0; index < this._markers.Count; ++index)
        {
          CoinLossRevengeSystem.RevengeMarker marker = this._markers[index];
          bool flag = false;
          Tuple<int, Rectangle, Rectangle> tuple1 = (Tuple<int, Rectangle, Rectangle>) null;
          foreach (Tuple<int, Rectangle, Rectangle> tuple2 in tupleList)
          {
            if (marker.Intersects(tuple2.Item2, tuple2.Item3))
            {
              tuple1 = tuple2;
              flag = true;
              break;
            }
          }
          if (!flag)
            marker.SetRespawnAttemptLock(false);
          else if (!marker.RespawnAttemptLocked)
          {
            marker.SetRespawnAttemptLock(true);
            if (marker.WouldNPCBeDiscouraged(Main.player[tuple1.Item1]))
            {
              marker.SetToExpire();
            }
            else
            {
              marker.SpawnEnemy();
              revengeMarkerList.Add(marker);
            }
          }
        }
        this._markers = this._markers.Except<CoinLossRevengeSystem.RevengeMarker>((IEnumerable<CoinLossRevengeSystem.RevengeMarker>) revengeMarkerList).ToList<CoinLossRevengeSystem.RevengeMarker>();
      }
    }

    private void RemoveExpiredOrInvalidMarkers()
    {
      lock (this._markersLock)
      {
        this._markers.Where<CoinLossRevengeSystem.RevengeMarker>((Func<CoinLossRevengeSystem.RevengeMarker, bool>) (x => x.IsExpired(this._gameTime)));
        this._markers.Where<CoinLossRevengeSystem.RevengeMarker>((Func<CoinLossRevengeSystem.RevengeMarker, bool>) (x => x.IsInvalid()));
        this._markers.RemoveAll((Predicate<CoinLossRevengeSystem.RevengeMarker>) (x => x.IsInvalid()));
        this._markers.RemoveAll((Predicate<CoinLossRevengeSystem.RevengeMarker>) (x => x.IsExpired(this._gameTime)));
      }
    }

    public CoinLossRevengeSystem.RevengeMarker DrawMapIcons(
      SpriteBatch spriteBatch,
      Vector2 mapTopLeft,
      Vector2 mapX2Y2AndOff,
      Rectangle? mapRect,
      float mapScale,
      float drawScale,
      ref string unused)
    {
      CoinLossRevengeSystem.RevengeMarker revengeMarker = (CoinLossRevengeSystem.RevengeMarker) null;
      lock (this._markersLock)
      {
        foreach (CoinLossRevengeSystem.RevengeMarker marker in this._markers)
        {
          if (marker.DrawMapIcon(spriteBatch, mapTopLeft, mapX2Y2AndOff, mapRect, mapScale, drawScale, this._gameTime))
            revengeMarker = marker;
        }
      }
      return revengeMarker;
    }

    public void SendAllMarkersToPlayer(int plr)
    {
      lock (this._markersLock)
      {
        foreach (CoinLossRevengeSystem.RevengeMarker marker in this._markers)
          NetMessage.SendCoinLossRevengeMarker(marker, plr);
      }
    }

    public class RevengeMarker
    {
      private static int _uniqueIDCounter = 0;
      private static readonly int _expirationCompCopper = Item.buyPrice(copper: 1);
      private static readonly int _expirationCompSilver = Item.buyPrice(silver: 1);
      private static readonly int _expirationCompGold = Item.buyPrice(gold: 1);
      private static readonly int _expirationCompPlat = Item.buyPrice(1);
      private const int ONE_MINUTE = 3600;
      private const int ENEMY_BOX_WIDTH = 2160;
      private const int ENEMY_BOX_HEIGHT = 1440;
      public static readonly Vector2 EnemyBoxSize = new Vector2(2160f, 1440f);
      private readonly Vector2 _location;
      private readonly Rectangle _hitbox;
      private readonly int _npcNetID;
      private readonly float _npcHPPercent;
      private readonly float _baseValue;
      private readonly int _coinsValue;
      private readonly int _npcTypeAgainstDiscouragement;
      private readonly int _npcAIStyleAgainstDiscouragement;
      private readonly int _expirationTime;
      private readonly bool _spawnedFromStatue;
      private readonly int _uniqueID;
      private bool _forceExpire;
      private bool _attemptedRespawn;

      public void SetToExpire() => this._forceExpire = true;

      public bool RespawnAttemptLocked => this._attemptedRespawn;

      public void SetRespawnAttemptLock(bool state) => this._attemptedRespawn = state;

      public RevengeMarker(
        Vector2 coords,
        int npcNetId,
        float npcHPPercent,
        int npcType,
        int npcAiStyle,
        int coinValue,
        float baseValue,
        bool spawnedFromStatue,
        int gameTime,
        int uniqueID = -1)
      {
        this._location = coords;
        this._npcNetID = npcNetId;
        this._npcHPPercent = npcHPPercent;
        this._npcTypeAgainstDiscouragement = npcType;
        this._npcAIStyleAgainstDiscouragement = npcAiStyle;
        this._coinsValue = coinValue;
        this._baseValue = baseValue;
        this._spawnedFromStatue = spawnedFromStatue;
        this._hitbox = Utils.CenteredRectangle(this._location, CoinLossRevengeSystem.RevengeMarker.EnemyBoxSize);
        this._expirationTime = this.CalculateExpirationTime(gameTime, coinValue);
        if (uniqueID == -1)
          this._uniqueID = CoinLossRevengeSystem.RevengeMarker._uniqueIDCounter++;
        else
          this._uniqueID = uniqueID;
      }

      public bool IsInvalid()
      {
        int npcInvasionGroup = NPC.GetNPCInvasionGroup(this._npcTypeAgainstDiscouragement);
        switch (npcInvasionGroup)
        {
          case -3:
            return !DD2Event.Ongoing;
          case -2:
            return !Main.pumpkinMoon || Main.dayTime;
          case -1:
            return !Main.snowMoon || Main.dayTime;
          case 1:
          case 2:
          case 3:
          case 4:
            return npcInvasionGroup != Main.invasionType;
          default:
            switch (this._npcTypeAgainstDiscouragement)
            {
              case 158:
              case 159:
              case 162:
              case 166:
              case 251:
              case 253:
              case 460:
              case 461:
              case 462:
              case 463:
              case 466:
              case 467:
              case 468:
              case 469:
              case 477:
              case 478:
              case 479:
                if (!Main.eclipse || !Main.dayTime)
                  return true;
                break;
            }
            return false;
        }
      }

      public bool IsExpired(int gameTime) => this._forceExpire || this._expirationTime <= gameTime;

      private int CalculateExpirationTime(int gameCacheTime, int coinValue)
      {
        int num = (coinValue >= CoinLossRevengeSystem.RevengeMarker._expirationCompSilver ? (coinValue >= CoinLossRevengeSystem.RevengeMarker._expirationCompGold ? (coinValue >= CoinLossRevengeSystem.RevengeMarker._expirationCompPlat ? 432000 : (int) MathHelper.Lerp(108000f, 216000f, Utils.GetLerpValue((float) CoinLossRevengeSystem.RevengeMarker._expirationCompSilver, (float) CoinLossRevengeSystem.RevengeMarker._expirationCompGold, (float) coinValue, false))) : (int) MathHelper.Lerp(36000f, 108000f, Utils.GetLerpValue((float) CoinLossRevengeSystem.RevengeMarker._expirationCompSilver, (float) CoinLossRevengeSystem.RevengeMarker._expirationCompGold, (float) coinValue, false))) : (int) MathHelper.Lerp(0.0f, 3600f, Utils.GetLerpValue((float) CoinLossRevengeSystem.RevengeMarker._expirationCompCopper, (float) CoinLossRevengeSystem.RevengeMarker._expirationCompSilver, (float) coinValue, false))) + 18000;
        return gameCacheTime + num;
      }

      public bool Intersects(Rectangle rectInner, Rectangle rectOuter) => rectOuter.Intersects(this._hitbox);

      public void SpawnEnemy()
      {
        int number = NPC.NewNPC((int) this._location.X, (int) this._location.Y, this._npcNetID);
        NPC npc = Main.npc[number];
        if (this._npcNetID < 0)
          npc.SetDefaults(this._npcNetID);
        int num1;
        if (NPCID.Sets.SpecialSpawningRules.TryGetValue(this._npcNetID, out num1) && num1 == 0)
        {
          Point tileCoordinates = npc.position.ToTileCoordinates();
          npc.ai[0] = (float) tileCoordinates.X;
          npc.ai[1] = (float) tileCoordinates.Y;
          npc.netUpdate = true;
        }
        npc.timeLeft += 3600;
        npc.extraValue = this._coinsValue;
        npc.value = this._baseValue;
        npc.SpawnedFromStatue = this._spawnedFromStatue;
        float num2 = Math.Max(0.5f, this._npcHPPercent);
        npc.life = (int) ((double) npc.lifeMax * (double) num2);
        if (number < 200)
        {
          if (Main.netMode == 0)
          {
            npc.moneyPing(this._location);
          }
          else
          {
            NetMessage.SendData(23, number: number);
            NetMessage.SendData(92, number: number, number2: ((float) this._coinsValue), number3: this._location.X, number4: this._location.Y);
          }
        }
        if (!CoinLossRevengeSystem.DisplayCaching)
          return;
        Main.NewText("Spawned " + npc.GivenOrTypeName);
      }

      public bool WouldNPCBeDiscouraged(Player playerTarget)
      {
        switch (this._npcAIStyleAgainstDiscouragement)
        {
          case 2:
            return NPC.DespawnEncouragement_AIStyle2_FloatingEye_IsDiscouraged(this._npcTypeAgainstDiscouragement, playerTarget.position);
          case 3:
            return !NPC.DespawnEncouragement_AIStyle3_Fighters_NotDiscouraged(this._npcTypeAgainstDiscouragement, playerTarget.position, (NPC) null);
          case 6:
            bool flag = false;
            switch (this._npcTypeAgainstDiscouragement)
            {
              case 10:
              case 39:
              case 95:
              case 117:
              case 510:
                flag = true;
                break;
              case 513:
                flag = !playerTarget.ZoneUndergroundDesert;
                break;
            }
            return flag && (double) playerTarget.position.Y < Main.worldSurface * 16.0;
          default:
            switch (this._npcNetID)
            {
              case 253:
                return !Main.eclipse;
              case 490:
                return Main.dayTime;
              default:
                return false;
            }
        }
      }

      public bool DrawMapIcon(
        SpriteBatch spriteBatch,
        Vector2 mapTopLeft,
        Vector2 mapX2Y2AndOff,
        Rectangle? mapRect,
        float mapScale,
        float drawScale,
        int gameTime)
      {
        Vector2 vector2 = (this._location / 16f - mapTopLeft) * mapScale + mapX2Y2AndOff;
        if (mapRect.HasValue && !mapRect.Value.Contains(vector2.ToPoint()))
          return false;
        Texture2D texture2D1 = TextureAssets.MapDeath.Value;
        Texture2D texture2D2 = this._coinsValue >= 100 ? (this._coinsValue >= 10000 ? (this._coinsValue >= 1000000 ? TextureAssets.Coin[3].Value : TextureAssets.Coin[2].Value) : TextureAssets.Coin[1].Value) : TextureAssets.Coin[0].Value;
        Rectangle r = texture2D2.Frame(verticalFrames: 8);
        spriteBatch.Draw(texture2D2, vector2, new Rectangle?(r), Color.White, 0.0f, r.Size() / 2f, drawScale, SpriteEffects.None, 0.0f);
        return Utils.CenteredRectangle(vector2, r.Size() * drawScale).Contains(Main.MouseScreen.ToPoint());
      }

      public void UseMouseOver(
        SpriteBatch spriteBatch,
        ref string mouseTextString,
        float drawScale = 1f)
      {
        mouseTextString = "";
        Vector2 vector2 = Main.MouseScreen / drawScale + new Vector2(-28f) + new Vector2(4f, 0.0f);
        ItemSlot.DrawMoney(spriteBatch, "", vector2.X, vector2.Y, Utils.CoinsSplit((long) this._coinsValue), true);
      }

      public int UniqueID => this._uniqueID;

      public void WriteSelfTo(BinaryWriter writer)
      {
        writer.Write(this._uniqueID);
        writer.WriteVector2(this._location);
        writer.Write(this._npcNetID);
        writer.Write(this._npcHPPercent);
        writer.Write(this._npcTypeAgainstDiscouragement);
        writer.Write(this._npcAIStyleAgainstDiscouragement);
        writer.Write(this._coinsValue);
        writer.Write(this._baseValue);
        writer.Write(this._spawnedFromStatue);
      }
    }
  }
}
