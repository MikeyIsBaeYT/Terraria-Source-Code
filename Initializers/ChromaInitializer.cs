// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.ChromaInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using ReLogic.Peripherals.RGB;
using ReLogic.Peripherals.RGB.Corsair;
using ReLogic.Peripherals.RGB.Logitech;
using ReLogic.Peripherals.RGB.Razer;
using System;
using System.Diagnostics;
using Terraria.GameContent.RGB;
using Terraria.Graphics.Effects;
using Terraria.IO;

namespace Terraria.Initializers
{
  public static class ChromaInitializer
  {
    private static ChromaEngine _engine;

    private static void AddDevices()
    {
      VendorColorProfile razerColorProfile = Main.Configuration.Get<VendorColorProfile>("RazerColorProfile", new VendorColorProfile(new Vector3(1f, 0.765f, 0.568f)));
      VendorColorProfile corsairColorProfile = Main.Configuration.Get<VendorColorProfile>("CorsairColorProfile", new VendorColorProfile());
      VendorColorProfile logitechColorProfile = Main.Configuration.Get<VendorColorProfile>("LogitechColorProfile", new VendorColorProfile());
      ChromaInitializer._engine.AddDeviceGroup("Razer", (RgbDeviceGroup) new RazerDeviceGroup(razerColorProfile));
      ChromaInitializer._engine.AddDeviceGroup("Corsair", (RgbDeviceGroup) new CorsairDeviceGroup(corsairColorProfile));
      ChromaInitializer._engine.AddDeviceGroup("Logitech", (RgbDeviceGroup) new LogitechDeviceGroup(logitechColorProfile));
      bool useRazer = Main.Configuration.Get<bool>("UseRazerRGB", true);
      bool useCorsair = Main.Configuration.Get<bool>("UseCorsairRGB", true);
      bool useLogitech = Main.Configuration.Get<bool>("UseLogitechRGB", true);
      float rgbUpdateRate = Main.Configuration.Get<float>("RGBUpdatesPerSecond", 45f);
      if ((double) rgbUpdateRate <= 1.0000000116861E-07)
        rgbUpdateRate = 45f;
      ChromaInitializer._engine.FrameTimeInSeconds = 1f / rgbUpdateRate;
      Main.Configuration.OnSave += (Action<Preferences>) (config =>
      {
        config.Put("UseRazerRGB", (object) useRazer);
        config.Put("UseCorsairRGB", (object) useCorsair);
        config.Put("UseLogitechRGB", (object) useLogitech);
        config.Put("RazerColorProfile", (object) razerColorProfile);
        config.Put("CorsairColorProfile", (object) corsairColorProfile);
        config.Put("LogitechColorProfile", (object) logitechColorProfile);
        config.Put("RGBUpdatesPerSecond", (object) rgbUpdateRate);
      });
      if (useRazer)
        ChromaInitializer._engine.EnableDeviceGroup("Razer");
      if (useCorsair)
        ChromaInitializer._engine.EnableDeviceGroup("Corsair");
      if (useLogitech)
        ChromaInitializer._engine.EnableDeviceGroup("Logitech");
      AppDomain.CurrentDomain.ProcessExit += new EventHandler(ChromaInitializer.OnProcessExit);
    }

    private static void OnProcessExit(object sender, EventArgs e) => ChromaInitializer._engine.DisableAllDeviceGroups();

    public static void Load()
    {
      ChromaInitializer._engine = Main.Chroma;
      ChromaInitializer.AddDevices();
      Color color = new Color(46, 23, 12);
      ChromaInitializer.RegisterShader("Base", (ChromaShader) new SurfaceBiomeShader(Color.Green, color), CommonConditions.InMenu, (ShaderLayer) 9);
      ChromaInitializer.RegisterShader("Surface Mushroom", (ChromaShader) new SurfaceBiomeShader(Color.DarkBlue, new Color(33, 31, 27)), CommonConditions.DrunkMenu, (ShaderLayer) 9);
      ChromaInitializer.RegisterShader("Sky", (ChromaShader) new SkyShader(new Color(34, 51, 128), new Color(5, 5, 5)), CommonConditions.Depth.Sky, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Surface", (ChromaShader) new SurfaceBiomeShader(Color.Green, color), CommonConditions.Depth.Surface, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Vines", (ChromaShader) new VineShader(), CommonConditions.Depth.Vines, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Underground", (ChromaShader) new CavernShader(new Color(122, 62, 32), new Color(25, 13, 7), 0.5f), CommonConditions.Depth.Underground, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Caverns", (ChromaShader) new CavernShader(color, new Color(25, 25, 25), 0.5f), CommonConditions.Depth.Caverns, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Magma", (ChromaShader) new CavernShader(new Color(181, 17, 0), new Color(25, 25, 25), 0.5f), CommonConditions.Depth.Magma, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Underworld", (ChromaShader) new UnderworldShader(Color.Red, new Color(1f, 0.5f, 0.0f), 1f), CommonConditions.Depth.Underworld, (ShaderLayer) 1);
      ChromaInitializer.RegisterShader("Surface Desert", (ChromaShader) new SurfaceBiomeShader(new Color(84, 49, 0), new Color(245, 225, 33)), CommonConditions.SurfaceBiome.Desert, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Surface Jungle", (ChromaShader) new SurfaceBiomeShader(Color.Green, Color.Teal), CommonConditions.SurfaceBiome.Jungle, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Surface Ocean", (ChromaShader) new SurfaceBiomeShader(Color.SkyBlue, Color.Blue), CommonConditions.SurfaceBiome.Ocean, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Surface Snow", (ChromaShader) new SurfaceBiomeShader(new Color(0, 10, 50), new Color(0.5f, 0.75f, 1f)), CommonConditions.SurfaceBiome.Snow, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Surface Mushroom", (ChromaShader) new SurfaceBiomeShader(Color.DarkBlue, new Color(33, 31, 27)), CommonConditions.SurfaceBiome.Mushroom, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Surface Hallow", (ChromaShader) new HallowSurfaceShader(), CommonConditions.SurfaceBiome.Hallow, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Surface Crimson", (ChromaShader) new CorruptSurfaceShader(Color.Red, new Color(25, 25, 40)), CommonConditions.SurfaceBiome.Crimson, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Surface Corruption", (ChromaShader) new CorruptSurfaceShader(new Color(73, 0, (int) byte.MaxValue), new Color(15, 15, 27)), CommonConditions.SurfaceBiome.Corruption, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Hive", (ChromaShader) new DrippingShader(new Color(0.05f, 0.01f, 0.0f), new Color((int) byte.MaxValue, 150, 0), 0.5f), CommonConditions.UndergroundBiome.Hive, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Underground Mushroom", (ChromaShader) new UndergroundMushroomShader(), CommonConditions.UndergroundBiome.Mushroom, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Underground Corrutpion", (ChromaShader) new UndergroundCorruptionShader(), CommonConditions.UndergroundBiome.Corrupt, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Underground Crimson", (ChromaShader) new DrippingShader(new Color(0.05f, 0.0f, 0.0f), new Color((int) byte.MaxValue, 0, 0)), CommonConditions.UndergroundBiome.Crimson, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Underground Hallow", (ChromaShader) new UndergroundHallowShader(), CommonConditions.UndergroundBiome.Hallow, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Meteorite", (ChromaShader) new MeteoriteShader(), CommonConditions.MiscBiome.Meteorite, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Temple", (ChromaShader) new TempleShader(), CommonConditions.UndergroundBiome.Temple, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Dungeon", (ChromaShader) new DungeonShader(), CommonConditions.UndergroundBiome.Dungeon, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Granite", (ChromaShader) new CavernShader(new Color(14, 19, 46), new Color(5, 0, 30), 0.5f), CommonConditions.UndergroundBiome.Granite, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Marble", (ChromaShader) new CavernShader(new Color(100, 100, 100), new Color(20, 20, 20), 0.5f), CommonConditions.UndergroundBiome.Marble, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Gem Cave", (ChromaShader) new GemCaveShader(color, new Color(25, 25, 25)), CommonConditions.UndergroundBiome.GemCave, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Underground Jungle", (ChromaShader) new JungleShader(), CommonConditions.UndergroundBiome.Jungle, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Underground Ice", (ChromaShader) new IceShader(new Color(0, 10, 50), new Color(0.5f, 0.75f, 1f)), CommonConditions.UndergroundBiome.Ice, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Corrupt Ice", (ChromaShader) new IceShader(new Color(5, 0, 25), new Color(152, 102, (int) byte.MaxValue)), CommonConditions.UndergroundBiome.CorruptIce, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Crimson Ice", (ChromaShader) new IceShader(new Color(0.1f, 0.0f, 0.0f), new Color(1f, 0.45f, 0.4f)), CommonConditions.UndergroundBiome.CrimsonIce, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Hallow Ice", (ChromaShader) new IceShader(new Color(0.2f, 0.0f, 0.1f), new Color(1f, 0.7f, 0.7f)), CommonConditions.UndergroundBiome.HallowIce, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Underground Desert", (ChromaShader) new DesertShader(new Color(60, 10, 0), new Color((int) byte.MaxValue, 165, 0)), CommonConditions.UndergroundBiome.Desert, (ShaderLayer) 2);
      ChromaInitializer.RegisterShader("Corrupt Desert", (ChromaShader) new DesertShader(new Color(15, 0, 15), new Color(116, 103, (int) byte.MaxValue)), CommonConditions.UndergroundBiome.CorruptDesert, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Crimson Desert", (ChromaShader) new DesertShader(new Color(20, 10, 0), new Color(195, 0, 0)), CommonConditions.UndergroundBiome.CrimsonDesert, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Hallow Desert", (ChromaShader) new DesertShader(new Color(29, 0, 56), new Color((int) byte.MaxValue, 221, (int) byte.MaxValue)), CommonConditions.UndergroundBiome.HallowDesert, (ShaderLayer) 3);
      ChromaInitializer.RegisterShader("Pumpkin Moon", (ChromaShader) new MoonShader(new Color(13, 0, 26), Color.Orange), CommonConditions.Events.PumpkinMoon, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Blood Moon", (ChromaShader) new MoonShader(new Color(10, 0, 0), Color.Red, Color.Red, new Color((int) byte.MaxValue, 150, 125)), CommonConditions.Events.BloodMoon, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Frost Moon", (ChromaShader) new MoonShader(new Color(0, 4, 13), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)), CommonConditions.Events.FrostMoon, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Solar Eclipse", (ChromaShader) new MoonShader(new Color(0.02f, 0.02f, 0.02f), Color.Orange, Color.Black), CommonConditions.Events.SolarEclipse, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Pirate Invasion", (ChromaShader) new PirateInvasionShader(new Color(173, 173, 173), new Color(101, 101, (int) byte.MaxValue), Color.Blue, Color.Black), CommonConditions.Events.PirateInvasion, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("DD2 Event", (ChromaShader) new DD2Shader(new Color(222, 94, 245), Color.White), CommonConditions.Events.DD2Event, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Goblin Army", (ChromaShader) new GoblinArmyShader(new Color(14, 0, 79), new Color(176, 0, 144)), CommonConditions.Events.GoblinArmy, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Frost Legion", (ChromaShader) new FrostLegionShader(Color.White, new Color(27, 80, 201)), CommonConditions.Events.FrostLegion, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Martian Madness", (ChromaShader) new MartianMadnessShader(new Color(64, 64, 64), new Color(64, 113, 122), new Color((int) byte.MaxValue, (int) byte.MaxValue, 0), new Color(3, 3, 18)), CommonConditions.Events.MartianMadness, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Solar Pillar", (ChromaShader) new PillarShader(Color.Red, Color.Orange), CommonConditions.Events.SolarPillar, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Nebula Pillar", (ChromaShader) new PillarShader(new Color((int) byte.MaxValue, 144, 209), new Color(100, 0, 76)), CommonConditions.Events.NebulaPillar, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Vortex Pillar", (ChromaShader) new PillarShader(Color.Green, Color.Black), CommonConditions.Events.VortexPillar, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Stardust Pillar", (ChromaShader) new PillarShader(new Color(46, 63, (int) byte.MaxValue), Color.White), CommonConditions.Events.StardustPillar, (ShaderLayer) 4);
      ChromaInitializer.RegisterShader("Eater of Worlds", (ChromaShader) new WormShader(new Color(14, 0, 15), new Color(47, 51, 59), new Color(20, 25, 11)), CommonConditions.Boss.EaterOfWorlds, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Eye of Cthulhu", (ChromaShader) new EyeOfCthulhuShader(new Color(145, 145, 126), new Color(138, 0, 0), new Color(3, 3, 18)), CommonConditions.Boss.EyeOfCthulhu, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Skeletron", (ChromaShader) new SkullShader(new Color(110, 92, 47), new Color(36, 32, 51), new Color(0, 0, 0)), CommonConditions.Boss.Skeletron, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Brain Of Cthulhu", (ChromaShader) new BrainShader(new Color(54, 0, 0), new Color(186, 137, 139)), CommonConditions.Boss.BrainOfCthulhu, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Empress of Light", (ChromaShader) new EmpressShader(), CommonConditions.Boss.Empress, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Queen Slime", (ChromaShader) new QueenSlimeShader(new Color(72, 41, 130), new Color(126, 220, (int) byte.MaxValue)), CommonConditions.Boss.QueenSlime, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("King Slime", (ChromaShader) new KingSlimeShader(new Color(41, 70, 130), Color.White), CommonConditions.Boss.KingSlime, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Queen Bee", (ChromaShader) new QueenBeeShader(new Color(5, 5, 0), new Color((int) byte.MaxValue, 235, 0)), CommonConditions.Boss.QueenBee, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Wall of Flesh", (ChromaShader) new WallOfFleshShader(new Color(112, 48, 60), new Color(5, 0, 0)), CommonConditions.Boss.WallOfFlesh, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Destroyer", (ChromaShader) new WormShader(new Color(25, 25, 25), new Color(192, 0, 0), new Color(10, 0, 0)), CommonConditions.Boss.Destroyer, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Skeletron Prime", (ChromaShader) new SkullShader(new Color(110, 92, 47), new Color(79, 0, 0), new Color((int) byte.MaxValue, 29, 0)), CommonConditions.Boss.SkeletronPrime, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("The Twins", (ChromaShader) new TwinsShader(new Color(145, 145, 126), new Color(138, 0, 0), new Color(138, 0, 0), new Color(20, 20, 20), new Color(65, 140, 0), new Color(3, 3, 18)), CommonConditions.Boss.TheTwins, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Duke Fishron", (ChromaShader) new DukeFishronShader(new Color(0, 0, 122), new Color(100, 254, 194)), CommonConditions.Boss.DukeFishron, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Plantera", (ChromaShader) new PlanteraShader(new Color((int) byte.MaxValue, 0, 220), new Color(0, (int) byte.MaxValue, 0), new Color(12, 4, 0)), CommonConditions.Boss.Plantera, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Golem", (ChromaShader) new GolemShader(new Color((int) byte.MaxValue, 144, 0), new Color((int) byte.MaxValue, 198, 0), new Color(10, 10, 0)), CommonConditions.Boss.Golem, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Cultist", (ChromaShader) new CultistShader(), CommonConditions.Boss.Cultist, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Moon Lord", (ChromaShader) new EyeballShader(false), CommonConditions.Boss.MoonLord, (ShaderLayer) 5);
      ChromaInitializer.RegisterShader("Rain", (ChromaShader) new RainShader(), CommonConditions.Weather.Rain, (ShaderLayer) 6);
      ChromaInitializer.RegisterShader("Snowstorm", (ChromaShader) new BlizzardShader(), CommonConditions.Weather.Blizzard, (ShaderLayer) 6);
      ChromaInitializer.RegisterShader("Sandstorm", (ChromaShader) new SandstormShader(), CommonConditions.Weather.Sandstorm, (ShaderLayer) 6);
      ChromaInitializer.RegisterShader("Slime Rain", (ChromaShader) new SlimeRainShader(), CommonConditions.Weather.SlimeRain, (ShaderLayer) 6);
      ChromaInitializer.RegisterShader("Drowning", (ChromaShader) new DrowningShader(), CommonConditions.Alert.Drowning, (ShaderLayer) 7);
      ChromaInitializer.RegisterShader("Keybinds", (ChromaShader) new KeybindsMenuShader(), CommonConditions.Alert.Keybinds, (ShaderLayer) 7);
      ChromaInitializer.RegisterShader("Lava Indicator", (ChromaShader) new LavaIndicatorShader(Color.Black, Color.Red, new Color((int) byte.MaxValue, 188, 0)), CommonConditions.Alert.LavaIndicator, (ShaderLayer) 7);
      ChromaInitializer.RegisterShader("Moon Lord Spawn", (ChromaShader) new EyeballShader(true), CommonConditions.Alert.MoonlordComing, (ShaderLayer) 7);
      ChromaInitializer.RegisterShader("Low Life", (ChromaShader) new LowLifeShader(), CommonConditions.CriticalAlert.LowLife, (ShaderLayer) 8);
      ChromaInitializer.RegisterShader("Death", (ChromaShader) new DeathShader(new Color(36, 0, 10), new Color(158, 28, 53)), CommonConditions.CriticalAlert.Death, (ShaderLayer) 8);
    }

    private static void RegisterShader(
      string name,
      ChromaShader shader,
      ChromaCondition condition,
      ShaderLayer layer)
    {
      ChromaInitializer._engine.RegisterShader(shader, condition, layer);
    }

    [Conditional("DEBUG")]
    private static void AddDebugDraw()
    {
      BasicDebugDrawer basicDebugDrawer = new BasicDebugDrawer(Main.instance.GraphicsDevice);
      Filters.Scene.OnPostDraw += (Action) (() => { });
    }
  }
}
