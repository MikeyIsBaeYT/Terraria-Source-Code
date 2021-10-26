// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ChromaHotkeyPainter
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Peripherals.RGB;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameInput;

namespace Terraria.GameContent
{
  public class ChromaHotkeyPainter
  {
    private readonly Dictionary<string, ChromaHotkeyPainter.PaintKey> _keys = new Dictionary<string, ChromaHotkeyPainter.PaintKey>();
    private readonly List<ChromaHotkeyPainter.ReactiveRGBKey> _reactiveKeys = new List<ChromaHotkeyPainter.ReactiveRGBKey>();
    private List<Keys> _xnaKeysInUse = new List<Keys>();
    private Player _player;
    private int _quickHealAlert;
    private List<ChromaHotkeyPainter.PaintKey> _wasdKeys = new List<ChromaHotkeyPainter.PaintKey>();
    private ChromaHotkeyPainter.PaintKey _healKey;
    private ChromaHotkeyPainter.PaintKey _mountKey;
    private ChromaHotkeyPainter.PaintKey _jumpKey;
    private ChromaHotkeyPainter.PaintKey _grappleKey;
    private ChromaHotkeyPainter.PaintKey _throwKey;
    private ChromaHotkeyPainter.PaintKey _manaKey;
    private ChromaHotkeyPainter.PaintKey _buffKey;
    private ChromaHotkeyPainter.PaintKey _smartCursorKey;
    private ChromaHotkeyPainter.PaintKey _smartSelectKey;

    public bool PotionAlert => (uint) this._quickHealAlert > 0U;

    public void CollectBoundKeys()
    {
      foreach (KeyValuePair<string, ChromaHotkeyPainter.PaintKey> key in this._keys)
        key.Value.Unbind();
      this._keys.Clear();
      foreach (KeyValuePair<string, List<string>> keyStatu in PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus)
        this._keys.Add(keyStatu.Key, new ChromaHotkeyPainter.PaintKey(keyStatu.Key, keyStatu.Value));
      foreach (KeyValuePair<string, ChromaHotkeyPainter.PaintKey> key in this._keys)
        key.Value.Bind();
      this._wasdKeys = new List<ChromaHotkeyPainter.PaintKey>()
      {
        this._keys["Up"],
        this._keys["Down"],
        this._keys["Left"],
        this._keys["Right"]
      };
      this._healKey = this._keys["QuickHeal"];
      this._mountKey = this._keys["QuickMount"];
      this._jumpKey = this._keys["Jump"];
      this._grappleKey = this._keys["Grapple"];
      this._throwKey = this._keys["Throw"];
      this._manaKey = this._keys["QuickMana"];
      this._buffKey = this._keys["QuickBuff"];
      this._smartCursorKey = this._keys["SmartCursor"];
      this._smartSelectKey = this._keys["SmartSelect"];
      this._reactiveKeys.Clear();
      this._xnaKeysInUse.Clear();
      foreach (KeyValuePair<string, ChromaHotkeyPainter.PaintKey> key in this._keys)
        this._xnaKeysInUse.AddRange((IEnumerable<Keys>) key.Value.GetXNAKeysInUse());
      this._xnaKeysInUse = this._xnaKeysInUse.Distinct<Keys>().ToList<Keys>();
    }

    public void PressKey(Keys key)
    {
    }

    private ChromaHotkeyPainter.ReactiveRGBKey FindReactiveKey(Keys keyTarget) => this._reactiveKeys.FirstOrDefault<ChromaHotkeyPainter.ReactiveRGBKey>((Func<ChromaHotkeyPainter.ReactiveRGBKey, bool>) (x => x.XNAKey == keyTarget));

    public void Update()
    {
      this._player = Main.LocalPlayer;
      if (!Main.hasFocus)
      {
        this.Step_ClearAll();
      }
      else
      {
        if (this.PotionAlert)
        {
          foreach (KeyValuePair<string, ChromaHotkeyPainter.PaintKey> key in this._keys)
          {
            if (key.Key != "QuickHeal")
              key.Value.SetClear();
          }
          this.Step_QuickHeal();
        }
        else
        {
          this.Step_Movement();
          this.Step_QuickHeal();
        }
        if (Main.InGameUI.CurrentState == Main.ManageControlsMenu)
        {
          this.Step_ClearAll();
          this.Step_KeybindsMenu();
        }
        this.Step_UpdateReactiveKeys();
      }
    }

    private void SetGroupColorBase(List<ChromaHotkeyPainter.PaintKey> keys, Color color)
    {
      foreach (ChromaHotkeyPainter.PaintKey key in keys)
        key.SetSolid(color);
    }

    private void SetGroupClear(List<ChromaHotkeyPainter.PaintKey> keys)
    {
      foreach (ChromaHotkeyPainter.PaintKey key in keys)
        key.SetClear();
    }

    private void Step_KeybindsMenu()
    {
      this.SetGroupColorBase(this._wasdKeys, ChromaHotkeyPainter.PainterColors.MovementKeys);
      this._jumpKey.SetSolid(ChromaHotkeyPainter.PainterColors.MovementKeys);
      this._grappleKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickGrapple);
      this._mountKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickMount);
      this._quickHealAlert = 0;
      this._healKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickHealReady);
      this._manaKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickMana);
      this._throwKey.SetSolid(ChromaHotkeyPainter.PainterColors.Throw);
      this._smartCursorKey.SetSolid(ChromaHotkeyPainter.PainterColors.SmartCursor);
      this._smartSelectKey.SetSolid(ChromaHotkeyPainter.PainterColors.SmartSelect);
    }

    private void Step_UpdateReactiveKeys()
    {
      foreach (ChromaHotkeyPainter.ReactiveRGBKey reactiveRgbKey in this._reactiveKeys.FindAll((Predicate<ChromaHotkeyPainter.ReactiveRGBKey>) (x => x.Expired)))
      {
        ChromaHotkeyPainter.ReactiveRGBKey key = reactiveRgbKey;
        key.Clear();
        if (!this._keys.Any<KeyValuePair<string, ChromaHotkeyPainter.PaintKey>>((Func<KeyValuePair<string, ChromaHotkeyPainter.PaintKey>, bool>) (x => x.Value.UsesKey(key.XNAKey))))
          key.Unbind();
      }
      this._reactiveKeys.RemoveAll((Predicate<ChromaHotkeyPainter.ReactiveRGBKey>) (x => x.Expired));
      foreach (ChromaHotkeyPainter.ReactiveRGBKey reactiveKey in this._reactiveKeys)
        reactiveKey.Update();
    }

    private void Step_ClearAll()
    {
      foreach (KeyValuePair<string, ChromaHotkeyPainter.PaintKey> key in this._keys)
        key.Value.SetClear();
    }

    private void Step_SmartKeys()
    {
      ChromaHotkeyPainter.PaintKey smartCursorKey = this._smartCursorKey;
      ChromaHotkeyPainter.PaintKey smartSelectKey = this._smartSelectKey;
      if (this._player.DeadOrGhost || this._player.frozen || this._player.tongued || this._player.webbed || this._player.stoned || this._player.noItems)
      {
        smartCursorKey.SetClear();
        smartSelectKey.SetClear();
      }
      else
      {
        if (Main.SmartCursorEnabled)
          smartCursorKey.SetSolid(ChromaHotkeyPainter.PainterColors.SmartCursor);
        else
          smartCursorKey.SetClear();
        if (this._player.nonTorch >= 0)
          smartSelectKey.SetSolid(ChromaHotkeyPainter.PainterColors.SmartSelect);
        else
          smartSelectKey.SetClear();
      }
    }

    private void Step_Movement()
    {
      List<ChromaHotkeyPainter.PaintKey> wasdKeys = this._wasdKeys;
      bool flag = this._player.frozen || this._player.tongued || this._player.webbed || this._player.stoned;
      if (this._player.DeadOrGhost)
        this.SetGroupClear(wasdKeys);
      else if (flag)
        this.SetGroupColorBase(wasdKeys, ChromaHotkeyPainter.PainterColors.DangerKeyBlocked);
      else
        this.SetGroupColorBase(wasdKeys, ChromaHotkeyPainter.PainterColors.MovementKeys);
    }

    private void Step_Mount()
    {
      ChromaHotkeyPainter.PaintKey mountKey = this._mountKey;
      if (this._player.QuickMount_GetItemToUse() == null || this._player.DeadOrGhost)
        mountKey.SetClear();
      else if (this._player.frozen || this._player.tongued || this._player.webbed || this._player.stoned || (double) this._player.gravDir == -1.0 || this._player.noItems)
      {
        mountKey.SetSolid(ChromaHotkeyPainter.PainterColors.DangerKeyBlocked);
        if ((double) this._player.gravDir != -1.0)
          return;
        mountKey.SetSolid(ChromaHotkeyPainter.PainterColors.DangerKeyBlocked * 0.6f);
      }
      else
        mountKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickMount);
    }

    private void Step_Grapple()
    {
      ChromaHotkeyPainter.PaintKey grappleKey = this._grappleKey;
      if (this._player.QuickGrapple_GetItemToUse() == null || this._player.DeadOrGhost)
        grappleKey.SetClear();
      else if (this._player.frozen || this._player.tongued || this._player.webbed || this._player.stoned || this._player.noItems)
        grappleKey.SetSolid(ChromaHotkeyPainter.PainterColors.DangerKeyBlocked);
      else
        grappleKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickGrapple);
    }

    private void Step_Jump()
    {
      ChromaHotkeyPainter.PaintKey jumpKey = this._jumpKey;
      if (this._player.DeadOrGhost)
        jumpKey.SetClear();
      else if (this._player.frozen || this._player.tongued || this._player.webbed || this._player.stoned)
        jumpKey.SetSolid(ChromaHotkeyPainter.PainterColors.DangerKeyBlocked);
      else
        jumpKey.SetSolid(ChromaHotkeyPainter.PainterColors.MovementKeys);
    }

    private void Step_QuickHeal()
    {
      ChromaHotkeyPainter.PaintKey healKey = this._healKey;
      if (this._player.QuickHeal_GetItemToUse() == null || this._player.DeadOrGhost)
      {
        healKey.SetClear();
        this._quickHealAlert = 0;
      }
      else if (this._player.potionDelay > 0)
      {
        float lerpValue = Utils.GetLerpValue((float) this._player.potionDelayTime, 0.0f, (float) this._player.potionDelay, true);
        Color color = Color.Lerp(ChromaHotkeyPainter.PainterColors.DangerKeyBlocked, ChromaHotkeyPainter.PainterColors.QuickHealCooldown, lerpValue) * lerpValue * lerpValue * lerpValue;
        healKey.SetSolid(color);
        this._quickHealAlert = 0;
      }
      else if (this._player.statLife == this._player.statLifeMax2)
      {
        healKey.SetClear();
        this._quickHealAlert = 0;
      }
      else if ((double) this._player.statLife <= (double) this._player.statLifeMax2 / 4.0)
      {
        if (this._quickHealAlert == 1)
          return;
        this._quickHealAlert = 1;
        healKey.SetAlert(Color.Black, ChromaHotkeyPainter.PainterColors.QuickHealReadyUrgent, -1f, 2f);
      }
      else if ((double) this._player.statLife <= (double) this._player.statLifeMax2 / 2.0)
      {
        if (this._quickHealAlert == 2)
          return;
        this._quickHealAlert = 2;
        healKey.SetAlert(Color.Black, ChromaHotkeyPainter.PainterColors.QuickHealReadyUrgent, -1f, 2f);
      }
      else
      {
        healKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickHealReady);
        this._quickHealAlert = 0;
      }
    }

    private void Step_QuickMana()
    {
      ChromaHotkeyPainter.PaintKey manaKey = this._manaKey;
      if (this._player.QuickMana_GetItemToUse() == null || this._player.DeadOrGhost || this._player.statMana == this._player.statManaMax2)
        manaKey.SetClear();
      else
        manaKey.SetSolid(ChromaHotkeyPainter.PainterColors.QuickMana);
    }

    private void Step_Throw()
    {
      ChromaHotkeyPainter.PaintKey throwKey = this._throwKey;
      Item heldItem = this._player.HeldItem;
      if (this._player.DeadOrGhost || this._player.HeldItem.favorited || this._player.noThrow > 0)
        throwKey.SetClear();
      else if (this._player.frozen || this._player.tongued || this._player.webbed || this._player.stoned || this._player.noItems)
        throwKey.SetClear();
      else
        throwKey.SetSolid(ChromaHotkeyPainter.PainterColors.Throw);
    }

    private class ReactiveRGBKey
    {
      public readonly Keys XNAKey;
      private readonly Color _color;
      private readonly TimeSpan _duration;
      private TimeSpan _startTime;
      private TimeSpan _expireTime;
      private RgbKey _rgbKey;

      public bool Expired => this._expireTime < Main.gameTimeCache.TotalGameTime;

      public ReactiveRGBKey(Keys key, Color color, TimeSpan duration)
      {
        this._color = color;
        this.XNAKey = key;
        this._duration = duration;
        this._startTime = Main.gameTimeCache.TotalGameTime;
      }

      public void Update() => this._rgbKey.SetSolid(Color.Lerp(this._color, Color.Black, (float) Utils.GetLerpValue(this._startTime.TotalSeconds, this._expireTime.TotalSeconds, Main.gameTimeCache.TotalGameTime.TotalSeconds, true)));

      public void Clear() => this._rgbKey.Clear();

      public void Unbind() => Main.Chroma.UnbindKey(this.XNAKey);

      public void Bind() => this._rgbKey = Main.Chroma.BindKey(this.XNAKey);

      public void Refresh()
      {
        this._startTime = Main.gameTimeCache.TotalGameTime;
        this._expireTime = this._startTime;
        this._expireTime.Add(this._duration);
      }
    }

    private class PaintKey
    {
      private string _trigger;
      private List<Keys> _xnaKeys;
      private List<RgbKey> _rgbKeys;

      public PaintKey(string triggerName, List<string> keys)
      {
        this._trigger = triggerName;
        this._xnaKeys = new List<Keys>();
        foreach (string key in keys)
        {
          Keys result;
          if (Enum.TryParse<Keys>(key, true, out result))
            this._xnaKeys.Add(result);
        }
        this._rgbKeys = new List<RgbKey>();
      }

      public void Unbind()
      {
        foreach (RgbKey rgbKey in this._rgbKeys)
          Main.Chroma.UnbindKey((Keys) rgbKey.Key);
      }

      public void Bind()
      {
        foreach (Keys xnaKey in this._xnaKeys)
          this._rgbKeys.Add(Main.Chroma.BindKey(xnaKey));
        this._rgbKeys = ((IEnumerable<RgbKey>) this._rgbKeys).Distinct<RgbKey>().ToList<RgbKey>();
      }

      public void SetSolid(Color color)
      {
        foreach (RgbKey rgbKey in this._rgbKeys)
          rgbKey.SetSolid(color);
      }

      public void SetClear()
      {
        foreach (RgbKey rgbKey in this._rgbKeys)
          rgbKey.Clear();
      }

      public bool UsesKey(Keys key) => this._xnaKeys.Contains(key);

      public void SetAlert(Color colorBase, Color colorFlash, float time, float flashesPerSecond)
      {
        if ((double) time == -1.0)
          time = 10000f;
        foreach (RgbKey rgbKey in this._rgbKeys)
          rgbKey.SetFlashing(colorBase, colorFlash, time, flashesPerSecond);
      }

      public List<Keys> GetXNAKeysInUse() => new List<Keys>((IEnumerable<Keys>) this._xnaKeys);
    }

    private static class PainterColors
    {
      private const float HOTKEY_COLOR_MULTIPLIER = 1f;
      public static readonly Color MovementKeys = Color.Gray * 1f;
      public static readonly Color QuickMount = Color.RoyalBlue * 1f;
      public static readonly Color QuickGrapple = Color.Lerp(Color.RoyalBlue, Color.Blue, 0.5f) * 1f;
      public static readonly Color QuickHealReady = Color.Pink * 1f;
      public static readonly Color QuickHealReadyUrgent = Color.DeepPink * 1f;
      public static readonly Color QuickHealCooldown = Color.HotPink * 0.5f * 1f;
      public static readonly Color QuickMana = new Color(40, 0, 230) * 1f;
      public static readonly Color Throw = Color.Red * 0.2f * 1f;
      public static readonly Color SmartCursor = Color.Gold;
      public static readonly Color SmartSelect = Color.Goldenrod;
      public static readonly Color DangerKeyBlocked = Color.Red * 1f;
    }
  }
}
