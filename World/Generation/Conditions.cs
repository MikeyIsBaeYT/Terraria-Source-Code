// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.Conditions
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.World.Generation
{
  public static class Conditions
  {
    public class IsTile : GenCondition
    {
      private ushort[] _types;

      public IsTile(params ushort[] types) => this._types = types;

      protected override bool CheckValidity(int x, int y)
      {
        if (GenBase._tiles[x, y].active())
        {
          for (int index = 0; index < this._types.Length; ++index)
          {
            if ((int) GenBase._tiles[x, y].type == (int) this._types[index])
              return true;
          }
        }
        return false;
      }
    }

    public class Continue : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => false;
    }

    public class IsSolid : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => GenBase._tiles[x, y].active() && Main.tileSolid[(int) GenBase._tiles[x, y].type];
    }

    public class HasLava : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => GenBase._tiles[x, y].liquid > (byte) 0 && GenBase._tiles[x, y].liquidType() == (byte) 1;
    }
  }
}
