// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativeUnlocksTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;

namespace Terraria.GameContent.Creative
{
  public class CreativeUnlocksTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    public ItemsSacrificedUnlocksTracker ItemSacrifices = new ItemsSacrificedUnlocksTracker();

    public void Save(BinaryWriter writer) => this.ItemSacrifices.Save(writer);

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.ItemSacrifices.Load(reader, gameVersionSaveWasMadeOn);

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.ValidateWorld(reader, gameVersionSaveWasMadeOn);

    public void Reset() => this.ItemSacrifices.Reset();

    public void OnPlayerJoining(int playerIndex) => this.ItemSacrifices.OnPlayerJoining(playerIndex);
  }
}
