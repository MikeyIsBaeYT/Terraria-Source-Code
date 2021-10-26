// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.HairShaderData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class HairShaderData : ShaderData
  {
    protected Vector3 _uColor = Vector3.One;
    protected Vector3 _uSecondaryColor = Vector3.One;
    protected float _uSaturation = 1f;
    protected float _uOpacity = 1f;
    protected Asset<Texture2D> _uImage;
    protected bool _shaderDisabled;
    private Vector2 _uTargetPosition = Vector2.One;

    public bool ShaderDisabled => this._shaderDisabled;

    public HairShaderData(Ref<Effect> shader, string passName)
      : base(shader, passName)
    {
    }

    public virtual void Apply(Player player, DrawData? drawData = null)
    {
      if (this._shaderDisabled)
        return;
      this.Shader.Parameters["uColor"].SetValue(this._uColor);
      this.Shader.Parameters["uSaturation"].SetValue(this._uSaturation);
      this.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
      this.Shader.Parameters["uTime"].SetValue(Main.GlobalTimeWrappedHourly);
      this.Shader.Parameters["uOpacity"].SetValue(this._uOpacity);
      this.Shader.Parameters["uTargetPosition"].SetValue(this._uTargetPosition);
      if (drawData.HasValue)
      {
        DrawData drawData1 = drawData.Value;
        this.Shader.Parameters["uSourceRect"].SetValue(new Vector4((float) drawData1.sourceRect.Value.X, (float) drawData1.sourceRect.Value.Y, (float) drawData1.sourceRect.Value.Width, (float) drawData1.sourceRect.Value.Height));
        this.Shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + drawData1.position);
        this.Shader.Parameters["uImageSize0"].SetValue(new Vector2((float) drawData1.texture.Width, (float) drawData1.texture.Height));
      }
      else
        this.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0.0f, 0.0f, 4f, 4f));
      if (this._uImage != null)
      {
        Main.graphics.GraphicsDevice.Textures[1] = (Texture) this._uImage.Value;
        this.Shader.Parameters["uImageSize1"].SetValue(new Vector2((float) this._uImage.Width(), (float) this._uImage.Height()));
      }
      if (player != null)
        this.Shader.Parameters["uDirection"].SetValue((float) player.direction);
      this.Apply();
    }

    public virtual Color GetColor(Player player, Color lightColor) => new Color(lightColor.ToVector4() * player.hairColor.ToVector4());

    public HairShaderData UseColor(float r, float g, float b) => this.UseColor(new Vector3(r, g, b));

    public HairShaderData UseColor(Color color) => this.UseColor(color.ToVector3());

    public HairShaderData UseColor(Vector3 color)
    {
      this._uColor = color;
      return this;
    }

    public HairShaderData UseImage(string path)
    {
      this._uImage = Main.Assets.Request<Texture2D>(path, (AssetRequestMode) 1);
      return this;
    }

    public HairShaderData UseOpacity(float alpha)
    {
      this._uOpacity = alpha;
      return this;
    }

    public HairShaderData UseSecondaryColor(float r, float g, float b) => this.UseSecondaryColor(new Vector3(r, g, b));

    public HairShaderData UseSecondaryColor(Color color) => this.UseSecondaryColor(color.ToVector3());

    public HairShaderData UseSecondaryColor(Vector3 color)
    {
      this._uSecondaryColor = color;
      return this;
    }

    public HairShaderData UseSaturation(float saturation)
    {
      this._uSaturation = saturation;
      return this;
    }

    public HairShaderData UseTargetPosition(Vector2 position)
    {
      this._uTargetPosition = position;
      return this;
    }
  }
}
