// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.PlayerDataInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;

namespace Terraria.Initializers
{
  public static class PlayerDataInitializer
  {
    public static void Load()
    {
      TextureAssets.Players = new Asset<Texture2D>[12, 16];
      PlayerDataInitializer.LoadStarterMale();
      PlayerDataInitializer.LoadStarterFemale();
      PlayerDataInitializer.LoadStickerMale();
      PlayerDataInitializer.LoadStickerFemale();
      PlayerDataInitializer.LoadGangsterMale();
      PlayerDataInitializer.LoadGangsterFemale();
      PlayerDataInitializer.LoadCoatMale();
      PlayerDataInitializer.LoadDressFemale();
      PlayerDataInitializer.LoadDressMale();
      PlayerDataInitializer.LoadCoatFemale();
      PlayerDataInitializer.LoadDisplayDollMale();
      PlayerDataInitializer.LoadDisplayDollFemale();
    }

    private static void LoadVariant(int ID, int[] pieceIDs)
    {
      for (int index = 0; index < pieceIDs.Length; ++index)
        TextureAssets.Players[ID, pieceIDs[index]] = Main.Assets.Request<Texture2D>("Images/Player_" + (object) ID + "_" + (object) pieceIDs[index], (AssetRequestMode) 2);
    }

    private static void CopyVariant(int to, int from)
    {
      for (int index = 0; index < 16; ++index)
        TextureAssets.Players[to, index] = TextureAssets.Players[from, index];
    }

    private static void LoadStarterMale()
    {
      PlayerDataInitializer.LoadVariant(0, new int[15]
      {
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        15
      });
      TextureAssets.Players[0, 14] = (Asset<Texture2D>) Asset<Texture2D>.Empty;
    }

    private static void LoadStickerMale()
    {
      PlayerDataInitializer.CopyVariant(1, 0);
      PlayerDataInitializer.LoadVariant(1, new int[6]
      {
        4,
        6,
        8,
        11,
        12,
        13
      });
    }

    private static void LoadGangsterMale()
    {
      PlayerDataInitializer.CopyVariant(2, 0);
      PlayerDataInitializer.LoadVariant(2, new int[6]
      {
        4,
        6,
        8,
        11,
        12,
        13
      });
    }

    private static void LoadCoatMale()
    {
      PlayerDataInitializer.CopyVariant(3, 0);
      PlayerDataInitializer.LoadVariant(3, new int[7]
      {
        4,
        6,
        8,
        11,
        12,
        13,
        14
      });
    }

    private static void LoadDressMale()
    {
      PlayerDataInitializer.CopyVariant(8, 0);
      PlayerDataInitializer.LoadVariant(8, new int[7]
      {
        4,
        6,
        8,
        11,
        12,
        13,
        14
      });
    }

    private static void LoadStarterFemale()
    {
      PlayerDataInitializer.CopyVariant(4, 0);
      PlayerDataInitializer.LoadVariant(4, new int[11]
      {
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13
      });
    }

    private static void LoadStickerFemale()
    {
      PlayerDataInitializer.CopyVariant(5, 4);
      PlayerDataInitializer.LoadVariant(5, new int[6]
      {
        4,
        6,
        8,
        11,
        12,
        13
      });
    }

    private static void LoadGangsterFemale()
    {
      PlayerDataInitializer.CopyVariant(6, 4);
      PlayerDataInitializer.LoadVariant(6, new int[6]
      {
        4,
        6,
        8,
        11,
        12,
        13
      });
    }

    private static void LoadCoatFemale()
    {
      PlayerDataInitializer.CopyVariant(7, 4);
      PlayerDataInitializer.LoadVariant(7, new int[7]
      {
        4,
        6,
        8,
        11,
        12,
        13,
        14
      });
    }

    private static void LoadDressFemale()
    {
      PlayerDataInitializer.CopyVariant(9, 4);
      PlayerDataInitializer.LoadVariant(9, new int[6]
      {
        4,
        6,
        8,
        11,
        12,
        13
      });
    }

    private static void LoadDisplayDollMale()
    {
      PlayerDataInitializer.CopyVariant(10, 0);
      PlayerDataInitializer.LoadVariant(10, new int[7]
      {
        0,
        2,
        3,
        5,
        7,
        9,
        10
      });
      Asset<Texture2D> player = TextureAssets.Players[10, 2];
      TextureAssets.Players[10, 2] = player;
      TextureAssets.Players[10, 1] = player;
      TextureAssets.Players[10, 4] = player;
      TextureAssets.Players[10, 6] = player;
      TextureAssets.Players[10, 11] = player;
      TextureAssets.Players[10, 12] = player;
      TextureAssets.Players[10, 13] = player;
      TextureAssets.Players[10, 8] = player;
      TextureAssets.Players[10, 15] = player;
    }

    private static void LoadDisplayDollFemale()
    {
      PlayerDataInitializer.CopyVariant(11, 10);
      PlayerDataInitializer.LoadVariant(11, new int[5]
      {
        3,
        5,
        7,
        9,
        10
      });
      Asset<Texture2D> player = TextureAssets.Players[10, 2];
      TextureAssets.Players[11, 2] = player;
      TextureAssets.Players[11, 1] = player;
      TextureAssets.Players[11, 4] = player;
      TextureAssets.Players[11, 6] = player;
      TextureAssets.Players[11, 11] = player;
      TextureAssets.Players[11, 12] = player;
      TextureAssets.Players[11, 13] = player;
      TextureAssets.Players[11, 8] = player;
      TextureAssets.Players[11, 15] = player;
    }
  }
}
