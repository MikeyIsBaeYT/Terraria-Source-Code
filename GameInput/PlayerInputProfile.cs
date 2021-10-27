// Decompiled with JetBrains decompiler
// Type: Terraria.GameInput.PlayerInputProfile
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Terraria.GameInput
{
  public class PlayerInputProfile
  {
    public Dictionary<InputMode, KeyConfiguration> InputModes = new Dictionary<InputMode, KeyConfiguration>()
    {
      {
        InputMode.Keyboard,
        new KeyConfiguration()
      },
      {
        InputMode.KeyboardUI,
        new KeyConfiguration()
      },
      {
        InputMode.XBoxGamepad,
        new KeyConfiguration()
      },
      {
        InputMode.XBoxGamepadUI,
        new KeyConfiguration()
      }
    };
    public string Name = "";
    public bool AllowEditting = true;
    public int HotbarRadialHoldTimeRequired = 16;
    public float TriggersDeadzone = 0.3f;
    public float InterfaceDeadzoneX = 0.2f;
    public float LeftThumbstickDeadzoneX = 0.25f;
    public float LeftThumbstickDeadzoneY = 0.4f;
    public float RightThumbstickDeadzoneX;
    public float RightThumbstickDeadzoneY;
    public bool LeftThumbstickInvertX;
    public bool LeftThumbstickInvertY;
    public bool RightThumbstickInvertX;
    public bool RightThumbstickInvertY;
    public int InventoryMoveCD = 6;

    public bool HotbarAllowsRadial => this.HotbarRadialHoldTimeRequired != -1;

    public PlayerInputProfile(string name) => this.Name = name;

    public void Initialize(PresetProfiles style)
    {
      foreach (KeyValuePair<InputMode, KeyConfiguration> inputMode in this.InputModes)
      {
        inputMode.Value.SetupKeys();
        PlayerInput.Reset(inputMode.Value, style, inputMode.Key);
      }
    }

    public bool Load(Dictionary<string, object> dict)
    {
      int num = 0;
      object obj;
      if (dict.TryGetValue("Last Launched Version", out obj))
        num = (int) (long) obj;
      if (dict.TryGetValue("Mouse And Keyboard", out obj))
        this.InputModes[InputMode.Keyboard].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((object) (JObject) obj).ToString()));
      if (dict.TryGetValue("Gamepad", out obj))
        this.InputModes[InputMode.XBoxGamepad].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((object) (JObject) obj).ToString()));
      if (dict.TryGetValue("Mouse And Keyboard UI", out obj))
        this.InputModes[InputMode.KeyboardUI].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((object) (JObject) obj).ToString()));
      if (dict.TryGetValue("Gamepad UI", out obj))
        this.InputModes[InputMode.XBoxGamepadUI].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((object) (JObject) obj).ToString()));
      if (num < 190)
      {
        this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomIn"] = new List<string>();
        this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomIn"].AddRange((IEnumerable<string>) PlayerInput.OriginalProfiles["Redigit's Pick"].InputModes[InputMode.Keyboard].KeyStatus["ViewZoomIn"]);
        this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomOut"] = new List<string>();
        this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomOut"].AddRange((IEnumerable<string>) PlayerInput.OriginalProfiles["Redigit's Pick"].InputModes[InputMode.Keyboard].KeyStatus["ViewZoomOut"]);
      }
      if (dict.TryGetValue("Settings", out obj))
      {
        Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(((object) (JObject) obj).ToString());
        if (dictionary.TryGetValue("Edittable", out obj))
          this.AllowEditting = (bool) obj;
        if (dictionary.TryGetValue("Gamepad - HotbarRadialHoldTime", out obj))
          this.HotbarRadialHoldTimeRequired = (int) (long) obj;
        if (dictionary.TryGetValue("Gamepad - LeftThumbstickDeadzoneX", out obj))
          this.LeftThumbstickDeadzoneX = (float) (double) obj;
        if (dictionary.TryGetValue("Gamepad - LeftThumbstickDeadzoneY", out obj))
          this.LeftThumbstickDeadzoneY = (float) (double) obj;
        if (dictionary.TryGetValue("Gamepad - RightThumbstickDeadzoneX", out obj))
          this.RightThumbstickDeadzoneX = (float) (double) obj;
        if (dictionary.TryGetValue("Gamepad - RightThumbstickDeadzoneY", out obj))
          this.RightThumbstickDeadzoneY = (float) (double) obj;
        if (dictionary.TryGetValue("Gamepad - LeftThumbstickInvertX", out obj))
          this.LeftThumbstickInvertX = (bool) obj;
        if (dictionary.TryGetValue("Gamepad - LeftThumbstickInvertY", out obj))
          this.LeftThumbstickInvertY = (bool) obj;
        if (dictionary.TryGetValue("Gamepad - RightThumbstickInvertX", out obj))
          this.RightThumbstickInvertX = (bool) obj;
        if (dictionary.TryGetValue("Gamepad - RightThumbstickInvertY", out obj))
          this.RightThumbstickInvertY = (bool) obj;
        if (dictionary.TryGetValue("Gamepad - TriggersDeadzone", out obj))
          this.TriggersDeadzone = (float) (double) obj;
        if (dictionary.TryGetValue("Gamepad - InterfaceDeadzoneX", out obj))
          this.InterfaceDeadzoneX = (float) (double) obj;
        if (dictionary.TryGetValue("Gamepad - InventoryMoveCD", out obj))
          this.InventoryMoveCD = (int) (long) obj;
      }
      return true;
    }

    public Dictionary<string, object> Save()
    {
      Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
      Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
      dictionary1.Add("Last Launched Version", (object) 194);
      dictionary2.Add("Edittable", (object) this.AllowEditting);
      dictionary2.Add("Gamepad - HotbarRadialHoldTime", (object) this.HotbarRadialHoldTimeRequired);
      dictionary2.Add("Gamepad - LeftThumbstickDeadzoneX", (object) this.LeftThumbstickDeadzoneX);
      dictionary2.Add("Gamepad - LeftThumbstickDeadzoneY", (object) this.LeftThumbstickDeadzoneY);
      dictionary2.Add("Gamepad - RightThumbstickDeadzoneX", (object) this.RightThumbstickDeadzoneX);
      dictionary2.Add("Gamepad - RightThumbstickDeadzoneY", (object) this.RightThumbstickDeadzoneY);
      dictionary2.Add("Gamepad - LeftThumbstickInvertX", (object) this.LeftThumbstickInvertX);
      dictionary2.Add("Gamepad - LeftThumbstickInvertY", (object) this.LeftThumbstickInvertY);
      dictionary2.Add("Gamepad - RightThumbstickInvertX", (object) this.RightThumbstickInvertX);
      dictionary2.Add("Gamepad - RightThumbstickInvertY", (object) this.RightThumbstickInvertY);
      dictionary2.Add("Gamepad - TriggersDeadzone", (object) this.TriggersDeadzone);
      dictionary2.Add("Gamepad - InterfaceDeadzoneX", (object) this.InterfaceDeadzoneX);
      dictionary2.Add("Gamepad - InventoryMoveCD", (object) this.InventoryMoveCD);
      dictionary1.Add("Settings", (object) dictionary2);
      dictionary1.Add("Mouse And Keyboard", (object) this.InputModes[InputMode.Keyboard].WritePreferences());
      dictionary1.Add("Gamepad", (object) this.InputModes[InputMode.XBoxGamepad].WritePreferences());
      dictionary1.Add("Mouse And Keyboard UI", (object) this.InputModes[InputMode.KeyboardUI].WritePreferences());
      dictionary1.Add("Gamepad UI", (object) this.InputModes[InputMode.XBoxGamepadUI].WritePreferences());
      return dictionary1;
    }

    public void ConditionalAddProfile(
      Dictionary<string, object> dicttouse,
      string k,
      InputMode nm,
      Dictionary<string, List<string>> dict)
    {
      if (PlayerInput.OriginalProfiles.ContainsKey(this.Name))
      {
        foreach (KeyValuePair<string, List<string>> writePreference in PlayerInput.OriginalProfiles[this.Name].InputModes[nm].WritePreferences())
        {
          bool flag = true;
          List<string> stringList;
          if (dict.TryGetValue(writePreference.Key, out stringList))
          {
            if (stringList.Count != writePreference.Value.Count)
              flag = false;
            if (!flag)
            {
              for (int index = 0; index < stringList.Count; ++index)
              {
                if (stringList[index] != writePreference.Value[index])
                {
                  flag = false;
                  break;
                }
              }
            }
          }
          else
            flag = false;
          if (flag)
            dict.Remove(writePreference.Key);
        }
      }
      if (dict.Count <= 0)
        return;
      dicttouse.Add(k, (object) dict);
    }

    public void ConditionalAdd(
      Dictionary<string, object> dicttouse,
      string a,
      object b,
      Func<PlayerInputProfile, bool> check)
    {
      if (PlayerInput.OriginalProfiles.ContainsKey(this.Name) && check(PlayerInput.OriginalProfiles[this.Name]))
        return;
      dicttouse.Add(a, b);
    }

    public void CopyGameplaySettingsFrom(PlayerInputProfile profile, InputMode mode)
    {
      string[] keysToCopy = new string[18]
      {
        "MouseLeft",
        "MouseRight",
        "Up",
        "Down",
        "Left",
        "Right",
        "Jump",
        "Grapple",
        "SmartSelect",
        "SmartCursor",
        "QuickMount",
        "QuickHeal",
        "QuickMana",
        "QuickBuff",
        "Throw",
        "Inventory",
        "ViewZoomIn",
        "ViewZoomOut"
      };
      this.CopyKeysFrom(profile, mode, keysToCopy);
    }

    public void CopyHotbarSettingsFrom(PlayerInputProfile profile, InputMode mode)
    {
      string[] keysToCopy = new string[12]
      {
        "HotbarMinus",
        "HotbarPlus",
        "Hotbar1",
        "Hotbar2",
        "Hotbar3",
        "Hotbar4",
        "Hotbar5",
        "Hotbar6",
        "Hotbar7",
        "Hotbar8",
        "Hotbar9",
        "Hotbar10"
      };
      this.CopyKeysFrom(profile, mode, keysToCopy);
    }

    public void CopyMapSettingsFrom(PlayerInputProfile profile, InputMode mode)
    {
      string[] keysToCopy = new string[6]
      {
        "MapZoomIn",
        "MapZoomOut",
        "MapAlphaUp",
        "MapAlphaDown",
        "MapFull",
        "MapStyle"
      };
      this.CopyKeysFrom(profile, mode, keysToCopy);
    }

    public void CopyGamepadSettingsFrom(PlayerInputProfile profile, InputMode mode)
    {
      string[] keysToCopy = new string[10]
      {
        "RadialHotbar",
        "RadialQuickbar",
        "DpadSnap1",
        "DpadSnap2",
        "DpadSnap3",
        "DpadSnap4",
        "DpadRadial1",
        "DpadRadial2",
        "DpadRadial3",
        "DpadRadial4"
      };
      this.CopyKeysFrom(profile, InputMode.XBoxGamepad, keysToCopy);
      this.CopyKeysFrom(profile, InputMode.XBoxGamepadUI, keysToCopy);
    }

    public void CopyGamepadAdvancedSettingsFrom(PlayerInputProfile profile, InputMode mode)
    {
      this.TriggersDeadzone = profile.TriggersDeadzone;
      this.InterfaceDeadzoneX = profile.InterfaceDeadzoneX;
      this.LeftThumbstickDeadzoneX = profile.LeftThumbstickDeadzoneX;
      this.LeftThumbstickDeadzoneY = profile.LeftThumbstickDeadzoneY;
      this.RightThumbstickDeadzoneX = profile.RightThumbstickDeadzoneX;
      this.RightThumbstickDeadzoneY = profile.RightThumbstickDeadzoneY;
      this.LeftThumbstickInvertX = profile.LeftThumbstickInvertX;
      this.LeftThumbstickInvertY = profile.LeftThumbstickInvertY;
      this.RightThumbstickInvertX = profile.RightThumbstickInvertX;
      this.RightThumbstickInvertY = profile.RightThumbstickInvertY;
      this.InventoryMoveCD = profile.InventoryMoveCD;
    }

    private void CopyKeysFrom(PlayerInputProfile profile, InputMode mode, string[] keysToCopy)
    {
      for (int index = 0; index < keysToCopy.Length; ++index)
      {
        List<string> stringList;
        if (profile.InputModes[mode].KeyStatus.TryGetValue(keysToCopy[index], out stringList))
        {
          this.InputModes[mode].KeyStatus[keysToCopy[index]].Clear();
          this.InputModes[mode].KeyStatus[keysToCopy[index]].AddRange((IEnumerable<string>) stringList);
        }
      }
    }

    public bool UsingDpadHotbar() => this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString());

    public bool UsingDpadMovekeys() => this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString());
  }
}
