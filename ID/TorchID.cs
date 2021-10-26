// Decompiled with JetBrains decompiler
// Type: Terraria.ID.TorchID
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Runtime.InteropServices;

namespace Terraria.ID
{
  public static class TorchID
  {
    public static int[] Dust = new int[22]
    {
      6,
      59,
      60,
      61,
      62,
      63,
      64,
      65,
      75,
      135,
      158,
      169,
      156,
      234,
      66,
      242,
      293,
      294,
      295,
      296,
      297,
      298
    };
    private static TorchID.ITorchLightProvider[] _lights;
    public const short Torch = 0;
    public const short Blue = 1;
    public const short Red = 2;
    public const short Green = 3;
    public const short Purple = 4;
    public const short White = 5;
    public const short Yellow = 6;
    public const short Demon = 7;
    public const short Cursed = 8;
    public const short Ice = 9;
    public const short Orange = 10;
    public const short Ichor = 11;
    public const short UltraBright = 12;
    public const short Bone = 13;
    public const short Rainbow = 14;
    public const short Pink = 15;
    public const short Desert = 16;
    public const short Coral = 17;
    public const short Corrupt = 18;
    public const short Crimson = 19;
    public const short Hallowed = 20;
    public const short Jungle = 21;
    public const short Count = 22;

    public static void Initialize() => TorchID._lights = new TorchID.ITorchLightProvider[22]
    {
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1f, 0.95f, 0.8f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.0f, 0.1f, 1.3f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1f, 0.1f, 0.1f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.0f, 1f, 0.1f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.9f, 0.0f, 0.9f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1.4f, 1.4f, 1.4f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.9f, 0.9f, 0.0f),
      (TorchID.ITorchLightProvider) new TorchID.DemonTorchLight(),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1f, 1.6f, 0.5f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.75f, 0.85f, 1.4f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1f, 0.5f, 0.0f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1.4f, 1.4f, 0.7f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.75f, 1.35f, 1.5f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.95f, 0.75f, 1.3f),
      (TorchID.ITorchLightProvider) new TorchID.DiscoTorchLight(),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1f, 0.0f, 1f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1.4f, 0.85f, 0.55f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.25f, 1.3f, 0.8f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.95f, 0.4f, 1.4f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1.4f, 0.7f, 0.5f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(1.25f, 0.6f, 1.2f),
      (TorchID.ITorchLightProvider) new TorchID.ConstantTorchLight(0.75f, 1.45f, 0.9f)
    };

    public static void TorchColor(int torchID, out float R, out float G, out float B) => TorchID._lights[torchID].GetRGB(out R, out G, out B);

    private interface ITorchLightProvider
    {
      void GetRGB(out float r, out float g, out float b);
    }

    private struct ConstantTorchLight : TorchID.ITorchLightProvider
    {
      public float R;
      public float G;
      public float B;

      public ConstantTorchLight(float Red, float Green, float Blue)
      {
        this.R = Red;
        this.G = Green;
        this.B = Blue;
      }

      public void GetRGB(out float r, out float g, out float b)
      {
        r = this.R;
        g = this.G;
        b = this.B;
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    private struct DemonTorchLight : TorchID.ITorchLightProvider
    {
      public void GetRGB(out float r, out float g, out float b)
      {
        r = (float) (0.5 * (double) Main.demonTorch + (1.0 - (double) Main.demonTorch));
        g = 0.3f;
        b = Main.demonTorch + (float) (0.5 * (1.0 - (double) Main.demonTorch));
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    private struct DiscoTorchLight : TorchID.ITorchLightProvider
    {
      public void GetRGB(out float r, out float g, out float b)
      {
        r = (float) Main.DiscoR / (float) byte.MaxValue;
        g = (float) Main.DiscoG / (float) byte.MaxValue;
        b = (float) Main.DiscoB / (float) byte.MaxValue;
      }
    }
  }
}
