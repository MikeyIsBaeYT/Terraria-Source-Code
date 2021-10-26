// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.IPersistentPerWorldContent
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;

namespace Terraria.GameContent
{
  public interface IPersistentPerWorldContent
  {
    void Save(BinaryWriter writer);

    void Load(BinaryReader reader, int gameVersionSaveWasMadeOn);

    void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn);

    void Reset();
  }
}
