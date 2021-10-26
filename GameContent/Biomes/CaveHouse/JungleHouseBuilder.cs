// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.JungleHouseBuilder
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public class JungleHouseBuilder : HouseBuilder
  {
    public JungleHouseBuilder(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
      : base(HouseType.Jungle, rooms)
    {
      this.TileType = (ushort) 158;
      this.WallType = (ushort) 42;
      this.BeamType = (ushort) 575;
      this.PlatformStyle = 2;
      this.DoorStyle = 2;
      this.TableStyle = 2;
      this.WorkbenchStyle = 2;
      this.PianoStyle = 2;
      this.BookcaseStyle = 12;
      this.ChairStyle = 3;
      this.ChestStyle = 8;
    }

    protected override void AgeRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(chance: 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        this.TileType
      }), (GenAction) new Actions.SetTileKeepWall((ushort) 60, true), (GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Actions.SetTileKeepWall((ushort) 59, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new Modifiers.IsEmpty(), (GenAction) new ActionVines(3, room.Height, 62)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new Modifiers.IsEmpty(), (GenAction) new ActionVines(3, room.Height, 62)));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(), (GenAction) new Actions.PlaceWall((ushort) 64)));
    }
  }
}
