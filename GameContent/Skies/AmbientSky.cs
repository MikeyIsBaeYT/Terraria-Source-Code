// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.AmbientSky
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent.Ambience;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class AmbientSky : CustomSky
  {
    private bool _isActive;
    private readonly SlotVector<AmbientSky.SkyEntity> _entities = new SlotVector<AmbientSky.SkyEntity>(500);
    private int _frameCounter;

    public override void Activate(Vector2 position, params object[] args) => this._isActive = true;

    public override void Deactivate(params object[] args) => this._isActive = false;

    private bool AnActiveSkyConflictsWithAmbience() => SkyManager.Instance["MonolithMoonLord"].IsActive() || SkyManager.Instance["MoonLord"].IsActive();

    public override void Update(GameTime gameTime)
    {
      if (Main.gamePaused)
        return;
      ++this._frameCounter;
      if (Main.netMode != 2 && this.AnActiveSkyConflictsWithAmbience() && SkyManager.Instance["Ambience"].IsActive())
        SkyManager.Instance.Deactivate("Ambience");
      foreach (SlotVector<AmbientSky.SkyEntity>.ItemPair entity in (IEnumerable<SlotVector<AmbientSky.SkyEntity>.ItemPair>) this._entities)
      {
        // ISSUE: variable of the null type
        __Null local = entity.Value;
        ((AmbientSky.SkyEntity) local).Update(this._frameCounter);
        if (!((AmbientSky.SkyEntity) local).IsActive)
        {
          this._entities.Remove((SlotId) entity.Id);
          if (Main.netMode != 2 && this._entities.Count == 0 && SkyManager.Instance["Ambience"].IsActive())
            SkyManager.Instance.Deactivate("Ambience");
        }
      }
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if (Main.gameMenu && Main.netMode == 0 && SkyManager.Instance["Ambience"].IsActive())
      {
        this._entities.Clear();
        SkyManager.Instance.Deactivate("Ambience");
      }
      foreach (SlotVector<AmbientSky.SkyEntity>.ItemPair entity in (IEnumerable<SlotVector<AmbientSky.SkyEntity>.ItemPair>) this._entities)
        ((AmbientSky.SkyEntity) entity.Value).Draw(spriteBatch, 3f, minDepth, maxDepth);
    }

    public override bool IsActive() => this._isActive;

    public override void Reset()
    {
    }

    public void Spawn(Player player, SkyEntityType type, int seed)
    {
      FastRandom random = new FastRandom(seed);
      switch (type)
      {
        case SkyEntityType.BirdsV:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.BirdsPackSkyEntity(player, random));
          break;
        case SkyEntityType.Wyvern:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.WyvernSkyEntity(player, random));
          break;
        case SkyEntityType.Airship:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.AirshipSkyEntity(player, random));
          break;
        case SkyEntityType.AirBalloon:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.AirBalloonSkyEntity(player, random));
          break;
        case SkyEntityType.Eyeball:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.EOCSkyEntity(player, random));
          break;
        case SkyEntityType.Meteor:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.MeteorSkyEntity(player, random));
          break;
        case SkyEntityType.Bats:
          List<AmbientSky.BatsGroupSkyEntity> group1 = AmbientSky.BatsGroupSkyEntity.CreateGroup(player, random);
          for (int index = 0; index < group1.Count; ++index)
            this._entities.Add((AmbientSky.SkyEntity) group1[index]);
          break;
        case SkyEntityType.Butterflies:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.ButterfliesSkyEntity(player, random));
          break;
        case SkyEntityType.LostKite:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.LostKiteSkyEntity(player, random));
          break;
        case SkyEntityType.Vulture:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.VultureSkyEntity(player, random));
          break;
        case SkyEntityType.PixiePosse:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.PixiePosseSkyEntity(player, random));
          break;
        case SkyEntityType.Seagulls:
          List<AmbientSky.SeagullsGroupSkyEntity> group2 = AmbientSky.SeagullsGroupSkyEntity.CreateGroup(player, random);
          for (int index = 0; index < group2.Count; ++index)
            this._entities.Add((AmbientSky.SkyEntity) group2[index]);
          break;
        case SkyEntityType.SlimeBalloons:
          List<AmbientSky.SlimeBalloonGroupSkyEntity> group3 = AmbientSky.SlimeBalloonGroupSkyEntity.CreateGroup(player, random);
          for (int index = 0; index < group3.Count; ++index)
            this._entities.Add((AmbientSky.SkyEntity) group3[index]);
          break;
        case SkyEntityType.Gastropods:
          List<AmbientSky.GastropodGroupSkyEntity> group4 = AmbientSky.GastropodGroupSkyEntity.CreateGroup(player, random);
          for (int index = 0; index < group4.Count; ++index)
            this._entities.Add((AmbientSky.SkyEntity) group4[index]);
          break;
        case SkyEntityType.Pegasus:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.PegasusSkyEntity(player, random));
          break;
        case SkyEntityType.EaterOfSouls:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.EOSSkyEntity(player, random));
          break;
        case SkyEntityType.Crimera:
          this._entities.Add((AmbientSky.SkyEntity) new AmbientSky.CrimeraSkyEntity(player, random));
          break;
        case SkyEntityType.Hellbats:
          List<AmbientSky.HellBatsGoupSkyEntity> group5 = AmbientSky.HellBatsGoupSkyEntity.CreateGroup(player, random);
          for (int index = 0; index < group5.Count; ++index)
            this._entities.Add((AmbientSky.SkyEntity) group5[index]);
          break;
      }
      if (Main.netMode == 2 || this.AnActiveSkyConflictsWithAmbience() || SkyManager.Instance["Ambience"].IsActive())
        return;
      SkyManager.Instance.Activate("Ambience", new Vector2());
    }

    private abstract class SkyEntity
    {
      public Vector2 Position;
      public Asset<Texture2D> Texture;
      public SpriteFrame Frame;
      public float Depth;
      public SpriteEffects Effects;
      public bool IsActive = true;
      public float Rotation;

      public Rectangle SourceRectangle => this.Frame.GetSourceRectangle(this.Texture.Value);

      protected void NextFrame() => this.Frame.CurrentRow = (byte) (((uint) this.Frame.CurrentRow + 1U) % (uint) this.Frame.RowCount);

      public abstract Color GetColor(Color backgroundColor);

      public abstract void Update(int frameCount);

      protected void SetPositionInWorldBasedOnScreenSpace(Vector2 actualWorldSpace)
      {
        Vector2 vector2 = actualWorldSpace - Main.Camera.Center;
        this.Position = Main.Camera.Center + vector2 * (this.Depth / 3f);
      }

      public abstract Vector2 GetDrawPosition();

      public virtual void Draw(
        SpriteBatch spriteBatch,
        float depthScale,
        float minDepth,
        float maxDepth)
      {
        this.CommonDraw(spriteBatch, depthScale, minDepth, maxDepth);
      }

      public void CommonDraw(
        SpriteBatch spriteBatch,
        float depthScale,
        float minDepth,
        float maxDepth)
      {
        if ((double) this.Depth <= (double) minDepth || (double) this.Depth > (double) maxDepth)
          return;
        Vector2 drawPositionByDepth = this.GetDrawPositionByDepth();
        Color color = this.GetColor(Main.ColorOfTheSkies) * Main.atmo;
        Vector2 origin = this.SourceRectangle.Size() / 2f;
        float scale = depthScale / this.Depth;
        spriteBatch.Draw(this.Texture.Value, drawPositionByDepth - Main.Camera.UnscaledPosition, new Rectangle?(this.SourceRectangle), color, this.Rotation, origin, scale, this.Effects, 0.0f);
      }

      internal Vector2 GetDrawPositionByDepth() => (this.GetDrawPosition() - Main.Camera.Center) * new Vector2(1f / this.Depth, 0.9f / this.Depth) + Main.Camera.Center;

      internal float Helper_GetOpacityWithAccountingForOceanWaterLine()
      {
        float t = (this.GetDrawPositionByDepth() - Main.Camera.UnscaledPosition).Y + (float) (this.SourceRectangle.Height / 2);
        float yscreenPosition = AmbientSkyDrawCache.Instance.OceanLineInfo.YScreenPosition;
        return 1f - Utils.GetLerpValue(yscreenPosition - 10f, yscreenPosition - 2f, t, true) * AmbientSkyDrawCache.Instance.OceanLineInfo.OceanOpacity;
      }
    }

    private class FadingSkyEntity : AmbientSky.SkyEntity
    {
      protected int LifeTime;
      protected Vector2 Velocity;
      protected int FramingSpeed;
      protected int TimeEntitySpawnedIn;
      protected float Opacity;
      protected float BrightnessLerper;
      protected float FinalOpacityMultiplier;
      protected float OpacityNormalizedTimeToFadeIn;
      protected float OpacityNormalizedTimeToFadeOut;
      protected int FrameOffset;

      public FadingSkyEntity()
      {
        this.Opacity = 0.0f;
        this.TimeEntitySpawnedIn = -1;
        this.BrightnessLerper = 0.0f;
        this.FinalOpacityMultiplier = 1f;
        this.OpacityNormalizedTimeToFadeIn = 0.1f;
        this.OpacityNormalizedTimeToFadeOut = 0.9f;
      }

      public override void Update(int frameCount)
      {
        if (this.IsMovementDone(frameCount))
          return;
        this.UpdateOpacity(frameCount);
        if ((frameCount + this.FrameOffset) % this.FramingSpeed == 0)
          this.NextFrame();
        this.UpdateVelocity(frameCount);
        this.Position = this.Position + this.Velocity;
      }

      public virtual void UpdateVelocity(int frameCount)
      {
      }

      private void UpdateOpacity(int frameCount)
      {
        int num = frameCount - this.TimeEntitySpawnedIn;
        if ((double) num >= (double) this.LifeTime * (double) this.OpacityNormalizedTimeToFadeOut)
          this.Opacity = Utils.GetLerpValue((float) this.LifeTime, (float) this.LifeTime * this.OpacityNormalizedTimeToFadeOut, (float) num, true);
        else
          this.Opacity = Utils.GetLerpValue(0.0f, (float) this.LifeTime * this.OpacityNormalizedTimeToFadeIn, (float) num, true);
      }

      private bool IsMovementDone(int frameCount)
      {
        if (this.TimeEntitySpawnedIn == -1)
          this.TimeEntitySpawnedIn = frameCount;
        if (frameCount - this.TimeEntitySpawnedIn < this.LifeTime)
          return false;
        this.IsActive = false;
        return true;
      }

      public override Color GetColor(Color backgroundColor) => Color.Lerp(backgroundColor, Color.White, this.BrightnessLerper) * this.Opacity * this.FinalOpacityMultiplier * this.Helper_GetOpacityWithAccountingForOceanWaterLine();

      public void StartFadingOut(int currentFrameCount)
      {
        int num1 = (int) ((double) this.LifeTime * (double) this.OpacityNormalizedTimeToFadeOut);
        int num2 = currentFrameCount - num1;
        if (num2 >= this.TimeEntitySpawnedIn)
          return;
        this.TimeEntitySpawnedIn = num2;
      }

      public override Vector2 GetDrawPosition() => this.Position;
    }

    private class ButterfliesSkyEntity : AmbientSky.FadingSkyEntity
    {
      public ButterfliesSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num1 = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        else
          this.Position.X = virtualCamera.Position.X - (float) num1;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 4000.0) + 4000.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        int num2 = random.Next(2) + 1;
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/ButterflySwarm" + (object) num2, (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, num2 == 2 ? (byte) 19 : (byte) 17);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((0.100000001490116 + (double) Math.Abs(Main.WindForVisuals) * 0.0500000007450581) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }
    }

    private class LostKiteSkyEntity : AmbientSky.FadingSkyEntity
    {
      public LostKiteSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num1 = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        else
          this.Position.X = virtualCamera.Position.X - (float) num1;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/LostKite", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 42);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 6;
        int num2 = random.Next((int) this.Frame.RowCount);
        for (int index = 0; index < num2; ++index)
          this.NextFrame();
      }

      public override void UpdateVelocity(int frameCount)
      {
        float num = (float) (1.20000004768372 + (double) Math.Abs(Main.WindForVisuals) * 3.0);
        if (Main.IsItStorming)
          num *= 1.5f;
        this.Velocity = new Vector2(num * (this.Effects == SpriteEffects.FlipHorizontally ? -1f : 1f), 0.0f);
      }

      public override void Update(int frameCount)
      {
        if (Main.IsItStorming)
          this.FramingSpeed = 4;
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        base.Update(frameCount);
        if (Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }
    }

    private class PegasusSkyEntity : AmbientSky.FadingSkyEntity
    {
      public PegasusSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Pegasus", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 11);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((1.5 + (double) Math.Abs(Main.WindForVisuals) * 0.600000023841858) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }

      public override Color GetColor(Color backgroundColor) => base.GetColor(backgroundColor) * Main.bgAlphaFrontLayer[6];
    }

    private class VultureSkyEntity : AmbientSky.FadingSkyEntity
    {
      public VultureSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Vulture", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 10);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((3.0 + (double) Math.Abs(Main.WindForVisuals) * 0.800000011920929) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }

      public override Color GetColor(Color backgroundColor) => base.GetColor(backgroundColor) * Math.Max(Main.bgAlphaFrontLayer[2], Main.bgAlphaFrontLayer[5]);
    }

    private class PixiePosseSkyEntity : AmbientSky.FadingSkyEntity
    {
      private int pixieType = 1;

      public PixiePosseSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 4000.0) + 4000.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 2.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        if (!Main.dayTime)
          this.pixieType = 2;
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/PixiePosse" + (object) this.pixieType, (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 25);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.6f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((0.119999997317791 + (double) Math.Abs(Main.WindForVisuals) * 0.0799999982118607) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if ((this.pixieType != 1 || Main.dayTime) && (this.pixieType != 2 || !Main.dayTime) && !Main.IsItRaining && !Main.eclipse && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon)
          return;
        this.StartFadingOut(frameCount);
      }

      public override void Draw(
        SpriteBatch spriteBatch,
        float depthScale,
        float minDepth,
        float maxDepth)
      {
        this.CommonDraw(spriteBatch, depthScale - 0.1f, minDepth, maxDepth);
      }
    }

    private class BirdsPackSkyEntity : AmbientSky.FadingSkyEntity
    {
      public BirdsPackSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/BirdsVShape", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 4);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((3.0 + (double) Math.Abs(Main.WindForVisuals) * 0.800000011920929) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }
    }

    private class SeagullsGroupSkyEntity : AmbientSky.FadingSkyEntity
    {
      private Vector2 _magnetAccelerations;
      private Vector2 _magnetPointTarget;
      private Vector2 _positionVsMagnet;
      private Vector2 _velocityVsMagnet;

      public SeagullsGroupSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num1 = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        else
          this.Position.X = virtualCamera.Position.X - (float) num1;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Seagull", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 9);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.1f;
        this.OpacityNormalizedTimeToFadeOut = 0.9f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 4;
        this.FrameOffset = random.Next(0, (int) this.Frame.RowCount);
        int num2 = random.Next((int) this.Frame.RowCount);
        for (int index = 0; index < num2; ++index)
          this.NextFrame();
      }

      public override void UpdateVelocity(int frameCount)
      {
        this._velocityVsMagnet += this._magnetAccelerations * new Vector2((float) Math.Sign(this._magnetPointTarget.X - this._positionVsMagnet.X), (float) Math.Sign(this._magnetPointTarget.Y - this._positionVsMagnet.Y));
        this._positionVsMagnet += this._velocityVsMagnet;
        this.Velocity = new Vector2((float) (4.0 * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f) + this._velocityVsMagnet;
      }

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }

      public void SetMagnetization(Vector2 accelerations, Vector2 targetOffset)
      {
        this._magnetAccelerations = accelerations;
        this._magnetPointTarget = targetOffset;
      }

      public override Color GetColor(Color backgroundColor) => base.GetColor(backgroundColor) * Main.bgAlphaFrontLayer[4];

      public override void Draw(
        SpriteBatch spriteBatch,
        float depthScale,
        float minDepth,
        float maxDepth)
      {
        this.CommonDraw(spriteBatch, depthScale - 1.5f, minDepth, maxDepth);
      }

      public static List<AmbientSky.SeagullsGroupSkyEntity> CreateGroup(
        Player player,
        FastRandom random)
      {
        List<AmbientSky.SeagullsGroupSkyEntity> seagullsGroupSkyEntityList = new List<AmbientSky.SeagullsGroupSkyEntity>();
        int num1 = 100;
        int num2 = random.Next(5, 9);
        float num3 = 100f;
        VirtualCamera virtualCamera = new VirtualCamera(player);
        SpriteEffects spriteEffects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        Vector2 vector2_1 = new Vector2();
        vector2_1.X = spriteEffects != SpriteEffects.FlipHorizontally ? virtualCamera.Position.X - (float) num1 : virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        vector2_1.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        float num4 = (float) ((double) random.NextFloat() * 2.0 + 1.0);
        int num5 = random.Next(30, 61) * 60;
        Vector2 vector2_2 = new Vector2((float) ((double) random.NextFloat() * 0.5 + 0.5), (float) ((double) random.NextFloat() * 0.5 + 0.5));
        Vector2 targetOffset = new Vector2((float) ((double) random.NextFloat() * 2.0 - 1.0), (float) ((double) random.NextFloat() * 2.0 - 1.0)) * num3;
        for (int index = 0; index < num2; ++index)
        {
          AmbientSky.SeagullsGroupSkyEntity seagullsGroupSkyEntity = new AmbientSky.SeagullsGroupSkyEntity(player, random);
          seagullsGroupSkyEntity.Depth = num4 + random.NextFloat() * 0.5f;
          seagullsGroupSkyEntity.Position = vector2_1 + new Vector2((float) ((double) random.NextFloat() * 20.0 - 10.0), random.NextFloat() * 3f) * 50f;
          seagullsGroupSkyEntity.Effects = spriteEffects;
          seagullsGroupSkyEntity.SetPositionInWorldBasedOnScreenSpace(seagullsGroupSkyEntity.Position);
          seagullsGroupSkyEntity.LifeTime = num5 + random.Next(301);
          seagullsGroupSkyEntity.SetMagnetization(vector2_2 * (float) ((double) random.NextFloat() * 0.300000011920929 + 0.850000023841858) * 0.05f, targetOffset);
          seagullsGroupSkyEntityList.Add(seagullsGroupSkyEntity);
        }
        return seagullsGroupSkyEntityList;
      }
    }

    private class GastropodGroupSkyEntity : AmbientSky.FadingSkyEntity
    {
      private Vector2 _magnetAccelerations;
      private Vector2 _magnetPointTarget;
      private Vector2 _positionVsMagnet;
      private Vector2 _velocityVsMagnet;

      public GastropodGroupSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 3200.0) + 3200.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 2.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Gastropod", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 1);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.1f;
        this.OpacityNormalizedTimeToFadeOut = 0.9f;
        this.BrightnessLerper = 0.75f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = int.MaxValue;
      }

      public override void UpdateVelocity(int frameCount)
      {
        this._velocityVsMagnet += this._magnetAccelerations * new Vector2((float) Math.Sign(this._magnetPointTarget.X - this._positionVsMagnet.X), (float) Math.Sign(this._magnetPointTarget.Y - this._positionVsMagnet.Y));
        this._positionVsMagnet += this._velocityVsMagnet;
        this.Velocity = new Vector2((float) ((1.5 + (double) Math.Abs(Main.WindForVisuals) * 0.200000002980232) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f) + this._velocityVsMagnet;
        this.Rotation = this.Velocity.X * 0.1f;
      }

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && !Main.dayTime && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon)
          return;
        this.StartFadingOut(frameCount);
      }

      public override Color GetColor(Color backgroundColor) => Color.Lerp(backgroundColor, Colors.AmbientNPCGastropodLight, this.BrightnessLerper) * this.Opacity * this.FinalOpacityMultiplier;

      public override void Draw(
        SpriteBatch spriteBatch,
        float depthScale,
        float minDepth,
        float maxDepth)
      {
        this.CommonDraw(spriteBatch, depthScale - 0.1f, minDepth, maxDepth);
      }

      public void SetMagnetization(Vector2 accelerations, Vector2 targetOffset)
      {
        this._magnetAccelerations = accelerations;
        this._magnetPointTarget = targetOffset;
      }

      public static List<AmbientSky.GastropodGroupSkyEntity> CreateGroup(
        Player player,
        FastRandom random)
      {
        List<AmbientSky.GastropodGroupSkyEntity> gastropodGroupSkyEntityList = new List<AmbientSky.GastropodGroupSkyEntity>();
        int num1 = 100;
        int num2 = random.Next(3, 8);
        VirtualCamera virtualCamera = new VirtualCamera(player);
        SpriteEffects spriteEffects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        Vector2 vector2_1 = new Vector2();
        vector2_1.X = spriteEffects != SpriteEffects.FlipHorizontally ? virtualCamera.Position.X - (float) num1 : virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        vector2_1.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 3200.0) + 3200.0);
        float num3 = (float) ((double) random.NextFloat() * 3.0 + 2.0);
        int num4 = random.Next(30, 61) * 60;
        Vector2 vector2_2 = new Vector2((float) ((double) random.NextFloat() * 0.100000001490116 + 0.100000001490116), (float) ((double) random.NextFloat() * 0.300000011920929 + 0.300000011920929));
        Vector2 targetOffset = new Vector2((float) ((double) random.NextFloat() * 2.0 - 1.0), (float) ((double) random.NextFloat() * 2.0 - 1.0)) * 120f;
        for (int index = 0; index < num2; ++index)
        {
          AmbientSky.GastropodGroupSkyEntity gastropodGroupSkyEntity = new AmbientSky.GastropodGroupSkyEntity(player, random);
          gastropodGroupSkyEntity.Depth = num3 + random.NextFloat() * 0.5f;
          gastropodGroupSkyEntity.Position = vector2_1 + new Vector2((float) ((double) random.NextFloat() * 20.0 - 10.0), random.NextFloat() * 3f) * 60f;
          gastropodGroupSkyEntity.Effects = spriteEffects;
          gastropodGroupSkyEntity.SetPositionInWorldBasedOnScreenSpace(gastropodGroupSkyEntity.Position);
          gastropodGroupSkyEntity.LifeTime = num4 + random.Next(301);
          gastropodGroupSkyEntity.SetMagnetization(vector2_2 * (random.NextFloat() * 0.5f) * 0.05f, targetOffset);
          gastropodGroupSkyEntityList.Add(gastropodGroupSkyEntity);
        }
        return gastropodGroupSkyEntityList;
      }
    }

    private class SlimeBalloonGroupSkyEntity : AmbientSky.FadingSkyEntity
    {
      private Vector2 _magnetAccelerations;
      private Vector2 _magnetPointTarget;
      private Vector2 _positionVsMagnet;
      private Vector2 _velocityVsMagnet;

      public SlimeBalloonGroupSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 4000.0) + 4000.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/SlimeBalloons", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 7);
        this.Frame.CurrentRow = (byte) random.Next(7);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.025f;
        this.OpacityNormalizedTimeToFadeOut = 0.975f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = int.MaxValue;
      }

      public override void UpdateVelocity(int frameCount)
      {
        this._velocityVsMagnet += this._magnetAccelerations * new Vector2((float) Math.Sign(this._magnetPointTarget.X - this._positionVsMagnet.X), (float) Math.Sign(this._magnetPointTarget.Y - this._positionVsMagnet.Y));
        this._positionVsMagnet += this._velocityVsMagnet;
        this.Velocity = new Vector2((float) ((1.0 + (double) Math.Abs(Main.WindForVisuals) * 1.0) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), -0.01f) + this._velocityVsMagnet;
        this.Rotation = this.Velocity.X * 0.1f;
      }

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        if (Main.IsItAHappyWindyDay && !Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }

      public void SetMagnetization(Vector2 accelerations, Vector2 targetOffset)
      {
        this._magnetAccelerations = accelerations;
        this._magnetPointTarget = targetOffset;
      }

      public static List<AmbientSky.SlimeBalloonGroupSkyEntity> CreateGroup(
        Player player,
        FastRandom random)
      {
        List<AmbientSky.SlimeBalloonGroupSkyEntity> balloonGroupSkyEntityList = new List<AmbientSky.SlimeBalloonGroupSkyEntity>();
        int num1 = 100;
        int num2 = random.Next(5, 10);
        VirtualCamera virtualCamera = new VirtualCamera(player);
        SpriteEffects spriteEffects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        Vector2 vector2_1 = new Vector2();
        vector2_1.X = spriteEffects != SpriteEffects.FlipHorizontally ? virtualCamera.Position.X - (float) num1 : virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        vector2_1.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        float num3 = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        int num4 = random.Next(80, 121) * 60;
        Vector2 vector2_2 = new Vector2((float) ((double) random.NextFloat() * 0.100000001490116 + 0.100000001490116), (float) ((double) random.NextFloat() * 0.100000001490116 + 0.100000001490116));
        Vector2 targetOffset = new Vector2((float) ((double) random.NextFloat() * 2.0 - 1.0), (float) ((double) random.NextFloat() * 2.0 - 1.0)) * 150f;
        for (int index = 0; index < num2; ++index)
        {
          AmbientSky.SlimeBalloonGroupSkyEntity balloonGroupSkyEntity = new AmbientSky.SlimeBalloonGroupSkyEntity(player, random);
          balloonGroupSkyEntity.Depth = num3 + random.NextFloat() * 0.5f;
          balloonGroupSkyEntity.Position = vector2_1 + new Vector2((float) ((double) random.NextFloat() * 20.0 - 10.0), random.NextFloat() * 3f) * 80f;
          balloonGroupSkyEntity.Effects = spriteEffects;
          balloonGroupSkyEntity.SetPositionInWorldBasedOnScreenSpace(balloonGroupSkyEntity.Position);
          balloonGroupSkyEntity.LifeTime = num4 + random.Next(301);
          balloonGroupSkyEntity.SetMagnetization(vector2_2 * (random.NextFloat() * 0.2f) * 0.05f, targetOffset);
          balloonGroupSkyEntityList.Add(balloonGroupSkyEntity);
        }
        return balloonGroupSkyEntityList;
      }
    }

    private class HellBatsGoupSkyEntity : AmbientSky.FadingSkyEntity
    {
      private Vector2 _magnetAccelerations;
      private Vector2 _magnetPointTarget;
      private Vector2 _positionVsMagnet;
      private Vector2 _velocityVsMagnet;

      public HellBatsGoupSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num1 = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        else
          this.Position.X = virtualCamera.Position.X - (float) num1;
        this.Position.Y = random.NextFloat() * 400f + (float) (Main.UnderworldLayer * 16);
        this.Depth = (float) ((double) random.NextFloat() * 5.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/HellBat" + (object) random.Next(1, 3), (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 10);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.1f;
        this.OpacityNormalizedTimeToFadeOut = 0.9f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 4;
        this.FrameOffset = random.Next(0, (int) this.Frame.RowCount);
        int num2 = random.Next((int) this.Frame.RowCount);
        for (int index = 0; index < num2; ++index)
          this.NextFrame();
      }

      public override void UpdateVelocity(int frameCount)
      {
        this._velocityVsMagnet += this._magnetAccelerations * new Vector2((float) Math.Sign(this._magnetPointTarget.X - this._positionVsMagnet.X), (float) Math.Sign(this._magnetPointTarget.Y - this._positionVsMagnet.Y));
        this._positionVsMagnet += this._velocityVsMagnet;
        this.Velocity = new Vector2((float) ((3.0 + (double) Math.Abs(Main.WindForVisuals) * 0.800000011920929) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f) + this._velocityVsMagnet;
      }

      public override void Update(int frameCount) => base.Update(frameCount);

      public void SetMagnetization(Vector2 accelerations, Vector2 targetOffset)
      {
        this._magnetAccelerations = accelerations;
        this._magnetPointTarget = targetOffset;
      }

      public override Color GetColor(Color backgroundColor) => Color.Lerp(Color.White, Color.Gray, this.Depth / 15f) * this.Opacity * this.FinalOpacityMultiplier;

      public static List<AmbientSky.HellBatsGoupSkyEntity> CreateGroup(
        Player player,
        FastRandom random)
      {
        List<AmbientSky.HellBatsGoupSkyEntity> batsGoupSkyEntityList = new List<AmbientSky.HellBatsGoupSkyEntity>();
        int num1 = 100;
        int num2 = random.Next(20, 40);
        VirtualCamera virtualCamera = new VirtualCamera(player);
        SpriteEffects spriteEffects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        Vector2 vector2_1 = new Vector2();
        vector2_1.X = spriteEffects != SpriteEffects.FlipHorizontally ? virtualCamera.Position.X - (float) num1 : virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        vector2_1.Y = random.NextFloat() * 800f + (float) (Main.UnderworldLayer * 16);
        float num3 = (float) ((double) random.NextFloat() * 5.0 + 3.0);
        int num4 = random.Next(30, 61) * 60;
        Vector2 vector2_2 = new Vector2((float) ((double) random.NextFloat() * 0.5 + 0.5), (float) ((double) random.NextFloat() * 0.5 + 0.5));
        Vector2 targetOffset = new Vector2((float) ((double) random.NextFloat() * 2.0 - 1.0), (float) ((double) random.NextFloat() * 2.0 - 1.0)) * 100f;
        for (int index = 0; index < num2; ++index)
        {
          AmbientSky.HellBatsGoupSkyEntity batsGoupSkyEntity = new AmbientSky.HellBatsGoupSkyEntity(player, random);
          batsGoupSkyEntity.Depth = num3 + random.NextFloat() * 0.5f;
          batsGoupSkyEntity.Position = vector2_1 + new Vector2((float) ((double) random.NextFloat() * 20.0 - 10.0), random.NextFloat() * 3f) * 50f;
          batsGoupSkyEntity.Effects = spriteEffects;
          batsGoupSkyEntity.SetPositionInWorldBasedOnScreenSpace(batsGoupSkyEntity.Position);
          batsGoupSkyEntity.LifeTime = num4 + random.Next(301);
          batsGoupSkyEntity.SetMagnetization(vector2_2 * (float) ((double) random.NextFloat() * 0.300000011920929 + 0.850000023841858) * 0.05f, targetOffset);
          batsGoupSkyEntityList.Add(batsGoupSkyEntity);
        }
        return batsGoupSkyEntityList;
      }
    }

    private class BatsGroupSkyEntity : AmbientSky.FadingSkyEntity
    {
      private Vector2 _magnetAccelerations;
      private Vector2 _magnetPointTarget;
      private Vector2 _positionVsMagnet;
      private Vector2 _velocityVsMagnet;

      public BatsGroupSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num1 = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        else
          this.Position.X = virtualCamera.Position.X - (float) num1;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Bat" + (object) random.Next(1, 4), (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 10);
        this.LifeTime = random.Next(60, 121) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.1f;
        this.OpacityNormalizedTimeToFadeOut = 0.9f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 4;
        this.FrameOffset = random.Next(0, (int) this.Frame.RowCount);
        int num2 = random.Next((int) this.Frame.RowCount);
        for (int index = 0; index < num2; ++index)
          this.NextFrame();
      }

      public override void UpdateVelocity(int frameCount)
      {
        this._velocityVsMagnet += this._magnetAccelerations * new Vector2((float) Math.Sign(this._magnetPointTarget.X - this._positionVsMagnet.X), (float) Math.Sign(this._magnetPointTarget.Y - this._positionVsMagnet.Y));
        this._positionVsMagnet += this._velocityVsMagnet;
        this.Velocity = new Vector2((float) ((3.0 + (double) Math.Abs(Main.WindForVisuals) * 0.800000011920929) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f) + this._velocityVsMagnet;
      }

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }

      public void SetMagnetization(Vector2 accelerations, Vector2 targetOffset)
      {
        this._magnetAccelerations = accelerations;
        this._magnetPointTarget = targetOffset;
      }

      public override Color GetColor(Color backgroundColor) => base.GetColor(backgroundColor) * Utils.Max<float>(Main.bgAlphaFrontLayer[3], Main.bgAlphaFrontLayer[0], Main.bgAlphaFrontLayer[10], Main.bgAlphaFrontLayer[11], Main.bgAlphaFrontLayer[12]);

      public static List<AmbientSky.BatsGroupSkyEntity> CreateGroup(
        Player player,
        FastRandom random)
      {
        List<AmbientSky.BatsGroupSkyEntity> batsGroupSkyEntityList = new List<AmbientSky.BatsGroupSkyEntity>();
        int num1 = 100;
        int num2 = random.Next(20, 40);
        VirtualCamera virtualCamera = new VirtualCamera(player);
        SpriteEffects spriteEffects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        Vector2 vector2_1 = new Vector2();
        vector2_1.X = spriteEffects != SpriteEffects.FlipHorizontally ? virtualCamera.Position.X - (float) num1 : virtualCamera.Position.X + virtualCamera.Size.X + (float) num1;
        vector2_1.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        float num3 = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        int num4 = random.Next(30, 61) * 60;
        Vector2 vector2_2 = new Vector2((float) ((double) random.NextFloat() * 0.5 + 0.5), (float) ((double) random.NextFloat() * 0.5 + 0.5));
        Vector2 targetOffset = new Vector2((float) ((double) random.NextFloat() * 2.0 - 1.0), (float) ((double) random.NextFloat() * 2.0 - 1.0)) * 100f;
        for (int index = 0; index < num2; ++index)
        {
          AmbientSky.BatsGroupSkyEntity batsGroupSkyEntity = new AmbientSky.BatsGroupSkyEntity(player, random);
          batsGroupSkyEntity.Depth = num3 + random.NextFloat() * 0.5f;
          batsGroupSkyEntity.Position = vector2_1 + new Vector2((float) ((double) random.NextFloat() * 20.0 - 10.0), random.NextFloat() * 3f) * 50f;
          batsGroupSkyEntity.Effects = spriteEffects;
          batsGroupSkyEntity.SetPositionInWorldBasedOnScreenSpace(batsGroupSkyEntity.Position);
          batsGroupSkyEntity.LifeTime = num4 + random.Next(301);
          batsGroupSkyEntity.SetMagnetization(vector2_2 * (float) ((double) random.NextFloat() * 0.300000011920929 + 0.850000023841858) * 0.05f, targetOffset);
          batsGroupSkyEntityList.Add(batsGroupSkyEntity);
        }
        return batsGroupSkyEntityList;
      }
    }

    private class WyvernSkyEntity : AmbientSky.FadingSkyEntity
    {
      public WyvernSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = (double) Main.WindForVisuals > 0.0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Wyvern", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 5);
        this.LifeTime = random.Next(40, 71) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.15f;
        this.OpacityNormalizedTimeToFadeOut = 0.85f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 4;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((3.0 + (double) Math.Abs(Main.WindForVisuals) * 0.800000011920929) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);
    }

    private class NormalizedBackgroundLayerSpaceSkyEntity : AmbientSky.SkyEntity
    {
      public override Color GetColor(Color backgroundColor) => Color.Lerp(backgroundColor, Color.White, 0.3f);

      public override Vector2 GetDrawPosition() => this.Position;

      public override void Update(int frameCount)
      {
      }
    }

    private class BoneSerpentSkyEntity : AmbientSky.NormalizedBackgroundLayerSpaceSkyEntity
    {
    }

    private class AirshipSkyEntity : AmbientSky.FadingSkyEntity
    {
      public AirshipSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = random.Next(2) == 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        int num = 100;
        if (this.Effects == SpriteEffects.FlipHorizontally)
          this.Position.X = virtualCamera.Position.X + virtualCamera.Size.X + (float) num;
        else
          this.Position.X = virtualCamera.Position.X - (float) num;
        this.Position.Y = (float) ((double) random.NextFloat() * (Main.worldSurface * 16.0 - 1600.0 - 2400.0) + 2400.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/FlyingShip", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 4);
        this.LifeTime = random.Next(40, 71) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.05f;
        this.OpacityNormalizedTimeToFadeOut = 0.95f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 4;
      }

      public override void UpdateVelocity(int frameCount) => this.Velocity = new Vector2((float) ((6.0 + (double) Math.Abs(Main.WindForVisuals) * 1.60000002384186) * (this.Effects == SpriteEffects.FlipHorizontally ? -1.0 : 1.0)), 0.0f);

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }
    }

    private class AirBalloonSkyEntity : AmbientSky.FadingSkyEntity
    {
      private const int RANDOM_TILE_SPAWN_RANGE = 100;

      public AirBalloonSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        int x = player.Center.ToTileCoordinates().X;
        this.Effects = random.Next(2) == 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        this.Position.X = (float) (((double) x + 100.0 * ((double) random.NextFloat() * 2.0 - 1.0)) * 16.0);
        this.Position.Y = (float) (Main.worldSurface * 16.0 - (double) random.Next(50, 81) * 16.0);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/AirBalloons_" + (random.Next(2) == 0 ? "Large" : "Small"), (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 5);
        this.Frame.CurrentRow = (byte) random.Next(5);
        this.LifeTime = random.Next(20, 51) * 60;
        this.OpacityNormalizedTimeToFadeIn = 0.05f;
        this.OpacityNormalizedTimeToFadeOut = 0.95f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = int.MaxValue;
      }

      public override void UpdateVelocity(int frameCount)
      {
        float x = Main.WindForVisuals * 4f;
        float num = (float) (3.0 + (double) Math.Abs(Main.WindForVisuals) * 1.0);
        if ((double) this.Position.Y < Main.worldSurface * 12.0)
          num *= 0.5f;
        if ((double) this.Position.Y < Main.worldSurface * 8.0)
          num *= 0.5f;
        if ((double) this.Position.Y < Main.worldSurface * 4.0)
          num *= 0.5f;
        this.Velocity = new Vector2(x, -num);
      }

      public override void Update(int frameCount)
      {
        base.Update(frameCount);
        if (!Main.IsItRaining && Main.dayTime && !Main.eclipse)
          return;
        this.StartFadingOut(frameCount);
      }
    }

    private class CrimeraSkyEntity : AmbientSky.EOCSkyEntity
    {
      public CrimeraSkyEntity(Player player, FastRandom random)
        : base(player, random)
      {
        int num = 3;
        if ((double) this.Depth <= 6.0)
          num = 2;
        if ((double) this.Depth <= 5.0)
          num = 1;
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Crimera" + (object) num, (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 3);
      }

      public override Color GetColor(Color backgroundColor) => base.GetColor(backgroundColor) * Main.bgAlphaFrontLayer[8];
    }

    private class EOSSkyEntity : AmbientSky.EOCSkyEntity
    {
      public EOSSkyEntity(Player player, FastRandom random)
        : base(player, random)
      {
        int num = 3;
        if ((double) this.Depth <= 6.0)
          num = 2;
        if ((double) this.Depth <= 5.0)
          num = 1;
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/EOS" + (object) num, (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 4);
      }

      public override Color GetColor(Color backgroundColor) => base.GetColor(backgroundColor) * Main.bgAlphaFrontLayer[1];
    }

    private class EOCSkyEntity : AmbientSky.FadingSkyEntity
    {
      private const int STATE_ZIGZAG = 1;
      private const int STATE_GOOVERPLAYER = 2;
      private int _state;
      private int _direction;
      private float _waviness;

      public EOCSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera camera = new VirtualCamera(player);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/EOC", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 3);
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 4.5);
        if (random.Next(4) != 0)
          this.BeginZigZag(ref random, camera, random.Next(2) == 1 ? 1 : -1);
        else
          this.BeginChasingPlayer(ref random, camera);
        this.SetPositionInWorldBasedOnScreenSpace(this.Position);
        this.OpacityNormalizedTimeToFadeIn = 0.1f;
        this.OpacityNormalizedTimeToFadeOut = 0.9f;
        this.BrightnessLerper = 0.2f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
      }

      private void BeginZigZag(ref FastRandom random, VirtualCamera camera, int direction)
      {
        this._state = 1;
        this.LifeTime = random.Next(18, 31) * 60;
        this._direction = direction;
        this._waviness = (float) ((double) random.NextFloat() * 1.0 + 1.0);
        this.Position.Y = camera.Position.Y;
        int num = 100;
        if (this._direction == 1)
          this.Position.X = camera.Position.X - (float) num;
        else
          this.Position.X = camera.Position.X + camera.Size.X + (float) num;
      }

      private void BeginChasingPlayer(ref FastRandom random, VirtualCamera camera)
      {
        this._state = 2;
        this.LifeTime = random.Next(18, 31) * 60;
        this.Position = camera.Position + camera.Size * new Vector2(random.NextFloat(), random.NextFloat());
      }

      public override void UpdateVelocity(int frameCount)
      {
        switch (this._state)
        {
          case 1:
            this.ZigzagMove(frameCount);
            break;
          case 2:
            this.ChasePlayerTop(frameCount);
            break;
        }
        this.Rotation = this.Velocity.ToRotation();
      }

      private void ZigzagMove(int frameCount) => this.Velocity = new Vector2((float) (this._direction * 3), (float) Math.Cos((double) frameCount / 1200.0 * 6.28318548202515) * this._waviness);

      private void ChasePlayerTop(int frameCount)
      {
        Vector2 vector2 = Main.LocalPlayer.Center + new Vector2(0.0f, -500f) - this.Position;
        if ((double) vector2.Length() < 100.0)
          return;
        this.Velocity.X += 0.1f * (float) Math.Sign(vector2.X);
        this.Velocity.Y += 0.1f * (float) Math.Sign(vector2.Y);
        this.Velocity = Vector2.Clamp(this.Velocity, new Vector2(-18f), new Vector2(18f));
      }
    }

    private class MeteorSkyEntity : AmbientSky.FadingSkyEntity
    {
      public MeteorSkyEntity(Player player, FastRandom random)
      {
        VirtualCamera virtualCamera = new VirtualCamera(player);
        this.Effects = random.Next(2) == 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        this.Depth = (float) ((double) random.NextFloat() * 3.0 + 3.0);
        this.Texture = Main.Assets.Request<Texture2D>("Images/Backgrounds/Ambience/Meteor", (AssetRequestMode) 1);
        this.Frame = new SpriteFrame((byte) 1, (byte) 4);
        Vector2 rotationVector2 = ((float) (0.785398185253143 + (double) random.NextFloat() * 1.57079637050629)).ToRotationVector2();
        double num1 = (Main.worldSurface * 16.0 - 0.0) / (double) rotationVector2.Y;
        float num2 = 1200f;
        double num3 = (double) num2;
        float num4 = (float) (num1 / num3);
        this.Velocity = rotationVector2 * num4;
        int num5 = 100;
        this.Position = player.Center + new Vector2((float) random.Next(-num5, num5 + 1), (float) random.Next(-num5, num5 + 1)) - this.Velocity * num2 * 0.5f;
        this.LifeTime = (int) num2;
        this.OpacityNormalizedTimeToFadeIn = 0.05f;
        this.OpacityNormalizedTimeToFadeOut = 0.95f;
        this.BrightnessLerper = 0.5f;
        this.FinalOpacityMultiplier = 1f;
        this.FramingSpeed = 5;
        this.Rotation = this.Velocity.ToRotation() + 1.570796f;
      }
    }

    private delegate AmbientSky.SkyEntity EntityFactoryMethod(Player player, int seed);
  }
}
