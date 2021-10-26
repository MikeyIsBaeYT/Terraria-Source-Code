// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.SpawnConditionBestiaryOverlayInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Terraria.GameContent.Bestiary
{
  public class SpawnConditionBestiaryOverlayInfoElement : 
    FilterProviderInfoElement,
    IBestiaryBackgroundOverlayAndColorProvider
  {
    private string _overlayImagePath;
    private Color? _overlayColor;

    public float DisplayPriority { get; set; }

    public SpawnConditionBestiaryOverlayInfoElement(
      string nameLanguageKey,
      int filterIconFrame,
      string overlayImagePath = null,
      Color? overlayColor = null)
      : base(nameLanguageKey, filterIconFrame)
    {
      this._overlayImagePath = overlayImagePath;
      this._overlayColor = overlayColor;
    }

    public Asset<Texture2D> GetBackgroundOverlayImage() => this._overlayImagePath == null ? (Asset<Texture2D>) null : Main.Assets.Request<Texture2D>(this._overlayImagePath, (AssetRequestMode) 1);

    public Color? GetBackgroundOverlayColor() => this._overlayColor;
  }
}
