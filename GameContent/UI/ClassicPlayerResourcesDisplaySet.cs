// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.ClassicPlayerResourcesDisplaySet
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;

namespace Terraria.GameContent.UI
{
  public class ClassicPlayerResourcesDisplaySet : IPlayerResourcesDisplaySet
  {
    private int UIDisplay_ManaPerStar = 20;
    private float UIDisplay_LifePerHeart = 20f;
    private int UI_ScreenAnchorX;

    public void Draw()
    {
      this.UI_ScreenAnchorX = Main.screenWidth - 800;
      this.DrawLife();
      this.DrawMana();
    }

    private void DrawLife()
    {
      Player localPlayer = Main.LocalPlayer;
      SpriteBatch spriteBatch = Main.spriteBatch;
      Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      this.UIDisplay_LifePerHeart = 20f;
      if (localPlayer.ghost)
        return;
      int num1 = localPlayer.statLifeMax / 20;
      int num2 = (localPlayer.statLifeMax - 400) / 5;
      if (num2 < 0)
        num2 = 0;
      if (num2 > 0)
      {
        num1 = localPlayer.statLifeMax / (20 + num2 / 4);
        this.UIDisplay_LifePerHeart = (float) localPlayer.statLifeMax / 20f;
      }
      this.UIDisplay_LifePerHeart += (float) ((localPlayer.statLifeMax2 - localPlayer.statLifeMax) / num1);
      int num3 = (int) ((double) localPlayer.statLifeMax2 / (double) this.UIDisplay_LifePerHeart);
      if (num3 >= 10)
        num3 = 10;
      string str = Lang.inter[0].Value + " " + (object) localPlayer.statLifeMax2 + "/" + (object) localPlayer.statLifeMax2;
      Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(str);
      if (!localPlayer.ghost)
      {
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, Lang.inter[0].Value, new Vector2((float) (500 + 13 * num3) - vector2.X * 0.5f + (float) this.UI_ScreenAnchorX, 6f), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2, new Vector2((float) (500 + 13 * num3) + vector2.X * 0.5f + (float) this.UI_ScreenAnchorX, 6f), color, 0.0f, new Vector2(FontAssets.MouseText.Value.MeasureString(localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2).X, 0.0f), 1f, SpriteEffects.None, 0.0f);
      }
      for (int index = 1; index < (int) ((double) localPlayer.statLifeMax2 / (double) this.UIDisplay_LifePerHeart) + 1; ++index)
      {
        float scale = 1f;
        bool flag = false;
        int num4;
        if ((double) localPlayer.statLife >= (double) index * (double) this.UIDisplay_LifePerHeart)
        {
          num4 = (int) byte.MaxValue;
          if ((double) localPlayer.statLife == (double) index * (double) this.UIDisplay_LifePerHeart)
            flag = true;
        }
        else
        {
          float num5 = ((float) localPlayer.statLife - (float) (index - 1) * this.UIDisplay_LifePerHeart) / this.UIDisplay_LifePerHeart;
          num4 = (int) (30.0 + 225.0 * (double) num5);
          if (num4 < 30)
            num4 = 30;
          scale = (float) ((double) num5 / 4.0 + 0.75);
          if ((double) scale < 0.75)
            scale = 0.75f;
          if ((double) num5 > 0.0)
            flag = true;
        }
        if (flag)
          scale += Main.cursorScale - 1f;
        int num6 = 0;
        int num7 = 0;
        if (index > 10)
        {
          num6 -= 260;
          num7 += 26;
        }
        int a = (int) ((double) num4 * 0.9);
        if (!localPlayer.ghost)
        {
          if (num2 > 0)
          {
            --num2;
            spriteBatch.Draw(TextureAssets.Heart2.Value, new Vector2((float) (500 + 26 * (index - 1) + num6 + this.UI_ScreenAnchorX + TextureAssets.Heart.Width() / 2), (float) (32.0 + ((double) TextureAssets.Heart.Height() - (double) TextureAssets.Heart.Height() * (double) scale) / 2.0) + (float) num7 + (float) (TextureAssets.Heart.Height() / 2)), new Rectangle?(new Rectangle(0, 0, TextureAssets.Heart.Width(), TextureAssets.Heart.Height())), new Color(num4, num4, num4, a), 0.0f, new Vector2((float) (TextureAssets.Heart.Width() / 2), (float) (TextureAssets.Heart.Height() / 2)), scale, SpriteEffects.None, 0.0f);
          }
          else
            spriteBatch.Draw(TextureAssets.Heart.Value, new Vector2((float) (500 + 26 * (index - 1) + num6 + this.UI_ScreenAnchorX + TextureAssets.Heart.Width() / 2), (float) (32.0 + ((double) TextureAssets.Heart.Height() - (double) TextureAssets.Heart.Height() * (double) scale) / 2.0) + (float) num7 + (float) (TextureAssets.Heart.Height() / 2)), new Rectangle?(new Rectangle(0, 0, TextureAssets.Heart.Width(), TextureAssets.Heart.Height())), new Color(num4, num4, num4, a), 0.0f, new Vector2((float) (TextureAssets.Heart.Width() / 2), (float) (TextureAssets.Heart.Height() / 2)), scale, SpriteEffects.None, 0.0f);
        }
      }
    }

    private void DrawMana()
    {
      Player localPlayer = Main.LocalPlayer;
      SpriteBatch spriteBatch = Main.spriteBatch;
      Color color = new Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      this.UIDisplay_ManaPerStar = 20;
      if (localPlayer.ghost || localPlayer.statManaMax2 <= 0)
        return;
      int num1 = localPlayer.statManaMax2 / 20;
      Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(Lang.inter[2].Value);
      int num2 = 50;
      if ((double) vector2.X >= 45.0)
        num2 = (int) vector2.X + 5;
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, FontAssets.MouseText.Value, Lang.inter[2].Value, new Vector2((float) (800 - num2 + this.UI_ScreenAnchorX), 6f), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      for (int index = 1; index < localPlayer.statManaMax2 / this.UIDisplay_ManaPerStar + 1; ++index)
      {
        bool flag = false;
        float scale = 1f;
        int num3;
        if (localPlayer.statMana >= index * this.UIDisplay_ManaPerStar)
        {
          num3 = (int) byte.MaxValue;
          if (localPlayer.statMana == index * this.UIDisplay_ManaPerStar)
            flag = true;
        }
        else
        {
          float num4 = (float) (localPlayer.statMana - (index - 1) * this.UIDisplay_ManaPerStar) / (float) this.UIDisplay_ManaPerStar;
          num3 = (int) (30.0 + 225.0 * (double) num4);
          if (num3 < 30)
            num3 = 30;
          scale = (float) ((double) num4 / 4.0 + 0.75);
          if ((double) scale < 0.75)
            scale = 0.75f;
          if ((double) num4 > 0.0)
            flag = true;
        }
        if (flag)
          scale += Main.cursorScale - 1f;
        int a = (int) ((double) num3 * 0.9);
        spriteBatch.Draw(TextureAssets.Mana.Value, new Vector2((float) (775 + this.UI_ScreenAnchorX), (float) (30 + TextureAssets.Mana.Height() / 2) + (float) (((double) TextureAssets.Mana.Height() - (double) TextureAssets.Mana.Height() * (double) scale) / 2.0) + (float) (28 * (index - 1))), new Rectangle?(new Rectangle(0, 0, TextureAssets.Mana.Width(), TextureAssets.Mana.Height())), new Color(num3, num3, num3, a), 0.0f, new Vector2((float) (TextureAssets.Mana.Width() / 2), (float) (TextureAssets.Mana.Height() / 2)), scale, SpriteEffects.None, 0.0f);
      }
    }

    public void TryToHover()
    {
      Vector2 mouseScreen = Main.MouseScreen;
      Player localPlayer = Main.LocalPlayer;
      int num1 = 26 * localPlayer.statLifeMax2 / (int) this.UIDisplay_LifePerHeart;
      int num2 = 0;
      if (localPlayer.statLifeMax2 > 200)
      {
        num1 = 260;
        num2 += 26;
      }
      if ((double) mouseScreen.X > (double) (500 + this.UI_ScreenAnchorX) && (double) mouseScreen.X < (double) (500 + num1 + this.UI_ScreenAnchorX) && (double) mouseScreen.Y > 32.0 && (double) mouseScreen.Y < (double) (32 + TextureAssets.Heart.Height() + num2))
        CommonResourceBarMethods.DrawLifeMouseOver();
      int num3 = 24;
      int num4 = 28 * localPlayer.statManaMax2 / this.UIDisplay_ManaPerStar;
      if ((double) mouseScreen.X <= (double) (762 + this.UI_ScreenAnchorX) || (double) mouseScreen.X >= (double) (762 + num3 + this.UI_ScreenAnchorX) || (double) mouseScreen.Y <= 30.0 || (double) mouseScreen.Y >= (double) (30 + num4))
        return;
      CommonResourceBarMethods.DrawManaMouseOver();
    }
  }
}
