// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.PowerStripUIElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class PowerStripUIElement : UIElement
  {
    private List<UIElement> _buttonsBySorting;
    private string _gamepadPointGroupname;

    public PowerStripUIElement(string gamepadGroupName, List<UIElement> buttons)
    {
      this._buttonsBySorting = new List<UIElement>((IEnumerable<UIElement>) buttons);
      this._gamepadPointGroupname = gamepadGroupName;
      int count = buttons.Count;
      int num1 = 4;
      int num2 = 40;
      int num3 = 40;
      int num4 = num3 + num1;
      UIPanel uiPanel1 = new UIPanel();
      uiPanel1.Width = new StyleDimension((float) (num2 + num1 * 2), 0.0f);
      uiPanel1.Height = new StyleDimension((float) (num3 * count + num1 * (1 + count)), 0.0f);
      UIPanel uiPanel2 = uiPanel1;
      this.SetPadding(0.0f);
      this.Width = uiPanel2.Width;
      this.Height = uiPanel2.Height;
      uiPanel2.BorderColor = new Color(89, 116, 213, (int) byte.MaxValue) * 0.9f;
      uiPanel2.BackgroundColor = new Color(73, 94, 171) * 0.9f;
      uiPanel2.SetPadding(0.0f);
      this.Append((UIElement) uiPanel2);
      for (int index = 0; index < count; ++index)
      {
        UIElement button = buttons[index];
        button.HAlign = 0.5f;
        button.Top = new StyleDimension((float) (num1 + num4 * index), 0.0f);
        button.SetSnapPoint(this._gamepadPointGroupname, index);
        uiPanel2.Append(button);
        this._buttonsBySorting.Add(button);
      }
    }
  }
}
