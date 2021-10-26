// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.TeleportPylonsSystem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Tile_Entities;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.GameContent
{
  public class TeleportPylonsSystem : IOnPlayerJoining
  {
    private List<TeleportPylonInfo> _pylons = new List<TeleportPylonInfo>();
    private List<TeleportPylonInfo> _pylonsOld = new List<TeleportPylonInfo>();
    private int _cooldownForUpdatingPylonsList;
    private const int CooldownTimePerPylonsListUpdate = 2147483647;
    private SceneMetrics _sceneMetrics = new SceneMetrics(Main.ActiveWorld);

    public List<TeleportPylonInfo> Pylons => this._pylons;

    public void Update()
    {
      if (Main.netMode == 1)
        return;
      if (this._cooldownForUpdatingPylonsList > 0)
      {
        --this._cooldownForUpdatingPylonsList;
      }
      else
      {
        this._cooldownForUpdatingPylonsList = int.MaxValue;
        this.UpdatePylonsListAndBroadcastChanges();
      }
    }

    public bool HasPylonOfType(TeleportPylonType pylonType) => this._pylons.Any<TeleportPylonInfo>((Func<TeleportPylonInfo, bool>) (x => x.TypeOfPylon == pylonType));

    public bool HasAnyPylon() => this._pylons.Count > 0;

    public void RequestImmediateUpdate()
    {
      if (Main.netMode == 1)
        return;
      this._cooldownForUpdatingPylonsList = int.MaxValue;
      this.UpdatePylonsListAndBroadcastChanges();
    }

    private void UpdatePylonsListAndBroadcastChanges()
    {
      Utils.Swap<List<TeleportPylonInfo>>(ref this._pylons, ref this._pylonsOld);
      this._pylons.Clear();
      foreach (TileEntity tileEntity in TileEntity.ByPosition.Values)
      {
        TeleportPylonType pylonType;
        if (tileEntity is TETeleportationPylon teleportationPylon2 && teleportationPylon2.TryGetPylonType(out pylonType))
          this._pylons.Add(new TeleportPylonInfo()
          {
            PositionInTiles = teleportationPylon2.Position,
            TypeOfPylon = pylonType
          });
      }
      IEnumerable<TeleportPylonInfo> teleportPylonInfos = this._pylonsOld.Except<TeleportPylonInfo>((IEnumerable<TeleportPylonInfo>) this._pylons);
      foreach (TeleportPylonInfo info in this._pylons.Except<TeleportPylonInfo>((IEnumerable<TeleportPylonInfo>) this._pylonsOld))
        NetManager.Instance.BroadcastOrLoopback(NetTeleportPylonModule.SerializePylonWasAddedOrRemoved(info, NetTeleportPylonModule.SubPacketType.PylonWasAdded));
      foreach (TeleportPylonInfo info in teleportPylonInfos)
        NetManager.Instance.BroadcastOrLoopback(NetTeleportPylonModule.SerializePylonWasAddedOrRemoved(info, NetTeleportPylonModule.SubPacketType.PylonWasRemoved));
    }

    public void AddForClient(TeleportPylonInfo info)
    {
      if (this._pylons.Contains(info))
        return;
      this._pylons.Add(info);
    }

    public void RemoveForClient(TeleportPylonInfo info) => this._pylons.RemoveAll((Predicate<TeleportPylonInfo>) (x => x.Equals(info)));

    public void HandleTeleportRequest(TeleportPylonInfo info, int playerIndex)
    {
      Player player = Main.player[playerIndex];
      string key = (string) null;
      bool flag1 = true;
      if (flag1)
      {
        flag1 &= TeleportPylonsSystem.IsPlayerNearAPylon(player);
        if (!flag1)
          key = "Net.CannotTeleportToPylonBecausePlayerIsNotNearAPylon";
      }
      if (flag1)
      {
        int necessaryNPCCount = this.HowManyNPCsDoesPylonNeed(info, player);
        flag1 &= this.DoesPylonHaveEnoughNPCsAroundIt(info, necessaryNPCCount);
        if (!flag1)
          key = "Net.CannotTeleportToPylonBecauseNotEnoughNPCs";
      }
      if (flag1)
      {
        flag1 &= !NPC.AnyDanger();
        if (!flag1)
          key = "Net.CannotTeleportToPylonBecauseThereIsDanger";
      }
      if (flag1)
      {
        if (!NPC.downedPlantBoss && (double) info.PositionInTiles.Y > Main.worldSurface && Framing.GetTileSafely((int) info.PositionInTiles.X, (int) info.PositionInTiles.Y).wall == (ushort) 87)
          flag1 = false;
        if (!flag1)
          key = "Net.CannotTeleportToPylonBecauseAccessingLihzahrdTempleEarly";
      }
      SceneMetricsScanSettings metricsScanSettings;
      if (flag1)
      {
        SceneMetrics sceneMetrics = this._sceneMetrics;
        metricsScanSettings = new SceneMetricsScanSettings();
        metricsScanSettings.VisualScanArea = new Rectangle?();
        metricsScanSettings.BiomeScanCenterPositionInWorld = new Vector2?(info.PositionInTiles.ToWorldCoordinates());
        metricsScanSettings.ScanOreFinderData = false;
        SceneMetricsScanSettings settings = metricsScanSettings;
        sceneMetrics.ScanAndExportToMain(settings);
        flag1 = this.DoesPylonAcceptTeleportation(info, player);
        if (!flag1)
          key = "Net.CannotTeleportToPylonBecauseNotMeetingBiomeRequirements";
      }
      if (flag1)
      {
        bool flag2 = false;
        int num = 0;
        for (int index = 0; index < this._pylons.Count; ++index)
        {
          TeleportPylonInfo pylon = this._pylons[index];
          if (player.InInteractionRange((int) pylon.PositionInTiles.X, (int) pylon.PositionInTiles.Y))
          {
            if (num < 1)
              num = 1;
            int necessaryNPCCount = this.HowManyNPCsDoesPylonNeed(pylon, player);
            if (this.DoesPylonHaveEnoughNPCsAroundIt(pylon, necessaryNPCCount))
            {
              if (num < 2)
                num = 2;
              SceneMetrics sceneMetrics = this._sceneMetrics;
              metricsScanSettings = new SceneMetricsScanSettings();
              metricsScanSettings.VisualScanArea = new Rectangle?();
              metricsScanSettings.BiomeScanCenterPositionInWorld = new Vector2?(pylon.PositionInTiles.ToWorldCoordinates());
              metricsScanSettings.ScanOreFinderData = false;
              SceneMetricsScanSettings settings = metricsScanSettings;
              sceneMetrics.ScanAndExportToMain(settings);
              if (this.DoesPylonAcceptTeleportation(pylon, player))
              {
                flag2 = true;
                break;
              }
            }
          }
        }
        if (!flag2)
        {
          flag1 = false;
          switch (num)
          {
            case 1:
              key = "Net.CannotTeleportToPylonBecauseNotEnoughNPCsAtCurrentPylon";
              break;
            case 2:
              key = "Net.CannotTeleportToPylonBecauseNotMeetingBiomeRequirements";
              break;
            default:
              key = "Net.CannotTeleportToPylonBecausePlayerIsNotNearAPylon";
              break;
          }
        }
      }
      if (flag1)
      {
        Vector2 newPos = info.PositionInTiles.ToWorldCoordinates() - new Vector2(0.0f, (float) player.HeightOffsetBoost);
        int num = 9;
        int typeOfPylon = (int) info.TypeOfPylon;
        int number6 = 0;
        player.Teleport(newPos, num, typeOfPylon);
        player.velocity = Vector2.Zero;
        if (Main.netMode != 2)
          return;
        RemoteClient.CheckSection(player.whoAmI, player.position);
        NetMessage.SendData(65, number2: ((float) player.whoAmI), number3: newPos.X, number4: newPos.Y, number5: num, number6: number6, number7: typeOfPylon);
      }
      else
        ChatHelper.SendChatMessageToClient(NetworkText.FromKey(key), new Color((int) byte.MaxValue, 240, 20), playerIndex);
    }

    public static bool IsPlayerNearAPylon(Player player) => player.IsTileTypeInInteractionRange(597);

    private bool DoesPylonHaveEnoughNPCsAroundIt(TeleportPylonInfo info, int necessaryNPCCount)
    {
      if (necessaryNPCCount <= 0)
        return true;
      Point16 positionInTiles = info.PositionInTiles;
      Rectangle rectangle = new Rectangle((int) positionInTiles.X - Main.buffScanAreaWidth / 2, (int) positionInTiles.Y - Main.buffScanAreaHeight / 2, Main.buffScanAreaWidth, Main.buffScanAreaHeight);
      int num = necessaryNPCCount;
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && npc.isLikeATownNPC && !npc.homeless && rectangle.Contains(npc.homeTileX, npc.homeTileY))
        {
          --num;
          if (num == 0)
            return true;
        }
      }
      return false;
    }

    public void RequestTeleportation(TeleportPylonInfo info, Player player) => NetManager.Instance.SendToServerOrLoopback(NetTeleportPylonModule.SerializeUseRequest(info));

    private bool DoesPylonAcceptTeleportation(TeleportPylonInfo info, Player player)
    {
      switch (info.TypeOfPylon)
      {
        case TeleportPylonType.SurfacePurity:
          return !(((double) info.PositionInTiles.Y <= Main.worldSurface ? 1 : 0) == 0 | ((int) info.PositionInTiles.X >= Main.maxTilesX - 380 || info.PositionInTiles.X <= (short) 380)) && (this._sceneMetrics.EnoughTilesForJungle || this._sceneMetrics.EnoughTilesForSnow || this._sceneMetrics.EnoughTilesForDesert || this._sceneMetrics.EnoughTilesForGlowingMushroom || this._sceneMetrics.EnoughTilesForHallow || this._sceneMetrics.EnoughTilesForCrimson ? 1 : (this._sceneMetrics.EnoughTilesForCorruption ? 1 : 0)) == 0;
        case TeleportPylonType.Jungle:
          return this._sceneMetrics.EnoughTilesForJungle;
        case TeleportPylonType.Hallow:
          return this._sceneMetrics.EnoughTilesForHallow;
        case TeleportPylonType.Underground:
          return (double) info.PositionInTiles.Y >= Main.worldSurface;
        case TeleportPylonType.Beach:
          bool flag = (double) info.PositionInTiles.Y <= Main.worldSurface && (double) info.PositionInTiles.Y > Main.worldSurface * 0.349999994039536;
          return (((int) info.PositionInTiles.X >= Main.maxTilesX - 380 ? 1 : (info.PositionInTiles.X <= (short) 380 ? 1 : 0)) & (flag ? 1 : 0)) != 0;
        case TeleportPylonType.Desert:
          return this._sceneMetrics.EnoughTilesForDesert;
        case TeleportPylonType.Snow:
          return this._sceneMetrics.EnoughTilesForSnow;
        case TeleportPylonType.GlowingMushroom:
          return this._sceneMetrics.EnoughTilesForGlowingMushroom;
        case TeleportPylonType.Victory:
          return true;
        default:
          return true;
      }
    }

    private int HowManyNPCsDoesPylonNeed(TeleportPylonInfo info, Player player) => info.TypeOfPylon != TeleportPylonType.Victory ? 2 : 0;

    public void Reset()
    {
      this._pylons.Clear();
      this._cooldownForUpdatingPylonsList = 0;
    }

    public void OnPlayerJoining(int playerIndex)
    {
      foreach (TeleportPylonInfo pylon in this._pylons)
        NetManager.Instance.SendToClient(NetTeleportPylonModule.SerializePylonWasAddedOrRemoved(pylon, NetTeleportPylonModule.SubPacketType.PylonWasAdded), playerIndex);
    }

    public static void SpawnInWorldDust(int tileStyle, Rectangle dustBox)
    {
      float r = 1f;
      float g = 1f;
      float b = 1f;
      switch ((byte) tileStyle)
      {
        case 0:
          r = 0.05f;
          g = 0.8f;
          b = 0.3f;
          break;
        case 1:
          r = 0.7f;
          g = 0.8f;
          b = 0.05f;
          break;
        case 2:
          r = 0.5f;
          g = 0.3f;
          b = 0.7f;
          break;
        case 3:
          r = 0.4f;
          g = 0.4f;
          b = 0.6f;
          break;
        case 4:
          r = 0.2f;
          g = 0.2f;
          b = 0.95f;
          break;
        case 5:
          r = 0.85f;
          g = 0.45f;
          b = 0.1f;
          break;
        case 6:
          r = 1f;
          g = 1f;
          b = 1.2f;
          break;
        case 7:
          r = 0.4f;
          g = 0.7f;
          b = 1.2f;
          break;
        case 8:
          r = 0.7f;
          g = 0.7f;
          b = 0.7f;
          break;
      }
      int index = Dust.NewDust(dustBox.TopLeft(), dustBox.Width, dustBox.Height, 43, Alpha: 254, newColor: new Color(r, g, b, 1f), Scale: 0.5f);
      Main.dust[index].velocity *= 0.1f;
      Main.dust[index].velocity.Y -= 0.2f;
    }
  }
}
