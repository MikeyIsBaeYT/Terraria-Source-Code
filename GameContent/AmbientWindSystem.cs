// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.AmbientWindSystem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.Utilities;

namespace Terraria.GameContent
{
  public class AmbientWindSystem
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private List<Point> _spotsForAirboneWind = new List<Point>();
    private int _updatesCounter;

    public void Update()
    {
      if (!Main.LocalPlayer.ZoneGraveyard)
        return;
      ++this._updatesCounter;
      Rectangle tileWorkSpace = this.GetTileWorkSpace();
      int num1 = tileWorkSpace.X + tileWorkSpace.Width;
      int num2 = tileWorkSpace.Y + tileWorkSpace.Height;
      for (int x = tileWorkSpace.X; x < num1; ++x)
      {
        for (int y = tileWorkSpace.Y; y < num2; ++y)
          this.TrySpawningWind(x, y);
      }
      if (this._updatesCounter % 30 != 0)
        return;
      this.SpawnAirborneWind();
    }

    private void SpawnAirborneWind()
    {
      foreach (Point point in this._spotsForAirboneWind)
        this.SpawnAirborneCloud(point.X, point.Y);
      this._spotsForAirboneWind.Clear();
    }

    private Rectangle GetTileWorkSpace()
    {
      Point tileCoordinates = Main.LocalPlayer.Center.ToTileCoordinates();
      int width = 120;
      int height = 30;
      return new Rectangle(tileCoordinates.X - width / 2, tileCoordinates.Y - height / 2, width, height);
    }

    private void TrySpawningWind(int x, int y)
    {
      if (!WorldGen.InWorld(x, y, 10) || Main.tile[x, y] == null)
        return;
      this.TestAirCloud(x, y);
      Tile tile = Main.tile[x, y];
      if (!tile.active() || tile.slope() > (byte) 0 || tile.halfBrick() || !Main.tileSolid[(int) tile.type] || WorldGen.SolidTile(Main.tile[x, y - 1]) || this._random.Next(120) != 0)
        return;
      this.SpawnFloorCloud(x, y);
      if (this._random.Next(3) != 0)
        return;
      this.SpawnFloorCloud(x, y - 1);
    }

    private void SpawnAirborneCloud(int x, int y)
    {
      int num1 = this._random.Next(2, 6);
      float num2 = 1.1f;
      float num3 = 2.2f;
      float num4 = 3f * (float) Math.PI / 400f * this._random.NextFloatDirection();
      float num5 = 3f * (float) Math.PI / 400f * this._random.NextFloatDirection();
      while ((double) num5 > -3.0 * Math.PI / 800.0 && (double) num5 < 3.0 * Math.PI / 800.0)
        num5 = 3f * (float) Math.PI / 400f * this._random.NextFloatDirection();
      if (this._random.Next(4) == 0)
      {
        num1 = this._random.Next(9, 16);
        num2 = 1.1f;
        num3 = 1.2f;
      }
      else if (this._random.Next(4) == 0)
      {
        num1 = this._random.Next(9, 16);
        num2 = 1.1f;
        num3 = 0.2f;
      }
      Vector2 vector2_1 = new Vector2(-10f, 0.0f);
      Vector2 worldCoordinates = new Point(x, y).ToWorldCoordinates();
      float num6 = num4 - (float) ((double) num5 * (double) num1 * 0.5);
      for (int index = 0; index < num1; ++index)
      {
        if (Main.rand.Next(10) == 0)
          num5 *= this._random.NextFloatDirection();
        Vector2 vector2_2 = this._random.NextVector2Circular(4f, 4f);
        int Type = 1091 + this._random.Next(2) * 2;
        float num7 = 1.4f;
        float Scale = num2 + this._random.NextFloat() * num3;
        float num8 = num6 + num5;
        Vector2 vector2_3 = Vector2.UnitX.RotatedBy((double) num8) * num7;
        Gore.NewGorePerfect(worldCoordinates + vector2_2 - vector2_1, vector2_3 * Main.WindForVisuals, Type, Scale);
        worldCoordinates += vector2_3 * 6.5f * Scale;
        num6 = num8;
      }
    }

    private void SpawnFloorCloud(int x, int y)
    {
      Vector2 worldCoordinates = new Point(x, y - 1).ToWorldCoordinates();
      int Type = this._random.Next(1087, 1090);
      float num1 = 16f * this._random.NextFloat();
      worldCoordinates.Y -= num1;
      if ((double) num1 < 4.0)
        Type = 1090;
      float num2 = 0.4f;
      float Scale = (float) (0.800000011920929 + (double) this._random.NextFloat() * 0.200000002980232);
      Gore.NewGorePerfect(worldCoordinates, Vector2.UnitX * num2 * Main.WindForVisuals, Type, Scale);
    }

    private void TestAirCloud(int x, int y)
    {
      if (this._random.Next(120000) != 0)
        return;
      for (int index = -2; index <= 2; ++index)
      {
        if (index != 0 && (!this.DoesTileAllowWind(Main.tile[x + index, y]) || !this.DoesTileAllowWind(Main.tile[x, y + index])))
          return;
      }
      this._spotsForAirboneWind.Add(new Point(x, y));
    }

    private bool DoesTileAllowWind(Tile t) => !t.active() || !Main.tileSolid[(int) t.type];
  }
}
