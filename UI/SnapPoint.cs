// Decompiled with JetBrains decompiler
// Type: Terraria.UI.SnapPoint
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI
{
  public class SnapPoint
  {
    private Vector2 _anchor;
    private Vector2 _offset;
    private Vector2 _calculatedPosition;
    private string _name;
    private int _id;
    public UIElement BoundElement;

    public string Name => this._name;

    public int ID => this._id;

    public Vector2 Position => this._calculatedPosition;

    public SnapPoint(string name, int id, Vector2 anchor, Vector2 offset)
    {
      this._name = name;
      this._id = id;
      this._anchor = anchor;
      this._offset = offset;
    }

    public void Calculate(UIElement element)
    {
      this.BoundElement = element;
      CalculatedStyle dimensions = element.GetDimensions();
      this._calculatedPosition = dimensions.Position() + this._offset + this._anchor * new Vector2(dimensions.Width, dimensions.Height);
    }

    public override string ToString() => "Snap Point - " + this.Name + " " + (object) this.ID;
  }
}
