// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.WindGrid
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.GameContent.Drawing
{
  public class WindGrid
  {
    private WindGrid.WindCoord[,] _grid = new WindGrid.WindCoord[1, 1];
    private int _width = 1;
    private int _height = 1;
    private int _gameTime;

    public void SetSize(int targetWidth, int targetHeight)
    {
      this._width = Math.Max(this._width, targetWidth);
      this._height = Math.Max(this._height, targetHeight);
      this.ResizeGrid();
    }

    public void Update()
    {
      ++this._gameTime;
      if (!Main.SettingsEnabled_TilesSwayInWind)
        return;
      this.ScanPlayers();
    }

    public void GetWindTime(
      int tileX,
      int tileY,
      int timeThreshold,
      out int windTimeLeft,
      out int direction)
    {
      WindGrid.WindCoord windCoord = this._grid[tileX % this._width, tileY % this._height];
      direction = windCoord.Direction;
      if (windCoord.Time + timeThreshold < this._gameTime)
        windTimeLeft = 0;
      else
        windTimeLeft = this._gameTime - windCoord.Time;
    }

    private void ResizeGrid()
    {
      if (this._width <= this._grid.GetLength(0) && this._height <= this._grid.GetLength(1))
        return;
      this._grid = new WindGrid.WindCoord[this._width, this._height];
    }

    private void SetWindTime(int tileX, int tileY, int direction)
    {
      this._grid[tileX % this._width, tileY % this._height].Time = this._gameTime;
      this._grid[tileX % this._width, tileY % this._height].Direction = direction;
    }

    private void ScanPlayers()
    {
      switch (Main.netMode)
      {
        case 0:
          this.ScanPlayer(Main.myPlayer);
          break;
        case 1:
          for (int i = 0; i < (int) byte.MaxValue; ++i)
            this.ScanPlayer(i);
          break;
      }
    }

    private void ScanPlayer(int i)
    {
      Player player = Main.player[i];
      if (!player.active || player.dead || (double) player.velocity.X == 0.0 || !Utils.CenteredRectangle(Main.Camera.Center, Main.Camera.UnscaledSize).Intersects(player.Hitbox) || player.velocity.HasNaNs())
        return;
      int direction = Math.Sign(player.velocity.X);
      foreach (Point point in Collision.GetTilesIn(player.TopLeft, player.BottomRight))
        this.SetWindTime(point.X, point.Y, direction);
    }

    private struct WindCoord
    {
      public int Time;
      public int Direction;
    }
  }
}
