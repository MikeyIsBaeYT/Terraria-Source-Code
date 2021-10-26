// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.LanternSky
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class LanternSky : CustomSky
  {
    private bool _active;
    private bool _leaving;
    private float _opacity;
    private Asset<Texture2D> _texture;
    private LanternSky.Lantern[] _lanterns;
    private UnifiedRandom _random = new UnifiedRandom();
    private int _lanternsDrawing;
    private const float slowDown = 0.5f;

    public override void OnLoad()
    {
      this._texture = TextureAssets.Extra[134];
      this.GenerateLanterns(false);
    }

    private void GenerateLanterns(bool onlyMissing)
    {
      if (!onlyMissing)
        this._lanterns = new LanternSky.Lantern[Main.maxTilesY / 4];
      for (int i = 0; i < this._lanterns.Length; ++i)
      {
        if (!onlyMissing || !this._lanterns[i].Active)
        {
          int maxValue = (int) ((double) Main.screenPosition.Y * 0.7 - (double) Main.screenHeight);
          int minValue = (int) ((double) maxValue - Main.worldSurface * 16.0);
          this._lanterns[i].Position = new Vector2((float) (this._random.Next(0, Main.maxTilesX) * 16), (float) this._random.Next(minValue, maxValue));
          this.ResetLantern(i);
          this._lanterns[i].Active = true;
        }
      }
      this._lanternsDrawing = this._lanterns.Length;
    }

    public void ResetLantern(int i)
    {
      this._lanterns[i].Depth = (float) ((1.0 - (double) i / (double) this._lanterns.Length) * 4.40000009536743 + 1.60000002384186);
      this._lanterns[i].Speed = (float) (-1.5 - 2.5 * this._random.NextDouble());
      this._lanterns[i].Texture = this._texture.Value;
      this._lanterns[i].Variant = this._random.Next(3);
      this._lanterns[i].TimeUntilFloat = (int) ((double) (2000 + this._random.Next(1200)) * 2.0);
      this._lanterns[i].TimeUntilFloatMax = this._lanterns[i].TimeUntilFloat;
    }

    public override void Update(GameTime gameTime)
    {
      if (Main.gamePaused || !Main.hasFocus)
        return;
      this._opacity = Utils.Clamp<float>(this._opacity + (float) LanternNight.LanternsUp.ToDirectionInt() * 0.01f, 0.0f, 1f);
      for (int i = 0; i < this._lanterns.Length; ++i)
      {
        if (this._lanterns[i].Active)
        {
          float num1 = Main.windSpeedCurrent;
          if ((double) num1 == 0.0)
            num1 = 0.1f;
          float num2 = (float) Math.Sin((double) this._lanterns[i].Position.X / 120.0) * 0.5f;
          this._lanterns[i].Position.Y += num2 * 0.5f;
          this._lanterns[i].Position.Y += this._lanterns[i].FloatAdjustedSpeed * 0.5f;
          this._lanterns[i].Position.X += (float) ((0.100000001490116 + (double) num1) * (3.0 - (double) this._lanterns[i].Speed) * 0.5 * ((double) i / (double) this._lanterns.Length + 1.5) / 2.5);
          this._lanterns[i].Rotation = (float) ((double) num2 * ((double) num1 < 0.0 ? -1.0 : 1.0) * 0.5);
          this._lanterns[i].TimeUntilFloat = Math.Max(0, this._lanterns[i].TimeUntilFloat - 1);
          if ((double) this._lanterns[i].Position.Y < 300.0)
          {
            if (!this._leaving)
            {
              this.ResetLantern(i);
              this._lanterns[i].Position = new Vector2((float) (this._random.Next(0, Main.maxTilesX) * 16), (float) (Main.worldSurface * 16.0 + 1600.0));
            }
            else
            {
              this._lanterns[i].Active = false;
              --this._lanternsDrawing;
            }
          }
        }
      }
      this._active = true;
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if (Main.gameMenu && this._active)
      {
        this._active = false;
        this._leaving = false;
        for (int index = 0; index < this._lanterns.Length; ++index)
          this._lanterns[index].Active = false;
      }
      if ((double) Main.screenPosition.Y > Main.worldSurface * 16.0 || Main.gameMenu || (double) this._opacity <= 0.0)
        return;
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this._lanterns.Length; ++index)
      {
        float depth = this._lanterns[index].Depth;
        if (num1 == -1 && (double) depth < (double) maxDepth)
          num1 = index;
        if ((double) depth > (double) minDepth)
          num2 = index;
        else
          break;
      }
      if (num1 == -1)
        return;
      Vector2 vector2 = Main.screenPosition + new Vector2((float) (Main.screenWidth >> 1), (float) (Main.screenHeight >> 1));
      Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
      for (int index = num1; index < num2; ++index)
      {
        if (this._lanterns[index].Active)
        {
          Color opacity = new Color(250, 120, 60, 120);
          float alpha = 1f;
          if ((double) this._lanterns[index].Depth > 5.0)
            alpha = 0.3f;
          else if ((double) this._lanterns[index].Depth > 4.5)
            alpha = 0.4f;
          else if ((double) this._lanterns[index].Depth > 4.0)
            alpha = 0.5f;
          else if ((double) this._lanterns[index].Depth > 3.5)
            alpha = 0.6f;
          else if ((double) this._lanterns[index].Depth > 3.0)
            alpha = 0.7f;
          else if ((double) this._lanterns[index].Depth > 2.5)
            alpha = 0.8f;
          else if ((double) this._lanterns[index].Depth > 2.0)
            alpha = 0.9f;
          opacity = new Color((int) ((double) opacity.R * (double) alpha), (int) ((double) opacity.G * (double) alpha), (int) ((double) opacity.B * (double) alpha), (int) ((double) opacity.A * (double) alpha));
          Vector2 depthScale = new Vector2(1f / this._lanterns[index].Depth, 0.9f / this._lanterns[index].Depth);
          depthScale *= 1.2f;
          Vector2 position = (this._lanterns[index].Position - vector2) * depthScale + vector2 - Main.screenPosition;
          position.X = (float) (((double) position.X + 500.0) % 4000.0);
          if ((double) position.X < 0.0)
            position.X += 4000f;
          position.X -= 500f;
          if (rectangle.Contains((int) position.X, (int) position.Y))
            this.DrawLantern(spriteBatch, this._lanterns[index], opacity, depthScale, position, alpha);
        }
      }
    }

    private void DrawLantern(
      SpriteBatch spriteBatch,
      LanternSky.Lantern lantern,
      Color opacity,
      Vector2 depthScale,
      Vector2 position,
      float alpha)
    {
      float y = ((float) ((double) Main.GlobalTimeWrappedHourly % 6.0 / 6.0 * 6.28318548202515)).ToRotationVector2().Y;
      float num1 = (float) ((double) y * 0.200000002980232 + 0.800000011920929);
      Color color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0) * this._opacity * alpha * num1 * 0.4f;
      for (float num2 = 0.0f; (double) num2 < 1.0; num2 += 0.3333333f)
      {
        Vector2 vector2 = new Vector2(0.0f, 2f).RotatedBy(6.28318548202515 * (double) num2 + (double) lantern.Rotation) * y;
        spriteBatch.Draw(lantern.Texture, position + vector2, new Rectangle?(lantern.GetSourceRectangle()), color, lantern.Rotation, lantern.GetSourceRectangle().Size() / 2f, depthScale.X * 2f, SpriteEffects.None, 0.0f);
      }
      spriteBatch.Draw(lantern.Texture, position, new Rectangle?(lantern.GetSourceRectangle()), opacity * this._opacity, lantern.Rotation, lantern.GetSourceRectangle().Size() / 2f, depthScale.X * 2f, SpriteEffects.None, 0.0f);
    }

    public override void Activate(Vector2 position, params object[] args)
    {
      if (this._active)
      {
        this._leaving = false;
        this.GenerateLanterns(true);
      }
      else
      {
        this.GenerateLanterns(false);
        this._active = true;
        this._leaving = false;
      }
    }

    public override void Deactivate(params object[] args) => this._leaving = true;

    public override bool IsActive() => this._active;

    public override void Reset() => this._active = false;

    private struct Lantern
    {
      private const int MAX_FRAMES_X = 3;
      public int Variant;
      public int TimeUntilFloat;
      public int TimeUntilFloatMax;
      private Texture2D _texture;
      public Vector2 Position;
      public float Depth;
      public float Rotation;
      public int FrameHeight;
      public int FrameWidth;
      public float Speed;
      public bool Active;

      public Texture2D Texture
      {
        get => this._texture;
        set
        {
          this._texture = value;
          this.FrameWidth = value.Width / 3;
          this.FrameHeight = value.Height;
        }
      }

      public float FloatAdjustedSpeed => this.Speed * ((float) this.TimeUntilFloat / (float) this.TimeUntilFloatMax);

      public Rectangle GetSourceRectangle() => new Rectangle(this.FrameWidth * this.Variant, 0, this.FrameWidth, this.FrameHeight);
    }
  }
}
