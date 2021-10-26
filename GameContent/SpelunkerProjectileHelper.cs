// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.SpelunkerProjectileHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.GameContent
{
  public class SpelunkerProjectileHelper
  {
    private HashSet<Vector2> _positionsChecked = new HashSet<Vector2>();
    private HashSet<Point> _tilesChecked = new HashSet<Point>();
    private Rectangle _clampBox;
    private int _frameCounter;

    public void OnPreUpdateAllProjectiles()
    {
      this._clampBox = new Rectangle(2, 2, Main.maxTilesX - 2, Main.maxTilesY - 2);
      if (++this._frameCounter < 10)
        return;
      this._frameCounter = 0;
      this._tilesChecked.Clear();
      this._positionsChecked.Clear();
    }

    public void AddSpotToCheck(Vector2 spot)
    {
      if (!this._positionsChecked.Add(spot))
        return;
      this.CheckSpot(spot);
    }

    private void CheckSpot(Vector2 Center)
    {
      int num1 = (int) Center.X / 16;
      int num2 = (int) Center.Y / 16;
      int num3 = Utils.Clamp<int>(num1 - 30, this._clampBox.Left, this._clampBox.Right);
      int num4 = Utils.Clamp<int>(num1 + 30, this._clampBox.Left, this._clampBox.Right);
      int num5 = Utils.Clamp<int>(num2 - 30, this._clampBox.Top, this._clampBox.Bottom);
      int num6 = Utils.Clamp<int>(num2 + 30, this._clampBox.Top, this._clampBox.Bottom);
      Point point = new Point();
      Vector2 Position = new Vector2();
      for (int index1 = num3; index1 <= num4; ++index1)
      {
        for (int index2 = num5; index2 <= num6; ++index2)
        {
          Tile t = Main.tile[index1, index2];
          if (t != null && t.active() && Main.IsTileSpelunkable(t) && (double) new Vector2((float) (num1 - index1), (float) (num2 - index2)).Length() <= 30.0)
          {
            point.X = index1;
            point.Y = index2;
            if (this._tilesChecked.Add(point) && Main.rand.Next(4) == 0)
            {
              Position.X = (float) (index1 * 16);
              Position.Y = (float) (index2 * 16);
              Dust dust = Dust.NewDustDirect(Position, 16, 16, 204, Alpha: 150, Scale: 0.3f);
              dust.fadeIn = 0.75f;
              dust.velocity *= 0.1f;
              dust.noLight = true;
            }
          }
        }
      }
    }
  }
}
