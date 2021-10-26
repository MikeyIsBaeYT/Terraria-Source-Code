// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.HorizontalBarsPlayerReosurcesDisplaySet
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;

namespace Terraria.GameContent.UI
{
  public class HorizontalBarsPlayerReosurcesDisplaySet : IPlayerResourcesDisplaySet
  {
    private int _maxSegmentCount;
    private int _hpSegmentsCount;
    private int _mpSegmentsCount;
    private int _hpFruitCount;
    private float _hpPercent;
    private float _mpPercent;
    private bool _hpHovered;
    private bool _mpHovered;
    private Asset<Texture2D> _hpFill;
    private Asset<Texture2D> _hpFillHoney;
    private Asset<Texture2D> _mpFill;
    private Asset<Texture2D> _panelLeft;
    private Asset<Texture2D> _panelMiddleHP;
    private Asset<Texture2D> _panelRightHP;
    private Asset<Texture2D> _panelMiddleMP;
    private Asset<Texture2D> _panelRightMP;

    public HorizontalBarsPlayerReosurcesDisplaySet(string name, AssetRequestMode mode)
    {
      string str = "Images\\UI\\PlayerResourceSets\\" + name;
      this._hpFill = Main.Assets.Request<Texture2D>(str + "\\HP_Fill", mode);
      this._hpFillHoney = Main.Assets.Request<Texture2D>(str + "\\HP_Fill_Honey", mode);
      this._mpFill = Main.Assets.Request<Texture2D>(str + "\\MP_Fill", mode);
      this._panelLeft = Main.Assets.Request<Texture2D>(str + "\\Panel_Left", mode);
      this._panelMiddleHP = Main.Assets.Request<Texture2D>(str + "\\HP_Panel_Middle", mode);
      this._panelRightHP = Main.Assets.Request<Texture2D>(str + "\\HP_Panel_Right", mode);
      this._panelMiddleMP = Main.Assets.Request<Texture2D>(str + "\\MP_Panel_Middle", mode);
      this._panelRightMP = Main.Assets.Request<Texture2D>(str + "\\MP_Panel_Right", mode);
    }

    public void Draw()
    {
      this.PrepareFields(Main.LocalPlayer);
      SpriteBatch spriteBatch = Main.spriteBatch;
      int num1 = 16;
      int num2 = 18;
      int num3 = Main.screenWidth - 300 - 22 + num1;
      Vector2 vector2_1 = new Vector2((float) num3, (float) num2);
      vector2_1.X += (float) ((this._maxSegmentCount - this._hpSegmentsCount) * this._panelMiddleHP.Width());
      bool isHovered1 = false;
      new ResourceDrawSettings()
      {
        ElementCount = (this._hpSegmentsCount + 2),
        ElementIndexOffset = 0,
        TopLeftAnchor = vector2_1,
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.LifePanelDrawer),
        OffsetPerDraw = Vector2.Zero,
        OffsetPerDrawByTexturePercentile = Vector2.UnitX,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered1);
      new ResourceDrawSettings()
      {
        ElementCount = this._hpSegmentsCount,
        ElementIndexOffset = 0,
        TopLeftAnchor = (vector2_1 + new Vector2(6f, 6f)),
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.LifeFillingDrawer),
        OffsetPerDraw = new Vector2((float) this._hpFill.Width(), 0.0f),
        OffsetPerDrawByTexturePercentile = Vector2.Zero,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered1);
      this._hpHovered = isHovered1;
      bool isHovered2 = false;
      Vector2 vector2_2 = new Vector2((float) (num3 - 10), (float) (num2 + 24));
      vector2_2.X += (float) ((this._maxSegmentCount - this._mpSegmentsCount) * this._panelMiddleMP.Width());
      new ResourceDrawSettings()
      {
        ElementCount = (this._mpSegmentsCount + 2),
        ElementIndexOffset = 0,
        TopLeftAnchor = vector2_2,
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.ManaPanelDrawer),
        OffsetPerDraw = Vector2.Zero,
        OffsetPerDrawByTexturePercentile = Vector2.UnitX,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered2);
      new ResourceDrawSettings()
      {
        ElementCount = this._mpSegmentsCount,
        ElementIndexOffset = 0,
        TopLeftAnchor = (vector2_2 + new Vector2(6f, 6f)),
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.ManaFillingDrawer),
        OffsetPerDraw = new Vector2((float) this._mpFill.Width(), 0.0f),
        OffsetPerDrawByTexturePercentile = Vector2.Zero,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered2);
      this._mpHovered = isHovered2;
    }

    private static void DrawManaText(SpriteBatch spriteBatch)
    {
      Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      int num = 180;
      Player localPlayer = Main.LocalPlayer;
      string str1 = Lang.inter[2].Value + ":";
      string str2 = localPlayer.statMana.ToString() + "/" + (object) localPlayer.statManaMax2;
      Vector2 vector2_1 = new Vector2((float) (Main.screenWidth - num), 65f);
      string str3 = str1 + " " + str2;
      Vector2 vector2_2 = FontAssets.MouseText.Value.MeasureString(str3);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str1, vector2_1 + new Vector2((float) (-(double) vector2_2.X * 0.5), 0.0f), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, str2, vector2_1 + new Vector2(vector2_2.X * 0.5f, 0.0f), color, 0.0f, new Vector2(FontAssets.MouseText.Value.MeasureString(str2).X, 0.0f), 1f, SpriteEffects.None, 0.0f);
    }

    private static void DrawLifeBarText(SpriteBatch spriteBatch, Vector2 topLeftAnchor)
    {
      Vector2 vector2_1 = topLeftAnchor + new Vector2(130f, -20f);
      Player localPlayer = Main.LocalPlayer;
      Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      string str = Lang.inter[0].Value + " " + (object) localPlayer.statLifeMax2 + "/" + (object) localPlayer.statLifeMax2;
      Vector2 vector2_2 = FontAssets.MouseText.Value.MeasureString(str);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, Lang.inter[0].Value, vector2_1 + new Vector2((float) (-(double) vector2_2.X * 0.5), 0.0f), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2, vector2_1 + new Vector2(vector2_2.X * 0.5f, 0.0f), color, 0.0f, new Vector2(FontAssets.MouseText.Value.MeasureString(localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2).X, 0.0f), 1f, SpriteEffects.None, 0.0f);
    }

    private void PrepareFields(Player player)
    {
      PlayerStatsSnapshot playerStatsSnapshot = new PlayerStatsSnapshot(player);
      this._hpSegmentsCount = (int) ((double) playerStatsSnapshot.LifeMax / (double) playerStatsSnapshot.LifePerSegment);
      this._mpSegmentsCount = (int) ((double) playerStatsSnapshot.ManaMax / (double) playerStatsSnapshot.ManaPerSegment);
      this._maxSegmentCount = 20;
      this._hpFruitCount = playerStatsSnapshot.LifeFruitCount;
      this._hpPercent = (float) playerStatsSnapshot.Life / (float) playerStatsSnapshot.LifeMax;
      this._mpPercent = (float) playerStatsSnapshot.Mana / (float) playerStatsSnapshot.ManaMax;
    }

    private void LifePanelDrawer(
      int elementIndex,
      int firstElementIndex,
      int lastElementIndex,
      out Asset<Texture2D> sprite,
      out Vector2 offset,
      out float drawScale,
      out Rectangle? sourceRect)
    {
      sourceRect = new Rectangle?();
      offset = Vector2.Zero;
      sprite = this._panelLeft;
      drawScale = 1f;
      if (elementIndex == lastElementIndex)
      {
        sprite = this._panelRightHP;
        offset = new Vector2(-16f, -10f);
      }
      else
      {
        if (elementIndex == firstElementIndex)
          return;
        sprite = this._panelMiddleHP;
      }
    }

    private void ManaPanelDrawer(
      int elementIndex,
      int firstElementIndex,
      int lastElementIndex,
      out Asset<Texture2D> sprite,
      out Vector2 offset,
      out float drawScale,
      out Rectangle? sourceRect)
    {
      sourceRect = new Rectangle?();
      offset = Vector2.Zero;
      sprite = this._panelLeft;
      drawScale = 1f;
      if (elementIndex == lastElementIndex)
      {
        sprite = this._panelRightMP;
        offset = new Vector2(-16f, -6f);
      }
      else
      {
        if (elementIndex == firstElementIndex)
          return;
        sprite = this._panelMiddleMP;
      }
    }

    private void LifeFillingDrawer(
      int elementIndex,
      int firstElementIndex,
      int lastElementIndex,
      out Asset<Texture2D> sprite,
      out Vector2 offset,
      out float drawScale,
      out Rectangle? sourceRect)
    {
      sprite = this._hpFill;
      if (elementIndex >= this._hpSegmentsCount - this._hpFruitCount)
        sprite = this._hpFillHoney;
      HorizontalBarsPlayerReosurcesDisplaySet.FillBarByValues(elementIndex, sprite, this._hpSegmentsCount, this._hpPercent, out offset, out drawScale, out sourceRect);
    }

    private static void FillBarByValues(
      int elementIndex,
      Asset<Texture2D> sprite,
      int segmentsCount,
      float fillPercent,
      out Vector2 offset,
      out float drawScale,
      out Rectangle? sourceRect)
    {
      sourceRect = new Rectangle?();
      offset = Vector2.Zero;
      int num1 = elementIndex;
      float num2 = 1f / (float) segmentsCount;
      float t = 1f - fillPercent;
      float num3 = 1f - Utils.GetLerpValue(num2 * (float) num1, num2 * (float) (num1 + 1), t, true);
      drawScale = 1f;
      Rectangle rectangle = sprite.Frame();
      int num4 = (int) ((double) rectangle.Width * (1.0 - (double) num3));
      offset.X += (float) num4;
      rectangle.X += num4;
      rectangle.Width -= num4;
      sourceRect = new Rectangle?(rectangle);
    }

    private void ManaFillingDrawer(
      int elementIndex,
      int firstElementIndex,
      int lastElementIndex,
      out Asset<Texture2D> sprite,
      out Vector2 offset,
      out float drawScale,
      out Rectangle? sourceRect)
    {
      sprite = this._mpFill;
      HorizontalBarsPlayerReosurcesDisplaySet.FillBarByValues(elementIndex, sprite, this._mpSegmentsCount, this._mpPercent, out offset, out drawScale, out sourceRect);
    }

    public void TryToHover()
    {
      if (this._hpHovered)
        CommonResourceBarMethods.DrawLifeMouseOver();
      if (!this._mpHovered)
        return;
      CommonResourceBarMethods.DrawManaMouseOver();
    }
  }
}
