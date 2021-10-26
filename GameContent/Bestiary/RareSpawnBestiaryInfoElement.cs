// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.RareSpawnBestiaryInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class RareSpawnBestiaryInfoElement : IBestiaryInfoElement, IProvideSearchFilterString
  {
    public int RarityLevel { get; private set; }

    public RareSpawnBestiaryInfoElement(int rarityLevel) => this.RarityLevel = rarityLevel;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;

    public string GetSearchString(ref BestiaryUICollectionInfo info) => info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0 ? (string) null : Language.GetText("BestiaryInfo.IsRare").Value;
  }
}
