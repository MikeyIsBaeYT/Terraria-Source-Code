// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PlayerSleepingHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria.GameContent
{
  public struct PlayerSleepingHelper
  {
    public const int BedSleepingMaxDistance = 96;
    public const int TimeToFullyFallAsleep = 120;
    public bool isSleeping;
    public int sleepingIndex;
    public int timeSleeping;
    public Vector2 visualOffsetOfBedBase;

    public bool FullyFallenAsleep => this.isSleeping && this.timeSleeping >= 120;

    public void GetSleepingOffsetInfo(Player player, out Vector2 posOffset)
    {
      if (this.isSleeping)
        posOffset = this.visualOffsetOfBedBase * player.Directions + new Vector2(0.0f, (float) ((double) this.sleepingIndex * (double) player.gravDir * -4.0));
      else
        posOffset = Vector2.Zero;
    }

    private bool DoesPlayerHaveReasonToActUpInBed(Player player) => NPC.AnyDanger(true) || Main.bloodMoon && !Main.dayTime || Main.eclipse && Main.dayTime || player.itemAnimation > 0;

    public void SetIsSleepingAndAdjustPlayerRotation(Player player, bool state)
    {
      if (this.isSleeping == state)
        return;
      this.isSleeping = state;
      if (state)
      {
        player.fullRotation = 1.570796f * (float) -player.direction;
      }
      else
      {
        player.fullRotation = 0.0f;
        this.visualOffsetOfBedBase = new Vector2();
      }
    }

    public void UpdateState(Player player)
    {
      if (!this.isSleeping)
      {
        this.timeSleeping = 0;
      }
      else
      {
        ++this.timeSleeping;
        if (this.DoesPlayerHaveReasonToActUpInBed(player))
          this.timeSleeping = 0;
        Point tileCoordinates = (player.Bottom + new Vector2(0.0f, -2f)).ToTileCoordinates();
        int targetDirection;
        Vector2 visualoffset;
        if (!PlayerSleepingHelper.GetSleepingTargetInfo(tileCoordinates.X, tileCoordinates.Y, out targetDirection, out Vector2 _, out visualoffset))
        {
          this.StopSleeping(player);
        }
        else
        {
          if (player.controlLeft || player.controlRight || player.controlUp || player.controlDown || player.controlJump || player.pulley || player.mount.Active || targetDirection != player.direction)
            this.StopSleeping(player);
          bool flag = false;
          if (player.itemAnimation > 0)
          {
            Item heldItem = player.HeldItem;
            if (heldItem.damage > 0 && !heldItem.noMelee)
              flag = true;
            if (heldItem.fishingPole > 0)
              flag = true;
            bool? nullable = ItemID.Sets.ForcesBreaksSleeping[heldItem.type];
            if (nullable.HasValue)
              flag = nullable.Value;
          }
          if (flag)
            this.StopSleeping(player);
          if (Main.sleepingManager.GetNextPlayerStackIndexInCoords(tileCoordinates) >= 2)
            this.StopSleeping(player);
          if (!this.isSleeping)
            return;
          this.visualOffsetOfBedBase = visualoffset;
          Main.sleepingManager.AddPlayerAndGetItsStackedIndexInCoords(player.whoAmI, tileCoordinates, out this.sleepingIndex);
        }
      }
    }

    public void StopSleeping(Player player, bool multiplayerBroadcast = true)
    {
      if (!this.isSleeping)
        return;
      this.SetIsSleepingAndAdjustPlayerRotation(player, false);
      this.timeSleeping = 0;
      this.sleepingIndex = -1;
      this.visualOffsetOfBedBase = new Vector2();
      if (!multiplayerBroadcast || Main.myPlayer != player.whoAmI)
        return;
      NetMessage.SendData(13, number: player.whoAmI);
    }

    public void StartSleeping(Player player, int x, int y)
    {
      int targetDirection;
      Vector2 anchorPosition;
      Vector2 visualoffset;
      PlayerSleepingHelper.GetSleepingTargetInfo(x, y, out targetDirection, out anchorPosition, out visualoffset);
      Vector2 offset = anchorPosition - player.Bottom;
      bool position = player.CanSnapToPosition(offset);
      if (position)
        position &= Main.sleepingManager.GetNextPlayerStackIndexInCoords((anchorPosition + new Vector2(0.0f, -2f)).ToTileCoordinates()) < 2;
      if (!position)
        return;
      if (this.isSleeping && player.Bottom == anchorPosition)
      {
        this.StopSleeping(player);
      }
      else
      {
        player.StopVanityActions();
        player.RemoveAllGrapplingHooks();
        player.RemoveAllFishingBobbers();
        if (player.mount.Active)
          player.mount.Dismount(player);
        player.Bottom = anchorPosition;
        player.ChangeDir(targetDirection);
        Main.sleepingManager.AddPlayerAndGetItsStackedIndexInCoords(player.whoAmI, new Point(x, y), out this.sleepingIndex);
        player.velocity = Vector2.Zero;
        player.gravDir = 1f;
        this.SetIsSleepingAndAdjustPlayerRotation(player, true);
        this.visualOffsetOfBedBase = visualoffset;
        if (Main.myPlayer != player.whoAmI)
          return;
        NetMessage.SendData(13, number: player.whoAmI);
      }
    }

    public static bool GetSleepingTargetInfo(
      int x,
      int y,
      out int targetDirection,
      out Vector2 anchorPosition,
      out Vector2 visualoffset)
    {
      Tile tileSafely = Framing.GetTileSafely(x, y);
      if (!TileID.Sets.CanBeSleptIn[(int) tileSafely.type] || !tileSafely.active())
      {
        targetDirection = 1;
        anchorPosition = new Vector2();
        visualoffset = new Vector2();
        return false;
      }
      int num1 = x;
      int num2 = y;
      int num3 = (int) tileSafely.frameX % 72 / 18;
      int num4 = num1 - num3;
      if ((int) tileSafely.frameY % 36 != 0)
        --num2;
      targetDirection = 1;
      int num5 = (int) tileSafely.frameX / 72;
      int x1 = num4;
      switch (num5)
      {
        case 0:
          targetDirection = -1;
          ++x1;
          break;
        case 1:
          x1 += 2;
          break;
      }
      anchorPosition = new Point(x1, num2 + 1).ToWorldCoordinates(autoAddY: 16f);
      visualoffset = PlayerSleepingHelper.SetOffsetbyBed((int) tileSafely.frameY / 36);
      return true;
    }

    private static Vector2 SetOffsetbyBed(int bedStyle)
    {
      switch (bedStyle)
      {
        case 8:
          return new Vector2(-11f, 1f);
        case 10:
          return new Vector2(-9f, -1f);
        case 11:
          return new Vector2(-11f, 1f);
        case 13:
          return new Vector2(-11f, -3f);
        case 15:
        case 16:
        case 17:
          return new Vector2(-7f, -3f);
        case 18:
          return new Vector2(-9f, -3f);
        case 19:
          return new Vector2(-3f, -1f);
        case 20:
          return new Vector2(-9f, -5f);
        case 21:
          return new Vector2(-9f, 5f);
        case 22:
          return new Vector2(-7f, 1f);
        case 23:
          return new Vector2(-5f, -1f);
        case 24:
        case 25:
          return new Vector2(-7f, 1f);
        case 27:
          return new Vector2(-9f, 3f);
        case 28:
          return new Vector2(-9f, 5f);
        case 29:
          return new Vector2(-11f, -1f);
        case 30:
          return new Vector2(-9f, 3f);
        case 31:
          return new Vector2(-7f, 5f);
        case 32:
          return new Vector2(-7f, -1f);
        case 34:
        case 35:
        case 36:
        case 37:
          return new Vector2(-13f, 1f);
        case 38:
          return new Vector2(-11f, -3f);
        default:
          return new Vector2(-9f, 1f);
      }
    }
  }
}
