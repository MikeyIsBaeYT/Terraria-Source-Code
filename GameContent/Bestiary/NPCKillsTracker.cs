// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCKillsTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using System.IO;
using Terraria.GameContent.NetModules;
using Terraria.ID;
using Terraria.Net;

namespace Terraria.GameContent.Bestiary
{
  public class NPCKillsTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    public const int POSITIVE_KILL_COUNT_CAP = 9999;
    private Dictionary<string, int> _killCountsByNpcId;

    public NPCKillsTracker() => this._killCountsByNpcId = new Dictionary<string, int>();

    public void RegisterKill(NPC npc)
    {
      string bestiaryCreditId = npc.GetBestiaryCreditId();
      int num;
      this._killCountsByNpcId.TryGetValue(bestiaryCreditId, out num);
      int killcount = num + 1;
      this._killCountsByNpcId[bestiaryCreditId] = Utils.Clamp<int>(killcount, 0, 9999);
      if (Main.netMode != 2)
        return;
      NetManager.Instance.Broadcast(NetBestiaryModule.SerializeKillCount(npc.netID, killcount));
    }

    public int GetKillCount(NPC npc) => this.GetKillCount(npc.GetBestiaryCreditId());

    public void SetKillCountDirectly(string persistentId, int killCount) => this._killCountsByNpcId[persistentId] = Utils.Clamp<int>(killCount, 0, 9999);

    public int GetKillCount(string persistentId)
    {
      int num;
      this._killCountsByNpcId.TryGetValue(persistentId, out num);
      return num;
    }

    public void Save(BinaryWriter writer)
    {
      lock (this._killCountsByNpcId)
      {
        writer.Write(this._killCountsByNpcId.Count);
        foreach (KeyValuePair<string, int> keyValuePair in this._killCountsByNpcId)
        {
          writer.Write(keyValuePair.Key);
          writer.Write(keyValuePair.Value);
        }
      }
    }

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
        this._killCountsByNpcId[reader.ReadString()] = reader.ReadInt32();
    }

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
      {
        reader.ReadString();
        reader.ReadInt32();
      }
    }

    public void Reset() => this._killCountsByNpcId.Clear();

    public void OnPlayerJoining(int playerIndex)
    {
      foreach (KeyValuePair<string, int> keyValuePair in this._killCountsByNpcId)
      {
        int idsByPersistentId = ContentSamples.NpcNetIdsByPersistentIds[keyValuePair.Key];
        NetManager.Instance.SendToClient(NetBestiaryModule.SerializeKillCount(idsByPersistentId, keyValuePair.Value), playerIndex);
      }
    }
  }
}
