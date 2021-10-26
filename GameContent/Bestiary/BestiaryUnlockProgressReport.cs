// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryUnlockProgressReport
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.Bestiary
{
  public struct BestiaryUnlockProgressReport
  {
    public int EntriesTotal;
    public float CompletionAmountTotal;

    public float CompletionPercent => this.EntriesTotal == 0 ? 1f : this.CompletionAmountTotal / (float) this.EntriesTotal;
  }
}
