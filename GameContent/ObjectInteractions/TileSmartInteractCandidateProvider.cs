// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.TileSmartInteractCandidateProvider
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Terraria.GameContent.ObjectInteractions
{
  public class TileSmartInteractCandidateProvider : ISmartInteractCandidateProvider
  {
    private List<Tuple<int, int>> targets = new List<Tuple<int, int>>();
    private TileSmartInteractCandidateProvider.ReusableCandidate _candidate = new TileSmartInteractCandidateProvider.ReusableCandidate();

    public void ClearSelfAndPrepareForCheck()
    {
      Main.TileInteractionLX = -1;
      Main.TileInteractionHX = -1;
      Main.TileInteractionLY = -1;
      Main.TileInteractionHY = -1;
      Main.SmartInteractTileCoords.Clear();
      Main.SmartInteractTileCoordsSelected.Clear();
      this.targets.Clear();
    }

    public bool ProvideCandidate(
      SmartInteractScanSettings settings,
      out ISmartInteractCandidate candidate)
    {
      candidate = (ISmartInteractCandidate) null;
      Point tileCoordinates = settings.mousevec.ToTileCoordinates();
      this.FillPotentialTargetTiles(settings);
      int num1 = -1;
      int num2 = -1;
      int AimedX = -1;
      int AimedY = -1;
      if (this.targets.Count > 0)
      {
        float num3 = -1f;
        Tuple<int, int> target = this.targets[0];
        for (int index = 0; index < this.targets.Count; ++index)
        {
          float num4 = Vector2.Distance(new Vector2((float) this.targets[index].Item1, (float) this.targets[index].Item2) * 16f + Vector2.One * 8f, settings.mousevec);
          if ((double) num3 == -1.0 || (double) num4 <= (double) num3)
          {
            num3 = num4;
            target = this.targets[index];
          }
        }
        if (Collision.InTileBounds(target.Item1, target.Item2, settings.LX, settings.LY, settings.HX, settings.HY))
        {
          num1 = target.Item1;
          num2 = target.Item2;
        }
      }
      bool flag1 = false;
      for (int index1 = 0; index1 < this.targets.Count; ++index1)
      {
        int index2 = this.targets[index1].Item1;
        int index3 = this.targets[index1].Item2;
        Tile tile = Main.tile[index2, index3];
        int num5 = 0;
        int num6 = 0;
        int num7 = 18;
        int num8 = 18;
        int num9 = 2;
        switch (tile.type)
        {
          case 10:
            num5 = 1;
            num6 = 3;
            num9 = 0;
            break;
          case 11:
          case 356:
          case 410:
          case 470:
          case 480:
          case 509:
            num5 = 2;
            num6 = 3;
            num9 = 0;
            break;
          case 15:
          case 497:
            num5 = 1;
            num6 = 2;
            num9 = 4;
            break;
          case 21:
          case 55:
          case 85:
          case 97:
          case 125:
          case 132:
          case 287:
          case 335:
          case 386:
          case 411:
          case 425:
          case 441:
          case 467:
          case 468:
          case 573:
          case 621:
            num5 = 2;
            num6 = 2;
            break;
          case 29:
          case 387:
            num5 = 2;
            num6 = 1;
            break;
          case 79:
          case 139:
          case 510:
          case 511:
            num5 = 2;
            num6 = 2;
            num9 = 0;
            break;
          case 88:
            num5 = 3;
            num6 = 1;
            num9 = 0;
            break;
          case 89:
          case 215:
          case 237:
          case 377:
            num5 = 3;
            num6 = 2;
            break;
          case 102:
          case 463:
          case 475:
          case 597:
            num5 = 3;
            num6 = 4;
            break;
          case 104:
            num5 = 2;
            num6 = 5;
            break;
          case 136:
          case 144:
          case 494:
            num5 = 1;
            num6 = 1;
            num9 = 0;
            break;
          case 207:
            num5 = 2;
            num6 = 4;
            num9 = 0;
            break;
          case 209:
            num5 = 4;
            num6 = 3;
            num9 = 0;
            break;
          case 212:
            num5 = 4;
            num6 = 3;
            break;
          case 216:
          case 338:
            num5 = 1;
            num6 = 2;
            break;
          case 354:
          case 455:
          case 491:
            num5 = 3;
            num6 = 3;
            num9 = 0;
            break;
          case 388:
          case 389:
            num5 = 1;
            num6 = 5;
            break;
          case 487:
            num5 = 4;
            num6 = 2;
            num9 = 0;
            break;
        }
        if (num5 != 0 && num6 != 0)
        {
          int lx = index2 - (int) tile.frameX % (num7 * num5) / num7;
          int ly = index3 - (int) tile.frameY % (num8 * num6 + num9) / num8;
          bool flag2 = Collision.InTileBounds(num1, num2, lx, ly, lx + num5 - 1, ly + num6 - 1);
          bool flag3 = Collision.InTileBounds(tileCoordinates.X, tileCoordinates.Y, lx, ly, lx + num5 - 1, ly + num6 - 1);
          if (flag3)
          {
            AimedX = tileCoordinates.X;
            AimedY = tileCoordinates.Y;
          }
          if (!settings.FullInteraction)
            flag2 &= flag3;
          if (flag1)
            flag2 = false;
          for (int x = lx; x < lx + num5; ++x)
          {
            for (int y = ly; y < ly + num6; ++y)
            {
              Point point = new Point(x, y);
              if (!Main.SmartInteractTileCoords.Contains(point))
              {
                if (flag2)
                  Main.SmartInteractTileCoordsSelected.Add(point);
                if (flag2 || settings.FullInteraction)
                  Main.SmartInteractTileCoords.Add(point);
              }
            }
          }
          if (!flag1 & flag2)
            flag1 = true;
        }
      }
      if (settings.DemandOnlyZeroDistanceTargets)
      {
        if (AimedX == -1 || AimedY == -1)
          return false;
        this._candidate.Reuse(true, 0.0f, AimedX, AimedY, settings.LX - 10, settings.LY - 10, settings.HX + 10, settings.HY + 10);
        candidate = (ISmartInteractCandidate) this._candidate;
        return true;
      }
      if (num1 == -1 || num2 == -1)
        return false;
      this._candidate.Reuse(false, new Rectangle(num1 * 16, num2 * 16, 16, 16).ClosestPointInRect(settings.mousevec).Distance(settings.mousevec), num1, num2, settings.LX - 10, settings.LY - 10, settings.HX + 10, settings.HY + 10);
      candidate = (ISmartInteractCandidate) this._candidate;
      return true;
    }

    private void FillPotentialTargetTiles(SmartInteractScanSettings settings)
    {
      for (int lx = settings.LX; lx <= settings.HX; ++lx)
      {
        for (int ly = settings.LY; ly <= settings.HY; ++ly)
        {
          Tile tile = Main.tile[lx, ly];
          if (tile != null && tile.active())
          {
            switch (tile.type)
            {
              case 10:
              case 11:
              case 21:
              case 29:
              case 55:
              case 79:
              case 85:
              case 88:
              case 89:
              case 97:
              case 102:
              case 104:
              case 125:
              case 132:
              case 136:
              case 139:
              case 144:
              case 207:
              case 209:
              case 215:
              case 216:
              case 287:
              case 335:
              case 338:
              case 354:
              case 377:
              case 386:
              case 387:
              case 388:
              case 389:
              case 410:
              case 411:
              case 425:
              case 441:
              case 455:
              case 463:
              case 467:
              case 468:
              case 470:
              case 475:
              case 480:
              case 487:
              case 491:
              case 494:
              case 509:
              case 510:
              case 511:
              case 573:
              case 597:
              case 621:
                this.targets.Add(new Tuple<int, int>(lx, ly));
                continue;
              case 15:
              case 497:
                if (settings.player.IsWithinSnappngRangeToTile(lx, ly, 40))
                {
                  this.targets.Add(new Tuple<int, int>(lx, ly));
                  continue;
                }
                continue;
              case 212:
                if (settings.player.HasItem(949))
                {
                  this.targets.Add(new Tuple<int, int>(lx, ly));
                  continue;
                }
                continue;
              case 237:
                if (settings.player.HasItem(1293))
                {
                  this.targets.Add(new Tuple<int, int>(lx, ly));
                  continue;
                }
                continue;
              case 356:
                if (!Main.fastForwardTime && (Main.netMode == 1 || Main.sundialCooldown == 0))
                {
                  this.targets.Add(new Tuple<int, int>(lx, ly));
                  continue;
                }
                continue;
              default:
                continue;
            }
          }
        }
      }
    }

    private class ReusableCandidate : ISmartInteractCandidate
    {
      private bool _strictSettings;
      private int _aimedX;
      private int _aimedY;
      private int _hx;
      private int _hy;
      private int _lx;
      private int _ly;

      public void Reuse(
        bool strictSettings,
        float distanceFromCursor,
        int AimedX,
        int AimedY,
        int LX,
        int LY,
        int HX,
        int HY)
      {
        this.DistanceFromCursor = distanceFromCursor;
        this._strictSettings = strictSettings;
        this._aimedX = AimedX;
        this._aimedY = AimedY;
        this._lx = LX;
        this._ly = LY;
        this._hx = HX;
        this._hy = HY;
      }

      public float DistanceFromCursor { get; private set; }

      public void WinCandidacy()
      {
        Main.SmartInteractX = this._aimedX;
        Main.SmartInteractY = this._aimedY;
        if (this._strictSettings)
          Main.SmartInteractShowingFake = Main.SmartInteractTileCoords.Count > 0;
        else
          Main.SmartInteractShowingGenuine = true;
        Main.TileInteractionLX = this._lx - 10;
        Main.TileInteractionLY = this._ly - 10;
        Main.TileInteractionHX = this._hx + 10;
        Main.TileInteractionHY = this._hy + 10;
      }
    }
  }
}
