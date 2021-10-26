// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIBestiaryEntryIcon
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.Bestiary;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIBestiaryEntryIcon : UIElement
  {
    private BestiaryEntry _entry;
    private Asset<Texture2D> _notUnlockedTexture;
    private bool _isPortrait;
    public bool ForceHover;
    private BestiaryUICollectionInfo _collectionInfo;

    public UIBestiaryEntryIcon(BestiaryEntry entry, bool isPortrait)
    {
      this._entry = entry;
      this.IgnoresMouseInteraction = true;
      this.OverrideSamplerState = Main.DefaultSamplerState;
      this.UseImmediateMode = true;
      this.Width.Set(0.0f, 1f);
      this.Height.Set(0.0f, 1f);
      this._notUnlockedTexture = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Locked", (AssetRequestMode) 1);
      this._isPortrait = isPortrait;
      this._collectionInfo = this._entry.UIInfoProvider.GetEntryUICollectionInfo();
    }

    public override void Update(GameTime gameTime)
    {
      this._collectionInfo = this._entry.UIInfoProvider.GetEntryUICollectionInfo();
      CalculatedStyle dimensions = this.GetDimensions();
      bool flag = this.IsMouseHovering || this.ForceHover;
      this._entry.Icon.Update(this._collectionInfo, dimensions.ToRectangle(), new EntryIconDrawSettings()
      {
        iconbox = dimensions.ToRectangle(),
        IsPortrait = this._isPortrait,
        IsHovered = flag
      });
      base.Update(gameTime);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      int num = this._entry.Icon.GetUnlockState(this._collectionInfo) ? 1 : 0;
      bool flag = this.IsMouseHovering || this.ForceHover;
      if (num != 0)
      {
        this._entry.Icon.Draw(this._collectionInfo, spriteBatch, new EntryIconDrawSettings()
        {
          iconbox = dimensions.ToRectangle(),
          IsPortrait = this._isPortrait,
          IsHovered = flag
        });
      }
      else
      {
        Texture2D texture2D = this._notUnlockedTexture.Value;
        spriteBatch.Draw(texture2D, dimensions.Center(), new Rectangle?(), Color.White * 0.15f, 0.0f, texture2D.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
      }
    }

    public string GetHoverText() => this._entry.Icon.GetHoverText(this._collectionInfo);
  }
}
