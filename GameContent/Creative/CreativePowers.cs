// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativePowers
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI;

namespace Terraria.GameContent.Creative
{
  public class CreativePowers
  {
    public abstract class APerPlayerTogglePower : ICreativePower, IOnPlayerJoining
    {
      internal string _powerNameKey;
      internal Point _iconLocation;
      internal bool _defaultToggleState;
      private bool[] _perPlayerIsEnabled = new bool[(int) byte.MaxValue];

      public ushort PowerId { get; set; }

      public string ServerConfigName { get; set; }

      public PowerPermissionLevel CurrentPermissionLevel { get; set; }

      public PowerPermissionLevel DefaultPermissionLevel { get; set; }

      public bool IsEnabledForPlayer(int playerIndex) => this._perPlayerIsEnabled.IndexInRange<bool>(playerIndex) && this._perPlayerIsEnabled[playerIndex];

      public void DeserializeNetMessage(BinaryReader reader, int userId)
      {
        switch ((CreativePowers.APerPlayerTogglePower.SubMessageType) reader.ReadByte())
        {
          case CreativePowers.APerPlayerTogglePower.SubMessageType.SyncEveryone:
            this.Deserialize_SyncEveryone(reader, userId);
            break;
          case CreativePowers.APerPlayerTogglePower.SubMessageType.SyncOnePlayer:
            int playerIndex = (int) reader.ReadByte();
            bool state = reader.ReadBoolean();
            if (Main.netMode == 2)
            {
              playerIndex = userId;
              if (!CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, playerIndex))
                break;
            }
            this.SetEnabledState(playerIndex, state);
            break;
        }
      }

      private void Deserialize_SyncEveryone(BinaryReader reader, int userId)
      {
        int count = (int) Math.Ceiling((double) this._perPlayerIsEnabled.Length / 8.0);
        if (Main.netMode == 2 && !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, userId))
        {
          reader.ReadBytes(count);
        }
        else
        {
          for (int index = 0; index < count; ++index)
          {
            BitsByte bitsByte = (BitsByte) reader.ReadByte();
            for (int key = 0; key < 8; ++key)
            {
              int playerIndex = index * 8 + key;
              if (playerIndex != Main.myPlayer)
              {
                if (playerIndex < this._perPlayerIsEnabled.Length)
                  this.SetEnabledState(playerIndex, bitsByte[key]);
                else
                  break;
              }
            }
          }
        }
      }

      public void SetEnabledState(int playerIndex, bool state)
      {
        this._perPlayerIsEnabled[playerIndex] = state;
        if (Main.netMode != 2)
          return;
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 3);
        packet.Writer.Write((byte) 1);
        packet.Writer.Write((byte) playerIndex);
        packet.Writer.Write(state);
        NetManager.Instance.Broadcast(packet);
      }

      public void DebugCall() => this.RequestUse();

      internal void RequestUse()
      {
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 1);
        packet.Writer.Write((byte) 1);
        packet.Writer.Write((byte) Main.myPlayer);
        packet.Writer.Write(!this._perPlayerIsEnabled[Main.myPlayer]);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public void Reset()
      {
        for (int index = 0; index < this._perPlayerIsEnabled.Length; ++index)
          this._perPlayerIsEnabled[index] = this._defaultToggleState;
      }

      public void OnPlayerJoining(int playerIndex)
      {
        int num = (int) Math.Ceiling((double) this._perPlayerIsEnabled.Length / 8.0);
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, num + 1);
        packet.Writer.Write((byte) 0);
        for (int index1 = 0; index1 < num; ++index1)
        {
          BitsByte bitsByte = (BitsByte) (byte) 0;
          for (int key = 0; key < 8; ++key)
          {
            int index2 = index1 * 8 + key;
            if (index2 < this._perPlayerIsEnabled.Length)
              bitsByte[key] = this._perPlayerIsEnabled[index2];
            else
              break;
          }
          packet.Writer.Write((byte) bitsByte);
        }
        NetManager.Instance.SendToClient(packet, playerIndex);
      }

      public void ProvidePowerButtons(
        CreativePowerUIElementRequestInfo info,
        List<UIElement> elements)
      {
        GroupOptionButton<bool> toggleButton = CreativePowersHelper.CreateToggleButton(info);
        CreativePowersHelper.UpdateUnlockStateByPower((ICreativePower) this, (UIElement) toggleButton, Main.OurFavoriteColor);
        toggleButton.Append((UIElement) CreativePowersHelper.GetIconImage(this._iconLocation));
        toggleButton.OnClick += new UIElement.MouseEvent(this.button_OnClick);
        toggleButton.OnUpdate += new UIElement.ElementEvent(this.button_OnUpdate);
        elements.Add((UIElement) toggleButton);
      }

      private void button_OnUpdate(UIElement affectedElement)
      {
        bool option = this._perPlayerIsEnabled[Main.myPlayer];
        GroupOptionButton<bool> groupOptionButton = affectedElement as GroupOptionButton<bool>;
        groupOptionButton.SetCurrentOption(option);
        if (!affectedElement.IsMouseHovering)
          return;
        string textValue = Language.GetTextValue(groupOptionButton.IsSelected ? this._powerNameKey + "_Enabled" : this._powerNameKey + "_Disabled");
        CreativePowersHelper.AddDescriptionIfNeeded(ref textValue, this._powerNameKey + "_Description");
        CreativePowersHelper.AddUnlockTextIfNeeded(ref textValue, this.GetIsUnlocked(), this._powerNameKey + "_Unlock");
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref textValue);
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void button_OnClick(UIMouseEvent evt, UIElement listeningElement)
      {
        if (!this.GetIsUnlocked() || !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, Main.myPlayer))
          return;
        this.RequestUse();
      }

      public abstract bool GetIsUnlocked();

      private enum SubMessageType : byte
      {
        SyncEveryone,
        SyncOnePlayer,
      }
    }

    public abstract class APerPlayerSliderPower : 
      ICreativePower,
      IOnPlayerJoining,
      IProvideSliderElement,
      IPowerSubcategoryElement
    {
      internal Point _iconLocation;
      internal float _sliderCurrentValueCache;
      internal string _powerNameKey;
      internal float[] _cachePerPlayer = new float[256];
      internal float _sliderDefaultValue;
      private float _currentTargetValue;
      private bool _needsToCommitChange;
      private DateTime _nextTimeWeCanPush = DateTime.UtcNow;

      public ushort PowerId { get; set; }

      public string ServerConfigName { get; set; }

      public PowerPermissionLevel CurrentPermissionLevel { get; set; }

      public PowerPermissionLevel DefaultPermissionLevel { get; set; }

      public bool GetRemappedSliderValueFor(int playerIndex, out float value)
      {
        value = 0.0f;
        if (!this._cachePerPlayer.IndexInRange<float>(playerIndex))
          return false;
        value = this.RemapSliderValueToPowerValue(this._cachePerPlayer[playerIndex]);
        return true;
      }

      public abstract float RemapSliderValueToPowerValue(float sliderValue);

      public void DeserializeNetMessage(BinaryReader reader, int userId)
      {
        int playerIndex = (int) reader.ReadByte();
        float num = reader.ReadSingle();
        if (Main.netMode == 2)
        {
          playerIndex = userId;
          if (!CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, playerIndex))
            return;
        }
        this._cachePerPlayer[playerIndex] = num;
        if (playerIndex != Main.myPlayer)
          return;
        this._sliderCurrentValueCache = num;
        this.UpdateInfoFromSliderValueCache();
      }

      internal abstract void UpdateInfoFromSliderValueCache();

      public void ProvidePowerButtons(
        CreativePowerUIElementRequestInfo info,
        List<UIElement> elements)
      {
        throw new NotImplementedException();
      }

      public void DebugCall()
      {
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 5);
        packet.Writer.Write((byte) Main.myPlayer);
        packet.Writer.Write(0.0f);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public abstract UIElement ProvideSlider();

      internal float GetSliderValue() => Main.netMode == 1 && this._needsToCommitChange ? this._currentTargetValue : this._sliderCurrentValueCache;

      internal void SetValueKeyboard(float value)
      {
        if ((double) value == (double) this._currentTargetValue || !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, Main.myPlayer))
          return;
        this._currentTargetValue = value;
        this._needsToCommitChange = true;
      }

      internal void SetValueGamepad()
      {
        float sliderValue = this.GetSliderValue();
        float num = UILinksInitializer.HandleSliderVerticalInput(sliderValue, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
        if ((double) num == (double) sliderValue)
          return;
        this.SetValueKeyboard(num);
      }

      public void PushChangeAndSetSlider(float value)
      {
        if (!CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, Main.myPlayer))
          return;
        value = MathHelper.Clamp(value, 0.0f, 1f);
        this._sliderCurrentValueCache = value;
        this._currentTargetValue = value;
        this.PushChange(value);
      }

      public GroupOptionButton<int> GetOptionButton(
        CreativePowerUIElementRequestInfo info,
        int optionIndex,
        int currentOptionIndex)
      {
        GroupOptionButton<int> categoryButton = CreativePowersHelper.CreateCategoryButton<int>(info, optionIndex, currentOptionIndex);
        CreativePowersHelper.UpdateUnlockStateByPower((ICreativePower) this, (UIElement) categoryButton, CreativePowersHelper.CommonSelectedColor);
        categoryButton.Append((UIElement) CreativePowersHelper.GetIconImage(this._iconLocation));
        categoryButton.OnUpdate += new UIElement.ElementEvent(this.categoryButton_OnUpdate);
        return categoryButton;
      }

      private void categoryButton_OnUpdate(UIElement affectedElement)
      {
        if (affectedElement.IsMouseHovering)
        {
          string textValue = Language.GetTextValue(this._powerNameKey + ((affectedElement as GroupOptionButton<int>).IsSelected ? "_Opened" : "_Closed"));
          CreativePowersHelper.AddDescriptionIfNeeded(ref textValue, this._powerNameKey + "_Description");
          CreativePowersHelper.AddUnlockTextIfNeeded(ref textValue, this.GetIsUnlocked(), this._powerNameKey + "_Unlock");
          CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref textValue);
          Main.instance.MouseTextNoOverride(textValue);
        }
        this.AttemptPushingChange();
      }

      private void AttemptPushingChange()
      {
        if (!this._needsToCommitChange || DateTime.UtcNow.CompareTo(this._nextTimeWeCanPush) == -1)
          return;
        this.PushChange(this._currentTargetValue);
      }

      internal void PushChange(float newSliderValue)
      {
        this._needsToCommitChange = false;
        this._sliderCurrentValueCache = newSliderValue;
        this._nextTimeWeCanPush = DateTime.UtcNow;
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 5);
        packet.Writer.Write((byte) Main.myPlayer);
        packet.Writer.Write(newSliderValue);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public virtual void Reset()
      {
        for (int playerIndex = 0; playerIndex < this._cachePerPlayer.Length; ++playerIndex)
          this.ResetForPlayer(playerIndex);
      }

      public virtual void ResetForPlayer(int playerIndex)
      {
        this._cachePerPlayer[playerIndex] = this._sliderDefaultValue;
        if (playerIndex != Main.myPlayer)
          return;
        this._sliderCurrentValueCache = this._sliderDefaultValue;
        this._currentTargetValue = this._sliderDefaultValue;
      }

      public void OnPlayerJoining(int playerIndex) => this.ResetForPlayer(playerIndex);

      public abstract bool GetIsUnlocked();
    }

    public abstract class ASharedButtonPower : ICreativePower
    {
      internal Point _iconLocation;
      internal string _powerNameKey;
      internal string _descriptionKey;

      public ushort PowerId { get; set; }

      public string ServerConfigName { get; set; }

      public PowerPermissionLevel CurrentPermissionLevel { get; set; }

      public PowerPermissionLevel DefaultPermissionLevel { get; set; }

      public ASharedButtonPower() => this.OnCreation();

      public void RequestUse()
      {
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 0);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public void DeserializeNetMessage(BinaryReader reader, int userId)
      {
        if (Main.netMode == 2 && !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, userId))
          return;
        this.UsePower();
      }

      internal abstract void UsePower();

      internal abstract void OnCreation();

      public void ProvidePowerButtons(
        CreativePowerUIElementRequestInfo info,
        List<UIElement> elements)
      {
        GroupOptionButton<bool> simpleButton = CreativePowersHelper.CreateSimpleButton(info);
        CreativePowersHelper.UpdateUnlockStateByPower((ICreativePower) this, (UIElement) simpleButton, CreativePowersHelper.CommonSelectedColor);
        simpleButton.Append((UIElement) CreativePowersHelper.GetIconImage(this._iconLocation));
        simpleButton.OnClick += new UIElement.MouseEvent(this.button_OnClick);
        simpleButton.OnUpdate += new UIElement.ElementEvent(this.button_OnUpdate);
        elements.Add((UIElement) simpleButton);
      }

      private void button_OnUpdate(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string textValue = Language.GetTextValue(this._powerNameKey);
        CreativePowersHelper.AddDescriptionIfNeeded(ref textValue, this._descriptionKey);
        CreativePowersHelper.AddUnlockTextIfNeeded(ref textValue, this.GetIsUnlocked(), this._powerNameKey + "_Unlock");
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref textValue);
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void button_OnClick(UIMouseEvent evt, UIElement listeningElement)
      {
        if (!CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, Main.myPlayer))
          return;
        this.RequestUse();
      }

      public abstract bool GetIsUnlocked();
    }

    public abstract class ASharedTogglePower : ICreativePower, IOnPlayerJoining
    {
      public ushort PowerId { get; set; }

      public string ServerConfigName { get; set; }

      public PowerPermissionLevel CurrentPermissionLevel { get; set; }

      public PowerPermissionLevel DefaultPermissionLevel { get; set; }

      public bool Enabled { get; private set; }

      public void SetPowerInfo(bool enabled) => this.Enabled = enabled;

      public void Reset() => this.Enabled = false;

      public void OnPlayerJoining(int playerIndex)
      {
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 1);
        packet.Writer.Write(this.Enabled);
        NetManager.Instance.SendToClient(packet, playerIndex);
      }

      public void DeserializeNetMessage(BinaryReader reader, int userId)
      {
        bool enabled = reader.ReadBoolean();
        if (Main.netMode == 2 && !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, userId))
          return;
        this.SetPowerInfo(enabled);
        if (Main.netMode != 2)
          return;
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 1);
        packet.Writer.Write(this.Enabled);
        NetManager.Instance.Broadcast(packet);
      }

      private void RequestUse()
      {
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 1);
        packet.Writer.Write(!this.Enabled);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public void ProvidePowerButtons(
        CreativePowerUIElementRequestInfo info,
        List<UIElement> elements)
      {
        GroupOptionButton<bool> toggleButton = CreativePowersHelper.CreateToggleButton(info);
        CreativePowersHelper.UpdateUnlockStateByPower((ICreativePower) this, (UIElement) toggleButton, Main.OurFavoriteColor);
        this.CustomizeButton((UIElement) toggleButton);
        toggleButton.OnClick += new UIElement.MouseEvent(this.button_OnClick);
        toggleButton.OnUpdate += new UIElement.ElementEvent(this.button_OnUpdate);
        elements.Add((UIElement) toggleButton);
      }

      private void button_OnUpdate(UIElement affectedElement)
      {
        bool enabled = this.Enabled;
        GroupOptionButton<bool> groupOptionButton = affectedElement as GroupOptionButton<bool>;
        groupOptionButton.SetCurrentOption(enabled);
        if (!affectedElement.IsMouseHovering)
          return;
        string buttonTextKey = this.GetButtonTextKey();
        string textValue = Language.GetTextValue(buttonTextKey + (groupOptionButton.IsSelected ? "_Enabled" : "_Disabled"));
        CreativePowersHelper.AddDescriptionIfNeeded(ref textValue, buttonTextKey + "_Description");
        CreativePowersHelper.AddUnlockTextIfNeeded(ref textValue, this.GetIsUnlocked(), buttonTextKey + "_Unlock");
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref textValue);
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void button_OnClick(UIMouseEvent evt, UIElement listeningElement)
      {
        if (!CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, Main.myPlayer))
          return;
        this.RequestUse();
      }

      internal abstract void CustomizeButton(UIElement button);

      internal abstract string GetButtonTextKey();

      public abstract bool GetIsUnlocked();
    }

    public abstract class ASharedSliderPower : 
      ICreativePower,
      IOnPlayerJoining,
      IProvideSliderElement,
      IPowerSubcategoryElement
    {
      internal Point _iconLocation;
      internal float _sliderCurrentValueCache;
      internal string _powerNameKey;
      internal bool _syncToJoiningPlayers = true;
      internal float _currentTargetValue;
      private bool _needsToCommitChange;
      private DateTime _nextTimeWeCanPush = DateTime.UtcNow;

      public ushort PowerId { get; set; }

      public string ServerConfigName { get; set; }

      public PowerPermissionLevel CurrentPermissionLevel { get; set; }

      public PowerPermissionLevel DefaultPermissionLevel { get; set; }

      public void DeserializeNetMessage(BinaryReader reader, int userId)
      {
        float num = reader.ReadSingle();
        if (Main.netMode == 2 && !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, userId))
          return;
        this._sliderCurrentValueCache = num;
        this.UpdateInfoFromSliderValueCache();
        if (Main.netMode != 2)
          return;
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 4);
        packet.Writer.Write(num);
        NetManager.Instance.Broadcast(packet);
      }

      internal abstract void UpdateInfoFromSliderValueCache();

      public void ProvidePowerButtons(
        CreativePowerUIElementRequestInfo info,
        List<UIElement> elements)
      {
        throw new NotImplementedException();
      }

      public void DebugCall()
      {
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 4);
        packet.Writer.Write(0.0f);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public abstract UIElement ProvideSlider();

      internal float GetSliderValue() => Main.netMode == 1 && this._needsToCommitChange ? this._currentTargetValue : this.GetSliderValueInner();

      internal virtual float GetSliderValueInner() => this._sliderCurrentValueCache;

      internal void SetValueKeyboard(float value)
      {
        if ((double) value == (double) this._currentTargetValue || !CreativePowersHelper.IsAvailableForPlayer((ICreativePower) this, Main.myPlayer))
          return;
        this._currentTargetValue = value;
        this._needsToCommitChange = true;
      }

      internal void SetValueGamepad()
      {
        float sliderValue = this.GetSliderValue();
        float num = UILinksInitializer.HandleSliderVerticalInput(sliderValue, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
        if ((double) num == (double) sliderValue)
          return;
        this.SetValueKeyboard(num);
      }

      public GroupOptionButton<int> GetOptionButton(
        CreativePowerUIElementRequestInfo info,
        int optionIndex,
        int currentOptionIndex)
      {
        GroupOptionButton<int> categoryButton = CreativePowersHelper.CreateCategoryButton<int>(info, optionIndex, currentOptionIndex);
        CreativePowersHelper.UpdateUnlockStateByPower((ICreativePower) this, (UIElement) categoryButton, CreativePowersHelper.CommonSelectedColor);
        categoryButton.Append((UIElement) CreativePowersHelper.GetIconImage(this._iconLocation));
        categoryButton.OnUpdate += new UIElement.ElementEvent(this.categoryButton_OnUpdate);
        return categoryButton;
      }

      private void categoryButton_OnUpdate(UIElement affectedElement)
      {
        if (affectedElement.IsMouseHovering)
        {
          string textValue = Language.GetTextValue(this._powerNameKey + ((affectedElement as GroupOptionButton<int>).IsSelected ? "_Opened" : "_Closed"));
          CreativePowersHelper.AddDescriptionIfNeeded(ref textValue, this._powerNameKey + "_Description");
          CreativePowersHelper.AddUnlockTextIfNeeded(ref textValue, this.GetIsUnlocked(), this._powerNameKey + "_Unlock");
          CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref textValue);
          Main.instance.MouseTextNoOverride(textValue);
        }
        this.AttemptPushingChange();
      }

      private void AttemptPushingChange()
      {
        if (!this._needsToCommitChange || DateTime.UtcNow.CompareTo(this._nextTimeWeCanPush) == -1)
          return;
        this._needsToCommitChange = false;
        this._sliderCurrentValueCache = this._currentTargetValue;
        this._nextTimeWeCanPush = DateTime.UtcNow;
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 4);
        packet.Writer.Write(this._currentTargetValue);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }

      public virtual void Reset() => this._sliderCurrentValueCache = 0.0f;

      public void OnPlayerJoining(int playerIndex)
      {
        if (!this._syncToJoiningPlayers)
          return;
        NetPacket packet = NetCreativePowersModule.PreparePacket(this.PowerId, 4);
        packet.Writer.Write(this._sliderCurrentValueCache);
        NetManager.Instance.SendToClient(packet, playerIndex);
      }

      public abstract bool GetIsUnlocked();
    }

    public class GodmodePower : CreativePowers.APerPlayerTogglePower, IPersistentPerPlayerContent
    {
      public GodmodePower()
      {
        this._powerNameKey = "CreativePowers.Godmode";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.Godmode;
      }

      public override bool GetIsUnlocked() => true;

      public void Save(Player player, BinaryWriter writer)
      {
        bool flag = this.IsEnabledForPlayer(Main.myPlayer);
        writer.Write(flag);
      }

      public void ResetDataForNewPlayer(Player player) => player.savedPerPlayerFieldsThatArentInThePlayerClass.godmodePowerEnabled = this._defaultToggleState;

      public void Load(Player player, BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        bool flag = reader.ReadBoolean();
        player.savedPerPlayerFieldsThatArentInThePlayerClass.godmodePowerEnabled = flag;
      }

      public void ApplyLoadedDataToOutOfPlayerFields(Player player)
      {
        if (player.savedPerPlayerFieldsThatArentInThePlayerClass.godmodePowerEnabled == this.IsEnabledForPlayer(player.whoAmI))
          return;
        this.RequestUse();
      }
    }

    public class FarPlacementRangePower : 
      CreativePowers.APerPlayerTogglePower,
      IPersistentPerPlayerContent
    {
      public FarPlacementRangePower()
      {
        this._powerNameKey = "CreativePowers.InfinitePlacementRange";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.BlockPlacementRange;
        this._defaultToggleState = true;
      }

      public override bool GetIsUnlocked() => true;

      public void Save(Player player, BinaryWriter writer)
      {
        bool flag = this.IsEnabledForPlayer(Main.myPlayer);
        writer.Write(flag);
      }

      public void ResetDataForNewPlayer(Player player) => player.savedPerPlayerFieldsThatArentInThePlayerClass.farPlacementRangePowerEnabled = this._defaultToggleState;

      public void Load(Player player, BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        bool flag = reader.ReadBoolean();
        player.savedPerPlayerFieldsThatArentInThePlayerClass.farPlacementRangePowerEnabled = flag;
      }

      public void ApplyLoadedDataToOutOfPlayerFields(Player player)
      {
        if (player.savedPerPlayerFieldsThatArentInThePlayerClass.farPlacementRangePowerEnabled == this.IsEnabledForPlayer(player.whoAmI))
          return;
        this.RequestUse();
      }
    }

    public class StartDayImmediately : CreativePowers.ASharedButtonPower
    {
      internal override void UsePower()
      {
        if (Main.netMode == 1)
          return;
        Main.SkipToTime(0, true);
      }

      internal override void OnCreation()
      {
        this._powerNameKey = "CreativePowers.StartDayImmediately";
        this._descriptionKey = this._powerNameKey + "_Description";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.TimeDawn;
      }

      public override bool GetIsUnlocked() => true;
    }

    public class StartNightImmediately : CreativePowers.ASharedButtonPower
    {
      internal override void UsePower()
      {
        if (Main.netMode == 1)
          return;
        Main.SkipToTime(0, false);
      }

      internal override void OnCreation()
      {
        this._powerNameKey = "CreativePowers.StartNightImmediately";
        this._descriptionKey = this._powerNameKey + "_Description";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.TimeDusk;
      }

      public override bool GetIsUnlocked() => true;
    }

    public class StartNoonImmediately : CreativePowers.ASharedButtonPower
    {
      internal override void UsePower()
      {
        if (Main.netMode == 1)
          return;
        Main.SkipToTime(27000, true);
      }

      internal override void OnCreation()
      {
        this._powerNameKey = "CreativePowers.StartNoonImmediately";
        this._descriptionKey = this._powerNameKey + "_Description";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.TimeNoon;
      }

      public override bool GetIsUnlocked() => true;
    }

    public class StartMidnightImmediately : CreativePowers.ASharedButtonPower
    {
      internal override void UsePower()
      {
        if (Main.netMode == 1)
          return;
        Main.SkipToTime(16200, false);
      }

      internal override void OnCreation()
      {
        this._powerNameKey = "CreativePowers.StartMidnightImmediately";
        this._descriptionKey = this._powerNameKey + "_Description";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.TimeMidnight;
      }

      public override bool GetIsUnlocked() => true;
    }

    public class ModifyTimeRate : CreativePowers.ASharedSliderPower, IPersistentPerWorldContent
    {
      public int TargetTimeRate { get; private set; }

      public ModifyTimeRate()
      {
        this._powerNameKey = "CreativePowers.ModifyTimeRate";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.ModifyTime;
      }

      public override void Reset()
      {
        this._sliderCurrentValueCache = 0.0f;
        this.TargetTimeRate = 1;
      }

      internal override void UpdateInfoFromSliderValueCache() => this.TargetTimeRate = (int) Math.Round((double) Utils.Remap(this._sliderCurrentValueCache, 0.0f, 1f, 1f, 24f));

      public override UIElement ProvideSlider()
      {
        UIVerticalSlider slider = CreativePowersHelper.CreateSlider(new Func<float>(((CreativePowers.ASharedSliderPower) this).GetSliderValue), new Action<float>(((CreativePowers.ASharedSliderPower) this).SetValueKeyboard), new Action(((CreativePowers.ASharedSliderPower) this).SetValueGamepad));
        slider.OnUpdate += new UIElement.ElementEvent(this.UpdateSliderAndShowMultiplierMouseOver);
        UIPanel uiPanel = new UIPanel();
        uiPanel.Width = new StyleDimension(87f, 0.0f);
        uiPanel.Height = new StyleDimension(180f, 0.0f);
        uiPanel.HAlign = 0.0f;
        uiPanel.VAlign = 0.5f;
        uiPanel.Append((UIElement) slider);
        uiPanel.OnUpdate += new UIElement.ElementEvent(CreativePowersHelper.UpdateUseMouseInterface);
        UIText uiText1 = new UIText("x24");
        uiText1.HAlign = 1f;
        uiText1.VAlign = 0.0f;
        uiPanel.Append((UIElement) uiText1);
        UIText uiText2 = new UIText("x12");
        uiText2.HAlign = 1f;
        uiText2.VAlign = 0.5f;
        uiPanel.Append((UIElement) uiText2);
        UIText uiText3 = new UIText("x1");
        uiText3.HAlign = 1f;
        uiText3.VAlign = 1f;
        uiPanel.Append((UIElement) uiText3);
        return (UIElement) uiPanel;
      }

      public override bool GetIsUnlocked() => true;

      public void Save(BinaryWriter writer) => writer.Write(this._sliderCurrentValueCache);

      public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        this._sliderCurrentValueCache = reader.ReadSingle();
        this.UpdateInfoFromSliderValueCache();
      }

      public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        double num = (double) reader.ReadSingle();
      }

      private void UpdateSliderAndShowMultiplierMouseOver(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string originalText = "x" + this.TargetTimeRate.ToString();
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref originalText);
        Main.instance.MouseTextNoOverride(originalText);
      }
    }

    public class DifficultySliderPower : 
      CreativePowers.ASharedSliderPower,
      IPersistentPerWorldContent
    {
      public float StrengthMultiplierToGiveNPCs { get; private set; }

      public DifficultySliderPower()
      {
        this._powerNameKey = "CreativePowers.DifficultySlider";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.EnemyStrengthSlider;
      }

      public override void Reset()
      {
        this._sliderCurrentValueCache = 0.0f;
        this.UpdateInfoFromSliderValueCache();
      }

      internal override void UpdateInfoFromSliderValueCache()
      {
        this.StrengthMultiplierToGiveNPCs = (double) this._sliderCurrentValueCache > 0.330000013113022 ? Utils.Remap(this._sliderCurrentValueCache, 0.33f, 1f, 1f, 3f) : Utils.Remap(this._sliderCurrentValueCache, 0.0f, 0.33f, 0.5f, 1f);
        this.StrengthMultiplierToGiveNPCs = (float) Math.Round((double) this.StrengthMultiplierToGiveNPCs * 20.0) / 20f;
      }

      public override UIElement ProvideSlider()
      {
        UIVerticalSlider slider = CreativePowersHelper.CreateSlider(new Func<float>(((CreativePowers.ASharedSliderPower) this).GetSliderValue), new Action<float>(((CreativePowers.ASharedSliderPower) this).SetValueKeyboard), new Action(((CreativePowers.ASharedSliderPower) this).SetValueGamepad));
        UIPanel panel = new UIPanel();
        panel.Width = new StyleDimension(82f, 0.0f);
        panel.Height = new StyleDimension(180f, 0.0f);
        panel.HAlign = 0.0f;
        panel.VAlign = 0.5f;
        panel.Append((UIElement) slider);
        panel.OnUpdate += new UIElement.ElementEvent(CreativePowersHelper.UpdateUseMouseInterface);
        slider.OnUpdate += new UIElement.ElementEvent(this.UpdateSliderColorAndShowMultiplierMouseOver);
        CreativePowers.DifficultySliderPower.AddIndication(panel, 0.0f, "x3", "Images/UI/WorldCreation/IconDifficultyMaster", new UIElement.ElementEvent(this.MouseOver_Master));
        CreativePowers.DifficultySliderPower.AddIndication(panel, 0.3333333f, "x2", "Images/UI/WorldCreation/IconDifficultyExpert", new UIElement.ElementEvent(this.MouseOver_Expert));
        CreativePowers.DifficultySliderPower.AddIndication(panel, 0.6666667f, "x1", "Images/UI/WorldCreation/IconDifficultyNormal", new UIElement.ElementEvent(this.MouseOver_Normal));
        CreativePowers.DifficultySliderPower.AddIndication(panel, 1f, "x0.5", "Images/UI/WorldCreation/IconDifficultyCreative", new UIElement.ElementEvent(this.MouseOver_Journey));
        return (UIElement) panel;
      }

      private static void AddIndication(
        UIPanel panel,
        float yAnchor,
        string indicationText,
        string iconImagePath,
        UIElement.ElementEvent updateEvent)
      {
        UIImage uiImage1 = new UIImage(Main.Assets.Request<Texture2D>(iconImagePath, (AssetRequestMode) 1));
        uiImage1.HAlign = 1f;
        uiImage1.VAlign = yAnchor;
        uiImage1.Left = new StyleDimension(4f, 0.0f);
        uiImage1.Top = new StyleDimension(2f, 0.0f);
        uiImage1.RemoveFloatingPointsFromDrawPosition = true;
        UIImage uiImage2 = uiImage1;
        if (updateEvent != null)
          uiImage2.OnUpdate += updateEvent;
        panel.Append((UIElement) uiImage2);
      }

      private void MouseOver_Journey(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string textValue = Language.GetTextValue("UI.Creative");
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void MouseOver_Normal(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string textValue = Language.GetTextValue("UI.Normal");
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void MouseOver_Expert(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string textValue = Language.GetTextValue("UI.Expert");
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void MouseOver_Master(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string textValue = Language.GetTextValue("UI.Master");
        Main.instance.MouseTextNoOverride(textValue);
      }

      private void UpdateSliderColorAndShowMultiplierMouseOver(UIElement affectedElement)
      {
        if (affectedElement.IsMouseHovering)
        {
          string originalText = "x" + this.StrengthMultiplierToGiveNPCs.ToString("F2");
          CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref originalText);
          Main.instance.MouseTextNoOverride(originalText);
        }
        if (!(affectedElement is UIVerticalSlider uiVerticalSlider))
          return;
        uiVerticalSlider.EmptyColor = Color.Black;
        Color color = !Main.masterMode ? (!Main.expertMode ? ((double) this.StrengthMultiplierToGiveNPCs >= 1.0 ? Color.White : Main.creativeModeColor) : Main.mcColor) : Main.hcColor;
        uiVerticalSlider.FilledColor = color;
      }

      public override bool GetIsUnlocked() => true;

      public void Save(BinaryWriter writer) => writer.Write(this._sliderCurrentValueCache);

      public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        this._sliderCurrentValueCache = reader.ReadSingle();
        this.UpdateInfoFromSliderValueCache();
      }

      public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        double num = (double) reader.ReadSingle();
      }
    }

    public class ModifyWindDirectionAndStrength : CreativePowers.ASharedSliderPower
    {
      public ModifyWindDirectionAndStrength()
      {
        this._powerNameKey = "CreativePowers.ModifyWindDirectionAndStrength";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.WindDirection;
        this._syncToJoiningPlayers = false;
      }

      internal override void UpdateInfoFromSliderValueCache() => Main.windSpeedCurrent = Main.windSpeedTarget = MathHelper.Lerp(-0.8f, 0.8f, this._sliderCurrentValueCache);

      internal override float GetSliderValueInner() => Utils.GetLerpValue(-0.8f, 0.8f, Main.windSpeedTarget, false);

      public override bool GetIsUnlocked() => true;

      public override UIElement ProvideSlider()
      {
        UIVerticalSlider slider = CreativePowersHelper.CreateSlider(new Func<float>(((CreativePowers.ASharedSliderPower) this).GetSliderValue), new Action<float>(((CreativePowers.ASharedSliderPower) this).SetValueKeyboard), new Action(((CreativePowers.ASharedSliderPower) this).SetValueGamepad));
        slider.OnUpdate += new UIElement.ElementEvent(this.UpdateSliderAndShowMultiplierMouseOver);
        UIPanel uiPanel = new UIPanel();
        uiPanel.Width = new StyleDimension(132f, 0.0f);
        uiPanel.Height = new StyleDimension(180f, 0.0f);
        uiPanel.HAlign = 0.0f;
        uiPanel.VAlign = 0.5f;
        uiPanel.Append((UIElement) slider);
        uiPanel.OnUpdate += new UIElement.ElementEvent(CreativePowersHelper.UpdateUseMouseInterface);
        UIText uiText1 = new UIText(Language.GetText("CreativePowers.WindWest"));
        uiText1.HAlign = 1f;
        uiText1.VAlign = 0.0f;
        uiPanel.Append((UIElement) uiText1);
        UIText uiText2 = new UIText(Language.GetText("CreativePowers.WindEast"));
        uiText2.HAlign = 1f;
        uiText2.VAlign = 1f;
        uiPanel.Append((UIElement) uiText2);
        UIText uiText3 = new UIText(Language.GetText("CreativePowers.WindNone"));
        uiText3.HAlign = 1f;
        uiText3.VAlign = 0.5f;
        uiPanel.Append((UIElement) uiText3);
        return (UIElement) uiPanel;
      }

      private void UpdateSliderAndShowMultiplierMouseOver(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        int num = (int) ((double) Main.windSpeedCurrent * 50.0);
        string originalText = "";
        if (num < 0)
          originalText += Language.GetTextValue("GameUI.EastWind", (object) Math.Abs(num));
        else if (num > 0)
          originalText += Language.GetTextValue("GameUI.WestWind", (object) num);
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref originalText);
        Main.instance.MouseTextNoOverride(originalText);
      }
    }

    public class ModifyRainPower : CreativePowers.ASharedSliderPower
    {
      public ModifyRainPower()
      {
        this._powerNameKey = "CreativePowers.ModifyRainPower";
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.RainStrength;
        this._syncToJoiningPlayers = false;
      }

      internal override void UpdateInfoFromSliderValueCache()
      {
        if ((double) this._sliderCurrentValueCache == 0.0)
          Main.StopRain();
        else
          Main.StartRain();
        Main.cloudAlpha = this._sliderCurrentValueCache;
        Main.maxRaining = this._sliderCurrentValueCache;
      }

      internal override float GetSliderValueInner() => Main.cloudAlpha;

      public override bool GetIsUnlocked() => true;

      public override UIElement ProvideSlider()
      {
        UIVerticalSlider slider = CreativePowersHelper.CreateSlider(new Func<float>(((CreativePowers.ASharedSliderPower) this).GetSliderValue), new Action<float>(((CreativePowers.ASharedSliderPower) this).SetValueKeyboard), new Action(((CreativePowers.ASharedSliderPower) this).SetValueGamepad));
        slider.OnUpdate += new UIElement.ElementEvent(this.UpdateSliderAndShowMultiplierMouseOver);
        UIPanel uiPanel = new UIPanel();
        uiPanel.Width = new StyleDimension(132f, 0.0f);
        uiPanel.Height = new StyleDimension(180f, 0.0f);
        uiPanel.HAlign = 0.0f;
        uiPanel.VAlign = 0.5f;
        uiPanel.Append((UIElement) slider);
        uiPanel.OnUpdate += new UIElement.ElementEvent(CreativePowersHelper.UpdateUseMouseInterface);
        UIText uiText1 = new UIText(Language.GetText("CreativePowers.WeatherMonsoon"));
        uiText1.HAlign = 1f;
        uiText1.VAlign = 0.0f;
        uiPanel.Append((UIElement) uiText1);
        UIText uiText2 = new UIText(Language.GetText("CreativePowers.WeatherClearSky"));
        uiText2.HAlign = 1f;
        uiText2.VAlign = 1f;
        uiPanel.Append((UIElement) uiText2);
        UIText uiText3 = new UIText(Language.GetText("CreativePowers.WeatherDrizzle"));
        uiText3.HAlign = 1f;
        uiText3.VAlign = 0.5f;
        uiPanel.Append((UIElement) uiText3);
        return (UIElement) uiPanel;
      }

      private void UpdateSliderAndShowMultiplierMouseOver(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string originalText = Main.maxRaining.ToString("P0");
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref originalText);
        Main.instance.MouseTextNoOverride(originalText);
      }
    }

    public class FreezeTime : CreativePowers.ASharedTogglePower, IPersistentPerWorldContent
    {
      internal override void CustomizeButton(UIElement button) => button.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.FreezeTime));

      internal override string GetButtonTextKey() => "CreativePowers.FreezeTime";

      public override bool GetIsUnlocked() => true;

      public void Save(BinaryWriter writer) => writer.Write(this.Enabled);

      public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.SetPowerInfo(reader.ReadBoolean());

      public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn) => reader.ReadBoolean();
    }

    public class FreezeWindDirectionAndStrength : 
      CreativePowers.ASharedTogglePower,
      IPersistentPerWorldContent
    {
      internal override void CustomizeButton(UIElement button) => button.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.WindFreeze));

      internal override string GetButtonTextKey() => "CreativePowers.FreezeWindDirectionAndStrength";

      public override bool GetIsUnlocked() => true;

      public void Save(BinaryWriter writer) => writer.Write(this.Enabled);

      public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.SetPowerInfo(reader.ReadBoolean());

      public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn) => reader.ReadBoolean();
    }

    public class FreezeRainPower : CreativePowers.ASharedTogglePower, IPersistentPerWorldContent
    {
      internal override void CustomizeButton(UIElement button) => button.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.RainFreeze));

      internal override string GetButtonTextKey() => "CreativePowers.FreezeRainPower";

      public override bool GetIsUnlocked() => true;

      public void Save(BinaryWriter writer) => writer.Write(this.Enabled);

      public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.SetPowerInfo(reader.ReadBoolean());

      public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn) => reader.ReadBoolean();
    }

    public class StopBiomeSpreadPower : CreativePowers.ASharedTogglePower, IPersistentPerWorldContent
    {
      internal override void CustomizeButton(UIElement button) => button.Append((UIElement) CreativePowersHelper.GetIconImage(CreativePowersHelper.CreativePowerIconLocations.StopBiomeSpread));

      internal override string GetButtonTextKey() => "CreativePowers.StopBiomeSpread";

      public override bool GetIsUnlocked() => true;

      public void Save(BinaryWriter writer) => writer.Write(this.Enabled);

      public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.SetPowerInfo(reader.ReadBoolean());

      public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn) => reader.ReadBoolean();
    }

    public class SpawnRateSliderPerPlayerPower : 
      CreativePowers.APerPlayerSliderPower,
      IPersistentPerPlayerContent
    {
      public float StrengthMultiplierToGiveNPCs { get; private set; }

      public SpawnRateSliderPerPlayerPower()
      {
        this._powerNameKey = "CreativePowers.NPCSpawnRateSlider";
        this._sliderDefaultValue = 0.5f;
        this._iconLocation = CreativePowersHelper.CreativePowerIconLocations.EnemySpawnRate;
      }

      public bool GetShouldDisableSpawnsFor(int playerIndex) => this._cachePerPlayer.IndexInRange<float>(playerIndex) && (double) this._cachePerPlayer[playerIndex] == 0.0;

      internal override void UpdateInfoFromSliderValueCache()
      {
      }

      public override float RemapSliderValueToPowerValue(float sliderValue) => (double) sliderValue < 0.5 ? Utils.Remap(sliderValue, 0.0f, 0.5f, 0.1f, 1f) : Utils.Remap(sliderValue, 0.5f, 1f, 1f, 10f);

      public override UIElement ProvideSlider()
      {
        UIVerticalSlider slider = CreativePowersHelper.CreateSlider(new Func<float>(((CreativePowers.APerPlayerSliderPower) this).GetSliderValue), new Action<float>(((CreativePowers.APerPlayerSliderPower) this).SetValueKeyboard), new Action(((CreativePowers.APerPlayerSliderPower) this).SetValueGamepad));
        slider.OnUpdate += new UIElement.ElementEvent(this.UpdateSliderAndShowMultiplierMouseOver);
        UIPanel uiPanel = new UIPanel();
        uiPanel.Width = new StyleDimension(77f, 0.0f);
        uiPanel.Height = new StyleDimension(180f, 0.0f);
        uiPanel.HAlign = 0.0f;
        uiPanel.VAlign = 0.5f;
        uiPanel.Append((UIElement) slider);
        uiPanel.OnUpdate += new UIElement.ElementEvent(CreativePowersHelper.UpdateUseMouseInterface);
        UIText uiText1 = new UIText("x10");
        uiText1.HAlign = 1f;
        uiText1.VAlign = 0.0f;
        uiPanel.Append((UIElement) uiText1);
        UIText uiText2 = new UIText("x1");
        uiText2.HAlign = 1f;
        uiText2.VAlign = 0.5f;
        uiPanel.Append((UIElement) uiText2);
        UIText uiText3 = new UIText("x0");
        uiText3.HAlign = 1f;
        uiText3.VAlign = 1f;
        uiPanel.Append((UIElement) uiText3);
        return (UIElement) uiPanel;
      }

      private void UpdateSliderAndShowMultiplierMouseOver(UIElement affectedElement)
      {
        if (!affectedElement.IsMouseHovering)
          return;
        string originalText = "x" + this.RemapSliderValueToPowerValue(this.GetSliderValue()).ToString("F2");
        if (this.GetShouldDisableSpawnsFor(Main.myPlayer))
          originalText = Language.GetTextValue(this._powerNameKey + "EnemySpawnsDisabled");
        CreativePowersHelper.AddPermissionTextIfNeeded((ICreativePower) this, ref originalText);
        Main.instance.MouseTextNoOverride(originalText);
      }

      public override bool GetIsUnlocked() => true;

      public void Save(Player player, BinaryWriter writer)
      {
        float num = this._cachePerPlayer[player.whoAmI];
        writer.Write(num);
      }

      public void ResetDataForNewPlayer(Player player) => player.savedPerPlayerFieldsThatArentInThePlayerClass.spawnRatePowerSliderValue = this._sliderDefaultValue;

      public void Load(Player player, BinaryReader reader, int gameVersionSaveWasMadeOn)
      {
        float num = reader.ReadSingle();
        player.savedPerPlayerFieldsThatArentInThePlayerClass.spawnRatePowerSliderValue = num;
      }

      public void ApplyLoadedDataToOutOfPlayerFields(Player player) => this.PushChangeAndSetSlider(player.savedPerPlayerFieldsThatArentInThePlayerClass.spawnRatePowerSliderValue);
    }
  }
}
