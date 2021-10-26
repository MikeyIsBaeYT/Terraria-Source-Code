// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.DesertHouseBuilder
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public class DesertHouseBuilder : HouseBuilder
  {
    public DesertHouseBuilder(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
      : base(HouseType.Desert, rooms)
    {
      this.TileType = (ushort) 396;
      this.WallType = (ushort) 187;
      this.BeamType = (ushort) 577;
      this.PlatformStyle = 42;
      this.DoorStyle = 43;
      this.TableStyle = 7;
      this.UsesTables2 = true;
      this.WorkbenchStyle = 39;
      this.PianoStyle = 38;
      this.BookcaseStyle = 39;
      this.ChairStyle = 43;
      this.ChestStyle = 1;
    }

    protected override void AgeRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.Blotches(chance: 0.200000002980232), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        this.TileType
      }), (GenAction) new Actions.SetTileKeepWall((ushort) 396, true), (GenAction) new Modifiers.Dither(), (GenAction) new Actions.SetTileKeepWall((ushort) 397, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[2]
      {
        (ushort) 397,
        (ushort) 396
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[2]
      {
        (ushort) 397,
        (ushort) 396
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.Blotches(), (GenAction) new Modifiers.OnlyWalls(new ushort[1]
      {
        this.WallType
      }), (GenAction) new Actions.PlaceWall((ushort) 216)));
    }
  }
}
