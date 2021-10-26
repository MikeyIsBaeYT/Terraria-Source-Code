// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.FilterManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.IO;

namespace Terraria.Graphics.Effects
{
  public class FilterManager : EffectManager<Filter>
  {
    private const float OPACITY_RATE = 1f;
    private LinkedList<Filter> _activeFilters = new LinkedList<Filter>();
    private int _filterLimit = 16;
    private EffectPriority _priorityThreshold;
    private int _activeFilterCount;
    private bool _captureThisFrame;

    public event Action OnPostDraw;

    public FilterManager()
    {
      Main.Configuration.OnLoad += (Action<Preferences>) (preferences =>
      {
        this._filterLimit = preferences.Get<int>("FilterLimit", 16);
        EffectPriority result;
        if (!Enum.TryParse<EffectPriority>(preferences.Get<string>("FilterPriorityThreshold", "VeryLow"), out result))
          return;
        this._priorityThreshold = result;
      });
      Main.Configuration.OnSave += (Action<Preferences>) (preferences =>
      {
        preferences.Put("FilterLimit", (object) this._filterLimit);
        preferences.Put("FilterPriorityThreshold", (object) Enum.GetName(typeof (EffectPriority), (object) this._priorityThreshold));
      });
    }

    public override void OnActivate(Filter effect, Vector2 position)
    {
      if (this._activeFilters.Contains(effect))
      {
        if (effect.Active)
          return;
        if (effect.Priority >= this._priorityThreshold)
          --this._activeFilterCount;
        this._activeFilters.Remove(effect);
      }
      else
        effect.Opacity = 0.0f;
      if (effect.Priority >= this._priorityThreshold)
        ++this._activeFilterCount;
      if (this._activeFilters.Count == 0)
      {
        this._activeFilters.AddLast(effect);
      }
      else
      {
        for (LinkedListNode<Filter> node = this._activeFilters.First; node != null; node = node.Next)
        {
          Filter filter = node.Value;
          if (effect.Priority <= filter.Priority)
          {
            this._activeFilters.AddAfter(node, effect);
            return;
          }
        }
        this._activeFilters.AddLast(effect);
      }
    }

    public void BeginCapture(RenderTarget2D screenTarget1, Color clearColor)
    {
      if (this._activeFilterCount == 0 && this.OnPostDraw == null)
      {
        this._captureThisFrame = false;
      }
      else
      {
        this._captureThisFrame = true;
        Main.instance.GraphicsDevice.SetRenderTarget(screenTarget1);
        Main.instance.GraphicsDevice.Clear(clearColor);
      }
    }

    public void Update(GameTime gameTime)
    {
      LinkedListNode<Filter> node = this._activeFilters.First;
      int count = this._activeFilters.Count;
      int num = 0;
      LinkedListNode<Filter> next;
      for (; node != null; node = next)
      {
        Filter filter = node.Value;
        next = node.Next;
        bool flag = false;
        if (filter.Priority >= this._priorityThreshold)
        {
          ++num;
          if (num > this._activeFilterCount - this._filterLimit)
          {
            filter.Update(gameTime);
            flag = true;
          }
        }
        if (filter.Active & flag)
          filter.Opacity = Math.Min(filter.Opacity + (float) (gameTime.ElapsedGameTime.TotalSeconds * 1.0), 1f);
        else
          filter.Opacity = Math.Max(filter.Opacity - (float) (gameTime.ElapsedGameTime.TotalSeconds * 1.0), 0.0f);
        if (!filter.Active && (double) filter.Opacity == 0.0)
        {
          if (filter.Priority >= this._priorityThreshold)
            --this._activeFilterCount;
          this._activeFilters.Remove(node);
        }
      }
    }

    public void EndCapture(
      RenderTarget2D finalTexture,
      RenderTarget2D screenTarget1,
      RenderTarget2D screenTarget2,
      Color clearColor)
    {
      if (!this._captureThisFrame)
        return;
      LinkedListNode<Filter> linkedListNode = this._activeFilters.First;
      int count = this._activeFilters.Count;
      Filter filter1 = (Filter) null;
      RenderTarget2D renderTarget2D = screenTarget1;
      GraphicsDevice graphicsDevice = Main.instance.GraphicsDevice;
      int num = 0;
      if ((double) Main.player[Main.myPlayer].gravDir == -1.0)
      {
        RenderTarget2D renderTarget = screenTarget2;
        graphicsDevice.SetRenderTarget(renderTarget);
        graphicsDevice.Clear(clearColor);
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, (Effect) null, Matrix.Invert(Main.GameViewMatrix.EffectMatrix));
        Main.spriteBatch.Draw((Texture2D) renderTarget2D, Vector2.Zero, Color.White);
        Main.spriteBatch.End();
        renderTarget2D = screenTarget2;
      }
      LinkedListNode<Filter> next;
      for (; linkedListNode != null; linkedListNode = next)
      {
        Filter filter2 = linkedListNode.Value;
        next = linkedListNode.Next;
        if (filter2.Priority >= this._priorityThreshold)
        {
          ++num;
          if (num > this._activeFilterCount - this._filterLimit && filter2.IsVisible())
          {
            if (filter1 != null)
            {
              RenderTarget2D renderTarget = renderTarget2D != screenTarget1 ? screenTarget1 : screenTarget2;
              graphicsDevice.SetRenderTarget(renderTarget);
              graphicsDevice.Clear(clearColor);
              Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
              filter1.Apply();
              Main.spriteBatch.Draw((Texture2D) renderTarget2D, Vector2.Zero, Main.ColorOfTheSkies);
              Main.spriteBatch.End();
              renderTarget2D = renderTarget2D != screenTarget1 ? screenTarget1 : screenTarget2;
            }
            filter1 = filter2;
          }
        }
      }
      graphicsDevice.SetRenderTarget(finalTexture);
      graphicsDevice.Clear(clearColor);
      if ((double) Main.player[Main.myPlayer].gravDir == -1.0)
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, (Effect) null, Main.GameViewMatrix.EffectMatrix);
      else
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
      if (filter1 != null)
      {
        filter1.Apply();
        Main.spriteBatch.Draw((Texture2D) renderTarget2D, Vector2.Zero, Main.ColorOfTheSkies);
      }
      else
        Main.spriteBatch.Draw((Texture2D) renderTarget2D, Vector2.Zero, Color.White);
      Main.spriteBatch.End();
      for (int index = 0; index < 8; ++index)
        graphicsDevice.Textures[index] = (Texture) null;
      if (this.OnPostDraw == null)
        return;
      this.OnPostDraw();
    }

    public bool HasActiveFilter() => (uint) this._activeFilters.Count > 0U;

    public bool CanCapture() => this.HasActiveFilter() || this.OnPostDraw != null;
  }
}
