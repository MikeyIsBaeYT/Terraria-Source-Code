// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UICharacter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UICharacter : UIElement
  {
    private Player _player;
    private Asset<Texture2D> _texture;
    private static Item _blankItem = new Item();
    private bool _animated;
    private bool _drawsBackPanel;
    private float _characterScale = 1f;
    private int _animationCounter;

    public UICharacter(Player player, bool animated = false, bool hasBackPanel = true, float characterScale = 1f)
    {
      this._player = player;
      this.Width.Set(59f, 0.0f);
      this.Height.Set(58f, 0.0f);
      this._texture = Main.Assets.Request<Texture2D>("Images/UI/PlayerBackground", (AssetRequestMode) 1);
      this.UseImmediateMode = true;
      this._animated = animated;
      this._drawsBackPanel = hasBackPanel;
      this._characterScale = characterScale;
      this.OverrideSamplerState = SamplerState.PointClamp;
    }

    public override void Update(GameTime gameTime)
    {
      this._player.ResetEffects();
      this._player.ResetVisibleAccessories();
      this._player.UpdateMiscCounter();
      this._player.UpdateDyes();
      this._player.PlayerFrame();
      if (this._animated)
        ++this._animationCounter;
      base.Update(gameTime);
    }

    private void UpdateAnim()
    {
      if (!this._animated)
      {
        this._player.bodyFrame.Y = this._player.legFrame.Y = this._player.headFrame.Y = 0;
      }
      else
      {
        this._player.bodyFrame.Y = this._player.legFrame.Y = this._player.headFrame.Y = ((int) ((double) Main.GlobalTimeWrappedHourly / 0.0700000002980232) % 14 + 6) * 56;
        this._player.WingFrame(false);
      }
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      if (this._drawsBackPanel)
        spriteBatch.Draw(this._texture.Value, dimensions.Position(), Color.White);
      this.UpdateAnim();
      Vector2 vector2 = dimensions.Position() + new Vector2(dimensions.Width * 0.5f - (float) (this._player.width >> 1), dimensions.Height * 0.5f - (float) (this._player.height >> 1));
      Item obj = this._player.inventory[this._player.selectedItem];
      this._player.inventory[this._player.selectedItem] = UICharacter._blankItem;
      Main.PlayerRenderer.DrawPlayer(Main.Camera, this._player, vector2 + Main.screenPosition, 0.0f, Vector2.Zero, scale: this._characterScale);
      this._player.inventory[this._player.selectedItem] = obj;
    }

    public void SetAnimated(bool animated) => this._animated = animated;

    public bool IsAnimated => this._animated;
  }
}
