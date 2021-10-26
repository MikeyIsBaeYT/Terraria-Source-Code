// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.HoneyPatchBiome
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class HoneyPatchBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      if (GenBase._tiles[origin.X, origin.Y].active() && WorldGen.SolidTile(origin.X, origin.Y))
        return false;
      Point result;
      if (!WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Down(80), (GenCondition) new Conditions.IsSolid()), out result))
        return false;
      result.Y += 2;
      Ref<int> count = new Ref<int>(0);
      WorldUtils.Gen(result, (GenShape) new Shapes.Circle(8), Actions.Chain((GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Scanner(count)));
      if (count.Value < 20 || !structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(result.X - 8, result.Y - 8, 16, 16)))
        return false;
      WorldUtils.Gen(result, (GenShape) new Shapes.Circle(8), Actions.Chain((GenAction) new Modifiers.RadialDither(0.0f, 10f), (GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.SetTile((ushort) 229, true)));
      ShapeData data = new ShapeData();
      WorldUtils.Gen(result, (GenShape) new Shapes.Circle(4, 3), Actions.Chain((GenAction) new Modifiers.Blotches(), (GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.ClearTile(true), new Modifiers.RectangleMask(-6, 6, 0, 3).Output(data), (GenAction) new Actions.SetLiquid(2)));
      WorldUtils.Gen(new Point(result.X, result.Y + 1), (GenShape) new ModShapes.InnerOutline(data), Actions.Chain((GenAction) new Modifiers.IsEmpty(), (GenAction) new Modifiers.RectangleMask(-6, 6, 1, 3), (GenAction) new Actions.SetTile((ushort) 59, true)));
      structures.AddProtectedStructure(new Microsoft.Xna.Framework.Rectangle(result.X - 8, result.Y - 8, 16, 16));
      return true;
    }
  }
}
