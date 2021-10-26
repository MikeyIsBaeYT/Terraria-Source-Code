// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.WingStatsInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.Initializers
{
  public class WingStatsInitializer
  {
    public static void Load()
    {
      WingStats[] wingStatsArray = new WingStats[47];
      float flySpeedOverride1 = 3f;
      float flySpeedOverride2 = 6f;
      float flySpeedOverride3 = 6.25f;
      float flySpeedOverride4 = 6.5f;
      float flySpeedOverride5 = 6.75f;
      float flySpeedOverride6 = 7f;
      float flySpeedOverride7 = 7.5f;
      float flySpeedOverride8 = 8f;
      float flySpeedOverride9 = 9f;
      int flyTime1 = 25;
      int flyTime2 = 100;
      int flyTime3 = 130;
      int flyTime4 = 150;
      int flyTime5 = 160;
      int flyTime6 = 170;
      int flyTime7 = 180;
      int flyTime8 = 150;
      wingStatsArray[46] = new WingStats(flyTime1, flySpeedOverride1);
      wingStatsArray[1] = new WingStats(flyTime2, flySpeedOverride3);
      wingStatsArray[2] = new WingStats(flyTime2, flySpeedOverride3);
      wingStatsArray[13] = new WingStats(flyTime2, flySpeedOverride3);
      wingStatsArray[25] = new WingStats(flyTime3, flySpeedOverride5);
      wingStatsArray[7] = new WingStats(flyTime3, flySpeedOverride5);
      wingStatsArray[6] = new WingStats(flyTime3, flySpeedOverride5);
      wingStatsArray[10] = new WingStats(flyTime3, flySpeedOverride5);
      wingStatsArray[4] = new WingStats(flyTime4, flySpeedOverride4);
      wingStatsArray[15] = new WingStats(flyTime5, flySpeedOverride7);
      wingStatsArray[5] = new WingStats(flyTime5, flySpeedOverride7);
      wingStatsArray[14] = new WingStats(flyTime5, flySpeedOverride7);
      wingStatsArray[9] = new WingStats(flyTime5, flySpeedOverride7);
      wingStatsArray[11] = new WingStats(flyTime6, flySpeedOverride7);
      wingStatsArray[8] = new WingStats(flyTime6, flySpeedOverride7);
      wingStatsArray[27] = new WingStats(flyTime6, flySpeedOverride7);
      wingStatsArray[24] = new WingStats(flyTime6, flySpeedOverride7);
      wingStatsArray[22] = new WingStats(flyTime6, flySpeedOverride4, hasHoldDownHoverFeatures: true, hoverFlySpeedOverride: 10f, hoverAccelerationMultiplier: 10f);
      wingStatsArray[21] = new WingStats(flyTime7, flySpeedOverride7);
      wingStatsArray[20] = new WingStats(flyTime7, flySpeedOverride7);
      wingStatsArray[12] = new WingStats(flyTime7, flySpeedOverride7);
      wingStatsArray[23] = new WingStats(flyTime7, flySpeedOverride7);
      wingStatsArray[26] = new WingStats(flyTime7, flySpeedOverride8, 2f);
      wingStatsArray[45] = new WingStats(flyTime7, flySpeedOverride8, 4.5f, true, 16f, 16f);
      wingStatsArray[37] = new WingStats(flyTime4, flySpeedOverride6, 2.5f, true, 12f, 12f);
      wingStatsArray[44] = new WingStats(flyTime4, flySpeedOverride8, 2f);
      WingStats wingStats1 = new WingStats(flyTime4, flySpeedOverride2, 2.5f, true, 12f, 12f);
      wingStatsArray[29] = new WingStats(flyTime7, flySpeedOverride9, 2.5f);
      wingStatsArray[32] = new WingStats(flyTime7, flySpeedOverride9, 2.5f);
      wingStatsArray[30] = new WingStats(flyTime7, flySpeedOverride4, 1.5f, true, 12f, 12f);
      wingStatsArray[31] = new WingStats(flyTime7, flySpeedOverride4, 1.5f, true, 12f, 12f);
      WingStats wingStats2 = new WingStats(flyTime8, flySpeedOverride6);
      wingStatsArray[3] = wingStats2;
      wingStatsArray[16] = wingStats2;
      wingStatsArray[17] = wingStats2;
      wingStatsArray[18] = wingStats2;
      wingStatsArray[19] = wingStats2;
      wingStatsArray[28] = wingStats2;
      wingStatsArray[33] = wingStats2;
      wingStatsArray[34] = wingStats2;
      wingStatsArray[35] = wingStats2;
      wingStatsArray[36] = wingStats2;
      wingStatsArray[38] = wingStats2;
      wingStatsArray[39] = wingStats2;
      wingStatsArray[40] = wingStats2;
      wingStatsArray[42] = wingStats2;
      wingStatsArray[41] = wingStats2;
      wingStatsArray[43] = wingStats2;
      ArmorIDs.Wing.Sets.Stats = wingStatsArray;
    }
  }
}
