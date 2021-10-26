// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.StardustSky
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class StardustSky : CustomSky
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private Asset<Texture2D> _planetTexture;
    private Asset<Texture2D> _bgTexture;
    private Asset<Texture2D>[] _starTextures;
    private bool _isActive;
    private StardustSky.Star[] _stars;
    private float _fadeOpacity;

    public override void OnLoad()
    {
      this._planetTexture = Main.Assets.Request<Texture2D>("Images/Misc/StarDustSky/Planet", (AssetRequestMode) 1);
      this._bgTexture = Main.Assets.Request<Texture2D>("Images/Misc/StarDustSky/Background", (AssetRequestMode) 1);
      this._starTextures = new Asset<Texture2D>[2];
      for (int index = 0; index < this._starTextures.Length; ++index)
        this._starTextures[index] = Main.Assets.Request<Texture2D>("Images/Misc/StarDustSky/Star " + (object) index, (AssetRequestMode) 1);
    }

    public override void Update(GameTime gameTime)
    {
      if (this._isActive)
        this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
      else
        this._fadeOpacity = Math.Max(0.0f, this._fadeOpacity - 0.01f);
    }

    public override Color OnTileColor(Color inColor) => new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, this._fadeOpacity * 0.5f));

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) maxDepth >= 3.40282346638529E+38 && (double) minDepth < 3.40282346638529E+38)
      {
        spriteBatch.Draw(TextureAssets.BlackTile.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
        spriteBatch.Draw(this._bgTexture.Value, new Rectangle(0, Math.Max(0, (int) ((Main.worldSurface * 16.0 - (double) Main.screenPosition.Y - 2400.0) * 0.100000001490116)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (float) (((double) Main.screenPosition.Y - 800.0) / 1000.0) * this._fadeOpacity));
        Vector2 vector2_1 = new Vector2((float) (Main.screenWidth >> 1), (float) (Main.screenHeight >> 1));
        Vector2 vector2_2 = 0.01f * (new Vector2((float) Main.maxTilesX * 8f, (float) Main.worldSurface / 2f) - Main.screenPosition);
        spriteBatch.Draw(this._planetTexture.Value, vector2_1 + new Vector2(-200f, -200f) + vector2_2, new Rectangle?(), Color.White * 0.9f * this._fadeOpacity, 0.0f, new Vector2((float) (this._planetTexture.Width() >> 1), (float) (this._planetTexture.Height() >> 1)), 1f, SpriteEffects.None, 1f);
      }
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this._stars.Length; ++index)
      {
        float depth = this._stars[index].Depth;
        if (num1 == -1 && (double) depth < (double) maxDepth)
          num1 = index;
        if ((double) depth > (double) minDepth)
          num2 = index;
        else
          break;
      }
      if (num1 == -1)
        return;
      float num3 = Math.Min(1f, (float) (((double) Main.screenPosition.Y - 1000.0) / 1000.0));
      Vector2 vector2_3 = Main.screenPosition + new Vector2((float) (Main.screenWidth >> 1), (float) (Main.screenHeight >> 1));
      Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
      for (int index = num1; index < num2; ++index)
      {
        Vector2 vector2_4 = new Vector2(1f / this._stars[index].Depth, 1.1f / this._stars[index].Depth);
        Vector2 position = (this._stars[index].Position - vector2_3) * vector2_4 + vector2_3 - Main.screenPosition;
        if (rectangle.Contains((int) position.X, (int) position.Y))
        {
          float num4 = (float) Math.Sin((double) this._stars[index].AlphaFrequency * (double) Main.GlobalTimeWrappedHourly + (double) this._stars[index].SinOffset) * this._stars[index].AlphaAmplitude + this._stars[index].AlphaAmplitude;
          float num5 = (float) (Math.Sin((double) this._stars[index].AlphaFrequency * (double) Main.GlobalTimeWrappedHourly * 5.0 + (double) this._stars[index].SinOffset) * 0.100000001490116 - 0.100000001490116);
          float num6 = MathHelper.Clamp(num4, 0.0f, 1f);
          Texture2D texture = this._starTextures[this._stars[index].TextureIndex].Value;
          spriteBatch.Draw(texture, position, new Rectangle?(), Color.White * num3 * num6 * 0.8f * (1f - num5) * this._fadeOpacity, 0.0f, new Vector2((float) (texture.Width >> 1), (float) (texture.Height >> 1)), (float) (((double) vector2_4.X * 0.5 + 0.5) * ((double) num6 * 0.300000011920929 + 0.699999988079071)), SpriteEffects.None, 0.0f);
        }
      }
    }

    public override float GetCloudAlpha() => (float) ((1.0 - (double) this._fadeOpacity) * 0.300000011920929 + 0.699999988079071);

    public override void Activate(Vector2 position, params object[] args)
    {
      this._fadeOpacity = 1f / 500f;
      this._isActive = true;
      int num1 = 200;
      int num2 = 10;
      this._stars = new StardustSky.Star[num1 * num2];
      int index1 = 0;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        float num3 = (float) index2 / (float) num1;
        for (int index3 = 0; index3 < num2; ++index3)
        {
          float num4 = (float) index3 / (float) num2;
          this._stars[index1].Position.X = (float) ((double) num3 * (double) Main.maxTilesX * 16.0);
          this._stars[index1].Position.Y = (float) ((double) num4 * (Main.worldSurface * 16.0 + 2000.0) - 1000.0);
          this._stars[index1].Depth = (float) ((double) this._random.NextFloat() * 8.0 + 1.5);
          this._stars[index1].TextureIndex = this._random.Next(this._starTextures.Length);
          this._stars[index1].SinOffset = this._random.NextFloat() * 6.28f;
          this._stars[index1].AlphaAmplitude = this._random.NextFloat() * 5f;
          this._stars[index1].AlphaFrequency = this._random.NextFloat() + 1f;
          ++index1;
        }
      }
      Array.Sort<StardustSky.Star>(this._stars, new Comparison<StardustSky.Star>(this.SortMethod));
    }

    private int SortMethod(StardustSky.Star meteor1, StardustSky.Star meteor2) => meteor2.Depth.CompareTo(meteor1.Depth);

    public override void Deactivate(params object[] args) => this._isActive = false;

    public override void Reset() => this._isActive = false;

    public override bool IsActive() => this._isActive || (double) this._fadeOpacity > 1.0 / 1000.0;

    private struct Star
    {
      public Vector2 Position;
      public float Depth;
      public int TextureIndex;
      public float SinOffset;
      public float AlphaFrequency;
      public float AlphaAmplitude;
    }
  }
}
