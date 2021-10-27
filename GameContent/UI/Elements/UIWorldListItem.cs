// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIWorldListItem
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.OS;
using Terraria.Graphics;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIWorldListItem : UIPanel
  {
    private WorldFileData _data;
    private Texture2D _dividerTexture;
    private Texture2D _innerPanelTexture;
    private UIImage _worldIcon;
    private UIText _buttonLabel;
    private UIText _deleteButtonLabel;
    private Texture2D _buttonCloudActiveTexture;
    private Texture2D _buttonCloudInactiveTexture;
    private Texture2D _buttonFavoriteActiveTexture;
    private Texture2D _buttonFavoriteInactiveTexture;
    private Texture2D _buttonPlayTexture;
    private Texture2D _buttonSeedTexture;
    private Texture2D _buttonDeleteTexture;
    private UIImageButton _deleteButton;

    public bool IsFavorite => this._data.IsFavorite;

    public UIWorldListItem(WorldFileData data, int snapPointIndex)
    {
      this._data = data;
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
        uiImageButton3.SetSnapPoint("Cloud", snapPointIndex);
        this.Append((UIElement) uiImageButton3);
        pixels3 += 24f;
      }
      if (Main.UseSeedUI && this._data.WorldGeneratorVersion != 0UL)
      {
        UIImageButton uiImageButton4 = new UIImageButton(this._buttonSeedTexture);
        uiImageButton4.VAlign = 1f;
        uiImageButton4.Left.Set(pixels3, 0.0f);
        uiImageButton4.OnClick += new UIElement.MouseEvent(this.SeedButtonClick);
        uiImageButton4.OnMouseOver += new UIElement.MouseEvent(this.SeedMouseOver);
        uiImageButton4.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
        uiImageButton4.SetSnapPoint("Seed", snapPointIndex);
        this.Append((UIElement) uiImageButton4);
        pixels3 += 24f;
      }
      UIImageButton uiImageButton5 = new UIImageButton(this._buttonDeleteTexture);
      uiImageButton5.VAlign = 1f;
      uiImageButton5.HAlign = 1f;
      uiImageButton5.OnClick += new UIElement.MouseEvent(this.DeleteButtonClick);
      uiImageButton5.OnMouseOver += new UIElement.MouseEvent(this.DeleteMouseOver);
      uiImageButton5.OnMouseOut += new UIElement.MouseEvent(this.DeleteMouseOut);
      this._deleteButton = uiImageButton5;
      if (!this._data.IsFavorite)
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
      uiImageButton1.SetSnapPoint("Play", snapPointIndex);
      uiImageButton2.SetSnapPoint("Favorite", snapPointIndex);
      uiImageButton5.SetSnapPoint("Delete", snapPointIndex);
    }

    private void LoadTextures()
    {
      this._dividerTexture = TextureManager.Load("Images/UI/Divider");
      this._innerPanelTexture = TextureManager.Load("Images/UI/InnerPanelBackground");
      this._buttonCloudActiveTexture = TextureManager.Load("Images/UI/ButtonCloudActive");
      this._buttonCloudInactiveTexture = TextureManager.Load("Images/UI/ButtonCloudInactive");
      this._buttonFavoriteActiveTexture = TextureManager.Load("Images/UI/ButtonFavoriteActive");
      this._buttonFavoriteInactiveTexture = TextureManager.Load("Images/UI/ButtonFavoriteInactive");
      this._buttonPlayTexture = TextureManager.Load("Images/UI/ButtonPlay");
      this._buttonSeedTexture = TextureManager.Load("Images/UI/ButtonSeed");
      this._buttonDeleteTexture = TextureManager.Load("Images/UI/ButtonDelete");
    }

    private void InitializeAppearance()
    {
      this.Height.Set(96f, 0.0f);
      this.Width.Set(0.0f, 1f);
      this.SetPadding(6f);
      this.BorderColor = new Color(89, 116, 213) * 0.7f;
    }

    private Texture2D GetIcon() => TextureManager.Load("Images/UI/Icon" + (this._data.IsHardMode ? "Hallow" : "") + (this._data.HasCorruption ? "Corruption" : "Crimson"));

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

    private void SeedMouseOver(UIMouseEvent evt, UIElement listeningElement) => this._buttonLabel.SetText(Language.GetTextValue("UI.CopySeed", (object) this._data.SeedText));

    private void DeleteMouseOver(UIMouseEvent evt, UIElement listeningElement) => this._deleteButtonLabel.SetText(Language.GetTextValue("UI.Delete"));

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
          Main.PlaySound(10);
          Main.selectedWorld = index;
          Main.menuMode = 9;
          break;
        }
      }
    }

    private void PlayGame(UIMouseEvent evt, UIElement listeningElement)
    {
      if (listeningElement != evt.Target)
        return;
      this._data.SetAsActive();
      Main.PlaySound(10);
      Main.GetInputText("");
      Main.menuMode = !Main.menuMultiplayer || SocialAPI.Network == null ? (!Main.menuMultiplayer ? 10 : 30) : 889;
      if (Main.menuMultiplayer)
        return;
      WorldGen.playWorld();
    }

    private void FavoriteButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      this._data.ToggleFavorite();
      ((UIImageButton) evt.Target).SetImage(this._data.IsFavorite ? this._buttonFavoriteActiveTexture : this._buttonFavoriteInactiveTexture);
      ((UIImageButton) evt.Target).SetVisibility(1f, this._data.IsFavorite ? 0.8f : 0.4f);
      if (this._data.IsFavorite)
      {
        this._buttonLabel.SetText(Language.GetTextValue("UI.Unfavorite"));
        this.RemoveChild((UIElement) this._deleteButton);
      }
      else
      {
        this._buttonLabel.SetText(Language.GetTextValue("UI.Favorite"));
        this.Append((UIElement) this._deleteButton);
      }
      if (!(this.Parent.Parent is UIList parent))
        return;
      parent.UpdateOrder();
    }

    private void SeedButtonClick(UIMouseEvent evt, UIElement listeningElement)
    {
      ((Platform) Platform.Current).Clipboard = this._data.SeedText;
      this._buttonLabel.SetText(Language.GetTextValue("UI.SeedCopied"));
    }

    public override int CompareTo(object obj)
    {
      if (!(obj is UIWorldListItem uiWorldListItem))
        return base.CompareTo(obj);
      if (this.IsFavorite && !uiWorldListItem.IsFavorite)
        return -1;
      if (!this.IsFavorite && uiWorldListItem.IsFavorite)
        return 1;
      return this._data.Name.CompareTo(uiWorldListItem._data.Name) != 0 ? this._data.Name.CompareTo(uiWorldListItem._data.Name) : this._data.GetFileName().CompareTo(uiWorldListItem._data.GetFileName());
    }

    public override void MouseOver(UIMouseEvent evt)
    {
      base.MouseOver(evt);
      this.BackgroundColor = new Color(73, 94, 171);
      this.BorderColor = new Color(89, 116, 213);
    }

    public override void MouseOut(UIMouseEvent evt)
    {
      base.MouseOut(evt);
      this.BackgroundColor = new Color(63, 82, 151) * 0.7f;
      this.BorderColor = new Color(89, 116, 213) * 0.7f;
    }

    private void DrawPanel(SpriteBatch spriteBatch, Vector2 position, float width)
    {
      spriteBatch.Draw(this._innerPanelTexture, position, new Rectangle?(new Rectangle(0, 0, 8, this._innerPanelTexture.Height)), Color.White);
      spriteBatch.Draw(this._innerPanelTexture, new Vector2(position.X + 8f, position.Y), new Rectangle?(new Rectangle(8, 0, 8, this._innerPanelTexture.Height)), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (((double) width - 16.0) / 8.0), 1f), SpriteEffects.None, 0.0f);
      spriteBatch.Draw(this._innerPanelTexture, new Vector2((float) ((double) position.X + (double) width - 8.0), position.Y), new Rectangle?(new Rectangle(16, 0, 8, this._innerPanelTexture.Height)), Color.White);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      base.DrawSelf(spriteBatch);
      CalculatedStyle innerDimensions = this.GetInnerDimensions();
      CalculatedStyle dimensions = this._worldIcon.GetDimensions();
      float x1 = dimensions.X + dimensions.Width;
      Color color = this._data.IsValid ? Color.White : Color.Red;
      Utils.DrawBorderString(spriteBatch, this._data.Name, new Vector2(x1 + 6f, dimensions.Y - 2f), color);
      spriteBatch.Draw(this._dividerTexture, new Vector2(x1, innerDimensions.Y + 21f), new Rectangle?(), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (((double) this.GetDimensions().X + (double) this.GetDimensions().Width - (double) x1) / 8.0), 1f), SpriteEffects.None, 0.0f);
      Vector2 position = new Vector2(x1 + 6f, innerDimensions.Y + 29f);
      float width1 = 100f;
      this.DrawPanel(spriteBatch, position, width1);
      string text = this._data.IsExpertMode ? Language.GetTextValue("UI.Expert") : Language.GetTextValue("UI.Normal");
      float x2 = Main.fontMouseText.MeasureString(text).X;
      float x3 = (float) ((double) width1 * 0.5 - (double) x2 * 0.5);
      Utils.DrawBorderString(spriteBatch, text, position + new Vector2(x3, 3f), this._data.IsExpertMode ? new Color(217, 143, 244) : Color.White);
      position.X += width1 + 5f;
      float width2 = 150f;
      if (!GameCulture.English.IsActive)
        width2 += 40f;
      this.DrawPanel(spriteBatch, position, width2);
      string textValue1 = Language.GetTextValue("UI.WorldSizeFormat", (object) this._data.WorldSizeName);
      float x4 = Main.fontMouseText.MeasureString(textValue1).X;
      float x5 = (float) ((double) width2 * 0.5 - (double) x4 * 0.5);
      Utils.DrawBorderString(spriteBatch, textValue1, position + new Vector2(x5, 3f), Color.White);
      position.X += width2 + 5f;
      float width3 = innerDimensions.X + innerDimensions.Width - position.X;
      this.DrawPanel(spriteBatch, position, width3);
      string textValue2 = Language.GetTextValue("UI.WorldCreatedFormat", !GameCulture.English.IsActive ? (object) this._data.CreationTime.ToShortDateString() : (object) this._data.CreationTime.ToString("d MMMM yyyy"));
      float x6 = Main.fontMouseText.MeasureString(textValue2).X;
      float x7 = (float) ((double) width3 * 0.5 - (double) x6 * 0.5);
      Utils.DrawBorderString(spriteBatch, textValue2, position + new Vector2(x7, 3f), Color.White);
      position.X += width3 + 5f;
    }
  }
}
