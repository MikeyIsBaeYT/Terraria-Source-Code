// Decompiled with JetBrains decompiler
// Type: Terraria.TestHighFPSIssues
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameInput;

namespace Terraria
{
  public class TestHighFPSIssues
  {
    private static List<double> _tapUpdates = new List<double>();
    private static List<double> _tapUpdateEnds = new List<double>();
    private static List<double> _tapDraws = new List<double>();
    private static int conU;
    private static int conUH;
    private static int conD;
    private static int conDH;
    private static int race;

    public static void TapUpdate(GameTime gt)
    {
      TestHighFPSIssues._tapUpdates.Add(gt.TotalGameTime.TotalMilliseconds);
      TestHighFPSIssues.conD = 0;
      --TestHighFPSIssues.race;
      if (++TestHighFPSIssues.conU <= TestHighFPSIssues.conUH)
        return;
      TestHighFPSIssues.conUH = TestHighFPSIssues.conU;
    }

    public static void TapUpdateEnd(GameTime gt) => TestHighFPSIssues._tapUpdateEnds.Add(gt.TotalGameTime.TotalMilliseconds);

    public static void TapDraw(GameTime gt)
    {
      TestHighFPSIssues._tapDraws.Add(gt.TotalGameTime.TotalMilliseconds);
      TestHighFPSIssues.conU = 0;
      ++TestHighFPSIssues.race;
      if (++TestHighFPSIssues.conD <= TestHighFPSIssues.conDH)
        return;
      TestHighFPSIssues.conDH = TestHighFPSIssues.conD;
    }

    public static void Update(GameTime gt)
    {
      if (PlayerInput.Triggers.Current.Down)
      {
        int num;
        TestHighFPSIssues.conDH = num = 0;
        TestHighFPSIssues.conUH = num;
        TestHighFPSIssues.race = num;
      }
      double num1 = gt.TotalGameTime.TotalMilliseconds - 5000.0;
      while (TestHighFPSIssues._tapUpdates.Count > 0 && TestHighFPSIssues._tapUpdates[0] < num1)
        TestHighFPSIssues._tapUpdates.RemoveAt(0);
      while (TestHighFPSIssues._tapDraws.Count > 0 && TestHighFPSIssues._tapDraws[0] < num1)
        TestHighFPSIssues._tapDraws.RemoveAt(0);
      while (TestHighFPSIssues._tapUpdateEnds.Count > 0 && TestHighFPSIssues._tapUpdateEnds[0] < num1)
        TestHighFPSIssues._tapUpdateEnds.RemoveAt(0);
      Main.versionNumber = "total (u/d)   " + (object) TestHighFPSIssues._tapUpdates.Count + " " + (object) TestHighFPSIssues._tapUpdateEnds.Count + "  " + (object) TestHighFPSIssues.race + " " + (object) TestHighFPSIssues.conUH + " " + (object) TestHighFPSIssues.conDH;
      Main.NewText(Main.versionNumber);
    }
  }
}
