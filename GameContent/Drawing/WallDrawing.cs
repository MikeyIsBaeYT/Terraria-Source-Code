// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.WallDrawing
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Terraria.Graphics;
using Terraria.ID;

namespace Terraria.GameContent.Drawing
{
  public class WallDrawing
  {
    private static VertexColors _glowPaintColors = new VertexColors(Color.White);
    private Tile[,] _tileArray;
    private TilePaintSystemV2 _paintSystem;

    public WallDrawing(TilePaintSystemV2 paintSystem) => this._paintSystem = paintSystem;

    public void DrawWalls()
    {
      float gfxQuality = Main.gfxQuality;
      int offScreenRange = Main.offScreenRange;
      int num1 = Main.drawToScreen ? 1 : 0;
      Vector2 screenPosition = Main.screenPosition;
      int screenWidth = Main.screenWidth;
      int screenHeight = Main.screenHeight;
      int maxTilesX = Main.maxTilesX;
      int maxTilesY = Main.maxTilesY;
      int[] wallBlend = Main.wallBlend;
      SpriteBatch spriteBatch = Main.spriteBatch;
      TileBatch tileBatch = Main.tileBatch;
      this._tileArray = Main.tile;
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num2;
      int num3 = (int) ((double) (num2 = (int) (120.0 * (1.0 - (double) gfxQuality) + 40.0 * (double) gfxQuality)) * 0.400000005960464);
      int num4 = (int) ((double) num2 * 0.349999994039536);
      int num5 = (int) ((double) num2 * 0.300000011920929);
      Vector2 vector2 = new Vector2((float) offScreenRange, (float) offScreenRange);
      if (num1 != 0)
        vector2 = Vector2.Zero;
      int num6 = (int) (((double) screenPosition.X - (double) vector2.X) / 16.0 - 1.0);
      int num7 = (int) (((double) screenPosition.X + (double) screenWidth + (double) vector2.X) / 16.0) + 2;
      int num8 = (int) (((double) screenPosition.Y - (double) vector2.Y) / 16.0 - 1.0);
      int num9 = (int) (((double) screenPosition.Y + (double) screenHeight + (double) vector2.Y) / 16.0) + 5;
      int num10 = offScreenRange / 16;
      int num11 = offScreenRange / 16;
      if (num6 - num10 < 4)
        num6 = num10 + 4;
      if (num7 + num10 > maxTilesX - 4)
        num7 = maxTilesX - num10 - 4;
      if (num8 - num11 < 4)
        num8 = num11 + 4;
      if (num9 + num11 > maxTilesY - 4)
        num9 = maxTilesY - num11 - 4;
      VertexColors vertices = new VertexColors();
      Rectangle rectangle = new Rectangle(0, 0, 32, 32);
      int underworldLayer = Main.UnderworldLayer;
      Point screenOverdrawOffset = Main.GetScreenOverdrawOffset();
      for (int index1 = num8 - num11 + screenOverdrawOffset.Y; index1 < num9 + num11 - screenOverdrawOffset.Y; ++index1)
      {
        for (int index2 = num6 - num10 + screenOverdrawOffset.X; index2 < num7 + num10 - screenOverdrawOffset.X; ++index2)
        {
          Tile tile = this._tileArray[index2, index1];
          if (tile == null)
          {
            tile = new Tile();
            this._tileArray[index2, index1] = tile;
          }
          ushort wall = tile.wall;
          if (wall > (ushort) 0 && !this.FullTile(index2, index1))
          {
            Color color1 = Lighting.GetColor(index2, index1);
            if (tile.wallColor() == (byte) 31)
              color1 = Color.White;
            if (color1.R != (byte) 0 || color1.G != (byte) 0 || color1.B != (byte) 0 || index1 >= underworldLayer)
            {
              Main.instance.LoadWall((int) wall);
              rectangle.X = tile.wallFrameX();
              rectangle.Y = tile.wallFrameY() + (int) Main.wallFrame[(int) wall] * 180;
              switch (tile.wall)
              {
                case 242:
                case 243:
                  int num12 = 20;
                  int num13 = ((int) Main.wallFrameCounter[(int) wall] + index2 * 11 + index1 * 27) % (num12 * 8);
                  rectangle.Y = tile.wallFrameY() + 180 * (num13 / num12);
                  break;
              }
              if (Lighting.NotRetro && !Main.wallLight[(int) wall] && tile.wall != (ushort) 241 && (tile.wall < (ushort) 88 || tile.wall > (ushort) 93) && !WorldGen.SolidTile(tile))
              {
                Texture2D tileDrawTexture = this.GetTileDrawTexture(tile, index2, index1);
                if (tile.wall == (ushort) 44)
                {
                  Color color2 = new Color((int) (byte) Main.DiscoR, (int) (byte) Main.DiscoG, (int) (byte) Main.DiscoB);
                  vertices.BottomLeftColor = color2;
                  vertices.BottomRightColor = color2;
                  vertices.TopLeftColor = color2;
                  vertices.TopRightColor = color2;
                }
                else
                {
                  Lighting.GetCornerColors(index2, index1, out vertices);
                  if (tile.wallColor() == (byte) 31)
                    vertices = WallDrawing._glowPaintColors;
                }
                tileBatch.Draw(tileDrawTexture, new Vector2((float) (index2 * 16 - (int) screenPosition.X - 8), (float) (index1 * 16 - (int) screenPosition.Y - 8)) + vector2, new Rectangle?(rectangle), vertices, Vector2.Zero, 1f, SpriteEffects.None);
              }
              else
              {
                Color color3 = color1;
                if (wall == (ushort) 44)
                  color3 = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                Texture2D tileDrawTexture = this.GetTileDrawTexture(tile, index2, index1);
                spriteBatch.Draw(tileDrawTexture, new Vector2((float) (index2 * 16 - (int) screenPosition.X - 8), (float) (index1 * 16 - (int) screenPosition.Y - 8)) + vector2, new Rectangle?(rectangle), color3, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
              }
              if ((int) color1.R > num3 || (int) color1.G > num4 || (int) color1.B > num5)
              {
                int num14 = this._tileArray[index2 - 1, index1].wall <= (ushort) 0 ? 0 : (wallBlend[(int) this._tileArray[index2 - 1, index1].wall] != wallBlend[(int) tile.wall] ? 1 : 0);
                bool flag1 = this._tileArray[index2 + 1, index1].wall > (ushort) 0 && wallBlend[(int) this._tileArray[index2 + 1, index1].wall] != wallBlend[(int) tile.wall];
                bool flag2 = this._tileArray[index2, index1 - 1].wall > (ushort) 0 && wallBlend[(int) this._tileArray[index2, index1 - 1].wall] != wallBlend[(int) tile.wall];
                bool flag3 = this._tileArray[index2, index1 + 1].wall > (ushort) 0 && wallBlend[(int) this._tileArray[index2, index1 + 1].wall] != wallBlend[(int) tile.wall];
                if (num14 != 0)
                  spriteBatch.Draw(TextureAssets.WallOutline.Value, new Vector2((float) (index2 * 16 - (int) screenPosition.X), (float) (index1 * 16 - (int) screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(0, 0, 2, 16)), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                if (flag1)
                  spriteBatch.Draw(TextureAssets.WallOutline.Value, new Vector2((float) (index2 * 16 - (int) screenPosition.X + 14), (float) (index1 * 16 - (int) screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(14, 0, 2, 16)), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                if (flag2)
                  spriteBatch.Draw(TextureAssets.WallOutline.Value, new Vector2((float) (index2 * 16 - (int) screenPosition.X), (float) (index1 * 16 - (int) screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(0, 0, 16, 2)), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                if (flag3)
                  spriteBatch.Draw(TextureAssets.WallOutline.Value, new Vector2((float) (index2 * 16 - (int) screenPosition.X), (float) (index1 * 16 - (int) screenPosition.Y + 14)) + vector2, new Rectangle?(new Rectangle(0, 14, 16, 2)), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
              }
            }
          }
        }
      }
      Main.instance.DrawTileCracks(2, Main.LocalPlayer.hitReplace);
      Main.instance.DrawTileCracks(2, Main.LocalPlayer.hitTile);
      TimeLogger.DrawTime(2, stopwatch.Elapsed.TotalMilliseconds);
    }

    private Texture2D GetTileDrawTexture(Tile tile, int tileX, int tileY)
    {
      Texture2D texture2D = TextureAssets.Wall[(int) tile.wall].Value;
      Texture2D requestIfNotReady = this._paintSystem.TryGetWallAndRequestIfNotReady((int) tile.wall, (int) tile.wallColor());
      if (requestIfNotReady != null)
        texture2D = requestIfNotReady;
      return texture2D;
    }

    protected bool FullTile(int x, int y)
    {
      if (this._tileArray[x - 1, y] == null || this._tileArray[x - 1, y].blockType() != 0 || this._tileArray[x + 1, y] == null || this._tileArray[x + 1, y].blockType() != 0)
        return false;
      Tile tile = this._tileArray[x, y];
      if (tile == null || !tile.active() || (int) tile.type < TileID.Sets.DrawsWalls.Length && TileID.Sets.DrawsWalls[(int) tile.type] || !Main.tileSolid[(int) tile.type] || Main.tileSolidTop[(int) tile.type])
        return false;
      int frameX = (int) tile.frameX;
      int frameY = (int) tile.frameY;
      if (Main.tileLargeFrames[(int) tile.type] > (byte) 0)
      {
        if ((frameY == 18 || frameY == 108) && (frameX >= 18 && frameX <= 54 || frameX >= 108 && frameX <= 144))
          return true;
      }
      else if (frameY == 18)
      {
        if (frameX >= 18 && frameX <= 54 || frameX >= 108 && frameX <= 144)
          return true;
      }
      else if (frameY >= 90 && frameY <= 196 && (frameX <= 70 || frameX >= 144 && frameX <= 232))
        return true;
      return false;
    }
  }
}
