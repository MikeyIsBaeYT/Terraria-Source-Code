// Decompiled with JetBrains decompiler
// Type: Terraria.Map.MapIconOverlay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.Map
{
  public class MapIconOverlay
  {
    private readonly List<IMapLayer> _layers = new List<IMapLayer>();

    public MapIconOverlay AddLayer(IMapLayer layer)
    {
      this._layers.Add(layer);
      return this;
    }

    public void Draw(
      Vector2 mapPosition,
      Vector2 mapOffset,
      Rectangle? clippingRect,
      float mapScale,
      float drawScale,
      ref string text)
    {
      MapOverlayDrawContext context = new MapOverlayDrawContext(mapPosition, mapOffset, clippingRect, mapScale, drawScale);
      foreach (IMapLayer layer in this._layers)
        layer.Draw(ref context, ref text);
    }
  }
}
