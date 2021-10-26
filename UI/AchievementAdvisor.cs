// Decompiled with JetBrains decompiler
// Type: Terraria.UI.AchievementAdvisor
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Achievements;
using Terraria.GameInput;

namespace Terraria.UI
{
  public class AchievementAdvisor
  {
    private List<AchievementAdvisorCard> _cards = new List<AchievementAdvisorCard>();
    private Asset<Texture2D> _achievementsTexture;
    private Asset<Texture2D> _achievementsBorderTexture;
    private Asset<Texture2D> _achievementsBorderMouseHoverFatTexture;
    private Asset<Texture2D> _achievementsBorderMouseHoverThinTexture;
    private AchievementAdvisorCard _hoveredCard;

    public bool CanDrawAboveCoins => Main.screenWidth >= 1000 && !PlayerInput.UsingGamepad;

    public void LoadContent()
    {
      this._achievementsTexture = Main.Assets.Request<Texture2D>("Images/UI/Achievements", (AssetRequestMode) 1);
      this._achievementsBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/Achievement_Borders", (AssetRequestMode) 1);
      this._achievementsBorderMouseHoverFatTexture = Main.Assets.Request<Texture2D>("Images/UI/Achievement_Borders_MouseHover", (AssetRequestMode) 1);
      this._achievementsBorderMouseHoverThinTexture = Main.Assets.Request<Texture2D>("Images/UI/Achievement_Borders_MouseHoverThin", (AssetRequestMode) 1);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    public void DrawOneAchievement(SpriteBatch spriteBatch, Vector2 position, bool large)
    {
      List<AchievementAdvisorCard> bestCards = this.GetBestCards(1);
      if (bestCards.Count < 1)
        return;
      AchievementAdvisorCard achievementAdvisorCard = bestCards[0];
      float scale = 0.35f;
      if (large)
        scale = 0.75f;
      this._hoveredCard = (AchievementAdvisorCard) null;
      bool hovered;
      this.DrawCard(bestCards[0], spriteBatch, position + new Vector2(8f) * scale, scale, out hovered);
      if (!hovered)
        return;
      this._hoveredCard = achievementAdvisorCard;
      if (PlayerInput.IgnoreMouseInterface)
        return;
      Main.player[Main.myPlayer].mouseInterface = true;
      if (!Main.mouseLeft || !Main.mouseLeftRelease)
        return;
      Main.ingameOptionsWindow = false;
      IngameFancyUI.OpenAchievementsAndGoto(this._hoveredCard.achievement);
    }

    public void Update() => this._hoveredCard = (AchievementAdvisorCard) null;

    public void DrawOptionsPanel(
      SpriteBatch spriteBatch,
      Vector2 leftPosition,
      Vector2 rightPosition)
    {
      List<AchievementAdvisorCard> bestCards = this.GetBestCards();
      this._hoveredCard = (AchievementAdvisorCard) null;
      int num = bestCards.Count;
      if (num > 5)
        num = 5;
      bool hovered;
      for (int index = 0; index < num; ++index)
      {
        this.DrawCard(bestCards[index], spriteBatch, leftPosition + new Vector2((float) (42 * index), 0.0f), 0.5f, out hovered);
        if (hovered)
          this._hoveredCard = bestCards[index];
      }
      for (int index = 5; index < bestCards.Count; ++index)
      {
        this.DrawCard(bestCards[index], spriteBatch, rightPosition + new Vector2((float) (42 * index), 0.0f), 0.5f, out hovered);
        if (hovered)
          this._hoveredCard = bestCards[index];
      }
      if (this._hoveredCard == null)
        return;
      if (this._hoveredCard.achievement.IsCompleted)
      {
        this._hoveredCard = (AchievementAdvisorCard) null;
      }
      else
      {
        if (PlayerInput.IgnoreMouseInterface)
          return;
        Main.player[Main.myPlayer].mouseInterface = true;
        if (!Main.mouseLeft || !Main.mouseLeftRelease)
          return;
        Main.ingameOptionsWindow = false;
        IngameFancyUI.OpenAchievementsAndGoto(this._hoveredCard.achievement);
      }
    }

    public void DrawMouseHover()
    {
      if (this._hoveredCard == null)
        return;
      Main.spriteBatch.End();
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, Main.UIScaleMatrix);
      PlayerInput.SetZoom_UI();
      Item obj = new Item();
      obj.SetDefaults(0, true);
      obj.SetNameOverride(this._hoveredCard.achievement.FriendlyName.Value);
      obj.ToolTip = ItemTooltip.FromLanguageKey(this._hoveredCard.achievement.Description.Key);
      obj.type = 1;
      obj.scale = 0.0f;
      obj.rare = 10;
      obj.value = -1;
      Main.HoverItem = obj;
      Main.instance.MouseText("");
      Main.mouseText = true;
    }

    private void DrawCard(
      AchievementAdvisorCard card,
      SpriteBatch spriteBatch,
      Vector2 position,
      float scale,
      out bool hovered)
    {
      hovered = false;
      if (Main.MouseScreen.Between(position, position + card.frame.Size() * scale))
      {
        Main.LocalPlayer.mouseInterface = true;
        hovered = true;
      }
      Color color = Color.White;
      if (!hovered)
        color = new Color(220, 220, 220, 220);
      Vector2 vector2_1 = new Vector2(-4f) * scale;
      Vector2 vector2_2 = new Vector2(-8f) * scale;
      Texture2D texture = this._achievementsBorderMouseHoverFatTexture.Value;
      if ((double) scale > 0.5)
      {
        texture = this._achievementsBorderMouseHoverThinTexture.Value;
        vector2_2 = new Vector2(-5f) * scale;
      }
      Rectangle frame = card.frame;
      frame.X += 528;
      spriteBatch.Draw(this._achievementsTexture.Value, position, new Rectangle?(frame), color, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
      spriteBatch.Draw(this._achievementsBorderTexture.Value, position + vector2_1, new Rectangle?(), color, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
      if (!hovered)
        return;
      spriteBatch.Draw(texture, position + vector2_2, new Rectangle?(), Main.OurFavoriteColor, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
    }

    private List<AchievementAdvisorCard> GetBestCards(int cardsAmount = 10)
    {
      List<AchievementAdvisorCard> achievementAdvisorCardList = new List<AchievementAdvisorCard>();
      for (int index = 0; index < this._cards.Count; ++index)
      {
        AchievementAdvisorCard card = this._cards[index];
        if (!card.achievement.IsCompleted && card.IsAchievableInWorld())
        {
          achievementAdvisorCardList.Add(card);
          if (achievementAdvisorCardList.Count >= cardsAmount)
            break;
        }
      }
      return achievementAdvisorCardList;
    }

    public void Initialize()
    {
      float num1 = 1f;
      List<AchievementAdvisorCard> cards1 = this._cards;
      Achievement achievement1 = Main.Achievements.GetAchievement("TIMBER");
      double num2 = (double) num1;
      float num3 = (float) (num2 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard1 = new AchievementAdvisorCard(achievement1, (float) num2);
      cards1.Add(achievementAdvisorCard1);
      List<AchievementAdvisorCard> cards2 = this._cards;
      Achievement achievement2 = Main.Achievements.GetAchievement("BENCHED");
      double num4 = (double) num3;
      float num5 = (float) (num4 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard2 = new AchievementAdvisorCard(achievement2, (float) num4);
      cards2.Add(achievementAdvisorCard2);
      List<AchievementAdvisorCard> cards3 = this._cards;
      Achievement achievement3 = Main.Achievements.GetAchievement("OBTAIN_HAMMER");
      double num6 = (double) num5;
      float num7 = (float) (num6 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard3 = new AchievementAdvisorCard(achievement3, (float) num6);
      cards3.Add(achievementAdvisorCard3);
      List<AchievementAdvisorCard> cards4 = this._cards;
      Achievement achievement4 = Main.Achievements.GetAchievement("NO_HOBO");
      double num8 = (double) num7;
      float num9 = (float) (num8 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard4 = new AchievementAdvisorCard(achievement4, (float) num8);
      cards4.Add(achievementAdvisorCard4);
      List<AchievementAdvisorCard> cards5 = this._cards;
      Achievement achievement5 = Main.Achievements.GetAchievement("YOU_CAN_DO_IT");
      double num10 = (double) num9;
      float num11 = (float) (num10 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard5 = new AchievementAdvisorCard(achievement5, (float) num10);
      cards5.Add(achievementAdvisorCard5);
      List<AchievementAdvisorCard> cards6 = this._cards;
      Achievement achievement6 = Main.Achievements.GetAchievement("OOO_SHINY");
      double num12 = (double) num11;
      float num13 = (float) (num12 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard6 = new AchievementAdvisorCard(achievement6, (float) num12);
      cards6.Add(achievementAdvisorCard6);
      List<AchievementAdvisorCard> cards7 = this._cards;
      Achievement achievement7 = Main.Achievements.GetAchievement("HEAVY_METAL");
      double num14 = (double) num13;
      float num15 = (float) (num14 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard7 = new AchievementAdvisorCard(achievement7, (float) num14);
      cards7.Add(achievementAdvisorCard7);
      List<AchievementAdvisorCard> cards8 = this._cards;
      Achievement achievement8 = Main.Achievements.GetAchievement("MATCHING_ATTIRE");
      double num16 = (double) num15;
      float num17 = (float) (num16 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard8 = new AchievementAdvisorCard(achievement8, (float) num16);
      cards8.Add(achievementAdvisorCard8);
      List<AchievementAdvisorCard> cards9 = this._cards;
      Achievement achievement9 = Main.Achievements.GetAchievement("HEART_BREAKER");
      double num18 = (double) num17;
      float num19 = (float) (num18 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard9 = new AchievementAdvisorCard(achievement9, (float) num18);
      cards9.Add(achievementAdvisorCard9);
      List<AchievementAdvisorCard> cards10 = this._cards;
      Achievement achievement10 = Main.Achievements.GetAchievement("I_AM_LOOT");
      double num20 = (double) num19;
      float num21 = (float) (num20 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard10 = new AchievementAdvisorCard(achievement10, (float) num20);
      cards10.Add(achievementAdvisorCard10);
      List<AchievementAdvisorCard> cards11 = this._cards;
      Achievement achievement11 = Main.Achievements.GetAchievement("HOLD_ON_TIGHT");
      double num22 = (double) num21;
      float num23 = (float) (num22 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard11 = new AchievementAdvisorCard(achievement11, (float) num22);
      cards11.Add(achievementAdvisorCard11);
      List<AchievementAdvisorCard> cards12 = this._cards;
      Achievement achievement12 = Main.Achievements.GetAchievement("STAR_POWER");
      double num24 = (double) num23;
      float num25 = (float) (num24 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard12 = new AchievementAdvisorCard(achievement12, (float) num24);
      cards12.Add(achievementAdvisorCard12);
      List<AchievementAdvisorCard> cards13 = this._cards;
      Achievement achievement13 = Main.Achievements.GetAchievement("EYE_ON_YOU");
      double num26 = (double) num25;
      float num27 = (float) (num26 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard13 = new AchievementAdvisorCard(achievement13, (float) num26);
      cards13.Add(achievementAdvisorCard13);
      List<AchievementAdvisorCard> cards14 = this._cards;
      Achievement achievement14 = Main.Achievements.GetAchievement("SMASHING_POPPET");
      double num28 = (double) num27;
      float num29 = (float) (num28 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard14 = new AchievementAdvisorCard(achievement14, (float) num28);
      cards14.Add(achievementAdvisorCard14);
      List<AchievementAdvisorCard> cards15 = this._cards;
      Achievement achievement15 = Main.Achievements.GetAchievement("WHERES_MY_HONEY");
      double num30 = (double) num29;
      float num31 = (float) (num30 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard15 = new AchievementAdvisorCard(achievement15, (float) num30);
      cards15.Add(achievementAdvisorCard15);
      List<AchievementAdvisorCard> cards16 = this._cards;
      Achievement achievement16 = Main.Achievements.GetAchievement("STING_OPERATION");
      double num32 = (double) num31;
      float num33 = (float) (num32 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard16 = new AchievementAdvisorCard(achievement16, (float) num32);
      cards16.Add(achievementAdvisorCard16);
      List<AchievementAdvisorCard> cards17 = this._cards;
      Achievement achievement17 = Main.Achievements.GetAchievement("BONED");
      double num34 = (double) num33;
      float num35 = (float) (num34 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard17 = new AchievementAdvisorCard(achievement17, (float) num34);
      cards17.Add(achievementAdvisorCard17);
      List<AchievementAdvisorCard> cards18 = this._cards;
      Achievement achievement18 = Main.Achievements.GetAchievement("DUNGEON_HEIST");
      double num36 = (double) num35;
      float num37 = (float) (num36 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard18 = new AchievementAdvisorCard(achievement18, (float) num36);
      cards18.Add(achievementAdvisorCard18);
      List<AchievementAdvisorCard> cards19 = this._cards;
      Achievement achievement19 = Main.Achievements.GetAchievement("ITS_GETTING_HOT_IN_HERE");
      double num38 = (double) num37;
      float num39 = (float) (num38 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard19 = new AchievementAdvisorCard(achievement19, (float) num38);
      cards19.Add(achievementAdvisorCard19);
      List<AchievementAdvisorCard> cards20 = this._cards;
      Achievement achievement20 = Main.Achievements.GetAchievement("MINER_FOR_FIRE");
      double num40 = (double) num39;
      float num41 = (float) (num40 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard20 = new AchievementAdvisorCard(achievement20, (float) num40);
      cards20.Add(achievementAdvisorCard20);
      List<AchievementAdvisorCard> cards21 = this._cards;
      Achievement achievement21 = Main.Achievements.GetAchievement("STILL_HUNGRY");
      double num42 = (double) num41;
      float num43 = (float) (num42 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard21 = new AchievementAdvisorCard(achievement21, (float) num42);
      cards21.Add(achievementAdvisorCard21);
      List<AchievementAdvisorCard> cards22 = this._cards;
      Achievement achievement22 = Main.Achievements.GetAchievement("ITS_HARD");
      double num44 = (double) num43;
      float num45 = (float) (num44 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard22 = new AchievementAdvisorCard(achievement22, (float) num44);
      cards22.Add(achievementAdvisorCard22);
      List<AchievementAdvisorCard> cards23 = this._cards;
      Achievement achievement23 = Main.Achievements.GetAchievement("BEGONE_EVIL");
      double num46 = (double) num45;
      float num47 = (float) (num46 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard23 = new AchievementAdvisorCard(achievement23, (float) num46);
      cards23.Add(achievementAdvisorCard23);
      List<AchievementAdvisorCard> cards24 = this._cards;
      Achievement achievement24 = Main.Achievements.GetAchievement("EXTRA_SHINY");
      double num48 = (double) num47;
      float num49 = (float) (num48 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard24 = new AchievementAdvisorCard(achievement24, (float) num48);
      cards24.Add(achievementAdvisorCard24);
      List<AchievementAdvisorCard> cards25 = this._cards;
      Achievement achievement25 = Main.Achievements.GetAchievement("HEAD_IN_THE_CLOUDS");
      double num50 = (double) num49;
      float num51 = (float) (num50 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard25 = new AchievementAdvisorCard(achievement25, (float) num50);
      cards25.Add(achievementAdvisorCard25);
      List<AchievementAdvisorCard> cards26 = this._cards;
      Achievement achievement26 = Main.Achievements.GetAchievement("BUCKETS_OF_BOLTS");
      double num52 = (double) num51;
      float num53 = (float) (num52 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard26 = new AchievementAdvisorCard(achievement26, (float) num52);
      cards26.Add(achievementAdvisorCard26);
      List<AchievementAdvisorCard> cards27 = this._cards;
      Achievement achievement27 = Main.Achievements.GetAchievement("DRAX_ATTAX");
      double num54 = (double) num53;
      float num55 = (float) (num54 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard27 = new AchievementAdvisorCard(achievement27, (float) num54);
      cards27.Add(achievementAdvisorCard27);
      List<AchievementAdvisorCard> cards28 = this._cards;
      Achievement achievement28 = Main.Achievements.GetAchievement("PHOTOSYNTHESIS");
      double num56 = (double) num55;
      float num57 = (float) (num56 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard28 = new AchievementAdvisorCard(achievement28, (float) num56);
      cards28.Add(achievementAdvisorCard28);
      List<AchievementAdvisorCard> cards29 = this._cards;
      Achievement achievement29 = Main.Achievements.GetAchievement("GET_A_LIFE");
      double num58 = (double) num57;
      float num59 = (float) (num58 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard29 = new AchievementAdvisorCard(achievement29, (float) num58);
      cards29.Add(achievementAdvisorCard29);
      List<AchievementAdvisorCard> cards30 = this._cards;
      Achievement achievement30 = Main.Achievements.GetAchievement("THE_GREAT_SOUTHERN_PLANTKILL");
      double num60 = (double) num59;
      float num61 = (float) (num60 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard30 = new AchievementAdvisorCard(achievement30, (float) num60);
      cards30.Add(achievementAdvisorCard30);
      List<AchievementAdvisorCard> cards31 = this._cards;
      Achievement achievement31 = Main.Achievements.GetAchievement("TEMPLE_RAIDER");
      double num62 = (double) num61;
      float num63 = (float) (num62 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard31 = new AchievementAdvisorCard(achievement31, (float) num62);
      cards31.Add(achievementAdvisorCard31);
      List<AchievementAdvisorCard> cards32 = this._cards;
      Achievement achievement32 = Main.Achievements.GetAchievement("LIHZAHRDIAN_IDOL");
      double num64 = (double) num63;
      float num65 = (float) (num64 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard32 = new AchievementAdvisorCard(achievement32, (float) num64);
      cards32.Add(achievementAdvisorCard32);
      List<AchievementAdvisorCard> cards33 = this._cards;
      Achievement achievement33 = Main.Achievements.GetAchievement("ROBBING_THE_GRAVE");
      double num66 = (double) num65;
      float num67 = (float) (num66 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard33 = new AchievementAdvisorCard(achievement33, (float) num66);
      cards33.Add(achievementAdvisorCard33);
      List<AchievementAdvisorCard> cards34 = this._cards;
      Achievement achievement34 = Main.Achievements.GetAchievement("OBSESSIVE_DEVOTION");
      double num68 = (double) num67;
      float num69 = (float) (num68 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard34 = new AchievementAdvisorCard(achievement34, (float) num68);
      cards34.Add(achievementAdvisorCard34);
      List<AchievementAdvisorCard> cards35 = this._cards;
      Achievement achievement35 = Main.Achievements.GetAchievement("STAR_DESTROYER");
      double num70 = (double) num69;
      float num71 = (float) (num70 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard35 = new AchievementAdvisorCard(achievement35, (float) num70);
      cards35.Add(achievementAdvisorCard35);
      List<AchievementAdvisorCard> cards36 = this._cards;
      Achievement achievement36 = Main.Achievements.GetAchievement("CHAMPION_OF_TERRARIA");
      double num72 = (double) num71;
      float num73 = (float) (num72 + 1.0);
      AchievementAdvisorCard achievementAdvisorCard36 = new AchievementAdvisorCard(achievement36, (float) num72);
      cards36.Add(achievementAdvisorCard36);
      this._cards.OrderBy<AchievementAdvisorCard, float>((Func<AchievementAdvisorCard, float>) (x => x.order));
    }
  }
}
