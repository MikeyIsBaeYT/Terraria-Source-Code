// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Events.ScreenDarkness
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.Events
{
  public class ScreenDarkness
  {
    public static float screenObstruction;

    public static void Update()
    {
      float num = 0.0f;
      float amount = 0.1f;
      Vector2 mountedCenter = Main.player[Main.myPlayer].MountedCenter;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == 370 && (double) Main.npc[index].Distance(mountedCenter) < 3000.0 && ((double) Main.npc[index].ai[0] >= 10.0 || (double) Main.npc[index].ai[0] == 9.0 && (double) Main.npc[index].ai[2] > 120.0))
        {
          num = 0.95f;
          amount = 0.03f;
        }
      }
      ScreenDarkness.screenObstruction = MathHelper.Lerp(ScreenDarkness.screenObstruction, num, amount);
    }

    public static void DrawBack(SpriteBatch spriteBatch)
    {
      if ((double) ScreenDarkness.screenObstruction == 0.0)
        return;
      Color color = Color.Black * ScreenDarkness.screenObstruction;
      spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), color);
    }

    public static void DrawFront(SpriteBatch spriteBatch)
    {
      if ((double) ScreenDarkness.screenObstruction == 0.0)
        return;
      Color color = new Color(0, 0, 120) * ScreenDarkness.screenObstruction * 0.3f;
      spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), color);
    }
  }
}
