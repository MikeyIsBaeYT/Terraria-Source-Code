// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIWorldCreationPreview
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIWorldCreationPreview : UIElement
  {
    private readonly Asset<Texture2D> _BorderTexture;
    private readonly Asset<Texture2D> _BackgroundExpertTexture;
    private readonly Asset<Texture2D> _BackgroundNormalTexture;
    private readonly Asset<Texture2D> _BackgroundMasterTexture;
    private readonly Asset<Texture2D> _BunnyExpertTexture;
    private readonly Asset<Texture2D> _BunnyNormalTexture;
    private readonly Asset<Texture2D> _BunnyCreativeTexture;
    private readonly Asset<Texture2D> _BunnyMasterTexture;
    private readonly Asset<Texture2D> _EvilRandomTexture;
    private readonly Asset<Texture2D> _EvilCorruptionTexture;
    private readonly Asset<Texture2D> _EvilCrimsonTexture;
    private readonly Asset<Texture2D> _SizeSmallTexture;
    private readonly Asset<Texture2D> _SizeMediumTexture;
    private readonly Asset<Texture2D> _SizeLargeTexture;
    private byte _difficulty;
    private byte _evil;
    private byte _size;

    public UIWorldCreationPreview()
    {
      this._BorderTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewBorder", (AssetRequestMode) 1);
      this._BackgroundNormalTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyNormal1", (AssetRequestMode) 1);
      this._BackgroundExpertTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyExpert1", (AssetRequestMode) 1);
      this._BackgroundMasterTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyMaster1", (AssetRequestMode) 1);
      this._BunnyNormalTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyNormal2", (AssetRequestMode) 1);
      this._BunnyExpertTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyExpert2", (AssetRequestMode) 1);
      this._BunnyCreativeTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyCreative2", (AssetRequestMode) 1);
      this._BunnyMasterTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewDifficultyMaster2", (AssetRequestMode) 1);
      this._EvilRandomTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewEvilRandom", (AssetRequestMode) 1);
      this._EvilCorruptionTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewEvilCorruption", (AssetRequestMode) 1);
      this._EvilCrimsonTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewEvilCrimson", (AssetRequestMode) 1);
      this._SizeSmallTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewSizeSmall", (AssetRequestMode) 1);
      this._SizeMediumTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewSizeMedium", (AssetRequestMode) 1);
      this._SizeLargeTexture = Main.Assets.Request<Texture2D>("Images/UI/WorldCreation/PreviewSizeLarge", (AssetRequestMode) 1);
      this.Width.Set((float) this._BackgroundExpertTexture.Width(), 0.0f);
      this.Height.Set((float) this._BackgroundExpertTexture.Height(), 0.0f);
    }

    public void UpdateOption(byte difficulty, byte evil, byte size)
    {
      this._difficulty = difficulty;
      this._evil = evil;
      this._size = size;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      Vector2 position = new Vector2(dimensions.X + 4f, dimensions.Y + 4f);
      Color color = Color.White;
      switch (this._difficulty)
      {
        case 0:
        case 3:
          spriteBatch.Draw(this._BackgroundNormalTexture.Value, position, Color.White);
          color = Color.White;
          break;
        case 1:
          spriteBatch.Draw(this._BackgroundExpertTexture.Value, position, Color.White);
          color = Color.DarkGray;
          break;
        case 2:
          spriteBatch.Draw(this._BackgroundMasterTexture.Value, position, Color.White);
          color = Color.DarkGray;
          break;
      }
      switch (this._size)
      {
        case 0:
          spriteBatch.Draw(this._SizeSmallTexture.Value, position, color);
          break;
        case 1:
          spriteBatch.Draw(this._SizeMediumTexture.Value, position, color);
          break;
        case 2:
          spriteBatch.Draw(this._SizeLargeTexture.Value, position, color);
          break;
      }
      switch (this._evil)
      {
        case 0:
          spriteBatch.Draw(this._EvilRandomTexture.Value, position, color);
          break;
        case 1:
          spriteBatch.Draw(this._EvilCorruptionTexture.Value, position, color);
          break;
        case 2:
          spriteBatch.Draw(this._EvilCrimsonTexture.Value, position, color);
          break;
      }
      switch (this._difficulty)
      {
        case 0:
          spriteBatch.Draw(this._BunnyNormalTexture.Value, position, color);
          break;
        case 1:
          spriteBatch.Draw(this._BunnyExpertTexture.Value, position, color);
          break;
        case 2:
          spriteBatch.Draw(this._BunnyMasterTexture.Value, position, color * 1.2f);
          break;
        case 3:
          spriteBatch.Draw(this._BunnyCreativeTexture.Value, position, color);
          break;
      }
      spriteBatch.Draw(this._BorderTexture.Value, new Vector2(dimensions.X, dimensions.Y), Color.White);
    }
  }
}
