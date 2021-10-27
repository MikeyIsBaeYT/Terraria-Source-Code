// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Capture.CaptureSettings
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.Graphics.Capture
{
  public class CaptureSettings
  {
    public Rectangle Area;
    public bool UseScaling = true;
    public string OutputName;
    public bool CaptureEntities = true;
    public CaptureBiome Biome = CaptureBiome.Biomes[0];
    public bool CaptureMech;
    public bool CaptureBackground;

    public CaptureSettings()
    {
      DateTime localTime = DateTime.Now.ToLocalTime();
      this.OutputName = "Capture " + localTime.Year.ToString("D4") + "-" + localTime.Month.ToString("D2") + "-" + localTime.Day.ToString("D2") + " " + localTime.Hour.ToString("D2") + "_" + localTime.Minute.ToString("D2") + "_" + localTime.Second.ToString("D2");
    }
  }
}
