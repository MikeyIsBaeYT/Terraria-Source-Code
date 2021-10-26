// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIWorldListItem
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.OS;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIWorldListItem : UIPanel
  {
    private WorldFileData _data;
    private Asset<Texture2D> _dividerTexture;
    private Asset<Texture2D> _innerPanelTexture;
    private UIImage _worldIcon;
    private UIText _buttonLabel;
    private UIText _deleteButtonLabel;
    private Asset<Texture2D> _buttonCloudActiveTexture;
    private Asset<Texture2D> _buttonCloudInactiveTexture;
    private Asset<Texture2D> _buttonFavoriteActiveTexture;
    private Asset<Texture2D> _buttonFavoriteInactiveTexture;
    private Asset<Texture2D> _buttonPlayTexture;
    private Asset<Texture2D> _buttonSeedTexture;
    private Asset<Texture2D> _buttonDeleteTexture;
    private UIImageButton _deleteButton;
    private int _orderInList;
    private bool _canBePlayed;

    public bool IsFavorite => this._data.IsFavorite;

    public UIWorldListItem(WorldFileData data, int orderInList, bool canBePlayed)
    {
      this._orderInList = orderInList;
      this._data = data;
      this._canBePlayed = canBePlayed;
      this.LoadTextures();
      this.InitializeAppearance();
      this._worldIcon = new UIImage(this.GetIcon());
      this._worldIcon.Left.Set(4f, 0.0f);
      this._worldIcon.OnDoubleClick += new UIElement.MouseEvent(this.PlayGame);
      this.Append((UIElement) this._worldIcon);
      float pixels1 = 4f;
      UIImageButton uiImageButton1 = new UIImageButton(this._buttonPlayTexture);
      uiImageButton1.VAlign = 1f;
      uiImageButton1.Left.Set(pixels1, 0.0f);
      uiImageButton1.OnClick += new UIElement.MouseEvent(this.PlayGame);
      this.OnDoubleClick += new UIElement.MouseEvent(this.PlayGame);
      uiImageButton1.OnMouseOver += new UIElement.MouseEvent(this.PlayMouseOver);
      uiImageButton1.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
      this.Append((UIElement) uiImageButton1);
      float pixels2 = pixels1 + 24f;
      UIImageButton uiImageButton2 = new UIImageButton(this._data.IsFavorite ? this._buttonFavoriteActiveTexture : this._buttonFavoriteInactiveTexture);
      uiImageButton2.VAlign = 1f;
      uiImageButton2.Left.Set(pixels2, 0.0f);
      uiImageButton2.OnClick += new UIElement.MouseEvent(this.FavoriteButtonClick);
      uiImageButton2.OnMouseOver += new UIElement.MouseEvent(this.FavoriteMouseOver);
      uiImageButton2.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
      uiImageButton2.SetVisibility(1f, this._data.IsFavorite ? 0.8f : 0.4f);
      this.Append((UIElement) uiImageButton2);
      float pixels3 = pixels2 + 24f;
      if (SocialAPI.Cloud != null)
      {
        UIImageButton uiImageButton3 = new UIImageButton(this._data.IsCloudSave ? this._buttonCloudActiveTexture : this._buttonCloudInactiveTexture);
        uiImageButton3.VAlign = 1f;
        uiImageButton3.Left.Set(pixels3, 0.0f);
        uiImageButton3.OnClick += new UIElement.MouseEvent(this.CloudButtonClick);
        uiImageButton3.OnMouseOver += new UIElement.MouseEvent(this.CloudMouseOver);
        uiImageButton3.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
        uiImageButton3.SetSnapPoint("Cloud", orderInList);
        this.Append((UIElement) uiImageButton3);
        pixels3 += 24f;
      }
      if (this._data.WorldGeneratorVersion != 0UL)
      {
        UIImageButton uiImageButton4 = new UIImageButton(this._buttonSeedTexture);
        uiImageButton4.VAlign = 1f;
        uiImageButton4.Left.Set(pixels3, 0.0f);
        uiImageButton4.OnClick += new UIElement.MouseEvent(this.SeedButtonClick);
        uiImageButton4.OnMouseOver += new UIElement.MouseEvent(this.SeedMouseOver);
        uiImageButton4.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
        uiImageButton4.SetSnapPoint("Seed", orderInList);
        this.Append((UIElement) uiImageButton4);
        pixels3 += 24f;
      }
      UIImageButton uiImageButton5 = new UIImageButton(this._buttonDeleteTexture);
      uiImageButton5.VAlign = 1f;
      uiImageButton5.HAlign = 1f;
      if (!this._data.IsFavorite)
        uiImageButton5.OnClick += new UIElement.MouseEvent(this.DeleteButtonClick);
      uiImageButton5.OnMouseOver += new UIElement.MouseEvent(this.DeleteMouseOver);
      uiImageButton5.OnMouseOut += new UIElement.MouseEvent(this.DeleteMouseOut);
      this._deleteButton = uiImageButton5;
      this.Append((UIElement) uiImageButton5);
      float pixels4 = pixels3 + 4f;
      this._buttonLabel = new UIText("");
      this._buttonLabel.VAlign = 1f;
      this._buttonLabel.Left.Set(pixels4, 0.0f);
      this._buttonLabel.Top.Set(-3f, 0.0f);
      this.Append((UIElement) this._buttonLabel);
      this._deleteButtonLabel = new UIText("");
      this._deleteButtonLabel.VAlign = 1f;
      this._deleteButtonLabel.HAlign = 1f;
      this._deleteButtonLabel.Left.Set(-30f, 0.0f);
      this._deleteButtonLabel.Top.Set(-3f, 0.0f);
      this.Append((UIElement) this._deleteButtonLabel);
      uiImageButton1.SetSnapPoint("Play", orderInList);
      uiImageButton2.SetSnapPoint("Favorite", orderInList);
      uiImageButton5.SetSnapPoint("Delete", orderInList);
    }

    private void LoadTextures()
    {
      this._dividerTexture = Main.Assets.Request<Texture2D>("Images/UI/Divider", (AssetRequestMode) 1);
      this._innerPanelTexture = Main.Assets.Request<Texture2D>("Images/UI/InnerPanelBackground", (AssetRequestMode) 1);
      this._buttonCloudActiveTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonCloudActive", (AssetRequestMode) 1);
      this._buttonCloudInactiveTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonCloudInactive", (AssetRequestMode) 1);
      this._buttonFavoriteActiveTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonFavoriteActive", (AssetRequestMode) 1);
      this._buttonFavoriteInactiveTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonFavoriteInactive", (AssetRequestMode) 1);
      this._buttonPlayTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonPlay", (AssetRequestMode) 1);
      this._buttonSeedTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonSeed", (AssetRequestMode) 1);
      this._buttonDeleteTexture = Main.Assets.Request<Texture2D>("Images/UI/ButtonDelete", (AssetRequestMode) 1);
    }

    private void InitializeAppearance()
    {
      this.Height.Set(96f, 0.0f);
      this.Width.Set(0.0f, 1f);
      this.SetPadding(6f);
      this.SetColorsToNotHovered();
    }

    private void SetColorsToHovered()
    {
      this.BackgroundColor = new Color(73, 94, 171);
      this.BorderColor = new Color(89, 116, 213);
      if (this._canBePlayed)
        return;
      this.BorderColor = new Color(150, 150, 150) * 1f;
      this.BackgroundColor = Color.Lerp(this.BackgroundColor, new Color(120, 120, 120), 0.5f) * 1f;
    }

    private void SetColorsToNotHovered()
    {
      this.BackgroundColor = new Color(63, 82, 151) * 0.7f;
      this.BorderColor = new Color(89, 116, 213) * 0.7f;
      if (this._canBePlayed)
        return;
      this.BorderColor = new Color((int) sbyte.MaxValue, (int) sbyte.MaxValue, (int) sbyte.MaxValue) * 0.7f;
      this.BackgroundColor = Color.Lerp(new Color(63, 82, 151), new Color(80, 80, 80), 0.5f) * 0.7f;
    }

    private Asset<Texture2D> GetIcon() => this._data.DrunkWorld ? Main.Assets.Request<Texture2D>("Images/UI/Icon" + (this._data.IsHardMode ? "Hallow" : "") + "CorruptionCrimson", (AssetRequestMode) 1) : Main.Assets.Request<Texture2D>("Images/UI/Icon" + (this._data.IsHardMode ? "Hallow" : "") + (this._data.HasCorruption ? "Corruption" : "Crimson"), (AssetRequestMode) 1);

    private void FavoriteMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      if (this._data.IsFavorite)
        this._buttonLabel.SetText(Language.GetTextValue("UI.Unfavorite"));
      else
        this._buttonLabel.SetText(Language.GetTextValue("UI.Favorite"));
    }

    private void CloudMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      if (this._data.IsCloudSave)
        this._buttonLabel.SetText(Language.GetTextValue("UI.MoveOffCloud"));
      else
        this._buttonLabel.SetText(Language.GetTextValue("UI.MoveToCloud"));
    }

    private void PlayMouseOver(UIMouseEvent evt, UIElement listeningElement) => this._buttonLabel.SetText(Language.GetTextValue("UI.Play"));

    private void SeedMouseOver(UIMouseEvent evt, UIElement listeningElement) => this._buttonLabel.SetText(Language.GetTextValue("UI.CopySeed", (object) this._data.GetFullSeedText()));

    private void DeleteMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      if (this._data.IsFavorite)
        this._deleteButtonLabel.SetText(Language.GetTextValue("UI.CannotDeleteFavorited"));
      else
        this._deleteButtonLabel.SetText(Language.GetTextValue("UI.Delete"));
    }

    private void DeleteMouseOut(UIMouseEvent evt, UIElement listeningElement) => this._deleteButtonLabel.SetText("");

    private void ButtonMouseOut(UIMouseEvent evt, UIElement listeningElement) => this._buttonLabel.SetText("");

    private void CloudButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      if (this._data.IsCloudSave)
        this._data.MoveToLocal();
      else
        this._data.MoveToCloud();
      ((UIImageButton) evt.Target).SetImage(this._data.IsCloudSave ? this._buttonCloudActiveTexture : this._buttonCloudInactiveTexture);
      if (this._data.IsCloudSave)
        this._buttonLabel.SetText(Language.GetTextValue("UI.MoveOffCloud"));
      else
        this._buttonLabel.SetText(Language.GetTextValue("UI.MoveToCloud"));
    }

    private void DeleteButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      for (int index = 0; index < Main.WorldList.Count; ++index)
      {
        if (Main.WorldList[index] == this._data)
        {
          SoundEngine.PlaySound(10);
          Main.selectedWorld = index;
          Main.menuMode = 9;
          break;
        }
      }
    }

    private void PlayGame(UIMouseEvent evt, UIElement listeningElement)
    {
      if (listeningElement != evt.Target || this.TryMovingToRejectionMenuIfNeeded(this._data.GameMode))
        return;
      this._data.SetAsActive();
      SoundEngine.PlaySound(10);
      Main.GetInputText("");
      Main.menuMode = !Main.menuMultiplayer || SocialAPI.Network == null ? (!Main.menuMultiplayer ? 10 : 30) : 889;
      if (Main.menuMultiplayer)
        return;
      WorldGen.playWorld();
    }

    private bool TryMovingToRejectionMenuIfNeeded(int worldGameMode)
    {
      GameModeData gameModeData;
      if (!Main.RegisterdGameModes.TryGetValue(worldGameMode, out gameModeData))
      {
        SoundEngine.PlaySound(10);
        Main.statusText = Language.GetTextValue("UI.WorldCannotBeLoadedBecauseItHasAnInvalidGameMode");
        Main.menuMode = 1000000;
        return true;
      }
      bool flag = Main.ActivePlayerFileData.Player.difficulty == (byte) 3;
      bool isJourneyMode = gameModeData.IsJourneyMode;
      if (flag && !isJourneyMode)
      {
        SoundEngine.PlaySound(10);
        Main.statusText = Language.GetTextValue("UI.PlayerIsCreativeAndWorldIsNotCreative");
        Main.menuMode = 1000000;
        return true;
      }
      if (!(!flag & isJourneyMode))
        return false;
      SoundEngine.PlaySound(10);
      Main.statusText = Language.GetTextValue("UI.PlayerIsNotCreativeAndWorldIsCreative");
      Main.menuMode = 1000000;
      return true;
    }

    private void FavoriteButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      this._data.ToggleFavorite();
      ((UIImageButton) evt.Target).SetImage(this._data.IsFavorite ? this._buttonFavoriteActiveTexture : this._buttonFavoriteInactiveTexture);
      ((UIImageButton) evt.Target).SetVisibility(1f, this._data.IsFavorite ? 0.8f : 0.4f);
      if (this._data.IsFavorite)
      {
        this._buttonLabel.SetText(Language.GetTextValue("UI.Unfavorite"));
        this._deleteButton.OnClick -= new UIElement.MouseEvent(this.DeleteButtonClick);
      }
      else
      {
        this._buttonLabel.SetText(Language.GetTextValue("UI.Favorite"));
        this._deleteButton.OnClick += new UIElement.MouseEvent(this.DeleteButtonClick);
      }
      if (!(this.Parent.Parent is UIList parent))
        return;
      parent.UpdateOrder();
    }

    private void SeedButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      Platform.Get<IClipboard>().Value = this._data.GetFullSeedText();
      this._buttonLabel.SetText(Language.GetTextValue("UI.SeedCopied"));
    }

    public override int CompareTo(object obj) => obj is UIWorldListItem uiWorldListItem ? this._orderInList.CompareTo(uiWorldListItem._orderInList) : base.CompareTo(obj);

    public override void MouseOver(UIMouseEvent evt)
    {
      base.MouseOver(evt);
      this.SetColorsToHovered();
    }

    public override void MouseOut(UIMouseEvent evt)
    {
      base.MouseOut(evt);
      this.SetColorsToNotHovered();
    }

    private void DrawPanel(SpriteBatch spriteBatch, Vector2 position, float width)
    {
      spriteBatch.Draw(this._innerPanelTexture.Value, position, new Rectangle?(new Rectangle(0, 0, 8, this._innerPanelTexture.Height())), Color.White);
      spriteBatch.Draw(this._innerPanelTexture.Value, new Vector2(position.X + 8f, position.Y), new Rectangle?(new Rectangle(8, 0, 8, this._innerPanelTexture.Height())), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (((double) width - 16.0) / 8.0), 1f), SpriteEffects.None, 0.0f);
      spriteBatch.Draw(this._innerPanelTexture.Value, new Vector2((float) ((double) position.X + (double) width - 8.0), position.Y), new Rectangle?(new Rectangle(16, 0, 8, this._innerPanelTexture.Height())), Color.White);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      base.DrawSelf(spriteBatch);
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      CalculatedStyle dimensions = this._worldIcon.GetDimensions();
      float x1 = dimensions.X + dimensions.Width;
      Color color1 = this._data.IsValid ? Color.White : Color.Red;
      Utils.DrawBorderString(spriteBatch, this._data.Name, new Vector2(x1 + 6f, dimensions.Y - 2f), color1);
      spriteBatch.Draw(this._dividerTexture.Value, new Vector2(x1, innerDimensions.Y + 21f), new Rectangle?(), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (((double) this.GetDimensions().X + (double) this.GetDimensions().Width - (double) x1) / 8.0), 1f), SpriteEffects.None, 0.0f);
      Vector2 position = new Vector2(x1 + 6f, innerDimensions.Y + 29f);
      float width1 = 100f;
      this.DrawPanel(spriteBatch, position, width1);
      Color color2 = Color.White;
      string textValue1;
      switch (this._data.GameMode)
      {
        case 1:
          textValue1 = Language.GetTextValue("UI.Expert");
          color2 = Main.mcColor;
          break;
        case 2:
          textValue1 = Language.GetTextValue("UI.Master");
          color2 = Main.hcColor;
          break;
        case 3:
          textValue1 = Language.GetTextValue("UI.Creative");
          color2 = Main.creativeModeColor;
          break;
        default:
          textValue1 = Language.GetTextValue("UI.Normal");
          break;
      }
      float x2 = FontAssets.MouseText.Value.MeasureString(textValue1).X;
      float x3 = (float) ((double) width1 * 0.5 - (double) x2 * 0.5);
      Utils.DrawBorderString(spriteBatch, textValue1, position + new Vector2(x3, 3f), color2);
      position.X += width1 + 5f;
      float width2 = 150f;
      if (!GameCulture.FromCultureName(GameCulture.CultureName.English).IsActive)
        width2 += 40f;
      this.DrawPanel(spriteBatch, position, width2);
      string textValue2 = Language.GetTextValue("UI.WorldSizeFormat", (object) this._data.WorldSizeName);
      float x4 = FontAssets.MouseText.Value.MeasureString(textValue2).X;
      float x5 = (float) ((double) width2 * 0.5 - (double) x4 * 0.5);
      Utils.DrawBorderString(spriteBatch, textValue2, position + new Vector2(x5, 3f), Color.White);
      position.X += width2 + 5f;
      float width3 = innerDimensions.X + innerDimensions.Width - position.X;
      this.DrawPanel(spriteBatch, position, width3);
      string textValue3 = Language.GetTextValue("UI.WorldCreatedFormat", !GameCulture.FromCultureName(GameCulture.CultureName.English).IsActive ? (object) this._data.CreationTime.ToShortDateString() : (object) this._data.CreationTime.ToString("d MMMM yyyy"));
      float x6 = FontAssets.MouseText.Value.MeasureString(textValue3).X;
      float x7 = (float) ((double) width3 * 0.5 - (double) x6 * 0.5);
      Utils.DrawBorderString(spriteBatch, textValue3, position + new Vector2(x7, 3f), Color.White);
      position.X += width3 + 5f;
    }
  }
}
