// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Ambience.AmbientSkyDrawCache
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

namespace Terraria.GameContent.Ambience
{
  public class AmbientSkyDrawCache
  {
    public static AmbientSkyDrawCache Instance = new AmbientSkyDrawCache();
    public AmbientSkyDrawCache.UnderworldCache[] Underworld = new AmbientSkyDrawCache.UnderworldCache[5];
    public AmbientSkyDrawCache.OceanLineCache OceanLineInfo;

    public void SetUnderworldInfo(int drawIndex, float scale) => this.Underworld[drawIndex] = new AmbientSkyDrawCache.UnderworldCache()
    {
      Scale = scale
    };

    public void SetOceanLineInfo(float yScreenPosition, float oceanOpacity) => this.OceanLineInfo = new AmbientSkyDrawCache.OceanLineCache()
    {
      YScreenPosition = yScreenPosition,
      OceanOpacity = oceanOpacity
    };

    public struct UnderworldCache
    {
      public float Scale;
    }

    public struct OceanLineCache
    {
      public float YScreenPosition;
      public float OceanOpacity;
    }
  }
}
