// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UISliderBase
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UISliderBase : UIElement
  {
    internal const int UsageLevel_NotSelected = 0;
    internal const int UsageLevel_SelectedAndLocked = 1;
    internal const int UsageLevel_OtherElementIsLocked = 2;
    internal static UIElement CurrentLockedSlider;
    internal static UIElement CurrentAimedSlider;

    internal int GetUsageLevel()
    {
      int num = 0;
      if (UISliderBase.CurrentLockedSlider == this)
        num = 1;
      else if (UISliderBase.CurrentLockedSlider != null)
        num = 2;
      return num;
    }
  }
}
