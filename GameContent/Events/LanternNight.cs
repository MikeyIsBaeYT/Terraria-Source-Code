// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Events.LanternNight
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;

namespace Terraria.GameContent.Events
{
  public class LanternNight
  {
    public static bool ManualLanterns;
    public static bool GenuineLanterns;
    public static bool NextNightIsLanternNight;
    public static int LanternNightsOnCooldown;
    private static bool _wasLanternNight;

    public static bool LanternsUp => LanternNight.GenuineLanterns || LanternNight.ManualLanterns;

    public static void CheckMorning()
    {
      bool flag = false;
      if (LanternNight.GenuineLanterns)
      {
        flag = true;
        LanternNight.GenuineLanterns = false;
      }
      if (LanternNight.ManualLanterns)
      {
        flag = true;
        LanternNight.ManualLanterns = false;
      }
      int num = flag ? 1 : 0;
    }

    public static void CheckNight() => LanternNight.NaturalAttempt();

    public static bool LanternsCanPersist() => !Main.dayTime && LanternNight.LanternsCanStart();

    public static bool LanternsCanStart() => !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon && Main.invasionType == 0 && NPC.MoonLordCountdown == 0 && !LanternNight.BossIsActive();

    private static bool BossIsActive()
    {
      for (int index = 0; index < 200; ++index)
      {
        NPC npc = Main.npc[index];
        if (npc.active && (npc.boss || npc.type >= 13 && npc.type <= 15))
          return true;
      }
      return false;
    }

    private static void NaturalAttempt()
    {
      if (Main.netMode == 1 || !LanternNight.LanternsCanStart())
        return;
      bool flag = false;
      if (LanternNight.LanternNightsOnCooldown > 0)
        --LanternNight.LanternNightsOnCooldown;
      if (LanternNight.LanternNightsOnCooldown == 0 && NPC.downedMoonlord && Main.rand.Next(14) == 0)
        flag = true;
      if (!flag && LanternNight.NextNightIsLanternNight)
      {
        LanternNight.NextNightIsLanternNight = false;
        flag = true;
      }
      if (!flag)
        return;
      LanternNight.GenuineLanterns = true;
      LanternNight.LanternNightsOnCooldown = Main.rand.Next(5, 11);
    }

    public static void ToggleManualLanterns()
    {
      int num1 = LanternNight.LanternsUp ? 1 : 0;
      if (Main.netMode != 1)
        LanternNight.ManualLanterns = !LanternNight.ManualLanterns;
      int num2 = LanternNight.LanternsUp ? 1 : 0;
      if (num1 == num2 || Main.netMode != 2)
        return;
      NetMessage.SendData(7);
    }

    public static void WorldClear()
    {
      LanternNight.ManualLanterns = false;
      LanternNight.GenuineLanterns = false;
      LanternNight.LanternNightsOnCooldown = 0;
      LanternNight._wasLanternNight = false;
    }

    public static void UpdateTime()
    {
      if (LanternNight.GenuineLanterns && !LanternNight.LanternsCanPersist())
        LanternNight.GenuineLanterns = false;
      if (LanternNight._wasLanternNight != LanternNight.LanternsUp)
      {
        if (Main.netMode != 2)
        {
          if (LanternNight.LanternsUp)
            SkyManager.Instance.Activate("Lantern", new Vector2());
          else
            SkyManager.Instance.Deactivate("Lantern");
        }
        else
          NetMessage.SendData(7);
      }
      LanternNight._wasLanternNight = LanternNight.LanternsUp;
    }
  }
}
