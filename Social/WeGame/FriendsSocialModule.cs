// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.FriendsSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using rail;

namespace Terraria.Social.WeGame
{
  public class FriendsSocialModule : Terraria.Social.Base.FriendsSocialModule
  {
    public override void Initialize()
    {
    }

    public override void Shutdown()
    {
    }

    public override string GetUsername()
    {
      string str;
      rail_api.RailFactory().RailPlayer().GetPlayerName(ref str);
      WeGameHelper.WriteDebugString("GetUsername by wegame" + str);
      return str;
    }

    public override void OpenJoinInterface()
    {
      WeGameHelper.WriteDebugString("OpenJoinInterface by wegame");
      rail_api.RailFactory().RailFloatingWindow().AsyncShowRailFloatingWindow((EnumRailWindowType) 10, "");
    }
  }
}
