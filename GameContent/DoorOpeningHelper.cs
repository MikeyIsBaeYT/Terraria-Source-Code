// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.DoorOpeningHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameInput;

namespace Terraria.GameContent
{
  public class DoorOpeningHelper
  {
    public static DoorOpeningHelper.DoorAutoOpeningPreference PreferenceSettings = DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForEverything;
    private Dictionary<int, DoorOpeningHelper.DoorAutoHandler> _handlerByTileType = new Dictionary<int, DoorOpeningHelper.DoorAutoHandler>()
    {
      {
        10,
        (DoorOpeningHelper.DoorAutoHandler) new DoorOpeningHelper.CommonDoorOpeningInfoProvider()
      },
      {
        388,
        (DoorOpeningHelper.DoorAutoHandler) new DoorOpeningHelper.TallGateOpeningInfoProvider()
      }
    };
    private List<DoorOpeningHelper.DoorOpenCloseTogglingInfo> _ongoingOpenDoors = new List<DoorOpeningHelper.DoorOpenCloseTogglingInfo>();
    private int _timeWeCanOpenDoorsUsingVelocityAlone;

    public void AllowOpeningDoorsByVelocityAloneForATime(int timeInFramesToAllow) => this._timeWeCanOpenDoorsUsingVelocityAlone = timeInFramesToAllow;

    public void Update(Player player)
    {
      this.LookForDoorsToClose(player);
      if (this.ShouldTryOpeningDoors())
        this.LookForDoorsToOpen(player);
      if (this._timeWeCanOpenDoorsUsingVelocityAlone <= 0)
        return;
      --this._timeWeCanOpenDoorsUsingVelocityAlone;
    }

    private bool ShouldTryOpeningDoors()
    {
      switch (DoorOpeningHelper.PreferenceSettings)
      {
        case DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForGamepadOnly:
          return PlayerInput.UsingGamepad;
        case DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForEverything:
          return true;
        default:
          return false;
      }
    }

    public static void CyclePreferences()
    {
      switch (DoorOpeningHelper.PreferenceSettings)
      {
        case DoorOpeningHelper.DoorAutoOpeningPreference.Disabled:
          DoorOpeningHelper.PreferenceSettings = DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForEverything;
          break;
        case DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForGamepadOnly:
          DoorOpeningHelper.PreferenceSettings = DoorOpeningHelper.DoorAutoOpeningPreference.Disabled;
          break;
        case DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForEverything:
          DoorOpeningHelper.PreferenceSettings = DoorOpeningHelper.DoorAutoOpeningPreference.EnabledForGamepadOnly;
          break;
      }
    }

    public void LookForDoorsToClose(Player player)
    {
      DoorOpeningHelper.PlayerInfoForClosingDoors infoForClosingDoor = this.GetPlayerInfoForClosingDoor(player);
      for (int index = this._ongoingOpenDoors.Count - 1; index >= 0; --index)
      {
        DoorOpeningHelper.DoorOpenCloseTogglingInfo ongoingOpenDoor = this._ongoingOpenDoors[index];
        if (ongoingOpenDoor.handler.TryCloseDoor(ongoingOpenDoor, infoForClosingDoor) != DoorOpeningHelper.DoorCloseAttemptResult.StillInDoorArea)
          this._ongoingOpenDoors.RemoveAt(index);
      }
    }

    private DoorOpeningHelper.PlayerInfoForClosingDoors GetPlayerInfoForClosingDoor(
      Player player)
    {
      return new DoorOpeningHelper.PlayerInfoForClosingDoors()
      {
        hitboxToNotCloseDoor = player.Hitbox
      };
    }

    public void LookForDoorsToOpen(Player player)
    {
      DoorOpeningHelper.PlayerInfoForOpeningDoors infoForOpeningDoor = this.GetPlayerInfoForOpeningDoor(player);
      if (infoForOpeningDoor.intendedOpeningDirection == 0 && (double) player.velocity.X == 0.0)
        return;
      Point tileCoords = new Point();
      for (int left = infoForOpeningDoor.tileCoordSpaceForCheckingForDoors.Left; left <= infoForOpeningDoor.tileCoordSpaceForCheckingForDoors.Right; ++left)
      {
        for (int top = infoForOpeningDoor.tileCoordSpaceForCheckingForDoors.Top; top <= infoForOpeningDoor.tileCoordSpaceForCheckingForDoors.Bottom; ++top)
        {
          tileCoords.X = left;
          tileCoords.Y = top;
          this.TryAutoOpeningDoor(tileCoords, infoForOpeningDoor);
        }
      }
    }

    private DoorOpeningHelper.PlayerInfoForOpeningDoors GetPlayerInfoForOpeningDoor(
      Player player)
    {
      int num1 = player.controlRight.ToInt() - player.controlLeft.ToInt();
      int gravDir = (int) player.gravDir;
      Rectangle hitbox1 = player.Hitbox;
      hitbox1.Y -= -1;
      hitbox1.Height += -2;
      float num2 = player.velocity.X;
      if (num1 == 0 && this._timeWeCanOpenDoorsUsingVelocityAlone == 0)
        num2 = 0.0f;
      float num3 = (float) num1 + num2;
      int num4 = Math.Sign(num3) * (int) Math.Ceiling((double) Math.Abs(num3));
      hitbox1.X += num4;
      if (num1 == 0)
        num1 = Math.Sign(num3);
      Rectangle hitbox2;
      Rectangle rectangle1 = hitbox2 = player.Hitbox;
      rectangle1.X += num4;
      Rectangle rectangle2 = rectangle1;
      Rectangle r = Rectangle.Union(hitbox2, rectangle2);
      Point tileCoordinates1 = r.TopLeft().ToTileCoordinates();
      Point tileCoordinates2 = r.BottomRight().ToTileCoordinates();
      Rectangle rectangle3 = new Rectangle(tileCoordinates1.X, tileCoordinates1.Y, tileCoordinates2.X - tileCoordinates1.X, tileCoordinates2.Y - tileCoordinates1.Y);
      return new DoorOpeningHelper.PlayerInfoForOpeningDoors()
      {
        hitboxToOpenDoor = hitbox1,
        intendedOpeningDirection = num1,
        playerGravityDirection = gravDir,
        tileCoordSpaceForCheckingForDoors = rectangle3
      };
    }

    private void TryAutoOpeningDoor(
      Point tileCoords,
      DoorOpeningHelper.PlayerInfoForOpeningDoors playerInfo)
    {
      DoorOpeningHelper.DoorAutoHandler infoProvider;
      if (!this.TryGetHandler(tileCoords, out infoProvider))
        return;
      DoorOpeningHelper.DoorOpenCloseTogglingInfo info = infoProvider.ProvideInfo(tileCoords);
      if (!infoProvider.TryOpenDoor(info, playerInfo))
        return;
      this._ongoingOpenDoors.Add(info);
    }

    private bool TryGetHandler(Point tileCoords, out DoorOpeningHelper.DoorAutoHandler infoProvider)
    {
      infoProvider = (DoorOpeningHelper.DoorAutoHandler) null;
      if (!WorldGen.InWorld(tileCoords.X, tileCoords.Y, 3))
        return false;
      Tile tile = Main.tile[tileCoords.X, tileCoords.Y];
      return tile != null && this._handlerByTileType.TryGetValue((int) tile.type, out infoProvider);
    }

    public enum DoorAutoOpeningPreference
    {
      Disabled,
      EnabledForGamepadOnly,
      EnabledForEverything,
    }

    private enum DoorCloseAttemptResult
    {
      StillInDoorArea,
      ClosedDoor,
      FailedToCloseDoor,
      DoorIsInvalidated,
    }

    private struct DoorOpenCloseTogglingInfo
    {
      public Point tileCoordsForToggling;
      public DoorOpeningHelper.DoorAutoHandler handler;
    }

    private struct PlayerInfoForOpeningDoors
    {
      public Rectangle hitboxToOpenDoor;
      public int intendedOpeningDirection;
      public int playerGravityDirection;
      public Rectangle tileCoordSpaceForCheckingForDoors;
    }

    private struct PlayerInfoForClosingDoors
    {
      public Rectangle hitboxToNotCloseDoor;
    }

    private interface DoorAutoHandler
    {
      DoorOpeningHelper.DoorOpenCloseTogglingInfo ProvideInfo(Point tileCoords);

      bool TryOpenDoor(
        DoorOpeningHelper.DoorOpenCloseTogglingInfo info,
        DoorOpeningHelper.PlayerInfoForOpeningDoors playerInfo);

      DoorOpeningHelper.DoorCloseAttemptResult TryCloseDoor(
        DoorOpeningHelper.DoorOpenCloseTogglingInfo info,
        DoorOpeningHelper.PlayerInfoForClosingDoors playerInfo);
    }

    private class CommonDoorOpeningInfoProvider : DoorOpeningHelper.DoorAutoHandler
    {
      public DoorOpeningHelper.DoorOpenCloseTogglingInfo ProvideInfo(
        Point tileCoords)
      {
        Tile tile = Main.tile[tileCoords.X, tileCoords.Y];
        Point point = tileCoords;
        point.Y -= (int) tile.frameY % 54 / 18;
        return new DoorOpeningHelper.DoorOpenCloseTogglingInfo()
        {
          handler = (DoorOpeningHelper.DoorAutoHandler) this,
          tileCoordsForToggling = point
        };
      }

      public bool TryOpenDoor(
        DoorOpeningHelper.DoorOpenCloseTogglingInfo doorInfo,
        DoorOpeningHelper.PlayerInfoForOpeningDoors playerInfo)
      {
        Point coordsForToggling = doorInfo.tileCoordsForToggling;
        int openingDirection = playerInfo.intendedOpeningDirection;
        Rectangle rectangle = new Rectangle(doorInfo.tileCoordsForToggling.X * 16, doorInfo.tileCoordsForToggling.Y * 16, 16, 48);
        switch (playerInfo.playerGravityDirection)
        {
          case -1:
            rectangle.Y -= 16;
            rectangle.Height += 16;
            break;
          case 1:
            rectangle.Height += 16;
            break;
        }
        if (!rectangle.Intersects(playerInfo.hitboxToOpenDoor) || playerInfo.hitboxToOpenDoor.Top < rectangle.Top || playerInfo.hitboxToOpenDoor.Bottom > rectangle.Bottom)
          return false;
        WorldGen.OpenDoor(coordsForToggling.X, coordsForToggling.Y, openingDirection);
        if (Main.tile[coordsForToggling.X, coordsForToggling.Y].type != (ushort) 10)
        {
          NetMessage.SendData(19, number2: ((float) coordsForToggling.X), number3: ((float) coordsForToggling.Y), number4: ((float) openingDirection));
          return true;
        }
        WorldGen.OpenDoor(coordsForToggling.X, coordsForToggling.Y, -openingDirection);
        if (Main.tile[coordsForToggling.X, coordsForToggling.Y].type == (ushort) 10)
          return false;
        NetMessage.SendData(19, number2: ((float) coordsForToggling.X), number3: ((float) coordsForToggling.Y), number4: ((float) -openingDirection));
        return true;
      }

      public DoorOpeningHelper.DoorCloseAttemptResult TryCloseDoor(
        DoorOpeningHelper.DoorOpenCloseTogglingInfo info,
        DoorOpeningHelper.PlayerInfoForClosingDoors playerInfo)
      {
        Point coordsForToggling = info.tileCoordsForToggling;
        Tile tile = Main.tile[coordsForToggling.X, coordsForToggling.Y];
        if (!tile.active() || tile.type != (ushort) 11)
          return DoorOpeningHelper.DoorCloseAttemptResult.DoorIsInvalidated;
        int num = (int) tile.frameX % 72 / 18;
        Rectangle rectangle1 = new Rectangle(coordsForToggling.X * 16, coordsForToggling.Y * 16, 16, 48);
        switch (num)
        {
          case 1:
            rectangle1.X -= 16;
            break;
          case 2:
            rectangle1.X += 16;
            break;
        }
        rectangle1.Inflate(1, 0);
        Rectangle rectangle2 = Rectangle.Intersect(rectangle1, playerInfo.hitboxToNotCloseDoor);
        if (rectangle2.Width > 0 || rectangle2.Height > 0)
          return DoorOpeningHelper.DoorCloseAttemptResult.StillInDoorArea;
        if (!WorldGen.CloseDoor(coordsForToggling.X, coordsForToggling.Y))
          return DoorOpeningHelper.DoorCloseAttemptResult.FailedToCloseDoor;
        NetMessage.SendData(13, number: Main.myPlayer);
        NetMessage.SendData(19, number: 1, number2: ((float) coordsForToggling.X), number3: ((float) coordsForToggling.Y), number4: 1f);
        return DoorOpeningHelper.DoorCloseAttemptResult.ClosedDoor;
      }
    }

    private class TallGateOpeningInfoProvider : DoorOpeningHelper.DoorAutoHandler
    {
      public DoorOpeningHelper.DoorOpenCloseTogglingInfo ProvideInfo(
        Point tileCoords)
      {
        Tile tile = Main.tile[tileCoords.X, tileCoords.Y];
        Point point = tileCoords;
        point.Y -= (int) tile.frameY % 90 / 18;
        return new DoorOpeningHelper.DoorOpenCloseTogglingInfo()
        {
          handler = (DoorOpeningHelper.DoorAutoHandler) this,
          tileCoordsForToggling = point
        };
      }

      public bool TryOpenDoor(
        DoorOpeningHelper.DoorOpenCloseTogglingInfo doorInfo,
        DoorOpeningHelper.PlayerInfoForOpeningDoors playerInfo)
      {
        Point coordsForToggling = doorInfo.tileCoordsForToggling;
        Rectangle rectangle = new Rectangle(doorInfo.tileCoordsForToggling.X * 16, doorInfo.tileCoordsForToggling.Y * 16, 16, 80);
        switch (playerInfo.playerGravityDirection)
        {
          case -1:
            rectangle.Y -= 16;
            rectangle.Height += 16;
            break;
          case 1:
            rectangle.Height += 16;
            break;
        }
        if (!rectangle.Intersects(playerInfo.hitboxToOpenDoor) || playerInfo.hitboxToOpenDoor.Top < rectangle.Top || playerInfo.hitboxToOpenDoor.Bottom > rectangle.Bottom)
          return false;
        bool closing = false;
        if (!WorldGen.ShiftTallGate(coordsForToggling.X, coordsForToggling.Y, closing))
          return false;
        NetMessage.SendData(19, number: (4 + closing.ToInt()), number2: ((float) coordsForToggling.X), number3: ((float) coordsForToggling.Y));
        return true;
      }

      public DoorOpeningHelper.DoorCloseAttemptResult TryCloseDoor(
        DoorOpeningHelper.DoorOpenCloseTogglingInfo info,
        DoorOpeningHelper.PlayerInfoForClosingDoors playerInfo)
      {
        Point coordsForToggling = info.tileCoordsForToggling;
        Tile tile = Main.tile[coordsForToggling.X, coordsForToggling.Y];
        if (!tile.active() || tile.type != (ushort) 389)
          return DoorOpeningHelper.DoorCloseAttemptResult.DoorIsInvalidated;
        int num = (int) tile.frameY % 90 / 18;
        Rectangle rectangle1 = new Rectangle(coordsForToggling.X * 16, coordsForToggling.Y * 16, 16, 80);
        rectangle1.Inflate(1, 0);
        Rectangle rectangle2 = Rectangle.Intersect(rectangle1, playerInfo.hitboxToNotCloseDoor);
        if (rectangle2.Width > 0 || rectangle2.Height > 0)
          return DoorOpeningHelper.DoorCloseAttemptResult.StillInDoorArea;
        bool closing = true;
        if (!WorldGen.ShiftTallGate(coordsForToggling.X, coordsForToggling.Y, closing))
          return DoorOpeningHelper.DoorCloseAttemptResult.FailedToCloseDoor;
        NetMessage.SendData(13, number: Main.myPlayer);
        NetMessage.SendData(19, number: (4 + closing.ToInt()), number2: ((float) coordsForToggling.X), number3: ((float) coordsForToggling.Y));
        return DoorOpeningHelper.DoorCloseAttemptResult.ClosedDoor;
      }
    }
  }
}
