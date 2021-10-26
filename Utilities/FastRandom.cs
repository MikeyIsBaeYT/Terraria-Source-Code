// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.FastRandom
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System;

namespace Terraria.Utilities
{
  public struct FastRandom
  {
    private const ulong RANDOM_MULTIPLIER = 25214903917;
    private const ulong RANDOM_ADD = 11;
    private const ulong RANDOM_MASK = 281474976710655;

    public ulong Seed { get; private set; }

    public FastRandom(ulong seed)
      : this()
    {
      this.Seed = seed;
    }

    public FastRandom(int seed)
      : this()
    {
      this.Seed = (ulong) seed;
    }

    public FastRandom WithModifier(ulong modifier) => new FastRandom(FastRandom.NextSeed(modifier) ^ this.Seed);

    public FastRandom WithModifier(int x, int y) => this.WithModifier((ulong) ((long) x + 2654435769L + ((long) y << 6)) + ((ulong) y >> 2));

    public static FastRandom CreateWithRandomSeed() => new FastRandom((ulong) Guid.NewGuid().GetHashCode());

    public void NextSeed() => this.Seed = FastRandom.NextSeed(this.Seed);

    private int NextBits(int bits)
    {
      this.Seed = FastRandom.NextSeed(this.Seed);
      return (int) (this.Seed >> 48 - bits);
    }

    public float NextFloat() => (float) this.NextBits(24) * 5.960464E-08f;

    public double NextDouble() => (double) this.NextBits(32) * 4.65661287307739E-10;

    public int Next(int max)
    {
      if ((max & -max) == max)
        return (int) ((long) max * (long) this.NextBits(31) >> 31);
      int num1;
      int num2;
      do
      {
        num1 = this.NextBits(31);
        num2 = num1 % max;
      }
      while (num1 - num2 + (max - 1) < 0);
      return num2;
    }

    public int Next(int min, int max) => this.Next(max - min) + min;

    private static ulong NextSeed(ulong seed) => (ulong) ((long) seed * 25214903917L + 11L & 281474976710655L);
  }
}
