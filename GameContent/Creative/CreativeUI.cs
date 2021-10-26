// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativeUI
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.Creative
{
  public class CreativeUI
  {
    public const int ItemSlotIndexes_SacrificeItem = 0;
    public const int ItemSlotIndexes_Count = 1;
    private bool _initialized;
    private Asset<Texture2D> _buttonTexture;
    private Asset<Texture2D> _buttonBorderTexture;
    private Item[] _itemSlotsForUI = new Item[1];
    private List<int> _itemIdsAvailableInfinitely = new List<int>();
    private UserInterface _powersUI = new UserInterface();
    public int GamepadPointIdForInfiniteItemSearchHack = -1;
    public bool GamepadMoveToSearchButtonHack;
    private UICreativePowersMenu _uiState;

    public bool Enabled { get; private set; }

    public bool Blocked => Main.LocalPlayer.talkNPC != -1 || Main.LocalPlayer.chest != -1;

    public CreativeUI()
    {
      for (int index = 0; index < this._itemSlotsForUI.Length; ++index)
        this._itemSlotsForUI[index] = new Item();
    }

    public void Initialize()
    {
      this._buttonTexture = Main.Assets.Request<Texture2D>("Images/UI/Creative/Journey_Toggle", (AssetRequestMode) 1);
      this._buttonBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/Creative/Journey_Toggle_MouseOver", (AssetRequestMode) 1);
      this._itemIdsAvailableInfinitely.Clear();
      this._uiState = new UICreativePowersMenu();
      this._powersUI.SetState((UIState) this._uiState);
      this._initialized = true;
    }

    public void Update(GameTime gameTime)
    {
      if (!this.Enabled || !Main.playerInventory)
        return;
      this._powersUI.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      if (!this._initialized)
        this.Initialize();
      if (Main.LocalPlayer.difficulty != (byte) 3)
      {
        this.Enabled = false;
      }
      else
      {
        if (this.Blocked)
          return;
        Vector2 location = new Vector2(28f, 267f);
        Vector2 vector2_1 = new Vector2(353f, 258f);
        Vector2 vector2_2 = new Vector2(40f, 267f);
        Vector2 vector2_3 = new Vector2(50f, 50f);
        Vector2 vector2_4 = vector2_1 + vector2_3;
        if (Main.screenHeight < 650 && this.Enabled)
          location.X += 52f * Main.inventoryScale;
        this.DrawToggleButton(spriteBatch, location);
        if (!this.Enabled)
          return;
        this._powersUI.Draw(spriteBatch, Main.gameTimeCache);
      }
    }

    public UIElement ProvideItemSlotElement(int itemSlotContext) => itemSlotContext != 0 ? (UIElement) null : (UIElement) new UIItemSlot(this._itemSlotsForUI, itemSlotContext, 30);

    public Item GetItemByIndex(int itemSlotContext) => itemSlotContext != 0 ? (Item) null : this._itemSlotsForUI[itemSlotContext];

    public void SetItembyIndex(Item item, int itemSlotContext)
    {
      if (itemSlotContext != 0)
        return;
      this._itemSlotsForUI[itemSlotContext] = item;
    }

    private void DrawToggleButton(SpriteBatch spritebatch, Vector2 location)
    {
      Vector2 size = this._buttonTexture.Size();
      Rectangle rectangle = Utils.CenteredRectangle(location + size / 2f, size);
      UILinkPointNavigator.SetPosition(311, rectangle.Center.ToVector2());
      spritebatch.Draw(this._buttonTexture.Value, location, new Rectangle?(), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      Main.LocalPlayer.creativeInterface = false;
      if (!rectangle.Contains(Main.MouseScreen.ToPoint()))
        return;
      Main.LocalPlayer.creativeInterface = true;
      Main.LocalPlayer.mouseInterface = true;
      if (this.Enabled)
        Main.instance.MouseText(Language.GetTextValue("CreativePowers.PowersMenuOpen"));
      else
        Main.instance.MouseText(Language.GetTextValue("CreativePowers.PowersMenuClosed"));
      spritebatch.Draw(this._buttonBorderTexture.Value, location, new Rectangle?(), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      if (!Main.mouseLeft || !Main.mouseLeftRelease)
        return;
      this.ToggleMenu();
    }

    public void SwapItem(ref Item item) => Utils.Swap<Item>(ref item, ref this._itemSlotsForUI[0]);

    public void CloseMenu()
    {
      this.Enabled = false;
      if (this._itemSlotsForUI[0].stack <= 0)
        return;
      this._itemSlotsForUI[0] = Main.LocalPlayer.GetItem(Main.myPlayer, this._itemSlotsForUI[0], GetItemSettings.InventoryUIToInventorySettings);
    }

    public void ToggleMenu()
    {
      this.Enabled = !this.Enabled;
      SoundEngine.PlaySound(12);
      if (this.Enabled)
      {
        Recipe.FindRecipes();
        Main.LocalPlayer.tileEntityAnchor.Clear();
        this.RefreshAvailableInfiniteItemsList();
      }
      else
      {
        if (this._itemSlotsForUI[0].stack <= 0)
          return;
        this._itemSlotsForUI[0] = Main.LocalPlayer.GetItem(Main.myPlayer, this._itemSlotsForUI[0], GetItemSettings.InventoryUIToInventorySettings);
      }
    }

    public bool IsShowingResearchMenu() => this.Enabled && this._uiState != null && this._uiState.IsShowingResearchMenu;

    public bool ShouldDrawSacrificeArea()
    {
      if (!this._itemSlotsForUI[0].IsAir)
        return true;
      Item mouseItem = Main.mouseItem;
      int amountNeeded;
      return !mouseItem.IsAir && CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(mouseItem.type, out amountNeeded) && Main.LocalPlayerCreativeTracker.ItemSacrifices.GetSacrificeCount(mouseItem.type) < amountNeeded;
    }

    public bool GetSacrificeNumbers(
      out int itemIdChecked,
      out int amountWeHave,
      out int amountNeededTotal)
    {
      amountWeHave = 0;
      amountNeededTotal = 0;
      itemIdChecked = 0;
      Item obj = this._itemSlotsForUI[0];
      if (!obj.IsAir)
        itemIdChecked = obj.type;
      if (!CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(obj.type, out amountNeededTotal))
        return false;
      Main.LocalPlayerCreativeTracker.ItemSacrifices.SacrificesCountByItemIdCache.TryGetValue(obj.type, out amountWeHave);
      return true;
    }

    public CreativeUI.ItemSacrificeResult SacrificeItem(out int amountWeSacrificed)
    {
      int amountNeeded = 0;
      amountWeSacrificed = 0;
      Item newItem = this._itemSlotsForUI[0];
      if (!CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(newItem.type, out amountNeeded))
        return CreativeUI.ItemSacrificeResult.CannotSacrifice;
      int num1 = 0;
      Main.LocalPlayerCreativeTracker.ItemSacrifices.SacrificesCountByItemIdCache.TryGetValue(newItem.type, out num1);
      int val1 = Utils.Clamp<int>(amountNeeded - num1, 0, amountNeeded);
      if (val1 == 0)
        return CreativeUI.ItemSacrificeResult.CannotSacrifice;
      int amount = Math.Min(val1, newItem.stack);
      if (!Main.ServerSideCharacter)
      {
        Main.LocalPlayerCreativeTracker.ItemSacrifices.RegisterItemSacrifice(newItem.type, amount);
      }
      else
      {
        NetPacket packet = NetCreativeUnlocksPlayerReportModule.SerializeSacrificeRequest(newItem.type, amount);
        NetManager.Instance.SendToServerOrLoopback(packet);
      }
      int num2 = amount == val1 ? 1 : 0;
      newItem.stack -= amount;
      if (newItem.stack <= 0)
        newItem.TurnToAir();
      amountWeSacrificed = amount;
      this.RefreshAvailableInfiniteItemsList();
      if (newItem.stack > 0)
      {
        newItem.position.X = Main.player[Main.myPlayer].Center.X - (float) (newItem.width / 2);
        newItem.position.Y = Main.player[Main.myPlayer].Center.Y - (float) (newItem.height / 2);
        this._itemSlotsForUI[0] = Main.LocalPlayer.GetItem(Main.myPlayer, newItem, GetItemSettings.InventoryUIToInventorySettings);
      }
      return num2 == 0 ? CreativeUI.ItemSacrificeResult.SacrificedButNotDone : CreativeUI.ItemSacrificeResult.SacrificedAndDone;
    }

    private void RefreshAvailableInfiniteItemsList()
    {
      this._itemIdsAvailableInfinitely.Clear();
      CreativeItemSacrificesCatalog.Instance.FillListOfItemsThatCanBeObtainedInfinitely(this._itemIdsAvailableInfinitely);
    }

    public void Reset()
    {
      for (int index = 0; index < this._itemSlotsForUI.Length; ++index)
        this._itemSlotsForUI[index].TurnToAir();
      this._initialized = false;
      this.Enabled = false;
    }

    public enum ItemSacrificeResult
    {
      CannotSacrifice,
      SacrificedButNotDone,
      SacrificedAndDone,
    }
  }
}
