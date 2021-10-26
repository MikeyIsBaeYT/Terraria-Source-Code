// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Shaders.WaterShaderData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Liquid;
using Terraria.Graphics;
using Terraria.Graphics.Light;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace Terraria.GameContent.Shaders
{
  public class WaterShaderData : ScreenShaderData
  {
    private const float DISTORTION_BUFFER_SCALE = 0.25f;
    private const float WAVE_FRAMERATE = 0.01666667f;
    private const int MAX_RIPPLES_QUEUED = 200;
    public bool _useViscosityFilter = true;
    private RenderTarget2D _distortionTarget;
    private RenderTarget2D _distortionTargetSwap;
    private bool _usingRenderTargets;
    private Vector2 _lastDistortionDrawOffset = Vector2.Zero;
    private float _progress;
    private WaterShaderData.Ripple[] _rippleQueue = new WaterShaderData.Ripple[200];
    private int _rippleQueueCount;
    private int _lastScreenWidth;
    private int _lastScreenHeight;
    public bool _useProjectileWaves = true;
    private bool _useNPCWaves = true;
    private bool _usePlayerWaves = true;
    private bool _useRippleWaves = true;
    private bool _useCustomWaves = true;
    private bool _clearNextFrame = true;
    private Texture2D[] _viscosityMaskChain = new Texture2D[3];
    private int _activeViscosityMask;
    private Asset<Texture2D> _rippleShapeTexture;
    private bool _isWaveBufferDirty = true;
    private int _queuedSteps;
    private const int MAX_QUEUED_STEPS = 2;

    public event Action<TileBatch> OnWaveDraw;

    public WaterShaderData(string passName)
      : base(passName)
    {
      Main.OnRenderTargetsInitialized += new ResolutionChangeEvent(this.InitRenderTargets);
      Main.OnRenderTargetsReleased += new Action(this.ReleaseRenderTargets);
      this._rippleShapeTexture = Main.Assets.Request<Texture2D>("Images/Misc/Ripples", (AssetRequestMode) 1);
      Main.OnPreDraw += new Action<GameTime>(this.PreDraw);
    }

    public override void Update(GameTime gameTime)
    {
      this._useViscosityFilter = Main.WaveQuality >= 3;
      this._useProjectileWaves = Main.WaveQuality >= 3;
      this._usePlayerWaves = Main.WaveQuality >= 2;
      this._useRippleWaves = Main.WaveQuality >= 2;
      this._useCustomWaves = Main.WaveQuality >= 2;
      if (Main.gamePaused || !Main.hasFocus)
        return;
      this._progress += (float) (gameTime.ElapsedGameTime.TotalSeconds * (double) this.Intensity * 0.75);
      this._progress %= 86400f;
      if (this._useProjectileWaves || this._useRippleWaves || this._useCustomWaves || this._usePlayerWaves)
        ++this._queuedSteps;
      base.Update(gameTime);
    }

    private void StepLiquids()
    {
      this._isWaveBufferDirty = true;
      Vector2 vector2_1 = Main.drawToScreen ? Vector2.Zero : new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      Vector2 vector2_2 = vector2_1 - Main.screenPosition;
      TileBatch tileBatch = Main.tileBatch;
      GraphicsDevice graphicsDevice = Main.instance.GraphicsDevice;
      graphicsDevice.SetRenderTarget(this._distortionTarget);
      if (this._clearNextFrame)
      {
        graphicsDevice.Clear(new Color(0.5f, 0.5f, 0.0f, 1f));
        this._clearNextFrame = false;
      }
      this.DrawWaves();
      graphicsDevice.SetRenderTarget(this._distortionTargetSwap);
      graphicsDevice.Clear(new Color(0.5f, 0.5f, 0.5f, 1f));
      Main.tileBatch.Begin();
      Vector2 vector2_3 = vector2_2 * 0.25f;
      vector2_3.X = (float) Math.Floor((double) vector2_3.X);
      vector2_3.Y = (float) Math.Floor((double) vector2_3.Y);
      Vector2 vector2_4 = vector2_3 - this._lastDistortionDrawOffset;
      this._lastDistortionDrawOffset = vector2_3;
      tileBatch.Draw((Texture2D) this._distortionTarget, new Vector4(vector2_4.X, vector2_4.Y, (float) this._distortionTarget.Width, (float) this._distortionTarget.Height), new VertexColors(Color.White));
      GameShaders.Misc["WaterProcessor"].Apply(new DrawData?(new DrawData((Texture2D) this._distortionTarget, Vector2.Zero, Color.White)));
      tileBatch.End();
      RenderTarget2D distortionTarget = this._distortionTarget;
      this._distortionTarget = this._distortionTargetSwap;
      this._distortionTargetSwap = distortionTarget;
      if (this._useViscosityFilter)
      {
        LiquidRenderer.Instance.SetWaveMaskData(ref this._viscosityMaskChain[this._activeViscosityMask]);
        tileBatch.Begin();
        Rectangle cachedDrawArea = LiquidRenderer.Instance.GetCachedDrawArea();
        Rectangle rectangle = new Rectangle(0, 0, cachedDrawArea.Height, cachedDrawArea.Width);
        Vector4 vector4 = new Vector4((float) (cachedDrawArea.X + cachedDrawArea.Width), (float) cachedDrawArea.Y, (float) cachedDrawArea.Height, (float) cachedDrawArea.Width) * 16f;
        vector4.X -= vector2_1.X;
        vector4.Y -= vector2_1.Y;
        Vector4 destination = vector4 * 0.25f;
        destination.X += vector2_3.X;
        destination.Y += vector2_3.Y;
        graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
        tileBatch.Draw(this._viscosityMaskChain[this._activeViscosityMask], destination, new Rectangle?(rectangle), new VertexColors(Color.White), Vector2.Zero, SpriteEffects.FlipHorizontally, 1.570796f);
        tileBatch.End();
        ++this._activeViscosityMask;
        this._activeViscosityMask %= this._viscosityMaskChain.Length;
      }
      graphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    private void DrawWaves()
    {
      Vector2 screenPosition = Main.screenPosition;
      Vector2 vector2_1 = -this._lastDistortionDrawOffset / 0.25f + (Main.drawToScreen ? Vector2.Zero : new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange));
      TileBatch tileBatch = Main.tileBatch;
      GraphicsDevice graphicsDevice = Main.instance.GraphicsDevice;
      Vector2 dimensions1 = new Vector2((float) Main.screenWidth, (float) Main.screenHeight);
      Vector2 vector2_2 = new Vector2(16f, 16f);
      tileBatch.Begin();
      GameShaders.Misc["WaterDistortionObject"].Apply(new DrawData?());
      if (this._useNPCWaves)
      {
        for (int index = 0; index < 200; ++index)
        {
          if (Main.npc[index] != null && Main.npc[index].active && (Main.npc[index].wet || Main.npc[index].wetCount != (byte) 0) && Collision.CheckAABBvAABBCollision(screenPosition, dimensions1, Main.npc[index].position - vector2_2, Main.npc[index].Size + vector2_2))
          {
            NPC npc = Main.npc[index];
            Vector2 vector2_3 = npc.Center - vector2_1;
            Vector2 vector2_4 = npc.velocity.RotatedBy(-(double) npc.rotation) / new Vector2((float) npc.height, (float) npc.width);
            float num1 = vector2_4.LengthSquared();
            float num2 = Math.Min((float) ((double) num1 * 0.300000011920929 + 0.699999988079071 * (double) num1 * (1024.0 / (double) (npc.height * npc.width))), 0.08f) + (npc.velocity - npc.oldVelocity).Length() * 0.5f;
            vector2_4.Normalize();
            Vector2 velocity = npc.velocity;
            velocity.Normalize();
            Vector2 vector2_5 = vector2_3 - velocity * 10f;
            if (!this._useViscosityFilter && (npc.honeyWet || npc.lavaWet))
              num2 *= 0.3f;
            if (npc.wet)
              tileBatch.Draw(TextureAssets.MagicPixel.Value, new Vector4(vector2_5.X, vector2_5.Y, (float) npc.width * 2f, (float) npc.height * 2f) * 0.25f, new Rectangle?(), new VertexColors(new Color((float) ((double) vector2_4.X * 0.5 + 0.5), (float) ((double) vector2_4.Y * 0.5 + 0.5), 0.5f * num2)), new Vector2((float) TextureAssets.MagicPixel.Width() / 2f, (float) TextureAssets.MagicPixel.Height() / 2f), SpriteEffects.None, npc.rotation);
            if (npc.wetCount != (byte) 0)
            {
              float num3 = 0.195f * (float) Math.Sqrt((double) npc.velocity.Length());
              float num4 = 5f;
              if (!npc.wet)
                num4 = -20f;
              this.QueueRipple(npc.Center + velocity * num4, new Color(0.5f, (float) ((npc.wet ? (double) num3 : -(double) num3) * 0.5 + 0.5), 0.0f, 1f) * 0.5f, new Vector2((float) npc.width, (float) npc.height * ((float) npc.wetCount / 9f)) * MathHelper.Clamp(num3 * 10f, 0.0f, 1f), RippleShape.Circle);
            }
          }
        }
      }
      if (this._usePlayerWaves)
      {
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index] != null && Main.player[index].active && (Main.player[index].wet || Main.player[index].wetCount != (byte) 0) && Collision.CheckAABBvAABBCollision(screenPosition, dimensions1, Main.player[index].position - vector2_2, Main.player[index].Size + vector2_2))
          {
            Player player = Main.player[index];
            Vector2 vector2_6 = player.Center - vector2_1;
            float num5 = 0.05f * (float) Math.Sqrt((double) player.velocity.Length());
            Vector2 velocity = player.velocity;
            velocity.Normalize();
            Vector2 vector2_7 = vector2_6 - velocity * 10f;
            if (!this._useViscosityFilter && (player.honeyWet || player.lavaWet))
              num5 *= 0.3f;
            if (player.wet)
              tileBatch.Draw(TextureAssets.MagicPixel.Value, new Vector4(vector2_7.X - (float) ((double) player.width * 2.0 * 0.5), vector2_7.Y - (float) ((double) player.height * 2.0 * 0.5), (float) player.width * 2f, (float) player.height * 2f) * 0.25f, new VertexColors(new Color((float) ((double) velocity.X * 0.5 + 0.5), (float) ((double) velocity.Y * 0.5 + 0.5), 0.5f * num5)));
            if (player.wetCount != (byte) 0)
            {
              float num6 = 5f;
              if (!player.wet)
                num6 = -20f;
              float num7 = num5 * 3f;
              this.QueueRipple(player.Center + velocity * num6, player.wet ? num7 : -num7, new Vector2((float) player.width, (float) player.height * ((float) player.wetCount / 9f)) * MathHelper.Clamp(num7 * 10f, 0.0f, 1f), RippleShape.Circle);
            }
          }
        }
      }
      if (this._useProjectileWaves)
      {
        for (int index = 0; index < 1000; ++index)
        {
          Projectile projectile = Main.projectile[index];
          int num8 = !projectile.wet || projectile.lavaWet ? 0 : (!projectile.honeyWet ? 1 : 0);
          bool flag1 = projectile.lavaWet;
          bool flag2 = projectile.honeyWet;
          bool flag3 = projectile.wet;
          if (projectile.ignoreWater)
            flag3 = true;
          if (((projectile == null || !projectile.active ? 0 : (ProjectileID.Sets.CanDistortWater[projectile.type] ? 1 : 0)) & (flag3 ? 1 : 0)) != 0 && !ProjectileID.Sets.NoLiquidDistortion[projectile.type] && Collision.CheckAABBvAABBCollision(screenPosition, dimensions1, projectile.position - vector2_2, projectile.Size + vector2_2))
          {
            if (projectile.ignoreWater)
            {
              int num9 = Collision.LavaCollision(projectile.position, projectile.width, projectile.height) ? 1 : 0;
              flag1 = Collision.WetCollision(projectile.position, projectile.width, projectile.height);
              flag2 = Collision.honey;
              int num10 = flag1 ? 1 : 0;
              if ((num9 | num10 | (flag2 ? 1 : 0)) == 0)
                continue;
            }
            Vector2 vector2_8 = projectile.Center - vector2_1;
            float num11 = 2f * (float) Math.Sqrt(0.0500000007450581 * (double) projectile.velocity.Length());
            Vector2 velocity = projectile.velocity;
            velocity.Normalize();
            if (!this._useViscosityFilter && flag2 | flag1)
              num11 *= 0.3f;
            float z = Math.Max(12f, (float) projectile.width * 0.75f);
            float w = Math.Max(12f, (float) projectile.height * 0.75f);
            tileBatch.Draw(TextureAssets.MagicPixel.Value, new Vector4(vector2_8.X - z * 0.5f, vector2_8.Y - w * 0.5f, z, w) * 0.25f, new VertexColors(new Color((float) ((double) velocity.X * 0.5 + 0.5), (float) ((double) velocity.Y * 0.5 + 0.5), num11 * 0.5f)));
          }
        }
      }
      tileBatch.End();
      if (this._useRippleWaves)
      {
        tileBatch.Begin();
        for (int index = 0; index < this._rippleQueueCount; ++index)
        {
          Vector2 vector2_9 = this._rippleQueue[index].Position - vector2_1;
          Vector2 size = this._rippleQueue[index].Size;
          Rectangle sourceRectangle = this._rippleQueue[index].SourceRectangle;
          Texture2D texture = this._rippleShapeTexture.Value;
          tileBatch.Draw(texture, new Vector4(vector2_9.X, vector2_9.Y, size.X, size.Y) * 0.25f, new Rectangle?(sourceRectangle), new VertexColors(this._rippleQueue[index].WaveData), new Vector2((float) (sourceRectangle.Width / 2), (float) (sourceRectangle.Height / 2)), SpriteEffects.None, this._rippleQueue[index].Rotation);
        }
        tileBatch.End();
      }
      this._rippleQueueCount = 0;
      if (!this._useCustomWaves || this.OnWaveDraw == null)
        return;
      tileBatch.Begin();
      this.OnWaveDraw(tileBatch);
      tileBatch.End();
    }

    private void PreDraw(GameTime gameTime)
    {
      this.ValidateRenderTargets();
      if (!this._usingRenderTargets || !Main.IsGraphicsDeviceAvailable)
        return;
      if (this._useProjectileWaves || this._useRippleWaves || this._useCustomWaves || this._usePlayerWaves)
      {
        for (int index = 0; index < Math.Min(this._queuedSteps, 2); ++index)
          this.StepLiquids();
      }
      else if (this._isWaveBufferDirty || this._clearNextFrame)
      {
        GraphicsDevice graphicsDevice = Main.instance.GraphicsDevice;
        graphicsDevice.SetRenderTarget(this._distortionTarget);
        graphicsDevice.Clear(new Color(0.5f, 0.5f, 0.0f, 1f));
        this._clearNextFrame = false;
        this._isWaveBufferDirty = false;
        graphicsDevice.SetRenderTarget((RenderTarget2D) null);
      }
      this._queuedSteps = 0;
    }

    public override void Apply()
    {
      if (!this._usingRenderTargets || !Main.IsGraphicsDeviceAvailable)
        return;
      this.UseProgress(this._progress);
      Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
      Vector2 vector2_1 = new Vector2((float) Main.screenWidth, (float) Main.screenHeight) * 0.5f * (Vector2.One - Vector2.One / Main.GameViewMatrix.Zoom);
      Vector2 vector2_2 = (Main.drawToScreen ? Vector2.Zero : new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange)) - Main.screenPosition - vector2_1;
      this.UseImage((Texture2D) this._distortionTarget, 1);
      this.UseImage((Texture2D) Main.waterTarget, 2, SamplerState.PointClamp);
      this.UseTargetPosition(Main.screenPosition - Main.sceneWaterPos + new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange) + vector2_1);
      this.UseImageOffset(-(vector2_2 * 0.25f - this._lastDistortionDrawOffset) / new Vector2((float) this._distortionTarget.Width, (float) this._distortionTarget.Height));
      base.Apply();
    }

    private void ValidateRenderTargets()
    {
      int backBufferWidth = Main.instance.GraphicsDevice.PresentationParameters.BackBufferWidth;
      int backBufferHeight = Main.instance.GraphicsDevice.PresentationParameters.BackBufferHeight;
      bool flag = !Main.drawToScreen;
      if (this._usingRenderTargets && !flag)
        this.ReleaseRenderTargets();
      else if (!this._usingRenderTargets & flag)
      {
        this.InitRenderTargets(backBufferWidth, backBufferHeight);
      }
      else
      {
        if (!(this._usingRenderTargets & flag) || !this._distortionTarget.IsContentLost && !this._distortionTargetSwap.IsContentLost)
          return;
        this._clearNextFrame = true;
      }
    }

    private void InitRenderTargets(int width, int height)
    {
      this._lastScreenWidth = width;
      this._lastScreenHeight = height;
      width = (int) ((double) width * 0.25);
      height = (int) ((double) height * 0.25);
      try
      {
        this._distortionTarget = new RenderTarget2D(Main.instance.GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
        this._distortionTargetSwap = new RenderTarget2D(Main.instance.GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
        this._usingRenderTargets = true;
        this._clearNextFrame = true;
      }
      catch (Exception ex)
      {
        Lighting.Mode = LightMode.Retro;
        this._usingRenderTargets = false;
        Console.WriteLine("Failed to create water distortion render targets. " + (object) ex);
      }
    }

    private void ReleaseRenderTargets()
    {
      try
      {
        if (this._distortionTarget != null)
          this._distortionTarget.Dispose();
        if (this._distortionTargetSwap != null)
          this._distortionTargetSwap.Dispose();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error disposing of water distortion render targets. " + (object) ex);
      }
      this._distortionTarget = (RenderTarget2D) null;
      this._distortionTargetSwap = (RenderTarget2D) null;
      this._usingRenderTargets = false;
    }

    public void QueueRipple(Vector2 position, float strength = 1f, RippleShape shape = RippleShape.Square, float rotation = 0.0f)
    {
      float g = (float) ((double) strength * 0.5 + 0.5);
      float num = Math.Min(Math.Abs(strength), 1f);
      this.QueueRipple(position, new Color(0.5f, g, 0.0f, 1f) * num, new Vector2(4f * Math.Max(Math.Abs(strength), 1f)), shape, rotation);
    }

    public void QueueRipple(
      Vector2 position,
      float strength,
      Vector2 size,
      RippleShape shape = RippleShape.Square,
      float rotation = 0.0f)
    {
      float g = (float) ((double) strength * 0.5 + 0.5);
      float num = Math.Min(Math.Abs(strength), 1f);
      this.QueueRipple(position, new Color(0.5f, g, 0.0f, 1f) * num, size, shape, rotation);
    }

    public void QueueRipple(
      Vector2 position,
      Color waveData,
      Vector2 size,
      RippleShape shape = RippleShape.Square,
      float rotation = 0.0f)
    {
      if (!this._useRippleWaves || Main.drawToScreen)
      {
        this._rippleQueueCount = 0;
      }
      else
      {
        if (this._rippleQueueCount >= this._rippleQueue.Length)
          return;
        this._rippleQueue[this._rippleQueueCount++] = new WaterShaderData.Ripple(position, waveData, size, shape, rotation);
      }
    }

    private struct Ripple
    {
      private static readonly Rectangle[] RIPPLE_SHAPE_SOURCE_RECTS = new Rectangle[3]
      {
        new Rectangle(0, 0, 0, 0),
        new Rectangle(1, 1, 62, 62),
        new Rectangle(1, 65, 62, 62)
      };
      public readonly Vector2 Position;
      public readonly Color WaveData;
      public readonly Vector2 Size;
      public readonly RippleShape Shape;
      public readonly float Rotation;

      public Rectangle SourceRectangle => WaterShaderData.Ripple.RIPPLE_SHAPE_SOURCE_RECTS[(int) this.Shape];

      public Ripple(
        Vector2 position,
        Color waveData,
        Vector2 size,
        RippleShape shape,
        float rotation)
      {
        this.Position = position;
        this.WaveData = waveData;
        this.Size = size;
        this.Shape = shape;
        this.Rotation = rotation;
      }
    }
  }
}
