// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCWasNearPlayerTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria.GameContent.NetModules;
using Terraria.ID;
using Terraria.Net;

namespace Terraria.GameContent.Bestiary
{
  public class NPCWasNearPlayerTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    private HashSet<string> _wasNearPlayer;
    private List<Rectangle> _playerHitboxesForBestiary;
    private List<int> _wasSeenNearPlayerByNetId;

    public void PrepareSamplesBasedOptimizations()
    {
    }

    public NPCWasNearPlayerTracker()
    {
      this._wasNearPlayer = new HashSet<string>();
      this._playerHitboxesForBestiary = new List<Rectangle>();
      this._wasSeenNearPlayerByNetId = new List<int>();
    }

    public void RegisterWasNearby(NPC npc)
    {
      string bestiaryCreditId = npc.GetBestiaryCreditId();
      bool flag = !this._wasNearPlayer.Contains(bestiaryCreditId);
      this._wasNearPlayer.Add(bestiaryCreditId);
      if (!(Main.netMode == 2 & flag))
        return;
      NetManager.Instance.Broadcast(NetBestiaryModule.SerializeSight(npc.netID));
    }

    public void SetWasSeenDirectly(string persistentId) => this._wasNearPlayer.Add(persistentId);

    public bool GetWasNearbyBefore(NPC npc) => this.GetWasNearbyBefore(npc.GetBestiaryCreditId());

    public bool GetWasNearbyBefore(string persistentIdentifier) => this._wasNearPlayer.Contains(persistentIdentifier);

    public void Save(BinaryWriter writer)
    {
      lock (this._wasNearPlayer)
      {
        writer.Write(this._wasNearPlayer.Count);
        foreach (string str in this._wasNearPlayer)
          writer.Write(str);
      }
    }

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
        this._wasNearPlayer.Add(reader.ReadString());
    }

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
        reader.ReadString();
    }

    public void Reset()
    {
      this._wasNearPlayer.Clear();
      this._playerHitboxesForBestiary.Clear();
      this._wasSeenNearPlayerByNetId.Clear();
    }

    public void ScanWorldForFinds()
    {
      this._playerHitboxesForBestiary.Clear();
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        Player player = Main.player[index];
        if (player.active)
        {
          Rectangle hitbox = player.Hitbox;
          hitbox.Inflate(300, 200);
          this._playerHitboxesForBestiary.Add(hitbox);
        }
      }
      for (int index1 = 0; index1 < 200; ++index1)
      {
        NPC npc = Main.npc[index1];
        if (npc.active && npc.CountsAsACritter && !this._wasSeenNearPlayerByNetId.Contains(npc.netID))
        {
          Rectangle hitbox = npc.Hitbox;
          for (int index2 = 0; index2 < this._playerHitboxesForBestiary.Count; ++index2)
          {
            Rectangle rectangle = this._playerHitboxesForBestiary[index2];
            if (hitbox.Intersects(rectangle))
            {
              this._wasSeenNearPlayerByNetId.Add(npc.netID);
              this.RegisterWasNearby(npc);
            }
          }
        }
      }
    }

    public void OnPlayerJoining(int playerIndex)
    {
      foreach (string key in this._wasNearPlayer)
      {
        int idsByPersistentId = ContentSamples.NpcNetIdsByPersistentIds[key];
        NetManager.Instance.SendToClient(NetBestiaryModule.SerializeSight(idsByPersistentId), playerIndex);
      }
    }
  }
}
