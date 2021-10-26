// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.ItemsSacrificedUnlocksTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using System.IO;
using Terraria.ID;

namespace Terraria.GameContent.Creative
{
  public class ItemsSacrificedUnlocksTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    public const int POSITIVE_SACRIFICE_COUNT_CAP = 9999;
    private Dictionary<string, int> _sacrificeCountByItemPersistentId;
    public readonly Dictionary<int, int> SacrificesCountByItemIdCache;

    public int LastEditId { get; private set; }

    public ItemsSacrificedUnlocksTracker()
    {
      this._sacrificeCountByItemPersistentId = new Dictionary<string, int>();
      this.SacrificesCountByItemIdCache = new Dictionary<int, int>();
      this.LastEditId = 0;
    }

    public int GetSacrificeCount(int itemId)
    {
      int num;
      this.SacrificesCountByItemIdCache.TryGetValue(itemId, out num);
      return num;
    }

    public void RegisterItemSacrifice(int itemId, int amount)
    {
      string key;
      if (!ContentSamples.ItemPersistentIdsByNetIds.TryGetValue(itemId, out key))
        return;
      int num1;
      this._sacrificeCountByItemPersistentId.TryGetValue(key, out num1);
      int num2 = Utils.Clamp<int>(num1 + amount, 0, 9999);
      this._sacrificeCountByItemPersistentId[key] = num2;
      this.SacrificesCountByItemIdCache[itemId] = num2;
      this.MarkContentsDirty();
    }

    public void SetSacrificeCountDirectly(string persistentId, int sacrificeCount)
    {
      int num = Utils.Clamp<int>(sacrificeCount, 0, 9999);
      this._sacrificeCountByItemPersistentId[persistentId] = num;
      int key;
      if (!ContentSamples.ItemNetIdsByPersistentIds.TryGetValue(persistentId, out key))
        return;
      this.SacrificesCountByItemIdCache[key] = num;
      this.MarkContentsDirty();
    }

    public void Save(BinaryWriter writer)
    {
      Dictionary<string, int> dictionary = new Dictionary<string, int>((IDictionary<string, int>) this._sacrificeCountByItemPersistentId);
      writer.Write(dictionary.Count);
      foreach (KeyValuePair<string, int> keyValuePair in dictionary)
      {
        writer.Write(keyValuePair.Key);
        writer.Write(keyValuePair.Value);
      }
    }

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num1 = reader.ReadInt32();
      for (int index = 0; index < num1; ++index)
      {
        string key1 = reader.ReadString();
        int num2 = reader.ReadInt32();
        this._sacrificeCountByItemPersistentId[key1] = num2;
        int key2;
        if (ContentSamples.ItemNetIdsByPersistentIds.TryGetValue(key1, out key2))
          this.SacrificesCountByItemIdCache[key2] = num2;
      }
    }

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn)
    {
      int num = reader.ReadInt32();
      for (int index = 0; index < num; ++index)
      {
        reader.ReadString();
        reader.ReadInt32();
      }
    }

    public void Reset()
    {
      this._sacrificeCountByItemPersistentId.Clear();
      this.SacrificesCountByItemIdCache.Clear();
      this.MarkContentsDirty();
    }

    public void OnPlayerJoining(int playerIndex)
    {
    }

    public void MarkContentsDirty() => ++this.LastEditId;
  }
}
