// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.SolarSky
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class SolarSky : CustomSky
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private Texture2D _planetTexture;
    private Texture2D _bgTexture;
    private Texture2D _meteorTexture;
    private bool _isActive;
    private SolarSky.Meteor[] _meteors;
    private float _fadeOpacity;

    public override void OnLoad()
    {
      this._planetTexture = TextureManager.Load("Images/Misc/SolarSky/Planet");
      this._bgTexture = TextureManager.Load("Images/Misc/SolarSky/Background");
      this._meteorTexture = TextureManager.Load("Images/Misc/SolarSky/Meteor");
    }

    public override void Update(GameTime gameTime)
    {
      this._fadeOpacity = !this._isActive ? Math.Max(0.0f, this._fadeOpacity - 0.01f) : Math.Min(1f, 0.01f + this._fadeOpacity);
      float num = 1200f;
      for (int index = 0; index < this._meteors.Length; ++index)
      {
        this._meteors[index].Position.X -= num * (float) gameTime.ElapsedGameTime.TotalSeconds;
        this._meteors[index].Position.Y += num * (float) gameTime.ElapsedGameTime.TotalSeconds;
        if ((double) this._meteors[index].Position.Y > Main.worldSurface * 16.0)
        {
          this._meteors[index].Position.X = this._meteors[index].StartX;
          this._meteors[index].Position.Y = -10000f;
        }
      }
    }

    public override Color OnTileColor(Color inColor) => new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, this._fadeOpacity * 0.5f));

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) maxDepth >= 3.40282346638529E+38 && (double) minDepth < 3.40282346638529E+38)
      {
        spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
        spriteBatch.Draw(this._bgTexture, new Rectangle(0, Math.Max(0, (int) ((Main.worldSurface * 16.0 - (double) Main.screenPosition.Y - 2400.0) * 0.100000001490116)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (float) (((double) Main.screenPosition.Y - 800.0) / 1000.0) * this._fadeOpacity));
        Vector2 vector2_1 = new Vector2((float) (Main.screenWidth >> 1), (float) (Main.screenHeight >> 1));
        Vector2 vector2_2 = 0.01f * (new Vector2((float) Main.maxTilesX * 8f, (float) Main.worldSurface / 2f) - Main.screenPosition);
        spriteBatch.Draw(this._planetTexture, vector2_1 + new Vector2(-200f, -200f) + vector2_2, new Rectangle?(), Color.White * 0.9f * this._fadeOpacity, 0.0f, new Vector2((float) (this._planetTexture.Width >> 1), (float) (this._planetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);
      }
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this._meteors.Length; ++index)
      {
        float depth = this._meteors[index].Depth;
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
        Vector2 vector2_4 = new Vector2(1f / this._meteors[index].Depth, 0.9f / this._meteors[index].Depth);
        Vector2 position = (this._meteors[index].Position - vector2_3) * vector2_4 + vector2_3 - Main.screenPosition;
        int num4 = this._meteors[index].FrameCounter / 3;
        this._meteors[index].FrameCounter = (this._meteors[index].FrameCounter + 1) % 12;
        if (rectangle.Contains((int) position.X, (int) position.Y))
          spriteBatch.Draw(this._meteorTexture, position, new Rectangle?(new Rectangle(0, num4 * (this._meteorTexture.Height / 4), this._meteorTexture.Width, this._meteorTexture.Height / 4)), Color.White * num3 * this._fadeOpacity, 0.0f, Vector2.Zero, vector2_4.X * 5f * this._meteors[index].Scale, SpriteEffects.None, 0.0f);
      }
    }

    public override float GetCloudAlpha() => (float) ((1.0 - (double) this._fadeOpacity) * 0.300000011920929 + 0.699999988079071);

    internal override void Activate(Vector2 position, params object[] args)
    {
      this._fadeOpacity = 1f / 500f;
      this._isActive = true;
      this._meteors = new SolarSky.Meteor[150];
      for (int index = 0; index < this._meteors.Length; ++index)
      {
        float num = (float) index / (float) this._meteors.Length;
        this._meteors[index].Position.X = (float) ((double) num * ((double) Main.maxTilesX * 16.0) + (double) this._random.NextFloat() * 40.0 - 20.0);
        this._meteors[index].Position.Y = (float) ((double) this._random.NextFloat() * -(Main.worldSurface * 16.0 + 10000.0) - 10000.0);
        this._meteors[index].Depth = this._random.Next(3) == 0 ? (float) ((double) this._random.NextFloat() * 5.0 + 4.80000019073486) : (float) ((double) this._random.NextFloat() * 3.0 + 1.79999995231628);
        this._meteors[index].FrameCounter = this._random.Next(12);
        this._meteors[index].Scale = (float) ((double) this._random.NextFloat() * 0.5 + 1.0);
        this._meteors[index].StartX = this._meteors[index].Position.X;
      }
      Array.Sort<SolarSky.Meteor>(this._meteors, new Comparison<SolarSky.Meteor>(this.SortMethod));
    }

    private int SortMethod(SolarSky.Meteor meteor1, SolarSky.Meteor meteor2) => meteor2.Depth.CompareTo(meteor1.Depth);

    internal override void Deactivate(params object[] args) => this._isActive = false;

    public override void Reset() => this._isActive = false;

    public override bool IsActive() => this._isActive || (double) this._fadeOpacity > 1.0 / 1000.0;

    private struct Meteor
    {
      public Vector2 Position;
      public float Depth;
      public int FrameCounter;
      public float Scale;
      public float StartX;
    }
  }
}
