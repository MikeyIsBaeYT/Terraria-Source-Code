// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.HighestOfMultipleUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class HighestOfMultipleUICollectionInfoProvider : IBestiaryUICollectionInfoProvider
  {
    private IBestiaryUICollectionInfoProvider[] _providers;
    private int _mainProviderIndex;

    public HighestOfMultipleUICollectionInfoProvider(
      params IBestiaryUICollectionInfoProvider[] providers)
    {
      this._providers = providers;
      this._mainProviderIndex = 0;
    }

    public BestiaryUICollectionInfo GetEntryUICollectionInfo()
    {
      BestiaryUICollectionInfo uiCollectionInfo1 = this._providers[this._mainProviderIndex].GetEntryUICollectionInfo();
      BestiaryEntryUnlockState unlockState = uiCollectionInfo1.UnlockState;
      for (int index = 0; index < this._providers.Length; ++index)
      {
        BestiaryUICollectionInfo uiCollectionInfo2 = this._providers[index].GetEntryUICollectionInfo();
        if (unlockState < uiCollectionInfo2.UnlockState)
          unlockState = uiCollectionInfo2.UnlockState;
      }
      uiCollectionInfo1.UnlockState = unlockState;
      return uiCollectionInfo1;
    }

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
