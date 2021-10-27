// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.MartianSky
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class MartianSky : CustomSky
  {
    private MartianSky.Ufo[] _ufos;
    private UnifiedRandom _random = new UnifiedRandom();
    private int _maxUfos;
    private bool _active;
    private bool _leaving;
    private int _activeUfos;

    public override void Update(GameTime gameTime)
    {
      if (Main.gamePaused || !Main.hasFocus)
        return;
      int activeUfos = this._activeUfos;
      for (int index = 0; index < this._ufos.Length; ++index)
      {
        MartianSky.Ufo ufo = this._ufos[index];
        if (ufo.IsActive)
        {
          ++ufo.Frame;
          if (!ufo.Update())
          {
            if (!this._leaving)
            {
              ufo.AssignNewBehavior();
            }
            else
            {
              ufo.IsActive = false;
              --activeUfos;
            }
          }
        }
        this._ufos[index] = ufo;
      }
      if (!this._leaving && activeUfos != this._maxUfos)
      {
        this._ufos[activeUfos].IsActive = true;
        this._ufos[activeUfos++].AssignNewBehavior();
      }
      this._active = !this._leaving || (uint) activeUfos > 0U;
      this._activeUfos = activeUfos;
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) Main.screenPosition.Y > 10000.0)
        return;
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this._ufos.Length; ++index)
      {
        float depth = this._ufos[index].Depth;
        if (num1 == -1 && (double) depth < (double) maxDepth)
          num1 = index;
        if ((double) depth > (double) minDepth)
          num2 = index;
        else
          break;
      }
      if (num1 == -1)
        return;
      Color color = new Color(Main.bgColor.ToVector4() * 0.9f + new Vector4(0.1f));
      Vector2 vector2_1 = Main.screenPosition + new Vector2((float) (Main.screenWidth >> 1), (float) (Main.screenHeight >> 1));
      Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
      for (int index = num1; index < num2; ++index)
      {
        Vector2 vector2_2 = new Vector2(1f / this._ufos[index].Depth, 0.9f / this._ufos[index].Depth);
        Vector2 position = (this._ufos[index].Position - vector2_1) * vector2_2 + vector2_1 - Main.screenPosition;
        if (this._ufos[index].IsActive && rectangle.Contains((int) position.X, (int) position.Y))
        {
          spriteBatch.Draw(this._ufos[index].Texture, position, new Rectangle?(this._ufos[index].GetSourceRectangle()), color * this._ufos[index].Opacity, this._ufos[index].Rotation, Vector2.Zero, vector2_2.X * 5f * this._ufos[index].Scale, SpriteEffects.None, 0.0f);
          if (this._ufos[index].GlowTexture != null)
            spriteBatch.Draw(this._ufos[index].GlowTexture, position, new Rectangle?(this._ufos[index].GetSourceRectangle()), Color.White * this._ufos[index].Opacity, this._ufos[index].Rotation, Vector2.Zero, vector2_2.X * 5f * this._ufos[index].Scale, SpriteEffects.None, 0.0f);
        }
      }
    }

    private void GenerateUfos()
    {
      this._maxUfos = (int) (256.0 * (double) ((float) Main.maxTilesX / 4200f));
      this._ufos = new MartianSky.Ufo[this._maxUfos];
      int num1 = this._maxUfos >> 4;
      for (int index = 0; index < num1; ++index)
      {
        double num2 = (double) index / (double) num1;
        this._ufos[index] = new MartianSky.Ufo(Main.extraTexture[5], (float) (Main.rand.NextDouble() * 4.0 + 6.59999990463257));
        this._ufos[index].GlowTexture = Main.glowMaskTexture[90];
      }
      for (int index = num1; index < this._ufos.Length; ++index)
      {
        double num3 = (double) (index - num1) / (double) (this._ufos.Length - num1);
        this._ufos[index] = new MartianSky.Ufo(Main.extraTexture[6], (float) (Main.rand.NextDouble() * 5.0 + 1.60000002384186));
        this._ufos[index].Scale = 0.5f;
        this._ufos[index].GlowTexture = Main.glowMaskTexture[91];
      }
    }

    internal override void Activate(Vector2 position, params object[] args)
    {
      this._activeUfos = 0;
      this.GenerateUfos();
      Array.Sort<MartianSky.Ufo>(this._ufos, (Comparison<MartianSky.Ufo>) ((ufo1, ufo2) => ufo2.Depth.CompareTo(ufo1.Depth)));
      this._active = true;
      this._leaving = false;
    }

    internal override void Deactivate(params object[] args) => this._leaving = true;

    public override bool IsActive() => this._active;

    public override void Reset() => this._active = false;

    private abstract class IUfoController
    {
      public abstract void InitializeUfo(ref MartianSky.Ufo ufo);

      public abstract bool Update(ref MartianSky.Ufo ufo);
    }

    private class ZipBehavior : MartianSky.IUfoController
    {
      private Vector2 _speed;
      private int _ticks;
      private int _maxTicks;

      public override void InitializeUfo(ref MartianSky.Ufo ufo)
      {
        ufo.Position.X = (float) MartianSky.Ufo.Random.NextDouble() * (float) (Main.maxTilesX << 4);
        ufo.Position.Y = (float) (MartianSky.Ufo.Random.NextDouble() * 5000.0);
        ufo.Opacity = 0.0f;
        float num1 = (float) (MartianSky.Ufo.Random.NextDouble() * 5.0 + 10.0);
        double num2 = MartianSky.Ufo.Random.NextDouble() * 0.600000023841858 - 0.300000011920929;
        ufo.Rotation = (float) num2;
        if (MartianSky.Ufo.Random.Next(2) == 0)
          num2 += 3.14159274101257;
        this._speed = new Vector2((float) Math.Cos(num2) * num1, (float) Math.Sin(num2) * num1);
        this._ticks = 0;
        this._maxTicks = MartianSky.Ufo.Random.Next(400, 500);
      }

      public override bool Update(ref MartianSky.Ufo ufo)
      {
        if (this._ticks < 10)
          ufo.Opacity += 0.1f;
        else if (this._ticks > this._maxTicks - 10)
          ufo.Opacity -= 0.1f;
        ufo.Position += this._speed;
        if (this._ticks == this._maxTicks)
          return false;
        ++this._ticks;
        return true;
      }
    }

    private class HoverBehavior : MartianSky.IUfoController
    {
      private int _ticks;
      private int _maxTicks;

      public override void InitializeUfo(ref MartianSky.Ufo ufo)
      {
        ufo.Position.X = (float) MartianSky.Ufo.Random.NextDouble() * (float) (Main.maxTilesX << 4);
        ufo.Position.Y = (float) (MartianSky.Ufo.Random.NextDouble() * 5000.0);
        ufo.Opacity = 0.0f;
        ufo.Rotation = 0.0f;
        this._ticks = 0;
        this._maxTicks = MartianSky.Ufo.Random.Next(120, 240);
      }

      public override bool Update(ref MartianSky.Ufo ufo)
      {
        if (this._ticks < 10)
          ufo.Opacity += 0.1f;
        else if (this._ticks > this._maxTicks - 10)
          ufo.Opacity -= 0.1f;
        if (this._ticks == this._maxTicks)
          return false;
        ++this._ticks;
        return true;
      }
    }

    private struct Ufo
    {
      private const int MAX_FRAMES = 3;
      private const int FRAME_RATE = 4;
      public static UnifiedRandom Random = new UnifiedRandom();
      private int _frame;
      private Texture2D _texture;
      private MartianSky.IUfoController _controller;
      public Texture2D GlowTexture;
      public Vector2 Position;
      public int FrameHeight;
      public int FrameWidth;
      public float Depth;
      public float Scale;
      public float Opacity;
      public bool IsActive;
      public float Rotation;

      public int Frame
      {
        get => this._frame;
        set => this._frame = value % 12;
      }

      public Texture2D Texture
      {
        get => this._texture;
        set
        {
          this._texture = value;
          this.FrameWidth = value.Width;
          this.FrameHeight = value.Height / 3;
        }
      }

      public MartianSky.IUfoController Controller
      {
        get => this._controller;
        set
        {
          this._controller = value;
          value.InitializeUfo(ref this);
        }
      }

      public Ufo(Texture2D texture, float depth = 1f)
      {
        this._frame = 0;
        this.Position = Vector2.Zero;
        this._texture = texture;
        this.Depth = depth;
        this.Scale = 1f;
        this.FrameWidth = texture.Width;
        this.FrameHeight = texture.Height / 3;
        this.GlowTexture = (Texture2D) null;
        this.Opacity = 0.0f;
        this.Rotation = 0.0f;
        this.IsActive = false;
        this._controller = (MartianSky.IUfoController) null;
      }

      public Rectangle GetSourceRectangle() => new Rectangle(0, this._frame / 4 * this.FrameHeight, this.FrameWidth, this.FrameHeight);

      public bool Update() => this.Controller.Update(ref this);

      public void AssignNewBehavior()
      {
        switch (MartianSky.Ufo.Random.Next(2))
        {
          case 0:
            this.Controller = (MartianSky.IUfoController) new MartianSky.ZipBehavior();
            break;
          case 1:
            this.Controller = (MartianSky.IUfoController) new MartianSky.HoverBehavior();
            break;
        }
      }
    }
  }
}
