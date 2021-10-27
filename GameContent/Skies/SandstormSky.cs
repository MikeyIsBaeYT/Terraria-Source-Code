// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.SandstormSky
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class SandstormSky : CustomSky
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private bool _isActive;
    private bool _isLeaving;
    private float _opacity;

    public override void OnLoad()
    {
    }

    public override void Update(GameTime gameTime)
    {
      if (Main.gamePaused || !Main.hasFocus)
        return;
      if (this._isLeaving)
      {
        this._opacity -= (float) gameTime.ElapsedGameTime.TotalSeconds;
        if ((double) this._opacity >= 0.0)
          return;
        this._isActive = false;
        this._opacity = 0.0f;
      }
      else
      {
        this._opacity += (float) gameTime.ElapsedGameTime.TotalSeconds;
        if ((double) this._opacity <= 1.0)
          return;
        this._opacity = 1f;
      }
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) minDepth >= 1.0 && (double) maxDepth != 3.40282346638529E+38)
        return;
      float num = Math.Min(1f, Sandstorm.Severity * 1.5f);
      Color color = new Color(new Vector4(0.85f, 0.66f, 0.33f, 1f) * 0.8f * Main.bgColor.ToVector4()) * this._opacity * num;
      spriteBatch.Draw(Main.magicPixel, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color);
    }

    internal override void Activate(Vector2 position, params object[] args)
    {
      this._isActive = true;
      this._isLeaving = false;
    }

    internal override void Deactivate(params object[] args) => this._isLeaving = true;

    public override void Reset()
    {
      this._opacity = 0.0f;
      this._isActive = false;
    }

    public override bool IsActive() => this._isActive;
  }
}
