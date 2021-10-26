// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Personalities.PersonalityDatabase
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.Personalities
{
  public class PersonalityDatabase
  {
    private Dictionary<int, PersonalityProfile> _personalityProfiles;

    public PersonalityDatabase() => this._personalityProfiles = new Dictionary<int, PersonalityProfile>();

    private void Register(IShopPersonalityTrait trait, int npcId)
    {
      if (!this._personalityProfiles.ContainsKey(npcId))
        this._personalityProfiles[npcId] = new PersonalityProfile();
      this._personalityProfiles[npcId].ShopModifiers.Add(trait);
    }

    private void Register(IShopPersonalityTrait trait, params int[] npcIds)
    {
      for (int index = 0; index < npcIds.Length; ++index)
        this.Register(trait, npcIds[index]);
    }
  }
}
