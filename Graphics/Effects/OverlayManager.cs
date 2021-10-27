// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.OverlayManager
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria.Graphics.Effects
{
  public class OverlayManager : EffectManager<Overlay>
  {
    private const float OPACITY_RATE = 1f;
    private LinkedList<Overlay>[] _activeOverlays = new LinkedList<Overlay>[Enum.GetNames(typeof (EffectPriority)).Length];
    private int _overlayCount;

    public OverlayManager()
    {
      for (int index = 0; index < this._activeOverlays.Length; ++index)
        this._activeOverlays[index] = new LinkedList<Overlay>();
    }

    public override void OnActivate(Overlay overlay, Vector2 position)
    {
      LinkedList<Overlay> activeOverlay = this._activeOverlays[(int) overlay.Priority];
      if (overlay.Mode == OverlayMode.FadeIn || overlay.Mode == OverlayMode.Active)
        return;
      if (overlay.Mode == OverlayMode.FadeOut)
      {
        activeOverlay.Remove(overlay);
        --this._overlayCount;
      }
      else
        overlay.Opacity = 0.0f;
      if (activeOverlay.Count != 0)
      {
        foreach (Overlay overlay1 in activeOverlay)
          overlay1.Mode = OverlayMode.FadeOut;
      }
      activeOverlay.AddLast(overlay);
      ++this._overlayCount;
    }

    public void Update(GameTime gameTime)
    {
      LinkedListNode<Overlay> next;
      for (int index = 0; index < this._activeOverlays.Length; ++index)
      {
        for (LinkedListNode<Overlay> node = this._activeOverlays[index].First; node != null; node = next)
        {
          Overlay overlay = node.Value;
          next = node.Next;
          overlay.Update(gameTime);
          switch (overlay.Mode)
          {
            case OverlayMode.FadeIn:
              overlay.Opacity += (float) (gameTime.ElapsedGameTime.TotalSeconds * 1.0);
              if ((double) overlay.Opacity >= 1.0)
              {
                overlay.Opacity = 1f;
                overlay.Mode = OverlayMode.Active;
                break;
              }
              break;
            case OverlayMode.Active:
              overlay.Opacity = Math.Min(1f, overlay.Opacity + (float) (gameTime.ElapsedGameTime.TotalSeconds * 1.0));
              break;
            case OverlayMode.FadeOut:
              overlay.Opacity -= (float) (gameTime.ElapsedGameTime.TotalSeconds * 1.0);
              if ((double) overlay.Opacity <= 0.0)
              {
                overlay.Opacity = 0.0f;
                overlay.Mode = OverlayMode.Inactive;
                this._activeOverlays[index].Remove(node);
                --this._overlayCount;
                break;
              }
              break;
          }
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch, RenderLayers layer)
    {
      if (this._overlayCount == 0)
        return;
      bool flag = false;
      for (int index = 0; index < this._activeOverlays.Length; ++index)
      {
        for (LinkedListNode<Overlay> linkedListNode = this._activeOverlays[index].First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          Overlay overlay = linkedListNode.Value;
          if (overlay.Layer == layer && overlay.IsVisible())
          {
            if (!flag)
            {
              spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, (Effect) null, Main.Transform);
              flag = true;
            }
            overlay.Draw(spriteBatch);
          }
        }
      }
      if (!flag)
        return;
      spriteBatch.End();
    }
  }
}
