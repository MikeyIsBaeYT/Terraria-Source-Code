// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.MiscShaderData
// Assembly: Terraria, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: 68659D26-2BE6-448F-8663-74FA559E6F08
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class MiscShaderData : ShaderData
  {
    private Vector3 _uColor = Vector3.One;
    private Vector3 _uSecondaryColor = Vector3.One;
    private float _uSaturation = 1f;
    private float _uOpacity = 1f;
    private Ref<Texture2D> _uImage;

    public MiscShaderData(Ref<Effect> shader, string passName)
      : base(shader, passName)
    {
    }

    public virtual void Apply(DrawData? drawData = null)
    {
      this.Shader.Parameters["uColor"].SetValue(this._uColor);
      this.Shader.Parameters["uSaturation"].SetValue(this._uSaturation);
      this.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
      this.Shader.Parameters["uTime"].SetValue(Main.GlobalTime);
      this.Shader.Parameters["uOpacity"].SetValue(this._uOpacity);
      if (drawData.HasValue)
      {
        DrawData drawData1 = drawData.Value;
        Vector4 vector4 = Vector4.Zero;
        if (drawData.Value.sourceRect.HasValue)
          vector4 = new Vector4((float) drawData1.sourceRect.Value.X, (float) drawData1.sourceRect.Value.Y, (float) drawData1.sourceRect.Value.Width, (float) drawData1.sourceRect.Value.Height);
        this.Shader.Parameters["uSourceRect"].SetValue(vector4);
        this.Shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + drawData1.position);
        this.Shader.Parameters["uImageSize0"].SetValue(new Vector2((float) drawData1.texture.Width, (float) drawData1.texture.Height));
      }
      else
        this.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0.0f, 0.0f, 4f, 4f));
      if (this._uImage != null)
      {
        Main.graphics.GraphicsDevice.Textures[1] = (Texture) this._uImage.Value;
        this.Shader.Parameters["uImageSize1"].SetValue(new Vector2((float) this._uImage.Value.Width, (float) this._uImage.Value.Height));
      }
      this.Apply();
    }

    public MiscShaderData UseColor(float r, float g, float b) => this.UseColor(new Vector3(r, g, b));

    public MiscShaderData UseColor(Color color) => this.UseColor(color.ToVector3());

    public MiscShaderData UseColor(Vector3 color)
    {
      this._uColor = color;
      return this;
    }

    public MiscShaderData UseImage(string path)
    {
      this._uImage = TextureManager.AsyncLoad(path);
      return this;
    }

    public MiscShaderData UseOpacity(float alpha)
    {
      this._uOpacity = alpha;
      return this;
    }

    public MiscShaderData UseSecondaryColor(float r, float g, float b) => this.UseSecondaryColor(new Vector3(r, g, b));

    public MiscShaderData UseSecondaryColor(Color color) => this.UseSecondaryColor(color.ToVector3());

    public MiscShaderData UseSecondaryColor(Vector3 color)
    {
      this._uSecondaryColor = color;
      return this;
    }

    public MiscShaderData UseSaturation(float saturation)
    {
      this._uSaturation = saturation;
      return this;
    }

    public virtual MiscShaderData GetSecondaryShader(Entity entity) => this;
  }
}
