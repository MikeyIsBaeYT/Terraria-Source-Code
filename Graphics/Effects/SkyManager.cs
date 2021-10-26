// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.SkyManager
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Terraria.Graphics.Effects
{
  public class SkyManager : EffectManager<CustomSky>
  {
    public static SkyManager Instance = new SkyManager();
    private float _lastDepth;
    private LinkedList<CustomSky> _activeSkies = new LinkedList<CustomSky>();

    public void Reset()
    {
      foreach (CustomSky customSky in this._effects.Values)
        customSky.Reset();
      this._activeSkies.Clear();
    }

    public void Update(GameTime gameTime)
    {
      LinkedListNode<CustomSky> next;
      for (int index = 0; index < Main.dayRate; ++index)
      {
        for (LinkedListNode<CustomSky> node = this._activeSkies.First; node != null; node = next)
        {
          CustomSky customSky = node.Value;
          next = node.Next;
          customSky.Update(gameTime);
          if (!customSky.IsActive())
            this._activeSkies.Remove(node);
        }
      }
    }

    public void Draw(SpriteBatch spriteBatch) => this.DrawDepthRange(spriteBatch, float.MinValue, float.MaxValue);

    public void DrawToDepth(SpriteBatch spriteBatch, float minDepth)
    {
      if ((double) this._lastDepth <= (double) minDepth)
        return;
      this.DrawDepthRange(spriteBatch, minDepth, this._lastDepth);
      this._lastDepth = minDepth;
    }

    public void DrawDepthRange(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      foreach (CustomSky activeSky in this._activeSkies)
        activeSky.Draw(spriteBatch, minDepth, maxDepth);
    }

    public void DrawRemainingDepth(SpriteBatch spriteBatch)
    {
      this.DrawDepthRange(spriteBatch, float.MinValue, this._lastDepth);
      this._lastDepth = float.MinValue;
    }

    public void ResetDepthTracker() => this._lastDepth = float.MaxValue;

    public void SetStartingDepth(float depth) => this._lastDepth = depth;

    public override void OnActivate(CustomSky effect, Vector2 position)
    {
      this._activeSkies.Remove(effect);
      this._activeSkies.AddLast(effect);
    }

    public Color ProcessTileColor(Color color)
    {
      foreach (CustomSky activeSky in this._activeSkies)
        color = activeSky.OnTileColor(color);
      return color;
    }

    public float ProcessCloudAlpha()
    {
      float num = 1f;
      foreach (CustomSky activeSky in this._activeSkies)
        num *= activeSky.GetCloudAlpha();
      return MathHelper.Clamp(num, 0.0f, 1f);
    }
  }
}
