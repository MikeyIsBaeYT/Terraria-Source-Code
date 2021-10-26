// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.DebugKeyboard
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using ReLogic.Peripherals.RGB;

namespace Terraria.GameContent.RGB
{
  internal class DebugKeyboard : RgbDevice
  {
    private DebugKeyboard(Fragment fragment)
      : base((RgbDeviceVendor) 4, (RgbDeviceType) 6, fragment, new DeviceColorProfile())
    {
    }

    public static DebugKeyboard Create()
    {
      int num1 = 400;
      int num2 = 100;
      Point[] pointArray = new Point[num1 * num2];
      for (int index1 = 0; index1 < num2; ++index1)
      {
        for (int index2 = 0; index2 < num1; ++index2)
          pointArray[index1 * num1 + index2] = new Point(index2 / 10, index1 / 10);
      }
      Vector2[] vector2Array = new Vector2[num1 * num2];
      for (int index3 = 0; index3 < num2; ++index3)
      {
        for (int index4 = 0; index4 < num1; ++index4)
          vector2Array[index3 * num1 + index4] = new Vector2((float) index4 / (float) num2, (float) index3 / (float) num2);
      }
      return new DebugKeyboard(Fragment.FromCustom(pointArray, vector2Array));
    }

    public virtual void Present()
    {
    }

    public virtual void DebugDraw(IDebugDrawer drawer, Vector2 position, float scale)
    {
      for (int index = 0; index < this.LedCount; ++index)
      {
        Vector2 ledCanvasPosition = this.GetLedCanvasPosition(index);
        drawer.DrawSquare(new Vector4(ledCanvasPosition * scale + position, scale / 100f, scale / 100f), new Color(this.GetUnprocessedLedColor(index)));
      }
    }
  }
}
