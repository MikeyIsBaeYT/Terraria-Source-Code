// Decompiled with JetBrains decompiler
// Type: Terraria.IO.WorldFileData
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;
using System.IO;
using Terraria.Localization;
using Terraria.Utilities;

namespace Terraria.IO
{
  public class WorldFileData : FileData
  {
    private const ulong GUID_IN_WORLD_FILE_VERSION = 777389080577;
    public DateTime CreationTime;
    public int WorldSizeX;
    public int WorldSizeY;
    public ulong WorldGeneratorVersion;
    private string _seedText = "";
    private int _seed;
    public bool IsValid = true;
    public Guid UniqueId;
    public LocalizedText _worldSizeName;
    public bool IsExpertMode;
    public bool HasCorruption = true;
    public bool IsHardMode;

    public string SeedText => this._seedText;

    public int Seed => this._seed;

    public string WorldSizeName => this._worldSizeName.Value;

    public bool HasCrimson
    {
      get => !this.HasCorruption;
      set => this.HasCorruption = !value;
    }

    public bool HasValidSeed => this.WorldGeneratorVersion > 0UL;

    public bool UseGuidAsMapName => this.WorldGeneratorVersion >= 777389080577UL;

    public WorldFileData()
      : base("World")
    {
    }

    public WorldFileData(string path, bool cloudSave)
      : base("World", path, cloudSave)
    {
    }

    public override void SetAsActive() => Main.ActiveWorldFileData = this;

    public void SetWorldSize(int x, int y)
    {
      this.WorldSizeX = x;
      this.WorldSizeY = y;
      switch (x)
      {
        case 4200:
          this._worldSizeName = Language.GetText("UI.WorldSizeSmall");
          break;
        case 6400:
          this._worldSizeName = Language.GetText("UI.WorldSizeMedium");
          break;
        case 8400:
          this._worldSizeName = Language.GetText("UI.WorldSizeLarge");
          break;
        default:
          this._worldSizeName = Language.GetText("UI.WorldSizeUnknown");
          break;
      }
    }

    public static WorldFileData FromInvalidWorld(string path, bool cloudSave)
    {
      WorldFileData worldFileData = new WorldFileData(path, cloudSave);
      worldFileData.IsExpertMode = false;
      worldFileData.SetSeedToEmpty();
      worldFileData.WorldGeneratorVersion = 0UL;
      worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
      worldFileData.SetWorldSize(1, 1);
      worldFileData.HasCorruption = true;
      worldFileData.IsHardMode = false;
      worldFileData.IsValid = false;
      worldFileData.Name = FileUtilities.GetFileName(path, false);
      worldFileData.UniqueId = Guid.Empty;
      worldFileData.CreationTime = cloudSave ? DateTime.Now : File.GetCreationTime(path);
      return worldFileData;
    }

    public void SetSeedToEmpty() => this.SetSeed("");

    public void SetSeed(string seedText)
    {
      this._seedText = seedText;
      if (!int.TryParse(seedText, out this._seed))
        this._seed = seedText.GetHashCode();
      this._seed = Math.Abs(this._seed);
    }

    public void SetSeedToRandom() => this.SetSeed(new UnifiedRandom().Next().ToString());

    public override void MoveToCloud()
    {
      if (this.IsCloudSave)
        return;
      string worldPathFromName = Main.GetWorldPathFromName(this.Name, true);
      if (!FileUtilities.MoveToCloud(this.Path, worldPathFromName))
        return;
      Main.LocalFavoriteData.ClearEntry((FileData) this);
      this._isCloudSave = true;
      this._path = worldPathFromName;
      Main.CloudFavoritesData.SaveFavorite((FileData) this);
    }

    public override void MoveToLocal()
    {
      if (!this.IsCloudSave)
        return;
      string worldPathFromName = Main.GetWorldPathFromName(this.Name, false);
      if (!FileUtilities.MoveToLocal(this.Path, worldPathFromName))
        return;
      Main.CloudFavoritesData.ClearEntry((FileData) this);
      this._isCloudSave = false;
      this._path = worldPathFromName;
      Main.LocalFavoriteData.SaveFavorite((FileData) this);
    }
  }
}
