// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.EyeballShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;
using Terraria.Utilities;

namespace Terraria.GameContent.RGB
{
  public class EyeballShader : ChromaShader
  {
    private static readonly EyeballShader.Ring[] Rings = new EyeballShader.Ring[5]
    {
      new EyeballShader.Ring(Color.Black.ToVector4(), 0.0f),
      new EyeballShader.Ring(Color.Black.ToVector4(), 0.4f),
      new EyeballShader.Ring(new Color(17, 220, 237).ToVector4(), 0.5f),
      new EyeballShader.Ring(new Color(17, 120, 237).ToVector4(), 0.6f),
      new EyeballShader.Ring(Vector4.One, 0.65f)
    };
    private readonly Vector4 _eyelidColor = new Color(108, 110, 75).ToVector4();
    private float _eyelidProgress;
    private Vector2 _pupilOffset = Vector2.Zero;
    private Vector2 _targetOffset = Vector2.Zero;
    private readonly UnifiedRandom _random = new UnifiedRandom();
    private float _timeUntilPupilMove;
    private float _eyelidStateTime;
    private readonly bool _isSpawning;
    private EyeballShader.EyelidState _eyelidState;

    public EyeballShader(bool isSpawning) => this._isSpawning = isSpawning;

    public virtual void Update(float elapsedTime)
    {
      this.UpdateEyelid(elapsedTime);
      int num1 = (double) this._timeUntilPupilMove <= 0.0 ? 1 : 0;
      this._pupilOffset = (this._targetOffset + this._pupilOffset) * 0.5f;
      this._timeUntilPupilMove -= elapsedTime;
      if (num1 == 0)
        return;
      float num2 = (float) this._random.NextDouble() * 6.283185f;
      float num3;
      if (this._isSpawning)
      {
        this._timeUntilPupilMove = (float) (this._random.NextDouble() * 0.400000005960464 + 0.300000011920929);
        num3 = (float) this._random.NextDouble() * 0.7f;
      }
      else
      {
        this._timeUntilPupilMove = (float) (this._random.NextDouble() * 0.400000005960464 + 0.600000023841858);
        num3 = (float) this._random.NextDouble() * 0.3f;
      }
      this._targetOffset = new Vector2((float) Math.Cos((double) num2), (float) Math.Sin((double) num2)) * num3;
    }

    private void UpdateEyelid(float elapsedTime)
    {
      float num1 = 0.5f;
      float num2 = 6f;
      if (this._isSpawning)
      {
        if (NPC.MoonLordCountdown >= 3590)
        {
          this._eyelidStateTime = 0.0f;
          this._eyelidState = EyeballShader.EyelidState.Closed;
        }
        num1 = (float) ((double) NPC.MoonLordCountdown / 3600.0 * 10.0 + 0.5);
        num2 = 2f;
      }
      this._eyelidStateTime += elapsedTime;
      switch (this._eyelidState)
      {
        case EyeballShader.EyelidState.Closed:
          this._eyelidProgress = 0.0f;
          if ((double) this._eyelidStateTime <= (double) num1)
            break;
          this._eyelidStateTime = 0.0f;
          this._eyelidState = EyeballShader.EyelidState.Opening;
          break;
        case EyeballShader.EyelidState.Opening:
          this._eyelidProgress = this._eyelidStateTime / 0.4f;
          if ((double) this._eyelidStateTime <= 0.400000005960464)
            break;
          this._eyelidStateTime = 0.0f;
          this._eyelidState = EyeballShader.EyelidState.Open;
          break;
        case EyeballShader.EyelidState.Open:
          this._eyelidProgress = 1f;
          if ((double) this._eyelidStateTime <= (double) num2)
            break;
          this._eyelidStateTime = 0.0f;
          this._eyelidState = EyeballShader.EyelidState.Closing;
          break;
        case EyeballShader.EyelidState.Closing:
          this._eyelidProgress = (float) (1.0 - (double) this._eyelidStateTime / 0.400000005960464);
          if ((double) this._eyelidStateTime <= 0.400000005960464)
            break;
          this._eyelidStateTime = 0.0f;
          this._eyelidState = EyeballShader.EyelidState.Closed;
          break;
      }
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector2 vector2_1 = new Vector2(1.5f, 0.5f);
      Vector2 vector2_2 = vector2_1 + this._pupilOffset;
      for (int index1 = 0; index1 < fragment.Count; ++index1)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index1);
        Vector2 vector2_3 = canvasPositionOfIndex - vector2_1;
        Vector4 vector4 = Vector4.One;
        float num1 = (vector2_2 - canvasPositionOfIndex).Length();
        for (int index2 = 1; index2 < EyeballShader.Rings.Length; ++index2)
        {
          EyeballShader.Ring ring1 = EyeballShader.Rings[index2];
          EyeballShader.Ring ring2 = EyeballShader.Rings[index2 - 1];
          if ((double) num1 < (double) ring1.Distance)
          {
            vector4 = Vector4.Lerp(ring2.Color, ring1.Color, (float) (((double) num1 - (double) ring2.Distance) / ((double) ring1.Distance - (double) ring2.Distance)));
            break;
          }
        }
        float num2 = (float) Math.Sqrt(1.0 - 0.400000005960464 * (double) vector2_3.Y * (double) vector2_3.Y) * 5f;
        float num3 = Math.Abs(vector2_3.X) - num2 * (float) (1.10000002384186 * (double) this._eyelidProgress - 0.100000001490116);
        if ((double) num3 > 0.0)
          vector4 = Vector4.Lerp(vector4, this._eyelidColor, Math.Min(1f, num3 * 10f));
        fragment.SetColor(index1, vector4);
      }
    }

    private struct Ring
    {
      public readonly Vector4 Color;
      public readonly float Distance;

      public Ring(Vector4 color, float distance)
      {
        this.Color = color;
        this.Distance = distance;
      }
    }

    private enum EyelidState
    {
      Closed,
      Opening,
      Open,
      Closing,
    }
  }
}
