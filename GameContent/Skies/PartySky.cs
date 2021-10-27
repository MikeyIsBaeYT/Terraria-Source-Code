// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.PartySky
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class PartySky : CustomSky
  {
    public static bool MultipleSkyWorkaroundFix;
    private bool _active;
    private bool _leaving;
    private float _opacity;
    private Texture2D[] _textures;
    private PartySky.Balloon[] _balloons;
    private UnifiedRandom _random = new UnifiedRandom();
    private int _balloonsDrawing;

    public override void OnLoad()
    {
      this._textures = new Texture2D[3];
      for (int index = 0; index < this._textures.Length; ++index)
        this._textures[index] = Main.extraTexture[69 + index];
      this.GenerateBalloons(false);
    }

    private void GenerateBalloons(bool onlyMissing)
    {
      if (!onlyMissing)
        this._balloons = new PartySky.Balloon[Main.maxTilesY / 4];
      for (int i = 0; i < this._balloons.Length; ++i)
      {
        if (!onlyMissing || !this._balloons[i].Active)
        {
          int maxValue = (int) ((double) Main.screenPosition.Y * 0.7 - (double) Main.screenHeight);
          int minValue = (int) ((double) maxValue - Main.worldSurface * 16.0);
          this._balloons[i].Position = new Vector2((float) (this._random.Next(0, Main.maxTilesX) * 16), (float) this._random.Next(minValue, maxValue));
          this.ResetBalloon(i);
          this._balloons[i].Active = true;
        }
      }
      this._balloonsDrawing = this._balloons.Length;
    }

    public void ResetBalloon(int i)
    {
      this._balloons[i].Depth = (float) ((double) i / (double) this._balloons.Length * 1.75 + 1.60000002384186);
      this._balloons[i].Speed = (float) (-1.5 - 2.5 * this._random.NextDouble());
      this._balloons[i].Texture = this._textures[this._random.Next(2)];
      this._balloons[i].Variant = this._random.Next(3);
      if (this._random.Next(30) != 0)
        return;
      this._balloons[i].Texture = this._textures[2];
    }

    private bool IsNearParty() => (double) Main.player[Main.myPlayer].townNPCs > 0.0 || Main.partyMonoliths > 0;

    public override void Update(GameTime gameTime)
    {
      if (!PartySky.MultipleSkyWorkaroundFix)
        return;
      PartySky.MultipleSkyWorkaroundFix = false;
      if (Main.gamePaused || !Main.hasFocus)
        return;
      this._opacity = Utils.Clamp<float>(this._opacity + (float) this.IsNearParty().ToDirectionInt() * 0.01f, 0.0f, 1f);
      for (int i = 0; i < this._balloons.Length; ++i)
      {
        if (this._balloons[i].Active)
        {
          ++this._balloons[i].Frame;
          this._balloons[i].Position.Y += this._balloons[i].Speed;
          this._balloons[i].Position.X += Main.windSpeed * (3f - this._balloons[i].Speed);
          if ((double) this._balloons[i].Position.Y < 300.0)
          {
            if (!this._leaving)
            {
              this.ResetBalloon(i);
              this._balloons[i].Position = new Vector2((float) (this._random.Next(0, Main.maxTilesX) * 16), (float) (Main.worldSurface * 16.0 + 1600.0));
              if (this._random.Next(30) == 0)
                this._balloons[i].Texture = this._textures[2];
            }
            else
            {
              this._balloons[i].Active = false;
              --this._balloonsDrawing;
            }
          }
        }
      }
      if (this._balloonsDrawing == 0)
        this._active = false;
      this._active = true;
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if (Main.gameMenu && this._active)
      {
        this._active = false;
        this._leaving = false;
        for (int index = 0; index < this._balloons.Length; ++index)
          this._balloons[index].Active = false;
      }
      if ((double) Main.screenPosition.Y > Main.worldSurface * 16.0 || Main.gameMenu || (double) this._opacity <= 0.0)
        return;
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this._balloons.Length; ++index)
      {
        float depth = this._balloons[index].Depth;
        if (num1 == -1 && (double) depth < (double) maxDepth)
          num1 = index;
        if ((double) depth > (double) minDepth)
          num2 = index;
        else
          break;
      }
      if (num1 == -1)
        return;
      Vector2 vector2_1 = Main.screenPosition + new Vector2((float) (Main.screenWidth >> 1), (float) (Main.screenHeight >> 1));
      Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
      for (int index = num1; index < num2; ++index)
      {
        if (this._balloons[index].Active)
        {
          Color color = new Color(Main.bgColor.ToVector4() * 0.9f + new Vector4(0.1f)) * 0.8f;
          float num3 = 1f;
          if ((double) this._balloons[index].Depth > 3.0)
            num3 = 0.6f;
          else if ((double) this._balloons[index].Depth > 2.5)
            num3 = 0.7f;
          else if ((double) this._balloons[index].Depth > 2.0)
            num3 = 0.8f;
          else if ((double) this._balloons[index].Depth > 1.5)
            num3 = 0.9f;
          float num4 = num3 * 0.9f;
          color = new Color((int) ((double) color.R * (double) num4), (int) ((double) color.G * (double) num4), (int) ((double) color.B * (double) num4), (int) ((double) color.A * (double) num4));
          Vector2 vector2_2 = new Vector2(1f / this._balloons[index].Depth, 0.9f / this._balloons[index].Depth);
          Vector2 position = (this._balloons[index].Position - vector2_1) * vector2_2 + vector2_1 - Main.screenPosition;
          position.X = (float) (((double) position.X + 500.0) % 4000.0);
          if ((double) position.X < 0.0)
            position.X += 4000f;
          position.X -= 500f;
          if (rectangle.Contains((int) position.X, (int) position.Y))
            spriteBatch.Draw(this._balloons[index].Texture, position, new Rectangle?(this._balloons[index].GetSourceRectangle()), color * this._opacity, 0.0f, Vector2.Zero, vector2_2.X * 2f, SpriteEffects.None, 0.0f);
        }
      }
    }

    internal override void Activate(Vector2 position, params object[] args)
    {
      if (this._active)
      {
        this._leaving = false;
        this.GenerateBalloons(true);
      }
      else
      {
        this.GenerateBalloons(false);
        this._active = true;
        this._leaving = false;
      }
    }

    internal override void Deactivate(params object[] args) => this._leaving = true;

    public override bool IsActive() => this._active;

    public override void Reset() => this._active = false;

    private struct Balloon
    {
      private const int MAX_FRAMES_X = 3;
      private const int MAX_FRAMES_Y = 3;
      private const int FRAME_RATE = 14;
      public int Variant;
      private Texture2D _texture;
      public Vector2 Position;
      public float Depth;
      public int FrameHeight;
      public int FrameWidth;
      public float Speed;
      public bool Active;
      private int _frameCounter;

      public Texture2D Texture
      {
        get => this._texture;
        set
        {
          this._texture = value;
          this.FrameWidth = value.Width / 3;
          this.FrameHeight = value.Height / 3;
        }
      }

      public int Frame
      {
        get => this._frameCounter;
        set => this._frameCounter = value % 42;
      }

      public Rectangle GetSourceRectangle() => new Rectangle(this.FrameWidth * this.Variant, this._frameCounter / 14 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
    }
  }
}
