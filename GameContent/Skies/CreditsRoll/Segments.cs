// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.CreditsRoll.Segments
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.Skies.CreditsRoll
{
  public class Segments
  {
    private const float PixelsToRollUpPerFrame = 0.5f;

    public class LocalizedTextSegment : ICreditsRollSegment
    {
      private const int PixelsForALine = 120;
      private LocalizedText _text;
      private float _timeToShowPeak;

      public float DedicatedTimeNeeded => 240f;

      public LocalizedTextSegment(float timeInAnimation, string textKey)
      {
        this._text = Language.GetText(textKey);
        this._timeToShowPeak = timeInAnimation;
      }

      public void Draw(ref CreditsRollInfo info)
      {
        float num1 = 400f;
        float num2 = 400f;
        int timeInAnimation = info.TimeInAnimation;
        float num3 = Utils.GetLerpValue(this._timeToShowPeak - num1, this._timeToShowPeak, (float) timeInAnimation, true) * Utils.GetLerpValue(this._timeToShowPeak + num2, this._timeToShowPeak, (float) timeInAnimation, true);
        if ((double) num3 <= 0.0)
          return;
        float num4 = this._timeToShowPeak - (float) timeInAnimation;
        Vector2 position = info.AnchorPositionOnScreen + new Vector2(0.0f, num4 * 0.5f);
        float Hue = (float) ((double) this._timeToShowPeak / 100.0 % 1.0);
        if ((double) Hue < 0.0)
          ++Hue;
        Color rgb = Main.hslToRgb(Hue, 1f, 0.5f);
        string text = this._text.Value;
        Vector2 origin = FontAssets.DeathText.Value.MeasureString(text) * 0.5f;
        float num5 = (float) (1.0 - (1.0 - (double) num3) * (1.0 - (double) num3));
        ChatManager.DrawColorCodedStringShadow(info.SpriteBatch, FontAssets.DeathText.Value, text, position, rgb * num5 * num5 * 0.25f, 0.0f, origin, Vector2.One);
        ChatManager.DrawColorCodedString(info.SpriteBatch, FontAssets.DeathText.Value, text, position, Color.White * num5, 0.0f, origin, Vector2.One);
      }
    }

    public abstract class ACreditsRollSegmentWithActions<T> : ICreditsRollSegment
    {
      private int _dedicatedTimeNeeded;
      private int _lastDedicatedTimeNeeded;
      protected int _targetTime;
      private List<ICreditsRollSegmentAction<T>> _actions = new List<ICreditsRollSegmentAction<T>>();

      public float DedicatedTimeNeeded => (float) this._dedicatedTimeNeeded;

      public ACreditsRollSegmentWithActions(int targetTime)
      {
        this._targetTime = targetTime;
        this._dedicatedTimeNeeded = 0;
      }

      protected void ProcessActions(T obj, float localTimeForObject)
      {
        for (int index = 0; index < this._actions.Count; ++index)
          this._actions[index].ApplyTo(obj, localTimeForObject);
      }

      public Segments.ACreditsRollSegmentWithActions<T> Then(
        ICreditsRollSegmentAction<T> act)
      {
        this.Bind(act);
        act.SetDelay((float) this._dedicatedTimeNeeded);
        this._actions.Add(act);
        this._lastDedicatedTimeNeeded = this._dedicatedTimeNeeded;
        this._dedicatedTimeNeeded += act.ExpectedLengthOfActionInFrames;
        return this;
      }

      public Segments.ACreditsRollSegmentWithActions<T> With(
        ICreditsRollSegmentAction<T> act)
      {
        this.Bind(act);
        act.SetDelay((float) this._lastDedicatedTimeNeeded);
        this._actions.Add(act);
        return this;
      }

      protected abstract void Bind(ICreditsRollSegmentAction<T> act);

      public abstract void Draw(ref CreditsRollInfo info);
    }

    public class NPCSegment : Segments.ACreditsRollSegmentWithActions<NPC>
    {
      private NPC _npc;
      private Vector2 _anchorOffset;
      private Vector2 _normalizedOriginForHitbox;

      public NPCSegment(
        int targetTime,
        int npcId,
        Vector2 anchorOffset,
        Vector2 normalizedNPCHitboxOrigin)
        : base(targetTime)
      {
        this._npc = new NPC();
        this._npc.SetDefaults(npcId);
        this._npc.IsABestiaryIconDummy = true;
        this._anchorOffset = anchorOffset;
        this._normalizedOriginForHitbox = normalizedNPCHitboxOrigin;
      }

      protected override void Bind(ICreditsRollSegmentAction<NPC> act) => act.BindTo(this._npc);

      public override void Draw(ref CreditsRollInfo info)
      {
        if ((double) info.TimeInAnimation > (double) this._targetTime + (double) this.DedicatedTimeNeeded)
          return;
        this.ResetNPCAnimation(ref info);
        this.ProcessActions(this._npc, (float) (info.TimeInAnimation - this._targetTime));
        if (this._npc.alpha >= (int) byte.MaxValue)
          return;
        this._npc.FindFrame();
        Main.instance.DrawNPCDirect(info.SpriteBatch, this._npc, this._npc.behindTiles, Vector2.Zero);
      }

      private void ResetNPCAnimation(ref CreditsRollInfo info)
      {
        this._npc.position = info.AnchorPositionOnScreen + this._anchorOffset - this._npc.Size * this._normalizedOriginForHitbox;
        this._npc.alpha = 0;
        this._npc.velocity = Vector2.Zero;
      }
    }

    public class LooseSprite
    {
      private DrawData _originalDrawData;
      public DrawData CurrentDrawData;
      public float CurrentOpacity;

      public LooseSprite(DrawData data)
      {
        this._originalDrawData = data;
        this.Reset();
      }

      public void Reset()
      {
        this.CurrentDrawData = this._originalDrawData;
        this.CurrentOpacity = 1f;
      }
    }

    public class SpriteSegment : Segments.ACreditsRollSegmentWithActions<Segments.LooseSprite>
    {
      private Segments.LooseSprite _sprite;
      private Vector2 _anchorOffset;

      public SpriteSegment(int targetTime, DrawData data, Vector2 anchorOffset)
        : base(targetTime)
      {
        this._sprite = new Segments.LooseSprite(data);
        this._anchorOffset = anchorOffset;
      }

      protected override void Bind(
        ICreditsRollSegmentAction<Segments.LooseSprite> act)
      {
        act.BindTo(this._sprite);
      }

      public override void Draw(ref CreditsRollInfo info)
      {
        if ((double) info.TimeInAnimation > (double) this._targetTime + (double) this.DedicatedTimeNeeded)
          return;
        this.ResetSpriteAnimation(ref info);
        this.ProcessActions(this._sprite, (float) (info.TimeInAnimation - this._targetTime));
        DrawData currentDrawData = this._sprite.CurrentDrawData;
        currentDrawData.position += info.AnchorPositionOnScreen;
        currentDrawData.color *= this._sprite.CurrentOpacity;
        currentDrawData.Draw(info.SpriteBatch);
      }

      private void ResetSpriteAnimation(ref CreditsRollInfo info) => this._sprite.Reset();
    }

    public class EmoteSegment : ICreditsRollSegment
    {
      private int _targetTime;
      private Vector2 _offset;
      private SpriteEffects _effect;
      private int _emoteId;

      public float DedicatedTimeNeeded { get; private set; }

      public EmoteSegment(
        int emoteId,
        int targetTime,
        int timeToPlay,
        Vector2 position,
        SpriteEffects drawEffect)
      {
        this._emoteId = emoteId;
        this._targetTime = targetTime;
        this._effect = drawEffect;
        this._offset = position;
        this.DedicatedTimeNeeded = (float) timeToPlay;
      }

      public void Draw(ref CreditsRollInfo info)
      {
        int num = info.TimeInAnimation - this._targetTime;
        if (num < 0 || (double) num >= (double) this.DedicatedTimeNeeded)
          return;
        Vector2 position = (info.AnchorPositionOnScreen + this._offset).Floor();
        bool flag = num < 6 || (double) num >= (double) this.DedicatedTimeNeeded - 6.0;
        Texture2D texture2D = TextureAssets.Extra[48].Value;
        Rectangle rectangle = texture2D.Frame(8, 38, flag ? 0 : 1);
        Vector2 origin = new Vector2((float) (rectangle.Width / 2), (float) rectangle.Height);
        SpriteEffects effect = this._effect;
        info.SpriteBatch.Draw(texture2D, position, new Rectangle?(rectangle), Color.White, 0.0f, origin, 1f, effect, 0.0f);
        if (flag)
          return;
        switch (this._emoteId)
        {
          case 87:
          case 89:
            if (effect.HasFlag((Enum) SpriteEffects.FlipHorizontally))
            {
              effect &= ~SpriteEffects.FlipHorizontally;
              position.X += 4f;
              break;
            }
            break;
        }
        info.SpriteBatch.Draw(texture2D, position, new Rectangle?(this.GetFrame(num % 20)), Color.White, 0.0f, origin, 1f, effect, 0.0f);
      }

      private Rectangle GetFrame(int wrappedTime)
      {
        int num = wrappedTime >= 10 ? 1 : 0;
        return TextureAssets.Extra[48].Value.Frame(8, 38, this._emoteId % 4 * 2 + num, this._emoteId / 4 + 1);
      }
    }
  }
}
