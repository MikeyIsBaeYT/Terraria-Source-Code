// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.UnlockableNPCEntryIcon
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria.GameContent.Bestiary
{
  public class UnlockableNPCEntryIcon : IEntryIcon
  {
    private int _npcNetId;
    private NPC _npcCache;
    private bool _firstUpdateDone;
    private Asset<Texture2D> _customTexture;
    private Vector2 _positionOffsetCache;
    private string _overrideNameKey;

    public UnlockableNPCEntryIcon(
      int npcNetId,
      float ai0 = 0.0f,
      float ai1 = 0.0f,
      float ai2 = 0.0f,
      float ai3 = 0.0f,
      string overrideNameKey = null)
    {
      this._npcNetId = npcNetId;
      this._npcCache = new NPC();
      this._npcCache.SetDefaults(this._npcNetId);
      this._npcCache.IsABestiaryIconDummy = true;
      this._firstUpdateDone = false;
      this._npcCache.ai[0] = ai0;
      this._npcCache.ai[1] = ai1;
      this._npcCache.ai[2] = ai2;
      this._npcCache.ai[3] = ai3;
      this._customTexture = (Asset<Texture2D>) null;
      this._overrideNameKey = overrideNameKey;
    }

    public IEntryIcon CreateClone() => (IEntryIcon) new UnlockableNPCEntryIcon(this._npcNetId, overrideNameKey: this._overrideNameKey);

    public void Update(
      BestiaryUICollectionInfo providedInfo,
      Rectangle hitbox,
      EntryIconDrawSettings settings)
    {
      Vector2 vector2 = new Vector2();
      int? nullable1 = new int?();
      int? nullable2 = new int?();
      int? nullable3 = new int?();
      bool flag = false;
      float velocity = 0.0f;
      Asset<Texture2D> asset = (Asset<Texture2D>) null;
      NPCID.Sets.NPCBestiaryDrawModifiers bestiaryDrawModifiers;
      if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(this._npcNetId, out bestiaryDrawModifiers))
      {
        this._npcCache.rotation = bestiaryDrawModifiers.Rotation;
        this._npcCache.scale = bestiaryDrawModifiers.Scale;
        if (bestiaryDrawModifiers.PortraitScale.HasValue && settings.IsPortrait)
          this._npcCache.scale = bestiaryDrawModifiers.PortraitScale.Value;
        vector2 = bestiaryDrawModifiers.Position;
        nullable1 = bestiaryDrawModifiers.Frame;
        nullable2 = bestiaryDrawModifiers.Direction;
        nullable3 = bestiaryDrawModifiers.SpriteDirection;
        velocity = bestiaryDrawModifiers.Velocity;
        flag = bestiaryDrawModifiers.IsWet;
        if (bestiaryDrawModifiers.PortraitPositionXOverride.HasValue && settings.IsPortrait)
          vector2.X = bestiaryDrawModifiers.PortraitPositionXOverride.Value;
        if (bestiaryDrawModifiers.PortraitPositionYOverride.HasValue && settings.IsPortrait)
          vector2.Y = bestiaryDrawModifiers.PortraitPositionYOverride.Value;
        if (bestiaryDrawModifiers.CustomTexturePath != null)
          asset = Main.Assets.Request<Texture2D>(bestiaryDrawModifiers.CustomTexturePath, (AssetRequestMode) 1);
        if (asset != null && asset.IsLoaded)
          this._customTexture = asset;
      }
      this._positionOffsetCache = vector2;
      this.UpdatePosition(settings);
      if (NPCID.Sets.TrailingMode[this._npcCache.type] != -1)
      {
        for (int index = 0; index < this._npcCache.oldPos.Length; ++index)
          this._npcCache.oldPos[index] = this._npcCache.position;
      }
      this._npcCache.direction = this._npcCache.spriteDirection = nullable2.HasValue ? nullable2.Value : -1;
      if (nullable3.HasValue)
        this._npcCache.spriteDirection = nullable3.Value;
      this._npcCache.wet = flag;
      this.AdjustSpecialSpawnRulesForVisuals(settings);
      this.SimulateFirstHover(velocity);
      if (!nullable1.HasValue && (settings.IsPortrait || settings.IsHovered))
      {
        this._npcCache.velocity.X = (float) this._npcCache.direction * velocity;
        this._npcCache.FindFrame();
      }
      else
      {
        if (!nullable1.HasValue)
          return;
        this._npcCache.FindFrame();
        this._npcCache.frame.Y = this._npcCache.frame.Height * nullable1.Value;
      }
    }

    private void UpdatePosition(EntryIconDrawSettings settings)
    {
      if (this._npcCache.noGravity)
        this._npcCache.Center = settings.iconbox.Center.ToVector2() + this._positionOffsetCache;
      else
        this._npcCache.Bottom = settings.iconbox.TopLeft() + settings.iconbox.Size() * new Vector2(0.5f, 1f) + new Vector2(0.0f, -8f) + this._positionOffsetCache;
      this._npcCache.position = this._npcCache.position.Floor();
    }

    private void AdjustSpecialSpawnRulesForVisuals(EntryIconDrawSettings settings)
    {
      int num;
      if (NPCID.Sets.SpecialSpawningRules.TryGetValue(this._npcNetId, out num) && num == 0)
      {
        Point tileCoordinates = (this._npcCache.position - this._npcCache.rotation.ToRotationVector2() * -1600f).ToTileCoordinates();
        this._npcCache.ai[0] = (float) tileCoordinates.X;
        this._npcCache.ai[1] = (float) tileCoordinates.Y;
      }
      switch (this._npcNetId)
      {
        case 244:
          this._npcCache.AI_001_SetRainbowSlimeColor();
          break;
        case 299:
        case 538:
        case 539:
        case 639:
        case 640:
        case 641:
        case 642:
        case 643:
        case 644:
        case 645:
          if (!settings.IsPortrait || this._npcCache.frame.Y != 0)
            break;
          this._npcCache.frame.Y = this._npcCache.frame.Height;
          break;
        case 330:
        case 372:
        case 586:
        case 587:
        case 619:
        case 620:
          this._npcCache.alpha = 0;
          break;
        case 356:
          this._npcCache.ai[2] = 1f;
          break;
        case 636:
          this._npcCache.Opacity = 1f;
          if ((double) ++this._npcCache.localAI[0] < 44.0)
            break;
          this._npcCache.localAI[0] = 0.0f;
          break;
        case 656:
          this._npcCache.townNpcVariationIndex = 1;
          break;
      }
    }

    private void SimulateFirstHover(float velocity)
    {
      if (this._firstUpdateDone)
        return;
      this._firstUpdateDone = true;
      this._npcCache.SetFrameSize();
      this._npcCache.velocity.X = (float) this._npcCache.direction * velocity;
      for (int index = 0; index < 1; ++index)
        this._npcCache.FindFrame();
    }

    public void Draw(
      BestiaryUICollectionInfo providedInfo,
      SpriteBatch spriteBatch,
      EntryIconDrawSettings settings)
    {
      this.UpdatePosition(settings);
      if (this._customTexture != null)
      {
        spriteBatch.Draw(this._customTexture.Value, this._npcCache.Center, new Rectangle?(), Color.White, 0.0f, this._customTexture.Size() / 2f, this._npcCache.scale, SpriteEffects.None, 0.0f);
      }
      else
      {
        ITownNPCProfile profile;
        if (this._npcCache.townNPC && TownNPCProfiles.Instance.GetProfile(this._npcCache.type, out profile))
          TextureAssets.Npc[this._npcCache.type] = profile.GetTextureNPCShouldUse(this._npcCache);
        Main.instance.DrawNPCDirect(spriteBatch, this._npcCache, this._npcCache.behindTiles, Vector2.Zero);
      }
    }

    public string GetHoverText(BestiaryUICollectionInfo providedInfo)
    {
      string str = Lang.GetNPCNameValue(this._npcCache.netID);
      if (!string.IsNullOrWhiteSpace(this._overrideNameKey))
        str = Language.GetTextValue(this._overrideNameKey);
      return this.GetUnlockState(providedInfo) ? str : "???";
    }

    public bool GetUnlockState(BestiaryUICollectionInfo providedInfo) => providedInfo.UnlockState > BestiaryEntryUnlockState.NotKnownAtAll_0;
  }
}
