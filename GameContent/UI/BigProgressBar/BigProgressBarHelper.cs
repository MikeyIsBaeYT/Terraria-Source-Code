// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.BigProgressBarHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class BigProgressBarHelper
  {
    private const string _bossBarTexturePath = "Images/UI/UI_BossBar";

    public static void DrawBareBonesBar(SpriteBatch spriteBatch, float lifePercent)
    {
      Rectangle destinationRectangle1 = Utils.CenteredRectangle(Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2(0.0f, -50f), new Vector2(400f, 20f));
      Rectangle destinationRectangle2 = destinationRectangle1;
      destinationRectangle2.Inflate(2, 2);
      Texture2D texture = TextureAssets.MagicPixel.Value;
      Rectangle rectangle = new Rectangle(0, 0, 1, 1);
      Rectangle destinationRectangle3 = destinationRectangle1;
      destinationRectangle3.Width = (int) ((double) destinationRectangle3.Width * (double) lifePercent);
      spriteBatch.Draw(texture, destinationRectangle2, new Rectangle?(rectangle), Color.White * 0.6f);
      spriteBatch.Draw(texture, destinationRectangle1, new Rectangle?(rectangle), Color.Black * 0.6f);
      spriteBatch.Draw(texture, destinationRectangle3, new Rectangle?(rectangle), Color.LimeGreen * 0.5f);
    }

    public static void DrawFancyBar(
      SpriteBatch spriteBatch,
      float lifePercent,
      Texture2D barIconTexture,
      Rectangle barIconFrame)
    {
      Texture2D texture2D = Main.Assets.Request<Texture2D>("Images/UI/UI_BossBar", (AssetRequestMode) 1).Value;
      Point p1 = new Point(456, 22);
      Point p2 = new Point(32, 24);
      int verticalFrames = 6;
      Rectangle rectangle1 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 3);
      Color color = Color.White * 0.2f;
      int num1 = (int) ((double) p1.X * (double) lifePercent);
      int num2 = num1 - num1 % 2;
      Rectangle rectangle2 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 2);
      rectangle2.X += p2.X;
      rectangle2.Y += p2.Y;
      rectangle2.Width = 2;
      rectangle2.Height = p1.Y;
      Rectangle rectangle3 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 1);
      rectangle3.X += p2.X;
      rectangle3.Y += p2.Y;
      rectangle3.Width = 2;
      rectangle3.Height = p1.Y;
      Rectangle r = Utils.CenteredRectangle(Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2(0.0f, -50f), p1.ToVector2());
      Vector2 position = r.TopLeft() - p2.ToVector2();
      spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle1), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture2D, r.TopLeft(), new Rectangle?(rectangle2), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (num2 / rectangle2.Width), 1f), SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture2D, r.TopLeft() + new Vector2((float) (num2 - 2), 0.0f), new Rectangle?(rectangle3), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      Rectangle rectangle4 = texture2D.Frame(verticalFrames: verticalFrames);
      spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle4), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      Vector2 vector2 = new Vector2(4f, 20f) + new Vector2(26f, 28f) / 2f;
      spriteBatch.Draw(barIconTexture, position + vector2, new Rectangle?(barIconFrame), Color.White, 0.0f, barIconFrame.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
    }

    public static void DrawFancyBar(
      SpriteBatch spriteBatch,
      float lifePercent,
      Texture2D barIconTexture,
      Rectangle barIconFrame,
      float shieldPercent)
    {
      Texture2D texture2D = Main.Assets.Request<Texture2D>("Images/UI/UI_BossBar", (AssetRequestMode) 1).Value;
      Point p1 = new Point(456, 22);
      Point p2 = new Point(32, 24);
      int verticalFrames = 6;
      Rectangle rectangle1 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 3);
      Color color = Color.White * 0.2f;
      int num1 = (int) ((double) p1.X * (double) lifePercent);
      int num2 = num1 - num1 % 2;
      Rectangle rectangle2 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 2);
      rectangle2.X += p2.X;
      rectangle2.Y += p2.Y;
      rectangle2.Width = 2;
      rectangle2.Height = p1.Y;
      Rectangle rectangle3 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 1);
      rectangle3.X += p2.X;
      rectangle3.Y += p2.Y;
      rectangle3.Width = 2;
      rectangle3.Height = p1.Y;
      int num3 = (int) ((double) p1.X * (double) shieldPercent);
      int num4 = num3 - num3 % 2;
      Rectangle rectangle4 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 5);
      rectangle4.X += p2.X;
      rectangle4.Y += p2.Y;
      rectangle4.Width = 2;
      rectangle4.Height = p1.Y;
      Rectangle rectangle5 = texture2D.Frame(verticalFrames: verticalFrames, frameY: 4);
      rectangle5.X += p2.X;
      rectangle5.Y += p2.Y;
      rectangle5.Width = 2;
      rectangle5.Height = p1.Y;
      Rectangle r = Utils.CenteredRectangle(Main.ScreenSize.ToVector2() * new Vector2(0.5f, 1f) + new Vector2(0.0f, -50f), p1.ToVector2());
      Vector2 position = r.TopLeft() - p2.ToVector2();
      spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle1), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture2D, r.TopLeft(), new Rectangle?(rectangle2), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (num2 / rectangle2.Width), 1f), SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture2D, r.TopLeft() + new Vector2((float) (num2 - 2), 0.0f), new Rectangle?(rectangle3), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture2D, r.TopLeft(), new Rectangle?(rectangle4), Color.White, 0.0f, Vector2.Zero, new Vector2((float) (num4 / rectangle4.Width), 1f), SpriteEffects.None, 0.0f);
      spriteBatch.Draw(texture2D, r.TopLeft() + new Vector2((float) (num4 - 2), 0.0f), new Rectangle?(rectangle5), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      Rectangle rectangle6 = texture2D.Frame(verticalFrames: verticalFrames);
      spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle6), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      Vector2 vector2 = new Vector2(4f, 20f) + barIconFrame.Size() / 2f;
      spriteBatch.Draw(barIconTexture, position + vector2, new Rectangle?(barIconFrame), Color.White, 0.0f, barIconFrame.Size() / 2f, 1f, SpriteEffects.None, 0.0f);
    }
  }
}
