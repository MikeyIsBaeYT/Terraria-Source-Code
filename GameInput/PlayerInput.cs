// Decompiled with JetBrains decompiler
// Type: Terraria.GameInput.PlayerInput
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Chat;
using Terraria.GameContent.UI.States;
using Terraria.ID;
using Terraria.IO;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameInput
{
  public class PlayerInput
  {
    public static TriggersPack Triggers = new TriggersPack();
    public static List<string> KnownTriggers = new List<string>()
    {
      "MouseLeft",
      "MouseRight",
      "Up",
      "Down",
      "Left",
      "Right",
      "Jump",
      "Throw",
      "Inventory",
      "Grapple",
      "SmartSelect",
      "SmartCursor",
      "QuickMount",
      "QuickHeal",
      "QuickMana",
      "QuickBuff",
      "MapZoomIn",
      "MapZoomOut",
      "MapAlphaUp",
      "MapAlphaDown",
      "MapFull",
      "MapStyle",
      "Hotbar1",
      "Hotbar2",
      "Hotbar3",
      "Hotbar4",
      "Hotbar5",
      "Hotbar6",
      "Hotbar7",
      "Hotbar8",
      "Hotbar9",
      "Hotbar10",
      "HotbarMinus",
      "HotbarPlus",
      "DpadRadial1",
      "DpadRadial2",
      "DpadRadial3",
      "DpadRadial4",
      "RadialHotbar",
      "RadialQuickbar",
      "DpadSnap1",
      "DpadSnap2",
      "DpadSnap3",
      "DpadSnap4",
      "MenuUp",
      "MenuDown",
      "MenuLeft",
      "MenuRight",
      "LockOn",
      "ViewZoomIn",
      "ViewZoomOut"
    };
    private static bool _canReleaseRebindingLock = true;
    private static int _memoOfLastPoint = -1;
    public static int NavigatorRebindingLock = 0;
    public static string BlockedKey = "";
    private static string _listeningTrigger;
    private static InputMode _listeningInputMode;
    public static Dictionary<string, PlayerInputProfile> Profiles = new Dictionary<string, PlayerInputProfile>();
    public static Dictionary<string, PlayerInputProfile> OriginalProfiles = new Dictionary<string, PlayerInputProfile>();
    private static string _selectedProfile;
    private static PlayerInputProfile _currentProfile;
    public static InputMode CurrentInputMode = InputMode.Keyboard;
    private static Buttons[] ButtonsGamepad = (Buttons[]) Enum.GetValues(typeof (Buttons));
    public static bool GrappleAndInteractAreShared = false;
    private static string _invalidatorCheck = "";
    private static bool _lastActivityState = false;
    public static MouseState MouseInfo;
    public static MouseState MouseInfoOld;
    public static int MouseX;
    public static int MouseY;
    public static bool LockTileUseButton = false;
    public static List<string> MouseKeys = new List<string>();
    public static int PreUIX = 0;
    public static int PreUIY = 0;
    public static int PreLockOnX = 0;
    public static int PreLockOnY = 0;
    public static int ScrollWheelValue;
    public static int ScrollWheelValueOld;
    public static int ScrollWheelDelta;
    public static int ScrollWheelDeltaForUI;
    public static bool GamepadAllowScrolling;
    public static int GamepadScrollValue;
    public static Vector2 GamepadThumbstickLeft = Vector2.Zero;
    public static Vector2 GamepadThumbstickRight = Vector2.Zero;
    private static bool _InBuildingMode = false;
    private static int _UIPointForBuildingMode = -1;
    public static bool WritingText = false;
    private static int _originalMouseX;
    private static int _originalMouseY;
    private static int _originalLastMouseX;
    private static int _originalLastMouseY;
    private static int _originalScreenWidth;
    private static int _originalScreenHeight;
    private static ZoomContext _currentWantedZoom;
    private static int[] DpadSnapCooldown = new int[4];

    public static void ListenFor(string triggerName, InputMode inputmode)
    {
      PlayerInput._listeningTrigger = triggerName;
      PlayerInput._listeningInputMode = inputmode;
    }

    public static string ListeningTrigger => PlayerInput._listeningTrigger;

    public static bool CurrentlyRebinding => PlayerInput._listeningTrigger != null;

    public static bool InvisibleGamepadInMenus
    {
      get
      {
        if (((Main.gameMenu || Main.ingameOptionsWindow || Main.playerInventory || Main.player[Main.myPlayer].talkNPC != -1 ? 1 : (Main.player[Main.myPlayer].sign != -1 ? 1 : 0)) == 0 || PlayerInput._InBuildingMode ? 0 : (Main.InvisibleCursorForGamepad ? 1 : 0)) != 0)
          return true;
        return PlayerInput.CursorIsBusy && !PlayerInput._InBuildingMode;
      }
    }

    public static PlayerInputProfile CurrentProfile => PlayerInput._currentProfile;

    public static KeyConfiguration ProfileGamepadUI => PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI];

    public static bool UsingGamepad => PlayerInput.CurrentInputMode == InputMode.XBoxGamepad || PlayerInput.CurrentInputMode == InputMode.XBoxGamepadUI;

    public static bool UsingGamepadUI => PlayerInput.CurrentInputMode == InputMode.XBoxGamepadUI;

    public static bool IgnoreMouseInterface => PlayerInput.UsingGamepad && !UILinkPointNavigator.Available;

    private static bool InvalidateKeyboardSwap()
    {
      if (PlayerInput._invalidatorCheck.Length == 0)
        return false;
      string str = "";
      foreach (Keys pressedKey in Main.keyState.GetPressedKeys())
        str = str + pressedKey.ToString() + ", ";
      if (str == PlayerInput._invalidatorCheck)
        return true;
      PlayerInput._invalidatorCheck = "";
      return false;
    }

    public static void ResetInputsOnActiveStateChange()
    {
      bool isActive = Main.instance.IsActive;
      if (PlayerInput._lastActivityState != isActive)
      {
        PlayerInput.MouseInfo = new MouseState();
        PlayerInput.MouseInfoOld = new MouseState();
        Main.keyState = Keyboard.GetState();
        Main.inputText = Keyboard.GetState();
        Main.oldInputText = Keyboard.GetState();
        Main.keyCount = 0;
        PlayerInput.Triggers.Reset();
        PlayerInput.Triggers.Reset();
        string str = "";
        foreach (Keys pressedKey in Main.keyState.GetPressedKeys())
          str = str + pressedKey.ToString() + ", ";
        PlayerInput._invalidatorCheck = str;
      }
      PlayerInput._lastActivityState = isActive;
    }

    public static bool InBuildingMode => PlayerInput._InBuildingMode;

    public static void EnterBuildingMode()
    {
      PlayerInput._InBuildingMode = true;
      PlayerInput._UIPointForBuildingMode = UILinkPointNavigator.CurrentPoint;
      Main.SmartCursorEnabled = true;
      if (Main.mouseItem.stack > 0)
        return;
      int pointForBuildingMode = PlayerInput._UIPointForBuildingMode;
      if (pointForBuildingMode >= 50 || pointForBuildingMode < 0 || Main.player[Main.myPlayer].inventory[pointForBuildingMode].stack <= 0)
        return;
      Utils.Swap<Item>(ref Main.mouseItem, ref Main.player[Main.myPlayer].inventory[pointForBuildingMode]);
    }

    public static void ExitBuildingMode()
    {
      PlayerInput._InBuildingMode = false;
      UILinkPointNavigator.ChangePoint(PlayerInput._UIPointForBuildingMode);
      if (Main.mouseItem.stack > 0 && Main.player[Main.myPlayer].itemAnimation == 0)
      {
        int pointForBuildingMode = PlayerInput._UIPointForBuildingMode;
        if (pointForBuildingMode < 50 && pointForBuildingMode >= 0 && Main.player[Main.myPlayer].inventory[pointForBuildingMode].stack <= 0)
          Utils.Swap<Item>(ref Main.mouseItem, ref Main.player[Main.myPlayer].inventory[pointForBuildingMode]);
      }
      PlayerInput._UIPointForBuildingMode = -1;
    }

    public static void VerifyBuildingMode()
    {
      if (!PlayerInput._InBuildingMode)
        return;
      Player player = Main.player[Main.myPlayer];
      bool flag = false;
      if (Main.mouseItem.stack <= 0)
        flag = true;
      if (player.dead)
        flag = true;
      if (!flag)
        return;
      PlayerInput.ExitBuildingMode();
    }

    public static int RealScreenWidth => PlayerInput._originalScreenWidth;

    public static int RealScreenHeight => PlayerInput._originalScreenHeight;

    public static void SetSelectedProfile(string name)
    {
      if (!PlayerInput.Profiles.ContainsKey(name))
        return;
      PlayerInput._selectedProfile = name;
      PlayerInput._currentProfile = PlayerInput.Profiles[PlayerInput._selectedProfile];
    }

    public static void Initialize()
    {
      Main.InputProfiles.OnProcessText += new Preferences.TextProcessAction(PlayerInput.PrettyPrintProfiles);
      Player.Hooks.OnEnterWorld += new Action<Player>(PlayerInput.Hook_OnEnterWorld);
      PlayerInputProfile playerInputProfile1 = new PlayerInputProfile("Redigit's Pick");
      playerInputProfile1.Initialize(PresetProfiles.Redigit);
      PlayerInput.Profiles.Add(playerInputProfile1.Name, playerInputProfile1);
      PlayerInputProfile playerInputProfile2 = new PlayerInputProfile("Yoraiz0r's Pick");
      playerInputProfile2.Initialize(PresetProfiles.Yoraiz0r);
      PlayerInput.Profiles.Add(playerInputProfile2.Name, playerInputProfile2);
      PlayerInputProfile playerInputProfile3 = new PlayerInputProfile("Console (Playstation)");
      playerInputProfile3.Initialize(PresetProfiles.ConsolePS);
      PlayerInput.Profiles.Add(playerInputProfile3.Name, playerInputProfile3);
      PlayerInputProfile playerInputProfile4 = new PlayerInputProfile("Console (Xbox)");
      playerInputProfile4.Initialize(PresetProfiles.ConsoleXBox);
      PlayerInput.Profiles.Add(playerInputProfile4.Name, playerInputProfile4);
      PlayerInputProfile playerInputProfile5 = new PlayerInputProfile("Custom");
      playerInputProfile5.Initialize(PresetProfiles.Redigit);
      PlayerInput.Profiles.Add(playerInputProfile5.Name, playerInputProfile5);
      PlayerInputProfile playerInputProfile6 = new PlayerInputProfile("Redigit's Pick");
      playerInputProfile6.Initialize(PresetProfiles.Redigit);
      PlayerInput.OriginalProfiles.Add(playerInputProfile6.Name, playerInputProfile6);
      PlayerInputProfile playerInputProfile7 = new PlayerInputProfile("Yoraiz0r's Pick");
      playerInputProfile7.Initialize(PresetProfiles.Yoraiz0r);
      PlayerInput.OriginalProfiles.Add(playerInputProfile7.Name, playerInputProfile7);
      PlayerInputProfile playerInputProfile8 = new PlayerInputProfile("Console (Playstation)");
      playerInputProfile8.Initialize(PresetProfiles.ConsolePS);
      PlayerInput.OriginalProfiles.Add(playerInputProfile8.Name, playerInputProfile8);
      PlayerInputProfile playerInputProfile9 = new PlayerInputProfile("Console (Xbox)");
      playerInputProfile9.Initialize(PresetProfiles.ConsoleXBox);
      PlayerInput.OriginalProfiles.Add(playerInputProfile9.Name, playerInputProfile9);
      PlayerInput.SetSelectedProfile("Custom");
      PlayerInput.Triggers.Initialize();
    }

    public static void Hook_OnEnterWorld(Player player)
    {
      if (!PlayerInput.UsingGamepad || player.whoAmI != Main.myPlayer)
        return;
      Main.SmartCursorEnabled = true;
    }

    public static bool Save()
    {
      Main.InputProfiles.Clear();
      Main.InputProfiles.Put("Selected Profile", (object) PlayerInput._selectedProfile);
      foreach (KeyValuePair<string, PlayerInputProfile> profile in PlayerInput.Profiles)
        Main.InputProfiles.Put(profile.Value.Name, (object) profile.Value.Save());
      return Main.InputProfiles.Save();
    }

    public static void Load()
    {
      Main.InputProfiles.Load();
      Dictionary<string, PlayerInputProfile> dictionary = new Dictionary<string, PlayerInputProfile>();
      string currentValue1 = (string) null;
      Main.InputProfiles.Get<string>("Selected Profile", ref currentValue1);
      List<string> allKeys = Main.InputProfiles.GetAllKeys();
      for (int index = 0; index < allKeys.Count; ++index)
      {
        string str = allKeys[index];
        if (!(str == "Selected Profile") && !string.IsNullOrEmpty(str))
        {
          Dictionary<string, object> currentValue2 = new Dictionary<string, object>();
          Main.InputProfiles.Get<Dictionary<string, object>>(str, ref currentValue2);
          if (currentValue2.Count > 0)
          {
            PlayerInputProfile playerInputProfile = new PlayerInputProfile(str);
            playerInputProfile.Initialize(PresetProfiles.None);
            if (playerInputProfile.Load(currentValue2))
              dictionary.Add(str, playerInputProfile);
          }
        }
      }
      if (dictionary.Count <= 0)
        return;
      PlayerInput.Profiles = dictionary;
      if (!string.IsNullOrEmpty(currentValue1) && PlayerInput.Profiles.ContainsKey(currentValue1))
        PlayerInput.SetSelectedProfile(currentValue1);
      else
        PlayerInput.SetSelectedProfile(PlayerInput.Profiles.Keys.First<string>());
    }

    public static void ManageVersion_1_3()
    {
      PlayerInputProfile profile = PlayerInput.Profiles["Custom"];
      string[,] strArray = new string[20, 2]
      {
        {
          "KeyUp",
          "Up"
        },
        {
          "KeyDown",
          "Down"
        },
        {
          "KeyLeft",
          "Left"
        },
        {
          "KeyRight",
          "Right"
        },
        {
          "KeyJump",
          "Jump"
        },
        {
          "KeyThrowItem",
          "Throw"
        },
        {
          "KeyInventory",
          "Inventory"
        },
        {
          "KeyQuickHeal",
          "QuickHeal"
        },
        {
          "KeyQuickMana",
          "QuickMana"
        },
        {
          "KeyQuickBuff",
          "QuickBuff"
        },
        {
          "KeyUseHook",
          "Grapple"
        },
        {
          "KeyAutoSelect",
          "SmartSelect"
        },
        {
          "KeySmartCursor",
          "SmartCursor"
        },
        {
          "KeyMount",
          "QuickMount"
        },
        {
          "KeyMapStyle",
          "MapStyle"
        },
        {
          "KeyFullscreenMap",
          "MapFull"
        },
        {
          "KeyMapZoomIn",
          "MapZoomIn"
        },
        {
          "KeyMapZoomOut",
          "MapZoomOut"
        },
        {
          "KeyMapAlphaUp",
          "MapAlphaUp"
        },
        {
          "KeyMapAlphaDown",
          "MapAlphaDown"
        }
      };
      for (int index = 0; index < strArray.GetLength(0); ++index)
      {
        string currentValue = (string) null;
        Main.Configuration.Get<string>(strArray[index, 0], ref currentValue);
        if (currentValue != null)
        {
          profile.InputModes[InputMode.Keyboard].KeyStatus[strArray[index, 1]] = new List<string>()
          {
            currentValue
          };
          profile.InputModes[InputMode.KeyboardUI].KeyStatus[strArray[index, 1]] = new List<string>()
          {
            currentValue
          };
        }
      }
    }

    public static bool CursorIsBusy => (double) ItemSlot.CircularRadialOpacity > 0.0 || (double) ItemSlot.QuicksRadialOpacity > 0.0;

    public static void UpdateInput()
    {
      PlayerInput.Triggers.Reset();
      PlayerInput.ScrollWheelValueOld = PlayerInput.ScrollWheelValue;
      PlayerInput.ScrollWheelValue = 0;
      PlayerInput.GamepadThumbstickLeft = Vector2.Zero;
      PlayerInput.GamepadThumbstickRight = Vector2.Zero;
      PlayerInput.GrappleAndInteractAreShared = PlayerInput.UsingGamepad && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].DoGrappleAndInteractShareTheSameKey;
      if (PlayerInput.InBuildingMode && !PlayerInput.UsingGamepad)
        PlayerInput.ExitBuildingMode();
      if (PlayerInput._canReleaseRebindingLock && PlayerInput.NavigatorRebindingLock > 0)
      {
        --PlayerInput.NavigatorRebindingLock;
        PlayerInput.Triggers.Current.UsedMovementKey = false;
        if (PlayerInput.NavigatorRebindingLock == 0 && PlayerInput._memoOfLastPoint != -1)
        {
          UIManageControls.ForceMoveTo = PlayerInput._memoOfLastPoint;
          PlayerInput._memoOfLastPoint = -1;
        }
      }
      PlayerInput._canReleaseRebindingLock = true;
      PlayerInput.VerifyBuildingMode();
      PlayerInput.MouseInput();
      PlayerInput.KeyboardInput();
      PlayerInput.GamePadInput();
      PlayerInput.Triggers.Update();
      PlayerInput.PostInput();
      PlayerInput.ScrollWheelDelta = PlayerInput.ScrollWheelValue - PlayerInput.ScrollWheelValueOld;
      PlayerInput.ScrollWheelDeltaForUI = PlayerInput.ScrollWheelDelta;
      PlayerInput.WritingText = false;
      PlayerInput.UpdateMainMouse();
      Main.mouseLeft = PlayerInput.Triggers.Current.MouseLeft;
      Main.mouseRight = PlayerInput.Triggers.Current.MouseRight;
      PlayerInput.CacheZoomableValues();
    }

    public static void UpdateMainMouse()
    {
      Main.lastMouseX = Main.mouseX;
      Main.lastMouseY = Main.mouseY;
      Main.mouseX = PlayerInput.MouseX;
      Main.mouseY = PlayerInput.MouseY;
    }

    public static void CacheZoomableValues()
    {
      PlayerInput.CacheOriginalInput();
      PlayerInput.CacheOriginalScreenDimensions();
    }

    public static void CacheMousePositionForZoom()
    {
      float num = 1f;
      PlayerInput._originalMouseX = (int) ((double) Main.mouseX * (double) num);
      PlayerInput._originalMouseY = (int) ((double) Main.mouseY * (double) num);
    }

    private static void CacheOriginalInput()
    {
      PlayerInput._originalMouseX = Main.mouseX;
      PlayerInput._originalMouseY = Main.mouseY;
      PlayerInput._originalLastMouseX = Main.lastMouseX;
      PlayerInput._originalLastMouseY = Main.lastMouseY;
    }

    public static void CacheOriginalScreenDimensions()
    {
      PlayerInput._originalScreenWidth = Main.screenWidth;
      PlayerInput._originalScreenHeight = Main.screenHeight;
    }

    private static void GamePadInput()
    {
      bool flag1 = false;
      PlayerInput.ScrollWheelValue += PlayerInput.GamepadScrollValue;
      GamePadState gamePadState = new GamePadState();
      bool flag2 = false;
      for (int index = 0; index < 4; ++index)
      {
        GamePadState state = GamePad.GetState((PlayerIndex) index);
        if (state.IsConnected)
        {
          flag2 = true;
          gamePadState = state;
          break;
        }
      }
      if (!flag2 || !Main.instance.IsActive && !Main.AllowUnfocusedInputOnGamepad)
        return;
      Player player = Main.player[Main.myPlayer];
      bool flag3 = UILinkPointNavigator.Available && !PlayerInput.InBuildingMode;
      InputMode key = InputMode.XBoxGamepad;
      if (Main.gameMenu | flag3 || player.talkNPC != -1 || player.sign != -1 || IngameFancyUI.CanCover())
        key = InputMode.XBoxGamepadUI;
      if (!Main.gameMenu && PlayerInput.InBuildingMode)
        key = InputMode.XBoxGamepad;
      if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepad && key == InputMode.XBoxGamepadUI)
        flag1 = true;
      if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepadUI && key == InputMode.XBoxGamepad)
        flag1 = true;
      if (flag1)
        PlayerInput.CurrentInputMode = key;
      KeyConfiguration inputMode = PlayerInput.CurrentProfile.InputModes[key];
      int num1 = 2145386496;
      for (int index = 0; index < PlayerInput.ButtonsGamepad.Length; ++index)
      {
        if (((Buttons) num1 & PlayerInput.ButtonsGamepad[index]) <= (Buttons) 0 && gamePadState.IsButtonDown(PlayerInput.ButtonsGamepad[index]))
        {
          if (PlayerInput.CheckRebindingProcessGamepad(PlayerInput.ButtonsGamepad[index].ToString()))
            return;
          inputMode.Processkey(PlayerInput.Triggers.Current, PlayerInput.ButtonsGamepad[index].ToString());
          flag1 = true;
        }
      }
      PlayerInput.GamepadThumbstickLeft = gamePadState.ThumbSticks.Left * new Vector2(1f, -1f) * new Vector2((float) (PlayerInput.CurrentProfile.LeftThumbstickInvertX.ToDirectionInt() * -1), (float) (PlayerInput.CurrentProfile.LeftThumbstickInvertY.ToDirectionInt() * -1));
      PlayerInput.GamepadThumbstickRight = gamePadState.ThumbSticks.Right * new Vector2(1f, -1f) * new Vector2((float) (PlayerInput.CurrentProfile.RightThumbstickInvertX.ToDirectionInt() * -1), (float) (PlayerInput.CurrentProfile.RightThumbstickInvertY.ToDirectionInt() * -1));
      Vector2 gamepadThumbstickRight = PlayerInput.GamepadThumbstickRight;
      Vector2 gamepadThumbstickLeft = PlayerInput.GamepadThumbstickLeft;
      Vector2 vector2_1 = gamepadThumbstickRight;
      if (vector2_1 != Vector2.Zero)
        vector2_1.Normalize();
      Vector2 vector2_2 = gamepadThumbstickLeft;
      if (vector2_2 != Vector2.Zero)
        vector2_2.Normalize();
      float num2 = 0.6f;
      float triggersDeadzone = PlayerInput.CurrentProfile.TriggersDeadzone;
      if (key == InputMode.XBoxGamepadUI)
      {
        num2 = 0.4f;
        if (PlayerInput.GamepadAllowScrolling)
          PlayerInput.GamepadScrollValue -= (int) ((double) gamepadThumbstickRight.Y * 16.0);
        PlayerInput.GamepadAllowScrolling = false;
      }
      Buttons buttons;
      if ((double) Vector2.Dot(-Vector2.UnitX, vector2_2) >= (double) num2 && (double) gamepadThumbstickLeft.X < -(double) PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX)
      {
        if (PlayerInput.CheckRebindingProcessGamepad(Buttons.LeftThumbstickLeft.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.LeftThumbstickLeft;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(Vector2.UnitX, vector2_2) >= (double) num2 && (double) gamepadThumbstickLeft.X > (double) PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX)
      {
        buttons = Buttons.LeftThumbstickRight;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.LeftThumbstickRight;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(-Vector2.UnitY, vector2_2) >= (double) num2 && (double) gamepadThumbstickLeft.Y < -(double) PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY)
      {
        buttons = Buttons.LeftThumbstickUp;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.LeftThumbstickUp;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(Vector2.UnitY, vector2_2) >= (double) num2 && (double) gamepadThumbstickLeft.Y > (double) PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY)
      {
        buttons = Buttons.LeftThumbstickDown;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.LeftThumbstickDown;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(-Vector2.UnitX, vector2_1) >= (double) num2 && (double) gamepadThumbstickRight.X < -(double) PlayerInput.CurrentProfile.RightThumbstickDeadzoneX)
      {
        buttons = Buttons.RightThumbstickLeft;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.RightThumbstickLeft;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(Vector2.UnitX, vector2_1) >= (double) num2 && (double) gamepadThumbstickRight.X > (double) PlayerInput.CurrentProfile.RightThumbstickDeadzoneX)
      {
        buttons = Buttons.RightThumbstickRight;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.RightThumbstickRight;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(-Vector2.UnitY, vector2_1) >= (double) num2 && (double) gamepadThumbstickRight.Y < -(double) PlayerInput.CurrentProfile.RightThumbstickDeadzoneY)
      {
        buttons = Buttons.RightThumbstickUp;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.RightThumbstickUp;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) Vector2.Dot(Vector2.UnitY, vector2_1) >= (double) num2 && (double) gamepadThumbstickRight.Y > (double) PlayerInput.CurrentProfile.RightThumbstickDeadzoneY)
      {
        buttons = Buttons.RightThumbstickDown;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.RightThumbstickDown;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) gamePadState.Triggers.Left > (double) triggersDeadzone)
      {
        buttons = Buttons.LeftTrigger;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.LeftTrigger;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      if ((double) gamePadState.Triggers.Right > (double) triggersDeadzone)
      {
        buttons = Buttons.RightTrigger;
        if (PlayerInput.CheckRebindingProcessGamepad(buttons.ToString()))
          return;
        KeyConfiguration keyConfiguration = inputMode;
        TriggersSet current = PlayerInput.Triggers.Current;
        buttons = Buttons.RightTrigger;
        string newKey = buttons.ToString();
        keyConfiguration.Processkey(current, newKey);
        flag1 = true;
      }
      bool flag4 = ItemID.Sets.GamepadWholeScreenUseRange[player.inventory[player.selectedItem].type] || player.scope;
      int num3 = player.inventory[player.selectedItem].tileBoost + ItemID.Sets.GamepadExtraRange[player.inventory[player.selectedItem].type];
      if (player.yoyoString && ItemID.Sets.Yoyo[player.inventory[player.selectedItem].type])
        num3 += 5;
      else if (player.inventory[player.selectedItem].createTile < 0 && player.inventory[player.selectedItem].createWall <= 0 && player.inventory[player.selectedItem].shoot > 0)
        num3 += 10;
      else if (player.controlTorch)
        ++num3;
      if (flag4)
        num3 += 30;
      if (player.mount.Active && player.mount.Type == 8)
        num3 = 10;
      bool flag5 = false;
      bool flag6 = !Main.gameMenu && !flag3 && Main.SmartCursorEnabled;
      if (!PlayerInput.CursorIsBusy)
      {
        bool flag7 = Main.mapFullscreen || !Main.gameMenu && !flag3;
        int num4 = Main.screenWidth / 2;
        int num5 = Main.screenHeight / 2;
        if (!Main.mapFullscreen & flag7 && !flag4)
        {
          Point point = Main.ReverseGravitySupport(player.Center - Main.screenPosition).ToPoint();
          num4 = point.X;
          num5 = point.Y;
        }
        if (((!(player.velocity == Vector2.Zero) || !(gamepadThumbstickLeft == Vector2.Zero) ? 0 : (gamepadThumbstickRight == Vector2.Zero ? 1 : 0)) & (flag6 ? 1 : 0)) != 0)
          num4 += player.direction * 10;
        if (gamepadThumbstickRight != Vector2.Zero & flag7)
        {
          Vector2 vector2_3 = new Vector2(8f);
          if (!Main.gameMenu && Main.mapFullscreen)
            vector2_3 = new Vector2(16f);
          if (flag6)
          {
            vector2_3 = new Vector2((float) (Player.tileRangeX * 16), (float) (Player.tileRangeY * 16));
            if (num3 != 0)
              vector2_3 += new Vector2((float) (num3 * 16), (float) (num3 * 16));
            if (flag4)
              vector2_3 = new Vector2((float) (Math.Max(Main.screenWidth, Main.screenHeight) / 2));
          }
          else if (!Main.mapFullscreen)
          {
            if (player.inventory[player.selectedItem].mech)
              vector2_3 += Vector2.Zero;
            else
              vector2_3 += new Vector2((float) num3) / 4f;
          }
          float m11 = Main.GameViewMatrix.ZoomMatrix.M11;
          Vector2 vector2_4 = gamepadThumbstickRight * vector2_3 * m11;
          int num6 = PlayerInput.MouseX - num4;
          int num7 = PlayerInput.MouseY - num5;
          if (flag6)
          {
            num6 = 0;
            num7 = 0;
          }
          int num8 = num6 + (int) vector2_4.X;
          int num9 = num7 + (int) vector2_4.Y;
          PlayerInput.MouseX = num8 + num4;
          PlayerInput.MouseY = num9 + num5;
          flag1 = true;
          flag5 = true;
        }
        if (gamepadThumbstickLeft != Vector2.Zero & flag7)
        {
          float num10 = 8f;
          if (!Main.gameMenu && Main.mapFullscreen)
            num10 = 3f;
          if (Main.mapFullscreen)
          {
            Vector2 vector2_5 = gamepadThumbstickLeft * num10;
            Main.mapFullscreenPos += vector2_5 * num10 * (1f / Main.mapFullscreenScale);
          }
          else if (!flag5 && Main.SmartCursorEnabled)
          {
            float m11 = Main.GameViewMatrix.ZoomMatrix.M11;
            Vector2 vector2_6 = gamepadThumbstickLeft * new Vector2((float) (Player.tileRangeX * 16), (float) (Player.tileRangeY * 16)) * m11;
            if (num3 != 0)
              vector2_6 = gamepadThumbstickLeft * new Vector2((float) ((Player.tileRangeX + num3) * 16), (float) ((Player.tileRangeY + num3) * 16)) * m11;
            if (flag4)
              vector2_6 = new Vector2((float) (Math.Max(Main.screenWidth, Main.screenHeight) / 2)) * gamepadThumbstickLeft;
            int x = (int) vector2_6.X;
            int y = (int) vector2_6.Y;
            int num11 = num4;
            PlayerInput.MouseX = x + num11;
            PlayerInput.MouseY = y + num5;
          }
          flag1 = true;
        }
        if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepad)
        {
          PlayerInput.HandleDpadSnap();
          int num12 = PlayerInput.MouseX - num4;
          int num13 = PlayerInput.MouseY - num5;
          int num14;
          int num15;
          if (!Main.gameMenu && !flag3)
          {
            if (flag4 && !Main.mapFullscreen)
            {
              float num16 = 1f;
              int num17 = Main.screenWidth / 2;
              int num18 = Main.screenHeight / 2;
              num14 = (int) Utils.Clamp<float>((float) num12, (float) -num17 * num16, (float) num17 * num16);
              num15 = (int) Utils.Clamp<float>((float) num13, (float) -num18 * num16, (float) num18 * num16);
            }
            else
            {
              float m11 = Main.GameViewMatrix.ZoomMatrix.M11;
              num14 = (int) Utils.Clamp<float>((float) num12, (float) (-(Player.tileRangeX + num3) * 16) * m11, (float) ((Player.tileRangeX + num3) * 16) * m11);
              num15 = (int) Utils.Clamp<float>((float) num13, (float) (-(Player.tileRangeY + num3) * 16) * m11, (float) ((Player.tileRangeY + num3) * 16) * m11);
            }
            if (flag6 && !flag1 | flag4)
            {
              float num19 = 0.81f;
              if (flag4)
                num19 = 0.95f;
              num14 = (int) ((double) num14 * (double) num19);
              num15 = (int) ((double) num15 * (double) num19);
            }
          }
          else
          {
            num14 = Utils.Clamp<int>(num12, -num4 + 10, num4 - 10);
            num15 = Utils.Clamp<int>(num13, -num5 + 10, num5 - 10);
          }
          PlayerInput.MouseX = num14 + num4;
          PlayerInput.MouseY = num15 + num5;
        }
      }
      if (flag1)
        PlayerInput.CurrentInputMode = key;
      if (PlayerInput.CurrentInputMode != InputMode.XBoxGamepad)
        return;
      Main.SetCameraGamepadLerp(0.1f);
    }

    private static void MouseInput()
    {
      bool flag = false;
      PlayerInput.MouseInfoOld = PlayerInput.MouseInfo;
      PlayerInput.MouseInfo = Mouse.GetState();
      PlayerInput.ScrollWheelValue += PlayerInput.MouseInfo.ScrollWheelValue;
      int num1 = PlayerInput.MouseInfo.X - PlayerInput.MouseInfoOld.X;
      int num2 = PlayerInput.MouseInfo.Y - PlayerInput.MouseInfoOld.Y;
      if (num1 != 0 || num2 != 0 || PlayerInput.MouseInfo.ScrollWheelValue != PlayerInput.MouseInfoOld.ScrollWheelValue)
      {
        PlayerInput.MouseX = PlayerInput.MouseInfo.X;
        PlayerInput.MouseY = PlayerInput.MouseInfo.Y;
        flag = true;
      }
      PlayerInput.MouseKeys.Clear();
      if (Main.instance.IsActive)
      {
        if (PlayerInput.MouseInfo.LeftButton == ButtonState.Pressed)
        {
          PlayerInput.MouseKeys.Add("Mouse1");
          flag = true;
        }
        if (PlayerInput.MouseInfo.RightButton == ButtonState.Pressed)
        {
          PlayerInput.MouseKeys.Add("Mouse2");
          flag = true;
        }
        if (PlayerInput.MouseInfo.MiddleButton == ButtonState.Pressed)
        {
          PlayerInput.MouseKeys.Add("Mouse3");
          flag = true;
        }
        if (PlayerInput.MouseInfo.XButton1 == ButtonState.Pressed)
        {
          PlayerInput.MouseKeys.Add("Mouse4");
          flag = true;
        }
        if (PlayerInput.MouseInfo.XButton2 == ButtonState.Pressed)
        {
          PlayerInput.MouseKeys.Add("Mouse5");
          flag = true;
        }
      }
      if (!flag)
        return;
      PlayerInput.CurrentInputMode = InputMode.Mouse;
      PlayerInput.Triggers.Current.UsedMovementKey = false;
    }

    private static void KeyboardInput()
    {
      bool flag1 = false;
      bool flag2 = false;
      Keys[] pressedKeys = Main.keyState.GetPressedKeys();
      if (PlayerInput.InvalidateKeyboardSwap() && PlayerInput.MouseKeys.Count == 0)
        return;
      for (int index = 0; index < pressedKeys.Length; ++index)
      {
        if (pressedKeys[index] == Keys.LeftShift || pressedKeys[index] == Keys.RightShift)
          flag1 = true;
        else if (pressedKeys[index] == Keys.LeftAlt || pressedKeys[index] == Keys.RightAlt)
          flag2 = true;
      }
      string blockKey = Main.blockKey;
      Keys keys = Keys.None;
      string str1 = keys.ToString();
      if (blockKey != str1)
      {
        bool flag3 = false;
        for (int index = 0; index < pressedKeys.Length; ++index)
        {
          if (pressedKeys[index].ToString() == Main.blockKey)
          {
            pressedKeys[index] = Keys.None;
            flag3 = true;
          }
        }
        if (!flag3)
        {
          keys = Keys.None;
          Main.blockKey = keys.ToString();
        }
      }
      KeyConfiguration inputMode = PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard];
      if (Main.gameMenu && !PlayerInput.WritingText)
        inputMode = PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI];
      List<string> stringList = new List<string>(pressedKeys.Length);
      for (int index = 0; index < pressedKeys.Length; ++index)
        stringList.Add(pressedKeys[index].ToString());
      if (PlayerInput.WritingText)
        stringList.Clear();
      int count = stringList.Count;
      stringList.AddRange((IEnumerable<string>) PlayerInput.MouseKeys);
      bool flag4 = false;
      for (int index = 0; index < stringList.Count; ++index)
      {
        string newKey = stringList[index].ToString();
        string str2 = stringList[index];
        keys = Keys.Tab;
        string str3 = keys.ToString();
        if (!(str2 == str3) || ((!flag1 ? 0 : (SocialAPI.Mode == SocialMode.Steam ? 1 : 0)) | (flag2 ? 1 : 0)) == 0)
        {
          if (PlayerInput.CheckRebindingProcessKeyboard(newKey))
            return;
          KeyboardState oldKeyState = Main.oldKeyState;
          if (index >= count || !Main.oldKeyState.IsKeyDown(pressedKeys[index]))
            inputMode.Processkey(PlayerInput.Triggers.Current, newKey);
          else
            inputMode.CopyKeyState(PlayerInput.Triggers.Old, PlayerInput.Triggers.Current, newKey);
          if (index >= count || pressedKeys[index] != Keys.None)
            flag4 = true;
        }
      }
      if (!flag4)
        return;
      PlayerInput.CurrentInputMode = InputMode.Keyboard;
    }

    private static void FixDerpedRebinds()
    {
      List<string> stringList = new List<string>()
      {
        "MouseLeft",
        "MouseRight",
        "Inventory"
      };
      foreach (InputMode key1 in Enum.GetValues(typeof (InputMode)))
      {
        if (key1 != InputMode.Mouse)
        {
          foreach (string key2 in stringList)
          {
            if (PlayerInput.CurrentProfile.InputModes[key1].KeyStatus[key2].Count < 1)
            {
              string key3 = "Redigit's Pick";
              if (PlayerInput.OriginalProfiles.ContainsKey(PlayerInput._selectedProfile))
                key3 = PlayerInput._selectedProfile;
              PlayerInput.CurrentProfile.InputModes[key1].KeyStatus[key2].AddRange((IEnumerable<string>) PlayerInput.OriginalProfiles[key3].InputModes[key1].KeyStatus[key2]);
            }
          }
        }
      }
    }

    private static bool CheckRebindingProcessGamepad(string newKey)
    {
      PlayerInput._canReleaseRebindingLock = false;
      if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.XBoxGamepad)
      {
        PlayerInput.NavigatorRebindingLock = 3;
        PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
        Main.PlaySound(12);
        if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
          PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
        else
          PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>()
          {
            newKey
          };
        PlayerInput.ListenFor((string) null, InputMode.XBoxGamepad);
      }
      if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.XBoxGamepadUI)
      {
        PlayerInput.NavigatorRebindingLock = 3;
        PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
        Main.PlaySound(12);
        if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
          PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
        else
          PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>()
          {
            newKey
          };
        PlayerInput.ListenFor((string) null, InputMode.XBoxGamepadUI);
      }
      PlayerInput.FixDerpedRebinds();
      return PlayerInput.NavigatorRebindingLock > 0;
    }

    private static bool CheckRebindingProcessKeyboard(string newKey)
    {
      PlayerInput._canReleaseRebindingLock = false;
      if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.Keyboard)
      {
        PlayerInput.NavigatorRebindingLock = 3;
        PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
        Main.PlaySound(12);
        if (PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
          PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
        else
          PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>()
          {
            newKey
          };
        PlayerInput.ListenFor((string) null, InputMode.Keyboard);
        Main.blockKey = newKey;
        Main.blockInput = false;
      }
      if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.KeyboardUI)
      {
        PlayerInput.NavigatorRebindingLock = 3;
        PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
        Main.PlaySound(12);
        if (PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
          PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
        else
          PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>()
          {
            newKey
          };
        PlayerInput.ListenFor((string) null, InputMode.KeyboardUI);
        Main.blockKey = newKey;
        Main.blockInput = false;
      }
      PlayerInput.FixDerpedRebinds();
      return PlayerInput.NavigatorRebindingLock > 0;
    }

    private static void PostInput()
    {
      Main.GamepadCursorAlpha = MathHelper.Clamp(Main.GamepadCursorAlpha + (!Main.SmartCursorEnabled || UILinkPointNavigator.Available || !(PlayerInput.GamepadThumbstickLeft == Vector2.Zero) || !(PlayerInput.GamepadThumbstickRight == Vector2.Zero) ? 0.05f : -0.05f), 0.0f, 1f);
      if (PlayerInput.CurrentProfile.HotbarAllowsRadial)
      {
        int num = PlayerInput.Triggers.Current.HotbarPlus.ToInt() - PlayerInput.Triggers.Current.HotbarMinus.ToInt();
        if (PlayerInput.MiscSettingsTEMP.HotbarRadialShouldBeUsed)
        {
          switch (num)
          {
            case -1:
              PlayerInput.Triggers.Current.RadialQuickbar = true;
              PlayerInput.Triggers.JustReleased.RadialQuickbar = false;
              break;
            case 1:
              PlayerInput.Triggers.Current.RadialHotbar = true;
              PlayerInput.Triggers.JustReleased.RadialHotbar = false;
              break;
          }
        }
      }
      PlayerInput.MiscSettingsTEMP.HotbarRadialShouldBeUsed = false;
    }

    private static void HandleDpadSnap()
    {
      Vector2 zero = Vector2.Zero;
      Player player = Main.player[Main.myPlayer];
      for (int index = 0; index < 4; ++index)
      {
        bool flag = false;
        Vector2 vector2 = Vector2.Zero;
        if (Main.gameMenu || UILinkPointNavigator.Available && !PlayerInput.InBuildingMode)
          return;
        switch (index)
        {
          case 0:
            flag = PlayerInput.Triggers.Current.DpadMouseSnap1;
            vector2 = -Vector2.UnitY;
            break;
          case 1:
            flag = PlayerInput.Triggers.Current.DpadMouseSnap2;
            vector2 = Vector2.UnitX;
            break;
          case 2:
            flag = PlayerInput.Triggers.Current.DpadMouseSnap3;
            vector2 = Vector2.UnitY;
            break;
          case 3:
            flag = PlayerInput.Triggers.Current.DpadMouseSnap4;
            vector2 = -Vector2.UnitX;
            break;
        }
        if (PlayerInput.DpadSnapCooldown[index] > 0)
          --PlayerInput.DpadSnapCooldown[index];
        if (flag)
        {
          if (PlayerInput.DpadSnapCooldown[index] == 0)
          {
            int num = 6;
            if (ItemSlot.IsABuildingItem(player.inventory[player.selectedItem]))
              num = player.inventory[player.selectedItem].useTime;
            PlayerInput.DpadSnapCooldown[index] = num;
            zero += vector2;
          }
        }
        else
          PlayerInput.DpadSnapCooldown[index] = 0;
      }
      if (!(zero != Vector2.Zero))
        return;
      Main.SmartCursorEnabled = false;
      Point tileCoordinates = (Main.MouseScreen + Main.screenPosition + zero * new Vector2(16f)).ToTileCoordinates();
      PlayerInput.MouseX = tileCoordinates.X * 16 + 8 - (int) Main.screenPosition.X;
      PlayerInput.MouseY = tileCoordinates.Y * 16 + 8 - (int) Main.screenPosition.Y;
    }

    public static string ComposeInstructionsForGamepad()
    {
      string str1 = "";
      if (!PlayerInput.UsingGamepad)
        return str1;
      InputMode key = InputMode.XBoxGamepad;
      if (Main.gameMenu || UILinkPointNavigator.Available)
        key = InputMode.XBoxGamepadUI;
      if (PlayerInput.InBuildingMode && !Main.gameMenu)
        key = InputMode.XBoxGamepad;
      KeyConfiguration inputMode = PlayerInput.CurrentProfile.InputModes[key];
      string str2;
      if (Main.mapFullscreen && !Main.gameMenu)
      {
        str2 = str1 + "          " + PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.inter[118].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"]) + PlayerInput.BuildCommand(Lang.inter[119].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
        if (Main.netMode == 1 && Main.player[Main.myPlayer].HasItem(2997))
          str2 += PlayerInput.BuildCommand(Lang.inter[120].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
      }
      else if (key == InputMode.XBoxGamepadUI && !PlayerInput.InBuildingMode)
      {
        str2 = UILinkPointNavigator.GetInstructions();
      }
      else
      {
        if (!PlayerInput.GrappleAndInteractAreShared || !WiresUI.Settings.DrawToolModeUI && (!Main.SmartInteractShowingGenuine || Main.SmartInteractNPC == -1 && (Main.SmartInteractX == -1 || Main.SmartInteractY == -1)))
          str1 += PlayerInput.BuildCommand(Lang.misc[57].Value, false, inputMode.KeyStatus["Grapple"]);
        string str3 = str1 + PlayerInput.BuildCommand(Lang.misc[58].Value, false, inputMode.KeyStatus["Jump"]) + PlayerInput.BuildCommand(Lang.misc[59].Value, false, inputMode.KeyStatus["HotbarMinus"], inputMode.KeyStatus["HotbarPlus"]);
        if (PlayerInput.InBuildingMode)
          str3 += PlayerInput.BuildCommand(Lang.menu[6].Value, false, inputMode.KeyStatus["Inventory"], inputMode.KeyStatus["MouseRight"]);
        if (WiresUI.Open)
        {
          str2 = str3 + PlayerInput.BuildCommand(Lang.misc[53].Value, false, inputMode.KeyStatus["MouseLeft"]) + PlayerInput.BuildCommand(Lang.misc[56].Value, false, inputMode.KeyStatus["MouseRight"]);
        }
        else
        {
          Item obj = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem];
          if (obj.damage > 0 && obj.ammo == 0)
            str2 = str3 + PlayerInput.BuildCommand(Lang.misc[60].Value, false, inputMode.KeyStatus["MouseLeft"]);
          else if (obj.createTile >= 0 || obj.createWall > 0)
            str2 = str3 + PlayerInput.BuildCommand(Lang.misc[61].Value, false, inputMode.KeyStatus["MouseLeft"]);
          else
            str2 = str3 + PlayerInput.BuildCommand(Lang.misc[63].Value, false, inputMode.KeyStatus["MouseLeft"]);
          if (Main.SmartInteractShowingGenuine)
          {
            if (Main.SmartInteractNPC != -1)
              str2 += PlayerInput.BuildCommand(Lang.misc[80].Value, false, inputMode.KeyStatus["MouseRight"]);
            else if (Main.SmartInteractX != -1 && Main.SmartInteractY != -1)
            {
              Tile tile = Main.tile[Main.SmartInteractX, Main.SmartInteractY];
              if (TileID.Sets.TileInteractRead[(int) tile.type])
                str2 += PlayerInput.BuildCommand(Lang.misc[81].Value, false, inputMode.KeyStatus["MouseRight"]);
              else
                str2 += PlayerInput.BuildCommand(Lang.misc[79].Value, false, inputMode.KeyStatus["MouseRight"]);
            }
          }
          else if (WiresUI.Settings.DrawToolModeUI)
            str2 += PlayerInput.BuildCommand(Lang.misc[89].Value, false, inputMode.KeyStatus["MouseRight"]);
        }
      }
      return str2;
    }

    public static string BuildCommand(
      string CommandText,
      bool Last,
      params List<string>[] Bindings)
    {
      string str1 = "";
      if (Bindings.Length == 0)
        return str1;
      string str2 = str1 + PlayerInput.GenInput(Bindings[0]);
      for (int index = 1; index < Bindings.Length; ++index)
      {
        string str3 = PlayerInput.GenInput(Bindings[index]);
        if (str3.Length > 0)
          str2 = str2 + "/" + str3;
      }
      if (str2.Length > 0)
      {
        str2 = str2 + ": " + CommandText;
        if (!Last)
          str2 += "   ";
      }
      return str2;
    }

    private static string GenInput(List<string> list)
    {
      if (list.Count == 0)
        return "";
      string str = GlyphTagHandler.GenerateTag(list[0]);
      for (int index = 1; index < list.Count; ++index)
        str = str + "/" + GlyphTagHandler.GenerateTag(list[index]);
      return str;
    }

    public static void NavigatorCachePosition()
    {
      PlayerInput.PreUIX = PlayerInput.MouseX;
      PlayerInput.PreUIY = PlayerInput.MouseY;
    }

    public static void NavigatorUnCachePosition()
    {
      PlayerInput.MouseX = PlayerInput.PreUIX;
      PlayerInput.MouseY = PlayerInput.PreUIY;
    }

    public static void LockOnCachePosition()
    {
      PlayerInput.PreLockOnX = PlayerInput.MouseX;
      PlayerInput.PreLockOnY = PlayerInput.MouseY;
    }

    public static void LockOnUnCachePosition()
    {
      PlayerInput.MouseX = PlayerInput.PreLockOnX;
      PlayerInput.MouseY = PlayerInput.PreLockOnY;
    }

    public static void PrettyPrintProfiles(ref string text)
    {
      string str1 = text;
      string[] separator = new string[1]{ "\r\n" };
      foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
      {
        if (str2.Contains(": {"))
        {
          string str3 = str2.Substring(0, str2.IndexOf('"'));
          string oldValue = str2 + "\r\n  ";
          string newValue = oldValue.Replace(": {\r\n  ", ": \r\n" + str3 + "{\r\n  ");
          text = text.Replace(oldValue, newValue);
        }
      }
      text = text.Replace("[\r\n        ", "[");
      text = text.Replace("[\r\n      ", "[");
      text = text.Replace("\"\r\n      ", "\"");
      text = text.Replace("\",\r\n        ", "\", ");
      text = text.Replace("\",\r\n      ", "\", ");
      text = text.Replace("\r\n    ]", "]");
    }

    public static void PrettyPrintProfilesOld(ref string text)
    {
      text = text.Replace(": {\r\n  ", ": \r\n  {\r\n  ");
      text = text.Replace("[\r\n      ", "[");
      text = text.Replace("\"\r\n      ", "\"");
      text = text.Replace("\",\r\n      ", "\", ");
      text = text.Replace("\r\n    ]", "]");
    }

    public static void Reset(KeyConfiguration c, PresetProfiles style, InputMode mode)
    {
      switch (style)
      {
        case PresetProfiles.Redigit:
          switch (mode)
          {
            case InputMode.Keyboard:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Jump"].Add("Space");
              c.KeyStatus["Inventory"].Add("Escape");
              c.KeyStatus["Grapple"].Add("E");
              c.KeyStatus["SmartSelect"].Add("LeftShift");
              c.KeyStatus["SmartCursor"].Add("LeftControl");
              c.KeyStatus["QuickMount"].Add("R");
              c.KeyStatus["QuickHeal"].Add("H");
              c.KeyStatus["QuickMana"].Add("J");
              c.KeyStatus["QuickBuff"].Add("B");
              c.KeyStatus["MapStyle"].Add("Tab");
              c.KeyStatus["MapFull"].Add("M");
              c.KeyStatus["MapZoomIn"].Add("Add");
              c.KeyStatus["MapZoomOut"].Add("Subtract");
              c.KeyStatus["MapAlphaUp"].Add("PageUp");
              c.KeyStatus["MapAlphaDown"].Add("PageDown");
              c.KeyStatus["Hotbar1"].Add("D1");
              c.KeyStatus["Hotbar2"].Add("D2");
              c.KeyStatus["Hotbar3"].Add("D3");
              c.KeyStatus["Hotbar4"].Add("D4");
              c.KeyStatus["Hotbar5"].Add("D5");
              c.KeyStatus["Hotbar6"].Add("D6");
              c.KeyStatus["Hotbar7"].Add("D7");
              c.KeyStatus["Hotbar8"].Add("D8");
              c.KeyStatus["Hotbar9"].Add("D9");
              c.KeyStatus["Hotbar10"].Add("D0");
              c.KeyStatus["ViewZoomOut"].Add("OemMinus");
              c.KeyStatus["ViewZoomIn"].Add("OemPlus");
              return;
            case InputMode.KeyboardUI:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseLeft"].Add("Space");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Up"].Add("Up");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Down"].Add("Down");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Left"].Add("Left");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Right"].Add("Right");
              c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              return;
            case InputMode.Mouse:
              return;
            case InputMode.XBoxGamepad:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Jump"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["LockOn"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.LeftStick));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["DpadSnap1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadSnap3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadSnap4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadSnap2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["MapStyle"].Add(string.Concat((object) Buttons.Back));
              return;
            case InputMode.XBoxGamepadUI:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.Back));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["DpadSnap1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadSnap3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadSnap4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadSnap2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              return;
            default:
              return;
          }
        case PresetProfiles.Yoraiz0r:
          switch (mode)
          {
            case InputMode.Keyboard:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Jump"].Add("Space");
              c.KeyStatus["Inventory"].Add("Escape");
              c.KeyStatus["Grapple"].Add("E");
              c.KeyStatus["SmartSelect"].Add("LeftShift");
              c.KeyStatus["SmartCursor"].Add("LeftControl");
              c.KeyStatus["QuickMount"].Add("R");
              c.KeyStatus["QuickHeal"].Add("H");
              c.KeyStatus["QuickMana"].Add("J");
              c.KeyStatus["QuickBuff"].Add("B");
              c.KeyStatus["MapStyle"].Add("Tab");
              c.KeyStatus["MapFull"].Add("M");
              c.KeyStatus["MapZoomIn"].Add("Add");
              c.KeyStatus["MapZoomOut"].Add("Subtract");
              c.KeyStatus["MapAlphaUp"].Add("PageUp");
              c.KeyStatus["MapAlphaDown"].Add("PageDown");
              c.KeyStatus["Hotbar1"].Add("D1");
              c.KeyStatus["Hotbar2"].Add("D2");
              c.KeyStatus["Hotbar3"].Add("D3");
              c.KeyStatus["Hotbar4"].Add("D4");
              c.KeyStatus["Hotbar5"].Add("D5");
              c.KeyStatus["Hotbar6"].Add("D6");
              c.KeyStatus["Hotbar7"].Add("D7");
              c.KeyStatus["Hotbar8"].Add("D8");
              c.KeyStatus["Hotbar9"].Add("D9");
              c.KeyStatus["Hotbar10"].Add("D0");
              c.KeyStatus["ViewZoomOut"].Add("OemMinus");
              c.KeyStatus["ViewZoomIn"].Add("OemPlus");
              return;
            case InputMode.KeyboardUI:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseLeft"].Add("Space");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Up"].Add("Up");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Down"].Add("Down");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Left"].Add("Left");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Right"].Add("Right");
              c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              return;
            case InputMode.Mouse:
              return;
            case InputMode.XBoxGamepad:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Jump"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.LeftStick));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["QuickHeal"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["RadialHotbar"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["DpadSnap1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadSnap3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadSnap4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadSnap2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["MapStyle"].Add(string.Concat((object) Buttons.Back));
              return;
            case InputMode.XBoxGamepadUI:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["LockOn"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.Back));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["DpadSnap1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadSnap3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadSnap4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadSnap2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              return;
            default:
              return;
          }
        case PresetProfiles.ConsolePS:
          switch (mode)
          {
            case InputMode.Keyboard:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Jump"].Add("Space");
              c.KeyStatus["Inventory"].Add("Escape");
              c.KeyStatus["Grapple"].Add("E");
              c.KeyStatus["SmartSelect"].Add("LeftShift");
              c.KeyStatus["SmartCursor"].Add("LeftControl");
              c.KeyStatus["QuickMount"].Add("R");
              c.KeyStatus["QuickHeal"].Add("H");
              c.KeyStatus["QuickMana"].Add("J");
              c.KeyStatus["QuickBuff"].Add("B");
              c.KeyStatus["MapStyle"].Add("Tab");
              c.KeyStatus["MapFull"].Add("M");
              c.KeyStatus["MapZoomIn"].Add("Add");
              c.KeyStatus["MapZoomOut"].Add("Subtract");
              c.KeyStatus["MapAlphaUp"].Add("PageUp");
              c.KeyStatus["MapAlphaDown"].Add("PageDown");
              c.KeyStatus["Hotbar1"].Add("D1");
              c.KeyStatus["Hotbar2"].Add("D2");
              c.KeyStatus["Hotbar3"].Add("D3");
              c.KeyStatus["Hotbar4"].Add("D4");
              c.KeyStatus["Hotbar5"].Add("D5");
              c.KeyStatus["Hotbar6"].Add("D6");
              c.KeyStatus["Hotbar7"].Add("D7");
              c.KeyStatus["Hotbar8"].Add("D8");
              c.KeyStatus["Hotbar9"].Add("D9");
              c.KeyStatus["Hotbar10"].Add("D0");
              c.KeyStatus["ViewZoomOut"].Add("OemMinus");
              c.KeyStatus["ViewZoomIn"].Add("OemPlus");
              return;
            case InputMode.KeyboardUI:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseLeft"].Add("Space");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Up"].Add("Up");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Down"].Add("Down");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Left"].Add("Left");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Right"].Add("Right");
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
              return;
            case InputMode.Mouse:
              return;
            case InputMode.XBoxGamepad:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Jump"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["LockOn"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.LeftStick));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["DpadRadial1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadRadial3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadRadial4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadRadial2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.Back));
              return;
            case InputMode.XBoxGamepadUI:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.Back));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["DpadRadial1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadRadial3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadRadial4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadRadial2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              return;
            default:
              return;
          }
        case PresetProfiles.ConsoleXBox:
          switch (mode)
          {
            case InputMode.Keyboard:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Jump"].Add("Space");
              c.KeyStatus["Inventory"].Add("Escape");
              c.KeyStatus["Grapple"].Add("E");
              c.KeyStatus["SmartSelect"].Add("LeftShift");
              c.KeyStatus["SmartCursor"].Add("LeftControl");
              c.KeyStatus["QuickMount"].Add("R");
              c.KeyStatus["QuickHeal"].Add("H");
              c.KeyStatus["QuickMana"].Add("J");
              c.KeyStatus["QuickBuff"].Add("B");
              c.KeyStatus["MapStyle"].Add("Tab");
              c.KeyStatus["MapFull"].Add("M");
              c.KeyStatus["MapZoomIn"].Add("Add");
              c.KeyStatus["MapZoomOut"].Add("Subtract");
              c.KeyStatus["MapAlphaUp"].Add("PageUp");
              c.KeyStatus["MapAlphaDown"].Add("PageDown");
              c.KeyStatus["Hotbar1"].Add("D1");
              c.KeyStatus["Hotbar2"].Add("D2");
              c.KeyStatus["Hotbar3"].Add("D3");
              c.KeyStatus["Hotbar4"].Add("D4");
              c.KeyStatus["Hotbar5"].Add("D5");
              c.KeyStatus["Hotbar6"].Add("D6");
              c.KeyStatus["Hotbar7"].Add("D7");
              c.KeyStatus["Hotbar8"].Add("D8");
              c.KeyStatus["Hotbar9"].Add("D9");
              c.KeyStatus["Hotbar10"].Add("D0");
              c.KeyStatus["ViewZoomOut"].Add("OemMinus");
              c.KeyStatus["ViewZoomIn"].Add("OemPlus");
              return;
            case InputMode.KeyboardUI:
              c.KeyStatus["MouseLeft"].Add("Mouse1");
              c.KeyStatus["MouseLeft"].Add("Space");
              c.KeyStatus["MouseRight"].Add("Mouse2");
              c.KeyStatus["Up"].Add("W");
              c.KeyStatus["Up"].Add("Up");
              c.KeyStatus["Down"].Add("S");
              c.KeyStatus["Down"].Add("Down");
              c.KeyStatus["Left"].Add("A");
              c.KeyStatus["Left"].Add("Left");
              c.KeyStatus["Right"].Add("D");
              c.KeyStatus["Right"].Add("Right");
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
              return;
            case InputMode.Mouse:
              return;
            case InputMode.XBoxGamepad:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Jump"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["LockOn"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.LeftStick));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["DpadRadial1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadRadial3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadRadial4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadRadial2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.Back));
              return;
            case InputMode.XBoxGamepadUI:
              c.KeyStatus["MouseLeft"].Add(string.Concat((object) Buttons.A));
              c.KeyStatus["MouseRight"].Add(string.Concat((object) Buttons.LeftShoulder));
              c.KeyStatus["SmartCursor"].Add(string.Concat((object) Buttons.RightShoulder));
              c.KeyStatus["Up"].Add(string.Concat((object) Buttons.LeftThumbstickUp));
              c.KeyStatus["Down"].Add(string.Concat((object) Buttons.LeftThumbstickDown));
              c.KeyStatus["Left"].Add(string.Concat((object) Buttons.LeftThumbstickLeft));
              c.KeyStatus["Right"].Add(string.Concat((object) Buttons.LeftThumbstickRight));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.B));
              c.KeyStatus["Inventory"].Add(string.Concat((object) Buttons.Y));
              c.KeyStatus["HotbarMinus"].Add(string.Concat((object) Buttons.LeftTrigger));
              c.KeyStatus["HotbarPlus"].Add(string.Concat((object) Buttons.RightTrigger));
              c.KeyStatus["Grapple"].Add(string.Concat((object) Buttons.X));
              c.KeyStatus["MapFull"].Add(string.Concat((object) Buttons.Start));
              c.KeyStatus["SmartSelect"].Add(string.Concat((object) Buttons.Back));
              c.KeyStatus["QuickMount"].Add(string.Concat((object) Buttons.RightStick));
              c.KeyStatus["DpadRadial1"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["DpadRadial3"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["DpadRadial4"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["DpadRadial2"].Add(string.Concat((object) Buttons.DPadRight));
              c.KeyStatus["MenuUp"].Add(string.Concat((object) Buttons.DPadUp));
              c.KeyStatus["MenuDown"].Add(string.Concat((object) Buttons.DPadDown));
              c.KeyStatus["MenuLeft"].Add(string.Concat((object) Buttons.DPadLeft));
              c.KeyStatus["MenuRight"].Add(string.Concat((object) Buttons.DPadRight));
              return;
            default:
              return;
          }
      }
    }

    public static void SetZoom_UI() => PlayerInput.SetZoom_Scaled(1f / Main.UIScale);

    public static void SetZoom_World()
    {
      PlayerInput.SetZoom_Scaled(1f);
      PlayerInput.SetZoom_MouseInWorld();
    }

    public static void SetZoom_Unscaled()
    {
      Main.lastMouseX = PlayerInput._originalLastMouseX;
      Main.lastMouseY = PlayerInput._originalLastMouseY;
      Main.mouseX = PlayerInput._originalMouseX;
      Main.mouseY = PlayerInput._originalMouseY;
      Main.screenWidth = PlayerInput._originalScreenWidth;
      Main.screenHeight = PlayerInput._originalScreenHeight;
    }

    public static void SetZoom_Test()
    {
      Vector2 vector2_1 = Main.screenPosition + new Vector2((float) Main.screenWidth, (float) Main.screenHeight) / 2f;
      Vector2 vector2_2 = Main.screenPosition + new Vector2((float) PlayerInput._originalMouseX, (float) PlayerInput._originalMouseY);
      Vector2 vector2_3 = Main.screenPosition + new Vector2((float) PlayerInput._originalLastMouseX, (float) PlayerInput._originalLastMouseY);
      Vector2 vector2_4 = Main.screenPosition + new Vector2(0.0f, 0.0f);
      Vector2 vector2_5 = Main.screenPosition + new Vector2((float) Main.screenWidth, (float) Main.screenHeight);
      Vector2 vector2_6 = vector2_2 - vector2_1;
      Vector2 vector2_7 = vector2_3 - vector2_1;
      Vector2 vector2_8 = vector2_4 - vector2_1;
      Vector2 vector2_9 = vector2_1;
      Vector2 vector2_10 = vector2_5 - vector2_9;
      float num1 = 1f / Main.GameViewMatrix.Zoom.X;
      float num2 = 1f;
      Vector2 vector2_11 = vector2_1 - Main.screenPosition + vector2_6 * num1;
      Vector2 vector2_12 = vector2_1 - Main.screenPosition + vector2_7 * num1;
      Vector2 vector2_13 = vector2_1 + vector2_8 * num2;
      Main.mouseX = (int) vector2_11.X;
      Main.mouseY = (int) vector2_11.Y;
      Main.lastMouseX = (int) vector2_12.X;
      Main.lastMouseY = (int) vector2_12.Y;
      Main.screenPosition = vector2_13;
      Main.screenWidth = (int) ((double) PlayerInput._originalScreenWidth * (double) num2);
      Main.screenHeight = (int) ((double) PlayerInput._originalScreenHeight * (double) num2);
    }

    public static void SetZoom_MouseInWorld()
    {
      Vector2 vector2_1 = Main.screenPosition + new Vector2((float) Main.screenWidth, (float) Main.screenHeight) / 2f;
      Vector2 vector2_2 = Main.screenPosition + new Vector2((float) PlayerInput._originalMouseX, (float) PlayerInput._originalMouseY);
      Vector2 vector2_3 = Main.screenPosition + new Vector2((float) PlayerInput._originalLastMouseX, (float) PlayerInput._originalLastMouseY);
      Vector2 vector2_4 = vector2_2 - vector2_1;
      Vector2 vector2_5 = vector2_1;
      Vector2 vector2_6 = vector2_3 - vector2_5;
      float num = 1f / Main.GameViewMatrix.Zoom.X;
      Vector2 vector2_7 = vector2_1 - Main.screenPosition + vector2_4 * num;
      Main.mouseX = (int) vector2_7.X;
      Main.mouseY = (int) vector2_7.Y;
      Vector2 vector2_8 = vector2_1 - Main.screenPosition + vector2_6 * num;
      Main.lastMouseX = (int) vector2_8.X;
      Main.lastMouseY = (int) vector2_8.Y;
    }

    public static void SetDesiredZoomContext(ZoomContext context) => PlayerInput._currentWantedZoom = context;

    public static void SetZoom_Context()
    {
      switch (PlayerInput._currentWantedZoom)
      {
        case ZoomContext.Unscaled:
          PlayerInput.SetZoom_Unscaled();
          Main.SetRecommendedZoomContext(Matrix.Identity);
          break;
        case ZoomContext.World:
          PlayerInput.SetZoom_World();
          Main.SetRecommendedZoomContext(Main.GameViewMatrix.ZoomMatrix);
          break;
        case ZoomContext.Unscaled_MouseInWorld:
          PlayerInput.SetZoom_Unscaled();
          PlayerInput.SetZoom_MouseInWorld();
          Main.SetRecommendedZoomContext(Main.GameViewMatrix.ZoomMatrix);
          break;
        case ZoomContext.UI:
          PlayerInput.SetZoom_UI();
          Main.SetRecommendedZoomContext(Main.UIScaleMatrix);
          break;
      }
    }

    private static void SetZoom_Scaled(float scale)
    {
      Main.lastMouseX = (int) ((double) PlayerInput._originalLastMouseX * (double) scale);
      Main.lastMouseY = (int) ((double) PlayerInput._originalLastMouseY * (double) scale);
      Main.mouseX = (int) ((double) PlayerInput._originalMouseX * (double) scale);
      Main.mouseY = (int) ((double) PlayerInput._originalMouseY * (double) scale);
      Main.screenWidth = (int) ((double) PlayerInput._originalScreenWidth * (double) scale);
      Main.screenHeight = (int) ((double) PlayerInput._originalScreenHeight * (double) scale);
    }

    public class MiscSettingsTEMP
    {
      public static bool HotbarRadialShouldBeUsed = true;
    }
  }
}
