// Decompiled with JetBrains decompiler
// Type: Terraria.GetItemSettings
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria
{
  public struct GetItemSettings
  {
    public static GetItemSettings InventoryEntityToPlayerInventorySettings = new GetItemSettings(NoText: true);
    public static GetItemSettings NPCEntityToPlayerInventorySettings = new GetItemSettings(true);
    public static GetItemSettings LootAllSettings = new GetItemSettings();
    public static GetItemSettings PickupItemFromWorld = new GetItemSettings(CanGoIntoVoidVault: true);
    public static GetItemSettings GetItemInDropItemCheck = new GetItemSettings(NoText: true);
    public static GetItemSettings InventoryUIToInventorySettings = new GetItemSettings();
    public static GetItemSettings InventoryUIToInventorySettingsShowAsNew = new GetItemSettings(NoText: true, StepAfterHandlingSlotNormally: new Action<Item>(GetItemSettings.MakeNewAndShiny));
    public static GetItemSettings ItemCreatedFromItemUsage = new GetItemSettings();
    public readonly bool LongText;
    public readonly bool NoText;
    public readonly bool CanGoIntoVoidVault;
    public readonly Action<Item> StepAfterHandlingSlotNormally;

    public GetItemSettings(
      bool LongText = false,
      bool NoText = false,
      bool CanGoIntoVoidVault = false,
      Action<Item> StepAfterHandlingSlotNormally = null)
    {
      this.LongText = LongText;
      this.NoText = NoText;
      this.CanGoIntoVoidVault = CanGoIntoVoidVault;
      this.StepAfterHandlingSlotNormally = StepAfterHandlingSlotNormally;
    }

    public void HandlePostAction(Item item)
    {
      if (this.StepAfterHandlingSlotNormally == null)
        return;
      this.StepAfterHandlingSlotNormally(item);
    }

    private static void MakeNewAndShiny(Item item) => item.newAndShiny = true;
  }
}
