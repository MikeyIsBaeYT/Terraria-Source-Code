// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.EmoteBubble
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Events;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
  public class EmoteBubble
  {
    private static int[] CountNPCs = new int[663];
    public static Dictionary<int, EmoteBubble> byID = new Dictionary<int, EmoteBubble>();
    private static List<int> toClean = new List<int>();
    public static int NextID;
    public int ID;
    public WorldUIAnchor anchor;
    public int lifeTime;
    public int lifeTimeStart;
    public int emote;
    public int metadata;
    private const int frameSpeed = 8;
    public int frameCounter;
    public int frame;
    public const int EMOTE_SHEET_HORIZONTAL_FRAMES = 8;
    public const int EMOTE_SHEET_EMOTES_PER_ROW = 4;
    public const int EMOTE_SHEET_VERTICAL_FRAMES = 38;

    public static void UpdateAll()
    {
      lock (EmoteBubble.byID)
      {
        EmoteBubble.toClean.Clear();
        foreach (KeyValuePair<int, EmoteBubble> keyValuePair in EmoteBubble.byID)
        {
          keyValuePair.Value.Update();
          if (keyValuePair.Value.lifeTime <= 0)
            EmoteBubble.toClean.Add(keyValuePair.Key);
        }
        foreach (int key in EmoteBubble.toClean)
          EmoteBubble.byID.Remove(key);
        EmoteBubble.toClean.Clear();
      }
    }

    public static void DrawAll(SpriteBatch sb)
    {
      lock (EmoteBubble.byID)
      {
        foreach (KeyValuePair<int, EmoteBubble> keyValuePair in EmoteBubble.byID)
          keyValuePair.Value.Draw(sb);
      }
    }

    public static Tuple<int, int> SerializeNetAnchor(WorldUIAnchor anch)
    {
      if (anch.type != WorldUIAnchor.AnchorType.Entity)
        return Tuple.Create<int, int>(0, 0);
      int num = 0;
      if (anch.entity is NPC)
        num = 0;
      else if (anch.entity is Player)
        num = 1;
      else if (anch.entity is Projectile)
        num = 2;
      return Tuple.Create<int, int>(num, anch.entity.whoAmI);
    }

    public static WorldUIAnchor DeserializeNetAnchor(int type, int meta)
    {
      if (type == 0)
        return new WorldUIAnchor((Entity) Main.npc[meta]);
      if (type == 1)
        return new WorldUIAnchor((Entity) Main.player[meta]);
      if (type == 2)
        return new WorldUIAnchor((Entity) Main.projectile[meta]);
      throw new Exception("How did you end up getting this?");
    }

    public static int AssignNewID() => EmoteBubble.NextID++;

    public static int NewBubble(int emoticon, WorldUIAnchor bubbleAnchor, int time)
    {
      EmoteBubble emoteBubble = new EmoteBubble(emoticon, bubbleAnchor, time)
      {
        ID = EmoteBubble.AssignNewID()
      };
      EmoteBubble.byID[emoteBubble.ID] = emoteBubble;
      if (Main.netMode == 2)
      {
        Tuple<int, int> tuple = EmoteBubble.SerializeNetAnchor(bubbleAnchor);
        NetMessage.SendData(91, number: emoteBubble.ID, number2: ((float) tuple.Item1), number3: ((float) tuple.Item2), number4: ((float) time), number5: emoticon);
      }
      EmoteBubble.OnBubbleChange(emoteBubble.ID);
      return emoteBubble.ID;
    }

    public static int NewBubbleNPC(WorldUIAnchor bubbleAnchor, int time, WorldUIAnchor other = null)
    {
      EmoteBubble emoteBubble = new EmoteBubble(0, bubbleAnchor, time)
      {
        ID = EmoteBubble.AssignNewID()
      };
      EmoteBubble.byID[emoteBubble.ID] = emoteBubble;
      emoteBubble.PickNPCEmote(other);
      if (Main.netMode == 2)
      {
        Tuple<int, int> tuple = EmoteBubble.SerializeNetAnchor(bubbleAnchor);
        NetMessage.SendData(91, number: emoteBubble.ID, number2: ((float) tuple.Item1), number3: ((float) tuple.Item2), number4: ((float) time), number5: emoteBubble.emote, number6: emoteBubble.metadata);
      }
      return emoteBubble.ID;
    }

    public static void CheckForNPCsToReactToEmoteBubble(int emoteID, Player player)
    {
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc != null && npc.active && npc.aiStyle == 7 && npc.townNPC && (double) npc.ai[0] < 2.0 && (player.CanBeTalkedTo && (double) player.Distance(npc.Center) < 200.0 || !Collision.CanHitLine(npc.Top, 0, 0, player.Top, 0, 0)))
        {
          int directionInt = ((double) npc.position.X < (double) player.position.X).ToDirectionInt();
          npc.ai[0] = 19f;
          npc.ai[1] = 220f;
          npc.ai[2] = (float) player.whoAmI;
          npc.direction = directionInt;
          npc.netUpdate = true;
        }
      }
    }

    public EmoteBubble(int emotion, WorldUIAnchor bubbleAnchor, int time = 180)
    {
      this.anchor = bubbleAnchor;
      this.emote = emotion;
      this.lifeTime = time;
      this.lifeTimeStart = time;
    }

    private void Update()
    {
      if (--this.lifeTime <= 0 || ++this.frameCounter < 8)
        return;
      this.frameCounter = 0;
      if (++this.frame < 2)
        return;
      this.frame = 0;
    }

    private void Draw(SpriteBatch sb)
    {
      Texture2D texture2D = TextureAssets.Extra[48].Value;
      SpriteEffects effect = SpriteEffects.None;
      Vector2 vector2 = this.GetPosition(out effect).Floor();
      bool flag = this.lifeTime < 6 || this.lifeTimeStart - this.lifeTime < 6;
      Rectangle rectangle = texture2D.Frame(8, 38, flag ? 0 : 1);
      Vector2 origin = new Vector2((float) (rectangle.Width / 2), (float) rectangle.Height);
      if ((double) Main.player[Main.myPlayer].gravDir == -1.0)
      {
        origin.Y = 0.0f;
        effect |= SpriteEffects.FlipVertically;
        vector2 = Main.ReverseGravitySupport(vector2);
      }
      sb.Draw(texture2D, vector2, new Rectangle?(rectangle), Color.White, 0.0f, origin, 1f, effect, 0.0f);
      if (flag)
        return;
      if (this.emote >= 0)
      {
        if ((this.emote == 87 || this.emote == 89) && effect.HasFlag((Enum) SpriteEffects.FlipHorizontally))
        {
          effect &= ~SpriteEffects.FlipHorizontally;
          vector2.X += 4f;
        }
        sb.Draw(texture2D, vector2, new Rectangle?(texture2D.Frame(8, 38, this.emote * 2 % 8 + this.frame, 1 + this.emote / 4)), Color.White, 0.0f, origin, 1f, effect, 0.0f);
      }
      else
      {
        if (this.emote != -1)
          return;
        Texture2D texture = TextureAssets.NpcHead[this.metadata].Value;
        float scale = 1f;
        if ((double) texture.Width / 22.0 > 1.0)
          scale = 22f / (float) texture.Width;
        if ((double) texture.Height / 16.0 > 1.0 / (double) scale)
          scale = 16f / (float) texture.Height;
        sb.Draw(texture, vector2 + new Vector2(effect.HasFlag((Enum) SpriteEffects.FlipHorizontally) ? 1f : -1f, (float) (-rectangle.Height + 3)), new Rectangle?(), Color.White, 0.0f, new Vector2((float) (texture.Width / 2), 0.0f), scale, effect, 0.0f);
      }
    }

    private Vector2 GetPosition(out SpriteEffects effect)
    {
      switch (this.anchor.type)
      {
        case WorldUIAnchor.AnchorType.Entity:
          effect = this.anchor.entity.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
          return new Vector2(this.anchor.entity.Top.X, this.anchor.entity.VisualPosition.Y) + new Vector2((float) (-this.anchor.entity.direction * this.anchor.entity.width) * 0.75f, 2f) - Main.screenPosition;
        case WorldUIAnchor.AnchorType.Tile:
          effect = SpriteEffects.None;
          return this.anchor.pos - Main.screenPosition + new Vector2(0.0f, (float) (-(double) this.anchor.size.Y / 2.0));
        case WorldUIAnchor.AnchorType.Pos:
          effect = SpriteEffects.None;
          return this.anchor.pos - Main.screenPosition;
        default:
          effect = SpriteEffects.None;
          return new Vector2((float) Main.screenWidth, (float) Main.screenHeight) / 2f;
      }
    }

    public static void OnBubbleChange(int bubbleID)
    {
      EmoteBubble emoteBubble1 = EmoteBubble.byID[bubbleID];
      if (emoteBubble1.anchor.type != WorldUIAnchor.AnchorType.Entity || !(emoteBubble1.anchor.entity is Player entity))
        return;
      foreach (EmoteBubble emoteBubble2 in EmoteBubble.byID.Values)
      {
        if (emoteBubble2.anchor.type == WorldUIAnchor.AnchorType.Entity && emoteBubble2.anchor.entity == entity && emoteBubble2.ID != bubbleID)
          emoteBubble2.lifeTime = 6;
      }
    }

    public void PickNPCEmote(WorldUIAnchor other = null)
    {
      Player plr = Main.player[(int) Player.FindClosest(this.anchor.entity.Center, 0, 0)];
      List<int> list = new List<int>();
      bool flag = false;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].boss)
          flag = true;
      }
      if (!flag)
      {
        if (Main.rand.Next(3) == 0)
          this.ProbeTownNPCs(list);
        if (Main.rand.Next(3) == 0)
          this.ProbeEmotions(list);
        if (Main.rand.Next(3) == 0)
          this.ProbeBiomes(list, plr);
        if (Main.rand.Next(2) == 0)
          this.ProbeCritters(list);
        if (Main.rand.Next(2) == 0)
          this.ProbeItems(list, plr);
        if (Main.rand.Next(5) == 0)
          this.ProbeBosses(list);
        if (Main.rand.Next(2) == 0)
          this.ProbeDebuffs(list, plr);
        if (Main.rand.Next(2) == 0)
          this.ProbeEvents(list);
        if (Main.rand.Next(2) == 0)
          this.ProbeWeather(list, plr);
        this.ProbeExceptions(list, plr, other);
      }
      else
        this.ProbeCombat(list);
      if (list.Count <= 0)
        return;
      this.emote = list[Main.rand.Next(list.Count)];
    }

    private void ProbeCombat(List<int> list)
    {
      list.Add(16);
      list.Add(1);
      list.Add(2);
      list.Add(91);
      list.Add(93);
      list.Add(84);
      list.Add(84);
    }

    private void ProbeWeather(List<int> list, Player plr)
    {
      if ((double) Main.cloudBGActive > 0.0)
        list.Add(96);
      if ((double) Main.cloudAlpha > 0.0)
      {
        if (!Main.dayTime)
          list.Add(5);
        list.Add(4);
        if (plr.ZoneSnow)
          list.Add(98);
        if ((double) plr.position.X < 4000.0 || (double) plr.position.X > (double) (Main.maxTilesX * 16 - 4000) && (double) plr.position.Y < Main.worldSurface / 16.0)
          list.Add(97);
      }
      else
        list.Add(95);
      if (!plr.ZoneHallow)
        return;
      list.Add(6);
    }

    private void ProbeEvents(List<int> list)
    {
      if (BirthdayParty.PartyIsUp && Main.rand.Next(3) == 0)
        list.Add(Utils.SelectRandom<int>(Main.rand, (int) sbyte.MaxValue, 128, 129, 126));
      if (Main.bloodMoon || !Main.dayTime && Main.rand.Next(4) == 0)
        list.Add(18);
      if (Main.eclipse || Main.hardMode && Main.rand.Next(4) == 0)
        list.Add(19);
      if ((!Main.dayTime || WorldGen.spawnMeteor) && NPC.downedBoss2)
        list.Add(99);
      if (Main.pumpkinMoon || (NPC.downedHalloweenKing || NPC.downedHalloweenTree) && !Main.dayTime)
        list.Add(20);
      if (Main.snowMoon || (NPC.downedChristmasIceQueen || NPC.downedChristmasSantank || NPC.downedChristmasTree) && !Main.dayTime)
        list.Add(21);
      if (!DD2Event.Ongoing && !DD2Event.DownedInvasionAnyDifficulty)
        return;
      list.Add(133);
    }

    private void ProbeDebuffs(List<int> list, Player plr)
    {
      if ((double) plr.Center.Y > (double) (Main.maxTilesY * 16 - 3200) || plr.onFire || ((NPC) this.anchor.entity).onFire || plr.onFire2)
        list.Add(9);
      if (Main.rand.Next(2) == 0)
        list.Add(11);
      if (plr.poisoned || ((NPC) this.anchor.entity).poisoned || plr.ZoneJungle)
        list.Add(8);
      if (plr.inventory[plr.selectedItem].type != 215 && Main.rand.Next(3) != 0)
        return;
      list.Add(10);
    }

    private void ProbeItems(List<int> list, Player plr)
    {
      list.Add(7);
      list.Add(73);
      list.Add(74);
      list.Add(75);
      list.Add(78);
      list.Add(90);
      if (plr.statLife >= plr.statLifeMax2 / 2)
        return;
      list.Add(84);
    }

    private void ProbeTownNPCs(List<int> list)
    {
      for (int index = 0; index < 663; ++index)
        EmoteBubble.CountNPCs[index] = 0;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active)
          ++EmoteBubble.CountNPCs[Main.npc[index].type];
      }
      int type = ((NPC) this.anchor.entity).type;
      for (int index = 0; index < 663; ++index)
      {
        if (NPCID.Sets.FaceEmote[index] > 0 && EmoteBubble.CountNPCs[index] > 0 && index != type)
          list.Add(NPCID.Sets.FaceEmote[index]);
      }
    }

    private void ProbeBiomes(List<int> list, Player plr)
    {
      if ((double) plr.position.Y / 16.0 < Main.worldSurface * 0.45)
        list.Add(22);
      else if ((double) plr.position.Y / 16.0 > Main.rockLayer + (double) (Main.maxTilesY / 2) - 100.0)
        list.Add(31);
      else if ((double) plr.position.Y / 16.0 > Main.rockLayer)
        list.Add(30);
      else if (plr.ZoneHallow)
        list.Add(27);
      else if (plr.ZoneCorrupt)
        list.Add(26);
      else if (plr.ZoneCrimson)
        list.Add(25);
      else if (plr.ZoneJungle)
        list.Add(24);
      else if (plr.ZoneSnow)
        list.Add(32);
      else if ((double) plr.position.Y / 16.0 < Main.worldSurface && ((double) plr.position.X < 4000.0 || (double) plr.position.X > (double) (16 * (Main.maxTilesX - 250))))
        list.Add(29);
      else if (plr.ZoneDesert)
        list.Add(28);
      else
        list.Add(23);
    }

    private void ProbeCritters(List<int> list)
    {
      Vector2 center = this.anchor.entity.Center;
      float num1 = 1f;
      float num2 = 1f;
      if ((double) center.Y < Main.rockLayer * 16.0)
        num2 = 0.2f;
      else
        num1 = 0.2f;
      if ((double) Main.rand.NextFloat() <= (double) num1)
      {
        if (Main.dayTime)
        {
          list.Add(13);
          list.Add(12);
          list.Add(68);
          list.Add(62);
          list.Add(63);
          list.Add(69);
          list.Add(70);
        }
        if (!Main.dayTime || Main.dayTime && (Main.time < 5400.0 || Main.time > 48600.0))
          list.Add(61);
        if (NPC.downedGoblins)
          list.Add(64);
        if (NPC.downedFrost)
          list.Add(66);
        if (NPC.downedPirates)
          list.Add(65);
        if (NPC.downedMartians)
          list.Add(71);
        if (WorldGen.crimson)
          list.Add(67);
      }
      if ((double) Main.rand.NextFloat() > (double) num2)
        return;
      list.Add(72);
      list.Add(69);
    }

    private void ProbeEmotions(List<int> list)
    {
      list.Add(0);
      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(15);
      list.Add(16);
      list.Add(17);
      list.Add(87);
      list.Add(91);
      list.Add(136);
      list.Add(134);
      list.Add(135);
      list.Add(137);
      list.Add(138);
      list.Add(139);
      if (!Main.bloodMoon || Main.dayTime)
        return;
      int num = Utils.SelectRandom<int>(Main.rand, 16, 1, 138);
      list.Add(num);
      list.Add(num);
      list.Add(num);
    }

    private void ProbeBosses(List<int> list)
    {
      int num = 0;
      if (!NPC.downedBoss1 && !Main.dayTime || NPC.downedBoss1)
        num = 1;
      if (NPC.downedBoss2)
        num = 2;
      if (NPC.downedQueenBee || NPC.downedBoss3)
        num = 3;
      if (Main.hardMode)
        num = 4;
      if (NPC.downedMechBossAny)
        num = 5;
      if (NPC.downedPlantBoss)
        num = 6;
      if (NPC.downedGolemBoss)
        num = 7;
      if (NPC.downedAncientCultist)
        num = 8;
      int maxValue = 10;
      if (NPC.downedMoonlord)
        maxValue = 1;
      if (num >= 1 && num <= 2 || num >= 1 && Main.rand.Next(maxValue) == 0)
      {
        list.Add(39);
        if (WorldGen.crimson)
          list.Add(41);
        else
          list.Add(40);
        list.Add(51);
      }
      if (num >= 2 && num <= 3 || num >= 2 && Main.rand.Next(maxValue) == 0)
      {
        list.Add(43);
        list.Add(42);
      }
      if (num >= 4 && num <= 5 || num >= 4 && Main.rand.Next(maxValue) == 0)
      {
        list.Add(44);
        list.Add(47);
        list.Add(45);
        list.Add(46);
      }
      if (num >= 5 && num <= 6 || num >= 5 && Main.rand.Next(maxValue) == 0)
      {
        if (!NPC.downedMechBoss1)
          list.Add(47);
        if (!NPC.downedMechBoss2)
          list.Add(45);
        if (!NPC.downedMechBoss3)
          list.Add(46);
        list.Add(48);
      }
      if (num == 6 || num >= 6 && Main.rand.Next(maxValue) == 0)
      {
        list.Add(48);
        list.Add(49);
        list.Add(50);
      }
      if (num == 7 || num >= 7 && Main.rand.Next(maxValue) == 0)
      {
        list.Add(49);
        list.Add(50);
        list.Add(52);
      }
      if (num == 8 || num >= 8 && Main.rand.Next(maxValue) == 0)
      {
        list.Add(52);
        list.Add(53);
      }
      if (NPC.downedPirates && Main.expertMode)
        list.Add(59);
      if (NPC.downedMartians)
        list.Add(60);
      if (NPC.downedChristmasIceQueen)
        list.Add(57);
      if (NPC.downedChristmasSantank)
        list.Add(58);
      if (NPC.downedChristmasTree)
        list.Add(56);
      if (NPC.downedHalloweenKing)
        list.Add(55);
      if (NPC.downedHalloweenTree)
        list.Add(54);
      if (NPC.downedEmpressOfLight)
        list.Add(143);
      if (!NPC.downedQueenSlime)
        return;
      list.Add(144);
    }

    private void ProbeExceptions(List<int> list, Player plr, WorldUIAnchor other)
    {
      NPC entity = (NPC) this.anchor.entity;
      if (entity.type == 17)
      {
        list.Add(80);
        list.Add(85);
        list.Add(85);
        list.Add(85);
        list.Add(85);
      }
      else if (entity.type == 18)
      {
        list.Add(73);
        list.Add(73);
        list.Add(84);
        list.Add(75);
      }
      else if (entity.type == 19)
      {
        if (other != null && ((NPC) other.entity).type == 22)
        {
          list.Add(1);
          list.Add(1);
          list.Add(93);
          list.Add(92);
        }
        else if (other != null && ((NPC) other.entity).type == 22)
        {
          list.Add(1);
          list.Add(1);
          list.Add(93);
          list.Add(92);
        }
        else
        {
          list.Add(82);
          list.Add(82);
          list.Add(85);
          list.Add(85);
          list.Add(77);
          list.Add(93);
        }
      }
      else if (entity.type == 20)
      {
        if (list.Contains(121))
        {
          list.Add(121);
          list.Add(121);
        }
        list.Add(14);
        list.Add(14);
      }
      else if (entity.type == 22)
      {
        if (!Main.bloodMoon)
        {
          if (other != null && ((NPC) other.entity).type == 19)
          {
            list.Add(1);
            list.Add(1);
            list.Add(93);
            list.Add(92);
          }
          else
            list.Add(79);
        }
        if (!Main.dayTime)
        {
          list.Add(16);
          list.Add(16);
          list.Add(16);
        }
      }
      else if (entity.type == 37)
      {
        list.Add(43);
        list.Add(43);
        list.Add(43);
        list.Add(72);
        list.Add(72);
      }
      else if (entity.type == 38)
      {
        if (Main.bloodMoon)
        {
          list.Add(77);
          list.Add(77);
          list.Add(77);
          list.Add(81);
        }
        else
        {
          list.Add(77);
          list.Add(77);
          list.Add(81);
          list.Add(81);
          list.Add(81);
          list.Add(90);
          list.Add(90);
        }
      }
      else if (entity.type == 54)
      {
        if (Main.bloodMoon)
        {
          list.Add(43);
          list.Add(72);
          list.Add(1);
        }
        else
        {
          if (list.Contains(111))
            list.Add(111);
          list.Add(17);
        }
      }
      else if (entity.type == 107)
      {
        if (other != null && ((NPC) other.entity).type == 124)
        {
          list.Remove(111);
          list.Add(0);
          list.Add(0);
          list.Add(0);
          list.Add(17);
          list.Add(17);
          list.Add(86);
          list.Add(88);
          list.Add(88);
        }
        else
        {
          if (list.Contains(111))
          {
            list.Add(111);
            list.Add(111);
            list.Add(111);
          }
          list.Add(91);
          list.Add(92);
          list.Add(91);
          list.Add(92);
        }
      }
      else if (entity.type == 108)
      {
        list.Add(100);
        list.Add(89);
        list.Add(11);
      }
      if (entity.type == 124)
      {
        if (other != null && ((NPC) other.entity).type == 107)
        {
          list.Remove(111);
          list.Add(0);
          list.Add(0);
          list.Add(0);
          list.Add(17);
          list.Add(17);
          list.Add(88);
          list.Add(88);
        }
        else
        {
          if (list.Contains(109))
          {
            list.Add(109);
            list.Add(109);
            list.Add(109);
          }
          if (list.Contains(108))
          {
            list.Remove(108);
            if (Main.hardMode)
            {
              list.Add(108);
              list.Add(108);
            }
            else
            {
              list.Add(106);
              list.Add(106);
            }
          }
          list.Add(43);
          list.Add(2);
        }
      }
      else if (entity.type == 142)
      {
        list.Add(32);
        list.Add(66);
        list.Add(17);
        list.Add(15);
        list.Add(15);
      }
      else if (entity.type == 160)
      {
        list.Add(10);
        list.Add(89);
        list.Add(94);
        list.Add(8);
      }
      else if (entity.type == 178)
      {
        list.Add(83);
        list.Add(83);
      }
      else if (entity.type == 207)
      {
        list.Add(28);
        list.Add(95);
        list.Add(93);
      }
      else if (entity.type == 208)
      {
        list.Add(94);
        list.Add(17);
        list.Add(3);
        list.Add(77);
      }
      else if (entity.type == 209)
      {
        list.Add(48);
        list.Add(83);
        list.Add(5);
        list.Add(5);
      }
      else if (entity.type == 227)
      {
        list.Add(63);
        list.Add(68);
      }
      else if (entity.type == 228)
      {
        list.Add(24);
        list.Add(24);
        list.Add(95);
        list.Add(8);
      }
      else if (entity.type == 229)
      {
        list.Add(93);
        list.Add(9);
        list.Add(65);
        list.Add(120);
        list.Add(59);
      }
      else if (entity.type == 353)
      {
        if (list.Contains(104))
        {
          list.Add(104);
          list.Add(104);
        }
        if (list.Contains(111))
        {
          list.Add(111);
          list.Add(111);
        }
        list.Add(67);
      }
      else if (entity.type == 368)
      {
        list.Add(85);
        list.Add(7);
        list.Add(79);
      }
      else if (entity.type == 369)
      {
        if (Main.bloodMoon)
          return;
        list.Add(70);
        list.Add(70);
        list.Add(76);
        list.Add(76);
        list.Add(79);
        list.Add(79);
        if ((double) entity.position.Y >= Main.worldSurface)
          return;
        list.Add(29);
      }
      else if (entity.type == 453)
      {
        list.Add(72);
        list.Add(69);
        list.Add(87);
        list.Add(3);
      }
      else
      {
        if (entity.type != 441)
          return;
        list.Add(100);
        list.Add(100);
        list.Add(1);
        list.Add(1);
        list.Add(1);
        list.Add(87);
      }
    }
  }
}
