// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Alignment
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI
{
  public struct Alignment
  {
    public static readonly Alignment TopLeft = new Alignment(0.0f, 0.0f);
    public static readonly Alignment Top = new Alignment(0.5f, 0.0f);
    public static readonly Alignment TopRight = new Alignment(1f, 0.0f);
    public static readonly Alignment Left = new Alignment(0.0f, 0.5f);
    public static readonly Alignment Center = new Alignment(0.5f, 0.5f);
    public static readonly Alignment Right = new Alignment(1f, 0.5f);
    public static readonly Alignment BottomLeft = new Alignment(0.0f, 1f);
    public static readonly Alignment Bottom = new Alignment(0.5f, 1f);
    public static readonly Alignment BottomRight = new Alignment(1f, 1f);
    public readonly float VerticalOffsetMultiplier;
    public readonly float HorizontalOffsetMultiplier;

    public Vector2 OffsetMultiplier => new Vector2(this.HorizontalOffsetMultiplier, this.VerticalOffsetMultiplier);

    private Alignment(float horizontal, float vertical)
    {
      this.HorizontalOffsetMultiplier = horizontal;
      this.VerticalOffsetMultiplier = vertical;
    }
  }
}
