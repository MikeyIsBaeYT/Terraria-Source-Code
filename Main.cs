// Decompiled with JetBrains decompiler
// Type: Terraria.Main
// Assembly: Terraria, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
// MVID: FF258283-FE37-4E8A-A035-CB1E6DC74C3C
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Terraria
{
  public class Main : Game
  {
    private const int MF_BYPOSITION = 1024;
    public const int sectionWidth = 200;
    public const int sectionHeight = 150;
    public const int maxTileSets = 150;
    public const int maxWallTypes = 32;
    public const int maxBackgrounds = 32;
    public const int maxDust = 2000;
    public const int maxCombatText = 100;
    public const int maxItemText = 20;
    public const int maxPlayers = 255;
    public const int maxChests = 1000;
    public const int maxItemTypes = 604;
    public const int maxItems = 200;
    public const int maxBuffs = 41;
    public const int maxProjectileTypes = 112;
    public const int maxProjectiles = 1000;
    public const int maxNPCTypes = 147;
    public const int maxNPCs = 200;
    public const int maxGoreTypes = 160;
    public const int maxGore = 200;
    public const int maxInventory = 48;
    public const int maxItemSounds = 37;
    public const int maxNPCHitSounds = 11;
    public const int maxNPCKilledSounds = 15;
    public const int maxLiquidTypes = 2;
    public const int maxMusic = 14;
    public const int numArmorHead = 45;
    public const int numArmorBody = 26;
    public const int numArmorLegs = 25;
    public const double dayLength = 54000.0;
    public const double nightLength = 32400.0;
    public const int maxStars = 130;
    public const int maxStarTypes = 5;
    public const int maxClouds = 100;
    public const int maxCloudTypes = 4;
    public const int maxHair = 36;
    public static int curRelease = 39;
    public static string versionNumber = "v1.1.2";
    public static string versionNumber2 = "v1.1.2";
    public static bool skipMenu = false;
    public static bool verboseNetplay = false;
    public static bool stopTimeOuts = false;
    public static bool showSpam = false;
    public static bool showItemOwner = false;
    public static int oldTempLightCount = 0;
    public static int musicBox = -1;
    public static int musicBox2 = -1;
    public static bool cEd = false;
    public static float upTimer;
    public static float upTimerMax;
    public static float upTimerMaxDelay;
    public static float[] drawTimer = new float[10];
    public static float[] drawTimerMax = new float[10];
    public static float[] drawTimerMaxDelay = new float[10];
    public static float[] renderTimer = new float[10];
    public static float[] lightTimer = new float[10];
    public static bool drawDiag = false;
    public static bool drawRelease = false;
    public static bool renderNow = false;
    public static bool drawToScreen = false;
    public static bool targetSet = false;
    public static int mouseX;
    public static int mouseY;
    public static bool mouseLeft;
    public static bool mouseRight;
    public static float essScale = 1f;
    public static int essDir = -1;
    public static string debugWords = "";
    public static bool gamePad = false;
    public static bool xMas = false;
    public static int snowDust = 0;
    public static bool chTitle = false;
    public static int keyCount = 0;
    public static string[] keyString = new string[10];
    public static int[] keyInt = new int[10];
    public static bool netDiag = false;
    public static int txData = 0;
    public static int rxData = 0;
    public static int txMsg = 0;
    public static int rxMsg = 0;
    public static int maxMsg = 62;
    public static int[] rxMsgType = new int[Main.maxMsg];
    public static int[] rxDataType = new int[Main.maxMsg];
    public static int[] txMsgType = new int[Main.maxMsg];
    public static int[] txDataType = new int[Main.maxMsg];
    public static float uCarry = 0.0f;
    public static bool drawSkip = false;
    public static int fpsCount = 0;
    public static Stopwatch fpsTimer = new Stopwatch();
    public static Stopwatch updateTimer = new Stopwatch();
    public bool gammaTest;
    public static bool showSplash = true;
    public static bool ignoreErrors = true;
    public static string defaultIP = "";
    public static int dayRate = 1;
    public static int maxScreenW = 1920;
    public static int minScreenW = 800;
    public static int maxScreenH = 1200;
    public static int minScreenH = 600;
    public static float iS = 1f;
    public static bool render = false;
    public static int qaStyle = 0;
    public static int zoneX = 99;
    public static int zoneY = 87;
    public static float harpNote = 0.0f;
    public static bool[] projHostile = new bool[112];
    public static bool[] pvpBuff = new bool[41];
    public static bool[] debuff = new bool[41];
    public static string[] buffName = new string[41];
    public static string[] buffTip = new string[41];
    public static int maxMP = 10;
    public static string[] recentWorld = new string[Main.maxMP];
    public static string[] recentIP = new string[Main.maxMP];
    public static int[] recentPort = new int[Main.maxMP];
    public static bool shortRender = true;
    public static bool owBack = true;
    public static int quickBG = 2;
    public static int bgDelay = 0;
    public static int bgStyle = 0;
    public static float[] bgAlpha = new float[10];
    public static float[] bgAlpha2 = new float[10];
    public bool showNPCs;
    public int mouseNPC = -1;
    public static int wof = -1;
    public static int wofT;
    public static int wofB;
    public static int wofF = 0;
    private static int offScreenRange = 200;
    private RenderTarget2D backWaterTarget;
    private RenderTarget2D waterTarget;
    private RenderTarget2D tileTarget;
    private RenderTarget2D blackTarget;
    private RenderTarget2D tile2Target;
    private RenderTarget2D wallTarget;
    private RenderTarget2D backgroundTarget;
    private int firstTileX;
    private int lastTileX;
    private int firstTileY;
    private int lastTileY;
    private double bgParrallax;
    private int bgStart;
    private int bgLoops;
    private int bgStartY;
    private int bgLoopsY;
    private int bgTop;
    public static int renderCount = 99;
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Process tServer = new Process();
    private static Stopwatch saveTime = new Stopwatch();
    public static MouseState mouseState = Mouse.GetState();
    public static MouseState oldMouseState = Mouse.GetState();
    public static KeyboardState keyState = Keyboard.GetState();
    public static Microsoft.Xna.Framework.Color mcColor = new Microsoft.Xna.Framework.Color(125, 125, (int) byte.MaxValue);
    public static Microsoft.Xna.Framework.Color hcColor = new Microsoft.Xna.Framework.Color(200, 125, (int) byte.MaxValue);
    public static Microsoft.Xna.Framework.Color bgColor;
    public static bool mouseHC = false;
    public static string chestText = "Chest";
    public static bool craftingHide = false;
    public static bool armorHide = false;
    public static float craftingAlpha = 1f;
    public static float armorAlpha = 1f;
    public static float[] buffAlpha = new float[41];
    public static Item trashItem = new Item();
    public static bool hardMode = false;
    public float chestLootScale = 1f;
    public bool chestLootHover;
    public float chestStackScale = 1f;
    public bool chestStackHover;
    public float chestDepositScale = 1f;
    public bool chestDepositHover;
    public static bool drawScene = false;
    public static Vector2 sceneWaterPos = new Vector2();
    public static Vector2 sceneTilePos = new Vector2();
    public static Vector2 sceneTile2Pos = new Vector2();
    public static Vector2 sceneWallPos = new Vector2();
    public static Vector2 sceneBackgroundPos = new Vector2();
    public static bool maxQ = true;
    public static float gfxQuality = 1f;
    public static float gfxRate = 0.01f;
    public int DiscoStyle;
    public static int DiscoR = (int) byte.MaxValue;
    public static int DiscoB = 0;
    public static int DiscoG = 0;
    public static int teamCooldown = 0;
    public static int teamCooldownLen = 300;
    public static bool gamePaused = false;
    public static int updateTime = 0;
    public static int drawTime = 0;
    public static int uCount = 0;
    public static int updateRate = 0;
    public static int frameRate = 0;
    public static bool RGBRelease = false;
    public static bool qRelease = false;
    public static bool netRelease = false;
    public static bool frameRelease = false;
    public static bool showFrameRate = false;
    public static int magmaBGFrame = 0;
    public static int magmaBGFrameCounter = 0;
    public static int saveTimer = 0;
    public static bool autoJoin = false;
    public static bool serverStarting = false;
    public static float leftWorld = 0.0f;
    public static float rightWorld = 134400f;
    public static float topWorld = 0.0f;
    public static float bottomWorld = 38400f;
    public static int maxTilesX = (int) Main.rightWorld / 16 + 1;
    public static int maxTilesY = (int) Main.bottomWorld / 16 + 1;
    public static int maxSectionsX = Main.maxTilesX / 200;
    public static int maxSectionsY = Main.maxTilesY / 150;
    public static int numDust = 2000;
    public static int maxNetPlayers = (int) byte.MaxValue;
    public static string[] chrName = new string[147];
    public static int worldRate = 1;
    public static float caveParrallax = 1f;
    public static string[] tileName = new string[150];
    public static int dungeonX;
    public static int dungeonY;
    public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
    public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
    public static bool dedServ = false;
    public static int spamCount = 0;
    public static int curMusic = 0;
    public int newMusic;
    public static bool showItemText = true;
    public static bool autoSave = true;
    public static string buffString = "";
    public static string libPath = "";
    public static int lo = 0;
    public static int LogoA = (int) byte.MaxValue;
    public static int LogoB = 0;
    public static bool LogoT = false;
    public static string statusText = "";
    public static string worldName = "";
    public static int worldID;
    public static int background = 0;
    public static Microsoft.Xna.Framework.Color tileColor;
    public static double worldSurface;
    public static double rockLayer;
    public static Microsoft.Xna.Framework.Color[] teamColor = new Microsoft.Xna.Framework.Color[5];
    public static bool dayTime = true;
    public static double time = 13500.0;
    public static int moonPhase = 0;
    public static short sunModY = 0;
    public static short moonModY = 0;
    public static bool grabSky = false;
    public static bool bloodMoon = false;
    public static int checkForSpawns = 0;
    public static int helpText = 0;
    public static bool autoGen = false;
    public static bool autoPause = false;
    public static int[] projFrames = new int[112];
    public static float demonTorch = 1f;
    public static int demonTorchDir = 1;
    public static int numStars;
    public static int cloudLimit = 100;
    public static int numClouds = Main.cloudLimit;
    public static float windSpeed = 0.0f;
    public static float windSpeedSpeed = 0.0f;
    public static Cloud[] cloud = new Cloud[100];
    public static bool resetClouds = true;
    public static int sandTiles;
    public static int evilTiles;
    public static int snowTiles;
    public static int holyTiles;
    public static int meteorTiles;
    public static int jungleTiles;
    public static int dungeonTiles;
    public static int fadeCounter = 0;
    public static float invAlpha = 1f;
    public static float invDir = 1f;
    [ThreadStatic]
    public static Random rand;
    public static Texture2D[] bannerTexture = new Texture2D[3];
    public static Texture2D[] npcHeadTexture = new Texture2D[12];
    public static Texture2D[] destTexture = new Texture2D[3];
    public static Texture2D[] wingsTexture = new Texture2D[3];
    public static Texture2D[] armorHeadTexture = new Texture2D[45];
    public static Texture2D[] armorBodyTexture = new Texture2D[26];
    public static Texture2D[] femaleBodyTexture = new Texture2D[26];
    public static Texture2D[] armorArmTexture = new Texture2D[26];
    public static Texture2D[] armorLegTexture = new Texture2D[25];
    public static Texture2D timerTexture;
    public static Texture2D reforgeTexture;
    public static Texture2D wallOutlineTexture;
    public static Texture2D wireTexture;
    public static Texture2D gridTexture;
    public static Texture2D lightDiscTexture;
    public static Texture2D MusicBoxTexture;
    public static Texture2D EyeLaserTexture;
    public static Texture2D BoneEyesTexture;
    public static Texture2D BoneLaserTexture;
    public static Texture2D trashTexture;
    public static Texture2D chainTexture;
    public static Texture2D probeTexture;
    public static Texture2D confuseTexture;
    public static Texture2D chain2Texture;
    public static Texture2D chain3Texture;
    public static Texture2D chain4Texture;
    public static Texture2D chain5Texture;
    public static Texture2D chain6Texture;
    public static Texture2D chain7Texture;
    public static Texture2D chain8Texture;
    public static Texture2D chain9Texture;
    public static Texture2D chain10Texture;
    public static Texture2D chain11Texture;
    public static Texture2D chain12Texture;
    public static Texture2D chaosTexture;
    public static Texture2D cdTexture;
    public static Texture2D wofTexture;
    public static Texture2D boneArmTexture;
    public static Texture2D boneArm2Texture;
    public static Texture2D[] npcToggleTexture = new Texture2D[2];
    public static Texture2D[] HBLockTexture = new Texture2D[2];
    public static Texture2D[] buffTexture = new Texture2D[41];
    public static Texture2D[] itemTexture = new Texture2D[604];
    public static Texture2D[] npcTexture = new Texture2D[147];
    public static Texture2D[] projectileTexture = new Texture2D[112];
    public static Texture2D[] goreTexture = new Texture2D[160];
    public static Texture2D cursorTexture;
    public static Texture2D dustTexture;
    public static Texture2D sunTexture;
    public static Texture2D sun2Texture;
    public static Texture2D moonTexture;
    public static Texture2D[] tileTexture = new Texture2D[150];
    public static Texture2D blackTileTexture;
    public static Texture2D[] wallTexture = new Texture2D[32];
    public static Texture2D[] backgroundTexture = new Texture2D[32];
    public static Texture2D[] cloudTexture = new Texture2D[4];
    public static Texture2D[] starTexture = new Texture2D[5];
    public static Texture2D[] liquidTexture = new Texture2D[2];
    public static Texture2D heartTexture;
    public static Texture2D manaTexture;
    public static Texture2D bubbleTexture;
    public static Texture2D[] treeTopTexture = new Texture2D[5];
    public static Texture2D shroomCapTexture;
    public static Texture2D[] treeBranchTexture = new Texture2D[5];
    public static Texture2D inventoryBackTexture;
    public static Texture2D inventoryBack2Texture;
    public static Texture2D inventoryBack3Texture;
    public static Texture2D inventoryBack4Texture;
    public static Texture2D inventoryBack5Texture;
    public static Texture2D inventoryBack6Texture;
    public static Texture2D inventoryBack7Texture;
    public static Texture2D inventoryBack8Texture;
    public static Texture2D inventoryBack9Texture;
    public static Texture2D inventoryBack10Texture;
    public static Texture2D inventoryBack11Texture;
    public static Texture2D loTexture;
    public static Texture2D logoTexture;
    public static Texture2D logo2Texture;
    public static Texture2D logo3Texture;
    public static Texture2D textBackTexture;
    public static Texture2D chatTexture;
    public static Texture2D chat2Texture;
    public static Texture2D chatBackTexture;
    public static Texture2D teamTexture;
    public static Texture2D reTexture;
    public static Texture2D raTexture;
    public static Texture2D splashTexture;
    public static Texture2D fadeTexture;
    public static Texture2D ninjaTexture;
    public static Texture2D antLionTexture;
    public static Texture2D spikeBaseTexture;
    public static Texture2D ghostTexture;
    public static Texture2D evilCactusTexture;
    public static Texture2D goodCactusTexture;
    public static Texture2D wraithEyeTexture;
    public static Texture2D skinBodyTexture;
    public static Texture2D skinLegsTexture;
    public static Texture2D playerEyeWhitesTexture;
    public static Texture2D playerEyesTexture;
    public static Texture2D playerHandsTexture;
    public static Texture2D playerHands2Texture;
    public static Texture2D playerHeadTexture;
    public static Texture2D playerPantsTexture;
    public static Texture2D playerShirtTexture;
    public static Texture2D playerShoesTexture;
    public static Texture2D playerUnderShirtTexture;
    public static Texture2D playerUnderShirt2Texture;
    public static Texture2D femaleShirt2Texture;
    public static Texture2D femalePantsTexture;
    public static Texture2D femaleShirtTexture;
    public static Texture2D femaleShoesTexture;
    public static Texture2D femaleUnderShirtTexture;
    public static Texture2D femaleUnderShirt2Texture;
    public static Texture2D[] playerHairTexture = new Texture2D[36];
    public static Texture2D[] playerHairAltTexture = new Texture2D[36];
    public static SoundEffect[] soundMech = new SoundEffect[1];
    public static SoundEffectInstance[] soundInstanceMech = new SoundEffectInstance[1];
    public static SoundEffect[] soundDig = new SoundEffect[3];
    public static SoundEffectInstance[] soundInstanceDig = new SoundEffectInstance[3];
    public static SoundEffect[] soundTink = new SoundEffect[3];
    public static SoundEffectInstance[] soundInstanceTink = new SoundEffectInstance[3];
    public static SoundEffect[] soundPlayerHit = new SoundEffect[3];
    public static SoundEffectInstance[] soundInstancePlayerHit = new SoundEffectInstance[3];
    public static SoundEffect[] soundFemaleHit = new SoundEffect[3];
    public static SoundEffectInstance[] soundInstanceFemaleHit = new SoundEffectInstance[3];
    public static SoundEffect soundPlayerKilled;
    public static SoundEffectInstance soundInstancePlayerKilled;
    public static SoundEffect soundGrass;
    public static SoundEffectInstance soundInstanceGrass;
    public static SoundEffect soundGrab;
    public static SoundEffectInstance soundInstanceGrab;
    public static SoundEffect soundPixie;
    public static SoundEffectInstance soundInstancePixie;
    public static SoundEffect[] soundItem = new SoundEffect[38];
    public static SoundEffectInstance[] soundInstanceItem = new SoundEffectInstance[38];
    public static SoundEffect[] soundNPCHit = new SoundEffect[12];
    public static SoundEffectInstance[] soundInstanceNPCHit = new SoundEffectInstance[12];
    public static SoundEffect[] soundNPCKilled = new SoundEffect[16];
    public static SoundEffectInstance[] soundInstanceNPCKilled = new SoundEffectInstance[16];
    public static SoundEffect soundDoorOpen;
    public static SoundEffectInstance soundInstanceDoorOpen;
    public static SoundEffect soundDoorClosed;
    public static SoundEffectInstance soundInstanceDoorClosed;
    public static SoundEffect soundMenuOpen;
    public static SoundEffectInstance soundInstanceMenuOpen;
    public static SoundEffect soundMenuClose;
    public static SoundEffectInstance soundInstanceMenuClose;
    public static SoundEffect soundMenuTick;
    public static SoundEffectInstance soundInstanceMenuTick;
    public static SoundEffect soundShatter;
    public static SoundEffectInstance soundInstanceShatter;
    public static SoundEffect[] soundZombie = new SoundEffect[5];
    public static SoundEffectInstance[] soundInstanceZombie = new SoundEffectInstance[5];
    public static SoundEffect[] soundRoar = new SoundEffect[2];
    public static SoundEffectInstance[] soundInstanceRoar = new SoundEffectInstance[2];
    public static SoundEffect[] soundSplash = new SoundEffect[2];
    public static SoundEffectInstance[] soundInstanceSplash = new SoundEffectInstance[2];
    public static SoundEffect soundDoubleJump;
    public static SoundEffectInstance soundInstanceDoubleJump;
    public static SoundEffect soundRun;
    public static SoundEffectInstance soundInstanceRun;
    public static SoundEffect soundCoins;
    public static SoundEffectInstance soundInstanceCoins;
    public static SoundEffect soundUnlock;
    public static SoundEffectInstance soundInstanceUnlock;
    public static SoundEffect soundChat;
    public static SoundEffectInstance soundInstanceChat;
    public static SoundEffect soundMaxMana;
    public static SoundEffectInstance soundInstanceMaxMana;
    public static SoundEffect soundDrown;
    public static SoundEffectInstance soundInstanceDrown;
    public static AudioEngine engine;
    public static SoundBank soundBank;
    public static WaveBank waveBank;
    public static Cue[] music = new Cue[14];
    public static float[] musicFade = new float[14];
    public static float musicVolume = 0.75f;
    public static float soundVolume = 1f;
    public static SpriteFont fontItemStack;
    public static SpriteFont fontMouseText;
    public static SpriteFont fontDeathText;
    public static SpriteFont[] fontCombatText = new SpriteFont[2];
    public static bool[] tileLighted = new bool[150];
    public static bool[] tileMergeDirt = new bool[150];
    public static bool[] tileCut = new bool[150];
    public static bool[] tileAlch = new bool[150];
    public static int[] tileShine = new int[150];
    public static bool[] tileShine2 = new bool[150];
    public static bool[] wallHouse = new bool[32];
    public static int[] wallBlend = new int[32];
    public static bool[] tileStone = new bool[150];
    public static bool[] tilePick = new bool[150];
    public static bool[] tileAxe = new bool[150];
    public static bool[] tileHammer = new bool[150];
    public static bool[] tileWaterDeath = new bool[150];
    public static bool[] tileLavaDeath = new bool[150];
    public static bool[] tileTable = new bool[150];
    public static bool[] tileBlockLight = new bool[150];
    public static bool[] tileNoSunLight = new bool[150];
    public static bool[] tileDungeon = new bool[150];
    public static bool[] tileSolidTop = new bool[150];
    public static bool[] tileSolid = new bool[150];
    public static bool[] tileNoAttach = new bool[150];
    public static bool[] tileNoFail = new bool[150];
    public static bool[] tileFrameImportant = new bool[150];
    public static int[] backgroundWidth = new int[32];
    public static int[] backgroundHeight = new int[32];
    public static bool tilesLoaded = false;
    public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];
    public static Dust[] dust = new Dust[2001];
    public static Star[] star = new Star[130];
    public static Item[] item = new Item[201];
    public static NPC[] npc = new NPC[201];
    public static Gore[] gore = new Gore[201];
    public static Projectile[] projectile = new Projectile[1001];
    public static CombatText[] combatText = new CombatText[100];
    public static ItemText[] itemText = new ItemText[20];
    public static Chest[] chest = new Chest[1000];
    public static Sign[] sign = new Sign[1000];
    public static Vector2 screenPosition;
    public static Vector2 screenLastPosition;
    public static int screenWidth = 800;
    public static int screenHeight = 600;
    public static int chatLength = 600;
    public static bool chatMode = false;
    public static bool chatRelease = false;
    public static int numChatLines = 7;
    public static string chatText = "";
    public static ChatLine[] chatLine = new ChatLine[Main.numChatLines];
    public static bool inputTextEnter = false;
    public static float[] hotbarScale = new float[10]
    {
      1f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f,
      0.75f
    };
    public static byte mouseTextColor = 0;
    public static int mouseTextColorChange = 1;
    public static bool mouseLeftRelease = false;
    public static bool mouseRightRelease = false;
    public static bool playerInventory = false;
    public static int stackSplit;
    public static int stackCounter = 0;
    public static int stackDelay = 7;
    public static Item mouseItem = new Item();
    public static Item guideItem = new Item();
    public static Item reforgeItem = new Item();
    private static float inventoryScale = 0.75f;
    public static bool hasFocus = true;
    public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];
    public static int[] availableRecipe = new int[Recipe.maxRecipes];
    public static float[] availableRecipeY = new float[Recipe.maxRecipes];
    public static int numAvailableRecipes;
    public static int focusRecipe;
    public static int myPlayer = 0;
    public static Player[] player = new Player[256];
    public static int spawnTileX;
    public static int spawnTileY;
    public static bool npcChatRelease = false;
    public static bool editSign = false;
    public static string signText = "";
    public static string npcChatText = "";
    public static bool npcChatFocus1 = false;
    public static bool npcChatFocus2 = false;
    public static bool npcChatFocus3 = false;
    public static int npcShop = 0;
    public Chest[] shop = new Chest[10];
    public static bool craftGuide = false;
    public static bool reforge = false;
    private static Item toolTip = new Item();
    private static int backSpaceCount = 0;
    public static string motd = "";
    public bool toggleFullscreen;
    private int numDisplayModes;
    private int[] displayWidth = new int[99];
    private int[] displayHeight = new int[99];
    public static bool gameMenu = true;
    public static Player[] loadPlayer = new Player[5];
    public static string[] loadPlayerPath = new string[5];
    private static int numLoadPlayers = 0;
    public static string playerPathName;
    public static string[] loadWorld = new string[999];
    public static string[] loadWorldPath = new string[999];
    private static int numLoadWorlds = 0;
    public static string worldPathName;
    public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + (object) Path.DirectorySeparatorChar + "My Games" + (object) Path.DirectorySeparatorChar + "Terraria";
    public static string WorldPath = Main.SavePath + (object) Path.DirectorySeparatorChar + "Worlds";
    public static string PlayerPath = Main.SavePath + (object) Path.DirectorySeparatorChar + "Players";
    public static string[] itemName = new string[604];
    public static string[] npcName = new string[147];
    private static KeyboardState inputText;
    private static KeyboardState oldInputText;
    public static int invasionType = 0;
    public static double invasionX = 0.0;
    public static int invasionSize = 0;
    public static int invasionDelay = 0;
    public static int invasionWarn = 0;
    public static int[] npcFrameCount = new int[147]
    {
      1,
      2,
      2,
      3,
      6,
      2,
      2,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      2,
      16,
      14,
      16,
      14,
      15,
      16,
      2,
      10,
      1,
      16,
      16,
      16,
      3,
      1,
      15,
      3,
      1,
      3,
      1,
      1,
      16,
      16,
      1,
      1,
      1,
      3,
      3,
      15,
      3,
      7,
      7,
      4,
      5,
      5,
      5,
      3,
      3,
      16,
      6,
      3,
      6,
      6,
      2,
      5,
      3,
      2,
      7,
      7,
      4,
      2,
      8,
      1,
      5,
      1,
      2,
      4,
      16,
      5,
      4,
      4,
      15,
      15,
      15,
      15,
      2,
      4,
      6,
      6,
      18,
      16,
      1,
      1,
      1,
      1,
      1,
      1,
      4,
      3,
      1,
      1,
      1,
      1,
      1,
      1,
      5,
      6,
      7,
      16,
      1,
      1,
      16,
      16,
      12,
      20,
      21,
      1,
      2,
      2,
      3,
      6,
      1,
      1,
      1,
      15,
      4,
      11,
      1,
      14,
      6,
      6,
      3,
      1,
      2,
      2,
      1,
      3,
      4,
      1,
      2,
      1,
      4,
      2,
      1,
      15,
      3,
      16,
      4,
      5,
      7,
      3
    };
    private static bool mouseExit = false;
    private static float exitScale = 0.8f;
    private static bool mouseReforge = false;
    private static float reforgeScale = 0.8f;
    public static Player clientPlayer = new Player();
    public static string getIP = Main.defaultIP;
    public static string getPort = Convert.ToString(Netplay.serverPort);
    public static bool menuMultiplayer = false;
    public static bool menuServer = false;
    public static int netMode = 0;
    public static int timeOut = 120;
    public static int netPlayCounter;
    public static int lastNPCUpdate;
    public static int lastItemUpdate;
    public static int maxNPCUpdates = 5;
    public static int maxItemUpdates = 5;
    public static string cUp = "W";
    public static string cLeft = "A";
    public static string cDown = "S";
    public static string cRight = "D";
    public static string cJump = "Space";
    public static string cThrowItem = "T";
    public static string cInv = "Escape";
    public static string cHeal = "H";
    public static string cMana = "M";
    public static string cBuff = "B";
    public static string cHook = "E";
    public static string cTorch = "LeftShift";
    public static Microsoft.Xna.Framework.Color mouseColor = new Microsoft.Xna.Framework.Color((int) byte.MaxValue, 50, 95);
    public static Microsoft.Xna.Framework.Color cursorColor = Microsoft.Xna.Framework.Color.White;
    public static int cursorColorDirection = 1;
    public static float cursorAlpha = 0.0f;
    public static float cursorScale = 0.0f;
    public static bool signBubble = false;
    public static int signX = 0;
    public static int signY = 0;
    public static bool hideUI = false;
    public static bool releaseUI = false;
    public static bool fixedTiming = false;
    private int splashCounter;
    public static string oldStatusText = "";
    public static bool autoShutdown = false;
    private float logoRotation;
    private float logoRotationDirection = 1f;
    private float logoRotationSpeed = 1f;
    private float logoScale = 1f;
    private float logoScaleDirection = 1f;
    private float logoScaleSpeed = 1f;
    private static int maxMenuItems = 14;
    private float[] menuItemScale = new float[Main.maxMenuItems];
    private int focusMenu = -1;
    private int selectedMenu = -1;
    private int selectedMenu2 = -1;
    private int selectedPlayer;
    private int selectedWorld;
    public static int menuMode = 0;
    private static Item cpItem = new Item();
    private int textBlinkerCount;
    private int textBlinkerState;
    public static string newWorldName = "";
    private static int accSlotCount = 0;
    private Microsoft.Xna.Framework.Color selColor = Microsoft.Xna.Framework.Color.White;
    private int focusColor;
    private int colorDelay;
    private int setKey = -1;
    private int bgScroll;
    public static bool autoPass = false;
    public static int menuFocus = 0;

    [DllImport("User32")]
    private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

    [DllImport("User32")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("User32")]
    private static extern int GetMenuItemCount(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string dllToLoad);

    public static void LoadWorlds()
    {
      Directory.CreateDirectory(Main.WorldPath);
      string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
      int num = files.Length;
      if (!Main.dedServ && num > 5)
        num = 5;
      for (int index = 0; index < num; ++index)
      {
        Main.loadWorldPath[index] = files[index];
        try
        {
          using (FileStream fileStream = new FileStream(Main.loadWorldPath[index], FileMode.Open))
          {
            using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
            {
              binaryReader.ReadInt32();
              Main.loadWorld[index] = binaryReader.ReadString();
              binaryReader.Close();
            }
          }
        }
        catch
        {
          Main.loadWorld[index] = Main.loadWorldPath[index];
        }
      }
      Main.numLoadWorlds = num;
    }

    private static void LoadPlayers()
    {
      Directory.CreateDirectory(Main.PlayerPath);
      string[] files = Directory.GetFiles(Main.PlayerPath, "*.plr");
      int num = files.Length;
      if (num > 5)
        num = 5;
      for (int index = 0; index < 5; ++index)
      {
        Main.loadPlayer[index] = new Player();
        if (index < num)
        {
          Main.loadPlayerPath[index] = files[index];
          Main.loadPlayer[index] = Player.LoadPlayer(Main.loadPlayerPath[index]);
        }
      }
      Main.numLoadPlayers = num;
    }

    protected void OpenRecent()
    {
      try
      {
        if (!File.Exists(Main.SavePath + (object) Path.DirectorySeparatorChar + "servers.dat"))
          return;
        using (FileStream fileStream = new FileStream(Main.SavePath + (object) Path.DirectorySeparatorChar + "servers.dat", FileMode.Open))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
          {
            binaryReader.ReadInt32();
            for (int index = 0; index < 10; ++index)
            {
              Main.recentWorld[index] = binaryReader.ReadString();
              Main.recentIP[index] = binaryReader.ReadString();
              Main.recentPort[index] = binaryReader.ReadInt32();
            }
          }
        }
      }
      catch
      {
      }
    }

    public static void SaveRecent()
    {
      Directory.CreateDirectory(Main.SavePath);
      try
      {
        File.SetAttributes(Main.SavePath + (object) Path.DirectorySeparatorChar + "servers.dat", FileAttributes.Normal);
      }
      catch
      {
      }
      try
      {
        using (FileStream fileStream = new FileStream(Main.SavePath + (object) Path.DirectorySeparatorChar + "servers.dat", FileMode.Create))
        {
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
          {
            binaryWriter.Write(Main.curRelease);
            for (int index = 0; index < 10; ++index)
            {
              binaryWriter.Write(Main.recentWorld[index]);
              binaryWriter.Write(Main.recentIP[index]);
              binaryWriter.Write(Main.recentPort[index]);
            }
          }
        }
      }
      catch
      {
      }
    }

    protected void SaveSettings()
    {
      Directory.CreateDirectory(Main.SavePath);
      try
      {
        File.SetAttributes(Main.SavePath + (object) Path.DirectorySeparatorChar + "config.dat", FileAttributes.Normal);
      }
      catch
      {
      }
      try
      {
        using (FileStream fileStream = new FileStream(Main.SavePath + (object) Path.DirectorySeparatorChar + "config.dat", FileMode.Create))
        {
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream))
          {
            binaryWriter.Write(Main.curRelease);
            binaryWriter.Write(this.graphics.IsFullScreen);
            binaryWriter.Write(Main.mouseColor.R);
            binaryWriter.Write(Main.mouseColor.G);
            binaryWriter.Write(Main.mouseColor.B);
            binaryWriter.Write(Main.soundVolume);
            binaryWriter.Write(Main.musicVolume);
            binaryWriter.Write(Main.cUp);
            binaryWriter.Write(Main.cDown);
            binaryWriter.Write(Main.cLeft);
            binaryWriter.Write(Main.cRight);
            binaryWriter.Write(Main.cJump);
            binaryWriter.Write(Main.cThrowItem);
            binaryWriter.Write(Main.cInv);
            binaryWriter.Write(Main.cHeal);
            binaryWriter.Write(Main.cMana);
            binaryWriter.Write(Main.cBuff);
            binaryWriter.Write(Main.cHook);
            binaryWriter.Write(Main.caveParrallax);
            binaryWriter.Write(Main.fixedTiming);
            binaryWriter.Write(this.graphics.PreferredBackBufferWidth);
            binaryWriter.Write(this.graphics.PreferredBackBufferHeight);
            binaryWriter.Write(Main.autoSave);
            binaryWriter.Write(Main.autoPause);
            binaryWriter.Write(Main.showItemText);
            binaryWriter.Write(Main.cTorch);
            binaryWriter.Write((byte) Lighting.lightMode);
            binaryWriter.Write((byte) Main.qaStyle);
            binaryWriter.Write(Main.owBack);
            binaryWriter.Write((byte) Lang.lang);
            binaryWriter.Close();
          }
        }
      }
      catch
      {
      }
    }

    protected void CheckBunny()
    {
      try
      {
        RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Terraria");
        if (subKey == null || subKey.GetValue("Bunny") == null || !(subKey.GetValue("Bunny").ToString() == "1"))
          return;
        Main.cEd = true;
      }
      catch
      {
        Main.cEd = false;
      }
    }

    protected void OpenSettings()
    {
      try
      {
        if (!File.Exists(Main.SavePath + (object) Path.DirectorySeparatorChar + "config.dat"))
          return;
        using (FileStream fileStream = new FileStream(Main.SavePath + (object) Path.DirectorySeparatorChar + "config.dat", FileMode.Open))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) fileStream))
          {
            int num = binaryReader.ReadInt32();
            bool flag = binaryReader.ReadBoolean();
            Main.mouseColor.R = binaryReader.ReadByte();
            Main.mouseColor.G = binaryReader.ReadByte();
            Main.mouseColor.B = binaryReader.ReadByte();
            Main.soundVolume = binaryReader.ReadSingle();
            Main.musicVolume = binaryReader.ReadSingle();
            Main.cUp = binaryReader.ReadString();
            Main.cDown = binaryReader.ReadString();
            Main.cLeft = binaryReader.ReadString();
            Main.cRight = binaryReader.ReadString();
            Main.cJump = binaryReader.ReadString();
            Main.cThrowItem = binaryReader.ReadString();
            if (num >= 1)
              Main.cInv = binaryReader.ReadString();
            if (num >= 12)
            {
              Main.cHeal = binaryReader.ReadString();
              Main.cMana = binaryReader.ReadString();
              Main.cBuff = binaryReader.ReadString();
            }
            if (num >= 13)
              Main.cHook = binaryReader.ReadString();
            Main.caveParrallax = binaryReader.ReadSingle();
            if (num >= 2)
              Main.fixedTiming = binaryReader.ReadBoolean();
            if (num >= 4)
            {
              this.graphics.PreferredBackBufferWidth = binaryReader.ReadInt32();
              this.graphics.PreferredBackBufferHeight = binaryReader.ReadInt32();
            }
            if (num >= 8)
              Main.autoSave = binaryReader.ReadBoolean();
            if (num >= 9)
              Main.autoPause = binaryReader.ReadBoolean();
            if (num >= 19)
              Main.showItemText = binaryReader.ReadBoolean();
            if (num >= 30)
            {
              Main.cTorch = binaryReader.ReadString();
              Lighting.lightMode = (int) binaryReader.ReadByte();
              Main.qaStyle = (int) binaryReader.ReadByte();
            }
            if (num >= 37)
              Main.owBack = binaryReader.ReadBoolean();
            if (num >= 39)
              Lang.lang = (int) binaryReader.ReadByte();
            binaryReader.Close();
            if (!flag || this.graphics.IsFullScreen)
              return;
            this.graphics.ToggleFullScreen();
          }
        }
      }
      catch
      {
      }
    }

    private static void ErasePlayer(int i)
    {
      try
      {
        File.Delete(Main.loadPlayerPath[i]);
        File.Delete(Main.loadPlayerPath[i] + ".bak");
        Main.LoadPlayers();
      }
      catch
      {
      }
    }

    private static void EraseWorld(int i)
    {
      try
      {
        File.Delete(Main.loadWorldPath[i]);
        File.Delete(Main.loadWorldPath[i] + ".bak");
        Main.LoadWorlds();
      }
      catch
      {
      }
    }

    private static string nextLoadPlayer()
    {
      int num = 1;
      while (true)
      {
        if (File.Exists(Main.PlayerPath + (object) Path.DirectorySeparatorChar + "player" + (object) num + ".plr"))
          ++num;
        else
          break;
      }
      return Main.PlayerPath + (object) Path.DirectorySeparatorChar + "player" + (object) num + ".plr";
    }

    private static string nextLoadWorld()
    {
      int num = 1;
      while (true)
      {
        if (File.Exists(Main.WorldPath + (object) Path.DirectorySeparatorChar + "world" + (object) num + ".wld"))
          ++num;
        else
          break;
      }
      return Main.WorldPath + (object) Path.DirectorySeparatorChar + "world" + (object) num + ".wld";
    }

    public void autoCreate(string newOpt)
    {
      if (newOpt == "0")
        Main.autoGen = false;
      else if (newOpt == "1")
      {
        Main.maxTilesX = 4200;
        Main.maxTilesY = 1200;
        Main.autoGen = true;
      }
      else if (newOpt == "2")
      {
        Main.maxTilesX = 6300;
        Main.maxTilesY = 1800;
        Main.autoGen = true;
      }
      else
      {
        if (!(newOpt == "3"))
          return;
        Main.maxTilesX = 8400;
        Main.maxTilesY = 2400;
        Main.autoGen = true;
      }
    }

    public void NewMOTD(string newMOTD) => Main.motd = newMOTD;

    public void LoadDedConfig(string configPath)
    {
      if (!File.Exists(configPath))
        return;
      using (StreamReader streamReader = new StreamReader(configPath))
      {
        string str1;
        while ((str1 = streamReader.ReadLine()) != null)
        {
          try
          {
            if (str1.Length > 6 && str1.Substring(0, 6).ToLower() == "world=")
              Main.worldPathName = str1.Substring(6);
            if (str1.Length > 5 && str1.Substring(0, 5).ToLower() == "port=")
            {
              string str2 = str1.Substring(5);
              try
              {
                Netplay.serverPort = Convert.ToInt32(str2);
              }
              catch
              {
              }
            }
            if (str1.Length > 11 && str1.Substring(0, 11).ToLower() == "maxplayers=")
            {
              string str3 = str1.Substring(11);
              try
              {
                Main.maxNetPlayers = Convert.ToInt32(str3);
              }
              catch
              {
              }
            }
            if (str1.Length > 11 && str1.Substring(0, 9).ToLower() == "priority=")
            {
              string str4 = str1.Substring(9);
              try
              {
                int int32 = Convert.ToInt32(str4);
                switch (int32)
                {
                  case 0:
                  case 1:
                  case 2:
                  case 3:
                  case 4:
                  case 5:
                    Process currentProcess = Process.GetCurrentProcess();
                    if (int32 == 0)
                    {
                      currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
                      break;
                    }
                    if (int32 == 1)
                    {
                      currentProcess.PriorityClass = ProcessPriorityClass.High;
                      break;
                    }
                    if (int32 == 2)
                    {
                      currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
                      break;
                    }
                    if (int32 == 3)
                    {
                      currentProcess.PriorityClass = ProcessPriorityClass.Normal;
                      break;
                    }
                    if (int32 == 4)
                    {
                      currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                      break;
                    }
                    if (int32 == 5)
                    {
                      currentProcess.PriorityClass = ProcessPriorityClass.Idle;
                      break;
                    }
                    break;
                }
              }
              catch
              {
              }
            }
            if (str1.Length > 9 && str1.Substring(0, 9).ToLower() == "password=")
              Netplay.password = str1.Substring(9);
            if (str1.Length > 5 && str1.Substring(0, 5).ToLower() == "motd=")
              Main.motd = str1.Substring(5);
            if (str1.Length > 5 && str1.Substring(0, 5).ToLower() == "lang=")
              Lang.lang = Convert.ToInt32(str1.Substring(5));
            if (str1.Length >= 10 && str1.Substring(0, 10).ToLower() == "worldpath=")
              Main.WorldPath = str1.Substring(10);
            if (str1.Length >= 10 && str1.Substring(0, 10).ToLower() == "worldname=")
              Main.worldName = str1.Substring(10);
            if (str1.Length > 8 && str1.Substring(0, 8).ToLower() == "banlist=")
              Netplay.banFile = str1.Substring(8);
            if (str1.Length > 11 && str1.Substring(0, 11).ToLower() == "autocreate=")
            {
              string str5 = str1.Substring(11);
              if (str5 == "0")
                Main.autoGen = false;
              else if (str5 == "1")
              {
                Main.maxTilesX = 4200;
                Main.maxTilesY = 1200;
                Main.autoGen = true;
              }
              else if (str5 == "2")
              {
                Main.maxTilesX = 6300;
                Main.maxTilesY = 1800;
                Main.autoGen = true;
              }
              else if (str5 == "3")
              {
                Main.maxTilesX = 8400;
                Main.maxTilesY = 2400;
                Main.autoGen = true;
              }
            }
            if (str1.Length > 7)
            {
              if (str1.Substring(0, 7).ToLower() == "secure=")
              {
                if (str1.Substring(7) == "1")
                  Netplay.spamCheck = true;
              }
            }
          }
          catch
          {
          }
        }
      }
    }

    public void SetNetPlayers(int mPlayers) => Main.maxNetPlayers = mPlayers;

    public void SetWorld(string wrold) => Main.worldPathName = wrold;

    public void SetWorldName(string wrold) => Main.worldName = wrold;

    public void autoShut() => Main.autoShutdown = true;

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public void AutoPass() => Main.autoPass = true;

    public void AutoJoin(string IP)
    {
      Main.defaultIP = IP;
      Main.getIP = IP;
      Netplay.SetIP(Main.defaultIP);
      Main.autoJoin = true;
    }

    public void AutoHost()
    {
      Main.menuMultiplayer = true;
      Main.menuServer = true;
      Main.menuMode = 1;
    }

    public void loadLib(string path)
    {
      Main.libPath = path;
      Main.LoadLibrary(Main.libPath);
    }

    public void DedServ()
    {
      Main.rand = new Random();
      if (Main.autoShutdown)
      {
        string lpWindowName = "terraria" + (object) Main.rand.Next(int.MaxValue);
        Console.Title = lpWindowName;
        IntPtr window = Main.FindWindow((string) null, lpWindowName);
        if (window != IntPtr.Zero)
          Main.ShowWindow(window, 0);
      }
      else
        Console.Title = "Terraria Server " + Main.versionNumber2;
      Main.dedServ = true;
      Main.showSplash = false;
      this.Initialize();
      Lang.setLang();
      for (int Type = 0; Type < 147; ++Type)
      {
        NPC npc = new NPC();
        npc.SetDefaults(Type);
        Main.npcName[Type] = npc.name;
      }
label_77:
      if (Main.worldPathName != null)
        goto label_78;
label_7:
      Main.LoadWorlds();
      bool flag1 = true;
      while (flag1)
      {
        Console.WriteLine("Terraria Server " + Main.versionNumber2);
        Console.WriteLine("");
        for (int index = 0; index < Main.numLoadWorlds; ++index)
          Console.WriteLine((index + 1).ToString() + (object) '\t' + (object) '\t' + Main.loadWorld[index]);
        Console.WriteLine("n" + (object) '\t' + (object) '\t' + "New World");
        Console.WriteLine("d <number>" + (object) '\t' + "Delete World");
        Console.WriteLine("");
        Console.Write("Choose World: ");
        string str1 = Console.ReadLine();
        try
        {
          Console.Clear();
        }
        catch
        {
        }
        if (str1.Length >= 2)
        {
          if (str1.Substring(0, 2).ToLower() == "d ")
          {
            try
            {
              int i = Convert.ToInt32(str1.Substring(2)) - 1;
              if (i < Main.numLoadWorlds)
              {
                Console.WriteLine("Terraria Server " + Main.versionNumber2);
                Console.WriteLine("");
                Console.WriteLine("Really delete " + Main.loadWorld[i] + "?");
                Console.Write("(y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                  Main.EraseWorld(i);
              }
            }
            catch
            {
            }
            try
            {
              Console.Clear();
              continue;
            }
            catch
            {
              continue;
            }
          }
        }
        if (!(str1 == "n"))
        {
          if (!(str1 == "N"))
          {
            try
            {
              int index = Convert.ToInt32(str1) - 1;
              if (index >= 0)
              {
                if (index < Main.numLoadWorlds)
                {
                  bool flag2 = true;
                  while (flag2)
                  {
                    Console.WriteLine("Terraria Server " + Main.versionNumber2);
                    Console.WriteLine("");
                    Console.Write("Max players (press enter for 8): ");
                    string str2 = Console.ReadLine();
                    try
                    {
                      if (str2 == "")
                        str2 = "8";
                      int int32 = Convert.ToInt32(str2);
                      if (int32 <= (int) byte.MaxValue && int32 >= 1)
                      {
                        Main.maxNetPlayers = int32;
                        flag2 = false;
                      }
                      flag2 = false;
                    }
                    catch
                    {
                    }
                    try
                    {
                      Console.Clear();
                    }
                    catch
                    {
                    }
                  }
                  bool flag3 = true;
                  while (flag3)
                  {
                    Console.WriteLine("Terraria Server " + Main.versionNumber2);
                    Console.WriteLine("");
                    Console.Write("Server port (press enter for 7777): ");
                    string str3 = Console.ReadLine();
                    try
                    {
                      if (str3 == "")
                        str3 = "7777";
                      int int32 = Convert.ToInt32(str3);
                      if (int32 <= (int) ushort.MaxValue)
                      {
                        Netplay.serverPort = int32;
                        flag3 = false;
                      }
                    }
                    catch
                    {
                    }
                    try
                    {
                      Console.Clear();
                    }
                    catch
                    {
                    }
                  }
                  Console.WriteLine("Terraria Server " + Main.versionNumber2);
                  Console.WriteLine("");
                  Console.Write("Server password (press enter for none): ");
                  Netplay.password = Console.ReadLine();
                  Main.worldPathName = Main.loadWorldPath[index];
                  flag1 = false;
                  try
                  {
                    Console.Clear();
                    continue;
                  }
                  catch
                  {
                    continue;
                  }
                }
                else
                  continue;
              }
              else
                continue;
            }
            catch
            {
              continue;
            }
          }
        }
        bool flag4 = true;
        while (flag4)
        {
          Console.WriteLine("Terraria Server " + Main.versionNumber2);
          Console.WriteLine("");
          Console.WriteLine("1" + (object) '\t' + "Small");
          Console.WriteLine("2" + (object) '\t' + "Medium");
          Console.WriteLine("3" + (object) '\t' + "Large");
          Console.WriteLine("");
          Console.Write("Choose size: ");
          string str4 = Console.ReadLine();
          try
          {
            switch (Convert.ToInt32(str4))
            {
              case 1:
                Main.maxTilesX = 4200;
                Main.maxTilesY = 1200;
                flag4 = false;
                break;
              case 2:
                Main.maxTilesX = 6300;
                Main.maxTilesY = 1800;
                flag4 = false;
                break;
              case 3:
                Main.maxTilesX = 8400;
                Main.maxTilesY = 2400;
                flag4 = false;
                break;
            }
          }
          catch
          {
          }
          try
          {
            Console.Clear();
          }
          catch
          {
          }
        }
        bool flag5 = true;
        while (flag5)
        {
          Console.WriteLine("Terraria Server " + Main.versionNumber2);
          Console.WriteLine("");
          Console.Write("Enter world name: ");
          Main.newWorldName = Console.ReadLine();
          if (Main.newWorldName != "")
          {
            if (Main.newWorldName != " ")
            {
              if (Main.newWorldName != null)
                flag5 = false;
            }
          }
          try
          {
            Console.Clear();
          }
          catch
          {
          }
        }
        Main.worldName = Main.newWorldName;
        Main.worldPathName = Main.nextLoadWorld();
        Main.menuMode = 10;
        WorldGen.CreateNewWorld();
        while (Main.menuMode == 10)
        {
          if (Main.oldStatusText != Main.statusText)
          {
            Main.oldStatusText = Main.statusText;
            Console.WriteLine(Main.statusText);
          }
        }
        try
        {
          Console.Clear();
        }
        catch
        {
        }
      }
      goto label_77;
label_78:
      if (!(Main.worldPathName == ""))
      {
        try
        {
          Console.Clear();
        }
        catch
        {
        }
        WorldGen.serverLoadWorld();
        Console.WriteLine("Terraria Server " + Main.versionNumber);
        Console.WriteLine("");
        while (!Netplay.ServerUp)
        {
          if (Main.oldStatusText != Main.statusText)
          {
            Main.oldStatusText = Main.statusText;
            Console.WriteLine(Main.statusText);
          }
        }
        try
        {
          Console.Clear();
        }
        catch
        {
        }
        Console.WriteLine("Terraria Server " + Main.versionNumber);
        Console.WriteLine("");
        Console.WriteLine("Listening on port " + (object) Netplay.serverPort);
        Console.WriteLine("Type 'help' for a list of commands.");
        Console.WriteLine("");
        Console.Title = "Terraria Server: " + Main.worldName;
        Stopwatch stopwatch = new Stopwatch();
        if (!Main.autoShutdown)
          Main.startDedInput();
        stopwatch.Start();
        double num1 = 50.0 / 3.0;
        double num2 = 0.0;
        int num3 = 0;
        new Stopwatch().Start();
        while (!Netplay.disconnect)
        {
          double elapsedMilliseconds = (double) stopwatch.ElapsedMilliseconds;
          if (elapsedMilliseconds + num2 >= num1)
          {
            ++num3;
            num2 += elapsedMilliseconds - num1;
            stopwatch.Reset();
            stopwatch.Start();
            if (Main.oldStatusText != Main.statusText)
            {
              Main.oldStatusText = Main.statusText;
              Console.WriteLine(Main.statusText);
            }
            if (num2 > 1000.0)
              num2 = 1000.0;
            if (Netplay.anyClients)
              this.Update(new GameTime());
            double num4 = (double) stopwatch.ElapsedMilliseconds + num2;
            if (num4 < num1)
            {
              int millisecondsTimeout = (int) (num1 - num4) - 1;
              if (millisecondsTimeout > 1)
              {
                Thread.Sleep(millisecondsTimeout);
                if (!Netplay.anyClients)
                {
                  num2 = 0.0;
                  Thread.Sleep(10);
                }
              }
            }
          }
          Thread.Sleep(0);
        }
      }
      else
        goto label_7;
    }

    public static void startDedInput() => ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), (object) 1);

    public static void startDedInputCallBack(object threadContext)
    {
      while (!Netplay.disconnect)
      {
        Console.Write(": ");
        string str1 = Console.ReadLine();
        string str2 = str1;
        string lower1 = str1.ToLower();
        try
        {
          if (lower1 == "help")
          {
            Console.WriteLine("Available commands:");
            Console.WriteLine("");
            Console.WriteLine("help " + (object) '\t' + (object) '\t' + " Displays a list of commands.");
            Console.WriteLine("playing " + (object) '\t' + " Shows the list of players");
            Console.WriteLine("clear " + (object) '\t' + (object) '\t' + " Clear the console window.");
            Console.WriteLine("exit " + (object) '\t' + (object) '\t' + " Shutdown the server and save.");
            Console.WriteLine("exit-nosave " + (object) '\t' + " Shutdown the server without saving.");
            Console.WriteLine("save " + (object) '\t' + (object) '\t' + " Save the game world.");
            Console.WriteLine("kick <player> " + (object) '\t' + " Kicks a player from the server.");
            Console.WriteLine("ban <player> " + (object) '\t' + " Bans a player from the server.");
            Console.WriteLine("password" + (object) '\t' + " Show password.");
            Console.WriteLine("password <pass>" + (object) '\t' + " Change password.");
            Console.WriteLine("version" + (object) '\t' + (object) '\t' + " Print version number.");
            Console.WriteLine("time" + (object) '\t' + (object) '\t' + " Display game time.");
            Console.WriteLine("port" + (object) '\t' + (object) '\t' + " Print the listening port.");
            Console.WriteLine("maxplayers" + (object) '\t' + " Print the max number of players.");
            Console.WriteLine("say <words>" + (object) '\t' + " Send a message.");
            Console.WriteLine("motd" + (object) '\t' + (object) '\t' + " Print MOTD.");
            Console.WriteLine("motd <words>" + (object) '\t' + " Change MOTD.");
            Console.WriteLine("dawn" + (object) '\t' + (object) '\t' + " Change time to dawn.");
            Console.WriteLine("noon" + (object) '\t' + (object) '\t' + " Change time to noon.");
            Console.WriteLine("dusk" + (object) '\t' + (object) '\t' + " Change time to dusk.");
            Console.WriteLine("midnight" + (object) '\t' + " Change time to midnight.");
            Console.WriteLine("settle" + (object) '\t' + (object) '\t' + " Settle all water.");
          }
          else if (lower1 == "settle")
          {
            if (!Liquid.panicMode)
              Liquid.StartPanic();
            else
              Console.WriteLine("Water is already settling");
          }
          else if (lower1 == "dawn")
          {
            Main.dayTime = true;
            Main.time = 0.0;
            NetMessage.SendData(7);
          }
          else if (lower1 == "dusk")
          {
            Main.dayTime = false;
            Main.time = 0.0;
            NetMessage.SendData(7);
          }
          else if (lower1 == "noon")
          {
            Main.dayTime = true;
            Main.time = 27000.0;
            NetMessage.SendData(7);
          }
          else if (lower1 == "midnight")
          {
            Main.dayTime = false;
            Main.time = 16200.0;
            NetMessage.SendData(7);
          }
          else if (lower1 == "exit-nosave")
            Netplay.disconnect = true;
          else if (lower1 == "exit")
          {
            WorldGen.saveWorld();
            Netplay.disconnect = true;
          }
          else if (lower1 == "save")
            WorldGen.saveWorld();
          else if (lower1 == "time")
          {
            string str3 = "AM";
            double time = Main.time;
            if (!Main.dayTime)
              time += 54000.0;
            double num1 = time / 86400.0 * 24.0 - 7.5 - 12.0;
            if (num1 < 0.0)
              num1 += 24.0;
            if (num1 >= 12.0)
              str3 = "PM";
            int num2 = (int) num1;
            double num3 = (double) (int) ((num1 - (double) num2) * 60.0);
            string str4 = string.Concat((object) num3);
            if (num3 < 10.0)
              str4 = "0" + str4;
            if (num2 > 12)
              num2 -= 12;
            if (num2 == 0)
              num2 = 12;
            Console.WriteLine("Time: " + (object) num2 + ":" + str4 + " " + str3);
          }
          else if (lower1 == "maxplayers")
            Console.WriteLine("Player limit: " + (object) Main.maxNetPlayers);
          else if (lower1 == "port")
            Console.WriteLine("Port: " + (object) Netplay.serverPort);
          else if (lower1 == "version")
            Console.WriteLine("Terraria Server " + Main.versionNumber);
          else if (lower1 == "clear")
          {
            try
            {
              Console.Clear();
            }
            catch
            {
            }
          }
          else if (lower1 == "playing")
          {
            int num = 0;
            for (int index = 0; index < (int) byte.MaxValue; ++index)
            {
              if (Main.player[index].active)
              {
                ++num;
                Console.WriteLine(Main.player[index].name + " (" + (object) Netplay.serverSock[index].tcpClient.Client.RemoteEndPoint + ")");
              }
            }
            switch (num)
            {
              case 0:
                Console.WriteLine("No players connected.");
                continue;
              case 1:
                Console.WriteLine("1 player connected.");
                continue;
              default:
                Console.WriteLine(num.ToString() + " players connected.");
                continue;
            }
          }
          else if (!(lower1 == ""))
          {
            if (lower1 == "motd")
            {
              if (Main.motd == "")
                Console.WriteLine("Welcome to " + Main.worldName + "!");
              else
                Console.WriteLine("MOTD: " + Main.motd);
            }
            else if (lower1.Length >= 5 && lower1.Substring(0, 5) == "motd ")
              Main.motd = str2.Substring(5);
            else if (lower1.Length == 8 && lower1.Substring(0, 8) == "password")
            {
              if (Netplay.password == "")
                Console.WriteLine("No password set.");
              else
                Console.WriteLine("Password: " + Netplay.password);
            }
            else if (lower1.Length >= 9 && lower1.Substring(0, 9) == "password ")
            {
              string str5 = str2.Substring(9);
              if (str5 == "")
              {
                Netplay.password = "";
                Console.WriteLine("Password disabled.");
              }
              else
              {
                Netplay.password = str5;
                Console.WriteLine("Password: " + Netplay.password);
              }
            }
            else if (lower1 == "say")
              Console.WriteLine("Usage: say <words>");
            else if (lower1.Length >= 4 && lower1.Substring(0, 4) == "say ")
            {
              string str6 = str2.Substring(4);
              if (str6 == "")
              {
                Console.WriteLine("Usage: say <words>");
              }
              else
              {
                Console.WriteLine("<Server> " + str6);
                NetMessage.SendData(25, text: ("<Server> " + str6), number: ((int) byte.MaxValue), number2: ((float) byte.MaxValue), number3: 240f, number4: 20f);
              }
            }
            else if (lower1.Length == 4 && lower1.Substring(0, 4) == "kick")
              Console.WriteLine("Usage: kick <player>");
            else if (lower1.Length >= 5 && lower1.Substring(0, 5) == "kick ")
            {
              string lower2 = lower1.Substring(5).ToLower();
              if (lower2 == "")
              {
                Console.WriteLine("Usage: kick <player>");
              }
              else
              {
                for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
                {
                  if (Main.player[remoteClient].active && Main.player[remoteClient].name.ToLower() == lower2)
                    NetMessage.SendData(2, remoteClient, text: "Kicked from server.");
                }
              }
            }
            else if (lower1.Length == 3 && lower1.Substring(0, 3) == "ban")
              Console.WriteLine("Usage: ban <player>");
            else if (lower1.Length >= 4 && lower1.Substring(0, 4) == "ban ")
            {
              string lower3 = lower1.Substring(4).ToLower();
              if (lower3 == "")
              {
                Console.WriteLine("Usage: ban <player>");
              }
              else
              {
                for (int index = 0; index < (int) byte.MaxValue; ++index)
                {
                  if (Main.player[index].active && Main.player[index].name.ToLower() == lower3)
                  {
                    Netplay.AddBan(index);
                    NetMessage.SendData(2, index, text: "Banned from server.");
                  }
                }
              }
            }
            else
              Console.WriteLine("Invalid command.");
          }
        }
        catch
        {
          Console.WriteLine("Invalid command.");
        }
      }
    }

    public Main()
    {
      this.graphics = new GraphicsDeviceManager((Game) this);
      this.Content.RootDirectory = "Content";
    }

    protected void SetTitle() => this.Window.Title = Lang.title();

    protected override void Initialize()
    {
      NPC.clrNames();
      NPC.setNames();
      Main.bgAlpha[0] = 1f;
      Main.bgAlpha2[0] = 1f;
      for (int index = 0; index < 112; ++index)
        Main.projFrames[index] = 1;
      Main.projFrames[72] = 4;
      Main.projFrames[86] = 4;
      Main.projFrames[87] = 4;
      Main.projFrames[102] = 2;
      Main.projFrames[111] = 8;
      Main.pvpBuff[20] = true;
      Main.pvpBuff[24] = true;
      Main.pvpBuff[31] = true;
      Main.pvpBuff[39] = true;
      Main.debuff[20] = true;
      Main.debuff[21] = true;
      Main.debuff[22] = true;
      Main.debuff[23] = true;
      Main.debuff[24] = true;
      Main.debuff[25] = true;
      Main.debuff[28] = true;
      Main.debuff[30] = true;
      Main.debuff[31] = true;
      Main.debuff[32] = true;
      Main.debuff[33] = true;
      Main.debuff[34] = true;
      Main.debuff[35] = true;
      Main.debuff[36] = true;
      Main.debuff[37] = true;
      Main.debuff[38] = true;
      Main.debuff[39] = true;
      for (int index = 0; index < 10; ++index)
      {
        Main.recentWorld[index] = "";
        Main.recentIP[index] = "";
        Main.recentPort[index] = 0;
      }
      if (Main.rand == null)
        Main.rand = new Random((int) DateTime.Now.Ticks);
      if (WorldGen.genRand == null)
        WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
      this.SetTitle();
      Main.lo = Main.rand.Next(6);
      Main.tileShine2[6] = true;
      Main.tileShine2[7] = true;
      Main.tileShine2[8] = true;
      Main.tileShine2[9] = true;
      Main.tileShine2[12] = true;
      Main.tileShine2[21] = true;
      Main.tileShine2[22] = true;
      Main.tileShine2[25] = true;
      Main.tileShine2[45] = true;
      Main.tileShine2[46] = true;
      Main.tileShine2[47] = true;
      Main.tileShine2[63] = true;
      Main.tileShine2[64] = true;
      Main.tileShine2[65] = true;
      Main.tileShine2[66] = true;
      Main.tileShine2[67] = true;
      Main.tileShine2[68] = true;
      Main.tileShine2[107] = true;
      Main.tileShine2[108] = true;
      Main.tileShine2[111] = true;
      Main.tileShine2[121] = true;
      Main.tileShine2[122] = true;
      Main.tileShine2[117] = true;
      Main.tileShine[129] = 300;
      Main.tileHammer[141] = true;
      Main.tileHammer[4] = true;
      Main.tileHammer[10] = true;
      Main.tileHammer[11] = true;
      Main.tileHammer[12] = true;
      Main.tileHammer[13] = true;
      Main.tileHammer[14] = true;
      Main.tileHammer[15] = true;
      Main.tileHammer[16] = true;
      Main.tileHammer[17] = true;
      Main.tileHammer[18] = true;
      Main.tileHammer[19] = true;
      Main.tileHammer[21] = true;
      Main.tileHammer[26] = true;
      Main.tileHammer[28] = true;
      Main.tileHammer[29] = true;
      Main.tileHammer[31] = true;
      Main.tileHammer[33] = true;
      Main.tileHammer[34] = true;
      Main.tileHammer[35] = true;
      Main.tileHammer[36] = true;
      Main.tileHammer[42] = true;
      Main.tileHammer[48] = true;
      Main.tileHammer[49] = true;
      Main.tileHammer[50] = true;
      Main.tileHammer[54] = true;
      Main.tileHammer[55] = true;
      Main.tileHammer[77] = true;
      Main.tileHammer[78] = true;
      Main.tileHammer[79] = true;
      Main.tileHammer[81] = true;
      Main.tileHammer[85] = true;
      Main.tileHammer[86] = true;
      Main.tileHammer[87] = true;
      Main.tileHammer[88] = true;
      Main.tileHammer[89] = true;
      Main.tileHammer[90] = true;
      Main.tileHammer[91] = true;
      Main.tileHammer[92] = true;
      Main.tileHammer[93] = true;
      Main.tileHammer[94] = true;
      Main.tileHammer[95] = true;
      Main.tileHammer[96] = true;
      Main.tileHammer[97] = true;
      Main.tileHammer[98] = true;
      Main.tileHammer[99] = true;
      Main.tileHammer[100] = true;
      Main.tileHammer[101] = true;
      Main.tileHammer[102] = true;
      Main.tileHammer[103] = true;
      Main.tileHammer[104] = true;
      Main.tileHammer[105] = true;
      Main.tileHammer[106] = true;
      Main.tileHammer[114] = true;
      Main.tileHammer[125] = true;
      Main.tileHammer[126] = true;
      Main.tileHammer[128] = true;
      Main.tileHammer[129] = true;
      Main.tileHammer[132] = true;
      Main.tileHammer[133] = true;
      Main.tileHammer[134] = true;
      Main.tileHammer[135] = true;
      Main.tileHammer[136] = true;
      Main.tileFrameImportant[139] = true;
      Main.tileHammer[139] = true;
      Main.tileLighted[149] = true;
      Main.tileFrameImportant[149] = true;
      Main.tileHammer[149] = true;
      Main.tileFrameImportant[142] = true;
      Main.tileHammer[142] = true;
      Main.tileFrameImportant[143] = true;
      Main.tileHammer[143] = true;
      Main.tileFrameImportant[144] = true;
      Main.tileHammer[144] = true;
      Main.tileStone[131] = true;
      Main.tileFrameImportant[136] = true;
      Main.tileFrameImportant[137] = true;
      Main.tileFrameImportant[138] = true;
      Main.tileBlockLight[137] = true;
      Main.tileSolid[137] = true;
      Main.tileBlockLight[145] = true;
      Main.tileSolid[145] = true;
      Main.tileMergeDirt[145] = true;
      Main.tileBlockLight[146] = true;
      Main.tileSolid[146] = true;
      Main.tileMergeDirt[146] = true;
      Main.tileBlockLight[147] = true;
      Main.tileSolid[147] = true;
      Main.tileMergeDirt[147] = true;
      Main.tileBlockLight[148] = true;
      Main.tileSolid[148] = true;
      Main.tileMergeDirt[148] = true;
      Main.tileBlockLight[138] = true;
      Main.tileSolid[138] = true;
      Main.tileBlockLight[140] = true;
      Main.tileSolid[140] = true;
      Main.tileAxe[5] = true;
      Main.tileAxe[30] = true;
      Main.tileAxe[72] = true;
      Main.tileAxe[80] = true;
      Main.tileAxe[124] = true;
      Main.tileShine[22] = 1150;
      Main.tileShine[6] = 1150;
      Main.tileShine[7] = 1100;
      Main.tileShine[8] = 1000;
      Main.tileShine[9] = 1050;
      Main.tileShine[12] = 1000;
      Main.tileShine[21] = 1200;
      Main.tileShine[63] = 900;
      Main.tileShine[64] = 900;
      Main.tileShine[65] = 900;
      Main.tileShine[66] = 900;
      Main.tileShine[67] = 900;
      Main.tileShine[68] = 900;
      Main.tileShine[45] = 1900;
      Main.tileShine[46] = 2000;
      Main.tileShine[47] = 2100;
      Main.tileShine[122] = 1800;
      Main.tileShine[121] = 1850;
      Main.tileShine[125] = 600;
      Main.tileShine[109] = 9000;
      Main.tileShine[110] = 9000;
      Main.tileShine[116] = 9000;
      Main.tileShine[117] = 9000;
      Main.tileShine[118] = 8000;
      Main.tileShine[107] = 950;
      Main.tileShine[108] = 900;
      Main.tileShine[111] = 850;
      Main.tileLighted[4] = true;
      Main.tileLighted[17] = true;
      Main.tileLighted[133] = true;
      Main.tileLighted[31] = true;
      Main.tileLighted[33] = true;
      Main.tileLighted[34] = true;
      Main.tileLighted[35] = true;
      Main.tileLighted[36] = true;
      Main.tileLighted[37] = true;
      Main.tileLighted[42] = true;
      Main.tileLighted[49] = true;
      Main.tileLighted[58] = true;
      Main.tileLighted[61] = true;
      Main.tileLighted[70] = true;
      Main.tileLighted[71] = true;
      Main.tileLighted[72] = true;
      Main.tileLighted[76] = true;
      Main.tileLighted[77] = true;
      Main.tileLighted[19] = true;
      Main.tileLighted[22] = true;
      Main.tileLighted[26] = true;
      Main.tileLighted[83] = true;
      Main.tileLighted[84] = true;
      Main.tileLighted[92] = true;
      Main.tileLighted[93] = true;
      Main.tileLighted[95] = true;
      Main.tileLighted[98] = true;
      Main.tileLighted[100] = true;
      Main.tileLighted[109] = true;
      Main.tileLighted[125] = true;
      Main.tileLighted[126] = true;
      Main.tileLighted[129] = true;
      Main.tileLighted[140] = true;
      Main.tileMergeDirt[1] = true;
      Main.tileMergeDirt[6] = true;
      Main.tileMergeDirt[7] = true;
      Main.tileMergeDirt[8] = true;
      Main.tileMergeDirt[9] = true;
      Main.tileMergeDirt[22] = true;
      Main.tileMergeDirt[25] = true;
      Main.tileMergeDirt[30] = true;
      Main.tileMergeDirt[37] = true;
      Main.tileMergeDirt[38] = true;
      Main.tileMergeDirt[40] = true;
      Main.tileMergeDirt[53] = true;
      Main.tileMergeDirt[56] = true;
      Main.tileMergeDirt[107] = true;
      Main.tileMergeDirt[108] = true;
      Main.tileMergeDirt[111] = true;
      Main.tileMergeDirt[112] = true;
      Main.tileMergeDirt[116] = true;
      Main.tileMergeDirt[117] = true;
      Main.tileMergeDirt[123] = true;
      Main.tileMergeDirt[140] = true;
      Main.tileMergeDirt[39] = true;
      Main.tileMergeDirt[122] = true;
      Main.tileMergeDirt[121] = true;
      Main.tileMergeDirt[120] = true;
      Main.tileMergeDirt[119] = true;
      Main.tileMergeDirt[118] = true;
      Main.tileMergeDirt[47] = true;
      Main.tileMergeDirt[46] = true;
      Main.tileMergeDirt[45] = true;
      Main.tileMergeDirt[44] = true;
      Main.tileMergeDirt[43] = true;
      Main.tileMergeDirt[41] = true;
      Main.tileFrameImportant[3] = true;
      Main.tileFrameImportant[4] = true;
      Main.tileFrameImportant[5] = true;
      Main.tileFrameImportant[10] = true;
      Main.tileFrameImportant[11] = true;
      Main.tileFrameImportant[12] = true;
      Main.tileFrameImportant[13] = true;
      Main.tileFrameImportant[14] = true;
      Main.tileFrameImportant[15] = true;
      Main.tileFrameImportant[16] = true;
      Main.tileFrameImportant[17] = true;
      Main.tileFrameImportant[18] = true;
      Main.tileFrameImportant[20] = true;
      Main.tileFrameImportant[21] = true;
      Main.tileFrameImportant[24] = true;
      Main.tileFrameImportant[26] = true;
      Main.tileFrameImportant[27] = true;
      Main.tileFrameImportant[28] = true;
      Main.tileFrameImportant[29] = true;
      Main.tileFrameImportant[31] = true;
      Main.tileFrameImportant[33] = true;
      Main.tileFrameImportant[34] = true;
      Main.tileFrameImportant[35] = true;
      Main.tileFrameImportant[36] = true;
      Main.tileFrameImportant[42] = true;
      Main.tileFrameImportant[50] = true;
      Main.tileFrameImportant[55] = true;
      Main.tileFrameImportant[61] = true;
      Main.tileFrameImportant[71] = true;
      Main.tileFrameImportant[72] = true;
      Main.tileFrameImportant[73] = true;
      Main.tileFrameImportant[74] = true;
      Main.tileFrameImportant[77] = true;
      Main.tileFrameImportant[78] = true;
      Main.tileFrameImportant[79] = true;
      Main.tileFrameImportant[81] = true;
      Main.tileFrameImportant[82] = true;
      Main.tileFrameImportant[83] = true;
      Main.tileFrameImportant[84] = true;
      Main.tileFrameImportant[85] = true;
      Main.tileFrameImportant[86] = true;
      Main.tileFrameImportant[87] = true;
      Main.tileFrameImportant[88] = true;
      Main.tileFrameImportant[89] = true;
      Main.tileFrameImportant[90] = true;
      Main.tileFrameImportant[91] = true;
      Main.tileFrameImportant[92] = true;
      Main.tileFrameImportant[93] = true;
      Main.tileFrameImportant[94] = true;
      Main.tileFrameImportant[95] = true;
      Main.tileFrameImportant[96] = true;
      Main.tileFrameImportant[97] = true;
      Main.tileFrameImportant[98] = true;
      Main.tileFrameImportant[99] = true;
      Main.tileFrameImportant[101] = true;
      Main.tileFrameImportant[102] = true;
      Main.tileFrameImportant[103] = true;
      Main.tileFrameImportant[104] = true;
      Main.tileFrameImportant[105] = true;
      Main.tileFrameImportant[100] = true;
      Main.tileFrameImportant[106] = true;
      Main.tileFrameImportant[110] = true;
      Main.tileFrameImportant[113] = true;
      Main.tileFrameImportant[114] = true;
      Main.tileFrameImportant[125] = true;
      Main.tileFrameImportant[126] = true;
      Main.tileFrameImportant[128] = true;
      Main.tileFrameImportant[129] = true;
      Main.tileFrameImportant[132] = true;
      Main.tileFrameImportant[133] = true;
      Main.tileFrameImportant[134] = true;
      Main.tileFrameImportant[135] = true;
      Main.tileFrameImportant[141] = true;
      Main.tileCut[3] = true;
      Main.tileCut[24] = true;
      Main.tileCut[28] = true;
      Main.tileCut[32] = true;
      Main.tileCut[51] = true;
      Main.tileCut[52] = true;
      Main.tileCut[61] = true;
      Main.tileCut[62] = true;
      Main.tileCut[69] = true;
      Main.tileCut[71] = true;
      Main.tileCut[73] = true;
      Main.tileCut[74] = true;
      Main.tileCut[82] = true;
      Main.tileCut[83] = true;
      Main.tileCut[84] = true;
      Main.tileCut[110] = true;
      Main.tileCut[113] = true;
      Main.tileCut[115] = true;
      Main.tileAlch[82] = true;
      Main.tileAlch[83] = true;
      Main.tileAlch[84] = true;
      Main.tileLavaDeath[104] = true;
      Main.tileLavaDeath[110] = true;
      Main.tileLavaDeath[113] = true;
      Main.tileLavaDeath[115] = true;
      Main.tileSolid[(int) sbyte.MaxValue] = true;
      Main.tileSolid[130] = true;
      Main.tileBlockLight[130] = true;
      Main.tileBlockLight[131] = true;
      Main.tileSolid[107] = true;
      Main.tileBlockLight[107] = true;
      Main.tileSolid[108] = true;
      Main.tileBlockLight[108] = true;
      Main.tileSolid[111] = true;
      Main.tileBlockLight[111] = true;
      Main.tileSolid[109] = true;
      Main.tileBlockLight[109] = true;
      Main.tileSolid[110] = false;
      Main.tileNoAttach[110] = true;
      Main.tileNoFail[110] = true;
      Main.tileSolid[112] = true;
      Main.tileBlockLight[112] = true;
      Main.tileSolid[116] = true;
      Main.tileBlockLight[116] = true;
      Main.tileSolid[117] = true;
      Main.tileBlockLight[117] = true;
      Main.tileSolid[123] = true;
      Main.tileBlockLight[123] = true;
      Main.tileSolid[118] = true;
      Main.tileBlockLight[118] = true;
      Main.tileSolid[119] = true;
      Main.tileBlockLight[119] = true;
      Main.tileSolid[120] = true;
      Main.tileBlockLight[120] = true;
      Main.tileSolid[121] = true;
      Main.tileBlockLight[121] = true;
      Main.tileSolid[122] = true;
      Main.tileBlockLight[122] = true;
      Main.tileBlockLight[115] = true;
      Main.tileSolid[0] = true;
      Main.tileBlockLight[0] = true;
      Main.tileSolid[1] = true;
      Main.tileBlockLight[1] = true;
      Main.tileSolid[2] = true;
      Main.tileBlockLight[2] = true;
      Main.tileSolid[3] = false;
      Main.tileNoAttach[3] = true;
      Main.tileNoFail[3] = true;
      Main.tileSolid[4] = false;
      Main.tileNoAttach[4] = true;
      Main.tileNoFail[4] = true;
      Main.tileNoFail[24] = true;
      Main.tileSolid[5] = false;
      Main.tileSolid[6] = true;
      Main.tileBlockLight[6] = true;
      Main.tileSolid[7] = true;
      Main.tileBlockLight[7] = true;
      Main.tileSolid[8] = true;
      Main.tileBlockLight[8] = true;
      Main.tileSolid[9] = true;
      Main.tileBlockLight[9] = true;
      Main.tileBlockLight[10] = true;
      Main.tileSolid[10] = true;
      Main.tileNoAttach[10] = true;
      Main.tileBlockLight[10] = true;
      Main.tileSolid[11] = false;
      Main.tileSolidTop[19] = true;
      Main.tileSolid[19] = true;
      Main.tileSolid[22] = true;
      Main.tileSolid[23] = true;
      Main.tileSolid[25] = true;
      Main.tileSolid[30] = true;
      Main.tileNoFail[32] = true;
      Main.tileBlockLight[32] = true;
      Main.tileSolid[37] = true;
      Main.tileBlockLight[37] = true;
      Main.tileSolid[38] = true;
      Main.tileBlockLight[38] = true;
      Main.tileSolid[39] = true;
      Main.tileBlockLight[39] = true;
      Main.tileSolid[40] = true;
      Main.tileBlockLight[40] = true;
      Main.tileSolid[41] = true;
      Main.tileBlockLight[41] = true;
      Main.tileSolid[43] = true;
      Main.tileBlockLight[43] = true;
      Main.tileSolid[44] = true;
      Main.tileBlockLight[44] = true;
      Main.tileSolid[45] = true;
      Main.tileBlockLight[45] = true;
      Main.tileSolid[46] = true;
      Main.tileBlockLight[46] = true;
      Main.tileSolid[47] = true;
      Main.tileBlockLight[47] = true;
      Main.tileSolid[48] = true;
      Main.tileBlockLight[48] = true;
      Main.tileSolid[53] = true;
      Main.tileBlockLight[53] = true;
      Main.tileSolid[54] = true;
      Main.tileBlockLight[52] = true;
      Main.tileSolid[56] = true;
      Main.tileBlockLight[56] = true;
      Main.tileSolid[57] = true;
      Main.tileBlockLight[57] = true;
      Main.tileSolid[58] = true;
      Main.tileBlockLight[58] = true;
      Main.tileSolid[59] = true;
      Main.tileBlockLight[59] = true;
      Main.tileSolid[60] = true;
      Main.tileBlockLight[60] = true;
      Main.tileSolid[63] = true;
      Main.tileBlockLight[63] = true;
      Main.tileStone[63] = true;
      Main.tileStone[130] = true;
      Main.tileSolid[64] = true;
      Main.tileBlockLight[64] = true;
      Main.tileStone[64] = true;
      Main.tileSolid[65] = true;
      Main.tileBlockLight[65] = true;
      Main.tileStone[65] = true;
      Main.tileSolid[66] = true;
      Main.tileBlockLight[66] = true;
      Main.tileStone[66] = true;
      Main.tileSolid[67] = true;
      Main.tileBlockLight[67] = true;
      Main.tileStone[67] = true;
      Main.tileSolid[68] = true;
      Main.tileBlockLight[68] = true;
      Main.tileStone[68] = true;
      Main.tileSolid[75] = true;
      Main.tileBlockLight[75] = true;
      Main.tileSolid[76] = true;
      Main.tileBlockLight[76] = true;
      Main.tileSolid[70] = true;
      Main.tileBlockLight[70] = true;
      Main.tileNoFail[50] = true;
      Main.tileNoAttach[50] = true;
      Main.tileDungeon[41] = true;
      Main.tileDungeon[43] = true;
      Main.tileDungeon[44] = true;
      Main.tileBlockLight[30] = true;
      Main.tileBlockLight[25] = true;
      Main.tileBlockLight[23] = true;
      Main.tileBlockLight[22] = true;
      Main.tileBlockLight[62] = true;
      Main.tileSolidTop[18] = true;
      Main.tileSolidTop[14] = true;
      Main.tileSolidTop[16] = true;
      Main.tileSolidTop[114] = true;
      Main.tileNoAttach[20] = true;
      Main.tileNoAttach[19] = true;
      Main.tileNoAttach[13] = true;
      Main.tileNoAttach[14] = true;
      Main.tileNoAttach[15] = true;
      Main.tileNoAttach[16] = true;
      Main.tileNoAttach[17] = true;
      Main.tileNoAttach[18] = true;
      Main.tileNoAttach[19] = true;
      Main.tileNoAttach[21] = true;
      Main.tileNoAttach[27] = true;
      Main.tileNoAttach[114] = true;
      Main.tileTable[14] = true;
      Main.tileTable[18] = true;
      Main.tileTable[19] = true;
      Main.tileTable[114] = true;
      Main.tileNoAttach[86] = true;
      Main.tileNoAttach[87] = true;
      Main.tileNoAttach[88] = true;
      Main.tileNoAttach[89] = true;
      Main.tileNoAttach[90] = true;
      Main.tileLavaDeath[86] = true;
      Main.tileLavaDeath[87] = true;
      Main.tileLavaDeath[88] = true;
      Main.tileLavaDeath[89] = true;
      Main.tileLavaDeath[125] = true;
      Main.tileLavaDeath[126] = true;
      Main.tileLavaDeath[101] = true;
      Main.tileTable[101] = true;
      Main.tileNoAttach[101] = true;
      Main.tileLavaDeath[102] = true;
      Main.tileNoAttach[102] = true;
      Main.tileNoAttach[94] = true;
      Main.tileNoAttach[95] = true;
      Main.tileNoAttach[96] = true;
      Main.tileNoAttach[97] = true;
      Main.tileNoAttach[98] = true;
      Main.tileNoAttach[99] = true;
      Main.tileLavaDeath[94] = true;
      Main.tileLavaDeath[95] = true;
      Main.tileLavaDeath[96] = true;
      Main.tileLavaDeath[97] = true;
      Main.tileLavaDeath[98] = true;
      Main.tileLavaDeath[99] = true;
      Main.tileLavaDeath[100] = true;
      Main.tileLavaDeath[103] = true;
      Main.tileTable[87] = true;
      Main.tileTable[88] = true;
      Main.tileSolidTop[87] = true;
      Main.tileSolidTop[88] = true;
      Main.tileSolidTop[101] = true;
      Main.tileNoAttach[91] = true;
      Main.tileLavaDeath[91] = true;
      Main.tileNoAttach[92] = true;
      Main.tileLavaDeath[92] = true;
      Main.tileNoAttach[93] = true;
      Main.tileLavaDeath[93] = true;
      Main.tileWaterDeath[4] = true;
      Main.tileWaterDeath[51] = true;
      Main.tileWaterDeath[93] = true;
      Main.tileWaterDeath[98] = true;
      Main.tileLavaDeath[3] = true;
      Main.tileLavaDeath[5] = true;
      Main.tileLavaDeath[10] = true;
      Main.tileLavaDeath[11] = true;
      Main.tileLavaDeath[12] = true;
      Main.tileLavaDeath[13] = true;
      Main.tileLavaDeath[14] = true;
      Main.tileLavaDeath[15] = true;
      Main.tileLavaDeath[16] = true;
      Main.tileLavaDeath[17] = true;
      Main.tileLavaDeath[18] = true;
      Main.tileLavaDeath[19] = true;
      Main.tileLavaDeath[20] = true;
      Main.tileLavaDeath[27] = true;
      Main.tileLavaDeath[28] = true;
      Main.tileLavaDeath[29] = true;
      Main.tileLavaDeath[32] = true;
      Main.tileLavaDeath[33] = true;
      Main.tileLavaDeath[34] = true;
      Main.tileLavaDeath[35] = true;
      Main.tileLavaDeath[36] = true;
      Main.tileLavaDeath[42] = true;
      Main.tileLavaDeath[49] = true;
      Main.tileLavaDeath[50] = true;
      Main.tileLavaDeath[52] = true;
      Main.tileLavaDeath[55] = true;
      Main.tileLavaDeath[61] = true;
      Main.tileLavaDeath[62] = true;
      Main.tileLavaDeath[69] = true;
      Main.tileLavaDeath[71] = true;
      Main.tileLavaDeath[72] = true;
      Main.tileLavaDeath[73] = true;
      Main.tileLavaDeath[74] = true;
      Main.tileLavaDeath[79] = true;
      Main.tileLavaDeath[80] = true;
      Main.tileLavaDeath[81] = true;
      Main.tileLavaDeath[106] = true;
      Main.wallHouse[1] = true;
      Main.wallHouse[4] = true;
      Main.wallHouse[5] = true;
      Main.wallHouse[6] = true;
      Main.wallHouse[10] = true;
      Main.wallHouse[11] = true;
      Main.wallHouse[12] = true;
      Main.wallHouse[16] = true;
      Main.wallHouse[17] = true;
      Main.wallHouse[18] = true;
      Main.wallHouse[19] = true;
      Main.wallHouse[20] = true;
      Main.wallHouse[21] = true;
      Main.wallHouse[22] = true;
      Main.wallHouse[23] = true;
      Main.wallHouse[24] = true;
      Main.wallHouse[25] = true;
      Main.wallHouse[26] = true;
      Main.wallHouse[27] = true;
      Main.wallHouse[29] = true;
      Main.wallHouse[30] = true;
      Main.wallHouse[31] = true;
      for (int index = 0; index < 32; ++index)
        Main.wallBlend[index] = index != 20 ? (index != 19 ? (index != 18 ? (index != 17 ? (index != 16 ? index : 2) : 7) : 8) : 9) : 14;
      Main.tileNoFail[32] = true;
      Main.tileNoFail[61] = true;
      Main.tileNoFail[69] = true;
      Main.tileNoFail[73] = true;
      Main.tileNoFail[74] = true;
      Main.tileNoFail[82] = true;
      Main.tileNoFail[83] = true;
      Main.tileNoFail[84] = true;
      Main.tileNoFail[110] = true;
      Main.tileNoFail[113] = true;
      for (int index = 0; index < 150; ++index)
      {
        Main.tileName[index] = "";
        if (Main.tileSolid[index])
          Main.tileNoSunLight[index] = true;
      }
      Main.tileNoSunLight[19] = false;
      Main.tileNoSunLight[11] = true;
      for (int index = 0; index < Main.maxMenuItems; ++index)
        this.menuItemScale[index] = 0.8f;
      for (int index = 0; index < 2001; ++index)
        Main.dust[index] = new Dust();
      for (int index = 0; index < 201; ++index)
        Main.item[index] = new Item();
      for (int index = 0; index < 201; ++index)
      {
        Main.npc[index] = new NPC();
        Main.npc[index].whoAmI = index;
      }
      for (int index = 0; index < 256; ++index)
        Main.player[index] = new Player();
      for (int index = 0; index < 1001; ++index)
        Main.projectile[index] = new Projectile();
      for (int index = 0; index < 201; ++index)
        Main.gore[index] = new Gore();
      for (int index = 0; index < 100; ++index)
        Main.cloud[index] = new Cloud();
      for (int index = 0; index < 100; ++index)
        Main.combatText[index] = new CombatText();
      for (int index = 0; index < 20; ++index)
        Main.itemText[index] = new ItemText();
      for (int Type = 0; Type < 604; ++Type)
      {
        Item obj = new Item();
        obj.SetDefaults(Type);
        Main.itemName[Type] = obj.name;
        if (obj.headSlot > 0)
          Item.headType[obj.headSlot] = obj.type;
        if (obj.bodySlot > 0)
          Item.bodyType[obj.bodySlot] = obj.type;
        if (obj.legSlot > 0)
          Item.legType[obj.legSlot] = obj.type;
      }
      for (int index = 0; index < Recipe.maxRecipes; ++index)
      {
        Main.recipe[index] = new Recipe();
        Main.availableRecipeY[index] = (float) (65 * index);
      }
      Recipe.SetupRecipes();
      for (int index = 0; index < Main.numChatLines; ++index)
        Main.chatLine[index] = new ChatLine();
      for (int index = 0; index < Liquid.resLiquid; ++index)
        Main.liquid[index] = new Liquid();
      for (int index = 0; index < 10000; ++index)
        Main.liquidBuffer[index] = new LiquidBuffer();
      this.shop[0] = new Chest();
      this.shop[1] = new Chest();
      this.shop[1].SetupShop(1);
      this.shop[2] = new Chest();
      this.shop[2].SetupShop(2);
      this.shop[3] = new Chest();
      this.shop[3].SetupShop(3);
      this.shop[4] = new Chest();
      this.shop[4].SetupShop(4);
      this.shop[5] = new Chest();
      this.shop[5].SetupShop(5);
      this.shop[6] = new Chest();
      this.shop[6].SetupShop(6);
      this.shop[7] = new Chest();
      this.shop[7].SetupShop(7);
      this.shop[8] = new Chest();
      this.shop[8].SetupShop(8);
      this.shop[9] = new Chest();
      this.shop[9].SetupShop(9);
      Main.teamColor[0] = Microsoft.Xna.Framework.Color.White;
      Main.teamColor[1] = new Microsoft.Xna.Framework.Color(230, 40, 20);
      Main.teamColor[2] = new Microsoft.Xna.Framework.Color(20, 200, 30);
      Main.teamColor[3] = new Microsoft.Xna.Framework.Color(75, 90, (int) byte.MaxValue);
      Main.teamColor[4] = new Microsoft.Xna.Framework.Color(200, 180, 0);
      if (Main.menuMode == 1)
        Main.LoadPlayers();
      for (int Type = 1; Type < 112; ++Type)
      {
        Projectile projectile = new Projectile();
        projectile.SetDefaults(Type);
        if (projectile.hostile)
          Main.projHostile[Type] = true;
      }
      Netplay.Init();
      if (Main.skipMenu)
      {
        WorldGen.clearWorld();
        Main.gameMenu = false;
        Main.LoadPlayers();
        Main.player[Main.myPlayer] = (Player) Main.loadPlayer[0].Clone();
        Main.PlayerPath = Main.loadPlayerPath[0];
        Main.LoadWorlds();
        WorldGen.generateWorld();
        WorldGen.EveryTileFrame();
        Main.player[Main.myPlayer].Spawn();
      }
      else
      {
        IntPtr systemMenu = Main.GetSystemMenu(this.Window.Handle, false);
        int menuItemCount = Main.GetMenuItemCount(systemMenu);
        Main.RemoveMenu(systemMenu, menuItemCount - 1, 1024);
      }
      if (Main.dedServ)
        return;
      keyBoardInput.newKeyEvent += (Action<char>) (keyStroke =>
      {
        if (Main.keyCount >= 10)
          return;
        Main.keyInt[Main.keyCount] = (int) keyStroke;
        Main.keyString[Main.keyCount] = string.Concat((object) keyStroke);
        ++Main.keyCount;
      });
      this.graphics.PreferredBackBufferWidth = Main.screenWidth;
      this.graphics.PreferredBackBufferHeight = Main.screenHeight;
      this.graphics.ApplyChanges();
      base.Initialize();
      this.Window.AllowUserResizing = true;
      this.OpenSettings();
      this.CheckBunny();
      Lang.setLang();
      if (Lang.lang == 0)
        Main.menuMode = 1212;
      this.SetTitle();
      this.OpenRecent();
      Star.SpawnStars();
      foreach (DisplayMode supportedDisplayMode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
      {
        if (supportedDisplayMode.Width >= Main.minScreenW && supportedDisplayMode.Height >= Main.minScreenH && supportedDisplayMode.Width <= Main.maxScreenW && supportedDisplayMode.Height <= Main.maxScreenH)
        {
          bool flag = true;
          for (int index = 0; index < this.numDisplayModes; ++index)
          {
            if (supportedDisplayMode.Width == this.displayWidth[index] && supportedDisplayMode.Height == this.displayHeight[index])
            {
              flag = false;
              break;
            }
          }
          if (flag)
          {
            this.displayHeight[this.numDisplayModes] = supportedDisplayMode.Height;
            this.displayWidth[this.numDisplayModes] = supportedDisplayMode.Width;
            ++this.numDisplayModes;
          }
        }
      }
      if (Main.autoJoin)
      {
        Main.LoadPlayers();
        Main.menuMode = 1;
        Main.menuMultiplayer = true;
      }
      Main.fpsTimer.Start();
      Main.updateTimer.Start();
    }

    protected override void LoadContent()
    {
      try
      {
        Main.engine = new AudioEngine("Content" + (object) Path.DirectorySeparatorChar + "TerrariaMusic.xgs");
        Main.soundBank = new SoundBank(Main.engine, "Content" + (object) Path.DirectorySeparatorChar + "Sound Bank.xsb");
        Main.waveBank = new WaveBank(Main.engine, "Content" + (object) Path.DirectorySeparatorChar + "Wave Bank.xwb");
        for (int index = 1; index < 14; ++index)
          Main.music[index] = Main.soundBank.GetCue("Music_" + (object) index);
        Main.soundMech[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Mech_0");
        Main.soundInstanceMech[0] = Main.soundMech[0].CreateInstance();
        Main.soundGrab = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Grab");
        Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
        Main.soundPixie = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Pixie");
        Main.soundInstancePixie = Main.soundGrab.CreateInstance();
        Main.soundDig[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Dig_0");
        Main.soundInstanceDig[0] = Main.soundDig[0].CreateInstance();
        Main.soundDig[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Dig_1");
        Main.soundInstanceDig[1] = Main.soundDig[1].CreateInstance();
        Main.soundDig[2] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Dig_2");
        Main.soundInstanceDig[2] = Main.soundDig[2].CreateInstance();
        Main.soundTink[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Tink_0");
        Main.soundInstanceTink[0] = Main.soundTink[0].CreateInstance();
        Main.soundTink[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Tink_1");
        Main.soundInstanceTink[1] = Main.soundTink[1].CreateInstance();
        Main.soundTink[2] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Tink_2");
        Main.soundInstanceTink[2] = Main.soundTink[2].CreateInstance();
        Main.soundPlayerHit[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Player_Hit_0");
        Main.soundInstancePlayerHit[0] = Main.soundPlayerHit[0].CreateInstance();
        Main.soundPlayerHit[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Player_Hit_1");
        Main.soundInstancePlayerHit[1] = Main.soundPlayerHit[1].CreateInstance();
        Main.soundPlayerHit[2] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Player_Hit_2");
        Main.soundInstancePlayerHit[2] = Main.soundPlayerHit[2].CreateInstance();
        Main.soundFemaleHit[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Female_Hit_0");
        Main.soundInstanceFemaleHit[0] = Main.soundFemaleHit[0].CreateInstance();
        Main.soundFemaleHit[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Female_Hit_1");
        Main.soundInstanceFemaleHit[1] = Main.soundFemaleHit[1].CreateInstance();
        Main.soundFemaleHit[2] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Female_Hit_2");
        Main.soundInstanceFemaleHit[2] = Main.soundFemaleHit[2].CreateInstance();
        Main.soundPlayerKilled = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Player_Killed");
        Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
        Main.soundChat = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Chat");
        Main.soundInstanceChat = Main.soundChat.CreateInstance();
        Main.soundGrass = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Grass");
        Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
        Main.soundDoorOpen = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Door_Opened");
        Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
        Main.soundDoorClosed = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Door_Closed");
        Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
        Main.soundMenuTick = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Menu_Tick");
        Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
        Main.soundMenuOpen = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Menu_Open");
        Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
        Main.soundMenuClose = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Menu_Close");
        Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
        Main.soundShatter = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Shatter");
        Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
        Main.soundZombie[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Zombie_0");
        Main.soundInstanceZombie[0] = Main.soundZombie[0].CreateInstance();
        Main.soundZombie[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Zombie_1");
        Main.soundInstanceZombie[1] = Main.soundZombie[1].CreateInstance();
        Main.soundZombie[2] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Zombie_2");
        Main.soundInstanceZombie[2] = Main.soundZombie[2].CreateInstance();
        Main.soundZombie[3] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Zombie_3");
        Main.soundInstanceZombie[3] = Main.soundZombie[3].CreateInstance();
        Main.soundZombie[4] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Zombie_4");
        Main.soundInstanceZombie[4] = Main.soundZombie[4].CreateInstance();
        Main.soundRoar[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Roar_0");
        Main.soundInstanceRoar[0] = Main.soundRoar[0].CreateInstance();
        Main.soundRoar[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Roar_1");
        Main.soundInstanceRoar[1] = Main.soundRoar[1].CreateInstance();
        Main.soundSplash[0] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Splash_0");
        Main.soundInstanceSplash[0] = Main.soundRoar[0].CreateInstance();
        Main.soundSplash[1] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Splash_1");
        Main.soundInstanceSplash[1] = Main.soundSplash[1].CreateInstance();
        Main.soundDoubleJump = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Double_Jump");
        Main.soundInstanceDoubleJump = Main.soundRoar[0].CreateInstance();
        Main.soundRun = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Run");
        Main.soundInstanceRun = Main.soundRun.CreateInstance();
        Main.soundCoins = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Coins");
        Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
        Main.soundUnlock = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Unlock");
        Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
        Main.soundMaxMana = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "MaxMana");
        Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
        Main.soundDrown = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Drown");
        Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
        for (int index = 1; index < 38; ++index)
        {
          Main.soundItem[index] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "Item_" + (object) index);
          Main.soundInstanceItem[index] = Main.soundItem[index].CreateInstance();
        }
        for (int index = 1; index < 12; ++index)
        {
          Main.soundNPCHit[index] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "NPC_Hit_" + (object) index);
          Main.soundInstanceNPCHit[index] = Main.soundNPCHit[index].CreateInstance();
        }
        for (int index = 1; index < 16; ++index)
        {
          Main.soundNPCKilled[index] = this.Content.Load<SoundEffect>("Sounds" + (object) Path.DirectorySeparatorChar + "NPC_Killed_" + (object) index);
          Main.soundInstanceNPCKilled[index] = Main.soundNPCKilled[index].CreateInstance();
        }
      }
      catch
      {
        Main.musicVolume = 0.0f;
        Main.soundVolume = 0.0f;
      }
      Main.reforgeTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Reforge");
      Main.timerTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Timer");
      Main.wofTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "WallOfFlesh");
      Main.wallOutlineTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Wall_Outline");
      Main.raTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "ra-logo");
      Main.reTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "re-logo");
      Main.splashTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "splash");
      Main.fadeTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "fade-out");
      Main.ghostTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Ghost");
      Main.evilCactusTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Evil_Cactus");
      Main.goodCactusTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Good_Cactus");
      Main.wraithEyeTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Wraith_Eyes");
      Main.MusicBoxTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Music_Box");
      Main.wingsTexture[1] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Wings_1");
      Main.wingsTexture[2] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Wings_2");
      Main.destTexture[0] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Dest1");
      Main.destTexture[1] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Dest2");
      Main.destTexture[2] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Dest3");
      Main.wireTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Wires");
      Main.loTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "logo_" + (object) Main.rand.Next(1, 7));
      this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
      for (int index = 1; index < 2; ++index)
        Main.bannerTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "House_Banner_" + (object) index);
      for (int index = 0; index < 12; ++index)
        Main.npcHeadTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "NPC_Head_" + (object) index);
      for (int index = 0; index < 150; ++index)
        Main.tileTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tiles_" + (object) index);
      for (int index = 1; index < 32; ++index)
        Main.wallTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Wall_" + (object) index);
      for (int index = 1; index < 41; ++index)
        Main.buffTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Buff_" + (object) index);
      for (int index = 0; index < 32; ++index)
      {
        Main.backgroundTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Background_" + (object) index);
        Main.backgroundWidth[index] = Main.backgroundTexture[index].Width;
        Main.backgroundHeight[index] = Main.backgroundTexture[index].Height;
      }
      for (int index = 0; index < 604; ++index)
        Main.itemTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Item_" + (object) index);
      for (int index = 0; index < 147; ++index)
        Main.npcTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "NPC_" + (object) index);
      for (int Type = 0; Type < 147; ++Type)
      {
        NPC npc = new NPC();
        npc.SetDefaults(Type);
        Main.npcName[Type] = npc.name;
      }
      for (int index = 0; index < 112; ++index)
        Main.projectileTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Projectile_" + (object) index);
      for (int index = 1; index < 160; ++index)
        Main.goreTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Gore_" + (object) index);
      for (int index = 0; index < 4; ++index)
        Main.cloudTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Cloud_" + (object) index);
      for (int index = 0; index < 5; ++index)
        Main.starTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Star_" + (object) index);
      for (int index = 0; index < 2; ++index)
        Main.liquidTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Liquid_" + (object) index);
      Main.npcToggleTexture[0] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "House_1");
      Main.npcToggleTexture[1] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "House_2");
      Main.HBLockTexture[0] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Lock_0");
      Main.HBLockTexture[1] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Lock_1");
      Main.gridTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Grid");
      Main.trashTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Trash");
      Main.cdTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "CoolDown");
      Main.logoTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Logo");
      Main.logo2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Logo2");
      Main.logo3Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Logo3");
      Main.dustTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Dust");
      Main.sunTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Sun");
      Main.sun2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Sun2");
      Main.moonTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Moon");
      Main.blackTileTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Black_Tile");
      Main.heartTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Heart");
      Main.bubbleTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Bubble");
      Main.manaTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Mana");
      Main.cursorTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Cursor");
      Main.ninjaTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Ninja");
      Main.antLionTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "AntlionBody");
      Main.spikeBaseTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Spike_Base");
      Main.treeTopTexture[0] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Tops_0");
      Main.treeBranchTexture[0] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Branches_0");
      Main.treeTopTexture[1] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Tops_1");
      Main.treeBranchTexture[1] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Branches_1");
      Main.treeTopTexture[2] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Tops_2");
      Main.treeBranchTexture[2] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Branches_2");
      Main.treeTopTexture[3] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Tops_3");
      Main.treeBranchTexture[3] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Branches_3");
      Main.treeTopTexture[4] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Tops_4");
      Main.treeBranchTexture[4] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Tree_Branches_4");
      Main.shroomCapTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Shroom_Tops");
      Main.inventoryBackTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back");
      Main.inventoryBack2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back2");
      Main.inventoryBack3Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back3");
      Main.inventoryBack4Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back4");
      Main.inventoryBack5Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back5");
      Main.inventoryBack6Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back6");
      Main.inventoryBack7Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back7");
      Main.inventoryBack8Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back8");
      Main.inventoryBack9Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back9");
      Main.inventoryBack10Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back10");
      Main.inventoryBack11Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Inventory_Back11");
      Main.textBackTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Text_Back");
      Main.chatTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chat");
      Main.chat2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chat2");
      Main.chatBackTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chat_Back");
      Main.teamTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Team");
      for (int index = 1; index < 26; ++index)
      {
        Main.femaleBodyTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Body_" + (object) index);
        Main.armorBodyTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Armor_Body_" + (object) index);
        Main.armorArmTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Armor_Arm_" + (object) index);
      }
      for (int index = 1; index < 45; ++index)
        Main.armorHeadTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Armor_Head_" + (object) index);
      for (int index = 1; index < 25; ++index)
        Main.armorLegTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Armor_Legs_" + (object) index);
      for (int index = 0; index < 36; ++index)
      {
        Main.playerHairTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Hair_" + (object) (index + 1));
        Main.playerHairAltTexture[index] = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_HairAlt_" + (object) (index + 1));
      }
      Main.skinBodyTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Skin_Body");
      Main.skinLegsTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Skin_Legs");
      Main.playerEyeWhitesTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Eye_Whites");
      Main.playerEyesTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Eyes");
      Main.playerHandsTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Hands");
      Main.playerHands2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Hands2");
      Main.playerHeadTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Head");
      Main.playerPantsTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Pants");
      Main.playerShirtTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Shirt");
      Main.playerShoesTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Shoes");
      Main.playerUnderShirtTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Undershirt");
      Main.playerUnderShirt2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Player_Undershirt2");
      Main.femalePantsTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Pants");
      Main.femaleShirtTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Shirt");
      Main.femaleShoesTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Shoes");
      Main.femaleUnderShirtTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Undershirt");
      Main.femaleUnderShirt2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Undershirt2");
      Main.femaleShirt2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Female_Shirt2");
      Main.chaosTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chaos");
      Main.EyeLaserTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Eye_Laser");
      Main.BoneEyesTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Bone_eyes");
      Main.BoneLaserTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Bone_Laser");
      Main.lightDiscTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Light_Disc");
      Main.confuseTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Confuse");
      Main.probeTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Probe");
      Main.chainTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain");
      Main.chain2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain2");
      Main.chain3Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain3");
      Main.chain4Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain4");
      Main.chain5Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain5");
      Main.chain6Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain6");
      Main.chain7Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain7");
      Main.chain8Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain8");
      Main.chain9Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain9");
      Main.chain10Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain10");
      Main.chain11Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain11");
      Main.chain12Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Chain12");
      Main.boneArmTexture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Arm_Bone");
      Main.boneArm2Texture = this.Content.Load<Texture2D>("Images" + (object) Path.DirectorySeparatorChar + "Arm_Bone_2");
      Main.fontItemStack = this.Content.Load<SpriteFont>("Fonts" + (object) Path.DirectorySeparatorChar + "Item_Stack");
      Main.fontMouseText = this.Content.Load<SpriteFont>("Fonts" + (object) Path.DirectorySeparatorChar + "Mouse_Text");
      Main.fontDeathText = this.Content.Load<SpriteFont>("Fonts" + (object) Path.DirectorySeparatorChar + "Death_Text");
      Main.fontCombatText[0] = this.Content.Load<SpriteFont>("Fonts" + (object) Path.DirectorySeparatorChar + "Combat_Text");
      Main.fontCombatText[1] = this.Content.Load<SpriteFont>("Fonts" + (object) Path.DirectorySeparatorChar + "Combat_Crit");
    }

    protected override void UnloadContent()
    {
    }

    protected void UpdateMusic()
    {
      try
      {
        if (Main.dedServ)
          return;
        if (Main.curMusic > 0)
        {
          if (!this.IsActive)
          {
            if (Main.music[Main.curMusic].IsPaused)
              return;
            if (!Main.music[Main.curMusic].IsPlaying)
              return;
            try
            {
              Main.music[Main.curMusic].Pause();
              return;
            }
            catch
            {
              return;
            }
          }
          else if (Main.music[Main.curMusic].IsPaused)
            Main.music[Main.curMusic].Resume();
        }
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        Rectangle rectangle1 = new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
        int num = 5000;
        for (int index = 0; index < 200; ++index)
        {
          if (Main.npc[index].active)
          {
            if (Main.npc[index].type == 134 || Main.npc[index].type == 143 || Main.npc[index].type == 144 || Main.npc[index].type == 145)
            {
              Rectangle rectangle2 = new Rectangle((int) ((double) Main.npc[index].position.X + (double) (Main.npc[index].width / 2)) - num, (int) ((double) Main.npc[index].position.Y + (double) (Main.npc[index].height / 2)) - num, num * 2, num * 2);
              if (rectangle1.Intersects(rectangle2))
              {
                flag3 = true;
                break;
              }
            }
            else if (Main.npc[index].type == 113 || Main.npc[index].type == 114 || Main.npc[index].type == 125 || Main.npc[index].type == 126)
            {
              Rectangle rectangle3 = new Rectangle((int) ((double) Main.npc[index].position.X + (double) (Main.npc[index].width / 2)) - num, (int) ((double) Main.npc[index].position.Y + (double) (Main.npc[index].height / 2)) - num, num * 2, num * 2);
              if (rectangle1.Intersects(rectangle3))
              {
                flag2 = true;
                break;
              }
            }
            else if (Main.npc[index].boss || Main.npc[index].type == 13 || Main.npc[index].type == 14 || Main.npc[index].type == 15 || Main.npc[index].type == 134 || Main.npc[index].type == 26 || Main.npc[index].type == 27 || Main.npc[index].type == 28 || Main.npc[index].type == 29 || Main.npc[index].type == 111)
            {
              Rectangle rectangle4 = new Rectangle((int) ((double) Main.npc[index].position.X + (double) (Main.npc[index].width / 2)) - num, (int) ((double) Main.npc[index].position.Y + (double) (Main.npc[index].height / 2)) - num, num * 2, num * 2);
              if (rectangle1.Intersects(rectangle4))
              {
                flag1 = true;
                break;
              }
            }
          }
        }
        if ((double) Main.musicVolume == 0.0)
          this.newMusic = 0;
        else if (Main.gameMenu)
          this.newMusic = Main.netMode == 2 ? 0 : 6;
        else if (flag2)
          this.newMusic = 12;
        else if (flag1)
          this.newMusic = 5;
        else if (flag3)
          this.newMusic = 13;
        else if ((double) Main.player[Main.myPlayer].position.Y > (double) ((Main.maxTilesY - 200) * 16))
          this.newMusic = 2;
        else if (Main.player[Main.myPlayer].zoneEvil)
          this.newMusic = (double) Main.player[Main.myPlayer].position.Y <= Main.worldSurface * 16.0 + (double) Main.screenHeight ? 8 : 10;
        else if (Main.player[Main.myPlayer].zoneMeteor || Main.player[Main.myPlayer].zoneDungeon)
          this.newMusic = 2;
        else if (Main.player[Main.myPlayer].zoneJungle)
          this.newMusic = 7;
        else if ((double) Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double) Main.screenHeight)
          this.newMusic = !Main.player[Main.myPlayer].zoneHoly ? 4 : 11;
        else if (Main.dayTime)
          this.newMusic = !Main.player[Main.myPlayer].zoneHoly ? 1 : 9;
        else if (!Main.dayTime)
          this.newMusic = !Main.bloodMoon ? 3 : 2;
        if (Main.gameMenu)
        {
          Main.musicBox2 = -1;
          Main.musicBox = -1;
        }
        if (Main.musicBox2 >= 0)
          Main.musicBox = Main.musicBox2;
        if (Main.musicBox >= 0)
        {
          if (Main.musicBox == 0)
            this.newMusic = 1;
          if (Main.musicBox == 1)
            this.newMusic = 2;
          if (Main.musicBox == 2)
            this.newMusic = 3;
          if (Main.musicBox == 4)
            this.newMusic = 4;
          if (Main.musicBox == 5)
            this.newMusic = 5;
          if (Main.musicBox == 3)
            this.newMusic = 6;
          if (Main.musicBox == 6)
            this.newMusic = 7;
          if (Main.musicBox == 7)
            this.newMusic = 8;
          if (Main.musicBox == 9)
            this.newMusic = 9;
          if (Main.musicBox == 8)
            this.newMusic = 10;
          if (Main.musicBox == 11)
            this.newMusic = 11;
          if (Main.musicBox == 10)
            this.newMusic = 12;
          if (Main.musicBox == 12)
            this.newMusic = 13;
        }
        Main.curMusic = this.newMusic;
        for (int index = 1; index < 14; ++index)
        {
          if (index == Main.curMusic)
          {
            if (!Main.music[index].IsPlaying)
            {
              Main.music[index] = Main.soundBank.GetCue("Music_" + (object) index);
              Main.music[index].Play();
              Main.music[index].SetVariable("Volume", Main.musicFade[index] * Main.musicVolume);
            }
            else
            {
              Main.musicFade[index] += 0.005f;
              if ((double) Main.musicFade[index] > 1.0)
                Main.musicFade[index] = 1f;
              Main.music[index].SetVariable("Volume", Main.musicFade[index] * Main.musicVolume);
            }
          }
          else if (Main.music[index].IsPlaying)
          {
            if ((double) Main.musicFade[Main.curMusic] > 0.25)
              Main.musicFade[index] -= 0.005f;
            else if (Main.curMusic == 0)
              Main.musicFade[index] = 0.0f;
            if ((double) Main.musicFade[index] <= 0.0)
            {
              Main.musicFade[index] -= 0.0f;
              Main.music[index].Stop(AudioStopOptions.Immediate);
            }
            else
              Main.music[index].SetVariable("Volume", Main.musicFade[index] * Main.musicVolume);
          }
          else
            Main.musicFade[index] = 0.0f;
        }
      }
      catch
      {
        Main.musicVolume = 0.0f;
      }
    }

    public static void snowing()
    {
      if (Main.gamePaused || Main.snowTiles <= 0 || (double) Main.player[Main.myPlayer].position.Y >= Main.worldSurface * 16.0)
        return;
      int maxValue = 800 / Main.snowTiles;
      int num1 = (int) (500.0 * (double) ((float) Main.screenWidth / 1920f));
      if ((double) Main.snowDust >= (double) num1 * ((double) Main.gfxQuality / 2.0 + 0.5) + (double) num1 * 0.100000001490116 || Main.rand.Next(maxValue) != 0)
        return;
      int num2 = Main.rand.Next(Main.screenWidth + 1000) - 500;
      int y = (int) Main.screenPosition.Y;
      if (Main.rand.Next(5) == 0)
        num2 = Main.rand.Next(500) - 500;
      else if (Main.rand.Next(5) == 0)
        num2 = Main.rand.Next(500) + Main.screenWidth;
      if (num2 < 0 || num2 > Main.screenWidth)
        y += Main.rand.Next((int) ((double) Main.screenHeight * 0.5)) + (int) ((double) Main.screenHeight * 0.1);
      int index = Dust.NewDust(new Vector2((float) (num2 + (int) Main.screenPosition.X), (float) y), 10, 10, 76);
      Main.dust[index].velocity.Y = (float) (3.0 + (double) Main.rand.Next(30) * 0.100000001490116);
      Main.dust[index].velocity.Y *= Main.dust[index].scale;
      Main.dust[index].velocity.X = Main.windSpeed + (float) Main.rand.Next(-10, 10) * 0.1f;
    }

    public static void checkXMas()
    {
      DateTime now = DateTime.Now;
      int day = now.Day;
      int month = now.Month;
      if (day >= 15 && month == 12)
        Main.xMas = true;
      else
        Main.xMas = false;
    }

    protected override void Update(GameTime gameTime)
    {
      if (Main.netMode != 2)
        Main.snowing();
      if (Main.chTitle)
      {
        Main.chTitle = false;
        this.SetTitle();
      }
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      WorldGen.destroyObject = false;
      if (!Main.dedServ)
      {
        if (Main.fixedTiming)
        {
          if (this.IsActive)
            this.IsFixedTimeStep = false;
          else
            this.IsFixedTimeStep = true;
        }
        else
          this.IsFixedTimeStep = true;
        this.graphics.SynchronizeWithVerticalRetrace = true;
        this.UpdateMusic();
        if (Main.showSplash)
          return;
        if (!Main.gameMenu && Main.netMode == 1)
        {
          if (!Main.saveTime.IsRunning)
            Main.saveTime.Start();
          if (Main.saveTime.ElapsedMilliseconds > 300000L)
          {
            Main.saveTime.Reset();
            WorldGen.saveToonWhilePlaying();
          }
        }
        else if (!Main.gameMenu && Main.autoSave)
        {
          if (!Main.saveTime.IsRunning)
            Main.saveTime.Start();
          if (Main.saveTime.ElapsedMilliseconds > 600000L)
          {
            Main.saveTime.Reset();
            WorldGen.saveToonWhilePlaying();
            WorldGen.saveAndPlay();
          }
        }
        else if (Main.saveTime.IsRunning)
          Main.saveTime.Stop();
        if (Main.teamCooldown > 0)
          --Main.teamCooldown;
        ++Main.updateTime;
        if (Main.fpsTimer.ElapsedMilliseconds >= 1000L)
        {
          if ((double) Main.fpsCount >= 30.0 + 30.0 * (double) Main.gfxQuality)
          {
            Main.gfxQuality += Main.gfxRate;
            Main.gfxRate += 0.005f;
          }
          else if ((double) Main.fpsCount < 29.0 + 30.0 * (double) Main.gfxQuality)
          {
            Main.gfxRate = 0.01f;
            Main.gfxQuality -= 0.1f;
          }
          if ((double) Main.gfxQuality < 0.0)
            Main.gfxQuality = 0.0f;
          if ((double) Main.gfxQuality > 1.0)
            Main.gfxQuality = 1f;
          if (Main.maxQ && this.IsActive)
          {
            Main.gfxQuality = 1f;
            Main.maxQ = false;
          }
          Main.updateRate = Main.uCount;
          Main.frameRate = Main.fpsCount;
          Main.fpsCount = 0;
          Main.fpsTimer.Restart();
          Main.updateTime = 0;
          Main.drawTime = 0;
          Main.uCount = 0;
          if (Main.netMode == 2)
            Main.cloudLimit = 0;
        }
        if (Main.fixedTiming)
        {
          float num = 16f;
          float elapsedMilliseconds = (float) Main.updateTimer.ElapsedMilliseconds;
          if ((double) elapsedMilliseconds + (double) Main.uCarry < (double) num)
          {
            Main.drawSkip = true;
            return;
          }
          Main.uCarry += elapsedMilliseconds - num;
          if ((double) Main.uCarry > 1000.0)
            Main.uCarry = 1000f;
          Main.updateTimer.Restart();
        }
        ++Main.uCount;
        Main.drawSkip = false;
        switch (Main.qaStyle)
        {
          case 1:
            Main.gfxQuality = 1f;
            break;
          case 2:
            Main.gfxQuality = 0.5f;
            break;
          case 3:
            Main.gfxQuality = 0.0f;
            break;
        }
        Main.numDust = (int) (2000.0 * ((double) Main.gfxQuality * 0.75 + 0.25));
        Gore.goreTime = (int) (600.0 * (double) Main.gfxQuality);
        Main.cloudLimit = (int) (100.0 * (double) Main.gfxQuality);
        Liquid.maxLiquid = (int) (2500.0 + 2500.0 * (double) Main.gfxQuality);
        Liquid.cycles = (int) (17.0 - 10.0 * (double) Main.gfxQuality);
        this.graphics.SynchronizeWithVerticalRetrace = (double) Main.gfxQuality >= 0.5;
        Lighting.maxRenderCount = (double) Main.gfxQuality >= 0.2 ? ((double) Main.gfxQuality >= 0.4 ? ((double) Main.gfxQuality >= 0.6 ? ((double) Main.gfxQuality >= 0.8 ? 4 : 5) : 6) : 7) : 8;
        if (Liquid.quickSettle)
        {
          Liquid.maxLiquid = Liquid.resLiquid;
          Liquid.cycles = 1;
        }
        Main.hasFocus = this.IsActive;
        if (!this.IsActive && Main.netMode == 0)
        {
          this.IsMouseVisible = true;
          if (Main.netMode != 2 && Main.myPlayer >= 0)
            Main.player[Main.myPlayer].delayUseItem = true;
          Main.mouseLeftRelease = false;
          Main.mouseRightRelease = false;
          if (Main.gameMenu)
            Main.UpdateMenu();
          Main.gamePaused = true;
          return;
        }
        this.IsMouseVisible = false;
        Main.demonTorch += (float) Main.demonTorchDir * 0.01f;
        if ((double) Main.demonTorch > 1.0)
        {
          Main.demonTorch = 1f;
          Main.demonTorchDir = -1;
        }
        if ((double) Main.demonTorch < 0.0)
        {
          Main.demonTorch = 0.0f;
          Main.demonTorchDir = 1;
        }
        int num1 = 7;
        if (this.DiscoStyle == 0)
        {
          Main.DiscoG += num1;
          if (Main.DiscoG >= (int) byte.MaxValue)
          {
            Main.DiscoG = (int) byte.MaxValue;
            ++this.DiscoStyle;
          }
          Main.DiscoR -= num1;
          if (Main.DiscoR <= 0)
            Main.DiscoR = 0;
        }
        else if (this.DiscoStyle == 1)
        {
          Main.DiscoB += num1;
          if (Main.DiscoB >= (int) byte.MaxValue)
          {
            Main.DiscoB = (int) byte.MaxValue;
            ++this.DiscoStyle;
          }
          Main.DiscoG -= num1;
          if (Main.DiscoG <= 0)
            Main.DiscoG = 0;
        }
        else
        {
          Main.DiscoR += num1;
          if (Main.DiscoR >= (int) byte.MaxValue)
          {
            Main.DiscoR = (int) byte.MaxValue;
            this.DiscoStyle = 0;
          }
          Main.DiscoB -= num1;
          if (Main.DiscoB <= 0)
            Main.DiscoB = 0;
        }
        if (Main.keyState.IsKeyDown(Keys.F10) && !Main.chatMode && !Main.editSign)
        {
          if (Main.frameRelease)
          {
            Main.PlaySound(12);
            Main.showFrameRate = !Main.showFrameRate;
          }
          Main.frameRelease = false;
        }
        else
          Main.frameRelease = true;
        if (Main.keyState.IsKeyDown(Keys.F9) && !Main.chatMode && !Main.editSign)
        {
          if (Main.RGBRelease)
          {
            Lighting.lightCounter += 100;
            Main.PlaySound(12);
            ++Lighting.lightMode;
            if (Lighting.lightMode >= 4)
              Lighting.lightMode = 0;
            if (Lighting.lightMode == 2 || Lighting.lightMode == 0)
            {
              Main.renderCount = 0;
              Main.renderNow = true;
              int num2 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
              int num3 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
              for (int index1 = 0; index1 < num2; ++index1)
              {
                for (int index2 = 0; index2 < num3; ++index2)
                {
                  Lighting.color[index1, index2] = 0.0f;
                  Lighting.colorG[index1, index2] = 0.0f;
                  Lighting.colorB[index1, index2] = 0.0f;
                }
              }
            }
          }
          Main.RGBRelease = false;
        }
        else
          Main.RGBRelease = true;
        if (Main.keyState.IsKeyDown(Keys.F8) && !Main.chatMode && !Main.editSign)
        {
          if (Main.netRelease)
          {
            Main.PlaySound(12);
            Main.netDiag = !Main.netDiag;
          }
          Main.netRelease = false;
        }
        else
          Main.netRelease = true;
        if (Main.keyState.IsKeyDown(Keys.F7) && !Main.chatMode && !Main.editSign)
        {
          if (Main.drawRelease)
          {
            Main.PlaySound(12);
            Main.drawDiag = !Main.drawDiag;
          }
          Main.drawRelease = false;
        }
        else
          Main.drawRelease = true;
        if (Main.keyState.IsKeyDown(Keys.F11))
        {
          if (Main.releaseUI)
            Main.hideUI = !Main.hideUI;
          Main.releaseUI = false;
        }
        else
          Main.releaseUI = true;
        if ((Main.keyState.IsKeyDown(Keys.LeftAlt) || Main.keyState.IsKeyDown(Keys.RightAlt)) && Main.keyState.IsKeyDown(Keys.Enter))
        {
          if (this.toggleFullscreen)
          {
            this.graphics.ToggleFullScreen();
            Main.chatRelease = false;
          }
          this.toggleFullscreen = false;
        }
        else
          this.toggleFullscreen = true;
        if (!Main.gamePad || Main.gameMenu)
        {
          Main.oldMouseState = Main.mouseState;
          Main.mouseState = Mouse.GetState();
          Main.mouseX = Main.mouseState.X;
          Main.mouseY = Main.mouseState.Y;
          Main.mouseLeft = false;
          Main.mouseRight = false;
          if (Main.mouseState.LeftButton == ButtonState.Pressed)
            Main.mouseLeft = true;
          if (Main.mouseState.RightButton == ButtonState.Pressed)
            Main.mouseRight = true;
        }
        Main.keyState = Keyboard.GetState();
        if (Main.editSign)
          Main.chatMode = false;
        if (Main.chatMode)
        {
          if (Main.keyState.IsKeyDown(Keys.Escape))
            Main.chatMode = false;
          string chatText = Main.chatText;
          Main.chatText = Main.GetInputText(Main.chatText);
          while ((double) Main.fontMouseText.MeasureString(Main.chatText).X > 470.0)
            Main.chatText = Main.chatText.Substring(0, Main.chatText.Length - 1);
          if (chatText != Main.chatText)
            Main.PlaySound(12);
          if (Main.inputTextEnter && Main.chatRelease)
          {
            if (Main.chatText != "")
              NetMessage.SendData(25, text: Main.chatText, number: Main.myPlayer);
            Main.chatText = "";
            Main.chatMode = false;
            Main.chatRelease = false;
            Main.player[Main.myPlayer].releaseHook = false;
            Main.player[Main.myPlayer].releaseThrow = false;
            Main.PlaySound(11);
          }
        }
        if (Main.keyState.IsKeyDown(Keys.Enter) && Main.netMode == 1 && !Main.keyState.IsKeyDown(Keys.LeftAlt) && !Main.keyState.IsKeyDown(Keys.RightAlt))
        {
          if (Main.chatRelease && !Main.chatMode && !Main.editSign && !Main.keyState.IsKeyDown(Keys.Escape))
          {
            Main.PlaySound(10);
            Main.chatMode = true;
            Main.clrInput();
            Main.chatText = "";
          }
          Main.chatRelease = false;
        }
        else
          Main.chatRelease = true;
        if (Main.gameMenu)
        {
          Main.UpdateMenu();
          if (Main.netMode != 2)
            return;
          Main.gamePaused = false;
        }
      }
      if (Main.netMode == 1)
      {
        for (int index = 0; index < 49; ++index)
        {
          if (Main.player[Main.myPlayer].inventory[index].IsNotTheSameAs(Main.clientPlayer.inventory[index]))
            NetMessage.SendData(5, text: Main.player[Main.myPlayer].inventory[index].name, number: Main.myPlayer, number2: ((float) index), number3: ((float) Main.player[Main.myPlayer].inventory[index].prefix));
        }
        if (Main.player[Main.myPlayer].armor[0].IsNotTheSameAs(Main.clientPlayer.armor[0]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[0].name, number: Main.myPlayer, number2: 49f, number3: ((float) Main.player[Main.myPlayer].armor[0].prefix));
        if (Main.player[Main.myPlayer].armor[1].IsNotTheSameAs(Main.clientPlayer.armor[1]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[1].name, number: Main.myPlayer, number2: 50f, number3: ((float) Main.player[Main.myPlayer].armor[1].prefix));
        if (Main.player[Main.myPlayer].armor[2].IsNotTheSameAs(Main.clientPlayer.armor[2]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[2].name, number: Main.myPlayer, number2: 51f, number3: ((float) Main.player[Main.myPlayer].armor[2].prefix));
        if (Main.player[Main.myPlayer].armor[3].IsNotTheSameAs(Main.clientPlayer.armor[3]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[3].name, number: Main.myPlayer, number2: 52f, number3: ((float) Main.player[Main.myPlayer].armor[3].prefix));
        if (Main.player[Main.myPlayer].armor[4].IsNotTheSameAs(Main.clientPlayer.armor[4]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[4].name, number: Main.myPlayer, number2: 53f, number3: ((float) Main.player[Main.myPlayer].armor[4].prefix));
        if (Main.player[Main.myPlayer].armor[5].IsNotTheSameAs(Main.clientPlayer.armor[5]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[5].name, number: Main.myPlayer, number2: 54f, number3: ((float) Main.player[Main.myPlayer].armor[5].prefix));
        if (Main.player[Main.myPlayer].armor[6].IsNotTheSameAs(Main.clientPlayer.armor[6]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[6].name, number: Main.myPlayer, number2: 55f, number3: ((float) Main.player[Main.myPlayer].armor[6].prefix));
        if (Main.player[Main.myPlayer].armor[7].IsNotTheSameAs(Main.clientPlayer.armor[7]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[7].name, number: Main.myPlayer, number2: 56f, number3: ((float) Main.player[Main.myPlayer].armor[7].prefix));
        if (Main.player[Main.myPlayer].armor[8].IsNotTheSameAs(Main.clientPlayer.armor[8]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[8].name, number: Main.myPlayer, number2: 57f, number3: ((float) Main.player[Main.myPlayer].armor[8].prefix));
        if (Main.player[Main.myPlayer].armor[9].IsNotTheSameAs(Main.clientPlayer.armor[9]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[9].name, number: Main.myPlayer, number2: 58f, number3: ((float) Main.player[Main.myPlayer].armor[9].prefix));
        if (Main.player[Main.myPlayer].armor[10].IsNotTheSameAs(Main.clientPlayer.armor[10]))
          NetMessage.SendData(5, text: Main.player[Main.myPlayer].armor[10].name, number: Main.myPlayer, number2: 59f, number3: ((float) Main.player[Main.myPlayer].armor[10].prefix));
        if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest)
          NetMessage.SendData(33, number: Main.player[Main.myPlayer].chest);
        if (Main.player[Main.myPlayer].talkNPC != Main.clientPlayer.talkNPC)
          NetMessage.SendData(40, number: Main.myPlayer);
        if (Main.player[Main.myPlayer].zoneEvil != Main.clientPlayer.zoneEvil)
          NetMessage.SendData(36, number: Main.myPlayer);
        if (Main.player[Main.myPlayer].zoneMeteor != Main.clientPlayer.zoneMeteor)
          NetMessage.SendData(36, number: Main.myPlayer);
        if (Main.player[Main.myPlayer].zoneDungeon != Main.clientPlayer.zoneDungeon)
          NetMessage.SendData(36, number: Main.myPlayer);
        if (Main.player[Main.myPlayer].zoneJungle != Main.clientPlayer.zoneJungle)
          NetMessage.SendData(36, number: Main.myPlayer);
        if (Main.player[Main.myPlayer].zoneHoly != Main.clientPlayer.zoneHoly)
          NetMessage.SendData(36, number: Main.myPlayer);
        bool flag = false;
        for (int index = 0; index < 10; ++index)
        {
          if (Main.player[Main.myPlayer].buffType[index] != Main.clientPlayer.buffType[index])
            flag = true;
        }
        if (flag)
        {
          NetMessage.SendData(50, number: Main.myPlayer);
          NetMessage.SendData(13, number: Main.myPlayer);
        }
      }
      if (Main.netMode == 1)
        Main.clientPlayer = (Player) Main.player[Main.myPlayer].clientClone();
      if (Main.netMode == 0 && (Main.playerInventory || Main.npcChatText != "" || Main.player[Main.myPlayer].sign >= 0) && Main.autoPause)
      {
        Keys[] pressedKeys = Main.keyState.GetPressedKeys();
        Main.player[Main.myPlayer].controlInv = false;
        for (int index = 0; index < pressedKeys.Length; ++index)
        {
          if (string.Concat((object) pressedKeys[index]) == Main.cInv)
            Main.player[Main.myPlayer].controlInv = true;
        }
        if (Main.player[Main.myPlayer].controlInv)
        {
          if (Main.player[Main.myPlayer].releaseInventory)
            Main.player[Main.myPlayer].toggleInv();
          Main.player[Main.myPlayer].releaseInventory = false;
        }
        else
          Main.player[Main.myPlayer].releaseInventory = true;
        if (Main.playerInventory)
        {
          int num = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
          Main.focusRecipe += num;
          if (Main.focusRecipe > Main.numAvailableRecipes - 1)
            Main.focusRecipe = Main.numAvailableRecipes - 1;
          if (Main.focusRecipe < 0)
            Main.focusRecipe = 0;
          Main.player[Main.myPlayer].dropItemCheck();
        }
        Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[0].headSlot;
        Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[1].bodySlot;
        Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[2].legSlot;
        if (!Main.player[Main.myPlayer].hostile)
        {
          if (Main.player[Main.myPlayer].armor[8].headSlot >= 0)
            Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[8].headSlot;
          if (Main.player[Main.myPlayer].armor[9].bodySlot >= 0)
            Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[9].bodySlot;
          if (Main.player[Main.myPlayer].armor[10].legSlot >= 0)
            Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[10].legSlot;
        }
        if (Main.editSign)
        {
          if (Main.player[Main.myPlayer].sign == -1)
          {
            Main.editSign = false;
          }
          else
          {
            Main.npcChatText = Main.GetInputText(Main.npcChatText);
            if (Main.inputTextEnter)
            {
              byte[] bytes = new byte[1]{ (byte) 10 };
              Main.npcChatText += Encoding.ASCII.GetString(bytes);
            }
          }
        }
        Main.gamePaused = true;
      }
      else
      {
        Main.gamePaused = false;
        if (!Main.dedServ && (double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && Main.netMode != 2)
        {
          Star.UpdateStars();
          Cloud.UpdateClouds();
        }
        for (int i = 0; i < (int) byte.MaxValue; ++i)
        {
          if (Main.ignoreErrors)
          {
            try
            {
              Main.player[i].UpdatePlayer(i);
            }
            catch
            {
            }
          }
          else
            Main.player[i].UpdatePlayer(i);
        }
        if (Main.netMode != 1)
          NPC.SpawnNPC();
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          Main.player[index].activeNPCs = 0.0f;
          Main.player[index].townNPCs = 0.0f;
        }
        if (Main.wof >= 0 && !Main.npc[Main.wof].active)
          Main.wof = -1;
        for (int i = 0; i < 200; ++i)
        {
          if (Main.ignoreErrors)
          {
            try
            {
              Main.npc[i].UpdateNPC(i);
            }
            catch (Exception ex)
            {
              Main.npc[i] = new NPC();
            }
          }
          else
            Main.npc[i].UpdateNPC(i);
        }
        for (int index = 0; index < 200; ++index)
        {
          if (Main.ignoreErrors)
          {
            try
            {
              Main.gore[index].Update();
            }
            catch
            {
              Main.gore[index] = new Gore();
            }
          }
          else
            Main.gore[index].Update();
        }
        for (int i = 0; i < 1000; ++i)
        {
          if (Main.ignoreErrors)
          {
            try
            {
              Main.projectile[i].Update(i);
            }
            catch
            {
              Main.projectile[i] = new Projectile();
            }
          }
          else
            Main.projectile[i].Update(i);
        }
        for (int i = 0; i < 200; ++i)
        {
          if (Main.ignoreErrors)
          {
            try
            {
              Main.item[i].UpdateItem(i);
            }
            catch
            {
              Main.item[i] = new Item();
            }
          }
          else
            Main.item[i].UpdateItem(i);
        }
        if (Main.ignoreErrors)
        {
          try
          {
            Dust.UpdateDust();
          }
          catch
          {
            for (int index = 0; index < 2000; ++index)
              Main.dust[index] = new Dust();
          }
        }
        else
          Dust.UpdateDust();
        if (Main.netMode != 2)
        {
          CombatText.UpdateCombatText();
          ItemText.UpdateItemText();
        }
        if (Main.ignoreErrors)
        {
          try
          {
            Main.UpdateTime();
          }
          catch
          {
            Main.checkForSpawns = 0;
          }
        }
        else
          Main.UpdateTime();
        if (Main.netMode != 1)
        {
          if (Main.ignoreErrors)
          {
            try
            {
              WorldGen.UpdateWorld();
              Main.UpdateInvasion();
            }
            catch
            {
            }
          }
          else
          {
            WorldGen.UpdateWorld();
            Main.UpdateInvasion();
          }
        }
        if (Main.ignoreErrors)
        {
          try
          {
            if (Main.netMode == 2)
              Main.UpdateServer();
            if (Main.netMode == 1)
              Main.UpdateClient();
          }
          catch
          {
            int netMode = Main.netMode;
          }
        }
        else
        {
          if (Main.netMode == 2)
            Main.UpdateServer();
          if (Main.netMode == 1)
            Main.UpdateClient();
        }
        if (Main.ignoreErrors)
        {
          try
          {
            for (int index = 0; index < Main.numChatLines; ++index)
            {
              if (Main.chatLine[index].showTime > 0)
                --Main.chatLine[index].showTime;
            }
          }
          catch
          {
            for (int index = 0; index < Main.numChatLines; ++index)
              Main.chatLine[index] = new ChatLine();
          }
        }
        else
        {
          for (int index = 0; index < Main.numChatLines; ++index)
          {
            if (Main.chatLine[index].showTime > 0)
              --Main.chatLine[index].showTime;
          }
        }
        Main.upTimer = (float) stopwatch.ElapsedMilliseconds;
        if ((double) Main.upTimerMaxDelay > 0.0)
          --Main.upTimerMaxDelay;
        else
          Main.upTimerMax = 0.0f;
        if ((double) Main.upTimer > (double) Main.upTimerMax)
        {
          Main.upTimerMax = Main.upTimer;
          Main.upTimerMaxDelay = 400f;
        }
        base.Update(gameTime);
      }
    }

    private static void UpdateMenu()
    {
      Main.playerInventory = false;
      Main.exitScale = 0.8f;
      switch (Main.netMode)
      {
        case 0:
          if (Main.grabSky)
            break;
          Main.time += 86.4;
          if (!Main.dayTime)
          {
            if (Main.time <= 32400.0)
              break;
            Main.bloodMoon = false;
            Main.time = 0.0;
            Main.dayTime = true;
            ++Main.moonPhase;
            if (Main.moonPhase < 8)
              break;
            Main.moonPhase = 0;
            break;
          }
          if (Main.time <= 54000.0)
            break;
          Main.time = 0.0;
          Main.dayTime = false;
          break;
        case 1:
          Main.UpdateTime();
          break;
      }
    }

    public static void clrInput() => Main.keyCount = 0;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern short GetKeyState(int keyCode);

    public static string GetInputText(string oldString)
    {
      if (!Main.hasFocus)
        return oldString;
      Main.inputTextEnter = false;
      string str1 = oldString;
      string str2 = "";
      if (str1 == null)
        str1 = "";
      bool flag1 = false;
      for (int index = 0; index < Main.keyCount; ++index)
      {
        int num = Main.keyInt[index];
        string str3 = Main.keyString[index];
        if (num == 13)
          Main.inputTextEnter = true;
        else if (num >= 32 && num != (int) sbyte.MaxValue)
          str2 += str3;
      }
      Main.keyCount = 0;
      string str4 = str1 + str2;
      Main.oldInputText = Main.inputText;
      Main.inputText = Keyboard.GetState();
      Keys[] pressedKeys1 = Main.inputText.GetPressedKeys();
      Keys[] pressedKeys2 = Main.oldInputText.GetPressedKeys();
      if (Main.inputText.IsKeyDown(Keys.Back) && Main.oldInputText.IsKeyDown(Keys.Back))
      {
        if (Main.backSpaceCount == 0)
        {
          Main.backSpaceCount = 7;
          flag1 = true;
        }
        --Main.backSpaceCount;
      }
      else
        Main.backSpaceCount = 15;
      for (int index1 = 0; index1 < pressedKeys1.Length; ++index1)
      {
        bool flag2 = true;
        for (int index2 = 0; index2 < pressedKeys2.Length; ++index2)
        {
          if (pressedKeys1[index1] == pressedKeys2[index2])
            flag2 = false;
        }
        if (string.Concat((object) pressedKeys1[index1]) == "Back" && (flag2 || flag1) && str4.Length > 0)
          str4 = str4.Substring(0, str4.Length - 1);
      }
      return str4;
    }

    protected void MouseText(string cursorText, int rare = 0, byte diff = 0)
    {
      if (this.mouseNPC > -1 || cursorText == null)
        return;
      int num1 = Main.mouseX + 10;
      int num2 = Main.mouseY + 10;
      Microsoft.Xna.Framework.Color color1 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
      if (Main.toolTip.type > 0)
      {
        if (Main.player[Main.myPlayer].kbGlove)
          Main.toolTip.knockBack *= 1.7f;
        rare = Main.toolTip.rare;
        int length = 20;
        int index1 = 1;
        string[] strArray1 = new string[length];
        bool[] flagArray1 = new bool[length];
        bool[] flagArray2 = new bool[length];
        for (int index2 = 0; index2 < length; ++index2)
        {
          flagArray1[index2] = false;
          flagArray2[index2] = false;
        }
        strArray1[0] = Main.toolTip.AffixName();
        if (Main.toolTip.stack > 1)
        {
          string[] strArray2;
          string str = (strArray2 = strArray1)[0] + " (" + (object) Main.toolTip.stack + ")";
          strArray2[0] = str;
        }
        if (Main.toolTip.social)
        {
          strArray1[index1] = Lang.tip[0];
          int index3 = index1 + 1;
          strArray1[index3] = Lang.tip[1];
          index1 = index3 + 1;
        }
        else
        {
          if (Main.toolTip.damage > 0)
          {
            int damage = Main.toolTip.damage;
            if (Main.toolTip.melee)
            {
              strArray1[index1] = string.Concat((object) (int) ((double) Main.player[Main.myPlayer].meleeDamage * (double) damage));
              string[] strArray3;
              IntPtr index4;
              (strArray3 = strArray1)[(int) (index4 = (IntPtr) index1)] = strArray3[index4] + Lang.tip[2];
            }
            else if (Main.toolTip.ranged)
            {
              strArray1[index1] = string.Concat((object) (int) ((double) Main.player[Main.myPlayer].rangedDamage * (double) damage));
              string[] strArray4;
              IntPtr index5;
              (strArray4 = strArray1)[(int) (index5 = (IntPtr) index1)] = strArray4[index5] + Lang.tip[3];
            }
            else if (Main.toolTip.magic)
            {
              strArray1[index1] = string.Concat((object) (int) ((double) Main.player[Main.myPlayer].magicDamage * (double) damage));
              string[] strArray5;
              IntPtr index6;
              (strArray5 = strArray1)[(int) (index6 = (IntPtr) index1)] = strArray5[index6] + Lang.tip[4];
            }
            else
              strArray1[index1] = string.Concat((object) damage);
            int index7 = index1 + 1;
            if (Main.toolTip.melee)
            {
              int num3 = Main.player[Main.myPlayer].meleeCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
              strArray1[index7] = num3.ToString() + Lang.tip[5];
              ++index7;
            }
            else if (Main.toolTip.ranged)
            {
              int num4 = Main.player[Main.myPlayer].rangedCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
              strArray1[index7] = num4.ToString() + Lang.tip[5];
              ++index7;
            }
            else if (Main.toolTip.magic)
            {
              int num5 = Main.player[Main.myPlayer].magicCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
              strArray1[index7] = num5.ToString() + Lang.tip[5];
              ++index7;
            }
            if (Main.toolTip.useStyle > 0)
            {
              strArray1[index7] = Main.toolTip.useAnimation > 8 ? (Main.toolTip.useAnimation > 20 ? (Main.toolTip.useAnimation > 25 ? (Main.toolTip.useAnimation > 30 ? (Main.toolTip.useAnimation > 35 ? (Main.toolTip.useAnimation > 45 ? (Main.toolTip.useAnimation > 55 ? Lang.tip[13] : Lang.tip[12]) : Lang.tip[11]) : Lang.tip[10]) : Lang.tip[9]) : Lang.tip[8]) : Lang.tip[7]) : Lang.tip[6];
              ++index7;
            }
            strArray1[index7] = (double) Main.toolTip.knockBack != 0.0 ? ((double) Main.toolTip.knockBack > 1.5 ? ((double) Main.toolTip.knockBack > 3.0 ? ((double) Main.toolTip.knockBack > 4.0 ? ((double) Main.toolTip.knockBack > 6.0 ? ((double) Main.toolTip.knockBack > 7.0 ? ((double) Main.toolTip.knockBack > 9.0 ? ((double) Main.toolTip.knockBack > 11.0 ? Lang.tip[22] : Lang.tip[21]) : Lang.tip[20]) : Lang.tip[19]) : Lang.tip[18]) : Lang.tip[17]) : Lang.tip[16]) : Lang.tip[15]) : Lang.tip[14];
            index1 = index7 + 1;
          }
          if (Main.toolTip.headSlot > 0 || Main.toolTip.bodySlot > 0 || Main.toolTip.legSlot > 0 || Main.toolTip.accessory)
          {
            strArray1[index1] = Lang.tip[23];
            ++index1;
          }
          if (Main.toolTip.vanity)
          {
            strArray1[index1] = Lang.tip[24];
            ++index1;
          }
          if (Main.toolTip.defense > 0)
          {
            strArray1[index1] = Main.toolTip.defense.ToString() + Lang.tip[25];
            ++index1;
          }
          if (Main.toolTip.pick > 0)
          {
            strArray1[index1] = Main.toolTip.pick.ToString() + Lang.tip[26];
            ++index1;
          }
          if (Main.toolTip.axe > 0)
          {
            strArray1[index1] = (Main.toolTip.axe * 5).ToString() + Lang.tip[27];
            ++index1;
          }
          if (Main.toolTip.hammer > 0)
          {
            strArray1[index1] = Main.toolTip.hammer.ToString() + Lang.tip[28];
            ++index1;
          }
          if (Main.toolTip.healLife > 0)
          {
            strArray1[index1] = Lang.tip[29] + " " + (object) Main.toolTip.healLife + " " + Lang.tip[30];
            ++index1;
          }
          if (Main.toolTip.healMana > 0)
          {
            strArray1[index1] = Lang.tip[29] + " " + (object) Main.toolTip.healMana + " " + Lang.tip[31];
            ++index1;
          }
          if (Main.toolTip.mana > 0 && (Main.toolTip.type != (int) sbyte.MaxValue || !Main.player[Main.myPlayer].spaceGun))
          {
            strArray1[index1] = Lang.tip[32] + " " + (object) (int) ((double) Main.toolTip.mana * (double) Main.player[Main.myPlayer].manaCost) + " " + Lang.tip[31];
            ++index1;
          }
          if (Main.toolTip.createWall > 0 || Main.toolTip.createTile > -1)
          {
            if (Main.toolTip.type != 213)
            {
              strArray1[index1] = Lang.tip[33];
              ++index1;
            }
          }
          else if (Main.toolTip.ammo > 0)
          {
            strArray1[index1] = Lang.tip[34];
            ++index1;
          }
          else if (Main.toolTip.consumable)
          {
            strArray1[index1] = Lang.tip[35];
            ++index1;
          }
          if (Main.toolTip.material)
          {
            strArray1[index1] = Lang.tip[36];
            ++index1;
          }
          if (Main.toolTip.toolTip != null)
          {
            strArray1[index1] = Main.toolTip.toolTip;
            ++index1;
          }
          if (Main.toolTip.toolTip2 != null)
          {
            strArray1[index1] = Main.toolTip.toolTip2;
            ++index1;
          }
          if (Main.toolTip.buffTime > 0)
          {
            string str = Main.toolTip.buffTime / 60 < 60 ? Math.Round((double) Main.toolTip.buffTime / 60.0).ToString() + Lang.tip[38] : Math.Round((double) (Main.toolTip.buffTime / 60) / 60.0).ToString() + Lang.tip[37];
            strArray1[index1] = str;
            ++index1;
          }
          if (Main.toolTip.prefix > (byte) 0)
          {
            if (Main.cpItem == null || Main.cpItem.netID != Main.toolTip.netID)
            {
              Main.cpItem = new Item();
              Main.cpItem.netDefaults(Main.toolTip.netID);
            }
            if (Main.cpItem.damage != Main.toolTip.damage)
            {
              double num6 = Math.Round(((double) Main.toolTip.damage - (double) Main.cpItem.damage) / (double) Main.cpItem.damage * 100.0);
              strArray1[index1] = num6 <= 0.0 ? num6.ToString() + Lang.tip[39] : "+" + (object) num6 + Lang.tip[39];
              if (num6 < 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.cpItem.useAnimation != Main.toolTip.useAnimation)
            {
              double num7 = Math.Round(((double) Main.toolTip.useAnimation - (double) Main.cpItem.useAnimation) / (double) Main.cpItem.useAnimation * 100.0) * -1.0;
              strArray1[index1] = num7 <= 0.0 ? num7.ToString() + Lang.tip[40] : "+" + (object) num7 + Lang.tip[40];
              if (num7 < 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.cpItem.crit != Main.toolTip.crit)
            {
              double num8 = (double) Main.toolTip.crit - (double) Main.cpItem.crit;
              strArray1[index1] = num8 <= 0.0 ? num8.ToString() + Lang.tip[41] : "+" + (object) num8 + Lang.tip[41];
              if (num8 < 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.cpItem.mana != Main.toolTip.mana)
            {
              double num9 = Math.Round(((double) Main.toolTip.mana - (double) Main.cpItem.mana) / (double) Main.cpItem.mana * 100.0);
              strArray1[index1] = num9 <= 0.0 ? num9.ToString() + Lang.tip[42] : "+" + (object) num9 + Lang.tip[42];
              if (num9 > 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if ((double) Main.cpItem.scale != (double) Main.toolTip.scale)
            {
              double num10 = Math.Round(((double) Main.toolTip.scale - (double) Main.cpItem.scale) / (double) Main.cpItem.scale * 100.0);
              strArray1[index1] = num10 <= 0.0 ? num10.ToString() + Lang.tip[43] : "+" + (object) num10 + Lang.tip[43];
              if (num10 < 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if ((double) Main.cpItem.shootSpeed != (double) Main.toolTip.shootSpeed)
            {
              double num11 = Math.Round(((double) Main.toolTip.shootSpeed - (double) Main.cpItem.shootSpeed) / (double) Main.cpItem.shootSpeed * 100.0);
              strArray1[index1] = num11 <= 0.0 ? num11.ToString() + Lang.tip[44] : "+" + (object) num11 + Lang.tip[44];
              if (num11 < 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if ((double) Main.cpItem.knockBack != (double) Main.toolTip.knockBack)
            {
              double num12 = Math.Round(((double) Main.toolTip.knockBack - (double) Main.cpItem.knockBack) / (double) Main.cpItem.knockBack * 100.0);
              strArray1[index1] = num12 <= 0.0 ? num12.ToString() + Lang.tip[45] : "+" + (object) num12 + Lang.tip[45];
              if (num12 < 0.0)
                flagArray2[index1] = true;
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 62)
            {
              strArray1[index1] = "+1" + Lang.tip[25];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 63)
            {
              strArray1[index1] = "+2" + Lang.tip[25];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 64)
            {
              strArray1[index1] = "+3" + Lang.tip[25];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 65)
            {
              strArray1[index1] = "+4" + Lang.tip[25];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 66)
            {
              strArray1[index1] = "+20 " + Lang.tip[31];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 67)
            {
              strArray1[index1] = "+1% " + Lang.tip[5];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 68)
            {
              strArray1[index1] = "+2% " + Lang.tip[5];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 69)
            {
              strArray1[index1] = "+1" + Lang.tip[39];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 70)
            {
              strArray1[index1] = "+2" + Lang.tip[39];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 71)
            {
              strArray1[index1] = "+3" + Lang.tip[39];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 72)
            {
              strArray1[index1] = "+4" + Lang.tip[39];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 73)
            {
              strArray1[index1] = "+1" + Lang.tip[46];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 74)
            {
              strArray1[index1] = "+2" + Lang.tip[46];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 75)
            {
              strArray1[index1] = "+3" + Lang.tip[46];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 76)
            {
              strArray1[index1] = "+4" + Lang.tip[46];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 77)
            {
              strArray1[index1] = "+1" + Lang.tip[47];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 78)
            {
              strArray1[index1] = "+2" + Lang.tip[47];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 79)
            {
              strArray1[index1] = "+3" + Lang.tip[47];
              flagArray1[index1] = true;
              ++index1;
            }
            if (Main.toolTip.prefix == (byte) 80)
            {
              strArray1[index1] = "+4" + Lang.tip[47];
              flagArray1[index1] = true;
              ++index1;
            }
          }
          if (Main.toolTip.wornArmor && Main.player[Main.myPlayer].setBonus != "")
          {
            strArray1[index1] = Lang.tip[48] + " " + Main.player[Main.myPlayer].setBonus;
            ++index1;
          }
        }
        if (Main.npcShop > 0)
        {
          if (Main.toolTip.value > 0)
          {
            string str = "";
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            int num17 = Main.toolTip.value * Main.toolTip.stack;
            if (!Main.toolTip.buy)
              num17 = Main.toolTip.value / 5 * Main.toolTip.stack;
            if (num17 < 1)
              num17 = 1;
            if (num17 >= 1000000)
            {
              num13 = num17 / 1000000;
              num17 -= num13 * 1000000;
            }
            if (num17 >= 10000)
            {
              num14 = num17 / 10000;
              num17 -= num14 * 10000;
            }
            if (num17 >= 100)
            {
              num15 = num17 / 100;
              num17 -= num15 * 100;
            }
            if (num17 >= 1)
              num16 = num17;
            if (num13 > 0)
              str = str + (object) num13 + " " + Lang.inter[15];
            if (num14 > 0)
              str = str + (object) num14 + " " + Lang.inter[16];
            if (num15 > 0)
              str = str + (object) num15 + " " + Lang.inter[17];
            if (num16 > 0)
              str = str + (object) num16 + " " + Lang.inter[18];
            strArray1[index1] = Main.toolTip.buy ? Lang.tip[50] + " " + str : Lang.tip[49] + " " + str;
            ++index1;
            float num18 = (float) Main.mouseTextColor / (float) byte.MaxValue;
            if (num13 > 0)
              color1 = new Microsoft.Xna.Framework.Color((int) (byte) (220.0 * (double) num18), (int) (byte) (220.0 * (double) num18), (int) (byte) (198.0 * (double) num18), (int) Main.mouseTextColor);
            else if (num14 > 0)
              color1 = new Microsoft.Xna.Framework.Color((int) (byte) (224.0 * (double) num18), (int) (byte) (201.0 * (double) num18), (int) (byte) (92.0 * (double) num18), (int) Main.mouseTextColor);
            else if (num15 > 0)
              color1 = new Microsoft.Xna.Framework.Color((int) (byte) (181.0 * (double) num18), (int) (byte) (192.0 * (double) num18), (int) (byte) (193.0 * (double) num18), (int) Main.mouseTextColor);
            else if (num16 > 0)
              color1 = new Microsoft.Xna.Framework.Color((int) (byte) (246.0 * (double) num18), (int) (byte) (138.0 * (double) num18), (int) (byte) (96.0 * (double) num18), (int) Main.mouseTextColor);
          }
          else
          {
            float num19 = (float) Main.mouseTextColor / (float) byte.MaxValue;
            strArray1[index1] = Lang.tip[51];
            ++index1;
            color1 = new Microsoft.Xna.Framework.Color((int) (byte) (120.0 * (double) num19), (int) (byte) (120.0 * (double) num19), (int) (byte) (120.0 * (double) num19), (int) Main.mouseTextColor);
          }
        }
        Vector2 vector2_1 = new Vector2();
        int num20 = 0;
        for (int index8 = 0; index8 < index1; ++index8)
        {
          Vector2 vector2_2 = Main.fontMouseText.MeasureString(strArray1[index8]);
          if ((double) vector2_2.X > (double) vector2_1.X)
            vector2_1.X = vector2_2.X;
          vector2_1.Y += vector2_2.Y + (float) num20;
        }
        if ((double) num1 + (double) vector2_1.X + 4.0 > (double) Main.screenWidth)
          num1 = (int) ((double) Main.screenWidth - (double) vector2_1.X - 4.0);
        if ((double) num2 + (double) vector2_1.Y + 4.0 > (double) Main.screenHeight)
          num2 = (int) ((double) Main.screenHeight - (double) vector2_1.Y - 4.0);
        int num21 = 0;
        float num22 = (float) Main.mouseTextColor / (float) byte.MaxValue;
        for (int index9 = 0; index9 < index1; ++index9)
        {
          for (int index10 = 0; index10 < 5; ++index10)
          {
            int num23 = num1;
            int num24 = num2 + num21;
            Microsoft.Xna.Framework.Color color2 = Microsoft.Xna.Framework.Color.Black;
            if (index10 == 0)
              num23 -= 2;
            else if (index10 == 1)
              num23 += 2;
            else if (index10 == 2)
              num24 -= 2;
            else if (index10 == 3)
            {
              num24 += 2;
            }
            else
            {
              color2 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
              if (index9 == 0)
              {
                if (rare == -1)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) (130.0 * (double) num22), (int) (byte) (130.0 * (double) num22), (int) (byte) (130.0 * (double) num22), (int) Main.mouseTextColor);
                if (rare == 1)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) (150.0 * (double) num22), (int) (byte) (150.0 * (double) num22), (int) (byte) ((double) byte.MaxValue * (double) num22), (int) Main.mouseTextColor);
                if (rare == 2)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) (150.0 * (double) num22), (int) (byte) ((double) byte.MaxValue * (double) num22), (int) (byte) (150.0 * (double) num22), (int) Main.mouseTextColor);
                if (rare == 3)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) byte.MaxValue * (double) num22), (int) (byte) (200.0 * (double) num22), (int) (byte) (150.0 * (double) num22), (int) Main.mouseTextColor);
                if (rare == 4)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) byte.MaxValue * (double) num22), (int) (byte) (150.0 * (double) num22), (int) (byte) (150.0 * (double) num22), (int) Main.mouseTextColor);
                if (rare == 5)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) byte.MaxValue * (double) num22), (int) (byte) (150.0 * (double) num22), (int) (byte) ((double) byte.MaxValue * (double) num22), (int) Main.mouseTextColor);
                if (rare == 6)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) (210.0 * (double) num22), (int) (byte) (160.0 * (double) num22), (int) (byte) ((double) byte.MaxValue * (double) num22), (int) Main.mouseTextColor);
                if (diff == (byte) 1)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.mcColor.R * (double) num22), (int) (byte) ((double) Main.mcColor.G * (double) num22), (int) (byte) ((double) Main.mcColor.B * (double) num22), (int) Main.mouseTextColor);
                if (diff == (byte) 2)
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.hcColor.R * (double) num22), (int) (byte) ((double) Main.hcColor.G * (double) num22), (int) (byte) ((double) Main.hcColor.B * (double) num22), (int) Main.mouseTextColor);
              }
              else if (flagArray1[index9])
                color2 = !flagArray2[index9] ? new Microsoft.Xna.Framework.Color((int) (byte) (120.0 * (double) num22), (int) (byte) (190.0 * (double) num22), (int) (byte) (120.0 * (double) num22), (int) Main.mouseTextColor) : new Microsoft.Xna.Framework.Color((int) (byte) (190.0 * (double) num22), (int) (byte) (120.0 * (double) num22), (int) (byte) (120.0 * (double) num22), (int) Main.mouseTextColor);
              else if (index9 == index1 - 1)
                color2 = color1;
            }
            this.spriteBatch.DrawString(Main.fontMouseText, strArray1[index9], new Vector2((float) num23, (float) num24), color2, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          num21 += (int) ((double) Main.fontMouseText.MeasureString(strArray1[index9]).Y + (double) num20);
        }
      }
      else
      {
        if (Main.buffString != "" && Main.buffString != null)
        {
          for (int index = 0; index < 5; ++index)
          {
            int num25 = num1;
            int num26 = num2 + (int) Main.fontMouseText.MeasureString(Main.buffString).Y;
            Microsoft.Xna.Framework.Color color3 = Microsoft.Xna.Framework.Color.Black;
            if (index == 0)
              num25 -= 2;
            else if (index == 1)
              num25 += 2;
            else if (index == 2)
              num26 -= 2;
            else if (index == 3)
              num26 += 2;
            else
              color3 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
            this.spriteBatch.DrawString(Main.fontMouseText, Main.buffString, new Vector2((float) num25, (float) num26), color3, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
        }
        Vector2 vector2 = Main.fontMouseText.MeasureString(cursorText);
        if ((double) num1 + (double) vector2.X + 4.0 > (double) Main.screenWidth)
          num1 = (int) ((double) Main.screenWidth - (double) vector2.X - 4.0);
        if ((double) num2 + (double) vector2.Y + 4.0 > (double) Main.screenHeight)
          num2 = (int) ((double) Main.screenHeight - (double) vector2.Y - 4.0);
        this.spriteBatch.DrawString(Main.fontMouseText, cursorText, new Vector2((float) num1, (float) (num2 - 2)), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(Main.fontMouseText, cursorText, new Vector2((float) num1, (float) (num2 + 2)), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(Main.fontMouseText, cursorText, new Vector2((float) (num1 - 2), (float) num2), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(Main.fontMouseText, cursorText, new Vector2((float) (num1 + 2), (float) num2), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        float num27 = (float) Main.mouseTextColor / (float) byte.MaxValue;
        Microsoft.Xna.Framework.Color color4 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
        if (rare == -1)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) (130.0 * (double) num27), (int) (byte) (130.0 * (double) num27), (int) (byte) (130.0 * (double) num27), (int) Main.mouseTextColor);
        if (rare == 6)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) (210.0 * (double) num27), (int) (byte) (160.0 * (double) num27), (int) (byte) ((double) byte.MaxValue * (double) num27), (int) Main.mouseTextColor);
        if (rare == 1)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) (150.0 * (double) num27), (int) (byte) (150.0 * (double) num27), (int) (byte) ((double) byte.MaxValue * (double) num27), (int) Main.mouseTextColor);
        if (rare == 2)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) (150.0 * (double) num27), (int) (byte) ((double) byte.MaxValue * (double) num27), (int) (byte) (150.0 * (double) num27), (int) Main.mouseTextColor);
        if (rare == 3)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) byte.MaxValue * (double) num27), (int) (byte) (200.0 * (double) num27), (int) (byte) (150.0 * (double) num27), (int) Main.mouseTextColor);
        if (rare == 4)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) byte.MaxValue * (double) num27), (int) (byte) (150.0 * (double) num27), (int) (byte) (150.0 * (double) num27), (int) Main.mouseTextColor);
        if (rare == 5)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) byte.MaxValue * (double) num27), (int) (byte) (150.0 * (double) num27), (int) (byte) ((double) byte.MaxValue * (double) num27), (int) Main.mouseTextColor);
        if (diff == (byte) 1)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.mcColor.R * (double) num27), (int) (byte) ((double) Main.mcColor.G * (double) num27), (int) (byte) ((double) Main.mcColor.B * (double) num27), (int) Main.mouseTextColor);
        if (diff == (byte) 2)
          color4 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.hcColor.R * (double) num27), (int) (byte) ((double) Main.hcColor.G * (double) num27), (int) (byte) ((double) Main.hcColor.B * (double) num27), (int) Main.mouseTextColor);
        this.spriteBatch.DrawString(Main.fontMouseText, cursorText, new Vector2((float) num1, (float) num2), color4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
      }
    }

    protected void DrawFPS()
    {
      if (!Main.showFrameRate)
        return;
      string str = string.Concat((object) Main.frameRate) + " (" + (object) (int) ((double) Main.gfxQuality * 100.0) + "%)";
      int num = 4;
      if (!Main.gameMenu)
        num = Main.screenHeight - 24;
      this.spriteBatch.DrawString(Main.fontMouseText, str + " " + Main.debugWords, new Vector2(4f, (float) num), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
    }

    public static Microsoft.Xna.Framework.Color shine(Microsoft.Xna.Framework.Color newColor, int type)
    {
      int r1 = (int) newColor.R;
      int r2 = (int) newColor.R;
      int r3 = (int) newColor.R;
      float num1 = 0.6f;
      int num2;
      int num3;
      int num4;
      switch (type)
      {
        case 25:
          num2 = (int) ((double) newColor.R * 0.949999988079071);
          num3 = (int) ((double) newColor.G * 0.850000023841858);
          num4 = (int) ((double) newColor.B * 1.1);
          break;
        case 117:
          num2 = (int) ((double) newColor.R * 1.10000002384186);
          num3 = (int) ((double) newColor.G * 1.0);
          num4 = (int) ((double) newColor.B * 1.2);
          break;
        default:
          num2 = (int) ((double) newColor.R * (1.0 + (double) num1));
          num3 = (int) ((double) newColor.G * (1.0 + (double) num1));
          num4 = (int) ((double) newColor.B * (1.0 + (double) num1));
          break;
      }
      if (num2 > (int) byte.MaxValue)
        num2 = (int) byte.MaxValue;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      if (num4 > (int) byte.MaxValue)
        num4 = (int) byte.MaxValue;
      newColor.R = (byte) num2;
      newColor.G = (byte) num3;
      newColor.B = (byte) num4;
      return new Microsoft.Xna.Framework.Color((int) (byte) num2, (int) (byte) num3, (int) (byte) num4, (int) newColor.A);
    }

    protected void DrawTiles(bool solidOnly = true)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num1 = (int) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 30.0 * (double) Main.gfxQuality);
      int num2 = (int) (50.0 * (1.0 - (double) Main.gfxQuality) + 2.0 * (double) Main.gfxQuality);
      Vector2 vector2_1 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2_1 = new Vector2();
      int index1 = 0;
      int[] numArray1 = new int[1000];
      int[] numArray2 = new int[1000];
      int num3 = (int) (((double) Main.screenPosition.X - (double) vector2_1.X) / 16.0 - 1.0);
      int num4 = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth + (double) vector2_1.X) / 16.0) + 2;
      int num5 = (int) (((double) Main.screenPosition.Y - (double) vector2_1.Y) / 16.0 - 1.0);
      int num6 = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight + (double) vector2_1.Y) / 16.0) + 5;
      if (num3 < 0)
        num3 = 0;
      if (num4 > Main.maxTilesX)
        num4 = Main.maxTilesX;
      if (num5 < 0)
        num5 = 0;
      if (num6 > Main.maxTilesY)
        num6 = Main.maxTilesY;
      for (int index2 = num5; index2 < num6 + 4; ++index2)
      {
        for (int x = num3 - 2; x < num4 + 2; ++x)
        {
          if (Main.tile[x, index2] == null)
            Main.tile[x, index2] = new Tile();
          bool flag1 = Main.tileSolid[(int) Main.tile[x, index2].type];
          if (Main.tile[x, index2].type == (byte) 11)
            flag1 = true;
          if (Main.tile[x, index2].active && flag1 == solidOnly)
          {
            Microsoft.Xna.Framework.Color color1 = Lighting.GetColor(x, index2);
            int num7 = 0;
            if (Main.tile[x, index2].type == (byte) 78 || Main.tile[x, index2].type == (byte) 85)
              num7 = 2;
            if (Main.tile[x, index2].type == (byte) 33 || Main.tile[x, index2].type == (byte) 49)
              num7 = -4;
            int height1;
            if (Main.tile[x, index2].type == (byte) 3 || Main.tile[x, index2].type == (byte) 4 || Main.tile[x, index2].type == (byte) 5 || Main.tile[x, index2].type == (byte) 24 || Main.tile[x, index2].type == (byte) 33 || Main.tile[x, index2].type == (byte) 49 || Main.tile[x, index2].type == (byte) 61 || Main.tile[x, index2].type == (byte) 71 || Main.tile[x, index2].type == (byte) 110)
              height1 = 20;
            else if (Main.tile[x, index2].type == (byte) 15 || Main.tile[x, index2].type == (byte) 14 || Main.tile[x, index2].type == (byte) 16 || Main.tile[x, index2].type == (byte) 17 || Main.tile[x, index2].type == (byte) 18 || Main.tile[x, index2].type == (byte) 20 || Main.tile[x, index2].type == (byte) 21 || Main.tile[x, index2].type == (byte) 26 || Main.tile[x, index2].type == (byte) 27 || Main.tile[x, index2].type == (byte) 32 || Main.tile[x, index2].type == (byte) 69 || Main.tile[x, index2].type == (byte) 72 || Main.tile[x, index2].type == (byte) 77 || Main.tile[x, index2].type == (byte) 80)
              height1 = 18;
            else if (Main.tile[x, index2].type == (byte) 137)
              height1 = 18;
            else if (Main.tile[x, index2].type == (byte) 135)
            {
              num7 = 2;
              height1 = 18;
            }
            else if (Main.tile[x, index2].type == (byte) 132)
            {
              num7 = 2;
              height1 = 18;
            }
            else
              height1 = 16;
            int width1 = Main.tile[x, index2].type == (byte) 4 || Main.tile[x, index2].type == (byte) 5 ? 20 : 16;
            if (Main.tile[x, index2].type == (byte) 73 || Main.tile[x, index2].type == (byte) 74 || Main.tile[x, index2].type == (byte) 113)
            {
              num7 -= 12;
              height1 = 32;
            }
            if (Main.tile[x, index2].type == (byte) 81)
            {
              num7 -= 8;
              height1 = 26;
              width1 = 24;
            }
            if (Main.tile[x, index2].type == (byte) 105)
              num7 = 2;
            if (Main.tile[x, index2].type == (byte) 124)
              height1 = 18;
            if (Main.tile[x, index2].type == (byte) 137)
              height1 = 18;
            if (Main.tile[x, index2].type == (byte) 138)
              height1 = 18;
            if (Main.tile[x, index2].type == (byte) 139 || Main.tile[x, index2].type == (byte) 142 || Main.tile[x, index2].type == (byte) 143)
              num7 = 2;
            if (Main.player[Main.myPlayer].findTreasure && (Main.tile[x, index2].type == (byte) 6 || Main.tile[x, index2].type == (byte) 7 || Main.tile[x, index2].type == (byte) 8 || Main.tile[x, index2].type == (byte) 9 || Main.tile[x, index2].type == (byte) 12 || Main.tile[x, index2].type == (byte) 21 || Main.tile[x, index2].type == (byte) 22 || Main.tile[x, index2].type == (byte) 28 || Main.tile[x, index2].type == (byte) 107 || Main.tile[x, index2].type == (byte) 108 || Main.tile[x, index2].type == (byte) 111 || Main.tile[x, index2].type >= (byte) 63 && Main.tile[x, index2].type <= (byte) 68 || Main.tileAlch[(int) Main.tile[x, index2].type]))
            {
              if ((int) color1.R < (int) Main.mouseTextColor / 2)
                color1.R = (byte) ((uint) Main.mouseTextColor / 2U);
              if (color1.G < (byte) 70)
                color1.G = (byte) 70;
              if (color1.B < (byte) 210)
                color1.B = (byte) 210;
              color1.A = Main.mouseTextColor;
              if (!Main.gamePaused && this.IsActive && Main.rand.Next(150) == 0)
              {
                int index3 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 15, Alpha: 150, Scale: 0.8f);
                Main.dust[index3].velocity *= 0.1f;
                Main.dust[index3].noLight = true;
              }
            }
            if (!Main.gamePaused && this.IsActive)
            {
              if (Main.tile[x, index2].type == (byte) 4 && Main.rand.Next(40) == 0 && Main.tile[x, index2].frameX < (short) 66)
              {
                int num8 = (int) Main.tile[x, index2].frameY / 22;
                int Type;
                switch (num8)
                {
                  case 0:
                    Type = 6;
                    break;
                  case 8:
                    Type = 75;
                    break;
                  default:
                    Type = 58 + num8;
                    break;
                }
                if (Main.tile[x, index2].frameX == (short) 22)
                  Dust.NewDust(new Vector2((float) (x * 16 + 6), (float) (index2 * 16)), 4, 4, Type, Alpha: 100);
                if (Main.tile[x, index2].frameX == (short) 44)
                  Dust.NewDust(new Vector2((float) (x * 16 + 2), (float) (index2 * 16)), 4, 4, Type, Alpha: 100);
                else
                  Dust.NewDust(new Vector2((float) (x * 16 + 4), (float) (index2 * 16)), 4, 4, Type, Alpha: 100);
              }
              if (Main.tile[x, index2].type == (byte) 33 && Main.rand.Next(40) == 0 && Main.tile[x, index2].frameX == (short) 0)
                Dust.NewDust(new Vector2((float) (x * 16 + 4), (float) (index2 * 16 - 4)), 4, 4, 6, Alpha: 100);
              if (Main.tile[x, index2].type == (byte) 93 && Main.rand.Next(40) == 0 && Main.tile[x, index2].frameX == (short) 0 && Main.tile[x, index2].frameY == (short) 0)
                Dust.NewDust(new Vector2((float) (x * 16 + 4), (float) (index2 * 16 + 2)), 4, 4, 6, Alpha: 100);
              if (Main.tile[x, index2].type == (byte) 100 && Main.rand.Next(40) == 0 && Main.tile[x, index2].frameX < (short) 36 && Main.tile[x, index2].frameY == (short) 0)
              {
                if (Main.tile[x, index2].frameX == (short) 0)
                {
                  if (Main.rand.Next(3) == 0)
                    Dust.NewDust(new Vector2((float) (x * 16 + 4), (float) (index2 * 16 + 2)), 4, 4, 6, Alpha: 100);
                  else
                    Dust.NewDust(new Vector2((float) (x * 16 + 14), (float) (index2 * 16 + 2)), 4, 4, 6, Alpha: 100);
                }
                else if (Main.rand.Next(3) == 0)
                  Dust.NewDust(new Vector2((float) (x * 16 + 6), (float) (index2 * 16 + 2)), 4, 4, 6, Alpha: 100);
                else
                  Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16 + 2)), 4, 4, 6, Alpha: 100);
              }
              if (Main.tile[x, index2].type == (byte) 98 && Main.rand.Next(40) == 0 && Main.tile[x, index2].frameY == (short) 0 && Main.tile[x, index2].frameX == (short) 0)
                Dust.NewDust(new Vector2((float) (x * 16 + 12), (float) (index2 * 16 + 2)), 4, 4, 6, Alpha: 100);
              if (Main.tile[x, index2].type == (byte) 49 && Main.rand.Next(20) == 0)
                Dust.NewDust(new Vector2((float) (x * 16 + 4), (float) (index2 * 16 - 4)), 4, 4, 29, Alpha: 100);
              if ((Main.tile[x, index2].type == (byte) 34 || Main.tile[x, index2].type == (byte) 35 || Main.tile[x, index2].type == (byte) 36) && Main.rand.Next(40) == 0 && Main.tile[x, index2].frameX < (short) 54 && Main.tile[x, index2].frameY == (short) 18 && (Main.tile[x, index2].frameX == (short) 0 || Main.tile[x, index2].frameX == (short) 36))
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16 + 2)), 14, 6, 6, Alpha: 100);
              if (Main.tile[x, index2].type == (byte) 22 && Main.rand.Next(400) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14);
              else if ((Main.tile[x, index2].type == (byte) 23 || Main.tile[x, index2].type == (byte) 24 || Main.tile[x, index2].type == (byte) 32) && Main.rand.Next(500) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14);
              else if (Main.tile[x, index2].type == (byte) 25 && Main.rand.Next(700) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14);
              else if (Main.tile[x, index2].type == (byte) 112 && Main.rand.Next(700) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14);
              else if (Main.tile[x, index2].type == (byte) 31 && Main.rand.Next(20) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14, Alpha: 100);
              else if (Main.tile[x, index2].type == (byte) 26 && Main.rand.Next(20) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14, Alpha: 100);
              else if ((Main.tile[x, index2].type == (byte) 71 || Main.tile[x, index2].type == (byte) 72) && Main.rand.Next(500) == 0)
                Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 41, Alpha: 250, Scale: 0.8f);
              else if ((Main.tile[x, index2].type == (byte) 17 || Main.tile[x, index2].type == (byte) 77 || Main.tile[x, index2].type == (byte) 133) && Main.rand.Next(40) == 0)
              {
                if (Main.tile[x, index2].frameX == (short) 18 & Main.tile[x, index2].frameY == (short) 18)
                  Dust.NewDust(new Vector2((float) (x * 16 + 2), (float) (index2 * 16)), 8, 6, 6, Alpha: 100);
              }
              else if (Main.tile[x, index2].type == (byte) 37 && Main.rand.Next(250) == 0)
              {
                int index4 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 6, Scale: ((float) Main.rand.Next(3)));
                if ((double) Main.dust[index4].scale > 1.0)
                  Main.dust[index4].noGravity = true;
              }
              else if ((Main.tile[x, index2].type == (byte) 58 || Main.tile[x, index2].type == (byte) 76) && Main.rand.Next(250) == 0)
              {
                int index5 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 6, Scale: ((float) Main.rand.Next(3)));
                if ((double) Main.dust[index5].scale > 1.0)
                  Main.dust[index5].noGravity = true;
                Main.dust[index5].noLight = true;
              }
              else if (Main.tile[x, index2].type == (byte) 61)
              {
                if (Main.tile[x, index2].frameX == (short) 144)
                {
                  if (Main.rand.Next(60) == 0)
                  {
                    int index6 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 44, Alpha: 250, Scale: 0.4f);
                    Main.dust[index6].fadeIn = 0.7f;
                  }
                  color1.A = (byte) (245.0 - (double) Main.mouseTextColor * 1.5);
                  color1.R = (byte) (245.0 - (double) Main.mouseTextColor * 1.5);
                  color1.B = (byte) (245.0 - (double) Main.mouseTextColor * 1.5);
                  color1.G = (byte) (245.0 - (double) Main.mouseTextColor * 1.5);
                }
              }
              else if (Main.tileShine[(int) Main.tile[x, index2].type] > 0 && (color1.R > (byte) 20 || color1.B > (byte) 20 || color1.G > (byte) 20))
              {
                int num9 = (int) color1.R;
                if ((int) color1.G > num9)
                  num9 = (int) color1.G;
                if ((int) color1.B > num9)
                  num9 = (int) color1.B;
                int num10 = num9 / 30;
                if (Main.rand.Next(Main.tileShine[(int) Main.tile[x, index2].type]) < num10 && (Main.tile[x, index2].type != (byte) 21 || Main.tile[x, index2].frameX >= (short) 36 && Main.tile[x, index2].frameX < (short) 180))
                {
                  int index7 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 43, Alpha: 254, Scale: 0.5f);
                  Main.dust[index7].velocity *= 0.0f;
                }
              }
            }
            if (Main.tile[x, index2].type == (byte) 128 && Main.tile[x, index2].frameX >= (short) 100)
            {
              numArray1[index1] = x;
              numArray2[index1] = index2;
              ++index1;
            }
            if (Main.tile[x, index2].type == (byte) 5 && Main.tile[x, index2].frameY >= (short) 198 && Main.tile[x, index2].frameX >= (short) 22)
            {
              numArray1[index1] = x;
              numArray2[index1] = index2;
              ++index1;
            }
            if (Main.tile[x, index2].type == (byte) 72 && Main.tile[x, index2].frameX >= (short) 36)
            {
              int num11 = 0;
              if (Main.tile[x, index2].frameY == (short) 18)
                num11 = 1;
              else if (Main.tile[x, index2].frameY == (short) 36)
                num11 = 2;
              this.spriteBatch.Draw(Main.shroomCapTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X - 22), (float) (index2 * 16 - (int) Main.screenPosition.Y - 26)) + vector2_1, new Rectangle?(new Rectangle(num11 * 62, 0, 60, 42)), Lighting.GetColor(x, index2), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            if (color1.R > (byte) 1 || color1.G > (byte) 1 || color1.B > (byte) 1)
            {
              if (Main.tile[x - 1, index2] == null)
                Main.tile[x - 1, index2] = new Tile();
              if (Main.tile[x + 1, index2] == null)
                Main.tile[x + 1, index2] = new Tile();
              if (Main.tile[x, index2 - 1] == null)
                Main.tile[x, index2 - 1] = new Tile();
              if (Main.tile[x, index2 + 1] == null)
                Main.tile[x, index2 + 1] = new Tile();
              if (solidOnly && flag1 && !Main.tileSolidTop[(int) Main.tile[x, index2].type] && (Main.tile[x - 1, index2].liquid > (byte) 0 || Main.tile[x + 1, index2].liquid > (byte) 0 || Main.tile[x, index2 - 1].liquid > (byte) 0 || Main.tile[x, index2 + 1].liquid > (byte) 0))
              {
                Microsoft.Xna.Framework.Color color2 = Lighting.GetColor(x, index2);
                int num12 = 0;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                bool flag5 = false;
                int index8 = 0;
                bool flag6 = false;
                if ((int) Main.tile[x - 1, index2].liquid > num12)
                {
                  num12 = (int) Main.tile[x - 1, index2].liquid;
                  flag2 = true;
                }
                else if (Main.tile[x - 1, index2].liquid > (byte) 0)
                  flag2 = true;
                if ((int) Main.tile[x + 1, index2].liquid > num12)
                {
                  num12 = (int) Main.tile[x + 1, index2].liquid;
                  flag3 = true;
                }
                else if (Main.tile[x + 1, index2].liquid > (byte) 0)
                {
                  num12 = (int) Main.tile[x + 1, index2].liquid;
                  flag3 = true;
                }
                if (Main.tile[x, index2 - 1].liquid > (byte) 0)
                  flag4 = true;
                if (Main.tile[x, index2 + 1].liquid > (byte) 240)
                  flag5 = true;
                if (Main.tile[x - 1, index2].liquid > (byte) 0)
                {
                  if (Main.tile[x - 1, index2].lava)
                    index8 = 1;
                  else
                    flag6 = true;
                }
                if (Main.tile[x + 1, index2].liquid > (byte) 0)
                {
                  if (Main.tile[x + 1, index2].lava)
                    index8 = 1;
                  else
                    flag6 = true;
                }
                if (Main.tile[x, index2 - 1].liquid > (byte) 0)
                {
                  if (Main.tile[x, index2 - 1].lava)
                    index8 = 1;
                  else
                    flag6 = true;
                }
                if (Main.tile[x, index2 + 1].liquid > (byte) 0)
                {
                  if (Main.tile[x, index2 + 1].lava)
                    index8 = 1;
                  else
                    flag6 = true;
                }
                if (!flag6 || index8 != 1)
                {
                  Vector2 vector2_2 = new Vector2((float) (x * 16), (float) (index2 * 16));
                  Rectangle rectangle = new Rectangle(0, 4, 16, 16);
                  if (flag5 && (flag2 || flag3))
                  {
                    flag2 = true;
                    flag3 = true;
                  }
                  if ((!flag4 || !flag2 && !flag3) && (!flag5 || !flag4))
                  {
                    if (flag4)
                      rectangle = new Rectangle(0, 4, 16, 4);
                    else if (flag5 && !flag2 && !flag3)
                    {
                      vector2_2 = new Vector2((float) (x * 16), (float) (index2 * 16 + 12));
                      rectangle = new Rectangle(0, 4, 16, 4);
                    }
                    else
                    {
                      float num13 = (float) (256 - num12) / 32f;
                      if (flag2 && flag3)
                      {
                        vector2_2 = new Vector2((float) (x * 16), (float) (index2 * 16 + (int) num13 * 2));
                        rectangle = new Rectangle(0, 4, 16, 16 - (int) num13 * 2);
                      }
                      else if (flag2)
                      {
                        vector2_2 = new Vector2((float) (x * 16), (float) (index2 * 16 + (int) num13 * 2));
                        rectangle = new Rectangle(0, 4, 4, 16 - (int) num13 * 2);
                      }
                      else
                      {
                        vector2_2 = new Vector2((float) (x * 16 + 12), (float) (index2 * 16 + (int) num13 * 2));
                        rectangle = new Rectangle(0, 4, 4, 16 - (int) num13 * 2);
                      }
                    }
                  }
                  float num14 = 0.5f;
                  if (index8 == 1)
                    num14 *= 1.6f;
                  if ((double) index2 < Main.worldSurface || (double) num14 > 1.0)
                    num14 = 1f;
                  color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((float) color2.R * num14), (int) (byte) ((float) color2.G * num14), (int) (byte) ((float) color2.B * num14), (int) (byte) ((float) color2.A * num14));
                  this.spriteBatch.Draw(Main.liquidTexture[index8], vector2_2 - Main.screenPosition + vector2_1, new Rectangle?(rectangle), color2, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
              if (Main.tile[x, index2].type == (byte) 51)
              {
                Microsoft.Xna.Framework.Color color3 = Lighting.GetColor(x, index2);
                float num15 = 0.5f;
                color3 = new Microsoft.Xna.Framework.Color((int) (byte) ((float) color3.R * num15), (int) (byte) ((float) color3.G * num15), (int) (byte) ((float) color3.B * num15), (int) (byte) ((float) color3.A * num15));
                this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color3, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
              else if (Main.tile[x, index2].type == (byte) 129)
                this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              else if (Main.tileAlch[(int) Main.tile[x, index2].type])
              {
                int height2 = 20;
                int num16 = -1;
                int index9 = (int) Main.tile[x, index2].type;
                int num17 = (int) Main.tile[x, index2].frameX / 18;
                if (index9 > 82)
                {
                  if (num17 == 0 && Main.dayTime)
                    index9 = 84;
                  if (num17 == 1 && !Main.dayTime)
                    index9 = 84;
                  if (num17 == 3 && Main.bloodMoon)
                    index9 = 84;
                }
                if (index9 == 84)
                {
                  if (num17 == 0 && Main.rand.Next(100) == 0)
                  {
                    int index10 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16 - 4)), 16, 16, 19, Alpha: 160, Scale: 0.1f);
                    Main.dust[index10].velocity.X /= 2f;
                    Main.dust[index10].velocity.Y /= 2f;
                    Main.dust[index10].noGravity = true;
                    Main.dust[index10].fadeIn = 1f;
                  }
                  if (num17 == 1 && Main.rand.Next(100) == 0)
                    Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 41, Alpha: 250, Scale: 0.8f);
                  if (num17 == 3)
                  {
                    if (Main.rand.Next(200) == 0)
                    {
                      int index11 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 14, Alpha: 100, Scale: 0.2f);
                      Main.dust[index11].fadeIn = 1.2f;
                    }
                    if (Main.rand.Next(75) == 0)
                    {
                      int index12 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 16, 27, Alpha: 100);
                      Main.dust[index12].velocity.X /= 2f;
                      Main.dust[index12].velocity.Y /= 2f;
                    }
                  }
                  if (num17 == 4 && Main.rand.Next(150) == 0)
                  {
                    int index13 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16)), 16, 8, 16);
                    Main.dust[index13].velocity.X /= 3f;
                    Main.dust[index13].velocity.Y /= 3f;
                    Main.dust[index13].velocity.Y -= 0.7f;
                    Main.dust[index13].alpha = 50;
                    Main.dust[index13].scale *= 0.1f;
                    Main.dust[index13].fadeIn = 0.9f;
                    Main.dust[index13].noGravity = true;
                  }
                  if (num17 == 5)
                  {
                    if (Main.rand.Next(40) == 0)
                    {
                      int index14 = Dust.NewDust(new Vector2((float) (x * 16), (float) (index2 * 16 - 6)), 16, 16, 6, Scale: 1.5f);
                      Main.dust[index14].velocity.Y -= 2f;
                      Main.dust[index14].noGravity = true;
                    }
                    color1.A = (byte) ((uint) Main.mouseTextColor / 2U);
                    color1.G = Main.mouseTextColor;
                    color1.B = Main.mouseTextColor;
                  }
                }
                this.spriteBatch.Draw(Main.tileTexture[index9], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num16)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height2)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
              else if (Main.tile[x, index2].type == (byte) 80)
              {
                bool flag7 = false;
                bool flag8 = false;
                int index15 = x;
                if (Main.tile[x, index2].frameX == (short) 36)
                  --index15;
                if (Main.tile[x, index2].frameX == (short) 54)
                  ++index15;
                if (Main.tile[x, index2].frameX == (short) 108)
                {
                  if (Main.tile[x, index2].frameY == (short) 16)
                    --index15;
                  else
                    ++index15;
                }
                int index16 = index2;
                bool flag9 = false;
                if (Main.tile[index15, index16].type == (byte) 80 && Main.tile[index15, index16].active)
                  flag9 = true;
                while (!Main.tile[index15, index16].active || !Main.tileSolid[(int) Main.tile[index15, index16].type] || !flag9)
                {
                  if (Main.tile[index15, index16].type == (byte) 80 && Main.tile[index15, index16].active)
                    flag9 = true;
                  ++index16;
                  if (index16 > index2 + 20)
                    break;
                }
                if (Main.tile[index15, index16].type == (byte) 112)
                  flag7 = true;
                if (Main.tile[index15, index16].type == (byte) 116)
                  flag8 = true;
                if (flag7)
                  this.spriteBatch.Draw(Main.evilCactusTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                else if (flag8)
                  this.spriteBatch.Draw(Main.goodCactusTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                else
                  this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
              else if (Lighting.lightMode < 2 && Main.tileSolid[(int) Main.tile[x, index2].type] && Main.tile[x, index2].type != (byte) 137)
              {
                if ((int) color1.R > num1 || (double) color1.G > (double) num1 * 1.1 || (double) color1.B > (double) num1 * 1.2)
                {
                  for (int index17 = 0; index17 < 9; ++index17)
                  {
                    int num18 = 0;
                    int num19 = 0;
                    int width2 = 4;
                    int height3 = 4;
                    Microsoft.Xna.Framework.Color color4 = color1;
                    Microsoft.Xna.Framework.Color color5 = color1;
                    if (index17 == 0)
                      color5 = Lighting.GetColor(x - 1, index2 - 1);
                    if (index17 == 1)
                    {
                      width2 = 8;
                      num18 = 4;
                      color5 = Lighting.GetColor(x, index2 - 1);
                    }
                    if (index17 == 2)
                    {
                      color5 = Lighting.GetColor(x + 1, index2 - 1);
                      num18 = 12;
                    }
                    if (index17 == 3)
                    {
                      color5 = Lighting.GetColor(x - 1, index2);
                      height3 = 8;
                      num19 = 4;
                    }
                    if (index17 == 4)
                    {
                      width2 = 8;
                      height3 = 8;
                      num18 = 4;
                      num19 = 4;
                    }
                    if (index17 == 5)
                    {
                      num18 = 12;
                      num19 = 4;
                      height3 = 8;
                      color5 = Lighting.GetColor(x + 1, index2);
                    }
                    if (index17 == 6)
                    {
                      color5 = Lighting.GetColor(x - 1, index2 + 1);
                      num19 = 12;
                    }
                    if (index17 == 7)
                    {
                      width2 = 8;
                      height3 = 4;
                      num18 = 4;
                      num19 = 12;
                      color5 = Lighting.GetColor(x, index2 + 1);
                    }
                    if (index17 == 8)
                    {
                      color5 = Lighting.GetColor(x + 1, index2 + 1);
                      num18 = 12;
                      num19 = 12;
                    }
                    color4.R = (byte) (((int) color1.R + (int) color5.R) / 2);
                    color4.G = (byte) (((int) color1.G + (int) color5.G) / 2);
                    color4.B = (byte) (((int) color1.B + (int) color5.B) / 2);
                    if (Main.tileShine2[(int) Main.tile[x, index2].type])
                      color4 = Main.shine(color4, (int) Main.tile[x, index2].type);
                    this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0) + (float) num18, (float) (index2 * 16 - (int) Main.screenPosition.Y + num7 + num19)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX + num18, (int) Main.tile[x, index2].frameY + num19, width2, height3)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  }
                }
                else if ((int) color1.R > num2 || (double) color1.G > (double) num2 * 1.1 || (double) color1.B > (double) num2 * 1.2)
                {
                  for (int index18 = 0; index18 < 4; ++index18)
                  {
                    int num20 = 0;
                    int num21 = 0;
                    Microsoft.Xna.Framework.Color color6 = color1;
                    Microsoft.Xna.Framework.Color color7 = color1;
                    if (index18 == 0)
                      color7 = !Lighting.Brighter(x, index2 - 1, x - 1, index2) ? Lighting.GetColor(x, index2 - 1) : Lighting.GetColor(x - 1, index2);
                    if (index18 == 1)
                    {
                      color7 = !Lighting.Brighter(x, index2 - 1, x + 1, index2) ? Lighting.GetColor(x, index2 - 1) : Lighting.GetColor(x + 1, index2);
                      num20 = 8;
                    }
                    if (index18 == 2)
                    {
                      color7 = !Lighting.Brighter(x, index2 + 1, x - 1, index2) ? Lighting.GetColor(x, index2 + 1) : Lighting.GetColor(x - 1, index2);
                      num21 = 8;
                    }
                    if (index18 == 3)
                    {
                      color7 = !Lighting.Brighter(x, index2 + 1, x + 1, index2) ? Lighting.GetColor(x, index2 + 1) : Lighting.GetColor(x + 1, index2);
                      num20 = 8;
                      num21 = 8;
                    }
                    color6.R = (byte) (((int) color1.R + (int) color7.R) / 2);
                    color6.G = (byte) (((int) color1.G + (int) color7.G) / 2);
                    color6.B = (byte) (((int) color1.B + (int) color7.B) / 2);
                    if (Main.tileShine2[(int) Main.tile[x, index2].type])
                      color6 = Main.shine(color6, (int) Main.tile[x, index2].type);
                    this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0) + (float) num20, (float) (index2 * 16 - (int) Main.screenPosition.Y + num7 + num21)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX + num20, (int) Main.tile[x, index2].frameY + num21, 8, 8)), color6, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  }
                }
                else
                {
                  if (Main.tileShine2[(int) Main.tile[x, index2].type])
                    color1 = Main.shine(color1, (int) Main.tile[x, index2].type);
                  this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
              else
              {
                if (Lighting.lightMode < 2 && Main.tileShine2[(int) Main.tile[x, index2].type])
                {
                  if (Main.tile[x, index2].type == (byte) 21)
                  {
                    if (Main.tile[x, index2].frameX >= (short) 36 && Main.tile[x, index2].frameX < (short) 178)
                      color1 = Main.shine(color1, (int) Main.tile[x, index2].type);
                  }
                  else
                    color1 = Main.shine(color1, (int) Main.tile[x, index2].type);
                }
                if (Main.tile[x, index2].type == (byte) 128)
                {
                  int frameX = (int) Main.tile[x, index2].frameX;
                  while (frameX >= 100)
                    frameX -= 100;
                  this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle(frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
                else
                {
                  this.spriteBatch.Draw(Main.tileTexture[(int) Main.tile[x, index2].type], new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  if (Main.tile[x, index2].type == (byte) 139)
                    this.spriteBatch.Draw(Main.MusicBoxTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  if (Main.tile[x, index2].type == (byte) 144)
                    this.spriteBatch.Draw(Main.timerTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X) - (float) (((double) width1 - 16.0) / 2.0), (float) (index2 * 16 - (int) Main.screenPosition.Y + num7)) + vector2_1, new Rectangle?(new Rectangle((int) Main.tile[x, index2].frameX, (int) Main.tile[x, index2].frameY, width1, height1)), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
        }
      }
      for (int index19 = 0; index19 < index1; ++index19)
      {
        int x = numArray1[index19];
        int y = numArray2[index19];
        if (Main.tile[x, y].type == (byte) 128)
        {
          if (Main.tile[x, y].frameX >= (short) 100)
          {
            int num22 = (int) Main.tile[x, y].frameY / 18;
            int frameX = (int) Main.tile[x, y].frameX;
            int index20 = 0;
            for (; frameX >= 100; frameX -= 100)
              ++index20;
            int num23 = -4;
            SpriteEffects effects = SpriteEffects.FlipHorizontally;
            if (frameX >= 36)
            {
              effects = SpriteEffects.None;
              num23 = -4;
            }
            switch (num22)
            {
              case 0:
                this.spriteBatch.Draw(Main.armorHeadTexture[index20], new Vector2((float) (x * 16 - (int) Main.screenPosition.X + num23), (float) (y * 16 - (int) Main.screenPosition.Y - 12)) + vector2_1, new Rectangle?(new Rectangle(0, 0, 40, 36)), Lighting.GetColor(x, y), 0.0f, new Vector2(), 1f, effects, 0.0f);
                break;
              case 1:
                this.spriteBatch.Draw(Main.armorBodyTexture[index20], new Vector2((float) (x * 16 - (int) Main.screenPosition.X + num23), (float) (y * 16 - (int) Main.screenPosition.Y - 28)) + vector2_1, new Rectangle?(new Rectangle(0, 0, 40, 54)), Lighting.GetColor(x, y), 0.0f, new Vector2(), 1f, effects, 0.0f);
                break;
              case 2:
                this.spriteBatch.Draw(Main.armorLegTexture[index20], new Vector2((float) (x * 16 - (int) Main.screenPosition.X + num23), (float) (y * 16 - (int) Main.screenPosition.Y - 44)) + vector2_1, new Rectangle?(new Rectangle(0, 0, 40, 54)), Lighting.GetColor(x, y), 0.0f, new Vector2(), 1f, effects, 0.0f);
                break;
            }
          }
        }
        try
        {
          if (Main.tile[x, y].type == (byte) 5)
          {
            if (Main.tile[x, y].frameY >= (short) 198)
            {
              if (Main.tile[x, y].frameX >= (short) 22)
              {
                int num24 = 0;
                if (Main.tile[x, y].frameX == (short) 22)
                {
                  if (Main.tile[x, y].frameY == (short) 220)
                    num24 = 1;
                  else if (Main.tile[x, y].frameY == (short) 242)
                    num24 = 2;
                  int index21 = 0;
                  int width = 80;
                  int height = 80;
                  int num25 = 32;
                  int num26 = 0;
                  for (int index22 = y; index22 < y + 100; ++index22)
                  {
                    if (Main.tile[x, index22].type == (byte) 2)
                    {
                      index21 = 0;
                      break;
                    }
                    if (Main.tile[x, index22].type == (byte) 23)
                    {
                      index21 = 1;
                      break;
                    }
                    if (Main.tile[x, index22].type == (byte) 60)
                    {
                      index21 = 2;
                      width = 114;
                      height = 96;
                      num25 = 48;
                      break;
                    }
                    if (Main.tile[x, index22].type == (byte) 147)
                    {
                      index21 = 4;
                      break;
                    }
                    if (Main.tile[x, index22].type == (byte) 109)
                    {
                      index21 = 3;
                      height = 140;
                      if (x % 3 == 1)
                      {
                        num24 += 3;
                        break;
                      }
                      if (x % 3 == 2)
                      {
                        num24 += 6;
                        break;
                      }
                      break;
                    }
                  }
                  this.spriteBatch.Draw(Main.treeTopTexture[index21], new Vector2((float) (x * 16 - (int) Main.screenPosition.X - num25), (float) (y * 16 - (int) Main.screenPosition.Y - height + 16 + num26)) + vector2_1, new Rectangle?(new Rectangle(num24 * (width + 2), 0, width, height)), Lighting.GetColor(x, y), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
                else if (Main.tile[x, y].frameX == (short) 44)
                {
                  if (Main.tile[x, y].frameY == (short) 220)
                    num24 = 1;
                  else if (Main.tile[x, y].frameY == (short) 242)
                    num24 = 2;
                  int index23 = 0;
                  for (int index24 = y; index24 < y + 100; ++index24)
                  {
                    if (Main.tile[x + 1, index24].type == (byte) 2)
                    {
                      index23 = 0;
                      break;
                    }
                    if (Main.tile[x + 1, index24].type == (byte) 23)
                    {
                      index23 = 1;
                      break;
                    }
                    if (Main.tile[x + 1, index24].type == (byte) 60)
                    {
                      index23 = 2;
                      break;
                    }
                    if (Main.tile[x + 1, index24].type == (byte) 147)
                    {
                      index23 = 4;
                      break;
                    }
                    if (Main.tile[x + 1, index24].type == (byte) 109)
                    {
                      index23 = 3;
                      if (x % 3 == 1)
                      {
                        num24 += 3;
                        break;
                      }
                      if (x % 3 == 2)
                      {
                        num24 += 6;
                        break;
                      }
                      break;
                    }
                  }
                  this.spriteBatch.Draw(Main.treeBranchTexture[index23], new Vector2((float) (x * 16 - (int) Main.screenPosition.X - 24), (float) (y * 16 - (int) Main.screenPosition.Y - 12)) + vector2_1, new Rectangle?(new Rectangle(0, num24 * 42, 40, 40)), Lighting.GetColor(x, y), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
                else if (Main.tile[x, y].frameX == (short) 66)
                {
                  if (Main.tile[x, y].frameY == (short) 220)
                    num24 = 1;
                  else if (Main.tile[x, y].frameY == (short) 242)
                    num24 = 2;
                  int index25 = 0;
                  for (int index26 = y; index26 < y + 100; ++index26)
                  {
                    if (Main.tile[x - 1, index26].type == (byte) 2)
                    {
                      index25 = 0;
                      break;
                    }
                    if (Main.tile[x - 1, index26].type == (byte) 23)
                    {
                      index25 = 1;
                      break;
                    }
                    if (Main.tile[x - 1, index26].type == (byte) 60)
                    {
                      index25 = 2;
                      break;
                    }
                    if (Main.tile[x - 1, index26].type == (byte) 147)
                    {
                      index25 = 4;
                      break;
                    }
                    if (Main.tile[x - 1, index26].type == (byte) 109)
                    {
                      index25 = 3;
                      if (x % 3 == 1)
                      {
                        num24 += 3;
                        break;
                      }
                      if (x % 3 == 2)
                      {
                        num24 += 6;
                        break;
                      }
                      break;
                    }
                  }
                  this.spriteBatch.Draw(Main.treeBranchTexture[index25], new Vector2((float) (x * 16 - (int) Main.screenPosition.X), (float) (y * 16 - (int) Main.screenPosition.Y - 12)) + vector2_1, new Rectangle?(new Rectangle(42, num24 * 42, 40, 40)), Lighting.GetColor(x, y), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
        }
        catch
        {
        }
      }
      if (solidOnly)
        Main.renderTimer[0] = (float) stopwatch.ElapsedMilliseconds;
      else
        Main.renderTimer[1] = (float) stopwatch.ElapsedMilliseconds;
    }

    protected void DrawWater(bool bg = false)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      Vector2 vector2_1 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2_1 = new Vector2();
      int num1 = (int) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 40.0 * (double) Main.gfxQuality);
      int num2 = (int) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 140.0 * (double) Main.gfxQuality);
      float num3 = (float) Main.evilTiles / 350f;
      if ((double) num3 > 1.0)
        num3 = 1f;
      if ((double) num3 < 0.0)
        num3 = 0.0f;
      float num4 = (float) (((double) byte.MaxValue - 100.0 * (double) num3) / (double) byte.MaxValue);
      float num5 = (float) (((double) byte.MaxValue - 50.0 * (double) num3) / (double) byte.MaxValue);
      int num6 = (int) (((double) Main.screenPosition.X - (double) vector2_1.X) / 16.0 - 1.0);
      int num7 = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth + (double) vector2_1.X) / 16.0) + 2;
      int num8 = (int) (((double) Main.screenPosition.Y - (double) vector2_1.Y) / 16.0 - 1.0);
      int num9 = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight + (double) vector2_1.Y) / 16.0) + 5;
      if (num6 < 5)
        num6 = 5;
      if (num7 > Main.maxTilesX - 5)
        num7 = Main.maxTilesX - 5;
      if (num8 < 5)
        num8 = 5;
      if (num9 > Main.maxTilesY - 5)
        num9 = Main.maxTilesY - 5;
      for (int index1 = num8; index1 < num9 + 4; ++index1)
      {
        for (int x = num6 - 2; x < num7 + 2; ++x)
        {
          if (Main.tile[x, index1] == null)
            Main.tile[x, index1] = new Tile();
          if (Main.tile[x, index1].liquid > (byte) 0 && (!Main.tile[x, index1].active || !Main.tileSolid[(int) Main.tile[x, index1].type] || Main.tileSolidTop[(int) Main.tile[x, index1].type]) && ((double) Lighting.Brightness(x, index1) > 0.0 || bg))
          {
            Microsoft.Xna.Framework.Color color1 = Lighting.GetColor(x, index1);
            float num10 = (float) (256 - (int) Main.tile[x, index1].liquid) / 32f;
            int index2 = 0;
            if (Main.tile[x, index1].lava)
              index2 = 1;
            float num11 = 0.5f;
            if (bg)
              num11 = 1f;
            Vector2 vector2_2 = new Vector2((float) (x * 16), (float) (index1 * 16 + (int) num10 * 2));
            Rectangle rectangle = new Rectangle(0, 0, 16, 16 - (int) num10 * 2);
            if (Main.tile[x, index1 + 1].liquid < (byte) 245 && (!Main.tile[x, index1 + 1].active || !Main.tileSolid[(int) Main.tile[x, index1 + 1].type] || Main.tileSolidTop[(int) Main.tile[x, index1 + 1].type]))
            {
              float num12 = (float) (256 - (int) Main.tile[x, index1 + 1].liquid) / 32f;
              num11 = (float) (0.5 * (8.0 - (double) num10) / 4.0);
              if ((double) num11 > 0.55)
                num11 = 0.55f;
              if ((double) num11 < 0.35)
                num11 = 0.35f;
              float num13 = num10 / 2f;
              if (Main.tile[x, index1 + 1].liquid < (byte) 200)
              {
                if (!bg)
                {
                  if (Main.tile[x, index1 - 1].liquid > (byte) 0 && Main.tile[x, index1 - 1].liquid > (byte) 0)
                  {
                    rectangle = new Rectangle(0, 4, 16, 16);
                    num11 = 0.5f;
                  }
                  else if (Main.tile[x, index1 - 1].liquid > (byte) 0)
                  {
                    vector2_2 = new Vector2((float) (x * 16), (float) (index1 * 16 + 4));
                    rectangle = new Rectangle(0, 4, 16, 12);
                    num11 = 0.5f;
                  }
                  else if (Main.tile[x, index1 + 1].liquid > (byte) 0)
                  {
                    vector2_2 = new Vector2((float) (x * 16), (float) (index1 * 16 + (int) num10 * 2 + (int) num12 * 2));
                    rectangle = new Rectangle(0, 4, 16, 16 - (int) num10 * 2);
                  }
                  else
                  {
                    vector2_2 = new Vector2((float) (x * 16 + (int) num13), (float) (index1 * 16 + (int) num13 * 2 + (int) num12 * 2));
                    rectangle = new Rectangle(0, 4, 16 - (int) num13 * 2, 16 - (int) num13 * 2);
                  }
                }
                else
                  continue;
              }
              else
              {
                num11 = 0.5f;
                rectangle = new Rectangle(0, 4, 16, 16 - (int) num10 * 2 + (int) num12 * 2);
              }
            }
            else if (Main.tile[x, index1 - 1].liquid > (byte) 32)
              rectangle = new Rectangle(0, 4, rectangle.Width, rectangle.Height);
            else if ((double) num10 < 1.0 && Main.tile[x, index1 - 1].active && Main.tileSolid[(int) Main.tile[x, index1 - 1].type] && !Main.tileSolidTop[(int) Main.tile[x, index1 - 1].type])
            {
              vector2_2 = new Vector2((float) (x * 16), (float) (index1 * 16));
              rectangle = new Rectangle(0, 4, 16, 16);
            }
            else
            {
              bool flag = true;
              for (int index3 = index1 + 1; index3 < index1 + 6 && (!Main.tile[x, index3].active || !Main.tileSolid[(int) Main.tile[x, index3].type] || Main.tileSolidTop[(int) Main.tile[x, index3].type]); ++index3)
              {
                if (Main.tile[x, index3].liquid < (byte) 200)
                {
                  flag = false;
                  break;
                }
              }
              if (!flag)
              {
                num11 = 0.5f;
                rectangle = new Rectangle(0, 4, 16, 16);
              }
              else if (Main.tile[x, index1 - 1].liquid > (byte) 0)
                rectangle = new Rectangle(0, 2, rectangle.Width, rectangle.Height);
            }
            if (Main.tile[x, index1].lava)
            {
              num11 *= 1.8f;
              if ((double) num11 > 1.0)
                num11 = 1f;
              if (this.IsActive && !Main.gamePaused && Dust.lavaBubbles < 200)
              {
                if (Main.tile[x, index1].liquid > (byte) 200 && Main.rand.Next(700) == 0)
                  Dust.NewDust(new Vector2((float) (x * 16), (float) (index1 * 16)), 16, 16, 35);
                if (rectangle.Y == 0 && Main.rand.Next(350) == 0)
                {
                  int index4 = Dust.NewDust(new Vector2((float) (x * 16), (float) ((double) (index1 * 16) + (double) num10 * 2.0 - 8.0)), 16, 8, 35, Alpha: 50, Scale: 1.5f);
                  Main.dust[index4].velocity *= 0.8f;
                  Main.dust[index4].velocity.X *= 2f;
                  Main.dust[index4].velocity.Y -= (float) Main.rand.Next(1, 7) * 0.1f;
                  if (Main.rand.Next(10) == 0)
                    Main.dust[index4].velocity.Y *= (float) Main.rand.Next(2, 5);
                  Main.dust[index4].noGravity = true;
                }
              }
            }
            float num14 = (float) color1.R * num11;
            float num15 = (float) color1.G * num11;
            float num16 = (float) color1.B * num11;
            float num17 = (float) color1.A * num11;
            if (index2 == 0)
              num16 *= num4;
            else
              num14 *= num5;
            color1 = new Microsoft.Xna.Framework.Color((int) (byte) num14, (int) (byte) num15, (int) (byte) num16, (int) (byte) num17);
            if (Lighting.lightMode < 2 && !bg)
            {
              Microsoft.Xna.Framework.Color color2 = color1;
              if (index2 == 0 && ((int) color2.R > num1 || (double) color2.G > (double) num1 * 1.1 || (double) color2.B > (double) num1 * 1.2) || (int) color2.R > num2 || (double) color2.G > (double) num2 * 1.1 || (double) color2.B > (double) num2 * 1.2)
              {
                for (int index5 = 0; index5 < 4; ++index5)
                {
                  int num18 = 0;
                  int num19 = 0;
                  int width = 8;
                  int height = 8;
                  Microsoft.Xna.Framework.Color color3 = color2;
                  Microsoft.Xna.Framework.Color color4 = Lighting.GetColor(x, index1);
                  if (index5 == 0)
                  {
                    if (Lighting.Brighter(x, index1 - 1, x - 1, index1))
                    {
                      if (!Main.tile[x - 1, index1].active)
                        color4 = Lighting.GetColor(x - 1, index1);
                      else if (!Main.tile[x, index1 - 1].active)
                        color4 = Lighting.GetColor(x, index1 - 1);
                    }
                    if (rectangle.Height < 8)
                      height = rectangle.Height;
                  }
                  if (index5 == 1)
                  {
                    if (Lighting.Brighter(x, index1 - 1, x + 1, index1))
                    {
                      if (!Main.tile[x + 1, index1].active)
                        color4 = Lighting.GetColor(x + 1, index1);
                      else if (!Main.tile[x, index1 - 1].active)
                        color4 = Lighting.GetColor(x, index1 - 1);
                    }
                    num18 = 8;
                    if (rectangle.Height < 8)
                      height = rectangle.Height;
                  }
                  if (index5 == 2)
                  {
                    if (Lighting.Brighter(x, index1 + 1, x - 1, index1))
                    {
                      if (!Main.tile[x - 1, index1].active)
                        color4 = Lighting.GetColor(x - 1, index1);
                      else if (!Main.tile[x, index1 + 1].active)
                        color4 = Lighting.GetColor(x, index1 + 1);
                    }
                    num19 = 8;
                    height = 8 - (16 - rectangle.Height);
                  }
                  if (index5 == 3)
                  {
                    if (Lighting.Brighter(x, index1 + 1, x + 1, index1))
                    {
                      if (!Main.tile[x + 1, index1].active)
                        color4 = Lighting.GetColor(x + 1, index1);
                      else if (!Main.tile[x, index1 + 1].active)
                        color4 = Lighting.GetColor(x, index1 + 1);
                    }
                    num18 = 8;
                    num19 = 8;
                    height = 8 - (16 - rectangle.Height);
                  }
                  color4 = new Microsoft.Xna.Framework.Color((int) (byte) ((float) color4.R * num11), (int) (byte) ((float) color4.G * num11), (int) (byte) ((float) color4.B * num11), (int) (byte) ((float) color4.A * num11));
                  color3.R = (byte) (((int) color2.R + (int) color4.R) / 2);
                  color3.G = (byte) (((int) color2.G + (int) color4.G) / 2);
                  color3.B = (byte) (((int) color2.B + (int) color4.B) / 2);
                  color3.A = (byte) (((int) color2.A + (int) color4.A) / 2);
                  this.spriteBatch.Draw(Main.liquidTexture[index2], vector2_2 - Main.screenPosition + new Vector2((float) num18, (float) num19) + vector2_1, new Rectangle?(new Rectangle(rectangle.X + num18, rectangle.Y + num19, width, height)), color3, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
              else
                this.spriteBatch.Draw(Main.liquidTexture[index2], vector2_2 - Main.screenPosition + vector2_1, new Rectangle?(rectangle), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            else
              this.spriteBatch.Draw(Main.liquidTexture[index2], vector2_2 - Main.screenPosition + vector2_1, new Rectangle?(rectangle), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      if (bg)
        return;
      Main.renderTimer[4] = (float) stopwatch.ElapsedMilliseconds;
    }

    protected void DrawGore()
    {
      for (int index = 0; index < 200; ++index)
      {
        if (Main.gore[index].active && Main.gore[index].type > 0)
        {
          Microsoft.Xna.Framework.Color alpha = Main.gore[index].GetAlpha(Lighting.GetColor((int) ((double) Main.gore[index].position.X + (double) Main.goreTexture[Main.gore[index].type].Width * 0.5) / 16, (int) (((double) Main.gore[index].position.Y + (double) Main.goreTexture[Main.gore[index].type].Height * 0.5) / 16.0)));
          this.spriteBatch.Draw(Main.goreTexture[Main.gore[index].type], new Vector2(Main.gore[index].position.X - Main.screenPosition.X + (float) (Main.goreTexture[Main.gore[index].type].Width / 2), Main.gore[index].position.Y - Main.screenPosition.Y + (float) (Main.goreTexture[Main.gore[index].type].Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.goreTexture[Main.gore[index].type].Width, Main.goreTexture[Main.gore[index].type].Height)), alpha, Main.gore[index].rotation, new Vector2((float) (Main.goreTexture[Main.gore[index].type].Width / 2), (float) (Main.goreTexture[Main.gore[index].type].Height / 2)), Main.gore[index].scale, SpriteEffects.None, 0.0f);
        }
      }
    }

    protected void DrawNPCs(bool behindTiles = false)
    {
      bool flag1 = false;
      Rectangle rectangle = new Rectangle((int) Main.screenPosition.X - 300, (int) Main.screenPosition.Y - 300, Main.screenWidth + 600, Main.screenHeight + 600);
      for (int index1 = 199; index1 >= 0; --index1)
      {
        if (Main.npc[index1].active && Main.npc[index1].type > 0 && Main.npc[index1].behindTiles == behindTiles)
        {
          if ((Main.npc[index1].type == 125 || Main.npc[index1].type == 126) && !flag1)
          {
            flag1 = true;
            for (int index2 = 0; index2 < 200; ++index2)
            {
              if (Main.npc[index2].active && index1 != index2 && (Main.npc[index2].type == 125 || Main.npc[index2].type == 126))
              {
                float num1 = Main.npc[index2].position.X + (float) Main.npc[index2].width * 0.5f;
                float num2 = Main.npc[index2].position.Y + (float) Main.npc[index2].height * 0.5f;
                Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) Main.npc[index1].width * 0.5f, Main.npc[index1].position.Y + (float) Main.npc[index1].height * 0.5f);
                float num3 = num1 - vector2.X;
                float num4 = num2 - vector2.Y;
                float rotation = (float) Math.Atan2((double) num4, (double) num3) - 1.57f;
                bool flag2 = true;
                if (Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4) > 2000.0)
                  flag2 = false;
                while (flag2)
                {
                  float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
                  if ((double) num5 < 40.0)
                  {
                    flag2 = false;
                  }
                  else
                  {
                    float num6 = (float) Main.chain12Texture.Height / num5;
                    float num7 = num3 * num6;
                    float num8 = num4 * num6;
                    vector2.X += num7;
                    vector2.Y += num8;
                    num3 = num1 - vector2.X;
                    num4 = num2 - vector2.Y;
                    Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
                    this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain12Texture.Width, Main.chain12Texture.Height)), color, rotation, new Vector2((float) Main.chain12Texture.Width * 0.5f, (float) Main.chain12Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
                  }
                }
              }
            }
          }
          if (rectangle.Intersects(new Rectangle((int) Main.npc[index1].position.X, (int) Main.npc[index1].position.Y, Main.npc[index1].width, Main.npc[index1].height)))
          {
            if (Main.npc[index1].type == 101)
            {
              bool flag3 = true;
              Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) (Main.npc[index1].width / 2), Main.npc[index1].position.Y + (float) (Main.npc[index1].height / 2));
              float num9 = (float) ((double) Main.npc[index1].ai[0] * 16.0 + 8.0) - vector2.X;
              float num10 = (float) ((double) Main.npc[index1].ai[1] * 16.0 + 8.0) - vector2.Y;
              float rotation = (float) Math.Atan2((double) num10, (double) num9) - 1.57f;
              bool flag4 = true;
              while (flag4)
              {
                float scale = 0.75f;
                int height = 28;
                float num11 = (float) Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
                if ((double) num11 < 28.0 * (double) scale)
                {
                  height = (int) num11 - 40 + 28;
                  flag4 = false;
                }
                float num12 = 20f * scale / num11;
                float num13 = num9 * num12;
                float num14 = num10 * num12;
                vector2.X += num13;
                vector2.Y += num14;
                num9 = (float) ((double) Main.npc[index1].ai[0] * 16.0 + 8.0) - vector2.X;
                num10 = (float) ((double) Main.npc[index1].ai[1] * 16.0 + 8.0) - vector2.Y;
                Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
                if (!flag3)
                {
                  flag3 = true;
                  this.spriteBatch.Draw(Main.chain10Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain10Texture.Width, height)), color, rotation, new Vector2((float) Main.chain10Texture.Width * 0.5f, (float) Main.chain10Texture.Height * 0.5f), scale, SpriteEffects.None, 0.0f);
                }
                else
                {
                  flag3 = false;
                  this.spriteBatch.Draw(Main.chain11Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain10Texture.Width, height)), color, rotation, new Vector2((float) Main.chain10Texture.Width * 0.5f, (float) Main.chain10Texture.Height * 0.5f), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
            else if (Main.npc[index1].aiStyle == 13)
            {
              Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) (Main.npc[index1].width / 2), Main.npc[index1].position.Y + (float) (Main.npc[index1].height / 2));
              float num15 = (float) ((double) Main.npc[index1].ai[0] * 16.0 + 8.0) - vector2.X;
              float num16 = (float) ((double) Main.npc[index1].ai[1] * 16.0 + 8.0) - vector2.Y;
              float rotation = (float) Math.Atan2((double) num16, (double) num15) - 1.57f;
              bool flag5 = true;
              while (flag5)
              {
                int height = 28;
                float num17 = (float) Math.Sqrt((double) num15 * (double) num15 + (double) num16 * (double) num16);
                if ((double) num17 < 40.0)
                {
                  height = (int) num17 - 40 + 28;
                  flag5 = false;
                }
                float num18 = 28f / num17;
                float num19 = num15 * num18;
                float num20 = num16 * num18;
                vector2.X += num19;
                vector2.Y += num20;
                num15 = (float) ((double) Main.npc[index1].ai[0] * 16.0 + 8.0) - vector2.X;
                num16 = (float) ((double) Main.npc[index1].ai[1] * 16.0 + 8.0) - vector2.Y;
                Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
                if (Main.npc[index1].type == 56)
                  this.spriteBatch.Draw(Main.chain5Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height)), color, rotation, new Vector2((float) Main.chain4Texture.Width * 0.5f, (float) Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
                else
                  this.spriteBatch.Draw(Main.chain4Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height)), color, rotation, new Vector2((float) Main.chain4Texture.Width * 0.5f, (float) Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
              }
            }
            if (Main.npc[index1].type == 36)
            {
              Vector2 vector2 = new Vector2((float) ((double) Main.npc[index1].position.X + (double) Main.npc[index1].width * 0.5 - 5.0 * (double) Main.npc[index1].ai[0]), Main.npc[index1].position.Y + 20f);
              for (int index3 = 0; index3 < 2; ++index3)
              {
                float num21 = Main.npc[(int) Main.npc[index1].ai[1]].position.X + (float) (Main.npc[(int) Main.npc[index1].ai[1]].width / 2) - vector2.X;
                float num22 = Main.npc[(int) Main.npc[index1].ai[1]].position.Y + (float) (Main.npc[(int) Main.npc[index1].ai[1]].height / 2) - vector2.Y;
                float num23;
                float num24;
                float num25;
                if (index3 == 0)
                {
                  num23 = num21 - 200f * Main.npc[index1].ai[0];
                  num24 = num22 + 130f;
                  num25 = 92f / (float) Math.Sqrt((double) num23 * (double) num23 + (double) num24 * (double) num24);
                  vector2.X += num23 * num25;
                  vector2.Y += num24 * num25;
                }
                else
                {
                  num23 = num21 - 50f * Main.npc[index1].ai[0];
                  num24 = num22 + 80f;
                  num25 = 60f / (float) Math.Sqrt((double) num23 * (double) num23 + (double) num24 * (double) num24);
                  vector2.X += num23 * num25;
                  vector2.Y += num24 * num25;
                }
                float rotation = (float) Math.Atan2((double) num24, (double) num23) - 1.57f;
                Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
                this.spriteBatch.Draw(Main.boneArmTexture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color, rotation, new Vector2((float) Main.boneArmTexture.Width * 0.5f, (float) Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
                if (index3 == 0)
                {
                  vector2.X += (float) ((double) num23 * (double) num25 / 2.0);
                  vector2.Y += (float) ((double) num24 * (double) num25 / 2.0);
                }
                else if (this.IsActive)
                {
                  vector2.X += (float) ((double) num23 * (double) num25 - 16.0);
                  vector2.Y += (float) ((double) num24 * (double) num25 - 6.0);
                  int index4 = Dust.NewDust(new Vector2(vector2.X, vector2.Y), 30, 10, 5, num23 * 0.02f, num24 * 0.02f, Scale: 2f);
                  Main.dust[index4].noGravity = true;
                }
              }
            }
            if (Main.npc[index1].aiStyle >= 33 && Main.npc[index1].aiStyle <= 36)
            {
              Vector2 vector2 = new Vector2((float) ((double) Main.npc[index1].position.X + (double) Main.npc[index1].width * 0.5 - 5.0 * (double) Main.npc[index1].ai[0]), Main.npc[index1].position.Y + 20f);
              for (int index5 = 0; index5 < 2; ++index5)
              {
                float num26 = Main.npc[(int) Main.npc[index1].ai[1]].position.X + (float) (Main.npc[(int) Main.npc[index1].ai[1]].width / 2) - vector2.X;
                float num27 = Main.npc[(int) Main.npc[index1].ai[1]].position.Y + (float) (Main.npc[(int) Main.npc[index1].ai[1]].height / 2) - vector2.Y;
                float num28;
                float num29;
                float num30;
                if (index5 == 0)
                {
                  num28 = num26 - 200f * Main.npc[index1].ai[0];
                  num29 = num27 + 130f;
                  num30 = 92f / (float) Math.Sqrt((double) num28 * (double) num28 + (double) num29 * (double) num29);
                  vector2.X += num28 * num30;
                  vector2.Y += num29 * num30;
                }
                else
                {
                  num28 = num26 - 50f * Main.npc[index1].ai[0];
                  num29 = num27 + 80f;
                  num30 = 60f / (float) Math.Sqrt((double) num28 * (double) num28 + (double) num29 * (double) num29);
                  vector2.X += num28 * num30;
                  vector2.Y += num29 * num30;
                }
                float rotation = (float) Math.Atan2((double) num29, (double) num28) - 1.57f;
                Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
                this.spriteBatch.Draw(Main.boneArm2Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color, rotation, new Vector2((float) Main.boneArmTexture.Width * 0.5f, (float) Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
                if (index5 == 0)
                {
                  vector2.X += (float) ((double) num28 * (double) num30 / 2.0);
                  vector2.Y += (float) ((double) num29 * (double) num30 / 2.0);
                }
                else if (this.IsActive)
                {
                  vector2.X += (float) ((double) num28 * (double) num30 - 16.0);
                  vector2.Y += (float) ((double) num29 * (double) num30 - 6.0);
                  int index6 = Dust.NewDust(new Vector2(vector2.X, vector2.Y), 30, 10, 6, num28 * 0.02f, num29 * 0.02f, Scale: 2.5f);
                  Main.dust[index6].noGravity = true;
                }
              }
            }
            if (Main.npc[index1].aiStyle == 20)
            {
              Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) (Main.npc[index1].width / 2), Main.npc[index1].position.Y + (float) (Main.npc[index1].height / 2));
              float num31 = Main.npc[index1].ai[1] - vector2.X;
              float num32 = Main.npc[index1].ai[2] - vector2.Y;
              float rotation = (float) Math.Atan2((double) num32, (double) num31) - 1.57f;
              Main.npc[index1].rotation = rotation;
              bool flag6 = true;
              while (flag6)
              {
                int height = 12;
                float num33 = (float) Math.Sqrt((double) num31 * (double) num31 + (double) num32 * (double) num32);
                if ((double) num33 < 20.0)
                {
                  height = (int) num33 - 20 + 12;
                  flag6 = false;
                }
                float num34 = 12f / num33;
                float num35 = num31 * num34;
                float num36 = num32 * num34;
                vector2.X += num35;
                vector2.Y += num36;
                num31 = Main.npc[index1].ai[1] - vector2.X;
                num32 = Main.npc[index1].ai[2] - vector2.Y;
                Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
                this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chainTexture.Width, height)), color, rotation, new Vector2((float) Main.chainTexture.Width * 0.5f, (float) Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
              }
              this.spriteBatch.Draw(Main.spikeBaseTexture, new Vector2(Main.npc[index1].ai[1] - Main.screenPosition.X, Main.npc[index1].ai[2] - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.spikeBaseTexture.Width, Main.spikeBaseTexture.Height)), Lighting.GetColor((int) Main.npc[index1].ai[1] / 16, (int) ((double) Main.npc[index1].ai[2] / 16.0)), rotation - 0.75f, new Vector2((float) Main.spikeBaseTexture.Width * 0.5f, (float) Main.spikeBaseTexture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
            }
            Microsoft.Xna.Framework.Color color1 = Lighting.GetColor((int) ((double) Main.npc[index1].position.X + (double) Main.npc[index1].width * 0.5) / 16, (int) (((double) Main.npc[index1].position.Y + (double) Main.npc[index1].height * 0.5) / 16.0));
            if (behindTiles && Main.npc[index1].type != 113 && Main.npc[index1].type != 114)
            {
              int num37 = (int) (((double) Main.npc[index1].position.X - 8.0) / 16.0);
              int num38 = (int) (((double) Main.npc[index1].position.X + (double) Main.npc[index1].width + 8.0) / 16.0);
              int num39 = (int) (((double) Main.npc[index1].position.Y - 8.0) / 16.0);
              int num40 = (int) (((double) Main.npc[index1].position.Y + (double) Main.npc[index1].height + 8.0) / 16.0);
              for (int x = num37; x <= num38; ++x)
              {
                for (int y = num39; y <= num40; ++y)
                {
                  if ((double) Lighting.Brightness(x, y) == 0.0)
                    color1 = Microsoft.Xna.Framework.Color.Black;
                }
              }
            }
            float num41 = 1f;
            float G = 1f;
            float num42 = 1f;
            float A = 1f;
            if (Main.npc[index1].poisoned)
            {
              if (Main.rand.Next(30) == 0)
              {
                int index7 = Dust.NewDust(Main.npc[index1].position, Main.npc[index1].width, Main.npc[index1].height, 46, Alpha: 120, Scale: 0.2f);
                Main.dust[index7].noGravity = true;
                Main.dust[index7].fadeIn = 1.9f;
              }
              float R = num41 * 0.65f;
              float B = num42 * 0.75f;
              color1 = Main.buffColor(color1, R, G, B, A);
            }
            if (Main.npc[index1].onFire)
            {
              if (Main.rand.Next(4) < 3)
              {
                int index8 = Dust.NewDust(new Vector2(Main.npc[index1].position.X - 2f, Main.npc[index1].position.Y - 2f), Main.npc[index1].width + 4, Main.npc[index1].height + 4, 6, Main.npc[index1].velocity.X * 0.4f, Main.npc[index1].velocity.Y * 0.4f, 100, Scale: 3.5f);
                Main.dust[index8].noGravity = true;
                Main.dust[index8].velocity *= 1.8f;
                Main.dust[index8].velocity.Y -= 0.5f;
                if (Main.rand.Next(4) == 0)
                {
                  Main.dust[index8].noGravity = false;
                  Main.dust[index8].scale *= 0.5f;
                }
              }
              Lighting.addLight((int) ((double) Main.npc[index1].position.X / 16.0), (int) ((double) Main.npc[index1].position.Y / 16.0 + 1.0), 1f, 0.3f, 0.1f);
            }
            if (Main.npc[index1].onFire2)
            {
              if (Main.rand.Next(4) < 3)
              {
                int index9 = Dust.NewDust(new Vector2(Main.npc[index1].position.X - 2f, Main.npc[index1].position.Y - 2f), Main.npc[index1].width + 4, Main.npc[index1].height + 4, 75, Main.npc[index1].velocity.X * 0.4f, Main.npc[index1].velocity.Y * 0.4f, 100, Scale: 3.5f);
                Main.dust[index9].noGravity = true;
                Main.dust[index9].velocity *= 1.8f;
                Main.dust[index9].velocity.Y -= 0.5f;
                if (Main.rand.Next(4) == 0)
                {
                  Main.dust[index9].noGravity = false;
                  Main.dust[index9].scale *= 0.5f;
                }
              }
              Lighting.addLight((int) ((double) Main.npc[index1].position.X / 16.0), (int) ((double) Main.npc[index1].position.Y / 16.0 + 1.0), 1f, 0.3f, 0.1f);
            }
            if (Main.player[Main.myPlayer].detectCreature && Main.npc[index1].lifeMax > 1)
            {
              if (color1.R < (byte) 150)
                color1.A = Main.mouseTextColor;
              if (color1.R < (byte) 50)
                color1.R = (byte) 50;
              if (color1.G < (byte) 200)
                color1.G = (byte) 200;
              if (color1.B < (byte) 100)
                color1.B = (byte) 100;
              if (!Main.gamePaused && this.IsActive && Main.rand.Next(50) == 0)
              {
                int index10 = Dust.NewDust(new Vector2(Main.npc[index1].position.X, Main.npc[index1].position.Y), Main.npc[index1].width, Main.npc[index1].height, 15, Alpha: 150, Scale: 0.8f);
                Main.dust[index10].velocity *= 0.1f;
                Main.dust[index10].noLight = true;
              }
            }
            if (Main.npc[index1].type == 50)
            {
              Vector2 vector2 = new Vector2();
              float num43 = 0.0f;
              vector2.Y -= Main.npc[index1].velocity.Y;
              vector2.X -= Main.npc[index1].velocity.X * 2f;
              float rotation = num43 + Main.npc[index1].velocity.X * 0.05f;
              if (Main.npc[index1].frame.Y == 120)
                vector2.Y += 2f;
              if (Main.npc[index1].frame.Y == 360)
                vector2.Y -= 2f;
              if (Main.npc[index1].frame.Y == 480)
                vector2.Y -= 6f;
              this.spriteBatch.Draw(Main.ninjaTexture, new Vector2(Main.npc[index1].position.X - Main.screenPosition.X + (float) (Main.npc[index1].width / 2) + vector2.X, Main.npc[index1].position.Y - Main.screenPosition.Y + (float) (Main.npc[index1].height / 2) + vector2.Y), new Rectangle?(new Rectangle(0, 0, Main.ninjaTexture.Width, Main.ninjaTexture.Height)), color1, rotation, new Vector2((float) (Main.ninjaTexture.Width / 2), (float) (Main.ninjaTexture.Height / 2)), 1f, SpriteEffects.None, 0.0f);
            }
            if (Main.npc[index1].type == 71)
            {
              Vector2 vector2 = new Vector2();
              float num44 = 0.0f;
              vector2.Y -= Main.npc[index1].velocity.Y * 0.3f;
              vector2.X -= Main.npc[index1].velocity.X * 0.6f;
              float rotation = num44 + Main.npc[index1].velocity.X * 0.09f;
              if (Main.npc[index1].frame.Y == 120)
                vector2.Y += 2f;
              if (Main.npc[index1].frame.Y == 360)
                vector2.Y -= 2f;
              if (Main.npc[index1].frame.Y == 480)
                vector2.Y -= 6f;
              this.spriteBatch.Draw(Main.itemTexture[327], new Vector2(Main.npc[index1].position.X - Main.screenPosition.X + (float) (Main.npc[index1].width / 2) + vector2.X, Main.npc[index1].position.Y - Main.screenPosition.Y + (float) (Main.npc[index1].height / 2) + vector2.Y), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[327].Width, Main.itemTexture[327].Height)), color1, rotation, new Vector2((float) (Main.itemTexture[327].Width / 2), (float) (Main.itemTexture[327].Height / 2)), 1f, SpriteEffects.None, 0.0f);
            }
            if (Main.npc[index1].type == 69)
              this.spriteBatch.Draw(Main.antLionTexture, new Vector2(Main.npc[index1].position.X - Main.screenPosition.X + (float) (Main.npc[index1].width / 2), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height + 14.0)), new Rectangle?(new Rectangle(0, 0, Main.antLionTexture.Width, Main.antLionTexture.Height)), color1, (float) (-(double) Main.npc[index1].rotation * 0.300000011920929), new Vector2((float) (Main.antLionTexture.Width / 2), (float) (Main.antLionTexture.Height / 2)), 1f, SpriteEffects.None, 0.0f);
            float num45 = 0.0f;
            float num46 = 0.0f;
            Vector2 origin = new Vector2((float) (Main.npcTexture[Main.npc[index1].type].Width / 2), (float) (Main.npcTexture[Main.npc[index1].type].Height / Main.npcFrameCount[Main.npc[index1].type] / 2));
            if (Main.npc[index1].type == 108 || Main.npc[index1].type == 124)
              num45 = 2f;
            if (Main.npc[index1].type == 4)
              origin = new Vector2(55f, 107f);
            else if (Main.npc[index1].type == 125)
            {
              origin = new Vector2(55f, 107f);
              num46 = 30f;
            }
            else if (Main.npc[index1].type == 126)
            {
              origin = new Vector2(55f, 107f);
              num46 = 30f;
            }
            else if (Main.npc[index1].type == 6)
              num46 = 26f;
            else if (Main.npc[index1].type == 94)
              num46 = 14f;
            else if (Main.npc[index1].type == 7 || Main.npc[index1].type == 8 || Main.npc[index1].type == 9)
              num46 = 13f;
            else if (Main.npc[index1].type == 98 || Main.npc[index1].type == 99 || Main.npc[index1].type == 100)
              num46 = 13f;
            else if (Main.npc[index1].type == 95 || Main.npc[index1].type == 96 || Main.npc[index1].type == 97)
              num46 = 13f;
            else if (Main.npc[index1].type == 10 || Main.npc[index1].type == 11 || Main.npc[index1].type == 12)
              num46 = 8f;
            else if (Main.npc[index1].type == 13 || Main.npc[index1].type == 14 || Main.npc[index1].type == 15)
              num46 = 26f;
            else if (Main.npc[index1].type == 48)
              num46 = 32f;
            else if (Main.npc[index1].type == 49 || Main.npc[index1].type == 51)
              num46 = 4f;
            else if (Main.npc[index1].type == 60)
              num46 = 10f;
            else if (Main.npc[index1].type == 62 || Main.npc[index1].type == 66)
              num46 = 14f;
            else if (Main.npc[index1].type == 63 || Main.npc[index1].type == 64 || Main.npc[index1].type == 103)
            {
              num46 = 4f;
              origin.Y += 4f;
            }
            else if (Main.npc[index1].type == 65)
              num46 = 14f;
            else if (Main.npc[index1].type == 69)
            {
              num46 = 4f;
              origin.Y += 8f;
            }
            else if (Main.npc[index1].type == 70)
              num46 = -4f;
            else if (Main.npc[index1].type == 72)
              num46 = -2f;
            else if (Main.npc[index1].type == 83 || Main.npc[index1].type == 84)
              num46 = 20f;
            else if (Main.npc[index1].type == 39 || Main.npc[index1].type == 40 || Main.npc[index1].type == 41)
              num46 = 26f;
            else if (Main.npc[index1].type >= 87 && Main.npc[index1].type <= 92)
              num46 = 56f;
            else if (Main.npc[index1].type >= 134 && Main.npc[index1].type <= 136)
              num46 = 30f;
            float num47 = num46 * Main.npc[index1].scale;
            if (Main.npc[index1].aiStyle == 10 || Main.npc[index1].type == 72)
              color1 = Microsoft.Xna.Framework.Color.White;
            SpriteEffects effects = SpriteEffects.None;
            if (Main.npc[index1].spriteDirection == 1)
              effects = SpriteEffects.FlipHorizontally;
            if (Main.npc[index1].type == 83 || Main.npc[index1].type == 84)
              this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), Microsoft.Xna.Framework.Color.White, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
            else if (Main.npc[index1].type >= 87 && Main.npc[index1].type <= 92)
            {
              Microsoft.Xna.Framework.Color alpha = Main.npc[index1].GetAlpha(color1);
              byte num48 = (byte) (((int) Main.tileColor.R + (int) Main.tileColor.G + (int) Main.tileColor.B) / 3);
              if ((int) alpha.R < (int) num48)
                alpha.R = num48;
              if ((int) alpha.G < (int) num48)
                alpha.G = num48;
              if ((int) alpha.B < (int) num48)
                alpha.B = num48;
              this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), alpha, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
            }
            else
            {
              if (Main.npc[index1].type == 94)
              {
                for (int index11 = 1; index11 < 6; index11 += 2)
                {
                  Vector2 oldPo = Main.npc[index1].oldPos[index11];
                  Microsoft.Xna.Framework.Color alpha = Main.npc[index1].GetAlpha(color1);
                  alpha.R = (byte) ((int) alpha.R * (10 - index11) / 15);
                  alpha.G = (byte) ((int) alpha.G * (10 - index11) / 15);
                  alpha.B = (byte) ((int) alpha.B * (10 - index11) / 15);
                  alpha.A = (byte) ((int) alpha.A * (10 - index11) / 15);
                  this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].oldPos[index11].X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index11].Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47), new Rectangle?(Main.npc[index1].frame), alpha, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
                }
              }
              if (Main.npc[index1].type == 125 || Main.npc[index1].type == 126 || Main.npc[index1].type == (int) sbyte.MaxValue || Main.npc[index1].type == 128 || Main.npc[index1].type == 129 || Main.npc[index1].type == 130 || Main.npc[index1].type == 131 || Main.npc[index1].type == 139 || Main.npc[index1].type == 140)
              {
                for (int index12 = 9; index12 >= 0; index12 -= 2)
                {
                  Vector2 oldPo = Main.npc[index1].oldPos[index12];
                  Microsoft.Xna.Framework.Color alpha = Main.npc[index1].GetAlpha(color1);
                  alpha.R = (byte) ((int) alpha.R * (10 - index12) / 20);
                  alpha.G = (byte) ((int) alpha.G * (10 - index12) / 20);
                  alpha.B = (byte) ((int) alpha.B * (10 - index12) / 20);
                  alpha.A = (byte) ((int) alpha.A * (10 - index12) / 20);
                  this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].oldPos[index12].X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index12].Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47), new Rectangle?(Main.npc[index1].frame), alpha, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
                }
              }
              this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), Main.npc[index1].GetAlpha(color1), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].color != new Microsoft.Xna.Framework.Color())
                this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), Main.npc[index1].GetColor(color1), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].confused)
                this.spriteBatch.Draw(Main.confuseTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale + (double) num47 + (double) num45 - (double) Main.confuseTexture.Height - 20.0)), new Rectangle?(new Rectangle(0, 0, Main.confuseTexture.Width, Main.confuseTexture.Height)), new Microsoft.Xna.Framework.Color(250, 250, 250, 70), Main.npc[index1].velocity.X * -0.05f, new Vector2((float) (Main.confuseTexture.Width / 2), (float) (Main.confuseTexture.Height / 2)), Main.essScale + 0.2f, SpriteEffects.None, 0.0f);
              if (Main.npc[index1].type >= 134 && Main.npc[index1].type <= 136 && color1 != Microsoft.Xna.Framework.Color.Black)
                this.spriteBatch.Draw(Main.destTexture[Main.npc[index1].type - 134], new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].type == 125)
                this.spriteBatch.Draw(Main.EyeLaserTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].type == 139)
                this.spriteBatch.Draw(Main.probeTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].type == (int) sbyte.MaxValue)
                this.spriteBatch.Draw(Main.BoneEyesTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].type == 131)
                this.spriteBatch.Draw(Main.BoneLaserTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47 + num45), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
              if (Main.npc[index1].type == 120)
              {
                for (int index13 = 1; index13 < Main.npc[index1].oldPos.Length; ++index13)
                {
                  Vector2 oldPo = Main.npc[index1].oldPos[index13];
                  this.spriteBatch.Draw(Main.chaosTexture, new Vector2((float) ((double) Main.npc[index1].oldPos[index13].X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index13].Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color()
                  {
                    R = (byte) (150 * (10 - index13) / 15),
                    G = (byte) (100 * (10 - index13) / 15),
                    B = (byte) (150 * (10 - index13) / 15),
                    A = (byte) (50 * (10 - index13) / 15)
                  }, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
                }
              }
              else if (Main.npc[index1].type == 137 || Main.npc[index1].type == 138)
              {
                for (int index14 = 1; index14 < Main.npc[index1].oldPos.Length; ++index14)
                {
                  Vector2 oldPo = Main.npc[index1].oldPos[index14];
                  this.spriteBatch.Draw(Main.npcTexture[Main.npc[index1].type], new Vector2((float) ((double) Main.npc[index1].oldPos[index14].X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index14].Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47), new Rectangle?(Main.npc[index1].frame), new Microsoft.Xna.Framework.Color()
                  {
                    R = (byte) (150 * (10 - index14) / 15),
                    G = (byte) (100 * (10 - index14) / 15),
                    B = (byte) (150 * (10 - index14) / 15),
                    A = (byte) (50 * (10 - index14) / 15)
                  }, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
                }
              }
              else if (Main.npc[index1].type == 82)
              {
                this.spriteBatch.Draw(Main.wraithEyeTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47), new Rectangle?(Main.npc[index1].frame), Microsoft.Xna.Framework.Color.White, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
                for (int index15 = 1; index15 < 10; ++index15)
                {
                  Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color(110 - index15 * 10, 110 - index15 * 10, 110 - index15 * 10, 110 - index15 * 10);
                  this.spriteBatch.Draw(Main.wraithEyeTexture, new Vector2((float) ((double) Main.npc[index1].position.X - (double) Main.screenPosition.X + (double) (Main.npc[index1].width / 2) - (double) Main.npcTexture[Main.npc[index1].type].Width * (double) Main.npc[index1].scale / 2.0 + (double) origin.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) Main.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npcTexture[Main.npc[index1].type].Height * (double) Main.npc[index1].scale / (double) Main.npcFrameCount[Main.npc[index1].type] + 4.0 + (double) origin.Y * (double) Main.npc[index1].scale) + num47) - Main.npc[index1].velocity * (float) index15 * 0.5f, new Rectangle?(Main.npc[index1].frame), color2, Main.npc[index1].rotation, origin, Main.npc[index1].scale, effects, 0.0f);
                }
              }
            }
          }
        }
      }
    }

    protected void DrawProj(int i)
    {
      if (Main.projectile[i].type == 32)
      {
        Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float) Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float) Main.projectile[i].height * 0.5f);
        float num1 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
        float num2 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        float rotation = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        bool flag = true;
        if ((double) num1 == 0.0 && (double) num2 == 0.0)
        {
          flag = false;
        }
        else
        {
          float num3 = 8f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
          float num4 = num1 * num3;
          float num5 = num2 * num3;
          vector2.X -= num4;
          vector2.Y -= num5;
          num1 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
          num2 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        }
        while (flag)
        {
          float num6 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
          if ((double) num6 < 28.0)
          {
            flag = false;
          }
          else
          {
            float num7 = 28f / num6;
            float num8 = num1 * num7;
            float num9 = num2 * num7;
            vector2.X += num8;
            vector2.Y += num9;
            num1 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
            num2 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            this.spriteBatch.Draw(Main.chain5Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain5Texture.Width, Main.chain5Texture.Height)), color, rotation, new Vector2((float) Main.chain5Texture.Width * 0.5f, (float) Main.chain5Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      else if (Main.projectile[i].type == 73)
      {
        Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float) Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float) Main.projectile[i].height * 0.5f);
        float num10 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
        float num11 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        float rotation = (float) Math.Atan2((double) num11, (double) num10) - 1.57f;
        bool flag = true;
        while (flag)
        {
          float num12 = (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
          if ((double) num12 < 25.0)
          {
            flag = false;
          }
          else
          {
            float num13 = 12f / num12;
            float num14 = num10 * num13;
            float num15 = num11 * num13;
            vector2.X += num14;
            vector2.Y += num15;
            num10 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
            num11 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            this.spriteBatch.Draw(Main.chain8Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color, rotation, new Vector2((float) Main.chain8Texture.Width * 0.5f, (float) Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      else if (Main.projectile[i].type == 74)
      {
        Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float) Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float) Main.projectile[i].height * 0.5f);
        float num16 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
        float num17 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        float rotation = (float) Math.Atan2((double) num17, (double) num16) - 1.57f;
        bool flag = true;
        while (flag)
        {
          float num18 = (float) Math.Sqrt((double) num16 * (double) num16 + (double) num17 * (double) num17);
          if ((double) num18 < 25.0)
          {
            flag = false;
          }
          else
          {
            float num19 = 12f / num18;
            float num20 = num16 * num19;
            float num21 = num17 * num19;
            vector2.X += num20;
            vector2.Y += num21;
            num16 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
            num17 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            this.spriteBatch.Draw(Main.chain9Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color, rotation, new Vector2((float) Main.chain8Texture.Width * 0.5f, (float) Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      else if (Main.projectile[i].aiStyle == 7)
      {
        Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float) Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float) Main.projectile[i].height * 0.5f);
        float num22 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
        float num23 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        float rotation = (float) Math.Atan2((double) num23, (double) num22) - 1.57f;
        bool flag = true;
        while (flag)
        {
          float num24 = (float) Math.Sqrt((double) num22 * (double) num22 + (double) num23 * (double) num23);
          if ((double) num24 < 25.0)
          {
            flag = false;
          }
          else
          {
            float num25 = 12f / num24;
            float num26 = num22 * num25;
            float num27 = num23 * num25;
            vector2.X += num26;
            vector2.Y += num27;
            num22 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
            num23 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chainTexture.Width, Main.chainTexture.Height)), color, rotation, new Vector2((float) Main.chainTexture.Width * 0.5f, (float) Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      else if (Main.projectile[i].aiStyle == 13)
      {
        float num28 = Main.projectile[i].position.X + 8f;
        float num29 = Main.projectile[i].position.Y + 2f;
        float x1 = Main.projectile[i].velocity.X;
        float y1 = Main.projectile[i].velocity.Y;
        float num30 = 20f / (float) Math.Sqrt((double) x1 * (double) x1 + (double) y1 * (double) y1);
        float x2;
        float y2;
        if ((double) Main.projectile[i].ai[0] == 0.0)
        {
          x2 = num28 - Main.projectile[i].velocity.X * num30;
          y2 = num29 - Main.projectile[i].velocity.Y * num30;
        }
        else
        {
          x2 = num28 + Main.projectile[i].velocity.X * num30;
          y2 = num29 + Main.projectile[i].velocity.Y * num30;
        }
        Vector2 vector2 = new Vector2(x2, y2);
        float num31 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
        float num32 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        float rotation = (float) Math.Atan2((double) num32, (double) num31) - 1.57f;
        if (Main.projectile[i].alpha == 0)
        {
          int num33 = -1;
          if ((double) Main.projectile[i].position.X + (double) (Main.projectile[i].width / 2) < (double) Main.player[Main.projectile[i].owner].position.X + (double) (Main.player[Main.projectile[i].owner].width / 2))
            num33 = 1;
          Main.player[Main.projectile[i].owner].itemRotation = Main.player[Main.projectile[i].owner].direction != 1 ? (float) Math.Atan2((double) num32 * (double) num33, (double) num31 * (double) num33) : (float) Math.Atan2((double) num32 * (double) num33, (double) num31 * (double) num33);
        }
        bool flag = true;
        while (flag)
        {
          float num34 = (float) Math.Sqrt((double) num31 * (double) num31 + (double) num32 * (double) num32);
          if ((double) num34 < 25.0)
          {
            flag = false;
          }
          else
          {
            float num35 = 12f / num34;
            float num36 = num31 * num35;
            float num37 = num32 * num35;
            vector2.X += num36;
            vector2.Y += num37;
            num31 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
            num32 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chainTexture.Width, Main.chainTexture.Height)), color, rotation, new Vector2((float) Main.chainTexture.Width * 0.5f, (float) Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      else if (Main.projectile[i].aiStyle == 15)
      {
        Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float) Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float) Main.projectile[i].height * 0.5f);
        float num38 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
        float num39 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
        float rotation = (float) Math.Atan2((double) num39, (double) num38) - 1.57f;
        if (Main.projectile[i].alpha == 0)
        {
          int num40 = -1;
          if ((double) Main.projectile[i].position.X + (double) (Main.projectile[i].width / 2) < (double) Main.player[Main.projectile[i].owner].position.X + (double) (Main.player[Main.projectile[i].owner].width / 2))
            num40 = 1;
          Main.player[Main.projectile[i].owner].itemRotation = Main.player[Main.projectile[i].owner].direction != 1 ? (float) Math.Atan2((double) num39 * (double) num40, (double) num38 * (double) num40) : (float) Math.Atan2((double) num39 * (double) num40, (double) num38 * (double) num40);
        }
        bool flag = true;
        while (flag)
        {
          float num41 = (float) Math.Sqrt((double) num38 * (double) num38 + (double) num39 * (double) num39);
          if ((double) num41 < 25.0)
          {
            flag = false;
          }
          else
          {
            float num42 = 12f / num41;
            float num43 = num38 * num42;
            float num44 = num39 * num42;
            vector2.X += num43;
            vector2.Y += num44;
            num38 = Main.player[Main.projectile[i].owner].position.X + (float) (Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
            num39 = Main.player[Main.projectile[i].owner].position.Y + (float) (Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            if (Main.projectile[i].type == 25)
              this.spriteBatch.Draw(Main.chain2Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain2Texture.Width, Main.chain2Texture.Height)), color, rotation, new Vector2((float) Main.chain2Texture.Width * 0.5f, (float) Main.chain2Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
            else if (Main.projectile[i].type == 35)
              this.spriteBatch.Draw(Main.chain6Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain6Texture.Width, Main.chain6Texture.Height)), color, rotation, new Vector2((float) Main.chain6Texture.Width * 0.5f, (float) Main.chain6Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
            else if (Main.projectile[i].type == 63)
              this.spriteBatch.Draw(Main.chain7Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain7Texture.Width, Main.chain7Texture.Height)), color, rotation, new Vector2((float) Main.chain7Texture.Width * 0.5f, (float) Main.chain7Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
            else
              this.spriteBatch.Draw(Main.chain3Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain3Texture.Width, Main.chain3Texture.Height)), color, rotation, new Vector2((float) Main.chain3Texture.Width * 0.5f, (float) Main.chain3Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
      Microsoft.Xna.Framework.Color newColor = Lighting.GetColor((int) ((double) Main.projectile[i].position.X + (double) Main.projectile[i].width * 0.5) / 16, (int) (((double) Main.projectile[i].position.Y + (double) Main.projectile[i].height * 0.5) / 16.0));
      if (Main.projectile[i].hide)
        newColor = Lighting.GetColor((int) ((double) Main.player[Main.projectile[i].owner].position.X + (double) Main.player[Main.projectile[i].owner].width * 0.5) / 16, (int) (((double) Main.player[Main.projectile[i].owner].position.Y + (double) Main.player[Main.projectile[i].owner].height * 0.5) / 16.0));
      if (Main.projectile[i].type == 14)
        newColor = Microsoft.Xna.Framework.Color.White;
      int num45 = 0;
      int num46 = 0;
      if (Main.projectile[i].type == 16)
        num45 = 6;
      if (Main.projectile[i].type == 17 || Main.projectile[i].type == 31)
        num45 = 2;
      if (Main.projectile[i].type == 25 || Main.projectile[i].type == 26 || Main.projectile[i].type == 35 || Main.projectile[i].type == 63)
      {
        num45 = 6;
        num46 -= 6;
      }
      if (Main.projectile[i].type == 28 || Main.projectile[i].type == 37 || Main.projectile[i].type == 75)
        num45 = 8;
      if (Main.projectile[i].type == 29)
        num45 = 11;
      if (Main.projectile[i].type == 43)
        num45 = 4;
      if (Main.projectile[i].type == 69 || Main.projectile[i].type == 70)
      {
        num45 = 4;
        num46 = 4;
      }
      float x = (float) ((double) (Main.projectileTexture[Main.projectile[i].type].Width - Main.projectile[i].width) * 0.5 + (double) Main.projectile[i].width * 0.5);
      if (Main.projectile[i].type == 50 || Main.projectile[i].type == 53)
        num46 = -8;
      if (Main.projectile[i].type == 72 || Main.projectile[i].type == 86 || Main.projectile[i].type == 87)
      {
        num46 = -16;
        num45 = 8;
      }
      if (Main.projectile[i].type == 74)
        num46 = -6;
      if (Main.projectile[i].type == 99)
        num45 = 1;
      if (Main.projectile[i].type == 111)
      {
        num45 = 18;
        num46 = -16;
      }
      SpriteEffects effects = SpriteEffects.None;
      if (Main.projectile[i].spriteDirection == -1)
        effects = SpriteEffects.FlipHorizontally;
      if (Main.projFrames[Main.projectile[i].type] > 1)
      {
        int height = Main.projectileTexture[Main.projectile[i].type].Height / Main.projFrames[Main.projectile[i].type];
        int y = height * Main.projectile[i].frame;
        if (Main.projectile[i].type == 111)
        {
          Microsoft.Xna.Framework.Color oldColor = new Microsoft.Xna.Framework.Color((int) Main.player[Main.projectile[i].owner].shirtColor.R, (int) Main.player[Main.projectile[i].owner].shirtColor.G, (int) Main.player[Main.projectile[i].owner].shirtColor.B);
          Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) ((double) Main.projectile[i].position.X + (double) Main.projectile[i].width * 0.5) / 16, (int) (((double) Main.projectile[i].position.Y + (double) Main.projectile[i].height * 0.5) / 16.0), oldColor);
          this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + x + (float) num46, Main.projectile[i].position.Y - Main.screenPosition.Y + (float) (Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, y, Main.projectileTexture[Main.projectile[i].type].Width, height)), Main.projectile[i].GetAlpha(color), Main.projectile[i].rotation, new Vector2(x, (float) (Main.projectile[i].height / 2 + num45)), Main.projectile[i].scale, effects, 0.0f);
        }
        else
          this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + x + (float) num46, Main.projectile[i].position.Y - Main.screenPosition.Y + (float) (Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, y, Main.projectileTexture[Main.projectile[i].type].Width, height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, new Vector2(x, (float) (Main.projectile[i].height / 2 + num45)), Main.projectile[i].scale, effects, 0.0f);
      }
      else if (Main.projectile[i].aiStyle == 19)
      {
        Vector2 origin = new Vector2(0.0f, 0.0f);
        if (Main.projectile[i].spriteDirection == -1)
          origin.X = (float) Main.projectileTexture[Main.projectile[i].type].Width;
        this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + (float) (Main.projectile[i].width / 2), Main.projectile[i].position.Y - Main.screenPosition.Y + (float) (Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, origin, Main.projectile[i].scale, effects, 0.0f);
      }
      else
      {
        if (Main.projectile[i].type == 94 && (double) Main.projectile[i].ai[1] > 6.0)
        {
          for (int index = 0; index < 10; ++index)
          {
            Microsoft.Xna.Framework.Color alpha = Main.projectile[i].GetAlpha(newColor);
            float num47 = (float) (9 - index) / 9f;
            alpha.R = (byte) ((double) alpha.R * (double) num47);
            alpha.G = (byte) ((double) alpha.G * (double) num47);
            alpha.B = (byte) ((double) alpha.B * (double) num47);
            alpha.A = (byte) ((double) alpha.A * (double) num47);
            float num48 = (float) (9 - index) / 9f;
            this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].oldPos[index].X - Main.screenPosition.X + x + (float) num46, Main.projectile[i].oldPos[index].Y - Main.screenPosition.Y + (float) (Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), alpha, Main.projectile[i].rotation, new Vector2(x, (float) (Main.projectile[i].height / 2 + num45)), num48 * Main.projectile[i].scale, effects, 0.0f);
          }
        }
        this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + x + (float) num46, Main.projectile[i].position.Y - Main.screenPosition.Y + (float) (Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, new Vector2(x, (float) (Main.projectile[i].height / 2 + num45)), Main.projectile[i].scale, effects, 0.0f);
        if (Main.projectile[i].type != 106)
          return;
        this.spriteBatch.Draw(Main.lightDiscTexture, new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + x + (float) num46, Main.projectile[i].position.Y - Main.screenPosition.Y + (float) (Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), new Microsoft.Xna.Framework.Color(200, 200, 200, 0), Main.projectile[i].rotation, new Vector2(x, (float) (Main.projectile[i].height / 2 + num45)), Main.projectile[i].scale, effects, 0.0f);
      }
    }

    private static Microsoft.Xna.Framework.Color buffColor(
      Microsoft.Xna.Framework.Color newColor,
      float R,
      float G,
      float B,
      float A)
    {
      newColor.R = (byte) ((double) newColor.R * (double) R);
      newColor.G = (byte) ((double) newColor.G * (double) G);
      newColor.B = (byte) ((double) newColor.B * (double) B);
      newColor.A = (byte) ((double) newColor.A * (double) A);
      return newColor;
    }

    protected void DrawWoF()
    {
      if (Main.wof < 0 || !Main.player[Main.myPlayer].gross)
        return;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active && Main.player[index].tongued && !Main.player[index].dead)
        {
          float num1 = Main.npc[Main.wof].position.X + (float) (Main.npc[Main.wof].width / 2);
          float num2 = Main.npc[Main.wof].position.Y + (float) (Main.npc[Main.wof].height / 2);
          Vector2 vector2 = new Vector2(Main.player[index].position.X + (float) Main.player[index].width * 0.5f, Main.player[index].position.Y + (float) Main.player[index].height * 0.5f);
          float num3 = num1 - vector2.X;
          float num4 = num2 - vector2.Y;
          float rotation = (float) Math.Atan2((double) num4, (double) num3) - 1.57f;
          bool flag = true;
          while (flag)
          {
            float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
            if ((double) num5 < 40.0)
            {
              flag = false;
            }
            else
            {
              float num6 = (float) Main.chain12Texture.Height / num5;
              float num7 = num3 * num6;
              float num8 = num4 * num6;
              vector2.X += num7;
              vector2.Y += num8;
              num3 = num1 - vector2.X;
              num4 = num2 - vector2.Y;
              Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
              this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain12Texture.Width, Main.chain12Texture.Height)), color, rotation, new Vector2((float) Main.chain12Texture.Width * 0.5f, (float) Main.chain12Texture.Height * 0.5f), 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
      }
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].aiStyle == 29)
        {
          float num9 = Main.npc[Main.wof].position.X + (float) (Main.npc[Main.wof].width / 2);
          float y = Main.npc[Main.wof].position.Y;
          float num10 = (float) (Main.wofB - Main.wofT);
          bool flag1 = false;
          if (Main.npc[index].frameCounter > 7.0)
            flag1 = true;
          float num11 = (float) Main.wofT + num10 * Main.npc[index].ai[0];
          Vector2 vector2 = new Vector2(Main.npc[index].position.X + (float) (Main.npc[index].width / 2), Main.npc[index].position.Y + (float) (Main.npc[index].height / 2));
          float num12 = num9 - vector2.X;
          float num13 = num11 - vector2.Y;
          float rotation = (float) Math.Atan2((double) num13, (double) num12) - 1.57f;
          bool flag2 = true;
          while (flag2)
          {
            SpriteEffects effects = SpriteEffects.None;
            if (flag1)
            {
              effects = SpriteEffects.FlipHorizontally;
              flag1 = false;
            }
            else
              flag1 = true;
            int height = 28;
            float num14 = (float) Math.Sqrt((double) num12 * (double) num12 + (double) num13 * (double) num13);
            if ((double) num14 < 40.0)
            {
              height = (int) num14 - 40 + 28;
              flag2 = false;
            }
            float num15 = 28f / num14;
            float num16 = num12 * num15;
            float num17 = num13 * num15;
            vector2.X += num16;
            vector2.Y += num17;
            num12 = num9 - vector2.X;
            num13 = num11 - vector2.Y;
            Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) vector2.X / 16, (int) ((double) vector2.Y / 16.0));
            this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height)), color, rotation, new Vector2((float) Main.chain4Texture.Width * 0.5f, (float) Main.chain4Texture.Height * 0.5f), 1f, effects, 0.0f);
          }
        }
      }
      int num18 = 140;
      float wofT = (float) Main.wofT;
      float wofB = (float) Main.wofB;
      float num19 = Main.screenPosition.Y + (float) Main.screenHeight;
      float num20 = (float) ((int) (((double) wofT - (double) Main.screenPosition.Y) / (double) num18) + 1) * (float) num18;
      if ((double) num20 > 0.0)
        wofT -= num20;
      float num21 = wofT;
      float x1 = Main.npc[Main.wof].position.X;
      float num22 = num19 - wofT;
      bool flag3 = true;
      SpriteEffects effects1 = SpriteEffects.None;
      if (Main.npc[Main.wof].spriteDirection == 1)
        effects1 = SpriteEffects.FlipHorizontally;
      if (Main.npc[Main.wof].direction > 0)
        x1 -= 80f;
      int num23 = 0;
      if (!Main.gamePaused)
        ++Main.wofF;
      if (Main.wofF > 12)
      {
        num23 = 280;
        if (Main.wofF > 17)
          Main.wofF = 0;
      }
      else if (Main.wofF > 6)
        num23 = 140;
      while (flag3)
      {
        float num24 = num19 - num21;
        if ((double) num24 > (double) num18)
          num24 = (float) num18;
        bool flag4 = true;
        int num25 = 0;
        while (flag4)
        {
          int x2 = (int) ((double) x1 + (double) (Main.wofTexture.Width / 2)) / 16;
          int y = (int) ((double) num21 + (double) num25) / 16;
          this.spriteBatch.Draw(Main.wofTexture, new Vector2(x1 - Main.screenPosition.X, num21 + (float) num25 - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, num23 + num25, Main.wofTexture.Width, 16)), Lighting.GetColor(x2, y), 0.0f, new Vector2(), 1f, effects1, 0.0f);
          num25 += 16;
          if ((double) num25 >= (double) num24)
            flag4 = false;
        }
        num21 += (float) num18;
        if ((double) num21 >= (double) num19)
          flag3 = false;
      }
    }

    protected void DrawGhost(Player drawPlayer)
    {
      SpriteEffects effects = drawPlayer.direction != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
      Microsoft.Xna.Framework.Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) ((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16, new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor / 2 + 100, (int) Main.mouseTextColor / 2 + 100, (int) Main.mouseTextColor / 2 + 100, (int) Main.mouseTextColor / 2 + 100)));
      Rectangle rectangle = new Rectangle(0, Main.ghostTexture.Height / 4 * drawPlayer.ghostFrame, Main.ghostTexture.Width, Main.ghostTexture.Height / 4);
      Vector2 origin = new Vector2((float) rectangle.Width * 0.5f, (float) rectangle.Height * 0.5f);
      this.spriteBatch.Draw(Main.ghostTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X + (double) (rectangle.Width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) (rectangle.Height / 2))), new Rectangle?(rectangle), immuneAlpha, 0.0f, origin, 1f, effects, 0.0f);
    }

    protected void DrawPlayer(Player drawPlayer)
    {
      Microsoft.Xna.Framework.Color color1 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.25) / 16.0), Microsoft.Xna.Framework.Color.White));
      Microsoft.Xna.Framework.Color color2 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.25) / 16.0), drawPlayer.eyeColor));
      Microsoft.Xna.Framework.Color color3 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.25) / 16.0), drawPlayer.hairColor));
      Microsoft.Xna.Framework.Color color4 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.25) / 16.0), drawPlayer.skinColor));
      Microsoft.Xna.Framework.Color color5 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16.0), drawPlayer.skinColor));
      Microsoft.Xna.Framework.Color color6 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.75) / 16.0), drawPlayer.skinColor));
      Microsoft.Xna.Framework.Color color7 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16.0), drawPlayer.shirtColor));
      Microsoft.Xna.Framework.Color color8 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16.0), drawPlayer.underShirtColor));
      Microsoft.Xna.Framework.Color color9 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.75) / 16.0), drawPlayer.pantsColor));
      Microsoft.Xna.Framework.Color color10 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.75) / 16.0), drawPlayer.shoeColor));
      Microsoft.Xna.Framework.Color color11 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) ((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.25) / 16, Microsoft.Xna.Framework.Color.White));
      Microsoft.Xna.Framework.Color color12 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) ((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16, Microsoft.Xna.Framework.Color.White));
      Microsoft.Xna.Framework.Color color13 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) ((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.75) / 16, Microsoft.Xna.Framework.Color.White));
      if ((double) drawPlayer.shadow > 0.0)
      {
        color6 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
        color5 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
        color4 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
        color3 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
        color2 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
        color1 = new Microsoft.Xna.Framework.Color(0, 0, 0, 0);
      }
      float R = 1f;
      float G = 1f;
      float B = 1f;
      float A = 1f;
      if (drawPlayer.poisoned)
      {
        if (Main.rand.Next(50) == 0)
        {
          int index = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 46, Alpha: 150, Scale: 0.2f);
          Main.dust[index].noGravity = true;
          Main.dust[index].fadeIn = 1.9f;
        }
        R *= 0.65f;
        B *= 0.75f;
      }
      if (drawPlayer.onFire)
      {
        if (Main.rand.Next(4) == 0)
        {
          int index = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 6, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, Scale: 3f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity *= 1.8f;
          Main.dust[index].velocity.Y -= 0.5f;
        }
        B *= 0.6f;
        G *= 0.7f;
      }
      if (drawPlayer.onFire2)
      {
        if (Main.rand.Next(4) == 0)
        {
          int index = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 75, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, Scale: 3f);
          Main.dust[index].noGravity = true;
          Main.dust[index].velocity *= 1.8f;
          Main.dust[index].velocity.Y -= 0.5f;
        }
        B *= 0.6f;
        G *= 0.7f;
      }
      if (drawPlayer.noItems)
      {
        G *= 0.8f;
        R *= 0.65f;
      }
      if (drawPlayer.blind)
      {
        G *= 0.65f;
        R *= 0.7f;
      }
      if (drawPlayer.bleed)
      {
        G *= 0.9f;
        B *= 0.9f;
        if (!drawPlayer.dead && Main.rand.Next(30) == 0)
        {
          int index = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 5);
          Main.dust[index].velocity.Y += 0.5f;
          Main.dust[index].velocity *= 0.25f;
        }
      }
      if ((double) R != 1.0 || (double) G != 1.0 || (double) B != 1.0 || (double) A != 1.0)
      {
        if (drawPlayer.onFire || drawPlayer.onFire2)
        {
          color1 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
          color2 = drawPlayer.GetImmuneAlpha(drawPlayer.eyeColor);
          color3 = drawPlayer.GetImmuneAlpha(drawPlayer.hairColor);
          color4 = drawPlayer.GetImmuneAlpha(drawPlayer.skinColor);
          color5 = drawPlayer.GetImmuneAlpha(drawPlayer.skinColor);
          color7 = drawPlayer.GetImmuneAlpha(drawPlayer.shirtColor);
          color8 = drawPlayer.GetImmuneAlpha(drawPlayer.underShirtColor);
          color9 = drawPlayer.GetImmuneAlpha(drawPlayer.pantsColor);
          color10 = drawPlayer.GetImmuneAlpha(drawPlayer.shoeColor);
          color11 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
          color12 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
          color13 = drawPlayer.GetImmuneAlpha(Microsoft.Xna.Framework.Color.White);
        }
        else
        {
          color1 = Main.buffColor(color1, R, G, B, A);
          color2 = Main.buffColor(color2, R, G, B, A);
          color3 = Main.buffColor(color3, R, G, B, A);
          color4 = Main.buffColor(color4, R, G, B, A);
          color5 = Main.buffColor(color5, R, G, B, A);
          color7 = Main.buffColor(color7, R, G, B, A);
          color8 = Main.buffColor(color8, R, G, B, A);
          color9 = Main.buffColor(color9, R, G, B, A);
          color10 = Main.buffColor(color10, R, G, B, A);
          color11 = Main.buffColor(color11, R, G, B, A);
          color12 = Main.buffColor(color12, R, G, B, A);
          color13 = Main.buffColor(color13, R, G, B, A);
        }
      }
      SpriteEffects effects1;
      SpriteEffects effects2;
      if ((double) drawPlayer.gravDir == 1.0)
      {
        if (drawPlayer.direction == 1)
        {
          effects1 = SpriteEffects.None;
          effects2 = SpriteEffects.None;
        }
        else
        {
          effects1 = SpriteEffects.FlipHorizontally;
          effects2 = SpriteEffects.FlipHorizontally;
        }
        if (!drawPlayer.dead)
        {
          drawPlayer.legPosition.Y = 0.0f;
          drawPlayer.headPosition.Y = 0.0f;
          drawPlayer.bodyPosition.Y = 0.0f;
        }
      }
      else
      {
        if (drawPlayer.direction == 1)
        {
          effects1 = SpriteEffects.FlipVertically;
          effects2 = SpriteEffects.FlipVertically;
        }
        else
        {
          effects1 = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
          effects2 = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
        }
        if (!drawPlayer.dead)
        {
          drawPlayer.legPosition.Y = 6f;
          drawPlayer.headPosition.Y = 6f;
          drawPlayer.bodyPosition.Y = 6f;
        }
      }
      Vector2 origin1 = new Vector2((float) drawPlayer.legFrame.Width * 0.5f, (float) drawPlayer.legFrame.Height * 0.75f);
      Vector2 origin2 = new Vector2((float) drawPlayer.legFrame.Width * 0.5f, (float) drawPlayer.legFrame.Height * 0.5f);
      Vector2 origin3 = new Vector2((float) drawPlayer.legFrame.Width * 0.5f, (float) drawPlayer.legFrame.Height * 0.4f);
      if (drawPlayer.merman)
      {
        drawPlayer.headRotation = (float) ((double) drawPlayer.velocity.Y * (double) drawPlayer.direction * 0.100000001490116);
        if ((double) drawPlayer.headRotation < -0.3)
          drawPlayer.headRotation = -0.3f;
        if ((double) drawPlayer.headRotation > 0.3)
          drawPlayer.headRotation = 0.3f;
      }
      else if (!drawPlayer.dead)
        drawPlayer.headRotation = 0.0f;
      if (drawPlayer.wings > 0)
        this.spriteBatch.Draw(Main.wingsTexture[drawPlayer.wings], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X + (double) (drawPlayer.width / 2) - (double) (9 * drawPlayer.direction)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) (drawPlayer.height / 2) + 2.0 * (double) drawPlayer.gravDir)), new Rectangle?(new Rectangle(0, Main.wingsTexture[drawPlayer.wings].Height / 4 * drawPlayer.wingFrame, Main.wingsTexture[drawPlayer.wings].Width, Main.wingsTexture[drawPlayer.wings].Height / 4)), color12, drawPlayer.bodyRotation, new Vector2((float) (Main.wingsTexture[drawPlayer.wings].Width / 2), (float) (Main.wingsTexture[drawPlayer.wings].Height / 8)), 1f, effects1, 0.0f);
      if (!drawPlayer.invis)
      {
        this.spriteBatch.Draw(Main.skinBodyTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        this.spriteBatch.Draw(Main.skinLegsTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.legFrame), color6, drawPlayer.legRotation, origin2, 1f, effects1, 0.0f);
      }
      if (drawPlayer.legs > 0 && drawPlayer.legs < 25)
        this.spriteBatch.Draw(Main.armorLegTexture[drawPlayer.legs], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.legFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.legFrame.Height + 4.0)) + drawPlayer.legPosition + origin1, new Rectangle?(drawPlayer.legFrame), color13, drawPlayer.legRotation, origin1, 1f, effects1, 0.0f);
      else if (!drawPlayer.invis)
      {
        if (!drawPlayer.male)
        {
          this.spriteBatch.Draw(Main.femalePantsTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.legFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.legFrame.Height + 4.0)) + drawPlayer.legPosition + origin1, new Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, origin1, 1f, effects1, 0.0f);
          this.spriteBatch.Draw(Main.femaleShoesTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.legFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.legFrame.Height + 4.0)) + drawPlayer.legPosition + origin1, new Rectangle?(drawPlayer.legFrame), color10, drawPlayer.legRotation, origin1, 1f, effects1, 0.0f);
        }
        else
        {
          this.spriteBatch.Draw(Main.playerPantsTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.legFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.legFrame.Height + 4.0)) + drawPlayer.legPosition + origin1, new Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, origin1, 1f, effects1, 0.0f);
          this.spriteBatch.Draw(Main.playerShoesTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.legFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.legFrame.Height + 4.0)) + drawPlayer.legPosition + origin1, new Rectangle?(drawPlayer.legFrame), color10, drawPlayer.legRotation, origin1, 1f, effects1, 0.0f);
        }
      }
      if (drawPlayer.body > 0 && drawPlayer.body < 26)
      {
        if (!drawPlayer.male)
          this.spriteBatch.Draw(Main.femaleBodyTexture[drawPlayer.body], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color12, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        else
          this.spriteBatch.Draw(Main.armorBodyTexture[drawPlayer.body], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color12, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        if ((drawPlayer.body == 10 || drawPlayer.body == 11 || drawPlayer.body == 12 || drawPlayer.body == 13 || drawPlayer.body == 14 || drawPlayer.body == 15 || drawPlayer.body == 16 || drawPlayer.body == 20) && !drawPlayer.invis)
          this.spriteBatch.Draw(Main.playerHandsTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
      }
      else if (!drawPlayer.invis)
      {
        if (!drawPlayer.male)
        {
          this.spriteBatch.Draw(Main.femaleUnderShirtTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color8, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
          this.spriteBatch.Draw(Main.femaleShirtTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        }
        else
        {
          this.spriteBatch.Draw(Main.playerUnderShirtTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color8, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
          this.spriteBatch.Draw(Main.playerShirtTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        }
        this.spriteBatch.Draw(Main.playerHandsTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
      }
      if (!drawPlayer.invis && drawPlayer.head != 38)
      {
        this.spriteBatch.Draw(Main.playerHeadTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(drawPlayer.bodyFrame), color4, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
        this.spriteBatch.Draw(Main.playerEyeWhitesTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(drawPlayer.bodyFrame), color1, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
        this.spriteBatch.Draw(Main.playerEyesTexture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(drawPlayer.bodyFrame), color2, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
      }
      if (drawPlayer.head == 10 || drawPlayer.head == 12 || drawPlayer.head == 28)
      {
        this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
        if (!drawPlayer.invis)
        {
          Rectangle bodyFrame = drawPlayer.bodyFrame;
          bodyFrame.Y -= 336;
          if (bodyFrame.Y < 0)
            bodyFrame.Y = 0;
          this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(bodyFrame), color3, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
        }
      }
      if (drawPlayer.head == 14 || drawPlayer.head == 15 || drawPlayer.head == 16 || drawPlayer.head == 18 || drawPlayer.head == 21 || drawPlayer.head == 24 || drawPlayer.head == 25 || drawPlayer.head == 26 || drawPlayer.head == 40 || drawPlayer.head == 44)
      {
        Rectangle bodyFrame = drawPlayer.bodyFrame;
        bodyFrame.Y -= 336;
        if (bodyFrame.Y < 0)
          bodyFrame.Y = 0;
        if (!drawPlayer.invis)
          this.spriteBatch.Draw(Main.playerHairAltTexture[drawPlayer.hair], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(bodyFrame), color3, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
      }
      if (drawPlayer.head == 23)
      {
        Rectangle bodyFrame = drawPlayer.bodyFrame;
        bodyFrame.Y -= 336;
        if (bodyFrame.Y < 0)
          bodyFrame.Y = 0;
        if (!drawPlayer.invis)
          this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(bodyFrame), color3, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
        this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
      }
      else if (drawPlayer.head == 14)
      {
        Rectangle bodyFrame = drawPlayer.bodyFrame;
        int num = 0;
        if (bodyFrame.Y == bodyFrame.Height * 6)
          bodyFrame.Height -= 2;
        else if (bodyFrame.Y == bodyFrame.Height * 7)
          num = -2;
        else if (bodyFrame.Y == bodyFrame.Height * 8)
          num = -2;
        else if (bodyFrame.Y == bodyFrame.Height * 9)
          num = -2;
        else if (bodyFrame.Y == bodyFrame.Height * 10)
          num = -2;
        else if (bodyFrame.Y == bodyFrame.Height * 13)
          bodyFrame.Height -= 2;
        else if (bodyFrame.Y == bodyFrame.Height * 14)
          num = -2;
        else if (bodyFrame.Y == bodyFrame.Height * 15)
          num = -2;
        else if (bodyFrame.Y == bodyFrame.Height * 16)
          num = -2;
        bodyFrame.Y += num;
        this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0 + (double) num)) + drawPlayer.headPosition + origin3, new Rectangle?(bodyFrame), color11, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
      }
      else if (drawPlayer.head > 0 && drawPlayer.head < 45 && drawPlayer.head != 28)
        this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
      else if (!drawPlayer.invis)
      {
        Rectangle bodyFrame = drawPlayer.bodyFrame;
        bodyFrame.Y -= 336;
        if (bodyFrame.Y < 0)
          bodyFrame.Y = 0;
        this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.headPosition + origin3, new Rectangle?(bodyFrame), color3, drawPlayer.headRotation, origin3, 1f, effects1, 0.0f);
      }
      if (drawPlayer.heldProj >= 0)
        this.DrawProj(drawPlayer.heldProj);
      Microsoft.Xna.Framework.Color color14 = Lighting.GetColor((int) ((double) drawPlayer.position.X + (double) drawPlayer.width * 0.5) / 16, (int) (((double) drawPlayer.position.Y + (double) drawPlayer.height * 0.5) / 16.0));
      if ((drawPlayer.itemAnimation > 0 || drawPlayer.inventory[drawPlayer.selectedItem].holdStyle > 0) && drawPlayer.inventory[drawPlayer.selectedItem].type > 0 && !drawPlayer.dead && !drawPlayer.inventory[drawPlayer.selectedItem].noUseGraphic && (!drawPlayer.wet || !drawPlayer.inventory[drawPlayer.selectedItem].noWet))
      {
        if (drawPlayer.inventory[drawPlayer.selectedItem].useStyle == 5)
        {
          int num = 10;
          Vector2 vector2 = new Vector2((float) (Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width / 2), (float) (Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
          if (drawPlayer.inventory[drawPlayer.selectedItem].type == 95)
          {
            num = 10;
            vector2.Y += 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 96)
            num = -5;
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 98)
          {
            num = -5;
            vector2.Y -= 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 534)
          {
            num = -2;
            vector2.Y += 1f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 533)
          {
            num = -7;
            vector2.Y -= 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 506)
          {
            num = 0;
            vector2.Y -= 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 494 || drawPlayer.inventory[drawPlayer.selectedItem].type == 508)
            num = -2;
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 434)
          {
            num = 0;
            vector2.Y -= 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 514)
          {
            num = 0;
            vector2.Y += 3f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 435 || drawPlayer.inventory[drawPlayer.selectedItem].type == 436 || drawPlayer.inventory[drawPlayer.selectedItem].type == 481 || drawPlayer.inventory[drawPlayer.selectedItem].type == 578)
          {
            num = -2;
            vector2.Y -= 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 197)
          {
            num = -5;
            vector2.Y += 4f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 126)
          {
            num = 4;
            vector2.Y += 4f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == (int) sbyte.MaxValue)
          {
            num = 4;
            vector2.Y += 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 157)
          {
            num = 6;
            vector2.Y += 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 160)
            num = -8;
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 164 || drawPlayer.inventory[drawPlayer.selectedItem].type == 219)
          {
            num = 2;
            vector2.Y += 4f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 165 || drawPlayer.inventory[drawPlayer.selectedItem].type == 272)
          {
            num = 4;
            vector2.Y += 4f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 266)
          {
            num = 0;
            vector2.Y += 2f * drawPlayer.gravDir;
          }
          else if (drawPlayer.inventory[drawPlayer.selectedItem].type == 281)
          {
            num = 6;
            vector2.Y -= 6f * drawPlayer.gravDir;
          }
          Vector2 origin4 = new Vector2((float) -num, (float) (Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
          if (drawPlayer.direction == -1)
            origin4 = new Vector2((float) (Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width + num), (float) (Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
          this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) (int) ((double) drawPlayer.itemLocation.X - (double) Main.screenPosition.X + (double) vector2.X), (float) (int) ((double) drawPlayer.itemLocation.Y - (double) Main.screenPosition.Y + (double) vector2.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color14), drawPlayer.itemRotation, origin4, drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0.0f);
          if (drawPlayer.inventory[drawPlayer.selectedItem].color != new Microsoft.Xna.Framework.Color())
            this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) (int) ((double) drawPlayer.itemLocation.X - (double) Main.screenPosition.X + (double) vector2.X), (float) (int) ((double) drawPlayer.itemLocation.Y - (double) Main.screenPosition.Y + (double) vector2.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color14), drawPlayer.itemRotation, origin4, drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0.0f);
        }
        else if ((double) drawPlayer.gravDir == -1.0)
        {
          this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) (int) ((double) drawPlayer.itemLocation.X - (double) Main.screenPosition.X), (float) (int) ((double) drawPlayer.itemLocation.Y - (double) Main.screenPosition.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color14), drawPlayer.itemRotation, new Vector2((float) ((double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 - (double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 * (double) drawPlayer.direction), 0.0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0.0f);
          if (drawPlayer.inventory[drawPlayer.selectedItem].color != new Microsoft.Xna.Framework.Color())
            this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) (int) ((double) drawPlayer.itemLocation.X - (double) Main.screenPosition.X), (float) (int) ((double) drawPlayer.itemLocation.Y - (double) Main.screenPosition.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color14), drawPlayer.itemRotation, new Vector2((float) ((double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 - (double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 * (double) drawPlayer.direction), 0.0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0.0f);
        }
        else
        {
          if (drawPlayer.inventory[drawPlayer.selectedItem].type == 425 || drawPlayer.inventory[drawPlayer.selectedItem].type == 507)
            effects2 = (double) drawPlayer.gravDir != 1.0 ? (drawPlayer.direction != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None) : (drawPlayer.direction != 1 ? SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically : SpriteEffects.FlipVertically);
          this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) (int) ((double) drawPlayer.itemLocation.X - (double) Main.screenPosition.X), (float) (int) ((double) drawPlayer.itemLocation.Y - (double) Main.screenPosition.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color14), drawPlayer.itemRotation, new Vector2((float) ((double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 - (double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 * (double) drawPlayer.direction), (float) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0.0f);
          if (drawPlayer.inventory[drawPlayer.selectedItem].color != new Microsoft.Xna.Framework.Color())
            this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float) (int) ((double) drawPlayer.itemLocation.X - (double) Main.screenPosition.X), (float) (int) ((double) drawPlayer.itemLocation.Y - (double) Main.screenPosition.Y)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color14), drawPlayer.itemRotation, new Vector2((float) ((double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 - (double) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5 * (double) drawPlayer.direction), (float) Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0.0f);
        }
      }
      if (drawPlayer.body > 0 && drawPlayer.body < 26)
      {
        this.spriteBatch.Draw(Main.armorArmTexture[drawPlayer.body], new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color12, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        if (drawPlayer.body != 10 && drawPlayer.body != 11 && drawPlayer.body != 12 && drawPlayer.body != 13 && drawPlayer.body != 14 && drawPlayer.body != 15 && drawPlayer.body != 16 && drawPlayer.body != 20 || drawPlayer.invis)
          return;
        this.spriteBatch.Draw(Main.playerHands2Texture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
      }
      else
      {
        if (drawPlayer.invis)
          return;
        if (!drawPlayer.male)
        {
          this.spriteBatch.Draw(Main.femaleUnderShirt2Texture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color8, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
          this.spriteBatch.Draw(Main.femaleShirt2Texture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        }
        else
          this.spriteBatch.Draw(Main.playerUnderShirt2Texture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color8, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
        this.spriteBatch.Draw(Main.playerHands2Texture, new Vector2((float) (int) ((double) drawPlayer.position.X - (double) Main.screenPosition.X - (double) (drawPlayer.bodyFrame.Width / 2) + (double) (drawPlayer.width / 2)), (float) (int) ((double) drawPlayer.position.Y - (double) Main.screenPosition.Y + (double) drawPlayer.height - (double) drawPlayer.bodyFrame.Height + 4.0)) + drawPlayer.bodyPosition + new Vector2((float) (drawPlayer.bodyFrame.Width / 2), (float) (drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin2, 1f, effects1, 0.0f);
      }
    }

    private static void HelpText()
    {
      bool flag1 = false;
      if (Main.player[Main.myPlayer].statLifeMax > 100)
        flag1 = true;
      bool flag2 = false;
      if (Main.player[Main.myPlayer].statManaMax > 0)
        flag2 = true;
      bool flag3 = true;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      bool flag9 = false;
      for (int index = 0; index < 48; ++index)
      {
        if (Main.player[Main.myPlayer].inventory[index].pick > 0 && Main.player[Main.myPlayer].inventory[index].name != "Copper Pickaxe")
          flag3 = false;
        if (Main.player[Main.myPlayer].inventory[index].axe > 0 && Main.player[Main.myPlayer].inventory[index].name != "Copper Axe")
          flag3 = false;
        if (Main.player[Main.myPlayer].inventory[index].hammer > 0)
          flag3 = false;
        if (Main.player[Main.myPlayer].inventory[index].type == 11 || Main.player[Main.myPlayer].inventory[index].type == 12 || Main.player[Main.myPlayer].inventory[index].type == 13 || Main.player[Main.myPlayer].inventory[index].type == 14)
          flag4 = true;
        if (Main.player[Main.myPlayer].inventory[index].type == 19 || Main.player[Main.myPlayer].inventory[index].type == 20 || Main.player[Main.myPlayer].inventory[index].type == 21 || Main.player[Main.myPlayer].inventory[index].type == 22)
          flag5 = true;
        if (Main.player[Main.myPlayer].inventory[index].type == 75)
          flag6 = true;
        if (Main.player[Main.myPlayer].inventory[index].type == 75)
          flag7 = true;
        if (Main.player[Main.myPlayer].inventory[index].type == 68 || Main.player[Main.myPlayer].inventory[index].type == 70)
          flag8 = true;
        if (Main.player[Main.myPlayer].inventory[index].type == 84)
          flag9 = true;
      }
      bool flag10 = false;
      bool flag11 = false;
      bool flag12 = false;
      bool flag13 = false;
      bool flag14 = false;
      bool flag15 = false;
      bool flag16 = false;
      bool flag17 = false;
      bool flag18 = false;
      for (int index = 0; index < 200; ++index)
      {
        if (Main.npc[index].active)
        {
          if (Main.npc[index].type == 17)
            flag10 = true;
          if (Main.npc[index].type == 18)
            flag11 = true;
          if (Main.npc[index].type == 19)
            flag13 = true;
          if (Main.npc[index].type == 20)
            flag12 = true;
          if (Main.npc[index].type == 54)
            flag18 = true;
          if (Main.npc[index].type == 124)
            flag15 = true;
          if (Main.npc[index].type == 107)
            flag14 = true;
          if (Main.npc[index].type == 108)
            flag16 = true;
          if (Main.npc[index].type == 38)
            flag17 = true;
        }
      }
      while (true)
      {
        do
        {
          ++Main.helpText;
          if (flag3)
          {
            switch (Main.helpText)
            {
              case 1:
                Main.npcChatText = Lang.dialog(177);
                return;
              case 2:
                Main.npcChatText = Lang.dialog(178);
                return;
              case 3:
                Main.npcChatText = Lang.dialog(179);
                return;
              case 4:
                Main.npcChatText = Lang.dialog(180);
                return;
              case 5:
                Main.npcChatText = Lang.dialog(181);
                return;
              case 6:
                Main.npcChatText = Lang.dialog(182);
                return;
            }
          }
          if (flag3 && !flag4 && !flag5 && Main.helpText == 11)
          {
            Main.npcChatText = Lang.dialog(183);
            return;
          }
          if (flag3 && flag4 && !flag5)
          {
            if (Main.helpText == 21)
            {
              Main.npcChatText = Lang.dialog(184);
              return;
            }
            if (Main.helpText == 22)
            {
              Main.npcChatText = Lang.dialog(185);
              return;
            }
          }
          if (flag3 && flag5)
          {
            if (Main.helpText == 31)
            {
              Main.npcChatText = Lang.dialog(186);
              return;
            }
            if (Main.helpText == 32)
            {
              Main.npcChatText = Lang.dialog(187);
              return;
            }
          }
          if (!flag1 && Main.helpText == 41)
          {
            Main.npcChatText = Lang.dialog(188);
            return;
          }
          if (!flag2 && Main.helpText == 42)
          {
            Main.npcChatText = Lang.dialog(189);
            return;
          }
          if (!flag2 && !flag6 && Main.helpText == 43)
          {
            Main.npcChatText = Lang.dialog(190);
            return;
          }
          if (!flag10 && !flag11)
          {
            switch (Main.helpText)
            {
              case 51:
                Main.npcChatText = Lang.dialog(191);
                return;
              case 52:
                Main.npcChatText = Lang.dialog(192);
                return;
              case 53:
                Main.npcChatText = Lang.dialog(193);
                return;
              case 54:
                Main.npcChatText = Lang.dialog(194);
                return;
            }
          }
          if (!flag10 && Main.helpText == 61)
          {
            Main.npcChatText = Lang.dialog(195);
            return;
          }
          if (!flag11 && Main.helpText == 62)
          {
            Main.npcChatText = Lang.dialog(196);
            return;
          }
          if (!flag13 && Main.helpText == 63)
          {
            Main.npcChatText = Lang.dialog(197);
            return;
          }
          if (!flag12 && Main.helpText == 64)
          {
            Main.npcChatText = Lang.dialog(198);
            return;
          }
          if (!flag15 && Main.helpText == 65 && NPC.downedBoss3)
          {
            Main.npcChatText = Lang.dialog(199);
            return;
          }
          if (!flag18 && Main.helpText == 66 && NPC.downedBoss3)
          {
            Main.npcChatText = Lang.dialog(200);
            return;
          }
          if (!flag14 && Main.helpText == 67)
          {
            Main.npcChatText = Lang.dialog(201);
            return;
          }
          if (!flag17 && NPC.downedBoss2 && Main.helpText == 68)
          {
            Main.npcChatText = Lang.dialog(202);
            return;
          }
          if (!flag16 && Main.hardMode && Main.helpText == 69)
          {
            Main.npcChatText = Lang.dialog(203);
            return;
          }
          if (flag7 && Main.helpText == 71)
          {
            Main.npcChatText = Lang.dialog(204);
            return;
          }
          if (flag8 && Main.helpText == 72)
          {
            Main.npcChatText = Lang.dialog(205);
            return;
          }
          if ((flag7 || flag8) && Main.helpText == 80)
          {
            Main.npcChatText = Lang.dialog(206);
            return;
          }
          if (!flag9 && Main.helpText == 201 && !Main.hardMode && !NPC.downedBoss3 && !NPC.downedBoss2)
          {
            Main.npcChatText = Lang.dialog(207);
            return;
          }
          if (Main.helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
          {
            Main.npcChatText = Lang.dialog(208);
            return;
          }
          if (Main.helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
          {
            Main.npcChatText = Lang.dialog(209);
            return;
          }
          if (Main.helpText == 1002 && !NPC.downedBoss3)
          {
            Main.npcChatText = Lang.dialog(210);
            return;
          }
          if (Main.helpText == 1050 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax < 200)
          {
            Main.npcChatText = Lang.dialog(211);
            return;
          }
          if (Main.helpText == 1051 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statDefense <= 10)
          {
            Main.npcChatText = Lang.dialog(212);
            return;
          }
          if (Main.helpText == 1052 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax >= 200 && Main.player[Main.myPlayer].statDefense > 10)
          {
            Main.npcChatText = Lang.dialog(213);
            return;
          }
          if (Main.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax < 300)
          {
            Main.npcChatText = Lang.dialog(214);
            return;
          }
          if (Main.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
          {
            Main.npcChatText = Lang.dialog(215);
            return;
          }
          if (Main.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
          {
            Main.npcChatText = Lang.dialog(216);
            return;
          }
          if (Main.helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
          {
            Main.npcChatText = Lang.dialog(217);
            return;
          }
          if (Main.helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax < 400)
          {
            Main.npcChatText = Lang.dialog(218);
            return;
          }
          if (Main.helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
          {
            Main.npcChatText = Lang.dialog(219);
            return;
          }
          if (Main.helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
          {
            Main.npcChatText = Lang.dialog(220);
            return;
          }
          if (Main.helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
          {
            Main.npcChatText = Lang.dialog(221);
            return;
          }
          if (Main.helpText == 1061 && Main.hardMode)
          {
            Main.npcChatText = Lang.dialog(222);
            return;
          }
          if (Main.helpText == 1062 && Main.hardMode)
          {
            Main.npcChatText = Lang.dialog(223);
            return;
          }
        }
        while (Main.helpText <= 1100);
        Main.helpText = 0;
      }
    }

    protected void DrawChat()
    {
      if (Main.player[Main.myPlayer].talkNPC < 0 && Main.player[Main.myPlayer].sign == -1)
      {
        Main.npcChatText = "";
      }
      else
      {
        if (Main.netMode == 0 && Main.autoPause && Main.player[Main.myPlayer].talkNPC >= 0)
        {
          if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 105)
            Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(107);
          if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 106)
            Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(108);
          if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 123)
            Main.npc[Main.player[Main.myPlayer].talkNPC].Transform(124);
        }
        Microsoft.Xna.Framework.Color color1 = new Microsoft.Xna.Framework.Color(200, 200, 200, 200);
        int num1 = ((int) Main.mouseTextColor * 2 + (int) byte.MaxValue) / 3;
        Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color(num1, num1, num1, num1);
        int length = 10;
        int index1 = 0;
        string[] strArray1 = new string[length];
        int startIndex1 = 0;
        int num2 = 0;
        if (Main.npcChatText == null)
          Main.npcChatText = "";
        for (int startIndex2 = 0; startIndex2 < Main.npcChatText.Length; ++startIndex2)
        {
          if (Encoding.ASCII.GetBytes(Main.npcChatText.Substring(startIndex2, 1))[0] == (byte) 10)
          {
            strArray1[index1] = Main.npcChatText.Substring(startIndex1, startIndex2 - startIndex1);
            ++index1;
            startIndex1 = startIndex2 + 1;
            num2 = startIndex2 + 1;
          }
          else if (Main.npcChatText.Substring(startIndex2, 1) == " " || startIndex2 == Main.npcChatText.Length - 1)
          {
            if ((double) Main.fontMouseText.MeasureString(Main.npcChatText.Substring(startIndex1, startIndex2 - startIndex1)).X > 470.0)
            {
              strArray1[index1] = Main.npcChatText.Substring(startIndex1, num2 - startIndex1);
              ++index1;
              startIndex1 = num2 + 1;
            }
            num2 = startIndex2;
          }
          if (index1 == 10)
          {
            Main.npcChatText = Main.npcChatText.Substring(0, startIndex2 - 1);
            startIndex1 = startIndex2 - 1;
            index1 = 9;
            break;
          }
        }
        if (index1 < 10)
          strArray1[index1] = Main.npcChatText.Substring(startIndex1, Main.npcChatText.Length - startIndex1);
        if (Main.editSign)
        {
          ++this.textBlinkerCount;
          if (this.textBlinkerCount >= 20)
          {
            this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
            this.textBlinkerCount = 0;
          }
          if (this.textBlinkerState == 1)
          {
            string[] strArray2;
            IntPtr index2;
            (strArray2 = strArray1)[(int) (index2 = (IntPtr) index1)] = strArray2[index2] + "|";
          }
        }
        int num3 = index1 + 1;
        this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float) (Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.chatBackTexture.Width, (num3 + 1) * 30)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float) (Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), (float) (100 + (num3 + 1) * 30)), new Rectangle?(new Rectangle(0, Main.chatBackTexture.Height - 30, Main.chatBackTexture.Width, 30)), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        for (int index3 = 0; index3 < num3; ++index3)
        {
          for (int index4 = 0; index4 < 5; ++index4)
          {
            Microsoft.Xna.Framework.Color color3 = Microsoft.Xna.Framework.Color.Black;
            int num4 = 170 + (Main.screenWidth - 800) / 2;
            int num5 = 120 + index3 * 30;
            if (index4 == 0)
              num4 -= 2;
            if (index4 == 1)
              num4 += 2;
            if (index4 == 2)
              num5 -= 2;
            if (index4 == 3)
              num5 += 2;
            if (index4 == 4)
              color3 = color2;
            this.spriteBatch.DrawString(Main.fontMouseText, strArray1[index3], new Vector2((float) num4, (float) num5), color3, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
        }
        int mouseTextColor = (int) Main.mouseTextColor;
        color2 = new Microsoft.Xna.Framework.Color(mouseTextColor, (int) ((double) mouseTextColor / 1.1), mouseTextColor / 2, mouseTextColor);
        string text1 = "";
        string text2 = "";
        int price = Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife;
        for (int index5 = 0; index5 < 10; ++index5)
        {
          int index6 = Main.player[Main.myPlayer].buffType[index5];
          if (Main.debuff[index6] && Main.player[Main.myPlayer].buffTime[index5] > 0 && index6 != 28 && index6 != 34)
            price += 1000;
        }
        if (Main.player[Main.myPlayer].sign > -1)
          text1 = !Main.editSign ? Lang.inter[48] : Lang.inter[47];
        else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
        {
          text1 = Lang.inter[28];
          text2 = Lang.inter[49];
        }
        else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142)
        {
          text1 = Lang.inter[28];
          if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
            text2 = Lang.inter[19];
        }
        else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
        {
          if (!Main.dayTime)
            text1 = Lang.inter[50];
        }
        else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
        {
          text1 = Lang.inter[51];
          text2 = Lang.inter[25];
        }
        else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
        {
          string str = "";
          int num6 = 0;
          int num7 = 0;
          int num8 = 0;
          int num9 = 0;
          int num10 = price;
          if (num10 > 0)
          {
            num10 = (int) ((double) num10 * 0.75);
            if (num10 < 1)
              num10 = 1;
          }
          if (num10 < 0)
            num10 = 0;
          price = num10;
          if (num10 >= 1000000)
          {
            num6 = num10 / 1000000;
            num10 -= num6 * 1000000;
          }
          if (num10 >= 10000)
          {
            num7 = num10 / 10000;
            num10 -= num7 * 10000;
          }
          if (num10 >= 100)
          {
            num8 = num10 / 100;
            num10 -= num8 * 100;
          }
          if (num10 >= 1)
            num9 = num10;
          if (num6 > 0)
            str = str + (object) num6 + " " + Lang.inter[15] + " ";
          if (num7 > 0)
            str = str + (object) num7 + " " + Lang.inter[16] + " ";
          if (num8 > 0)
            str = str + (object) num8 + " " + Lang.inter[17] + " ";
          if (num9 > 0)
            str = str + (object) num9 + " " + Lang.inter[18] + " ";
          float num11 = (float) Main.mouseTextColor / (float) byte.MaxValue;
          if (num6 > 0)
            color2 = new Microsoft.Xna.Framework.Color((int) (byte) (220.0 * (double) num11), (int) (byte) (220.0 * (double) num11), (int) (byte) (198.0 * (double) num11), (int) Main.mouseTextColor);
          else if (num7 > 0)
            color2 = new Microsoft.Xna.Framework.Color((int) (byte) (224.0 * (double) num11), (int) (byte) (201.0 * (double) num11), (int) (byte) (92.0 * (double) num11), (int) Main.mouseTextColor);
          else if (num8 > 0)
            color2 = new Microsoft.Xna.Framework.Color((int) (byte) (181.0 * (double) num11), (int) (byte) (192.0 * (double) num11), (int) (byte) (193.0 * (double) num11), (int) Main.mouseTextColor);
          else if (num9 > 0)
            color2 = new Microsoft.Xna.Framework.Color((int) (byte) (246.0 * (double) num11), (int) (byte) (138.0 * (double) num11), (int) (byte) (96.0 * (double) num11), (int) Main.mouseTextColor);
          text1 = Lang.inter[54] + " (" + str + ")";
          if (num10 == 0)
            text1 = Lang.inter[54];
        }
        int num12 = 180 + (Main.screenWidth - 800) / 2;
        int num13 = 130 + num3 * 30;
        float scale1 = 0.9f;
        if (Main.mouseX > num12 && (double) Main.mouseX < (double) num12 + (double) Main.fontMouseText.MeasureString(text1).X && Main.mouseY > num13 && (double) Main.mouseY < (double) num13 + (double) Main.fontMouseText.MeasureString(text1).Y)
        {
          Main.player[Main.myPlayer].mouseInterface = true;
          scale1 = 1.1f;
          if (!Main.npcChatFocus2)
            Main.PlaySound(12);
          Main.npcChatFocus2 = true;
          Main.player[Main.myPlayer].releaseUseItem = false;
        }
        else
        {
          if (Main.npcChatFocus2)
            Main.PlaySound(12);
          Main.npcChatFocus2 = false;
        }
        for (int index7 = 0; index7 < 5; ++index7)
        {
          int num14 = num12;
          int num15 = num13;
          Microsoft.Xna.Framework.Color color4 = Microsoft.Xna.Framework.Color.Black;
          if (index7 == 0)
            num14 -= 2;
          if (index7 == 1)
            num14 += 2;
          if (index7 == 2)
            num15 -= 2;
          if (index7 == 3)
            num15 += 2;
          if (index7 == 4)
            color4 = color2;
          Vector2 origin = Main.fontMouseText.MeasureString(text1);
          origin *= 0.5f;
          this.spriteBatch.DrawString(Main.fontMouseText, text1, new Vector2((float) num14 + origin.X, (float) num15 + origin.Y), color4, 0.0f, origin, scale1, SpriteEffects.None, 0.0f);
        }
        string text3 = Lang.inter[52];
        color2 = new Microsoft.Xna.Framework.Color(mouseTextColor, (int) ((double) mouseTextColor / 1.1), mouseTextColor / 2, mouseTextColor);
        int num16 = num12 + (int) Main.fontMouseText.MeasureString(text1).X + 20;
        int num17 = num16 + (int) Main.fontMouseText.MeasureString(text3).X;
        int num18 = 130 + num3 * 30;
        float scale2 = 0.9f;
        if (Main.mouseX > num16 && (double) Main.mouseX < (double) num16 + (double) Main.fontMouseText.MeasureString(text3).X && Main.mouseY > num18 && (double) Main.mouseY < (double) num18 + (double) Main.fontMouseText.MeasureString(text3).Y)
        {
          scale2 = 1.1f;
          if (!Main.npcChatFocus1)
            Main.PlaySound(12);
          Main.npcChatFocus1 = true;
          Main.player[Main.myPlayer].releaseUseItem = false;
          Main.player[Main.myPlayer].controlUseItem = false;
        }
        else
        {
          if (Main.npcChatFocus1)
            Main.PlaySound(12);
          Main.npcChatFocus1 = false;
        }
        for (int index8 = 0; index8 < 5; ++index8)
        {
          int num19 = num16;
          int num20 = num18;
          Microsoft.Xna.Framework.Color color5 = Microsoft.Xna.Framework.Color.Black;
          if (index8 == 0)
            num19 -= 2;
          if (index8 == 1)
            num19 += 2;
          if (index8 == 2)
            num20 -= 2;
          if (index8 == 3)
            num20 += 2;
          if (index8 == 4)
            color5 = color2;
          Vector2 origin = Main.fontMouseText.MeasureString(text3);
          origin *= 0.5f;
          this.spriteBatch.DrawString(Main.fontMouseText, text3, new Vector2((float) num19 + origin.X, (float) num20 + origin.Y), color5, 0.0f, origin, scale2, SpriteEffects.None, 0.0f);
        }
        if (text2 != "")
        {
          Vector2 vector2 = Main.fontMouseText.MeasureString(text2);
          int num21 = num17 + (int) vector2.X / 3;
          int num22 = 130 + num3 * 30;
          float scale3 = 0.9f;
          if (Main.mouseX > num21 && (double) Main.mouseX < (double) num21 + (double) Main.fontMouseText.MeasureString(text2).X && Main.mouseY > num22 && (double) Main.mouseY < (double) num22 + (double) Main.fontMouseText.MeasureString(text2).Y)
          {
            Main.player[Main.myPlayer].mouseInterface = true;
            scale3 = 1.1f;
            if (!Main.npcChatFocus3)
              Main.PlaySound(12);
            Main.npcChatFocus3 = true;
            Main.player[Main.myPlayer].releaseUseItem = false;
          }
          else
          {
            if (Main.npcChatFocus3)
              Main.PlaySound(12);
            Main.npcChatFocus3 = false;
          }
          for (int index9 = 0; index9 < 5; ++index9)
          {
            int num23 = num21;
            int num24 = num22;
            Microsoft.Xna.Framework.Color color6 = Microsoft.Xna.Framework.Color.Black;
            if (index9 == 0)
              num23 -= 2;
            if (index9 == 1)
              num23 += 2;
            if (index9 == 2)
              num24 -= 2;
            if (index9 == 3)
              num24 += 2;
            if (index9 == 4)
              color6 = color2;
            Vector2 origin = Main.fontMouseText.MeasureString(text1);
            origin *= 0.5f;
            this.spriteBatch.DrawString(Main.fontMouseText, text2, new Vector2((float) num23 + origin.X, (float) num24 + origin.Y), color6, 0.0f, origin, scale3, SpriteEffects.None, 0.0f);
          }
        }
        if (!Main.mouseLeft || !Main.mouseLeftRelease)
          return;
        Main.mouseLeftRelease = false;
        Main.player[Main.myPlayer].releaseUseItem = false;
        Main.player[Main.myPlayer].mouseInterface = true;
        if (Main.npcChatFocus1)
        {
          Main.player[Main.myPlayer].talkNPC = -1;
          Main.player[Main.myPlayer].sign = -1;
          Main.editSign = false;
          Main.npcChatText = "";
          Main.PlaySound(11);
        }
        else if (Main.npcChatFocus2)
        {
          if (Main.player[Main.myPlayer].sign != -1)
          {
            if (Main.editSign)
            {
              Main.PlaySound(12);
              int sign = Main.player[Main.myPlayer].sign;
              Sign.TextSign(sign, Main.npcChatText);
              Main.editSign = false;
              if (Main.netMode != 1)
                return;
              NetMessage.SendData(47, number: sign);
            }
            else
            {
              Main.PlaySound(12);
              Main.editSign = true;
              Main.clrInput();
            }
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 1;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 2;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 8;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 142)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 9;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
          {
            if (Main.netMode == 0)
              NPC.SpawnSkeletron();
            else
              NetMessage.SendData(51, number: Main.myPlayer, number2: 1f);
            Main.npcChatText = "";
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 3;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 4;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 5;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 6;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.npcShop = 7;
            this.shop[Main.npcShop].SetupShop(Main.npcShop);
            Main.PlaySound(12);
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
          {
            Main.PlaySound(12);
            Main.HelpText();
          }
          else
          {
            if (Main.npc[Main.player[Main.myPlayer].talkNPC].type != 18)
              return;
            Main.PlaySound(12);
            if (price > 0)
            {
              if (Main.player[Main.myPlayer].BuyItem(price))
              {
                Main.PlaySound(2, Style: 4);
                Main.player[Main.myPlayer].HealEffect(Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife);
                Main.npcChatText = (double) Main.player[Main.myPlayer].statLife >= (double) Main.player[Main.myPlayer].statLifeMax * 0.25 ? ((double) Main.player[Main.myPlayer].statLife >= (double) Main.player[Main.myPlayer].statLifeMax * 0.5 ? ((double) Main.player[Main.myPlayer].statLife >= (double) Main.player[Main.myPlayer].statLifeMax * 0.75 ? Lang.dialog(230) : Lang.dialog(229)) : Lang.dialog(228)) : Lang.dialog(227);
                Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
                for (int b = 0; b < 10; ++b)
                {
                  int index10 = Main.player[Main.myPlayer].buffType[b];
                  if (Main.debuff[index10] && Main.player[Main.myPlayer].buffTime[b] > 0 && index10 != 28 && index10 != 34)
                    Main.player[Main.myPlayer].DelBuff(b);
                }
              }
              else
              {
                int num25 = Main.rand.Next(3);
                if (num25 == 0)
                  Main.npcChatText = Lang.dialog(52);
                if (num25 == 1)
                  Main.npcChatText = Lang.dialog(53);
                if (num25 != 2)
                  return;
                Main.npcChatText = Lang.dialog(54);
              }
            }
            else
            {
              int num26 = Main.rand.Next(3);
              if (num26 == 0)
                Main.npcChatText = Lang.dialog(55);
              if (num26 == 1)
                Main.npcChatText = Lang.dialog(56);
              if (num26 != 2)
                return;
              Main.npcChatText = Lang.dialog(57);
            }
          }
        }
        else
        {
          if (!Main.npcChatFocus3 || Main.player[Main.myPlayer].talkNPC < 0)
            return;
          if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
          {
            Main.PlaySound(12);
            Main.npcChatText = Lang.evilGood();
          }
          else if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
          {
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.PlaySound(12);
            Main.craftGuide = true;
          }
          else
          {
            if (Main.npc[Main.player[Main.myPlayer].talkNPC].type != 107)
              return;
            Main.playerInventory = true;
            Main.npcChatText = "";
            Main.PlaySound(12);
            Main.reforge = true;
          }
        }
      }
    }

    private static bool AccCheck(Item newItem, int slot)
    {
      if (Main.player[Main.myPlayer].armor[slot].IsTheSameAs(newItem))
        return false;
      for (int index = 0; index < Main.player[Main.myPlayer].armor.Length; ++index)
      {
        if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[index]))
          return true;
      }
      return false;
    }

    public static Item armorSwap(Item newItem)
    {
      for (int index = 0; index < Main.player[Main.myPlayer].armor.Length; ++index)
      {
        if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[index]))
          Main.accSlotCount = index;
      }
      if (newItem.headSlot == -1 && newItem.bodySlot == -1 && newItem.legSlot == -1 && !newItem.accessory)
        return newItem;
      Item obj = newItem;
      if (newItem.headSlot != -1)
      {
        obj = (Item) Main.player[Main.myPlayer].armor[0].Clone();
        Main.player[Main.myPlayer].armor[0] = (Item) newItem.Clone();
      }
      else if (newItem.bodySlot != -1)
      {
        obj = (Item) Main.player[Main.myPlayer].armor[1].Clone();
        Main.player[Main.myPlayer].armor[1] = (Item) newItem.Clone();
      }
      else if (newItem.legSlot != -1)
      {
        obj = (Item) Main.player[Main.myPlayer].armor[2].Clone();
        Main.player[Main.myPlayer].armor[2] = (Item) newItem.Clone();
      }
      else if (newItem.accessory)
      {
        for (int index = 3; index < 8; ++index)
        {
          if (Main.player[Main.myPlayer].armor[index].type == 0)
          {
            Main.accSlotCount = index - 3;
            break;
          }
        }
        for (int index = 0; index < Main.player[Main.myPlayer].armor.Length; ++index)
        {
          if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[index]))
            Main.accSlotCount = index - 3;
        }
        if (Main.accSlotCount >= 5)
          Main.accSlotCount = 0;
        if (Main.accSlotCount < 0)
          Main.accSlotCount = 4;
        obj = (Item) Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
        Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = (Item) newItem.Clone();
        ++Main.accSlotCount;
        if (Main.accSlotCount >= 5)
          Main.accSlotCount = 0;
      }
      Main.PlaySound(7);
      Recipe.FindRecipes();
      return obj;
    }

    public static void BankCoins()
    {
      for (int index1 = 0; index1 < 20; ++index1)
      {
        if (Main.player[Main.myPlayer].bank[index1].type >= 71 && Main.player[Main.myPlayer].bank[index1].type <= 73 && Main.player[Main.myPlayer].bank[index1].stack == Main.player[Main.myPlayer].bank[index1].maxStack)
        {
          Main.player[Main.myPlayer].bank[index1].SetDefaults(Main.player[Main.myPlayer].bank[index1].type + 1);
          for (int index2 = 0; index2 < 20; ++index2)
          {
            if (index2 != index1 && Main.player[Main.myPlayer].bank[index2].type == Main.player[Main.myPlayer].bank[index1].type && Main.player[Main.myPlayer].bank[index2].stack < Main.player[Main.myPlayer].bank[index2].maxStack)
            {
              ++Main.player[Main.myPlayer].bank[index2].stack;
              Main.player[Main.myPlayer].bank[index1].SetDefaults(0);
              Main.BankCoins();
            }
          }
        }
      }
    }

    public static void ChestCoins()
    {
      for (int index1 = 0; index1 < 20; ++index1)
      {
        if (Main.chest[Main.player[Main.myPlayer].chest].item[index1].type >= 71 && Main.chest[Main.player[Main.myPlayer].chest].item[index1].type <= 73 && Main.chest[Main.player[Main.myPlayer].chest].item[index1].stack == Main.chest[Main.player[Main.myPlayer].chest].item[index1].maxStack)
        {
          Main.chest[Main.player[Main.myPlayer].chest].item[index1].SetDefaults(Main.chest[Main.player[Main.myPlayer].chest].item[index1].type + 1);
          for (int index2 = 0; index2 < 20; ++index2)
          {
            if (index2 != index1 && Main.chest[Main.player[Main.myPlayer].chest].item[index2].type == Main.chest[Main.player[Main.myPlayer].chest].item[index1].type && Main.chest[Main.player[Main.myPlayer].chest].item[index2].stack < Main.chest[Main.player[Main.myPlayer].chest].item[index2].maxStack)
            {
              if (Main.netMode == 1)
                NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index2));
              ++Main.chest[Main.player[Main.myPlayer].chest].item[index2].stack;
              Main.chest[Main.player[Main.myPlayer].chest].item[index1].SetDefaults(0);
              Main.ChestCoins();
            }
          }
        }
      }
    }

    protected void DrawNPCHouse()
    {
      for (int n = 0; n < 200; ++n)
      {
        if (Main.npc[n].active && Main.npc[n].townNPC && !Main.npc[n].homeless && Main.npc[n].homeTileX > 0 && Main.npc[n].homeTileY > 0 && Main.npc[n].type != 37)
        {
          int index1 = 1;
          int homeTileX = Main.npc[n].homeTileX;
          int index2 = Main.npc[n].homeTileY - 1;
          if (Main.tile[homeTileX, index2] != null)
          {
            bool flag = false;
            while (!Main.tile[homeTileX, index2].active || !Main.tileSolid[(int) Main.tile[homeTileX, index2].type])
            {
              --index2;
              if (index2 >= 10)
              {
                if (Main.tile[homeTileX, index2] == null)
                {
                  flag = true;
                  break;
                }
              }
              else
                break;
            }
            if (!flag)
            {
              int num1 = 8;
              int num2 = 18;
              if (Main.tile[homeTileX, index2].type == (byte) 19)
                num2 -= 8;
              int y = index2 + 1;
              this.spriteBatch.Draw(Main.bannerTexture[index1], new Vector2((float) (homeTileX * 16 - (int) Main.screenPosition.X + num1), (float) (y * 16 - (int) Main.screenPosition.Y + num2)), new Rectangle?(new Rectangle(0, 0, Main.bannerTexture[index1].Width, Main.bannerTexture[index1].Height)), Lighting.GetColor(homeTileX, y), 0.0f, new Vector2((float) (Main.bannerTexture[index1].Width / 2), (float) (Main.bannerTexture[index1].Height / 2)), 1f, SpriteEffects.None, 0.0f);
              int num3 = NPC.TypeToNum(Main.npc[n].type);
              float scale = 1f;
              float num4 = Main.npcHeadTexture[num3].Width <= Main.npcHeadTexture[num3].Height ? (float) Main.npcHeadTexture[num3].Height : (float) Main.npcHeadTexture[num3].Width;
              if ((double) num4 > 24.0)
                scale = 24f / num4;
              this.spriteBatch.Draw(Main.npcHeadTexture[num3], new Vector2((float) (homeTileX * 16 - (int) Main.screenPosition.X + num1), (float) (y * 16 - (int) Main.screenPosition.Y + num2 + 2)), new Rectangle?(new Rectangle(0, 0, Main.npcHeadTexture[num3].Width, Main.npcHeadTexture[num3].Height)), Lighting.GetColor(homeTileX, y), 0.0f, new Vector2((float) (Main.npcHeadTexture[num3].Width / 2), (float) (Main.npcHeadTexture[num3].Height / 2)), scale, SpriteEffects.None, 0.0f);
              int num5 = homeTileX * 16 - (int) Main.screenPosition.X + num1 - Main.bannerTexture[index1].Width / 2;
              int num6 = y * 16 - (int) Main.screenPosition.Y + num2 - Main.bannerTexture[index1].Height / 2;
              if (Main.mouseX >= num5 && Main.mouseX <= num5 + Main.bannerTexture[index1].Width && Main.mouseY >= num6 && Main.mouseY <= num6 + Main.bannerTexture[index1].Height)
              {
                this.MouseText(Main.npc[n].displayName + " the " + Main.npc[n].name);
                if (Main.mouseRightRelease && Main.mouseRight)
                {
                  Main.mouseRightRelease = false;
                  WorldGen.kickOut(n);
                  Main.PlaySound(12);
                }
              }
            }
          }
        }
      }
    }

    protected void DrawInterface()
    {
      if (this.showNPCs)
        this.DrawNPCHouse();
      if (Main.player[Main.myPlayer].selectedItem == 48 && Main.player[Main.myPlayer].itemAnimation > 0)
        Main.mouseLeftRelease = false;
      Main.mouseHC = false;
      if (Main.hideUI)
      {
        Main.maxQ = true;
      }
      else
      {
        if (Main.player[Main.myPlayer].rulerAcc)
        {
          int num1 = (int) ((double) ((int) ((double) Main.screenPosition.X / 16.0) * 16) - (double) Main.screenPosition.X);
          int num2 = (int) ((double) ((int) ((double) Main.screenPosition.Y / 16.0) * 16) - (double) Main.screenPosition.Y);
          int num3 = Main.screenWidth / Main.gridTexture.Width;
          int num4 = Main.screenHeight / Main.gridTexture.Height;
          for (int index1 = 0; index1 <= num3 + 1; ++index1)
          {
            for (int index2 = 0; index2 <= num4 + 1; ++index2)
              this.spriteBatch.Draw(Main.gridTexture, new Vector2((float) (index1 * Main.gridTexture.Width + num1), (float) (index2 * Main.gridTexture.Height + num2)), new Rectangle?(new Rectangle(0, 0, Main.gridTexture.Width, Main.gridTexture.Height)), new Microsoft.Xna.Framework.Color(100, 100, 100, 15), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
        }
        if (Main.netDiag)
        {
          for (int index = 0; index < 4; ++index)
          {
            string text = "";
            int num5 = 20;
            int num6 = 220;
            if (index == 0)
            {
              text = "RX Msgs: " + string.Format("{0:0,0}", (object) Main.rxMsg);
              num6 += index * 20;
            }
            else if (index == 1)
            {
              text = "RX Bytes: " + string.Format("{0:0,0}", (object) Main.rxData);
              num6 += index * 20;
            }
            else if (index == 2)
            {
              text = "TX Msgs: " + string.Format("{0:0,0}", (object) Main.txMsg);
              num6 += index * 20;
            }
            else if (index == 3)
            {
              text = "TX Bytes: " + string.Format("{0:0,0}", (object) Main.txData);
              num6 += index * 20;
            }
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num5, (float) num6), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          for (int index = 0; index < Main.maxMsg; ++index)
          {
            int num7 = 200;
            int num8 = 120 + index * 15;
            string text1 = index.ToString() + ": ";
            this.spriteBatch.DrawString(Main.fontMouseText, text1, new Vector2((float) num7, (float) num8), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            int num9 = num7 + 30;
            string text2 = "rx:" + string.Format("{0:0,0}", (object) Main.rxMsgType[index]);
            this.spriteBatch.DrawString(Main.fontMouseText, text2, new Vector2((float) num9, (float) num8), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            int num10 = num9 + 70;
            string text3 = string.Format("{0:0,0}", (object) Main.rxDataType[index]);
            this.spriteBatch.DrawString(Main.fontMouseText, text3, new Vector2((float) num10, (float) num8), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            int num11 = num10 + 70;
            string text4 = index.ToString() + ": ";
            this.spriteBatch.DrawString(Main.fontMouseText, text4, new Vector2((float) num11, (float) num8), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            int num12 = num11 + 30;
            string text5 = "tx:" + string.Format("{0:0,0}", (object) Main.txMsgType[index]);
            this.spriteBatch.DrawString(Main.fontMouseText, text5, new Vector2((float) num12, (float) num8), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            int num13 = num12 + 70;
            string text6 = string.Format("{0:0,0}", (object) Main.txDataType[index]);
            this.spriteBatch.DrawString(Main.fontMouseText, text6, new Vector2((float) num13, (float) num8), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
          }
        }
        if (Main.drawDiag)
        {
          for (int index = 0; index < 7; ++index)
          {
            string text = "";
            int num14 = 20;
            int num15 = 220 + index * 16;
            if (index == 0)
              text = "Solid Tiles:";
            if (index == 1)
              text = "Misc. Tiles:";
            if (index == 2)
              text = "Walls Tiles:";
            if (index == 3)
              text = "Background Tiles:";
            if (index == 4)
              text = "Water Tiles:";
            if (index == 5)
              text = "Black Tiles:";
            if (index == 6)
              text = "Total Render:";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num14, (float) num15), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          for (int index = 0; index < 7; ++index)
          {
            string text = "";
            int num16 = 180;
            int num17 = 220 + index * 16;
            if (index == 0)
              text = Main.renderTimer[index].ToString() + "ms";
            if (index == 1)
              text = Main.renderTimer[index].ToString() + "ms";
            if (index == 2)
              text = Main.renderTimer[index].ToString() + "ms";
            if (index == 3)
              text = Main.renderTimer[index].ToString() + "ms";
            if (index == 4)
              text = Main.renderTimer[index].ToString() + "ms";
            if (index == 5)
              text = Main.renderTimer[index].ToString() + "ms";
            if (index == 6)
              text = ((float) ((double) Main.renderTimer[0] + (double) Main.renderTimer[1] + (double) Main.renderTimer[2] + (double) Main.renderTimer[3] + (double) Main.renderTimer[4] + (double) Main.renderTimer[5])).ToString() + "ms";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num16, (float) num17), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          for (int index = 0; index < 6; ++index)
          {
            string text = "";
            int num18 = 20;
            int num19 = 346 + index * 16;
            if (index == 0)
              text = "Lighting Init:";
            if (index == 1)
              text = "Lighting Phase #1:";
            if (index == 2)
              text = "Lighting Phase #2:";
            if (index == 3)
              text = "Lighting Phase #3";
            if (index == 4)
              text = "Lighting Phase #4";
            if (index == 5)
              text = "Total Lighting:";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num18, (float) num19), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          for (int index = 0; index < 6; ++index)
          {
            string text = "";
            int num20 = 180;
            int num21 = 346 + index * 16;
            if (index == 0)
              text = Main.lightTimer[index].ToString() + "ms";
            if (index == 1)
              text = Main.lightTimer[index].ToString() + "ms";
            if (index == 2)
              text = Main.lightTimer[index].ToString() + "ms";
            if (index == 3)
              text = Main.lightTimer[index].ToString() + "ms";
            if (index == 4)
              text = Main.lightTimer[index].ToString() + "ms";
            if (index == 5)
              text = ((float) ((double) Main.lightTimer[0] + (double) Main.lightTimer[1] + (double) Main.lightTimer[2] + (double) Main.lightTimer[3] + (double) Main.lightTimer[4])).ToString() + "ms";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num20, (float) num21), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          int num22 = 5;
          for (int index = 0; index < num22; ++index)
          {
            int num23 = 20;
            int num24 = 456 + index * 16;
            string text = "Render #" + (object) index + ":";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num23, (float) num24), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          for (int index = 0; index < num22; ++index)
          {
            int num25 = 180;
            int num26 = 456 + index * 16;
            string text = Main.drawTimer[index].ToString() + "ms";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num25, (float) num26), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          for (int index = 0; index < num22; ++index)
          {
            int num27 = 230;
            int num28 = 456 + index * 16;
            string text = Main.drawTimerMax[index].ToString() + "ms";
            this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) num27, (float) num28), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          string str = "";
          int num29 = 20;
          int num30 = 456 + 16 * num22 + 16;
          string text7 = "Update:";
          this.spriteBatch.DrawString(Main.fontMouseText, text7, new Vector2((float) num29, (float) num30), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          str = "";
          int num31 = 180;
          string text8 = Main.upTimer.ToString() + "ms";
          this.spriteBatch.DrawString(Main.fontMouseText, text8, new Vector2((float) num31, (float) num30), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          str = "";
          int num32 = 230;
          string text9 = Main.upTimerMax.ToString() + "ms";
          this.spriteBatch.DrawString(Main.fontMouseText, text9, new Vector2((float) num32, (float) num30), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        }
        if (Main.signBubble)
        {
          int num33 = (int) ((double) Main.signX - (double) Main.screenPosition.X);
          int num34 = (int) ((double) Main.signY - (double) Main.screenPosition.Y);
          SpriteEffects effects = SpriteEffects.None;
          int num35;
          if ((double) Main.signX > (double) Main.player[Main.myPlayer].position.X + (double) Main.player[Main.myPlayer].width)
          {
            effects = SpriteEffects.FlipHorizontally;
            num35 = num33 + (-8 - Main.chat2Texture.Width);
          }
          else
            num35 = num33 + 8;
          int num36 = num34 - 22;
          this.spriteBatch.Draw(Main.chat2Texture, new Vector2((float) num35, (float) num36), new Rectangle?(new Rectangle(0, 0, Main.chat2Texture.Width, Main.chat2Texture.Height)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, effects, 0.0f);
          Main.signBubble = false;
        }
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active && Main.myPlayer != index && !Main.player[index].dead)
          {
            Rectangle rectangle1 = new Rectangle((int) ((double) Main.player[index].position.X + (double) Main.player[index].width * 0.5 - 16.0), (int) ((double) Main.player[index].position.Y + (double) Main.player[index].height - 48.0), 32, 48);
            if (Main.player[Main.myPlayer].team > 0 && Main.player[Main.myPlayer].team == Main.player[index].team)
            {
              Rectangle rectangle2 = new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
              string text10 = Main.player[index].name;
              if (Main.player[index].statLife < Main.player[index].statLifeMax)
                text10 = text10 + ": " + (object) Main.player[index].statLife + "/" + (object) Main.player[index].statLifeMax;
              Vector2 position1 = Main.fontMouseText.MeasureString(text10);
              float num37 = 0.0f;
              if (Main.player[index].chatShowTime > 0)
                num37 = -position1.Y;
              float num38 = 0.0f;
              float num39 = (float) Main.mouseTextColor / (float) byte.MaxValue;
              Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.teamColor[Main.player[index].team].R * (double) num39), (int) (byte) ((double) Main.teamColor[Main.player[index].team].G * (double) num39), (int) (byte) ((double) Main.teamColor[Main.player[index].team].B * (double) num39), (int) Main.mouseTextColor);
              Vector2 vector2 = new Vector2((float) (Main.screenWidth / 2) + Main.screenPosition.X, (float) (Main.screenHeight / 2) + Main.screenPosition.Y);
              float num40 = Main.player[index].position.X + (float) (Main.player[index].width / 2) - vector2.X;
              float num41 = (float) ((double) Main.player[index].position.Y - (double) position1.Y - 2.0) + num37 - vector2.Y;
              float num42 = (float) Math.Sqrt((double) num40 * (double) num40 + (double) num41 * (double) num41);
              int num43 = Main.screenHeight;
              if (Main.screenHeight > Main.screenWidth)
                num43 = Main.screenWidth;
              int num44 = num43 / 2 - 30;
              if (num44 < 100)
                num44 = 100;
              if ((double) num42 < (double) num44)
              {
                position1.X = (float) ((double) Main.player[index].position.X + (double) (Main.player[index].width / 2) - (double) position1.X / 2.0) - Main.screenPosition.X;
                position1.Y = (float) ((double) Main.player[index].position.Y - (double) position1.Y - 2.0) + num37 - Main.screenPosition.Y;
              }
              else
              {
                num38 = num42;
                float num45 = (float) num44 / num42;
                position1.X = (float) ((double) (Main.screenWidth / 2) + (double) num40 * (double) num45 - (double) position1.X / 2.0);
                position1.Y = (float) (Main.screenHeight / 2) + num41 * num45;
              }
              if ((double) num38 > 0.0)
              {
                string text11 = "(" + (object) (int) ((double) num38 / 16.0 * 2.0) + " ft)";
                Vector2 position2 = Main.fontMouseText.MeasureString(text11);
                position2.X = (float) ((double) position1.X + (double) Main.fontMouseText.MeasureString(text10).X / 2.0 - (double) position2.X / 2.0);
                position2.Y = (float) ((double) position1.Y + (double) Main.fontMouseText.MeasureString(text10).Y / 2.0 - (double) position2.Y / 2.0 - 20.0);
                this.spriteBatch.DrawString(Main.fontMouseText, text11, new Vector2(position2.X - 2f, position2.Y), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                this.spriteBatch.DrawString(Main.fontMouseText, text11, new Vector2(position2.X + 2f, position2.Y), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                this.spriteBatch.DrawString(Main.fontMouseText, text11, new Vector2(position2.X, position2.Y - 2f), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                this.spriteBatch.DrawString(Main.fontMouseText, text11, new Vector2(position2.X, position2.Y + 2f), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                this.spriteBatch.DrawString(Main.fontMouseText, text11, position2, color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
              this.spriteBatch.DrawString(Main.fontMouseText, text10, new Vector2(position1.X - 2f, position1.Y), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              this.spriteBatch.DrawString(Main.fontMouseText, text10, new Vector2(position1.X + 2f, position1.Y), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              this.spriteBatch.DrawString(Main.fontMouseText, text10, new Vector2(position1.X, position1.Y - 2f), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              this.spriteBatch.DrawString(Main.fontMouseText, text10, new Vector2(position1.X, position1.Y + 2f), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              this.spriteBatch.DrawString(Main.fontMouseText, text10, position1, color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
        if (Main.playerInventory)
        {
          Main.npcChatText = "";
          Main.player[Main.myPlayer].sign = -1;
        }
        if (Main.ignoreErrors)
        {
          try
          {
            if (!(Main.npcChatText != ""))
            {
              if (Main.player[Main.myPlayer].sign == -1)
                goto label_136;
            }
            this.DrawChat();
          }
          catch
          {
          }
        }
        else if (Main.npcChatText != "" || Main.player[Main.myPlayer].sign != -1)
          this.DrawChat();
label_136:
        Microsoft.Xna.Framework.Color color1 = new Microsoft.Xna.Framework.Color(220, 220, 220, 220);
        Main.invAlpha += Main.invDir * 0.2f;
        if ((double) Main.invAlpha > 240.0)
        {
          Main.invAlpha = 240f;
          Main.invDir = -1f;
        }
        if ((double) Main.invAlpha < 180.0)
        {
          Main.invAlpha = 180f;
          Main.invDir = 1f;
        }
        color1 = new Microsoft.Xna.Framework.Color((int) (byte) Main.invAlpha, (int) (byte) Main.invAlpha, (int) (byte) Main.invAlpha, (int) (byte) Main.invAlpha);
        bool flag1 = false;
        int rare1 = 0;
        int num46 = Main.screenWidth - 800;
        int num47 = Main.player[Main.myPlayer].statLifeMax / 20;
        if (num47 >= 10)
          num47 = 10;
        string text12 = Lang.inter[0] + " " + (object) Main.player[Main.myPlayer].statLifeMax + "/" + (object) Main.player[Main.myPlayer].statLifeMax;
        Vector2 vector2_1 = Main.fontMouseText.MeasureString(text12);
        if (!Main.player[Main.myPlayer].ghost)
        {
          this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[0], new Vector2((float) (500 + 13 * num47) - vector2_1.X * 0.5f + (float) num46, 6f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(Main.fontMouseText, Main.player[Main.myPlayer].statLife.ToString() + "/" + (object) Main.player[Main.myPlayer].statLifeMax, new Vector2((float) (500 + 13 * num47) + vector2_1.X * 0.5f + (float) num46, 6f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(Main.fontMouseText.MeasureString(Main.player[Main.myPlayer].statLife.ToString() + "/" + (object) Main.player[Main.myPlayer].statLifeMax).X, 0.0f), 1f, SpriteEffects.None, 0.0f);
        }
        int num48 = 20;
        for (int index = 1; index < Main.player[Main.myPlayer].statLifeMax / num48 + 1; ++index)
        {
          float scale = 1f;
          bool flag2 = false;
          int num49;
          if (Main.player[Main.myPlayer].statLife >= index * num48)
          {
            num49 = (int) byte.MaxValue;
            if (Main.player[Main.myPlayer].statLife == index * num48)
              flag2 = true;
          }
          else
          {
            float num50 = (float) (Main.player[Main.myPlayer].statLife - (index - 1) * num48) / (float) num48;
            num49 = (int) (30.0 + 225.0 * (double) num50);
            if (num49 < 30)
              num49 = 30;
            scale = (float) ((double) num50 / 4.0 + 0.75);
            if ((double) scale < 0.75)
              scale = 0.75f;
            if ((double) num50 > 0.0)
              flag2 = true;
          }
          if (flag2)
            scale += Main.cursorScale - 1f;
          int num51 = 0;
          int num52 = 0;
          if (index > 10)
          {
            num51 -= 260;
            num52 += 26;
          }
          int a = (int) ((double) num49 * 0.9);
          if (!Main.player[Main.myPlayer].ghost)
            this.spriteBatch.Draw(Main.heartTexture, new Vector2((float) (500 + 26 * (index - 1) + num51 + num46 + Main.heartTexture.Width / 2), (float) (32.0 + ((double) Main.heartTexture.Height - (double) Main.heartTexture.Height * (double) scale) / 2.0) + (float) num52 + (float) (Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Microsoft.Xna.Framework.Color(num49, num49, num49, a), 0.0f, new Vector2((float) (Main.heartTexture.Width / 2), (float) (Main.heartTexture.Height / 2)), scale, SpriteEffects.None, 0.0f);
        }
        int num53 = 20;
        if (Main.player[Main.myPlayer].statManaMax2 > 0)
        {
          int num54 = Main.player[Main.myPlayer].statManaMax2 / 20;
          this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[2], new Vector2((float) (750 + num46), 6f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          for (int index = 1; index < Main.player[Main.myPlayer].statManaMax2 / num53 + 1; ++index)
          {
            bool flag3 = false;
            float scale = 1f;
            int num55;
            if (Main.player[Main.myPlayer].statMana >= index * num53)
            {
              num55 = (int) byte.MaxValue;
              if (Main.player[Main.myPlayer].statMana == index * num53)
                flag3 = true;
            }
            else
            {
              float num56 = (float) (Main.player[Main.myPlayer].statMana - (index - 1) * num53) / (float) num53;
              num55 = (int) (30.0 + 225.0 * (double) num56);
              if (num55 < 30)
                num55 = 30;
              scale = (float) ((double) num56 / 4.0 + 0.75);
              if ((double) scale < 0.75)
                scale = 0.75f;
              if ((double) num56 > 0.0)
                flag3 = true;
            }
            if (flag3)
              scale += Main.cursorScale - 1f;
            int a = (int) ((double) num55 * 0.9);
            this.spriteBatch.Draw(Main.manaTexture, new Vector2((float) (775 + num46), (float) (30 + Main.manaTexture.Height / 2) + (float) (((double) Main.manaTexture.Height - (double) Main.manaTexture.Height * (double) scale) / 2.0) + (float) (28 * (index - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Microsoft.Xna.Framework.Color(num55, num55, num55, a), 0.0f, new Vector2((float) (Main.manaTexture.Width / 2), (float) (Main.manaTexture.Height / 2)), scale, SpriteEffects.None, 0.0f);
          }
        }
        if (Main.player[Main.myPlayer].breath < Main.player[Main.myPlayer].breathMax && !Main.player[Main.myPlayer].ghost)
        {
          int num57 = 76;
          int num58 = Main.player[Main.myPlayer].breathMax / 20;
          this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[1], new Vector2((float) (500 + 13 * num47) - Main.fontMouseText.MeasureString(Lang.inter[1]).X * 0.5f + (float) num46, (float) (6 + num57)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          int num59 = 20;
          for (int index = 1; index < Main.player[Main.myPlayer].breathMax / num59 + 1; ++index)
          {
            float scale = 1f;
            int num60;
            if (Main.player[Main.myPlayer].breath >= index * num59)
            {
              num60 = (int) byte.MaxValue;
            }
            else
            {
              float num61 = (float) (Main.player[Main.myPlayer].breath - (index - 1) * num59) / (float) num59;
              num60 = (int) (30.0 + 225.0 * (double) num61);
              if (num60 < 30)
                num60 = 30;
              scale = (float) ((double) num61 / 4.0 + 0.75);
              if ((double) scale < 0.75)
                scale = 0.75f;
            }
            int num62 = 0;
            int num63 = 0;
            if (index > 10)
            {
              num62 -= 260;
              num63 += 26;
            }
            this.spriteBatch.Draw(Main.bubbleTexture, new Vector2((float) (500 + 26 * (index - 1) + num62 + num46), (float) (32.0 + ((double) Main.bubbleTexture.Height - (double) Main.bubbleTexture.Height * (double) scale) / 2.0) + (float) num63 + (float) num57), new Rectangle?(new Rectangle(0, 0, Main.bubbleTexture.Width, Main.bubbleTexture.Height)), new Microsoft.Xna.Framework.Color(num60, num60, num60, num60), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
          }
        }
        Main.buffString = "";
        if (!Main.playerInventory)
        {
          int index3 = -1;
          for (int b = 0; b < 10; ++b)
          {
            if (Main.player[Main.myPlayer].buffType[b] > 0)
            {
              int index4 = Main.player[Main.myPlayer].buffType[b];
              int num64 = 32 + b * 38;
              int num65 = 76;
              Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color(Main.buffAlpha[b], Main.buffAlpha[b], Main.buffAlpha[b], Main.buffAlpha[b]);
              this.spriteBatch.Draw(Main.buffTexture[index4], new Vector2((float) num64, (float) num65), new Rectangle?(new Rectangle(0, 0, Main.buffTexture[index4].Width, Main.buffTexture[index4].Height)), color2, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              if (index4 != 28 && index4 != 34 && index4 != 37 && index4 != 38 && index4 != 40)
              {
                string text13 = Main.player[Main.myPlayer].buffTime[b] / 60 < 60 ? Math.Round((double) Main.player[Main.myPlayer].buffTime[b] / 60.0).ToString() + " s" : Math.Round((double) (Main.player[Main.myPlayer].buffTime[b] / 60) / 60.0).ToString() + " m";
                this.spriteBatch.DrawString(Main.fontItemStack, text13, new Vector2((float) num64, (float) (num65 + Main.buffTexture[index4].Height)), color2, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
              }
              if (Main.mouseX < num64 + Main.buffTexture[index4].Width && Main.mouseY < num65 + Main.buffTexture[index4].Height && Main.mouseX > num64 && Main.mouseY > num65)
              {
                index3 = b;
                Main.buffAlpha[b] += 0.1f;
                if (Main.mouseRight && Main.mouseRightRelease && !Main.debuff[index4])
                {
                  Main.PlaySound(12);
                  Main.player[Main.myPlayer].DelBuff(b);
                }
              }
              else
                Main.buffAlpha[b] -= 0.05f;
              if ((double) Main.buffAlpha[b] > 1.0)
                Main.buffAlpha[b] = 1f;
              else if ((double) Main.buffAlpha[b] < 0.4)
                Main.buffAlpha[b] = 0.4f;
            }
            else
              Main.buffAlpha[b] = 0.4f;
          }
          if (index3 >= 0)
          {
            int index5 = Main.player[Main.myPlayer].buffType[index3];
            if (index5 > 0)
            {
              Main.buffString = Main.buffTip[index5];
              this.MouseText(Main.buffName[index5]);
            }
          }
        }
        if (Main.player[Main.myPlayer].dead)
          Main.playerInventory = false;
        if (!Main.playerInventory)
        {
          Main.player[Main.myPlayer].chest = -1;
          if (Main.craftGuide)
          {
            Main.craftGuide = false;
            Recipe.FindRecipes();
          }
          Main.reforge = false;
        }
        string cursorText1 = "";
        if (Main.playerInventory)
        {
          if (Main.netMode == 1)
          {
            int num66 = 675 + Main.screenWidth - 800;
            int y = 114;
            if (Main.player[Main.myPlayer].hostile)
            {
              this.spriteBatch.Draw(Main.itemTexture[4], new Vector2((float) (num66 - 2), (float) y), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height)), Main.teamColor[Main.player[Main.myPlayer].team], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              this.spriteBatch.Draw(Main.itemTexture[4], new Vector2((float) (num66 + 2), (float) y), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height)), Main.teamColor[Main.player[Main.myPlayer].team], 0.0f, new Vector2(), 1f, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
              this.spriteBatch.Draw(Main.itemTexture[4], new Vector2((float) (num66 - 16), (float) (y + 14)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height)), Main.teamColor[Main.player[Main.myPlayer].team], -0.785f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              this.spriteBatch.Draw(Main.itemTexture[4], new Vector2((float) (num66 + 2), (float) (y + 14)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height)), Main.teamColor[Main.player[Main.myPlayer].team], -0.785f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            if (Main.mouseX > num66 && Main.mouseX < num66 + 34 && Main.mouseY > y - 2 && Main.mouseY < y + 34)
            {
              Main.player[Main.myPlayer].mouseInterface = true;
              if (Main.mouseLeft && Main.mouseLeftRelease && Main.teamCooldown == 0)
              {
                Main.teamCooldown = Main.teamCooldownLen;
                Main.PlaySound(12);
                Main.player[Main.myPlayer].hostile = !Main.player[Main.myPlayer].hostile;
                NetMessage.SendData(30, number: Main.myPlayer);
              }
            }
            int num67 = num66 - 3;
            Rectangle rectangle3 = new Rectangle(Main.mouseX, Main.mouseY, 1, 1);
            int width = Main.teamTexture.Width;
            int height = Main.teamTexture.Height;
            for (int index = 0; index < 5; ++index)
            {
              Rectangle rectangle4 = new Rectangle();
              if (index == 0)
                rectangle4 = new Rectangle(num67 + 50, y - 20, width, height);
              if (index == 1)
                rectangle4 = new Rectangle(num67 + 40, y, width, height);
              if (index == 2)
                rectangle4 = new Rectangle(num67 + 60, y, width, height);
              if (index == 3)
                rectangle4 = new Rectangle(num67 + 40, y + 20, width, height);
              if (index == 4)
                rectangle4 = new Rectangle(num67 + 60, y + 20, width, height);
              if (rectangle4.Intersects(rectangle3))
              {
                Main.player[Main.myPlayer].mouseInterface = true;
                if (Main.mouseLeft && Main.mouseLeftRelease && Main.player[Main.myPlayer].team != index && Main.teamCooldown == 0)
                {
                  Main.teamCooldown = Main.teamCooldownLen;
                  Main.PlaySound(12);
                  Main.player[Main.myPlayer].team = index;
                  NetMessage.SendData(45, number: Main.myPlayer);
                }
              }
            }
            this.spriteBatch.Draw(Main.teamTexture, new Vector2((float) (num67 + 50), (float) (y - 20)), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[0], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            this.spriteBatch.Draw(Main.teamTexture, new Vector2((float) (num67 + 40), (float) y), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[1], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            this.spriteBatch.Draw(Main.teamTexture, new Vector2((float) (num67 + 60), (float) y), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[2], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            this.spriteBatch.Draw(Main.teamTexture, new Vector2((float) (num67 + 40), (float) (y + 20)), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[3], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            this.spriteBatch.Draw(Main.teamTexture, new Vector2((float) (num67 + 60), (float) (y + 20)), new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height)), Main.teamColor[4], 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
          bool flag4 = false;
          Main.inventoryScale = 0.85f;
          int num68 = 448;
          int num69 = 210;
          Microsoft.Xna.Framework.Color color3 = new Microsoft.Xna.Framework.Color(150, 150, 150, 150);
          if (Main.mouseX >= num68 && (double) Main.mouseX <= (double) num68 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num69 && (double) Main.mouseY <= (double) num69 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
          {
            Main.player[Main.myPlayer].mouseInterface = true;
            if (Main.mouseLeftRelease && Main.mouseLeft)
            {
              if (Main.mouseItem.type != 0)
                Main.trashItem.SetDefaults(0);
              Item mouseItem = Main.mouseItem;
              Main.mouseItem = Main.trashItem;
              Main.trashItem = mouseItem;
              if (Main.trashItem.type == 0 || Main.trashItem.stack < 1)
                Main.trashItem = new Item();
              if (Main.mouseItem.IsTheSameAs(Main.trashItem) && Main.trashItem.stack != Main.trashItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
              {
                if (Main.mouseItem.stack + Main.trashItem.stack <= Main.mouseItem.maxStack)
                {
                  Main.trashItem.stack += Main.mouseItem.stack;
                  Main.mouseItem.stack = 0;
                }
                else
                {
                  int num70 = Main.mouseItem.maxStack - Main.trashItem.stack;
                  Main.trashItem.stack += num70;
                  Main.mouseItem.stack -= num70;
                }
              }
              if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                Main.mouseItem = new Item();
              if (Main.mouseItem.type > 0 || Main.trashItem.type > 0)
                Main.PlaySound(7);
            }
            if (!flag4)
            {
              cursorText1 = Main.trashItem.name;
              if (Main.trashItem.stack > 1)
                cursorText1 = cursorText1 + " (" + (object) Main.trashItem.stack + ")";
              Main.toolTip = (Item) Main.trashItem.Clone();
              if (cursorText1 == null)
                cursorText1 = Lang.inter[3];
            }
            else
              cursorText1 = Lang.inter[3];
          }
          this.spriteBatch.Draw(Main.inventoryBack7Texture, new Vector2((float) num68, (float) num69), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
          Microsoft.Xna.Framework.Color color4 = Microsoft.Xna.Framework.Color.White;
          if (Main.trashItem.type == 0 || Main.trashItem.stack == 0 || flag4)
          {
            color4 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
            float inventoryScale = Main.inventoryScale;
            this.spriteBatch.Draw(Main.trashTexture, new Vector2((float) ((double) num68 + 26.0 * (double) Main.inventoryScale - (double) Main.trashTexture.Width * 0.5 * (double) inventoryScale), (float) ((double) num69 + 26.0 * (double) Main.inventoryScale - (double) Main.trashTexture.Height * 0.5 * (double) inventoryScale)), new Rectangle?(new Rectangle(0, 0, Main.trashTexture.Width, Main.trashTexture.Height)), color4, 0.0f, new Vector2(), inventoryScale, SpriteEffects.None, 0.0f);
          }
          else
          {
            float num71 = 1f;
            if (Main.itemTexture[Main.trashItem.type].Width > 32 || Main.itemTexture[Main.trashItem.type].Height > 32)
              num71 = Main.itemTexture[Main.trashItem.type].Width <= Main.itemTexture[Main.trashItem.type].Height ? 32f / (float) Main.itemTexture[Main.trashItem.type].Height : 32f / (float) Main.itemTexture[Main.trashItem.type].Width;
            float scale = num71 * Main.inventoryScale;
            this.spriteBatch.Draw(Main.itemTexture[Main.trashItem.type], new Vector2((float) ((double) num68 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.trashItem.type].Width * 0.5 * (double) scale), (float) ((double) num69 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.trashItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.trashItem.type].Width, Main.itemTexture[Main.trashItem.type].Height)), Main.trashItem.GetAlpha(color4), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
            if (Main.trashItem.color != new Microsoft.Xna.Framework.Color())
              this.spriteBatch.Draw(Main.itemTexture[Main.trashItem.type], new Vector2((float) ((double) num68 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.trashItem.type].Width * 0.5 * (double) scale), (float) ((double) num69 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.trashItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.trashItem.type].Width, Main.itemTexture[Main.trashItem.type].Height)), Main.trashItem.GetColor(color4), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
            if (Main.trashItem.stack > 1)
              this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.trashItem.stack), new Vector2((float) num68 + 10f * Main.inventoryScale, (float) num69 + 26f * Main.inventoryScale), color4, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
          }
          this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[4], new Vector2(40f, 0.0f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          Main.inventoryScale = 0.85f;
          if (Main.mouseX > 20 && Main.mouseX < (int) (20.0 + 560.0 * (double) Main.inventoryScale) && Main.mouseY > 20 && Main.mouseY < (int) (20.0 + 224.0 * (double) Main.inventoryScale))
            Main.player[Main.myPlayer].mouseInterface = true;
          for (int index6 = 0; index6 < 10; ++index6)
          {
            for (int index7 = 0; index7 < 4; ++index7)
            {
              int num72 = (int) (20.0 + (double) (index6 * 56) * (double) Main.inventoryScale);
              int num73 = (int) (20.0 + (double) (index7 * 56) * (double) Main.inventoryScale);
              int index8 = index6 + index7 * 10;
              Microsoft.Xna.Framework.Color color5 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
              if (Main.mouseX >= num72 && (double) Main.mouseX <= (double) num72 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num73 && (double) Main.mouseY <= (double) num73 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
              {
                Main.player[Main.myPlayer].mouseInterface = true;
                if (Main.mouseLeftRelease && Main.mouseLeft)
                {
                  if (Main.keyState.IsKeyDown(Keys.LeftShift))
                  {
                    if (Main.player[Main.myPlayer].inventory[index8].type > 0)
                    {
                      if (Main.npcShop > 0)
                      {
                        if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[index8].value, Main.player[Main.myPlayer].inventory[index8].stack))
                        {
                          this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[index8]);
                          Main.player[Main.myPlayer].inventory[index8].SetDefaults(0);
                          Main.PlaySound(18);
                        }
                        else if (Main.player[Main.myPlayer].inventory[index8].value == 0)
                        {
                          this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[index8]);
                          Main.player[Main.myPlayer].inventory[index8].SetDefaults(0);
                          Main.PlaySound(7);
                        }
                      }
                      else
                      {
                        Recipe.FindRecipes();
                        Main.PlaySound(7);
                        Main.trashItem = (Item) Main.player[Main.myPlayer].inventory[index8].Clone();
                        Main.player[Main.myPlayer].inventory[index8].SetDefaults(0);
                      }
                    }
                  }
                  else if (Main.player[Main.myPlayer].selectedItem != index8 || Main.player[Main.myPlayer].itemAnimation <= 0)
                  {
                    Item mouseItem = Main.mouseItem;
                    Main.mouseItem = Main.player[Main.myPlayer].inventory[index8];
                    Main.player[Main.myPlayer].inventory[index8] = mouseItem;
                    if (Main.player[Main.myPlayer].inventory[index8].type == 0 || Main.player[Main.myPlayer].inventory[index8].stack < 1)
                      Main.player[Main.myPlayer].inventory[index8] = new Item();
                    if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index8]) && Main.player[Main.myPlayer].inventory[index8].stack != Main.player[Main.myPlayer].inventory[index8].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                    {
                      if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[index8].stack <= Main.mouseItem.maxStack)
                      {
                        Main.player[Main.myPlayer].inventory[index8].stack += Main.mouseItem.stack;
                        Main.mouseItem.stack = 0;
                      }
                      else
                      {
                        int num74 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[index8].stack;
                        Main.player[Main.myPlayer].inventory[index8].stack += num74;
                        Main.mouseItem.stack -= num74;
                      }
                    }
                    if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                      Main.mouseItem = new Item();
                    if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[index8].type > 0)
                    {
                      Recipe.FindRecipes();
                      Main.PlaySound(7);
                    }
                  }
                }
                else if (Main.mouseRight && Main.mouseRightRelease && (Main.player[Main.myPlayer].inventory[index8].type == 599 || Main.player[Main.myPlayer].inventory[index8].type == 600 || Main.player[Main.myPlayer].inventory[index8].type == 601))
                {
                  Main.PlaySound(7);
                  Main.stackSplit = 30;
                  Main.mouseRightRelease = false;
                  int num75 = Main.rand.Next(14);
                  if (num75 == 0 && Main.hardMode)
                    Main.player[Main.myPlayer].inventory[index8].SetDefaults(602);
                  else if (num75 <= 7)
                  {
                    Main.player[Main.myPlayer].inventory[index8].SetDefaults(586);
                    Main.player[Main.myPlayer].inventory[index8].stack = Main.rand.Next(20, 50);
                  }
                  else
                  {
                    Main.player[Main.myPlayer].inventory[index8].SetDefaults(591);
                    Main.player[Main.myPlayer].inventory[index8].stack = Main.rand.Next(20, 50);
                  }
                }
                else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].inventory[index8].maxStack == 1)
                  Main.player[Main.myPlayer].inventory[index8] = Main.armorSwap(Main.player[Main.myPlayer].inventory[index8]);
                else if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].inventory[index8].maxStack > 1 && Main.player[Main.myPlayer].inventory[index8].type > 0 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index8]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                {
                  if (Main.mouseItem.type == 0)
                  {
                    Main.mouseItem = (Item) Main.player[Main.myPlayer].inventory[index8].Clone();
                    Main.mouseItem.stack = 0;
                  }
                  ++Main.mouseItem.stack;
                  --Main.player[Main.myPlayer].inventory[index8].stack;
                  if (Main.player[Main.myPlayer].inventory[index8].stack <= 0)
                    Main.player[Main.myPlayer].inventory[index8] = new Item();
                  Recipe.FindRecipes();
                  Main.soundInstanceMenuTick.Stop();
                  Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                  Main.PlaySound(12);
                  Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                }
                cursorText1 = Main.player[Main.myPlayer].inventory[index8].name;
                Main.toolTip = (Item) Main.player[Main.myPlayer].inventory[index8].Clone();
                if (Main.player[Main.myPlayer].inventory[index8].stack > 1)
                  cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].inventory[index8].stack + ")";
              }
              if (index7 != 0)
                this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float) num72, (float) num73), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
              else
                this.spriteBatch.Draw(Main.inventoryBack9Texture, new Vector2((float) num72, (float) num73), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
              color5 = Microsoft.Xna.Framework.Color.White;
              if (Main.player[Main.myPlayer].inventory[index8].type > 0 && Main.player[Main.myPlayer].inventory[index8].stack > 0)
              {
                float num76 = 1f;
                if (Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height > 32)
                  num76 = Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width;
                float scale = num76 * Main.inventoryScale;
                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type], new Vector2((float) ((double) num72 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width * 0.5 * (double) scale), (float) ((double) num73 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height)), Main.player[Main.myPlayer].inventory[index8].GetAlpha(color5), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].inventory[index8].color != new Microsoft.Xna.Framework.Color())
                  this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type], new Vector2((float) ((double) num72 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width * 0.5 * (double) scale), (float) ((double) num73 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index8].type].Height)), Main.player[Main.myPlayer].inventory[index8].GetColor(color5), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].inventory[index8].stack > 1)
                  this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].inventory[index8].stack), new Vector2((float) num72 + 10f * Main.inventoryScale, (float) num73 + 26f * Main.inventoryScale), color5, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              }
              if (index7 == 0)
              {
                string text14 = string.Concat((object) (index8 + 1));
                if (text14 == "10")
                  text14 = "0";
                Microsoft.Xna.Framework.Color color6 = color1;
                if (Main.player[Main.myPlayer].selectedItem == index8)
                {
                  color6.R = (byte) 0;
                  color6.B = (byte) 0;
                  color6.G = byte.MaxValue;
                  color6.A = (byte) 50;
                }
                this.spriteBatch.DrawString(Main.fontItemStack, text14, new Vector2((float) (num72 + 6), (float) (num73 + 4)), color6, 0.0f, new Vector2(), Main.inventoryScale * 0.8f, SpriteEffects.None, 0.0f);
              }
            }
          }
          int index9 = 0;
          int num77 = 2;
          int num78 = 32;
          if (!Main.player[Main.myPlayer].hbLocked)
            index9 = 1;
          this.spriteBatch.Draw(Main.HBLockTexture[index9], new Vector2((float) num77, (float) num78), new Rectangle?(new Rectangle(0, 0, Main.HBLockTexture[index9].Width, Main.HBLockTexture[index9].Height)), color1, 0.0f, new Vector2(), 0.9f, SpriteEffects.None, 0.0f);
          if (Main.mouseX > num77 && (double) Main.mouseX < (double) num77 + (double) Main.HBLockTexture[index9].Width * 0.899999976158142 && Main.mouseY > num78 && (double) Main.mouseY < (double) num78 + (double) Main.HBLockTexture[index9].Height * 0.899999976158142)
          {
            Main.player[Main.myPlayer].mouseInterface = true;
            if (!Main.player[Main.myPlayer].hbLocked)
            {
              this.MouseText(Lang.inter[5]);
              flag1 = true;
            }
            else
            {
              this.MouseText(Lang.inter[6]);
              flag1 = true;
            }
            if (Main.mouseLeft && Main.mouseLeftRelease)
            {
              Main.PlaySound(22);
              Main.player[Main.myPlayer].hbLocked = !Main.player[Main.myPlayer].hbLocked;
            }
          }
          if (Main.armorHide)
          {
            Main.armorAlpha -= 0.1f;
            if ((double) Main.armorAlpha < 0.0)
              Main.armorAlpha = 0.0f;
          }
          else
          {
            Main.armorAlpha += 0.025f;
            if ((double) Main.armorAlpha > 1.0)
              Main.armorAlpha = 1f;
          }
          Microsoft.Xna.Framework.Color color7 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.mouseTextColor * (double) Main.armorAlpha), (int) (byte) ((double) Main.mouseTextColor * (double) Main.armorAlpha), (int) (byte) ((double) Main.mouseTextColor * (double) Main.armorAlpha), (int) (byte) ((double) Main.mouseTextColor * (double) Main.armorAlpha));
          Main.armorHide = false;
          int index10 = 1;
          int num79 = Main.screenWidth - 152;
          int num80 = 128;
          if (Main.netMode == 0)
            num79 += 72;
          if (this.showNPCs)
            index10 = 0;
          this.spriteBatch.Draw(Main.npcToggleTexture[index10], new Vector2((float) num79, (float) num80), new Rectangle?(new Rectangle(0, 0, Main.npcToggleTexture[index10].Width, Main.npcToggleTexture[index10].Height)), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), 0.9f, SpriteEffects.None, 0.0f);
          if (Main.mouseX > num79 && (double) Main.mouseX < (double) num79 + (double) Main.npcToggleTexture[index10].Width * 0.899999976158142 && Main.mouseY > num80 && (double) Main.mouseY < (double) num80 + (double) Main.npcToggleTexture[index10].Height * 0.899999976158142)
          {
            Main.player[Main.myPlayer].mouseInterface = true;
            if (Main.mouseLeft && Main.mouseLeftRelease)
            {
              Main.PlaySound(12);
              this.showNPCs = !this.showNPCs;
            }
          }
          if (this.showNPCs)
          {
            this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[7], new Vector2((float) (Main.screenWidth - 64 - 28 - 3), 152f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            if (Main.mouseX > Main.screenWidth - 64 - 28 && Main.mouseX < (int) ((double) (Main.screenWidth - 64 - 28) + 56.0 * (double) Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int) (174.0 + 448.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            int num81 = 0;
            string cursorText2 = "";
            for (int index11 = 0; index11 < 12; ++index11)
            {
              bool flag5 = false;
              int index12 = 0;
              if (index11 == 0)
              {
                flag5 = true;
              }
              else
              {
                for (int index13 = 0; index13 < 200; ++index13)
                {
                  if (Main.npc[index13].active && NPC.TypeToNum(Main.npc[index13].type) == index11)
                  {
                    flag5 = true;
                    index12 = index13;
                    break;
                  }
                }
              }
              if (flag5)
              {
                int num82 = Main.screenWidth - 64 - 28;
                int num83 = (int) (174.0 + (double) (num81 * 56) * (double) Main.inventoryScale);
                Microsoft.Xna.Framework.Color color8 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
                if (Main.screenHeight < 768 && num81 > 5)
                {
                  num83 -= (int) (280.0 * (double) Main.inventoryScale);
                  num82 -= 48;
                }
                if (Main.mouseX >= num82 && (double) Main.mouseX <= (double) num82 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num83 && (double) Main.mouseY <= (double) num83 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                {
                  flag1 = true;
                  switch (index11)
                  {
                    case 0:
                      cursorText2 = Lang.inter[8];
                      break;
                    case 11:
                      cursorText2 = Main.npc[index12].displayName;
                      break;
                    default:
                      cursorText2 = Main.npc[index12].displayName + " the " + Main.npc[index12].name;
                      break;
                  }
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseItem.type == 0)
                  {
                    Main.PlaySound(12);
                    this.mouseNPC = index11;
                    Main.mouseLeftRelease = false;
                  }
                }
                this.spriteBatch.Draw(Main.inventoryBack11Texture, new Vector2((float) num82, (float) num83), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                color8 = Microsoft.Xna.Framework.Color.White;
                int index14 = index11;
                float scale = 1f;
                float num84 = Main.npcHeadTexture[index14].Width <= Main.npcHeadTexture[index14].Height ? (float) Main.npcHeadTexture[index14].Height : (float) Main.npcHeadTexture[index14].Width;
                if ((double) num84 > 36.0)
                  scale = 36f / num84;
                this.spriteBatch.Draw(Main.npcHeadTexture[index14], new Vector2((float) num82 + 26f * Main.inventoryScale, (float) num83 + 26f * Main.inventoryScale), new Rectangle?(new Rectangle(0, 0, Main.npcHeadTexture[index14].Width, Main.npcHeadTexture[index14].Height)), color8, 0.0f, new Vector2((float) (Main.npcHeadTexture[index14].Width / 2), (float) (Main.npcHeadTexture[index14].Height / 2)), scale, SpriteEffects.None, 0.0f);
                ++num81;
              }
            }
            if (cursorText2 != "" && Main.mouseItem.type == 0)
              this.MouseText(cursorText2);
          }
          else
          {
            Vector2 vector2_2 = Main.fontMouseText.MeasureString("Equip");
            Vector2 vector2_3 = Main.fontMouseText.MeasureString(Lang.inter[45]);
            float num85 = vector2_2.X / vector2_3.X;
            this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[45], new Vector2((float) (Main.screenWidth - 64 - 28 + 4), (float) (152.0 + ((double) vector2_2.Y - (double) vector2_2.Y * (double) num85) / 2.0)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 0.8f * num85, SpriteEffects.None, 0.0f);
            if (Main.mouseX > Main.screenWidth - 64 - 28 && Main.mouseX < (int) ((double) (Main.screenWidth - 64 - 28) + 56.0 * (double) Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int) (174.0 + 448.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int slot = 0; slot < 8; ++slot)
            {
              int num86 = Main.screenWidth - 64 - 28;
              int num87 = (int) (174.0 + (double) (slot * 56) * (double) Main.inventoryScale);
              Microsoft.Xna.Framework.Color color9 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
              string text15 = "";
              if (slot == 3)
                text15 = Lang.inter[9];
              if (slot == 7)
                text15 = Main.player[Main.myPlayer].statDefense.ToString() + " " + Lang.inter[10];
              Vector2 vector2_4 = Main.fontMouseText.MeasureString(text15);
              this.spriteBatch.DrawString(Main.fontMouseText, text15, new Vector2((float) ((double) num86 - (double) vector2_4.X - 10.0), (float) ((double) num87 + (double) Main.inventoryBackTexture.Height * 0.5 - (double) vector2_4.Y * 0.5)), color7, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              if (Main.mouseX >= num86 && (double) Main.mouseX <= (double) num86 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num87 && (double) Main.mouseY <= (double) num87 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
              {
                Main.armorHide = true;
                Main.player[Main.myPlayer].mouseInterface = true;
                if (Main.mouseLeftRelease && Main.mouseLeft && (Main.mouseItem.type == 0 || Main.mouseItem.headSlot > -1 && slot == 0 || Main.mouseItem.bodySlot > -1 && slot == 1 || Main.mouseItem.legSlot > -1 && slot == 2 || Main.mouseItem.accessory && slot > 2 && !Main.AccCheck(Main.mouseItem, slot)))
                {
                  Item mouseItem = Main.mouseItem;
                  Main.mouseItem = Main.player[Main.myPlayer].armor[slot];
                  Main.player[Main.myPlayer].armor[slot] = mouseItem;
                  if (Main.player[Main.myPlayer].armor[slot].type == 0 || Main.player[Main.myPlayer].armor[slot].stack < 1)
                    Main.player[Main.myPlayer].armor[slot] = new Item();
                  if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                    Main.mouseItem = new Item();
                  if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[slot].type > 0)
                  {
                    Recipe.FindRecipes();
                    Main.PlaySound(7);
                  }
                }
                cursorText1 = Main.player[Main.myPlayer].armor[slot].name;
                Main.toolTip = (Item) Main.player[Main.myPlayer].armor[slot].Clone();
                if (slot <= 2)
                  Main.toolTip.wornArmor = true;
                if (Main.player[Main.myPlayer].armor[slot].stack > 1)
                  cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].armor[slot].stack + ")";
              }
              this.spriteBatch.Draw(Main.inventoryBack3Texture, new Vector2((float) num86, (float) num87), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
              color9 = Microsoft.Xna.Framework.Color.White;
              if (Main.player[Main.myPlayer].armor[slot].type > 0 && Main.player[Main.myPlayer].armor[slot].stack > 0)
              {
                float num88 = 1f;
                if (Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height > 32)
                  num88 = Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width;
                float scale = num88 * Main.inventoryScale;
                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type], new Vector2((float) ((double) num86 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width * 0.5 * (double) scale), (float) ((double) num87 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height)), Main.player[Main.myPlayer].armor[slot].GetAlpha(color9), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].armor[slot].color != new Microsoft.Xna.Framework.Color())
                  this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type], new Vector2((float) ((double) num86 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width * 0.5 * (double) scale), (float) ((double) num87 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[slot].type].Height)), Main.player[Main.myPlayer].armor[slot].GetColor(color9), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].armor[slot].stack > 1)
                  this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].armor[slot].stack), new Vector2((float) num86 + 10f * Main.inventoryScale, (float) num87 + 26f * Main.inventoryScale), color9, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              }
            }
            Vector2 vector2_5 = Main.fontMouseText.MeasureString("Social");
            Vector2 vector2_6 = Main.fontMouseText.MeasureString(Lang.inter[11]);
            float num89 = vector2_5.X / vector2_6.X;
            this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[11], new Vector2((float) (Main.screenWidth - 64 - 28 - 44), (float) (152.0 + ((double) vector2_5.Y - (double) vector2_5.Y * (double) num89) / 2.0)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 0.8f * num89, SpriteEffects.None, 0.0f);
            if (Main.mouseX > Main.screenWidth - 64 - 28 - 47 && Main.mouseX < (int) ((double) (Main.screenWidth - 64 - 20 - 47) + 56.0 * (double) Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int) (174.0 + 168.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int index15 = 8; index15 < 11; ++index15)
            {
              int num90 = Main.screenWidth - 64 - 28 - 47;
              int num91 = (int) (174.0 + (double) ((index15 - 8) * 56) * (double) Main.inventoryScale);
              Microsoft.Xna.Framework.Color color10 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
              string text16 = "";
              if (index15 == 8)
                text16 = Lang.inter[12];
              else if (index15 == 9)
                text16 = Lang.inter[13];
              else if (index15 == 10)
                text16 = Lang.inter[14];
              Vector2 vector2_7 = Main.fontMouseText.MeasureString(text16);
              this.spriteBatch.DrawString(Main.fontMouseText, text16, new Vector2((float) ((double) num90 - (double) vector2_7.X - 10.0), (float) ((double) num91 + (double) Main.inventoryBackTexture.Height * 0.5 - (double) vector2_7.Y * 0.5)), color7, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              if (Main.mouseX >= num90 && (double) Main.mouseX <= (double) num90 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num91 && (double) Main.mouseY <= (double) num91 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
              {
                Main.player[Main.myPlayer].mouseInterface = true;
                Main.armorHide = true;
                if (Main.mouseLeftRelease && Main.mouseLeft)
                {
                  if (Main.mouseItem.type == 0 || Main.mouseItem.headSlot > -1 && index15 == 8 || Main.mouseItem.bodySlot > -1 && index15 == 9 || Main.mouseItem.legSlot > -1 && index15 == 10)
                  {
                    Item mouseItem = Main.mouseItem;
                    Main.mouseItem = Main.player[Main.myPlayer].armor[index15];
                    Main.player[Main.myPlayer].armor[index15] = mouseItem;
                    if (Main.player[Main.myPlayer].armor[index15].type == 0 || Main.player[Main.myPlayer].armor[index15].stack < 1)
                      Main.player[Main.myPlayer].armor[index15] = new Item();
                    if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                      Main.mouseItem = new Item();
                    if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[index15].type > 0)
                    {
                      Recipe.FindRecipes();
                      Main.PlaySound(7);
                    }
                  }
                }
                else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].armor[index15].maxStack == 1)
                  Main.player[Main.myPlayer].armor[index15] = Main.armorSwap(Main.player[Main.myPlayer].armor[index15]);
                cursorText1 = Main.player[Main.myPlayer].armor[index15].name;
                Main.toolTip = (Item) Main.player[Main.myPlayer].armor[index15].Clone();
                Main.toolTip.social = true;
                if (index15 <= 2)
                  Main.toolTip.wornArmor = true;
                if (Main.player[Main.myPlayer].armor[index15].stack > 1)
                  cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].armor[index15].stack + ")";
              }
              this.spriteBatch.Draw(Main.inventoryBack8Texture, new Vector2((float) num90, (float) num91), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
              color10 = Microsoft.Xna.Framework.Color.White;
              if (Main.player[Main.myPlayer].armor[index15].type > 0 && Main.player[Main.myPlayer].armor[index15].stack > 0)
              {
                float num92 = 1f;
                if (Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height > 32)
                  num92 = Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width;
                float scale = num92 * Main.inventoryScale;
                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type], new Vector2((float) ((double) num90 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width * 0.5 * (double) scale), (float) ((double) num91 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height)), Main.player[Main.myPlayer].armor[index15].GetAlpha(color10), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].armor[index15].color != new Microsoft.Xna.Framework.Color())
                  this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type], new Vector2((float) ((double) num90 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width * 0.5 * (double) scale), (float) ((double) num91 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[index15].type].Height)), Main.player[Main.myPlayer].armor[index15].GetColor(color10), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.player[Main.myPlayer].armor[index15].stack > 1)
                  this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].armor[index15].stack), new Vector2((float) num90 + 10f * Main.inventoryScale, (float) num91 + 26f * Main.inventoryScale), color10, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              }
            }
          }
          int num93 = (Main.screenHeight - 600) / 2;
          int num94 = (int) ((double) Main.screenHeight / 600.0 * 250.0);
          if (Main.craftingHide)
          {
            Main.craftingAlpha -= 0.1f;
            if ((double) Main.craftingAlpha < 0.0)
              Main.craftingAlpha = 0.0f;
          }
          else
          {
            Main.craftingAlpha += 0.025f;
            if ((double) Main.craftingAlpha > 1.0)
              Main.craftingAlpha = 1f;
          }
          Microsoft.Xna.Framework.Color color11 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.mouseTextColor * (double) Main.craftingAlpha), (int) (byte) ((double) Main.mouseTextColor * (double) Main.craftingAlpha), (int) (byte) ((double) Main.mouseTextColor * (double) Main.craftingAlpha), (int) (byte) ((double) Main.mouseTextColor * (double) Main.craftingAlpha));
          Main.craftingHide = false;
          if (Main.reforge)
          {
            if (Main.mouseReforge)
            {
              if ((double) Main.reforgeScale < 1.3)
                Main.reforgeScale += 0.02f;
            }
            else if ((double) Main.reforgeScale > 1.0)
              Main.reforgeScale -= 0.02f;
            if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.craftGuide)
            {
              Main.reforge = false;
              Main.player[Main.myPlayer].dropItemCheck();
              Recipe.FindRecipes();
            }
            else
            {
              int num95 = 101;
              int num96 = 241;
              string text17 = Lang.inter[46] + ": ";
              if (Main.reforgeItem.type > 0)
              {
                int price = Main.reforgeItem.value;
                string text18 = "";
                int num97 = 0;
                int num98 = 0;
                int num99 = 0;
                int num100 = 0;
                int num101 = price;
                if (num101 < 1)
                  num101 = 1;
                if (num101 >= 1000000)
                {
                  num97 = num101 / 1000000;
                  num101 -= num97 * 1000000;
                }
                if (num101 >= 10000)
                {
                  num98 = num101 / 10000;
                  num101 -= num98 * 10000;
                }
                if (num101 >= 100)
                {
                  num99 = num101 / 100;
                  num101 -= num99 * 100;
                }
                if (num101 >= 1)
                  num100 = num101;
                if (num97 > 0)
                  text18 = text18 + (object) num97 + " " + Lang.inter[15] + " ";
                if (num98 > 0)
                  text18 = text18 + (object) num98 + " " + Lang.inter[16] + " ";
                if (num99 > 0)
                  text18 = text18 + (object) num99 + " " + Lang.inter[17] + " ";
                if (num100 > 0)
                  text18 = text18 + (object) num100 + " " + Lang.inter[18] + " ";
                float num102 = (float) Main.mouseTextColor / (float) byte.MaxValue;
                Microsoft.Xna.Framework.Color color12 = Microsoft.Xna.Framework.Color.White;
                if (num97 > 0)
                  color12 = new Microsoft.Xna.Framework.Color((int) (byte) (220.0 * (double) num102), (int) (byte) (220.0 * (double) num102), (int) (byte) (198.0 * (double) num102), (int) Main.mouseTextColor);
                else if (num98 > 0)
                  color12 = new Microsoft.Xna.Framework.Color((int) (byte) (224.0 * (double) num102), (int) (byte) (201.0 * (double) num102), (int) (byte) (92.0 * (double) num102), (int) Main.mouseTextColor);
                else if (num99 > 0)
                  color12 = new Microsoft.Xna.Framework.Color((int) (byte) (181.0 * (double) num102), (int) (byte) (192.0 * (double) num102), (int) (byte) (193.0 * (double) num102), (int) Main.mouseTextColor);
                else if (num100 > 0)
                  color12 = new Microsoft.Xna.Framework.Color((int) (byte) (246.0 * (double) num102), (int) (byte) (138.0 * (double) num102), (int) (byte) (96.0 * (double) num102), (int) Main.mouseTextColor);
                this.spriteBatch.DrawString(Main.fontMouseText, text18, new Vector2((float) (num95 + 50) + Main.fontMouseText.MeasureString(text17).X, (float) num96), color12, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                int num103 = num95 + 70;
                int num104 = num96 + 40;
                this.spriteBatch.Draw(Main.reforgeTexture, new Vector2((float) num103, (float) num104), new Rectangle?(new Rectangle(0, 0, Main.reforgeTexture.Width, Main.reforgeTexture.Height)), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2((float) (Main.reforgeTexture.Width / 2), (float) (Main.reforgeTexture.Height / 2)), Main.reforgeScale, SpriteEffects.None, 0.0f);
                if (Main.mouseX > num103 - Main.reforgeTexture.Width / 2 && Main.mouseX < num103 + Main.reforgeTexture.Width / 2 && Main.mouseY > num104 - Main.reforgeTexture.Height / 2 && Main.mouseY < num104 + Main.reforgeTexture.Height / 2)
                {
                  cursorText1 = Lang.inter[19];
                  if (!Main.mouseReforge)
                    Main.PlaySound(12);
                  Main.mouseReforge = true;
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.mouseLeftRelease && Main.mouseLeft && Main.player[Main.myPlayer].BuyItem(price))
                  {
                    Main.reforgeItem.SetDefaults(Main.reforgeItem.name);
                    Main.reforgeItem.Prefix(-2);
                    Main.reforgeItem.position.X = Main.player[Main.myPlayer].position.X + (float) (Main.player[Main.myPlayer].width / 2) - (float) (Main.reforgeItem.width / 2);
                    Main.reforgeItem.position.Y = Main.player[Main.myPlayer].position.Y + (float) (Main.player[Main.myPlayer].height / 2) - (float) (Main.reforgeItem.height / 2);
                    ItemText.NewText(Main.reforgeItem, Main.reforgeItem.stack);
                    Main.PlaySound(2, Style: 37);
                  }
                }
                else
                  Main.mouseReforge = false;
              }
              else
                text17 = Lang.inter[20];
              this.spriteBatch.DrawString(Main.fontMouseText, text17, new Vector2((float) (num95 + 50), (float) num96), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              Microsoft.Xna.Framework.Color color13 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
              if (Main.mouseX >= num95 && (double) Main.mouseX <= (double) num95 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num96 && (double) Main.mouseY <= (double) num96 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
              {
                Main.player[Main.myPlayer].mouseInterface = true;
                Main.craftingHide = true;
                if (Main.mouseItem.Prefix(-3) || Main.mouseItem.type == 0)
                {
                  if (Main.mouseLeftRelease && Main.mouseLeft)
                  {
                    Item mouseItem = Main.mouseItem;
                    Main.mouseItem = Main.reforgeItem;
                    Main.reforgeItem = mouseItem;
                    if (Main.reforgeItem.type == 0 || Main.reforgeItem.stack < 1)
                      Main.reforgeItem = new Item();
                    if (Main.mouseItem.IsTheSameAs(Main.reforgeItem) && Main.reforgeItem.stack != Main.reforgeItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                    {
                      if (Main.mouseItem.stack + Main.reforgeItem.stack <= Main.mouseItem.maxStack)
                      {
                        Main.reforgeItem.stack += Main.mouseItem.stack;
                        Main.mouseItem.stack = 0;
                      }
                      else
                      {
                        int num105 = Main.mouseItem.maxStack - Main.reforgeItem.stack;
                        Main.reforgeItem.stack += num105;
                        Main.mouseItem.stack -= num105;
                      }
                    }
                    if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                      Main.mouseItem = new Item();
                    if (Main.mouseItem.type > 0 || Main.reforgeItem.type > 0)
                    {
                      Recipe.FindRecipes();
                      Main.PlaySound(7);
                    }
                  }
                  else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.reforgeItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                  {
                    if (Main.mouseItem.type == 0)
                    {
                      Main.mouseItem = (Item) Main.reforgeItem.Clone();
                      Main.mouseItem.stack = 0;
                    }
                    ++Main.mouseItem.stack;
                    --Main.reforgeItem.stack;
                    if (Main.reforgeItem.stack <= 0)
                      Main.reforgeItem = new Item();
                    Recipe.FindRecipes();
                    Main.soundInstanceMenuTick.Stop();
                    Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                    Main.PlaySound(12);
                    Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                  }
                }
                cursorText1 = Main.reforgeItem.name;
                Main.toolTip = (Item) Main.reforgeItem.Clone();
                if (Main.reforgeItem.stack > 1)
                  cursorText1 = cursorText1 + " (" + (object) Main.reforgeItem.stack + ")";
              }
              this.spriteBatch.Draw(Main.inventoryBack4Texture, new Vector2((float) num95, (float) num96), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
              color13 = Microsoft.Xna.Framework.Color.White;
              if (Main.reforgeItem.type > 0 && Main.reforgeItem.stack > 0)
              {
                float num106 = 1f;
                if (Main.itemTexture[Main.reforgeItem.type].Width > 32 || Main.itemTexture[Main.reforgeItem.type].Height > 32)
                  num106 = Main.itemTexture[Main.reforgeItem.type].Width <= Main.itemTexture[Main.reforgeItem.type].Height ? 32f / (float) Main.itemTexture[Main.reforgeItem.type].Height : 32f / (float) Main.itemTexture[Main.reforgeItem.type].Width;
                float scale = num106 * Main.inventoryScale;
                this.spriteBatch.Draw(Main.itemTexture[Main.reforgeItem.type], new Vector2((float) ((double) num95 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.reforgeItem.type].Width * 0.5 * (double) scale), (float) ((double) num96 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.reforgeItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.reforgeItem.type].Width, Main.itemTexture[Main.reforgeItem.type].Height)), Main.reforgeItem.GetAlpha(color13), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.reforgeItem.color != new Microsoft.Xna.Framework.Color())
                  this.spriteBatch.Draw(Main.itemTexture[Main.reforgeItem.type], new Vector2((float) ((double) num95 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.reforgeItem.type].Width * 0.5 * (double) scale), (float) ((double) num96 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.reforgeItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.reforgeItem.type].Width, Main.itemTexture[Main.reforgeItem.type].Height)), Main.reforgeItem.GetColor(color13), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.reforgeItem.stack > 1)
                  this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.reforgeItem.stack), new Vector2((float) num95 + 10f * Main.inventoryScale, (float) num96 + 26f * Main.inventoryScale), color13, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              }
            }
          }
          else if (Main.craftGuide)
          {
            if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.reforge)
            {
              Main.craftGuide = false;
              Main.player[Main.myPlayer].dropItemCheck();
              Recipe.FindRecipes();
            }
            else
            {
              int num107 = 73;
              int num108 = 331 + num93;
              string text19;
              if (Main.guideItem.type > 0)
              {
                text19 = Lang.inter[21] + " " + Main.guideItem.name;
                this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[22], new Vector2((float) num107, (float) (num108 + 118)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                int focusRecipe = Main.focusRecipe;
                int num109 = 0;
                for (int index16 = 0; index16 < Recipe.maxRequirements; ++index16)
                {
                  int num110 = (index16 + 1) * 26;
                  if (Main.recipe[Main.availableRecipe[focusRecipe]].requiredTile[index16] == -1)
                  {
                    if (index16 == 0 && !Main.recipe[Main.availableRecipe[focusRecipe]].needWater)
                    {
                      this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[23], new Vector2((float) num107, (float) (num108 + 118 + num110)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                      break;
                    }
                    break;
                  }
                  ++num109;
                  this.spriteBatch.DrawString(Main.fontMouseText, Main.tileName[Main.recipe[Main.availableRecipe[focusRecipe]].requiredTile[index16]], new Vector2((float) num107, (float) (num108 + 118 + num110)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
                if (Main.recipe[Main.availableRecipe[focusRecipe]].needWater)
                {
                  int num111 = (num109 + 1) * 26;
                  this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[53], new Vector2((float) num107, (float) (num108 + 118 + num111)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
              else
                text19 = Lang.inter[24];
              this.spriteBatch.DrawString(Main.fontMouseText, text19, new Vector2((float) (num107 + 50), (float) (num108 + 12)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              Microsoft.Xna.Framework.Color color14 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
              if (Main.mouseX >= num107 && (double) Main.mouseX <= (double) num107 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num108 && (double) Main.mouseY <= (double) num108 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
              {
                Main.player[Main.myPlayer].mouseInterface = true;
                Main.craftingHide = true;
                if (Main.mouseItem.material || Main.mouseItem.type == 0)
                {
                  if (Main.mouseLeftRelease && Main.mouseLeft)
                  {
                    Item mouseItem = Main.mouseItem;
                    Main.mouseItem = Main.guideItem;
                    Main.guideItem = mouseItem;
                    if (Main.guideItem.type == 0 || Main.guideItem.stack < 1)
                      Main.guideItem = new Item();
                    if (Main.mouseItem.IsTheSameAs(Main.guideItem) && Main.guideItem.stack != Main.guideItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                    {
                      if (Main.mouseItem.stack + Main.guideItem.stack <= Main.mouseItem.maxStack)
                      {
                        Main.guideItem.stack += Main.mouseItem.stack;
                        Main.mouseItem.stack = 0;
                      }
                      else
                      {
                        int num112 = Main.mouseItem.maxStack - Main.guideItem.stack;
                        Main.guideItem.stack += num112;
                        Main.mouseItem.stack -= num112;
                      }
                    }
                    if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                      Main.mouseItem = new Item();
                    if (Main.mouseItem.type > 0 || Main.guideItem.type > 0)
                    {
                      Recipe.FindRecipes();
                      Main.PlaySound(7);
                    }
                  }
                  else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.guideItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                  {
                    if (Main.mouseItem.type == 0)
                    {
                      Main.mouseItem = (Item) Main.guideItem.Clone();
                      Main.mouseItem.stack = 0;
                    }
                    ++Main.mouseItem.stack;
                    --Main.guideItem.stack;
                    if (Main.guideItem.stack <= 0)
                      Main.guideItem = new Item();
                    Recipe.FindRecipes();
                    Main.soundInstanceMenuTick.Stop();
                    Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                    Main.PlaySound(12);
                    Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                  }
                }
                cursorText1 = Main.guideItem.name;
                Main.toolTip = (Item) Main.guideItem.Clone();
                if (Main.guideItem.stack > 1)
                  cursorText1 = cursorText1 + " (" + (object) Main.guideItem.stack + ")";
              }
              this.spriteBatch.Draw(Main.inventoryBack4Texture, new Vector2((float) num107, (float) num108), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
              Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
              if (Main.guideItem.type > 0 && Main.guideItem.stack > 0)
              {
                float num113 = 1f;
                if (Main.itemTexture[Main.guideItem.type].Width > 32 || Main.itemTexture[Main.guideItem.type].Height > 32)
                  num113 = Main.itemTexture[Main.guideItem.type].Width <= Main.itemTexture[Main.guideItem.type].Height ? 32f / (float) Main.itemTexture[Main.guideItem.type].Height : 32f / (float) Main.itemTexture[Main.guideItem.type].Width;
                float scale = num113 * Main.inventoryScale;
                this.spriteBatch.Draw(Main.itemTexture[Main.guideItem.type], new Vector2((float) ((double) num107 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.guideItem.type].Width * 0.5 * (double) scale), (float) ((double) num108 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.guideItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.guideItem.type].Width, Main.itemTexture[Main.guideItem.type].Height)), Main.guideItem.GetAlpha(white), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.guideItem.color != new Microsoft.Xna.Framework.Color())
                  this.spriteBatch.Draw(Main.itemTexture[Main.guideItem.type], new Vector2((float) ((double) num107 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.guideItem.type].Width * 0.5 * (double) scale), (float) ((double) num108 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.guideItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.guideItem.type].Width, Main.itemTexture[Main.guideItem.type].Height)), Main.guideItem.GetColor(white), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                if (Main.guideItem.stack > 1)
                  this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.guideItem.stack), new Vector2((float) num107 + 10f * Main.inventoryScale, (float) num108 + 26f * Main.inventoryScale), white, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              }
            }
          }
          if (!Main.reforge)
          {
            if (Main.numAvailableRecipes > 0)
              this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[25], new Vector2(76f, (float) (414 + num93)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            for (int index17 = 0; index17 < Recipe.maxRecipes; ++index17)
            {
              Main.inventoryScale = (float) (100.0 / ((double) Math.Abs(Main.availableRecipeY[index17]) + 100.0));
              if ((double) Main.inventoryScale < 0.75)
                Main.inventoryScale = 0.75f;
              if ((double) Main.availableRecipeY[index17] < (double) ((index17 - Main.focusRecipe) * 65))
              {
                if ((double) Main.availableRecipeY[index17] == 0.0)
                  Main.PlaySound(12);
                Main.availableRecipeY[index17] += 6.5f;
              }
              else if ((double) Main.availableRecipeY[index17] > (double) ((index17 - Main.focusRecipe) * 65))
              {
                if ((double) Main.availableRecipeY[index17] == 0.0)
                  Main.PlaySound(12);
                Main.availableRecipeY[index17] -= 6.5f;
              }
              if (index17 < Main.numAvailableRecipes && (double) Math.Abs(Main.availableRecipeY[index17]) <= (double) num94)
              {
                int num114 = (int) (46.0 - 26.0 * (double) Main.inventoryScale);
                int num115 = (int) (410.0 + (double) Main.availableRecipeY[index17] * (double) Main.inventoryScale - 30.0 * (double) Main.inventoryScale + (double) num93);
                double num116 = (double) ((int) color1.A + 50);
                double num117 = (double) byte.MaxValue;
                if ((double) Math.Abs(Main.availableRecipeY[index17]) > (double) (num94 - 100))
                {
                  num116 = 150.0 * (100.0 - ((double) Math.Abs(Main.availableRecipeY[index17]) - (double) (num94 - 100))) * 0.01;
                  num117 = (double) byte.MaxValue * (100.0 - ((double) Math.Abs(Main.availableRecipeY[index17]) - (double) (num94 - 100))) * 0.01;
                }
                Microsoft.Xna.Framework.Color color15 = new Microsoft.Xna.Framework.Color((int) (byte) num116, (int) (byte) num116, (int) (byte) num116, (int) (byte) num116);
                Microsoft.Xna.Framework.Color color16 = new Microsoft.Xna.Framework.Color((int) (byte) num117, (int) (byte) num117, (int) (byte) num117, (int) (byte) num117);
                if (Main.mouseX >= num114 && (double) Main.mouseX <= (double) num114 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num115 && (double) Main.mouseY <= (double) num115 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                {
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.focusRecipe == index17 && Main.guideItem.type == 0)
                  {
                    if (Main.mouseItem.type == 0 || Main.mouseItem.IsTheSameAs(Main.recipe[Main.availableRecipe[index17]].createItem) && Main.mouseItem.stack + Main.recipe[Main.availableRecipe[index17]].createItem.stack <= Main.mouseItem.maxStack)
                    {
                      if (Main.mouseLeftRelease && Main.mouseLeft)
                      {
                        int stack = Main.mouseItem.stack;
                        Main.mouseItem = (Item) Main.recipe[Main.availableRecipe[index17]].createItem.Clone();
                        Main.mouseItem.Prefix(-1);
                        Main.mouseItem.stack += stack;
                        Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float) (Main.player[Main.myPlayer].width / 2) - (float) (Main.mouseItem.width / 2);
                        Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float) (Main.player[Main.myPlayer].height / 2) - (float) (Main.mouseItem.height / 2);
                        ItemText.NewText(Main.mouseItem, Main.recipe[Main.availableRecipe[index17]].createItem.stack);
                        Main.recipe[Main.availableRecipe[index17]].Create();
                        if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[index17]].createItem.type > 0)
                          Main.PlaySound(7);
                      }
                      else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                      {
                        Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                        int stack = Main.mouseItem.stack;
                        Main.mouseItem = (Item) Main.recipe[Main.availableRecipe[index17]].createItem.Clone();
                        Main.mouseItem.stack += stack;
                        Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float) (Main.player[Main.myPlayer].width / 2) - (float) (Main.mouseItem.width / 2);
                        Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float) (Main.player[Main.myPlayer].height / 2) - (float) (Main.mouseItem.height / 2);
                        ItemText.NewText(Main.mouseItem, Main.recipe[Main.availableRecipe[index17]].createItem.stack);
                        Main.recipe[Main.availableRecipe[index17]].Create();
                        if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[index17]].createItem.type > 0)
                          Main.PlaySound(7);
                      }
                    }
                  }
                  else if (Main.mouseLeftRelease && Main.mouseLeft)
                    Main.focusRecipe = index17;
                  Main.craftingHide = true;
                  cursorText1 = Main.recipe[Main.availableRecipe[index17]].createItem.name;
                  Main.toolTip = (Item) Main.recipe[Main.availableRecipe[index17]].createItem.Clone();
                  if (Main.recipe[Main.availableRecipe[index17]].createItem.stack > 1)
                    cursorText1 = cursorText1 + " (" + (object) Main.recipe[Main.availableRecipe[index17]].createItem.stack + ")";
                }
                if (Main.numAvailableRecipes > 0)
                {
                  double num118 = num116 - 50.0;
                  if (num118 < 0.0)
                    num118 = 0.0;
                  this.spriteBatch.Draw(Main.inventoryBack4Texture, new Vector2((float) num114, (float) num115), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Microsoft.Xna.Framework.Color((int) (byte) num118, (int) (byte) num118, (int) (byte) num118, (int) (byte) num118), 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                  if (Main.recipe[Main.availableRecipe[index17]].createItem.type > 0 && Main.recipe[Main.availableRecipe[index17]].createItem.stack > 0)
                  {
                    float num119 = 1f;
                    if (Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height > 32)
                      num119 = Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width <= Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height ? 32f / (float) Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height : 32f / (float) Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width;
                    float scale = num119 * Main.inventoryScale;
                    this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type], new Vector2((float) ((double) num114 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width * 0.5 * (double) scale), (float) ((double) num115 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height)), Main.recipe[Main.availableRecipe[index17]].createItem.GetAlpha(color16), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                    if (Main.recipe[Main.availableRecipe[index17]].createItem.color != new Microsoft.Xna.Framework.Color())
                      this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type], new Vector2((float) ((double) num114 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width * 0.5 * (double) scale), (float) ((double) num115 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[index17]].createItem.type].Height)), Main.recipe[Main.availableRecipe[index17]].createItem.GetColor(color16), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                    if (Main.recipe[Main.availableRecipe[index17]].createItem.stack > 1)
                      this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.recipe[Main.availableRecipe[index17]].createItem.stack), new Vector2((float) num114 + 10f * Main.inventoryScale, (float) num115 + 26f * Main.inventoryScale), color16, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  }
                }
              }
            }
            if (Main.numAvailableRecipes > 0)
            {
              for (int index18 = 0; index18 < Recipe.maxRequirements && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type != 0; ++index18)
              {
                int num120 = 80 + index18 * 40;
                int num121 = 380 + num93;
                double num122 = (double) ((int) color1.A + 50);
                Microsoft.Xna.Framework.Color white1 = Microsoft.Xna.Framework.Color.White;
                Microsoft.Xna.Framework.Color white2 = Microsoft.Xna.Framework.Color.White;
                double num123 = (double) ((int) color1.A + 50) - (double) Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 2.0;
                double num124 = (double) byte.MaxValue - (double) Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 2.0;
                if (num123 < 0.0)
                  num123 = 0.0;
                if (num124 < 0.0)
                  num124 = 0.0;
                white1.R = (byte) num123;
                white1.G = (byte) num123;
                white1.B = (byte) num123;
                white1.A = (byte) num123;
                white2.R = (byte) num124;
                white2.G = (byte) num124;
                white2.B = (byte) num124;
                white2.A = (byte) num124;
                Main.inventoryScale = 0.6f;
                if (num123 != 0.0)
                {
                  if (Main.mouseX >= num120 && (double) Main.mouseX <= (double) num120 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num121 && (double) Main.mouseY <= (double) num121 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                  {
                    Main.craftingHide = true;
                    Main.player[Main.myPlayer].mouseInterface = true;
                    cursorText1 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].name;
                    Main.toolTip = (Item) Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].Clone();
                    if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].stack > 1)
                      cursorText1 = cursorText1 + " (" + (object) Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].stack + ")";
                  }
                  double num125 = num123 - 50.0;
                  if (num125 < 0.0)
                    num125 = 0.0;
                  this.spriteBatch.Draw(Main.inventoryBack4Texture, new Vector2((float) num120, (float) num121), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Microsoft.Xna.Framework.Color((int) (byte) num125, (int) (byte) num125, (int) (byte) num125, (int) (byte) num125), 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                  if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type > 0 && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].stack > 0)
                  {
                    float num126 = 1f;
                    if (Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height > 32)
                      num126 = Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width <= Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height ? 32f / (float) Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height : 32f / (float) Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width;
                    float scale = num126 * Main.inventoryScale;
                    this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type], new Vector2((float) ((double) num120 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width * 0.5 * (double) scale), (float) ((double) num121 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height)), Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].GetAlpha(white2), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                    if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].color != new Microsoft.Xna.Framework.Color())
                      this.spriteBatch.Draw(Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type], new Vector2((float) ((double) num120 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width * 0.5 * (double) scale), (float) ((double) num121 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].type].Height)), Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].GetColor(white2), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                    if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].stack > 1)
                      this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[index18].stack), new Vector2((float) num120 + 10f * Main.inventoryScale, (float) num121 + 26f * Main.inventoryScale), white2, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  }
                }
                else
                  break;
              }
            }
          }
          Vector2 vector2_8 = Main.fontMouseText.MeasureString("Coins");
          Vector2 vector2_9 = Main.fontMouseText.MeasureString(Lang.inter[26]);
          float num127 = vector2_8.X / vector2_9.X;
          this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[26], new Vector2(496f, (float) (84.0 + ((double) vector2_8.Y - (double) vector2_8.Y * (double) num127) / 2.0)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 0.75f * num127, SpriteEffects.None, 0.0f);
          Main.inventoryScale = 0.6f;
          for (int index19 = 0; index19 < 4; ++index19)
          {
            int num128 = 497;
            int num129 = (int) (85.0 + (double) (index19 * 56) * (double) Main.inventoryScale + 20.0);
            int index20 = index19 + 40;
            Microsoft.Xna.Framework.Color color17 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
            if (Main.mouseX >= num128 && (double) Main.mouseX <= (double) num128 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num129 && (double) Main.mouseY <= (double) num129 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
            {
              Main.player[Main.myPlayer].mouseInterface = true;
              if (Main.mouseLeftRelease && Main.mouseLeft)
              {
                if (Main.keyState.IsKeyDown(Keys.LeftShift))
                {
                  if (Main.player[Main.myPlayer].inventory[index20].type > 0)
                  {
                    if (Main.npcShop > 0)
                    {
                      if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[index20].value, Main.player[Main.myPlayer].inventory[index20].stack))
                      {
                        this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[index20]);
                        Main.player[Main.myPlayer].inventory[index20].SetDefaults(0);
                        Main.PlaySound(18);
                      }
                      else if (Main.player[Main.myPlayer].inventory[index20].value == 0)
                      {
                        this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[index20]);
                        Main.player[Main.myPlayer].inventory[index20].SetDefaults(0);
                        Main.PlaySound(7);
                      }
                    }
                    else
                    {
                      Recipe.FindRecipes();
                      Main.PlaySound(7);
                      Main.trashItem = (Item) Main.player[Main.myPlayer].inventory[index20].Clone();
                      Main.player[Main.myPlayer].inventory[index20].SetDefaults(0);
                    }
                  }
                }
                else if ((Main.player[Main.myPlayer].selectedItem != index20 || Main.player[Main.myPlayer].itemAnimation <= 0) && (Main.mouseItem.type == 0 || Main.mouseItem.type == 71 || Main.mouseItem.type == 72 || Main.mouseItem.type == 73 || Main.mouseItem.type == 74))
                {
                  Item mouseItem = Main.mouseItem;
                  Main.mouseItem = Main.player[Main.myPlayer].inventory[index20];
                  Main.player[Main.myPlayer].inventory[index20] = mouseItem;
                  if (Main.player[Main.myPlayer].inventory[index20].type == 0 || Main.player[Main.myPlayer].inventory[index20].stack < 1)
                    Main.player[Main.myPlayer].inventory[index20] = new Item();
                  if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index20]) && Main.player[Main.myPlayer].inventory[index20].stack != Main.player[Main.myPlayer].inventory[index20].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                  {
                    if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[index20].stack <= Main.mouseItem.maxStack)
                    {
                      Main.player[Main.myPlayer].inventory[index20].stack += Main.mouseItem.stack;
                      Main.mouseItem.stack = 0;
                    }
                    else
                    {
                      int num130 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[index20].stack;
                      Main.player[Main.myPlayer].inventory[index20].stack += num130;
                      Main.mouseItem.stack -= num130;
                    }
                  }
                  if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                    Main.mouseItem = new Item();
                  if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[index20].type > 0)
                    Main.PlaySound(7);
                  Recipe.FindRecipes();
                }
              }
              else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index20]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
              {
                if (Main.mouseItem.type == 0)
                {
                  Main.mouseItem = (Item) Main.player[Main.myPlayer].inventory[index20].Clone();
                  Main.mouseItem.stack = 0;
                }
                ++Main.mouseItem.stack;
                --Main.player[Main.myPlayer].inventory[index20].stack;
                if (Main.player[Main.myPlayer].inventory[index20].stack <= 0)
                  Main.player[Main.myPlayer].inventory[index20] = new Item();
                Recipe.FindRecipes();
                Main.soundInstanceMenuTick.Stop();
                Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                Main.PlaySound(12);
                Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
              }
              cursorText1 = Main.player[Main.myPlayer].inventory[index20].name;
              Main.toolTip = (Item) Main.player[Main.myPlayer].inventory[index20].Clone();
              if (Main.player[Main.myPlayer].inventory[index20].stack > 1)
                cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].inventory[index20].stack + ")";
            }
            this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float) num128, (float) num129), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
            color17 = Microsoft.Xna.Framework.Color.White;
            if (Main.player[Main.myPlayer].inventory[index20].type > 0 && Main.player[Main.myPlayer].inventory[index20].stack > 0)
            {
              float num131 = 1f;
              if (Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height > 32)
                num131 = Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width;
              float scale = num131 * Main.inventoryScale;
              this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type], new Vector2((float) ((double) num128 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width * 0.5 * (double) scale), (float) ((double) num129 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height)), Main.player[Main.myPlayer].inventory[index20].GetAlpha(color17), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index20].color != new Microsoft.Xna.Framework.Color())
                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type], new Vector2((float) ((double) num128 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width * 0.5 * (double) scale), (float) ((double) num129 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index20].type].Height)), Main.player[Main.myPlayer].inventory[index20].GetColor(color17), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index20].stack > 1)
                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].inventory[index20].stack), new Vector2((float) num128 + 10f * Main.inventoryScale, (float) num129 + 26f * Main.inventoryScale), color17, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
            }
          }
          Vector2 vector2_10 = Main.fontMouseText.MeasureString("Ammo");
          Vector2 vector2_11 = Main.fontMouseText.MeasureString(Lang.inter[27]);
          float num132 = vector2_10.X / vector2_11.X;
          this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[27], new Vector2(532f, (float) (84.0 + ((double) vector2_10.Y - (double) vector2_10.Y * (double) num132) / 2.0)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 0.75f * num132, SpriteEffects.None, 0.0f);
          Main.inventoryScale = 0.6f;
          for (int index21 = 0; index21 < 4; ++index21)
          {
            int num133 = 534;
            int num134 = (int) (85.0 + (double) (index21 * 56) * (double) Main.inventoryScale + 20.0);
            int index22 = 44 + index21;
            Microsoft.Xna.Framework.Color color18 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
            if (Main.mouseX >= num133 && (double) Main.mouseX <= (double) num133 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num134 && (double) Main.mouseY <= (double) num134 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
            {
              Main.player[Main.myPlayer].mouseInterface = true;
              if (Main.mouseLeftRelease && Main.mouseLeft)
              {
                if (Main.keyState.IsKeyDown(Keys.LeftShift))
                {
                  if (Main.player[Main.myPlayer].inventory[index22].type > 0)
                  {
                    if (Main.npcShop > 0)
                    {
                      if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[index22].value, Main.player[Main.myPlayer].inventory[index22].stack))
                      {
                        this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[index22]);
                        Main.player[Main.myPlayer].inventory[index22].SetDefaults(0);
                        Main.PlaySound(18);
                      }
                      else if (Main.player[Main.myPlayer].inventory[index22].value == 0)
                      {
                        this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[index22]);
                        Main.player[Main.myPlayer].inventory[index22].SetDefaults(0);
                        Main.PlaySound(7);
                      }
                    }
                    else
                    {
                      Recipe.FindRecipes();
                      Main.PlaySound(7);
                      Main.trashItem = (Item) Main.player[Main.myPlayer].inventory[index22].Clone();
                      Main.player[Main.myPlayer].inventory[index22].SetDefaults(0);
                    }
                  }
                }
                else if ((Main.player[Main.myPlayer].selectedItem != index22 || Main.player[Main.myPlayer].itemAnimation <= 0) && (Main.mouseItem.type == 0 || Main.mouseItem.ammo > 0 || Main.mouseItem.type == 530))
                {
                  Item mouseItem = Main.mouseItem;
                  Main.mouseItem = Main.player[Main.myPlayer].inventory[index22];
                  Main.player[Main.myPlayer].inventory[index22] = mouseItem;
                  if (Main.player[Main.myPlayer].inventory[index22].type == 0 || Main.player[Main.myPlayer].inventory[index22].stack < 1)
                    Main.player[Main.myPlayer].inventory[index22] = new Item();
                  if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index22]) && Main.player[Main.myPlayer].inventory[index22].stack != Main.player[Main.myPlayer].inventory[index22].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                  {
                    if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[index22].stack <= Main.mouseItem.maxStack)
                    {
                      Main.player[Main.myPlayer].inventory[index22].stack += Main.mouseItem.stack;
                      Main.mouseItem.stack = 0;
                    }
                    else
                    {
                      int num135 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[index22].stack;
                      Main.player[Main.myPlayer].inventory[index22].stack += num135;
                      Main.mouseItem.stack -= num135;
                    }
                  }
                  if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                    Main.mouseItem = new Item();
                  if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[index22].type > 0)
                    Main.PlaySound(7);
                  Recipe.FindRecipes();
                }
              }
              else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[index22]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
              {
                if (Main.mouseItem.type == 0)
                {
                  Main.mouseItem = (Item) Main.player[Main.myPlayer].inventory[index22].Clone();
                  Main.mouseItem.stack = 0;
                }
                ++Main.mouseItem.stack;
                --Main.player[Main.myPlayer].inventory[index22].stack;
                if (Main.player[Main.myPlayer].inventory[index22].stack <= 0)
                  Main.player[Main.myPlayer].inventory[index22] = new Item();
                Recipe.FindRecipes();
                Main.soundInstanceMenuTick.Stop();
                Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                Main.PlaySound(12);
                Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
              }
              cursorText1 = Main.player[Main.myPlayer].inventory[index22].name;
              Main.toolTip = (Item) Main.player[Main.myPlayer].inventory[index22].Clone();
              if (Main.player[Main.myPlayer].inventory[index22].stack > 1)
                cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].inventory[index22].stack + ")";
            }
            this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float) num133, (float) num134), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
            color18 = Microsoft.Xna.Framework.Color.White;
            if (Main.player[Main.myPlayer].inventory[index22].type > 0 && Main.player[Main.myPlayer].inventory[index22].stack > 0)
            {
              float num136 = 1f;
              if (Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height > 32)
                num136 = Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width;
              float scale = num136 * Main.inventoryScale;
              this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type], new Vector2((float) ((double) num133 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width * 0.5 * (double) scale), (float) ((double) num134 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height)), Main.player[Main.myPlayer].inventory[index22].GetAlpha(color18), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index22].color != new Microsoft.Xna.Framework.Color())
                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type], new Vector2((float) ((double) num133 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width * 0.5 * (double) scale), (float) ((double) num134 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index22].type].Height)), Main.player[Main.myPlayer].inventory[index22].GetColor(color18), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index22].stack > 1)
                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].inventory[index22].stack), new Vector2((float) num133 + 10f * Main.inventoryScale, (float) num134 + 26f * Main.inventoryScale), color18, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
            }
          }
          if (Main.npcShop > 0 && (!Main.playerInventory || Main.player[Main.myPlayer].talkNPC == -1))
            Main.npcShop = 0;
          if (Main.npcShop > 0)
          {
            this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[28], new Vector2(284f, 210f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            Main.inventoryScale = 0.75f;
            if (Main.mouseX > 73 && Main.mouseX < (int) (73.0 + 280.0 * (double) Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int) (210.0 + 224.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int index23 = 0; index23 < 5; ++index23)
            {
              for (int index24 = 0; index24 < 4; ++index24)
              {
                int num137 = (int) (73.0 + (double) (index23 * 56) * (double) Main.inventoryScale);
                int num138 = (int) (210.0 + (double) (index24 * 56) * (double) Main.inventoryScale);
                int index25 = index23 + index24 * 5;
                Microsoft.Xna.Framework.Color color19 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
                if (Main.mouseX >= num137 && (double) Main.mouseX <= (double) num137 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num138 && (double) Main.mouseY <= (double) num138 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                {
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.mouseLeftRelease && Main.mouseLeft)
                  {
                    if (Main.mouseItem.type == 0)
                    {
                      if ((Main.player[Main.myPlayer].selectedItem != index25 || Main.player[Main.myPlayer].itemAnimation <= 0) && Main.player[Main.myPlayer].BuyItem(this.shop[Main.npcShop].item[index25].value))
                      {
                        if (this.shop[Main.npcShop].item[index25].buyOnce)
                        {
                          int prefix = (int) this.shop[Main.npcShop].item[index25].prefix;
                          Main.mouseItem.netDefaults(this.shop[Main.npcShop].item[index25].netID);
                          Main.mouseItem.Prefix(prefix);
                        }
                        else
                        {
                          Main.mouseItem.netDefaults(this.shop[Main.npcShop].item[index25].netID);
                          Main.mouseItem.Prefix(-1);
                        }
                        Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float) (Main.player[Main.myPlayer].width / 2) - (float) (Main.mouseItem.width / 2);
                        Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float) (Main.player[Main.myPlayer].height / 2) - (float) (Main.mouseItem.height / 2);
                        ItemText.NewText(Main.mouseItem, Main.mouseItem.stack);
                        if (this.shop[Main.npcShop].item[index25].buyOnce)
                        {
                          --this.shop[Main.npcShop].item[index25].stack;
                          if (this.shop[Main.npcShop].item[index25].stack <= 0)
                            this.shop[Main.npcShop].item[index25].SetDefaults(0);
                        }
                        Main.PlaySound(18);
                      }
                    }
                    else if (this.shop[Main.npcShop].item[index25].type == 0)
                    {
                      if (Main.player[Main.myPlayer].SellItem(Main.mouseItem.value, Main.mouseItem.stack))
                      {
                        this.shop[Main.npcShop].AddShop(Main.mouseItem);
                        Main.mouseItem.stack = 0;
                        Main.mouseItem.type = 0;
                        Main.PlaySound(18);
                      }
                      else if (Main.mouseItem.value == 0)
                      {
                        this.shop[Main.npcShop].AddShop(Main.mouseItem);
                        Main.mouseItem.stack = 0;
                        Main.mouseItem.type = 0;
                        Main.PlaySound(7);
                      }
                    }
                  }
                  else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(this.shop[Main.npcShop].item[index25]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0) && Main.player[Main.myPlayer].BuyItem(this.shop[Main.npcShop].item[index25].value))
                  {
                    Main.PlaySound(18);
                    if (Main.mouseItem.type == 0)
                    {
                      Main.mouseItem.netDefaults(this.shop[Main.npcShop].item[index25].netID);
                      Main.mouseItem.stack = 0;
                    }
                    ++Main.mouseItem.stack;
                    Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                    if (this.shop[Main.npcShop].item[index25].buyOnce)
                    {
                      --this.shop[Main.npcShop].item[index25].stack;
                      if (this.shop[Main.npcShop].item[index25].stack <= 0)
                        this.shop[Main.npcShop].item[index25].SetDefaults(0);
                    }
                  }
                  cursorText1 = this.shop[Main.npcShop].item[index25].name;
                  Main.toolTip = (Item) this.shop[Main.npcShop].item[index25].Clone();
                  Main.toolTip.buy = true;
                  if (this.shop[Main.npcShop].item[index25].stack > 1)
                    cursorText1 = cursorText1 + " (" + (object) this.shop[Main.npcShop].item[index25].stack + ")";
                }
                this.spriteBatch.Draw(Main.inventoryBack6Texture, new Vector2((float) num137, (float) num138), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                color19 = Microsoft.Xna.Framework.Color.White;
                if (this.shop[Main.npcShop].item[index25].type > 0 && this.shop[Main.npcShop].item[index25].stack > 0)
                {
                  float num139 = 1f;
                  if (Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width > 32 || Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height > 32)
                    num139 = Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width <= Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height ? 32f / (float) Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height : 32f / (float) Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width;
                  float scale = num139 * Main.inventoryScale;
                  this.spriteBatch.Draw(Main.itemTexture[this.shop[Main.npcShop].item[index25].type], new Vector2((float) ((double) num137 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width * 0.5 * (double) scale), (float) ((double) num138 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width, Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height)), this.shop[Main.npcShop].item[index25].GetAlpha(color19), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (this.shop[Main.npcShop].item[index25].color != new Microsoft.Xna.Framework.Color())
                    this.spriteBatch.Draw(Main.itemTexture[this.shop[Main.npcShop].item[index25].type], new Vector2((float) ((double) num137 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width * 0.5 * (double) scale), (float) ((double) num138 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Width, Main.itemTexture[this.shop[Main.npcShop].item[index25].type].Height)), this.shop[Main.npcShop].item[index25].GetColor(color19), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (this.shop[Main.npcShop].item[index25].stack > 1)
                    this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) this.shop[Main.npcShop].item[index25].stack), new Vector2((float) num137 + 10f * Main.inventoryScale, (float) num138 + 26f * Main.inventoryScale), color19, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
          if (Main.player[Main.myPlayer].chest > -1 && Main.tile[Main.player[Main.myPlayer].chestX, Main.player[Main.myPlayer].chestY].type != (byte) 21)
            Main.player[Main.myPlayer].chest = -1;
          if (Main.player[Main.myPlayer].chest != -1)
          {
            Main.inventoryScale = 0.75f;
            if (Main.mouseX > 73 && Main.mouseX < (int) (73.0 + 280.0 * (double) Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int) (210.0 + 224.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int index26 = 0; index26 < 3; ++index26)
            {
              int num140 = 286;
              int num141 = 250;
              float scale = this.chestLootScale;
              string text20 = Lang.inter[29];
              if (index26 == 1)
              {
                num141 += 26;
                scale = this.chestDepositScale;
                text20 = Lang.inter[30];
              }
              else if (index26 == 2)
              {
                num141 += 52;
                scale = this.chestStackScale;
                text20 = Lang.inter[31];
              }
              Vector2 origin = Main.fontMouseText.MeasureString(text20) / 2f;
              Microsoft.Xna.Framework.Color color20 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.mouseTextColor * (double) scale), (int) (byte) ((double) Main.mouseTextColor * (double) scale), (int) (byte) ((double) Main.mouseTextColor * (double) scale), (int) (byte) ((double) Main.mouseTextColor * (double) scale));
              int num142 = num140 + (int) ((double) origin.X * (double) scale);
              this.spriteBatch.DrawString(Main.fontMouseText, text20, new Vector2((float) num142, (float) num141), color20, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
              origin *= scale;
              float num143;
              if ((double) Main.mouseX > (double) num142 - (double) origin.X && (double) Main.mouseX < (double) num142 + (double) origin.X && (double) Main.mouseY > (double) num141 - (double) origin.Y && (double) Main.mouseY < (double) num141 + (double) origin.Y)
              {
                switch (index26)
                {
                  case 0:
                    if (!this.chestLootHover)
                      Main.PlaySound(12);
                    this.chestLootHover = true;
                    break;
                  case 1:
                    if (!this.chestDepositHover)
                      Main.PlaySound(12);
                    this.chestDepositHover = true;
                    break;
                  default:
                    if (!this.chestStackHover)
                      Main.PlaySound(12);
                    this.chestStackHover = true;
                    break;
                }
                Main.player[Main.myPlayer].mouseInterface = true;
                num143 = scale + 0.05f;
                if (Main.mouseLeft && Main.mouseLeftRelease)
                {
                  switch (index26)
                  {
                    case 0:
                      if (Main.player[Main.myPlayer].chest > -1)
                      {
                        for (int index27 = 0; index27 < 20; ++index27)
                        {
                          if (Main.chest[Main.player[Main.myPlayer].chest].item[index27].type > 0)
                          {
                            Main.chest[Main.player[Main.myPlayer].chest].item[index27] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.chest[Main.player[Main.myPlayer].chest].item[index27]);
                            if (Main.netMode == 1)
                              NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index27));
                          }
                        }
                        break;
                      }
                      if (Main.player[Main.myPlayer].chest == -3)
                      {
                        for (int index28 = 0; index28 < 20; ++index28)
                        {
                          if (Main.player[Main.myPlayer].bank2[index28].type > 0)
                            Main.player[Main.myPlayer].bank2[index28] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.player[Main.myPlayer].bank2[index28]);
                        }
                        break;
                      }
                      for (int index29 = 0; index29 < 20; ++index29)
                      {
                        if (Main.player[Main.myPlayer].bank[index29].type > 0)
                          Main.player[Main.myPlayer].bank[index29] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.player[Main.myPlayer].bank[index29]);
                      }
                      break;
                    case 1:
                      for (int index30 = 40; index30 >= 10; --index30)
                      {
                        if (Main.player[Main.myPlayer].inventory[index30].stack > 0 && Main.player[Main.myPlayer].inventory[index30].type > 0)
                        {
                          if (Main.player[Main.myPlayer].inventory[index30].maxStack > 1)
                          {
                            for (int index31 = 0; index31 < 20; ++index31)
                            {
                              if (Main.player[Main.myPlayer].chest > -1)
                              {
                                if (Main.chest[Main.player[Main.myPlayer].chest].item[index31].stack < Main.chest[Main.player[Main.myPlayer].chest].item[index31].maxStack && Main.player[Main.myPlayer].inventory[index30].IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[index31]))
                                {
                                  int num144 = Main.player[Main.myPlayer].inventory[index30].stack;
                                  if (Main.player[Main.myPlayer].inventory[index30].stack + Main.chest[Main.player[Main.myPlayer].chest].item[index31].stack > Main.chest[Main.player[Main.myPlayer].chest].item[index31].maxStack)
                                    num144 = Main.chest[Main.player[Main.myPlayer].chest].item[index31].maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[index31].stack;
                                  Main.player[Main.myPlayer].inventory[index30].stack -= num144;
                                  Main.chest[Main.player[Main.myPlayer].chest].item[index31].stack += num144;
                                  Main.ChestCoins();
                                  Main.PlaySound(7);
                                  if (Main.player[Main.myPlayer].inventory[index30].stack <= 0)
                                  {
                                    Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                    if (Main.netMode == 1)
                                    {
                                      NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index31));
                                      break;
                                    }
                                    break;
                                  }
                                  if (Main.chest[Main.player[Main.myPlayer].chest].item[index31].type == 0)
                                  {
                                    Main.chest[Main.player[Main.myPlayer].chest].item[index31] = (Item) Main.player[Main.myPlayer].inventory[index30].Clone();
                                    Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                  }
                                  if (Main.netMode == 1)
                                    NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index31));
                                }
                              }
                              else if (Main.player[Main.myPlayer].chest == -3)
                              {
                                if (Main.player[Main.myPlayer].bank2[index31].stack < Main.player[Main.myPlayer].bank2[index31].maxStack && Main.player[Main.myPlayer].inventory[index30].IsTheSameAs(Main.player[Main.myPlayer].bank2[index31]))
                                {
                                  int num145 = Main.player[Main.myPlayer].inventory[index30].stack;
                                  if (Main.player[Main.myPlayer].inventory[index30].stack + Main.player[Main.myPlayer].bank2[index31].stack > Main.player[Main.myPlayer].bank2[index31].maxStack)
                                    num145 = Main.player[Main.myPlayer].bank2[index31].maxStack - Main.player[Main.myPlayer].bank2[index31].stack;
                                  Main.player[Main.myPlayer].inventory[index30].stack -= num145;
                                  Main.player[Main.myPlayer].bank2[index31].stack += num145;
                                  Main.PlaySound(7);
                                  Main.BankCoins();
                                  if (Main.player[Main.myPlayer].inventory[index30].stack <= 0)
                                  {
                                    Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                    break;
                                  }
                                  if (Main.player[Main.myPlayer].bank2[index31].type == 0)
                                  {
                                    Main.player[Main.myPlayer].bank2[index31] = (Item) Main.player[Main.myPlayer].inventory[index30].Clone();
                                    Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                  }
                                }
                              }
                              else if (Main.player[Main.myPlayer].bank[index31].stack < Main.player[Main.myPlayer].bank[index31].maxStack && Main.player[Main.myPlayer].inventory[index30].IsTheSameAs(Main.player[Main.myPlayer].bank[index31]))
                              {
                                int num146 = Main.player[Main.myPlayer].inventory[index30].stack;
                                if (Main.player[Main.myPlayer].inventory[index30].stack + Main.player[Main.myPlayer].bank[index31].stack > Main.player[Main.myPlayer].bank[index31].maxStack)
                                  num146 = Main.player[Main.myPlayer].bank[index31].maxStack - Main.player[Main.myPlayer].bank[index31].stack;
                                Main.player[Main.myPlayer].inventory[index30].stack -= num146;
                                Main.player[Main.myPlayer].bank[index31].stack += num146;
                                Main.PlaySound(7);
                                Main.BankCoins();
                                if (Main.player[Main.myPlayer].inventory[index30].stack <= 0)
                                {
                                  Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                  break;
                                }
                                if (Main.player[Main.myPlayer].bank[index31].type == 0)
                                {
                                  Main.player[Main.myPlayer].bank[index31] = (Item) Main.player[Main.myPlayer].inventory[index30].Clone();
                                  Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                }
                              }
                            }
                          }
                          if (Main.player[Main.myPlayer].inventory[index30].stack > 0)
                          {
                            if (Main.player[Main.myPlayer].chest > -1)
                            {
                              for (int index32 = 0; index32 < 20; ++index32)
                              {
                                if (Main.chest[Main.player[Main.myPlayer].chest].item[index32].stack == 0)
                                {
                                  Main.PlaySound(7);
                                  Main.chest[Main.player[Main.myPlayer].chest].item[index32] = (Item) Main.player[Main.myPlayer].inventory[index30].Clone();
                                  Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                  if (Main.netMode == 1)
                                  {
                                    NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index32));
                                    break;
                                  }
                                  break;
                                }
                              }
                            }
                            else if (Main.player[Main.myPlayer].chest == -3)
                            {
                              for (int index33 = 0; index33 < 20; ++index33)
                              {
                                if (Main.player[Main.myPlayer].bank2[index33].stack == 0)
                                {
                                  Main.PlaySound(7);
                                  Main.player[Main.myPlayer].bank2[index33] = (Item) Main.player[Main.myPlayer].inventory[index30].Clone();
                                  Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                  break;
                                }
                              }
                            }
                            else
                            {
                              for (int index34 = 0; index34 < 20; ++index34)
                              {
                                if (Main.player[Main.myPlayer].bank[index34].stack == 0)
                                {
                                  Main.PlaySound(7);
                                  Main.player[Main.myPlayer].bank[index34] = (Item) Main.player[Main.myPlayer].inventory[index30].Clone();
                                  Main.player[Main.myPlayer].inventory[index30].SetDefaults(0);
                                  break;
                                }
                              }
                            }
                          }
                        }
                      }
                      break;
                    default:
                      if (Main.player[Main.myPlayer].chest > -1)
                      {
                        for (int index35 = 0; index35 < 20; ++index35)
                        {
                          if (Main.chest[Main.player[Main.myPlayer].chest].item[index35].type > 0 && Main.chest[Main.player[Main.myPlayer].chest].item[index35].stack < Main.chest[Main.player[Main.myPlayer].chest].item[index35].maxStack)
                          {
                            for (int index36 = 0; index36 < 48; ++index36)
                            {
                              if (Main.chest[Main.player[Main.myPlayer].chest].item[index35].IsTheSameAs(Main.player[Main.myPlayer].inventory[index36]))
                              {
                                int num147 = Main.player[Main.myPlayer].inventory[index36].stack;
                                if (Main.chest[Main.player[Main.myPlayer].chest].item[index35].stack + num147 > Main.chest[Main.player[Main.myPlayer].chest].item[index35].maxStack)
                                  num147 = Main.chest[Main.player[Main.myPlayer].chest].item[index35].maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[index35].stack;
                                Main.PlaySound(7);
                                Main.chest[Main.player[Main.myPlayer].chest].item[index35].stack += num147;
                                Main.player[Main.myPlayer].inventory[index36].stack -= num147;
                                Main.ChestCoins();
                                if (Main.player[Main.myPlayer].inventory[index36].stack == 0)
                                  Main.player[Main.myPlayer].inventory[index36].SetDefaults(0);
                                else if (Main.chest[Main.player[Main.myPlayer].chest].item[index35].type == 0)
                                {
                                  Main.chest[Main.player[Main.myPlayer].chest].item[index35] = (Item) Main.player[Main.myPlayer].inventory[index36].Clone();
                                  Main.player[Main.myPlayer].inventory[index36].SetDefaults(0);
                                }
                                if (Main.netMode == 1)
                                  NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index35));
                              }
                            }
                          }
                        }
                        break;
                      }
                      if (Main.player[Main.myPlayer].chest == -3)
                      {
                        for (int index37 = 0; index37 < 20; ++index37)
                        {
                          if (Main.player[Main.myPlayer].bank2[index37].type > 0 && Main.player[Main.myPlayer].bank2[index37].stack < Main.player[Main.myPlayer].bank2[index37].maxStack)
                          {
                            for (int index38 = 0; index38 < 48; ++index38)
                            {
                              if (Main.player[Main.myPlayer].bank2[index37].IsTheSameAs(Main.player[Main.myPlayer].inventory[index38]))
                              {
                                int num148 = Main.player[Main.myPlayer].inventory[index38].stack;
                                if (Main.player[Main.myPlayer].bank2[index37].stack + num148 > Main.player[Main.myPlayer].bank2[index37].maxStack)
                                  num148 = Main.player[Main.myPlayer].bank2[index37].maxStack - Main.player[Main.myPlayer].bank2[index37].stack;
                                Main.PlaySound(7);
                                Main.player[Main.myPlayer].bank2[index37].stack += num148;
                                Main.player[Main.myPlayer].inventory[index38].stack -= num148;
                                Main.BankCoins();
                                if (Main.player[Main.myPlayer].inventory[index38].stack == 0)
                                  Main.player[Main.myPlayer].inventory[index38].SetDefaults(0);
                                else if (Main.player[Main.myPlayer].bank2[index37].type == 0)
                                {
                                  Main.player[Main.myPlayer].bank2[index37] = (Item) Main.player[Main.myPlayer].inventory[index38].Clone();
                                  Main.player[Main.myPlayer].inventory[index38].SetDefaults(0);
                                }
                              }
                            }
                          }
                        }
                        break;
                      }
                      for (int index39 = 0; index39 < 20; ++index39)
                      {
                        if (Main.player[Main.myPlayer].bank[index39].type > 0 && Main.player[Main.myPlayer].bank[index39].stack < Main.player[Main.myPlayer].bank[index39].maxStack)
                        {
                          for (int index40 = 0; index40 < 48; ++index40)
                          {
                            if (Main.player[Main.myPlayer].bank[index39].IsTheSameAs(Main.player[Main.myPlayer].inventory[index40]))
                            {
                              int num149 = Main.player[Main.myPlayer].inventory[index40].stack;
                              if (Main.player[Main.myPlayer].bank[index39].stack + num149 > Main.player[Main.myPlayer].bank[index39].maxStack)
                                num149 = Main.player[Main.myPlayer].bank[index39].maxStack - Main.player[Main.myPlayer].bank[index39].stack;
                              Main.PlaySound(7);
                              Main.player[Main.myPlayer].bank[index39].stack += num149;
                              Main.player[Main.myPlayer].inventory[index40].stack -= num149;
                              Main.BankCoins();
                              if (Main.player[Main.myPlayer].inventory[index40].stack == 0)
                                Main.player[Main.myPlayer].inventory[index40].SetDefaults(0);
                              else if (Main.player[Main.myPlayer].bank[index39].type == 0)
                              {
                                Main.player[Main.myPlayer].bank[index39] = (Item) Main.player[Main.myPlayer].inventory[index40].Clone();
                                Main.player[Main.myPlayer].inventory[index40].SetDefaults(0);
                              }
                            }
                          }
                        }
                      }
                      break;
                  }
                  Recipe.FindRecipes();
                }
              }
              else
              {
                num143 = scale - 0.05f;
                switch (index26)
                {
                  case 0:
                    this.chestLootHover = false;
                    break;
                  case 1:
                    this.chestDepositHover = false;
                    break;
                  default:
                    this.chestStackHover = false;
                    break;
                }
              }
              if ((double) num143 < 0.75)
                num143 = 0.75f;
              if ((double) num143 > 1.0)
                num143 = 1f;
              switch (index26)
              {
                case 0:
                  this.chestLootScale = num143;
                  break;
                case 1:
                  this.chestDepositScale = num143;
                  break;
                default:
                  this.chestStackScale = num143;
                  break;
              }
            }
          }
          else
          {
            this.chestLootScale = 0.75f;
            this.chestDepositScale = 0.75f;
            this.chestStackScale = 0.75f;
            this.chestLootHover = false;
            this.chestDepositHover = false;
            this.chestStackHover = false;
          }
          if (Main.player[Main.myPlayer].chest > -1)
          {
            this.spriteBatch.DrawString(Main.fontMouseText, Main.chestText, new Vector2(284f, 210f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            Main.inventoryScale = 0.75f;
            if (Main.mouseX > 73 && Main.mouseX < (int) (73.0 + 280.0 * (double) Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int) (210.0 + 224.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int index41 = 0; index41 < 5; ++index41)
            {
              for (int index42 = 0; index42 < 4; ++index42)
              {
                int num150 = (int) (73.0 + (double) (index41 * 56) * (double) Main.inventoryScale);
                int num151 = (int) (210.0 + (double) (index42 * 56) * (double) Main.inventoryScale);
                int index43 = index41 + index42 * 5;
                Microsoft.Xna.Framework.Color color21 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
                if (Main.mouseX >= num150 && (double) Main.mouseX <= (double) num150 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num151 && (double) Main.mouseY <= (double) num151 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                {
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.mouseLeftRelease && Main.mouseLeft)
                  {
                    if (Main.player[Main.myPlayer].selectedItem != index43 || Main.player[Main.myPlayer].itemAnimation <= 0)
                    {
                      Item mouseItem = Main.mouseItem;
                      Main.mouseItem = Main.chest[Main.player[Main.myPlayer].chest].item[index43];
                      Main.chest[Main.player[Main.myPlayer].chest].item[index43] = mouseItem;
                      if (Main.chest[Main.player[Main.myPlayer].chest].item[index43].type == 0 || Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack < 1)
                        Main.chest[Main.player[Main.myPlayer].chest].item[index43] = new Item();
                      if (Main.mouseItem.IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[index43]) && Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack != Main.chest[Main.player[Main.myPlayer].chest].item[index43].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                      {
                        if (Main.mouseItem.stack + Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack <= Main.mouseItem.maxStack)
                        {
                          Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack += Main.mouseItem.stack;
                          Main.mouseItem.stack = 0;
                        }
                        else
                        {
                          int num152 = Main.mouseItem.maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack;
                          Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack += num152;
                          Main.mouseItem.stack -= num152;
                        }
                      }
                      if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                        Main.mouseItem = new Item();
                      if (Main.mouseItem.type > 0 || Main.chest[Main.player[Main.myPlayer].chest].item[index43].type > 0)
                      {
                        Recipe.FindRecipes();
                        Main.PlaySound(7);
                      }
                      if (Main.netMode == 1)
                        NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index43));
                    }
                  }
                  else if (Main.mouseRight && Main.mouseRightRelease && Main.chest[Main.player[Main.myPlayer].chest].item[index43].maxStack == 1)
                  {
                    Main.chest[Main.player[Main.myPlayer].chest].item[index43] = Main.armorSwap(Main.chest[Main.player[Main.myPlayer].chest].item[index43]);
                    if (Main.netMode == 1)
                      NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index43));
                  }
                  else if (Main.stackSplit <= 1 && Main.mouseRight && Main.chest[Main.player[Main.myPlayer].chest].item[index43].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[index43]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                  {
                    if (Main.mouseItem.type == 0)
                    {
                      Main.mouseItem = (Item) Main.chest[Main.player[Main.myPlayer].chest].item[index43].Clone();
                      Main.mouseItem.stack = 0;
                    }
                    ++Main.mouseItem.stack;
                    --Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack;
                    if (Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack <= 0)
                      Main.chest[Main.player[Main.myPlayer].chest].item[index43] = new Item();
                    Recipe.FindRecipes();
                    Main.soundInstanceMenuTick.Stop();
                    Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                    Main.PlaySound(12);
                    Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                    if (Main.netMode == 1)
                      NetMessage.SendData(32, number: Main.player[Main.myPlayer].chest, number2: ((float) index43));
                  }
                  cursorText1 = Main.chest[Main.player[Main.myPlayer].chest].item[index43].name;
                  Main.toolTip = (Item) Main.chest[Main.player[Main.myPlayer].chest].item[index43].Clone();
                  if (Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack > 1)
                    cursorText1 = cursorText1 + " (" + (object) Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack + ")";
                }
                this.spriteBatch.Draw(Main.inventoryBack5Texture, new Vector2((float) num150, (float) num151), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                color21 = Microsoft.Xna.Framework.Color.White;
                if (Main.chest[Main.player[Main.myPlayer].chest].item[index43].type > 0 && Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack > 0)
                {
                  float num153 = 1f;
                  if (Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width > 32 || Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height > 32)
                    num153 = Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width <= Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height ? 32f / (float) Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height : 32f / (float) Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width;
                  float scale = num153 * Main.inventoryScale;
                  this.spriteBatch.Draw(Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type], new Vector2((float) ((double) num150 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width * 0.5 * (double) scale), (float) ((double) num151 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height)), Main.chest[Main.player[Main.myPlayer].chest].item[index43].GetAlpha(color21), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (Main.chest[Main.player[Main.myPlayer].chest].item[index43].color != new Microsoft.Xna.Framework.Color())
                    this.spriteBatch.Draw(Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type], new Vector2((float) ((double) num150 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width * 0.5 * (double) scale), (float) ((double) num151 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Width, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[index43].type].Height)), Main.chest[Main.player[Main.myPlayer].chest].item[index43].GetColor(color21), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack > 1)
                    this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.chest[Main.player[Main.myPlayer].chest].item[index43].stack), new Vector2((float) num150 + 10f * Main.inventoryScale, (float) num151 + 26f * Main.inventoryScale), color21, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
          if (Main.player[Main.myPlayer].chest == -2)
          {
            this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[32], new Vector2(284f, 210f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            Main.inventoryScale = 0.75f;
            if (Main.mouseX > 73 && Main.mouseX < (int) (73.0 + 280.0 * (double) Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int) (210.0 + 224.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int index44 = 0; index44 < 5; ++index44)
            {
              for (int index45 = 0; index45 < 4; ++index45)
              {
                int num154 = (int) (73.0 + (double) (index44 * 56) * (double) Main.inventoryScale);
                int num155 = (int) (210.0 + (double) (index45 * 56) * (double) Main.inventoryScale);
                int index46 = index44 + index45 * 5;
                Microsoft.Xna.Framework.Color color22 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
                if (Main.mouseX >= num154 && (double) Main.mouseX <= (double) num154 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num155 && (double) Main.mouseY <= (double) num155 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                {
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.mouseLeftRelease && Main.mouseLeft)
                  {
                    if (Main.player[Main.myPlayer].selectedItem != index46 || Main.player[Main.myPlayer].itemAnimation <= 0)
                    {
                      Item mouseItem = Main.mouseItem;
                      Main.mouseItem = Main.player[Main.myPlayer].bank[index46];
                      Main.player[Main.myPlayer].bank[index46] = mouseItem;
                      if (Main.player[Main.myPlayer].bank[index46].type == 0 || Main.player[Main.myPlayer].bank[index46].stack < 1)
                        Main.player[Main.myPlayer].bank[index46] = new Item();
                      if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank[index46]) && Main.player[Main.myPlayer].bank[index46].stack != Main.player[Main.myPlayer].bank[index46].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                      {
                        if (Main.mouseItem.stack + Main.player[Main.myPlayer].bank[index46].stack <= Main.mouseItem.maxStack)
                        {
                          Main.player[Main.myPlayer].bank[index46].stack += Main.mouseItem.stack;
                          Main.mouseItem.stack = 0;
                        }
                        else
                        {
                          int num156 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].bank[index46].stack;
                          Main.player[Main.myPlayer].bank[index46].stack += num156;
                          Main.mouseItem.stack -= num156;
                        }
                      }
                      if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                        Main.mouseItem = new Item();
                      if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].bank[index46].type > 0)
                      {
                        Recipe.FindRecipes();
                        Main.PlaySound(7);
                      }
                    }
                  }
                  else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].bank[index46].maxStack == 1)
                    Main.player[Main.myPlayer].bank[index46] = Main.armorSwap(Main.player[Main.myPlayer].bank[index46]);
                  else if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].bank[index46].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank[index46]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                  {
                    if (Main.mouseItem.type == 0)
                    {
                      Main.mouseItem = (Item) Main.player[Main.myPlayer].bank[index46].Clone();
                      Main.mouseItem.stack = 0;
                    }
                    ++Main.mouseItem.stack;
                    --Main.player[Main.myPlayer].bank[index46].stack;
                    if (Main.player[Main.myPlayer].bank[index46].stack <= 0)
                      Main.player[Main.myPlayer].bank[index46] = new Item();
                    Recipe.FindRecipes();
                    Main.soundInstanceMenuTick.Stop();
                    Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                    Main.PlaySound(12);
                    Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                  }
                  cursorText1 = Main.player[Main.myPlayer].bank[index46].name;
                  Main.toolTip = (Item) Main.player[Main.myPlayer].bank[index46].Clone();
                  if (Main.player[Main.myPlayer].bank[index46].stack > 1)
                    cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].bank[index46].stack + ")";
                }
                this.spriteBatch.Draw(Main.inventoryBack2Texture, new Vector2((float) num154, (float) num155), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                color22 = Microsoft.Xna.Framework.Color.White;
                if (Main.player[Main.myPlayer].bank[index46].type > 0 && Main.player[Main.myPlayer].bank[index46].stack > 0)
                {
                  float num157 = 1f;
                  if (Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height > 32)
                    num157 = Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width;
                  float scale = num157 * Main.inventoryScale;
                  this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type], new Vector2((float) ((double) num154 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width * 0.5 * (double) scale), (float) ((double) num155 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height)), Main.player[Main.myPlayer].bank[index46].GetAlpha(color22), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (Main.player[Main.myPlayer].bank[index46].color != new Microsoft.Xna.Framework.Color())
                    this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type], new Vector2((float) ((double) num154 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width * 0.5 * (double) scale), (float) ((double) num155 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank[index46].type].Height)), Main.player[Main.myPlayer].bank[index46].GetColor(color22), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (Main.player[Main.myPlayer].bank[index46].stack > 1)
                    this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].bank[index46].stack), new Vector2((float) num154 + 10f * Main.inventoryScale, (float) num155 + 26f * Main.inventoryScale), color22, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
          if (Main.player[Main.myPlayer].chest == -3)
          {
            this.spriteBatch.DrawString(Main.fontMouseText, Lang.inter[33], new Vector2(284f, 210f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            Main.inventoryScale = 0.75f;
            if (Main.mouseX > 73 && Main.mouseX < (int) (73.0 + 280.0 * (double) Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int) (210.0 + 224.0 * (double) Main.inventoryScale))
              Main.player[Main.myPlayer].mouseInterface = true;
            for (int index47 = 0; index47 < 5; ++index47)
            {
              for (int index48 = 0; index48 < 4; ++index48)
              {
                int num158 = (int) (73.0 + (double) (index47 * 56) * (double) Main.inventoryScale);
                int num159 = (int) (210.0 + (double) (index48 * 56) * (double) Main.inventoryScale);
                int index49 = index47 + index48 * 5;
                Microsoft.Xna.Framework.Color color23 = new Microsoft.Xna.Framework.Color(100, 100, 100, 100);
                if (Main.mouseX >= num158 && (double) Main.mouseX <= (double) num158 + (double) Main.inventoryBackTexture.Width * (double) Main.inventoryScale && Main.mouseY >= num159 && (double) Main.mouseY <= (double) num159 + (double) Main.inventoryBackTexture.Height * (double) Main.inventoryScale)
                {
                  Main.player[Main.myPlayer].mouseInterface = true;
                  if (Main.mouseLeftRelease && Main.mouseLeft)
                  {
                    if (Main.player[Main.myPlayer].selectedItem != index49 || Main.player[Main.myPlayer].itemAnimation <= 0)
                    {
                      Item mouseItem = Main.mouseItem;
                      Main.mouseItem = Main.player[Main.myPlayer].bank2[index49];
                      Main.player[Main.myPlayer].bank2[index49] = mouseItem;
                      if (Main.player[Main.myPlayer].bank2[index49].type == 0 || Main.player[Main.myPlayer].bank2[index49].stack < 1)
                        Main.player[Main.myPlayer].bank2[index49] = new Item();
                      if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank2[index49]) && Main.player[Main.myPlayer].bank2[index49].stack != Main.player[Main.myPlayer].bank2[index49].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                      {
                        if (Main.mouseItem.stack + Main.player[Main.myPlayer].bank2[index49].stack <= Main.mouseItem.maxStack)
                        {
                          Main.player[Main.myPlayer].bank2[index49].stack += Main.mouseItem.stack;
                          Main.mouseItem.stack = 0;
                        }
                        else
                        {
                          int num160 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].bank2[index49].stack;
                          Main.player[Main.myPlayer].bank2[index49].stack += num160;
                          Main.mouseItem.stack -= num160;
                        }
                      }
                      if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                        Main.mouseItem = new Item();
                      if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].bank2[index49].type > 0)
                      {
                        Recipe.FindRecipes();
                        Main.PlaySound(7);
                      }
                    }
                  }
                  else if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].bank2[index49].maxStack == 1)
                    Main.player[Main.myPlayer].bank2[index49] = Main.armorSwap(Main.player[Main.myPlayer].bank2[index49]);
                  else if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].bank2[index49].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank2[index49]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                  {
                    if (Main.mouseItem.type == 0)
                    {
                      Main.mouseItem = (Item) Main.player[Main.myPlayer].bank2[index49].Clone();
                      Main.mouseItem.stack = 0;
                    }
                    ++Main.mouseItem.stack;
                    --Main.player[Main.myPlayer].bank2[index49].stack;
                    if (Main.player[Main.myPlayer].bank2[index49].stack <= 0)
                      Main.player[Main.myPlayer].bank2[index49] = new Item();
                    Recipe.FindRecipes();
                    Main.soundInstanceMenuTick.Stop();
                    Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                    Main.PlaySound(12);
                    Main.stackSplit = Main.stackSplit != 0 ? Main.stackDelay : 15;
                  }
                  cursorText1 = Main.player[Main.myPlayer].bank2[index49].name;
                  Main.toolTip = (Item) Main.player[Main.myPlayer].bank2[index49].Clone();
                  if (Main.player[Main.myPlayer].bank2[index49].stack > 1)
                    cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].bank2[index49].stack + ")";
                }
                this.spriteBatch.Draw(Main.inventoryBack2Texture, new Vector2((float) num158, (float) num159), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), color1, 0.0f, new Vector2(), Main.inventoryScale, SpriteEffects.None, 0.0f);
                color23 = Microsoft.Xna.Framework.Color.White;
                if (Main.player[Main.myPlayer].bank2[index49].type > 0 && Main.player[Main.myPlayer].bank2[index49].stack > 0)
                {
                  float num161 = 1f;
                  if (Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height > 32)
                    num161 = Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width;
                  float scale = num161 * Main.inventoryScale;
                  this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type], new Vector2((float) ((double) num158 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width * 0.5 * (double) scale), (float) ((double) num159 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height)), Main.player[Main.myPlayer].bank2[index49].GetAlpha(color23), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (Main.player[Main.myPlayer].bank2[index49].color != new Microsoft.Xna.Framework.Color())
                    this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type], new Vector2((float) ((double) num158 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width * 0.5 * (double) scale), (float) ((double) num159 + 26.0 * (double) Main.inventoryScale - (double) Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank2[index49].type].Height)), Main.player[Main.myPlayer].bank2[index49].GetColor(color23), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                  if (Main.player[Main.myPlayer].bank2[index49].stack > 1)
                    this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].bank2[index49].stack), new Vector2((float) num158 + 10f * Main.inventoryScale, (float) num159 + 26f * Main.inventoryScale), color23, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
          }
        }
        else if (Main.npcChatText == null || Main.npcChatText == "")
        {
          bool flag6 = false;
          bool flag7 = false;
          bool flag8 = false;
          for (int index50 = 0; index50 < 3; ++index50)
          {
            string text21 = "";
            if (Main.player[Main.myPlayer].accCompass > 0 && !flag8)
            {
              int num162 = (int) (((double) Main.player[Main.myPlayer].position.X + (double) (Main.player[Main.myPlayer].width / 2)) * 2.0 / 16.0 - (double) Main.maxTilesX);
              if (num162 > 0)
              {
                text21 = "Position: " + (object) num162 + " feet east";
                if (num162 == 1)
                  text21 = "Position: " + (object) num162 + " foot east";
              }
              else if (num162 < 0)
              {
                int num163 = num162 * -1;
                text21 = "Position: " + (object) num163 + " feet west";
                if (num163 == 1)
                  text21 = "Position: " + (object) num163 + " foot west";
              }
              else
                text21 = "Position: center";
              flag8 = true;
            }
            else if (Main.player[Main.myPlayer].accDepthMeter > 0 && !flag7)
            {
              int num164 = (int) (((double) Main.player[Main.myPlayer].position.Y + (double) Main.player[Main.myPlayer].height) * 2.0 / 16.0 - Main.worldSurface * 2.0);
              if (num164 > 0)
              {
                text21 = "Depth: " + (object) num164 + " feet below";
                if (num164 == 1)
                  text21 = "Depth: " + (object) num164 + " foot below";
              }
              else if (num164 < 0)
              {
                int num165 = num164 * -1;
                text21 = "Depth: " + (object) num165 + " feet above";
                if (num165 == 1)
                  text21 = "Depth: " + (object) num165 + " foot above";
              }
              else
                text21 = "Depth: Level";
              flag7 = true;
            }
            else if (Main.player[Main.myPlayer].accWatch > 0 && !flag6)
            {
              string str1 = "AM";
              double time = Main.time;
              if (!Main.dayTime)
                time += 54000.0;
              double num166 = time / 86400.0 * 24.0 - 7.5 - 12.0;
              if (num166 < 0.0)
                num166 += 24.0;
              if (num166 >= 12.0)
                str1 = "PM";
              int num167 = (int) num166;
              double num168 = (double) (int) ((num166 - (double) num167) * 60.0);
              string str2 = string.Concat((object) num168);
              if (num168 < 10.0)
                str2 = "0" + str2;
              if (num167 > 12)
                num167 -= 12;
              if (num167 == 0)
                num167 = 12;
              if (Main.player[Main.myPlayer].accWatch == 1)
                str2 = "00";
              else if (Main.player[Main.myPlayer].accWatch == 2)
                str2 = num168 >= 30.0 ? "30" : "00";
              text21 = Lang.inter[34] + ": " + (object) num167 + ":" + str2 + " " + str1;
              flag6 = true;
            }
            if (text21 != "")
            {
              for (int index51 = 0; index51 < 5; ++index51)
              {
                int num169 = 0;
                int num170 = 0;
                Microsoft.Xna.Framework.Color color24 = Microsoft.Xna.Framework.Color.Black;
                if (index51 == 0)
                  num169 = -2;
                if (index51 == 1)
                  num169 = 2;
                if (index51 == 2)
                  num170 = -2;
                if (index51 == 3)
                  num170 = 2;
                if (index51 == 4)
                  color24 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
                this.spriteBatch.DrawString(Main.fontMouseText, text21, new Vector2((float) (22 + num169), (float) (110 + 22 * index50 + num170 + 48)), color24, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
            }
          }
        }
        if (Main.playerInventory || Main.player[Main.myPlayer].ghost)
        {
          string text22 = Lang.inter[35];
          Vector2 vector2_12 = Main.fontMouseText.MeasureString("Save & Exit");
          Vector2 vector2_13 = Main.fontMouseText.MeasureString(Lang.inter[35]);
          if (Main.netMode != 0)
          {
            text22 = Lang.inter[36];
            vector2_12 = Main.fontMouseText.MeasureString("Disconnect");
            vector2_13 = Main.fontMouseText.MeasureString(Lang.inter[36]);
          }
          Vector2 vector2_14 = Main.fontDeathText.MeasureString(text22);
          int num171 = Main.screenWidth - 110;
          int num172 = Main.screenHeight - 20;
          float num173 = vector2_12.X / vector2_13.X;
          if (Main.mouseExit)
          {
            if ((double) Main.exitScale < 1.0)
              Main.exitScale += 0.02f;
          }
          else if ((double) Main.exitScale > 0.8)
            Main.exitScale -= 0.02f;
          for (int index = 0; index < 5; ++index)
          {
            int num174 = 0;
            int num175 = 0;
            Microsoft.Xna.Framework.Color color25 = Microsoft.Xna.Framework.Color.Black;
            if (index == 0)
              num174 = -2;
            if (index == 1)
              num174 = 2;
            if (index == 2)
              num175 = -2;
            if (index == 3)
              num175 = 2;
            if (index == 4)
              color25 = Microsoft.Xna.Framework.Color.White;
            this.spriteBatch.DrawString(Main.fontDeathText, text22, new Vector2((float) (num171 + num174), (float) (num172 + num175)), color25, 0.0f, new Vector2(vector2_14.X / 2f, vector2_14.Y / 2f), (Main.exitScale - 0.2f) * num173, SpriteEffects.None, 0.0f);
          }
          if ((double) Main.mouseX > (double) num171 - (double) vector2_14.X / 2.0 && (double) Main.mouseX < (double) num171 + (double) vector2_14.X / 2.0 && (double) Main.mouseY > (double) num172 - (double) vector2_14.Y / 2.0 && (double) Main.mouseY < (double) num172 + (double) vector2_14.Y / 2.0 - 10.0)
          {
            if (!Main.mouseExit)
              Main.PlaySound(12);
            Main.mouseExit = true;
            Main.player[Main.myPlayer].mouseInterface = true;
            if (Main.mouseLeftRelease && Main.mouseLeft)
            {
              Main.menuMode = 10;
              WorldGen.SaveAndQuit();
            }
          }
          else
            Main.mouseExit = false;
        }
        if (!Main.playerInventory && !Main.player[Main.myPlayer].ghost)
        {
          string text23 = Lang.inter[37];
          if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name != "" && Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name != null)
            text23 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].AffixName();
          Vector2 vector2_15 = Main.fontMouseText.MeasureString(text23) / 2f;
          this.spriteBatch.DrawString(Main.fontMouseText, text23, new Vector2(236f - vector2_15.X, 0.0f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          int num176 = 20;
          for (int index52 = 0; index52 < 10; ++index52)
          {
            if (index52 == Main.player[Main.myPlayer].selectedItem)
            {
              if ((double) Main.hotbarScale[index52] < 1.0)
                Main.hotbarScale[index52] += 0.05f;
            }
            else if ((double) Main.hotbarScale[index52] > 0.75)
              Main.hotbarScale[index52] -= 0.05f;
            float scale1 = Main.hotbarScale[index52];
            int num177 = (int) (20.0 + 22.0 * (1.0 - (double) scale1));
            Microsoft.Xna.Framework.Color color26 = new Microsoft.Xna.Framework.Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) (75.0 + 150.0 * (double) scale1));
            this.spriteBatch.Draw(Main.inventoryBackTexture, new Vector2((float) num176, (float) num177), new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height)), new Microsoft.Xna.Framework.Color(100, 100, 100, 100), 0.0f, new Vector2(), scale1, SpriteEffects.None, 0.0f);
            if (!Main.player[Main.myPlayer].hbLocked && Main.mouseX >= num176 && (double) Main.mouseX <= (double) num176 + (double) Main.inventoryBackTexture.Width * (double) Main.hotbarScale[index52] && Main.mouseY >= num177 && (double) Main.mouseY <= (double) num177 + (double) Main.inventoryBackTexture.Height * (double) Main.hotbarScale[index52] && !Main.player[Main.myPlayer].channel)
            {
              Main.player[Main.myPlayer].mouseInterface = true;
              if (Main.mouseLeft && !Main.player[Main.myPlayer].hbLocked)
                Main.player[Main.myPlayer].changeItem = index52;
              Main.player[Main.myPlayer].showItemIcon = false;
              cursorText1 = Main.player[Main.myPlayer].inventory[index52].AffixName();
              if (Main.player[Main.myPlayer].inventory[index52].stack > 1)
                cursorText1 = cursorText1 + " (" + (object) Main.player[Main.myPlayer].inventory[index52].stack + ")";
              rare1 = Main.player[Main.myPlayer].inventory[index52].rare;
            }
            if (Main.player[Main.myPlayer].inventory[index52].type > 0 && Main.player[Main.myPlayer].inventory[index52].stack > 0)
            {
              float num178 = 1f;
              if (Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height > 32)
                num178 = Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width <= Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height ? 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height : 32f / (float) Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width;
              float scale2 = num178 * scale1;
              this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type], new Vector2((float) ((double) num176 + 26.0 * (double) scale1 - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width * 0.5 * (double) scale2), (float) ((double) num177 + 26.0 * (double) scale1 - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height * 0.5 * (double) scale2)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height)), Main.player[Main.myPlayer].inventory[index52].GetAlpha(color26), 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index52].color != new Microsoft.Xna.Framework.Color())
                this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type], new Vector2((float) ((double) num176 + 26.0 * (double) scale1 - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width * 0.5 * (double) scale2), (float) ((double) num177 + 26.0 * (double) scale1 - (double) Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height * 0.5 * (double) scale2)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[index52].type].Height)), Main.player[Main.myPlayer].inventory[index52].GetColor(color26), 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index52].stack > 1)
                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.player[Main.myPlayer].inventory[index52].stack), new Vector2((float) num176 + 10f * scale1, (float) num177 + 26f * scale1), color26, 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index52].useAmmo > 0)
              {
                int useAmmo = Main.player[Main.myPlayer].inventory[index52].useAmmo;
                int num179 = 0;
                for (int index53 = 0; index53 < 48; ++index53)
                {
                  if (Main.player[Main.myPlayer].inventory[index53].ammo == useAmmo)
                    num179 += Main.player[Main.myPlayer].inventory[index53].stack;
                }
                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) num179), new Vector2((float) num176 + 8f * scale1, (float) num177 + 30f * scale1), color26, 0.0f, new Vector2(), scale1 * 0.8f, SpriteEffects.None, 0.0f);
              }
              else if (Main.player[Main.myPlayer].inventory[index52].type == 509)
              {
                int num180 = 0;
                for (int index54 = 0; index54 < 48; ++index54)
                {
                  if (Main.player[Main.myPlayer].inventory[index54].type == 530)
                    num180 += Main.player[Main.myPlayer].inventory[index54].stack;
                }
                this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) num180), new Vector2((float) num176 + 8f * scale1, (float) num177 + 30f * scale1), color26, 0.0f, new Vector2(), scale1 * 0.8f, SpriteEffects.None, 0.0f);
              }
              string text24 = string.Concat((object) (index52 + 1));
              if (text24 == "10")
                text24 = "0";
              this.spriteBatch.DrawString(Main.fontItemStack, text24, new Vector2((float) num176 + 8f * Main.hotbarScale[index52], (float) num177 + 4f * Main.hotbarScale[index52]), new Microsoft.Xna.Framework.Color((int) color26.R / 2, (int) color26.G / 2, (int) color26.B / 2, (int) color26.A / 2), 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
              if (Main.player[Main.myPlayer].inventory[index52].potion)
              {
                Microsoft.Xna.Framework.Color color27 = Main.player[Main.myPlayer].inventory[index52].GetAlpha(color26);
                float num181 = (float) Main.player[Main.myPlayer].potionDelay / (float) Main.player[Main.myPlayer].potionDelayTime;
                color27 = new Microsoft.Xna.Framework.Color((int) (byte) ((float) color27.R * num181), (int) (byte) ((float) color27.G * num181), (int) (byte) ((float) color27.B * num181), (int) (byte) ((float) color27.A * num181));
                this.spriteBatch.Draw(Main.cdTexture, new Vector2((float) ((double) num176 + 26.0 * (double) Main.hotbarScale[index52] - (double) Main.cdTexture.Width * 0.5 * (double) scale2), (float) ((double) num177 + 26.0 * (double) Main.hotbarScale[index52] - (double) Main.cdTexture.Height * 0.5 * (double) scale2)), new Rectangle?(new Rectangle(0, 0, Main.cdTexture.Width, Main.cdTexture.Height)), color27, 0.0f, new Vector2(), scale2, SpriteEffects.None, 0.0f);
              }
            }
            num176 += (int) ((double) Main.inventoryBackTexture.Width * (double) Main.hotbarScale[index52]) + 4;
          }
        }
        if (Main.mouseItem.stack <= 0)
          Main.mouseItem.type = 0;
        if (cursorText1 != null && cursorText1 != "" && Main.mouseItem.type == 0)
        {
          Main.player[Main.myPlayer].showItemIcon = false;
          this.MouseText(cursorText1, rare1);
          flag1 = true;
        }
        if (Main.chatMode)
        {
          ++this.textBlinkerCount;
          if (this.textBlinkerCount >= 20)
          {
            this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
            this.textBlinkerCount = 0;
          }
          string chatText = Main.chatText;
          if (this.textBlinkerState == 1)
            chatText += "|";
          this.spriteBatch.Draw(Main.textBackTexture, new Vector2(78f, (float) (Main.screenHeight - 36)), new Rectangle?(new Rectangle(0, 0, Main.textBackTexture.Width, Main.textBackTexture.Height)), new Microsoft.Xna.Framework.Color(100, 100, 100, 100), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 5; ++index)
          {
            int num182 = 0;
            int num183 = 0;
            Microsoft.Xna.Framework.Color color28 = Microsoft.Xna.Framework.Color.Black;
            if (index == 0)
              num182 = -2;
            if (index == 1)
              num182 = 2;
            if (index == 2)
              num183 = -2;
            if (index == 3)
              num183 = 2;
            if (index == 4)
              color28 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
            this.spriteBatch.DrawString(Main.fontMouseText, chatText, new Vector2((float) (88 + num182), (float) (Main.screenHeight - 30 + num183)), color28, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
        }
        for (int index55 = 0; index55 < Main.numChatLines; ++index55)
        {
          if (Main.chatMode || Main.chatLine[index55].showTime > 0)
          {
            float num184 = (float) Main.mouseTextColor / (float) byte.MaxValue;
            for (int index56 = 0; index56 < 5; ++index56)
            {
              int num185 = 0;
              int num186 = 0;
              Microsoft.Xna.Framework.Color color29 = Microsoft.Xna.Framework.Color.Black;
              if (index56 == 0)
                num185 = -2;
              if (index56 == 1)
                num185 = 2;
              if (index56 == 2)
                num186 = -2;
              if (index56 == 3)
                num186 = 2;
              if (index56 == 4)
                color29 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.chatLine[index55].color.R * (double) num184), (int) (byte) ((double) Main.chatLine[index55].color.G * (double) num184), (int) (byte) ((double) Main.chatLine[index55].color.B * (double) num184), (int) Main.mouseTextColor);
              this.spriteBatch.DrawString(Main.fontMouseText, Main.chatLine[index55].text, new Vector2((float) (88 + num185), (float) (Main.screenHeight - 30 + num186 - 28 - index55 * 21)), color29, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
        if (Main.player[Main.myPlayer].dead)
        {
          string text25 = Lang.inter[38];
          this.spriteBatch.DrawString(Main.fontDeathText, text25, new Vector2((float) (Main.screenWidth / 2 - text25.Length * 10), (float) (Main.screenHeight / 2 - 20)), Main.player[Main.myPlayer].GetDeathAlpha(new Microsoft.Xna.Framework.Color(0, 0, 0, 0)), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
        }
        this.spriteBatch.Draw(Main.cursorTexture, new Vector2((float) (Main.mouseX + 1), (float) (Main.mouseY + 1)), new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height)), new Microsoft.Xna.Framework.Color((int) ((double) Main.cursorColor.R * 0.200000002980232), (int) ((double) Main.cursorColor.G * 0.200000002980232), (int) ((double) Main.cursorColor.B * 0.200000002980232), (int) ((double) Main.cursorColor.A * 0.5)), 0.0f, new Vector2(), Main.cursorScale * 1.1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(Main.cursorTexture, new Vector2((float) Main.mouseX, (float) Main.mouseY), new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height)), Main.cursorColor, 0.0f, new Vector2(), Main.cursorScale, SpriteEffects.None, 0.0f);
        if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
        {
          this.mouseNPC = -1;
          Main.player[Main.myPlayer].showItemIcon = false;
          Main.player[Main.myPlayer].showItemIcon2 = 0;
          flag1 = true;
          float num187 = 1f;
          if (Main.itemTexture[Main.mouseItem.type].Width > 32 || Main.itemTexture[Main.mouseItem.type].Height > 32)
            num187 = Main.itemTexture[Main.mouseItem.type].Width <= Main.itemTexture[Main.mouseItem.type].Height ? 32f / (float) Main.itemTexture[Main.mouseItem.type].Height : 32f / (float) Main.itemTexture[Main.mouseItem.type].Width;
          float num188 = 1f * Main.cursorScale;
          Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
          float scale = num187 * num188;
          this.spriteBatch.Draw(Main.itemTexture[Main.mouseItem.type], new Vector2((float) ((double) Main.mouseX + 26.0 * (double) num188 - (double) Main.itemTexture[Main.mouseItem.type].Width * 0.5 * (double) scale), (float) ((double) Main.mouseY + 26.0 * (double) num188 - (double) Main.itemTexture[Main.mouseItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height)), Main.mouseItem.GetAlpha(white), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
          if (Main.mouseItem.color != new Microsoft.Xna.Framework.Color())
            this.spriteBatch.Draw(Main.itemTexture[Main.mouseItem.type], new Vector2((float) ((double) Main.mouseX + 26.0 * (double) num188 - (double) Main.itemTexture[Main.mouseItem.type].Width * 0.5 * (double) scale), (float) ((double) Main.mouseY + 26.0 * (double) num188 - (double) Main.itemTexture[Main.mouseItem.type].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height)), Main.mouseItem.GetColor(white), 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
          if (Main.mouseItem.stack > 1)
            this.spriteBatch.DrawString(Main.fontItemStack, string.Concat((object) Main.mouseItem.stack), new Vector2((float) Main.mouseX + 10f * num188, (float) Main.mouseY + 26f * num188), white, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
        }
        else if (this.mouseNPC > -1)
        {
          Main.player[Main.myPlayer].mouseInterface = true;
          flag1 = false;
          float scale = 1f * Main.cursorScale;
          this.spriteBatch.Draw(Main.npcHeadTexture[this.mouseNPC], new Vector2((float) ((double) Main.mouseX + 26.0 * (double) scale - (double) Main.npcHeadTexture[this.mouseNPC].Width * 0.5 * (double) scale), (float) ((double) Main.mouseY + 26.0 * (double) scale - (double) Main.npcHeadTexture[this.mouseNPC].Height * 0.5 * (double) scale)), new Rectangle?(new Rectangle(0, 0, Main.npcHeadTexture[this.mouseNPC].Width, Main.npcHeadTexture[this.mouseNPC].Height)), Microsoft.Xna.Framework.Color.White, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
          if (Main.mouseRight && Main.mouseRightRelease)
          {
            Main.PlaySound(12);
            this.mouseNPC = -1;
          }
          if (Main.mouseLeft && Main.mouseLeftRelease)
          {
            if (this.mouseNPC == 0)
            {
              if (WorldGen.MoveNPC((int) (((double) Main.mouseX + (double) Main.screenPosition.X) / 16.0), (int) (((double) Main.mouseY + (double) Main.screenPosition.Y) / 16.0), -1))
                Main.NewText(Lang.inter[39], G: (byte) 240, B: (byte) 20);
            }
            else
            {
              int n = 0;
              for (int index = 0; index < 200; ++index)
              {
                if (Main.npc[index].active && Main.npc[index].type == NPC.NumToType(this.mouseNPC))
                {
                  n = index;
                  break;
                }
              }
              if (n >= 0)
              {
                int x = (int) (((double) Main.mouseX + (double) Main.screenPosition.X) / 16.0);
                int y = (int) (((double) Main.mouseY + (double) Main.screenPosition.Y) / 16.0);
                if (WorldGen.MoveNPC(x, y, n))
                {
                  this.mouseNPC = -1;
                  WorldGen.moveRoom(x, y, n);
                  Main.PlaySound(12);
                }
              }
              else
                this.mouseNPC = 0;
            }
          }
        }
        Rectangle rectangle5 = new Rectangle((int) ((double) Main.mouseX + (double) Main.screenPosition.X), (int) ((double) Main.mouseY + (double) Main.screenPosition.Y), 1, 1);
        if (!flag1)
        {
          int num189 = 26 * Main.player[Main.myPlayer].statLifeMax / num48;
          int num190 = 0;
          if (Main.player[Main.myPlayer].statLifeMax > 200)
          {
            num189 = 260;
            num190 += 26;
          }
          if (Main.mouseX > 500 + num46 && Main.mouseX < 500 + num189 + num46 && Main.mouseY > 32 && Main.mouseY < 32 + Main.heartTexture.Height + num190)
          {
            Main.player[Main.myPlayer].showItemIcon = false;
            this.MouseText(Main.player[Main.myPlayer].statLife.ToString() + "/" + (object) Main.player[Main.myPlayer].statLifeMax);
            flag1 = true;
          }
        }
        if (!flag1)
        {
          int num191 = 24;
          int num192 = 28 * Main.player[Main.myPlayer].statManaMax2 / num53;
          if (Main.mouseX > 762 + num46 && Main.mouseX < 762 + num191 + num46 && Main.mouseY > 30 && Main.mouseY < 30 + num192)
          {
            Main.player[Main.myPlayer].showItemIcon = false;
            this.MouseText(Main.player[Main.myPlayer].statMana.ToString() + "/" + (object) Main.player[Main.myPlayer].statManaMax2);
            flag1 = true;
          }
        }
        if (!flag1)
        {
          for (int index = 0; index < 200; ++index)
          {
            if (Main.item[index].active)
            {
              Rectangle rectangle6 = new Rectangle((int) ((double) Main.item[index].position.X + (double) Main.item[index].width * 0.5 - (double) Main.itemTexture[Main.item[index].type].Width * 0.5), (int) ((double) Main.item[index].position.Y + (double) Main.item[index].height - (double) Main.itemTexture[Main.item[index].type].Height), Main.itemTexture[Main.item[index].type].Width, Main.itemTexture[Main.item[index].type].Height);
              if (rectangle5.Intersects(rectangle6))
              {
                Main.player[Main.myPlayer].showItemIcon = false;
                string cursorText3 = Main.item[index].AffixName();
                if (Main.item[index].stack > 1)
                  cursorText3 = cursorText3 + " (" + (object) Main.item[index].stack + ")";
                if (Main.item[index].owner < (int) byte.MaxValue && Main.showItemOwner)
                  cursorText3 = cursorText3 + " <" + Main.player[Main.item[index].owner].name + ">";
                int rare2 = Main.item[index].rare;
                this.MouseText(cursorText3, rare2);
                flag1 = true;
                break;
              }
            }
          }
        }
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active && Main.myPlayer != index && !Main.player[index].dead)
          {
            Rectangle rectangle7 = new Rectangle((int) ((double) Main.player[index].position.X + (double) Main.player[index].width * 0.5 - 16.0), (int) ((double) Main.player[index].position.Y + (double) Main.player[index].height - 48.0), 32, 48);
            if (!flag1 && rectangle5.Intersects(rectangle7))
            {
              Main.player[Main.myPlayer].showItemIcon = false;
              int num193 = Main.player[index].statLife;
              if (num193 < 0)
                num193 = 0;
              string cursorText4 = Main.player[index].name + ": " + (object) num193 + "/" + (object) Main.player[index].statLifeMax;
              if (Main.player[index].hostile)
                cursorText4 += " (PvP)";
              this.MouseText(cursorText4, diff: Main.player[index].difficulty);
            }
          }
        }
        if (!flag1)
        {
          for (int index57 = 0; index57 < 200; ++index57)
          {
            if (Main.npc[index57].active)
            {
              Rectangle rectangle8 = new Rectangle((int) ((double) Main.npc[index57].position.X + (double) Main.npc[index57].width * 0.5 - (double) Main.npcTexture[Main.npc[index57].type].Width * 0.5), (int) ((double) Main.npc[index57].position.Y + (double) Main.npc[index57].height - (double) (Main.npcTexture[Main.npc[index57].type].Height / Main.npcFrameCount[Main.npc[index57].type])), Main.npcTexture[Main.npc[index57].type].Width, Main.npcTexture[Main.npc[index57].type].Height / Main.npcFrameCount[Main.npc[index57].type]);
              if (Main.npc[index57].type >= 87 && Main.npc[index57].type <= 92)
                rectangle8 = new Rectangle((int) ((double) Main.npc[index57].position.X + (double) Main.npc[index57].width * 0.5 - 32.0), (int) ((double) Main.npc[index57].position.Y + (double) Main.npc[index57].height * 0.5 - 32.0), 64, 64);
              if (rectangle5.Intersects(rectangle8) && (Main.npc[index57].type != 85 || (double) Main.npc[index57].ai[0] != 0.0))
              {
                bool flag9 = false;
                if ((Main.npc[index57].townNPC || Main.npc[index57].type == 105 || Main.npc[index57].type == 106 || Main.npc[index57].type == 123) && new Rectangle((int) ((double) Main.player[Main.myPlayer].position.X + (double) (Main.player[Main.myPlayer].width / 2) - (double) (Player.tileRangeX * 16)), (int) ((double) Main.player[Main.myPlayer].position.Y + (double) (Main.player[Main.myPlayer].height / 2) - (double) (Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2).Intersects(new Rectangle((int) Main.npc[index57].position.X, (int) Main.npc[index57].position.Y, Main.npc[index57].width, Main.npc[index57].height)))
                  flag9 = true;
                if (flag9 && !Main.player[Main.myPlayer].dead)
                {
                  int num194 = -(Main.npc[index57].width / 2 + 8);
                  SpriteEffects effects = SpriteEffects.None;
                  if (Main.npc[index57].spriteDirection == -1)
                  {
                    effects = SpriteEffects.FlipHorizontally;
                    num194 = Main.npc[index57].width / 2 + 8;
                  }
                  this.spriteBatch.Draw(Main.chatTexture, new Vector2(Main.npc[index57].position.X + (float) (Main.npc[index57].width / 2) - Main.screenPosition.X - (float) (Main.chatTexture.Width / 2) - (float) num194, Main.npc[index57].position.Y - (float) Main.chatTexture.Height - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chatTexture.Width, Main.chatTexture.Height)), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, effects, 0.0f);
                  if (Main.mouseRight && Main.npcChatRelease)
                  {
                    Main.npcChatRelease = false;
                    if (Main.player[Main.myPlayer].talkNPC != index57)
                    {
                      Main.npcShop = 0;
                      Main.craftGuide = false;
                      Main.player[Main.myPlayer].dropItemCheck();
                      Recipe.FindRecipes();
                      Main.player[Main.myPlayer].sign = -1;
                      Main.editSign = false;
                      Main.player[Main.myPlayer].talkNPC = index57;
                      Main.playerInventory = false;
                      Main.player[Main.myPlayer].chest = -1;
                      Main.npcChatText = Main.npc[index57].GetChat();
                      Main.PlaySound(24);
                    }
                  }
                }
                Main.player[Main.myPlayer].showItemIcon = false;
                string cursorText5 = Main.npc[index57].displayName;
                int index58 = index57;
                if (Main.npc[index57].realLife >= 0)
                  index58 = Main.npc[index57].realLife;
                if (Main.npc[index58].lifeMax > 1 && !Main.npc[index58].dontTakeDamage)
                  cursorText5 = cursorText5 + ": " + (object) Main.npc[index58].life + "/" + (object) Main.npc[index58].lifeMax;
                this.MouseText(cursorText5);
                break;
              }
            }
          }
        }
        Main.npcChatRelease = !Main.mouseRight;
        if (Main.player[Main.myPlayer].showItemIcon && (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type > 0 || Main.player[Main.myPlayer].showItemIcon2 > 0))
        {
          int index = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type;
          Microsoft.Xna.Framework.Color color30 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetAlpha(Microsoft.Xna.Framework.Color.White);
          Microsoft.Xna.Framework.Color color31 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetColor(Microsoft.Xna.Framework.Color.White);
          if (Main.player[Main.myPlayer].showItemIcon2 > 0)
          {
            index = Main.player[Main.myPlayer].showItemIcon2;
            color30 = Microsoft.Xna.Framework.Color.White;
            color31 = new Microsoft.Xna.Framework.Color();
          }
          float cursorScale = Main.cursorScale;
          this.spriteBatch.Draw(Main.itemTexture[index], new Vector2((float) (Main.mouseX + 10), (float) (Main.mouseY + 10)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[index].Width, Main.itemTexture[index].Height)), color30, 0.0f, new Vector2(), cursorScale, SpriteEffects.None, 0.0f);
          if (Main.player[Main.myPlayer].showItemIcon2 == 0 && Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].color != new Microsoft.Xna.Framework.Color())
            this.spriteBatch.Draw(Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type], new Vector2((float) (Main.mouseX + 10), (float) (Main.mouseY + 10)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Height)), color31, 0.0f, new Vector2(), cursorScale, SpriteEffects.None, 0.0f);
        }
        Main.player[Main.myPlayer].showItemIcon = false;
        Main.player[Main.myPlayer].showItemIcon2 = 0;
      }
    }

    protected void QuitGame()
    {
      Steam.Kill();
      this.Exit();
    }

    protected Microsoft.Xna.Framework.Color randColor()
    {
      int r = 0;
      int g = 0;
      int b;
      for (b = 0; r + b + g <= 150; b = Main.rand.Next(256))
      {
        r = Main.rand.Next(256);
        g = Main.rand.Next(256);
      }
      return new Microsoft.Xna.Framework.Color(r, g, b, (int) byte.MaxValue);
    }

    protected void DrawMenu()
    {
      Main.render = false;
      Star.UpdateStars();
      Cloud.UpdateClouds();
      Main.holyTiles = 0;
      Main.evilTiles = 0;
      Main.jungleTiles = 0;
      Main.chatMode = false;
      for (int index = 0; index < Main.numChatLines; ++index)
        Main.chatLine[index] = new ChatLine();
      this.DrawFPS();
      Main.screenLastPosition = Main.screenPosition;
      Main.screenPosition.Y = (float) (Main.worldSurface * 16.0) - (float) Main.screenHeight;
      if (Main.grabSky)
        Main.screenPosition.X += (float) (Main.mouseX - Main.screenWidth / 2) * 0.02f;
      else
        Main.screenPosition.X += 2f;
      if ((double) Main.screenPosition.X > 2147483520.0)
        Main.screenPosition.X = 0.0f;
      if ((double) Main.screenPosition.X < -2147483520.0)
        Main.screenPosition.X = 0.0f;
      Main.background = 0;
      byte num1 = (byte) (((int) byte.MaxValue + (int) Main.tileColor.R * 2) / 3);
      Microsoft.Xna.Framework.Color color1 = new Microsoft.Xna.Framework.Color((int) num1, (int) num1, (int) num1, (int) byte.MaxValue);
      this.logoRotation += this.logoRotationSpeed * 3E-05f;
      if ((double) this.logoRotation > 0.1)
        this.logoRotationDirection = -1f;
      else if ((double) this.logoRotation < -0.1)
        this.logoRotationDirection = 1f;
      if ((double) this.logoRotationSpeed < 20.0 & (double) this.logoRotationDirection == 1.0)
        ++this.logoRotationSpeed;
      else if ((double) this.logoRotationSpeed > -20.0 & (double) this.logoRotationDirection == -1.0)
        --this.logoRotationSpeed;
      this.logoScale += this.logoScaleSpeed * 1E-05f;
      if ((double) this.logoScale > 1.1)
        this.logoScaleDirection = -1f;
      else if ((double) this.logoScale < 0.9)
        this.logoScaleDirection = 1f;
      if ((double) this.logoScaleSpeed < 50.0 & (double) this.logoScaleDirection == 1.0)
        ++this.logoScaleSpeed;
      else if ((double) this.logoScaleSpeed > -50.0 & (double) this.logoScaleDirection == -1.0)
        --this.logoScaleSpeed;
      Microsoft.Xna.Framework.Color color2 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) color1.R * ((double) Main.LogoA / (double) byte.MaxValue)), (int) (byte) ((double) color1.G * ((double) Main.LogoA / (double) byte.MaxValue)), (int) (byte) ((double) color1.B * ((double) Main.LogoA / (double) byte.MaxValue)), (int) (byte) ((double) color1.A * ((double) Main.LogoA / (double) byte.MaxValue)));
      Microsoft.Xna.Framework.Color color3 = new Microsoft.Xna.Framework.Color((int) (byte) ((double) color1.R * ((double) Main.LogoB / (double) byte.MaxValue)), (int) (byte) ((double) color1.G * ((double) Main.LogoB / (double) byte.MaxValue)), (int) (byte) ((double) color1.B * ((double) Main.LogoB / (double) byte.MaxValue)), (int) (byte) ((double) color1.A * ((double) Main.LogoB / (double) byte.MaxValue)));
      Main.LogoT = false;
      if (!Main.LogoT)
        this.spriteBatch.Draw(Main.logoTexture, new Vector2((float) (Main.screenWidth / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color2, this.logoRotation, new Vector2((float) (Main.logoTexture.Width / 2), (float) (Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0.0f);
      else
        this.spriteBatch.Draw(Main.logo3Texture, new Vector2((float) (Main.screenWidth / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color2, this.logoRotation, new Vector2((float) (Main.logoTexture.Width / 2), (float) (Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(Main.logo2Texture, new Vector2((float) (Main.screenWidth / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color3, this.logoRotation, new Vector2((float) (Main.logoTexture.Width / 2), (float) (Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0.0f);
      if (Main.dayTime)
      {
        Main.LogoA += 2;
        if (Main.LogoA > (int) byte.MaxValue)
          Main.LogoA = (int) byte.MaxValue;
        --Main.LogoB;
        if (Main.LogoB < 0)
          Main.LogoB = 0;
      }
      else
      {
        Main.LogoB += 2;
        if (Main.LogoB > (int) byte.MaxValue)
          Main.LogoB = (int) byte.MaxValue;
        --Main.LogoA;
        if (Main.LogoA < 0)
        {
          Main.LogoA = 0;
          Main.LogoT = true;
        }
      }
      int num2 = 250;
      int num3 = Main.screenWidth / 2;
      int num4 = 80;
      int num5 = 0;
      int menuMode = Main.menuMode;
      int index1 = -1;
      int num6 = 0;
      int num7 = 0;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      int num8 = 0;
      bool[] flagArray1 = new bool[Main.maxMenuItems];
      bool[] flagArray2 = new bool[Main.maxMenuItems];
      int[] numArray1 = new int[Main.maxMenuItems];
      int[] numArray2 = new int[Main.maxMenuItems];
      byte[] numArray3 = new byte[Main.maxMenuItems];
      float[] numArray4 = new float[Main.maxMenuItems];
      bool[] flagArray3 = new bool[Main.maxMenuItems];
      for (int index2 = 0; index2 < Main.maxMenuItems; ++index2)
      {
        flagArray1[index2] = false;
        flagArray2[index2] = false;
        numArray1[index2] = 0;
        numArray2[index2] = 0;
        numArray4[index2] = 1f;
      }
      string[] strArray1 = new string[Main.maxMenuItems];
      if (Main.menuMode == -1)
        Main.menuMode = 0;
      if (Main.menuMode == 1212)
      {
        strArray1[0] = this.focusMenu != 2 ? (this.focusMenu != 3 ? (this.focusMenu != 4 ? (this.focusMenu != 5 ? "Select language" : "Seleccione el idioma") : "Sélectionnez la langue") : "Selezionare la lingua") : "Wählen Sie die Sprache";
        num4 = 50;
        num2 = 200;
        numArray1[1] = 25;
        numArray1[2] = 25;
        numArray1[3] = 25;
        numArray1[4] = 25;
        numArray1[5] = 25;
        flagArray1[0] = true;
        strArray1[1] = "English";
        strArray1[2] = "Deutsch";
        strArray1[3] = "Italiano";
        strArray1[4] = "Française";
        strArray1[5] = "Español";
        num5 = 6;
        if (this.selectedMenu >= 1)
        {
          Lang.lang = this.selectedMenu;
          Lang.setLang();
          Main.menuMode = 0;
          Main.PlaySound(10);
          this.SaveSettings();
        }
      }
      else if (Main.menuMode == 1213)
      {
        strArray1[0] = this.focusMenu != 1 ? (this.focusMenu != 2 ? (this.focusMenu != 3 ? (this.focusMenu != 4 ? (this.focusMenu != 5 ? Lang.menu[102] : "Seleccione el idioma") : "Sélectionnez la langue") : "Selezionare la lingua") : "Wählen Sie die Sprache") : "Select language";
        num4 = 48;
        num2 = 180;
        numArray1[1] = 25;
        numArray1[2] = 25;
        numArray1[3] = 25;
        numArray1[4] = 25;
        numArray1[5] = 25;
        numArray1[6] = 50;
        flagArray1[0] = true;
        strArray1[1] = "English";
        strArray1[2] = "Deutsch";
        strArray1[3] = "Italiano";
        strArray1[4] = "Française";
        strArray1[5] = "Español";
        strArray1[6] = Lang.menu[5];
        num5 = 7;
        if (this.selectedMenu == 6)
        {
          Main.menuMode = 11;
          Main.PlaySound(11);
        }
        else if (this.selectedMenu >= 1)
        {
          Lang.lang = this.selectedMenu;
          Lang.setLang();
          Main.PlaySound(12);
          this.SaveSettings();
        }
      }
      else if (Main.netMode == 2)
      {
        bool flag4 = true;
        for (int index3 = 0; index3 < 8; ++index3)
        {
          if (index3 < (int) byte.MaxValue)
          {
            try
            {
              strArray1[index3] = Netplay.serverSock[index3].statusText;
              if (Netplay.serverSock[index3].active)
              {
                if (Main.showSpam)
                {
                  string[] strArray2;
                  int index4;
                  string str = (strArray2 = strArray1)[(IntPtr) (index4 = index3)] + " (" + (object) NetMessage.buffer[index3].spamCount + ")";
                  strArray2[index4] = str;
                }
              }
            }
            catch
            {
              strArray1[index3] = "";
            }
            flagArray1[index3] = true;
            if (strArray1[index3] != "" && strArray1[index3] != null)
              flag4 = false;
          }
        }
        if (flag4)
        {
          strArray1[0] = Lang.menu[0];
          strArray1[1] = Lang.menu[1] + (object) Netplay.serverPort + ".";
        }
        num5 = 11;
        strArray1[9] = Main.statusText;
        flagArray1[9] = true;
        num2 = 170;
        num4 = 30;
        numArray1[10] = 20;
        numArray1[10] = 40;
        strArray1[10] = Lang.menu[2];
        if (this.selectedMenu == 10)
        {
          Netplay.disconnect = true;
          Main.PlaySound(11);
        }
      }
      else if (Main.menuMode == 31)
      {
        string password = Netplay.password;
        Netplay.password = Main.GetInputText(Netplay.password);
        if (password != Netplay.password)
          Main.PlaySound(12);
        strArray1[0] = Lang.menu[3];
        ++this.textBlinkerCount;
        if (this.textBlinkerCount >= 20)
        {
          this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
          this.textBlinkerCount = 0;
        }
        strArray1[1] = Netplay.password;
        if (this.textBlinkerState == 1)
        {
          string[] strArray3;
          (strArray3 = strArray1)[1] = strArray3[1] + "|";
          numArray2[1] = 1;
        }
        else
        {
          string[] strArray4;
          (strArray4 = strArray1)[1] = strArray4[1] + " ";
        }
        flagArray1[0] = true;
        flagArray1[1] = true;
        numArray1[1] = -20;
        numArray1[2] = 20;
        strArray1[2] = Lang.menu[4];
        strArray1[3] = Lang.menu[5];
        num5 = 4;
        if (this.selectedMenu == 3)
        {
          Main.PlaySound(11);
          Main.menuMode = 0;
          Netplay.disconnect = true;
          Netplay.password = "";
        }
        else if (this.selectedMenu == 2 || Main.inputTextEnter)
        {
          NetMessage.SendData(38, text: Netplay.password);
          Main.menuMode = 14;
        }
      }
      else
      {
        if (Main.netMode != 1)
        {
          switch (Main.menuMode)
          {
            case 0:
              Main.menuMultiplayer = false;
              Main.menuServer = false;
              Main.netMode = 0;
              strArray1[0] = Lang.menu[12];
              strArray1[1] = Lang.menu[13];
              strArray1[2] = Lang.menu[14];
              strArray1[3] = Lang.menu[15];
              num5 = 4;
              if (this.selectedMenu == 3)
                this.QuitGame();
              if (this.selectedMenu == 1)
              {
                Main.PlaySound(10);
                Main.menuMode = 12;
              }
              if (this.selectedMenu == 2)
              {
                Main.PlaySound(10);
                Main.menuMode = 11;
              }
              if (this.selectedMenu == 0)
              {
                Main.PlaySound(10);
                Main.menuMode = 1;
                Main.LoadPlayers();
                goto label_482;
              }
              else
                goto label_482;
            case 1:
              Main.myPlayer = 0;
              num2 = 190;
              num4 = 50;
              strArray1[5] = Lang.menu[16];
              strArray1[6] = Lang.menu[17];
              switch (Main.numLoadPlayers)
              {
                case 0:
                  flagArray2[6] = true;
                  strArray1[6] = "";
                  break;
                case 5:
                  flagArray2[5] = true;
                  strArray1[5] = "";
                  break;
              }
              strArray1[7] = Lang.menu[5];
              for (int index5 = 0; index5 < 5; ++index5)
              {
                if (index5 < Main.numLoadPlayers)
                {
                  strArray1[index5] = Main.loadPlayer[index5].name;
                  numArray3[index5] = Main.loadPlayer[index5].difficulty;
                }
                else
                  strArray1[index5] = (string) null;
              }
              num5 = 8;
              if (this.focusMenu >= 0 && this.focusMenu < Main.numLoadPlayers)
              {
                index1 = this.focusMenu;
                Vector2 vector2 = Main.fontDeathText.MeasureString(strArray1[index1]);
                num6 = (int) ((double) (Main.screenWidth / 2) + (double) vector2.X * 0.5 + 10.0);
                num7 = num2 + num4 * this.focusMenu + 4;
              }
              if (this.selectedMenu == 7)
              {
                Main.autoJoin = false;
                Main.autoPass = false;
                Main.PlaySound(11);
                if (Main.menuMultiplayer)
                {
                  Main.menuMode = 12;
                  Main.menuMultiplayer = false;
                  Main.menuServer = false;
                  goto label_482;
                }
                else
                {
                  Main.menuMode = 0;
                  goto label_482;
                }
              }
              else if (this.selectedMenu == 5)
              {
                Main.loadPlayer[Main.numLoadPlayers] = new Player();
                Main.loadPlayer[Main.numLoadPlayers].inventory[0].SetDefaults("Copper Shortsword");
                Main.loadPlayer[Main.numLoadPlayers].inventory[0].Prefix(-1);
                Main.loadPlayer[Main.numLoadPlayers].inventory[1].SetDefaults("Copper Pickaxe");
                Main.loadPlayer[Main.numLoadPlayers].inventory[1].Prefix(-1);
                Main.loadPlayer[Main.numLoadPlayers].inventory[2].SetDefaults("Copper Axe");
                Main.loadPlayer[Main.numLoadPlayers].inventory[2].Prefix(-1);
                Main.PlaySound(10);
                Main.menuMode = 2;
                goto label_482;
              }
              else if (this.selectedMenu == 6)
              {
                Main.PlaySound(10);
                Main.menuMode = 4;
                goto label_482;
              }
              else if (this.selectedMenu >= 0)
              {
                if (Main.menuMultiplayer)
                {
                  this.selectedPlayer = this.selectedMenu;
                  Main.player[Main.myPlayer] = (Player) Main.loadPlayer[this.selectedPlayer].Clone();
                  Main.playerPathName = Main.loadPlayerPath[this.selectedPlayer];
                  Main.PlaySound(10);
                  if (Main.autoJoin)
                  {
                    if (Netplay.SetIP(Main.getIP))
                    {
                      Main.menuMode = 10;
                      Netplay.StartClient();
                    }
                    else if (Netplay.SetIP2(Main.getIP))
                    {
                      Main.menuMode = 10;
                      Netplay.StartClient();
                    }
                    Main.autoJoin = false;
                    goto label_482;
                  }
                  else if (Main.menuServer)
                  {
                    Main.LoadWorlds();
                    Main.menuMode = 6;
                    goto label_482;
                  }
                  else
                  {
                    Main.menuMode = 13;
                    Main.clrInput();
                    goto label_482;
                  }
                }
                else
                {
                  Main.myPlayer = 0;
                  this.selectedPlayer = this.selectedMenu;
                  Main.player[Main.myPlayer] = (Player) Main.loadPlayer[this.selectedPlayer].Clone();
                  Main.playerPathName = Main.loadPlayerPath[this.selectedPlayer];
                  Main.LoadWorlds();
                  Main.PlaySound(10);
                  Main.menuMode = 6;
                  goto label_482;
                }
              }
              else
                goto label_482;
            case 2:
              if (this.selectedMenu == 0)
              {
                Main.menuMode = 17;
                Main.PlaySound(10);
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].hairColor;
              }
              if (this.selectedMenu == 1)
              {
                Main.menuMode = 18;
                Main.PlaySound(10);
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].eyeColor;
              }
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 19;
                Main.PlaySound(10);
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].skinColor;
              }
              if (this.selectedMenu == 3)
              {
                Main.menuMode = 20;
                Main.PlaySound(10);
              }
              strArray1[0] = Lang.menu[18];
              strArray1[1] = Lang.menu[19];
              strArray1[2] = Lang.menu[20];
              strArray1[3] = Lang.menu[21];
              num2 = 220;
              for (int index6 = 0; index6 < 9; ++index6)
                numArray4[index6] = index6 >= 6 ? 0.9f : 0.75f;
              num4 = 38;
              numArray1[6] = 6;
              numArray1[7] = 12;
              numArray1[8] = 18;
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 176;
              strArray1[4] = !Main.loadPlayer[index1].male ? Lang.menu[23] : Lang.menu[22];
              if (this.selectedMenu == 4)
              {
                if (Main.loadPlayer[index1].male)
                {
                  Main.PlaySound(20);
                  Main.loadPlayer[index1].male = false;
                }
                else
                {
                  Main.PlaySound(1);
                  Main.loadPlayer[index1].male = true;
                }
              }
              if (Main.loadPlayer[index1].difficulty == (byte) 2)
              {
                strArray1[5] = Lang.menu[24];
                numArray3[5] = Main.loadPlayer[index1].difficulty;
              }
              else if (Main.loadPlayer[index1].difficulty == (byte) 1)
              {
                strArray1[5] = Lang.menu[25];
                numArray3[5] = Main.loadPlayer[index1].difficulty;
              }
              else
                strArray1[5] = Lang.menu[26];
              if (this.selectedMenu == 5)
              {
                Main.PlaySound(10);
                Main.menuMode = 222;
              }
              if (this.selectedMenu == 7)
              {
                Main.PlaySound(12);
                Main.loadPlayer[index1].hair = Main.rand.Next(36);
                Main.loadPlayer[index1].eyeColor = this.randColor();
                while ((int) Main.loadPlayer[index1].eyeColor.R + (int) Main.loadPlayer[index1].eyeColor.G + (int) Main.loadPlayer[index1].eyeColor.B > 300)
                  Main.loadPlayer[index1].eyeColor = this.randColor();
                Main.loadPlayer[index1].hairColor = this.randColor();
                Main.loadPlayer[index1].pantsColor = this.randColor();
                Main.loadPlayer[index1].shirtColor = this.randColor();
                Main.loadPlayer[index1].shoeColor = this.randColor();
                Main.loadPlayer[index1].skinColor = this.randColor();
                float num9 = (float) Main.rand.Next(60, 120) * 0.01f;
                if ((double) num9 > 1.0)
                  num9 = 1f;
                Main.loadPlayer[index1].skinColor.R = (byte) ((double) Main.rand.Next(240, (int) byte.MaxValue) * (double) num9);
                Main.loadPlayer[index1].skinColor.G = (byte) ((double) Main.rand.Next(110, 140) * (double) num9);
                Main.loadPlayer[index1].skinColor.B = (byte) ((double) Main.rand.Next(75, 110) * (double) num9);
                Main.loadPlayer[index1].underShirtColor = this.randColor();
                switch (Main.loadPlayer[index1].hair + 1)
                {
                  case 5:
                  case 6:
                  case 7:
                  case 10:
                  case 12:
                  case 19:
                  case 22:
                  case 23:
                  case 26:
                  case 27:
                  case 30:
                  case 33:
                    Main.loadPlayer[index1].male = false;
                    break;
                  default:
                    Main.loadPlayer[index1].male = true;
                    break;
                }
              }
              strArray1[7] = Lang.menu[27];
              strArray1[6] = Lang.menu[28];
              strArray1[8] = Lang.menu[5];
              num5 = 9;
              if (this.selectedMenu == 8)
              {
                Main.PlaySound(11);
                Main.menuMode = 1;
                goto label_482;
              }
              else if (this.selectedMenu == 6)
              {
                Main.PlaySound(10);
                Main.loadPlayer[Main.numLoadPlayers].name = "";
                Main.menuMode = 3;
                Main.clrInput();
                goto label_482;
              }
              else
                goto label_482;
            case 3:
              string name = Main.loadPlayer[Main.numLoadPlayers].name;
              Main.loadPlayer[Main.numLoadPlayers].name = Main.GetInputText(Main.loadPlayer[Main.numLoadPlayers].name);
              if (Main.loadPlayer[Main.numLoadPlayers].name.Length > Player.nameLen)
                Main.loadPlayer[Main.numLoadPlayers].name = Main.loadPlayer[Main.numLoadPlayers].name.Substring(0, Player.nameLen);
              if (name != Main.loadPlayer[Main.numLoadPlayers].name)
                Main.PlaySound(12);
              strArray1[0] = Lang.menu[45];
              flagArray2[2] = true;
              if (Main.loadPlayer[Main.numLoadPlayers].name != "")
              {
                if (Main.loadPlayer[Main.numLoadPlayers].name.Substring(0, 1) == " ")
                  Main.loadPlayer[Main.numLoadPlayers].name = "";
                for (int startIndex = 0; startIndex < Main.loadPlayer[Main.numLoadPlayers].name.Length; ++startIndex)
                {
                  if (Main.loadPlayer[Main.numLoadPlayers].name.Substring(startIndex, 1) != " ")
                    flagArray2[2] = false;
                }
              }
              ++this.textBlinkerCount;
              if (this.textBlinkerCount >= 20)
              {
                this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
                this.textBlinkerCount = 0;
              }
              strArray1[1] = Main.loadPlayer[Main.numLoadPlayers].name;
              if (this.textBlinkerState == 1)
              {
                string[] strArray5;
                (strArray5 = strArray1)[1] = strArray5[1] + "|";
                numArray2[1] = 1;
              }
              else
              {
                string[] strArray6;
                (strArray6 = strArray1)[1] = strArray6[1] + " ";
              }
              flagArray1[0] = true;
              flagArray1[1] = true;
              numArray1[1] = -20;
              numArray1[2] = 20;
              strArray1[2] = Lang.menu[4];
              strArray1[3] = Lang.menu[5];
              num5 = 4;
              if (this.selectedMenu == 3)
              {
                Main.PlaySound(11);
                Main.menuMode = 2;
              }
              if (this.selectedMenu == 2 || !flagArray2[2] && Main.inputTextEnter)
              {
                Main.loadPlayer[Main.numLoadPlayers].name.Trim();
                Main.loadPlayerPath[Main.numLoadPlayers] = Main.nextLoadPlayer();
                Player.SavePlayer(Main.loadPlayer[Main.numLoadPlayers], Main.loadPlayerPath[Main.numLoadPlayers]);
                Main.LoadPlayers();
                Main.PlaySound(10);
                Main.menuMode = 1;
                goto label_482;
              }
              else
                goto label_482;
            case 4:
              num2 = 220;
              num4 = 60;
              strArray1[5] = Lang.menu[5];
              for (int index7 = 0; index7 < 5; ++index7)
              {
                if (index7 < Main.numLoadPlayers)
                {
                  strArray1[index7] = Main.loadPlayer[index7].name;
                  numArray3[index7] = Main.loadPlayer[index7].difficulty;
                }
                else
                  strArray1[index7] = (string) null;
              }
              num5 = 6;
              if (this.focusMenu >= 0 && this.focusMenu < Main.numLoadPlayers)
              {
                index1 = this.focusMenu;
                Vector2 vector2 = Main.fontDeathText.MeasureString(strArray1[index1]);
                num6 = (int) ((double) (Main.screenWidth / 2) + (double) vector2.X * 0.5 + 10.0);
                num7 = num2 + num4 * this.focusMenu + 4;
              }
              if (this.selectedMenu == 5)
              {
                Main.PlaySound(11);
                Main.menuMode = 1;
                goto label_482;
              }
              else if (this.selectedMenu >= 0)
              {
                this.selectedPlayer = this.selectedMenu;
                Main.PlaySound(10);
                Main.menuMode = 5;
                goto label_482;
              }
              else
                goto label_482;
            case 5:
              strArray1[0] = Lang.menu[46] + " " + Main.loadPlayer[this.selectedPlayer].name + "?";
              flagArray1[0] = true;
              strArray1[1] = Lang.menu[104];
              strArray1[2] = Lang.menu[105];
              num5 = 3;
              if (this.selectedMenu == 1)
              {
                Main.ErasePlayer(this.selectedPlayer);
                Main.PlaySound(10);
                Main.menuMode = 1;
                goto label_482;
              }
              else if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 1;
                goto label_482;
              }
              else
                goto label_482;
            case 6:
              num2 = 190;
              num4 = 50;
              strArray1[5] = Lang.menu[47];
              strArray1[6] = Lang.menu[17];
              switch (Main.numLoadWorlds)
              {
                case 0:
                  flagArray2[6] = true;
                  strArray1[6] = "";
                  break;
                case 5:
                  flagArray2[5] = true;
                  strArray1[5] = "";
                  break;
              }
              strArray1[7] = Lang.menu[5];
              for (int index8 = 0; index8 < 5; ++index8)
                strArray1[index8] = index8 >= Main.numLoadWorlds ? (string) null : Main.loadWorld[index8];
              num5 = 8;
              if (this.selectedMenu == 7)
              {
                Main.menuMode = !Main.menuMultiplayer ? 1 : 12;
                Main.PlaySound(11);
                goto label_482;
              }
              else if (this.selectedMenu == 5)
              {
                Main.PlaySound(10);
                Main.menuMode = 16;
                Main.newWorldName = Lang.gen[57] + " " + (object) (Main.numLoadWorlds + 1);
                goto label_482;
              }
              else if (this.selectedMenu == 6)
              {
                Main.PlaySound(10);
                Main.menuMode = 8;
                goto label_482;
              }
              else if (this.selectedMenu >= 0)
              {
                if (Main.menuMultiplayer)
                {
                  Main.PlaySound(10);
                  Main.worldPathName = Main.loadWorldPath[this.selectedMenu];
                  Main.menuMode = 30;
                  goto label_482;
                }
                else
                {
                  Main.PlaySound(10);
                  Main.worldPathName = Main.loadWorldPath[this.selectedMenu];
                  WorldGen.playWorld();
                  Main.menuMode = 10;
                  goto label_482;
                }
              }
              else
                goto label_482;
            case 7:
              string newWorldName = Main.newWorldName;
              Main.newWorldName = Main.GetInputText(Main.newWorldName);
              if (Main.newWorldName.Length > 20)
                Main.newWorldName = Main.newWorldName.Substring(0, 20);
              if (newWorldName != Main.newWorldName)
                Main.PlaySound(12);
              strArray1[0] = Lang.menu[48];
              flagArray2[2] = true;
              if (Main.newWorldName != "")
              {
                if (Main.newWorldName.Substring(0, 1) == " ")
                  Main.newWorldName = "";
                for (int index9 = 0; index9 < Main.newWorldName.Length; ++index9)
                {
                  if (Main.newWorldName != " ")
                    flagArray2[2] = false;
                }
              }
              ++this.textBlinkerCount;
              if (this.textBlinkerCount >= 20)
              {
                this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
                this.textBlinkerCount = 0;
              }
              strArray1[1] = Main.newWorldName;
              if (this.textBlinkerState == 1)
              {
                string[] strArray7;
                (strArray7 = strArray1)[1] = strArray7[1] + "|";
                numArray2[1] = 1;
              }
              else
              {
                string[] strArray8;
                (strArray8 = strArray1)[1] = strArray8[1] + " ";
              }
              flagArray1[0] = true;
              flagArray1[1] = true;
              numArray1[1] = -20;
              numArray1[2] = 20;
              strArray1[2] = Lang.menu[4];
              strArray1[3] = Lang.menu[5];
              num5 = 4;
              if (this.selectedMenu == 3)
              {
                Main.PlaySound(11);
                Main.menuMode = 16;
              }
              if (this.selectedMenu == 2 || !flagArray2[2] && Main.inputTextEnter)
              {
                Main.menuMode = 10;
                Main.worldName = Main.newWorldName;
                Main.worldPathName = Main.nextLoadWorld();
                WorldGen.CreateNewWorld();
                goto label_482;
              }
              else
                goto label_482;
            case 8:
              num2 = 220;
              num4 = 60;
              strArray1[5] = Lang.menu[5];
              for (int index10 = 0; index10 < 5; ++index10)
                strArray1[index10] = index10 >= Main.numLoadWorlds ? (string) null : Main.loadWorld[index10];
              num5 = 6;
              if (this.selectedMenu == 5)
              {
                Main.PlaySound(11);
                Main.menuMode = 1;
                goto label_482;
              }
              else if (this.selectedMenu >= 0)
              {
                this.selectedWorld = this.selectedMenu;
                Main.PlaySound(10);
                Main.menuMode = 9;
                goto label_482;
              }
              else
                goto label_482;
            case 9:
              strArray1[0] = Lang.menu[46] + " " + Main.loadWorld[this.selectedWorld] + "?";
              flagArray1[0] = true;
              strArray1[1] = Lang.menu[104];
              strArray1[2] = Lang.menu[105];
              num5 = 3;
              if (this.selectedMenu == 1)
              {
                Main.EraseWorld(this.selectedWorld);
                Main.PlaySound(10);
                Main.menuMode = 6;
                goto label_482;
              }
              else if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 6;
                goto label_482;
              }
              else
                goto label_482;
            case 10:
              num5 = 1;
              strArray1[0] = Main.statusText;
              flagArray1[0] = true;
              num2 = 300;
              goto label_482;
            case 11:
              num2 = 180;
              num4 = 44;
              numArray1[8] = 10;
              num5 = 9;
              for (int index11 = 0; index11 < 9; ++index11)
                numArray4[index11] = 0.9f;
              strArray1[0] = Lang.menu[63];
              strArray1[1] = Lang.menu[64];
              strArray1[2] = Lang.menu[65];
              strArray1[3] = Lang.menu[66];
              strArray1[4] = !Main.autoSave ? Lang.menu[68] : Lang.menu[67];
              strArray1[5] = !Main.autoPause ? Lang.menu[70] : Lang.menu[69];
              strArray1[6] = !Main.showItemText ? Lang.menu[72] : Lang.menu[71];
              strArray1[8] = Lang.menu[5];
              strArray1[7] = Lang.menu[103];
              if (this.selectedMenu == 7)
              {
                Main.PlaySound(10);
                Main.menuMode = 1213;
              }
              if (this.selectedMenu == 8)
              {
                Main.PlaySound(11);
                this.SaveSettings();
                Main.menuMode = 0;
              }
              if (this.selectedMenu == 6)
              {
                Main.PlaySound(12);
                Main.showItemText = !Main.showItemText;
              }
              if (this.selectedMenu == 5)
              {
                Main.PlaySound(12);
                Main.autoPause = !Main.autoPause;
              }
              if (this.selectedMenu == 4)
              {
                Main.PlaySound(12);
                Main.autoSave = !Main.autoSave;
              }
              if (this.selectedMenu == 3)
              {
                Main.PlaySound(11);
                Main.menuMode = 27;
              }
              if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 26;
              }
              if (this.selectedMenu == 1)
              {
                Main.PlaySound(10);
                this.selColor = Main.mouseColor;
                Main.menuMode = 25;
              }
              if (this.selectedMenu == 0)
              {
                Main.PlaySound(10);
                Main.menuMode = 1111;
                goto label_482;
              }
              else
                goto label_482;
            case 12:
              Main.menuServer = false;
              strArray1[0] = Lang.menu[87];
              strArray1[1] = Lang.menu[88];
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 0)
              {
                Main.LoadPlayers();
                Main.menuMultiplayer = true;
                Main.PlaySound(10);
                Main.menuMode = 1;
              }
              else if (this.selectedMenu == 1)
              {
                Main.LoadPlayers();
                Main.PlaySound(10);
                Main.menuMode = 1;
                Main.menuMultiplayer = true;
                Main.menuServer = true;
              }
              if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 0;
              }
              num5 = 3;
              goto label_482;
            case 13:
              string getIp = Main.getIP;
              Main.getIP = Main.GetInputText(Main.getIP);
              if (getIp != Main.getIP)
                Main.PlaySound(12);
              strArray1[0] = Lang.menu[89];
              flagArray2[9] = true;
              if (Main.getIP != "")
              {
                if (Main.getIP.Substring(0, 1) == " ")
                  Main.getIP = "";
                for (int index12 = 0; index12 < Main.getIP.Length; ++index12)
                {
                  if (Main.getIP != " ")
                    flagArray2[9] = false;
                }
              }
              ++this.textBlinkerCount;
              if (this.textBlinkerCount >= 20)
              {
                this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
                this.textBlinkerCount = 0;
              }
              strArray1[1] = Main.getIP;
              if (this.textBlinkerState == 1)
              {
                string[] strArray9;
                (strArray9 = strArray1)[1] = strArray9[1] + "|";
                numArray2[1] = 1;
              }
              else
              {
                string[] strArray10;
                (strArray10 = strArray1)[1] = strArray10[1] + " ";
              }
              flagArray1[0] = true;
              flagArray1[1] = true;
              numArray1[9] = 44;
              numArray1[10] = 64;
              strArray1[9] = Lang.menu[4];
              strArray1[10] = Lang.menu[5];
              num5 = 11;
              num2 = 180;
              num4 = 30;
              numArray1[1] = 19;
              for (int index13 = 2; index13 < 9; ++index13)
              {
                int index14 = index13 - 2;
                if (Main.recentWorld[index14] != null && Main.recentWorld[index14] != "")
                {
                  strArray1[index13] = Main.recentWorld[index14] + " (" + Main.recentIP[index14] + ":" + (object) Main.recentPort[index14] + ")";
                }
                else
                {
                  strArray1[index13] = "";
                  flagArray1[index13] = true;
                }
                numArray4[index13] = 0.6f;
                numArray1[index13] = 40;
              }
              if (this.selectedMenu >= 2 && this.selectedMenu < 9)
              {
                Main.autoPass = false;
                int index15 = this.selectedMenu - 2;
                Netplay.serverPort = Main.recentPort[index15];
                Main.getIP = Main.recentIP[index15];
                if (Netplay.SetIP(Main.getIP))
                {
                  Main.menuMode = 10;
                  Netplay.StartClient();
                }
                else if (Netplay.SetIP2(Main.getIP))
                {
                  Main.menuMode = 10;
                  Netplay.StartClient();
                }
              }
              if (this.selectedMenu == 10)
              {
                Main.PlaySound(11);
                Main.menuMode = 1;
              }
              if (this.selectedMenu == 9 || !flagArray2[2] && Main.inputTextEnter)
              {
                Main.PlaySound(12);
                Main.menuMode = 131;
                Main.clrInput();
                goto label_482;
              }
              else
                goto label_482;
            case 14:
              break;
            case 15:
              num5 = 2;
              strArray1[0] = Main.statusText;
              flagArray1[0] = true;
              num2 = 80;
              num4 = 400;
              strArray1[1] = Lang.menu[5];
              if (this.selectedMenu == 1)
              {
                Netplay.disconnect = true;
                Main.PlaySound(11);
                Main.menuMode = 0;
                Main.netMode = 0;
                goto label_482;
              }
              else
                goto label_482;
            case 16:
              num2 = 200;
              num4 = 60;
              numArray1[1] = 30;
              numArray1[2] = 30;
              numArray1[3] = 30;
              numArray1[4] = 70;
              strArray1[0] = Lang.menu[91];
              flagArray1[0] = true;
              strArray1[1] = Lang.menu[92];
              strArray1[2] = Lang.menu[93];
              strArray1[3] = Lang.menu[94];
              strArray1[4] = Lang.menu[5];
              num5 = 5;
              if (this.selectedMenu == 4)
              {
                Main.menuMode = 6;
                Main.PlaySound(11);
                goto label_482;
              }
              else if (this.selectedMenu > 0)
              {
                if (this.selectedMenu == 1)
                {
                  Main.maxTilesX = 4200;
                  Main.maxTilesY = 1200;
                }
                else if (this.selectedMenu == 2)
                {
                  Main.maxTilesX = 6400;
                  Main.maxTilesY = 1800;
                }
                else
                {
                  Main.maxTilesX = 8400;
                  Main.maxTilesY = 2400;
                }
                Main.clrInput();
                Main.menuMode = 7;
                Main.PlaySound(10);
                WorldGen.setWorldSize();
                goto label_482;
              }
              else
                goto label_482;
            case 17:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 390;
              num2 = 260;
              num4 = 60;
              Main.loadPlayer[index1].hairColor = this.selColor;
              num5 = 3;
              strArray1[0] = Lang.menu[37] + " " + (object) (Main.loadPlayer[index1].hair + 1);
              strArray1[1] = Lang.menu[38];
              flagArray1[1] = true;
              numArray1[2] = 150;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 0)
              {
                Main.PlaySound(12);
                ++Main.loadPlayer[index1].hair;
                if (Main.loadPlayer[index1].hair >= 36)
                  Main.loadPlayer[index1].hair = 0;
              }
              else if (this.selectedMenu2 == 0)
              {
                Main.PlaySound(12);
                --Main.loadPlayer[index1].hair;
                if (Main.loadPlayer[index1].hair < 0)
                  Main.loadPlayer[index1].hair = 35;
              }
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 2;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 18:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.loadPlayer[index1].eyeColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[39];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 2;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 19:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.loadPlayer[index1].skinColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[40];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 2;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 20:
              if (this.selectedMenu == 0)
              {
                Main.menuMode = 21;
                Main.PlaySound(10);
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].shirtColor;
              }
              if (this.selectedMenu == 1)
              {
                Main.menuMode = 22;
                Main.PlaySound(10);
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].underShirtColor;
              }
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 23;
                Main.PlaySound(10);
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].pantsColor;
              }
              if (this.selectedMenu == 3)
              {
                this.selColor = Main.loadPlayer[Main.numLoadPlayers].shoeColor;
                Main.menuMode = 24;
                Main.PlaySound(10);
              }
              strArray1[0] = Lang.menu[33];
              strArray1[1] = Lang.menu[34];
              strArray1[2] = Lang.menu[35];
              strArray1[3] = Lang.menu[36];
              num2 = 260;
              num4 = 50;
              numArray1[5] = 20;
              strArray1[5] = Lang.menu[5];
              num5 = 6;
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              if (this.selectedMenu == 5)
              {
                Main.PlaySound(11);
                Main.menuMode = 2;
                goto label_482;
              }
              else
                goto label_482;
            case 21:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.loadPlayer[index1].shirtColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[41];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 20;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 22:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.loadPlayer[index1].underShirtColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[42];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 20;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 23:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.loadPlayer[index1].pantsColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[43];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 20;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 24:
              index1 = Main.numLoadPlayers;
              num6 = Main.screenWidth / 2 - 16;
              num7 = 210;
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.loadPlayer[index1].shoeColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[44];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 20;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 25:
              flag1 = true;
              num8 = 370;
              num2 = 240;
              num4 = 60;
              Main.mouseColor = this.selColor;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[64];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 11;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 26:
              flag2 = true;
              num2 = 240;
              num4 = 60;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[65];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 11;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 27:
              num2 = 176;
              num4 = 28;
              num5 = 14;
              string[] strArray11 = new string[12]
              {
                Main.cUp,
                Main.cDown,
                Main.cLeft,
                Main.cRight,
                Main.cJump,
                Main.cThrowItem,
                Main.cInv,
                Main.cHeal,
                Main.cMana,
                Main.cBuff,
                Main.cHook,
                Main.cTorch
              };
              if (this.setKey >= 0)
                strArray11[this.setKey] = "_";
              strArray1[0] = Lang.menu[74] + strArray11[0];
              strArray1[1] = Lang.menu[75] + strArray11[1];
              strArray1[2] = Lang.menu[76] + strArray11[2];
              strArray1[3] = Lang.menu[77] + strArray11[3];
              strArray1[4] = Lang.menu[78] + strArray11[4];
              strArray1[5] = Lang.menu[79] + strArray11[5];
              strArray1[6] = Lang.menu[80] + strArray11[6];
              strArray1[7] = Lang.menu[81] + strArray11[7];
              strArray1[8] = Lang.menu[82] + strArray11[8];
              strArray1[9] = Lang.menu[83] + strArray11[9];
              strArray1[10] = Lang.menu[84] + strArray11[10];
              strArray1[11] = Lang.menu[85] + strArray11[11];
              for (int index16 = 0; index16 < 12; ++index16)
              {
                flagArray3[index16] = true;
                numArray4[index16] = 0.55f;
                numArray2[index16] = -80;
              }
              numArray4[12] = 0.8f;
              numArray4[13] = 0.8f;
              numArray1[12] = 6;
              strArray1[12] = Lang.menu[86];
              numArray1[13] = 16;
              strArray1[13] = Lang.menu[5];
              if (this.selectedMenu == 13)
              {
                Main.menuMode = 11;
                Main.PlaySound(11);
              }
              else if (this.selectedMenu == 12)
              {
                Main.cUp = "W";
                Main.cDown = "S";
                Main.cLeft = "A";
                Main.cRight = "D";
                Main.cJump = "Space";
                Main.cThrowItem = "T";
                Main.cInv = "Escape";
                Main.cHeal = "H";
                Main.cMana = "M";
                Main.cBuff = "B";
                Main.cHook = "E";
                Main.cTorch = "LeftShift";
                this.setKey = -1;
                Main.PlaySound(11);
              }
              else if (this.selectedMenu >= 0)
                this.setKey = this.selectedMenu;
              if (this.setKey >= 0)
              {
                Keys[] pressedKeys = Main.keyState.GetPressedKeys();
                if (pressedKeys.Length > 0)
                {
                  string str = string.Concat((object) pressedKeys[0]);
                  if (str != "None")
                  {
                    if (this.setKey == 0)
                      Main.cUp = str;
                    if (this.setKey == 1)
                      Main.cDown = str;
                    if (this.setKey == 2)
                      Main.cLeft = str;
                    if (this.setKey == 3)
                      Main.cRight = str;
                    if (this.setKey == 4)
                      Main.cJump = str;
                    if (this.setKey == 5)
                      Main.cThrowItem = str;
                    if (this.setKey == 6)
                      Main.cInv = str;
                    if (this.setKey == 7)
                      Main.cHeal = str;
                    if (this.setKey == 8)
                      Main.cMana = str;
                    if (this.setKey == 9)
                      Main.cBuff = str;
                    if (this.setKey == 10)
                      Main.cHook = str;
                    if (this.setKey == 11)
                      Main.cTorch = str;
                    this.setKey = -1;
                    goto label_482;
                  }
                  else
                    goto label_482;
                }
                else
                  goto label_482;
              }
              else
                goto label_482;
            case 28:
              Main.caveParrallax = (float) (1.0 - (double) this.bgScroll / 500.0);
              flag3 = true;
              num2 = 240;
              num4 = 60;
              num5 = 3;
              strArray1[0] = "";
              strArray1[1] = Lang.menu[52];
              flagArray1[1] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.menuMode = 1111;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 30:
              string password = Netplay.password;
              Netplay.password = Main.GetInputText(Netplay.password);
              if (password != Netplay.password)
                Main.PlaySound(12);
              strArray1[0] = Lang.menu[7];
              ++this.textBlinkerCount;
              if (this.textBlinkerCount >= 20)
              {
                this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
                this.textBlinkerCount = 0;
              }
              strArray1[1] = Netplay.password;
              if (this.textBlinkerState == 1)
              {
                string[] strArray12;
                (strArray12 = strArray1)[1] = strArray12[1] + "|";
                numArray2[1] = 1;
              }
              else
              {
                string[] strArray13;
                (strArray13 = strArray1)[1] = strArray13[1] + " ";
              }
              flagArray1[0] = true;
              flagArray1[1] = true;
              numArray1[1] = -20;
              numArray1[2] = 20;
              strArray1[2] = Lang.menu[4];
              strArray1[3] = Lang.menu[5];
              num5 = 4;
              if (this.selectedMenu == 3)
              {
                Main.PlaySound(11);
                Main.menuMode = 6;
                Netplay.password = "";
                goto label_482;
              }
              else if (this.selectedMenu == 2 || Main.inputTextEnter || Main.autoPass)
              {
                this.tServer.StartInfo.FileName = "TerrariaServer.exe";
                this.tServer.StartInfo.Arguments = "-autoshutdown -world \"" + Main.worldPathName + "\" -password \"" + Netplay.password + "\" -lang " + (object) Lang.lang;
                if (Main.libPath != "")
                {
                  ProcessStartInfo startInfo = this.tServer.StartInfo;
                  startInfo.Arguments = startInfo.Arguments + " -loadlib " + Main.libPath;
                }
                this.tServer.StartInfo.UseShellExecute = false;
                this.tServer.StartInfo.CreateNoWindow = true;
                this.tServer.Start();
                Netplay.SetIP("127.0.0.1");
                Main.autoPass = true;
                Main.statusText = Lang.menu[8];
                Netplay.StartClient();
                Main.menuMode = 10;
                goto label_482;
              }
              else
                goto label_482;
            case 100:
              num5 = 1;
              strArray1[0] = Main.statusText;
              flagArray1[0] = true;
              num2 = 300;
              goto label_482;
            case 111:
              num2 = 240;
              num4 = 60;
              num5 = 3;
              strArray1[0] = Lang.menu[73];
              strArray1[1] = this.graphics.PreferredBackBufferWidth.ToString() + "x" + (object) this.graphics.PreferredBackBufferHeight;
              flagArray1[0] = true;
              numArray1[2] = 170;
              numArray1[1] = 10;
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 1)
              {
                Main.PlaySound(12);
                int num10 = 0;
                for (int index17 = 0; index17 < this.numDisplayModes; ++index17)
                {
                  if (this.displayWidth[index17] == this.graphics.PreferredBackBufferWidth && this.displayHeight[index17] == this.graphics.PreferredBackBufferHeight)
                  {
                    num10 = index17;
                    break;
                  }
                }
                int index18 = num10 + 1;
                if (index18 >= this.numDisplayModes)
                  index18 = 0;
                this.graphics.PreferredBackBufferWidth = this.displayWidth[index18];
                this.graphics.PreferredBackBufferHeight = this.displayHeight[index18];
              }
              if (this.selectedMenu == 2)
              {
                if (this.graphics.IsFullScreen)
                  this.graphics.ApplyChanges();
                Main.menuMode = 1111;
                Main.PlaySound(11);
                goto label_482;
              }
              else
                goto label_482;
            case 131:
              int num11 = 7777;
              string getPort = Main.getPort;
              Main.getPort = Main.GetInputText(Main.getPort);
              if (getPort != Main.getPort)
                Main.PlaySound(12);
              strArray1[0] = Lang.menu[90];
              flagArray2[2] = true;
              if (Main.getPort != "")
              {
                bool flag5 = false;
                try
                {
                  num11 = Convert.ToInt32(Main.getPort);
                  if (num11 > 0)
                  {
                    if (num11 <= (int) ushort.MaxValue)
                      flag5 = true;
                  }
                }
                catch
                {
                }
                if (flag5)
                  flagArray2[2] = false;
              }
              ++this.textBlinkerCount;
              if (this.textBlinkerCount >= 20)
              {
                this.textBlinkerState = this.textBlinkerState != 0 ? 0 : 1;
                this.textBlinkerCount = 0;
              }
              strArray1[1] = Main.getPort;
              if (this.textBlinkerState == 1)
              {
                string[] strArray14;
                (strArray14 = strArray1)[1] = strArray14[1] + "|";
                numArray2[1] = 1;
              }
              else
              {
                string[] strArray15;
                (strArray15 = strArray1)[1] = strArray15[1] + " ";
              }
              flagArray1[0] = true;
              flagArray1[1] = true;
              numArray1[1] = -20;
              numArray1[2] = 20;
              strArray1[2] = Lang.menu[4];
              strArray1[3] = Lang.menu[5];
              num5 = 4;
              if (this.selectedMenu == 3)
              {
                Main.PlaySound(11);
                Main.menuMode = 1;
              }
              if (this.selectedMenu == 2 || !flagArray2[2] && Main.inputTextEnter)
              {
                Netplay.serverPort = num11;
                Main.autoPass = false;
                if (Netplay.SetIP(Main.getIP))
                {
                  Main.menuMode = 10;
                  Netplay.StartClient();
                  goto label_482;
                }
                else if (Netplay.SetIP2(Main.getIP))
                {
                  Main.menuMode = 10;
                  Netplay.StartClient();
                  goto label_482;
                }
                else
                  goto label_482;
              }
              else
                goto label_482;
            case 200:
              num5 = 3;
              strArray1[0] = Lang.menu[9];
              flagArray1[0] = true;
              num2 -= 30;
              numArray1[1] = 70;
              numArray1[2] = 50;
              strArray1[1] = Lang.menu[10];
              strArray1[2] = Lang.menu[6];
              if (this.selectedMenu == 1)
              {
                if (File.Exists(Main.worldPathName + ".bak"))
                {
                  File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
                  File.Delete(Main.worldPathName + ".bak");
                  Main.PlaySound(10);
                  WorldGen.playWorld();
                  Main.menuMode = 10;
                }
                else
                {
                  Main.PlaySound(11);
                  Main.menuMode = 0;
                  Main.netMode = 0;
                }
              }
              if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 0;
                Main.netMode = 0;
                goto label_482;
              }
              else
                goto label_482;
            case 201:
              num5 = 3;
              strArray1[0] = Lang.menu[9];
              flagArray1[0] = true;
              flagArray1[1] = true;
              num2 -= 30;
              numArray1[1] = -30;
              numArray1[2] = 50;
              strArray1[1] = Lang.menu[11];
              strArray1[2] = Lang.menu[5];
              if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 0;
                Main.netMode = 0;
                goto label_482;
              }
              else
                goto label_482;
            case 222:
              strArray1[0] = this.focusMenu != 3 ? (this.focusMenu != 2 ? (this.focusMenu != 1 ? Lang.menu[32] : Lang.menu[31]) : Lang.menu[30]) : Lang.menu[29];
              num4 = 50;
              numArray1[1] = 25;
              numArray1[2] = 25;
              numArray1[3] = 25;
              flagArray1[0] = true;
              strArray1[1] = Lang.menu[26];
              strArray1[2] = Lang.menu[25];
              numArray3[2] = (byte) 1;
              strArray1[3] = Lang.menu[24];
              numArray3[3] = (byte) 2;
              num5 = 4;
              if (this.selectedMenu == 1)
              {
                Main.loadPlayer[Main.numLoadPlayers].difficulty = (byte) 0;
                Main.menuMode = 2;
                goto label_482;
              }
              else if (this.selectedMenu == 2)
              {
                Main.menuMode = 2;
                Main.loadPlayer[Main.numLoadPlayers].difficulty = (byte) 1;
                goto label_482;
              }
              else if (this.selectedMenu == 3)
              {
                Main.loadPlayer[Main.numLoadPlayers].difficulty = (byte) 2;
                Main.menuMode = 2;
                goto label_482;
              }
              else
                goto label_482;
            case 1111:
              num2 = 210;
              num4 = 46;
              for (int index19 = 0; index19 < 7; ++index19)
                numArray4[index19] = 0.9f;
              numArray1[7] = 10;
              num5 = 8;
              strArray1[0] = !this.graphics.IsFullScreen ? Lang.menu[50] : Lang.menu[49];
              this.bgScroll = (int) Math.Round((1.0 - (double) Main.caveParrallax) * 500.0);
              strArray1[1] = Lang.menu[51];
              strArray1[2] = Lang.menu[52];
              strArray1[3] = !Main.fixedTiming ? Lang.menu[54] : Lang.menu[53];
              switch (Lighting.lightMode)
              {
                case 0:
                  strArray1[4] = Lang.menu[55];
                  break;
                case 1:
                  strArray1[4] = Lang.menu[56];
                  break;
                case 2:
                  strArray1[4] = Lang.menu[57];
                  break;
                case 3:
                  strArray1[4] = Lang.menu[58];
                  break;
              }
              switch (Main.qaStyle)
              {
                case 0:
                  strArray1[5] = Lang.menu[59];
                  break;
                case 1:
                  strArray1[5] = Lang.menu[60];
                  break;
                case 2:
                  strArray1[5] = Lang.menu[61];
                  break;
                default:
                  strArray1[5] = Lang.menu[62];
                  break;
              }
              strArray1[6] = !Main.owBack ? Lang.menu[101] : Lang.menu[100];
              if (this.selectedMenu == 6)
              {
                Main.PlaySound(12);
                Main.owBack = !Main.owBack;
              }
              strArray1[7] = Lang.menu[5];
              if (this.selectedMenu == 7)
              {
                Main.PlaySound(11);
                this.SaveSettings();
                Main.menuMode = 11;
              }
              if (this.selectedMenu == 5)
              {
                Main.PlaySound(12);
                ++Main.qaStyle;
                if (Main.qaStyle > 3)
                  Main.qaStyle = 0;
              }
              if (this.selectedMenu == 4)
              {
                Main.PlaySound(12);
                ++Lighting.lightMode;
                if (Lighting.lightMode >= 4)
                  Lighting.lightMode = 0;
              }
              if (this.selectedMenu == 3)
              {
                Main.PlaySound(12);
                Main.fixedTiming = !Main.fixedTiming;
              }
              if (this.selectedMenu == 2)
              {
                Main.PlaySound(11);
                Main.menuMode = 28;
              }
              if (this.selectedMenu == 1)
              {
                Main.PlaySound(10);
                Main.menuMode = 111;
              }
              if (this.selectedMenu == 0)
              {
                this.graphics.ToggleFullScreen();
                goto label_482;
              }
              else
                goto label_482;
            default:
              goto label_482;
          }
        }
        num5 = 2;
        strArray1[0] = Main.statusText;
        flagArray1[0] = true;
        num2 = 300;
        strArray1[1] = Lang.menu[6];
        if (this.selectedMenu == 1)
        {
          Netplay.disconnect = true;
          Netplay.clientSock.tcpClient.Close();
          Main.PlaySound(11);
          Main.menuMode = 0;
          Main.netMode = 0;
          try
          {
            this.tServer.Kill();
          }
          catch
          {
          }
        }
      }
label_482:
      if (Main.menuMode != menuMode)
      {
        num5 = 0;
        for (int index20 = 0; index20 < Main.maxMenuItems; ++index20)
          this.menuItemScale[index20] = 0.8f;
      }
      int focusMenu = this.focusMenu;
      this.selectedMenu = -1;
      this.selectedMenu2 = -1;
      this.focusMenu = -1;
      for (int index21 = 0; index21 < num5; ++index21)
      {
        if (strArray1[index21] != null)
        {
          if (flag1)
          {
            string text1 = "";
            for (int index22 = 0; index22 < 6; ++index22)
            {
              int num12 = num8;
              int num13 = 370 + Main.screenWidth / 2 - 400;
              if (index22 == 0)
                text1 = Lang.menu[95];
              if (index22 == 1)
              {
                text1 = Lang.menu[96];
                num12 += 30;
              }
              if (index22 == 2)
              {
                text1 = Lang.menu[97];
                num12 += 60;
              }
              if (index22 == 3)
              {
                text1 = string.Concat((object) this.selColor.R);
                num13 += 90;
              }
              if (index22 == 4)
              {
                text1 = string.Concat((object) this.selColor.G);
                num13 += 90;
                num12 += 30;
              }
              if (index22 == 5)
              {
                text1 = string.Concat((object) this.selColor.B);
                num13 += 90;
                num12 += 60;
              }
              for (int index23 = 0; index23 < 5; ++index23)
              {
                Microsoft.Xna.Framework.Color color4 = Microsoft.Xna.Framework.Color.Black;
                if (index23 == 4)
                {
                  color4 = color1;
                  color4.R = (byte) (((int) byte.MaxValue + (int) color4.R) / 2);
                  color4.G = (byte) (((int) byte.MaxValue + (int) color4.R) / 2);
                  color4.B = (byte) (((int) byte.MaxValue + (int) color4.R) / 2);
                }
                int maxValue = (int) byte.MaxValue;
                int num14 = (int) color4.R - ((int) byte.MaxValue - maxValue);
                if (num14 < 0)
                  num14 = 0;
                color4 = new Microsoft.Xna.Framework.Color((int) (byte) num14, (int) (byte) num14, (int) (byte) num14, (int) (byte) maxValue);
                int num15 = 0;
                int num16 = 0;
                if (index23 == 0)
                  num15 = -2;
                if (index23 == 1)
                  num15 = 2;
                if (index23 == 2)
                  num16 = -2;
                if (index23 == 3)
                  num16 = 2;
                this.spriteBatch.DrawString(Main.fontDeathText, text1, new Vector2((float) (num13 + num15), (float) (num12 + num16)), color4, 0.0f, new Vector2(), 0.5f, SpriteEffects.None, 0.0f);
              }
            }
            bool flag6 = false;
            for (int index24 = 0; index24 < 2; ++index24)
            {
              for (int index25 = 0; index25 < 3; ++index25)
              {
                int num17 = num8 + index25 * 30 - 12;
                int num18 = 360 + Main.screenWidth / 2 - 400;
                float scale = 0.9f;
                int num19;
                if (index24 == 0)
                {
                  num19 = num18 - 70;
                  num17 += 2;
                }
                else
                  num19 = num18 - 40;
                string text2 = "-";
                if (index24 == 1)
                  text2 = "+";
                Vector2 vector2 = new Vector2(24f, 24f);
                int num20 = 142;
                if (Main.mouseX > num19 && (double) Main.mouseX < (double) num19 + (double) vector2.X && Main.mouseY > num17 + 13 && (double) Main.mouseY < (double) (num17 + 13) + (double) vector2.Y)
                {
                  if (this.focusColor != (index24 + 1) * (index25 + 10))
                    Main.PlaySound(12);
                  this.focusColor = (index24 + 1) * (index25 + 10);
                  flag6 = true;
                  num20 = (int) byte.MaxValue;
                  if (Main.mouseLeft)
                  {
                    if (this.colorDelay <= 1)
                    {
                      this.colorDelay = this.colorDelay != 0 ? 3 : 40;
                      int num21 = index24;
                      if (index24 == 0)
                      {
                        num21 = -1;
                        if ((int) this.selColor.R + (int) this.selColor.G + (int) this.selColor.B <= 150)
                          num21 = 0;
                      }
                      if (index25 == 0 && (int) this.selColor.R + num21 >= 0 && (int) this.selColor.R + num21 <= (int) byte.MaxValue)
                        this.selColor.R += (byte) num21;
                      if (index25 == 1 && (int) this.selColor.G + num21 >= 0 && (int) this.selColor.G + num21 <= (int) byte.MaxValue)
                        this.selColor.G += (byte) num21;
                      if (index25 == 2 && (int) this.selColor.B + num21 >= 0 && (int) this.selColor.B + num21 <= (int) byte.MaxValue)
                        this.selColor.B += (byte) num21;
                    }
                    --this.colorDelay;
                  }
                  else
                    this.colorDelay = 0;
                }
                for (int index26 = 0; index26 < 5; ++index26)
                {
                  Microsoft.Xna.Framework.Color color5 = Microsoft.Xna.Framework.Color.Black;
                  if (index26 == 4)
                  {
                    color5 = color1;
                    color5.R = (byte) (((int) byte.MaxValue + (int) color5.R) / 2);
                    color5.G = (byte) (((int) byte.MaxValue + (int) color5.R) / 2);
                    color5.B = (byte) (((int) byte.MaxValue + (int) color5.R) / 2);
                  }
                  int num22 = (int) color5.R - ((int) byte.MaxValue - num20);
                  if (num22 < 0)
                    num22 = 0;
                  color5 = new Microsoft.Xna.Framework.Color((int) (byte) num22, (int) (byte) num22, (int) (byte) num22, (int) (byte) num20);
                  int num23 = 0;
                  int num24 = 0;
                  if (index26 == 0)
                    num23 = -2;
                  if (index26 == 1)
                    num23 = 2;
                  if (index26 == 2)
                    num24 = -2;
                  if (index26 == 3)
                    num24 = 2;
                  this.spriteBatch.DrawString(Main.fontDeathText, text2, new Vector2((float) (num19 + num23), (float) (num17 + num24)), color5, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
            if (!flag6)
            {
              this.focusColor = 0;
              this.colorDelay = 0;
            }
          }
          if (flag3)
          {
            int num25 = 400;
            string text3 = "";
            for (int index27 = 0; index27 < 4; ++index27)
            {
              int num26 = num25;
              int num27 = 370 + Main.screenWidth / 2 - 400;
              if (index27 == 0)
                text3 = Lang.menu[52] + ": " + (object) this.bgScroll;
              for (int index28 = 0; index28 < 5; ++index28)
              {
                Microsoft.Xna.Framework.Color color6 = Microsoft.Xna.Framework.Color.Black;
                if (index28 == 4)
                {
                  color6 = color1;
                  color6.R = (byte) (((int) byte.MaxValue + (int) color6.R) / 2);
                  color6.G = (byte) (((int) byte.MaxValue + (int) color6.R) / 2);
                  color6.B = (byte) (((int) byte.MaxValue + (int) color6.R) / 2);
                }
                int maxValue = (int) byte.MaxValue;
                int num28 = (int) color6.R - ((int) byte.MaxValue - maxValue);
                if (num28 < 0)
                  num28 = 0;
                color6 = new Microsoft.Xna.Framework.Color((int) (byte) num28, (int) (byte) num28, (int) (byte) num28, (int) (byte) maxValue);
                int num29 = 0;
                int num30 = 0;
                if (index28 == 0)
                  num29 = -2;
                if (index28 == 1)
                  num29 = 2;
                if (index28 == 2)
                  num30 = -2;
                if (index28 == 3)
                  num30 = 2;
                this.spriteBatch.DrawString(Main.fontDeathText, text3, new Vector2((float) (num27 + num29), (float) (num26 + num30)), color6, 0.0f, new Vector2(), 0.5f, SpriteEffects.None, 0.0f);
              }
            }
            bool flag7 = false;
            for (int index29 = 0; index29 < 2; ++index29)
            {
              for (int index30 = 0; index30 < 1; ++index30)
              {
                int num31 = num25 + index30 * 30 - 12;
                int num32 = 360 + Main.screenWidth / 2 - 400;
                float scale = 0.9f;
                int num33;
                if (index29 == 0)
                {
                  num33 = num32 - 70;
                  num31 += 2;
                }
                else
                  num33 = num32 - 40;
                string text4 = "-";
                if (index29 == 1)
                  text4 = "+";
                Vector2 vector2 = new Vector2(24f, 24f);
                int num34 = 142;
                if (Main.mouseX > num33 && (double) Main.mouseX < (double) num33 + (double) vector2.X && Main.mouseY > num31 + 13 && (double) Main.mouseY < (double) (num31 + 13) + (double) vector2.Y)
                {
                  if (this.focusColor != (index29 + 1) * (index30 + 10))
                    Main.PlaySound(12);
                  this.focusColor = (index29 + 1) * (index30 + 10);
                  flag7 = true;
                  num34 = (int) byte.MaxValue;
                  if (Main.mouseLeft)
                  {
                    if (this.colorDelay <= 1)
                    {
                      this.colorDelay = this.colorDelay != 0 ? 3 : 40;
                      int num35 = index29;
                      if (index29 == 0)
                        num35 = -1;
                      if (index30 == 0)
                      {
                        this.bgScroll += num35;
                        if (this.bgScroll > 100)
                          this.bgScroll = 100;
                        if (this.bgScroll < 0)
                          this.bgScroll = 0;
                      }
                    }
                    --this.colorDelay;
                  }
                  else
                    this.colorDelay = 0;
                }
                for (int index31 = 0; index31 < 5; ++index31)
                {
                  Microsoft.Xna.Framework.Color color7 = Microsoft.Xna.Framework.Color.Black;
                  if (index31 == 4)
                  {
                    color7 = color1;
                    color7.R = (byte) (((int) byte.MaxValue + (int) color7.R) / 2);
                    color7.G = (byte) (((int) byte.MaxValue + (int) color7.R) / 2);
                    color7.B = (byte) (((int) byte.MaxValue + (int) color7.R) / 2);
                  }
                  int num36 = (int) color7.R - ((int) byte.MaxValue - num34);
                  if (num36 < 0)
                    num36 = 0;
                  color7 = new Microsoft.Xna.Framework.Color((int) (byte) num36, (int) (byte) num36, (int) (byte) num36, (int) (byte) num34);
                  int num37 = 0;
                  int num38 = 0;
                  if (index31 == 0)
                    num37 = -2;
                  if (index31 == 1)
                    num37 = 2;
                  if (index31 == 2)
                    num38 = -2;
                  if (index31 == 3)
                    num38 = 2;
                  this.spriteBatch.DrawString(Main.fontDeathText, text4, new Vector2((float) (num33 + num37), (float) (num31 + num38)), color7, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
            if (!flag7)
            {
              this.focusColor = 0;
              this.colorDelay = 0;
            }
          }
          if (flag2)
          {
            int num39 = 400;
            string text5 = "";
            for (int index32 = 0; index32 < 4; ++index32)
            {
              int num40 = num39;
              int num41 = 370 + Main.screenWidth / 2 - 400;
              if (index32 == 0)
                text5 = Lang.menu[98];
              if (index32 == 1)
              {
                text5 = Lang.menu[99];
                num40 += 30;
              }
              if (index32 == 2)
              {
                text5 = Math.Round((double) Main.soundVolume * 100.0).ToString() + "%";
                num41 += 90;
              }
              if (index32 == 3)
              {
                text5 = Math.Round((double) Main.musicVolume * 100.0).ToString() + "%";
                num41 += 90;
                num40 += 30;
              }
              for (int index33 = 0; index33 < 5; ++index33)
              {
                Microsoft.Xna.Framework.Color color8 = Microsoft.Xna.Framework.Color.Black;
                if (index33 == 4)
                {
                  color8 = color1;
                  color8.R = (byte) (((int) byte.MaxValue + (int) color8.R) / 2);
                  color8.G = (byte) (((int) byte.MaxValue + (int) color8.R) / 2);
                  color8.B = (byte) (((int) byte.MaxValue + (int) color8.R) / 2);
                }
                int maxValue = (int) byte.MaxValue;
                int num42 = (int) color8.R - ((int) byte.MaxValue - maxValue);
                if (num42 < 0)
                  num42 = 0;
                color8 = new Microsoft.Xna.Framework.Color((int) (byte) num42, (int) (byte) num42, (int) (byte) num42, (int) (byte) maxValue);
                int num43 = 0;
                int num44 = 0;
                if (index33 == 0)
                  num43 = -2;
                if (index33 == 1)
                  num43 = 2;
                if (index33 == 2)
                  num44 = -2;
                if (index33 == 3)
                  num44 = 2;
                this.spriteBatch.DrawString(Main.fontDeathText, text5, new Vector2((float) (num41 + num43), (float) (num40 + num44)), color8, 0.0f, new Vector2(), 0.5f, SpriteEffects.None, 0.0f);
              }
            }
            bool flag8 = false;
            for (int index34 = 0; index34 < 2; ++index34)
            {
              for (int index35 = 0; index35 < 2; ++index35)
              {
                int num45 = num39 + index35 * 30 - 12;
                int num46 = 360 + Main.screenWidth / 2 - 400;
                float scale = 0.9f;
                int num47;
                if (index34 == 0)
                {
                  num47 = num46 - 70;
                  num45 += 2;
                }
                else
                  num47 = num46 - 40;
                string text6 = "-";
                if (index34 == 1)
                  text6 = "+";
                Vector2 vector2 = new Vector2(24f, 24f);
                int num48 = 142;
                if (Main.mouseX > num47 && (double) Main.mouseX < (double) num47 + (double) vector2.X && Main.mouseY > num45 + 13 && (double) Main.mouseY < (double) (num45 + 13) + (double) vector2.Y)
                {
                  if (this.focusColor != (index34 + 1) * (index35 + 10))
                    Main.PlaySound(12);
                  this.focusColor = (index34 + 1) * (index35 + 10);
                  flag8 = true;
                  num48 = (int) byte.MaxValue;
                  if (Main.mouseLeft)
                  {
                    if (this.colorDelay <= 1)
                    {
                      this.colorDelay = this.colorDelay != 0 ? 3 : 40;
                      int num49 = index34;
                      if (index34 == 0)
                        num49 = -1;
                      if (index35 == 0)
                      {
                        Main.soundVolume += (float) num49 * 0.01f;
                        if ((double) Main.soundVolume > 1.0)
                          Main.soundVolume = 1f;
                        if ((double) Main.soundVolume < 0.0)
                          Main.soundVolume = 0.0f;
                      }
                      if (index35 == 1)
                      {
                        Main.musicVolume += (float) num49 * 0.01f;
                        if ((double) Main.musicVolume > 1.0)
                          Main.musicVolume = 1f;
                        if ((double) Main.musicVolume < 0.0)
                          Main.musicVolume = 0.0f;
                      }
                    }
                    --this.colorDelay;
                  }
                  else
                    this.colorDelay = 0;
                }
                for (int index36 = 0; index36 < 5; ++index36)
                {
                  Microsoft.Xna.Framework.Color color9 = Microsoft.Xna.Framework.Color.Black;
                  if (index36 == 4)
                  {
                    color9 = color1;
                    color9.R = (byte) (((int) byte.MaxValue + (int) color9.R) / 2);
                    color9.G = (byte) (((int) byte.MaxValue + (int) color9.R) / 2);
                    color9.B = (byte) (((int) byte.MaxValue + (int) color9.R) / 2);
                  }
                  int num50 = (int) color9.R - ((int) byte.MaxValue - num48);
                  if (num50 < 0)
                    num50 = 0;
                  color9 = new Microsoft.Xna.Framework.Color((int) (byte) num50, (int) (byte) num50, (int) (byte) num50, (int) (byte) num48);
                  int num51 = 0;
                  int num52 = 0;
                  if (index36 == 0)
                    num51 = -2;
                  if (index36 == 1)
                    num51 = 2;
                  if (index36 == 2)
                    num52 = -2;
                  if (index36 == 3)
                    num52 = 2;
                  this.spriteBatch.DrawString(Main.fontDeathText, text6, new Vector2((float) (num47 + num51), (float) (num45 + num52)), color9, 0.0f, new Vector2(), scale, SpriteEffects.None, 0.0f);
                }
              }
            }
            if (!flag8)
            {
              this.focusColor = 0;
              this.colorDelay = 0;
            }
          }
          for (int index37 = 0; index37 < 5; ++index37)
          {
            Microsoft.Xna.Framework.Color color10 = Microsoft.Xna.Framework.Color.Black;
            if (index37 == 4)
            {
              color10 = color1;
              if (numArray3[index21] == (byte) 2)
                color10 = Main.hcColor;
              else if (numArray3[index21] == (byte) 1)
                color10 = Main.mcColor;
              color10.R = (byte) (((int) byte.MaxValue + (int) color10.R) / 2);
              color10.G = (byte) (((int) byte.MaxValue + (int) color10.G) / 2);
              color10.B = (byte) (((int) byte.MaxValue + (int) color10.B) / 2);
            }
            int num53 = (int) ((double) byte.MaxValue * ((double) this.menuItemScale[index21] * 2.0 - 1.0));
            if (flagArray1[index21])
              num53 = (int) byte.MaxValue;
            int num54 = (int) color10.R - ((int) byte.MaxValue - num53);
            if (num54 < 0)
              num54 = 0;
            int num55 = (int) color10.G - ((int) byte.MaxValue - num53);
            if (num55 < 0)
              num55 = 0;
            int num56 = (int) color10.B - ((int) byte.MaxValue - num53);
            if (num56 < 0)
              num56 = 0;
            color10 = new Microsoft.Xna.Framework.Color((int) (byte) num54, (int) (byte) num55, (int) (byte) num56, (int) (byte) num53);
            int num57 = 0;
            int num58 = 0;
            if (index37 == 0)
              num57 = -2;
            if (index37 == 1)
              num57 = 2;
            if (index37 == 2)
              num58 = -2;
            if (index37 == 3)
              num58 = 2;
            Vector2 origin = Main.fontDeathText.MeasureString(strArray1[index21]);
            origin.X *= 0.5f;
            origin.Y *= 0.5f;
            float num59 = this.menuItemScale[index21];
            if (Main.menuMode == 15 && index21 == 0)
              num59 *= 0.35f;
            else if (Main.netMode == 2)
              num59 *= 0.5f;
            float scale = num59 * numArray4[index21];
            if (!flagArray3[index21])
              this.spriteBatch.DrawString(Main.fontDeathText, strArray1[index21], new Vector2((float) (num3 + num57 + numArray2[index21]), (float) (num2 + num4 * index21 + num58) + origin.Y * numArray4[index21] + (float) numArray1[index21]), color10, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
            else
              this.spriteBatch.DrawString(Main.fontDeathText, strArray1[index21], new Vector2((float) (num3 + num57 + numArray2[index21]), (float) (num2 + num4 * index21 + num58) + origin.Y * numArray4[index21] + (float) numArray1[index21]), color10, 0.0f, new Vector2(0.0f, origin.Y), scale, SpriteEffects.None, 0.0f);
          }
          if (!flagArray3[index21])
          {
            if ((double) Main.mouseX > (double) num3 - (double) (strArray1[index21].Length * 10) * (double) numArray4[index21] + (double) numArray2[index21] && (double) Main.mouseX < (double) num3 + (double) (strArray1[index21].Length * 10) * (double) numArray4[index21] + (double) numArray2[index21] && Main.mouseY > num2 + num4 * index21 + numArray1[index21] && (double) Main.mouseY < (double) (num2 + num4 * index21 + numArray1[index21]) + 50.0 * (double) numArray4[index21] && Main.hasFocus)
            {
              this.focusMenu = index21;
              if (flagArray1[index21] || flagArray2[index21])
              {
                this.focusMenu = -1;
              }
              else
              {
                if (focusMenu != this.focusMenu)
                  Main.PlaySound(12);
                if (Main.mouseLeftRelease && Main.mouseLeft)
                  this.selectedMenu = index21;
                if (Main.mouseRightRelease && Main.mouseRight)
                  this.selectedMenu2 = index21;
              }
            }
          }
          else if (Main.mouseX > num3 + numArray2[index21] && (double) Main.mouseX < (double) num3 + (double) (strArray1[index21].Length * 20) * (double) numArray4[index21] + (double) numArray2[index21] && Main.mouseY > num2 + num4 * index21 + numArray1[index21] && (double) Main.mouseY < (double) (num2 + num4 * index21 + numArray1[index21]) + 50.0 * (double) numArray4[index21] && Main.hasFocus)
          {
            this.focusMenu = index21;
            if (flagArray1[index21] || flagArray2[index21])
            {
              this.focusMenu = -1;
            }
            else
            {
              if (focusMenu != this.focusMenu)
                Main.PlaySound(12);
              if (Main.mouseLeftRelease && Main.mouseLeft)
                this.selectedMenu = index21;
              if (Main.mouseRightRelease && Main.mouseRight)
                this.selectedMenu2 = index21;
            }
          }
        }
      }
      for (int index38 = 0; index38 < Main.maxMenuItems; ++index38)
      {
        if (index38 == this.focusMenu)
        {
          if ((double) this.menuItemScale[index38] < 1.0)
            this.menuItemScale[index38] += 0.02f;
          if ((double) this.menuItemScale[index38] > 1.0)
            this.menuItemScale[index38] = 1f;
        }
        else if ((double) this.menuItemScale[index38] > 0.8)
          this.menuItemScale[index38] -= 0.02f;
      }
      if (index1 >= 0)
      {
        Main.loadPlayer[index1].PlayerFrame();
        Main.loadPlayer[index1].position.X = (float) num6 + Main.screenPosition.X;
        Main.loadPlayer[index1].position.Y = (float) num7 + Main.screenPosition.Y;
        this.DrawPlayer(Main.loadPlayer[index1]);
      }
      for (int index39 = 0; index39 < 5; ++index39)
      {
        Microsoft.Xna.Framework.Color color11 = Microsoft.Xna.Framework.Color.Black;
        if (index39 == 4)
        {
          color11 = color1;
          color11.R = (byte) (((int) byte.MaxValue + (int) color11.R) / 2);
          color11.G = (byte) (((int) byte.MaxValue + (int) color11.R) / 2);
          color11.B = (byte) (((int) byte.MaxValue + (int) color11.R) / 2);
        }
        color11.A = (byte) ((double) color11.A * 0.300000011920929);
        int num60 = 0;
        int num61 = 0;
        if (index39 == 0)
          num60 = -2;
        if (index39 == 1)
          num60 = 2;
        if (index39 == 2)
          num61 = -2;
        if (index39 == 3)
          num61 = 2;
        string text = "Copyright © 2012 Re-Logic";
        Vector2 origin = Main.fontMouseText.MeasureString(text);
        origin.X *= 0.5f;
        origin.Y *= 0.5f;
        this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) ((double) Main.screenWidth - (double) origin.X + (double) num60 - 10.0), (float) ((double) Main.screenHeight - (double) origin.Y + (double) num61 - 2.0)), color11, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
      }
      for (int index40 = 0; index40 < 5; ++index40)
      {
        Microsoft.Xna.Framework.Color color12 = Microsoft.Xna.Framework.Color.Black;
        if (index40 == 4)
        {
          color12 = color1;
          color12.R = (byte) (((int) byte.MaxValue + (int) color12.R) / 2);
          color12.G = (byte) (((int) byte.MaxValue + (int) color12.R) / 2);
          color12.B = (byte) (((int) byte.MaxValue + (int) color12.R) / 2);
        }
        color12.A = (byte) ((double) color12.A * 0.300000011920929);
        int num62 = 0;
        int num63 = 0;
        if (index40 == 0)
          num62 = -2;
        if (index40 == 1)
          num62 = 2;
        if (index40 == 2)
          num63 = -2;
        if (index40 == 3)
          num63 = 2;
        Vector2 origin = Main.fontMouseText.MeasureString(Main.versionNumber);
        origin.X *= 0.5f;
        origin.Y *= 0.5f;
        this.spriteBatch.DrawString(Main.fontMouseText, Main.versionNumber, new Vector2((float) ((double) origin.X + (double) num62 + 10.0), (float) ((double) Main.screenHeight - (double) origin.Y + (double) num63 - 2.0)), color12, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
      }
      this.spriteBatch.Draw(Main.cursorTexture, new Vector2((float) (Main.mouseX + 1), (float) (Main.mouseY + 1)), new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height)), new Microsoft.Xna.Framework.Color((int) ((double) Main.cursorColor.R * 0.200000002980232), (int) ((double) Main.cursorColor.G * 0.200000002980232), (int) ((double) Main.cursorColor.B * 0.200000002980232), (int) ((double) Main.cursorColor.A * 0.5)), 0.0f, new Vector2(), Main.cursorScale * 1.1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(Main.cursorTexture, new Vector2((float) Main.mouseX, (float) Main.mouseY), new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height)), Main.cursorColor, 0.0f, new Vector2(), Main.cursorScale, SpriteEffects.None, 0.0f);
      if (Main.fadeCounter > 0)
      {
        Microsoft.Xna.Framework.Color color13 = Microsoft.Xna.Framework.Color.White;
        --Main.fadeCounter;
        byte num64 = (byte) (float) ((double) Main.fadeCounter / 75.0 * (double) byte.MaxValue);
        color13 = new Microsoft.Xna.Framework.Color((int) num64, (int) num64, (int) num64, (int) num64);
        this.spriteBatch.Draw(Main.fadeTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color13);
      }
      this.spriteBatch.End();
      Main.mouseLeftRelease = !Main.mouseLeft;
      if (Main.mouseRight)
        Main.mouseRightRelease = false;
      else
        Main.mouseRightRelease = true;
    }

    public static void CursorColor()
    {
      Main.cursorAlpha += (float) Main.cursorColorDirection * 0.015f;
      if ((double) Main.cursorAlpha >= 1.0)
      {
        Main.cursorAlpha = 1f;
        Main.cursorColorDirection = -1;
      }
      if ((double) Main.cursorAlpha <= 0.6)
      {
        Main.cursorAlpha = 0.6f;
        Main.cursorColorDirection = 1;
      }
      float num = (float) ((double) Main.cursorAlpha * 0.300000011920929 + 0.699999988079071);
      Main.cursorColor = new Microsoft.Xna.Framework.Color((int) (byte) ((double) Main.mouseColor.R * (double) Main.cursorAlpha), (int) (byte) ((double) Main.mouseColor.G * (double) Main.cursorAlpha), (int) (byte) ((double) Main.mouseColor.B * (double) Main.cursorAlpha), (int) (byte) ((double) byte.MaxValue * (double) num));
      Main.cursorScale = (float) ((double) Main.cursorAlpha * 0.300000011920929 + 0.699999988079071 + 0.100000001490116);
    }

    protected void DrawSplash(GameTime gameTime)
    {
      this.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
      base.Draw(gameTime);
      this.spriteBatch.Begin();
      ++this.splashCounter;
      Microsoft.Xna.Framework.Color color = Microsoft.Xna.Framework.Color.White;
      byte num = 0;
      if (this.splashCounter <= 75)
        num = (byte) (float) ((double) this.splashCounter / 75.0 * (double) byte.MaxValue);
      else if (this.splashCounter <= 125)
        num = byte.MaxValue;
      else if (this.splashCounter <= 200)
      {
        num = (byte) (float) ((double) (125 - this.splashCounter) / 75.0 * (double) byte.MaxValue);
      }
      else
      {
        Main.showSplash = false;
        Main.fadeCounter = 75;
      }
      color = new Microsoft.Xna.Framework.Color((int) num, (int) num, (int) num, (int) num);
      this.spriteBatch.Draw(Main.loTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color);
      this.spriteBatch.End();
    }

    protected void DrawBackground()
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num1 = (int) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 140.0 * (double) Main.gfxQuality);
      int num2 = (int) (200.0 * (1.0 - (double) Main.gfxQuality) + 40.0 * (double) Main.gfxQuality);
      int num3 = 96;
      Vector2 vector2 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2 = new Vector2();
      float num4 = 0.9f;
      float num5 = num4;
      float num6 = num4;
      float num7 = num4;
      float num8 = 0.0f;
      if (Main.holyTiles > Main.evilTiles)
        num8 = (float) Main.holyTiles / 800f;
      else if (Main.evilTiles > Main.holyTiles)
        num8 = (float) Main.evilTiles / 800f;
      if ((double) num8 > 1.0)
        num8 = 1f;
      if ((double) num8 < 0.0)
        num8 = 0.0f;
      float num9 = (Main.screenPosition.Y - (float) (Main.worldSurface * 16.0)) / 300f;
      if ((double) num9 < 0.0)
        num9 = 0.0f;
      else if ((double) num9 > 1.0)
        num9 = 1f;
      float num10 = (float) (1.0 * (1.0 - (double) num9) + (double) num5 * (double) num9);
      Lighting.brightness = (float) ((double) Lighting.defBrightness * (1.0 - (double) num9) + 1.0 * (double) num9);
      float num11 = (float) ((double) Main.screenPosition.Y - (double) (Main.screenHeight / 2) + 200.0 - Main.rockLayer * 16.0) / 300f;
      if ((double) num11 < 0.0)
        num11 = 0.0f;
      else if ((double) num11 > 1.0)
        num11 = 1f;
      if (Main.evilTiles > 0)
      {
        num5 = (float) (0.800000011920929 * (double) num8 + (double) num5 * (1.0 - (double) num8));
        num6 = (float) (0.75 * (double) num8 + (double) num6 * (1.0 - (double) num8));
        num7 = (float) (1.10000002384186 * (double) num8 + (double) num7 * (1.0 - (double) num8));
      }
      else if (Main.holyTiles > 0)
      {
        num5 = (float) (1.0 * (double) num8 + (double) num5 * (1.0 - (double) num8));
        num6 = (float) (0.699999988079071 * (double) num8 + (double) num6 * (1.0 - (double) num8));
        num7 = (float) (0.899999976158142 * (double) num8 + (double) num7 * (1.0 - (double) num8));
      }
      float num12 = (float) (1.0 * ((double) num10 - (double) num11) + (double) num5 * (double) num11);
      float num13 = (float) (1.0 * ((double) num10 - (double) num11) + (double) num6 * (double) num11);
      float num14 = (float) (1.0 * ((double) num10 - (double) num11) + (double) num7 * (double) num11);
      Lighting.defBrightness = (float) (1.20000004768372 * (1.0 - (double) num11) + 1.0 * (double) num11);
      this.bgParrallax = (double) Main.caveParrallax;
      this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num3) - (double) (num3 / 2));
      this.bgLoops = Main.screenWidth / num3 + 2;
      this.bgTop = (int) ((double) ((int) Main.worldSurface * 16 - Main.backgroundHeight[1]) - (double) Main.screenPosition.Y + 16.0);
      for (int index1 = 0; index1 < this.bgLoops; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
        {
          int num15 = (int) (float) Math.Round((double) -(float) Math.IEEERemainder((double) ((float) this.bgStart + Main.screenPosition.X), 16.0));
          if (num15 == -8)
            num15 = 8;
          float num16 = (float) (this.bgStart + num3 * index1 + index2 * 16 + 8);
          float bgTop = (float) this.bgTop;
          Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) (((double) num16 + (double) Main.screenPosition.X) / 16.0), (int) (((double) Main.screenPosition.Y + (double) bgTop) / 16.0));
          color.R = (byte) ((double) color.R * (double) num12);
          color.G = (byte) ((double) color.G * (double) num13);
          color.B = (byte) ((double) color.B * (double) num14);
          this.spriteBatch.Draw(Main.backgroundTexture[1], new Vector2((float) (this.bgStart + num3 * index1 + 16 * index2 + num15), (float) this.bgTop) + vector2, new Rectangle?(new Rectangle(16 * index2 + num15 + 16, 0, 16, 16)), color);
        }
      }
      double num17 = (double) ((int) (((double) (Main.maxTilesY - 230) - Main.worldSurface) / 6.0) * 6);
      double num18 = Main.worldSurface + num17 - 5.0;
      bool flag1 = false;
      bool flag2 = false;
      this.bgTop = (int) ((double) ((int) Main.worldSurface * 16) - (double) Main.screenPosition.Y + 16.0);
      if (Main.worldSurface * 16.0 <= (double) Main.screenPosition.Y + (double) Main.screenHeight + (double) Main.offScreenRange)
      {
        this.bgParrallax = (double) Main.caveParrallax;
        this.bgStart = (int) (-Math.IEEERemainder(96.0 + (double) Main.screenPosition.X * this.bgParrallax, (double) num3) - (double) (num3 / 2)) - (int) vector2.X;
        this.bgLoops = (Main.screenWidth + (int) vector2.X * 2) / num3 + 2;
        if (Main.worldSurface * 16.0 < (double) Main.screenPosition.Y - 16.0)
        {
          this.bgStartY = (int) (Math.IEEERemainder((double) this.bgTop, (double) Main.backgroundHeight[2]) - (double) Main.backgroundHeight[2]);
          this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int) vector2.Y * 2) / Main.backgroundHeight[2] + 1;
        }
        else
        {
          this.bgStartY = this.bgTop;
          this.bgLoopsY = (Main.screenHeight - this.bgTop + (int) vector2.Y * 2) / Main.backgroundHeight[2] + 1;
        }
        if (Main.rockLayer * 16.0 < (double) Main.screenPosition.Y + 600.0)
        {
          this.bgLoopsY = (int) (Main.rockLayer * 16.0 - (double) Main.screenPosition.Y + 600.0 - (double) this.bgStartY) / Main.backgroundHeight[2];
          flag2 = true;
        }
        int num19 = (int) (float) Math.Round((double) -(float) Math.IEEERemainder((double) ((float) this.bgStart + Main.screenPosition.X), 16.0));
        if (num19 == -8)
          num19 = 8;
        for (int index3 = 0; index3 < this.bgLoops; ++index3)
        {
          for (int index4 = 0; index4 < this.bgLoopsY; ++index4)
          {
            for (int index5 = 0; index5 < 6; ++index5)
            {
              for (int index6 = 0; index6 < 6; ++index6)
              {
                float num20 = (float) (this.bgStartY + index4 * 96 + index6 * 16 + 8);
                int x = (int) (((double) (this.bgStart + num3 * index3 + index5 * 16 + 8) + (double) Main.screenPosition.X) / 16.0);
                int index7 = (int) (((double) num20 + (double) Main.screenPosition.Y) / 16.0);
                Microsoft.Xna.Framework.Color color1 = Lighting.GetColor(x, index7);
                if (Main.tile[x, index7] == null)
                  Main.tile[x, index7] = new Tile();
                if (color1.R > (byte) 0 || color1.G > (byte) 0 || color1.B > (byte) 0)
                {
                  if (((int) color1.R > num1 || (double) color1.G > (double) num1 * 1.1 || (double) color1.B > (double) num1 * 1.2) && !Main.tile[x, index7].active)
                  {
                    if (Main.tile[x, index7].wall != (byte) 0)
                    {
                      if (Main.tile[x, index7].wall != (byte) 21)
                        goto label_83;
                    }
                    try
                    {
                      for (int index8 = 0; index8 < 9; ++index8)
                      {
                        int num21 = 0;
                        int num22 = 0;
                        int width = 4;
                        int height = 4;
                        Microsoft.Xna.Framework.Color color2 = color1;
                        Microsoft.Xna.Framework.Color color3 = color1;
                        if (index8 == 0 && !Main.tile[x - 1, index7 - 1].active)
                          color3 = Lighting.GetColor(x - 1, index7 - 1);
                        if (index8 == 1)
                        {
                          width = 8;
                          num21 = 4;
                          if (!Main.tile[x, index7 - 1].active)
                            color3 = Lighting.GetColor(x, index7 - 1);
                        }
                        if (index8 == 2)
                        {
                          if (!Main.tile[x + 1, index7 - 1].active)
                            color3 = Lighting.GetColor(x + 1, index7 - 1);
                          if (Main.tile[x + 1, index7 - 1] == null)
                            Main.tile[x + 1, index7 - 1] = new Tile();
                          num21 = 12;
                        }
                        if (index8 == 3)
                        {
                          if (!Main.tile[x - 1, index7].active)
                            color3 = Lighting.GetColor(x - 1, index7);
                          height = 8;
                          num22 = 4;
                        }
                        if (index8 == 4)
                        {
                          width = 8;
                          height = 8;
                          num21 = 4;
                          num22 = 4;
                        }
                        if (index8 == 5)
                        {
                          num21 = 12;
                          num22 = 4;
                          height = 8;
                          if (!Main.tile[x + 1, index7].active)
                            color3 = Lighting.GetColor(x + 1, index7);
                        }
                        if (index8 == 6)
                        {
                          if (!Main.tile[x - 1, index7 + 1].active)
                            color3 = Lighting.GetColor(x - 1, index7 + 1);
                          num22 = 12;
                        }
                        if (index8 == 7)
                        {
                          width = 8;
                          height = 4;
                          num21 = 4;
                          num22 = 12;
                          if (!Main.tile[x, index7 + 1].active)
                            color3 = Lighting.GetColor(x, index7 + 1);
                        }
                        if (index8 == 8)
                        {
                          if (!Main.tile[x + 1, index7 + 1].active)
                            color3 = Lighting.GetColor(x + 1, index7 + 1);
                          num21 = 12;
                          num22 = 12;
                        }
                        color2.R = (byte) (((int) color1.R + (int) color3.R) / 2);
                        color2.G = (byte) (((int) color1.G + (int) color3.G) / 2);
                        color2.B = (byte) (((int) color1.B + (int) color3.B) / 2);
                        color2.R = (byte) ((double) color2.R * (double) num12);
                        color2.G = (byte) ((double) color2.G * (double) num13);
                        color2.B = (byte) ((double) color2.B * (double) num14);
                        this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float) (this.bgStart + num3 * index3 + 16 * index5 + num21 + num19), (float) (this.bgStartY + Main.backgroundHeight[2] * index4 + 16 * index6 + num22)) + vector2, new Rectangle?(new Rectangle(16 * index5 + num21 + num19 + 16, 16 * index6 + num22, width, height)), color2);
                      }
                      continue;
                    }
                    catch
                    {
                      color1.R = (byte) ((double) color1.R * (double) num12);
                      color1.G = (byte) ((double) color1.G * (double) num13);
                      color1.B = (byte) ((double) color1.B * (double) num14);
                      this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float) (this.bgStart + num3 * index3 + 16 * index5 + num19), (float) (this.bgStartY + Main.backgroundHeight[2] * index4 + 16 * index6)) + vector2, new Rectangle?(new Rectangle(16 * index5 + num19 + 16, 16 * index6, 16, 16)), color1);
                      continue;
                    }
                  }
label_83:
                  if ((int) color1.R > num2 || (double) color1.G > (double) num2 * 1.1 || (double) color1.B > (double) num2 * 1.2)
                  {
                    for (int index9 = 0; index9 < 4; ++index9)
                    {
                      int num23 = 0;
                      int num24 = 0;
                      Microsoft.Xna.Framework.Color color4 = color1;
                      Microsoft.Xna.Framework.Color color5 = color1;
                      if (index9 == 0)
                        color5 = !Lighting.Brighter(x, index7 - 1, x - 1, index7) ? Lighting.GetColor(x, index7 - 1) : Lighting.GetColor(x - 1, index7);
                      if (index9 == 1)
                      {
                        color5 = !Lighting.Brighter(x, index7 - 1, x + 1, index7) ? Lighting.GetColor(x, index7 - 1) : Lighting.GetColor(x + 1, index7);
                        num23 = 8;
                      }
                      if (index9 == 2)
                      {
                        color5 = !Lighting.Brighter(x, index7 + 1, x - 1, index7) ? Lighting.GetColor(x, index7 + 1) : Lighting.GetColor(x - 1, index7);
                        num24 = 8;
                      }
                      if (index9 == 3)
                      {
                        color5 = !Lighting.Brighter(x, index7 + 1, x + 1, index7) ? Lighting.GetColor(x, index7 + 1) : Lighting.GetColor(x + 1, index7);
                        num23 = 8;
                        num24 = 8;
                      }
                      color4.R = (byte) (((int) color1.R + (int) color5.R) / 2);
                      color4.G = (byte) (((int) color1.G + (int) color5.G) / 2);
                      color4.B = (byte) (((int) color1.B + (int) color5.B) / 2);
                      color4.R = (byte) ((double) color4.R * (double) num12);
                      color4.G = (byte) ((double) color4.G * (double) num13);
                      color4.B = (byte) ((double) color4.B * (double) num14);
                      this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float) (this.bgStart + num3 * index3 + 16 * index5 + num23 + num19), (float) (this.bgStartY + Main.backgroundHeight[2] * index4 + 16 * index6 + num24)) + vector2, new Rectangle?(new Rectangle(16 * index5 + num23 + num19 + 16, 16 * index6 + num24, 8, 8)), color4);
                    }
                  }
                  else
                  {
                    color1.R = (byte) ((double) color1.R * (double) num12);
                    color1.G = (byte) ((double) color1.G * (double) num13);
                    color1.B = (byte) ((double) color1.B * (double) num14);
                    this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float) (this.bgStart + num3 * index3 + 16 * index5 + num19), (float) (this.bgStartY + Main.backgroundHeight[2] * index4 + 16 * index6)) + vector2, new Rectangle?(new Rectangle(16 * index5 + num19 + 16, 16 * index6, 16, 16)), color1);
                  }
                }
                else
                {
                  color1.R = (byte) ((double) color1.R * (double) num12);
                  color1.G = (byte) ((double) color1.G * (double) num13);
                  color1.B = (byte) ((double) color1.B * (double) num14);
                  this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float) (this.bgStart + num3 * index3 + 16 * index5 + num19), (float) (this.bgStartY + Main.backgroundHeight[2] * index4 + 16 * index6)) + vector2, new Rectangle?(new Rectangle(16 * index5 + num19 + 16, 16 * index6, 16, 16)), color1);
                }
              }
            }
          }
        }
        if (flag2)
        {
          this.bgParrallax = (double) Main.caveParrallax;
          this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num3) - (double) (num3 / 2));
          this.bgLoops = (Main.screenWidth + (int) vector2.X * 2) / num3 + 2;
          this.bgTop = this.bgStartY + this.bgLoopsY * Main.backgroundHeight[2];
          if (this.bgTop > -32)
          {
            for (int index10 = 0; index10 < this.bgLoops; ++index10)
            {
              for (int index11 = 0; index11 < 6; ++index11)
              {
                float num25 = (float) (this.bgStart + num3 * index10 + index11 * 16 + 8);
                float bgTop = (float) this.bgTop;
                Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) (((double) num25 + (double) Main.screenPosition.X) / 16.0), (int) (((double) Main.screenPosition.Y + (double) bgTop) / 16.0));
                color.R = (byte) ((double) color.R * (double) num12);
                color.G = (byte) ((double) color.G * (double) num13);
                color.B = (byte) ((double) color.B * (double) num14);
                this.spriteBatch.Draw(Main.backgroundTexture[4], new Vector2((float) (this.bgStart + num3 * index10 + 16 * index11 + num19), (float) this.bgTop) + vector2, new Rectangle?(new Rectangle(16 * index11 + num19 + 16, 0, 16, 16)), color);
              }
            }
          }
        }
      }
      this.bgTop = (int) ((double) ((int) Main.rockLayer * 16) - (double) Main.screenPosition.Y + 16.0 + 600.0 - 8.0);
      if (Main.rockLayer * 16.0 <= (double) Main.screenPosition.Y + 600.0)
      {
        this.bgParrallax = (double) Main.caveParrallax;
        this.bgStart = (int) (-Math.IEEERemainder(96.0 + (double) Main.screenPosition.X * this.bgParrallax, (double) num3) - (double) (num3 / 2)) - (int) vector2.X;
        this.bgLoops = (Main.screenWidth + (int) vector2.X * 2) / num3 + 2;
        if (Main.rockLayer * 16.0 + (double) Main.screenHeight < (double) Main.screenPosition.Y - 16.0)
        {
          this.bgStartY = (int) (Math.IEEERemainder((double) this.bgTop, (double) Main.backgroundHeight[3]) - (double) Main.backgroundHeight[3]);
          this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int) vector2.Y * 2) / Main.backgroundHeight[2] + 1;
        }
        else
        {
          this.bgStartY = this.bgTop;
          this.bgLoopsY = (Main.screenHeight - this.bgTop + (int) vector2.Y * 2) / Main.backgroundHeight[2] + 1;
        }
        if (num18 * 16.0 < (double) Main.screenPosition.Y + 600.0)
        {
          this.bgLoopsY = (int) (num18 * 16.0 - (double) Main.screenPosition.Y + 600.0 - (double) this.bgStartY) / Main.backgroundHeight[2];
          flag1 = true;
        }
        int num26 = (int) (float) Math.Round((double) -(float) Math.IEEERemainder((double) ((float) this.bgStart + Main.screenPosition.X), 16.0));
        if (num26 == -8)
          num26 = 8;
        for (int index12 = 0; index12 < this.bgLoops; ++index12)
        {
          for (int index13 = 0; index13 < this.bgLoopsY; ++index13)
          {
            for (int index14 = 0; index14 < 6; ++index14)
            {
              for (int index15 = 0; index15 < 6; ++index15)
              {
                float num27 = (float) (this.bgStartY + index13 * 96 + index15 * 16 + 8);
                int x = (int) (((double) (this.bgStart + num3 * index12 + index14 * 16 + 8) + (double) Main.screenPosition.X) / 16.0);
                int index16 = (int) (((double) num27 + (double) Main.screenPosition.Y) / 16.0);
                Microsoft.Xna.Framework.Color color6 = Lighting.GetColor(x, index16);
                if (Main.tile[x, index16] == null)
                  Main.tile[x, index16] = new Tile();
                bool flag3 = false;
                if ((double) Main.caveParrallax != 0.0)
                {
                  if (Main.tile[x - 1, index16] == null)
                    Main.tile[x - 1, index16] = new Tile();
                  if (Main.tile[x + 1, index16] == null)
                    Main.tile[x + 1, index16] = new Tile();
                  if (Main.tile[x, index16].wall == (byte) 0 || Main.tile[x, index16].wall == (byte) 21 || Main.tile[x - 1, index16].wall == (byte) 0 || Main.tile[x - 1, index16].wall == (byte) 21 || Main.tile[x + 1, index16].wall == (byte) 0 || Main.tile[x + 1, index16].wall == (byte) 21)
                    flag3 = true;
                }
                else if (Main.tile[x, index16].wall == (byte) 0 || Main.tile[x, index16].wall == (byte) 21)
                  flag3 = true;
                if ((flag3 || color6.R == (byte) 0 || color6.G == (byte) 0 || color6.B == (byte) 0) && (color6.R > (byte) 0 || color6.G > (byte) 0 || color6.B > (byte) 0) && (Main.tile[x, index16].wall == (byte) 0 || Main.tile[x, index16].wall == (byte) 21 || (double) Main.caveParrallax != 0.0))
                {
                  if (Lighting.lightMode < 2 && color6.R < (byte) 230 && color6.G < (byte) 230 && color6.B < (byte) 230)
                  {
                    if (((int) color6.R > num1 || (double) color6.G > (double) num1 * 1.1 || (double) color6.B > (double) num1 * 1.2) && !Main.tile[x, index16].active)
                    {
                      for (int index17 = 0; index17 < 9; ++index17)
                      {
                        int num28 = 0;
                        int num29 = 0;
                        int width = 4;
                        int height = 4;
                        Microsoft.Xna.Framework.Color color7 = color6;
                        Microsoft.Xna.Framework.Color color8 = color6;
                        if (index17 == 0 && !Main.tile[x - 1, index16 - 1].active)
                          color8 = Lighting.GetColor(x - 1, index16 - 1);
                        if (index17 == 1)
                        {
                          width = 8;
                          num28 = 4;
                          if (!Main.tile[x, index16 - 1].active)
                            color8 = Lighting.GetColor(x, index16 - 1);
                        }
                        if (index17 == 2)
                        {
                          if (!Main.tile[x + 1, index16 - 1].active)
                            color8 = Lighting.GetColor(x + 1, index16 - 1);
                          num28 = 12;
                        }
                        if (index17 == 3)
                        {
                          if (!Main.tile[x - 1, index16].active)
                            color8 = Lighting.GetColor(x - 1, index16);
                          height = 8;
                          num29 = 4;
                        }
                        if (index17 == 4)
                        {
                          width = 8;
                          height = 8;
                          num28 = 4;
                          num29 = 4;
                        }
                        if (index17 == 5)
                        {
                          num28 = 12;
                          num29 = 4;
                          height = 8;
                          if (!Main.tile[x + 1, index16].active)
                            color8 = Lighting.GetColor(x + 1, index16);
                        }
                        if (index17 == 6)
                        {
                          if (!Main.tile[x - 1, index16 + 1].active)
                            color8 = Lighting.GetColor(x - 1, index16 + 1);
                          num29 = 12;
                        }
                        if (index17 == 7)
                        {
                          width = 8;
                          height = 4;
                          num28 = 4;
                          num29 = 12;
                          if (!Main.tile[x, index16 + 1].active)
                            color8 = Lighting.GetColor(x, index16 + 1);
                        }
                        if (index17 == 8)
                        {
                          if (!Main.tile[x + 1, index16 + 1].active)
                            color8 = Lighting.GetColor(x + 1, index16 + 1);
                          num28 = 12;
                          num29 = 12;
                        }
                        color7.R = (byte) (((int) color6.R + (int) color8.R) / 2);
                        color7.G = (byte) (((int) color6.G + (int) color8.G) / 2);
                        color7.B = (byte) (((int) color6.B + (int) color8.B) / 2);
                        color7.R = (byte) ((double) color7.R * (double) num12);
                        color7.G = (byte) ((double) color7.G * (double) num13);
                        color7.B = (byte) ((double) color7.B * (double) num14);
                        this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float) (this.bgStart + num3 * index12 + 16 * index14 + num28 + num26), (float) (this.bgStartY + Main.backgroundHeight[2] * index13 + 16 * index15 + num29)) + vector2, new Rectangle?(new Rectangle(16 * index14 + num28 + num26 + 16, 16 * index15 + num29, width, height)), color7);
                      }
                    }
                    else if ((int) color6.R > num2 || (double) color6.G > (double) num2 * 1.1 || (double) color6.B > (double) num2 * 1.2)
                    {
                      for (int index18 = 0; index18 < 4; ++index18)
                      {
                        int num30 = 0;
                        int num31 = 0;
                        Microsoft.Xna.Framework.Color color9 = color6;
                        Microsoft.Xna.Framework.Color color10 = color6;
                        if (index18 == 0)
                          color10 = !Lighting.Brighter(x, index16 - 1, x - 1, index16) ? Lighting.GetColor(x, index16 - 1) : Lighting.GetColor(x - 1, index16);
                        if (index18 == 1)
                        {
                          color10 = !Lighting.Brighter(x, index16 - 1, x + 1, index16) ? Lighting.GetColor(x, index16 - 1) : Lighting.GetColor(x + 1, index16);
                          num30 = 8;
                        }
                        if (index18 == 2)
                        {
                          color10 = !Lighting.Brighter(x, index16 + 1, x - 1, index16) ? Lighting.GetColor(x, index16 + 1) : Lighting.GetColor(x - 1, index16);
                          num31 = 8;
                        }
                        if (index18 == 3)
                        {
                          color10 = !Lighting.Brighter(x, index16 + 1, x + 1, index16) ? Lighting.GetColor(x, index16 + 1) : Lighting.GetColor(x + 1, index16);
                          num30 = 8;
                          num31 = 8;
                        }
                        color9.R = (byte) (((int) color6.R + (int) color10.R) / 2);
                        color9.G = (byte) (((int) color6.G + (int) color10.G) / 2);
                        color9.B = (byte) (((int) color6.B + (int) color10.B) / 2);
                        color9.R = (byte) ((double) color9.R * (double) num12);
                        color9.G = (byte) ((double) color9.G * (double) num13);
                        color9.B = (byte) ((double) color9.B * (double) num14);
                        this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float) (this.bgStart + num3 * index12 + 16 * index14 + num30 + num26), (float) (this.bgStartY + Main.backgroundHeight[2] * index13 + 16 * index15 + num31)) + vector2, new Rectangle?(new Rectangle(16 * index14 + num30 + num26 + 16, 16 * index15 + num31, 8, 8)), color9);
                      }
                    }
                    else
                    {
                      color6.R = (byte) ((double) color6.R * (double) num12);
                      color6.G = (byte) ((double) color6.G * (double) num13);
                      color6.B = (byte) ((double) color6.B * (double) num14);
                      this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float) (this.bgStart + num3 * index12 + 16 * index14 + num26), (float) (this.bgStartY + Main.backgroundHeight[2] * index13 + 16 * index15)) + vector2, new Rectangle?(new Rectangle(16 * index14 + num26 + 16, 16 * index15, 16, 16)), color6);
                    }
                  }
                  else
                  {
                    color6.R = (byte) ((double) color6.R * (double) num12);
                    color6.G = (byte) ((double) color6.G * (double) num13);
                    color6.B = (byte) ((double) color6.B * (double) num14);
                    this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float) (this.bgStart + num3 * index12 + 16 * index14 + num26), (float) (this.bgStartY + Main.backgroundHeight[2] * index13 + 16 * index15)) + vector2, new Rectangle?(new Rectangle(16 * index14 + num26 + 16, 16 * index15, 16, 16)), color6);
                  }
                }
              }
            }
          }
        }
        if (flag1)
        {
          this.bgParrallax = (double) Main.caveParrallax;
          this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num3) - (double) (num3 / 2));
          this.bgLoops = Main.screenWidth / num3 + 2;
          this.bgTop = this.bgStartY + this.bgLoopsY * Main.backgroundHeight[2];
          for (int index19 = 0; index19 < this.bgLoops; ++index19)
          {
            for (int index20 = 0; index20 < 6; ++index20)
            {
              float num32 = (float) (this.bgStart + num3 * index19 + index20 * 16 + 8);
              float bgTop = (float) this.bgTop;
              Microsoft.Xna.Framework.Color color = Lighting.GetColor((int) (((double) num32 + (double) Main.screenPosition.X) / 16.0), (int) (((double) Main.screenPosition.Y + (double) bgTop) / 16.0));
              color.R = (byte) ((double) color.R * (double) num12);
              color.G = (byte) ((double) color.G * (double) num13);
              color.B = (byte) ((double) color.B * (double) num14);
              this.spriteBatch.Draw(Main.backgroundTexture[6], new Vector2((float) (this.bgStart + num3 * index19 + 16 * index20 + num26), (float) this.bgTop) + vector2, new Rectangle?(new Rectangle(16 * index20 + num26 + 16, Main.magmaBGFrame * 16, 16, 16)), color);
            }
          }
        }
      }
      this.bgTop = (int) ((double) ((int) num18 * 16) - (double) Main.screenPosition.Y + 16.0 + 600.0) - 8;
      if (num18 * 16.0 <= (double) Main.screenPosition.Y + 600.0)
      {
        this.bgStart = (int) (-Math.IEEERemainder(96.0 + (double) Main.screenPosition.X * this.bgParrallax, (double) num3) - (double) (num3 / 2)) - (int) vector2.X;
        this.bgLoops = (Main.screenWidth + (int) vector2.X * 2) / num3 + 2;
        if (num18 * 16.0 + (double) Main.screenHeight < (double) Main.screenPosition.Y - 16.0)
        {
          this.bgStartY = (int) (Math.IEEERemainder((double) this.bgTop, (double) Main.backgroundHeight[2]) - (double) Main.backgroundHeight[2]);
          this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int) vector2.Y * 2) / Main.backgroundHeight[2] + 1;
        }
        else
        {
          this.bgStartY = this.bgTop;
          this.bgLoopsY = (Main.screenHeight - this.bgTop + (int) vector2.Y * 2) / Main.backgroundHeight[2] + 1;
        }
        int num33 = (int) ((double) num1 * 1.5);
        int num34 = (int) ((double) num2 * 1.5);
        int num35 = (int) (float) Math.Round((double) -(float) Math.IEEERemainder((double) ((float) this.bgStart + Main.screenPosition.X), 16.0));
        if (num35 == -8)
          num35 = 8;
        for (int index21 = 0; index21 < this.bgLoops; ++index21)
        {
          for (int index22 = 0; index22 < this.bgLoopsY; ++index22)
          {
            for (int index23 = 0; index23 < 6; ++index23)
            {
              for (int index24 = 0; index24 < 6; ++index24)
              {
                float num36 = (float) (this.bgStartY + index22 * 96 + index24 * 16 + 8);
                int x = (int) (((double) (this.bgStart + num3 * index21 + index23 * 16 + 8) + (double) Main.screenPosition.X) / 16.0);
                int index25 = (int) (((double) num36 + (double) Main.screenPosition.Y) / 16.0);
                Microsoft.Xna.Framework.Color color11 = Lighting.GetColor(x, index25);
                if (Main.tile[x, index25] == null)
                  Main.tile[x, index25] = new Tile();
                bool flag4 = false;
                if ((double) Main.caveParrallax != 0.0)
                {
                  if (Main.tile[x - 1, index25] == null)
                    Main.tile[x - 1, index25] = new Tile();
                  if (Main.tile[x + 1, index25] == null)
                    Main.tile[x + 1, index25] = new Tile();
                  if (Main.tile[x, index25].wall == (byte) 0 || Main.tile[x, index25].wall == (byte) 21 || Main.tile[x - 1, index25].wall == (byte) 0 || Main.tile[x - 1, index25].wall == (byte) 21 || Main.tile[x + 1, index25].wall == (byte) 0 || Main.tile[x + 1, index25].wall == (byte) 21)
                    flag4 = true;
                }
                else if (Main.tile[x, index25].wall == (byte) 0 || Main.tile[x, index25].wall == (byte) 21)
                  flag4 = true;
                if ((flag4 || color11.R == (byte) 0 || color11.G == (byte) 0 || color11.B == (byte) 0) && (color11.R > (byte) 0 || color11.G > (byte) 0 || color11.B > (byte) 0) && (Main.tile[x, index25].wall == (byte) 0 || Main.tile[x, index25].wall == (byte) 21 || (double) Main.caveParrallax != 0.0))
                {
                  if (Lighting.lightMode < 2 && color11.R < (byte) 230 && color11.G < (byte) 230 && color11.B < (byte) 230)
                  {
                    if (((int) color11.R > num33 || (double) color11.G > (double) num33 * 1.1 || (double) color11.B > (double) num33 * 1.2) && !Main.tile[x, index25].active)
                    {
                      for (int index26 = 0; index26 < 9; ++index26)
                      {
                        int num37 = 0;
                        int num38 = 0;
                        int width = 4;
                        int height = 4;
                        Microsoft.Xna.Framework.Color color12 = color11;
                        Microsoft.Xna.Framework.Color color13 = color11;
                        if (index26 == 0 && !Main.tile[x - 1, index25 - 1].active)
                          color13 = Lighting.GetColor(x - 1, index25 - 1);
                        if (index26 == 1)
                        {
                          width = 8;
                          num37 = 4;
                          if (!Main.tile[x, index25 - 1].active)
                            color13 = Lighting.GetColor(x, index25 - 1);
                        }
                        if (index26 == 2)
                        {
                          if (!Main.tile[x + 1, index25 - 1].active)
                            color13 = Lighting.GetColor(x + 1, index25 - 1);
                          num37 = 12;
                        }
                        if (index26 == 3)
                        {
                          if (!Main.tile[x - 1, index25].active)
                            color13 = Lighting.GetColor(x - 1, index25);
                          height = 8;
                          num38 = 4;
                        }
                        if (index26 == 4)
                        {
                          width = 8;
                          height = 8;
                          num37 = 4;
                          num38 = 4;
                        }
                        if (index26 == 5)
                        {
                          num37 = 12;
                          num38 = 4;
                          height = 8;
                          if (!Main.tile[x + 1, index25].active)
                            color13 = Lighting.GetColor(x + 1, index25);
                        }
                        if (index26 == 6)
                        {
                          if (!Main.tile[x - 1, index25 + 1].active)
                            color13 = Lighting.GetColor(x - 1, index25 + 1);
                          num38 = 12;
                        }
                        if (index26 == 7)
                        {
                          width = 8;
                          height = 4;
                          num37 = 4;
                          num38 = 12;
                          if (!Main.tile[x, index25 + 1].active)
                            color13 = Lighting.GetColor(x, index25 + 1);
                        }
                        if (index26 == 8)
                        {
                          if (!Main.tile[x + 1, index25 + 1].active)
                            color13 = Lighting.GetColor(x + 1, index25 + 1);
                          num37 = 12;
                          num38 = 12;
                        }
                        color12.R = (byte) (((int) color11.R + (int) color13.R) / 2);
                        color12.G = (byte) (((int) color11.G + (int) color13.G) / 2);
                        color12.B = (byte) (((int) color11.B + (int) color13.B) / 2);
                        color12.R = (byte) ((double) color12.R * (double) num12);
                        color12.G = (byte) ((double) color12.G * (double) num13);
                        color12.B = (byte) ((double) color12.B * (double) num14);
                        this.spriteBatch.Draw(Main.backgroundTexture[5], new Vector2((float) (this.bgStart + num3 * index21 + 16 * index23 + num37 + num35), (float) (this.bgStartY + Main.backgroundHeight[2] * index22 + 16 * index24 + num38)) + vector2, new Rectangle?(new Rectangle(16 * index23 + num37 + num35 + 16, 16 * index24 + Main.backgroundHeight[2] * Main.magmaBGFrame + num38, width, height)), color12, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                      }
                    }
                    else if ((int) color11.R > num34 || (double) color11.G > (double) num34 * 1.1 || (double) color11.B > (double) num34 * 1.2)
                    {
                      for (int index27 = 0; index27 < 4; ++index27)
                      {
                        int num39 = 0;
                        int num40 = 0;
                        Microsoft.Xna.Framework.Color color14 = color11;
                        Microsoft.Xna.Framework.Color color15 = color11;
                        if (index27 == 0)
                          color15 = !Lighting.Brighter(x, index25 - 1, x - 1, index25) ? Lighting.GetColor(x, index25 - 1) : Lighting.GetColor(x - 1, index25);
                        if (index27 == 1)
                        {
                          color15 = !Lighting.Brighter(x, index25 - 1, x + 1, index25) ? Lighting.GetColor(x, index25 - 1) : Lighting.GetColor(x + 1, index25);
                          num39 = 8;
                        }
                        if (index27 == 2)
                        {
                          color15 = !Lighting.Brighter(x, index25 + 1, x - 1, index25) ? Lighting.GetColor(x, index25 + 1) : Lighting.GetColor(x - 1, index25);
                          num40 = 8;
                        }
                        if (index27 == 3)
                        {
                          color15 = !Lighting.Brighter(x, index25 + 1, x + 1, index25) ? Lighting.GetColor(x, index25 + 1) : Lighting.GetColor(x + 1, index25);
                          num39 = 8;
                          num40 = 8;
                        }
                        color14.R = (byte) (((int) color11.R + (int) color15.R) / 2);
                        color14.G = (byte) (((int) color11.G + (int) color15.G) / 2);
                        color14.B = (byte) (((int) color11.B + (int) color15.B) / 2);
                        color14.R = (byte) ((double) color14.R * (double) num12);
                        color14.G = (byte) ((double) color14.G * (double) num13);
                        color14.B = (byte) ((double) color14.B * (double) num14);
                        this.spriteBatch.Draw(Main.backgroundTexture[5], new Vector2((float) (this.bgStart + num3 * index21 + 16 * index23 + num39 + num35), (float) (this.bgStartY + Main.backgroundHeight[2] * index22 + 16 * index24 + num40)) + vector2, new Rectangle?(new Rectangle(16 * index23 + num39 + num35 + 16, 16 * index24 + Main.backgroundHeight[2] * Main.magmaBGFrame + num40, 8, 8)), color14, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                      }
                    }
                    else
                    {
                      color11.R = (byte) ((double) color11.R * (double) num12);
                      color11.G = (byte) ((double) color11.G * (double) num13);
                      color11.B = (byte) ((double) color11.B * (double) num14);
                      this.spriteBatch.Draw(Main.backgroundTexture[5], new Vector2((float) (this.bgStart + num3 * index21 + 16 * index23 + num35), (float) (this.bgStartY + Main.backgroundHeight[2] * index22 + 16 * index24)) + vector2, new Rectangle?(new Rectangle(16 * index23 + num35 + 16, 16 * index24 + Main.backgroundHeight[2] * Main.magmaBGFrame, 16, 16)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                    }
                  }
                  else
                  {
                    color11.R = (byte) ((double) color11.R * (double) num12);
                    color11.G = (byte) ((double) color11.G * (double) num13);
                    color11.B = (byte) ((double) color11.B * (double) num14);
                    this.spriteBatch.Draw(Main.backgroundTexture[5], new Vector2((float) (this.bgStart + num3 * index21 + 16 * index23 + num35), (float) (this.bgStartY + Main.backgroundHeight[2] * index22 + 16 * index24)) + vector2, new Rectangle?(new Rectangle(16 * index23 + num35 + 16, 16 * index24 + Main.backgroundHeight[2] * Main.magmaBGFrame, 16, 16)), color11, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                  }
                }
              }
            }
          }
        }
      }
      Lighting.brightness = Lighting.defBrightness;
      Main.renderTimer[3] = (float) stopwatch.ElapsedMilliseconds;
    }

    protected void RenderBackground()
    {
      if (Main.drawToScreen)
        return;
      this.GraphicsDevice.SetRenderTarget(this.backWaterTarget);
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      try
      {
        this.DrawWater(true);
      }
      catch
      {
      }
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.GraphicsDevice.SetRenderTarget(this.backgroundTarget);
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      this.DrawBackground();
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    protected void RenderTiles()
    {
      if (Main.drawToScreen)
        return;
      this.RenderBlack();
      this.GraphicsDevice.SetRenderTarget(this.tileTarget);
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      this.DrawTiles();
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    protected void RenderTiles2()
    {
      if (Main.drawToScreen)
        return;
      this.GraphicsDevice.SetRenderTarget(this.tile2Target);
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      this.DrawTiles(false);
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    protected void RenderWater()
    {
      if (Main.drawToScreen)
        return;
      this.GraphicsDevice.SetRenderTarget(this.waterTarget);
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      try
      {
        this.DrawWater();
        if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
          this.DrawWires();
      }
      catch
      {
      }
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    protected bool FullTile(int x, int y)
    {
      if (Main.tile[x, y].active && Main.tileSolid[(int) Main.tile[x, y].type] && !Main.tileSolidTop[(int) Main.tile[x, y].type] && Main.tile[x, y].type != (byte) 10 && Main.tile[x, y].type != (byte) 54 && Main.tile[x, y].type != (byte) 138)
      {
        int frameX = (int) Main.tile[x, y].frameX;
        int frameY = (int) Main.tile[x, y].frameY;
        if (frameY == 18)
        {
          if (frameX >= 18 && frameX <= 54 || frameX >= 108 && frameX <= 144)
            return true;
        }
        else if (frameY >= 90 && frameY <= 196 && (frameX <= 70 || frameX >= 144 && frameX <= 232))
          return true;
      }
      return false;
    }

    protected void DrawBlack()
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      Vector2 vector2 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2 = new Vector2();
      int num1 = ((int) Main.tileColor.R + (int) Main.tileColor.G + (int) Main.tileColor.B) / 3;
      float num2 = (float) num1 * 0.4f / (float) byte.MaxValue;
      switch (Lighting.lightMode)
      {
        case 2:
          num2 = (float) ((int) Main.tileColor.R - 55) / (float) byte.MaxValue;
          break;
        case 3:
          num2 = (float) (num1 - 55) / (float) byte.MaxValue;
          break;
      }
      int num3 = (int) (((double) Main.screenPosition.X - (double) vector2.X) / 16.0 - 1.0);
      int num4 = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth + (double) vector2.X) / 16.0) + 2;
      int num5 = (int) (((double) Main.screenPosition.Y - (double) vector2.Y) / 16.0 - 1.0);
      int num6 = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight + (double) vector2.Y) / 16.0) + 5;
      int num7 = Main.offScreenRange / 16;
      int num8 = Main.offScreenRange / 16;
      if (num3 - num7 < 0)
        num3 = num7;
      if (num4 + num7 > Main.maxTilesX)
        num4 = Main.maxTilesX - num7;
      if (num5 - num8 < 0)
        num5 = num8;
      if (num6 + num8 > Main.maxTilesY)
        num6 = Main.maxTilesY - num8;
      for (int index1 = num5 - num8; index1 < num6 + num8; ++index1)
      {
        if ((double) index1 <= Main.worldSurface)
        {
          for (int index2 = num3 - num7; index2 < num4 + num7; ++index2)
          {
            if (Main.tile[index2, index1] == null)
              Main.tile[index2, index1] = new Tile();
            if ((double) Lighting.Brightness(index2, index1) < (double) num2 && (Main.tile[index2, index1].liquid < (byte) 250 || WorldGen.SolidTile(index2, index1) || Main.tile[index2, index1].liquid > (byte) 250 && (double) Lighting.Brightness(index2, index1) == 0.0))
            {
              int num9 = index2;
              int index3 = index2 + 1;
              while (Main.tile[index3, index1] != null && (double) Lighting.Brightness(index3, index1) < (double) num2 && (Main.tile[index3, index1].liquid < (byte) 250 || WorldGen.SolidTile(index3, index1) || Main.tile[index3, index1].liquid > (byte) 250 && (double) Lighting.Brightness(index3, index1) == 0.0))
              {
                ++index3;
                if (index3 >= num4 + num7)
                  break;
              }
              index2 = index3 - 1;
              int width = (index2 - num9 + 1) * 16;
              this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float) (num9 * 16 - (int) Main.screenPosition.X), (float) (index1 * 16 - (int) Main.screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(0, 0, width, 16)), Microsoft.Xna.Framework.Color.Black, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
      }
      Main.renderTimer[5] = (float) stopwatch.ElapsedMilliseconds;
    }

    protected void RenderBlack()
    {
      if (Main.drawToScreen)
        return;
      this.GraphicsDevice.SetRenderTarget(this.blackTarget);
      this.GraphicsDevice.DepthStencilState = new DepthStencilState()
      {
        DepthBufferEnable = true
      };
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      this.DrawBlack();
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    protected void DrawWalls()
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      int num1 = (int) ((double) byte.MaxValue * (1.0 - (double) Main.gfxQuality) + 100.0 * (double) Main.gfxQuality);
      int num2 = (int) (120.0 * (1.0 - (double) Main.gfxQuality) + 40.0 * (double) Main.gfxQuality);
      Vector2 vector2 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2 = new Vector2();
      int num3 = ((int) Main.tileColor.R + (int) Main.tileColor.G + (int) Main.tileColor.B) / 3;
      float num4 = (float) num3 * 0.53f / (float) byte.MaxValue;
      if (Lighting.lightMode == 2)
        num4 = (float) ((int) Main.tileColor.R - 12) / (float) byte.MaxValue;
      if (Lighting.lightMode == 3)
        num4 = (float) (num3 - 12) / (float) byte.MaxValue;
      int num5 = (int) (((double) Main.screenPosition.X - (double) vector2.X) / 16.0 - 1.0);
      int num6 = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth + (double) vector2.X) / 16.0) + 2;
      int num7 = (int) (((double) Main.screenPosition.Y - (double) vector2.Y) / 16.0 - 1.0);
      int num8 = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight + (double) vector2.Y) / 16.0) + 5;
      int num9 = Main.offScreenRange / 16;
      int num10 = Main.offScreenRange / 16;
      if (num5 - num9 < 0)
        num5 = num9;
      if (num6 + num9 > Main.maxTilesX)
        num6 = Main.maxTilesX - num9;
      if (num7 - num10 < 0)
        num7 = num10;
      if (num8 + num10 > Main.maxTilesY)
        num8 = Main.maxTilesY - num10;
      for (int index1 = num7 - num10; index1 < num8 + num10; ++index1)
      {
        if ((double) index1 <= Main.worldSurface)
        {
          for (int index2 = num5 - num9; index2 < num6 + num9; ++index2)
          {
            if (Main.tile[index2, index1] == null)
              Main.tile[index2, index1] = new Tile();
            if ((double) Lighting.Brightness(index2, index1) < (double) num4 && (Main.tile[index2, index1].liquid < (byte) 250 || WorldGen.SolidTile(index2, index1) || Main.tile[index2, index1].liquid > (byte) 250 && (double) Lighting.Brightness(index2, index1) == 0.0))
              this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float) (index2 * 16 - (int) Main.screenPosition.X), (float) (index1 * 16 - (int) Main.screenPosition.Y)) + vector2, Lighting.GetBlackness(index2, index1));
          }
        }
      }
      for (int index3 = num7 - num10; index3 < num8 + num10; ++index3)
      {
        for (int index4 = num5 - num9; index4 < num6 + num9; ++index4)
        {
          if (Main.tile[index4, index3] == null)
            Main.tile[index4, index3] = new Tile();
          if (Main.tile[index4, index3].wall > (byte) 0 && (double) Lighting.Brightness(index4, index3) > 0.0 && !this.FullTile(index4, index3))
          {
            Microsoft.Xna.Framework.Color color1 = Lighting.GetColor(index4, index3);
            Rectangle rectangle;
            if (Lighting.lightMode < 2 && Main.tile[index4, index3].wall != (byte) 21 && !WorldGen.SolidTile(index4, index3))
            {
              if ((int) color1.R > num1 || (double) color1.G > (double) num1 * 1.1 || (double) color1.B > (double) num1 * 1.2)
              {
                for (int index5 = 0; index5 < 9; ++index5)
                {
                  int num11 = 0;
                  int num12 = 0;
                  int width = 12;
                  int height = 12;
                  Microsoft.Xna.Framework.Color color2 = color1;
                  Microsoft.Xna.Framework.Color color3 = color1;
                  if (index5 == 0)
                    color3 = Lighting.GetColor(index4 - 1, index3 - 1);
                  if (index5 == 1)
                  {
                    width = 8;
                    num11 = 12;
                    color3 = Lighting.GetColor(index4, index3 - 1);
                  }
                  if (index5 == 2)
                  {
                    color3 = Lighting.GetColor(index4 + 1, index3 - 1);
                    num11 = 20;
                  }
                  if (index5 == 3)
                  {
                    color3 = Lighting.GetColor(index4 - 1, index3);
                    height = 8;
                    num12 = 12;
                  }
                  if (index5 == 4)
                  {
                    width = 8;
                    height = 8;
                    num11 = 12;
                    num12 = 12;
                  }
                  if (index5 == 5)
                  {
                    num11 = 20;
                    num12 = 12;
                    height = 8;
                    color3 = Lighting.GetColor(index4 + 1, index3);
                  }
                  if (index5 == 6)
                  {
                    color3 = Lighting.GetColor(index4 - 1, index3 + 1);
                    num12 = 20;
                  }
                  if (index5 == 7)
                  {
                    width = 12;
                    num11 = 12;
                    num12 = 20;
                    color3 = Lighting.GetColor(index4, index3 + 1);
                  }
                  if (index5 == 8)
                  {
                    color3 = Lighting.GetColor(index4 + 1, index3 + 1);
                    num11 = 20;
                    num12 = 20;
                  }
                  color2.R = (byte) (((int) color1.R + (int) color3.R) / 2);
                  color2.G = (byte) (((int) color1.G + (int) color3.G) / 2);
                  color2.B = (byte) (((int) color1.B + (int) color3.B) / 2);
                  this.spriteBatch.Draw(Main.wallTexture[(int) Main.tile[index4, index3].wall], new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X - 8 + num11), (float) (index3 * 16 - (int) Main.screenPosition.Y - 8 + num12)) + vector2, new Rectangle?(new Rectangle((int) Main.tile[index4, index3].wallFrameX * 2 + num11, (int) Main.tile[index4, index3].wallFrameY * 2 + num12, width, height)), color2, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
              else if ((int) color1.R > num2 || (double) color1.G > (double) num2 * 1.1 || (double) color1.B > (double) num2 * 1.2)
              {
                for (int index6 = 0; index6 < 4; ++index6)
                {
                  int num13 = 0;
                  int num14 = 0;
                  Microsoft.Xna.Framework.Color color4 = color1;
                  Microsoft.Xna.Framework.Color color5 = color1;
                  if (index6 == 0)
                    color5 = !Lighting.Brighter(index4, index3 - 1, index4 - 1, index3) ? Lighting.GetColor(index4, index3 - 1) : Lighting.GetColor(index4 - 1, index3);
                  if (index6 == 1)
                  {
                    color5 = !Lighting.Brighter(index4, index3 - 1, index4 + 1, index3) ? Lighting.GetColor(index4, index3 - 1) : Lighting.GetColor(index4 + 1, index3);
                    num13 = 16;
                  }
                  if (index6 == 2)
                  {
                    color5 = !Lighting.Brighter(index4, index3 + 1, index4 - 1, index3) ? Lighting.GetColor(index4, index3 + 1) : Lighting.GetColor(index4 - 1, index3);
                    num14 = 16;
                  }
                  if (index6 == 3)
                  {
                    color5 = !Lighting.Brighter(index4, index3 + 1, index4 + 1, index3) ? Lighting.GetColor(index4, index3 + 1) : Lighting.GetColor(index4 + 1, index3);
                    num13 = 16;
                    num14 = 16;
                  }
                  color4.R = (byte) (((int) color1.R + (int) color5.R) / 2);
                  color4.G = (byte) (((int) color1.G + (int) color5.G) / 2);
                  color4.B = (byte) (((int) color1.B + (int) color5.B) / 2);
                  this.spriteBatch.Draw(Main.wallTexture[(int) Main.tile[index4, index3].wall], new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X - 8 + num13), (float) (index3 * 16 - (int) Main.screenPosition.Y - 8 + num14)) + vector2, new Rectangle?(new Rectangle((int) Main.tile[index4, index3].wallFrameX * 2 + num13, (int) Main.tile[index4, index3].wallFrameY * 2 + num14, 16, 16)), color4, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
              else
              {
                rectangle = new Rectangle((int) Main.tile[index4, index3].wallFrameX * 2, (int) Main.tile[index4, index3].wallFrameY * 2, 32, 32);
                this.spriteBatch.Draw(Main.wallTexture[(int) Main.tile[index4, index3].wall], new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X - 8), (float) (index3 * 16 - (int) Main.screenPosition.Y - 8)) + vector2, new Rectangle?(rectangle), Lighting.GetColor(index4, index3), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
            }
            else
            {
              rectangle = new Rectangle((int) Main.tile[index4, index3].wallFrameX * 2, (int) Main.tile[index4, index3].wallFrameY * 2, 32, 32);
              this.spriteBatch.Draw(Main.wallTexture[(int) Main.tile[index4, index3].wall], new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X - 8), (float) (index3 * 16 - (int) Main.screenPosition.Y - 8)) + vector2, new Rectangle?(rectangle), Lighting.GetColor(index4, index3), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            if ((double) color1.R > (double) num2 * 0.4 || (double) color1.G > (double) num2 * 0.35 || (double) color1.B > (double) num2 * 0.3)
            {
              bool flag1 = false;
              if (Main.tile[index4 - 1, index3].wall > (byte) 0 && Main.wallBlend[(int) Main.tile[index4 - 1, index3].wall] != Main.wallBlend[(int) Main.tile[index4, index3].wall])
                flag1 = true;
              bool flag2 = false;
              if (Main.tile[index4 + 1, index3].wall > (byte) 0 && Main.wallBlend[(int) Main.tile[index4 + 1, index3].wall] != Main.wallBlend[(int) Main.tile[index4, index3].wall])
                flag2 = true;
              bool flag3 = false;
              if (Main.tile[index4, index3 - 1].wall > (byte) 0 && Main.wallBlend[(int) Main.tile[index4, index3 - 1].wall] != Main.wallBlend[(int) Main.tile[index4, index3].wall])
                flag3 = true;
              bool flag4 = false;
              if (Main.tile[index4, index3 + 1].wall > (byte) 0 && Main.wallBlend[(int) Main.tile[index4, index3 + 1].wall] != Main.wallBlend[(int) Main.tile[index4, index3].wall])
                flag4 = true;
              if (flag1)
                this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X), (float) (index3 * 16 - (int) Main.screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(0, 0, 2, 16)), Lighting.GetColor(index4, index3), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              if (flag2)
                this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X + 14), (float) (index3 * 16 - (int) Main.screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(14, 0, 2, 16)), Lighting.GetColor(index4, index3), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              if (flag3)
                this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X), (float) (index3 * 16 - (int) Main.screenPosition.Y)) + vector2, new Rectangle?(new Rectangle(0, 0, 16, 2)), Lighting.GetColor(index4, index3), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              if (flag4)
                this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float) (index4 * 16 - (int) Main.screenPosition.X), (float) (index3 * 16 - (int) Main.screenPosition.Y + 14)) + vector2, new Rectangle?(new Rectangle(0, 14, 16, 2)), Lighting.GetColor(index4, index3), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
          }
        }
      }
      Main.renderTimer[2] = (float) stopwatch.ElapsedMilliseconds;
    }

    protected void RenderWalls()
    {
      if (Main.drawToScreen)
        return;
      this.GraphicsDevice.SetRenderTarget(this.wallTarget);
      this.GraphicsDevice.DepthStencilState = new DepthStencilState()
      {
        DepthBufferEnable = true
      };
      this.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0, 0, 0, 0));
      this.spriteBatch.Begin();
      this.DrawWalls();
      this.spriteBatch.End();
      this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
    }

    protected void ReleaseTargets()
    {
      try
      {
        if (Main.dedServ)
          return;
        Main.offScreenRange = 0;
        Main.targetSet = false;
        this.waterTarget.Dispose();
        this.backWaterTarget.Dispose();
        this.blackTarget.Dispose();
        this.tileTarget.Dispose();
        this.tile2Target.Dispose();
        this.wallTarget.Dispose();
        this.backgroundTarget.Dispose();
      }
      catch
      {
      }
    }

    protected void InitTargets()
    {
      try
      {
        if (Main.dedServ)
          return;
        Main.offScreenRange = 192;
        Main.targetSet = true;
        if (this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2 > 2048)
          Main.offScreenRange = (2048 - this.GraphicsDevice.PresentationParameters.BackBufferWidth) / 2;
        this.waterTarget = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
        this.backWaterTarget = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
        this.blackTarget = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
        this.tileTarget = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
        this.tile2Target = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
        this.wallTarget = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
        this.backgroundTarget = new RenderTarget2D(this.GraphicsDevice, this.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, this.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
      }
      catch
      {
        Lighting.lightMode = 2;
        try
        {
          this.ReleaseTargets();
        }
        catch
        {
        }
      }
    }

    protected void DrawWires()
    {
      int num1 = (int) (50.0 * (1.0 - (double) Main.gfxQuality) + 2.0 * (double) Main.gfxQuality);
      Vector2 vector2 = new Vector2((float) Main.offScreenRange, (float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2 = new Vector2();
      int num2 = (int) (((double) Main.screenPosition.X - (double) vector2.X) / 16.0 - 1.0);
      int num3 = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth + (double) vector2.X) / 16.0) + 2;
      int num4 = (int) (((double) Main.screenPosition.Y - (double) vector2.Y) / 16.0 - 1.0);
      int num5 = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight + (double) vector2.Y) / 16.0) + 5;
      if (num2 < 0)
        num2 = 0;
      if (num3 > Main.maxTilesX)
        num3 = Main.maxTilesX;
      if (num4 < 0)
        num4 = 0;
      if (num5 > Main.maxTilesY)
        num5 = Main.maxTilesY;
      for (int index1 = num4; index1 < num5; ++index1)
      {
        for (int x = num2; x < num3; ++x)
        {
          if (Main.tile[x, index1].wire && (double) Lighting.Brightness(x, index1) > 0.0)
          {
            Rectangle rectangle = new Rectangle(0, 0, 16, 16);
            bool wire1 = Main.tile[x, index1 - 1].wire;
            bool wire2 = Main.tile[x, index1 + 1].wire;
            bool wire3 = Main.tile[x - 1, index1].wire;
            bool wire4 = Main.tile[x + 1, index1].wire;
            rectangle = !wire1 ? (!wire2 ? (!wire3 ? (!wire4 ? new Rectangle(0, 54, 16, 16) : new Rectangle(72, 36, 16, 16)) : (!wire4 ? new Rectangle(54, 36, 16, 16) : new Rectangle(18, 0, 16, 16))) : (!wire3 ? (!wire4 ? new Rectangle(18, 36, 16, 16) : new Rectangle(0, 36, 16, 16)) : (!wire4 ? new Rectangle(72, 18, 16, 16) : new Rectangle(72, 0, 16, 16)))) : (!wire2 ? (!wire3 ? (!wire4 ? new Rectangle(36, 36, 16, 16) : new Rectangle(36, 18, 16, 16)) : (!wire4 ? new Rectangle(54, 18, 16, 16) : new Rectangle(0, 18, 16, 16))) : (!wire3 ? (!wire4 ? new Rectangle(0, 0, 16, 16) : new Rectangle(36, 0, 16, 16)) : (!wire4 ? new Rectangle(54, 0, 16, 16) : new Rectangle(18, 18, 16, 16))));
            Microsoft.Xna.Framework.Color color1 = Lighting.GetColor(x, index1);
            if (Lighting.lightMode < 2 && ((int) color1.R > num1 || (double) color1.G > (double) num1 * 1.1 || (double) color1.B > (double) num1 * 1.2))
            {
              for (int index2 = 0; index2 < 4; ++index2)
              {
                int num6 = 0;
                int num7 = 0;
                Microsoft.Xna.Framework.Color color2 = color1;
                Microsoft.Xna.Framework.Color color3 = color1;
                if (index2 == 0)
                  color3 = !Lighting.Brighter(x, index1 - 1, x - 1, index1) ? Lighting.GetColor(x, index1 - 1) : Lighting.GetColor(x - 1, index1);
                if (index2 == 1)
                {
                  color3 = !Lighting.Brighter(x, index1 - 1, x + 1, index1) ? Lighting.GetColor(x, index1 - 1) : Lighting.GetColor(x + 1, index1);
                  num6 = 8;
                }
                if (index2 == 2)
                {
                  color3 = !Lighting.Brighter(x, index1 + 1, x - 1, index1) ? Lighting.GetColor(x, index1 + 1) : Lighting.GetColor(x - 1, index1);
                  num7 = 8;
                }
                if (index2 == 3)
                {
                  color3 = !Lighting.Brighter(x, index1 + 1, x + 1, index1) ? Lighting.GetColor(x, index1 + 1) : Lighting.GetColor(x + 1, index1);
                  num6 = 8;
                  num7 = 8;
                }
                color2.R = (byte) (((int) color1.R + (int) color3.R) / 2);
                color2.G = (byte) (((int) color1.G + (int) color3.G) / 2);
                color2.B = (byte) (((int) color1.B + (int) color3.B) / 2);
                this.spriteBatch.Draw(Main.wireTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X + num6), (float) (index1 * 16 - (int) Main.screenPosition.Y + num7)) + vector2, new Rectangle?(new Rectangle(rectangle.X + num6, rectangle.Y + num7, 8, 8)), color2, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
              }
            }
            else
              this.spriteBatch.Draw(Main.wireTexture, new Vector2((float) (x * 16 - (int) Main.screenPosition.X), (float) (index1 * 16 - (int) Main.screenPosition.Y)) + vector2, new Rectangle?(rectangle), color1, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
          }
        }
      }
    }

    protected override void Draw(GameTime gameTime)
    {
      Main.drawToScreen = Lighting.lightMode >= 2;
      if (Main.drawToScreen && Main.targetSet)
        this.ReleaseTargets();
      if (!Main.drawToScreen && !Main.targetSet)
        this.InitTargets();
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      ++Main.fpsCount;
      if (!this.IsActive)
        Main.maxQ = true;
      if (!Main.dedServ)
      {
        bool flag = false;
        int screenWidth = Main.screenWidth;
        Viewport viewport = this.GraphicsDevice.Viewport;
        int width = viewport.Width;
        if (screenWidth == width)
        {
          int screenHeight = Main.screenHeight;
          viewport = this.GraphicsDevice.Viewport;
          int height = viewport.Height;
          if (screenHeight == height)
            goto label_11;
        }
        flag = true;
        if (Main.gamePaused)
          Main.renderNow = true;
label_11:
        viewport = this.GraphicsDevice.Viewport;
        Main.screenWidth = viewport.Width;
        viewport = this.GraphicsDevice.Viewport;
        Main.screenHeight = viewport.Height;
        if (Main.screenWidth > Main.maxScreenW)
        {
          Main.screenWidth = Main.maxScreenW;
          flag = true;
        }
        if (Main.screenHeight > Main.maxScreenH)
        {
          Main.screenHeight = Main.maxScreenH;
          flag = true;
        }
        if (Main.screenWidth < Main.minScreenW)
        {
          Main.screenWidth = Main.minScreenW;
          flag = true;
        }
        if (Main.screenHeight < Main.minScreenH)
        {
          Main.screenHeight = Main.minScreenH;
          flag = true;
        }
        if (flag)
        {
          this.graphics.PreferredBackBufferWidth = Main.screenWidth;
          this.graphics.PreferredBackBufferHeight = Main.screenHeight;
          this.graphics.ApplyChanges();
          if (!Main.drawToScreen)
            this.InitTargets();
        }
      }
      Main.CursorColor();
      ++Main.drawTime;
      Main.screenLastPosition = Main.screenPosition;
      if (Main.stackSplit == 0)
      {
        Main.stackCounter = 0;
        Main.stackDelay = 7;
      }
      else
      {
        ++Main.stackCounter;
        if (Main.stackCounter >= 30)
        {
          --Main.stackDelay;
          if (Main.stackDelay < 2)
            Main.stackDelay = 2;
          Main.stackCounter = 0;
        }
      }
      Main.mouseTextColor += (byte) Main.mouseTextColorChange;
      if (Main.mouseTextColor >= (byte) 250)
        Main.mouseTextColorChange = -4;
      if (Main.mouseTextColor <= (byte) 175)
        Main.mouseTextColorChange = 4;
      if (Main.myPlayer >= 0)
        Main.player[Main.myPlayer].mouseInterface = false;
      Main.toolTip = new Item();
      if (!Main.gameMenu && Main.netMode != 2)
      {
        Main.screenPosition.X = (float) ((double) Main.player[Main.myPlayer].position.X + (double) Main.player[Main.myPlayer].width * 0.5 - (double) Main.screenWidth * 0.5);
        Main.screenPosition.Y = (float) ((double) Main.player[Main.myPlayer].position.Y + (double) Main.player[Main.myPlayer].height * 0.5 - (double) Main.screenHeight * 0.5);
        Main.screenPosition.X = (float) (int) Main.screenPosition.X;
        Main.screenPosition.Y = (float) (int) Main.screenPosition.Y;
      }
      if (!Main.gameMenu && Main.netMode != 2)
      {
        if ((double) Main.screenPosition.X < (double) Main.leftWorld + (double) (Lighting.offScreenTiles * 16) + 16.0)
          Main.screenPosition.X = (float) ((double) Main.leftWorld + (double) (Lighting.offScreenTiles * 16) + 16.0);
        else if ((double) Main.screenPosition.X + (double) Main.screenWidth > (double) Main.rightWorld - (double) (Lighting.offScreenTiles * 16) - 32.0)
          Main.screenPosition.X = (float) ((double) Main.rightWorld - (double) Main.screenWidth - (double) (Lighting.offScreenTiles * 16) - 32.0);
        if ((double) Main.screenPosition.Y < (double) Main.topWorld + (double) (Lighting.offScreenTiles * 16) + 16.0)
          Main.screenPosition.Y = (float) ((double) Main.topWorld + (double) (Lighting.offScreenTiles * 16) + 16.0);
        else if ((double) Main.screenPosition.Y + (double) Main.screenHeight > (double) Main.bottomWorld - (double) (Lighting.offScreenTiles * 16) - 32.0)
          Main.screenPosition.Y = (float) ((double) Main.bottomWorld - (double) Main.screenHeight - (double) (Lighting.offScreenTiles * 16) - 32.0);
      }
      if (Main.showSplash)
      {
        this.DrawSplash(gameTime);
      }
      else
      {
        if (!Main.gameMenu)
        {
          if (Main.renderNow)
          {
            Main.screenLastPosition = Main.screenPosition;
            Main.renderNow = false;
            Main.renderCount = 99;
            int tempLightCount = Lighting.tempLightCount;
            this.Draw(gameTime);
            Lighting.tempLightCount = tempLightCount;
            Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
            Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
            this.RenderTiles();
            Main.sceneTilePos.X = Main.screenPosition.X - (float) Main.offScreenRange;
            Main.sceneTilePos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            this.RenderBackground();
            Main.sceneBackgroundPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
            Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            this.RenderWalls();
            Main.sceneWallPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
            Main.sceneWallPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            this.RenderTiles2();
            Main.sceneTile2Pos.X = Main.screenPosition.X - (float) Main.offScreenRange;
            Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            this.RenderWater();
            Main.sceneWaterPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
            Main.sceneWaterPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            Main.renderCount = 99;
          }
          else
          {
            if (Main.renderCount == 3)
            {
              this.RenderTiles();
              Main.sceneTilePos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneTilePos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if (Main.renderCount == 2)
            {
              this.RenderBackground();
              Main.sceneBackgroundPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if (Main.renderCount == 2)
            {
              this.RenderWalls();
              Main.sceneWallPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneWallPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if (Main.renderCount == 3)
            {
              this.RenderTiles2();
              Main.sceneTile2Pos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if (Main.renderCount == 1)
            {
              this.RenderWater();
              Main.sceneWaterPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneWaterPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
          }
          if (Main.render && !Main.gameMenu)
          {
            if ((double) Math.Abs(Main.sceneTilePos.X - (Main.screenPosition.X - (float) Main.offScreenRange)) > (double) Main.offScreenRange || (double) Math.Abs(Main.sceneTilePos.Y - (Main.screenPosition.Y - (float) Main.offScreenRange)) > (double) Main.offScreenRange)
            {
              this.RenderTiles();
              Main.sceneTilePos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneTilePos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if ((double) Math.Abs(Main.sceneTile2Pos.X - (Main.screenPosition.X - (float) Main.offScreenRange)) > (double) Main.offScreenRange || (double) Math.Abs(Main.sceneTile2Pos.Y - (Main.screenPosition.Y - (float) Main.offScreenRange)) > (double) Main.offScreenRange)
            {
              this.RenderTiles2();
              Main.sceneTile2Pos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if ((double) Math.Abs(Main.sceneBackgroundPos.X - (Main.screenPosition.X - (float) Main.offScreenRange)) > (double) Main.offScreenRange || (double) Math.Abs(Main.sceneBackgroundPos.Y - (Main.screenPosition.Y - (float) Main.offScreenRange)) > (double) Main.offScreenRange)
            {
              this.RenderBackground();
              Main.sceneBackgroundPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if ((double) Math.Abs(Main.sceneWallPos.X - (Main.screenPosition.X - (float) Main.offScreenRange)) > (double) Main.offScreenRange || (double) Math.Abs(Main.sceneWallPos.Y - (Main.screenPosition.Y - (float) Main.offScreenRange)) > (double) Main.offScreenRange)
            {
              this.RenderWalls();
              Main.sceneWallPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneWallPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
            if ((double) Math.Abs(Main.sceneWaterPos.X - (Main.screenPosition.X - (float) Main.offScreenRange)) > (double) Main.offScreenRange || (double) Math.Abs(Main.sceneWaterPos.Y - (Main.screenPosition.Y - (float) Main.offScreenRange)) > (double) Main.offScreenRange)
            {
              this.RenderWater();
              Main.sceneWaterPos.X = Main.screenPosition.X - (float) Main.offScreenRange;
              Main.sceneWaterPos.Y = Main.screenPosition.Y - (float) Main.offScreenRange;
            }
          }
        }
        this.bgParrallax = 0.1;
        this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) Main.backgroundWidth[Main.background]) - (double) (Main.backgroundWidth[Main.background] / 2));
        this.bgLoops = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
        this.bgStartY = 0;
        this.bgLoopsY = 0;
        this.bgTop = (int) (-(double) Main.screenPosition.Y / (Main.worldSurface * 16.0 - 600.0) * 200.0);
        Main.bgColor = Microsoft.Xna.Framework.Color.White;
        if (Main.gameMenu || Main.netMode == 2)
          this.bgTop = -200;
        int num1 = (int) (Main.time / 54000.0 * (double) (Main.screenWidth + Main.sunTexture.Width * 2)) - Main.sunTexture.Width;
        int num2 = 0;
        Microsoft.Xna.Framework.Color white1 = Microsoft.Xna.Framework.Color.White;
        float scale1 = 1f;
        float rotation1 = (float) (Main.time / 54000.0 * 2.0 - 7.30000019073486);
        int num3 = (int) (Main.time / 32400.0 * (double) (Main.screenWidth + Main.moonTexture.Width * 2)) - Main.moonTexture.Width;
        int num4 = 0;
        Microsoft.Xna.Framework.Color white2 = Microsoft.Xna.Framework.Color.White;
        float scale2 = 1f;
        float rotation2 = (float) (Main.time / 32400.0 * 2.0 - 7.30000019073486);
        if (Main.dayTime)
        {
          double num5;
          if (Main.time < 27000.0)
          {
            num5 = Math.Pow(1.0 - Main.time / 54000.0 * 2.0, 2.0);
            num2 = (int) ((double) this.bgTop + num5 * 250.0 + 180.0);
          }
          else
          {
            num5 = Math.Pow((Main.time / 54000.0 - 0.5) * 2.0, 2.0);
            num2 = (int) ((double) this.bgTop + num5 * 250.0 + 180.0);
          }
          scale1 = (float) (1.2 - num5 * 0.4);
        }
        else
        {
          double num6;
          if (Main.time < 16200.0)
          {
            num6 = Math.Pow(1.0 - Main.time / 32400.0 * 2.0, 2.0);
            num4 = (int) ((double) this.bgTop + num6 * 250.0 + 180.0);
          }
          else
          {
            num6 = Math.Pow((Main.time / 32400.0 - 0.5) * 2.0, 2.0);
            num4 = (int) ((double) this.bgTop + num6 * 250.0 + 180.0);
          }
          scale2 = (float) (1.2 - num6 * 0.4);
        }
        if (Main.dayTime)
        {
          if (Main.time < 13500.0)
          {
            float num7 = (float) (Main.time / 13500.0);
            white1.R = (byte) ((double) num7 * 200.0 + 55.0);
            white1.G = (byte) ((double) num7 * 180.0 + 75.0);
            white1.B = (byte) ((double) num7 * 250.0 + 5.0);
            Main.bgColor.R = (byte) ((double) num7 * 230.0 + 25.0);
            Main.bgColor.G = (byte) ((double) num7 * 220.0 + 35.0);
            Main.bgColor.B = (byte) ((double) num7 * 220.0 + 35.0);
          }
          if (Main.time > 45900.0)
          {
            float num8 = (float) (1.0 - (Main.time / 54000.0 - 0.85) * (20.0 / 3.0));
            white1.R = (byte) ((double) num8 * 120.0 + 55.0);
            white1.G = (byte) ((double) num8 * 100.0 + 25.0);
            white1.B = (byte) ((double) num8 * 120.0 + 55.0);
            Main.bgColor.R = (byte) ((double) num8 * 200.0 + 35.0);
            Main.bgColor.G = (byte) ((double) num8 * 85.0 + 35.0);
            Main.bgColor.B = (byte) ((double) num8 * 135.0 + 35.0);
          }
          else if (Main.time > 37800.0)
          {
            float num9 = (float) (1.0 - (Main.time / 54000.0 - 0.7) * (20.0 / 3.0));
            white1.R = (byte) ((double) num9 * 80.0 + 175.0);
            white1.G = (byte) ((double) num9 * 130.0 + 125.0);
            white1.B = (byte) ((double) num9 * 100.0 + 155.0);
            Main.bgColor.R = (byte) ((double) num9 * 20.0 + 235.0);
            Main.bgColor.G = (byte) ((double) num9 * 135.0 + 120.0);
            Main.bgColor.B = (byte) ((double) num9 * 85.0 + 170.0);
          }
        }
        if (!Main.dayTime)
        {
          if (Main.bloodMoon)
          {
            if (Main.time < 16200.0)
            {
              float num10 = (float) (1.0 - Main.time / 16200.0);
              white2.R = (byte) ((double) num10 * 10.0 + 205.0);
              white2.G = (byte) ((double) num10 * 170.0 + 55.0);
              white2.B = (byte) ((double) num10 * 200.0 + 55.0);
              Main.bgColor.R = (byte) (40.0 - (double) num10 * 40.0 + 35.0);
              Main.bgColor.G = (byte) ((double) num10 * 20.0 + 15.0);
              Main.bgColor.B = (byte) ((double) num10 * 20.0 + 15.0);
            }
            else if (Main.time >= 16200.0)
            {
              float num11 = (float) ((Main.time / 32400.0 - 0.5) * 2.0);
              white2.R = (byte) ((double) num11 * 50.0 + 205.0);
              white2.G = (byte) ((double) num11 * 100.0 + 155.0);
              white2.B = (byte) ((double) num11 * 100.0 + 155.0);
              white2.R = (byte) ((double) num11 * 10.0 + 205.0);
              white2.G = (byte) ((double) num11 * 170.0 + 55.0);
              white2.B = (byte) ((double) num11 * 200.0 + 55.0);
              Main.bgColor.R = (byte) (40.0 - (double) num11 * 40.0 + 35.0);
              Main.bgColor.G = (byte) ((double) num11 * 20.0 + 15.0);
              Main.bgColor.B = (byte) ((double) num11 * 20.0 + 15.0);
            }
          }
          else if (Main.time < 16200.0)
          {
            float num12 = (float) (1.0 - Main.time / 16200.0);
            white2.R = (byte) ((double) num12 * 10.0 + 205.0);
            white2.G = (byte) ((double) num12 * 70.0 + 155.0);
            white2.B = (byte) ((double) num12 * 100.0 + 155.0);
            Main.bgColor.R = (byte) ((double) num12 * 20.0 + 15.0);
            Main.bgColor.G = (byte) ((double) num12 * 20.0 + 15.0);
            Main.bgColor.B = (byte) ((double) num12 * 20.0 + 15.0);
          }
          else if (Main.time >= 16200.0)
          {
            float num13 = (float) ((Main.time / 32400.0 - 0.5) * 2.0);
            white2.R = (byte) ((double) num13 * 50.0 + 205.0);
            white2.G = (byte) ((double) num13 * 100.0 + 155.0);
            white2.B = (byte) ((double) num13 * 100.0 + 155.0);
            Main.bgColor.R = (byte) ((double) num13 * 10.0 + 15.0);
            Main.bgColor.G = (byte) ((double) num13 * 20.0 + 15.0);
            Main.bgColor.B = (byte) ((double) num13 * 20.0 + 15.0);
          }
        }
        if (Main.gameMenu || Main.netMode == 2)
        {
          this.bgTop = 0;
          if (!Main.dayTime)
          {
            Main.bgColor.R = (byte) 35;
            Main.bgColor.G = (byte) 35;
            Main.bgColor.B = (byte) 35;
          }
        }
        if (Main.gameMenu)
        {
          Main.bgDelay = 1000;
          Main.evilTiles = (int) ((double) Main.bgAlpha[1] * 500.0);
        }
        if (Main.evilTiles > 0)
        {
          float num14 = (float) Main.evilTiles / 500f;
          if ((double) num14 > 1.0)
            num14 = 1f;
          int r1 = (int) Main.bgColor.R;
          int g1 = (int) Main.bgColor.G;
          int b1 = (int) Main.bgColor.B;
          int num15 = r1 - (int) (100.0 * (double) num14 * ((double) Main.bgColor.R / (double) byte.MaxValue));
          int num16 = g1 - (int) (140.0 * (double) num14 * ((double) Main.bgColor.G / (double) byte.MaxValue));
          int num17 = b1 - (int) (80.0 * (double) num14 * ((double) Main.bgColor.B / (double) byte.MaxValue));
          if (num15 < 15)
            num15 = 15;
          if (num16 < 15)
            num16 = 15;
          if (num17 < 15)
            num17 = 15;
          Main.bgColor.R = (byte) num15;
          Main.bgColor.G = (byte) num16;
          Main.bgColor.B = (byte) num17;
          int r2 = (int) white1.R;
          int g2 = (int) white1.G;
          int b2 = (int) white1.B;
          int num18 = r2 - (int) (100.0 * (double) num14 * ((double) white1.R / (double) byte.MaxValue));
          int num19 = g2 - (int) (100.0 * (double) num14 * ((double) white1.G / (double) byte.MaxValue));
          int num20 = b2 - (int) (0.0 * (double) num14 * ((double) white1.B / (double) byte.MaxValue));
          if (num18 < 15)
            num18 = 15;
          if (num19 < 15)
            num19 = 15;
          if (num20 < 15)
            num20 = 15;
          white1.R = (byte) num18;
          white1.G = (byte) num19;
          white1.B = (byte) num20;
          int r3 = (int) white2.R;
          int g3 = (int) white2.G;
          int b3 = (int) white2.B;
          int num21 = r3 - (int) (140.0 * (double) num14 * ((double) white2.R / (double) byte.MaxValue));
          int num22 = g3 - (int) (190.0 * (double) num14 * ((double) white2.G / (double) byte.MaxValue));
          int num23 = b3 - (int) (170.0 * (double) num14 * ((double) white2.B / (double) byte.MaxValue));
          if (num21 < 15)
            num21 = 15;
          if (num22 < 15)
            num22 = 15;
          if (num23 < 15)
            num23 = 15;
          white2.R = (byte) num21;
          white2.G = (byte) num22;
          white2.B = (byte) num23;
        }
        if (Main.jungleTiles > 0)
        {
          float num24 = (float) Main.jungleTiles / 200f;
          if ((double) num24 > 1.0)
            num24 = 1f;
          int r4 = (int) Main.bgColor.R;
          int num25 = (int) Main.bgColor.G;
          int b4 = (int) Main.bgColor.B;
          int num26 = r4 - (int) (20.0 * (double) num24 * ((double) Main.bgColor.R / (double) byte.MaxValue));
          int num27 = b4 - (int) (90.0 * (double) num24 * ((double) Main.bgColor.B / (double) byte.MaxValue));
          if (num25 > (int) byte.MaxValue)
            num25 = (int) byte.MaxValue;
          if (num25 < 15)
            num25 = 15;
          if (num26 > (int) byte.MaxValue)
            num26 = (int) byte.MaxValue;
          if (num26 < 15)
            num26 = 15;
          if (num27 < 15)
            num27 = 15;
          Main.bgColor.R = (byte) num26;
          Main.bgColor.G = (byte) num25;
          Main.bgColor.B = (byte) num27;
          int r5 = (int) white1.R;
          int num28 = (int) white1.G;
          int b5 = (int) white1.B;
          int num29 = r5 - (int) (30.0 * (double) num24 * ((double) white1.R / (double) byte.MaxValue));
          int num30 = b5 - (int) (10.0 * (double) num24 * ((double) white1.B / (double) byte.MaxValue));
          if (num29 < 15)
            num29 = 15;
          if (num28 < 15)
            num28 = 15;
          if (num30 < 15)
            num30 = 15;
          white1.R = (byte) num29;
          white1.G = (byte) num28;
          white1.B = (byte) num30;
          int r6 = (int) white2.R;
          int g = (int) white2.G;
          int b6 = (int) white2.B;
          int num31 = g - (int) (140.0 * (double) num24 * ((double) white2.R / (double) byte.MaxValue));
          int num32 = r6 - (int) (170.0 * (double) num24 * ((double) white2.G / (double) byte.MaxValue));
          int num33 = b6 - (int) (190.0 * (double) num24 * ((double) white2.B / (double) byte.MaxValue));
          if (num32 < 15)
            num32 = 15;
          if (num31 < 15)
            num31 = 15;
          if (num33 < 15)
            num33 = 15;
          white2.R = (byte) num32;
          white2.G = (byte) num31;
          white2.B = (byte) num33;
        }
        if (Main.bgColor.R < (byte) 15)
          Main.bgColor.R = (byte) 15;
        if (Main.bgColor.G < (byte) 15)
          Main.bgColor.G = (byte) 15;
        if (Main.bgColor.B < (byte) 15)
          Main.bgColor.B = (byte) 15;
        if (Main.bloodMoon)
        {
          if (Main.bgColor.R < (byte) 25)
            Main.bgColor.R = (byte) 25;
          if (Main.bgColor.G < (byte) 25)
            Main.bgColor.G = (byte) 25;
          if (Main.bgColor.B < (byte) 25)
            Main.bgColor.B = (byte) 25;
        }
        Main.tileColor.A = byte.MaxValue;
        Main.tileColor.R = (byte) (((int) Main.bgColor.R + (int) Main.bgColor.B + (int) Main.bgColor.G) / 3);
        Main.tileColor.G = (byte) (((int) Main.bgColor.R + (int) Main.bgColor.B + (int) Main.bgColor.G) / 3);
        Main.tileColor.B = (byte) (((int) Main.bgColor.R + (int) Main.bgColor.B + (int) Main.bgColor.G) / 3);
        Main.tileColor.R = (byte) (((int) Main.bgColor.R + (int) Main.bgColor.G + (int) Main.bgColor.B + (int) Main.bgColor.R * 7) / 10);
        Main.tileColor.G = (byte) (((int) Main.bgColor.R + (int) Main.bgColor.G + (int) Main.bgColor.B + (int) Main.bgColor.G * 7) / 10);
        Main.tileColor.B = (byte) (((int) Main.bgColor.R + (int) Main.bgColor.G + (int) Main.bgColor.B + (int) Main.bgColor.B * 7) / 10);
        if (Main.tileColor.R >= byte.MaxValue && Main.tileColor.G >= byte.MaxValue)
        {
          int b7 = (int) Main.tileColor.B;
        }
        float num34 = (float) (Main.maxTilesX / 4200);
        float num35 = num34 * num34;
        float num36 = (float) ((((double) Main.screenPosition.Y + (double) (Main.screenHeight / 2)) / 16.0 - (65.0 + 10.0 * (double) num35)) / (Main.worldSurface / 5.0));
        if ((double) num36 < 0.0)
          num36 = 0.0f;
        if ((double) num36 > 1.0)
          num36 = 1f;
        if (Main.gameMenu)
          num36 = 1f;
        Main.bgColor.R = (byte) ((double) Main.bgColor.R * (double) num36);
        Main.bgColor.G = (byte) ((double) Main.bgColor.G * (double) num36);
        Main.bgColor.B = (byte) ((double) Main.bgColor.B * (double) num36);
        this.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
        base.Draw(gameTime);
        this.spriteBatch.Begin();
        if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
        {
          for (int index = 0; index < this.bgLoops; ++index)
            this.spriteBatch.Draw(Main.backgroundTexture[Main.background], new Rectangle(this.bgStart + Main.backgroundWidth[Main.background] * index, this.bgTop, Main.backgroundWidth[Main.background], Main.backgroundHeight[Main.background]), Main.bgColor);
        }
        if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && (int) byte.MaxValue - (int) Main.bgColor.R - 100 > 0 && Main.netMode != 2)
        {
          for (int index = 0; index < Main.numStars; ++index)
          {
            Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color();
            float num37 = (float) Main.evilTiles / 500f;
            if ((double) num37 > 1.0)
              num37 = 1f;
            float num38 = (float) (1.0 - (double) num37 * 0.5);
            if (Main.evilTiles <= 0)
              num38 = 1f;
            int num39 = (int) ((double) ((int) byte.MaxValue - (int) Main.bgColor.R - 100) * (double) Main.star[index].twinkle * (double) num38);
            int num40 = (int) ((double) ((int) byte.MaxValue - (int) Main.bgColor.G - 100) * (double) Main.star[index].twinkle * (double) num38);
            int num41 = (int) ((double) ((int) byte.MaxValue - (int) Main.bgColor.B - 100) * (double) Main.star[index].twinkle * (double) num38);
            if (num39 < 0)
              num39 = 0;
            if (num40 < 0)
              num40 = 0;
            if (num41 < 0)
              num41 = 0;
            color.R = (byte) num39;
            color.G = (byte) ((double) num40 * (double) num38);
            color.B = (byte) ((double) num41 * (double) num38);
            float num42 = Main.star[index].position.X * ((float) Main.screenWidth / 800f);
            float num43 = Main.star[index].position.Y * ((float) Main.screenHeight / 600f);
            this.spriteBatch.Draw(Main.starTexture[Main.star[index].type], new Vector2(num42 + (float) Main.starTexture[Main.star[index].type].Width * 0.5f, num43 + (float) Main.starTexture[Main.star[index].type].Height * 0.5f + (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.starTexture[Main.star[index].type].Width, Main.starTexture[Main.star[index].type].Height)), color, Main.star[index].rotation, new Vector2((float) Main.starTexture[Main.star[index].type].Width * 0.5f, (float) Main.starTexture[Main.star[index].type].Height * 0.5f), Main.star[index].scale * Main.star[index].twinkle, SpriteEffects.None, 0.0f);
          }
        }
        if ((double) Main.screenPosition.Y / 16.0 < Main.worldSurface + 2.0)
        {
          if (Main.dayTime)
          {
            scale1 *= 1.1f;
            if (!Main.gameMenu && Main.player[Main.myPlayer].head == 12)
              this.spriteBatch.Draw(Main.sun2Texture, new Vector2((float) num1, (float) (num2 + (int) Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white1, rotation1, new Vector2((float) (Main.sunTexture.Width / 2), (float) (Main.sunTexture.Height / 2)), scale1, SpriteEffects.None, 0.0f);
            else
              this.spriteBatch.Draw(Main.sunTexture, new Vector2((float) num1, (float) (num2 + (int) Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white1, rotation1, new Vector2((float) (Main.sunTexture.Width / 2), (float) (Main.sunTexture.Height / 2)), scale1, SpriteEffects.None, 0.0f);
          }
          if (!Main.dayTime)
            this.spriteBatch.Draw(Main.moonTexture, new Vector2((float) num3, (float) (num4 + (int) Main.moonModY)), new Rectangle?(new Rectangle(0, Main.moonTexture.Width * Main.moonPhase, Main.moonTexture.Width, Main.moonTexture.Width)), white2, rotation2, new Vector2((float) (Main.moonTexture.Width / 2), (float) (Main.moonTexture.Width / 2)), scale2, SpriteEffects.None, 0.0f);
        }
        Rectangle rectangle1 = !Main.dayTime ? new Rectangle((int) ((double) num3 - (double) Main.moonTexture.Width * 0.5 * (double) scale2), (int) ((double) num4 - (double) Main.moonTexture.Width * 0.5 * (double) scale2 + (double) Main.moonModY), (int) ((double) Main.moonTexture.Width * (double) scale2), (int) ((double) Main.moonTexture.Width * (double) scale2)) : new Rectangle((int) ((double) num1 - (double) Main.sunTexture.Width * 0.5 * (double) scale1), (int) ((double) num2 - (double) Main.sunTexture.Height * 0.5 * (double) scale1 + (double) Main.sunModY), (int) ((double) Main.sunTexture.Width * (double) scale1), (int) ((double) Main.sunTexture.Width * (double) scale1));
        Rectangle rectangle2 = new Rectangle(Main.mouseX, Main.mouseY, 1, 1);
        Main.sunModY = (short) ((double) Main.sunModY * 0.999);
        Main.moonModY = (short) ((double) Main.moonModY * 0.999);
        if (Main.gameMenu && Main.netMode != 1)
        {
          if (Main.mouseLeft && Main.hasFocus)
          {
            if (rectangle2.Intersects(rectangle1) || Main.grabSky)
            {
              if (Main.dayTime)
              {
                Main.time = 54000.0 * ((double) (Main.mouseX + Main.sunTexture.Width) / ((double) Main.screenWidth + (double) (Main.sunTexture.Width * 2)));
                Main.sunModY = (short) (Main.mouseY - num2);
                if (Main.time > 53990.0)
                  Main.time = 53990.0;
              }
              else
              {
                Main.time = 32400.0 * ((double) (Main.mouseX + Main.moonTexture.Width) / ((double) Main.screenWidth + (double) (Main.moonTexture.Width * 2)));
                Main.moonModY = (short) (Main.mouseY - num4);
                if (Main.time > 32390.0)
                  Main.time = 32390.0;
              }
              if (Main.time < 10.0)
                Main.time = 10.0;
              if (Main.netMode != 0)
                NetMessage.SendData(18);
              Main.grabSky = true;
            }
          }
          else
            Main.grabSky = false;
        }
        float num44 = (float) (Main.screenHeight - 600);
        this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1200.0 + 1190.0);
        float num45 = (float) (this.bgTop - 50);
        if (Main.resetClouds)
        {
          Cloud.resetClouds();
          Main.resetClouds = false;
        }
        if (this.IsActive || Main.netMode != 0)
        {
          Main.windSpeedSpeed += (float) Main.rand.Next(-10, 11) * 0.0001f;
          if (!Main.dayTime)
            Main.windSpeedSpeed += (float) Main.rand.Next(-10, 11) * 0.0002f;
          if ((double) Main.windSpeedSpeed < -0.002)
            Main.windSpeedSpeed = -1f / 500f;
          if ((double) Main.windSpeedSpeed > 0.002)
            Main.windSpeedSpeed = 1f / 500f;
          Main.windSpeed += Main.windSpeedSpeed;
          if ((double) Main.windSpeed < -0.3)
            Main.windSpeed = -0.3f;
          if ((double) Main.windSpeed > 0.3)
            Main.windSpeed = 0.3f;
          Main.numClouds += Main.rand.Next(-1, 2);
          if (Main.numClouds < 0)
            Main.numClouds = 0;
          if (Main.numClouds > Main.cloudLimit)
            Main.numClouds = Main.cloudLimit;
        }
        if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
        {
          for (int index = 0; index < 100; ++index)
          {
            if (Main.cloud[index].active && (double) Main.cloud[index].scale < 1.0)
            {
              Microsoft.Xna.Framework.Color color = Main.cloud[index].cloudColor(Main.bgColor);
              if ((double) num36 < 1.0)
              {
                color.R = (byte) ((double) color.R * (double) num36);
                color.G = (byte) ((double) color.G * (double) num36);
                color.B = (byte) ((double) color.B * (double) num36);
                color.A = (byte) ((double) color.A * (double) num36);
              }
              float num46 = Main.cloud[index].position.Y * ((float) Main.screenHeight / 600f);
              float num47 = (float) (((double) Main.screenPosition.Y / 16.0 - 24.0) / Main.worldSurface);
              if ((double) num47 < 0.0)
                num47 = 0.0f;
              float num48;
              if ((double) num47 > 1.0)
                num48 = 1f;
              if (Main.gameMenu)
                num48 = 1f;
              this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[index].type], new Vector2(Main.cloud[index].position.X + (float) Main.cloudTexture[Main.cloud[index].type].Width * 0.5f, num46 + (float) Main.cloudTexture[Main.cloud[index].type].Height * 0.5f + num45), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[index].type].Width, Main.cloudTexture[Main.cloud[index].type].Height)), color, Main.cloud[index].rotation, new Vector2((float) Main.cloudTexture[Main.cloud[index].type].Width * 0.5f, (float) Main.cloudTexture[Main.cloud[index].type].Height * 0.5f), Main.cloud[index].scale, SpriteEffects.None, 0.0f);
            }
          }
        }
        float num49 = 1f;
        float scale3 = 1f * 2f;
        this.bgParrallax = 0.15;
        int num50 = (int) ((double) Main.backgroundWidth[7] * (double) scale3);
        Microsoft.Xna.Framework.Color color1 = Main.bgColor;
        Microsoft.Xna.Framework.Color color2 = color1;
        if ((double) num49 < 1.0)
        {
          color1.R = (byte) ((double) color1.R * (double) num49);
          color1.G = (byte) ((double) color1.G * (double) num49);
          color1.B = (byte) ((double) color1.B * (double) num49);
          color1.A = (byte) ((double) color1.A * (double) num49);
        }
        this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1300.0 + 1090.0);
        if (Main.owBack)
        {
          this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num50) - (double) (num50 / 2));
          this.bgLoops = Main.screenWidth / num50 + 2;
          if (Main.gameMenu)
            this.bgTop = 100;
          if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
          {
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[0]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[0]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[0]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[0]);
            if ((double) Main.bgAlpha2[0] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[7], new Vector2((float) (this.bgStart + num50 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale3, SpriteEffects.None, 0.0f);
            }
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[1]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[1]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[1]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[1]);
            if ((double) Main.bgAlpha2[1] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[23], new Vector2((float) (this.bgStart + num50 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale3, SpriteEffects.None, 0.0f);
            }
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[2]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[2]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[2]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[2]);
            if ((double) Main.bgAlpha2[2] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[24], new Vector2((float) (this.bgStart + num50 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale3, SpriteEffects.None, 0.0f);
            }
          }
        }
        float num51 = (float) (this.bgTop - 50);
        if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
        {
          for (int index = 0; index < 100; ++index)
          {
            if (Main.cloud[index].active && (double) Main.cloud[index].scale < 1.15 && (double) Main.cloud[index].scale >= 1.0)
            {
              Microsoft.Xna.Framework.Color color3 = Main.cloud[index].cloudColor(Main.bgColor);
              if ((double) num49 < 1.0)
              {
                color3.R = (byte) ((double) color3.R * (double) num49);
                color3.G = (byte) ((double) color3.G * (double) num49);
                color3.B = (byte) ((double) color3.B * (double) num49);
                color3.A = (byte) ((double) color3.A * (double) num49);
              }
              float num52 = Main.cloud[index].position.Y * ((float) Main.screenHeight / 600f);
              float num53 = (float) (((double) Main.screenPosition.Y / 16.0 - 24.0) / Main.worldSurface);
              if ((double) num53 < 0.0)
                num53 = 0.0f;
              float num54;
              if ((double) num53 > 1.0)
                num54 = 1f;
              if (Main.gameMenu)
                num54 = 1f;
              this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[index].type], new Vector2(Main.cloud[index].position.X + (float) Main.cloudTexture[Main.cloud[index].type].Width * 0.5f, num52 + (float) Main.cloudTexture[Main.cloud[index].type].Height * 0.5f + num51), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[index].type].Width, Main.cloudTexture[Main.cloud[index].type].Height)), color3, Main.cloud[index].rotation, new Vector2((float) Main.cloudTexture[Main.cloud[index].type].Width * 0.5f, (float) Main.cloudTexture[Main.cloud[index].type].Height * 0.5f), Main.cloud[index].scale, SpriteEffects.None, 0.0f);
            }
          }
        }
        if (Main.holyTiles > 0 && Main.owBack)
        {
          this.bgParrallax = 0.17;
          float scale4 = 1.1f * 2f;
          int num55 = (int) (3500.0 * (double) scale4 * 1.05);
          this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num55) - (double) (num55 / 2));
          this.bgLoops = Main.screenWidth / num55 + 2;
          this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1400.0 + 900.0);
          if (Main.gameMenu)
          {
            this.bgTop = 230;
            this.bgStart -= 500;
          }
          Microsoft.Xna.Framework.Color color4 = color2;
          float num56 = (float) Main.holyTiles / 400f;
          if ((double) num56 > 0.5)
            num56 = 0.5f;
          color4.R = (byte) ((double) color4.R * (double) num56);
          color4.G = (byte) ((double) color4.G * (double) num56);
          color4.B = (byte) ((double) color4.B * (double) num56);
          color4.A = (byte) ((double) color4.A * (double) num56 * 0.800000011920929);
          if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
          {
            for (int index = 0; index < this.bgLoops; ++index)
            {
              this.spriteBatch.Draw(Main.backgroundTexture[18], new Vector2((float) (this.bgStart + num55 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[18], Main.backgroundHeight[18])), color4, 0.0f, new Vector2(), scale4, SpriteEffects.None, 0.0f);
              this.spriteBatch.Draw(Main.backgroundTexture[19], new Vector2((float) (this.bgStart + num55 * index + 1700), (float) (this.bgTop + 100)), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[19], Main.backgroundHeight[19])), color4, 0.0f, new Vector2(), scale4 * 0.9f, SpriteEffects.None, 0.0f);
            }
          }
        }
        this.bgParrallax = 0.2;
        float scale5 = 1.15f * 2f;
        int num57 = (int) ((double) Main.backgroundWidth[7] * (double) scale5);
        this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num57) - (double) (num57 / 2));
        this.bgLoops = Main.screenWidth / num57 + 2;
        this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1400.0 + 1260.0);
        if (Main.owBack)
        {
          if (Main.gameMenu)
          {
            this.bgTop = 230;
            this.bgStart -= 500;
          }
          if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
          {
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[0]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[0]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[0]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[0]);
            if ((double) Main.bgAlpha2[0] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[8], new Vector2((float) (this.bgStart + num57 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
            }
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[1]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[1]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[1]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[1]);
            if ((double) Main.bgAlpha2[1] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[22], new Vector2((float) (this.bgStart + num57 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
            }
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[2]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[2]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[2]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[2]);
            if ((double) Main.bgAlpha2[2] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[25], new Vector2((float) (this.bgStart + num57 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
            }
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha2[3]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha2[3]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha2[3]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha2[3]);
            if ((double) Main.bgAlpha2[3] > 0.0)
            {
              for (int index = 0; index < this.bgLoops; ++index)
                this.spriteBatch.Draw(Main.backgroundTexture[28], new Vector2((float) (this.bgStart + num57 * index), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7])), color1, 0.0f, new Vector2(), scale5, SpriteEffects.None, 0.0f);
            }
          }
        }
        float num58 = (float) ((double) this.bgTop * 1.00999999046326 - 150.0);
        if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
        {
          for (int index = 0; index < 100; ++index)
          {
            if (Main.cloud[index].active && (double) Main.cloud[index].scale > (double) scale5)
            {
              Microsoft.Xna.Framework.Color color5 = Main.cloud[index].cloudColor(Main.bgColor);
              if ((double) num49 < 1.0)
              {
                color5.R = (byte) ((double) color5.R * (double) num49);
                color5.G = (byte) ((double) color5.G * (double) num49);
                color5.B = (byte) ((double) color5.B * (double) num49);
                color5.A = (byte) ((double) color5.A * (double) num49);
              }
              float num59 = Main.cloud[index].position.Y * ((float) Main.screenHeight / 600f);
              float num60 = (float) (((double) Main.screenPosition.Y / 16.0 - 24.0) / Main.worldSurface);
              if ((double) num60 < 0.0)
                num60 = 0.0f;
              float num61;
              if ((double) num60 > 1.0)
                num61 = 1f;
              if (Main.gameMenu)
                num61 = 1f;
              this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[index].type], new Vector2(Main.cloud[index].position.X + (float) Main.cloudTexture[Main.cloud[index].type].Width * 0.5f, num59 + (float) Main.cloudTexture[Main.cloud[index].type].Height * 0.5f + num58), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[index].type].Width, Main.cloudTexture[Main.cloud[index].type].Height)), color5, Main.cloud[index].rotation, new Vector2((float) Main.cloudTexture[Main.cloud[index].type].Width * 0.5f, (float) Main.cloudTexture[Main.cloud[index].type].Height * 0.5f), Main.cloud[index].scale, SpriteEffects.None, 0.0f);
            }
          }
        }
        int bgStyle = Main.bgStyle;
        int num62 = (int) (((double) Main.screenPosition.X + (double) (Main.screenWidth / 2)) / 16.0);
        int num63 = num62 < 380 || num62 > Main.maxTilesX - 380 ? 4 : (Main.sandTiles <= 1000 ? (!Main.player[Main.myPlayer].zoneHoly ? (!Main.player[Main.myPlayer].zoneEvil ? (!Main.player[Main.myPlayer].zoneJungle ? 0 : 3) : 1) : 6) : (!Main.player[Main.myPlayer].zoneEvil ? (!Main.player[Main.myPlayer].zoneHoly ? 2 : 5) : 5));
        float num64 = 0.05f;
        int num65 = 30;
        if (num63 == 0)
          num65 = 120;
        if (Main.bgDelay < 0)
          ++Main.bgDelay;
        else if (num63 != Main.bgStyle)
        {
          ++Main.bgDelay;
          if (Main.bgDelay > num65)
          {
            Main.bgDelay = -60;
            Main.bgStyle = num63;
            if (num63 == 0)
              Main.bgDelay = 0;
          }
        }
        else if (Main.bgDelay > 0)
          --Main.bgDelay;
        if (Main.gameMenu)
        {
          num64 = 0.02f;
          Main.bgStyle = Main.dayTime ? 0 : 1;
          num63 = Main.bgStyle;
        }
        if (Main.quickBG > 0)
        {
          --Main.quickBG;
          Main.bgStyle = num63;
          num64 = 1f;
        }
        switch (Main.bgStyle)
        {
          case 1:
          case 5:
          case 6:
            Main.bgAlpha2[0] -= num64;
            if ((double) Main.bgAlpha2[0] < 0.0)
              Main.bgAlpha2[0] = 0.0f;
            Main.bgAlpha2[1] -= num64;
            if ((double) Main.bgAlpha2[1] < 0.0)
              Main.bgAlpha2[1] = 0.0f;
            Main.bgAlpha2[2] += num64;
            if ((double) Main.bgAlpha2[2] > 1.0)
              Main.bgAlpha2[2] = 1f;
            Main.bgAlpha2[3] -= num64;
            if ((double) Main.bgAlpha2[3] < 0.0)
            {
              Main.bgAlpha2[3] = 0.0f;
              break;
            }
            break;
          case 2:
            Main.bgAlpha2[0] -= num64;
            if ((double) Main.bgAlpha2[0] < 0.0)
              Main.bgAlpha2[0] = 0.0f;
            Main.bgAlpha2[1] += num64;
            if ((double) Main.bgAlpha2[1] > 1.0)
              Main.bgAlpha2[1] = 1f;
            Main.bgAlpha2[2] -= num64;
            if ((double) Main.bgAlpha2[2] < 0.0)
              Main.bgAlpha2[2] = 0.0f;
            Main.bgAlpha2[3] -= num64;
            if ((double) Main.bgAlpha2[3] < 0.0)
            {
              Main.bgAlpha2[3] = 0.0f;
              break;
            }
            break;
          case 4:
            Main.bgAlpha2[0] -= num64;
            if ((double) Main.bgAlpha2[0] < 0.0)
              Main.bgAlpha2[0] = 0.0f;
            Main.bgAlpha2[1] -= num64;
            if ((double) Main.bgAlpha2[1] < 0.0)
              Main.bgAlpha2[1] = 0.0f;
            Main.bgAlpha2[2] -= num64;
            if ((double) Main.bgAlpha2[2] < 0.0)
              Main.bgAlpha2[2] = 0.0f;
            Main.bgAlpha2[3] += num64;
            if ((double) Main.bgAlpha2[3] > 1.0)
            {
              Main.bgAlpha2[3] = 1f;
              break;
            }
            break;
          default:
            Main.bgAlpha2[0] += num64;
            if ((double) Main.bgAlpha2[0] > 1.0)
              Main.bgAlpha2[0] = 1f;
            Main.bgAlpha2[1] -= num64;
            if ((double) Main.bgAlpha2[1] < 0.0)
              Main.bgAlpha2[1] = 0.0f;
            Main.bgAlpha2[2] -= num64;
            if ((double) Main.bgAlpha2[2] < 0.0)
              Main.bgAlpha2[2] = 0.0f;
            Main.bgAlpha2[3] -= num64;
            if ((double) Main.bgAlpha2[3] < 0.0)
            {
              Main.bgAlpha2[3] = 0.0f;
              break;
            }
            break;
        }
        for (int index1 = 0; index1 < 7; ++index1)
        {
          if (Main.bgStyle == index1)
          {
            Main.bgAlpha[index1] += num64;
            if ((double) Main.bgAlpha[index1] > 1.0)
              Main.bgAlpha[index1] = 1f;
          }
          else
          {
            Main.bgAlpha[index1] -= num64;
            if ((double) Main.bgAlpha[index1] < 0.0)
              Main.bgAlpha[index1] = 0.0f;
          }
          if (Main.owBack)
          {
            color1 = color2;
            color1.R = (byte) ((double) color1.R * (double) Main.bgAlpha[index1]);
            color1.G = (byte) ((double) color1.G * (double) Main.bgAlpha[index1]);
            color1.B = (byte) ((double) color1.B * (double) Main.bgAlpha[index1]);
            color1.A = (byte) ((double) color1.A * (double) Main.bgAlpha[index1]);
            if ((double) Main.bgAlpha[index1] > 0.0 && index1 == 3)
            {
              float scale6 = 1.25f * 2f;
              int num66 = (int) ((double) Main.backgroundWidth[8] * (double) scale6);
              this.bgParrallax = 0.4;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num66) - (double) (num66 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1800.0 + 1660.0);
              if (Main.gameMenu)
                this.bgTop = 320;
              this.bgLoops = Main.screenWidth / num66 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index2 = 0; index2 < this.bgLoops; ++index2)
                  this.spriteBatch.Draw(Main.backgroundTexture[15], new Vector2((float) (this.bgStart + num66 * index2), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale6, SpriteEffects.None, 0.0f);
              }
              float scale7 = 1.31f * 2f;
              int num67 = (int) ((double) Main.backgroundWidth[8] * (double) scale7);
              this.bgParrallax = 0.43;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num67) - (double) (num67 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1950.0 + 1840.0);
              if (Main.gameMenu)
              {
                this.bgTop = 400;
                this.bgStart -= 80;
              }
              this.bgLoops = Main.screenWidth / num67 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index3 = 0; index3 < this.bgLoops; ++index3)
                  this.spriteBatch.Draw(Main.backgroundTexture[16], new Vector2((float) (this.bgStart + num67 * index3), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale7, SpriteEffects.None, 0.0f);
              }
              float scale8 = 1.34f * 2f;
              int num68 = (int) ((double) Main.backgroundWidth[8] * (double) scale8);
              this.bgParrallax = 0.49;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num68) - (double) (num68 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 2100.0 + 2060.0);
              if (Main.gameMenu)
              {
                this.bgTop = 480;
                this.bgStart -= 120;
              }
              this.bgLoops = Main.screenWidth / num68 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index4 = 0; index4 < this.bgLoops; ++index4)
                  this.spriteBatch.Draw(Main.backgroundTexture[17], new Vector2((float) (this.bgStart + num68 * index4), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale8, SpriteEffects.None, 0.0f);
              }
            }
            if ((double) Main.bgAlpha[index1] > 0.0 && index1 == 2)
            {
              float scale9 = 1.25f * 2f;
              int num69 = (int) ((double) Main.backgroundWidth[8] * (double) scale9);
              this.bgParrallax = 0.37;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num69) - (double) (num69 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0);
              if (Main.gameMenu)
                this.bgTop = 320;
              this.bgLoops = Main.screenWidth / num69 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index5 = 0; index5 < this.bgLoops; ++index5)
                  this.spriteBatch.Draw(Main.backgroundTexture[21], new Vector2((float) (this.bgStart + num69 * index5), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20])), color1, 0.0f, new Vector2(), scale9, SpriteEffects.None, 0.0f);
              }
              float scale10 = 1.34f * 2f;
              int num70 = (int) ((double) Main.backgroundWidth[8] * (double) scale10);
              this.bgParrallax = 0.49;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num70) - (double) (num70 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0);
              if (Main.gameMenu)
              {
                this.bgTop = 480;
                this.bgStart -= 120;
              }
              this.bgLoops = Main.screenWidth / num70 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index6 = 0; index6 < this.bgLoops; ++index6)
                  this.spriteBatch.Draw(Main.backgroundTexture[20], new Vector2((float) (this.bgStart + num70 * index6), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20])), color1, 0.0f, new Vector2(), scale10, SpriteEffects.None, 0.0f);
              }
            }
            if ((double) Main.bgAlpha[index1] > 0.0 && index1 == 5)
            {
              float scale11 = 1.25f * 2f;
              int num71 = (int) ((double) Main.backgroundWidth[8] * (double) scale11);
              this.bgParrallax = 0.37;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num71) - (double) (num71 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0);
              if (Main.gameMenu)
                this.bgTop = 320;
              this.bgLoops = Main.screenWidth / num71 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index7 = 0; index7 < this.bgLoops; ++index7)
                  this.spriteBatch.Draw(Main.backgroundTexture[26], new Vector2((float) (this.bgStart + num71 * index7), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20])), color1, 0.0f, new Vector2(), scale11, SpriteEffects.None, 0.0f);
              }
              float scale12 = 1.34f * 2f;
              int num72 = (int) ((double) Main.backgroundWidth[8] * (double) scale12);
              this.bgParrallax = 0.49;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num72) - (double) (num72 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0);
              if (Main.gameMenu)
              {
                this.bgTop = 480;
                this.bgStart -= 120;
              }
              this.bgLoops = Main.screenWidth / num72 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index8 = 0; index8 < this.bgLoops; ++index8)
                  this.spriteBatch.Draw(Main.backgroundTexture[27], new Vector2((float) (this.bgStart + num72 * index8), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20])), color1, 0.0f, new Vector2(), scale12, SpriteEffects.None, 0.0f);
              }
            }
            if ((double) Main.bgAlpha[index1] > 0.0 && index1 == 1)
            {
              float scale13 = 1.25f * 2f;
              int num73 = (int) ((double) Main.backgroundWidth[8] * (double) scale13);
              this.bgParrallax = 0.4;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num73) - (double) (num73 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
              if (Main.gameMenu)
                this.bgTop = 320;
              this.bgLoops = Main.screenWidth / num73 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index9 = 0; index9 < this.bgLoops; ++index9)
                  this.spriteBatch.Draw(Main.backgroundTexture[12], new Vector2((float) (this.bgStart + num73 * index9), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale13, SpriteEffects.None, 0.0f);
              }
              float scale14 = 1.31f * 2f;
              int num74 = (int) ((double) Main.backgroundWidth[8] * (double) scale14);
              this.bgParrallax = 0.43;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num74) - (double) (num74 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
              if (Main.gameMenu)
              {
                this.bgTop = 400;
                this.bgStart -= 80;
              }
              this.bgLoops = Main.screenWidth / num74 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index10 = 0; index10 < this.bgLoops; ++index10)
                  this.spriteBatch.Draw(Main.backgroundTexture[13], new Vector2((float) (this.bgStart + num74 * index10), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale14, SpriteEffects.None, 0.0f);
              }
              float scale15 = 1.34f * 2f;
              int num75 = (int) ((double) Main.backgroundWidth[8] * (double) scale15);
              this.bgParrallax = 0.49;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num75) - (double) (num75 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
              if (Main.gameMenu)
              {
                this.bgTop = 480;
                this.bgStart -= 120;
              }
              this.bgLoops = Main.screenWidth / num75 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index11 = 0; index11 < this.bgLoops; ++index11)
                  this.spriteBatch.Draw(Main.backgroundTexture[14], new Vector2((float) (this.bgStart + num75 * index11), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale15, SpriteEffects.None, 0.0f);
              }
            }
            if ((double) Main.bgAlpha[index1] > 0.0 && index1 == 6)
            {
              float scale16 = 1.25f * 2f;
              int num76 = (int) ((double) Main.backgroundWidth[8] * (double) scale16);
              this.bgParrallax = 0.4;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num76) - (double) (num76 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
              if (Main.gameMenu)
                this.bgTop = 320;
              this.bgLoops = Main.screenWidth / num76 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index12 = 0; index12 < this.bgLoops; ++index12)
                  this.spriteBatch.Draw(Main.backgroundTexture[29], new Vector2((float) (this.bgStart + num76 * index12), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale16, SpriteEffects.None, 0.0f);
              }
              float scale17 = 1.31f * 2f;
              int num77 = (int) ((double) Main.backgroundWidth[8] * (double) scale17);
              this.bgParrallax = 0.43;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num77) - (double) (num77 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
              if (Main.gameMenu)
              {
                this.bgTop = 400;
                this.bgStart -= 80;
              }
              this.bgLoops = Main.screenWidth / num77 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index13 = 0; index13 < this.bgLoops; ++index13)
                  this.spriteBatch.Draw(Main.backgroundTexture[30], new Vector2((float) (this.bgStart + num77 * index13), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale17, SpriteEffects.None, 0.0f);
              }
              float scale18 = 1.34f * 2f;
              int num78 = (int) ((double) Main.backgroundWidth[8] * (double) scale18);
              this.bgParrallax = 0.49;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num78) - (double) (num78 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
              if (Main.gameMenu)
              {
                this.bgTop = 480;
                this.bgStart -= 120;
              }
              this.bgLoops = Main.screenWidth / num78 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index14 = 0; index14 < this.bgLoops; ++index14)
                  this.spriteBatch.Draw(Main.backgroundTexture[31], new Vector2((float) (this.bgStart + num78 * index14), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale18, SpriteEffects.None, 0.0f);
              }
            }
            if ((double) Main.bgAlpha[index1] > 0.0 && index1 == 0)
            {
              float scale19 = 1.25f * 2f;
              int num79 = (int) ((double) Main.backgroundWidth[8] * (double) scale19);
              this.bgParrallax = 0.4;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num79) - (double) (num79 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
              if (Main.gameMenu)
                this.bgTop = 320;
              this.bgLoops = Main.screenWidth / num79 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index15 = 0; index15 < this.bgLoops; ++index15)
                  this.spriteBatch.Draw(Main.backgroundTexture[9], new Vector2((float) (this.bgStart + num79 * index15), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale19, SpriteEffects.None, 0.0f);
              }
              float scale20 = 1.31f * 2f;
              int num80 = (int) ((double) Main.backgroundWidth[8] * (double) scale20);
              this.bgParrallax = 0.43;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num80) - (double) (num80 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
              if (Main.gameMenu)
              {
                this.bgTop = 400;
                this.bgStart -= 80;
              }
              this.bgLoops = Main.screenWidth / num80 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index16 = 0; index16 < this.bgLoops; ++index16)
                  this.spriteBatch.Draw(Main.backgroundTexture[10], new Vector2((float) (this.bgStart + num80 * index16), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale20, SpriteEffects.None, 0.0f);
              }
              float scale21 = 1.34f * 2f;
              int num81 = (int) ((double) Main.backgroundWidth[8] * (double) scale21);
              this.bgParrallax = 0.49;
              this.bgStart = (int) (-Math.IEEERemainder((double) Main.screenPosition.X * this.bgParrallax, (double) num81) - (double) (num81 / 2));
              this.bgTop = (int) ((-(double) Main.screenPosition.Y + (double) num44 / 2.0) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
              if (Main.gameMenu)
              {
                this.bgTop = 480;
                this.bgStart -= 120;
              }
              this.bgLoops = Main.screenWidth / num81 + 2;
              if ((double) Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
              {
                for (int index17 = 0; index17 < this.bgLoops; ++index17)
                  this.spriteBatch.Draw(Main.backgroundTexture[11], new Vector2((float) (this.bgStart + num81 * index17), (float) this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8])), color1, 0.0f, new Vector2(), scale21, SpriteEffects.None, 0.0f);
              }
            }
          }
        }
        if (Main.gameMenu || Main.netMode == 2)
        {
          this.DrawMenu();
        }
        else
        {
          this.firstTileX = (int) ((double) Main.screenPosition.X / 16.0 - 1.0);
          this.lastTileX = (int) (((double) Main.screenPosition.X + (double) Main.screenWidth) / 16.0) + 2;
          this.firstTileY = (int) ((double) Main.screenPosition.Y / 16.0 - 1.0);
          this.lastTileY = (int) (((double) Main.screenPosition.Y + (double) Main.screenHeight) / 16.0) + 2;
          if (this.firstTileX < 0)
            this.firstTileX = 0;
          if (this.lastTileX > Main.maxTilesX)
            this.lastTileX = Main.maxTilesX;
          if (this.firstTileY < 0)
            this.firstTileY = 0;
          if (this.lastTileY > Main.maxTilesY)
            this.lastTileY = Main.maxTilesY;
          if (!Main.drawSkip)
            Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
          Microsoft.Xna.Framework.Color white3 = Microsoft.Xna.Framework.Color.White;
          if (Main.drawToScreen)
            this.DrawWater(true);
          else
            this.spriteBatch.Draw((Texture2D) this.backWaterTarget, Main.sceneBackgroundPos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
          float x = (Main.sceneBackgroundPos.X - Main.screenPosition.X + (float) Main.offScreenRange) * Main.caveParrallax - (float) Main.offScreenRange;
          if (Main.drawToScreen)
            this.DrawBackground();
          else
            this.spriteBatch.Draw((Texture2D) this.backgroundTarget, new Vector2(x, Main.sceneBackgroundPos.Y - Main.screenPosition.Y), Microsoft.Xna.Framework.Color.White);
          ++Main.magmaBGFrameCounter;
          if (Main.magmaBGFrameCounter >= 8)
          {
            Main.magmaBGFrameCounter = 0;
            ++Main.magmaBGFrame;
            if (Main.magmaBGFrame >= 3)
              Main.magmaBGFrame = 0;
          }
          try
          {
            if (Main.drawToScreen)
            {
              this.DrawBlack();
              this.DrawWalls();
            }
            else
            {
              this.spriteBatch.Draw((Texture2D) this.blackTarget, Main.sceneTilePos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
              this.spriteBatch.Draw((Texture2D) this.wallTarget, Main.sceneWallPos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
            }
            this.DrawWoF();
            if (Main.player[Main.myPlayer].detectCreature)
            {
              if (Main.drawToScreen)
              {
                this.DrawTiles(false);
                this.DrawTiles();
              }
              else
              {
                this.spriteBatch.Draw((Texture2D) this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
                this.spriteBatch.Draw((Texture2D) this.tileTarget, Main.sceneTilePos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
              }
              this.DrawGore();
              this.DrawNPCs(true);
              this.DrawNPCs();
            }
            else
            {
              if (Main.drawToScreen)
              {
                this.DrawTiles(false);
                this.DrawNPCs(true);
                this.DrawTiles();
              }
              else
              {
                this.spriteBatch.Draw((Texture2D) this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
                this.DrawNPCs(true);
                this.spriteBatch.Draw((Texture2D) this.tileTarget, Main.sceneTilePos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
              }
              this.DrawGore();
              this.DrawNPCs();
            }
          }
          catch
          {
          }
          for (int i = 0; i < 1000; ++i)
          {
            if (Main.projectile[i].active && Main.projectile[i].type > 0 && !Main.projectile[i].hide)
              this.DrawProj(i);
          }
          for (int index = 0; index < (int) byte.MaxValue; ++index)
          {
            if (Main.player[index].active)
            {
              if (Main.player[index].ghost)
              {
                Vector2 position = Main.player[index].position;
                Main.player[index].position = Main.player[index].shadowPos[0];
                Main.player[index].shadow = 0.5f;
                this.DrawGhost(Main.player[index]);
                Main.player[index].position = Main.player[index].shadowPos[1];
                Main.player[index].shadow = 0.7f;
                this.DrawGhost(Main.player[index]);
                Main.player[index].position = Main.player[index].shadowPos[2];
                Main.player[index].shadow = 0.9f;
                this.DrawGhost(Main.player[index]);
                Main.player[index].position = position;
                Main.player[index].shadow = 0.0f;
                this.DrawGhost(Main.player[index]);
              }
              else
              {
                bool flag1 = false;
                bool flag2 = false;
                if (Main.player[index].head == 5 && Main.player[index].body == 5 && Main.player[index].legs == 5)
                  flag1 = true;
                if (Main.player[index].head == 7 && Main.player[index].body == 7 && Main.player[index].legs == 7)
                  flag1 = true;
                if (Main.player[index].head == 22 && Main.player[index].body == 14 && Main.player[index].legs == 14)
                  flag1 = true;
                if (Main.player[index].body == 17 && Main.player[index].legs == 16 && (Main.player[index].head == 29 || Main.player[index].head == 30 || Main.player[index].head == 31))
                  flag1 = true;
                if (Main.player[index].body == 19 && Main.player[index].legs == 18 && (Main.player[index].head == 35 || Main.player[index].head == 36 || Main.player[index].head == 37))
                  flag2 = true;
                if (Main.player[index].body == 24 && Main.player[index].legs == 23 && (Main.player[index].head == 41 || Main.player[index].head == 42 || Main.player[index].head == 43))
                {
                  flag2 = true;
                  flag1 = true;
                }
                if (flag2)
                {
                  Vector2 position = Main.player[index].position;
                  if (!Main.gamePaused)
                    Main.player[index].ghostFade += Main.player[index].ghostDir * 0.075f;
                  if ((double) Main.player[index].ghostFade < 0.1)
                  {
                    Main.player[index].ghostDir = 1f;
                    Main.player[index].ghostFade = 0.1f;
                  }
                  if ((double) Main.player[index].ghostFade > 0.9)
                  {
                    Main.player[index].ghostDir = -1f;
                    Main.player[index].ghostFade = 0.9f;
                  }
                  Main.player[index].position.X = position.X - Main.player[index].ghostFade * 5f;
                  Main.player[index].shadow = Main.player[index].ghostFade;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position.X = position.X + Main.player[index].ghostFade * 5f;
                  Main.player[index].shadow = Main.player[index].ghostFade;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position = position;
                  Main.player[index].position.Y = position.Y - Main.player[index].ghostFade * 5f;
                  Main.player[index].shadow = Main.player[index].ghostFade;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position.Y = position.Y + Main.player[index].ghostFade * 5f;
                  Main.player[index].shadow = Main.player[index].ghostFade;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position = position;
                  Main.player[index].shadow = 0.0f;
                }
                if (flag1)
                {
                  Vector2 position = Main.player[index].position;
                  Main.player[index].position = Main.player[index].shadowPos[0];
                  Main.player[index].shadow = 0.5f;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position = Main.player[index].shadowPos[1];
                  Main.player[index].shadow = 0.7f;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position = Main.player[index].shadowPos[2];
                  Main.player[index].shadow = 0.9f;
                  this.DrawPlayer(Main.player[index]);
                  Main.player[index].position = position;
                  Main.player[index].shadow = 0.0f;
                }
                this.DrawPlayer(Main.player[index]);
              }
            }
          }
          if (!Main.gamePaused)
          {
            Main.essScale += (float) Main.essDir * 0.01f;
            if ((double) Main.essScale > 1.0)
            {
              Main.essDir = -1;
              Main.essScale = 1f;
            }
            if ((double) Main.essScale < 0.7)
            {
              Main.essDir = 1;
              Main.essScale = 0.7f;
            }
          }
          for (int index18 = 0; index18 < 200; ++index18)
          {
            if (Main.item[index18].active && Main.item[index18].type > 0)
            {
              int num82 = (int) ((double) Main.item[index18].position.X + (double) Main.item[index18].width * 0.5) / 16;
              int offScreenTiles1 = Lighting.offScreenTiles;
              int num83 = (int) ((double) Main.item[index18].position.Y + (double) Main.item[index18].height * 0.5) / 16;
              int offScreenTiles2 = Lighting.offScreenTiles;
              Microsoft.Xna.Framework.Color color6 = Lighting.GetColor((int) ((double) Main.item[index18].position.X + (double) Main.item[index18].width * 0.5) / 16, (int) ((double) Main.item[index18].position.Y + (double) Main.item[index18].height * 0.5) / 16);
              if (!Main.gamePaused && this.IsActive && (Main.item[index18].type >= 71 && Main.item[index18].type <= 74 || Main.item[index18].type == 58 || Main.item[index18].type == 109) && color6.R > (byte) 60 && (double) ((float) Main.rand.Next(500) - (float) (((double) Math.Abs(Main.item[index18].velocity.X) + (double) Math.Abs(Main.item[index18].velocity.Y)) * 10.0)) < (double) ((int) color6.R / 50))
              {
                int index19 = Dust.NewDust(Main.item[index18].position, Main.item[index18].width, Main.item[index18].height, 43, Alpha: 254, Scale: 0.5f);
                Main.dust[index19].velocity *= 0.0f;
              }
              float rotation3 = Main.item[index18].velocity.X * 0.2f;
              float scale22 = 1f;
              Microsoft.Xna.Framework.Color alpha = Main.item[index18].GetAlpha(color6);
              if (Main.item[index18].type == 520 || Main.item[index18].type == 521 || Main.item[index18].type == 547 || Main.item[index18].type == 548 || Main.item[index18].type == 549)
              {
                scale22 = Main.essScale;
                alpha.R = (byte) ((double) alpha.R * (double) scale22);
                alpha.G = (byte) ((double) alpha.G * (double) scale22);
                alpha.B = (byte) ((double) alpha.B * (double) scale22);
                alpha.A = (byte) ((double) alpha.A * (double) scale22);
              }
              else if (Main.item[index18].type == 58 || Main.item[index18].type == 184)
              {
                scale22 = (float) ((double) Main.essScale * 0.25 + 0.75);
                alpha.R = (byte) ((double) alpha.R * (double) scale22);
                alpha.G = (byte) ((double) alpha.G * (double) scale22);
                alpha.B = (byte) ((double) alpha.B * (double) scale22);
                alpha.A = (byte) ((double) alpha.A * (double) scale22);
              }
              float num84 = (float) (Main.item[index18].height - Main.itemTexture[Main.item[index18].type].Height);
              float num85 = (float) (Main.item[index18].width / 2 - Main.itemTexture[Main.item[index18].type].Width / 2);
              this.spriteBatch.Draw(Main.itemTexture[Main.item[index18].type], new Vector2(Main.item[index18].position.X - Main.screenPosition.X + (float) (Main.itemTexture[Main.item[index18].type].Width / 2) + num85, (float) ((double) Main.item[index18].position.Y - (double) Main.screenPosition.Y + (double) (Main.itemTexture[Main.item[index18].type].Height / 2) + (double) num84 + 2.0)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[index18].type].Width, Main.itemTexture[Main.item[index18].type].Height)), alpha, rotation3, new Vector2((float) (Main.itemTexture[Main.item[index18].type].Width / 2), (float) (Main.itemTexture[Main.item[index18].type].Height / 2)), scale22, SpriteEffects.None, 0.0f);
              if (Main.item[index18].color != new Microsoft.Xna.Framework.Color())
                this.spriteBatch.Draw(Main.itemTexture[Main.item[index18].type], new Vector2(Main.item[index18].position.X - Main.screenPosition.X + (float) (Main.itemTexture[Main.item[index18].type].Width / 2) + num85, (float) ((double) Main.item[index18].position.Y - (double) Main.screenPosition.Y + (double) (Main.itemTexture[Main.item[index18].type].Height / 2) + (double) num84 + 2.0)), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[index18].type].Width, Main.itemTexture[Main.item[index18].type].Height)), Main.item[index18].GetColor(color6), rotation3, new Vector2((float) (Main.itemTexture[Main.item[index18].type].Width / 2), (float) (Main.itemTexture[Main.item[index18].type].Height / 2)), scale22, SpriteEffects.None, 0.0f);
            }
          }
          Rectangle rectangle3 = new Rectangle((int) Main.screenPosition.X - 500, (int) Main.screenPosition.Y - 50, Main.screenWidth + 1000, Main.screenHeight + 100);
          for (int index = 0; index < Main.numDust; ++index)
          {
            if (Main.dust[index].active)
            {
              if (new Rectangle((int) Main.dust[index].position.X, (int) Main.dust[index].position.Y, 4, 4).Intersects(rectangle3))
              {
                Microsoft.Xna.Framework.Color newColor = Lighting.GetColor((int) ((double) Main.dust[index].position.X + 4.0) / 16, (int) ((double) Main.dust[index].position.Y + 4.0) / 16);
                if (Main.dust[index].type == 6 || Main.dust[index].type == 15 || Main.dust[index].noLight || Main.dust[index].type >= 59 && Main.dust[index].type <= 64)
                  newColor = Microsoft.Xna.Framework.Color.White;
                Microsoft.Xna.Framework.Color alpha = Main.dust[index].GetAlpha(newColor);
                this.spriteBatch.Draw(Main.dustTexture, Main.dust[index].position - Main.screenPosition, new Rectangle?(Main.dust[index].frame), alpha, Main.dust[index].rotation, new Vector2(4f, 4f), Main.dust[index].scale, SpriteEffects.None, 0.0f);
                if (Main.dust[index].color != new Microsoft.Xna.Framework.Color())
                  this.spriteBatch.Draw(Main.dustTexture, Main.dust[index].position - Main.screenPosition, new Rectangle?(Main.dust[index].frame), Main.dust[index].GetColor(alpha), Main.dust[index].rotation, new Vector2(4f, 4f), Main.dust[index].scale, SpriteEffects.None, 0.0f);
                if (alpha == Microsoft.Xna.Framework.Color.Black)
                  Main.dust[index].active = false;
              }
              else
                Main.dust[index].active = false;
            }
          }
          if (Main.drawToScreen)
          {
            this.DrawWater();
            if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
              this.DrawWires();
          }
          else
            this.spriteBatch.Draw((Texture2D) this.waterTarget, Main.sceneWaterPos - Main.screenPosition, Microsoft.Xna.Framework.Color.White);
          if (!Main.hideUI)
          {
            for (int index20 = 0; index20 < (int) byte.MaxValue; ++index20)
            {
              if (Main.player[index20].active && Main.player[index20].chatShowTime > 0 && index20 != Main.myPlayer && !Main.player[index20].dead)
              {
                Vector2 vector2_1 = Main.fontMouseText.MeasureString(Main.player[index20].chatText);
                Vector2 vector2_2;
                vector2_2.X = (float) ((double) Main.player[index20].position.X + (double) (Main.player[index20].width / 2) - (double) vector2_1.X / 2.0);
                vector2_2.Y = (float) ((double) Main.player[index20].position.Y - (double) vector2_1.Y - 2.0);
                for (int index21 = 0; index21 < 5; ++index21)
                {
                  int num86 = 0;
                  int num87 = 0;
                  Microsoft.Xna.Framework.Color color7 = Microsoft.Xna.Framework.Color.Black;
                  if (index21 == 0)
                    num86 = -2;
                  if (index21 == 1)
                    num86 = 2;
                  if (index21 == 2)
                    num87 = -2;
                  if (index21 == 3)
                    num87 = 2;
                  if (index21 == 4)
                    color7 = new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor);
                  this.spriteBatch.DrawString(Main.fontMouseText, Main.player[index20].chatText, new Vector2(vector2_2.X + (float) num86 - Main.screenPosition.X, vector2_2.Y + (float) num87 - Main.screenPosition.Y), color7, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
                }
              }
            }
            for (int index22 = 0; index22 < 100; ++index22)
            {
              if (Main.combatText[index22].active)
              {
                int index23 = 0;
                if (Main.combatText[index22].crit)
                  index23 = 1;
                Vector2 vector2 = Main.fontCombatText[index23].MeasureString(Main.combatText[index22].text);
                Vector2 origin = new Vector2(vector2.X * 0.5f, vector2.Y * 0.5f);
                double scale23 = (double) Main.combatText[index22].scale;
                float r = (float) Main.combatText[index22].color.R;
                float g = (float) Main.combatText[index22].color.G;
                float b8 = (float) Main.combatText[index22].color.B;
                float a = (float) Main.combatText[index22].color.A;
                float num88 = r * (float) ((double) Main.combatText[index22].scale * (double) Main.combatText[index22].alpha * 0.300000011920929);
                float num89 = b8 * (float) ((double) Main.combatText[index22].scale * (double) Main.combatText[index22].alpha * 0.300000011920929);
                float num90 = g * (float) ((double) Main.combatText[index22].scale * (double) Main.combatText[index22].alpha * 0.300000011920929);
                float num91 = a * (Main.combatText[index22].scale * Main.combatText[index22].alpha);
                Microsoft.Xna.Framework.Color color8 = new Microsoft.Xna.Framework.Color((int) num88, (int) num90, (int) num89, (int) num91);
                for (int index24 = 0; index24 < 5; ++index24)
                {
                  int num92 = 0;
                  int num93 = 0;
                  if (index24 == 0)
                    --num92;
                  else if (index24 == 1)
                    ++num92;
                  else if (index24 == 2)
                    --num93;
                  else if (index24 == 3)
                  {
                    ++num93;
                  }
                  else
                  {
                    float num94 = (float) Main.combatText[index22].color.R * Main.combatText[index22].scale * Main.combatText[index22].alpha;
                    float num95 = (float) Main.combatText[index22].color.B * Main.combatText[index22].scale * Main.combatText[index22].alpha;
                    float num96 = (float) Main.combatText[index22].color.G * Main.combatText[index22].scale * Main.combatText[index22].alpha;
                    float num97 = (float) Main.combatText[index22].color.A * Main.combatText[index22].scale * Main.combatText[index22].alpha;
                    color8 = new Microsoft.Xna.Framework.Color((int) num94, (int) num96, (int) num95, (int) num97);
                  }
                  this.spriteBatch.DrawString(Main.fontCombatText[index23], Main.combatText[index22].text, new Vector2(Main.combatText[index22].position.X - Main.screenPosition.X + (float) num92 + origin.X, Main.combatText[index22].position.Y - Main.screenPosition.Y + (float) num93 + origin.Y), color8, Main.combatText[index22].rotation, origin, Main.combatText[index22].scale, SpriteEffects.None, 0.0f);
                }
              }
            }
            for (int index25 = 0; index25 < 20; ++index25)
            {
              if (Main.itemText[index25].active)
              {
                string text = Main.itemText[index25].name;
                if (Main.itemText[index25].stack > 1)
                  text = text + " (" + (object) Main.itemText[index25].stack + ")";
                Vector2 vector2 = Main.fontMouseText.MeasureString(text);
                Vector2 origin = new Vector2(vector2.X * 0.5f, vector2.Y * 0.5f);
                double scale24 = (double) Main.itemText[index25].scale;
                float r = (float) Main.itemText[index25].color.R;
                float g = (float) Main.itemText[index25].color.G;
                float b9 = (float) Main.itemText[index25].color.B;
                float a = (float) Main.itemText[index25].color.A;
                float num98 = r * (float) ((double) Main.itemText[index25].scale * (double) Main.itemText[index25].alpha * 0.300000011920929);
                float num99 = b9 * (float) ((double) Main.itemText[index25].scale * (double) Main.itemText[index25].alpha * 0.300000011920929);
                float num100 = g * (float) ((double) Main.itemText[index25].scale * (double) Main.itemText[index25].alpha * 0.300000011920929);
                float num101 = a * (Main.itemText[index25].scale * Main.itemText[index25].alpha);
                Microsoft.Xna.Framework.Color color9 = new Microsoft.Xna.Framework.Color((int) num98, (int) num100, (int) num99, (int) num101);
                for (int index26 = 0; index26 < 5; ++index26)
                {
                  int num102 = 0;
                  int num103 = 0;
                  if (index26 == 0)
                    num102 -= 2;
                  else if (index26 == 1)
                    num102 += 2;
                  else if (index26 == 2)
                    num103 -= 2;
                  else if (index26 == 3)
                  {
                    num103 += 2;
                  }
                  else
                  {
                    float num104 = (float) Main.itemText[index25].color.R * Main.itemText[index25].scale * Main.itemText[index25].alpha;
                    float num105 = (float) Main.itemText[index25].color.B * Main.itemText[index25].scale * Main.itemText[index25].alpha;
                    float num106 = (float) Main.itemText[index25].color.G * Main.itemText[index25].scale * Main.itemText[index25].alpha;
                    float num107 = (float) Main.itemText[index25].color.A * Main.itemText[index25].scale * Main.itemText[index25].alpha;
                    color9 = new Microsoft.Xna.Framework.Color((int) num104, (int) num106, (int) num105, (int) num107);
                  }
                  if (index26 < 4)
                    color9 = new Microsoft.Xna.Framework.Color(0, 0, 0, (int) ((float) Main.itemText[index25].color.A * Main.itemText[index25].scale * Main.itemText[index25].alpha));
                  this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2(Main.itemText[index25].position.X - Main.screenPosition.X + (float) num102 + origin.X, Main.itemText[index25].position.Y - Main.screenPosition.Y + (float) num103 + origin.Y), color9, Main.itemText[index25].rotation, origin, Main.itemText[index25].scale, SpriteEffects.None, 0.0f);
                }
              }
            }
            if (Main.netMode == 1 && Netplay.clientSock.statusText != "" && Netplay.clientSock.statusText != null)
            {
              string text = Netplay.clientSock.statusText + ": " + (object) (int) ((double) Netplay.clientSock.statusCount / (double) Netplay.clientSock.statusMax * 100.0) + "%";
              this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float) (628.0 - (double) Main.fontMouseText.MeasureString(text).X * 0.5) + (float) (Main.screenWidth - 800), 84f), new Microsoft.Xna.Framework.Color((int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor, (int) Main.mouseTextColor), 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
            this.DrawFPS();
            this.DrawInterface();
          }
          else
            Main.maxQ = true;
          this.spriteBatch.End();
          Main.mouseLeftRelease = !Main.mouseLeft;
          Main.mouseRightRelease = !Main.mouseRight;
          if (Main.mouseState.RightButton != ButtonState.Pressed)
            Main.stackSplit = 0;
          if (Main.stackSplit > 0)
            --Main.stackSplit;
          if (Main.renderCount >= 10)
            return;
          Main.drawTimer[Main.renderCount] = (float) stopwatch.ElapsedMilliseconds;
          if ((double) Main.drawTimerMaxDelay[Main.renderCount] > 0.0)
            --Main.drawTimerMaxDelay[Main.renderCount];
          else
            Main.drawTimerMax[Main.renderCount] = 0.0f;
          if ((double) Main.drawTimer[Main.renderCount] <= (double) Main.drawTimerMax[Main.renderCount])
            return;
          Main.drawTimerMax[Main.renderCount] = Main.drawTimer[Main.renderCount];
          Main.drawTimerMaxDelay[Main.renderCount] = 100f;
        }
      }
    }

    private static void UpdateInvasion()
    {
      if (Main.invasionType <= 0)
        return;
      if (Main.invasionSize <= 0)
      {
        switch (Main.invasionType)
        {
          case 1:
            NPC.downedGoblins = true;
            if (Main.netMode == 2)
            {
              NetMessage.SendData(7);
              break;
            }
            break;
          case 2:
            NPC.downedFrost = true;
            break;
        }
        Main.InvasionWarning();
        Main.invasionType = 0;
        Main.invasionDelay = 7;
      }
      if (Main.invasionX == (double) Main.spawnTileX)
        return;
      float num = 1f;
      if (Main.invasionX > (double) Main.spawnTileX)
      {
        Main.invasionX -= (double) num;
        if (Main.invasionX <= (double) Main.spawnTileX)
        {
          Main.invasionX = (double) Main.spawnTileX;
          Main.InvasionWarning();
        }
        else
          --Main.invasionWarn;
      }
      else if (Main.invasionX < (double) Main.spawnTileX)
      {
        Main.invasionX += (double) num;
        if (Main.invasionX >= (double) Main.spawnTileX)
        {
          Main.invasionX = (double) Main.spawnTileX;
          Main.InvasionWarning();
        }
        else
          --Main.invasionWarn;
      }
      if (Main.invasionWarn > 0)
        return;
      Main.invasionWarn = 3600;
      Main.InvasionWarning();
    }

    private static void InvasionWarning()
    {
      string str1 = "";
      string str2 = Main.invasionSize > 0 ? (Main.invasionX >= (double) Main.spawnTileX ? (Main.invasionX <= (double) Main.spawnTileX ? (Main.invasionType != 2 ? (str1 = Lang.misc[3]) : Lang.misc[7]) : (Main.invasionType != 2 ? (str1 = Lang.misc[2]) : Lang.misc[6])) : (Main.invasionType != 2 ? (str1 = Lang.misc[1]) : Lang.misc[5])) : (Main.invasionType != 2 ? (str1 = Lang.misc[0]) : Lang.misc[4]);
      if (Main.netMode == 0)
      {
        Main.NewText(str2, (byte) 175, (byte) 75);
      }
      else
      {
        if (Main.netMode != 2)
          return;
        NetMessage.SendData(25, text: str2, number: ((int) byte.MaxValue), number2: 175f, number3: 75f, number4: ((float) byte.MaxValue));
      }
    }

    public static void StartInvasion(int type = 1)
    {
      if (Main.invasionType != 0 || Main.invasionDelay != 0)
        return;
      int num = 0;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active && Main.player[index].statLifeMax >= 200)
          ++num;
      }
      if (num <= 0)
        return;
      Main.invasionType = type;
      Main.invasionSize = 80 + 40 * num;
      Main.invasionWarn = 0;
      if (Main.rand.Next(2) == 0)
        Main.invasionX = 0.0;
      else
        Main.invasionX = (double) Main.maxTilesX;
    }

    private static void UpdateClient()
    {
      if (Main.myPlayer == (int) byte.MaxValue)
        Netplay.disconnect = true;
      ++Main.netPlayCounter;
      if (Main.netPlayCounter > 3600)
        Main.netPlayCounter = 0;
      if (Math.IEEERemainder((double) Main.netPlayCounter, 300.0) == 0.0)
      {
        NetMessage.SendData(13, number: Main.myPlayer);
        NetMessage.SendData(36, number: Main.myPlayer);
      }
      if (Math.IEEERemainder((double) Main.netPlayCounter, 600.0) == 0.0)
      {
        NetMessage.SendData(16, number: Main.myPlayer);
        NetMessage.SendData(40, number: Main.myPlayer);
      }
      if (Netplay.clientSock.active)
      {
        ++Netplay.clientSock.timeOut;
        if (!Main.stopTimeOuts && Netplay.clientSock.timeOut > 60 * Main.timeOut)
        {
          Main.statusText = Lang.inter[43];
          Netplay.disconnect = true;
        }
      }
      for (int whoAmI = 0; whoAmI < 200; ++whoAmI)
      {
        if (Main.item[whoAmI].active && Main.item[whoAmI].owner == Main.myPlayer)
          Main.item[whoAmI].FindOwner(whoAmI);
      }
    }

    private static void UpdateServer()
    {
      ++Main.netPlayCounter;
      if (Main.netPlayCounter > 3600)
      {
        NetMessage.SendData(7);
        NetMessage.syncPlayers();
        Main.netPlayCounter = 0;
      }
      for (int index = 0; index < Main.maxNetPlayers; ++index)
      {
        if (Main.player[index].active && Netplay.serverSock[index].active)
          Netplay.serverSock[index].SpamUpdate();
      }
      if (Math.IEEERemainder((double) Main.netPlayCounter, 900.0) == 0.0)
      {
        bool flag = true;
        int number = Main.lastItemUpdate;
        int num = 0;
        while (flag)
        {
          ++number;
          if (number >= 200)
            number = 0;
          ++num;
          if (!Main.item[number].active || Main.item[number].owner == (int) byte.MaxValue)
            NetMessage.SendData(21, number: number);
          if (num >= Main.maxItemUpdates || number == Main.lastItemUpdate)
            flag = false;
        }
        Main.lastItemUpdate = number;
      }
      for (int whoAmI = 0; whoAmI < 200; ++whoAmI)
      {
        if (Main.item[whoAmI].active && (Main.item[whoAmI].owner == (int) byte.MaxValue || !Main.player[Main.item[whoAmI].owner].active))
          Main.item[whoAmI].FindOwner(whoAmI);
      }
      for (int index1 = 0; index1 < (int) byte.MaxValue; ++index1)
      {
        if (Netplay.serverSock[index1].active)
        {
          ++Netplay.serverSock[index1].timeOut;
          if (!Main.stopTimeOuts && Netplay.serverSock[index1].timeOut > 60 * Main.timeOut)
            Netplay.serverSock[index1].kill = true;
        }
        if (Main.player[index1].active)
        {
          int sectionX = Netplay.GetSectionX((int) ((double) Main.player[index1].position.X / 16.0));
          int sectionY1 = Netplay.GetSectionY((int) ((double) Main.player[index1].position.Y / 16.0));
          int num = 0;
          for (int index2 = sectionX - 1; index2 < sectionX + 2; ++index2)
          {
            for (int index3 = sectionY1 - 1; index3 < sectionY1 + 2; ++index3)
            {
              if (index2 >= 0 && index2 < Main.maxSectionsX && index3 >= 0 && index3 < Main.maxSectionsY && !Netplay.serverSock[index1].tileSection[index2, index3])
                ++num;
            }
          }
          if (num > 0)
          {
            int number = num * 150;
            NetMessage.SendData(9, index1, text: "Receiving tile data", number: number);
            Netplay.serverSock[index1].statusText2 = "is receiving tile data";
            Netplay.serverSock[index1].statusMax += number;
            for (int index4 = sectionX - 1; index4 < sectionX + 2; ++index4)
            {
              for (int sectionY2 = sectionY1 - 1; sectionY2 < sectionY1 + 2; ++sectionY2)
              {
                if (index4 >= 0 && index4 < Main.maxSectionsX && sectionY2 >= 0 && sectionY2 < Main.maxSectionsY && !Netplay.serverSock[index1].tileSection[index4, sectionY2])
                {
                  NetMessage.SendSection(index1, index4, sectionY2);
                  NetMessage.SendData(11, index1, number: index4, number2: ((float) sectionY2), number3: ((float) index4), number4: ((float) sectionY2));
                }
              }
            }
          }
        }
      }
    }

    public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255)
    {
      for (int index = Main.numChatLines - 1; index > 0; --index)
      {
        Main.chatLine[index].text = Main.chatLine[index - 1].text;
        Main.chatLine[index].showTime = Main.chatLine[index - 1].showTime;
        Main.chatLine[index].color = Main.chatLine[index - 1].color;
      }
      Main.chatLine[0].color = R != (byte) 0 || G != (byte) 0 || B != (byte) 0 ? new Microsoft.Xna.Framework.Color((int) R, (int) G, (int) B) : Microsoft.Xna.Framework.Color.White;
      Main.chatLine[0].text = newText;
      Main.chatLine[0].showTime = Main.chatLength;
      Main.PlaySound(12);
    }

    private static void UpdateTime()
    {
      Main.time += (double) Main.dayRate;
      if (!Main.dayTime)
      {
        if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860.0)
        {
          for (int plr = 0; plr < (int) byte.MaxValue; ++plr)
          {
            if (Main.player[plr].active && !Main.player[plr].dead && (double) Main.player[plr].position.Y < Main.worldSurface * 16.0)
            {
              NPC.SpawnOnPlayer(plr, 4);
              WorldGen.spawnEye = false;
              break;
            }
          }
        }
        if (Main.time > 32400.0)
        {
          Main.checkXMas();
          if (Main.invasionDelay > 0)
            --Main.invasionDelay;
          WorldGen.spawnNPC = 0;
          Main.checkForSpawns = 0;
          Main.time = 0.0;
          Main.bloodMoon = false;
          Main.dayTime = true;
          ++Main.moonPhase;
          if (Main.moonPhase >= 8)
            Main.moonPhase = 0;
          if (Main.netMode == 2)
          {
            NetMessage.SendData(7);
            WorldGen.saveAndPlay();
          }
          if (Main.netMode != 1 && WorldGen.shadowOrbSmashed)
          {
            if (!NPC.downedGoblins)
            {
              if (Main.rand.Next(3) == 0)
                Main.StartInvasion();
            }
            else if (Main.rand.Next(15) == 0)
              Main.StartInvasion();
          }
        }
        if (Main.time <= 16200.0 || !WorldGen.spawnMeteor)
          return;
        WorldGen.spawnMeteor = false;
        WorldGen.dropMeteor();
      }
      else
      {
        Main.bloodMoon = false;
        if (Main.time > 54000.0)
        {
          WorldGen.spawnNPC = 0;
          Main.checkForSpawns = 0;
          if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
            WorldGen.spawnMeteor = true;
          if (!NPC.downedBoss1 && Main.netMode != 1)
          {
            bool flag = false;
            for (int index = 0; index < (int) byte.MaxValue; ++index)
            {
              if (Main.player[index].active && Main.player[index].statLifeMax >= 200 && Main.player[index].statDefense > 10)
              {
                flag = true;
                break;
              }
            }
            if (flag && Main.rand.Next(3) == 0)
            {
              int num = 0;
              for (int index = 0; index < 200; ++index)
              {
                if (Main.npc[index].active && Main.npc[index].townNPC)
                  ++num;
              }
              if (num >= 4)
              {
                WorldGen.spawnEye = true;
                switch (Main.netMode)
                {
                  case 0:
                    Main.NewText(Lang.misc[9], (byte) 50, B: (byte) 130);
                    break;
                  case 2:
                    NetMessage.SendData(25, text: Lang.misc[9], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
                    break;
                }
              }
            }
          }
          if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
          {
            for (int index = 0; index < (int) byte.MaxValue; ++index)
            {
              if (Main.player[index].active && Main.player[index].statLifeMax > 120)
              {
                Main.bloodMoon = true;
                break;
              }
            }
            if (Main.bloodMoon)
            {
              switch (Main.netMode)
              {
                case 0:
                  Main.NewText(Lang.misc[8], (byte) 50, B: (byte) 130);
                  break;
                case 2:
                  NetMessage.SendData(25, text: Lang.misc[8], number: ((int) byte.MaxValue), number2: 50f, number3: ((float) byte.MaxValue), number4: 130f);
                  break;
              }
            }
          }
          Main.time = 0.0;
          Main.dayTime = false;
          if (Main.netMode == 2)
            NetMessage.SendData(7);
        }
        if (Main.netMode == 1)
          return;
        ++Main.checkForSpawns;
        if (Main.checkForSpawns < 7200)
          return;
        int num1 = 0;
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (Main.player[index].active)
            ++num1;
        }
        Main.checkForSpawns = 0;
        WorldGen.spawnNPC = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        int num7 = 0;
        int num8 = 0;
        int num9 = 0;
        int num10 = 0;
        int num11 = 0;
        int num12 = 0;
        int num13 = 0;
        int num14 = 0;
        for (int npc = 0; npc < 200; ++npc)
        {
          if (Main.npc[npc].active && Main.npc[npc].townNPC)
          {
            if (Main.npc[npc].type != 37 && !Main.npc[npc].homeless)
              WorldGen.QuickFindHome(npc);
            if (Main.npc[npc].type == 37)
              ++num7;
            if (Main.npc[npc].type == 17)
              ++num2;
            if (Main.npc[npc].type == 18)
              ++num3;
            if (Main.npc[npc].type == 19)
              ++num5;
            if (Main.npc[npc].type == 20)
              ++num4;
            if (Main.npc[npc].type == 22)
              ++num6;
            if (Main.npc[npc].type == 38)
              ++num8;
            if (Main.npc[npc].type == 54)
              ++num9;
            if (Main.npc[npc].type == 107)
              ++num11;
            if (Main.npc[npc].type == 108)
              ++num10;
            if (Main.npc[npc].type == 124)
              ++num12;
            if (Main.npc[npc].type == 142)
              ++num13;
            ++num14;
          }
        }
        if (WorldGen.spawnNPC != 0)
          return;
        int num15 = 0;
        bool flag1 = false;
        int num16 = 0;
        bool flag2 = false;
        bool flag3 = false;
        for (int index1 = 0; index1 < (int) byte.MaxValue; ++index1)
        {
          if (Main.player[index1].active)
          {
            for (int index2 = 0; index2 < 48; ++index2)
            {
              if (Main.player[index1].inventory[index2] != null & Main.player[index1].inventory[index2].stack > 0)
              {
                if (Main.player[index1].inventory[index2].type == 71)
                  num15 += Main.player[index1].inventory[index2].stack;
                if (Main.player[index1].inventory[index2].type == 72)
                  num15 += Main.player[index1].inventory[index2].stack * 100;
                if (Main.player[index1].inventory[index2].type == 73)
                  num15 += Main.player[index1].inventory[index2].stack * 10000;
                if (Main.player[index1].inventory[index2].type == 74)
                  num15 += Main.player[index1].inventory[index2].stack * 1000000;
                if (Main.player[index1].inventory[index2].ammo == 14 || Main.player[index1].inventory[index2].useAmmo == 14)
                  flag2 = true;
                if (Main.player[index1].inventory[index2].type == 166 || Main.player[index1].inventory[index2].type == 167 || Main.player[index1].inventory[index2].type == 168 || Main.player[index1].inventory[index2].type == 235)
                  flag3 = true;
              }
            }
            int num17 = Main.player[index1].statLifeMax / 20;
            if (num17 > 5)
              flag1 = true;
            num16 += num17;
          }
        }
        if (!NPC.downedBoss3 && num7 == 0)
        {
          int index = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37);
          Main.npc[index].homeless = false;
          Main.npc[index].homeTileX = Main.dungeonX;
          Main.npc[index].homeTileY = Main.dungeonY;
        }
        if (WorldGen.spawnNPC == 0 && num6 < 1)
          WorldGen.spawnNPC = 22;
        if (WorldGen.spawnNPC == 0 && (double) num15 > 5000.0 && num2 < 1)
          WorldGen.spawnNPC = 17;
        if (WorldGen.spawnNPC == 0 && flag1 && num3 < 1)
          WorldGen.spawnNPC = 18;
        if (WorldGen.spawnNPC == 0 && flag2 && num5 < 1)
          WorldGen.spawnNPC = 19;
        if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num4 < 1)
          WorldGen.spawnNPC = 20;
        if (WorldGen.spawnNPC == 0 && flag3 && num2 > 0 && num8 < 1)
          WorldGen.spawnNPC = 38;
        if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num9 < 1)
          WorldGen.spawnNPC = 54;
        if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num11 < 1)
          WorldGen.spawnNPC = 107;
        if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num10 < 1)
          WorldGen.spawnNPC = 108;
        if (WorldGen.spawnNPC == 0 && NPC.savedMech && num12 < 1)
          WorldGen.spawnNPC = 124;
        if (WorldGen.spawnNPC != 0 || !NPC.downedFrost || num13 >= 1 || !Main.xMas)
          return;
        WorldGen.spawnNPC = 142;
      }
    }

    public static int DamageVar(float dmg) => (int) Math.Round((double) (dmg * (float) (1.0 + (double) Main.rand.Next(-15, 16) * 0.00999999977648258)));

    public static double CalculateDamage(int Damage, int Defense)
    {
      double num = (double) Damage - (double) Defense * 0.5;
      if (num < 1.0)
        num = 1.0;
      return num;
    }

    public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
    {
      int index1 = Style;
      try
      {
        if (Main.dedServ || (double) Main.soundVolume == 0.0)
          return;
        bool flag = false;
        float num1 = 1f;
        float num2 = 0.0f;
        if (x == -1 || y == -1)
        {
          flag = true;
        }
        else
        {
          if (WorldGen.gen || Main.netMode == 2)
            return;
          Rectangle rectangle1 = new Rectangle((int) ((double) Main.screenPosition.X - (double) (Main.screenWidth * 2)), (int) ((double) Main.screenPosition.Y - (double) (Main.screenHeight * 2)), Main.screenWidth * 5, Main.screenHeight * 5);
          Rectangle rectangle2 = new Rectangle(x, y, 1, 1);
          Vector2 vector2 = new Vector2(Main.screenPosition.X + (float) Main.screenWidth * 0.5f, Main.screenPosition.Y + (float) Main.screenHeight * 0.5f);
          if (rectangle2.Intersects(rectangle1))
            flag = true;
          if (flag)
          {
            num2 = (float) (((double) x - (double) vector2.X) / ((double) Main.screenWidth * 0.5));
            float num3 = Math.Abs((float) x - vector2.X);
            float num4 = Math.Abs((float) y - vector2.Y);
            num1 = (float) (1.0 - Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4) / ((double) Main.screenWidth * 1.5));
          }
        }
        if ((double) num2 < -1.0)
          num2 = -1f;
        if ((double) num2 > 1.0)
          num2 = 1f;
        if ((double) num1 > 1.0)
          num1 = 1f;
        if ((double) num1 <= 0.0 || !flag)
          return;
        float num5 = num1 * Main.soundVolume;
        switch (type)
        {
          case 0:
            int index2 = Main.rand.Next(3);
            Main.soundInstanceDig[index2].Stop();
            Main.soundInstanceDig[index2] = Main.soundDig[index2].CreateInstance();
            Main.soundInstanceDig[index2].Volume = num5;
            Main.soundInstanceDig[index2].Pan = num2;
            Main.soundInstanceDig[index2].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceDig[index2].Play();
            break;
          case 1:
            int index3 = Main.rand.Next(3);
            Main.soundInstancePlayerHit[index3].Stop();
            Main.soundInstancePlayerHit[index3] = Main.soundPlayerHit[index3].CreateInstance();
            Main.soundInstancePlayerHit[index3].Volume = num5;
            Main.soundInstancePlayerHit[index3].Pan = num2;
            Main.soundInstancePlayerHit[index3].Play();
            break;
          case 2:
            if (index1 == 1)
            {
              int num6 = Main.rand.Next(3);
              if (num6 == 1)
                index1 = 18;
              if (num6 == 2)
                index1 = 19;
            }
            if (index1 != 9 && index1 != 10 && index1 != 24 && index1 != 26 && index1 != 34)
              Main.soundInstanceItem[index1].Stop();
            Main.soundInstanceItem[index1] = Main.soundItem[index1].CreateInstance();
            Main.soundInstanceItem[index1].Volume = num5;
            Main.soundInstanceItem[index1].Pan = num2;
            Main.soundInstanceItem[index1].Pitch = (float) Main.rand.Next(-6, 7) * 0.01f;
            if (index1 == 26 || index1 == 35)
            {
              Main.soundInstanceItem[index1].Volume = num5 * 0.75f;
              Main.soundInstanceItem[index1].Pitch = Main.harpNote;
            }
            Main.soundInstanceItem[index1].Play();
            break;
          case 3:
            Main.soundInstanceNPCHit[index1].Stop();
            Main.soundInstanceNPCHit[index1] = Main.soundNPCHit[index1].CreateInstance();
            Main.soundInstanceNPCHit[index1].Volume = num5;
            Main.soundInstanceNPCHit[index1].Pan = num2;
            Main.soundInstanceNPCHit[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceNPCHit[index1].Play();
            break;
          case 4:
            if (index1 == 10 && Main.soundInstanceNPCKilled[index1].State == SoundState.Playing)
              break;
            Main.soundInstanceNPCKilled[index1] = Main.soundNPCKilled[index1].CreateInstance();
            Main.soundInstanceNPCKilled[index1].Volume = num5;
            Main.soundInstanceNPCKilled[index1].Pan = num2;
            Main.soundInstanceNPCKilled[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceNPCKilled[index1].Play();
            break;
          case 5:
            Main.soundInstancePlayerKilled.Stop();
            Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
            Main.soundInstancePlayerKilled.Volume = num5;
            Main.soundInstancePlayerKilled.Pan = num2;
            Main.soundInstancePlayerKilled.Play();
            break;
          case 6:
            Main.soundInstanceGrass.Stop();
            Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
            Main.soundInstanceGrass.Volume = num5;
            Main.soundInstanceGrass.Pan = num2;
            Main.soundInstanceGrass.Pitch = (float) Main.rand.Next(-30, 31) * 0.01f;
            Main.soundInstanceGrass.Play();
            break;
          case 7:
            Main.soundInstanceGrab.Stop();
            Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
            Main.soundInstanceGrab.Volume = num5;
            Main.soundInstanceGrab.Pan = num2;
            Main.soundInstanceGrab.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceGrab.Play();
            break;
          case 8:
            Main.soundInstanceDoorOpen.Stop();
            Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
            Main.soundInstanceDoorOpen.Volume = num5;
            Main.soundInstanceDoorOpen.Pan = num2;
            Main.soundInstanceDoorOpen.Pitch = (float) Main.rand.Next(-20, 21) * 0.01f;
            Main.soundInstanceDoorOpen.Play();
            break;
          case 9:
            Main.soundInstanceDoorClosed.Stop();
            Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
            Main.soundInstanceDoorClosed.Volume = num5;
            Main.soundInstanceDoorClosed.Pan = num2;
            Main.soundInstanceDoorOpen.Pitch = (float) Main.rand.Next(-20, 21) * 0.01f;
            Main.soundInstanceDoorClosed.Play();
            break;
          case 10:
            Main.soundInstanceMenuOpen.Stop();
            Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
            Main.soundInstanceMenuOpen.Volume = num5;
            Main.soundInstanceMenuOpen.Pan = num2;
            Main.soundInstanceMenuOpen.Play();
            break;
          case 11:
            Main.soundInstanceMenuClose.Stop();
            Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
            Main.soundInstanceMenuClose.Volume = num5;
            Main.soundInstanceMenuClose.Pan = num2;
            Main.soundInstanceMenuClose.Play();
            break;
          case 12:
            Main.soundInstanceMenuTick.Stop();
            Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
            Main.soundInstanceMenuTick.Volume = num5;
            Main.soundInstanceMenuTick.Pan = num2;
            Main.soundInstanceMenuTick.Play();
            break;
          case 13:
            Main.soundInstanceShatter.Stop();
            Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
            Main.soundInstanceShatter.Volume = num5;
            Main.soundInstanceShatter.Pan = num2;
            Main.soundInstanceShatter.Play();
            break;
          case 14:
            int index4 = Main.rand.Next(3);
            Main.soundInstanceZombie[index4] = Main.soundZombie[index4].CreateInstance();
            Main.soundInstanceZombie[index4].Volume = num5 * 0.4f;
            Main.soundInstanceZombie[index4].Pan = num2;
            Main.soundInstanceZombie[index4].Play();
            break;
          case 15:
            if (Main.soundInstanceRoar[index1].State != SoundState.Stopped)
              break;
            Main.soundInstanceRoar[index1] = Main.soundRoar[index1].CreateInstance();
            Main.soundInstanceRoar[index1].Volume = num5;
            Main.soundInstanceRoar[index1].Pan = num2;
            Main.soundInstanceRoar[index1].Play();
            break;
          case 16:
            Main.soundInstanceDoubleJump.Stop();
            Main.soundInstanceDoubleJump = Main.soundDoubleJump.CreateInstance();
            Main.soundInstanceDoubleJump.Volume = num5;
            Main.soundInstanceDoubleJump.Pan = num2;
            Main.soundInstanceDoubleJump.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceDoubleJump.Play();
            break;
          case 17:
            Main.soundInstanceRun.Stop();
            Main.soundInstanceRun = Main.soundRun.CreateInstance();
            Main.soundInstanceRun.Volume = num5;
            Main.soundInstanceRun.Pan = num2;
            Main.soundInstanceRun.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceRun.Play();
            break;
          case 18:
            Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
            Main.soundInstanceCoins.Volume = num5;
            Main.soundInstanceCoins.Pan = num2;
            Main.soundInstanceCoins.Play();
            break;
          case 19:
            if (Main.soundInstanceSplash[index1].State != SoundState.Stopped)
              break;
            Main.soundInstanceSplash[index1] = Main.soundSplash[index1].CreateInstance();
            Main.soundInstanceSplash[index1].Volume = num5;
            Main.soundInstanceSplash[index1].Pan = num2;
            Main.soundInstanceSplash[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceSplash[index1].Play();
            break;
          case 20:
            int index5 = Main.rand.Next(3);
            Main.soundInstanceFemaleHit[index5].Stop();
            Main.soundInstanceFemaleHit[index5] = Main.soundFemaleHit[index5].CreateInstance();
            Main.soundInstanceFemaleHit[index5].Volume = num5;
            Main.soundInstanceFemaleHit[index5].Pan = num2;
            Main.soundInstanceFemaleHit[index5].Play();
            break;
          case 21:
            int index6 = Main.rand.Next(3);
            Main.soundInstanceTink[index6].Stop();
            Main.soundInstanceTink[index6] = Main.soundTink[index6].CreateInstance();
            Main.soundInstanceTink[index6].Volume = num5;
            Main.soundInstanceTink[index6].Pan = num2;
            Main.soundInstanceTink[index6].Play();
            break;
          case 22:
            Main.soundInstanceUnlock.Stop();
            Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
            Main.soundInstanceUnlock.Volume = num5;
            Main.soundInstanceUnlock.Pan = num2;
            Main.soundInstanceUnlock.Play();
            break;
          case 23:
            Main.soundInstanceDrown.Stop();
            Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
            Main.soundInstanceDrown.Volume = num5;
            Main.soundInstanceDrown.Pan = num2;
            Main.soundInstanceDrown.Play();
            break;
          case 24:
            Main.soundInstanceChat = Main.soundChat.CreateInstance();
            Main.soundInstanceChat.Volume = num5;
            Main.soundInstanceChat.Pan = num2;
            Main.soundInstanceChat.Play();
            break;
          case 25:
            Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
            Main.soundInstanceMaxMana.Volume = num5;
            Main.soundInstanceMaxMana.Pan = num2;
            Main.soundInstanceMaxMana.Play();
            break;
          case 26:
            int index7 = Main.rand.Next(3, 5);
            Main.soundInstanceZombie[index7] = Main.soundZombie[index7].CreateInstance();
            Main.soundInstanceZombie[index7].Volume = num5 * 0.9f;
            Main.soundInstanceZombie[index7].Pan = num2;
            Main.soundInstanceSplash[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceZombie[index7].Play();
            break;
          case 27:
            if (Main.soundInstancePixie.State == SoundState.Playing)
            {
              Main.soundInstancePixie.Volume = num5;
              Main.soundInstancePixie.Pan = num2;
              Main.soundInstancePixie.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
              break;
            }
            Main.soundInstancePixie.Stop();
            Main.soundInstancePixie = Main.soundPixie.CreateInstance();
            Main.soundInstancePixie.Volume = num5;
            Main.soundInstancePixie.Pan = num2;
            Main.soundInstancePixie.Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstancePixie.Play();
            break;
          case 28:
            if (Main.soundInstanceMech[index1].State == SoundState.Playing)
              break;
            Main.soundInstanceMech[index1] = Main.soundMech[index1].CreateInstance();
            Main.soundInstanceMech[index1].Volume = num5;
            Main.soundInstanceMech[index1].Pan = num2;
            Main.soundInstanceMech[index1].Pitch = (float) Main.rand.Next(-10, 11) * 0.01f;
            Main.soundInstanceMech[index1].Play();
            break;
        }
      }
      catch
      {
      }
    }
  }
}
