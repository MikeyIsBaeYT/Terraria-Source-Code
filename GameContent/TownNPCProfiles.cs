// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.TownNPCProfiles
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent
{
  public class TownNPCProfiles
  {
    private const string DefaultNPCFileFolderPath = "Images/TownNPCs/";
    private static readonly int[] CatHeadIDs = new int[6]
    {
      27,
      28,
      29,
      30,
      31,
      32
    };
    private static readonly int[] DogHeadIDs = new int[6]
    {
      33,
      34,
      35,
      36,
      37,
      38
    };
    private static readonly int[] BunnyHeadIDs = new int[6]
    {
      39,
      40,
      41,
      42,
      43,
      44
    };
    private Dictionary<int, ITownNPCProfile> _townNPCProfiles = new Dictionary<int, ITownNPCProfile>()
    {
      {
        369,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Angler", 22)
      },
      {
        633,
        (ITownNPCProfile) new Profiles.TransformableNPCProfile("Images/TownNPCs/BestiaryGirl", 26)
      },
      {
        54,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Clothier", 7)
      },
      {
        209,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Cyborg", 16)
      },
      {
        38,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Demolitionist", 4)
      },
      {
        207,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/DyeTrader", 14)
      },
      {
        588,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Golfer", 25)
      },
      {
        124,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Mechanic", 8)
      },
      {
        17,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Merchant", 2)
      },
      {
        18,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Nurse", 3)
      },
      {
        227,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Painter", 17)
      },
      {
        229,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Pirate", 19)
      },
      {
        142,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Santa", 11)
      },
      {
        453,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/SkeletonMerchant", -1)
      },
      {
        178,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Steampunker", 13)
      },
      {
        353,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Stylist", 20)
      },
      {
        441,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/TaxCollector", 23)
      },
      {
        368,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/TravelingMerchant", 21)
      },
      {
        108,
        (ITownNPCProfile) new Profiles.LegacyNPCProfile("Images/TownNPCs/Wizard", 10)
      },
      {
        637,
        (ITownNPCProfile) new Profiles.VariantNPCProfile("Images/TownNPCs/Cat", "Cat", TownNPCProfiles.CatHeadIDs, new string[6]
        {
          "Siamese",
          "Black",
          "OrangeTabby",
          "RussianBlue",
          "Silver",
          "White"
        })
      },
      {
        638,
        (ITownNPCProfile) new Profiles.VariantNPCProfile("Images/TownNPCs/Dog", "Dog", TownNPCProfiles.DogHeadIDs, new string[6]
        {
          "Labrador",
          "PitBull",
          "Beagle",
          "Corgi",
          "Dalmation",
          "Husky"
        })
      },
      {
        656,
        (ITownNPCProfile) new Profiles.VariantNPCProfile("Images/TownNPCs/Bunny", "Bunny", TownNPCProfiles.BunnyHeadIDs, new string[6]
        {
          "White",
          "Angora",
          "Dutch",
          "Flemish",
          "Lop",
          "Silver"
        })
      }
    };
    public static TownNPCProfiles Instance = new TownNPCProfiles();

    public bool GetProfile(int npcId, out ITownNPCProfile profile) => this._townNPCProfiles.TryGetValue(npcId, out profile);
  }
}
