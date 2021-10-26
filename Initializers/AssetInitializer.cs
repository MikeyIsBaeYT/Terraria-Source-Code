// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.AssetInitializer
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using ReLogic.Content;
using ReLogic.Content.Readers;
using ReLogic.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.IO;
using Terraria.Utilities;

namespace Terraria.Initializers
{
  public static class AssetInitializer
  {
    public static void CreateAssetServices(GameServiceContainer services)
    {
      AssetReaderCollection readerCollection = new AssetReaderCollection();
      readerCollection.RegisterReader((IAssetReader) new PngReader(XnaExtensions.Get<IGraphicsDeviceService>((IServiceProvider) services).GraphicsDevice), new string[1]
      {
        ".png"
      });
      readerCollection.RegisterReader((IAssetReader) new XnbReader((IServiceProvider) services), new string[1]
      {
        ".xnb"
      });
      AsyncAssetLoader asyncAssetLoader = new AsyncAssetLoader(readerCollection, 20);
      asyncAssetLoader.RequireTypeCreationOnTransfer(typeof (Texture2D));
      asyncAssetLoader.RequireTypeCreationOnTransfer(typeof (DynamicSpriteFont));
      asyncAssetLoader.RequireTypeCreationOnTransfer(typeof (SpriteFont));
      IAssetRepository iassetRepository = (IAssetRepository) new AssetRepository((IAssetLoader) new AssetLoader(readerCollection), (IAsyncAssetLoader) asyncAssetLoader);
      services.AddService(typeof (AssetReaderCollection), (object) readerCollection);
      services.AddService(typeof (IAssetRepository), (object) iassetRepository);
    }

    public static ResourcePackList CreateResourcePackList(IServiceProvider services)
    {
      JArray resourcePackJson;
      string resourcePackFolder;
      AssetInitializer.GetResourcePacksFolderPathAndConfirmItExists(out resourcePackJson, out resourcePackFolder);
      return ResourcePackList.FromJson(resourcePackJson, services, resourcePackFolder);
    }

    public static void GetResourcePacksFolderPathAndConfirmItExists(
      out JArray resourcePackJson,
      out string resourcePackFolder)
    {
      resourcePackJson = Main.Configuration.Get<JArray>("ResourcePacks", new JArray());
      resourcePackFolder = Path.Combine(Main.SavePath, "ResourcePacks");
      Utils.TryCreatingDirectory(resourcePackFolder);
    }

    public static void LoadSplashAssets(bool asyncLoadForSounds)
    {
      TextureAssets.SplashTexture16x9 = AssetInitializer.LoadAsset<Texture2D>("Images\\SplashScreens\\Splash_1", (AssetRequestMode) 1);
      TextureAssets.SplashTexture4x3 = AssetInitializer.LoadAsset<Texture2D>("Images\\logo_" + (object) new UnifiedRandom().Next(1, 9), (AssetRequestMode) 1);
      TextureAssets.SplashTextureLegoResonanace = AssetInitializer.LoadAsset<Texture2D>("Images\\SplashScreens\\ResonanceArray", (AssetRequestMode) 1);
      int num = new UnifiedRandom().Next(1, 10);
      TextureAssets.SplashTextureLegoBack = AssetInitializer.LoadAsset<Texture2D>("Images\\SplashScreens\\Splash_" + (object) num + "_0", (AssetRequestMode) 1);
      TextureAssets.SplashTextureLegoTree = AssetInitializer.LoadAsset<Texture2D>("Images\\SplashScreens\\Splash_" + (object) num + "_1", (AssetRequestMode) 1);
      TextureAssets.SplashTextureLegoFront = AssetInitializer.LoadAsset<Texture2D>("Images\\SplashScreens\\Splash_" + (object) num + "_2", (AssetRequestMode) 1);
      TextureAssets.Item[75] = AssetInitializer.LoadAsset<Texture2D>("Images\\Item_" + (object) (short) 75, (AssetRequestMode) 1);
      TextureAssets.LoadingSunflower = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Sunflower_Loading", (AssetRequestMode) 1);
    }

    public static void LoadAssetsWhileInInitialBlackScreen()
    {
      AssetInitializer.LoadFonts((AssetRequestMode) 1);
      AssetInitializer.LoadTextures((AssetRequestMode) 1);
      AssetInitializer.LoadRenderTargetAssets((AssetRequestMode) 1);
      AssetInitializer.LoadSounds((AssetRequestMode) 1);
    }

    public static void Load(bool asyncLoad)
    {
    }

    private static void LoadFonts(AssetRequestMode mode)
    {
      FontAssets.ItemStack = AssetInitializer.LoadAsset<DynamicSpriteFont>("Fonts/Item_Stack", mode);
      FontAssets.MouseText = AssetInitializer.LoadAsset<DynamicSpriteFont>("Fonts/Mouse_Text", mode);
      FontAssets.DeathText = AssetInitializer.LoadAsset<DynamicSpriteFont>("Fonts/Death_Text", mode);
      FontAssets.CombatText[0] = AssetInitializer.LoadAsset<DynamicSpriteFont>("Fonts/Combat_Text", mode);
      FontAssets.CombatText[1] = AssetInitializer.LoadAsset<DynamicSpriteFont>("Fonts/Combat_Crit", mode);
    }

    private static void LoadSounds(AssetRequestMode mode) => SoundEngine.Load((IServiceProvider) Main.instance.Services);

    private static void LoadRenderTargetAssets(AssetRequestMode mode)
    {
      AssetInitializer.RegisterRenderTargetAsset((INeedRenderTargetContent) (TextureAssets.RenderTargets.PlayerRainbowWings = new PlayerRainbowWingsTextureContent()));
      AssetInitializer.RegisterRenderTargetAsset((INeedRenderTargetContent) (TextureAssets.RenderTargets.PlayerTitaniumStormBuff = new PlayerTitaniumStormBuffTextureContent()));
      AssetInitializer.RegisterRenderTargetAsset((INeedRenderTargetContent) (TextureAssets.RenderTargets.QueenSlimeMount = new PlayerQueenSlimeMountTextureContent()));
    }

    private static void RegisterRenderTargetAsset(INeedRenderTargetContent content) => Main.ContentThatNeedsRenderTargets.Add(content);

    private static void LoadTextures(AssetRequestMode mode)
    {
      for (int index1 = 0; index1 < TextureAssets.Item.Length; ++index1)
      {
        int index2 = ItemID.Sets.TextureCopyLoad[index1];
        TextureAssets.Item[index1] = index2 == -1 ? AssetInitializer.LoadAsset<Texture2D>("Images/Item_" + (object) index1, (AssetRequestMode) 0) : TextureAssets.Item[index2];
      }
      for (int index = 0; index < TextureAssets.Npc.Length; ++index)
        TextureAssets.Npc[index] = AssetInitializer.LoadAsset<Texture2D>("Images/NPC_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.Projectile.Length; ++index)
        TextureAssets.Projectile[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Projectile_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.Gore.Length; ++index)
        TextureAssets.Gore[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Gore_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.Wall.Length; ++index)
        TextureAssets.Wall[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Wall_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.Tile.Length; ++index)
        TextureAssets.Tile[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Tiles_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.ItemFlame.Length; ++index)
        TextureAssets.ItemFlame[index] = AssetInitializer.LoadAsset<Texture2D>("Images/ItemFlame_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.Wings.Length; ++index)
        TextureAssets.Wings[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Wings_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.PlayerHair.Length; ++index)
        TextureAssets.PlayerHair[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Player_Hair_" + (object) (index + 1), (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.PlayerHairAlt.Length; ++index)
        TextureAssets.PlayerHairAlt[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Player_HairAlt_" + (object) (index + 1), (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.ArmorHead.Length; ++index)
        TextureAssets.ArmorHead[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Armor_Head_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.FemaleBody.Length; ++index)
        TextureAssets.FemaleBody[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Female_Body_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.ArmorBody.Length; ++index)
        TextureAssets.ArmorBody[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Armor_Body_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.ArmorBodyComposite.Length; ++index)
        TextureAssets.ArmorBodyComposite[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Armor/Armor_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.ArmorArm.Length; ++index)
        TextureAssets.ArmorArm[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Armor_Arm_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.ArmorLeg.Length; ++index)
        TextureAssets.ArmorLeg[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Armor_Legs_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccHandsOn.Length; ++index)
        TextureAssets.AccHandsOn[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_HandsOn_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccHandsOff.Length; ++index)
        TextureAssets.AccHandsOff[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_HandsOff_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccHandsOnComposite.Length; ++index)
        TextureAssets.AccHandsOnComposite[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Accessories/Acc_HandsOn_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccHandsOffComposite.Length; ++index)
        TextureAssets.AccHandsOffComposite[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Accessories/Acc_HandsOff_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccBack.Length; ++index)
        TextureAssets.AccBack[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Back_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccFront.Length; ++index)
        TextureAssets.AccFront[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Front_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccShoes.Length; ++index)
        TextureAssets.AccShoes[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Shoes_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccWaist.Length; ++index)
        TextureAssets.AccWaist[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Waist_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccShield.Length; ++index)
        TextureAssets.AccShield[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Shield_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccNeck.Length; ++index)
        TextureAssets.AccNeck[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Neck_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccFace.Length; ++index)
        TextureAssets.AccFace[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Face_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.AccBalloon.Length; ++index)
        TextureAssets.AccBalloon[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Acc_Balloon_" + (object) index, (AssetRequestMode) 0);
      for (int index = 0; index < TextureAssets.Background.Length; ++index)
        TextureAssets.Background[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Background_" + (object) index, (AssetRequestMode) 0);
      TextureAssets.FlameRing = AssetInitializer.LoadAsset<Texture2D>("Images/FlameRing", (AssetRequestMode) 0);
      TextureAssets.TileCrack = AssetInitializer.LoadAsset<Texture2D>("Images\\TileCracks", mode);
      TextureAssets.ChestStack[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\ChestStack_0", mode);
      TextureAssets.ChestStack[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\ChestStack_1", mode);
      TextureAssets.SmartDig = AssetInitializer.LoadAsset<Texture2D>("Images\\SmartDig", mode);
      TextureAssets.IceBarrier = AssetInitializer.LoadAsset<Texture2D>("Images\\IceBarrier", mode);
      TextureAssets.Frozen = AssetInitializer.LoadAsset<Texture2D>("Images\\Frozen", mode);
      for (int index = 0; index < TextureAssets.Pvp.Length; ++index)
        TextureAssets.Pvp[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\PVP_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.EquipPage.Length; ++index)
        TextureAssets.EquipPage[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\DisplaySlots_" + (object) index, mode);
      TextureAssets.HouseBanner = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\House_Banner", mode);
      for (int index = 0; index < TextureAssets.CraftToggle.Length; ++index)
        TextureAssets.CraftToggle[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Craft_Toggle_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.InventorySort.Length; ++index)
        TextureAssets.InventorySort[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Sort_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.TextGlyph.Length; ++index)
        TextureAssets.TextGlyph[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Glyphs_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.HotbarRadial.Length; ++index)
        TextureAssets.HotbarRadial[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\HotbarRadial_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.InfoIcon.Length; ++index)
        TextureAssets.InfoIcon[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\InfoIcon_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.Reforge.Length; ++index)
        TextureAssets.Reforge[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Reforge_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.Camera.Length; ++index)
        TextureAssets.Camera[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Camera_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.WireUi.Length; ++index)
        TextureAssets.WireUi[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Wires_" + (object) index, mode);
      TextureAssets.BuilderAcc = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\BuilderIcons", mode);
      TextureAssets.QuicksIcon = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\UI_quickicon1", mode);
      TextureAssets.CraftUpButton = AssetInitializer.LoadAsset<Texture2D>("Images\\RecUp", mode);
      TextureAssets.CraftDownButton = AssetInitializer.LoadAsset<Texture2D>("Images\\RecDown", mode);
      TextureAssets.ScrollLeftButton = AssetInitializer.LoadAsset<Texture2D>("Images\\RecLeft", mode);
      TextureAssets.ScrollRightButton = AssetInitializer.LoadAsset<Texture2D>("Images\\RecRight", mode);
      TextureAssets.OneDropLogo = AssetInitializer.LoadAsset<Texture2D>("Images\\OneDropLogo", mode);
      TextureAssets.Pulley = AssetInitializer.LoadAsset<Texture2D>("Images\\PlayerPulley", mode);
      TextureAssets.Timer = AssetInitializer.LoadAsset<Texture2D>("Images\\Timer", mode);
      TextureAssets.EmoteMenuButton = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Emotes", mode);
      TextureAssets.BestiaryMenuButton = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Bestiary", mode);
      TextureAssets.Wof = AssetInitializer.LoadAsset<Texture2D>("Images\\WallOfFlesh", mode);
      TextureAssets.WallOutline = AssetInitializer.LoadAsset<Texture2D>("Images\\Wall_Outline", mode);
      TextureAssets.Fade = AssetInitializer.LoadAsset<Texture2D>("Images\\fade-out", mode);
      TextureAssets.Ghost = AssetInitializer.LoadAsset<Texture2D>("Images\\Ghost", mode);
      TextureAssets.EvilCactus = AssetInitializer.LoadAsset<Texture2D>("Images\\Evil_Cactus", mode);
      TextureAssets.GoodCactus = AssetInitializer.LoadAsset<Texture2D>("Images\\Good_Cactus", mode);
      TextureAssets.CrimsonCactus = AssetInitializer.LoadAsset<Texture2D>("Images\\Crimson_Cactus", mode);
      TextureAssets.WraithEye = AssetInitializer.LoadAsset<Texture2D>("Images\\Wraith_Eyes", mode);
      TextureAssets.Firefly = AssetInitializer.LoadAsset<Texture2D>("Images\\Firefly", mode);
      TextureAssets.FireflyJar = AssetInitializer.LoadAsset<Texture2D>("Images\\FireflyJar", mode);
      TextureAssets.Lightningbug = AssetInitializer.LoadAsset<Texture2D>("Images\\LightningBug", mode);
      TextureAssets.LightningbugJar = AssetInitializer.LoadAsset<Texture2D>("Images\\LightningBugJar", mode);
      for (int index = 1; index <= 3; ++index)
        TextureAssets.JellyfishBowl[index - 1] = AssetInitializer.LoadAsset<Texture2D>("Images\\jellyfishBowl" + (object) index, mode);
      TextureAssets.GlowSnail = AssetInitializer.LoadAsset<Texture2D>("Images\\GlowSnail", mode);
      TextureAssets.IceQueen = AssetInitializer.LoadAsset<Texture2D>("Images\\IceQueen", mode);
      TextureAssets.SantaTank = AssetInitializer.LoadAsset<Texture2D>("Images\\SantaTank", mode);
      TextureAssets.JackHat = AssetInitializer.LoadAsset<Texture2D>("Images\\JackHat", mode);
      TextureAssets.TreeFace = AssetInitializer.LoadAsset<Texture2D>("Images\\TreeFace", mode);
      TextureAssets.PumpkingFace = AssetInitializer.LoadAsset<Texture2D>("Images\\PumpkingFace", mode);
      TextureAssets.ReaperEye = AssetInitializer.LoadAsset<Texture2D>("Images\\Reaper_Eyes", mode);
      TextureAssets.MapDeath = AssetInitializer.LoadAsset<Texture2D>("Images\\MapDeath", mode);
      TextureAssets.DukeFishron = AssetInitializer.LoadAsset<Texture2D>("Images\\DukeFishron", mode);
      TextureAssets.MiniMinotaur = AssetInitializer.LoadAsset<Texture2D>("Images\\MiniMinotaur", mode);
      TextureAssets.Map = AssetInitializer.LoadAsset<Texture2D>("Images\\Map", mode);
      for (int index = 0; index < TextureAssets.MapBGs.Length; ++index)
        TextureAssets.MapBGs[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\MapBG" + (object) (index + 1), mode);
      TextureAssets.Hue = AssetInitializer.LoadAsset<Texture2D>("Images\\Hue", mode);
      TextureAssets.ColorSlider = AssetInitializer.LoadAsset<Texture2D>("Images\\ColorSlider", mode);
      TextureAssets.ColorBar = AssetInitializer.LoadAsset<Texture2D>("Images\\ColorBar", mode);
      TextureAssets.ColorBlip = AssetInitializer.LoadAsset<Texture2D>("Images\\ColorBlip", mode);
      TextureAssets.ColorHighlight = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Slider_Highlight", mode);
      TextureAssets.LockOnCursor = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\LockOn_Cursor", mode);
      TextureAssets.Rain = AssetInitializer.LoadAsset<Texture2D>("Images\\Rain", mode);
      for (int index = 0; index < 301; ++index)
        TextureAssets.GlowMask[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Glow_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.HighlightMask.Length; ++index)
      {
        if (TileID.Sets.HasOutlines[index])
          TextureAssets.HighlightMask[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Misc\\TileOutlines\\Tiles_" + (object) index, mode);
      }
      for (int index = 0; index < 212; ++index)
        TextureAssets.Extra[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Extra_" + (object) index, mode);
      for (int index = 0; index < 4; ++index)
        TextureAssets.Coin[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Coin_" + (object) index, mode);
      TextureAssets.MagicPixel = AssetInitializer.LoadAsset<Texture2D>("Images\\MagicPixel", mode);
      TextureAssets.SettingsPanel = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Settings_Panel", mode);
      TextureAssets.SettingsPanel2 = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Settings_Panel_2", mode);
      for (int index = 0; index < TextureAssets.XmasTree.Length; ++index)
        TextureAssets.XmasTree[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Xmas_" + (object) index, mode);
      for (int index = 0; index < 6; ++index)
        TextureAssets.Clothes[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Clothes_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.Flames.Length; ++index)
        TextureAssets.Flames[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Flame_" + (object) index, mode);
      for (int index = 0; index < 8; ++index)
        TextureAssets.MapIcon[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Map_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.Underworld.Length; ++index)
        TextureAssets.Underworld[index] = AssetInitializer.LoadAsset<Texture2D>("Images/Backgrounds/Underworld " + (object) index, (AssetRequestMode) 0);
      TextureAssets.Dest[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Dest1", mode);
      TextureAssets.Dest[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Dest2", mode);
      TextureAssets.Dest[2] = AssetInitializer.LoadAsset<Texture2D>("Images\\Dest3", mode);
      TextureAssets.Actuator = AssetInitializer.LoadAsset<Texture2D>("Images\\Actuator", mode);
      TextureAssets.Wire = AssetInitializer.LoadAsset<Texture2D>("Images\\Wires", mode);
      TextureAssets.Wire2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Wires2", mode);
      TextureAssets.Wire3 = AssetInitializer.LoadAsset<Texture2D>("Images\\Wires3", mode);
      TextureAssets.Wire4 = AssetInitializer.LoadAsset<Texture2D>("Images\\Wires4", mode);
      TextureAssets.WireNew = AssetInitializer.LoadAsset<Texture2D>("Images\\WiresNew", mode);
      TextureAssets.FlyingCarpet = AssetInitializer.LoadAsset<Texture2D>("Images\\FlyingCarpet", mode);
      TextureAssets.Hb1 = AssetInitializer.LoadAsset<Texture2D>("Images\\HealthBar1", mode);
      TextureAssets.Hb2 = AssetInitializer.LoadAsset<Texture2D>("Images\\HealthBar2", mode);
      for (int index = 0; index < TextureAssets.NpcHead.Length; ++index)
        TextureAssets.NpcHead[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\NPC_Head_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.NpcHeadBoss.Length; ++index)
        TextureAssets.NpcHeadBoss[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\NPC_Head_Boss_" + (object) index, mode);
      for (int index = 1; index < TextureAssets.BackPack.Length; ++index)
        TextureAssets.BackPack[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\BackPack_" + (object) index, mode);
      for (int index = 1; index < 323; ++index)
        TextureAssets.Buff[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Buff_" + (object) index, mode);
      Main.instance.LoadBackground(0);
      Main.instance.LoadBackground(49);
      TextureAssets.MinecartMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Minecart", mode);
      for (int index = 0; index < TextureAssets.RudolphMount.Length; ++index)
        TextureAssets.RudolphMount[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Rudolph_" + (object) index, mode);
      TextureAssets.BunnyMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Bunny", mode);
      TextureAssets.PigronMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Pigron", mode);
      TextureAssets.SlimeMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Slime", mode);
      TextureAssets.TurtleMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Turtle", mode);
      TextureAssets.UnicornMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Unicorn", mode);
      TextureAssets.BasiliskMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Basilisk", mode);
      TextureAssets.MinecartMechMount[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_MinecartMech", mode);
      TextureAssets.MinecartMechMount[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_MinecartMechGlow", mode);
      TextureAssets.CuteFishronMount[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_CuteFishron1", mode);
      TextureAssets.CuteFishronMount[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_CuteFishron2", mode);
      TextureAssets.MinecartWoodMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_MinecartWood", mode);
      TextureAssets.DesertMinecartMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_MinecartDesert", mode);
      TextureAssets.FishMinecartMount = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_MinecartMineCarp", mode);
      TextureAssets.BeeMount[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Bee", mode);
      TextureAssets.BeeMount[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_BeeWings", mode);
      TextureAssets.UfoMount[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_UFO", mode);
      TextureAssets.UfoMount[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_UFOGlow", mode);
      TextureAssets.DrillMount[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_DrillRing", mode);
      TextureAssets.DrillMount[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_DrillSeat", mode);
      TextureAssets.DrillMount[2] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_DrillDiode", mode);
      TextureAssets.DrillMount[3] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Glow_DrillRing", mode);
      TextureAssets.DrillMount[4] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Glow_DrillSeat", mode);
      TextureAssets.DrillMount[5] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Glow_DrillDiode", mode);
      TextureAssets.ScutlixMount[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_Scutlix", mode);
      TextureAssets.ScutlixMount[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_ScutlixEyes", mode);
      TextureAssets.ScutlixMount[2] = AssetInitializer.LoadAsset<Texture2D>("Images\\Mount_ScutlixEyeGlow", mode);
      for (int index = 0; index < TextureAssets.Gem.Length; ++index)
        TextureAssets.Gem[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Gem_" + (object) index, mode);
      for (int index = 0; index < 37; ++index)
        TextureAssets.Cloud[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Cloud_" + (object) index, mode);
      for (int index = 0; index < 4; ++index)
        TextureAssets.Star[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Star_" + (object) index, mode);
      for (int index = 0; index < 13; ++index)
      {
        TextureAssets.Liquid[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Liquid_" + (object) index, mode);
        TextureAssets.LiquidSlope[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\LiquidSlope_" + (object) index, mode);
      }
      Main.instance.waterfallManager.LoadContent();
      TextureAssets.NpcToggle[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\House_1", mode);
      TextureAssets.NpcToggle[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\House_2", mode);
      TextureAssets.HbLock[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Lock_0", mode);
      TextureAssets.HbLock[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Lock_1", mode);
      TextureAssets.blockReplaceIcon[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\BlockReplace_0", mode);
      TextureAssets.blockReplaceIcon[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\BlockReplace_1", mode);
      TextureAssets.Grid = AssetInitializer.LoadAsset<Texture2D>("Images\\Grid", mode);
      TextureAssets.Trash = AssetInitializer.LoadAsset<Texture2D>("Images\\Trash", mode);
      TextureAssets.Cd = AssetInitializer.LoadAsset<Texture2D>("Images\\CoolDown", mode);
      TextureAssets.Logo = AssetInitializer.LoadAsset<Texture2D>("Images\\Logo", mode);
      TextureAssets.Logo2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Logo2", mode);
      TextureAssets.Logo3 = AssetInitializer.LoadAsset<Texture2D>("Images\\Logo3", mode);
      TextureAssets.Logo4 = AssetInitializer.LoadAsset<Texture2D>("Images\\Logo4", mode);
      TextureAssets.Dust = AssetInitializer.LoadAsset<Texture2D>("Images\\Dust", mode);
      TextureAssets.Sun = AssetInitializer.LoadAsset<Texture2D>("Images\\Sun", mode);
      TextureAssets.Sun2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Sun2", mode);
      TextureAssets.Sun3 = AssetInitializer.LoadAsset<Texture2D>("Images\\Sun3", mode);
      TextureAssets.BlackTile = AssetInitializer.LoadAsset<Texture2D>("Images\\Black_Tile", mode);
      TextureAssets.Heart = AssetInitializer.LoadAsset<Texture2D>("Images\\Heart", mode);
      TextureAssets.Heart2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Heart2", mode);
      TextureAssets.Bubble = AssetInitializer.LoadAsset<Texture2D>("Images\\Bubble", mode);
      TextureAssets.Flame = AssetInitializer.LoadAsset<Texture2D>("Images\\Flame", mode);
      TextureAssets.Mana = AssetInitializer.LoadAsset<Texture2D>("Images\\Mana", mode);
      for (int index = 0; index < TextureAssets.Cursors.Length; ++index)
        TextureAssets.Cursors[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Cursor_" + (object) index, mode);
      TextureAssets.CursorRadial = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Radial", mode);
      TextureAssets.Ninja = AssetInitializer.LoadAsset<Texture2D>("Images\\Ninja", mode);
      TextureAssets.AntLion = AssetInitializer.LoadAsset<Texture2D>("Images\\AntlionBody", mode);
      TextureAssets.SpikeBase = AssetInitializer.LoadAsset<Texture2D>("Images\\Spike_Base", mode);
      TextureAssets.Wood[0] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_0", mode);
      TextureAssets.Wood[1] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_1", mode);
      TextureAssets.Wood[2] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_2", mode);
      TextureAssets.Wood[3] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_3", mode);
      TextureAssets.Wood[4] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_4", mode);
      TextureAssets.Wood[5] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_5", mode);
      TextureAssets.Wood[6] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tiles_5_6", mode);
      TextureAssets.SmileyMoon = AssetInitializer.LoadAsset<Texture2D>("Images\\Moon_Smiley", mode);
      TextureAssets.PumpkinMoon = AssetInitializer.LoadAsset<Texture2D>("Images\\Moon_Pumpkin", mode);
      TextureAssets.SnowMoon = AssetInitializer.LoadAsset<Texture2D>("Images\\Moon_Snow", mode);
      for (int index = 0; index < TextureAssets.Moon.Length; ++index)
        TextureAssets.Moon[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Moon_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.TreeTop.Length; ++index)
        TextureAssets.TreeTop[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tree_Tops_" + (object) index, mode);
      for (int index = 0; index < TextureAssets.TreeBranch.Length; ++index)
        TextureAssets.TreeBranch[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Tree_Branches_" + (object) index, mode);
      TextureAssets.ShroomCap = AssetInitializer.LoadAsset<Texture2D>("Images\\Shroom_Tops", mode);
      TextureAssets.InventoryBack = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back", mode);
      TextureAssets.InventoryBack2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back2", mode);
      TextureAssets.InventoryBack3 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back3", mode);
      TextureAssets.InventoryBack4 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back4", mode);
      TextureAssets.InventoryBack5 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back5", mode);
      TextureAssets.InventoryBack6 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back6", mode);
      TextureAssets.InventoryBack7 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back7", mode);
      TextureAssets.InventoryBack8 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back8", mode);
      TextureAssets.InventoryBack9 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back9", mode);
      TextureAssets.InventoryBack10 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back10", mode);
      TextureAssets.InventoryBack11 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back11", mode);
      TextureAssets.InventoryBack12 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back12", mode);
      TextureAssets.InventoryBack13 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back13", mode);
      TextureAssets.InventoryBack14 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back14", mode);
      TextureAssets.InventoryBack15 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back15", mode);
      TextureAssets.InventoryBack16 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back16", mode);
      TextureAssets.InventoryBack17 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back17", mode);
      TextureAssets.InventoryBack18 = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Back18", mode);
      TextureAssets.HairStyleBack = AssetInitializer.LoadAsset<Texture2D>("Images\\HairStyleBack", mode);
      TextureAssets.ClothesStyleBack = AssetInitializer.LoadAsset<Texture2D>("Images\\ClothesStyleBack", mode);
      TextureAssets.InventoryTickOff = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Tick_Off", mode);
      TextureAssets.InventoryTickOn = AssetInitializer.LoadAsset<Texture2D>("Images\\Inventory_Tick_On", mode);
      TextureAssets.TextBack = AssetInitializer.LoadAsset<Texture2D>("Images\\Text_Back", mode);
      TextureAssets.Chat = AssetInitializer.LoadAsset<Texture2D>("Images\\Chat", mode);
      TextureAssets.Chat2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chat2", mode);
      TextureAssets.ChatBack = AssetInitializer.LoadAsset<Texture2D>("Images\\Chat_Back", mode);
      TextureAssets.Team = AssetInitializer.LoadAsset<Texture2D>("Images\\Team", mode);
      PlayerDataInitializer.Load();
      TextureAssets.Chaos = AssetInitializer.LoadAsset<Texture2D>("Images\\Chaos", mode);
      TextureAssets.EyeLaser = AssetInitializer.LoadAsset<Texture2D>("Images\\Eye_Laser", mode);
      TextureAssets.BoneEyes = AssetInitializer.LoadAsset<Texture2D>("Images\\Bone_Eyes", mode);
      TextureAssets.BoneLaser = AssetInitializer.LoadAsset<Texture2D>("Images\\Bone_Laser", mode);
      TextureAssets.LightDisc = AssetInitializer.LoadAsset<Texture2D>("Images\\Light_Disc", mode);
      TextureAssets.Confuse = AssetInitializer.LoadAsset<Texture2D>("Images\\Confuse", mode);
      TextureAssets.Probe = AssetInitializer.LoadAsset<Texture2D>("Images\\Probe", mode);
      TextureAssets.SunOrb = AssetInitializer.LoadAsset<Texture2D>("Images\\SunOrb", mode);
      TextureAssets.SunAltar = AssetInitializer.LoadAsset<Texture2D>("Images\\SunAltar", mode);
      TextureAssets.XmasLight = AssetInitializer.LoadAsset<Texture2D>("Images\\XmasLight", mode);
      TextureAssets.Beetle = AssetInitializer.LoadAsset<Texture2D>("Images\\BeetleOrb", mode);
      for (int index = 0; index < 17; ++index)
        TextureAssets.Chains[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\Chains_" + (object) index, mode);
      TextureAssets.Chain20 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain20", mode);
      TextureAssets.FishingLine = AssetInitializer.LoadAsset<Texture2D>("Images\\FishingLine", mode);
      TextureAssets.Chain = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain", mode);
      TextureAssets.Chain2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain2", mode);
      TextureAssets.Chain3 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain3", mode);
      TextureAssets.Chain4 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain4", mode);
      TextureAssets.Chain5 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain5", mode);
      TextureAssets.Chain6 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain6", mode);
      TextureAssets.Chain7 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain7", mode);
      TextureAssets.Chain8 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain8", mode);
      TextureAssets.Chain9 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain9", mode);
      TextureAssets.Chain10 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain10", mode);
      TextureAssets.Chain11 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain11", mode);
      TextureAssets.Chain12 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain12", mode);
      TextureAssets.Chain13 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain13", mode);
      TextureAssets.Chain14 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain14", mode);
      TextureAssets.Chain15 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain15", mode);
      TextureAssets.Chain16 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain16", mode);
      TextureAssets.Chain17 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain17", mode);
      TextureAssets.Chain18 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain18", mode);
      TextureAssets.Chain19 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain19", mode);
      TextureAssets.Chain20 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain20", mode);
      TextureAssets.Chain21 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain21", mode);
      TextureAssets.Chain22 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain22", mode);
      TextureAssets.Chain23 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain23", mode);
      TextureAssets.Chain24 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain24", mode);
      TextureAssets.Chain25 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain25", mode);
      TextureAssets.Chain26 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain26", mode);
      TextureAssets.Chain27 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain27", mode);
      TextureAssets.Chain28 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain28", mode);
      TextureAssets.Chain29 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain29", mode);
      TextureAssets.Chain30 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain30", mode);
      TextureAssets.Chain31 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain31", mode);
      TextureAssets.Chain32 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain32", mode);
      TextureAssets.Chain33 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain33", mode);
      TextureAssets.Chain34 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain34", mode);
      TextureAssets.Chain35 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain35", mode);
      TextureAssets.Chain36 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain36", mode);
      TextureAssets.Chain37 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain37", mode);
      TextureAssets.Chain38 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain38", mode);
      TextureAssets.Chain39 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain39", mode);
      TextureAssets.Chain40 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain40", mode);
      TextureAssets.Chain41 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain41", mode);
      TextureAssets.Chain42 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain42", mode);
      TextureAssets.Chain43 = AssetInitializer.LoadAsset<Texture2D>("Images\\Chain43", mode);
      TextureAssets.EyeLaserSmall = AssetInitializer.LoadAsset<Texture2D>("Images\\Eye_Laser_Small", mode);
      TextureAssets.BoneArm = AssetInitializer.LoadAsset<Texture2D>("Images\\Arm_Bone", mode);
      TextureAssets.PumpkingArm = AssetInitializer.LoadAsset<Texture2D>("Images\\PumpkingArm", mode);
      TextureAssets.PumpkingCloak = AssetInitializer.LoadAsset<Texture2D>("Images\\PumpkingCloak", mode);
      TextureAssets.BoneArm2 = AssetInitializer.LoadAsset<Texture2D>("Images\\Arm_Bone_2", mode);
      for (int index = 1; index < TextureAssets.GemChain.Length; ++index)
        TextureAssets.GemChain[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\GemChain_" + (object) index, mode);
      for (int index = 1; index < TextureAssets.Golem.Length; ++index)
        TextureAssets.Golem[index] = AssetInitializer.LoadAsset<Texture2D>("Images\\GolemLights" + (object) index, mode);
      TextureAssets.GolfSwingBarFill = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\GolfSwingBarFill", mode);
      TextureAssets.GolfSwingBarPanel = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\GolfSwingBarPanel", mode);
      TextureAssets.SpawnPoint = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\SpawnPoint", mode);
      TextureAssets.SpawnBed = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\SpawnBed", mode);
      TextureAssets.MapPing = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\MapPing", mode);
      TextureAssets.GolfBallArrow = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\GolfBall_Arrow", mode);
      TextureAssets.GolfBallArrowShadow = AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\GolfBall_Arrow_Shadow", mode);
      TextureAssets.GolfBallOutline = AssetInitializer.LoadAsset<Texture2D>("Images\\Misc\\GolfBallOutline", mode);
      AssetInitializer.LoadMinimapFrames(mode);
      AssetInitializer.LoadPlayerResourceSets(mode);
      Main.AchievementAdvisor.LoadContent();
    }

    private static void LoadMinimapFrames(AssetRequestMode mode)
    {
      float num1 = 2f;
      float num2 = 6f;
      AssetInitializer.LoadMinimap("Default", new Vector2(-8f, -15f), new Vector2(148f + num1, 234f + num2), new Vector2(200f + num1, 234f + num2), new Vector2(174f + num1, 234f + num2), mode);
      AssetInitializer.LoadMinimap("Golden", new Vector2(-10f, -10f), new Vector2(136f, 248f), new Vector2(96f, 248f), new Vector2(116f, 248f), mode);
      AssetInitializer.LoadMinimap("Remix", new Vector2(-10f, -10f), new Vector2(200f, 234f), new Vector2(148f, 234f), new Vector2(174f, 234f), mode);
      AssetInitializer.LoadMinimap("Sticks", new Vector2(-10f, -10f), new Vector2(148f, 234f), new Vector2(200f, 234f), new Vector2(174f, 234f), mode);
      AssetInitializer.LoadMinimap("StoneGold", new Vector2(-15f, -15f), new Vector2(220f, 244f), new Vector2(244f, 188f), new Vector2(244f, 216f), mode);
      AssetInitializer.LoadMinimap("TwigLeaf", new Vector2(-20f, -20f), new Vector2(206f, 242f), new Vector2(162f, 242f), new Vector2(184f, 242f), mode);
      AssetInitializer.LoadMinimap("Leaf", new Vector2(-20f, -20f), new Vector2(212f, 244f), new Vector2(168f, 246f), new Vector2(190f, 246f), mode);
      AssetInitializer.LoadMinimap("Retro", new Vector2(-10f, -10f), new Vector2(150f, 236f), new Vector2(202f, 236f), new Vector2(176f, 236f), mode);
      AssetInitializer.LoadMinimap("Valkyrie", new Vector2(-10f, -10f), new Vector2(154f, 242f), new Vector2(206f, 240f), new Vector2(180f, 244f), mode);
      string frameName = Main.Configuration.Get<string>("MinimapFrame", "Default");
      Main.ActiveMinimapFrame = Main.MinimapFrames.FirstOrDefault<KeyValuePair<string, MinimapFrame>>((Func<KeyValuePair<string, MinimapFrame>, bool>) (pair => pair.Key == frameName)).Value;
      if (Main.ActiveMinimapFrame == null)
        Main.ActiveMinimapFrame = Main.MinimapFrames.Values.First<MinimapFrame>();
      Main.Configuration.OnSave += new Action<Preferences>(AssetInitializer.Configuration_OnSave_MinimapFrame);
    }

    private static void Configuration_OnSave_MinimapFrame(Preferences obj)
    {
      string str = Main.MinimapFrames.FirstOrDefault<KeyValuePair<string, MinimapFrame>>((Func<KeyValuePair<string, MinimapFrame>, bool>) (pair => pair.Value == Main.ActiveMinimapFrame)).Key ?? "Default";
      obj.Put("MinimapFrame", (object) str);
    }

    private static void LoadMinimap(
      string name,
      Vector2 frameOffset,
      Vector2 resetPosition,
      Vector2 zoomInPosition,
      Vector2 zoomOutPosition,
      AssetRequestMode mode)
    {
      MinimapFrame minimapFrame = new MinimapFrame(AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Minimap\\" + name + "\\MinimapFrame", mode), frameOffset);
      minimapFrame.SetResetButton(AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Minimap\\" + name + "\\MinimapButton_Reset", mode), resetPosition);
      minimapFrame.SetZoomOutButton(AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Minimap\\" + name + "\\MinimapButton_ZoomOut", mode), zoomOutPosition);
      minimapFrame.SetZoomInButton(AssetInitializer.LoadAsset<Texture2D>("Images\\UI\\Minimap\\" + name + "\\MinimapButton_ZoomIn", mode), zoomInPosition);
      Main.MinimapFrames[name] = minimapFrame;
    }

    private static void LoadPlayerResourceSets(AssetRequestMode mode)
    {
      Main.PlayerResourcesSets["Default"] = (IPlayerResourcesDisplaySet) new ClassicPlayerResourcesDisplaySet();
      Main.PlayerResourcesSets["New"] = (IPlayerResourcesDisplaySet) new FancyClassicPlayerResourcesDisplaySet("FancyClassic", mode);
      Main.PlayerResourcesSets["HorizontalBars"] = (IPlayerResourcesDisplaySet) new HorizontalBarsPlayerReosurcesDisplaySet("HorizontalBars", mode);
      string frameName = Main.Configuration.Get<string>("PlayerResourcesSet", "New");
      Main.ActivePlayerResourcesSet = Main.PlayerResourcesSets.FirstOrDefault<KeyValuePair<string, IPlayerResourcesDisplaySet>>((Func<KeyValuePair<string, IPlayerResourcesDisplaySet>, bool>) (pair => pair.Key == frameName)).Value;
      if (Main.ActivePlayerResourcesSet == null)
        Main.ActivePlayerResourcesSet = Main.PlayerResourcesSets.Values.First<IPlayerResourcesDisplaySet>();
      Main.Configuration.OnSave += new Action<Preferences>(AssetInitializer.Configuration_OnSave_PlayerResourcesSet);
    }

    private static void Configuration_OnSave_PlayerResourcesSet(Preferences obj)
    {
      string str = Main.PlayerResourcesSets.FirstOrDefault<KeyValuePair<string, IPlayerResourcesDisplaySet>>((Func<KeyValuePair<string, IPlayerResourcesDisplaySet>, bool>) (pair => pair.Value == Main.ActivePlayerResourcesSet)).Key ?? "New";
      obj.Put("PlayerResourcesSet", (object) str);
    }

    private static Asset<T> LoadAsset<T>(string assetName, AssetRequestMode mode) where T : class => Main.Assets.Request<T>(assetName, mode);
  }
}
