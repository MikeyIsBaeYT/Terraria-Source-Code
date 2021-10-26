// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.FancyClassicPlayerResourcesDisplaySet
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;

namespace Terraria.GameContent.UI
{
  public class FancyClassicPlayerResourcesDisplaySet : IPlayerResourcesDisplaySet
  {
    private float _currentPlayerLife;
    private float _lifePerHeart;
    private int _playerLifeFruitCount;
    private int _lastHeartFillingIndex;
    private int _lastHeartPanelIndex;
    private int _heartCountRow1;
    private int _heartCountRow2;
    private int _starCount;
    private int _lastStarFillingIndex;
    private float _manaPerStar;
    private float _currentPlayerMana;
    private Asset<Texture2D> _heartLeft;
    private Asset<Texture2D> _heartMiddle;
    private Asset<Texture2D> _heartRight;
    private Asset<Texture2D> _heartRightFancy;
    private Asset<Texture2D> _heartFill;
    private Asset<Texture2D> _heartFillHoney;
    private Asset<Texture2D> _heartSingleFancy;
    private Asset<Texture2D> _starTop;
    private Asset<Texture2D> _starMiddle;
    private Asset<Texture2D> _starBottom;
    private Asset<Texture2D> _starSingle;
    private Asset<Texture2D> _starFill;
    private bool _hoverLife;
    private bool _hoverMana;

    public FancyClassicPlayerResourcesDisplaySet(string name, AssetRequestMode mode)
    {
      string str = "Images\\UI\\PlayerResourceSets\\" + name;
      this._heartLeft = Main.Assets.Request<Texture2D>(str + "\\Heart_Left", mode);
      this._heartMiddle = Main.Assets.Request<Texture2D>(str + "\\Heart_Middle", mode);
      this._heartRight = Main.Assets.Request<Texture2D>(str + "\\Heart_Right", mode);
      this._heartRightFancy = Main.Assets.Request<Texture2D>(str + "\\Heart_Right_Fancy", mode);
      this._heartFill = Main.Assets.Request<Texture2D>(str + "\\Heart_Fill", mode);
      this._heartFillHoney = Main.Assets.Request<Texture2D>(str + "\\Heart_Fill_B", mode);
      this._heartSingleFancy = Main.Assets.Request<Texture2D>(str + "\\Heart_Single_Fancy", mode);
      this._starTop = Main.Assets.Request<Texture2D>(str + "\\Star_A", mode);
      this._starMiddle = Main.Assets.Request<Texture2D>(str + "\\Star_B", mode);
      this._starBottom = Main.Assets.Request<Texture2D>(str + "\\Star_C", mode);
      this._starSingle = Main.Assets.Request<Texture2D>(str + "\\Star_Single", mode);
      this._starFill = Main.Assets.Request<Texture2D>(str + "\\Star_Fill", mode);
    }

    public void Draw()
    {
      Player localPlayer = Main.LocalPlayer;
      SpriteBatch spriteBatch = Main.spriteBatch;
      this.PrepareFields(localPlayer);
      this.DrawLifeBar(spriteBatch);
      this.DrawManaBar(spriteBatch);
    }

    private void DrawLifeBar(SpriteBatch spriteBatch)
    {
      Vector2 vector2 = new Vector2((float) (Main.screenWidth - 300 + 4), 15f);
      bool isHovered = false;
      new ResourceDrawSettings()
      {
        ElementCount = this._heartCountRow1,
        ElementIndexOffset = 0,
        TopLeftAnchor = vector2,
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.HeartPanelDrawer),
        OffsetPerDraw = Vector2.Zero,
        OffsetPerDrawByTexturePercentile = Vector2.UnitX,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered);
      new ResourceDrawSettings()
      {
        ElementCount = this._heartCountRow2,
        ElementIndexOffset = 10,
        TopLeftAnchor = (vector2 + new Vector2(0.0f, 28f)),
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.HeartPanelDrawer),
        OffsetPerDraw = Vector2.Zero,
        OffsetPerDrawByTexturePercentile = Vector2.UnitX,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered);
      new ResourceDrawSettings()
      {
        ElementCount = this._heartCountRow1,
        ElementIndexOffset = 0,
        TopLeftAnchor = (vector2 + new Vector2(15f, 15f)),
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.HeartFillingDrawer),
        OffsetPerDraw = (Vector2.UnitX * 2f),
        OffsetPerDrawByTexturePercentile = Vector2.UnitX,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = new Vector2(0.5f, 0.5f)
      }.Draw(spriteBatch, ref isHovered);
      new ResourceDrawSettings()
      {
        ElementCount = this._heartCountRow2,
        ElementIndexOffset = 10,
        TopLeftAnchor = (vector2 + new Vector2(15f, 15f) + new Vector2(0.0f, 28f)),
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.HeartFillingDrawer),
        OffsetPerDraw = (Vector2.UnitX * 2f),
        OffsetPerDrawByTexturePercentile = Vector2.UnitX,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = new Vector2(0.5f, 0.5f)
      }.Draw(spriteBatch, ref isHovered);
      this._hoverLife = isHovered;
    }

    private static void DrawLifeBarText(SpriteBatch spriteBatch, Vector2 topLeftAnchor)
    {
      Vector2 vector2_1 = topLeftAnchor + new Vector2(130f, -24f);
      Player localPlayer = Main.LocalPlayer;
      Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      string str = Lang.inter[0].Value + " " + (object) localPlayer.statLifeMax2 + "/" + (object) localPlayer.statLifeMax2;
      Vector2 vector2_2 = FontAssets.MouseText.Value.MeasureString(str);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, Lang.inter[0].Value, vector2_1 + new Vector2((float) (-(double) vector2_2.X * 0.5), 0.0f), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2, vector2_1 + new Vector2(vector2_2.X * 0.5f, 0.0f), color, 0.0f, new Vector2(FontAssets.MouseText.Value.MeasureString(localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2).X, 0.0f), 1f, SpriteEffects.None, 0.0f);
    }

    private void DrawManaBar(SpriteBatch spriteBatch)
    {
      Vector2 vector2 = new Vector2((float) (Main.screenWidth - 40), 22f);
      int starCount = this._starCount;
      bool isHovered = false;
      new ResourceDrawSettings()
      {
        ElementCount = this._starCount,
        ElementIndexOffset = 0,
        TopLeftAnchor = vector2,
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.StarPanelDrawer),
        OffsetPerDraw = Vector2.Zero,
        OffsetPerDrawByTexturePercentile = Vector2.UnitY,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = Vector2.Zero
      }.Draw(spriteBatch, ref isHovered);
      new ResourceDrawSettings()
      {
        ElementCount = this._starCount,
        ElementIndexOffset = 0,
        TopLeftAnchor = (vector2 + new Vector2(15f, 16f)),
        GetTextureMethod = new ResourceDrawSettings.TextureGetter(this.StarFillingDrawer),
        OffsetPerDraw = (Vector2.UnitY * -2f),
        OffsetPerDrawByTexturePercentile = Vector2.UnitY,
        OffsetSpriteAnchor = Vector2.Zero,
        OffsetSpriteAnchorByTexturePercentile = new Vector2(0.5f, 0.5f)
      }.Draw(spriteBatch, ref isHovered);
      this._hoverMana = isHovered;
    }

    private static void DrawManaText(SpriteBatch spriteBatch)
    {
      Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(Lang.inter[2].Value);
      Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      int num = 50;
      if ((double) vector2.X >= 45.0)
        num = (int) vector2.X + 5;
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, Lang.inter[2].Value, new Vector2((float) (Main.screenWidth - num), 6f), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
    }

    private void HeartPanelDrawer(
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
      sprite = this._heartLeft;
      drawScale = 1f;
      if (elementIndex == lastElementIndex && elementIndex == firstElementIndex)
      {
        sprite = this._heartSingleFancy;
        offset = new Vector2(-4f, -4f);
      }
      else if (elementIndex == lastElementIndex && lastElementIndex == this._lastHeartPanelIndex)
      {
        sprite = this._heartRightFancy;
        offset = new Vector2(-8f, -4f);
      }
      else if (elementIndex == lastElementIndex)
      {
        sprite = this._heartRight;
      }
      else
      {
        if (elementIndex == firstElementIndex)
          return;
        sprite = this._heartMiddle;
      }
    }

    private void HeartFillingDrawer(
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
      sprite = this._heartLeft;
      sprite = elementIndex >= this._playerLifeFruitCount ? this._heartFill : this._heartFillHoney;
      float lerpValue = Utils.GetLerpValue(this._lifePerHeart * (float) elementIndex, this._lifePerHeart * (float) (elementIndex + 1), this._currentPlayerLife, true);
      drawScale = lerpValue;
      if (elementIndex != this._lastHeartFillingIndex || (double) lerpValue <= 0.0)
        return;
      drawScale += Main.cursorScale - 1f;
    }

    private void StarPanelDrawer(
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
      sprite = this._starTop;
      drawScale = 1f;
      if (elementIndex == lastElementIndex && elementIndex == firstElementIndex)
        sprite = this._starSingle;
      else if (elementIndex == lastElementIndex)
      {
        sprite = this._starBottom;
        offset = new Vector2(0.0f, 0.0f);
      }
      else
      {
        if (elementIndex == firstElementIndex)
          return;
        sprite = this._starMiddle;
      }
    }

    private void StarFillingDrawer(
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
      sprite = this._starFill;
      float lerpValue = Utils.GetLerpValue(this._manaPerStar * (float) elementIndex, this._manaPerStar * (float) (elementIndex + 1), this._currentPlayerMana, true);
      drawScale = lerpValue;
      if (elementIndex != this._lastStarFillingIndex || (double) lerpValue <= 0.0)
        return;
      drawScale += Main.cursorScale - 1f;
    }

    private void PrepareFields(Player player)
    {
      PlayerStatsSnapshot playerStatsSnapshot = new PlayerStatsSnapshot(player);
      this._playerLifeFruitCount = playerStatsSnapshot.LifeFruitCount;
      this._lifePerHeart = playerStatsSnapshot.LifePerSegment;
      this._currentPlayerLife = (float) playerStatsSnapshot.Life;
      this._manaPerStar = playerStatsSnapshot.ManaPerSegment;
      this._heartCountRow1 = Utils.Clamp<int>((int) ((double) playerStatsSnapshot.LifeMax / (double) this._lifePerHeart), 0, 10);
      this._heartCountRow2 = Utils.Clamp<int>((int) ((double) (playerStatsSnapshot.LifeMax - 200) / (double) this._lifePerHeart), 0, 10);
      this._lastHeartFillingIndex = (int) ((double) playerStatsSnapshot.Life / (double) this._lifePerHeart);
      this._lastHeartPanelIndex = this._heartCountRow1 + this._heartCountRow2 - 1;
      this._starCount = (int) ((double) playerStatsSnapshot.ManaMax / (double) this._manaPerStar);
      this._currentPlayerMana = (float) playerStatsSnapshot.Mana;
      this._lastStarFillingIndex = (int) ((double) this._currentPlayerMana / (double) this._manaPerStar);
    }

    public void TryToHover()
    {
      if (this._hoverLife)
        CommonResourceBarMethods.DrawLifeMouseOver();
      if (!this._hoverMana)
        return;
      CommonResourceBarMethods.DrawManaMouseOver();
    }
  }
}
