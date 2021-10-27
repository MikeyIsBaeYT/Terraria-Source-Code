// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.ArmorShaderDataSet
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class ArmorShaderDataSet
  {
    protected List<ArmorShaderData> _shaderData = new List<ArmorShaderData>();
    protected Dictionary<int, int> _shaderLookupDictionary = new Dictionary<int, int>();
    protected int _shaderDataCount;

    public T BindShader<T>(int itemId, T shaderData) where T : ArmorShaderData
    {
      this._shaderLookupDictionary[itemId] = ++this._shaderDataCount;
      this._shaderData.Add((ArmorShaderData) shaderData);
      return shaderData;
    }

    public void Apply(int shaderId, Entity entity, DrawData? drawData = null)
    {
      if (shaderId != 0 && shaderId <= this._shaderDataCount)
        this._shaderData[shaderId - 1].Apply(entity, drawData);
      else
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public void ApplySecondary(int shaderId, Entity entity, DrawData? drawData = null)
    {
      if (shaderId != 0 && shaderId <= this._shaderDataCount)
        this._shaderData[shaderId - 1].GetSecondaryShader(entity).Apply(entity, drawData);
      else
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public ArmorShaderData GetShaderFromItemId(int type) => this._shaderLookupDictionary.ContainsKey(type) ? this._shaderData[this._shaderLookupDictionary[type] - 1] : (ArmorShaderData) null;

    public int GetShaderIdFromItemId(int type) => this._shaderLookupDictionary.ContainsKey(type) ? this._shaderLookupDictionary[type] : 0;

    public ArmorShaderData GetSecondaryShader(int id, Player player) => id != 0 && id <= this._shaderDataCount && this._shaderData[id - 1] != null ? this._shaderData[id - 1].GetSecondaryShader((Entity) player) : (ArmorShaderData) null;
  }
}
