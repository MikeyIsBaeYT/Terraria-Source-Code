// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.SimpleStructure
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.WorldBuilding
{
  public class SimpleStructure : GenStructure
  {
    private int[,] _data;
    private int _width;
    private int _height;
    private GenAction[] _actions;
    private bool _xMirror;
    private bool _yMirror;

    public int Width => this._width;

    public int Height => this._height;

    public SimpleStructure(params string[] data) => this.ReadData(data);

    public SimpleStructure(string data) => this.ReadData(data.Split('\n'));

    private void ReadData(string[] lines)
    {
      this._height = lines.Length;
      this._width = lines[0].Length;
      this._data = new int[this._width, this._height];
      for (int index1 = 0; index1 < this._height; ++index1)
      {
        for (int index2 = 0; index2 < this._width; ++index2)
        {
          int num = (int) lines[index1][index2];
          switch (num)
          {
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
              this._data[index2, index1] = num - 48;
              break;
            default:
              this._data[index2, index1] = -1;
              break;
          }
        }
      }
    }

    public SimpleStructure SetActions(params GenAction[] actions)
    {
      this._actions = actions;
      return this;
    }

    public SimpleStructure Mirror(bool horizontalMirror, bool verticalMirror)
    {
      this._xMirror = horizontalMirror;
      this._yMirror = verticalMirror;
      return this;
    }

    public override bool Place(Point origin, StructureMap structures)
    {
      if (!structures.CanPlace(new Microsoft.Xna.Framework.Rectangle(origin.X, origin.Y, this._width, this._height)))
        return false;
      for (int index1 = 0; index1 < this._width; ++index1)
      {
        for (int index2 = 0; index2 < this._height; ++index2)
        {
          int num1 = this._xMirror ? -index1 : index1;
          int num2 = this._yMirror ? -index2 : index2;
          if (this._data[index1, index2] != -1 && !this._actions[this._data[index1, index2]].Apply(origin, num1 + origin.X, num2 + origin.Y))
            return false;
        }
      }
      structures.AddProtectedStructure(new Microsoft.Xna.Framework.Rectangle(origin.X, origin.Y, this._width, this._height));
      return true;
    }
  }
}
