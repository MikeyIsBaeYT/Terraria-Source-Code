// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.AssetSourceController
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.Content;
using ReLogic.Content.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.IO;

namespace Terraria.GameContent
{
  public class AssetSourceController
  {
    private readonly List<IContentSource> _staticSources;
    private readonly IAssetRepository _assetRepository;

    public event Action<ResourcePackList> OnResourcePackChange;

    public ResourcePackList ActiveResourcePackList { get; private set; }

    public AssetSourceController(
      IAssetRepository assetRepository,
      IEnumerable<IContentSource> staticSources)
    {
      this._assetRepository = assetRepository;
      this._staticSources = staticSources.ToList<IContentSource>();
      this.UseResourcePacks(new ResourcePackList());
    }

    public void Refresh()
    {
      foreach (ResourcePack allPack in this.ActiveResourcePackList.AllPacks)
        allPack.Refresh();
      this.UseResourcePacks(this.ActiveResourcePackList);
    }

    public void UseResourcePacks(ResourcePackList resourcePacks)
    {
      if (this.OnResourcePackChange != null)
        this.OnResourcePackChange(resourcePacks);
      this.ActiveResourcePackList = resourcePacks;
      List<IContentSource> icontentSourceList = new List<IContentSource>(resourcePacks.EnabledPacks.OrderBy<ResourcePack, int>((Func<ResourcePack, int>) (pack => pack.SortingOrder)).Select<ResourcePack, IContentSource>((Func<ResourcePack, IContentSource>) (pack => pack.GetContentSource())));
      icontentSourceList.AddRange((IEnumerable<IContentSource>) this._staticSources);
      foreach (IContentSource icontentSource in icontentSourceList)
        icontentSource.ClearRejections();
      this._assetRepository.SetSources((IEnumerable<IContentSource>) icontentSourceList, (AssetRequestMode) 1);
    }
  }
}
