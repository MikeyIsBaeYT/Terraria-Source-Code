// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Light.TileLightScanner
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Threading;
using System;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria.Graphics.Light
{
  public class TileLightScanner
  {
    private readonly World _world;
    private FastRandom _random = FastRandom.CreateWithRandomSeed();

    public TileLightScanner(World world) => this._world = world;

    public void ExportTo(Rectangle area, LightMap outputMap)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      TileLightScanner.\u003C\u003Ec__DisplayClass3_0 cDisplayClass30 = new TileLightScanner.\u003C\u003Ec__DisplayClass3_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass30.area = area;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass30.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass30.outputMap = outputMap;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      FastParallel.For(cDisplayClass30.area.Left, cDisplayClass30.area.Right, new ParallelForAction((object) cDisplayClass30, __methodptr(\u003CExportTo\u003Eb__0)), (object) null);
    }

    private bool IsTileNullOrTouchingNull(int x, int y) => !WorldGen.InWorld(x, y, 1) || this._world.Tiles[x, y] == null || this._world.Tiles[x + 1, y] == null || this._world.Tiles[x - 1, y] == null || this._world.Tiles[x, y - 1] == null || this._world.Tiles[x, y + 1] == null;

    public void Update() => this._random.NextSeed();

    public LightMaskMode GetMaskMode(int x, int y) => TileLightScanner.GetTileMask(this._world.Tiles[x, y]);

    private static LightMaskMode GetTileMask(Tile tile)
    {
      if ((!tile.active() || !Main.tileBlockLight[(int) tile.type] || tile.type == (ushort) 131 || tile.inActive() ? 0 : (tile.slope() == (byte) 0 ? 1 : 0)) != 0)
        return LightMaskMode.Solid;
      if (tile.lava() || tile.liquid <= (byte) 128)
        return LightMaskMode.None;
      return !tile.honey() ? LightMaskMode.Water : LightMaskMode.Honey;
    }

    public void GetTileLight(int x, int y, out Vector3 outputColor)
    {
      outputColor = Vector3.Zero;
      Tile tile = this._world.Tiles[x, y];
      FastRandom localRandom = this._random.WithModifier(x, y);
      if (y < (int) Main.worldSurface)
        this.ApplySurfaceLight(tile, x, y, ref outputColor);
      else if (y > Main.UnderworldLayer)
        this.ApplyHellLight(tile, x, y, ref outputColor);
      TileLightScanner.ApplyWallLight(tile, x, y, ref localRandom, ref outputColor);
      if (tile.active())
        this.ApplyTileLight(tile, x, y, ref localRandom, ref outputColor);
      TileLightScanner.ApplyLavaLight(tile, ref outputColor);
    }

    private static void ApplyLavaLight(Tile tile, ref Vector3 lightColor)
    {
      if (!tile.lava() || tile.liquid <= (byte) 0)
        return;
      float num = 0.55f + (float) (270 - (int) Main.mouseTextColor) / 900f;
      if ((double) lightColor.X < (double) num)
        lightColor.X = num;
      if ((double) lightColor.Y < (double) num)
        lightColor.Y = num * 0.6f;
      if ((double) lightColor.Z >= (double) num)
        return;
      lightColor.Z = num * 0.2f;
    }

    private static void ApplyWallLight(
      Tile tile,
      int x,
      int y,
      ref FastRandom localRandom,
      ref Vector3 lightColor)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      switch (tile.wall)
      {
        case 33:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            num1 = 0.09f;
            num2 = 0.0525f;
            num3 = 0.24f;
            break;
          }
          break;
        case 44:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            num1 = (float) ((double) Main.DiscoR / (double) byte.MaxValue * 0.150000005960464);
            num2 = (float) ((double) Main.DiscoG / (double) byte.MaxValue * 0.150000005960464);
            num3 = (float) ((double) Main.DiscoB / (double) byte.MaxValue * 0.150000005960464);
            break;
          }
          break;
        case 137:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            float num4 = 0.4f + (float) (270 - (int) Main.mouseTextColor) / 1500f + (float) localRandom.Next(0, 50) * 0.0005f;
            num1 = 1f * num4;
            num2 = 0.5f * num4;
            num3 = 0.1f * num4;
            break;
          }
          break;
        case 153:
          num1 = 0.6f;
          num2 = 0.3f;
          break;
        case 154:
          num1 = 0.6f;
          num3 = 0.6f;
          break;
        case 155:
          num1 = 0.6f;
          num2 = 0.6f;
          num3 = 0.6f;
          break;
        case 156:
          num2 = 0.6f;
          break;
        case 164:
          num1 = 0.6f;
          break;
        case 165:
          num3 = 0.6f;
          break;
        case 166:
          num1 = 0.6f;
          num2 = 0.6f;
          break;
        case 174:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            num1 = 0.2975f;
            break;
          }
          break;
        case 175:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            num1 = 0.075f;
            num2 = 0.15f;
            num3 = 0.4f;
            break;
          }
          break;
        case 176:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            num1 = 0.1f;
            num2 = 0.1f;
            num3 = 0.1f;
            break;
          }
          break;
        case 182:
          if (!tile.active() || !Main.tileBlockLight[(int) tile.type])
          {
            num1 = 0.24f;
            num2 = 0.12f;
            num3 = 0.09f;
            break;
          }
          break;
      }
      if ((double) lightColor.X < (double) num1)
        lightColor.X = num1;
      if ((double) lightColor.Y < (double) num2)
        lightColor.Y = num2;
      if ((double) lightColor.Z >= (double) num3)
        return;
      lightColor.Z = num3;
    }

    private void ApplyTileLight(
      Tile tile,
      int x,
      int y,
      ref FastRandom localRandom,
      ref Vector3 lightColor)
    {
      float R = 0.0f;
      float G = 0.0f;
      float B = 0.0f;
      if (Main.tileLighted[(int) tile.type])
      {
        switch (tile.type)
        {
          case 4:
            if (tile.frameX < (short) 66)
            {
              TorchID.TorchColor((int) tile.frameY / 22, out R, out G, out B);
              break;
            }
            break;
          case 17:
          case 133:
          case 302:
            R = 0.83f;
            G = 0.6f;
            B = 0.5f;
            break;
          case 22:
          case 140:
            R = 0.12f;
            G = 0.07f;
            B = 0.32f;
            break;
          case 26:
          case 31:
            if (tile.type == (ushort) 31 && tile.frameX >= (short) 36 || tile.type == (ushort) 26 && tile.frameX >= (short) 54)
            {
              float num = (float) localRandom.Next(-5, 6) * (1f / 400f);
              R = (float) (0.5 + (double) num * 2.0);
              G = 0.2f + num;
              B = 0.1f;
              break;
            }
            float num1 = (float) localRandom.Next(-5, 6) * (1f / 400f);
            R = 0.31f + num1;
            G = 0.1f;
            B = (float) (0.439999997615814 + (double) num1 * 2.0);
            break;
          case 27:
            if (tile.frameY < (short) 36)
            {
              R = 0.3f;
              G = 0.27f;
              break;
            }
            break;
          case 33:
            if (tile.frameX == (short) 0)
            {
              switch ((int) tile.frameY / 22)
              {
                case 0:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 1:
                  R = 0.55f;
                  G = 0.85f;
                  B = 0.35f;
                  break;
                case 2:
                  R = 0.65f;
                  G = 0.95f;
                  B = 0.5f;
                  break;
                case 3:
                  R = 0.2f;
                  G = 0.75f;
                  B = 1f;
                  break;
                case 5:
                  R = 0.85f;
                  G = 0.6f;
                  B = 1f;
                  break;
                case 7:
                case 8:
                  R = 0.75f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 9:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 10:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 14:
                  R = 1f;
                  G = 1f;
                  B = 0.6f;
                  break;
                case 15:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 18:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 19:
                  R = 0.37f;
                  G = 0.8f;
                  B = 1f;
                  break;
                case 20:
                  R = 0.0f;
                  G = 0.9f;
                  B = 1f;
                  break;
                case 21:
                  R = 0.25f;
                  G = 0.7f;
                  B = 1f;
                  break;
                case 23:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 24:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 25:
                  R = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  G = 0.3f;
                  B = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 28:
                  R = 0.9f;
                  G = 0.75f;
                  B = 1f;
                  break;
                case 29:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 30:
                  Vector3 vector3_1 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                  R = vector3_1.X;
                  G = vector3_1.Y;
                  B = vector3_1.Z;
                  break;
                case 31:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 32:
                  R = 0.55f;
                  G = 0.45f;
                  B = 0.95f;
                  break;
                case 33:
                  R = 1f;
                  G = 0.6f;
                  B = 0.1f;
                  break;
                case 34:
                  R = 0.3f;
                  G = 0.75f;
                  B = 0.55f;
                  break;
                case 35:
                  R = 0.9f;
                  G = 0.55f;
                  B = 0.7f;
                  break;
                case 36:
                  R = 0.55f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 37:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 38:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                default:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
              }
            }
            else
              break;
            break;
          case 34:
            if ((int) tile.frameX % 108 < 54)
            {
              switch ((int) tile.frameY / 54 + 37 * ((int) tile.frameX / 108))
              {
                case 7:
                  R = 0.95f;
                  G = 0.95f;
                  B = 0.5f;
                  break;
                case 8:
                  R = 0.85f;
                  G = 0.6f;
                  B = 1f;
                  break;
                case 9:
                  R = 1f;
                  G = 0.6f;
                  B = 0.6f;
                  break;
                case 11:
                case 12:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 13:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 15:
                  R = 1f;
                  G = 1f;
                  B = 0.7f;
                  break;
                case 16:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 17:
                  R = 0.75f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 18:
                  R = 1f;
                  G = 1f;
                  B = 0.6f;
                  break;
                case 19:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 23:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 24:
                  R = 0.37f;
                  G = 0.8f;
                  B = 1f;
                  break;
                case 25:
                  R = 0.0f;
                  G = 0.9f;
                  B = 1f;
                  break;
                case 26:
                  R = 0.25f;
                  G = 0.7f;
                  B = 1f;
                  break;
                case 27:
                  R = 0.55f;
                  G = 0.85f;
                  B = 0.35f;
                  break;
                case 28:
                  R = 0.65f;
                  G = 0.95f;
                  B = 0.5f;
                  break;
                case 29:
                  R = 0.2f;
                  G = 0.75f;
                  B = 1f;
                  break;
                case 30:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 32:
                  R = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  G = 0.3f;
                  B = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 35:
                  R = 0.9f;
                  G = 0.75f;
                  B = 1f;
                  break;
                case 36:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 37:
                  Vector3 vector3_2 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                  R = vector3_2.X;
                  G = vector3_2.Y;
                  B = vector3_2.Z;
                  break;
                case 38:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 39:
                  R = 0.55f;
                  G = 0.45f;
                  B = 0.95f;
                  break;
                case 40:
                  R = 1f;
                  G = 0.6f;
                  B = 0.1f;
                  break;
                case 41:
                  R = 0.3f;
                  G = 0.75f;
                  B = 0.55f;
                  break;
                case 42:
                  R = 0.9f;
                  G = 0.55f;
                  B = 0.7f;
                  break;
                case 43:
                  R = 0.55f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 44:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 45:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                default:
                  R = 1f;
                  G = 0.95f;
                  B = 0.8f;
                  break;
              }
            }
            else
              break;
            break;
          case 35:
            if (tile.frameX < (short) 36)
            {
              R = 0.75f;
              G = 0.6f;
              B = 0.3f;
              break;
            }
            break;
          case 37:
            R = 0.56f;
            G = 0.43f;
            B = 0.15f;
            break;
          case 42:
            if (tile.frameX == (short) 0)
            {
              switch ((int) tile.frameY / 36)
              {
                case 0:
                  R = 0.7f;
                  G = 0.65f;
                  B = 0.55f;
                  break;
                case 1:
                  R = 0.9f;
                  G = 0.75f;
                  B = 0.6f;
                  break;
                case 2:
                  R = 0.8f;
                  G = 0.6f;
                  B = 0.6f;
                  break;
                case 3:
                  R = 0.65f;
                  G = 0.5f;
                  B = 0.2f;
                  break;
                case 4:
                  R = 0.5f;
                  G = 0.7f;
                  B = 0.4f;
                  break;
                case 5:
                  R = 0.9f;
                  G = 0.4f;
                  B = 0.2f;
                  break;
                case 6:
                  R = 0.7f;
                  G = 0.75f;
                  B = 0.3f;
                  break;
                case 7:
                  float num2 = Main.demonTorch * 0.2f;
                  R = 0.9f - num2;
                  G = 0.9f - num2;
                  B = 0.7f + num2;
                  break;
                case 8:
                  R = 0.75f;
                  G = 0.6f;
                  B = 0.3f;
                  break;
                case 9:
                  float num3 = 1f;
                  float num4 = 0.3f;
                  B = 0.5f + Main.demonTorch * 0.2f;
                  R = num3 - Main.demonTorch * 0.1f;
                  G = num4 - Main.demonTorch * 0.2f;
                  break;
                case 11:
                  R = 0.85f;
                  G = 0.6f;
                  B = 1f;
                  break;
                case 14:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 15:
                case 16:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 17:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 18:
                  R = 0.75f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 21:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 22:
                  R = 1f;
                  G = 1f;
                  B = 0.6f;
                  break;
                case 23:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 27:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 28:
                  R = 0.37f;
                  G = 0.8f;
                  B = 1f;
                  break;
                case 29:
                  R = 0.0f;
                  G = 0.9f;
                  B = 1f;
                  break;
                case 30:
                  R = 0.25f;
                  G = 0.7f;
                  B = 1f;
                  break;
                case 32:
                  R = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  G = 0.3f;
                  B = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 35:
                  R = 0.7f;
                  G = 0.6f;
                  B = 0.9f;
                  break;
                case 36:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 37:
                  Vector3 vector3_3 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                  R = vector3_3.X;
                  G = vector3_3.Y;
                  B = vector3_3.Z;
                  break;
                case 38:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 39:
                  R = 0.55f;
                  G = 0.45f;
                  B = 0.95f;
                  break;
                case 40:
                  R = 1f;
                  G = 0.6f;
                  B = 0.1f;
                  break;
                case 41:
                  R = 0.3f;
                  G = 0.75f;
                  B = 0.55f;
                  break;
                case 42:
                  R = 0.9f;
                  G = 0.55f;
                  B = 0.7f;
                  break;
                case 43:
                  R = 0.55f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 44:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 45:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                default:
                  R = 1f;
                  G = 1f;
                  B = 1f;
                  break;
              }
            }
            else
              break;
            break;
          case 49:
            if (tile.frameX == (short) 0)
            {
              R = 0.0f;
              G = 0.35f;
              B = 0.8f;
              break;
            }
            break;
          case 61:
            if (tile.frameX == (short) 144)
            {
              float num5 = (float) (1.0 + (double) (270 - (int) Main.mouseTextColor) / 400.0);
              float num6 = (float) (0.800000011920929 - (double) (270 - (int) Main.mouseTextColor) / 400.0);
              R = 0.42f * num6;
              G = 0.81f * num5;
              B = 0.52f * num6;
              break;
            }
            break;
          case 70:
          case 71:
          case 72:
          case 190:
          case 348:
          case 349:
          case 528:
          case 578:
            if (tile.type != (ushort) 349 || tile.frameX >= (short) 36)
            {
              float num7 = (float) localRandom.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 1000f;
              R = 0.0f;
              G = (float) (0.200000002980232 + (double) num7 / 2.0);
              B = 1f;
              break;
            }
            break;
          case 77:
            R = 0.75f;
            G = 0.45f;
            B = 0.25f;
            break;
          case 83:
            if (tile.frameX == (short) 18 && !Main.dayTime)
            {
              R = 0.1f;
              G = 0.4f;
              B = 0.6f;
            }
            if (tile.frameX == (short) 90 && !Main.raining && Main.time > 40500.0)
            {
              R = 0.9f;
              G = 0.72f;
              B = 0.18f;
              break;
            }
            break;
          case 84:
            switch ((int) tile.frameX / 18)
            {
              case 2:
                float num8 = (float) (270 - (int) Main.mouseTextColor) / 800f;
                if ((double) num8 > 1.0)
                  num8 = 1f;
                else if ((double) num8 < 0.0)
                  num8 = 0.0f;
                R = num8 * 0.7f;
                G = num8;
                B = num8 * 0.1f;
                break;
              case 5:
                float num9 = 0.9f;
                R = num9;
                G = num9 * 0.8f;
                B = num9 * 0.2f;
                break;
              case 6:
                float num10 = 0.08f;
                G = num10 * 0.8f;
                B = num10;
                break;
            }
            break;
          case 92:
            if (tile.frameY <= (short) 18 && tile.frameX == (short) 0)
            {
              R = 1f;
              G = 1f;
              B = 1f;
              break;
            }
            break;
          case 93:
            if (tile.frameX == (short) 0)
            {
              switch ((int) tile.frameY / 54)
              {
                case 1:
                  R = 0.95f;
                  G = 0.95f;
                  B = 0.5f;
                  break;
                case 2:
                  R = 0.85f;
                  G = 0.6f;
                  B = 1f;
                  break;
                case 3:
                  R = 0.75f;
                  G = 1f;
                  B = 0.6f;
                  break;
                case 4:
                case 5:
                  R = 0.75f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 6:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 7:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 9:
                  R = 1f;
                  G = 1f;
                  B = 0.7f;
                  break;
                case 10:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 12:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 13:
                  R = 1f;
                  G = 1f;
                  B = 0.6f;
                  break;
                case 14:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 18:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 19:
                  R = 0.37f;
                  G = 0.8f;
                  B = 1f;
                  break;
                case 20:
                  R = 0.0f;
                  G = 0.9f;
                  B = 1f;
                  break;
                case 21:
                  R = 0.25f;
                  G = 0.7f;
                  B = 1f;
                  break;
                case 23:
                  R = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  G = 0.3f;
                  B = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 24:
                  R = 0.35f;
                  G = 0.5f;
                  B = 0.3f;
                  break;
                case 25:
                  R = 0.34f;
                  G = 0.4f;
                  B = 0.31f;
                  break;
                case 26:
                  R = 0.25f;
                  G = 0.32f;
                  B = 0.5f;
                  break;
                case 29:
                  R = 0.9f;
                  G = 0.75f;
                  B = 1f;
                  break;
                case 30:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 31:
                  Vector3 vector3_4 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                  R = vector3_4.X;
                  G = vector3_4.Y;
                  B = vector3_4.Z;
                  break;
                case 32:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 33:
                  R = 0.55f;
                  G = 0.45f;
                  B = 0.95f;
                  break;
                case 34:
                  R = 1f;
                  G = 0.6f;
                  B = 0.1f;
                  break;
                case 35:
                  R = 0.3f;
                  G = 0.75f;
                  B = 0.55f;
                  break;
                case 36:
                  R = 0.9f;
                  G = 0.55f;
                  B = 0.7f;
                  break;
                case 37:
                  R = 0.55f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 38:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 39:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                default:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
              }
            }
            else
              break;
            break;
          case 95:
            if (tile.frameX < (short) 36)
            {
              R = 1f;
              G = 0.95f;
              B = 0.8f;
              break;
            }
            break;
          case 96:
            if (tile.frameX >= (short) 36)
            {
              R = 0.5f;
              G = 0.35f;
              B = 0.1f;
              break;
            }
            break;
          case 98:
            if (tile.frameY == (short) 0)
            {
              R = 1f;
              G = 0.97f;
              B = 0.85f;
              break;
            }
            break;
          case 100:
          case 173:
            if (tile.frameX < (short) 36)
            {
              switch ((int) tile.frameY / 36)
              {
                case 1:
                  R = 0.95f;
                  G = 0.95f;
                  B = 0.5f;
                  break;
                case 2:
                  R = 0.85f;
                  G = 0.6f;
                  B = 1f;
                  break;
                case 3:
                  R = 1f;
                  G = 0.6f;
                  B = 0.6f;
                  break;
                case 5:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 6:
                case 7:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 8:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 9:
                  R = 0.75f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 11:
                  R = 1f;
                  G = 1f;
                  B = 0.7f;
                  break;
                case 12:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 13:
                  R = 1f;
                  G = 1f;
                  B = 0.6f;
                  break;
                case 14:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 18:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 19:
                  R = 0.37f;
                  G = 0.8f;
                  B = 1f;
                  break;
                case 20:
                  R = 0.0f;
                  G = 0.9f;
                  B = 1f;
                  break;
                case 21:
                  R = 0.25f;
                  G = 0.7f;
                  B = 1f;
                  break;
                case 22:
                  R = 0.35f;
                  G = 0.5f;
                  B = 0.3f;
                  break;
                case 23:
                  R = 0.34f;
                  G = 0.4f;
                  B = 0.31f;
                  break;
                case 24:
                  R = 0.25f;
                  G = 0.32f;
                  B = 0.5f;
                  break;
                case 25:
                  R = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  G = 0.3f;
                  B = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 29:
                  R = 0.9f;
                  G = 0.75f;
                  B = 1f;
                  break;
                case 30:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 31:
                  Vector3 vector3_5 = Main.hslToRgb((float) ((double) Main.demonTorch * 0.119999997317791 + 0.689999997615814), 1f, 0.75f).ToVector3() * 1.2f;
                  R = vector3_5.X;
                  G = vector3_5.Y;
                  B = vector3_5.Z;
                  break;
                case 32:
                  R = 1f;
                  G = 0.97f;
                  B = 0.85f;
                  break;
                case 33:
                  R = 0.55f;
                  G = 0.45f;
                  B = 0.95f;
                  break;
                case 34:
                  R = 1f;
                  G = 0.6f;
                  B = 0.1f;
                  break;
                case 35:
                  R = 0.3f;
                  G = 0.75f;
                  B = 0.55f;
                  break;
                case 36:
                  R = 0.9f;
                  G = 0.55f;
                  B = 0.7f;
                  break;
                case 37:
                  R = 0.55f;
                  G = 0.85f;
                  B = 1f;
                  break;
                case 38:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                case 39:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
                default:
                  R = 1f;
                  G = 0.95f;
                  B = 0.65f;
                  break;
              }
            }
            else
              break;
            break;
          case 125:
            float num11 = (float) localRandom.Next(28, 42) * 0.01f + (float) (270 - (int) Main.mouseTextColor) / 800f;
            G = lightColor.Y = 0.3f * num11;
            B = lightColor.Z = 0.6f * num11;
            break;
          case 126:
            if (tile.frameX < (short) 36)
            {
              R = (float) Main.DiscoR / (float) byte.MaxValue;
              G = (float) Main.DiscoG / (float) byte.MaxValue;
              B = (float) Main.DiscoB / (float) byte.MaxValue;
              break;
            }
            break;
          case 129:
            switch ((int) tile.frameX / 18 % 3)
            {
              case 0:
                R = 0.0f;
                G = 0.05f;
                B = 0.25f;
                break;
              case 1:
                R = 0.2f;
                G = 0.0f;
                B = 0.15f;
                break;
              case 2:
                R = 0.1f;
                G = 0.0f;
                B = 0.2f;
                break;
            }
            break;
          case 149:
            if (tile.frameX <= (short) 36)
            {
              switch ((int) tile.frameX / 18)
              {
                case 0:
                  R = 0.1f;
                  G = 0.2f;
                  B = 0.5f;
                  break;
                case 1:
                  R = 0.5f;
                  G = 0.1f;
                  B = 0.1f;
                  break;
                case 2:
                  R = 0.2f;
                  G = 0.5f;
                  B = 0.1f;
                  break;
              }
              R *= (float) localRandom.Next(970, 1031) * (1f / 1000f);
              G *= (float) localRandom.Next(970, 1031) * (1f / 1000f);
              B *= (float) localRandom.Next(970, 1031) * (1f / 1000f);
              break;
            }
            break;
          case 160:
            R = (float) ((double) Main.DiscoR / (double) byte.MaxValue * 0.25);
            G = (float) ((double) Main.DiscoG / (double) byte.MaxValue * 0.25);
            B = (float) ((double) Main.DiscoB / (double) byte.MaxValue * 0.25);
            break;
          case 171:
            if (tile.frameX < (short) 10)
            {
              x -= (int) tile.frameX;
              y -= (int) tile.frameY;
            }
            switch (((int) this._world.Tiles[x, y].frameY & 15360) >> 10)
            {
              case 1:
                R = 0.1f;
                G = 0.1f;
                B = 0.1f;
                break;
              case 2:
                R = 0.2f;
                break;
              case 3:
                G = 0.2f;
                break;
              case 4:
                B = 0.2f;
                break;
              case 5:
                R = 0.125f;
                G = 0.125f;
                break;
              case 6:
                R = 0.2f;
                G = 0.1f;
                break;
              case 7:
                R = 0.125f;
                G = 0.125f;
                break;
              case 8:
                R = 0.08f;
                G = 0.175f;
                break;
              case 9:
                G = 0.125f;
                B = 0.125f;
                break;
              case 10:
                R = 0.125f;
                B = 0.125f;
                break;
              case 11:
                R = 0.1f;
                G = 0.1f;
                B = 0.2f;
                break;
              default:
                double num12;
                B = (float) (num12 = 0.0);
                G = (float) num12;
                R = (float) num12;
                break;
            }
            R *= 0.5f;
            G *= 0.5f;
            B *= 0.5f;
            break;
          case 174:
            if (tile.frameX == (short) 0)
            {
              R = 1f;
              G = 0.95f;
              B = 0.65f;
              break;
            }
            break;
          case 184:
            if (tile.frameX == (short) 110)
            {
              R = 0.25f;
              G = 0.1f;
              B = 0.0f;
            }
            if (tile.frameX == (short) 132)
            {
              R = 0.0f;
              G = 0.25f;
              B = 0.0f;
            }
            if (tile.frameX == (short) 154)
            {
              R = 0.0f;
              G = 0.16f;
              B = 0.34f;
            }
            if (tile.frameX == (short) 176)
            {
              R = 0.3f;
              G = 0.0f;
              B = 0.17f;
              break;
            }
            break;
          case 204:
          case 347:
            R = 0.35f;
            break;
          case 209:
            if (tile.frameX == (short) 234 || tile.frameX == (short) 252)
            {
              Vector3 vector3_6 = PortalHelper.GetPortalColor(Main.myPlayer, 0).ToVector3() * 0.65f;
              R = vector3_6.X;
              G = vector3_6.Y;
              B = vector3_6.Z;
              break;
            }
            if (tile.frameX == (short) 306 || tile.frameX == (short) 324)
            {
              Vector3 vector3_7 = PortalHelper.GetPortalColor(Main.myPlayer, 1).ToVector3() * 0.65f;
              R = vector3_7.X;
              G = vector3_7.Y;
              B = vector3_7.Z;
              break;
            }
            break;
          case 215:
            if (tile.frameY < (short) 36)
            {
              float num13 = (float) localRandom.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 700f;
              float num14;
              float num15;
              float num16;
              switch ((int) tile.frameX / 54)
              {
                case 1:
                  num14 = 0.7f;
                  num15 = 1f;
                  num16 = 0.5f;
                  break;
                case 2:
                  num14 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  num15 = 0.3f;
                  num16 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 3:
                  num14 = 0.45f;
                  num15 = 0.75f;
                  num16 = 1f;
                  break;
                case 4:
                  num14 = 1.15f;
                  num15 = 1.15f;
                  num16 = 0.5f;
                  break;
                case 5:
                  num14 = (float) Main.DiscoR / (float) byte.MaxValue;
                  num15 = (float) Main.DiscoG / (float) byte.MaxValue;
                  num16 = (float) Main.DiscoB / (float) byte.MaxValue;
                  break;
                case 6:
                  num14 = 0.75f;
                  num15 = 1.2825f;
                  num16 = 1.2f;
                  break;
                case 7:
                  num14 = 0.95f;
                  num15 = 0.65f;
                  num16 = 1.3f;
                  break;
                case 8:
                  num14 = 1.4f;
                  num15 = 0.85f;
                  num16 = 0.55f;
                  break;
                case 9:
                  num14 = 0.25f;
                  num15 = 1.3f;
                  num16 = 0.8f;
                  break;
                case 10:
                  num14 = 0.95f;
                  num15 = 0.4f;
                  num16 = 1.4f;
                  break;
                case 11:
                  num14 = 1.4f;
                  num15 = 0.7f;
                  num16 = 0.5f;
                  break;
                case 12:
                  num14 = 1.25f;
                  num15 = 0.6f;
                  num16 = 1.2f;
                  break;
                case 13:
                  num14 = 0.75f;
                  num15 = 1.45f;
                  num16 = 0.9f;
                  break;
                default:
                  num14 = 0.9f;
                  num15 = 0.3f;
                  num16 = 0.1f;
                  break;
              }
              R = num14 + num13;
              G = num15 + num13;
              B = num16 + num13;
              break;
            }
            break;
          case 235:
            if ((double) lightColor.X < 0.6)
              lightColor.X = 0.6f;
            if ((double) lightColor.Y < 0.6)
            {
              lightColor.Y = 0.6f;
              break;
            }
            break;
          case 237:
            R = 0.1f;
            G = 0.1f;
            break;
          case 238:
            if ((double) lightColor.X < 0.5)
              lightColor.X = 0.5f;
            if ((double) lightColor.Z < 0.5)
            {
              lightColor.Z = 0.5f;
              break;
            }
            break;
          case 262:
            R = 0.75f;
            B = 0.75f;
            break;
          case 263:
            R = 0.75f;
            G = 0.75f;
            break;
          case 264:
            B = 0.75f;
            break;
          case 265:
            G = 0.75f;
            break;
          case 266:
            R = 0.75f;
            break;
          case 267:
            R = 0.75f;
            G = 0.75f;
            B = 0.75f;
            break;
          case 268:
            R = 0.75f;
            G = 0.375f;
            break;
          case 270:
            R = 0.73f;
            G = 1f;
            B = 0.41f;
            break;
          case 271:
            R = 0.45f;
            G = 0.95f;
            B = 1f;
            break;
          case 286:
          case 619:
            R = 0.1f;
            G = 0.2f;
            B = 0.7f;
            break;
          case 316:
          case 317:
          case 318:
            int index = (x - (int) tile.frameX / 18) / 2 * ((y - (int) tile.frameY / 18) / 3) % Main.cageFrames;
            bool flag1 = Main.jellyfishCageMode[(int) tile.type - 316, index] == (byte) 2;
            if (tile.type == (ushort) 316)
            {
              if (flag1)
              {
                R = 0.2f;
                G = 0.3f;
                B = 0.8f;
              }
              else
              {
                R = 0.1f;
                G = 0.2f;
                B = 0.5f;
              }
            }
            if (tile.type == (ushort) 317)
            {
              if (flag1)
              {
                R = 0.2f;
                G = 0.7f;
                B = 0.3f;
              }
              else
              {
                R = 0.05f;
                G = 0.45f;
                B = 0.1f;
              }
            }
            if (tile.type == (ushort) 318)
            {
              if (flag1)
              {
                R = 0.7f;
                G = 0.2f;
                B = 0.5f;
                break;
              }
              R = 0.4f;
              G = 0.1f;
              B = 0.25f;
              break;
            }
            break;
          case 327:
            float num17 = 0.5f + (float) (270 - (int) Main.mouseTextColor) / 1500f + (float) localRandom.Next(0, 50) * 0.0005f;
            R = 1f * num17;
            G = 0.5f * num17;
            B = 0.1f * num17;
            break;
          case 336:
            R = 0.85f;
            G = 0.5f;
            B = 0.3f;
            break;
          case 340:
            R = 0.45f;
            G = 1f;
            B = 0.45f;
            break;
          case 341:
            R = (float) (0.400000005960464 * (double) Main.demonTorch + 0.600000023841858 * (1.0 - (double) Main.demonTorch));
            G = 0.35f;
            B = (float) (1.0 * (double) Main.demonTorch + 0.600000023841858 * (1.0 - (double) Main.demonTorch));
            break;
          case 342:
            R = 0.5f;
            G = 0.5f;
            B = 1.1f;
            break;
          case 343:
            R = 0.85f;
            G = 0.85f;
            B = 0.3f;
            break;
          case 344:
            R = 0.6f;
            G = 1.026f;
            B = 0.96f;
            break;
          case 350:
            double num18 = Main.timeForVisualEffects * 0.08;
            double num19;
            R = (float) (num19 = -Math.Cos((int) (num18 / 6.283) % 3 == 1 ? num18 : 0.0) * 0.1 + 0.1);
            G = (float) num19;
            B = (float) num19;
            break;
          case 354:
            R = 0.65f;
            G = 0.35f;
            B = 0.15f;
            break;
          case 370:
            R = 0.32f;
            G = 0.16f;
            B = 0.12f;
            break;
          case 372:
            if (tile.frameX == (short) 0)
            {
              R = 0.9f;
              G = 0.1f;
              B = 0.75f;
              break;
            }
            break;
          case 381:
          case 517:
            R = 0.25f;
            G = 0.1f;
            B = 0.0f;
            break;
          case 390:
            R = 0.4f;
            G = 0.2f;
            B = 0.1f;
            break;
          case 391:
            R = 0.3f;
            G = 0.1f;
            B = 0.25f;
            break;
          case 405:
            if (tile.frameX < (short) 54)
            {
              float num20 = (float) localRandom.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 700f;
              float num21;
              float num22;
              float num23;
              switch ((int) tile.frameX / 54)
              {
                case 1:
                  num21 = 0.7f;
                  num22 = 1f;
                  num23 = 0.5f;
                  break;
                case 2:
                  num21 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                  num22 = 0.3f;
                  num23 = (float) (1.0 * (double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch));
                  break;
                case 3:
                  num21 = 0.45f;
                  num22 = 0.75f;
                  num23 = 1f;
                  break;
                case 4:
                  num21 = 1.15f;
                  num22 = 1.15f;
                  num23 = 0.5f;
                  break;
                case 5:
                  num21 = (float) Main.DiscoR / (float) byte.MaxValue;
                  num22 = (float) Main.DiscoG / (float) byte.MaxValue;
                  num23 = (float) Main.DiscoB / (float) byte.MaxValue;
                  break;
                default:
                  num21 = 0.9f;
                  num22 = 0.3f;
                  num23 = 0.1f;
                  break;
              }
              R = num21 + num20;
              G = num22 + num20;
              B = num23 + num20;
              break;
            }
            break;
          case 415:
            R = 0.7f;
            G = 0.5f;
            B = 0.1f;
            break;
          case 416:
            R = 0.0f;
            G = 0.6f;
            B = 0.7f;
            break;
          case 417:
            R = 0.6f;
            G = 0.2f;
            B = 0.6f;
            break;
          case 418:
            R = 0.6f;
            G = 0.6f;
            B = 0.9f;
            break;
          case 429:
            int num24 = (int) tile.frameX / 18;
            bool flag2 = num24 % 2 >= 1;
            bool flag3 = num24 % 4 >= 2;
            bool flag4 = num24 % 8 >= 4;
            int num25 = num24 % 16 >= 8 ? 1 : 0;
            if (flag2)
              R += 0.5f;
            if (flag3)
              G += 0.5f;
            if (flag4)
              B += 0.5f;
            if (num25 != 0)
            {
              R += 0.2f;
              G += 0.2f;
              break;
            }
            break;
          case 463:
            R = 0.2f;
            G = 0.4f;
            B = 0.8f;
            break;
          case 491:
            R = 0.5f;
            G = 0.4f;
            B = 0.7f;
            break;
          case 500:
            R = 0.525f;
            G = 0.375f;
            B = 0.075f;
            break;
          case 501:
            R = 0.0f;
            G = 0.45f;
            B = 0.525f;
            break;
          case 502:
            R = 0.45f;
            G = 0.15f;
            B = 0.45f;
            break;
          case 503:
            R = 0.45f;
            G = 0.45f;
            B = 0.675f;
            break;
          case 519:
            if (tile.frameY == (short) 90)
            {
              float num26 = (float) localRandom.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 1000f;
              R = 0.1f;
              G = (float) (0.200000002980232 + (double) num26 / 2.0);
              B = 0.7f + num26;
              break;
            }
            break;
          case 534:
          case 535:
            R = 0.0f;
            G = 0.25f;
            B = 0.0f;
            break;
          case 536:
          case 537:
            R = 0.0f;
            G = 0.16f;
            B = 0.34f;
            break;
          case 539:
          case 540:
            R = 0.3f;
            G = 0.0f;
            B = 0.17f;
            break;
          case 548:
            if ((int) tile.frameX / 54 >= 7)
            {
              R = 0.7f;
              G = 0.3f;
              B = 0.2f;
              break;
            }
            break;
          case 564:
            if (tile.frameX < (short) 36)
            {
              R = 0.05f;
              G = 0.3f;
              B = 0.55f;
              break;
            }
            break;
          case 568:
            R = 1f;
            G = 0.61f;
            B = 0.65f;
            break;
          case 569:
            R = 0.12f;
            G = 1f;
            B = 0.66f;
            break;
          case 570:
            R = 0.57f;
            G = 0.57f;
            B = 1f;
            break;
          case 572:
            switch ((int) tile.frameY / 36)
            {
              case 0:
                R = 0.9f;
                G = 0.5f;
                B = 0.7f;
                break;
              case 1:
                R = 0.7f;
                G = 0.55f;
                B = 0.96f;
                break;
              case 2:
                R = 0.45f;
                G = 0.96f;
                B = 0.95f;
                break;
              case 3:
                R = 0.5f;
                G = 0.96f;
                B = 0.62f;
                break;
              case 4:
                R = 0.47f;
                G = 0.69f;
                B = 0.95f;
                break;
              case 5:
                R = 0.92f;
                G = 0.57f;
                B = 0.51f;
                break;
            }
            break;
          case 580:
            R = 0.7f;
            G = 0.3f;
            B = 0.2f;
            break;
          case 581:
            R = 1f;
            G = 0.75f;
            B = 0.5f;
            break;
          case 582:
          case 598:
            R = 0.7f;
            G = 0.2f;
            B = 0.1f;
            break;
          case 592:
            if (tile.frameY > (short) 0)
            {
              float num27 = (float) localRandom.Next(28, 42) * 0.005f + (float) (270 - (int) Main.mouseTextColor) / 700f;
              float num28 = 1.35f;
              float num29 = 0.45f;
              float num30 = 0.15f;
              R = num28 + num27;
              G = num29 + num27;
              B = num30 + num27;
              break;
            }
            break;
          case 593:
            if (tile.frameX < (short) 18)
            {
              R = 0.8f;
              G = 0.3f;
              B = 0.1f;
              break;
            }
            break;
          case 594:
            if (tile.frameX < (short) 36)
            {
              R = 0.8f;
              G = 0.3f;
              B = 0.1f;
              break;
            }
            break;
          case 597:
            switch ((int) tile.frameX / 54)
            {
              case 0:
                R = 0.05f;
                G = 0.8f;
                B = 0.3f;
                break;
              case 1:
                R = 0.7f;
                G = 0.8f;
                B = 0.05f;
                break;
              case 2:
                R = 0.7f;
                G = 0.5f;
                B = 0.9f;
                break;
              case 3:
                R = 0.6f;
                G = 0.6f;
                B = 0.8f;
                break;
              case 4:
                R = 0.4f;
                G = 0.4f;
                B = 1.15f;
                break;
              case 5:
                R = 0.85f;
                G = 0.45f;
                B = 0.1f;
                break;
              case 6:
                R = 0.8f;
                G = 0.8f;
                B = 1f;
                break;
              case 7:
                R = 0.5f;
                G = 0.8f;
                B = 1.2f;
                break;
            }
            R *= 0.75f;
            G *= 0.75f;
            B *= 0.75f;
            break;
          case 613:
          case 614:
            R = 0.7f;
            G = 0.3f;
            B = 0.2f;
            break;
          case 620:
            Color color = new Color(230, 230, 230, 0).MultiplyRGBA(Main.hslToRgb((float) ((double) Main.GlobalTimeWrappedHourly * 0.5 % 1.0), 1f, 0.5f)) * 0.4f;
            R = (float) color.R / (float) byte.MaxValue;
            G = (float) color.G / (float) byte.MaxValue;
            B = (float) color.B / (float) byte.MaxValue;
            break;
        }
      }
      if ((double) lightColor.X < (double) R)
        lightColor.X = R;
      if ((double) lightColor.Y < (double) G)
        lightColor.Y = G;
      if ((double) lightColor.Z >= (double) B)
        return;
      lightColor.Z = B;
    }

    private void ApplySurfaceLight(Tile tile, int x, int y, ref Vector3 lightColor)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      float num4 = (float) Main.tileColor.R / (float) byte.MaxValue;
      float num5 = (float) Main.tileColor.G / (float) byte.MaxValue;
      float num6 = (float) Main.tileColor.B / (float) byte.MaxValue;
      float num7 = (float) (((double) num4 + (double) num5 + (double) num6) / 3.0);
      if (tile.active() && TileID.Sets.AllowLightInWater[(int) tile.type])
      {
        if ((double) lightColor.X < (double) num7 && (Main.wallLight[(int) tile.wall] || tile.wall == (ushort) 73 || tile.wall == (ushort) 227))
        {
          num1 = num4;
          num2 = num5;
          num3 = num6;
        }
      }
      else if ((!tile.active() || !Main.tileNoSunLight[(int) tile.type] || (tile.slope() != (byte) 0 || tile.halfBrick()) && this._world.Tiles[x, y - 1].liquid == (byte) 0 && this._world.Tiles[x, y + 1].liquid == (byte) 0 && this._world.Tiles[x - 1, y].liquid == (byte) 0 && this._world.Tiles[x + 1, y].liquid == (byte) 0) && (double) lightColor.X < (double) num7 && (Main.wallLight[(int) tile.wall] || tile.wall == (ushort) 73 || tile.wall == (ushort) 227) && tile.liquid < (byte) 200 && (!tile.halfBrick() || this._world.Tiles[x, y - 1].liquid < (byte) 200))
      {
        num1 = num4;
        num2 = num5;
        num3 = num6;
      }
      if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[(int) tile.type]) && (tile.wall >= (ushort) 88 && tile.wall <= (ushort) 93 || tile.wall == (ushort) 241) && tile.liquid < byte.MaxValue)
      {
        num1 = num4;
        num2 = num5;
        num3 = num6;
        int num8 = (int) tile.wall - 88;
        if (tile.wall == (ushort) 241)
          num8 = 6;
        switch (num8)
        {
          case 0:
            num1 *= 0.9f;
            num2 *= 0.15f;
            num3 *= 0.9f;
            break;
          case 1:
            num1 *= 0.9f;
            num2 *= 0.9f;
            num3 *= 0.15f;
            break;
          case 2:
            num1 *= 0.15f;
            num2 *= 0.15f;
            num3 *= 0.9f;
            break;
          case 3:
            num1 *= 0.15f;
            num2 *= 0.9f;
            num3 *= 0.15f;
            break;
          case 4:
            num1 *= 0.9f;
            num2 *= 0.15f;
            num3 *= 0.15f;
            break;
          case 5:
            float num9 = 0.2f;
            float num10 = 0.7f - num9;
            num1 *= num10 + (float) Main.DiscoR / (float) byte.MaxValue * num9;
            num2 *= num10 + (float) Main.DiscoG / (float) byte.MaxValue * num9;
            num3 *= num10 + (float) Main.DiscoB / (float) byte.MaxValue * num9;
            break;
          case 6:
            num1 *= 0.9f;
            num2 *= 0.5f;
            num3 *= 0.0f;
            break;
        }
      }
      if ((double) lightColor.X < (double) num1)
        lightColor.X = num1;
      if ((double) lightColor.Y < (double) num2)
        lightColor.Y = num2;
      if ((double) lightColor.Z >= (double) num3)
        return;
      lightColor.Z = num3;
    }

    private void ApplyHellLight(Tile tile, int x, int y, ref Vector3 lightColor)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      float num4 = (float) (0.550000011920929 + Math.Sin((double) Main.GlobalTimeWrappedHourly * 2.0) * 0.0799999982118607);
      if ((!tile.active() || !Main.tileNoSunLight[(int) tile.type] || (tile.slope() != (byte) 0 || tile.halfBrick()) && this._world.Tiles[x, y - 1].liquid == (byte) 0 && this._world.Tiles[x, y + 1].liquid == (byte) 0 && this._world.Tiles[x - 1, y].liquid == (byte) 0 && this._world.Tiles[x + 1, y].liquid == (byte) 0) && (double) lightColor.X < (double) num4 && (Main.wallLight[(int) tile.wall] || tile.wall == (ushort) 73 || tile.wall == (ushort) 227) && tile.liquid < (byte) 200 && (!tile.halfBrick() || this._world.Tiles[x, y - 1].liquid < (byte) 200))
      {
        num1 = num4;
        num2 = num4 * 0.6f;
        num3 = num4 * 0.2f;
      }
      if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[(int) tile.type]) && tile.wall >= (ushort) 88 && tile.wall <= (ushort) 93 && tile.liquid < byte.MaxValue)
      {
        num1 = num4;
        num2 = num4 * 0.6f;
        num3 = num4 * 0.2f;
        switch (tile.wall)
        {
          case 88:
            num1 *= 0.9f;
            num2 *= 0.15f;
            num3 *= 0.9f;
            break;
          case 89:
            num1 *= 0.9f;
            num2 *= 0.9f;
            num3 *= 0.15f;
            break;
          case 90:
            num1 *= 0.15f;
            num2 *= 0.15f;
            num3 *= 0.9f;
            break;
          case 91:
            num1 *= 0.15f;
            num2 *= 0.9f;
            num3 *= 0.15f;
            break;
          case 92:
            num1 *= 0.9f;
            num2 *= 0.15f;
            num3 *= 0.15f;
            break;
          case 93:
            float num5 = 0.2f;
            float num6 = 0.7f - num5;
            num1 *= num6 + (float) Main.DiscoR / (float) byte.MaxValue * num5;
            num2 *= num6 + (float) Main.DiscoG / (float) byte.MaxValue * num5;
            num3 *= num6 + (float) Main.DiscoB / (float) byte.MaxValue * num5;
            break;
        }
      }
      if ((double) lightColor.X < (double) num1)
        lightColor.X = num1;
      if ((double) lightColor.Y < (double) num2)
        lightColor.Y = num2;
      if ((double) lightColor.Z >= (double) num3)
        return;
      lightColor.Z = num3;
    }
  }
}
