// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.ScreenEffectInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.Skies;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Terraria.Initializers
{
  public static class ScreenEffectInitializer
  {
    public static void Load()
    {
      Filters.Scene["Nebula"] = new Filter(new ScreenShaderData("FilterTower").UseColor(1f, 0.0f, 0.9f).UseOpacity(0.35f), EffectPriority.High);
      Filters.Scene["Solar"] = new Filter(new ScreenShaderData("FilterTower").UseColor(1f, 0.7f, 0.0f).UseOpacity(0.3f), EffectPriority.High);
      Filters.Scene["Stardust"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0.0f, 0.5f, 1f).UseOpacity(0.5f), EffectPriority.High);
      Filters.Scene["Vortex"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0.0f, 0.7f, 0.7f).UseOpacity(0.5f), EffectPriority.High);
      Filters.Scene["MonolithNebula"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(1f, 0.0f, 0.9f).UseOpacity(0.35f), EffectPriority.Medium);
      Filters.Scene["MonolithSolar"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(1f, 0.7f, 0.0f).UseOpacity(0.3f), EffectPriority.Medium);
      Filters.Scene["MonolithStardust"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.0f, 0.5f, 1f).UseOpacity(0.5f), EffectPriority.Medium);
      Filters.Scene["MonolithVortex"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.0f, 0.7f, 0.7f).UseOpacity(0.5f), EffectPriority.Medium);
      Filters.Scene["MoonLord"] = new Filter((ScreenShaderData) new MoonLordScreenShaderData("FilterMoonLord", false), EffectPriority.VeryHigh);
      Filters.Scene["MoonLordShake"] = new Filter((ScreenShaderData) new MoonLordScreenShaderData("FilterMoonLordShake", false), EffectPriority.VeryHigh);
      Filters.Scene["MonolithMoonLord"] = new Filter((ScreenShaderData) new MoonLordScreenShaderData("FilterMoonLord", true), EffectPriority.Medium);
      Filters.Scene["Graveyard"] = new Filter(new ScreenShaderData("FilterGraveyard"), EffectPriority.Medium);
      Filters.Scene["testInvert"] = new Filter(new ScreenShaderData("FilterInvert"), EffectPriority.VeryHigh);
      Filters.Scene["BloodMoon"] = new Filter(new BloodMoonScreenShaderData("FilterBloodMoon").UseColor(2f, -0.8f, -0.6f), EffectPriority.Medium);
      Filters.Scene["Sandstorm"] = new Filter(new SandstormShaderData("FilterSandstormForeground").UseColor(1.1f, 1f, 0.5f).UseSecondaryColor(0.7f, 0.5f, 0.3f).UseImage("Images/Misc/noise").UseIntensity(0.4f), EffectPriority.High);
      Overlays.Scene["Sandstorm"] = (Overlay) new SimpleOverlay("Images/Misc/noise", new SandstormShaderData("FilterSandstormBackground").UseColor(1.1f, 1f, 0.5f).UseSecondaryColor(0.7f, 0.5f, 0.3f).UseImage("Images/Misc/noise").UseIntensity(0.4f), EffectPriority.High, RenderLayers.Landscape);
      Filters.Scene["Blizzard"] = new Filter(new BlizzardShaderData("FilterBlizzardForeground").UseColor(1f, 1f, 1f).UseSecondaryColor(0.7f, 0.7f, 1f).UseImage("Images/Misc/noise").UseIntensity(0.4f).UseImageScale(new Vector2(3f, 0.75f)), EffectPriority.High);
      Overlays.Scene["Blizzard"] = (Overlay) new SimpleOverlay("Images/Misc/noise", new BlizzardShaderData("FilterBlizzardBackground").UseColor(1f, 1f, 1f).UseSecondaryColor(0.7f, 0.7f, 1f).UseImage("Images/Misc/noise").UseIntensity(0.4f).UseImageScale(new Vector2(3f, 0.75f)), EffectPriority.High, RenderLayers.Landscape);
      Filters.Scene["HeatDistortion"] = new Filter(new ScreenShaderData("FilterHeatDistortion").UseImage("Images/Misc/noise").UseIntensity(4f), EffectPriority.Low);
      Filters.Scene["WaterDistortion"] = new Filter(new WaterShaderData("FilterWaterDistortion").UseIntensity(1f).UseImage("Images/Misc/noise"), EffectPriority.VeryHigh);
      Filters.Scene["CrystalDestructionColor"] = new Filter(new ScreenShaderData("FilterCrystalDestructionColor").UseColor(1f, 0.0f, 0.75f).UseIntensity(1f).UseOpacity(0.8f), EffectPriority.VeryHigh);
      Filters.Scene["CrystalDestructionVortex"] = new Filter(new ScreenShaderData("FilterCrystalDestructionVortex").UseImage("Images/Misc/noise"), EffectPriority.VeryHigh);
      Filters.Scene["CrystalWin"] = new Filter(new ScreenShaderData("FilterCrystalWin"), EffectPriority.VeryHigh);
      Filters.Scene["Test"] = new Filter(new ScreenShaderData("FilterTest"), EffectPriority.VeryHigh);
      Filters.Scene["Test2"] = new Filter(new ScreenShaderData("FilterTest2"), EffectPriority.VeryHigh);
      Filters.Scene["Test3"] = new Filter(new ScreenShaderData("FilterTest3").UseImage("Images/Extra_" + (object) (short) 156), EffectPriority.VeryHigh);
      Overlays.Scene.Load();
      Filters.Scene.Load();
      ScreenEffectInitializer.LoadSkies();
    }

    private static void LoadSkies()
    {
      SkyManager.Instance["Party"] = (CustomSky) new PartySky();
      SkyManager.Instance["Martian"] = (CustomSky) new MartianSky();
      SkyManager.Instance["Nebula"] = (CustomSky) new NebulaSky();
      SkyManager.Instance["Stardust"] = (CustomSky) new StardustSky();
      SkyManager.Instance["Vortex"] = (CustomSky) new VortexSky();
      SkyManager.Instance["Solar"] = (CustomSky) new SolarSky();
      SkyManager.Instance["Slime"] = (CustomSky) new SlimeSky();
      SkyManager.Instance["MoonLord"] = (CustomSky) new MoonLordSky(false);
      SkyManager.Instance["CreditsRoll"] = (CustomSky) new CreditsRollSky();
      SkyManager.Instance["MonolithNebula"] = (CustomSky) new NebulaSky();
      SkyManager.Instance["MonolithStardust"] = (CustomSky) new StardustSky();
      SkyManager.Instance["MonolithVortex"] = (CustomSky) new VortexSky();
      SkyManager.Instance["MonolithSolar"] = (CustomSky) new SolarSky();
      SkyManager.Instance["MonolithMoonLord"] = (CustomSky) new MoonLordSky(true);
      SkyManager.Instance["Sandstorm"] = (CustomSky) new SandstormSky();
      SkyManager.Instance["Blizzard"] = (CustomSky) new BlizzardSky();
      SkyManager.Instance["Ambience"] = (CustomSky) new AmbientSky();
      SkyManager.Instance["Lantern"] = (CustomSky) new LanternSky();
      SkyManager.Instance.Load();
    }
  }
}
