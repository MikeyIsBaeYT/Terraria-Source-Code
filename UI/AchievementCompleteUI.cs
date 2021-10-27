// Decompiled with JetBrains decompiler
// Type: Terraria.UI.AchievementCompleteUI
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Achievements;
using Terraria.GameInput;
using Terraria.Graphics;

namespace Terraria.UI
{
  public class AchievementCompleteUI
  {
    private static Texture2D AchievementsTexture;
    private static Texture2D AchievementsTextureBorder;
    private static List<AchievementCompleteUI.DrawCache> caches = new List<AchievementCompleteUI.DrawCache>();

    public static void LoadContent()
    {
      AchievementCompleteUI.AchievementsTexture = TextureManager.Load("Images/UI/Achievements");
      AchievementCompleteUI.AchievementsTextureBorder = TextureManager.Load("Images/UI/Achievement_Borders");
    }

    public static void Initialize() => Main.Achievements.OnAchievementCompleted += new Achievement.AchievementCompleted(AchievementCompleteUI.AddCompleted);

    public static void Draw(SpriteBatch sb)
    {
      float y = (float) (Main.screenHeight - 40);
      if (PlayerInput.UsingGamepad)
        y -= 25f;
      Vector2 center = new Vector2((float) (Main.screenWidth / 2), y);
      foreach (AchievementCompleteUI.DrawCache cach in AchievementCompleteUI.caches)
      {
        AchievementCompleteUI.DrawAchievement(sb, ref center, cach);
        if ((double) center.Y < -100.0)
          break;
      }
    }

    public static void AddCompleted(Achievement achievement)
    {
      if (Main.netMode == 2)
        return;
      AchievementCompleteUI.caches.Add(new AchievementCompleteUI.DrawCache(achievement));
    }

    public static void Clear() => AchievementCompleteUI.caches.Clear();

    public static void Update()
    {
      foreach (AchievementCompleteUI.DrawCache cach in AchievementCompleteUI.caches)
        cach.Update();
      for (int index = 0; index < AchievementCompleteUI.caches.Count; ++index)
      {
        if (AchievementCompleteUI.caches[index].TimeLeft == 0)
        {
          AchievementCompleteUI.caches.Remove(AchievementCompleteUI.caches[index]);
          --index;
        }
      }
    }

    private static void DrawAchievement(
      SpriteBatch sb,
      ref Vector2 center,
      AchievementCompleteUI.DrawCache ach)
    {
      float alpha = ach.Alpha;
      if ((double) alpha > 0.0)
      {
        string title = ach.Title;
        Vector2 center1 = center;
        Vector2 vector2 = Main.fontItemStack.MeasureString(title);
        float num1 = ach.Scale * 1.1f;
        Vector2 size = (vector2 + new Vector2(58f, 10f)) * num1;
        Rectangle rectangle = Utils.CenteredRectangle(center1, size);
        Vector2 mouseScreen = Main.MouseScreen;
        int num2 = rectangle.Contains(mouseScreen.ToPoint()) ? 1 : 0;
        Color c = num2 != 0 ? new Color(64, 109, 164) * 0.75f : new Color(64, 109, 164) * 0.5f;
        Utils.DrawInvBG(sb, rectangle, c);
        float scale = num1 * 0.3f;
        Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor / 5, (int) Main.mouseTextColor);
        Vector2 position = rectangle.Right() - Vector2.UnitX * num1 * (float) (12.0 + (double) scale * (double) ach.Frame.Width);
        sb.Draw(AchievementCompleteUI.AchievementsTexture, position, new Rectangle?(ach.Frame), Color.White * alpha, 0.0f, new Vector2(0.0f, (float) (ach.Frame.Height / 2)), scale, SpriteEffects.None, 0.0f);
        sb.Draw(AchievementCompleteUI.AchievementsTextureBorder, position, new Rectangle?(), Color.White * alpha, 0.0f, new Vector2(0.0f, (float) (ach.Frame.Height / 2)), scale, SpriteEffects.None, 0.0f);
        Utils.DrawBorderString(sb, title, position - Vector2.UnitX * 10f, color * alpha, num1 * 0.9f, 1f, 0.4f);
        if (num2 != 0 && !PlayerInput.IgnoreMouseInterface)
        {
          Main.player[Main.myPlayer].mouseInterface = true;
          if (Main.mouseLeft && Main.mouseLeftRelease)
          {
            IngameFancyUI.OpenAchievementsAndGoto(ach.theAchievement);
            ach.TimeLeft = 0;
          }
        }
      }
      ach.ApplyHeight(ref center);
    }

    public class DrawCache
    {
      public Achievement theAchievement;
      private const int _iconSize = 64;
      private const int _iconSizeWithSpace = 66;
      private const int _iconsPerRow = 8;
      public int IconIndex;
      public Rectangle Frame;
      public string Title;
      public int TimeLeft;

      public void Update()
      {
        --this.TimeLeft;
        if (this.TimeLeft >= 0)
          return;
        this.TimeLeft = 0;
      }

      public DrawCache(Achievement achievement)
      {
        this.theAchievement = achievement;
        this.Title = achievement.FriendlyName.Value;
        int iconIndex = Main.Achievements.GetIconIndex(achievement.Name);
        this.IconIndex = iconIndex;
        this.Frame = new Rectangle(iconIndex % 8 * 66, iconIndex / 8 * 66, 64, 64);
        this.TimeLeft = 300;
      }

      public float Scale
      {
        get
        {
          if (this.TimeLeft < 30)
            return MathHelper.Lerp(0.0f, 1f, (float) this.TimeLeft / 30f);
          return this.TimeLeft > 285 ? MathHelper.Lerp(1f, 0.0f, (float) (((double) this.TimeLeft - 285.0) / 15.0)) : 1f;
        }
      }

      public float Alpha
      {
        get
        {
          float scale = this.Scale;
          return (double) scale <= 0.5 ? 0.0f : (float) (((double) scale - 0.5) / 0.5);
        }
      }

      public void ApplyHeight(ref Vector2 v) => v.Y -= 50f * this.Alpha;
    }
  }
}
