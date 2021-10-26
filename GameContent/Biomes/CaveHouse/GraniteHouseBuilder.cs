// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.GraniteHouseBuilder
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public class GraniteHouseBuilder : HouseBuilder
  {
    public GraniteHouseBuilder(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
      : base(HouseType.Granite, rooms)
    {
      this.TileType = (ushort) 369;
      this.WallType = (ushort) 181;
      this.BeamType = (ushort) 576;
      this.PlatformStyle = 28;
      this.DoorStyle = 34;
      this.TableStyle = 33;
      this.WorkbenchStyle = 29;
      this.PianoStyle = 28;
      this.BookcaseStyle = 30;
      this.ChairStyle = 34;
      this.ChestStyle = 50;
    }

    protected override void AgeRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(chance: 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        this.TileType
      }), (GenAction) new Actions.SetTileKeepWall((ushort) 368, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 368
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 368
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(), (GenAction) new Actions.PlaceWall((ushort) 180)));
    }
  }
}
