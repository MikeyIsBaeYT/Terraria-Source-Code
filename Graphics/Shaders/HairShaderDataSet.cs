// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.HairShaderDataSet
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class HairShaderDataSet
  {
    protected List<HairShaderData> _shaderData = new List<HairShaderData>();
    protected Dictionary<int, short> _shaderLookupDictionary = new Dictionary<int, short>();
    protected byte _shaderDataCount;

    public T BindShader<T>(int itemId, T shaderData) where T : HairShaderData
    {
      if (this._shaderDataCount == byte.MaxValue)
        throw new Exception("Too many shaders bound.");
      this._shaderLookupDictionary[itemId] = (short) ++this._shaderDataCount;
      this._shaderData.Add((HairShaderData) shaderData);
      return shaderData;
    }

    public void Apply(short shaderId, Player player, DrawData? drawData = null)
    {
      if (shaderId != (short) 0 && (int) shaderId <= (int) this._shaderDataCount)
        this._shaderData[(int) shaderId - 1].Apply(player, drawData);
      else
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public Color GetColor(short shaderId, Player player, Color lightColor) => shaderId != (short) 0 && (int) shaderId <= (int) this._shaderDataCount ? this._shaderData[(int) shaderId - 1].GetColor(player, lightColor) : new Color(lightColor.ToVector4() * player.hairColor.ToVector4());

    public HairShaderData GetShaderFromItemId(int type) => this._shaderLookupDictionary.ContainsKey(type) ? this._shaderData[(int) this._shaderLookupDictionary[type] - 1] : (HairShaderData) null;

    public short GetShaderIdFromItemId(int type) => this._shaderLookupDictionary.ContainsKey(type) ? this._shaderLookupDictionary[type] : (short) -1;
  }
}
