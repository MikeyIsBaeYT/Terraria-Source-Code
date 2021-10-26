// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.NoiseHelper
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.Utilities;

namespace Terraria.GameContent.RGB
{
  public static class NoiseHelper
  {
    private const int RANDOM_SEED = 1;
    private const int NOISE_2D_SIZE = 32;
    private const int NOISE_2D_SIZE_MASK = 31;
    private const int NOISE_SIZE_MASK = 1023;
    private static readonly float[] StaticNoise = NoiseHelper.CreateStaticNoise(1024);

    private static float[] CreateStaticNoise(int length)
    {
      UnifiedRandom r = new UnifiedRandom(1);
      float[] numArray = new float[length];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = r.NextFloat();
      return numArray;
    }

    public static float GetDynamicNoise(int index, float currentTime) => Math.Abs(Math.Abs(NoiseHelper.StaticNoise[index & 1023] - currentTime % 1f) - 0.5f) * 2f;

    public static float GetStaticNoise(int index) => NoiseHelper.StaticNoise[index & 1023];

    public static float GetDynamicNoise(int x, int y, float currentTime) => NoiseHelper.GetDynamicNoiseInternal(x, y, currentTime % 1f);

    private static float GetDynamicNoiseInternal(int x, int y, float wrappedTime)
    {
      x &= 31;
      y &= 31;
      return Math.Abs(Math.Abs(NoiseHelper.StaticNoise[y * 32 + x] - wrappedTime) - 0.5f) * 2f;
    }

    public static float GetStaticNoise(int x, int y)
    {
      x &= 31;
      y &= 31;
      return NoiseHelper.StaticNoise[y * 32 + x];
    }

    public static float GetDynamicNoise(Vector2 position, float currentTime)
    {
      position *= 10f;
      currentTime %= 1f;
      Vector2 vector2_1 = new Vector2((float) Math.Floor((double) position.X), (float) Math.Floor((double) position.Y));
      Point point = new Point((int) vector2_1.X, (int) vector2_1.Y);
      Vector2 vector2_2 = new Vector2(position.X - vector2_1.X, position.Y - vector2_1.Y);
      return MathHelper.Lerp(MathHelper.Lerp(NoiseHelper.GetDynamicNoiseInternal(point.X, point.Y, currentTime), NoiseHelper.GetDynamicNoiseInternal(point.X, point.Y + 1, currentTime), vector2_2.Y), MathHelper.Lerp(NoiseHelper.GetDynamicNoiseInternal(point.X + 1, point.Y, currentTime), NoiseHelper.GetDynamicNoiseInternal(point.X + 1, point.Y + 1, currentTime), vector2_2.Y), vector2_2.X);
    }

    public static float GetStaticNoise(Vector2 position)
    {
      position *= 10f;
      Vector2 vector2_1 = new Vector2((float) Math.Floor((double) position.X), (float) Math.Floor((double) position.Y));
      Point point = new Point((int) vector2_1.X, (int) vector2_1.Y);
      Vector2 vector2_2 = new Vector2(position.X - vector2_1.X, position.Y - vector2_1.Y);
      return MathHelper.Lerp(MathHelper.Lerp(NoiseHelper.GetStaticNoise(point.X, point.Y), NoiseHelper.GetStaticNoise(point.X, point.Y + 1), vector2_2.Y), MathHelper.Lerp(NoiseHelper.GetStaticNoise(point.X + 1, point.Y), NoiseHelper.GetStaticNoise(point.X + 1, point.Y + 1), vector2_2.Y), vector2_2.X);
    }
  }
}
