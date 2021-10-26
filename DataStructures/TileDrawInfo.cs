// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileDrawInfo
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public class TileDrawInfo
  {
    public Tile tileCache;
    public ushort typeCache;
    public short tileFrameX;
    public short tileFrameY;
    public Texture2D drawTexture;
    public Color tileLight;
    public int tileTop;
    public int tileWidth;
    public int tileHeight;
    public int halfBrickHeight;
    public int addFrY;
    public int addFrX;
    public SpriteEffects tileSpriteEffect;
    public Texture2D glowTexture;
    public Rectangle glowSourceRect;
    public Color glowColor;
    public Vector3[] colorSlices = new Vector3[9];
    public Color finalColor;
    public Color colorTint;
  }
}
