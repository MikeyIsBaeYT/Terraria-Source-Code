// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.HairstyleUnlocksHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent
{
  public class HairstyleUnlocksHelper
  {
    public List<int> AvailableHairstyles = new List<int>();
    private bool _defeatedMartians;
    private bool _defeatedMoonlord;
    private bool _isAtStylist;
    private bool _isAtCharacterCreation;

    public void UpdateUnlocks()
    {
      if (!this.ListWarrantsRemake())
        return;
      this.RebuildList();
    }

    private bool ListWarrantsRemake()
    {
      bool flag1 = NPC.downedMartians && !Main.gameMenu;
      bool flag2 = NPC.downedMoonlord && !Main.gameMenu;
      bool flag3 = Main.hairWindow && !Main.gameMenu;
      bool gameMenu = Main.gameMenu;
      bool flag4 = false;
      if (this._defeatedMartians != flag1 || this._defeatedMoonlord != flag2 || this._isAtStylist != flag3 || this._isAtCharacterCreation != gameMenu)
        flag4 = true;
      this._defeatedMartians = flag1;
      this._defeatedMoonlord = flag2;
      this._isAtStylist = flag3;
      this._isAtCharacterCreation = gameMenu;
      return flag4;
    }

    private void RebuildList()
    {
      List<int> availableHairstyles = this.AvailableHairstyles;
      availableHairstyles.Clear();
      if (this._isAtCharacterCreation || this._isAtStylist)
      {
        for (int index = 0; index < 51; ++index)
          availableHairstyles.Add(index);
        availableHairstyles.Add(136);
        availableHairstyles.Add(137);
        availableHairstyles.Add(138);
        availableHairstyles.Add(139);
        availableHairstyles.Add(140);
        availableHairstyles.Add(141);
        availableHairstyles.Add(142);
        availableHairstyles.Add(143);
        availableHairstyles.Add(144);
        availableHairstyles.Add(147);
        availableHairstyles.Add(148);
        availableHairstyles.Add(149);
        availableHairstyles.Add(150);
        availableHairstyles.Add(151);
        availableHairstyles.Add(154);
        availableHairstyles.Add(155);
        availableHairstyles.Add(157);
        availableHairstyles.Add(158);
        availableHairstyles.Add(161);
      }
      if (!this._isAtStylist)
        return;
      for (int index = 51; index < 123; ++index)
        availableHairstyles.Add(index);
      availableHairstyles.Add(134);
      availableHairstyles.Add(135);
      availableHairstyles.Add(145);
      availableHairstyles.Add(146);
      availableHairstyles.Add(152);
      availableHairstyles.Add(153);
      availableHairstyles.Add(156);
      availableHairstyles.Add(159);
      availableHairstyles.Add(160);
      if (this._defeatedMartians)
        availableHairstyles.AddRange((IEnumerable<int>) new int[10]
        {
          132,
          131,
          130,
          129,
          128,
          (int) sbyte.MaxValue,
          126,
          125,
          124,
          123
        });
      if (!this._defeatedMartians || !this._defeatedMoonlord)
        return;
      availableHairstyles.Add(133);
    }
  }
}
