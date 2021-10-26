// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCWasChatWithTracker
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
  public class NPCWasChatWithTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    private HashSet<string> _chattedWithPlayer;

    public NPCWasChatWithTracker() => this._chattedWithPlayer = new HashSet<string>();

    public void RegisterChatStartWith(NPC npc)
    {
      string bestiaryCreditId = npc.GetBestiaryCreditId();
      bool flag = !this._chattedWithPlayer.Contains(bestiaryCreditId);
      this._chattedWithPlayer.Add(bestiaryCreditId);
      if (!(Main.netMode == 2 & flag))
        return;
      NetManager.Instance.Broadcast(NetBestiaryModule.SerializeChat(npc.netID));
    }

    public void SetWasChatWithDirectly(string persistentId) => this._chattedWithPlayer.Add(persistentId);

    public bool GetWasChatWith(NPC npc) => this._chattedWithPlayer.Contains(npc.GetBestiaryCreditId());

    public bool GetWasChatWith(string persistentId) => this._chattedWithPlayer.Contains(persistentId);

    public void Save(BinaryWriter writer)
    {
      lock (this._chattedWithPlayer)
      {
        writer.Write(this._chattedWithPlayer.Count);
        foreach (string str in this._chattedWithPlayer)
          writer.Write(str);
      }
    }

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
        this._chattedWithPlayer.Add(reader.ReadString());
    }

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
        reader.ReadString();
    }

    public void Reset() => this._chattedWithPlayer.Clear();

    public void OnPlayerJoining(int playerIndex)
    {
      foreach (string key in this._chattedWithPlayer)
      {
        int npcNetId;
        if (ContentSamples.NpcNetIdsByPersistentIds.TryGetValue(key, out npcNetId))
          NetManager.Instance.SendToClient(NetBestiaryModule.SerializeChat(npcNetId), playerIndex);
      }
    }
  }
}
