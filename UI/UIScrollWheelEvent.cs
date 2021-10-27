// Decompiled with JetBrains decompiler
// Type: Terraria.UI.UIScrollWheelEvent
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI
{
  public class UIScrollWheelEvent : UIMouseEvent
  {
    public readonly int ScrollWheelValue;

    public UIScrollWheelEvent(UIElement target, Vector2 mousePosition, int scrollWheelValue)
      : base(target, mousePosition)
    {
      this.ScrollWheelValue = scrollWheelValue;
    }
  }
}
