// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ContentRejectionFromSize
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using ReLogic.Content;
using Terraria.Localization;

namespace Terraria.GameContent
{
  public class ContentRejectionFromSize : IRejectionReason
  {
    private int _neededWidth;
    private int _neededHeight;
    private int _actualWidth;
    private int _actualHeight;

    public ContentRejectionFromSize(
      int neededWidth,
      int neededHeight,
      int actualWidth,
      int actualHeight)
    {
      this._neededWidth = neededWidth;
      this._neededHeight = neededHeight;
      this._actualWidth = actualWidth;
      this._actualHeight = actualHeight;
    }

    public string GetReason() => Language.GetTextValueWith("AssetRejections.BadSize", (object) new
    {
      NeededWidth = this._neededWidth,
      NeededHeight = this._neededHeight,
      ActualWidth = this._actualWidth,
      ActualHeight = this._actualHeight
    });
  }
}
