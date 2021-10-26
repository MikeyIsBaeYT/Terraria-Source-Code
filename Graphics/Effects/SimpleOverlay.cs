// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.SimpleOverlay
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
  public class SimpleOverlay : Overlay
  {
    private Asset<Texture2D> _texture;
    private ScreenShaderData _shader;
    public Vector2 TargetPosition = Vector2.Zero;

    public SimpleOverlay(
      string textureName,
      ScreenShaderData shader,
      EffectPriority priority = EffectPriority.VeryLow,
      RenderLayers layer = RenderLayers.All)
      : base(priority, layer)
    {
      this._texture = Main.Assets.Request<Texture2D>(textureName == null ? "" : textureName, (AssetRequestMode) 1);
      this._shader = shader;
    }

    public SimpleOverlay(
      string textureName,
      string shaderName = "Default",
      EffectPriority priority = EffectPriority.VeryLow,
      RenderLayers layer = RenderLayers.All)
      : base(priority, layer)
    {
      this._texture = Main.Assets.Request<Texture2D>(textureName == null ? "" : textureName, (AssetRequestMode) 1);
      this._shader = new ScreenShaderData(Main.ScreenShaderRef, shaderName);
    }

    public ScreenShaderData GetShader() => this._shader;

    public override void Draw(SpriteBatch spriteBatch)
    {
      this._shader.UseGlobalOpacity(this.Opacity);
      this._shader.UseTargetPosition(this.TargetPosition);
      this._shader.Apply();
      spriteBatch.Draw(this._texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Main.ColorOfTheSkies);
    }

    public override void Update(GameTime gameTime) => this._shader.Update(gameTime);

    public override void Activate(Vector2 position, params object[] args)
    {
      this.TargetPosition = position;
      this.Mode = OverlayMode.FadeIn;
    }

    public override void Deactivate(params object[] args) => this.Mode = OverlayMode.FadeOut;

    public override bool IsVisible() => (double) this._shader.CombinedOpacity > 0.0;
  }
}
