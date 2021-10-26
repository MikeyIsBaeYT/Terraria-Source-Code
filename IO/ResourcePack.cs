// Decompiled with JetBrains decompiler
// Type: Terraria.IO.ResourcePack
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Ionic.Zip;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using ReLogic.Content;
using ReLogic.Content.Sources;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.GameContent;

namespace Terraria.IO
{
  public class ResourcePack
  {
    public readonly string FullPath;
    public readonly string FileName;
    private readonly IServiceProvider _services;
    private readonly bool _isCompressed;
    private readonly ZipFile _zipFile;
    private Texture2D _icon;
    private IContentSource _contentSource;
    private bool _needsReload = true;
    private const string ICON_FILE_NAME = "icon.png";
    private const string PACK_FILE_NAME = "pack.json";

    public Texture2D Icon
    {
      get
      {
        if (this._icon == null)
          this._icon = this.CreateIcon();
        return this._icon;
      }
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Author { get; private set; }

    public ResourcePackVersion Version { get; private set; }

    public bool IsEnabled { get; set; }

    public int SortingOrder { get; set; }

    public ResourcePack(IServiceProvider services, string path)
    {
      if (File.Exists(path))
        this._isCompressed = true;
      else if (!Directory.Exists(path))
        throw new FileNotFoundException("Unable to find file or folder for resource pack at: " + path);
      this.FileName = Path.GetFileName(path);
      this._services = services;
      this.FullPath = path;
      if (this._isCompressed)
        this._zipFile = ZipFile.Read(path);
      this.LoadManifest();
    }

    public void Refresh() => this._needsReload = true;

    public IContentSource GetContentSource()
    {
      if (this._needsReload)
      {
        this._contentSource = !this._isCompressed ? (IContentSource) new FileSystemContentSource(Path.Combine(this.FullPath, "Content")) : (IContentSource) new ZipContentSource(this.FullPath, "Content");
        this._contentSource.ContentValidator = (IContentValidator) VanillaContentValidator.Instance;
        this._needsReload = false;
      }
      return this._contentSource;
    }

    private Texture2D CreateIcon()
    {
      if (!this.HasFile("icon.png"))
        return XnaExtensions.Get<IAssetRepository>(this._services).Request<Texture2D>("Images/UI/DefaultResourcePackIcon", (AssetRequestMode) 1).Value;
      using (Stream stream = this.OpenStream("icon.png"))
        return XnaExtensions.Get<AssetReaderCollection>(this._services).Read<Texture2D>(stream, ".png");
    }

    private void LoadManifest()
    {
      if (!this.HasFile("pack.json"))
        throw new FileNotFoundException(string.Format("Resource Pack at \"{0}\" must contain a {1} file.", (object) this.FullPath, (object) "pack.json"));
      JObject jobject;
      using (Stream stream = this.OpenStream("pack.json"))
      {
        using (StreamReader streamReader = new StreamReader(stream))
          jobject = JObject.Parse(streamReader.ReadToEnd());
      }
      this.Name = Extensions.Value<string>((IEnumerable<JToken>) jobject["Name"]);
      this.Description = Extensions.Value<string>((IEnumerable<JToken>) jobject["Description"]);
      this.Author = Extensions.Value<string>((IEnumerable<JToken>) jobject["Author"]);
      this.Version = jobject["Version"].ToObject<ResourcePackVersion>();
    }

    private Stream OpenStream(string fileName)
    {
      if (!this._isCompressed)
        return (Stream) File.OpenRead(Path.Combine(this.FullPath, fileName));
      ZipEntry zipEntry = this._zipFile[fileName];
      MemoryStream memoryStream = new MemoryStream((int) zipEntry.UncompressedSize);
      zipEntry.Extract((Stream) memoryStream);
      memoryStream.Position = 0L;
      return (Stream) memoryStream;
    }

    private bool HasFile(string fileName) => !this._isCompressed ? File.Exists(Path.Combine(this.FullPath, fileName)) : this._zipFile.ContainsEntry(fileName);
  }
}
