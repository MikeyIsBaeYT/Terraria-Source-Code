// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlayerDeathReason
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.IO;
using Terraria.Localization;

namespace Terraria.DataStructures
{
  public class PlayerDeathReason
  {
    private int _sourcePlayerIndex = -1;
    private int _sourceNPCIndex = -1;
    private int _sourceProjectileIndex = -1;
    private int _sourceOtherIndex = -1;
    private int _sourceProjectileType;
    private int _sourceItemType;
    private int _sourceItemPrefix;
    private string _sourceCustomReason;

    public int? SourceProjectileType => this._sourceProjectileIndex == -1 ? new int?() : new int?(this._sourceProjectileType);

    public static PlayerDeathReason LegacyEmpty() => new PlayerDeathReason()
    {
      _sourceOtherIndex = 254
    };

    public static PlayerDeathReason LegacyDefault() => new PlayerDeathReason()
    {
      _sourceOtherIndex = (int) byte.MaxValue
    };

    public static PlayerDeathReason ByNPC(int index) => new PlayerDeathReason()
    {
      _sourceNPCIndex = index
    };

    public static PlayerDeathReason ByCustomReason(string reasonInEnglish) => new PlayerDeathReason()
    {
      _sourceCustomReason = reasonInEnglish
    };

    public static PlayerDeathReason ByPlayer(int index) => new PlayerDeathReason()
    {
      _sourcePlayerIndex = index,
      _sourceItemType = Main.player[index].inventory[Main.player[index].selectedItem].type,
      _sourceItemPrefix = (int) Main.player[index].inventory[Main.player[index].selectedItem].prefix
    };

    public static PlayerDeathReason ByOther(int type) => new PlayerDeathReason()
    {
      _sourceOtherIndex = type
    };

    public static PlayerDeathReason ByProjectile(
      int playerIndex,
      int projectileIndex)
    {
      PlayerDeathReason playerDeathReason = new PlayerDeathReason()
      {
        _sourcePlayerIndex = playerIndex,
        _sourceProjectileIndex = projectileIndex,
        _sourceProjectileType = Main.projectile[projectileIndex].type
      };
      if (playerIndex >= 0 && playerIndex <= (int) byte.MaxValue)
      {
        playerDeathReason._sourceItemType = Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].type;
        playerDeathReason._sourceItemPrefix = (int) Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].prefix;
      }
      return playerDeathReason;
    }

    public NetworkText GetDeathText(string deadPlayerName) => this._sourceCustomReason != null ? NetworkText.FromLiteral(this._sourceCustomReason) : Lang.CreateDeathMessage(deadPlayerName, this._sourcePlayerIndex, this._sourceNPCIndex, this._sourceProjectileIndex, this._sourceOtherIndex, this._sourceProjectileType, this._sourceItemType);

    public void WriteSelfTo(BinaryWriter writer)
    {
      BitsByte bitsByte = (BitsByte) (byte) 0;
      bitsByte[0] = this._sourcePlayerIndex != -1;
      bitsByte[1] = this._sourceNPCIndex != -1;
      bitsByte[2] = this._sourceProjectileIndex != -1;
      bitsByte[3] = this._sourceOtherIndex != -1;
      bitsByte[4] = (uint) this._sourceProjectileType > 0U;
      bitsByte[5] = (uint) this._sourceItemType > 0U;
      bitsByte[6] = (uint) this._sourceItemPrefix > 0U;
      bitsByte[7] = this._sourceCustomReason != null;
      writer.Write((byte) bitsByte);
      if (bitsByte[0])
        writer.Write((short) this._sourcePlayerIndex);
      if (bitsByte[1])
        writer.Write((short) this._sourceNPCIndex);
      if (bitsByte[2])
        writer.Write((short) this._sourceProjectileIndex);
      if (bitsByte[3])
        writer.Write((byte) this._sourceOtherIndex);
      if (bitsByte[4])
        writer.Write((short) this._sourceProjectileType);
      if (bitsByte[5])
        writer.Write((short) this._sourceItemType);
      if (bitsByte[6])
        writer.Write((byte) this._sourceItemPrefix);
      if (!bitsByte[7])
        return;
      writer.Write(this._sourceCustomReason);
    }

    public static PlayerDeathReason FromReader(BinaryReader reader)
    {
      PlayerDeathReason playerDeathReason = new PlayerDeathReason();
      BitsByte bitsByte = (BitsByte) reader.ReadByte();
      if (bitsByte[0])
        playerDeathReason._sourcePlayerIndex = (int) reader.ReadInt16();
      if (bitsByte[1])
        playerDeathReason._sourceNPCIndex = (int) reader.ReadInt16();
      if (bitsByte[2])
        playerDeathReason._sourceProjectileIndex = (int) reader.ReadInt16();
      if (bitsByte[3])
        playerDeathReason._sourceOtherIndex = (int) reader.ReadByte();
      if (bitsByte[4])
        playerDeathReason._sourceProjectileType = (int) reader.ReadInt16();
      if (bitsByte[5])
        playerDeathReason._sourceItemType = (int) reader.ReadInt16();
      if (bitsByte[6])
        playerDeathReason._sourceItemPrefix = (int) reader.ReadByte();
      if (bitsByte[7])
        playerDeathReason._sourceCustomReason = reader.ReadString();
      return playerDeathReason;
    }
  }
}
