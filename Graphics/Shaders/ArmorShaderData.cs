// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.ArmorShaderData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: C:\Users\mikeyisbaeyt\Downloads\depotdownloader-2.4.5\depots\105601\6707058\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class ArmorShaderData : ShaderData
  {
    private Vector3 _uColor = Vector3.One;
    private Vector3 _uSecondaryColor = Vector3.One;
    private float _uSaturation = 1f;
    private float _uOpacity = 1f;
    private Asset<Texture2D> _uImage;
    private Vector2 _uTargetPosition = Vector2.One;

    public ArmorShaderData(Ref<Effect> shader, string passName)
      : base(shader, passName)
    {
    }

    public virtual void Apply(Entity entity, DrawData? drawData = null)
    {
      this.Shader.Parameters["uColor"].SetValue(this._uColor);
      this.Shader.Parameters["uSaturation"].SetValue(this._uSaturation);
      this.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
      this.Shader.Parameters["uTime"].SetValue(Main.GlobalTimeWrappedHourly);
      this.Shader.Parameters["uOpacity"].SetValue(this._uOpacity);
      this.Shader.Parameters["uTargetPosition"].SetValue(this._uTargetPosition);
      if (drawData.HasValue)
      {
        DrawData drawData1 = drawData.Value;
        Vector4 vector4 = !drawData1.sourceRect.HasValue ? new Vector4(0.0f, 0.0f, (float) drawData1.texture.Width, (float) drawData1.texture.Height) : new Vector4((float) drawData1.sourceRect.Value.X, (float) drawData1.sourceRect.Value.Y, (float) drawData1.sourceRect.Value.Width, (float) drawData1.sourceRect.Value.Height);
        this.Shader.Parameters["uSourceRect"].SetValue(vector4);
        this.Shader.Parameters["uLegacyArmorSourceRect"].SetValue(vector4);
        this.Shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + drawData1.position);
        this.Shader.Parameters["uImageSize0"].SetValue(new Vector2((float) drawData1.texture.Width, (float) drawData1.texture.Height));
        this.Shader.Parameters["uLegacyArmorSheetSize"].SetValue(new Vector2((float) drawData1.texture.Width, (float) drawData1.texture.Height));
        this.Shader.Parameters["uRotation"].SetValue(drawData1.rotation * (drawData1.effect.HasFlag((Enum) SpriteEffects.FlipHorizontally) ? -1f : 1f));
        this.Shader.Parameters["uDirection"].SetValue(drawData1.effect.HasFlag((Enum) SpriteEffects.FlipHorizontally) ? -1 : 1);
      }
      else
      {
        Vector4 vector4 = new Vector4(0.0f, 0.0f, 4f, 4f);
        this.Shader.Parameters["uSourceRect"].SetValue(vector4);
        this.Shader.Parameters["uLegacyArmorSourceRect"].SetValue(vector4);
        this.Shader.Parameters["uRotation"].SetValue(0.0f);
      }
      if (this._uImage != null)
      {
        Main.graphics.GraphicsDevice.Textures[1] = (Texture) this._uImage.Value;
        this.Shader.Parameters["uImageSize1"].SetValue(new Vector2((float) this._uImage.Width(), (float) this._uImage.Height()));
      }
      if (entity != null)
        this.Shader.Parameters["uDirection"].SetValue((float) entity.direction);
      if (entity is Player player)
      {
        Rectangle bodyFrame = player.bodyFrame;
        this.Shader.Parameters["uLegacyArmorSourceRect"].SetValue(new Vector4((float) bodyFrame.X, (float) bodyFrame.Y, (float) bodyFrame.Width, (float) bodyFrame.Height));
        this.Shader.Parameters["uLegacyArmorSheetSize"].SetValue(new Vector2(40f, 1120f));
      }
      this.Apply();
    }

    public ArmorShaderData UseColor(float r, float g, float b) => this.UseColor(new Vector3(r, g, b));

    public ArmorShaderData UseColor(Color color) => this.UseColor(color.ToVector3());

    public ArmorShaderData UseColor(Vector3 color)
    {
      this._uColor = color;
      return this;
    }

    public ArmorShaderData UseImage(string path)
    {
      this._uImage = Main.Assets.Request<Texture2D>(path, (AssetRequestMode) 1);
      return this;
    }

    public ArmorShaderData UseOpacity(float alpha)
    {
      this._uOpacity = alpha;
      return this;
    }

    public ArmorShaderData UseTargetPosition(Vector2 position)
    {
      this._uTargetPosition = position;
      return this;
    }

    public ArmorShaderData UseSecondaryColor(float r, float g, float b) => this.UseSecondaryColor(new Vector3(r, g, b));

    public ArmorShaderData UseSecondaryColor(Color color) => this.UseSecondaryColor(color.ToVector3());

    public ArmorShaderData UseSecondaryColor(Vector3 color)
    {
      this._uSecondaryColor = color;
      return this;
    }

    public ArmorShaderData UseSaturation(float saturation)
    {
      this._uSaturation = saturation;
      return this;
    }

    public virtual ArmorShaderData GetSecondaryShader(Entity entity) => this;
  }
}
