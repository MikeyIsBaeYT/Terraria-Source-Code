// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.IceHouseBuilder
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public class IceHouseBuilder : HouseBuilder
  {
    public IceHouseBuilder(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
      : base(HouseType.Ice, rooms)
    {
      this.TileType = (ushort) 321;
      this.WallType = (ushort) 149;
      this.BeamType = (ushort) 574;
      this.DoorStyle = 30;
      this.PlatformStyle = 19;
      this.TableStyle = 28;
      this.WorkbenchStyle = 23;
      this.PianoStyle = 23;
      this.BookcaseStyle = 25;
      this.ChairStyle = 30;
      this.ChestStyle = 11;
    }

    protected override void AgeRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(chance: 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        this.TileType
      }), (GenAction) new Actions.SetTileKeepWall((ushort) 161, true), (GenAction) new Modifiers.Dither(0.8), (GenAction) new Actions.SetTileKeepWall((ushort) 147, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 161
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 161
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(chance: 0.8), (GenAction) new Modifiers.SkipTiles(this.SkipTilesDuringWallAging), (double) room.Y > Main.worldSurface ? (GenAction) new Actions.ClearWall(true) : (GenAction) new Actions.PlaceWall((ushort) 40)));
    }
  }
}
