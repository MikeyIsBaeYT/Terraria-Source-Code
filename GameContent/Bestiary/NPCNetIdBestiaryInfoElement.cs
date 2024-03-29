﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCNetIdBestiaryInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class NPCNetIdBestiaryInfoElement : IBestiaryInfoElement, IBestiaryEntryDisplayIndex
  {
    public int NetId { get; private set; }

    public NPCNetIdBestiaryInfoElement(int npcNetId) => this.NetId = npcNetId;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;

    public int BestiaryDisplayIndex => ContentSamples.NpcBestiarySortingId[this.NetId];
  }
}
