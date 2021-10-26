// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.MoonLordSky
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class MoonLordSky : CustomSky
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private bool _isActive;
    private int _moonLordIndex = -1;
    private bool _forPlayer;
    private float _fadeOpacity;

    public MoonLordSky(bool forPlayer) => this._forPlayer = forPlayer;

    public override void OnLoad()
    {
    }

    public override void Update(GameTime gameTime)
    {
      if (!this._forPlayer)
        return;
      if (this._isActive)
        this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
      else
        this._fadeOpacity = Math.Max(0.0f, this._fadeOpacity - 0.01f);
    }

    private float GetIntensity()
    {
      if (this._forPlayer)
        return this._fadeOpacity;
      if (!this.UpdateMoonLordIndex())
        return 0.0f;
      float x = 0.0f;
      if (this._moonLordIndex != -1)
        x = Vector2.Distance(Main.player[Main.myPlayer].Center, Main.npc[this._moonLordIndex].Center);
      return 1f - Utils.SmoothStep(3000f, 6000f, x);
    }

    public override Color OnTileColor(Color inColor)
    {
      float intensity = this.GetIntensity();
      return new Color(Vector4.Lerp(new Vector4(0.5f, 0.8f, 1f, 1f), inColor.ToVector4(), 1f - intensity));
    }

    private bool UpdateMoonLordIndex()
    {
      if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
        return true;
      int num = -1;
      for (int index = 0; index < Main.npc.Length; ++index)
      {
        if (Main.npc[index].active && Main.npc[index].type == 398)
        {
          num = index;
          break;
        }
      }
      this._moonLordIndex = num;
      return num != -1;
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) maxDepth < 0.0 || (double) minDepth >= 0.0)
        return;
      float intensity = this.GetIntensity();
      spriteBatch.Draw(TextureAssets.BlackTile.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * intensity);
    }

    public override float GetCloudAlpha() => 1f - this._fadeOpacity;

    public override void Activate(Vector2 position, params object[] args)
    {
      this._isActive = true;
      if (this._forPlayer)
        this._fadeOpacity = 1f / 500f;
      else
        this._fadeOpacity = 1f;
    }

    public override void Deactivate(params object[] args)
    {
      this._isActive = false;
      if (this._forPlayer)
        return;
      this._fadeOpacity = 0.0f;
    }

    public override void Reset()
    {
      this._isActive = false;
      this._fadeOpacity = 0.0f;
    }

    public override bool IsActive() => this._isActive || (double) this._fadeOpacity > 1.0 / 1000.0;
  }
}
