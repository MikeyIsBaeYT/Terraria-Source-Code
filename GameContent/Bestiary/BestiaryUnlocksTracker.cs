// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryUnlocksTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;

namespace Terraria.GameContent.Bestiary
{
  public class BestiaryUnlocksTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    public NPCKillsTracker Kills = new NPCKillsTracker();
    public NPCWasNearPlayerTracker Sights = new NPCWasNearPlayerTracker();
    public NPCWasChatWithTracker Chats = new NPCWasChatWithTracker();

    public void Save(BinaryWriter writer)
    {
      this.Kills.Save(writer);
      this.Sights.Save(writer);
      this.Chats.Save(writer);
    }

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      this.Kills.Load(reader, gameVersionSaveWasMadeOn);
      this.Sights.Load(reader, gameVersionSaveWasMadeOn);
      this.Chats.Load(reader, gameVersionSaveWasMadeOn);
    }

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      this.Kills.ValidateWorld(reader, gameVersionSaveWasMadeOn);
      this.Sights.ValidateWorld(reader, gameVersionSaveWasMadeOn);
      this.Chats.ValidateWorld(reader, gameVersionSaveWasMadeOn);
    }

    public void Reset()
    {
      this.Kills.Reset();
      this.Sights.Reset();
      this.Chats.Reset();
    }

    public void OnPlayerJoining(int playerIndex)
    {
      this.Kills.OnPlayerJoining(playerIndex);
      this.Sights.OnPlayerJoining(playerIndex);
      this.Chats.OnPlayerJoining(playerIndex);
    }

    public void FillBasedOnVersionBefore210()
    {
    }
  }
}
