// Decompiled with JetBrains decompiler
// Type: Terraria.UI.InGamePopups
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Achievements;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Social.Base;

namespace Terraria.UI
{
  public class InGamePopups
  {
    public class AchievementUnlockedPopup : IInGameNotification
    {
      private Achievement _theAchievement;
      private Asset<Texture2D> _achievementTexture;
      private Asset<Texture2D> _achievementBorderTexture;
      private const int _iconSize = 64;
      private const int _iconSizeWithSpace = 66;
      private const int _iconsPerRow = 8;
      private int _iconIndex;
      private Rectangle _achievementIconFrame;
      private string _title;
      private int _ingameDisplayTimeLeft;

      public bool ShouldBeRemoved { get; private set; }

      public object CreationObject { get; private set; }

      public AchievementUnlockedPopup(Achievement achievement)
      {
        this.CreationObject = (object) achievement;
        this._ingameDisplayTimeLeft = 300;
        this._theAchievement = achievement;
        this._title = achievement.FriendlyName.Value;
        int iconIndex = Main.Achievements.GetIconIndex(achievement.Name);
        this._iconIndex = iconIndex;
        this._achievementIconFrame = new Rectangle(iconIndex % 8 * 66, iconIndex / 8 * 66, 64, 64);
        this._achievementTexture = Main.Assets.Request<Texture2D>("Images/UI/Achievements", (AssetRequestMode) 2);
        this._achievementBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/Achievement_Borders", (AssetRequestMode) 2);
      }

      public void Update()
      {
        --this._ingameDisplayTimeLeft;
        if (this._ingameDisplayTimeLeft >= 0)
          return;
        this._ingameDisplayTimeLeft = 0;
      }

      private float Scale
      {
        get
        {
          if (this._ingameDisplayTimeLeft < 30)
            return MathHelper.Lerp(0.0f, 1f, (float) this._ingameDisplayTimeLeft / 30f);
          return this._ingameDisplayTimeLeft > 285 ? MathHelper.Lerp(1f, 0.0f, (float) (((double) this._ingameDisplayTimeLeft - 285.0) / 15.0)) : 1f;
        }
      }

      private float Opacity
      {
        get
        {
          float scale = this.Scale;
          return (double) scale <= 0.5 ? 0.0f : (float) (((double) scale - 0.5) / 0.5);
        }
      }

      public void PushAnchor(ref Vector2 anchorPosition)
      {
        float num = 50f * this.Opacity;
        anchorPosition.Y -= num;
      }

      public void DrawInGame(SpriteBatch sb, Vector2 bottomAnchorPosition)
      {
        float opacity = this.Opacity;
        if ((double) opacity <= 0.0)
          return;
        float num1 = this.Scale * 1.1f;
        Vector2 size = (FontAssets.ItemStack.Value.MeasureString(this._title) + new Vector2(58f, 10f)) * num1;
        Rectangle rectangle = Utils.CenteredRectangle(bottomAnchorPosition + new Vector2(0.0f, (float) (-(double) size.Y * 0.5)), size);
        Vector2 mouseScreen = Main.MouseScreen;
        int num2 = rectangle.Contains(mouseScreen.ToPoint()) ? 1 : 0;
        Color c = num2 != 0 ? new Color(64, 109, 164) * 0.75f : new Color(64, 109, 164) * 0.5f;
        Utils.DrawInvBG(sb, rectangle, c);
        float scale = num1 * 0.3f;
        Vector2 position = rectangle.Right() - Vector2.UnitX * num1 * (float) (12.0 + (double) scale * (double) this._achievementIconFrame.Width);
        sb.Draw(this._achievementTexture.Value, position, new Rectangle?(this._achievementIconFrame), Color.White * opacity, 0.0f, new Vector2(0.0f, (float) (this._achievementIconFrame.Height / 2)), scale, SpriteEffects.None, 0.0f);
        sb.Draw(this._achievementBorderTexture.Value, position, new Rectangle?(), Color.White * opacity, 0.0f, new Vector2(0.0f, (float) (this._achievementIconFrame.Height / 2)), scale, SpriteEffects.None, 0.0f);
        Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor / 5, (int) Main.mouseTextColor);
        Utils.DrawBorderString(sb, this._title, position - Vector2.UnitX * 10f, color * opacity, num1 * 0.9f, 1f, 0.4f);
        if (num2 == 0)
          return;
        this.OnMouseOver();
      }

      private void OnMouseOver()
      {
        if (PlayerInput.IgnoreMouseInterface)
          return;
        Main.player[Main.myPlayer].mouseInterface = true;
        if (!Main.mouseLeft || !Main.mouseLeftRelease)
          return;
        Main.mouseLeftRelease = false;
        IngameFancyUI.OpenAchievementsAndGoto(this._theAchievement);
        this._ingameDisplayTimeLeft = 0;
        this.ShouldBeRemoved = true;
      }

      public void DrawInNotificationsArea(
        SpriteBatch spriteBatch,
        Rectangle area,
        ref int gamepadPointLocalIndexTouse)
      {
        Utils.DrawInvBG(spriteBatch, area, Color.Red);
      }
    }

    public class PlayerWantsToJoinGamePopup : IInGameNotification
    {
      private int _timeLeft;
      private const int _timeLeftMax = 1800;
      private string _displayTextWithoutTime;
      private UserJoinToServerRequest _request;

      private float Scale
      {
        get
        {
          if (this._timeLeft < 30)
            return MathHelper.Lerp(0.0f, 1f, (float) this._timeLeft / 30f);
          return this._timeLeft > 1785 ? MathHelper.Lerp(1f, 0.0f, (float) (((double) this._timeLeft - 1785.0) / 15.0)) : 1f;
        }
      }

      private float Opacity
      {
        get
        {
          float scale = this.Scale;
          return (double) scale <= 0.5 ? 0.0f : (float) (((double) scale - 0.5) / 0.5);
        }
      }

      public object CreationObject { get; private set; }

      public PlayerWantsToJoinGamePopup(UserJoinToServerRequest request)
      {
        this._request = request;
        this.CreationObject = (object) request;
        this._timeLeft = 1800;
        switch (Main.rand.Next(5))
        {
          case 1:
            this._displayTextWithoutTime = "This Fucker Wants to Join you";
            break;
          case 2:
            this._displayTextWithoutTime = "This Weirdo Wants to Join you";
            break;
          case 3:
            this._displayTextWithoutTime = "This Great Gal Wants to Join you";
            break;
          case 4:
            this._displayTextWithoutTime = "The one guy who beat you up 30 years ago Wants to Join you";
            break;
          default:
            this._displayTextWithoutTime = "This Bloke Wants to Join you";
            break;
        }
      }

      public bool ShouldBeRemoved => this._timeLeft <= 0;

      public void Update() => --this._timeLeft;

      public void DrawInGame(SpriteBatch spriteBatch, Vector2 bottomAnchorPosition)
      {
        float opacity = this.Opacity;
        if ((double) opacity <= 0.0)
          return;
        string text = Utils.FormatWith(this._request.GetUserWrapperText(), (object) new
        {
          DisplayName = this._request.UserDisplayName,
          FullId = this._request.UserFullIdentifier
        });
        float num = this.Scale * 1.1f;
        Vector2 size = (FontAssets.ItemStack.Value.MeasureString(text) + new Vector2(58f, 10f)) * num;
        Rectangle R = Utils.CenteredRectangle(bottomAnchorPosition + new Vector2(0.0f, (float) (-(double) size.Y * 0.5)), size);
        Vector2 mouseScreen = Main.MouseScreen;
        Color c = R.Contains(mouseScreen.ToPoint()) ? new Color(64, 109, 164) * 0.75f : new Color(64, 109, 164) * 0.5f;
        Utils.DrawInvBG(spriteBatch, R, c);
        new Vector2((float) R.Left, (float) R.Center.Y).X += 32f;
        Texture2D texture2D1 = Main.Assets.Request<Texture2D>("Images/UI/ButtonPlay", (AssetRequestMode) 1).Value;
        Vector2 position = new Vector2((float) (R.Left + 7), (float) ((double) MathHelper.Lerp((float) R.Top, (float) R.Bottom, 0.5f) - (double) (texture2D1.Height / 2) - 1.0));
        bool flag1 = Utils.CenteredRectangle(position + new Vector2((float) (texture2D1.Width / 2), 0.0f), texture2D1.Size()).Contains(mouseScreen.ToPoint());
        spriteBatch.Draw(texture2D1, position, new Rectangle?(), Color.White * (flag1 ? 1f : 0.5f), 0.0f, new Vector2(0.0f, 0.5f) * texture2D1.Size(), 1f, SpriteEffects.None, 0.0f);
        if (flag1)
          this.OnMouseOver();
        Texture2D texture2D2 = Main.Assets.Request<Texture2D>("Images/UI/ButtonDelete", (AssetRequestMode) 1).Value;
        position = new Vector2((float) (R.Left + 7), (float) ((double) MathHelper.Lerp((float) R.Top, (float) R.Bottom, 0.5f) + (double) (texture2D2.Height / 2) + 1.0));
        bool flag2 = Utils.CenteredRectangle(position + new Vector2((float) (texture2D2.Width / 2), 0.0f), texture2D2.Size()).Contains(mouseScreen.ToPoint());
        spriteBatch.Draw(texture2D2, position, new Rectangle?(), Color.White * (flag2 ? 1f : 0.5f), 0.0f, new Vector2(0.0f, 0.5f) * texture2D2.Size(), 1f, SpriteEffects.None, 0.0f);
        if (flag2)
          this.OnMouseOver(true);
        Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor / 5, (int) Main.mouseTextColor);
        Utils.DrawBorderString(spriteBatch, text, R.Center.ToVector2() + new Vector2(10f, 0.0f), color * opacity, num * 0.9f, 0.5f, 0.4f);
      }

      private void OnMouseOver(bool reject = false)
      {
        if (PlayerInput.IgnoreMouseInterface)
          return;
        Main.player[Main.myPlayer].mouseInterface = true;
        if (!Main.mouseLeft || !Main.mouseLeftRelease)
          return;
        Main.mouseLeftRelease = false;
        this._timeLeft = 0;
        if (reject)
          this._request.Reject();
        else
          this._request.Accept();
      }

      public void PushAnchor(ref Vector2 positionAnchorBottom)
      {
        float num = 70f * this.Opacity;
        positionAnchorBottom.Y -= num;
      }

      public void DrawInNotificationsArea(
        SpriteBatch spriteBatch,
        Rectangle area,
        ref int gamepadPointLocalIndexTouse)
      {
        string userWrapperText = this._request.GetUserWrapperText();
        string userDisplayName = this._request.UserDisplayName;
        Utils.TrimTextIfNeeded(ref userDisplayName, FontAssets.MouseText.Value, 0.9f, (float) (area.Width / 4));
        var data = new
        {
          DisplayName = userDisplayName,
          FullId = this._request.UserFullIdentifier
        };
        string text = Utils.FormatWith(userWrapperText, (object) data);
        Vector2 mouseScreen = Main.MouseScreen;
        Color c = area.Contains(mouseScreen.ToPoint()) ? new Color(64, 109, 164) * 0.75f : new Color(64, 109, 164) * 0.5f;
        Utils.DrawInvBG(spriteBatch, area, c);
        Vector2 pos = new Vector2((float) area.Left, (float) area.Center.Y);
        pos.X += 32f;
        Texture2D texture2D1 = Main.Assets.Request<Texture2D>("Images/UI/ButtonPlay", (AssetRequestMode) 1).Value;
        Vector2 position = new Vector2((float) (area.Left + 7), (float) ((double) MathHelper.Lerp((float) area.Top, (float) area.Bottom, 0.5f) - (double) (texture2D1.Height / 2) - 1.0));
        bool flag1 = Utils.CenteredRectangle(position + new Vector2((float) (texture2D1.Width / 2), 0.0f), texture2D1.Size()).Contains(mouseScreen.ToPoint());
        spriteBatch.Draw(texture2D1, position, new Rectangle?(), Color.White * (flag1 ? 1f : 0.5f), 0.0f, new Vector2(0.0f, 0.5f) * texture2D1.Size(), 1f, SpriteEffects.None, 0.0f);
        if (flag1)
          this.OnMouseOver();
        Texture2D texture2D2 = Main.Assets.Request<Texture2D>("Images/UI/ButtonDelete", (AssetRequestMode) 1).Value;
        position = new Vector2((float) (area.Left + 7), (float) ((double) MathHelper.Lerp((float) area.Top, (float) area.Bottom, 0.5f) + (double) (texture2D2.Height / 2) + 1.0));
        bool flag2 = Utils.CenteredRectangle(position + new Vector2((float) (texture2D2.Width / 2), 0.0f), texture2D2.Size()).Contains(mouseScreen.ToPoint());
        spriteBatch.Draw(texture2D2, position, new Rectangle?(), Color.White * (flag2 ? 1f : 0.5f), 0.0f, new Vector2(0.0f, 0.5f) * texture2D2.Size(), 1f, SpriteEffects.None, 0.0f);
        if (flag2)
          this.OnMouseOver(true);
        pos.X += 6f;
        Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor / 5, (int) Main.mouseTextColor);
        Utils.DrawBorderString(spriteBatch, text, pos, color, 0.9f, anchory: 0.4f);
      }
    }
  }
}
