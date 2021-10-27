// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Shaders.SandstormShaderData
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
  public class SandstormShaderData : ScreenShaderData
  {
    private Vector2 _texturePosition = Vector2.Zero;

    public SandstormShaderData(string passName)
      : base(passName)
    {
    }

    public override void Update(GameTime gameTime)
    {
      Vector2 vector2 = new Vector2(-Main.windSpeed, -1f) * new Vector2(20f, 0.1f);
      vector2.Normalize();
      Vector2 direction = vector2 * new Vector2(2f, 0.2f);
      if (!Main.gamePaused && Main.hasFocus)
        this._texturePosition += direction * (float) gameTime.ElapsedGameTime.TotalSeconds;
      this._texturePosition.X %= 10f;
      this._texturePosition.Y %= 10f;
      this.UseDirection(direction);
      base.Update(gameTime);
    }

    public override void Apply()
    {
      this.UseTargetPosition(this._texturePosition);
      base.Apply();
    }
  }
}
