// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.CreditsRoll.Actions
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.Skies.CreditsRoll
{
  public class Actions
  {
    public class NPCs
    {
      public interface INPCAction : ICreditsRollSegmentAction<NPC>
      {
      }

      public class Fade : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private int _alphaPerFrame;
        private float _delay;

        public Fade(int alphaPerFrame)
        {
          this._duration = 0;
          this._alphaPerFrame = alphaPerFrame;
        }

        public Fade(int alphaPerFrame, int duration)
        {
          this._duration = duration;
          this._alphaPerFrame = alphaPerFrame;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          if (this._duration == 0)
          {
            obj.alpha = Utils.Clamp<int>(obj.alpha + this._alphaPerFrame, 0, (int) byte.MaxValue);
          }
          else
          {
            float num = localTimeForObj - this._delay;
            if ((double) num > (double) this._duration)
              num = (float) this._duration;
            obj.alpha = Utils.Clamp<int>(obj.alpha + (int) num * this._alphaPerFrame, 0, (int) byte.MaxValue);
          }
        }
      }

      public class Move : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private Vector2 _offsetPerFrame;
        private int _duration;
        private float _delay;

        public Move(Vector2 offsetPerFrame, int durationInFrames)
        {
          this._offsetPerFrame = offsetPerFrame;
          this._duration = durationInFrames;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          NPC npc = obj;
          npc.position = npc.position + this._offsetPerFrame * num;
          obj.velocity = this._offsetPerFrame;
          if ((double) this._offsetPerFrame.X == 0.0)
            return;
          obj.direction = obj.spriteDirection = (double) this._offsetPerFrame.X > 0.0 ? 1 : -1;
        }
      }

      public class Wait : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private float _delay;

        public Wait(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.velocity = Vector2.Zero;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class LookAt : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _direction;
        private float _delay;

        public LookAt(int direction) => this._direction = direction;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.direction = obj.spriteDirection = this._direction;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class PartyHard : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        public void BindTo(NPC obj)
        {
          obj.ForcePartyHatOn = true;
          obj.UpdateAltTexture();
        }

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
        }

        public void SetDelay(float delay)
        {
        }
      }
    }

    public class Sprites
    {
      public interface ISpriteAction : ICreditsRollSegmentAction<Segments.LooseSprite>
      {
      }

      public class Fade : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private int _duration;
        private float _opacityTarget;
        private float _delay;

        public Fade(float opacityTarget)
        {
          this._duration = 0;
          this._opacityTarget = opacityTarget;
        }

        public Fade(float opacityTarget, int duration)
        {
          this._duration = duration;
          this._opacityTarget = opacityTarget;
        }

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          if (this._duration == 0)
          {
            obj.CurrentOpacity = this._opacityTarget;
          }
          else
          {
            float t = localTimeForObj - this._delay;
            if ((double) t > (double) this._duration)
              t = (float) this._duration;
            obj.CurrentOpacity = MathHelper.Lerp(obj.CurrentOpacity, this._opacityTarget, Utils.GetLerpValue(0.0f, (float) this._duration, t, true));
          }
        }
      }

      public class Wait : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private int _duration;
        private float _delay;

        public Wait(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          double delay = (double) this._delay;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }
    }
  }
}
