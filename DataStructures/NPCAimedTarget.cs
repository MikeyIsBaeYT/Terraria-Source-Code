// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.NPCAimedTarget
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Enums;

namespace Terraria.DataStructures
{
  public struct NPCAimedTarget
  {
    public NPCTargetType Type;
    public Rectangle Hitbox;
    public int Width;
    public int Height;
    public Vector2 Position;
    public Vector2 Velocity;

    public bool Invalid => this.Type == NPCTargetType.None;

    public Vector2 Center => this.Position + this.Size / 2f;

    public Vector2 Size => new Vector2((float) this.Width, (float) this.Height);

    public NPCAimedTarget(NPC npc)
    {
      this.Type = NPCTargetType.NPC;
      this.Hitbox = npc.Hitbox;
      this.Width = npc.width;
      this.Height = npc.height;
      this.Position = npc.position;
      this.Velocity = npc.velocity;
    }

    public NPCAimedTarget(Player player, bool ignoreTank = true)
    {
      this.Type = NPCTargetType.Player;
      this.Hitbox = player.Hitbox;
      this.Width = player.width;
      this.Height = player.height;
      this.Position = player.position;
      this.Velocity = player.velocity;
      if (ignoreTank || player.tankPet <= -1)
        return;
      Projectile projectile = Main.projectile[player.tankPet];
      this.Type = NPCTargetType.PlayerTankPet;
      this.Hitbox = projectile.Hitbox;
      this.Width = projectile.width;
      this.Height = projectile.height;
      this.Position = projectile.position;
      this.Velocity = projectile.velocity;
    }
  }
}
