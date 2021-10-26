// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Camera
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics
{
  public class Camera
  {
    public Vector2 UnscaledPosition => Main.screenPosition;

    public Vector2 UnscaledSize => new Vector2((float) Main.screenWidth, (float) Main.screenHeight);

    public Vector2 ScaledPosition => this.UnscaledPosition + this.GameViewMatrix.Translation;

    public Vector2 ScaledSize => this.UnscaledSize - this.GameViewMatrix.Translation * 2f;

    public RasterizerState Rasterizer => Main.Rasterizer;

    public SamplerState Sampler => Main.DefaultSamplerState;

    public SpriteViewMatrix GameViewMatrix => Main.GameViewMatrix;

    public SpriteBatch SpriteBatch => Main.spriteBatch;

    public Vector2 Center => this.UnscaledPosition + this.UnscaledSize * 0.5f;
  }
}
